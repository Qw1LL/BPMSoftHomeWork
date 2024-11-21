namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;

	#region Interface: IContactsToSyncRequest

	/// <summary>
	/// Represents methods to get contacts for data synchronization.
	/// </summary>
	public interface IContactsToSyncRequest
	{

		#region Methods: Public

		/// <summary>
		/// Returns unique identifiers of contacts for data synchronization.
		/// </summary>
		/// <param name="userConnection">Instance of <see cref="UserConnection"/>.</param>
		/// <param name="startDate">Start date.</param>
		/// <returns>List of contact ids.</returns>
		IEnumerable<Guid> GetContactsToSync(UserConnection userConnection, DateTime startDate);

		#endregion

	}

	#endregion

}

