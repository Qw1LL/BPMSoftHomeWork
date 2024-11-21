define("ProcessInModulesDetailV2", ["ConfigurationConstants", "ConfigurationEnums"],
	function(ConfigurationConstants, configurationEnums) {
		return {
			/**
			 * Entity schema name.
			 * @type {String}
			 */
			entitySchemaName: "ProcessInModules",

			messages: {
			},
			attributes: {
			},
			methods: {
				/**
				 * Opens module lookup.
				 * @private
				 */
				openModuleLookup: function() {
					var config = this.getOpenLookupConfig();
					this.openLookup(config, this.addCallBack, this);
				},

				/**
				 * Returns config for open lookup.
				 * @private
				 * @return {Object}
				 */
				getOpenLookupConfig: function() {
					var sysSchemaUId = this.get("MasterRecordId");
					var filterGroup = this.BPMSoft.createFilterGroup();
					var subFilters = this.BPMSoft.createFilterGroup();
					subFilters.addItem(this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "SysSchemaUId", sysSchemaUId));
					filterGroup.addItem(this.BPMSoft.createNotExistsFilter("[ProcessInModules:SysModule].Id",
						subFilters));
					filterGroup.addItem(this.BPMSoft.createExistsFilter("[SysModuleInWorkplace:SysModule].Id"));
					filterGroup.addItem(this.BPMSoft.createIsNotNullFilter(
						Ext.create("BPMSoft.ColumnExpression", {
							columnPath: "SectionSchemaUId"
						})
					));
					filterGroup.addItem(this.BPMSoft.createExistsFilter(
						"[SysModuleEdit:SysModuleEntity:SysModuleEntity].Id"));
					var config = {
						entitySchemaName: "SysModule",
						multiSelect: true,
						columns: ["Caption"],
						hideActions: true,
						filters: filterGroup
					};
					return config;
				},

				/**
				 * @inheritdoc BaseGridDetailV2#addRecord
				 * @overridden
				 */
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
					this.openModuleLookup();
				},

				/**
				 * @inheritdoc BaseGridDetailV2#onCardSaved
				 * @overridden
				 */
				onCardSaved: function() {
					this.openModuleLookup();
				},

				/**
				 * Adds selected sections.
				 * @private
				 * @param {Object} args Selected result.
				 */
				addCallBack: function(args) {
					var schemaUId = this.get("MasterRecordId");
					if (BPMSoft.ProcessEntryPointUtilities.getCanRunProcessFromSection()) {
						BPMSoft.ProcessModuleUtilities.getProcessSchemaParentUIdByUId(schemaUId, function(parentUId) {
							this.addSelectedSections(args.selectedRows, parentUId);
						}, this);
					} else {
						this.addSelectedSections(args.selectedRows, schemaUId);
					}
				},

				/**
				 * Executes selected sections insert query.
				 * @param {BPMSoft.Collection} selectedRows Selected rows collection.
				 * @param {String} parentUId Parent schema identifier.
				 */
				addSelectedSections: function(selectedRows, parentUId) {
					var bq = this.Ext.create("BPMSoft.BatchQuery");
					this.selectedRows = selectedRows.getItems();
					this.selectedItems = [];
					this.selectedRows.forEach(function(item) {
						item.SysSchemaUId = parentUId;
						bq.add(this.getProcessInModulesInsertQuery(item));
						this.selectedItems.push(item.value);
					}, this);
					if (bq.queries.length) {
						this.showBodyMask.call(this);
						bq.execute(this.onProcessInModulesInsert, this);
					}
				},

				/**
				 * Returns insert query.
				 * @param {Object} config Configuration object.
				 * @param {String} config.SysSchemaUId Unique identifier of process.
				 * @param {String} config.value Unique identifier of section.
				 * @private
				 */
				getProcessInModulesInsertQuery: function(config) {
					var insert = Ext.create("BPMSoft.InsertQuery", {
						rootSchemaName: this.entitySchemaName
					});
					insert.setParameterValue("SysSchemaUId", config.SysSchemaUId, this.BPMSoft.DataValueType.GUID);
					insert.setParameterValue("SysModule", config.value, this.BPMSoft.DataValueType.GUID);
					return insert;
				},

				/**
				 * Loads the list of sections.
				 * @param {Object} response Server response.
				 * @private
				 */
				onProcessInModulesInsert: function(response) {
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
				 * @inheritdoc BPMSoft.BaseGridDetailV2#addDetailWizardMenuItems
				 * @overridden
				 */
				addDetailWizardMenuItems: BPMSoft.emptyFn
			},

			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"rowDataItemMarkerColumnName": "SysModule",
						"type": "listed",
						"listedConfig": {
							"name": "DataGridListedConfig",
							"items": [
								{
									"name": "CaptionListedGridColumn",
									"bindTo": "Caption",
									"type": BPMSoft.GridCellType.TEXT,
									"position": {
										"column": 1,
										"colSpan": 24
									}
								}
							]
						},
						"tiledConfig": {
							"name": "DataGridTiledConfig",
							"grid": {
								"columns": 24,
								"rows": 3
							},
							"items": [
								{
									"name": "CaptionTiledGridColumn",
									"bindTo": "Caption",
									"type": BPMSoft.GridCellType.TEXT,
									"position": {
										"row": 1,
										"column": 1,
										"colSpan": 24
									},
									"captionConfig": {
										"visible": true
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
