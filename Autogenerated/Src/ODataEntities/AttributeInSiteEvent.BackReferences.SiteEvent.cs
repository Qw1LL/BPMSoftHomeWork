namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: AttributeInSiteEvent

	/// <exclude/>
	public class AttributeInSiteEvent : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public AttributeInSiteEvent(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AttributeInSiteEvent";
		}

		public AttributeInSiteEvent(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "AttributeInSiteEvent";
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
		public Guid SiteEventAttributeId {
			get {
				return GetTypedColumnValue<Guid>("SiteEventAttributeId");
			}
			set {
				SetColumnValue("SiteEventAttributeId", value);
				_siteEventAttribute = null;
			}
		}

		/// <exclude/>
		public string SiteEventAttributeName {
			get {
				return GetTypedColumnValue<string>("SiteEventAttributeName");
			}
			set {
				SetColumnValue("SiteEventAttributeName", value);
				if (_siteEventAttribute != null) {
					_siteEventAttribute.Name = value;
				}
			}
		}

		private SiteEventAttribute _siteEventAttribute;
		/// <summary>
		/// Атрибут.
		/// </summary>
		public SiteEventAttribute SiteEventAttribute {
			get {
				return _siteEventAttribute ??
					(_siteEventAttribute = new SiteEventAttribute(LookupColumnEntities.GetEntity("SiteEventAttribute")));
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

		private SiteEventAttrListItem _listItemValue;
		/// <summary>
		/// Значение(Список).
		/// </summary>
		public SiteEventAttrListItem ListItemValue {
			get {
				return _listItemValue ??
					(_listItemValue = new SiteEventAttrListItem(LookupColumnEntities.GetEntity("ListItemValue")));
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
		/// Значение(Числовое).
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
		/// Значение(Дробное).
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
		/// Значение(Логическое).
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
		public Guid ProductValueId {
			get {
				return GetTypedColumnValue<Guid>("ProductValueId");
			}
			set {
				SetColumnValue("ProductValueId", value);
				_productValue = null;
			}
		}

		/// <exclude/>
		public string ProductValueName {
			get {
				return GetTypedColumnValue<string>("ProductValueName");
			}
			set {
				SetColumnValue("ProductValueName", value);
				if (_productValue != null) {
					_productValue.Name = value;
				}
			}
		}

		private Product _productValue;
		/// <summary>
		/// Значение(Связь с продуктом).
		/// </summary>
		public Product ProductValue {
			get {
				return _productValue ??
					(_productValue = new Product(LookupColumnEntities.GetEntity("ProductValue")));
			}
		}

		/// <exclude/>
		public Guid SiteEventId {
			get {
				return GetTypedColumnValue<Guid>("SiteEventId");
			}
			set {
				SetColumnValue("SiteEventId", value);
				_siteEvent = null;
			}
		}

		/// <exclude/>
		public string SiteEventSource {
			get {
				return GetTypedColumnValue<string>("SiteEventSource");
			}
			set {
				SetColumnValue("SiteEventSource", value);
				if (_siteEvent != null) {
					_siteEvent.Source = value;
				}
			}
		}

		private SiteEvent _siteEvent;
		/// <summary>
		/// Событие сайта.
		/// </summary>
		public SiteEvent SiteEvent {
			get {
				return _siteEvent ??
					(_siteEvent = new SiteEvent(LookupColumnEntities.GetEntity("SiteEvent")));
			}
		}

		/// <exclude/>
		public Guid ProductTypeValueId {
			get {
				return GetTypedColumnValue<Guid>("ProductTypeValueId");
			}
			set {
				SetColumnValue("ProductTypeValueId", value);
				_productTypeValue = null;
			}
		}

		/// <exclude/>
		public string ProductTypeValueName {
			get {
				return GetTypedColumnValue<string>("ProductTypeValueName");
			}
			set {
				SetColumnValue("ProductTypeValueName", value);
				if (_productTypeValue != null) {
					_productTypeValue.Name = value;
				}
			}
		}

		private ProductType _productTypeValue;
		/// <summary>
		/// Тип продукта.
		/// </summary>
		public ProductType ProductTypeValue {
			get {
				return _productTypeValue ??
					(_productTypeValue = new ProductType(LookupColumnEntities.GetEntity("ProductTypeValue")));
			}
		}

		/// <exclude/>
		public Guid ProductCategoryValueId {
			get {
				return GetTypedColumnValue<Guid>("ProductCategoryValueId");
			}
			set {
				SetColumnValue("ProductCategoryValueId", value);
				_productCategoryValue = null;
			}
		}

		/// <exclude/>
		public string ProductCategoryValueName {
			get {
				return GetTypedColumnValue<string>("ProductCategoryValueName");
			}
			set {
				SetColumnValue("ProductCategoryValueName", value);
				if (_productCategoryValue != null) {
					_productCategoryValue.Name = value;
				}
			}
		}

		private ProductCategory _productCategoryValue;
		/// <summary>
		/// Категория продукта.
		/// </summary>
		public ProductCategory ProductCategoryValue {
			get {
				return _productCategoryValue ??
					(_productCategoryValue = new ProductCategory(LookupColumnEntities.GetEntity("ProductCategoryValue")));
			}
		}

		/// <exclude/>
		public Guid ProductTradeMarkValueId {
			get {
				return GetTypedColumnValue<Guid>("ProductTradeMarkValueId");
			}
			set {
				SetColumnValue("ProductTradeMarkValueId", value);
				_productTradeMarkValue = null;
			}
		}

		/// <exclude/>
		public string ProductTradeMarkValueName {
			get {
				return GetTypedColumnValue<string>("ProductTradeMarkValueName");
			}
			set {
				SetColumnValue("ProductTradeMarkValueName", value);
				if (_productTradeMarkValue != null) {
					_productTradeMarkValue.Name = value;
				}
			}
		}

		private TradeMark _productTradeMarkValue;
		/// <summary>
		/// Торговая марка.
		/// </summary>
		public TradeMark ProductTradeMarkValue {
			get {
				return _productTradeMarkValue ??
					(_productTradeMarkValue = new TradeMark(LookupColumnEntities.GetEntity("ProductTradeMarkValue")));
			}
		}

		#endregion

	}

	#endregion

}

