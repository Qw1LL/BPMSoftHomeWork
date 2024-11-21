define("MLRegressionModelPage", [], function() {
	return {
		entitySchemaName: "MLModel",
		methods: {
			/**
			 * @inheritDoc
			 * @overriden
			 */
			filterTargetColumns: function(column) {
				return this.callParent(arguments) && BPMSoft.isNumberDataValueType(column.dataValueType);
			}
		},
		diff: [
			{
				"name": "RegressionAcademyUrl",
				"operation": "remove",
				"parentName": "FaqUrls",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"classes": {
						"textClass": ["faq-button", "base-edit-link"]
					},
					"click": {"bindTo": "onFaqClick"},
					"caption": "$Resources.Strings.RegressionAcademyCaption",
					"tag": {"contextHelpId": 1941}
				}
			}
		]
	};
});
