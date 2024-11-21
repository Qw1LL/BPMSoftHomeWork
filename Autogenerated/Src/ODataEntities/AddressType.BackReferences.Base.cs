namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: AddressType

	/// <exclude/>
	public class AddressType : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public AddressType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AddressType";
		}

		public AddressType(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "AddressType";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<Account> AccountCollectionByAddressType {
			get;
			set;
		}

		public IEnumerable<AccountAddress> AccountAddressCollectionByAddressType {
			get;
			set;
		}

		public IEnumerable<Contact> ContactCollectionByAddressType {
			get;
			set;
		}

		public IEnumerable<ContactAddress> ContactAddressCollectionByAddressType {
			get;
			set;
		}

		public IEnumerable<Lead> LeadCollectionByAddressType {
			get;
			set;
		}

		public IEnumerable<LeadAddress> LeadAddressCollectionByAddressType {
			get;
			set;
		}

		public IEnumerable<LeadQualification> LeadQualificationCollectionByLeadAccountAddressType {
			get;
			set;
		}

		public IEnumerable<LeadQualification> LeadQualificationCollectionByLeadContactAddressType {
			get;
			set;
		}

		public IEnumerable<VwClientAddress> VwClientAddressCollectionByAddressType {
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

		/// <summary>
		/// Использовать в контактах.
		/// </summary>
		public bool ForContact {
			get {
				return GetTypedColumnValue<bool>("ForContact");
			}
			set {
				SetColumnValue("ForContact", value);
			}
		}

		/// <summary>
		/// Использовать в контрагентах.
		/// </summary>
		public bool ForAccount {
			get {
				return GetTypedColumnValue<bool>("ForAccount");
			}
			set {
				SetColumnValue("ForAccount", value);
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

		#endregion

	}

	#endregion

}

