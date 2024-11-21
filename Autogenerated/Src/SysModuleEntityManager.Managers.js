define("SysModuleEntityManager", ["SysModuleEntityManagerItem"], function() {
	/**
	 * @class BPMSoft.SysModuleEntityManager
	 * ##### ######### ##### #######.
	 */

	Ext.define("BPMSoft.SysModuleEntityManager", {
		extend: "BPMSoft.ObjectManager",
		alternateClassName: "BPMSoft.SysModuleEntityManager",
		singleton: true,

		//region Properties: Private

		/**
		 * ######## ###### ######## #########.
		 * @private
		 * {String}
		 */
		itemClassName: "BPMSoft.SysModuleEntityManagerItem",

		/**
		 * ######## #####.
		 * @private
		 * {String}
		 */
		entitySchemaName: "SysModuleEntity",

		/**
		 * ###### ############ ####### ########.
		 * @private
		 * @type {Object}
		 */
		propertyColumnNames: {
			entitySchemaUId: "SysEntitySchemaUId",
			typeColumnUId: "TypeColumnUId"
		},

		// endregion

		// region Methods: Public

		/**
		 * ########## ######### ######### ######### #### ####### ### entity-#####.
		 * @param {String} entitySchemaUId entity-#####.
		 * @param {Function} callback ####### ######### ######.
		 * @param {Object} scope ######## ###### callback-#######.
		 * @return {BPMSoft.SysModuleEntityManagerItem} ######### ######### ######### #### #######
		 * entity-##### ######.
		 */
		findItemsByEntitySchemaUId: function(entitySchemaUId, callback, scope) {
			BPMSoft.chain(
				function(next) {
					this.initialize(null, next, this);
				},
				function() {
					var filteredItems = this.items.filterByFn(function(item) {
						return (item.getEntitySchemaUId() === entitySchemaUId);
					});
					callback.call(scope, filteredItems);
				},
				this
			);
		}

		// endregion

	});

	return BPMSoft.SysModuleEntityManager;

});
