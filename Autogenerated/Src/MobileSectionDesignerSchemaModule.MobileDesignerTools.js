define("MobileSectionDesignerSchemaModule", ["BaseSchemaModuleV2"], function() {
	/**
	 * @class BPMSoft.configuration.MobileSectionDesignerSchemaModule
	 * ##### ######## ######### ########## ##########.
	 */
	Ext.define("BPMSoft.configuration.MobileSectionDesignerSchemaModule", {
		alternateClassName: "BPMSoft.MobileSectionDesignerSchemaModule",
		extend: "BPMSoft.BaseSchemaModule",

		/**
		 * ### ######## ######## ##### ########## ##########
		 * @public
		 * @type {String}
		 */
		workplace: "",

		/**
		 * ### ######## ######## ##### ########## ##########
		 * @public
		 * @type {String}
		 */
		workplaceTypeId: "",

		/**
		 * ############## ######## #####.
		 * @protected
		 * @overridden
		 */
		initSchemaName: function() {
			this.schemaName = "MobileSectionDesignerModule";
		},

		/**
		 * ####### ###### #############
		 * @protected
		 * @overridden
		 * @param {Object} viewModelClass ##### ###### ############# #####
		 * @return {Object} ########## ######### ###### ############# #####
		 */
		createViewModel: function() {
			var viewModel = this.callParent(arguments);
			viewModel.set("Workplace", this.workplace);
			viewModel.set("WorkplaceTypeId", this.workplaceTypeId);
			return viewModel;
		}

	});
	return BPMSoft.MobileSectionDesignerSchemaModule;
});
