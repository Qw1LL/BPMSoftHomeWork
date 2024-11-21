namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: TouchEventLog

	/// <exclude/>
	public class TouchEventLog : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public TouchEventLog(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "TouchEventLog";
		}

		public TouchEventLog(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "TouchEventLog";
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
		/// Has errors.
		/// </summary>
		public bool HasErrors {
			get {
				return GetTypedColumnValue<bool>("HasErrors");
			}
			set {
				SetColumnValue("HasErrors", value);
			}
		}

		/// <summary>
		/// Error details.
		/// </summary>
		public string ErrorDetails {
			get {
				return GetTypedColumnValue<string>("ErrorDetails");
			}
			set {
				SetColumnValue("ErrorDetails", value);
			}
		}

		/// <exclude/>
		public Guid TrackingId {
			get {
				return GetTypedColumnValue<Guid>("TrackingId");
			}
			set {
				SetColumnValue("TrackingId", value);
				_tracking = null;
			}
		}

		/// <exclude/>
		public string TrackingName {
			get {
				return GetTypedColumnValue<string>("TrackingName");
			}
			set {
				SetColumnValue("TrackingName", value);
				if (_tracking != null) {
					_tracking.Name = value;
				}
			}
		}

		private TouchEventTracking _tracking;
		/// <summary>
		/// Tracking.
		/// </summary>
		public TouchEventTracking Tracking {
			get {
				return _tracking ??
					(_tracking = new TouchEventTracking(LookupColumnEntities.GetEntity("Tracking")));
			}
		}

		/// <summary>
		/// Message type.
		/// </summary>
		public string MessageTypeName {
			get {
				return GetTypedColumnValue<string>("MessageTypeName");
			}
			set {
				SetColumnValue("MessageTypeName", value);
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
		/// Amount.
		/// </summary>
		public int Amount {
			get {
				return GetTypedColumnValue<int>("Amount");
			}
			set {
				SetColumnValue("Amount", value);
			}
		}

		#endregion

	}

	#endregion

}

