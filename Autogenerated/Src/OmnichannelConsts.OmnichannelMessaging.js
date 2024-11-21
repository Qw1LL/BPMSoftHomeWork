define("OmnichannelConsts", [], function() {
	const chatStatus = {
		Completed: "a1b0184b-0a54-4a47-ba08-a5772105d3b2"
	};

	const channelProviders = {
		Facebook: "50491c6c-d82b-4b86-b38c-99262d11a5ac",
		Telegram: "645170ab-c67a-4dcc-9def-c0e5236bdfe0",
		WhatsApp: "1398dc73-b428-4e21-b97a-c1bb6b4bc621"
	};

	const omniChatSchemaUId = "af1f685c-315b-4b44-a957-c5094417a57a";

	return {
		Status: chatStatus,
		OmniChatSchemaUId: omniChatSchemaUId,
		ChannelProviders: channelProviders
	};
});
