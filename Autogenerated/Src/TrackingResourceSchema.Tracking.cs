namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration.Tracking;
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

	#region Class: TrackingResourceSchema

	/// <exclude/>
	public class TrackingResourceSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public TrackingResourceSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public TrackingResourceSchema(TrackingResourceSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public TrackingResourceSchema(TrackingResourceSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("87d7834d-e6fb-449f-a1bd-dbb57679ad87");
			RealUId = new Guid("87d7834d-e6fb-449f-a1bd-dbb57679ad87");
			Name = "TrackingResource";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("120fd877-7905-4e7f-9414-1956e0c20629");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("5c57f67a-bcf3-4eb7-b3ae-cb3d8a1f8527")) == null) {
				Columns.Add(CreateSourceColumn());
			}
			if (Columns.FindByUId(new Guid("f08e1ecc-dc92-474c-87e9-3386c0dd685c")) == null) {
				Columns.Add(CreateIsActiveColumn());
			}
			if (Columns.FindByUId(new Guid("e5d64707-88bb-4c9b-baed-c0fc22d918b4")) == null) {
				Columns.Add(CreateIsDeletedColumn());
			}
			if (Columns.FindByUId(new Guid("eb8ffd47-256d-427f-8467-d6f0fc67f5a2")) == null) {
				Columns.Add(CreateProjectColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("fd8dbf8b-c885-432e-993b-1fd43b15277e"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("87d7834d-e6fb-449f-a1bd-dbb57679ad87"),
				ModifiedInSchemaUId = new Guid("87d7834d-e6fb-449f-a1bd-dbb57679ad87"),
				CreatedInPackageId = new Guid("120fd877-7905-4e7f-9414-1956e0c20629")
			};
		}

		protected virtual EntitySchemaColumn CreateSourceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("5c57f67a-bcf3-4eb7-b3ae-cb3d8a1f8527"),
				Name = @"Source",
				CreatedInSchemaUId = new Guid("87d7834d-e6fb-449f-a1bd-dbb57679ad87"),
				ModifiedInSchemaUId = new Guid("87d7834d-e6fb-449f-a1bd-dbb57679ad87"),
				CreatedInPackageId = new Guid("120fd877-7905-4e7f-9414-1956e0c20629")
			};
		}

		protected virtual EntitySchemaColumn CreateIsActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("f08e1ecc-dc92-474c-87e9-3386c0dd685c"),
				Name = @"IsActive",
				CreatedInSchemaUId = new Guid("87d7834d-e6fb-449f-a1bd-dbb57679ad87"),
				ModifiedInSchemaUId = new Guid("87d7834d-e6fb-449f-a1bd-dbb57679ad87"),
				CreatedInPackageId = new Guid("120fd877-7905-4e7f-9414-1956e0c20629")
			};
		}

		protected virtual EntitySchemaColumn CreateIsDeletedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("e5d64707-88bb-4c9b-baed-c0fc22d918b4"),
				Name = @"IsDeleted",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("87d7834d-e6fb-449f-a1bd-dbb57679ad87"),
				ModifiedInSchemaUId = new Guid("87d7834d-e6fb-449f-a1bd-dbb57679ad87"),
				CreatedInPackageId = new Guid("120fd877-7905-4e7f-9414-1956e0c20629")
			};
		}

		protected virtual EntitySchemaColumn CreateProjectColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("eb8ffd47-256d-427f-8467-d6f0fc67f5a2"),
				Name = @"Project",
				ReferenceSchemaUId = new Guid("fefe317f-6cf8-48fa-8073-3dfc0a20bf3f"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("87d7834d-e6fb-449f-a1bd-dbb57679ad87"),
				ModifiedInSchemaUId = new Guid("87d7834d-e6fb-449f-a1bd-dbb57679ad87"),
				CreatedInPackageId = new Guid("120fd877-7905-4e7f-9414-1956e0c20629")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new TrackingResource(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new TrackingResource_TrackingEventsProcess(userConnection);
		}

		public override object Clone() {
			return new TrackingResourceSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new TrackingResourceSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("87d7834d-e6fb-449f-a1bd-dbb57679ad87"));
		}

		#endregion

	}

	#endregion

	#region Class: TrackingResource

	/// <summary>
	/// TrackingResource.
	/// </summary>
	public class TrackingResource : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public TrackingResource(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "TrackingResource";
		}

		public TrackingResource(TrackingResource source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Название.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Источника ресурса.
		/// </summary>
		public string Source {
			get {
				return GetTypedColumnValue<string>("Source");
			}
			set {
				SetColumnValue("Source", value);
			}
		}

		/// <summary>
		/// Активный.
		/// </summary>
		public bool IsActive {
			get {
				return GetTypedColumnValue<bool>("IsActive");
			}
			set {
				SetColumnValue("IsActive", value);
			}
		}

		/// <summary>
		/// Удаленный.
		/// </summary>
		public bool IsDeleted {
			get {
				return GetTypedColumnValue<bool>("IsDeleted");
			}
			set {
				SetColumnValue("IsDeleted", value);
			}
		}

		/// <exclude/>
		public Guid ProjectId {
			get {
				return GetTypedColumnValue<Guid>("ProjectId");
			}
			set {
				SetColumnValue("ProjectId", value);
				_project = null;
			}
		}

		/// <exclude/>
		public string ProjectName {
			get {
				return GetTypedColumnValue<string>("ProjectName");
			}
			set {
				SetColumnValue("ProjectName", value);
				if (_project != null) {
					_project.Name = value;
				}
			}
		}

		private TrackingProject _project;
		/// <summary>
		/// Проект.
		/// </summary>
		public TrackingProject Project {
			get {
				return _project ??
					(_project = LookupColumnEntities.GetEntity("Project") as TrackingProject);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new TrackingResource_TrackingEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Inserted += (s, e) => ThrowEvent("TrackingResourceInserted", e);
			Inserting += (s, e) => ThrowEvent("TrackingResourceInserting", e);
			Updated += (s, e) => ThrowEvent("TrackingResourceUpdated", e);
			Updating += (s, e) => ThrowEvent("TrackingResourceUpdating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new TrackingResource(this);
		}

		#endregion

	}

	#endregion

	#region Class: TrackingResource_TrackingEventsProcess

	/// <exclude/>
	public partial class TrackingResource_TrackingEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : TrackingResource
	{

		public TrackingResource_TrackingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "TrackingResource_TrackingEventsProcess";
			SchemaUId = new Guid("87d7834d-e6fb-449f-a1bd-dbb57679ad87");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("87d7834d-e6fb-449f-a1bd-dbb57679ad87");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _eventSubProcess3_088e3f6cd020476d9931adc276713808;
		public ProcessFlowElement EventSubProcess3_088e3f6cd020476d9931adc276713808 {
			get {
				return _eventSubProcess3_088e3f6cd020476d9931adc276713808 ?? (_eventSubProcess3_088e3f6cd020476d9931adc276713808 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess3_088e3f6cd020476d9931adc276713808",
					SchemaElementUId = new Guid("088e3f6c-d020-476d-9931-adc276713808"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessage3_e0436ec117c1494a98e70784deba2bab;
		public ProcessFlowElement StartMessage3_e0436ec117c1494a98e70784deba2bab {
			get {
				return _startMessage3_e0436ec117c1494a98e70784deba2bab ?? (_startMessage3_e0436ec117c1494a98e70784deba2bab = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage3_e0436ec117c1494a98e70784deba2bab",
					SchemaElementUId = new Guid("e0436ec1-17c1-494a-98e7-0784deba2bab"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask3_2ffeae273d9641feb31fcbbf891953ff;
		public ProcessScriptTask ScriptTask3_2ffeae273d9641feb31fcbbf891953ff {
			get {
				return _scriptTask3_2ffeae273d9641feb31fcbbf891953ff ?? (_scriptTask3_2ffeae273d9641feb31fcbbf891953ff = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask3_2ffeae273d9641feb31fcbbf891953ff",
					SchemaElementUId = new Guid("2ffeae27-3d96-41fe-b31f-cbbf891953ff"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask3_2ffeae273d9641feb31fcbbf891953ffExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess4_2f9aa0b93de741bfbdb0d473d24f4756;
		public ProcessFlowElement EventSubProcess4_2f9aa0b93de741bfbdb0d473d24f4756 {
			get {
				return _eventSubProcess4_2f9aa0b93de741bfbdb0d473d24f4756 ?? (_eventSubProcess4_2f9aa0b93de741bfbdb0d473d24f4756 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess4_2f9aa0b93de741bfbdb0d473d24f4756",
					SchemaElementUId = new Guid("2f9aa0b9-3de7-41bf-bdb0-d473d24f4756"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessage4_a843f79b8adb47df92b04bf3534770e0;
		public ProcessFlowElement StartMessage4_a843f79b8adb47df92b04bf3534770e0 {
			get {
				return _startMessage4_a843f79b8adb47df92b04bf3534770e0 ?? (_startMessage4_a843f79b8adb47df92b04bf3534770e0 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage4_a843f79b8adb47df92b04bf3534770e0",
					SchemaElementUId = new Guid("a843f79b-8adb-47df-92b0-4bf3534770e0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask4_8af3daa5c3734aaa8b713e52197e4dfc;
		public ProcessScriptTask ScriptTask4_8af3daa5c3734aaa8b713e52197e4dfc {
			get {
				return _scriptTask4_8af3daa5c3734aaa8b713e52197e4dfc ?? (_scriptTask4_8af3daa5c3734aaa8b713e52197e4dfc = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask4_8af3daa5c3734aaa8b713e52197e4dfc",
					SchemaElementUId = new Guid("8af3daa5-c373-4aaa-8b71-3e52197e4dfc"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask4_8af3daa5c3734aaa8b713e52197e4dfcExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess5_5fc4e9e4d47f4f408033073596b73fab;
		public ProcessFlowElement EventSubProcess5_5fc4e9e4d47f4f408033073596b73fab {
			get {
				return _eventSubProcess5_5fc4e9e4d47f4f408033073596b73fab ?? (_eventSubProcess5_5fc4e9e4d47f4f408033073596b73fab = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess5_5fc4e9e4d47f4f408033073596b73fab",
					SchemaElementUId = new Guid("5fc4e9e4-d47f-4f40-8033-073596b73fab"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask5_7a41a19adf5f4711bb10f4af3ba14b00;
		public ProcessScriptTask ScriptTask5_7a41a19adf5f4711bb10f4af3ba14b00 {
			get {
				return _scriptTask5_7a41a19adf5f4711bb10f4af3ba14b00 ?? (_scriptTask5_7a41a19adf5f4711bb10f4af3ba14b00 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask5_7a41a19adf5f4711bb10f4af3ba14b00",
					SchemaElementUId = new Guid("7a41a19a-df5f-4711-bb10-f4af3ba14b00"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask5_7a41a19adf5f4711bb10f4af3ba14b00Execute,
				});
			}
		}

		private ProcessFlowElement _startMessage5_4721d7d44811463aaf2818e52a89983e;
		public ProcessFlowElement StartMessage5_4721d7d44811463aaf2818e52a89983e {
			get {
				return _startMessage5_4721d7d44811463aaf2818e52a89983e ?? (_startMessage5_4721d7d44811463aaf2818e52a89983e = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage5_4721d7d44811463aaf2818e52a89983e",
					SchemaElementUId = new Guid("4721d7d4-4811-463a-af28-18e52a89983e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess6_28f0168aa5174974be74905ce4adbaba;
		public ProcessFlowElement EventSubProcess6_28f0168aa5174974be74905ce4adbaba {
			get {
				return _eventSubProcess6_28f0168aa5174974be74905ce4adbaba ?? (_eventSubProcess6_28f0168aa5174974be74905ce4adbaba = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess6_28f0168aa5174974be74905ce4adbaba",
					SchemaElementUId = new Guid("28f0168a-a517-4974-be74-905ce4adbaba"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessage6_48c798eb9cae4333b2e5e4eada370272;
		public ProcessFlowElement StartMessage6_48c798eb9cae4333b2e5e4eada370272 {
			get {
				return _startMessage6_48c798eb9cae4333b2e5e4eada370272 ?? (_startMessage6_48c798eb9cae4333b2e5e4eada370272 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage6_48c798eb9cae4333b2e5e4eada370272",
					SchemaElementUId = new Guid("48c798eb-9cae-4333-b2e5-e4eada370272"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask6_70e978de45c44feb8f44001773fb36f6;
		public ProcessScriptTask ScriptTask6_70e978de45c44feb8f44001773fb36f6 {
			get {
				return _scriptTask6_70e978de45c44feb8f44001773fb36f6 ?? (_scriptTask6_70e978de45c44feb8f44001773fb36f6 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask6_70e978de45c44feb8f44001773fb36f6",
					SchemaElementUId = new Guid("70e978de-45c4-4feb-8f44-001773fb36f6"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask6_70e978de45c44feb8f44001773fb36f6Execute,
				});
			}
		}

		private LocalizableString _dataSyncErrorMessage;
		public LocalizableString DataSyncErrorMessage {
			get {
				return _dataSyncErrorMessage ?? (_dataSyncErrorMessage = new LocalizableString(Storage, Schema.GetResourceManagerName(), "EventsProcessSchema.LocalizableStrings.DataSyncErrorMessage.Value"));
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess3_088e3f6cd020476d9931adc276713808.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess3_088e3f6cd020476d9931adc276713808 };
			FlowElements[StartMessage3_e0436ec117c1494a98e70784deba2bab.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage3_e0436ec117c1494a98e70784deba2bab };
			FlowElements[ScriptTask3_2ffeae273d9641feb31fcbbf891953ff.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask3_2ffeae273d9641feb31fcbbf891953ff };
			FlowElements[EventSubProcess4_2f9aa0b93de741bfbdb0d473d24f4756.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess4_2f9aa0b93de741bfbdb0d473d24f4756 };
			FlowElements[StartMessage4_a843f79b8adb47df92b04bf3534770e0.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage4_a843f79b8adb47df92b04bf3534770e0 };
			FlowElements[ScriptTask4_8af3daa5c3734aaa8b713e52197e4dfc.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask4_8af3daa5c3734aaa8b713e52197e4dfc };
			FlowElements[EventSubProcess5_5fc4e9e4d47f4f408033073596b73fab.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess5_5fc4e9e4d47f4f408033073596b73fab };
			FlowElements[ScriptTask5_7a41a19adf5f4711bb10f4af3ba14b00.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask5_7a41a19adf5f4711bb10f4af3ba14b00 };
			FlowElements[StartMessage5_4721d7d44811463aaf2818e52a89983e.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage5_4721d7d44811463aaf2818e52a89983e };
			FlowElements[EventSubProcess6_28f0168aa5174974be74905ce4adbaba.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess6_28f0168aa5174974be74905ce4adbaba };
			FlowElements[StartMessage6_48c798eb9cae4333b2e5e4eada370272.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage6_48c798eb9cae4333b2e5e4eada370272 };
			FlowElements[ScriptTask6_70e978de45c44feb8f44001773fb36f6.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask6_70e978de45c44feb8f44001773fb36f6 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess3_088e3f6cd020476d9931adc276713808":
						break;
					case "StartMessage3_e0436ec117c1494a98e70784deba2bab":
						e.Context.QueueTasks.Enqueue("ScriptTask3_2ffeae273d9641feb31fcbbf891953ff");
						break;
					case "ScriptTask3_2ffeae273d9641feb31fcbbf891953ff":
						break;
					case "EventSubProcess4_2f9aa0b93de741bfbdb0d473d24f4756":
						break;
					case "StartMessage4_a843f79b8adb47df92b04bf3534770e0":
						e.Context.QueueTasks.Enqueue("ScriptTask4_8af3daa5c3734aaa8b713e52197e4dfc");
						break;
					case "ScriptTask4_8af3daa5c3734aaa8b713e52197e4dfc":
						break;
					case "EventSubProcess5_5fc4e9e4d47f4f408033073596b73fab":
						break;
					case "ScriptTask5_7a41a19adf5f4711bb10f4af3ba14b00":
						break;
					case "StartMessage5_4721d7d44811463aaf2818e52a89983e":
						e.Context.QueueTasks.Enqueue("ScriptTask5_7a41a19adf5f4711bb10f4af3ba14b00");
						break;
					case "EventSubProcess6_28f0168aa5174974be74905ce4adbaba":
						break;
					case "StartMessage6_48c798eb9cae4333b2e5e4eada370272":
						e.Context.QueueTasks.Enqueue("ScriptTask6_70e978de45c44feb8f44001773fb36f6");
						break;
					case "ScriptTask6_70e978de45c44feb8f44001773fb36f6":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("StartMessage3_e0436ec117c1494a98e70784deba2bab");
			ActivatedEventElements.Add("StartMessage4_a843f79b8adb47df92b04bf3534770e0");
			ActivatedEventElements.Add("StartMessage5_4721d7d44811463aaf2818e52a89983e");
			ActivatedEventElements.Add("StartMessage6_48c798eb9cae4333b2e5e4eada370272");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess3_088e3f6cd020476d9931adc276713808":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessage3_e0436ec117c1494a98e70784deba2bab":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage3_e0436ec117c1494a98e70784deba2bab";
					result = StartMessage3_e0436ec117c1494a98e70784deba2bab.Execute(context);
					break;
				case "ScriptTask3_2ffeae273d9641feb31fcbbf891953ff":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask3_2ffeae273d9641feb31fcbbf891953ff";
					result = ScriptTask3_2ffeae273d9641feb31fcbbf891953ff.Execute(context, ScriptTask3_2ffeae273d9641feb31fcbbf891953ffExecute);
					break;
				case "EventSubProcess4_2f9aa0b93de741bfbdb0d473d24f4756":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessage4_a843f79b8adb47df92b04bf3534770e0":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage4_a843f79b8adb47df92b04bf3534770e0";
					result = StartMessage4_a843f79b8adb47df92b04bf3534770e0.Execute(context);
					break;
				case "ScriptTask4_8af3daa5c3734aaa8b713e52197e4dfc":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask4_8af3daa5c3734aaa8b713e52197e4dfc";
					result = ScriptTask4_8af3daa5c3734aaa8b713e52197e4dfc.Execute(context, ScriptTask4_8af3daa5c3734aaa8b713e52197e4dfcExecute);
					break;
				case "EventSubProcess5_5fc4e9e4d47f4f408033073596b73fab":
					context.QueueTasks.Dequeue();
					break;
				case "ScriptTask5_7a41a19adf5f4711bb10f4af3ba14b00":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask5_7a41a19adf5f4711bb10f4af3ba14b00";
					result = ScriptTask5_7a41a19adf5f4711bb10f4af3ba14b00.Execute(context, ScriptTask5_7a41a19adf5f4711bb10f4af3ba14b00Execute);
					break;
				case "StartMessage5_4721d7d44811463aaf2818e52a89983e":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage5_4721d7d44811463aaf2818e52a89983e";
					result = StartMessage5_4721d7d44811463aaf2818e52a89983e.Execute(context);
					break;
				case "EventSubProcess6_28f0168aa5174974be74905ce4adbaba":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessage6_48c798eb9cae4333b2e5e4eada370272":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage6_48c798eb9cae4333b2e5e4eada370272";
					result = StartMessage6_48c798eb9cae4333b2e5e4eada370272.Execute(context);
					break;
				case "ScriptTask6_70e978de45c44feb8f44001773fb36f6":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask6_70e978de45c44feb8f44001773fb36f6";
					result = ScriptTask6_70e978de45c44feb8f44001773fb36f6.Execute(context, ScriptTask6_70e978de45c44feb8f44001773fb36f6Execute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptTask3_2ffeae273d9641feb31fcbbf891953ffExecute(ProcessExecutingContext context) {
			InsertResourceToCloudTenantService();
			return true;
		}

		public virtual bool ScriptTask4_8af3daa5c3734aaa8b713e52197e4dfcExecute(ProcessExecutingContext context) {
			UpdateResource();
			return true;
		}

		public virtual bool ScriptTask5_7a41a19adf5f4711bb10f4af3ba14b00Execute(ProcessExecutingContext context) {
			BeforeUpdateResource();
			return true;
		}

		public virtual bool ScriptTask6_70e978de45c44feb8f44001773fb36f6Execute(ProcessExecutingContext context) {
			BeforeInsertResource();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "TrackingResourceInserted":
							if (ActivatedEventElements.Contains("StartMessage3_e0436ec117c1494a98e70784deba2bab")) {
							context.QueueTasks.Enqueue("StartMessage3_e0436ec117c1494a98e70784deba2bab");
						}
						break;
					case "TrackingResourceUpdated":
							if (ActivatedEventElements.Contains("StartMessage4_a843f79b8adb47df92b04bf3534770e0")) {
							context.QueueTasks.Enqueue("StartMessage4_a843f79b8adb47df92b04bf3534770e0");
						}
						break;
					case "TrackingResourceUpdating":
							if (ActivatedEventElements.Contains("StartMessage5_4721d7d44811463aaf2818e52a89983e")) {
							context.QueueTasks.Enqueue("StartMessage5_4721d7d44811463aaf2818e52a89983e");
						}
						break;
					case "TrackingResourceInserting":
							if (ActivatedEventElements.Contains("StartMessage6_48c798eb9cae4333b2e5e4eada370272")) {
							context.QueueTasks.Enqueue("StartMessage6_48c798eb9cae4333b2e5e4eada370272");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: TrackingResource_TrackingEventsProcess

	/// <exclude/>
	public class TrackingResource_TrackingEventsProcess : TrackingResource_TrackingEventsProcess<TrackingResource>
	{

		public TrackingResource_TrackingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion


	#region Class: TrackingResourceEventsProcess

	/// <exclude/>
	public class TrackingResourceEventsProcess : TrackingResource_TrackingEventsProcess
	{

		public TrackingResourceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

