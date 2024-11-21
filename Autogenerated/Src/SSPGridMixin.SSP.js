define("SSPGridMixin", ["GridUtilitiesV2"], function() {
	/**
	 * SSPGridMixin mixin class.
	 * Provides methods for grid handling in ssp sections.
	 * @class BPMSoft.FileImportMixin
	 */
	Ext.define("BPMSoft.SSPGridMixin", {
		alternateClassName: "BPMSoft.configuration.mixins.SSPGridMixin",

		// region Methods: Protected

		/**
		 * Decorates gridSettingsInfo by portal config.
		 * @protected
		 * @param {Object} gridSettingsInfo Portal grid settings config object.
		 */
		applyPortalGridSettingsInfo: function(gridSettingsInfo) {
			gridSettingsInfo.firstColumnsOnly = true;
			gridSettingsInfo.useBackwards = false;
			const schemaAccessList = this.BPMSoft.configuration.PortalSchemaAccessList;
			const primaryColumnName = gridSettingsInfo.entitySchema.primaryColumnName;
			if (schemaAccessList.hasOwnProperty(gridSettingsInfo.entitySchemaName)) {
				const entityColumns = gridSettingsInfo.entitySchema.columns;
				for (var column in entityColumns) {
					if ((column !== primaryColumnName) && this.Ext.isEmpty(this.BPMSoft.findWhere(
						schemaAccessList[gridSettingsInfo.entitySchemaName].explorerAllowedColumns,
						{uId: entityColumns[column].uId}))) {
						delete gridSettingsInfo.entitySchema.columns[column];
					}
				}
			} else {
				const columns = gridSettingsInfo.entitySchema.columns;
				for (var columnName in columns) {
					if(columns.hasOwnProperty(columnName)){
						const primaryDisplayColumnName = gridSettingsInfo.entitySchema.primaryDisplayColumnName;
						if (columnName !== primaryColumnName && columnName !== primaryDisplayColumnName) {
							delete gridSettingsInfo.entitySchema.columns[columnName];
						}
					}
				}
			}
		},

		// endregion

		// region Methods: Public

		/**
		 * Gets allowed column uids for current portal user.
		 * @public
		 * @param {string} entitySchemaName Object entity schema name.
		 * @return {Array|null} Array of allowed column uids for current portal user.
		 */
		getAllowedColumns: function(entitySchemaName) {
			if (BPMSoft.isCurrentUserSsp() && BPMSoft.Features.getIsEnabled("PortalColumnConfig")) {
				const schemaAccessList = BPMSoft.configuration.PortalSchemaAccessList;
				if (!schemaAccessList.hasOwnProperty(entitySchemaName)) {
					return [];
				}
				const currentSchemaAccessList = schemaAccessList[entitySchemaName];
				return currentSchemaAccessList.explorerAllowedColumns;
			}
			return null;
		}

		// endregion


	});
});
