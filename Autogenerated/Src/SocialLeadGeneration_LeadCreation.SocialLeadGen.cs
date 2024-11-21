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

	#region Class: SocialLeadGeneration_LeadCreationMethodsWrapper

	/// <exclude/>
	public class SocialLeadGeneration_LeadCreationMethodsWrapper : ProcessModel
	{

		public SocialLeadGeneration_LeadCreationMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ScriptTask2Execute", ScriptTask2Execute);
		}

		#region Methods: Private

		private bool ScriptTask2Execute(ProcessExecutingContext context) {
			var leadNotifyStringData = Get<string>("WebhookMetadata");
			CreateLeadFromWebhookMetadata(leadNotifyStringData);
			return true;
		}

			private void SetProcessLinkedInParameters(LeadNotifyWebhook webhook, Entity entity, bool isSuccessCreation, Exception exception) {
			    Set("LinkedInAdAccountId", webhook.Metadata.LinkedIn?.AdAccount?.Id.ToString() ?? string.Empty);
			    Set("LinkedInAdAccountName", webhook.Metadata.LinkedIn?.AdAccount?.Name ?? string.Empty);
			    Set("AdId", webhook.Metadata.LinkedIn?.AdCreative?.Id.ToString() ?? string.Empty);
			    Set("AdName", webhook.Metadata.LinkedIn?.AdCreative?.Name ?? string.Empty);
			    Set("CampaignGroupId", webhook.Metadata.LinkedIn?.CampaignGroup?.Id.ToString() ?? string.Empty);
			    Set("CampaignGroupName", webhook.Metadata.LinkedIn?.CampaignGroup?.Name ?? string.Empty);
			    Set("CampaignId", webhook.Metadata.LinkedIn?.Campaign?.Id.ToString() ?? string.Empty);
			    Set("CampaignName", webhook.Metadata.LinkedIn?.Campaign?.Name ?? string.Empty);
			    Set("FormId", webhook.Metadata.LinkedIn?.Form?.Id.ToString() ?? string.Empty);
			    Set("FormName", webhook.Metadata.LinkedIn?.Form?.Name ?? string.Empty);
			    Set("ObjectSchemaName", webhook.EntitySchemaName);
			    Set("ResultOfCreation", isSuccessCreation);
			    Set("CreatedRecordId", entity?.GetTypedColumnValue<Guid>("Id") ?? Guid.Empty);
			    Set("ErrorMessage", exception?.ToString() ?? string.Empty);
			}
			   
			private void CreateLeadFromWebhookMetadata(string leadNotifyStringData) {
			    if (leadNotifyStringData == null)
			    throw new Exception("leadNotifyStringData==null");
			    var webhook = WebhookParser.ParseLeadNotify(leadNotifyStringData);
			    Entity entity = default;
			    bool isSuccessCreation = false;
			    Exception exception = default;
			    try {
			        isSuccessCreation = EntityCreator.Create(webhook, UserConnection, out entity);
			    }
			    catch (Exception ex) {
			        exception = ex;
			    }
			    SetProcessLinkedInParameters(webhook, entity, isSuccessCreation, exception);
			}

		#endregion

	}

	#endregion

}

