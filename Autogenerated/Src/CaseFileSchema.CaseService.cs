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

	#region Class: CaseFileSchema

	/// <exclude/>
	public class CaseFileSchema : BPMSoft.Configuration.CaseFile_Case_BPMSoftSchema
	{

		#region Constructors: Public

		public CaseFileSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CaseFileSchema(CaseFileSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CaseFileSchema(CaseFileSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("736dce4a-0ec7-4890-99e2-18d8851b80e6");
			Name = "CaseFile";
			ParentSchemaUId = new Guid("72deb8f3-0936-41ca-b4ae-102c6c4bf708");
			ExtendParent = true;
			CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CaseFile(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CaseFile_CaseServiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CaseFileSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CaseFileSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("736dce4a-0ec7-4890-99e2-18d8851b80e6"));
		}

		#endregion

	}

	#endregion

	#region Class: CaseFile

	/// <summary>
	/// Объект для детали файлы и ссылки объекта раздела "Обращения".
	/// </summary>
	public class CaseFile : BPMSoft.Configuration.CaseFile_Case_BPMSoft
	{

		#region Constructors: Public

		public CaseFile(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CaseFile";
		}

		public CaseFile(CaseFile source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CaseFile_CaseServiceEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Inserted += (s, e) => ThrowEvent("CaseFileInserted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CaseFile(this);
		}

		#endregion

	}

	#endregion

	#region Class: CaseFile_CaseServiceEventsProcess

	/// <exclude/>
	public partial class CaseFile_CaseServiceEventsProcess<TEntity> : BPMSoft.Configuration.CaseFile_CaseEventsProcess<TEntity> where TEntity : CaseFile
	{

		public CaseFile_CaseServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CaseFile_CaseServiceEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("736dce4a-0ec7-4890-99e2-18d8851b80e6");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _eventSubProcess3_4f47efa85b0548aba7425f1444e6efbe;
		public ProcessFlowElement EventSubProcess3_4f47efa85b0548aba7425f1444e6efbe {
			get {
				return _eventSubProcess3_4f47efa85b0548aba7425f1444e6efbe ?? (_eventSubProcess3_4f47efa85b0548aba7425f1444e6efbe = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess3_4f47efa85b0548aba7425f1444e6efbe",
					SchemaElementUId = new Guid("4f47efa8-5b05-48ab-a742-5f1444e6efbe"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessage3_d2d754bfe83e4a33a4261ac9a26d3d73;
		public ProcessFlowElement StartMessage3_d2d754bfe83e4a33a4261ac9a26d3d73 {
			get {
				return _startMessage3_d2d754bfe83e4a33a4261ac9a26d3d73 ?? (_startMessage3_d2d754bfe83e4a33a4261ac9a26d3d73 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage3_d2d754bfe83e4a33a4261ac9a26d3d73",
					SchemaElementUId = new Guid("d2d754bf-e83e-4a33-a426-1ac9a26d3d73"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask3_c959bb6a28f640e88e18746af09758b1;
		public ProcessScriptTask ScriptTask3_c959bb6a28f640e88e18746af09758b1 {
			get {
				return _scriptTask3_c959bb6a28f640e88e18746af09758b1 ?? (_scriptTask3_c959bb6a28f640e88e18746af09758b1 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask3_c959bb6a28f640e88e18746af09758b1",
					SchemaElementUId = new Guid("c959bb6a-28f6-40e8-8e18-746af09758b1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask3_c959bb6a28f640e88e18746af09758b1Execute,
				});
			}
		}

		private ProcessThrowMessageEvent _intermediateThrowMessage1_cb35b2dcae514d96b46177b11d4fb395;
		public ProcessThrowMessageEvent IntermediateThrowMessage1_cb35b2dcae514d96b46177b11d4fb395 {
			get {
				return _intermediateThrowMessage1_cb35b2dcae514d96b46177b11d4fb395 ?? (_intermediateThrowMessage1_cb35b2dcae514d96b46177b11d4fb395 = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "IntermediateThrowMessage1_cb35b2dcae514d96b46177b11d4fb395",
					SchemaElementUId = new Guid("cb35b2dc-ae51-4d96-b461-77b11d4fb395"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "CaseFileInserted",
						ThrowToBase = true,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess3_4f47efa85b0548aba7425f1444e6efbe.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess3_4f47efa85b0548aba7425f1444e6efbe };
			FlowElements[StartMessage3_d2d754bfe83e4a33a4261ac9a26d3d73.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage3_d2d754bfe83e4a33a4261ac9a26d3d73 };
			FlowElements[ScriptTask3_c959bb6a28f640e88e18746af09758b1.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask3_c959bb6a28f640e88e18746af09758b1 };
			FlowElements[IntermediateThrowMessage1_cb35b2dcae514d96b46177b11d4fb395.SchemaElementUId] = new Collection<ProcessFlowElement> { IntermediateThrowMessage1_cb35b2dcae514d96b46177b11d4fb395 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess3_4f47efa85b0548aba7425f1444e6efbe":
						break;
					case "StartMessage3_d2d754bfe83e4a33a4261ac9a26d3d73":
						e.Context.QueueTasks.Enqueue("ScriptTask3_c959bb6a28f640e88e18746af09758b1");
						break;
					case "ScriptTask3_c959bb6a28f640e88e18746af09758b1":
						e.Context.QueueTasks.Enqueue("IntermediateThrowMessage1_cb35b2dcae514d96b46177b11d4fb395");
						break;
					case "IntermediateThrowMessage1_cb35b2dcae514d96b46177b11d4fb395":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("StartMessage3_d2d754bfe83e4a33a4261ac9a26d3d73");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess3_4f47efa85b0548aba7425f1444e6efbe":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessage3_d2d754bfe83e4a33a4261ac9a26d3d73":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage3_d2d754bfe83e4a33a4261ac9a26d3d73";
					result = StartMessage3_d2d754bfe83e4a33a4261ac9a26d3d73.Execute(context);
					break;
				case "ScriptTask3_c959bb6a28f640e88e18746af09758b1":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask3_c959bb6a28f640e88e18746af09758b1";
					result = ScriptTask3_c959bb6a28f640e88e18746af09758b1.Execute(context, ScriptTask3_c959bb6a28f640e88e18746af09758b1Execute);
					break;
				case "IntermediateThrowMessage1_cb35b2dcae514d96b46177b11d4fb395":
					context.QueueTasks.Dequeue();
					base.ThrowEvent(context, "CaseFileInserted");
					result = IntermediateThrowMessage1_cb35b2dcae514d96b46177b11d4fb395.Execute(context);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptTask3_c959bb6a28f640e88e18746af09758b1Execute(ProcessExecutingContext context) {
			if(Entity.GetTypedColumnValue<bool>("IsNeedToNotify")) {
				var notifier = new CaseFileMessageNotifier(Entity, UserConnection);
				var manager = new MessageHistoryManager(UserConnection, notifier);
				manager.Notify();
			}
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "CaseFileInserted":
							if (ActivatedEventElements.Contains("StartMessage3_d2d754bfe83e4a33a4261ac9a26d3d73")) {
							context.QueueTasks.Enqueue("StartMessage3_d2d754bfe83e4a33a4261ac9a26d3d73");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: CaseFile_CaseServiceEventsProcess

	/// <exclude/>
	public class CaseFile_CaseServiceEventsProcess : CaseFile_CaseServiceEventsProcess<CaseFile>
	{

		public CaseFile_CaseServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CaseFile_CaseServiceEventsProcess

	public partial class CaseFile_CaseServiceEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CaseFileEventsProcess

	/// <exclude/>
	public class CaseFileEventsProcess : CaseFile_CaseServiceEventsProcess
	{

		public CaseFileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

