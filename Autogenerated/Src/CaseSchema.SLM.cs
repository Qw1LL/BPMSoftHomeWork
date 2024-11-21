namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;
	using CoreSysSettings = BPMSoft.Core.Configuration.SysSettings;
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
	using System.Text;

	#region Class: Case_SLM_BPMSoftSchema

	/// <exclude/>
	public class Case_SLM_BPMSoftSchema : BPMSoft.Configuration.Case_Case_BPMSoftSchema
	{

		#region Constructors: Public

		public Case_SLM_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Case_SLM_BPMSoftSchema(Case_SLM_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Case_SLM_BPMSoftSchema(Case_SLM_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIX_RegisteredOn_DescIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("9ed6688c-3e02-47af-9124-e38e20904716");
			index.Name = "IX_RegisteredOn_Desc";
			index.CreatedInSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd");
			index.ModifiedInSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd");
			index.CreatedInPackageId = new Guid("a7919973-994c-4956-b846-530c9ef3b289");
			EntitySchemaIndexColumn registeredOnIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("aa03e37c-3527-4b5c-a16c-53fbc178b41e"),
				ColumnUId = new Guid("c91a9a6f-008d-4b2e-83d5-03868ad68c99"),
				CreatedInSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				ModifiedInSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				CreatedInPackageId = new Guid("a7919973-994c-4956-b846-530c9ef3b289"),
				OrderDirection = OrderDirectionStrict.Descending
			};
			index.Columns.Add(registeredOnIndexColumn);
			return index;
		}

		private EntitySchemaIndex CreateIX_SolutionOverdue_AttributesIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("9ad0ba05-3b32-4561-8bfc-870aee9c951c");
			index.Name = "IX_SolutionOverdue_Attributes";
			index.CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c");
			index.ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c");
			index.CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd");
			EntitySchemaIndexColumn solutionProvidedOnIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("4f3631c8-b14e-4591-a25a-b9207401cfa2"),
				ColumnUId = new Guid("81552f0a-fd92-4865-9533-f4c3ab2861a7"),
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				OrderDirection = OrderDirectionStrict.Descending
			};
			index.Columns.Add(solutionProvidedOnIndexColumn);
			EntitySchemaIndexColumn solutionDateIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("5de35510-255d-4f3f-8119-9a3f9b8082f5"),
				ColumnUId = new Guid("624839d1-3bd0-45e0-95d1-28326703f19c"),
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				OrderDirection = OrderDirectionStrict.Descending
			};
			index.Columns.Add(solutionDateIndexColumn);
			EntitySchemaIndexColumn solutionOverdueIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("8dab4368-f988-43de-a48e-bbf238fc3237"),
				ColumnUId = new Guid("0fa66efc-d2d0-47b9-abab-9e3ad2ea82d3"),
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(solutionOverdueIndexColumn);
			return index;
		}

		private EntitySchemaIndex CreateIX_ResponseOverdue_AttributesIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("8d002ad1-0715-4bdc-aa5e-8be1a5e39381");
			index.Name = "IX_ResponseOverdue_Attributes";
			index.CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c");
			index.ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c");
			index.CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd");
			EntitySchemaIndexColumn respondedOnIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("14abc9af-1b98-4ee2-b236-3a9576b1770f"),
				ColumnUId = new Guid("02612dc8-7243-4acb-b0bd-abbd19e24136"),
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				OrderDirection = OrderDirectionStrict.Descending
			};
			index.Columns.Add(respondedOnIndexColumn);
			EntitySchemaIndexColumn responseDateIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("c3226bd5-beb9-48ea-9383-30fb120d4f4d"),
				ColumnUId = new Guid("25280121-c075-441f-b4f8-feeb6cc7ca38"),
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				OrderDirection = OrderDirectionStrict.Descending
			};
			index.Columns.Add(responseDateIndexColumn);
			EntitySchemaIndexColumn responseOverdueIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("a4aaaa1e-d84e-48a2-84ac-04c35a6fad1e"),
				ColumnUId = new Guid("1ed4e080-0bf8-4f4f-97e8-b3e22f3240a0"),
				CreatedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				ModifiedInSchemaUId = new Guid("7d80c5f8-f594-44e3-b87e-31b7f7432c4c"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(responseOverdueIndexColumn);
			return index;
		}

		private EntitySchemaIndex CreateIDX_SubjectIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("e675ceca-ff2f-44c2-bd1a-f2c1af261cba");
			index.Name = "IDX_Subject";
			index.CreatedInSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd");
			index.ModifiedInSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd");
			index.CreatedInPackageId = new Guid("ff020f92-eb95-49ea-a251-6a0ed7e274a5");
			EntitySchemaIndexColumn subjectIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("5f164afe-e5a5-40a6-9e32-b7f83656bba8"),
				ColumnUId = new Guid("ffe8526d-044f-4222-a1ef-fca83a0772d8"),
				CreatedInSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				ModifiedInSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				CreatedInPackageId = new Guid("ff020f92-eb95-49ea-a251-6a0ed7e274a5"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(subjectIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("3179e425-d87c-4c9c-a201-53e19a977f6d");
			Name = "Case_SLM_BPMSoft";
			ParentSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd");
			ExtendParent = true;
			CreatedInPackageId = new Guid("4bc36079-7dbb-41e6-9a4e-b85039bf2a70");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("61ccdc6d-f9dc-4b22-a86d-212127e717a6")) == null) {
				Columns.Add(CreateServiceItemColumn());
			}
			if (Columns.FindByUId(new Guid("58cec386-8fdf-42e3-8014-ca4001c615ec")) == null) {
				Columns.Add(CreateProcessingTimeUnitColumn());
			}
			if (Columns.FindByUId(new Guid("28dfd64f-463a-449c-9fcd-a9bfed4a5686")) == null) {
				Columns.Add(CreateProcessingTimeUnitValueColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateServiceItemColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("61ccdc6d-f9dc-4b22-a86d-212127e717a6"),
				Name = @"ServiceItem",
				ReferenceSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3179e425-d87c-4c9c-a201-53e19a977f6d"),
				ModifiedInSchemaUId = new Guid("3179e425-d87c-4c9c-a201-53e19a977f6d"),
				CreatedInPackageId = new Guid("4bc36079-7dbb-41e6-9a4e-b85039bf2a70")
			};
		}

		protected virtual EntitySchemaColumn CreateProcessingTimeUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("58cec386-8fdf-42e3-8014-ca4001c615ec"),
				Name = @"ProcessingTimeUnit",
				ReferenceSchemaUId = new Guid("a9432d40-f95f-4d31-9f48-0444ebba77ab"),
				IsValueCloneable = false,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("3179e425-d87c-4c9c-a201-53e19a977f6d"),
				ModifiedInSchemaUId = new Guid("3179e425-d87c-4c9c-a201-53e19a977f6d"),
				CreatedInPackageId = new Guid("b11d550e-0087-4f53-ae17-fb00d41102cf")
			};
		}

		protected virtual EntitySchemaColumn CreateProcessingTimeUnitValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("28dfd64f-463a-449c-9fcd-a9bfed4a5686"),
				Name = @"ProcessingTimeUnitValue",
				IsValueCloneable = false,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("3179e425-d87c-4c9c-a201-53e19a977f6d"),
				ModifiedInSchemaUId = new Guid("3179e425-d87c-4c9c-a201-53e19a977f6d"),
				CreatedInPackageId = new Guid("b11d550e-0087-4f53-ae17-fb00d41102cf")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIX_RegisteredOn_DescIndex());
			Indexes.Add(CreateIX_SolutionOverdue_AttributesIndex());
			Indexes.Add(CreateIX_ResponseOverdue_AttributesIndex());
			Indexes.Add(CreateIDX_SubjectIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Case_SLM_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Case_SLMEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Case_SLM_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Case_SLM_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3179e425-d87c-4c9c-a201-53e19a977f6d"));
		}

		#endregion

	}

	#endregion

	#region Class: Case_SLM_BPMSoft

	/// <summary>
	/// Обращение.
	/// </summary>
	public class Case_SLM_BPMSoft : BPMSoft.Configuration.Case_Case_BPMSoft
	{

		#region Constructors: Public

		public Case_SLM_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Case_SLM_BPMSoft";
		}

		public Case_SLM_BPMSoft(Case_SLM_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ServiceItemId {
			get {
				return GetTypedColumnValue<Guid>("ServiceItemId");
			}
			set {
				SetColumnValue("ServiceItemId", value);
				_serviceItem = null;
			}
		}

		/// <exclude/>
		public string ServiceItemName {
			get {
				return GetTypedColumnValue<string>("ServiceItemName");
			}
			set {
				SetColumnValue("ServiceItemName", value);
				if (_serviceItem != null) {
					_serviceItem.Name = value;
				}
			}
		}

		private ServiceItem _serviceItem;
		/// <summary>
		/// Сервис.
		/// </summary>
		public ServiceItem ServiceItem {
			get {
				return _serviceItem ??
					(_serviceItem = LookupColumnEntities.GetEntity("ServiceItem") as ServiceItem);
			}
		}

		/// <exclude/>
		public Guid ProcessingTimeUnitId {
			get {
				return GetTypedColumnValue<Guid>("ProcessingTimeUnitId");
			}
			set {
				SetColumnValue("ProcessingTimeUnitId", value);
				_processingTimeUnit = null;
			}
		}

		/// <exclude/>
		public string ProcessingTimeUnitName {
			get {
				return GetTypedColumnValue<string>("ProcessingTimeUnitName");
			}
			set {
				SetColumnValue("ProcessingTimeUnitName", value);
				if (_processingTimeUnit != null) {
					_processingTimeUnit.Name = value;
				}
			}
		}

		private TimeUnit _processingTimeUnit;
		/// <summary>
		/// Единица времени обработки.
		/// </summary>
		public TimeUnit ProcessingTimeUnit {
			get {
				return _processingTimeUnit ??
					(_processingTimeUnit = LookupColumnEntities.GetEntity("ProcessingTimeUnit") as TimeUnit);
			}
		}

		/// <summary>
		/// Значение времени обработки.
		/// </summary>
		public int ProcessingTimeUnitValue {
			get {
				return GetTypedColumnValue<int>("ProcessingTimeUnitValue");
			}
			set {
				SetColumnValue("ProcessingTimeUnitValue", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Case_SLMEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Case_SLM_BPMSoftDeleted", e);
			Saved += (s, e) => ThrowEvent("Case_SLM_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("Case_SLM_BPMSoftSaving", e);
			SaveError += (s, e) => ThrowEvent("Case_SLM_BPMSoftSaveError", e);
			Validating += (s, e) => ThrowEvent("Case_SLM_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Case_SLM_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Case_SLMEventsProcess

	/// <exclude/>
	public partial class Case_SLMEventsProcess<TEntity> : BPMSoft.Configuration.Case_CaseEventsProcess<TEntity> where TEntity : Case_SLM_BPMSoft
	{

		public Case_SLMEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Case_SLMEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("3179e425-d87c-4c9c-a201-53e19a977f6d");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual bool NeedSaveLifecycle {
			get;
			set;
		}

		public virtual Guid CreatedCaseLifecycleId {
			get;
			set;
		}

		public virtual bool StatusChanged {
			get;
			set;
		}

		public virtual bool IsNew {
			get;
			set;
		}

		public virtual Guid ClosedCaseLifeCycleId {
			get;
			set;
		}

		private ProcessFlowElement _sLM_EventSubProcess4;
		public ProcessFlowElement SLM_EventSubProcess4 {
			get {
				return _sLM_EventSubProcess4 ?? (_sLM_EventSubProcess4 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "SLM_EventSubProcess4",
					SchemaElementUId = new Guid("7acc5824-a8d2-4916-b0bb-74950db35337"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _logChangesScriptTask;
		public ProcessScriptTask LogChangesScriptTask {
			get {
				return _logChangesScriptTask ?? (_logChangesScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "LogChangesScriptTask",
					SchemaElementUId = new Guid("00a4ff68-2b07-4d54-99c3-f51fa625c33c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = LogChangesScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _sLM_CaseSavingStartMessage;
		public ProcessFlowElement SLM_CaseSavingStartMessage {
			get {
				return _sLM_CaseSavingStartMessage ?? (_sLM_CaseSavingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SLM_CaseSavingStartMessage",
					SchemaElementUId = new Guid("9dda909c-699b-4cc1-b336-773e8cb64ce8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessThrowMessageEvent _sLM_CaseSavingIntermediateThrowMessage;
		public ProcessThrowMessageEvent SLM_CaseSavingIntermediateThrowMessage {
			get {
				return _sLM_CaseSavingIntermediateThrowMessage ?? (_sLM_CaseSavingIntermediateThrowMessage = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "SLM_CaseSavingIntermediateThrowMessage",
					SchemaElementUId = new Guid("795470b7-437d-4498-bf31-19d87954dc1b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "CaseSaving",
						ThrowToBase = true,
				});
			}
		}

		private ProcessThrowMessageEvent _sLM_CaseSavedIntermediateThrowMessage;
		public ProcessThrowMessageEvent SLM_CaseSavedIntermediateThrowMessage {
			get {
				return _sLM_CaseSavedIntermediateThrowMessage ?? (_sLM_CaseSavedIntermediateThrowMessage = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "SLM_CaseSavedIntermediateThrowMessage",
					SchemaElementUId = new Guid("223892fd-ea8a-4fb3-b606-902ceae69017"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "CaseSaved",
						ThrowToBase = true,
				});
			}
		}

		private ProcessScriptTask _sLM_SetIsNeedToLogLifecycleScriptTask;
		public ProcessScriptTask SLM_SetIsNeedToLogLifecycleScriptTask {
			get {
				return _sLM_SetIsNeedToLogLifecycleScriptTask ?? (_sLM_SetIsNeedToLogLifecycleScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SLM_SetIsNeedToLogLifecycleScriptTask",
					SchemaElementUId = new Guid("23046b50-e6cf-40ab-89bf-8b4fbd15d222"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SLM_SetIsNeedToLogLifecycleScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _sLM_CaseSavedStartMessage;
		public ProcessFlowElement SLM_CaseSavedStartMessage {
			get {
				return _sLM_CaseSavedStartMessage ?? (_sLM_CaseSavedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SLM_CaseSavedStartMessage",
					SchemaElementUId = new Guid("8438da09-4b2b-423a-98e7-01d26e53994e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _sLM_UpdateColumnsScriptTask;
		public ProcessScriptTask SLM_UpdateColumnsScriptTask {
			get {
				return _sLM_UpdateColumnsScriptTask ?? (_sLM_UpdateColumnsScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SLM_UpdateColumnsScriptTask",
					SchemaElementUId = new Guid("a73f848f-f46c-477a-9e32-98f6bcb4d9f6"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SLM_UpdateColumnsScriptTaskExecute,
				});
			}
		}

		private ProcessScriptTask _scriptTask4_ab9276f748f74b7bb7e989b4384bf572;
		public ProcessScriptTask ScriptTask4_ab9276f748f74b7bb7e989b4384bf572 {
			get {
				return _scriptTask4_ab9276f748f74b7bb7e989b4384bf572 ?? (_scriptTask4_ab9276f748f74b7bb7e989b4384bf572 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask4_ab9276f748f74b7bb7e989b4384bf572",
					SchemaElementUId = new Guid("ab9276f7-48f7-4b7b-b7e9-89b4384bf572"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask4_ab9276f748f74b7bb7e989b4384bf572Execute,
				});
			}
		}

		private ProcessScriptTask _scriptTask5_b1a0f7f9d74246ebb8a883eed5b27f2f;
		public ProcessScriptTask ScriptTask5_b1a0f7f9d74246ebb8a883eed5b27f2f {
			get {
				return _scriptTask5_b1a0f7f9d74246ebb8a883eed5b27f2f ?? (_scriptTask5_b1a0f7f9d74246ebb8a883eed5b27f2f = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask5_b1a0f7f9d74246ebb8a883eed5b27f2f",
					SchemaElementUId = new Guid("b1a0f7f9-d742-46eb-b8a8-83eed5b27f2f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask5_b1a0f7f9d74246ebb8a883eed5b27f2fExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess1_8e05cd38afa84cab84fbe9f539e7f085;
		public ProcessFlowElement EventSubProcess1_8e05cd38afa84cab84fbe9f539e7f085 {
			get {
				return _eventSubProcess1_8e05cd38afa84cab84fbe9f539e7f085 ?? (_eventSubProcess1_8e05cd38afa84cab84fbe9f539e7f085 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess1_8e05cd38afa84cab84fbe9f539e7f085",
					SchemaElementUId = new Guid("8e05cd38-afa8-4cab-84fb-e9f539e7f085"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask3_5aea08ec6fd14149ac9c388eaecacdce;
		public ProcessScriptTask ScriptTask3_5aea08ec6fd14149ac9c388eaecacdce {
			get {
				return _scriptTask3_5aea08ec6fd14149ac9c388eaecacdce ?? (_scriptTask3_5aea08ec6fd14149ac9c388eaecacdce = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask3_5aea08ec6fd14149ac9c388eaecacdce",
					SchemaElementUId = new Guid("5aea08ec-6fd1-4149-ac9c-388eaecacdce"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask3_5aea08ec6fd14149ac9c388eaecacdceExecute,
				});
			}
		}

		private ProcessThrowMessageEvent _intermediateThrowMessage1_9ff187f5851a471f8cd83eba5bb9414f;
		public ProcessThrowMessageEvent IntermediateThrowMessage1_9ff187f5851a471f8cd83eba5bb9414f {
			get {
				return _intermediateThrowMessage1_9ff187f5851a471f8cd83eba5bb9414f ?? (_intermediateThrowMessage1_9ff187f5851a471f8cd83eba5bb9414f = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "IntermediateThrowMessage1_9ff187f5851a471f8cd83eba5bb9414f",
					SchemaElementUId = new Guid("0aa4dfb4-18a7-4b90-a506-b229b54d43db"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "CaseSaveError",
						ThrowToBase = true,
				});
			}
		}

		private ProcessFlowElement _startMessage1_59ac7bb5ba534da28c4b27e4991d86c8;
		public ProcessFlowElement StartMessage1_59ac7bb5ba534da28c4b27e4991d86c8 {
			get {
				return _startMessage1_59ac7bb5ba534da28c4b27e4991d86c8 ?? (_startMessage1_59ac7bb5ba534da28c4b27e4991d86c8 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage1_59ac7bb5ba534da28c4b27e4991d86c8",
					SchemaElementUId = new Guid("59ac7bb5-ba53-4da2-8c4b-27e4991d86c8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[SLM_EventSubProcess4.SchemaElementUId] = new Collection<ProcessFlowElement> { SLM_EventSubProcess4 };
			FlowElements[LogChangesScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { LogChangesScriptTask };
			FlowElements[SLM_CaseSavingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SLM_CaseSavingStartMessage };
			FlowElements[SLM_CaseSavingIntermediateThrowMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SLM_CaseSavingIntermediateThrowMessage };
			FlowElements[SLM_CaseSavedIntermediateThrowMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SLM_CaseSavedIntermediateThrowMessage };
			FlowElements[SLM_SetIsNeedToLogLifecycleScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SLM_SetIsNeedToLogLifecycleScriptTask };
			FlowElements[SLM_CaseSavedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SLM_CaseSavedStartMessage };
			FlowElements[SLM_UpdateColumnsScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SLM_UpdateColumnsScriptTask };
			FlowElements[ScriptTask4_ab9276f748f74b7bb7e989b4384bf572.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask4_ab9276f748f74b7bb7e989b4384bf572 };
			FlowElements[ScriptTask5_b1a0f7f9d74246ebb8a883eed5b27f2f.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask5_b1a0f7f9d74246ebb8a883eed5b27f2f };
			FlowElements[EventSubProcess1_8e05cd38afa84cab84fbe9f539e7f085.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1_8e05cd38afa84cab84fbe9f539e7f085 };
			FlowElements[ScriptTask3_5aea08ec6fd14149ac9c388eaecacdce.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask3_5aea08ec6fd14149ac9c388eaecacdce };
			FlowElements[IntermediateThrowMessage1_9ff187f5851a471f8cd83eba5bb9414f.SchemaElementUId] = new Collection<ProcessFlowElement> { IntermediateThrowMessage1_9ff187f5851a471f8cd83eba5bb9414f };
			FlowElements[StartMessage1_59ac7bb5ba534da28c4b27e4991d86c8.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage1_59ac7bb5ba534da28c4b27e4991d86c8 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "SLM_EventSubProcess4":
						break;
					case "LogChangesScriptTask":
						e.Context.QueueTasks.Enqueue("ScriptTask4_ab9276f748f74b7bb7e989b4384bf572");
						break;
					case "SLM_CaseSavingStartMessage":
						e.Context.QueueTasks.Enqueue("ScriptTask5_b1a0f7f9d74246ebb8a883eed5b27f2f");
						break;
					case "SLM_CaseSavingIntermediateThrowMessage":
						break;
					case "SLM_CaseSavedIntermediateThrowMessage":
						break;
					case "SLM_SetIsNeedToLogLifecycleScriptTask":
						e.Context.QueueTasks.Enqueue("SLM_CaseSavingIntermediateThrowMessage");
						break;
					case "SLM_CaseSavedStartMessage":
						e.Context.QueueTasks.Enqueue("LogChangesScriptTask");
						break;
					case "SLM_UpdateColumnsScriptTask":
						e.Context.QueueTasks.Enqueue("SLM_SetIsNeedToLogLifecycleScriptTask");
						break;
					case "ScriptTask4_ab9276f748f74b7bb7e989b4384bf572":
						e.Context.QueueTasks.Enqueue("SLM_CaseSavedIntermediateThrowMessage");
						break;
					case "ScriptTask5_b1a0f7f9d74246ebb8a883eed5b27f2f":
						e.Context.QueueTasks.Enqueue("SLM_UpdateColumnsScriptTask");
						break;
					case "EventSubProcess1_8e05cd38afa84cab84fbe9f539e7f085":
						break;
					case "ScriptTask3_5aea08ec6fd14149ac9c388eaecacdce":
						e.Context.QueueTasks.Enqueue("IntermediateThrowMessage1_9ff187f5851a471f8cd83eba5bb9414f");
						break;
					case "IntermediateThrowMessage1_9ff187f5851a471f8cd83eba5bb9414f":
						break;
					case "StartMessage1_59ac7bb5ba534da28c4b27e4991d86c8":
						e.Context.QueueTasks.Enqueue("ScriptTask3_5aea08ec6fd14149ac9c388eaecacdce");
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("SLM_CaseSavingStartMessage");
			ActivatedEventElements.Add("SLM_CaseSavedStartMessage");
			ActivatedEventElements.Add("StartMessage1_59ac7bb5ba534da28c4b27e4991d86c8");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "SLM_EventSubProcess4":
					context.QueueTasks.Dequeue();
					break;
				case "LogChangesScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "LogChangesScriptTask";
					result = LogChangesScriptTask.Execute(context, LogChangesScriptTaskExecute);
					break;
				case "SLM_CaseSavingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "SLM_CaseSavingStartMessage";
					result = SLM_CaseSavingStartMessage.Execute(context);
					break;
				case "SLM_CaseSavingIntermediateThrowMessage":
					context.QueueTasks.Dequeue();
					base.ThrowEvent(context, "CaseSaving");
					result = SLM_CaseSavingIntermediateThrowMessage.Execute(context);
					break;
				case "SLM_CaseSavedIntermediateThrowMessage":
					context.QueueTasks.Dequeue();
					base.ThrowEvent(context, "CaseSaved");
					result = SLM_CaseSavedIntermediateThrowMessage.Execute(context);
					break;
				case "SLM_SetIsNeedToLogLifecycleScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "SLM_SetIsNeedToLogLifecycleScriptTask";
					result = SLM_SetIsNeedToLogLifecycleScriptTask.Execute(context, SLM_SetIsNeedToLogLifecycleScriptTaskExecute);
					break;
				case "SLM_CaseSavedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "SLM_CaseSavedStartMessage";
					result = SLM_CaseSavedStartMessage.Execute(context);
					break;
				case "SLM_UpdateColumnsScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "SLM_UpdateColumnsScriptTask";
					result = SLM_UpdateColumnsScriptTask.Execute(context, SLM_UpdateColumnsScriptTaskExecute);
					break;
				case "ScriptTask4_ab9276f748f74b7bb7e989b4384bf572":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask4_ab9276f748f74b7bb7e989b4384bf572";
					result = ScriptTask4_ab9276f748f74b7bb7e989b4384bf572.Execute(context, ScriptTask4_ab9276f748f74b7bb7e989b4384bf572Execute);
					break;
				case "ScriptTask5_b1a0f7f9d74246ebb8a883eed5b27f2f":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask5_b1a0f7f9d74246ebb8a883eed5b27f2f";
					result = ScriptTask5_b1a0f7f9d74246ebb8a883eed5b27f2f.Execute(context, ScriptTask5_b1a0f7f9d74246ebb8a883eed5b27f2fExecute);
					break;
				case "EventSubProcess1_8e05cd38afa84cab84fbe9f539e7f085":
					context.QueueTasks.Dequeue();
					break;
				case "ScriptTask3_5aea08ec6fd14149ac9c388eaecacdce":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask3_5aea08ec6fd14149ac9c388eaecacdce";
					result = ScriptTask3_5aea08ec6fd14149ac9c388eaecacdce.Execute(context, ScriptTask3_5aea08ec6fd14149ac9c388eaecacdceExecute);
					break;
				case "IntermediateThrowMessage1_9ff187f5851a471f8cd83eba5bb9414f":
					context.QueueTasks.Dequeue();
					base.ThrowEvent(context, "CaseSaveError");
					result = IntermediateThrowMessage1_9ff187f5851a471f8cd83eba5bb9414f.Execute(context);
					break;
				case "StartMessage1_59ac7bb5ba534da28c4b27e4991d86c8":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage1_59ac7bb5ba534da28c4b27e4991d86c8";
					result = StartMessage1_59ac7bb5ba534da28c4b27e4991d86c8.Execute(context);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool LogChangesScriptTaskExecute(ProcessExecutingContext context) {
			if (NeedSaveLifecycle) {
				LogChangedColumns();
			}
			return true;
		}

		public virtual bool SLM_SetIsNeedToLogLifecycleScriptTaskExecute(ProcessExecutingContext context) {
			NeedSaveLifecycle = GetIsNeedToLogLifecycle();
			if (NeedSaveLifecycle) {
				SaveLifecycle();
			}
			return true;
		}

		public virtual bool SLM_UpdateColumnsScriptTaskExecute(ProcessExecutingContext context) {
			UpdateResponse();
			UpdateSolution();
			UpdateClosureDate();
			CalculateTerms();
			return true;
		}

		public virtual bool ScriptTask4_ab9276f748f74b7bb7e989b4384bf572Execute(ProcessExecutingContext context) {
			NotifyUser();
			return true;
		}

		public virtual bool ScriptTask5_b1a0f7f9d74246ebb8a883eed5b27f2fExecute(ProcessExecutingContext context) {
			StatusChanged = CheckIsStatusChanged();
			IsNew = Entity.GetTypedOldColumnValue<Guid>("Id") == Guid.Empty;
			return true;
		}

		public virtual bool ScriptTask3_5aea08ec6fd14149ac9c388eaecacdceExecute(ProcessExecutingContext context) {
			var delete = new Delete(UserConnection).From("CaseLifecycle")
			.Where("Id")
				.IsEqual(Column.Parameter(CreatedCaseLifecycleId));
			delete.Execute();
			var instance = UserConnection.EntitySchemaManager.GetInstanceByName("CaseLifecycle");
			var caseLifecycle = instance.CreateEntity(UserConnection);
			if (caseLifecycle.FetchFromDB(ClosedCaseLifeCycleId)) {
				caseLifecycle.SetColumnValue("EndDate", null);
				caseLifecycle.SetColumnValue("StateDurationInMinutes", null);
				caseLifecycle.SetColumnValue("StateDurationInHours", null);
				caseLifecycle.SetColumnValue("StateDurationInDays", null);
				caseLifecycle.Save();
			}
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "Case_SLM_BPMSoftSaving":
							if (ActivatedEventElements.Contains("SLM_CaseSavingStartMessage")) {
							context.QueueTasks.Enqueue("SLM_CaseSavingStartMessage");
							ProcessQueue(context);
							return;
						}
						break;
					case "Case_SLM_BPMSoftSaved":
							if (ActivatedEventElements.Contains("SLM_CaseSavedStartMessage")) {
							context.QueueTasks.Enqueue("SLM_CaseSavedStartMessage");
							ProcessQueue(context);
							return;
						}
						break;
					case "Case_SLM_BPMSoftSaveError":
							if (ActivatedEventElements.Contains("StartMessage1_59ac7bb5ba534da28c4b27e4991d86c8")) {
							context.QueueTasks.Enqueue("StartMessage1_59ac7bb5ba534da28c4b27e4991d86c8");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: Case_SLMEventsProcess

	/// <exclude/>
	public class Case_SLMEventsProcess : Case_SLMEventsProcess<Case_SLM_BPMSoft>
	{

		public Case_SLMEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

