Ext.define("BPMSoft.configuration.ActionAddFileAndLinks", {
	extend: "BPMSoft.ActionBase",

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	execute: function(record, pageConfig) {
		this.callParent(arguments);
		var config = this.config;
		var embeddedDetailId = BPMSoft.util.getColumnSetId(record.modelName, config.detailName, pageConfig.viewMode);
		var embeddedDetail = Ext.getCmp(embeddedDetailId);
		embeddedDetail.setIsCollapsed(false);
		embeddedDetail.fireEvent("additem", embeddedDetail);
		this.executionEnd(true);
	}

});
