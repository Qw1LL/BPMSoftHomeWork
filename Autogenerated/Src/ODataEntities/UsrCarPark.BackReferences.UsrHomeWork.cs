namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: UsrCarPark

	/// <exclude/>
	public class UsrCarPark : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public UsrCarPark(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "UsrCarPark";
		}

		public UsrCarPark(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "UsrCarPark";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<UsrTransportRequests> UsrTransportRequestsCollectionByUsrCar {
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
		/// Номер машины.
		/// </summary>
		public string UsrCarNumber {
			get {
				return GetTypedColumnValue<string>("UsrCarNumber");
			}
			set {
				SetColumnValue("UsrCarNumber", value);
			}
		}

		/// <summary>
		/// Марка.
		/// </summary>
		public string UsrCarBrand {
			get {
				return GetTypedColumnValue<string>("UsrCarBrand");
			}
			set {
				SetColumnValue("UsrCarBrand", value);
			}
		}

		/// <exclude/>
		public Guid UsrCompanyId {
			get {
				return GetTypedColumnValue<Guid>("UsrCompanyId");
			}
			set {
				SetColumnValue("UsrCompanyId", value);
				_usrCompany = null;
			}
		}

		/// <exclude/>
		public string UsrCompanyName {
			get {
				return GetTypedColumnValue<string>("UsrCompanyName");
			}
			set {
				SetColumnValue("UsrCompanyName", value);
				if (_usrCompany != null) {
					_usrCompany.Name = value;
				}
			}
		}

		private Account _usrCompany;
		/// <summary>
		/// Компания.
		/// </summary>
		public Account UsrCompany {
			get {
				return _usrCompany ??
					(_usrCompany = new Account(LookupColumnEntities.GetEntity("UsrCompany")));
			}
		}

		/// <summary>
		/// Актуальный.
		/// </summary>
		public bool UsrIsActual {
			get {
				return GetTypedColumnValue<bool>("UsrIsActual");
			}
			set {
				SetColumnValue("UsrIsActual", value);
			}
		}

		#endregion

	}

	#endregion

}

