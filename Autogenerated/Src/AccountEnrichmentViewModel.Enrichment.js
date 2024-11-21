define("AccountEnrichmentViewModel", ["BaseEnrichmentViewModel"], function() {
	Ext.define("BPMSoft.configuration.AccountEnrichmentViewModel", {
		alternateClassName: "BPMSoft.AccountEnrichmentViewModel",
		extend: "BPMSoft.configuration.BaseEnrichmentViewModel",

		/**
		 * Array of enriched data types without links.
		 * @protected
		 * @type {String[]}
		 */
		notLinkDataTags: ["phone", "email"],

		/**
		 * @inheritdoc BPMSoft.BaseEnrichmentViewModel#onLinkClick.
		 * @protected
		 * @overridden
		 */
		onLinkClick: function(path) {
			window.open(path);
			return false;
		},

		/**
		 * @inheritdoc BPMSoft.BaseEnrichmentViewModel#getIsLinkData.
		 * @protected
		 * @overridden
		 */
		getIsLinkData: function() {
			let service = this.get("AccountEnrichmentService.Name");
			if(service === "EnrichmentService"){
				var notLinkDataTags = this.notLinkDataTags;
				var itemCategory = this.get("CategoryTag");
				return !Ext.Array.contains(notLinkDataTags, itemCategory);
			} else {
				return false;
			}
		},

		/**
		 * @inheritdoc BPMSoft.BaseEnrichmentViewModel#getHref.
		 * @protected
		 * @overridden
		 */
		getHref: function() {
			var value = this.get("Value");
			return {
				url: value,
				caption: value
			};
		}
	});
});