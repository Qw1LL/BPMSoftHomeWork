 define("SystemDesigner", ["RightUtilities"], function(RightUtilities) {
	return {	
		methods: {
			/**
			 * Opens Integration with telephony section.
			 * @public
			 */
			navigateToTelephonyIntegrationSection: function() {
				var operationCode = "CanManageSolution";
				if (this.get(operationCode) === true) {
					this.openSection("TelephonyIntegrationSection");
				} else {
					this.showPermissionsErrorMessage(operationCode);
				}
				
			}
		},
		diff: [
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "IntegrationTile",
				"name": "TelephonyIntegration",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": "$Resources.Strings.TelephonyIntegrationCaption",
					"tag": "navigateToTelephonyIntegrationSection",
					"click": {"bindTo": "invokeOperation"}
				}
			}
		]
	};
});