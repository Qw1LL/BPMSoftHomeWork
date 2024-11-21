define("GoogleServiceRequest", ["SocialNetworkServiceRequest"], function() {
	Ext.define("BPMSoft.configuration.social.GoogleServiceRequest", {
		extend: "BPMSoft.SocialNetworkServiceRequest",
		alternateClassName: "BPMSoft.GoogleServiceRequest",

		/**
		 * @inheritdoc BPMSoft.ConfigurationServiceRequest#serviceName
		 * @overridden
		 */
		serviceName: "GoogleService",

		/**
		 * @inheritdoc BPMSoft.BaseRequest#getSerializableObject
		 * @overridden
		 */
		getSerializableObject: function(serializableObject) {
			this.callParent(arguments);
			var request = serializableObject.request = serializableObject.request || {};
			if (this.consumerInfo) {
				request.consumerInfo = this.consumerInfo;
			}
		}
	});
});
