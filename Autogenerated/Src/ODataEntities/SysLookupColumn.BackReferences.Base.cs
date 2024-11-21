namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysLookupColumn

	/// <exclude/>
	public class SysLookupColumn : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysLookupColumn(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysLookupColumn";
		}

		public SysLookupColumn(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysLookupColumn";
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
		public Guid SysLookupId {
			get {
				return GetTypedColumnValue<Guid>("SysLookupId");
			}
			set {
				SetColumnValue("SysLookupId", value);
				_sysLookup = null;
			}
		}

		/// <exclude/>
		public string SysLookupName {
			get {
				return GetTypedColumnValue<string>("SysLookupName");
			}
			set {
				SetColumnValue("SysLookupName", value);
				if (_sysLookup != null) {
					_sysLookup.Name = value;
				}
			}
		}

		private SysLookup _sysLookup;
		/// <summary>
		/// Lookup.
		/// </summary>
		public SysLookup SysLookup {
			get {
				return _sysLookup ??
					(_sysLookup = new SysLookup(LookupColumnEntities.GetEntity("SysLookup")));
			}
		}

		/// <summary>
		/// Column Id.
		/// </summary>
		public string MetaPath {
			get {
				return GetTypedColumnValue<string>("MetaPath");
			}
			set {
				SetColumnValue("MetaPath", value);
			}
		}

		/// <summary>
		/// Position.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		/// <summary>
		/// Title.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
			}
		}

		/// <summary>
		/// Width.
		/// </summary>
		public int Width {
			get {
				return GetTypedColumnValue<int>("Width");
			}
			set {
				SetColumnValue("Width", value);
			}
		}

		/// <exclude/>
		public Guid SysOrderDirectionId {
			get {
				return GetTypedColumnValue<Guid>("SysOrderDirectionId");
			}
			set {
				SetColumnValue("SysOrderDirectionId", value);
				_sysOrderDirection = null;
			}
		}

		/// <exclude/>
		public string SysOrderDirectionName {
			get {
				return GetTypedColumnValue<string>("SysOrderDirectionName");
			}
			set {
				SetColumnValue("SysOrderDirectionName", value);
				if (_sysOrderDirection != null) {
					_sysOrderDirection.Name = value;
				}
			}
		}

		private SysOrderDirection _sysOrderDirection;
		/// <summary>
		/// Sort by.
		/// </summary>
		public SysOrderDirection SysOrderDirection {
			get {
				return _sysOrderDirection ??
					(_sysOrderDirection = new SysOrderDirection(LookupColumnEntities.GetEntity("SysOrderDirection")));
			}
		}

		/// <summary>
		/// Column.
		/// </summary>
		public string MetaCaption {
			get {
				return GetTypedColumnValue<string>("MetaCaption");
			}
			set {
				SetColumnValue("MetaCaption", value);
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

