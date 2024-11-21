namespace BPMSoft.Configuration
{
	using System;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Web.Common;
	using BPMSoft.Web.Common.ServiceRouting;


	#region Class: SecurePortalMessage

	/// <summary>
	/// Provides functionality for working with Portal message object, which is forbidden for changing by portal users.
	/// </summary>
	public class SecurePortalMessage
	{
		#region Fields: Private

		private readonly UserConnection _userConnection;
		
		#endregion

		#region Constructors: Public

		public SecurePortalMessage(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private Select GetPortalMessageSelect(Guid messageHistoryId, string historySchemaName) {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, historySchemaName);
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			var primaryKeyFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				esq.RootSchema.GetPrimaryColumnName(), messageHistoryId);
			esq.Filters.Add(primaryKeyFilter);
			var caseMessageHistorySelect = esq.GetSelectQuery(_userConnection);
			caseMessageHistorySelect
				.InnerJoin("PortalMessage").As("PM")
					.On("PM", "Id")
					.IsEqual(historySchemaName, "RecordId");
			caseMessageHistorySelect.Column("PM", "HideOnPortal");
			caseMessageHistorySelect.Column("PM", "FromPortal");
			caseMessageHistorySelect.Column("PM", "TypeId");
			caseMessageHistorySelect.InnerJoin("PortalMessageType").As("PMType")
					.On("PMType", "Id")
					.IsEqual("PM", "TypeId");
			caseMessageHistorySelect.Column("PMType", "Name").As("PMTypeName");
			return caseMessageHistorySelect;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Gets portal message attributes connected to <paramref name="messageHistoryId"/>
		/// </summary>
		/// <param name="messageHistoryId">MessageHistory identifier.</param>
		/// <param name="historySchemaName">Schema name of history object.</param>
		/// <returns>Portal message attributes.</returns>
		public SecurePortalMessageAttributes FetchAttributesByMessageHistory(Guid messageHistoryId,
				string historySchemaName) {
			Select select = GetPortalMessageSelect(messageHistoryId, historySchemaName);
			select.ExecuteSingleRecord(reader => new SecurePortalMessageAttributes {
				HideOnPortal = reader.GetColumnValue<bool>("HideOnPortal"),
				FromPortal = reader.GetColumnValue<bool>("FromPortal"),
				MessageTypeCaption = reader.GetColumnValue<string>("PMTypeName"),
				MessageType = reader.GetColumnValue<Guid>("TypeId")
			}, out SecurePortalMessageAttributes securePortalMessageAttributes);
			return securePortalMessageAttributes;
		}

		#endregion

	}

	#endregion

}
