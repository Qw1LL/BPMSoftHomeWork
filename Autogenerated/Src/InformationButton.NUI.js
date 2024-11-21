define("InformationButton", ["ext-base", "BPMSoft", "InformationButtonResources", "css!InformationButton"],
		function(Ext, BPMSoft, resources) {
	/**
	 * @class BPMSoft.controls.InformationButton
	 * InformationButton class.
	 */
	Ext.define("BPMSoft.controls.InformationButton", {
		extend: "BPMSoft.Button",
		alternateClassName: "BPMSoft.InformationButton",

		/**
		 * @inheritdoc BPMSoft.Button#prefix
		 * @type {String}
		 */
		prefix: "t-information-btn t-btn",

		/**
		 * @inheritdoc BPMSoft.Button#style
		 * @type {BPMSoft.controls.ButtonEnums.style}
		 */
		style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,

		/**
		 * @inheritdoc BPMSoft.Button#iconAlign
		 * @type {BPMSoft.controls.ButtonEnums.iconAlign}
		 */
		iconAlign: BPMSoft.controls.ButtonEnums.iconAlign.LEFT,

		init: function() {
			this.callParent(arguments);
			this.imageConfig = this.imageConfig || this.getDefaultImageConfig();
		},

		/**
		 * Returns default image configuration.
		 * @return {Object}
		 */
		getDefaultImageConfig: function() {
			return resources.localizableImages.DefaultIcon;
		}
	});
});

