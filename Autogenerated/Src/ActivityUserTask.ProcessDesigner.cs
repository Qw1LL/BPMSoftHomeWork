namespace BPMSoft.Core.Process.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;

	#region Class: ActivityUserTask

	public partial class ActivityUserTask : IUserTaskActivityInfo, IProcessElementExtraDataBuilder
	{

		#region Methods: Private

		private Activity ObsoleteCreateActivity() {
			var activity = new Activity(UserConnection);
			activity.SetDefColumnValues();
			activity.Id = Guid.NewGuid();
			activity.TypeId = ActivityConsts.TaskTypeUId;
			string subject = GetActivityTitle();
			SysUserInfo currentUser = UserConnection.CurrentUser;
			DateTime startDate =
				NewDate(currentUser.GetCurrentDateTime(), StartIn, (ProcessDurationPeriod)StartInPeriod);
			activity.Title = subject;
			activity.StartDate = startDate;
			activity.DueDate = NewDate(activity.StartDate, Duration, (ProcessDurationPeriod)DurationPeriod);
			if (ActivityCategory.IsEmpty()) {
				ActivityCategory = ActivityConsts.TaskCategoryId;
			}
			activity.ActivityCategoryId = ActivityCategory;
			activity.ShowInScheduler = ShowInScheduler;
			if (OwnerId != Guid.Empty) {
				activity.OwnerId = OwnerId;
				if (RemindBefore != 0) {
					activity.RemindToOwner = true;
					activity.RemindToOwnerDate =
						NewDate(activity.StartDate, -1 * RemindBefore, (ProcessDurationPeriod)RemindBeforePeriod);
				}
			}
			EntitySchemaColumn columnLead = activity.Schema.Columns.FindByName("Lead");
			if (columnLead != null && Lead != Guid.Empty) {
				activity.SetColumnValue(columnLead, Lead);
			}
			if (Account != Guid.Empty) {
				activity.AccountId = Account;
			}
			if (Contact != Guid.Empty) {
				activity.ContactId = Contact;
			}
			EntitySchemaColumn columnOpportunity = activity.Schema.Columns.FindByName("Opportunity");
			if (columnOpportunity != null && Opportunity != Guid.Empty) {
				activity.SetColumnValue(columnOpportunity, Opportunity);
			}
			EntitySchemaColumn columnDocument = activity.Schema.Columns.FindByName("Document");
			if (columnDocument != null && Document != Guid.Empty) {
				activity.SetColumnValue(columnDocument, Document);
			}
			EntitySchemaColumn columnInvoice = activity.Schema.Columns.FindByName("Invoice");
			if (columnInvoice != null && Invoice != Guid.Empty) {
				activity.SetColumnValue(columnInvoice, Invoice);
			}
			EntitySchemaColumn columnCase = activity.Schema.Columns.FindByName("Case");
			if (columnCase != null && Case != Guid.Empty) {
				activity.SetColumnValue(columnCase, Case);
			}
			EntitySchemaColumn columnOrder = activity.Schema.Columns.FindByName("Order");
			if (columnOrder != null && Order != Guid.Empty) {
				activity.SetColumnValue(columnOrder, Order);
			}
			EntitySchemaColumn columnProject = activity.Schema.Columns.FindByName("Project");
			if (columnProject != null && Project != Guid.Empty) {
				activity.SetColumnValue(columnProject, Project);
			}
			EntitySchemaColumn columnRequests = activity.Schema.Columns.FindByName("Requests");
			if (columnRequests != null && Requests != Guid.Empty) {
				activity.SetColumnValue(columnRequests, Requests);
			}
			EntitySchemaColumn columnListing = activity.Schema.Columns.FindByName("Listing");
			if (columnListing != null && Listing != Guid.Empty) {
				activity.SetColumnValue(columnListing, Listing);
			}
			EntitySchemaColumn columnProperty = activity.Schema.Columns.FindByName("Property");
			if (columnProperty != null && Property != Guid.Empty) {
				activity.SetColumnValue(columnProperty, Property);
			}
			EntitySchemaColumn columnContract = activity.Schema.Columns.FindByName("Contract");
			if (columnContract != null && Contract != Guid.Empty) {
				activity.SetColumnValue(columnContract, Contract);
			}
			EntitySchemaColumn columnChange = activity.Schema.Columns.FindByName("Change");
			if (columnChange != null && Change != Guid.Empty) {
				activity.SetColumnValue(columnChange, Change);
			}
			EntitySchemaColumn columnRelease = activity.Schema.Columns.FindByName("Release");
			if (columnRelease != null && Release != Guid.Empty) {
				activity.SetColumnValue(columnRelease, Release);
			}
			EntitySchemaColumn columnProblem = activity.Schema.Columns.FindByName("Problem");
			if (columnProblem != null && Problem != Guid.Empty) {
				activity.SetColumnValue(columnProblem, Problem);
			}
			EntitySchemaColumn columnApplication = activity.Schema.Columns.FindByName("Application");
			if (columnApplication != null && Application != Guid.Empty) {
				activity.SetColumnValue(columnApplication, Application);
			}
			EntitySchemaColumn columnFinApplication = activity.Schema.Columns.FindByName("FinApplication");
			if (columnFinApplication != null && FinApplication != Guid.Empty) {
				activity.SetColumnValue(columnFinApplication, FinApplication);
			}
			BaseProcessUserTaskUtilities.SetEntityColumnValues(this, activity);
			activity.ProcessElementId = UId;
			activity.AllowedResult = GetResultAllowedValues();
			Guid resultColumnUId = activity.Schema.Columns.GetByName("Status").UId;

			// After adding process listener entity is saved
			UserConnection.IProcessEngine
				.AddProcessListener(activity, UId, GetConditionData(resultColumnUId, activity));
			UserConnection.IProcessEngine.LinkProcessToEntity(Owner, activity.Schema.UId, activity.Id);
			IsActivityCompleted = false;
			CurrentActivityId = activity.Id;
			return activity;
		}

		private  bool ObsoleteCompleteExecuting(object[] parameters) {
			if (!(parameters[0] is Activity activity)) {
				return false;
			}
			OwnerId = activity.OwnerId;
			EntitySchemaColumn columnLead = activity.Schema.Columns.FindByName("Lead");
			if (columnLead != null) {
				object lead = activity.GetColumnValue(columnLead);
				if (lead != null) {
					Lead = (Guid)lead;
				}
			}
			Account = activity.AccountId;
			Contact = activity.ContactId;
			EntitySchemaColumn columnOpportunity = activity.Schema.Columns.FindByName("Opportunity");
			if (columnOpportunity != null) {
				object opportunity = activity.GetColumnValue(columnOpportunity);
				if (opportunity != null) {
					Opportunity = (Guid)opportunity;
				}
			}
			EntitySchemaColumn columnInvoice = activity.Schema.Columns.FindByName("Invoice");
			if (columnInvoice != null) {
				object invoice = activity.GetColumnValue(columnInvoice);
				if (invoice != null) {
					Invoice = (Guid)invoice;
				}
			}
			EntitySchemaColumn columnOrder = activity.Schema.Columns.FindByName("Order");
			if (columnOrder != null) {
				object order = activity.GetColumnValue(columnOrder);
				if (order != null) {
					Order = (Guid)order;
				}
			}
			EntitySchemaColumn columnRequests = activity.Schema.Columns.FindByName("Requests");
			if (columnRequests != null) {
				object requests = activity.GetColumnValue(columnRequests);
				if (requests != null) {
					Requests = (Guid)requests;
				}
			}
			EntitySchemaColumn columnListing = activity.Schema.Columns.FindByName("Listing");
			if (columnListing != null) {
				object listing = activity.GetColumnValue(columnListing);
				if (listing != null) {
					Listing = (Guid)listing;
				}
			}
			EntitySchemaColumn columnProperty = activity.Schema.Columns.FindByName("Property");
			if (columnProperty != null) {
				object property = activity.GetColumnValue(columnProperty);
				if (property != null) {
					Property = (Guid)property;
				}
			}
			EntitySchemaColumn columnContract = activity.Schema.Columns.FindByName("Contract");
			if (columnContract != null) {
				object contract = activity.GetColumnValue(columnContract);
				if (contract != null) {
					Contract = (Guid)contract;
				}
			}
			EntitySchemaColumn columnProject = activity.Schema.Columns.FindByName("Project");
			if (columnProject != null) {
				object project = activity.GetColumnValue(columnProject);
				if (project != null) {
					Project = (Guid)project;
				}
			}
			EntitySchemaColumn columnDocument = activity.Schema.Columns.FindByName("Document");
			if (columnDocument != null) {
				object document = activity.GetColumnValue(columnDocument);
				if (document != null) {
					Document = (Guid)document;
				}
			}
			EntitySchemaColumn columnChange = activity.Schema.Columns.FindByName("Change");
			if (columnChange != null) {
				object change = activity.GetColumnValue(columnChange);
				if (change != null) {
					Change = (Guid)change;
				}
			}
			EntitySchemaColumn columnProblem = activity.Schema.Columns.FindByName("Problem");
			if (columnProblem != null) {
				object problem = activity.GetColumnValue(columnProblem);
				if (problem != null) {
					Problem = (Guid)problem;
				}
			}
			EntitySchemaColumn columnRelease = activity.Schema.Columns.FindByName("Release");
			if (columnRelease != null) {
				object release = activity.GetColumnValue(columnRelease);
				if (release != null) {
					Release = (Guid)release;
				}
			}
			EntitySchemaColumn columnApplication = activity.Schema.Columns.FindByName("Application");
			if (columnApplication != null) {
				object application = activity.GetColumnValue(columnApplication);
				if (application != null) {
					Application = (Guid)application;
				}
			}
			EntitySchemaColumn columnFinApplication = activity.Schema.Columns.FindByName("FinApplication");
			if (columnFinApplication != null) {
				object finApplication = activity.GetColumnValue(columnFinApplication);
				if (finApplication != null) {
					FinApplication = (Guid)finApplication;
				}
			}
			BaseProcessUserTaskUtilities.SetDynamicParameterValues(this, activity);
			ActivityResult = activity.ResultId;
			IsActivityCompleted = true;
			bool result = base.CompleteExecuting(parameters);
			activity.SetColumnValue("ProcessElementId", null);
			activity.UseAdminRights = false;
			activity.Save();
			return result;
		}

		#endregion

		#region Methods: Protected

		/// <inheritdoc />
		protected override bool InternalExecute(ProcessExecutingContext context) {
			if (GlobalAppSettings.FeatureResetParameterValuesBeforeReExecuteProcessElement &&
					Status == ProcessStatus.Error) {
				if (CurrentActivityId == Guid.Empty &&
						!ProcessUserTaskUtilities.GetIsActivityCreated(UserConnection, UId)) {
					Entity activity = CreateActivity();
					AfterActivitySaveScriptExecute(activity);
				}
			}
			bool isRunning = CurrentActivityId.IsNotEmpty() && !IsActivityCompleted;
			if (!isRunning) {
				Entity activity = CreateActivity();
				AfterActivitySaveScriptExecute(activity);
			}
			InteractWithUser(context, isRunning, ShowExecutionPage);
			return false;
		}

		#endregion

		#region Methods: Public

		public virtual Guid GetActivityType() {
			var select = (Select)new Select(UserConnection)
				.Column("Id")
				.From("ActivityType")
				.Where("Code").IsEqual(Column.Parameter("Activity"));
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dr = select.ExecuteReader(dbExecutor)) {
					if (dr.Read()) {
						return UserConnection.DBTypeConverter.DBValueToGuid(dr[0]);
					}
				}
			}
			return Guid.Empty;
		}

		public virtual DateTime NewDate(DateTime oldDate, int offset, ProcessDurationPeriod offsetPeriod) {
			switch (offsetPeriod) {
				default:
					return oldDate.AddMinutes(offset);
				case ProcessDurationPeriod.Hours:
					return oldDate.AddHours(offset);
				case ProcessDurationPeriod.Days:
					return oldDate.AddDays(offset);
				case ProcessDurationPeriod.Weeks:
					return oldDate.AddDays(offset * 7);
				case ProcessDurationPeriod.Months:
					return oldDate.AddMonths(offset);
			}
		}

		/// <inheritdoc />
		public override bool CompleteExecuting(params object[] parameters) {
			if (!UserConnection.GetIsFeatureEnabled("UseProcessPerformerAssignment")) {
				return ObsoleteCompleteExecuting(parameters);
			}
			var activity = parameters[0] as Activity;
			this.SynchronizeCompletedUserTaskActivity(new UserTaskActivitySyncOptions {
				UseEntityComplete = true,
				Activity = activity,
				RemoveListener = false
			});
			return base.CompleteExecuting(parameters);
		}

		public virtual string GetConditionData(Guid resultColumnUId, Entity activity) {
			return ProcessUserTaskUtilities.GetConditionData(UserConnection, resultColumnUId, activity);
		}

		public virtual string GetActivityTitle() {
			return ProcessUserTaskUtilities.GetActivityTitle(this, Recommendation, CurrentActivityId);
		}

		/// <inheritdoc />
		public override void CancelExecuting(params object[] parameters) {
			base.CancelExecuting(parameters);
			UserConnection.IProcessEngine
				.RemoveActivityProcessListener(CurrentActivityId, UId, ActivityConsts.CanceledStatusUId);
		}

		/// <inheritdoc />
		protected override void WriteExecutionData(IProcessExecutionDataWriter dataWriter) {
			base.WriteExecutionData(dataWriter);
			dataWriter.Write("entitySchemaName", "Activity");
			dataWriter.Write("activityRecordId", CurrentActivityId);
			dataWriter.Write("pageTypeId", ActivityConsts.TaskTypeUId);
			dataWriter.Write("nextProcElUId", "nextProcElUIdValue");
			dataWriter.Write("allowedResults",
				ProcessUserTaskUtilities.GetAllowedActivityResults(UserConnection, CurrentActivityId));
			dataWriter.Write("executionContext", ExecutionContext);
			dataWriter.Write("recommendation", GetActivityTitle());
			dataWriter.Write("informationOnStep", GetParameterValue("InformationOnStep", string.Empty));
		}

		/// <inheritdoc />
		public override string GetExecutionData() {
			if (UserConnection.GetIsFeatureEnabled("UseProcessPerformerAssignment")) {
				return base.GetExecutionData();
			}
			var element = (IProcessElementMetaInfo)GetSchemaElement();
			ProcessSchemaParameter informationOnStepParameter = element.Parameters.GetByName("InformationOnStep");
			object informationOnStep = GetParameterValue(informationOnStepParameter) ?? string.Empty;
			return SerializeToString(new {
				procElUId = UId,
				name = Name,
				processId = ProcessUserTaskUtilities.GetParentProcessId(Owner),
				isProcessExecutedBySignal = ProcessUserTaskUtilities.GetIsProcessExecutedBySignal(Owner),
				processName = Owner.Name,
				entitySchemaName = "Activity",
				recommendation = GetActivityTitle(),
				informationOnStep = informationOnStep.ToString(),
				pageTypeId = ActivityConsts.TaskTypeUId,
				activityRecordId = CurrentActivityId,
				executionContext = ExecutionContext,
				nextProcElUId = "nextProcElUIdValue",
				allowedResults = ProcessUserTaskUtilities.GetAllowedActivityResults(UserConnection, CurrentActivityId)
			});
		}

		public virtual Guid GetActivityEntitySchemaUId() {
			return ActivityConsts.ActivityEntitySchemaUId;
		}

		public Entity CreateActivity() {
			if (!UserConnection.GetIsFeatureEnabled("UseProcessPerformerAssignment")) {
				return ObsoleteCreateActivity();
			}
			if (ActivityCategory.IsEmpty()) {
				ActivityCategory = ActivityConsts.TaskCategoryId;
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
			return activity;
		}

		/// <inheritdoc />
		public override ProcessElementNotification GetNotificationData() {
			ProcessElementNotification notification = base.GetNotificationData();
			ProcessUserTaskUtilities.AssignNotificationData(notification, Recommendation, StartIn, StartInPeriod);
			return notification;
		}

		/// <inheritdoc />
		public IDictionary<string, object> GetExtraDataValues() {
			return new Dictionary<string, object> {
				{ ProcessElementExtraDataKeys.UserTaskEntitySchemaNameKey, "Activity"}
			};
		}

		#endregion

	}

	#endregion

	#region Class: ActivityUserTaskSchemaExtension

	/// <inheritdoc />
	public class ActivityUserTaskSchemaExtension : ProcessUserTaskSchemaExtension
	{

		#region Methods: Public

		/// <inheritdoc />
		public override Dictionary<Guid, string> GetResultParameterAllValues(UserConnection userConnection,
				ProcessSchemaUserTask schemaUserTask) {
			var results = new Dictionary<Guid, string>();
			ProcessSchemaParameter paramActivityCategory = schemaUserTask.Parameters.GetByName("ActivityCategory");
			string taskActivityCategoryId = "F51C4643-58E6-DF11-971B-001D60E938C6";
			if (paramActivityCategory.SourceValue.Source == ProcessSchemaParameterValueSource.ConstValue) {
				taskActivityCategoryId = paramActivityCategory.SourceValue.Value;
			}
			var select = new Select(userConnection).Distinct()
					.Column("ActivityResult", "Id")
					.Column("ActivityResult", "Name")
				.From("ActivityResult").WithHints(Hints.NoLock)
				.Join(JoinType.Inner, "ActivityCategoryResultEntry")
					.On("ActivityResult", "Id").IsEqual("ActivityCategoryResultEntry", "ActivityResultId")
				.Where("ActivityCategoryResultEntry", "ActivityCategoryId")
					.IsEqual(Column.Parameter(taskActivityCategoryId, "Guid")) as Select;
			using (DBExecutor dbExecutor = userConnection.EnsureDBConnection()) {
				using (IDataReader dr = select.ExecuteReader(dbExecutor)) {
					while (dr.Read()) {
						results.Add(userConnection.DBTypeConverter.DBValueToGuid(dr[0]), dr.GetString(1));
					}
				}
			}
			return results;
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
