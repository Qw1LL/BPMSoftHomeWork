define("ContentBuilderElementViewModelFactory", ["BPMSoft", "ContentBuilderBlockViewModel",
		"ContentBuilderSeparatorElementViewModel", "ContentBuilderButtonElementViewModel",
		"ContentBuilderHtmlElementViewModel", "ContentBuilderImageElementViewModel",
		"ContentBuilderTextElementViewModel", "ContentBuilderNavbarElementViewModel",
		"ContentBuilderSpacerElementViewModel", "ContentBuilderConstants"],
	function() {

	/**
	 * @class BPMSoft.ContentBuilderElementViewModelFactory
	 */
	Ext.define("BPMSoft.ContentBuilderElementViewModelFactory", {

		// #region Methods: Public

		/**
		 * Returns list of default (predefined) grid elements.
		 * @public
		 * @return {BPMSoft.BaseViewModelCollection} Content block.
		 */
		getPredefinedElements: function() {
			var elements = new BPMSoft.BaseViewModelCollection();
			elements.add(Ext.create("BPMSoft.ContentBuilderBlockViewModel"));
			elements.add(Ext.create("BPMSoft.ContentBuilderImageElementViewModel"));
			elements.add(Ext.create("BPMSoft.ContentBuilderTextElementViewModel"));
			elements.add(Ext.create("BPMSoft.ContentBuilderButtonElementViewModel"));
			elements.add(Ext.create("BPMSoft.ContentBuilderHtmlElementViewModel"));
			elements.add(Ext.create("BPMSoft.ContentBuilderSeparatorElementViewModel"));
			elements.add(Ext.create("BPMSoft.ContentBuilderNavbarElementViewModel"));
			elements.add(Ext.create("BPMSoft.ContentBuilderSpacerElementViewModel"));
			return elements;
		}

		// #endregion

	});
});
