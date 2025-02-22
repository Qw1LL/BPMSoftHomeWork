﻿/**
 * Schema of campaign Landing element page
 * Parent: EntityCampaignSchemaElementPage
 */
define("CampaignLandingPage", ["BaseFiltersGenerateModule", "LookupUtilities",
	"MarketingEnums"], function() {
		return {
			attributes: {

				/**
				 * Site URL of landing page
				 * @type {BPMSoft.dataValueType.TEXT}
				 */
				"SiteUrl": {
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Status of the landing page
				 * @type {BPMSoft.dataValueType.TEXT}
				 */
				"LandingStatus": {
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
					return ["Id", "Name", "ExternalURL", "State", "Type"];
				},

				/**
				 * @inheritdoc EntityCampaignSchemaElementPage#getEntityRecordIdFromElement
				 * @overridden
				 */
				getEntityRecordIdFromElement: function(element) {
					return element.landingId;
				},

				/**
				 * @inheritdoc EntityCampaignSchemaElementPage#setRecordIdToElement
				 * @overridden
				 */
				setRecordIdToElement: function(element, recordId) {
					element.landingId = recordId;
				},

				/**
				 * @inheritdoc EntityCampaignSchemaElementPage#getEntityLookupCaption
				 * @overridden
				 */
				getEntityLookupCaption: function() {
					return this.get("Resources.Strings.CampaignLandingText");
				},

				/**
				 * @inheritdoc EntityCampaignSchemaElementPage#getEntitySchemaName
				 * @overridden
				 */
				getEntitySchemaName: function() {
					return "GeneratedWebForm";
				},

				/**
				 * @inheritdoc EntityCampaignSchemaElementPage#setPageParameters
				 * @overridden
				 */
				setPageParameters: function(eventEntity) {
					this.callParent(arguments);
					this.set("SiteUrl", eventEntity.get("ExternalURL"));
					this.set("LandingStatus", eventEntity.get("State").displayValue);
				},

				/**
				 * @inheritdoc EntityCampaignSchemaElementPage#clearPageParameters
				 * @overridden
				 */
				clearPageParameters: function() {
					this.callParent(arguments);
					this.set("SiteUrl", null);
					this.set("LandingStatus", null);
				},

				/**
				 * @inheritdoc EntityCampaignSchemaElementPage#getEntityLookupFilters
				 * @overridden
				 */
				getEntityLookupFilters: function() {
					var filters = this.BPMSoft.createFilterGroup();
					var selectedLandingIds = [];
					var currentElement = this.get("ProcessElement");
					BPMSoft.each(currentElement.parentSchema.flowElements, function(el) {
						if (el.landingId && el.uId !== currentElement.uId) {
							var rightExpression = Ext.create("BPMSoft.ParameterExpression", {
								parameterDataType: BPMSoft.DataValueType.GUID,
								parameterValue: el.landingId
							});
							selectedLandingIds.push(rightExpression);
						}
					}, this);
					var leftExpression = Ext.create("BPMSoft.ColumnExpression", {
						columnPath: "Id"
					});
					var notInFilter = this.BPMSoft.createInFilter(leftExpression, selectedLandingIds);
					notInFilter.comparisonType = this.BPMSoft.ComparisonType.NOT_EQUAL;
					filters.addItem(notInFilter);
					return filters;
				},

				/**
				 * @inheritdoc BaseCampaignSchemaElementPage#getContextHelpCode
				 * @overridden
				 */
				getContextHelpCode: function() {
					return "CampaignLandingElement";
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "SiteUrlLabel",
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
							"bindTo": "Resources.Strings.SiteUrlCaption"
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
					"name": "SiteUrl",
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
						"controlConfig": {"tag": "SiteUrl"}
					}
				},
				{
					"operation": "insert",
					"name": "LandingStatusLabel",
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
							"bindTo": "Resources.Strings.StatusCaption"
						},
						"visible": {
							"bindTo": "isEntitySelected"
						}
					}
				},
				{
					"operation": "insert",
					"name": "LandingStatus",
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
						"controlConfig": {"tag": "LandingStatus"}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
