namespace BPMSoft.Configuration 
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.Entities;

	#region Class: ProductPriceHelper

	public class ProductPriceHelper 
	{
		#region Fields: Private

		private UserConnection _userConnection;
		private EntitySchema _productPriceSchema;
		private EntitySchema _productSchema;

		#endregion

		#region Constructors

		public ProductPriceHelper(UserConnection userConnection) {
			_userConnection = userConnection;
			_productPriceSchema = _userConnection.EntitySchemaManager.GetInstanceByName("ProductPrice");
			_productSchema = _userConnection.EntitySchemaManager.GetInstanceByName("Product");
		}

		#endregion

		#region Methods: Private

		private int GetPriceColumnPrecision(Entity entity) {
			EntitySchemaColumn priceColumn = entity.Schema.Columns.FindByName("Price");
			if (priceColumn.DataValueType is FloatDataValueType) {
				var dbValueType = (FloatDataValueType)priceColumn.DataValueType;
				return dbValueType.Precision;
			}
			return 0;
		}

		private void NormalizePrice(Entity entity, int minPrecision) {
			decimal price = entity.GetTypedColumnValue<Decimal>("Price");
			decimal normalizedPrice = Math.Round(price, minPrecision, MidpointRounding.AwayFromZero);
			if (price != normalizedPrice) {
				entity.SetColumnValue("Price", normalizedPrice);
			}
		}

		private void NormalizePrices(Entity src, Entity dest) {
			var srcPricePrecision = GetPriceColumnPrecision(src);
			var destPricePrecision = GetPriceColumnPrecision(dest);
			int minPrecision = srcPricePrecision < destPricePrecision
				? srcPricePrecision
				: destPricePrecision;
			NormalizePrice(src, minPrecision);
			NormalizePrice(dest, minPrecision);
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Used to retrieve the BasePriceList value.
		/// </summary>
		/// <returns>BasePriceList Id.</returns>
		protected virtual Guid GetBasePriceListId() {
			object basePriceListValue;
			if (!Core.Configuration.SysSettings.TryGetValue(_userConnection, "BasePriceList",
				out basePriceListValue)) {
				return Guid.Empty;
			}
			var basePriceListId = (Guid)basePriceListValue;
			return basePriceListId;
		}

		/// <summary>
		/// Used to retrieve the Product entity by Id.
		/// </summary>
		/// <param name="productId">Product Id.</param>
		/// <returns>Product entity if it exists.</returns>
		protected virtual Entity GetProductEntity(Guid productId) {
			Entity product = _productSchema.CreateEntity(_userConnection);
			bool isFetched = product.FetchFromDB(productId);
			return isFetched ? product : null;
		}

		/// <summary>
		/// Used to create related to Product Id and PriceList Id ProductPrice entity.
		/// </summary>
		/// <param name="basePriceListId">PriceList Id.</param>
		/// <param name="productId">Product Id.</param>
		/// <returns>ProductPrice entity.</returns>
		protected virtual Entity GetNewBaseProductPriceEntity(Guid basePriceListId, Guid productId) {
			Entity baseProductPrice = _productPriceSchema.CreateEntity(_userConnection);
			baseProductPrice.SetDefColumnValues();
			baseProductPrice.SetColumnValue("Id", Guid.NewGuid());
			baseProductPrice.SetColumnValue("PriceListId", basePriceListId);
			baseProductPrice.SetColumnValue("ProductId", productId);
			return baseProductPrice;
		}

		/// <summary>
		/// Used to retrieve the ProductPrice entity by Product Id and PriceList Id.
		/// </summary>
		/// <param name="basePriceListId">PriceList Id.</param>
		/// <param name="productId">Product Id.</param>
		/// <returns>ProductPrice entity if it exists.</returns>
		protected virtual Entity GetBaseProductPriceEntity(Guid basePriceListId, Guid productId) {
			Entity baseProductPrice = _productPriceSchema.CreateEntity(_userConnection);
			var conditions = new Dictionary<string, object> {
				{"Product", productId},
				{"PriceList", basePriceListId}
			};
			bool isFetched = baseProductPrice.FetchFromDB(conditions);
			return isFetched ? baseProductPrice : null;
		}

		protected virtual bool IsEntityColumnChanged<T>(Entity src, Entity dest, string columnName) {
			T srcColumn = src.GetTypedColumnValue<T>(columnName);
			T destColumn = dest.GetTypedColumnValue<T>(columnName);
			return !srcColumn.Equals(destColumn);
		}

		/// <summary>
		/// Used to check equivalence of CurrencyId, TaxId, Price values.
		/// </summary>
		/// <param name="src">Source entity.</param>
		/// <param name="dest">Destination entity.</param>
		/// <returns>
		/// False if CurrencyId, Price, and TaxId are equals to destination values and true otherwise.
		/// </returns>
		protected virtual bool IsEntityColumnsChanged(Entity src, Entity dest) {
			bool isPriceChanged = IsEntityColumnChanged<Decimal>(src, dest, "Price");
			bool isCurrencyChanged = IsEntityColumnChanged<Guid>(src, dest, "CurrencyId");
			bool isTaxChanged = IsEntityColumnChanged<Guid>(src, dest, "TaxId");
			return isCurrencyChanged || isPriceChanged || isTaxChanged;
		}

		/// <summary>
		/// Used to synchronise CurrencyId, TaxId, Price columns.
		/// </summary>
		/// <param name="src">Source entity.</param>
		/// <param name="dest">Destination entity.</param>
		protected virtual void SyncEntities(Entity src, Entity dest) {
			NormalizePrices(src, dest);
			bool isColumnsChanged = IsEntityColumnsChanged(src, dest);
			if (!isColumnsChanged && dest.StoringState != StoringObjectState.New) {
				return;
			}
			var currency = src.GetTypedColumnValue<Guid>("CurrencyId");
			var price = src.GetTypedColumnValue<Decimal>("Price");
			Guid tax = src.GetTypedColumnValue<Guid>("TaxId");
			object taxValue = null;
			if (tax != Guid.Empty) {
				taxValue = tax;
			}
			dest.SetColumnValue("CurrencyId", currency);
			dest.SetColumnValue("Price", price);
			dest.SetColumnValue("TaxId", taxValue);
			dest.Save(false);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Updates price for related BasePriceList ProductPrice record.
		/// If ProductPrice record isn't exists and price isn't empty - creates them.
		/// </summary>
		/// <param name="product">Product entity.</param>
		public void SetPriceInBasePriceList(Entity product) {
			if (product == null) {
				return;
			}
			Guid productId = product.GetTypedColumnValue<Guid>("Id");
			Guid basePriceListId = GetBasePriceListId();
			if (basePriceListId == Guid.Empty) {
				return;
			}
			Entity baseProductPrice = GetBaseProductPriceEntity(basePriceListId, productId);
			if (baseProductPrice == null) {
				baseProductPrice = GetNewBaseProductPriceEntity(basePriceListId, productId);
			}
			SyncEntities(product, baseProductPrice);
		}

		/// <summary>
		/// Updates price for related Product record if PriceList column equals to BasePriceList SysSettings value.
		/// </summary>
		/// <param name="productPrice">ProductPrice entity.</param>
		public void SetPriceInProduct(Entity productPrice) {
			if (productPrice == null) {
				return;
			}
			Guid basePriceListId = GetBasePriceListId();
			if (basePriceListId == Guid.Empty) {
				return;
			}
			Guid productPricePriceListId = productPrice.GetTypedColumnValue<Guid>("PriceListId");
			if (!productPricePriceListId.Equals(basePriceListId)) {
				return;
			}
			Guid productId = productPrice.GetTypedColumnValue<Guid>("ProductId");
			Entity product = GetProductEntity(productId);
			if (product == null) {
				return;
			}
			SyncEntities(productPrice, product);
		}

		#endregion
	}

	#endregion
}
