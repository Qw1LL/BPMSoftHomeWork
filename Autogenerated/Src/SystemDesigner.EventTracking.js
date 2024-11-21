define("SystemDesigner", function() {
	return {
		methods: {
			/**
			 * @inheritodoc SystemDesigner#getOperationRightsDecoupling
			 * @overridden
			 */
			getOperationRightsDecoupling: function() {
				var operationRights = this.callParent(arguments);
				operationRights.navigateToEventTracking = "CanManageEventTracking";
				return operationRights;
			},

			/**
			 * Navigates to "EventTracking" section.
			 * @private
			 */
			navigateToEventTracking: function() {
				if (this.get("CanManageEventTracking") === true) {
					this.sandbox.publish("PushHistoryState", {hash: "SectionModuleV2/SiteEventTypeSection"});
				} else {
					this.showPermissionsErrorMessage("CanManageEventTracking");
				}
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "IntegrationTile",
				"name": "EventTrackingSetup",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.SiteEventTypeCaption"},
					"tag": "navigateToEventTracking",
					"click": {"bindTo": "invokeOperation"}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
