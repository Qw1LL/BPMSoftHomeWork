﻿define("SpecificationFilterViewModel", ["SpecificationFilterViewModelResources", "ConfigurationEnums",
	"SpecificationConstants"],
	function(resources, ConfigurationEnums, SpecificationConstants) {

		/**
		 * ########## ############ ###### ############# ###### ########### ########## #############
		 * @returns {Object}
		 */
		function generate(parentSandbox, config) {
			var sandbox = parentSandbox;
			var viewModelConfig = {
				entitySchema: config.entitySchema,
				values: {
					/**
					 * ######### ######### #######
					 * @type {BPMSoft.BaseViewModelCollection}
					 */
					GridData: new BPMSoft.BaseViewModelCollection(),

					/**
					 * ######### ####### #######
					 * @type {BPMSoft.Collection}
					 */
					FilterColumns: new BPMSoft.Collection(),


					SpecificationFilters: new BPMSoft.Collection(),

					/**
					 * ######### ############# ########
					 * @type {BPMSoft.Collection}
					 */
					ColumnViewCollection: new BPMSoft.Collection(),

					/**
					 * #### ######## ########
					 * @type {String}
					 */
					CataloguePath: "",

					/**
					 * ######### ########
					 * @type {BPMSoft.FilterGroup}
					 */
					Filters: BPMSoft.createFilterGroup()
				},

				methods: {
					/**
					 * ############# ######### #####
					 * @param config
					 */
					init: function(config, callback, scope) {
						if (config && config.displayValue) {
							this.set("CataloguePath", config.displayValue);
							this.set("ActiveRow", config.activeRow);
							//config.productType = "AC5FDC34-5D1D-4BE0-8B46-4B68EC9622D5";
							if (config.productType) {
								this.set("ProductType", config.productType);
							} else {
								callback.call(scope);
								return;
							}
						}
						var filterColumns = this.get("FilterColumns");
						// DM
						var specificationFilters = this.get("SpecificationFilters");
						///////////////////////
						var select = Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: "ProductFilter"
						});
						select.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_COLUMN, "Id");
						select.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_DISPLAY_COLUMN, "Name");
						var column = select.addColumn("Position");
						column.orderDirection = BPMSoft.OrderDirection.ASC;
						column.orderPosition = 0;
						select.addColumn("Type");
						select.addColumn("Specification");
						select.addColumn("Specification.Type", "SpecificationType");
						select.addColumn("ColumnPath");
						select.addColumn("ReferenceSchemaName");
						select.addColumn("ColumnDataValueType");
						select.addColumn("ColumnCaption");
						select.addColumn("ProductType");
						select.rowCount = -1;
						select.filters.addItem(BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
							"ProductType.Id", this.get("ProductType")));
						select.getEntityCollection(function(result) {
							var collection = result.collection;
							if (collection && collection.collection.length > 0) {
								BPMSoft.each(collection.collection.items, function(item) {
									if (item && item.get("Type").value ===
										SpecificationConstants.ProductFilterType.Field) {
										var columnDataValueType = item.get("ColumnDataValueType");
										var referenceSchemaName = item.get("ReferenceSchemaName");
										var columnPath = item.get("ColumnPath");
										// ######### ####
										if (columnDataValueType === BPMSoft.DataValueType.TEXT) {
											var config = {
												name: item.get("ColumnPath"),
												caption: item.get("Name"),
												uId: item.get("Id"),
												dataValueType: columnDataValueType
											};
											var viewTextConfig = this.SpecificationFilterView.generateTextView(config);
											var viewText = Ext.create(viewTextConfig.className, viewTextConfig);
											this["on" + config.name.replace(".", "_") + "EnterPressed"] = function() {
												this.updateFilters(true);
											};
											filterColumns.add(config.name + "Value" + config.uId, {
												ColumnKey: config.name + "Value",
												Column: config.name,
												ComparisonType: BPMSoft.ComparisonType.START_WITH
											});
											this.get("ColumnViewCollection").add(config.uId, viewText);
										}
										// ########## ####
										else if (columnDataValueType === BPMSoft.DataValueType.LOOKUP) {
											// ########## #######
											var lookupConfig = {
												name: item.get("ColumnPath").replace(".", "_"),
												caption: item.get("Name"),
												uId: item.get("Id"),
												dataValueType: columnDataValueType
											};
											// ######### #############
											var viewLookupConfig =
												this.SpecificationFilterView.generateLookupFilterView(lookupConfig);
											this["onGetItemConfig" + lookupConfig.name]  = function(itemConfig, model) {
												var lookupElementConfig = this.SpecificationFilterView.generateLookupElementView(model);
												itemConfig.config = lookupElementConfig;
											};
											// ########## ###### ##########
											var gridData = this.getGridData(lookupConfig.name);
											var selectLookupItem =
												Ext.create("BPMSoft.EntitySchemaQuery", {
													rootSchemaName: referenceSchemaName
												});
											selectLookupItem.addMacrosColumn(
												BPMSoft.QueryMacrosType.PRIMARY_COLUMN, "Id");
											var columnName = selectLookupItem.addMacrosColumn(
												BPMSoft.QueryMacrosType.PRIMARY_DISPLAY_COLUMN, "Name");
											columnName.orderDirection = BPMSoft.OrderDirection.ASC;
											columnName.orderPosition = 0;
											selectLookupItem.addParameterColumn(false,
												BPMSoft.DataValueType.BOOLEAN, "CheckBox");
											selectLookupItem.addParameterColumn(referenceSchemaName,
												BPMSoft.DataValueType.TEXT, "ReferenceSchemaName");
											selectLookupItem.addParameterColumn(columnPath,
												BPMSoft.DataValueType.TEXT, "ColumnPath");
											selectLookupItem.rowCount = -1;
											selectLookupItem.getEntityCollection(function(result) {
												var collection = result.collection;
												if (collection && collection.collection.length > 0) {
													collection.each(function(item) {
														item.sandbox = sandbox;
														item.checkedchanged = this.checkedElement;
														item.filterViewModel = this;
													}, this);
													gridData.loadAll(collection);
													this.set("IsToolsButtonVisible" + lookupConfig.name, gridData.getCount() > 5);
												}
											}, this);
											this.get("ColumnViewCollection").add(lookupConfig.uId, viewLookupConfig);
										}
									}
									// ######### ######## ## ###############
									else if (item && item.get("Type").value ===
										SpecificationConstants.ProductFilterType.Specification) {
										var specificationTypeId = item.get("SpecificationType").value;
										// ######### ############# ########## ####
										if (specificationTypeId === SpecificationConstants.SpecificationTypes.ListType) {
											var lookupConfig = {
												name: item.get("Specification").value,
												caption: item.get("Specification").displayValue,
												uId: item.get("Id")
											};
											var viewLookupConfig =
												this.SpecificationFilterView.generateLookupFilterView(lookupConfig);
											this["onGetItemConfig" + lookupConfig.name]  = function(itemConfig, model) {
												var lookupElementConfig = this.SpecificationFilterView.generateLookupElementView(model);
												itemConfig.config = lookupElementConfig;
											};
											var gridData = this.getGridData(lookupConfig.name);
											var selectSpecificationListItem =
												Ext.create("BPMSoft.EntitySchemaQuery", {
													rootSchemaName: "SpecificationListItem"
												});
											selectSpecificationListItem.addMacrosColumn(
												BPMSoft.QueryMacrosType.PRIMARY_COLUMN, "Id");
											var columnName = selectSpecificationListItem.addMacrosColumn(
												BPMSoft.QueryMacrosType.PRIMARY_DISPLAY_COLUMN, "Name");
											columnName.orderDirection = BPMSoft.OrderDirection.ASC;
											columnName.orderPosition = 0;
											selectSpecificationListItem.addColumn("Specification");
											selectSpecificationListItem.addColumn("Specification.Type",
												"SpecificationType");
											selectSpecificationListItem.addParameterColumn(false,
												BPMSoft.DataValueType.BOOLEAN, "CheckBox");
											selectSpecificationListItem.rowCount = -1;
											selectSpecificationListItem.filters.addItem(
												BPMSoft.createColumnFilterWithParameter(
													BPMSoft.ComparisonType.EQUAL,
													"Specification.Id", item.get("Specification").value));
											selectSpecificationListItem.getEntityCollection(function(result) {
												var collection = result.collection;
												if (collection && collection.collection.length > 0) {
													collection.each(function(item) {
														item.sandbox = sandbox;
														item.checkedchanged = this.checkedElement;
														item.filterViewModel = this;
													}, this);
													gridData.loadAll(collection);
													this.set("IsToolsButtonVisible" + lookupConfig.name, gridData.getCount() > 5);
												}
											}, this);
											this.get("ColumnViewCollection").add(lookupConfig.uId, viewLookupConfig);
										} else if (specificationTypeId ===
											SpecificationConstants.SpecificationTypes.StringType) {
											var configSpecificationText = {
												name: "Specification_" + item.get("Specification").value.replace(/-/gi, "_"),
												caption: item.get("Name"),
												uId: item.get("Id"),
												dataValueType: BPMSoft.DataValueType.TEXT
											};
											var viewTextConf =
												this.SpecificationFilterView.generateTextView(configSpecificationText);
											var viewSpecificationText = Ext.create(viewTextConf.className, viewTextConf);
											this["on" + configSpecificationText.name.replace(".", "_") + "EnterPressed"] = function() {
												this.updateFilters(true);
											};
											specificationFilters.add(
												configSpecificationText.name + "Value" + configSpecificationText.uId, {
													SpecificationId: item.get("Specification").value,
													ColumnKey: configSpecificationText.name + "Value",
													ComparisonType: BPMSoft.ComparisonType.CONTAIN,
													ValueColumn: "StringValue"
												});
											this.get("ColumnViewCollection").add(configSpecificationText.uId,
												viewSpecificationText);
										}
									}
								}, this);
							}
							callback.call(scope);
						}, this);
					},

					/**
					 * ########## ########### ############ ###### #######
					 * @protected
					 * @param itemValues
					 * @param rowValues
					 * @param entitySchema
					 * @returns {BaseViewModel}
					 */
					getGridRecordByItemValues: function(rowConfig, rowValues, entitySchema) {
						var gridRecord = Ext.create("BPMSoft.BaseViewModel", {
							//entitySchema: entitySchema,
							rowConfig: rowConfig,
							values: rowValues,
							isNew: false,
							isDeleted: false,
							methods: {

							}
						});
						return gridRecord;
					},

					/**
					 * ######## ######### ######### ####### #### "##########"
					 * @param uid
					 * @returns {Object}
					 */
					getGridData: function(uid) {
						var gridData = this.get("GridData" + uid);
						if (Ext.isEmpty(gridData)) {
							gridData = new BPMSoft.BaseViewModelCollection();
							this.set("GridData" + uid, gridData);
						}
						return gridData;
					},

					/**
					 * ############ ####### ########### ###### ####### #### "##########"
					 * @private
					 */
					onCollapsedChanged: function() {},

					/**
					 * ############ ##### ######## ####### #### "##########"
					 * @private
					 */
					selectUnselectSpecification: function() {
						var args = arguments[3];
						this.set("StopCheckEvent_" + args.id, true);
						var gridData = this.getGridData(args.id);
						gridData.each(function(item) {
							item.set("CheckBox", args.key);
						}, this);
						this.set("StopCheckEvent_" + args.id, false);
					},

					/**
					 * ############ ######### ######## ####### #### "##########"
					 * @private
					 */
					checkedElement: function(checked, gridDataId) {
						/*
						if (!this.get("StopCheckEvent_" + id)) {
						}
						*/
						var filters = this.filterViewModel.get("Filters");
						var selectedItemId = this.get("Id");
						var filterKey = selectedItemId + "Filter";
						var filterGroupKey = gridDataId + "Filter";
						var filterGroup = null;
						/** ####### ########### # ###### # ############ ##### ###
						 * ### ##### ####### ####### ######. #### ## ###, ## #########
						 * ##### ######## # #######
						 */
						if (!filters.contains(filterGroupKey)) {
							filterGroup = BPMSoft.createFilterGroup();
							filterGroup.logicalOperation = BPMSoft.LogicalOperatorType.OR;
							filters.add(filterGroupKey, filterGroup);
						} else {
							filterGroup = filters.get(filterGroupKey);
						}
						if (filterGroup.contains(filterKey)) {
							filterGroup.removeByKey(filterKey);
						}
						if (checked) {
							var newFilter = null;
							var columnPath = this.get("ColumnPath");
							if (!Ext.isEmpty(columnPath))
							{
								var columnFilter = BPMSoft.createColumnFilterWithParameter(
									BPMSoft.ComparisonType.EQUAL, columnPath, selectedItemId);
								filterGroup.add(filterKey, columnFilter);
							}else{
								// ############ ####### ## ############
								var existFilter = BPMSoft.createExistsFilter(
									"[SpecificationInProduct:Product:Id].Id");
								existFilter.subFilters.addItem(BPMSoft.createColumnFilterWithParameter(
									BPMSoft.ComparisonType.EQUAL, "ListItemValue", selectedItemId));
								existFilter.subFilters.addItem(BPMSoft.createColumnFilterWithParameter(
									BPMSoft.ComparisonType.EQUAL, "Specification", gridDataId));
								filterGroup.add(filterKey, existFilter);
							}
						}
					},

					/**
					 * ######### ###### # #########
					 * @private
					 * @param name
					 */
					addFilter: function(filters, column) {
						var key = column.ColumnKey;
						var value = this.get(key);
						var filterKey = key + "Filter";
						if (filters.contains(filterKey)) {
							filters.removeByKey(filterKey);
						}
						if (!Ext.isEmpty(value)) {
							filters.add(filterKey,
								BPMSoft.createColumnFilterWithParameter(
									column.ComparisonType, column.Column, value)
							);
						}
					},

					/**
					 * ######### ###### ## ############## ########## ####
					 * @param filters - ######### ######## #### ########### ############## ######
					 * @param specificationFilter - ###### ## ###### ####### ########### ######
					 */
					addSpecificationFilter: function(filters, specificationFilter) {
						var key = specificationFilter.ColumnKey;
						var specificationId = specificationFilter.SpecificationId;
						var value = this.get(key);
						var filterKey = key + "Filter";
						if (filters.contains(filterKey)) {
							filters.removeByKey(filterKey);
						}
						if (!Ext.isEmpty(value)) {
							var existFilter = BPMSoft.createExistsFilter(
								"[SpecificationInProduct:Product:Id].Id");
							existFilter.subFilters.addItem(BPMSoft.createColumnFilterWithParameter(
								specificationFilter.ComparisonType, specificationFilter.ValueColumn, value));
							existFilter.subFilters.addItem(BPMSoft.createColumnFilterWithParameter(
								BPMSoft.ComparisonType.EQUAL, "Specification", specificationId));
							filters.add(filterKey, existFilter);
						}
					},

					/**
					 * ######### ######### ######## # ######### ##
					 * @private
					 */
					updateFilters: function(autoApply) {
						var filterColumns = this.get("FilterColumns");
						var specificationFilters = this.get("SpecificationFilters");
						var filters = this.get("Filters");
						filters.logicalOperation = BPMSoft.LogicalOperatorType.AND;
						filterColumns.each(function(column) {
							this.addFilter(filters, column);
						}, this);
						specificationFilters.each(function(specFilter) {
							this.addSpecificationFilter(filters, specFilter);
						}, this);
						/*
						var filterItem = {
							key: "UpdateExtendFilterItem",
							filters: filters,
							rowId: this.get("ActiveRow")
						};
						*/
						//sandbox.publish("UpdateExtendCatalogueFilter", filterItem, [sandbox.id]);
						if (autoApply) {
							this.applyFilters();
						}
					},

					/**
					 * ######### # ########## ######### UpdateExtendCatalogueFilter
					 */
					applyFilters: function() {
						var filters = this.get("Filters");
						var filterItem = {
							key: "UpdateExtendFilterItem",
							filters: filters,
							rowId: this.get("ActiveRow")
						};
						sandbox.publish("UpdateExtendCatalogueFilter", filterItem, [sandbox.id]);
					},

					/**
					 * ############ ######### ############# ########## ########## ########
					 * @protected
					 */
					renderFilterElements: function() {
						var collection = this.get("ColumnViewCollection");
						var renderToContainer = Ext.getCmp("filterElementsContainer");
						collection.each(function(view) {
							view.bind(this);
							renderToContainer.items.add(view);
						}, this);
					},

					/**
					 * ############ ######## ###### ########### ########## #########
					 * @protected
					 */
					onGoBackToFolders: function() {
						const filters = this.get("Filters");
						filters.clear();
						this.applyFilters();
						sandbox.publish("CloseExtendCatalogueFilter", null, [sandbox.id]);
					},

					/**
					 * ######### ##########
					 * @protected
					 */
					applyButton: function() {
						this.updateFilters(true);
					}

				}
			};
			return viewModelConfig;
		}

		/**
		 * ######## ###### ############# ######## ########## #######
		 * @param entitySchema
		 * @param mainViewModel
		 * @returns {Object}
		 */
		function getSpecificationViewModelConfig(entitySchema, mainViewModel) {
			var viewModelConfig = {
				entitySchema: entitySchema,
				values: {
				},
				methods: {
				}
			};
			return viewModelConfig;
		}

		return {
			generate: generate,
			getSpecificationViewModelConfig: getSpecificationViewModelConfig
		};
	});
