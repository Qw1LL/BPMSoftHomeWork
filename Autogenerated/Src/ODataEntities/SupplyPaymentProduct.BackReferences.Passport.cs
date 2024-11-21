namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SupplyPaymentProduct

	/// <exclude/>
	public class SupplyPaymentProduct : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SupplyPaymentProduct(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SupplyPaymentProduct";
		}

		public SupplyPaymentProduct(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SupplyPaymentProduct";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<InvoiceProduct> InvoiceProductCollectionBySupplyPaymentProduct {
			get;
			set;
		}

		public IEnumerable<VwSupplyPaymentProduct> VwSupplyPaymentProductCollectionBySupplyPaymentProduct {
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

		private OrderProduct _product;
		/// <summary>
		/// Продукт.
		/// </summary>
		public OrderProduct Product {
			get {
				return _product ??
					(_product = new OrderProduct(LookupColumnEntities.GetEntity("Product")));
			}
		}

		/// <summary>
		/// Количество.
		/// </summary>
		public Decimal Quantity {
			get {
				return GetTypedColumnValue<Decimal>("Quantity");
			}
			set {
				SetColumnValue("Quantity", value);
			}
		}

		/// <summary>
		/// Сумма.
		/// </summary>
		public Decimal Amount {
			get {
				return GetTypedColumnValue<Decimal>("Amount");
			}
			set {
				SetColumnValue("Amount", value);
			}
		}

		/// <exclude/>
		public Guid SupplyPaymentElementId {
			get {
				return GetTypedColumnValue<Guid>("SupplyPaymentElementId");
			}
			set {
				SetColumnValue("SupplyPaymentElementId", value);
				_supplyPaymentElement = null;
			}
		}

		/// <exclude/>
		public string SupplyPaymentElementName {
			get {
				return GetTypedColumnValue<string>("SupplyPaymentElementName");
			}
			set {
				SetColumnValue("SupplyPaymentElementName", value);
				if (_supplyPaymentElement != null) {
					_supplyPaymentElement.Name = value;
				}
			}
		}

		private SupplyPaymentElement _supplyPaymentElement;
		/// <summary>
		/// Шаг графика поставок и оплат.
		/// </summary>
		public SupplyPaymentElement SupplyPaymentElement {
			get {
				return _supplyPaymentElement ??
					(_supplyPaymentElement = new SupplyPaymentElement(LookupColumnEntities.GetEntity("SupplyPaymentElement")));
			}
		}

		/// <summary>
		/// Количество, б.е.
		/// </summary>
		public Decimal BaseQuantity {
			get {
				return GetTypedColumnValue<Decimal>("BaseQuantity");
			}
			set {
				SetColumnValue("BaseQuantity", value);
			}
		}

		#endregion

	}

	#endregion

}

