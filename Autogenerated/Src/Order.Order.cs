namespace BPMSoft.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using BPMSoft.Common;
    using BPMSoft.Core;
    using BPMSoft.Core.Configuration;
    using BPMSoft.Core.DB;
    using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Class: Order_OrderEventsProcess

	public partial class Order_OrderEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void SetOrderProductCurrency() {
			Guid currencyId = Entity.GetTypedColumnValue<Guid>("CurrencyId");
			decimal currencyRate = Entity.GetTypedColumnValue<decimal>("CurrencyRate");
			var currencyEntity = UserConnection.EntitySchemaManager.GetInstanceByName("Currency").CreateEntity(UserConnection);
			currencyEntity.FetchFromDB(currencyEntity.Schema.GetPrimaryColumnName(), currencyId, new[] { "Division" });
			decimal division = currencyEntity.GetTypedColumnValue<decimal>("Division");
			decimal currencyFromPrimaryFactor = division!= 0? currencyRate / division : 0;
			var update = new Update(UserConnection, "OrderProduct")
				.Set("CurrencyId", Column.Parameter(currencyId))
				.Set("CurrencyRate", Column.Parameter(currencyRate))
				.Set("Price", Column.Parameter(currencyFromPrimaryFactor) * Column.SourceColumn("PrimaryPrice"))
				.Set("Amount", Column.Parameter(currencyFromPrimaryFactor) * Column.SourceColumn("PrimaryAmount"))
				.Set("DiscountAmount", Column.Parameter(currencyFromPrimaryFactor) * Column.SourceColumn("PrimaryDiscountAmount"))
				.Set("TaxAmount", Column.Parameter(currencyFromPrimaryFactor) * Column.SourceColumn("PrimaryTaxAmount"))
				.Set("TotalAmount", Column.Parameter(currencyFromPrimaryFactor) * Column.SourceColumn("PrimaryTotalAmount"))
			.Where("OrderId").IsEqual(Column.Parameter(Entity.GetTypedColumnValue<Guid>("Id"))) as Update;
			update.Execute();
		}

		public virtual void UpdateProductAmounts() {
			if (NeedFinRecalc) {
				ProductEntryUtils utils = ClassFactory.Get<ProductEntryUtils>(new Core.Factories.ConstructorArgument("userConnection", UserConnection));
				utils.UpdateRecordProductAmounts(Entity, true);
			}
		}

		public virtual CurrencyRateInfo GetCurrencyInfo() {
			var currencyId = Entity.GetTypedColumnValue<Guid>("CurrencyId");
			var currencyRateStorage = ClassFactory.Get<ICurrenciesRateStorage>();
			var currencyInfo = currencyRateStorage.GetActualCurrencyRates(currencyId).FirstOrDefault();
			return currencyInfo;
		}

		public virtual bool ChangeStatus() {
			if (Entity.StoringState == StoringObjectState.New) {
				return true;
			}
			List<string> changedColumnNames = Entity.GetChangedColumnValues()
													.Where(cv=>cv.Value != cv.OldValue)
													.ToList().ConvertAll(cv => cv.Column.Name);
			NeedFinRecalc = changedColumnNames.Intersect(new[] {"CurrencyRate", "Currency"}).Any();
			var securityEngine = UserConnection.DBSecurityEngine;
			bool hasRight = securityEngine.GetIsEntitySchemaColumnEditingAllowed("Order", "PaymentStatus");
			if (changedColumnNames.Intersect(new[] {"Amount", "PaymentAmount"}).Any() && hasRight) {
				var amount = Entity.GetTypedColumnValue<decimal>("Amount");
				var paymentAmount = Entity.GetTypedColumnValue<decimal>("PaymentAmount");
				if (amount > 0 && amount == paymentAmount) {
					Entity.SetColumnValue("PaymentStatusId", OrderPackage.Constants.Order.OrderPaymentStatus.Paid);
				} else if (paymentAmount > 0) {
					Entity.SetColumnValue("PaymentStatusId", OrderPackage.Constants.Order.OrderPaymentStatus.PartiallyPaid);
				}
			}
			return true;
		}

		public virtual bool CalculatePrimaryAmount() {
			ConstructorArgument arg = new ConstructorArgument("userConnection", UserConnection);
			var orderCalculator = ClassFactory.Get<OrderCalculator>(arg);
            orderCalculator.CalculatePrimaryAmount(Entity);
			return true;
		}

		public virtual bool SetNumberGenerationParams() {
			GenerateNumberUserTask.EntitySchema = Entity.Schema;
			return true;
		}

		public virtual bool UpdateNumber() {
			string code = GenerateNumberUserTask.ResultCode;
			Entity.SetColumnValue("Number", code);
			return true;
		}

		public virtual bool UpdateReminders() {
			if (!CanGenerateAnniversaryReminding) {
				return true;
			}
			Guid id = Entity.GetTypedColumnValue<Guid>("Id");
			OrderAnniversaryReminding remindingsGenerator = new OrderAnniversaryReminding(UserConnection, id);
			remindingsGenerator.Options = GetRemindingOptions();
			remindingsGenerator.GenerateActualRemindings();
			return true;
		}

		public virtual void InitCanGenerateAnniversaryReminding() {
			bool isNew = Entity.StoringState == StoringObjectState.New;
			var columns = GetAnniversaryDependentColumns();
			var changedColumns = Entity.GetChangedColumnValues();
			EntityChangedColumns = changedColumns.ToList();
			bool anniversaryColumnsChanged = changedColumns.Any(col => columns.Contains(col.Name));
			CanGenerateAnniversaryReminding = anniversaryColumnsChanged;
		}

		public virtual IEnumerable<string> GetAnniversaryDependentColumns() {
			return new[] { "ContactId", "AccountId", "OwnerId" };
		}

		public virtual IEnumerable<string> GetRemindingOptions() {
			var options = new List<string>();
			var changedColumns = EntityChangedColumns as List<EntityColumnValue> ?? new List<EntityColumnValue>();
			if (changedColumns.Any(col => col.Name == "OwnerId")) {
				options.AddRange(new[] {
					OrderAnniversaryReminding.AccountOption,
					OrderAnniversaryReminding.ContactOption
				});
				return options;
			}
			if (changedColumns.Any(col => col.Name == "ContactId")) {
				options.Add(OrderAnniversaryReminding.ContactOption);
			}
			if (changedColumns.Any(col => col.Name == "AccountId")) {
				options.Add(OrderAnniversaryReminding.AccountOption);
			}
			return options;
		}

		#endregion

	}

	#endregion

}

