namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using global::Common.Logging;
	using IntegrationApi.Interfaces;
	using IntegrationApi.MailboxDomain.Interfaces;
	using IntegrationApi.MailboxDomain.Model;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Linq;
	using System.Text;

	#region Class: EnableNewCalendarSynchronizationProcessMethodsWrapper

	/// <exclude/>
	public class EnableNewCalendarSynchronizationProcessMethodsWrapper : ProcessModel
	{

		public EnableNewCalendarSynchronizationProcessMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ScriptTask1Execute", ScriptTask1Execute);
		}

		#region Methods: Private

		private bool ScriptTask1Execute(ProcessExecutingContext context) {
			var uc = Get<UserConnection>("UserConnection");
			var syncPeriod = Get<int>("SyncPeriod");
			var mailboxesStrings = Get<string>("Emails");
			var mailboxService = ClassFactory.Get<IMailboxService>(new ConstructorArgument("uc", uc));
			var mailboxes = mailboxService.GetAllMailboxes().Where(m => mailboxesStrings.Contains(m.SenderEmailAddress.ToLower()));
			foreach (var mailbox in mailboxes) {
				
				if(syncPeriod == -1) {
					var syncJobScheduler = ClassFactory.Get<ISyncJobScheduler>();
					syncJobScheduler.RemoveSyncJob(uc, mailbox.SenderEmailAddress, ExchangeUtility.ActivitySyncProcessName);
				} else {
					EnableCalendarSync(uc, mailbox.Id);
					ReCreateCalendarSyncJob(mailbox, ExchangeUtility.ActivitySyncProcessName, syncPeriod);
				}
			}
			return true;
		}

			private void ReCreateCalendarSyncJob(Mailbox mailbox, string processName, int syncPeriod) {
				var _logger = LogManager.GetLogger("Calendar");
				var uc = Get<UserConnection>("UserConnection");
				try {
					var parameters = new Dictionary<string, object> {
						{ "SenderEmailAddress", mailbox.SenderEmailAddress },
						{ "MailboxType", mailbox.TypeId },
						{ "PeriodInMinutes", syncPeriod }
					};
					var syncJobScheduler = ClassFactory.Get<ISyncJobScheduler>();
					_logger.Info($"Re-create calendar {mailbox.SenderEmailAddress} synchronization job by process.");
					syncJobScheduler.CreateSyncJob(uc, syncPeriod, processName, parameters);
				} catch (Exception ex) {
					_logger.Error($"Error re-creating calendar {mailbox.SenderEmailAddress} " +
						$"synchronization job by process.", ex);
				}
			}
			
			private void EnableCalendarSync(UserConnection uc, Guid mailboxId) {
				var update = new Update(uc, "ActivitySyncSettings")
					.Set("ImportAppointments", Column.Parameter(true))
					.Set("ExportActivities", Column.Parameter(true))
					.Where("MailboxSyncSettingsId")
						.IsEqual(Column.Parameter(mailboxId));
				update.Execute();
			}

		#endregion

	}

	#endregion

}

