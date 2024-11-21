define("ScoringModelSectionV2", [],
	function() {
		return {
			entitySchemaName: "ScoringModel",
			attributes: {
				"CanManageBpCloudIntegrationSettings": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false
				}
			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/,
			messages: {},
			methods: {
				/**
				 * @inheritdoc BPMSoft.GridUtilitiesV2#getFilters
				 * @overridden
				 */
				getFilters: function() {
					var filterGroup = this.callParent(arguments);
					filterGroup.add("ScoringObjectIsInCurrentWorkspace",
						BPMSoft.createColumnFilterWithParameter(
							BPMSoft.ComparisonType.EQUAL, "ScoringObject.SysWorkspace.Id",
							BPMSoft.SysValue.CURRENT_WORKSPACE.value, BPMSoft.DataValueType.TEXT));
					return filterGroup;
				},

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#getCanDesignSection
				 * @overridden
				 */
				getCanDesignSection: function() {
					return false;
				},

				loadGridDataRecord: function(primaryColumnValue, callback, scope) {
					var performanceManagerLabel = "loadGridDataRecord";
					if (scope && scope.hasOwnProperty("sandbox")) {
						performanceManagerLabel = scope.sandbox.id + "_" + performanceManagerLabel;
					} else if (this && this.hasOwnProperty("sandbox")) {
						performanceManagerLabel = this.sandbox.id + "_" + performanceManagerLabel;
					}
					performanceManager.start(performanceManagerLabel);
					var esq = this.getGridDataESQ();
					this.initQueryColumns(esq);
					esq.filters.addItem(this.getFilters());
					this.initQueryEvents(esq);
					var gridData = this.getGridData();
					if (gridData.contains(primaryColumnValue)) {
						var activeRow = gridData.get(primaryColumnValue);
						esq.getEntity(primaryColumnValue, function(response) {
							this.destroyQueryEvents(esq);
							if (!response.success) {
								performanceManager.stop(performanceManagerLabel);
								return;
							}
							var entity = response.entity;
							var activeRowColumns = activeRow.columns;
							this.BPMSoft.each(entity.columns, function(column, columnName) {
								if (activeRowColumns.hasOwnProperty(columnName)) {
									activeRow.set(columnName, entity.get(columnName));
								}
							}, this);
							if (this.Ext.isFunction(callback)) {
								performanceManager.stop(performanceManagerLabel);
								callback.call(scope || this);
							}
							this.onDataChanged();
						}, this);
						performanceManager.stop(performanceManagerLabel);
					} else {
						this.beforeLoadGridDataRecord();
						esq.getEntityCollection(function(response) {
							this.destroyQueryEvents(esq);
							this.afterLoadGridDataRecord();
							if (!response.success) {
								performanceManager.stop(performanceManagerLabel);
								return;
							}
							var responseCollection = response.collection;
							this.prepareResponseCollection(responseCollection);
							this.initIsGridEmpty(responseCollection);
							this.addItemsToGridData(responseCollection, this.getAddRowsOptions());
							if (this.get("IsGridDataLoaded") !== true || this.get("IsGridLoading") === true) {
								this.set("PreloadedGridDataRecords", responseCollection.getKeys());
							}
							this.afterLoadGridDataUserFunction(primaryColumnValue);
							this.onDataChanged();
							if (this.Ext.isFunction(callback)) {
								performanceManager.stop(performanceManagerLabel);
								callback.call(scope || this);
							}
							performanceManager.stop(performanceManagerLabel);
						}, this);
						performanceManager.stop(performanceManagerLabel);
					}
				},

				/**
				 * @inheritdoc BPMSoft.BaseViewModel#copyEntity
				 * @overridden
				 */
				copyRecord: function(primaryColumnValue) {
					this.showBodyMask();
					var scoringModel = this.createSectionEntity();
					scoringModel.set("SourceModel", {value: primaryColumnValue});
					var onEntityCopied = scoringModel.saveEntity.bind(scoringModel, this.onCopyRecordSaved, this);
					scoringModel.copyEntity(primaryColumnValue, onEntityCopied, scoringModel);
				},

				/**
				 * Handles saving of the copied record.
				 * @param {Object} result Result of the save operation.
				 */
				onCopyRecordSaved: function(result) {
					if (result.success) {
						this.set("ActiveRow", null);
						var recordId = result.id;
						this.editRecord(recordId);
					} else {
						this.hideBodyMask();
					}
				},

				/**
				 * Creates instance of the EntitySchema of section.
				 * @returns {BPMSoft.BaseViewModel} Instance of the EntitySchema of section.
				 */
				createSectionEntity: function() {
					var entitySchema = this.entitySchema;
					var columns = BPMSoft.DataManager.getViewModelColumns(entitySchema.columns);
					return this.Ext.create("BPMSoft.BaseViewModel", {
							entitySchema: entitySchema,
							columns: columns}
					);
				},

				/**
				 * Opens bpmcrm Cloud Integration settings page.
				 */
				openBpCloudIntegrationPage: function() {
					this.sandbox.publish("PushHistoryState", {hash: "CardModuleV2/BpCloudIntegrationPageV2"});
				},

				/**
				 * Creates "OpenBpCloudIntegrationPage" menu item.
				 * @return {BPMSoft.BaseViewModel} Menu item.
				 */
				createOpenBpCloudIntegrationPageMenuItem: function() {
					return this.getButtonMenuItem({
						Click: {bindTo: "openBpCloudIntegrationPage"},
						Caption: {bindTo: "Resources.Strings.GoToBpCloudIntegrationCaption"},
						Visible: {bindTo: "CanManageBpCloudIntegrationSettings"}
					});
				},

				/**
				 * @inheritDoc BPMSoft.BaseSectionV2#getSectionActions
				 * @overridden
				 */
				getSectionActions: function() {
					var actionMenuItems = this.Ext.create("BPMSoft.BaseViewModelCollection");
					var parentActionMenuItems = this.callParent(arguments);
					parentActionMenuItems.get("Item7").values.Visible = false;
					parentActionMenuItems.each(function(item) {
						actionMenuItems.addItem(item);
					}, this);
					actionMenuItems.addItem(this.createOpenBpCloudIntegrationPageMenuItem());
					return actionMenuItems;
				},

				/**
				 * Initializes "initCanManageBpCloudIntegrationSettings" property.
				 * @private
				 */
				initCanManageBpCloudIntegrationSettings: function() {
					this.checkCanExecuteOperation("CanManageBpCloudIntegrationSettings",
						this.setCanManageBpCloudIntegrationSettings, this);
				},

				/**
				 * Sets value of the "CanManageBpCloudIntegrationSettings" property.
				 * @private
				 * @param {Boolean} value.
				 */
				setCanManageBpCloudIntegrationSettings: function(value) {
					this.set("CanManageBpCloudIntegrationSettings", value);
				},

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#init
				 * @overridden
				 */
				init: function() {
					this.callParent(arguments);
					this.initCanManageBpCloudIntegrationSettings();
				}
			}
		};
	});
