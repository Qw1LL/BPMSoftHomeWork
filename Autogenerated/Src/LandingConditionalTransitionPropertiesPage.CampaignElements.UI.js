 /**
 * LandingConditionalTransitionPropertiesPage edit page schema.
 * Parent: CampaignConditionalSequenceFlowPropertiesPage.
 * Parent: BaseProcessSchemaElementPropertiesPage.
 */
define("LandingConditionalTransitionPropertiesPage", ["LandingConditionalTransitionPropertiesPageResources",
		"CampaignEnums", "SelectableItemListMixin"],
	function(resources, CampaignEnums) {
		return {
			messages: {},
			mixins: {
				SelectableItemListMixin: "BPMSoft.SelectableItemListMixin"
			},
			attributes: {

				/**
				 * Values of responses
				 */
				"ResponsesCollection": {
					"dataValueType": this.BPMSoft.DataValueType.COLLECTION,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Values of StepCompletedCondition enum for responses collection
				 */
				"ResponsesEnum": {
					dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: {
						Submitted: {
							value: CampaignEnums.StepCompletedConditions.COMPLETED,
							name: resources.localizableStrings.SubmittedResponseCaption
						},
						NotSubmitted: {
							value: CampaignEnums.StepCompletedConditions.NOT_COMPLETED,
							name: resources.localizableStrings.NotSubmittedResponseCaption
						},
						Any: {
							value: CampaignEnums.StepCompletedConditions.ANY,
							name: resources.localizableStrings.AnyResponseCaption
						}
					}
				}
			},
			methods: {

				/**
				 * @inheritdoc BaseCampaignSchemaElementPage#initPageAsync
				 * @override
				 */
				initPageAsync: function(element, callback, scope) {
					this._initResponses();
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc BaseCampaignSchemaElementPage#initElementProperties.
				 * @override
				 */
				 initElementProperties: function(element, callback, scope) {
					this.updateItemsCollection("ResponsesCollection", [element.stepCompletedCondition]);
					this.callParent(arguments);
				 },

				/**
				 * Initializes value of the "ResponsesCollection" property.
				 * @private
				 */
				_initResponses: function() {
					var responses = this.get("ResponsesEnum");
					var responsesArr = Object.keys(responses)
						.map(function(key) {
							return responses[key];
						});
					this.initItemsCollection("ResponsesCollection", responsesArr, 0, false);
					this.$ResponsesCollection.on("itemChanged", this.updateFlowDescription, this);
				},

				/**
				 * @inheritdoc CampaignConditionalSequenceFlowPropertiesPage#saveConditions
				 * @override
				 */
				saveConditions: function(flow) {
					this.callParent(arguments);
					var selectedResponse = this.getSelectedOptions("ResponsesCollection");
					flow.stepCompletedCondition = selectedResponse.length ?
							selectedResponse[0] : this.get("ResponsesEnum").Submitted.value;
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
						"layout": {"column": 0, "row": 0, "colSpan": 24},
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
					"name": "Responses",
					"parentName": "ResponseContainer",
					"propertyName": "items",
					"values": {
						"layout": {"column": 0, "row": 1, "colSpan": 24},
						"generator": "ConfigurationItemGenerator.generateContainerList",
						"idProperty": "Id",
						"collection": "ResponsesCollection",
						"onGetItemConfig": "getItemViewConfig",
						"classes": {
							"wrapClassName": ["responses-list"]
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
