namespace BPMSoft.Configuration.Omnichannel.Messaging
{
	using System;

	public static class OmnichannelMessagingConsts
	{

		public static readonly Guid CompletedChatStatus = new Guid("A1B0184B-0A54-4A47-BA08-A5772105D3B2");
		public static readonly Guid WaitingForProcessing = new Guid("79BCCFFA-8C8B-4863-B376-A69D2244182B");
		public static readonly Guid InProgressChatStatus = new Guid("81737BDD-60C7-4EF7-BB75-52C53D5C38C1");
		public static readonly Guid BotProcessingChatStatus = new Guid("B05FBF72-69ED-41A7-BE7C-AF3EC13B08C7");
		public const string QueueOperatorsCacheKey = "OmnichannelQueueOperators";
		public const string DefaultQueueOperatorRoutingRule = "ForEveryone";
		public const string QueueOperatorRoutingRuleForEveryone = "ForEveryone";
		public const string QueueOperatorRoutingRuleForFree = "ForFree";
		public const string QueueOperatorRoutingRulesCacheKey = "OmnichannelQueueOperatorRoutingRules";
		public const string ChatQueueCacheKeyMask = "ChatQueue_{0}";
		public static class OperatorState {
			public static class Active {
				public const string Code = "Active";
				public static readonly Guid Id = new Guid("A2922EE1-9BC4-4524-979A-D6E804FC1F56");
				public const bool OperatorAvailable = true;
			}
			public static class Inactive {
				public const string Code = "Inactive";
				public static readonly Guid Id = new Guid("314CCE15-9847-4DB3-B93C-D1E6EA175B23");
				public const bool OperatorAvailable = false;
			}
		}
		public static class Scheduler {
			public static class OperatorTimeoutJob {
				public const string JobGroup = "OmniChatOperatorTimeout";
				public const string JobNameTpl = "OmniChatOperator_Chat_{0}";
				public const string TimeoutSettingCode = "OmniChatOperatorAcceptChatTimeout";
				public const int DefOperatorTimeoutInMinutes = 5;
			}
		}

		public static readonly Guid TelegramProvider = new Guid("645170ab-c67a-4dcc-9def-c0e5236bdfe0");
		public static readonly Guid FacebookProvider = new Guid("50491C6C-D82B-4B86-B38C-99262D11A5AC");
		public static readonly Guid WhatsappProvider = new Guid("1398DC73-B428-4E21-B97A-C1BB6B4BC621");
	}
}
