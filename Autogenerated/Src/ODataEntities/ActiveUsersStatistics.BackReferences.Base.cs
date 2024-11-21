namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: ActiveUsersStatistics

	/// <exclude/>
	public class ActiveUsersStatistics : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public ActiveUsersStatistics(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ActiveUsersStatistics";
		}

		public ActiveUsersStatistics(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "ActiveUsersStatistics";
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
		/// Date/Time.
		/// </summary>
		public DateTime DateValue {
			get {
				return GetTypedColumnValue<DateTime>("DateValue");
			}
			set {
				SetColumnValue("DateValue", value);
			}
		}

		/// <summary>
		/// Session count.
		/// </summary>
		public int SessionCount {
			get {
				return GetTypedColumnValue<int>("SessionCount");
			}
			set {
				SetColumnValue("SessionCount", value);
			}
		}

		/// <summary>
		/// System user count.
		/// </summary>
		public int SysUserCount {
			get {
				return GetTypedColumnValue<int>("SysUserCount");
			}
			set {
				SetColumnValue("SysUserCount", value);
			}
		}

		/// <summary>
		/// Portal user count.
		/// </summary>
		public int PortalUserCount {
			get {
				return GetTypedColumnValue<int>("PortalUserCount");
			}
			set {
				SetColumnValue("PortalUserCount", value);
			}
		}

		#endregion

	}

	#endregion

}

