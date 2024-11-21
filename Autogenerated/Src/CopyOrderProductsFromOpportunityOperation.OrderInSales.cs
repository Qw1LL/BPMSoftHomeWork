namespace BPMSoft.Configuration
{
	using System;
	using System.Linq;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using System.Text.RegularExpressions;

	#region Class: CopyOrderProductsFromOpportunityOperation

	public class CopyOrderProductsFromOpportunityOperation
	{

		#region Class: CopyOrderProductsArgs

		/// <summary>
		/// Arguments for CopyOrderProductsFromOpportunityOperation.
		/// </summary>
		public partial class CopyOrderProductsArgs
		{

			#region Constants: Private

			private const string _productListPattern = @"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-]" +
				@"[0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})(\,[0-9A-Fa-f]{8}[-][0-9A-Fa-f]" +
				@"{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})*$";

			#endregion

			#region Properties: Public

			/// <summary>
			/// Opportunity identifier.
			/// </summary>
			/// <value>
			/// The opportunity identifier.
			/// </value>
			public Guid OpportunityId { get; set; }

			/// <summary>
			/// Order identifier.
			/// </summary>
			/// <value>
			/// The order identifier.
			/// </value>
			public Guid OrderId { get; set; }

			private string _productItems;

			/// <summary>
			/// Product identifiers, separated by comma.
			/// </summary>
			/// <value>
			/// The product items.
			/// </value>
			public string ProductItems {
				get {
					return _productItems;
				}
				set {
					if (value.IsNullOrEmpty()) {
						return;
					}
					if (Regex.IsMatch(value, _productListPattern)) {
						_productItems = value;
					} else {
						throw new ArgumentException(nameof(ProductItems));
					}
				}
			}

			/// <summary>
			/// Copy all product to order flag.
			/// </summary>
			/// <value>
			/// Copy all product to order flag.
			/// </value>
			public bool IsCopyAllProducts { get; set; }

			#endregion
		}

		#endregion

		#region Constants: Private

		private const string OrderProductSchemaName = "OrderProduct";
		private const string OpportunityProductSchemaName = "OpportunityProductInterest";
		private const string ProductUnitColumnsPath = "ProductUnit_Product_Product_";

		#endregion

		#region Fields: Protected

		protected readonly UserConnection UserConnection;
		protected readonly EntitySchema OrderProductSchema;
		protected CopyOrderProductsArgs OperationArguments;
		protected bool PriceWithTaxes;

		#endregion

		#region Constructors: Public

		public CopyOrderProductsFromOpportunityOperation(UserConnection userConnection) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			UserConnection = userConnection;
			OrderProductSchema = UserConnection.EntitySchemaManager
				.GetInstanceByName(OrderProductSchemaName);
		}

		#endregion

		#region Methods: Private

		private bool IsOpportunityProductSingle(EntityCollection products, Guid oppProductId) {
			return products.Count(entity => entity.GetTypedColumnValue<Guid>("Id") == oppProductId) == 1;
		}

		#endregion

		#region Methods: Protected

		protected virtual void Init(CopyOrderProductsArgs args) {
			OperationArguments = args;
			PriceWithTaxes = Core.Configuration.SysSettings.GetValue(UserConnection, "PriceWithTaxes", false);
		}

		protected virtual EntitySchemaQuery FormOpportunityProductESQ() {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager
				.GetInstanceByName(OpportunityProductSchemaName));
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("Product.Name");
			esq.AddColumn("Product.Unit");
			esq.AddColumn("Product.Tax");
			esq.AddColumn("Product.Tax.Percent");
			esq.AddColumn("Product");
			esq.AddColumn("Quantity");
			esq.AddColumn("Price");
			esq.AddColumn("Amount");
			esq.AddColumn("[ProductUnit:Product:Product].NumberOfBaseUnits");
			esq.AddColumn("[ProductUnit:Product:Product].Unit");
			esq.Filters.Add(esq.CreateFilterWithParameters(
				FilterComparisonType.Equal, "Opportunity", OperationArguments.OpportunityId));
			if (!OperationArguments.IsCopyAllProducts) {
				var productCol = new List<string>(OperationArguments.ProductItems.Split(','));
				esq.Filters.Add(esq.CreateFilterWithParameters(
					FilterComparisonType.Equal, "Product", productCol));
			}
			return esq;
		}

		protected void SetAmountColumns(Entity orderProduct, Entity opportunityProduct) {
			decimal taxAmount;
			decimal totalAmount;
			decimal amount = opportunityProduct.GetTypedColumnValue<decimal>("Amount");
			decimal taxPercent = opportunityProduct.GetTypedColumnValue<decimal>("Product_Tax_Percent");
			if (PriceWithTaxes) {
				taxAmount = (amount * taxPercent) / (100 + taxPercent);
				totalAmount = amount;
			} else {
				taxAmount = (amount * taxPercent) / 100;
				totalAmount = amount + taxAmount;
			}
			orderProduct.SetColumnValue("Price", opportunityProduct.GetColumnValue("Price"));
			orderProduct.SetColumnValue("DiscountTax", taxPercent);
			orderProduct.SetColumnValue("Amount", amount);
			orderProduct.SetColumnValue("PrimaryAmount", amount);
			orderProduct.SetColumnValue("DiscountAmount", 0);
			orderProduct.SetColumnValue("PrimaryTotalAmount", totalAmount);
			orderProduct.SetColumnValue("TotalAmount", totalAmount);
			orderProduct.SetColumnValue("TaxAmount", taxAmount);
		}

		protected void SetQuantityColumns(Entity orderProduct, Entity opportunityProduct) {
			decimal quantity = opportunityProduct.GetTypedColumnValue<decimal>("Quantity");
			orderProduct.SetColumnValue("Quantity", quantity);
			decimal numberOfBaseUnits = opportunityProduct.GetTypedColumnValue<decimal>(
				ProductUnitColumnsPath + "NumberOfBaseUnits");
			decimal baseQuantity = quantity;
			if (numberOfBaseUnits > 0 && AreUnitsEquals(opportunityProduct)) {
				baseQuantity = numberOfBaseUnits * quantity;
			}
			orderProduct.SetColumnValue("BaseQuantity", baseQuantity);
		}

		protected virtual void SetOrderProductValues(Entity orderProduct, Entity opportunityProduct) {
			orderProduct.SetColumnValue("Name", opportunityProduct.GetColumnValue("Product_Name"));
			orderProduct.SetColumnValue("ProductId", opportunityProduct.GetColumnValue("ProductId"));
			orderProduct.SetColumnValue("UnitId", opportunityProduct.GetColumnValue("Product_UnitId"));
			orderProduct.SetColumnValue("TaxId", opportunityProduct.GetColumnValue("Product_TaxId"));
			orderProduct.SetColumnValue("OrderId", OperationArguments.OrderId);
			SetAmountColumns(orderProduct, opportunityProduct);
			SetQuantityColumns(orderProduct, opportunityProduct);
		}

		protected bool AreUnitsEquals(Entity product) {
			Guid productUnitId = product.GetTypedColumnValue<Guid>(ProductUnitColumnsPath + "UnitId");
			Guid productCurrentUnitId = product.GetTypedColumnValue<Guid>("Product_UnitId");
			return productUnitId == productCurrentUnitId;
		}

		protected void ProcessOpportunityProduct(Entity product, EntityCollection products) {
			Guid oppProductId = product.GetTypedColumnValue<Guid>("Id");
			Guid productUnitId = product.GetTypedColumnValue<Guid>(ProductUnitColumnsPath + "UnitId");
			if (productUnitId.IsEmpty() ||
					AreUnitsEquals(product) || 
					IsOpportunityProductSingle(products, oppProductId)) {
				Entity orderProductEntity = OrderProductSchema.CreateEntity(UserConnection);
				orderProductEntity.SetDefColumnValues();
				SetOrderProductValues(orderProductEntity, product);
				orderProductEntity.Save(false);
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Executes operation that copies opportunity products to order.
		/// </summary>
		/// <param name="args">The operation arguments.</param>
		public void Execute(CopyOrderProductsArgs args) {
			Init(args);
			EntitySchemaQuery esq = FormOpportunityProductESQ();
			EntityCollection products = esq.GetEntityCollection(UserConnection);
			if (products.IsEmpty()) {
				return;
			}
			foreach (Entity product in products) {
				ProcessOpportunityProduct(product, products);
			}
		}

		#endregion

	} 

	#endregion

}
