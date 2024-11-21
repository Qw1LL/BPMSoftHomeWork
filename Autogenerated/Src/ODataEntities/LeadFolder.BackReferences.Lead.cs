namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: LeadFolder

	/// <exclude/>
	public class LeadFolder : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public LeadFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LeadFolder";
		}

		public LeadFolder(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "LeadFolder";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<LeadFolder> LeadFolderCollectionByParent {
			get;
			set;
		}

		public IEnumerable<LeadInFolder> LeadInFolderCollectionByFolder {
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
		/// Дата создания.
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
		/// Создал.
		/// </summary>
		public Contact CreatedBy {
			get {
				return _createdBy ??
					(_createdBy = new Contact(LookupColumnEntities.GetEntity("CreatedBy")));
			}
		}

		/// <summary>
		/// Дата изменения.
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
		/// Изменил.
		/// </summary>
		public Contact ModifiedBy {
			get {
				return _modifiedBy ??
					(_modifiedBy = new Contact(LookupColumnEntities.GetEntity("ModifiedBy")));
			}
		}

		/// <summary>
		/// Название.
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
		/// Описание.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		/// <exclude/>
		public Guid ParentId {
			get {
				return GetTypedColumnValue<Guid>("ParentId");
			}
			set {
				SetColumnValue("ParentId", value);
				_parent = null;
			}
		}

		/// <exclude/>
		public string ParentName {
			get {
				return GetTypedColumnValue<string>("ParentName");
			}
			set {
				SetColumnValue("ParentName", value);
				if (_parent != null) {
					_parent.Name = value;
				}
			}
		}

		private LeadFolder _parent;
		/// <summary>
		/// Родитель.
		/// </summary>
		public LeadFolder Parent {
			get {
				return _parent ??
					(_parent = new LeadFolder(LookupColumnEntities.GetEntity("Parent")));
			}
		}

		/// <exclude/>
		public Guid FolderTypeId {
			get {
				return GetTypedColumnValue<Guid>("FolderTypeId");
			}
			set {
				SetColumnValue("FolderTypeId", value);
				_folderType = null;
			}
		}

		/// <exclude/>
		public string FolderTypeName {
			get {
				return GetTypedColumnValue<string>("FolderTypeName");
			}
			set {
				SetColumnValue("FolderTypeName", value);
				if (_folderType != null) {
					_folderType.Name = value;
				}
			}
		}

		private FolderType _folderType;
		/// <summary>
		/// Тип группы.
		/// </summary>
		public FolderType FolderType {
			get {
				return _folderType ??
					(_folderType = new FolderType(LookupColumnEntities.GetEntity("FolderType")));
			}
		}

		/// <summary>
		/// Активные процессы.
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
		/// Тип оптимизации.
		/// </summary>
		public int OptimizationType {
			get {
				return GetTypedColumnValue<int>("OptimizationType");
			}
			set {
				SetColumnValue("OptimizationType", value);
			}
		}

		#endregion

	}

	#endregion

}

