define("PortalMessageTimelineItemViewModel", ["BaseTimelineItemViewModel",
		"PortalMessageTimelineItemViewModelResources"
	],
	function() {
		/**
		 * @class BPMSoft.configuration.PortalMessageTimelineItemViewModel
		 * Portal message timeline item view model class.
		 */
		Ext.define("BPMSoft.configuration.PortalMessageTimelineItemViewModel", {
			alternateClassName: "BPMSoft.PortalMessageTimelineItemViewModel",
			extend: "BPMSoft.BaseTimelineItemViewModel",

			// region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BaseTimelineItemViewModel#initDefaultValues
			 * @override
			 */
			initDefaultValues: function() {
				this.callParent(arguments);
				this.set("ShowAuthorIcon", true);
				this.set("UseAuthorCaption", true);
			}

			// endregion

		});
	});
