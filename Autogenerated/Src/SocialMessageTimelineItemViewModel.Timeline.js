define("SocialMessageTimelineItemViewModel", ["BaseTimelineItemViewModel",
		"SocialMessageTimelineItemViewModelResources"
	],
	function() {
		/**
		 * @class BPMSoft.configuration.SocialMessageTimelineItemViewModel
		 * Social message timeline item view model class.
		 */
		Ext.define("BPMSoft.configuration.SocialMessageTimelineItemViewModel", {
			alternateClassName: "BPMSoft.SocialMessageTimelineItemViewModel",
			extend: "BPMSoft.BaseTimelineItemViewModel",

			// region Methods: Protected

			/**
			 * Initializes message url.
			 * @protected
			 */
			initMessageUrl: function() {
				var message = this.get("Message");
				message = BPMSoft.stripTags(message);
				message = message.trim();
				if (BPMSoft.isUrl(message)) {
					this.set("MessageUrl", message);
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseTimelineItemViewModel#initDefaultValues
			 * @override
			 */
			initDefaultValues: function() {
				this.callParent(arguments);
				this.set("ShowAuthorIcon", true);
				this.set("UseAuthorCaption", true);
				this.initMessageUrl();
			},

			// endregion

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
