define("SystemDesigner", ["SystemDesignerResources"], function (resources) {
	return {
		attributes: {
			/**
			 * Flag that indicates feature "Tracking" enabled.
			 */
			"IsTrackingEnabled": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: false
			}
		},
		methods: {
			/**
			 * @inheritodoc SystemDesigner#getOperationRightsDecoupling
			 * @overridden
			 */
			getOperationRightsDecoupling: function() {
				var operationRights = this.callParent(arguments);
				operationRights.navigateToTracking = "CanManageTracking";
				return operationRights;
			},
			/**
			 * @inheritodoc SystemDesigner#setDefaultParameters
			 * @overridden
			 */
			setDefaultParameters: function() {
				this.callParent(arguments);
				var isEnabled = this.getIsFeatureEnabled("Tracking");
				this.$IsTrackingEnabled = isEnabled;
			},
			/**
			 * Navigate to the Tracking settings.
			 * @private
			 */
			_navigateToTrackingSettings: function() {
				if (this.get("CanManageTracking") === true) {
					var url = BPMSoft.workspaceBaseUrl + "/ClientApp/#/Tracking";
					window.open(url, "_blank");
				} else {
					this.showPermissionsErrorMessage("CanManageTracking");
				}
			}

		},
		diff: [
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "IntegrationTile",
				"name": "TrackingSection",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": { "bindTo": "Resources.Strings.TrackingSettingsLinkCaption" },
					"tag": "_navigateToTrackingSettings",
					"click": "$invokeOperation",
					"visible": "$IsTrackingEnabled"
				}
			},
			{
				"operation": "remove",
				"name": "EventTrackingSetup"
			}
		]
	};
});
