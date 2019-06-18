//-----------------------------------------------------------------------
// <copyright file="Repository.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CityQuest.Entities
{
    /// <summary>
    /// Repository class.
    /// </summary>
    /// <typeparam name="T">Database entity class.</typeparam>
    /// <seealso cref="CityQuest.Entities.IRepository{T}" />
    public class Repository<T> : IRepository<T> where T : class
    {
        /// <summary>
        /// The database context
        /// </summary>
        protected readonly CityQuestDBContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public Repository(CityQuestDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Gets the by identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The entity.</returns>
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// Gets the asynchronously.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>The list of entities.</returns>
        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        }

        /// <summary>
        /// Gets the asynchronously.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="include">The include.</param>
        /// <returns>The list of entities.</returns>
        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> include)
        {
            return await _dbContext.Set<T>().Where(predicate).Include(include).ToListAsync();
        }

        /// <summary>
        /// Lists all asynchronously.
        /// </summary>
        /// <returns>The list of entities.</returns>
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        /// <summary>
        /// Adds the asynchronously.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The entity.</returns>
        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        /// <summary>
        /// Updates the asynchronously.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The method is void.</returns>
        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes the asynchronously.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The method is void.</returns>
        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T[] entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
            await _dbContext.SaveChangesAsync();
        }
    }
}
