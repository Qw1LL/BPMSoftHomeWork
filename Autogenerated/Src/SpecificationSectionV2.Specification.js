// D9 Team
define("SpecificationSectionV2", [],
	function() {
		return {
			entitySchemaName: "Specification",
			messages: {
				/**
				 * @message GetBackHistoryState
				 * ######## ####, #### ########## ##### ####### ## ###### #######
				 */
				"GetBackHistoryState": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			methods: {

				/**
				 * ############# ######## #######
				 * @protected
				 * @overriden
				 */
				init: function() {
					this.callParent(arguments);
					this.getBackHistoryState();
				},

				/**
				 * ######## ##### ### ######## ## ####### ## ###### "#####"
				 * # ######### # BackHistoryState.
				 * @protected
				 * @virtual
				 */
				getBackHistoryState: function() {
					var backHistoryState = this.sandbox.publish("GetBackHistoryState",
						null, ["SpecificationSectionV2"]);
					this.set("BackHistoryState", backHistoryState || null);
				},

				/**
				 * ########## ######### ###### "#######" ## ####### #### ### ######### ########
				 * @protected
				 * @returns {boolean} true, #### ###### ######
				 */
				isCloseButtonVisible: function() {
					return (this.get("BackHistoryState") != null);
				},

				/**
				 * ########## ############# ####### ## #########.
				 * ######, #########
				 * @protected
				 * @return {Object} ############# ####### ## #########.
				 */
				getDefaultDataViews: function() {
					var gridDataView = {
						name: "GridDataView",
						active: true,
						caption: this.getDefaultGridDataViewCaption(),
						icon: this.getDefaultGridDataViewIcon()
					};
					return {
						"GridDataView": gridDataView
					};
				},

				/**
				 * ############# ######### ########.
				 * @overriden
				 * @returns {string}
				 */
				getDefaultGridDataViewCaption: function() {
					return this.get("Resources.Strings.HeaderCaption");
				},

				/**
				 * ######### ###### ########### #####.
				 * ######## ###### ########### #####.
				 * @overriden
				 */
				initSeparateModeActionsButtonHeaderMenuItemCaption: function() {
					this.set("SeparateModeActionsButtonHeaderMenuItemCaption",
						this.get("Resources.Strings.ShortHeaderCaption"));
					this.set("IsIncludeInFolderButtonVisible", false);
				},

				/**
				 * ########## ###### ######### ######## ####### # ###### ########### #######.
				 * @protected
				 * @overridden
				 * @return {BPMSoft.BaseViewModelCollection} ########## ######### ######## ####### # ######
				 * ########### #######.
				 */
				getSectionActions: function() {
					var actionMenuItems = this.callParent(arguments);
					actionMenuItems.clear();
					return actionMenuItems;
				},

				/**
				 * ########## ##### ## ###### "#######". ####### ## ########## ########
				 * @protected
				 */
				onCloseSpecificationSectionButtonClick: function() {
					var backHistoryState = this.get("BackHistoryState");
					this.sandbox.publish("ReplaceHistoryState",
						{
							hash: backHistoryState
						});
				}

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"activeRowAction": {"bindTo": "onActiveRowAction"},
						"type": "tiled",
						"listedConfig": {
							"name": "DataGridListedConfig",
							"items": [
								{
									"name": "NameListedGridColumn",
									"bindTo": "Name",
									"type": BPMSoft.GridCellType.TEXT,
									"position": {"column": 1, "colSpan": 14}
								}
							]
						},
						"tiledConfig": {
							"name": "DataGridTiledConfig",
							"grid": {"columns": 24, "rows": 1},
							"items": [
								{
									"name": "NameTiledGridColumn",
									"bindTo": "Name",
									"type": BPMSoft.GridCellType.TEXT,
									"position": {"row": 1, "column": 1, "colSpan": 10},
									"captionConfig": {"visible": false}
								}
							]
						}
					}
				},
				{
					"operation": "remove",
					"name": "DataGridActiveRowCopyAction"
				},
				{
					"operation": "remove",
					"name": "SeparateModePrintButton"
				},
				{
					"operation": "remove",
					"name": "SeparateModeViewOptionsButton"
				},
				{
					"operation": "merge",
					"name": "DataGridActiveRowOpenAction",
					"parentName": "DataGrid",
					"propertyName": "activeRowActions",
					"values": {
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT
					}
				},
				{
					"operation": "remove",
					"name": "CombinedModePrintButton"
				},
				{
					"operation": "remove",
					"name": "CombinedModeViewOptionsButton"
				},
				{
					"operation": "insert",
					"name": "CloseCatalogueButton",
					"parentName": "SeparateModeActionButtonsLeftContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {"bindTo": "Resources.Strings.CloseButtonCaption"},
						"visible": {"bindTo": "isCloseButtonVisible"},
						"click": {"bindTo": "onCloseSpecificationSectionButtonClick"},
						"classes": {
							"textClass": ["actions-button-margin-right"],
							"wrapperClass": ["actions-button-margin-right"]
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
