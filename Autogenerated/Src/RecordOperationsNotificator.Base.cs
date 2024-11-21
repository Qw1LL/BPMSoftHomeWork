namespace BPMSoft.Configuration
{
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Messaging.Common;

	/// <inheritdoc cref="IRecordOperationsNotificator"/>
	[DefaultBinding(typeof(IRecordOperationsNotificator))]
	public class RecordOperationsNotificator : IRecordOperationsNotificator
	{

		#region Fields: Private

		/// <summary>
		/// <see cref="UserConnection"/> instance.
		/// </summary>
		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// .ctor.
		/// </summary>
		/// <param name="userConnection"><see cref="UserConnection"/> instance.</param>
		public RecordOperationsNotificator(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Get user IDs by contact.
		/// </summary>
		/// <param name="contacts">Collection of contact ids.</param>
		/// <returns>Collection of user ids.</returns>
		private IEnumerable<Guid> GetUsersId(List<Guid> contacts) {
			var result = Enumerable.Empty<Guid>();
			if (contacts.IsNullOrEmpty()) {
				return result;
			}
			var usersSelect = new Select(_userConnection)
				.Column("Id").Distinct()
				.From("SysAdminUnit")
				.Where("ContactId").In(Column.Parameters(contacts)) as Select;
			result = usersSelect.ExecuteEnumerable(reader => reader.GetColumnValue<Guid>("Id"));
			return result;
		}

		/// <summary>
		/// Get message type body for sending.
		/// </summary>
		/// <param name="schemaName">Entity schema name.</param>
		/// <returns>Message body type name.</returns>
		private string GetMessageBodyTypeName(string schemaName) {
			return $"{schemaName}RecordChange";
		}

		/// <summary>
		/// Send a message over a web socket.
		/// </summary>
		/// <param name="simpleMessage">Message for ws event.</param>
		/// <param name="users">Users identifier collection.</param>
		private void SendSocketMessage(SimpleMessage simpleMessage, IEnumerable<Guid> users) {
			var msgManager = MsgChannelManager.Instance;
			msgManager.Post(users, simpleMessage);
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IRecordOperationsNotificator.SendRecordChange(List{Guid}, string, Guid, EntityChangeType)"/>
		public void SendRecordChange(List<Guid> contactIds, string entitySchemaName, Guid recordId, EntityChangeType state) {
			if (!_userConnection.GetIsFeatureEnabled("RecordOperationsNotificator")) {
				return;
			}
			var usersId = GetUsersId(contactIds);
			if (usersId.IsNullOrEmpty()) {
				return;
			}
			var message = new {
				RecordId = recordId,
				State = state
			};
			var simpleMessage = new SimpleMessage {
				Body = JsonConvert.SerializeObject(message),
			};
			simpleMessage.Header.Sender = "RecordOperationsNotificator";
			simpleMessage.Header.BodyTypeName = GetMessageBodyTypeName(entitySchemaName);
			SendSocketMessage(simpleMessage, usersId);
		}

		/// <inheritdoc cref="IRecordOperationsNotificator.SendRecordChange(Guid, string, Guid, EntityChangeType)"/>
		public void SendRecordChange(Guid contactId, string entitySchemaName, Guid recordId, EntityChangeType state) {
			if (contactId == Guid.Empty) {
				return;
			}
			SendRecordChange(new List<Guid>() { contactId }, entitySchemaName, recordId, state);
		}

		#endregion

	}
}
