namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	#region Class: ContactsWithClicksToSyncRequest

	/// <summary>
	/// Class to implement logic to get contacts with clicks without existing touches.
	/// </summary>
	public class ContactsWithClicksToSyncRequest :  IContactsToSyncRequest
	{

		#region Methods: Private

		private Select GetContactsToSyncSelect(UserConnection userConnection, DateTime startDate) {
			var select = new Select(userConnection).Distinct()
				.Column("c", "Id").As("ContactId")
				.From("Contact", "c")
				.InnerJoin("MandrillClicks").As("mc")
					.On("c", "RId").IsEqual("mc", "ContactRId")
				.Where("mc", "TimeStamp")
					.IsGreaterOrEqual(Column.Parameter(startDate))
					.And().Not().Exists(
						new Select(userConnection)
							.Column("Id")
							.From(nameof(Touch))
							.Where("ContactId").IsEqual("c", "Id")) as Select;
			select.SpecifyNoLockHints();
			return select;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns unique identifiers of contacts with clicks without touches.
		/// </summary>
		/// <param name="userConnection">Instance of <see cref="UserConnection"/>.</param>
		/// <param name="startDate">Start date.</param>
		/// <returns>List of contact ids.</returns>
		public IEnumerable<Guid> GetContactsToSync(UserConnection userConnection, DateTime startDate) {
			var select = GetContactsToSyncSelect(userConnection, startDate);
			return select.ExecuteEnumerable<Guid>(reader => reader.GetColumnValue<Guid>("ContactId"));
		}

		#endregion

	}

	#endregion
}

