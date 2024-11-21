/**
 * Parent: BaseParametersMappingPage
 */
define("ProcessElementParametersMappingPage", ["ProcessElementParametersMappingPageResources",
			"ProcessSchemaUserTaskUtilities", "SearchEdit", "css!ProcessElementParametersMappingPageCSS"],
		function(resources, ProcessSchemaUserTaskUtilities) {

			/**
			 * Configuration of the process element schema.
			 */
			const flowElementColumnsConfig = {
				Name: {
					dataValueType: this.BPMSoft.DataValueType.TEXT,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				Id: {
					dataValueType: this.BPMSoft.DataValueType.GUID,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				Caption: {
					dataValueType: this.BPMSoft.DataValueType.TEXT,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				Icon: {
					dataValueType: this.BPMSoft.DataValueType.TEXT,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			};

			/**
			 * Schema configuration of process element parameter.
			 */
			const flowElementParameterColumnsConfig = {
				Id: {
					dataValueType: this.BPMSoft.DataValueType.GUID,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				ParentUId: {
					dataValueType: this.BPMSoft.DataValueType.GUID,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				Caption: {
					dataValueType: this.BPMSoft.DataValueType.TEXT,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				Icon: {
					dataValueType: this.BPMSoft.DataValueType.TEXT,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				Value: {
					dataValueType: this.BPMSoft.DataValueType.TEXT,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				ExtendedProperties: {
					dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			};
			return {
				attributes: {
					/**
					 * Process elements grid data.
					 */
					ElementsGridData: {
						dataValueType: this.BPMSoft.DataValueType.COLLECTION
					},

					/**
					 * Process elements grid row.
					 */
					ElementsGridActiveRow: {
						dataValueType: this.BPMSoft.DataValueType.TEXT,
						onChange: "_onElementsGridActiveRowChanged"
					},

					/**
					 * Elements grid search text.
					 * @type {BPMSoft.dataValueType.TEXT}
					 */
					ElementsGridSearchText: {
						dataValueType: this.BPMSoft.DataValueType.TEXT,
						type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},

					/**
					 * Element Parameters grid search text.
					 * @type {BPMSoft.dataValueType.TEXT}
					 */
					ParametersGridSearchText: {
						dataValueType: this.BPMSoft.DataValueType.TEXT,
						type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},

					/**
					 * Flag that indicates whether process elements grid is empty.
					 */
					IsElementsGridEmpty: {
						dataValueType: this.BPMSoft.DataValueType.BOOLEAN
					},

					/**
					 * Element parameters search field marker value.
					 */
					"ParametersSearchMarkerValue": {
						dataValueType: this.BPMSoft.DataValueType.TEXT,
						type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						value: "ElementParametersSearchEdit"
					},

					/**
					 * Process elements search field marker value.
					 */
					"ElementsSearchMarkerValue": {
						dataValueType: this.BPMSoft.DataValueType.TEXT,
						type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						value: "ElementsSearchEdit"
					},

					/**
					 * Name of primary column in Elements Grid
					 */
					"ElementsPrimaryColumnName": {
						dataValueType: this.BPMSoft.DataValueType.TEXT,
						type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						value: "Name"
					},

					/**
					 * Expanded nodes.
					 */
					"ExpandedParameters": {
						dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT,
						type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						onChange: "_onExpandedParametersChanged",
						value: []
					}
				},

				/**
				 * Entity schema name.
				 * @private
				 * @type {String}
				 */
				entitySchemaName: null,

				messages: {
					/**
					 * @message GetParametersInfo
					 * Gets parameter info.
					 */
					"GetParametersInfo": {
						direction: BPMSoft.MessageDirectionType.PUBLISH,
						mode: BPMSoft.MessageMode.PTP
					}
				},
				properties: {
					/**
					 * @private
					 */
					_expandedParametersStoreKey: "_ProcessElementParametersMappingPage_ExpandedParameters",

					/**
					 * @private
					 */
					_filteredExpandedParameters: []
				},
				methods: {

					/**
					 * @private
					 */
					_onElementsGridActiveRowChanged: function() {
						this._initExpandedParameters();
					},

					/**
					 * @private
					 */
					_getExpandedParametersStoreKey: function() {
						return this.$ElementsGridActiveRow + this._expandedParametersStoreKey;
					},

					/**
					 * @private
					 */
					_onExpandedParametersChanged: function () {
						const itemsToStore = [];
						[].push.apply(itemsToStore, this._filteredExpandedParameters);
						[].push.apply(itemsToStore, this.$ExpandedParameters);
						BPMSoft.ClientPageSessionCache.setItem(this._getExpandedParametersStoreKey(),
							JSON.stringify(itemsToStore));
					},

					/**
					 * @private
					 */
					_getParentParameters: function() {
						let parents = this.$ParametersGridData.getItems().map(function(i) {
							return i.$ParentUId;
						});
						parents = _.compact(parents);
						return _.uniq(parents);
					},

					/**
					 * @private
					 */
					_initExpandedParameters: function() {
						const parents = this._getParentParameters();
						const stored = BPMSoft.ClientPageSessionCache.getItem(this._getExpandedParametersStoreKey());
						const storedNodes = stored ? JSON.parse(stored) : [];
						this.$ExpandedParameters = stored ? _.intersection(parents, storedNodes) : parents;
						this._filteredExpandedParameters = _.difference(storedNodes, parents);
					},

					/**
					 * @inheritdoc BPMSoft.BaseSchemaViewModel#onRender
					 * @overridden
					 */
					onRender: function() {
						this.callParent(arguments);
						this._initExpandedParameters();
					},

					/**
					 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
					 * @overridden
					 */
					init: function(callback) {
						this.initProcessSchema();
						this.initGridData();
						this.callParent([function() {
							this.initGridRowViewModel(function() {
								this.getMainCollection(function(collection) {
									this.loadMainGridCollection(collection);
									this.initActiveRow();
									this.initGetSelectedParameterSubscription();
									callback.call(this);
								});
							}, this);
						}, this]);
					},

					/**
					 * @inheritdoc BPMSoft.BaseParametersMappingPage#initGridData
					 * @overridden
					 */
					initGridData: function() {
						this.set("ElementsGridData", this.Ext.create("BPMSoft.BaseViewModelCollection"));
						this.callParent(arguments);
					},

					/**
					 * @inheritdoc BPMSoft.BaseParametersMappingPage#getMainCollection
					 * @overridden
					 */
					getMainCollection: function(callback) {
						const processSchema = this.get("ProcessSchema");
						const flowElements = processSchema.flowElements;
						const filteredElements = this.excludeSelfFromMapping(flowElements);
						callback.call(this, filteredElements);
					},

					/**
					 * @inheritdoc BPMSoft.BaseParametersMappingPage#loadMainGridCollection
					 * @overridden
					 */
					loadMainGridCollection: function(dataCollection) {
						const collection = this.getElementsGridData();
						const isGridEmpty = this.BPMSoft.isEmptyObject(dataCollection);
						this.set("IsElementsGridEmpty", isGridEmpty);
						collection.clear();
						const gridRowCollection = this.getMainRowCollection(dataCollection);
						collection.loadAll(gridRowCollection);
					},

					/**
					 * Filters process elements by entered search text.
					 * @private
					 */
					filterElementsCollection: function() {
						const searchText = this.getElementsGridSearchText();
						this.loadMainCollection();
						if (this.Ext.isEmpty(searchText)) {
							return;
						}
						const collection = this.getElementsGridData();
						this.reloadFilteredElements(collection, searchText);
						if (collection.isEmpty()) {
							this.set("IsElementsGridEmpty", true);
						} else {
							this.setFirstCollectionRowActive(collection);
						}
					},

					/**
					 * Sets first row of collection as active.
					 * @private
					 * @param {BPMSoft.Collection} collection Grid items collection.
					 */
					setFirstCollectionRowActive: function(collection) {
						var firstItem = collection.getByIndex(0);
						var flowElementName = firstItem.get("Name");
						this.set("ElementsGridActiveRow", flowElementName);
					},

					/**
					 * @inheritdoc BPMSoft.BaseParametersMappingPage#loadMainCollection
					 * @overridden
					 */
					loadMainCollection: function() {
						this.getMainCollection(function(collection) {
							this.loadMainGridCollection(collection);
						}, this);
					},

					/**
					 * Loads list of element parameters.
					 * @private
					 */
					loadElementParametersCollection: function() {
						var elementRow = this.getElementsGridActiveRow();
						this.loadActiveRowParametersCollection(elementRow);
					},

					/**
					 * Clears element parameters search text value and reload parameters collection.
					 * @private
					 */
					onParametersSearchValueDeleted: function() {
						this.set("ParametersGridSearchText", "");
						this.loadElementParametersCollection();
					},

					/**
					 * Loads parameters of currently selected process element.
					 * @private
					 * @param {BPMSoft.BaseViewModel} elementRow Active grid row view model.
					 */
					loadActiveRowParametersCollection: function(elementRow) {
						var flowElementName = elementRow.get("Name");
						this.getParametersGridRowCollection(flowElementName, function(collection) {
							this.loadParametersGrid(collection);
						}, this);
					},

					/**
					 * Checks if filtered collection contains currently selected row.
					 * @private
					 * @param {BPMSoft.Collection} collection Filtered collection.
					 */
					checkActiveRowVisible: function(collection) {
						var row = this.get("ParametersGridActiveRow");
						if (row === null) {
							return;
						}
						if (!collection.contains(row)) {
							this.clearSelectedParametersRows();
						}
					},

					/**
					 * Clears selected rows is both grids.
					 * @private
					 */
					clearSelectedParametersRows: function() {
						this.set("ParametersGridActiveRow", "");
					},

					/**
					 * Gets ElementParametersGridSearchText column value.
					 * @private
					 * @return {String} Element parameters search field value.
					 */
					getParametersGridSearchText: function() {
						return this.get("ParametersGridSearchText") || "";
					},

					/**
					 * Gets ElementsGridSearchText column value.
					 * @private
					 * @return {String} Element parameters search field value.
					 */
					getElementsGridSearchText: function() {
						return this.get("ElementsGridSearchText") || "";
					},

					/**
					 * Reloads collection with filtered parameters.
					 * @private
					 * @param {BPMSoft.Collection} collection Collection to filter.
					 * @param {String} searchText Value to filter by collection items.
					 */
					reloadFilteredParameters: function(collection, searchText) {
						var filteredCollection = this.useGridItemsFilter()
							? this.getFilteredGridItems(collection)
							: this.filterGridItemsByCaption(collection, searchText);
						collection.reloadAll(filteredCollection);
					},

					/**
					 * Reloads collection with filtered elements.
					 * @private
					 * @param {BPMSoft.Collection} collection Collection to filter.
					 * @param {String} searchText Value to filter by collection items.
					 */
					reloadFilteredElements: function(collection, searchText) {
						var filteredCollection = this.filterGridItemsByCaption(collection, searchText);
						collection.reloadAll(filteredCollection);
					},

					/**
					 * Filters grid items by caption.
					 * @private
					 * @param {Object} items Items to filter.
					 * @param {String} searchText Value to filter by collection items.
					 */
					filterGridItemsByCaption: function(items, searchText) {
						var filterValue = searchText.toLowerCase();
						var filteredCollection;
						if (items instanceof this.BPMSoft.Collection) {
							filteredCollection = this.filterCollectionByCaption(items, filterValue);
						} else {
							filteredCollection = this.filterItemsByCaption(items, filterValue);
						}
						return filteredCollection;
					},

					/**
					 * Filters collection for items where caption contains search value.
					 * @private
					 * @param {BPMSoft.Collection} collection Collection to filter.
					 * @param searchValue Search field text.
					 * @return {BPMSoft.Collection} Filtered collection.
					 */
					filterCollectionByCaption: function(collection, searchValue) {
						return collection.filterByFn(function(item) {
							var lowerCaseCaption = this.getLowerCaseItemCaption(item);
							if (lowerCaseCaption.indexOf(searchValue) !== -1) {
								return true;
							}
						}, this);
					},

					/**
					 * Filters objects key value pairs for items where caption contains search value.
					 * @private
					 * @param {Object} items Object to filter.
					 * @param {String} searchValue Search field text.
					 * @return {BPMSoft.Collection} Filtered collection.
					 */
					filterItemsByCaption: function(items, searchValue) {
						var newCollection = this.Ext.create("BPMSoft.Collection");
						BPMSoft.each(items, function(item, key) {
							var lowerCaseCaption = this.getLowerCaseItemCaption(item);
							if (lowerCaseCaption.indexOf(searchValue) !== -1) {
								newCollection.add(key, item);
							}
						}, this);
						return newCollection;
					},

					/**
					 * Filters element parameters by entered search text.
					 * @private
					 */
					filterParametersCollection: function() {
						var searchText = this.getParametersGridSearchText();
						this.loadElementParametersCollection();
						if (this.Ext.isEmpty(searchText)) {
							return;
						}
						var collection = this.getParametersGridData();
						this.reloadFilteredParameters(collection, searchText);
						var isGridEmpty = collection.isEmpty();
						this.set("IsParametersGridEmpty", isGridEmpty);
						this.checkActiveRowVisible(collection);
					},

					/**
					 * Returns lowercase item caption.
					 * @private
					 * @param {Object} item Grid item.
					 * @return {String}
					 */
					_getLowerCaseItemCaption: function(item) {
						var itemCaption = item.caption.toString();
						return itemCaption.toLowerCase();
					},

					/**
					 * @private
					 */
					_searchTextValidator: function(item) {
						var searchValue = this.getParametersGridSearchText();
						var lowerCaseCaption = this._getLowerCaseItemCaption(item);
						if (lowerCaseCaption.indexOf(searchValue.toLowerCase()) !== -1) {
							return true;
						}
					},

					/**
					 * @private
					 */
					_directionValidator: function(item) {
						return item.direction !== BPMSoft.ProcessSchemaParameterDirection.IN;
					},

					/**
					 * @private
					 */
					_nestedMappingValidator: function(parameter) {
						var isValid = true;
						if (BPMSoft.instanceOfClass(parameter, "BPMSoft.ProcessSchemaParameter")) {
							var parent = parameter.getParent();
							var hierarchicalParentUIds = parameter.getHierarchicalParentsUIds();
							var mappingParentHierarchicalUIds = Ext.clone(this.get("MappingParentHierarchicalUIds"));
							if (parent && !Ext.isEmpty(mappingParentHierarchicalUIds)) {
								var parentMappingParameter = mappingParentHierarchicalUIds.shift();
								isValid = Ext.Array.contains(hierarchicalParentUIds, parentMappingParameter) ||
									Ext.Array.contains(mappingParentHierarchicalUIds, parent.uId);
							}
						}
						return isValid;
					},

					/**
					 * @private
					 */
					_isValidCollectionMapping: function(parameterRow) {
						if (parameterRow.$Parameter) {
							return BPMSoft.isEnumerableDataValueType(this.$DataValueType) ===
								BPMSoft.isEnumerableDataValueType(parameterRow.$Parameter.dataValueType);
						}
						return true;
					},

					/**
					 * Returns lowercase item caption.
					 * @private
					 * @param {Object} item Grid item.
					 * @return {String}
					 */
					getLowerCaseItemCaption: function(item) {
						var itemCaption = item.get("Caption");
						return itemCaption.toLowerCase();
					},

					/**
					 * Loads element parameters collection to grid.
					 * @private
					 * @param {BPMSoft.Collection} gridRowCollection List of parameters.
					 */
					loadParametersGrid: function(gridRowCollection) {
						var isGridEmpty = this.BPMSoft.isEmptyObject(gridRowCollection);
						this.set("IsParametersGridEmpty", isGridEmpty);
						var collection = this.getParametersGridData();
						collection.clear();
						var searchText = this.getParametersGridSearchText();
						if (!this.Ext.isEmpty(searchText) && !this.useGridItemsFilter()) {
							gridRowCollection = this.filterGridItemsByCaption(gridRowCollection, searchText);
						}
						var filteredCollection = this.useGridItemsFilter()
							? this.getFilteredGridItems(gridRowCollection)
							: gridRowCollection;
						var sortedCollection = this.sortParametersByCaption(filteredCollection);
						collection.loadAll(sortedCollection);
						this.set("IsParametersGridEmpty", collection.isEmpty());
					},

					/**
					 * @inheritdoc BPMSoft.BaseParametersMappingPage#getMainRowCollection
					 * @overridden
					 */
					getMainRowCollection: function(flowElements) {
						const collection = {};
						const gridRowViewModelName = this.getGridRowViewModelClassName();
						this.BPMSoft.each(flowElements.getItems(), function(flowElement) {
							if (!flowElement.parameters || flowElement.parameters.getCount() === 0) {
								return true;
							}
							const utils = this.BPMSoft.ProcessSchemaDesignerUtilities;
							const flowElementDisplayValue = utils.getElementCaption(flowElement);
							const item = this.Ext.create(gridRowViewModelName, {
								rowConfig: flowElementColumnsConfig,
								values: {
									Name: flowElement.name,
									Id: flowElement.uId,
									Caption: flowElementDisplayValue,
									Icon: this.BPMSoft.ImageUrlBuilder.getUrl(flowElement.getSmallImage())
								}
							});
							this.addItemToFlowElementsGridRowCollection(collection, flowElement, item);
						}, this);
						if (this.BPMSoft.isEmptyObject(collection)) {
							this.set("IsElementsGridEmpty", true);
						}
						return collection;
					},

					/**
					 * Adds item to flow element collection.
					 * @private
					 * @param {Object} collection Flow elements collection.
					 * @param {BPMSoft.ProcessFlowElementSchema} flowElement Flow element.
					 * @param {BPMSoft.BaseGridRowViewModel} item Grid row view model.
					 */
					addItemToFlowElementsGridRowCollection: function(collection, flowElement, item) {
						collection[flowElement.name] = item;
					},

					/**
					 * Fills out the grid of parameters by result parameters.
					 * @protected
					 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
					 * @param {Object} resultParametersInfo Data of result parameters.
					 * @param {Function} callback Callback function.
					 * @param {Object} scope Callback scope.
					 */
					fillGridRowsByResultInfo: function(element, resultParametersInfo, callback, scope) {
						const resultParameter = resultParametersInfo.resultParameter;
						this.$IsElementsGridHierarchical = false;
						if (!resultParameter || resultParameter.dataValueType !== this.BPMSoft.DataValueType.ENTITY) {
							const collection = this.getGridRowsWithParameters(resultParametersInfo.resultParameters);
							callback.call(scope, collection);
							return;
						}
						const utilities = this.BPMSoft.ProcessSchemaDesignerUtilities;
						const config = {
							collection: {},
							packageUId: element.getPackageUId(),
							parameterUId: resultParameter.uId,
							parameterCaption: utilities.getElementCaption(resultParameter),
							entitySchemaUId: resultParameter.referenceSchemaUId,
							entitySchemaColumnUIds: resultParametersInfo.entitySchemaColumnUIds,
							callback: callback,
							scope: scope
						};
						this.fillGridRowsWithEntitySchemaColumns(config);
					},

					/**
					 * @inheritdoc BPMSoft.BaseParametersMappingPage#getParameterValidators
					 * @overridden
					 */
					getParameterValidators: function() {
						const validators = this.callParent(arguments);
						const searchValue = this.getParametersGridSearchText();
						if (searchValue) {
							validators.add(this._searchTextValidator);
						}
						validators.add(this._directionValidator);
						validators.add(this._nestedMappingValidator);
						return validators;
					},

					/**
					 * Gets collection of grid row view models for the selected process element parameters.
					 * @protected
					 * @param {String} flowElementKey Key of the selected process element.
					 * @param {Function} callback Callback function.
					 * @param {Object} scope Callback scope.
					 */
					getParametersGridRowCollection: function(flowElementKey, callback, scope) {
						const processSchema = this.get("ProcessSchema");
						const flowElement = processSchema.findItemByName(flowElementKey);
						ProcessSchemaUserTaskUtilities.getResultParametersInfo(flowElement, function(resultInfo) {
							let parameters = this.getCollectionFromArray(resultInfo.resultParameters);
							this.set("HasParameters", !parameters.isEmpty());
							parameters = this.applyFilters(parameters);
							resultInfo.resultParameters = this.getFilteredByExistingReferenceSchema(parameters);
							this.fillGridRowsByResultInfo(flowElement, resultInfo, callback, scope);
						}, this);
					},

					/**
					 * Filters collection for lookup items where entity schema does'not exist.
					 * @param {BPMSoft.Collection} collection Filtered collection.
					 * @returns {BPMSoft.Collection}
					 */
					getFilteredByExistingReferenceSchema: function(collection) {
						return collection.filterByFn(function(item) {
							if (item.dataValueType !== BPMSoft.DataValueType.LOOKUP) {
								return true;
							}
							return item.referenceSchemaUId || !item.referenceSchemaName;
						});
					},

					/**
					 * Creates collection from array.
					 * @param {Array} array Array.
					 * @return {BPMSoft.Collection}
					 */
					getCollectionFromArray: function(array) {
						const collection = Ext.create("BPMSoft.Collection");
						BPMSoft.each(array, function(item) {
							collection.add(item);
						});
						return collection;
					},

					/**
					 * Returns grid row view model of the parameter.
					 * @protected
					 * @param {Object} config Configuration object.
					 * @param {GUID} config.uId Element identifier.
					 * @param {String} config.caption Element caption.
					 * @param {BPMSoft.DataValueType} config.dataValueType Data value type of the parameter.
					 * @param {Object} config.extendedProperties Another element properties.
					 */
					getParameterGridRowViewModel: function(config) {
						const gridRowViewModelName = this.getGridRowViewModelClassName();
						const imageUrl =
							BPMSoft.ProcessSchemaDesignerUtilities.getDataValueTypeImageUrl(config.dataValueType);
						return this.Ext.create(gridRowViewModelName, {
							rowConfig: flowElementParameterColumnsConfig,
							values: {
								Id: config.uId,
								ParentUId: config.parentUId,
								Caption: config.caption,
								Parameter: config.parameter,
								Icon: imageUrl,
								ExtendedProperties: config.extendedProperties
							}
						});
					},

					/**
					 * Gets the grid of parameter.
					 * @protected
					 * @param {BPMSoft.Collection} parameters Parameters of the element.
					 * @return {Object} Grid rows list.
					 */
					getGridRowsWithParameters: function(parameters) {
						let collection = {};
						BPMSoft.each(parameters.getItems(), function(parameter) {
							const caption = this.BPMSoft.ProcessSchemaDesignerUtilities.getElementCaption(parameter);
							const parentParameter = parameter.getParent();
							collection[parameter.uId] = this.getParameterGridRowViewModel({
								uId: parameter.uId,
								caption: caption,
								parentUId: parentParameter && parentParameter.uId,
								parameter: parameter,
								dataValueType: parameter.dataValueType,
								extendedProperties: {
									isEntitySchemaColumn: false
								}
							});
							if ((this.getIsFeatureEnabled("ProcessParameterCollections") || BPMSoft.isDebug) &&
								parameter.itemProperties && !parameter.itemProperties.isEmpty()) {
								this.$IsElementsGridHierarchical = true;
								collection = Ext.merge(collection,
									this.getGridRowsWithParameters(parameter.itemProperties));
							}
						}, this);
						return collection;
					},

					/**
					 * Fills out the grid of parameters by entity schema columns.
					 * @protected
					 * @param {Object} config Configuration object.
					 * @param {GUID} config.packageUId UId of the package.
					 * @param {GUID} config.entitySchemaUId UId of the entity schema.
					 * @param {String} config.entitySchemaColumnUIds Identifiers of columns.
					 * @param {GUID} config.parameterUId UId of the parameter.
					 * @param {String} config.parameterCaption Parameter caption.
					 * @param {Object} config.collection List of rows.
					 * @param {Function} config.callback Callback function.
					 * @param {String} config.scope Callback scope.
					 */
					fillGridRowsWithEntitySchemaColumns: function(config) {
						const entitySchemaUId = config.entitySchemaUId;
						if (!entitySchemaUId) {
							config.callback.call(config.scope);
							return;
						}
						const schemaConfig = {
							schemaUId: entitySchemaUId,
							packageUId: config.packageUId
						};
						BPMSoft.EntitySchemaManager.findBundleSchemaInstance(schemaConfig, function(entitySchema) {
							if (entitySchema) {
								this.fillParametersGridRowsCollection(entitySchema.columns,
									config);
								config.callback.call(config.scope, config.collection);
							} else {
								config.callback.call(config.scope);
							}
						}, this);
					},

					/**
					 * Fills parameters grid rows collection.
					 * @private
					 * @param {BPMSoft.ObjectCollection} columns Entity schema columns.
					 * @param {BPMSoft.Collection} columns Entity schema columns collection.
					 * @param {Object} config Grid data.
					 */
					fillParametersGridRowsCollection: function(columns, config) {
						this.set("HasParameters", columns.isEmpty());
						const dataValueType = this.get("DataValueType");
						const isLookup = BPMSoft.isLookupDataValueType(dataValueType);
						const filteredParameters = this.applyFilters(columns, isLookup, dataValueType);
						filteredParameters.each(function(column) {
							if (config.entitySchemaColumnUIds &&
									!this.Ext.Array.contains(config.entitySchemaColumnUIds, column.uId)) {
								return true;
							}
							const caption = BPMSoft.ProcessSchemaDesignerUtilities.getElementCaption(column);
							config.collection[column.uId] = this.getParameterGridRowViewModel({
								uId: column.uId,
								caption: caption,
								dataValueType: column.dataValueType,
								parameter: column,
								extendedProperties: {
									parameterUId: config.parameterUId,
									parameterCaption: config.parameterCaption,
									isEntitySchemaColumn: true
								}
							});
						}, this);
					},

					/**
					 * @inheritdoc BPMSoft.BaseParametersMappingPage#getActiveRow
					 * @overridden
					 */
					getActiveRow: function(gridName) {
						let activeRow;
						const primaryColumnValue = this.get(gridName + "ActiveRow");
						if (primaryColumnValue) {
							const gridData = this.getGridData(gridName);
							activeRow = gridData.find(primaryColumnValue) ? gridData.get(primaryColumnValue) : null;
						}
						return activeRow;
					},

					/**
					 * @inheritdoc BPMSoft.BaseParametersMappingPage#initActiveRow
					 * @overridden
					 */
					initActiveRow: function() {
						const mappingInfo = this.sandbox.publish("GetParameterMappingInfo", null, [this.sandbox.id]);
						if (mappingInfo && mappingInfo.parameterUId && mappingInfo.schemaElementUId) {
							const processSchema = this.get("ProcessSchema");
							const flowElement = processSchema.findItemByUId(mappingInfo.schemaElementUId);
							let parameterActiveRowValue = mappingInfo.entityColumnUId;
							parameterActiveRowValue = parameterActiveRowValue || mappingInfo.parameterUId;
							this.set("ElementsGridActiveRow", flowElement.name);
							this.set("ParametersGridActiveRow", parameterActiveRowValue);
						} else {
							const collection = this.getGridData("ElementsGrid");
							if (!collection.isEmpty()) {
								this.setFirstCollectionRowActive(collection);
							}
						}
						this.on("change:ParametersGridActiveRow", this.onChangeActiveRow, this);
					},

					/**
					 * @inheritdoc BPMSoft.BaseParametersMappingPage#getSelectedData
					 * @overridden
					 */
					getSelectedData: function() {
						const elementRow = this.getActiveRow("ElementsGrid");
						const parameterRow = this.getActiveRow("ParametersGrid");
						if (!elementRow || !parameterRow || !this._isValidCollectionMapping(parameterRow)) {
							return null;
						}
						const extendedProperties = parameterRow.get("ExtendedProperties");
						if (extendedProperties && extendedProperties.isEntitySchemaColumn) {
							return this.getEntityColumnParameterValue(elementRow, parameterRow);
						} else {
							return this.getParameterValue(elementRow, parameterRow);
						}
					},

					/**
					 * Returns selected row data.
					 * @private
					 * @param {Object} elementRow Element row data.
					 * @param {Object} parameterRow Parameter row data.
					 * @return {{value: string Parameter mapping path, displayValue: string Selected item caption}}
					 */
					getEntityColumnParameterValue: function(element, parameter) {
						const extendedProperties = parameter.get("ExtendedProperties");
						const valueMacros = BPMSoft.FormulaMacros.prepareEntityColumnParameterValue(element.get("Id"),
							extendedProperties.parameterUId, parameter.get("Id"));
						const displayValueMacros = BPMSoft.FormulaMacros.prepareEntityColumnParameterDisplayValue(
							element.get("Caption"), extendedProperties.parameterCaption, parameter.get("Caption"));
						return {
							value: valueMacros.getBody(),
							displayValue: displayValueMacros.getBody()
						};
					},

					/**
					 * Returns selected row data.
					 * @protected
					 * @return {Object} elementRow Element row data.
					 * @return {Object} parameterRow Parameter row data.
					 * @return {String} return.displayValue Selected item caption.
					 * @return {Object} Parameter mapping path.
					 */
					getParameterValue: function(elementRow, parameterRow) {
						const valueMacros = BPMSoft.FormulaMacros.prepareProcessElementParameterValue(
							elementRow.$Id, parameterRow.$Id);
						const caption = (this.getIsFeatureEnabled("ProcessParameterCollections") || BPMSoft.isDebug)
							? parameterRow.$Parameter.getFullCaption()
							: parameterRow.$Caption;
						const displayValueMacros = BPMSoft.FormulaMacros.prepareProcessElementParameterDisplayValue(
							elementRow.$Caption, caption);
						return {
							value: valueMacros.getBody(),
							displayValue: displayValueMacros.getBody()
						};
					},

					/**
					 * Selects active row event handler on process elements grid.
					 * @param {String} flowElementPrimaryColumn Name of selected process flow element.
					 * @public
					 */
					onSelectFlowElement: function(flowElementPrimaryColumn) {
						this.getParametersGridRowCollection(flowElementPrimaryColumn, function(gridRowCollection) {
							this.loadParametersGrid(gridRowCollection);
							this.set("ParametersGridActiveRow", null);
						}, this);
					},

					/**
					 * Applies empty message config for elements grid.
					 * @param {Object} config Configuration object.
					 */
					applyEmptyElementsGridMessageConfig: function(config) {
						const searchText = this.getElementsGridSearchText();
						const isSearchEmpty = this.Ext.isEmpty(searchText);
						const title = isSearchEmpty
							? this.get("Resources.Strings.ElementsEmptyGridMessage")
							: this.get("Resources.Strings.ElementParametersNoElementsFoundMessage");
						const wrapClasses = ["empty-grid-message", "half-width"];
						this.applyEmptyGridMessageConfig(config, title, wrapClasses);
					},

					/**
					 * Applies empty message config for element parameters grid.
					 * @param {Object} config Configuration object.
					 */
					applyEmptyParametersGridMessageConfig: function(config) {
						const searchText = this.getParametersGridSearchText();
						const isSearchEmpty = this.Ext.isEmpty(searchText);
						const hasParameters = this.get("HasParameters");
						let title;
						if (isSearchEmpty) {
							title = hasParameters
								? this.get("Resources.Strings.ElementParametersNoRequiredParameters")
								: this.get("Resources.Strings.ElementParametersEmptyGridMessage");
						} else {
							title = this.get("Resources.Strings.ElementParametersNoParametersFoundMessage");
						}
						const wrapClasses = ["empty-grid-message"];
						this.applyEmptyGridMessageConfig(config, title, wrapClasses);
					},

					/**
					 * Returns active process element row view model.
					 * @private
					 * @return {BPMSoft.BaseViewModel} Active grid row view model.
					 */
					getElementsGridActiveRow: function() {
						return this.getActiveRow("ElementsGrid");
					},

					/**
					 * Returns collection of process element view models.
					 * @private
					 * @return {BPMSoft.BaseViewModelCollection} Process elements grid data.
					 */
					getElementsGridData: function() {
						return this.getGridData("ElementsGrid");
					},

					/**
					 * Returns collection of element parameters view models.
					 * @private
					 * @return {BPMSoft.BaseViewModelCollection} Element parameters grid data.
					 */
					getParametersGridData: function() {
						return this.getGridData("ParametersGrid");
					},

					/**
					 * Returns row collection of the grid.
					 * @protected
					 * @virtual
					 * @param {String} gridName Grid name.
					 * @return {BPMSoft.BaseViewModelCollection} Collection of view models.
					 */
					getGridData: function(gridName) {
						return this.get(gridName + "Data");
					}
				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "insert",
						"name": "left-grid-container",
						"propertyName": "items",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.CONTAINER,
							"wrapClass": ["grid-container", "left"],
							"items": []
						}
					},
					{
						"operation": "insert",
						"name": "ElementsGridSearchText",
						"parentName": "left-grid-container",
						"propertyName": "items",
						"values": {
							"generator": "SearchEditGenerator.generate",
							"markerValue": {"bindTo": "ElementsSearchMarkerValue"},
							"labelConfig": {visible: false},
							"layout": {
								"column": 0,
								"row": 0,
								"colSpan": 24
							},
							"value": {"bindTo": "ElementsGridSearchText"},
							"controlWrapConfig": {"classes": {"wrapClassName": ["search-text-edit"]}},
							"hasClearIcon": true,
							"controlConfig": {
								"className": "BPMSoft.SearchEdit",
								"placeholder": {"bindTo": "Resources.Strings.ElementSearchPlaceholder"},
								"cleariconclick": {"bindTo": "filterElementsCollection"},
								"enterkeypressed": {"bindTo": "filterElementsCollection"},
								"searchValueDeleted": {"bindTo": "loadMainCollection"},
								"rightIconClick": {"bindTo": "filterElementsCollection"}
							}
						}
					},
					{
						"operation": "insert",
						"name": "ElementsGrid",
						"parentName": "left-grid-container",
						"propertyName": "items",
						"values": {
							"primaryDisplayColumnName": "Caption",
							"primaryColumnName": "Name",
							"itemType": this.BPMSoft.ViewItemType.GRID,
							"type": "listed",
							"collection": {
								"bindTo": "ElementsGridData"
							},
							"selectRow": {
								"bindTo": "onSelectFlowElement"
							},
							"activeRow": {
								"bindTo": "ElementsGridActiveRow"
							},
							"getEmptyMessageConfig": {
								"bindTo": "applyEmptyElementsGridMessageConfig"
							},
							"isEmpty": {
								"bindTo": "IsElementsGridEmpty"
							},
							"columnsConfig": [
								{
									cols: 24,
									key: [
										{
											name: {bindTo: "Icon"},
											type: this.BPMSoft.GridIconType.ICON22LISTED
										},
										{
											name: {bindTo: "Caption"}
										}
									]
								}
							]
						}
					},
					{
						"operation": "insert",
						"name": "right-grid-container",
						"propertyName": "items",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.CONTAINER,
							"wrapClass": ["grid-container", "right"],
							"items": [],
							"visible": {
								"bindTo": "IsElementsGridEmpty",
								"bindConfig": {
									"converter": function(value) {
										return value !== true;
									}
								}
							}
						}
					},
					{
						"operation": "insert",
						"name": "ParametersGridSearchText",
						"parentName": "right-grid-container",
						"propertyName": "items",
						"values": {
							"generator": "SearchEditGenerator.generate",
							"markerValue": {"bindTo": "ParametersSearchMarkerValue"},
							"labelConfig": {visible: false},
							"layout": {
								"column": 0,
								"row": 0,
								"colSpan": 24
							},
							"value": {"bindTo": "ParametersGridSearchText"},
							"controlWrapConfig": {"classes": {"wrapClassName": ["search-text-edit"]}},
							"hasClearIcon": true,
							"controlConfig": {
								"className": "BPMSoft.SearchEdit",
								"placeholder": {"bindTo": "Resources.Strings.ElementParametersSearchPlaceholder"},
								"cleariconclick": {"bindTo": "filterParametersCollection"},
								"searchValueDeleted": {"bindTo": "onParametersSearchValueDeleted"},
								"enterkeypressed": {"bindTo": "filterParametersCollection"},
								"rightIconClick": {"bindTo": "filterParametersCollection"}
							}
						}
					},
					{
						"operation": "insert",
						"name": "ParametersGrid",
						"parentName": "right-grid-container",
						"propertyName": "items",
						"values": {
							"_toggleFoldingOnExpandHierarchyLevelChange": true,
							"hierarchical": "$IsElementsGridHierarchical",
							"hierarchicalColumnName": "ParentUId",
							"primaryDisplayColumnName": "Caption",
							"primaryColumnName": "Id",
							"itemType": BPMSoft.ViewItemType.GRID,
							"collection": {"bindTo": "ParametersGridData"},
							"type": "listed",
							"openRecord": {"bindTo": "onGridDoubleClick"},
							"getEmptyMessageConfig": {"bindTo": "applyEmptyParametersGridMessageConfig"},
							"isEmpty": {"bindTo": "IsParametersGridEmpty"},
							"expandHierarchyLevels": "$ExpandedParameters",
							"activeRow": {"bindTo": "ParametersGridActiveRow"},
							"columnsConfig": [{
								cols: 24,
								key: [
									{
										name: {bindTo: "Icon"},
										type: BPMSoft.GridIconType.ICON16LISTED
									},
									{
										name: {bindTo: "Caption"}
									}
								]
							}]
						}
					}
				]
			};
		});
