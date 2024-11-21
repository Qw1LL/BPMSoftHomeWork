/**
 * Base edit page schema of process element "signal".
 * Parent: ProcessBaseEventPropertiesPage => ProcessFlowElementPropertiesPage => BaseProcessSchemaElementPropertiesPage
 */
define("BaseSignalEventPropertiesPage", ["BusinessRuleModule", "EntitySchemaSelectMixin", "FilterModuleMixin",
		"ConfigurationItemGenerator", "BaseSignalEventPropertiesPageResources"
	],
	function(BusinessRuleModule) {
		var SignalEnum = {
			SignalType: BPMSoft.process.constants.SignalType,
			ExpectChanges: BPMSoft.process.constants.SignalExpectChanges
		};
		return {
			mixins: {
				filterModuleMixin: "BPMSoft.FilterModuleMixin",
				entitySchemaSelectMixin: "BPMSoft.EntitySchemaSelectMixin"
			},
			attributes: {

				/**
				 * EntitySchemaUId parameter.
				 * @protected
				 * @type {String}
				 */
				"EntitySchemaUId": {
					"dataValueType": this.BPMSoft.DataValueType.MAPPING,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"initMethod": "initEntitySchemaUIdProperty"
				},

				/**
				 * RecordId parameter.
				 * @protected
				 * @type {String}
				 */
				"RecordId": {
					"dataValueType": this.BPMSoft.DataValueType.MAPPING,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"doAutoSave": true,
					"initMethod": "initProperty"
				},

				/**
				 * Entity of element.
				 * @protected
				 * @type {Object}
				 */
				"EntitySchemaSelect": {
					"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"isRequired": true
				},

				/**
				 * Signal type of element.
				 * @protected
				 * @type {Object}
				 */
				"SignalType": {
					"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"isRequired": true
				},

				/**
				 * Entity change type of element.
				 * @protected
				 * @type {Object}
				 */
				"EntityChangeType": {
					"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"isRequired": true
				},

				/**
				 * Expect changes of element.
				 * @protected
				 * @type {Object}
				 */
				"ExpectChanges": {
					"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Signal of element.
				 * @protected
				 * @type {String}
				 */
				"Signal": {
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},
			methods: {

				//region Methods: Protected

				/**
				 * @inheritdoc BPMSoft.BaseObject#onDestroy
				 * @overridden
				 */
				onDestroy: function() {
					this.destroyFilterModuleMixin();
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc ProcessSchemaElementEditable#onPageModeClick
				 * @overridden
				 */
				onPageModeClick: function() {
					if (!this.get("IsExtendedMode")) {
						this.unloadFilterUnitModule();
					}
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc ProcessSchemaElementEditable#onElementDataLoad
				 * @overridden
				 */
				onElementDataLoad: function(element, callback, scope) {
					this.initSignalTypeList(element);
					this.callParent([element, function() {
						this.mixins.entitySchemaSelectMixin.initEntitySchemaSelectMixin.call(this);
						var newEntityChangedColumns = element.getPropertyValue("newEntityChangedColumns");
						this.BPMSoft.chain(
							function(next) {
								this.initSignalEntity(element);
								next();
							},
							this.initEntitySchemaSelect,
							function(next) {
								this.initEntityChangeTypeList();
								this.initExpectChangesList();
								this.initEntitySchemaColumnsSelect(newEntityChangedColumns, next, this);
							},
							function() {
								this.validAttributes([
									"SignalType",
									"EntitySchemaSelect",
									"EntityChangeType",
									"ExpectChanges"
								]);
								this.mixins.filterModuleMixin.initFilterModuleMixin.call(this, {}, callback, scope);
							}, this);
					}, this]);
				},

				/**
				 * @inheritdoc BaseProcessSchemaElementPropertiesPage#saveValues
				 * @overridden
				 */
				saveValues: function() {
					var element = this.get("ProcessElement");
					element.setPropertyValue("signal", this.get("Signal"));
					this.saveSignalType(element);
					this.saveEntity(element);
					this.saveEntitySignal(element);
					this.saveEntityColumns(element);
					this.saveDataSourceFilters(element);
					this.saveEntityFilters(element);
					this.callParent(arguments);
				},

				/**
				 * Saves element signal type property.
				 * @protected
				 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
				 */
				saveSignalType: function(element) {
					var signalType = this.get("SignalType");
					signalType = Ext.isObject(signalType) ? signalType.value : signalType;
					var isEntitySignal = signalType === SignalEnum.SignalType.ObjectSignal;
					element.setPropertyValue("waitingRandomSignal", !isEntitySignal);
					element.setPropertyValue("waitingEntitySignal", isEntitySignal);
				},

				/**
				 * Saves element entity signal property.
				 * @protected
				 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
				 */
				saveEntitySignal: function(element) {
					var entitySignal = this.get("EntityChangeType");
					entitySignal = Ext.isObject(entitySignal) ? entitySignal.value : entitySignal;
					element.setPropertyValue("entitySignal", entitySignal);
				},

				/**
				 * Saves element entity property.
				 * @protected
				 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
				 */
				saveEntity: function(element) {
					var entity = this.get("EntitySchemaSelect");
					entity = Ext.isObject(entity) ? entity.value : entity;
					element.setPropertyValue("entity", entity);
					element.setPropertyValue("entitySchemaUId", entity);
					this.set("EntitySchemaUId", entity);
				},

				/**
				 * Saves element entity columns property.
				 * @protected
				 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
				 */
				saveEntityColumns: function(element) {
					const anySelectedField = SignalEnum.ExpectChanges.AnySelectedField;
					const anyField = SignalEnum.ExpectChanges.AnyField;
					var expectChanges = this.get("ExpectChanges");
					expectChanges = Ext.isObject(expectChanges) ? expectChanges.value : expectChanges;
					var changedColumns = [];
					if (expectChanges === anySelectedField) {
						var controlList = this.get("EntitySchemaColumnsControlsSelect");
						changedColumns = controlList.mapArray(function(control) {
							return control.get("Id");
						}, this);
						if (changedColumns.length === 0) {
							expectChanges = anyField;
							var expectChangesList = this.getExpectChangesList();
							this.set("ExpectChanges", expectChangesList[expectChanges]);
						}
					}
					this.set("NewEntityChangedColumns", changedColumns);
					element.setPropertyValue("hasEntityColumnChange", expectChanges === anySelectedField);
					element.setPropertyValue("newEntityChangedColumns", changedColumns);
				},

				/**
				 * Saves element entity filters property.
				 * @protected
				 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
				 */
				saveEntityFilters: function(element) {
					var entityFilters = this.get("EntityFilters");
					var isEmpty = Ext.isEmpty(entityFilters) || entityFilters === "null";
					if (!isEmpty && Ext.isString(entityFilters)) {
						var deserializedEntityFilters = this.deserializeFilterEditData(entityFilters);
						isEmpty = deserializedEntityFilters.isEmpty();
					}
					this.set("HasEntityFilters", !isEmpty);
					element.setPropertyValue("hasEntityFilters", !isEmpty);
					element.setPropertyValue("entityFilters", entityFilters);
				},

				/**
				 * Initializes EntitySchemaUId property.
				 * @protected
				 * @param {BPMSoft.ProcessSchemaParameter} parameter Process parameter.
				 */
				initEntitySchemaUIdProperty: function(parameter) {
					if (parameter) {
						this.initProperty(parameter);
					}
				},

				/**
				 * @inheritdoc BPMSoft.FilterModuleMixin#initReferenceSchemaUId
				 * @overridden
				 */
				initReferenceSchemaUId: function() {
					var entity = this.get("EntitySchemaSelect");
					entity = Ext.isObject(entity) ? entity.value : entity;
					this.set("ReferenceSchemaUId", entity);
				},

				/**
				 * @inheritdoc BPMSoft.FilterModuleMixin#getDataSourceFiltersValue
				 * @overridden
				 */
				getDataSourceFiltersValue: function() {
					return this.get("EntityFilters");
				},

				/**
				 * @inheritdoc BPMSoft.FilterModuleMixin#setDataSourceFiltersValue
				 * @overridden
				 */
				setDataSourceFiltersValue: function(element, parameterName, value) {
					this.set("EntityFilters", value);
				},

				/**
				 * @inheritdoc BPMSoft.FilterModuleMixin#updateFilterModule
				 * @overridden
				 */
				updateFilterModule: function() {
					if (this.getObjectSignalFiltersControlGroupVisible()) {
						this.initReferenceSchemaUId();
						this.mixins.filterModuleMixin.updateFilterModule.call(this);
						this.setFilterInfoButtonVisible();
					}
				},

				/**
				 * @inheritdoc BPMSoft.FilterModuleMixin#onFiltersChanged
				 * @overridden
				 */
				onFiltersChanged: function(args) {
					this.mixins.filterModuleMixin.onFiltersChanged.call(this, args);
					this.setFilterInfoButtonVisible();
				},

				/**
				 * @inheritdoc BPMSoft.FilterModuleMixin#getFilterModuleConfig
				 * @overridden
				 */
				getFilterModuleConfig: function(entitySchemaName) {
					var baseConfig = this.mixins.filterModuleMixin.getFilterModuleConfig.call(this, entitySchemaName);
					var config = {
						filterEditConfig: null,
						rightExpressionMenuAligned: true
					};
					return Ext.apply(baseConfig, config);
				},

				/**
				 * @inheritdoc BPMSoft.EntitySchemaSelectMixin#onEntitySchemaSelectChanged
				 * @overridden
				 */
				onEntitySchemaSelectChanged: function() {
					this.mixins.entitySchemaSelectMixin.onEntitySchemaSelectChanged.call(this);
					var entity = this.get("EntitySchemaSelect");
					var entitySchemaUId = Ext.isObject(entity) ? entity.value : entity;
					this.clearAttributes([
						"FilterEditData",
						"EntityFilters",
						"EntityChangeType"
					]);
					this.set("EntitySchemaUId", entitySchemaUId);
					this.validAttributes([
						"ExpectChanges"
					]);
				},

				/**
				 * Initializes signal entity.
				 * @protected
				 * @param {BPMSoft.ProcessStartSignalSchema} element Process start signal element.
				 */
				initSignalEntity: function(element) {
					var signal = element.getPropertyValue("signal");
					if (!Ext.isEmpty(signal) && signal !== "null") {
						this.set("Signal", signal);
					}
					this.set("EntitySchemaSelect", element.getPropertyValue("entitySchemaUId"), {
						silent: true
					});
					this.set("EntitySignal", element.getPropertyValue("entitySignal"));
					this.set("HasEntityColumnChange", element.getPropertyValue("hasEntityColumnChange"));
					this.set("NewEntityChangedColumns", element.getPropertyValue("newEntityChangedColumns"));
					this.set("HasEntityFilters", element.getPropertyValue("hasEntityFilters"));
					this.set("EntityFilters", element.getPropertyValue("entityFilters"));
				},

				/**
				 * Initializes SignalType list.
				 * @protected
				 */
				initSignalTypeList: function(element) {
					var waitingEntitySignal = element.getPropertyValue("waitingEntitySignal");
					var waitingRandomSignal = element.getPropertyValue("waitingRandomSignal");
					this.set("WaitingRandomSignal", waitingRandomSignal);
					this.set("WaitingEntitySignal", waitingEntitySignal);
					var signalTypeList = this.getSignalTypeList();
					var isObjectSignal = waitingEntitySignal && !waitingRandomSignal;
					var objectSignal = SignalEnum.SignalType.ObjectSignal;
					var simpleSignal = SignalEnum.SignalType.SimpleSignal;
					var index = isObjectSignal ? objectSignal : simpleSignal;
					var signalType = signalTypeList[index];
					this.set("SignalType", signalType);
					this.on("change:SignalType", this.onSignalTypeChanged, this);
				},

				/**
				 * SignalType change handler.
				 * @protected
				 */
				onSignalTypeChanged: function() {
					if (!this.getObjectSignalFiltersControlGroupVisible()) {
						this.unloadFilterUnitModule();
					}
					this.clearAttributes([
						"EntityChangeType",
						"EntityFilters",
						"EntitySchemaSelect",
						"ExpectChanges",
						"FilterEditData",
						"Signal",
						"RecordId"
					]);
					this.validAttributes([
						"EntityChangeType",
						"EntitySchemaSelect",
						"ExpectChanges",
						"Signal",
						"RecordId"
					]);
				},

				/**
				 * Returns SignalType list.
				 * @protected
				 * @return {Object} SignalType list.
				 */
				getSignalTypeList: function() {
					var list = {};
					var simpleSignal = SignalEnum.SignalType.SimpleSignal;
					var objectSignal = SignalEnum.SignalType.ObjectSignal;
					list[simpleSignal] = {
						value: simpleSignal,
						displayValue: this.get("Resources.Strings.SimpleSignalCaption")
					};
					list[objectSignal] = {
						value: objectSignal,
						displayValue: this.get("Resources.Strings.ObjectSignalCaption")
					};
					return list;
				},

				/**
				 * The event handler for preparing of the data drop-down SignalType.
				 * @protected
				 * @param {Object} filter Filters for data preparation.
				 * @param {BPMSoft.Collection} list The data for the drop-down list.
				 */
				prepareSignalTypeList: function(filter, list) {
					if (list === null) {
						return;
					}
					list.clear();
					list.loadAll(this.getSignalTypeList());
				},

				/**
				 * Initializes EntityChangeType list.
				 * @protected
				 */
				initEntityChangeTypeList: function() {
					var entityChangeType = this.BPMSoft.EntityChangeType;
					var entitySignal = this.get("EntitySignal");
					if (!Ext.isEmpty(this.get("EntitySchemaSelect")) &&
						entitySignal === entityChangeType.None) {
						entitySignal = entityChangeType.Inserted;
					}
					if (entitySignal !== entityChangeType.None) {
						var entityChangeTypeList = this.getEntityChangeTypeList();
						this.set("EntityChangeType", entityChangeTypeList[entitySignal], {
							silent: true
						});
					}
					this.on("change:EntityChangeType", this.onEntityChangeTypeChanged, this);
				},

				/**
				 * EntityChangeType change handler.
				 * @private
				 */
				onEntityChangeTypeChanged: function() {
					var entitySignal = this.get("EntityChangeType");
					if (Ext.isEmpty(entitySignal)) {
						this.unloadFilterUnitModule();
					}
					this.clearAttributes(["ExpectChanges"]);
					this.validAttributes(["ExpectChanges"]);
					this.clearEntitySchemaColumns();
				},

				/**
				 * Returns EntityChangeType list.
				 * @protected
				 * @return {Object} EntityChangeType list.
				 */
				getEntityChangeTypeList: function() {
					var list = {};
					var entityChangeType = this.BPMSoft.EntityChangeType;
					var inserted = entityChangeType.Inserted;
					var updated = entityChangeType.Updated;
					var deleted = entityChangeType.Deleted;
					list[inserted] = {
						value: inserted,
						displayValue: this.get("Resources.Strings.InsertedEntityChangeTypeCaption")
					};
					list[updated] = {
						value: updated,
						displayValue: this.get("Resources.Strings.UpdatedEntityChangeTypeCaption")
					};
					list[deleted] = {
						value: deleted,
						displayValue: this.get("Resources.Strings.DeletedEntityChangeTypeCaption")
					};
					return list;
				},

				/**
				 * The event handler for preparing of the data drop-down EntityChangeType.
				 * @protected
				 * @param {Object} filter Filters for data preparation.
				 * @param {BPMSoft.Collection} list The data for the drop-down list.
				 */
				prepareEntityChangeTypeList: function(filter, list) {
					if (list === null) {
						return;
					}
					list.clear();
					list.loadAll(this.getEntityChangeTypeList());
				},

				/**
				 * Initializes ExpectChanges list.
				 * @protected
				 */
				initExpectChangesList: function() {
					var hasEntityColumnChange = this.get("HasEntityColumnChange");
					var index = hasEntityColumnChange ? 1 : 0;
					var expectChangesList = this.getExpectChangesList();
					var expectChanges = expectChangesList[index];
					this.set("ExpectChanges", expectChanges, {
						silent: true
					});
					this.on("change:ExpectChanges", this.onExpectChangesChanged, this);
				},

				/**
				 * ExpectChanges change handler.
				 * @protected
				 */
				onExpectChangesChanged: function() {
					this.clearEntitySchemaColumns();
				},

				/**
				 * The event handler for preparing of the data drop-down ExpectChanges.
				 * @protected
				 * @param {Object} filter Filters for data preparation.
				 * @param {BPMSoft.Collection} list The data for the drop-down list.
				 */
				prepareExpectChangesList: function(filter, list) {
					if (list === null) {
						return;
					}
					list.clear();
					list.loadAll(this.getExpectChangesList());
				},

				/**
				 * Returns ExpectChanges list.
				 * @protected
				 * @return {Object} ExpectChanges list.
				 */
				getExpectChangesList: function() {
					var list = {};
					var anyField = SignalEnum.ExpectChanges.AnyField;
					var anySelectedField = SignalEnum.ExpectChanges.AnySelectedField;
					list[anyField] = {
						value: anyField,
						displayValue: this.get("Resources.Strings.AnyFieldCaption")
					};
					list[anySelectedField] = {
						value: anySelectedField,
						displayValue: this.get("Resources.Strings.AnySelectedFieldCaption")
					};
					return list;
				},

				/**
				 * Returns the value of visibility for simple signal controls group.
				 * @protected
				 * @return {Boolean}
				 */
				getSimpleSignalControlGroupVisible: function() {
					var signalType = this.get("SignalType");
					signalType = Ext.isObject(signalType) ? signalType.value : signalType;
					return (signalType === SignalEnum.SignalType.SimpleSignal);
				},

				/**
				 * Returns the value of visibility for object signal controls group.
				 * @protected
				 * @return {Boolean}
				 */
				getObjectSignalControlGroupVisible: function() {
					var signalType = this.get("SignalType");
					signalType = Ext.isObject(signalType) ? signalType.value : signalType;
					return (signalType === SignalEnum.SignalType.ObjectSignal);
				},

				/**
				 * Returns the value of visibility for object signal properties controls group.
				 * @protected
				 * @return {Boolean}
				 */
				getObjectSignalPropertiesControlGroupVisible: function() {
					var isEmpty = Ext.isEmpty(this.get("EntitySchemaSelect"));
					var objectSignalControlGroupVisible = this.getObjectSignalControlGroupVisible();
					return (objectSignalControlGroupVisible && !isEmpty);
				},

				/**
				 * Returns the value of visibility for object signal filters controls group.
				 * @protected
				 * @return {Boolean}
				 */
				getObjectSignalFiltersControlGroupVisible: function() {
					var isEmpty = Ext.isEmpty(this.get("EntityChangeType"));
					var objectSignalControlGroupVisible = this.getObjectSignalControlGroupVisible();
					var objectSignalPropertiesControlGroupVisible = this.getObjectSignalPropertiesControlGroupVisible();
					return (objectSignalControlGroupVisible &&
						objectSignalPropertiesControlGroupVisible && !isEmpty);
				},

				/**
				 * Returns the value of visibility for expect changes.
				 * @protected
				 * @return {Boolean}
				 */
				getExpectChangesVisible: function() {
					var entityChangeType = this.get("EntityChangeType");
					entityChangeType = Ext.isObject(entityChangeType) ? entityChangeType.value : entityChangeType;
					var objectSignalPropertiesControlGroupVisible = this.getObjectSignalPropertiesControlGroupVisible();
					return (objectSignalPropertiesControlGroupVisible &&
						entityChangeType === this.BPMSoft.EntityChangeType.Updated);
				},

				/**
				 * Returns the value of visibility for entity columns container.
				 * @protected
				 * @return {Boolean}
				 */
				getEntityColumnsContainerVisible: function() {
					var expectChanges = this.get("ExpectChanges");
					expectChanges = Ext.isObject(expectChanges) ? expectChanges.value : expectChanges;
					var expectChangesVisible = this.getExpectChangesVisible();
					return (expectChangesVisible && expectChanges === SignalEnum.ExpectChanges.AnySelectedField);
				},

				/**
				 * Returns the value of visibility for filter info button.
				 * @protected
				 * @return {Boolean}
				 */
				setFilterInfoButtonVisible: function() {
					var filterEditData = this.get("FilterEditData");
					var visible = Ext.isEmpty(filterEditData) || filterEditData.isEmpty();
					visible = visible && this.getObjectSignalFiltersControlGroupVisible();
					this.set("FilterInfoButtonVisible", visible);
				},

				/**
				 * Returns the value of visibility for the object signal filter.
				 * @protected
				 * @return {String}
				 */
				getObjectSignalFilterCaption: function() {
					var caption = "";
					var entityChangeType = this.get("EntityChangeType");
					entityChangeType = Ext.isObject(entityChangeType) ? entityChangeType.value : entityChangeType;
					switch (entityChangeType) {
						case this.BPMSoft.EntityChangeType.Inserted:
							caption = this.get("Resources.Strings.InsertedObjectSignalFilterCaption");
							break;
						case this.BPMSoft.EntityChangeType.Updated:
							caption = this.get("Resources.Strings.UpdatedObjectSignalFilterCaption");
							break;
						case this.BPMSoft.EntityChangeType.Deleted:
							caption = this.get("Resources.Strings.DeletedObjectSignalFilterCaption");
							break;
					}
					return caption;
				},

				/**
				 * Clears view model attributes value.
				 * @protected
				 * @param {String[]} attributes View model attributes.
				 */
				clearAttributes: function(attributes) {
					attributes.forEach(function(key) {
						this.set(key, null);
					}, this);
				},

				/**
				 * Sets validation info true for attributes.
				 * @protected
				 * @param {String[]} attributes View model attributes.
				 */
				validAttributes: function(attributes) {
					attributes.forEach(function(key) {
						this.setValidationInfo(key, true, null);
					}, this);
				}

				//endregion
			},
			diff: /**SCHEMA_DIFF*/ [

				// region MainControlContainer

				{
					"operation": "insert",
					"name": "MainControlContainer",
					"parentName": "EditorsContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"wrapClass": ["base-signal-properties"]
					}
				}, {
					"operation": "insert",
					"name": "MainControlGroup",
					"parentName": "MainControlContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				}, {
					"operation": "insert",
					"name": "RecommendationLabel",
					"parentName": "MainControlGroup",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24
						},
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "Resources.Strings.RecommendationCaption"
						},
						"classes": {
							"labelClass": ["t-title-label-proc"]
						}
					}
				}, {
					"operation": "insert",
					"name": "SignalType",
					"parentName": "MainControlGroup",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24
						},
						"contentType": this.BPMSoft.ContentType.ENUM,
						"labelConfig": {
							"visible": false
						},
						"controlConfig": {
							"prepareList": {
								"bindTo": "prepareSignalTypeList"
							}
						},
						"wrapClass": ["no-caption-control"]
					}
				}, {
					"operation": "insert",
					"name": "useBackgroundMode",
					"parentName": "MainControlGroup",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 24
						},
						"visible": {
							"bindTo": "canUseBackgroundProcessMode"
						},
						"wrapClass": ["t-checkbox-control"]
					}
				},

				// endregion

				// region SimpleSignalControlGroup

				{
					"operation": "insert",
					"name": "SimpleSignalControlGroup",
					"parentName": "MainControlGroup",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24
						},
						"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
						"visible": {
							"bindTo": "getSimpleSignalControlGroupVisible"
						},
						"items": []
					}
				}, {
					"operation": "insert",
					"name": "Signal",
					"parentName": "SimpleSignalControlGroup",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24
						},
						"isRequired": true,
						"wrapClass": ["top-caption-control"],
						"markerValue": "SignalValue",
						"caption": {
							"bindTo": "Resources.Strings.SignalCaption"
						}
					}
				},

				// endregion

				// region ObjectSignalControlGroup

				{
					"operation": "insert",
					"name": "ObjectSignalControlGroup",
					"parentName": "MainControlGroup",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 24
						},
						"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
						"visible": {
							"bindTo": "getObjectSignalControlGroupVisible"
						},
						"items": []
					}
				}, {
					"operation": "insert",
					"name": "EntitySchemaSelect",
					"parentName": "ObjectSignalControlGroup",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24
						},
						"isRequired": true,
						"contentType": this.BPMSoft.ContentType.ENUM,
						"labelConfig": {
							"visible": true
						},
						"controlConfig": {
							"prepareList": {
								"bindTo": "prepareEntityList"
							},
							"filterComparisonType": this.BPMSoft.StringFilterType.CONTAIN
						},
						"wrapClass": ["top-caption-control"],
						"caption": {
							"bindTo": "Resources.Strings.EntityCaption"
						}
					}
				},

				// endregion

				// region ObjectSignalPropertiesControlGroup

				{
					"operation": "insert",
					"name": "ObjectSignalPropertiesControlGroup",
					"parentName": "ObjectSignalControlGroup",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24
						},
						"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
						"visible": {
							"bindTo": "getObjectSignalPropertiesControlGroupVisible"
						},
						"items": []
					}
				}, {
					"operation": "insert",
					"name": "EntityChangeTypeLabel",
					"parentName": "ObjectSignalPropertiesControlGroup",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24
						},
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "Resources.Strings.EntityChangeTypeCaption"
						},
						"classes": {
							"labelClass": ["t-title-label-proc"]
						}
					}
				}, {
					"operation": "insert",
					"name": "EntityChangeType",
					"parentName": "ObjectSignalPropertiesControlGroup",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24
						},
						"isRequired": true,
						"contentType": this.BPMSoft.ContentType.ENUM,
						"labelConfig": {
							"visible": false
						},
						"controlConfig": {
							"prepareList": {
								"bindTo": "prepareEntityChangeTypeList"
							}
						},
						"wrapClass": ["no-caption-control"]
					}
				}, {
					"operation": "insert",
					"name": "ExpectChanges",
					"parentName": "ObjectSignalPropertiesControlGroup",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24
						},
						"isRequired": true,
						"contentType": this.BPMSoft.ContentType.ENUM,
						"controlConfig": {
							"prepareList": {
								"bindTo": "prepareExpectChangesList"
							}
						},
						"labelConfig": {
							"visible": true
						},
						"wrapClass": ["top-caption-control"],
						"visible": {
							"bindTo": "getExpectChangesVisible"
						},
						"caption": {
							"bindTo": "Resources.Strings.ExpectChangesCaption"
						}
					}
				},

				// endregion

				// region EntityColumnsContainer

				{
					"operation": "insert",
					"parentName": "ObjectSignalPropertiesControlGroup",
					"propertyName": "items",
					"name": "EntityColumnsContainer",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 24
						},
						"items": [],
						"visible": {
							"bindTo": "getEntityColumnsContainerVisible"
						},
						"markerValue": "EntityColumnsContainer",
						"wrapClass": ["entity-columns-container"]
					}
				}, {
					"operation": "insert",
					"parentName": "EntityColumnsContainer",
					"propertyName": "items",
					"name": "RecordColumnValuesContainer",
					"values": {
						"generator": "ConfigurationItemGenerator.generateContainerList",
						"idProperty": "Id",
						"collection": "EntitySchemaColumnsControlsSelect",
						"onGetItemConfig": "getEntitySchemaColumnsControlsSelectViewConfig",
						"itemPrefix": "Id",
						"classes": {
							"wrapClassName": ["record-column-values-container", "grid-layout"]
						}
					}
				}, {
					"operation": "insert",
					"parentName": "EntityColumnsContainer",
					"propertyName": "items",
					"name": "AddRecordColumnValuesButton",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"imageConfig": {
							"bindTo": "Resources.Images.AddButtonImage"
						},
						"caption": {
							"bindTo": "Resources.Strings.AddRecordColumnValuesButtonCaption"
						},
						"classes": {
							"wrapperClass": ["add-record-column-values-button"]
						},
						"click": {
							"bindTo": "onAddEntitySchemaColumnControlSelect"
						}
					}
				},

				// endregion

				// region ObjectSignalFiltersControlGroup

				{
					"operation": "insert",
					"name": "ObjectSignalFiltersControlGroup",
					"parentName": "ObjectSignalControlGroup",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24
						},
						"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
						"visible": {
							"bindTo": "getObjectSignalFiltersControlGroupVisible"
						},
						"items": []
					}
				}, {
					"operation": "insert",
					"name": "ObjectSignalFilterLabel",
					"parentName": "ObjectSignalFiltersControlGroup",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 23
						},
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "getObjectSignalFilterCaption"
						},
						"classes": {
							"labelClass": ["t-title-label-proc"]
						}
					}
				}, {
					"operation": "insert",
					"name": "FilterInfoButtonContainer",
					"parentName": "ObjectSignalFiltersControlGroup",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 23,
							"row": 0,
							"colSpan": 1
						},
						"visible": {
							"bindTo": "FilterInfoButtonVisible"
						},
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"markerValue": "FilterInfoButtonContainer",
						"wrapClass": ["filter-info-button-container"]
					}
				}, {
					"operation": "insert",
					"name": "FilterInfoButton",
					"parentName": "FilterInfoButtonContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.INFORMATION_BUTTON,
						"content": {
							"bindTo": "Resources.Strings.FilterInformationText"
						}
					}
				}, {
					"operation": "insert",
					"name": "ExtendedFiltersContainer",
					"parentName": "ObjectSignalFiltersControlGroup",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24
						},
						"id": "ExtendedFiltersContainer",
						"selectors": {
							"wrapEl": "#ExtendedFiltersContainer"
						},
						"afterrender": {
							"bindTo": "updateFilterModule"
						},
						"afterrerender": {
							"bindTo": "updateFilterModule"
						},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"markerValue": "ExtendedFiltersContainer",
						"wrapClass": ["extended-filters-container"]
					}
				}

				// endregion

			] /**SCHEMA_DIFF*/,
			rules: {
				"Signal": {
					"BindParameterRequiredSignalToSignalType": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.REQUIRED,
						"conditions": [{
							"leftExpression": {
								"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
								"attribute": "SignalType"
							},
							"comparisonType": this.BPMSoft.ComparisonType.EQUAL,
							"rightExpression": {
								"type": BusinessRuleModule.enums.ValueType.CONSTANT,
								"value": SignalEnum.SignalType.SimpleSignal
							}
						}]
					}
				},
				"EntitySchemaSelect": {
					"BindParameterRequiredEntitySchemaSelectToSignalType": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.REQUIRED,
						"conditions": [{
							"leftExpression": {
								"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
								"attribute": "SignalType"
							},
							"comparisonType": this.BPMSoft.ComparisonType.EQUAL,
							"rightExpression": {
								"type": BusinessRuleModule.enums.ValueType.CONSTANT,
								"value": SignalEnum.SignalType.ObjectSignal
							}
						}]
					}
				},
				"EntityChangeType": {
					"BindParameterRequiredEntityChangeTypeToSignalType": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.REQUIRED,
						"logical": this.BPMSoft.LogicalOperatorType.AND,
						"conditions": [{
							"leftExpression": {
								"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
								"attribute": "SignalType"
							},
							"comparisonType": this.BPMSoft.ComparisonType.EQUAL,
							"rightExpression": {
								"type": BusinessRuleModule.enums.ValueType.CONSTANT,
								"value": SignalEnum.SignalType.ObjectSignal
							}
						}, {
							"leftExpression": {
								"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
								"attribute": "EntitySchemaSelect"
							},
							"comparisonType": this.BPMSoft.ComparisonType.IS_NOT_NULL
						}]
					}
				},
				"ExpectChanges": {
					"BindParameterRequiredExpectChangesToSignalType": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.REQUIRED,
						"logical": this.BPMSoft.LogicalOperatorType.AND,
						"conditions": [{
							"leftExpression": {
								"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
								"attribute": "SignalType"
							},
							"comparisonType": this.BPMSoft.ComparisonType.EQUAL,
							"rightExpression": {
								"type": BusinessRuleModule.enums.ValueType.CONSTANT,
								"value": SignalEnum.SignalType.ObjectSignal
							}
						}, {
							"leftExpression": {
								"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
								"attribute": "EntitySchemaSelect"
							},
							"comparisonType": this.BPMSoft.ComparisonType.IS_NOT_NULL
						}, {
							"leftExpression": {
								"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
								"attribute": "EntityChangeType"
							},
							"comparisonType": this.BPMSoft.ComparisonType.IS_NOT_NULL
						}, {
							"leftExpression": {
								"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
								"attribute": "EntityChangeType"
							},
							"comparisonType": this.BPMSoft.ComparisonType.EQUAL,
							"rightExpression": {
								"type": BusinessRuleModule.enums.ValueType.CONSTANT,
								"value": this.BPMSoft.EntityChangeType.Updated
							}
						}]
					}
				}
			}
		};
	}
);
