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
	using BPMSoft.Messaging.Common;
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

	#region Class: MailServerSchema

	/// <exclude/>
	public class MailServerSchema : BPMSoft.Configuration.MailServer_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public MailServerSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MailServerSchema(MailServerSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MailServerSchema(MailServerSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("ba3d9f48-19a3-446a-ab3a-4fffeeba7983");
			Name = "MailServer";
			ParentSchemaUId = new Guid("7ba8351f-9a61-49e6-9e0d-8b32ed25c4c4");
			ExtendParent = true;
			CreatedInPackageId = new Guid("24c6dcbf-ddce-46c1-876f-ee548e2ae17a");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("ff05d2f5-bc16-4d80-b361-13120a07867e")) == null) {
				Columns.Add(CreateExchangeEmailAddressColumn());
			}
			if (Columns.FindByUId(new Guid("5a1ceded-281a-4994-bf5f-5fe57b752e0b")) == null) {
				Columns.Add(CreateIsExchengeAutodiscoverColumn());
			}
			if (Columns.FindByUId(new Guid("411a2310-81f3-4a83-896e-87eccdbae77f")) == null) {
				Columns.Add(CreateTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateExchangeEmailAddressColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("ff05d2f5-bc16-4d80-b361-13120a07867e"),
				Name = @"ExchangeEmailAddress",
				CreatedInSchemaUId = new Guid("ba3d9f48-19a3-446a-ab3a-4fffeeba7983"),
				ModifiedInSchemaUId = new Guid("ba3d9f48-19a3-446a-ab3a-4fffeeba7983"),
				CreatedInPackageId = new Guid("24c6dcbf-ddce-46c1-876f-ee548e2ae17a")
			};
		}

		protected virtual EntitySchemaColumn CreateIsExchengeAutodiscoverColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("5a1ceded-281a-4994-bf5f-5fe57b752e0b"),
				Name = @"IsExchengeAutodiscover",
				CreatedInSchemaUId = new Guid("ba3d9f48-19a3-446a-ab3a-4fffeeba7983"),
				ModifiedInSchemaUId = new Guid("ba3d9f48-19a3-446a-ab3a-4fffeeba7983"),
				CreatedInPackageId = new Guid("24c6dcbf-ddce-46c1-876f-ee548e2ae17a")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("411a2310-81f3-4a83-896e-87eccdbae77f"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("2db96124-22df-41dd-a3ce-9c12e32a78be"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ba3d9f48-19a3-446a-ab3a-4fffeeba7983"),
				ModifiedInSchemaUId = new Guid("ba3d9f48-19a3-446a-ab3a-4fffeeba7983"),
				CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MailServer(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MailServer_ExchangeEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MailServerSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MailServerSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ba3d9f48-19a3-446a-ab3a-4fffeeba7983"));
		}

		#endregion

	}

	#endregion

	#region Class: MailServer

	/// <summary>
	/// Почтовый провайдер.
	/// </summary>
	public class MailServer : BPMSoft.Configuration.MailServer_Base_BPMSoft
	{

		#region Constructors: Public

		public MailServer(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MailServer";
		}

		public MailServer(MailServer source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Адрес сервера.
		/// </summary>
		public string ExchangeEmailAddress {
			get {
				return GetTypedColumnValue<string>("ExchangeEmailAddress");
			}
			set {
				SetColumnValue("ExchangeEmailAddress", value);
			}
		}

		/// <summary>
		/// Автообнаружение.
		/// </summary>
		public bool IsExchengeAutodiscover {
			get {
				return GetTypedColumnValue<bool>("IsExchengeAutodiscover");
			}
			set {
				SetColumnValue("IsExchengeAutodiscover", value);
			}
		}

		/// <exclude/>
		public Guid TypeId {
			get {
				return GetTypedColumnValue<Guid>("TypeId");
			}
			set {
				SetColumnValue("TypeId", value);
				_type = null;
			}
		}

		/// <exclude/>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
				if (_type != null) {
					_type.Name = value;
				}
			}
		}

		private MailServerType _type;
		/// <summary>
		/// Тип почтового провайдера.
		/// </summary>
		public MailServerType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as MailServerType);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MailServer_ExchangeEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MailServerDeleted", e);
			Inserting += (s, e) => ThrowEvent("MailServerInserting", e);
			Saved += (s, e) => ThrowEvent("MailServerSaved", e);
			Updated += (s, e) => ThrowEvent("MailServerUpdated", e);
			Validating += (s, e) => ThrowEvent("MailServerValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MailServer(this);
		}

		#endregion

	}

	#endregion

	#region Class: MailServer_ExchangeEventsProcess

	/// <exclude/>
	public partial class MailServer_ExchangeEventsProcess<TEntity> : BPMSoft.Configuration.MailServer_BaseEventsProcess<TEntity> where TEntity : MailServer
	{

		public MailServer_ExchangeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MailServer_ExchangeEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ba3d9f48-19a3-446a-ab3a-4fffeeba7983");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _mailServerSavedMessageScriptTaskEventSubProcess;
		public ProcessFlowElement MailServerSavedMessageScriptTaskEventSubProcess {
			get {
				return _mailServerSavedMessageScriptTaskEventSubProcess ?? (_mailServerSavedMessageScriptTaskEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "MailServerSavedMessageScriptTaskEventSubProcess",
					SchemaElementUId = new Guid("5e344bce-7db3-42b7-a8fe-de9d5b6059bb"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _mailServerSavedMessage;
		public ProcessFlowElement MailServerSavedMessage {
			get {
				return _mailServerSavedMessage ?? (_mailServerSavedMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "MailServerSavedMessage",
					SchemaElementUId = new Guid("092c1d5c-f04d-41fc-a9ed-767c9f3689e3"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _mailServerSavedMessageScriptTask;
		public ProcessScriptTask MailServerSavedMessageScriptTask {
			get {
				return _mailServerSavedMessageScriptTask ?? (_mailServerSavedMessageScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "MailServerSavedMessageScriptTask",
					SchemaElementUId = new Guid("3e5f7719-c36f-45d3-b395-5a4db0c179a0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = MailServerSavedMessageScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[MailServerSavedMessageScriptTaskEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { MailServerSavedMessageScriptTaskEventSubProcess };
			FlowElements[MailServerSavedMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { MailServerSavedMessage };
			FlowElements[MailServerSavedMessageScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { MailServerSavedMessageScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "MailServerSavedMessageScriptTaskEventSubProcess":
						break;
					case "MailServerSavedMessage":
						e.Context.QueueTasks.Enqueue("MailServerSavedMessageScriptTask");
						break;
					case "MailServerSavedMessageScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("MailServerSavedMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "MailServerSavedMessageScriptTaskEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "MailServerSavedMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "MailServerSavedMessage";
					result = MailServerSavedMessage.Execute(context);
					break;
				case "MailServerSavedMessageScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "MailServerSavedMessageScriptTask";
					result = MailServerSavedMessageScriptTask.Execute(context, MailServerSavedMessageScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool MailServerSavedMessageScriptTaskExecute(ProcessExecutingContext context) {
			if (Entity.AllowEmailDownloading == false) {
				Update allowEmailDownloadingUpdate = new Update(UserConnection, "MailboxSyncSettings")
					.Set("EnableMailSynhronization", Column.Parameter(false))
					.Where("MailServerId").IsEqual(Column.Parameter(Entity.Id)) as Update;
				allowEmailDownloadingUpdate.Execute();
				RemoveMailboxSyncSettingsJob();
			}
			if (Entity.AllowEmailSending == false) {
				Update allowEmailSendingUpdate = new Update(UserConnection, "MailboxSyncSettings")
					.Set("SendEmailsViaThisAccount", Column.Parameter(false))
					.Where("MailServerId").IsEqual(Column.Parameter(Entity.Id)) as Update;
				allowEmailSendingUpdate.Execute();
			}
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "MailServerSaved":
							if (ActivatedEventElements.Contains("MailServerSavedMessage")) {
							context.QueueTasks.Enqueue("MailServerSavedMessage");
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

	#region Class: MailServer_ExchangeEventsProcess

	/// <exclude/>
	public class MailServer_ExchangeEventsProcess : MailServer_ExchangeEventsProcess<MailServer>
	{

		public MailServer_ExchangeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion


	#region Class: MailServerEventsProcess

	/// <exclude/>
	public class MailServerEventsProcess : MailServer_ExchangeEventsProcess
	{

		public MailServerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

