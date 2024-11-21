define("FeatureItemViewModel", ["FeatureItemViewModelResources"], function(resources) {
	/**
	 * @class BPMSoft.configuration.FilterItemViewModel
	 * Feature item view model class.
	 */
	Ext.define("BPMSoft.configuration.FeatureItemViewModel", {
		extend: "BPMSoft.BaseViewModel",
		alternateClassName: "BPMSoft.FeatureItemViewModel",

		Ext: null,
		BPMSoft: null,
		sandbox: null,

		/**
		 * Initializes features view model class..
		 * @protected
		 */
		init: function() {
			this.addEvents(
				/**
				 * @event
				 * Change feature state event.
				 * @param {BPMSoft.FeatureItemViewModel} viewModel View model of feature item.
				 */
				"changeFeatureState"
			);
			this.initButtonCaption();
		},

		/**
		 * Initializes feature state button caption.
		 * @private
		 */
		initButtonCaption: function() {
			var featureState = this.get("FeatureState");
			if (featureState === BPMSoft.FeatureState.ENABLED) {
				this.set("SwitchStateButtonCaption", resources.localizableStrings.DisableFeatureCaption);
			} else {
				this.set("SwitchStateButtonCaption", resources.localizableStrings.EnableFeatureCaption);
			}
		},

		/**
		 * Handler for change feature state button click.
		 * @protected
		 */
		onChangeFeatureStateClick: function() {
			var featureCode = arguments[3] || this.get("Code");
			var featureEnabled = BPMSoft.Features.getIsEnabled(featureCode);
			this.set("FeatureState", featureEnabled ? BPMSoft.FeatureState.DISABLED : BPMSoft.FeatureState.ENABLED);
			this.initButtonCaption();
			this.fireEvent("changeFeatureState", this);
		}
	});

	return BPMSoft.FeatureItemViewModel;
});
