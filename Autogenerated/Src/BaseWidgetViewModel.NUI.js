define("BaseWidgetViewModel", ["BPMSoft", "ext-base", "BaseWidgetViewModelResources", "QueryCancellationMixin",
	"DetailManager"], function(BPMSoft, Ext, resources) {

		Ext.define("BPMSoft.configuration.BaseWidgetViewModel", {
			extend: "BPMSoft.BaseViewModel",
			alternateClassName: "BPMSoft.configuration.BaseWidgetViewModel",

			/**
			 * Ext framework.
			 * @type {Object}.
			 */
			Ext: null,

			/**
			 * Sandbox.
			 * @type {Object}.
			 */
			sandbox: null,

			/**
			 * BPMSoft framework.
			 * @type {Object}.
			 */
			BPMSoft: null,

			mixins: {
				QueryCancellationMixin: "BPMSoft.QueryCancellationMixin"
			},

			// region Properties: Protected

			columns: {
				DataIsLoading: {
					dataValueType: BPMSoft.DataValueType.Boolean,
					value: false,
				},
			},

			/**
			 * Column is used for adding aggregation column to select query
			 * @protected
			 * @type {String}.
			 */
			aggregationColumnName: "aggregationColumn",

			// endregion

			// region Methods: private

			/**
			 * @private
			 */
			_getExcludedEntitySchemaNames: function() {
				return ["Dashboard", "OperatorSingleWindow"];
			},

			/**
			 * @private
			 */
			_getEntitySchemaNameByApplicationStructureItemId: function(config, callback, scope) {
				const id = config.applicationStructureItemId.toLowerCase();
				const modules = Ext.Object.getValues(BPMSoft.configuration.ModuleStructure);
				const module = modules.find(function(item) {
					return (item.moduleId && item.moduleId.toLowerCase()) === id;
				}, this);
				if (module) {
					callback.call(scope, module.entitySchemaName);
				} else {
					BPMSoft.DetailManager.initialize(function() {
						const detailManagerItems = BPMSoft.DetailManager.getItems();
						const detailManagerItem = detailManagerItems.firstOrDefault(function(item) {
							return item.getId().toLowerCase() === id;
						}, this);
						if (detailManagerItem) {
							callback.call(scope, detailManagerItem.getEntitySchemaName());
						} else {
							callback.call(scope, null);
						}
					}, this);
				}
			},

			/**
			 * @private
			 */
			_requireSectionEntitySchema: function(callback, scope) {
				const id = this.get("sectionId");
				if (id) {
					this._getEntitySchemaNameByApplicationStructureItemId({applicationStructureItemId: id}, function(entitySchemaName) {
						const excludedEntitySchemaNames = this._getExcludedEntitySchemaNames();
						if (entitySchemaName && !BPMSoft.contains(excludedEntitySchemaNames, entitySchemaName)) {
							this.set("sectionEntitySchemaName", entitySchemaName);
							BPMSoft.require([entitySchemaName], function(entitySchema) {
								BPMSoft[entitySchemaName] = entitySchema;
								callback.call(scope);
							}, this);
						} else {
							callback.call(scope);
						}
					}, this);
				} else {
					callback.call(scope);
				}
			},

			/**
			 * @private
			 */
			_getSectionSchemaBoundColumnPath: function(sectionBindingColumnPath, columnPath) {
				const sectionEntitySchema = BPMSoft[this.get("sectionEntitySchemaName")];
				const columnPathArray = sectionBindingColumnPath.split(".");
				const columnPathTpl = columnPathArray.length > 1 ? "{4}.[{0}:{1}:{2}].{3}" : "[{0}:{1}:{2}].{3}";
				const lastSectionBindingColumnPathElement = columnPathArray.pop();
				return Ext.String.format(columnPathTpl,
					sectionEntitySchema.name,
					sectionEntitySchema.primaryColumnName,
					lastSectionBindingColumnPathElement,
					columnPath,
					columnPathArray.join("."));
			},

			//endregion

			// region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BaseModel#getModelColumns
			 * @override
			 */
			getModelColumns: function() {
				const baseColumns = this.callParent(arguments);
				return this.Ext.apply(baseColumns, {
					caption: {
						type: BPMSoft.core.enums.ViewModelSchemaItem.ATTRIBUTE,
						dataValueType: BPMSoft.DataValueType.Text,
						value: null
					},
					value: {
						type: BPMSoft.core.enums.ViewModelSchemaItem.ATTRIBUTE,
						dataValueType: BPMSoft.DataValueType.Text,
						value: null
					}
				});
			},


			/**
			 * Does actions that required after page had been rendered.
			 * @protected
			 */
			onRender: this.BPMSoft.emptyFn,

			/**
			 * Initializes the initial values of the model.
			 * @protected
			 * @param {Function} callback The function that will be called upon completion.
			 * @param {Object} scope The context in which the callback function will be called.
			 */
			init: function(callback, scope) {
				this.prepareWidget(callback, scope);
			},

			/**
			 * Initializes the resource model with values from the object resources.
			 * @protected
			 * @param {Object} resourcesObj Resource object.
			 */
			initResourcesValues: function(resourcesObj) {
				const resourcesSuffix = "Resources";
				BPMSoft.each(resourcesObj, function(resourceGroup, resourceGroupName) {
					resourceGroupName = resourceGroupName.replace("localizable", "");
					BPMSoft.each(resourceGroup, function(resourceValue, resourceName) {
						const viewModelResourceName = [resourcesSuffix, resourceGroupName, resourceName].join(".");
						this.set(viewModelResourceName, resourceValue);
					}, this);
				}, this);
			},

			/**
			 * Prepares indicator parameters
			 * @protected
			 * @param {Function} callback The function that will be called upon completion.
			 * @param {Object} scope The context in which the callback function will be called.
			 */
			prepareWidget: function(callback, scope) {
				if (this.get("entitySchemaName")) {
					BPMSoft.chain(
						function(next) {
							this.set("DataIsLoading", true);
							this._requireSectionEntitySchema(next, this);
						},
						function(next) {
							const select = this.createSelect();
							select.getEntityCollection(next, this);
							const key = this.sandbox.id;
							this.mixins.QueryCancellationMixin.registerSentQuery.call(this, key, select);
						},
						function(next, response) {
							this.set("DataIsLoading", false);
							if (!response.success || this.destroyed) {
								return;
							}
							const resultEntity = response.collection.getByIndex(0);
							this.set("value", resultEntity.get("value"));
							callback.call(scope);
						},
						this
					);
				} else {
					callback.call(scope);
				}
			},

			/**
			 * Updates module filters by module configuration.
			 * @protected
			 * @param {BPMSoft.FilterGroup} quickFilter Filter.
			 * @param {String} sectionBindingColumnPath Column connection with section.
			 */
			updateModuleFilter: function(quickFilter, sectionBindingColumnPath) {
				const leftExpression = quickFilter.leftExpression;
				if (!Ext.isEmpty(leftExpression)) {
					if (leftExpression.columnPath) {
						leftExpression.columnPath = this._getSectionSchemaBoundColumnPath(
							sectionBindingColumnPath, leftExpression.columnPath);
					}
					const leftExpressionFunctionArgument = leftExpression.functionArgument;
					if (leftExpression.expressionType === BPMSoft.ExpressionType.FUNCTION && leftExpressionFunctionArgument) {
						leftExpressionFunctionArgument.columnPath = this._getSectionSchemaBoundColumnPath(
							sectionBindingColumnPath, leftExpressionFunctionArgument.columnPath);
					}
				} else {
					quickFilter.each(function(item) {
						this.updateModuleFilter(item, sectionBindingColumnPath);
					}, this);
				}
			},

			/**
			 * Performs data selection.
			 * @protected
			 * @return {BPMSoft.EntitySchemaQuery} select Contains selected and filtered data.
			 */
			createSelect: function(selectParameters) {
				const select = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: this.get("entitySchemaName"),
					isBatchable: BPMSoft.Features.getIsEnabled("BatchableDashboardQueryFeature")
				});
				BPMSoft.each(Object.keys(selectParameters || {}), function(parameter) {
					select[parameter] = selectParameters[parameter];
				});
				this.addAggregationColumn(select);
				const filterData = this.get("filterData");
				const filters = Ext.isString(filterData) ? BPMSoft.deserialize(filterData) : Ext.create("BPMSoft.FilterGroup");
				select.filters.addItem(filters);
				const quickFilters = this.getQuickFilters();
				if (!Ext.isEmpty(quickFilters)) {
					select.filters.addItem(quickFilters);
				}
				return select;
			},

			/**
			 * Adds an aggregation column based on the aggregation type from the config.
			 * @protected
			 * @param {Object} select Data selection.
			 */
			addAggregationColumn: function(select) {
				const aggregationType = this.get("aggregationType");
				const aggregationColumnName = this.get(this.aggregationColumnName) || "Id";
				select.addAggregationSchemaColumn(aggregationColumnName, aggregationType, "value");
			},

			// endregion

			// region Methods: Public

			/**
			 * @inheritdoc BPMSoft.BaseViewModel#constructor
			 * @override
			 */
			constructor: function() {
				this.callParent(arguments);
				this.initResourcesValues(resources);
			},

			/**
			 * Method for subscribe by default for afterrender and afterrerender.
			 */
			loadModule: this.BPMSoft.emptyFn,

			/**
			 * Returns filters based on section filters.
			 * @return {Object} Filters based on section filters.
			 */
			getQuickFilters: function() {
				const sectionBindingColumn = this.get("sectionBindingColumn");
				if (Ext.isEmpty(this.get("sectionId")) || Ext.isEmpty(sectionBindingColumn)) {
					return this.Ext.create("BPMSoft.FilterGroup");
				}
				if (this.get("primaryColumnValue")) {
					const filter = this.Ext.create("BPMSoft.FilterGroup");
					filter.addItem(BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "Id", this.get("primaryColumnValue")));
					this.updateModuleFilter(filter, sectionBindingColumn);
					return filter;
				}
				const quickFilter = this.sandbox.publish("GetFiltersCollection", null);
				if (quickFilter) {
					const sectionEntitySchema = BPMSoft[this.get("sectionEntitySchemaName")];
					const primaryColumnName = sectionEntitySchema && sectionEntitySchema.primaryColumnName;
					if (!quickFilter.getIsEnabled() && primaryColumnName) {
						quickFilter.addItem(BPMSoft.createColumnIsNotNullFilter(primaryColumnName));
					}
					if (sectionEntitySchema && sectionEntitySchema.name) {
						this.updateModuleFilter(quickFilter, sectionBindingColumn);
					}
				}
				return quickFilter;
			},
			
			/**
			 * @inheritDoc
			 * @override
			 */
			onDestroy: function() {
				this.callParent(arguments);
				this.mixins.QueryCancellationMixin.abortRegisteredQueries.call(this);
			}

			// endregion

		});
	});
