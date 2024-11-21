namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: PartnershipParameter

	/// <exclude/>
	public class PartnershipParameter : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public PartnershipParameter(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "PartnershipParameter";
		}

		public PartnershipParameter(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "PartnershipParameter";
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

		/// <summary>
		/// Значение.
		/// </summary>
		public string StringValue {
			get {
				return GetTypedColumnValue<string>("StringValue");
			}
			set {
				SetColumnValue("StringValue", value);
			}
		}

		/// <summary>
		/// Значение (целочисленное).
		/// </summary>
		public int IntValue {
			get {
				return GetTypedColumnValue<int>("IntValue");
			}
			set {
				SetColumnValue("IntValue", value);
			}
		}

		/// <summary>
		/// Значение (дробное).
		/// </summary>
		public Decimal FloatValue {
			get {
				return GetTypedColumnValue<Decimal>("FloatValue");
			}
			set {
				SetColumnValue("FloatValue", value);
			}
		}

		/// <summary>
		/// Значение (логическое).
		/// </summary>
		public bool BooleanValue {
			get {
				return GetTypedColumnValue<bool>("BooleanValue");
			}
			set {
				SetColumnValue("BooleanValue", value);
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

		/// <exclude/>
		public Guid ListItemValueId {
			get {
				return GetTypedColumnValue<Guid>("ListItemValueId");
			}
			set {
				SetColumnValue("ListItemValueId", value);
				_listItemValue = null;
			}
		}

		/// <exclude/>
		public string ListItemValueName {
			get {
				return GetTypedColumnValue<string>("ListItemValueName");
			}
			set {
				SetColumnValue("ListItemValueName", value);
				if (_listItemValue != null) {
					_listItemValue.Name = value;
				}
			}
		}

		private SpecificationListItem _listItemValue;
		/// <summary>
		/// Значение (выбор из списка).
		/// </summary>
		public SpecificationListItem ListItemValue {
			get {
				return _listItemValue ??
					(_listItemValue = new SpecificationListItem(LookupColumnEntities.GetEntity("ListItemValue")));
			}
		}

		/// <exclude/>
		public Guid PartnerParamCategoryId {
			get {
				return GetTypedColumnValue<Guid>("PartnerParamCategoryId");
			}
			set {
				SetColumnValue("PartnerParamCategoryId", value);
				_partnerParamCategory = null;
			}
		}

		/// <exclude/>
		public string PartnerParamCategoryName {
			get {
				return GetTypedColumnValue<string>("PartnerParamCategoryName");
			}
			set {
				SetColumnValue("PartnerParamCategoryName", value);
				if (_partnerParamCategory != null) {
					_partnerParamCategory.Name = value;
				}
			}
		}

		private PartnerParamCategory _partnerParamCategory;
		/// <summary>
		/// Параметр.
		/// </summary>
		public PartnerParamCategory PartnerParamCategory {
			get {
				return _partnerParamCategory ??
					(_partnerParamCategory = new PartnerParamCategory(LookupColumnEntities.GetEntity("PartnerParamCategory")));
			}
		}

		/// <summary>
		/// Балл.
		/// </summary>
		public int Score {
			get {
				return GetTypedColumnValue<int>("Score");
			}
			set {
				SetColumnValue("Score", value);
			}
		}

		/// <exclude/>
		public Guid PartnershipId {
			get {
				return GetTypedColumnValue<Guid>("PartnershipId");
			}
			set {
				SetColumnValue("PartnershipId", value);
				_partnership = null;
			}
		}

		/// <exclude/>
		public string PartnershipName {
			get {
				return GetTypedColumnValue<string>("PartnershipName");
			}
			set {
				SetColumnValue("PartnershipName", value);
				if (_partnership != null) {
					_partnership.Name = value;
				}
			}
		}

		private Partnership _partnership;
		/// <summary>
		/// Партнерство.
		/// </summary>
		public Partnership Partnership {
			get {
				return _partnership ??
					(_partnership = new Partnership(LookupColumnEntities.GetEntity("Partnership")));
			}
		}

		/// <exclude/>
		public Guid PartnershipParameterTypeId {
			get {
				return GetTypedColumnValue<Guid>("PartnershipParameterTypeId");
			}
			set {
				SetColumnValue("PartnershipParameterTypeId", value);
				_partnershipParameterType = null;
			}
		}

		/// <exclude/>
		public string PartnershipParameterTypeName {
			get {
				return GetTypedColumnValue<string>("PartnershipParameterTypeName");
			}
			set {
				SetColumnValue("PartnershipParameterTypeName", value);
				if (_partnershipParameterType != null) {
					_partnershipParameterType.Name = value;
				}
			}
		}

		private PartnershipParamType _partnershipParameterType;
		/// <summary>
		/// Тип.
		/// </summary>
		public PartnershipParamType PartnershipParameterType {
			get {
				return _partnershipParameterType ??
					(_partnershipParameterType = new PartnershipParamType(LookupColumnEntities.GetEntity("PartnershipParameterType")));
			}
		}

		/// <exclude/>
		public Guid ParameterTypeId {
			get {
				return GetTypedColumnValue<Guid>("ParameterTypeId");
			}
			set {
				SetColumnValue("ParameterTypeId", value);
				_parameterType = null;
			}
		}

		/// <exclude/>
		public string ParameterTypeName {
			get {
				return GetTypedColumnValue<string>("ParameterTypeName");
			}
			set {
				SetColumnValue("ParameterTypeName", value);
				if (_parameterType != null) {
					_parameterType.Name = value;
				}
			}
		}

		private ParameterType _parameterType;
		/// <summary>
		/// Вид.
		/// </summary>
		public ParameterType ParameterType {
			get {
				return _parameterType ??
					(_parameterType = new ParameterType(LookupColumnEntities.GetEntity("ParameterType")));
			}
		}

		/// <exclude/>
		public Guid PartnerLevelId {
			get {
				return GetTypedColumnValue<Guid>("PartnerLevelId");
			}
			set {
				SetColumnValue("PartnerLevelId", value);
				_partnerLevel = null;
			}
		}

		/// <exclude/>
		public string PartnerLevelName {
			get {
				return GetTypedColumnValue<string>("PartnerLevelName");
			}
			set {
				SetColumnValue("PartnerLevelName", value);
				if (_partnerLevel != null) {
					_partnerLevel.Name = value;
				}
			}
		}

		private PartnerLevel _partnerLevel;
		/// <summary>
		/// Уровень партнера.
		/// </summary>
		public PartnerLevel PartnerLevel {
			get {
				return _partnerLevel ??
					(_partnerLevel = new PartnerLevel(LookupColumnEntities.GetEntity("PartnerLevel")));
			}
		}

		/// <exclude/>
		public Guid ParameterValueTypeId {
			get {
				return GetTypedColumnValue<Guid>("ParameterValueTypeId");
			}
			set {
				SetColumnValue("ParameterValueTypeId", value);
				_parameterValueType = null;
			}
		}

		/// <exclude/>
		public string ParameterValueTypeName {
			get {
				return GetTypedColumnValue<string>("ParameterValueTypeName");
			}
			set {
				SetColumnValue("ParameterValueTypeName", value);
				if (_parameterValueType != null) {
					_parameterValueType.Name = value;
				}
			}
		}

		private SpecificationType _parameterValueType;
		/// <summary>
		/// Тип значения параметра.
		/// </summary>
		public SpecificationType ParameterValueType {
			get {
				return _parameterValueType ??
					(_parameterValueType = new SpecificationType(LookupColumnEntities.GetEntity("ParameterValueType")));
			}
		}

		/// <summary>
		/// Текущее значение.
		/// </summary>
		public string CurrentValue {
			get {
				return GetTypedColumnValue<string>("CurrentValue");
			}
			set {
				SetColumnValue("CurrentValue", value);
			}
		}

		/// <summary>
		/// Значение (GUID).
		/// </summary>
		public Guid GuidValue {
			get {
				return GetTypedColumnValue<Guid>("GuidValue");
			}
			set {
				SetColumnValue("GuidValue", value);
			}
		}

		#endregion

	}

	#endregion

}

