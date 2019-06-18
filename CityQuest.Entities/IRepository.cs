//-----------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Dream Team">
//     Copyright (c) Dream Team. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CityQuest.Entities
{
    /// <summary>
    /// Repository interface.
    /// </summary>
    /// <typeparam name="T">Database entity class.</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Gets the by identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The entity.</returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Lists all asynchronously.
        /// </summary>
        /// <returns>The list of entities.</returns>
        Task<IReadOnlyList<T>> ListAllAsync();

        /// <summary>
        /// Adds the asynchronously.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The entity.</returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Updates the asynchronously.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The method is void.</returns>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Deletes the asynchronously.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The method is void.</returns>
        Task DeleteAsync(T entity);

        Task DeleteAsync(T[] entities);

        /// <summary>
        /// Gets the asynchronously.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>The list of entities.</returns>
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Gets the asynchronously.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="include">The include.</param>
        /// <returns>The list of entities.</returns>
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> include);
    }
}
