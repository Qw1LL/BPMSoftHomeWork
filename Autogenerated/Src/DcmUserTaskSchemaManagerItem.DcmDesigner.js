define("DcmUserTaskSchemaManagerItem", ["ext-base", "BPMSoft", "DcmProcessUserTaskSchema"], function(Ext, BPMSoft) {
	/**
	 * @class BPMSoft.manager.DcmUserTaskSchemaManagerItem
	 * Class for the dcm schema user task manager item.
	 */
	Ext.define("BPMSoft.manager.DcmUserTaskSchemaManagerItem", {

		extend: "BPMSoft.ProcessUserTaskSchemaManagerItem",

		alternateClassName: "BPMSoft.DcmUserTaskSchemaManagerItem",

		/**
		 * @inheritdoc BPMSoft.ProcessUserTaskSchemaManagerItem#instanceClassName.
		 * @overridden
		 */
		instanceClassName: "BPMSoft.DcmProcessUserTaskSchema"

	});

	return BPMSoft.DcmUserTaskSchemaManagerItem;

});
