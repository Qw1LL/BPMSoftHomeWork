namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	#region Class: ESNNotificationCounter

	/// <summary>
	/// Provides a method to get the number of ESN notifications.
	/// </summary>
	/// <seealso cref="BPMSoft.Configuration.INotificationCounter" />
	public class ESNNotificationCounter : INotificationCounter
	{
		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		public ESNNotificationCounter(UserConnection userConnection) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private void ResponseHandler(IDataReader reader, IDictionary<string, int> result) {
			var count = reader.GetColumnValue<int>("Count");
			result.Add(NotificationGroupConst.ESNNotification, count);
		}

		#endregion

		#region Methods: Protected

		protected virtual Select GetCountSelect(Guid contactId) {
			var select = (Select) new Select(_userConnection)
				.Column(Func.Count(Column.Asterisk())).As("Count")
				.From("ESNNotification")
				.Where("OwnerId").IsEqual(Column.Parameter(contactId))
				.And("IsRead").IsEqual(Column.Const(false))
				.And("CreatedById").IsNotEqual(Column.Parameter(contactId));
			return select;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns notification counters by contact.
		/// </summary>
		/// <param name="contactId">Contact identifier.</param>
		/// <returns>
		/// Dictionary, where key is group of count and value is count.
		/// </returns>
		public IDictionary<string, int> GetNotificationCount(Guid contactId) {
			contactId.CheckArgumentEmpty(nameof(contactId));
			var result = new Dictionary<string, int>();
			var select = GetCountSelect(contactId);
			select.ExecuteReader(reader => ResponseHandler(reader, result));
			return result;
		}

		#endregion
	}

	#endregion
}
