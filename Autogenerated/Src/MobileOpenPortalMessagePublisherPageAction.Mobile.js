/**
 * @class BPMSoft.configuration.action.OpenPortalMessagePublisherPage
 */
Ext.define("BPMSoft.configuration.action.OpenPortalMessagePublisherPage", {
	alternateClassName: "BPMSoft.configuration.OpenPortalMessagePublisherPageAction",
	extend: "BPMSoft.ActionBase",

	config: {

		/**
		 * @cfg {String} entitySchemaUId UId of schema.
		 */
		entitySchemaUId: null,

		/**
		 * @inheritdoc
		 */
		useMask: false

	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	execute: function(record) {
		this.callParent(arguments);
		BPMSoft.util.openCachedPage("PortalMessagePublisherPage", {
			entitySchemaUId: this.getEntitySchemaUId(),
			record: record
		});
		this.executionEnd(true);
	}

});
