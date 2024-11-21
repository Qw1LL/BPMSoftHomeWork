define("DcmElementSchemaManager", ["ext-base", "BPMSoft", "DcmUserTaskSchemaManager",
	"DcmSchemaElement", "DcmProcessSubprocessSchema"], function(Ext, BPMSoft) {
	/**
	 * @class BPMSoft.manager.DcmElementSchemaManager
	 * DCM flow element schema manager.
	 */
	Ext.define("BPMSoft.manager.DcmElementSchemaManager", {

		extend: "BPMSoft.BaseProcessFlowElementSchemaManager",

		alternateClassName: "BPMSoft.DcmElementSchemaManager",

		singleton: true,

		/**
		 * @inheritdoc BPMSoft.BaseSchemaManager#managerName
		 * @overridden
		 */
		managerName: "DcmElementSchemaManager",

		/**
		 * @inheritdoc BPMSoft.BaseProcessFlowElementSchemaManager#userTaskSchemaManagerName
		 * @overridden
		 */
		userTaskSchemaManagerName: "DcmUserTaskSchemaManager",

		/**
		 * @inheritdoc BPMSoft.BaseProcessFlowElementSchemaManager#notImplementedElementsFeatureCode
		 * @overridden
		 */
		notImplementedElementsFeatureCode: "DcmNotImplementedElements",

		/**
		 * @inheritdoc BPMSoft.BaseProcessFlowElementSchemaManager#notImplementedElementNames
		 * @protected
		 * @overridden
		 */
		notImplementedElementNames: [],

		/**
		 * @inheritdoc BPMSoft.BaseProcessFlowElementSchemaManager#coreElementClassNames
		 * @protected
		 * @overridden
		 */
		coreElementClassNames: [
			{
				itemType: "BPMSoft.DcmProcessSubprocessSchema",
				initialConfig: {
					isValid: false
				}
			}
		]

	});
	return BPMSoft.DcmElementSchemaManager;
});
