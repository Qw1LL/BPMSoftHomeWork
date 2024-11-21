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

	#region Class: TrackingProjectSchema

	/// <exclude/>
	public class TrackingProjectSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public TrackingProjectSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public TrackingProjectSchema(TrackingProjectSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public TrackingProjectSchema(TrackingProjectSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fefe317f-6cf8-48fa-8073-3dfc0a20bf3f");
			RealUId = new Guid("fefe317f-6cf8-48fa-8073-3dfc0a20bf3f");
			Name = "TrackingProject";
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

		protected override void InitializeOwnerColumn() {
			base.InitializeOwnerColumn();
			OwnerColumn = CreateOwnerColumn();
			if (Columns.FindByUId(OwnerColumn.UId) == null) {
				Columns.Add(OwnerColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("06236b5f-f2c9-4c9a-9759-4b088aa04243")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("02287166-3c2e-4bed-8077-54d2ad580284")) == null) {
				Columns.Add(CreateIsDeletedColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("2d0f5b7e-cbd2-40e0-bbf5-a67c1e8ad8c3"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("fefe317f-6cf8-48fa-8073-3dfc0a20bf3f"),
				ModifiedInSchemaUId = new Guid("fefe317f-6cf8-48fa-8073-3dfc0a20bf3f"),
				CreatedInPackageId = new Guid("120fd877-7905-4e7f-9414-1956e0c20629")
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("06236b5f-f2c9-4c9a-9759-4b088aa04243"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("fefe317f-6cf8-48fa-8073-3dfc0a20bf3f"),
				ModifiedInSchemaUId = new Guid("fefe317f-6cf8-48fa-8073-3dfc0a20bf3f"),
				CreatedInPackageId = new Guid("120fd877-7905-4e7f-9414-1956e0c20629")
			};
		}

		protected virtual EntitySchemaColumn CreateOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("435fb340-8a96-49b5-bf4b-76d9b5eaee8a"),
				Name = @"Owner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("fefe317f-6cf8-48fa-8073-3dfc0a20bf3f"),
				ModifiedInSchemaUId = new Guid("fefe317f-6cf8-48fa-8073-3dfc0a20bf3f"),
				CreatedInPackageId = new Guid("120fd877-7905-4e7f-9414-1956e0c20629")
			};
		}

		protected virtual EntitySchemaColumn CreateIsDeletedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("02287166-3c2e-4bed-8077-54d2ad580284"),
				Name = @"IsDeleted",
				CreatedInSchemaUId = new Guid("fefe317f-6cf8-48fa-8073-3dfc0a20bf3f"),
				ModifiedInSchemaUId = new Guid("fefe317f-6cf8-48fa-8073-3dfc0a20bf3f"),
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
			return new TrackingProject(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new TrackingProject_TrackingEventsProcess(userConnection);
		}

		public override object Clone() {
			return new TrackingProjectSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new TrackingProjectSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fefe317f-6cf8-48fa-8073-3dfc0a20bf3f"));
		}

		#endregion

	}

	#endregion

	#region Class: TrackingProject

	/// <summary>
	/// Проект трекинга.
	/// </summary>
	public class TrackingProject : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public TrackingProject(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "TrackingProject";
		}

		public TrackingProject(TrackingProject source)
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
		/// Описание.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		/// <exclude/>
		public Guid OwnerId {
			get {
				return GetTypedColumnValue<Guid>("OwnerId");
			}
			set {
				SetColumnValue("OwnerId", value);
				_owner = null;
			}
		}

		/// <exclude/>
		public string OwnerName {
			get {
				return GetTypedColumnValue<string>("OwnerName");
			}
			set {
				SetColumnValue("OwnerName", value);
				if (_owner != null) {
					_owner.Name = value;
				}
			}
		}

		private Contact _owner;
		/// <summary>
		/// Ответственный.
		/// </summary>
		public Contact Owner {
			get {
				return _owner ??
					(_owner = LookupColumnEntities.GetEntity("Owner") as Contact);
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new TrackingProject_TrackingEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Inserted += (s, e) => ThrowEvent("TrackingProjectInserted", e);
			Inserting += (s, e) => ThrowEvent("TrackingProjectInserting", e);
			Updated += (s, e) => ThrowEvent("TrackingProjectUpdated", e);
			Updating += (s, e) => ThrowEvent("TrackingProjectUpdating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new TrackingProject(this);
		}

		#endregion

	}

	#endregion

	#region Class: TrackingProject_TrackingEventsProcess

	/// <exclude/>
	public partial class TrackingProject_TrackingEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : TrackingProject
	{

		public TrackingProject_TrackingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "TrackingProject_TrackingEventsProcess";
			SchemaUId = new Guid("fefe317f-6cf8-48fa-8073-3dfc0a20bf3f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("fefe317f-6cf8-48fa-8073-3dfc0a20bf3f");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _eventSubProcess3_e0d27a0181154b26ad053267e21f7cb7;
		public ProcessFlowElement EventSubProcess3_e0d27a0181154b26ad053267e21f7cb7 {
			get {
				return _eventSubProcess3_e0d27a0181154b26ad053267e21f7cb7 ?? (_eventSubProcess3_e0d27a0181154b26ad053267e21f7cb7 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess3_e0d27a0181154b26ad053267e21f7cb7",
					SchemaElementUId = new Guid("e0d27a01-8115-4b26-ad05-3267e21f7cb7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessage3_5c447a5d60814ae587b8c7889062866c;
		public ProcessFlowElement StartMessage3_5c447a5d60814ae587b8c7889062866c {
			get {
				return _startMessage3_5c447a5d60814ae587b8c7889062866c ?? (_startMessage3_5c447a5d60814ae587b8c7889062866c = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage3_5c447a5d60814ae587b8c7889062866c",
					SchemaElementUId = new Guid("5c447a5d-6081-4ae5-87b8-c7889062866c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask3_79dba1c675cc48a58941f39c76d031f6;
		public ProcessScriptTask ScriptTask3_79dba1c675cc48a58941f39c76d031f6 {
			get {
				return _scriptTask3_79dba1c675cc48a58941f39c76d031f6 ?? (_scriptTask3_79dba1c675cc48a58941f39c76d031f6 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask3_79dba1c675cc48a58941f39c76d031f6",
					SchemaElementUId = new Guid("79dba1c6-75cc-48a5-8941-f39c76d031f6"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask3_79dba1c675cc48a58941f39c76d031f6Execute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess4_e3e45202bc484428b32f3653cee68928;
		public ProcessFlowElement EventSubProcess4_e3e45202bc484428b32f3653cee68928 {
			get {
				return _eventSubProcess4_e3e45202bc484428b32f3653cee68928 ?? (_eventSubProcess4_e3e45202bc484428b32f3653cee68928 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess4_e3e45202bc484428b32f3653cee68928",
					SchemaElementUId = new Guid("e3e45202-bc48-4428-b32f-3653cee68928"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessage4_6533d3cd06224f1682ceebfcd34a3119;
		public ProcessFlowElement StartMessage4_6533d3cd06224f1682ceebfcd34a3119 {
			get {
				return _startMessage4_6533d3cd06224f1682ceebfcd34a3119 ?? (_startMessage4_6533d3cd06224f1682ceebfcd34a3119 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage4_6533d3cd06224f1682ceebfcd34a3119",
					SchemaElementUId = new Guid("6533d3cd-0622-4f16-82ce-ebfcd34a3119"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask4_ad1cfaad8be74f0abc0edb97b8aac8ea;
		public ProcessScriptTask ScriptTask4_ad1cfaad8be74f0abc0edb97b8aac8ea {
			get {
				return _scriptTask4_ad1cfaad8be74f0abc0edb97b8aac8ea ?? (_scriptTask4_ad1cfaad8be74f0abc0edb97b8aac8ea = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask4_ad1cfaad8be74f0abc0edb97b8aac8ea",
					SchemaElementUId = new Guid("ad1cfaad-8be7-4f0a-bc0e-db97b8aac8ea"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask4_ad1cfaad8be74f0abc0edb97b8aac8eaExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess5_be4e19644ba1448982743c8d638c6feb;
		public ProcessFlowElement EventSubProcess5_be4e19644ba1448982743c8d638c6feb {
			get {
				return _eventSubProcess5_be4e19644ba1448982743c8d638c6feb ?? (_eventSubProcess5_be4e19644ba1448982743c8d638c6feb = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess5_be4e19644ba1448982743c8d638c6feb",
					SchemaElementUId = new Guid("be4e1964-4ba1-4489-8274-3c8d638c6feb"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessage5_ee2f8e66cfc6482a93dbc249b9a5bd56;
		public ProcessFlowElement StartMessage5_ee2f8e66cfc6482a93dbc249b9a5bd56 {
			get {
				return _startMessage5_ee2f8e66cfc6482a93dbc249b9a5bd56 ?? (_startMessage5_ee2f8e66cfc6482a93dbc249b9a5bd56 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage5_ee2f8e66cfc6482a93dbc249b9a5bd56",
					SchemaElementUId = new Guid("ee2f8e66-cfc6-482a-93db-c249b9a5bd56"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask5_71eba656a912481ea2bf2b6943804e96;
		public ProcessScriptTask ScriptTask5_71eba656a912481ea2bf2b6943804e96 {
			get {
				return _scriptTask5_71eba656a912481ea2bf2b6943804e96 ?? (_scriptTask5_71eba656a912481ea2bf2b6943804e96 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask5_71eba656a912481ea2bf2b6943804e96",
					SchemaElementUId = new Guid("71eba656-a912-481e-a2bf-2b6943804e96"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask5_71eba656a912481ea2bf2b6943804e96Execute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess6_24e85033ba3243d1a7cd3cd070534632;
		public ProcessFlowElement EventSubProcess6_24e85033ba3243d1a7cd3cd070534632 {
			get {
				return _eventSubProcess6_24e85033ba3243d1a7cd3cd070534632 ?? (_eventSubProcess6_24e85033ba3243d1a7cd3cd070534632 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess6_24e85033ba3243d1a7cd3cd070534632",
					SchemaElementUId = new Guid("24e85033-ba32-43d1-a7cd-3cd070534632"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessage6_f7b99cde1ab34820bab306111ac8431c;
		public ProcessFlowElement StartMessage6_f7b99cde1ab34820bab306111ac8431c {
			get {
				return _startMessage6_f7b99cde1ab34820bab306111ac8431c ?? (_startMessage6_f7b99cde1ab34820bab306111ac8431c = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage6_f7b99cde1ab34820bab306111ac8431c",
					SchemaElementUId = new Guid("f7b99cde-1ab3-4820-bab3-06111ac8431c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask6_ea162ce6c1634e78a83dc4f02fbb63f0;
		public ProcessScriptTask ScriptTask6_ea162ce6c1634e78a83dc4f02fbb63f0 {
			get {
				return _scriptTask6_ea162ce6c1634e78a83dc4f02fbb63f0 ?? (_scriptTask6_ea162ce6c1634e78a83dc4f02fbb63f0 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask6_ea162ce6c1634e78a83dc4f02fbb63f0",
					SchemaElementUId = new Guid("ea162ce6-c163-4e78-a83d-c4f02fbb63f0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask6_ea162ce6c1634e78a83dc4f02fbb63f0Execute,
				});
			}
		}

		private LocalizableString _dataSyncErrorMessage;
		public LocalizableString DataSyncErrorMessage {
			get {
				return _dataSyncErrorMessage ?? (_dataSyncErrorMessage = new LocalizableString(Storage, Schema.GetResourceManagerName(), "EventsProcessSchema.LocalizableStrings.DataSyncErrorMessage.Value"));
			}
		}

		private LocalizableString _deleteEntityErrorMessage;
		public LocalizableString DeleteEntityErrorMessage {
			get {
				return _deleteEntityErrorMessage ?? (_deleteEntityErrorMessage = new LocalizableString(Storage, Schema.GetResourceManagerName(), "EventsProcessSchema.LocalizableStrings.DeleteEntityErrorMessage.Value"));
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess3_e0d27a0181154b26ad053267e21f7cb7.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess3_e0d27a0181154b26ad053267e21f7cb7 };
			FlowElements[StartMessage3_5c447a5d60814ae587b8c7889062866c.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage3_5c447a5d60814ae587b8c7889062866c };
			FlowElements[ScriptTask3_79dba1c675cc48a58941f39c76d031f6.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask3_79dba1c675cc48a58941f39c76d031f6 };
			FlowElements[EventSubProcess4_e3e45202bc484428b32f3653cee68928.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess4_e3e45202bc484428b32f3653cee68928 };
			FlowElements[StartMessage4_6533d3cd06224f1682ceebfcd34a3119.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage4_6533d3cd06224f1682ceebfcd34a3119 };
			FlowElements[ScriptTask4_ad1cfaad8be74f0abc0edb97b8aac8ea.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask4_ad1cfaad8be74f0abc0edb97b8aac8ea };
			FlowElements[EventSubProcess5_be4e19644ba1448982743c8d638c6feb.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess5_be4e19644ba1448982743c8d638c6feb };
			FlowElements[StartMessage5_ee2f8e66cfc6482a93dbc249b9a5bd56.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage5_ee2f8e66cfc6482a93dbc249b9a5bd56 };
			FlowElements[ScriptTask5_71eba656a912481ea2bf2b6943804e96.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask5_71eba656a912481ea2bf2b6943804e96 };
			FlowElements[EventSubProcess6_24e85033ba3243d1a7cd3cd070534632.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess6_24e85033ba3243d1a7cd3cd070534632 };
			FlowElements[StartMessage6_f7b99cde1ab34820bab306111ac8431c.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage6_f7b99cde1ab34820bab306111ac8431c };
			FlowElements[ScriptTask6_ea162ce6c1634e78a83dc4f02fbb63f0.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask6_ea162ce6c1634e78a83dc4f02fbb63f0 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess3_e0d27a0181154b26ad053267e21f7cb7":
						break;
					case "StartMessage3_5c447a5d60814ae587b8c7889062866c":
						e.Context.QueueTasks.Enqueue("ScriptTask3_79dba1c675cc48a58941f39c76d031f6");
						break;
					case "ScriptTask3_79dba1c675cc48a58941f39c76d031f6":
						break;
					case "EventSubProcess4_e3e45202bc484428b32f3653cee68928":
						break;
					case "StartMessage4_6533d3cd06224f1682ceebfcd34a3119":
						e.Context.QueueTasks.Enqueue("ScriptTask4_ad1cfaad8be74f0abc0edb97b8aac8ea");
						break;
					case "ScriptTask4_ad1cfaad8be74f0abc0edb97b8aac8ea":
						break;
					case "EventSubProcess5_be4e19644ba1448982743c8d638c6feb":
						break;
					case "StartMessage5_ee2f8e66cfc6482a93dbc249b9a5bd56":
						e.Context.QueueTasks.Enqueue("ScriptTask5_71eba656a912481ea2bf2b6943804e96");
						break;
					case "ScriptTask5_71eba656a912481ea2bf2b6943804e96":
						break;
					case "EventSubProcess6_24e85033ba3243d1a7cd3cd070534632":
						break;
					case "StartMessage6_f7b99cde1ab34820bab306111ac8431c":
						e.Context.QueueTasks.Enqueue("ScriptTask6_ea162ce6c1634e78a83dc4f02fbb63f0");
						break;
					case "ScriptTask6_ea162ce6c1634e78a83dc4f02fbb63f0":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("StartMessage3_5c447a5d60814ae587b8c7889062866c");
			ActivatedEventElements.Add("StartMessage4_6533d3cd06224f1682ceebfcd34a3119");
			ActivatedEventElements.Add("StartMessage5_ee2f8e66cfc6482a93dbc249b9a5bd56");
			ActivatedEventElements.Add("StartMessage6_f7b99cde1ab34820bab306111ac8431c");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess3_e0d27a0181154b26ad053267e21f7cb7":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessage3_5c447a5d60814ae587b8c7889062866c":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage3_5c447a5d60814ae587b8c7889062866c";
					result = StartMessage3_5c447a5d60814ae587b8c7889062866c.Execute(context);
					break;
				case "ScriptTask3_79dba1c675cc48a58941f39c76d031f6":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask3_79dba1c675cc48a58941f39c76d031f6";
					result = ScriptTask3_79dba1c675cc48a58941f39c76d031f6.Execute(context, ScriptTask3_79dba1c675cc48a58941f39c76d031f6Execute);
					break;
				case "EventSubProcess4_e3e45202bc484428b32f3653cee68928":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessage4_6533d3cd06224f1682ceebfcd34a3119":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage4_6533d3cd06224f1682ceebfcd34a3119";
					result = StartMessage4_6533d3cd06224f1682ceebfcd34a3119.Execute(context);
					break;
				case "ScriptTask4_ad1cfaad8be74f0abc0edb97b8aac8ea":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask4_ad1cfaad8be74f0abc0edb97b8aac8ea";
					result = ScriptTask4_ad1cfaad8be74f0abc0edb97b8aac8ea.Execute(context, ScriptTask4_ad1cfaad8be74f0abc0edb97b8aac8eaExecute);
					break;
				case "EventSubProcess5_be4e19644ba1448982743c8d638c6feb":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessage5_ee2f8e66cfc6482a93dbc249b9a5bd56":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage5_ee2f8e66cfc6482a93dbc249b9a5bd56";
					result = StartMessage5_ee2f8e66cfc6482a93dbc249b9a5bd56.Execute(context);
					break;
				case "ScriptTask5_71eba656a912481ea2bf2b6943804e96":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask5_71eba656a912481ea2bf2b6943804e96";
					result = ScriptTask5_71eba656a912481ea2bf2b6943804e96.Execute(context, ScriptTask5_71eba656a912481ea2bf2b6943804e96Execute);
					break;
				case "EventSubProcess6_24e85033ba3243d1a7cd3cd070534632":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessage6_f7b99cde1ab34820bab306111ac8431c":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage6_f7b99cde1ab34820bab306111ac8431c";
					result = StartMessage6_f7b99cde1ab34820bab306111ac8431c.Execute(context);
					break;
				case "ScriptTask6_ea162ce6c1634e78a83dc4f02fbb63f0":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask6_ea162ce6c1634e78a83dc4f02fbb63f0";
					result = ScriptTask6_ea162ce6c1634e78a83dc4f02fbb63f0.Execute(context, ScriptTask6_ea162ce6c1634e78a83dc4f02fbb63f0Execute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptTask3_79dba1c675cc48a58941f39c76d031f6Execute(ProcessExecutingContext context) {
			InsertedProjectToCloudTenantService();
			return true;
		}

		public virtual bool ScriptTask4_ad1cfaad8be74f0abc0edb97b8aac8eaExecute(ProcessExecutingContext context) {
			AfterUpdateProject();
			return true;
		}

		public virtual bool ScriptTask5_71eba656a912481ea2bf2b6943804e96Execute(ProcessExecutingContext context) {
			BeforeUpdateProject();
			return true;
		}

		public virtual bool ScriptTask6_ea162ce6c1634e78a83dc4f02fbb63f0Execute(ProcessExecutingContext context) {
			BeforeInsertProject();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "TrackingProjectInserted":
							if (ActivatedEventElements.Contains("StartMessage3_5c447a5d60814ae587b8c7889062866c")) {
							context.QueueTasks.Enqueue("StartMessage3_5c447a5d60814ae587b8c7889062866c");
						}
						break;
					case "TrackingProjectUpdated":
							if (ActivatedEventElements.Contains("StartMessage4_6533d3cd06224f1682ceebfcd34a3119")) {
							context.QueueTasks.Enqueue("StartMessage4_6533d3cd06224f1682ceebfcd34a3119");
						}
						break;
					case "TrackingProjectUpdating":
							if (ActivatedEventElements.Contains("StartMessage5_ee2f8e66cfc6482a93dbc249b9a5bd56")) {
							context.QueueTasks.Enqueue("StartMessage5_ee2f8e66cfc6482a93dbc249b9a5bd56");
						}
						break;
					case "TrackingProjectInserting":
							if (ActivatedEventElements.Contains("StartMessage6_f7b99cde1ab34820bab306111ac8431c")) {
							context.QueueTasks.Enqueue("StartMessage6_f7b99cde1ab34820bab306111ac8431c");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: TrackingProject_TrackingEventsProcess

	/// <exclude/>
	public class TrackingProject_TrackingEventsProcess : TrackingProject_TrackingEventsProcess<TrackingProject>
	{

		public TrackingProject_TrackingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion


	#region Class: TrackingProjectEventsProcess

	/// <exclude/>
	public class TrackingProjectEventsProcess : TrackingProject_TrackingEventsProcess
	{

		public TrackingProjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

