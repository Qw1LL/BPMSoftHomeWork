define("ProductInLeadTypeDetailV2", ["ConfigurationEnums"],
	function(configurationEnums) {
		return {
			entitySchemaName: "VwProductInLeadType",
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "AddRecordButton",
					"values": {
						"visible": false
					}
				},
				{
					"operation": "merge",
					"name": "AddTypedRecordButton",
					"values": {
						"controlConfig": {
							"menu": {
								"items": [
									{
										"caption": {
											bindTo: "Resources.Strings.AddProductCaption"
										},
										"click": {
											bindTo: "addRecord"
										},
										"tag": "Product"
									}
								]
							}
						},
						"visible": {
							"bindTo": "getToolsVisible"
						}
					}
				},
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"rowDataItemMarkerColumnName": "Name"
					}
				}
			]/**SCHEMA_DIFF*/,
			methods: {
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
				 * ########## #######, ####### ###### ########## ########.
				 * @return {Object} ########## ###### ########-############ #######.
				 */
				getGridDataColumns: function() {
					return {
						"Id": {path: "Id"},
						"Product": {path: "Product"},
						"Product.Name": {path: "Product.Name"},
						"ProductFolder": {path: "ProductFolder"},
						"ProductFolder.Name": {path: "ProductFolder.Name"}
					};
				},

				/**
				 * ######### ########## ########.
				 * @param {String} columnName ### #######.
				 * @private
				 */
				openItemLookup: function(columnName) {
					var leadTypeId = this.get("MasterRecordId");
					if (this.Ext.isEmpty(leadTypeId) || this.Ext.isEmpty(columnName)) {
						return;
					}
					var config = {
						entitySchemaName: columnName,
						multiSelect: true,
						columnName: columnName,
						columns: ["Name"]
					};
					var productFilterPath = "[ProductInLeadType:" + columnName + ":Id].LeadType";
					var subProductFilterGroup = this.Ext.create("BPMSoft.FilterGroup");
					var productFilter = this.BPMSoft.createColumnInFilterWithParameters(productFilterPath,
						[leadTypeId]);
					subProductFilterGroup.addItem(productFilter);
					var notExistsFilter = this.BPMSoft.createNotExistsFilter("Id", subProductFilterGroup);
					config.filters = notExistsFilter;
					this.openLookup(config, this.addCallBack, this);
				},

				/**
				 * ######## ######## ###########.
				 * @overridden
				 */
				onCardSaved: function() {
					this.openItemLookup(this.get("AddItemType"));
				},

				/*
				 * ######### ########## ######### # ###### #### ######## #### ########### #### ##### #########.
				 * @overridden
				 */
				addRecord: function(tag) {
					this.set("AddItemType", tag);
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
					this.openItemLookup(tag);
				},

				/*
				 * ########## ######## #########.
				 * @param {String} args ### #######.
				 * @private
				 */
				addCallBack: function(args) {
					var bq = this.Ext.create("BPMSoft.BatchQuery");
					var leadTypeId = this.get("MasterRecordId");
					this.selectedRows = args.selectedRows.getItems();
					this.selectedItems = [];
					this.selectedRows.forEach(function(item) {
						item.LeadTypeId = leadTypeId;
						switch (args.columnName) {
							case "Product":
								item.ProductId = item.value;
								item.ProductFolderId = null;
								break;
							case "ProductFolder":
								item.ProductFolderId = item.value;
								item.ProductId = null;
								break;
						}
						bq.add(this.getProductInsertQuery(item));
						this.selectedItems.push(item.value);
					}, this);
					if (bq.queries.length) {
						this.showBodyMask.call(this);
						bq.execute(this.onItemsInsert, this);
					}
				},

				/*
				 * ########## ###### ## ########## ########.
				 * @param {Object} item ############# #### ########### # ######### # ########### #######.
				 * @private
				 */
				getProductInsertQuery: function(item) {
					var insert = Ext.create("BPMSoft.InsertQuery", {
						rootSchemaName: "ProductInLeadType"
					});
					insert.setParameterValue("LeadType", item.LeadTypeId, this.BPMSoft.DataValueType.GUID);
					insert.setParameterValue("Product", item.ProductId, this.BPMSoft.DataValueType.GUID);
					insert.setParameterValue("ProductFolder", item.ProductFolderId, this.BPMSoft.DataValueType.GUID);
					return insert;
				},

				/*
				 * ######## ########## ######### # ######.
				 * @param {Object} response ###### ###### ## #######.
				 * @private
				 */
				onItemsInsert: function(response) {
					this.hideBodyMask.call(this);
					this.beforeLoadGridData();
					var filterCollection = [];
					response.queryResults.forEach(function(item) {
						filterCollection.push(item.id);
					});
					var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: this.entitySchemaName
					});
					this.initQueryColumns(esq);
					esq.filters.add("recordId", BPMSoft.createColumnInFilterWithParameters("Id", filterCollection));
					esq.getEntityCollection(function(response) {
						this.afterLoadGridData();
						if (response.success) {
							var responseCollection = response.collection;
							this.prepareResponseCollection(responseCollection);
							this.getGridData().loadAll(responseCollection);
						}
					}, this);
				},

				/*
				 * ######## ######### #######
				 * @overridden
				 */
				deleteRecords: function() {
					var selectedRows = this.getSelectedItems();
					if (selectedRows.length > 0) {
						this.entitySchema.name = "ProductInLeadType";
						this.set("SelectedRows", selectedRows);
						this.callParent(arguments);
					}
				},

				/**
				 * ############## ######### ##### ######## ######
				 * @overridden
				 */
				onDeleted: function() {
					this.entitySchema.name = this.entitySchemaName;
				}
			}
		};
	});
