namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SpecificationListItem

	/// <exclude/>
	public class SpecificationListItem : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SpecificationListItem(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SpecificationListItem";
		}

		public SpecificationListItem(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SpecificationListItem";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<LevelPartnershipParam> LevelPartnershipParamCollectionByListItemValue {
			get;
			set;
		}

		public IEnumerable<PartnerParamHistory> PartnerParamHistoryCollectionByListItemValue {
			get;
			set;
		}

		public IEnumerable<PartnershipParameter> PartnershipParameterCollectionByListItemValue {
			get;
			set;
		}

		public IEnumerable<SpecificationInLead> SpecificationInLeadCollectionByListItemValue {
			get;
			set;
		}

		public IEnumerable<SpecificationInObject> SpecificationInObjectCollectionByListItemValue {
			get;
			set;
		}

		public IEnumerable<SpecificationInProduct> SpecificationInProductCollectionByListItemValue {
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

		/// <exclude/>
		public Guid SpecificationId {
			get {
				return GetTypedColumnValue<Guid>("SpecificationId");
			}
			set {
				SetColumnValue("SpecificationId", value);
				_specification = null;
			}
		}

		/// <exclude/>
		public string SpecificationName {
			get {
				return GetTypedColumnValue<string>("SpecificationName");
			}
			set {
				SetColumnValue("SpecificationName", value);
				if (_specification != null) {
					_specification.Name = value;
				}
			}
		}

		private Specification _specification;
		/// <summary>
		/// Характеристика.
		/// </summary>
		public Specification Specification {
			get {
				return _specification ??
					(_specification = new Specification(LookupColumnEntities.GetEntity("Specification")));
			}
		}

		#endregion

	}

	#endregion

}

