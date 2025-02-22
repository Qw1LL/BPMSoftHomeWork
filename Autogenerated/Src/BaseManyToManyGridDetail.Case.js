﻿//TODO: ####### # ######### #####
define("BaseManyToManyGridDetail", ["ConfigurationEnums"],
	function(ConfigurationEnums) {
		return {
			methods: {
				/**
				 * ############## ###### ###### ## #########.
				 */
				initConfig: function() {
					this.baseDetailConfig = {
						lookupEntitySchema: "",
						sectionEntitySchema: "",
						lookupConfig: {
							multiSelect: true,
							filters: []
						}
					};
				},

				/**
				 * ########## ######### ######.
				 * @returns {Object} ######### ######.
				 */
				getConfig: function() {
					return this.baseDetailConfig ? this.baseDetailConfig : this.initConfig();
				},

				/**
				 * ######### ###### ## ####### ### ############ ## ###### #######.
				 * @returns {BPMSoft.EntitySchemaQuery}
				 */
				getAlreadyExistsRecordsQuery: function() {
					var config = this.getConfig();
					var masterRecordId = this.get("MasterRecordId");
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: this.entitySchemaName
					});
					esq.addColumn(config.lookupEntitySchema);
					esq.addColumn(config.sectionEntitySchema);
					esq.filters.add("sectionSchemaFilter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, config.sectionEntitySchema, masterRecordId));
					return esq;
				},

				/**
				 * ########## ####### ###### ###### "########".
				 */
				addRecord: function() {
					var cardState = this.sandbox.publish("GetCardState", null, [this.sandbox.id]);
					var isNew = (cardState.state === ConfigurationEnums.CardStateV2.ADD ||
						cardState.state === ConfigurationEnums.CardStateV2.COPY);
					if (isNew) {
						var args = {
							isSilent: true,
							messageTags: [this.sandbox.id]
						};
						this.sandbox.publish("SaveRecord", args, [this.sandbox.id]);
					} else {
						this.addDetailRecord();
					}
				},

				/**
				 * ######### ########## ####### ##### LookupEntitySchema.
				 */
				addDetailRecord: function() {
					var lookupConfig = {};
					var config = this.getConfig();
					var esq = this.getAlreadyExistsRecordsQuery();
					esq.getEntityCollection(function(result) {
						var existsCollection = [];
						if (result.success) {
							result.collection.each(function(item) {
								var record = item.get(config.lookupEntitySchema);
								existsCollection.push(record.value);
							}, this);
						}
						var filterGroup = BPMSoft.createFilterGroup();
						if (existsCollection.length > 0) {
							var existsFilter = this.BPMSoft.createColumnInFilterWithParameters("Id",
								existsCollection);
							existsFilter.Name = "existsFilter";
							existsFilter.comparisonType = this.BPMSoft.ComparisonType.NOT_EQUAL;
							filterGroup.add("existsFilter", existsFilter);
							for (var filter in this.baseDetailConfig.lookupConfig.filters) {
								filterGroup.add(this.BPMSoft.utils.generateGUID(),
									config.lookupConfig.filters[filter]);
							}
						}
						this.Ext.apply(lookupConfig, config.lookupConfig);
						lookupConfig.filters = filterGroup;
						this.openLookup(lookupConfig, this.addRecordCallback, this);
					}, this);
				},

				/**
				 * ######### ########## ####### ##### LookupEntitySchema ##### ##########
				 * ##### ###### ####### # ###### ########## ####### ## ######.
				 * @overridden.
				 * @protected.
				 * @virtual.
				 */
				onCardSaved: function() {
					this.addDetailRecord();
				},

				/**
				 * ######### ###### # ####### ##### ########.
				 * @param args ######### ######.
				 */
				addRecordCallback: function(args) {
					var bq = Ext.create("BPMSoft.BatchQuery");
					this.selectedRows = args.selectedRows.getItems();
					this.selectedItems = [];
					this.selectedRows.forEach(function(item) {
						bq.add(this.getSchemaInsertQuery(item));
						this.selectedItems.push(item.value);
					}, this);
					if (bq.queries.length) {
						bq.execute(this.onRecordsInserted, this);
					}
				},

				/**
				 * #### ######### ########## ####### ## ######.
				 */
				onRecordsInserted: function() {
					this.updateDetail({reloadAll: true});
				},

				/**
				 * @inheritDoc BPMSoft.BaseGridDetailV2#getAddRecordButtonVisible
				 * @overridden
				 */
				getAddRecordButtonVisible: function() {
					return this.getToolsVisible();
				},

				/**
				 * ######### # ########## ###### ## ########## ####### # ####### ##### ########.
				 * @param item ###### ### ##########.
				 * @returns {BPMSoft.InsertQuery} ###### ## ##########.
				 */
				getSchemaInsertQuery: function(item) {
					var config = this.getConfig();
					var masterRecordId = this.get("MasterRecordId");
					var insert = this.Ext.create("BPMSoft.InsertQuery", {
						rootSchemaName: this.entitySchemaName
					});
					insert.setParameterValue(config.sectionEntitySchema, masterRecordId,
						this.BPMSoft.DataValueType.GUID);
					insert.setParameterValue(config.lookupEntitySchema, item.value, this.BPMSoft.DataValueType.GUID);
					return insert;
				}
			},
			diff: [
				{
					"operation": "remove",
					"name": "AddTypedRecordButton"
				},
				{
					"operation": "remove",
					"name": "EditRecordMenu"
				},
				{
					"operation": "remove",
					"name": "CopyRecordMenu"
				}
			]
		};
	}

);


