using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ASP_Net_RepositoryPattern.DAL.Interfaces;

namespace ASP_Net_RepositoryPatternTest.Mocks.RepositoryMocks
{
    public abstract class GenericMockRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal List<TEntity> EntitySet;

        protected GenericMockRepository()
        {
            EntitySet = new List<TEntity>();
        }

        public void Dispose()
        {
            // Do nothing
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = EntitySet.AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.ToList();
        }

        // Because ID can be anything and there is no common base class for entities
        // in this project this has to be implemented in the actual repository
        public abstract TEntity GetById(object id);

        public void Insert(TEntity entity)
        {
            EntitySet.Add(entity);
        }

        public void Delete(object id)
        {
            EntitySet.Remove(GetById(id));
        }

        public void Delete(TEntity entity)
        {
            EntitySet.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            // Update does not really do anything since changing the item will automatically change the item in the list
            // because these are reference types. There is nothing to be persisted elsewhere.
        }

        public void Save()
        {
            // This also does not do anything because there is nothing to be persisted. Everything is in memory.
        }
    }
}