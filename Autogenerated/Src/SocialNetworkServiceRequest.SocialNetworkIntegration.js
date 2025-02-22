﻿define(["ConfigurationServiceRequest"], function() {
	Ext.define("BPMSoft.configuration.social.SocialNetworkServiceRequest", {
		extend: "BPMSoft.ConfigurationServiceRequest",
		alternateClassName: "BPMSoft.SocialNetworkServiceRequest",

		consumerVersion: "",
		accessToken: "",
		consumerKey: "",
		consumerSecret: "",
		socialId: "",
		socialIds: null,
		type: "",
		user: "",

		/**
		 * @inheritdoc BPMSoft.ConfigurationServiceRequest#serviceName
		 * @overridden
		 */
		serviceName: "SocialNetworkService",

		/**
		 * @inheritdoc BPMSoft.BaseRequest#getSerializableObject
		 * @overridden
		 */
		getSerializableObject: function(serializableObject) {
			this.callParent(arguments);
			var request = serializableObject.request = serializableObject.request || {};
			if (this.consumerVersion) {
				request.consumerVersion = this.consumerVersion;
			}
			if (this.accessToken) {
				request.accessToken = this.accessToken;
			}
			if (this.consumerKey) {
				request.consumerKey = this.consumerKey;
			}
			if (this.consumerSecret) {
				request.consumerSecret = this.consumerSecret;
			}
			if (this.socialId) {
				request.socialId = this.socialId;
			}
			if (this.socialIds) {
				request.socialIds = this.socialIds;
			}
			if (this.type) {
				request.type = this.type;
			}
			if (this.user) {
				request.user = this.user;
			}
		}
	});
});
