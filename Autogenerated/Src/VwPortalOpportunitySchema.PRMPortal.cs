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

	#region Class: VwPortalOpportunitySchema

	/// <exclude/>
	public class VwPortalOpportunitySchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwPortalOpportunitySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwPortalOpportunitySchema(VwPortalOpportunitySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwPortalOpportunitySchema(VwPortalOpportunitySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cbef7b5f-f5b7-4682-bb1c-88813a9775ed");
			RealUId = new Guid("cbef7b5f-f5b7-4682-bb1c-88813a9775ed");
			Name = "VwPortalOpportunity";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("2b000645-6072-461d-8963-11edfee86881");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateTitleColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("14a40052-38b8-4e1c-8619-3b4e8c16d0bf")) == null) {
				Columns.Add(CreateAccountColumn());
			}
			if (Columns.FindByUId(new Guid("9c239e45-1ba7-4865-81e4-0e3cdee92044")) == null) {
				Columns.Add(CreateOwnerColumn());
			}
			if (Columns.FindByUId(new Guid("d085c6cd-d98d-46b9-9946-0f3043c78b5b")) == null) {
				Columns.Add(CreateBudgetColumn());
			}
			if (Columns.FindByUId(new Guid("0fc84ffb-f202-4c3a-8367-e300391aee25")) == null) {
				Columns.Add(CreateLeadTypeColumn());
			}
			if (Columns.FindByUId(new Guid("706f1f04-a0ac-4e0f-8612-b0fe1efe8e36")) == null) {
				Columns.Add(CreateDueDateColumn());
			}
			if (Columns.FindByUId(new Guid("48ad85a7-19d6-4432-8222-bdcd1486fbfa")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("763c22c6-a1fe-4a36-aef7-c632681256b8")) == null) {
				Columns.Add(CreateStageColumn());
			}
			if (Columns.FindByUId(new Guid("93c63ff7-281e-45ea-97f6-8322fd361a3c")) == null) {
				Columns.Add(CreateProbabilityColumn());
			}
			if (Columns.FindByUId(new Guid("12f08693-1b73-4bc5-8279-ca52051e3341")) == null) {
				Columns.Add(CreatePartnerRolesColumn());
			}
			if (Columns.FindByUId(new Guid("3a91b415-d062-434d-a87c-f5db7347af2f")) == null) {
				Columns.Add(CreatePartnerColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateTitleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("18f4e056-897a-47e1-a38c-30f970fed27b"),
				Name = @"Title",
				CreatedInSchemaUId = new Guid("cbef7b5f-f5b7-4682-bb1c-88813a9775ed"),
				ModifiedInSchemaUId = new Guid("cbef7b5f-f5b7-4682-bb1c-88813a9775ed"),
				CreatedInPackageId = new Guid("2b000645-6072-461d-8963-11edfee86881")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("14a40052-38b8-4e1c-8619-3b4e8c16d0bf"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("cbef7b5f-f5b7-4682-bb1c-88813a9775ed"),
				ModifiedInSchemaUId = new Guid("cbef7b5f-f5b7-4682-bb1c-88813a9775ed"),
				CreatedInPackageId = new Guid("2b000645-6072-461d-8963-11edfee86881")
			};
		}

		protected virtual EntitySchemaColumn CreateOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9c239e45-1ba7-4865-81e4-0e3cdee92044"),
				Name = @"Owner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("cbef7b5f-f5b7-4682-bb1c-88813a9775ed"),
				ModifiedInSchemaUId = new Guid("cbef7b5f-f5b7-4682-bb1c-88813a9775ed"),
				CreatedInPackageId = new Guid("2b000645-6072-461d-8963-11edfee86881")
			};
		}

		protected virtual EntitySchemaColumn CreateBudgetColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("d085c6cd-d98d-46b9-9946-0f3043c78b5b"),
				Name = @"Budget",
				CreatedInSchemaUId = new Guid("cbef7b5f-f5b7-4682-bb1c-88813a9775ed"),
				ModifiedInSchemaUId = new Guid("cbef7b5f-f5b7-4682-bb1c-88813a9775ed"),
				CreatedInPackageId = new Guid("2b000645-6072-461d-8963-11edfee86881")
			};
		}

		protected virtual EntitySchemaColumn CreateLeadTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0fc84ffb-f202-4c3a-8367-e300391aee25"),
				Name = @"LeadType",
				ReferenceSchemaUId = new Guid("e0dbeb22-4932-4eee-a8f2-a247a5fce888"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("cbef7b5f-f5b7-4682-bb1c-88813a9775ed"),
				ModifiedInSchemaUId = new Guid("cbef7b5f-f5b7-4682-bb1c-88813a9775ed"),
				CreatedInPackageId = new Guid("2b000645-6072-461d-8963-11edfee86881")
			};
		}

		protected virtual EntitySchemaColumn CreateDueDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("706f1f04-a0ac-4e0f-8612-b0fe1efe8e36"),
				Name = @"DueDate",
				CreatedInSchemaUId = new Guid("cbef7b5f-f5b7-4682-bb1c-88813a9775ed"),
				ModifiedInSchemaUId = new Guid("cbef7b5f-f5b7-4682-bb1c-88813a9775ed"),
				CreatedInPackageId = new Guid("2b000645-6072-461d-8963-11edfee86881")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("48ad85a7-19d6-4432-8222-bdcd1486fbfa"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("85fe0df7-a970-4717-8f7b-8caba783906b"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("cbef7b5f-f5b7-4682-bb1c-88813a9775ed"),
				ModifiedInSchemaUId = new Guid("cbef7b5f-f5b7-4682-bb1c-88813a9775ed"),
				CreatedInPackageId = new Guid("2b000645-6072-461d-8963-11edfee86881")
			};
		}

		protected virtual EntitySchemaColumn CreateStageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("763c22c6-a1fe-4a36-aef7-c632681256b8"),
				Name = @"Stage",
				ReferenceSchemaUId = new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("cbef7b5f-f5b7-4682-bb1c-88813a9775ed"),
				ModifiedInSchemaUId = new Guid("cbef7b5f-f5b7-4682-bb1c-88813a9775ed"),
				CreatedInPackageId = new Guid("2b000645-6072-461d-8963-11edfee86881")
			};
		}

		protected virtual EntitySchemaColumn CreateProbabilityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("93c63ff7-281e-45ea-97f6-8322fd361a3c"),
				Name = @"Probability",
				CreatedInSchemaUId = new Guid("cbef7b5f-f5b7-4682-bb1c-88813a9775ed"),
				ModifiedInSchemaUId = new Guid("cbef7b5f-f5b7-4682-bb1c-88813a9775ed"),
				CreatedInPackageId = new Guid("2b000645-6072-461d-8963-11edfee86881")
			};
		}

		protected virtual EntitySchemaColumn CreatePartnerRolesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("12f08693-1b73-4bc5-8279-ca52051e3341"),
				Name = @"PartnerRoles",
				CreatedInSchemaUId = new Guid("cbef7b5f-f5b7-4682-bb1c-88813a9775ed"),
				ModifiedInSchemaUId = new Guid("cbef7b5f-f5b7-4682-bb1c-88813a9775ed"),
				CreatedInPackageId = new Guid("2b000645-6072-461d-8963-11edfee86881")
			};
		}

		protected virtual EntitySchemaColumn CreatePartnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3a91b415-d062-434d-a87c-f5db7347af2f"),
				Name = @"Partner",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("cbef7b5f-f5b7-4682-bb1c-88813a9775ed"),
				ModifiedInSchemaUId = new Guid("cbef7b5f-f5b7-4682-bb1c-88813a9775ed"),
				CreatedInPackageId = new Guid("2b000645-6072-461d-8963-11edfee86881")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwPortalOpportunity(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwPortalOpportunity_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwPortalOpportunitySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwPortalOpportunitySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cbef7b5f-f5b7-4682-bb1c-88813a9775ed"));
		}

		#endregion

	}

	#endregion

	#region Class: VwPortalOpportunity

	/// <summary>
	/// Объект Продажа на портале.
	/// </summary>
	public class VwPortalOpportunity : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwPortalOpportunity(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwPortalOpportunity";
		}

		public VwPortalOpportunity(VwPortalOpportunity source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Название.
		/// </summary>
		public string Title {
			get {
				return GetTypedColumnValue<string>("Title");
			}
			set {
				SetColumnValue("Title", value);
			}
		}

		/// <exclude/>
		public Guid AccountId {
			get {
				return GetTypedColumnValue<Guid>("AccountId");
			}
			set {
				SetColumnValue("AccountId", value);
				_account = null;
			}
		}

		/// <exclude/>
		public string AccountName {
			get {
				return GetTypedColumnValue<string>("AccountName");
			}
			set {
				SetColumnValue("AccountName", value);
				if (_account != null) {
					_account.Name = value;
				}
			}
		}

		private Account _account;
		/// <summary>
		/// Контрагент.
		/// </summary>
		public Account Account {
			get {
				return _account ??
					(_account = LookupColumnEntities.GetEntity("Account") as Account);
			}
		}

		/// <exclude/>
		public Guid OwnerId {
			get {
				return GetTypedColumnValue<Guid>("OwnerId");
			}
			set {
				SetColumnValue("OwnerId", value);
				_owner = null;
			}
		}

		/// <exclude/>
		public string OwnerName {
			get {
				return GetTypedColumnValue<string>("OwnerName");
			}
			set {
				SetColumnValue("OwnerName", value);
				if (_owner != null) {
					_owner.Name = value;
				}
			}
		}

		private Contact _owner;
		/// <summary>
		/// Ответственный.
		/// </summary>
		public Contact Owner {
			get {
				return _owner ??
					(_owner = LookupColumnEntities.GetEntity("Owner") as Contact);
			}
		}

		/// <summary>
		/// Бюджет клиента.
		/// </summary>
		public Decimal Budget {
			get {
				return GetTypedColumnValue<Decimal>("Budget");
			}
			set {
				SetColumnValue("Budget", value);
			}
		}

		/// <exclude/>
		public Guid LeadTypeId {
			get {
				return GetTypedColumnValue<Guid>("LeadTypeId");
			}
			set {
				SetColumnValue("LeadTypeId", value);
				_leadType = null;
			}
		}

		/// <exclude/>
		public string LeadTypeName {
			get {
				return GetTypedColumnValue<string>("LeadTypeName");
			}
			set {
				SetColumnValue("LeadTypeName", value);
				if (_leadType != null) {
					_leadType.Name = value;
				}
			}
		}

		private LeadType _leadType;
		/// <summary>
		/// Тип потребности.
		/// </summary>
		public LeadType LeadType {
			get {
				return _leadType ??
					(_leadType = LookupColumnEntities.GetEntity("LeadType") as LeadType);
			}
		}

		/// <summary>
		/// Дата закрытия.
		/// </summary>
		public DateTime DueDate {
			get {
				return GetTypedColumnValue<DateTime>("DueDate");
			}
			set {
				SetColumnValue("DueDate", value);
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

		private OpportunityType _type;
		/// <summary>
		/// Тип.
		/// </summary>
		public OpportunityType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as OpportunityType);
			}
		}

		/// <exclude/>
		public Guid StageId {
			get {
				return GetTypedColumnValue<Guid>("StageId");
			}
			set {
				SetColumnValue("StageId", value);
				_stage = null;
			}
		}

		/// <exclude/>
		public string StageName {
			get {
				return GetTypedColumnValue<string>("StageName");
			}
			set {
				SetColumnValue("StageName", value);
				if (_stage != null) {
					_stage.Name = value;
				}
			}
		}

		private OpportunityStage _stage;
		/// <summary>
		/// Стадия.
		/// </summary>
		public OpportunityStage Stage {
			get {
				return _stage ??
					(_stage = LookupColumnEntities.GetEntity("Stage") as OpportunityStage);
			}
		}

		/// <summary>
		/// Вероятность, %.
		/// </summary>
		public int Probability {
			get {
				return GetTypedColumnValue<int>("Probability");
			}
			set {
				SetColumnValue("Probability", value);
			}
		}

		/// <summary>
		/// Роли партнера.
		/// </summary>
		public string PartnerRoles {
			get {
				return GetTypedColumnValue<string>("PartnerRoles");
			}
			set {
				SetColumnValue("PartnerRoles", value);
			}
		}

		/// <exclude/>
		public Guid PartnerId {
			get {
				return GetTypedColumnValue<Guid>("PartnerId");
			}
			set {
				SetColumnValue("PartnerId", value);
				_partner = null;
			}
		}

		/// <exclude/>
		public string PartnerName {
			get {
				return GetTypedColumnValue<string>("PartnerName");
			}
			set {
				SetColumnValue("PartnerName", value);
				if (_partner != null) {
					_partner.Name = value;
				}
			}
		}

		private Account _partner;
		/// <summary>
		/// Партнер.
		/// </summary>
		public Account Partner {
			get {
				return _partner ??
					(_partner = LookupColumnEntities.GetEntity("Partner") as Account);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwPortalOpportunity_PRMPortalEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwPortalOpportunityDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwPortalOpportunity(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwPortalOpportunity_PRMPortalEventsProcess

	/// <exclude/>
	public partial class VwPortalOpportunity_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwPortalOpportunity
	{

		public VwPortalOpportunity_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwPortalOpportunity_PRMPortalEventsProcess";
			SchemaUId = new Guid("cbef7b5f-f5b7-4682-bb1c-88813a9775ed");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("cbef7b5f-f5b7-4682-bb1c-88813a9775ed");
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

	#region Class: VwPortalOpportunity_PRMPortalEventsProcess

	/// <exclude/>
	public class VwPortalOpportunity_PRMPortalEventsProcess : VwPortalOpportunity_PRMPortalEventsProcess<VwPortalOpportunity>
	{

		public VwPortalOpportunity_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwPortalOpportunity_PRMPortalEventsProcess

	public partial class VwPortalOpportunity_PRMPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwPortalOpportunityEventsProcess

	/// <exclude/>
	public class VwPortalOpportunityEventsProcess : VwPortalOpportunity_PRMPortalEventsProcess
	{

		public VwPortalOpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

