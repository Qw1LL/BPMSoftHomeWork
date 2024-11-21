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

	#region Class: VwSysSSPEntitySchemaAccessListSchema

	/// <exclude/>
	public class VwSysSSPEntitySchemaAccessListSchema : BPMSoft.Configuration.VwSysSSPEntitySchemaAccessList_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public VwSysSSPEntitySchemaAccessListSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSysSSPEntitySchemaAccessListSchema(VwSysSSPEntitySchemaAccessListSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSysSSPEntitySchemaAccessListSchema(VwSysSSPEntitySchemaAccessListSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("613da198-638b-4cd0-aaca-88269a97165a");
			Name = "VwSysSSPEntitySchemaAccessList";
			ParentSchemaUId = new Guid("a7982d2c-1ee2-43ce-a6e1-43d6c67c5a51");
			ExtendParent = true;
			CreatedInPackageId = new Guid("7cc31540-fa76-4c79-9b86-a6eabd8e662c");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateSysSchemaColumn() {
			EntitySchemaColumn column = base.CreateSysSchemaColumn();
			column.RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel;
			column.ModifiedInSchemaUId = new Guid("613da198-638b-4cd0-aaca-88269a97165a");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSysSSPEntitySchemaAccessList(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSysSSPEntitySchemaAccessList_SSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSysSSPEntitySchemaAccessListSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSysSSPEntitySchemaAccessListSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("613da198-638b-4cd0-aaca-88269a97165a"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSysSSPEntitySchemaAccessList

	/// <summary>
	/// SSP Entity Schema Access List (View).
	/// </summary>
	public class VwSysSSPEntitySchemaAccessList : BPMSoft.Configuration.VwSysSSPEntitySchemaAccessList_Base_BPMSoft
	{

		#region Constructors: Public

		public VwSysSSPEntitySchemaAccessList(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysSSPEntitySchemaAccessList";
		}

		public VwSysSSPEntitySchemaAccessList(VwSysSSPEntitySchemaAccessList source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSysSSPEntitySchemaAccessList_SSPEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Validating += (s, e) => ThrowEvent("VwSysSSPEntitySchemaAccessListValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwSysSSPEntitySchemaAccessList(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysSSPEntitySchemaAccessList_SSPEventsProcess

	/// <exclude/>
	public partial class VwSysSSPEntitySchemaAccessList_SSPEventsProcess<TEntity> : BPMSoft.Configuration.VwSysSSPEntitySchemaAccessList_BaseEventsProcess<TEntity> where TEntity : VwSysSSPEntitySchemaAccessList
	{

		public VwSysSSPEntitySchemaAccessList_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSysSSPEntitySchemaAccessList_SSPEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("613da198-638b-4cd0-aaca-88269a97165a");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _vwSysSSPEntitySchemaAccessListValidating;
		public ProcessFlowElement VwSysSSPEntitySchemaAccessListValidating {
			get {
				return _vwSysSSPEntitySchemaAccessListValidating ?? (_vwSysSSPEntitySchemaAccessListValidating = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "VwSysSSPEntitySchemaAccessListValidating",
					SchemaElementUId = new Guid("0bd8a217-3b18-472d-9d55-bc6cbc102db3"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _vwSysSSPEntitySchemaAccessListValidatingScriptTask;
		public ProcessScriptTask VwSysSSPEntitySchemaAccessListValidatingScriptTask {
			get {
				return _vwSysSSPEntitySchemaAccessListValidatingScriptTask ?? (_vwSysSSPEntitySchemaAccessListValidatingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "VwSysSSPEntitySchemaAccessListValidatingScriptTask",
					SchemaElementUId = new Guid("ac24ae31-e0bc-4e83-8638-a29c16549e7a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = VwSysSSPEntitySchemaAccessListValidatingScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[VwSysSSPEntitySchemaAccessListValidating.SchemaElementUId] = new Collection<ProcessFlowElement> { VwSysSSPEntitySchemaAccessListValidating };
			FlowElements[VwSysSSPEntitySchemaAccessListValidatingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { VwSysSSPEntitySchemaAccessListValidatingScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "VwSysSSPEntitySchemaAccessListValidating":
						e.Context.QueueTasks.Enqueue("VwSysSSPEntitySchemaAccessListValidatingScriptTask");
						break;
					case "VwSysSSPEntitySchemaAccessListValidatingScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "VwSysSSPEntitySchemaAccessListValidating":
					context.QueueTasks.Dequeue();
					context.SenderName = "VwSysSSPEntitySchemaAccessListValidating";
					result = VwSysSSPEntitySchemaAccessListValidating.Execute(context);
					break;
				case "VwSysSSPEntitySchemaAccessListValidatingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "VwSysSSPEntitySchemaAccessListValidatingScriptTask";
					result = VwSysSSPEntitySchemaAccessListValidatingScriptTask.Execute(context, VwSysSSPEntitySchemaAccessListValidatingScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool VwSysSSPEntitySchemaAccessListValidatingScriptTaskExecute(ProcessExecutingContext context) {
			if (Entity.UserConnection.DBSecurityEngine.GetCanExecuteOperation("CanManageLookups")){
				return true;
			}
			return false;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysSSPEntitySchemaAccessList_SSPEventsProcess

	/// <exclude/>
	public class VwSysSSPEntitySchemaAccessList_SSPEventsProcess : VwSysSSPEntitySchemaAccessList_SSPEventsProcess<VwSysSSPEntitySchemaAccessList>
	{

		public VwSysSSPEntitySchemaAccessList_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSysSSPEntitySchemaAccessList_SSPEventsProcess

	public partial class VwSysSSPEntitySchemaAccessList_SSPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSysSSPEntitySchemaAccessListEventsProcess

	/// <exclude/>
	public class VwSysSSPEntitySchemaAccessListEventsProcess : VwSysSSPEntitySchemaAccessList_SSPEventsProcess
	{

		public VwSysSSPEntitySchemaAccessListEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

