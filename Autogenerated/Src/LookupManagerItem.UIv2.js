define("LookupManagerItem", ["SysModuleEntityManager", "AnalyticsManagerItem"], function() {

	/**
	 * @class BPMSoft.LookupManagerItem
	 * @public
	 * ##### ######## ######### .
	 */

	Ext.define("BPMSoft.manager.LookupManagerItem", {
		extend: "BPMSoft.AnalyticsManagerItem",
		alternateClassName: "BPMSoft.LookupManagerItem",

		// region Properties: Private

		/**
		 * #########.
		 * @protected
		 * @type {String}
		 */
		name: null,

		/**
		 * ########.
		 * @protected
		 * @type {String}
		 */
		description: null,

		/**
		 * ############# ##### ######.
		 * @private
		 * @type {String}
		 */
		sysPageSchemaUId: null,

		/**
		 * ############# entity ##### ######.
		 * @private
		 * @type {String}
		 */
		sysEntitySchemaUId: null,

		/**
		 * ###### ## SysLookup.
		 * @private
		 * @type {String}
		 */
		sysLookup: null,

		// endregion

		// region Methods: Public

		/**
		 * ##### ########## ######## ######### ########.
		 * @return {String} ######## #########.
		 */
		getName: function() {
			return this.getPropertyValue("name");
		},

		/**
		 * ##### ########## ######## ######## ########.
		 * @return {String} ######## ########.
		 */
		getDescription: function() {
			return this.getPropertyValue("description");
		},

		/**
		 * ##### ########## ######## ############## ########.
		 * @return {String} ############# ########.
		 */
		getSysPageSchemaUId: function() {
			return this.getPropertyValue("sysPageSchemaUId");
		},

		/**
		 * ##### ########## ######## ############## #####.
		 * @return {String} ############# #####.
		 */
		getSysEntitySchemaUId: function() {
			return this.getPropertyValue("sysEntitySchemaUId");
		},

		/**
		 * ##### ########## ######## ###### ## SysLookup.
		 * @return {String} ###### ## SysLookup.
		 */
		getSysLookup: function() {
			return this.getPropertyValue("sysLookup");
		},

		/**
		 * ##### ############# ######## ### ######### ########.
		 * @param {String} name #########.
		 */
		setName: function(name) {
			this.setPropertyValue("name", name);
		},


		/**
		 * ########## ####### ######### #### ####### ### ############# entity-##### ###########.
		 * @param {Function} callback ####### ######### ######.
		 * @param {Object} scope ######## ###### callback-#######.
		 * @return {BPMSoft.SysModuleEntityManagerItem} ####### ######### #### ####### ### #############
		 * entity-##### ###########.
		 */
		getSysModuleEntityManagerItems: function(callback, scope) {
			BPMSoft.SysModuleEntityManager.initialize(null, function() {
				BPMSoft.SysModuleEntityManager.findItemsByEntitySchemaUId(this.getSysEntitySchemaUId(), callback, scope);
			}, this);
		},

		/**
		 * @inheritdoc BPMSoft.AnalyticsManagerItem#getModifiedString
		 * @override
		 */
		getModifiedString: function() {
			return (this.getIsDeleted() ? "-" : "+") + this.getName();
		}

		// endregion

	});

	return BPMSoft.LookupManagerItem;

});
