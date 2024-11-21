/**
 * View model for content mjml hero item in container list.
 */
define("ContentMjHeroItemViewModel", ["ContentMjHeroItemViewModelResources",
		"BaseContentStructureItemViewModel"],
	function(resources) {
		/**
		 * @class BPMSoft.configuration.ContentMjHeroItemViewModel
		 */
		Ext.define("BPMSoft.configuration.ContentMjHeroItemViewModel", {
			extend: "BPMSoft.BaseContentStructureItemViewModel",
			alternateClassName: "BPMSoft.ContentMjHeroItemViewModel",
			/**
			 * @inheritdoc BaseContentStructureItemViewModel#markerValuePrefix
			 * @override
			 */
			markerValuePrefix: "mjhero-item",
			/**
			 * @inheritdoc BaseContentStructureItemViewModel#markerValuePostfix
			 * @override
			 */
			markerValuePostfix: "mjhero-item-container",

			/**
			 * @inheritdoc BPMSoft.BaseViewModel#constructor
			 * @override
			 */
			constructor: function() {
				this.callParent(arguments);
				this.initResourcesValues(resources);
			},

			/**
			 * @inheritdoc BaseContentStructureItemViewModel#setCaption
			 * @override
			 */
			setCaption: function(index) {
				var title = resources.localizableStrings.BaseStructureItemTitle;
				this.callParent([index, title]);
			}

		});
	}
);
