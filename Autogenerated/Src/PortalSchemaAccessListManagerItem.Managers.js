define("PortalSchemaAccessListManagerItem", [], function() {

	/**
	 * @class BPMSoft.PortalSchemaAccessListManagerItem
	 */

	Ext.define("BPMSoft.PortalSchemaAccessListManagerItem", {
		extend: "BPMSoft.ObjectManagerItem",
		alternateClassName: "BPMSoft.PortalSchemaAccessListManagerItem",

		// region Properties: Public

		/**
		 * Entity schema unique identifier.
		 * @type {String}
		 */
		entitySchemaUId: null,

		/**
		 *  Entity schema name.
		 * @type {String}
		 */
		entitySchemaName: null

		// endregion

	});

	return BPMSoft.PortalSchemaAccessListManagerItem;
});
