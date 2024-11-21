define("ForecastMiniPage", ["ForecastMiniPageResources", "ForecastConstants", "SysAdminUnit", "BusinessRuleModule", "GoogleTagManagerUtilities", "ForecastHierarchyItemViewModel",
		"ForecastEntityLookupMixin", "ApplicationStructureWizardUtils", "css!ForecastMiniPageCSS", "css!ForecastColumnDesignerMiniPage"],
	function(resources, ForecastConstants, SysAdminUnit, BusinessRuleModule, GoogleTagManagerUtilities) {
		return {
			entitySchemaName: "ForecastSheet",
			properties: {
				parentSchemaUId: "3a622ca4-e1ea-4273-8b41-c20129310fd7",
				initialSettings: {
					autoCalculation: {
						isEnabled: false
					},
					autoSnapshot: {
						isEnabled: false
					}
				}
			},
			attributes: {
				/**
				 * @inheritDoc BaseMiniPage#MiniPageModes
				 * @override
				 */
				"MiniPageModes": {
					"value": [
						this.BPMSoft.ConfigurationEnums.CardOperation.ADD,
						this.BPMSoft.ConfigurationEnums.CardOperation.EDIT,
						this.BPMSoft.ConfigurationEnums.CardOperation.COPY
					]
				},
				/**
				 * Forecast entity.
				 */
				"ForecastEntity": {
					"dataValueType": BPMSoft.DataValueType.LOOKUP,
					"isLookup": true,
					"isRequired": true,
					"onChange": "onForecastEntityChanged"
				},

				/**
				 * Hierarchy collection.
				 */
				"HierarchyData": {
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Forecast settings config.
				 */
				"Setting": {
					"type": this.BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
					"value": "{}"
				},
				/**
				 * Forecast entity primary display column exist flag.
				 */
				"IsEntityPrimaryDisplayColumnExist": {
					"value": true
				},

				/**
				 * Is Forecast automatic calculation enabled.
				 */
				"IsAutoCalculateEnable": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": false,
					"onChange": "onAutoCalculateStatusChanged"
				},

				/**
				 * Is forecast automatic snapshot enabled.
				 */
				"IsAutoSnapshotEnable": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": false,
					"onChange": "onAutoSnapshotChanged"
				},

				/**
				 * Is forecast automatic snapshot enabled.
				 */
				"IsTimeZoneRequired": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": false
				},

				/**
				 * The default crone expression.
				 */
				"DefaultCronExpression": {
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": "0 */45 0-23 */1 * ? *"
				},

				/**
				 * The minute crone expression validation config.
				 */
				"MinuteCronExpressionValidationConfig": {
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": {
						min: 15
					}
				},

				/**
				 * Is forecast auto calculation feature enabled.
				 */
				"IsForecastAutoCalculationFeatureEnabled": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"value": BPMSoft.Features.getIsEnabled("ForecastAutoCalculation")
				},

				/**
				 * Is forecast snapshot feature enabled.
				 */
				"IsForecastSnapshotFeatureEnabled": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"value": BPMSoft.Features.getIsEnabled("ForecastSnapshot")
				},

				/**
				 * Period of process run in minutes/hours.
				 */
				"AutoSnapshotTime": {
					"dataValueType": BPMSoft.DataValueType.TIME,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": new Date(0, 0, 0, 3, 0)
				},

				/**
				 * Time zones collection.
				 * @private
				 * @type {BPMSoft.Collection}
				 */
				"TimeZoneList": {
					"dataValueType": this.BPMSoft.DataValueType.COLLECTION
				},

				/**
				 * Selected time zone item.
				 * @private
				 * @type {Object}
				 * */
				"TimeZone": {
					"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
				},

				/**
				 * Default utc time zone identifier.
				 * @private
				 * @type {Object}
				 * */
				"DefaultTimeZoneId": {
					"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
					'value': "8BC71D34-55D8-DF11-9B2A-001D60E938C6"
				},

				/**
				 * Time zone offset.
				 * @private
				 * @type {String}
				 * */
				"TimeZoneOffset": {
					"dataValueType": this.BPMSoft.DataValueType.STRING,
					"value": "US Mountain Standard Time"
				}
			},
			messages: {
				/**
				 * Message of saving forecast result.
				 */
				"SetForecastResult": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message StructureExplorerInfo
				 * Returns settings for Structure explorer modal box.
				 */
				"StructureExplorerInfo": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message ColumnSelected
				 * Returns selected column config.
				 */
				"ColumnSelected": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message GetHierarchyCollection
				 * Gets hierarchy collection.
				 */
				"GetHierarchyCollection": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.BIDIRECTIONAL
				},

				/**
				 * @message DeleteHierarchyItem
				 * Delete hierarchy item.
				 */
				"DeleteHierarchyItem": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.BIDIRECTIONAL
				},

				/**
				 * @message GetCronExpression
				 * Gets crone expression.
				 */
				"GetCronExpression": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message GetMinuteHourPeriodType
				 * Gets minute or hour cron expression period type.
				 */
				"GetMinuteHourPeriodType": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			mixins: {
				ForecastEntityLookupMixin: "BPMSoft.ForecastEntityLookupMixin"
			},
			methods: {

				/**
				 * @inheritDoc BPMSoft.BaseMiniPage#init
				 * @override
				 */
				init: function() {
					const collection = new BPMSoft.BaseViewModelCollection();
					collection.on("itemChanged", this.addHierarchy, this);
					this.set("HierarchyData", collection);
					this.callParent(arguments);
					this.subscribeSandboxMessages();
					this.initTabs();
				},

				/**
				 * @inheritDoc BaseMiniPage#onEntityInitialized
				 * @protected
				 * @override
				 */
				onEntityInitialized: function() {
					this.miniPageContainerBottomOffset = 120;
					this.callParent(arguments);
				},

				/**
				 * @inheritDoc BPMSoft.BaseMiniPage#init
				 * @override
				 */
				destroy: function() {
					this.$HierarchyData.un("itemChanged", this.addHierarchy, this);
					this.callParent(arguments);
				},

				/**
				 * @inheritDoc BPMSoft.BaseMiniPage#onPageInitialized
				 * @override
				 */
				onPageInitialized: function(callback, scope) {
					this.callParent([function() {
						this.viewModel.mixins.ForecastEntityLookupMixin.init(callback, scope);
					}, scope || this]);
				},

				/**
				 * Subscribes for sandbox messages.
				 * @protected
				 * @virtual
				 */
				subscribeSandboxMessages: function() {
					this.sandbox.subscribe("GetHierarchyCollection", this.getHierarchyData, this, []);
					this.sandbox.subscribe("DeleteHierarchyItem", this.deleteHierarchyItem, this, []);
				},

				/**
				 * Deletes hierarchy item by id.
				 * @param {String} id Item id.
				 */
				deleteHierarchyItem: function(id) {
					const data = this.getHierarchyData();
					data.removeByKey(id);
					data.each(function(item, index) {
						item.set("Level", index + 1);
					});
				},

				/**
				 * @inheritDoc BaseMiniPage#getMiniPageHeader
				 * @protected
				 * @override
				 */
				getMiniPageHeader: function() {
					if (this.isAddMode()) {
						return this.get("Resources.Strings.NewPlanCaption");
					}
					if (this.isEditMode()) {
						return this.get("Resources.Strings.EditPlanCaption");
					}
					return this.BPMSoft.emptyString;
				},

				/**
				 * @inheritDoc BaseMiniPage#initEntity
				 * @protected
				 * @override
				 */
				initEntity: function(callback, scope) {
					this.callParent([function() {
						this.BPMSoft.chain(
							this._initForecastColumnReferenceSchema,
							this._initForecastReferenceSchema,
							this.initHierarchy,
							this._initValuesFromSettings,
							function() {
								this.Ext.callback(callback, scope);
							},
							this
						);
					}, this]);
				},

				/**
				 * Initializes hierarchy from Setting config.
				 * @protected
				 * @virtual
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback scope.
				 */
				initHierarchy: function(callback, scope) {
					const settings = this.getSettingsObj();
					if (settings && settings.hierarchy) {
						settings.hierarchy.forEach(function(item, index) {
							this._setHierarchyItem(index, item);
						}, this);
						if (this.isEditMode() && settings.hierarchy.length > 0) {
							const level = settings.hierarchy.length + 1;
							this._addEmptyHierarchyItem(level);
						}
					}
					this.Ext.callback(callback, scope);
				},


				/**
				 * @inheritDoc BPMSoft.BaseMiniPage#save
				 * @override
				 */
				save: function() {
					const forecastEntityId = this.$ForecastEntity && this.$ForecastEntity.value;
					if (this.isEmpty(forecastEntityId)) {
						return;
					}
					const isAutoCalculationSettingsNotValid = !this._validateAutoCalculationSettings();
					if (isAutoCalculationSettingsNotValid) {
						return;
					}
					this._updateSettings();
					this.saveHierarchy();
					const parentMethod = this.getParentMethod(this, arguments);
					this._getForecastEntityInCellUId(forecastEntityId, function(forecastEntityInCellUId) {
						var isValid = this.validate();
						if (!isValid) {
							return;
						}
						if (this.isNotEmpty(forecastEntityInCellUId)) {
							this.$ForecastEntityInCellUId = forecastEntityInCellUId;
							parentMethod();
						} else {
							this.BPMSoft.chain(
								this._addEntity,
								parentMethod,
								this
							);
						}
					}, this);
					this._addGTMForAutoCalculate();
					this._addGTMForSnapshot();
				},

				/**
				 * Saves hierarchy to settings config.
				 * @protected
				 * @virtual
				 */
				saveHierarchy: function() {
					const hierarchyData = this.getHierarchyData();
					const settings = this.getSettingsObj();
					settings.hierarchy = [];
					hierarchyData.each(function(item, index) {
						const columnPath = item.get("ColumnPath");
						if (columnPath) {
							settings.hierarchy.push({
								"columnPath": columnPath,
								"level": index
							});
						}
					});
					this.set("Setting", JSON.stringify(settings));
				},

				/**
				 * @private
				 */
				_addGTMForAutoCalculate: function() {
					if (this.$IsAutoCalculateEnable &&!this.initialSettings.autoCalculation.isEnabled) {
						var data = this._getGoogleTagManagerData(ForecastConstants.GTMEventActions.ForecastAutoCalculateEnabled);
						GoogleTagManagerUtilities.actionModule(data);
					}
				},

				/**
				 * @private
				 */
				_addGTMForSnapshot: function() {
					if (this.initialSettings.autoSnapshot.isEnabled !== this.$IsAutoSnapshotEnable) {
						var action = this.$IsAutoSnapshotEnable 
							? ForecastConstants.GTMEventActions.ForecastSnapshotEnabled 
							: ForecastConstants.GTMEventActions.ForecastSnapshotDisabled;
						var data = this._getGoogleTagManagerData(action);
						GoogleTagManagerUtilities.actionModule(data);
					}
				},

				/**
				 * @private
				 */
				_getGoogleTagManagerData: function(action) {
					return {
						action: action,
						moduleName: "ForecastsModule",
						schemaName: this.entitySchemaName
					};
				},

				/**
				 * @private
				 */
				_getSectionId: function() {
					return this.sandbox.id + "_module_BaseSchemaModuleV2";
				},

				/**
				 * @private
				 */
				_addEmptyHierarchyItem: function(level) {
					const hierarchyData = this.getHierarchyData();
					const viewModel = this.createHierarchyViewModel(level);
					hierarchyData.add(viewModel.get("Id"), viewModel);
				},

				/**
				 * @private
				 */
				_setHierarchyItem: function(index, item) {
					const hierarchyData = this.getHierarchyData();
					const viewModel = this.createHierarchyViewModel(index + 1, item.columnPath);
					this._getColumnCaption(item.columnPath, function(columnCaption) {
						viewModel.set("ColumnCaption", columnCaption);
					}, this);
					hierarchyData.add(viewModel.get("Id"), viewModel);
				},

				/**
				 * @private
				 */
				_getColumnCaption: function(path, callback, scope) {
					if (path.includes('.')) {
						this._loadHierarchyItemCaption(this.$ForecastEntity.value, path, callback, scope);
					} else {
						const schema = this.get("ForecastReferenceSchema");
						const column = schema.columns[path];
						if (column) {
							this.Ext.callback(callback, scope, [column.caption])
						}
					}
				},

				/**
				 * @private
				 */
				_initValuesFromSettings: function(callback, scope) {
					const settings = this.getSettingsObj();
					if (settings) {
						this._initAutoCalculation(settings.autoCalculation);
						this._initAutoSnapshot(settings.autoSnapshot);
						this._fillInitialSettings(settings);
						var timezoneId = settings.timeZoneId ?? this.$DefaultTimeZoneId;
						this.$TimeZone = this._getCurrentTimeZoneInfo(callback, scope, timezoneId)
					} else {
						this.Ext.callback(callback, scope);
					}
				},

				/**
				 * @private
				 */
				_fillInitialSettings: function(settings) {
					if (settings.autoCalculation || settings.autoSnapshot) {
						this.Ext.apply(this.initialSettings, settings);
					}
				},

				/**
				 * @private
				 */
				_initAutoCalculation: function(autoCalcSettings) {
					if (autoCalcSettings && autoCalcSettings.isEnabled) {
						this.set("CronExpression", autoCalcSettings.cronExpression);
						this.set("IsAutoCalculateEnable", autoCalcSettings.isEnabled);
						this.set("IsCronValid", true);
					}
				},

				/**
				 * @private
				 */
				_initAutoSnapshot: function(autoSnapshotSettings) {
					if (autoSnapshotSettings && autoSnapshotSettings.isEnabled) {
						this.set("IsAutoSnapshotEnable", autoSnapshotSettings.isEnabled);
						if (autoSnapshotSettings.time) {
							const time = autoSnapshotSettings.time;
							this.set('AutoSnapshotTime', new Date(0, 0, 0, time.hours, time.minutes))
						}
					}
				},

				/**
				 * @private
				 */
				_updateSettings: function() {
					const settings = this.getSettingsObj();
					this._updateAutoCalculationSettings(settings);
					this._updateAutoSnapshotSettings(settings);
					settings.timeZoneId = this.$TimeZone?.value;
					this.set("Setting", JSON.stringify(settings));
				},

				/**
				 * @private
				 */
				_updateAutoSnapshotSettings: function(settings) {
					if (!this.$IsForecastSnapshotFeatureEnabled) {
						return;
					}
					settings.autoSnapshot = {
						isEnabled: this.$IsAutoSnapshotEnable
					};
					if (this.$AutoSnapshotTime) {
						settings.autoSnapshot.time = {
							hours: this.$AutoSnapshotTime?.getHours(),
							minutes: this.$AutoSnapshotTime?.getMinutes()
						}
					}
				},

				/**
				 * @private
				 */
				_updateAutoCalculationSettings: function(settings) {
					if (!this.$IsForecastAutoCalculationFeatureEnabled) {
						return;
					}
					const cronExpression = this.$IsAutoCalculateEnable
						? this.sandbox.publish("GetCronExpression", null, [this._getSectionId()])
						: undefined;
					settings.autoCalculation = {
						isEnabled: this.$IsAutoCalculateEnable,
						cronExpression: cronExpression
					};
				},

				/**
				 * @private
				 */
				_validateAutoCalculationSettings: function() {
					if (this.$IsAutoCalculateEnable && 
						this.$IsForecastAutoCalculationFeatureEnabled && 
						this.$AutomationInfoTabInitialized) {
						const cronExpression = this.sandbox.publish("GetCronExpression", null, [this._getSectionId()]);
						const validationConfig = this._getCroneExpressionValidationConfig();
						const info = this.BPMSoft.CronExpression.validate(cronExpression, validationConfig);
						this._setCronValidationInfo(info);
						if (!info.isValid) {
							return false;
						}
					}
					return true;
				},

				/**
				 * @private
				 */
				_getCroneExpressionValidationConfig: function() {
					const cronExpressionType = this.sandbox.publish("GetMinuteHourPeriodType", null, [this._getSectionId()]);
					if (cronExpressionType && cronExpressionType.value === BPMSoft.cron.Parameters.Minutes) {
						return {
							minutes: this.$MinuteCronExpressionValidationConfig
						};
					}
				},

				/**
				 * @private
				 */
				_setCronValidationInfo: function(info) {
					this.set("CronValidationErrorMessage", info.error);
					this.set("IsCronValid", info.isValid);
				},

				/**
				 * @private
				 */
				_loadHierarchyItemCaption: function(schemaUid, columnPath, callback, scope) {
					var schemaColumnInformationRequest = {
						getSchemaColumnInformation: {
							entitySchemaUId: schemaUid,
							SchemaColumnPath: columnPath
						}
					};
					this.BPMSoft.SchemaDesignerUtilities.execute(schemaColumnInformationRequest, function(response) {
						if (response) {
							const metaPath = schemaUid + "." + response.getSchemaColumnInformationResponse.columnMetaPath;
							this.BPMSoft.SchemaDesignerUtilities.getColumnCaptionPathByMetaPath(metaPath, callback, scope);
						}
					}, this);
				},

				/**
				 * @private
				 */
				_initForecastColumnReferenceSchema: function(callback, scope) {
					const forecastEntitySchemaName = this.$EntitySchemaName;
					this.BPMSoft.require([forecastEntitySchemaName], function(schema) {
						this.set("ForecastColumnReferenceSchema", schema);
						this.Ext.callback(callback, scope);
					}, this);
				},

				/**
				 * @private
				 */
				_getSchemaName: function() {
					const entitySchema = this.$ForecastEntity;
					if (entitySchema) {
						if (entitySchema.Name) {
							return entitySchema.Name;
						}
						const referenceSchema = this.BPMSoft.EntitySchemaManager.getItem(entitySchema.value);
						entitySchema.Name = referenceSchema.name;
						this.set("ForecastEntity", entitySchema);
						return entitySchema.Name;
					}
					return "";
				},

				/**
				 * @private
				 */
				_initForecastReferenceSchema: function(callback, scope) {
					let schemaName = this._getSchemaName();
					const schema = this.BPMSoft[schemaName];
					if (this.isNotEmpty(schema)) {
						this.set("ForecastReferenceSchema", schema);
						this.Ext.callback(callback, scope);
						return;
					}
					this.BPMSoft.require([schemaName], function(schema) {
						this.set("ForecastReferenceSchema", schema);
						this.Ext.callback(callback, scope);
					}, this);
				},

				/**
				 * @inheritDoc BPMSoft.BaseMiniPage#onSaved
				 * @override
				 */
				onSaved: function() {
					if (this.isEditMode()) {
						this._publishSetForecastResult();
					} else {
						this._addForecastColumns(this._publishSetForecastResult);
					}
				},

				/**
				 * Adds forecast columns.
				 * @param {Function} callback Callback function.
				 * @private
				 */
				_addForecastColumns: function(callback) {
					const query = this.getInsertForecastColumnQuery();
					query.execute(function(response) {
						if (response.success) {
							this.Ext.callback(callback, this);
						}
					}, this);
				},

				/**
				 * Returns inesrt query of forecast column insert.
				 * @return {BPMSoft.InsertQuery} Insert query of forecast column insert.
				 * @protected
				 */
				getInsertForecastColumnQuery: function() {
					const insertEsq = this.Ext.create("BPMSoft.InsertQuery", {
						rootSchemaName: "ForecastColumn"
					});
					insertEsq.setParameterValue("Sheet", this.$Id, this.BPMSoft.DataValueType.GUID);
					insertEsq.setParameterValue("Type", ForecastConstants.ColumnType.Editable,
						this.BPMSoft.DataValueType.GUID);
					insertEsq.setParameterValue("Position", 0, this.BPMSoft.DataValueType.INTEGER);
					insertEsq.setParameterValue("Title", this.get("Resources.Strings.EditColumnCaption"),
						this.BPMSoft.DataValueType.TEXT);
					return insertEsq;
				},

				/**
				 * Forms ForecastColumn Settings column value.
				 * @protected
				 * @param {BPMSoft.EntitySchema} schema ForecastColumn reference schema.
				 * @return {Object} Settings column value.
				 */
				formForecastColumnSettingValue: function(schema) {
					const periodColumn = this._getSchemaColumnByName(schema, "DueDate");
					const refColumn = this._getSchemaColumn(schema, {
						"referenceSchemaName": this.$ForecastEntity.Name
					});
					const config = {
						sourceUId: schema.uId,
						periodColumn: periodColumn && periodColumn.uId || "",
						refColumnId: refColumn && refColumn.uId || ""
					};
					return JSON.stringify(config);
				},

				/**
				 * @private
				 */
				_getSchemaColumnByName: function(schema, name) {
					return this._getSchemaColumn(schema, {"name": name});
				},

				/**
				 * @private
				 */
				_getSchemaColumn: function(schema, filter) {
					return this.BPMSoft.findWhere(schema.columns, filter);
				},

				/**
				 * @private
				 */
				_publishSetForecastResult: function() {
					const result = {
						forecastId: this.$Id,
						forecastName: this.$Name,
						forecastForecastEntityInCellUId: this.$ForecastEntityInCellUId,
						forecastEntityId: this.$ForecastEntity.value,
						forecastEntityName: this.$ForecastEntity.Name,
						forecastSetting: this.$Setting
					};
					this.sandbox.publish("SetForecastResult", result, [this.sandbox.id]);
					this.hideBodyMask();
					this.close();
				},

				/**
				 * Returns hierarchy collection.
				 * @return {BPMSoft.BaseViewModelCollection} Hierarchy collection
				 */
				getHierarchyData: function() {
					let data = this.get("HierarchyData");
					if (!data) {
						data = this.Ext.create("BPMSoft.BaseViewModelCollection");
						this.set("HierarchyData", data);
					}
					return data;
				},

				/**
				 * Creates first hierarchy item.
				 */
				toggleHierarchyContainer: function() {
					const hierarchyData = this.getHierarchyData();
					if (hierarchyData.getCount() === 0) {
						this._addEmptyHierarchyItem();
						this.addNewHierarchyButtonClick();
					}
				},

				/**
				 * Clicks on new added hierarchy item.
				 */
				addNewHierarchyButtonClick: function() {
					const lookupButton = document.getElementsByClassName("hierarchy-select-column");
					if (lookupButton && lookupButton.length) {
						lookupButton[lookupButton.length - 1].click();
					}
				},

				/**
				 * Creates hierarchy view model item.
				 * @protected
				 * @param {Number} [level] Item level.
				 * @param {string} [columnPath] Item Column Path.
				 * @returns {BPMSoft.ForecastHierarchyItemViewModel}
				 */
				createHierarchyViewModel: function(level, columnPath) {
					level = level || 1;
					const entity = this.get("ForecastEntity") || {};
					const viewModel = this.Ext.create("BPMSoft.ForecastHierarchyItemViewModel", {
						sandbox: this.sandbox,
						entitySchemaName: entity.Name,
						values: {
							"Id": this.BPMSoft.generateGUID(),
							"Level": level,
							"ColumnPath": columnPath
						}
					});
					return viewModel;
				},

				/**
				 * Returns settings object.
				 * @protected
				 * @return {Object} Settings object.
				 */
				getSettingsObj: function() {
					const settings = this.get("Setting");
					return this.isNotEmpty(settings) && this.Ext.isString(settings) ? JSON.parse(settings) : {};
				},

				/**
				 * Generates configuration of the element view.
				 * @protected
				 * @param {Object} itemConfig Link to the configuration element of ContainerList.
				 */
				onGetItemConfig: function(itemConfig) {
					itemConfig.config = this.getHierarchyViewConfig();
				},


				/**
				 * Initializes time zone query columns.
				 * @protected
				 * @virtual
				 * @param {BPMSoft.EntitySchemaQuery} esq Entity schema query.
				 */
				initTimeZoneQueryColumns: function(esq) {
					esq.addColumn("Id");
					esq.addColumn("Name");
					esq.addColumn("Code");
				},

				/**
				 * Prepares time zone list item.
				 * @protected
				 * @virtual
				 * @param {Object} item Time zone list item.
				 * @return {Object}
				 */
				prepareTimeZoneListItem: function(item) {
					return {
						value: item.get("Id"),
						displayValue: item.get("Name"),
						code: item.get("Code")
					};
				},

				/**
				 * Gets is time zone control enabled.
				 * @protected
				 * @return {boolean}
				 */
				getIsTimeZoneControlEnabled: function() {
					return this.get("IsForecastSnapshotFeatureEnabled") && this.getIsAdditionalSettingsVisible();
				},

				/**
				 * Creates TimeZone entity schema query.
				 * @protected
				 * @return {BPMSoft.EntitySchemaQuery}
				 */
				createTimeZoneQuery: function() {
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {rootSchemaName: "TimeZone"});
					this.initTimeZoneQueryColumns(esq);
					return esq;
				},

				/**
				 * Returns the value of the "visibility" tabs for the container.
				 * @protected
				 * return {Boolean} Value of the "Visibility" tabs for the container.
				 */
				getTabsContainerVisible: function() {
					return !(this.get("TabsCollection").isEmpty());
				},

				/**
				 * Sets active tab.
				 * @protected
				 * @param {String} tabName Tab name.
				 */
				setActiveTab: function(tabName) {
					this.set("ActiveTabName", tabName);
				},

				/**
				 * Processing active tab changes.
				 * @protected
				 * @param {BPMSoft.BaseViewModel} activeTab Selected tab.
				 */
				activeTabChange: function(activeTab) {
					var activeTabName = activeTab.get("Name");
					var tabsCollection = this.get("TabsCollection");
					tabsCollection.eachKey(function(tabName, tab) {
						var tabContainerVisibleBinding = tab.get("Name");
						this.set(tabContainerVisibleBinding, false);
					}, this);
					this.set(activeTabName, true);
					if (activeTabName === "AutomationInfoTab") {
						this.$AutomationInfoTabInitialized = true;
					}
				},

				/**
				 * Initialize tabs values.
				 * @protected
				 */
				initTabs: function() {
					var defaultTabName = this.getDefaultTabName();
					if (defaultTabName) {
						this.setActiveTab(defaultTabName);
						this.set(defaultTabName, true);
					}
				},

				/**
				 * Return default tab name.
				 * @protected
				 * @return {String|null} Default tab name.
				 */
				getDefaultTabName: function() {
					const tabsCollection = this.get("TabsCollection");
					if (!tabsCollection || tabsCollection.isEmpty()) {
						return null;
					}
					var defaultTabName = this.get("DefaultTabName");
					if (!defaultTabName) {
						const firstTab = tabsCollection.getByIndex(0);
						defaultTabName = firstTab.get("Name");
						this.set("DefaultTabName", defaultTabName);
					}
					return defaultTabName;
				},
				
				/**
				 * Returns hierarchy item view config.
				 * @virtual
				 * @protected
				 * @return {Object} Hierarchy item view config.
				 */
				getHierarchyViewConfig: function() {
					const deleteIconImage = this.get("Resources.Images.CloseButtonImage");
					return {
						"id": "hierarchyColumnTextEdit",
						"className": "BPMSoft.Container",
						"classes": {"wrapClassName": ["control-width-15", "hierarchy-container-item"]},
						"items": [
							{
								"className": "BPMSoft.Label",
								"classes": {"labelClass": ["hierarchy-label"]},
								"caption": {"bindTo": "HierarchyLevelCaption"},
							},
							{
								"className": "BPMSoft.Container",
								"classes": {"wrapClassName": ["hierarchy-input-container"]},
								"items": [
									{
										"className": "BPMSoft.TextEdit",
										"value": {"bindTo": "ColumnCaption"},
										"markerValue": {"bindTo": "getMarkerValue"},
										"readonly": true,
										"rightIconClasses": ["custom-right-item", "lookup-edit-right-icon",
											"hierarchy-select-column"],
										"rightIconClick": {"bindTo": "openStructureExplorer"}
									},
									{
										"className": "BPMSoft.Button",
										"markerValue": {"bindTo": "getDeleteButtonMarkerValue"},
										"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
										"visible": {
											"bindTo": "ColumnPath",
											"bindConfig": {"converter": "isNotEmptyValue"}
										},
										"click": {"bindTo": "deleteHierarchyItem"},
										"classes": {"wrapperClass": ["delete-hierarchy-button"]},
										"imageConfig": deleteIconImage
									}
								]
							}
						]
					};
				},

				/**
				 * Returns CronExpression.
				 * @return {String}
				 */
				getStringCronExpression: function() {
					return this.get("CronExpression") || this.$DefaultCronExpression;
				},

				/**
				 * Returns if additional settings are visible.
				 * @return {Boolean} Is additional settings visible.
				 */
				getIsAdditionalSettingsVisible: function() {
					return this.$IsAutoSnapshotEnable || this.$IsAutoCalculateEnable;
				},
				
				/**
				 * Event handler for prepare list event of time zone lookup.
				 */
				onPrepareTimeZoneList: function() {
					this._loadTimeZones();
				},
				
				/**
				 * Handles forecast entity change event.
				 */
				onForecastEntityChanged: function() {
					this._verifyIsPrimaryDisplayColumnExist();
					this.getHierarchyData().reloadAll();
				},

				/**
				 * Handles auto calculate state changes.
				 */
				onAutoCalculateStatusChanged: function() {
					if (!this.$IsAutoCalculateEnable) {
						this.set("IsCronValid", true);
					}
					this.$IsTimeZoneRequired = this.getIsTimeZoneControlEnabled();
				},

				/**
				 * Handles auto snapshot state changes.
				 */
				onAutoSnapshotChanged: function() {
					this.$IsTimeZoneRequired = this.getIsTimeZoneControlEnabled();
				},
				
				/**
				 * Add item to hierarchy.
				 */
				addHierarchy: function() {
					const hierarchyData = this.getHierarchyData();
					const lastItem = hierarchyData.last();
					if (lastItem && this.isNotEmpty(lastItem.get("ColumnPath"))) {
						const level = hierarchyData.getCount() + 1;
						this._addEmptyHierarchyItem(level);
						this.addNewHierarchyButtonClick();
					}
				},

				/**
				 * Verifies that primary display column in forecast entity exists.
				 * @private
				 */
				_verifyIsPrimaryDisplayColumnExist: function() {
					if (this.$ForecastEntity && this.$IsEntityInitialized) {
						this.BPMSoft.require([this.$ForecastEntity.Name], function(schema) {
							this.set("IsEntityPrimaryDisplayColumnExist", !!schema.primaryDisplayColumn);
						}, this);
					}
				},

				/**
				 * @private
				 */
				_getCurrentTimeZoneInfo: function(callback, scope, timezoneId) {
					var esq = this.createTimeZoneQuery();
					return esq.getEntity(timezoneId, (response) => {
						if(response && response.success) {
							this.$TimeZone = this.prepareTimeZoneListItem(response.entity);
						}
						this.Ext.callback(callback, scope);
					});
				},


				/**
				 * @privates
				 */
				_addEntity: function(callback, scope) {
					let newSchema;
					let packageUId;
					const referenceSchema = this.BPMSoft.EntitySchemaManager.getItem(this.$ForecastEntity.value);
					this._showSavingMask();
					this.BPMSoft.chain(
						this.BPMSoft.PackageManager.getCustomPackageUId,
						function(next, customPackageUId) {
							packageUId = customPackageUId;
							const entityName = this.$ForecastEntity.Name;
							const newSchemaName =
								this.BPMSoft.EntitySchemaManager.getSchemaNamePrefix() + entityName + "Forecast";
							const existedSchema = this.BPMSoft.EntitySchemaManager.findItemByName(newSchemaName);
							if (this.isNotEmpty(existedSchema)) {
								this.$ForecastEntityInCellUId = existedSchema.uId;
								this.Ext.callback(callback, scope);
								return;
							}
							newSchema = this._createNewSchema(newSchemaName, customPackageUId, entityName);
							next();
						}, function(next) {
							newSchema.setParent(this.parentSchemaUId, next, this);
						}, function(next) {
							newSchema.define();
							const newEntitySchema = this.BPMSoft.EntitySchemaManager.addSchema(newSchema);
							this.BPMSoft.DataManager.initEntitySchemaDataCollection(newSchema.name);
							this.BPMSoft.ApplicationStructureWizardUtils
								.createLookupManagerItem(newEntitySchema, next, this);
						},
						function(next) {
							const column = this._createLookupColumn(referenceSchema);
							newSchema.addColumn(column);
							next();
						},
						function(next) {
							this.BPMSoft.EntitySchemaManager.save(next, this);
						},
						this._processResponse,
						function(next) {
							this._updateSavingMask(this.get("Resources.Strings.AddingNewObject"));
							this.BPMSoft.SchemaDesignerUtilities.buildChangedConfiguration(next, this);
						},
						this._processResponse,
						function(next) {
							this.BPMSoft.EntitySchemaManager.updateDBStructure({packageUId: packageUId}, next, this);
						},
						this._processResponse,
						function() {
							this.$ForecastEntityInCellUId = newSchema.uId;
							this._hideSavingMask();
							this.Ext.callback(callback, scope);
						},
						this
					);
				},

				/**
				 * @private
				 */
				_processResponse: function(next, response) {
					if (response && response.success) {
						this.Ext.callback(next, this);
					} else {
						this._clearSchemasModifiedStatus(response.items);
						this._hideSavingMask();
						this._showErrorMessage(response);
					}
				},

				/**
				 * @private
				 */
				_clearSchemasModifiedStatus: function(items) {
					items.each(function(item) {
						item.status = this.BPMSoft.ModificationStatus.NOT_MODIFIED;
					}, this);
				},

				/**
				 * @private
				 */
				_showErrorMessage: function(response) {
					const message = response.errorInfo.toString();
					this.BPMSoft.showInformation(message);
				},

				/**
				 * @private
				 */
				_updateSavingMask: function(maskCaption) {
					if (this.savingMaskId) {
						this.BPMSoft.Mask.updateCaption(this.savingMaskId, maskCaption);
					} else {
						this._showSavingMask(maskCaption);
					}
				},

				/**
				 * @private
				 */
				_showSavingMask: function(maskCaption) {
					this.savingMaskId = this.BPMSoft.Mask.show({caption: maskCaption, timeout: 0});
				},

				/**
				 * @private
				 */
				_hideSavingMask: function() {
					this.BPMSoft.Mask.hide(this.savingMaskId);
					this.savingMaskId = null;
				},

				/**
				 * @private
				 */
				_createNewSchema: function(newSchemaName, customPackageUId, entityName) {
					const newSchema = this.BPMSoft.EntitySchemaManager.createSchema({
						"uId": this.BPMSoft.generateGUID(),
						"name": newSchemaName,
						"packageUId": customPackageUId,
						"caption": {}
					});
					const caption = this.Ext.String.format(
						this.get("Resources.Strings.NewObjectCaptionTemplate"), entityName);
					newSchema.setLocalizableStringPropertyValue("caption", caption);
					return newSchema;
				},

				/**
				 * @private
				 */
				_createLookupColumn: function(referenceSchema) {
					const column = new this.BPMSoft.EntitySchemaColumn({
						name: this.BPMSoft.EntitySchemaManager.getSchemaNamePrefix() + referenceSchema.name,
						caption: new this.BPMSoft.LocalizableString(referenceSchema.caption)
					});
					column.dataValueType = this.BPMSoft.DataValueType.LOOKUP;
					column.referenceSchemaUId = referenceSchema.uId;
					column.isValueCloneable = true;
					column.isCascade = true;
					column.setNew();
					return column;
				},

				/**
				 * @private
				 */
				_getForecastEntityInCellUId: function(forecastEntityUId, callback, scope) {
					let schemaUId;
					this.BPMSoft.EntitySchemaManager.getItemByUId(forecastEntityUId, function(referenceSchema) {
						const childForecastEntityList = this.BPMSoft.EntitySchemaManager.filterByFn(function(item) {
							return item.parentUId === this.parentSchemaUId;
						}, this);
						let column;
						this.BPMSoft.eachAsync(childForecastEntityList.getItems(), function(item, next) {
							this.BPMSoft.require([item.name], function(schema) {
								column = this.BPMSoft.findWhere(schema.columns, {
									"isInherited": false,
									"referenceSchemaName": referenceSchema.name
								});
								if (this.isNotEmpty(column)) {
									schemaUId = schema.uId;
									this.Ext.callback(callback, scope || this, [schemaUId]);
									return;
								}
								next();
							}, this, next);
						}, function() {
							this.Ext.callback(callback, scope || this, [schemaUId]);
						}, this);
					}, this);
				},


				/**
				 * Load time zone from lookup
				 * @param callback
				 * @param scope
				 * @private
				 */
				_loadTimeZones: function(callback, scope) {
					var esq = this.createTimeZoneQuery();
					esq.getEntityCollection(function(response) {
						if (!response || !response.success) {
							return;
						}
						var list = this.$TimeZoneList;
						var columnList = {};
						var timeZoneOffset = this.$TimeZone && this.$TimeZone.code;
						if (!timeZoneOffset) {
							timeZoneOffset = this.$TimeZoneOffset;
						}
						response.collection.each(function(item) {
							var listItem = this.prepareTimeZoneListItem(item);
							columnList[item.get("Id")] = listItem;
							if (item.code === timeZoneOffset) {
								this.$TimeZone = listItem;
							}
						}, this);
						list.clear();
						list.loadAll(columnList);
						Ext.callback(callback, scope);
					}, this);
				},
			},
			rules: {
				"AutoSnapshotTime": {
					"RequiredRule": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.REQUIRED,
						"conditions": [
							{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "IsAutoSnapshotEnable"
								},
								"comparisonType": BPMSoft.ComparisonType.EQUAL,
								"rightExpression": {
									"type": BusinessRuleModule.enums.ValueType.CONSTANT,
									"value": true
								}
							}
						]
					}
				},
				"TimeZone": {
					"RequiredRule": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.REQUIRED,
						"conditions": [
							{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "IsTimeZoneRequired"
								},
								"comparisonType": BPMSoft.ComparisonType.EQUAL,
								"rightExpression": {
									"type": BusinessRuleModule.enums.ValueType.CONSTANT,
									"value": true
								}
							}
						]
					}
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "AlignableMiniPageContainer",
					"values": {
						"wrapClass": [
							"minipage-alignable-container",
							"forecast-minipage-alignable-container"
						]
					}
				},			
				{
					"operation": "remove",
					"name": "RequiredColumnsContainer",
				},
				{
					"operation": "insert",
					"name": "ParamsContainer",
					"parentName": "MiniPage",
					"propertyName": "items",
					"values": {
						"className": "BPMSoft.LazyContainer",
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24
						},
						"items": []
					}
				},
				{
					"name": "CommonControlGroup",
					"operation": "insert",
					"parentName": "ParamsContainer",
					"propertyName": "items",
					"index": 0,
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTROL_GROUP,
						"caption": {
							"bindTo": "Resources.Strings.GeneralTabCaption"
						},
						"controlConfig": {
							"collapsed": false
						},
						"tools": [],
						"items": [],
						"wrapClass": ["choose-column-control-group"]
					}
				},
				{
					"operation": "insert",
					"parentName": "CommonControlGroup",
					"propertyName": "items",
					"name": "CommonGridLayout",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"classes": {
							"wrapClassName": ["common-designer-layout"]
						},
						"items": []
					}
				},
				{
					"name": "Name",
					"parentName": "CommonGridLayout",
					"operation": "insert",
					"propertyName": "items",
					"index": 0,
					"values": {
						"labelConfig": {
							"visible": true
						},
						"isMiniPageModelItem": true,
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24
						}
					}
				},
				{
					"name": "PeriodType",
					"parentName": "CommonGridLayout",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"isMiniPageModelItem": true,
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24
						},
						"enabled": {
							"bindTo": "isAddMode"
						}
					}
				},
				{
					"name": "ForecastEntity",
					"parentName": "CommonGridLayout",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"isMiniPageModelItem": true,
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 24
						},
						"contentType": BPMSoft.ContentType.ENUM,
						"controlConfig": {
							"prepareList": {
								"bindTo": "prepareForecastEntityList"
							},
							"loadNextPage": {
								"bindTo": "loadNextForecastEntities"
							}
						},
						"enabled": {
							"bindTo": "isAddMode"
						}
					}
				},
				{
					"name": "PrimaryDisplayNotExistContainer",
					"operation": "insert",
					"parentName": "CommonGridLayout",
					"propertyName": "items",
					"values": {
						"wrapClass": ["primary-display-container"],
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 24
						},
						"visible": {
							"bindTo": "IsEntityPrimaryDisplayColumnExist",
							"bindConfig": {"converter": "invertBooleanValue"},
						},
						"items": []
					}
				},
				{
					"name": "ForecastPrimaryDisplayNotExistError",
					"parentName": "PrimaryDisplayNotExistContainer",
					"operation": "insert",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "Resources.Strings.PrimaryDisplayColumnNotExistErrorMessage"},
						"classes": {"labelClass": ["primary-display-container-label"]}
					},
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "Name",
					"parentName": "PrimaryDisplayNotExistContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.HYPERLINK,
						"classes": {"hyperlinkClass": ["primary-display-container-hyperlink"]},
						"markerValue": {"bindTo": "Resources.Strings.MoreDetailsCaption"},
						"caption": {"bindTo": "Resources.Strings.MoreDetailsCaption"},
						"href": {"bindTo": "Resources.Strings.MoreDetailsLink"}
					}
				},
				{
					"operation": "merge",
					"name": "SaveEditButton",
					"values": {
						"caption": {"bindTo": "Resources.Strings.CreateCaption"},
						"enabled": {"bindTo": "IsEntityPrimaryDisplayColumnExist"}
					}
				},
				{
					"operation": "merge",
					"name": "MiniPageHeaderCaption",
					"values": {
						"visible": true
					}
				},
				{
					"operation": "merge",
					"name": "OpenCurrentEntityPage",
					"values": {
						"visible": false
					}
				},
				{
					"name": "MainHierarchyContainer",
					"operation": "insert",
					"parentName": "CommonGridLayout",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"layout": {
							"column": 0,
							"row": 5,
							"colSpan": 24
						},
						"visible": {"bindTo": "IsEntityPrimaryDisplayColumnExist"},
						"items": []
					}
				},
				{
					"name": "SetHierarchyButton",
					"operation": "insert",
					"parentName": "MainHierarchyContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"caption": {"bindTo": "Resources.Strings.SetupHierarchyButtonCaption"},
						"click": {"bindTo": "toggleHierarchyContainer"},
						"classes": {"wrapperClass": ["setup-hierarchy-button"]},
						"imageConfig": resources.localizableImages.HierarchyImage,
						"enabled": {
							"bindTo": "ForecastEntity",
							"bindConfig": {"converter": "isNotEmptyValue"}
						}
					}
				},
				{
					"name": "ItemsHierarchyContainer",
					"operation": "insert",
					"parentName": "MainHierarchyContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": {"wrapClassName": ["items-hierarchy-container"]},
						"items": []
					}
				},
				{
					"name": "HierarchyContainerList",
					"operation": "insert",
					"parentName": "ItemsHierarchyContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"className": "BPMSoft.ContainerList",
						"collection": {"bindTo": "HierarchyData"},
						"onGetItemConfig": {"bindTo": "onGetItemConfig"},
						"classes": {"wrapClassName": ["hierarchy-container-list"]},
						"defaultItemConfig": {},
						"idProperty": "Id",
						"itemPrefix": "Id",
						"markerValue": "HierarchyContainerList"
					}
				},
				{
					"name": "AutomationControlGroup",
					"operation": "insert",
					"parentName": "ParamsContainer",
					"propertyName": "items",
					"index": 1,
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTROL_GROUP,
						"caption": {
							"bindTo": "Resources.Strings.AutomationTabCaption"
						},
						"controlConfig": {
							"collapsed": false
						},
						"tools": [],
						"items": [],
						"wrapClass": ["choose-column-control-group"]
					}
				},
				{
					"operation": "insert",
					"parentName": "AutomationControlGroup",
					"propertyName": "items",
					"name": "AutomationGridLayout",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"classes": {
							"wrapClassName": ["common-designer-layout"]
						},
						"items": []
					}
				},
				{
					"name": "AutoSnapshotContainer",
					"operation": "insert",
					"parentName": "AutomationGridLayout",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24
						},
						"wrapClass": [
							"auto-snapshot-container"
						],
						"visible": {
							"bindTo": "IsForecastSnapshotFeatureEnabled"
						},
						"items": []
					}
				},
				{
					"name": "AutoSnapshotEnabled",
					"parentName": "AutoSnapshotContainer",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"className": "BPMSoft.ToggleEdit",
						"wrapClass": [
							"auto-snapshot-checkbox-container",
						],
						"caption": {"bindTo": "Resources.Strings.AutoSnapshotCaption"},
						"bindTo": "IsAutoSnapshotEnable",
					}
				},
				{
					"operation": "insert",
					"name": "AutoSnaphotTime",
					"parentName": "AutoSnapshotContainer",
					"propertyName": "items",
					"values": {
						"labelConfig": {
							"visible": true,
							"caption": {"bindTo": "Resources.Strings.AutoSnapshotTimeCaption"}
						},
						"bindTo": "AutoSnapshotTime",
						"wrapClass": ["auto-snapshot-time"],
						"visible": {
							"bindTo": "IsAutoSnapshotEnable"
						},
					}
				},
				{
					"name": "AutoCalculateContainer",
					"operation": "insert",
					"parentName": "AutomationGridLayout",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24
						},
						"visible": {
							"bindTo": "IsForecastAutoCalculationFeatureEnabled"
						},
						"items": []
					}
				},
				{
					"name": "AutoCalcEnabled",
					"parentName": "AutoCalculateContainer",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"className": "BPMSoft.ToggleEdit",
						"wrapClass": [
							"auto-calculate-checkbox-container"
						],
						"caption": {"bindTo": "Resources.Strings.AutoCalculateCaption"},
						"bindTo": "IsAutoCalculateEnable",
					}
				},
				{
					"operation": "insert",
					"name": "MinuteHourStartContainer",
					"parentName": "AutoCalculateContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"wrapClass": ["minute-hours-container"],
						"visible": { "bindTo": "IsAutoCalculateEnable" },
					}
				},
				{
					"operation": "insert",
					"name": "MinuteHourModule",
					"parentName": "MinuteHourStartContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.MODULE,
						"moduleName": "BaseSchemaModuleV2",
						"instanceConfig": {
							"isSchemaConfigInitialized": true,
							"schemaName": "MinuteHourCronExpressionPage",
							"useHistoryState": false,
							"parameters": {
								"viewModelConfig": {
									"CronExpression": {
										"getValueMethod": "getStringCronExpression"
									}
								}
							}
						}
					}
				},
				{
					"operation": "insert",
					"name": "TimeZone",
					"parentName": "AutomationGridLayout",
					"propertyName": "items",
					"values": {
						"bindTo": "TimeZone",
						"contentType": BPMSoft.ContentType.ENUM,
						"labelConfig": {
							"caption": SysAdminUnit.columns.TimeZoneId.caption,
						},
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 24
						},
						"controlConfig": {
							"filterComparisonType": BPMSoft.StringFilterType.CONTAIN,
							"prepareList": {"bindTo": "onPrepareTimeZoneList"},
							"list": {"bindTo": "TimeZoneList"},
							"classes": ["combo-box-edit-wrap"]
						},
						"visible": {"bindTo": "getIsTimeZoneControlEnabled"},
						"markerValue": "time-zone-value"
					}
				},
				{
					"name": "CronValidationErrorMessage",
					"parentName": "MinuteHourStartContainer",
					"propertyName": "items",
					"operation": "insert",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "CronValidationErrorMessage"},
						"classes": {"labelClass": ["cron-validation-error-label"]},
						"visible": {
							"bindTo": "IsCronValid",
							"bindConfig": {"converter": "invertBooleanValue"},
						},
					}
				},
			]/**SCHEMA_DIFF*/
		};
	});
