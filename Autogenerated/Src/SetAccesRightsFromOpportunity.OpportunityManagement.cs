namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Linq;
	using System.Text;

	#region Class: SetAccesRightsFromOpportunityMethodsWrapper

	/// <exclude/>
	public class SetAccesRightsFromOpportunityMethodsWrapper : ProcessModel
	{

		public SetAccesRightsFromOpportunityMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ScriptTask4Execute", ScriptTask4Execute);
		}

		#region Methods: Private

		private bool ScriptTask4Execute(ProcessExecutingContext context) {
			var isOpportunityRightsUsed = BPMSoft.Configuration.OpportunityManagement.OpportunityManagementUtils
				.GetIsAnySchemaAdministratedByRecords(UserConnection, "Account", "Contact", "Opportunity");
			Set("IsOpportunityRightsUsed", isOpportunityRightsUsed);
			return true;
		}

		#endregion

	}

	#endregion

}

