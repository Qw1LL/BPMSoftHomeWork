namespace BPMSoft.Configuration
{

	using DataContract = BPMSoft.Nui.ServiceModel.DataContract;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Collections.Specialized;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using System.Web;
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

	#region Class: Lead_MarketingCampaignEventsProcess

	public partial class Lead_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void BindToCampaignAndBulkEmail() {
			if (!Entity.IsColumnValueLoaded("BpmHref")) {
				return;
			}
			string bpmHref = Entity.GetTypedColumnValue<string>("BpmHref");
			if (string.IsNullOrWhiteSpace(bpmHref)) {
				return;
			}
			var utmParser = new MarketingUtmParser();
			var bulkEmailId = utmParser.GetBulkEmailByUtm(Entity.UserConnection, bpmHref);
			if (bulkEmailId.IsNotEmpty()) {
				Entity.SetColumnValue("BulkEmailId", bulkEmailId);
			}
			var campaignId = utmParser.GetCampaignByUtm(Entity.UserConnection, bpmHref);
			if (campaignId.IsNotEmpty()) {
				Entity.SetColumnValue("CampaignId", campaignId);
			}
		}

		public override void LeadInserting() {
			base.LeadInserting();
			BindToCampaignAndBulkEmail();
		}

		#endregion

	}

	#endregion

}

