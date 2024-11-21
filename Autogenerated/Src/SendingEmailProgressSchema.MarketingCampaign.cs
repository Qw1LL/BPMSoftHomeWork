namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.IO;

	#region Class: SendingEmailProgressSchema

	/// <exclude/>
	public class SendingEmailProgressSchema : BPMSoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public SendingEmailProgressSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SendingEmailProgressSchema(SendingEmailProgressSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SendingEmailProgressSchema(SendingEmailProgressSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c5938a65-78bf-fb90-1585-0221ab3f1c6b");
			RealUId = new Guid("c5938a65-78bf-fb90-1585-0221ab3f1c6b");
			Name = "SendingEmailProgress";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryColumn() {
			base.InitializePrimaryColumn();
			PrimaryColumn = CreateIdColumn();
			if (Columns.FindByUId(PrimaryColumn.UId) == null) {
				Columns.Add(PrimaryColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("de736c98-eb3a-39e4-fb67-fc3e823971bb")) == null) {
				Columns.Add(CreatePreparedRecipientsCountColumn());
			}
			if (Columns.FindByUId(new Guid("c61ff70c-94b9-86c3-a608-cd26b0de9fd4")) == null) {
				Columns.Add(CreateModifiedOnColumn());
			}
			if (Columns.FindByUId(new Guid("9a6357a5-edd0-a753-5581-24b09b199988")) == null) {
				Columns.Add(CreateBulkEmailColumn());
			}
			if (Columns.FindByUId(new Guid("6b952ef2-b04a-6f0f-fc21-a32b79ea600e")) == null) {
				Columns.Add(CreateProcessedRecipientCountColumn());
			}
			if (Columns.FindByUId(new Guid("ef66dda2-6f89-a219-5710-c102f8b9412e")) == null) {
				Columns.Add(CreateReceivedInitialResponseCountColumn());
			}
		}

		protected virtual EntitySchemaColumn CreatePreparedRecipientsCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("de736c98-eb3a-39e4-fb67-fc3e823971bb"),
				Name = @"PreparedRecipientsCount",
				CreatedInSchemaUId = new Guid("c5938a65-78bf-fb90-1585-0221ab3f1c6b"),
				ModifiedInSchemaUId = new Guid("c5938a65-78bf-fb90-1585-0221ab3f1c6b"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected virtual EntitySchemaColumn CreateModifiedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("c61ff70c-94b9-86c3-a608-cd26b0de9fd4"),
				Name = @"ModifiedOn",
				CreatedInSchemaUId = new Guid("c5938a65-78bf-fb90-1585-0221ab3f1c6b"),
				ModifiedInSchemaUId = new Guid("c5938a65-78bf-fb90-1585-0221ab3f1c6b"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected virtual EntitySchemaColumn CreateIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("add5da20-9aa7-0ee9-4996-f15ae4cea919"),
				Name = @"Id",
				CreatedInSchemaUId = new Guid("c5938a65-78bf-fb90-1585-0221ab3f1c6b"),
				ModifiedInSchemaUId = new Guid("c5938a65-78bf-fb90-1585-0221ab3f1c6b"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected virtual EntitySchemaColumn CreateBulkEmailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9a6357a5-edd0-a753-5581-24b09b199988"),
				Name = @"BulkEmail",
				ReferenceSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c5938a65-78bf-fb90-1585-0221ab3f1c6b"),
				ModifiedInSchemaUId = new Guid("c5938a65-78bf-fb90-1585-0221ab3f1c6b"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected virtual EntitySchemaColumn CreateProcessedRecipientCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("6b952ef2-b04a-6f0f-fc21-a32b79ea600e"),
				Name = @"ProcessedRecipientCount",
				CreatedInSchemaUId = new Guid("c5938a65-78bf-fb90-1585-0221ab3f1c6b"),
				ModifiedInSchemaUId = new Guid("c5938a65-78bf-fb90-1585-0221ab3f1c6b"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected virtual EntitySchemaColumn CreateReceivedInitialResponseCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("ef66dda2-6f89-a219-5710-c102f8b9412e"),
				Name = @"ReceivedInitialResponseCount",
				CreatedInSchemaUId = new Guid("c5938a65-78bf-fb90-1585-0221ab3f1c6b"),
				ModifiedInSchemaUId = new Guid("c5938a65-78bf-fb90-1585-0221ab3f1c6b"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SendingEmailProgress(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SendingEmailProgress_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SendingEmailProgressSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SendingEmailProgressSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c5938a65-78bf-fb90-1585-0221ab3f1c6b"));
		}

		#endregion

	}

	#endregion

	#region Class: SendingEmailProgress

	/// <summary>
	/// Прогресс отправки рассылок.
	/// </summary>
	public class SendingEmailProgress : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SendingEmailProgress(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SendingEmailProgress";
		}

		public SendingEmailProgress(SendingEmailProgress source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Подготовлено получателей, кол-во.
		/// </summary>
		public int PreparedRecipientsCount {
			get {
				return GetTypedColumnValue<int>("PreparedRecipientsCount");
			}
			set {
				SetColumnValue("PreparedRecipientsCount", value);
			}
		}

		/// <summary>
		/// Изменено.
		/// </summary>
		public DateTime ModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("ModifiedOn");
			}
			set {
				SetColumnValue("ModifiedOn", value);
			}
		}

		/// <summary>
		/// Id.
		/// </summary>
		public Guid Id {
			get {
				return GetTypedColumnValue<Guid>("Id");
			}
			set {
				SetColumnValue("Id", value);
			}
		}

		/// <exclude/>
		public Guid BulkEmailId {
			get {
				return GetTypedColumnValue<Guid>("BulkEmailId");
			}
			set {
				SetColumnValue("BulkEmailId", value);
				_bulkEmail = null;
			}
		}

		/// <exclude/>
		public string BulkEmailName {
			get {
				return GetTypedColumnValue<string>("BulkEmailName");
			}
			set {
				SetColumnValue("BulkEmailName", value);
				if (_bulkEmail != null) {
					_bulkEmail.Name = value;
				}
			}
		}

		private BulkEmail _bulkEmail;
		/// <summary>
		/// Email.
		/// </summary>
		public BulkEmail BulkEmail {
			get {
				return _bulkEmail ??
					(_bulkEmail = LookupColumnEntities.GetEntity("BulkEmail") as BulkEmail);
			}
		}

		/// <summary>
		/// Обработано получателей, кол-во.
		/// </summary>
		public int ProcessedRecipientCount {
			get {
				return GetTypedColumnValue<int>("ProcessedRecipientCount");
			}
			set {
				SetColumnValue("ProcessedRecipientCount", value);
			}
		}

		/// <summary>
		/// Получен первичный отклик, кол-во.
		/// </summary>
		public int ReceivedInitialResponseCount {
			get {
				return GetTypedColumnValue<int>("ReceivedInitialResponseCount");
			}
			set {
				SetColumnValue("ReceivedInitialResponseCount", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SendingEmailProgress_MarketingCampaignEventsProcess(UserConnection);
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
			return new SendingEmailProgress(this);
		}

		#endregion

	}

	#endregion

	#region Class: SendingEmailProgress_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class SendingEmailProgress_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Core.Process.EmbeddedProcess where TEntity : SendingEmailProgress
	{

		private TEntity _entity;
		public TEntity Entity {
			get {
				return _entity;
			}
			set {
				_entity = value;
			}
		}

		public SendingEmailProgress_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SendingEmailProgress_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("c5938a65-78bf-fb90-1585-0221ab3f1c6b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c5938a65-78bf-fb90-1585-0221ab3f1c6b");
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

	#region Class: SendingEmailProgress_MarketingCampaignEventsProcess

	/// <exclude/>
	public class SendingEmailProgress_MarketingCampaignEventsProcess : SendingEmailProgress_MarketingCampaignEventsProcess<SendingEmailProgress>
	{

		public SendingEmailProgress_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SendingEmailProgress_MarketingCampaignEventsProcess

	public partial class SendingEmailProgress_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SendingEmailProgressEventsProcess

	/// <exclude/>
	public class SendingEmailProgressEventsProcess : SendingEmailProgress_MarketingCampaignEventsProcess
	{

		public SendingEmailProgressEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

