define("SupplyPaymentProductDetailModalBox", ["ConfigurationGrid", "ConfigurationGridGenerator",
		"ConfigurationGridUtilities", "css!SummaryModuleV2"], function() {
	return {
		entitySchemaName: "VwSupplyPaymentProduct",
		mixins: {
			ConfigurationGridUtilites: "BPMSoft.ConfigurationGridUtilities",
			GridUtilities: "BPMSoft.GridUtilities"
		},
		messages: {
			/**
			 * ############ ### ########## ####### ###### ####### ######## # #####.
			 */
			"ReloadSupplyPaymentGridData": {
				mode: this.BPMSoft.MessageMode.BROADCAST,
				direction: this.BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		attributes: {
			/**
			 * ####### ############### #######.
			 */
			IsEditable: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: true
			},

			/**
			 * ########### ###### ####.
			 */
			MinWidth: {
				dataValueType: BPMSoft.DataValueType.INTEGER,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: 820
			},

			/**
			 * ########### ###### ####.
			 */
			MinHeight: {
				dataValueType: BPMSoft.DataValueType.INTEGER,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: 50
			},

			/**
			 * ############ ###### ########## #######.
			 */
			MaxGridHeight: {
				dataValueType: BPMSoft.DataValueType.INTEGER,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: 450
			},

			/**
			 * ######## ######## #####.
			 */
			TotalAmount: {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: ""
			}
		},
		methods: {
			/**
			 * ############## ######### ###### ############# #######.
			 * @protected
			 * @param {Function} callback #######, ####### ##### ####### ##### #############.
			 * @param {Object} scope ######## ##########.
			 */
			initData: function(callback, scope) {
				this.set("Collection", this.Ext.create("BPMSoft.BaseViewModelCollection"));
				this.initGridRowViewModel(function() {
					this.initGridData();
					this.mixins.GridUtilities.init.call(this);
					this.loadGridData();
					callback.call(scope);
				}, this);
			},

			/**
			 * @inheritdoc BPMSoft.ConfigurationGridUtilities#getCellControlsConfig
			 * @overridden
			 */
			getCellControlsConfig: function(entitySchemaColumn) {
				var config = this.mixins.ConfigurationGridUtilites.getCellControlsConfig.apply(this, arguments);
				if (entitySchemaColumn.name === "MaxQuantity") {
					this.Ext.apply(config, {
						controlConfig: {
							tips: [{
								tip: {
									content: this.get("Resources.Strings.AvailableFieldHint"),
									displayMode: this.BPMSoft.TipDisplayMode.NARROW
								},
								settings: {
									alignEl: "disabledElIconEl"
								}
							}]
						}
					});
				}
				return config;
			},

			/**
			 * @inheritdoc BPMSoft.ConfigurationGridUtilities#getDefaultConfigurationGridItemSchemaName
			 * @overridden
			 */
			getDefaultConfigurationGridItemSchemaName: function() {
				return "SupplyPaymentProductPageV2";
			},

			/**
			 * ########## ######### #######.
			 * @protected
			 * @return {Object}
			 */
			getGridData: function() {
				return this.get("Collection");
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
			 * @overridden
			 */
			init: function(callback, scope) {
				this.initEditPages();
				this.callParent([function() {
					this.initData(function() {
						callback.call(scope);
					}, this);
				}, this]);
			},

			/**
			 * ######### ############# ######## ## ######### ### ###### ## #######.
			 * @protected
			 * @virtual
			 */
			initGridData: function() {
				this.set("ActiveRow", "");
				this.set("IsEditable", true);
				this.set("MultiSelect", false);
				this.set("IsPageable", false);
				this.set("IsClearGridData", false);
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilities#loadGridData
			 * @overridden
			 */
			loadGridData: function() {
				if (!this.get("IsDetailCollapsed") && !this.get("IsGridLoading")) {
					this.set("IsGridLoading", true);
					this.mixins.GridUtilities.loadGridData.call(this);
				}
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilities#getFilters
			 * @overridden
			 */
			getFilters: function() {
				var filters = this.mixins.GridUtilities.getFilters.call(this);
				if (filters) {
					var moduleInfo = this.getModuleInfo();
					var supplyPaymentElementId = moduleInfo && moduleInfo.supplyPaymentElementId;
					if (supplyPaymentElementId) {
						filters.add("supplyPaymentElementFilter",
							this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL, "SupplyPaymentElement", supplyPaymentElementId
							)
						);
					}
					var notDistributedFiltersGroup = this.Ext.create("BPMSoft.FilterGroup");
					notDistributedFiltersGroup.logicalOperation =  BPMSoft.LogicalOperatorType.OR;
					notDistributedFiltersGroup.add("isNotDistributedFilter",
						this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL, "IsDistributed", 0
						)
					);
					notDistributedFiltersGroup.add("usedQuantityMoreZeroFilter",
						this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.GREATER, "UsedQuantity", 0
						)
					);
					filters.add(notDistributedFiltersGroup);
				}
				return filters;
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilities#getGridDataColumns
			 * @overridden
			 */
			getGridDataColumns: function() {
				var gridDataColumns = this.mixins.GridUtilities.getGridDataColumns(arguments);
				var requiredColumns = {
					OrderProduct: {path: "OrderProduct"}
				};
				return Ext.apply(gridDataColumns, requiredColumns);
			},

			/**
			 * ############## ###### ######### ######### #######.
			 * @protected
			 * @param {Function} callback callback-#######.
			 * @param {Object} scope ######## ##########.
			 */
			initGridRowViewModel: function(callback, scope) {
				this.initEditableGridRowViewModel(callback, scope);
			},

			/**
			 * ######## ##########, ########## ### ######## ######.
			 * @protected
			 * @return {Object} ######, ############ ####### ### ######## ###### ########## ####.
			 */
			getModuleInfo: function() {
				return this.get("moduleInfo");
			},

			/**
			 * @inheritDoc BPMSoft.BaseSectionV2#getActiveRow
			 * @overridden
			 */
			getActiveRow: function() {
				var activeRow = null;
				var primaryColumnValue = this.get("ActiveRow");
				if (primaryColumnValue) {
					var gridData = this.getGridData();
					activeRow = gridData.find(primaryColumnValue) ? gridData.get(primaryColumnValue) : null;
				}
				return activeRow;
			},

			/**
			 * ######### ####### ########## #### ## ########### ###########.
			 * @private
			 * @return {Object} ######, ########## ########## # ###### # ###### ########## ####.
			 */
			getModalWindowSize: function() {
				var gridContainerEl = this.Ext.get("gridContainer");
				var fixedContainerEl = this.Ext.get("fixedAreaContainer");
				if (!gridContainerEl || !fixedContainerEl) {
					return null;
				}
				var totalHeight = fixedContainerEl.dom.clientHeight +
					Math.min(gridContainerEl.dom.clientHeight, this.get("MaxGridHeight")) + this.get("MinHeight")+20;
				return {
					width: this.get("MinWidth"),
					height: totalHeight
				};
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilities#onGridDataLoaded
			 * @overridden
			 */
			onGridDataLoaded: function() {
				this.mixins.GridUtilities.onGridDataLoaded.apply(this, arguments);
				this.recalculateTotalAmount();
				var modalWindowSize = this.getModalWindowSize();
				if (modalWindowSize) {
					this.updateSize(modalWindowSize.width, modalWindowSize.height);
				}
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilities#prepareResponseCollectionItem
			 * @overridden
			 */
			prepareResponseCollectionItem: function(item) {
				this.mixins.GridUtilities.prepareResponseCollectionItem.apply(this, arguments);
				item.on("change:UsedAmount", this.recalculateTotalAmount, this);
			},

			/**
			 * ######## ######## #####.
			 * @private
			 */
			recalculateTotalAmount: function() {
				var totalAmount = 0;
				var gridData = this.getGridData();
				gridData.each(function(row) {
					totalAmount += row.get("UsedAmount") || 0;
				}, this);
				this.set("TotalAmount", this.BPMSoft.getFormattedNumberValue(totalAmount));
			},

			/**
			 * ########## ########## # ######### # ########## ###########.
			 * @protected
			 * @return {Object} ########## # ######### # ########## ###########.
			 */
			getChangedProductData: function() {
				var data = this.getGridData();
				var productsInfo = {};
				var isAnyRowChanged = false;
				data.each(function(row) {
					if (row.isChanged()) {
						var quantity = row.get("UsedQuantity");
						if (quantity !== 0 && !Boolean(quantity)) {
							quantity = 0;
							row.set("UsedQuantity", quantity);
						}
						isAnyRowChanged = true;
						var orderProduct = row.get("OrderProduct");
						if (orderProduct && orderProduct.value) {
							productsInfo[orderProduct.value] = quantity;
						}
					}
				}, this);
				return {
					productsInfo: productsInfo,
					isAnyRowChanged: isAnyRowChanged
				};
			},

			/**
			 * ######### ######### ########## #########.
			 * @protected
			 */
			saveChanges: function() {
				var moduleInfo = this.getModuleInfo();
				var supplyPaymentElementId = moduleInfo && moduleInfo.supplyPaymentElementId;
				var changedProductData = this.getChangedProductData();
				if (supplyPaymentElementId && changedProductData.isAnyRowChanged) {
					this.set("okButtonMaskVisible", true);
					this.saveChangesOnServer({
						supplyPaymentElementId: supplyPaymentElementId,
						productsInfo: changedProductData.productsInfo,
						callback: function() {
							this.sandbox.publish("ReloadSupplyPaymentGridData");
							this.closeWindow();
						},
						scope: this
					});
				} else {
					this.closeWindow();
				}
			},

			/**
			 * ######### ######### ########## ######### # ##.
			 * @protected
			 * @param {Object} config ###### ### ############ ####### ########## ########## ######### ## ######.
			 * ######## ######### #########:
			 * @param {GUID} config.supplyPaymentElementId
			 *   ############# ######## #### ####### ######## # #####.
			 * @param {Object} config.productsInfo
			 *   ######, ########## ########## ## ########## ######### # ## ##### ##########.
			 * @param {Function} config.callback
			 *   #######, ####### ##### ####### ##### ######### ###### ## #######.
			 * @param {Object} config.scope
			 *   ######## ##########.
			 */
			saveChangesOnServer: function(config) {
				this.callService({
					serviceName: "OrderPassportService",
					methodName: "UpdateSupplyPaymentProducts",
					data: {
						"updateRequest": {
							"supplyPaymentElementId": config.supplyPaymentElementId,
							"productsData": this.BPMSoft.encode(config.productsInfo)
						}
					}
				}, function(response) {
					this.set("okButtonMaskVisible", false);
					var result = response.UpdateSupplyPaymentProductsResult || {};
					if (!result.success) {
						this.showInformationDialog(result.errorInfo.message);
						this.reloadGridData();
					} else {
						config.callback.call(config.scope);
					}
				}, this);
			},

			/**
			 * @inheritdoc BPMSoft.ConfigurationGridUtilities#onCtrlEnterKeyPressed
			 * @overridden
			 */
			onCtrlEnterKeyPressed: function() {
				var activeRow = this.getActiveRow();
				this.unfocusRowControls(activeRow);
				this.setActiveRow(null);
			},

			/**
			 * @inheritdoc BPMSoft.ConfigurationGridUtilities#onEnterKeyPressed
			 * @overridden
			 */
			onEnterKeyPressed: function() {
				var activeRow = this.getActiveRow();
				this.unfocusRowControls(activeRow);
			},

			/**
			 * @inheritdoc BPMSoft.ConfigurationGridUtilities#onTabKeyPressed
			 * @overridden
			 */
			onTabKeyPressed: function() {
				var activeRow = this.getActiveRow();
				this.currentActiveColumnName = this.getCurrentActiveColumnName(activeRow, this.columnsConfig);
				return true;
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#onRender
			 * @overridden
			 */
			onRender: function() {
				var modalBoxInnerBoxEl = this.Ext.get(this.renderTo);
				if (modalBoxInnerBoxEl && this.Ext.isFunction(modalBoxInnerBoxEl.parent)) {
					var modalBoxEl = modalBoxInnerBoxEl.parent();
					if (modalBoxEl) {
						modalBoxEl.addCls("supply-payment-products-modal-box");
					}
				}
				this.updateSize(this.get("MinWidth"), this.get("MinHeight") + 50);
			},

			/**
			 * ########### ### ######## ########## ####.
			 * @protected
			 */
			closeWindow: function() {
				this.destroyModule();
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "gridContainer",
				"index": 0,
				"propertyName": "items",
				"values": {
					"id": "gridContainer",
					"selectors": {"wrapEl": "#gridContainer"},
					"wrapClass": ["grid-container"],
					"markerValue": "supplyPaymentGridContainer",
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "DataGrid",
				"parentName": "gridContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID,
					"className": "BPMSoft.ConfigurationGrid",
					"generator": "ConfigurationGridGenerator.generatePartial",
					"generateControlsConfig": {"bindTo": "generateActiveRowControlsConfig"},
					"multiSelect": false,
					"rowDataItemMarkerColumnName": "OrderProduct",
					"unSelectRow": {"bindTo": "unSelectRow"},
					"onGridClick": {"bindTo": "onGridClick"},
					"listedZebra": true,
					"initActiveRowKeyMap": {"bindTo": "initActiveRowKeyMap"},
					"collection": {"bindTo": "Collection"},
					"activeRow": {"bindTo": "ActiveRow"},
					"primaryColumnName": "Id",
					"isEmpty": {"bindTo": "IsGridEmpty"},
					"isLoading": {"bindTo": "IsGridLoading"},
					"selectedRows": {"bindTo": "SelectedRows"},
					"type": "listed",
					"listedConfig": {
						"name": "DataGridListedConfig",
						"items": [
							{
								"name": "OrderProductListedGridColumn",
								"bindTo": "OrderProduct",
								"position": {"column": 1, "colSpan": 11}
							},
							{
								"name": "UsedQuantityListedGridColumn",
								"bindTo": "UsedQuantity",
								"position": {"column": 13, "colSpan": 4}
							},
							{
								"name": "MaxQuantityListedGridColumn",
								"bindTo": "MaxQuantity",
								"position": {"column": 17, "colSpan": 4}
							},
							{
								"name": "UsedAmountListedGridColumn",
								"bindTo": "UsedAmount",
								"position": {"column": 21, "colSpan": 4}
							}
						]
					},
					"tiledConfig": {
						"name": "DataGridTiledConfig",
						"grid": {"columns": 24, "rows": 1},
						"items": [
							{
								"name": "OrderProductTiledGridColumn",
								"bindTo": "OrderProduct",
								"position": {"row": 1, "column": 1, "colSpan": 11}
							},
							{
								"name": "UsedQuantityTiledGridColumn",
								"bindTo": "UsedQuantity",
								"position": {"row": 1, "column": 13, "colSpan": 4}
							},
							{
								"name": "MaxQuantityTiledGridColumn",
								"bindTo": "MaxQuantity",
								"position": {"row": 1, "column": 17, "colSpan": 4}
							},
							{
								"name": "UsedAmountTiledGridColumn",
								"bindTo": "UsedAmount",
								"position": {"row": 1, "column": 21, "colSpan": 4}
							}
						]
					}
				}
			},
			{
				"operation": "insert",
				"name": "ButtonContainer",
				"parentName": "gridContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "okButton",
				"parentName": "ButtonContainer",
				"propertyName": "items",
				"values": {
					"caption": {"bindTo": "Resources.Strings.OKButtonCaption"},
					"click": {"bindTo": "saveChanges"},
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
					"maskVisible": {"bindTo": "okButtonMaskVisible"},
					"markerValue": "ButtonOK"
				}
			},
			{
				"operation": "insert",
				"name": "cancelButton",
				"parentName": "ButtonContainer",
				"propertyName": "items",
				"values": {
					"caption": {"bindTo": "Resources.Strings.CancelButtonCaption"},
					"click": {"bindTo": "closeWindow"},
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
					"markerValue": "ButtonCancel"
				}
			},
			{
				"operation": "insert",
				"name": "fixedAreaContainer",
				"index": 1,
				"values": {
					"id": "fixedAreaContainer",
					"selectors": {"wrapEl": "#fixedAreaContainer"},
					"wrapClass": ["fixed-area-container"],
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"name": "headContainer",
				"parentName": "fixedAreaContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["header"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "headContainer",
				"propertyName": "items",
				"name": "headerNameContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["header-name-container", "header-name-container-full"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "headContainer",
				"propertyName": "items",
				"name": "closeIconContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["header-name-container", "header-name-container-full"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "closeIconButton",
				"parentName": "closeIconContainer",
				"propertyName": "items",
				"values": {
					"click": {"bindTo": "closeWindow"},
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"hint": {"bindTo": "Resources.Strings.CloseButtonHint"},
					"imageConfig": {"bindTo": "Resources.Images.CloseIcon"},
					"markerValue": "CloseIconButton",
					"classes": {"wrapperClass": ["close-btn-user-class"]},
					"selectors": {"wrapEl": "#headContainer"}
				}
			},
			{
				"operation": "insert",
				"parentName": "headerNameContainer",
				"propertyName": "items",
				"name": "HeaderLabel",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": {"bindTo": "Resources.Strings.HeaderCaption"}
				}
			},
			{
				"operation": "insert",
				"parentName": "headerNameContainer",
				"propertyName": "items",
				"name": "HeaderLabelInfoButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
					"content": {"bindTo": "Resources.Strings.HeaderTip"}
				}
			},
			{
				"operation": "insert",
				"name": "buttonsContainer",
				"parentName": "fixedAreaContainer",
				"propertyName": "items",
				"values": {
					"id": "buttonsContainer",
					"selectors": {"wrapEl": "#buttonsContainer"},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "summaryItemContainer",
				"propertyName": "items",
				"parentName": "buttonsContainer",
				"values": {
					"id": "summaryItemContainer",
					"selectors": {"wrapEl": "#summaryItemContainer"},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["summary-item-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "summaryItemCaption",
				"parentName": "summaryItemContainer",
				"propertyName": "items",
				"values": {
					"caption": {"bindTo": "Resources.Strings.TotalAmountCaption"},
					"itemType": BPMSoft.ViewItemType.LABEL,
					"classes": {
						"labelClass": ["summary-item-caption"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "summaryItemValue",
				"parentName": "summaryItemContainer",
				"propertyName": "items",
				"values": {
					"caption": {"bindTo": "TotalAmount"},
					"itemType": BPMSoft.ViewItemType.LABEL,
					"classes": {
						"labelClass": ["summary-item-value"]
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
