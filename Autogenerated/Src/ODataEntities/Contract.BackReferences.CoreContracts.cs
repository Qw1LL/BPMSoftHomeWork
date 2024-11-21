namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: Contract

	/// <exclude/>
	public class Contract : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public Contract(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Contract";
		}

		public Contract(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "Contract";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<Activity> ActivityCollectionByContract {
			get;
			set;
		}

		public IEnumerable<Contract> ContractCollectionByParent {
			get;
			set;
		}

		public IEnumerable<ContractFile> ContractFileCollectionByContract {
			get;
			set;
		}

		public IEnumerable<ContractInFolder> ContractInFolderCollectionByContract {
			get;
			set;
		}

		public IEnumerable<ContractInTag> ContractInTagCollectionByEntity {
			get;
			set;
		}

		public IEnumerable<ContractVisa> ContractVisaCollectionByContract {
			get;
			set;
		}

		public IEnumerable<Document> DocumentCollectionByContract {
			get;
			set;
		}

		public IEnumerable<Invoice> InvoiceCollectionByContract {
			get;
			set;
		}

		public IEnumerable<OrderProduct> OrderProductCollectionByContract {
			get;
			set;
		}

		public IEnumerable<SupplyPaymentElement> SupplyPaymentElementCollectionByContract {
			get;
			set;
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

		/// <exclude/>
		public Guid CreatedById {
			get {
				return GetTypedColumnValue<Guid>("CreatedById");
			}
			set {
				SetColumnValue("CreatedById", value);
				_createdBy = null;
			}
		}

		/// <exclude/>
		public string CreatedByName {
			get {
				return GetTypedColumnValue<string>("CreatedByName");
			}
			set {
				SetColumnValue("CreatedByName", value);
				if (_createdBy != null) {
					_createdBy.Name = value;
				}
			}
		}

		private Contact _createdBy;
		/// <summary>
		/// Создал.
		/// </summary>
		public Contact CreatedBy {
			get {
				return _createdBy ??
					(_createdBy = new Contact(LookupColumnEntities.GetEntity("CreatedBy")));
			}
		}

		/// <summary>
		/// Дата изменения.
		/// </summary>
		public DateTime ModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("ModifiedOn");
			}
			set {
				SetColumnValue("ModifiedOn", value);
			}
		}

		/// <exclude/>
		public Guid ModifiedById {
			get {
				return GetTypedColumnValue<Guid>("ModifiedById");
			}
			set {
				SetColumnValue("ModifiedById", value);
				_modifiedBy = null;
			}
		}

		/// <exclude/>
		public string ModifiedByName {
			get {
				return GetTypedColumnValue<string>("ModifiedByName");
			}
			set {
				SetColumnValue("ModifiedByName", value);
				if (_modifiedBy != null) {
					_modifiedBy.Name = value;
				}
			}
		}

		private Contact _modifiedBy;
		/// <summary>
		/// Изменил.
		/// </summary>
		public Contact ModifiedBy {
			get {
				return _modifiedBy ??
					(_modifiedBy = new Contact(LookupColumnEntities.GetEntity("ModifiedBy")));
			}
		}

		/// <summary>
		/// Активные процессы.
		/// </summary>
		public int ProcessListeners {
			get {
				return GetTypedColumnValue<int>("ProcessListeners");
			}
			set {
				SetColumnValue("ProcessListeners", value);
			}
		}

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
					(_type = new ContractType(LookupColumnEntities.GetEntity("Type")));
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
					(_state = new ContractState(LookupColumnEntities.GetEntity("State")));
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
					(_account = new Account(LookupColumnEntities.GetEntity("Account")));
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
					(_supplierBillingInfo = new AccountBillingInfo(LookupColumnEntities.GetEntity("SupplierBillingInfo")));
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
					(_owner = new Contact(LookupColumnEntities.GetEntity("Owner")));
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
					(_customerBillingInfo = new AccountBillingInfo(LookupColumnEntities.GetEntity("CustomerBillingInfo")));
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
					(_contact = new Contact(LookupColumnEntities.GetEntity("Contact")));
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
					(_parent = new Contract(LookupColumnEntities.GetEntity("Parent")));
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
					(_ourCompany = new Account(LookupColumnEntities.GetEntity("OurCompany")));
			}
		}

		/// <exclude/>
		public Guid OrderId {
			get {
				return GetTypedColumnValue<Guid>("OrderId");
			}
			set {
				SetColumnValue("OrderId", value);
				_order = null;
			}
		}

		/// <exclude/>
		public string OrderNumber {
			get {
				return GetTypedColumnValue<string>("OrderNumber");
			}
			set {
				SetColumnValue("OrderNumber", value);
				if (_order != null) {
					_order.Number = value;
				}
			}
		}

		private Order _order;
		/// <summary>
		/// Заказ.
		/// </summary>
		public Order Order {
			get {
				return _order ??
					(_order = new Order(LookupColumnEntities.GetEntity("Order")));
			}
		}

		/// <exclude/>
		public Guid CurrencyId {
			get {
				return GetTypedColumnValue<Guid>("CurrencyId");
			}
			set {
				SetColumnValue("CurrencyId", value);
				_currency = null;
			}
		}

		/// <exclude/>
		public string CurrencyName {
			get {
				return GetTypedColumnValue<string>("CurrencyName");
			}
			set {
				SetColumnValue("CurrencyName", value);
				if (_currency != null) {
					_currency.Name = value;
				}
			}
		}

		private Currency _currency;
		/// <summary>
		/// Валюта.
		/// </summary>
		public Currency Currency {
			get {
				return _currency ??
					(_currency = new Currency(LookupColumnEntities.GetEntity("Currency")));
			}
		}

		/// <summary>
		/// Курс.
		/// </summary>
		public Decimal CurrencyRate {
			get {
				return GetTypedColumnValue<Decimal>("CurrencyRate");
			}
			set {
				SetColumnValue("CurrencyRate", value);
			}
		}

		/// <summary>
		/// Сумма.
		/// </summary>
		public Decimal Amount {
			get {
				return GetTypedColumnValue<Decimal>("Amount");
			}
			set {
				SetColumnValue("Amount", value);
			}
		}

		/// <summary>
		/// Сумма, б.в.
		/// </summary>
		public Decimal PrimaryAmount {
			get {
				return GetTypedColumnValue<Decimal>("PrimaryAmount");
			}
			set {
				SetColumnValue("PrimaryAmount", value);
			}
		}

		#endregion

	}

	#endregion

}

