define("MailServerViewModel", ["BPMSoft", "MailServerViewModelResources"], function(BPMSoft, resources) {

	/**
	 * @class BPMSoft.configuration.MailServerViewModel
	 */
	Ext.define("BPMSoft.configuration.MailServerViewModel", {
		extend: "BPMSoft.model.BaseViewModel",
		alternateClassName: "BPMSoft.MailServerViewModel",

		/**
		 * Gets mail server image.
		 * @return {Object}
		 */
		getMailServerImage: function() {
			var imageConfig;
			var logo = this.get("Logo");
			if (logo) {
				imageConfig = {
					source: BPMSoft.ImageSources.SYS_IMAGE,
					params: {
						primaryColumnValue: logo.value
					}
				};
			} else {
				imageConfig = resources.localizableImages.DefaultLogo;
			}
			return {
				source: BPMSoft.ImageSources.URL,
				url: BPMSoft.ImageUrlBuilder.getUrl(imageConfig)
			};
		}
	});
	return BPMSoft.MailServerViewModel;
});
