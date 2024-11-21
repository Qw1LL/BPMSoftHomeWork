define("SyncModule", ["ext-base", "BPMSoft"], function(Ext, BPMSoft) {

	/**
	 * ############## ######.
	 */
	function init() {
		BPMSoft.ServerChannel.on(BPMSoft.EventName.ON_MESSAGE, onChannelMessage, this);
	}

	/**
	 * ############ ######### ########## ###### #########.
	 * @protected
	 * @param {Object} scope ######## ##########.
	 * @param {Object} message ###### #########.
	 */
	function onChannelMessage(scope, message) {
		if (Ext.isEmpty(message) || Ext.isEmpty(window.console)) {
			return;
		}
		var header = message.Header;
		if (Ext.isEmpty(header) || (header.Sender !== "SyncMsgLogger")) {
			return;
		}
		var body = message.Body;
		switch (header.BodyTypeName) {
			case "Info":
				window.console.log(body);
				break;
			case "Error":
				window.console.error(body);
				break;
			default:
				break;
		}
	}

	return {
		init: init
	};
});
