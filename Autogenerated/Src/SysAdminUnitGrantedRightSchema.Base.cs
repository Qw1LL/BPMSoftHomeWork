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

	#region Class: SysAdminUnitGrantedRightSchema

	/// <exclude/>
	public class SysAdminUnitGrantedRightSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysAdminUnitGrantedRightSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysAdminUnitGrantedRightSchema(SysAdminUnitGrantedRightSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysAdminUnitGrantedRightSchema(SysAdminUnitGrantedRightSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7273d66e-49ea-43e9-92ea-20f3d542407c");
			RealUId = new Guid("7273d66e-49ea-43e9-92ea-20f3d542407c");
			Name = "SysAdminUnitGrantedRight";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("8a2e796c-7ed7-4544-a9bc-4a3149183f3e")) == null) {
				Columns.Add(CreateGrantorSysAdminUnitColumn());
			}
			if (Columns.FindByUId(new Guid("5290e2da-05d6-49e7-b839-9b098bf6b15e")) == null) {
				Columns.Add(CreateGranteeSysAdminUnitColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateGrantorSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8a2e796c-7ed7-4544-a9bc-4a3149183f3e"),
				Name = @"GrantorSysAdminUnit",
				ReferenceSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("7273d66e-49ea-43e9-92ea-20f3d542407c"),
				ModifiedInSchemaUId = new Guid("7273d66e-49ea-43e9-92ea-20f3d542407c"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateGranteeSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5290e2da-05d6-49e7-b839-9b098bf6b15e"),
				Name = @"GranteeSysAdminUnit",
				ReferenceSchemaUId = new Guid("d5d01fcd-6d8c-4b29-9e58-cca3ffe62364"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("7273d66e-49ea-43e9-92ea-20f3d542407c"),
				ModifiedInSchemaUId = new Guid("7273d66e-49ea-43e9-92ea-20f3d542407c"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysAdminUnitGrantedRight(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysAdminUnitGrantedRight_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysAdminUnitGrantedRightSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysAdminUnitGrantedRightSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7273d66e-49ea-43e9-92ea-20f3d542407c"));
		}

		#endregion

	}

	#endregion

	#region Class: SysAdminUnitGrantedRight

	/// <summary>
	/// Additionally inherited permissions.
	/// </summary>
	public class SysAdminUnitGrantedRight : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysAdminUnitGrantedRight(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysAdminUnitGrantedRight";
		}

		public SysAdminUnitGrantedRight(SysAdminUnitGrantedRight source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid GrantorSysAdminUnitId {
			get {
				return GetTypedColumnValue<Guid>("GrantorSysAdminUnitId");
			}
			set {
				SetColumnValue("GrantorSysAdminUnitId", value);
				_grantorSysAdminUnit = null;
			}
		}

		/// <exclude/>
		public string GrantorSysAdminUnitName {
			get {
				return GetTypedColumnValue<string>("GrantorSysAdminUnitName");
			}
			set {
				SetColumnValue("GrantorSysAdminUnitName", value);
				if (_grantorSysAdminUnit != null) {
					_grantorSysAdminUnit.Name = value;
				}
			}
		}

		private VwSysAdminUnit _grantorSysAdminUnit;
		/// <summary>
		/// Who grants permissions.
		/// </summary>
		public VwSysAdminUnit GrantorSysAdminUnit {
			get {
				return _grantorSysAdminUnit ??
					(_grantorSysAdminUnit = LookupColumnEntities.GetEntity("GrantorSysAdminUnit") as VwSysAdminUnit);
			}
		}

		/// <exclude/>
		public Guid GranteeSysAdminUnitId {
			get {
				return GetTypedColumnValue<Guid>("GranteeSysAdminUnitId");
			}
			set {
				SetColumnValue("GranteeSysAdminUnitId", value);
				_granteeSysAdminUnit = null;
			}
		}

		/// <exclude/>
		public string GranteeSysAdminUnitName {
			get {
				return GetTypedColumnValue<string>("GranteeSysAdminUnitName");
			}
			set {
				SetColumnValue("GranteeSysAdminUnitName", value);
				if (_granteeSysAdminUnit != null) {
					_granteeSysAdminUnit.Name = value;
				}
			}
		}

		private VwSysAdminUnit _granteeSysAdminUnit;
		/// <summary>
		/// Who receives permissions.
		/// </summary>
		public VwSysAdminUnit GranteeSysAdminUnit {
			get {
				return _granteeSysAdminUnit ??
					(_granteeSysAdminUnit = LookupColumnEntities.GetEntity("GranteeSysAdminUnit") as VwSysAdminUnit);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysAdminUnitGrantedRight_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysAdminUnitGrantedRightDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysAdminUnitGrantedRightDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysAdminUnitGrantedRightInserted", e);
			Inserting += (s, e) => ThrowEvent("SysAdminUnitGrantedRightInserting", e);
			Saved += (s, e) => ThrowEvent("SysAdminUnitGrantedRightSaved", e);
			Saving += (s, e) => ThrowEvent("SysAdminUnitGrantedRightSaving", e);
			Validating += (s, e) => ThrowEvent("SysAdminUnitGrantedRightValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysAdminUnitGrantedRight(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysAdminUnitGrantedRight_BaseEventsProcess

	/// <exclude/>
	public partial class SysAdminUnitGrantedRight_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysAdminUnitGrantedRight
	{

		public SysAdminUnitGrantedRight_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysAdminUnitGrantedRight_BaseEventsProcess";
			SchemaUId = new Guid("7273d66e-49ea-43e9-92ea-20f3d542407c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7273d66e-49ea-43e9-92ea-20f3d542407c");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _sysAdminUnitGrantedRightSavedEventSubProcess;
		public ProcessFlowElement SysAdminUnitGrantedRightSavedEventSubProcess {
			get {
				return _sysAdminUnitGrantedRightSavedEventSubProcess ?? (_sysAdminUnitGrantedRightSavedEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "SysAdminUnitGrantedRightSavedEventSubProcess",
					SchemaElementUId = new Guid("12110a24-27eb-4cec-a603-790f3e34997a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _sysAdminUnitGrantedRightSaved;
		public ProcessFlowElement SysAdminUnitGrantedRightSaved {
			get {
				return _sysAdminUnitGrantedRightSaved ?? (_sysAdminUnitGrantedRightSaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SysAdminUnitGrantedRightSaved",
					SchemaElementUId = new Guid("371d4f8f-306e-4145-aad2-ecff6a386ff0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _sysAdminUnitGrantedRightDeleted;
		public ProcessFlowElement SysAdminUnitGrantedRightDeleted {
			get {
				return _sysAdminUnitGrantedRightDeleted ?? (_sysAdminUnitGrantedRightDeleted = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SysAdminUnitGrantedRightDeleted",
					SchemaElementUId = new Guid("00242600-9c4b-44e0-b1d0-9658f0e0fcaa"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _sysAdminUnitGrantedRightSavedScriptTask;
		public ProcessScriptTask SysAdminUnitGrantedRightSavedScriptTask {
			get {
				return _sysAdminUnitGrantedRightSavedScriptTask ?? (_sysAdminUnitGrantedRightSavedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SysAdminUnitGrantedRightSavedScriptTask",
					SchemaElementUId = new Guid("7b097eee-81e3-434f-a770-e8fdd079e923"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SysAdminUnitGrantedRightSavedScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[SysAdminUnitGrantedRightSavedEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { SysAdminUnitGrantedRightSavedEventSubProcess };
			FlowElements[SysAdminUnitGrantedRightSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { SysAdminUnitGrantedRightSaved };
			FlowElements[SysAdminUnitGrantedRightDeleted.SchemaElementUId] = new Collection<ProcessFlowElement> { SysAdminUnitGrantedRightDeleted };
			FlowElements[SysAdminUnitGrantedRightSavedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SysAdminUnitGrantedRightSavedScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "SysAdminUnitGrantedRightSavedEventSubProcess":
						break;
					case "SysAdminUnitGrantedRightSaved":
						e.Context.QueueTasks.Enqueue("SysAdminUnitGrantedRightSavedScriptTask");
						break;
					case "SysAdminUnitGrantedRightDeleted":
						e.Context.QueueTasks.Enqueue("SysAdminUnitGrantedRightSavedScriptTask");
						break;
					case "SysAdminUnitGrantedRightSavedScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("SysAdminUnitGrantedRightSaved");
			ActivatedEventElements.Add("SysAdminUnitGrantedRightDeleted");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "SysAdminUnitGrantedRightSavedEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "SysAdminUnitGrantedRightSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysAdminUnitGrantedRightSaved";
					result = SysAdminUnitGrantedRightSaved.Execute(context);
					break;
				case "SysAdminUnitGrantedRightDeleted":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysAdminUnitGrantedRightDeleted";
					result = SysAdminUnitGrantedRightDeleted.Execute(context);
					break;
				case "SysAdminUnitGrantedRightSavedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysAdminUnitGrantedRightSavedScriptTask";
					result = SysAdminUnitGrantedRightSavedScriptTask.Execute(context, SysAdminUnitGrantedRightSavedScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool SysAdminUnitGrantedRightSavedScriptTaskExecute(ProcessExecutingContext context) {
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "SysAdminUnitGrantedRightSaved":
							if (ActivatedEventElements.Contains("SysAdminUnitGrantedRightSaved")) {
							context.QueueTasks.Enqueue("SysAdminUnitGrantedRightSaved");
						}
						break;
					case "SysAdminUnitGrantedRightDeleted":
							if (ActivatedEventElements.Contains("SysAdminUnitGrantedRightDeleted")) {
							context.QueueTasks.Enqueue("SysAdminUnitGrantedRightDeleted");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: SysAdminUnitGrantedRight_BaseEventsProcess

	/// <exclude/>
	public class SysAdminUnitGrantedRight_BaseEventsProcess : SysAdminUnitGrantedRight_BaseEventsProcess<SysAdminUnitGrantedRight>
	{

		public SysAdminUnitGrantedRight_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysAdminUnitGrantedRight_BaseEventsProcess

	public partial class SysAdminUnitGrantedRight_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysAdminUnitGrantedRightEventsProcess

	/// <exclude/>
	public class SysAdminUnitGrantedRightEventsProcess : SysAdminUnitGrantedRight_BaseEventsProcess
	{

		public SysAdminUnitGrantedRightEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

