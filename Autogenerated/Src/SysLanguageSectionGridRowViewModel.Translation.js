define("SysLanguageSectionGridRowViewModel", ["ext-base", "BaseSectionGridRowViewModel"], function(Ext) {

	/**
	 * @class BPMSoft.configuration.SysLanguageSectionGridRowViewModel
	 */
	Ext.define("BPMSoft.configuration.SysLanguageSectionGridRowViewModel", {
		extend: "BPMSoft.BaseSectionGridRowViewModel",
		alternateClassName: "BPMSoft.SysLanguageSectionGridRowViewModel",

		/**
		 * @inheritdoc BPMSoft.BaseSectionGridRowViewModel#constructor
		 * Adds primary image value to language.
		 * @overridden
		 */
		constructor: function() {
			this.callParent(arguments);
			var image = this.get("Image");
			if (image && image.value) {
				var language = this.get("Language");
				language.primaryImageValue = image.value;
			}
		}
	});

	return BPMSoft.SysLanguageSectionGridRowViewModel;
});
