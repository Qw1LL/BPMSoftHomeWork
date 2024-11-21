namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: Invoice

	/// <exclude/>
	public class Invoice : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public Invoice(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Invoice";
		}

		public Invoice(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "Invoice";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<Activity> ActivityCollectionByInvoice {
			get;
			set;
		}

		public IEnumerable<EmailFolderColumnValuesSetting> EmailFolderColumnValuesSettingCollectionByInvoice {
			get;
			set;
		}

		public IEnumerable<InvoiceFile> InvoiceFileCollectionByInvoice {
			get;
			set;
		}

		public IEnumerable<InvoiceInFolder> InvoiceInFolderCollectionByInvoice {
			get;
			set;
		}

		public IEnumerable<InvoiceInTag> InvoiceInTagCollectionByEntity {
			get;
			set;
		}

		public IEnumerable<InvoiceProduct> InvoiceProductCollectionByInvoice {
			get;
			set;
		}

		public IEnumerable<InvoiceVisa> InvoiceVisaCollectionByInvoice {
			get;
			set;
		}

		public IEnumerable<SupplyPaymentElement> SupplyPaymentElementCollectionByInvoice {
			get;
			set;
		}

		public IEnumerable<VwInvoiceProduct> VwInvoiceProductCollectionByInvoice {
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
		/// Дата выставления.
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

		/// <summary>
		/// Сумма оплаты, б.в.
		/// </summary>
		public Decimal PrimaryPaymentAmount {
			get {
				return GetTypedColumnValue<Decimal>("PrimaryPaymentAmount");
			}
			set {
				SetColumnValue("PrimaryPaymentAmount", value);
			}
		}

		/// <exclude/>
		public Guid PaymentStatusId {
			get {
				return GetTypedColumnValue<Guid>("PaymentStatusId");
			}
			set {
				SetColumnValue("PaymentStatusId", value);
				_paymentStatus = null;
			}
		}

		/// <exclude/>
		public string PaymentStatusName {
			get {
				return GetTypedColumnValue<string>("PaymentStatusName");
			}
			set {
				SetColumnValue("PaymentStatusName", value);
				if (_paymentStatus != null) {
					_paymentStatus.Name = value;
				}
			}
		}

		private InvoicePaymentStatus _paymentStatus;
		/// <summary>
		/// Состояние оплаты.
		/// </summary>
		public InvoicePaymentStatus PaymentStatus {
			get {
				return _paymentStatus ??
					(_paymentStatus = new InvoicePaymentStatus(LookupColumnEntities.GetEntity("PaymentStatus")));
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
		/// Платежные реквизиты поставщика.
		/// </summary>
		public AccountBillingInfo SupplierBillingInfo {
			get {
				return _supplierBillingInfo ??
					(_supplierBillingInfo = new AccountBillingInfo(LookupColumnEntities.GetEntity("SupplierBillingInfo")));
			}
		}

		/// <summary>
		/// Напоминать ответственному.
		/// </summary>
		public bool RemindToOwner {
			get {
				return GetTypedColumnValue<bool>("RemindToOwner");
			}
			set {
				SetColumnValue("RemindToOwner", value);
			}
		}

		/// <summary>
		/// Дата напоминания ответственному.
		/// </summary>
		public DateTime RemindToOwnerDate {
			get {
				return GetTypedColumnValue<DateTime>("RemindToOwnerDate");
			}
			set {
				SetColumnValue("RemindToOwnerDate", value);
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
		/// Платежные реквизиты клиента.
		/// </summary>
		public AccountBillingInfo CustomerBillingInfo {
			get {
				return _customerBillingInfo ??
					(_customerBillingInfo = new AccountBillingInfo(LookupColumnEntities.GetEntity("CustomerBillingInfo")));
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
		/// Дата оплаты.
		/// </summary>
		public DateTime DueDate {
			get {
				return GetTypedColumnValue<DateTime>("DueDate");
			}
			set {
				SetColumnValue("DueDate", value);
			}
		}

		/// <summary>
		/// Сумма оплаты.
		/// </summary>
		public Decimal PaymentAmount {
			get {
				return GetTypedColumnValue<Decimal>("PaymentAmount");
			}
			set {
				SetColumnValue("PaymentAmount", value);
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
					(_contact = new Contact(LookupColumnEntities.GetEntity("Contact")));
			}
		}

		/// <exclude/>
		public Guid SupplierId {
			get {
				return GetTypedColumnValue<Guid>("SupplierId");
			}
			set {
				SetColumnValue("SupplierId", value);
				_supplier = null;
			}
		}

		/// <exclude/>
		public string SupplierName {
			get {
				return GetTypedColumnValue<string>("SupplierName");
			}
			set {
				SetColumnValue("SupplierName", value);
				if (_supplier != null) {
					_supplier.Name = value;
				}
			}
		}

		private Account _supplier;
		/// <summary>
		/// Поставщик.
		/// </summary>
		public Account Supplier {
			get {
				return _supplier ??
					(_supplier = new Account(LookupColumnEntities.GetEntity("Supplier")));
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

		/// <exclude/>
		public Guid ProjectId {
			get {
				return GetTypedColumnValue<Guid>("ProjectId");
			}
			set {
				SetColumnValue("ProjectId", value);
				_project = null;
			}
		}

		/// <exclude/>
		public string ProjectName {
			get {
				return GetTypedColumnValue<string>("ProjectName");
			}
			set {
				SetColumnValue("ProjectName", value);
				if (_project != null) {
					_project.Name = value;
				}
			}
		}

		private Project _project;
		/// <summary>
		/// Проект.
		/// </summary>
		public Project Project {
			get {
				return _project ??
					(_project = new Project(LookupColumnEntities.GetEntity("Project")));
			}
		}

		/// <exclude/>
		public Guid OpportunityId {
			get {
				return GetTypedColumnValue<Guid>("OpportunityId");
			}
			set {
				SetColumnValue("OpportunityId", value);
				_opportunity = null;
			}
		}

		/// <exclude/>
		public string OpportunityTitle {
			get {
				return GetTypedColumnValue<string>("OpportunityTitle");
			}
			set {
				SetColumnValue("OpportunityTitle", value);
				if (_opportunity != null) {
					_opportunity.Title = value;
				}
			}
		}

		private Opportunity _opportunity;
		/// <summary>
		/// Продажа.
		/// </summary>
		public Opportunity Opportunity {
			get {
				return _opportunity ??
					(_opportunity = new Opportunity(LookupColumnEntities.GetEntity("Opportunity")));
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
		public Guid ContractId {
			get {
				return GetTypedColumnValue<Guid>("ContractId");
			}
			set {
				SetColumnValue("ContractId", value);
				_contract = null;
			}
		}

		/// <exclude/>
		public string ContractNumber {
			get {
				return GetTypedColumnValue<string>("ContractNumber");
			}
			set {
				SetColumnValue("ContractNumber", value);
				if (_contract != null) {
					_contract.Number = value;
				}
			}
		}

		private Contract _contract;
		/// <summary>
		/// Договор.
		/// </summary>
		public Contract Contract {
			get {
				return _contract ??
					(_contract = new Contract(LookupColumnEntities.GetEntity("Contract")));
			}
		}

		/// <summary>
		/// Сумма без налога.
		/// </summary>
		public Decimal AmountWithoutTax {
			get {
				return GetTypedColumnValue<Decimal>("AmountWithoutTax");
			}
			set {
				SetColumnValue("AmountWithoutTax", value);
			}
		}

		/// <summary>
		/// Сумма без налога, б.в.
		/// </summary>
		public Decimal PrimaryAmountWithoutTax {
			get {
				return GetTypedColumnValue<Decimal>("PrimaryAmountWithoutTax");
			}
			set {
				SetColumnValue("PrimaryAmountWithoutTax", value);
			}
		}

		/// <summary>
		/// Сумма оплаты без налога.
		/// </summary>
		public Decimal PaymentAmountWithoutTax {
			get {
				return GetTypedColumnValue<Decimal>("PaymentAmountWithoutTax");
			}
			set {
				SetColumnValue("PaymentAmountWithoutTax", value);
			}
		}

		/// <summary>
		/// Сумма оплаты без налога, б.в.
		/// </summary>
		public Decimal PrimaryPaymentAmountWithoutTax {
			get {
				return GetTypedColumnValue<Decimal>("PrimaryPaymentAmountWithoutTax");
			}
			set {
				SetColumnValue("PrimaryPaymentAmountWithoutTax", value);
			}
		}

		#endregion

	}

	#endregion

}

