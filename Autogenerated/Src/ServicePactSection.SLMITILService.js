define("ServicePactSection", ["GridUtilitiesV2"],
function() {
	return {
		entitySchemaName: "ServicePact",
		contextHelpId: "1001",
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/,
		messages: {},
		methods: {

			/**
			 * ############# ############# ########### #######.
			 * @protected
			 */
			initContextHelp: function() {
				this.set("ContextHelpId", 1062);
				this.callParent(arguments);
			}
		}
	};
});
