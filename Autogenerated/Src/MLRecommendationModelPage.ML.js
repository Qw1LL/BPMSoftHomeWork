define("MLRecommendationModelPage", ["ConfigurationEnums", "css!MLModelPageCSS", "MLListPredictionMixin"],
	function() {
		return {
			entitySchemaName: "MLModel",
			attributes: {
				"BatchPredictionEnabled": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					value: false
				},
				"TargetColumnEnabled": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					value: false
				},

				/**
				 * Virtual column for CFUserColumnPath.
				 */
				"CFUserColumn": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"caption": {"bindTo": "getCFColumnCaption"}
				},

				/**
				 * Virtual column for CFItemColumnPath.
				 */
				"CFItemColumn": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"caption": {"bindTo": "getCFColumnCaption"}
				},

				/**
				 * Virtual column for CFInteractionValueColumnPath.
				 */
				"CFInteractionValueColumn": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"caption": {"bindTo": "getCFInteractionValueColumnCaption"}
				},
				/**
				 * Lookup selection column for ListPredictResultSchemaUId.
				 */
				"ListPredictResultSchema": {
					"dataValueType": BPMSoft.DataValueType.LOOKUP,
					"isLookup": true,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Virtual column for ListPredictResultSchemaUId.
				 */
				"ListPredictResultSchemaUId": {
					"dependencies": [
						{
							"columns": ["ListPredictResultSchema"],
							"methodName": "onListPredictionResultSchemaChanged"
						}
					]
				},

				/**
				 * Lookup selection column for ListPredictResultSubjectColumn.
				 */
				"ListPredictResultSubjectColumnLookup": {
					"dataValueType": BPMSoft.DataValueType.LOOKUP,
					"isLookup": true,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"caption": {"bindTo": "Resources.Strings.CFResultUserCaption"}
				},

				/**
				 * Virtual column for ListPredictResultSubjectColumn.
				 */
				"ListPredictResultSubjectColumn": {
					"dependencies": [
						{
							"columns": ["ListPredictResultSubjectColumnLookup"],
							"methodName": "onListPredictionResultColumnLookupAttributeChange"
						}
					]
				},

				/**
				 * Lookup selection column ListPredictResultItemColumn.
				 */
				"ListPredictResultObjectColumnLookup": {
					"dataValueType": BPMSoft.DataValueType.LOOKUP,
					"isLookup": true,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"caption": {"bindTo": "Resources.Strings.CFResultItemCaption"}
				},

				/**
				 * Virtual column for ListPredictResultItemColumn.
				 */
				"ListPredictResultObjectColumn": {
					"dependencies": [
						{
							"columns": ["ListPredictResultObjectColumnLookup"],
							"methodName": "onListPredictionResultColumnLookupAttributeChange"
						}
					]
				},

				/**
				 * Lookup selection column for ListPredictResultValueColumn.
				 */
				"ListPredictResultValueColumnLookup": {
					"dataValueType": BPMSoft.DataValueType.LOOKUP,
					"isLookup": true,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Virtual column for ListPredictResultValueColumn.
				 */
				"ListPredictResultValueColumn": {
					"dependencies": [
						{
							"columns": ["ListPredictResultValueColumnLookup"],
							"methodName": "onListPredictionResultColumnLookupAttributeChange"
						}
					]
				},

				/**
				 * Lookup selection column for ListPredictResultModelColumn.
				 */
				"ListPredictResultModelColumnLookup": {
					"dataValueType": BPMSoft.DataValueType.LOOKUP,
					"isLookup": true,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Virtual column for ListPredictResultModelColumn.
				 */
				"ListPredictResultModelColumn": {
					"dependencies": [
						{
							"columns": ["ListPredictResultModelColumnLookup"],
							"methodName": "onListPredictionResultColumnLookupAttributeChange"
						}
					]
				},

				/**
				 * Lookup selection column for ListPredictResultTimestampColumn.
				 */
				"ListPredictResultDateColumnLookup": {
					"dataValueType": BPMSoft.DataValueType.LOOKUP,
					"isLookup": true,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Virtual column for ListPredictResultTimestampColumn
				 */
				"ListPredictResultTimestampColumn": {
					"dependencies": [
						{
							"columns": ["ListPredictResultDateColumnLookup"],
							"methodName": "onListPredictionResultColumnLookupAttributeChange"
						}
					]
				},

				/**
				 * Indicates load state of list prediction result schema.
				 */
				"ListPredictResultSchemaInitialized": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Search config for list predict subject column autocompletion.
				 */
				"ListPredictSubjectColumnSearchConfig": {
					"dataValueType": BPMSoft.DataValueType.OBJECT,
					"value": {
						"columnPathAttribute": "CFUserColumnPath"
					}
				},

				/**
				 * Search config for list predict object column autocompletion.
				 */
				"ListPredictObjectColumnSearchConfig": {
					"dataValueType": BPMSoft.DataValueType.OBJECT,
					"value": {
						"columnPathAttribute": "CFItemColumnPath"
					}
				}
			},
			mixins: {
				MLListPredictionMixin: "BPMSoft.MLListPredictionMixin"
			},
			methods: {

				getTrainColumnsSelectionModuleConfig: function() {
					return {};
				},

				/**
				 * Loads captions for CF columns paths.
				 * @private
				 */
				_initializeCFColumnCaptions: function() {
					if (Ext.isEmpty(this.$RootSchema)) {
						return;
					}
					const schemaName = this.$RootSchema.name;
					const serviceParameters = [
						{
							schemaName: schemaName,
							columnPath: this.$CFUserColumnPath,
							key: "CFUserColumn"
						},
						{
							schemaName: schemaName,
							columnPath: this.$CFItemColumnPath,
							key: "CFItemColumn"
						},
						{
							schemaName: schemaName,
							columnPath: this.$CFInteractionValueColumnPath,
							key: "CFInteractionValueColumn"
						}
					];
					this.getColumnPathCaption(this.Ext.JSON.encode(serviceParameters), function(captionConfigs) {
						BPMSoft.each(captionConfigs, function(captionConfig) {
							this.set(captionConfig.key, captionConfig.columnCaption);
						}, this);
					}, this);
				},

				/**
				 * @inheritDoc
				 * @overriden
				 */
				initializeAdditionalSchemas: function() {
					this.initializeListPredictionResultSchema();
				},

				onEntityInitialized: function() {
					this.callParent(arguments);
					this.initializeListPredictionResultSchemaColumns(function() {
						this._initializeListPredictionResultColumns();
						this._initializeCFColumnCaptions();
					}, this);
				},

				columnChanged: function() {
					this._updateTrainButtonConfig();
				},

				/**
				 * Returns caption of CF column.
				 * @return {String}
				 */
				getCFColumnCaption: function(columnName) {
					return this.getEntityColumnCaption(columnName + "Path");
				},

				/**
				 * Returns caption of CFInteractionValueColumn.
				 * @return {String}
				 */
				getCFInteractionValueColumnCaption: function() {
					return this.getEntityColumnCaption("CFInteractionValueColumnPath");
				},

				/**
				 * Returns hint of CFInteractionValueColumn.
				 * @return {String}
				 */
				getCFInteractionValueColumnHint: function() {
					return this.get("Resources.Strings.CFInteractionValueColumnHint");
				},

				/**
				 * Returns RootSchema column caption depending on problem type.
				 * @return {String}
				 */
				getRootSchemaCaption: function() {
					return this.get("Resources.Strings.CFRootSchemaCaption");
				},

				/**
				 * Returns RootSchema column hint depending on problem type.
				 * @return {String}
				 */
				getRootSchemaHint: function() {
					return this.get("Resources.Strings.CFRootSchemaHint");
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
				getColumnSelectionModulesSandboxTags: function() {
					return [];
				}
			},
			diff: [
				{
					"name": "MLExplanationContainer",
					"operation": "remove"
				},
				{
					"name": "TargetColumnGroup",
					"operation": "remove"
				},
				{
					"name": "PredictedResultColumnGroup",
					"operation": "remove"
				},
				{
					"operation": "remove",
					"name": "TrainingQueryColumnSelectionModule"
				},
				{
					"name": "CFUserColumn",
					"parentName": "ProfileContainer",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 24
						},
						"contentType": BPMSoft.ContentType.SHORT_TEXT,
						"enabled": {"bindTo": "isAddMode"}
					}
				},
				{
					"name": "CFItemColumn",
					"parentName": "ProfileContainer",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 24
						},
						"contentType": BPMSoft.ContentType.SHORT_TEXT,
						"enabled": {"bindTo": "isAddMode"}
					}
				},
				{
					"name": "CFInteractionValueColumn",
					"parentName": "ProfileContainer",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 5,
							"colSpan": 24
						},
						"contentType": BPMSoft.ContentType.SHORT_TEXT,
						"tip": {
							"content": {"bindTo": "getCFInteractionValueColumnHint"}
						},
						"enabled": {"bindTo": "isAddMode"}
					}
				},
				{
					"name": "CFAcademyUrl",
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
						"caption": "$Resources.Strings.RecommendationAcademyCaption",
						"tag": {"contextHelpId": 2077}
					}
				},
				{
					"name": "FactorsCountsEdit",
					"parentName": "TrainingColumnGroupGrid",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"bindTo": "FactorsCounts",
						"tip": {
							"content": "$Resources.Strings.ParametersAutofittingTipContent"
						},
						"layout": {
							"column": 13,
							"row": 0,
							"colSpan": 11
						}
					}
				},
				{
					"name": "RegularizationValuesEdit",
					"parentName": "TrainingColumnGroupGrid",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"bindTo": "RegularizationValues",
						"tip": {
							"content": "$Resources.Strings.ParametersAutofittingTipContent"
						},
						"layout": {
							"column": 13,
							"row": 1,
							"colSpan": 11
						}
					}
				},
				{
					"name": "CFResultSavingGroup",
					"parentName": "ModelSettingsTab",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
						"caption": {
							"bindTo": "Resources.Strings.CFResultGroupCaption"
						},
						"tools": [],
						"items": [],
						"controlConfig": {}
					}
				},
				{
					"name": "CFResultSavingGridLayout",
					"parentName": "CFResultSavingGroup",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"name": "ListPredictResultSchema",
					"parentName": "CFResultSavingGridLayout",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 11
						},
						"controlConfig": {
							"prepareList": {
								"bindTo": "prepareRootSchemaList"
							}
						},
						"bindTo": "ListPredictResultSchema",
						"caption": {
							"bindTo": "Resources.Strings.CFResultSchemaCaption"
						},
						"dataValueType": BPMSoft.DataValueType.ENUM
					}
				},
				{
					"name": "ListPredictResultSubjectColumnLookup",
					"parentName": "CFResultSavingGridLayout",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 11
						},
						"bindTo": "ListPredictResultSubjectColumnLookup",
						"caption": {
							"bindTo": "Resources.Strings.CFResultUserCaption"
						},
						"dataValueType": BPMSoft.DataValueType.ENUM,
						"controlConfig": {
							"prepareList": {
								"bindTo": "prepareListPredictionSchemaColumnLookupList"
							}
						},
						"isRequired": {
							"bindTo": "ListPredictResultSchema",
							"bindConfig": {
								"converter": "setListPredictionResultSubjectColumnRequired"
							}
						}
					}
				},
				{
					"name": "ListPredictResultObjectColumnLookup",
					"parentName": "CFResultSavingGridLayout",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 11
						},
						"bindTo": "ListPredictResultObjectColumnLookup",
						"caption": {
							"bindTo": "Resources.Strings.CFResultItemCaption"
						},
						"dataValueType": BPMSoft.DataValueType.ENUM,
						"controlConfig": {
							"prepareList": {
								"bindTo": "prepareListPredictionSchemaColumnLookupList"
							}
						},
						"isRequired": {
							"bindTo": "ListPredictResultSchema",
							"bindConfig": {
								"converter": "setListPredictionResultObjectColumnRequired"
							}
						}
					}
				},
				{
					"name": "ListPredictResultValueColumnLookup",
					"parentName": "CFResultSavingGridLayout",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 13,
							"row": 0,
							"colSpan": 11
						},
						"bindTo": "ListPredictResultValueColumnLookup",
						"caption": {
							"bindTo": "Resources.Strings.CFResultValueCaption"
						},
						"dataValueType": BPMSoft.DataValueType.ENUM,
						"controlConfig": {
							"prepareList": {
								"bindTo": "prepareListPredictionSchemaColumnLookupList"
							}
						}
					}
				},
				{
					"name": "ListPredictResultModelColumnLookup",
					"parentName": "CFResultSavingGridLayout",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 13,
							"row": 1,
							"colSpan": 11
						},
						"bindTo": "ListPredictResultModelColumnLookup",
						"caption": {
							"bindTo": "Resources.Strings.CFResultModelCaption"
						},
						"dataValueType": BPMSoft.DataValueType.ENUM,
						"controlConfig": {
							"prepareList": {
								"bindTo": "prepareListPredictionSchemaColumnLookupList"
							}
						}
					}
				},
				{
					"name": "ListPredictResultDateColumnLookup",
					"parentName": "CFResultSavingGridLayout",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 13,
							"row": 2,
							"colSpan": 11
						},
						"bindTo": "ListPredictResultDateColumnLookup",
						"caption": {
							"bindTo": "Resources.Strings.CFResultTimestampCaption"
						},
						"dataValueType": BPMSoft.DataValueType.ENUM,
						"controlConfig": {
							"prepareList": {
								"bindTo": "prepareListPredictionSchemaColumnLookupList"
							}
						}
					}
				}
			]
		};
	});
