using System;
using System.Collections.Generic;
using System.Linq;
using BPMSoft.Common;
using BPMSoft.Core;
using BPMSoft.Core.DB;
using BPMSoft.Core.Entities;
using BPMSoft.Core.Factories;

namespace BPMSoft.Configuration.Passport
{
	public class OrderAmountHelper
	{
		#region Class: UpdateAmountsInfo

		protected class UpdateAmountsInfo
		{
			public decimal OrderProductTotalAmount { get; set; }

			public decimal OrderProductQuantity { get; set; }

			public decimal OrderProductBaseQuantity { get; set; }

			public Guid ProductId { get; set; }

			public String ProductName { get; set; }

			public Guid OrderId { get; set; }
			public decimal OrderAmount { get; set; }

			public CurrencyInfo OrderProductCurrencyInfo { get; set; }

			public decimal OrderCurrencyDivision { get; set; }

			public decimal OrderCurrencyRate { get; set; }

			public Guid OrderProductId { get; set; }

			public Guid OrderProductUnitId { get; set; }

			public Guid PriceListId { get; set; }

			public decimal OrderProductPrice { get; set; }

			public decimal OrderProductDiscountPercent { get; set; }

			public decimal OrderProductDiscountAmount { get; set; }

			public Guid OrderProductTaxId { get; set; }

			public decimal OrderProductDiscountTax { get; set; }

			public decimal OrderProductTaxAmount { get; set; }

			public Guid SupplyPaymentElementId { get; set; }

			public decimal OrderProductToPrimaryFactor => OrderProductCurrencyInfo.ToPrimaryFactor;

			public decimal OrderToPrimaryFactor => GetToPrimaryFactor(OrderCurrencyDivision, OrderCurrencyRate);
		}

		#endregion

		#region Class: InvoiceAmountByOrderInfo

		protected class InvoiceAmountByOrderInfo
		{
			public CurrencyInfo OrderCurrencyInfo { get; set; }

			public decimal InvoiceAmount { get; set; }

			public decimal PrimaryAmount { get; set; }

			public int ProductsCount { get; set; }

			public Guid InvoiceId { get; set; }
		}

		#endregion

		#region Class: CurrencyInfo

		protected class CurrencyInfo
		{
			public Guid Id { get; set; }

			public decimal Rate { get; set; }

			public decimal Division { get; set; }

			public decimal ToPrimaryFactor => GetToPrimaryFactor(Division, Rate);

			public decimal FromPrimaryFactor => GetToPrimaryFactor(Rate, Division);
		}

		#endregion

		#region Class: OrderFinanceInfo

		protected class OrderFinanceInfo
		{
			public Guid OrderId { get; set; }
			
			public CurrencyInfo CurrencyInfo { get; set; }

			public decimal Amount { get; set; }

			public decimal PrimaryAmount { get; set; }

			public decimal PaymentAmount { get; set; }
		}

		#endregion

		#region Class: SupplyPaymentFactAmountByInvoiceInfo

		protected class SupplyPaymentFactAmountByInvoiceInfo
		{
			public CurrencyInfo OrderCurrencyInfo { get; set; }

			public decimal PrimaryPaymentAmount { get; set; }

			public Guid InvoicePaymentStatusId { get; set; }

			public Entity SupplyPaymentElement { get; set; }

			public Guid InvoiceId { get; set; }

			public DateTime DueDate { get; set; }

			public Guid CurrencyId { get; set; }

			public decimal CurrencyRate { get; set; }

			public int CurrencyDivision { get; set; }

			public decimal PaymentAmount { get; set; }
		}

		#endregion

		#region Class: SupplyPaymentInfo

		protected class SupplyPaymentInfo
		{
			public Guid SupplyPaymentId { get; set; }

			public int ProductsCount { get; set; }

			public decimal Percentage { get; set; }

			public decimal Amount { get; set; }

			public decimal ProductsAmount { get; set; }

			public decimal PrimaryAmountFact { get; set; }
		}

		#endregion

		#region Class: OrderPaymentStatusByInvoice

		protected class OrderPaymentAmountCalcInfo
		{
			public Guid OrderId { get; set; }

			public int PaidInvoiceNotLinkedWithSPECount { get; set; }

			public CurrencyInfo CurrencyInfo { get; set; }

			public decimal PaymentAmountBySPE { get; set; }

			public decimal PaymentAmountByInvoice { get; set; }

			public bool IsAmountCalculatedByInvoices {
				get { return PaidInvoiceNotLinkedWithSPECount > 0; }
			}
		}

		#endregion

		#region Class: InvoicePaymentAmountInfo

		public class InvoicePaymentAmountInfo
		{
			public decimal PaymentAmount { get; set; }

			public Guid CurrencyId { get; set; }

			public DateTime DueDate { get; set; }

			public decimal CurrencyRate { get; set; }

			public int CurrencyDivision { get; set; }
		}

		#endregion

		#region Constants: Private

		private const string UseCrossRateForOrderPaymentAmountCode = "UseCrossRateForOrderPaymentAmount";

		#endregion

		#region Constructors: Public

		public OrderAmountHelper(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Public

		public UserConnection UserConnection { get; private set; }

		public CurrencyConverter CurrencyConverter => ClassFactory
			.Get<CurrencyConverter>(new ConstructorArgument("currenciesRateStorage", CurrencyRateStorage));

		public CurrencyRateStorage CurrencyRateStorage => ClassFactory
			.Get<CurrencyRateStorage>(new ConstructorArgument("userConnection", UserConnection));
		
		public bool IsUseCrossRate => UserConnection.GetIsFeatureEnabled(UseCrossRateForOrderPaymentAmountCode);

		#endregion

		#region Methods: Private

		private void UpdateOrderPaymentAmount(Guid orderId, CurrencyInfo currrencyInfo, decimal primaryPaymentAmount) {
			Entity record = GetOrderEntity(orderId);
			var primaryPaymentAmountColumnName = "PrimaryPaymentAmount";
			var amountPrecision = GetColumnPrecision(record, primaryPaymentAmountColumnName);
			var primaryPaymentAmountByRecord = record.GetTypedColumnValue<decimal>(primaryPaymentAmountColumnName);
			var currentAmount = GetRoundedValue(primaryPaymentAmountByRecord, amountPrecision);
			var roundedPrimaryPaymentAmount = GetRoundedValue(primaryPaymentAmount, amountPrecision);
			if (currentAmount == roundedPrimaryPaymentAmount) {
				return;
			}
			var invertedFactor = GetToPrimaryFactor(currrencyInfo.Rate, currrencyInfo.Division);
			var paymentAmount = primaryPaymentAmount * invertedFactor;
			record.SetColumnValue("PaymentAmount", paymentAmount);
			record.SetColumnValue("PrimaryPaymentAmount", primaryPaymentAmount);
			record.Save(false);
		}

		private Entity GetOrderEntity(Guid orderId) {
			var record = UserConnection.EntitySchemaManager.GetInstanceByName("Order").CreateEntity(UserConnection);
			if (!record.FetchFromDB(orderId)) {
				throw new ArgumentOutOfRangeException("orderId");
			}
			return record;
		}

		private void UpdateOrderPaymentAmountUseCrossRate(Guid orderId, CurrencyInfo currrencyInfo, 
				decimal paymentAmount) {
			Entity orderEntity = GetOrderEntity(orderId);
			var primaryPaymentAmountColumnName = "PrimaryPaymentAmount";
			var amountPrecision = GetColumnPrecision(orderEntity, primaryPaymentAmountColumnName);
			Guid primaryCurrencyId = GetPrimaryCurrencyId();
			var primaryPaymentAmount = GetOrderPrimaryPaymentAmountWithCrossRate(paymentAmount,
				currrencyInfo, primaryCurrencyId, amountPrecision);
			orderEntity.SetColumnValue("PaymentAmount", paymentAmount);
			orderEntity.SetColumnValue(primaryPaymentAmountColumnName, primaryPaymentAmount);
			orderEntity.Save(false);
		}

		private decimal GetRoundValueByColumnPrecision(Entity entity, decimal amount, string columnName) {
			var precision = GetColumnPrecision(entity, columnName);
			return GetRoundedValue(amount, precision);
		}

		private static int GetColumnPrecision(Entity entity, string columnName) {
			var precision = 2;
			EntitySchemaColumn entitySchemaColumn = entity.Schema.Columns.FindByName(columnName);
			if (entitySchemaColumn == null) {
				return precision;
			}
			var columnDataValueType = entitySchemaColumn.DataValueType as FloatDataValueType;
			if (columnDataValueType != null) {
				precision = columnDataValueType.Precision;
			}
			return precision;
		}

		private decimal GetOrderPrimaryPaymentAmountWithCrossRate(decimal paymentAmount, CurrencyInfo currencyInfo,
				Guid targetCurrencyId, int amountPrecision) {
			CurrencyRateInfo currentCurrencyRateInfo = GetCurrencyRateInfo(currencyInfo);
			var result = CurrencyConverter
				.GetConvertedAmountToCurrency(currentCurrencyRateInfo, targetCurrencyId,
					paymentAmount, UserConnection.CurrentUser.GetCurrentDateTime());
			return GetRoundedValue(result, amountPrecision);
		}

		private Guid GetPrimaryCurrencyId() {
			return (Guid)Core.Configuration.SysSettings.GetValue(UserConnection, "PrimaryCurrency");
		}

		private decimal GetOrderPaymentAmountWithCrossRateByInvoice(IEnumerable<InvoicePaymentAmountInfo> paymentAmountsInfo, 
				CurrencyInfo currencyInfo) {
			decimal sumPaymentAmount = 0;
			CurrencyRateInfo targetCurrencyRateInfo = GetCurrencyRateInfo(currencyInfo);
			foreach (InvoicePaymentAmountInfo paymentAmountInfo in paymentAmountsInfo) {
				var currentCurrencyRateInfo = new CurrencyRateInfo() {
					CurrencyId = paymentAmountInfo.CurrencyId,
					Rate = paymentAmountInfo.CurrencyRate,
					Division = paymentAmountInfo.CurrencyDivision
				};
				sumPaymentAmount += CurrencyConverter
					.GetConvertedAmountToCurrency(currentCurrencyRateInfo, targetCurrencyRateInfo,
						paymentAmountInfo.PaymentAmount);
			}
			return sumPaymentAmount;
		}

		private static CurrencyRateInfo GetCurrencyRateInfo(CurrencyInfo currencyInfo) {
			return new CurrencyRateInfo() {
				CurrencyId = currencyInfo.Id,
				Division = (int)currencyInfo.Division,
				Rate = currencyInfo.Rate
			};
		}

		private decimal GetRoundedValue(decimal amount, int amountPrecision) {
			return Math.Round(amount, amountPrecision);
		}

		private IEnumerable<InvoicePaymentAmountInfo> GetInvoicePaymentAmountInfo(Guid orderId) {
			var invoicePaymentAmountsInfo = new List<InvoicePaymentAmountInfo>();
			Guid[] invoicesStatusToCalcOrderSum = GetInvoicesStatusToCalcOrderSum();
			var speWithInvoiceSelect = new Select(UserConnection)
					.Column("Id")
				.From("SupplyPaymentElement").As("spe").WithHints(Hints.NoLock)
				.Where("spe", "InvoiceId").IsEqual("i", "Id")
					.And("i", "OrderId").IsEqual(Column.Parameter(orderId));
			var paymentAmountByInvoicesSelect = new Select(UserConnection)
					.Column(Func.Sum("i", "PaymentAmount")).As("SumPaymentAmount")
					.Column("i", "CurrencyId").As("CurrencyId")
					.Column("i", "CurrencyRate").As("CurrencyRate")
					.Column("c", "Division").As("CurrencyDivision")
				.From("Invoice").As("i")
				.InnerJoin("Currency").As("c").On("c", "Id").IsEqual("i", "CurrencyId")
				.Where("i", "OrderId").IsEqual(Column.Parameter(orderId))
					.And("i", "PaymentStatusId").In(Column.Parameters(invoicesStatusToCalcOrderSum))
					.And().Not().Exists(speWithInvoiceSelect)
				.GroupBy("i", "CurrencyId")
				.GroupBy("i", "CurrencyRate")
				.GroupBy("c", "Division") as Select;
			paymentAmountByInvoicesSelect.ExecuteReader(reader => {
				var result = new InvoicePaymentAmountInfo() {
					PaymentAmount = reader.GetColumnValue<decimal>("SumPaymentAmount"),
					CurrencyId = reader.GetColumnValue<Guid>("CurrencyId"),
					CurrencyRate = reader.GetColumnValue<decimal>("CurrencyRate"),
					CurrencyDivision = reader.GetColumnValue<int>("CurrencyDivision")
				};
				invoicePaymentAmountsInfo.Add(result);
			});
			return invoicePaymentAmountsInfo;
		}

		private static Guid[] GetInvoicesStatusToCalcOrderSum() {
			return new[] {
				PassportConstants.InvoicePaymentStatusPaid,
				PassportConstants.InvoicePaymentStatusPartiallyPaid
			};
		}

		private static decimal GetToPrimaryFactor(decimal currencyDivision, decimal currencyRate) {
			return currencyRate == 0 ? 0 : currencyDivision / currencyRate;
		}

		private List<Guid> GetPaymentsWithoutProductsInOrder(Guid orderId, Guid elementTypeId) {
			var esq = GetSupplyPaymentElementEsq(orderId);
			esq.Filters.Add(esq.CreateNotExistsFilter("[SupplyPaymentProduct:SupplyPaymentElement].Id"));
			var valuesFilter = new EntitySchemaQueryFilterCollection(esq, LogicalOperationStrict.Or) {
				esq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "Percentage", 0),
				esq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "AmountPlan", 0)
			};
			esq.Filters.Add(valuesFilter);
			var elementTypeFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Type", elementTypeId);
			esq.Filters.Add(elementTypeFilter);
			var idColumn = esq.AddColumn(esq.RootSchema.GetPrimaryColumnName());
			EntityCollection entityCollection = esq.GetEntityCollection(UserConnection);
			return entityCollection.Select(entity => entity.GetTypedColumnValue<Guid>(idColumn.Name)).ToList();
		}

		private QueryFunction GetSupplyPaymentProductNotNullColumn(string columnName) {
			var query = (Select)(new Select(UserConnection)
				.Column("spp", columnName)
				.From("SupplyPaymentProduct").As("spp").WithHints(Hints.NoLock)
				.Where("Id").IsEqual(Column.SourceColumn("InvoiceProduct", "SupplyPaymentProductId")));
			var expression = Func.IsNull(Column.SubSelect(query), Column.Const(0));
			return expression;
		}

		private OrderPaymentAmountCalcInfo GetOrderPaymentAmountCalcInfoByInvoiceUseCrossRate(Guid invoiceId) {
			OrderFinanceInfo orderInfo = GetOrderInfoByInvoice(invoiceId);
			if (orderInfo.OrderId.IsEmpty()) {
				return null;
			}
			CurrencyInfo currencyInfo = orderInfo.CurrencyInfo;
			IEnumerable<InvoicePaymentAmountInfo> paymentAmountsInfo = GetInvoicePaymentAmountInfo(orderInfo.OrderId);
			int paidInvoiceNotLinkedWithSPECount = paymentAmountsInfo.Count();
			decimal paymentAmountByInvoice = GetOrderPaymentAmountWithCrossRateByInvoice(paymentAmountsInfo, currencyInfo);
			return new OrderPaymentAmountCalcInfo {
				OrderId = orderInfo.OrderId,
				PaidInvoiceNotLinkedWithSPECount = paidInvoiceNotLinkedWithSPECount,
				CurrencyInfo = new CurrencyInfo {
					Id = currencyInfo.Id,
					Rate = currencyInfo.Rate,
					Division = currencyInfo.Division
				},
				PaymentAmountByInvoice = paymentAmountByInvoice
			};
		}

		private OrderFinanceInfo GetOrderInfoByInvoice(Guid invoiceId) {
			OrderFinanceInfo orderFinanceInfo = new OrderFinanceInfo();
			var select = new Select(UserConnection)
					.Column("o", "Id").As("OrderId")
					.Column("o", "CurrencyId").As("CurrencyId")
					.Column("o", "CurrencyRate").As("CurrencyRate")
					.Column("c", "Division").As("CurrencyDivision")
				.From("Invoice").As("i")
					.InnerJoin("Order").As("o").On("o", "Id").IsEqual("i", "OrderId")
					.InnerJoin("Currency").As("c").On("c", "Id").IsEqual("o", "CurrencyId")
				.Where("i", "Id").IsEqual(Column.Parameter(invoiceId)) as Select;
			select.ExecuteReader(reader => {
				orderFinanceInfo.OrderId = reader.GetColumnValue<Guid>("OrderId");
				orderFinanceInfo.CurrencyInfo = new CurrencyInfo {
					Id = reader.GetColumnValue<Guid>("CurrencyId"),
					Rate = reader.GetColumnValue<decimal>("CurrencyRate"),
					Division = reader.GetColumnValue<int>("CurrencyDivision")
				};
			});
			return orderFinanceInfo;
		}

		private void UpdateOrderPaymentAmountOnInvoiceChangedUseCrossRate(Guid invoiceId) {
			OrderPaymentAmountCalcInfo orderInfo = GetOrderPaymentAmountCalcInfoByInvoiceUseCrossRate(invoiceId);
			if ((orderInfo == null) || !orderInfo.IsAmountCalculatedByInvoices) {
				return;
			}
			UpdateOrderPaymentAmountUseCrossRate(orderInfo.OrderId, orderInfo.CurrencyInfo,
				orderInfo.PaymentAmountByInvoice);
		}

		private void UpdateOrderPaymentAmountOnSPEChangedUseCrossRate(Guid supplyPaymentElementId) {
			OrderFinanceInfo orderPaymentInfo = GetOrderPaymentInfoBySPE(supplyPaymentElementId);
			UpdateOrderPaymentAmountUseCrossRate(orderPaymentInfo.OrderId, orderPaymentInfo.CurrencyInfo,
					orderPaymentInfo.PaymentAmount);
		}

		private OrderFinanceInfo GetOrderPaymentInfoBySPE(Guid supplyPaymentElementId) {
			var orderFinanceInfo = new OrderFinanceInfo();
			var paymentAmountBySPE = new Select(UserConnection)
					.Column(Func.Sum("summSpe", "AmountFact")).As("SPEPaymentAmountSum")
				.From("SupplyPaymentElement").As("summSpe").WithHints(Hints.NoLock)
				.Where("summSpe", "OrderId").IsEqual("Order", "Id")
					.And("summSpe", "TypeId").IsEqual(Column.Parameter(PassportConstants.SupplyPaymentTypePayment));
			var select = new Select(UserConnection)
					.Column("Order", "Id").As("OrderId")
					.Column(Column.SubSelect(paymentAmountBySPE)).As("PaymentAmountBySPE")
					.Column("Order", "CurrencyId").As("CurrencyId")
					.Column("Order", "CurrencyRate").As("CurrencyRate")
					.Column("OrderCurrnecy", "Division").As("CurrencyDivision")
				.From("Order").As("Order").WithHints(Hints.NoLock)
					.LeftOuterJoin("Currency").As("OrderCurrnecy").WithHints(Hints.NoLock)
						.On("OrderCurrnecy", "Id").IsEqual("Order", "CurrencyId")
					.InnerJoin("SupplyPaymentElement").As("currentStep").WithHints(Hints.NoLock)
						.On("Order", "Id").IsEqual("currentStep", "OrderId")
				.Where("currentStep", "Id").IsEqual(Column.Parameter(supplyPaymentElementId)) as Select;
			select.ExecuteReader(reader => {
				orderFinanceInfo.OrderId = reader.GetColumnValue<Guid>("OrderId");
				orderFinanceInfo.PaymentAmount = reader.GetColumnValue<decimal>("PaymentAmountBySPE");
				orderFinanceInfo.CurrencyInfo = new CurrencyInfo() {
					Id = reader.GetColumnValue<Guid>("CurrencyId"),
					Rate = reader.GetColumnValue<decimal>("CurrencyRate"),
					Division = reader.GetColumnValue<decimal>("CurrencyDivision")
				};
			});
			return orderFinanceInfo;
		}

		#endregion

		#region Methods: Protected

		protected QueryColumnExpression GetGuidColumnExpression(Guid value) {
			return (value == Guid.Empty) ? Column.Const(null) : Column.Parameter(value);
		}

		protected List<SupplyPaymentInfo> GetSPEWithProductsCountInOrder(Guid orderId, Guid? supplyPaymentElementId = null) {
			var esq = GetSupplyPaymentElementEsq(orderId);
			if (supplyPaymentElementId != null) {
				var primaryColumnFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal,
					esq.RootSchema.GetPrimaryColumnName(), supplyPaymentElementId);
				esq.Filters.Add(primaryColumnFilter);
			}
			var productCountColumn = esq.AddColumn(esq.CreateAggregationFunction(AggregationTypeStrict.Count,
				"[SupplyPaymentProduct:SupplyPaymentElement].Id"));
			var productAmountColumn = esq.AddColumn(esq.CreateAggregationFunction(AggregationTypeStrict.Sum,
				"[SupplyPaymentProduct:SupplyPaymentElement].Amount"));
			var idColumn = esq.AddColumn(esq.RootSchema.GetPrimaryColumnName());
			var amountColumn = esq.AddColumn("AmountPlan");
			var primAmountFactColumn = esq.AddColumn("PrimaryAmountFact");
			var percentageColumn = esq.AddColumn("Percentage");
			EntityCollection entityCollection = esq.GetEntityCollection(UserConnection);
			return entityCollection.Select(entity => new SupplyPaymentInfo {
				SupplyPaymentId = entity.GetTypedColumnValue<Guid>(idColumn.Name),
				ProductsCount = entity.GetTypedColumnValue<int>(productCountColumn.Name),
				Percentage = entity.GetTypedColumnValue<decimal>(percentageColumn.Name),
				Amount = entity.GetTypedColumnValue<decimal>(amountColumn.Name),
				ProductsAmount = entity.GetTypedColumnValue<decimal>(productAmountColumn.Name),
				PrimaryAmountFact = entity.GetTypedColumnValue<decimal>(primAmountFactColumn.Name)
			}).ToList();
		}

		protected void ExecuteInTransaction(Action<DBExecutor> operation) {
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				try {
					dbExecutor.StartTransaction();
					operation(dbExecutor);
					dbExecutor.CommitTransaction();
				} catch {
					dbExecutor.RollbackTransaction();
					throw;
				}
			}
		}

		protected bool HasPriceList {
			get {
				var schema = UserConnection.EntitySchemaManager.GetInstanceByName("OrderProduct");
				var schemaColumn = schema.Columns.FindByName("PriceList");
				return (schemaColumn != null);
			}
		}

		protected UpdateAmountsInfo GetUpdateAmountsParamsFromOrderProduct(Guid orderProductId, Guid supplyPaymentElementId) {
			var infoEsq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "OrderProduct");
			var nameColumn = infoEsq.AddColumn("Name");
			var totalAmountColumn = infoEsq.AddColumn("TotalAmount");
			var quantityColumn = infoEsq.AddColumn("Quantity");
			var baseQuantityColumn = infoEsq.AddColumn("BaseQuantity");
			var productIdColumn = infoEsq.AddColumn("Product");
			var currencyIdColumn = infoEsq.AddColumn("Currency");
			var currencyDivisionColumn = infoEsq.AddColumn("Currency.Division");
			var currencyRateColumn = infoEsq.AddColumn("CurrencyRate");
			var orderCurrencyDivisionColumn = infoEsq.AddColumn("Order.Currency.Division");
			var orderCurrencyRateColumn = infoEsq.AddColumn("Order.CurrencyRate");
			var orderIdColumn = infoEsq.AddColumn("Order.Id");
			var orderAmountColumn = infoEsq.AddColumn("Order.Amount");
			var priceColumn = infoEsq.AddColumn("Price");
			var discountPercentColumn = infoEsq.AddColumn("DiscountPercent");
			var discountAmountColumn = infoEsq.AddColumn("DiscountAmount");
			var taxIdColumn = infoEsq.AddColumn("Tax.Id");
			var discountTaxColumn = infoEsq.AddColumn("DiscountTax");
			var taxAmountColumn = infoEsq.AddColumn("TaxAmount");
			var unitIdColumn = infoEsq.AddColumn("Unit");
			if (HasPriceList) {
				infoEsq.AddColumn("PriceList");
			}
			var row = infoEsq.GetEntity(UserConnection, orderProductId);
			if (row == null) {
				return null;
			}
			var updateAmountsParams = new UpdateAmountsInfo {
				OrderProductId = orderProductId,
				ProductName = row.GetTypedColumnValue<string>(nameColumn.Name),
				OrderProductTotalAmount = row.GetTypedColumnValue<decimal>(totalAmountColumn.ValueQueryAlias),
				OrderProductQuantity = row.GetTypedColumnValue<decimal>(quantityColumn.ValueQueryAlias),
				OrderProductBaseQuantity = row.GetTypedColumnValue<decimal>(baseQuantityColumn.ValueQueryAlias),
				OrderProductPrice = row.GetTypedColumnValue<decimal>(priceColumn.ValueQueryAlias),
				OrderProductDiscountPercent = row.GetTypedColumnValue<decimal>(discountPercentColumn.ValueQueryAlias),
				OrderProductDiscountAmount = row.GetTypedColumnValue<decimal>(discountAmountColumn.ValueQueryAlias),
				OrderProductTaxId = row.GetTypedColumnValue<Guid>(taxIdColumn.Name),
				OrderProductDiscountTax = row.GetTypedColumnValue<decimal>(discountTaxColumn.ValueQueryAlias),
				OrderProductTaxAmount = row.GetTypedColumnValue<decimal>(taxAmountColumn.ValueQueryAlias),
				OrderProductUnitId = row.GetTypedColumnValue<Guid>(unitIdColumn.ValueQueryAlias),
				OrderProductCurrencyInfo = new CurrencyInfo {
					Id = row.GetTypedColumnValue<Guid>(currencyIdColumn.ValueQueryAlias),
					Division = row.GetTypedColumnValue<decimal>(currencyDivisionColumn.Name),
					Rate = row.GetTypedColumnValue<decimal>(currencyRateColumn.Name)
				},
				ProductId = row.GetTypedColumnValue<Guid>(productIdColumn.ValueQueryAlias),
				OrderCurrencyDivision = row.GetTypedColumnValue<decimal>(orderCurrencyDivisionColumn.Name),
				OrderCurrencyRate = row.GetTypedColumnValue<decimal>(orderCurrencyRateColumn.Name),
				OrderId = row.GetTypedColumnValue<Guid>(orderIdColumn.Name),
				OrderAmount = row.GetTypedColumnValue<decimal>(orderAmountColumn.Name),
				SupplyPaymentElementId = supplyPaymentElementId
			};
			if (HasPriceList) {
				updateAmountsParams.PriceListId = row.GetTypedColumnValue<Guid>("PriceListId");
			}
			return updateAmountsParams;
		}

		[Obsolete]
		protected Update UpdateOrder(Guid orderId) {
			Update update = new Update(UserConnection, "Order").WithHints(Hints.RowLock)
				.Set("Amount", new Select(UserConnection)
					.Column(Func.Sum("PrimaryTotalAmount") * Column.SourceColumn("Currency", "Division") /
							Column.SourceColumn("Order", "CurrencyRate"))
					.From("OrderProduct").WithHints(Hints.NoLock)
						.Join(JoinType.Inner, "Order").WithHints(Hints.NoLock)
							.On("Order", "Id").IsEqual("OrderProduct", "OrderId")
						.Join(JoinType.Inner, "Currency").WithHints(Hints.NoLock)
							.On("Currency", "Id").IsEqual("Order", "CurrencyId")
					.Where("OrderProduct", "OrderId")
						.IsEqual(Column.Parameter(orderId))
					.GroupBy("Currency", "Division")
					.GroupBy("Order", "CurrencyRate") as Select)
				.Set("PrimaryAmount", new Select(UserConnection)
					.Column(Func.Sum("PrimaryTotalAmount"))
					.From("OrderProduct").WithHints(Hints.NoLock)
					.Where("OrderProduct", "OrderId")
					.IsEqual(Column.Parameter(orderId)) as Select)
				.Where("Id").IsEqual(Column.Parameter(orderId)) as Update;
			return update;
		}

		/// <summary>
		/// Forms supply payment product amount update query.
		/// </summary>
		protected void UpdateSPProduct(Guid orderProductId, decimal totalAmount, decimal quantity, DBExecutor dbExecutor) {
			var amountExpression = quantity == 0
				? Column.Const(0)
				: (Column.Parameter(totalAmount) / Column.Parameter(quantity)) * Column.SourceColumn("Quantity");
			var update = (Update)(new Update(UserConnection, "SupplyPaymentProduct").WithHints(Hints.RowLock)
				.Set("Amount", amountExpression)
				.Where("ProductId").IsEqual(Column.Parameter(orderProductId)));
			update.Execute(dbExecutor);
		}

		/// <summary>
		/// Forms invoice products update query.
		/// </summary>
		protected virtual Update GetInvoiceProductUpdate(UpdateAmountsInfo updateAmountsParams) {
			var orderCurrencyFactor = updateAmountsParams.OrderProductCurrencyInfo.ToPrimaryFactor;
			if (orderCurrencyFactor == 0) {
				orderCurrencyFactor = GetToPrimaryFactor(updateAmountsParams.OrderCurrencyDivision, updateAmountsParams.OrderCurrencyRate);
			}
			var discountTaxDivider = 100m + updateAmountsParams.OrderProductDiscountTax;
			var productQuantityExpression = GetSupplyPaymentProductNotNullColumn("Quantity");
			var productAmountExpression = GetSupplyPaymentProductNotNullColumn("Amount");
			var taxAmountExpression = discountTaxDivider == 0
				? Column.Const(0)
				: productAmountExpression * Column.Parameter(updateAmountsParams.OrderProductDiscountTax) /
				  Column.Parameter(discountTaxDivider);
			var discountAmountExpression = productQuantityExpression * Column.Parameter(updateAmountsParams.OrderProductPrice) *
					Column.Parameter(updateAmountsParams.OrderProductDiscountPercent) /
					Column.Const(100m);
			Select invoiceCurrencyFactorQuery = GetInvoiceCurrencyFactorQuery("InvoiceProduct", "InvoiceId");
			var invCurrencyExpr = Column.SubSelect(invoiceCurrencyFactorQuery) *
				Column.Parameter(orderCurrencyFactor);
			Update update = (Update)(new Update(UserConnection, "InvoiceProduct").WithHints(Hints.RowLock)
				.Set("Name", Column.Parameter(updateAmountsParams.ProductName))
				.Set("ProductId", GetGuidColumnExpression(updateAmountsParams.ProductId))
				.Set("Quantity", productQuantityExpression)
				.Set("BaseQuantity", Column.Parameter(updateAmountsParams.OrderProductBaseQuantity))
				.Set("UnitId", GetGuidColumnExpression(updateAmountsParams.OrderProductUnitId))
				.Set("Price", Column.Parameter(updateAmountsParams.OrderProductPrice) * invCurrencyExpr)
				.Set("Amount", productQuantityExpression * Column.Parameter(updateAmountsParams.OrderProductPrice) * invCurrencyExpr)
				.Set("DiscountPercent", Column.Parameter(updateAmountsParams.OrderProductDiscountPercent))
				.Set("DiscountAmount", discountAmountExpression * invCurrencyExpr)
				.Set("TaxId", GetGuidColumnExpression(updateAmountsParams.OrderProductTaxId))
				.Set("DiscountTax", Column.Parameter(updateAmountsParams.OrderProductDiscountTax) * invCurrencyExpr)
				.Set("TaxAmount", taxAmountExpression * invCurrencyExpr)
				.Set("TotalAmount", productAmountExpression * invCurrencyExpr)
				.Set("PrimaryTotalAmount", productAmountExpression * Column.Parameter(orderCurrencyFactor))
				.Set("PrimaryTaxAmount", taxAmountExpression * Column.Parameter(orderCurrencyFactor))
				.Set("PrimaryPrice", Column.Parameter(updateAmountsParams.OrderProductPrice) * Column.Parameter(orderCurrencyFactor))
				.Set("PrimaryAmount",
					productQuantityExpression * Column.Parameter(updateAmountsParams.OrderProductPrice) * Column.Parameter(orderCurrencyFactor))
				.Set("PrimaryDiscountAmount", discountAmountExpression * Column.Parameter(orderCurrencyFactor))
				.Where().Exists(
					new Select(UserConnection)
						.Column(Column.Const(1))
						.From("SupplyPaymentProduct").WithHints(Hints.NoLock)
						.Where("SupplyPaymentProduct", "ProductId").IsEqual(Column.Parameter(updateAmountsParams.OrderProductId))
						.And("SupplyPaymentProduct", "Id").IsEqual("InvoiceProduct", "SupplyPaymentProductId") as Select));
			if (HasPriceList) {
				update = update.Set("PriceListId", Column.Parameter(updateAmountsParams.PriceListId));
			}
			return update;
		}

		protected Select GetInvoiceCurrencyFactorQuery(string sourceAlias, string sourceColumn) {
			var invoiceCurrencyFactorQuery = (Select)(new Select(UserConnection)
				.Column(Column.SourceColumn("inv", "CurrencyRate") / Column.SourceColumn("ic", "Division")).From("Invoice")
				.As("inv").WithHints(Hints.NoLock).InnerJoin("Currency").As("ic").On("ic", "Id").IsEqual("inv", "CurrencyId")
				.Where("inv", "Id").IsEqual(Column.SourceColumn(sourceAlias, sourceColumn)));
			return invoiceCurrencyFactorQuery;
		}

		[Obsolete]
		protected Update GetInvoiceAmountUpdateByProduct(CurrencyInfo currencyInfo, Guid orderProductId,
				Guid supplyPaymentElementId) {
			var sppSelect = new Select(UserConnection)
				.Column("SupplyPaymentProduct", "Id")
				.From("SupplyPaymentProduct").WithHints(Hints.NoLock)
					.InnerJoin("SupplyPaymentElement").WithHints(Hints.NoLock)
						.On("SupplyPaymentElementId").IsEqual("SupplyPaymentElement", "Id")
					.Where("SupplyPaymentProduct", "ProductId").IsEqual(Column.Parameter(orderProductId))
				.And("SupplyPaymentElement", "InvoiceId").IsEqual("Invoice", "Id");
			if (supplyPaymentElementId != Guid.Empty) {
				sppSelect = sppSelect.And("SupplyPaymentElement", "Id").IsEqual(Column.Parameter(supplyPaymentElementId));
			}
			Query update = GetInvoiceAmountUpdate(currencyInfo).Where().Exists(sppSelect);
			return (Update)update;
		}

		[Obsolete]
		protected Update GetInvoiceAmountUpdateBySpeId(CurrencyInfo currencyInfo, Guid supplyPaymentelementId) {
			var update = GetInvoiceAmountUpdate(currencyInfo)
				.Where().Exists(
					new Select(UserConnection)
						.Column("SupplyPaymentElement", "Id")
						.From("SupplyPaymentElement").WithHints(Hints.NoLock)
						.Where("SupplyPaymentElement", "Id").IsEqual(Column.Parameter(supplyPaymentelementId))
						.And("SupplyPaymentElement", "InvoiceId").IsEqual("Invoice", "Id")
				);
			return (Update)update;
		}

		/// <summary>
		/// Returns invoice identifiers by order identifier.
		/// </summary>
		protected List<Guid> GetInvoiceIdsByOrderId(Guid orderId) {
			var select = (Select)new Select(UserConnection)
				.Column("InvoiceId")
				.From("SupplyPaymentElement")
				.WithHints(Hints.NoLock)
				.Where("OrderId").IsEqual(Column.Parameter(orderId));
			var invoiceIds = new List<Guid>();
			select.ExecuteReader(reader => {
				Guid invoiceId = reader.GetColumnValue<Guid>("InvoiceId");
				if (invoiceId.IsNotEmpty()) {
					invoiceIds.Add(invoiceId);
				}
			});
			return invoiceIds;
		}

		/// <summary>
		/// Returns invoice identifier by supply payment element identifier.
		/// </summary>
		protected Guid GetInvoiceIdBySupplyPaymentElementId(Guid supplyPaymenElementId) {
			var select = (Select)new Select(UserConnection)
				.Column("InvoiceId")
				.From("SupplyPaymentElement")
				.WithHints(Hints.NoLock)
				.Where("Id").IsEqual(Column.Parameter(supplyPaymenElementId));
			return select.ExecuteScalar<Guid>();
		}

		/// <summary>
		/// Returns invoice update query.
		/// </summary>
		protected Update GetInvoiceUpdateQuery(CurrencyInfo currencyInfo, Guid invoiceId) {
			var update = GetInvoiceAmountUpdate(currencyInfo)
				.Where("Id").IsEqual(Column.Parameter(invoiceId));
			return update as Update;
		}

		/// <summary>
		/// Returns invoices update query.
		/// </summary>
		protected Update GetInvoicesUpdateQuery(CurrencyInfo currencyInfo, List<Guid> invoiceIds) {
			var queryParameters = invoiceIds.Select(item => new QueryParameter(item)).ToList();
			var update = GetInvoiceAmountUpdate(currencyInfo)
				.Where("Id").In(queryParameters);
			return update as Update;
		}

		/// <summary>
		/// Returns invoice amount and currency update query.
		/// </summary>
		protected virtual Update GetInvoiceAmountUpdate(CurrencyInfo currencyInfo) {
			var invoiceCurrencyFactorQuery = GetInvoiceCurrencyFactorQuery("Invoice", "Id");
			var update = new Update(UserConnection, "Invoice")
				.WithHints(Hints.RowLock)
				.Set("Amount",
					Func.Coalesce(GetInvoiceProductSelectByInvoice("TotalAmount"), 
						GetSupplyPaymentSelectByInvoice("AmountPlan") *
							Column.Parameter(currencyInfo.ToPrimaryFactor) * 
							Column.SubSelect(invoiceCurrencyFactorQuery),
						Column.Const(0)))
				.Set("PrimaryAmount",
					Func.Coalesce(GetInvoiceProductSelectByInvoice("PrimaryTotalAmount"),
						GetSupplyPaymentSelectByInvoice("PrimaryAmountPlan"),
						Column.Const(0)))
				.Set("PaymentAmount",
					Column.SourceColumn("PrimaryPaymentAmount") * Column.SubSelect(invoiceCurrencyFactorQuery));
			return update;
		}

		protected QueryColumnExpression GetInvoiceProductSelectByInvoice(string columnName) {
			var amountSelect = new Select(UserConnection)
				.Column(Func.Sum("ip", columnName))
				.From("InvoiceProduct").As("ip")
				.WithHints(Hints.NoLock)
				.Where("ip", "InvoiceId").IsEqual(Column.SourceColumn("Invoice", "Id"));
			return Column.SubSelect(amountSelect);
		}

		protected QueryColumnExpression GetSupplyPaymentSelectByInvoice(string columnName) {
			var amountSelect = new Select(UserConnection)
				.Column("spe", columnName)
				.From("SupplyPaymentElement").As("spe")
				.WithHints(Hints.NoLock)
				.Where("spe", "InvoiceId").IsEqual(Column.SourceColumn("Invoice", "Id"));
			return Column.SubSelect(amountSelect);
		}

		/// <summary>
		/// Returns need update contract by product flag.
		/// </summary>
		protected bool TryGetContractUpdateByProduct(Guid orderProductId, Guid productCurrencyId, decimal productCurrencyRate,
				out Update contractUpdate) {
			bool isNeedUpdate;
			contractUpdate = TryGetContractUpdate(productCurrencyId, productCurrencyRate, out isNeedUpdate);
			if (!isNeedUpdate) {
				contractUpdate = null;
				return false;
			}
			contractUpdate.Where()
				.Exists(
					new Select(UserConnection).Column(Column.Const(1))
						.From("SupplyPaymentProduct").WithHints(Hints.NoLock)
						.InnerJoin("SupplyPaymentElement").WithHints(Hints.NoLock)
						.On("SupplyPaymentElementId").IsEqual("SupplyPaymentElement", "Id")
						.Where("SupplyPaymentProduct", "ProductId").IsEqual(Column.Parameter(orderProductId))
						.And("SupplyPaymentElement", "ContractId").IsEqual("Contract", "Id") as Select);
			return true;
		}

		/// <summary>
		/// Returns need udpate contract by supply payment element flag.
		/// </summary>
		protected bool TryGetContractUpdateBySpeId(Guid supplyPaymentElementId, Guid productCurrencyId,
				decimal productCurrencyRate, out Update contractUpdate) {
			bool isNeedUpdate;
			contractUpdate = TryGetContractUpdate(productCurrencyId, productCurrencyRate, out isNeedUpdate);
			if (!isNeedUpdate) {
				contractUpdate = null;
				return false;
			}
			contractUpdate.Where()
				.Exists(
					new Select(UserConnection).Column(Column.Const(1))
						.From("SupplyPaymentElement").WithHints(Hints.NoLock)
							.Where("SupplyPaymentElement", "Id").IsEqual(Column.Parameter(supplyPaymentElementId))
						.And("SupplyPaymentElement", "ContractId").IsEqual("Contract", "Id") as Select);
			return true;
		}

		/// <summary>
		/// Forms contract update query
		/// </summary>
		protected Update TryGetContractUpdate(Guid productCurrencyId, decimal productCurrencyRate, out bool isNeedUpdate) {
			isNeedUpdate = false;
			var contractSchema = UserConnection.EntitySchemaManager.FindInstanceByName("Contract");
			if (contractSchema == null) {
				return null;
			}
			var update = new Update(UserConnection, "Contract").WithHints(Hints.RowLock);
			if (contractSchema.Columns.FindByName("Currency") != null) {
				update.Set("CurrencyId", GetGuidColumnExpression(productCurrencyId));
				isNeedUpdate = true;
			}
			if (contractSchema.Columns.FindByName("CurrencyRate") != null) {
				update.Set("CurrencyRate", Column.Parameter(productCurrencyRate));
				isNeedUpdate = true;
			}
			if (contractSchema.Columns.FindByName("Amount") != null) {
				update.Set("Amount",
					(Select)
					(new Select(UserConnection).Column(Func.Sum("AmountPlan"))
						.From("SupplyPaymentElement").WithHints(Hints.NoLock)
						.Where("ContractId")
						.IsEqual(Column.SourceColumn("Contract", "Id"))));
				isNeedUpdate = true;
			}
			if (contractSchema.Columns.FindByName("PrimaryAmount") != null) {
				update.Set("PrimaryAmount",
					(Select)
					(new Select(UserConnection).Column(Func.Sum("PrimaryAmountPlan"))
						.From("SupplyPaymentElement").WithHints(Hints.NoLock)
						.Where("ContractId")
						.IsEqual(Column.SourceColumn("Contract", "Id"))));
				isNeedUpdate = true;
			}
			return update;
		}

		protected Dictionary<string, object> SafeGetColumnValues(Entity entity, IEnumerable<string> columns) {
			var result = new Dictionary<string, object>();
			var columnNames = columns.ToList();
			bool needToFetchColumns = columnNames.Any(c => !entity.IsColumnValueLoaded(entity.Schema.Columns.GetByName(c)));
			if (needToFetchColumns) {
				if (!entity.FetchFromDB(entity.Schema.GetPrimaryColumnName(), entity.PrimaryColumnValue, columnNames)) {
					return null;
				}
			}
			foreach (var columnName in columnNames) {
				var column = entity.Schema.Columns.GetByName(columnName);
				result[columnName] = entity.GetColumnValue(column);
			}
			return result;
		}

		protected InvoiceAmountByOrderInfo GetInvoiceAmountInfo(Guid supplyPaymenElementId) {
			var speEsq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SupplyPaymentElement");
			var currencyColumn = speEsq.AddColumn("Order.Currency.Id");
			var currencyRateColumn = speEsq.AddColumn("Order.CurrencyRate");
			var currencyDivisionColumn = speEsq.AddColumn("Order.Currency.Division");
			var amountPlanColumn = speEsq.AddColumn("AmountPlan");
			var invoiceColumn = speEsq.AddColumn("Invoice.Id");
			var productCounFunc =
				speEsq.CreateAggregationFunction(AggregationTypeStrict.Count, "[SupplyPaymentProduct:SupplyPaymentElement].Id");
			var productCountColumn = speEsq.AddColumn(productCounFunc);
			var supplyPaymenrElement = speEsq.GetEntity(UserConnection, supplyPaymenElementId);
			var result = new InvoiceAmountByOrderInfo {
				InvoiceId = supplyPaymenrElement.GetTypedColumnValue<Guid>(invoiceColumn.Name),
				OrderCurrencyInfo = new CurrencyInfo {
					Id = supplyPaymenrElement.GetTypedColumnValue<Guid>(currencyColumn.Name),
					Rate = supplyPaymenrElement.GetTypedColumnValue<decimal>(currencyRateColumn.Name),
					Division = supplyPaymenrElement.GetTypedColumnValue<decimal>(currencyDivisionColumn.Name)
				},
				InvoiceAmount = supplyPaymenrElement.GetTypedColumnValue<decimal>(amountPlanColumn.Name),
				ProductsCount = supplyPaymenrElement.GetTypedColumnValue<int>(productCountColumn.Name)
			};
			result.PrimaryAmount = result.InvoiceAmount * result.OrderCurrencyInfo.ToPrimaryFactor;
			return result;
		}

		/// <summary>
		/// Updates invoice amount, related to <paremref name="supplyPaymentElementId"/>.
		/// </summary>
		/// <param name="supplyPaymentElementId"><see cref="SupplyPaymentElement"/> instance unique identifier.</param>
		/// <param name="useRestricts">Check invoice update conditions flag.</param>
		protected void UpdateInvoiceAmountBySPE(Guid supplyPaymentElementId, bool useRestricts = true) {
			InvoiceAmountByOrderInfo amountByOrderInfo = GetInvoiceAmountInfo(supplyPaymentElementId);
			if ((useRestricts && amountByOrderInfo.ProductsCount > 0) || amountByOrderInfo.InvoiceId.IsEmpty()) {
				return;
			}
			Update update = GetInvoiceUpdateQuery(amountByOrderInfo.OrderCurrencyInfo, amountByOrderInfo.InvoiceId);
			update.Execute();
		}

		protected List<Guid> GetSupplyPaymentIdsByOrderProductId(Guid orderProductId) {
			var result = new List<Guid>();
			var select = new Select(UserConnection)
				.Column("spe", "Id")
				.From("SupplyPaymentElement").As("spe").WithHints(Hints.NoLock)
				.Where().Exists(
					new Select(UserConnection)
						.Column("spp", "Id")
						.From("SupplyPaymentProduct").As("spp").WithHints(Hints.NoLock)
						.Where("spp", "SupplyPaymentElementId").IsEqual("spe", "Id")
						.And("spp", "ProductId").IsEqual(Column.Parameter(orderProductId))
				);
			using (var executor = UserConnection.EnsureDBConnection()) {
				using (var dataReader = ((Select)select).ExecuteReader(executor)) {
					while (dataReader.Read()) {
						if (!dataReader.IsDBNull(0)) {
							result.Add(dataReader.GetGuid(0));
						}
					}
				}
			}
			return result;
		}

		protected void UpdateSupplyPaymentElementAmount(Guid supplyPaymentElementId, Guid orderId,
				OrderFinanceInfo orderFinanceInfo, DBExecutor dbExecutor) {
			var contractSchema = UserConnection.EntitySchemaManager.FindInstanceByName("Contract");
			Guid invoiceId = GetInvoiceIdBySupplyPaymentElementId(supplyPaymentElementId);
			if (invoiceId.IsNotEmpty()) {
				GetInvoiceUpdateQuery(orderFinanceInfo.CurrencyInfo, invoiceId).Execute(dbExecutor);
			}
			if (contractSchema != null) {
				Update contractUpdate;
				if (TryGetContractUpdateBySpeId(supplyPaymentElementId, orderFinanceInfo.CurrencyInfo.Id,
					orderFinanceInfo.CurrencyInfo.Rate, out contractUpdate)) {
					contractUpdate.Execute(dbExecutor);
				}
			}
		}

		protected OrderFinanceInfo GetOrderFinanceInfo(Guid recordId, bool loadCurrencyInfo = true) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Order");
			EntitySchemaQueryColumn currencyColumn = null;
			EntitySchemaQueryColumn currencyRateColumn = null;
			EntitySchemaQueryColumn currencyDivisionColumn = null;
			if (loadCurrencyInfo) {
				currencyColumn = esq.AddColumn("Currency.Id");
				currencyRateColumn = esq.AddColumn("CurrencyRate");
				currencyDivisionColumn = esq.AddColumn("Currency.Division");
			}
			EntitySchemaQueryColumn amountColumn = esq.AddColumn("Amount");
			EntitySchemaQueryColumn primaryAmountColumn = esq.AddColumn("PrimaryAmount");
			var row = esq.GetEntity(UserConnection, recordId);
			return new OrderFinanceInfo {
				Amount = row.GetTypedColumnValue<decimal>(amountColumn.Name),
				PrimaryAmount = row.GetTypedColumnValue<decimal>(primaryAmountColumn.Name),
				CurrencyInfo = loadCurrencyInfo
					? new CurrencyInfo {
						Id = row.GetTypedColumnValue<Guid>(currencyColumn.Name),
						Rate = row.GetTypedColumnValue<decimal>(currencyRateColumn.Name),
						Division = row.GetTypedColumnValue<decimal>(currencyDivisionColumn.Name)
					}
					: null
			};
		}

		protected virtual void UpdateSupplyPaymentElementsPercentageAndAmount(Guid orderId, decimal orderAmount,
				decimal toPrimaryCurrencyFactor, Guid? supplyPaymentElementId = null) {
			var speInfos = GetSPEWithProductsCountInOrder(orderId, supplyPaymentElementId);
			var supplyPaymentElementSchema = UserConnection.EntitySchemaManager.GetInstanceByName("SupplyPaymentElement");
			foreach (SupplyPaymentInfo supplyPaymentInfo in speInfos) {
				var row = supplyPaymentElementSchema.CreateEntity(UserConnection);
				row.FetchFromDB(supplyPaymentInfo.SupplyPaymentId, false);
				if (supplyPaymentInfo.ProductsCount == 0) {
					var amountPlan = row.GetTypedColumnValue<decimal>("Percentage") * orderAmount / 100m;
					row.SetColumnValue("AmountPlan", amountPlan);
					row.SetColumnValue("PrimaryAmountPlan", amountPlan * toPrimaryCurrencyFactor);
				} else {
					row.SetColumnValue("AmountPlan", supplyPaymentInfo.ProductsAmount);
					row.SetColumnValue("PrimaryAmountPlan", supplyPaymentInfo.ProductsAmount * toPrimaryCurrencyFactor);
					var percentage = (orderAmount == 0) ? 0 : supplyPaymentInfo.ProductsAmount / orderAmount * 100m;
					row.SetColumnValue("Percentage", percentage);
				}
				decimal primAmountFact = row.GetTypedColumnValue<decimal>("PrimaryAmountFact");
				decimal newAmountFact = toPrimaryCurrencyFactor != 0 ? primAmountFact / toPrimaryCurrencyFactor : 0;
				row.SetColumnValue("AmountFact", newAmountFact);
				row.Save(false);
			}
		}

		protected EntitySchemaQuery GetSupplyPaymentElementEsq(Guid orderId) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SupplyPaymentElement");
			var orderFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Order", orderId);
			esq.Filters.Add(orderFilter);
			return esq;
		}

		protected UpdateAmountsInfo ProtectedUpdateAmounts(Guid orderProductId, Guid? supplyPaymentElementId = null,
				DBExecutor dbExecutor = null) {
			supplyPaymentElementId = supplyPaymentElementId ?? Guid.Empty;
			UpdateAmountsInfo updateInfo = GetUpdateAmountsParamsFromOrderProduct(orderProductId, supplyPaymentElementId.Value);
			Action<DBExecutor> updateOperations = executor => {
				if (supplyPaymentElementId.IsNullOrEmpty()) {
					UpdateSPProduct(updateInfo.OrderProductId, updateInfo.OrderProductTotalAmount,
						updateInfo.OrderProductQuantity, executor);
					GetInvoiceProductUpdate(updateInfo).Execute(executor);
					List<Guid> invoiceIds = GetInvoiceIdsByOrderId(updateInfo.OrderId);
					if (invoiceIds.Any()) {
						GetInvoicesUpdateQuery(updateInfo.OrderProductCurrencyInfo, invoiceIds).Execute(executor);
					}
				} else {
					GetInvoiceProductUpdate(updateInfo).Execute(executor);
					Guid invoiceId = GetInvoiceIdBySupplyPaymentElementId(supplyPaymentElementId.Value);
					if (invoiceId.IsNotEmpty()) {
						GetInvoiceUpdateQuery(updateInfo.OrderProductCurrencyInfo, invoiceId).Execute(executor);
					}
				}
				Update contractUpdate;
				if (TryGetContractUpdateByProduct(updateInfo.OrderProductId, updateInfo.OrderProductCurrencyInfo.Id,
					updateInfo.OrderProductCurrencyInfo.Rate, out contractUpdate)) {
					contractUpdate.Execute(executor);
				}
			};
			if (dbExecutor == null) {
				ExecuteInTransaction(updateOperations);
			} else {
				updateOperations(dbExecutor);
			}
			return updateInfo;
		}

		protected OrderPaymentAmountCalcInfo GetOrderPaymentAmountCalcInfoBySPE(Guid supplyPaymentElementId) {
			var orderSelect = GetOrderPaymentStatusSelect();
			orderSelect = (Select)orderSelect
				.InnerJoin("SupplyPaymentElement").As("currentStep").WithHints(Hints.NoLock)
				.On("Order", "Id").IsEqual("currentStep", "OrderId")
				.Where("currentStep", "Id").IsEqual(Column.Parameter(supplyPaymentElementId));
			OrderPaymentAmountCalcInfo orderInfo = GetOrderPaymentAmountCalcInfo(orderSelect);
			return orderInfo;
		}

		protected OrderPaymentAmountCalcInfo GetOrderPaymentAmountCalcInfoByInvoice(Guid invoiceId) {
			var orderSelect = GetOrderPaymentStatusSelect();
			orderSelect = (Select)orderSelect
					.InnerJoin("Invoice").As("currentInvoice").WithHints(Hints.NoLock)
						.On("Order", "Id").IsEqual("currentInvoice", "OrderId")
				.Where("currentInvoice", "Id").IsEqual(Column.Parameter(invoiceId));
			OrderPaymentAmountCalcInfo orderInfo = GetOrderPaymentAmountCalcInfo(orderSelect);
			return orderInfo;
		}

		protected OrderPaymentAmountCalcInfo GetOrderPaymentAmountCalcInfoByOrderId(Guid orderId) {
			var orderSelect = GetOrderPaymentStatusSelect();
			orderSelect = (Select)orderSelect
				.Where("Order", "Id").IsEqual(Column.Parameter(orderId));
			OrderPaymentAmountCalcInfo orderInfo = GetOrderPaymentAmountCalcInfo(orderSelect);
			return orderInfo;
		}

		protected OrderPaymentAmountCalcInfo GetOrderPaymentAmountCalcInfo(Select orderPaymentStatusSelect) {
			OrderPaymentAmountCalcInfo result = null;
			using (var executor = UserConnection.EnsureDBConnection()) {
				using (var reader = orderPaymentStatusSelect.ExecuteReader(executor)) {
					if (reader.Read() && !reader.IsDBNull(reader.GetOrdinal("OrderId"))) {
						result = new OrderPaymentAmountCalcInfo {
							OrderId = reader.GetColumnValue<Guid>("OrderId"),
							PaidInvoiceNotLinkedWithSPECount = reader.GetColumnValue<int>("InvoicesWithoutSpe"),
							CurrencyInfo = new CurrencyInfo {
								Id = reader.GetColumnValue<Guid>("Order_CurrencyId"),
								Rate = reader.GetColumnValue<decimal>("Order_CurrencyRate"),
								Division = reader.GetColumnValue<decimal>("Order_Currency_Division")
							},
							PaymentAmountBySPE = reader.GetColumnValue<decimal>("PaymentAmountBySPE"),
							PaymentAmountByInvoice = reader.GetColumnValue<decimal>("PaymentAmountByInvoice")
						};
					}
				}
			}
			return result;
		}

		protected Select GetOrderPaymentStatusSelect() {
			var invoicesStatusToCalcOrderSum = GetInvoicesStatusToCalcOrderSum();
			var speWithInvoiceSelect = new Select(UserConnection)
				.Column("Id")
				.From("SupplyPaymentElement").As("spe").WithHints(Hints.NoLock)
				.Where("spe", "InvoiceId").IsEqual("inv", "Id")
				.And("Order", "Id").IsEqual("Order", "Id");
			var orderPayedInvoicesCountSelect = new Select(UserConnection)
				.Column(Func.Count("inv", "Id"))
				.From("Invoice").As("inv").WithHints(Hints.NoLock)
				.Where("inv", "OrderId").IsEqual("Order", "Id")
				.And("inv", "PaymentStatusId").In(Column.Parameters(invoicesStatusToCalcOrderSum))
				.And().Not().Exists(speWithInvoiceSelect);
			var paymentAmountBySPE = new Select(UserConnection)
				.Column(Func.Sum("summSpe", "PrimaryAmountFact")).As("SPEPaymentAmountSum")
				.From("SupplyPaymentElement").As("summSpe").WithHints(Hints.NoLock)
				.Where("summSpe", "OrderId").IsEqual("Order", "Id")
				.And("summSpe", "TypeId").IsEqual(Column.Parameter(PassportConstants.SupplyPaymentTypePayment));
			var paymentAmountByInvoices = new Select(UserConnection)
				.Column(Func.Sum("inv", "PrimaryPaymentAmount")).As("InvoicePaymentAmountSum")
				.From("Invoice").As("inv").WithHints(Hints.NoLock)
				.Where("inv", "OrderId").IsEqual("Order", "Id")
				.And("inv", "PaymentStatusId").In(Column.Parameters(invoicesStatusToCalcOrderSum))
				.And().Not().Exists(speWithInvoiceSelect);
			var select = new Select(UserConnection)
				.Column("Order", "Id").As("OrderId")
				.Column(Column.SubSelect(orderPayedInvoicesCountSelect)).As("InvoicesWithoutSpe")
				.Column("Order", "CurrencyId").As("Order_CurrencyId")
				.Column("Order", "CurrencyRate").As("Order_CurrencyRate")
				.Column("OrderCurrnecy", "Division").As("Order_Currency_Division")
				.Column(Column.SubSelect(paymentAmountBySPE)).As("PaymentAmountBySPE")
				.Column(Column.SubSelect(paymentAmountByInvoices)).As("PaymentAmountByInvoice")
				.From("Order").As("Order").WithHints(Hints.NoLock)
				.LeftOuterJoin("Currency").As("OrderCurrnecy").WithHints(Hints.NoLock)
					.On("OrderCurrnecy", "Id").IsEqual("Order", "CurrencyId");
			return (Select)select;
		}

		protected virtual void UpdateSupplyPaymentElemenByInvoice(Guid invoiceId, List<EntityColumnValue> changedColumnValues,
				SupplyPaymentFactAmountByInvoiceInfo supplyPaymentElementAmountInfo) {
			EntityColumnValue paymentStatusColumnValue =
				changedColumnValues.FirstOrDefault(changedColumn => changedColumn.Name == "PaymentStatusId");
			Entity supplyPaymentElement = supplyPaymentElementAmountInfo.SupplyPaymentElement;
			if (paymentStatusColumnValue != null) {
				var speStatus = (Guid)paymentStatusColumnValue.Value == PassportConstants.InvoicePaymentStatusPaid
					? PassportConstants.SupplyPaymentStateFinished
					: PassportConstants.SupplyPaymentStateNotFinished;
				if (supplyPaymentElement.GetTypedColumnValue<Guid>("StateId") != speStatus) {
					supplyPaymentElement.SetColumnValue("StateId", speStatus);
				}
			}
			UpdateSupplyPaymentElementByInvoice(supplyPaymentElementAmountInfo, supplyPaymentElement);
			supplyPaymentElement.Save(false);
		}


		protected virtual void UpdateSupplyPaymentElementByInvoice(SupplyPaymentFactAmountByInvoiceInfo factAmountInfo,
				Entity supplyPaymentElement) {
			decimal amountFact = 0;
			var columnName = "AmountFact";
			amountFact = factAmountInfo.PrimaryPaymentAmount * factAmountInfo.OrderCurrencyInfo.FromPrimaryFactor;
			if (IsUseCrossRate) {
				CurrencyRateInfo targetCurrencyRateInfo = new CurrencyRateInfo() {
					Rate = factAmountInfo.OrderCurrencyInfo.Rate,
					Division = (int)factAmountInfo.OrderCurrencyInfo.Division
				};
				CurrencyRateInfo currentCurrencyRateInfo = new CurrencyRateInfo() {
					Rate = factAmountInfo.CurrencyRate,
					Division = factAmountInfo.CurrencyDivision
				};
				amountFact = CurrencyConverter
					.GetConvertedAmountToCurrency(currentCurrencyRateInfo, targetCurrencyRateInfo,
						factAmountInfo.PaymentAmount);
				amountFact = GetRoundValueByColumnPrecision(supplyPaymentElement, amountFact, columnName);
			}
			supplyPaymentElement.SetColumnValue(columnName, amountFact);
			supplyPaymentElement.SetColumnValue("PrimaryAmountFact", factAmountInfo.PrimaryPaymentAmount);
			supplyPaymentElement.SetColumnValue("DateFact", factAmountInfo.DueDate);
		}

		protected SupplyPaymentFactAmountByInvoiceInfo GetSupplyPaymentElementByInvoice(Guid invoiceId) {
			var speEsq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SupplyPaymentElement");
			speEsq.AddAllSchemaColumns();
			var paymentAmount = speEsq.AddColumn("Invoice.PaymentAmount");
			var primaryPaymentAmount = speEsq.AddColumn("Invoice.PrimaryPaymentAmount");
			var invoiceCurrencyId = speEsq.AddColumn("Invoice.Currency.Id");
			var invoiceCurrencyDivision = speEsq.AddColumn("Invoice.Currency.Division");
			var invoiceCurrencyRate = speEsq.AddColumn("Invoice.CurrencyRate");
			var invoiceIdColumn = speEsq.AddColumn("Invoice.Id");
			var invoiceDueDate = speEsq.AddColumn("Invoice.DueDate");
			var invoicePaymentStatusId = speEsq.AddColumn("Invoice.PaymentStatus.Id");
			var orderCurrencyId = speEsq.AddColumn("Order.Currency.Id");
			var orderCurrencyDivision = speEsq.AddColumn("Order.Currency.Division");
			var orderCurrencyRate = speEsq.AddColumn("Order.CurrencyRate");
			speEsq.Filters.Add(speEsq.CreateFilterWithParameters(FilterComparisonType.Equal, "Invoice", invoiceId));
			var item = speEsq.GetEntityCollection(UserConnection).FirstOrDefault();
			if (item == null) {
				return null;
			}
			return new SupplyPaymentFactAmountByInvoiceInfo {
				SupplyPaymentElement = item,
				InvoiceId = item.GetTypedColumnValue<Guid>(invoiceIdColumn.Name),
				InvoicePaymentStatusId = item.GetTypedColumnValue<Guid>(invoicePaymentStatusId.Name),
				CurrencyId = item.GetTypedColumnValue<Guid>(invoiceCurrencyId.Name),
				CurrencyRate = item.GetTypedColumnValue<decimal>(invoiceCurrencyRate.Name),
				CurrencyDivision = item.GetTypedColumnValue<int>(invoiceCurrencyDivision.Name),
				PaymentAmount = item.GetTypedColumnValue<decimal>(paymentAmount.Name),
				PrimaryPaymentAmount = item.GetTypedColumnValue<decimal>(primaryPaymentAmount.Name),
				DueDate = item.GetTypedColumnValue<DateTime>(invoiceDueDate.Name),
				OrderCurrencyInfo = new CurrencyInfo {
					Id = item.GetTypedColumnValue<Guid>(orderCurrencyId.Name),
					Division = item.GetTypedColumnValue<decimal>(orderCurrencyDivision.Name),
					Rate = item.GetTypedColumnValue<decimal>(orderCurrencyRate.Name)
				}
			};
		}

		protected CurrencyInfo GetCurrencyInfo(string schemaName, Guid primaryColumnValue) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, schemaName);
			var orderCurrencyId = esq.AddColumn("Currency.Id");
			var orderCurrencyDivision = esq.AddColumn("Currency.Division");
			var orderCurrencyRate = esq.AddColumn("CurrencyRate");
			var row = esq.GetEntity(UserConnection, primaryColumnValue);
			return new CurrencyInfo {
				Id = row.GetTypedColumnValue<Guid>(orderCurrencyId.Name),
				Division = row.GetTypedColumnValue<decimal>(orderCurrencyDivision.Name),
				Rate = row.GetTypedColumnValue<decimal>(orderCurrencyRate.Name)
			};
		}

		protected void UpdateProductDetailAmounts(string schemaName, CurrencyInfo currencyInfo, Guid schemaRowId) {
			var update = new Update(UserConnection, schemaName + "Product").WithHints(Hints.RowLock)
				.Set("PrimaryTotalAmount",
					Column.SourceColumn("PrimaryTotalAmount") * Column.Parameter(currencyInfo.FromPrimaryFactor))
				.Set("TaxAmount", Column.SourceColumn("PrimaryTaxAmount") * Column.Parameter(currencyInfo.FromPrimaryFactor))
				.Set("Price", Column.SourceColumn("PrimaryPrice") * Column.Parameter(currencyInfo.FromPrimaryFactor))
				.Set("Amount", Column.SourceColumn("PrimaryAmount") * Column.Parameter(currencyInfo.FromPrimaryFactor))
				.Set("DiscountAmount",
					Column.SourceColumn("PrimaryDiscountAmount") * Column.Parameter(currencyInfo.FromPrimaryFactor))
				.Where(schemaName + "Id").IsEqual(Column.Parameter(schemaRowId));
			update.Execute();
		}

		protected bool IsInvoiceLinkedWithSupplyPaymentAndHasNoProducts(Guid invoiceId) {
			var invoiceProductSelect = new Select(UserConnection)
				.Column(Column.SourceColumn("Id"))
				.From("InvoiceProduct").As("ip").WithHints(Hints.NoLock)
				.Where("ip", "InvoiceId").IsEqual("inv", "Id");
			var speSelect = new Select(UserConnection)
				.Column(Column.SourceColumn("Id"))
				.From("SupplyPaymentElement").As("spe").WithHints(Hints.NoLock)
				.Where("spe", "InvoiceId").IsEqual("inv", "Id");
			var select = (Select)new Select(UserConnection)
				.Column("inv", "Id")
				.From("Invoice").As("inv").WithHints(Hints.NoLock)
				.Where("inv", "Id").IsEqual(Column.Parameter(invoiceId))
				.And().Exists(speSelect)
				.And().Not().Exists(invoiceProductSelect);
			return select.ExecuteScalar<Guid>() != Guid.Empty;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Updates supply payment, invoice and contract amounts by order id.
		/// </summary>
		/// <param name="orderId">Order identifier.</param>
		public virtual void UpdateAmountsByOrderId(Guid orderId) {
			var productsEsq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "OrderProduct");
			var idFilter = productsEsq.CreateFilterWithParameters(FilterComparisonType.Equal, "Order", orderId);
			productsEsq.Filters.Add(idFilter);
			var idColumn = productsEsq.AddColumn("Id");
			var productEntities = productsEsq.GetEntityCollection(UserConnection);
			UpdateAmountsInfo orderProductInfo = null;
			decimal orderAmount, currencyPrimaryFactor = 0;
			ExecuteInTransaction(executor => {
				foreach (Entity productEntity in productEntities) {
					var orderProductId = productEntity.GetTypedColumnValue<Guid>(idColumn.Name);
					orderProductInfo = ProtectedUpdateAmounts(orderProductId, dbExecutor: executor);
					currencyPrimaryFactor = orderProductInfo.OrderProductToPrimaryFactor;
				}
			});
			if (orderProductInfo == null) {
				var currencyInfo = GetOrderFinanceInfo(orderId);
				orderAmount = currencyInfo.Amount;
				currencyPrimaryFactor = GetToPrimaryFactor(currencyInfo.CurrencyInfo.Division, currencyInfo.CurrencyInfo.Rate);
			} else {
				orderAmount = orderProductInfo.OrderAmount;
			}
			UpdateSupplyPaymentElementsPercentageAndAmount(orderId, orderAmount, currencyPrimaryFactor);
		}

		[Obsolete]
		public virtual void UpdateAmounts(Guid orderProductId, Guid? supplyPaymentElementId = null) {
			UpdateAmountsInfo orderProductInfo = ProtectedUpdateAmounts(orderProductId, supplyPaymentElementId);
			if (orderProductInfo == null) {
				return;
			}
			UpdateSupplyPaymentElementsPercentageAndAmount(orderProductInfo.OrderId, orderProductInfo.OrderAmount,
					orderProductInfo.OrderToPrimaryFactor);
		}

		/// <summary>
		/// Updates supply payment percentage, invoice amount on products change.
		/// </summary>
		/// <param name="productInfos">Changed products.</param>
		/// <param name="supplyPaymentElementId">Supply payment element identifier.</param>
		public virtual void OnSupplyPaymentProductsChange(List<SupplyPaymentProductInfo> productInfos,
				Guid supplyPaymentElementId) {
			UpdateAmountsInfo updateAmountsInfo = null;
			foreach (SupplyPaymentProductInfo productInfo in productInfos) {
				updateAmountsInfo = ProtectedUpdateAmounts(productInfo.OrderProductId, supplyPaymentElementId);
			}
			if (updateAmountsInfo != null) {
				UpdateSupplyPaymentElementsPercentageAndAmount(updateAmountsInfo.OrderId, updateAmountsInfo.OrderAmount,
					updateAmountsInfo.OrderProductToPrimaryFactor, supplyPaymentElementId);
			}
			if (productInfos.Any(productInfo => productInfo.ToDelete)) {
				UpdateInvoiceBySupplyPaymentElementId(supplyPaymentElementId);
			}
		}

		/// <summary>
		/// Updates supply payment, invoice and invoice product amounts on order product change.
		/// <param name="orderProductId">Order product identifier.</param>
		/// <param name="changedColumnValues">Changed column values.</param>
		/// </summary>
		public virtual void OnOrderProductChanged(Guid orderProductId, IEnumerable<EntityColumnValue> changedColumnValues) {
			UpdateAmountsInfo orderProductInfo = ProtectedUpdateAmounts(orderProductId);
			if (orderProductInfo == null) {
				return;
			}
			UpdateSupplyPaymentElementsPercentageAndAmount(orderProductInfo.OrderId, orderProductInfo.OrderAmount,
					orderProductInfo.OrderToPrimaryFactor);
		}

		/// <summary>
		/// Clears supply payment element's percentage and amount without products.
		/// </summary>
		/// <param name="orderId">Order identifier.</param>
		/// <param name="elementTypeId">Supply payment element type identifier.</param>
		public virtual void ClearPercentageInElementsWithoutProducts(Guid orderId, Guid elementTypeId) {
			if (orderId == Guid.Empty) {
				return;
			}
			List<Guid> entityCollection = GetPaymentsWithoutProductsInOrder(orderId, elementTypeId);
			var supplyPaymentElementSchema = UserConnection.EntitySchemaManager.GetInstanceByName("SupplyPaymentElement");
			foreach (Guid supplyPaymentElementId in entityCollection) {
				var row = supplyPaymentElementSchema.CreateEntity(UserConnection);
				row.FetchFromDB(supplyPaymentElementId, false);
				ClearPercentageInElement(row);
			}
		}

		/// <summary>
		/// Updates invoice amount, related to <paremref name="supplyPaymentElementId"/>.
		/// </summary>
		/// <param name="supplyPaymentElementId"><see cref="SupplyPaymentElement"/> instance unique identifier.</param>
		/// <param name="useRestricts">Check invoice update conditions flag.</param>
		public virtual void UpdateInvoiceBySupplyPaymentElementId(Guid supplyPaymentElementId, bool useRestricts = true) {
			UpdateInvoiceAmountBySPE(supplyPaymentElementId, useRestricts);
		}

		/// <summary>
		/// Updates order payment amount on supply payment element change.
		/// </summary>
		/// <param name="supplyPaymentElementId">Supply payment element identifier.</param>
		public void UpdateOrderPaymentAmountOnSPEChanged(Guid supplyPaymentElementId) {
			if (IsUseCrossRate) {
				UpdateOrderPaymentAmountOnSPEChangedUseCrossRate(supplyPaymentElementId);
				return;
			}
			OrderPaymentAmountCalcInfo orderInfo = GetOrderPaymentAmountCalcInfoBySPE(supplyPaymentElementId);
			if ((orderInfo == null) || orderInfo.IsAmountCalculatedByInvoices) {
				return;
			}
			UpdateOrderPaymentAmount(orderInfo.OrderId, orderInfo.CurrencyInfo, orderInfo.PaymentAmountBySPE);
		}

		/// <summary>
		/// Updates order payment amount on supply payment element delete.
		/// </summary>
		/// <param name="orderId">Order identifier.</param>
		public void UpdateOrderPaymentAmountOnSupplyPaymentElementDeleted(Guid orderId) {
			OrderPaymentAmountCalcInfo orderInfo = GetOrderPaymentAmountCalcInfoByOrderId(orderId);
			if (orderInfo == null) {
				return;
			}
			UpdateOrderPaymentAmount(orderInfo.OrderId, orderInfo.CurrencyInfo,
				orderInfo.IsAmountCalculatedByInvoices ? orderInfo.PaymentAmountByInvoice : orderInfo.PaymentAmountBySPE);
		}

		/// <summary>
		/// Updates order payment amount on invoice change
		/// </summary>
		/// <param name="invoiceId">Invoice identifier</param>
		public void UpdateOrderPaymentAmountOnInvoiceChanged(Guid invoiceId) {
			if (IsUseCrossRate) {
				UpdateOrderPaymentAmountOnInvoiceChangedUseCrossRate(invoiceId);
				return;
			}
			OrderPaymentAmountCalcInfo orderInfo = GetOrderPaymentAmountCalcInfoByInvoice(invoiceId);
			if ((orderInfo == null) || !orderInfo.IsAmountCalculatedByInvoices) {
				return;
			}
			UpdateOrderPaymentAmount(orderInfo.OrderId, orderInfo.CurrencyInfo, orderInfo.PaymentAmountByInvoice);
		}

		/// <summary>
		/// Updates supply payment element values on invoice change
		/// </summary>
		/// <param name="invoiceId">Invoice identifier.</param>
		/// <param name="changedColumnValues">Changed columns.</param>
		/// <param name="orderPaymentAmountUpdated">Sets true if order payment amount was updated.</param>
		public virtual void UpdateSupplyPaymentElementOnInvoiceChanged(Guid invoiceId,
				List<EntityColumnValue> changedColumnValues, out bool orderPaymentAmountUpdated) {
			orderPaymentAmountUpdated = false;
			if (!changedColumnValues.ConvertAll(cv => cv.Column.Name)
				.Intersect(new[] { "PrimaryPaymentAmount", "PaymentStatusId", "DueDate" }).Any()) {
				return;
			}
			var supplyPaymentElementInfo = GetSupplyPaymentElementByInvoice(invoiceId);
			if (supplyPaymentElementInfo == null) {
				return;
			}
			bool invoiceIsPaid = supplyPaymentElementInfo.InvoicePaymentStatusId == PassportConstants.InvoicePaymentStatusPaid
					|| supplyPaymentElementInfo.InvoicePaymentStatusId ==
					 PassportConstants.InvoicePaymentStatusPartiallyPaid;
			if (!invoiceIsPaid) {
				return;
			}
			UpdateSupplyPaymentElemenByInvoice(invoiceId, changedColumnValues, supplyPaymentElementInfo);
			orderPaymentAmountUpdated = true;
		}

		/// <summary>
		/// Updates invoice product amount on currency change.
		/// </summary>
		/// <param name="invoiceId">Invoice identifier..</param>
		public bool UpdateInvoiceProductAmountOnCurrencyChange(Guid invoiceId) {
			var isAmountFromSpe = IsInvoiceLinkedWithSupplyPaymentAndHasNoProducts(invoiceId);
			if (!isAmountFromSpe) {
				return false;
			}
			var invoiceCurrencyInfo = GetCurrencyInfo("Invoice", invoiceId);
			UpdateProductDetailAmounts("Invoice", invoiceCurrencyInfo, invoiceId);
			return true;
		}

		/// <summary>
		/// Updates order payment amount on invoice delete.
		/// </summary>
		/// <param name="orderId">Order identifier.</param>
		public void UpdateOrderPaymentAmountOnInvoiceDeleted(Guid orderId) {
			OrderPaymentAmountCalcInfo orderInfo = GetOrderPaymentAmountCalcInfoByOrderId(orderId);
			if (orderInfo == null) {
				return;
			}
			UpdateOrderPaymentAmount(orderInfo.OrderId, orderInfo.CurrencyInfo,
				!orderInfo.IsAmountCalculatedByInvoices ? orderInfo.PaymentAmountBySPE : orderInfo.PaymentAmountByInvoice);
		}

		/// <summary>
		/// Returns supply payment elements identifiers by order product idendifier.
		/// </summary>
		/// <param name="orderProductId">Order product idendifier.</param>
		/// <returns>Supply payment element identifiers.</returns>
		public virtual List<Guid> GetSupplyPaymentElementIdsByOrderProduct(Guid orderProductId) {
			var ids = GetSupplyPaymentIdsByOrderProductId(orderProductId);
			return ids;
		}

		/// <summary>
		/// Updates supply payment amount and percentage.
		/// </summary>
		/// <param name="orderId">Order identifier.</param>
		/// <param name="supplyPaymentElementIds">Supply payment elements identifiers.</param>
		public virtual void OnOrderProductDeleted(Guid orderId, List<Guid> supplyPaymentElementIds) {
			var currencyInfo = GetOrderFinanceInfo(orderId);
			if (supplyPaymentElementIds.Any()) {
				ExecuteInTransaction(executor => {
					foreach (Guid supplyPaymentElementId in supplyPaymentElementIds) {
						UpdateSupplyPaymentElementAmount(supplyPaymentElementId, orderId, currencyInfo, executor);
					}
				});
			}
			var toPrimaryFactor = GetToPrimaryFactor(currencyInfo.CurrencyInfo.Division, currencyInfo.CurrencyInfo.Rate);
			UpdateSupplyPaymentElementsPercentageAndAmount(orderId, currencyInfo.Amount, toPrimaryFactor);
		}

		/// <summary>
		/// Clears percentage, expected amounts values.
		/// </summary>
		/// <param name="supplyPaymentElement">Supply payment element entity.</param>
		public virtual void ClearPercentageInElement(Entity supplyPaymentElement) {
			supplyPaymentElement.SetColumnValue("Percentage", 0);
			supplyPaymentElement.SetColumnValue("AmountPlan", 0);
			supplyPaymentElement.SetColumnValue("PrimaryAmountPlan", 0);
			supplyPaymentElement.Save(false);
		}

		/// <summary>
		/// Updates supply payment expected amounts.
		/// </summary>
		/// <param name="orderId">Order identifier.</param>
		/// <param name="supplyPaymentElementList">Supply payment elements.</param>
		public virtual void UpdateSupplyPaymentElementsAmount(Guid orderId, List<Entity> supplyPaymentElementList) {
			if (supplyPaymentElementList.Count == 0) {
				return;
			}
			var orderCurrencyOnfo = GetOrderFinanceInfo(orderId);
			foreach (Entity item in supplyPaymentElementList) {
				var percentage = item.GetTypedColumnValue<decimal>("Percentage");
				item.SetColumnValue("AmountPlan", orderCurrencyOnfo.Amount * percentage / 100m);
				item.SetColumnValue("PrimaryAmountPlan", orderCurrencyOnfo.PrimaryAmount * percentage / 100m);
				decimal amountFact = orderCurrencyOnfo.CurrencyInfo.FromPrimaryFactor *
					 item.GetTypedColumnValue<decimal>("PrimaryAmountFact");
				item.SetColumnValue("AmountFact", amountFact);
			}
		}

		#endregion
	}
}
