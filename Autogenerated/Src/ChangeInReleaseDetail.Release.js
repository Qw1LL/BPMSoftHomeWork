define("ChangeInReleaseDetail", [],
	function() {
		return {
			entitySchemaName: "Change",
			methods: {
				/**
				 * ############## ######### ######.
				 */
				initConfig: function() {
					this.callParent(arguments);
					var config = this.getConfig();
					config.lookupEntitySchema = "Change";
					config.sectionEntitySchema = "Release";
				},
				/**
				 * ######### #############.
				 */
				init: function() {
					this.callParent(arguments);
					this.initConfig();
				}
			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	}
);
