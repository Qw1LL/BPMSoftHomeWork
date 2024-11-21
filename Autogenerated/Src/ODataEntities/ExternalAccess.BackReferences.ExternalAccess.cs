namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: ExternalAccess

	/// <exclude/>
	public class ExternalAccess : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public ExternalAccess(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ExternalAccess";
		}

		public ExternalAccess(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "ExternalAccess";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<ExternalAccessFile> ExternalAccessFileCollectionByExternalAccess {
			get;
			set;
		}

		public IEnumerable<ExternalAccessInFolder> ExternalAccessInFolderCollectionByExternalAccess {
			get;
			set;
		}

		public IEnumerable<ExternalAccessInTag> ExternalAccessInTagCollectionByEntity {
			get;
			set;
		}

		public IEnumerable<SysIsolatedRecord> SysIsolatedRecordCollectionByExternalAccess {
			get;
			set;
		}

		public IEnumerable<SysUserSession> SysUserSessionCollectionByExternalAccess {
			get;
			set;
		}

		public IEnumerable<VwIsolatedRecord> VwIsolatedRecordCollectionByExternalAccess {
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
		/// Reason to grant access.
		/// </summary>
		public string AccessReason {
			get {
				return GetTypedColumnValue<string>("AccessReason");
			}
			set {
				SetColumnValue("AccessReason", value);
			}
		}

		/// <summary>
		/// Notes.
		/// </summary>
		public string Notes {
			get {
				return GetTypedColumnValue<string>("Notes");
			}
			set {
				SetColumnValue("Notes", value);
			}
		}

		/// <summary>
		/// Start date.
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
		/// Access close date.
		/// </summary>
		public DateTime DueDate {
			get {
				return GetTypedColumnValue<DateTime>("DueDate");
			}
			set {
				SetColumnValue("DueDate", value);
			}
		}

		/// <exclude/>
		public Guid GrantorId {
			get {
				return GetTypedColumnValue<Guid>("GrantorId");
			}
			set {
				SetColumnValue("GrantorId", value);
				_grantor = null;
			}
		}

		/// <exclude/>
		public string GrantorName {
			get {
				return GetTypedColumnValue<string>("GrantorName");
			}
			set {
				SetColumnValue("GrantorName", value);
				if (_grantor != null) {
					_grantor.Name = value;
				}
			}
		}

		private Contact _grantor;
		/// <summary>
		/// Grantor.
		/// </summary>
		public Contact Grantor {
			get {
				return _grantor ??
					(_grantor = new Contact(LookupColumnEntities.GetEntity("Grantor")));
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

		/// <summary>
		/// Deny access to data.
		/// </summary>
		public bool IsDataIsolationEnabled {
			get {
				return GetTypedColumnValue<bool>("IsDataIsolationEnabled");
			}
			set {
				SetColumnValue("IsDataIsolationEnabled", value);
			}
		}

		/// <summary>
		/// Deny configuration.
		/// </summary>
		public bool IsSystemOperationsRestricted {
			get {
				return GetTypedColumnValue<bool>("IsSystemOperationsRestricted");
			}
			set {
				SetColumnValue("IsSystemOperationsRestricted", value);
			}
		}

		/// <exclude/>
		public Guid ExternalAccessClientId {
			get {
				return GetTypedColumnValue<Guid>("ExternalAccessClientId");
			}
			set {
				SetColumnValue("ExternalAccessClientId", value);
				_externalAccessClient = null;
			}
		}

		/// <exclude/>
		public string ExternalAccessClientClientId {
			get {
				return GetTypedColumnValue<string>("ExternalAccessClientClientId");
			}
			set {
				SetColumnValue("ExternalAccessClientClientId", value);
				if (_externalAccessClient != null) {
					_externalAccessClient.ClientId = value;
				}
			}
		}

		private ExternalAccessClient _externalAccessClient;
		/// <summary>
		/// Access client.
		/// </summary>
		public ExternalAccessClient ExternalAccessClient {
			get {
				return _externalAccessClient ??
					(_externalAccessClient = new ExternalAccessClient(LookupColumnEntities.GetEntity("ExternalAccessClient")));
			}
		}

		#endregion

	}

	#endregion

}

