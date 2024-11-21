define("CasePageV2", ["FormatUtils", "NetworkUtilities", "BusinessRuleModule",
		"ConfigurationEnums", "CasesEstimateLabel", "ServiceDeskConstants", "CasePageUtilitiesV2",
		"css!CasePageV2CSS", "css!CasesEstimateLabel", "css!MiniPageViewGeneratorCSS"],
	function(FormatUtils, NetworkUtilities, BusinessRuleModule, Enums, CasesEstimateLabel, ServiceDeskConstants) {
		return {
			entitySchemaName: "Case",
			mixins: {
				/**
				 * @class CasePageUtilitiesV2 implements quick save cards in one click.
				 */
				CasePageUtilitiesV2: "BPMSoft.CasePageUtilitiesV2"
			},
			messages: {
				/**
				 * @message UpdateResolvedButtonMenu
				 * It is need to update the collection of menu items quick save button after changing status.
				 * @param {Object} config menu
				 */
				"UpdateResolvedButtonMenu": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message OnResolvedButtonMenuClick
				 * Event menu selection buttons quick save.
				 * @param {Object} config menu
				 */
				"OnResolvedButtonMenuClick": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message UpdateOpenCaseDetail
				 * Update changes about contact and account.
				 */
				"UpdateOpenCaseDetail": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message GetCaseIdOpenCaseDetail
				 * Informs identifier of current case.
				 */
				"GetCaseIdOpenCaseDetail": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				/**
				 * @message CallCustomer
				 * Make a call for customer.
				 */
				"CallCustomer": {
					"mode": BPMSoft.MessageMode.PTP,
					"direction": BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			attributes: {
				/**
				 * Reason closure code default.
				 */
				"DefCaseClosureCode": {
					dataValueType: this.BPMSoft.DataValueType.GUID,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				/**
				 * Close card after save
				 */
				"IsCloseOnSave": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false
				},
				/**
				 * Caption for ResolvedMenu button.
				 */
				"ResolvedButtonMenuCaption": {
					dataValueType: this.BPMSoft.DataValueType.TEXT,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				/**
				 * Collection name drop-down menu function button is empty.
				 */
				"IsResolvedButtonMenuEmpty": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false
				},
				/**
				 *  Collection name drop-down menu in the function button.
				 */
				"ResolvedButtonMenuItems": {
					dataValueType: this.BPMSoft.DataValueType.COLLECTION
				},
				/**
				 * Informs the name of active tab of open cases.
				 */
				"ActiveOpenCasesTabName": {
					dataValueType: this.BPMSoft.DataValueType.TEXT,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				/**
				 * Contact column value.
				 */
				"Contact": {
					dependencies: [
						{
							columns: ["Contact"],
							methodName: "onContactColumnChanged"
						}
					]
				},
				/**
				 * Account column value.
				 */
				"Account": {
					dependencies: [
						{
							columns: ["Account"],
							methodName: "onAccountColumnChanged"
						}
					]
				},
				/**
				 * SolutionDate column caption value.
				 */
				"SolutionDateCaption": {
					dataValueType: this.BPMSoft.DataValueType.COLLECTION,
					dependencies: [
						{
							columns: ["SolutionDate"],
							methodName: "onPlanedDateChanged"
						},
						{
							columns: ["Status"],
							methodName: "onPlanedDateChanged"
						}
					]
				},
				/**
				 * IsSolutionOverdue column flag.
				 */
				"IsSolutionOverdue": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN
				},
				/**
				 * Status column value.
				 */
				"Status": {
					lookupListConfig: {
						columns: ["IsFinal", "IsResolved", "IsPaused"],
						filter: function() {
							var status = this.get("OriginalStatus");
							var filterGroup = new this.BPMSoft.createFilterGroup();
							if (!status || status.IsFinal) {
								filterGroup.add("emptyFilter", this.BPMSoft.createColumnIsNullFilter("Id"));
								return filterGroup;
							}
							filterGroup.logicalOperation = this.BPMSoft.LogicalOperatorType.OR;
							filterGroup.add("StatusFilter", this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL,
								"[CaseNextStatus:NextStatus].Status", this.get("OriginalStatus").value));
							filterGroup.add("StatusFilterCurrent", this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL,
								"Id", this.get("OriginalStatus").value));
							return filterGroup;

						}
					}
				},
				/**
				 * SatisfactionLevel column value.
				 */
				"SatisfactionLevel": {
					lookupListConfig: {
						columns: ["Point"],
						orders: [
							{
								columnPath: "Point",
								direction: this.BPMSoft.OrderDirection.DESC
							}
						]
					}
				},
				/**
				 * RespondedOn column value.
				 */
				"RespondedOn": {
					dependencies: [
						{
							columns: ["Status"],
							methodName: "onStatusChanged"
						}
					]
				},
				/**
				 * Priority column value.
				 */
				"Priority": {
					dataValueType: this.BPMSoft.DataValueType.LOOKUP,
					lookupListConfig: {
						orders: [
							{
								columnPath: "Priority"
							}
						]
					}
				}

			},
			details: /**SCHEMA_DETAILS*/{
				"ContactCasesDetail": {
					"schemaName": "ContactOpenCasesDetail",
					"entitySchemaName": "Case",
					"filter": {
						"masterColumn": "Contact",
						"detailColumn": "Contact"
					}
				},
				"AccountCasesDetail": {
					"schemaName": "AccountOpenCasesDetail",
					"entitySchemaName": "Case",
					"filter": {
						"masterColumn": "Account",
						"detailColumn": "Account"
					}
				},
				"Files": {
					"schemaName": "FileDetailV2",
					"entitySchemaName": "CaseFile",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "Case"
					}
				},
				"ContactCommunication": {
					"schemaName": "CommunicationInCaseDetail",
					"filter": {
						"masterColumn": "Contact",
						"detailColumn": "Contact"
					}
				}
			}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "remove",
					"name": "HeaderContainer"
				},
				{
					"operation": "insert",
					"name": "ResolvedButton",
					"parentName": "LeftContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"caption": {
							"bindTo": "ResolvedButtonMenuCaption"
						},
						"style": this.BPMSoft.controls.ButtonEnums.style.ORANGE,
						"classes": {
							"textClass": ["actions-button-margin-right"],
							"wrapperClass": ["actions-button-margin-right"]
						},
						"click": {"bindTo": "onResolvedButtonMenuClick"},
						"menu": {
							"items": {"bindTo": "ResolvedButtonMenuItems"}
						},
						"visible": {
							"bindTo": "IsResolvedButtonMenuEmpty",
							"bindConfig": {
								"converter": function(value) {
									return !value;
								}
							}
						}
					}
				},
				{
					"operation": "insert",
					"name": "ProcessingTab",
					"values": {
						"caption": {"bindTo": "Resources.Strings.ProcessingTabCaption"},
						"items": []
					},
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "ParametersTab",
					"values": {
						"caption": {
							"bindTo": "Resources.Strings.ParametersTabCaption"
						},
						"items": []
					},
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 1
				},
				{
					"operation": "insert",
					"name": "FilesTab",
					"values": {
						"caption": {
							"bindTo": "Resources.Strings.FilesTabCaption"
						},
						"items": []
					},
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 2
				},
				{
					"operation": "insert",
					"name": "Files",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					},
					"parentName": "FilesTab",
					"propertyName": "items"
				},
				//ProcessingTab
				{
					"operation": "insert",
					"name": "CaseProcessing_gridLayout",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					},
					"parentName": "ProcessingTab",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "Subject",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24,
							"rowSpan": 1
						},
						"bindTo": "Subject"
					},
					"parentName": "CaseProcessing_gridLayout",
					"propertyName": "items"
				},
				//RightContainerTab
				{
					"operation": "insert",
					"name": "RightContainerTab",
					"values": {
						"caption": {
							"bindTo": "Resources.Strings.RightContainerTabCaption"
						},
						"items": []
					},
					"parentName": "RightTabs",
					"propertyName": "tabs",
					"index": 0
				},
				//ParametersTab
				{
					"operation": "insert",
					"name": "CaseParameters_gridLayout",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					},
					"parentName": "ParametersTab",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "RegisteredOn",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "RegisteredOn",
						"enabled": false
					},
					"parentName": "CaseParameters_gridLayout",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "ResponseDate",
					"values": {
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "ResponseDate",
						"labelConfig": {
							"visible": true
						}
					},
					"parentName": "CaseParameters_gridLayout",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "SolutionDateParameters",
					"values": {
						"layout": {
							"column": 13,
							"row": 1,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "SolutionDate",
						"enabled": false
					},
					"parentName": "CaseParameters_gridLayout",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "FirstSolutionProvidedOn",
					"values": {
						"layout": {
							"column": 13,
							"row": 2,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "FirstSolutionProvidedOn",
						"enabled": false
					},
					"parentName": "CaseParameters_gridLayout",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "SolutionProvidedOn",
					"values": {
						"layout": {
							"column": 13,
							"row": 3,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "SolutionProvidedOn",
						"enabled": false
					},
					"parentName": "CaseParameters_gridLayout",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "ClosureDate",
					"values": {
						"layout": {
							"column": 0,
							"row": 5,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "ClosureDate",
						"enabled": false
					},
					"parentName": "CaseParameters_gridLayout",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "ClosureCode",
					"values": {
						"layout": {
							"column": 0,
							"row": 6,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "ClosureCode",
						"contentType": this.BPMSoft.ContentType.ENUM
					},
					"parentName": "CaseParameters_gridLayout",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "Origin",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 11,
							"rowSpan": 1
						},
						"contentType": this.BPMSoft.ContentType.ENUM,
						"bindTo": "Origin"
					},
					"parentName": "CaseParameters_gridLayout",
					"propertyName": "items"
				},
				// Feedback control group
				{
					"operation": "insert",
					"name": "FeedbackControlGroup",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTROL_GROUP,
						"items": [],
						"caption": {
							"bindTo": "Resources.Strings.FeedbackGroupCaption"
						}
					},
					"parentName": "ParametersTab",
					"propertyName": "items",
					"index": 2
				},
				{
					"operation": "insert",
					"name": "FeedbackControlGroup_gridLayout",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					},
					"parentName": "FeedbackControlGroup",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "SatisfactionLevel",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "SatisfactionLevel",
						"contentType": this.BPMSoft.ContentType.ENUM
					},
					"parentName": "FeedbackControlGroup_gridLayout",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "SatisfactionLevelComment",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24,
							"rowSpan": 1
						},
						"bindTo": "SatisfactionLevelComment",
						"contentType": this.BPMSoft.ContentType.LONG_TEXT
					},
					"parentName": "FeedbackControlGroup_gridLayout",
					"propertyName": "items"
				},
				// SolutionLabel
				{
					"operation": "insert",
					"name": "SolutionCaptionContainer",
					"propertyName": "items",
					"values": {
						"id": "SolutionCaptionContainer",
						"selectors": {"wrapEl": "#SolutionCaptionContainer"},
						"layout": {
							"column": 16,
							"row": 4,
							"colSpan": 6,
							"rowSpan": 1
						},
						"markerValue": "SolutionCaptionContainer",
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["estimate-caption-container"],
						"items": []
					},
					"parentName": "CaseParameters_gridLayout"
				},
				{
					"operation": "insert",
					"name": "SolutionTimerImageContainer",
					"parentName": "SolutionCaptionContainer",
					"propertyName": "items",
					"values": {
						"id": "TimerImageContainer",
						"selectors": {"wrapEl": "#TimerImageContainer"},
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["timer-image-container"],
						"visible": {
							"bindTo": "isSolutionTimerImageVisible"
						},
						"markerValue": "SolutionTimerImageContainer",
						"afterrerender": {
							"bindTo": "renderCaptionStyle"
						},
						"afterrender": {
							"bindTo": "renderCaptionStyle"
						},
						"items": []
					},
					"index": 10
				},
				{
					"operation": "insert",
					"name": "SolutionMinutesCaption",
					"parentName": "SolutionCaptionContainer",
					"propertyName": "items",
					"values": {
						"id": "SolutionMinutesCaption",
						"labelClass": ["estimate-caption-label"],
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "getSolutionDateMinute"
						},
						"visible": {
							"bindTo": "isSolutionHourVisible"
						}
					},
					"index": 3
				},
				{
					"operation": "insert",
					"name": "SolutionEstimateSeconds",
					"parentName": "SolutionCaptionContainer",
					"propertyName": "items",
					"values": {
						"id": "SolutionEstimateSeconds",
						"labelClass": ["estimate-caption-label blink"],
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": ":",
						"visible": {
							"bindTo": "isSolutionHourVisible"
						}
					},
					"index": 2
				},
				{
					"operation": "insert",
					"name": "SolutionCaptionLabel",
					"parentName": "SolutionCaptionContainer",
					"propertyName": "items",
					"values": {
						"id": "SolutionCaptionLabel",
						"labelClass": ["estimate-caption-label day"],
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "getSolutionDateDay"
						},
						"visible": {
							"bindTo": "isSolutionCaptionVisible"
						},
						"afterrerender": {"bindTo": "renderCaptionStyle"},
						"afterrender": {"bindTo": "renderCaptionStyle"}
					},
					"index": 1
				},
				{
					"operation": "insert",
					"name": "SolutionCaptionPrefix",
					"parentName": "SolutionCaptionContainer",
					"propertyName": "items",
					"values": {
						"id": "SolutionCaptionPrefix",
						"labelClass": ["estimate-caption-label prefix"],
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "getSolutionCaptionPrefix"
						},
						"visible": {
							"bindTo": "isSolutionCaptionVisible"
						}
					},
					"index": 0
				},
				//Profile container
				{
					"operation": "insert",
					"name": "Priority",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 5,
							"rowSpan": 1
						},
						"bindTo": "Priority",
						"contentType": this.BPMSoft.ContentType.ENUM,
						"labelConfig": {
							"visible": false
						},
						"change": {
							bindTo: "setPriorityField"
						},
						"iconsVisible": true,
						"wrapClass": ["priority-edit-class"]
					},
					"parentName": "CaseProfile_gridLayout",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "StatusContainer",
					"values": {
						"layout": {
							"column": 5,
							"row": 0,
							"colSpan": 9,
							"rowSpan": 1
						},
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"classes": {
							"wrapClassName": ["caseStatusContainer"]
						},
						"items": []
					},
					"parentName": "CaseProfile_gridLayout",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "StatusValue",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "getStatusValue"},
						"markerValue": "StatusValue"
					},
					"parentName": "StatusContainer",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "NumberContainer",
					"values": {
						"layout": {
							"column": 14,
							"row": 0,
							"colSpan": 10,
							"rowSpan": 1
						},
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"classes": {
							"wrapClassName": ["caseNumberContainer"]
						},
						"items": []
					},
					"parentName": "CaseProfile_gridLayout",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "NumberValue",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "getNumberValue"},
						"markerValue": "NumberValue"
					},
					"parentName": "NumberContainer",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "SolutionDate",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 16,
							"rowSpan": 1
						},
						"bindTo": "SolutionDate",
						"labelConfig": {
							"visible": true
						},
						"enabled": false
					},
					"parentName": "CaseProfile_gridLayout",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "Contact",
					"values": {
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24,
							"rowSpan": 1
						},
						"bindTo": "Contact"
					},
					"parentName": "CaseProfile_gridLayout",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "Account",
					"values": {
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 24,
							"rowSpan": 1
						},
						"bindTo": "Account"
					},
					"parentName": "CaseProfile_gridLayout",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "Category",
					"values": {
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 24,
							"rowSpan": 1
						},
						"bindTo": "Category",
						"enabled": {
							"bindTo": "IsCategoryEnabled"
						},
						"contentType": this.BPMSoft.ContentType.ENUM
					},
					"parentName": "CaseProfile_gridLayout",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "CreatedOnContainer",
					"values": {
						"layout": {
							"column": 0,
							"row": 9,
							"colSpan": 24,
							"rowSpan": 1
						},
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"classes": {
							"wrapClassName": ["caseCreatedOnContainer"]
						},
						"items": []
					},
					"parentName": "CaseProfile_gridLayout",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "CreatedOnValue",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "getCreatedOnDate"},
						"markerValue": {"bindTo": "CreatedOnValue"},
						"visible": {"bindTo": "isEditMode"}
					},
					"parentName": "CreatedOnContainer",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "CaseProfile_gridLayout",
					"values": {
						"generator": "MiniPageViewGenerator.generatePartial",
						"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
						"classes": {
							"wrapClassName": ["profileContainer"]
						},
						"items": []
					},
					"parentName": "RightContainerTab",
					"propertyName": "items",
					"index": 9
				},
				/*SolutionLabel*/
				{
					"operation": "insert",
					"name": "SolutionCaptionProfile",
					"parentName": "CaseProfile_gridLayout",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 16,
							"row": 1,
							"colSpan": 8,
							"rowSpan": 1
						},
						"markerValue": "SolutionCaptionContainerProfile",
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["profile-estimate-caption-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "SolutionCaptionValueProfile",
					"parentName": "SolutionCaptionProfile",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "getSolutionCaptionValue"},
						"markerValue": "SolutionCaptionValueProfile",
						"visible": {"bindTo": "isSolutionHourVisible"},
						"labelClass": ["estimate-caption-label"],
						"hint": {
							"bindTo": "getSolutionCaptionHint"
						}
					}
				},
				//Right container contact communication detail
				{
					"operation": "insert",
					"parentName": "RightContainerTab",
					"propertyName": "items",
					"name": "ContactCommunication",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL,
						"visible": false
					},
					"index": 9
				},
				//Right container open cases detail
				{
					"operation": "insert",
					"name": "OpenCasesControlGroup",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTROL_GROUP,
						"items": [],
						"caption": {
							"bindTo": "Resources.Strings.OpenCasesControlGroupCaption"
						},
						"visible": false
					},
					"parentName": "RightContainerTab",
					"propertyName": "items",
					"index": 10
				},
				{
					"operation": "insert",
					"name": "OpenCasesDetail",
					"parentName": "OpenCasesControlGroup",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"visible": {"bindTo": "getRightTabsContainerVisible"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "OpenCasesTabs",
					"parentName": "OpenCasesDetail",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.TAB_PANEL,
						"activeTabChange": {"bindTo": "activeOpenCasesTabChange"},
						"activeTabName": {"bindTo": "ActiveOpenCasesTabName"},
						"classes": {"wrapClass": ["tab-panel-margin-bottom"]},
						"collection": {"bindTo": "OpenCasesTabsCollection"},
						"tabs": []
					}
				},
				{
					"operation": "insert",
					"name": "ContactCasesTab",
					"values": {
						"caption": {
							"bindTo": "Resources.Strings.ContactTabCaption"
						},
						"visible": {
							"bindTo": "ContactOpenCasesTabVisibility"
						},
						"items": []
					},
					"parentName": "OpenCasesTabs",
					"propertyName": "tabs",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "ContactCasesDetail",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					},
					"parentName": "ContactCasesTab",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "AccountCasesTab",
					"values": {
						"caption": {
							"bindTo": "Resources.Strings.AccountTabCaption"
						},
						"items": []
					},
					"parentName": "OpenCasesTabs",
					"propertyName": "tabs",
					"index": 1
				},
				{
					"operation": "insert",
					"name": "AccountCasesDetail",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					},
					"parentName": "AccountCasesTab",
					"propertyName": "items",
					"index": 0
				}
			]/**SCHEMA_DIFF*/,
			methods: {
				/**
				 * Returns Case created on hint.
				 * @protected
				 * @returns {String}
				 */
				getSolutionCaptionHint: function() {
					var prefix = this.getSolutionCaptionPrefix();
					return prefix ? prefix.replace(":", "") : "";
				},

				/**
				 * Returns Case created on caption.
				 * @protected
				 * @returns {String}
				 */
				getSolutionCaptionValue: function() {
					var prefix = "";
					var day = this.getSolutionDateDay();
					var minutes = this.getSolutionDateMinute();
					return FormatUtils.getDateCaption(prefix, day, minutes);
				},

				/**
				 * Returns Case status.
				 * @protected
				 * @returns {String}
				 */
				getStatusValue: function() {
					var status = this.get("Status");
					return status ? status.displayValue : "";
				},

				/**
				 * Returns Case number.
				 * @protected
				 * @returns {String}
				 */
				getNumberValue: function() {
					var number = this.get("Number");
					return number ? number.replace("-", "") : "";
				},

				/**
				 * @inheritDoc BasePageV2#onCloseCardButtonClick
				 * @overridden
				 */
				onCloseCardButtonClick: function() {
					this.hideBodyMask({
						uniqueMaskId: "case"
					});
					this.callParent(arguments);
				},

				/**
				 * Checks need to change the owner and if so replace
				 * @param {Object} status The new status
				 */
				changeOwner: function(status) {
					var isPortalUser = this.BPMSoft.CurrentUser.userType === this.BPMSoft.UserType.SSP;
					if (status.value === ServiceDeskConstants.CaseState.InProgress && !isPortalUser) {
						var owner = this.get("Owner");
						var contact = this.BPMSoft.SysValue.CURRENT_USER_CONTACT;
						if ((!owner) || (contact && owner && (owner.value !== contact.value))) {
							this.set("Owner", contact);
						}
					}
					if (status.value === ServiceDeskConstants.CaseState.Reopened) {
						this.set("Owner", null);
					}
				},

				/**
				 * Processing saving case after selecting menu item quick save button.
				 * @protected
				 * @param {Object} config Config menu
				 */
				saveCard: function(config) {
					if (config.IsSetClosureCode && config.ClosureCode && !this.get("ClosureCode")) {
						this.set("ClosureCode", config.ClosureCode);
					}
					var status = config.Status;
					this.set("Status", status);
					this.changeOwner(status);
					this.set("IsCloseOnSave", config.IsCloseOnSave);
					if (config.IsCloseOnSave) {
						this.save();
					} else {
						this.save({
							callback: this.Ext.emptyFn,
							isSilent: true,
							callBaseSilentSavedActions: true
						});
					}
				},

				/**
				 * Processing selecting menu item quick save button
				 * @protected
				 * @param {Object} config Config menu
				 */
				onResolvedButtonMenuClick: function(config) {
					if (!config) {
						var resolvedButtonMenuItems = this.get("ResolvedButtonMenuItems");
						if (!resolvedButtonMenuItems.isEmpty()) {
							config = resolvedButtonMenuItems.collection.items[0].values.Tag;
						} else {
							return;
						}
					}
					var status = config.Status;
					if (!status) {
						return;
					}
					this.showBodyMask({
						uniqueMaskId: "case"
					});
					this.asyncValidate(function(result) {
						if (result.success) {
							this.saveCard.call(this, config);
						} else {
							this.hideBodyMask({
								uniqueMaskId: "case"
							});
							this.showInformationDialog(result.message);
						}
					}, this);
				},

				/**
				 * Initializes of initial values of model.
				 * @overridden
				 */
				init: function() {
					this.statusDefSysSettingsName = "CaseStatusDef";
					this.callParent(arguments);
					this.initCollection();
					this.set("ResolvedButtonMenuCaption", this.get("Resources.Strings.ResolvedButtonCaption"));
				},

				/**
				 * @inheritdoc BasePageV2#onDestroy
				 * @overridden
				 */
				onDestroy: function() {
					this.hideBodyMask({
						uniqueMaskId: "case"
					});
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc BasePageV2#onRender
				 * @overridden
				 */
				onRender: function() {
					this.callParent(arguments);
					this.renderCaptionStyle();
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#initTabs
				 * @overridden
				 */
				initTabs: function() {
					this.callParent(arguments);
					var defaultRightTabName = this.getDefaultOpenCasesTabName();
					if (!defaultRightTabName) {
						return;
					}
					this.setActiveOpenCasesTab(defaultRightTabName);
					this.set(defaultRightTabName, true);
					this.initCasePageMessages();
				},

				/**
				 * Initializes messages on page.
				 * @protected
				 */
				initCasePageMessages: function() {
					var contactSubscriberId = this.sandbox.id + "_detail_ContactCasesDetailCase";
					this.sandbox.subscribe("GetCaseIdOpenCaseDetail", function() {
						return this.get("Id");
					}, this, [contactSubscriberId]);
					var accountSubscriberId = this.sandbox.id + "_detail_AccountCasesDetailCase";
					this.sandbox.subscribe("GetCaseIdOpenCaseDetail", function() {
						return this.get("Id");
					}, this, [accountSubscriberId]);
				},

				/**
				 * Returns the first tab name of open cases.
				 * @protected
				 * @virtual
				 * @return {String} Name of first tab of open cases.
				 */
				getDefaultOpenCasesTabName: function() {
					var tabsCollection = this.get("OpenCasesTabsCollection");
					if (tabsCollection.isEmpty()) {
						return "";
					}
					var firstTab = tabsCollection.getByIndex(0);
					var defaultTabName = firstTab.get("Name");
					return defaultTabName;
				},

				/**
				 * Sets open cases active tab.
				 * @protected
				 * @virtual
				 * @param {String} tabName Tab name.
				 */
				setActiveOpenCasesTab: function(tabName) {
					this.set("ActiveOpenCasesTabName", tabName);
				},

				/**
				 * Open cases tab change event handler.
				 * @protected
				 * @virtual
				 * @param {BPMSoft.BaseViewModel} activeTab Active bab.
				 */
				activeOpenCasesTabChange: function(activeTab) {
					var activeTabName = activeTab.get("Name");
					var tabsCollection = this.get("OpenCasesTabsCollection");
					tabsCollection.eachKey(function(tabName, tab) {
						var tabContainerVisibleBinding = tab.get("Name");
						this.set(tabContainerVisibleBinding, false);
					}, this);
					this.set(activeTabName, true);
				},

				/**
				 * @inheritdoc BPMSoft.LookupQuickAddMixin#checkRightsCallback
				 * @overridden
				 */
				extractValuePairsFromFilters: function(entitySchema, columnName, lookupFilters) {
					if (columnName === "Contact") {
						lookupFilters = this.Ext.create("BPMSoft.Collection");
						this.set("Account", null);
					}
					this.callParent(arguments);
				},

				/**
				 * Contact change event handler.
				 * @protected
				 */
				onContactColumnChanged: function() {
					var contact = this.get("Contact");
					var subscriberId = this.sandbox.id + "_detail_ContactCasesDetailCase";
					var updateConfig = {
						masterRecordId: contact ? contact.value : this.BPMSoft.GUID_EMPTY,
						reloadAll: true
					};
					this.sandbox.publish("UpdateOpenCaseDetail", updateConfig, [subscriberId]);
					this.updateDetail({
						detail: "ContactCommunication"
					});
				},

				/**
				 * Account change event handler.
				 * @protected
				 */
				onAccountColumnChanged: function() {
					var account = this.get("Account");
					var subscriberId = this.sandbox.id + "_detail_AccountCasesDetailCase";
					var updateConfig = {
						masterRecordId: account,
						reloadAll: true
					};
					this.sandbox.publish("UpdateOpenCaseDetail", updateConfig, [subscriberId]);
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#onSaved
				 * @overridden
				 */
				onSaved: function() {
					this.callParent(arguments);
					var response = arguments[0];
					this.hideBodyMask({
						uniqueMaskId: "case"
					});
					if (response.success) {
						if (this.get("IsCloseOnSave")&& !this.get("NextPrcElReady")) {
							this.onCloseCardButtonClick();
						} else {
							var statusId = this.get("Status").value;
							if (this.get("IsInChain") || this.sandbox.moduleName === "ProcessCardModuleV2") {
								this.getResolvedButtonMenu.call(this, statusId);
							} else {
								this.sandbox.publish("UpdateResolvedButtonMenu", statusId,
									[this.sandbox.id]);
							}
						}
					}
				},

				/**
				 * @inheritDoc BPMSoft.BaseSectionV2#subscribeSandboxEvents
				 * @overridden
				 */
				subscribeSandboxEvents: function() {
					this.callParent(arguments);
					var resolvedClickSubscriberId = this.sandbox.id;
					this.sandbox.subscribe("OnResolvedButtonMenuClick", function() {
						var tagMenuItem = arguments[0];
						this.onResolvedButtonMenuClick(tagMenuItem);
					}, this, [resolvedClickSubscriberId]);
				},

				/**
				 * @inheritDoc BasePageV2#onEntityInitialized
				 * @overridden
				 */
				onEntityInitialized: function() {
					if (this.isAddMode() || this.isCopyMode()) {
						this.setCaseNumber();
						this.setPriorityImage();
					}
					this.BPMSoft.SysSettings.querySysSettingsItem(this.statusDefSysSettingsName, function(value) {
						this.set("StatusDefSysSettingsValue", value);
					}, this);
					this.BPMSoft.SysSettings.querySysSettingsItem("CaseClosureCodeDef", function(value) {
						this.set("DefCaseClosureCode", value);
					}, this);
					this.updateOriginals();
					var contact = this.get("Contact");
					if (contact && !this.get("Account")) {
						var account = contact.Account;
						if (account) {
							this.set("Account", account);
						}
					}
					this.set("PreviousStatus", this.get("Status"));
					this.set("IsCategoryEnabled", this.isNew || !this.get("Category"));
					this.callParent(arguments);
					this.setDateDiff();
					this.renderCaptionStyle();
					var status = this.get("Status");
					var statusId = status ? status.value : this.get("StatusDefSysSettingsValue");
					this.getResolvedButtonMenu(statusId);
					if (!this.isNewMode()) {
						this.setControlsValue();
					}
				},

				setPriorityImage: function() {
					var priority = this.get("Priority");
					if (!priority) {
						return;
					}
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "CasePriority"
					});
					esq.addColumn("Image");
					esq.filters.add("defaultPriorityFilter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Id", priority.value));
					esq.getEntityCollection(function(result) {
						if (!result.success) {
							return;
						}
						var item = result.collection.getItems()[0];
						if (!item) {
							return;
						}
						var image = item.get("Image");
						var updatedValue = {};
						updatedValue.value = item.get("Id");
						updatedValue.primaryImageValue = image.value;
						this.set("Priority", updatedValue);
					}, this);
				},

				/**
				 * Application and updating css-styles after rerendering component.
				 * @protected
				 * @virtual
				 */
				renderCaptionStyle: function() {
					if (CasesEstimateLabel.isCaptionVisible(this)) {
						CasesEstimateLabel.setCaptionStyle(this);
					}
				},

				/**
				 * Solution Date change event handler.
				 * @protected
				 * @virtual
				 */
				onPlanedDateChanged: function() {
					if (!this.get("Status")) {
						return;
					}
					this.setDateDiff();
					this.renderCaptionStyle();
				},

				/**
				 * Calculation the date difference for Response date and solution date.
				 * @protected
				 * @virtual
				 */
				setDateDiff: function() {
					if (!CasesEstimateLabel.isCaptionVisible(this)) {
						return;
					}
					CasesEstimateLabel.calculateDateDiff("SolutionDate", "SolutionDateCaption",
						"IsSolutionOverdue", this);
				},

				/**
				 * Sets the date and time for Solution Date.
				 * @protected
				 * @returns {string} String line with the days and hours
				 */
				getSolutionDateDay: function() {
					var isOverdue = this.get("IsSolutionOverdue");
					return CasesEstimateLabel.setDayDiff("SolutionDateCaption", isOverdue, this);
				},

				/**
				 * Sets the minutes for Solution Date.
				 * @protected
				 * @returns {string} String line with the minutes
				 */
				getSolutionDateMinute: function() {
					return CasesEstimateLabel.getDateMinute("SolutionDateCaption", this);
				},

				/**
				 * Display hours for Solution Date.
				 * @protected
				 * @returns {Boolean} Hours visibility flag
				 */
				isSolutionHourVisible: function() {
					return (CasesEstimateLabel.isHourVisible("SolutionDateCaption", this) && this.isSolutionCaptionVisible());
				},

				/**
				 * Displays image from Solution Date.
				 * @protected
				 * @returns {Boolean} Timer image and solution caption visibility flag
				 */
				isSolutionTimerImageVisible: function() {
					return (this.isTimerImageVisible() && this.isSolutionCaptionVisible());
				},

				/**
				 * Displays clock container.
				 * @protected
				 * @returns {Boolean} Timer image visibility flag
				 */
				isTimerImageVisible: function() {
					var status = this.get("Status");
					if (!status) {
						return false;
					}
					return !(status.IsPaused || status.IsFinal || status.IsResolved);
				},

				/**
				 * Flag of Solution caption.
				 * @protected
				 * @returns {Boolean} Solution caption visibility flag
				 */
				isSolutionCaptionVisible: function() {
					var CaseStatus = this.get("Status");
					var solutionDate = CasesEstimateLabel.isSolutionDate(this);
					return ((CasesEstimateLabel.isCaptionVisible(this) && solutionDate && CaseStatus &&
					(!CaseStatus.IsFinal && !CaseStatus.IsResolved && !CaseStatus.IsPaused)) ||
					(this.get("IsSolutionOverdue") && CasesEstimateLabel.isCaptionVisible(this) && solutionDate));
				},
				/**
				 * Gets prefix for Solution Date.
				 * @protected
				 * @returns {string} Solution caption
				 */
				getSolutionCaptionPrefix: function() {
					return this.get("IsSolutionOverdue") ?
						this.get("Resources.Strings.DelayHeaderCaptionSuffix") :
						this.get("Resources.Strings.LeftHeaderCaptionSuffix");
				},

				/**
				 * @inheritDoc CasePageV2#getLookupQueryFilters
				 * @overridden
				 */
				getLookupQueryFilters: function(columnName) {
					var parentColumnName = this.get("ParentColumnName");
					var parentFilters = this.get(parentColumnName + "Filters");
					var filterGroup = this.callParent([columnName]);
					if (columnName === parentColumnName && parentFilters) {
						filterGroup.add(parentFilters);
					}
					return filterGroup;
				},

				/**
				 * @inheritDoc CasePageV2#getLookupQuery
				 * @overridden
				 */
				getLookupQuery: function(filterValue, columnName, isLookup) {
					var parentColumnName = this.get("ParentColumnName");
					var parentFilters = this.get(parentColumnName + "Filters");
					var prepareListColumnName = this.get("PrepareListColumnName");
					var prepareListFilters = this.get(prepareListColumnName + "Filters");
					var entitySchemaQuery = this.callParent([filterValue, columnName, isLookup]);
					if (columnName === prepareListColumnName && prepareListFilters) {
						entitySchemaQuery.filters.add(prepareListColumnName + "Filter", prepareListFilters);
					}
					if (columnName === parentColumnName && parentFilters) {
						entitySchemaQuery.filters.add(parentColumnName + "Filter", parentFilters);
					}
					return entitySchemaQuery;
				},

				/**
				 * Updates information about initial object data.
				 * @protected
				 * @param {Boolean} isNull Cleaning flag of initial data
				 */
				updateOriginals: function(isNull) {
					var status = isNull ? null : this.get("Status");
					this.set("OriginalStatus", status);
					if (status) {
						this.set("IsOriginalStatusPaused", status.IsPaused);
					}
					this.set("OriginalSolutionProvidedOn", isNull ? null : this.get("SolutionProvidedOn"));
				},

				/**
				 * Sets the Number of Case.
				 * @protected
				 */
				setCaseNumber: function() {
					this.getIncrementCode(function(response) {
						this.set("Number", response);
					});
				},

				/**
				 * Non-empty field check for "Contact" and "Account".
				 * @param {Function} callback
				 * @param {BPMSoft.BaseSchemaViewModel} scope Execution context of callback-function
				 */
				validateAccountOrContactFilling: function(callback, scope) {
					var account = this.get("Account");
					var contact = this.get("Contact");
					var result = {
						success: true
					};
					if (this.Ext.isEmpty(account) && this.Ext.isEmpty(contact)) {
						result.message = this.get("Resources.Strings.RequiredContactOrAccountMessage");
						result.success = false;
					}
					callback.call(scope || this, result);
				},

				/**
				 * The handler that checks whether the status is resolved.
				 * @protected
				 * @virtual
				 * @param {Object} status Case status
				 */
				handleResolvedStatus: function(status) {
					if (status.IsResolved) {
						if (!this.get("SolutionProvidedOn")) {
							this.set("SolutionProvidedOn", new Date());
						}
						if (!this.get("FirstSolutionProvidedOn")) {
							this.set("FirstSolutionProvidedOn", new Date());
						}
					}
				},

				/**
				 * Clears "SolutionProvidedOn" if the status has been changes from "IsResolved" to not "IsFinal".
				 * @param {Object} status Case status
				 */
				clearSolutionProvidedOn: function(status) {
					var previousStatus = this.get("PreviousStatus");
					if (!status.IsFinal && previousStatus.IsResolved && this.get("SolutionProvidedOn")) {
						this.set("SolutionProvidedOn", 0);
					}
				},

				/**
				 * The handler that checks whether the status "IsFinal".
				 * If the status is final, sets "ClosureDate" and "ClosureCode".
				 * @param {Object} status Case status
				 */
				handleFinalStatus: function(status) {
					if (status.IsFinal && !this.get("ClosureDate")) {
						this.set("ClosureDate", new Date());
						if (this.get("OriginalSolutionProvidedOn")) {
							this.set("SolutionProvidedOn", this.get("OriginalSolutionProvidedOn"));
						}
						if (!this.get("ClosureCode")) {
							this.set("ClosureCode", this.get("DefCaseClosureCode"));
						}
					} else {
						this.set("ClosureDate", null);
						this.set("ClosureCode", null);
					}
				},

				/**
				 * "Status" change event handler.
				 * Changing the status from initial status to any other, sets the "RespondedOn" field by current date and time.
				 * @protected
				 */
				onStatusChanged: function() {
					var status = this.get("Status");
					if (!status) {
						return;
					}
					if (this.isStatusDef() === false && !this.get("RespondedOn")) {
						this.set("RespondedOn", new Date());
					}
					var originalStatus = this.get("OriginalStatus");
					if (!originalStatus) {
						return;
					}
					if (this.isNew || originalStatus !== status) {
						this.handleFinalStatus(status);
						this.handleResolvedStatus(status);
						this.handlePausedStatus(status);
					}
					this.clearSolutionProvidedOn(status);
					this.set("PreviousStatus", status);
				},

				/**
				 * The handler that checks whether the status is equal to "IsPaused".
				 * If the is "IsPaused", status is cleared
				 * @param {Object} status Case status
				 */
				handlePausedStatus: this.BPMSoft.emptyFn,

				/**
				 * Checks whether the field "RespondedOn" is not empty or it has been changed.
				 * @protected
				 * @returns {Boolean} RespondedOn updating flag
				 */
				needUpdateRespondedOn: function() {
					return this.get("RespondedOn") && this.changedValues && this.changedValues.RespondedOn;
				},

				/**
				 * Checks whether the field "SolutionProvidedOn" is not empty or it has been changed.
				 * @protected
				 * @returns {Boolean} SolutionProvidedOn updating flag
				 */
				needUpdateSolutionProvidedOn: function() {
					return this.get("SolutionProvidedOn") && this.changedValues && this.changedValues.SolutionProvidedOn;
				},

				/**
				 * Checks whether the field "FirstSolutionProvidedOn" is not empty or it has been changed.
				 * @protected
				 * @returns {Boolean} FirstSolutionProvidedOn updating flag
				 */
				needUpdateFirstSolutionProvidedOn: function() {
					return this.get("FirstSolutionProvidedOn") && this.changedValues && this.changedValues.FirstSolutionProvidedOn;
				},

				/**
				 * Checks whether "Status" column value and system settings "StatusDefSysSettingsValue" value are equal.
				 * @protected
				 * @returns {Boolean} Default status flag
				 */
				isStatusDef: function() {
					var status = this.get("Status");
					var statusDefSysSettingsValue = this.get("StatusDefSysSettingsValue");
					if (!status || !statusDefSysSettingsValue) {
						return;
					}
					return statusDefSysSettingsValue.value === status.value;
				},

				/**
				 * Fills the field of duplicate controls.
				 * @protected
				 */
				setControlsValue: function() {
					var category = this.get("Category");
					var origin = this.get("Origin");
					var priority = this.get("Priority");
					if (category) {
						this.set("ParametersCategory", category);
					}
					if (origin) {
						this.set("ParametersOrigin", origin);
					}
					if (priority) {
						this.set("ParametersPriority", priority);
					}
				},

				/**
				 * Forms the case date of creation.
				 * @protected
				 * @virtual
				 * @return {String} Case date of creation.
				 */
				getCreatedOnDate: function() {
					var createdOn = this.get("CreatedOn");
					var caption = this.get("Resources.Strings.CreatedOnCaption") + " ";
					return createdOn ? caption + FormatUtils.smartFormatDate(createdOn) : "";
				},

				/**
				 * Checks the rights, validates values, saves values
				 * If necessary, recalculates the value of the "RespondedOn" before saving
				 * @protected
				 * @virtual
				 */
				save: function() {
					if (this.needUpdateRespondedOn()) {
						this.set("RespondedOn", new Date());
					}
					if (this.needUpdateSolutionProvidedOn()) {
						this.set("SolutionProvidedOn", new Date());
					}
					if (this.needUpdateFirstSolutionProvidedOn()) {
						this.set("FirstSolutionProvidedOn", new Date());
					}
					var solutionRemainsSetter = this.get("SolutionRemainsSetter");
					if (solutionRemainsSetter) {
						this.set("SolutionRemains", solutionRemainsSetter);
					} else {
						this.set("SolutionRemains", 0);
					}
					this.set("IsCategoryEnabled", this.isNew || !this.get("Category"));
					this.updateOriginals();
					this.callParent(arguments);
				},

				/**
				 * @inheritDoc CasePageV2#asyncValidate
				 * @overridden
				 */
				asyncValidate: function(callback, scope) {
					this.callParent([function(response) {
						var chainCheckResponse = function(next) {
							if (!this.response.success) {
								this.callback.call(this.scope, this.response);
							} else {
								next();
							}
						};
						var chainValidateAccountOrContact = function(next) {
							var self = this;
							this.scope.validateAccountOrContactFilling(function(response) {
								self.response = response;
								next();
							}, this.scope);
						};
						var chainInvokeCallback = function() {
							this.callback.call(this.scope, this.response);
						};
						var chainScope = {
							scope: scope || this,
							response: response,
							callback: callback
						};
						this.BPMSoft.chain(chainCheckResponse, chainValidateAccountOrContact, chainInvokeCallback, chainScope);
					}, this]);
				},

				/**
				 * @inheritDoc CasePageV2#onGridRowChanged
				 * @overridden
				 */
				onGridRowChanged: function() {
					var result = this.callParent(arguments);
					this.updateOriginals(true);
					return result;
				},

				/**
				 * Sets context help identifier.
				 * @protected
				 */
				initContextHelp: function() {
					this.set("ContextHelpId", 1063);
					this.callParent(arguments);
				},

				/**
				 * Sets priority field caption.
				 * @protected
				 * @param {Object} item Selected list
				 */
				setPriorityField: function(item) {
					item.displayValue = "";
				}
			},
			rules: {
				"Contact": {
					"FiltrationContactByAccount": {
						"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
						"autocomplete": true,
						"autoClean": true,
						"baseAttributePatch": "Account",
						"comparisonType": this.BPMSoft.ComparisonType.EQUAL,
						"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
						"attribute": "Account"
					}
				},
				"ClosureCode": {
					"EnableClosureCodeOnFinalState": {
						ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						property: BusinessRuleModule.enums.Property.ENABLED,
						conditions: [
							{
								leftExpression: {
									type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									attribute: "Status",
									attributePath: "IsFinal"
								},
								comparisonType: this.BPMSoft.ComparisonType.EQUAL,
								rightExpression: {
									type: BusinessRuleModule.enums.ValueType.CONSTANT,
									value: true
								}
							},
							{
								leftExpression: {
									type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									attribute: "Status",
									attributePath: "IsResolved"
								},
								comparisonType: this.BPMSoft.ComparisonType.EQUAL,
								rightExpression: {
									type: BusinessRuleModule.enums.ValueType.CONSTANT,
									value: true
								}
							}
						]
					},
					"RequireClosureCodeOnFinalState": {
						ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						property: BusinessRuleModule.enums.Property.REQUIRED,
						conditions: [{
							leftExpression: {
								type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
								attribute: "Status",
								attributePath: "IsFinal"
							},
							comparisonType: this.BPMSoft.ComparisonType.EQUAL,
							rightExpression: {
								type: BusinessRuleModule.enums.ValueType.CONSTANT,
								value: true
							}
						}]
					}
				},
				"ClosureDate": {
					"EnableClosureDateOnFinalState": {
						ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						property: BusinessRuleModule.enums.Property.ENABLED,
						conditions: [{
							leftExpression: {
								type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
								attribute: "Status",
								attributePath: "IsFinal"
							},
							comparisonType: this.BPMSoft.ComparisonType.EQUAL,
							rightExpression: {
								type: BusinessRuleModule.enums.ValueType.CONSTANT,
								value: true
							}
						}]
					}
				}
			}
		};
	});
