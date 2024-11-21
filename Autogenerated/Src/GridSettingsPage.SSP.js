define("GridSettingsPage", ["SSPGridMixin"], function() {
	return {

		mixins: {
			/**
			 * Provides methods for grid handling in ssp sections.
			 */
			"SSPGridMixin": "BPMSoft.SSPGridMixin"
		},

		methods: {

			// region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.GridSettingsPage#initGridSettingsParams
			 * @overridden
			 */
			initGridSettingsParams: function() {
				this.callParent(arguments);
				if (this.BPMSoft.isCurrentUserSsp()) {
					let gridSettingsInfo = this.sandbox.publish("GetGridSettingsInfo", null, [this.sandbox.id]);
					if (!this.Ext.isEmpty(gridSettingsInfo) && this.getIsFeatureEnabled("PortalColumnConfig")) {
						this.applyPortalGridSettingsInfo(gridSettingsInfo);
						this.useBackwards = gridSettingsInfo.useBackwards;
						this.firstColumnsOnly = gridSettingsInfo.firstColumnsOnly;
					}
				}
			}

			// endregion

		},
		diff: []
	};
});
