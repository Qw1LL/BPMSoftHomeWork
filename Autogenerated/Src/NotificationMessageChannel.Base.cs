namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Common;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Messaging.Common;

	#region Class: NotificationMessageChannel

	public class NotificationMessageChannel
	{

		#region Fields: Private

		private readonly UserConnection _userConnection;

		private readonly IMsgChannelManager _channelManager;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Creates a new instance with specified user connection.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="channelManager">Channel manager.</param>
		public NotificationMessageChannel(UserConnection userConnection, IMsgChannelManager channelManager) { 
			userConnection.CheckArgumentNull("userConnection");
			channelManager.CheckArgumentNull("channelManager");
			_userConnection = userConnection;
			_channelManager = channelManager;
		}

		#endregion

		#region Methods: Private

		private Guid FindSysAdminUnitId(Guid contactId) {
			SysUserInfo currentUser = _userConnection.CurrentUser;
			if (currentUser.ContactId == contactId) {
				return currentUser.Id;
			}
			EntitySchemaManager entitySchemaManager = _userConnection.EntitySchemaManager;
			var esq = new EntitySchemaQuery(entitySchemaManager, "SysAdminUnit") {
				UseAdminRights = false,
				IgnoreDisplayValues = true,
				CanReadUncommitedData = true
			};
			EntitySchemaQueryColumn queryColumn = esq.AddColumn("Id");
			IEntitySchemaQueryFilterItem queryFilterItem =
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Contact", contactId);
			esq.Filters.Add(queryFilterItem);
			EntityCollection entities = esq.GetEntityCollection(_userConnection);
			if (entities.Count != 0) {
				Entity entity = entities.First.Value;
				return entity.GetTypedColumnValue<Guid>(queryColumn.Name);
			}
			return Guid.Empty;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Posts a message.
		/// </summary>
		/// <param name="contactId">Identifier of the contact.</param>
		/// <param name="messageBuilder">Message builder.</param>
		public void PostMessage(Guid contactId, INotificationMessageBuilder messageBuilder) {
			messageBuilder.CheckArgumentNull("messageBuilder");
			Guid adminUnitId = FindSysAdminUnitId(contactId);
			messageBuilder.SysAdminUnitId = adminUnitId;
			IMsg message = messageBuilder.Build();
			IMsgChannel channel = _channelManager.FindItemByUId(adminUnitId);
			if (channel != null) {
				channel.PostMessage(message);
			}
		}

		#endregion

	}

	#endregion

}

