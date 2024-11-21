define("SysModuleEntityManagerItem", ["SysModuleEntityManagerItemResources"], function() {

	/**
	 * @class BPMSoft.SysModuleEntityManagerItem
	 * ##### ######## ######### ##### #######.
	 */

	Ext.define("BPMSoft.SysModuleEntityManagerItem", {
		extend: "BPMSoft.ObjectManagerItem",
		alternateClassName: "BPMSoft.SysModuleEntityManagerItem",

		// region Properties: Private

		/**
		 * ############# ####### ####.
		 * @private
		 * @type {String}
		 */
		typeColumnUId: null,

		/**
		 * ############# entity #####.
		 * @private
		 * @type {String}
		 */
		entitySchemaUId: null,

		// endregion

		// region Methods: Public

		/**
		 * ##### ########## ######## ############## entity #####.
		 * @return {String} ########## ######## ############## entity #####.
		 */
		getEntitySchemaUId: function() {
			return this.getPropertyValue("entitySchemaUId");
		},

		/**
		 * ##### ############# ######## ############## entity #####.
		 * @param {String} value ############## entity #####.
		 */
		setEntitySchemaUId: function(value) {
			this.setPropertyValue("entitySchemaUId", value);
		},

		/**
		 * ########## ######### ######### ######### ####### #### ####### ### ##### #######.
		 * @param {Function} callback ####### ######### ######.
		 * @param {Object} scope ######## ###### callback-#######.
		 * @return {BPMSoft.Collection} ######### ######### ######### ####### #### ####### ### ##### #######.
		 */
		getSysModuleEditManagerItems: function(callback, scope) {
			BPMSoft.chain(
				function(next) {
					BPMSoft.SysModuleEditManager.initialize(next, this);
				},
				function() {
					var sysModuleEntityId = this.id;
					var sysModuleEditItems = BPMSoft.SysModuleEditManager.getItems();
					var sysModuleEditManagerItems = sysModuleEditItems.filterByFn(function(item) {
						return (item.getSysModuleEntityId() === sysModuleEntityId);
					});
					Ext.callback(callback, scope, [sysModuleEditManagerItems]);
				}, this
			);
		},

		/**
		 * ##### ########## ######## ############## ####### ####.
		 * @return {String} ########## ######## ############## ####### ####.
		 */
		getTypeColumnUId: function() {
			return this.getPropertyValue("typeColumnUId");
		},

		/**
		 * ##### ############# ######## ############## ####### ####.
		 * @param {String} value ######## ############## ####### ####.
		 */
		setTypeColumnUId: function(value) {
			this.setPropertyValue("typeColumnUId", value);
		}

		// endregion

	});

	return BPMSoft.SysModuleEntityManagerItem;

});
