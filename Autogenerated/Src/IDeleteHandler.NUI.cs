namespace BPMSoft.Configuration {
	using System;
	using BPMSoft.Core.Entities;

	#region Interface: IDeleteHandler

	/// <summary>
	/// Implement delete record of entity.
	/// </summary>
	public interface IDeleteHandler {

		/// <summary>
		/// Returns exception of delete.
		/// </summary>
		Exception Exception { get; }

		/// <summary>
		/// Returns error message of delete.
		/// </summary>
		string ErrorMessage { get; }

		/// <summary>
		/// Deletes entity by record identifier.
		/// </summary>
		/// <param name="recordId">Entity identifier.</param>
		/// <returns>Result of delete.</returns>
		bool Delete(Guid recordId);

	}

	#endregion

}

