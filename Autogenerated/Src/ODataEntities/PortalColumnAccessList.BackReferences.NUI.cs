namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: PortalColumnAccessList

	/// <exclude/>
	public class PortalColumnAccessList : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public PortalColumnAccessList(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "PortalColumnAccessList";
		}

		public PortalColumnAccessList(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "PortalColumnAccessList";
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
		public Guid PortalSchemaListId {
			get {
				return GetTypedColumnValue<Guid>("PortalSchemaListId");
			}
			set {
				SetColumnValue("PortalSchemaListId", value);
				_portalSchemaList = null;
			}
		}

		/// <exclude/>
		public string PortalSchemaListAccessEntitySchemaName {
			get {
				return GetTypedColumnValue<string>("PortalSchemaListAccessEntitySchemaName");
			}
			set {
				SetColumnValue("PortalSchemaListAccessEntitySchemaName", value);
				if (_portalSchemaList != null) {
					_portalSchemaList.AccessEntitySchemaName = value;
				}
			}
		}

		private PortalSchemaAccessList _portalSchemaList;
		/// <summary>
		/// List of schema fields for portal access.
		/// </summary>
		public PortalSchemaAccessList PortalSchemaList {
			get {
				return _portalSchemaList ??
					(_portalSchemaList = new PortalSchemaAccessList(LookupColumnEntities.GetEntity("PortalSchemaList")));
			}
		}

		/// <summary>
		/// Column.
		/// </summary>
		public Guid ColumnUId {
			get {
				return GetTypedColumnValue<Guid>("ColumnUId");
			}
			set {
				SetColumnValue("ColumnUId", value);
			}
		}

		/// <summary>
		/// Column name.
		/// </summary>
		public string ColumnName {
			get {
				return GetTypedColumnValue<string>("ColumnName");
			}
			set {
				SetColumnValue("ColumnName", value);
			}
		}

		#endregion

	}

	#endregion

}

