namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: OAuthClientApp

	/// <exclude/>
	public class OAuthClientApp : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public OAuthClientApp(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OAuthClientApp";
		}

		public OAuthClientApp(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "OAuthClientApp";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<OAuthResourceInClient> OAuthResourceInClientCollectionByOAuthClient {
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
		/// Created on.
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
		/// Created by.
		/// </summary>
		public Contact CreatedBy {
			get {
				return _createdBy ??
					(_createdBy = new Contact(LookupColumnEntities.GetEntity("CreatedBy")));
			}
		}

		/// <summary>
		/// Modified on.
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
		/// Modified by.
		/// </summary>
		public Contact ModifiedBy {
			get {
				return _modifiedBy ??
					(_modifiedBy = new Contact(LookupColumnEntities.GetEntity("ModifiedBy")));
			}
		}

		/// <summary>
		/// Active processes.
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
		/// Name.
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
		/// Client Id.
		/// </summary>
		public string ClientId {
			get {
				return GetTypedColumnValue<string>("ClientId");
			}
			set {
				SetColumnValue("ClientId", value);
			}
		}

		/// <summary>
		/// Client secret.
		/// </summary>
		public string ClientSecret {
			get {
				return GetTypedColumnValue<string>("ClientSecret");
			}
			set {
				SetColumnValue("ClientSecret", value);
			}
		}

		/// <summary>
		/// Redirect URL.
		/// </summary>
		public string RedirectUrl {
			get {
				return GetTypedColumnValue<string>("RedirectUrl");
			}
			set {
				SetColumnValue("RedirectUrl", value);
			}
		}

		/// <summary>
		/// Application URL.
		/// </summary>
		public string ApplicationUrl {
			get {
				return GetTypedColumnValue<string>("ApplicationUrl");
			}
			set {
				SetColumnValue("ApplicationUrl", value);
			}
		}

		/// <summary>
		/// Active.
		/// </summary>
		public bool IsActive {
			get {
				return GetTypedColumnValue<bool>("IsActive");
			}
			set {
				SetColumnValue("IsActive", value);
			}
		}

		/// <exclude/>
		public Guid SystemUserId {
			get {
				return GetTypedColumnValue<Guid>("SystemUserId");
			}
			set {
				SetColumnValue("SystemUserId", value);
				_systemUser = null;
			}
		}

		/// <exclude/>
		public string SystemUserName {
			get {
				return GetTypedColumnValue<string>("SystemUserName");
			}
			set {
				SetColumnValue("SystemUserName", value);
				if (_systemUser != null) {
					_systemUser.Name = value;
				}
			}
		}

		private SysAdminUnit _systemUser;
		/// <summary>
		/// System user.
		/// </summary>
		public SysAdminUnit SystemUser {
			get {
				return _systemUser ??
					(_systemUser = new SysAdminUnit(LookupColumnEntities.GetEntity("SystemUser")));
			}
		}

		/// <summary>
		/// Description.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		#endregion

	}

	#endregion

}

