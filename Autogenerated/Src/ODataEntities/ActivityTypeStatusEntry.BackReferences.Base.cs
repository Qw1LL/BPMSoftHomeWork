namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: ActivityTypeStatusEntry

	/// <exclude/>
	public class ActivityTypeStatusEntry : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public ActivityTypeStatusEntry(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ActivityTypeStatusEntry";
		}

		public ActivityTypeStatusEntry(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "ActivityTypeStatusEntry";
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

		/// <exclude/>
		public Guid ActivityTypeId {
			get {
				return GetTypedColumnValue<Guid>("ActivityTypeId");
			}
			set {
				SetColumnValue("ActivityTypeId", value);
				_activityType = null;
			}
		}

		/// <exclude/>
		public string ActivityTypeName {
			get {
				return GetTypedColumnValue<string>("ActivityTypeName");
			}
			set {
				SetColumnValue("ActivityTypeName", value);
				if (_activityType != null) {
					_activityType.Name = value;
				}
			}
		}

		private ActivityType _activityType;
		/// <summary>
		/// Activity type.
		/// </summary>
		public ActivityType ActivityType {
			get {
				return _activityType ??
					(_activityType = new ActivityType(LookupColumnEntities.GetEntity("ActivityType")));
			}
		}

		/// <exclude/>
		public Guid ActivityStatusId {
			get {
				return GetTypedColumnValue<Guid>("ActivityStatusId");
			}
			set {
				SetColumnValue("ActivityStatusId", value);
				_activityStatus = null;
			}
		}

		/// <exclude/>
		public string ActivityStatusName {
			get {
				return GetTypedColumnValue<string>("ActivityStatusName");
			}
			set {
				SetColumnValue("ActivityStatusName", value);
				if (_activityStatus != null) {
					_activityStatus.Name = value;
				}
			}
		}

		private ActivityStatus _activityStatus;
		/// <summary>
		/// Activity status.
		/// </summary>
		public ActivityStatus ActivityStatus {
			get {
				return _activityStatus ??
					(_activityStatus = new ActivityStatus(LookupColumnEntities.GetEntity("ActivityStatus")));
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

		#endregion

	}

	#endregion

}

