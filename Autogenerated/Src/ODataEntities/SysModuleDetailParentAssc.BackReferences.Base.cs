namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysModuleDetailParentAssc

	/// <exclude/>
	public class SysModuleDetailParentAssc : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysModuleDetailParentAssc(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysModuleDetailParentAssc";
		}

		public SysModuleDetailParentAssc(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysModuleDetailParentAssc";
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
		public Guid SysModuleDetailId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleDetailId");
			}
			set {
				SetColumnValue("SysModuleDetailId", value);
				_sysModuleDetail = null;
			}
		}

		/// <exclude/>
		public string SysModuleDetailCaption {
			get {
				return GetTypedColumnValue<string>("SysModuleDetailCaption");
			}
			set {
				SetColumnValue("SysModuleDetailCaption", value);
				if (_sysModuleDetail != null) {
					_sysModuleDetail.Caption = value;
				}
			}
		}

		private SysModuleDetail _sysModuleDetail;
		/// <summary>
		/// Detail.
		/// </summary>
		public SysModuleDetail SysModuleDetail {
			get {
				return _sysModuleDetail ??
					(_sysModuleDetail = new SysModuleDetail(LookupColumnEntities.GetEntity("SysModuleDetail")));
			}
		}

		/// <summary>
		/// Column path.
		/// </summary>
		public string ColumnMetaPath {
			get {
				return GetTypedColumnValue<string>("ColumnMetaPath");
			}
			set {
				SetColumnValue("ColumnMetaPath", value);
			}
		}

		/// <summary>
		/// Path to parent column.
		/// </summary>
		public string ParentColumnMetaPath {
			get {
				return GetTypedColumnValue<string>("ParentColumnMetaPath");
			}
			set {
				SetColumnValue("ParentColumnMetaPath", value);
			}
		}

		/// <exclude/>
		public Guid SysParentAssociationTypeId {
			get {
				return GetTypedColumnValue<Guid>("SysParentAssociationTypeId");
			}
			set {
				SetColumnValue("SysParentAssociationTypeId", value);
				_sysParentAssociationType = null;
			}
		}

		/// <exclude/>
		public string SysParentAssociationTypeName {
			get {
				return GetTypedColumnValue<string>("SysParentAssociationTypeName");
			}
			set {
				SetColumnValue("SysParentAssociationTypeName", value);
				if (_sysParentAssociationType != null) {
					_sysParentAssociationType.Name = value;
				}
			}
		}

		private SysParentAssociationType _sysParentAssociationType;
		/// <summary>
		/// Parent connection type.
		/// </summary>
		public SysParentAssociationType SysParentAssociationType {
			get {
				return _sysParentAssociationType ??
					(_sysParentAssociationType = new SysParentAssociationType(LookupColumnEntities.GetEntity("SysParentAssociationType")));
			}
		}

		/// <summary>
		/// Detail column.
		/// </summary>
		public string ColumnCaption {
			get {
				return GetTypedColumnValue<string>("ColumnCaption");
			}
			set {
				SetColumnValue("ColumnCaption", value);
			}
		}

		/// <summary>
		/// Parent object column.
		/// </summary>
		public string ParentColumnCaption {
			get {
				return GetTypedColumnValue<string>("ParentColumnCaption");
			}
			set {
				SetColumnValue("ParentColumnCaption", value);
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

