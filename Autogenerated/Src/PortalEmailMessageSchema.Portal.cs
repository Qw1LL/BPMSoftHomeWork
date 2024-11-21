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

	#region Class: PortalEmailMessageSchema

	/// <exclude/>
	public class PortalEmailMessageSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public PortalEmailMessageSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public PortalEmailMessageSchema(PortalEmailMessageSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public PortalEmailMessageSchema(PortalEmailMessageSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("92f15430-ea7c-4e98-9580-14b5d80fe5e6");
			RealUId = new Guid("92f15430-ea7c-4e98-9580-14b5d80fe5e6");
			Name = "PortalEmailMessage";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c85d2d65-6230-4aeb-9934-bfac9785d42f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a4c8140b-6136-442a-9175-b70f9e955047")) == null) {
				Columns.Add(CreateCaseMessageHistoryColumn());
			}
			if (Columns.FindByUId(new Guid("f9e40343-10bf-4820-bfc2-824587ae9cb4")) == null) {
				Columns.Add(CreateRecipientColumn());
			}
			if (Columns.FindByUId(new Guid("9e79c0dd-c82f-49d9-9f56-766b8630b54b")) == null) {
				Columns.Add(CreateSenderColumn());
			}
			if (Columns.FindByUId(new Guid("b6ae512c-8182-444c-a2f2-44b30fc3075b")) == null) {
				Columns.Add(CreateSendDateColumn());
			}
			if (Columns.FindByUId(new Guid("b4a82d88-32bc-4eb5-8031-31b19adf856f")) == null) {
				Columns.Add(CreateIsHtmlBodyColumn());
			}
			if (Columns.FindByUId(new Guid("22daf758-b8ff-4474-824b-5f56a23d552e")) == null) {
				Columns.Add(CreateMessageTypeIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCaseMessageHistoryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a4c8140b-6136-442a-9175-b70f9e955047"),
				Name = @"CaseMessageHistory",
				ReferenceSchemaUId = new Guid("9abf0257-2d36-47ca-920c-b9fb084275d6"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("92f15430-ea7c-4e98-9580-14b5d80fe5e6"),
				ModifiedInSchemaUId = new Guid("92f15430-ea7c-4e98-9580-14b5d80fe5e6"),
				CreatedInPackageId = new Guid("eac080e5-c7e6-4027-928f-bde13f5a1451")
			};
		}

		protected virtual EntitySchemaColumn CreateRecipientColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("f9e40343-10bf-4820-bfc2-824587ae9cb4"),
				Name = @"Recipient",
				CreatedInSchemaUId = new Guid("92f15430-ea7c-4e98-9580-14b5d80fe5e6"),
				ModifiedInSchemaUId = new Guid("92f15430-ea7c-4e98-9580-14b5d80fe5e6"),
				CreatedInPackageId = new Guid("eac080e5-c7e6-4027-928f-bde13f5a1451")
			};
		}

		protected virtual EntitySchemaColumn CreateSenderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("9e79c0dd-c82f-49d9-9f56-766b8630b54b"),
				Name = @"Sender",
				CreatedInSchemaUId = new Guid("92f15430-ea7c-4e98-9580-14b5d80fe5e6"),
				ModifiedInSchemaUId = new Guid("92f15430-ea7c-4e98-9580-14b5d80fe5e6"),
				CreatedInPackageId = new Guid("eac080e5-c7e6-4027-928f-bde13f5a1451")
			};
		}

		protected virtual EntitySchemaColumn CreateSendDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("b6ae512c-8182-444c-a2f2-44b30fc3075b"),
				Name = @"SendDate",
				CreatedInSchemaUId = new Guid("92f15430-ea7c-4e98-9580-14b5d80fe5e6"),
				ModifiedInSchemaUId = new Guid("92f15430-ea7c-4e98-9580-14b5d80fe5e6"),
				CreatedInPackageId = new Guid("eac080e5-c7e6-4027-928f-bde13f5a1451")
			};
		}

		protected virtual EntitySchemaColumn CreateIsHtmlBodyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("b4a82d88-32bc-4eb5-8031-31b19adf856f"),
				Name = @"IsHtmlBody",
				CreatedInSchemaUId = new Guid("92f15430-ea7c-4e98-9580-14b5d80fe5e6"),
				ModifiedInSchemaUId = new Guid("92f15430-ea7c-4e98-9580-14b5d80fe5e6"),
				CreatedInPackageId = new Guid("eac080e5-c7e6-4027-928f-bde13f5a1451")
			};
		}

		protected virtual EntitySchemaColumn CreateMessageTypeIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("22daf758-b8ff-4474-824b-5f56a23d552e"),
				Name = @"MessageTypeId",
				CreatedInSchemaUId = new Guid("92f15430-ea7c-4e98-9580-14b5d80fe5e6"),
				ModifiedInSchemaUId = new Guid("92f15430-ea7c-4e98-9580-14b5d80fe5e6"),
				CreatedInPackageId = new Guid("eac080e5-c7e6-4027-928f-bde13f5a1451")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new PortalEmailMessage(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new PortalEmailMessage_PortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new PortalEmailMessageSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new PortalEmailMessageSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("92f15430-ea7c-4e98-9580-14b5d80fe5e6"));
		}

		#endregion

	}

	#endregion

	#region Class: PortalEmailMessage

	/// <summary>
	/// Портальное email сообщение.
	/// </summary>
	public class PortalEmailMessage : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public PortalEmailMessage(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "PortalEmailMessage";
		}

		public PortalEmailMessage(PortalEmailMessage source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid CaseMessageHistoryId {
			get {
				return GetTypedColumnValue<Guid>("CaseMessageHistoryId");
			}
			set {
				SetColumnValue("CaseMessageHistoryId", value);
				_caseMessageHistory = null;
			}
		}

		private CaseMessageHistory _caseMessageHistory;
		/// <summary>
		/// CaseMessageHistory.
		/// </summary>
		public CaseMessageHistory CaseMessageHistory {
			get {
				return _caseMessageHistory ??
					(_caseMessageHistory = LookupColumnEntities.GetEntity("CaseMessageHistory") as CaseMessageHistory);
			}
		}

		/// <summary>
		/// Получатель.
		/// </summary>
		public string Recipient {
			get {
				return GetTypedColumnValue<string>("Recipient");
			}
			set {
				SetColumnValue("Recipient", value);
			}
		}

		/// <summary>
		/// Отправитель.
		/// </summary>
		public string Sender {
			get {
				return GetTypedColumnValue<string>("Sender");
			}
			set {
				SetColumnValue("Sender", value);
			}
		}

		/// <summary>
		/// Дата отправки.
		/// </summary>
		public DateTime SendDate {
			get {
				return GetTypedColumnValue<DateTime>("SendDate");
			}
			set {
				SetColumnValue("SendDate", value);
			}
		}

		/// <summary>
		/// Тело письма в формате HTML.
		/// </summary>
		public bool IsHtmlBody {
			get {
				return GetTypedColumnValue<bool>("IsHtmlBody");
			}
			set {
				SetColumnValue("IsHtmlBody", value);
			}
		}

		/// <summary>
		/// Тип сообщения.
		/// </summary>
		public Guid MessageTypeId {
			get {
				return GetTypedColumnValue<Guid>("MessageTypeId");
			}
			set {
				SetColumnValue("MessageTypeId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new PortalEmailMessage_PortalEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new PortalEmailMessage(this);
		}

		#endregion

	}

	#endregion

	#region Class: PortalEmailMessage_PortalEventsProcess

	/// <exclude/>
	public partial class PortalEmailMessage_PortalEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : PortalEmailMessage
	{

		public PortalEmailMessage_PortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "PortalEmailMessage_PortalEventsProcess";
			SchemaUId = new Guid("92f15430-ea7c-4e98-9580-14b5d80fe5e6");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("92f15430-ea7c-4e98-9580-14b5d80fe5e6");
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

	#region Class: PortalEmailMessage_PortalEventsProcess

	/// <exclude/>
	public class PortalEmailMessage_PortalEventsProcess : PortalEmailMessage_PortalEventsProcess<PortalEmailMessage>
	{

		public PortalEmailMessage_PortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: PortalEmailMessage_PortalEventsProcess

	public partial class PortalEmailMessage_PortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: PortalEmailMessageEventsProcess

	/// <exclude/>
	public class PortalEmailMessageEventsProcess : PortalEmailMessage_PortalEventsProcess
	{

		public PortalEmailMessageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

