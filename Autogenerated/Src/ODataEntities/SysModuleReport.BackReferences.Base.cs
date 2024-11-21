namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysModuleReport

	/// <exclude/>
	public class SysModuleReport : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysModuleReport(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysModuleReport";
		}

		public SysModuleReport(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysModuleReport";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<SysModuleReportInPackage> SysModuleReportInPackageCollectionBySysModuleReport {
			get;
			set;
		}

		public IEnumerable<SysModuleReportLczOld> SysModuleReportLczOldCollectionByRecord {
			get;
			set;
		}

		public IEnumerable<SysModuleReportTable> SysModuleReportTableCollectionBySysModuleReport {
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

		/// <summary>
		/// File name.
		/// </summary>
		public string FileName {
			get {
				return GetTypedColumnValue<string>("FileName");
			}
			set {
				SetColumnValue("FileName", value);
			}
		}

		/// <summary>
		/// Unique identifier of printable form.
		/// </summary>
		public Guid SysReportSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysReportSchemaUId");
			}
			set {
				SetColumnValue("SysReportSchemaUId", value);
			}
		}

		/// <summary>
		/// Unique identifier of printable form setup.
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
		/// Show in section.
		/// </summary>
		public bool ShowInSection {
			get {
				return GetTypedColumnValue<bool>("ShowInSection");
			}
			set {
				SetColumnValue("ShowInSection", value);
			}
		}

		/// <summary>
		/// Show in card.
		/// </summary>
		public bool ShowInCard {
			get {
				return GetTypedColumnValue<bool>("ShowInCard");
			}
			set {
				SetColumnValue("ShowInCard", value);
			}
		}

		/// <summary>
		/// Convert to PDF.
		/// </summary>
		public bool ConvertInPDF {
			get {
				return GetTypedColumnValue<bool>("ConvertInPDF");
			}
			set {
				SetColumnValue("ConvertInPDF", value);
			}
		}

		/// <summary>
		/// Type column value.
		/// </summary>
		public Guid TypeColumnValue {
			get {
				return GetTypedColumnValue<Guid>("TypeColumnValue");
			}
			set {
				SetColumnValue("TypeColumnValue", value);
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

