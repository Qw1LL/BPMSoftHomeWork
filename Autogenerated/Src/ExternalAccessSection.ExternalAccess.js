define("ExternalAccessSection", [
	"ExternalAccessUtilities"
], function() {
	return {
		entitySchemaName: "ExternalAccess",
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "DataGridActiveRowCopyAction",
				"values": {
					"visible": false
				}
			},
			{
				"operation": "merge",
				"name": "DataGridActiveRowDeleteAction",
				"values": {
					"visible": false
				}
			}
		]/**SCHEMA_DIFF*/,
		mixins: {
			ExternalAccessUtilities: "BPMSoft.ExternalAccessUtilities"
		},
		methods: {

			/**
			 * Reloads rows for deactivated records.
			 * @param {Object} responseObject Response of service that deactivates external accesses.
			 * @param {String[]} accessIds Accesses to deactivate.
			 * @private
			 */
			_processDeactivationResponse: function(responseObject, accessIds) {
				if (!BPMSoft.isEmptyObject(responseObject)) {
					const rows = this.getGridData();
					BPMSoft.each(accessIds, function(accessId) {
						const row = rows.find(accessId);
						if (row) {
							row.loadEntity(accessId);
						}
					});
				}
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilities#getGridDataColumns
			 * @override
			 */
			getGridDataColumns: function() {
				const defColumnsConfig = this.callParent(arguments);
				defColumnsConfig.IsActive = {
					path: "IsActive"
				};
				return defColumnsConfig;
			},

			/**
			 * @override
			 * @inheritdoc
			 */
			getSectionActions: function() {
				const actionMenuItems = this.callParent(arguments);
				actionMenuItems.addItem(this.getButtonMenuItem({
					Type: "BPMSoft.MenuSeparator",
					Caption: BPMSoft.emptyString
				}));
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Caption": {"bindTo": "getDeactivationActionCaption"},
					"Click": {"bindTo": "deactivateExternalAccessRecord"},
					"Enabled": {"bindTo": "getIsDeactivationActionEnabled"},
					"IsEnabledForSelectedAll": true
				}));
				return actionMenuItems;
			},

			/**
			 * @override
			 * @inheritdoc
			 */
			isVisibleDeleteAction: function() {
				return false;
			},

			/**
			 * Returns whether deactivation action should be active
			 * @return {Boolean} Whether deactivation action should be active.
			 */
			getIsDeactivationActionEnabled: function() {
				if (this.$MultiSelect) {
					return true;
				}
				const selectedAccess = this.getActiveRow();
				return selectedAccess && selectedAccess.$IsActive;
			},

			/**
			 * Deactivates selected access record.
			 */
			deactivateExternalAccessRecord: function() {
				const accessIds = this.getSelectedItems();
				if (accessIds) {
					this.deactivateAccesses(accessIds, function(responseObject) {
						this._processDeactivationResponse(responseObject, accessIds);
					}, this);
				}
			}

		}
	};
});
