/**
 * Using as baseDcmSchemaName in DcmSchemaElementPropertiesPageBuilder.
 */
define("BaseDcmSchemaElementPropertiesPage", ["BaseDcmSchemaElementPropertiesPageResources", "BusinessRuleModule",
		"DcmSchemaElementTransitionFactory", "MenuItemsMappingMixin", "DcmConditionItemViewModel"],
	function(resources, businessRuleModule) {
		return {

			mixins: {
				menuItemsMappingMixin: "BPMSoft.MenuItemsMappingMixin"
			},

			attributes: {
				/**
				 * Caption.
				 */
				"caption": {
					isRequired: true
				},

				/**
				 * Dcm element.
				 */
				"DcmElement": {
					dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * DcmSchema element transition.
				 */
				"Transition": {
					"dataValueType": BPMSoft.DataValueType.LOOKUP,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"isRequired": true
				},

				/**
				 * DcmSchema element after which current element should be executed.
				 */
				"ExecuteAfterElement": {
					"dataValueType": BPMSoft.DataValueType.LOOKUP,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Collection of possible transitions.
				 */
				"TransitionsCollection": {
					"dataValueType": BPMSoft.DataValueType.COLLECTION,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Collection of possible DcmSchema elements, after which current element can be executed.
				 */
				"DcmElementsCollection": {
					"dataValueType": BPMSoft.DataValueType.COLLECTION,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * DcmSchema element required type.
				 */
				"RequiredType": {
					"dataValueType": BPMSoft.DataValueType.LOOKUP,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"isRequired": true
				},

				/**
				 * Conditions collection.
				 */
				"Conditions": {
					"dataValueType": BPMSoft.DataValueType.COLLECTION
				},

				/**
				 * Flag that indicate whether ConditionHeaderContainer is visible or not.
				 */
				"HasConditions": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * Flag that indicate whether Conditions is available or not.
				 */
				"UseConditions": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * Flag that indicate whether Conditions are using formula to determine result or not.
				 */
				"UseFormulaConditions": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"value": false
				}
			},

			rules: {
				"ExecuteAfterElement": {
					"BindExecuteAfterElementRequiredToExecutionType": {
						"ruleType": businessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": businessRuleModule.enums.Property.REQUIRED,
						"conditions": [{
							"leftExpression": {
								"type": businessRuleModule.enums.ValueType.ATTRIBUTE,
								"attribute": "Transition"
							},
							"comparisonType": this.BPMSoft.ComparisonType.NOT_EQUAL,
							"rightExpression": {
								"type": businessRuleModule.enums.ValueType.CONSTANT,
								"value": BPMSoft.DcmSchemaElementTransitionFactory.defaultTransitionTypeUId
							}
						}]
					}
				}
			},

			methods: {

				//region Methods: Private

				/**
				 * Initialize TransitionsCollection.
				 * @private
				 */
				_initTransitionsCollection: function() {
					var transitionsCollection = Ext.create("BPMSoft.Collection");
					this._fillTransitionsCollection(transitionsCollection);
					this.set("TransitionsCollection", transitionsCollection);
				},

				/**
				 * Initialize DcmElementsCollection.
				 * @private
				 */
				_initDcmElementsCollection: function() {
					var dcmElementsElementCollection = Ext.create("BPMSoft.Collection");
					this._fillDcmElementsCollection(dcmElementsElementCollection);
					this.set("DcmElementsCollection", dcmElementsElementCollection);
				},

				/**
				 * Initialize Transition attribute value.
				 * @private
				 */
				_initDcmElementTransition: function() {
					var dcmElement = this.get("DcmElement");
					var transitionsCollection = this.get("TransitionsCollection");
					var dcmElementTransition = dcmElement.getTransition();
					var transitionTypeUId = dcmElementTransition.getTransitionTypeUId();
					var transition = transitionsCollection.get(transitionTypeUId);
					this.set("Transition", transition);
				},

				/**
				 * Initialize ExecuteAfterElement attribute value.
				 * @private
				 */
				_initExecuteAfterElement: function() {
					var dcmElement = this.get("DcmElement");
					var dcmElementsCollection = this.get("DcmElementsCollection");
					var transition = dcmElement.getTransition();
					var sourceElement = transition.findSourceElement();
					var executeAfterElement = dcmElementsCollection.find(sourceElement ? sourceElement.uId : null);
					this.set("ExecuteAfterElement", executeAfterElement);
				},

				/**
				 * Actualize and returns actual DcmElementsCollection.
				 * @private
				 * @return {BPMSoft.Collection}
				 */
				_getActualDcmElementsCollection: function() {
					var dcmElementsCollection = this.get("DcmElementsCollection");
					this._fillDcmElementsCollection(dcmElementsCollection);
					return dcmElementsCollection;
				},

				/**
				 * DcmSchema changed-event handler. Actualize Transition attribute.
				 * @private
				 * @param {Object} eventData Changed-event data of DcmSchema.
				 */
				_onDcmSchemaChanged: function(eventData) {
					var dcmElement = this.get("DcmElement");
					if (eventData.eventName !== "transitionChanged") {
						return;
					}
					if (eventData.elementUId === dcmElement.uId && eventData.operation === "add") {
						var transitionsCollection = this.get("TransitionsCollection");
						var dcmElementTransition = dcmElement.getTransition();
						var transitionTypeUId = dcmElementTransition.getTransitionTypeUId();
						var transition = this.get("Transition");
						if (transition.value !== transitionTypeUId) {
							transition = transitionsCollection.get(transitionTypeUId);
							this.set("Transition", transition);
						}
					}
				},

				/**
				 * Handler of Transition attribute change event. Actualize DcmSchemaElement transition and sets default
				 * ExecuteAfterElement attribute value.
				 * @private
				 */
				_onTransitionChange: function() {
					var transition = this.get("Transition");
					if (transition) {
						var dcmElement = this.get("DcmElement");
						const value = transition.value;
						var dcmElementTransition = BPMSoft.DcmSchemaElementTransitionFactory
							.createTransitionByTypeUId(value, {elementUId: dcmElement.uId});
						dcmElement.setTransition(dcmElementTransition);
						var previousElement = null;
						if (!BPMSoft.DcmSchemaElementTransitionFactory.getIsDefaultTransitionByTypeUId(value)) {
							var executeAfterElementCollection = this._getActualDcmElementsCollection();
							previousElement = executeAfterElementCollection.last();
						}
						this.set("ExecuteAfterElement", previousElement);
					}
				},

				/**
				 * Handler of ExecuteAfterElement attribute change event. Actualize DcmSchemaElement transition.
				 * @private
				 */
				_onExecuteAfterElementChange: function() {
					var dcmElement = this.get("DcmElement");
					var executeAfterElement = this.get("ExecuteAfterElement");
					var executeAfterElementUId = executeAfterElement ? executeAfterElement.value : null;
					var dcmElementTransition = dcmElement.getTransition();
					dcmElementTransition.sourceElementUId = executeAfterElementUId;
				},

				/**
				 * Fills the list of possible values of DcmSchemaElement transitions.
				 * @private
				 * @param {BPMSoft.Collection} list The list that will be to filled in values.
				 */
				_fillTransitionsCollection: function(list) {
					var columnsConfig = {};
					var transitions = BPMSoft.DcmSchemaElementTransitionFactory.getTransitionsCaptions();
					BPMSoft.each(transitions, function(caption, typeUId) {
						columnsConfig[typeUId] = {
							value: typeUId,
							displayValue: caption
						};
					}, this);
					list.clear();
					list.loadAll(columnsConfig);
				},

				/**
				 * Fills the list of possible values of ExecuteAfterElement.
				 * @private
				 * @param {BPMSoft.Collection} list The list that will be to filled in values.
				 */
				_fillDcmElementsCollection: function(list) {
					var dcmElement = this.get("DcmElement");
					var stageUId = dcmElement.containerUId;
					var dcmSchema = dcmElement.parentSchema;
					var stage = dcmSchema.stages.get(stageUId);
					var columnsConfig = {};
					stage.elements.each(function(element) {
						if (element.uId !== dcmElement.uId) {
							columnsConfig[element.uId] = {
								value: element.uId,
								displayValue: element.getDisplayValue()
							};
						}
						return element.uId !== dcmElement.uId;
					}, this);
					list.clear();
					list.loadAll(columnsConfig);
				},

				/**
				 * Init process flow element by dcm element.
				 * @private
				 * @param {BPMSoft.DcmSchemaElement} dcmElement Dcm element.
				 * @return {BPMSoft.manager.ProcessFlowElementSchema} Process flow element of dcm element.
				 */
				_initProcessFlowElement: function(dcmElement) {
					this.set("DcmElement", dcmElement);
					this._initTransitionsCollection();
					this._initDcmElementsCollection();
					this._initDcmElementTransition();
					this.initDcmElementRequiredType();
					this._initExecuteAfterElement();
					this.on("change:Transition", this._onTransitionChange, this);
					this.on("change:ExecuteAfterElement", this._onExecuteAfterElementChange, this);
					this.on("change:RequiredType", this.onRequiredTypeChange, this);
					dcmElement.parentSchema.on("changed", this._onDcmSchemaChanged, this);
					var flowElement = dcmElement.processFlowElement;
					flowElement.caption = dcmElement.caption.clone();
					flowElement.description = dcmElement.description.clone();
					return flowElement;
				},

				/**
				 * Creates dcm condition item view model with init parameters.
				 * @private
				 * @param {Object} [config] Item config object.
				 * @param {String} [config.resultId] Result identifier.
				 * @param {String} [config.resultFormula] Result formula.
				 * @param {String} [config.nextStageId] Next stage identifier.
				 * @return {BPMSoft.configuration.DcmConditionItemViewModel}
				 */
				_createDcmConditionItemViewModel: function(config) {
					var values = Ext.apply({}, config, {
						packageUId: this.get("packageUId"),
						parentCollection: this.get("Conditions"),
						useFormulaConditions: this.get("UseFormulaConditions"),
						resultList: this.getConditionsResultList(),
						parameterName: "ResultFormula"
					});
					var viewModel = new BPMSoft.DcmConditionItemViewModel({
						sandbox: this.sandbox,
						parentElement: this.get("DcmElement"),
						values: values
					});
					return viewModel;
				},

				/**
				 * Returns conditions array.
				 * @private
				 * @return {{resultId: String, nextStageId: String}[]}
				 */
				_getConditions: function() {
					var conditions = this.get("Conditions");
					return conditions.getItems()
						.filter(function(item) {
							const resultFormula = item.get("ResultFormula");
							const resultFormulaValue = resultFormula && resultFormula.value;
							return (item.get("Result") || !BPMSoft.isEmpty(resultFormulaValue)) && item.get("NextStage");
						})
						.map(function(item) {
							var result = item.get("Result");
							var resultFormula = item.get("ResultFormula");
							var nextStage = item.get("NextStage");
							return {
								resultId: result && result.value,
								resultFormula: resultFormula,
								nextStageId: nextStage.value
							};
						});
				},

				//endregion

				//region Methods: Protected

				/**
				 * @inheritdoc MappingEditMixin#getInvokerUId
				 * @overridden
				 */
				getInvokerUId: function() {
					return this.get("DcmElement").uId;
				},

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
				 * @overridden
				 */
				init: function(callback, scope) {
					this.set("IsAfterActivitySaveScriptEditVisible", false);
					this.callParent([function() {
						this.initMappingEntitySchema(callback, scope);
					}, this]);
				},

				/**
				 * @inheritdoc BPMSoft.BaseProcessSchemaElementPropertiesPage#onElementDataLoad
				 * @overridden
				 */
				onElementDataLoad: function(dcmElement, callback, scope) {
					var flowElement = this._initProcessFlowElement(dcmElement);
					this.callParent([flowElement, function() {
						this.initConditions();
						callback.call(scope);
					}, this]);
				},

				/**
				 * @inheritdoc BPMSoft.BaseProcessSchemaElementPropertiesPage#saveValues
				 * @overridden
				 */
				saveValues: function() {
					this.callParent(arguments);
					var dcmElement = this.get("DcmElement");
					var caption = this.get("caption");
					var description = this.get("description");
					var requiredType = this.get("RequiredType");
					dcmElement.setLocalizableStringPropertyValue("caption", caption);
					dcmElement.setLocalizableStringPropertyValue("description", description);
					var requiredTypeValue = requiredType && requiredType.value ||
						BPMSoft.DcmConstants.ElementRequiredType.NOT_REQUIRED.value;
					dcmElement.setPropertyValue("requiredType", requiredTypeValue);
					this.saveConditions();
				},

				/**
				 * @inheritdoc BPMSoft.BaseProcessSchemaElementPropertiesPage#saveValidationResults
				 * @overridden
				 */
				saveValidationResults: function() {
					this.callParent(arguments);
					var dcmElement = this.get("DcmElement");
					var processElement = this.get("ProcessElement");
					dcmElement.setPropertyValue("isValidateExecuted",
						dcmElement.isValidateExecuted && processElement.isValidateExecuted);
					var isDcmElementValid = this.isElementValid(dcmElement.validationResults);
					dcmElement.setPropertyValue("isValid", isDcmElementValid && processElement.isValid);
				},

				/**
				 * @inheritdoc BPMSoft.BaseProcessSchemaElementPropertiesPage#onDestroy
				 * @overridden
				 */
				onDestroy: function() {
					this.callParent(arguments);
					var dcmElement = this.get("DcmElement");
					if (dcmElement) {
						dcmElement.parentSchema.un("changed", this._onDcmSchemaChanged, this);
					}
				},

				/**
				 * Handles on RequiredType attribute change.
				 * @protected
				 * @param {BPMSoft.BaseViewModel} viewModel View model.
				 * @param {BPMSoft.DcmConstants.ElementRequiredType} requiredType Dcm schema element required type.
				 */
				onRequiredTypeChange: function(viewModel, requiredType) {
					var value = requiredType
						? requiredType.value
						: BPMSoft.DcmConstants.ElementRequiredType.NOT_REQUIRED.value;
					var element = this.get("DcmElement");
					element.setPropertyValue("requiredType", value);
				},

				/**
				 * Returns default value for RequiredType.
				 * @protected
				 * @return {Object}
				 */
				getDefaultRequiredType: function() {
					return BPMSoft.DcmConstants.ElementRequiredType.NOT_REQUIRED;
				},

				/**
				 * Initialize RequiredType attribute value.
				 * @protected
				 */
				initDcmElementRequiredType: function() {
					var dcmElement = this.get("DcmElement");
					var requiredType = dcmElement.requiredType;
					var value = requiredType === null
						? this.getDefaultRequiredType()
						: BPMSoft.findWhere(BPMSoft.DcmConstants.ElementRequiredType, {value: requiredType});
					this.set("RequiredType", value);
				},

				/**
				 * Init dcm condition parameter.
				 * @protected
				 */
				initConditions: function() {
					var collection = new BPMSoft.ObjectCollection();
					collection.on("changed", this.onConditionsChanged, this);
					this.set("Conditions", collection);
					var element = this.get("DcmElement");
					var conditions = element.conditions;
					if (!conditions) {
						return;
					}
					var items = BPMSoft.decode(conditions);
					items.forEach(function(item) {
						var viewModel = this._createDcmConditionItemViewModel(item);
						collection.add(viewModel.get("Id"), viewModel);
					}, this);
				},

				/**
				 * Handler for changed Conditions collection.
				 * Hide\show ConditionHeaderContainer depends on Conditions is empty or not.
				 * @protected
				 */
				onConditionsChanged: function() {
					var conditions = this.get("Conditions");
					this.set("HasConditions", conditions && !conditions.isEmpty());
				},

				/**
				 * Save Conditions collection to DcmElement.
				 * @protected
				 */
				saveConditions: function() {
					var element = this.get("DcmElement");
					var conditions = this._getConditions();
					element.conditions = conditions.length ? BPMSoft.encode(conditions) : null;
				},

				/**
				 * Handler for AddCondition button. Adds new condition item.
				 * @protected
				 */
				onAddConditionButton: function() {
					var conditions = this.get("Conditions");
					var viewModel = this._createDcmConditionItemViewModel();
					var id = viewModel.get("Id");
					conditions.add(id, viewModel);

					Ext.getCmp("AddConditionButton").getWrapEl().dom.scrollIntoView();
				},

				/**
				 * Returns conditions result list.
				 * @protected
				 * @return {Object}
				 */
				getConditionsResultList: function() {
					return {};
				},

				/**
				 * @inheritdoc BPMSoft.RootUserTaskPropertiesPage#onGetProcessElementInfo
				 * @overridden
				 */
				onGetProcessElementInfo: function() {
					const baseInfo = this.callParent(arguments);
					baseInfo.entitySchema = this.get("EntitySchema");
					return baseInfo;
				},

				//endregion

				//region Methods: Public

				/**
				 * Returns caption for ExecutionType field.
				 * @return {String}
				 */
				getTransitionCaption: function() {
					return resources.localizableStrings.WhenExecuteElementCaption;
				},

				/**
				 * Returns caption for ExecuteAfterElement field.
				 * @return {String}
				 */
				getExecuteAfterElementCaption: function() {
					return resources.localizableStrings.ExecuteAfterElementCaption;
				},

				/**
				 * Returns flag that indicates whether the ExecuteAfterElement field visible.
				 * @return {Boolean}
				 */
				getIsExecuteAfterElementVisible: function() {
					var transition = this.get("Transition");
					return transition && !BPMSoft.DcmSchemaElementTransitionFactory
						.getIsDefaultTransitionByTypeUId(transition.value);
				},

				/**
				 * Prepares list of values to display in dropDown list for Transition field.
				 * @param {String} filter Filter value.
				 * @param {BPMSoft.Collection} list The list that will be to filled in values.
				 */
				onPrepareTransitionList: function(filter, list) {
					var transitionsCollection = this.get("TransitionsCollection");
					list.clear();
					list.loadAll(transitionsCollection);
				},

				/**
				 * Prepares list of values to display in dropDown list for ExecuteAfterElement field.
				 * @param {String} filter Filter value.
				 * @param {BPMSoft.Collection} list The list that will be to filled in values.
				 */
				onPrepareDcmElementsList: function(filter, list) {
					if (!list) {
						return;
					}
					var dcmElementsCollection = this._getActualDcmElementsCollection();
					list.clear();
					list.loadAll(dcmElementsCollection);
				},

				/**
				 * Prepares list of values to display in dropDown list for Required step type field.
				 * @param {String} filter Filter value.
				 * @param {BPMSoft.Collection} list The list that will be to filled in values.
				 */
				onPrepareRequiredTypeList: function(filter, list) {
					list.clear();
					list.loadAll(BPMSoft.DcmConstants.ElementRequiredType);
				}

				//endregion

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "BaseDcmContainer",
					"propertyName": "items",
					"parentName": "EditorsContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				},

				// region Transitions

				{
					"operation": "insert",
					"name": "TransitionContainer",
					"propertyName": "items",
					"parentName": "BaseDcmContainer",
					"className": "BPMSoft.GridLayoutEdit",
					"values": {
						"layout": {"column": 0, "row": 0, "colSpan": 24},
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ExecutionTypeLabel",
					"parentName": "TransitionContainer",
					"propertyName": "items",
					"values": {
						"layout": {"column": 0, "row": 0, "colSpan": 24},
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "getTransitionCaption"
						},
						"classes": {
							"labelClass": ["t-title-label-proc"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "Transition",
					"parentName": "TransitionContainer",
					"propertyName": "items",
					"values": {
						"layout": {"column": 0, "row": 1, "colSpan": 24},
						"contentType": BPMSoft.ContentType.ENUM,
						"labelConfig": {
							"visible": false
						},
						"controlConfig": {
							"prepareList": {
								"bindTo": "onPrepareTransitionList"
							}
						},
						"wrapClass": ["top-caption-control"]
					}
				},
				{
					"operation": "insert",
					"name": "ExecuteAfterElement",
					"parentName": "TransitionContainer",
					"propertyName": "items",
					"values": {
						"layout": {"column": 0, "row": 2, "colSpan": 24},
						"contentType": BPMSoft.ContentType.ENUM,
						"controlConfig": {
							"prepareList": {
								"bindTo": "onPrepareDcmElementsList"
							}
						},
						// BusinessRuleModule copy controlConfig (with bindings) to labelConfig
						// if labelConfig not set. But label doesn't have bindings to list or prepareList
						"labelConfig": {},
						"caption": {
							"bindTo": "getExecuteAfterElementCaption"
						},
						"visible": {
							"bindTo": "getIsExecuteAfterElementVisible"
						},
						"wrapClass": ["top-caption-control"]
					}
				},

				// endregion

				// region RequiredType

				{
					"operation": "insert",
					"name": "RequiredTypeContainer",
					"propertyName": "items",
					"parentName": "BaseDcmContainer",
					"values": {
						"layout": {"column": 0, "row": 1, "colSpan": 24},
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "RequiredTypeLabel",
					"parentName": "RequiredTypeContainer",
					"propertyName": "items",
					"values": {
						"layout": {"column": 0, "row": 0, "colSpan": 24},
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "Resources.Strings.RequiredTypeCaption"
						},
						"classes": {
							"labelClass": ["t-title-label-proc"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "RequiredType",
					"parentName": "RequiredTypeContainer",
					"propertyName": "items",
					"values": {
						"layout": {"column": 0, "row": 1, "colSpan": 24},
						"contentType": BPMSoft.ContentType.ENUM,
						"labelConfig": {
							"visible": false
						},
						"controlConfig": {
							"prepareList": {
								"bindTo": "onPrepareRequiredTypeList"
							}
						},
						"wrapClass": ["top-caption-control"]
					}
				},

				// endregion

				// region Conditions

				{
					"operation": "insert",
					"parentName": "BaseDcmContainer",
					"propertyName": "items",
					"className": "BPMSoft.Container",
					"name": "ConditionContainer",
					"values": {
						"layout": {"column": 0, "row": 2, "colSpan": 24},
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"visible": {"bindTo": "UseConditions"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "ConditionContainer",
					"propertyName": "items",
					"name": "ConditionLabel",
					"values": {
						"layout": {"column": 0, "row": 0, "colSpan": 24},
						"classes": {"labelClass": ["t-title-label-proc"]},
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "Resources.Strings.ConditionCaption"}
					}
				},

				{
					"operation": "insert",
					"parentName": "ConditionContainer",
					"propertyName": "items",
					"name": "ConditionHeaderContainer",
					"values": {
						"layout": {"column": 0, "row": 1, "colSpan": 24},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": {"wrapClassName": ["condition-header-container"]},
						"visible": {
							"bindTo": "HasConditions"
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "ConditionHeaderContainer",
					"propertyName": "items",
					"name": "IfResultLabel",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "Resources.Strings.IfResultCaption"}
					}
				},
				{
					"operation": "insert",
					"parentName": "ConditionHeaderContainer",
					"propertyName": "items",
					"name": "SetStageTotLabel",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "Resources.Strings.SetStageToCaption"}
					}
				},
				{
					"operation": "insert",
					"parentName": "ConditionContainer",
					"propertyName": "items",
					"name": "ConditionList",
					"values": {
						"layout": {"column": 0, "row": 2, "colSpan": 24},
						"generator": "ConfigurationItemGenerator.generateContainerList",
						"idProperty": "Id",
						"collection": "Conditions",
						"classes": {"wrapClassName": ["condition-container-list", "grid-layout"]},
						"itemPrefix": "condition-item",
						"defaultItemConfig": {},
						"rowCssSelector": ".conditionContainer"
					}
				},
				{
					"operation": "insert",
					"parentName": "ConditionList",
					"propertyName": "defaultItemConfig",
					"name": "ConditionItem",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["condition-item"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "ConditionItem",
					"propertyName": "items",
					"name": "Result",
					"values": {
						"itemType": BPMSoft.ViewItemType.COMPONENT,
						"className": "BPMSoft.ComboBoxEdit",
						"classes": {"wrapClass": ["top-caption-control"]},
						"prepareList": {"bindTo": "onPrepareResultList"},
						"list": {"bindTo": "ResultList"},
						"visible": {
							"bindTo": "UseFormulaConditions",
							"bindConfig": {"converter": "invertBooleanValue"}
						},
						"value": {"bindTo": "Result"}
					}
				},
				{
					"operation": "insert",
					"parentName": "ConditionItem",
					"propertyName": "items",
					"name": "ResultFormula",
					"values": {
						"itemType": BPMSoft.ViewItemType.COMPONENT,
						"className": "BPMSoft.MappingEdit",
						"classes": {"wrapClass": ["top-caption-control"]},
						"visible": {"bindTo": "UseFormulaConditions"},
						"openEditWindow": {"bindTo": "openExtendedMappingEditWindow"},
						"value": {"bindTo": "ResultFormula"}
					}
				},
				{
					"operation": "insert",
					"parentName": "ConditionItem",
					"propertyName": "items",
					"name": "NextStage",
					"values": {
						"itemType": BPMSoft.ViewItemType.COMPONENT,
						"className": "BPMSoft.ComboBoxEdit",
						"classes": {"wrapClass": ["top-caption-control"]},
						"prepareList": {"bindTo": "onPrepareList"},
						"list": {"bindTo": "NextStageList"},
						"value": {"bindTo": "NextStage"}
					}
				},
				{
					"operation": "insert",
					"parentName": "ConditionItem",
					"propertyName": "items",
					"name": "RemoveConditionButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.COMPONENT,
						"className": "BPMSoft.Button",
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"imageConfig": {"bindTo": "getRemoveConditionButtonImageConfig"},
						"classes": {"wrapperClass": ["remove-condition-button"]},
						"click": {"bindTo": "onRemoveConditionButton"}
					}
				},
				{
					"operation": "insert",
					"parentName": "BaseDcmContainer",
					"propertyName": "items",
					"className": "BPMSoft.Container",
					"name": "AddConditionButtonContainer",
					"values": {
						"layout": {"column": 0, "row": 3, "colSpan": 24},
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"visible": {"bindTo": "UseConditions"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "AddConditionButtonContainer",
					"propertyName": "items",
					"name": "AddConditionButton",
					"values": {
						"id": "AddConditionButton",
						"layout": {"column": 0, "row": 0, "colSpan": 24},
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {"bindTo": "Resources.Strings.AddConditionButtonCaption"},
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"imageConfig": {"bindTo": "Resources.Images.AddConditionImage"},
						"classes": {"wrapperClass": ["add-condition-button"]},
						"click": {"bindTo": "onAddConditionButton"}
					}
				}

				// endregion

			]/**SCHEMA_DIFF*/
		};
	}
);
