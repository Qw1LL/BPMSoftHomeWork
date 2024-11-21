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

	#region Class: ListenerByNotifierSchema

	/// <exclude/>
	public class ListenerByNotifierSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ListenerByNotifierSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ListenerByNotifierSchema(ListenerByNotifierSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ListenerByNotifierSchema(ListenerByNotifierSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("63845207-7cec-41ff-baf5-425b69236020");
			RealUId = new Guid("63845207-7cec-41ff-baf5-425b69236020");
			Name = "ListenerByNotifier";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("b4ad7210-1e2c-4a25-8f9c-bff818d48783");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("b606eb57-6d58-435e-b69b-ac57d73c4c29")) == null) {
				Columns.Add(CreateMessageNotifierColumn());
			}
			if (Columns.FindByUId(new Guid("bf4e2548-f0a6-4b3f-bb6c-711826502b0d")) == null) {
				Columns.Add(CreateMessageListenerColumn());
			}
			if (Columns.FindByUId(new Guid("9deea5b1-d5bd-4c81-8e55-76d396376457")) == null) {
				Columns.Add(CreateNotifierConnectionColumnColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateMessageNotifierColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b606eb57-6d58-435e-b69b-ac57d73c4c29"),
				Name = @"MessageNotifier",
				ReferenceSchemaUId = new Guid("eb2f5124-c41f-4166-9caf-7986912ddea1"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("63845207-7cec-41ff-baf5-425b69236020"),
				ModifiedInSchemaUId = new Guid("63845207-7cec-41ff-baf5-425b69236020"),
				CreatedInPackageId = new Guid("b4ad7210-1e2c-4a25-8f9c-bff818d48783")
			};
		}

		protected virtual EntitySchemaColumn CreateMessageListenerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("bf4e2548-f0a6-4b3f-bb6c-711826502b0d"),
				Name = @"MessageListener",
				ReferenceSchemaUId = new Guid("34c308f0-dd59-4069-9613-4093b945b9be"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("63845207-7cec-41ff-baf5-425b69236020"),
				ModifiedInSchemaUId = new Guid("63845207-7cec-41ff-baf5-425b69236020"),
				CreatedInPackageId = new Guid("b4ad7210-1e2c-4a25-8f9c-bff818d48783")
			};
		}

		protected virtual EntitySchemaColumn CreateNotifierConnectionColumnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("9deea5b1-d5bd-4c81-8e55-76d396376457"),
				Name = @"NotifierConnectionColumn",
				CreatedInSchemaUId = new Guid("63845207-7cec-41ff-baf5-425b69236020"),
				ModifiedInSchemaUId = new Guid("63845207-7cec-41ff-baf5-425b69236020"),
				CreatedInPackageId = new Guid("cf777bca-d84e-40ce-8c41-2703b994b306")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ListenerByNotifier(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ListenerByNotifier_MessageEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ListenerByNotifierSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ListenerByNotifierSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("63845207-7cec-41ff-baf5-425b69236020"));
		}

		#endregion

	}

	#endregion

	#region Class: ListenerByNotifier

	/// <summary>
	/// Listener by notifier.
	/// </summary>
	public class ListenerByNotifier : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ListenerByNotifier(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ListenerByNotifier";
		}

		public ListenerByNotifier(ListenerByNotifier source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid MessageNotifierId {
			get {
				return GetTypedColumnValue<Guid>("MessageNotifierId");
			}
			set {
				SetColumnValue("MessageNotifierId", value);
				_messageNotifier = null;
			}
		}

		/// <exclude/>
		public string MessageNotifierName {
			get {
				return GetTypedColumnValue<string>("MessageNotifierName");
			}
			set {
				SetColumnValue("MessageNotifierName", value);
				if (_messageNotifier != null) {
					_messageNotifier.Name = value;
				}
			}
		}

		private MessageNotifier _messageNotifier;
		/// <summary>
		/// Notifier.
		/// </summary>
		public MessageNotifier MessageNotifier {
			get {
				return _messageNotifier ??
					(_messageNotifier = LookupColumnEntities.GetEntity("MessageNotifier") as MessageNotifier);
			}
		}

		/// <exclude/>
		public Guid MessageListenerId {
			get {
				return GetTypedColumnValue<Guid>("MessageListenerId");
			}
			set {
				SetColumnValue("MessageListenerId", value);
				_messageListener = null;
			}
		}

		/// <exclude/>
		public string MessageListenerName {
			get {
				return GetTypedColumnValue<string>("MessageListenerName");
			}
			set {
				SetColumnValue("MessageListenerName", value);
				if (_messageListener != null) {
					_messageListener.Name = value;
				}
			}
		}

		private MessageListener _messageListener;
		/// <summary>
		/// Listener.
		/// </summary>
		public MessageListener MessageListener {
			get {
				return _messageListener ??
					(_messageListener = LookupColumnEntities.GetEntity("MessageListener") as MessageListener);
			}
		}

		/// <summary>
		/// Notifier connection column name.
		/// </summary>
		public string NotifierConnectionColumn {
			get {
				return GetTypedColumnValue<string>("NotifierConnectionColumn");
			}
			set {
				SetColumnValue("NotifierConnectionColumn", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ListenerByNotifier_MessageEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ListenerByNotifierDeleted", e);
			Validating += (s, e) => ThrowEvent("ListenerByNotifierValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ListenerByNotifier(this);
		}

		#endregion

	}

	#endregion

	#region Class: ListenerByNotifier_MessageEventsProcess

	/// <exclude/>
	public partial class ListenerByNotifier_MessageEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ListenerByNotifier
	{

		public ListenerByNotifier_MessageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ListenerByNotifier_MessageEventsProcess";
			SchemaUId = new Guid("63845207-7cec-41ff-baf5-425b69236020");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("63845207-7cec-41ff-baf5-425b69236020");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
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
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: ListenerByNotifier_MessageEventsProcess

	/// <exclude/>
	public class ListenerByNotifier_MessageEventsProcess : ListenerByNotifier_MessageEventsProcess<ListenerByNotifier>
	{

		public ListenerByNotifier_MessageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ListenerByNotifier_MessageEventsProcess

	public partial class ListenerByNotifier_MessageEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ListenerByNotifierEventsProcess

	/// <exclude/>
	public class ListenerByNotifierEventsProcess : ListenerByNotifier_MessageEventsProcess
	{

		public ListenerByNotifierEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

