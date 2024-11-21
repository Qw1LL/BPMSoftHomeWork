namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: ActivityCategoryResultEntry

	/// <exclude/>
	public class ActivityCategoryResultEntry : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public ActivityCategoryResultEntry(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ActivityCategoryResultEntry";
		}

		public ActivityCategoryResultEntry(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "ActivityCategoryResultEntry";
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
		public Guid ActivityResultId {
			get {
				return GetTypedColumnValue<Guid>("ActivityResultId");
			}
			set {
				SetColumnValue("ActivityResultId", value);
				_activityResult = null;
			}
		}

		/// <exclude/>
		public string ActivityResultName {
			get {
				return GetTypedColumnValue<string>("ActivityResultName");
			}
			set {
				SetColumnValue("ActivityResultName", value);
				if (_activityResult != null) {
					_activityResult.Name = value;
				}
			}
		}

		private ActivityResult _activityResult;
		/// <summary>
		/// Result of activity.
		/// </summary>
		public ActivityResult ActivityResult {
			get {
				return _activityResult ??
					(_activityResult = new ActivityResult(LookupColumnEntities.GetEntity("ActivityResult")));
			}
		}

		/// <exclude/>
		public Guid ActivityCategoryId {
			get {
				return GetTypedColumnValue<Guid>("ActivityCategoryId");
			}
			set {
				SetColumnValue("ActivityCategoryId", value);
				_activityCategory = null;
			}
		}

		/// <exclude/>
		public string ActivityCategoryName {
			get {
				return GetTypedColumnValue<string>("ActivityCategoryName");
			}
			set {
				SetColumnValue("ActivityCategoryName", value);
				if (_activityCategory != null) {
					_activityCategory.Name = value;
				}
			}
		}

		private ActivityCategory _activityCategory;
		/// <summary>
		/// Activity category.
		/// </summary>
		public ActivityCategory ActivityCategory {
			get {
				return _activityCategory ??
					(_activityCategory = new ActivityCategory(LookupColumnEntities.GetEntity("ActivityCategory")));
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

