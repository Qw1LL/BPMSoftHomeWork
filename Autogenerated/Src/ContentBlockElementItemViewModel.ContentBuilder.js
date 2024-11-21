define("ContentBlockElementItemViewModel", ["ContentBlockElementItemViewModelResources"], function(resources) {

	/**
	 * Class for ContentBlockElementItemViewModel.
	 */
	Ext.define("BPMSoft.configuration.ContentBlockElementItemViewModel", {
		extend: "BPMSoft.model.BaseViewModel",
		alternateClassName: "BPMSoft.ContentBlockElementItemViewModel",

		sandbox: null,

		columns: {
			Id: {
				dataValueType: BPMSoft.DataValueType.GUID
			},
			Type: {
				dataValueType: BPMSoft.DataValueType.TEXT
			},
			Caption: {
				dataValueType: BPMSoft.DataValueType.TEXT
			},
			Icon: {
				dataValueType: BPMSoft.DataValueType.IMAGE
			},
			Row: {
				dataValueType: BPMSoft.DataValueType.INTEGER,
				value: 0
			},
			Column: {
				dataValueType: BPMSoft.DataValueType.INTEGER,
				value: 0
			},
			RowSpan: {
				dataValueType: BPMSoft.DataValueType.INTEGER,
				value: 0
			},
			ColSpan: {
				dataValueType: BPMSoft.DataValueType.INTEGER,
				value: 0
			},
			GroupName: {
				dataValueType: BPMSoft.DataValueType.TEXT
			}
		},

		/**
		 * Initial config.
		 * @type {Object}
		 */
		InitialConfig: null,

		// region Methods: Public

		/**
		 * Returns remove button image.
		 * @return {BPMSoft.LocalizableImage}
		 */
		getRemoveButtonImage: function() {
			return resources.localizableImages.RemoveImage;
		},

		/**
		 * Returns actual block element config.
		 */
		getConfig: function() {
			return Ext.apply(this.InitialConfig, {
				ColSpan: this.$ColSpan,
				RowSpan: this.$RowSpan,
				Column: this.$Column,
				Row: this.$Row,
				ItemType: this.$Type,
				GroupName: this.$GroupName
			});
		}

		// endregion

	});

	return BPMSoft.ContentBlockElementItemViewModel;
});
