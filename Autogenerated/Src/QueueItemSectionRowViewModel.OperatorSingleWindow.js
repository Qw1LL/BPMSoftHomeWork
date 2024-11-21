define("QueueItemSectionRowViewModel", ["BaseSectionGridRowViewModel"], function() {

	/**
	 * View class model - Queue items section list string
	 * @class BPMSoft.configuration.QueueItemSectionRowViewModel
	 */
	Ext.define("BPMSoft.configuration.QueueItemSectionRowViewModel", {
		extend: "BPMSoft.configuration.BaseSectionGridRowViewModel",
		alternateClassName: "BPMSoft.QueueItemSectionRowViewModel",

		//region Methods: Protected

		/**
		 * Returns "Take it" button visibility.
		 * @protected
		 */
		getRunProcessButtonVisible: function() {
			return !this.get("Status.IsFinal");
		}

		//endregion

	});
	return BPMSoft.QueueItemSectionRowViewModel;
});
