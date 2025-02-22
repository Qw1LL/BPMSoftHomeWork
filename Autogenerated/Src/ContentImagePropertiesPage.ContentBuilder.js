﻿define("ContentImagePropertiesPage", ["css!ContentItemStylesPageCSS"], function() {
	return {
		modules: {
			AlignPropertyModulePage: {
				moduleId: "AlignPropertyModulePage",
				moduleName: "ConfigurationModuleV2",
				config: {
					schemaName: "AlignPropertyModule",
					isSchemaConfigInitialized: true,
					useHistoryState: false,
					parameters: {
						viewModelConfig: {
							Config: {
								attributeValue: "Config"
							},
							PropertyName: "Align"
						}
					}
				}
			}
		},
		attributes: {

			/**
			 * Image.
			 */
			Image: {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Mobile image.
			 */
			MobileImage: {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Allow use mobile image.
			 */
			UseMobileImage: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				onChange: "_onUseMobileImageChanged"
			},

			/**
			 * Image display value.
			 */
			DisplayValue: {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				onChange: "_onDisplayValueChanged"
			},

			/**
			 * Mobile image display value.
			 */
			MobileDisplayValue: {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				onChange: "_onMobileDisplayValueChanged"
			},

			/**
			 * Link to open.
			 */
			Link: {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				onChange: "_onLinkChanged"
			},

			/**
			 * Image width.
			 */
			Width: {
				dataValueType: BPMSoft.DataValueType.INTEGER,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				onChange: "_onImageWidthChanged"
			},

			/**
			 * Image height.
			 */
			Height: {
				dataValueType: BPMSoft.DataValueType.INTEGER,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				onChange: "_onImageHeightChanged"
			},

			/**
			 * Image title text.
			 */
			ImageTitle: {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				onChange: "_onImageTitleChanged"
			},

			/**
			 * Image alternative text.
			 */
			Alt: {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				onChange: "_onAltChanged"
			}

		},
		properties: {

			/**
			 * @private
			 */
			_imageFileName: null,

			/**
			 * @private
			 */
			_mobileImageFileName: null
		},
		methods: {

			// region Methods: Private

			/**
			 * @private
			 */
			_imageWidthValidator: function(value) {
				return Ext.isEmpty(value)
					? { isValid: true }
					: BPMSoft.validateNumberRange(1, 1350, value);
			},

			/**
			 * @private
			 */
			_imageHeightValidator: function(value) {
				return Ext.isEmpty(value)
					? { isValid: true }
					: BPMSoft.validateNumberRange(1, BPMSoft.DataValueTypeRange.INTEGER.maxValue, value);
			},

			/**
			 * @private
			 */
			_onDisplayValueChanged: function(model, value) {
				if (value !== this.get("Resources.Strings.ImageEmbedded")) {
					this.$Image = BPMSoft.utils.html.sanitizeHTML(value);
					this._setImageValues();
				}
			},

			/**
			 * @private
			 */
			_onMobileDisplayValueChanged: function(model, value) {
				if (value !== this.get("Resources.Strings.ImageEmbedded")) {
					this.$MobileImage = BPMSoft.utils.html.sanitizeHTML(value);
					this._setMobileImageValues();
				}
			},

			/**
			 * @private
			 */
			_setImageValues: function() {
				this.$Config.ImageConfig = {
					source: BPMSoft.ImageSources.URL,
					url: this.$Image,
					imageSrc: this.$Image,
					name: this._imageFileName
				};
				this.save();
			},

			/**
			 * @private
			 */
			_setMobileImageValues: function() {
				this.$Config.MobileImageConfig = {
					source: BPMSoft.ImageSources.URL,
					url: this.$MobileImage,
					imageSrc: this.$MobileImage,
					name: this._mobileImageFileName
				};
				this.save();
			},

			/**
			 * @private
			 */
			 _onImageTitleChanged: function(model, text) {
				if (this.isChanged(this.$Config.ImageTitle, text)) {
					this.$Config.ImageTitle = BPMSoft.utils.html.sanitizeHTML(text);
					this.save();
				}
			},

			/**
			 * @private
			 */
			_onAltChanged: function(model, text) {
				if (this.isChanged(this.$Config.Alt, text)) {
					this.$Config.Alt = BPMSoft.utils.html.sanitizeHTML(text);
					this.save();
				}
			},

			/**
			 * @private
			 */
			_setFileMobileImageValues: function(file, fileName) {
				this.$MobileDisplayValue = this.get("Resources.Strings.ImageEmbedded");
				this.$MobileImage = file;
				this._mobileImageFileName = fileName;
				this._setMobileImageValues();
			},

			/**
			 * @private
			 */
			_setFileImageValues: function(file, fileName) {
				this.$DisplayValue = this.get("Resources.Strings.ImageEmbedded");
				this.$Image = file;
				this._imageFileName = fileName;
				this._setImageValues();
			},

			/**
			 * @private
			 */
			_onLinkChanged: function(model, link) {
				if (this.isChanged(this.$Config.Link, link)) {
					this.$Config.Link = BPMSoft.utils.html.sanitizeHTML(link);
					this.save();
				}
			},

			/**
			 * @private
			 */
			_initImage: function() {
				this.$Link = this.$Config.Link;
				this.$ImageTitle = this.$Config.ImageTitle;
				this.$Alt = this.$Config.Alt;
				this.$Width = this.$Config.Width;
				this.$Height = this.$Config.Height;
				this._initImageAttribute(this.$Config.ImageConfig, "Image", "DisplayValue");
				this._initImageAttribute(this.$Config.MobileImageConfig, "MobileImage", "MobileDisplayValue");
				this.$UseMobileImage = Boolean(this.$MobileDisplayValue);
			},

			/**
			 * @private
			 */
			_initImageAttribute: function(imageConfig, propertyName, displayPropertyName) {
				if (imageConfig && imageConfig.hasOwnProperty("url")) {
					if (imageConfig.url && imageConfig.url.startsWith("data:")) {
						this.set(displayPropertyName, this.get("Resources.Strings.ImageEmbedded"));
						this.set(propertyName, imageConfig.url);
					} else {
						this.set(displayPropertyName, imageConfig.url);
					}
				} else {
					this.set(propertyName, BPMSoft.emptyString);
					this.set(displayPropertyName, BPMSoft.emptyString);
				}
			},

			/**
			 * @private
			 */
			_onImageWidthChanged: function(model, width) {
				if (this.isChanged(this.$Config.Width, width)) {
					this.$Config.Width = width;
					if (width > 0 && width !== "auto") {
						this.$Config.Styles.width = width + "px";
					} else {
						delete this.$Config.Styles.width;
					}
					this.save();
				}
			},

			/**
			 * @private
			 */
			_onImageHeightChanged: function(model, height) {
				if (this.isChanged(this.$Config.Height, height)) {
					this.$Config.Height = height;
					if (height > 0 && height !== "auto") {
						this.$Config.Styles.height = height + "px";
						} else {
						delete this.$Config.Styles.height;
						}
					this.save();
				}
			},

			/**
			 * @private
			 */
			_onUseMobileImageChanged: function() {
				if (!this.$UseMobileImage) {
					this.removeMobileImageAttributes();
				}
			},

			// endregion

			// region Methods: Protected

			/**
			 * @inheritdoc ContentItemPropertiesPage#onContentItemConfigChanged
			 * @overridden
			 */
			onContentItemConfigChanged: function(config) {
				if (config) {
					this.$Styles = JSON.stringify(config.Styles || {}, null, "\t");
					this.$IsValid = BPMSoft.isJsonObject(this.$Styles) || Ext.isEmpty(this.$Styles);
					this._initImage();
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#setValidationConfig
			 * @overridden
			 */
			setValidationConfig: function() {
				this.callParent(arguments);
				this.addColumnValidator("Width", this._imageWidthValidator);
				this.addColumnValidator("Height", this._imageHeightValidator);
			},

			/**
			 * Mobile image attribute clear icon handler.
			 * @protected
			 */
			removeMobileImageAttributes: function() {
				this.$MobileDisplayValue = "";
			},

			// endregion

			// region Methods: Public

			/**
			 * Image selection button handler.
			 * @public
			 */
			onImageSelected: function(image) {
				if (image || Ext.isArray(image)) {
					FileAPI.readAsDataURL(image[0], function(e) {
						this._setFileImageValues(e.result, e.target.name);
					}.bind(this));
				}
			},

			/**
			 * Mobile image selection button handler.
			 * @public
			 */
			onMobileImageSelected: function(image) {
				if (image || Ext.isArray(image)) {
					FileAPI.readAsDataURL(image[0], function(e) {
						this._setFileMobileImageValues(e.result, e.target.name);
					}.bind(this));
				}
			},

			/**
			 * Image attribute clear icon handler.
			 * @public
			 */
			removeImageAttributes: function() {
				this.$DisplayValue = "";
			}

			// endregion

		},
		diff: [
			{
				"operation": "insert",
				"name": "ContentImagePropertiesContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["content-styles-editor-wrapper"]
				}
			},
			{
				"operation": "insert",
				"name": "ImageGroup",
				"parentName": "ContentImagePropertiesContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"items": [],
					"caption": "$Resources.Strings.ImageOptionsLabel"
				},
				"index": 0
			},
			{
				"operation": "insert",
				"parentName": "ImageGroup",
				"name": "ImageContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["image-properties-wrapper"],
					"visible": {
						"bindTo": "Config",
						"bindConfig": {
							"converter": "toBoolean"
						}
					}
				}
			},
			{
				"operation": "insert",
				"name": "DesktopImage",
				"parentName": "ImageContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "DesktopImage",
				"name": "ImageUploadGroup",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["control-editor-wrapper"]
				}
			},
			{
				"operation": "insert",
				"name": "UploadImage",
				"parentName": "ImageUploadGroup",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["icon-16x16 image-icon"]
				}
			},
			{
				"operation": "insert",
				"name": "Image",
				"parentName": "ImageUploadGroup",
				"propertyName": "items",
				"values": {
					"value": "$DisplayValue",
					"markerValue": "Image",
					"caption": "image",
					"wrapClass": ["url-placeholder", "control-editor-wrapper", "hide-label"],
					"controlConfig": {
						"placeholder": "$Resources.Strings.ImageUrlPlaceholder",
						"hasClearIcon": true,
						"cleariconclick": "$removeImageAttributes"
					},
					"classes": {
						"wrapClassName": ["show-placeholder"]
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "ImageUploadGroup",
				"name": "UploadImageButton",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"imageConfig": "$Resources.Images.UploadBackgroundImage",
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"fileTypeFilter": ["image/*"],
					"fileUpload": true,
					"filesSelected": "$onImageSelected",
					"fileUploadMultiSelect": false,
					"markerValue": "UploadImageButton",
					"classes": {"wrapperClass": ["upload-image-icon-wrapper"]}
				}
			},
			{
				"operation": "insert",
				"parentName": "ImageUploadGroup",
				"name": "UploadImageButton",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"imageConfig": "$Resources.Images.UploadBackgroundImage",
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"fileTypeFilter": ["image/*"],
					"fileUpload": true,
					"filesSelected": "$onImageSelected",
					"fileUploadMultiSelect": false,
					"markerValue": "UploadImageButton",
					"classes": {"wrapperClass": ["upload-image-icon-wrapper"]}
				}
			},
			{
				"operation": "insert",
				"parentName": "ImageUploadGroup",
				"name": "UploadImageButtonLeft",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"imageConfig": "$Resources.Images.UploadBackgroundImageLeft",
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"fileTypeFilter": ["image/*"],
					"fileUpload": true,
					"filesSelected": "$onImageSelected",
					"fileUploadMultiSelect": false,
					"markerValue": "UploadImageButton",
					"classes": {"wrapperClass": ["upload-image-icon-wrapper-left"]}
				}
			},
			{
				"operation": "insert",
				"name": "MobileImageContainer",
				"parentName": "ImageContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["mobile-image-wrapper"]
				}
			},
			{
				"operation": "insert",
				"name": "MobileImageCheckboxContainer",
				"parentName": "MobileImageContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["mobile-image-checkbox-wrapper"]
				}
			},
			{
				"operation": "insert",
				"parentName": "MobileImageCheckboxContainer",
				"propertyName": "items",
				"name": "UseMobileImage",
				"values": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"controlConfig": {
						"className": "BPMSoft.CheckBoxEdit",
						"checked": "$UseMobileImage"
					},
					"markerValue": "UseMobileImage",
					"caption": "$Resources.Strings.UseMobileImage",
					"wrapClass": ["style-input", "reverse-label"]
				}
			},
			{
				"operation": "insert",
				"parentName": "MobileImageContainer",
				"name": "MobileImageUploadGroup",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["control-editor-wrapper"],
					"visible": "$UseMobileImage"
				}
			},
			{
				"operation": "insert",
				"name": "MobileUploadImage",
				"parentName": "MobileImageUploadGroup",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["icon-16x16 image-icon"]
				}
			},
			{
				"operation": "insert",
				"name": "MobileImage",
				"parentName": "MobileImageUploadGroup",
				"propertyName": "items",
				"values": {
					"value": "$MobileDisplayValue",
					"markerValue": "MobileImage",
					"caption": "Image",
					"wrapClass": ["url-placeholder", "control-editor-wrapper", "hide-label"],
					"controlConfig": {
						"placeholder": "$Resources.Strings.ImageUrlPlaceholder",
						"hasClearIcon": true,
						"cleariconclick": "$removeMobileImageAttributes"
					},
					"classes": {
						"wrapClassName": ["show-placeholder"]
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "MobileImageUploadGroup",
				"name": "UploadMobileImageButton",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"imageConfig": "$Resources.Images.UploadBackgroundImage",
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"fileTypeFilter": ["image/*"],
					"fileUpload": true,
					"filesSelected": "$onMobileImageSelected",
					"fileUploadMultiSelect": false,
					"markerValue": "UploadMobileImageButton",
					"classes": {"wrapperClass": ["upload-image-icon-wrapper"]}
				}
			},
			{
				"operation": "insert",
				"parentName": "ImageContainer",
				"name": "ImageLinkGroup",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["control-editor-wrapper"]
				}
			},
			{
				"operation": "insert",
				"parentName": "ImageLinkGroup",
				"propertyName": "items",
				"name": "Link",
				"values": {
					"itemType": BPMSoft.ViewItemType.TEXT,
					"value": "$Link",
					"markerValue": "Link",
					"wrapClass": ["style-input"],
					"labelConfig": {
						"caption": "$Resources.Strings.ImageHrefLabel"
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "ImageContainer",
				"name": "ImageSizeGroup",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["control-editor-wrapper"]
				}
			},
			{
				"operation": "insert",
				"parentName": "ImageSizeGroup",
				"propertyName": "items",
				"name": "Width",
				"values": {
					"itemType": BPMSoft.ViewItemType.TEXT,
					"value": "$Width",
					"markerValue": "Width",
					"wrapClass": ["style-input"],
					"controlConfig": {"placeholder": "$Resources.Strings.PlaceholderAutoText"},
					"labelConfig": {
						"caption": "$Resources.Strings.ImageWidth"
					},
					"classes": {"wrapClassName": ["show-placeholder"]}
				}
			},
			{
				"operation": "insert",
				"parentName": "ImageSizeGroup",
				"propertyName": "items",
				"name": "Height",
				"values": {
					"itemType": BPMSoft.ViewItemType.TEXT,
					"value": "$Height",
					"markerValue": "Height",
					"wrapClass": ["style-input"],
					"controlConfig": {"placeholder": "$Resources.Strings.PlaceholderAutoText"},
					"labelConfig": {
						"caption": "$Resources.Strings.ImageHeight"
					},
					"classes": {"wrapClassName": ["show-placeholder"]}
				}
			},
			{
				"operation": "insert",
				"parentName": "ImageContainer",
				"name": "ImageTitleGroup",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["control-editor-wrapper"]
				}
			},
			{
				"operation": "insert",
				"parentName": "ImageTitleGroup",
				"propertyName": "items",
				"name": "ImageTitle",
				"values": {
					"itemType": BPMSoft.ViewItemType.TEXT,
					"value": "$ImageTitle",
					"wrapClass": ["style-input"],
					"labelConfig": {
						"caption": "$Resources.Strings.ImageTitleText"
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "ImageContainer",
				"name": "ImageAltGroup",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["control-editor-wrapper"]
				}
			},
			{
				"operation": "insert",
				"parentName": "ImageAltGroup",
				"propertyName": "items",
				"name": "Alt",
				"values": {
					"itemType": BPMSoft.ViewItemType.TEXT,
					"value": "$Alt",
					"markerValue": "Alt",
					"wrapClass": ["style-input"],
					"labelConfig": {
						"caption": "$Resources.Strings.ImageAltText"
					}
				}
			},
			{
				"operation": "insert",
				"name": "AlignGroup",
				"parentName": "ContentImagePropertiesContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"items": [],
					"caption": "$Resources.Strings.ImageAlign"
				},
				"index": 1
			},
			{
				"operation": "insert",
				"name": "AlignContainer",
				"parentName": "AlignGroup",
				"propertyName": "items",
				"values": {
					"markerValue": "AlignContainer",
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["content-builder-align-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "AlignPropertyModulePage",
				"parentName": "AlignContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.MODULE
				}
			}
		]
	};
});
