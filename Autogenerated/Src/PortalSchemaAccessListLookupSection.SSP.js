define("PortalSchemaAccessListLookupSection", ["BusinessRuleModule", "PortalSchemaAccessListLookupSectionResources",
			"ConfigurationEnums", "ConfigurationGrid", "ConfigurationGridGenerator",
			"ConfigurationGridUtilities"],
		function(BusinessRuleModule, resources) {
			return {
				entitySchemaName: "PortalSchemaAccessList",
				attributes: {
					"SysEntitySchema": {
						dataValueType: BPMSoft.DataValueType.LOOKUP,
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					}
				},
				mixins: {
					ConfigurationGridUtilites: "BPMSoft.ConfigurationGridUtilities"
				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "merge",
						"name": "DataGrid",
						"parentName": "DataGridContainer",
						"propertyName": "items",
						"values": {
							"columnsConfig": [
								{
									"cols": 24,
									"key": [
										{
											"name": {"bindTo": "SysEntitySchema"}
										}
									]
								}
							],
							"captionsConfig": [
								{
									"cols": 24,
									"name": resources.localizableStrings.AccessEntitySchemaCaption
								}
							]
						}
					},
					{
						"operation": "remove",
						"name": "DataGridActiveRowCopyAction"
					},
					{
						"operation": "remove",
						"name": "activeRowActionCopy"
					},
					{
						"operation": "merge",
						"name": "SeparateModeViewOptionsButton",
						"values": {"visible": false}
					},
					{
						"operation": "merge",
						"name": "SortMenuContainer",
						"values": {"visible": false}
					}
				]/**SCHEMA_DIFF*/,
				messages: {},
				methods: {

					/**
					 * @inheritdoc BPMSoft.GridUtilitiesV2#generateEntityProfile
					 * @overridden
					 */
					generateEntityProfile: function() {
						return {};
					},

					/**
					 * @inheritdoc BPMSoft.GridUtilities#initQueryColumns
					 * @overridden
					 */
					initQueryColumns: function(esq) {
						this.callParent(arguments);
						esq.addColumn("[VwSysSchemaInfo:UId:SchemaUId].Caption", "SysEntitySchema");
					},

					/**
					 * @inheritDoc BasePageV2#initActionButtonMenu
					 * @overridden
					 */
					initActionButtonMenu: function() {
						this.set("ActionsButtonVisible", false);
					},

					/**
					 * @inheritDoc BPMSoft.GridUtilities#getGridRowViewModelConfig
					 * @overridden
					 */
					getGridRowViewModelConfig: function(config) {
						this.applyGridRowViewModelConfig(config);
						return this.callParent(arguments);
					},

					/**
					 * Find and replace SysEntitySchema property.
					 * @private
					 * @param {Object} config Properties of the view model class.
					 */
					applyGridRowViewModelConfig: function(config) {
						var rowData = config.rawData;
						if (rowData && rowData.hasOwnProperty("SysEntitySchema")) {
							rowData.SysEntitySchema = {
								displayValue: rowData.SysEntitySchema,
								value: rowData.SysEntitySchemaUId
							};
						}
						var rowConfig = config.rowConfig;
						if (rowConfig && rowConfig.hasOwnProperty("SysEntitySchema")) {
							this.Ext.apply(rowConfig.SysEntitySchema, {
								dataValueType: this.BPMSoft.DataValueType.LOOKUP,
								isLookup: true,
								referenceSchemaName: "VwSysSchemaInfo"
							});
						}
					},

					/**
					 * @inheritdoc BPMSoft.ConfigurationGridUtilites#getCellControlsConfig
					 * @overridden
					 */
					getCellControlsConfig: function() {
						var controlsConfig =
								this.mixins.ConfigurationGridUtilities.getCellControlsConfig.apply(this, arguments);
						if (!this.get("IsAddMode")) {
							this.Ext.apply(controlsConfig, {
								enabled: false
							});
						}
						return controlsConfig;
					},

					/**
					 * @inheritdoc BPMSoft.ConfigurationGridUtilities#createNewRow
					 * @overridden
					 */
					createNewRow: function() {
						this.set("IsAddMode", true);
						this.mixins.ConfigurationGridUtilities.createNewRow.apply(this, arguments);
						this.set("IsAddMode", false);
					},

					/**
					 * @inheritdoc BPMSoft.GridUtilities#getDefaultGridProfile
					 * @overridden
					 */
					applyDefaultGridProfile: this.BPMSoft.emptyFn
				}
			};
		});
