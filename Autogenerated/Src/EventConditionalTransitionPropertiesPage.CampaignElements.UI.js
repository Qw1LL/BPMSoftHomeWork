/**
 * EventConditionalTransitionPropertiesPage edit page schema.
 * Parent: CampaignConditionalSequenceFlowPropertiesPage.
 * Parent: BaseProcessSchemaElementPropertiesPage.
 */
define("EventConditionalTransitionPropertiesPage", ["BusinessRuleModule", "SelectableItemListMixin"],
		function(BusinessRuleModule) {
			return {
				messages: {},
				mixins: {
					SelectableItemListMixin: "BPMSoft.SelectableItemListMixin"
				},
				attributes: {

					/**
					 * Values of lookup for ResponseMode
					 */
					"ResponseModeEnum": {
						dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT,
						type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						value: {
							Default: {
								value: "0",
								captionName: "Resources.Strings.ResponseModeDefault"
							},
							WithCondition: {
								value: "1",
								captionName: "Resources.Strings.ResponseModeWithCondition"
							}
						}
					},

					/**
					 * Condition when response options exist
					 */
					"HasResponseCondition": {
						"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},

					/**
					 * Collection of responses
					 */
					"ResponsesCollection": {
						"dataValueType": this.BPMSoft.DataValueType.COLLECTION,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},

					/**
					 * Lookup for ResponseMode
					 */
					"ResponseMode": {
						"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						"isRequired": true
					}
				},
				rules: {

					/**
					 * Rule for ResponseConditionDecision
					 */
					"ResponseConditionDecision": {
						"BindResponseConditionDecisionRequiredToReactionMode": {
							"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
							"property": BusinessRuleModule.enums.Property.REQUIRED,
							"conditions": [{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "ResponseMode"
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
					 * @inheritdoc CampaignConditionalSequenceFlowPropertiesPage#subscribeEvents
					 * @overridden
					 */
					subscribeEvents: function() {
						this.callParent(arguments);
						this.on("change:ResponseMode", this._onResponseModeLookupChanged, this);
					},

					/**
					 * Handles change of the "ResponseMode" property.
					 * @private
					 * @return { void }
					 */
					_onResponseModeLookupChanged: function() {
						var responseModeEnum = this.get("ResponseModeEnum");
						var responseMode = this.get("ResponseMode");
						var decisionModeEnabled = (responseMode &&
							responseMode.value === responseModeEnum.WithCondition.value);
						if (!decisionModeEnabled) {
							this.set("ResponseConditionDecision", null);
						}
						this.updateFlowDescription();
					},

					/**
					 * Loads values into user response mode combobox.
					 * @protected
					 * @param {Object} filter ComboboxEdit value.
					 * @param {BPMSoft.Collection} list List of comboboxEdit values.
					 */
					onPrepareResponseModeList: function(filter, list) {
						this.prepareList("ResponseModeEnum", list, this);
					},

					/**
					 * @inheritdoc BaseCampaignSchemaElementPage#initPageAsync
					 * @override
					 */
					initPageAsync: function(element, callback, scope) {
						var parentMethod = this.getParentMethod();
						this._getEventResponses(function(response) {
							if (!Ext.isEmpty(response.collection)) {
								var items = response.collection.getItems()
									.map(function(item) {
										return {
											value: item.values.Id,
											name: item.values.Name
										};
									})
									.sort(function(a, b) {
										return b.name.length - a.name.length;
									});
								this.initItemsCollection("ResponsesCollection", items, [], true);
								this.$ResponsesCollection.on("itemChanged", this.updateFlowDescription, this);
								parentMethod.call(this, element, callback, scope);
							}
						}, this);
					},

					/**
					 * @inheritdoc BaseCampaignSchemaElementPage#initElementProperties.
					 * @overridden
					 */
					initElementProperties: function(element, callback, scope) {
						this._initResponseMode(element.hasResponseCondition);
						var responses = element.eventResponseCollection
							? JSON.parse(element.eventResponseCollection)
							: [];
						this.updateItemsCollection("ResponsesCollection", responses);
						this.callParent(arguments);
					},

					/**
					 * Initializes value of the "ResponseMode" property.
					 * @private
					 * @param {String} value Initial value.
					 */
					_initResponseMode: function(value) {
						var isDefault = !value;
						this.setLookupValue(isDefault, "ResponseMode",
								"WithCondition", this);
					},

					/**
					 * Get collection of responses from the database.
					 * @param {function} callback Callback function
					 * @param {Object} scope Context.
					 */
					_getEventResponses: function(callback, scope) {
						var schemaName = "EventResponse";
						var esq = Ext.create("BPMSoft.EntitySchemaQuery", {rootSchemaName: schemaName});
						esq.serverESQCacheParameters = {
							cacheLevel: BPMSoft.ESQServerCacheLevels.SESSION,
							cacheGroup: this.name,
							cacheItemName: Ext.String.format("{0}", schemaName)
						};
						esq.addColumn("Id");
						esq.addColumn("Name");
						esq.getEntityCollection(callback, scope);
					},

					/**
					 * @inheritdoc CampaignConditionalSequenceFlowPropertiesPage#saveConditions
					 * @override
					 */
					saveConditions: function(flow) {
						this.callParent(arguments);
						var hasResponseCondition = this._getIsResponseModeWithConditions();
						flow.hasResponseCondition = hasResponseCondition;
						flow.eventResponseCollection = this._getResponsesCollection(hasResponseCondition);
					},

					/**
					 * Determines whether the value of the "ReactionMode" is not default value.
					 * @private
					 * @param {String} reactionMode Value of the ResponseMode lookup.
					 * @return {Boolean}
					 */
					_getIsResponseModeWithConditions: function() {
						return this.isLookupValueEqual("ResponseMode", "1", this);
					},

					/**
					 * Returns string representation of selected event responses
					 * @param { Boolean } hasResponseCondition visibility of responses' checkboxes
					 * @private
					 * @return {string} json of selected email response ids
					 */
					_getResponsesCollection: function(hasResponseCondition) {
						var responses = [];
						if (hasResponseCondition) {
							responses = this.getSelectedOptions("ResponsesCollection");
						}
						return JSON.stringify(responses);
					}
				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "insert",
						"name": "ResponseContainer",
						"propertyName": "items",
						"parentName": "ContentContainer",
						"className": "BPMSoft.GridLayoutEdit",
						"values": {
							"layout": {"column": 0, "row": 2, "colSpan": 24},
							"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": []
						}
					},
					{
						"operation": "insert",
						"name": "ResponseModeLabel",
						"parentName": "ResponseContainer",
						"propertyName": "items",
						"values": {
							"layout": {
								"column": 0,
								"row": 0,
								"colSpan": 24
							},
							"itemType": this.BPMSoft.ViewItemType.LABEL,
							"caption": {
								"bindTo": "getResponseQuestionCaption"
							},
							"classes": {
								"labelClass": ["t-title-label-proc"]
							}
						}
					},
					{
						"operation": "insert",
						"name": "ResponseMode",
						"parentName": "ResponseContainer",
						"propertyName": "items",
						"values": {
							"contentType": this.BPMSoft.ContentType.ENUM,
							"controlConfig": {
								"prepareList": {
									"bindTo": "onPrepareResponseModeList"
								}
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
						"name": "Responses",
						"parentName": "ResponseContainer",
						"propertyName": "items",
						"values": {
							"layout": {"column": 0, "row": 2, "colSpan": 24},
							"generator": "ConfigurationItemGenerator.generateContainerList",
							"idProperty": "Id",
							"collection": "ResponsesCollection",
							"onGetItemConfig": "getMultiselectItemViewConfig",
							"classes": {
								"wrapClassName": ["responses-list"]
							},
							"visible": {
								"bindTo": "ResponseMode",
								"bindConfig": {
									converter: "_getIsResponseModeWithConditions"
								}
							}
						}
					}
				]/**SCHEMA_DIFF*/
			};
		}
);
