define("MLTextSimilarityModelPage", ["MLConfigurationConsts",
		"MLListPredictionMixin"], function(MLConfigurationConsts) {
	return {
		entitySchemaName: "MLModel",
		mixins: {
			MLListPredictionMixin: "BPMSoft.MLListPredictionMixin"
		},
		attributes: {
			/**
			 * Lookup selection column for ListPredictResultSchemaUId.
			 */
			"PredictionSchema": {
				"dataValueType": BPMSoft.DataValueType.LOOKUP,
				"isLookup": true,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
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
				"caption": {"bindTo": "Resources.Strings.ListPredictResultSubjectСaption"}
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
				"caption": {"bindTo": "Resources.Strings.ListPredictResultObjectСaption"}
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
					"schemaAttribute": "RootSchema"
				}
			},

			/**
			 * Search config for list predict object column autocompletion.
			 */
			"ListPredictObjectColumnSearchConfig": {
				"dataValueType": BPMSoft.DataValueType.OBJECT,
				"value": {
					"schemaAttribute": "PredictionSchema"
				}
			}
		},
		methods: {

			_loadPredictionColumnsSelectionModule: function() {
				this.sandbox.loadModule("MLColumnSelectionModule", {
					"id": "PredictionColumnSelectionModule",
					"renderTo": "PredictionColumnSelectionModule",
					"instanceConfig": {
						"isSchemaConfigInitialized": true,
						"useHistoryState": false,
						"rootSchema": "PredictionSchema",
						"columnType": MLConfigurationConsts.MLModelColumnTypes.Prediction
					}
				});
			},

			getTrainColumnsSelectionModuleConfig: function() {
				const parentConfig = this.callParent(arguments);
				parentConfig.instanceConfig.columnType = MLConfigurationConsts.MLModelColumnTypes.Training
				return parentConfig;
			},

			/**
			 * @inheritDoc
			 * @overriden
			 */
			onEntityInitialized: function() {
				this.callParent(arguments);
				this.set("PredictionColumnCollection", this.Ext.create("BPMSoft.BaseViewModelCollection"));
				this.initializeSchemaColumns("PredictionSchemaColumns", "PredictionSchema",
					"PredictionSchemaColumnsList", function() {
						this._loadPredictionColumnsSelectionModule();
						this.initializeListPredictionResultSchemaColumns(function() {
							this._initializeListPredictionResultColumns();
						}, this);
					}, this);
			},

			/**
			 * @inheritDoc
			 * @overriden
			 */
			getSelectionModuleInfoCollection: function(attributeName) {
				if (attributeName === "PredictionSchema") {
					return this.$PredictionColumnCollection;
				}
				return this.callParent(arguments);
			},

			/**
			 * @inheritDoc
			 * @overriden
			 */
			initializeAdditionalSchemas: function() {
				this.initializeSchema("PredictionSchema");
				this.initializeListPredictionResultSchema();
			},

			/**
			 * @inheritDoc
			 * @overriden
			 */
			getColumnSelectionModuleLocalizableStrings: function(attributeName) {
				if (attributeName === "PredictionSchema") {
					return {
						title: this.get("Resources.Strings.SimilarObjectSelectionColumnsGroupCaption"),
						helpText: this.get("Resources.Strings.SimilarObjectColumnSelectionTipText")
					};
				}
				return this.callParent(arguments);
			},

			/**
			 * @inheritDoc
			 * @overriden
			 */
			columnDataValueTypeFilter: function(dataValueType) {
				return BPMSoft.isTextDataValueType(dataValueType);
			},

			/**
			 * @inheritDoc
			 * @overriden
			 */
			getRootSchemaHint: function() {
				return this.get("Resources.Strings.SubjectObjectSchemasTipContent");
			},

			/**
			 * @inheritDoc
			 * @overriden
			 */
			getColumnSelectionModulesSandboxTags: function() {
				const parentModules = this.callParent(arguments);
				parentModules.push("PredictionColumnSelectionModule");
				return parentModules;
			},

			/**
			 * Reloads prediction columns selection module on card rerender. 
			 */
			updatePredictionQueryColumnSelectionModule: function () {
				this._updateColumnSelectionModule(this._loadPredictionColumnsSelectionModule);
			}
		},
		diff: [
			{
				"name": "MetricIndicator",
				"operation": "remove"
			},
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
				"operation": "merge",
				"name": "RootSchema",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.RootEntityCaption"
					}
				}
			},
			{
				"operation": "insert",
				"name": "TrainingQueryColumnSelectionModule",
				"parentName": "ModelSettingsTab",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.MODULE,
					"afterrerender": {
						"bindTo": "updateTrainingQueryColumnSelectionModule"
					}
				},
				"index": 1
			},
			{
				"operation": "insert",
				"name": "PredictionColumnSelectionModule",
				"parentName": "ModelSettingsTab",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.MODULE,
					"afterrerender": {
						"bindTo": "updatePredictionQueryColumnSelectionModule"
					}
				},
				"index": 2
			},
			{
				"name": "PredictionSchema",
				"parentName": "ProfileContainer",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"caption": {"bindTo": "Resources.Strings.PredictionSchemaCaption"},
					"bindTo": "PredictionSchema",
					"controlConfig": {
						"prepareList": {
							"bindTo": "prepareRootSchemaList"
						}
					},
					"layout": {
						"column": 0,
						"row": 3,
						"colSpan": 24
					},
					"tip": {
						"content": {"bindTo": "getRootSchemaHint"}
					},
					"dataValueType": BPMSoft.DataValueType.ENUM,
					"enabled": {"bindTo": "isAddMode"}
				}
			},
			{
				"name": "TextSimilarityResultSavingGroup",
				"parentName": "ModelSettingsTab",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"caption": {
						"bindTo": "Resources.Strings.ResultSavingGroupCaption"
					},
					"tools": [],
					"items": [],
					"controlConfig": {}
				},
				"index": 3
			},
			{
				"name": "TextSimilarityResultSavingGridLayout",
				"parentName": "TextSimilarityResultSavingGroup",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			},
			{
				"name": "ListPredictResultSchema",
				"parentName": "TextSimilarityResultSavingGridLayout",
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
						"bindTo": "Resources.Strings.ListPredictResultSchemaCaption"
					},
					"dataValueType": BPMSoft.DataValueType.ENUM
				}
			},
			{
				"name": "ListPredictResultSubjectColumnLookup",
				"parentName": "TextSimilarityResultSavingGridLayout",
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
						"bindTo": "Resources.Strings.ListPredictResultSubjectCaption"
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
				"parentName": "TextSimilarityResultSavingGridLayout",
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
						"bindTo": "Resources.Strings.ListPredictResultObjectCaption"
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
				"parentName": "TextSimilarityResultSavingGridLayout",
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
						"bindTo": "Resources.Strings.ListPredictResultValueCaption"
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
				"parentName": "TextSimilarityResultSavingGridLayout",
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
						"bindTo": "Resources.Strings.ListPredictResultModelCaption"
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
				"parentName": "TextSimilarityResultSavingGridLayout",
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
						"bindTo": "Resources.Strings.ListPredictResultDateCaption"
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
				"name": "LowerScoreThreshold",
				"parentName": "TrainingColumnGroupGrid",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"bindTo": "LowerScoreThreshold",
					"layout": {
						"column": 13,
						"row": 0,
						"colSpan": 11
					},
				}
			}
		]
	};
});
