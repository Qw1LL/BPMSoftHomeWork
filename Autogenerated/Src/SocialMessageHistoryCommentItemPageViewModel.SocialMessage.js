define("SocialMessageHistoryCommentItemPageViewModel", ["NetworkUtilities", "MiniPageUtilities",
		"SocialMessageHistoryCommentItemPageViewModelResources"],
	function(NetworkUtilities) {
		/**
		 * @class BPMSoft.configuration.SocialMessageHistoryCommentItemPageViewModel
		 * Comment to social message in history view model class.
		 */
		Ext.define("BPMSoft.configuration.SocialMessageHistoryCommentItemPageViewModel", {
			alternateClassName: "BPMSoft.SocialMessageHistoryCommentItemPageViewModel",
			extend: "BPMSoft.BaseModel",

			Ext: null,
			BPMSoft: null,
			sandbox: null,

			getCreatedOn: this.BPMSoft.abstractFn,
			openCreatedByPage: this.BPMSoft.abstractFn,
			getCreatedByImage: this.BPMSoft.abstractFn,
			getImageUrlByEntity: this.BPMSoft.abstractFn,
			getImageUrlById: this.BPMSoft.abstractFn,

			displayValueConverter: function(value) {
				return (value && value.displayValue) || Ext.emptyString;
			},

			contactToUrlConverter: function(contact) {
				if (!contact || !contact.value) {
					return Ext.emptyString;
				}
				return "ViewModule.aspx#" + NetworkUtilities.getEntityUrl("Contact", contact.value);
			}
		});
	});
