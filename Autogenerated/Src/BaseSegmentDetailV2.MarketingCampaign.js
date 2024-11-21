define("BaseSegmentDetailV2", ["BPMSoft", "MarketingEnums", "ConfigurationEnums"],
		function(BPMSoft, MarketingEnums, enums) {
			return {
				methods: {
					/**
					 * ########## #######, ####### ###### ########## ########.
					 * @return {Object} ########## ###### ########-############ #######.
					 */
					getGridDataColumns: function() {
						return {
							"Id": {path: "Id"},
							"Segment": {path:  "Segment"}
						};
					},

					/**
					 * ######### ######## ######.
					 */
					addSegments: function() {
						var masterRecordId = this.get("MasterRecordId");
						var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: this.entitySchemaName
						});
						esq.addColumn("Id");
						esq.addColumn("Segment.Id", "LeadFolderId");
						esq.filters.add("filterEntity", this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL, this.get("ParentEntitySchemaName"), masterRecordId));
						esq.getEntityCollection(function(result) {
							var existsSegmentsCollection = [];
							if (result.success) {
								result.collection.each(function(item) {
									existsSegmentsCollection.push(item.get("LeadFolderId"));
								});
							}
							var config = {
								entitySchemaName: "LeadFolder",
								multiSelect: true
							};
							if (existsSegmentsCollection.length > 0) {
								var existsFilter = this.BPMSoft.createColumnInFilterWithParameters(
										"Id",
										existsSegmentsCollection);
								existsFilter.comparisonType = this.BPMSoft.ComparisonType.NOT_EQUAL;
								existsFilter.Name = "existsFilter";
								config.filters = existsFilter;
							}
							this.openLookup(config, this.addCallback, this);
						}, this);
					},

					/**
					 * ########## #######.
					 * @overridden
					 */
					addRecord: function() {
						var cardState = this.sandbox.publish("GetCardState", null, [this.sandbox.id]);
						var isNew = (cardState.state === enums.CardStateV2.ADD ||
								cardState.state === enums.CardStateV2.COPY);
						if (isNew) {
							this.set("CardState", enums.CardStateV2.ADD);
							var args = {
								isSilent: true,
								messageTags: [this.sandbox.id]
							};
							this.sandbox.publish("SaveRecord", args, [this.sandbox.id]);
						} else {
							this.addSegments();
						}
					},

					/**
					 * ######### ######## ######
					 * @protected
					 * @overridden
					 */
					onCardSaved: function() {
						this.addSegments();
					},

					/**
					 * ########## ######## ##### ##### ### #########.
					 * @param {Object} args ######### ###### ## ###########.
					 * @private
					 */
					addCallback: function(args) {
						var batchQuery = this.Ext.create("BPMSoft.BatchQuery");
						var masterRecordId = this.get("MasterRecordId");
						this.selectedRows = args.selectedRows.getItems();
						this.selectedItems = [];
						this.selectedRows.forEach(function(item) {
							item.MasterEntityId = masterRecordId;
							batchQuery.add(this.getSegmentInsertQuery(item));
							this.selectedItems.push(item.value);
						}, this);
						if (batchQuery.queries.length) {
							this.showBodyMask.call(this);
							batchQuery.execute(function(response) {
								this.onSegmentInsert(response);
								this.onSegmentsChanged();
							}, this);
						}
					},

					/**
					 * ########## ###### ## ########## ########.
					 * @param {Object} item ############# ########### # ######### # ########### ###### #####.
					 * @private
					 */
					getSegmentInsertQuery: function(item) {
						var insertQuery = Ext.create("BPMSoft.InsertQuery", {
							rootSchemaName: this.entitySchemaName
						});
						insertQuery.setParameterValue(
								this.get("ParentEntitySchemaName"),
								item.MasterEntityId, this.BPMSoft.DataValueType.GUID);
						insertQuery.setParameterValue("Segment", item.value, this.BPMSoft.DataValueType.GUID);
						return insertQuery;
					},

					/**
					 * ######## ########## ######### # ######.
					 * @param {Object} response ######### ####### ########## #######.
					 * @private
					 */
					onSegmentInsert: function(response) {
						this.hideBodyMask.call(this);
						this.beforeLoadGridData();
						var filterCollection = [];
						response.queryResults.forEach(function(item) {
							filterCollection.push(item.id);
						});
						var entitySchemaQuery = Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: this.entitySchemaName
						});
						this.initQueryColumns(entitySchemaQuery);
						entitySchemaQuery.filters.add(
								"recordId",
								BPMSoft.createColumnInFilterWithParameters("Id", filterCollection));
						entitySchemaQuery.getEntityCollection(function(response) {
							this.afterLoadGridData();
							if (response.success) {
								var responseCollection = response.collection;
								this.prepareResponseCollection(responseCollection);
								var gridData = this.getGridData();
								gridData.loadAll(responseCollection);
							}
						}, this);
					},

					/**
					 * ############## ######### ##### ######## ######.
					 * @protected
					 * @overridden
					 */
					onDeleted: function() {
						this.onSegmentsChanged();
						this.callParent(arguments);
					},

					/**
					 * ###### ######### #########.
					 */
					onSegmentsChanged: function() {
						var masterRecordId = this.get("MasterRecordId");
						if (masterRecordId) {
							var update = Ext.create("BPMSoft.UpdateQuery", {
								rootSchemaName: this.get("ParentEntitySchemaName")
							});
							var filters = update.filters;
							var idFilter = update.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "Id",
									masterRecordId);
							filters.add("IdFilter", idFilter);
							update.setParameterValue("SegmentsStatus",
									MarketingEnums.SegmentsStatus.REQUIERESUPDATING, BPMSoft.DataValueType.GUID);
							update.execute(function() {
								this.sandbox.publish("DetailChanged", {}, [this.sandbox.id]);
							}, this);
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
					getEditRecordMenuItem: BPMSoft.emptyFn
				},
				diff: [
					{
						"operation": "merge",
						"name": "DataGrid",
						"values": {
							"type": "listed",
							"listedConfig": {
								"name": "DataGridListedConfig",
								"items": [
									{
										"name": "SegmentListedGridColumn",
										"bindTo": "Segment",
										"position": {
											"column": 1,
											"colSpan": 24
										},
										"type": BPMSoft.GridCellType.TITLE
									}
								]
							},
							"tiledConfig": {
								"name": "DataGridTiledConfig",
								"grid": {
									"columns": 1,
									"rows": 1
								},
								"items": [
									{
										"name": "SegmentTiledGridColumn",
										"bindTo": "Segment",
										"position": {
											"row": 1,
											"column": 1,
											"colSpan": 24
										},
										"type": BPMSoft.GridCellType.TITLE
									}
								]
							}
						}
					},
					{
						"operation": "merge",
						"name": "AddRecordButton",
						"values": {
							"visible": {"bindTo": "getToolsVisible"}
						}
					}
				],
				attributes: {
					ParentEntitySchemaName: {dataValueType: BPMSoft.DataValueType.STRING},
					CanChangeSegments: {dataValueType: BPMSoft.DataValueType.BOOLEAN}
				}
			};
		}
);
