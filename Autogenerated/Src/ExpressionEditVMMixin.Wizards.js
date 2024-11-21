define("ExpressionEditVMMixin", ["ExpressionEnums", "StructureExplorerUtilitiesV2",
		"StructureExplorerParameterMainViewModel", "BusinessRuleExpressionDataQueryBuilder"],
	function() {
		/**
		 * View model mixin for work with ExpressionEdit.
		 */
		Ext.define("BPMSoft.configuration.mixins.ExpressionEditVMMixin", {
			alternateClassName: "BPMSoft.ExpressionEditVMMixin",

			//region Methods: Private

			/**
			 * @private
			 */
			_loadToCollection: function(loader, outList, callback) {
				if (!outList) {
					return;
				}
				const builder = Ext.create("BPMSoft.BusinessRuleExpressionDataQueryBuilder");
				loader(builder).then(function(collection) {
					outList.reloadAll(collection);
					if (callback) {
						callback.call(this);
					}
				});
			},

			/**
			 * @private
			 */
			_getBuilderSortCollectionByKey: function(key, builder, dataGetterConfig) {
				return builder
					.from(builder.buildPageSchemaItemGetterByKey(key, dataGetterConfig))
					.then(builder.select(builder.buildPageSchemaItemTypesValueSelector()))
					.then(builder.sortByDisplayValue())
					.then(builder.toCollection());
			},

			/**
			 * @private
			 */
			_loadLookupValue: function(loader, callback, scope) {
				const builder = Ext.create("BPMSoft.BusinessRuleExpressionDataQueryBuilder");
				loader(builder).then(function(lookupValue) {
					callback.call(scope, lookupValue);
				});
			},

			/**
			 * @private
			 */
			_getFilterProperties: function(filter) {
				const result = {};
				result.filterValue = "";
				result.filterFn = null;
				if (Ext.isString(filter)) {
					result.filterValue = filter;
					return result;
				}
				if (Ext.isFunction(filter.filterFn)) {
					result.filterFn = filter.filterFn;
				}
				if (Ext.isString(filter.filterValue)) {
					result.filterValue = filter.filterValue;
				}
				return result;
			},

			//endregion

			//region Methods: Protected

			/**
			 * Prepare reference entity schema list.
			 * @protected
			 * @param {String} filter Filter value
			 * @param {BPMSoft.core.collections.Collection} list List.
			 */
			prepareReferenceSchemaList: function(filter, list) {
				if (!list) {
					return;
				}
				list.clear();
				var loadItems = {};
				BPMSoft.EntitySchemaManager.initialize(function() {
					var items = BPMSoft.EntitySchemaManager.getItems();
					items.each(function(item) {
						if (!item.getIsVirtual() && !item.getExtendParent()) {
							var uId = item.getUId();
							loadItems[uId] = {
								value: uId,
								displayValue: item.getCaption(),
								name: item.getName()
							};
						}
					}, this);
					list.loadAll(loadItems);
				}, this);
			},

			/**
			 * Process lookup value list.
			 * @protected
			 * @param {String} filter Filter value
			 * @param {BPMSoft.core.collections.Collection} list List.
			 * @param {BPMSoft.ExpressionEnums.ExpressionType} expressionType Expression type.
			 * @param {String} referenceSchemaName Reference schema name.
			 */
			prepareValueList: function(filter, list, expressionType, referenceSchemaName) {
				if (!list) {
					return;
				}
				list.clear();
				if (referenceSchemaName && expressionType === BPMSoft.ExpressionEnums.ExpressionType.CONSTANT) {
					this.prepareConstantValueList(filter, list, referenceSchemaName);
				}
			},

			/**
			 * Prepare constant lookup value list.
			 * @protected
			 * @param {String} filter Filter value
			 * @param {BPMSoft.core.collections.Collection} list List.
			 * @param {String} referenceSchemaName Reference schema name.
			 */
			prepareConstantValueList: function(filter, list, referenceSchemaName) {
				if (!list) {
					return;
				}
				var config = {
					"entitySchemaName": referenceSchemaName,
					"filterValue": filter
				};
				this.loadValueList(config, function(items) {
					list.loadAll(items);
				});
			},

			/**
			 * Load value list.
			 * @protected
			 * @param {Object} config Lookup config.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			loadValueList: function(config, callback, scope) {
				BPMSoft.chain(
					function(next) {
						next(config);
					},
					this.getEntitySchemaLookupQueryConfig,
					this.generateEntitySchemaLookupQuery,
					this.requestLookupValueItems,
					function(next, items) {
						callback.call(scope, items);
					},
					this);
			},

			/**
			 * Return entity schema lookup query config.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} config Lookup config.
			 * @param {String} config.entitySchemaName Entity schema name.
			 */
			getEntitySchemaLookupQueryConfig: function(callback, config) {
				BPMSoft.require([config.entitySchemaName], function(schema) {
					if (schema) {
						Ext.apply(config, {
							"primaryColumnName": schema.primaryColumnName,
							"primaryDisplayColumnName": schema.primaryDisplayColumnName
						});
						callback.call(this, config);
					}
				}, this);
			},

			/**
			 * Return entity schema lookup query.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} config Lookup config.
			 * @param {String} config.entitySchemaName Entity schema name.
			 * @param {String} config.primaryColumnName Entity schema primary column name.
			 * @param {String} config.primaryDisplayColumnName Entity schema primary display column name.
			 * @param {String} config.filterValue Filter value.
			 */
			generateEntitySchemaLookupQuery: function(callback, config) {
				var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
					"rootSchemaName": config.entitySchemaName,
					"rowCount": 100
				});
				esq.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_COLUMN, "value");
				if (!Ext.isEmpty(config.primaryDisplayColumnName)) {
					var primaryDisplayColumn = esq.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_DISPLAY_COLUMN, "displayValue");
					primaryDisplayColumn.orderPosition = 1;
					primaryDisplayColumn.orderDirection = BPMSoft.OrderDirection.ASC;
				}
				if (!Ext.isEmpty(config.filterValue)) {
					esq.filters.add("valueFilter", BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.START_WITH, config.primaryDisplayColumnName, config.filterValue));
				}
				callback.call(this, esq, config);
			},

			/**
			 * Require lookup entity schema query.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {BPMSoft.EntitySchemaQuery} esq Entity schema query.
			 */
			requestLookupValueItems: function(callback, esq) {
				esq.getEntityCollection(function(response) {
					if (response.success && response.collection) {
						this.onLookupValueItemsResponse(response.collection, callback, this);
					}
				}, this);
			},

			/**
			 * Prepare response of entity schema query.
			 * @protected
			 * @param {BPMSoft.core.collections.Collection} collection Response collection.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			onLookupValueItemsResponse: function(collection, callback, scope) {
				var items = {};
				collection.each(function(item) {
					var value = item.get("value");
					items[value] = {
						"value": value,
						"displayValue": item.get("displayValue") || value
					};
				}, this);
				callback.call(scope, items);
			},

			/**
			 * Returns reference schema by UId.
			 * @protected
			 * @param {String} referenceSchemaUId Reference schema UId.
			 * @return {Object} Reference schema.
			 */
			getReferenceSchemaLookupValue: function(referenceSchemaUId) {
				if (!BPMSoft.EntitySchemaManager.isInitialized) {
					return null;
				} else {
					var referenceSchema = BPMSoft.EntitySchemaManager.findItem(referenceSchemaUId);
					return referenceSchema && {
						value: referenceSchemaUId,
						displayValue: referenceSchema.getCaption(),
						name: referenceSchema.getName()
					};
				}
			},

			/**
			 * Returns reference schema by name.
			 * @protected
			 * @param {String} referenceSchemaName Reference schema name.
			 * @return {Object} Reference schema.
			 */
			getReferenceSchemaLookupValueByName: function(referenceSchemaName) {
				if (!Ext.isEmpty(referenceSchemaName)) {
					var referenceSchema = BPMSoft.EntitySchemaManager.findRootSchemaItemByName(referenceSchemaName);
					return this.getReferenceSchemaLookupValue(referenceSchema && referenceSchema.getUId());
				}
			},

			/**
			 * Loads entity schema column structure explorer.
			 * @protected
			 * @param {Object} explorerConfig Structure explorer config.
			 * @param {Boolean} explorerConfig.useBackwards Flag indicates when to use backwards relations.
			 * @param {Object} explorerConfig.expression Expression.
			 * @param {Number} explorerConfig.expandLevel Related lookup columns expand level.
			 * @param {String} explorerConfig.entitySchemaUId Entity schema uid.
			 * @param {String} explorerConfig.pageSchemaUId Client unit schema uid.
			 * @param {Function} callback The callback function.
			 * @param {Object} scope The callback function context.
			 */
			loadEntitySchemaColumnVocabulary: function(explorerConfig, callback, scope) {
				var moduleConfig = {
					useBackwards: explorerConfig.useBackwards || false,
					columnPath: explorerConfig.expression && explorerConfig.expression.name,
					displayId: explorerConfig.displayId,
					expandLevel: explorerConfig.expandLevel,
					allowedReferenceSchemas: explorerConfig.allowedReferenceSchemas,
					lookupsColumnsOnly: explorerConfig.lookupsColumnsOnly,
					columnsFiltrationMethod: explorerConfig.columnsFiltrationMethod
				};
				if (explorerConfig.entitySchemaUId) {
					var entityItem = BPMSoft.EntitySchemaManager.getItem(explorerConfig.entitySchemaUId);
					moduleConfig.schemaName = entityItem.getName();
				} else {
					moduleConfig.viewModelClassName = "BPMSoft.StructureExplorerParameterMainViewModel";
					moduleConfig.pageSchemaUId = explorerConfig.pageSchemaUId;
				}
				BPMSoft.StructureExplorerUtilities.open({
					moduleName: "StructureExploreModuleV2",
					moduleConfig: moduleConfig,
					handlerMethod: function(result) {
						callback.call(scope, {
							value: result.metaPath.join("."),
							name: result.path.join("."),
							displayValue: result.caption.join("."),
							dataValueType: result.dataValueType,
							referenceSchema: this.getReferenceSchemaLookupValueByName(result.referenceSchemaName)
						});
					},
					scope: this
				});
			},

			/**
			 * Prepares entity schema column list.
			 * @protected
			 * @param {Object} dataGetterConfig Data getter configuration object.
			 * @param {String} dataGetterConfig.entitySchemaUId Entity schema identifier.
			 * @param {String} dataGetterConfig.packageUId Package identifier.
			 * @param {Object} filterConfig Filter configuration object.
			 * @param {String} filterConfig.filterValue Filter search value.
			 * @param {Array} filterConfig.filterFns Filter functions.
			 * @param {BPMSoft.core.collections.Collection} outList Output page schema attributes list.
			 * @param {Function} callback Callback function
			 */
			prepareEntitySchemaColumnList: function(dataGetterConfig, filterConfig, outList, callback) {
				this._loadToCollection(function(builder) {
					const filterValue = filterConfig.filterValue || "";
					const filterFns = filterConfig.filterFns || [];
					const filters = [builder.buildEntitySchemaColumnSimpleValueFilter({filterValue: filterValue})]
						.concat(filterFns);
					return builder
						.from(builder.buildEntitySchemaColumnsGetter(dataGetterConfig))
						.then(builder.filter(filters))
						.then(builder.select(builder.buildEntitySchemaColumnValueSelector()))
						.then(builder.sortByDisplayValue())
						.then(builder.toCollection());
				}, outList, callback);
			},

			/**
			 * Prepares page schema attribute list.
			 * @protected
			 * @param {Object} dataGetterConfig Data getter configuration object.
			 * @param {String} dataGetterConfig.pageSchemaUId Page schema identifier.
			 * @param {String} dataGetterConfig.packageUId Package identifier.
			 * @param {Object} filterConfig Filter configuration object.
			 * @param {String} filterConfig.filterValue Filter search value.
			 * @param {Array} filterConfig.filterFns Filter functions.
			 * @param {BPMSoft.core.collections.Collection} outList Output page schema attributes list.
			 */
			preparePageSchemaParameterList: function(dataGetterConfig, filterConfig, outList, callback) {
				this._loadToCollection(function(builder) {
					const filterValue = filterConfig.filterValue || "";
					const filterFns = filterConfig.filterFns || [];
					const filters = [builder.buildPageSchemaParameterSimpleValueFilter({filterValue: filterValue})]
						.concat(filterFns);
					return builder
						.from(builder.buildPageSchemaParametersGetter(dataGetterConfig))
						.then(builder.filter(filters))
						.then(builder.select(builder.buildPageSchemaParameterValueSelector()))
						.then(builder.sortByDisplayValue())
						.then(builder.toCollection());
				}, outList, callback);
			},

			/**
			 * Returns data value type of system value.
			 * @protected
			 * @param {BPMSoft.SystemValueType} sysValueType System value type.
			 * @return {String} Data value type.
			 */
			findSysValueDataValueType: function(sysValueType) {
				const pairs = [{
					dataValueType: BPMSoft.DataValueType.TIME,
					sysValueTypes: [BPMSoft.SystemValueType.CURRENT_TIME]
				}, {
					dataValueType: BPMSoft.DataValueType.DATE,
					sysValueTypes: [BPMSoft.SystemValueType.CURRENT_DATE]
				}, {
					dataValueType: BPMSoft.DataValueType.DATE_TIME,
					sysValueTypes: [BPMSoft.SystemValueType.CURRENT_DATE_TIME]
				}, {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					sysValueTypes: [
						BPMSoft.SystemValueType.CURRENT_USER,
						BPMSoft.SystemValueType.CURRENT_USER_CONTACT,
						BPMSoft.SystemValueType.CURRENT_USER_ACCOUNT,
						BPMSoft.SystemValueType.CURRENT_FUNCTIONAL_ROLES,
						BPMSoft.SystemValueType.CURRENT_ORGANIZATIONAL_ROLES
					]
				}];
				for (let i = 0; i < pairs.length; i++) {
					if (BPMSoft.contains(pairs[i].sysValueTypes, sysValueType)) {
						return pairs[i].dataValueType;
					}
				}
			},

			/**
			 * Returns reference schema name of system value.
			 * @protected
			 * @param {BPMSoft.SystemValueType} sysValueType System value type.
			 * @return {String} Reference schema name.
			 */
			findSysValueReferenceSchemaName: function(sysValueType) {
				const pairs = [{
					referenceSchemaName: "Contact",
					sysValueTypes: [BPMSoft.SystemValueType.CURRENT_USER_CONTACT]
				}, {
					referenceSchemaName: "Account",
					sysValueTypes: [BPMSoft.SystemValueType.CURRENT_USER_ACCOUNT]
				}, {
					referenceSchemaName: "SysAdminUnit",
					sysValueTypes: [BPMSoft.SystemValueType.CURRENT_USER]
				}, {
					referenceSchemaName: null,
					sysValueTypes: [
						BPMSoft.SystemValueType.CURRENT_DATE_TIME,
						BPMSoft.SystemValueType.CURRENT_DATE,
						BPMSoft.SystemValueType.CURRENT_TIME
					]
				}];
				for (let i = 0; i < pairs.length; i++) {
					if (BPMSoft.contains(pairs[i].sysValueTypes, sysValueType)) {
						return pairs[i].referenceSchemaName;
					}
				}
			},

			/**
			 * Prepares system values list.
			 * @protected
			 * @param {Object} filter Filter config.
			 * @param {BPMSoft.core.collections.Collection} list System values list.
			 */
			prepareSysValuesList: function(filter, list) {
				if (!list) {
					return;
				}
				filter = this._getFilterProperties(filter);
				const filterFn = filter.filterFn;
				const filterValue = filter.filterValue;
				const sysValues = {};
				const sysValuesKeys = Object.keys(BPMSoft.SystemValueType);
				sysValuesKeys.forEach(function(key) {
					const sysValueName = BPMSoft.SystemValueType[key];
					const caption = this.getSysValueCaption(sysValueName);
					const dataValueType = this.findSysValueDataValueType(sysValueName);
					const referenceSchemaName = this.findSysValueReferenceSchemaName(sysValueName);
					const filtrationObject = {
						referenceSchemaName: referenceSchemaName,
						dataValueType: dataValueType
					};
					if (filterFn && filterFn(filtrationObject) !== true) {
						return;
					}
					if (dataValueType && caption && caption.indexOf(filterValue) >= 0) {
						sysValues[sysValueName] = {
							value: sysValueName,
							displayValue: caption,
							dataValueType: dataValueType
						};
					}
				}, this);
				list.reloadAll(sysValues);
			},

			/**
			 * Prepares system values list.
			 * @protected
			 * @param {Object} filter Column search value.
			 * @param {BPMSoft.core.collections.Collection} list System values list.
			 */
			prepareConstantList: function(filter, list) {
				if (!list) {
					return;
				}
				filter = this._getFilterProperties(filter);
				const filterFn = filter.filterFn;
				const filterValue = filter.filterValue;
				const constants = {};
				const constantKeys = Object.keys(BPMSoft.DataValueType);
				constantKeys.forEach(function(key) {
					const value = BPMSoft.DataValueType[key];
					if (filterFn && filterFn(value) !== true) {
						return;
					}
					const caption = BPMSoft.getDataValueTypeCaption(value);
					const name = BPMSoft.getDataValueTypeName(value);
					if (caption && caption.indexOf(filterValue) >= 0) {
						constants[name] = {
							value: name,
							displayValue: caption,
							dataValueType: value
						};
					}
				}, this);
				list.reloadAll(constants);
			},

			/**
			 * Prepares page schema attributes list.
			 * @protected
			 * @param {Object} dataGetterConfig Data getter configuration object.
			 * @param {Object} dataGetterConfig.pageSchemaUId Page schema identifier.
			 * @param {Object} filterConfig Filter configuration object.
			 * @param {String} filterConfig.filterValue Filter search value.
			 * @param {Array} filterConfig.filterFns Filter functions.
			 * @param {BPMSoft.core.collections.Collection} outList Output page schema attributes list.
			 * @param {Function} callback Callback function
			 */
			prepareAttributesList: function(dataGetterConfig, filterConfig, outList, callback) {
				this._loadToCollection(function(builder) {
					const filterValue = filterConfig.filterValue || "";
					const filterFns = filterConfig.filterFns || [];
					const filters = [builder.buildPageSchemaAttributeSimpleValueFilter({filterValue: filterValue})]
						.concat(filterFns);
					return builder
						.from(builder.buildPageSchemaItemGetterByKey("attributes_", dataGetterConfig))
						.then(builder.filter(filters))
						.then(builder.select(builder.buildPageSchemaAttributeValueSelector()))
						.then(builder.sortByDisplayValue())
						.then(builder.toCollection());
				}, outList, callback);
			},

			/**
			 * Prepares page schema tabs list.
			 * @protected
			 * @param {Object} dataGetterConfig Data getter configuration object.
			 * @param {Object} dataGetterConfig.pageSchemaUId Page schema identifier.
			 * @param {BPMSoft.core.collections.Collection} outList Output page schema tabs list.
			 * @param {Function} callback Callback function
			 */
			prepareTabsList: function(dataGetterConfig, outList, callback) {
				const scope = this;
				this._loadToCollection(function(builder) {
					return scope._getBuilderSortCollectionByKey("tabs_", builder, dataGetterConfig);
				}, outList, callback);
			},

			/**
			 * Prepares page schema modules list.
			 * @protected
			 * @param {Object} dataGetterConfig Data getter configuration object.
			 * @param {Object} dataGetterConfig.pageSchemaUId Page schema identifier.
			 * @param {BPMSoft.core.collections.Collection} outList Output page schema modules list.
			 * @param {Function} callback Callback function
			 */
			prepareModulesList: function(dataGetterConfig, outList, callback) {
				const scope = this;
				this._loadToCollection(function(builder) {
					return scope._getBuilderSortCollectionByKey("modules_", builder, dataGetterConfig);
				}, outList, callback);
			},

			/**
			 * Prepares page schema details list.
			 * @protected
			 * @param {Object} dataGetterConfig Data getter configuration object.
			 * @param {Object} dataGetterConfig.pageSchemaUId Page schema identifier.
			 * @param {BPMSoft.core.collections.Collection} outList Output page schema details list.
			 * @param {Function} callback Callback function
			 */
			prepareDetailsList: function(dataGetterConfig, outList, callback) {
				const scope = this;
				this._loadToCollection(function(builder) {
					return scope._getBuilderSortCollectionByKey("details_", builder, dataGetterConfig);
				}, outList, callback);
			},

			/**
			 * Prepares page schema groups list.
			 * @protected
			 * @param {Object} dataGetterConfig Data getter configuration object.
			 * @param {Object} dataGetterConfig.pageSchemaUId Page schema identifier.
			 * @param {BPMSoft.core.collections.Collection} outList Output page schema groups list.
			 * @param {Function} callback Callback function
			 */
			prepareGroupsList: function(dataGetterConfig, outList, callback) {
				const scope = this;
				this._loadToCollection(function(builder) {
					return scope._getBuilderSortCollectionByKey("groups_", builder, dataGetterConfig);
				}, outList, callback);
			},

			/**
			 * Returns entity schema column lookup value.
			 * @protected
			 * @param {Object} config Config.
			 * @param {String} config.entitySchemaUId Entity schema UId.
			 * @param {String} config.packageUId Package UId.
			 * @param {String} config.columnName Entity column name.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			getEntitySchemaColumnLookupValue: function(config, callback, scope) {
				this._loadLookupValue(function(builder) {
					const entitySchemaUId = config.entitySchemaUId;
					const packageUId = config.packageUId;
					const columnName = config.columnName;
					return builder
						.from(builder.buildEntitySchemaColumnsGetter({
							entitySchemaUId: entitySchemaUId,
							packageUId: packageUId
						}))
						.then(builder.filter([builder.buildNameFilter({name: columnName})]))
						.then(builder.select(builder.buildEntitySchemaColumnValueSelector()))
						.then(builder.firstOrDefault());
				}, callback, scope);
			},

			/**
			 * Returns page schema parameter lookup value.
			 * @protected
			 * @param {Object} config Config.
			 * @param {String} config.pageSchemaUId Page schema UId.
			 * @param {String} config.packageUId Package UId.
			 * @param {String} config.parameterName Parameter name.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			getPageSchemaParameterLookupValue: function(config, callback, scope) {
				this._loadLookupValue(function(builder) {
					const pageSchemaUId = config.pageSchemaUId;
					const packageUId = config.packageUId;
					const parameterName = config.parameterName;
					return builder
						.from(builder.buildPageSchemaParametersGetter({
							pageSchemaUId: pageSchemaUId,
							packageUId: packageUId
						}))
						.then(builder.filter([builder.buildNameFilter({name: parameterName})]))
						.then(builder.select(builder.buildPageSchemaParameterValueSelector()))
						.then(builder.firstOrDefault());
				}, callback, scope);
			},

			/**
			 * Returns attribute lookup value.
			 * @protected
			 * @param {Object} config Configuration object.
			 * @param {String} config.pageSchemaUId Page schema UId.
			 * @param {String} config.attributeName Attribute name.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			getAttributeLookupValue: function(config, callback, scope) {
				this._loadLookupValue(function(builder) {
					const pageSchemaUId = config.pageSchemaUId;
					const attributeName = config.attributeName;
					return builder
						.from(builder.buildPageSchemaItemGetterByKey("attributes_", {pageSchemaUId: pageSchemaUId}))
						.then(builder.filter([builder.buildNameFilter({name: attributeName})]))
						.then(builder.select(builder.buildPageSchemaAttributeValueSelector()))
						.then(builder.firstOrDefault(builder.buildPageSchemaAttributeDefaultValueGenerator({name: attributeName})));
				}, callback, scope);
			},

			getDetailLookupValue: function(config, callback, scope) {
				this._loadLookupValue(function(builder) {
					const pageSchemaUId = config.pageSchemaUId;
					const detailName = config.detailName;
					return builder
						.from(builder.buildPageSchemaItemGetterByKey("details_", {pageSchemaUId: pageSchemaUId}))
						.then(builder.filter([builder.buildNameFilter({name: detailName})]))
						.then(builder.select(builder.buildPageSchemaDetailValueSelector()))
						.then(builder.firstOrDefault());
				}, callback, scope);
			},

			getModuleLookupValue: function(config, callback, scope) {
				this._loadLookupValue(function(builder) {
					const pageSchemaUId = config.pageSchemaUId;
					const moduleName = config.moduleName;
					return builder
						.from(builder.buildPageSchemaItemGetterByKey("modules_", {pageSchemaUId: pageSchemaUId}))
						.then(builder.filter([builder.buildNameFilter({name: moduleName})]))
						.then(builder.select(builder.buildPageSchemaModuleValueSelector()))
						.then(builder.firstOrDefault());
				}, callback, scope);
			},

			getGroupLookupValue: function(config, callback, scope) {
				this._loadLookupValue(function(builder) {
					const pageSchemaUId = config.pageSchemaUId;
					const groupName = config.groupName;
					return builder
						.from(builder.buildPageSchemaItemGetterByKey("groups_", {pageSchemaUId: pageSchemaUId}))
						.then(builder.filter([builder.buildNameFilter({name: groupName})]))
						.then(builder.select(builder.buildPageSchemaGroupValueSelector()))
						.then(builder.firstOrDefault());
				}, callback, scope);
			},

			getTabLookupValue: function(config, callback, scope) {
				this._loadLookupValue(function(builder) {
					const pageSchemaUId = config.pageSchemaUId;
					const tabName = config.tabName;
					return builder
						.from(builder.buildPageSchemaItemGetterByKey("tabs_", {pageSchemaUId: pageSchemaUId}))
						.then(builder.filter([builder.buildNameFilter({name: tabName})]))
						.then(builder.select(builder.buildPageSchemaTabValueSelector()))
						.then(builder.firstOrDefault());
				}, callback, scope);
			},

			/**
			 * Returns system value caption.
			 * @protected
			 * @param {String} sysValue System value name.
			 * @return {String} System value caption.
			 */
			getSysValueCaption: function(sysValue) {
				return BPMSoft.Resources.SystemValueCaptions[sysValue];
			}

			//endregion

		});
	}
);
