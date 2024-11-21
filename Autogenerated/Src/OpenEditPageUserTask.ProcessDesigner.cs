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
	using BPMSoft.Nui.ServiceModel.Extensions;
	using RecordEditMode = BPMSoft.Configuration.RecordEditMode;
	using CoreEntityCollection = BPMSoft.Core.Entities.EntityCollection;
	using CoreEntitySchema = BPMSoft.Core.Entities.EntitySchema;
	using CoreEntitySchemaColumn = BPMSoft.Core.Entities.EntitySchemaColumn;

	#region Class: OpenEditPageUserTask

	/// <summary>
	/// Represents user task to open edit page.
	/// </summary>
	public partial class OpenEditPageUserTask : IUserTaskActivityInfo, IProcessElementExtraDataBuilder
	{

		#region Properties: Private

		private bool UseProcessPerformerAssignment =>
			UserConnection.GetIsFeatureEnabled("UseProcessPerformerAssignment");

		private CoreEntitySchema _entitySchema;
		private CoreEntitySchema EntitySchema => _entitySchema ??
			(_entitySchema = UserConnection.EntitySchemaManager.GetInstanceByUId(ObjectSchemaId));

		private bool CreateActivityFix => CreateActivity || !(Owner is ProcessComponentSet);

		#endregion

		#region Methods: Private

		private static DateTime GetDateTime(DateTime dateTime, int offset, ProcessDurationPeriod offsetPeriod) {
			return BaseProcessUserTaskUtilities.AddOffsetToDate(dateTime, offset, offsetPeriod);
		}

		private Dictionary<string, object> GetDefaultValues(EntitySchema entitySchema) {
			var defaultColumnValues = new Dictionary<string, object>();
			foreach (KeyValuePair<string, object> columnValue in RecordColumnValues.Values) {
				EntitySchemaColumn column = entitySchema.GetSchemaColumnByMetaPath(columnValue.Key);
				bool isLookup = column.DataValueType is LookupDataValueType ||
					column.DataValueType is MultiLookupDataValueType;
				if (isLookup &&((Guid)columnValue.Value).IsEmpty()) {
					continue;
				}
				defaultColumnValues[column.Name] = SerializeEntityColumn(column, columnValue.Value);
			}
			var editMode = (RecordEditMode)Enum.ToObject(typeof(RecordEditMode), EditMode);
			if (editMode == RecordEditMode.New) {
				EntitySchemaColumnCollection columns = entitySchema.Columns;
				defaultColumnValues["ProcessListeners"] =
					SerializeEntityColumn(columns.GetByName("ProcessListeners"), (int)EntityChangeType.Inserted);
			}
			return defaultColumnValues.Count > 0 ? defaultColumnValues : null;
		}

		private void PrepareRecord(RecordEditMode editMode) {
			if (CreateActivityFix) {
				CreateAccompanyingActivity();
			}
			if (editMode == RecordEditMode.New) {
				RecordId = Guid.NewGuid();
				IProcessEngine processEngine = UserConnection.ProcessEngine;
				processEngine.AddProcessListener(RecordId, ObjectSchemaId, UId, null, null, EntityChangeType.Inserted);
			} else {
				AddProcessListenerForEntityChange();
			}
		}

		private void PrepareActivityRecord(RecordEditMode editMode) {
			if (editMode == RecordEditMode.New) {
				CreateTechnicalActivity();
				RecordId = CurrentActivityId;
			} else {
				CurrentActivityId = RecordId;
				AddProcessListenerForEntityChange();
			}
		}

		private void AddProcessListenerForEntityChange() {
			string serializedFilters = GetProcessListenerFilters();
			IProcessEngine processEngine = UserConnection.ProcessEngine;
			processEngine.AddProcessListener(RecordId, ObjectSchemaId, UId, serializedFilters);
		}

		private string GetProcessListenerFilters() {
			return IsMatchConditions && DataSourceFilters.IsNotNullOrEmpty()
				? ConvertToProcessDataSourceFilters(ObjectSchemaId, DataSourceFilters)
				: null;
		}

		private void SpecifyActivityColumnValues(Entity activity) {
			ActivityUserTaskHelper.SpecifyActivityLookupColumnValue(activity, "Account", Account);
			ActivityUserTaskHelper.SpecifyActivityLookupColumnValue(activity, "Contact", Contact);
			ActivityUserTaskHelper.SpecifyActivityLookupColumnValue(activity, "Lead", Lead);
			ActivityUserTaskHelper.SpecifyActivityLookupColumnValue(activity, "Opportunity", Opportunity);
			ActivityUserTaskHelper.SpecifyActivityLookupColumnValue(activity, "Document", Document);
			ActivityUserTaskHelper.SpecifyActivityLookupColumnValue(activity, "Invoice", Invoice);
			ActivityUserTaskHelper.SpecifyActivityLookupColumnValue(activity, "Case", Case);
			ActivityUserTaskHelper.SpecifyActivityLookupColumnValue(activity, "Contract", Contract);
			ActivityUserTaskHelper.SpecifyActivityLookupColumnValue(activity, "Change", Change);
			ActivityUserTaskHelper.SpecifyActivityLookupColumnValue(activity, "Release", Release);
			ActivityUserTaskHelper.SpecifyActivityLookupColumnValue(activity, "Problem", Problem);
			ActivityUserTaskHelper.SpecifyActivityLookupColumnValue(activity, "Project", Project);
			ActivityUserTaskHelper.SpecifyActivityLookupColumnValue(activity, "Order", Order);
			ActivityUserTaskHelper.SpecifyActivityLookupColumnValue(activity, "Requests", Requests);
			ActivityUserTaskHelper.SpecifyActivityLookupColumnValue(activity, "Listing", Listing);
			ActivityUserTaskHelper.SpecifyActivityLookupColumnValue(activity, "Property", Property);
			activity.SetColumnValue("ProcessElementId", UId);
			string allowedResult = GetResultAllowedValues();
			activity.SetColumnValue("AllowedResult", allowedResult);
		}

		private Entity ObsoleteCreateAccompanyingActivity() {
			CoreEntitySchema activitySchema = GetActivityEntitySchema();
			Entity activity = activitySchema.CreateEntity(UserConnection);
			activity.UseAdminRights = false;
			string title = GetActivityTitle();
			activity.SetColumnValue("Title", title);
			activity.SetDefColumnValues();
			activity.SetColumnValue("TypeId", ActivityConsts.TaskTypeUId);
			DateTime startDate = GetDateTime(UserConnection.CurrentUser.GetCurrentDateTime(), StartIn,
				(ProcessDurationPeriod)StartInPeriod);
			activity.SetColumnValue("StartDate", startDate);
			DateTime dateTime = GetDateTime(startDate, Duration, (ProcessDurationPeriod)DurationPeriod);
			activity.SetColumnValue("DueDate", dateTime);
			activity.SetColumnValue("ActivityCategoryId", ActivityCategory);
			activity.SetColumnValue("ShowInScheduler", ShowInScheduler);
			if (OwnerId != Guid.Empty) {
				activity.SetColumnValue("OwnerId", OwnerId);
				if (RemindBefore != 0) {
					activity.SetColumnValue("RemindToOwner", true);
					dateTime = GetDateTime(startDate, -1 * RemindBefore, (ProcessDurationPeriod)RemindBeforePeriod);
					activity.SetColumnValue("RemindToOwnerDate", dateTime);
				}
			}
			SpecifyActivityColumnValues(activity);
			activity.PrimaryColumnValue = Guid.NewGuid();
			Guid resultColumnUId = activitySchema.Columns.GetByName("Status").UId;
			UserConnection.ProcessEngine.AddProcessListener(activity, UId, GetConditionData(resultColumnUId, activity));
			IsActivityCompleted = false;
			CurrentActivityId = activity.PrimaryColumnValue;
			return activity;
		}

		private Entity ObsoleteCreateActivity() {
			CoreEntitySchema activitySchema = GetActivityEntitySchema();
			Entity activity = activitySchema.CreateEntity(UserConnection);
			activity.UseAdminRights = false;
			string activityTitle = GetActivityTitle();
			activity.SetColumnValue("Title", activityTitle);
			activity.SetDefColumnValues();
			foreach (KeyValuePair<string, object> columnValue in GetEntityColumnValues(activitySchema)) {
				activity.SetColumnValue(columnValue.Key, columnValue.Value);
			}
			EntitySchemaColumn columnDocument = activity.Schema.Columns.FindByName("Document");
			if (columnDocument != null) {
				object document = activity.GetColumnValue(columnDocument);
				if (document != null) {
					Document = (Guid)document;
				}
			}
			SpecifyActivityColumnValues(activity);
			string serializedFilters = GetProcessListenerFilters();
			IProcessEngine processEngine = UserConnection.ProcessEngine;
			processEngine.AddProcessListener(activity, UId, serializedFilters);
			CurrentActivityId = activity.PrimaryColumnValue;
			IsActivityCompleted = false;
			PageTypeUId = GetActivityType();
			return activity;
		}

		private Entity CreateTechnicalActivity(bool isAccompanying) {
			var info = new UserTaskActivityInfo {
				Title = GetActivityTitle(),
				TypeId = ActivityConsts.TaskTypeUId,
				StartOffset = new ProcessDateOffset(StartIn, (ProcessDurationPeriod)StartInPeriod),
				Duration = new ProcessDateOffset(Duration, (ProcessDurationPeriod)DurationPeriod),
				RemindOffset = new ProcessDateOffset(RemindBefore, (ProcessDurationPeriod)RemindBeforePeriod),
				PriorityId = ActivityPriority
			};
			if (!isAccompanying) {
				info.CompletionFilter = Option.Some(GetProcessListenerFilters());
				info.ColumnValues = GetEntityColumnValues(GetActivityEntitySchema());
			}
			Entity activity = this.CreateUserTaskActivity(info);
			IsActivityCompleted = false;
			CurrentActivityId = activity.PrimaryColumnValue;
			return activity;
		}

		private Dictionary<string, object> GetEntityColumnValues(EntitySchema schema) {
			var result = new Dictionary<string, object>();
			foreach (KeyValuePair<string, object> columnValue in RecordColumnValues.Values) {
				CoreEntitySchemaColumn column = schema.GetSchemaColumnByMetaPath(columnValue.Key);
				if ((column.DataValueType is LookupDataValueType || column.DataValueType is MultiLookupDataValueType) &&
					((Guid)columnValue.Value).IsEmpty()) {
					continue;
				}
				result[column.ColumnValueName] = columnValue.Value;
			}
			return result;
		}

		private string GetConditionData(Guid resultColumnUId, Entity activity) {
			return ProcessUserTaskUtilities.GetConditionData(UserConnection, resultColumnUId, activity);
		}

		private void FillResultParameter() {
			if (GenerateDecisionsFromColumn) {
				ResultParameter = GetResultParameter();
			}
		}

		private void RemoveActivityProcessListener() {
			if (CurrentActivityId.IsEmpty()) {
				return;
			}
			Guid activityStatusId = ProcessUserTaskUtilities.GetActivityStatus(UserConnection, CurrentActivityId);
			if (activityStatusId != ActivityConsts.CanceledStatusUId) {
				activityStatusId = ActivityConsts.CompletedStatusUId;
			}
			IProcessEngine processEngine = UserConnection.ProcessEngine;
			processEngine.RemoveActivityProcessListener(CurrentActivityId, UId, activityStatusId);
		}

		private void ContinueExecution() {
			if ((RecordEditMode)Enum.ToObject(typeof(RecordEditMode), EditMode) == RecordEditMode.New) {
				string serializedFilters = IsMatchConditions && DataSourceFilters.IsNotNullOrEmpty()
					? ConvertToProcessDataSourceFilters(ObjectSchemaId, DataSourceFilters)
					: null;
				UserConnection.ProcessEngine.AddProcessListener(RecordId, ObjectSchemaId, UId, serializedFilters);
				EditMode = (int)RecordEditMode.Existing;
			}
			if (CurrentActivityId.IsEmpty()) {
				return;
			}
			Guid activityStatusId = ProcessUserTaskUtilities.GetActivityStatus(UserConnection, CurrentActivityId);
			if (activityStatusId == ActivityConsts.NewStatusUId) {
				ProcessUserTaskUtilities.SetActivityStatus(UserConnection, CurrentActivityId,
					ActivityConsts.InProgressUId);
			}
		}

		private void CompleteExecution() {
			bool isActivityRecord = GetIsActivityEntitySchema();
			if (CurrentActivityId.IsEmpty()) {
				RemoveObjectProcessListener(isActivityRecord);
				return;
			}
			if (UseProcessPerformerAssignment) {
				this.SynchronizeCompletedUserTaskActivity(new UserTaskActivitySyncOptions {
					RemoveListener = !isActivityRecord,
					UseEntityComplete = isActivityRecord,
					SynchronizeParameterValues = false
				});
				return;
			}
			RemoveActivityProcessListener();
			RemoveObjectProcessListener(isActivityRecord);
		}

		private void RemoveObjectProcessListener(bool isActivityRecord) {
			if (!isActivityRecord) {
				IProcessEngine processEngine = UserConnection.ProcessEngine;
				processEngine.RemoveProcessListener(RecordId, ObjectSchemaId, UId);
			}
		}

		#endregion

		#region Methods: Protected

		/// <inheritdoc />
		protected override bool InternalExecute(ProcessExecutingContext context) {
			bool isRedo = GlobalAppSettings.FeatureResetParameterValuesBeforeReExecuteProcessElement &&
				Status == ProcessStatus.Error && CurrentActivityId.IsEmpty() &&
				!ProcessUserTaskUtilities.GetIsActivityCreated(UserConnection, UId);
			bool activityExists = CurrentActivityId.IsNotEmpty() && !IsActivityCompleted;
			if (!activityExists || isRedo) {
				var editMode = (RecordEditMode)Enum.ToObject(typeof(RecordEditMode), EditMode);
				if (GetIsActivityEntitySchema()) {
					PrepareActivityRecord(editMode);
				} else {
					PrepareRecord(editMode);
				}
			}
			InteractWithUser(context, activityExists, ShowExecutionPage);
			return false;
		}

		/// <inheritdoc />
		protected override void WriteExecutionData(IProcessExecutionDataWriter dataWriter) {
			base.WriteExecutionData(dataWriter);
			string actionName = GetActionName();
			dataWriter.Write("action", actionName);
			dataWriter.Write("completeExecution", actionName == "add");
			dataWriter.Write("entitySchemaName", EntitySchema.Name);
			dataWriter.Write("recordId", RecordId);
			dataWriter.Write("activityRecordId", CurrentActivityId);
			dataWriter.Write("recommendation", GetActivityTitle());
			string informationOnStep = LocalizableString.IsNullOrEmpty(InformationOnStep)
				? GetParameterValue("InformationOnStep")?.ToString() ?? string.Empty
				: InformationOnStep.Value;
			dataWriter.Write("informationOnStep", informationOnStep);
			dataWriter.Write("executionContext", ExecutionContext);
			dataWriter.Write("pageTypeId", PageTypeUId == Guid.Empty ? string.Empty : PageTypeUId.ToString());
			dataWriter.Write("nextProcElUId", "nextProcElUIdValue");
			Dictionary<string, object> defaultValues = GetDefaultValues(EntitySchema);
			dataWriter.WriteObject("defaultValues", defaultValues);
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public override bool CompleteExecuting(params object[] parameters) {
			if (GetIsActivityEntitySchema() || GetIsMatchedConditions()) {
				CompleteExecution();
				FillResultParameter();
				return base.CompleteExecuting(parameters);
			}
			ContinueExecution();
			return false;
		}

		/// <inheritdoc />
		public override ProcessElementNotification GetNotificationData() {
			ProcessElementNotification notification = base.GetNotificationData();
			ProcessUserTaskUtilities.AssignNotificationData(notification, Recommendation, StartIn, StartInPeriod);
			return notification;
		}

		/// <inheritdoc />
		public override void CancelExecuting(params object[] parameters) {
			base.CancelExecuting(parameters);
			IProcessEngine processEngine = UserConnection.ProcessEngine;
			if (CurrentActivityId.IsNotEmpty()) {
				processEngine.RemoveActivityProcessListener(CurrentActivityId, UId, ActivityConsts.CanceledStatusUId);
			}
			if (GetIsActivityEntitySchema()) {
				return;
			}
			var editMode = (RecordEditMode)Enum.ToObject(typeof(RecordEditMode), EditMode);
			EntityChangeType entityChangeType = editMode == RecordEditMode.New
				? EntityChangeType.Inserted
				: EntityChangeType.Updated;
			processEngine.RemoveProcessListener(RecordId, ObjectSchemaId, UId, entityChangeType);
		}

		/// <inheritdoc />
		public override string GetExecutionData() {
			if (UseProcessPerformerAssignment) {
				return base.GetExecutionData();
			}
			EntitySchemaManager entitySchemaManager = UserConnection.EntitySchemaManager;
			CoreEntitySchema entitySchema = entitySchemaManager.GetInstanceByUId(ObjectSchemaId);
			Dictionary<string, object> defaultValues = GetDefaultValues(entitySchema);
			string actionName = GetActionName();
			string informationOnStep = LocalizableString.IsNullOrEmpty(InformationOnStep)
				? GetParameterValue("InformationOnStep")?.ToString() ?? string.Empty
				: InformationOnStep.Value;
			return SerializeToString(new {
				processId = ProcessUserTaskUtilities.GetParentProcessId(Owner),
				procElUId = UId,
				name = Name,
				isProcessExecutedBySignal = ProcessUserTaskUtilities.GetIsProcessExecutedBySignal(Owner),
				processName = Owner.Name,
				action = actionName,
				entitySchemaName = entitySchema.Name,
				recordId = RecordId,
				activityRecordId = CurrentActivityId,
				recommendation = GetActivityTitle(),
				informationOnStep,
				defaultValues,
				executionContext = ExecutionContext,
				completeExecution = actionName == "add",
				pageTypeId = PageTypeUId == Guid.Empty ? string.Empty : PageTypeUId.ToString(),
				nextProcElUId = "nextProcElUIdValue"
			});
		}

		/// <summary>
		/// Determines whether the conditions is satisfied.
		/// </summary>
		/// <returns><c>true</c> when conditions are successfully checked; otherwise - <c>false</c>.</returns>
		public virtual bool GetIsMatchedConditions() {
			if (!IsMatchConditions || DataSourceFilters.IsNullOrEmpty()) {
				return true;
			}
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, EntitySchema.Name) {
				UseAdminRights = false
			};
			esq.AddColumn(EntitySchema.PrimaryColumn.Name);
			ProcessUserTaskUtilities.SpecifyESQFilters(UserConnection, this, EntitySchema, esq, DataSourceFilters);
			if (esq.Filters.Count == 0) {
				return true;
			}
			if (esq.Filters.Count == 1) {
				if (esq.Filters[0] is EntitySchemaQueryFilterCollection filterGroup && filterGroup.Count == 0) {
					return true;
				}
			}
			Entity entity = esq.GetEntity(UserConnection, RecordId);
			return entity != null;
		}

		/// <summary>
		/// Returns value of the result parameter.
		/// </summary>
		/// <returns></returns>
		public virtual Guid GetResultParameter() {
			if (string.IsNullOrEmpty(DecisionalColumnMetaPath)) {
				return Guid.Empty;
			}
			Guid resultParameterId = Guid.Empty;
			EntitySchemaColumn columnSchema = EntitySchema.GetSchemaColumnByMetaPath(DecisionalColumnMetaPath);
			var esq = new EntitySchemaQuery(EntitySchema) {
				UseAdminRights = false
			};
			EntitySchemaQueryColumn column = esq.AddColumn(columnSchema.Name);
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", RecordId));
			CoreEntityCollection resultCollection = esq.GetEntityCollection(UserConnection);
			if (resultCollection.Count != 0) {
				resultParameterId = resultCollection.First.Value.GetTypedColumnValue<Guid>(column.ValueQueryAlias);
			}
			return resultParameterId;
		}

		/// <summary>
		/// Returns entity of the accompanying Activity.
		/// </summary>
		/// <returns>A new instance of the entity.</returns>
		public Entity CreateAccompanyingActivity() {
			return UseProcessPerformerAssignment ? CreateTechnicalActivity(true) : ObsoleteCreateAccompanyingActivity();
		}

		/// <summary>
		/// Returns type of the activity.
		/// </summary>
		/// <returns>Lookup value.</returns>
		public virtual Guid GetActivityType() {
			foreach (KeyValuePair<string, object> columnValue in RecordColumnValues.Values) {
				CoreEntitySchemaColumn column = EntitySchema.GetSchemaColumnByMetaPath(columnValue.Key);
				if (column.Name == "Type" && columnValue.Value != null) {
					var typeId = (Guid)columnValue.Value;
					if (typeId != Guid.Empty) {
						return typeId;
					}
				}
			}
			return PageTypeUId;
		}

		/// <summary>
		/// Returns title of the activity.
		/// </summary>
		/// <returns>Activity title.</returns>
		public virtual string GetActivityTitle() {
			return ProcessUserTaskUtilities.GetActivityTitle(this, Recommendation, CurrentActivityId);
		}

		/// <summary>
		/// Serializes value of the entity column.
		/// </summary>
		/// <param name="schemaColumn">Schema column.</param>
		/// <param name="columnValue">Column value.</param>
		/// <returns></returns>
		public virtual object SerializeEntityColumn(CoreEntitySchemaColumn schemaColumn, object columnValue) {
			if (schemaColumn == null || columnValue == null) {
				return string.Empty;
			}
			if (schemaColumn.DataValueType is BooleanDataValueType) {
				return DataTypeUtilities.ValueAsType<bool>(columnValue);
			}
			if (schemaColumn.IsLookupType) {
				QueryColumnExpression primaryColumnValue =
					Column.Parameter(DataTypeUtilities.ValueAsType<Guid>(columnValue));
				EntitySchema referenceSchema = schemaColumn.ReferenceSchema;
				var displayValueSelect =
					(Select)new Select(UserConnection)
						.Column(referenceSchema.PrimaryDisplayColumn.Name)
					.From(referenceSchema.Name).WithHints(Hints.NoLock)
					.Where(referenceSchema.PrimaryColumn.Name).IsEqual(primaryColumnValue);
				return new {
					value = columnValue,
					displayValue = displayValueSelect?.ExecuteScalar<string>()
				};
			}
			if (schemaColumn.DataValueType is DateTimeDataValueType dateTimeDataValueType) {
				var dateTime = (DateTime)columnValue;
				if (dateTime == DateTime.MinValue) {
					return null;
				}
				if (dateTime.Kind != DateTimeKind.Unspecified) {
					columnValue = DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified);
				}
				string value = DateTimeDataValueType.Serialize(columnValue, TimeZoneInfo.Utc);
				return new {
					dataValueType = (int)dateTimeDataValueType.ToEnum(),
					value
				};
			}
			return DataTypeUtilities.ValueAsType<string>(columnValue);
		}

		/// <summary>
		/// Determines whether the current entity schema is Activity.
		/// </summary>
		/// <returns></returns>
		public virtual bool GetIsActivityEntitySchema() {
			return ObjectSchemaId == GetActivityEntitySchemaUId();
		}

		/// <summary>
		/// Record edit mode.
		/// </summary>
		/// <returns>Edit mode of the record.</returns>
		public virtual string GetActionName() {
			var editMode = (RecordEditMode)Enum.ToObject(typeof(RecordEditMode), EditMode);
			if (editMode != RecordEditMode.New) {
				return "edit";
			}
			return GetIsActivityEntitySchema() || GetIsExecuted() ? "edit" : "add";
		}

		/// <summary>
		/// Returns UId of the Activity schema.
		/// </summary>
		public virtual Guid GetActivityEntitySchemaUId() {
			return ActivityConsts.ActivityEntitySchemaUId;
		}

		/// <summary>
		/// Creates entity of the Activity.
		/// </summary>
		/// <returns>A new instance of the entity.</returns>
		public Entity CreateTechnicalActivity() {
			return UseProcessPerformerAssignment ? CreateTechnicalActivity(false) : ObsoleteCreateActivity();
		}

		/// <summary>
		/// Returns instance of the Activity schema.
		/// </summary>
		/// <returns>Activity schema.</returns>
		public virtual CoreEntitySchema GetActivityEntitySchema() {
			return UserConnection.EntitySchemaManager.GetInstanceByName("Activity");
		}

		/// <summary>
		/// Determines whether the current process element is executed.
		/// </summary>
		/// <returns></returns>
		public virtual bool GetIsExecuted() {
			var select =
				(Select)new Select(UserConnection)
					.Column("Id")
				.From(EntitySchema.Name).WithHints(Hints.NoLock)
				.Where("Id").IsEqual(Column.Parameter(RecordId));
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = select.ExecuteReader(dbExecutor)) {
					return dataReader.Read();
				}
			}
		}

		/// <inheritdoc />
		public IDictionary<string, object> GetExtraDataValues() {
			return new Dictionary<string, object> {
				{ ProcessElementExtraDataKeys.UserTaskEntitySchemaNameKey, EntitySchema.Name }
			};
		}

		#endregion

	}

	#endregion

	#region Class: OpenEditPageUserTaskSchemaExtension

	/// <exclude/>
	public class OpenEditPageUserTaskSchemaExtension : ProcessUserTaskSchemaExtension
	{

		#region Methods: Public

		public override Dictionary<Guid, string> GetResultParameterAllValues(UserConnection userConnection,
				ProcessSchemaUserTask schemaUserTask) {
			var conditionValues = new Dictionary<Guid, string>();
			ProcessSchemaParameterCollection parameters = schemaUserTask.Parameters;
			ProcessSchemaParameter metaPath = parameters.GetByName("DecisionalColumnMetaPath");
			if (string.IsNullOrEmpty(metaPath.SourceValue.Value)) {
				return conditionValues;
			}
			ProcessSchemaParameter objectSchemaId = parameters.GetByName("ObjectSchemaId");
			EntitySchemaManager entitySchemaManager = userConnection.EntitySchemaManager;
			var entitySchemaUId = new Guid(objectSchemaId.SourceValue.Value);
			EntitySchema entitySchema = entitySchemaManager.GetInstanceByUId(entitySchemaUId);
			EntitySchemaColumn column = entitySchema.GetSchemaColumnByMetaPath(metaPath.SourceValue.Value);
			var esq = new EntitySchemaQuery(column.ReferenceSchema) {
				UseAdminRights = false
			};
			EntitySchemaQueryColumn primaryColumn = esq.AddColumn(column.ReferenceSchema.PrimaryColumn.Name);
			EntitySchemaQueryColumn displayColumn = esq.AddColumn(column.ReferenceSchema.PrimaryDisplayColumn.Name);
			EntityCollection entities = esq.GetEntityCollection(userConnection);
			foreach (Entity entity in entities) {
				EntitySchemaColumnCollection columns = entity.Schema.Columns;
				string columnValueName = columns.GetByName(primaryColumn.Name).ColumnValueName;
				Guid primaryValue = entity.GetTypedColumnValue<Guid>(columnValueName);
				string displayValue = entity.GetTypedColumnValue<string>(
					columns.GetByName(displayColumn.Name).ColumnValueName);
				conditionValues[primaryValue] = displayValue;
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
