namespace BPMSoft.Configuration
{
	using System;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.DB;
	using BPMSoft.Web.Common;

	#region Class: SupplyPaymentService

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class SupplyPaymentService : BaseService
	{

		#region Methods: Privite

		private EntityCollection GetSupplyPaymentProduct(Guid supplyPaymentProductId, Guid contractId) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SupplyPaymentProduct");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			var product = esq.AddColumn("Product");
			var quantity = esq.AddColumn("Quantity");
			esq.Filters.Add(esq.CreateFilterWithParameters(
				FilterComparisonType.NotEqual,
				"[SupplyPaymentElement:Id:SupplyPaymentElement].Id",
				supplyPaymentProductId
			));
			esq.Filters.Add(esq.CreateIsNotNullFilter(
				"[SupplyPaymentElement:Id:SupplyPaymentElement].Contract"
			));
			esq.Filters.Add(esq.CreateFilterWithParameters(
				FilterComparisonType.NotEqual,
				"[SupplyPaymentElement:Id:SupplyPaymentElement].Contract",
				contractId
			));
			return esq.GetEntityCollection(UserConnection);
		}

		private EntityCollection GetCurrentSupplyPaymentProduct(Guid supplyPaymentProductId) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SupplyPaymentProduct");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			var product = esq.AddColumn("Product");
			var contract = esq.AddColumn("SupplyPaymentElement.Contract");
			var quantity = esq.AddColumn("Quantity");
			esq.Filters.Add(esq.CreateFilterWithParameters(
				FilterComparisonType.Equal,
				"[SupplyPaymentElement:Id:SupplyPaymentElement].Id",
				supplyPaymentProductId
			));
			return esq.GetEntityCollection(UserConnection);
		}
	
		private EntityCollection GetQuantityOrderProduct(Guid id) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "OrderProduct");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("Name");
			esq.AddColumn("Notes");
			esq.AddColumn("Product");
			esq.AddColumn("CustomProduct");
			esq.AddColumn("DeliveryDate");
			esq.AddColumn("Quantity");
			esq.AddColumn("Unit");
			esq.AddColumn("PrimaryPrice");
			esq.AddColumn("Price");
			esq.AddColumn("PrimaryAmount");
			esq.AddColumn("Amount");
			esq.AddColumn("PrimaryDiscountAmount");
			esq.AddColumn("DiscountAmount");
			esq.AddColumn("DiscountPercent");
			esq.AddColumn("Tax");
			esq.AddColumn("PrimaryTaxAmount");
			esq.AddColumn("TaxAmount");
			esq.AddColumn("PrimaryTotalAmount");
			esq.AddColumn("TotalAmount");
			esq.AddColumn("DiscountTax");
			esq.AddColumn("Order");
			esq.AddColumn("BaseQuantity");
			esq.AddColumn("PriceList");
			esq.AddColumn("Currency");
			esq.AddColumn("CurrencyRate");
			esq.Filters.Add(esq.CreateFilterWithParameters(
				FilterComparisonType.Equal,
				"Id",
				id
			));
			return esq.GetEntityCollection(UserConnection);
		}

		private void UpdateOrderProduct(Guid orderId) {
			QueryColumnExpression totalAmount =
					(Column.SourceColumn("Quantity") * Column.SourceColumn("PrimaryPrice")).Block() -
					((Column.SourceColumn("PrimaryPrice") * Column.SourceColumn("DiscountPercent") /
						Column.Parameter(100)).Block() * Column.SourceColumn("Quantity")).Block();
			Update update = new Update(UserConnection, "OrderProduct").
				Set("TotalAmount", totalAmount).
				Where("OrderId").IsEqual(Column.Parameter(orderId)) as Update;
			update.Execute();
		}
		
		private void UpdateQuantity(Guid productId, decimal quantity, decimal currentQuantity) {
			Update update = new Update(UserConnection, "OrderProduct").
				Set("Quantity", Column.Parameter(quantity - currentQuantity)).
				Where("Id").IsEqual(Column.Parameter(productId)) as Update;
			update.Execute();
		}

		private void CreateOrderProduct(Entity quantityOrderProduct, decimal currentQuantity, Guid currentContract) {
			var orderProductId = Guid.NewGuid();
			var orderProductSchema = UserConnection.EntitySchemaManager.GetInstanceByName("OrderProduct");
			var orderProduct = orderProductSchema.CreateEntity(UserConnection);
			orderProduct.SetDefColumnValues();
			orderProduct.SetColumnValue("Id", orderProductId);
			orderProduct.SetColumnValue("Name", quantityOrderProduct.GetTypedColumnValue<string>("Name"));
			orderProduct.SetColumnValue("Notes", quantityOrderProduct.GetTypedColumnValue<string>("Notes"));
			if (quantityOrderProduct.GetTypedColumnValue<Guid>("ProductId") != Guid.Empty) {
				orderProduct.SetColumnValue("ProductId", quantityOrderProduct.GetTypedColumnValue<Guid>("ProductId"));
			}
			orderProduct.SetColumnValue("CustomProduct", quantityOrderProduct.GetTypedColumnValue<string>("CustomProduct"));
			orderProduct.SetColumnValue("DeliveryDate", quantityOrderProduct.GetTypedColumnValue<DateTime>("DeliveryDate"));
			orderProduct.SetColumnValue("Quantity", currentQuantity);
			if (quantityOrderProduct.GetTypedColumnValue<Guid>("UnitId") != Guid.Empty) {
				orderProduct.SetColumnValue("UnitId", quantityOrderProduct.GetTypedColumnValue<Guid>("UnitId"));
			}
			orderProduct.SetColumnValue("PrimaryPrice", quantityOrderProduct.GetTypedColumnValue<decimal>("PrimaryPrice"));
			orderProduct.SetColumnValue("Price", quantityOrderProduct.GetTypedColumnValue<decimal>("Price"));
			orderProduct.SetColumnValue("PrimaryAmount", quantityOrderProduct.GetTypedColumnValue<decimal>("PrimaryAmount"));
			orderProduct.SetColumnValue("Amount", quantityOrderProduct.GetTypedColumnValue<decimal>("Amount"));
			orderProduct.SetColumnValue("PrimaryDiscountAmount", quantityOrderProduct.GetTypedColumnValue<decimal>("PrimaryDiscountAmount"));
			orderProduct.SetColumnValue("DiscountAmount", quantityOrderProduct.GetTypedColumnValue<decimal>("DiscountAmount"));
			orderProduct.SetColumnValue("DiscountPercent", quantityOrderProduct.GetTypedColumnValue<decimal>("DiscountPercent"));
			if (quantityOrderProduct.GetTypedColumnValue<Guid>("TaxId") != Guid.Empty) {
				orderProduct.SetColumnValue("TaxId", quantityOrderProduct.GetTypedColumnValue<Guid>("TaxId"));
			}
			orderProduct.SetColumnValue("PrimaryTaxAmount", quantityOrderProduct.GetTypedColumnValue<decimal>("PrimaryTaxAmount"));
			orderProduct.SetColumnValue("TaxAmount", quantityOrderProduct.GetTypedColumnValue<decimal>("TaxAmount"));
			orderProduct.SetColumnValue("PrimaryTotalAmount", quantityOrderProduct.GetTypedColumnValue<decimal>("PrimaryTotalAmount"));
			orderProduct.SetColumnValue("TotalAmount", quantityOrderProduct.GetTypedColumnValue<decimal>("TotalAmount"));
			orderProduct.SetColumnValue("DiscountTax", quantityOrderProduct.GetTypedColumnValue<decimal>("DiscountTax"));
			if (quantityOrderProduct.GetTypedColumnValue<Guid>("OrderId") != Guid.Empty) {
				orderProduct.SetColumnValue("OrderId", quantityOrderProduct.GetTypedColumnValue<Guid>("OrderId"));
			}
			orderProduct.SetColumnValue("BaseQuantity", quantityOrderProduct.GetTypedColumnValue<decimal>("BaseQuantity"));
			if (quantityOrderProduct.GetTypedColumnValue<Guid>("PriceListId") != Guid.Empty) {
				orderProduct.SetColumnValue("PriceListId", quantityOrderProduct.GetTypedColumnValue<Guid>("PriceListId"));
			}
			if (quantityOrderProduct.GetTypedColumnValue<Guid>("CurrencyId") != Guid.Empty) {
				orderProduct.SetColumnValue("CurrencyId", quantityOrderProduct.GetTypedColumnValue<Guid>("CurrencyId"));
			}
			orderProduct.SetColumnValue("CurrencyRate", quantityOrderProduct.GetTypedColumnValue<decimal>("CurrencyRate"));
			if (currentContract != Guid.Empty) {
				orderProduct.SetColumnValue("ContractId", currentContract);
			}
			orderProduct.Save();
		}

		#endregion

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		public bool NeedDivideProduct(Guid supplyPaymentProductId, Guid contractId) {
			EntityCollection supplyPaymentProductCollection = GetSupplyPaymentProduct(supplyPaymentProductId, contractId);
			EntityCollection currentSupplyPaymentProductCollection = GetCurrentSupplyPaymentProduct(supplyPaymentProductId);
			foreach (Entity supplyPaymentProductItem in supplyPaymentProductCollection) {
				foreach (Entity currentSupplyPaymentProductItem in currentSupplyPaymentProductCollection) {
					Guid productId = supplyPaymentProductItem.GetTypedColumnValue<Guid>("ProductId");
					Guid currentProductId = currentSupplyPaymentProductItem.GetTypedColumnValue<Guid>("ProductId");
					if (productId == currentProductId) {
						return true;
					}
				}
			}
			return false;
		}


		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		public void DivideProduct(Guid supplyPaymentProductId, Guid contractId) {
			EntityCollection supplyPaymentProductCollection = GetSupplyPaymentProduct(supplyPaymentProductId, contractId);
			EntityCollection currentSupplyPaymentProductCollection = GetCurrentSupplyPaymentProduct(supplyPaymentProductId);
			foreach(Entity supplyPaymentProductItem in supplyPaymentProductCollection) {
				foreach (Entity currentSupplyPaymentProductItem in currentSupplyPaymentProductCollection) {
					Guid productId = supplyPaymentProductItem.GetTypedColumnValue<Guid>("ProductId");
					Guid currentProductId = currentSupplyPaymentProductItem.GetTypedColumnValue<Guid>("ProductId");
					Guid currentContract = currentSupplyPaymentProductItem.GetTypedColumnValue<Guid>("SupplyPaymentElement_ContractId");
					decimal currentQuantity = currentSupplyPaymentProductItem.GetTypedColumnValue<decimal>("Quantity");
					if (productId == currentProductId) {
						var quantityCollection = GetQuantityOrderProduct(productId);
						if (quantityCollection.Count == 0) {
							return;
						}
						var quantityOrderProduct = quantityCollection[0];
						var quantity = quantityOrderProduct.GetTypedColumnValue<decimal>("Quantity");
						var order = quantityOrderProduct.GetTypedColumnValue<Guid>("OrderId");
						if (quantity <= 0 || (quantity - currentQuantity) < 0) {
							return;
						}
						UpdateQuantity(productId, quantity, currentQuantity);
						CreateOrderProduct(quantityOrderProduct, currentQuantity, currentContract);
						UpdateOrderProduct(order);
					}
				}
			}
		}

		#endregion
	}

	#endregion
}
