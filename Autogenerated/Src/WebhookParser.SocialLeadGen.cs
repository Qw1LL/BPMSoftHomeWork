namespace BPMSoft.Configuration.SocialLeadGen
{
	using Newtonsoft.Json;

	#region Class: WebhookParser

	/// <summary>
	/// Webhook parser.
	/// </summary>
	public static class WebhookParser
	{

		#region Methods: Public

		/// <summary>
		/// Parse lead notify webhook data.
		/// </summary>
		/// <param name="data">Data which is need to be converted to the lead notify webhook object.</param>
		/// <returns>Lead notify webhook object.</returns>
		public static LeadNotifyWebhook ParseLeadNotify(string data) {
			return JsonConvert.DeserializeObject<LeadNotifyWebhook>(data);
		}

		/// <summary>
		/// Parse message notify webhook data.
		/// </summary>
		/// <param name="data">Data which is need to be converted to the message notify webhook object.</param>
		/// <returns>Message notify webhook object.</returns>
		public static MessageNotifyWebhook ParseMessageNotify(string data) {
			return JsonConvert.DeserializeObject<MessageNotifyWebhook>(data);
		}

		#endregion

	}

    #endregion

}
