define("ProblemChangeDetail", ["ConfigurationEnums"],
	function() {
		return {
			entitySchemaName: "Problem",
			methods: {
				/**
				 * ############## ######### ######.
				 */
				initConfig: function() {
					this.callParent(arguments);
					var config = this.getConfig();
					config.lookupEntitySchema = "Problem";
					config.sectionEntitySchema = "Change";
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
