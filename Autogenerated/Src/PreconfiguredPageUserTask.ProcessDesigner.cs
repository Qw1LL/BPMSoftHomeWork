namespace BPMSoft.Core.Process.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Dynamic;
	using System.Text;
	using System.Linq;
	using Newtonsoft.Json;
	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Nui.ServiceModel.Extensions;
	using CoreEntitySchemaColumn = BPMSoft.Core.Entities.EntitySchemaColumn;
	using EntityCollection = BPMSoft.Core.Entities.EntityCollection;
	using EntitySchema = BPMSoft.Core.Entities.EntitySchema;
	using Utilities = BPMSoft.Configuration.ProcessUserTaskUtilities;

	#region Class: PreconfiguredPageUserTask

	/// <summary>
	/// Represents preconfigured page which is a one of the process interactive element.
	/// </summary>
	public partial class PreconfiguredPageUserTask : IUserTaskActivityInfo
	{

		#region Constants: Private

		private const string Action = "add";
		private const string DefUrlTemplate = "[Module]/[Page]/" + Action;

		#endregion

		#region Properties: Private

		private ClientUnitSchemaManager ClientUnitSchemaManager => UserConnection.ClientUnitSchemaManager;

		private EntitySchemaManager EntitySchemaManager => UserConnection.EntitySchemaManager;

		#endregion

		#region Methods: Private

		private string GetEntitySchemaName(Guid uid) {
			return uid.IsEmpty() ? string.Empty : EntitySchemaManager.GetItemByUId(uid).Name;
		}

		private string GetUrlToken(string pageName) {
			var module = ClientUnitSchemaManager.FindItemByUId(Module);
			string moduleName = module?.Name ?? "ProcessCardModuleV2";
			string template = Url.IsNullOrEmpty() ? DefUrlTemplate : Url;
			return template.Replace("[Module]", moduleName).Replace("[Page]", pageName);
		}

		private object GetParameterLookupValue(ProcessSchemaParameter parameter,
				IReadOnlyDictionary<Guid, Guid> sysModuleEntityPageType) {
			object value = GetParameterValue(parameter);
			var primaryColumnValue = (Guid?)value;
			if (primaryColumnValue?.IsEmpty() != false) {
				return null;
			}
			if (parameter.ParentMetaSchema == null) {
				parameter.ParentMetaSchema = Owner.Schema;
				Log.Warn("[PreconfiguredPageUserTask]. Parameter metadata modified at runtime.");
			}
			EntitySchema referenceSchema = parameter.ReferenceSchema;
			if (referenceSchema.PrimaryDisplayColumn == null) {
				return new {
					value = primaryColumnValue.Value.ToString()
				};
			}
			Entity entity = referenceSchema.CreateEntity(UserConnection);
			entity.UseAdminRights = false;
			var columnsToFetch = new Collection<CoreEntitySchemaColumn>() {
				referenceSchema.PrimaryColumn,
				referenceSchema.PrimaryDisplayColumn,
			};
			var hasPageTypeColumn = sysModuleEntityPageType.ContainsKey(referenceSchema.UId);
			CoreEntitySchemaColumn pageTypeColumn = null;
			if (hasPageTypeColumn) {
				Guid typeColumnUId = sysModuleEntityPageType[referenceSchema.UId];
				pageTypeColumn = referenceSchema.Columns.FindByUId(typeColumnUId);
				if (pageTypeColumn != null) {
					columnsToFetch.Add(pageTypeColumn);
				}
			}
			entity.FetchFromDB(referenceSchema.PrimaryColumn, primaryColumnValue.Value, columnsToFetch, false);
			ExpandoObject lookupValue = GetClientLookupLinkValue(entity, pageTypeColumn);
			return lookupValue;
		}

		private static ExpandoObject GetClientLookupLinkValue(Entity entity, CoreEntitySchemaColumn pageTypeColumn) {
			var value = new ExpandoObject() as IDictionary<string, object>;
			value.Add("value", entity.PrimaryColumnValue.ToString());
			value.Add("displayValue", entity.PrimaryDisplayColumnValue);
			if (pageTypeColumn != null) {
				value.Add(pageTypeColumn.Name, new {
					value = entity.GetTypedColumnValue<Guid>(pageTypeColumn.ColumnValueName)
				});
			}
			return (ExpandoObject)value;
		}

		private Dictionary<Guid,Guid> GetSysModuleEntityPageTypes() {
			var result = new Dictionary<Guid,Guid>();
			var esq = new EntitySchemaQuery(EntitySchemaManager, "SysModuleEntity") {
				IgnoreDisplayValues = true,
				UseAdminRights = false,
				UseLocalization = false
			};
			esq.AddColumn("SysEntitySchemaUId");
			esq.AddColumn("TypeColumnUId");
			EntityCollection entityCollection = esq.GetEntityCollection(UserConnection);
			entityCollection.ForEach(e => {
				var sysEntitySchemaUId = e.GetTypedColumnValue<Guid>("SysEntitySchemaUId");
				var typeColumnUId = e.GetTypedColumnValue<Guid>("TypeColumnUId");
				result[sysEntitySchemaUId] = typeColumnUId;
			});
			return result;
		}

		private object GetParameterDateTimeValue(ProcessSchemaParameter parameter) {
			object value = GetParameterValue(parameter);
			if (value == null) {
				return null;
			}
			var dateTime = (DateTime)value;
			if (dateTime == DateTime.MinValue) {
				return null;
			}
			if (dateTime.Kind == DateTimeKind.Local) {
				value = DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified);
			}
			var dataValueType = (DateTimeDataValueType)parameter.DataValueType;
			return new {
				dataValueType = (int)dataValueType.ToEnum(),
				value = DateTimeDataValueType.Serialize(value, TimeZoneInfo.Utc)
			};
		}

		/// <summary>
		/// Returns page parameters.
		/// </summary>
		/// <param name="processSchema">Parent process schema.</param>
		/// <param name="useLookupValues">Load lookup display value only for new pages.
		/// Old pages are using parameter value as simple guid value, not object (value, displayValue)</param>
		/// <returns>Parameters dictionary</returns>
		private Dictionary<string, object> GetPageParameters(ProcessSchema processSchema, bool useLookupValues) {
			var userTask = (ProcessSchemaUserTask)processSchema.GetBaseElementByUId(SchemaElementUId);
			var sysModuleEntityPageType = new Dictionary<Guid, Guid>();
			var result = new Dictionary<string, object>();
			var dynamicParameters = userTask.Parameters.Where(p => p.CreatedInSchemaUId == processSchema.UId).ToList();
			var dateTimeParameters = dynamicParameters.Where(p => p.DataValueType.IsDateTime).ToList();
			var lookupParameters = dynamicParameters.Where(p => useLookupValues && p.DataValueType.IsLookup).ToList();
			var anotherParameters = dynamicParameters.Except(dateTimeParameters).Except(lookupParameters).ToList();
			if (lookupParameters.Count > 0) {
				sysModuleEntityPageType = GetSysModuleEntityPageTypes();
			}
			dateTimeParameters.ForEach(p => result.Add(p.Name, GetParameterDateTimeValue(p)));
			lookupParameters.ForEach(p => result.Add(p.Name, GetParameterLookupValue(p, sysModuleEntityPageType)));
			anotherParameters.ForEach(p => result.Add(p.Name, GetParameterValue(p)));
			return result;
		}

		private Dictionary<string, object> GetAttributes() {
			var result = new Dictionary<string, object>();
			ClientUnitSchema instance = ClientUnitSchemaManager.GetInstanceByUId(ClientUnitSchemaUId);
			ClientUnitSchemaParameterCollection parameters = instance.Parameters;
			parameters.ForEach(p => {
				var precision = p.DataValueType is FloatDataValueType
					? (int?)((FloatDataValueType)p.DataValueType).Precision
					: null;
				var value = new {
					caption = p.Caption?.Value,
					dataValueType = (int)p.DataValueType.ToEnum(),
					isLookup = p.DataValueType.IsLookup,
					referenceSchemaName = GetEntitySchemaName(p.ReferenceSchemaUId),
					isRequired = p.IsRequired,
					precision,
					isProcessUserTaskParameterAttribute = true
				};
				result.Add(p.Name, value);
			});
			return result;
		}

		private string GetUserContextExecutionData(string jsonData) {
			string userContextData = ProcessLane?.GetUserContextData();
			if (userContextData.IsNullOrEmpty()) {
				return jsonData;
			}
			var sb = new StringBuilder(jsonData);
			sb.Length--;
			sb.Append(",").Append(userContextData).Append("}");
			return sb.ToString();
		}

		private JsonSerializerSettings GetSerializeJsonSettings() {
			return new JsonSerializerSettings {
				TypeNameHandling = TypeNameHandling.None,
				TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
				NullValueHandling = NullValueHandling.Include
			};
		}

		private string GetActivityTitle() {
			return ProcessUserTaskUtilities.GetActivityTitle(this, Recommendation, CurrentActivityId);
		}

		private void CreateTechnicalActivity() {
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
		}

		private bool CreateTechnicalActivityIfNeeded() {
			if (!CreateActivity) {
				return IsRunning;
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

		#endregion

		#region Methods: Protected

		/// <inheritdoc/>
		protected override bool InternalExecute(ProcessExecutingContext context) {
			if (EntryPointId.IsEmpty()) {
				EntryPointId = Utilities.AddProcessEntryPoint(UserConnection, EntitySchemaUId, EntityId, UId);
			}
			bool canSkipPerformerCheck = CreateTechnicalActivityIfNeeded();
			InteractWithUser(context, canSkipPerformerCheck, ShowExecutionPage);
			IsRunning = true;
			return false;
		}

		/// <inheritdoc />
		protected override void WriteExecutionData(IProcessExecutionDataWriter dataWriter) {
			base.WriteExecutionData(dataWriter);
			var page = ClientUnitSchemaManager.GetItemByUId(ClientUnitSchemaUId);
			string recommendation = LocalizableString.IsNullOrEmpty(Recommendation)
				? GetParameterValue("Recommendation")?.ToString() ?? string.Empty
				: Recommendation.Value;
			dataWriter.Write("recommendation", recommendation);
			string informationOnStep = LocalizableString.IsNullOrEmpty(InformationOnStep)
				? GetParameterValue("InformationOnStep")?.ToString() ?? string.Empty
				: InformationOnStep.Value;
			dataWriter.Write("informationOnStep", informationOnStep);
			dataWriter.Write("activityRecordId", CurrentActivityId);
			dataWriter.Write("header", Title.Value);
			dataWriter.Write("pageCaption", page.Caption.ToString());
			dataWriter.Write("nextProcElUId", "nextProcElUIdValue");
			dataWriter.Write("urlToken", GetUrlToken(page.Name));
			dataWriter.Write("recordId", EntityId);
			dataWriter.Write("preconfiguredPage", true);
			dataWriter.Write("action", Action);
			var processSchema = (ProcessSchema)Owner.Schema;
			bool isInheritedFromTemplate = ClientUnitSchemaManager.IsInheritedFrom(ClientUnitSchemaUId, Template);
			dataWriter.WriteObject("parameters", GetPageParameters(processSchema, isInheritedFromTemplate));
			dataWriter.WriteObject("attributes", isInheritedFromTemplate ? GetAttributes() : null);
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc/>
		public override bool CompleteExecuting(params object[] parameters) {
			Utilities.DeactivateProcessEntryPoint(UserConnection, EntryPointId, EntitySchemaUId, EntityId);
			if (CurrentActivityId.IsNotEmpty()) {
				this.SynchronizeCompletedUserTaskActivity(new UserTaskActivitySyncOptions {
					RemoveListener = true,
					SynchronizeParameterValues = false
				});
			}
			GenerateSignal();
			return base.CompleteExecuting(parameters);
		}

		/// <inheritdoc/>
		public override void CancelExecuting(params object[] parameters) {
			Utilities.DeactivateProcessEntryPoint(UserConnection, EntryPointId, EntitySchemaUId, EntityId);
			if (CurrentActivityId.IsNotEmpty()) {
				IProcessEngine processEngine = UserConnection.IProcessEngine;
				processEngine.RemoveActivityProcessListener(CurrentActivityId, UId, ActivityConsts.CanceledStatusUId);
			}
			base.CancelExecuting(parameters);
		}

		/// <inheritdoc/>
		public override string GetExecutionData() {
			if (UserConnection.GetIsFeatureEnabled("UseProcessPerformerAssignment")) {
				return base.GetExecutionData();
			}
			var page = ClientUnitSchemaManager.GetItemByUId(ClientUnitSchemaUId);
			var processSchema = (ProcessSchema)Owner.Schema;
			bool isInheritedFromTemplate = ClientUnitSchemaManager.IsInheritedFrom(ClientUnitSchemaUId, Template);
			string recommendation = LocalizableString.IsNullOrEmpty(Recommendation)
				? GetParameterValue("Recommendation")?.ToString() ?? string.Empty
				: Recommendation.Value;
			string informationOnStep = LocalizableString.IsNullOrEmpty(InformationOnStep)
				? GetParameterValue("InformationOnStep")?.ToString() ?? string.Empty
				: InformationOnStep.Value;
			var executionData = new {
				procElUId = UId,
				name = Name,
				processId = Utilities.GetParentProcessId(Owner),
				isProcessExecutedBySignal = Utilities.GetIsProcessExecutedBySignal(Owner),
				processName = Owner.Name,
				header = Title.Value,
				recommendation,
				informationOnStep,
				pageCaption = page.Caption.ToString(),
				nextProcElUId = "nextProcElUIdValue",
				urlToken = GetUrlToken(page.Name),
				recordId = EntityId,
				parameters = GetPageParameters(processSchema, isInheritedFromTemplate),
				attributes = isInheritedFromTemplate ? GetAttributes() : null,
				preconfiguredPage = true,
				action = Action
			};
			string jsonData = JsonConvert.SerializeObject(executionData, Formatting.None, GetSerializeJsonSettings());
			jsonData = GetUserContextExecutionData(jsonData);
			return jsonData;
		}

		/// <inheritdoc/>
		public override ProcessElementNotification GetNotificationData() {
			ProcessElementNotification notification = base.GetNotificationData();
			if (Recommendation != null && Recommendation.HasValue && !Recommendation.Value.IsNullOrEmpty()) {
				notification.Title = Recommendation;
			}
			return notification;
		}

		public virtual void GenerateSignal() {
			if (string.IsNullOrEmpty(PressedButtonCode)) {
				return;
			}
			ProcessSchema processSchema = (ProcessSchema)Owner.Schema;
			var userTask = (ProcessSchemaUserTask)processSchema.GetBaseElementByUId(SchemaElementUId);
			ProcessSchemaParameter buttonsParameter = userTask.Parameters.FindByName("Buttons");
			LocalizableParameterValuesList buttons = buttonsParameter?.SourceValue.LocalizableCollectionValue;
			LocalizableParameterValues pressedButton = buttons?.Find(button => button["Tag"].Value == PressedButtonCode);
			LocalizableParameterValue generateSignalValue = null;
			pressedButton?.TryGetValue("GenerateSignal", out generateSignalValue);
			string generateSignal = generateSignalValue?.Value;
			if (string.IsNullOrEmpty(generateSignal)) {
				return;
			}
			var context = new ProcessExecutingContext(UserConnection) { Process = Owner };
			UserConnection.IProcessEngine.ThrowSignal(context, generateSignal);
		}

		#endregion

	}

	#endregion

	#region Class: PreconfiguredPageUserTaskSchemaExtension

	/// <exclude/>
	public class PreconfiguredPageUserTaskSchemaExtension : ProcessUserTaskSchemaExtension
	{

		#region Methods: Public

		public override Dictionary<Guid, string> GetResultParameterAllValues(UserConnection userConnection, ProcessSchemaUserTask schemaUserTask) {
			var conditionValues = new Dictionary<Guid, string>();
			ProcessSchemaParameterValue sourceValue = schemaUserTask.Parameters.GetByName("Buttons").SourceValue;
			LocalizableParameterValuesList items = sourceValue.LocalizableCollectionValue;
			if (items == null) {
				items = new LocalizableParameterValuesList();
			} else {
				items.SetupDefaultLocalizableValues("Caption", "No caption");
			}
			foreach (var item in items) {
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

