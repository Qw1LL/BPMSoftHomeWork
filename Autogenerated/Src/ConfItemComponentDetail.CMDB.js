define("ConfItemComponentDetail", ["ConfigurationEnums", "ServicModelConstants", "RelationshipsRecordsUtilities"],
		function(enums, serviceModelConstants) {
			return {
				entitySchemaName: "ConfItem",
				mixins: {
					RelationshipsRecordsUtilities: "BPMSoft.RelationshipsRecordsUtilities"
				},
				messages: {
					/**
					 * @message UpdateRelationshipDetail
					 * Updates relationship detail.
					 */
					"UpdateRelationshipDetail": {
						mode: this.BPMSoft.MessageMode.PTP,
						direction: this.BPMSoft.MessageDirectionType.PUBLISH
					}
				},
				methods: {
					/**
					 * @inheritdoc BPMSoft.BaseGridDetailV2#add
					 * @overridden
					 * */
					add: function() {
						this.set("CardState", enums.CardStateV2.ADD);
						var args = {
							isSilent: true,
							messageTags: [this.sandbox.id]
						};
						this.sandbox.publish("SaveRecord", args, [this.sandbox.id]);
					},
					/**
					 * ########## ####### ### ########## ############.
					 * @overridden
					 * */
					addComponent: function() {
						this.set("NeedAddRelation", false);
						this.add();
					},

					/**
					 * ########## ####### # ########### ############.
					 * @overridden
					 * */
					addRelatedComponent: function() {
						this.set("NeedAddRelation", true);
						this.add();
					},

					/**
					 * ######### # ########## ###### ## ########## ###### ##### #########.
					 * @param {Object} item ###### ### ##########.
					 * @returns {BPMSoft.InsertQuery} ###### ## ##########.
					 * @private
					 */
					getSchemaInsertQuery: function(item, masterRecordId) {
						var insert = this.Ext.create("BPMSoft.InsertQuery", {
							rootSchemaName: serviceModelConstants.TablesName.VmConfItemRelationship
						});
						var dependencyCategory = serviceModelConstants.DependencyCategory.Influence;
						var dependencyType = serviceModelConstants.DependencyType.ConnectedTo;
						insert.setParameterValue("DependencyCategory", dependencyCategory, this.BPMSoft.DataValueType.GUID);
						insert.setParameterValue("DependencyType", dependencyType, this.BPMSoft.DataValueType.GUID);
						insert.setParameterValue("ConfItemA", item.Id, this.BPMSoft.DataValueType.GUID);
						insert.setParameterValue("ConfItemB", masterRecordId, this.BPMSoft.DataValueType.GUID);
						return insert;
					},

					/**
					 * ######### ########### ### ########.
					 * @param {Array} items ######### ########
					 * @private
					 */
					createRelation: function(items) {
						if (!this.get("NeedAddRelation")) {
							return;
						}
						var masterRecordId = this.get("MasterRecordId");
						var query = this.Ext.create("BPMSoft.BatchQuery");
						items.forEach(function(item) {
							query.add(this.getSchemaInsertQuery(item, masterRecordId));
						}, this);

						if (query.queries.length) {
							query.execute(function() {
								this.sandbox.publish("UpdateRelationshipDetail");
							}, this);
						}
					},

					/**
					 * @inheritdoc BPMSoft.BaseGridDetailV2#onCardSaved
					 * @overridden
					 * */
					onCardSaved: function() {
						this.addDetailRecord();
					},

					/**
					 * ########## ####### "#############" ####### "##"
					 * @private
					 * */
					addDetailRecord: function() {
						this.openComponentsLookup();
					},

					/**
					 * ######## ###### ######### ############ ####### ####### "##"
					 * @param {Object} item
					 * @obsolete
					 */
					getParentCollection: function(item) {
						var config = {
							serviceName: "HierarchicalRecordSelectService",
							methodName: "GetRecords",
							data: {
								request: {
									Id: item,
									SchemaTableName: "ConfItem",
									ParentIdColumnName: "ParentConfItemId",
									Type: "parent"
								}
							}
						};
						this.callService(config, this.onSelectRecords, this);
					},
					/**
					 * callBack ####### getParentCollection, ######## ######## ########### "#############"
					 * @private
					 * @param {Object} responseObject
					 */
					onSelectRecords: function(responseObject) {
						var result = responseObject.GetRecordsResult;
						if (result) {
							this.set("ConfItemParentCollection", result);
						}
						this.openComponentsLookup();
					},
					/**
					 * Open lookup of available "ConfItem" for filtering:
					 * not current ConfItem, not parent ConfItem, not child ConfItem.
					 * @private
					 */
					openComponentsLookup: function() {
						var columnNames = ["ParentConfItem"];
						var parentRecord = this.sandbox.publish("GetColumnsValues", columnNames, [this.sandbox.id]);
						var masterRecordId = this.get("MasterRecordId");

						var filtersCollection = this.mixins.RelationshipsRecordsUtilities.getHierarchicalFilter.call(this,
								masterRecordId, parentRecord.ParentConfItem, "ParentConfItem");
						var config = {
							entitySchemaName: "ConfItem",
							multiSelect: true
						};
						config.filters = filtersCollection;
						this.BPMSoft.LookupUtilities.Open({
							"lookupConfig": config,
							"sandbox": this.sandbox,
							"valuePairs": this.get("DefaultValues")
						}, this.addCallBack, this);
					},
					/**
					 * callBack ####### addRecord, ########### "############ ##" # "##"
					 * @private
					 * @param {Object} args
					 */
					addCallBack: function(args) {
						var parentConfItemId = this.get("MasterRecordId");
						this.selectedRows = args.selectedRows.getItems();
						var selectedItems = [];
						this.selectedRows.forEach(function(item) {
							selectedItems.push(item.Id);
						}, this);
						if (selectedItems.length !== 0) {
							var config = this.mixins.RelationshipsRecordsUtilities.getConfig(parentConfItemId,
									selectedItems, "ConfItem", "ParentConfItemId");
							this.callService(config, function(response) {
								this.addElementInHierarchy(response, selectedItems);
							}, this);
							this.createRelation(this.selectedRows);
						} else {
							this.updateDetail({reloadAll: true});
						}
					},
					/**
					 * Service callback, set child ConfItem into ConfItem.
					 * @param {Object} responseObject
					 * @param {Object} selectedItems
					 */
					addElementInHierarchy: function(responseObject, selectedItems) {
						if(responseObject) {
							var result = responseObject.UpdateRecordsResult;
							if (result.success) {
								this.onConfItemUpdate.call(this, selectedItems);
							} else {
								BPMSoft.utils.showInformation(result.errorInfo.message);
							}
						}
					},
					/**
					 * ########## ###### ## ############ "############ ##" # "##".
					 * @private
					 * @param {Array} items
					 */
					getConfItemUpdateQuery: function(items) {
						var update = this.Ext.create("BPMSoft.UpdateQuery", {
							rootSchemaName: this.entitySchemaName
						});
						update.filters.add("IdFilter", update.createColumnInFilterWithParameters("Id", items));
						return update;
					},
					/**
					 * ######## "################ ######"
					 * @param {ConfigurationItem} selectedItems
					 * @private
					 * */
					onConfItemUpdate: function(selectedItems) {
						this.hideBodyMask.call(this);
						this.beforeLoadGridData();
						var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchema: this.entitySchema
						});
						this.initQueryColumns(esq);
						esq.filters.add("Id", this.BPMSoft.createColumnInFilterWithParameters("Id", selectedItems));
						esq.getEntityCollection(function(response) {
							this.afterLoadGridData();
							if (response.success) {
								var responseCollection = response.collection;
								this.prepareResponseCollection(responseCollection);
								this.getGridData().loadAll(responseCollection);
							}
						}, this);
					},

					/**
					 * ####### ########### # ###### ######## #############.
					 * @param {Array} items ######### ########
					 * @private
					 */
					deleteRelations: function(items) {
						var masterRecordId = this.get("MasterRecordId");
						var query = this.Ext.create("BPMSoft.DeleteQuery", {
							rootSchemaName: serviceModelConstants.TablesName.VmConfItemRelationship
						});
						query.filters.add(this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL, "ConfItemA", masterRecordId));
						query.filters.add(this.BPMSoft.createColumnInFilterWithParameters(
								"ConfItemB", items, this.BPMSoft.DataValueType.GUID));
						query.execute(function() {
							this.sandbox.publish("UpdateRelationshipDetail");
						}, this);
					},

					/**
					 * @inheritdoc BPMSoft.BaseGridDetailV2#deleteRecords
					 * @overridden
					 * */
					deleteRecords: function() {
						var selectedRows = this.getSelectedItems();
						var update = this.getConfItemUpdateQuery(selectedRows);
						update.setParameterValue("ParentConfItem", null, this.BPMSoft.DataValueType.GUID);
						update.execute(function() {
							this.reloadGridData();
						}, this);
						this.deleteRelations(selectedRows);
					}
				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "remove",
						"name": "CopyRecordMenu"
					},
					{
						"operation": "remove",
						"name": "EditRecordMenu"
					},
					{
						"operation": "remove",
						"name": "AddRecordButton"
					},
					{
						"operation": "merge",
						"name": "AddTypedRecordButton",
						"parentName": "Detail",
						"propertyName": "tools",
						"index": 1,
						"values": {
							"itemType": this.BPMSoft.ViewItemType.BUTTON,
							"visible": true,
							"menu": []
						}
					},
					{
						"operation": "insert",
						"name": "AddComponentMenu",
						"parentName": "AddTypedRecordButton",
						"propertyName": "menu",
						"values": {
							"caption": {
								"bindTo": "Resources.Strings.AddComponent"
							},
							"click": {
								"bindTo": "addComponent"
							}
						}
					},
					{
						"operation": "insert",
						"name": "AddRelatedComponentMenu",
						"parentName": "AddTypedRecordButton",
						"propertyName": "menu",
						"values": {
							"caption": {
								"bindTo": "Resources.Strings.AddRelatedComponent"
							},
							"click": {
								"bindTo": "addRelatedComponent"
							}
						}
					}
				]/**SCHEMA_DIFF*/
			};
		});
