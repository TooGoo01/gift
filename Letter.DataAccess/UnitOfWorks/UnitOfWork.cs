using Letter.DataAccess.Context;
using Letter.DataAccess.Entities.Base;
using Letter.DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Letter.DataAccess.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LetterDbContext _educationDbContext;
        private bool _isDisposed = false;
        private readonly Dictionary<Type, object> _repositories;
        private readonly ISession _session;

        public UnitOfWork(LetterDbContext educationDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _educationDbContext = educationDbContext;
            _repositories = new Dictionary<Type, object>();
            _session = httpContextAccessor.HttpContext?.Session;
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : EntityBase
        {
            if (_repositories.Keys.Contains(typeof(TEntity)) == true)
                return _repositories[typeof(TEntity)] as IGenericRepository<TEntity>;

            var repo = new GenericRepository<TEntity>(_educationDbContext);

            _repositories.Add(typeof(TEntity), repo);

            return repo;
        }

        public void Commit()
        {
            var entities = _educationDbContext.ChangeTracker.Entries<EntityBase>();

            foreach (var entityEntry in entities)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    entityEntry.Entity.RegUserId = 1;
                    entityEntry.Entity.RegDate = DateTime.Now;
                }
                else if (entityEntry.State == EntityState.Modified)
                {
                    entityEntry.Entity.EditUserId = 1;
                    entityEntry.Entity.EditDate = DateTime.Now;
                }
            }
            _educationDbContext.SaveChanges();
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                _educationDbContext.Dispose();
                _isDisposed = true;
            }
        }

        private TRepository GetRepository<TRepository>()
        {
            if (_repositories.Keys.Contains(typeof(TRepository)))
                return (TRepository)_repositories[typeof(TRepository)];

            var type = Assembly.GetExecutingAssembly().GetTypes()
               .FirstOrDefault(x => !x.IsAbstract
               && !x.IsInterface
               && x.Name == typeof(TRepository).Name.Substring(1));

            if (type == null)
                throw new Exception("Repository type is not found");

            var repository = (TRepository)Activator.CreateInstance(type, _educationDbContext);

            _repositories.Add(typeof(TRepository), repository);

            return repository;
        }
    }
}

