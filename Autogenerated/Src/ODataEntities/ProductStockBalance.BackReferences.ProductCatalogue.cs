namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: ProductStockBalance

	/// <exclude/>
	public class ProductStockBalance : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public ProductStockBalance(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ProductStockBalance";
		}

		public ProductStockBalance(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "ProductStockBalance";
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
		public Guid ProductId {
			get {
				return GetTypedColumnValue<Guid>("ProductId");
			}
			set {
				SetColumnValue("ProductId", value);
				_product = null;
			}
		}

		/// <exclude/>
		public string ProductName {
			get {
				return GetTypedColumnValue<string>("ProductName");
			}
			set {
				SetColumnValue("ProductName", value);
				if (_product != null) {
					_product.Name = value;
				}
			}
		}

		private Product _product;
		/// <summary>
		/// Продукт.
		/// </summary>
		public Product Product {
			get {
				return _product ??
					(_product = new Product(LookupColumnEntities.GetEntity("Product")));
			}
		}

		/// <summary>
		/// Остаток.
		/// </summary>
		public Decimal TotalQuantity {
			get {
				return GetTypedColumnValue<Decimal>("TotalQuantity");
			}
			set {
				SetColumnValue("TotalQuantity", value);
			}
		}

		/// <summary>
		/// Резерв.
		/// </summary>
		public Decimal ReserveQuantity {
			get {
				return GetTypedColumnValue<Decimal>("ReserveQuantity");
			}
			set {
				SetColumnValue("ReserveQuantity", value);
			}
		}

		/// <summary>
		/// Доступно.
		/// </summary>
		public Decimal AvailableQuantity {
			get {
				return GetTypedColumnValue<Decimal>("AvailableQuantity");
			}
			set {
				SetColumnValue("AvailableQuantity", value);
			}
		}

		/// <exclude/>
		public Guid WarehouseId {
			get {
				return GetTypedColumnValue<Guid>("WarehouseId");
			}
			set {
				SetColumnValue("WarehouseId", value);
				_warehouse = null;
			}
		}

		/// <exclude/>
		public string WarehouseName {
			get {
				return GetTypedColumnValue<string>("WarehouseName");
			}
			set {
				SetColumnValue("WarehouseName", value);
				if (_warehouse != null) {
					_warehouse.Name = value;
				}
			}
		}

		private Warehouse _warehouse;
		/// <summary>
		/// Склад.
		/// </summary>
		public Warehouse Warehouse {
			get {
				return _warehouse ??
					(_warehouse = new Warehouse(LookupColumnEntities.GetEntity("Warehouse")));
			}
		}

		#endregion

	}

	#endregion

}

