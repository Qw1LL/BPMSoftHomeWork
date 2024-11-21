namespace BPMSoft.Configuration
{

	using DataContract = BPMSoft.Nui.ServiceModel.DataContract;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.Messaging.Common;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;

	#region Class: MailServer_BaseEventsProcess

	public partial class MailServer_BaseEventsProcess<TEntity>
	{

		#region Methods: Protected

		/// <summary>
		/// Returns current server <see cref="MailboxSyncSettings"/> identifiers.
		/// </summary>
		/// <returns>Current server <see cref="MailboxSyncSettings"/> identifiers.</returns>
		protected virtual List<Guid> GetCurrentMailserverMailboxIds() {
			var select = (Select)new Select(UserConnection)
				.Column("Id")
			.From("MailboxSyncSettings")
			.Where("MailServerId").IsEqual(Column.Parameter(Entity.PrimaryColumnValue));
			var mailboxIds = new List<Guid>();
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = select.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						mailboxIds.Add(dataReader.GetColumnValue<Guid>("Id"));
					}
				}
			}
			return mailboxIds;
		}

		#endregion

		#region Methods: Public

		public virtual void SendMessage(string operation) {
			string messageTpl = "{{\"Id\":\"{0}\"}}";
			string messageBody = String.Format(messageTpl, Entity.Id);
			Guid sysAdminUnitId = UserConnection.CurrentUser.Id;
			IMsgChannel channel = MsgChannelManager.Instance.FindItemByUId(sysAdminUnitId);
			if (channel == null) {
				return;
			}
			var simpleMessage = new SimpleMessage {
				Id = sysAdminUnitId,
				Body = messageBody
			};
			simpleMessage.Header.Sender = operation;
			channel.PostMessage(simpleMessage);
		}

		/// <summary>
		/// Clears current mail server mailboxes passwords.
		/// </summary>
		public virtual void ClearMailboxSyncSettingsPasswords() {
			Guid oldOAuthApplicationId = Entity.GetTypedOldColumnValue<Guid>("OAuthApplicationId");
			Guid oAuthApplicationId = Entity.GetTypedColumnValue<Guid>("OAuthApplicationId");
			if (oldOAuthApplicationId.IsEmpty() && oAuthApplicationId.IsNotEmpty()) {
				List<Guid> mailboxIds = GetCurrentMailserverMailboxIds();
				foreach (var mailboxId in mailboxIds) {
					var entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName("MailboxSyncSettings");
					Entity mailbox = entitySchema.CreateEntity(UserConnection);
					if (mailbox.FetchFromDB(mailboxId)) {
						mailbox.SetColumnValue("UserPassword", string.Empty);
						mailbox.Save();
					}
				}
			}
		}

		/// <summary>
		/// Deletes unused OAuth application.
		/// </summary>
		/// <param name="isUpdated">Sign that mail server was updated.</param>
		public virtual void DeleteUnusedOAuthApplication(bool isUpdated) {
			Guid oldOAuthApplicationId = Entity.GetTypedOldColumnValue<Guid>("OAuthApplicationId");
			if (oldOAuthApplicationId.IsNotEmpty() && Entity.GetTypedColumnValue<Guid>("OAuthApplicationId").IsEmpty()) {
				if (isUpdated) {
					ClearMailboxSyncSettingsOAuthTokenStorages();
				}
				new Delete(UserConnection).From("OAuthApplications")
					.Where("Id").IsEqual(Column.Parameter(oldOAuthApplicationId)).Execute();
			}
		}

		/// <summary>
		/// Clears current mail server mailboxes OAuth token storages.
		/// </summary>
		public virtual void ClearMailboxSyncSettingsOAuthTokenStorages() {
			List<Guid> mailboxIds = GetCurrentMailserverMailboxIds();
			foreach (var mailboxId in mailboxIds) {
				var entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName("MailboxSyncSettings");
				Entity mailbox = entitySchema.CreateEntity(UserConnection);
				if (mailbox.FetchFromDB(mailboxId)) {
					mailbox.SetColumnValue("OAuthTokenStorageId", null);
					mailbox.Save();
				}
			}
		}

		#endregion

	}

	#endregion

}

