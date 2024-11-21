define("PageTemplateViewModel", ["PageTemplateViewModelResources"], function(resources) {
	Ext.define("BPMSoft.PageTemplateViewModel", {
		extend: "BPMSoft.BaseViewModel",

		columns: {
			IsSelected: {
				value: false
			}
		},

		/**
		 * @inheritdoc BPMSoft.BaseViewModel#primaryImageColumnName
		 * @override
		 */
		primaryImageColumnName: "PreviewImage",

		/**
		 * @private
		 */
		_getDefaultPreviewImage: function() {
			return BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.DefaultTemplate);
		},

		/**
		 * @inheritdoc BPMSoft.BaseViewModel#constructor
		 * @override
		 */
		constructor: function() {
			this.callParent(arguments);
			this.addEvents(
				"pageTemplateSelect"
			);
		},

		/**
		 * Returns template item image config.
		 * @return {Object}
		 */
		getTemplateItemImageConfig: function() {
			var url = this.getSchemaImageUrl() || this._getDefaultPreviewImage();
			return {
				source: BPMSoft.ImageSources.URL,
				url: url
			};
		},

		/**
		 * Handler of page template container click.
		 */
		onPageTemplateClick: function() {
			this.fireEvent("pageTemplateSelect", this);
		}

	});

	return BPMSoft.PageTemplateViewModel;
});
