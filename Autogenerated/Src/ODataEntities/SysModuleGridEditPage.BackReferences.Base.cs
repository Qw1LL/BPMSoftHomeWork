namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysModuleGridEditPage

	/// <exclude/>
	public class SysModuleGridEditPage : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysModuleGridEditPage(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysModuleGridEditPage";
		}

		public SysModuleGridEditPage(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysModuleGridEditPage";
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
		/// Type value.
		/// </summary>
		public Guid TypeColumnValue {
			get {
				return GetTypedColumnValue<Guid>("TypeColumnValue");
			}
			set {
				SetColumnValue("TypeColumnValue", value);
			}
		}

		/// <exclude/>
		public Guid SysModuleGridPageId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleGridPageId");
			}
			set {
				SetColumnValue("SysModuleGridPageId", value);
				_sysModuleGridPage = null;
			}
		}

		/// <exclude/>
		public string SysModuleGridPageCaption {
			get {
				return GetTypedColumnValue<string>("SysModuleGridPageCaption");
			}
			set {
				SetColumnValue("SysModuleGridPageCaption", value);
				if (_sysModuleGridPage != null) {
					_sysModuleGridPage.Caption = value;
				}
			}
		}

		private SysSchema _sysModuleGridPage;
		/// <summary>
		/// Section list.
		/// </summary>
		public SysSchema SysModuleGridPage {
			get {
				return _sysModuleGridPage ??
					(_sysModuleGridPage = new SysSchema(LookupColumnEntities.GetEntity("SysModuleGridPage")));
			}
		}

		/// <exclude/>
		public Guid SysEditPageSchemaId {
			get {
				return GetTypedColumnValue<Guid>("SysEditPageSchemaId");
			}
			set {
				SetColumnValue("SysEditPageSchemaId", value);
				_sysEditPageSchema = null;
			}
		}

		/// <exclude/>
		public string SysEditPageSchemaCaption {
			get {
				return GetTypedColumnValue<string>("SysEditPageSchemaCaption");
			}
			set {
				SetColumnValue("SysEditPageSchemaCaption", value);
				if (_sysEditPageSchema != null) {
					_sysEditPageSchema.Caption = value;
				}
			}
		}

		private SysSchema _sysEditPageSchema;
		/// <summary>
		/// Card page.
		/// </summary>
		public SysSchema SysEditPageSchema {
			get {
				return _sysEditPageSchema ??
					(_sysEditPageSchema = new SysSchema(LookupColumnEntities.GetEntity("SysEditPageSchema")));
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
		/// Unique identifier of section list.
		/// </summary>
		public Guid SysModuleGridPageUId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleGridPageUId");
			}
			set {
				SetColumnValue("SysModuleGridPageUId", value);
			}
		}

		/// <summary>
		/// Unique identifier of card page.
		/// </summary>
		public Guid SysEditPageSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysEditPageSchemaUId");
			}
			set {
				SetColumnValue("SysEditPageSchemaUId", value);
			}
		}

		#endregion

	}

	#endregion

}

