define(["SocialNetworkServiceRequest"], function() {
	Ext.define("BPMSoft.configuration.social.ExecuteCommandRequest", {
		extend: "BPMSoft.SocialNetworkServiceRequest",

		/**
		 * @inheritdoc BPMSoft.BaseRequest#contractName
		 * @overridden
		 */
		contractName: "ExecuteCommand",

		command: null,

		/**
		 * @inheritdoc BPMSoft.BaseRequest#getSerializableObject
		 * @overridden
		 */
		getSerializableObject: function(serializableObject) {
			this.callParent(arguments);
			var request = serializableObject.request = serializableObject.request || {};
			if (this.command) {
				request.command = this.command;
			}
		}
	});
});
