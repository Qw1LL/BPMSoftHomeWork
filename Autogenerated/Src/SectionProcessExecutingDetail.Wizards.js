/**
 * @class BPMSoft.SectionProcessExecutingDetail
 * @extends BPMSoft.BaseProcessExecutingDetail
 */
define("SectionProcessExecutingDetail", ["SectionProcessSettingsManager"], function() {
	return {
		methods: {
			/**
			 * @inheritdoc DataManagerGridUtilities#getEntitySchemaName
			 * @override
			 */
			getEntitySchemaName: function() {
				return "ProcessInModules";
			},

			/**
			 * @inheritdoc BaseProcessExecutingDetail#getProcessRunnerManager
			 * @override
			 */
			getProcessRunnerManager: function() {
				return BPMSoft.SectionManager;
			},

			/**
			 * @inheritdoc BaseProcessExecutingDetail#getManagerName
			 * @override
			 */
			getManagerName: function() {
				return "SectionProcessSettingsManager";
			},

			/**
			 * @inheritdoc BaseProcessExecutingDetail#getManagerItemName
			 * @override
			 */
			getManagerItemName: function() {
				return "SectionProcessSettingsManagerItem";
			},

			/**
			 * @inheritdoc BaseProcessExecutingDetail#getIsParameterRequired
			 * @override
			 */
			getIsParameterRequired: function() {
				return false;
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"parentName": "Detail",
				"propertyName": "tools",
				"name": "AddRecordButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.AddButtonCaption"},
					"click": {"bindTo": "addRecord"},
					"classes": {
						"wrapperClass": ["right-icon"],
					},
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
					"imageConfig": {
						"bindTo": "Resources.Images.AddButtonWhite",
					},
					"clickDebounceTimeout": 1000
				}
			},
			]
	};
});
