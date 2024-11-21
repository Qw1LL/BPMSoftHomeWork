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

	#region Class: QueueStatusSchema

	/// <exclude/>
	public class QueueStatusSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public QueueStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public QueueStatusSchema(QueueStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public QueueStatusSchema(QueueStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("749b84e0-9db9-4883-9303-ffc09ea14ecc");
			RealUId = new Guid("749b84e0-9db9-4883-9303-ffc09ea14ecc");
			Name = "QueueStatus";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f218b7b3-8c78-4ff0-aa0a-44d361bf4ae4");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("62d58a77-e861-4875-a481-f7ba7617949f")) == null) {
				Columns.Add(CreateIsInitialColumn());
			}
			if (Columns.FindByUId(new Guid("1125807f-5e6c-4a98-8c35-4e40db800ed1")) == null) {
				Columns.Add(CreateIsFinalColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIsInitialColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("62d58a77-e861-4875-a481-f7ba7617949f"),
				Name = @"IsInitial",
				CreatedInSchemaUId = new Guid("749b84e0-9db9-4883-9303-ffc09ea14ecc"),
				ModifiedInSchemaUId = new Guid("749b84e0-9db9-4883-9303-ffc09ea14ecc"),
				CreatedInPackageId = new Guid("7be0af39-38cd-442a-b589-d8f3ef3f4d19")
			};
		}

		protected virtual EntitySchemaColumn CreateIsFinalColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("1125807f-5e6c-4a98-8c35-4e40db800ed1"),
				Name = @"IsFinal",
				CreatedInSchemaUId = new Guid("749b84e0-9db9-4883-9303-ffc09ea14ecc"),
				ModifiedInSchemaUId = new Guid("749b84e0-9db9-4883-9303-ffc09ea14ecc"),
				CreatedInPackageId = new Guid("7be0af39-38cd-442a-b589-d8f3ef3f4d19")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new QueueStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new QueueStatus_OperatorSingleWindowEventsProcess(userConnection);
		}

		public override object Clone() {
			return new QueueStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new QueueStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("749b84e0-9db9-4883-9303-ffc09ea14ecc"));
		}

		#endregion

	}

	#endregion

	#region Class: QueueStatus

	/// <summary>
	/// Состояние очереди единого окна.
	/// </summary>
	public class QueueStatus : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public QueueStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "QueueStatus";
		}

		public QueueStatus(QueueStatus source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Начальное.
		/// </summary>
		public bool IsInitial {
			get {
				return GetTypedColumnValue<bool>("IsInitial");
			}
			set {
				SetColumnValue("IsInitial", value);
			}
		}

		/// <summary>
		/// Конечное.
		/// </summary>
		public bool IsFinal {
			get {
				return GetTypedColumnValue<bool>("IsFinal");
			}
			set {
				SetColumnValue("IsFinal", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new QueueStatus_OperatorSingleWindowEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("QueueStatusDeleted", e);
			Saved += (s, e) => ThrowEvent("QueueStatusSaved", e);
			Validating += (s, e) => ThrowEvent("QueueStatusValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new QueueStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: QueueStatus_OperatorSingleWindowEventsProcess

	/// <exclude/>
	public partial class QueueStatus_OperatorSingleWindowEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : QueueStatus
	{

		public QueueStatus_OperatorSingleWindowEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "QueueStatus_OperatorSingleWindowEventsProcess";
			SchemaUId = new Guid("749b84e0-9db9-4883-9303-ffc09ea14ecc");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("749b84e0-9db9-4883-9303-ffc09ea14ecc");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _eventSubProcess3_fcae09c63f4e45bf843931f2d37e9dcf;
		public ProcessFlowElement EventSubProcess3_fcae09c63f4e45bf843931f2d37e9dcf {
			get {
				return _eventSubProcess3_fcae09c63f4e45bf843931f2d37e9dcf ?? (_eventSubProcess3_fcae09c63f4e45bf843931f2d37e9dcf = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess3_fcae09c63f4e45bf843931f2d37e9dcf",
					SchemaElementUId = new Guid("fcae09c6-3f4e-45bf-8439-31f2d37e9dcf"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _queueStatusSavedMessage;
		public ProcessFlowElement QueueStatusSavedMessage {
			get {
				return _queueStatusSavedMessage ?? (_queueStatusSavedMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "QueueStatusSavedMessage",
					SchemaElementUId = new Guid("062f67e3-4410-49e1-b59e-e4c6eecb5565"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask_QueueStatusSaved;
		public ProcessScriptTask ScriptTask_QueueStatusSaved {
			get {
				return _scriptTask_QueueStatusSaved ?? (_scriptTask_QueueStatusSaved = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask_QueueStatusSaved",
					SchemaElementUId = new Guid("4af156eb-0dc6-457e-88c1-3f147effce17"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask_QueueStatusSavedExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess3_fcae09c63f4e45bf843931f2d37e9dcf.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess3_fcae09c63f4e45bf843931f2d37e9dcf };
			FlowElements[QueueStatusSavedMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { QueueStatusSavedMessage };
			FlowElements[ScriptTask_QueueStatusSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask_QueueStatusSaved };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess3_fcae09c63f4e45bf843931f2d37e9dcf":
						break;
					case "QueueStatusSavedMessage":
						e.Context.QueueTasks.Enqueue("ScriptTask_QueueStatusSaved");
						break;
					case "ScriptTask_QueueStatusSaved":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("QueueStatusSavedMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess3_fcae09c63f4e45bf843931f2d37e9dcf":
					context.QueueTasks.Dequeue();
					break;
				case "QueueStatusSavedMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "QueueStatusSavedMessage";
					result = QueueStatusSavedMessage.Execute(context);
					break;
				case "ScriptTask_QueueStatusSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask_QueueStatusSaved";
					result = ScriptTask_QueueStatusSaved.Execute(context, ScriptTask_QueueStatusSavedExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptTask_QueueStatusSavedExecute(ProcessExecutingContext context) {
			QueueCacheHelper.ClearCache();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "QueueStatusSaved":
							if (ActivatedEventElements.Contains("QueueStatusSavedMessage")) {
							context.QueueTasks.Enqueue("QueueStatusSavedMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: QueueStatus_OperatorSingleWindowEventsProcess

	/// <exclude/>
	public class QueueStatus_OperatorSingleWindowEventsProcess : QueueStatus_OperatorSingleWindowEventsProcess<QueueStatus>
	{

		public QueueStatus_OperatorSingleWindowEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: QueueStatus_OperatorSingleWindowEventsProcess

	public partial class QueueStatus_OperatorSingleWindowEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: QueueStatusEventsProcess

	/// <exclude/>
	public class QueueStatusEventsProcess : QueueStatus_OperatorSingleWindowEventsProcess
	{

		public QueueStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

