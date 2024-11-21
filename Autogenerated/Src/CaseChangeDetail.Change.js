define("CaseChangeDetail", ["ConfigurationEnums"],
	function() {
		return {
			entitySchemaName: "Case",
			methods: {
				/**
				 * ############## ######### ######.
				 */
				initConfig: function() {
					this.callParent(arguments);
					var config = this.getConfig();
					config.lookupEntitySchema = "Case";
					config.lookupConfig.hideActions = true;
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
	});
