namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Common;

	public class ProductEntryUtils
	{

		#region Constructors: Public

		public ProductEntryUtils(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Protected

		protected UserConnection UserConnection {
			get;
			private set;
		}

		#endregion

		#region Methods: Private

		private static decimal Division(decimal value, decimal currencyRate, decimal division) {
			decimal result = 0;
			if (currencyRate > 0) {
				result = value * division / currencyRate;
			}
			return result;
		}

		#endregion

		#region Methods: Protected

		protected virtual void UpdateProductEntry(UserConnection userConnection, string productDetailSchemaName, Guid recordId,
			decimal price, decimal amount, decimal totalAmount, decimal discountAmount, decimal taxAmount, decimal rate, decimal division) {
			var update = (Update)new Update(userConnection, productDetailSchemaName)
				.Set("Price", Column.Parameter(price))
				.Set("Amount", Column.Parameter(amount))
				.Set("DiscountAmount", Column.Parameter(discountAmount))
				.Set("TaxAmount", Column.Parameter(taxAmount))
				.Set("TotalAmount", Column.Parameter(totalAmount))
				.Set("PrimaryPrice", Column.Parameter(Division(price, rate, division)))
				.Set("PrimaryAmount", Column.Parameter(Division(amount, rate, division)))
				.Set("PrimaryDiscountAmount", Column.Parameter(Division(discountAmount, rate, division)))
				.Set("PrimaryTaxAmount", Column.Parameter(Division(taxAmount, rate, division)))
				.Set("PrimaryTotalAmount", Column.Parameter(Division(totalAmount, rate, division)))
				.Where("Id").IsEqual(Column.Parameter(recordId));
			update.Execute();

		}


		protected virtual void UpdateMasterSchemaRecordAmount(string masterSchemaName, Guid masterRecordId,
				decimal totalAmount, decimal primaryTotalAmount) {
			var update = (Update)new Update(UserConnection, masterSchemaName)
				.Set("Amount", Column.Parameter(totalAmount))
				.Set("PrimaryAmount", Column.Parameter(primaryTotalAmount))
				.Where("Id").IsEqual(Column.Parameter(masterRecordId));
			update.Execute();
		}

		protected virtual Select GetProductFinanceSelect(UserConnection userConnection, string masterSchemaName,
			Guid masterRecordId, string productDetailSchemaName) {
			Select productFinanceSelect = new Select(userConnection)
					.Column("p", "Price")
					.Column("ProductDetail", "ProductId")
					.Column("ProductDetail", "CustomProduct")
					.Column("ProductDetail", "Quantity")
					.Column("ProductDetail", "DiscountPercent")
					.Column("ProductDetail", "Price")
					.Column("p", "CurrencyId")
					.Column("c", "Division")
					.Column("cr", "Rate")
					.Column("ProductDetail", "Id")
					.Column("t", "Percent")
					.From(productDetailSchemaName).As("ProductDetail")
					.LeftOuterJoin("Product").As("p").On("ProductDetail", "ProductId").IsEqual("p", "Id")
					.LeftOuterJoin("Tax").As("t").On("ProductDetail", "TaxId").IsEqual("t", "Id")
					.LeftOuterJoin("Currency").As("c").On("p", "CurrencyId").IsEqual("c", "Id")
					.LeftOuterJoin("CurrencyRate").As("cr").On("c", "Id").IsEqual("cr", "CurrencyId").And("cr", "StartDate").IsEqual(
						new Select(userConnection).Column(Func.Max("cr2", "StartDate")).From("CurrencyRate").As("cr2").Where("cr2", "CurrencyId").IsEqual("c", "Id"))
					.Where("ProductDetail", masterSchemaName + "Id").IsEqual(new QueryParameter(masterRecordId)) as Select;
			return productFinanceSelect;
		}

		protected virtual decimal GetCurrencyDivision(UserConnection userConnection, Guid currencyId) {
			Select currencyDivisionSelect = (Select)new Select(userConnection)
					.Column("c", "Division")
					.From("Currency").As("c")
					.Where("Id").IsEqual(new QueryParameter(currencyId));
			using (DBExecutor dbExecutor = userConnection.EnsureDBConnection()) {
				using (var dataReader = currencyDivisionSelect.ExecuteReader(dbExecutor)) {
					if (dataReader.Read()) {
						return userConnection.DBTypeConverter.DBValueToDecimal(dataReader[0]);
					}
				}
			}
			return 1m;
		}
		#endregion

		#region Methods: Public

		[Obsolete("Use RecalculateAmountByProducts")]
		public static void RecalculateFinanceByProducts(UserConnection userConnection, string masterSchemaName, string masterRecordId,
				string productDetailSchemaName, string masterRecordCurrencyId, double masterRecordCurrencyRate) {
			ProductEntryUtils utils = ClassFactory.Get<ProductEntryUtils>(new ConstructorArgument("userConnection", userConnection));
			Guid masterRecordIdGuid, masterRecordCurrencyIdGuid;
			if (!Guid.TryParse(masterRecordId, out masterRecordIdGuid)) {
				return;
			}
			Guid.TryParse(masterRecordCurrencyId, out masterRecordCurrencyIdGuid);
			utils.RecalculateAmountByProducts(masterSchemaName, masterRecordIdGuid, productDetailSchemaName,
				masterRecordCurrencyIdGuid, Convert.ToDecimal(masterRecordCurrencyRate));
		}
		
		/// <summary>
		/// Updates record products amounts.
		/// </summary>
		/// <param name="entity">Entity with products.</param>
		/// <param name="updateCurrency">Update products currency.</param>
		public virtual void UpdateRecordProductAmounts(Entity entity, bool updateCurrency = false) {
			if (entity == null) {
				throw new ArgumentNullException("entity");
			}
			string masterSchemaName = entity.SchemaName;
			Guid currencyId = entity.GetTypedColumnValue<Guid>("CurrencyId");
			decimal currencyRate = entity.GetTypedColumnValue<decimal>("CurrencyRate");
			Entity currencyEntity = UserConnection.EntitySchemaManager.GetInstanceByName("Currency").CreateEntity(UserConnection);
			currencyEntity.FetchFromDB(currencyEntity.Schema.GetPrimaryColumnName(), currencyId, new[] { "Division" });
			decimal division = currencyEntity.GetTypedColumnValue<decimal>("Division");
			decimal currencyFromPrimaryFactor = division != 0 ? currencyRate / division : 0;
			var update =
				new Update(UserConnection, string.Format("{0}Product", masterSchemaName))
					.Set("Price", Column.Parameter(currencyFromPrimaryFactor) * Column.SourceColumn("PrimaryPrice"))
					.Set("Amount", Column.Parameter(currencyFromPrimaryFactor) * Column.SourceColumn("PrimaryAmount"))
					.Set("DiscountAmount", Column.Parameter(currencyFromPrimaryFactor) * Column.SourceColumn("PrimaryDiscountAmount"))
					.Set("TaxAmount", Column.Parameter(currencyFromPrimaryFactor) * Column.SourceColumn("PrimaryTaxAmount"))
					.Set("TotalAmount", Column.Parameter(currencyFromPrimaryFactor) * Column.SourceColumn("PrimaryTotalAmount"))
					.Where(string.Format("{0}Id", masterSchemaName))
					.IsEqual(Column.Parameter(entity.GetTypedColumnValue<Guid>("Id"))) as Update;
			if (updateCurrency) {
				update
					.Set("CurrencyId", Column.Parameter(currencyId))
					.Set("CurrencyRate", Column.Parameter(currencyRate));
			}
			update.Execute();
		}

		public void RecalculateAmountByProducts(string masterSchemaName, Guid masterRecordId,
				string productDetailSchemaName, Guid masterRecordCurrencyId, decimal masterRecordCurrencyRate) {
			var productFinanceSelect = GetProductFinanceSelect(UserConnection, masterSchemaName, masterRecordId, productDetailSchemaName);
			decimal totalMasterAmount = 0.0m;
			decimal totalQuantity = 0;
			var masterDivision = GetCurrencyDivision(UserConnection, masterRecordCurrencyId);
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (var dataReader = productFinanceSelect.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
				decimal productPriceMasterRecordCurrency;
				decimal taxAmount = 0.0m;
						decimal quantity = UserConnection.DBTypeConverter.DBValueToDecimal(dataReader[3]);
				Guid masterCurrencyId = masterRecordCurrencyId;
						if (!dataReader.IsDBNull(0)) {
							decimal productPriceOriginalCurrency = UserConnection.DBTypeConverter.DBValueToDecimal(dataReader[0]);
							Guid productCurrencyId = UserConnection.DBTypeConverter.DBValueToGuid(dataReader[6]);
							decimal productRate = UserConnection.DBTypeConverter.DBValueToDecimal(dataReader[8]);
							decimal productDivision = UserConnection.DBTypeConverter.DBValueToDecimal(dataReader[7]);
				if (productCurrencyId != masterCurrencyId) {
					productPriceMasterRecordCurrency = (productPriceOriginalCurrency * masterRecordCurrencyRate * productDivision) / (productRate * masterDivision);
				} else {
								productPriceMasterRecordCurrency = productPriceOriginalCurrency;
							}
						} else {
							productPriceMasterRecordCurrency = UserConnection.DBTypeConverter.DBValueToDecimal(dataReader[5]);
				}
						decimal discountRate = UserConnection.DBTypeConverter.DBValueToDecimal(dataReader[4]) / 100;
				decimal discountAmount = productPriceMasterRecordCurrency * quantity * discountRate;
				decimal amount = productPriceMasterRecordCurrency * quantity - discountAmount;
						if (!dataReader.IsDBNull(10)) {
							taxAmount = amount * UserConnection.DBTypeConverter.DBValueToDecimal(dataReader[10]) / 100;
						}
				bool priceWithTaxes = Core.Configuration.SysSettings.GetValue(UserConnection, "PriceWithTaxes", false);
				var totalAmount = amount;
				if (!priceWithTaxes) {
					totalAmount += taxAmount;
				}
						UpdateProductEntry(UserConnection, productDetailSchemaName, UserConnection.DBTypeConverter.DBValueToGuid(dataReader[9]), productPriceMasterRecordCurrency, amount, totalAmount, discountAmount, taxAmount, (decimal)masterRecordCurrencyRate, masterDivision);
				totalMasterAmount += totalAmount;
				totalQuantity += quantity;
					}
				}
			}
			if (totalQuantity > 0) {
				UpdateMasterSchemaRecordAmount(masterSchemaName, masterRecordId, totalMasterAmount,
					Division(totalMasterAmount, masterRecordCurrencyRate, masterDivision));
			}
		}

		#endregion

	}
}

