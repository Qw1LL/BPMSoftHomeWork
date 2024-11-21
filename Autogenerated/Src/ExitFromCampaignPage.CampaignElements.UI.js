define("ExitFromCampaignPage", ["MultilineLabel", "css!MultilineLabel"],
	function() {
		return {
			attributes: {
				/**
				 * Flag to indicate that element is campaign's goal or not.
				 */
				"IsCampaignGoal": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"onChange": "onIsCampaignGoalChanged"
				}
			},
			methods: {
				/**
				 * @inheritdoc CampaignBaseAudiencePropertiesPage#getContextHelpCode
				 * @override
				 */
				getContextHelpCode: function() {
					return "CampaignExitFromCampaignElement";
				},

				/**
				 * @inheritdoc BaseCampaignSchemaElementPage#initElementProperties.
				 * @override
				 */
				 initElementProperties: function(element, callback, scope) {
					 this.set("IsCampaignGoal", element.isCampaignGoal);
					this.callParent(arguments);
				 },

				/**
				 * Handles change of campaign goal sign
				 * @public
				 */
				onIsCampaignGoalChanged: function(model, value) {
					var element = this.get("ProcessElement");
					element.isCampaignGoal = value;
					element.updateMarkers();
				},

				/**
				 * @inheritdoc BaseProcessSchemaElementPropertiesPage#saveValues
				 * @override
				 */
				saveValues: function() {
					this.callParent(arguments);
					var element = this.get("ProcessElement");
					element.initLargeImage();
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"parentName": "FolderAudienceSourceLayout",
					"propertyName": "items",
					"name": "ContactFolderHint",
					"values": {
						"layout": {"column": 22, "row": 1, "colSpan": 1},
						"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
						"content": {"bindTo": "Resources.Strings.ContactFolderSelectionHint"},
						"controlConfig": {
							"classes": {
								"wrapperClass": "t-folder-information-btn"
							},
							"imageConfig": {
								"bindTo": "Resources.Images.InfoButtonImage"
							}
						}
					}
				},
				{
					"operation": "insert",
					"name": "IsCampaignGoalLabel",
					"parentName": "ContentContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 24
						},
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "Resources.Strings.IsCampaignGoalLabel"
						},
						"classes": {
							"labelClass": ["t-title-label-proc"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "ContentContainer",
					"propertyName": "items",
					"name": "IsCampaignGoal",
					"values": {
						"wrapClass": ["t-checkbox-control"],
						"visible": true,
						"caption": {"bindTo": "Resources.Strings.IsCampaignGoalCaption"},
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 24
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
});
