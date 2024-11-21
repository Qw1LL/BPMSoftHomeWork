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

	#region Class: SysModuleInSysModuleFolderSchema

	/// <exclude/>
	public class SysModuleInSysModuleFolderSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysModuleInSysModuleFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysModuleInSysModuleFolderSchema(SysModuleInSysModuleFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysModuleInSysModuleFolderSchema(SysModuleInSysModuleFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("23960511-3f42-47e5-9f69-1550f0f637e9");
			RealUId = new Guid("23960511-3f42-47e5-9f69-1550f0f637e9");
			Name = "SysModuleInSysModuleFolder";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("398c17c3-5f0d-4bfd-bace-e54e45b93b1d")) == null) {
				Columns.Add(CreateSysModuleColumn());
			}
			if (Columns.FindByUId(new Guid("04fe38fc-1cef-455a-924f-9274a5091aab")) == null) {
				Columns.Add(CreateSubSysModuleFolderColumn());
			}
			if (Columns.FindByUId(new Guid("08b75e4a-c487-41e7-8c43-0d6f4026d9a1")) == null) {
				Columns.Add(CreateSysModuleFolderColumn());
			}
			if (Columns.FindByUId(new Guid("8b924055-9d6a-4149-9519-ce5f5735a88e")) == null) {
				Columns.Add(CreatePositionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysModuleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("398c17c3-5f0d-4bfd-bace-e54e45b93b1d"),
				Name = @"SysModule",
				ReferenceSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("23960511-3f42-47e5-9f69-1550f0f637e9"),
				ModifiedInSchemaUId = new Guid("23960511-3f42-47e5-9f69-1550f0f637e9"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSubSysModuleFolderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("04fe38fc-1cef-455a-924f-9274a5091aab"),
				Name = @"SubSysModuleFolder",
				ReferenceSchemaUId = new Guid("88fa8985-5bbd-4975-95b1-51caec10987a"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("23960511-3f42-47e5-9f69-1550f0f637e9"),
				ModifiedInSchemaUId = new Guid("23960511-3f42-47e5-9f69-1550f0f637e9"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysModuleFolderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("08b75e4a-c487-41e7-8c43-0d6f4026d9a1"),
				Name = @"SysModuleFolder",
				ReferenceSchemaUId = new Guid("88fa8985-5bbd-4975-95b1-51caec10987a"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("23960511-3f42-47e5-9f69-1550f0f637e9"),
				ModifiedInSchemaUId = new Guid("23960511-3f42-47e5-9f69-1550f0f637e9"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("8b924055-9d6a-4149-9519-ce5f5735a88e"),
				Name = @"Position",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("23960511-3f42-47e5-9f69-1550f0f637e9"),
				ModifiedInSchemaUId = new Guid("23960511-3f42-47e5-9f69-1550f0f637e9"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysModuleInSysModuleFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysModuleInSysModuleFolder_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysModuleInSysModuleFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysModuleInSysModuleFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("23960511-3f42-47e5-9f69-1550f0f637e9"));
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleInSysModuleFolder

	/// <summary>
	/// Section in SysModule folder.
	/// </summary>
	public class SysModuleInSysModuleFolder : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysModuleInSysModuleFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysModuleInSysModuleFolder";
		}

		public SysModuleInSysModuleFolder(SysModuleInSysModuleFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysModuleId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleId");
			}
			set {
				SetColumnValue("SysModuleId", value);
				_sysModule = null;
			}
		}

		/// <exclude/>
		public string SysModuleCaption {
			get {
				return GetTypedColumnValue<string>("SysModuleCaption");
			}
			set {
				SetColumnValue("SysModuleCaption", value);
				if (_sysModule != null) {
					_sysModule.Caption = value;
				}
			}
		}

		private SysModule _sysModule;
		/// <summary>
		/// Section.
		/// </summary>
		public SysModule SysModule {
			get {
				return _sysModule ??
					(_sysModule = LookupColumnEntities.GetEntity("SysModule") as SysModule);
			}
		}

		/// <exclude/>
		public Guid SubSysModuleFolderId {
			get {
				return GetTypedColumnValue<Guid>("SubSysModuleFolderId");
			}
			set {
				SetColumnValue("SubSysModuleFolderId", value);
				_subSysModuleFolder = null;
			}
		}

		/// <exclude/>
		public string SubSysModuleFolderCaption {
			get {
				return GetTypedColumnValue<string>("SubSysModuleFolderCaption");
			}
			set {
				SetColumnValue("SubSysModuleFolderCaption", value);
				if (_subSysModuleFolder != null) {
					_subSysModuleFolder.Caption = value;
				}
			}
		}

		private SysModuleFolder _subSysModuleFolder;
		/// <summary>
		/// Subordinate workplace.
		/// </summary>
		public SysModuleFolder SubSysModuleFolder {
			get {
				return _subSysModuleFolder ??
					(_subSysModuleFolder = LookupColumnEntities.GetEntity("SubSysModuleFolder") as SysModuleFolder);
			}
		}

		/// <exclude/>
		public Guid SysModuleFolderId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleFolderId");
			}
			set {
				SetColumnValue("SysModuleFolderId", value);
				_sysModuleFolder = null;
			}
		}

		/// <exclude/>
		public string SysModuleFolderCaption {
			get {
				return GetTypedColumnValue<string>("SysModuleFolderCaption");
			}
			set {
				SetColumnValue("SysModuleFolderCaption", value);
				if (_sysModuleFolder != null) {
					_sysModuleFolder.Caption = value;
				}
			}
		}

		private SysModuleFolder _sysModuleFolder;
		/// <summary>
		/// Workplace.
		/// </summary>
		public SysModuleFolder SysModuleFolder {
			get {
				return _sysModuleFolder ??
					(_sysModuleFolder = LookupColumnEntities.GetEntity("SysModuleFolder") as SysModuleFolder);
			}
		}

		/// <summary>
		/// Position.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysModuleInSysModuleFolder_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysModuleInSysModuleFolderDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysModuleInSysModuleFolderDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysModuleInSysModuleFolderInserted", e);
			Inserting += (s, e) => ThrowEvent("SysModuleInSysModuleFolderInserting", e);
			Saved += (s, e) => ThrowEvent("SysModuleInSysModuleFolderSaved", e);
			Saving += (s, e) => ThrowEvent("SysModuleInSysModuleFolderSaving", e);
			Validating += (s, e) => ThrowEvent("SysModuleInSysModuleFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysModuleInSysModuleFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleInSysModuleFolder_BaseEventsProcess

	/// <exclude/>
	public partial class SysModuleInSysModuleFolder_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysModuleInSysModuleFolder
	{

		public SysModuleInSysModuleFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysModuleInSysModuleFolder_BaseEventsProcess";
			SchemaUId = new Guid("23960511-3f42-47e5-9f69-1550f0f637e9");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("23960511-3f42-47e5-9f69-1550f0f637e9");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual bool IsLastRecord {
			get;
			set;
		}

		private ProcessFlowElement _eventAfterDelete;
		public ProcessFlowElement EventAfterDelete {
			get {
				return _eventAfterDelete ?? (_eventAfterDelete = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventAfterDelete",
					SchemaElementUId = new Guid("6a44a6ba-6288-4e9c-91f9-e95e7db61721"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessageAfterDelete;
		public ProcessFlowElement StartMessageAfterDelete {
			get {
				return _startMessageAfterDelete ?? (_startMessageAfterDelete = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessageAfterDelete",
					SchemaElementUId = new Guid("bddf7a50-090b-4993-b488-8033729b3ce1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTaskCheckLastRecord;
		public ProcessScriptTask ScriptTaskCheckLastRecord {
			get {
				return _scriptTaskCheckLastRecord ?? (_scriptTaskCheckLastRecord = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTaskCheckLastRecord",
					SchemaElementUId = new Guid("f7760a60-a7c2-4ccc-8457-076e04859034"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTaskCheckLastRecordExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventAfterDelete.SchemaElementUId] = new Collection<ProcessFlowElement> { EventAfterDelete };
			FlowElements[StartMessageAfterDelete.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessageAfterDelete };
			FlowElements[ScriptTaskCheckLastRecord.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTaskCheckLastRecord };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventAfterDelete":
						break;
					case "StartMessageAfterDelete":
						e.Context.QueueTasks.Enqueue("ScriptTaskCheckLastRecord");
						break;
					case "ScriptTaskCheckLastRecord":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("StartMessageAfterDelete");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventAfterDelete":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessageAfterDelete":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessageAfterDelete";
					result = StartMessageAfterDelete.Execute(context);
					break;
				case "ScriptTaskCheckLastRecord":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTaskCheckLastRecord";
					result = ScriptTaskCheckLastRecord.Execute(context, ScriptTaskCheckLastRecordExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptTaskCheckLastRecordExecute(ProcessExecutingContext context) {
			var recordTableESQ = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysModuleInSysModuleFolder");
			recordTableESQ.AddColumn(recordTableESQ.RootSchema.GetPrimaryColumnName());
			recordTableESQ.AddColumn("SysModule");
			recordTableESQ.Filters.Add(recordTableESQ.CreateFilterWithParameters(FilterComparisonType.Equal, "SysModule", Entity.GetTypedColumnValue<string>("SysModuleId")));
			var recordEntity = recordTableESQ.GetEntityCollection(UserConnection);
			if (recordEntity.Count < 1) {
				UserConnection.EntitySchemaManager.GetInstanceByName("SysModule")
					.CreateEntity(UserConnection).Delete(Entity.GetTypedColumnValue<Guid>("SysModuleId"));
			}
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "SysModuleInSysModuleFolderDeleted":
							if (ActivatedEventElements.Contains("StartMessageAfterDelete")) {
							context.QueueTasks.Enqueue("StartMessageAfterDelete");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleInSysModuleFolder_BaseEventsProcess

	/// <exclude/>
	public class SysModuleInSysModuleFolder_BaseEventsProcess : SysModuleInSysModuleFolder_BaseEventsProcess<SysModuleInSysModuleFolder>
	{

		public SysModuleInSysModuleFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysModuleInSysModuleFolder_BaseEventsProcess

	public partial class SysModuleInSysModuleFolder_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysModuleInSysModuleFolderEventsProcess

	/// <exclude/>
	public class SysModuleInSysModuleFolderEventsProcess : SysModuleInSysModuleFolder_BaseEventsProcess
	{

		public SysModuleInSysModuleFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

