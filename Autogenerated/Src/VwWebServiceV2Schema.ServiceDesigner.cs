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

	#region Class: VwWebServiceV2Schema

	/// <exclude/>
	public class VwWebServiceV2Schema : BPMSoft.Configuration.VwSysSchemaInWorkspaceSchema
	{

		#region Constructors: Public

		public VwWebServiceV2Schema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwWebServiceV2Schema(VwWebServiceV2Schema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwWebServiceV2Schema(VwWebServiceV2Schema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("057b56c2-d524-4be3-9668-904d92602fca");
			RealUId = new Guid("057b56c2-d524-4be3-9668-904d92602fca");
			Name = "VwWebServiceV2";
			ParentSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9a41e39e-51c2-4a16-b81f-aa6773013744");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("984795df-2a7a-9456-051e-1d5fd6aa6d49")) == null) {
				Columns.Add(CreateTypeNameColumn());
			}
		}

		protected override EntitySchemaColumn CreateUIdColumn() {
			EntitySchemaColumn column = base.CreateUIdColumn();
			column.RequirementType = EntitySchemaColumnRequirementType.None;
			column.ModifiedInSchemaUId = new Guid("057b56c2-d524-4be3-9668-904d92602fca");
			return column;
		}

		protected virtual EntitySchemaColumn CreateTypeNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("984795df-2a7a-9456-051e-1d5fd6aa6d49"),
				Name = @"TypeName",
				CreatedInSchemaUId = new Guid("057b56c2-d524-4be3-9668-904d92602fca"),
				ModifiedInSchemaUId = new Guid("057b56c2-d524-4be3-9668-904d92602fca"),
				CreatedInPackageId = new Guid("e0cd720a-279e-436c-a704-8c755267ad15")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwWebServiceV2(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwWebServiceV2_ServiceDesignerEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwWebServiceV2Schema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwWebServiceV2Schema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("057b56c2-d524-4be3-9668-904d92602fca"));
		}

		#endregion

	}

	#endregion

	#region Class: VwWebServiceV2

	/// <summary>
	/// Web Service (view).
	/// </summary>
	public class VwWebServiceV2 : BPMSoft.Configuration.VwSysSchemaInWorkspace
	{

		#region Constructors: Public

		public VwWebServiceV2(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwWebServiceV2";
		}

		public VwWebServiceV2(VwWebServiceV2 source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Type name.
		/// </summary>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwWebServiceV2_ServiceDesignerEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwWebServiceV2Deleted", e);
			Loading += (s, e) => ThrowEvent("VwWebServiceV2Loading", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwWebServiceV2(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwWebServiceV2_ServiceDesignerEventsProcess

	/// <exclude/>
	public partial class VwWebServiceV2_ServiceDesignerEventsProcess<TEntity> : BPMSoft.Configuration.VwSysSchemaInWorkspace_BaseEventsProcess<TEntity> where TEntity : VwWebServiceV2
	{

		public VwWebServiceV2_ServiceDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwWebServiceV2_ServiceDesignerEventsProcess";
			SchemaUId = new Guid("057b56c2-d524-4be3-9668-904d92602fca");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("057b56c2-d524-4be3-9668-904d92602fca");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _eventSubProcess3_1f05c9218a06422f9b2f07451f507087;
		public ProcessFlowElement EventSubProcess3_1f05c9218a06422f9b2f07451f507087 {
			get {
				return _eventSubProcess3_1f05c9218a06422f9b2f07451f507087 ?? (_eventSubProcess3_1f05c9218a06422f9b2f07451f507087 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess3_1f05c9218a06422f9b2f07451f507087",
					SchemaElementUId = new Guid("1f05c921-8a06-422f-9b2f-07451f507087"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessage3_2493be51644144d09f6776a067a34c74;
		public ProcessFlowElement StartMessage3_2493be51644144d09f6776a067a34c74 {
			get {
				return _startMessage3_2493be51644144d09f6776a067a34c74 ?? (_startMessage3_2493be51644144d09f6776a067a34c74 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage3_2493be51644144d09f6776a067a34c74",
					SchemaElementUId = new Guid("2493be51-6441-44d0-9f67-76a067a34c74"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask3_b50195c767954d739c619c5e769d6319;
		public ProcessScriptTask ScriptTask3_b50195c767954d739c619c5e769d6319 {
			get {
				return _scriptTask3_b50195c767954d739c619c5e769d6319 ?? (_scriptTask3_b50195c767954d739c619c5e769d6319 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask3_b50195c767954d739c619c5e769d6319",
					SchemaElementUId = new Guid("b50195c7-6795-4d73-9c61-9c5e769d6319"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask3_b50195c767954d739c619c5e769d6319Execute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess3_1f05c9218a06422f9b2f07451f507087.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess3_1f05c9218a06422f9b2f07451f507087 };
			FlowElements[StartMessage3_2493be51644144d09f6776a067a34c74.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage3_2493be51644144d09f6776a067a34c74 };
			FlowElements[ScriptTask3_b50195c767954d739c619c5e769d6319.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask3_b50195c767954d739c619c5e769d6319 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess3_1f05c9218a06422f9b2f07451f507087":
						break;
					case "StartMessage3_2493be51644144d09f6776a067a34c74":
						e.Context.QueueTasks.Enqueue("ScriptTask3_b50195c767954d739c619c5e769d6319");
						break;
					case "ScriptTask3_b50195c767954d739c619c5e769d6319":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("StartMessage3_2493be51644144d09f6776a067a34c74");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess3_1f05c9218a06422f9b2f07451f507087":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessage3_2493be51644144d09f6776a067a34c74":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage3_2493be51644144d09f6776a067a34c74";
					result = StartMessage3_2493be51644144d09f6776a067a34c74.Execute(context);
					break;
				case "ScriptTask3_b50195c767954d739c619c5e769d6319":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask3_b50195c767954d739c619c5e769d6319";
					result = ScriptTask3_b50195c767954d739c619c5e769d6319.Execute(context, ScriptTask3_b50195c767954d739c619c5e769d6319Execute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptTask3_b50195c767954d739c619c5e769d6319Execute(ProcessExecutingContext context) {
			UserConnection.DBSecurityEngine.CheckCanExecuteAnyOperation("CanViewConfiguration", "CanManageSolution");
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "VwWebServiceV2Loading":
							if (ActivatedEventElements.Contains("StartMessage3_2493be51644144d09f6776a067a34c74")) {
							context.QueueTasks.Enqueue("StartMessage3_2493be51644144d09f6776a067a34c74");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: VwWebServiceV2_ServiceDesignerEventsProcess

	/// <exclude/>
	public class VwWebServiceV2_ServiceDesignerEventsProcess : VwWebServiceV2_ServiceDesignerEventsProcess<VwWebServiceV2>
	{

		public VwWebServiceV2_ServiceDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwWebServiceV2_ServiceDesignerEventsProcess

	public partial class VwWebServiceV2_ServiceDesignerEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwWebServiceV2EventsProcess

	/// <exclude/>
	public class VwWebServiceV2EventsProcess : VwWebServiceV2_ServiceDesignerEventsProcess
	{

		public VwWebServiceV2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

