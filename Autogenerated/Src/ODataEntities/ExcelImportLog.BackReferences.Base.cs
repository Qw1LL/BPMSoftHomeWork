namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: ExcelImportLog

	/// <exclude/>
	public class ExcelImportLog : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public ExcelImportLog(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ExcelImportLog";
		}

		public ExcelImportLog(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "ExcelImportLog";
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
		/// Message text.
		/// </summary>
		public string MessageText {
			get {
				return GetTypedColumnValue<string>("MessageText");
			}
			set {
				SetColumnValue("MessageText", value);
			}
		}

		/// <exclude/>
		public Guid ExcelImportId {
			get {
				return GetTypedColumnValue<Guid>("ExcelImportId");
			}
			set {
				SetColumnValue("ExcelImportId", value);
				_excelImport = null;
			}
		}

		private ExcelImport _excelImport;
		/// <summary>
		/// Excel import.
		/// </summary>
		public ExcelImport ExcelImport {
			get {
				return _excelImport ??
					(_excelImport = new ExcelImport(LookupColumnEntities.GetEntity("ExcelImport")));
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
		/// Stack trace.
		/// </summary>
		public string StackTrace {
			get {
				return GetTypedColumnValue<string>("StackTrace");
			}
			set {
				SetColumnValue("StackTrace", value);
			}
		}

		#endregion

	}

	#endregion

}

