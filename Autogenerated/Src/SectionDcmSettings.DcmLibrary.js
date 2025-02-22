﻿define("SectionDcmSettings", ["SectionDcmSettingsResources", "SysDcmSettingsManager", "DcmSchemaManager"],
	function(resources) {
		return {
			messages: {

				/**
				 * @message GetModuleConfigResult
				 * Publishing message on section dcm settings initialization.
				 */
				"SectionDcmSettingsInitialized": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message ValidateSectionDcmSettings
				 * Subscribing on message for validation section dcm settings.
				 */
				"ValidateSectionDcmSettings": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message SaveSectionDcmSettings
				 * Subscribing on message for saving section dcm settings.
				 */
				"SaveSectionDcmSettings": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message OnSectionDcmSettingsSaved
				 * Publishing message on save section dcm settings.
				 */
				"OnSectionDcmSettingsSaved": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message ReloadCaseSettings
				 * Subscribing on message for reload case settings.
				 */
				"ReloadCaseSettings": {
					mode: BPMSoft.MessageMode.BROADCAST,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message ReloadDcmLibGridData
				 * Publishing message for reload dcm lib grid data.
				 */
				"ReloadDcmLibGridData": {
					mode: BPMSoft.MessageMode.BROADCAST,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message EnabledDcmSchemas
				 * Subscribing on message for enabled schemas.
				 */
				"EnabledDcmSchemas": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},
			attributes: {

				/**
				 * SysModuleEntityId.
				 */
				"SysModuleEntityId": {
					dataValueType: BPMSoft.DataValueType.GUID,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * SSP section SysModuleEntity unique identifier.
				 * @type {String}
				 */
				"SspSysModuleEntityId": {
					dataValueType: BPMSoft.DataValueType.GUID,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * PackageUId.
				 */
				"PackageUId": {
					dataValueType: BPMSoft.DataValueType.GUID,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * SysDcmSettingsItem.
				 */
				"SysDcmSettingsItem": {
					dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * SSP section SysDcmSettings item.
				 * @type {BPMSoft.SysDcmSettingsManagerItem}
				 */
				"SspSysDcmSettingsItem": {
					dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * SectionEntitySchema.
				 */
				"SectionEntitySchema": {
					dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * StageColumn.
				 */
				"StageColumn": {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					caption: resources.localizableStrings.StageColumnCaption,
					onChange: "onStageColumnChange"
				},

				/**
				 * FilterColumn.
				 */
				"FilterColumn": {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					caption: resources.localizableStrings.FilterColumnCaption,
					onChange: "onFiltersColumnChange"
				},

				/**
				 * Filters.
				 */
				"Filters": {
					dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * StageColumnsList.
				 */
				"StageColumnsList": {
					dataValueType: BPMSoft.DataValueType.COLLECTION,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * DcmSchemaList.
				 */
				"DcmSchemaList": {
					dataValueType: BPMSoft.DataValueType.COLLECTION,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * FilterColumnsList.
				 */
				"FilterColumnsList": {
					dataValueType: BPMSoft.DataValueType.COLLECTION,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},
			modules: {},
			methods: {

				//region Methods: Private

				/**
				 * Subscribes sandbox to messages.
				 * @private
				 */
				subscribeSandboxEvents: function() {
					var sandbox = this.sandbox;
					sandbox.subscribe("ValidateSectionDcmSettings", this.onValidate, this, [sandbox.id]);
					sandbox.subscribe("SaveSectionDcmSettings", this.onSave, this, [sandbox.id]);
					sandbox.subscribe("ReloadCaseSettings", this.onReloadCaseSettings, this);
					sandbox.subscribe("EnabledDcmSchemas", this.onEnabledDcmSchemas, this);
				},

				/**
				 * Handler for reload section wizard case settings.
				 * @protected
				 */
				onReloadCaseSettings: function() {
					var maskId = BPMSoft.Mask.show({
						selector: "#SectionDcmSettingsModule",
						timeout: 0
					});
					BPMSoft.chain(
						function(next) {
							BPMSoft.DcmSchemaManager.reInitialize(next, this);
						},
						function(next) {
							BPMSoft.SysDcmSettingsManager.reInitialize(next, this);
						},
						function(next) {
							BPMSoft.SysDcmSchemaInSettingsManager.reInitialize(next, this);
						},
						this.initializeSysDcmSettingsItem,
						this.initializeSectionEntitySchema,
						this.initializeColumnValues,
						function() {
							BPMSoft.Mask.hide(maskId);
						},
						this
					);
				},

				/**
				 * Returns section dcm settings filters. If filters array is empty, adds new empty filter.
				 * @private
				 * @return {Object[]} Section dcm settings filters.
				 */
				getSectionDcmSettingsFilers: function() {
					var sysDcmSettingsItem = this.get("SysDcmSettingsItem");
					var filters = sysDcmSettingsItem.getFilters();
					if (filters.length === 0) {
						filters.push({
							columnUId: null
						});
					}
					return filters;
				},

				/**
				 * Initialize SysDcmSettingsManager.
				 * @private
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function call context.
				 */
				initializeSysDcmSettingsManager: function(callback, scope) {
					BPMSoft.SysDcmSettingsManager.initialize(null, callback, scope);
				},

				/**
				 * Initialize SysDcmSchemaInSettingsManager.
				 * @private
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function call context.
				 */
				initializeSysDcmSchemaInSettingsManager: function(callback, scope) {
					BPMSoft.SysDcmSchemaInSettingsManager.initialize(null, callback, scope);
				},

				/**
				 * Initialize SysDcmSettingsManager item. If manager item doesn't exists, creates new and adds it to
				 * SysDcmSettingsManager
				 * @private
				 * @param {Function} callback Callback function.
				 * @param {BPMSoft.manager.SysDcmSettingsManagerItem} callback.sysDcmSettingsItem Initialized
				 * manager item.
				 * @param {Object} scope Callback function call context.
				 */
				initializeSysDcmSettingsItem: function(callback, scope) {
					BPMSoft.chain(
						function(next) {
							const sysModuleEntityId = this.$SysModuleEntityId;
							this._forceGetEntitySysDcmSettingsItem(sysModuleEntityId, next, this);
						},
						function(next, sysDcmSettingsItem) {
							this.$SysDcmSettingsItem = sysDcmSettingsItem;
							Ext.callback(next, this);
						},
						function(next) {
							const sspSysModuleEntityId = this.$SspSysModuleEntityId;
							if (!Ext.isEmpty(sspSysModuleEntityId)) {
								return this._forceGetEntitySysDcmSettingsItem(sspSysModuleEntityId, next, this);
							}
							next();
						},
						function(next, sspSysDcmSettingsItem) {
							if (!Ext.isEmpty(sspSysDcmSettingsItem)) {
								this.$SspSysDcmSettingsItem = sspSysDcmSettingsItem;
							}
							Ext.callback(next, this);
						},
						function() {
							Ext.callback(callback, scope || this, [this.$SysDcmSettingsItem]);
						}, this);
				},

				/**
				 * Returns SysDcmSettingsManagerItem instance for SysModuleEntity. If item not exists, new item will be created.
				 * @private
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function scope.
				 */
				_forceGetEntitySysDcmSettingsItem: function(sysModuleEntityId, callback, scope) {
					const sysDcmSettingsItem = BPMSoft.SysDcmSettingsManager.findBySysModuleEntityId(sysModuleEntityId);
					if (sysDcmSettingsItem) {
						Ext.callback(callback, scope || this, [sysDcmSettingsItem]);
					} else {
						this.createSysDcmSettingsItem(sysModuleEntityId, callback, scope);
					}
				},

				/**
				 * Initialize section entity schema. After initialization sets it to SectionEntitySchema attribure.
				 * @private
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function call context.
				 */
				initializeSectionEntitySchema: function(callback, scope) {
					var sysDcmSettingsItem = this.get("SysDcmSettingsItem");
					var packageUId = this.get("PackageUId");
					sysDcmSettingsItem.getEntitySchema(packageUId, function(entitySchema) {
						this.set("SectionEntitySchema", entitySchema);
						callback.call(scope);
					}, this);
				},

				/**
				 * Initialize view model column values.
				 * @private
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function call context.
				 */
				initializeColumnValues: function(callback, scope) {
					this.initializeStageColumnValue();
					this.initializeFilterColumnValue();
					callback.call(scope);
				},

				/**
				 * Initialize StageColumn value.
				 * @private
				 */
				initializeStageColumnValue: function() {
					var sysDcmSettingsItem = this.get("SysDcmSettingsItem");
					var entitySchema = this.get("SectionEntitySchema");
					var stageColumnUId = sysDcmSettingsItem.getStageColumnUId();
					var stageColumn = entitySchema.findColumnByUId(stageColumnUId);
					if (stageColumn) {
						this.set("StageColumn", {
							value: stageColumnUId,
							displayValue: this.getColumnDisplayValue(stageColumn)
						});
					}
				},

				/**
				 * Initialize FilterColumn column value.
				 * @private
				 */
				initializeFilterColumnValue: function() {
					var entitySchema = this.get("SectionEntitySchema");
					var filters = this.getSectionDcmSettingsFilers();
					this.set("Filters", filters);
					var firstFilter = filters[0];
					var filterColumnUId = firstFilter.columnUId;
					var filterColumn = entitySchema.findColumnByUId(filterColumnUId);
					if (filterColumn) {
						this.set("FilterColumn", {
							value: filterColumnUId,
							displayValue: this.getColumnDisplayValue(filterColumn)
						});
					} else {
						this.set("FilterColumn", null);
					}
				},

				/**
				 * Method fills FilterColumnsList property.
				 * @private
				 * @param {String} filter Filter value.
				 * @param {BPMSoft.Collection} list Lookup list.
				 */
				prepareStageColumnsList: function(filter, list) {
					var filterColumn = this.get("FilterColumn") || {};
					this.prepareEntitySchemaColumnsList(list, [filterColumn.value]);
				},

				/**
				 * Filters dcm schema collection by current SysDcmSettingsItem in SysDcmSchemaInSettingsManager.
				 * @private
				 * @param {BPMSoft.Collection} items Dcm schema items collection.
				 * @return {BPMSoft.Collection}
				 */
				filterDcmSchemasBySchemaInSettings: function(items) {
					var sysDcmSettingsItem = this.get("SysDcmSettingsItem");
					var dcmSchemaInSettings = BPMSoft.SysDcmSchemaInSettingsManager
						.filterItemsBySysDcmSettingsId(sysDcmSettingsItem.id);
					var schemaUIds = dcmSchemaInSettings.getItems().map(function(settingItem) {
						return settingItem.getSysDcmSchemaUId();
					}, this);
					var filteredItems = items.filterByFn(function(schemaItem) {
						return BPMSoft.contains(schemaUIds, schemaItem.uId);
					}, this);
					return filteredItems;
				},

				/**
				 * Returns collection of active dcm schema for current entity section.
				 * @private
				 * @param {Function} callback The callback function.
				 * @param {BPMSoft.Collection} callback.filteredItems The collection of filtered DcmSchemaManager items.
				 * @param {Object} scope The scope of callback function.
				 */
				getSectionDcmSchemaManagerItems: function(callback, scope) {
					var packageUId = this.get("PackageUId");
					BPMSoft.DcmSchemaManager.findPackageItems(packageUId, function(items) {
						var filteredItems = this.filterDcmSchemasBySchemaInSettings(items);
						var activeItems = filteredItems.filterByFn(function(schemaItem) {
							return schemaItem.getIsActive();
						}, this);
						callback.call(scope, activeItems);
					}, this);
				},

				/**
				 * Method fills DcmSchemaList property.
				 * @private
				 * @param {String} filter Filter value.
				 * @param {BPMSoft.Collection} list Lookup list.
				 */
				prepareDcmSchemaList: function(filter, list) {
					this.getDcmSchemaList(function(result) {
						list.clear();
						list.loadAll(result);
					}, this);
				},

				/**
				 * Returns DCM schema list
				 * @private
				 * @param {Function} callback Callback function.
				 * @param {Object} scope The scope of callback function.
				 */
				getDcmSchemaList: function(callback, scope) {
					this.getSectionDcmSchemaManagerItems(function(items) {
						var result = Ext.create("BPMSoft.Collection");
						var columnsConfig = {};
						items.each(function(item) {
							var schemaUId = item.getUId();
							var schemaDisplayValue = item.getDisplayValue();
							columnsConfig[schemaUId] = {
								value: schemaUId,
								displayValue: schemaDisplayValue
							};
						}, this);
						result.loadAll(columnsConfig);
						callback.call(scope, result);
					}, this);
				},

				/**
				 * Method fills FilterColumnsList property.
				 * @private
				 * @param {String} filter Filter value.
				 * @param {BPMSoft.Collection} list Lookup list.
				 */
				prepareFilterColumnsList: function(filter, list) {
					var stageColumn = this.get("StageColumn") || {};
					this.prepareEntitySchemaColumnsList(list, [stageColumn.value]);
				},

				/**
				 * Returns columns config be columns collection
				 * @private
				 * @param {BPMSoft.Collection} columns Entity schema columns.
				 * @return {Object} Columns config.
				 */
				getColumnsConfig: function(columns) {
					var columnsConfig = {};
					columns.each(function(column) {
						var columnUId = column.uId;
						columnsConfig[columnUId] = {
							value: columnUId,
							displayValue: this.getColumnDisplayValue(column),
							name: column.name
						};
					}, this);
					return columnsConfig;
				},

				/**
				 * Method fills collection by entity schema columns.
				 * @private
				 * @param {BPMSoft.Collection} list Lookup list.
				 * @param {String[]} excludeColumnsUIds Columns uIds to exclude from collection.
				 */
				prepareEntitySchemaColumnsList: function(list, excludeColumnsUIds) {
					var entitySchema = this.get("SectionEntitySchema");
					var lookupColumns = this.getEntitySchemaLookupColumns(entitySchema);
					var dcmStageColumns = this.excludeColumns(lookupColumns, excludeColumnsUIds);
					this.sortColumnsByDisplayValue(dcmStageColumns);
					var columnsConfig = this.getColumnsConfig(dcmStageColumns);
					list.clear();
					list.loadAll(columnsConfig);
				},

				/**
				 * Method sorting columns collection by display value.
				 * @private
				 * @param {BPMSoft.Collection} columns Columns.
				 */
				sortColumnsByDisplayValue: function(columns) {
					columns.sortByFn(function(column1, column2) {
						var displayValue1 = this.getColumnDisplayValue(column1);
						var displayValue2 = this.getColumnDisplayValue(column2);
						return displayValue1.localeCompare(displayValue2);
					}, this);
				},

				/**
				 * Returns entity schema lookup columns.
				 * @private
				 * @param {BPMSoft.EntitySchema} entitySchema Entity schema.
				 */
				getEntitySchemaLookupColumns: function(entitySchema) {
					return entitySchema.columns.filter(function(column) {
						return column.dataValueType === BPMSoft.DataValueType.LOOKUP;
					});
				},

				/**
				 * Exclude from columns collection columns with passed uIds.
				 * @private
				 * @param {BPMSoft.Collection} columns Entity schema columns collection.
				 * @param {String[]} excludeColumnUIds Columns uIds to exclude from collection.
				 */
				excludeColumns: function(columns, excludeColumnUIds) {
					return columns.filter(function(column) {
						return excludeColumnUIds.indexOf(column.uId) === -1;
					});
				},

				/**
				 * Returns entity schema column display value.
				 * @private
				 * @param {BPMSoft.manager.EntitySchemaColumn} column Entity schema column.
				 * @return {String} Display value.
				 */
				getColumnDisplayValue: function(column) {
					return column.caption.getValue() || column.name;
				},

				/**
				 * Validates Stage column.
				 * @private
				 */
				stageColumnValidator: function() {
					var invalidMessage = "";
					var stageColumn = this.get("StageColumn");
					if (!stageColumn) {
						invalidMessage = BPMSoft.Resources.BaseViewModel.columnRequiredValidationMessage;
					}
					return {
						invalidMessage: invalidMessage
					};
				},

				/**
				 * Shows response error if exists.
				 * @private
				 * @param {BPMSoft.core.BaseResponse} response Service response.
				 */
				showResponseError: function(response) {
					var message = response.errorInfo ? response.errorInfo.message : response.statusText;
					this.error(message);
					BPMSoft.showErrorMessage(message);
				},

				/**
				 * Deactivates all cases where StageColumn not equal to current.
				 * @private
				 * @param {BPMSoft.Collection} items DcmSchemaManager items for deactivate.
				 * @param {Function} callback The callback function.
				 * @param {Boolean} callback.success Deactivate result.
				 * @param {Object} scope The scope of callback function.
				 */
				deactivateCases: function(items, callback, scope) {
					var schemaUIds = items.getItems().map(function(item) {
						return item.getUId();
					});
					var config = {
						items: schemaUIds,
						enabled: false
					};
					BPMSoft.DcmSchemaManager.setEnabled(config, function(response) {
						if (response.success) {
							this.sandbox.publish("ReloadDcmLibGridData");
							this.saveSectionDcmSettings(function() {
								callback.call(scope, true);
							}, this);
						} else {
							callback.call(scope, false);
							this.showResponseError(response);
						}
					}, this);
				},

				/**
				 * Saves all data to manager.
				 * @private
				 * @param {Function} callback The callback function.
				 * @param {Object} scope The scope of callback function.
				 */
				saveSectionDcmSettings: function(callback, scope) {
					this.onSave();
					var packageUId = this.get("PackageUId");
					BPMSoft.SysDcmSettingsManager.saveAndUpdateSchemaData(packageUId, callback, scope);
				},

				/**
				 * Confirms changing StageColumn field.
				 * @private
				 * @param {String} message Confirm user message.
				 * @param {Object} handlers Object with handlers for user answers: yes, cancel
				 * @param {Object} scope The scope of handlers callback method.
				 */
				confirmChangeStageColumn: function(message, handlers, scope) {
					var changeButton = {
						className: "BPMSoft.Button",
						returnCode: BPMSoft.MessageBoxButtons.YES.returnCode,
						caption: resources.localizableStrings.DeactivateButtonCaption
					};
					this.showConfirmationDialog(message, function(returnCode) {
						handlers[returnCode].call(scope);
					}, [changeButton, BPMSoft.MessageBoxButtons.CANCEL.returnCode], {defaultButton: 0});
				},

				/**
				 * Reverts changes for not valid attributes.
				 * @private
				 */
				revertNotValidAttributes: function() {
					BPMSoft.each(this.validationInfo.attributes, function(attribute, attributeName) {
						if (!attribute.isValid) {
							this.revertAttributeChanges(attributeName);
						}
					}, this);
				},

				/**
				 * Shows validation message.
				 * @private
				 */
				showValidationMessage: function() {
					var message = this.getValidationMessage();
					this.showInformationDialog(message);
				},

				/**
				 * Publish message to finish init.
				 * @private
				 */
				sectionDcmSettingsInitialized: function() {
					var sandbox = this.sandbox;
					sandbox.publish("SectionDcmSettingsInitialized", null, [sandbox.id]);
				},

				/**
				 * Sets SysDcmSettings item properties.
				 * @private
				 * @param {BPMSoft.SysDcmSettingsManagerItem} sysDcmSettingsItem Section SysDcmSettings item.
				 */
				_setSysDcmSettingsItemProperties: function(sysDcmSettingsItem) {
					var stageColumn = this.$StageColumn;
					var filters = this.$Filters;
					var filterColumn = this.$FilterColumn;
					if (filters) {
						filters[0] = {
							columnUId: filterColumn ? filterColumn.value : null
						};
						sysDcmSettingsItem.setStageColumnUId(stageColumn ? stageColumn.value : null);
						sysDcmSettingsItem.setFilters(filters);
					}
				},

				//endregion

				//region Methods: Protected

				/**
				 * @inheritdoc BPMSoft.configuration.BaseSchemaViewModel#init
				 * @protected
				 * @overridden
				 */
				init: function(callback, scope) {
					this.subscribeSandboxEvents();
					this.initializeColumns();
					this.setValidationConfig();
					this.subscribeForColumnEvents();
					callback.call(scope);
					var sysModuleEntityId = this.get("SysModuleEntityId");
					if (!sysModuleEntityId) {
						this.sectionDcmSettingsInitialized();
					} else {
						BPMSoft.chain(
							this.initializeSysDcmSettingsManager,
							this.initializeSysDcmSettingsItem,
							this.initializeSectionEntitySchema,
							this.initializeColumnValues,
							this.initializeSysDcmSchemaInSettingsManager,
							function() {
								this.sectionDcmSettingsInitialized();
							}, this
						);
					}
				},

				/**
				 * Initialize view model columns.
				 * @protected
				 */
				initializeColumns: function() {
					this.set("DcmSchemaList", Ext.create("BPMSoft.Collection"));
					this.set("StageColumnsList", Ext.create("BPMSoft.Collection"));
					this.set("FilterColumnsList", Ext.create("BPMSoft.Collection"));
				},

				/**
				 * Creates SysDcmSettingsManagerItem and adds it to manager.
				 * @protected
				 * @param {String} sysModuleEntityId SysModuleEntity id.
				 * @param {Function} callback Callback function.
				 * @param {BPMSoft.manager.SysDcmSettingsManagerItem} callback.sysDcmSettingsItem Initialized
				 * manager item.
				 * @param {Object} scope Callback function call context.
				 */
				createSysDcmSettingsItem: function(sysModuleEntityId, callback, scope) {
					var config = this.getSysDcmSettingsItemConfig(sysModuleEntityId);
					BPMSoft.SysDcmSettingsManager.createItem(config, function(item) {
						var sysDcmSettingsItem = BPMSoft.SysDcmSettingsManager.addItem(item);
						callback.call(scope, sysDcmSettingsItem);
					}, this);
				},

				/**
				 * Returns config for new SysDcmSettingsManagerItem.
				 * @protected
				 * @param {String} sysModuleEntityId SysModuleEntity id.
				 * @return {Object}
				 */
				getSysDcmSettingsItemConfig: function(sysModuleEntityId) {
					return {
						propertyValues: {
							sysModuleEntity: {
								value: sysModuleEntityId
							}
						}
					};
				},

				/**
				 * Validates section dcm settings. Revert SysDcmSettingsItem changes if flag revertChanges is true.
				 * @protected
				 * @param {Object} [config]
				 * @param {Boolean} config.revertChanges Revert changes if not validate.
				 * @return {Boolean} Returns flag that indicates whether view model is valid.
				 */
				onValidate: function(config) {
					var isValid = this.validate();
					if (!isValid) {
						if (config && config.revertChanges) {
							this.revertNotValidAttributes();
							isValid = true;
						} else {
							this.showValidationMessage();
						}
					}
					return isValid;
				},

				/**
				 * Saves section dcm settings into client SysDcmSettings manager.
				 * After save, publish OnSectionDcmSettingsSaved message.
				 * @protected
				 */
				onSave: function() {
					var sysDcmSettingsItem = this.$SysDcmSettingsItem;
					var sspSysDcmSettingsItem = this.$SspSysDcmSettingsItem;
					this._setSysDcmSettingsItemProperties(sysDcmSettingsItem);
					if (!Ext.isEmpty(sspSysDcmSettingsItem)) {
						this._setSysDcmSettingsItemProperties(sspSysDcmSettingsItem);
					}
				},

				/**
				 * Returns image config for cases icon.
				 * @protected
				 * @return {Object} Image config.
				 */
				getCasesImageConfig: function() {
					var imageUrl = BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.CasesIcon);
					return {
						source: BPMSoft.ImageSources.URL,
						url: imageUrl
					};
				},

				/**
				 * @inheritdoc BaseSchemaViewModel#setValidationConfig
				 * @overridden
				 */
				setValidationConfig: function() {
					this.callParent(arguments);
					this.addColumnValidator("StageColumn", this.stageColumnValidator);
				},

				/**
				 * Finds filter column name.
				 * @private
				 * @return {String|null}
				 */
				findFilterColumnName: function() {
					var filterColumn = this.get("FilterColumn");
					var columnName = null;
					if (filterColumn) {
						var entitySchema = this.get("SectionEntitySchema");
						var columns = entitySchema.columns;
						var column = columns.get(filterColumn.value);
						columnName = column.name;
					}
					return columnName;
				},

				/**
				 * Finds item to deactivate.
				 * @private
				 * @param {BPMSoft.Collection} items Items.
				 * @return {BPMSoft.Collection}
				 */
				findItemsToDeactivate: function(items) {
					var filterColumnName = this.findFilterColumnName();
					var stageColumn = this.get("StageColumn");
					return items.filterByFn(function(item) {
						var isEqualsStageColumns = item.stageColumnUId === stageColumn.value;
						var filterGroup = item.getFilterGroup();
						var filter = filterGroup.first();
						var isEmptyFilters = !filter && Ext.isEmpty(filterColumnName);
						var isEqualsFilters = isEmptyFilters
							|| filter && filterColumnName === filter.leftExpression.columnPath;
						return !isEqualsStageColumns || !isEqualsFilters;
					});
				},

				/**
				 * Deactivates cases where column changed.
				 * @private
				 * @param {Object} config Configuration object.
				 * @param {Function} config.initializeColumnValueFn Initialize column value function.
				 * @param {String} config.templateMessage Template Message.
				 */
				deactivateCasesOnColumnChange: function(config) {
					this.showBodyMask();
					this.getSectionDcmSchemaManagerItems(function(items) {
						var itemsToDeactivate = this.findItemsToDeactivate(items);
						var count = itemsToDeactivate.getCount();
						if (count === 0) {
							this.saveSectionDcmSettings(function() {
								this.hideBodyMask();
							}, this);
							return;
						}
						var message = Ext.String.format(config.templateMessage, count);
						this.confirmChangeStageColumn(message, {
							yes: function() {
								this.deactivateCases(itemsToDeactivate, function(result) {
									if (!result) {
										config.initializeColumnValueFn.call(this);
									}
									this.hideBodyMask();
								}, this);
							},
							cancel: function() {
								config.initializeColumnValueFn.call(this);
								this.hideBodyMask();
							}
						}, this);
					}, this);
				},

				/**
				 * Handler for StageColumn attribute changes.
				 * @protected
				 * @param {Object} viewModel Lookup viewModel.
				 * @param {Object} lookupValue New lookup record.
				 * @param {Object} options Event options.
				 */
				onStageColumnChange: function(viewModel, lookupValue, options) {
					var value = lookupValue && lookupValue.value;
					var changedByUser = options && options.changeEvent === "change";
					if (!changedByUser || !value) {
						return;
					}
					this.deactivateCasesOnColumnChange({
						templateMessage: resources.localizableStrings.DeactivateCasesOnChangeStageColumnConfirmMessage,
						initializeColumnValueFn: this.initializeStageColumnValue
					});
				},

				/**
				 * Handler for FilterColumn attribute changes.
				 * @protected
				 * @param {Object} viewModel Lookup viewModel.
				 * @param {Object} lookupValue New lookup record.
				 * @param {Object} options Event options.
				 */
				onFiltersColumnChange: function(viewModel, lookupValue, options) {
					var changedByUser = options && options.changeEvent === "change";
					var stageColumn = this.get("StageColumn");
					if (!changedByUser || !stageColumn) {
						return;
					}
					this.deactivateCasesOnColumnChange({
						templateMessage: resources.localizableStrings.DeactivateCasesOnChangeFilterColumnConfirmMessage,
						initializeColumnValueFn: this.initializeFilterColumnValue
					});
				},

				/**
				 * Handler for message EnabledDcmSchemas.
				 * @protected
				 * @param {Object} config Configuration object.
				 * @param {String[]} config.items Array schema UIds.
				 * @param {Boolean} config.enabled Enabled property value.
				 */
				onEnabledDcmSchemas: function(config) {
					if (config.enabled === false) {
						this.saveSectionDcmSettings(BPMSoft.emptyFn, this);
					}
				}

				//endregion

			},
			diff: [
				{
					"operation": "insert",
					"name": "SectionSettings",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": {
							"wrapClassName": [
								"sys-dcm-settings"
							]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "SectionSettings",
					"propertyName": "items",
					"name": "CasesColumns",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"labelConfig": {
							"classes": ["section-caption"]
						},
						"caption": resources.localizableStrings.columnLabel
					}
				},
				{
					"operation": "insert",
					"name": "StageColumn",
					"parentName": "SectionSettings",
					"propertyName": "items",
					"values": {
						"dataValueType": BPMSoft.DataValueType.ENUM,
						"controlConfig": {
							"list": {"bindTo": "StageColumnsList"},
							"prepareList": {"bindTo": "prepareStageColumnsList"},
							"filterComparisonType": BPMSoft.StringFilterType.CONTAIN
						},
						"labelConfig": {
							"isRequired": true
						}
					}
				},
				{
					"operation": "insert",
					"name": "FilterColumn",
					"parentName": "SectionSettings",
					"propertyName": "items",
					"values": {
						"dataValueType": BPMSoft.DataValueType.ENUM,
						"controlConfig": {
							"list": {"bindTo": "FilterColumnsList"},
							"prepareList": {"bindTo": "prepareFilterColumnsList"}
						}
					}
				}
			]
		};
	}
);
