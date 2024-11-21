define("EntitySchemaFilterProviderModule", ["BPMSoft", "sandbox", "EntitySchemaFilterProviderModuleResources",
	"StructureExplorerUtilities", "LookupUtilities"],
	function(BPMSoft, sandbox, resources, StructureExplorerUtilities, LookupUtilities) {

		/**
		 * ################ ###### ########
		 * @private
		 * @type {Object}
		 */
		var localizableStrings = resources.localizableStrings;

		/**
		 * @class BPMSoft.data.filters.EntitySchemaFilterProvider
		 * ######### ########## #### ########
		 */
		Ext.define("BPMSoft.data.filters.EntitySchemaFilterProvider", {
			extend: "BPMSoft.data.filters.BaseFilterProvider",
			alternateClassName: "BPMSoft.EntitySchemaFilterProvider",
			sandbox: sandbox,

			/**
			 * ######### ###### ## {@link Ext.Element} # ####### ##### ########### ####### ##########.
			 * #### ######## ####### - ## ######### ###### ########### ##### ## ## ########## ############.
			 * #### ######## ## ####### - ## ##### ############## ######## ##### {@link #render render()}
			 * @type {Ext.Element}
			 */
			renderTo: null,

			/**
			 * Root schema name.
			 * @type {String}
			 */
			rootSchemaName: "",

			/**
			 * Indicates the filter provider can display column Id.
			 * @type {Boolean}
			 */
			canDisplayId: false,

			/**
			 * Indicates if the lookup actions are visible.
			 * @type {Boolean}
			 */
			shouldHideLookupActions: false,

			/**
			 * ############# ###### ###### #######
			 * @type {String}
			 */
			structureExplorerId: "",

			/**
			 * ############# ###### ###### ########## ########
			 * @type {String}
			 */
			selectDataId: "",

			/**
			 * ########### #### ########
			 * @type {BPMSoft.FilterType[]}
			 */
			allowedFilterTypes: [
				BPMSoft.FilterType.COMPARE,
				BPMSoft.FilterType.IS_NULL,
				BPMSoft.FilterType.IN,
				BPMSoft.FilterType.EXISTS,
				BPMSoft.FilterType.INNER_JOIN
			],

			leftExpressionTypes: [
				"ColumnExpression"
			],

			/**
			 * Indicates if the column settings are hidden.
			 * @type {Boolean}
			 */
			isColumnSettingsHidden: false,

			/**
			 * ####### ######### #########
			 * @return {BPMSoft.Collection} ########## ######### ######### #########
			 */
			constructor: function() {
				this.callParent(arguments);
				this.initDateMacrosTypes();
				var sandbox = this.sandbox;
				var structureExplorerId = this.structureExplorerId = sandbox.id + "_StructureExplorerPage";
				sandbox.subscribe("StructureExplorerInfo", function() {
					return {
						useBackwards: true,
						useExists: true,
						summaryColumnsOnly: false
					};
				}, [structureExplorerId]);
				this.selectDataId = sandbox.id + "_LookupPage";
				var entitySchemaFilterProvider = this;
				sandbox.subscribe("GetStructureExplorerSchemaName", function() {
					return entitySchemaFilterProvider.rootSchemaName;
				}, [structureExplorerId]);
			},

			/**
			 * ######### ####### ###### #######
			 * @private
			 */
			onColumnSelected: function(leftExpressionResult, callback, scope) {
				callback.call(scope || this, leftExpressionResult);
			},

			/**
			 * ######## ### ######### ## ######### ## #### ######## dataValueType
			 * @param {BPMSoft.DataValueType} dataValueType ### ########
			 * @return {BPMSoft.AggregationType} ########## ### #########
			 */
			getAggregationTypeByDataValueType: function(dataValueType) {
				var result;
				switch (dataValueType) {
					case BPMSoft.DataValueType.INTEGER:
					case BPMSoft.DataValueType.FLOAT:
					case BPMSoft.DataValueType.MONEY:
						result = BPMSoft.AggregationType.SUM;
						break;
					case BPMSoft.DataValueType.DATE:
					case BPMSoft.DataValueType.DATE_TIME:
					case BPMSoft.DataValueType.TIME:
						result = BPMSoft.AggregationType.MAX;
						break;
					default:
						throw new BPMSoft.UnsupportedTypeException();
				}
				return result;
			},

			/**
			 * ######## ##### ##### ######### # ######## ####### callback # ######### scope
			 * @virtual
			 * @param {Function} callback #######, ####### ##### ####### ### ######### ###### ##### #########
			 * @param {Object} scope ########, # ####### ##### ####### ####### callback
			 * @param {BPMSoft.BaseFilter} oldFilter ############ ######, ####### ##### ######## #########
			 */
			getLeftExpression: function(callback, scope, oldFilter) {
				var entitySchemaFilterProvider = this;
				var config = this.getLeftExpressionConfig();
				if (oldFilter) {
					var oldFilterConfig = {
						columnPath: oldFilter.leftExpression.columnPath,
						isAggregative: oldFilter.isAggregative,
						leftExpressionAggregationType: oldFilter.leftExpression.aggregationType,
						leftExpressionFilterType: oldFilter.filterType
					};
					Ext.apply(config, oldFilterConfig);
				}
				var handler = function(args) {
					entitySchemaFilterProvider.onColumnSelected(args, callback, scope);
				};
				this.openStructureExplorer(config, handler, this);
			},

			/**
			 * Opens the structure explorer.
			 * @private
			 * @param {Object} config Config.
			 * @param {Function} callback Callback function.
			 * @param {Function} callback Callback execution context.
			 */
			openStructureExplorer: function(config, callback, scope) {
				StructureExplorerUtilities.Open(this.sandbox, config, callback, this.renderTo, scope || this);
			},

			/**
			 * Returns config for the editor of left expression.
			 * @protected
			 * @returns {Object} Config.
			 */
			getLeftExpressionConfig: function() {
				return {
					excludeDataValueTypes: [BPMSoft.DataValueType.IMAGELOOKUP],
					useBackwards: true,
					displayId: this.canDisplayId,
					schemaName: this.rootSchemaName
				};
			},

			/**
			 * ####### ####### ###### ## ######## ############
			 * @param {Object} filterConfig ############ #######
			 * @return {BPMSoft.BaseFilter} ########## ######### ######### #######
			 */
			createSimpleFilter: function(filterConfig) {
				var leftExpression = Ext.create("BPMSoft.ColumnExpression", {
					columnPath: filterConfig.leftExpressionColumnPath
				});
				var dataValueType = filterConfig.dataValueType;
				var config = {
					dataValueType: dataValueType,
					leftExpressionCaption: filterConfig.leftExpressionCaption,
					leftExpression: leftExpression
				};
				var filterClassName;
				switch (dataValueType) {
					case BPMSoft.DataValueType.LOOKUP:
						filterClassName = "BPMSoft.InFilter";
						Ext.apply(config, {
							referenceSchemaName: filterConfig.referenceSchemaName
						});
						break;
					case BPMSoft.DataValueType.IMAGELOOKUP:
						filterClassName = "BPMSoft.IsNullFilter";
						Ext.apply(config, {
							comparisonType: this.defaultImageLookupComparisonType
						});
						break;
					default:
						filterClassName = "BPMSoft.CompareFilter";
						Ext.apply(config, {
							rightExpression: Ext.create("BPMSoft.ParameterExpression", {
								parameterDataType: dataValueType,
								parameterValue: (dataValueType === BPMSoft.DataValueType.BOOLEAN) ? true : null
							})
						});
						break;
				}
				return Ext.create(filterClassName, config);
			},

			/**
			 * ####### ############# ###### ## ######## ############
			 * @param {Object} filterConfig ############ #######
			 * @return {BPMSoft.BaseFilter} ########## ######### ######### #######
			 */
			createAggregativeFilter: function(filterConfig) {
				var config = {
					isAggregative: true,
					leftExpressionCaption: filterConfig.leftExpressionCaption
				};
				var referenceSchemaName = filterConfig.referenceSchemaName;
				var subFilters = Ext.create("BPMSoft.FilterGroup", {
					rootSchemaName: referenceSchemaName,
					key: BPMSoft.generateGUID()
				});
				var filterClassName = "BPMSoft.CompareFilter";
				var leftExpressionClassName = "BPMSoft.AggregationQueryExpression";
				var dataValueType = filterConfig.dataValueType;
				if (!dataValueType) {
					dataValueType = BPMSoft.DataValueType.INTEGER;
				}
				var useAggregativeFunction = filterConfig.isAggregative;
				var aggregationType = this.getAggregationTypeByDataValueType(dataValueType);
				if (useAggregativeFunction) {
					switch (filterConfig.aggregationFunction) {
						case "exists":
							filterClassName = "BPMSoft.ExistsFilter";
							leftExpressionClassName = "BPMSoft.ColumnExpression";
							break;
						case "count":
							dataValueType = BPMSoft.DataValueType.INTEGER;
							aggregationType = BPMSoft.AggregationType.COUNT;
							break;
					}
				}
				Ext.apply(config, {
					leftExpression: Ext.create(leftExpressionClassName, {
						columnPath: filterConfig.leftExpressionColumnPath
					})
				});
				if (filterClassName === "BPMSoft.CompareFilter") {
					Ext.apply(config, {
						comparisonType: this.defaultAggregationComparisonType,
						dataValueType: dataValueType,
						rightExpression: Ext.create("BPMSoft.ParameterExpression", {
							parameterDataType: dataValueType,
							parameterValue: null
						})
					});
					Ext.apply(config.leftExpression, {
						subFilters: subFilters,
						aggregationType: aggregationType
					});
				} else {
					config.subFilters = subFilters;
				}
				return Ext.create(filterClassName, config);
			},

			/**
			 * ####### ###### ## ######### ## ######## ############
			 * @param {Object} filterConfig ############ #######
			 * @return {BPMSoft.BaseFilter} ########## ######### ######### #######
			 */
			createDefaultFilter: function(filterConfig) {
				var defaultFilter;
				if (filterConfig.isBackward) {
					defaultFilter = this.createAggregativeFilter(filterConfig);
				} else {
					defaultFilter = this.createSimpleFilter(filterConfig);
				}
				return defaultFilter;
			},

			/**
			 * ####### ######## ## ######### ######## ##### #######
			 * @param {String} schemaName ######## ##### #######
			 */
			subscribeForFilterSchemaName: function(schemaName) {
				var sandbox = this.sandbox;
				var structureExplorerId = this.structureExplorerId = sandbox.id + "_StructureExplorerPage";
				sandbox.subscribe("GetStructureExplorerSchemaName", function() {
					return schemaName;
				}, [structureExplorerId]);
			},

			/**
			 * ######## ######## ### ########## ####### # ######### ####### callback # ######### scope
			 * @virtual
			 * @param {BPMSoft.BaseFilter} filter ###### ## ########## #######
			 */
			getLookupFilterValue: function(filter) {
				var selectDataId = this.selectDataId;
				var sandbox = this.sandbox;
				sandbox.subscribe("LookupInfo", function() {
					return {
						entitySchemaName: filter.referenceSchemaName,
						multiSelect: true
					};
				}, [selectDataId]);
				var entitySchemaFilterProvider = this;
				var handler = function(lookupValueResult) {
					var selectedValues = lookupValueResult.selectedRows.getItems();
					entitySchemaFilterProvider.setRightExpressionsValues(filter, selectedValues);
				};
				var config = this.getLookupFilterConfig(filter);
				LookupUtilities.Open(sandbox, config, handler, this, this.renderTo, false);
			},

			/**
			 * Get config for lookup.
			 * @virtual
			 * @protected
			 * @param filter Lookup filter.
			 * @returns {Object} Lookup config.
			 */
			getLookupFilterConfig: function(filter) {
				return {
					entitySchemaName: filter.referenceSchemaName,
					multiSelect: true,
					selectedValues: this.getRightExpressionSelectedItemsIds(filter),
					hideActions: this.shouldHideLookupActions,
					isColumnSettingsHidden: this.isColumnSettingsHidden
				};
			},

			/**
			 * ###### ############ ##### ######## #### ######
			 * @private
			 * @type {Object}
			 */
			dataValueTypeFilterMacrosType: {},

			/**
			 * ############## ###### ############ ##### ######## #### ######
			 * @private
			 */
			initDateMacrosTypes: function() {
				this.dataValueTypeFilterMacrosType[BPMSoft.DataValueType.TIME] = [
					BPMSoft.FilterMacrosType.HOUR_PREVIOUS,
					BPMSoft.FilterMacrosType.HOUR_CURRENT,
					BPMSoft.FilterMacrosType.HOUR_NEXT,
					BPMSoft.FilterMacrosType.HOUR_EXACT,
					BPMSoft.FilterMacrosType.HOUR_PREVIOUS_N,
					BPMSoft.FilterMacrosType.HOUR_NEXT_N
				];
				this.dataValueTypeFilterMacrosType[BPMSoft.DataValueType.DATE] = [
					BPMSoft.FilterMacrosType.DAY_YESTERDAY,
					BPMSoft.FilterMacrosType.DAY_TODAY,
					BPMSoft.FilterMacrosType.DAY_TOMORROW,
					BPMSoft.FilterMacrosType.DAY_OF_MONTH,
					BPMSoft.FilterMacrosType.DAY_OF_WEEK,
					BPMSoft.FilterMacrosType.DAY_PREVIOUS_N,
					BPMSoft.FilterMacrosType.DAY_NEXT_N,
					BPMSoft.FilterMacrosType.WEEK_PREVIOUS,
					BPMSoft.FilterMacrosType.WEEK_CURRENT,
					BPMSoft.FilterMacrosType.WEEK_NEXT,
					BPMSoft.FilterMacrosType.MONTH_PREVIOUS,
					BPMSoft.FilterMacrosType.MONTH_CURRENT,
					BPMSoft.FilterMacrosType.MONTH_NEXT,
					BPMSoft.FilterMacrosType.MONTH_EXACT,
					BPMSoft.FilterMacrosType.QUARTER_PREVIOUS,
					BPMSoft.FilterMacrosType.QUARTER_CURRENT,
					BPMSoft.FilterMacrosType.QUARTER_NEXT,
					BPMSoft.FilterMacrosType.HALF_YEAR_PREVIOUS,
					BPMSoft.FilterMacrosType.HALF_YEAR_CURRENT,
					BPMSoft.FilterMacrosType.HALF_YEAR_NEXT,
					BPMSoft.FilterMacrosType.YEAR_PREVIOUS,
					BPMSoft.FilterMacrosType.YEAR_CURRENT,
					BPMSoft.FilterMacrosType.YEAR_NEXT,
					BPMSoft.FilterMacrosType.YEAR_EXACT,
					BPMSoft.FilterMacrosType.DAY_OF_YEAR_TODAY,
					BPMSoft.FilterMacrosType.DAY_OF_YEAR_TODAY_PLUS_DAYS_OFFSET,
					BPMSoft.FilterMacrosType.NEXT_N_DAYS_OF_YEAR,
					BPMSoft.FilterMacrosType.PREVIOUS_N_DAYS_OF_YEAR
				];
				this.dataValueTypeFilterMacrosType[BPMSoft.DataValueType.DATE_TIME] =
						this.dataValueTypeFilterMacrosType[BPMSoft.DataValueType.TIME].concat(
								this.dataValueTypeFilterMacrosType[BPMSoft.DataValueType.DATE]
						);
			},

			/**
			 * ########## ###### ########## ######## ### ########## #### ######
			 * @param {BPMSoft.core.enums.DataValueType} dataValueType ### ######
			 * @return {BPMSoft.FilterMacrosType[]} ###### ########## ########
			 */
			getDataValueTypeMacrosType: function(dataValueType) {
				return this.dataValueTypeFilterMacrosType[dataValueType];
			},

			/**
			 * ########## ###### ######## ### ########## #### #######
			 * @throws {BPMSoft.UnsupportedTypeException}
			 * #### ### ########## #### ####### ## ###### ###### ########
			 * @param {BPMSoft.FilterMacrosType} filterMacrosType ### #######
			 * @return {Object} ###### ########
			 */
			getMacrosTypeConfig: function(filterMacrosType) {
				return BPMSoft.getMacrosTypeConfig(filterMacrosType);
			},

			/**
			 * ########## ###### ######### ######## ### ########## #######
			 * @param {BPMSoft.BaseFilter} filter
			 * @return {BPMSoft.FilterMacrosType[]}
			 */
			getAllowedMacrosTypes: function(filter) {
				var filterDataValueType = filter.dataValueType;
				var macrosTypes = [];
				if (BPMSoft.isDateDataValueType(filterDataValueType)) {
					macrosTypes = BPMSoft.deepClone(this.getDataValueTypeMacrosType(filterDataValueType));
				} else if (filter.referenceSchemaName === "Contact") {
					macrosTypes.push(BPMSoft.FilterMacrosType.CONTACT_CURRENT);
				} else if (filter.referenceSchemaName === "SysAdminUnit") {
					macrosTypes.push(BPMSoft.FilterMacrosType.USER_CURRENT);
				}
				return macrosTypes;
			},

			/**
			 * Checks if the value is in the configured range. If not, returns the closest range boundary.
			 * @private
			 * @param {Object} macrosConfig Configuration object for the specified macros type.
			 * @param {Number} macrosConfig.value.maxValue Maximum allowed value.
			 * @param {Number} macrosConfig.value.minValue Minimum allowed value.
			 * @param {Number} value Macros value to be validated and corrected if out of range.
			 * @returns {Number} Initial macros value if it is within the range, otherwise the closest range boundry.
			 */
			_getValidMacrosValue: function(macrosConfig, value) {
				var macrosValue = macrosConfig && macrosConfig.value;
				if (macrosValue && macrosValue.dataValueType === BPMSoft.DataValueType.INTEGER) {
					var maxValue = macrosValue.maxValue;
					var minValue = macrosValue.minValue;
					if (!Ext.isEmpty(maxValue) && maxValue < value) {
						return maxValue;
					}
					if (!Ext.isEmpty(minValue) && minValue > value) {
						return minValue;
					}
				}
				return value;
			},

			/**
			 * ############# ######## ### ###### ##### #######.
			 * @throws {BPMSoft.UnsupportedTypeException}
			 * #### ### ####### ############### ######### ## ###### # ## ##### ####.
			 * @param {BPMSoft.BaseFilter} filter ###### #######.
			 * @param {String/Number/Date/Boolean} value ########.
			 * @param {BPMSoft.FilterMacrosType} macrosType ### #######.
			 * @param {BPMSoft.core.enums.DataValueType} [dataValueType] ### #########.
			 */
			setRightExpressionValue: function(filter, value, macrosType, dataValueType) {
				var functionArgumentExpression = filter.leftExpression.functionArgument;
				if (functionArgumentExpression) {
					filter.leftExpression = functionArgumentExpression;
				}
				var expression;
				if (!Ext.isEmpty(macrosType)) {
					var macrosTypeConfig = this.getMacrosTypeConfig(macrosType);
					value = this._getValidMacrosValue(macrosTypeConfig, value);
					switch (macrosTypeConfig.functionType) {
						case BPMSoft.FunctionType.MACROS:
							expression = Ext.create("BPMSoft.FunctionExpression", {
								functionType: BPMSoft.FunctionType.MACROS,
								macrosType: macrosTypeConfig.queryMacrosType
							});
							if (BPMSoft.ParameterizedFilterMacrosTypes.indexOf(macrosType) > -1) {
								expression.functionArgument = Ext.create("BPMSoft.ParameterExpression", {
									parameterDataType: macrosTypeConfig.value.dataValueType,
									parameterValue: value
								});
							}
							break;
						case BPMSoft.FunctionType.DATE_PART:
							var aggregationType = filter.leftExpression && filter.leftExpression.aggregationType;
							var leftExpression = Ext.create("BPMSoft.FunctionExpression", {
								functionType: BPMSoft.FunctionType.DATE_PART,
								datePartType: macrosTypeConfig.datePartType,
								functionArgument: filter.leftExpression,
								aggregationType: aggregationType
							});
							filter.leftExpression = leftExpression;
							var macrosTypeConfigValue = macrosTypeConfig.value;
							var hasDisplayRange = !Ext.isEmpty(macrosTypeConfigValue.displayValueRange);
							var parameterValue = (hasDisplayRange && !Ext.isEmpty(value)) ? (value + 1) : value;
							expression = Ext.create("BPMSoft.ParameterExpression", {
								parameterDataType: macrosTypeConfigValue.dataValueType,
								parameterValue: parameterValue
							});
							break;
						default:
							throw new BPMSoft.UnsupportedTypeException();
					}
					if (filter.filterType === BPMSoft.FilterType.IN) {
						var config = {
							leftExpressionColumnPath: filter.leftExpression.columnPath,
							dataValueType: BPMSoft.DataValueType.GUID,
							leftExpressionCaption: filter.leftExpressionCaption
						};
						var newFilter = this.createSimpleFilter(config);
						newFilter.comparisonType = filter.comparisonType;
						newFilter.referenceSchemaName = filter.referenceSchemaName;
						newFilter.setRightExpression(expression);
						this.fireEvent("replaceFilter", filter, newFilter);
					} else {
						filter.setRightExpression(expression);
					}
				} else {
					expression = Ext.create("BPMSoft.ParameterExpression", {
						parameterDataType: dataValueType || filter.dataValueType,
						parameterValue: value
					});
					filter.setRightExpression(expression);
				}
			},

			/**
			 * ############# ######## ### ###### ##### #######.
			 * @throws {BPMSoft.UnsupportedTypeException}
			 * #### values ## ######, ## ############ ##########.
			 * @param {BPMSoft.BaseFilter} filter ###### #######.
			 * @param {Array} values ###### ########.
			 * @param {BPMSoft.core.enums.DataValueType} [dataValueType] ### #########.
			 */
			setRightExpressionsValues: function(filter, values, dataValueType) {
				if (values && !Ext.isArray(values)) {
					throw new BPMSoft.UnsupportedTypeException({
						message: localizableStrings.setRightExpressionsValuesException
					});
				}
				var actualFilter;
				if (filter.filterType !== BPMSoft.FilterType.IN) {
					var config = {
						leftExpressionColumnPath: filter.leftExpression.columnPath,
						dataValueType: BPMSoft.DataValueType.LOOKUP,
						referenceSchemaName: filter.referenceSchemaName,
						leftExpressionCaption: filter.leftExpressionCaption
					};
					actualFilter = this.createSimpleFilter(config);
					this.fireEvent("replaceFilter", filter, actualFilter);
				} else {
					actualFilter = filter;
				}
				var expressions = [];
				BPMSoft.each(values, function(value) {
					var expression = Ext.create("BPMSoft.ParameterExpression", {
						parameterValue: value,
						parameterDataType: dataValueType || BPMSoft.DataValueType.LOOKUP
					});
					expressions.push(expression);
				});
				actualFilter.setRightExpressions(expressions);
			},

			/**
			 * ########## ###### ######## ### #### ####### #######
			 * @throws {BPMSoft.UnsupportedTypeException}
			 * #### ### #### ####### ####### ## ###### ##### ########### #### ####### #######
			 * @param {BPMSoft.BaseFilter} filter ####### #######
			 * @return {Object} ###### ######## ### #### ####### #######
			 */
			getFilterMacrosConfig: function(filter) {
				return BPMSoft.GetFilterMacrosConfig(filter);
			},

			/**
			 * ########## ###### ############ ######## ####### #######
			 * @param {BPMSoft.BaseFilter} filter ####### #######
			 * @return {Object} ###### ############ ######## ####### #######
			 * @return {Object.macrosCaption} ######### #######
			 * @return {Object.macrosParameterCaption} ###### ############ ######## ####### #######
			 */
			getRightExpressionMacrosDisplayValues: function(filter) {
				return BPMSoft.GetRightExpressionMacrosDisplayValues(filter);
			},

			/**
			 * ######### ###### ############### ######## ####### ### ######## # #### ###### ## ###########.
			 * @param {BPMSoft.BaseFilter} filter ####### #######.
			 * @return {Array} ###### ###############.
			 */
			getRightExpressionSelectedItemsIds: function(filter) {
				if (!filter.rightExpressions || !Ext.isArray(filter.rightExpressions)) {
					return null;
				}
				var selectedIds = [];
				BPMSoft.each(filter.rightExpressions, function(selectedItem) {
					var filterValue = selectedItem.parameter && selectedItem.parameter.getValue();
					if (filterValue && filterValue.value) {
						selectedIds.push(filterValue.value);
					}
				}, this);
				return selectedIds;
			}

		});

		return BPMSoft.EntitySchemaFilterProvider;
	});
