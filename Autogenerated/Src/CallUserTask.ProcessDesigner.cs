namespace BPMSoft.Core.Process.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;

	#region Class: CallUserTask

	/// <exclude/>
	public partial class CallUserTask : IProcessElementExtraDataBuilder
	{

		#region Methods: Protected

		/// <inheritdoc />
		protected override bool InternalExecute(ProcessExecutingContext context) {
			if (Status == ProcessStatus.Error) {
				if (CurrentActivityId == Guid.Empty &&
						!ProcessUserTaskUtilities.GetIsActivityCreated(UserConnection, UId)) {
					AfterActivitySaveScriptExecute(CreateActivity());
				}
			}
			bool isRunning = !CurrentActivityId.Equals(Guid.Empty) && !IsActivityCompleted;
			if (!isRunning) {
				AfterActivitySaveScriptExecute(CreateActivity());
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
				.Where("Code").IsEqual(Column.Parameter("Call"));
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
			switch(offsetPeriod) {
				default:
				case ProcessDurationPeriod.Minutes:
					return oldDate.AddMinutes(offset);
				case ProcessDurationPeriod.Hours:
					return oldDate.AddHours(offset);
				case ProcessDurationPeriod.Days:
					return oldDate.AddDays(offset);
				case ProcessDurationPeriod.Weeks:
					return oldDate.AddDays(offset*7);
				case ProcessDurationPeriod.Months:
					return oldDate.AddMonths(offset);
			}
		}

		public virtual Guid GetActivityCategory(Guid activityType) {
			var select = (Select)new Select(UserConnection)
					.Column("Id")
				.From("ActivityCategory")
				.Where("ActivityTypeId").IsEqual(Column.Parameter(activityType));
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dr = select.ExecuteReader(dbExecutor)) {
					if (dr.Read()) {
						return UserConnection.DBTypeConverter.DBValueToGuid(dr[0]);
					}
				}
			}
			return Guid.Empty;
		}

		/// <inheritdoc />
		public override bool CompleteExecuting(params object[] parameters) {
			if (!(parameters[0] is Activity activity)) {
				return false;
			}
			OwnerId = activity.OwnerId;
			var columnLead = activity.Schema.Columns.FindByName("Lead");
			if (columnLead != null) {
				object lead = activity.GetColumnValue(columnLead);
				if (lead != null) {
					Lead = (Guid)lead;
				}
			}
			Account = activity.AccountId;
			Contact = activity.ContactId;
			var columnOpportunity = activity.Schema.Columns.FindByName("Opportunity");
			if (columnOpportunity != null) {
				object opportunity = activity.GetColumnValue(columnOpportunity);
				if (opportunity != null) {
					Opportunity = (Guid)opportunity;
				}
			}
			var columnInvoice = activity.Schema.Columns.FindByName("Invoice");
			if (columnInvoice != null) {
				object invoice = activity.GetColumnValue(columnInvoice);
				if (invoice != null) {
					Invoice = (Guid)invoice;
				}
			}
			var columnOrder = activity.Schema.Columns.FindByName("Order");
			if (columnOrder != null) {
				object order = activity.GetColumnValue(columnOrder);
				if (order != null) {
					Order = (Guid)order;
				}
			}
			var columnProject = activity.Schema.Columns.FindByName("Project");
			if (columnProject != null) {
				object project = activity.GetColumnValue(columnProject);
				if (project != null) {
					Project = (Guid)project;
				}
			}
			var columnContract = activity.Schema.Columns.FindByName("Contract");
			if (columnContract != null) {
				object contract = activity.GetColumnValue(columnContract);
				if (contract != null) {
					Contract = (Guid)contract;
				}
			}
			var columnDocument = activity.Schema.Columns.FindByName("Document");
			if (columnDocument != null) {
				object document = activity.GetColumnValue(columnDocument);
				if (document != null) {
					Document = (Guid)document;
				}
			}
			var columnRequests = activity.Schema.Columns.FindByName("Requests");
			if (columnRequests != null) {
				object requests = activity.GetColumnValue(columnRequests);
				if (requests != null) {
					Requests = (Guid)requests;
				}
			}
			var columnListing = activity.Schema.Columns.FindByName("Listing");
			if (columnListing != null) {
				object listing = activity.GetColumnValue(columnListing);
				if (listing != null) {
					Listing = (Guid)listing;
				}
			}
			var columnProperty = activity.Schema.Columns.FindByName("Property");
			if (columnProperty != null) {
				object property = activity.GetColumnValue(columnProperty);
				if (property != null) {
					Property = (Guid)property;
				}
			}
			var columnChange = activity.Schema.Columns.FindByName("Change");
			if (columnChange != null) {
				object change = activity.GetColumnValue(columnChange);
				if (change != null) {
					Change = (Guid)change;
				}
			}
			var columnProblem = activity.Schema.Columns.FindByName("Problem");
			if (columnProblem != null) {
				object problem = activity.GetColumnValue(columnProblem);
				if (problem != null) {
					Problem = (Guid)problem;
				}
			}
			var columnRelease = activity.Schema.Columns.FindByName("Release");
			if (columnRelease != null) {
				object release = activity.GetColumnValue(columnRelease);
				if (release != null) {
					Release = (Guid)release;
				}
			}
			ActivityResult = activity.ResultId;
			IsActivityCompleted = true;
			bool result = base.CompleteExecuting(parameters);
			activity.SetColumnValue("ProcessElementId", null);
			activity.UseAdminRights = false;
			activity.Save();
			return result;
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
			UserConnection.IProcessEngine.RemoveActivityProcessListener(CurrentActivityId, UId, ActivityConsts.CanceledStatusUId);
		}

		/// <inheritdoc />
		public override string GetExecutionData() {
			return SerializeToString(new {
				procElUId = UId,
				name = Name,
				processId = ProcessUserTaskUtilities.GetParentProcessId(Owner),
				isProcessExecutedBySignal = ProcessUserTaskUtilities.GetIsProcessExecutedBySignal(Owner),
				processName = Owner.Name,
				entitySchemaName = "Activity",
				recommendation = GetActivityTitle(),
				informationOnStep = LocalizableString.IsNullOrEmpty(InformationOnStep) ? null : InformationOnStep.Value,
				pageTypeId =  ActivityConsts.CallTypeUId,
				activityRecordId = CurrentActivityId,
				executionContext = ExecutionContext,
				nextProcElUId = "nextProcElUIdValue",
				allowedResults = ProcessUserTaskUtilities.GetAllowedActivityResults(UserConnection, CurrentActivityId)
			});
		}

		/// <inheritdoc />
		public override ProcessElementNotification GetNotificationData() {
			ProcessElementNotification notification = base.GetNotificationData();
			ProcessUserTaskUtilities.AssignNotificationData(notification, Recommendation, StartIn, StartInPeriod);
			return notification;
		}

		public virtual Guid GetActivityEntitySchemaUId() {
			return ActivityConsts.ActivityEntitySchemaUId;
		}

		public virtual Activity CreateActivity() {
			var activity = new Activity(UserConnection);
			activity.SetDefColumnValues();
			activity.Id = Guid.NewGuid();
			activity.TypeId = ActivityConsts.CallTypeUId;
			activity.ActivityCategoryId = GetActivityCategory(activity.TypeId);
			activity.Title = GetActivityTitle();
			activity.StartDate = NewDate(UserConnection.CurrentUser.GetCurrentDateTime(), StartIn,
				(ProcessDurationPeriod)StartInPeriod);
			activity.DueDate = NewDate(activity.StartDate, Duration, (ProcessDurationPeriod)DurationPeriod);
			activity.ShowInScheduler = ShowInScheduler;
			if (OwnerId != Guid.Empty) {
				activity.OwnerId = OwnerId;
				if (RemindBefore != 0) {
					activity.RemindToOwner = true;
					activity.RemindToOwnerDate = NewDate(activity.StartDate, -1 * RemindBefore,
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
			var columnDocument = activity.Schema.Columns.FindByName("Document");
			if (columnDocument != null && Document != Guid.Empty) {
				activity.SetColumnValue(columnDocument, Document);
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
			var columnProject = activity.Schema.Columns.FindByName("Project");
			if (columnProject != null && Project != Guid.Empty) {
				activity.SetColumnValue(columnProject, Project);
			}
			var columnContract = activity.Schema.Columns.FindByName("Contract");
			if (columnContract != null && Contract != Guid.Empty) {
				activity.SetColumnValue(columnContract, Contract);
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
			activity.ProcessElementId = UId;
			activity.AllowedResult = GetResultAllowedValues();
			Guid resultColumnUId = activity.Schema.Columns.GetByName("Status").UId;
			string conditionData = GetConditionData(resultColumnUId, activity);
			UserConnection.IProcessEngine.AddProcessListener(activity, UId, conditionData);
			UserConnection.IProcessEngine.LinkProcessToEntity(Owner, activity.Schema.UId, activity.Id);
			IsActivityCompleted = false;
			CurrentActivityId = activity.Id;
			return activity;
		}

		public virtual Guid GetParentProcessId() {
			Process parentProcess = Owner;
			Guid processId = parentProcess.UId;
			while(parentProcess != null){
				processId = parentProcess.UId;
				parentProcess = parentProcess.Owner;
			}
			return processId;
		}

		/// <inheritdoc />
		public IDictionary<string, object> GetExtraDataValues() {
			return new Dictionary<string, object> {
				{ ProcessElementExtraDataKeys.UserTaskEntitySchemaNameKey, "Activity" }
			};
		}

		#endregion

	}

	#endregion

	#region Class: CallUserTaskSchemaExtension

	/// <exclude/>
	public class CallUserTaskSchemaExtension : ProcessUserTaskSchemaExtension
	{

		#region Methods: Public

		/// <inheritdoc />
		public override Dictionary<Guid, string> GetResultParameterAllValues(UserConnection userConnection,
				ProcessSchemaUserTask schemaUserTask) {
			var results = new Dictionary<Guid, string>();
			var select = (Select)new Select(userConnection).Distinct()
					.Column("ActivityResult", "Id")
					.Column("ActivityResult", "Name")
				.From("ActivityResult")
				.Join(JoinType.Inner, "ActivityCategoryResultEntry")
					.On("ActivityResult", "Id").IsEqual("ActivityCategoryResultEntry", "ActivityResultId")
				.Join(JoinType.Inner, "ActivityCategory")
					.On("ActivityCategoryResultEntry", "ActivityCategoryId").IsEqual("ActivityCategory", "Id")
				.Join(JoinType.Inner, "ActivityType")
					.On("ActivityCategory", "ActivityTypeId").IsEqual("ActivityType", "Id")
					.Where("ActivityType", "Code").IsEqual(Column.Parameter("Call"));
			using (DBExecutor dbExecutor = userConnection.EnsureDBConnection()) {
				using (IDataReader dr = select.ExecuteReader(dbExecutor)) {
					while (dr.Read()) {
						results.Add(userConnection.DBTypeConverter.DBValueToGuid(dr[0]), dr.GetString(1));
					}
				}
			}
			return results;
		}

		#endregion

	}

	#endregion

}

