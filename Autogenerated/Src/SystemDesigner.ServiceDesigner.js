define("SystemDesigner", [], function() {
	return {
		methods: {
			/**
			 * Opens Web services section.
			 * @public
			 */
			navigateToWebServiceV2Section: function() {
				var operationCode = "CanManageSolution";
				if (this.get(operationCode) === true) {
					this.openSection("WebServiceV2Section");
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
				"name": "WebServiceV2Section",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": "$Resources.Strings.WebServicesCaption",
					"tag": "navigateToWebServiceV2Section",
					"click": {"bindTo": "invokeOperation"}
				}
			}
		]
	};
});
