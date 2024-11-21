define("PreviewableGridLayoutEdit", ["PreviewableGridLayoutEditResources",
		"PreviewableGridLayoutEditItem"], function() {

	/**
	 * Class of control element which changes grid element settings.
	 * @class BPMSoft.controls.GridLayoutEdit
	 */
	Ext.define("BPMSoft.controls.PreviewableGridLayoutEdit", {
		extend: "BPMSoft.GridLayoutEdit",
		alternateClassName: "BPMSoft.PreviewableGridLayouEdit",

		//region Methods: Public

		/**
		 * @inheritdoc BPMSoft.component#init
		 * @overridden
		 */
		init: function() {
			this.callParent(arguments);
			this.addEvents(
				"previewReady"
			);
		}

		//endregion

	});

	return BPMSoft.PreviewableGridLayouEdit;

});
