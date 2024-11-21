define("SystemDesigner", [], function() {
	return {
		methods: {
			openOAuthSection: function() {
				this.openSection("OAuthClientAppSection");
			},
			/**
			 * @return {Boolean} True if OAuth integration enabled.
			 * @private
			 */
			getIsOAuthIntegrationEnabled: function() {
				return this.getIsFeatureEnabled("OAuth20Integration");
			}
		},
		diff: [
			{
				"operation": "insert",
				"index": 1,
				"propertyName": "items",
				"parentName": "InstallExtensionsTile",
				"name": "OAuthSection",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.OAuthSectionCaption"},
					"tag": "openOAuthSection",
					"click": {"bindTo": "invokeOperation"},
					"visible": {"bindTo": "getIsOAuthIntegrationEnabled"}
				}
			}
		]
	};
});


