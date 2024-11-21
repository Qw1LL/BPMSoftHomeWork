namespace BPMSoft.Configuration
{
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	
	public static class CommunicationUtilities
	{
		#region Constants: Private
		
		private const string CommunicationNumberSessionDataKey = "CommunicationNumberSessionDataKey";
		
		#endregion
		
		#region Methods: Private
		
		private static string GetEventNameByCommunicationCode(string communicationCode) {
			string result;
			switch (communicationCode) {
				default:
					result = string.Empty;
					break;
			}
			return result;
		}
		
		private static string GetProcessUIdByCommunicationCode(UserConnection userConnection, string communicationCode) {
			string result;
			switch (communicationCode) {
				default:
					result = string.Empty;
					break;
			}
			return result;
		}
		
		#endregion
		
		#region Methods: Public
		
		public static string[] GetSelectedCommunicationNumbers(UserConnection userConnection) {
			return userConnection.SessionData[CommunicationNumberSessionDataKey] as string[];
		}
		
		public static void SetSelectedCommunicationNumbers(UserConnection userConnection, string[] value) {	
			userConnection.SessionData[CommunicationNumberSessionDataKey] = value;
		}
		
		public static string GetProcessConnectionAttemptScript(UserConnection userConnection, string communicationCode, string number) {
			SetSelectedCommunicationNumbers(userConnection, new string[] { number });
			string eventName = GetEventNameByCommunicationCode(communicationCode);
			string processUId = GetProcessUIdByCommunicationCode(userConnection, communicationCode);
			return string.Concat("var windowForEvent = window;",
				"if (window.opener) { windowForEvent = window.opener; } ",
				"if (windowForEvent.opener) { windowForEvent = windowForEvent.opener; } ",
				"var msgObject = new Object();",
				"msgObject.tag = ", Json.Serialize(number), ";",
				"var msg = Ext.util.JSON.encodeObject(msgObject, 3);",
				"windowForEvent.BPMSoft.AjaxMethods.ThrowClientEventWithParameters(",
				Json.Serialize(processUId), ", ",
				Json.Serialize(eventName), ", ",
				"msg);");
		}
		
		public static string GetProcessConnectionAttemptScript(UserConnection userConnection, string communicationCode) {
			string[] numbers = GetSelectedCommunicationNumbers(userConnection);
			if (numbers != null && numbers.Length > 0) {
				string number = numbers[0];
				string eventName = GetEventNameByCommunicationCode(communicationCode);
				string processUId = GetProcessUIdByCommunicationCode(userConnection, communicationCode);
				return string.Concat("var windowForEvent = window;",
					"if (window.opener) { windowForEvent = window.opener; } ",
					"if (windowForEvent.opener) { windowForEvent = windowForEvent.opener; } ",
					"var msgObject = new Object();",
					"msgObject.tag = ", Json.Serialize(number), ";",
					"var msg = Ext.util.JSON.encodeObject(msgObject, 3);",
					"windowForEvent.BPMSoft.AjaxMethods.ThrowClientEventWithParameters(",
					Json.Serialize(processUId), ", ",
					Json.Serialize(eventName), ", ",
					"msg);");
			}
			return string.Empty;
		}
		
		#endregion
		
	}
}
