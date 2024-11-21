namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysModuleReportTable

	/// <exclude/>
	public class SysModuleReportTable : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysModuleReportTable(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysModuleReportTable";
		}

		public SysModuleReportTable(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysModuleReportTable";
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
		/// List of fields.
		/// </summary>
		public string MacrosList {
			get {
				return GetTypedColumnValue<string>("MacrosList");
			}
			set {
				SetColumnValue("MacrosList", value);
			}
		}

		/// <exclude/>
		public Guid SysModuleReportId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleReportId");
			}
			set {
				SetColumnValue("SysModuleReportId", value);
				_sysModuleReport = null;
			}
		}

		/// <exclude/>
		public string SysModuleReportCaption {
			get {
				return GetTypedColumnValue<string>("SysModuleReportCaption");
			}
			set {
				SetColumnValue("SysModuleReportCaption", value);
				if (_sysModuleReport != null) {
					_sysModuleReport.Caption = value;
				}
			}
		}

		private SysModuleReport _sysModuleReport;
		/// <summary>
		/// Printable.
		/// </summary>
		public SysModuleReport SysModuleReport {
			get {
				return _sysModuleReport ??
					(_sysModuleReport = new SysModuleReport(LookupColumnEntities.GetEntity("SysModuleReport")));
			}
		}

		/// <summary>
		/// Path to relationship column.
		/// </summary>
		public string ReferenceColumn {
			get {
				return GetTypedColumnValue<string>("ReferenceColumn");
			}
			set {
				SetColumnValue("ReferenceColumn", value);
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
		/// Object.
		/// </summary>
		public Guid ObjectId {
			get {
				return GetTypedColumnValue<Guid>("ObjectId");
			}
			set {
				SetColumnValue("ObjectId", value);
			}
		}

		/// <summary>
		/// Path to parent object.
		/// </summary>
		public string ObjectColumnPath {
			get {
				return GetTypedColumnValue<string>("ObjectColumnPath");
			}
			set {
				SetColumnValue("ObjectColumnPath", value);
			}
		}

		/// <summary>
		/// Column of parent object.
		/// </summary>
		public string ObjectColumnCaption {
			get {
				return GetTypedColumnValue<string>("ObjectColumnCaption");
			}
			set {
				SetColumnValue("ObjectColumnCaption", value);
			}
		}

		/// <summary>
		/// Relationship column.
		/// </summary>
		public string ReferenceColumnCaption {
			get {
				return GetTypedColumnValue<string>("ReferenceColumnCaption");
			}
			set {
				SetColumnValue("ReferenceColumnCaption", value);
			}
		}

		/// <summary>
		/// Hide the table if it is empty.
		/// </summary>
		public bool IsEmptyTableHide {
			get {
				return GetTypedColumnValue<bool>("IsEmptyTableHide");
			}
			set {
				SetColumnValue("IsEmptyTableHide", value);
			}
		}

		/// <summary>
		/// Filter settings.
		/// </summary>
		public string FilterSettings {
			get {
				return GetTypedColumnValue<string>("FilterSettings");
			}
			set {
				SetColumnValue("FilterSettings", value);
			}
		}

		/// <summary>
		/// Macros settings.
		/// </summary>
		public string MacrosSettings {
			get {
				return GetTypedColumnValue<string>("MacrosSettings");
			}
			set {
				SetColumnValue("MacrosSettings", value);
			}
		}

		#endregion

	}

	#endregion

}

