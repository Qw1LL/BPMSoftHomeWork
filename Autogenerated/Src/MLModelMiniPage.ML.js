define("MLModelMiniPage", ["MLConfigurationConsts", "MLModelPageResources", "MLTextSimilarityModelPageResources",
		"MLRecommendationModelPageResources", "RootSchemaLookupMixin"],
	function(MLConfigurationConsts, modelPageResources, textSimilarityModelPageResources,
			 recommendationModelPageResources) {
		return {
			entitySchemaName: "MLModel",
			mixins: {
				RootSchemaLookupMixin: "BPMSoft.RootSchemaLookupMixin"
			},
			attributes: {
				"MiniPageModes": {
					"value": [this.BPMSoft.ConfigurationEnums.CardOperation.ADD]
				},

				/**
				 * Root schema lookup value.
				 */
				"RootSchema": {
					"dataValueType": BPMSoft.DataValueType.LOOKUP,
					"isLookup": true,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"isRequired": true
				},

				/**
				 * Uid of the root schema.
				 */
				"RootSchemaUId": {
					"dependencies": [
						{
							"columns": ["RootSchema"],
							"methodName": "onRootSchemaChanged"
						}
					]
				},

				/**
				 * Virtual column for CFUserColumnPath lookup.
				 */
				"CFUserColumn": {
					"dataValueType": BPMSoft.DataValueType.LOOKUP,
					"isLookup": true,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Virtual column for CFItemColumnPath lookup.
				 */
				"CFItemColumn": {
					"dataValueType": BPMSoft.DataValueType.LOOKUP,
					"isLookup": true,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Virtual column for CFInteractionValueColumnPath lookup.
				 */
				"CFInteractionValueColumn": {
					"dataValueType": BPMSoft.DataValueType.LOOKUP,
					"isLookup": true,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Dependencies config for actualizing CF columns.
				 */
				"CFColumnsDependencies": {
					"dependencies": [
						{
							"columns": ["CFUserColumn", "CFItemColumn", "CFInteractionValueColumn"],
							"methodName": "onCFVirtualColumnChanged"
						}
					]
				},

				/**
				 * Selection column for PredictionSchemaUId.
				 */
				"PredictionSchema": {
					"dataValueType": BPMSoft.DataValueType.LOOKUP,
					"isLookup": true,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Column for PredictionSchemaUId.
				 */
				"PredictionSchemaUId": {
					"dependencies": [
						{
							"columns": ["PredictionSchema"],
							"methodName": "onPredictionSchemaChanged"
						}
					]
				}
			},
			methods: {
				/**
				 * @param {Object} column Entity schema column config.
				 * @private
				 */
				_lookupColumnsFiltrationMethod: function(column) {
					return column.dataValueType === BPMSoft.DataValueType.LOOKUP ||
						column.dataValueType === BPMSoft.DataValueType.GUID;
				},

				/**
				 * @param {Object} column Entity schema column config.
				 * @private
				 */
				_numericColumnsFiltrationMethod: function(column) {
					const dataValueTypes = BPMSoft.DataValueType;
					return [dataValueTypes.INTEGER, dataValueTypes.FLOAT, dataValueTypes.MONEY, dataValueTypes.FLOAT1,
						dataValueTypes.FLOAT2, dataValueTypes.FLOAT3, dataValueTypes.FLOAT4, dataValueTypes.FLOAT8]
						.includes(column.dataValueType);
				},

				/**
				 * Handles selection of column.
				 * @private
				 * @param {String} modelColumnName Model column for selected value.
				 * @param {Object} linkedColumnInfo Selected column information.
				 */
				_onColumnSelected: function(modelColumnName, linkedColumnInfo) {
					const value = linkedColumnInfo.leftExpressionColumnPath;
					const displayValue = linkedColumnInfo.leftExpressionCaption;
					this.set(modelColumnName, {
						value: value,
						displayValue: displayValue
					});
				},

				/**
				 * Opens entity structure explorer module for select column macros.
				 * @private
				 */
				_openStructureExplorer: function(columnName, columnsFiltrationMethod) {
					const schemaName = this.$RootSchema.name;
					BPMSoft.StructureExplorerUtilities.open({
						scope: this,
						handlerMethod: this._onColumnSelected.bind(this, columnName),
						moduleConfig: {
							useBackwards: false,
							schemaName: schemaName,
							columnsFiltrationMethod: columnsFiltrationMethod,
							firstColumnsOnly: false
						}
					});
				},

				/**
				 * If CF column required modifies its model's property.
				 * @private
				 * @return {Boolean} True if column is required.
				 */
				_setColumnRequired: function(columnName, conditionMethod) {
					const isRequired = conditionMethod();
					this.columns[columnName].isRequired = isRequired;
					return isRequired;
				},

				/**
				 * @inheritdoc BaseMiniPage#onEntityInitialized
				 * @protected
				 * @override
				 */
				onEntityInitialized: function() {
					this.callParent(arguments);
					this.initializeRootSchema();
				},

				/**
				 * Handles modification of CF virtual column and saves corresponding real column's value.
				 */
				onCFVirtualColumnChanged: function(ruleName, virtualColumnName) {
					const realColumnName = virtualColumnName + "Path";
					const oldValue = this.get(realColumnName);
					const newValue = this.getLookupValue(virtualColumnName);
					if (oldValue !== newValue &&
							(this.Ext.isEmpty(oldValue) || !this.Ext.isEmpty(newValue))) {
						this.set(realColumnName, newValue);
					}
				},

				/**
				 * @return {Boolean} True if model is of a collaborative filtering recommendation problem type.
				 */
				getIsCF: function() {
					return this.getLookupValue("MLProblemType") === MLConfigurationConsts.ProblemTypes.CF;
				},

				/**
				 * @return {Boolean} True if model is of a collaborative filtering recommendation problem type and
				 * RootSchema was selected.
				 */
				getIsCFAndRootSchemaSelected: function() {
					return this.getIsCF() && !this.Ext.isEmpty(this.get("RootSchemaUId"));
				},

				/**
				 * @return {Boolean} True if CFUserColumn column is required.
				 */
				setCFUserColumnRequired: function() {
					return this._setColumnRequired("CFUserColumn", this.getIsCF.bind(this));
				},

				/**
				 * @return {Boolean} True if CFItemColumn column is required.
				 */
				setCFItemColumnRequired: function() {
					return this._setColumnRequired("CFItemColumn", this.getIsCF.bind(this));
				},

				setPredictionSchemaRequired: function() {
					return this._setColumnRequired("PredictionSchema", this.getIsTextSimilarity.bind(this));
				},

				/**
				 * Opens structure explorer for choosing lookup linked column.
				 */
				selectLookupColumn: function(lookupConfig, columnName) {
					this._openStructureExplorer(columnName, this._lookupColumnsFiltrationMethod);
				},

				/**
				 * Opens structure explorer for choosing numeric linked column.
				 */
				selectNumericColumn: function(lookupConfig, columnName) {
					this._openStructureExplorer(columnName, this._numericColumnsFiltrationMethod);
				},

				/**
				 * Returns caption for entity column.
				 * @param {String} columnName Entity column name.
				 * @return {String} Caption for entity column.
				 */
				getEntityColumnCaption: function(columnName) {
					return this.entitySchema.getColumnByName(columnName).caption;
				},

				/**
				 * Returns caption of CFUserColumnPath.
				 * @return {String}
				 */
				getCFUserColumnCaption: function() {
					return this.getEntityColumnCaption("CFUserColumnPath");
				},

				/**
				 * Returns caption of CFItemColumnPath.
				 * @return {String}
				 */
				getCFItemColumnCaption: function() {
					return this.getEntityColumnCaption("CFItemColumnPath");
				},

				/**
				 * Returns caption of CFInteractionValueColumnPath.
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
					return recommendationModelPageResources.localizableStrings.CFInteractionValueColumnHint;
				},

				/**
				 * Returns RootSchema column caption depending on problem type.
				 * @return {String}
				 */
				getRootSchemaCaption: function() {
					if (this.getIsTextSimilarity()) {
						return textSimilarityModelPageResources.localizableStrings.RootEntityCaption;
					}
					return this.getIsCF()
						? recommendationModelPageResources.localizableStrings.CFRootSchemaCaption
						: this.getEntityColumnCaption("RootSchemaUId");
				},

				/**
				 * Returns RootSchema column hint depending on problem type.
				 * @return {String}
				 */
				getRootSchemaHint: function() {
					if (this.getIsTextSimilarity()) {
						return textSimilarityModelPageResources.localizableStrings.SubjectObjectSchemasTipContent;
					}
					return this.getIsCF()
						? recommendationModelPageResources.localizableStrings.CFRootSchemaHint
						: modelPageResources.localizableStrings.ChooseObjectStepTipCaption;
				},

				onPredictionSchemaChanged: function() {
					const selectedSchema = this.$PredictionSchema;
					const currentSelectedSchemaUId = this.$PredictionSchemaUId;
					if (this.Ext.isEmpty(selectedSchema) || selectedSchema.value === currentSelectedSchemaUId) {
						return;
					}
					this.$PredictionSchemaUId = selectedSchema.value;
				},

				getIsTextSimilarity: function() {
					return this.getLookupValue("MLProblemType") === MLConfigurationConsts.ProblemTypes.TextSimilarity;
				},

				/**
				 * Empty function for mocking control bindings.
				 */
				emptyFn: Ext.emptyFn
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"name": "Name",
					"parentName": "MiniPage",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"labelConfig": {
							"visible": true
						},
						"isMiniPageModelItem": true,
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24
						}
					}
				},
				{
					"name": "MLProblemType",
					"parentName": "MiniPage",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"isMiniPageModelItem": true,
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24
						}
					}
				},
				{
					"name": "RootSchema",
					"parentName": "MiniPage",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"isMiniPageModelItem": true,
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 24
						},
						"contentType": BPMSoft.ContentType.ENUM,
						"controlConfig": {
							"prepareList": {
								"bindTo": "prepareRootSchemaList"
							}
						},
						"caption": {"bindTo": "getRootSchemaCaption"},
						"tip": {
							"content": {"bindTo": "getRootSchemaHint"}
						}
					}
				},
				{
					"name": "PredictionSchema",
					"parentName": "MiniPage",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"isMiniPageModelItem": true,
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 24
						},
						"controlConfig": {
							"prepareList": {
								"bindTo": "prepareRootSchemaList"
							}
						},
						"tip": {
							"content": {"bindTo": "getRootSchemaHint"}
						},
						"contentType": BPMSoft.ContentType.ENUM,
						"visible": {"bindTo": "getIsTextSimilarity"},
						"isRequired": {
							"bindTo": "MLProblemType",
							"bindConfig": {
								"converter": "setPredictionSchemaRequired"
							}
						},
						"caption": textSimilarityModelPageResources.localizableStrings.PredictionSchemaCaption
					}
				},
				{
					"name": "CFUserColumn",
					"parentName": "MiniPage",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"isMiniPageModelItem": true,
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 24
						},
						"contentType": BPMSoft.ContentType.LOOKUP,
						"controlConfig": {
							"loadVocabulary": {"bindTo": "selectLookupColumn"},
							"href": {"bindTo": "emptyFn"},
							"prepareList": {"bindTo": "emptyFn"}
						},
						"caption": {"bindTo": "getCFUserColumnCaption"},
						"visible": {"bindTo": "getIsCFAndRootSchemaSelected"},
						"isRequired": {
							"bindTo": "MLProblemType",
							"bindConfig": {
								"converter": "setCFUserColumnRequired"
							}
						}
					}
				},
				{
					"name": "CFItemColumn",
					"parentName": "MiniPage",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"isMiniPageModelItem": true,
						"layout": {
							"column": 0,
							"row": 5,
							"colSpan": 24
						},
						"contentType": BPMSoft.ContentType.LOOKUP,
						"controlConfig": {
							"loadVocabulary": {"bindTo": "selectLookupColumn"},
							"href": {"bindTo": "emptyFn"},
							"prepareList": {"bindTo": "emptyFn"}
						},
						"caption": {"bindTo": "getCFItemColumnCaption"},
						"visible": {"bindTo": "getIsCFAndRootSchemaSelected"},
						"isRequired": {
							"bindTo": "MLProblemType",
							"bindConfig": {
								"converter": "setCFItemColumnRequired"
							}
						}
					}
				},
				{
					"name": "CFInteractionValueColumn",
					"parentName": "MiniPage",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"isMiniPageModelItem": true,
						"layout": {
							"column": 0,
							"row": 6,
							"colSpan": 24
						},
						"contentType": BPMSoft.ContentType.LOOKUP,
						"controlConfig": {
							"loadVocabulary": {"bindTo": "selectNumericColumn"},
							"href": {"bindTo": "emptyFn"},
							"prepareList": {"bindTo": "emptyFn"}
						},
						"caption": {"bindTo": "getCFInteractionValueColumnCaption"},
						"tip": {
							"content": {"bindTo": "getCFInteractionValueColumnHint"}
						},
						"visible": {"bindTo": "getIsCFAndRootSchemaSelected"}
					}
				},
				{
					"operation": "merge",
					"name": "SaveEditButton",
					"values": {
						"click": {"bindTo": "openCurrentEntityPage"}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
