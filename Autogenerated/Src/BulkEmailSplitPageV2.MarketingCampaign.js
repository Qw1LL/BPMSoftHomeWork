define("BulkEmailSplitPageV2", ["BulkEmailSplitPageV2Resources", "GeneralDetails", "MarketingEnums",
		"MarketingCommonUtilities", "WizardStepsControl", "BulkEmailAnalytics", "css!WizardStepsControl",
		"EntityHelper", "MultilineLabel", "css!BulkEmailSplitPageV2CSS", "css!CampaignDetailV2CSS",
		"css!InfoButtonStyles", "css!MultilineLabel"],
	function(resources, GeneralDetails, MarketingEnums, MarketingCommonUtilities) {
		/** @enum
		 * #### ####### #####-#####. */
		BPMSoft.BulkEmailSplitWizardSteps = {
			/** ########. */
			Emails: 1,
			/** #########. */
			Audience: 2,
			/** ######. */
			Run: 3,
			/** ##########. */
			Results: 4
		};
		return {
			entitySchemaName: "BulkEmailSplit",
			mixins: {
				EntityHelper: "BPMSoft.EntityHelper",
				Analytics: "BPMSoft.BulkEmailAnalytics"
			},
			details: /**SCHEMA_DETAILS*/{
				BulkEmailSplitTarget: {
					schemaName: "BulkEmailSplitTargetDetailV2",
					entitySchemaName: "VwMandrillRecipient",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "[BulkEmail:Id:BulkEmail].SplitTest"
					},
					subscriber: function() {
						this.refreshColumns(["RecipientCount", "SegmentsStatus"], function() {
							this.updateIsRecipientPercentEnabled();
							this.findPassedStep();
							this.setBulkEmailDetailEditable();
						});
					}
				},
				BulkEmailInBulkEmailSplit: {
					schemaName: "BulkEmailInBulkEmailSplitDetailV2",
					entitySchemaName: "BulkEmail",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "SplitTest"
					},
					subscriber: function() {
						this.findPassedStep();
						this.updateDetail({detail: "BulkEmail"});
					}
				},
				BulkEmail: {
					schemaName: "BulkEmailDetailV2",
					entitySchemaName: "BulkEmail",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "SplitTest"
					},
					captionName: "BulkEmailDetailCaption"
				}
			}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "Name",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 11,
							"rowSpan": 1
						},
						"controlConfig": {
							"classes": ["campaign-name-enlarged"]
						}
					},
					"parentName": "Header",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "ContainerSteps",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24,
						},
						"items": [],
						"classes": {
							"wrapClassName": ["container-steps"]
						},
					},
					"parentName": "Header",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "Owner",
					"values": {
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 11,
						},
					},
					"parentName": "Header",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "StartDateHeaders",
					"values": {
						"dataValueType": BPMSoft.DataValueType.DATE_TIME,
						"wrapClass": ["start-date-control"],
						"layout": {
							"column": 12,
							"row": 3,
							"colSpan": 12,
							"rowSpan": 1
						},
						"caption": resources.localizableStrings.StartDateHeadersCaption,
						"value": {
							"bindTo": "StartDate"
						},
						"visible": {
							"bindTo": "CurrentStep",
							"bindConfig": {
								converter: "bindConverter4"
							}
						},
						"controlConfig": {
							"classes": ["bulk-email-split-test-date-time-header"],
							"enabled": false,
							"setValidationInfo": BPMSoft.emptyFn
						}
					},
					"parentName": "Header",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Notes",
					"values": {
						"layout": {
							"column": 12,
							"row": 1,
							"colSpan": 12,
						}
					}
				},
				{
					"operation": "insert",
					"name": "SplitWizardSteps",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"layout": {"column": 0, "row": 4, "colSpan": 24, "rowSpan": 1},
						"items": []
					},
					"parentName": "Header",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "SplitWizardStep1",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": [],
						"visible": {
							"bindTo": "CurrentStep",
							"bindConfig": {
								converter: "bindConverter1"
							}
						}
					},
					"parentName": "SplitWizardSteps",
					"propertyName": "items"
				},
				{
					"operation": "merge",
					"name": "CloseButton",
					"values": {
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT
					}
				},
				{
					"operation": "insert",
					"name": "SplitWizardStep2",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": [],
						"visible": {
							"bindTo": "CurrentStep",
							"bindConfig": {
								converter: "bindConverter2"
							}
						}
					},
					"parentName": "SplitWizardSteps",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "SplitWizardStep3",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": [],
						"visible": {
							"bindTo": "CurrentStep",
							"bindConfig": {
								converter: "bindConverter3"
							}
						}
					},
					"parentName": "SplitWizardSteps",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "SplitWizardStep4",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": [],
						"visible": {
							"bindTo": "CurrentStep",
							"bindConfig": {
								converter: "bindConverter4"
							}
						}
					},
					"parentName": "SplitWizardSteps",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"parentName": "SplitWizardStep1",
					"propertyName": "items",
					"name": "BulkEmailInBulkEmailSplit",
					"values": {
						itemType: BPMSoft.ViewItemType.DETAIL,
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24,
							"rowSpan": 1
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "SplitWizardStep2",
					"name": "RecipientPercentGroup",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
						"caption": resources.localizableStrings.SelectAudienceCaption,
						"tools": [],
						"classes": {
							"wrapClass": ["recipient-percent-group"]
						},
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24,
							"rowSpan": 1
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "RecipientPercentGroupGrid",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					},
					"parentName": "RecipientPercentGroup",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "RecipientPercent",
					"values": {
						"labelConfig": {
							"caption": resources.localizableStrings.RecipientPercentCaption,
							"isRequired": true
						},
						"enabled": {"bindTo": "IsRecipientPercentEnabled"},
						"classes": {
							"wrapClass": ["recipient-percent"]
						},
						"labelWrapConfig": {
							"classes": {
								"wrapClassName": ["recipient-percent-label-wrap"]
							}
						},
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24,
							"rowSpan": 1
						}
					},
					"parentName": "RecipientPercentGroupGrid",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"parentName": "RecipientPercentGroup",
					"propertyName": "tools",
					"name": "RecipientPercentInformationTooltipButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
						"controlConfig": {
							"imageConfig": {
								"bindTo": "Resources.Images.informationIcon"
							}
						},
						"content": {"bindTo": "Resources.Strings.RecipientPercentTooltip"},
						"tools": []
					}
				},
				{
					"operation": "insert",
					"parentName": "SplitWizardStep2",
					"propertyName": "items",
					"name": "BulkEmailSplitTarget",
					"values": {
						itemType: BPMSoft.ViewItemType.DETAIL,
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24,
							"rowSpan": 1
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "SplitWizardStep3",
					"name": "StartDateGroup",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
						"caption": resources.localizableStrings.StartDateGroupCaption,
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24,
							"rowSpan": 1
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "StartDateRadio",
					"values": {
						"caption": " ",
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24,
							"rowSpan": 1
						},
						"itemType": BPMSoft.ViewItemType.RADIO_GROUP,
						"value": {"bindTo": "StartManual"},
						"items": [
							{
								"name": "StartDateRadio",
								"caption": resources.localizableStrings.StartDateRadioCaption,
								"value": false,
								"enabled": {
									"bindTo": "IsStartManualEnabled"
								}
							}
						]
					},
					"parentName": "StartDateGroup",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "StartDate",
					"values": {
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24,
							"rowSpan": 1
						},
						"enabled": {
							"bindTo": "IsStartDateEnabled"
						}
					},
					"parentName": "StartDateGroup",
					"propertyName": "items",
					"index": 2
				},
				{
					"operation": "insert",
					"name": "StartManualRadio",
					"values": {
						"caption": " ",
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 24,
							"rowSpan": 1
						},
						"itemType": BPMSoft.ViewItemType.RADIO_GROUP,
						"value": {"bindTo": "StartManual"},
						"items": [
							{
								"name": "StartManualRadio",
								"caption": resources.localizableStrings.StartManualRadioCaption,
								"value": true,
								"enabled": {
									"bindTo": "IsStartManualEnabled"
								}
							}
						]
					},
					"parentName": "StartDateGroup",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"parentName": "SplitWizardStep3",
					"name": "DetermineWinnerGroup",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
						"caption": resources.localizableStrings.DetermineWinnerGroupCaption,
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24,
							"rowSpan": 1
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "DetermineWinnerLabel",
					"values": {
						"className": "BPMSoft.MultilineLabel",
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": resources.localizableStrings.DetermineWinnerLabel,
						"contentVisible": true,
						"classes": {
							"multilineLabelClass": ["determine-winner-label"]
						}
					},
					"parentName": "DetermineWinnerGroup",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"parentName": "SplitWizardStep4",
					"propertyName": "items",
					"name": "BulkEmail",
					"values": {
						itemType: BPMSoft.ViewItemType.DETAIL,
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 24,
							"rowSpan": 1
						}
					}
				},
				{
					"operation": "merge",
					"name": "SaveButton",
					"values": {
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE
					}
				},
				{
					"operation": "remove",
					"name": "ESNTab"
				},
				{
					"operation": "remove",
					"name": "ESNFeedContainer"
				},
				{
					"operation": "remove",
					"name": "ESNFeed"
				},
				{
					"operation": "remove",
					"name": "ViewOptionsButton"
				},
				{
					"operation": "remove",
					"name": "actions"
				},
				{
					"operation": "insert",
					"parentName": "LeftContainer",
					"propertyName": "items",
					"name": "RunSplitTestButton",
					"values": {
						itemType: BPMSoft.ViewItemType.BUTTON,
						caption: {"bindTo": "RunTestButtontCaption"},
						click: {"bindTo": "onRunTestClick"},
						style: BPMSoft.controls.ButtonEnums.style.ORANGE
					}
				},
				{
					"operation": "insert",
					"name": "WizardSteps",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"className": "BPMSoft.WizardStepsControl",
						"wizardSteps": [
							{
								caption: resources.localizableStrings.TestParametersCaption
							},
							{
								caption: resources.localizableStrings.AudienceTestCaption
							},
							{
								caption: resources.localizableStrings.RunTestCaption
							},
							{
								caption: resources.localizableStrings.TestResultsCaption
							}
						],
						"currentStep": {"bindTo": "CurrentStep"},
						"passedStep": {"bindTo": "PassedStep"}
					},
					"parentName": "ContainerSteps",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"parentName": "SplitWizardStep4",
					"propertyName": "items",
					"name": "BulkEmailIndicators",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
						"afterrerender": {"bindTo": "loadIndicatorsModules"},
						"afterrender": {"bindTo": "loadIndicatorsModules"},
						"caption": "",
						"items": [],
						"controlConfig": {
							"collapsed": false
						},
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 24,
							"rowSpan": 1
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "BulkEmailIndicators",
					"propertyName": "items",
					"name": "BulkEmailIndicatorOpens",
					"values": {
						"itemType": BPMSoft.ViewItemType.MODULE,
						"classes": {
							"wrapClassName": ["indicator-container"]
						}
					},
					"index": 0
				},
				{
					"operation": "insert",
					"parentName": "BulkEmailIndicators",
					"propertyName": "items",
					"name": "BulkEmailIndicatorClicks",
					"values": {
						"itemType": BPMSoft.ViewItemType.MODULE,
						"classes": {
							"wrapClassName": ["indicator-container"]
						}
					},
					"index": 1
				},
				{
					"operation": "insert",
					"parentName": "BulkEmailIndicators",
					"propertyName": "items",
					"name": "BulkEmailIndicatorSoftBounce",
					"values": {
						"itemType": BPMSoft.ViewItemType.MODULE,
						"classes": {
							"wrapClassName": ["indicator-container"]
						}
					},
					"index": 2
				},
				{
					"operation": "insert",
					"parentName": "BulkEmailIndicators",
					"propertyName": "items",
					"name": "BulkEmailIndicatorHardBounce",
					"values": {
						"itemType": BPMSoft.ViewItemType.MODULE,
						"classes": {
							"wrapClassName": ["indicator-container"]
						}
					},
					"index": 3
				},
				{
					"operation": "insert",
					"parentName": "BulkEmailIndicators",
					"propertyName": "items",
					"name": "BulkEmailIndicatorUnsubscribe",
					"values": {
						"itemType": BPMSoft.ViewItemType.MODULE,
						"classes": {
							"wrapClassName": ["indicator-container"]
						}
					},
					"index": 4
				},
				{
					"operation": "insert",
					"parentName": "BulkEmailIndicators",
					"propertyName": "items",
					"name": "BulkEmailIndicatorSpam",
					"values": {
						"itemType": BPMSoft.ViewItemType.MODULE,
						"classes": {
							"wrapClassName": ["indicator-container"]
						}
					},
					"index": 5
				}
			]/**SCHEMA_DIFF*/,
			attributes: {
				"IsRecipientPercentEnabled": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN
				},
				/**
				 * ####### ### # #######.
				 */
				"CurrentStep": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.INTEGER
				},
				/**
				 * ########## ### #  #######.
				 */
				"PassedStep": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.INTEGER
				},
				/**
				 * ####### ###### ########## ###### {###### #####|########## ####}.
				 */
				"RunTestButtontCaption": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.TEXT
				},
				/**
				 * ####### ############## #### ######.
				 */
				"IsStartDateEnabled": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.BOOLEAN
				},
				/**
				 * ####### ############## ############## ####### ####### #####.
				 */
				"IsStartManualEnabled": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.BOOLEAN
				},
				/**
				 * #######, ########### ## ############# ######## #### ####### ######## ##### ########## ########.
				 */
				"IsUpdateEmailsDateAfterSave": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.BOOLEAN
				},
				/**
				 * ####### ###### # #########.
				 */
				"Clicks": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"dataValueType": BPMSoft.DataValueType.FLOAT,
					"value": 0.0
				},
				/**
				 * ####### ######## #####.
				 */
				"Opens": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"dataValueType": BPMSoft.DataValueType.FLOAT,
					"value": 0.0
				},
				/**
				 * ####### SoftBounce.
				 */
				"SoftBounce": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.FLOAT,
					value: 0.0
				},
				/**
				 * ####### HardBounce.
				 */
				"HardBounce": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.FLOAT,
					value: 0.0
				},
				/**
				 * ####### #######.
				 */
				"Unsubscribe": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.FLOAT,
					value: 0.0
				},
				/**
				 * ####### ##### ######### ### ####.
				 */
				"Spam": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.FLOAT,
					value: 0.0
				},
				/**
				 * ########## ###### # #########.
				 */
				"ClicksCount": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"dataValueType": BPMSoft.DataValueType.INTEGER,
					"value": 0
				},
				/**
				 * ########## ######## #####.
				 */
				"OpensCount": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"dataValueType": BPMSoft.DataValueType.INTEGER,
					"value": 0
				},
				/**
				 * ########## SoftBounce.
				 */
				"SoftBounceCount": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"dataValueType": BPMSoft.DataValueType.INTEGER,
					"value": 0
				},
				/**
				 * ########## HardBounce.
				 */
				"HardBounceCount": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"dataValueType": BPMSoft.DataValueType.INTEGER,
					"value": 0
				},
				/**
				 * ########## #######.
				 */
				"UnsubscribeCount": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"dataValueType": BPMSoft.DataValueType.INTEGER,
					"value": 0
				},
				/**
				 * ########## ##### #########, ### ####.
				 */
				"SpamCount": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"dataValueType": BPMSoft.DataValueType.INTEGER,
					"value": 0
				},
				/**
				 * #######, ######## ## ### ######### #### #######.
				 */
				"IsPublicDemoBuild": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					value: false
				},
				/**
				 * ###### ## ########### ##### ######.
				 */
				"TrialUrl": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.TEXT,
					value: ""
				}
			},
			methods: {

				/**
				 * @inheritdoc BasePageV2#addSectionDesignerViewOptions
				 * @overridden
				 */
				addSectionDesignerViewOptions: BPMSoft.emptyFn,

				/**
				 * ########## ####### ######### ###### ###########.
				 * @private
				 */
				loadIndicatorsModules: function() {
					if (this.get("CurrentStep") !== BPMSoft.BulkEmailSplitWizardSteps.Results) {
						return;
					}
					var indicators = {
						Opens: {style: "widget-orange"},
						Clicks: {style: "widget-orange"},
						SoftBounce: {style: "widget-orange"},
						HardBounce: {style: "widget-orange"},
						Unsubscribe: {style: "widget-orange"},
						Spam: {style: "widget-orange"}
					};
					BPMSoft.each(indicators, function(item, key) {
						var moduleId = this.sandbox.id + "_IndicatorModule_" + key;
						this.sandbox.loadModule("SimpleIndicatorModule", {
							renderTo: "BulkEmailIndicator" + key,
							id: moduleId
						});
						this.sandbox.subscribe("GetIndicatorConfig", function() {
							return this.Ext.apply(item, {
								caption: this.get("Resources.Strings.IndicatorCaptionFor" + key),
								value: this.get(key) || 0,
								totalAmount: this.get(key + "Count") || 0,
								fontStyle: "default-indicator-font-size",
								format: {
									textDecorator: "{0}%",
									thousandSeparator: BPMSoft.Resources.CultureSettings.thousandSeparator,
									dateFormat: BPMSoft.Resources.CultureSettings.dateFormat
								},
								bottomLabelFormat: {
									decimalPrecision: 0,
									thousandSeparator: BPMSoft.Resources.CultureSettings.thousandSeparator,
									type: BPMSoft.DataValueType.INTEGER
								}
							});
						}, this, [moduleId]);
						this.sandbox.publish("GenerateIndicator", null, [moduleId]);
					}, this);
				},

				/**
				 * ######### ##### ########## ## ######### # #####.
				 * @private
				 */
				getEmailStatistics: function() {
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "BulkEmail"
					});
					esq.addAggregationSchemaColumn("SendCount", BPMSoft.AggregationType.SUM, "SendCount");
					esq.addAggregationSchemaColumn("RejectedCount", BPMSoft.AggregationType.SUM, "RejectedCount");
					esq.addAggregationSchemaColumn("DeliveryError", BPMSoft.AggregationType.SUM, "DeliveryError");
					esq.addAggregationSchemaColumn("ClicksCount", BPMSoft.AggregationType.SUM, "ClicksCount");
					esq.addAggregationSchemaColumn("OpensCount", BPMSoft.AggregationType.SUM, "OpensCount");
					esq.addAggregationSchemaColumn("SoftBounceCount", BPMSoft.AggregationType.SUM, "SoftBounceCount");
					esq.addAggregationSchemaColumn("HardBounceCount", BPMSoft.AggregationType.SUM, "HardBounceCount");
					esq.addAggregationSchemaColumn("UnsubscribeCount", BPMSoft.AggregationType.SUM, "UnsubscribeCount");
					esq.addAggregationSchemaColumn("SpamCount", BPMSoft.AggregationType.SUM, "SpamCount");
					esq.filters.addItem(esq.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
						"SplitTest", this.get("Id")));
					esq.getEntityCollection(function(response) {
						if (response && response.success) {
							var collection = response.collection;
							if (collection && collection.getCount() > 0) {
								var rez = collection.getByIndex(0);
								var percentWeight = rez.get("SendCount") / 100;
								var percentActiveWeight = (rez.get("SendCount") - rez.get("RejectedCount")
									- rez.get("DeliveryError") - rez.get("SoftBounceCount") - rez.get("HardBounceCount")) / 100;
								if (percentWeight === 0) {
									this.set("ClicksCount", 0);
									this.set("OpensCount", 0);
									this.set("SoftBounceCount", 0);
									this.set("HardBounceCount", 0);
									this.set("UnsubscribeCount", 0);
									this.set("SpamCount", 0);
									this.set("Clicks", 0);
									this.set("Opens", 0);
									this.set("SoftBounce", 0);
									this.set("HardBounce", 0);
									this.set("Unsubscribe", 0);
									this.set("Spam", 0);
								} else {
									this.set("ClicksCount", rez.get("ClicksCount"));
									this.set("OpensCount", rez.get("OpensCount"));
									this.set("SoftBounceCount", rez.get("SoftBounceCount"));
									this.set("HardBounceCount", rez.get("HardBounceCount"));
									this.set("UnsubscribeCount", rez.get("UnsubscribeCount"));
									this.set("SpamCount", rez.get("SpamCount"));
									this.set("Clicks", this.get("ClicksCount") / percentActiveWeight);
									this.set("Opens", this.get("OpensCount") / percentActiveWeight);
									this.set("SoftBounce", this.get("SoftBounceCount") / percentWeight);
									this.set("HardBounce", this.get("HardBounceCount") / percentWeight);
									this.set("Unsubscribe", this.get("UnsubscribeCount") / percentActiveWeight);
									this.set("Spam", this.get("SpamCount") / percentActiveWeight);
								}
							}
						}
					}, this);
				},

				/**
				 * @inheritDoc BasePageV2#init
				 * @overridden
				 */
				init: function() {
					this.callParent(arguments);
					this.on("change:StartManual", function(model, value) {
						if (value) {
							this.set("StartDate", null);
						}
						this.setIsStartDateEnabled();
					}, this);
					this.loadSysSettings();
				},

				/**
				 * ######## ######### ########.
				 * @protected
				 */
				loadSysSettings: function() {
					var sysSettings = ["BuildType", "TrialUrl"];
					BPMSoft.SysSettings.querySysSettings(sysSettings, function(settings) {
						var isPublicDemo = (settings.BuildType.value === MarketingEnums.BuildType.DEMO_PUBLIC);
						this.set("IsPublicDemoBuild", isPublicDemo);
						this.set("TrialUrl", settings.TrialUrl);
					}, this);
				},

				/**
				 * @inheritDoc BasePageV2#onEntityInitialized
				 * @overridden
				 */
				onEntityInitialized: function() {
					this.callParent(arguments);
					this.getEmailStatistics();
					this.updateIsRecipientPercentEnabled();
					var statusId = this.get("Status").value;
					var isPlanned = statusId === MarketingEnums.BulkEmailSplitStatus.PLANNED;
					this.setIsStartManualEnabled();
					var currentStep = isPlanned ? BPMSoft.BulkEmailSplitWizardSteps.Emails
						: BPMSoft.BulkEmailSplitWizardSteps.Results;
					this.setCurrentStep(currentStep);
					this.findPassedStep();
					this.setIsStartDateEnabled();
				},

				/**
				 * @inheritDoc BasePageV2#save
				 * @overridden
				 */
				save: function() {
					var saveArgs = arguments;
					var statusId = this.get("Status").value;
					this.set("IsUpdateEmailsDateAfterSave", false);
					if (statusId === MarketingEnums.BulkEmailSplitStatus.START_SCHEDULED) {
						this.checkDateBeforeStart(function() {
							this.superclass.save.apply(this, saveArgs);
							this.set("IsUpdateEmailsDateAfterSave", true);
						});
					} else {
						this.callParent(arguments);
					}
				},

				/**
				 * @inheritDoc BasePageV2#onSaved
				 * @overridden
				 */
				onSaved: function(response) {
					if (response.success) {
						this.sendSaveCardModuleResponse(true);
					}
					this.callParent(arguments);
					var isUpdate = this.get("IsUpdateEmailsDateAfterSave");
					if (isUpdate === false) {
						return;
					}
					var startManual = this.get("StartManual");
					if (startManual === false) {
						this.setBulkEmailSplitStarted();
					} else if (startManual === true) {
						this.abandonSplitTest();
					}
				},

				/**
				 * @inheritDoc BPMSoft.BasePageV2#subscribeSandboxEvents
				 * @overriden
				 */
				subscribeSandboxEvents: function() {
					this.callParent(arguments);
					this.sandbox.subscribe("CurrentStepInHeaderChanged", this.onCurrentStepInHeaderChanged, this,
						[this.sandbox.id]);
					this.sandbox.subscribe("OnRunTestClick", this.onRunTestClick, this,
						[this.sandbox.id]);
					var bulkEmailInBulkEmailSplitId = this.getDetailId("BulkEmailInBulkEmailSplit");
					this.sandbox.subscribe("GetBulkEmailDetailEditable", this.getBulkEmailDetailEditable, this,
						[bulkEmailInBulkEmailSplitId]);
					var bulkEmailSplitTargetId = this.getDetailId("BulkEmailSplitTarget");
					this.sandbox.subscribe("GetIsChanged", function() {
						return {isChanged: this.get("IsChanged")};
					}, this, [bulkEmailSplitTargetId]);
				},

				/**
				 * @inheritDoc BPMSoft.BasePageV2#changeSelectedSideBarMenu
				 * @overriden
				 */
				changeSelectedSideBarMenu: function() {
					var moduleName = "BulkEmail";
					var moduleConfig = BPMSoft.configuration.ModuleStructure[moduleName];
					if (moduleConfig) {
						var sectionSchema = moduleConfig.sectionSchema;
						var config = moduleConfig.sectionModule + "/";
						if (sectionSchema) {
							config += moduleConfig.sectionSchema + "/";
						}
						this.sandbox.publish("SelectedSideBarItemChanged", config, ["sectionMenuModule"]);
					}
				},

				/**
				 * ########## ########### ############## #### "% ###########".
				 * @returns {boolean}
				 */
				updateIsRecipientPercentEnabled: function() {
					var enabled = true;
					var recipientCount = this.get("RecipientCount");
					if (recipientCount > 0) {
						enabled = false;
					}
					var segmentsStatus = this.get("SegmentsStatus");
					if (segmentsStatus && segmentsStatus.value !== MarketingEnums.SegmentsStatus.UPDATED) {
						enabled = false;
					}
					this.set("IsRecipientPercentEnabled", enabled);
				},

				/**
				 * ############# ###### BulkEmailInBulkEmailSplit ####, ########### ## ########### ##############.
				 * @protected
				 */
				setBulkEmailDetailEditable: function() {
					var value = this.get("IsRecipientPercentEnabled");
					var bulkEmailInBulkEmailSplitId = this.getDetailId("BulkEmailInBulkEmailSplit");
					this.sandbox.publish("SetBulkEmailDetailEditable", value, [bulkEmailInBulkEmailSplitId]);

				},

				/**
				 * ########## ###### BulkEmailInBulkEmailSplit ####, ########### ## ########### ##############.
				 * @protected
				 * @return {Boolean}.
				 */
				getBulkEmailDetailEditable: function() {
					return this.get("IsRecipientPercentEnabled");
				},

				/**
				 * ########## ####### ####### ## ###### ####### #####.
				 * @protected
				 */
				onRunTestClick: function() {
					if (this.get("IsPublicDemoBuild")) {
						MarketingCommonUtilities.ShowConfirmationDialogWithGoButton(
							this.get("Resources.Strings.DemoDataMessage"),
							this.get("TrialUrl"),
							this.get("Resources.Strings.TryTrialButtonCaption"),
							this
						);
						return;
					}
					var statusId = this.get("Status").value;
					if (statusId === MarketingEnums.BulkEmailSplitStatus.START_SCHEDULED) {
						this.abandonSplitTest();
					} else if (statusId === MarketingEnums.BulkEmailSplitStatus.PLANNED) {
						this.startSplitTest();
					}
				},

				/**
				 * ######### ######### #####.
				 * @protected
				 */
				abandonSplitTest: function() {
					var bulkEmailSplitId = this.getPrimaryColumnValue();
					var dataSend = {
						splitTestId: this.getPrimaryColumnValue()
					};
					var config = {
						serviceName: "BulkEmailSplitService",
						methodName: "AbandonSplitTest",
						data: dataSend
					};
					this.callService(config, function(response) {
						var result = response.AbandonSplitTestResult;
						if (result.Success === true) {
							this.set("Status", {value: result.StatusId}, {silent: true});
							this.sandbox.publish("ReloadRecordInSection", bulkEmailSplitId, [this.sandbox.id]);
							this.findPassedStep();
						} else {
							this.showInformationDialog(resources.localizableStrings.AbandonTesteEmailAlreadyRunMessage);
						}
					});
				},

				/**
				 * ######### ####### #####.
				 * @protected
				 */
				startSplitTest: function() {
					BPMSoft.chain(
						function(next) {
							var config = {
								style: BPMSoft.MessageBoxStyles.ORANGE
							};
							this.showConfirmationDialog(resources.localizableStrings.ConfirmationRunTestMessage,
								function(returnCode) {
									if (returnCode === BPMSoft.MessageBoxButtons.YES.returnCode) {
										next();
									}
								}, ["yes", "no"], config);
						},
						function(next) {
							this.checkDateBeforeStart(next);
						},
						function(next) {
							this.saveCheckCanEditRight(next);
						},
						function(next) {
							this.saveAsyncValidate(next);
						},
						function(next) {
							this.showBodyMask();
							this.saveEntity(function(response) {
								if (this.validateResponse(response)) {
									this.cardSaveResponse = response;
									next();
								}
							}, this);
						},
						function(next) {
							this.setBulkEmailSplitStarted(next);
						},
						function() {
							this.hideBodyMask.call(this);
							this.findPassedStep();
							this.setCurrentStep(BPMSoft.BulkEmailSplitWizardSteps.Results);
							this.setIsStartDateEnabled();
							this.setIsStartManualEnabled();
							this.showInformationDialog(resources.localizableStrings.StartTestSuccessfulMessage);
						},
						this);
				},

				/**
				 * ######### ######## ######## #### ######, ##### ######## #####.
				 * @protected
				 * @param {Function} callback ####### ######### ######.
				 */
				checkDateBeforeStart: function(callback) {
					var startManual = this.get("StartManual");
					var startDate = this.get("StartDate");
					var isValid = true;
					if (startManual === false && startDate === null) {
						isValid = false;
					}
					var isDateActual = true;
					if (startDate !== null && startDate < new Date()) {
						isDateActual = false;
					}
					if (!isValid) {
						this.showInformationDialog(resources.localizableStrings.StartDateValidationMessage);
						this.setCurrentStep(BPMSoft.BulkEmailSplitWizardSteps.Run);
					} else if (!isDateActual) {
						var dateNotActualMessage = Ext.String.format("{0}\n\n{1}",
							resources.localizableStrings.StartDateActualValidationMessage,
							resources.localizableStrings.StartDateActualValidationAsk);
						var config = {
							style: BPMSoft.MessageBoxStyles.ORANGE
						};
						this.showConfirmationDialog(dateNotActualMessage, function(returnCode) {
							if (returnCode === BPMSoft.MessageBoxButtons.YES.returnCode) {
								this.set("StartDate", new Date());
								this.set("StartManual", true);
								if (callback) {
									callback.call(this);
								}
							}
						}, ["yes", "no"], config);
						this.setCurrentStep(BPMSoft.BulkEmailSplitWizardSteps.Run);
					} else {
						if (callback) {
							callback.call(this);
						}
					}
				},

				/**
				 * ######## # callback-####### ######### ######## ########### # #####-####.
				 * @protected
				 * @param {Function} callback ####### ######### ######.
				 * @param {Array} columns ####### ####### ########## ######## # ######.
				 */
				getBulkEmailIdInBulkEmailSplit: function(callback, columns) {
					var bulkEmailSplitId = this.get("Id");
					var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "BulkEmail"
					});
					esq.addColumn("Id");
					if (columns) {
						BPMSoft.each(columns, function(column) {
							esq.addColumn(column);
						});
					}
					esq.filters.add("filterBulkEmailSplit", BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "SplitTest", bulkEmailSplitId));
					esq.getEntityCollection(function(result) {
						if (result.success) {
							callback.call(this, result.collection);
						}
					}, this);
				},

				/**
				 * ######### ##########.
				 * @inheritdoc BPMSoft.BasePageV2ViewModel#setValidationConfig.
				 * @overridden
				 */
				setValidationConfig: function() {
					this.callParent(arguments);
					this.addColumnValidator("RecipientPercent", this.checkRecipientPercentValidator);
				},

				/**
				 * Validates RecipientPercent.
				 * @private
				 * @return {Object} Validation result.
				 */
				checkRecipientPercentValidator: function() {
					var invalidMessage = "";
					var value = this.get("RecipientPercent");
					if (value > 100 || value <= 0) {
						invalidMessage = this.get("Resources.Strings.IncorrectRecipientPercentMessage");
					}
					return {
						fullInvalidMessage: invalidMessage,
						invalidMessage: invalidMessage
					};
				},

				/**
				 * Returns error message after split test start.
				 * @param {Object} result Service execution result.
				 * @returns {String} Error message.
				 */
				getSplitTestStartErrorMessage: function(result) {
					if (result && result.Message) {
						return result.Message;
					}
					return this.get("Resources.Strings.BulkSplitTestStartErrorDefaultMessage");
				},

				/**
				 * Starts status Started for split test.
				 * @protected
				 * @param {Function} callback Callback function.
				 */
				setBulkEmailSplitStarted: function(callback) {
					var bulkEmailSplitId = this.getPrimaryColumnValue();
					var startManual = this.get("StartManual");
					var startDate = this.get("StartDate");
					if (startManual === true) {
						startDate = new Date();
					}
					var dataSend = {
						splitTestId: bulkEmailSplitId,
						startDate: startDate,
						startManual: startManual
					};
					var config = {
						serviceName: "BulkEmailSplitService",
						methodName: "StartSplitTest",
						data: dataSend
					};
					this.callService(config, function(response) {
						var result = response.StartSplitTestResult;
						if (result && result.Success === true) {
							this.set("Status", {value: result.StatusId}, {silent: true});
							this.sandbox.publish("ReloadRecordInSection", bulkEmailSplitId, [this.sandbox.id]);
							this.findPassedStep();
							this.setIsStartDateEnabled();
							this.setIsStartManualEnabled();
							if (callback) {
								callback.call(this);
							}
						} else {
							this.hideBodyMask.call(this);
							var message = this.getSplitTestStartErrorMessage(result);
							this.showInformationDialog(message);
						}
					}, this);
				},

				/**
				 * Current step change handler.
				 * @protected
				 * @param {Number} value New step number.
				 */
				onCurrentStepInHeaderChanged: function(value) {
					this.set("CurrentStep", value);
				},

				/**
				 * ############# ####### ### # ####### ## ######## # #######.
				 * @protected
				 * @param {Number} value ##### ########## ####.
				 */
				setCurrentStep: function(value) {
					this.set("CurrentStep", value);
					this.sandbox.publish("SetCurrentStepInHeader", value, [this.sandbox.id]);
				},

				/**
				 * ############# ########## ### # ####### ## ######## # #######.
				 * @protected
				 * @param {Number} value ##### ########## ####.
				 */
				setPassedStep: function(value) {
					this.set("PassedStep", value);
					this.sandbox.publish("SetPassedStepInHeader", value, [this.sandbox.id]);
					this.setRunTestButtontCaption();
				},

				/**
				 * ######### ##### ########### #### ### ######## #####.
				 * @protected
				 */
				findPassedStep: function() {
					var statusId = this.get("Status").value;
					if (statusId === MarketingEnums.BulkEmailSplitStatus.PLANNED) {
						var isStep2Passed = this.checkPassedStep2();
						if (!isStep2Passed) {
							this.checkPassedStep1();
						}
					} else if (statusId === MarketingEnums.BulkEmailSplitStatus.STARTED ||
						statusId === MarketingEnums.BulkEmailSplitStatus.START_SCHEDULED) {
						this.setPassedStep(BPMSoft.BulkEmailSplitWizardSteps.Run);
					} else if (statusId === MarketingEnums.BulkEmailSplitStatus.COMPLETED) {
						this.setPassedStep(BPMSoft.BulkEmailSplitWizardSteps.Results);
					}
				},

				/**
				 * ######### ########## ####### ### ########### #### ######### #####.
				 * @protected
				 */
				checkPassedStep1: function() {
					this.getBulkEmailIdInBulkEmailSplit(function(viewModelCollection) {
						var step = viewModelCollection.getCount() > 1 ?
							BPMSoft.BulkEmailSplitWizardSteps.Emails : null;
						this.setPassedStep(step);
					});
				},

				/**
				 * ######### ########## ####### ### ########### #### ######### #####.
				 * @protected
				 * @return {Object}
				 */
				checkPassedStep2: function() {
					var recipientCount = this.get("RecipientCount");
					var segmentsStatus = this.get("SegmentsStatus").value;
					if (recipientCount > 0 && segmentsStatus === MarketingEnums.SegmentsStatus.UPDATED) {
						this.setPassedStep(BPMSoft.BulkEmailSplitWizardSteps.Audience);
						return true;
					}
					return false;
				},

				/**
				 * #########, ### ######## ############# #### ######### #####.
				 * @protected
				 * @param {Number} value ##### ####.
				 * @return {Boolean}.
				 */
				bindConverter1: function(value) {
					return value === BPMSoft.BulkEmailSplitWizardSteps.Emails;
				},

				/**
				 * #########, ### ######## ############# #### ######### #####.
				 * @protected
				 * @param {Number} value ##### ####.
				 * @return {Boolean}.
				 */
				bindConverter2: function(value) {
					return value === BPMSoft.BulkEmailSplitWizardSteps.Audience;
				},

				/**
				 * #########, ### ######## ############# #### ###### #####.
				 * @protected
				 * @param {Number} value ##### ####.
				 * @return {Boolean}.
				 */
				bindConverter3: function(value) {
					return value === BPMSoft.BulkEmailSplitWizardSteps.Run;
				},

				/**
				 * #########, ### ######## ############# #### ########## #####.
				 * @protected
				 * @param {Number} value ##### ####.
				 * @return {Boolean}.
				 */
				bindConverter4: function(value) {
					return value === BPMSoft.BulkEmailSplitWizardSteps.Results;
				},

				/**
				 * ############# #######, ########## ## ########### ############ #### ######.
				 * @protected
				 */
				setIsStartDateEnabled: function() {
					var statusId = this.get("Status").value;
					var startManual = this.get("StartManual");
					if (statusId === MarketingEnums.BulkEmailSplitStatus.COMPLETED ||
						statusId === MarketingEnums.BulkEmailSplitStatus.STARTED) {
						this.set("IsStartDateEnabled", false);
					} else {
						this.set("IsStartDateEnabled", !startManual);
					}
				},

				/**
				 * ############# #######, ########## ## ########### ############ ####### ####### ########.
				 * @protected
				 */
				setIsStartManualEnabled: function() {
					var statusId = this.get("Status").value;
					var result = (statusId === MarketingEnums.BulkEmailSplitStatus.PLANNED ||
					statusId === MarketingEnums.BulkEmailSplitStatus.START_SCHEDULED);
					this.set("IsStartManualEnabled", result);
				},

				/**
				 * ############# ####### ###### ####### ### ######### #####.
				 * @protected
				 */
				setRunTestButtontCaption: function() {
					var passedStep = this.get("PassedStep");
					var caption = "";
					if (!Ext.isEmpty(passedStep) && passedStep !== BPMSoft.BulkEmailSplitWizardSteps.Emails) {
						var statusId = this.get("Status").value;
						if (statusId === MarketingEnums.BulkEmailSplitStatus.PLANNED) {
							caption = resources.localizableStrings.RunSplitTestCaption;
						} else if (statusId === MarketingEnums.BulkEmailSplitStatus.START_SCHEDULED) {
							caption = resources.localizableStrings.AbandonSplitTestCaption;
						}
					}
					this.set("RunTestButtontCaption", caption);
					this.sandbox.publish("SetRunTestButtontCaption", caption, [this.sandbox.id]);
				}

			},
			messages: {
				/**
				 * @message CurrentStepInHeaderChanged
				 * ########## ## ######### ######## #### ####### # #######.
				 */
				"CurrentStepInHeaderChanged": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				/**
				 * @message SetCurrentStepInHeader
				 * ############# ####### ### ####### # #######.
				 */
				"SetCurrentStepInHeader": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				/**
				 * @message SetPassedStepInHeader
				 * ############# ########## ### ####### # #######.
				 */
				"SetPassedStepInHeader": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				/**
				 * @message ReloadCard
				 * ########## # ####### ## ###### ######### #### # #######.
				 */
				"OnRunTestClick": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				/**
				 * @message SetRunTestButtontCaption
				 * ############# ####### ###### ########## ###### {###### #####|########## ####}.
				 */
				"SetRunTestButtontCaption": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				/**
				 * @message SetBulkEmailDetailEditable
				 * ############# ####### ########### ############## ####### ## ###### BulkEmailInBulkEmailSplit.
				 */
				"SetBulkEmailDetailEditable": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				/**
				 * @message GetBulkEmailDetailEditable
				 * ######## ####### ########### ############## ####### ## ###### BulkEmailInBulkEmailSplit.
				 */
				"GetBulkEmailDetailEditable": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				/**
				 * @message GetIndicatorConfig
				 * ######## ############ ######## ########## ###### ##########.
				 */
				"GetIndicatorConfig": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				/**
				 * @message GenerateIndicator
				 * ########## ######### # ########### ########## ####### ###########.
				 */
				"GenerateIndicator": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				/**
				 * @message GetIsChanged
				 * ########## ######### ######## ##############.
				 */
				"GetIsChanged": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				/**
				 * @message ReloadRecordInSection
				 * ########## # ####### ## ###### ######### ####.
				 */
				"ReloadRecordInSection": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			}
		};
	});
