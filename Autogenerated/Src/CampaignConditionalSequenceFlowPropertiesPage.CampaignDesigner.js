/**
 * CampaignConditionalSequenceFlowPropertiesPage edit page schema.
 * Parent: CampaignSequenceFlowPropertiesPage.
 */
define("CampaignConditionalSequenceFlowPropertiesPage", ["BusinessRuleModule",
		"CampaignElementMixin", "DropdownLookupMixin", "StructureExplorerUtilities",
		"FilterModuleMixin", "EntitySchemaSelectMixin"],
	function(BusinessRuleModule) {
		return {
			messages: {
				"GetFilterModuleConfig": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				"OnFiltersChanged": {
					mode: BPMSoft.MessageMode.BROADCAST,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				"SetFilterModuleConfig": {
					mode: BPMSoft.MessageMode.BROADCAST,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			mixins: {
				entitySchemaSelectMixin: "BPMSoft.EntitySchemaSelectMixin",
				campaignElementMixin: "BPMSoft.CampaignElementMixin",
				dropdownLookupMixin: "BPMSoft.DropdownLookupMixin"
			},
			properties: {
				/**
				 * Default filter entity schema identifier for filter (contact).
				 * @type {Guid}
				 */
				defaultFilterEntitySchemaId: "5b229e55-8ebf-414a-8dee-26e2b059025b",
				/**
				 * Default filter entity schema name for filter.
				 * @type {Guid}
				 */
				defaultFilterEntitySchemaName: "Contact"
			},
			attributes: {
				/**
				 * Values of lookup for sequenceMode.
				 */
				"SequenceModeEnum": {
					dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: {
						Default: {
							value: "0",
							captionName: "Resources.Strings.SequenceModeDefault"
						},
						TimePeriod: {
							value: "1",
							captionName: "Resources.Strings.SequenceModeTimePeriod"
						}
					}
				},

				/**
				 * Values of lookup for delayUnit.
				 */
				"DelayUnitEnum": {
					dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: {
						Default: {
							value: "0",
							captionName: "Resources.Strings.DelayDecisionDaysNumber"
						},
						Hours: {
							value: "1",
							captionName: "Resources.Strings.DelayDecisionHoursNumber"
						}
					}
				},

				/**
				 * Values of lookup for filterMode.
				 */
				"FilterModeEnum": {
					dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: {
						Default: {
							value: "0",
							captionName: "Resources.Strings.FilterModeDefault"
						},
						WithFilter: {
							value: "1",
							captionName: "Resources.Strings.FilterModeWithFilter"
						}
					}
				},

				/**
				 * Lookup for SequenceMode.
				 */
				"SequenceMode": {
					"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"isRequired": true
				},

				/**
				 * Lookup for FilterMode.
				 */
				"FilterMode": {
					"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"isRequired": true
				},

				/**
				 * Delay unit for ui combobox.
				 */
				"DelayUnit": {
					"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"isRequired": true,
					"onChange": "updateFlowDescription"
				},

				/**
				 * DaysNumber property.
				 */
				"DaysNumber": {
					"dataValueType": this.BPMSoft.DataValueType.INTEGER,
					"value": 1,
					"defaultValue": 1,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"onChange": "updateFlowDescription"
				},

				/**
				 * Time when transition will be executed.
				 */
				"ExecutionTime": {
					"dataValueType": this.BPMSoft.DataValueType.TIME,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"onChange": "updateFlowDescription"
				},

				/**
				 * IsFilterChanged property which indicates whenever filter has been changed.
				 */
				"IsFilterChanged": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Initial value of filters.
				 */
				"InitialFilter": {
					dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * FilterId schema property.
				 */
				"FilterId": {
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * HasStartTime property to indicate that StartTime property is specified.
				 */
				"HasStartTime": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: true
				},

				/**
				 * Values collection of lookup for FilterEntitySchema.
				 * @type {BPMSoft.Collection}
				 */
				"FilterEntitySchemaCollection": {
					dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: Ext.create("BPMSoft.Collection")
				},

				/**
				 * Current entity schema to filter participants of campaign.
				 * @type {Object}
				 */
				"FilterEntitySchema": {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true
				},

				/**
				 * Flag to indicate page loading state.
				 * @type {Boolean}
				 */
				"PageLoaded": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": false,
					"onChange": "_onPageLoaded"
				}
			},
			rules: {
				/**
				 * Rule for ExecutionTime.
				 */
				"ExecutionTime": {
					"BindExecutionTimeRequiredToSequenceMode": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.REQUIRED,
						"conditions": [{
							"leftExpression": {
								"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
								"attribute": "SequenceMode"
							},
							"comparisonType": this.BPMSoft.ComparisonType.EQUAL,
							"rightExpression": {
								"type": BusinessRuleModule.enums.ValueType.CONSTANT,
								"value": "1"
							}
						}]
					}
				}
			},
			methods: {

				/**
				 * @inheritdoc BaseProcessSchemaElementPropertiesPage#init
				 * @overridden
				 */
				init: function() {
					this.subscribeEvents();
					this.callParent(arguments);
				},

				/**
				 * Subscribes on events.
				 * @protected
				 */
				subscribeEvents: function() {
					this.on("change:SequenceMode", this._onSequenceModeLookupChanged, this);
					this.on("change:FilterMode", this._onFilterModeLookupChanged, this);
					this.on("change:HasStartTime", this._onHasStartTimeChanged, this);
				},

				/**
				 * Handles change of the "SequenceMode" property.
				 * @private
				 */
				_onSequenceModeLookupChanged: function() {
					var sequenceMode = this.$SequenceMode;
					var defaultValue = this.$SequenceModeEnum.Default.value;
					if (!sequenceMode || sequenceMode.value === defaultValue) {
						this.$DaysNumber = 1;
						this.$ExecutionTime = null;
					} else {
						this._setDefaultDaysNumberForTransitionWithDelay();
						this._setDefaultExecutionTimeForTransitionWithDelay();
					}
					this.updateFlowDescription();
				},

				/**
				 * Handles change of the "FilterMode" property.
				 * @private
				 */
				_onFilterModeLookupChanged: function() {
					var filterMode = this.get("FilterMode");
					var defaultValue = this.get("FilterModeEnum").Default.value;
					this.updateFlowDescription();
					if (filterMode.value === defaultValue) {
						this.sandbox.unloadModule(this._getFilterEditModuleId());
						return;
					}
					if (this._isCampaignAudienceImportEnabled()) {
						this.loadFilterModule();
						return;
					}
					var filterId = this.get("FilterId");
					this._initFilter(filterId);
				},

				/**
				 * Handles change of the "HasStartTime" property.
				 * @private
				 */
				_onHasStartTimeChanged: function() {
					if (this.$HasStartTime && !this.$ExecutionTime) {
						this.$ExecutionTime = new Date();
					}
					this.validateColumn("DaysNumber");
					this.updateFlowDescription();
				},

				/**
				 * Sets expected default value for DaysNumber attribute.
				 * @private
				 */
				_setDefaultDaysNumberForTransitionWithDelay: function() {
					if (!this.$DaysNumber) {
						this.$DaysNumber = 0;
					}
				},

				/**
				 * Sets expected default value for DaysNumber attribute.
				 * @private
				 */
				_setDefaultExecutionTimeForTransitionWithDelay: function() {
					if (this.$HasStartTime && !this.$ExecutionTime) {
						this.$ExecutionTime = new Date();
					}
				},

				/**
				 * @private
				 */
				_createFilterEntitySchemaESQ: function() {
					var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "CampaignSignalEntity"
					});
					esq.addColumn("Id");
					esq.addColumn("EntityObject");
					esq.addColumn("Caption");
					return esq;
				},

				/**
				 * @private
				 */
				_getDefaultFilterEntitySchema: function() {
					var item = this.$FilterEntitySchemaCollection.findByFn(function(el) {
						return el.value === this.defaultFilterEntitySchemaId;
					}, this);
					item.schemaName = this.defaultFilterEntitySchemaName;
					return item;
				},

				/**
				 * @private
				 */
				_initFilterEntitySchema: function(filterEntitySchemaId, callback, scope) {
					var selectedItem = this.$FilterEntitySchemaCollection.findByFn(function(el) {
						return el.value === filterEntitySchemaId;
					});
					if (!selectedItem) {
						selectedItem = this._getDefaultFilterEntitySchema();
					}
					if (selectedItem.schemaName) {
						this.set("FilterEntitySchema", selectedItem);
						callback.call(scope);
						return;
					}
					BPMSoft.EntitySchemaManager.findItemByUId(selectedItem.entitySchemaUId, function(schema) {
						selectedItem.schemaName = schema.name;
						this.set("FilterEntitySchema", selectedItem);
						callback.call(scope);
					}, this);
				},

				/**
				 * @private
				 */
				_initFilterEntitySchemaCollection: function(filterEntitySchemaId, callback, scope) {
					var esq = this._createFilterEntitySchemaESQ();
					esq.getEntityCollection(function(response) {
						this.loadFilterEntitySchemaCollection(response.collection);
						callback.call(scope);
					}, this);
				},

				/**
				 * @private
				 */
				_updateFilterEntitySchemaData: function(props) {
					var schemaId = this.$FilterEntitySchema.value;
					var currentSchema = this.$FilterEntitySchemaCollection.findByFn(function(el) {
						return el.value === schemaId;
					}, this);
					BPMSoft.each(props, function(value, prop) {
						currentSchema[prop] = value;
					}, this);
				},

				/**
				 * @private
				 */
				_actualizeFilterModule: function(hideMask) {
					var filterModuleConfig = this.onGetConditionFilterModuleConfig();
					var filterModuleId = this._getFilterEditModuleId();
					this.sandbox.publish("SetFilterModuleConfig", filterModuleConfig, [filterModuleId]);
					if (hideMask) {
						this.hideBodyMask();
					}
				},

				/**
				 * @private
				 */
				_onPageLoaded: function() {
					this.updateFlowDescription();
				},

				/**
				 * Handler on "FilterEntitySchema" attribute change event.
				 * Clears filter data and actualizes page state.
				 * @protected
				 * @param {BPMSoft.BaseViewModel} model View model.
				 * @param {Object} value New value.
				 */
				onFilterEntitySchemaChanged: function(model, value) {
					this.set("FilterData", null);
					if (!value) {
						return;
					}
					this.loadPropertiesPageMask();
					if (!value.schemaName) {
						BPMSoft.EntitySchemaManager.findItemByUId(value.entitySchemaUId, function(schema) {
							this.$FilterEntitySchema.schemaName = schema.name;
							this._updateFilterEntitySchemaData({schemaName: schema.name});
							this._actualizeFilterModule(true);
						}, this);
						return;
					}
					this._actualizeFilterModule(true);
				},

				/**
				 * Loads available audience schemas to FilterEntitySchemaCollection.
				 * @protected
				 * @param {BPMSoft.Collection} collection Loaded audience schemas.
				 */
				loadFilterEntitySchemaCollection: function(collection) {
					var list = new BPMSoft.Collection();
					BPMSoft.each(collection, function(el) {
						var schemaObject = {
							value: el.$Id,
							displayValue: el.$Caption,
							caption: el.$Caption,
							entitySchemaUId: el.$EntityObject.value
						};
						list.add(el.$Id, schemaObject);
					}, this);
					list.sort("caption", this.BPMSoft.OrderDirection.ASC);
					this.$FilterEntitySchemaCollection.reloadAll(list);
				},

				/**
				 * @inheritdoc BaseCampaignSchemaElementPage#initPageAsync
				 * @override
				 */
				initPageAsync: function(element, callback, scope) {
					var parentMethod = this.getParentMethod();
					this.$CanSaveElementConfig = true;
					this._initFilterEntitySchemaCollection(element.filterEntitySchemaId, function() {
						this.on("change:FilterEntitySchema", this.onFilterEntitySchemaChanged, this);
						parentMethod.call(this, element, callback, scope);
					}, this);
				},

				/**
				 * @inheritdoc BaseCampaignSchemaElementPage#initElementProperties.
				 * @overridden
				 */
				initElementProperties: function(element, callback, scope) {
					this._initDaysNumber(element.delayInDays);
					this.set("HasStartTime", element.hasStartTime);
					this._initExecutionTime(element.startTime);
					this._setDelayUnitLookupValue(element.delayUnit);
					this._setSequenceModeLookupValue(element.isDelayedStart);
					this._setFilterModeLookupValue(element.hasFilter);
					this._initFilterEntitySchema(element.filterEntitySchemaId, callback, this);
					this.set("FilterData", element.filter);
					this._actualizeFilterModule();
					if (!this._isCampaignAudienceImportEnabled()) {
						this.set("FilterId", element.filterId);
						this.set("InitialFilter", element.filter);
						this.set("IsFilterChanged", element.isFilterChanged);
					}
					this.callParent(arguments);
					this.$PageLoaded = true;
				},

				/**
				 * If filterId is not empty gets filter data from linked contactFolder.
				 * Otherwise generates new unique identifier and sets existing or empty filter.
				 * @private
				 * @param  {Guid} folderId unique identifier of linked ContactFolder.
				 */
				_initFilter: function(folderId) {
					var filters = this.get("FilterData");
					if (filters === "null") {
						filters = null;
					}
					if (folderId && this.Ext.isEmpty(filters)) {
						var config = {
							serviceName: "CampaignService",
							methodName: "GetContactFolderInfo",
							data: {
								folderId: folderId,
								folderSchemaName: "ContactFolder"
							}
						};
						this.callService(config, function(response) {
							var folderInfo = response.GetContactFolderInfoResult;
							if (folderInfo) {
								this.set("FilterData", folderInfo.SearchData);
								this.set("InitialFilter", folderInfo.SearchData);
							}
							this.loadFilterModule();
						}, this);
					} else {
						if (!folderId) {
							var filterId = BPMSoft.generateGUID();
							this.set("FilterId", filterId);
						}
						this.loadFilterModule();
					}
				},

				/**
				 * @private
				 */
				_initializeFilter: function() {
					var filterId = this.get("FilterId");
					if (this._isCampaignAudienceImportEnabled() && !filterId) {
						this.loadFilterModule();
						return;
					}
					this._initFilter(filterId);
				},

				/**
				 * Page render handler.
				 * Starts to init filter module when page is rendered.
				 * @overriden
				 */
				onRender: function() {
					if (this._getIsFiltersContainerVisible()) {
						this._initializeFilter();
					}
				},

				/**
				 * Initializes value of the "ExecutionTime" property.
				 * @private
				 * @param {string} value Initial date string.
				 */
				_initExecutionTime: function(value) {
					var date = new Date();
					if (value) {
						var formatValue = value.replace(/\-/g, "/");
						date = new Date(formatValue);
					}
					this.set("ExecutionTime", date);
				},

				/**
				 * Initializes value of the "DaysNumber" property.
				 * @private
				 * @param {Number} value Initial value.
				 */
				_initDaysNumber: function(value) {
					var daysNumber = 0;
					if (this.Ext.isNumber(value)) {
						daysNumber = value;
					}
					this.set("DaysNumber", daysNumber);
				},

				/**
				 * Initializes value of the "SequenceMode" property.
				 * @private
				 * @param {Boolean} isDelayedStart Is transition has any delay.
				 */
				_setSequenceModeLookupValue: function(isDelayedStart) {
					var isDefaultValue = !isDelayedStart;
					this.setLookupValue(isDefaultValue,
						"SequenceMode", "TimePeriod", this);
				},

				/**
				 * Initialize value of the "DelayUnit" ptoperty
				 * @private
				 * @param {Integer} delayUnit Delay unit value from metadata.
				 */
				_setDelayUnitLookupValue: function(delayUnit) {
					var isDefaultValue = !delayUnit || delayUnit === 0 ? true : false;
					this.setLookupValue(isDefaultValue,
						"DelayUnit", "Hours", this);
				},

				/**
				 * Inits is Filter is visible.
				 * @private
				 * @param  {Boolean} isFilterEnabled user decision to use filter.
				 */
				_setFilterModeLookupValue: function(isFilterEnabled) {
					var isDefaultValue = !isFilterEnabled;
					var options = {
						silent: true
					};
					this.setLookupValue(isDefaultValue,
						"FilterMode", "WithFilter", this, options);
				},

				/**
				 * @private
				 */
				_getFilterRootSchemaName: function() {
					if (!this.$FilterEntitySchema) {
						return this.defaultFilterEntitySchemaName;
					}
					return this.$FilterEntitySchema.schemaName;
				},

				/**
				 * Loads values into sequence mode combobox.
				 * @protected
				 * @param {Object} sequence ComboboxEdit value.
				 * @param {BPMSoft.Collection} list List of comboboxEdit values.
				 */
				onPrepareSequenceModeList: function(filter, list) {
					this.prepareList("SequenceModeEnum", list, this);
				},

				/**
				 * Loads values into filter mode combobox.
				 * @protected
				 * @param {Object} filter ComboboxEdit value.
				 * @param {BPMSoft.Collection} list List of comboboxEdit values.
				 */
				onPrepareFilterModeList: function(filter, list) {
					this.prepareList("FilterModeEnum", list, this);
				},

				/**
				 * Loads values into delay unit combobox.
				 * @protected
				 * @param {Object} filter ComboboxEdit value.
				 * @param {BPMSoft.Collection} list List of comboboxEdit values.
				 */
				onPrepareDelayUnitList: function(filter, list) {
					this.prepareList("DelayUnitEnum", list, this);
				},

				/**
				 * Applies all connection conditions for current transition schema.
				 * @protected
				 * @param {BPMSoft.ProcessCampaignConditionalSequenceFlowSchema} flow Conditional transition schema.
				 */
				saveConditions: function(flow) {
					var isDelayedStart = this._getIsSequenceMode();
					flow.isDelayedStart = isDelayedStart;
					flow.hasStartTime = this.$HasStartTime;
					var startTime = this._getCurrentStartTime();
					var delayUnit = this.get("DelayUnit");
					flow.startTime = startTime;
					flow.delayUnit = BPMSoft.isEmptyObject(delayUnit) ? 0 : parseInt(delayUnit.value , 10);
					flow.delayInDays = this.getCurrentDalayInDays(isDelayedStart);
					var hasFilter = this._getIsFiltersContainerVisible();
					flow.hasFilter = hasFilter;
					this._saveFiltersInSchema(hasFilter, flow);
					if (this._isCampaignAudienceImportEnabled()) {
						flow.filterEntitySchemaId = this.$FilterEntitySchema && this.$FilterEntitySchema.value;
						flow.isFilterChanged = false;
						flow.filterId = null;
						flow.initialFilter = null;
						return;
					}
					flow.filterId = this.get("FilterId");
					flow.isFilterChanged = this.get("IsFilterChanged");
					this.set("IsFilterChanged", false);
				},

				/**
				 * @inheritdoc BaseCampaignSchemaElementPage#saveValues.
				 * @overridden
				 */
				saveValues: function() {
					this.callParent(arguments);
					var element = this.get("ProcessElement");
					this.saveConditions(element);
				},

				/**
				 * Returns StartTime parameter based on selected page attributes.
				 * @private
				 * @return {Date} start time.
				 */
				_getCurrentStartTime: function() {
					var hasStartTime = this.$HasStartTime;
					var executionTime = this.$ExecutionTime || new Date();
					return hasStartTime && executionTime ? this.convertDateToString(executionTime) : "";
				},

				/**
				 * Returns DelayInDays parameter based on selected page attributes.
				 * If no delay returns 0 otherwise returns value of DaysNumber attribute.
				 * @param {Boolean} isDelayedStart is transition has some delay.
				 * @protected
				 * @return {number} delay in days.
				 */
				getCurrentDalayInDays: function(isDelayedStart) {
					var validationInfo = this.validationInfo.get("DaysNumber") || { isValid: true };
					if (!isDelayedStart || !validationInfo.isValid) {
						return 1;
					}
					var daysNumber = this.get("DaysNumber");
					return this.Ext.isNumber(daysNumber) ? daysNumber : 1;
				},

				/**
				 * @inheritdoc BaseCampaignSchemaElementPage#getContextHelpCode.
				 * @overridden
				 */
				getContextHelpCode: function() {
					return "CampaignConditionalSequenceFlow";
				},

				/**
				 * Determines whether the value of the "DelayDecision" is DaysNumber value.
				 * @return {Boolean}.
				 */
				_getIsSequenceMode: function() {
					return this.isLookupValueEqual("SequenceMode", "1", this) &&
							!this.get("IsSynchronous");
				},

				/**
				 * Saves schema filters.
				 * If schema hasn't any filter sets empty string
				 * else sets current FilterData if exists.
				 * @private
				 * @param {Boolean} hasFilter Is current transition has filter.
				 * @param {BPMSoft.ProcessCampaignConditionSequenceFlowSchema} sequenceFlowSchema
				 * Schema of current transition.
				 */
				_saveFiltersInSchema: function(hasFilter, element) {
					if (!hasFilter) {
						element.filter = "";
					} else {
						element.filter = this.get("FilterData") || "";
					}
				},

				/**
				 * Returns visibility of filter container.
				 * @private
				 * @return {Boolean} is filter container visible.
				 */
				_getIsFiltersContainerVisible: function() {
					return this.isLookupValueEqual("FilterMode", "1", this);
				},

				/**
				 * Returns sandbox's FilterEditModule Id.
				 * @private
				 * @return {string} Id of FilterEditModule.
				 */
				_getFilterEditModuleId: function() {
					return this.sandbox.id + "_FilterEditModule";
				},

				/**
				 * Validates DaysNumber by value.
				 * @private
				 * @param {number} value DaysNumber value for validate.
				 * @returns {Boolean} Validation result.
				 * Returns true when DaysNumber is valid, and false in otherwise.
				 */
				_isDaysNumberValid: function(value) {
					if (!this._getIsSequenceMode()) {
						return true;
					}
					if (this.Ext.isEmpty(value)) {
						return false;
					}
					return this.$HasStartTime
						? value >= 0
						: value > 0;
				},

				/**
				 * @private
				 */
				_isCampaignAudienceImportEnabled: function() {
					return this.getIsFeatureEnabled("CampaignAudienceImport");
				},

				/**
				 * Creates caption with target element name.
				 * @protected
				 * @return {string} custom caption with element name.
				 */
				getFilterQuestionCaption: function() {
					var caption = this.get("Resources.Strings.FilterModeCaption");
					caption = this.Ext.String.format(caption, this.getTargetElement().getCaption());
					return caption;
				},

				/**
				 * Creates caption with source element name
				 * @protected
				 * @return {string} custom caption with element name
				 */
				getResponseQuestionCaption: function() {
					var caption = this.get("Resources.Strings.ResponseModeCaption");
					var sourceElement = this.getSourceElement();
					caption = this.Ext.String.format(caption, sourceElement && sourceElement.getCaption());
					return caption;
				},

				/**
				 * Returns source element for this sequence flow
				 * @protected
				 * @return {BPMSoft.CampaignSchemaElement} sourse element for transition
				 */
				getSourceElement: function() {
					var flowElement = this.get("ProcessElement");
					if (flowElement) {
						return flowElement.findSourceElement();
					}
					return null;
				},

				/**
				 * Returns target element for this sequence flow.
				 * @protected
				 * @return {BPMSoft.CampaignSchemaElement} target element for transition.
				 */
				getTargetElement: function() {
					var flowElement = this.get("ProcessElement");
					if (flowElement) {
						return flowElement.findTargetElement();
					}
					return null;
				},

				/**
				 * Loads Filter module to display filters.
				 * @protected
				 */
				loadFilterModule: function() {
					var moduleId = this._getFilterEditModuleId();
					var sandbox = this.sandbox;
					sandbox.subscribe("OnFiltersChanged", this.onConditionFiltersChanged, this, [moduleId]);
					sandbox.subscribe("GetFilterModuleConfig",
						this.onGetConditionFilterModuleConfig, this, [moduleId]);
					sandbox.loadModule("FilterEditModule", {renderTo: "ExtendedFiltersContainer", id: moduleId});
				},

				/**
				 * Returns FilterModuleConfig to load filter module.
				 * @protected
				 * @return {object} Filter module config.
				 */
				onGetConditionFilterModuleConfig: function() {
					return {
						rootSchemaName: this._getFilterRootSchemaName(),
						rightExpressionMenuAligned: true,
						filters: this.get("FilterData"),
						filterProviderClassName: "BPMSoft.EntitySchemaFilterProvider"
					};
				},

				/**
				 * Updates description for current transition.
				 * @protected
				 */
				updateFlowDescription: function() {
					if (!this.$PageLoaded) {
						return;
					}
					var flow = this.get("ProcessElement");
					this.saveConditions(flow);
					flow.updateDescription();
				},

				/**
				 * Listener on filters changed.
				 * Sets value of FilterData attribute.
				 * If filter was not changed compare initial and current filter values to check filter changes.
				 * @param {object} args { filter: object, serializedFilter: string } Filters.
				 * @protected
				 */
				onConditionFiltersChanged: function(args) {
					this.set("FilterData", args.serializedFilter);
					this.updateFlowDescription();
					if (this._isCampaignAudienceImportEnabled()) {
						return;
					}
					var initialFilter = this.get("InitialFilter");
					if (!this.get("IsFilterChanged")) {
						this.set("IsFilterChanged", args.serializedFilter !== initialFilter);
					}
				},

				/**
				 * Validates DaysNumber value. It must be positive and not empty.
				 * @protected
				 * @param  {Object} value Mapping value.
				 * @return {Object} Validation info object.
				 * Result object must contains properties:
				 *  - isValid - indicates result of validation.
				 *  - invalidMessage - validation message when DaysNumber is not valid.
				 */
				validateDaysNumber: function(value) {
					var validationInfo = {
						isValid: true,
						invalidMessage: ""
					};
					if(!this._isDaysNumberValid(value)) {
						validationInfo.isValid = false;
						validationInfo.invalidMessage = this.get("Resources.Strings.NegativeDaysNumberErrorText");
					}
					return validationInfo;
				},

				/**
				 * @inheritdoc BaseSchemaViewModel#setValidationConfig
				 * @override
				 */
				setValidationConfig: function() {
					this.callParent(arguments);
					this.addColumnValidator("DaysNumber", this.validateDaysNumber);
				},

				/**
				 * Handler on load audience schema list on combobox click.
				 * @protected
				 * @param {String} filter Text to contain.
				 * @param {BPMSoft.Collection} list Items collection.
				 */
				prepareFilterEntitySchemaList: function(filter, list) {
					list.reloadAll(this.$FilterEntitySchemaCollection);
				},

				/**
				 * Returns true when feature is turned on and with filter mode is selected.
				 * @protected
				 * @returns {Boolean}
				 */
				isFilterEntitySchemaVisible: function() {
					return this._isCampaignAudienceImportEnabled()
						&& this.$FilterMode.value === this.$FilterModeEnum.WithFilter.value;
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "remove",
					"name": "InformationLabel"
				},
				{
					"operation": "insert",
					"name": "SequenceModeLabel",
					"parentName": "SequenceContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24
						},
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": "$Resources.Strings.SequenceModeCaption",
						"classes": {
							"labelClass": ["t-title-label-proc"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "SequenceMode",
					"parentName": "SequenceContainer",
					"propertyName": "items",
					"values": {
						"contentType": this.BPMSoft.ContentType.ENUM,
						"controlConfig": {
							"prepareList": "$onPrepareSequenceModeList"
						},
						"isRequired": true,
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 24
						},
						"labelConfig": {
							"visible": false
						},
						"wrapClass": ["no-caption-control"]
					}
				},
				{
					"operation": "insert",
					"name": "DelaySettingsContainer",
					"propertyName": "items",
					"parentName": "SequenceContainer",
					"className": "BPMSoft.GridLayoutEdit",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": [],
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 24
						},
						"visible": "$_getIsSequenceMode"
					}
				},
				{
					"operation": "insert",
					"name": "DelayDecisionLabel",
					"parentName": "DelaySettingsContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24
						},
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": "$Resources.Strings.DelayDecisionCaption",
						"classes": {
							"labelClass": ["label-small"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "DelayUnit",
					"parentName": "DelaySettingsContainer",
					"propertyName": "items",
					"values": {
						"contentType": this.BPMSoft.ContentType.ENUM,
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24
						},
						"controlConfig": {
							"prepareList": "$onPrepareDelayUnitList"
						},
						"labelConfig": {
							"visible": false
						},
						"isRequired": false
					}
				},
				{
					"operation": "insert",
					"name": "DaysNumberLabel",
					"parentName": "DelaySettingsContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24
						},
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": "$Resources.Strings.DaysNumberCaption",
						"classes": {
							"labelClass": ["label-small"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "DaysNumber",
					"parentName": "DelaySettingsContainer",
					"propertyName": "items",
					"values": {
						"dataValueType": this.BPMSoft.DataValueType.INTEGER,
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 24
						},
						"labelConfig": {
							"visible": false
						},
						"isRequired": false
					}
				},
				{
					"operation": "insert",
					"name": "HasExecutionTimeLabel",
					"parentName": "DelaySettingsContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 24
						},
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": "$Resources.Strings.ExecutionTimeCaption",
						"classes": {
							"labelClass": ["label-small"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "DelaySettingsContainer",
					"propertyName": "items",
					"name": "HasStartTime",
					"values": {
						"wrapClass": ["t-checkbox-control", "no-wrap"],
						"caption": "$Resources.Strings.HasStartTimeCaption",
						"layout": {
							"column": 0,
							"row": 5,
							"colSpan": 24
						}
					}
				},
				{
					"operation": "insert",
					"name": "ExecutionTime",
					"parentName": "DelaySettingsContainer",
					"propertyName": "items",
					"values": {
						"wrapClass": ["t-combobox-edit", "no-label"],
						"dataValueType": this.BPMSoft.DataValueType.TIME,
						"layout": {
							"column": 0,
							"row": 6,
							"colSpan": 24
						},
						"labelConfig": {
							"visible": false
						},
						"value": "$ExecutionTime",
						"visible": "$HasStartTime"
					}
				},
				{
					"operation": "insert",
					"name": "FiltersBlockContainer",
					"propertyName": "items",
					"parentName": "ContentContainer",
					"className": "BPMSoft.GridLayoutEdit",
					"values": {
						"layout": {"column": 0, "row": 4, "colSpan": 24},
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "FilterModeLabel",
					"parentName": "FiltersBlockContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24
						},
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": "$getFilterQuestionCaption",
						"classes": {
							"labelClass": ["t-title-label-proc"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "FilterMode",
					"parentName": "FiltersBlockContainer",
					"propertyName": "items",
					"values": {
						"contentType": this.BPMSoft.ContentType.ENUM,
						"controlConfig": {
							"prepareList": "$onPrepareFilterModeList"
						},
						"isRequired": true,
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24
						},
						"labelConfig": {
							"visible": false
						},
						"wrapClass": ["no-caption-control"]
					}
				},
				{
					"operation": "insert",
					"name": "AudienceEntitySchemaLayout",
					"parentName": "FiltersBlockContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"row": 2,
							"column": 0,
							"rowSpan": 1,
							"colSpan": 24
						},
						"visible": "$isFilterEntitySchemaVisible",
						"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "FilterEntitySchemaLabel",
					"parentName": "AudienceEntitySchemaLayout",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24
						},
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": "$Resources.Strings.FilterAudienceSchemaLabelCaption",
						"classes": {
							"labelClass": ["t-title-label-proc"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "FilterEntitySchema",
					"parentName": "AudienceEntitySchemaLayout",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"rowSpan": 1,
							"colSpan": 24
						},
						"contentType": this.BPMSoft.ContentType.ENUM,
						"controlConfig": {
							"prepareList": "$prepareFilterEntitySchemaList",
							"filterComparisonType": this.BPMSoft.StringFilterType.CONTAIN
						},
						"labelConfig": {
							"visible": false
						},
						"wrapClass": ["top-caption-control"]
					}
				},
				{
					"operation": "insert",
					"parentName": "FiltersBlockContainer",
					"propertyName": "items",
					"name": "FiltersContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 24
						}
					}
				},
				{
					"operation": "insert",
					"name": "ExtendedFiltersContainer",
					"parentName": "FiltersContainer",
					"propertyName": "items",
					"values": {
						"id": "ExtendedFiltersContainer",
						"selectors": {"wrapEl": "#ExtendedFiltersContainer"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
