define("ServiceItemSection", [],
function() {
	return {
		entitySchemaName: "ServiceItem",
		ContextHelpId: "1061",
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/,
		messages: {},
		methods: {
			/**
			 * ############# ############# ########### #######.
			 * @protected
			 */
			initContextHelp: function() {
				this.set("ContextHelpId", 1061);
				this.callParent(arguments);
			}
		}
	};
});
