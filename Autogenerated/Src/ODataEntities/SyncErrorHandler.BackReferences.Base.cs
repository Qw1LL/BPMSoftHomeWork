namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SyncErrorHandler

	/// <exclude/>
	public class SyncErrorHandler : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SyncErrorHandler(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SyncErrorHandler";
		}

		public SyncErrorHandler(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SyncErrorHandler";
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

		/// <summary>
		/// Code.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
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
		/// Exception class name.
		/// </summary>
		public string ExceptionClass {
			get {
				return GetTypedColumnValue<string>("ExceptionClass");
			}
			set {
				SetColumnValue("ExceptionClass", value);
			}
		}

		/// <summary>
		/// Exception message filter.
		/// </summary>
		public string MessageFilter {
			get {
				return GetTypedColumnValue<string>("MessageFilter");
			}
			set {
				SetColumnValue("MessageFilter", value);
			}
		}

		/// <summary>
		/// Synchronization retry attempts count.
		/// </summary>
		public int RetryCount {
			get {
				return GetTypedColumnValue<int>("RetryCount");
			}
			set {
				SetColumnValue("RetryCount", value);
			}
		}

		/// <exclude/>
		public Guid ErrorCodeId {
			get {
				return GetTypedColumnValue<Guid>("ErrorCodeId");
			}
			set {
				SetColumnValue("ErrorCodeId", value);
				_errorCode = null;
			}
		}

		/// <exclude/>
		public string ErrorCodeName {
			get {
				return GetTypedColumnValue<string>("ErrorCodeName");
			}
			set {
				SetColumnValue("ErrorCodeName", value);
				if (_errorCode != null) {
					_errorCode.Name = value;
				}
			}
		}

		private SyncErrorMessage _errorCode;
		/// <summary>
		/// Error code identifier.
		/// </summary>
		public SyncErrorMessage ErrorCode {
			get {
				return _errorCode ??
					(_errorCode = new SyncErrorMessage(LookupColumnEntities.GetEntity("ErrorCode")));
			}
		}

		/// <summary>
		/// Do not stop syncing.
		/// </summary>
		public bool NotStopSyncing {
			get {
				return GetTypedColumnValue<bool>("NotStopSyncing");
			}
			set {
				SetColumnValue("NotStopSyncing", value);
			}
		}

		#endregion

	}

	#endregion

}

