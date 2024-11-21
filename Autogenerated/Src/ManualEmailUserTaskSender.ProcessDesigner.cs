namespace BPMSoft.Core.Process.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Mail.Sender;

	#region Class: ManualEmailUserTaskSender

	public class ManualEmailUserTaskSender : IEmailUserTaskSender
	{

		#region Properties: Public

		public UserConnection UserConnection { get; set; }

		/// <inheritdoc />
		public bool NeedUserInteraction => true;

		#endregion

		#region Methods: Private

		private static void SetParameterByActivity(EmailTemplateUserTask userTask, Activity activity,
				string parameterName) {
			EntitySchemaColumn column = activity.Schema.Columns.FindByName(parameterName);
			if (column == null) {
				return;
			}
			object columnValue = activity.GetColumnValue(column);
			if (columnValue != null) {
				userTask.SetPropertyValue(parameterName, columnValue);
			}
		}

		private static void SetActivityRemindToOwnerDate(Activity activity, EmailTemplateUserTask userTask) {
			if (userTask.OwnerId.IsEmpty()) {
				return;
			}
			activity.OwnerId = userTask.OwnerId;
			if (userTask.RemindBefore != 0) {
				activity.RemindToOwner = true;
				var processDurationPeriod = (ProcessDurationPeriod)userTask.RemindBeforePeriod;
				int offset = -1 * userTask.RemindBefore;
				DateTime remindToOwnerDate = BaseProcessUserTaskUtilities.AddOffsetToDate(activity.StartDate, offset,
					processDurationPeriod);
				activity.RemindToOwnerDate = remindToOwnerDate;
			}
		}

		private void CreateActivity(IEmailUserTaskMessageProvider messageProvider) {
			EmailTemplateUserTask userTask = messageProvider.EmailUserTask;
			EmailMessage message = messageProvider.GetEmailMessage();
			CreateActivity(message, userTask);
		}

		private void CreateActivity(EmailMessage message, EmailTemplateUserTask userTask) {
			if (!UserConnection.GetIsFeatureEnabled("UseProcessPerformerAssignment")) {
				Activity entity = ObsoleteCreateActivity(message, userTask);
				userTask.AddEmailAttachments(entity, message.Attachments);
				userTask.ExecuteAfterActivitySaveScript(entity);
				return;
			}
			userTask.CreateActivityEntity(message);
		}

		private Activity ObsoleteCreateActivity(EmailMessage message, EmailTemplateUserTask userTask) {
			var activity = new Activity(UserConnection);
			activity.SetDefColumnValues();
			activity.Id = Guid.NewGuid();
			activity.TypeId = ActivityConsts.EmailTypeUId;
			activity.MessageTypeId = ActivityConsts.OutgoingEmailTypeId;
			userTask.Subject = message.Subject;
			activity.Title = message.Subject;
			ProcessDurationPeriod offsetPeriod = (ProcessDurationPeriod)userTask.StartInPeriod;
			activity.StartDate = BaseProcessUserTaskUtilities.AddOffsetToDate(
				UserConnection.CurrentUser.GetCurrentDateTime(), userTask.StartIn, offsetPeriod);
			ProcessDurationPeriod offsetPeriod1 = (ProcessDurationPeriod)userTask.DurationPeriod;
			activity.DueDate = BaseProcessUserTaskUtilities.AddOffsetToDate(activity.StartDate, userTask.Duration,
				offsetPeriod1);
			if (userTask.ActivityCategory.IsEmpty()) {
				userTask.ActivityCategory = ActivityConsts.EmailActivityCategoryId;
			}
			activity.ActivityCategoryId = userTask.ActivityCategory;
			activity.ShowInScheduler = userTask.ShowInScheduler;
			activity.Recepient = message.To.ConcatIfNotEmpty(";");
			activity.CopyRecepient = message.Cc.ConcatIfNotEmpty(";");
			activity.BlindCopyRecepient = message.Bcc.ConcatIfNotEmpty(";");
			activity.Body = message.Body;
			activity.IsHtmlBody = true;
			activity.Sender = message.From;
			SetActivityRemindToOwnerDate(activity, userTask);
			FillActivityConnections(activity, userTask);
			activity.ProcessElementId = userTask.UId;
			activity.AllowedResult = userTask.GetResultAllowedValues();
			LinkActivityToProcess(activity, userTask);
			userTask.IsActivityCompleted = false;
			userTask.ActivityId = activity.Id;
			return activity;
		}

		private void FillActivityConnections(Activity activity, EmailTemplateUserTask userTask) {
			IEnumerable<string> activityConnections = GetActivityConnections();
			foreach (string activityConnection in activityConnections) {
				object propertyValue = userTask.GetPropertyValue(activityConnection);
				ProcessUserTaskUtilities.SetEntityColumnValue(activity, activityConnection, propertyValue);
			}
			ProcessUserTaskUtilities.SetEntityColumnValues(userTask, activity);
		}

		private string GetActivityTitle(EmailTemplateUserTask userTask) {
			if (userTask.IsExecuted) {
				var select = (Select)new Select(UserConnection).
						Column("Title").
					From("Activity").
					Where("Id").IsEqual(Column.Parameter(userTask.ActivityId));
				return select.ExecuteScalar<string>();
			}
			return userTask.Subject;
		}

		private IEnumerable<string> GetActivityConnections() {
			return new[] {
				"Account",
				"Contact",
				"Lead",
				"Opportunity",
				"Invoice",
				"Order",
				"Project",
				"Contract",
				"Document",
				"Requests",
				"Listing",
				"Property",
				"Change",
				"Problem",
				"Release",
				"Case",
			};
		}

		#endregion

		#region Methods: Protected

		protected virtual void LinkActivityToProcess(Activity activity, EmailTemplateUserTask userTask) {
			Guid resultColumnUId = activity.Schema.Columns.GetByName("Status").UId;
			string conditionData = ProcessUserTaskUtilities.GetConditionData(UserConnection, resultColumnUId, activity);
			UserConnection.IProcessEngine.AddProcessListener(activity, userTask.UId, conditionData);
			UserConnection.IProcessEngine.LinkProcessToEntity(userTask.Owner, activity.Schema.UId, activity.Id);
		}

		#endregion

		#region Methods: Public

		public bool Execute(IEmailUserTaskMessageProvider messageProvider, ProcessExecutingContext context) {
			EmailTemplateUserTask userTask = messageProvider.EmailUserTask;
			Guid activityId = userTask.ActivityId;
			bool showExecutionPage = userTask.ShowExecutionPage;
			bool isActivityCompleted = userTask.IsActivityCompleted;
			bool activityExists = activityId.IsNotEmpty() && !isActivityCompleted;
			if (GlobalAppSettings.FeatureResetParameterValuesBeforeReExecuteProcessElement &&
					userTask.Status == ProcessStatus.Error) {
				bool isActivityCreated = ProcessUserTaskUtilities.GetIsActivityCreated(UserConnection, userTask.UId);
				if (activityId.IsEmpty() && !isActivityCreated) {
					CreateActivity(messageProvider);
				}
			}
			if (!activityExists) {
				CreateActivity(messageProvider);
			}
			userTask.InteractWithUser(context, activityExists, showExecutionPage);
			return false;
		}

		public bool CompleteExecuting(EmailTemplateUserTask userTask, Func<object[], bool> callBase,
				params object[] parameters) {
			var activity = parameters[0] as Activity;
			if (activity == null) {
				return false;
			}
			userTask.OwnerId = activity.OwnerId;
			IEnumerable<string> activityConnections = GetActivityConnections();
			foreach (string activityConnection in activityConnections) {
				SetParameterByActivity(userTask, activity, activityConnection);
			}
			ProcessUserTaskUtilities.SetEntityColumnValues(userTask, activity);
			userTask.ActivityResult = activity.ResultId;
			userTask.IsActivityCompleted = true;
			bool result = callBase(parameters);
			activity.SetColumnValue("ProcessElementId", null);
			activity.UseAdminRights = false;
			activity.Save();
			return result;
		}

		public void CancelExecuting(EmailTemplateUserTask userTask, Action<object[]> callBase,
				params object[] parameters) {
			UserConnection.IProcessEngine.RemoveActivityProcessListener(userTask.ActivityId, userTask.UId,
				ActivityConsts.CanceledStatusUId);
			callBase(parameters);
		}

		public string GetExecutionData(EmailTemplateUserTask userTask) {
			string informationOnStep = LocalizableString.IsNullOrEmpty(userTask.InformationOnStep)
				? userTask.GetParameterValue("InformationOnStep")?.ToString() ?? string.Empty
				: userTask.InformationOnStep.Value;
			string allowedActivityResults = ProcessUserTaskUtilities.GetAllowedActivityResults(UserConnection,
				userTask.ActivityId);
			Guid parentProcessId = ProcessUserTaskUtilities.GetParentProcessId(userTask.Owner);
			return
				ServiceStackTextHelper.Serialize(
					new {
						procElUId = userTask.UId,
						name = userTask.Name,
						processId = parentProcessId,
						isProcessExecutedBySignal = userTask.Owner.IsProcessExecutedBySignal,
						processName = userTask.Owner.Name,
						entitySchemaName = "Activity",
						recommendation = GetActivityTitle(userTask),
						informationOnStep,
						pageTypeId = ActivityConsts.EmailTypeUId,
						activityRecordId = userTask.ActivityId,
						executionContext = userTask.ExecutionContext,
						nextProcElUId = "nextProcElUIdValue",
						allowedResults = allowedActivityResults
					});
		}

		/// <inheritdoc />
		[Obsolete("7.18.2 | Method is not in use and will be removed in upcoming builds")]
		public IProcessNotifier GetProcessNotifier(Func<IProcessNotifier> baseProcessNotifier) {
			return baseProcessNotifier();
		}

		#endregion

	}

	#endregion

}
