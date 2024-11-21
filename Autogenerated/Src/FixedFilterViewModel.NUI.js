define('FixedFilterViewModel', ['ext-base', 'sandbox', 'BPMSoft', 'FixedFilterViewModelResources'],
	function(Ext, sandbox, BPMSoft, resources) {

		function defGetFilter(filterInfo) {
			var filter;
			if (filterInfo.dataValueType === BPMSoft.DataValueType.DATE) {
				var startDate = filterInfo.startDate.value;
				var dueDate = filterInfo.dueDate.value;
				if (filterInfo.singleColumn) {
					if (startDate && dueDate) {
						filter =
							BPMSoft.createColumnBetweenFilterWithParameters(
								filterInfo.startDate.columnName,
								BPMSoft.startOfDay(startDate), BPMSoft.endOfDay(dueDate));
					} else if (startDate) {
						filter =
							BPMSoft.createColumnFilterWithParameter(
								BPMSoft.ComparisonType.GREATER_OR_EQUAL,
								filterInfo.startDate.columnName, BPMSoft.startOfDay(startDate));
					} else if (dueDate) {
						filter =
							BPMSoft.createColumnFilterWithParameter(
								BPMSoft.ComparisonType.LESS_OR_EQUAL,
								filterInfo.startDate.columnName, BPMSoft.endOfDay(dueDate));
					}
				} else {
					var periodFilterCollection = BPMSoft.createFilterGroup();
					periodFilterCollection.logicalOperation = BPMSoft.LogicalOperatorType.AND;
					if (startDate) {
						filter =
							BPMSoft.createColumnFilterWithParameter(
								BPMSoft.ComparisonType.GREATER_OR_EQUAL,
								filterInfo.dueDate.columnName, BPMSoft.startOfDay(startDate));
						periodFilterCollection.add(filterInfo.dueDate.columnName, filter);
					}
					if (dueDate) {
						filter =
							BPMSoft.createColumnFilterWithParameter(
								BPMSoft.ComparisonType.LESS_OR_EQUAL,
								filterInfo.startDate.columnName, BPMSoft.endOfDay(dueDate));
						periodFilterCollection.add(filterInfo.startDate.columnName, filter);
					}
					if (startDate && dueDate) {
						filter = periodFilterCollection;
					}
				}
			}
			else if (filterInfo.value) {
				if (filterInfo.isLookup) {
					filter = BPMSoft.createColumnInFilterWithParameters(filterInfo.columnName,
						filterInfo.value);
				}
				else {
					filter = BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
						filterInfo.columnName, filterInfo.value);
				}
			}

			if (filterInfo.appendFilter) {
				var appendFilter = filterInfo.appendFilter(filterInfo);
				if (appendFilter) {
					if (filter) {
						var filterGroup = BPMSoft.createFilterGroup();
						filterGroup.logicalOperation = filterInfo.appendFilterLogicalOperation ||
							BPMSoft.LogicalOperatorType.OR;
						filterGroup.add(filterInfo.name + 'DefaultFilter', filter);
						filterGroup.add(filterInfo.name + 'AppendedFilter', appendFilter);
						return filterGroup;
					}
					else {
						return appendFilter;
					}
				}
			}
			return filter;
		}

		function defGetFilters(filtersInfo) {
			var filtersCollection = BPMSoft.createFilterGroup();
			filtersCollection.logicalOperation = BPMSoft.LogicalOperatorType.AND;
			BPMSoft.each(filtersInfo, function(filterInfo) {
				var filter;
				if (filterInfo.getFilter) {
					filter = filterInfo.getFilter(filterInfo);
				}
				else {
					filter = defGetFilter(filterInfo);
				}
				if (filter) {
					filtersCollection.add(filterInfo.name, filter);
				}
			}, this);
			return filtersCollection;
		}

		function getFilters() {
			var filtersValues = this.prepareFilters();
			if (this.config.getFilters) {
				return this.config.getFilters(filtersValues);
			}
			return defGetFilters(filtersValues);
		}

		function prepareFilters() {
			var filtersValues = {};
			BPMSoft.each(this.config.filters, function(filterConfig) {
				if (filterConfig.moduleName) {
					return;
				}
				var filterInfo = {
					name: filterConfig.name,
					dataValueType: filterConfig.dataValueType
				};
				if (filterConfig.dataValueType === BPMSoft.DataValueType.DATE) {
					var periodConfig = this.config.getPeriodFilterConfig(filterConfig);
					var startDate = this.get(periodConfig.startDateColumnName);
					var dueDate = this.get(periodConfig.dueDateColumnName);
					filterInfo.startDate = {
						columnName: periodConfig.startDateColumnName,
						value: startDate
					};
					filterInfo.dueDate = {
						columnName: periodConfig.dueDateColumnName,
						value: dueDate
					};
					filterInfo.singleColumn = periodConfig.singleColumn;
				}
				else {
					var entityColumn = this.entitySchema.getColumnByName(filterConfig.columnName);
					filterInfo.columnName = filterConfig.columnName;
					filterInfo.isLookup = entityColumn.isLookup;
					if (entityColumn) {
						if (entityColumn.isLookup) {
							var values = this.get(getSelectedLookupValuesPropertyName(filterConfig.name));
							var filterValues = [];
							values.each(function(value) {
								filterValues.push(value.get('value'));
							}, this);
							if (filterValues.length > 0) {
								filterInfo.value = filterValues;
							}
						} else {
							var value = this.get(filterConfig.name);
							filterInfo.value = value;
						}
					}
				}
				if (filterConfig.getFilter) {
					filterInfo.getFilter = filterConfig.getFilter;
				}
				else if (filterConfig.appendFilter) {
					filterInfo.appendFilter = filterConfig.appendFilter;
					filterInfo.appendFilterLogicalOperation = filterConfig.appendFilterLogicalOperation;
				}
				filtersValues[filterConfig.name] = filterInfo;
			}, this);
			return filtersValues;
		}

		function generate(schema) {
			var viewModelConfig = {
				entitySchema: schema.entitySchema,
				config: schema,
				columns: {
				},
				values: {
				},
				methods: {
					getFilters: getFilters,
					prepareFilters: prepareFilters,
					getSelectedLookupValuesPropertyName: getSelectedLookupValuesPropertyName,
					setPeriod: setPeriod,
					setCurrentContact: setCurrentContact,
					clearLookupFilter: clearLookupFilter,
					clearPeriodFilter: clearPeriodFilter,
					periodChanged: periodChanged,
					initialize: initialize,
					applyFilter: applyFilter,
					clearSimpleFilterProperties: clearSimpleFilterProperties,
					addLookupFilter: addLookupFilter,
					editFilter: editLookupFilter,
					subscribeCollectionEvents: subscribeCollectionEvents,
					addFilterValue: addFilterValue,
					addFilterValueByFilterConfig: addFilterValueByFilterConfig,
					addNonPeriodFilterValue: addNonPeriodFilterValue,
					updateButtonCaption: updateButtonCaption,
					getFilterValue: getFilterValue
				}
			};
			BPMSoft.each(schema.filters, function(filterConfig) {
				if (filterConfig.dataValueType === BPMSoft.DataValueType.DATE) {
					var periodConfig = schema.getPeriodFilterConfig(filterConfig);
					var startDateColumn = generateViewModelColumn(periodConfig.startDateColumnName);
					viewModelConfig.values[periodConfig.startDateColumnName] = periodConfig.startDateDefValue;
					viewModelConfig.columns[periodConfig.startDateColumnName] = startDateColumn;
					var dueDateColumn = generateViewModelColumn(periodConfig.dueDateColumnName);
					viewModelConfig.columns[dueDateColumn.name] = dueDateColumn;
					viewModelConfig.values[periodConfig.dueDateColumnName] = periodConfig.dueDateDefValue;
					if (periodConfig.singleColumn) {
						dueDateColumn.dataValueType = BPMSoft.DataValueType.DATE;
						dueDateColumn.type = BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN;
					}
				}
				else {
					var column = generateViewModelColumn(filterConfig.name, filterConfig.columnName);
					viewModelConfig.columns[column.name] = column;
					if (filterConfig.dataValueType === BPMSoft.DataValueType.LOOKUP ||
						filterConfig.dataValueType === BPMSoft.DataValueType.ENUM) {
						column.referenceSchemaName = filterConfig.referenceSchemaName ||
							schema.entitySchema.columns[filterConfig.columnName].referenceSchemaName;
						viewModelConfig.values[column.name + 'List'] = new BPMSoft.Collection();
						var selectedValuesCollection = new BPMSoft.Collection();
						viewModelConfig.values[getSelectedLookupValuesPropertyName(column.name)] =
							selectedValuesCollection;
						column.isLookup = true;
						var lookupListColumnConfig = {
							type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
							name: column.name + 'List',
							isCollection: true
						};
						viewModelConfig.columns[lookupListColumnConfig.name] = lookupListColumnConfig;
						if (filterConfig.prepareList) {
							viewModelConfig.methods['get' + lookupListColumnConfig.name] = filterConfig.prepareList;
						}
						var buttonCaptionColumnConfig = {
							type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
							name: filterConfig.name + 'ButtonCaption'
						};
						if (filterConfig.filter) {
							viewModelConfig.values[filterConfig.name + 'LookupFilter'] = filterConfig.filter();
						}
						viewModelConfig.columns[buttonCaptionColumnConfig.name] = buttonCaptionColumnConfig;
						viewModelConfig.values[buttonCaptionColumnConfig.name] = filterConfig.caption;
						viewModelConfig.values[filterConfig.name + 'Views'] = new BPMSoft.Collection();
					}
				}
			}, this);
			return viewModelConfig;
		}

		function generateFilterViewModelConfig() {
			return {
				columns: {
					displayValue: {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						name: 'displayValue'
					},
					filterName: {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						name: 'filterName'
					}
				},
				values: {
					name: null,
					value: null,
					view: null
				},
				methods: {
				}
			};
		}

		function initialize() {
			this.suspendUpdate = true;
			var currentFilter = this.get('currentFilterName');
			this.clearSimpleFilterProperties();
			var addedFilter = this.getAddedFixedFilter();
			var filterState = this.getFilterState('Fixed');
			BPMSoft.each(this.config.filters, function(filterInfo) {
				var value;
				if (filterInfo.name === 'Owner') {
					if (filterInfo.addOwnerCaption) {
						this.set('addOwnerCaption', filterInfo.addOwnerCaption);
					} else {
						this.set('addOwnerCaption', resources.localizableStrings.AddOwnerCaption);
					}
				}
				if (filterInfo.dataValueType === BPMSoft.DataValueType.LOOKUP ||
					filterInfo.dataValueType === BPMSoft.DataValueType.ENUM) {
					this.subscribeCollectionEvents(filterInfo.name);

					if (filterState && filterState[filterInfo.name]) {
						value = filterState[filterInfo.name];
					} else if (filterInfo.defValue) {
						value = filterInfo.defValue;
					}
				} else if (filterState && filterState[filterInfo.name]) {
					value = filterState[filterInfo.name];
				}
				if (Ext.isArray(value)) {
					BPMSoft.each(value, function(currentValue) {
						this.addFilterValueByFilterConfig(filterInfo, currentValue);
					}, this);
				}
				else if (value) {
					this.addFilterValueByFilterConfig(filterInfo, value);
				}
			}, this);
			if (addedFilter) {
				this.set('currentFilterName', addedFilter.currentFilter);
				BPMSoft.each(addedFilter.values, function(currentValue) {
					this.addNonPeriodFilterValue(addedFilter.columnName, currentValue);
				}, this);
				this.clearSimpleFilterProperties();
			}
			this.suspendUpdate = false;
		}

		function subscribeCollectionEvents(filterName) {
			var selectedValues = this.get(getSelectedLookupValuesPropertyName(filterName));
			selectedValues.on('dataLoaded', function() {
				var filtersViews = this.get(filterName + 'Views');
				selectedValues.each(function(filterViewModel) {
					filtersViews.add(filterViewModel.get('filterName'), filterViewModel.get('view'));
				});
				this.updateButtonCaption(filterName);
			}, this);
			selectedValues.on('add', function(filterViewModel) {
				var filtersViews = this.get(filterName + 'Views');
				filtersViews.add(filterViewModel.get('filterName'), filterViewModel.get('view'));
				this.updateButtonCaption(filterName);
			}, this);
			selectedValues.on('remove', function(filterViewModel) {
				var filtersViews = this.get(filterName + 'Views');
				var view = filtersViews.removeByKey(filterViewModel.get('filterName'));
				view.destroy();
				this.updateButtonCaption(filterName);
			}, this);
			selectedValues.on('clear', function() {
				var filtersViews = this.get(filterName + 'Views');
				filtersViews.each(function(view) {
					view.destroy();
				});
				filtersViews.clear();
				this.updateButtonCaption(filterName);
			}, this);
		}

		function addNonPeriodFilterValue(tag, simpleFilterValue) {
			var selectedValues = this.get(getSelectedLookupValuesPropertyName(tag));
			var oldFilterName = this.get('currentFilterName');
			var filterName = 'fixedFilter' + tag + simpleFilterValue.value;
			if (oldFilterName && filterName !== oldFilterName) {
				selectedValues.removeByKey(oldFilterName);
			}
			var simpleFilter = selectedValues.find(filterName);
			if (!simpleFilter) {
				var config = generateFilterViewModelConfig();
				simpleFilter = this.getFilterViewModel(tag, filterName, config);
				simpleFilter.set('name', tag);
				simpleFilter.set('filterName', filterName);
				simpleFilter.set('value', simpleFilterValue.value);
				simpleFilter.set('displayValue', simpleFilterValue.displayValue);
				selectedValues.add(filterName, simpleFilter);
				this.filterChanged();
			}
		}

		function applyFilter(a1, a2, a3, tag) {
			var simpleFilterValue = this.get(tag);
			if (simpleFilterValue) {
				this.addNonPeriodFilterValue(tag, simpleFilterValue);
			}
			this.destroySimpleFilterEdit();
		}

		function clearSimpleFilterProperties(tag) {
			this.set(tag, null);
			this.set('currentFilterName', null);
		}

		function setPeriod(tag) {
			if (!tag) {
				return;
			}
			var indexOfSeparator = tag.lastIndexOf('_');
			if (indexOfSeparator === -1) {
				return;
			}
			var filterName = tag.substring(0, indexOfSeparator);
			var periodName = tag.substring(indexOfSeparator + 1);
			var periodFilterConfig;
			BPMSoft.each(this.config.filters, function(filterConfig) {
				if (filterConfig.name === filterName) {
					periodFilterConfig = this.config.getPeriodFilterConfig(filterConfig);
				}
			}, this);
			if (!periodFilterConfig) {
				return;
			}
			var startDate = new Date();
			var dueDate;
			switch (periodName) {
				case 'Yesterday':
					startDate = BPMSoft.startOfDay(Ext.Date.add(startDate, 'd', -1));
					dueDate = BPMSoft.endOfDay(startDate);
					break;
				case 'Tomorrow':
					startDate = BPMSoft.startOfDay(Ext.Date.add(startDate, 'd', 1));
					dueDate = BPMSoft.endOfDay(startDate);
					break;
				case 'PastWeek':
					startDate = BPMSoft.startOfWeek(Ext.Date.add(startDate, 'd', -7));
					dueDate = BPMSoft.endOfWeek(startDate);
					break;
				case 'CurrentWeek':
					startDate = BPMSoft.startOfWeek(startDate);
					dueDate = BPMSoft.endOfWeek(startDate);
					break;
				case 'NextWeek':
					startDate = BPMSoft.startOfWeek(Ext.Date.add(startDate, 'd', 7));
					dueDate = BPMSoft.endOfWeek(startDate);
					break;
				case 'PastMonth':
					startDate = BPMSoft.startOfMonth(Ext.Date.add(startDate, 'mo', -1));
					dueDate = BPMSoft.endOfMonth(startDate);
					break;
				case 'CurrentMonth':
					startDate = BPMSoft.startOfMonth(startDate);
					dueDate = BPMSoft.endOfMonth(startDate);
					break;
				case 'NextMonth':
					startDate = BPMSoft.startOfMonth(Ext.Date.add(startDate, 'mo', 1));
					dueDate = BPMSoft.endOfMonth(startDate);
					break;
				default:
					startDate = BPMSoft.startOfDay(startDate);
					dueDate = BPMSoft.endOfDay(startDate);
					break;
			}
			this.suspendUpdate = true;
			this.set(periodFilterConfig.startDateColumnName, startDate);
			this.set(periodFilterConfig.dueDateColumnName, dueDate);
			this.suspendUpdate = false;
			if (this.filterChanged) {
				this.filterChanged();
			}
		}

		function periodChanged(value, tag) {
			if (!this.suspendUpdate) {
				var starColumnName = tag.periodConfig.startDateColumnName;
				var dueColumnName = tag.periodConfig.dueDateColumnName;
				var startDate = this.get(starColumnName);
				var dueDate = this.get(dueColumnName);
				if (startDate && dueDate && startDate > dueDate) {
					this.suspendUpdate = true;
					if (tag.currentColumnName === starColumnName) {
						this.set(dueColumnName, value);
					}
					else {
						this.set(starColumnName, value);
					}
					this.suspendUpdate = false;
				}
				if (this.filterChanged) {
					this.filterChanged();
				}
			}
		}

		function setCurrentContact(tag) {
			if (!tag) {
				return;
			}
			var filters = this.get(getSelectedLookupValuesPropertyName(tag));
			filters.clear();
			this.addNonPeriodFilterValue(tag, BPMSoft.SysValue.CURRENT_USER_CONTACT);
		}

		function clearLookupFilter(tag) {
			if (!tag) {
				return;
			}

			var filters = this.get(getSelectedLookupValuesPropertyName(tag));
			filters.clear();
			this.filterChanged();
		}

		function generateViewModelColumn(columnName, columnPath) {
			return {
				type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
				name: columnName,
				columnPath: columnPath || columnName
			};
		}

		function getSelectedLookupValuesPropertyName(propertyName) {
			return 'Selected' + propertyName + 'List';
		}

		function clearPeriodFilter(a1, a2, a3, tag) {
			var startDate = this.get(tag.startDateColumnName);
			var dueDate = this.get(tag.dueDateColumnName);
			if (startDate || dueDate) {
				this.suspendUpdate = true;
				this.set(tag.startDateColumnName, null);
				this.set(tag.dueDateColumnName, null);
				this.suspendUpdate = false;
				if (this.filterChanged) {
					this.filterChanged();
				}
			}
		}

		function updateButtonCaption(filterName) {
			var filterInfo;
			BPMSoft.each(this.config.filters, function(filterConfig) {
				if (filterConfig.name === filterName) {
					filterInfo = filterConfig;
				}
			}, this);
			if (filterInfo) {
				var selectedCollection = this.get(getSelectedLookupValuesPropertyName(filterInfo.name));
				if (!selectedCollection || selectedCollection.collection.length === 0) {
					this.set(filterName + 'ButtonCaption', filterInfo.caption);
					return;
				}
			}
			this.set(filterName + 'ButtonCaption', '');
		}

		function addLookupFilter(filterName) {
			//this.showSimpleFilterEdit(filterName);
			this.lookupSelecting(filterName);
		}

		function editLookupFilter(filterName, tag) {
			this.lookupSelecting(filterName, tag);
//			var filters = this.get(getSelectedLookupValuesPropertyName(filterName));
//			var filterViewModel = filters.find(tag);
//			if (filterViewModel) {
//				var value = {
//					value: filterViewModel.get('value'),
//					displayValue: filterViewModel.get('displayValue')
//				};
//				this.set('currentFilterName', tag);
//				this.set(filterName, value);
//				this.showSimpleFilterEdit(filterName);
//			}
		}

		function getFilterValue(filterName) {
			var result = {};
			BPMSoft.each(this.config.filters, function(filterConfig) {
				var filterValue;
				if (!filterName || filterConfig.name === filterName) {
					if (filterConfig.dataValueType === BPMSoft.DataValueType.DATE) {
						var periodConfig = this.config.getPeriodFilterConfig(filterConfig);
						var startDate = this.get(periodConfig.startDateColumnName);
						var dueDate = this.get(periodConfig.dueDateColumnName);
						filterValue = {
							startDate: startDate,
							dueDate: dueDate
						};
					} else if (filterConfig.dataValueType === BPMSoft.DataValueType.LOOKUP ||
						filterConfig.dataValueType === BPMSoft.DataValueType.ENUM) {
						var values = this.get(getSelectedLookupValuesPropertyName(filterConfig.name));
						filterValue = [];
						values.each(function(value) {
							filterValue.push({
								value: value.get('value'),
								displayValue: value.get('displayValue')
							});
						}, this);
					} else {
						filterValue = this.get(filterConfig.name);
					}
					if (filterName) {
						result = filterValue;
					} else {
						result[filterConfig.name] = filterValue;
					}
				}
			}, this);
			return result;
		}

		function addFilterValueByFilterConfig(filterConfig, filterValue) {
			if (filterConfig.dataValueType === BPMSoft.DataValueType.DATE) {
				var periodConfig = this.config.getPeriodFilterConfig(filterConfig);
				this.set(periodConfig.startDateColumnName, filterValue.startDate);
				this.set(periodConfig.dueDateColumnName, filterValue.dueDate);
			} else {
				if (!Ext.isArray(filterValue)) {
					this.addNonPeriodFilterValue(filterConfig.name, filterValue);
				} else {
					BPMSoft.each(filterValue, function(val) {
						this.addNonPeriodFilterValue(filterConfig.name, val);
					}, this);
				}
			}
		}

		function addFilterValue(filterName, filterValue) {
			var filterChanged = false;
			var updateSuspended = this.suspendUpdate;
			this.suspendUpdate = true;
			BPMSoft.each(this.config.filters, function(filterConfig) {
				if (filterConfig.name === filterName) {
					filterChanged = true;
					this.addFilterValueByFilterConfig(filterConfig, filterValue);
				}
			}, this);
			this.suspendUpdate = updateSuspended;
			if (filterChanged && this.filterChanged) {
				this.filterChanged();
			}
		}

		return {
			generate: generate
		};

	});
