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

	#region Class: QueueUpdateFrequencySchema

	/// <exclude/>
	public class QueueUpdateFrequencySchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public QueueUpdateFrequencySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public QueueUpdateFrequencySchema(QueueUpdateFrequencySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public QueueUpdateFrequencySchema(QueueUpdateFrequencySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("658c1af2-df48-464c-9257-0245f5460090");
			RealUId = new Guid("658c1af2-df48-464c-9257-0245f5460090");
			Name = "QueueUpdateFrequency";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("96ba3f81-7af1-43c9-9a5b-ab40bf0d009a");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("104e6ad9-b211-4286-a3b8-62e29ae8a322")) == null) {
				Columns.Add(CreateFrequencyColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateFrequencyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("104e6ad9-b211-4286-a3b8-62e29ae8a322"),
				Name = @"Frequency",
				CreatedInSchemaUId = new Guid("658c1af2-df48-464c-9257-0245f5460090"),
				ModifiedInSchemaUId = new Guid("658c1af2-df48-464c-9257-0245f5460090"),
				CreatedInPackageId = new Guid("96ba3f81-7af1-43c9-9a5b-ab40bf0d009a")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new QueueUpdateFrequency(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new QueueUpdateFrequency_OperatorSingleWindowEventsProcess(userConnection);
		}

		public override object Clone() {
			return new QueueUpdateFrequencySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new QueueUpdateFrequencySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("658c1af2-df48-464c-9257-0245f5460090"));
		}

		#endregion

	}

	#endregion

	#region Class: QueueUpdateFrequency

	/// <summary>
	/// Частота обновления очереди .
	/// </summary>
	public class QueueUpdateFrequency : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public QueueUpdateFrequency(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "QueueUpdateFrequency";
		}

		public QueueUpdateFrequency(QueueUpdateFrequency source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Частота обновления в минутах.
		/// </summary>
		public int Frequency {
			get {
				return GetTypedColumnValue<int>("Frequency");
			}
			set {
				SetColumnValue("Frequency", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new QueueUpdateFrequency_OperatorSingleWindowEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("QueueUpdateFrequencyDeleted", e);
			Saved += (s, e) => ThrowEvent("QueueUpdateFrequencySaved", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new QueueUpdateFrequency(this);
		}

		#endregion

	}

	#endregion

	#region Class: QueueUpdateFrequency_OperatorSingleWindowEventsProcess

	/// <exclude/>
	public partial class QueueUpdateFrequency_OperatorSingleWindowEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : QueueUpdateFrequency
	{

		public QueueUpdateFrequency_OperatorSingleWindowEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "QueueUpdateFrequency_OperatorSingleWindowEventsProcess";
			SchemaUId = new Guid("658c1af2-df48-464c-9257-0245f5460090");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("658c1af2-df48-464c-9257-0245f5460090");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _eventSubProcess3_331342c9982c4a4281870bdb5ed2e659;
		public ProcessFlowElement EventSubProcess3_331342c9982c4a4281870bdb5ed2e659 {
			get {
				return _eventSubProcess3_331342c9982c4a4281870bdb5ed2e659 ?? (_eventSubProcess3_331342c9982c4a4281870bdb5ed2e659 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess3_331342c9982c4a4281870bdb5ed2e659",
					SchemaElementUId = new Guid("331342c9-982c-4a42-8187-0bdb5ed2e659"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessage3_9296aa43d7634650b0f333c745a017cb;
		public ProcessFlowElement StartMessage3_9296aa43d7634650b0f333c745a017cb {
			get {
				return _startMessage3_9296aa43d7634650b0f333c745a017cb ?? (_startMessage3_9296aa43d7634650b0f333c745a017cb = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage3_9296aa43d7634650b0f333c745a017cb",
					SchemaElementUId = new Guid("9296aa43-d763-4650-b0f3-33c745a017cb"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask3_acfc7a7ed8484fc8aab5052a157f0173;
		public ProcessScriptTask ScriptTask3_acfc7a7ed8484fc8aab5052a157f0173 {
			get {
				return _scriptTask3_acfc7a7ed8484fc8aab5052a157f0173 ?? (_scriptTask3_acfc7a7ed8484fc8aab5052a157f0173 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask3_acfc7a7ed8484fc8aab5052a157f0173",
					SchemaElementUId = new Guid("acfc7a7e-d848-4fc8-aab5-052a157f0173"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask3_acfc7a7ed8484fc8aab5052a157f0173Execute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess3_331342c9982c4a4281870bdb5ed2e659.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess3_331342c9982c4a4281870bdb5ed2e659 };
			FlowElements[StartMessage3_9296aa43d7634650b0f333c745a017cb.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage3_9296aa43d7634650b0f333c745a017cb };
			FlowElements[ScriptTask3_acfc7a7ed8484fc8aab5052a157f0173.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask3_acfc7a7ed8484fc8aab5052a157f0173 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess3_331342c9982c4a4281870bdb5ed2e659":
						break;
					case "StartMessage3_9296aa43d7634650b0f333c745a017cb":
						e.Context.QueueTasks.Enqueue("ScriptTask3_acfc7a7ed8484fc8aab5052a157f0173");
						break;
					case "ScriptTask3_acfc7a7ed8484fc8aab5052a157f0173":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("StartMessage3_9296aa43d7634650b0f333c745a017cb");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess3_331342c9982c4a4281870bdb5ed2e659":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessage3_9296aa43d7634650b0f333c745a017cb":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage3_9296aa43d7634650b0f333c745a017cb";
					result = StartMessage3_9296aa43d7634650b0f333c745a017cb.Execute(context);
					break;
				case "ScriptTask3_acfc7a7ed8484fc8aab5052a157f0173":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask3_acfc7a7ed8484fc8aab5052a157f0173";
					result = ScriptTask3_acfc7a7ed8484fc8aab5052a157f0173.Execute(context, ScriptTask3_acfc7a7ed8484fc8aab5052a157f0173Execute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptTask3_acfc7a7ed8484fc8aab5052a157f0173Execute(ProcessExecutingContext context) {
			QueueCacheHelper.ClearCache();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "QueueUpdateFrequencySaved":
							if (ActivatedEventElements.Contains("StartMessage3_9296aa43d7634650b0f333c745a017cb")) {
							context.QueueTasks.Enqueue("StartMessage3_9296aa43d7634650b0f333c745a017cb");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: QueueUpdateFrequency_OperatorSingleWindowEventsProcess

	/// <exclude/>
	public class QueueUpdateFrequency_OperatorSingleWindowEventsProcess : QueueUpdateFrequency_OperatorSingleWindowEventsProcess<QueueUpdateFrequency>
	{

		public QueueUpdateFrequency_OperatorSingleWindowEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: QueueUpdateFrequency_OperatorSingleWindowEventsProcess

	public partial class QueueUpdateFrequency_OperatorSingleWindowEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: QueueUpdateFrequencyEventsProcess

	/// <exclude/>
	public class QueueUpdateFrequencyEventsProcess : QueueUpdateFrequency_OperatorSingleWindowEventsProcess
	{

		public QueueUpdateFrequencyEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

