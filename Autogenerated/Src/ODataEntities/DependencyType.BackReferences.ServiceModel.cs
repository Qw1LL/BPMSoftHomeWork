namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: DependencyType

	/// <exclude/>
	public class DependencyType : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public DependencyType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DependencyType";
		}

		public DependencyType(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "DependencyType";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<ConfItemRelationship> ConfItemRelationshipCollectionByDependencyType {
			get;
			set;
		}

		public IEnumerable<ServiceInConfItem> ServiceInConfItemCollectionByDependencyType {
			get;
			set;
		}

		public IEnumerable<ServiceRelationship> ServiceRelationshipCollectionByDependencyType {
			get;
			set;
		}

		public IEnumerable<VwConfItemRelationship> VwConfItemRelationshipCollectionByDependencyType {
			get;
			set;
		}

		public IEnumerable<VwServiceInConfItem> VwServiceInConfItemCollectionByDependencyType {
			get;
			set;
		}

		public IEnumerable<VwServiceRelationship> VwServiceRelationshipCollectionByDependencyType {
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
		/// Сервис-Сервис.
		/// </summary>
		public bool ForServiceService {
			get {
				return GetTypedColumnValue<bool>("ForServiceService");
			}
			set {
				SetColumnValue("ForServiceService", value);
			}
		}

		/// <summary>
		/// Конфигурация-Конфигурация.
		/// </summary>
		public bool ForConfItemConfItem {
			get {
				return GetTypedColumnValue<bool>("ForConfItemConfItem");
			}
			set {
				SetColumnValue("ForConfItemConfItem", value);
			}
		}

		/// <summary>
		/// Сервис-Конфигурация.
		/// </summary>
		public bool ForServiceConfItem {
			get {
				return GetTypedColumnValue<bool>("ForServiceConfItem");
			}
			set {
				SetColumnValue("ForServiceConfItem", value);
			}
		}

		/// <summary>
		/// Название обратного типа зависимости.
		/// </summary>
		public string ReverseTypeName {
			get {
				return GetTypedColumnValue<string>("ReverseTypeName");
			}
			set {
				SetColumnValue("ReverseTypeName", value);
			}
		}

		/// <exclude/>
		public Guid DependencyCategoryId {
			get {
				return GetTypedColumnValue<Guid>("DependencyCategoryId");
			}
			set {
				SetColumnValue("DependencyCategoryId", value);
				_dependencyCategory = null;
			}
		}

		/// <exclude/>
		public string DependencyCategoryName {
			get {
				return GetTypedColumnValue<string>("DependencyCategoryName");
			}
			set {
				SetColumnValue("DependencyCategoryName", value);
				if (_dependencyCategory != null) {
					_dependencyCategory.Name = value;
				}
			}
		}

		private DependencyCategory _dependencyCategory;
		/// <summary>
		/// Категория.
		/// </summary>
		public DependencyCategory DependencyCategory {
			get {
				return _dependencyCategory ??
					(_dependencyCategory = new DependencyCategory(LookupColumnEntities.GetEntity("DependencyCategory")));
			}
		}

		#endregion

	}

	#endregion

}

