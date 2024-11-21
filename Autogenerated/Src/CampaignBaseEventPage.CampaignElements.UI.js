/**
 * Schema of campaign  base Event element page
 * Parent: EntityCampaignSchemaElementPage
 */
define("CampaignBaseEventPage", [],
	function() {
		return {
			attributes: {

				/**
				 * Start time of the selected event.
				 * @type {BPMSoft.dataValueType.DATE}
				 */
				"StartTime": {
					"dataValueType": this.BPMSoft.DataValueType.DATE,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * End time of the selected event.
				 * @type {BPMSoft.dataValueType.DATE}
				 */
				"EndTime": {
					"dataValueType": this.BPMSoft.DataValueType.DATE,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Type of the selected event.
				 * @type {BPMSoft.dataValueType.TEXT}
				 */
				"EventType": {
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Owner of the selected event.
				 * @type {BPMSoft.dataValueType.TEXT}
				 */
				"Owner": {
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},
			methods: {

				/**
				 * @inheritdoc EntityCampaignSchemaElementPage#getColumnsForEntitySelect
				 * @overridden
				 */
				getColumnsForEntitySelect: function() {
					return ["Id", "Name", "StartDate", "EndDate", "Type", "Owner"];
				},

				/**
				 * @inheritdoc EntityCampaignSchemaElementPage#getEntityRecordIdFromElement
				 * @overridden
				 */
				getEntityRecordIdFromElement: function(element) {
					return element.eventId;
				},

				/**
				 * @inheritdoc EntityCampaignSchemaElementPage#setRecordIdToElement
				 * @overridden
				 */
				setRecordIdToElement: function(element, recordId) {
					element.eventId = recordId;
				},

				/**
				 * @inheritdoc EntityCampaignSchemaElementPage#getEntityLookupCaption
				 * @overridden
				 */
				getEntityLookupCaption: function() {
					return this.get("Resources.Strings.CampaignEventText");
				},

				/**
				 * @inheritdoc EntityCampaignSchemaElementPage#getEntitySchemaName
				 * @overridden
				 */
				getEntitySchemaName: function() {
					return "Event";
				},

				/**
				 * @inheritdoc EntityCampaignSchemaElementPage#setPageParameters
				 * @overridden
				 */
				setPageParameters: function(eventEntity) {
					this.callParent(arguments);
					this.set("StartTime", eventEntity.get("StartDate"));
					this.set("EndTime", eventEntity.get("EndDate"));
					this.set("EventType", eventEntity.get("Type").displayValue);
					this.set("Owner", eventEntity.get("Owner").displayValue);
				},

				/**
				 * @inheritdoc EntityCampaignSchemaElementPage#clearPageParameters
				 * @overridden
				 */
				clearPageParameters: function() {
					this.callParent(arguments);
					this.set("StartTime", null);
					this.set("EndTime", null);
					this.set("EventType", null);
					this.set("Owner", null);
				},

				/**
				 * @inheritdoc EntityCampaignSchemaElementPage#getEntityLookupFilters
				 * @overridden
				 */
				getEntityLookupFilters: function() {
					var filters = this.BPMSoft.createFilterGroup();
					var selectedEventIds = [];
					var currentElement = this.get("ProcessElement");
					BPMSoft.each(currentElement.parentSchema.flowElements, function(el) {
						if (el.eventId && el.uId !== currentElement.uId) {
							var rightExpression = Ext.create("BPMSoft.ParameterExpression", {
								parameterDataType: BPMSoft.DataValueType.GUID,
								parameterValue: el.eventId
							});
							selectedEventIds.push(rightExpression);
						}
					}, this);
					var leftExpression = Ext.create("BPMSoft.ColumnExpression", {
						columnPath: "Id"
					});
					var notInFilter = this.BPMSoft.createInFilter(leftExpression, selectedEventIds);
					notInFilter.comparisonType = this.BPMSoft.ComparisonType.NOT_EQUAL;
					filters.addItem(notInFilter);
					return filters;
				},

				/**
				 * @inheritdoc BaseCampaignSchemaElementPage#getContextHelpCode
				 * @overridden
				 */
				getContextHelpCode: function() {
					return "CampaignEventElement";
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "StartTimeLabel",
					"parentName": "ContentContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24
						},
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "Resources.Strings.StartTimeCaption"
						},
						"classes": {
							"labelClass": ["label-small"]
						},
						"visible": {
							"bindTo": "isEntitySelected"
						}
					}
				},
				{
					"operation": "insert",
					"name": "StartTime",
					"parentName": "ContentContainer",
					"propertyName": "items",
					"values": {
						"labelConfig": {
							"visible": false
						},
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 24
						},
						"classes": {
							"labelClass": ["feature-item-label"]
						},
						"enabled": false,
						"visible": {
							"bindTo": "isEntitySelected"
						},
						"controlConfig": {"tag": "StartTime"}
					}
				},
				{
					"operation": "insert",
					"name": "EndTimeLabel",
					"parentName": "ContentContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 24
						},
						"classes": {
							"labelClass": ["label-small"]
						},
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "Resources.Strings.EndTimeCaption"
						},
						"visible": {
							"bindTo": "isEntitySelected"
						}
					}
				},
				{
					"operation": "insert",
					"name": "EndTime",
					"parentName": "ContentContainer",
					"propertyName": "items",
					"values": {
						"labelConfig": {
							"visible": false
						},
						"layout": {
							"column": 0,
							"row": 5,
							"colSpan": 24
						},
						"classes": {
							"labelClass": ["feature-item-label"]
						},
						"enabled": false,
						"visible": {
							"bindTo": "isEntitySelected"
						},
						"controlConfig": {"tag": "EndTime"}
					}
				},
				{
					"operation": "insert",
					"name": "EventTypeLabel",
					"parentName": "ContentContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 6,
							"colSpan": 24
						},
						"value": {
							"bindTo": "EventType"
						},
						"classes": {
							"labelClass": ["label-small"]
						},
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "Resources.Strings.EventTypeCaption"
						},
						"visible": {
							"bindTo": "isEntitySelected"
						}
					}
				},
				{
					"operation": "insert",
					"name": "EventType",
					"parentName": "ContentContainer",
					"propertyName": "items",
					"values": {
						"labelConfig": {
							"visible": false
						},
						"layout": {
							"column": 0,
							"row": 7,
							"colSpan": 24
						},
						"classes": {
							"labelClass": ["feature-item-label"]
						},
						"itemType": this.BPMSoft.ViewItemType.TEXT,
						"enabled": false,
						"visible": {
							"bindTo": "isEntitySelected"
						},
						"controlConfig": {"tag": "EventType"}
					}
				},
				{
					"operation": "insert",
					"name": "OwnerLabel",
					"parentName": "ContentContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 8,
							"colSpan": 24
						},
						"value": {
							"bindTo": "Owner"
						},
						"classes": {
							"labelClass": ["label-small"]
						},
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "Resources.Strings.OwnerCaption"
						},
						"visible": {
							"bindTo": "isEntitySelected"
						}
					}
				},
				{
					"operation": "insert",
					"name": "Owner",
					"parentName": "ContentContainer",
					"propertyName": "items",
					"values": {
						"labelConfig": {
							"visible": false
						},
						"layout": {
							"column": 0,
							"row": 9,
							"colSpan": 24
						},
						"classes": {
							"labelClass": ["feature-item-label"]
						},
						"itemType": this.BPMSoft.ViewItemType.TEXT,
						"enabled": false,
						"visible": {
							"bindTo": "isEntitySelected"
						},
						"controlConfig": {"tag": "Owner"}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
