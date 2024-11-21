 define("CampaignTemplateGalleryViewModel", ["CampaignTemplateGalleryViewModelResources"],
	function(resources) {
	Ext.define("BPMSoft.configuration.CampaignTemplateGalleryViewModel", {
		extend: "BPMSoft.BaseViewModel",
		alternateClassName: "BPMSoft.CampaignTemplateGalleryViewModel",

		Ext: null,
		BPMSoft: null,
		sandbox: null,

		messages: {
			/**
			 * @message CampaignTemplateSelected
			 * Emit campaign template selected action.
			 */
			"CampaignTemplateSelected": {
				"mode": this.BPMSoft.MessageMode.PTP,
				"direction": this.BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message CampaignTemplateSelected
			 * Emit campaign template selected action.
			 */
			"CampaignTemplateGalleryCanceled": {
				"mode": this.BPMSoft.MessageMode.PTP,
				"direction": this.BPMSoft.MessageDirectionType.PUBLISH
			}
		},

		/**
		 * @inheritDoc BPMSoft.BaseViewModel#constructor
		 * @protected
		 * @override
		 */
		constructor: function() {
			this.callParent(arguments);
			this.sandbox.registerMessages(this.messages);
		},

		onTemplateSelected: function(templateId) {
			this.sandbox.publish("CampaignTemplateSelected", templateId, [this.sandbox.id]);
		},

		onGalleryViewCanceled: function() {
			this.sandbox.publish("CampaignTemplateGalleryCanceled", null, [this.sandbox.id]);
		}

	});

	return BPMSoft.CampaignTemplateGalleryViewModel;

});
