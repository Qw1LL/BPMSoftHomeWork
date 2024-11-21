define("LeadProductDetailV2", ["ConfigurationEnums"],
	function(configurationEnums) {
		return {
			entitySchemaName: "LeadProduct",
			methods: {
				/**
				 * ########## #######, ####### ###### ########## ########
				 * @return {Object} ########## ###### ########-############ #######
				 */
				getGridDataColumns: function() {
					return {
						"Id": {path: "Id"},
						"Product": {path: "Product"},
						"Product.Name": {path: "Product.Name"}
					};
				},

				/**
				 * Returns lookup config for product entity.
				 * @protected
				 * @virtual
				 * @return {Object} Lookup config.
				 */
				getProductLookupConfig: function() {
					var config = {
						entitySchemaName: "Product",
						multiSelect: true,
						columns: ["Name", "Price", "Currency"],
						filters: this.BPMSoft.createFilterGroup()
					};
					return config;
				},

				/**
				 * ######### ########## #########
				 * @private
				 */
				openProductLookup: function() {
					var config = this.getProductLookupConfig();
					var leadId = this.get("MasterRecordId");
					if (this.Ext.isEmpty(leadId)) {
						return;
					}
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: this.entitySchemaName
					});
					esq.addColumn("Id");
					esq.addColumn("Product.Id", "ProductId");
					esq.filters.add("filterLead", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Lead", leadId));
					esq.getEntityCollection(function(result) {
						var existsProductsCollection = [];
						if (result.success) {
							result.collection.each(function(item) {
								existsProductsCollection.push(item.get("ProductId"));
							});
						}
						if (existsProductsCollection.length > 0) {
							var existsFilter = this.BPMSoft.createColumnInFilterWithParameters("Id",
								existsProductsCollection);
							existsFilter.comparisonType = this.BPMSoft.ComparisonType.NOT_EQUAL;
							existsFilter.Name = "existsFilter";
							config.filters.add("existsFilter", existsFilter);
						}
						this.openLookup(config, this.addCallBack, this);
					}, this);
				},

				/**
				 * @overridden
				 */
				onCardSaved: function() {
					this.openProductLookup();
				},

				/*
				 * ######### ########## ######### # ###### #### ######## #### #### ##### #########
				 * @overridden
				 * */
				addRecord: function() {
					var masterCardState = this.sandbox.publish("GetCardState", null, [this.sandbox.id]);
					var isNewRecord = (masterCardState.state === configurationEnums.CardStateV2.ADD ||
					masterCardState.state === configurationEnums.CardStateV2.COPY);
					if (isNewRecord === true) {
						var args = {
							isSilent: true,
							messageTags: [this.sandbox.id]
						};
						this.sandbox.publish("SaveRecord", args, [this.sandbox.id]);
						return;
					}
					this.openProductLookup();
				},

				/*
				 * ########## ######## #########
				 * @private
				 * */
				addCallBack: function(args) {
					var bq = this.Ext.create("BPMSoft.BatchQuery");
					var leadId = this.get("MasterRecordId");
					this.selectedRows = args.selectedRows.getItems();
					this.selectedItems = [];
					this.selectedRows.forEach(function(item) {
						item.LeadId = leadId;
						item.ProductId = item.value;
						bq.add(this.getProductInsertQuery(item));
						this.selectedItems.push(item.value);
					}, this);
					if (bq.queries.length) {
						this.showBodyMask.call(this);
						bq.execute(this.onProductInsert, this);
					}
				},

				/**
				 * Handles post product insert action.
				 */
				onProductInsert: function() {
					this.hideBodyMask();
					this.reloadGridData();
				},

				/*
				 * ########## ###### ## ########## ########
				 * @param item {Object} ############# #### # ######### # ########### #######   {LeadId, value}
				 * @private
				 * */
				getProductInsertQuery: function(item) {
					var insert = Ext.create("BPMSoft.InsertQuery", {
						rootSchemaName: this.entitySchemaName
					});
					insert.setParameterValue("Lead", item.LeadId, this.BPMSoft.DataValueType.GUID);
					insert.setParameterValue("Product", item.ProductId, this.BPMSoft.DataValueType.GUID);
					return insert;
				},

				/*
				 * ######## ######### #######
				 * @overridden
				 * */
				deleteRecords: function() {
					var selectedRows = this.getSelectedItems();
					if (selectedRows.length > 0) {
						this.set("SelectedRows", selectedRows);
						this.callParent(arguments);
					}
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getCopyRecordMenuItem
				 * @overridden
				 */
				getCopyRecordMenuItem: BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getEditRecordMenuItem
				 * @overridden
				 */
				getEditRecordMenuItem: BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.GridUtilitiesV2#getFilterDefaultColumnName
				 * @overridden
				 */
				getFilterDefaultColumnName: function() {
					return "Product";
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"rowDataItemMarkerColumnName": "Product"
					}
				},
				{
					"operation": "merge",
					"name": "AddRecordButton",
					"values": {
						"visible": {"bindTo": "getToolsVisible"}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
