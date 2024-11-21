/**
 * Generates view config for visa detail.
 */
Ext.define("BPMSoft.configuration.VisaEmbeddedDetailGenerator", {
	extend: "BPMSoft.EmbeddedDetailGenerator",

	/**
	 * @inheritdoc
	 * @protected
	 * @override
	 */
	generateItem: function() {
		var config = this.callParent(arguments);
		config.xtype = "cfvisaedetailitem";
		config.parentModelName = this.getCardGenerator().getModelName();
		return config;
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @override
	 */
	generate: function() {
		var config = this.callParent(arguments);
		var cardGenerator = this.getCardGenerator();
		var isEdit = cardGenerator.isEdit();
		if (isEdit || !BPMSoft.Features.getIsEnabled("UseMobileApprovals")) {
			return null;
		}
		return config;
	}

});