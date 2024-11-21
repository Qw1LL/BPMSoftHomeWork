namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysModuleAnalyticsReport

	/// <exclude/>
	public class SysModuleAnalyticsReport : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysModuleAnalyticsReport(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysModuleAnalyticsReport";
		}

		public SysModuleAnalyticsReport(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysModuleAnalyticsReport";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<SysModuleAnalyticsReportLczOld> SysModuleAnalyticsReportLczOldCollectionByRecord {
			get;
			set;
		}

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

		/// <exclude/>
		public Guid SysModuleId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleId");
			}
			set {
				SetColumnValue("SysModuleId", value);
				_sysModule = null;
			}
		}

		/// <exclude/>
		public string SysModuleCaption {
			get {
				return GetTypedColumnValue<string>("SysModuleCaption");
			}
			set {
				SetColumnValue("SysModuleCaption", value);
				if (_sysModule != null) {
					_sysModule.Caption = value;
				}
			}
		}

		private SysModule _sysModule;
		/// <summary>
		/// Section.
		/// </summary>
		public SysModule SysModule {
			get {
				return _sysModule ??
					(_sysModule = new SysModule(LookupColumnEntities.GetEntity("SysModule")));
			}
		}

		/// <summary>
		/// Automatic preview.
		/// </summary>
		public bool AutoPreview {
			get {
				return GetTypedColumnValue<bool>("AutoPreview");
			}
			set {
				SetColumnValue("AutoPreview", value);
			}
		}

		/// <summary>
		/// Contextual help Id.
		/// </summary>
		public string HelpContextId {
			get {
				return GetTypedColumnValue<string>("HelpContextId");
			}
			set {
				SetColumnValue("HelpContextId", value);
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
		/// Unique identifier of report.
		/// </summary>
		public Guid SysSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysSchemaUId");
			}
			set {
				SetColumnValue("SysSchemaUId", value);
			}
		}

		/// <summary>
		/// Unique identifier of analytics setup.
		/// </summary>
		public Guid SysOptionsPageSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysOptionsPageSchemaUId");
			}
			set {
				SetColumnValue("SysOptionsPageSchemaUId", value);
			}
		}

		/// <summary>
		/// Section object name.
		/// </summary>
		public string ModuleSchemaName {
			get {
				return GetTypedColumnValue<string>("ModuleSchemaName");
			}
			set {
				SetColumnValue("ModuleSchemaName", value);
			}
		}

		/// <exclude/>
		public Guid LogoId {
			get {
				return GetTypedColumnValue<Guid>("LogoId");
			}
			set {
				SetColumnValue("LogoId", value);
				_logo = null;
			}
		}

		/// <exclude/>
		public string LogoName {
			get {
				return GetTypedColumnValue<string>("LogoName");
			}
			set {
				SetColumnValue("LogoName", value);
				if (_logo != null) {
					_logo.Name = value;
				}
			}
		}

		private SysImage _logo;
		/// <summary>
		/// Logo.
		/// </summary>
		public SysImage Logo {
			get {
				return _logo ??
					(_logo = new SysImage(LookupColumnEntities.GetEntity("Logo")));
			}
		}

		/// <exclude/>
		public Guid TypeId {
			get {
				return GetTypedColumnValue<Guid>("TypeId");
			}
			set {
				SetColumnValue("TypeId", value);
				_type = null;
			}
		}

		/// <exclude/>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
				if (_type != null) {
					_type.Name = value;
				}
			}
		}

		private SysModuleReportType _type;
		/// <summary>
		/// Type.
		/// </summary>
		public SysModuleReportType Type {
			get {
				return _type ??
					(_type = new SysModuleReportType(LookupColumnEntities.GetEntity("Type")));
			}
		}

		#endregion

	}

	#endregion

}

