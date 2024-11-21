define("SiteEventAttributeSectionV2", [],
	function() {
		return {
			entitySchemaName: "SiteEventAttribute",
			methods: {
				/**
				 * ########## ######### ###### "#######" ## ####### #### ### ######### ########.
				 * @protected
				 * @returns {boolean} true, #### ###### ######.
				 */
				isCloseButtonVisible: function() {
					return true;
				},

				/**
				 * ########## ############# ####### ## #########.
				 * ######, #########.
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
					if(actionMenuItems) {
						actionMenuItems.clear();
					}
					return actionMenuItems;
				},

				/**
				 * ########## ##### ## ###### "#######". ####### ## ########## ########.
				 * @protected
				 */
				onCloseAttributeSectionButtonClick: function() {
					this.sandbox.publish("BackHistoryState");
				}

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"activeRowAction": { "bindTo": "onActiveRowAction"},
						"type": "tiled",
						"listedConfig": {
							"name": "DataGridListedConfig",
							"items": [
								{
									"name": "NameListedGridColumn",
									"bindTo": "Name",
									"type": BPMSoft.GridCellType.TEXT,
									"position": { "column": 1, "colSpan": 14 }
								}
							]
						},
						"tiledConfig": {
							"name": "DataGridTiledConfig",
							"grid": { "columns": 24, "rows": 1},
							"items": [
								{
									"name": "NameTiledGridColumn",
									"bindTo": "Name",
									"type": BPMSoft.GridCellType.TEXT,
									"position": { "row": 1, "column": 1, "colSpan": 10 },
									"captionConfig": { "visible": false }
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
					"name": "CloseButton",
					"parentName": "SeparateModeActionButtonsLeftContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": { "bindTo": "Resources.Strings.CloseButtonCaption" },
						"visible": { "bindTo" : "isCloseButtonVisible" },
						"click": { "bindTo": "onCloseAttributeSectionButtonClick" },
						"classes": {
							"textClass": ["actions-button-margin-right"],
							"wrapperClass": ["actions-button-margin-right"]
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
