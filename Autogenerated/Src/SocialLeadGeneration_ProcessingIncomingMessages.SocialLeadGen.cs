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
	using System.Linq;
	using System.Text;

	#region Class: SocialLeadGeneration_ProcessingIncomingMessagesMethodsWrapper

	/// <exclude/>
	public class SocialLeadGeneration_ProcessingIncomingMessagesMethodsWrapper : ProcessModel
	{

		public SocialLeadGeneration_ProcessingIncomingMessagesMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ScriptTask1Execute", ScriptTask1Execute);
		}

		#region Methods: Private

		private bool ScriptTask1Execute(ProcessExecutingContext context) {
			try {
				var webhookMessage = Get<string>("InputMessage");
				var messageNotifyWebhook = WebhookParser.ParseMessageNotify(webhookMessage);
				ProcessWebhook(messageNotifyWebhook);
				Set("ParsingResult", true);
			} catch (Exception exception) {
				Set("ErrorMessage", exception.ToString());
				Set("ParsingResult", false);
				return true;
			}
			return true;
		}

			private bool IsContainsAnyCode(IEnumerable<MessageNotifyWebhook.Message> messages, IEnumerable<string> codes) =>
				messages.Any(x => codes.Contains(x.Code));
			
			private IEnumerable<string> GetNoAccessToAccountCodes() =>
				new string[] {
					"LinkedInHasNoAccessToAdAccount"
				};
			
			private IEnumerable<string> GetExpireSoonTokenCodes() =>
				new string[] {
					"LinkedInRefreshToken14DaysExpiration"
				};
				
			private IEnumerable<string> GetFailedToEnrichWebhookErrorCodes() =>
				new string[] {
					"LinkedEnrichInHasNoAccessToAdAccount"
				};
			
			private IEnumerable<string> GetTokenErrorCodes() =>
				new string[] {
					"LinkedInTokenExpired",
					"LinkedInTokenRevoked",
					"LinkedInTokenUnknown",
					"LinkedInRefreshTokenExpired",
					"LinkedInRefreshTokenFail"
				};
			
			private void ProcessWebhook(MessageNotifyWebhook messageWebhook) {
				if (messageWebhook == default || messageWebhook.Messages == default) {
					Set("ErrorMessage", "Webhook is empty or null");
				}
				Set("NoAccessToAccount", IsContainsAnyCode(messageWebhook.Messages, GetNoAccessToAccountCodes()));
				Set("TokenWillExpireSoon", IsContainsAnyCode(messageWebhook.Messages, GetExpireSoonTokenCodes()));
				Set("TokenErrors", IsContainsAnyCode(messageWebhook.Messages, GetTokenErrorCodes()));
				Set("FailedToEnrichWebhook", IsContainsAnyCode(messageWebhook.Messages, GetFailedToEnrichWebhookErrorCodes()));
			}

		#endregion

	}

	#endregion

}

