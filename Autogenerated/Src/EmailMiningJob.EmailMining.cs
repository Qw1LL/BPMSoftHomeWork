namespace BPMSoft.Configuration.EmailMining
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using global::Common.Logging;
	using Newtonsoft.Json;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Messaging.Common;

	#region Class: EmailMiningJob

	/// <summary>
	/// Represents periodical task for email mining.
	/// </summary>
	public class EmailMiningJob : IJobExecutor
	{

		#region Constants: Private

		/// <summary>
		/// SysSetting name with mining process periodicity in minutes.
		/// </summary>
		private const string JobPeriodSysSettingsName = "EmailMiningPeriodMin";

		/// <summary>
		/// SysSetting name with email count for each process run.
		/// </summary>
		private const string EmailPackCountSysSettingsName = "EmailMiningPackageSize";

		/// <summary>
		/// Default value of email count for each process run.
		/// </summary>
		private const int DefEmailPackSize = 10;

		/// <summary>
		/// Delay in mininutes for next job execution if <see cref="IncorrectConfigurationException"/> occurred.
		/// </summary>
		private const int IncorrectConfigurationTimeShiftMinutes = 60;

		/// <summary>
		/// SysSetting for mining process enablement.
		/// </summary>
		private const string EnableEmailMiningSysSettingsName = "EnableEmailMining";
		private const string IdentificationActualPeriodSysSettingsName = "EmailMiningIdentificationActualPeriod";
		private const string MessageSender = "EmailMining";
		private const string MessageBodyTypeName = "EmailEnriched";

		#endregion

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("EmailMining");
		private readonly Lazy<IAppSchedulerWraper> _lazySchedulerWraper =
			new Lazy<IAppSchedulerWraper>(() => ClassFactory.Get<IAppSchedulerWraper>());

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="EmailMiningJob"/> class.
		/// </summary>
		public EmailMiningJob() {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="EmailMiningJob"/> class.
		/// </summary>
		/// <param name="msgChannelManager">The channel manager.</param>
		public EmailMiningJob(IMsgChannelManager msgChannelManager) {
			_channelManager = msgChannelManager;
		}

		#endregion

		#region Properties: Private

		private IMsgChannelManager _channelManager;
		private IMsgChannelManager ChannelManager {
			get {
				if (_channelManager != null) {
					return _channelManager;
				}
				if (MsgChannelManager.IsRunning) {
					_channelManager = MsgChannelManager.Instance;
				}
				return _channelManager;
			}
		}

		#endregion

		#region Methods: Private

		private void LogError(Exception exception) {
			_log.ErrorFormat("Exception where thrown during email mining job.", exception);
		}

		private EntityCollection GetUnprocessedEmailPack(UserConnection userConnection) {
			int rowNum = SysSettings.GetValue(userConnection, EmailPackCountSysSettingsName,
				DefEmailPackSize);
			int actualDaysPeriod = SysSettings.GetValue(userConnection,
				IdentificationActualPeriodSysSettingsName, 1);
			DateTime actualEmailsStartDate = DateTime.Today.AddDays(-actualDaysPeriod);
			EntitySchema activitySchema = userConnection.EntitySchemaManager.GetInstanceByName("Activity");
			var esq = new EntitySchemaQuery(activitySchema) {
				IgnoreDisplayValues = true
			};
			esq.PrimaryQueryColumn.IsVisible = true;
			esq.AddColumn("Body");
			esq.AddColumn("IsHtmlBody");
			esq.AddColumn("CreatedOn");
			esq.AddColumn("SendDate").OrderByDesc();
			esq.AddColumn("Sender");
			esq.RowCount = rowNum;
			esq.Filters.AddLengthFilter(activitySchema, "Body", FilterComparisonType.Greater, 0);
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Type",
				ActivityConsts.EmailTypeUId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "EnrichStatus",
				EnrichStatus.Inactive.ToString()));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.GreaterOrEqual, "SendDate",
				actualEmailsStartDate));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "[EmailMessageData:Activity:Id].Role",
				ActivityConsts.ActivityParticipantRoleTo, ActivityConsts.ActivityParticipantRoleCc, ActivityConsts.ActivityParticipantRoleBcc));
			return esq.GetEntityCollection(userConnection);
		}

		private Dictionary<Guid, List<Guid>> GetEmailSubsribers(UserConnection userConnection,
				EntityCollection emails) {
			IEnumerable<Guid> activityIds = emails.Select(entity => entity.PrimaryColumnValue);
			var select = (Select)new Select(userConnection)
					.Column("emd", "ActivityId")
					.Column("au", "Id").As("AdminUnitId")
				.From("EmailMessageData").As("emd")
					.InnerJoin("SysAdminUnit").As("au").On("emd", "OwnerId").IsEqual("au", "ContactId")
				.Where("emd", "ActivityId").In(Column.Parameters(activityIds));
			var subscribers = new Dictionary<Guid, List<Guid>>();
			using (DBExecutor dbExecutor = userConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = select.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						Guid subsriberId = dataReader.GetColumnValue<Guid>("AdminUnitId");
						Guid activityId = dataReader.GetColumnValue<Guid>("ActivityId");
						AddActivityForSubsciber(subscribers, subsriberId, activityId);
					}
				}
			}
			return subscribers;
		}

		private void AddActivityForSubsciber(Dictionary<Guid, List<Guid>> subscribers, Guid subsriberId,
				Guid activityId) {
			List<Guid> subsriberActivities;
			if (!subscribers.ContainsKey(subsriberId)) {
				subsriberActivities = new List<Guid>();
				subscribers.Add(subsriberId, subsriberActivities);
			} else {
				subsriberActivities = subscribers[subsriberId];
			}
			subsriberActivities.Add(activityId);
		}

		private void SendResultsToSubscribers(List<EmailMiner.MiningResult> results,
				Dictionary<Guid, List<Guid>> subscribers) {
			if (subscribers == null || results == null) {
				return;
			}
			var channelManager = ChannelManager;
			if (channelManager == null) {
				_log.Warn("Message channel manager is not running. Results won't be sent");
				return;
			}
			foreach (KeyValuePair<Guid, List<Guid>> valuePair in subscribers) {
				Guid subscriberId = valuePair.Key;
				IMsgChannel channel = channelManager.FindItemByUId(subscriberId);
				if (channel == null) {
					continue;
				}
				List<Guid> activityIds = valuePair.Value;
				List<EmailMiner.MiningResult> subscriberResults = results
					.Where(result => activityIds.Contains(result.ActivityId))
					.ToList();
				var simpleMessage = new SimpleMessage {
					Body = JsonConvert.SerializeObject(subscriberResults),
					Id = channel.Id
				};
				simpleMessage.Header.BodyTypeName = MessageBodyTypeName;
				simpleMessage.Header.Sender = MessageSender;
				channel.PostMessage(simpleMessage);
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Runs the email miner.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <returns>The count of the processed emails or <c>-1</c> if feature is not enabled.</returns>
		public virtual int RunMiner(UserConnection userConnection) {
			EntityCollection emails = GetUnprocessedEmailPack(userConnection);
			int processedCount = emails.Count;
			_log.InfoFormat("Emails to process: {0}", processedCount);
			if (emails.IsNotEmpty()) {
				EmailMiner emailMiner =
					ClassFactory.Get<EmailMiner>(new ConstructorArgument("userConnection", userConnection));
				List<EmailMiner.MiningResult> results = emailMiner.Execute(emails);
				Dictionary<Guid, List<Guid>> subscribers = GetEmailSubsribers(userConnection, emails);
				SendResultsToSubscribers(results, subscribers);
			}
			_log.Info("Email mining finished succcessfully");
			return processedCount;
		}

		/// <summary>
		/// Runs email mining and schedules next job.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="parameters">Job parameters.</param>
		public void Execute(UserConnection userConnection, IDictionary<string, object> parameters) {
			int timeShiftMinutes = 0;
			try {
				if (!SysSettings.GetValue<bool>(userConnection, EnableEmailMiningSysSettingsName, true)) {
					_log.InfoFormat("Email mining is disabled. See system settings value {0}",
						EnableEmailMiningSysSettingsName);
					return;
				}
				RunMiner(userConnection);
			} catch (IncorrectConfigurationException ex) {
				_log.Error(ex.Message);
				timeShiftMinutes = IncorrectConfigurationTimeShiftMinutes;
			} catch (Exception ex) {
				LogError(ex);
				throw;
			} finally {
				int periodMin = SysSettings.GetValue(userConnection, JobPeriodSysSettingsName, 0);
				if (periodMin == 0) {
					_log.Info($"SysSetting {JobPeriodSysSettingsName} equals to zero. Job will not be rescheduled.");
				} else {
					if (timeShiftMinutes > 0) {
						_log.Warn($"Next job will be run in {periodMin + timeShiftMinutes} minutes");
					}
					SchedulerUtils.ScheduleNextRun(userConnection, EmailMiningAppListener.TargetJobGroupName, this,
						periodMin + timeShiftMinutes);
				}
			}
		}

		#endregion

	}

	#endregion

}
