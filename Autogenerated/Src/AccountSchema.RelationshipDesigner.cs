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

	#region Class: Account_RelationshipDesigner_BPMSoftSchema

	/// <exclude/>
	public class Account_RelationshipDesigner_BPMSoftSchema : BPMSoft.Configuration.Account_EmailMining_BPMSoftSchema
	{

		#region Constructors: Public

		public Account_RelationshipDesigner_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Account_RelationshipDesigner_BPMSoftSchema(Account_RelationshipDesigner_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Account_RelationshipDesigner_BPMSoftSchema(Account_RelationshipDesigner_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("6e234650-3cda-4290-b44e-cd0f9b0dfa08");
			Name = "Account_RelationshipDesigner_BPMSoft";
			ParentSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e");
			ExtendParent = true;
			CreatedInPackageId = new Guid("32e5a92e-2a79-472b-b08d-f730aa69067f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a4362aa9-f7a2-4491-9072-a8cc46aaa42c")) == null) {
				Columns.Add(CreateAUMColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateAUMColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Text")) {
				UId = new Guid("a4362aa9-f7a2-4491-9072-a8cc46aaa42c"),
				Name = @"AUM",
				CreatedInSchemaUId = new Guid("6e234650-3cda-4290-b44e-cd0f9b0dfa08"),
				ModifiedInSchemaUId = new Guid("6e234650-3cda-4290-b44e-cd0f9b0dfa08"),
				CreatedInPackageId = new Guid("32e5a92e-2a79-472b-b08d-f730aa69067f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Account_RelationshipDesigner_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Account_RelationshipDesignerEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Account_RelationshipDesigner_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Account_RelationshipDesigner_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6e234650-3cda-4290-b44e-cd0f9b0dfa08"));
		}

		#endregion

	}

	#endregion

	#region Class: Account_RelationshipDesigner_BPMSoft

	/// <summary>
	/// Account.
	/// </summary>
	public class Account_RelationshipDesigner_BPMSoft : BPMSoft.Configuration.Account_EmailMining_BPMSoft
	{

		#region Constructors: Public

		public Account_RelationshipDesigner_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Account_RelationshipDesigner_BPMSoft";
		}

		public Account_RelationshipDesigner_BPMSoft(Account_RelationshipDesigner_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// AUM.
		/// </summary>
		public string AUM {
			get {
				return GetTypedColumnValue<string>("AUM");
			}
			set {
				SetColumnValue("AUM", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Account_RelationshipDesignerEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Account_RelationshipDesigner_BPMSoftDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Account_RelationshipDesigner_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Account_RelationshipDesignerEventsProcess

	/// <exclude/>
	public partial class Account_RelationshipDesignerEventsProcess<TEntity> : BPMSoft.Configuration.Account_EmailMiningEventsProcess<TEntity> where TEntity : Account_RelationshipDesigner_BPMSoft
	{

		public Account_RelationshipDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Account_RelationshipDesignerEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6e234650-3cda-4290-b44e-cd0f9b0dfa08");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _eventSubProcess4_ac206982e5ca4dbf8d9b2a73decaf31d;
		public ProcessFlowElement EventSubProcess4_ac206982e5ca4dbf8d9b2a73decaf31d {
			get {
				return _eventSubProcess4_ac206982e5ca4dbf8d9b2a73decaf31d ?? (_eventSubProcess4_ac206982e5ca4dbf8d9b2a73decaf31d = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess4_ac206982e5ca4dbf8d9b2a73decaf31d",
					SchemaElementUId = new Guid("ac206982-e5ca-4dbf-8d9b-2a73decaf31d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessage3_a5eaf572417549caab47cfdb2838b4af;
		public ProcessFlowElement StartMessage3_a5eaf572417549caab47cfdb2838b4af {
			get {
				return _startMessage3_a5eaf572417549caab47cfdb2838b4af ?? (_startMessage3_a5eaf572417549caab47cfdb2838b4af = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage3_a5eaf572417549caab47cfdb2838b4af",
					SchemaElementUId = new Guid("a5eaf572-4175-49ca-ab47-cfdb2838b4af"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask3_577e941aadef43acaa01570ead570c0a;
		public ProcessScriptTask ScriptTask3_577e941aadef43acaa01570ead570c0a {
			get {
				return _scriptTask3_577e941aadef43acaa01570ead570c0a ?? (_scriptTask3_577e941aadef43acaa01570ead570c0a = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask3_577e941aadef43acaa01570ead570c0a",
					SchemaElementUId = new Guid("577e941a-adef-43ac-aa01-570ead570c0a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask3_577e941aadef43acaa01570ead570c0aExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess4_ac206982e5ca4dbf8d9b2a73decaf31d.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess4_ac206982e5ca4dbf8d9b2a73decaf31d };
			FlowElements[StartMessage3_a5eaf572417549caab47cfdb2838b4af.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage3_a5eaf572417549caab47cfdb2838b4af };
			FlowElements[ScriptTask3_577e941aadef43acaa01570ead570c0a.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask3_577e941aadef43acaa01570ead570c0a };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess4_ac206982e5ca4dbf8d9b2a73decaf31d":
						break;
					case "StartMessage3_a5eaf572417549caab47cfdb2838b4af":
						e.Context.QueueTasks.Enqueue("ScriptTask3_577e941aadef43acaa01570ead570c0a");
						break;
					case "ScriptTask3_577e941aadef43acaa01570ead570c0a":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("StartMessage3_a5eaf572417549caab47cfdb2838b4af");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess4_ac206982e5ca4dbf8d9b2a73decaf31d":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessage3_a5eaf572417549caab47cfdb2838b4af":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage3_a5eaf572417549caab47cfdb2838b4af";
					result = StartMessage3_a5eaf572417549caab47cfdb2838b4af.Execute(context);
					break;
				case "ScriptTask3_577e941aadef43acaa01570ead570c0a":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask3_577e941aadef43acaa01570ead570c0a";
					result = ScriptTask3_577e941aadef43acaa01570ead570c0a.Execute(context, ScriptTask3_577e941aadef43acaa01570ead570c0aExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptTask3_577e941aadef43acaa01570ead570c0aExecute(ProcessExecutingContext context) {
			return DeleteRelationshipEntity();
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "Account_RelationshipDesigner_BPMSoftDeleted":
							if (ActivatedEventElements.Contains("StartMessage3_a5eaf572417549caab47cfdb2838b4af")) {
							context.QueueTasks.Enqueue("StartMessage3_a5eaf572417549caab47cfdb2838b4af");
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

	#region Class: Account_RelationshipDesignerEventsProcess

	/// <exclude/>
	public class Account_RelationshipDesignerEventsProcess : Account_RelationshipDesignerEventsProcess<Account_RelationshipDesigner_BPMSoft>
	{

		public Account_RelationshipDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

