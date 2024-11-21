namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration.PRM;
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

	#region Class: Lead_PRMPortal_BPMSoftSchema

	/// <exclude/>
	public class Lead_PRMPortal_BPMSoftSchema : BPMSoft.Configuration.Lead_OrderLead_BPMSoftSchema
	{

		#region Constructors: Public

		public Lead_PRMPortal_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Lead_PRMPortal_BPMSoftSchema(Lead_PRMPortal_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Lead_PRMPortal_BPMSoftSchema(Lead_PRMPortal_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIDX_LeadNameIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("bf3f62f3-5d38-4031-a648-58b036f8f19d");
			index.Name = "IDX_LeadName";
			index.CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec");
			index.ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec");
			index.CreatedInPackageId = new Guid("b424f2c1-869b-44e8-aaf1-c9a818421e06");
			EntitySchemaIndexColumn leadNameIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("2c3ed9bd-ff44-447d-b4af-c6a4e4090a5a"),
				ColumnUId = new Guid("d06ba9af-faf5-4741-a672-e154ae561a94"),
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("b424f2c1-869b-44e8-aaf1-c9a818421e06"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(leadNameIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("07b9e4ee-6b92-4a34-8444-7d9556c2adbb");
			Name = "Lead_PRMPortal_BPMSoft";
			ParentSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec");
			ExtendParent = true;
			CreatedInPackageId = new Guid("ba438a7b-1c87-4703-9a24-35e026996df4");
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

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIDX_LeadNameIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Lead_PRMPortal_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Lead_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Lead_PRMPortal_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Lead_PRMPortal_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("07b9e4ee-6b92-4a34-8444-7d9556c2adbb"));
		}

		#endregion

	}

	#endregion

	#region Class: Lead_PRMPortal_BPMSoft

	/// <summary>
	/// Лид.
	/// </summary>
	public class Lead_PRMPortal_BPMSoft : BPMSoft.Configuration.Lead_OrderLead_BPMSoft
	{

		#region Constructors: Public

		public Lead_PRMPortal_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Lead_PRMPortal_BPMSoft";
		}

		public Lead_PRMPortal_BPMSoft(Lead_PRMPortal_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Lead_PRMPortalEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Lead_PRMPortal_BPMSoftDeleted", e);
			Inserted += (s, e) => ThrowEvent("Lead_PRMPortal_BPMSoftInserted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Lead_PRMPortal_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Lead_PRMPortalEventsProcess

	/// <exclude/>
	public partial class Lead_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.Lead_OrderLeadEventsProcess<TEntity> where TEntity : Lead_PRMPortal_BPMSoft
	{

		public Lead_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Lead_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("07b9e4ee-6b92-4a34-8444-7d9556c2adbb");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _eventSubProcess1_f68eb686c4e64d70bceadde0a0538834;
		public ProcessFlowElement EventSubProcess1_f68eb686c4e64d70bceadde0a0538834 {
			get {
				return _eventSubProcess1_f68eb686c4e64d70bceadde0a0538834 ?? (_eventSubProcess1_f68eb686c4e64d70bceadde0a0538834 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess1_f68eb686c4e64d70bceadde0a0538834",
					SchemaElementUId = new Guid("f68eb686-c4e6-4d70-bcea-dde0a0538834"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _pRMPortalLeadInsertedStartMessage;
		public ProcessFlowElement PRMPortalLeadInsertedStartMessage {
			get {
				return _pRMPortalLeadInsertedStartMessage ?? (_pRMPortalLeadInsertedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "PRMPortalLeadInsertedStartMessage",
					SchemaElementUId = new Guid("ead724f6-3871-4b67-8b91-89f21e9b822d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask1_d870fe5b381b4e81a5460d80276ae41e;
		public ProcessScriptTask ScriptTask1_d870fe5b381b4e81a5460d80276ae41e {
			get {
				return _scriptTask1_d870fe5b381b4e81a5460d80276ae41e ?? (_scriptTask1_d870fe5b381b4e81a5460d80276ae41e = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask1_d870fe5b381b4e81a5460d80276ae41e",
					SchemaElementUId = new Guid("d870fe5b-381b-4e81-a546-0d80276ae41e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask1_d870fe5b381b4e81a5460d80276ae41eExecute,
				});
			}
		}

		private ProcessTerminateEvent _terminateEvent1_91862e76ec2a4f9ba31e1c3349553cd7;
		public ProcessTerminateEvent TerminateEvent1_91862e76ec2a4f9ba31e1c3349553cd7 {
			get {
				return _terminateEvent1_91862e76ec2a4f9ba31e1c3349553cd7 ?? (_terminateEvent1_91862e76ec2a4f9ba31e1c3349553cd7 = new ProcessTerminateEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaTerminateEvent",
					Name = "TerminateEvent1_91862e76ec2a4f9ba31e1c3349553cd7",
					SchemaElementUId = new Guid("91862e76-ec2a-4f9b-a31e-1c3349553cd7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1_f68eb686c4e64d70bceadde0a0538834.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1_f68eb686c4e64d70bceadde0a0538834 };
			FlowElements[PRMPortalLeadInsertedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { PRMPortalLeadInsertedStartMessage };
			FlowElements[ScriptTask1_d870fe5b381b4e81a5460d80276ae41e.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask1_d870fe5b381b4e81a5460d80276ae41e };
			FlowElements[TerminateEvent1_91862e76ec2a4f9ba31e1c3349553cd7.SchemaElementUId] = new Collection<ProcessFlowElement> { TerminateEvent1_91862e76ec2a4f9ba31e1c3349553cd7 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1_f68eb686c4e64d70bceadde0a0538834":
						break;
					case "PRMPortalLeadInsertedStartMessage":
						e.Context.QueueTasks.Enqueue("ScriptTask1_d870fe5b381b4e81a5460d80276ae41e");
						break;
					case "ScriptTask1_d870fe5b381b4e81a5460d80276ae41e":
						e.Context.QueueTasks.Enqueue("TerminateEvent1_91862e76ec2a4f9ba31e1c3349553cd7");
						break;
					case "TerminateEvent1_91862e76ec2a4f9ba31e1c3349553cd7":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("PRMPortalLeadInsertedStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess1_f68eb686c4e64d70bceadde0a0538834":
					context.QueueTasks.Dequeue();
					break;
				case "PRMPortalLeadInsertedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "PRMPortalLeadInsertedStartMessage";
					result = PRMPortalLeadInsertedStartMessage.Execute(context);
					break;
				case "ScriptTask1_d870fe5b381b4e81a5460d80276ae41e":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask1_d870fe5b381b4e81a5460d80276ae41e";
					result = ScriptTask1_d870fe5b381b4e81a5460d80276ae41e.Execute(context, ScriptTask1_d870fe5b381b4e81a5460d80276ae41eExecute);
					break;
				case "TerminateEvent1_91862e76ec2a4f9ba31e1c3349553cd7":
					context.QueueTasks.Dequeue();
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptTask1_d870fe5b381b4e81a5460d80276ae41eExecute(ProcessExecutingContext context) {
			PartnerGrantRight();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "Lead_PRMPortal_BPMSoftInserted":
							if (ActivatedEventElements.Contains("PRMPortalLeadInsertedStartMessage")) {
							context.QueueTasks.Enqueue("PRMPortalLeadInsertedStartMessage");
							ProcessQueue(context);
							return;
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: Lead_PRMPortalEventsProcess

	/// <exclude/>
	public class Lead_PRMPortalEventsProcess : Lead_PRMPortalEventsProcess<Lead_PRMPortal_BPMSoft>
	{

		public Lead_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

