define("DcmProcessUserTaskSchema", ["ext-base", "BPMSoft"], function(Ext, BPMSoft) {

	/**
	 * @class BPMSoft.manager.DcmProcessUserTaskSchema
	 */
	Ext.define("BPMSoft.manager.DcmProcessUserTaskSchema", {

		extend: "BPMSoft.ProcessUserTaskSchema",

		alternateClassName: "BPMSoft.DcmProcessUserTaskSchema",

		//region Properties: Protected

		/**
		 * @inheritdoc BPMSoft.manager.ProcessUserTaskSchema#taskSchemaManagerName
		 * @overridden
		 */
		taskSchemaManagerName: "DcmUserTaskSchemaManager",

		/**
		 * @inheritdoc BPMSoft.manager.ProcessUserTaskSchema#taskSchemaManagerName
		 * @overridden
		 */
		elementManagerName: "DcmElementSchemaManager",

		/**
		 * Dcm small image name.
		 * @protected
		 * @type {String}
		 */
		dcmSmallImageName: "DcmSmallSvgImage.svg"

		//endregion

	});

	return BPMSoft.DcmProcessUserTaskSchema;

});
