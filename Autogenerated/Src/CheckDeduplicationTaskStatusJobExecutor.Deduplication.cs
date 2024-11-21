namespace BPMSoft.Configuration.Deduplication
{
	using System;
	using System.Collections.Generic;
	using global::Common.Logging;
	using DeduplicationElastic.Domain.Deduplication.Task;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Http.Abstractions;

	#region Class: CheckDeduplicationTaskStatusJobExecutor

	/// <summary>
	/// Job executor that checks deduplication task status. 
	/// </summary>
	public class CheckDeduplicationTaskStatusJobExecutor : IJobExecutor
	{

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("Deduplication");

		#endregion

		#region Fields: Public

		public static string EntityNameParamName = "entityName";
		public static string IndexNameParamName = "indexName";
		public static string JobGroupNameSuffix = "CheckDeduplicationTaskStatusJob";

		#endregion

		#region Properties: Private

		private IDeduplicationRemindingRepository DeduplicationRemindingRepository {
			get {
				return ClassFactory.Get<IDeduplicationRemindingRepository>();
			}
		}

		private IAppSchedulerWraper AppSchedulerWrapper {
			get {
				return ClassFactory.Get<IAppSchedulerWraper>();
			}
		}

		#endregion

		#region Methods: Private

		private IBulkDeduplicationTaskClient GetBulkDeduplicationTaskRestClient(UserConnection userConnection) {
			var connectionArg = new ConstructorArgument("userConnection", userConnection);
			return ClassFactory.Get<IBulkDeduplicationTaskClient>(connectionArg);
		}

		private string GetRemindingSubject(UserConnection userConnection, DeduplicationTaskStatus? deduplicationTaskStatus) {
			var localazibleStringName = string.Empty;
			switch (deduplicationTaskStatus) {
				case DeduplicationTaskStatus.Canceled:
					localazibleStringName = "FaildDuplicatesSearchMessage";
					break;
				case DeduplicationTaskStatus.Completed:
					return userConnection.GetLocalizableString("CheckDeduplicationTaskStatusJobExecutor",
						"SuccessfullDuplicatesSearchMessage");
				case DeduplicationTaskStatus.Failed:
				case null:
					localazibleStringName = "FaildDuplicatesSearchMessage";
					break;
				default:
					return null;
			}
			return userConnection.GetLocalizableString("DeduplicationActionHelper",
				localazibleStringName);
		}

		private void CreateReminding(UserConnection userConnection, DeduplicationTaskStatus? deduplicationTaskStatus,
				string entityName) {
			var remindingDescription = userConnection.GetLocalizableString("DeduplicationActionHelper",
				"RemindingDescription");
			var remindingSubject = GetRemindingSubject(userConnection, deduplicationTaskStatus);
			DeduplicationRemindingRepository.CreateReminding(userConnection, remindingDescription, remindingSubject, entityName);
		}

		private void RemoveJob(string entityName) {
			AppSchedulerWrapper.RemoveGroupJobs(GetCheckDeduplicationStatusJobGroupName(entityName));
		}
		
		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns check deduplication task status job group name based on entity.
		/// </summary>
		/// <param name="entityName">Entity name.</param>
		/// <returns>Job group name.</returns>
		public static string GetCheckDeduplicationStatusJobGroupName(string entityName) {
			return $"{entityName}{JobGroupNameSuffix}";
		}

		/// <summary>
		/// Executes deduplication task status check job.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="parameters">Checking job parameters.</param>
		public void Execute(UserConnection userConnection, IDictionary<string, object> parameters) {
			var entityName = (string)parameters[EntityNameParamName];
			var indexName = (string)parameters[IndexNameParamName];
			try {
				var deduplicationTaskRestClient = GetBulkDeduplicationTaskRestClient(userConnection);
				var deduplicationTaskStatus =
					deduplicationTaskRestClient.GetDeduplicationTaskStatus(entityName, indexName);
				if (deduplicationTaskStatus.HasValue && deduplicationTaskStatus == DeduplicationTaskStatus.Running) {
					return;
				}
				CreateReminding(userConnection, deduplicationTaskStatus, entityName);
				RemoveJob(entityName);
			} catch (HttpException httpException) {
				RemoveJob(entityName);
				_log.Error($"HttpException during processing {nameof(CheckDeduplicationTaskStatusJobExecutor)}", httpException);
			} catch (Exception exception) {
				_log.Error($"Error during processing {nameof(CheckDeduplicationTaskStatusJobExecutor)}", exception);
			}
		}

		#endregion

	}

	#endregion

}
