define("SystemDesigner", function() {
	return {
		attributes: {
			/**
			 * Flag that indicates feature "Deduplication" enabled.
			 */
			"IsDeduplicationEnable": {
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
				operationRights.navigateToDuplicatesSettings = "CanManageDuplicatesRules";
				return operationRights;
			},

			/**
			 * @inheritodoc SystemDesigner#setDefaultParameters
			 * @overridden
			 */
			setDefaultParameters: function() {
				this.callParent(arguments);
				var isElasticDeduplicationEnabled = this.getIsFeatureEnabled("ESDeduplication");
				var isDeduplicationEnabled = this.getIsFeatureEnabled("Deduplication");
				var isEnabled = isElasticDeduplicationEnabled || isDeduplicationEnabled;
				this.set("IsDeduplicationEnable", isEnabled);
			},

			/**
			 * ######### ####### # ###### Duplication rule.
			 * @private
			 */
			navigateToDuplicatesSettings: function() {
				var duplicationModuleStructure = BPMSoft.configuration.ModuleStructure.DuplicatesRule;
				if (duplicationModuleStructure) {
					var newHash = BPMSoft.combinePath(duplicationModuleStructure.sectionModule,
						duplicationModuleStructure.sectionSchema);
					this.sandbox.publish("PushHistoryState", {hash: newHash});
				}
			}

		},
		diff: [
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "SystemSettingsTile",
				"name": "DuplicatesSettingsSection",
				"index": 2,
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.DuplicatesSettingsLinkCaption"},
					"tag": "navigateToDuplicatesSettings",
					"click": {"bindTo": "invokeOperation"},
					"visible": {"bindTo": "IsDeduplicationEnable"}
				}
			}
		]
	};
});
