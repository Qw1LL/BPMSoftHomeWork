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

	#region Class: Contract_CoreContracts_BPMSoftSchema

	/// <exclude/>
	public class Contract_CoreContracts_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public Contract_CoreContracts_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Contract_CoreContracts_BPMSoftSchema(Contract_CoreContracts_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Contract_CoreContracts_BPMSoftSchema(Contract_CoreContracts_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810");
			RealUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810");
			Name = "Contract_CoreContracts_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNumberColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("7a6eaf1a-a818-40ca-8f91-8bd2ec36cef5")) == null) {
				Columns.Add(CreateStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("91ea6293-a8ff-4506-98eb-7577352cdad1")) == null) {
				Columns.Add(CreateEndDateColumn());
			}
			if (Columns.FindByUId(new Guid("12c2844f-0167-410f-99d0-8d6a54a0aca3")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("7c828ea0-9dcb-45b5-b051-7318ca556d11")) == null) {
				Columns.Add(CreateStateColumn());
			}
			if (Columns.FindByUId(new Guid("b1b39ef5-5550-41b4-9ad9-77f60c847d89")) == null) {
				Columns.Add(CreateAccountColumn());
			}
			if (Columns.FindByUId(new Guid("5672ebff-99c9-496f-8f90-c80cc1514173")) == null) {
				Columns.Add(CreateSupplierBillingInfoColumn());
			}
			if (Columns.FindByUId(new Guid("11951c89-228f-4178-a5df-6104b727af13")) == null) {
				Columns.Add(CreateOwnerColumn());
			}
			if (Columns.FindByUId(new Guid("526dbd03-9706-486d-b3ed-3b598acf5f64")) == null) {
				Columns.Add(CreateCustomerBillingInfoColumn());
			}
			if (Columns.FindByUId(new Guid("73bef14c-cd27-4c2e-9ae9-c16cc1098af7")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("42a41ee5-b73b-4fe2-ac55-34f192da42ed")) == null) {
				Columns.Add(CreateNotesColumn());
			}
			if (Columns.FindByUId(new Guid("0d3f5a3c-2d4f-4a3b-9d18-87a8345515ce")) == null) {
				Columns.Add(CreateParentColumn());
			}
			if (Columns.FindByUId(new Guid("f8bfced5-6c5b-4750-98b1-d5f4d4aab715")) == null) {
				Columns.Add(CreateOurCompanyColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNumberColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("bbdd475a-30b1-4a42-bfc1-98126f57bbd3"),
				Name = @"Number",
				CreatedInSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"),
				ModifiedInSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"),
				CreatedInPackageId = new Guid("1401a881-7126-4c81-86f8-4e9e355b0669")
			};
		}

		protected virtual EntitySchemaColumn CreateStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("7a6eaf1a-a818-40ca-8f91-8bd2ec36cef5"),
				Name = @"StartDate",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"),
				ModifiedInSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"),
				CreatedInPackageId = new Guid("1401a881-7126-4c81-86f8-4e9e355b0669"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentDate")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateEndDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("91ea6293-a8ff-4506-98eb-7577352cdad1"),
				Name = @"EndDate",
				CreatedInSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"),
				ModifiedInSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"),
				CreatedInPackageId = new Guid("1401a881-7126-4c81-86f8-4e9e355b0669")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("12c2844f-0167-410f-99d0-8d6a54a0aca3"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("427ad733-d7ff-43c5-a65a-c22a25e4e5df"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"),
				ModifiedInSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"),
				CreatedInPackageId = new Guid("1401a881-7126-4c81-86f8-4e9e355b0669"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"42b49a15-1d6c-4fa3-b24a-45711ba90cb3"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateStateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7c828ea0-9dcb-45b5-b051-7318ca556d11"),
				Name = @"State",
				ReferenceSchemaUId = new Guid("946f79dc-1039-448b-a670-eb6658e7180a"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"),
				ModifiedInSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"),
				CreatedInPackageId = new Guid("1401a881-7126-4c81-86f8-4e9e355b0669"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"8f7197fb-af9c-4674-9c7d-3d7d32aa3d2e"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b1b39ef5-5550-41b4-9ad9-77f60c847d89"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"),
				ModifiedInSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"),
				CreatedInPackageId = new Guid("1401a881-7126-4c81-86f8-4e9e355b0669")
			};
		}

		protected virtual EntitySchemaColumn CreateSupplierBillingInfoColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5672ebff-99c9-496f-8f90-c80cc1514173"),
				Name = @"SupplierBillingInfo",
				ReferenceSchemaUId = new Guid("4f0e44ce-343c-45b6-ae14-ff0533d4add9"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"),
				ModifiedInSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"),
				CreatedInPackageId = new Guid("1401a881-7126-4c81-86f8-4e9e355b0669")
			};
		}

		protected virtual EntitySchemaColumn CreateOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("11951c89-228f-4178-a5df-6104b727af13"),
				Name = @"Owner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"),
				ModifiedInSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"),
				CreatedInPackageId = new Guid("1401a881-7126-4c81-86f8-4e9e355b0669"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentUserContact")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateCustomerBillingInfoColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("526dbd03-9706-486d-b3ed-3b598acf5f64"),
				Name = @"CustomerBillingInfo",
				ReferenceSchemaUId = new Guid("4f0e44ce-343c-45b6-ae14-ff0533d4add9"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"),
				ModifiedInSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"),
				CreatedInPackageId = new Guid("1401a881-7126-4c81-86f8-4e9e355b0669")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("73bef14c-cd27-4c2e-9ae9-c16cc1098af7"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"),
				ModifiedInSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"),
				CreatedInPackageId = new Guid("1401a881-7126-4c81-86f8-4e9e355b0669")
			};
		}

		protected virtual EntitySchemaColumn CreateNotesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("42a41ee5-b73b-4fe2-ac55-34f192da42ed"),
				Name = @"Notes",
				CreatedInSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"),
				ModifiedInSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"),
				CreatedInPackageId = new Guid("35a1e95b-1cfe-4e66-8afa-90d42fa38092")
			};
		}

		protected virtual EntitySchemaColumn CreateParentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0d3f5a3c-2d4f-4a3b-9d18-87a8345515ce"),
				Name = @"Parent",
				ReferenceSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"),
				ModifiedInSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"),
				CreatedInPackageId = new Guid("1401a881-7126-4c81-86f8-4e9e355b0669")
			};
		}

		protected virtual EntitySchemaColumn CreateOurCompanyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f8bfced5-6c5b-4750-98b1-d5f4d4aab715"),
				Name = @"OurCompany",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"),
				ModifiedInSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"),
				CreatedInPackageId = new Guid("35a1e95b-1cfe-4e66-8afa-90d42fa38092")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Contract_CoreContracts_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Contract_CoreContractsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Contract_CoreContracts_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Contract_CoreContracts_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"));
		}

		#endregion

	}

	#endregion

	#region Class: Contract_CoreContracts_BPMSoft

	/// <summary>
	/// Договор.
	/// </summary>
	public class Contract_CoreContracts_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public Contract_CoreContracts_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Contract_CoreContracts_BPMSoft";
		}

		public Contract_CoreContracts_BPMSoft(Contract_CoreContracts_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Номер.
		/// </summary>
		public string Number {
			get {
				return GetTypedColumnValue<string>("Number");
			}
			set {
				SetColumnValue("Number", value);
			}
		}

		/// <summary>
		/// Дата начала.
		/// </summary>
		public DateTime StartDate {
			get {
				return GetTypedColumnValue<DateTime>("StartDate");
			}
			set {
				SetColumnValue("StartDate", value);
			}
		}

		/// <summary>
		/// Дата завершения.
		/// </summary>
		public DateTime EndDate {
			get {
				return GetTypedColumnValue<DateTime>("EndDate");
			}
			set {
				SetColumnValue("EndDate", value);
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

		private ContractType _type;
		/// <summary>
		/// Тип.
		/// </summary>
		public ContractType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as ContractType);
			}
		}

		/// <exclude/>
		public Guid StateId {
			get {
				return GetTypedColumnValue<Guid>("StateId");
			}
			set {
				SetColumnValue("StateId", value);
				_state = null;
			}
		}

		/// <exclude/>
		public string StateName {
			get {
				return GetTypedColumnValue<string>("StateName");
			}
			set {
				SetColumnValue("StateName", value);
				if (_state != null) {
					_state.Name = value;
				}
			}
		}

		private ContractState _state;
		/// <summary>
		/// Состояние.
		/// </summary>
		public ContractState State {
			get {
				return _state ??
					(_state = LookupColumnEntities.GetEntity("State") as ContractState);
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
		public Guid SupplierBillingInfoId {
			get {
				return GetTypedColumnValue<Guid>("SupplierBillingInfoId");
			}
			set {
				SetColumnValue("SupplierBillingInfoId", value);
				_supplierBillingInfo = null;
			}
		}

		/// <exclude/>
		public string SupplierBillingInfoName {
			get {
				return GetTypedColumnValue<string>("SupplierBillingInfoName");
			}
			set {
				SetColumnValue("SupplierBillingInfoName", value);
				if (_supplierBillingInfo != null) {
					_supplierBillingInfo.Name = value;
				}
			}
		}

		private AccountBillingInfo _supplierBillingInfo;
		/// <summary>
		/// Наши реквизиты.
		/// </summary>
		public AccountBillingInfo SupplierBillingInfo {
			get {
				return _supplierBillingInfo ??
					(_supplierBillingInfo = LookupColumnEntities.GetEntity("SupplierBillingInfo") as AccountBillingInfo);
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

		/// <exclude/>
		public Guid CustomerBillingInfoId {
			get {
				return GetTypedColumnValue<Guid>("CustomerBillingInfoId");
			}
			set {
				SetColumnValue("CustomerBillingInfoId", value);
				_customerBillingInfo = null;
			}
		}

		/// <exclude/>
		public string CustomerBillingInfoName {
			get {
				return GetTypedColumnValue<string>("CustomerBillingInfoName");
			}
			set {
				SetColumnValue("CustomerBillingInfoName", value);
				if (_customerBillingInfo != null) {
					_customerBillingInfo.Name = value;
				}
			}
		}

		private AccountBillingInfo _customerBillingInfo;
		/// <summary>
		/// Реквизиты контрагента.
		/// </summary>
		public AccountBillingInfo CustomerBillingInfo {
			get {
				return _customerBillingInfo ??
					(_customerBillingInfo = LookupColumnEntities.GetEntity("CustomerBillingInfo") as AccountBillingInfo);
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
		/// Контакт контрагента.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = LookupColumnEntities.GetEntity("Contact") as Contact);
			}
		}

		/// <summary>
		/// Заметки.
		/// </summary>
		public string Notes {
			get {
				return GetTypedColumnValue<string>("Notes");
			}
			set {
				SetColumnValue("Notes", value);
			}
		}

		/// <exclude/>
		public Guid ParentId {
			get {
				return GetTypedColumnValue<Guid>("ParentId");
			}
			set {
				SetColumnValue("ParentId", value);
				_parent = null;
			}
		}

		/// <exclude/>
		public string ParentNumber {
			get {
				return GetTypedColumnValue<string>("ParentNumber");
			}
			set {
				SetColumnValue("ParentNumber", value);
				if (_parent != null) {
					_parent.Number = value;
				}
			}
		}

		private Contract _parent;
		/// <summary>
		/// Родительский договор.
		/// </summary>
		public Contract Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as Contract);
			}
		}

		/// <exclude/>
		public Guid OurCompanyId {
			get {
				return GetTypedColumnValue<Guid>("OurCompanyId");
			}
			set {
				SetColumnValue("OurCompanyId", value);
				_ourCompany = null;
			}
		}

		/// <exclude/>
		public string OurCompanyName {
			get {
				return GetTypedColumnValue<string>("OurCompanyName");
			}
			set {
				SetColumnValue("OurCompanyName", value);
				if (_ourCompany != null) {
					_ourCompany.Name = value;
				}
			}
		}

		private Account _ourCompany;
		/// <summary>
		/// Наша компания.
		/// </summary>
		public Account OurCompany {
			get {
				return _ourCompany ??
					(_ourCompany = LookupColumnEntities.GetEntity("OurCompany") as Account);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Contract_CoreContractsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Contract_CoreContracts_BPMSoftDeleted", e);
			Validating += (s, e) => ThrowEvent("Contract_CoreContracts_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Contract_CoreContracts_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Contract_CoreContractsEventsProcess

	/// <exclude/>
	public partial class Contract_CoreContractsEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : Contract_CoreContracts_BPMSoft
	{

		public Contract_CoreContractsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Contract_CoreContractsEventsProcess";
			SchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("897be3e4-0333-467d-88e2-b7a945c0d810");
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

	#region Class: Contract_CoreContractsEventsProcess

	/// <exclude/>
	public class Contract_CoreContractsEventsProcess : Contract_CoreContractsEventsProcess<Contract_CoreContracts_BPMSoft>
	{

		public Contract_CoreContractsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Contract_CoreContractsEventsProcess

	public partial class Contract_CoreContractsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

