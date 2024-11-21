define("CaseProblemDetail", ["ConfigurationEnums"],
	function(enums) {
		return {
			entitySchemaName: "Case",
			methods: {
				/*
				 * ########## ####### ########### ##### ##### ## ###########
				 * @overridden
				 * */
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
						this.addDetailRecord();
					}
				},

				/*
				 * ########## ######## ######### ### ######### ##########
				 * @private
				 * */
				addCallBack: function(args) {
					var problemId = this.get("MasterRecordId");
					this.selectedRows = args.selectedRows.getItems();
					var selectedItems = [];
					this.selectedRows.forEach(function(item) {
						selectedItems.push(item.Id);
					}, this);
					if (selectedItems.length !== 0) {
						var update = this.getNewCaseUpdateQuery(selectedItems);
						update.setParameterValue("Problem", problemId, this.BPMSoft.DataValueType.GUID);
						update.execute(function() {
								this.onCaseUpdate.call(this, selectedItems);
							}, this);
					} else {
						this.updateDetail({reloadAll: true});
					}
				},

				/*
				 * ########## ###### ## ############ ######## # #########
				 * @param item Case #########
				 * @private
				 * */
				getCaseUpdateQuery: function(items, problemId) {
					var update = Ext.create("BPMSoft.UpdateQuery", {
						rootSchemaName: this.entitySchemaName
					});
					var	idFilter = update.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
						"Id", items);
					update.filters.add("IdFilter", idFilter);
					update.setParameterValue("Problem", problemId, this.BPMSoft.DataValueType.GUID);
					return update;
				},

				getNewCaseUpdateQuery: function(items) {
					var update = Ext.create("BPMSoft.UpdateQuery", {
						rootSchemaName: this.entitySchemaName
					});
					var	idFilter = update.createColumnInFilterWithParameters("Id", items);
					update.filters.add("IdFilter", idFilter);
					return update;
				},

				/*
				 * ######## #########
				 * @private
				 * */
				onCaseUpdate: function(selectedItems) {
					this.hideBodyMask.call(this);
					this.beforeLoadGridData();
					var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchema: this.entitySchema
					});
					this.initQueryColumns(esq);
					esq.filters.add("Id", BPMSoft.createColumnInFilterWithParameters("Id", selectedItems));
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
				 * ######## ######### #######, ##### ### # ####### #### - #############.
				 * @overridden
				 * */
				deleteRecords: function() {
					var selectedRows = this.getSelectedItems();
					var update = this.getNewCaseUpdateQuery(selectedRows);
					update.setParameterValue("Problem", null, this.BPMSoft.DataValueType.GUID);
					update.execute(function() {
						this.getGridData().removeByKey(selectedRows[0]);
					}, this);
				},

				addDetailRecord: function() {
					var problemId = this.get("MasterRecordId");
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: this.entitySchemaName
					});
					esq.addColumn("Id");
					esq.addColumn("Problem");
					esq.filters.add("filterProblem", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Problem", problemId));
					esq.getEntityCollection(function(result) {
						var existsRequestCollection = [];
						if (result.success) {
							result.collection.each(function(item) {
								existsRequestCollection.push(item.get("Id"));
							});
						}
						var config = {
							entitySchemaName: "Case",
							sectionEntitySchema: "Problem",
							multiSelect: true,
							valuePairs: this.get("DefaultValues")
						};
						var filtersCollection = this.BPMSoft.createFilterGroup();
						if (existsRequestCollection.length > 0) {
							var existsFilter = this.BPMSoft.createColumnInFilterWithParameters("Id",
								existsRequestCollection);
							existsFilter.comparisonType = this.BPMSoft.ComparisonType.NOT_EQUAL;
							existsFilter.Name = "existsFilter";
							filtersCollection.add(existsFilter);
						}
						var emptyFilter = this.BPMSoft.createColumnIsNullFilter("Problem");
						emptyFilter.Name = "emptyFilter";
						filtersCollection.logicalOperation = this.BPMSoft.LogicalOperatorType.AND;
						filtersCollection.add(emptyFilter);
						config.filters = filtersCollection;
						this.openLookup(config, this.addCallBack, this);
					}, this);
				},

				onCardSaved: function() {
					this.addDetailRecord();
				}
			},
			diff: [
				{
					"operation": "remove",
					"name": "CopyRecordMenu"
				},
				{
					"operation": "remove",
					"name": "EditRecordMenu"
				}
			]
		};
	}
);
