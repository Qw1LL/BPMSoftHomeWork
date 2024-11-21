namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: UsrTransportRequestsInFolder

	/// <exclude/>
	public class UsrTransportRequestsInFolder : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public UsrTransportRequestsInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "UsrTransportRequestsInFolder";
		}

		public UsrTransportRequestsInFolder(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "UsrTransportRequestsInFolder";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

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

		/// <exclude/>
		public Guid FolderId {
			get {
				return GetTypedColumnValue<Guid>("FolderId");
			}
			set {
				SetColumnValue("FolderId", value);
				_folder = null;
			}
		}

		/// <exclude/>
		public string FolderName {
			get {
				return GetTypedColumnValue<string>("FolderName");
			}
			set {
				SetColumnValue("FolderName", value);
				if (_folder != null) {
					_folder.Name = value;
				}
			}
		}

		private UsrTransportRequestsFolder _folder;
		/// <summary>
		/// Группа Заявки на транспорт.
		/// </summary>
		public UsrTransportRequestsFolder Folder {
			get {
				return _folder ??
					(_folder = new UsrTransportRequestsFolder(LookupColumnEntities.GetEntity("Folder")));
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
		public Guid UsrTransportRequestsId {
			get {
				return GetTypedColumnValue<Guid>("UsrTransportRequestsId");
			}
			set {
				SetColumnValue("UsrTransportRequestsId", value);
				_usrTransportRequests = null;
			}
		}

		/// <exclude/>
		public string UsrTransportRequestsUsrName {
			get {
				return GetTypedColumnValue<string>("UsrTransportRequestsUsrName");
			}
			set {
				SetColumnValue("UsrTransportRequestsUsrName", value);
				if (_usrTransportRequests != null) {
					_usrTransportRequests.UsrName = value;
				}
			}
		}

		private UsrTransportRequests _usrTransportRequests;
		/// <summary>
		/// Заявки на транспорт.
		/// </summary>
		public UsrTransportRequests UsrTransportRequests {
			get {
				return _usrTransportRequests ??
					(_usrTransportRequests = new UsrTransportRequests(LookupColumnEntities.GetEntity("UsrTransportRequests")));
			}
		}

		#endregion

	}

	#endregion

}

