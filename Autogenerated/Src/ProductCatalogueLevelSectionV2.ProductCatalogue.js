// D9 Team
define("ProductCatalogueLevelSectionV2", ["LocalizableHelper", "ServiceHelper"],
		function(LocalizableHelper, ServiceHelper) {
			return {
				entitySchemaName: "ProductCatalogueLevel",
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
						var backHistoryState = this.sandbox.publish("GetBackHistoryState",
								null, ["ProductCatalogueLevelSectionV2"]);
						this.set("BackHistoryState", backHistoryState || null);
					},

					/**
					 * ########## ######### ###### "#######" ## ####### #### ### ######### ########
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
					 * ##### ######### ######## ### ########## ####### # ############ ## tag.
					 * @private
					 */
					onActiveRowAction: function(tag, id) {
						if (tag === "delete" || tag === "edit") {
							this.callParent(arguments);
						} else {
							var gridData = this.getGridData();
							var activeRow = gridData.get(id);
							var position = activeRow.get("Position");
							if (tag === "up") {
								if (position > 0) {
									position--;
								}
							}
							if (tag === "down") {
								position++;
							}
							this.setPosition(id, position, function() {
								gridData.clear();
								this.loadGridData();
							}, this);
						}
					},

					/**
					 * ######## #######, ####### ###### ########## ########.
					 * @protected
					 * @overridden
					 * @return {Object} ########## #######, ####### ###### ########## ########.
					 */
					getGridDataColumns: function() {
						var gridDataColumns = this.callParent(arguments);
						if (gridDataColumns && !gridDataColumns.Position) {
							gridDataColumns.Position = {
								path: "Position",
								orderPosition: 0,
								orderDirection: BPMSoft.OrderDirection.ASC
							};
						}
						return gridDataColumns;
					},

					/**
					 * ##### ############# ########## ######## ####### position.
					 * @private
					 * @param {String} recordId ############# ######.
					 * @param {Number} position ##### #######.
					 * @param {Function} callback ####### ######### ######.
					 * @param {Object} scope ######## ########## callback.
					 */
					setPosition: function(recordId, position, callback, scope) {
						var data = {
							tableName: this.entitySchemaName,
							primaryColumnValue: recordId,
							position: position,
							grouppingColumnNames: ""
						};
						ServiceHelper.callService("RightsService", "SetCustomRecordPosition", callback, data, scope);
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
					 * ############# ######## ## ######### ########## ######## ##############.
					 * @protected
					 * @overriden
					 */
					initCardModuleResponseSubscription: function() {
						var editCardsSandboxIds = [];
						var editPages = this.get("EditPages");
						editPages.each(function(editPage) {
							var editCardsSandboxId = this.getChainCardModuleSandboxId(editPage.get("Tag"));
							editCardsSandboxIds.push(editCardsSandboxId);
						}, this);
						editCardsSandboxIds.push(this.getCardModuleSandboxId());
						this.sandbox.subscribe("CardModuleResponse", function() {
							var gridData = this.getGridData();
							gridData.clear();
							this.loadGridData();
						}, this, editCardsSandboxIds);
					},

					/**
					 * ########## ##### ## ###### "#######". ####### ## ########## ########
					 * @protected
					 */
					onCloseCatalogueButtonClick: function() {
						var backHistoryState = this.get("BackHistoryState");
						this.sandbox.publish("ReplaceHistoryState", {
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
						"operation": "insert",
						"name": "DataGridActiveRowMoveUpAction",
						"parentName": "DataGrid",
						"propertyName": "activeRowActions",
						"values": {
							"className": "BPMSoft.Button",
							"hint": LocalizableHelper.localizableStrings.UpButtonHint,
							"caption": LocalizableHelper.localizableStrings.UpButtonHint,
							"tag": "up"
						}
					},
					{
						"operation": "insert",
						"name": "DataGridActiveRowMoveDownAction",
						"parentName": "DataGrid",
						"propertyName": "activeRowActions",
						"values": {
							"className": "BPMSoft.Button",
							"hint": LocalizableHelper.localizableStrings.DownButtonHint,
							"caption": LocalizableHelper.localizableStrings.DownButtonHint,
							"tag": "down"
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
							"style": BPMSoft.controls.ButtonEnums.style.ORANGE
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
							"click": {"bindTo": "onCloseCatalogueButtonClick"},
							"classes": {
								"textClass": ["actions-button-margin-right"],
								"wrapperClass": ["actions-button-margin-right"]
							}
						}
					}
				]/**SCHEMA_DIFF*/
			};
		});
