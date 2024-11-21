define("SocialFeed", ["OperatorSingleWindowSocialMessageViewModel"], function() {
		return {
			methods: {

				/**
				 * @inheritdoc BPMSoft.SocialFeedUtilities#getSocialMessageViewModelName
				 */
				getSocialMessageViewModelName: function() {
					return "BPMSoft.OperatorSingleWindowSocialMessageViewModel";
				}

			}
		};
	});
