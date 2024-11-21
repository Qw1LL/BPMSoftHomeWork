define("SysWorkplaceSectionV2", ["LocalizableHelper", "ServiceHelper", "ConfigurationEnums",
	"SysWorkplaceSectionGridRowViewModel", "SysWorkplaceUtilitiesModuleV2", "css!SysWorkplaceUtilitiesModuleV2",
	"SystemOperationsPermissionsMixin"],
function(LocalizableHelper, ServiceHelper, ConfigurationEnums) {
	return {
		entitySchemaName: "SysWorkplace",

		messages: {
			"RefreshWorkplace": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.PUBLISH
			}
		},

		mixins: {
			/**
			 * @class SystemOperationsPermissionsMixin
			 * System operations permissions mixin.
			 */
			SystemOperationsPermissionsMixin: "BPMSoft.SystemOperationsPermissionsMixin"
		},

		attributes: {
			"SecurityOperationName": {
				"dataValueType": this.BPMSoft.DataValueType.STRING,
				"value": "CanManageWorkplaceSettings"
			},

			/**
			 * List of typed workplaces edit pages.
			 */
			"WorkplaceTypedPages": {
				"dataValueType": BPMSoft.DataValueType.COLLECTION
			}
		},

		methods: {

			/**
			 * @overridden
			 */
			getGridRowViewModelClassName: function() {
				return "BPMSoft.SysWorkplaceSectionGridRowViewModel";
			},

			/**
			* ########## ############# ####### ## #########.
			* ######, #########
			* @protected
			* @return {Object} ############# ####### ## #########
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
			* @override
			* @returns {string}
			*/
			getDefaultGridDataViewCaption: function() {
				return this.get("Resources.Strings.HeaderCaption");
			},

			/**
			 * @override
			 */
			initSeparateModeActionsButtonHeaderMenuItemCaption: function() {
				this.set("SeparateModeActionsButtonHeaderMenuItemCaption", this.get("Resources.Strings.HeaderCaption"));
				this.set("IsIncludeInFolderButtonVisible", false);
			},

			/**
			 * ##### ######### ######## ### ########## ####### # ############ ## tag
			 * @private
			 */
			onActiveRowAction: function(tag, id) {
				if (tag === "delete" || tag === "edit") {
					this.callParent(arguments);
				} else {
					var gridData = this.getGridData();
					var activeRow = gridData.get(id);
					var position = activeRow.get("Position");
					if (tag === "up" && position > 0) {
						position--;
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
			 * ######## #######, ####### ###### ########## ########
			 * @protected
			 * @overridden
			 * @return {Object} ########## #######, ####### ###### ########## ########
			 */
			getGridDataColumns: function() {
				var gridDataColumns = this.callParent(arguments);
				if (!gridDataColumns.Position) {
					gridDataColumns.Position = {
						path: "Position",
						orderPosition: 0,
						orderDirection: BPMSoft.OrderDirection.ASC
					};
				}
				return gridDataColumns;
			},

			/**
			 * ############# ####### ######.
			 * @protected
			 * @virtual
			 * @param {String} recordId ########## ############# ######.
			 * @param {Number} position ##### ####### ######.
			 * @param {Function} callback #######, ####### ##### ####### ## ##########.
			 * @param {Object} scope ########, # ####### ##### ####### ####### callback.
			 */
			setPosition: function(recordId, position, callback, scope) {
				if (this.get("CanManageWorkplaceSettings") === true) {
					var data = {
						tableName: this.entitySchemaName,
						primaryColumnValue: recordId,
						position: position,
						grouppingColumnNames: ""
					};
					ServiceHelper.callService("RightsService", "SetCustomRecordPosition", callback, data, scope);
				}
				else
					this.showPermissionsErrorMessage("CanManageWorkplaceSettings");
			},

			/**
			* ######### ######## ########### ##### ########### ########.
			* @protected
			* @overridden
			*/
			onRender: function() {
				if (!this.get("Restored")) {
					this.loadActiveViewData();
				}
				this.callParent(arguments);
			},

			/**
			 * @inheritDoc BasePageV2#init
			 * @overridden
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this.initWorkplaceTypes(callback, scope);
				}, this]);
			},

			/**
			 * Initialize types of workplaces and corresponding edit pages.
			 * @param {Function} callback Callback method on init complete.
			 * @param {Object} scope Callback scope.
			 */
			initWorkplaceTypes: function(callback, scope) {
				this.$WorkplaceTypedPages = this.Ext.create("BPMSoft.BaseViewModelCollection");
				const workplacesEsq = this._getWorkplaceTypesEsq();
				workplacesEsq.getEntityCollection(function(result) {
					if (result.success) {
						result.collection.each(function(item) {
							this.$WorkplaceTypedPages.addItem(this._getEditPagesMenuItem(item));
						}, this);
					}
					this.Ext.callback(callback, scope);
				}, this);
			},

			_getWorkplaceTypesEsq: function() {
				const select = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "SysWorkplaceType"
				});
				select.addColumn("Id");
				select.addColumn("Name");
				select.addColumn("Code");
				return select;
			},

			/**
			 * get edit page button config.
			 * @returns {BPMSoft.BaseViewModel}
			 * @private
			 */
			_getEditPagesMenuItem: function(workplacesQueryResultItem) {
				return this.Ext.create("BPMSoft.BaseViewModel", {
					values: {
						Click: {"bindTo": "addNewWorkplace"},
						Caption: workplacesQueryResultItem.$Name,
						Tag: {
							TypeId: workplacesQueryResultItem.$Id,
							TypeCode: workplacesQueryResultItem.$Code
						},
						MarkerValue: workplacesQueryResultItem.$Name
					}
				});
			},

			/**
			 * Add new typed workplace.
			 * @param {Object} tag Button tag for typed pages.
			 */
			addNewWorkplace: function(tag) {
				const schemaName = this.getEditPageSchemaName();
				this.openCardInChain({
					schemaName: schemaName,
					operation: ConfigurationEnums.CardStateV2.ADD,
					moduleId: this.getChainCardModuleSandboxId(this.BPMSoft.GUID_EMPTY),
					defaultValues: [
						{
							name: "Type",
							value: tag.TypeId
						}, {
							name: "Code",
							value: tag.TypeCode
					}]
				});
			}

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "DataGrid",
				"values": {
					"activeRowAction": {bindTo: "onActiveRowAction"},
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
					},
					"sortColumnIndex": null
				}
			},
			{
				"operation": "merge",
				"name": "DataViewsContainer",
				"values": {
					"wrapClass": ["workplace-data-views-container-wrapClass", "data-views-container-wrapClass"]
				}
			},
			{
				"operation": "insert",
				"name": "DataGridActiveRowMoveUpAction",
				"parentName": "DataGrid",
				"propertyName": "activeRowActions",
				"values": {
					"className": "BPMSoft.Button",
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
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
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
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
				"name": "LeftGridUtilsContainer"
			},
			{
				"operation": "merge",
				"name": "DataGridActiveRowOpenAction",
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
				"operation": "remove",
				"name": "SeparateModeViewOptionsButton"
			},
			{
				"operation": "remove",
				"name": "SeparateModeActionsButton"
			},
			{
				"operation": "remove",
				"name": "FiltersContainer"
			},
			{
				"operation": "merge",
				"name": "SeparateModeAddRecordButton",
				"parentName": "SeparateModeActionButtonsLeftContainer",
				"propertyName": "items",
				"values": {
					"visible": {
						"bindTo": "IsAddRecordButtonVisible",
						"bindConfig": {
							"converter": function(value) {
								return value && this.getIsFeatureDisabled("UseTypedWorkplaces");
							}
						}
					}
				}
			},
			{
				"operation": "insert",
				"name": "SeparateModeAddTypedRecordButton",
				"parentName": "SeparateModeActionButtonsLeftContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
					"caption": {"bindTo": "AddRecordButtonCaption"},
					"visible": {
						"bindTo": "IsAddRecordButtonVisible",
						"bindConfig": {
							"converter": function(value) {
								return value && this.getIsFeatureEnabled("UseTypedWorkplaces");
							}
						}
					},
					"classes": {
						"textClass": ["actions-button-margin-right"],
						"wrapperClass": ["actions-button-margin-right"]
					},
					"controlConfig": {
						"menu": {
							"items": {
								"bindTo": "WorkplaceTypedPages"
							}
						}
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
