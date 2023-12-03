using Letter.DataAccess.Entities.Base;
using Letter.DataAccess.Repositories;

namespace Letter.DataAccess.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : EntityBase;

        void Commit();
    }
}
