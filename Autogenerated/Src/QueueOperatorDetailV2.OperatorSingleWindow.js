define("QueueOperatorDetailV2", ["QueueOperator", "ConfigurationEnums"],
	function(QueueOperator, ConfigurationEnums) {
		return {
			entitySchemaName: "QueueOperator",
			methods: {
				/**
				 * ######### ########## ##########.
				 * @private
				 */
				openContactLookup: function() {
					var config = {
						entitySchemaName: "Contact",
						multiSelect: true
					};
					var filters = this.BPMSoft.createFilterGroup();
					var subFilterGroup = Ext.create("BPMSoft.FilterGroup");
					var subFilter = BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "Queue",
						this.get("MasterRecordId"));
					subFilterGroup.addItem(subFilter);
					var notExistsOperatorFilter = BPMSoft.createNotExistsFilter("[QueueOperator:Operator].Id",
						subFilterGroup);
					filters.addItem(notExistsOperatorFilter);
					var existsSysAdminUnitFilter = this.BPMSoft.createExistsFilter("[SysAdminUnit:Contact].Id");
					filters.addItem(existsSysAdminUnitFilter);
					config.filters = filters;
					this.openLookup(config, this.addRecordCallBack, this);
				},

				/**
				 * @inheritdoc BaseGridDetailV2#onCardSaved
				 * @overridden
				 */
				onCardSaved: function() {
					this.openContactLookup();
				},

				/*
				 * @inheritDoc BasePageV2#addRecord
				 * @overridden
				 * */
				addRecord: function() {
					var masterCardState = this.sandbox.publish("GetCardState", null, [this.sandbox.id]);
					var isNewRecord = (masterCardState.state === ConfigurationEnums.CardStateV2.ADD ||
					masterCardState.state === ConfigurationEnums.CardStateV2.COPY);
					if (isNewRecord === true) {
						var args = {
							isSilent: true,
							messageTags: [this.sandbox.id]
						};
						this.sandbox.publish("SaveRecord", args, [this.sandbox.id]);
						return;
					}
					this.openContactLookup();
				},

				/*
				 * ########## ######## ######### ### ########## #######.
				 * @private
				 * @param {Object} args ####### ######### ###### ###### ########## #######.
				 * */
				addRecordCallBack: function(response) {
					var bq = this.Ext.create("BPMSoft.BatchQuery");
					var selectedOperators = response.selectedRows;
					selectedOperators.each(function(item) {
						bq.add(this.getOperatorInsertQuery(item));
					}, this);
					if (bq.queries.length) {
						this.showBodyMask.call(this);
						bq.execute(this.onOperatorsInserted, this);
					}
				},

				/*
				 * ######### ###### ## ########## ######### #######.
				 * @private
				 * @param {Object} item ########### ########.
				 * */
				getOperatorInsertQuery: function(item) {
					var insert = Ext.create("BPMSoft.InsertQuery", {
						rootSchemaName: this.entitySchemaName
					});
					var queueId = this.get("MasterRecordId");
					insert.setParameterValue("Queue", queueId, this.BPMSoft.DataValueType.GUID);
					insert.setParameterValue("Operator", item.value, this.BPMSoft.DataValueType.GUID);
					insert.setParameterValue("Active", true, this.BPMSoft.DataValueType.BOOLEAN);
					return insert;
				},

				/*
				 * ############ ########## ########## # #### ######.
				 * @private
				 * @param {Object} response ###### ###### #######.
				 * */
				onOperatorsInserted: function(response) {
					this.hideBodyMask();
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
							var collection = response.collection;
							this.prepareResponseCollection(collection);
							collection.each(function(item) {
								item.entitySchema = QueueOperator;
								item.primaryColumnName = item.entitySchema.primaryColumnName;
							}, this);
							this.getGridData().loadAll(collection);
						}
					}, this);
				},

				/**
				* ########## ### ####### ### ########## ## #########.
				* @overridden
				* @return {String} ### #######.
				*/
				getFilterDefaultColumnName: function() {
					return "Operator";
				},
				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getCopyRecordMenuItem
				 * @overridden
				 */
				getCopyRecordMenuItem: BPMSoft.emptyFn

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"type": "listed",
						"primaryDisplayColumnName": "Operator.Name",
						"rowDataItemMarkerColumnName": "Operator",
						"listedConfig": {
							"name": "DataGridListedConfig",
							"items": [
								{
									"name": "OperatorNameListedGridColumn",
									"bindTo": "Operator",
									"position": {
										"column": 1,
										"colSpan": 20
									}
								},
								{
									"name": "OperatorActiveListedGridColumn",
									"bindTo": "Active",
									"position": {
										"column": 21,
										"colSpan": 4
									}
								}
							]
						},
						"tiledConfig": {
							"name": "DataGridTiledConfig",
							"grid": {
								"columns": 24,
								"rows": 1
							},
							"items": [
								{
									"name": "OperatorNameTiledGridColumn",
									"bindTo": "Operator",
									"position": {
										"row": 1,
										"column": 1,
										"colSpan": 20
									}
								},
								{
									"name": "OperatorActiveListedGridColumn",
									"bindTo": "Active",
									"position": {
										"row": 1,
										"column": 21,
										"colSpan": 4
									}
								}
							]
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
