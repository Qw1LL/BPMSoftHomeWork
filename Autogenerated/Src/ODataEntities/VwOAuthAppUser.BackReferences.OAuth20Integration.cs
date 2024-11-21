namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: VwOAuthAppUser

	/// <exclude/>
	public class VwOAuthAppUser : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwOAuthAppUser(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwOAuthAppUser";
		}

		public VwOAuthAppUser(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "VwOAuthAppUser";
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

		/// <exclude/>
		public Guid SysUserId {
			get {
				return GetTypedColumnValue<Guid>("SysUserId");
			}
			set {
				SetColumnValue("SysUserId", value);
				_sysUser = null;
			}
		}

		/// <exclude/>
		public string SysUserName {
			get {
				return GetTypedColumnValue<string>("SysUserName");
			}
			set {
				SetColumnValue("SysUserName", value);
				if (_sysUser != null) {
					_sysUser.Name = value;
				}
			}
		}

		private SysAdminUnit _sysUser;
		/// <summary>
		/// System administrative unit identifier.
		/// </summary>
		public SysAdminUnit SysUser {
			get {
				return _sysUser ??
					(_sysUser = new SysAdminUnit(LookupColumnEntities.GetEntity("SysUser")));
			}
		}

		/// <exclude/>
		public Guid OAuthAppId {
			get {
				return GetTypedColumnValue<Guid>("OAuthAppId");
			}
			set {
				SetColumnValue("OAuthAppId", value);
				_oAuthApp = null;
			}
		}

		/// <exclude/>
		public string OAuthAppName {
			get {
				return GetTypedColumnValue<string>("OAuthAppName");
			}
			set {
				SetColumnValue("OAuthAppName", value);
				if (_oAuthApp != null) {
					_oAuthApp.Name = value;
				}
			}
		}

		private OAuthApplications _oAuthApp;
		/// <summary>
		/// OAuth application identifier.
		/// </summary>
		public OAuthApplications OAuthApp {
			get {
				return _oAuthApp ??
					(_oAuthApp = new OAuthApplications(LookupColumnEntities.GetEntity("OAuthApp")));
			}
		}

		/// <summary>
		/// User login to the application.
		/// </summary>
		public string UserAppLogin {
			get {
				return GetTypedColumnValue<string>("UserAppLogin");
			}
			set {
				SetColumnValue("UserAppLogin", value);
			}
		}

		/// <summary>
		/// OAuth access token.
		/// </summary>
		public string AccessToken {
			get {
				return GetTypedColumnValue<string>("AccessToken");
			}
			set {
				SetColumnValue("AccessToken", value);
			}
		}

		/// <summary>
		/// Time in seconds since 1970.01.01 after which the token expires.
		/// </summary>
		public int ExpiresOn {
			get {
				return GetTypedColumnValue<int>("ExpiresOn");
			}
			set {
				SetColumnValue("ExpiresOn", value);
			}
		}

		/// <summary>
		/// OAuth refresh token.
		/// </summary>
		public string RefreshToken {
			get {
				return GetTypedColumnValue<string>("RefreshToken");
			}
			set {
				SetColumnValue("RefreshToken", value);
			}
		}

		#endregion

	}

	#endregion

}

