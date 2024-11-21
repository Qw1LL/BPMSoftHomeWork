define("ContentBlockSectionGridRowViewModel", ["ext-base", "ContentBlockSectionGridRowViewModelResources",
	"BaseSectionGridRowViewModel"], function(Ext) {

	/**
	 * @class BPMSoft.configuration.ContentBlockSectionGridRowViewModel
	 */
	Ext.define("BPMSoft.configuration.ContentBlockSectionGridRowViewModel", {
		extend: "BPMSoft.BaseSectionGridRowViewModel",
		alternateClassName: "BPMSoft.ContentBlockSectionGridRowViewModel",

		/**
		 * @inheritDoc BPMSoft.BaseViewModel#getLookupImageUrl
		 * @overridden
		 */
		getLookupImageUrl: function(lookupColumnName) {
			var lookupColumn = this.findEntityColumn(lookupColumnName) || this.getColumnByName(lookupColumnName);
			if (!lookupColumn || !lookupColumn.isLookup) {
				throw new BPMSoft.UnsupportedTypeException();
			}
			var lookupColumnValue = this.get(lookupColumnName);
			var value = lookupColumnValue.value;
			if (!value) {
				return null;
			}
			var imageConfig = {
				source: BPMSoft.ImageSources.SYS_IMAGE,
				params: {
					primaryColumnValue: value
				}
			};
			return BPMSoft.ImageUrlBuilder.getUrl(imageConfig);
		}
	});

	return BPMSoft.ContentBlockSectionGridRowViewModel;
});
