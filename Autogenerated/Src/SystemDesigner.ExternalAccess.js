define("SystemDesigner", [], function() {
	return {
		methods: {
			/**
			 * Opens access section.
			 * @private
			 */
			navigateToExternalAccessSection: function() {
				this.openSection("ExternalAccessSection");
			},
			/**
			 * @return {Boolean} True if external access enabled.
			 * @private
			 */
			_isExternalAccessEnabled: function() {
				return !this.getIsFeatureEnabled("DisableExternalAccess");
			}
		},
		diff: [
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "UsersTile",
				"name": "ExternalAccessSection",
				"index": 7,
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.ExtAccessSectionCaption"},
					"tag": "navigateToExternalAccessSection",
					"click": {"bindTo": "invokeOperation"},
					"visible": {"bindTo": "_isExternalAccessEnabled"}
				}
			}
		]
	};
});
