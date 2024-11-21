 define("SystemDesigner", ["SystemDesignerResources"], function(resources) {
	return {
		attributes: {
			/**
			 * Flag that indicates feature "Tracking" enabled.
			 */
			"IsSocialLeadGenSectionEnabled": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: false
			}
		},
		methods: {
			/**
			 * @inheritodoc SystemDesigner#setDefaultParameters
			 * @overridden
			 */
			setDefaultParameters: function() {
				this.callParent(arguments);
				var isEnabled = this.getIsFeatureEnabled("SocialLeadGenSection");
				this.$IsSocialLeadGenSectionEnabled = isEnabled;
			},

			/**
			 * Navigate to the Tracking settings.
			 * @private
			 */
			_navigateToSocialLeadGenSection: function() {
				const url = BPMSoft.workspaceBaseUrl + "/ClientApp/#/SocialLeadgen";
				window.open(url, "_blank");
			}

		},
		diff: [
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "IntegrationTile",
				"name": "SocialLeadGenSection",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.SocialLeadGenLinkCaption"},
					"tag": "_navigateToSocialLeadGenSection",
					"click": "$invokeOperation",
					"visible": "$IsSocialLeadGenSectionEnabled"
				}
			}
		]
	};
});
