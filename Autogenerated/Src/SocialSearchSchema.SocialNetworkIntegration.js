define([],
	function() {
		return {
			/**
			 * #########, ########### ### ########## ############ ############ #####
			 * @type {Object}
			 */
			messages: {
				/**
				 * ########## ######### ####### ChangeHeaderCaption
				 */
				"NeedHeaderCaption": {
					mode: BPMSoft.MessageMode.BROADCAST,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 *
				 */
				"ChangeHeaderCaption": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 *
				 */
				"BackHistoryState": {
					mode: BPMSoft.MessageMode.BROADCAST,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 *
				 */
				"SetInitialisationData": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message ResultSelectedRows
				 * ########## ######### ###### # ###########.
				 */
				"ResultSelectedRows": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message SearchResultBySocialNetworks
				 * ########## ######### ###### ## ########## #####.
				 */
				"SearchResultBySocialNetworks": {
					mode: BPMSoft.MessageMode.BROADCAST,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},

			/**
			 * ######## ###### ############# #######
			 * @type {Object}
			 */
			attributes: {
				/**
				 * ######### ###### ### ############# ######.
				 */
				"GridData": {dataValueType: BPMSoft.DataValueType.COLLECTION},

				/**
				 * ####### ######### ######## "######### #####".
				 */
				"IsSummarySettingsVisible": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					value: false
				},

				/**
				 * ############# ######## ###### # #######.
				 */
				"ActiveRow": {
					dataValueType: BPMSoft.DataValueType.STRING,
					value: null
				},

				/**
				 * ###### ############### ######### ####### # #######.
				 */
				"SelectedRows": {
					dataValueType: BPMSoft.DataValueType.COLLECTION
				}
			},

			/**
			 * ######-####### (#######), ########### ################ ####### #####
			 */
			mixins: {},

			methods: {
				/**
				 * @inheritdoc BPMSoft.BaseSchemaModule#init
				 * @overridden
				 */
				init: function(callback, scope) {
					this.callParent([function() {
						this.subscribeSandboxEvents();
						callback.call(scope);
					}, this]);
					this.initSelectedRows();
				},

				/**
				 * ############## ######### ###### # #######.
				 * @protected
				 */
				initSelectedRows: function() {
					this.set("SelectedRows", []);
				},

				/**
				 * ############## ######### ########.
				 * @protected
				 */
				initMainHeaderCaption: function() {
					var caption = this.get("Resources.Strings.HeaderCaption");
					this.sandbox.publish("ChangeHeaderCaption", {
						caption: caption,
						dataViews: new BPMSoft.Collection(),
						moduleName: this.name
					});
				},

				/**
				 * @inheritdoc BPMSoft.BasePage#subscribeSandboxEvents
				 * @overridden
				 */
				subscribeSandboxEvents: function() {
					this.sandbox.subscribe("NeedHeaderCaption", function() {
						this.initMainHeaderCaption();
					}, this);
				},

				/**
				 * ########## ####### ####### ## ###### ######.
				 */
				onCloseButtonClick: function() {
					this.sandbox.publish("BackHistoryState");
				},

				/**
				 * @inheritdoc BPMSoft.BasePage#onRender
				 * @overridden
				 */
				onRender: function() {
					this.initMainHeaderCaption();
				},

				search: BPMSoft.emptyFn,

				clear: BPMSoft.emptyFn,

				/**
				 * ########## ####### ###### #######.
				 */
				onSelectButtonClick: function() {
					var selectedItems = this.getSelectedItems();
					var config = {
						selectedItems: selectedItems
					};
					this.sandbox.publish("SearchResultBySocialNetworks", config);
					this.sandbox.publish("BackHistoryState");
				},

				/**
				 * ########## ######### / ######## ###### # #######.
				 * @protected
				 * @return {Object} ###### #######.
				 */
				getSelectedItems: BPMSoft.emptyFn,

				/**
				 * ########## ########### ###### #######.
				 * @protected
				 * @return {Boolean} ########### ###### #######.
				 */
				getSelectButtonEnabled: BPMSoft.emptyFn
			},

			diff: /**SCHEMA_DIFF*/[
//				SectionWrapContainer
				{
					"operation": "insert",
					"name": "SectionWrapContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["section-wrap"],
						"items": []
					}
				},
//				ActionButtonsContainer
				{
					"operation": "insert",
					"name": "ActionButtonsContainer",
					"parentName": "SectionWrapContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"id": "ActionButtonsContainer",
						"selectors": {"wrapEl": "#ActionButtonsContainer"},
						"wrapClass": ["action-buttons-container-wrapClass", "actions-container"],
						"items": []
					}
				},
//				ActionButtonsLeftContainer
				{
					"operation": "insert",
					"name": "ActionButtonsLeftContainer",
					"parentName": "ActionButtonsContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["action-buttons-left-container-wrapClass"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "SelectButton",
					"parentName": "ActionButtonsLeftContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {"bindTo": "Resources.Strings.SelectButtonCaption"},
						"click": {"bindTo": "onSelectButtonClick"},
						"enabled": {"bindTo": "getSelectButtonEnabled"},
						"classes": {
							"textClass": ["actions-button-margin-right", "t-btn-style-green"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "CloseButton",
					"parentName": "ActionButtonsLeftContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
						"caption": {"bindTo": "Resources.Strings.CloseButtonCaption"},
						"click": {"bindTo": "onCloseButtonClick"},
						"classes": {
							"textClass": ["actions-button-margin-right"]
						}
					}
				},
//				ContentContainer
				{
					"operation": "insert",
					"name": "ContentContainer",
					"parentName": "SectionWrapContainer",
					"propertyName": "items",
					"values": {
						"id": "ContentContainer",
						"selectors": {"wrapEl": "#ContentContainer"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["content-container-wrapClass", "content-container"],
						"items": []
					}
				},
//				SocialSearchContainer
				{
					"operation": "insert",
					"name": "SocialSearchContainer",
					"parentName": "ContentContainer",
					"propertyName": "items",
					"values": {
						"id": "SocialSearchContainer",
						"selectors": {"wrapEl": "#SocialSearchContainer"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["social-search-wrapClass"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "QueryContainer",
					"parentName": "SocialSearchContainer",
					"propertyName": "items",
					"values": {
						"id": "QueryContainer",
						"selectors": {"wrapEl": "#QueryContainer"},
						"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
						"wrapClass": ["social-search-query-container"],
						"isHeaderVisible": false,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "QueryInputContainer",
					"parentName": "QueryContainer",
					"propertyName": "items",
					"values": {
						"id": "QueryInputContainer",
						"selectors": {"wrapEl": "#QueryInputContainer"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["social-search-query-input-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "Query",
					"parentName": "QueryInputContainer",
					"propertyName": "items",
					"values": {
						"dataValueType": BPMSoft.DataValueType.TEXT,
						"labelConfig": {
							"caption": "Query",
							"visible": false
						},
						"markerValue": "SocialSearchQuery",
						"classes": {
							"wrapClass": ["social-search-query-input"]
						},
						"controlConfig": {
							"className": "BPMSoft.TextEdit",
							"enterkeypressed": {"bindTo": "search"}
						}
					}
				},
				{
					"operation": "insert",
					"name": "SearchTooltipButton",
					"parentName": "QueryContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
						"content": {
							"bindTo": "Resources.Strings.SearchTooltip"
						},
						"behaviour": {
							"displayEvent": BPMSoft.TipDisplayEvent.HOVER
						},
						"controlConfig": {
							"classes": {
								"wrapperClass": "webform-info-button-control-group info-button",
								"imageClass": "webform-info-button-image"
							}
						}
					}
				},
				{
					"operation": "insert",
					"name": "SearchButton",
					"parentName": "QueryContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
						"caption": {"bindTo": "Resources.Strings.SearchButtonCaption"},
						"click": {bindTo: "search"},
						"classes": {
							"textClass": ["actions-button-margin-right", "search-button"]
						}
					}
				},
//				SocialSearchResultContainer
				{
					"operation": "insert",
					"name": "SocialSearchResultContainer",
					"parentName": "SocialSearchContainer",
					"propertyName": "items",
					"values": {
						"id": "SocialSearchResultContainer",
						"selectors": {"wrapEl": "#SocialSearchResultContainer"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["social-search-result-container-wrapClass"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "SocialSearchResultControlGroup",
					"parentName": "SocialSearchResultContainer",
					"propertyName": "items",
					"values": {
						"id": "SocialSearchResultControlGroup",
						"selectors": {"wrapEl": "#SocialSearchResultControlGroup"},
						"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
						"caption": {bindTo: "Resources.Strings.SearchResultContainerCaption"},
						"wrapClass": ["detail"],
						"items": [],
						"tools": []
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
