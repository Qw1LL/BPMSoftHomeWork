define("MLScoringModelPage", [], function() {
	return {
		entitySchemaName: "MLModel",
		attributes: {
			"TargetColumnEnabled": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				value: false
			}
		},
		methods: {
			/**
			 * @inheritDoc
			 * @override
			 */
			onEntityInitialized: function() {
				this.callParent(arguments);
				this.updateTrainingOutputFilterModule();
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			onRootSchemaChanged: function() {
				this.callParent(arguments);
				this.updateTrainingOutputFilterModule();
			},

			/**
			 * @return {Boolean} True if RootSchema is not set.
			 */
			getIsRootSchemaNotSet: function() {
				return this.Ext.isEmpty(this.$RootSchema);
			},
			/**
			 * Returns Target expression group caption.
			 * @return {String}
			 */
			getTargetColumnGroupCaption: function() {
				return this.get("Resources.Strings.TargetColumnGroup_Filters_Caption");
			},

			/**
			 * Returns Target expression group tip content.
			 * @return {String}
			 */
			getTargetColumnGroupInfoButtonContent: function() {
				return this.get("Resources.Strings.TargetColumnGroupInfoButton_Filters_Content");
			},

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
				"name": "ScoringAcademyUrl",
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
					"caption": "$Resources.Strings.ScoringAcademyCaption",
					"tag": {"contextHelpId": 1942}
				}
			},
			{
				"name": "TargetColumnGroupEmptyRootSchemaLabel",
				"parentName": "TargetColumnGroup",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": "$Resources.Strings.RootSchemaNotSet",
					"visible": {
						"bindTo": "getIsRootSchemaNotSet"
					},
					"labelConfig": {
						"classes": ["placeholder-label"]
					}
				}
			},
			{
				"name": "TrainingOutputFilterDataContainer",
				"parentName": "TargetColumnGroup",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 24
					},
					"id": "TrainingOutputFilterDataContainer",
					"selectors": {"wrapEl": "#TrainingOutputFilterDataContainer"},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["training-filters-container"],
					"beforererender": {"bindTo": "unloadTrainingOutputFilterUnitModule"},
					"afterrender": {"bindTo": "updateTrainingOutputFilterModule"},
					"afterrerender": {"bindTo": "updateTrainingOutputFilterModule"}
				}
			}
		]
	};
});
