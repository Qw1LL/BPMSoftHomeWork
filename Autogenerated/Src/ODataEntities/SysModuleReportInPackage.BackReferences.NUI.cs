namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysModuleReportInPackage

	/// <exclude/>
	public class SysModuleReportInPackage : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysModuleReportInPackage(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysModuleReportInPackage";
		}

		public SysModuleReportInPackage(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysModuleReportInPackage";
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
		public Guid SysModuleReportPackageId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleReportPackageId");
			}
			set {
				SetColumnValue("SysModuleReportPackageId", value);
				_sysModuleReportPackage = null;
			}
		}

		/// <exclude/>
		public string SysModuleReportPackageName {
			get {
				return GetTypedColumnValue<string>("SysModuleReportPackageName");
			}
			set {
				SetColumnValue("SysModuleReportPackageName", value);
				if (_sysModuleReportPackage != null) {
					_sysModuleReportPackage.Name = value;
				}
			}
		}

		private SysModuleReportPackage _sysModuleReportPackage;
		/// <summary>
		/// Package of section printables.
		/// </summary>
		public SysModuleReportPackage SysModuleReportPackage {
			get {
				return _sysModuleReportPackage ??
					(_sysModuleReportPackage = new SysModuleReportPackage(LookupColumnEntities.GetEntity("SysModuleReportPackage")));
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

		#endregion

	}

	#endregion

}

