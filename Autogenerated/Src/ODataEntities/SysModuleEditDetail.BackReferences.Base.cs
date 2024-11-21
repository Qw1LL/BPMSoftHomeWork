namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysModuleEditDetail

	/// <exclude/>
	public class SysModuleEditDetail : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysModuleEditDetail(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysModuleEditDetail";
		}

		public SysModuleEditDetail(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysModuleEditDetail";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<SysModuleEditDetailParentAssc> SysModuleEditDetailParentAsscCollectionBySysModuleEditDetail {
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
		public Guid SysModuleEditId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleEditId");
			}
			set {
				SetColumnValue("SysModuleEditId", value);
				_sysModuleEdit = null;
			}
		}

		/// <exclude/>
		public string SysModuleEditPageCaption {
			get {
				return GetTypedColumnValue<string>("SysModuleEditPageCaption");
			}
			set {
				SetColumnValue("SysModuleEditPageCaption", value);
				if (_sysModuleEdit != null) {
					_sysModuleEdit.PageCaption = value;
				}
			}
		}

		private SysModuleEdit _sysModuleEdit;
		/// <summary>
		/// Section card.
		/// </summary>
		public SysModuleEdit SysModuleEdit {
			get {
				return _sysModuleEdit ??
					(_sysModuleEdit = new SysModuleEdit(LookupColumnEntities.GetEntity("SysModuleEdit")));
			}
		}

		/// <exclude/>
		public Guid SysModuleGridId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleGridId");
			}
			set {
				SetColumnValue("SysModuleGridId", value);
				_sysModuleGrid = null;
			}
		}

		private SysModuleGrid _sysModuleGrid;
		/// <summary>
		/// Section list.
		/// </summary>
		public SysModuleGrid SysModuleGrid {
			get {
				return _sysModuleGrid ??
					(_sysModuleGrid = new SysModuleGrid(LookupColumnEntities.GetEntity("SysModuleGrid")));
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

		#endregion

	}

	#endregion

}

