define("OrderProductDetailV2", ["MoneyModule", "css!OrderPageV2Styles", "css!SummaryModuleV2"], function(MoneyModule) {
	return {
		entitySchemaName: "OrderProduct",
		messages: {
			/**
			 * @message GetOrderProductSummary
			 * Returns information of product summary.
			 */
			"GetOrderProductSummary": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message UpdateOrderProductSummary
			 * Update product summary.
			 */
			"UpdateOrderProductSummary": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message DiscardChanges
			 * Occurs when changes in the target object were canceled. Is used to update data items.
			 */
			"DiscardChanges": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message OnCurrencyChanged
			 * Message on order card currency changed.
			 */
			"OnCurrencyChanged": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
		attributes: {
			"IsCurrencyChanged": {
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			"RefreshAfterPageSavedConfig": {
				"dataValueType": this.BPMSoft.DataValueType.OBJECT,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			}
		},
		methods: {

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#init
			 * @overridden
			 */
			init: function() {
				this.callParent(arguments);
				this.set("MultiSelect", true);
				this.set("isCollapsed", false);
				this.set("SummaryLoaded", false);
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilitiesV2#addGridDataColumns
			 * @overridden
			 */
			addGridDataColumns: function(esq) {
				this.callParent(arguments);
				esq.addColumn("Currency.Division");
			},

			/**
			 * Recount grid amounts.
			 * @protected
			 */
			recountGridData: function() {
				var gridData = this.getGridData();
				var columns = ["Price", "Amount", "DiscountAmount", "TaxAmount", "TotalAmount"];
				this.BPMSoft.each(gridData.getItems(), function(row) {
					this.BPMSoft.each(columns, function(column) {
						MoneyModule.RecalcBaseValue.call(row, "CurrencyRate", column, "Primary" + column,
							row.get("Currency.Division"));
					}, this);
				}, this);
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#loadGridData
			 * @overridden
			 */
			loadGridData: function() {
				this.callParent(arguments);
				this.updateSummary();
			},

			/**
			 * Update summaries.
			 */
			updateSummary: function() {
				var summary = this.sandbox.publish("GetOrderProductSummary", null, [this.sandbox.id]);
				this.set("TotalCount", summary.count || 0);
				this.set("CurrencySymbol", summary.currency);
				this.set("TotalAmount", summary.amount);
				this.set("SummaryLoaded", Boolean(summary.currency));
			},

			/**
			 * Returns summary visibility.
			 * @return {Boolean} Summary visibility.
			 */
			getSummaryVisible: function() {
				return this.getToolsVisible() && this.get("SummaryLoaded");
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#subscribeSandboxEvents
			 * @overridden
			 */
			subscribeSandboxEvents: function() {
				this.callParent(arguments);
				this.sandbox.subscribe("UpdateOrderProductSummary", this.updateSummary, this, [this.sandbox.id]);
				this.sandbox.subscribe("DiscardChanges", this.updateSummary, this, [this.sandbox.id]);
				this.sandbox.subscribe("OnCurrencyChanged", this.onCurrencyChanged, this);
				this.sandbox.subscribe("RerenderDetail", function(config) {
					if (this.viewModel) {
						var renderTo = this.Ext.get(config.renderTo);
						if (renderTo) {
							if (this.view) {
								this.view.destroyed = true;
							}
							this.render(renderTo);
							return true;
						}
					}
				}, this, [this.sandbox.id]);
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilitiesV2#onDataChanged
			 * @overridden
			 */
			onDataChanged: function() {
				this.callParent(arguments);
				this.updateSummary();
				this.set("IsCurrencyChanged", false);
			},

			/**
			 * @inheritdoc BPMSoft.ConfigurationGridUtilities#saveRowChanges
			 * @overridden
			 */
			saveRowChanges: function(row) {
				if (row && this.getIsRowChanged(row)) {
					this.fireDetailChanged(null);
					this.updateSummary();
				}
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#updateDetail
			 * @overridden
			 */
			updateDetail: function(config) {
				if (!config.reloadAll) {
					this.fireDetailChanged({action: "reloadAll", rows: []});
					config.reloadAll = true;
				}
				this.callParent([config]);
			},

			/**
			 * Handles on card currency changed.
			 * @protected
			 */
			onCurrencyChanged: function() {
				var activeRow = this.getActiveRow();
				if (activeRow) {
					this.discardActiveRowChanges(function() {
						this.setActiveRow(null);
					}, this);
				}
				this.set("IsCurrencyChanged", true);
			},

			/**
			 * Handles grid row selection.
			 * @param {BPMSoft.BaseViewModel} row Selected row.
			 */
			onRowSelected: function(row) {
				this.applyCardCurrencyChanges(row);
			},

			/**
			 * Applies changes on card if currency was changed.
			 * @protected
			 * @param {BPMSoft.BaseViewModel} row Selected row.
			 */
			applyCardCurrencyChanges: function(row) {
				if (row === null) {
					return;
				}
				var isCurrencyChanged = this.get("IsCurrencyChanged");
				if (!isCurrencyChanged) {
					return;
				}
				var args = {
					messageTags: [this.sandbox.id]
				};
				this.sandbox.publish("SaveRecord", args, [this.sandbox.id]);
				this.setActiveRow(null);
			},

			/**
			 * @inheritDoc BPMSoft.BaseDetailV2#onCardSaved
			 * @override
			 */
			onCardSaved: function() {
				var currencyChanged = this.get("IsCurrencyChanged");
				if (currencyChanged) {
					this.set("IsCurrencyChanged", false);
					this.set("RefreshAfterPageSavedConfig", {callback: this.onCardSaved, scope: this});
					this.reloadGridData();
				} else {
					this.callParent(arguments);
				}
			},

			/**
			 * @inheritDoc BPMSoft.BaseDetailV2#onGridDataLoaded
			 * @override
			 */
			onGridDataLoaded: function() {
				this.callParent(arguments);
				this.recountGridData();
				var conf = this.get("RefreshAfterPageSavedConfig");
				if (conf) {
					this.set("RefreshAfterPageSavedConfig", null);
					if (this.Ext.isFunction(conf.callback)) {
						conf.callback.call(conf.scope || this);
					}
				}
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "Detail",
				"values": {"classes": {"wrapClass": ["detail", "grid-detail", "order-product-detail"]}}
			},
			{
				"operation": "insert",
				"name": "summaryItemsContainer",
				"propertyName": "tools",
				"parentName": "Detail",
				"values": {
					"id": "summaryItemContainer",
					"selectors": {"wrapEl": "#summaryItemContainer"},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["summary-item-container"],
					"visible": {"bindTo": "getSummaryVisible"},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "summaryCountCaption",
				"parentName": "summaryItemsContainer",
				"propertyName": "items",
				"values": {
					"caption": {"bindTo": "Resources.Strings.TotalCountCaption"},
					"itemType": BPMSoft.ViewItemType.LABEL,
					"classes": {"labelClass": ["summary-item-caption"]}
				}
			},
			{
				"operation": "insert",
				"name": "summaryCountValue",
				"parentName": "summaryItemsContainer",
				"propertyName": "items",
				"values": {
					"caption": {"bindTo": "TotalCount"},
					"markerValue": {"bindTo": "Resources.Strings.TotalCountCaption"},
					"itemType": BPMSoft.ViewItemType.LABEL,
					"classes": {"labelClass": ["summary-item-value"]}
				}
			},
			{
				"operation": "insert",
				"name": "summaryAmountCaption",
				"parentName": "summaryItemsContainer",
				"propertyName": "items",
				"values": {
					"caption": {"bindTo": "Resources.Strings.TotalAmountCaption"},
					"itemType": BPMSoft.ViewItemType.LABEL,
					"classes": {"labelClass": ["summary-item-caption"]}
				}
			},
			{
				"operation": "insert",
				"name": "summaryAmountCurrencySymbol",
				"parentName": "summaryItemsContainer",
				"propertyName": "items",
				"values": {
					"caption": {"bindTo": "CurrencySymbol"},
					"itemType": BPMSoft.ViewItemType.LABEL,
					"classes": {"labelClass": ["summary-item-value"]}
				}
			},
			{
				"operation": "insert",
				"name": "summaryAmountValue",
				"parentName": "summaryItemsContainer",
				"propertyName": "items",
				"values": {
					"caption": {
						bindTo: "TotalAmount",
						bindConfig: {converter: BPMSoft.getFormattedMoneyValue}
					},
					"markerValue": {"bindTo": "Resources.Strings.TotalAmountCaption"},
					"itemType": BPMSoft.ViewItemType.LABEL,
					"classes": {"labelClass": ["summary-item-value"]}
				}
			},
			{
				"operation": "merge",
				"name": "DataGrid",
				"values": {
					"selectRow": {"bindTo": "onRowSelected"}
				}
			},
			{
				"operation": "merge",
				"name": "ToolsButton",
				"values": {
					"generateId": false
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
