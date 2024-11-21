define("ProductSectionV2", [],
	function() {
		return {
			entitySchemaName: "Product",
			methods: {
				/**
				 * ############# ############# ########### #######.
				 * @protected
				 */
				initContextHelp: function() {
					this.set("ContextHelpId", 1056);
					this.callParent(arguments);
				},
				/**
				 * ########## ######### ############# ####### ## #########
				 * @protected
				 * @overriden
				 */
				getDefaultGridDataViewCaption: function() {
					var moduleStructure = BPMSoft.configuration.ModuleStructure[this.entitySchemaName];
					return (moduleStructure && moduleStructure.moduleCaption) ?
						moduleStructure.moduleCaption :
						this.get("Resources.Strings.PageCaption");
				}
			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	});
