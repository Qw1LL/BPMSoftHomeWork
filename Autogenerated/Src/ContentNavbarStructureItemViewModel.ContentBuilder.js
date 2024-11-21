define("ContentNavbarStructureItemViewModel", ["ContentNavbarStructureItemViewModelResources",
		"BaseContentStructureItemViewModel"],
	function(resources) {
		/**
		 * @class BPMSoft.configuration.ContentNavbarStructureItemViewModel
		 */
		Ext.define("BPMSoft.configuration.ContentNavbarStructureItemViewModel", {
			extend: "BPMSoft.BaseContentStructureItemViewModel",
			alternateClassName: "BPMSoft.ContentNavbarStructureItemViewModel",
			/**
			 * @inheritdoc BaseContentStructureItemViewModel#markerValuePrefix
			 * @override
			 */
			markerValuePrefix: "link-item",
			/**
			 * @inheritdoc BaseContentStructureItemViewModel#markerValuePostfix
			 * @override
			 */
			markerValuePostfix: "link-item-container",
			/**
			 * @inheritdoc BaseContentStructureItemViewModel#itemType
			 * @override
			 */
			itemType: "navbarlink",
			/**
			 * @inheritdoc BaseContentStructureItemViewModel#wrapClassNames
			 * @override
			 */
			wrapClassNames: {
				container: "navbar-link-item-container",
				item: "navbar-link-item",
				caption: "navbar-link-caption"
			},

			/**
			 * @inheritDoc BPMSoft.BaseViewModel#constructor
			 * @override
			 */
			constructor: function() {
				this.callParent(arguments);
				this.initResourcesValues(resources);
			},

			/**
			 * @inheritDoc BaseContentStructureItemViewModel#setCaption
			 * @override
			 */
			setCaption: function(index) {
				var title = resources.localizableStrings.BaseStructureItemTitle;
				this.callParent([index, title]);
			}

		});
	}
);
