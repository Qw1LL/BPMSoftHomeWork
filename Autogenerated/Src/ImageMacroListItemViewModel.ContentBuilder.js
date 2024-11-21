define("ImageMacroListItemViewModel", ["ImageMacroListItemViewModelResources", "BaseMacroListItemViewModel"],
		function(resources) {
	/**
	 * @class BPMSoft.configuration.ImageMacroListItemViewModel
	 */
	Ext.define("BPMSoft.configuration.ImageMacroListItemViewModel", {
		extend: "BPMSoft.BaseMacroListItemViewModel",
		alternateClassName: "BPMSoft.ImageMacroListItemViewModel",

		attributes: {
			/**
			 * Image display value.
			 */
			ImageDisplayValue: {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			}
		},

		/**
		 * @override
		 */
		isEmailMacroButtonVisible: false,

		/**
		 * @private
		 */
		_onImageDisplayValueChanged: function(model, value) {
			if (!Ext.isEmpty(value) && value !== resources.localizableStrings.ImageEmbedded) {
				this.$Value = value;
			}
			if (Ext.isEmpty(value)) {
				this.$Value = null;
			}
		},

		/**
		 * @private
		 */
		_initImageDisplayValue: function(config) {
			var image = config.Value;
			if (!image) {
				return;
			}
			if (this._isImageEmbedded(image)) {
				config.ImageDisplayValue = resources.localizableStrings.ImageEmbedded;
			} else {
				config.ImageDisplayValue = image;
			}
		},

		/**
		 * @private
		 */
		_isImageEmbedded: function(image) {
			return image.startsWith("data:") || image.startsWith("../rest/FileService/");
		},

		/**
		 * @inheritdoc BPMSoft.BaseViewModel#constructor
		 * @overridden
		 */
		constructor: function(config) {
			config && config.values && this._initImageDisplayValue(config.values);
			this.callParent(arguments);
			this.on("change:ImageDisplayValue", this._onImageDisplayValueChanged, this);
		},

		/**
		 * @inheritdoc BPMSoft.BaseObject#onDestroy
		 * @override
		 */
		onDestroy: function() {
			this.un("change:ImageDisplayValue", this._onImageDisplayValueChanged, this);
			this.callParent(arguments);
		},

		/**
		 * Upload image button handler.
		 * @param {Array} image array.
		 * @public
		 */
		onImageSelected: function(image) {
			if (image || Ext.isArray(image)) {
				FileAPI.readAsDataURL(image[0], function (e) {
					this.$ImageDisplayValue = resources.localizableStrings.ImageEmbedded;
					if (this.$Value !== e.result) {
						this.$Value = e.result;
					}
				}.bind(this));
			}
		},

		/**
		 * @inheritdoc BaseMacroListItemViewModel#getMacroInputConfig
		 * @override
		 */
		getMacroInputConfig: function() {
			return [this.getMacroLabelConfig(),
				{
					className: "BPMSoft.Container",
					classes: {
						wrapClassName: ["control-editor-wrapper"]
					},
					items: [
						{
							className: "BPMSoft.Container",
							classes: {
								wrapClassName: ["image-icon", "icon-16x16"]
							},
							items: []
						},
						{
							className: "BPMSoft.TextEdit",
							value: "$ImageDisplayValue",
							placeholder: resources.localizableStrings.ImageUrlPlaceholder,
							hasClearIcon: true,
							classes: {
								wrapClass: ["show-placeholder", "control-editor-wrapper"]
							}
						},
						{
							className: "BPMSoft.Button",
							imageConfig: resources.localizableImages.UploadImage,
							fileTypeFilter: ["image/*"],
							fileUpload: true,
							filesSelected: "$onImageSelected",
							fileUploadMultiSelect: false,
							classes: {
								wrapperClass: ["upload-icon-wrapper"]
							}
						}
					]
				}
			];
		}
	});
	return BPMSoft.ImageMacroListItemViewModel;
});
