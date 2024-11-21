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

	#region Class: SocialLeadGeneration_LoadingLeadsMethodsWrapper

	/// <exclude/>
	public class SocialLeadGeneration_LoadingLeadsMethodsWrapper : ProcessModel
	{

		public SocialLeadGeneration_LoadingLeadsMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ScriptTask1Execute", ScriptTask1Execute);
			AddScriptTaskMethod("ScriptTask2Execute", ScriptTask2Execute);
		}

		#region Methods: Private

		private bool ScriptTask1Execute(ProcessExecutingContext context) {
			var ids = new List<string>();
			try {
			    var integrationId = Get<Guid>("IntegrationId");
			    var formId = Get<string>("FormId");
			    var startDate = Get<DateTime>("StartDate");
			    var endDate = Get<DateTime>("EndDate");
			    var query = new Select(UserConnection)
			        .Column("SocialLeadId")
			        .From("LeadGenWebhooks").As("Webhooks")
			        .InnerJoin("LeadGenWebhookStatus").As("WebhooksStatus")
			        .On("Webhooks", "LeadGenWebhookStatusId").IsEqual("WebhooksStatus", "Id")
			        .Where("Webhooks", "IntegrationId").IsEqual(Column.Parameter(integrationId))
			        .And("Webhooks", "SocialCreatedOn").IsGreater(Column.Parameter(startDate))
			        .And("Webhooks", "SocialCreatedOn").IsLess(Column.Parameter(endDate))
			        .And("WebhooksStatus", "Name").IsEqual(Column.Parameter("Success"));
			    if (!string.IsNullOrEmpty(formId)) {
			        query = query.And("Webhooks", "FormId").IsEqual(Column.Parameter(formId));
			    }
			    using (var executor = UserConnection.EnsureDBConnection()) {
					using (var reader = (query as Select).ExecuteReader(executor)) {
						while (reader.Read()) {
							ids.Add(reader.GetColumnValue("SocialLeadId").ToString());
						}
					}
				}
			    Set("SelectResult", true);
			    Set("SocialLeadIdCollection", string.Join(",", ids.ToArray()));
			}
			catch (Exception exception) {
			    Set("SelectResult", false);
			    Set("ErrorMessage", exception.Message);
			}
			return true;
		}

		private bool ScriptTask2Execute(ProcessExecutingContext context) {
			try
			{
			    var integrationId = Get<Guid>("IntegrationId");
			    var formIdStr = Get<string>("FormId");
			    long formId = string.IsNullOrEmpty(formIdStr) ? default : long.Parse(formIdStr);
			    var startDate = Get<DateTime>("StartDate");
			    var endDate = Get<DateTime>("EndDate");
			    var socialLeadIdCollection = Get<string>("SocialLeadIdCollection");
			    var socialLeadIds = string.IsNullOrEmpty(socialLeadIdCollection) ? new string[] { } : socialLeadIdCollection.Split(',');
			    var receiverSocialLeadGenRestProvider = new ReceiverSocialLeadGenRestProvider(UserConnection);
			    receiverSocialLeadGenRestProvider.PullLinkedInLeads(startDate, endDate, socialLeadIds, true, integrationId, formId);
			    Set("SelectResult", true);
			}
			catch (Exception exception) {
			    Set("SelectResult", false);
			    Set("ErrorMessage", exception.Message);
			}   
			return true;
		}

		#endregion

	}

	#endregion

}

