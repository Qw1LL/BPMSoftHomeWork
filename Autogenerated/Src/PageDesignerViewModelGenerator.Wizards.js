define("PageDesignerViewModelGenerator", ["ViewModelSchemaDesignerViewModelGenerator"], function() {

	/**
	 * Page designer view model generator.
	 */
	Ext.define("BPMSoft.configuration.PageDesignerViewModelGenerator", {
		extend: "BPMSoft.configuration.ViewModelSchemaDesignerViewModelGenerator",
		alternateClassName: "BPMSoft.PageDesignerViewModelGenerator",

		// region Properties: Protected

		/**
		 * Flags that indicates whether designer is read only on not.
		 * @type {Boolean}
		 */
		isReadOnly: false

		// endregion

	});

	return BPMSoft.PageDesignerViewModelGenerator;
});
