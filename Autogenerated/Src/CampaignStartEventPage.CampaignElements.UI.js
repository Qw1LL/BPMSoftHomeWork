/**
 * Schema of campaign Event element page
 * Parent: CampaignBaseEventPage
 */
define("CampaignStartEventPage", [],
	function() {
		return {
			attributes: {
				/**
				 * Flag to indicate state of participants' recurring entrance by signal.
				 * @type {Boolean}
				 */
				"IsRecurring": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"value": false,
					"onChange": "onIsRecurringChanged"
				}
			},
			methods: {
				/**
				 * @private
				 */
				_isRecurringAllowed: function() {
					return BPMSoft.Features.getIsEnabled("CampaignSignalRecurringEntrance");
				},

				/**
				 * @private
				 */
				_getEventFilter: function(schemaName, eventId) {
					var eventFilter = BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "Event", eventId);
					var filterGroup = Ext.create("BPMSoft.FilterGroup");
					filterGroup.rootSchemaName = schemaName;
					filterGroup.logicalOperation = BPMSoft.LogicalOperatorType.AND;
					filterGroup.addItem(eventFilter);
					var serializedFilter = filterGroup.serialize({
						serializeFilterManagerInfo: true
					});
					var deserializedFilters = BPMSoft.deserialize(serializedFilter);
					var serializedFilterData = {
						className: "BPMSoft.FilterGroup",
						serializedFilterEditData: serializedFilter,
						dataSourceFilters: deserializedFilters.serialize()
					};
					return BPMSoft.encode(serializedFilterData);
				},

				/**
				 * Handles change of recurring sign
				 * @public
				 */
				onIsRecurringChanged: function(model, value) {
					var element = this.get("ProcessElement");
					element.isRecurring = value;
					element.updateMarkers();
				},

				/**
				 * @inheritdoc BaseCampaignSchemaElementPage#getContextHelpCode
				 * @overridden
				 */
				getContextHelpCode: function() {
					return "CampaignStartEventElement";
				},

				/**
				 * @inheritdoc BPMSoft.ProcessFlowElementPropertiesPage#initParameters
				 * @override
				 */
				initParameters: function(element) {
					this.callParent(arguments);
					this.$IsRecurring = element.isRecurring;
				},

				/**
				 * @inheritdoc EntityCampaignSchemaElementPage#clearPageParameters
				 * @override
				 */
				clearPageParameters: function() {
					this.callParent(arguments);
					this.set("IsRecurring", false);
				},

				/**
				 * @inheritdoc BPMSoft.ProcessFlowElementPropertiesPage#saveValues
				 * @override
				 */
				saveValues: function() {
					this.callParent(arguments);
					var element = this.$ProcessElement;
					element.isRecurring = this.$IsRecurring;
					element.signalEntityId = element.eventId;
					var targetEntitySchema = BPMSoft.EntitySchemaManager.findItemByName("EventTarget");
					element.entitySchemaUId = targetEntitySchema.uId;
					element.entityFilters = this._getEventFilter(targetEntitySchema.name, element.eventId);
				}

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "RecurringAddContainer",
					"parentName": "ContentContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"visible": "$_isRecurringAllowed",
						"layout": {
							"column": 0,
							"row": 9,
							"colSpan": 24
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "RecurringAddLayout",
					"propertyName": "items",
					"parentName": "RecurringAddContainer",
					"className": "BPMSoft.GridLayoutEdit",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "IsRecurringLabel",
					"parentName": "RecurringAddLayout",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 0
						},
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": "$Resources.Strings.IsRecurringLabel",
						"classes": {
							"labelClass": ["t-title-label-proc"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "IsRecurring",
					"parentName": "RecurringAddLayout",
					"propertyName": "items",
					"values": {
						"wrapClass": ["t-checkbox-control"],
						"caption": "$Resources.Strings.IsRecurringCaption",
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 23
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "RecurringAddLayout",
					"propertyName": "items",
					"name": "RecurringAddHint",
					"values": {
						"layout": {"column": 23, "row": 1, "colSpan": 1},
						"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
						"content": "$Resources.Strings.IsRecurringHint",
						"controlConfig": {
							"classes": {
								"wrapperClass": "t-checkbox-information-button"
							},
							"imageConfig": {
								"bindTo": "Resources.Images.InfoButtonImage"
							}
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
