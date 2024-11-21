namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: Product

	/// <exclude/>
	public class Product : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public Product(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Product";
		}

		public Product(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "Product";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<AttributeInSiteEvent> AttributeInSiteEventCollectionByProductValue {
			get;
			set;
		}

		public IEnumerable<ContactsProductInterest> ContactsProductInterestCollectionByProduct {
			get;
			set;
		}

		public IEnumerable<DocumentProduct> DocumentProductCollectionByProduct {
			get;
			set;
		}

		public IEnumerable<EventProduct> EventProductCollectionByProduct {
			get;
			set;
		}

		public IEnumerable<InvoiceProduct> InvoiceProductCollectionByProduct {
			get;
			set;
		}

		public IEnumerable<LeadProduct> LeadProductCollectionByProduct {
			get;
			set;
		}

		public IEnumerable<OpportunityProductInterest> OpportunityProductInterestCollectionByProduct {
			get;
			set;
		}

		public IEnumerable<OrderProduct> OrderProductCollectionByProduct {
			get;
			set;
		}

		public IEnumerable<ProductEntry> ProductEntryCollectionByCrossSalesOferring {
			get;
			set;
		}

		public IEnumerable<ProductEntry> ProductEntryCollectionByProduct {
			get;
			set;
		}

		public IEnumerable<ProductFile> ProductFileCollectionByProduct {
			get;
			set;
		}

		public IEnumerable<ProductForecast> ProductForecastCollectionByProduct {
			get;
			set;
		}

		public IEnumerable<ProductInFolder> ProductInFolderCollectionByProduct {
			get;
			set;
		}

		public IEnumerable<ProductInLeadType> ProductInLeadTypeCollectionByProduct {
			get;
			set;
		}

		public IEnumerable<ProductInTag> ProductInTagCollectionByEntity {
			get;
			set;
		}

		public IEnumerable<ProductPrice> ProductPriceCollectionByProduct {
			get;
			set;
		}

		public IEnumerable<ProductStockBalance> ProductStockBalanceCollectionByProduct {
			get;
			set;
		}

		public IEnumerable<ProductUnit> ProductUnitCollectionByProduct {
			get;
			set;
		}

		public IEnumerable<ProjectProduct> ProjectProductCollectionByProduct {
			get;
			set;
		}

		public IEnumerable<RecommendedProduct> RecommendedProductCollectionByProduct {
			get;
			set;
		}

		public IEnumerable<SpecificationInProduct> SpecificationInProductCollectionByProduct {
			get;
			set;
		}

		public IEnumerable<VwDocumentProduct> VwDocumentProductCollectionByProduct {
			get;
			set;
		}

		public IEnumerable<VwInvoiceProduct> VwInvoiceProductCollectionByProduct {
			get;
			set;
		}

		public IEnumerable<VwProductInLeadType> VwProductInLeadTypeCollectionByProduct {
			get;
			set;
		}

		public IEnumerable<VwProjectProduct> VwProjectProductCollectionByProduct {
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
		/// Код.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		/// <exclude/>
		public Guid UnitId {
			get {
				return GetTypedColumnValue<Guid>("UnitId");
			}
			set {
				SetColumnValue("UnitId", value);
				_unit = null;
			}
		}

		/// <exclude/>
		public string UnitName {
			get {
				return GetTypedColumnValue<string>("UnitName");
			}
			set {
				SetColumnValue("UnitName", value);
				if (_unit != null) {
					_unit.Name = value;
				}
			}
		}

		private Unit _unit;
		/// <summary>
		/// Единица измерения.
		/// </summary>
		public Unit Unit {
			get {
				return _unit ??
					(_unit = new Unit(LookupColumnEntities.GetEntity("Unit")));
			}
		}

		/// <exclude/>
		public Guid CurrencyId {
			get {
				return GetTypedColumnValue<Guid>("CurrencyId");
			}
			set {
				SetColumnValue("CurrencyId", value);
				_currency = null;
			}
		}

		/// <exclude/>
		public string CurrencyName {
			get {
				return GetTypedColumnValue<string>("CurrencyName");
			}
			set {
				SetColumnValue("CurrencyName", value);
				if (_currency != null) {
					_currency.Name = value;
				}
			}
		}

		private Currency _currency;
		/// <summary>
		/// Валюта.
		/// </summary>
		public Currency Currency {
			get {
				return _currency ??
					(_currency = new Currency(LookupColumnEntities.GetEntity("Currency")));
			}
		}

		/// <summary>
		/// Цена.
		/// </summary>
		public Decimal Price {
			get {
				return GetTypedColumnValue<Decimal>("Price");
			}
			set {
				SetColumnValue("Price", value);
			}
		}

		/// <exclude/>
		public Guid TaxId {
			get {
				return GetTypedColumnValue<Guid>("TaxId");
			}
			set {
				SetColumnValue("TaxId", value);
				_tax = null;
			}
		}

		/// <exclude/>
		public string TaxName {
			get {
				return GetTypedColumnValue<string>("TaxName");
			}
			set {
				SetColumnValue("TaxName", value);
				if (_tax != null) {
					_tax.Name = value;
				}
			}
		}

		private Tax _tax;
		/// <summary>
		/// Налог.
		/// </summary>
		public Tax Tax {
			get {
				return _tax ??
					(_tax = new Tax(LookupColumnEntities.GetEntity("Tax")));
			}
		}

		/// <summary>
		/// Ссылка.
		/// </summary>
		public string URL {
			get {
				return GetTypedColumnValue<string>("URL");
			}
			set {
				SetColumnValue("URL", value);
			}
		}

		/// <exclude/>
		public Guid TypeId {
			get {
				return GetTypedColumnValue<Guid>("TypeId");
			}
			set {
				SetColumnValue("TypeId", value);
				_type = null;
			}
		}

		/// <exclude/>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
				if (_type != null) {
					_type.Name = value;
				}
			}
		}

		private ProductType _type;
		/// <summary>
		/// Тип.
		/// </summary>
		public ProductType Type {
			get {
				return _type ??
					(_type = new ProductType(LookupColumnEntities.GetEntity("Type")));
			}
		}

		/// <summary>
		/// Используется.
		/// </summary>
		public bool Active {
			get {
				return GetTypedColumnValue<bool>("Active");
			}
			set {
				SetColumnValue("Active", value);
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
		public Guid OwnerId {
			get {
				return GetTypedColumnValue<Guid>("OwnerId");
			}
			set {
				SetColumnValue("OwnerId", value);
				_owner = null;
			}
		}

		/// <exclude/>
		public string OwnerName {
			get {
				return GetTypedColumnValue<string>("OwnerName");
			}
			set {
				SetColumnValue("OwnerName", value);
				if (_owner != null) {
					_owner.Name = value;
				}
			}
		}

		private Contact _owner;
		/// <summary>
		/// Ответственный.
		/// </summary>
		public Contact Owner {
			get {
				return _owner ??
					(_owner = new Contact(LookupColumnEntities.GetEntity("Owner")));
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
		public Guid ProductSourceId {
			get {
				return GetTypedColumnValue<Guid>("ProductSourceId");
			}
			set {
				SetColumnValue("ProductSourceId", value);
				_productSource = null;
			}
		}

		/// <exclude/>
		public string ProductSourceName {
			get {
				return GetTypedColumnValue<string>("ProductSourceName");
			}
			set {
				SetColumnValue("ProductSourceName", value);
				if (_productSource != null) {
					_productSource.Name = value;
				}
			}
		}

		private ProductSource _productSource;
		/// <summary>
		/// Источник продукта.
		/// </summary>
		public ProductSource ProductSource {
			get {
				return _productSource ??
					(_productSource = new ProductSource(LookupColumnEntities.GetEntity("ProductSource")));
			}
		}

		/// <summary>
		/// Заметки.
		/// </summary>
		public string Notes {
			get {
				return GetTypedColumnValue<string>("Notes");
			}
			set {
				SetColumnValue("Notes", value);
			}
		}

		/// <exclude/>
		public Guid PictureId {
			get {
				return GetTypedColumnValue<Guid>("PictureId");
			}
			set {
				SetColumnValue("PictureId", value);
				_picture = null;
			}
		}

		/// <exclude/>
		public string PictureName {
			get {
				return GetTypedColumnValue<string>("PictureName");
			}
			set {
				SetColumnValue("PictureName", value);
				if (_picture != null) {
					_picture.Name = value;
				}
			}
		}

		private SysImage _picture;
		/// <summary>
		/// Изображение.
		/// </summary>
		public SysImage Picture {
			get {
				return _picture ??
					(_picture = new SysImage(LookupColumnEntities.GetEntity("Picture")));
			}
		}

		/// <summary>
		/// Архивный.
		/// </summary>
		public bool IsArchive {
			get {
				return GetTypedColumnValue<bool>("IsArchive");
			}
			set {
				SetColumnValue("IsArchive", value);
			}
		}

		/// <exclude/>
		public Guid CategoryId {
			get {
				return GetTypedColumnValue<Guid>("CategoryId");
			}
			set {
				SetColumnValue("CategoryId", value);
				_category = null;
			}
		}

		/// <exclude/>
		public string CategoryName {
			get {
				return GetTypedColumnValue<string>("CategoryName");
			}
			set {
				SetColumnValue("CategoryName", value);
				if (_category != null) {
					_category.Name = value;
				}
			}
		}

		private ProductCategory _category;
		/// <summary>
		/// Категория.
		/// </summary>
		public ProductCategory Category {
			get {
				return _category ??
					(_category = new ProductCategory(LookupColumnEntities.GetEntity("Category")));
			}
		}

		/// <exclude/>
		public Guid TradeMarkId {
			get {
				return GetTypedColumnValue<Guid>("TradeMarkId");
			}
			set {
				SetColumnValue("TradeMarkId", value);
				_tradeMark = null;
			}
		}

		/// <exclude/>
		public string TradeMarkName {
			get {
				return GetTypedColumnValue<string>("TradeMarkName");
			}
			set {
				SetColumnValue("TradeMarkName", value);
				if (_tradeMark != null) {
					_tradeMark.Name = value;
				}
			}
		}

		private TradeMark _tradeMark;
		/// <summary>
		/// Торговая марка.
		/// </summary>
		public TradeMark TradeMark {
			get {
				return _tradeMark ??
					(_tradeMark = new TradeMark(LookupColumnEntities.GetEntity("TradeMark")));
			}
		}

		/// <summary>
		/// Краткое описание.
		/// </summary>
		public string ShortDescription {
			get {
				return GetTypedColumnValue<string>("ShortDescription");
			}
			set {
				SetColumnValue("ShortDescription", value);
			}
		}

		/// <summary>
		/// Преимущества.
		/// </summary>
		public string Benefits {
			get {
				return GetTypedColumnValue<string>("Benefits");
			}
			set {
				SetColumnValue("Benefits", value);
			}
		}

		/// <summary>
		/// Основные условия.
		/// </summary>
		public string GeneralConditions {
			get {
				return GetTypedColumnValue<string>("GeneralConditions");
			}
			set {
				SetColumnValue("GeneralConditions", value);
			}
		}

		#endregion

	}

	#endregion

}

