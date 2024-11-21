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

	#region Class: Lead_WebLeadFormEventsProcess

	public partial class Lead_WebLeadFormEventsProcess<TEntity>
	{

		#region Methods: Private

		private void SetComputedColumnValue(string columnName, Guid computedValue, bool useDefaultLeadSourceValue) {
			if (computedValue == Guid.Empty) {
				return;
			}
			var value = Entity.IsColumnValueLoaded(columnName)
				? Entity.GetTypedColumnValue<Guid>(columnName) : Guid.Empty;
			if (useDefaultLeadSourceValue && value != Guid.Empty) {
				return;
			}
			Entity.SetColumnValue(columnName, computedValue);
		}

		#endregion

		#region Methods: Public

		public override void LeadInserted() {
			base.LeadInserted();
			if (Entity.GetIsColumnValueLoaded("QualifiedContactId") && Guid.Empty != Entity.QualifiedContactId ||
					Entity.GetIsColumnValueLoaded("WebFormId") && Guid.Empty == Entity.WebFormId) {	
				return;
			}
			ProcessSchema schema = UserConnection.ProcessSchemaManager
				.GetInstanceByName("LeadManagementIdentification");
			var parameterValues = new Dictionary<string, string>();
			parameterValues.Add("LeadId", Entity.Id.ToString());
			RunProcess(schema.UId, parameterValues);
		}

		public override void LeadInserting() {
			base.LeadInserting();
			string bpmHrefColumnName = "BpmHref";
			string bpmRefColumnName = "BpmRef";
			string bpmHref = Entity.IsColumnValueLoaded(bpmHrefColumnName) 
				? Entity.GetTypedColumnValue<string>(bpmHrefColumnName) : String.Empty;
			string bpmRef = Entity.IsColumnValueLoaded(bpmRefColumnName) 
				? Entity.GetTypedColumnValue<string>(bpmRefColumnName) : String.Empty;
			var lsh = new LeadSourceHelper(UserConnection, bpmHref, bpmRef);
			lsh.ComputeMediumAndSource();
			var useDefaultLeadSourceValue = UserConnection.GetIsFeatureEnabled("UseDefaultLeadSourceValue");
			SetComputedColumnValue("LeadMediumId", lsh.ResultLeadMediumId, useDefaultLeadSourceValue);
			SetComputedColumnValue("LeadSourceId", lsh.ResultLeadSourceId, useDefaultLeadSourceValue);
		}

		#endregion

	}

	#endregion

}

