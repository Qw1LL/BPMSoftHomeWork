define("PortalEntitySchemaFilterProviderModule", ["BPMSoft", "EntitySchemaFilterProviderModule"],
	function (BPMSoft) {
		/**
		 * @class BPMSoft.data.filters.PortalEntitySchemaFilterProvider
		 * Portal entity schema start filters provider.
		 */
		Ext.define("BPMSoft.data.filters.PortalEntitySchemaFilterProvider", {
			extend: "BPMSoft.EntitySchemaFilterProvider",
			alternateClassName: "BPMSoft.PortalEntitySchemaFilterProvider",


			//region Methods: Private

			/**
			 * Get allowed column uids for current portal user.
			 * @private
			 * @returns {Array} Array of allowed column uids for current portal user
			 */
			_getAllowedColumns: function() {
				var schemaAccessList = BPMSoft.configuration.PortalSchemaAccessList;
				var rootSchemaName = this.rootSchemaName;
				return schemaAccessList.hasOwnProperty(rootSchemaName)
					? schemaAccessList[rootSchemaName].explorerAllowedColumns
					: [];
			},

			//endregion

			//region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.data.filters.EntitySchemaFilterProvider#getLeftExpressionConfig
			 * @overriden
			 */
			getLeftExpressionConfig: function () {
				var parentConfig = this.callParent(arguments);
				if (!BPMSoft.Features.getIsEnabled("PortalColumnConfig")){
					return parentConfig;
				}
				parentConfig.allowedColumns = this._getAllowedColumns();
				parentConfig.firstColumnsOnly = true;
				parentConfig.useBackwards = false;
				return parentConfig;
			},

			/**
			 * @inheritdoc BPMSoft.data.filters.EntitySchemaFilterProvider#getLookupFilterConfig
			 * @overriden
			 */
			getLookupFilterConfig: function() {
				var config = this.callParent(arguments);
				config.settingsButtonVisible = false;
				return config;
			}

			//endregion

		});
		return BPMSoft.PortalEntitySchemaFilterProvider;
	}
);
