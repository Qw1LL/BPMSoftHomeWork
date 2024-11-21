define("DcmUtilities", ["RightUtilities", "SectionManager", "DcmSchemaManager", "SysDcmSettingsManager",
	"FilterUtilities"], function(rightUtilities) {
	Ext.define("BPMSoft.configuration.DcmUtilities", {
		extend: "BPMSoft.BaseObject",
		alternateClassName: "BPMSoft.DcmUtilities",
		singleton: true,

		//region Methods: Private

		/**
		 * Returns SysDcmSettings manager item.
		 * @private
		 * @param {BPMSoft.configuration.BaseSchemaViewModel} viewModel Page view model.
		 * @return {BPMSoft.manager.SysDcmSettingsManagerItem/null}
		 */
		findSysDcmSettingsItem: function(viewModel) {
			const moduleStructure = viewModel.getModuleStructure();
			if (!moduleStructure) {
				return null;
			}
			const sectionManagerItem = BPMSoft.SectionManager.findItem(moduleStructure.moduleId);
			if (!sectionManagerItem) {
				return null;
			}
			const sysModuleEntityId = sectionManagerItem.getSysModuleEntityId();
			return BPMSoft.SysDcmSettingsManager.findBySysModuleEntityId(sysModuleEntityId);
		},

		/**
		 * Returns entity schema query for running dcm processes.
		 * @private
		 * @param {String} recordId Current record identifier.
		 * @param {String} entitySchemaUId Entity schema identifier.
		 * @return {BPMSoft.EntitySchemaQuery}
		 */
		getRunningProcessesEsq: function(recordId, entitySchemaUId) {
			const esq = Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: "SysEntityCommonPrcEl",
				rowCount: 1
			});
			esq.addColumn("ProcessElement.SysProcess.SysSchema.UId", "UId");
			esq.addColumn("ProcessElement.SysProcess.SysSchema.Name", "Name");
			esq.filters.addItem(BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
				"RecordId", recordId, BPMSoft.DataValueType.GUID));
			esq.filters.addItem(BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
				"EntitySchemaUId", entitySchemaUId, BPMSoft.DataValueType.GUID));
			esq.filters.addItem(BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
				"ProcessElement.SysProcess.SysSchema.ManagerName", "DcmSchemaManager"));
			return esq;
		},

		/**
		 * Returns running dcm process instances identifiers for current record.
		 * @private
		 * @param {String} recordId Current record identifier.
		 * @param {String} entitySchemaUId Entity schema identifier.
		 * @param {Function} callback The callback function.
		 * @param {BPMSoft.DcmSchemaManagerItem} callback.item Dcm schema manager item.
		 * @param {Object} scope The scope of callback function.
		 */
		_getRunningProcesses: function(recordId, entitySchemaUId, callback, scope) {
			if (!BPMSoft.Features.getIsEnabled('UseDcmServerEndPoint')) {
				const esq = this.getRunningProcessesEsq(recordId, entitySchemaUId);
				esq.getEntityCollection(function(result) {
					let managerItem = null;
					result.collection.each(function(record) {
						const uId = record.get('UId');
						const item = BPMSoft.DcmSchemaManager.findItem(uId);
						const itemEntitySchemaUId = item.getEntitySchemaUId();
						if (entitySchemaUId === itemEntitySchemaUId) {
							managerItem = item;
							return false;
						}
					}, this);
					callback.call(scope, managerItem);
				}, this);
			} else {
				const request = new BPMSoft.ParametrizedRequest({
					contractName: 'DcmRunningProcessRequest',
					config: {
						recordId: recordId,
						entitySchemaUId: entitySchemaUId
					}
				});
				request.execute(function(result) {
					let managerItem = null;
					if (result.rowsAffected === 1) {
						const uId = result.UId;
						const item = BPMSoft.DcmSchemaManager.findItem(uId);
						const itemEntitySchemaUId = item.getEntitySchemaUId();
						if (entitySchemaUId === itemEntitySchemaUId) {
							managerItem = item;
						}
					}
					callback.call(scope, managerItem);
				}, scope);
			}
		},

		/**
		 * Returns running dcm schema manager item for existing entity record.
		 * @private
		 * @param {BPMSoft.configuration.BaseSchemaViewModel} viewModel Page view model.
		 * @param {Function} callback The callback function.
		 * @param {BPMSoft.manager.DcmSchemaManagerItem} callback.item Actual DcmSchemaManager item.
		 * @param {Object} scope The scope of callback function.
		 */
		findRunningDcmSchemaManagerItem: function(viewModel, callback, scope) {
			const sysDcmSettingsItem = this.findSysDcmSettingsItem(viewModel);
			const recordId = viewModel.get("Id");
			if (sysDcmSettingsItem && recordId) {
				const entitySchemaUId = sysDcmSettingsItem.getEntitySchemaUId();
				this._getRunningProcesses(recordId, entitySchemaUId, callback, scope);
			} else {
				callback.call(scope, null);
			}
		},

		/**
		 * Returns collection of active dcm schema manager items for section.
		 * @private
		 * @param {string} sectionEntitySchemaUId Section entity schema uId.
		 * @return {BPMSoft.Collection}
		 */
		getSectionDcmSchemaManagerItems: function(sectionEntitySchemaUId) {
			return BPMSoft.DcmSchemaManager.filterByFn(function(dcmSchemaManagerItem) {
				const isSchemaActive = dcmSchemaManagerItem.getIsActive();
				const dcmEntitySchemaUId = dcmSchemaManagerItem.getEntitySchemaUId();
				return isSchemaActive && dcmEntitySchemaUId === sectionEntitySchemaUId;
			}, this);
		},

		/**
		 * Returns flag that indicates whether the viewModel match dcm schema filters.
		 * @private
		 * @param {BPMSoft.manager.DcmSchemaManagerItem} dcmSchemaManagerItem Dcm schema manager item.
		 * @param {BPMSoft.configuration.BaseSchemaViewModel} viewModel Page view model.
		 * @return {Boolean}
		 */
		getIsViewModelMatchDcmSchemaFilters: function(dcmSchemaManagerItem, viewModel) {
			const dcmSchemaFiltersGroup = dcmSchemaManagerItem.getFilterGroup();
			if (!dcmSchemaFiltersGroup || dcmSchemaFiltersGroup.isEmpty()) {
				return true;
			}
			const dcmSchemaFilters = dcmSchemaFiltersGroup.getItems();
			return _.every(dcmSchemaFilters, function(filterItem) {
				return this.checkFilter(filterItem, viewModel);
			}, this);
		},

		/**
		 * Returns flag that indicates whether the viewModel match filter item.
		 * @private
		 * @param {BPMSoft.data.filters.BaseFilter} filterItem Filter item.
		 * @param {BPMSoft.configuration.BaseSchemaViewModel} viewModel Page view model.
		 * @return {Boolean}
		 */
		checkFilter: function(filterItem, viewModel) {
			if (filterItem.isEnabled !== true) {
				return false;
			}
			switch (filterItem.filterType) {
				case BPMSoft.FilterType.IN:
					return this.checkInFilter(filterItem, viewModel);
				case BPMSoft.FilterType.IS_NULL:
					return this.checkIsNullFilter(filterItem, viewModel);
				default:
					return false;
			}
		},

		/**
		 * Returns view model column by filter left expression column path.
		 * @private
		 * @param {BPMSoft.configuration.BaseSchemaViewModel} viewModel Page view model.
		 * @param {BPMSoft.data.filters.BaseFilter} filterItem Filter item.
		 * @return {Object}
		 */
		getViewModelColumnByFilterItem: function(viewModel, filterItem) {
			const columnPath = filterItem.leftExpression.columnPath;
			return  this.getViewModelColumnByPath(viewModel, columnPath);
		},

		/**
		 * Returns view model column by column path.
		 * @param {BPMSoft.configuration.BaseSchemaViewModel} viewModel Page view model.
		 * @param {string} columnPath Column path.
		 * @return {Object}
		 */
		getViewModelColumnByPath: function(viewModel, columnPath) {
			let foundColumn = null;
			BPMSoft.each(viewModel.columns, function(column) {
				if (column.columnPath === columnPath) {
					foundColumn = column;
				}
				return foundColumn == null;
			});
			return foundColumn;
		},

		/**
		 * Returns flag that indicates whether the viewModel match InFilter.
		 * @private
		 * @param {BPMSoft.data.filters.InFilter} filterItem Filter item.
		 * @param {BPMSoft.configuration.BaseSchemaViewModel} viewModel Page view model.
		 * @return {Boolean}
		 */
		checkInFilter: function(filterItem, viewModel) {
			const column = this.getViewModelColumnByFilterItem(viewModel, filterItem);
			if (!column) {
				return false;
			}
			const columnDataValueType = column.dataValueType;
			const columnValue = viewModel.get(column.name);
			const viewModelColumnValue = this.getPrimitiveValue(columnDataValueType, columnValue);
			return BPMSoft.some(filterItem.rightExpressions, function (rightExpression) {
				const filterParameter = rightExpression.parameter;
				if (filterParameter.dataValueType !== columnDataValueType) {
					return false;
				}
				return this.compareFilterParameterValue(viewModelColumnValue, filterParameter);
			}, this);
		},

		/**
		 * Returns flag that indicates whether the viewModel match IsNullFilter.
		 * @private
		 * @param {BPMSoft.data.filters.IsNullFilter} filterItem Filter item.
		 * @param {BPMSoft.configuration.BaseSchemaViewModel} viewModel Page view model.
		 * @return {Boolean}
		 */
		checkIsNullFilter: function(filterItem, viewModel) {
			const column = this.getViewModelColumnByFilterItem(viewModel, filterItem);
			if (!column) {
				return false;
			}
			const columnValue = viewModel.get(column.name);
			const viewModelColumnValue = this.getPrimitiveValue(column.dataValueType, columnValue);
			return viewModelColumnValue == null;
		},

		/**
		 * Compare filter parameter value with passed value.
		 * @private
		 * @param {Object} value Value to compare with filter.
		 * @param {BPMSoft.data.filters.Parameter} filterParameter Filter parameter.
		 * @return {Boolean}
		 */
		compareFilterParameterValue: function(value, filterParameter) {
			const filterValue = filterParameter.getValue();
			const filterParameterValue = this.getPrimitiveValue(filterParameter.dataValueType, filterValue);
			return filterParameterValue === value;
		},

		/**
		 * Returns primitive value by data value type.
		 * @private
		 * @param {BPMSoft.core.enums.DataValueType} dataValueType Data value type.
		 * @param {Object} value Value.
		 * @return {Object|null}
		 */
		getPrimitiveValue: function(dataValueType, value) {
			if (!value) {
				return null;
			}
			const isLookup = BPMSoft.isLookupDataValueType(dataValueType);
			return isLookup ? value.value : value;
		},

		/**
		 * Initialize managers.
		 * @private
		 * @param {Function} callback callback function.
		 */
		initializeManagers: function(callback) {
			const managers = [
				BPMSoft.SectionManager,
				BPMSoft.SysModuleEntityManager,
				BPMSoft.DcmSchemaManager,
				BPMSoft.SysDcmSettingsManager
			];
			BPMSoft.eachAsyncAll(managers, function(manager, next) {
				manager.initialize(next, this);
			}, callback, this);
		},

		/**
		 * Returns flag that indicates if section has any enabled dcm schema.
		 * @private
		 * @param {BPMSoft.configuration.BaseSchemaViewModel} viewModel Section or page view model.
		 */
		getHasAnyDcmSchema: function(viewModel) {
			let result = false;
			const sysDcmSettingsItem = this.findSysDcmSettingsItem(viewModel);
			if (sysDcmSettingsItem) {
				const entitySchemaUId = sysDcmSettingsItem.getEntitySchemaUId();
				result = !this.getSectionDcmSchemaManagerItems(entitySchemaUId).isEmpty();
			}
			return result;
		},

		//endregion

		//region Methods: Public

		/**
		 * Check rights for operation CanManageDcm.
		 * @param {Function} callback Callback method.
		 * @param {Boolean} callback.canManageDcm Flag that indicates whether the user has
		 * appropriate rights to manage dcm.
		 * @param {Object} scope Callback method context.
		 */
		checkCanManageDcmRights: function(callback, scope) {
			rightUtilities.checkCanExecuteOperation({"operation": "CanManageDcm"}, callback, scope);
		},

		/**
		 * Returns actual dcm schema uId for section or page view model.
		 * @param {BPMSoft.configuration.BaseSchemaViewModel} viewModel Section or page view model.
		 * @param {Function} callback Callback function.
		 * @param {string} callback.dcmSchemaUId Actual dcm schema uId.
		 * @param {Boolean} callback.hasAnyDcmSchema Flag that indicates if section has any enabled dcm schema.
		 * @param {Object} scope Callback function call context.
		 */
		getActualDcmSchemaUId: function(viewModel, callback, scope) {
			BPMSoft.chain(
				this.initializeManagers,
				function() {
					const dcmSchemaManagerItem = this.findActualDcmSchemaManagerItem(viewModel);
					const dcmSchemaUId = dcmSchemaManagerItem ? dcmSchemaManagerItem.getUId() : null;
					if (dcmSchemaUId) {
						callback.call(scope, dcmSchemaUId, true);
					} else {
						callback.call(scope, dcmSchemaUId, this.getHasAnyDcmSchema(viewModel));
					}
				},
				this
			);
		},

		/**
		 * Returns an array of column names by which SysDcmSettings filters were built.
		 * @param {BPMSoft.configuration.BaseSchemaViewModel} viewModel Section or page view model.
		 * @param {Function} callback Callback function.
		 * @param {string[]} callback.dcmSchemaUId Array of column names.
		 * @param {Object} scope Callback function call context.
		 */
		getFilteredColumns: function(viewModel, callback, scope) {
			const entitySchema = viewModel.entitySchema;
			if (!entitySchema) {
				callback.call(scope, []);
				return;
			}
			BPMSoft.chain(
				this.initializeManagers,
				function() {
					const sysDcmSettingsItem = this.findSysDcmSettingsItem(viewModel);
					const filteredColumns = [];
					if (sysDcmSettingsItem) {
						const filters = sysDcmSettingsItem.getFilters();
						filters.forEach(function(filter) {
							const entitySchemaColumn = entitySchema.findColumnByUId(filter.columnUId);
							if (!entitySchemaColumn) {
								return;
							}
							const viewModelColumn = this.getViewModelColumnByPath(viewModel, entitySchemaColumn.name);
							filteredColumns.push(viewModelColumn.name);
						}, this);
					}
					callback.call(scope, filteredColumns);
				}, this);
		},

		/**
		 * @deprecated
		 */
		getIsDcmDesignerAvailable: function(viewModel, callback, scope) {
			if (!viewModel.entitySchema) {
				callback.call(scope, false);
				return;
			}
			this.checkCanManageDcmRights(callback, scope);
		},

		/**
		 * Returns running dcm schema identifier for existing entity record.
		 * @param {BPMSoft.configuration.BaseSchemaViewModel} viewModel Page view model.
		 * @param {Function} callback The callback function.
		 * @param {BPMSoft.manager.DcmSchemaManagerItem} callback.schemaUId Running dcm schema identifier.
		 * @param {Boolean} callback.isActive Flag that indicates dcm schema active state.
		 * @param {Object} scope The scope of callback function.
		 */
		findRunningDcmSchemaUId: function(viewModel, callback, scope) {
			if (viewModel.isNewMode()) {
				callback.call(scope, null);
				return;
			}
			BPMSoft.chain(
				this.initializeManagers,
				function(next) {
					this.findRunningDcmSchemaManagerItem(viewModel, next, this);
				},
				function(next, item) {
					let isActive = false;
					let schemaUId = null;
					if (item) {
						schemaUId = item.getUId();
						isActive = item.getIsActive();
					}
					callback.call(scope, schemaUId, isActive);
				},
				this
			);
		},

		/**
		 * Returns actual dcmSchemaManager item for page view model.
		 * If section has no SysDcmSettings records, returns null.
		 * @param {BPMSoft.configuration.BaseSchemaViewModel} viewModel Page view model.
		 * @return {BPMSoft.manager.DcmSchemaManagerItem/null}
		 */
		findActualDcmSchemaManagerItem: function(viewModel) {
			const sysDcmSettingsItem = this.findSysDcmSettingsItem(viewModel);
			if (!sysDcmSettingsItem) {
				return null;
			}
			const entitySchemaUId = sysDcmSettingsItem.getEntitySchemaUId();
			const dcmSchemaManagerItems = this.getSectionDcmSchemaManagerItems(entitySchemaUId).getItems();
			const actualManagerItem = _.find(dcmSchemaManagerItems, function (dcmSchemaManagerItem) {
				const isActualVersion = BPMSoft.DcmSchemaManager.getCanUseProcessVersions()
					? dcmSchemaManagerItem.isActiveVersion
					: true;
				return this.getIsViewModelMatchDcmSchemaFilters(dcmSchemaManagerItem, viewModel) && isActualVersion;
			}, this);
			return actualManagerItem;
		},

		/**
		 * Returns whether view model has dcm schema.
		 * @param {BPMSoft.configuration.BaseSchemaViewModel} viewModel Page view model.
		 * @param {Function} callback The callback function.
		 * @param {Boolean} callback.result Flag that indicates whether view model has dcm schema or not.
		 * @param {Object} scope The scope of callback function.
		 */
		hasAnyDcmSchema: function(viewModel, callback, scope) {
			const enitySctructure = viewModel.entitySchema && viewModel.getEntityStructure();
			const entitySchemaUId = enitySctructure && enitySctructure.entitySchemaUId;
			if (!entitySchemaUId) {
				return callback.call(scope, false);
			}
			BPMSoft.chain(
				function(next) {
					BPMSoft.DcmSchemaManager.initialize(next, this);
				},
				function() {
					const dcmItem = BPMSoft.DcmSchemaManager.findByFn(function (item) {
						return item.getIsActive() && item.getEntitySchemaUId() === entitySchemaUId;
					}, this);
					const result = viewModel.isNotEmpty(dcmItem);
					callback.call(scope, result);
				}, this
			);
		},

		/**
		 * @private
		 */
		_updateStageFilterCaptions: function(filters, stageEntitySchema) {
			BPMSoft.each(filters, function(filter) {
				const item = BPMSoft.EntitySchemaManager.findItemByName(filter.referenceSchemaName);
				if (item) {
					const stageColumn = stageEntitySchema.columns.findByFn(function(column) {
						return column.referenceSchemaUId === item.uId;
					}, this);
					filter.leftExpressionCaption = stageColumn && stageColumn.caption.getValue() ||
						filter.leftExpressionCaption;
				}
			}, this);
		},

		/**
		 * Returns stage filters display value.
		 * @param {BPMSoft.data.filters.FilterGroup} filters Stage filters.
		 * @param {BPMSoft.manager.EntitySchema} stageEntitySchema Stage entity schema.
		 */
		getStageFiltersDisplayValue: function(filters, stageEntitySchema) {
			this._updateStageFilterCaptions(filters, stageEntitySchema);
			return BPMSoft.FilterUtilities.getExtendedFilterDisplayValue(filters);
		},

		/**
		 * Returns stage column display name.
		 * @param {GUID} stageColumnUId Stage column unique identifier.
		 * @param {GUID} entitySchemaUId Stage entity schema unique identifier.
		 * @param {Function} callback Callback.
		 * @param {Object} scope Callback scope.
		 */
		getStageColumnDisplayName: function(stageColumnUId, entitySchemaUId, callback, scope) {
			if (!stageColumnUId || !entitySchemaUId) {
				return;
			}
			BPMSoft.chain(
				function(next) {
					BPMSoft.PackageManager.getCustomPackageUId(next, this);
				},
				function(next, packageUId) {
					BPMSoft.EntitySchemaManager.findBundleSchemaInstance({
						schemaUId: entitySchemaUId,
						packageUId: packageUId
					}, next, this);
				},
				function(next, schema) {
					const column = schema && schema.columns.find(stageColumnUId);
					const columnCaption = column && column.caption.getValue();
					const columnName = column && column.name;
					Ext.callback(callback, scope, [columnCaption || columnName || stageColumnUId]);
				}, this
			);
		}

		//endregion

	});
});
