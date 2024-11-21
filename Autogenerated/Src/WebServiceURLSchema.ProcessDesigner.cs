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

	#region Class: WebServiceURLSchema

	/// <exclude/>
	public class WebServiceURLSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public WebServiceURLSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public WebServiceURLSchema(WebServiceURLSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public WebServiceURLSchema(WebServiceURLSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("543e7919-0d37-4610-a08f-443e8605f9bc");
			RealUId = new Guid("543e7919-0d37-4610-a08f-443e8605f9bc");
			Name = "WebServiceURL";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("47c22e57-1b16-4004-8f6b-0f257046428b");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateURLColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("eed5f6a4-93d3-4b74-afff-027b0e407504")) == null) {
				Columns.Add(CreateWebServiceColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("543e7919-0d37-4610-a08f-443e8605f9bc");
			column.CreatedInPackageId = new Guid("47c22e57-1b16-4004-8f6b-0f257046428b");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("543e7919-0d37-4610-a08f-443e8605f9bc");
			column.CreatedInPackageId = new Guid("47c22e57-1b16-4004-8f6b-0f257046428b");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("543e7919-0d37-4610-a08f-443e8605f9bc");
			column.CreatedInPackageId = new Guid("47c22e57-1b16-4004-8f6b-0f257046428b");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("543e7919-0d37-4610-a08f-443e8605f9bc");
			column.CreatedInPackageId = new Guid("47c22e57-1b16-4004-8f6b-0f257046428b");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("543e7919-0d37-4610-a08f-443e8605f9bc");
			column.CreatedInPackageId = new Guid("47c22e57-1b16-4004-8f6b-0f257046428b");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("543e7919-0d37-4610-a08f-443e8605f9bc");
			column.CreatedInPackageId = new Guid("47c22e57-1b16-4004-8f6b-0f257046428b");
			return column;
		}

		protected virtual EntitySchemaColumn CreateURLColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("62951142-48fe-4a39-a5e4-e8fc3da163c8"),
				Name = @"URL",
				CreatedInSchemaUId = new Guid("543e7919-0d37-4610-a08f-443e8605f9bc"),
				ModifiedInSchemaUId = new Guid("543e7919-0d37-4610-a08f-443e8605f9bc"),
				CreatedInPackageId = new Guid("47c22e57-1b16-4004-8f6b-0f257046428b")
			};
		}

		protected virtual EntitySchemaColumn CreateWebServiceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("eed5f6a4-93d3-4b74-afff-027b0e407504"),
				Name = @"WebService",
				ReferenceSchemaUId = new Guid("34a72c74-848f-4081-86c8-87310ee15fb5"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("543e7919-0d37-4610-a08f-443e8605f9bc"),
				ModifiedInSchemaUId = new Guid("543e7919-0d37-4610-a08f-443e8605f9bc"),
				CreatedInPackageId = new Guid("b25ba612-51fa-4b36-88e3-e38746f7044b")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new WebServiceURL(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new WebServiceURL_ProcessDesignerEventsProcess(userConnection);
		}

		public override object Clone() {
			return new WebServiceURLSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new WebServiceURLSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("543e7919-0d37-4610-a08f-443e8605f9bc"));
		}

		#endregion

	}

	#endregion

	#region Class: WebServiceURL

	/// <summary>
	/// Web service address.
	/// </summary>
	public class WebServiceURL : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public WebServiceURL(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "WebServiceURL";
		}

		public WebServiceURL(WebServiceURL source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// URL.
		/// </summary>
		public string URL {
			get {
				return GetTypedColumnValue<string>("URL");
			}
			set {
				SetColumnValue("URL", value);
			}
		}

		/// <exclude/>
		public Guid WebServiceId {
			get {
				return GetTypedColumnValue<Guid>("WebServiceId");
			}
			set {
				SetColumnValue("WebServiceId", value);
				_webService = null;
			}
		}

		/// <exclude/>
		public string WebServiceName {
			get {
				return GetTypedColumnValue<string>("WebServiceName");
			}
			set {
				SetColumnValue("WebServiceName", value);
				if (_webService != null) {
					_webService.Name = value;
				}
			}
		}

		private WebService _webService;
		/// <summary>
		/// Web service.
		/// </summary>
		public WebService WebService {
			get {
				return _webService ??
					(_webService = LookupColumnEntities.GetEntity("WebService") as WebService);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new WebServiceURL_ProcessDesignerEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("WebServiceURLDeleted", e);
			Deleting += (s, e) => ThrowEvent("WebServiceURLDeleting", e);
			Inserting += (s, e) => ThrowEvent("WebServiceURLInserting", e);
			Saving += (s, e) => ThrowEvent("WebServiceURLSaving", e);
			Validating += (s, e) => ThrowEvent("WebServiceURLValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new WebServiceURL(this);
		}

		#endregion

	}

	#endregion

	#region Class: WebServiceURL_ProcessDesignerEventsProcess

	/// <exclude/>
	public partial class WebServiceURL_ProcessDesignerEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : WebServiceURL
	{

		public WebServiceURL_ProcessDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "WebServiceURL_ProcessDesignerEventsProcess";
			SchemaUId = new Guid("543e7919-0d37-4610-a08f-443e8605f9bc");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("543e7919-0d37-4610-a08f-443e8605f9bc");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _webServiceURLEventSubProcess;
		public ProcessFlowElement WebServiceURLEventSubProcess {
			get {
				return _webServiceURLEventSubProcess ?? (_webServiceURLEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "WebServiceURLEventSubProcess",
					SchemaElementUId = new Guid("d82fea9a-f0ca-4005-94b4-f05dc2177da8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _webServiceURLInsertingStartMessage;
		public ProcessFlowElement WebServiceURLInsertingStartMessage {
			get {
				return _webServiceURLInsertingStartMessage ?? (_webServiceURLInsertingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "WebServiceURLInsertingStartMessage",
					SchemaElementUId = new Guid("29868cf6-3162-4414-aa4f-542feb36a19c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _webServiceURLSavingStartMessage;
		public ProcessFlowElement WebServiceURLSavingStartMessage {
			get {
				return _webServiceURLSavingStartMessage ?? (_webServiceURLSavingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "WebServiceURLSavingStartMessage",
					SchemaElementUId = new Guid("18472a68-df48-4dcb-991b-68258be35494"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _webServiceURLDeletingStartMessage;
		public ProcessFlowElement WebServiceURLDeletingStartMessage {
			get {
				return _webServiceURLDeletingStartMessage ?? (_webServiceURLDeletingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "WebServiceURLDeletingStartMessage",
					SchemaElementUId = new Guid("04a03ded-f627-4d71-8130-8c36feabf095"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _checkCanManageLookupsScriptTask;
		public ProcessScriptTask CheckCanManageLookupsScriptTask {
			get {
				return _checkCanManageLookupsScriptTask ?? (_checkCanManageLookupsScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "CheckCanManageLookupsScriptTask",
					SchemaElementUId = new Guid("d33c6259-764e-4be4-afe5-675d518cc310"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = CheckCanManageLookupsScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[WebServiceURLEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { WebServiceURLEventSubProcess };
			FlowElements[WebServiceURLInsertingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { WebServiceURLInsertingStartMessage };
			FlowElements[WebServiceURLSavingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { WebServiceURLSavingStartMessage };
			FlowElements[WebServiceURLDeletingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { WebServiceURLDeletingStartMessage };
			FlowElements[CheckCanManageLookupsScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { CheckCanManageLookupsScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "WebServiceURLEventSubProcess":
						break;
					case "WebServiceURLInsertingStartMessage":
						e.Context.QueueTasks.Enqueue("CheckCanManageLookupsScriptTask");
						break;
					case "WebServiceURLSavingStartMessage":
						e.Context.QueueTasks.Enqueue("CheckCanManageLookupsScriptTask");
						break;
					case "WebServiceURLDeletingStartMessage":
						e.Context.QueueTasks.Enqueue("CheckCanManageLookupsScriptTask");
						break;
					case "CheckCanManageLookupsScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("WebServiceURLInsertingStartMessage");
			ActivatedEventElements.Add("WebServiceURLSavingStartMessage");
			ActivatedEventElements.Add("WebServiceURLDeletingStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "WebServiceURLEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "WebServiceURLInsertingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "WebServiceURLInsertingStartMessage";
					result = WebServiceURLInsertingStartMessage.Execute(context);
					break;
				case "WebServiceURLSavingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "WebServiceURLSavingStartMessage";
					result = WebServiceURLSavingStartMessage.Execute(context);
					break;
				case "WebServiceURLDeletingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "WebServiceURLDeletingStartMessage";
					result = WebServiceURLDeletingStartMessage.Execute(context);
					break;
				case "CheckCanManageLookupsScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "CheckCanManageLookupsScriptTask";
					result = CheckCanManageLookupsScriptTask.Execute(context, CheckCanManageLookupsScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool CheckCanManageLookupsScriptTaskExecute(ProcessExecutingContext context) {
			UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageLookups");
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "WebServiceURLInserting":
							if (ActivatedEventElements.Contains("WebServiceURLInsertingStartMessage")) {
							context.QueueTasks.Enqueue("WebServiceURLInsertingStartMessage");
						}
						break;
					case "WebServiceURLSaving":
							if (ActivatedEventElements.Contains("WebServiceURLSavingStartMessage")) {
							context.QueueTasks.Enqueue("WebServiceURLSavingStartMessage");
						}
						break;
					case "WebServiceURLDeleting":
							if (ActivatedEventElements.Contains("WebServiceURLDeletingStartMessage")) {
							context.QueueTasks.Enqueue("WebServiceURLDeletingStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: WebServiceURL_ProcessDesignerEventsProcess

	/// <exclude/>
	public class WebServiceURL_ProcessDesignerEventsProcess : WebServiceURL_ProcessDesignerEventsProcess<WebServiceURL>
	{

		public WebServiceURL_ProcessDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: WebServiceURL_ProcessDesignerEventsProcess

	public partial class WebServiceURL_ProcessDesignerEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: WebServiceURLEventsProcess

	/// <exclude/>
	public class WebServiceURLEventsProcess : WebServiceURL_ProcessDesignerEventsProcess
	{

		public WebServiceURLEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

