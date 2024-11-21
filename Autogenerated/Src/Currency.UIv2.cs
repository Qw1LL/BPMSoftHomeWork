namespace BPMSoft.Configuration
{

	using DataContract = BPMSoft.Nui.ServiceModel.DataContract;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.Core.Store;
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;

	#region Class: Currency_UIv2EventsProcess

	public partial class Currency_UIv2EventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void OnCurrencySavedHandler() {
			var currRateSchema = UserConnection.EntitySchemaManager.GetInstanceByName("CurrencyRate");
			var currencyRateStorage = BPMSoft.Core.Factories.ClassFactory.Get<BPMSoft.Configuration.CurrencyRateStorage>(
				new BPMSoft.Core.Factories.ConstructorArgument("userConnection", UserConnection),
				new BPMSoft.Core.Factories.ConstructorArgument("schema", currRateSchema));
			List<CurrencyRateInfo> rates = currencyRateStorage.GetActualCurrencyRates(Entity.PrimaryColumnValue);
			CurrencyRateInfo currentCurrenyRate = rates.FirstOrDefault();
			if (currentCurrenyRate != null) {
				OldCurrencyRate = CurrencyRateHelper.SetMantissaToRate(currentCurrenyRate.Rate, currentCurrenyRate.RateMantissa);
			}
			if (CurrencyRate > 0.00m && OldCurrencyRate != CurrencyRate) {
				currencyRateStorage.SaveRates(new CurrencyRateInfo() {
					CurrencyId = Entity.PrimaryColumnValue, 
					Rate = CurrencyRate
				});
			}
		}

		public virtual void OnCurrencySavingHandler() {
			var columns = Entity.GetChangedColumnValues();
			var rateColumnName = Entity.Schema.Columns.GetByName("Rate").ColumnValueName;
			CurrencyRate = Entity.GetTypedColumnValue<decimal>(rateColumnName);
			Entity.SetColumnValue("Rate", 0.00m);
		}

		#endregion

	}

	#endregion

}

