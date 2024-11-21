define("DcmProcessSubprocessSchema", ["ext-base", "BPMSoft"], function(Ext, BPMSoft) {
	/**
	 * @class BPMSoft.manager.DcmProcessSubprocessSchema
	 */
	Ext.define("BPMSoft.manager.DcmProcessSubprocessSchema", {
		extend: "BPMSoft.ProcessSubprocessSchema",
		alternateClassName: "BPMSoft.DcmProcessSubprocessSchema",

		/**
		 * @inheritdoc BPMSoft.manager.ProcessSubprocessSchema#editPageSchemaName
		 * @overridden
		 */
		editPageSchemaName: "DcmSubProcessPropertiesPage",

		/**
		 * Dcm small image name.
		 * @protected
		 * @type {String}
		 */
		dcmSmallImageName: "dcm_subprocess_small.svg"

	});
	return BPMSoft.manager.DcmProcessSubprocessSchema;
});
