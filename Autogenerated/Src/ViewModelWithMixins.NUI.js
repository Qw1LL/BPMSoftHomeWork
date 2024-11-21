define("ViewModelWithMixins", ["PanelEmptyListMixin", "MiniPageUtilities"],
	function() {
		/**
		 * @class BPMSoft.configuration.ViewModelWithMixins
		 * The ViewModelWithMixins class is used for creating new instances of notifications view model with
		 * mixin PanelEmptyListMixin.
		 */
		Ext.define("BPMSoft.configuration.ViewModelWithMixins", {
			extend: "BPMSoft.BaseViewModel",
			alternateClassName: "BPMSoft.ViewModelWithMixins",
			mixins: {
				PanelEmptyListMixin: "BPMSoft.PanelEmptyListMixin",
				/**
				 * @class MiniPageUtilities Mixin, used for Mini Pages
				 */
				MiniPageUtilitiesMixin: "BPMSoft.MiniPageUtilities"
			}
		});
	});
