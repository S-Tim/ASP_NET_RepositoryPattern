using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ASP_Net_RepositoryPattern.DAL.Interfaces
{
    /// <summary>
    /// Represets the interface for a generic repository and includes basic CRUD methods
    /// </summary>
    /// <typeparam name="TEntity">The type of entity that is managed with this repository</typeparam>
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        /// <summary>
        /// Get method, that  retrieves the entities meeting the given expression or retrieves all
        /// if no expression is given.
        /// </summary>
        /// <param name="filter">Lambda expression that acts as a filter while retrieving the entities</param>
        /// <returns></returns>
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null);

        /// <summary>
        /// Gets an entity by its Id
        /// </summary>
        /// <param name="id">Id of the entity</param>
        /// <returns></returns>
        TEntity GetById(object id);

        /// <summary>
        /// Inserts a new entity
        /// </summary>
        /// <param name="entity">Entity object</param>
        void Insert(TEntity entity);

        /// <summary>
        /// Deletes an entity by Id
        /// </summary>
        /// <param name="id">Id of the entity</param>
        void Delete(object id);

        /// <summary>
        /// Deletes the given entity
        /// </summary>
        /// <param name="entity">Entity to be deleted</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Updates the given entity
        /// </summary>
        /// <param name="entity">Entity to be updated</param>
        void Update(TEntity entity);

        /// <summary>
        /// Persists all changes made to the entities
        /// </summary>
        void Save();
    }
}
