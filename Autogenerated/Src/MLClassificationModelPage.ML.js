define("MLClassificationModelPage", ["MLConfigurationConsts"],
	function(MLConfigurationConsts) {
		return {
			entitySchemaName: "MLModel",
			attributes: {
			},
			methods: {
				/**
				 * @returns {Boolean} True if ConfidentValueLowEdge field should be visible.
				 */
				getIsConfidentValueLowEdgeVisible: function() {
					return this.getLookupValue("MLConfidentValueMethod")
						=== MLConfigurationConsts.ConfidentValueMethods.MaximumProbability;
				},

				/**
				 * @inheritDoc
				 * @overriden
				 */
				filterTargetColumns: function(column) {
					return this.callParent(arguments) && BPMSoft.isLookupDataValueType(column.dataValueType);
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"name": "ClassificationAcademyUrl",
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
						"caption": "$Resources.Strings.ClassificationAcademyCaption",
						"tag": {"contextHelpId": 1940}
					}
				},
				{
					"name": "MLConfidentValueMethod",
					"parentName": "TrainingColumnGroupGrid",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 13,
							"row": 0,
							"colSpan": 11
						}
					}
				},
				{
					"name": "ConfidentValueLowEdge",
					"parentName": "TrainingColumnGroupGrid",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"visible": {
							"bindTo": "MLConfidentValueMethod",
							"bindConfig": {"converter": "getIsConfidentValueLowEdgeVisible"}
						},
						"layout": {
							"column": 13,
							"row": 1,
							"colSpan": 11
						}
					}
				}
			]/**SCHEMA_DIFF*/,
			userCode: {}
		};
	});
