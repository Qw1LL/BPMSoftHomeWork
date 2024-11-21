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

	#region Class: MailServer_ExchangeEventsProcess

	public partial class MailServer_ExchangeEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void RemoveMailboxSyncSettingsJob() {
			Select allowEmailDownloadingSelect = new Select(UserConnection)
				.Column("SenderEmailAddress")
			.From("MailboxSyncSettings")
			.Where("MailServerId").IsEqual(Column.Parameter(Entity.Id)) as Select;
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader reader = allowEmailDownloadingSelect.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						string senderEmailAddress = reader.GetColumnValue<string>("SenderEmailAddress");
						if (Entity.GetTypedColumnValue<Guid>("TypeId") == ExchangeConsts.ExchangeMailServerTypeId) {
							ExchangeUtility.RemoveSyncJob(UserConnection, senderEmailAddress,
								ExchangeUtility.MailSyncProcessName);
						} else if (Entity.GetTypedColumnValue<Guid>("TypeId") == ExchangeConsts.ImapMailServerTypeId) {
							var parameters = new Dictionary<string, object> {
								{ "SenderEmailAddress", senderEmailAddress },
								{ "CurrentUserId", UserConnection.CurrentUser.Id }
							};
							var scheduler = ClassFactory.Get<BPMSoft.Mail.IImapSyncJobScheduler>();
							scheduler.RemoveSyncJob(UserConnection, parameters);
						}
					}
				}
			}
		}

		#endregion

	}

	#endregion

}

