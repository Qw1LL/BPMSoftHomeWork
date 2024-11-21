namespace BPMSoft.Core.Process.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using Newtonsoft.Json;
	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;

	#region Class: UserQuestionUserTask

	/// <summary>
	/// Represents user dialog which is a one of the process interactive element.
	/// </summary>
	public partial class UserQuestionUserTask : IUserTaskActivityInfo
	{

		#region Properties: Private

		private bool UseProcessPerformerAssignment =>
			UserConnection.GetIsFeatureEnabled("UseProcessPerformerAssignment");

		private bool CreateActivityFix => CreateActivity || !(Owner is ProcessComponentSet);

		#endregion

		#region Methods: Private

		private List<Dictionary<string, object>> GetDecisionOptionItems() {
			LocalizableParameterValuesList decisionOptionItems = null;
			if (BranchingDecisions.Value.IsNotNullOrEmpty()) {
				Process process = Owner;
				ProcessSchema processSchema = process.ProcessSchema;
				string resourceManagerName = processSchema.OwnerSchema == null
					? processSchema.GetResourceManagerName()
					: processSchema.OwnerSchema.GetResourceManagerName();
				ProcessSchemaBaseElement element = processSchema.GetBaseElementByUId(SchemaElementUId);
				string resourceItemName = "BaseElements." + element.Name + ".Parameters.BranchingDecisions.Value";
				var localizableString = new LocalizableString(Storage, resourceManagerName, resourceItemName);
				string value = localizableString.Value;
				if (value.IsNotNullOrEmpty()) {
					decisionOptionItems = LocalizableParameterValuesList.DeserializeFrom77FormatData(value, "Caption");
				} else {
					decisionOptionItems = LocalizableParameterValuesList.DeserializeData(BranchingDecisions.Value);
					decisionOptionItems.SetupDefaultLocalizableValues("Caption", NoCaptionLocalizableString.Value);
				}
			}
			return decisionOptionItems?.To77FormatList();
		}

		private bool CreateTechnicalActivityIfNeeded() {
			if (!CreateActivityFix) {
				return false;
			}
			bool isRedo = GlobalAppSettings.FeatureResetParameterValuesBeforeReExecuteProcessElement &&
				Status == ProcessStatus.Error && CurrentActivityId.IsEmpty() &&
				!ProcessUserTaskUtilities.GetIsActivityCreated(UserConnection, UId);
			bool activityExists = CurrentActivityId.IsNotEmpty() && !IsActivityCompleted;
			if (!activityExists || isRedo) {
				CreateTechnicalActivity();
			}
			return activityExists;
		}

		private bool ObsoleteCompleteExecuting(object[] parameters) {
			Guid activityStatusId = ProcessUserTaskUtilities.GetActivityStatus(UserConnection, CurrentActivityId);
			if (activityStatusId != ActivityConsts.CanceledStatusUId) {
				activityStatusId = ActivityConsts.CompletedStatusUId;
			}
			IProcessEngine processEngine = UserConnection.IProcessEngine;
			if (!processEngine.RemoveActivityProcessListener(CurrentActivityId, UId, activityStatusId)) {
				return false;
			}
			IsActivityCompleted = true;
			return base.CompleteExecuting(parameters);
		}

		private Entity ObsoleteCreateActivity() {
			var activity = new Activity(UserConnection);
			activity.SetDefColumnValues();
			activity.Id = Guid.NewGuid();
			activity.TypeId = ActivityConsts.TaskTypeUId;
			activity.Title = GetActivityTitle();
			activity.StartDate = GetDateTime(UserConnection.CurrentUser.GetCurrentDateTime(), StartIn,
				(ProcessDurationPeriod)StartInPeriod);
			activity.DueDate = GetDateTime(activity.StartDate, Duration, (ProcessDurationPeriod)DurationPeriod);
			activity.ActivityCategoryId = ActivityCategory;
			activity.ShowInScheduler = ShowInScheduler;
			if (OwnerId != Guid.Empty) {
				activity.OwnerId = OwnerId;
				if (RemindBefore != 0) {
					activity.RemindToOwner = true;
					activity.RemindToOwnerDate = GetDateTime(activity.StartDate, -1 * RemindBefore,
						(ProcessDurationPeriod)RemindBeforePeriod);
				}
			}
			var columnLead = activity.Schema.Columns.FindByName("Lead");
			if (columnLead != null && Lead != Guid.Empty) {
				activity.SetColumnValue(columnLead, Lead);
			}
			if (Account != Guid.Empty) {
				activity.AccountId = Account;
			}
			if (Contact != Guid.Empty) {
				activity.ContactId = Contact;
			}
			var columnOpportunity = activity.Schema.Columns.FindByName("Opportunity");
			if (columnOpportunity != null && Opportunity != Guid.Empty) {
				activity.SetColumnValue(columnOpportunity, Opportunity);
			}
			var columnInvoice = activity.Schema.Columns.FindByName("Invoice");
			if (columnInvoice != null && Invoice != Guid.Empty) {
				activity.SetColumnValue(columnInvoice, Invoice);
			}
			var columnCase = activity.Schema.Columns.FindByName("Case");
			if (columnCase != null && Case != Guid.Empty) {
				activity.SetColumnValue(columnCase, Case);
			}
			var columnOrder = activity.Schema.Columns.FindByName("Order");
			if (columnOrder != null && Order != Guid.Empty) {
				activity.SetColumnValue(columnOrder, Order);
			}
			var columnRequests = activity.Schema.Columns.FindByName("Requests");
			if (columnRequests != null && Requests != Guid.Empty) {
				activity.SetColumnValue(columnRequests, Requests);
			}
			var columnListing = activity.Schema.Columns.FindByName("Listing");
			if (columnListing != null && Listing != Guid.Empty) {
				activity.SetColumnValue(columnListing, Listing);
			}
			var columnProperty = activity.Schema.Columns.FindByName("Property");
			if (columnProperty != null && Property != Guid.Empty) {
				activity.SetColumnValue(columnProperty, Property);
			}
			var columnContract = activity.Schema.Columns.FindByName("Contract");
			if (columnContract != null && Contract != Guid.Empty) {
				activity.SetColumnValue(columnContract, Contract);
			}
			var columnProject = activity.Schema.Columns.FindByName("Project");
			if (columnProject != null && Project != Guid.Empty) {
				activity.SetColumnValue(columnProject, Project);
			}
			var columnDocument = activity.Schema.Columns.FindByName("Document");
			if (columnDocument != null && Document != Guid.Empty) {
				activity.SetColumnValue(columnDocument, Document);
			}
			var columnChange = activity.Schema.Columns.FindByName("Change");
			if (columnChange != null && Change != Guid.Empty) {
				activity.SetColumnValue(columnChange, Change);
			}
			var columnRelease = activity.Schema.Columns.FindByName("Release");
			if (columnRelease != null && Release != Guid.Empty) {
				activity.SetColumnValue(columnRelease, Release);
			}
			var columnProblem = activity.Schema.Columns.FindByName("Problem");
			if (columnProblem != null && Problem != Guid.Empty) {
				activity.SetColumnValue(columnProblem, Problem);
			}
			BaseProcessUserTaskUtilities.SetEntityColumnValues(this, activity);
			activity.ProcessElementId = UId;
			activity.AllowedResult = GetResultAllowedValues();
			Guid resultColumnUId = activity.Schema.Columns.GetByName("Status").UId;
			UserConnection.IProcessEngine
				.AddProcessListener(activity, UId, GetConditionData(resultColumnUId, activity));
			IsActivityCompleted = false;
			CurrentActivityId = activity.Id;
			return activity;
		}

		#endregion

		#region Methods: Protected

		/// <inheritdoc />
		protected override bool InternalExecute(ProcessExecutingContext context) {
			bool canSkipPerformerCheck = CreateTechnicalActivityIfNeeded();
			InteractWithUser(context, canSkipPerformerCheck, ShowExecutionPage);
			return false;
		}

		/// <inheritdoc />
		protected override void WriteExecutionData(IProcessExecutionDataWriter dataWriter) {
			base.WriteExecutionData(dataWriter);
			dataWriter.Write("urlToken", "ProcessCardModuleV2/UserQuestionProcessPageV2");
			dataWriter.Write("recommendation", GetActivityTitle());
			string informationOnStep = LocalizableString.IsNullOrEmpty(InformationOnStep)
				? GetParameterValue("InformationOnStep")?.ToString() ?? string.Empty
				: InformationOnStep.Value;
			dataWriter.Write("informationOnStep", informationOnStep);
			dataWriter.Write("activityRecordId", CurrentActivityId);
			dataWriter.Write("questionText", Question.ToString());
			dataWriter.Write("decisionMode", DecisionMode);
			dataWriter.Write("isDecisionRequired", IsDecisionRequired);
			List<Dictionary<string, object>> decisionOptionItems = GetDecisionOptionItems();
			dataWriter.WriteObject("decisionOptions", decisionOptionItems, false);
			dataWriter.Write("executionContext", ExecutionContext);
			dataWriter.Write("nextProcElUId", "nextProcElUIdValue");
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public override bool CompleteExecuting(params object[] parameters) {
			if (CurrentActivityId.IsEmpty()) {
				return base.CompleteExecuting(parameters);
			}
			if (!UseProcessPerformerAssignment) {
				return ObsoleteCompleteExecuting(parameters);
			}
			this.SynchronizeCompletedUserTaskActivity(new UserTaskActivitySyncOptions {
				RemoveListener = true,
				SynchronizeParameterValues = false
			});
			return base.CompleteExecuting(parameters);
		}

		/// <inheritdoc />
		public override void CancelExecuting(params object[] parameters) {
			base.CancelExecuting(parameters);
			if (CurrentActivityId.IsNotEmpty()) {
				IProcessEngine processEngine = UserConnection.IProcessEngine;
				processEngine.RemoveActivityProcessListener(CurrentActivityId, UId, ActivityConsts.CanceledStatusUId);
			}
		}

		/// <inheritdoc />
		public override string GetExecutionData() {
			if (UseProcessPerformerAssignment) {
				return base.GetExecutionData();
			}
			List<Dictionary<string, object>> decisionOptionItems = GetDecisionOptionItems();
			string informationOnStep = LocalizableString.IsNullOrEmpty(InformationOnStep)
				? GetParameterValue("InformationOnStep")?.ToString() ?? string.Empty
				: InformationOnStep.Value;
			string executionData = SerializeToString(new {
				procElUId = UId,
				name = Name,
				processId = ProcessUserTaskUtilities.GetParentProcessId(Owner),
				isProcessExecutedBySignal = ProcessUserTaskUtilities.GetIsProcessExecutedBySignal(Owner),
				processName = Owner.Name,
				urlToken = "ProcessCardModuleV2/UserQuestionProcessPageV2",
				recommendation = GetActivityTitle(),
				informationOnStep,
				activityRecordId = CurrentActivityId,
				questionText = Question.ToString(),
				decisionMode = DecisionMode,
				isDecisionRequired = IsDecisionRequired,
				decisionOptions = decisionOptionItems,
				executionContext = ExecutionContext,
				nextProcElUId = "nextProcElUIdValue"
			});
			string userContextData = ProcessLane?.GetUserContextData();
			if (!string.IsNullOrEmpty(userContextData)) {
				var sb = new StringBuilder(executionData);
				sb.Length--;
				sb.Append(",");
				sb.Append(userContextData);
				sb.Append("}");
				executionData = sb.ToString();
			}
			return executionData;
		}

		/// <inheritdoc />
		public override string GetResultAllowedValues() {
			Dictionary<Guid, string> resultAllowedValues = GetResultParameterAllowedValues();
			return JsonConvert.SerializeObject(resultAllowedValues, Formatting.None,
				new JsonSerializerSettings {
					TypeNameHandling = TypeNameHandling.All,
					TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple
				});
		}

		/// <inheritdoc />
		public override ProcessElementNotification GetNotificationData() {
			ProcessElementNotification notification = base.GetNotificationData();
			ProcessUserTaskUtilities.AssignNotificationData(notification, Recommendation, StartIn, StartInPeriod);
			return notification;
		}

		/// <summary>
		/// Returns date and time with the specified offset period.
		/// </summary>
		/// <param name="dateTime">Date time.</param>
		/// <param name="offset">Offset value.</param>
		/// <param name="offsetPeriod">Offset period.</param>
		/// <returns>Modified date and time.</returns>
		public virtual DateTime GetDateTime(DateTime dateTime, int offset, ProcessDurationPeriod offsetPeriod) {
			return BaseProcessUserTaskUtilities.AddOffsetToDate(dateTime, offset, offsetPeriod);
		}

		public virtual string GetActivityTitle() {
			return ProcessUserTaskUtilities.GetActivityTitle(this, Recommendation, CurrentActivityId);
		}

		public virtual string GetConditionData(Guid resultColumnUId, Entity activity) {
			return ProcessUserTaskUtilities.GetConditionData(UserConnection, resultColumnUId, activity);
		}

		public virtual Guid GetActivityEntitySchemaUId() {
			return ActivityConsts.ActivityEntitySchemaUId;
		}

		public Entity CreateTechnicalActivity() {
			if (!UseProcessPerformerAssignment) {
				return ObsoleteCreateActivity();
			}
			var info = new UserTaskActivityInfo {
				Title = GetActivityTitle(),
				TypeId = ActivityConsts.TaskTypeUId,
				StartOffset = new ProcessDateOffset(StartIn, (ProcessDurationPeriod)StartInPeriod),
				Duration = new ProcessDateOffset(Duration, (ProcessDurationPeriod)DurationPeriod),
				RemindOffset = new ProcessDateOffset(RemindBefore, (ProcessDurationPeriod)RemindBeforePeriod),
				PriorityId = ActivityPriority
			};
			Entity activity = this.CreateUserTaskActivity(info);
			IsActivityCompleted = false;
			CurrentActivityId = activity.PrimaryColumnValue;
			AfterActivitySaveScriptExecute(activity);
			return activity;
		}

		#endregion

	}

	#endregion

	#region Class: UserQuestionUserTaskSchemaExtension

	/// <exclude/>
	public class UserQuestionUserTaskSchemaExtension : ProcessUserTaskSchemaExtension
	{

		#region Methods: Public

		/// <inheritdoc />
		public override Dictionary<Guid, string> GetResultParameterAllValues(UserConnection userConnection,
				ProcessSchemaUserTask schemaUserTask) {
			var conditionValues = new Dictionary<Guid, string>();
			ProcessSchemaParameterCollection parameters = schemaUserTask.Parameters;
			ProcessSchemaParameter branchingDecisionsParameter = parameters.GetByName("BranchingDecisions");
			ProcessSchemaParameterValue sourceValue = branchingDecisionsParameter.SourceValue;
			LocalizableParameterValuesList items = sourceValue.LocalizableCollectionValue;
			if (items == null) {
				items = new LocalizableParameterValuesList();
			} else {
				items.SetupDefaultLocalizableValues("Caption", "No caption");
			}
			foreach (LocalizableParameterValues item in items) {
				conditionValues[new Guid(item["Id"].Value)] = item["Caption"].Value;
			}
			return conditionValues;
		}

		/// <inheritdoc />
		public override void SynchronizeDynamicParameters(UserConnection userConnection, ProcessUserTaskSchema target) {
			base.SynchronizeDynamicParameters(userConnection, target);
			ProcessUserTaskUtilities.SynchronizeActivityConnectionParameters(userConnection, target);
		}

		#endregion

	}

	#endregion

}
