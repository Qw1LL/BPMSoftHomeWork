define("SysModuleInWorkplaceDetailV2", [], function() {
	return {
		methods: {

			/**
			 * @inheritdoc
			 * @overridden
			 */
			getHiddenModuleCodes: function() {
				var codes = this.callParent(arguments) || [];
				return codes.concat("Queue");
			}
		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
