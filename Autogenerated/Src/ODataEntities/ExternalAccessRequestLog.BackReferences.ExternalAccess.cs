namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: ExternalAccessRequestLog

	/// <exclude/>
	public class ExternalAccessRequestLog : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public ExternalAccessRequestLog(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ExternalAccessRequestLog";
		}

		public ExternalAccessRequestLog(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "ExternalAccessRequestLog";
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

		/// <summary>
		/// Date.
		/// </summary>
		public DateTime RequestedOn {
			get {
				return GetTypedColumnValue<DateTime>("RequestedOn");
			}
			set {
				SetColumnValue("RequestedOn", value);
			}
		}

		/// <exclude/>
		public Guid RequestedById {
			get {
				return GetTypedColumnValue<Guid>("RequestedById");
			}
			set {
				SetColumnValue("RequestedById", value);
				_requestedBy = null;
			}
		}

		/// <exclude/>
		public string RequestedByName {
			get {
				return GetTypedColumnValue<string>("RequestedByName");
			}
			set {
				SetColumnValue("RequestedByName", value);
				if (_requestedBy != null) {
					_requestedBy.Name = value;
				}
			}
		}

		private Contact _requestedBy;
		/// <summary>
		/// User.
		/// </summary>
		public Contact RequestedBy {
			get {
				return _requestedBy ??
					(_requestedBy = new Contact(LookupColumnEntities.GetEntity("RequestedBy")));
			}
		}

		/// <summary>
		/// Site URL.
		/// </summary>
		public string Url {
			get {
				return GetTypedColumnValue<string>("Url");
			}
			set {
				SetColumnValue("Url", value);
			}
		}

		/// <summary>
		/// Subscription.
		/// </summary>
		public string CustomerId {
			get {
				return GetTypedColumnValue<string>("CustomerId");
			}
			set {
				SetColumnValue("CustomerId", value);
			}
		}

		/// <summary>
		/// External access id.
		/// </summary>
		public Guid ExternalAccessId {
			get {
				return GetTypedColumnValue<Guid>("ExternalAccessId");
			}
			set {
				SetColumnValue("ExternalAccessId", value);
			}
		}

		/// <summary>
		/// Access description.
		/// </summary>
		public string ExternalAccessDescription {
			get {
				return GetTypedColumnValue<string>("ExternalAccessDescription");
			}
			set {
				SetColumnValue("ExternalAccessDescription", value);
			}
		}

		#endregion

	}

	#endregion

}

