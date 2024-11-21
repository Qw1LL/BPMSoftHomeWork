define("ConfItemSection", ["GridUtilitiesV2"],
function() {
	return {
		entitySchemaName: "ConfItem",
		contextHelpId: "1001",
		diff: /**SCHEMA_DIFF*/[],/**SCHEMA_DIFF*/
		messages: {},
		methods: {

			/**
			 * ############# ############# ########### #######.
			 * @protected
			 */
			initContextHelp: function() {
				this.set("ContextHelpId", 1065);
				this.callParent(arguments);
			}
		}
	};
});
