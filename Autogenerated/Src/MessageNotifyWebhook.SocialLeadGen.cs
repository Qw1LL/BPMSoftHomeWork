namespace BPMSoft.Configuration.SocialLeadGen
{
	using Newtonsoft.Json;
	using System.Collections.Generic;

	#region Class: WebhookParser

	/// <summary>
	/// Message notify webhook.
	/// </summary>
	[JsonObject(MemberSerialization.OptIn)]
	public class MessageNotifyWebhook
	{

		#region Class: Message

		/// <summary>
		/// Describes single message for notify.
		/// </summary>
		public class Message
		{
			/// <summary>
			/// Message code which describes what happens.
			/// </summary>
			[JsonProperty("code")]
			public string Code { get; set; }

			/// <summary>
			/// Message type.
			/// </summary>
			[JsonProperty("type")]
			public int Type { get; set; }

			/// <summary>
			/// Detailed description of message.
			/// </summary>
			[JsonProperty("description")]
			public string Description { get; set; }
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Messages collection.
		/// </summary>
		[JsonProperty("messages")]
		public IEnumerable<Message> Messages { get; set; }

		#endregion

	}

	#endregion

}
