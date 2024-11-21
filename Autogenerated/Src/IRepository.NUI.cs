namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;

	#region Interface: IRepository

	/// <summary>
	/// Templated repository to abstract storage.
	/// </summary>
	/// <typeparam name="T">Stored entity type.</typeparam>
	public interface IRepository<T> where T : BaseStorableEntity
	{
		/// <summary>
		/// Returns entity by id.
		/// </summary>
		/// <param name="id">Entity id.</param>
		/// <returns>Entity.</returns>
		T Find(Guid id);

		/// <summary>
		/// Creates entity in storage and returns its id.
		/// </summary>
		/// <param name="entity">Creating entity.</param>
		/// <returns>Entity id.</returns>
		Guid Create(T entity);

		/// <summary>
		/// Removes entity by id.
		/// </summary>
		/// <param name="id">Entity id.</param>
		void Remove(Guid id);

		/// <summary>
		///	Searches items by predicate. 
		/// </summary>
		/// <param name="predicaticate">Predicate.</param>
		/// <returns>Search result.</returns>
		IEnumerable<T> Where(Func<T, bool> predicaticate);

		/// <summary>
		/// Returns entire storage.
		/// </summary>
		/// <returns>Storage items.</returns>
		IEnumerable<T> GetAll();
	}

	#endregion

}
