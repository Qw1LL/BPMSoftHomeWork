namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	#region Class: ProductPriceDataRepository

	/// <summary>
	/// Class for selection PriceList from Partnership.
	/// </summary>
	public class ProductPriceDataRepository
	{
		#region Fields: Protected

		protected readonly UserConnection UserConnection;
		protected Dictionary<Guid, ProductPriceData> ProductPriceLists;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="ProductPriceDataRepository"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		public ProductPriceDataRepository(UserConnection userConnection) {
			UserConnection = userConnection;
			ProductPriceLists = new Dictionary<Guid, ProductPriceData>();
		}

		#endregion

		#region Methods: Private

		private Select GetProductPriceListSelect(List<Guid> priceListIds, List<Guid> productIds) {
			return new Select(UserConnection)
					.Column("PP", "Price").As("Price")
					.Column("PP", "ProductId").As("ProductId")
					.Column("PP", "TaxId").As("TaxId")
					.Column("PP", "CurrencyId").As("CurrencyId")
					.Column("T", "Percent").As("Percent")
					.Column("PP", "PriceListId").As("PriceListId")
					.From("ProductPrice").As("PP")
					.InnerJoin("Tax").As("T")
					.On("T", "Id").IsEqual("PP", "TaxId")
					.Where("PriceListId").In(Column.Parameters(priceListIds))
					.And("ProductId").In(Column.Parameters(productIds))
				as Select;
		}
		
		private ProductPriceData CreateProductPriceData(IDataReader reader) {
			return new ProductPriceData {
				TaxId = reader.GetColumnValue<Guid>("TaxId"),
				CurrencyId = reader.GetColumnValue<Guid>("CurrencyId"),
				TaxPercent = reader.GetColumnValue<decimal>("Percent"),
				Price = reader.GetColumnValue<decimal>("Price"),
				PriceListId = reader.GetColumnValue<Guid>("PriceListId")
			};
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Initialize repository with product price lists in order like in price list collection.
		/// </summary>
		/// <param name="priceListIds">Price list in right order.</param>
		/// <param name="productIds">Products for wich we need product price.</param>
		public void Initialize(List<Guid> priceListIds, List<Guid> productIds) {
			var productPriceListSelect = GetProductPriceListSelect(priceListIds, productIds);
			productPriceListSelect.ExecuteReader(reader => {
				var productId = reader.GetColumnValue<Guid>("ProductId");
				var priceListId = reader.GetColumnValue<Guid>("PriceListId");
				if (ProductPriceLists.TryGetValue(productId, out ProductPriceData previousProductData)) { 
					if (priceListIds.IndexOf(previousProductData.PriceListId) > priceListIds.IndexOf(priceListId)) {
						ProductPriceLists[productId] = CreateProductPriceData(reader);
					}
				} else {
					ProductPriceLists.Add(productId, CreateProductPriceData(reader));
				}			
			});
		}

		/// <summary>
		/// Get Product price for product instance of the <see cref="ProductPriceDataRepository"/> class
		/// in out parameter.
		/// </summary>
		/// <param name="productId">Product identifier.</param>
		/// <param name="resultData">Product price data.</param>
		/// <returns>Product price exits</returns>
		public bool TryGetProductPriceData(Guid productId, out ProductPriceData resultData) {
			return ProductPriceLists.TryGetValue(productId, out resultData);
		}

		#endregion
	}

	#endregion

}
