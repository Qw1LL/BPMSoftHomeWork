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

	#region Class: OpportunityStage_OpportunityEventsProcess

	public partial class OpportunityStage_OpportunityEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void ClearCache() {
			#pragma warning disable CS0618
			Store.Cache[CacheLevel.Application]
				.ExpireGroup(UserConnection.GetIsFeatureEnabled("NewOpportunityStageManager")
					? BPMSoft.Configuration.OpportunityStageRepository.OpportunityCacheGroupName
					: BPMSoft.Configuration.OpportunityStageHelper.OppInStageCacheGroupName);
			#pragma warning restore CS0618
		}

		#endregion

	}

	#endregion

}

