define("LeadDetailV2", ["css!LeadDetailModule", "ControlGridModule", "BaseProgressBarModule",
		"css!BaseProgressBarModule"],
	function() {
		return {
			entitySchemaName: "Lead",
			attributes: {
				/**
				 * ####### ########### ########### #######.
				 * @type {Boolean}
				 */
				CanShowDataGrid: {
					dataValueType: BPMSoft.DataValueType.BOOLEAN
				}
			},
			methods: {
				/**
				 * ######### ####### ########### ########### #######.
				 */
				updateCanShowDataGrid: function() {
					var masterRecordId = this.get("MasterRecordId");
					var canShowDataGrid = (masterRecordId && masterRecordId !== null);
					this.set("CanShowDataGrid", canShowDataGrid);
				},

				/**
				 * @inheritDoc BPMSoft.Configuration.BaseDetailV2#getToolsVisible
				 * @overridden
				 */
				getToolsVisible: function() {
					return (!this.get("IsDetailCollapsed") && this.get("CanShowDataGrid"));
				},

				/**
				 * @inheritDoc BPMSoft.Configuration.BaseDetailV2#updateDetail
				 * @overridden
				 */
				updateDetail: function(config) {
					config.reloadAll = true;
					this.callParent(arguments);
					this.updateCanShowDataGrid();
				},

				/**
				 * Sets default values to launch lead management process.
				 */
				addDefaultValues: function() {
					var defValues = this.get("DefaultValues");
					defValues.push({
						name: "StartLeadManagementProcess",
						value: true
					});
					this.set("DefaultValues", defValues);
				},

				/**
				 * @inheritDoc BPMSoft.Configuration.BaseDetailV2#init
				 * @overridden
				 */
				init: function(callback, scope) {
					this.updateCanShowDataGrid();
					this.addDefaultValues();
					this.callParent([
						function() {
							callback.call(scope);
						},
						this
					]);
				},

				/**
				 * ##### ######## ## ###### ###### ######## ##########.
				 * @param {Object} control ###### ########## ###### ########.
				 * @overridden
				 */
				applyControlConfig: function(control) {
					control.config = {
						className: "BPMSoft.BaseProgressBar",
						value: {
							"bindTo": "QualifyStatus",
							"bindConfig": {"converter": "getQualifyStatusValue"}
						},
						width: "158px"
					};
				},

				/**
				 * @inheritdoc BPMSoft.GridUtilitiesV2#addColumnLink
				 * @overridden
				 */
				addColumnLink: function(item) {
					item.getQualifyStatusValue = function(qualifyStatus) {
						if (!qualifyStatus) {
							return null;
						} else {
							return {
								value: this.get("QualifyStatus.StageNumber"),
								displayValue: qualifyStatus.displayValue
							};
						}
					};
					return this.callParent(arguments);
				},

				/**
				 * @inheritdoc BPMSoft.GridUtilitiesV2#getGridDataColumns
				 * @overridden
				 */
				getGridDataColumns: function() {
					var gridDataColumns = this.callParent(arguments);
					gridDataColumns["QualifyStatus.StageNumber"] =
						gridDataColumns["QualifyStatus.StageNumber"] || {path: "QualifyStatus.StageNumber"};
					return gridDataColumns;
				},

				getIsCanShowDataGrid: function(canShowDataGrid) {
					return !canShowDataGrid;
				},

				/**
				 * @inheritdoc BPMSoft.GridUtilitiesV2#getFilterDefaultColumnName
				 * @overridden
				 */
				getFilterDefaultColumnName: function() {
					return "LeadType";
				},

				/**
				 * @inheritDoc BPMSoft.BaseGridDetailV2#getOpenCardConfig
				 * @overridden
				 */
				getOpenCardConfig: function() {
					var config = this.BPMSoft.deepClone(this.callParent(arguments));
					var defaultValues = config && config.defaultValues ? config.defaultValues : null;
					if (defaultValues && !this.hasQualifiedEntities(defaultValues)) {
						this.addParentQualifiedEntities(defaultValues);
					}
					return config;
				},

				/**
				 * Returns true if list have QualifiedContact or QualifiedAccount.
				 * @private
				 * @param {Array} list Array of default values.
				 * @return {Boolean} True if list have QualifiedContact or QualifiedAccount.
				 */
				hasQualifiedEntities: function(list) {
					var values = list.filter(function(item) {
						return item.name === "QualifiedContact" || item.name === "QualifiedAccount";
					});
					return values.length !== 0;
				},

				/**
				 * Adds QualifiedContact and QualifiedAccount to default values if they exists.
				 * @private
				 * @param {Array} defaultValues Default values.
				 */
				addParentQualifiedEntities: function(defaultValues) {
					var parentViewModelValues = this.sandbox.publish("GetColumnsValues", ["Contact", "Account"],
							[this.sandbox.id]);
					if (parentViewModelValues) {
						this.BPMSoft.each(parentViewModelValues, function(item, itemName) {
							if (item && item.value) {
								var valueName = "Qualified" + itemName;
								defaultValues.push({
									name: valueName,
									value: item.value
								});
							}
						}, this);
					}
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "DataGrid",
					"parentName": "Detail",
					"propertyName": "items",
					"values": {
						"className": "BPMSoft.ControlGrid",
						"controlColumnName": "QualifyStatus",
						"applyControlConfig": {"bindTo": "applyControlConfig"},
					}
				},
				{
					"operation": "insert",
					"name": "EmptyEntityLabel",
					"parentName": "Detail",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"classes": {
							"labelClass": ["t-label ts-empty-entity-label"]
						},
						"caption": {"bindTo": "Resources.Strings.EmptyEntityLabel"},
						"visible": {
							"bindTo": "CanShowDataGrid",
							"bindConfig": {"converter": "getIsCanShowDataGrid"}
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
