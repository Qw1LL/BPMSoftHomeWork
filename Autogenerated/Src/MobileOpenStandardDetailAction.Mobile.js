/**
 * @class BPMSoft.configuration.action.OpenStandardDetail
 */
Ext.define("BPMSoft.configuration.action.OpenStandardDetail", {
	alternateClassName: "BPMSoft.configuration.OpenStandardDetailAction",
	extend: "BPMSoft.ActionBase",

	config: {

		/**
		 * @cfg {String} detailModelName Model name.
		 */
		detailModelName: null,

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
		BPMSoft.util.openStandardDetail({
			detailModelName: this.getDetailModelName(),
			parentRecord: record
		});
		this.executionEnd(true);
	}

});
