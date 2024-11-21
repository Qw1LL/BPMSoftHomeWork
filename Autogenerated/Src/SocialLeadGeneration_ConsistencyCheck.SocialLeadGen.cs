namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Configuration.SocialLeadGen;
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
	using System.Text;

	#region Class: SocialLeadGeneration_ConsistencyCheckMethodsWrapper

	/// <exclude/>
	public class SocialLeadGeneration_ConsistencyCheckMethodsWrapper : ProcessModel
	{

		public SocialLeadGeneration_ConsistencyCheckMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ScriptTask2Execute", ScriptTask2Execute);
			AddScriptTaskMethod("ScriptTask1Execute", ScriptTask1Execute);
		}

		#region Methods: Private

		private bool ScriptTask2Execute(ProcessExecutingContext context) {
			try
			{
			    var from = Get<DateTime>("LastCheckDate");
			    var to = DateTime.Now;
			    var socialLeadIdCollection = Get<string>("SocialLeadIdCollection");
			    var receiverSocialLeadGenRestProvider = new ReceiverSocialLeadGenRestProvider(UserConnection);
			    receiverSocialLeadGenRestProvider.PullLinkedInLeads(from, to, socialLeadIdCollection.Split(','));
			    Set("RequestSuccess", true);
			}
			catch (Exception exception) {
			    Set("RequestSuccess", false);
			    Set("ErrorMessage", exception.Message);
			}   
			return true;
		}

		private bool ScriptTask1Execute(ProcessExecutingContext context) {
			try
			{
				var from = Get<DateTime>("LastCheckDate");
				var to = DateTime.Now;
				if (from > to) {
					throw new Exception("Invalid range. Value 'from' is greater than 'to'");
				}
				var diff = (to - from).TotalDays;
				if (diff > 90) {
					from = to.AddDays(-90);
					Set("LastCheckDate", from);
				}
				var ids = new List<string>();
				var select = new Select(UserConnection)
					.Column("SocialLeadId").From("LeadGenWebhooks")
					.Where("CreatedOn").IsGreater(Column.Parameter(from))
					.And("CreatedOn").IsLessOrEqual(Column.Parameter(to)) 
					as Select;
				using (var executor = UserConnection.EnsureDBConnection()) {
					using (var reader = select.ExecuteReader(executor)) {
						while (reader.Read()) {
							ids.Add(reader.GetColumnValue("SocialLeadId").ToString());
						}
					}
				}
				Set("SelectResult", true);
				Set("SocialLeadIdCollection", string.Join(",", ids.ToArray()));
			} catch (Exception exception) {
				Set("SelectResult", false);
				Set("ErrorMessage", exception.Message);
			}
			return true;
		}

		#endregion

	}

	#endregion

}

