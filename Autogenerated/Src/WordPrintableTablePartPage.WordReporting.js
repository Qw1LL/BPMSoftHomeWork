define("WordPrintableTablePartPage", ["WordPrintableTablePartPageResources", "ColumnSettingsUtilities",
			"StructureExplorerUtilitiesV2", "css!WordPrintableTablePartPageCSS", "ConfigurationConstants"],
		function(resources, ColumnSettingsUtilities) {
			return {
				entitySchemaName: "SysModuleReportTable",
				messages: {
					GetTablePartDefaultValues: {
						direction: BPMSoft.MessageDirectionType.PUBLISH,
						mode: BPMSoft.MessageMode.PTP
					},
					GetTablePartById: {
						direction: BPMSoft.MessageDirectionType.PUBLISH,
						mode: BPMSoft.MessageMode.PTP
					},
					SaveTablePart: {
						direction: BPMSoft.MessageDirectionType.PUBLISH,
						mode: BPMSoft.MessageMode.PTP
					},
					GetFilterModuleConfig: {
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE,
						mode: BPMSoft.MessageMode.PTP
					},
					OnFiltersChanged: {
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE,
						mode: BPMSoft.MessageMode.BROADCAST
					},
					SetFilterModuleConfig: {
						direction: BPMSoft.MessageDirectionType.PUBLISH,
						mode: BPMSoft.MessageMode.BROADCAST
					},
					GetMacrosListDetailInfo: {
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE,
						mode: BPMSoft.MessageMode.PTP
					},
					RootEntitySchemaChanged: {
						direction: BPMSoft.MessageDirectionType.PUBLISH,
						mode: BPMSoft.MessageMode.PTP
					},
					ReinitializeMacrosList: {
						direction: BPMSoft.MessageDirectionType.PUBLISH,
						mode: BPMSoft.MessageMode.PTP
					},
					MacrosListChanged: {
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE,
						mode: BPMSoft.MessageMode.PTP
					},
					OpenMacrosSettingsPage: {
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE,
						mode: BPMSoft.MessageMode.PTP
					},
					SetMacrosSettings: {
						direction: BPMSoft.MessageDirectionType.PUBLISH,
						mode: BPMSoft.MessageMode.PTP
					},
					ColumnSettingsInfo: {
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE,
						mode: BPMSoft.MessageMode.PTP
					},
					ColumnSetuped: {
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE,
						mode: BPMSoft.MessageMode.PTP
					}
				},
				attributes: {
					Caption: {
						caption: resources.localizableStrings.CaptionLabel
					},
					IsEmptyTableHide: {
						caption: resources.localizableStrings.IsEmptyTableHideLabel
					},
					MainObjectName: {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.TEXT
					},
					TableObject: {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.LOOKUP,
						caption: resources.localizableStrings.TableObjectLabel,
						isRequired: true,
						referenceSchemaName: "VwSysSchemaInfo",
						lookupConfig: {
							actionsButtonVisible: false,
							settingsButtonVisible: false,
							isColumnSettingsHidden: true
						},
						lookupListConfig: {
							columns: ["Name"],
							filter: function() {
								const filters = Ext.create("BPMSoft.FilterGroup");
								filters.addItem(BPMSoft.createColumnFilterWithParameter(
										BPMSoft.ComparisonType.EQUAL, "SysWorkspace.Id", BPMSoft.SysValue.CURRENT_WORKSPACE.value));
								filters.addItem(BPMSoft.createColumnFilterWithParameter(
										BPMSoft.ComparisonType.EQUAL, "ManagerName", "EntitySchemaManager"));
								return filters;
							}
						}
					},
					MainObjectColumn: {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.LOOKUP,
						caption: resources.localizableStrings.MainObjectColumnLabel,
						isRequired: true
					},
					TableObjectColumn: {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.LOOKUP,
						caption: resources.localizableStrings.TableObjectColumnLabel,
						isRequired: true
					},
					TableObjectMacrosList: {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
					},
					TryCompleteInitialization: {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
					}
				},
				methods: {

					// region Methods: Private

					_canUse7xFilters: function() {
						return BPMSoft.Features.getIsEnabled("Use7xFiltersForWordReports");
					},

					getLogoImageConfig: function() {
						const config = {
							params: {
								r: "MenuLogoImage"
							},
							source: this.BPMSoft.ImageSources.SYS_SETTING
						};
						return this.BPMSoft.ImageUrlBuilder.getUrl(config);
					},
					
					_getMacrosSettingsColumnName: function() {
						return this._canUse7xFilters() ? "MacrosSettings": "MacrosList";
					},

					_getFilterSettingsColumnName: function() {
						return this._canUse7xFilters() ? "FilterSettings": "Filter";
					},

					/**
					 * @return {String}
					 * @private
					 */
					_createSerializedEmptyFilterGroup: function() {
						const filter = Ext.create("BPMSoft.FilterGroup");
						return filter.serialize({serializeFilterManagerInfo: true});
					},

					/**
					 * @param {BPMSoft.FilterGroup} filter1
					 * @param {BPMSoft.FilterGroup} filter2
					 * @return {Boolean}
					 * @private
					 */
					_areFiltersEqual: function(filter1, filter2) {
						const filter1Dto = JSON.parse(filter1.serialize({serializeFilterManagerInfo: false}));
						const filter2Dto = JSON.parse(filter2.serialize({serializeFilterManagerInfo: false}));
						delete filter1Dto.rootSchemaName;
						delete filter2Dto.rootSchemaName;
						return BPMSoft.isEqual(filter1Dto, filter2Dto);
					},

					_isExpressionValueValid: function(dataValueType, expressionValue) {
						let valueIsValid = !Ext.isEmpty(expressionValue);
						switch (dataValueType) {
							case BPMSoft.DataValueType.INTEGER:
							case BPMSoft.DataValueType.FLOAT:
							case BPMSoft.DataValueType.FLOAT1:
							case BPMSoft.DataValueType.FLOAT2:
							case BPMSoft.DataValueType.FLOAT3:
							case BPMSoft.DataValueType.FLOAT4:
							case BPMSoft.DataValueType.MONEY:
								valueIsValid = Ext.isNumeric(expressionValue);
								break;
							case BPMSoft.DataValueType.GUID:
								valueIsValid = BPMSoft.isGUID(expressionValue);
								break;
							case BPMSoft.DataValueType.TEXT:
								valueIsValid = Ext.isString(expressionValue);
								break;
							default:
								break;
						}
						return valueIsValid;
					},

					_isFilterValueValid: function(filterItem) {
						if (!filterItem) {
							return false;
						}
						if (!filterItem.rightExpression && !filterItem.rightExpressions) {
							return true;
						}
						let isValid = true;
						let dataValueType = filterItem.dataValueType;
						let rightExpressionParameterValue;
						if (filterItem.rightExpression) {
							rightExpressionParameterValue = filterItem.rightExpression.parameter &&
									filterItem.rightExpression.parameter.getValue();
							if (!rightExpressionParameterValue && filterItem.rightExpression.functionArgument) {
								rightExpressionParameterValue = filterItem.rightExpression.functionArgument.parameter.value;
								dataValueType = filterItem.rightExpression.functionArgument.parameter.dataValueType;
							}
						}
						if (!BPMSoft.utils.common.isUndefined(rightExpressionParameterValue)) {
							isValid = this._isExpressionValueValid(dataValueType, rightExpressionParameterValue);
						} else {
							if (filterItem.rightExpressions) {
								filterItem.rightExpressions.forEach(function(rightExpression) {
									if (rightExpression instanceof BPMSoft.ParameterExpression) {
										const parameter = rightExpression.parameter;
										const isCurrentExpressionValid =
												this._isExpressionValueValid(dataValueType, parameter.getValue().value);
										if (!isCurrentExpressionValid) {
											const index = filterItem.rightExpressions.indexOf(rightExpression);
											filterItem.rightExpressions.splice(index, 1);
										}
									}
								}, this);
								isValid = filterItem.rightExpressions.length > 0;
							}
						}
						return isValid;
					},

					/**
					 * @param {BPMSoft.FilterGroup} filterGroup
					 * @private
					 */
					_removeUncompletedItemsFromFilterGroup: function(filterGroup) {
						const clonedItems = filterGroup.getItems().concat([]);
						clonedItems.forEach(function(item) {
							if (item.filterType === BPMSoft.FilterType.FILTER_GROUP) {
								this._removeUncompletedItemsFromFilterGroup(item);
								return;
							}
							if (!item.getIsCompleted() || !this._isFilterValueValid(item)) {
								filterGroup.remove(item);
							}
							if (item.isAggregative && item.leftExpression.subFilters) {
								this._removeUncompletedItemsFromFilterGroup(item.leftExpression.subFilters);
							}
						}, this);
					},

					/**
					 * @param {Object} model
					 * @param {Object} lookupValue
					 * @private
					 */
					_onTableObjectChanged: function(model, lookupValue) {
						if (lookupValue) {
							this.set("ObjectId", lookupValue.value);
							this.set("Name", lookupValue.displayValue);
							this.set("Caption", lookupValue.displayValue);
							this._tryFillEntityRelationalColumns();
						} else {
							this.set("ObjectId", null);
							this.set("Name", null);
						}
						if (this.get("MainObjectColumn")) {
							this.set("MainObjectColumn", null);
						}
						if (this.get("TableObjectColumn")) {
							this.set("TableObjectColumn", null);
						}
						this.set(this._getFilterSettingsColumnName(), this._createSerializedEmptyFilterGroup());
						this.set("TableObjectMacrosList", []);
						this._publishReinitializeFilterEditor();
						this._publishReinitializeMacrosListEditor();
					},

					/**
					 * @param {Object} model
					 * @param {Object} lookupValue
					 * @private
					 */
					_onMainObjectColumnChanged: function(model, lookupValue) {
						if (lookupValue) {
							this.set("ObjectColumnPath", lookupValue.value);
							this.set("ObjectColumnCaption", lookupValue.displayValue);
						} else {
							this.set("ObjectColumnPath", null);
							this.set("ObjectColumnCaption", null);
						}
					},

					/**
					 * @param {Object} model
					 * @param {Object} lookupValue
					 * @private
					 */
					_onTableObjectColumnChanged: function(model, lookupValue) {
						if (lookupValue) {
							this.set("ReferenceColumn", lookupValue.value);
							this.set("ReferenceColumnCaption", lookupValue.displayValue);
						} else {
							this.set("ReferenceColumn", null);
							this.set("ReferenceColumnCaption", null);
						}
					},

					/**
					 * @param {Object} model
					 * @param {Array} value
					 * @private
					 */
					_onTableObjectMacrosListChanged: function(model, value) {
						this.set(this._getMacrosSettingsColumnName(), JSON.stringify(value));
					},

					/**
					 * @param {Object} config
					 * @param {String} config.schemaName
					 * @param {String} config.referenceSchemaName
					 * @param {Function} callback
					 * @param {Object} scope
					 * @private
					 */
					_getFirstLookupColumnWithExpectedReferenceSchema: function(config, callback, scope) {
						BPMSoft.require([config.schemaName], function(schema) {
							const columns = Object.values(schema.columns)
									.filter(function(x) {
										return x.isLookup && x.referenceSchemaName === config.referenceSchemaName;
									})
									.sort(function(x, y) {
										if (x.name > y.name) {
											return 1;
										}
										if (x.name < y.name) {
											return -1;
										}
										return 0;
									});
							callback.call(scope, columns[0]);
						}, this);
					},

					/**
					 * @param {Object} config
					 * @param {String} config.schemaName
					 * @param {Function} callback
					 * @param {Object} scope
					 * @private
					 */
					_getIdColumn: function(config, callback, scope) {
						BPMSoft.require([config.schemaName], function(schema) {
							const column = Object.values(schema.columns)
									.find(function(x) {
										return x.name === "Id";
									});
							callback.call(scope, column);
						}, this);
					},

					/**
					 * @private
					 */
					_tryFillEntityRelationalColumns: function() {
						const tableObject = this.get("TableObject");
						if (tableObject) {
							BPMSoft.chain(
									function(next) {
										const config = {
											schemaName: tableObject.Name,
											referenceSchemaName: this.get("MainObjectName")
										};
										this._getFirstLookupColumnWithExpectedReferenceSchema(config, function(column) {
											if (!column) {
												return;
											}
											this.set("TableObjectColumn", {
												value: column.uId,
												displayValue: column.caption,
												path: column.name
											});
											next();
										}, this);
									},
									function() {
										this._getIdColumn({schemaName: this.get("MainObjectName")}, function(column) {
											this.set("MainObjectColumn", {
												value: column.uId,
												displayValue: column.caption,
												path: column.name
											});
										}, this);
									},
									this
							);
						}
					},

					/**
					 * @return {Array}
					 * @private
					 */
					_getExcludedColumnDataValueTypes: function() {
						return [
							BPMSoft.DataValueType.BLOB,
							BPMSoft.DataValueType.IMAGE,
							BPMSoft.DataValueType.FILE,
							BPMSoft.DataValueType.COLOR
						];
					},

					/**
					 * @param {String} columnName
					 * @param {Object} config
					 * @param {String} config.schemaName
					 * @param {String} config.columnPath
					 * @private
					 */
					_openStructureExplorer: function(columnName, config) {
						BPMSoft.StructureExplorerUtilities.open({
							moduleConfig: Ext.apply({
								useBackwards: false,
								displayId: true,
								excludeDataValueTypes: this._getExcludedColumnDataValueTypes()
							}, config),
							handlerMethod: function(result) {
								this.set(columnName, {
									value: result.metaPath.join("."),
									displayValue: result.caption.join("."),
									path: result.path.join(".")
								});
							},
							scope: this
						});
					},

					/**
					 * @param {String} filterValue
					 * @param {BPMSoft.Collection} list
					 * @param {String} referenceSchemaName
					 * @private
					 */
					_loadColumnLookupData: function(filterValue, list, referenceSchemaName) {
						BPMSoft.require([referenceSchemaName], function(schema) {
							const collection = Ext.create("BPMSoft.Collection");
							Object.values(schema.columns)
									.filter(function(column) {
										if (!Ext.isString(column.caption)) {
											return false;
										}
										return column.caption.toUpperCase().indexOf(filterValue.toUpperCase()) >= 0;
									}, this)
									.filter(function(column) {
										const excludedDataValueTypes = this._getExcludedColumnDataValueTypes();
										return !excludedDataValueTypes.some(function(dataValueType) {
											return column.dataValueType === dataValueType;
										});
									}, this)
									.sort(function(column1, column2) {
										if (column1.caption > column2.caption) {
											return 1;
										}
										if (column1.caption < column2.caption) {
											return -1;
										}
										return 0;
									})
									.forEach(function(column) {
										collection.add(column.uId, {
											value: column.uId,
											displayValue: column.caption,
											path: column.name
										});
									});
							list.reloadAll(collection);
						}, this);
					},

					/**
					 * @param {Object} config
					 * @param {String} config.entitySchemaUId
					 * @param {Function} callback
					 * @param {Object} scope
					 * @private
					 */
					_getEntitySchemaByUId: function(config, callback, scope) {
						const request = {
							serverMethod: "EntitySchemaService.svc/GetEntitySchemaByUId",
							data: {
								entitySchemaUId: config.entitySchemaUId
							}
						};
						BPMSoft.CoreServiceProvider.execute(request, function(response) {
							if (response.success) {
								callback.call(scope, {
									uId: config.entitySchemaUId,
									name: response.entitySchema.Name,
									caption: response.entitySchema.Caption
								});
							} else {
								throw Ext.create("BPMSoft.ItemNotFoundException");
							}
						}, this);
					},

					/**
					 * @param {Object} config
					 * @param {String?} config.entitySchemaUId
					 * @param {String?} config.entitySchemaName
					 * @param {String} config.entitySchemaColumnMetaPath
					 * @param {Function} callback
					 * @param {Object} scope
					 * @private
					 */
					_getEntitySchemaColumnByMetaPath: function(config, callback, scope) {
						BPMSoft.chain(
								function(next) {
									if (!config.entitySchemaUId) {
										BPMSoft.require([config.entitySchemaName], function(entitySchema) {
											if (!entitySchema) {
												throw Ext.create("BPMSoft.ItemNotFoundException");
											}
											next(entitySchema.uId);
										}, this);
									} else {
										next(config.entitySchemaUId);
									}
								},
								function(next, entitySchemaUId) {
									const request = {
										entitySchemaUId: entitySchemaUId,
										schemaColumnMetaPath: config.entitySchemaColumnMetaPath
									};
									BPMSoft.SchemaDesignerUtilities.getEntitySchemaColumnPathByMetaPath(request, function(response) {
										callback.call(scope, {
											metaPath: request.schemaColumnMetaPath,
											path: response.columnPath,
											captionPath: response.columnCaptionPath
										});
									});
								},
								this
						);
					},

					/**
					 * @param {Function} callback
					 * @param {Object} scope
					 * @private
					 */
					_initTableObject: function(callback, scope) {
						this._getEntitySchemaByUId({entitySchemaUId: this.get("ObjectId")}, function(response) {
							this.set("TableObject", {
								value: response.uId,
								displayValue: response.caption,
								Name: response.name
							});
							callback.call(scope);
						}, this);
					},

					/**
					 * @param {Function} callback
					 * @param {Object} scope
					 * @private
					 */
					_initTableObjectColumn: function(callback, scope) {
						const request = {
							entitySchemaUId: this.get("ObjectId"),
							entitySchemaColumnMetaPath: this.get("ReferenceColumn")
						};
						this._getEntitySchemaColumnByMetaPath(request, function(response) {
							this.set("TableObjectColumn", {
								value: response.metaPath,
								displayValue: response.captionPath,
								path: response.path
							});
							callback.call(scope);
						}, this);
					},

					/**
					 * @param {Function} callback
					 * @param {Object} scope
					 * @private
					 */
					_initMainObjectColumn: function(callback, scope) {
						const request = {
							entitySchemaName: this.get("MainObjectName"),
							entitySchemaColumnMetaPath: this.get("ObjectColumnPath")
						};
						this._getEntitySchemaColumnByMetaPath(request, function(response) {
							this.set("MainObjectColumn", {
								value: response.metaPath,
								displayValue: response.captionPath,
								path: response.path
							});
							callback.call(scope);
						}, this);
					},

					/**
					 * @private
					 */
					_initTableObjectMacrosList: function() {
						this.set("TableObjectMacrosList", JSON.parse(this.get(this._getMacrosSettingsColumnName())));
					},

					/**
					 * @param {Object} config
					 * @param {Boolean} config.isFirstInitialization
					 * @param {Function} callback
					 * @param {Object} scope
					 * @private
					 */
					_afterEntityLoading: function(config, callback, scope) {
						if (this.isAddMode()) {
							this._initTableObjectMacrosList();
							Ext.callback(callback, scope);
							return;
						}
						BPMSoft.chain(
								function(next) {
									this._initTableObject(next, this);
								},
								function(next) {
									this._initTableObjectColumn(next, this);
								},
								function(next) {
									this._initMainObjectColumn(next, this);
								},
								function() {
									this._initTableObjectMacrosList();
									if (!config.isFirstInitialization) {
										this._publishReinitializeFilterEditor();
										this._publishReinitializeMacrosListEditor();
									}
									Ext.callback(callback, scope);
								},
								this
						);
					},

					/**
					 * @param {Object} entity
					 * @private
					 */
					_setColumnValuesFromEntity: function(entity) {
						BPMSoft.each(entity.columnValues, function(value, columnName) {
							const column = this.columns[columnName];
							if (column) {
								this.setColumnValue(columnName, value, {preventValidation: true});
							}
						}, this);
					},

					/**
					 * @param {String} serializedFilter
					 * @return {String}
					 * @private
					 */
					_fixFilterGroupBeforeSave: function(serializedFilter) {
						const filter = BPMSoft.deserialize(serializedFilter);
						this._removeUncompletedItemsFromFilterGroup(filter);
						return filter.serialize({serializeFilterManagerInfo: true});
					},

					/**
					 * @param {String} columnName
					 * @param {Boolean|Number|String|Object} columnValue
					 * @return {Boolean|Number|String|Object}
					 * @private
					 */
					_prepareEntityColumnForSave: function(columnName, columnValue) {
						if (columnName === this._getFilterSettingsColumnName()) {
							return this._fixFilterGroupBeforeSave(columnValue);
						}
						return columnValue;
					},

					/**
					 * @return {Object}
					 * @private
					 */
					_getEntityForSave: function() {
						const columnValues = {};
						BPMSoft.each(this.columns, function(column, columnName) {
							if (column.type === BPMSoft.ViewModelColumnType.ENTITY_COLUMN) {
								columnValues[columnName] = this._prepareEntityColumnForSave(columnName, this.get(columnName));
							}
						}, this);
						return {columnValues: columnValues};
					},

					/**
					 * @private
					 */
					_subscribeOnVirtualColumnChanges: function() {
						this.subscribeOnColumnChange("TableObject", this._onTableObjectChanged, this);
						this.subscribeOnColumnChange("MainObjectColumn", this._onMainObjectColumnChanged, this);
						this.subscribeOnColumnChange("TableObjectColumn", this._onTableObjectColumnChanged, this);
						this.subscribeOnColumnChange("TableObjectMacrosList", this._onTableObjectMacrosListChanged, this);
					},

					/**
					 * @private
					 */
					_unsubscribeOnVirtualColumnChanges: function() {
						this.unsubscribeOnColumnChange("TableObject", this._onTableObjectChanged, this);
						this.unsubscribeOnColumnChange("MainObjectColumn", this._onMainObjectColumnChanged, this);
						this.unsubscribeOnColumnChange("TableObjectColumn", this._onTableObjectColumnChanged, this);
						this.unsubscribeOnColumnChange("TableObjectMacrosList", this._onTableObjectMacrosListChanged, this);
					},

					/**
					 * @private
					 */
					_subscribeOnTableObjectFilterEditorEvents: function() {
						this.sandbox.subscribe("GetFilterModuleConfig", function() {
							return {
								rootSchemaName: this.get("TableObject") && this.get("TableObject").Name,
								filters: this.get(this._getFilterSettingsColumnName()),
								entitySchemaFilterProviderConfig: {
									shouldHideLookupActions: true,
									isColumnSettingsHidden: true
								}
							};
						}, this, ["TableObjectFilterEditor"]);
						this.sandbox.subscribe("OnFiltersChanged", function(response) {
							const oldFilter = BPMSoft.deserialize(this.get(this._getFilterSettingsColumnName()));
							if (!this._areFiltersEqual(response.filter, oldFilter)) {
								this.set(this._getFilterSettingsColumnName(), response.serializedFilter);
							}
						}, this, ["TableObjectFilterEditor"]);
					},

					/**
					 * @private
					 */
					_subscribeOnTableObjectMacrosEditorEvents: function() {
						this.sandbox.subscribe("GetMacrosListDetailInfo", function() {
							return {
								rootEntitySchema: this.get("TableObject") && this.get("TableObject").Name,
								isSortingEnabled: true,
								macrosList: this.get("TableObjectMacrosList"),
								caption: this.get("Resources.Strings.TableObjectMacrosEditorCaption"),
								infoButtonText: this.get("Resources.Strings.TableObjectMacrosEditorInfoButtonText"),
								moduleSchemaNameRequiredValidationMessage: this._getSysModuleRequiredValidationMessage(),
								addButtonLabel: this.get("Resources.Strings.AddButtonLabel")
							};
						}, this, ["TableObjectMacrosEditor"]);
						this.sandbox.subscribe("MacrosListChanged", function(macrosList) {
							this.set("TableObjectMacrosList", macrosList);
						}, this, ["TableObjectMacrosEditor"]);
						this.sandbox.subscribe("OpenMacrosSettingsPage", function(macrosSettings) {
							ColumnSettingsUtilities.Open(this.sandbox, macrosSettings, function(newMacrosSettings) {
								this.sandbox.publish("SetMacrosSettings", newMacrosSettings, ["TableObjectMacrosEditor"]);
							}, this.renderTo, this);
						}, this, ["TableObjectMacrosEditor"]);
					},

					/**
					 * @private
					 */

					_getSysModuleRequiredValidationMessage: function() {
						return Ext.String.format(
							BPMSoft.Resources.BaseViewModel.fieldValidationError,
							this.getColumnCaptionByName("TableObject"),
							BPMSoft.Resources.BaseViewModel.columnRequiredValidationMessage);
					},

					_publishReinitializeFilterEditor: function() {
						const config = {
							rootSchemaName: this.get("TableObject") && this.get("TableObject").Name,
							filters: this.get(this._getFilterSettingsColumnName())
						};
						this.sandbox.publish("SetFilterModuleConfig", config, ["TableObjectFilterEditor"]);
					},

					/**
					 * @private
					 */
					_publishReinitializeMacrosListEditor: function() {
						const schemaName = this.get("TableObject") && this.get("TableObject").Name;
						this.sandbox.publish("RootEntitySchemaChanged", schemaName, ["TableObjectMacrosEditor"]);
						this.sandbox.publish("ReinitializeMacrosList", this.get("TableObjectMacrosList"), ["TableObjectMacrosEditor"]);
					},

					// endregion

					// region Methods: Protected

					/**
					 * @inheritDoc BPMSoft.BasePageV2#onEntityInitialized
					 * @override
					 */
					onEntityInitialized: function() {
						this.callParent(arguments);
						BPMSoft.chain(
								function(next) {
									this._afterEntityLoading({isFirstInitialization: true}, next, this);
								},
								function() {
									this._subscribeOnVirtualColumnChanges();
									this._subscribeOnTableObjectFilterEditorEvents();
									this._subscribeOnTableObjectMacrosEditorEvents();
									this.get("TryCompleteInitialization")();
								},
								this
						);
					},

					/**
					 * @inheritDoc BPMSoft.BaseObject#onDestroy
					 * @override
					 */
					onDestroy: function() {
						this._unsubscribeOnVirtualColumnChanges();
						this.callParent(arguments);
					},

					// endregion

					// region Methods: Public

					/**
					 * @inheritDoc BPMSoft.BaseSchemaViewModel#init
					 * @override
					 */
					init: function(callback, scope) {
						this.set("TryCompleteInitialization", (function(atemptCount) {
							let counter = 0;
							return function() {
								counter++;
								if (counter === atemptCount) {
									callback.call(scope);
								}
							};
						})(2));
						this.callParent([
							function() {
								this.get("TryCompleteInitialization")();
							}, this
						]);
					},

					onRender: function() {
						this.callParent(arguments);
						this.loadModule({name: "MacrosModule"});
					},

					/**
					 * @inheritDoc BPMSoft.BaseSchemaViewModel#loadVocabulary
					 * @override
					 */
					loadVocabulary: function(args, columnName) {
						if (columnName === "MainObjectColumn") {
							this._openStructureExplorer("MainObjectColumn", {
								schemaName: this.get("MainObjectName"),
								columnPath: this.get("MainObjectColumn") && this.get("MainObjectColumn").path
							});
							return;
						}
						if (columnName === "TableObjectColumn") {
							const tableObject = this.get("TableObject");
							if (tableObject) {
								this._openStructureExplorer("TableObjectColumn", {
									schemaName: tableObject.Name,
									columnPath: this.get("TableObjectColumn") && this.get("TableObjectColumn").path
								});
							}
							return;
						}
						this.callParent(arguments);
					},

					/**
					 * @inheritDoc BPMSoft.EntityBaseViewModelMixin#loadLookupData
					 * @override
					 */
					loadLookupData: function(filterValue, list, columnName) {
						if (columnName === "MainObjectColumn") {
							this._loadColumnLookupData(filterValue, list, this.get("MainObjectName"));
							return;
						}
						if (columnName === "TableObjectColumn") {
							const tableObject = this.get("TableObject");
							if (tableObject) {
								this._loadColumnLookupData(filterValue, list, tableObject.Name);
							}
							return;
						}
						this.callParent(arguments);
					},

					/**
					 * @inheritDoc BPMSoft.EntityBaseViewModelMixin#loadLookupDataWithParams
					 * @override
					 */
					loadLookupDataWithParams: function(params, columnName) {
						if (columnName === "MainObjectColumn" || columnName === "TableObjectColumn") {
							return;
						}
						this.callParent(arguments);
					},

					/**
					 * @inheritDoc BPMSoft.EntityBaseViewModelMixin#setDefaultValues
					 * @overridden
					 */
					setDefaultValues: function(callback, scope) {
						this.callParent([
							function() {
								const entity = Ext.merge({
									columnValues: {
										MacrosList: !this._canUse7xFilters() ? JSON.stringify([]) : "",
										MacrosSettings: this._canUse7xFilters() ? JSON.stringify([]) : "",
										Filter: !this._canUse7xFilters() ? this._createSerializedEmptyFilterGroup() : "",
										FilterSettings: this._canUse7xFilters() ? this._createSerializedEmptyFilterGroup() : ""
									}
								}, this.sandbox.publish("GetTablePartDefaultValues"));
								this._setColumnValuesFromEntity(entity);
								Ext.callback(callback, scope);
							}, this
						]);
					},

					/**
					 * @inheritDoc BPMSoft.EntityBaseViewModelMixin#loadEntity
					 * @overridden
					 */
					loadEntity: function(primaryColumnValue, callback, scope) {
						const entity = this.sandbox.publish("GetTablePartById", {id: primaryColumnValue});
						this.isNew = false;
						this._setColumnValuesFromEntity(entity);
						this.changedValues = {};
						Ext.callback(callback, scope);
					},

					/**
					 * @inheritDoc BPMSoft.EntityBaseViewModelMixin#copyEntity
					 * @overridden
					 */
					copyEntity: function(primaryColumnValue, callback, scope) {
						const entity = this.sandbox.publish("GetTablePartById", {id: primaryColumnValue});
						this._setColumnValuesFromEntity(entity);
						this.isNew = true;
						this.$Id = BPMSoft.generateGUID();
						this.$Caption += " - " + this.get("Resources.Strings.CopyPostfixCaption");
						Ext.callback(callback, scope);
					},

					/**
					 * @inheritDoc BPMSoft.EntityBaseViewModelMixin#saveEntity
					 * @overridden
					 */
					saveEntity: function(callback, scope) {
						const response = this.sandbox.publish("SaveTablePart", this._getEntityForSave());
						if (response.success) {
							this.isNew = false;
							this.changedValues = null;
						}
						Ext.callback(callback, scope, [response]);
					},

					/**
					 * @inheritDoc BPMSoft.BasePageV2#onDiscardChangesClick
					 * @overridden
					 */
					onDiscardChangesClick: function(callback, scope) {
						this.callParent([
							function() {
								BPMSoft.chain(
										function(next) {
											this._unsubscribeOnVirtualColumnChanges();
											this._afterEntityLoading({isFirstInitialization: false}, next, this);
										},
										function() {
											this._subscribeOnVirtualColumnChanges();
											Ext.callback(callback, scope);
										},
										this
								);
							}, this
						]);
					},

					/**
					 * @inheritDoc BPMSoft.BasePageV2#getPageHeaderCaption
					 * @overridden
					 */
					getPageHeaderCaption: function() {
						return this.get("Caption") || this.get("Resources.Strings.DefaultPageHeaderCaption");
					},

					/**
					 * Returns enabling of table object.
					 * @return {Boolean}
					 */
					getIsTableObjectEnabled: function() {
						const filter = BPMSoft.deserialize(this.get(this._getFilterSettingsColumnName()));
						const macrosList = this.get("TableObjectMacrosList");
						return !filter.getIsEnabled() && Ext.isEmpty(macrosList);
					},

					/**
					 * Returns empty info image uri.
					 * @return {String}
					 */
					getBlankSlatesImageSrc: function() {
						return BPMSoft.ImageUrlBuilder.getUrl(this.get("Resources.Images.EmptyInfoImage"));
					}

					//endregion

				},
				details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
				modules: /**SCHEMA_MODULES*/{
					"FilterModule": {
						"moduleId": "TableObjectFilterEditor",
						"moduleName": "FilterEditModule"
					},
					"MacrosModule": {
						"moduleId": "TableObjectMacrosEditor",
						"moduleName": "MacrosListDetailModule",
						"reload": false,
						"config": {
							"sandboxTag": "TableObjectMacrosEditor"
						}
					}
				}/**SCHEMA_MODULES*/,
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "merge",
						"name": "CardContentWrapper",
						"values": {
							"wrapClass": [
								"card-content-container",
								"word-printable-card-content-container",
								"word-printable-table-part-card-content-container"
							]
						}
					}, {
						"operation": "remove",
						"name": "LeftModulesContainer"
					}, {
						"operation": "merge",
						"name": "SaveButton",
						"values": {
							"hint": ""
						}
					}, {
						"operation": "insert",
						"name": "MainHeaderWrap",
						"parentName": "CardContentWrapper",
						"propertyName": "items",
						"index": 2,
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"wrapClass": ["word-printable-card-main-header-wrap-container"],
							"items": []
						}
					}, {
						"operation": "insert",
						"name": "MainHeader",
						"parentName": "MainHeaderWrap",
						"propertyName": "items",
						"index": 0,
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"wrapClass": ["word-printable-card-main-header-container"],
							"items": []
						}
					}, {
						"operation": "insert",
						"name": "PageCaption",
						"parentName": "MainHeader",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.LABEL,
							"caption": {"bindTo": "getPageHeaderCaption"}
						}
					},
					{
						"operation": "insert",
						"name": "logoImage",
						"parentName": "MainHeader",
						"propertyName": "items",
						"values": {
							"id": "logoImage",
							"itemType": BPMSoft.ViewItemType.COMPONENT,
							"selectors": {
								"wrapEl": "#logoImage"
							},
							"className": "BPMSoft.ImageView",
							"imageSrc": {"bindTo": "getLogoImageConfig"},
							"tag": "HeaderLogoImage",
							"classes": {
								"wrapClass": ["main-header-logo-image", "cursor-pointer"]
							}
						}
					}, 
					{
						"operation": "insert",
						"name": "TableObject",
						"parentName": "Header",
						"propertyName": "items",
						"values": {
							"bindTo": "TableObject",
							"controlConfig": {
								"placeholder": {"bindTo": "Resources.Strings.TableObjectPlaceholder"}
							},
							"enabled": {"bindTo": "getIsTableObjectEnabled"},
							"tip": {
								"content": {"bindTo": "Resources.Strings.TableObjectTip"}
							},
							"layout": {"row": 0, "column": 0, "rowSpan": 1, "colSpan": 11}
						}
					}, {
						"operation": "insert",
						"name": "TableObjectColumn",
						"parentName": "Header",
						"propertyName": "items",
						"values": {
							"bindTo": "TableObjectColumn",
							"controlConfig": {
								"placeholder": {"bindTo": "Resources.Strings.TableObjectColumnPlaceholder"}
							},
							"tip": {
								"content": {"bindTo": "Resources.Strings.TableObjectColumnTip"}
							},
							"layout": {"row": 0, "column": 13, "rowSpan": 1, "colSpan": 11}
						}
					}, {
						"operation": "insert",
						"name": "Caption",
						"parentName": "Header",
						"propertyName": "items",
						"values": {
							"bindTo": "Caption",
							"controlConfig": {
								"placeholder": {"bindTo": "Resources.Strings.TableObjectCaptionPlaceholder"}
							},
							"tip": {
								"content": {"bindTo": "Resources.Strings.CaptionTip"}
							},
							"layout": {"row": 1, "column": 0, "rowSpan": 1, "colSpan": 11}
						}
					}, {
						"operation": "insert",
						"name": "MainObjectColumn",
						"parentName": "Header",
						"propertyName": "items",
						"values": {
							"bindTo": "MainObjectColumn",
							"controlConfig": {
								"placeholder": {"bindTo": "Resources.Strings.TableObjectColumnPlaceholder"}
							},
							"tip": {
								"content": {"bindTo": "Resources.Strings.MainObjectColumnTip"}
							},
							"layout": {"row": 1, "column": 13, "rowSpan": 1, "colSpan": 11}
						}
					}, {
						"operation": "insert",
						"name": "IsEmptyTableHide",
						"parentName": "Header",
						"propertyName": "items",
						"values": {
							"bindTo": "IsEmptyTableHide",
							"layout": {"row": 2, "column": 0, "rowSpan": 1, "colSpan": 11}
						}
					}, {
						"operation": "insert",
						"name": "ParametersTab",
						"parentName": "Tabs",
						"propertyName": "tabs",
						"index": 0,
						"values": {
							"caption": {"bindTo": "Resources.Strings.ParametersTabCaption"},
							"items": []
						}
					}, {
						"operation": "insert",
						"name": "MacrosModule",
						"parentName": "ParametersTab",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.MODULE,
							"visible": true,
							"classes": {
								"wrapClassName": ["table-macros"]
							}
						}
					}, {
						"operation": "insert",
						"name": "FiltersTab",
						"parentName": "Tabs",
						"propertyName": "tabs",
						"index": 1,
						"values": {
							"caption": {"bindTo": "Resources.Strings.FiltersTabCaption"},
							"items": []
						}
					}, {
						"operation": "insert",
						"name": "FilterModule",
						"parentName": "FiltersTab",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.MODULE,
							"visible": {
								"bindTo": "TableObject",
								"bindConfig": {"converter": "isNotEmptyValue"}
							}
						}
					}, {
						"operation": "insert",
						"name": "FiltersTabBlankSlatesContainer",
						"parentName": "FiltersTab",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"visible": {
								"bindTo": "TableObject",
								"bindConfig": {"converter": "isEmptyValue"}
							},
							"wrapClass": ["word-printable-blank-slates-container"],
							"items": []
						}
					}, {
						"operation": "insert",
						"name": "FiltersTabBlankSlatesImage",
						"parentName": "FiltersTabBlankSlatesContainer",
						"propertyName": "items",
						"values": {
							"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
							"onPhotoChange": BPMSoft.emptyFn,
							"getSrcMethod": "getBlankSlatesImageSrc"
						}
					}, {
						"operation": "insert",
						"name": "FiltersTabBlankSlatesLabelContainer",
						"parentName": "FiltersTabBlankSlatesContainer",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"wrapClass": ["word-printable-blank-slates-label-container"],
							"items": []
						}
					}, {
						"operation": "insert",
						"name": "FiltersTabBlankSlatesLabel",
						"parentName": "FiltersTabBlankSlatesLabelContainer",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.LABEL,
							"caption": {"bindTo": "Resources.Strings.FilterModulePlaceHolderLabel"}
						}
					}, {
						"operation": "insert",
						"name": "ParametersTabBlankSlatesContainer",
						"parentName": "ParametersTab",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"visible": {
								"bindTo": "TableObject",
								"bindConfig": {"converter": "isEmptyValue"}
							},
							"wrapClass": ["word-printable-blank-slates-container"],
							"items": []
						}
					}, {
						"operation": "insert",
						"name": "ParametersTabBlankSlatesImage",
						"parentName": "ParametersTabBlankSlatesContainer",
						"propertyName": "items",
						"values": {
							"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
							"onPhotoChange": BPMSoft.emptyFn,
							"getSrcMethod": "getBlankSlatesImageSrc"
						}
					}, {
						"operation": "insert",
						"name": "ParametersTabBlankSlatesLabelContainer",
						"parentName": "ParametersTabBlankSlatesContainer",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"wrapClass": ["word-printable-blank-slates-label-container"],
							"items": []
						}
					}, {
						"operation": "insert",
						"name": "ParametersTabBlankSlatesLabel",
						"parentName": "ParametersTabBlankSlatesLabelContainer",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.LABEL,
							"caption": {"bindTo": "Resources.Strings.MacrosModulePlaceHolderLabel"}
						}
					}
				]/**SCHEMA_DIFF*/
			};
		});
