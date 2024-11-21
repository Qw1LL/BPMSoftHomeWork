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

	#region Class: VwBulkEmailAudienceSchema

	/// <exclude/>
	public class VwBulkEmailAudienceSchema : BPMSoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public VwBulkEmailAudienceSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwBulkEmailAudienceSchema(VwBulkEmailAudienceSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwBulkEmailAudienceSchema(VwBulkEmailAudienceSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a152f9dc-4f24-4d68-a7ae-8389fdcfab83");
			RealUId = new Guid("a152f9dc-4f24-4d68-a7ae-8389fdcfab83");
			Name = "VwBulkEmailAudience";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e");
			IsDBView = true;
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
			if (Columns.FindByUId(new Guid("c6b32c69-e01a-41e6-af78-dfd5b8a6b28e")) == null) {
				Columns.Add(CreateBulkEmailColumn());
			}
			if (Columns.FindByUId(new Guid("540a362a-98fa-e27c-6cc1-48be5b2aa067")) == null) {
				Columns.Add(CreateBulkEmailResponseColumn());
			}
			if (Columns.FindByUId(new Guid("eac82b2e-089f-c11d-4d10-98aa0c0f0fde")) == null) {
				Columns.Add(CreateClicksColumn());
			}
			if (Columns.FindByUId(new Guid("d2782e56-8c60-48d1-995c-e768ac9c1e52")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("bee5b170-ad9a-4a1e-8b31-bc0b9f3978c9")) == null) {
				Columns.Add(CreateCreatedOnColumn());
			}
			if (Columns.FindByUId(new Guid("64829cee-7320-4514-8da5-506ee6cd952b")) == null) {
				Columns.Add(CreateEmailAddressColumn());
			}
			if (Columns.FindByUId(new Guid("9d733eaf-93ab-4f44-9819-7047e0ce5ba2")) == null) {
				Columns.Add(CreateIsSentColumn());
			}
			if (Columns.FindByUId(new Guid("264fa2b6-3224-4fb2-a719-a2bb56fb25e7")) == null) {
				Columns.Add(CreateLinkedEntityColumn());
			}
			if (Columns.FindByUId(new Guid("a0fe8e03-aa08-36c3-ac52-7c74068f8612")) == null) {
				Columns.Add(CreateOpensColumn());
			}
			if (Columns.FindByUId(new Guid("e6f3b61d-d974-4577-934a-e807f0d42003")) == null) {
				Columns.Add(CreateReplicaColumn());
			}
			if (Columns.FindByUId(new Guid("330e9712-ecf6-435e-ad84-0d26b8bdd0b6")) == null) {
				Columns.Add(CreateSessionIdColumn());
			}
			if (Columns.FindByUId(new Guid("ffc16f31-3330-b561-aead-960215f0e8a2")) == null) {
				Columns.Add(CreateModifiedOnColumn());
			}
			if (Columns.FindByUId(new Guid("d6156479-ad24-73c3-bc98-137f5772eecf")) == null) {
				Columns.Add(CreateProviderNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateBulkEmailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c6b32c69-e01a-41e6-af78-dfd5b8a6b28e"),
				Name = @"BulkEmail",
				ReferenceSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("a152f9dc-4f24-4d68-a7ae-8389fdcfab83"),
				ModifiedInSchemaUId = new Guid("a152f9dc-4f24-4d68-a7ae-8389fdcfab83"),
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e")
			};
		}

		protected virtual EntitySchemaColumn CreateBulkEmailResponseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("540a362a-98fa-e27c-6cc1-48be5b2aa067"),
				Name = @"BulkEmailResponse",
				ReferenceSchemaUId = new Guid("2ff5127a-ca8a-4515-aeb0-d2ded9168aed"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a152f9dc-4f24-4d68-a7ae-8389fdcfab83"),
				ModifiedInSchemaUId = new Guid("a152f9dc-4f24-4d68-a7ae-8389fdcfab83"),
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"14769602-ebda-40b1-91d5-ea9d623e2400"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateClicksColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("eac82b2e-089f-c11d-4d10-98aa0c0f0fde"),
				Name = @"Clicks",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("a152f9dc-4f24-4d68-a7ae-8389fdcfab83"),
				ModifiedInSchemaUId = new Guid("a152f9dc-4f24-4d68-a7ae-8389fdcfab83"),
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d2782e56-8c60-48d1-995c-e768ac9c1e52"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a152f9dc-4f24-4d68-a7ae-8389fdcfab83"),
				ModifiedInSchemaUId = new Guid("a152f9dc-4f24-4d68-a7ae-8389fdcfab83"),
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e")
			};
		}

		protected virtual EntitySchemaColumn CreateCreatedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("bee5b170-ad9a-4a1e-8b31-bc0b9f3978c9"),
				Name = @"CreatedOn",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("a152f9dc-4f24-4d68-a7ae-8389fdcfab83"),
				ModifiedInSchemaUId = new Guid("a152f9dc-4f24-4d68-a7ae-8389fdcfab83"),
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e")
			};
		}

		protected virtual EntitySchemaColumn CreateEmailAddressColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("64829cee-7320-4514-8da5-506ee6cd952b"),
				Name = @"EmailAddress",
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a152f9dc-4f24-4d68-a7ae-8389fdcfab83"),
				ModifiedInSchemaUId = new Guid("a152f9dc-4f24-4d68-a7ae-8389fdcfab83"),
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e")
			};
		}

		protected virtual EntitySchemaColumn CreateIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("789f6e45-5684-4dab-93f1-cd89b87ec2bb"),
				Name = @"Id",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				UsageType = EntitySchemaColumnUsageType.Advanced,
				CreatedInSchemaUId = new Guid("a152f9dc-4f24-4d68-a7ae-8389fdcfab83"),
				ModifiedInSchemaUId = new Guid("a152f9dc-4f24-4d68-a7ae-8389fdcfab83"),
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e")
			};
		}

		protected virtual EntitySchemaColumn CreateIsSentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("9d733eaf-93ab-4f44-9819-7047e0ce5ba2"),
				Name = @"IsSent",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("a152f9dc-4f24-4d68-a7ae-8389fdcfab83"),
				ModifiedInSchemaUId = new Guid("a152f9dc-4f24-4d68-a7ae-8389fdcfab83"),
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e")
			};
		}

		protected virtual EntitySchemaColumn CreateLinkedEntityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("264fa2b6-3224-4fb2-a719-a2bb56fb25e7"),
				Name = @"LinkedEntity",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsValueCloneable = false,
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("a152f9dc-4f24-4d68-a7ae-8389fdcfab83"),
				ModifiedInSchemaUId = new Guid("a152f9dc-4f24-4d68-a7ae-8389fdcfab83"),
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e")
			};
		}

		protected virtual EntitySchemaColumn CreateOpensColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("a0fe8e03-aa08-36c3-ac52-7c74068f8612"),
				Name = @"Opens",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("a152f9dc-4f24-4d68-a7ae-8389fdcfab83"),
				ModifiedInSchemaUId = new Guid("a152f9dc-4f24-4d68-a7ae-8389fdcfab83"),
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e")
			};
		}

		protected virtual EntitySchemaColumn CreateReplicaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e6f3b61d-d974-4577-934a-e807f0d42003"),
				Name = @"Replica",
				ReferenceSchemaUId = new Guid("dcb6b7a6-c21f-45d1-a442-dda902ef64c5"),
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("a152f9dc-4f24-4d68-a7ae-8389fdcfab83"),
				ModifiedInSchemaUId = new Guid("a152f9dc-4f24-4d68-a7ae-8389fdcfab83"),
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e")
			};
		}

		protected virtual EntitySchemaColumn CreateSessionIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("330e9712-ecf6-435e-ad84-0d26b8bdd0b6"),
				Name = @"SessionId",
				IsValueCloneable = false,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("a152f9dc-4f24-4d68-a7ae-8389fdcfab83"),
				ModifiedInSchemaUId = new Guid("a152f9dc-4f24-4d68-a7ae-8389fdcfab83"),
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e")
			};
		}

		protected virtual EntitySchemaColumn CreateModifiedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("ffc16f31-3330-b561-aead-960215f0e8a2"),
				Name = @"ModifiedOn",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("a152f9dc-4f24-4d68-a7ae-8389fdcfab83"),
				ModifiedInSchemaUId = new Guid("a152f9dc-4f24-4d68-a7ae-8389fdcfab83"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected virtual EntitySchemaColumn CreateProviderNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("d6156479-ad24-73c3-bc98-137f5772eecf"),
				Name = @"ProviderName",
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a152f9dc-4f24-4d68-a7ae-8389fdcfab83"),
				ModifiedInSchemaUId = new Guid("a152f9dc-4f24-4d68-a7ae-8389fdcfab83"),
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
			return new VwBulkEmailAudience(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwBulkEmailAudience_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwBulkEmailAudienceSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwBulkEmailAudienceSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a152f9dc-4f24-4d68-a7ae-8389fdcfab83"));
		}

		#endregion

	}

	#endregion

	#region Class: VwBulkEmailAudience

	/// <summary>
	/// Участник рассылки (аудитория).
	/// </summary>
	public class VwBulkEmailAudience : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwBulkEmailAudience(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwBulkEmailAudience";
		}

		public VwBulkEmailAudience(VwBulkEmailAudience source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
		/// Рассылка.
		/// </summary>
		public BulkEmail BulkEmail {
			get {
				return _bulkEmail ??
					(_bulkEmail = LookupColumnEntities.GetEntity("BulkEmail") as BulkEmail);
			}
		}

		/// <exclude/>
		public Guid BulkEmailResponseId {
			get {
				return GetTypedColumnValue<Guid>("BulkEmailResponseId");
			}
			set {
				SetColumnValue("BulkEmailResponseId", value);
				_bulkEmailResponse = null;
			}
		}

		/// <exclude/>
		public string BulkEmailResponseName {
			get {
				return GetTypedColumnValue<string>("BulkEmailResponseName");
			}
			set {
				SetColumnValue("BulkEmailResponseName", value);
				if (_bulkEmailResponse != null) {
					_bulkEmailResponse.Name = value;
				}
			}
		}

		private BulkEmailResponse _bulkEmailResponse;
		/// <summary>
		/// Отклик.
		/// </summary>
		public BulkEmailResponse BulkEmailResponse {
			get {
				return _bulkEmailResponse ??
					(_bulkEmailResponse = LookupColumnEntities.GetEntity("BulkEmailResponse") as BulkEmailResponse);
			}
		}

		/// <summary>
		/// Переходы.
		/// </summary>
		public int Clicks {
			get {
				return GetTypedColumnValue<int>("Clicks");
			}
			set {
				SetColumnValue("Clicks", value);
			}
		}

		/// <exclude/>
		public Guid ContactId {
			get {
				return GetTypedColumnValue<Guid>("ContactId");
			}
			set {
				SetColumnValue("ContactId", value);
				_contact = null;
			}
		}

		/// <exclude/>
		public string ContactName {
			get {
				return GetTypedColumnValue<string>("ContactName");
			}
			set {
				SetColumnValue("ContactName", value);
				if (_contact != null) {
					_contact.Name = value;
				}
			}
		}

		private Contact _contact;
		/// <summary>
		/// Контакт.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = LookupColumnEntities.GetEntity("Contact") as Contact);
			}
		}

		/// <summary>
		/// Дата создания.
		/// </summary>
		public DateTime CreatedOn {
			get {
				return GetTypedColumnValue<DateTime>("CreatedOn");
			}
			set {
				SetColumnValue("CreatedOn", value);
			}
		}

		/// <summary>
		/// Email.
		/// </summary>
		public string EmailAddress {
			get {
				return GetTypedColumnValue<string>("EmailAddress");
			}
			set {
				SetColumnValue("EmailAddress", value);
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

		/// <summary>
		/// Отправлено.
		/// </summary>
		public bool IsSent {
			get {
				return GetTypedColumnValue<bool>("IsSent");
			}
			set {
				SetColumnValue("IsSent", value);
			}
		}

		/// <exclude/>
		public Guid LinkedEntityId {
			get {
				return GetTypedColumnValue<Guid>("LinkedEntityId");
			}
			set {
				SetColumnValue("LinkedEntityId", value);
				_linkedEntity = null;
			}
		}

		/// <exclude/>
		public string LinkedEntityName {
			get {
				return GetTypedColumnValue<string>("LinkedEntityName");
			}
			set {
				SetColumnValue("LinkedEntityName", value);
				if (_linkedEntity != null) {
					_linkedEntity.Name = value;
				}
			}
		}

		private Contact _linkedEntity;
		/// <summary>
		/// Расширенный объект.
		/// </summary>
		public Contact LinkedEntity {
			get {
				return _linkedEntity ??
					(_linkedEntity = LookupColumnEntities.GetEntity("LinkedEntity") as Contact);
			}
		}

		/// <summary>
		/// Открытия.
		/// </summary>
		public int Opens {
			get {
				return GetTypedColumnValue<int>("Opens");
			}
			set {
				SetColumnValue("Opens", value);
			}
		}

		/// <exclude/>
		public Guid ReplicaId {
			get {
				return GetTypedColumnValue<Guid>("ReplicaId");
			}
			set {
				SetColumnValue("ReplicaId", value);
				_replica = null;
			}
		}

		/// <exclude/>
		public string ReplicaCaption {
			get {
				return GetTypedColumnValue<string>("ReplicaCaption");
			}
			set {
				SetColumnValue("ReplicaCaption", value);
				if (_replica != null) {
					_replica.Caption = value;
				}
			}
		}

		private DCReplica _replica;
		/// <summary>
		/// Реплика динамического контента.
		/// </summary>
		public DCReplica Replica {
			get {
				return _replica ??
					(_replica = LookupColumnEntities.GetEntity("Replica") as DCReplica);
			}
		}

		/// <summary>
		/// Сессия.
		/// </summary>
		public Guid SessionId {
			get {
				return GetTypedColumnValue<Guid>("SessionId");
			}
			set {
				SetColumnValue("SessionId", value);
			}
		}

		/// <summary>
		/// Дата изменения.
		/// </summary>
		/// <remarks>
		/// Дата изменения.
		/// </remarks>
		public DateTime ModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("ModifiedOn");
			}
			set {
				SetColumnValue("ModifiedOn", value);
			}
		}

		/// <summary>
		/// Провайдер отправки.
		/// </summary>
		public string ProviderName {
			get {
				return GetTypedColumnValue<string>("ProviderName");
			}
			set {
				SetColumnValue("ProviderName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwBulkEmailAudience_MarketingCampaignEventsProcess(UserConnection);
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
			return new VwBulkEmailAudience(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwBulkEmailAudience_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class VwBulkEmailAudience_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Core.Process.EmbeddedProcess where TEntity : VwBulkEmailAudience
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

		public VwBulkEmailAudience_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwBulkEmailAudience_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("a152f9dc-4f24-4d68-a7ae-8389fdcfab83");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a152f9dc-4f24-4d68-a7ae-8389fdcfab83");
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

	#region Class: VwBulkEmailAudience_MarketingCampaignEventsProcess

	/// <exclude/>
	public class VwBulkEmailAudience_MarketingCampaignEventsProcess : VwBulkEmailAudience_MarketingCampaignEventsProcess<VwBulkEmailAudience>
	{

		public VwBulkEmailAudience_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwBulkEmailAudience_MarketingCampaignEventsProcess

	public partial class VwBulkEmailAudience_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwBulkEmailAudienceEventsProcess

	/// <exclude/>
	public class VwBulkEmailAudienceEventsProcess : VwBulkEmailAudience_MarketingCampaignEventsProcess
	{

		public VwBulkEmailAudienceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

