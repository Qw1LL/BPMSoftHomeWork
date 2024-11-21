define("BaseParametersMappingPage", ["GridUtilitiesV2", "MappingEnums"],
		function() {
			return {
				mixins: {
					GridUtilities: "BPMSoft.GridUtilities"
				},
				attributes: {
					/**
					 * Config that contains filters parameters.
					 */
					"FilterConfig": {
						dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT
					},

					/**
					 * Parameters grid data.
					 */
					"ParametersGridData": {
						dataValueType: this.BPMSoft.DataValueType.COLLECTION
					},

					/**
					 * Flag that indicates whether process elements grid is hierarchical.
					 */
					IsElementsGridHierarchical: {
						dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
						value: false
					},

					/**
					 * Parameters grid active row.
					 */
					"ParametersGridActiveRow": {
						dataValueType: BPMSoft.DataValueType.GUID
					},

					/**
					 * Flag that indicates whether parameters grid is empty.
					 */
					"IsParametersGridEmpty": {
						dataValueType: BPMSoft.DataValueType.BOOLEAN
					},

					/**
					 * Flag that indicates whether process has any parameters.
					 */
					"HasParameters": {
						dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
						type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},

					/**
					 * Process schema instance.
					 */
					ProcessSchema: {
						dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT
					},

					/**
					 * Maximum parameter nesting level that allowed to specify mapping to. If defined as null parameter
					 * with any nesting level will be allowed to map to.
					 */
					"AllowedCollectionItemNestingLevel": {
						dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT,
						value: null
					}
				},
				messages: {
					/**
					 * Returns process schema.
					 * @message GetProcessSchema
					 */
					"GetProcessSchema": {
						direction: BPMSoft.MessageDirectionType.PUBLISH,
						mode: BPMSoft.MessageMode.PTP
					},

					/**
					 * Returns selected rows.
					 * @message ResultSelectedRows
					 */
					"ResultSelectedRows": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.PUBLISH
					},

					/**
					 * Returns active row.
					 * @message ResultSelectedRows
					 */
					"ResultActiveRow": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.PUBLISH
					},

					/**
					 * Returns selected process parameter.
					 * @message GetSelectedProcessParameter
					 */
					"GetSelectedProcessParameter": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},

					/**
					 * Returns the parameter mapping data.
					 * @message GetParameterMappingInfo
					 */
					"GetParameterMappingInfo": {
						direction: BPMSoft.MessageDirectionType.PUBLISH,
						mode: BPMSoft.MessageMode.PTP
					}
				},
				methods: {
					/**
					 * Returns selected row data.
					 * @protected
					 * @abstract
					 * @return {Object} Selected data.
					 * @return {String} return.caption Selected item caption.
					 * @return {String} return.value Path to parameter.
					 */
					getSelectedData: BPMSoft.emptyFn,

					/**
					 * Returns active row.
					 * @private
					 * @return {BPMSoft.BaseViewModel} Active row view model.
					 */
					getActiveRow: BPMSoft.emptyFn,

					/**
					 * Returns grid collection in callback function.
					 * @protected
					 * @abstract
					 * @param {Function} callback The callback function.
					 */
					getMainCollection: BPMSoft.emptyFn,

					/**
					 * Returns grid rows view model collection.
					 * @protected
					 * @abstract
					 * @param {Object} parameters Parameters.
					 * @return {Object} Grid rows view model collection.
					 */
					getMainRowCollection: BPMSoft.emptyFn,

					/**
					 * Initializes active rows.
					 * @protected
					 * @abstract
					 */
					initActiveRow: BPMSoft.emptyFn,

					/**
					 * Applies empty message config for parameters grid.
					 * @protected
					 * @abstract
					 * @param {Object} config Configuration object.
					 */
					applyEmptyParametersGridMessageConfig: BPMSoft.emptyFn,

					/**
					 * Loads grid collection.
					 * @protected
					 * @abstract
					 * @param {BPMSoft.Collection} collection Data collection.
					 */
					loadMainGridCollection: BPMSoft.emptyFn,

					/**
					 * Initializes process schema.
					 * @protected
					 */
					initProcessSchema: function() {
						var processSchema = this.sandbox.publish("GetProcessSchema");
						this.set("ProcessSchema", processSchema);
					},

					/**
					 * Filters collection from invoker of the mapping window.
					 * @protected
					 * @virtual
					 * @param {BPMSoft.Collection} collection Collection to filter
					 * @return {BPMSoft.Collection} Filtered collection
					 */
					excludeSelfFromMapping: function(collection) {
						var result = collection;
						var itemUIdToRemove = this.get("InvokerUId");
						if (collection && itemUIdToRemove) {
							result = collection.filterByFn(function(item) {
								return item.uId !== itemUIdToRemove;
							});
						}
						return result;
					},

					/**
					 * Filters collection by reference schema for lookup.
					 * @protected
					 * @virtual
					 * @param {BPMSoft.Collection} collection Collection  to filter.
					 * @return {BPMSoft.Collection} Filtered collection.
					 */
					getFilteredByReferenceSchemaUId: function(collection) {
						var referenceSchemaUId = this.get("referenceSchemaUId");
						return this.applyReferenceSchemaFilters(collection, referenceSchemaUId);
					},

					/**
					 * Filters collection by data type.
					 * @protected
					 * @param {BPMSoft.Collection} collection Collection to filter
					 * @param {Number} dataValueType value type.
					 * @return {BPMSoft.Collection} Filtered collection.
					 */
					getFilteredByDataValueTypeParameters: function(collection, dataValueType) {
						var result = collection;
						var validator = BPMSoft.findDataValueTypeValidator(dataValueType);
						if (collection && validator) {
							result = collection.filterByFn(function(item) {
								return validator(item.dataValueType);
							});
						}
						return result;
					},

					/**
					 * Applies filters to collection according to filter flags.
					 * @param {BPMSoft.Collection} collection Collection to filter
					 * @param {Boolean} isLookup Is parameter a lookup.
					 * @param {Number} dataValueType Parameter value type.
					 * @returns {BPMSoft.Collection} Filtered collection.
					 */
					applyFilters: function(collection, isLookup, dataValueType) {
						var shouldBeCompiled = BPMSoft.isInstanceOfClass(this.$ProcessSchema,
							"BPMSoft.ProcessSchema") && this.$ProcessSchema.shouldBeCompiled();
						if (shouldBeCompiled &&	(BPMSoft.isDebug ||
								BPMSoft.Features.getIsEnabled("NoCompilationFeature"))) {
							collection = collection.filterByFn(function(parameter) {
								return !BPMSoft.isEnumerableDataValueType(parameter.dataValueType);
							});
						}
						if (this.useGridItemsFilter()) {
							return collection;
						}
						dataValueType = dataValueType || this.get("DataValueType");
						isLookup = isLookup || BPMSoft.isLookupDataValueType(dataValueType);
						var filterConfig = this.get("FilterConfig");
						if (filterConfig) {
							collection = this.applyFilterConfig(collection, filterConfig);
						} else {
							collection = this.getFilteredByDataValueTypeParameters(collection, dataValueType);
							if (isLookup) {
								collection = this.getFilteredByReferenceSchemaUId(collection);
							}
						}
						return collection;
					},

					/**
					 * @protected
					 */
					useGridItemsFilter: function() {
						return BPMSoft.Features.getIsEnabled("ProcessParameterCollections") || BPMSoft.isDebug;
					},

					/**
					 * Applies data value type filters array to collection.
					 * @private
					 * @param {BPMSoft.Collection} collection Collection to filter
					 * @param {Array} filterArray Data value type filters array.
					 * @returns {BPMSoft.Collection} Filtered collection.
					 */
					applyDataValueTypeFilters: function(collection, filterArray) {
						if (collection) {
							collection = collection.filterByFn(function(item) {
								return BPMSoft.contains(filterArray, item.dataValueType);
							}, this);
						}
						return collection;
					},

					/**
					 * Applies reference schema uid filter to collection.
					 * @private
					 * @param {BPMSoft.Collection} collection Collection to filter
					 * @param {String} referenceSchemaUId Reference schema uid to filter.
					 * @returns {BPMSoft.Collection} Filtered collection.
					 */
					applyReferenceSchemaFilters: function(collection, referenceSchemaUId) {
						if (collection) {
							collection = collection.filterByFn(function(item) {
								if (item.dataValueType === BPMSoft.DataValueType.GUID) {
									return true;
								}
								var itemReferenceSchemaUId = item.referenceSchemaUId ||
									item.sourceValue.referenceSchemaUId;
								return itemReferenceSchemaUId === referenceSchemaUId;
							}, this);
						}
						return collection;
					},

					/**
					 * Applies filters from filter config to collection.
					 * @private
					 * @param {BPMSoft.Collection} collection Collection to filter
					 * @param {Object} filterConfig Filter object.
					 * @returns {BPMSoft.Collection} Filtered collection.
					 */
					applyFilterConfig: function(collection, filterConfig) {
						var referenceSchemaUId = filterConfig.filterSchemaUId;
						var allowedDataValueTypes = filterConfig.allowedDataValueTypes;
						if (!Ext.isEmpty(allowedDataValueTypes)) {
							collection = this.applyDataValueTypeFilters(collection, allowedDataValueTypes);
						}
						if (!Ext.isEmpty(referenceSchemaUId)) {
							collection = this.applyReferenceSchemaFilters(collection, referenceSchemaUId);
						}
						return collection;
					},


					/**
					 * @private
					 */
					_getReferenceSchemaValidator: function() {
						var filterConfig = this.get("FilterConfig");
						var isLookup = BPMSoft.isLookupDataValueType(this.get("DataValueType"));
						var referenceSchemaUId = filterConfig
							? filterConfig.filterSchemaUId
							: (isLookup ? this.get("referenceSchemaUId") : null);
						return function(item) {
							var result = true;
							if (BPMSoft.isLookupDataValueType(item.dataValueType) && referenceSchemaUId) {
								var itemReferenceSchemaUId = item.referenceSchemaUId ||
									item.sourceValue.referenceSchemaUId;
								result = itemReferenceSchemaUId === referenceSchemaUId;
							}
							return result;
						};
					},

					/**
					 * @private
					 */
					_getDataValueTypeValidator: function() {
						var validator;
						var filterConfig = this.get("FilterConfig");
						if (filterConfig) {
							validator = function(item) {
								return BPMSoft.contains(filterConfig.allowedDataValueTypes, item.dataValueType);
							};
						} else {
							validator = function(item) {
								var dataTypeValidator = BPMSoft.findDataValueTypeValidator(this.get("DataValueType"));
								return dataTypeValidator ? dataTypeValidator(item.dataValueType) : true;
							};
						}
						return validator;
					},

					/**
					 * @private
					 */
					_validateParentParameter: function(parameter) {
						let result = true;
						const dataValueType = this.get("DataValueType");
						if (!BPMSoft.isEnumerableDataValueType(dataValueType)) {
							result = this.$HasParent || !BPMSoft.isEmpty(this.$AllowedCollectionItemNestingLevel)
								? this._validateNestedParameters(parameter.itemProperties)
								: false;
						}
						return result;
					},

					/**
					 * @private
					 */
					_validateNestedParameters: function(collection) {
						const filteredNestedParameters = collection.filterByFn(function(item) {
							if (!this._validateParameterNestingLevel(item)) {
								return false;
							}
							return item.hasNestedParameters()
								? this._validateNestedParameters(item.itemProperties)
								: this._validateParameter(item);
						}, this);
						return !filteredNestedParameters.isEmpty();
					},

					/**
					 * @private
					 */
					_validateParameterNestingLevel: function(parameter) {
						const nestingLevelSpecified = !BPMSoft.isEmpty(this.$AllowedCollectionItemNestingLevel);
						return !nestingLevelSpecified || parameter.getNestingLevel() <=
							this.$AllowedCollectionItemNestingLevel;
					},

					/**
					 * @private
					 */
					_validateParameter: function(parameter) {
						var validators = this.getParameterValidators();
						var isValid = true;
						validators.each(function(validator) {
							if (isValid && validator) {
								isValid = validator.call(this, parameter);
							}
						}, this);
						return isValid;
					},

					/**
					 * @private
					 */
					_isProcessSchemaParameter: function(parameter) {
						return BPMSoft.instanceOfClass(parameter, "BPMSoft.ProcessSchemaParameter");
					},

					/**
					 * Initializes subscriber for the GetSelectedProcessParameter message.
					 * @protected
					 * @virtual
					 */
					initGetSelectedParameterSubscription: function() {
						var sandbox = this.sandbox;
						sandbox.subscribe("GetSelectedProcessParameter", this.getSelectedData, this, [sandbox.id]);
					},

					/**
					 * Active row change handler.
					 * @protected
					 * @virtual
					 */
					onChangeActiveRow: function() {
						var selectedRows = this.getSelectedRows();
						this.sandbox.publish("ResultActiveRow", selectedRows, [this.sandbox.id]);
					},

					/**
					 * Initializes grid data.
					 * @protected
					 * @virtual
					 */
					initGridData: function() {
						this.set("ParametersGridData", this.Ext.create("BPMSoft.BaseViewModelCollection"));
					},

					/**
					 * Returns image Url.
					 * @private
					 * @param {String} imageName Image name.
					 * @return {String} Image URL.
					 */
					getImageUrl: function(imageName) {
						return BPMSoft.ImageUrlBuilder.getUrl({
							source: BPMSoft.ImageSources.RESOURCE_MANAGER,
							params: {
								resourceManagerName: "BPMSoft.Nui",
								resourceItemName: "ProcessSchemaDesigner." + imageName
							}
						});
					},

					/**
					 * Returns selected rows data.
					 * @private
					 * @return {Object}
					 */
					getSelectedRows: function() {
						var selectedData = this.getSelectedData();
						var result = new BPMSoft.Collection();
						if (selectedData) {
							result.add(selectedData.Id, selectedData);
						}
						return {
							selectedRows: result
						};
					},

					/**
					 * Grid double click handler.
					 * @protected
					 */
					onGridDoubleClick: function() {
						var selectedRows = this.getSelectedRows();
						this.sandbox.publish("ResultSelectedRows", selectedRows, [this.sandbox.id]);
					},

					/**
					 * Applies empty grid message config.
					 * @protected
					 * @param {Object} config Configuration object.
					 * @param {String} title Empty message label text.
					 * @param {Array} wrapClasses Empty message label wrap classes.
					 */
					applyEmptyGridMessageConfig: function(config, title, wrapClasses) {
						var emptyGridMessageProperties = {
							title: title,
							wrapClasses: wrapClasses
						};
						var emptyGridMessageViewConfig = this.getEmptyGridMessageViewConfig(emptyGridMessageProperties);
						this.Ext.apply(config, emptyGridMessageViewConfig);
					},

					/**
					 * Returns view config for empty grid message.
					 * @protected
					 * @param {Object} messageProperties Message properties.
					 * @param {String} messageProperties.title Message.
					 * @param {Array} messageProperties.wrapClasses Wrap classes array.
					 * @return {Object}.
					 */
					getEmptyGridMessageViewConfig: function(messageProperties) {
						var config = {
							className: "BPMSoft.Container",
							classes: {
								wrapClassName: messageProperties.wrapClasses
							},
							items: []
						};
						config.items.push({
							className: "BPMSoft.Container",
							classes: {
								wrapClassName: ["title"]
							},
							items: [
								{
									className: "BPMSoft.Label",
									caption: messageProperties.title
								}
							]
						});
						return config;
					},

					/**
					 * Returns sorted by caption parameters collection.
					 * @protected
					 * @param {BPMSoft.Collection} collection Source collection.
					 * @return {BPMSoft.BaseViewModelCollection} Sorted collection.
					 */
					sortParametersByCaption: function(collection) {
						var sortedCollection = this.Ext.create("BPMSoft.BaseViewModelCollection", {
							getKey: function(item) {
								return item.get("Id");
							}
						});
						var sortColumn = "Caption";
						sortedCollection.loadAll(collection);
						sortedCollection.sortByFn(function(item1, item2) {
							var item1Caption = item1.get(sortColumn);
							var item2Caption = item2.get(sortColumn);
							return item1Caption.localeCompare(item2Caption);
						});
						return sortedCollection;
					},

					/**
					 * Returns collection of validators.
					 * @protected
					 * @virtual
					 * @return {BPMSoft.Collection}
					 */
					getParameterValidators: function() {
						var dataValueTypeValidator = this._getDataValueTypeValidator();
						var referenceSchemaValidator = this._getReferenceSchemaValidator();
						var validators = new BPMSoft.Collection();
						validators.add(dataValueTypeValidator);
						validators.add(referenceSchemaValidator);
						return validators;
					},

					/**
					 * Returns filtered grid items collection.
					 * @protected
					 * @param {BPMSoft.Collection} collection Source collection.
					 */
					getFilteredGridItems: function(collection) {
						var filteredCollection = this.Ext.create("BPMSoft.BaseViewModelCollection", {
							getKey: function(item) {
								return item.get("Id");
							}
						});
						filteredCollection.loadAll(collection);
						filteredCollection = filteredCollection.filterByFn(function(item) {
							var parameter = item.get("Parameter");
							return this._isProcessSchemaParameter(parameter) && parameter.hasNestedParameters()
								? this._validateParentParameter(parameter)
								: this._validateParameter(parameter);
						}, this);
						return filteredCollection;
					}
				}
			};
		});
