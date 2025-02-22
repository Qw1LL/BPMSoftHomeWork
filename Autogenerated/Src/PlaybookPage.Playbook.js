﻿define("PlaybookPage", [], function() {
	return {
		entitySchemaName: "Playbook",
		attributes: {

			/**
			 * Dcm Stage identifier.
			 */
			"StageId": {
				"onChange": "onStageIdChanged"
			},

			/**
			 * Culture lookup.
			 */
			"Culture": {
				"dataValueType": BPMSoft.DataValueType.LOOKUP,
				"lookupListConfig": {
					"filter": function () {
						return this.BPMSoft.createColumnFilterWithParameter(
							BPMSoft.ComparisonType.EQUAL, "[SysCulture:Language:Id].Active", true);
					}
				}
			},

			/**
			 * Case lookup.
			 */
			"Case": {
				"onChange": "onCaseChanged",
				"dataValueType": BPMSoft.DataValueType.LOOKUP,
				"lookupListConfig": {
					"hideActions": true,
					"filter": function () {
						return this.BPMSoft.createColumnFilterWithParameter(
							BPMSoft.ComparisonType.EQUAL, "IsActive", true);
					}
				}
			},
			
			/**
			 * Dcm stage lookup.
			 */
			"Stage": {
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": BPMSoft.DataValueType.LOOKUP,
				"name": "Stage",
				"onChange": "onStageChanged",
				"isRequired": true
			},
		},
		methods: {

			//region Methods: Private

			/**
			 * @private
			 */
			_processDcmView: function(callback, response, scope) {
				if (response && response.success) {
					this.$DcmEntity = response.entity;
					this._initStageLookupData(response.entity, callback, this);
				} else {
					Ext.callback(callback, scope || this);
				}
			},

			/**
			 * @private
			 */
			_getDcmView: function(callback, scope) {
				if (this.$Case) {
					const esq = this.getDcmInfoESQ();
					esq.getEntity(this.$Case.value, callback, scope);
				} else {
					Ext.callback(callback, scope, [{success: false}]);
				}
			},

			/**
			 * @private
			 */
			_initActionsSchemaName: function(schema, entity) {
				const actionsColumn = schema && schema.columns.find(entity.$StageColumnUId);
				const actionsSchemaName = actionsColumn.referenceSchemaName;
				this.set("ActionsSchemaName", actionsSchemaName);
			},

			/**
			 * @private
			 */
			_initStageLookupData: function(entity, callback, scope) {
				this.set("StageLookupData", null);
				const config = {
					schemaUId: entity.$EntitySchemaUId,
					packageUId: entity.$PackageUId
				};
				BPMSoft.EntitySchemaManager.findBundleSchemaInstance(config, function(schema) {
					this._initActionsSchemaName(schema, entity);
					BPMSoft.chain(
						this.setActionsPrimaryColumnNames,
						this._selectStagesFromDb,
						this._createStageLookupData,
						this._onDcmConfigSet,
						this._processStagesList,
						function(next) {
							Ext.callback(callback, scope || this);
						}, this
					);
				}, this);
			},

			/**
			 * @private
			 */
			_onDcmConfigSet: function(callback, scope) {
				if (this.$DcmEntity) {
					const schemaUId = this.$DcmEntity.$UId;
					this.BPMSoft.chain(
						function(next) {
							BPMSoft.DcmSchemaManager.initialize(next, this);
						},
						function(next) {
							BPMSoft.DcmElementSchemaManager.initialize(next, this);
						},
						function() {
							const caseItem = schemaUId && BPMSoft.DcmSchemaManager.getItems().get(schemaUId);
							if (caseItem) {
								caseItem.getInstance(function(schemaInstance) {
									if (schemaInstance) {
										this.set("DcmSchemaInstance", schemaInstance);
										this.set("AvailableStages", schemaInstance.stages);
										Ext.callback(callback, scope || this);
									}
								}, this);
							}
						},
						this
					);
				}
			},

			/**
			 * @private
			 */
			_selectStagesFromDb: function(callback, scope) {
				const selectConfig = {
					entitySchemaName: this.$ActionsSchemaName,
					addToStore: true,
					columnsInfo: [
						{columnName: this.$ActionsPrimaryColumnName},
						{columnName: this.$ActionsPrimaryDisplayColumnName}
					]
				};
				BPMSoft.DataManager.select(selectConfig, callback, scope || this);
			},

			/**
			 * @private
			 */
			_processStagesList: function(callback, scope) {
				this.$StagesList = this.getStagesList();
				if (!this.BPMSoft.isEmptyGUID(this.$StageId)) {
					this.$Stage = this.$StagesList.find(this.$StageId);
				}
				Ext.callback(callback, scope);
			},

			/**
			 * @private
			 */
			_createStageLookupData: function(callback, dataCollection) {
				const stageLookupData = {};
				dataCollection.collection.each(function(item) {
					const viewModel = item.viewModel;
					const id = viewModel.get(this.$ActionsPrimaryColumnName);
					const caption = viewModel.get(this.$ActionsPrimaryDisplayColumnName);
					stageLookupData[id] = caption;
				}, this);
				this.set("StageLookupData", stageLookupData);
				Ext.callback(callback, this);
			},
			
			//endregion
			
			//region Methods: Protected

			/**
			 * Handles Stage field state changed event.
			 * @protected
			 */
			onStageChanged: function(model, stage) {
				if (stage) {
					this.$StageId = stage.value || BPMSoft.GUID_EMPTY;
				} else {
					this.$StageId = BPMSoft.GUID_EMPTY;
				}
			},

			/**
			 * Handles Case field state changed event.
			 * @protected
			 */
			onCaseChanged: function() {
				this.showBodyMask();
				if (this.$StagesList && !this.$StagesList.isEmpty()) {
					this.$StagesList.clear();
				}
				this.$StageId = BPMSoft.GUID_EMPTY;
				this.$Stage = null;
				this.initDcmActionsDashboard(function() {
					this.hideBodyMask();
				}, this);
			},

			/**
			 * Handles StageId field state changed event.
			 * @protected
			 */
			onStageIdChanged: function() {
				if (!this.BPMSoft.isEmptyGUID(this.$StageId)) {
					if (this.$Stage && this.$Stage.value !== this.$StageId) {
						this.$Stage = this.$StagesList.find(this.$StageId);
					}
				} else {
					this.$Stage = null;
				}
			},

			/**
			 * @inheritDoc BasePageV2#onEntityInitialized
			 * @overridden
			 */
			onEntityInitialized: function(callback, scope) {
				this.callParent(arguments);
				this.initDcmActionsDashboard(BPMSoft.emptyFn, this);
			},

			/**
			 * @inheritDoc BasePageV2#init
			 * @overridden
			 */
			init: function(callback, scope) {
				if (!this.get("StagesList")) {
					this.set("StagesList", this.Ext.create("BPMSoft.Collection"));
					this.set("StagesLookupList", this.Ext.create("BPMSoft.Collection"));
				}
				this.callParent(arguments);
			},

			/**
			 * Returns dcm view esq.
			 * @protected
			 * @virtual
			 * @returns {BPMSoft.EntitySchemaQuery} Request.
			 */
			getDcmInfoESQ: function() {
				const esq = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "VwSysDcmLib"
				});
				esq.addColumn("UId");
				esq.addColumn("PackageUId");
				esq.addColumn("StageColumnUId");
				esq.addColumn("EntitySchemaUId")
				return esq;
			},

			/**
			 * Sets actions primary column names.
			 * @protected
			 */
			setActionsPrimaryColumnNames: function(callback, scope) {
				const actionsSchemaName = this.get("ActionsSchemaName");
				BPMSoft.require([actionsSchemaName], function(response) {
					if (response) {
						this.set("ActionsPrimaryColumnName", response.primaryColumnName);
						this.set("ActionsPrimaryDisplayColumnName", response.primaryDisplayColumnName);
					}
					Ext.callback(callback, scope || this);
				}, this);
			},
			
			/**
			 * Loads values into  sync interval combobox.
			 * @param {Object} filter ComboboxEdit value.
			 * @param {BPMSoft.Collection} list List of comboboxEdit values.
			 */
			prepareStagesList: function(filter, list) {
				if (list === null) {
					return;
				}
				list.clear();
				list.loadAll(this.getStagesList());
			},

			/**
			 * Returns collection of sync intervals.
			 * @return {BPMSoft.Collection} List of sync intervals.
			 */
			getStagesList: function() {
				if (this.$StagesList && !this.$StagesList.isEmpty()) {
					return this.$StagesList;
				}
				const list = Ext.create("BPMSoft.Collection");
				const stages = this.get("StageLookupData");
				const availableStages = this.get("AvailableStages");
				BPMSoft.each(availableStages, function(model) {
					const key = model.stageRecordId;
					const stageCaption = stages[key];
					if (stageCaption) {
						list.add(key, {
							displayValue: stageCaption,
							value: key
						});
					}
				}, this);
				return list;
			},

			/**
			 * @inheritDoc BPMSoft.LookupQuickAddMixin#getLookupPageConfig
			 * @overriden
			 */
			getLookupPageConfig: function() {
				const config = this.callParent(arguments);
				if (this.isCaseLookupColumn(config.columnName)) {
					config.entitySchemaName = "VwSysDcmLib";
				}
				return config;
			},

			/**
			 * Checks if the given column is reference to SysSchema.
			 * @param {String} columnName Name of lookup case column.
			 * @returns {Boolean} Is case lookup column.
			 */
			isCaseLookupColumn: function (columnName) {
				const column = this.columns[columnName];
				return column && column.referenceSchemaName === "SysSchema";
			},

			/**
			 * @inheritDoc BPMSoft.BaseViewModel#getEntitySchemaQuery
			 * @override
			 */
			getEntitySchemaQuery: function() {
				const esq = this.callParent(arguments);
				esq.addColumn("StageId");
				return esq;
			},


			/**
			 * @private
			 */
			initDcmActionsDashboard: function(callback, scope) {
				this.BPMSoft.chain(
					this._getDcmView,
					this._processDcmView,
					function() {
						Ext.callback(callback, scope);
					}, this
				);
			}

			//endregion
			
		},
		mixins: {
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "CultureField",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 1,
						"layoutName": "Header"
					},
					"bindTo": "Culture",
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Case",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 2,
						"layoutName": "Header"
					},
					"bindTo": "Case"
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "Stage",
				"parentName": "Header",
				"propertyName": "items",
				"index": 3,
				"values": {
					"layout": {
						"column": 0,
						"row": 3,
						"rowSpan": 1,
						"colSpan": 11,
					},
					"bindTo": "Stage",
					"contentType": BPMSoft.ContentType.ENUM,
					"labelConfig": {
						"caption": {"bindTo": "Resources.Strings.StageCaption"},
					},
					"controlConfig": {
						"className": "BPMSoft.ComboBoxEdit",
						"prepareList": {"bindTo": "prepareStagesList"},
						"list": {"bindTo": "StagesLookupList"}
					}
				}
			},
		
		]/**SCHEMA_DIFF*/
	};
});
