namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.OperationLog;
	using BPMSoft.Core.Packages;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;
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

	#region Class: VwWorkspaceObjectsSchema

	/// <exclude/>
	public class VwWorkspaceObjectsSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public VwWorkspaceObjectsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwWorkspaceObjectsSchema(VwWorkspaceObjectsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwWorkspaceObjectsSchema(VwWorkspaceObjectsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("95a9f7af-bbd7-408a-a5e2-7b24b3f4556e");
			RealUId = new Guid("95a9f7af-bbd7-408a-a5e2-7b24b3f4556e");
			Name = "VwWorkspaceObjects";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateCaptionColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("c7227eee-1b80-4db9-9f3a-cfdaa562ae3d")) == null) {
				Columns.Add(CreateIsModuleColumn());
			}
			if (Columns.FindByUId(new Guid("356fed4d-7b90-41aa-9d61-2cfe1df9e9fc")) == null) {
				Columns.Add(CreateIsLookupColumn());
			}
			if (Columns.FindByUId(new Guid("278b1727-05db-41b5-a80c-72fc962430ee")) == null) {
				Columns.Add(CreateAdministratedByRecordsColumn());
			}
			if (Columns.FindByUId(new Guid("c449bd15-1392-4a02-b1d3-f3852c194ebf")) == null) {
				Columns.Add(CreateAdministratedByColumnsColumn());
			}
			if (Columns.FindByUId(new Guid("b12eda60-9b6a-4295-a281-8bd1fd1c2d33")) == null) {
				Columns.Add(CreateAdministratedByOperationsColumn());
			}
			if (Columns.FindByUId(new Guid("b7a4479c-74c2-4491-bca8-a03c0c093458")) == null) {
				Columns.Add(CreateSysWorkspaceColumn());
			}
			if (Columns.FindByUId(new Guid("b076dce7-a486-4584-a06e-567972ab10c8")) == null) {
				Columns.Add(CreateIsTrackChangesInDBColumn());
			}
			if (Columns.FindByUId(new Guid("117b0843-3caf-41b7-9f04-59ef867d640d")) == null) {
				Columns.Add(CreateIsInSSPEntitySchemaAccessListColumn());
			}
			if (Columns.FindByUId(new Guid("50b78acd-9cab-49e3-812a-fd96337814a9")) == null) {
				Columns.Add(CreateUIdColumn());
			}
			if (Columns.FindByUId(new Guid("165c9b05-f1b9-9f9a-b90d-79d0963967c7")) == null) {
				Columns.Add(CreateIsAvailableInStudioColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("95a9f7af-bbd7-408a-a5e2-7b24b3f4556e");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("95a9f7af-bbd7-408a-a5e2-7b24b3f4556e");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("5d031a2d-53b8-4768-bead-6347cf929ec0"),
				Name = @"Caption",
				CreatedInSchemaUId = new Guid("95a9f7af-bbd7-408a-a5e2-7b24b3f4556e"),
				ModifiedInSchemaUId = new Guid("95a9f7af-bbd7-408a-a5e2-7b24b3f4556e"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateIsModuleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("c7227eee-1b80-4db9-9f3a-cfdaa562ae3d"),
				Name = @"IsModule",
				CreatedInSchemaUId = new Guid("95a9f7af-bbd7-408a-a5e2-7b24b3f4556e"),
				ModifiedInSchemaUId = new Guid("95a9f7af-bbd7-408a-a5e2-7b24b3f4556e"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateIsLookupColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("356fed4d-7b90-41aa-9d61-2cfe1df9e9fc"),
				Name = @"IsLookup",
				CreatedInSchemaUId = new Guid("95a9f7af-bbd7-408a-a5e2-7b24b3f4556e"),
				ModifiedInSchemaUId = new Guid("95a9f7af-bbd7-408a-a5e2-7b24b3f4556e"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateAdministratedByRecordsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("278b1727-05db-41b5-a80c-72fc962430ee"),
				Name = @"AdministratedByRecords",
				CreatedInSchemaUId = new Guid("95a9f7af-bbd7-408a-a5e2-7b24b3f4556e"),
				ModifiedInSchemaUId = new Guid("95a9f7af-bbd7-408a-a5e2-7b24b3f4556e"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateAdministratedByColumnsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("c449bd15-1392-4a02-b1d3-f3852c194ebf"),
				Name = @"AdministratedByColumns",
				CreatedInSchemaUId = new Guid("95a9f7af-bbd7-408a-a5e2-7b24b3f4556e"),
				ModifiedInSchemaUId = new Guid("95a9f7af-bbd7-408a-a5e2-7b24b3f4556e"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateAdministratedByOperationsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("b12eda60-9b6a-4295-a281-8bd1fd1c2d33"),
				Name = @"AdministratedByOperations",
				CreatedInSchemaUId = new Guid("95a9f7af-bbd7-408a-a5e2-7b24b3f4556e"),
				ModifiedInSchemaUId = new Guid("95a9f7af-bbd7-408a-a5e2-7b24b3f4556e"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysWorkspaceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b7a4479c-74c2-4491-bca8-a03c0c093458"),
				Name = @"SysWorkspace",
				ReferenceSchemaUId = new Guid("7f9653ec-2e91-4aaa-a065-7b1d46edd292"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("95a9f7af-bbd7-408a-a5e2-7b24b3f4556e"),
				ModifiedInSchemaUId = new Guid("95a9f7af-bbd7-408a-a5e2-7b24b3f4556e"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateIsTrackChangesInDBColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("b076dce7-a486-4584-a06e-567972ab10c8"),
				Name = @"IsTrackChangesInDB",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("95a9f7af-bbd7-408a-a5e2-7b24b3f4556e"),
				ModifiedInSchemaUId = new Guid("95a9f7af-bbd7-408a-a5e2-7b24b3f4556e"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateIsInSSPEntitySchemaAccessListColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("117b0843-3caf-41b7-9f04-59ef867d640d"),
				Name = @"IsInSSPEntitySchemaAccessList",
				CreatedInSchemaUId = new Guid("95a9f7af-bbd7-408a-a5e2-7b24b3f4556e"),
				ModifiedInSchemaUId = new Guid("95a9f7af-bbd7-408a-a5e2-7b24b3f4556e"),
				CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae")
			};
		}

		protected virtual EntitySchemaColumn CreateUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("50b78acd-9cab-49e3-812a-fd96337814a9"),
				Name = @"UId",
				CreatedInSchemaUId = new Guid("95a9f7af-bbd7-408a-a5e2-7b24b3f4556e"),
				ModifiedInSchemaUId = new Guid("95a9f7af-bbd7-408a-a5e2-7b24b3f4556e"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateIsAvailableInStudioColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("165c9b05-f1b9-9f9a-b90d-79d0963967c7"),
				Name = @"IsAvailableInStudio",
				CreatedInSchemaUId = new Guid("95a9f7af-bbd7-408a-a5e2-7b24b3f4556e"),
				ModifiedInSchemaUId = new Guid("95a9f7af-bbd7-408a-a5e2-7b24b3f4556e"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwWorkspaceObjects(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwWorkspaceObjects_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwWorkspaceObjectsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwWorkspaceObjectsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("95a9f7af-bbd7-408a-a5e2-7b24b3f4556e"));
		}

		#endregion

	}

	#endregion

	#region Class: VwWorkspaceObjects

	/// <summary>
	/// Объекты рабочего пространства (представление).
	/// </summary>
	public class VwWorkspaceObjects : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public VwWorkspaceObjects(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwWorkspaceObjects";
		}

		public VwWorkspaceObjects(VwWorkspaceObjects source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Заголовок.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
			}
		}

		/// <summary>
		/// Раздел.
		/// </summary>
		public bool IsModule {
			get {
				return GetTypedColumnValue<bool>("IsModule");
			}
			set {
				SetColumnValue("IsModule", value);
			}
		}

		/// <summary>
		/// Справочник.
		/// </summary>
		public bool IsLookup {
			get {
				return GetTypedColumnValue<bool>("IsLookup");
			}
			set {
				SetColumnValue("IsLookup", value);
			}
		}

		/// <summary>
		/// Администрируется по записям.
		/// </summary>
		public bool AdministratedByRecords {
			get {
				return GetTypedColumnValue<bool>("AdministratedByRecords");
			}
			set {
				SetColumnValue("AdministratedByRecords", value);
			}
		}

		/// <summary>
		/// Администрируется по колонкам.
		/// </summary>
		public bool AdministratedByColumns {
			get {
				return GetTypedColumnValue<bool>("AdministratedByColumns");
			}
			set {
				SetColumnValue("AdministratedByColumns", value);
			}
		}

		/// <summary>
		/// Администрируется по операциям.
		/// </summary>
		public bool AdministratedByOperations {
			get {
				return GetTypedColumnValue<bool>("AdministratedByOperations");
			}
			set {
				SetColumnValue("AdministratedByOperations", value);
			}
		}

		/// <exclude/>
		public Guid SysWorkspaceId {
			get {
				return GetTypedColumnValue<Guid>("SysWorkspaceId");
			}
			set {
				SetColumnValue("SysWorkspaceId", value);
				_sysWorkspace = null;
			}
		}

		/// <exclude/>
		public string SysWorkspaceName {
			get {
				return GetTypedColumnValue<string>("SysWorkspaceName");
			}
			set {
				SetColumnValue("SysWorkspaceName", value);
				if (_sysWorkspace != null) {
					_sysWorkspace.Name = value;
				}
			}
		}

		private SysWorkspace _sysWorkspace;
		/// <summary>
		/// Рабочее пространство.
		/// </summary>
		public SysWorkspace SysWorkspace {
			get {
				return _sysWorkspace ??
					(_sysWorkspace = LookupColumnEntities.GetEntity("SysWorkspace") as SysWorkspace);
			}
		}

		/// <summary>
		/// Вести журнал изменений.
		/// </summary>
		public bool IsTrackChangesInDB {
			get {
				return GetTypedColumnValue<bool>("IsTrackChangesInDB");
			}
			set {
				SetColumnValue("IsTrackChangesInDB", value);
			}
		}

		/// <summary>
		/// Доступен пользователям портала.
		/// </summary>
		public bool IsInSSPEntitySchemaAccessList {
			get {
				return GetTypedColumnValue<bool>("IsInSSPEntitySchemaAccessList");
			}
			set {
				SetColumnValue("IsInSSPEntitySchemaAccessList", value);
			}
		}

		/// <summary>
		/// UId.
		/// </summary>
		public Guid UId {
			get {
				return GetTypedColumnValue<Guid>("UId");
			}
			set {
				SetColumnValue("UId", value);
			}
		}

		/// <summary>
		/// Доступность в Studio.
		/// </summary>
		public bool IsAvailableInStudio {
			get {
				return GetTypedColumnValue<bool>("IsAvailableInStudio");
			}
			set {
				SetColumnValue("IsAvailableInStudio", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwWorkspaceObjects_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwWorkspaceObjectsDeleted", e);
			Deleting += (s, e) => ThrowEvent("VwWorkspaceObjectsDeleting", e);
			Inserted += (s, e) => ThrowEvent("VwWorkspaceObjectsInserted", e);
			Inserting += (s, e) => ThrowEvent("VwWorkspaceObjectsInserting", e);
			Saved += (s, e) => ThrowEvent("VwWorkspaceObjectsSaved", e);
			Saving += (s, e) => ThrowEvent("VwWorkspaceObjectsSaving", e);
			Updated += (s, e) => ThrowEvent("VwWorkspaceObjectsUpdated", e);
			Updating += (s, e) => ThrowEvent("VwWorkspaceObjectsUpdating", e);
			Validating += (s, e) => ThrowEvent("VwWorkspaceObjectsValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwWorkspaceObjects(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwWorkspaceObjects_BaseEventsProcess

	/// <exclude/>
	public partial class VwWorkspaceObjects_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : VwWorkspaceObjects
	{

		public VwWorkspaceObjects_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwWorkspaceObjects_BaseEventsProcess";
			SchemaUId = new Guid("95a9f7af-bbd7-408a-a5e2-7b24b3f4556e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("95a9f7af-bbd7-408a-a5e2-7b24b3f4556e");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _subProcess1;
		public ProcessFlowElement SubProcess1 {
			get {
				return _subProcess1 ?? (_subProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "SubProcess1",
					SchemaElementUId = new Guid("de22ab32-5082-4d48-93ef-9f5ca931c1fb"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessageVwWorkspaceObjectsUpdating;
		public ProcessFlowElement StartMessageVwWorkspaceObjectsUpdating {
			get {
				return _startMessageVwWorkspaceObjectsUpdating ?? (_startMessageVwWorkspaceObjectsUpdating = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessageVwWorkspaceObjectsUpdating",
					SchemaElementUId = new Guid("e0ea4e6c-4ac6-4c6a-b4b0-8fe10e63cb7f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptVwWorkspaceObjectsUpdating;
		public ProcessScriptTask ScriptVwWorkspaceObjectsUpdating {
			get {
				return _scriptVwWorkspaceObjectsUpdating ?? (_scriptVwWorkspaceObjectsUpdating = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptVwWorkspaceObjectsUpdating",
					SchemaElementUId = new Guid("9222f106-5075-4f61-8126-43c14a097ef8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptVwWorkspaceObjectsUpdatingExecute,
				});
			}
		}

		private ProcessFlowElement _subProcess2;
		public ProcessFlowElement SubProcess2 {
			get {
				return _subProcess2 ?? (_subProcess2 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "SubProcess2",
					SchemaElementUId = new Guid("2390509d-4343-49bf-8996-06c7ed59f236"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessageVwWorkspaceObjectsUpdated;
		public ProcessFlowElement StartMessageVwWorkspaceObjectsUpdated {
			get {
				return _startMessageVwWorkspaceObjectsUpdated ?? (_startMessageVwWorkspaceObjectsUpdated = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessageVwWorkspaceObjectsUpdated",
					SchemaElementUId = new Guid("f33ecdd0-d26b-406a-91e5-bff0c405f1ab"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptVwWorkspaceObjectsUpdated;
		public ProcessScriptTask ScriptVwWorkspaceObjectsUpdated {
			get {
				return _scriptVwWorkspaceObjectsUpdated ?? (_scriptVwWorkspaceObjectsUpdated = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptVwWorkspaceObjectsUpdated",
					SchemaElementUId = new Guid("2bdc98ab-bf56-48ee-9ec3-e71d569a42eb"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptVwWorkspaceObjectsUpdatedExecute,
				});
			}
		}

		private LocalizableString _operationExeptionMessage;
		public LocalizableString OperationExeptionMessage {
			get {
				return _operationExeptionMessage ?? (_operationExeptionMessage = new LocalizableString(Storage, Schema.GetResourceManagerName(), "EventsProcessSchema.LocalizableStrings.OperationExeptionMessage.Value"));
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[SubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { SubProcess1 };
			FlowElements[StartMessageVwWorkspaceObjectsUpdating.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessageVwWorkspaceObjectsUpdating };
			FlowElements[ScriptVwWorkspaceObjectsUpdating.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptVwWorkspaceObjectsUpdating };
			FlowElements[SubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { SubProcess2 };
			FlowElements[StartMessageVwWorkspaceObjectsUpdated.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessageVwWorkspaceObjectsUpdated };
			FlowElements[ScriptVwWorkspaceObjectsUpdated.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptVwWorkspaceObjectsUpdated };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "SubProcess1":
						break;
					case "StartMessageVwWorkspaceObjectsUpdating":
						e.Context.QueueTasks.Enqueue("ScriptVwWorkspaceObjectsUpdating");
						break;
					case "ScriptVwWorkspaceObjectsUpdating":
						break;
					case "SubProcess2":
						break;
					case "StartMessageVwWorkspaceObjectsUpdated":
						e.Context.QueueTasks.Enqueue("ScriptVwWorkspaceObjectsUpdated");
						break;
					case "ScriptVwWorkspaceObjectsUpdated":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("StartMessageVwWorkspaceObjectsUpdating");
			ActivatedEventElements.Add("StartMessageVwWorkspaceObjectsUpdated");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "SubProcess1":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessageVwWorkspaceObjectsUpdating":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessageVwWorkspaceObjectsUpdating";
					result = StartMessageVwWorkspaceObjectsUpdating.Execute(context);
					break;
				case "ScriptVwWorkspaceObjectsUpdating":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptVwWorkspaceObjectsUpdating";
					result = ScriptVwWorkspaceObjectsUpdating.Execute(context, ScriptVwWorkspaceObjectsUpdatingExecute);
					break;
				case "SubProcess2":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessageVwWorkspaceObjectsUpdated":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessageVwWorkspaceObjectsUpdated";
					result = StartMessageVwWorkspaceObjectsUpdated.Execute(context);
					break;
				case "ScriptVwWorkspaceObjectsUpdated":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptVwWorkspaceObjectsUpdated";
					result = ScriptVwWorkspaceObjectsUpdated.Execute(context, ScriptVwWorkspaceObjectsUpdatedExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptVwWorkspaceObjectsUpdatingExecute(ProcessExecutingContext context) {
			var eventArgs = (context.ThrowEventArgs as BPMSoft.Core.Entities.EntityBeforeEventArgs);
			var queryCondition = new BPMSoft.Core.DB.QueryCondition();
			queryCondition.ConditionType = BPMSoft.Core.DB.QueryConditionType.Equal;
			queryCondition.LeftExpression = new BPMSoft.Core.DB.QueryColumnExpression("SysWorkspaceId");
			queryCondition.RightExpressions.Add(
				new BPMSoft.Core.DB.QueryColumnExpression(BPMSoft.Core.DB.Column.Parameter(Entity.UserConnection.Workspace.Id)));
			eventArgs.AdditionalCondition = queryCondition;
			return true;
		}

		public virtual bool ScriptVwWorkspaceObjectsUpdatedExecute(ProcessExecutingContext context) {
			var eventArgs = (context.ThrowEventArgs as BPMSoft.Core.Entities.EntityAfterEventArgs);
			var modifiedColumnValues = eventArgs.ModifiedColumnValues;
			Guid sysBaseSchemaId = eventArgs.PrimaryColumnValue;
			Guid sysBaseSchemaUId = WorkspaceUtilities.GetSchemaUIdById(sysBaseSchemaId, UserConnection);
			var entitySchemaManager = UserConnection.EntitySchemaManager;
			var sysSchema = entitySchemaManager.GetItemByUId(sysBaseSchemaUId);
			if (sysSchema != null) {
				var administratedByColumns = modifiedColumnValues.FindByName("AdministratedByColumns");
				if (administratedByColumns != null) {
					bool? nNeedAddRightsForColumns = administratedByColumns.Value as bool?;
					bool needAddRightsForColumns = (nNeedAddRightsForColumns == null) ? false : (bool)nNeedAddRightsForColumns;
					if (needAddRightsForColumns) {
						AddRightsForColumns(sysBaseSchemaUId);
					}
					OperationLogger.Instance.LogAdminEntitySchemaEdit(UserConnection, Entity.Name, EntitySchemaAdministrationType.Columns, needAddRightsForColumns);
				}
				var administratedByOperations = modifiedColumnValues.FindByName("AdministratedByOperations");
				if (administratedByOperations != null) {
					bool? NeedAddRightsForOperations = administratedByOperations.Value as bool?;
					bool needAddRightsForOperations = (NeedAddRightsForOperations == null) ? false : (bool)NeedAddRightsForOperations;
					if (needAddRightsForOperations) {
						AddRightsForOperations(sysBaseSchemaUId);
					}
					OperationLogger.Instance.LogAdminEntitySchemaEdit(UserConnection, Entity.Name, EntitySchemaAdministrationType.Operations, needAddRightsForOperations);
				}
				var customSchema = entitySchemaManager.DesignItemInCustomPackage(UserConnection, sysBaseSchemaUId);
				var schema = customSchema.Instance as EntitySchema;
				schema.AdministratedByRecords = sysSchema.Instance.AdministratedByRecords;
				schema.AdministratedByColumns = sysSchema.Instance.AdministratedByColumns;
				schema.AdministratedByOperations = sysSchema.Instance.AdministratedByOperations;
				var extraProperties = customSchema.ExtraProperties;
				var adminByRecords = modifiedColumnValues.FindByName("AdministratedByRecords");
				var adminByColumns = modifiedColumnValues.FindByName("AdministratedByColumns");
				var adminByOperations = modifiedColumnValues.FindByName("AdministratedByOperations");
				if (adminByRecords != null) {
					bool? NeedAddRightsForRecords = adminByRecords.Value as bool?;
					bool needAddRightsForRecords = (NeedAddRightsForRecords == null) ? false : (bool)NeedAddRightsForRecords;
					extraProperties.SetValueByName("AdministratedByRecords", adminByRecords.Value);
					schema.AdministratedByRecords = (bool)adminByRecords.Value;
					schema.ValidateNames(false);
					if (needAddRightsForRecords) {
						CreateRightRecordsSchema(sysBaseSchemaUId);
					}
					OperationLogger.Instance.LogAdminEntitySchemaEdit(UserConnection, Entity.Name, EntitySchemaAdministrationType.Records, needAddRightsForRecords);
				}
				if (adminByColumns != null) {
					extraProperties.SetValueByName("AdministratedByColumns", adminByColumns.Value);
					schema.AdministratedByColumns = (bool)adminByColumns.Value;
				}
				if (adminByOperations != null) {
					extraProperties.SetValueByName("AdministratedByOperations", adminByOperations.Value);
					schema.AdministratedByOperations = (bool)adminByOperations.Value;
				}
				entitySchemaManager.SaveDesignedItemInSessionData(customSchema);
				entitySchemaManager.SaveSchema(schema.UId, Entity.UserConnection);
				foreach (var extraProperty in extraProperties) {
					var conditions = new System.Collections.Generic.Dictionary<string, object> {
						{ "Name", extraProperty.Name },
						{ "SysSchema", customSchema.Id }
					};
					if(extraProperty.Name == "Hash")	continue;
					SysSchemaProperty sysSchemaProperty = new SysSchemaProperty(Entity.UserConnection);
					if (!sysSchemaProperty.FetchFromDB(conditions)) {
						sysSchemaProperty.SetDefColumnValues();
					}
					sysSchemaProperty.SysSchemaId = customSchema.Id;
					sysSchemaProperty.Name = extraProperty.Name;
					sysSchemaProperty.Value = extraProperty.Value != null ? extraProperty.Value.ToString(): string.Empty;
					sysSchemaProperty.Save();
				}
				#if !NETSTANDARD2_0 // TODO
				bool isSuccessfulBuild = false;
				if (!GlobalAppSettings.FeatureUseRuntimeEntitySchemaMetadata) {
					var workspaceBuilder = BPMSoft.Core.Packages.WorkspaceBuilderUtility.CreateWorkspaceBuilder(UserConnection.AppConnection);
					var compilerErrorCollection = workspaceBuilder.Build(UserConnection.Workspace);
					isSuccessfulBuild = !compilerErrorCollection.HasErrors;
				}
				var configurationBuilder = ClassFactory.Get<BPMSoft.Core.ConfigurationBuild.IAppConfigurationBuilder>();
				configurationBuilder.BuildChanged();
				if (isSuccessfulBuild && GlobalAppSettings.FeatureDetachWorkspaceAssemblyChangedFromCompilation) {
					UserConnection.Workspace.WorkspaceChanged();
				}
				#endif
			}
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "VwWorkspaceObjectsUpdating":
							if (ActivatedEventElements.Contains("StartMessageVwWorkspaceObjectsUpdating")) {
							context.QueueTasks.Enqueue("StartMessageVwWorkspaceObjectsUpdating");
						}
						break;
					case "VwWorkspaceObjectsUpdated":
							if (ActivatedEventElements.Contains("StartMessageVwWorkspaceObjectsUpdated")) {
							context.QueueTasks.Enqueue("StartMessageVwWorkspaceObjectsUpdated");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: VwWorkspaceObjects_BaseEventsProcess

	/// <exclude/>
	public class VwWorkspaceObjects_BaseEventsProcess : VwWorkspaceObjects_BaseEventsProcess<VwWorkspaceObjects>
	{

		public VwWorkspaceObjects_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion


	#region Class: VwWorkspaceObjectsEventsProcess

	/// <exclude/>
	public class VwWorkspaceObjectsEventsProcess : VwWorkspaceObjects_BaseEventsProcess
	{

		public VwWorkspaceObjectsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

