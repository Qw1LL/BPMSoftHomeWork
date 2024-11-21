/**
 * Parent: BaseOperationGranteeDetail
 */
define("ProcessExecutionGranteeDetail", ["InformationButtonResources", "RightsServiceHelper",
		"ProcessExecutionGranteeDetailResources", "css!ProcessExecutionGranteeDetailCSS"],
	function(InformationButtonResources, RightsServiceHelper, ProcessExecutionGranteeDetailResources) {
	return {
		entitySchemaName: "SysProcessSchemaOperationRight",
		mixins: {
			RightsServiceHelper: "BPMSoft.RightsServiceHelper"
		},
		methods: {

			//region Methods: Private

			/**
			 * @private
			 */
			_getRowById: function(itemId) {
				const gridData = this.getGridData();
				return gridData.get(itemId);
			},

			/**
			 * @private
			 */
			_getIsColumnEnabled: function(columnName) {
				return columnName === 'CanExecute';
			},

			/**
			 * @private
			 */
			_applyCustomCellConfig: function(config, entitySchemaColumn) {
				config.enabled = this._getIsColumnEnabled(entitySchemaColumn.name);
			},

			//endregion

			//region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BaseOperationGranteeDetail#checkCanChangeGrantee
			 * @overridden
			 */
			checkCanChangeGrantee: function(callbackAllow, callbackDenied, scope) {
				this.checkCanChangeProcessExecutionGrantee(callbackAllow, callbackDenied, scope);
			},

			/**
			 * @inheritdoc BPMSoft.BaseOperationGranteeDetail#deleteGrantees
			 * @overridden
			 */
			deleteGrantees: function(itemIds, callback, scope) {
				const processSchemaUId = this.get("MasterRecordId");
				const adminUnitIds = itemIds.map(function(itemId) {
					const row = this._getRowById(itemId);
					return row.get("SysAdminUnit").value;
				}, this);
				this.deleteProcessExecutionGrantees(processSchemaUId, adminUnitIds, callback, scope);
			},

			/**
			 * @inheritdoc BPMSoft.BaseOperationGranteeDetail#insertGrantees
			 * @overridden
			 */
			setOperationGrantees: function(adminUnitIds, canExecute, callback, scope) {
				const processSchemaUId = this.get("MasterRecordId");
				this.setProcessExecutionGrantees(processSchemaUId, adminUnitIds, canExecute, callback, scope);
			},

			/**
			 * @inheritdoc BPMSoft.BaseOperationGranteeDetail#setGranteePosition
			 * @overridden
			 */
			setGranteePosition: function(itemId, position, callback, scope) {
				const processSchemaUId = this.get("MasterRecordId");
				const row = this._getRowById(itemId);
				const adminUnitId = row.get("SysAdminUnit").value;
				this.setProcessExecutionGranteePosition(processSchemaUId, adminUnitId, position, callback, scope);
			},

			/**
			 * @inheritdoc BPMSoft.BaseOperationGranteeDetail#getAdminUnitLookupFilters
			 * @overridden
			 */
			getAdminUnitLookupFilters: function() {
				const filterGroup = this.callParent(arguments);
				const processSchemaUId = this.get("MasterRecordId");
				const operationFilter = this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL, "RootProcessSchemaUId", processSchemaUId);
				filterGroup.subFilters.addItem(operationFilter);
				return filterGroup;
			},

			/**
			 * @inheritdoc BPMSoft.ConfigurationGridUtilities#getIsRowChanged
			 * @overridden
			 */
			getIsRowChanged: function(row) {
				return (row instanceof BPMSoft.BaseViewModel) && row.isAttributeChanged("CanExecute");
			},

			/**
			 * @inheritdoc BPMSoft.ConfigurationGridUtilities#saveRowChanges
			 * @overridden
			 */
			saveRowChanges: function(row, callback, scope) {
				if (this.getIsRowChanged(row)) {
					const adminUnitId = row.$SysAdminUnit.value;
					const canExecute = row.$CanExecute;
					this.setOperationGrantees([adminUnitId], canExecute, function () {
						row.clearChangedValues();
						Ext.callback(callback, scope || this);
					}, this);
				} else {
					this.Ext.callback(callback, scope || this);
				}
			},

			/**
			 * @inheritdoc BPMSoft.ConfigurationGridUtilites#getCellControlsConfig
			 * @overridden
			 */
			getCellControlsConfig: function(entitySchemaColumn) {
				const config = this.callParent(arguments);
				this._applyCustomCellConfig(config, entitySchemaColumn);
				return config;
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getAddRecordButtonCaption
			 * @overridden
			 */
			getAddRecordButtonCaption: function() {
				return ProcessExecutionGranteeDetailResources.localizableStrings.AddNewMember;
			}

			//endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "Information",
				"parentName": "Detail",
				"propertyName": "tools",
				"values": {
					"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
					"behaviour": {"displayEvent": BPMSoft.TipDisplayEvent.CLICK},
					"content": {"bindTo": "Resources.Strings.LaunchRightsInfoTip"},
					"style": BPMSoft.TipStyle.WHITE,
					"controlConfig": {
						"imageConfig": InformationButtonResources.localizableImages.DefaultIcon,
						"classes": {"wrapperClass": ["information-button"]}
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
