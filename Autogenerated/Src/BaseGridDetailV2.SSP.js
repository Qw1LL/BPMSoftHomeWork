 define("BaseGridDetailV2", ["SSPGridMixin"], function() {
	return {
		mixins: {
			/**
			 * Provides methods for grid handling in ssp sections.
			 */
			"SSPGridMixin": "BPMSoft.SSPGridMixin"
		},

		methods: {

			//region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.GridUtilitiesV2#initData
			 * Initializes collection of the data view.
			 * @protected
			 * @override
			 */
			initData: function(callback, scope) {
				this.$IsImportDisabled = this.BPMSoft.isCurrentUserSsp();
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getExtendedFilterConfig
			 * @protected
			 * @override
			 */
			getExtendedFilterConfig: function() {
				let config = this.callParent(arguments);
				config.hasExtendedMode = !this.BPMSoft.isCurrentUserSsp();
				config.allowedColumns = this.mixins.SSPGridMixin.getAllowedColumns(this.entitySchemaName);
				return config;
			},

			//endregion

		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
