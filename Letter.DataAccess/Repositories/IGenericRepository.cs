﻿using Letter.DataAccess.Entities.Base;
using System.Linq.Expressions;

namespace Letter.DataAccess.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : EntityBase
    {
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null);

        TEntity Get(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);

        void Reload(TEntity entity);

        void Add(TEntity entity);
        void Update(TEntity entity);
        Task AddAsync(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);
        void UpdateRange(IEnumerable<TEntity> entities);

        void Attach(TEntity entity);

        void AttachRange(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);

        void Delete(Expression<Func<TEntity, bool>> predicate);

        void DeleteRange(IEnumerable<TEntity> entities);

        bool CheckExist(Expression<Func<TEntity, bool>> predicate = null);

        int Count(Expression<Func<TEntity, bool>> predicate = null);
    }
}
