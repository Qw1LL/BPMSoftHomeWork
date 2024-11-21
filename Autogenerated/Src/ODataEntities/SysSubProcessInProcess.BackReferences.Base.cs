namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysSubProcessInProcess

	/// <exclude/>
	public class SysSubProcessInProcess : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysSubProcessInProcess(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysSubProcessInProcess";
		}

		public SysSubProcessInProcess(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysSubProcessInProcess";
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
		/// ProcessUId.
		/// </summary>
		public Guid ProcessUId {
			get {
				return GetTypedColumnValue<Guid>("ProcessUId");
			}
			set {
				SetColumnValue("ProcessUId", value);
			}
		}

		/// <summary>
		/// ParentProcessUId.
		/// </summary>
		public Guid ParentProcessUId {
			get {
				return GetTypedColumnValue<Guid>("ParentProcessUId");
			}
			set {
				SetColumnValue("ParentProcessUId", value);
			}
		}

		/// <summary>
		/// SubProcessUId.
		/// </summary>
		public Guid SubProcessUId {
			get {
				return GetTypedColumnValue<Guid>("SubProcessUId");
			}
			set {
				SetColumnValue("SubProcessUId", value);
			}
		}

		/// <summary>
		/// ParentSubProcessUId.
		/// </summary>
		public Guid ParentSubProcessUId {
			get {
				return GetTypedColumnValue<Guid>("ParentSubProcessUId");
			}
			set {
				SetColumnValue("ParentSubProcessUId", value);
			}
		}

		#endregion

	}

	#endregion

}

