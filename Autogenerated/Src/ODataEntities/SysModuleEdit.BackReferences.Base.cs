namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysModuleEdit

	/// <exclude/>
	public class SysModuleEdit : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysModuleEdit(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysModuleEdit";
		}

		public SysModuleEdit(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysModuleEdit";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<QuickAddMenuItem> QuickAddMenuItemCollectionBySysModuleEdit {
			get;
			set;
		}

		public IEnumerable<SysModuleEditDetail> SysModuleEditDetailCollectionBySysModuleEdit {
			get;
			set;
		}

		public IEnumerable<SysModuleEditLczOld> SysModuleEditLczOldCollectionByRecord {
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

		/// <exclude/>
		public Guid SysModuleEntityId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleEntityId");
			}
			set {
				SetColumnValue("SysModuleEntityId", value);
				_sysModuleEntity = null;
			}
		}

		private SysModuleEntity _sysModuleEntity;
		/// <summary>
		/// Section object.
		/// </summary>
		public SysModuleEntity SysModuleEntity {
			get {
				return _sysModuleEntity ??
					(_sysModuleEntity = new SysModuleEntity(LookupColumnEntities.GetEntity("SysModuleEntity")));
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
		/// Use details of section.
		/// </summary>
		public bool UseModuleDetails {
			get {
				return GetTypedColumnValue<bool>("UseModuleDetails");
			}
			set {
				SetColumnValue("UseModuleDetails", value);
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
		/// Identifier of card page.
		/// </summary>
		public Guid SysPageSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysPageSchemaUId");
			}
			set {
				SetColumnValue("SysPageSchemaUId", value);
			}
		}

		/// <summary>
		/// Unique identifier of edit page schema.
		/// </summary>
		public Guid CardSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("CardSchemaUId");
			}
			set {
				SetColumnValue("CardSchemaUId", value);
			}
		}

		/// <summary>
		/// User task caption.
		/// </summary>
		public string ActionKindCaption {
			get {
				return GetTypedColumnValue<string>("ActionKindCaption");
			}
			set {
				SetColumnValue("ActionKindCaption", value);
			}
		}

		/// <summary>
		/// User task name.
		/// </summary>
		public string ActionKindName {
			get {
				return GetTypedColumnValue<string>("ActionKindName");
			}
			set {
				SetColumnValue("ActionKindName", value);
			}
		}

		/// <summary>
		/// Edit page caption.
		/// </summary>
		public string PageCaption {
			get {
				return GetTypedColumnValue<string>("PageCaption");
			}
			set {
				SetColumnValue("PageCaption", value);
			}
		}

		/// <summary>
		/// Unique identifier of mini page schema.
		/// </summary>
		public Guid MiniPageSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("MiniPageSchemaUId");
			}
			set {
				SetColumnValue("MiniPageSchemaUId", value);
			}
		}

		/// <summary>
		/// Unique identifier of schema for search row view .
		/// </summary>
		public Guid SearchRowSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SearchRowSchemaUId");
			}
			set {
				SetColumnValue("SearchRowSchemaUId", value);
			}
		}

		/// <summary>
		/// Mini page modes.
		/// </summary>
		public string MiniPageModes {
			get {
				return GetTypedColumnValue<string>("MiniPageModes");
			}
			set {
				SetColumnValue("MiniPageModes", value);
			}
		}

		#endregion

	}

	#endregion

}

