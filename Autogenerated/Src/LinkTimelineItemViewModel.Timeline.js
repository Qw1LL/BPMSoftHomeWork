define("LinkTimelineItemViewModel", ["LinkTimelineItemViewModelResources", "BaseTimelineItemViewModel"],
	function() {
		/**
		 * @class BPMSoft.configuration.LinkTimelineItemViewModel
		 * Link timeline item view model class.
		 */
		Ext.define("BPMSoft.configuration.LinkTimelineItemViewModel", {
			alternateClassName: "BPMSoft.LinkTimelineItemViewModel",
			extend: "BPMSoft.BaseTimelineItemViewModel",

			// region Methods: Public

			/**
			 * Returns link preview visible value.
			 * @return {Boolean}
			 */
			getLinkPreviewVisible: function() {
				return !Ext.isEmpty(this.get("LinkPreviewData"));
			}

			// endregion

		});
	});
