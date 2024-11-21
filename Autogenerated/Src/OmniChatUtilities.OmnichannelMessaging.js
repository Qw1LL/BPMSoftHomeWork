define("OmniChatUtilities", ["NetworkUtilities"], function(NetworkUtilities) {

	/**
	 * Class utility methods for working with omnichannel chats.
	 */
	Ext.define("BPMSoft.utilities.OmniChatUtilities", {
		extend: "BPMSoft.core.BaseObject",
		alternateClassName: "BPMSoft.OmniChatUtilities",

		/**
		 * Opens contact card.
		 * @param {Object} event Click event.
		 */
		openContactCard: function(event) {
			const contactId = event.detail.contactId;
			const historyState = this.sandbox.publish("GetHistoryState");
			if (contactId !== (historyState.hash && historyState.hash.recordId)) {
				NetworkUtilities.openEntityPage({
					entityId: contactId,
					entitySchemaName: "Contact",
					sandbox: this.sandbox
				});
			}
		},

		/**
		 * Opens account card.
		 * @param {Object} event Click event.
		 */
		openAccountCard: function(event) {
			const accountId = event.detail.accountId;
			const historyState = this.sandbox.publish("GetHistoryState");
			if (accountId !== (historyState.hash && historyState.hash.recordId)) {
				NetworkUtilities.openEntityPage({
					entityId: accountId,
					entitySchemaName: "Account",
					sandbox: this.sandbox
				});
			}
		}
	});

	return Ext.create("BPMSoft.OmniChatUtilities");
});
