define("SystemDesigner", function() {
	return {
		methods: {
			/**
			 * Returns true if feature BulkEmailUXEnabled is enabled.
			 * @private
			 * @returns {Boolean} True if feature BulkEmailUXEnabled is enabled.
			 */
			getIsBulkEmailUXEnabled: function() {
				return this.BPMSoft.Features.getIsEnabled("BulkEmailUX");
			},

			/**
			 * Opens mailing log.
			 */
			openBulkEmailEventLog: function() {
				this.sandbox.publish("PushHistoryState", {hash: "SectionModuleV2/BulkEmailEventLogSectionV2"});
			}

		},
		diff: [
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "IntegrationTile",
				"name": "OpenBulkEmailEventLog",
				"index": 3,
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.OpenBulkEmailEventLogCaption"},
					"tag": "openBulkEmailEventLog",
					"click": {"bindTo": "invokeOperation"}
				}
			}
		]
	};
});
