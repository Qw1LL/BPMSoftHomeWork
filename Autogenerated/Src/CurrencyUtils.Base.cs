using System;
using System.Data;
using BPMSoft.Core;
using BPMSoft.Core.Entities;
using BPMSoft.Core.DB;
namespace BPMSoft.Configuration
{
	[Obsolete("Class is obsolete, use BPMSoft.Configuration.CurrencyRateStorage instead.")]
	public static class CurrencyUtils
	{
		public static decimal GetCurrencyRate(Guid currencyId,UserConnection userConnection) {
			var rateSelect = new Select(userConnection).Top(1)
			.Column("StartDate")
			.Column("Currency","Division").As("Division")
			.Column("Rate").As("Rate")
			.From("CurrencyRate")
			.Join(JoinType.Inner, "Currency")
			.On("Currency", "Id").IsEqual(Column.Parameter(currencyId))
			.Where("StartDate").IsLessOrEqual(Column.Parameter(DateTime.Today))
				.And("CurrencyId").IsEqual(Column.Parameter(currencyId))
			.OrderByDesc("StartDate") as Select;
			var entitySchemaManager = userConnection.GetSchemaManager("EntitySchemaManager") as EntitySchemaManager;
			BPMSoft.Core.Entities.EntitySchema wSchema = new BPMSoft.Core.Entities.EntitySchema(entitySchemaManager);
			EntityCollection coll = new EntityCollection(userConnection, wSchema);
			using (DBExecutor dbExecutor = userConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = rateSelect.ExecuteReader(dbExecutor)) {
					coll.Load(dataReader);
				}
			}
			if (coll.Count > 0) {
				var currencyDivision = coll[0].GetTypedColumnValue<Int32>("Division");
				var currencyRate = coll[0].GetTypedColumnValue<Decimal>("Rate");
				if(currencyDivision == 0) currencyDivision = 1;
				var rate = Math.Round(currencyRate / currencyDivision, 2);
				return rate;
			} else {
				return 1;
			}
		}
	}
}
