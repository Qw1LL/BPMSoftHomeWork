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

	#region Class: BaseMessageHistorySchema

	/// <exclude/>
	[IsVirtual]
	public class BaseMessageHistorySchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public BaseMessageHistorySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BaseMessageHistorySchema(BaseMessageHistorySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BaseMessageHistorySchema(BaseMessageHistorySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a8f74749-bbc1-47a6-84b6-10e974356e91");
			RealUId = new Guid("a8f74749-bbc1-47a6-84b6-10e974356e91");
			Name = "BaseMessageHistory";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("b4ad7210-1e2c-4a25-8f9c-bff818d48783");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("21bf4763-3f85-40c6-90ad-69088168140c")) == null) {
				Columns.Add(CreateMessageColumn());
			}
			if (Columns.FindByUId(new Guid("6c4bf711-5016-4689-8ee2-fcb1a1ecdd0e")) == null) {
				Columns.Add(CreateMessageNotifierColumn());
			}
			if (Columns.FindByUId(new Guid("56d2c71d-1f5e-4a06-b41e-ae01c9537ae0")) == null) {
				Columns.Add(CreateRecordIdColumn());
			}
			if (Columns.FindByUId(new Guid("d8943e95-8bc0-49f5-86a9-22c6f42f7f43")) == null) {
				Columns.Add(CreateHasAttachmentColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateMessageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("21bf4763-3f85-40c6-90ad-69088168140c"),
				Name = @"Message",
				CreatedInSchemaUId = new Guid("a8f74749-bbc1-47a6-84b6-10e974356e91"),
				ModifiedInSchemaUId = new Guid("a8f74749-bbc1-47a6-84b6-10e974356e91"),
				CreatedInPackageId = new Guid("b4ad7210-1e2c-4a25-8f9c-bff818d48783")
			};
		}

		protected virtual EntitySchemaColumn CreateMessageNotifierColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6c4bf711-5016-4689-8ee2-fcb1a1ecdd0e"),
				Name = @"MessageNotifier",
				ReferenceSchemaUId = new Guid("eb2f5124-c41f-4166-9caf-7986912ddea1"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a8f74749-bbc1-47a6-84b6-10e974356e91"),
				ModifiedInSchemaUId = new Guid("a8f74749-bbc1-47a6-84b6-10e974356e91"),
				CreatedInPackageId = new Guid("b4ad7210-1e2c-4a25-8f9c-bff818d48783")
			};
		}

		protected virtual EntitySchemaColumn CreateRecordIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("56d2c71d-1f5e-4a06-b41e-ae01c9537ae0"),
				Name = @"RecordId",
				CreatedInSchemaUId = new Guid("a8f74749-bbc1-47a6-84b6-10e974356e91"),
				ModifiedInSchemaUId = new Guid("a8f74749-bbc1-47a6-84b6-10e974356e91"),
				CreatedInPackageId = new Guid("b4ad7210-1e2c-4a25-8f9c-bff818d48783")
			};
		}

		protected virtual EntitySchemaColumn CreateHasAttachmentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("d8943e95-8bc0-49f5-86a9-22c6f42f7f43"),
				Name = @"HasAttachment",
				CreatedInSchemaUId = new Guid("a8f74749-bbc1-47a6-84b6-10e974356e91"),
				ModifiedInSchemaUId = new Guid("a8f74749-bbc1-47a6-84b6-10e974356e91"),
				CreatedInPackageId = new Guid("b4ad7210-1e2c-4a25-8f9c-bff818d48783")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BaseMessageHistory(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BaseMessageHistory_MessageEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BaseMessageHistorySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BaseMessageHistorySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a8f74749-bbc1-47a6-84b6-10e974356e91"));
		}

		#endregion

	}

	#endregion

	#region Class: BaseMessageHistory

	/// <summary>
	/// Message history.
	/// </summary>
	public class BaseMessageHistory : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public BaseMessageHistory(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BaseMessageHistory";
		}

		public BaseMessageHistory(BaseMessageHistory source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Message.
		/// </summary>
		public string Message {
			get {
				return GetTypedColumnValue<string>("Message");
			}
			set {
				SetColumnValue("Message", value);
			}
		}

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

		/// <summary>
		/// Record Id.
		/// </summary>
		public Guid RecordId {
			get {
				return GetTypedColumnValue<Guid>("RecordId");
			}
			set {
				SetColumnValue("RecordId", value);
			}
		}

		/// <summary>
		/// Attachments.
		/// </summary>
		public bool HasAttachment {
			get {
				return GetTypedColumnValue<bool>("HasAttachment");
			}
			set {
				SetColumnValue("HasAttachment", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BaseMessageHistory_MessageEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BaseMessageHistoryDeleted", e);
			Validating += (s, e) => ThrowEvent("BaseMessageHistoryValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BaseMessageHistory(this);
		}

		#endregion

	}

	#endregion

	#region Class: BaseMessageHistory_MessageEventsProcess

	/// <exclude/>
	public partial class BaseMessageHistory_MessageEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : BaseMessageHistory
	{

		public BaseMessageHistory_MessageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BaseMessageHistory_MessageEventsProcess";
			SchemaUId = new Guid("a8f74749-bbc1-47a6-84b6-10e974356e91");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a8f74749-bbc1-47a6-84b6-10e974356e91");
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

	#region Class: BaseMessageHistory_MessageEventsProcess

	/// <exclude/>
	public class BaseMessageHistory_MessageEventsProcess : BaseMessageHistory_MessageEventsProcess<BaseMessageHistory>
	{

		public BaseMessageHistory_MessageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BaseMessageHistory_MessageEventsProcess

	public partial class BaseMessageHistory_MessageEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BaseMessageHistoryEventsProcess

	/// <exclude/>
	public class BaseMessageHistoryEventsProcess : BaseMessageHistory_MessageEventsProcess
	{

		public BaseMessageHistoryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

