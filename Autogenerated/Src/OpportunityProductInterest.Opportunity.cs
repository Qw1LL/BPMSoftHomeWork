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
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;

	#region Class: OpportunityProductInterest_OpportunityEventsProcess

	public partial class OpportunityProductInterest_OpportunityEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void CalckOpportunityAmount(Guid opportunityId) {
			var select = new Select(UserConnection)
				.Column(Func.Sum("Amount")).As("Amount")
				.From("OpportunityProductInterest")
			 	.Where("OpportunityId").IsEqual(Column.Parameter(opportunityId)) as Select;
			double amount = 0;
			select.ExecuteReader((reader => {
				amount = reader.GetColumnValue<double>("Amount");
			}));
			var opportunity = UserConnection.EntitySchemaManager.GetInstanceByName("Opportunity")
				.CreateEntity(UserConnection);
			opportunity.FetchFromDB(opportunityId);
			opportunity.SetColumnValue("Amount", amount);
			opportunity.Save(false);
		}

		#endregion

	}

	#endregion

}

