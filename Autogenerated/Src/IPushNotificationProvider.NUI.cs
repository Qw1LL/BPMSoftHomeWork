namespace BPMSoft.Configuration
{
	using System.Collections.Generic;

	#region Interface: IPushNotificationProvider

	/// <summary>
	/// Interface of push notification providers.
	/// </summary>
	public interface IPushNotificationProvider
	{
		void Send(PushNotificationData data);
	}

	#endregion

	#region Class: PushNotificationData

	/// <summary>
	/// Represents push notification data.
	/// </summary>
	public class PushNotificationData
	{
		public string Token {
			get;
			set;
		}

		public string Title {
			get;
			set;
		}

		public string Message {
			get;
			set;
		}

		public Dictionary<string, string> AdditionalData {
			get;
			set;
		}
	}

	#endregion

}
