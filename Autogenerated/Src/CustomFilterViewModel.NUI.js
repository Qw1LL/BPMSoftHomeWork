﻿define("CustomFilterViewModel", ["ext-base", "BPMSoft", "CustomFilterViewModelResources", "ConfigurationEnums"],
	function(Ext, BPMSoft, resources, ConfigurationEnums) {

		var customFilterPrefix = "customFilter";

		function generate(config) {
			var viewModelConfig = {
				entitySchema: config.entitySchema,
				columns: {
					buttonCaption: {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						name: "buttonCaption"
					},
					simpleFilterColumn: {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						name: "simpleFilterColumn"
					},
					booleanValueColumnList: {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						name: "booleanValueColumnList",
						isCollection: true
					},
					simpleFilterColumnList: {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						name: "simpleFilterColumnList",
						isCollection: true
					},
					simpleFilterValueColumn: {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						name: "simpleFilterValueColumn"
					}
				},
				values: {
					primaryDisplayColumnConfig: null,
					primaryDisplayColumnFilterTag: null,
					quickFilterKey: config.quickFilterKey,
					filters: new BPMSoft.Collection(),
					filtersViews: new BPMSoft.Collection(),
					currentFilterName: null,
					simpleFilterColumnList: new BPMSoft.Collection(),
					booleanValueColumnList: new BPMSoft.Collection(),
					buttonCaption: resources.localizableStrings.FiltersCaption
				},
				methods: {
					getFilters: getFilters,
					clearConditions: clearConditions,
					subscribeForCollectionEvent: subscribeForCollectionEvent,
					initialize: initialize,
					updateButtonCaption: updateButtonCaption,
					loadFilterViews: loadFilterViews,
					addFilterView: addFilterView,
					removeFilterView: removeFilterView,
					clearFilterViews: clearFilterViews,
					getSimpleFilterColumnList: getSimpleFilterColumnList,
					simpleFilterColumnChange: simpleFilterColumnChange,
					cancelSimpleFilter: clearSimpleFilterProperties,
					applySimpleFilter: applySimpleFilter,
					addSimpleFilterValue: addSimpleFilterValue,
					addExtendFilterValue: addExtendFilterValue,
					clearSimpleFilterProperties: clearSimpleFilterProperties,
					generateFilterViewModelConfig: generateFilterViewModelConfig,
					getSimpleFilter: getSimpleFilter,
					getExtendFilter: getExtendFilter,
					addSimpleFilter: addSimpleFilter,
					editSimpleFilter: editSimpleFilter,
					editExtendFilter: editExtendFilter,
					getValueEditControlConfig: getValueEditControlConfig,
					getBooleanValueColumnList: getBooleanValueColumnList,
					getFilterValue: getFilterValue,
					addFilterValue: addFilterValue,
					showFolders: showFolders,
					updateFiltersByObjectPath: config.updateFiltersByObjectPath
				}
			};

			if (config.entitySchema.primaryDisplayColumnName) {
				viewModelConfig.values.primaryDisplayColumnFilterTag = customFilterPrefix +
					config.entitySchema.primaryDisplayColumnName + config.quickFilterKey;
				viewModelConfig.values.primaryDisplayColumnConfig = {
					value: config.entitySchema.primaryDisplayColumnName,
					displayValue: config.entitySchema.primaryDisplayColumn.caption,
					dataValueType: config.entitySchema.primaryDisplayColumn.dataValueType,
					referenceSchemaName: config.entitySchema.primaryDisplayColumn.referenceSchemaName
				};
			}
			return viewModelConfig;
		}

		function generateFilterViewModelConfig() {
			return {
				columns: {
					columnCaption: {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						name: "columnCaption"
					},
					displayValue: {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						name: "displayValue"
					},
					filterName: {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						name: "filterName"
					}
				},
				values: {
					columnCaption: "",
					columnName: null,
					value: null,
					dataValueType: null,
					referenceSchemaName: null,
					referenceSchemaPrimaryDisplayColumnName: null,
					view: null,
					viewVisible: true
				},
				methods: {
				}
			};
		}

		function initialize() {
			this.subscribeForCollectionEvent();
			this.suspendUpdate = true;
			var filterState = this.getFilterState("Custom");
			if (filterState) {
				for (var key in filterState) {
					this.addFilterValue(key, filterState[key]);
				}
			}
			this.suspendUpdate = false;
		}

		function getSimpleFilterDisplayValue(simpleFilterColumn, simpleFilterValue) {
			var displayValue;
			if (simpleFilterColumn.dataValueType === BPMSoft.DataValueType.ENUM ||
				simpleFilterColumn.dataValueType === BPMSoft.DataValueType.LOOKUP) {
				displayValue = simpleFilterValue;
			}
			else if (simpleFilterColumn.dataValueType === BPMSoft.DataValueType.DATE_TIME) {
				displayValue = BPMSoft.getTypedStringValue(simpleFilterValue, BPMSoft.DataValueType.DATE);
			}
			else if (simpleFilterColumn.dataValueType === BPMSoft.DataValueType.BOOLEAN) {
				displayValue = simpleFilterValue.displayValue;
			}
			else {
				displayValue = BPMSoft.getTypedStringValue(simpleFilterValue, simpleFilterColumn.dataValueType);
			}
			return displayValue;
		}

		function addSimpleFilterValue(simpleFilterColumn, simpleFilterValue) {
			var filters = this.get("filters");
			var oldFilterName = this.get("currentFilterName");
			var filterName = customFilterPrefix + simpleFilterColumn.value + this.get("quickFilterKey");
			if (oldFilterName && filterName !== oldFilterName) {
				filters.removeByKey(oldFilterName);
			}
			var simpleFilter = filters.find(filterName);
			if (!simpleFilter) {
				var config = this.generateFilterViewModelConfig();
				config.methods.editFilter = function(tag) {
					customFilterViewModel.editSimpleFilter(tag);
				};
				config.methods.getFilter = this.getSimpleFilter;
				simpleFilter = this.getFilterViewModel(filterName, config);
				var customFilterViewModel = this;
				simpleFilter.set("filterName", filterName);
				simpleFilter.set("columnName", simpleFilterColumn.value);
				simpleFilter.set("columnCaption", simpleFilterColumn.displayValue);
				simpleFilter.set("value", simpleFilterValue);
				simpleFilter.set("displayValue",
					getSimpleFilterDisplayValue(simpleFilterColumn, simpleFilterValue));
				simpleFilter.set("dataValueType", simpleFilterColumn.dataValueType);
				filters.add(filterName, simpleFilter);
				if (simpleFilterColumn.referenceSchemaName) {
					simpleFilter.set("referenceSchemaName", simpleFilterColumn.referenceSchemaName);
					var thisContext = this;
					if (simpleFilterColumn.primaryDisplayColumnName) {
						simpleFilter.set("referenceSchemaPrimaryDisplayColumnName",
							simpleFilterColumn.primaryDisplayColumnName);
						this.filterChanged();
					} else {
						require([simpleFilterColumn.referenceSchemaName], function(schema) {
							simpleFilter.set("referenceSchemaPrimaryDisplayColumnName",
								schema.primaryDisplayColumnName);
							thisContext.filterChanged();
						}, this);
					}
				}
				else {
					this.filterChanged();
				}
			}
			else {
				simpleFilter.set("value", simpleFilterValue);
				simpleFilter.set("displayValue",
					getSimpleFilterDisplayValue(simpleFilterColumn, simpleFilterValue));
				this.filterChanged();
			}
		}

		function addExtendFilterValue(extendFilterValue) {
			var filters = this.get("filters");
			var oldFilterName = this.get("currentFilterName");
			if (!this.extendFilterIndex) {
				this.extendFilterIndex = 0;
			}
			var filterName = "customExtendFilter" + this.get("quickFilterKey") + this.extendFilterIndex++;
			if (oldFilterName) {
				filters.removeByKey(oldFilterName);
			}
			var customFilterViewModel = this;
			var config = this.generateFilterViewModelConfig();
			config.methods.editFilter = function() {
				customFilterViewModel.editExtendFilter();
			};
			config.methods.getFilter = this.getExtendFilter;
			var extendFilter = this.getFilterViewModel(filterName, config);
			extendFilter.set("filterName", filterName);
			extendFilter.set("value", extendFilterValue.value);
			var extendFilterDisplayValue = extendFilterValue.displayValue;
			extendFilter.set("displayValue", extendFilterDisplayValue.length > 20 ?
				extendFilterDisplayValue.substring(0, 20) + "..." : extendFilterDisplayValue);
			filters.add(filterName, extendFilter);
			this.filterChanged();
		}

		function applySimpleFilter() {
			var simpleFilterColumn = this.get("simpleFilterColumn");
			var simpleFilterValue = this.get("simpleFilterValueColumn");
			if (simpleFilterColumn && !Ext.isEmpty(simpleFilterValue)) {
				this.addSimpleFilterValue(simpleFilterColumn, simpleFilterValue);
				this.destroySimpleFilterAddingContainer();
			}
		}

		function clearSimpleFilterProperties() {
			this.set("simpleFilterColumn", null);
			this.set("simpleFilterValueColumn", null);
			this.set("currentFilterName", null);
		}

		function getValueEditControlConfig(dataValueType) {
			var className;
			switch (dataValueType) {
				case BPMSoft.DataValueType.INTEGER:
					className = "BPMSoft.IntegerEdit";
					break;
				case BPMSoft.DataValueType.FLOAT:
					className = "BPMSoft.FloatEdit";
					break;
				case BPMSoft.DataValueType.MONEY:
					className = {
						className: "BPMSoft.FloatEdit",
						decimalPrecision: 2
					};
					break;
				case BPMSoft.DataValueType.DATE:
				case BPMSoft.DataValueType.DATE_TIME:
					className = "BPMSoft.DateEdit";
					break;
				case BPMSoft.DataValueType.BOOLEAN:
					className = {
						className: "BPMSoft.ComboBoxEdit",
						list: {
							bindTo: "booleanValueColumnList"
						},
						prepareList: {
							bindTo: "getBooleanValueColumnList"
						}
					};
					break;
				default:
					className = "BPMSoft.TextEdit";
					break;
			}
			return className;
		}

		function simpleFilterColumnChange(value) {
			var dataValueType = value ? value.dataValueType : "";
			var className = this.getValueEditControlConfig(dataValueType);
			this.changeSimpleFilterValueEdit(className);
			this.set("simpleFilterValueColumn", null);
		}

		function getSimpleFilterColumnList(filters, list) {
			list.clear();
			var columnList = {};
			var columnNames = [];
			var columns = this.entitySchema.columns;
			BPMSoft.each(columns, function(column) {
				if (column.dataValueType !== BPMSoft.DataValueType.GUID &&
					column.dataValueType !== BPMSoft.DataValueType.TIME &&
					column.dataValueType !== BPMSoft.DataValueType.BLOB &&
					column.dataValueType !== BPMSoft.DataValueType.IMAGELOOKUP &&
					column.usageType !== ConfigurationEnums.EntitySchemaColumnUsageType.None) {
					columnNames.push({
						name: column.name,
						caption: column.caption
					});
				}
			});
			var sortedColumnNames = columnNames.sort(function(a, b) {
				if (a.caption === b.caption) {
					return 0;
				} else {
					return a.caption > b.caption ? 1 : -1;
				}
			});
			BPMSoft.each(sortedColumnNames, function(item) {
				var column = columns[item.name];
				columnList[column.name] = {
					value: column.name,
					displayValue: column.caption,
					dataValueType: column.dataValueType,
					referenceSchemaName: column.referenceSchemaName
				};
			});
			list.loadAll(columnList);
		}

		function getBooleanValueColumnList(filters, list) {
			list.clear();
			var columnList = {};
			columnList.TRUE = {
				value: "true",
				displayValue: BPMSoft.getTypedStringValue(true, BPMSoft.DataValueType.BOOLEAN)
			};
			columnList.FALSE = {
				value: "false",
				displayValue: BPMSoft.getTypedStringValue(false, BPMSoft.DataValueType.BOOLEAN)
			};
			list.loadAll(columnList);
		}

		function subscribeForCollectionEvent() {
			var filters = this.get("filters");
			filters.on("dataLoaded", this.loadFilterViews, this);
			filters.on("add", this.addFilterView, this);
			filters.on("remove", this.removeFilterView, this);
			filters.on("clear", this.clearFilterViews, this);
		}

		function loadFilterViews() {
			var filtersViews = this.get("filtersViews");
			var filters = this.get("filters");
			filters.each(function(filterViewModel) {
				filtersViews.add(filterViewModel.get("filterName"), filterViewModel.get("view"));
			});
			this.updateButtonCaption();
		}

		function addFilterView(filterViewModel) {
			var filtersViews = this.get("filtersViews");
			filtersViews.add(filterViewModel.get("filterName"), filterViewModel.get("view"));
			this.updateButtonCaption();
		}

		function removeFilterView(filterViewModel) {
			var filtersViews = this.get("filtersViews");
			var view = filtersViews.removeByKey(filterViewModel.get("filterName"));
			view.destroy();
			this.updateButtonCaption();
		}

		function clearFilterViews() {
			var filtersViews = this.get("filtersViews");
			filtersViews.each(function(view) {
				view.destroy();
			});
			filtersViews.clear();
			this.updateButtonCaption();
		}

		function getSimpleFilter() {
			var filter;
			var dataValueType = this.get("dataValueType");
			var value = this.get("value");
			var columnName = this.get("columnName");
			var lookupComparisonType = this.getLookupComparisonType();
			switch (dataValueType) {
				case BPMSoft.DataValueType.LOOKUP:
				case BPMSoft.DataValueType.ENUM:
					filter = BPMSoft.createColumnFilterWithParameter(lookupComparisonType,
						columnName + "." + this.get("referenceSchemaPrimaryDisplayColumnName"),
						value);
					break;
				case BPMSoft.DataValueType.TEXT:
					filter = BPMSoft.createColumnFilterWithParameter(lookupComparisonType,
						columnName, value);
					break;
				case BPMSoft.DataValueType.DATE:
				case BPMSoft.DataValueType.DATE_TIME:
					filter = BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, columnName,
						value);
					filter.trimDateTimeParameterToDate = true;
					break;
				case BPMSoft.DataValueType.BOOLEAN:
					filter = BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
						columnName, value.value);
					break;
				default:
					filter = BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
						columnName, value);
					break;
			}
			filter.leftExpressionCaption = this.get("columnCaption");
			return filter;
		}

		function getExtendFilter() {
			return BPMSoft.deserialize(this.get("value"));
		}

		function getFilters(extendedMode) {
			var filters = this.get("filters");
			var filterCollection = null;
			if (filters.collection.length === 1) {
				var filter = filters.getByIndex(0);
				if (!filter.get("columnName")) {
					filterCollection = filter.getFilter();
					if (!extendedMode && this.updateFiltersByObjectPath) {
						this.updateFiltersByObjectPath(filterCollection, filterCollection.rootSchemaName,
							this.updateFiltersByObjectPath);
					}
					return filterCollection;
				}
			}
			filterCollection = BPMSoft.createFilterGroup();
			filters.each(function(filterInfo) {
				var filter = filterInfo.getFilter();
				if (filter) {
					if (this.updateFiltersByObjectPath) {
						this.updateFiltersByObjectPath(filter, filter.rootSchemaName,
							this.updateFiltersByObjectPath);
					}
					filterCollection.add(filterInfo.get("filterName"), filter);
				}
			}, this);
			return filterCollection;
		}

		function clearConditions() {
			var filters = this.get("filters");
			if (filters.collection.length > 0) {
				filters.clear();
				this.filterChanged();
			}
		}

		function updateButtonCaption() {
			var filters = this.get("filters");
			if (filters.collection.length > 0) {
				this.set("buttonCaption", "");
			} else {
				this.set("buttonCaption", resources.localizableStrings.FiltersCaption);
			}
		}

		function addSimpleFilter() {
			var filters = this.get("filters");
			var defFilter = null;
			if (!filters.find(this.get("primaryDisplayColumnFilterTag"))) {
				defFilter = this.get("primaryDisplayColumnConfig");
			}
			this.set("simpleFilterColumn", defFilter);
			this.set("simpleFilterValueColumn", null);
			this.set("currentFilterName", null);
			if (defFilter) {
				var valueEditConfig = this.getValueEditControlConfig(defFilter.dataValueType);
				this.showSimpleFilterEdit(valueEditConfig);
			}
			else {
				this.showSimpleFilterEdit();
			}
		}

		function editSimpleFilter(tag) {
			if (tag === this.get("currentFilterName")) {
				return;
			}
			var filters = this.get("filters");
			var filterViewModel = filters.find(tag);
			if (filterViewModel) {
				var renderIndex = filters.indexOf(filterViewModel);
				var columnValue = {
					value: filterViewModel.get("columnName"),
					displayValue: filterViewModel.get("columnCaption"),
					dataValueType: filterViewModel.get("dataValueType"),
					referenceSchemaName: filterViewModel.get("referenceSchemaName")
				};
				this.set("currentFilterName", tag);
				var value = filterViewModel.get("value");
				this.set("simpleFilterColumn", columnValue);
				this.set("simpleFilterValueColumn", value);
				var valueEditConfig = this.getValueEditControlConfig(columnValue.dataValueType);
				filterViewModel.set("viewVisible", false);
				this.showSimpleFilterEdit(valueEditConfig, function() {
					filterViewModel.set("viewVisible", true);
				}, renderIndex);
			}
		}

		function editExtendFilter() {
			this.goToExtendedMode();
		}

		function showFolders() {
			this.showFolderManager();
		}

		function getFilterValue(filterName) {
			var result = {};
			var filters = this.get("filters");
			filters.each(function(filterInfo) {
				var filterValue;
				var currentFilterName = filterInfo.get("columnName");
				if (!filterName || currentFilterName === filterName) {
					filterValue = {
						displayValue: filterInfo.get("displayValue")
					};
					if (filterInfo.get("datavalueType") === BPMSoft.DataValueType.BOOLEAN) {
						filterValue.value = filterInfo.get("value").value;
					} else {
						filterValue.value = filterInfo.get("value");
					}
					var referenceSchemaPrimaryDisplayColumnName = filterInfo.get(
						"referenceSchemaPrimaryDisplayColumnName");
					if (referenceSchemaPrimaryDisplayColumnName) {
						filterValue.primaryDisplayColumnName = referenceSchemaPrimaryDisplayColumnName;
					}
				}
				if (filterName) {
					result = filterValue;
				} else {
					result[currentFilterName] = filterValue;
				}
			});
			return result;
		}

		function addFilterValue(filterName, filterValue) {
			var column = this.entitySchema.columns[filterName];
			if (column) {
				var columnConfig = {
					value: column.name,
					displayValue: column.caption,
					dataValueType: column.dataValueType,
					referenceSchemaName: column.referenceSchemaName,
					primaryDisplayColumnName: filterValue.primaryDisplayColumnName
				};
				var value = filterValue.value;
				if (column.dataValueType === BPMSoft.DataValueType.BOOLEAN) {
					value = {
						value: value ? "true" : "false",
						displayValue: BPMSoft.getTypedStringValue(value, BPMSoft.DataValueType.BOOLEAN)
					};
				}
				this.addSimpleFilterValue(columnConfig, value);
			} else {
				this.addExtendFilterValue(filterValue);
			}
		}

		return {
			generate: generate
		};
	});
