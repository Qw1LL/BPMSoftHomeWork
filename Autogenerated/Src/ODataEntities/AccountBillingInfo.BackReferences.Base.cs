namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: AccountBillingInfo

	/// <exclude/>
	public class AccountBillingInfo : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public AccountBillingInfo(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AccountBillingInfo";
		}

		public AccountBillingInfo(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "AccountBillingInfo";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<Contract> ContractCollectionByCustomerBillingInfo {
			get;
			set;
		}

		public IEnumerable<Contract> ContractCollectionBySupplierBillingInfo {
			get;
			set;
		}

		public IEnumerable<Invoice> InvoiceCollectionByCustomerBillingInfo {
			get;
			set;
		}

		public IEnumerable<Invoice> InvoiceCollectionBySupplierBillingInfo {
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
		/// Название.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Описание.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
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
		public Guid CountryId {
			get {
				return GetTypedColumnValue<Guid>("CountryId");
			}
			set {
				SetColumnValue("CountryId", value);
				_country = null;
			}
		}

		/// <exclude/>
		public string CountryName {
			get {
				return GetTypedColumnValue<string>("CountryName");
			}
			set {
				SetColumnValue("CountryName", value);
				if (_country != null) {
					_country.Name = value;
				}
			}
		}

		private Country _country;
		/// <summary>
		/// Страна.
		/// </summary>
		public Country Country {
			get {
				return _country ??
					(_country = new Country(LookupColumnEntities.GetEntity("Country")));
			}
		}

		/// <summary>
		/// Платежные реквизиты.
		/// </summary>
		public string BillingInfo {
			get {
				return GetTypedColumnValue<string>("BillingInfo");
			}
			set {
				SetColumnValue("BillingInfo", value);
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
		public Guid AccountManagerId {
			get {
				return GetTypedColumnValue<Guid>("AccountManagerId");
			}
			set {
				SetColumnValue("AccountManagerId", value);
				_accountManager = null;
			}
		}

		/// <exclude/>
		public string AccountManagerName {
			get {
				return GetTypedColumnValue<string>("AccountManagerName");
			}
			set {
				SetColumnValue("AccountManagerName", value);
				if (_accountManager != null) {
					_accountManager.Name = value;
				}
			}
		}

		private Contact _accountManager;
		/// <summary>
		/// Руководитель.
		/// </summary>
		public Contact AccountManager {
			get {
				return _accountManager ??
					(_accountManager = new Contact(LookupColumnEntities.GetEntity("AccountManager")));
			}
		}

		/// <exclude/>
		public Guid ChiefAccountantId {
			get {
				return GetTypedColumnValue<Guid>("ChiefAccountantId");
			}
			set {
				SetColumnValue("ChiefAccountantId", value);
				_chiefAccountant = null;
			}
		}

		/// <exclude/>
		public string ChiefAccountantName {
			get {
				return GetTypedColumnValue<string>("ChiefAccountantName");
			}
			set {
				SetColumnValue("ChiefAccountantName", value);
				if (_chiefAccountant != null) {
					_chiefAccountant.Name = value;
				}
			}
		}

		private Contact _chiefAccountant;
		/// <summary>
		/// Главный бухгалтер.
		/// </summary>
		public Contact ChiefAccountant {
			get {
				return _chiefAccountant ??
					(_chiefAccountant = new Contact(LookupColumnEntities.GetEntity("ChiefAccountant")));
			}
		}

		/// <summary>
		/// Юридическое лицо.
		/// </summary>
		public string LegalUnit {
			get {
				return GetTypedColumnValue<string>("LegalUnit");
			}
			set {
				SetColumnValue("LegalUnit", value);
			}
		}

		#endregion

	}

	#endregion

}

