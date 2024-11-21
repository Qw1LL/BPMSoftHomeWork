define("CampaignDiagramPropertyAudiencePage", ["BPMSoft", "CampaignDiagramPropertyAudiencePage",
		"MarketingEnums", "CampaignDiagramPropertyEnums", "css!CampaignDiagramPropertyConnectorPageCSS"],
	function(BPMSoft, resources, MarketingEnums, CampaignDiagramPropertyEnums) {
		return {
			entitySchemaName: "ContactFolder",
			methods: {
				/**
				 * Returns a collection of fields used in the entity.
				 * @protected
				 * @overridden
				 * @return {Array} Collection fields.
				 */
				getUsedColumns: function() {
					return [
						"Id",
						"Name"
					];
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "remove",
					"name": "CampaignDiagramPropertyDescriptionContainer"
				},
				{
					"operation": "remove",
					"name": "DiagramElementLookup"
				},
				{
					"operation": "insert",
					"name": "InfoContainer",
					"parentName": "CampaignDiagramPropertyEntityMainContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "InfoLayout",
					"parentName": "InfoContainer",
					"propertyName": "items",
					"values": {"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "InfoLayout",
					"propertyName": "items",
					"name": "InformationTooltipButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"imageConfig": {"bindTo": "InfoButtonImageConfig"},
						"classes": {
							"wrapperClass": ["no-padding", "info-button"],
							"imageClass": ["info-button-image", "size-24px"]
						},
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 1,
							"rowSpan": 1
						},
						"showTooltip": false
					}
				},
				{
					"operation": "insert",
					"parentName": "InfoLayout",
					"propertyName": "items",
					"name": "InformationLabel",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "Resources.Strings.InfoCaption"},
						"classes": {
							"labelClass": [
								"description-label", "color-gray"
							],
							"wrapClass": [
								"description-wrap"
							]
						},
						"layout": {
							"column": 3,
							"row": 0,
							"colSpan": 21,
							"rowSpan": 2
						}
					}
				},
				{
					"operation": "insert",
					"name": "DiagramElementLookup",
					"parentName": "CampaignDiagramPropertyEntityMainContainer",
					"propertyName": "items",
					"values": {
						"bindTo": "DiagramElementLookup",
						"dataValueType": BPMSoft.DataValueType.LOOKUP,
						"caption": CampaignDiagramPropertyEnums.CampaignPropertyLabelCaption.CONTACT_FOLDER,
						"controlConfig": {
							"loadVocabulary": {"bindTo": "loadDiagramElementSchemaLookup"},
							"tag": "DiagramElementLookup"
						},
						"visible": {
							"bindTo": "IsExtendedMode"
						},
						"enabled": {
							"bindTo": "IsStatusEnabled"
						},
						"markerValue": {"bindTo": "DiagramElementPageTypeCaption"}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
