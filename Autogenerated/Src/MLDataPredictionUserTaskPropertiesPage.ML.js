define("MLDataPredictionUserTaskPropertiesPage", ["BPMSoft", "MLDataPredictionUserTaskPropertiesPageResources",
			"MLConfigurationConsts", "FilterModuleMixin", "EntityStructureHelperMixin"],
			function(BPMSoft, resources, mlConsts) {
	return {
		mixins: {
			filterModuleMixin: "BPMSoft.FilterModuleMixin",
			entityStructureHelperMixin: "BPMSoft.EntityStructureHelperMixin"
		},
		messages: {
			"GetFilterModuleConfig": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			"OnFiltersChanged": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
		properties: {
			batchDataSourceFiltersParameterName: "PredictionFilterData",
			cfUsersDataSourceFiltersParameterName: "CFUserFilterData",
			cfItemsDataSourceFiltersParameterName: "CFItemFilterData",
			cfUsersFilterEditDataParameterName: "CFUserFilterEditData",
			cfItemsFilterEditDataParameterName: "CFItemFilterEditData"
		},
		attributes: {

			/**
			 * Machine learning model identifier.
			 * @protected
			 * @type {Object}
			 */
			"MLModelId": {
				dataValueType: this.BPMSoft.DataValueType.LOOKUP,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				initMethod: "_initLookupProperty",
				referenceSchemaName: "MLModel",
				isLookup: true,
				isRequired: true,
				doAutoSave: true,
				caption: resources.localizableStrings.MLModelCaption
			},

			/**
			 * Selected model entity schema UId.
			 * @private
			 * @type {String}
			 */
			"ModelSchemaUId": {
				dataValueType: this.BPMSoft.DataValueType.LOOKUP,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Model's problem type.
			 * @private
			 * @type {String}
			 */
			"ProblemTypeId": {
				dataValueType: this.BPMSoft.DataValueType.GUID,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * CF model Subject schema name.
			 * @private
			 * @type {String}
			 */
			"CFUserSchemaName": {
				dataValueType: this.BPMSoft.DataValueType.TEXT,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * CF model Object schema name.
			 * @private
			 * @type {String}
			 */
			"CFItemSchemaName": {
				dataValueType: this.BPMSoft.DataValueType.TEXT,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Predictable entity record identifier.
			 * @protected
			 * @type {Object}
			 */
			"RecordId": {
				dataValueType: this.BPMSoft.DataValueType.MAPPING,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				initMethod: "initPropertySilent",
				doAutoSave: true,
				caption: resources.localizableStrings.EntityRecordCaption
			},

			/**
			 * Data prediction modes.
			 * @protected
			 * @type {Object}
			 */
			"DataPredictionModeEnum": {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: {
					PredictSingleItem: "0",
					PredictCollection: "1"
				}
			},

			/**
			 * Data prediction mode.
			 * @protected
			 * @type {Object}
			 */
			"DataPredictionMode": {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isLookup: true,
				isRequired: true,
				onChange: "_onDataPredictionModeChanged"
			},

			/**
			 * Filters for prediction (batch).
			 * @protected
			 * @type {Object}
			 */
			"PredictionFilterData": {
				"dataValueType": this.BPMSoft.DataValueType.CUSTOM_OBJECT,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Filters for selecting users for recommendation model.
			 * @protected
			 * @type {Object}
			 */
			"CFUserFilterData": {
				"dataValueType": this.BPMSoft.DataValueType.CUSTOM_OBJECT,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Filters for selecting items for recommendation model.
			 * @protected
			 * @type {Object}
			 */
			"CFItemFilterData": {
				"dataValueType": this.BPMSoft.DataValueType.CUSTOM_OBJECT,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Defines entity collection (batch) mode.
			 * @protected
			 * @type {Boolean}
			 */
			"IsBatchPredictionMode": {
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Defines CF filters visibility.
			 * @protected
			 * @type {Boolean}
			 */
			"IsCFFilterVisible": {
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Number of items to predict.
			 * @protected
			 * @type {Number}
			 */
			"TopN": {
				dataValueType: BPMSoft.DataValueType.INTEGER,
				parameterBindConfig: {
					onInit: "initProperty",
					onSave: "saveIntParameter"
				}
			},

			/**
			 * Number of recommended Items.
			 * @protected
			 * @type {Boolean}
			 */
			"CFFilterAlreadyInteractedItems": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				parameterBindConfig: {
					onInit: "initProperty",
					onSave: "saveParameter"
				}
			}

		},
		details: {},
		methods: {

			//region Methods: Private

			/**
			 * Inits lookup parameter value.
			 * @param {BPMSoft.manager.ProcessSchemaParameter} parameter Process parameter.
			 * @private
			 */
			_initLookupProperty: function(parameter) {
				const parameterName = parameter.getName();
				const value = parameter.getValue();
				if (!this.Ext.isEmpty(value)) {
					this.set(parameterName, {
						value: value,
						displayValue: parameter.getParameterDisplayValue()
					});
				}
			},

			/**
			 * Handles MLModelId change event.
			 * @private
			 */
			_onMLModelIdChange: function() {
				this.unloadCFUserFilterModule();
				this.unloadCFItemFilterModule();
				this.set(this.batchDataSourceFiltersParameterName, null);
				this.set(this.cfUsersDataSourceFiltersParameterName, null);
				this.set(this.cfItemsDataSourceFiltersParameterName, null);
				this.$RecordId = null;
				this.set("FilterEditData", null);
				this.set(this.cfUsersFilterEditDataParameterName, null);
				this.set(this.cfItemsFilterEditDataParameterName, null);
				this._updateModelAttributes(function() {
					this.updateBatchFilterModule();
					this.updateCFUserFilterModule();
					this.updateCFItemFilterModule();
				}, this);
			},

			/**
			 * Sets data read mode value.
			 * @param {BPMSoft.manager.mixins.ParametrizedProcessSchemaElement} element Process element.
			 * @private
			 */
			_initDataPredictionMode: function(element) {
				const parameter = element.getParameterByName("IsBatchPrediction");
				const isBatchPrediction = parameter.getValue();
				const dataPredictionModeEnum = this.$DataPredictionModeEnum;
				const modeLookupValue = isBatchPrediction
					? dataPredictionModeEnum.PredictCollection
					: dataPredictionModeEnum.PredictSingleItem;
				const modes = this._getDataPredictionModes();
				this.$DataPredictionMode = modes[modeLookupValue];
			},

			/**
			 * Data prediction mode change handler.
			 * @private
			 */
			_onDataPredictionModeChanged: function() {
				this.unloadBatchFiltersModule();
				this.$IsBatchPredictionMode =
					this.getLookupValue("DataPredictionMode") === this.$DataPredictionModeEnum.PredictCollection;
			},

			/**
			 * Saves IsBatchPrediction parameter value.
			 * @param {BPMSoft.manager.mixins.ParametrizedProcessSchemaElement} element Process element.
			 * @private
			 */
			_saveDataPredictionMode: function(element) {
				if (!this.isAttributeChanged("DataPredictionMode")) {
					return;
				}
				const parameter = element.getParameterByName("IsBatchPrediction");
				const isBatchPrediction =
					this.getLookupValue("DataPredictionMode") === this.$DataPredictionModeEnum.PredictCollection;
				const sourceValue = {
					value: isBatchPrediction,
					source: BPMSoft.ProcessSchemaParameterValueSource.ConstValue
				};
				parameter.setMappingValue(sourceValue);
			},

			/**
			 * Returns data prediction modes.
			 * @private
			 * @return {Object}
			 */
			_getDataPredictionModes: function() {
				const dataPredictionModeEnum = this.get("DataPredictionModeEnum");
				const dataPredictionModes = {};
				dataPredictionModes[dataPredictionModeEnum.PredictSingleItem] = {
					value: dataPredictionModeEnum.PredictSingleItem,
					displayValue: resources.localizableStrings.PredictSingleItemCaption
				};
				dataPredictionModes[dataPredictionModeEnum.PredictCollection] = {
					value: dataPredictionModeEnum.PredictCollection,
					displayValue: resources.localizableStrings.PredictCollectionCaption
				};
				return dataPredictionModes;
			},

			/**
			 * Updates current model attributes to selected value.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 * @private
			 */
			_updateModelAttributes: function(callback, scope) {
				const modelId = this.getLookupValue("MLModelId");
				if (this.Ext.isEmpty(modelId)) {
					this.$ModelSchemaUId = null;
					this.$ProblemTypeId = null;
					this._updateCFModelAttributes();
					callback.call(scope || this);
					return;
				}
				const esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "MLModel"
				});
				esq.addColumn("RootSchemaUId");
				esq.addColumn("PredictionSchemaUId");
				esq.addColumn("MLProblemType.Id");
				esq.addColumn("CFUserColumnPath");
				esq.addColumn("CFItemColumnPath");
				esq.getEntity(modelId, function(response) {
					const entity = response.entity;
					if (!entity) {
						this.error(`ML model ${modelId} not found`);
						this.$MLModelId = {value: null, displayValue: null};
						callback.call(scope);
						return;
					}
					this.$ModelSchemaUId = entity.get("PredictionSchemaUId") || entity.get("RootSchemaUId");
					this._updateRecordIdReferenceSchema(this.$ModelSchemaUId);
					this.$ProblemTypeId = entity.get("MLProblemType.Id");
					const modes = this._getDataPredictionModes();
					if (!this.getIsBatchEnabledForProblemType()) {
						this.$DataPredictionMode = modes[this.$DataPredictionModeEnum.PredictSingleItem];
					}
					this._updateCFModelAttributes(entity, function() {
						this.$IsCFFilterVisible = this.$ProblemTypeId === mlConsts.ProblemTypes.CF;
						callback.call(scope);
					}, this);
				}, this);
			},

			_updateRecordIdReferenceSchema: function (referenceSchemaUId) {
				this.$ProcessElement.getParameterByName("RecordId").referenceSchemaUId = referenceSchemaUId;
				const recordId = this.$RecordId || {
					value: null,
					displayValue: null
				};
				recordId.referenceSchemaUId = referenceSchemaUId;
				this.$RecordId = recordId;
			},

			_updateCFModelAttributes: function(mlModelEntity, callback, scope) {
				const cfUserColumnPath = mlModelEntity && mlModelEntity.get("CFUserColumnPath");
				const cfItemColumnPath = mlModelEntity && mlModelEntity.get("CFItemColumnPath");
				if (this.$ProblemTypeId !== mlConsts.ProblemTypes.CF || !this.$ModelSchemaUId ||
						(!cfUserColumnPath && !cfItemColumnPath)) {
					this.$CFUserSchemaName = null;
					this.$CFItemSchemaName = null;
					if (callback) {
						callback.call(scope);
					}
					return;
				}
				BPMSoft.EntitySchemaManager.getInstanceByUId(this.$ModelSchemaUId, function(rootSchema) {
					const columnsPaths = [cfUserColumnPath, cfItemColumnPath];
					this._getColumnsReferenceSchemas(rootSchema.name, columnsPaths, function(columnsReferenceSchemas) {
						this.$CFUserSchemaName = columnsReferenceSchemas[cfUserColumnPath];
						this.$CFItemSchemaName = columnsReferenceSchemas[cfItemColumnPath];
						callback.call(scope);
					}, this);
				}, this);
			},

			_getColumnsReferenceSchemas: function(rootSchemaName, columnPaths, callback, scope) {
				const serviceParams = [];
				BPMSoft.each(columnPaths, function(columnPath) {
					serviceParams.push({
						schemaName: rootSchemaName,
						columnPath: columnPath,
						key: columnPath
					});
				}, this);
				this.getColumnPathCaption(this.Ext.JSON.encode(serviceParams), function(columnConfigs) {
					const result = {};
					BPMSoft.each(columnConfigs, function(columnConfig) {
						result[columnConfig.key] = columnConfig.referenceSchemaName;
					}, this);
					callback.call(scope, result);
				}, this);
			},

			/**
			 * @private
			 */
			_getBatchFiltersModuleId: function() {
				return this.sandbox.id + "_ML_BatchFiltersModule";
			},

			/**
			 * @private
			 */
			_getCFUserFiltersModuleId: function() {
				return this.sandbox.id + "_ML_CFUserFiltersModule";
			},

			/**
			 * @private
			 */
			_getCFItemFiltersModuleId: function() {
				return this.sandbox.id + "_ML_CFItemFiltersModule";
			},

			/**
			 * Returns filters is empty.
			 * @param {Object} filterEditData Filters data.
			 * @return {Boolean} True if filters is empty, else false.
			 */
			_getIsFilterEmpty: function(filterEditData) {
				return this.Ext.isEmpty(filterEditData) || filterEditData.isEmpty();
			},

			//endregion

			// region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BaseObject#onDestroy
			 * @override
			 */
			onDestroy: function() {
				const moduleIds = [
					this._getBatchFiltersModuleId(),
					this._getCFUserFiltersModuleId(),
					this._getCFItemFiltersModuleId()
				];
				this.destroyFilterModuleMixin(moduleIds);
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.FilterModuleMixin#initReferenceSchemaUId
			 * @override
			 */
			initReferenceSchemaUId: Ext.emptyFn,

			/**
			 * @inheritdoc BPMSoft.FilterModuleMixin#getFilterContainerId
			 * @override
			 */
			getFilterContainerId: function() {
				return "ExtendedFiltersContainer";
			},

			/**
			 * @inheritdoc BPMSoft.FilterModuleMixin#getFilterReferenceSchemaAttributeName
			 * @override
			 */
			getFilterReferenceSchemaAttributeName: function() {
				return "ModelSchemaUId";
			},

			/**
			 * @inheritdoc BPMSoft.BaseProcessSchemaElementPropertiesPage#customValidator
			 * @overridden
			 */
			customValidator: function() {
				const validationInfo = this.callParent(arguments);
				if (this.getIsNotCF()) {
					return validationInfo;
				}
				const cfUserFilters = this.get(this.cfUsersFilterEditDataParameterName);
				if (this._getIsFilterEmpty(cfUserFilters)) {
					validationInfo.isValid = false;
					validationInfo.invalidMessage = this.get("Resources.Strings.FilterDataIsNullOrEmptyMessage");
				}
				if (!validationInfo.isValid) {
					this.addCustomValidationResult(validationInfo);
				}
				return validationInfo;
			},

			/**
			 * Fixes ProcessFlowElementPropertiesPage#saveParameter for integer parameter (int value can't be
			 * deserialized in ProcessSchemaParameterValue.ApplyMetaDataValue -> reader.GetStringValue().
			 * @protected
			 */
			saveIntParameter: function(parameter) {
				const sourceValue = this.getParameterSourceValue(parameter);
				sourceValue.value =
					!this.Ext.isEmpty(sourceValue.value) ? String(sourceValue.value) : sourceValue.value;
				parameter.setMappingValue(sourceValue);
			},

			//endregion

			//region Methods: Public

			/**
			 * Fills out the drop down list of data read modes.
			 * @param {String} filter Filter value.
			 * @param {BPMSoft.core.collections.Collection} list The drop down list.
			 */
			prepareDataPredictionModes: function(filter, list) {
				if (!list) {
					return;
				}
				const dataPredictionModes = this._getDataPredictionModes();
				list.clear();
				list.loadAll(dataPredictionModes);
			},

			/**
			 * @inheritdoc ProcessSchemaElementEditable#onElementDataLoad
			 * @override
			 */
			onElementDataLoad: function(element, callback, scope) {
				const parentMethod = this.getParentMethod();
				BPMSoft.chain(
					function(next) {
						parentMethod.call(this, element, next, this);
					},
					function(next) {
						this._initDataPredictionMode(element);
						this.subscribeOnColumnChange("MLModelId", this._onMLModelIdChange, this);
						next();
					},
					this._updateModelAttributes,
					function(next) {
						const filterConfig = [
							{
								referenceSchemaParameterName: "ModelSchemaUId",
								dataSourceFiltersParameterName: this.batchDataSourceFiltersParameterName
							},
							{
								dataSourceFiltersParameterName: this.cfUsersDataSourceFiltersParameterName,
								filterDataParameterName: this.cfUsersFilterEditDataParameterName,
								skipInitReferenceSchema: true
							},
							{
								dataSourceFiltersParameterName: this.cfItemsDataSourceFiltersParameterName,
								filterDataParameterName: this.cfItemsFilterEditDataParameterName,
								skipInitReferenceSchema: true
							}
						];
						filterConfig.element = element;
						this.mixins.filterModuleMixin.initFilterModuleMixin.call(this, filterConfig, next, this);
					},
					function() {
						callback.call(scope || this);
					},
				this);
			},

			/**
			 * @inheritdoc BaseProcessSchemaElementPropertiesPage#saveValues
			 * @override
			 */
			saveValues: function() {
				const element = this.get("ProcessElement");
				this._saveDataPredictionMode(element);
				this.saveDataSourceFilters(element, this.batchDataSourceFiltersParameterName);
				this.saveDataSourceFilters(element, this.cfUsersDataSourceFiltersParameterName,
					this.cfUsersFilterEditDataParameterName);
				this.saveDataSourceFilters(element, this.cfItemsDataSourceFiltersParameterName,
					this.cfItemsFilterEditDataParameterName);
				this.callParent(arguments);
			},

			/**
			 * @return {Boolean} True if current mode is single record prediction.
			 */
			getIsRecordIdVisible: function() {
				const isSinglePredictMode = !this.getIsBatchEnabledForProblemType() ||
					this.getLookupValue("DataPredictionMode") === this.$DataPredictionModeEnum.PredictSingleItem;
				return this.getIsNotCF() && !this.Ext.isEmpty(this.getLookupValue("MLModelId")) && isSinglePredictMode;
			},

			/**
			 * Updates Batch filters module.
			 */
			updateBatchFilterModule: function() {
				const filterModuleId = this._getBatchFiltersModuleId();
				this.updateFilterModule(filterModuleId);
			},

			/**
			 * Updates CF users filters module.
			 */
			updateCFUserFilterModule: function() {
				const filterModuleId = this._getCFUserFiltersModuleId();
				this.updateFilterModuleBySchema(this.$CFUserSchemaName, filterModuleId, "CFUserFiltersContainer",
					this.cfUsersFilterEditDataParameterName);
			},

			/**
			 * Updates CF items filters module.
			 */
			updateCFItemFilterModule: function() {
				const filterModuleId = this._getCFItemFiltersModuleId();
				this.updateFilterModuleBySchema(this.$CFItemSchemaName, filterModuleId, "CFItemFiltersContainer",
					this.cfItemsFilterEditDataParameterName);
			},

			/**
			 * Unloads Batch filters module.
			 */
			unloadBatchFiltersModule: function() {
				const moduleId = this._getBatchFiltersModuleId();
				this.unloadFilterUnitModule(moduleId);
			},

			/**
			 * Unloads CF users filters module.
			 */
			unloadCFUserFilterModule: function() {
				const moduleId = this._getCFUserFiltersModuleId();
				this.unloadFilterUnitModule(moduleId);
			},

			/**
			 * Unloads CF items filters module.
			 */
			unloadCFItemFilterModule: function() {
				const moduleId = this._getCFItemFiltersModuleId();
				this.unloadFilterUnitModule(moduleId);
			},

			/**
			 * @return {Boolean} True if problem type is not CF.
			 */
			getIsNotCF: function() {
				return this.$ProblemTypeId !== mlConsts.ProblemTypes.CF;
			},

			/**
			 * @return {Boolean} True if batch prediction can be used.
			 */
			getIsBatchEnabledForProblemType: function() {
				const problemTypes = mlConsts.ProblemTypes;
				return [problemTypes.Scoring, problemTypes.Regression, problemTypes.TextSimilarity,
					problemTypes.Classification].includes(this.$ProblemTypeId);
			},

			/**
			 * @return {Boolean} True if batch filters should be visible.
			 */
			getIsBatchFilterVisible: function() {
				return this.getIsBatchEnabledForProblemType() && this.$IsBatchPredictionMode;
			},

			/**
			 * @return {Boolean} True if prediction top N should be visible.
			 */
			getIsPredictionTopNVisible: function() {
				return this.$ProblemTypeId === mlConsts.ProblemTypes.TextSimilarity;
			}

			//endregion

		},
		modules: {},
		diff: /**SCHEMA_DIFF*/[
			{
				"name": "UserTaskContainer",
				"parentName": "EditorsContainer",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			},
			{
				"name": "MLModelContainer",
				"parentName": "UserTaskContainer",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"layout": {"column": 0, "row": 0, "colSpan": 24},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"name": "MLModelId",
				"parentName": "MLModelContainer",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"layout": {"column": 0, "row": 0, "colSpan": 24},
					"wrapClass": ["top-caption-control"],
					"bindTo": "MLModelId",
					"contentType": BPMSoft.ContentType.ENUM,
					"controlConfig": {
						"filterComparisonType": BPMSoft.StringFilterType.CONTAIN
					}
				}
			},
			{
				"name": "DataPredictionModeContainer",
				"parentName": "UserTaskContainer",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"layout": {"column": 0, "row": 1, "colSpan": 24},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"visible": {"bindTo": "getIsBatchEnabledForProblemType"}
				}
			},
			{
				"name": "DataPredictionModeLabel",
				"parentName": "DataPredictionModeContainer",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"layout": {"column": 0, "row": 0, "colSpan": 24},
					"classes": {"labelClass": ["t-title-label-proc"]},
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": "$Resources.Strings.DataPredictModeCaption"
				}
			},
			{
				"name": "DataPredictionModeSelect",
				"parentName": "DataPredictionModeContainer",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"layout": {"column": 0, "row": 1, "colSpan": 24},
					"contentType": BPMSoft.ContentType.ENUM,
					"controlConfig": {"prepareList": {"bindTo": "prepareDataPredictionModes"}},
					"labelConfig": {"visible": false},
					"wrapClass": ["no-caption-control"],
					"bindTo": "DataPredictionMode"
				}
			},
			{
				"name": "RecordId",
				"parentName": "UserTaskContainer",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"layout": {"column": 0, "row": 2, "colSpan": 24},
					"wrapClass": ["top-caption-control"],
					"classes": {"labelClass": ["t-title-label-proc"]},
					"bindTo": "RecordId",
					"visible": {"bindTo": "getIsRecordIdVisible"}
				}
			},
			{
				"name": "BatchFiltersControlGroup",
				"parentName": "UserTaskContainer",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"layout": {"column": 0, "row": 2, "colSpan": 24},
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": [],
					"visible": {"bindTo": "getIsBatchFilterVisible"}
				}
			},
			{
				"name": "FilterLabel",
				"parentName": "BatchFiltersControlGroup",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"layout": {"column": 0, "row": 0, "colSpan": 24},
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": "$Resources.Strings.PredictFilterDataCaption",
					"classes": {
						"labelClass": ["t-title-label-proc"]
					}
				}
			},
			{
				"name": "ExtendedFiltersContainer",
				"parentName": "BatchFiltersControlGroup",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"layout": {"column": 0, "row": 1, "colSpan": 24},
					"id": "ExtendedFiltersContainer",
					"selectors": {"wrapEl": "#ExtendedFiltersContainer"},
					"beforererender": {
						"bindTo": "unloadBatchFiltersModule"
					},
					"afterrender": {
						"bindTo": "updateBatchFilterModule"
					},
					"afterrerender": {
						"bindTo": "updateBatchFilterModule"
					},
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"markerValue": "ExtendedFiltersContainer"
				}
			},
			{
				"name": "PredictionTopN",
				"parentName": "UserTaskContainer",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"layout": {"column": 0, "row": 2, "colSpan": 24},
					"wrapClass": ["top-caption-control"],
					"caption": "$Resources.Strings.PredictionTopNCaption",
					"bindTo": "TopN",
					"visible": { "bindTo": "getIsPredictionTopNVisible"}
				}
			},
			{
				"name": "CFControlGroup",
				"parentName": "UserTaskContainer",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"layout": {"column": 0, "row": 2, "colSpan": 24},
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": [],
					"visible": "$IsCFFilterVisible"
				}
			},
			{
				"name": "CFUserFilterLabel",
				"parentName": "CFControlGroup",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"layout": {"column": 0, "row": 0, "colSpan": 24},
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": "$Resources.Strings.CFUserFilterDataCaption",
					"classes": {
						"labelClass": ["t-title-label-proc"]
					}
				}
			},
			{
				"name": "CFUserFiltersContainer",
				"parentName": "CFControlGroup",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"layout": {"column": 0, "row": 1, "colSpan": 24},
					"id": "CFUserFiltersContainer",
					"selectors": {"wrapEl": "#CFUserFiltersContainer"},
					"beforererender": {
						"bindTo": "unloadCFUserFilterModule"
					},
					"afterrender": {
						"bindTo": "updateCFUserFilterModule"
					},
					"afterrerender": {
						"bindTo": "updateCFUserFilterModule"
					},
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"markerValue": "CFUserFiltersContainer"
				}
			},
			{
				"name": "CFItemFilterLabel",
				"parentName": "CFControlGroup",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"layout": {"column": 0, "row": 2, "colSpan": 23},
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": "$Resources.Strings.CFItemFilterDataCaption",
					"classes": {
						"labelClass": ["t-title-label-proc"]
					}
				}
			},

			{
				"operation": "insert",
				"name": "FilterInfoButtonContainer",
				"parentName": "CFControlGroup",
				"propertyName": "items",
				"values": {
					"layout": {"column": 23, "row": 2, "colSpan": 1},
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"markerValue": "FilterInfoButtonContainer",
					"wrapClass": ["filter-info-button-container"]
				}
			},
			{
				"operation": "insert",
				"parentName": "FilterInfoButtonContainer",
				"propertyName": "items",
				"name": "FilterInfoButton",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.INFORMATION_BUTTON,
					"content": "$Resources.Strings.CFItemFilterInfoButtonText"
				}
			},

			{
				"name": "CFItemFiltersContainer",
				"parentName": "CFControlGroup",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"layout": {"column": 0, "row": 3, "colSpan": 24},
					"id": "CFItemFiltersContainer",
					"selectors": {"wrapEl": "#CFItemFiltersContainer"},
					"beforererender": {
						"bindTo": "unloadCFItemFilterModule"
					},
					"afterrender": {
						"bindTo": "updateCFItemFilterModule"
					},
					"afterrerender": {
						"bindTo": "updateCFItemFilterModule"
					},
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"markerValue": "CFItemFiltersContainer"
				}
			},
			{
				"name": "CFTopN",
				"parentName": "CFControlGroup",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"layout": {"column": 0, "row": 4, "colSpan": 24},
					"wrapClass": ["top-caption-control"],
					"caption": "$Resources.Strings.CFTopNCaption",
					"bindTo": "TopN"
				}
			},
			{
				"name": "CFFilterAlreadyInteractedItems",
				"parentName": "CFControlGroup",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"layout": {"column": 0, "row": 5, "colSpan": 24},
					"wrapClass": ["t-checkbox-control"],
					"caption": {
						"bindTo": "Resources.Strings.CFFilterAlreadyInteractedItemsCaption"
					},
					"bindTo": "CFFilterAlreadyInteractedItems"
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
