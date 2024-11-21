/**
 * Parent: BaseGridDetailV2
 */
define("VisaDetailV2", ["VisaDetailV2Resources", "VisaHelper", "ConfigurationConstants", "SecurityUtilities"
], function(resources, VisaHelper, ConfigurationConstants) {
	return {
		attributes: {
			/**
			 * Flag to show all visas includes Canceled.
			 */
			"IsShowAll": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: true
			},
			/**
			 * The name of the operation, access to which should be the user to use the page.
			 */
			"SecurityOperationName": {
				dataValueType: BPMSoft.DataValueType.STRING,
				value: "CanManageUsers"
			},
			/**
			 * Flag to show only visas which current user have to process.
			 */
			"IsShowOnlyMyApproval": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				onChange: "onIsShowOnlyMyApprovalChange",
				value: false
			}
		},
		mixins: {
			SecurityUtilitiesMixin: "BPMSoft.SecurityUtilitiesMixin"
		},
		methods: {
			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#linkClicked
			 * @override
			 */
			linkClicked: function(recordId, columnName, href, callParentOnLinkClicked) {
				if (callParentOnLinkClicked) {
					this.callParent(arguments);
					return false;
				}
				if (columnName === "VisaOwner" || columnName === "DelegatedFrom") {
					BPMSoft.chain(
						this.checkAvailability,
						function() {
							this.linkClicked(recordId, columnName, href, true);
						},
						this
					);
				} else {
					return this.callParent(arguments);
				}
				return false;
			},

			/**
			 * Approval of the selected record.
			 * @private
			 */
			approve: function() {
				var activeRow = this.getActiveRow();
				if (!this.checkState(activeRow)) {
					return;
				}
				VisaHelper.approveAction(activeRow, this.visaHelperActionsCallBack, this);
			},

			/**
			 * Checks state of visa.
			 * @private
			 * @param {BPMSoft.BaseViewModel} entity Selected row.
			 * @return {Boolean} State of visa.
			 */
			checkState: function(entity) {
				var status = entity.get("Status");
				if (entity.get("IsCanceled") === true) {
					this.showInformationDialog(this.get("Resources.Strings.IsCanceled"));
					return false;
				}
				if (status.value === ConfigurationConstants.VisaStatus.positive.value) {
					this.showInformationDialog(this.get("Resources.Strings.ApproveYet"));
					return false;
				}
				if (status.value === ConfigurationConstants.VisaStatus.negative.value) {
					this.showInformationDialog(this.get("Resources.Strings.RejectingYet"));
					return false;
				}
				return true;
			},

			/**
			 * Rejected approval.
			 * @private
			 */
			reject: function() {
				var activeRow = this.getActiveRow();
				if (!this.checkState(activeRow)) {
					return;
				}
				VisaHelper.rejectAction(activeRow, this.visaHelperActionsCallBack, this);
			},

			/**
			 * Changes approver.
			 * @private
			 */
			changeVizier: function() {
				var activeRow = this.getActiveRow();
				var id = activeRow.get("Id");
				var visaEntityName = activeRow.entitySchema.name;
				VisaHelper.changeVizierAction(id, visaEntityName, this.sandbox, null,
					this.visaHelperActionsCallBack, this);
			},

			/**
			 * Returns caption of button.
			 * @private
			 * @return {String} Caption of button.
			 */
			getCaptionShowAll: function() {
				return this.get("IsShowAll")
					? this.get("Resources.Strings.ShowActualCaption")
					: this.get("Resources.Strings.ShowAllCaption");
			},

			/**
			 * Shows all actual approvals.
			 * @private
			 */
			showAllActualVisas: function() {
				this.set("IsShowAll", !this.get("IsShowAll"));
				this.reloadGridData();
				this._setProfileKey("IsShowAll");
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getFilters
			 * @override
			 */
			getFilters: function() {
				var filters = this.callParent(arguments);
				if (this.get("IsShowOnlyMyApproval")) {
					filters.addItem(BPMSoft.createColumnFilterWithParameter(
						"[SysAdminUnitInRole:SysAdminUnitRoleId:VisaOwner].SysAdminUnit",
						BPMSoft.SysValue.CURRENT_USER.value));
					var filterGroup = new BPMSoft.FilterGroup({
						logicalOperation: BPMSoft.LogicalOperatorType.OR
					});
					var isNullFilterExpression = new BPMSoft.ColumnExpression({
						columnPath: "Status"
					});
					filterGroup.addItem(BPMSoft.createIsNullFilter(isNullFilterExpression));
					filterGroup.addItem(BPMSoft.createColumnFilterWithParameter("Status.IsFinal", false));
					filters.addItem(filterGroup);
				}
				if (this.get("IsShowOnlyMyApproval") || !this.get("IsShowAll")) {
					filters.addItem(BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "IsCanceled", false));
				}
				return filters;
			},

			/**
			 * @inheritdoc GridUtilitiesV2#getGridDataColumns
			 * @override
			 */
			getGridDataColumns: function() {
				var gridDataColumns = this.callParent(arguments);
				if (!gridDataColumns.IsCanceled) {
					gridDataColumns.IsCanceled = {
						path: "IsCanceled"
					};
				}
				if (!gridDataColumns.Status) {
					gridDataColumns.Status = {
						path: "Status"
					};
				}
				return gridDataColumns;
			},

			/**
			 * Enables/Disables "ChangeVizier" menu item.
			 * @protected
			 * @return {Boolean} Enabled flag.
			 */
			setEnableVisaOwnerMenuActions: function() {
				if (this.getEditRecordButtonEnabled()) {
					var record = this.getActiveRow();
					var status = record.get("Status");
					this.getGridDataColumns();
					var isCanceled = record.get("IsCanceled");
					if (status.displayValue === ConfigurationConstants.VisaStatus.positive.displayValue ||
						status.displayValue === ConfigurationConstants.VisaStatus.negative.displayValue ||
						isCanceled) {
						return false;
					}
					return true;
				}
			},

			/**
			 * Handling action "Send for approval".
			 * @protected
			 * @param {Object} result Result of action.
			 */
			addCallBack: function(result) {
				var activeRow = this.getActiveRow();
				var primaryColumnValue = activeRow.get("Id");
				var selectedRow = result.selectedRows.getByIndex(0);
				var update = Ext.create("BPMSoft.UpdateQuery", {
					rootSchema: this.entitySchema
				});
				update.enablePrimaryColumnFilter(primaryColumnValue);
				update.setParameterValue("DelegatedFrom", activeRow.get("VisaOwner").value);
				update.setParameterValue("VisaOwner", selectedRow.value);
				update.execute(function(response) {
					if (response.success) {
						activeRow.set("DelegatedFrom", activeRow.get("VisaOwner"));
						activeRow.set("VisaOwner", selectedRow);
					}
				}, this);
			},

			/**
			 * Handling VisaHelper callback.
			 * @private
			 * @param {Object} response Response from VisaHelper.
			 * @param {Object} updateObject Data for update field.
			 */
			visaHelperActionsCallBack: function(response) {
				if (!response.success) {
					return;
				}
				var activeRow = this.getActiveRow();
				this.loadGridDataRecord(activeRow.get("Id"), function() {
					this.fireDetailChanged();
				}, this);
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#addRecordOperationsMenuItems
			 * @override
			 */
			addRecordOperationsMenuItems: function(toolsButtonMenu) {
				this.callParent(arguments);
				toolsButtonMenu.addItem(this.getButtonMenuItem({
					Caption: {bindTo: "Resources.Strings.Approve"},
					Click: {bindTo: "approve"},
					Enabled: {bindTo: "getEditRecordButtonEnabled"},
					ImageConfig: this.get("Resources.Images.ApproveImage")
				}), 0);
				toolsButtonMenu.addItem(this.getButtonMenuItem({
					Caption: {bindTo: "Resources.Strings.Reject"},
					Click: {bindTo: "reject"},
					Enabled: {bindTo: "getEditRecordButtonEnabled"},
					ImageConfig: this.get("Resources.Images.RejectImage")
				}), 1);
				toolsButtonMenu.addItem(this.getButtonMenuItem({
					Caption: {bindTo: "Resources.Strings.ChangeVisaOwner"},
					Click: {bindTo: "changeVizier"},
					Enabled: {bindTo: "setEnableVisaOwnerMenuActions"},
					ImageConfig: this.get("Resources.Images.ChangeVizierImage")
				}), 2);
				toolsButtonMenu.addItem(this.getButtonMenuItem({
					Caption: {bindTo: "getCaptionShowAll"},
					Click: {bindTo: "showAllActualVisas"},
					Enabled: {
						bindTo: "IsShowOnlyMyApproval",
						bindConfig: {converter: "invertBooleanValue"}
					}
				}), 3);
				toolsButtonMenu.addItem(this.getButtonMenuSeparator(), 4);
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getCopyRecordMenuItem
			 * @override
			 */
			getCopyRecordMenuItem: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.GridUtilitiesV2#getFilterDefaultColumnName
			 * @override
			 */
			getFilterDefaultColumnName: function() {
				return "VisaOwner";
			},

			/**
			 * @private
			 */
			_setProfileKey: function(property) {
				var profile = this.getProfile();
				var key = this.getProfileKey();
				if (this.isNotEmpty(profile) && this.isNotEmpty(key)) {
					profile[property] = this.get(property);
					this.set(this.getProfileColumnName(), profile);
					BPMSoft.utils.saveUserProfile(key, profile, false);
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseDetailV2#initFilterProfile
			 * @override
			 */
			initFilterProfile: function() {
				this.callParent(arguments);
				var profile = this.getProfile();
				if (profile) {
					this.set("IsShowAll", profile.IsShowAll);
					this.set("IsShowOnlyMyApproval", profile.IsShowOnlyMyApproval, {silent: true});
				}
			},

			/**
			 * Handler on change IsShowOnlyMyApproval attribute.
			 * @protected
			 */
			onIsShowOnlyMyApprovalChange: function() {
				this._setProfileKey("IsShowOnlyMyApproval");
				this.reloadGridData();
			}

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "DataGrid",
				"values": {
					"type": "listed",
					"listedConfig": {
						"name": "DataGridListedConfig",
						"items": [
							{
								"name": "ObjectiveListedGridColumn",
								"bindTo": "Objective",
								"position": {
									"column": 1,
									"colSpan": 24
								},
								"type": BPMSoft.GridCellType.TITLE
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
								"name": "ObjectiveTiledGridColumn",
								"bindTo": "Objective",
								"position": {
									"row": 1,
									"column": 1,
									"colSpan": 24
								},
								"type": BPMSoft.GridCellType.TITLE
							}
						]
					}
				}
			},
			{
				"operation": "remove",
				"name": "AddRecordButton"
			},
			{
				"operation": "insert",
				"parentName": "Detail",
				"propertyName": "items",
				"index": 0,
				"name": "ToolsFilterContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["detail-tools-filters-container"],
					"visible": {"bindTo": "getToolsVisible"},
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "ToolsFilterContainer",
				"propertyName": "items",
				"name": "ShowOnlyMyApprovalCheckbox",
				"values": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"bindTo": "IsShowOnlyMyApproval",
					"labelConfig": {"caption": {"bindTo": "Resources.Strings.ShowOnlyMyApprovalCaption"}}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
