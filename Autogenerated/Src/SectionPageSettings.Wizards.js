/**
 * Parent: BaseSectionPageSettings
 */
define("SectionPageSettings", [
	"SectionPageSettingsResources",
], function(resources) {
	return {
		messages: {
			"SaveSectionVisaSettings": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		methods: {

			// region Methods: Private
			// endregion

			// region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BaseSectionPageSettings#onBeforeSectionPageWiazardOpen
			 * @override
			 */
			onBeforeSectionPageWiazardOpen: function(callback, scope) {
				this.sandbox.publish("SaveSectionVisaSettings", callback);
			}

			// endregion

			// region Methods: Public
			// endregion

		},
		diff: []
	};
});
