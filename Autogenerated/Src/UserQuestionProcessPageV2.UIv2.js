define("UserQuestionProcessPageV2", ["ProcessModuleUtilities", "CustomProcessPageV2Utilities"],
	function() {
		return {
			mixins: {
				CustomProcessPageV2Utilities: "BPMSoft.CustomProcessPageV2Utilities"
			},
			entitySchemaName: null,
			attributes: {},
			details: /**SCHEMA_DETAILS*/{
			}/**SCHEMA_DETAILS*/,
			methods: {

				/**
				 * ################ ########### ######### ######### ######## #### ### ########,
				 * ### ### ## ########### entitySchema
				 * @overridden
				 */
				initCardPrintForms: function(callback, scope) {
					const printMenuItems = this.Ext.create("BPMSoft.BaseViewModelCollection");
					this.set(this.moduleCardPrintFormsCollectionName, printMenuItems);
					if (callback) {
						callback.call(scope || this);
					}
				},

				/**
				 * @overridden
				 */
				onDiscardChangesClick: function() {
					this.sandbox.publish("BackHistoryState");
				},

				/**
				 * @overridden
				 */
				onCloseCardButtonClick: function() {
					this.sandbox.publish("BackHistoryState");
				},

				/**
				 * @protected
				 * @overridden
				 */
				initHeaderCaption: Ext.emptyFn,

				/**
				 * @protected
				 * @overridden
				 */
				initPrintButtonMenu: Ext.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BasePageV2#initContainersVisibility
				 * @overridden
				 */
				initContainersVisibility: function() {
					this.callParent(arguments);
					this.set("IsPageHeaderVisible", false);
				},

				/**
				 * @protected
				 * @overridden
				 */
				getHeader: function() {
					return this.get("Resources.Strings.HeaderCaption");
				},

				/**
				 * @protected
				 * @overridden
				 */
				init: function() {
					this.set("IsSeparateMode", true);
					this.callParent(arguments);
				},

				/**
				 * @protected
				 * @overridden
				 */
				save: function() {
					let resultDecisions = this.getResultDecisions();
					if (resultDecisions.length === 0 && this.get("isDecisionRequired") === true) {
						this.showInformationDialog(this.get("Resources.Strings.WarningMessage"));
						return false;
					}
					const processData = this.get("ProcessData") || {};
					processData.parameters = processData.parameters || {};
					resultDecisions = Ext.encode(resultDecisions);
					this.set("ResultDecisions", resultDecisions);
					Ext.apply(processData.parameters, {
						ResultDecisions: resultDecisions
					});
					this.acceptProcessElement();
				},

				/**
				 * ########## ######### ############# ######## #######
				 * @protected
				 */
				getResultDecisions: function() {
					const resultDecisions = [];
					const decisionOptions = this.get("decisionOptions");
					if (this.get("decisionMode") === 0) {
						const decisionName = this.get("radioButtonsGroup");
						BPMSoft.each(decisionOptions, function(decisionOption) {
							if (decisionOption.Name === decisionName) {
								resultDecisions.push(decisionOption.Id);
							}
						});
					} else {
						const scope = this;
						BPMSoft.each(decisionOptions, function(decisionOption) {
							const value = scope.get(decisionOption.Name.toString());
							if (value === true) {
								resultDecisions.push(decisionOption.Id);
							}
						});
					}
					return resultDecisions;
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#isChanged
				 * @override
				 */
				isChanged: function() {
					return this.isParametersChanged() || this.callParent(arguments);
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "SaveButton",
					"values": {
						"visible": true
					}
				}, {
					"operation": "merge",
					"name": "CloseButton",
					"values": {
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT_ORANGE,
						"visible": true
					}
				}, {
					"operation": "remove",
					"name": "actions"
				}, {
					"operation": "remove",
					"name": "back"
				}, {
					"operation": "remove",
					"name": "DiscardChangesButton"
				}, {
					"operation": "remove",
					"name": "Tabs"
				}, {
					"operation": "merge",
					"name": "ActionButtonsContainer",
					"values": {
						"visible": true
					}
				}, {
					"operation": "merge",
					"name": "actions",
					"values": {
						"visible": false
					}
				}, {
					"operation": "remove",
					"name": "BackButton"
				}, {
					"operation": "merge",
					"name": "DiscardChangesButton",
					"values": {
						"visible": true
					}
				}, {
					"operation": "remove",
					"name": "ViewOptionsButton"
				}, {
					"operation": "merge",
					"name": "HeaderCaptionContainer",
					"values": {
						"visible": true
					}
				}, {
					"operation": "remove",
					"name": "Header"
				}, {
					"operation": "insert",
					"name": "UserQuestionContentContainer",
					"parentName": "HeaderContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				}, {
					"operation": "insert",
					"parentName": "UserQuestionContentContainer",
					"propertyName": "items",
					"name": "UserQuestionContentBlock",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"operation": "merge",
					"name": "CloseButton",
					"values": {
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT
					}
				}
			]/**SCHEMA_DIFF*/,
			userCode: {}
		};
	});
