define("ProductPriceDetailV2", ["BusinessRuleModule", "RightUtilities"], function(BusinessRuleModule, RightUtilities) {
	return {
		entitySchemaName: "ProductPrice",
		attributes: {
			/**
			 * ####### #####-#### ## ######### #########
			 * @type {BPMSoft.DataValueType.LOOKUP}
			 */
			BasePriceList: {
				dataValueType: this.BPMSoft.DataValueType.LOOKUP,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * ####### ####### # ######### ####### ######## #####-#####
			 * @type {BPMSoft.DataValueType.BOOLEAN}
			 */
			HasBaseItem: {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN
			}
		},
		methods: {
			/**
			 * ############## ######### ######## ######
			 * @protected
			 * @virtual
			 * @overriden
			 */
			init: function() {
				BPMSoft.SysSettings.querySysSettingsItem("BasePriceList",
					function(value) {
						this.set("BasePriceList", value);
					}, this);
				this.callParent(arguments);
			},

			/**
			 * ######### ####### ##### ######### "########" #####-##### (############# # ######### #########)
			 * @protected
			 * @param {BPMSoft.Collection} items
			 * @returns {boolean}
			 */
			checkAndSetHasIsBaseInDeleteItems: function(items) {
				var hasIsBaseItem = false;
				var gridData = this.getGridData();
				if (gridData) {
					this.BPMSoft.each(items, function(itemKey) {
						var item = gridData.get(itemKey);
						var basePriceList = this.get("BasePriceList");
						var priceList = item.get("PriceList");
						hasIsBaseItem =
							(hasIsBaseItem || (basePriceList && priceList && (basePriceList.value === priceList.value)));
					}, this);
				}
				this.set("HasBaseItem", hasIsBaseItem);
			},

			/**
			 * ####### ########## ######
			 * @protected
			 * @overriden
			 */
			deleteRecords: function() {
				var items = this.getSelectedItems();
				if (!items || !items.length) {
					return;
				}
				this.checkAndSetHasIsBaseInDeleteItems(items);
				if (items.length === 1) {
					RightUtilities.checkCanDelete({
						schemaName: this.entitySchema.name,
						primaryColumnValue: items[0]
					}, this.deleteCallback, this);
				} else {
					RightUtilities.checkMultiCanDelete({
						schemaName: this.entitySchema.name,
						primaryColumnValues: items
					}, this.deleteCallback, this);
				}
			},

			/**
			 * ####### ######### ###### ######## #######
			 * @param {String} result
			 */
			deleteCallback: function(result) {
				if (result) {
					this.showInformationDialog(this.get("Resources.Strings." + result), function() {
					}, {
						style: this.BPMSoft.MessageBoxStyles.BLUE
					});
				} else {
					if (!this.get("HasBaseItem")) {
						this.showConfirmationDialog(this.get("Resources.Strings.DeleteConfirmationMessage"),
							function(returnCode) {
								if (returnCode === this.BPMSoft.MessageBoxButtons.YES.returnCode) {
									this.onDeleteAccept();
								}
							},
							[this.BPMSoft.MessageBoxButtons.YES.returnCode,
								this.BPMSoft.MessageBoxButtons.NO.returnCode],
							null);
					} else {
						this.showInformationDialog(this.get("Resources.Strings.DeleteHasIsBaseItemMessage"),
							function() {}, {style: this.BPMSoft.MessageBoxStyles.BLUE});
					}
				}
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilitiesV2#getFilterDefaultColumnName
			 * @overridden
			 */
			getFilterDefaultColumnName: function() {
				return "PriceList";
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "DataGrid",
				"values": {
					"primaryDisplayColumnName": "PriceList"
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
