/**
 * View model for content section item in container list.
 */
define("ContentSectionItemViewModel", ["ContentSectionItemViewModelResources",
		"BaseContentStructureItemViewModel"],
	function(resources) {
		/**
		 * @class BPMSoft.configuration.ContentSectionItemViewModel
		 */
		Ext.define("BPMSoft.configuration.ContentSectionItemViewModel", {
			extend: "BPMSoft.BaseContentStructureItemViewModel",
			alternateClassName: "BPMSoft.ContentSectionItemViewModel",
			/**
			 * @inheritdoc BaseContentStructureItemViewModel#markerValuePrefix
			 * @override
			 */
			markerValuePrefix: "section-item",
			/**
			 * @inheritdoc BaseContentStructureItemViewModel#markerValuePostfix
			 * @override
			 */
			markerValuePostfix: "section-item-container",

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

			// #endregion

		});
	}
);
