namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: ServiceRelationship

	/// <exclude/>
	public class ServiceRelationship : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public ServiceRelationship(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ServiceRelationship";
		}

		public ServiceRelationship(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "ServiceRelationship";
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

		/// <exclude/>
		public Guid ServiceItemAId {
			get {
				return GetTypedColumnValue<Guid>("ServiceItemAId");
			}
			set {
				SetColumnValue("ServiceItemAId", value);
				_serviceItemA = null;
			}
		}

		/// <exclude/>
		public string ServiceItemAName {
			get {
				return GetTypedColumnValue<string>("ServiceItemAName");
			}
			set {
				SetColumnValue("ServiceItemAName", value);
				if (_serviceItemA != null) {
					_serviceItemA.Name = value;
				}
			}
		}

		private ServiceItem _serviceItemA;
		/// <summary>
		/// Сервис А.
		/// </summary>
		public ServiceItem ServiceItemA {
			get {
				return _serviceItemA ??
					(_serviceItemA = new ServiceItem(LookupColumnEntities.GetEntity("ServiceItemA")));
			}
		}

		/// <exclude/>
		public Guid ServiceItemBId {
			get {
				return GetTypedColumnValue<Guid>("ServiceItemBId");
			}
			set {
				SetColumnValue("ServiceItemBId", value);
				_serviceItemB = null;
			}
		}

		/// <exclude/>
		public string ServiceItemBName {
			get {
				return GetTypedColumnValue<string>("ServiceItemBName");
			}
			set {
				SetColumnValue("ServiceItemBName", value);
				if (_serviceItemB != null) {
					_serviceItemB.Name = value;
				}
			}
		}

		private ServiceItem _serviceItemB;
		/// <summary>
		/// Сервис Б.
		/// </summary>
		public ServiceItem ServiceItemB {
			get {
				return _serviceItemB ??
					(_serviceItemB = new ServiceItem(LookupColumnEntities.GetEntity("ServiceItemB")));
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

		/// <exclude/>
		public Guid DependencyTypeId {
			get {
				return GetTypedColumnValue<Guid>("DependencyTypeId");
			}
			set {
				SetColumnValue("DependencyTypeId", value);
				_dependencyType = null;
			}
		}

		/// <exclude/>
		public string DependencyTypeName {
			get {
				return GetTypedColumnValue<string>("DependencyTypeName");
			}
			set {
				SetColumnValue("DependencyTypeName", value);
				if (_dependencyType != null) {
					_dependencyType.Name = value;
				}
			}
		}

		private DependencyType _dependencyType;
		/// <summary>
		/// Тип.
		/// </summary>
		public DependencyType DependencyType {
			get {
				return _dependencyType ??
					(_dependencyType = new DependencyType(LookupColumnEntities.GetEntity("DependencyType")));
			}
		}

		#endregion

	}

	#endregion

}

