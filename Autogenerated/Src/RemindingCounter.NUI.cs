namespace BPMSoft.Configuration
{
	using System;
	using System.Data;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	#region Class: RemindingCounter

	/// <summary>
	/// Provides a method to get the number of notifications by group.
	/// </summary>
	public class RemindingCounter : INotificationCounter
	{
		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		public RemindingCounter(UserConnection userConnection) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private Select GetRemindingCountSelect(Guid contactId) {
			var select = (Select) new Select(_userConnection)
				.Column(Func.Count(Column.Asterisk())).As("Count")
				.Column("NotificationType", "Name").As("Name")
				.From("Reminding")
				.InnerJoin("NotificationType").On("NotificationType", "Id").IsEqual("Reminding", "NotificationTypeId")
				.InnerJoin("VwSysSchemaInWorkspace").On("VwSysSchemaInWorkspace", "UId").IsEqual("Reminding", "SysEntitySchemaId")
				.Where("Reminding", "IsRead").IsEqual(Column.Const(false))
				.And("Reminding", "IsNeedToSend").IsEqual(Column.Const(false))
				.And("Reminding", "ContactId").IsEqual(Column.Parameter(contactId))
				.And("VwSysSchemaInWorkspace", "SysWorkspaceId").IsEqual(Column.Parameter(_userConnection.Workspace.Id))
				.GroupBy("NotificationType", "Name");
			return select;
		}

		private void ResponseHandler(IDataReader reader, IDictionary<string, int> result) {
			var notificationType = reader.GetColumnValue<string>("Name");
			var count = reader.GetColumnValue<int>("Count");
			result.Add(notificationType, count);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns notification counters by contact.
		/// </summary>
		/// <param name="contactId">Contact identifier.</param>
		/// <returns>Dictionary, where key is group of count and value is count.</returns>
		public IDictionary<string, int> GetNotificationCount(Guid contactId) {
			contactId.CheckArgumentEmpty(nameof(contactId));
			var result = new Dictionary<string, int>();
			var select = GetRemindingCountSelect(contactId);
			select.ExecuteReader(reader => { ResponseHandler(reader, result); });
			return result;
		}

		#endregion
	}

	#endregion
}
