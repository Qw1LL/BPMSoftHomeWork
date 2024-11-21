define("DcmUserTaskSchema", ["ext-base", "BPMSoft"], function(Ext, BPMSoft) {

	/**
	 * @class BPMSoft.manager.DcmUserTaskSchema
	 */
	Ext.define("BPMSoft.manager.DcmUserTaskSchema", {

		extend: "BPMSoft.UserTaskSchema",

		alternateClassName: "BPMSoft.DcmUserTaskSchema",

		//region Properties: Protected

		/**
		 * @inheritdoc BPMSoft.manager.UserTaskSchema#editPageSchemaUIdPropertyName.
		 * @overridden
		 */
		editPageSchemaUIdPropertyName: "dcmParametersEditPageSchemaV2UId"

		//endregion

	});

	return BPMSoft.DcmUserTaskSchema;

});

