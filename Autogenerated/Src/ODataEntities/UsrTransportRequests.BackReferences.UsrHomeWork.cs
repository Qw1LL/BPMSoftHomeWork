namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: UsrTransportRequests

	/// <exclude/>
	public class UsrTransportRequests : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public UsrTransportRequests(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "UsrTransportRequests";
		}

		public UsrTransportRequests(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "UsrTransportRequests";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<Activity> ActivityCollectionByUsrTransportRequest {
			get;
			set;
		}

		public IEnumerable<UsrTransportRequestsFile> UsrTransportRequestsFileCollectionByUsrTransportRequests {
			get;
			set;
		}

		public IEnumerable<UsrTransportRequestsInFolder> UsrTransportRequestsInFolderCollectionByUsrTransportRequests {
			get;
			set;
		}

		public IEnumerable<UsrTransportRequestsInTag> UsrTransportRequestsInTagCollectionByEntity {
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
		/// Название.
		/// </summary>
		public string UsrName {
			get {
				return GetTypedColumnValue<string>("UsrName");
			}
			set {
				SetColumnValue("UsrName", value);
			}
		}

		/// <summary>
		/// Заметки.
		/// </summary>
		public string UsrNotes {
			get {
				return GetTypedColumnValue<string>("UsrNotes");
			}
			set {
				SetColumnValue("UsrNotes", value);
			}
		}

		/// <summary>
		/// Номер заявки.
		/// </summary>
		public string UsrRequestNumber {
			get {
				return GetTypedColumnValue<string>("UsrRequestNumber");
			}
			set {
				SetColumnValue("UsrRequestNumber", value);
			}
		}

		/// <summary>
		/// Описание.
		/// </summary>
		public string UsrDescription {
			get {
				return GetTypedColumnValue<string>("UsrDescription");
			}
			set {
				SetColumnValue("UsrDescription", value);
			}
		}

		/// <exclude/>
		public Guid UsrOwnerId {
			get {
				return GetTypedColumnValue<Guid>("UsrOwnerId");
			}
			set {
				SetColumnValue("UsrOwnerId", value);
				_usrOwner = null;
			}
		}

		/// <exclude/>
		public string UsrOwnerName {
			get {
				return GetTypedColumnValue<string>("UsrOwnerName");
			}
			set {
				SetColumnValue("UsrOwnerName", value);
				if (_usrOwner != null) {
					_usrOwner.Name = value;
				}
			}
		}

		private Contact _usrOwner;
		/// <summary>
		/// Ответственный.
		/// </summary>
		public Contact UsrOwner {
			get {
				return _usrOwner ??
					(_usrOwner = new Contact(LookupColumnEntities.GetEntity("UsrOwner")));
			}
		}

		/// <exclude/>
		public Guid UsrDriverId {
			get {
				return GetTypedColumnValue<Guid>("UsrDriverId");
			}
			set {
				SetColumnValue("UsrDriverId", value);
				_usrDriver = null;
			}
		}

		/// <exclude/>
		public string UsrDriverName {
			get {
				return GetTypedColumnValue<string>("UsrDriverName");
			}
			set {
				SetColumnValue("UsrDriverName", value);
				if (_usrDriver != null) {
					_usrDriver.Name = value;
				}
			}
		}

		private Contact _usrDriver;
		/// <summary>
		/// Водитель.
		/// </summary>
		public Contact UsrDriver {
			get {
				return _usrDriver ??
					(_usrDriver = new Contact(LookupColumnEntities.GetEntity("UsrDriver")));
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
		/// Адрес доставки.
		/// </summary>
		public string UsrDeliveryAddress {
			get {
				return GetTypedColumnValue<string>("UsrDeliveryAddress");
			}
			set {
				SetColumnValue("UsrDeliveryAddress", value);
			}
		}

		/// <exclude/>
		public Guid UsrCarId {
			get {
				return GetTypedColumnValue<Guid>("UsrCarId");
			}
			set {
				SetColumnValue("UsrCarId", value);
				_usrCar = null;
			}
		}

		/// <exclude/>
		public string UsrCarUsrCarBrand {
			get {
				return GetTypedColumnValue<string>("UsrCarUsrCarBrand");
			}
			set {
				SetColumnValue("UsrCarUsrCarBrand", value);
				if (_usrCar != null) {
					_usrCar.UsrCarBrand = value;
				}
			}
		}

		private UsrCarPark _usrCar;
		/// <summary>
		/// Автомобиль.
		/// </summary>
		public UsrCarPark UsrCar {
			get {
				return _usrCar ??
					(_usrCar = new UsrCarPark(LookupColumnEntities.GetEntity("UsrCar")));
			}
		}

		/// <exclude/>
		public Guid UsrStatusId {
			get {
				return GetTypedColumnValue<Guid>("UsrStatusId");
			}
			set {
				SetColumnValue("UsrStatusId", value);
				_usrStatus = null;
			}
		}

		/// <exclude/>
		public string UsrStatusUsrName {
			get {
				return GetTypedColumnValue<string>("UsrStatusUsrName");
			}
			set {
				SetColumnValue("UsrStatusUsrName", value);
				if (_usrStatus != null) {
					_usrStatus.UsrName = value;
				}
			}
		}

		private UsrTransportRequestsStatus _usrStatus;
		/// <summary>
		/// Статус.
		/// </summary>
		public UsrTransportRequestsStatus UsrStatus {
			get {
				return _usrStatus ??
					(_usrStatus = new UsrTransportRequestsStatus(LookupColumnEntities.GetEntity("UsrStatus")));
			}
		}

		/// <summary>
		/// Дата поездки.
		/// </summary>
		public DateTime UsrTripDate {
			get {
				return GetTypedColumnValue<DateTime>("UsrTripDate");
			}
			set {
				SetColumnValue("UsrTripDate", value);
			}
		}

		#endregion

	}

	#endregion

}

