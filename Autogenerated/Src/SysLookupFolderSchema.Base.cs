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

	#region Class: SysLookupFolderSchema

	/// <exclude/>
	public class SysLookupFolderSchema : BPMSoft.Configuration.BaseFolderSchema
	{

		#region Constructors: Public

		public SysLookupFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysLookupFolderSchema(SysLookupFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysLookupFolderSchema(SysLookupFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5403f977-1005-41a3-99a1-5ff37806bbbf");
			RealUId = new Guid("5403f977-1005-41a3-99a1-5ff37806bbbf");
			Name = "SysLookupFolder";
			ParentSchemaUId = new Guid("d602bf96-d029-4b07-9755-63c8f5cb5ed5");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("5403f977-1005-41a3-99a1-5ff37806bbbf");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("5403f977-1005-41a3-99a1-5ff37806bbbf");
			return column;
		}

		protected override EntitySchemaColumn CreateParentColumn() {
			EntitySchemaColumn column = base.CreateParentColumn();
			column.ReferenceSchemaUId = new Guid("5403f977-1005-41a3-99a1-5ff37806bbbf");
			column.ColumnValueName = @"ParentId";
			column.DisplayColumnValueName = @"ParentName";
			column.ModifiedInSchemaUId = new Guid("5403f977-1005-41a3-99a1-5ff37806bbbf");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysLookupFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysLookupFolder_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysLookupFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysLookupFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5403f977-1005-41a3-99a1-5ff37806bbbf"));
		}

		#endregion

	}

	#endregion

	#region Class: SysLookupFolder

	/// <summary>
	/// Lookup folder.
	/// </summary>
	public class SysLookupFolder : BPMSoft.Configuration.BaseFolder
	{

		#region Constructors: Public

		public SysLookupFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysLookupFolder";
		}

		public SysLookupFolder(SysLookupFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ParentId {
			get {
				return GetTypedColumnValue<Guid>("ParentId");
			}
			set {
				SetColumnValue("ParentId", value);
				_parent = null;
			}
		}

		/// <exclude/>
		public string ParentName {
			get {
				return GetTypedColumnValue<string>("ParentName");
			}
			set {
				SetColumnValue("ParentName", value);
				if (_parent != null) {
					_parent.Name = value;
				}
			}
		}

		private SysLookupFolder _parent;
		/// <summary>
		/// Parent.
		/// </summary>
		public SysLookupFolder Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as SysLookupFolder);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysLookupFolder_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysLookupFolderDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysLookupFolderDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysLookupFolderInserted", e);
			Inserting += (s, e) => ThrowEvent("SysLookupFolderInserting", e);
			Saved += (s, e) => ThrowEvent("SysLookupFolderSaved", e);
			Saving += (s, e) => ThrowEvent("SysLookupFolderSaving", e);
			Validating += (s, e) => ThrowEvent("SysLookupFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysLookupFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysLookupFolder_BaseEventsProcess

	/// <exclude/>
	public partial class SysLookupFolder_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseFolder_BaseEventsProcess<TEntity> where TEntity : SysLookupFolder
	{

		public SysLookupFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysLookupFolder_BaseEventsProcess";
			SchemaUId = new Guid("5403f977-1005-41a3-99a1-5ff37806bbbf");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5403f977-1005-41a3-99a1-5ff37806bbbf");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _eventSubProcess1;
		public ProcessFlowElement EventSubProcess1 {
			get {
				return _eventSubProcess1 ?? (_eventSubProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess1",
					SchemaElementUId = new Guid("241555e6-79e5-4bdb-8247-ef39e2b4f856"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _sysLookupFolderInserted;
		public ProcessFlowElement SysLookupFolderInserted {
			get {
				return _sysLookupFolderInserted ?? (_sysLookupFolderInserted = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SysLookupFolderInserted",
					SchemaElementUId = new Guid("5ddc7db3-6983-45f4-9cf7-2a33779222c8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask1;
		public ProcessScriptTask ScriptTask1 {
			get {
				return _scriptTask1 ?? (_scriptTask1 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask1",
					SchemaElementUId = new Guid("1f46d8c6-963a-4921-8dc6-c111a0717ab6"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask1Execute,
				});
			}
		}

		private ProcessThrowMessageEvent _baseSysLookupFolderInserted;
		public ProcessThrowMessageEvent BaseSysLookupFolderInserted {
			get {
				return _baseSysLookupFolderInserted ?? (_baseSysLookupFolderInserted = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "BaseSysLookupFolderInserted",
					SchemaElementUId = new Guid("91872619-0514-4b0f-9ba5-20278b866b6b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "SysLookupFolderInserted",
						ThrowToBase = true,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[SysLookupFolderInserted.SchemaElementUId] = new Collection<ProcessFlowElement> { SysLookupFolderInserted };
			FlowElements[ScriptTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask1 };
			FlowElements[BaseSysLookupFolderInserted.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseSysLookupFolderInserted };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "SysLookupFolderInserted":
						e.Context.QueueTasks.Enqueue("ScriptTask1");
						break;
					case "ScriptTask1":
						e.Context.QueueTasks.Enqueue("BaseSysLookupFolderInserted");
						break;
					case "BaseSysLookupFolderInserted":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("SysLookupFolderInserted");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess1":
					context.QueueTasks.Dequeue();
					break;
				case "SysLookupFolderInserted":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysLookupFolderInserted";
					result = SysLookupFolderInserted.Execute(context);
					break;
				case "ScriptTask1":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask1";
					result = ScriptTask1.Execute(context, ScriptTask1Execute);
					break;
				case "BaseSysLookupFolderInserted":
					context.QueueTasks.Dequeue();
					base.ThrowEvent(context, "SysLookupFolderInserted");
					result = BaseSysLookupFolderInserted.Execute(context);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptTask1Execute(ProcessExecutingContext context) {
			Guid adminGroupId = new Guid("A29A3BA5-4B0D-DE11-9A51-005056C00008");
			var dbSecurityEngine = UserConnection.DBSecurityEngine;
			var rightLevel = dbSecurityEngine.GetEntitySchemaRecordRightLevel(Entity.Schema.Name, Entity.Id);
			if (rightLevel.HasFlag(SchemaRecordRightLevels.CanRead) &&
				rightLevel.HasFlag(SchemaRecordRightLevels.CanChangeReadRight)) {
				dbSecurityEngine.SetEntitySchemaRecordOperationRightLevel(adminGroupId, Entity.Schema.Name,
					Entity.Id, EntitySchemaRecordRightOperation.Read, EntitySchemaRecordRightLevel.Allow);
			}
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "SysLookupFolderInserted":
							if (ActivatedEventElements.Contains("SysLookupFolderInserted")) {
							context.QueueTasks.Enqueue("SysLookupFolderInserted");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: SysLookupFolder_BaseEventsProcess

	/// <exclude/>
	public class SysLookupFolder_BaseEventsProcess : SysLookupFolder_BaseEventsProcess<SysLookupFolder>
	{

		public SysLookupFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysLookupFolder_BaseEventsProcess

	public partial class SysLookupFolder_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void CheckCanManageLookups() {
			return;
		}

		#endregion

	}

	#endregion


	#region Class: SysLookupFolderEventsProcess

	/// <exclude/>
	public class SysLookupFolderEventsProcess : SysLookupFolder_BaseEventsProcess
	{

		public SysLookupFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

