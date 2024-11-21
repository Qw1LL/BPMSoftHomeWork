define("ContentImageElementViewModel", ["ContentImageElementViewModelResources", "ContentElementBaseViewModel"],
	function(resources) {

	Ext.define("BPMSoft.ContentBuilder.ContentImageElementViewModel", {
		extend: "BPMSoft.ContentElementBaseViewModel",
		alternateClassName: "BPMSoft.ContentImageElementViewModel",

		/**
		 * View model element class name.
		 * @protected
		 * @type {String}
		 */
		className: "BPMSoft.ContentImageElement",

		/**
		 * @inheritdoc BPMSoft.ContentElementBaseViewModel#sanitizedProperties
		 * @overridde
		 */
		 sanitizedProperties: ["Link", "ImageTitle", "Alt"],

		/**
		 * @inheritdoc BPMSoft.BaseViewModel#constructor
		 * @overridden
		 */
		constructor: function() {
			this.callParent(arguments);
			this.initResourcesValues(resources);
		},

		/**
		 * Shows dialog window for adding image link.
		 */
		setLink: function() {
			var controls = {
				link: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					value: this.get("Link"),
					customConfig: {
						markerValue: "image-edit"
					}
				}
			};
			BPMSoft.utils.inputBox(
				this.get("Resources.Strings.SetLinkInputBoxCaption"),
				this.linkInputBoxHandler,
				["ok", "cancel"],
				this,
				controls
			);
		},

		/**
		 * Handler of user input link.
		 * @protected
		 * @param {String} returnCode Button code, which was pressed.
		 * @param {Object} controlData Control data which was added by user.
		 */
		linkInputBoxHandler: function(returnCode, controlData) {
			if (returnCode === "ok") {
				this.set("Link", controlData.link.value);
			}
		},

		/**
		 * Image change handler.
		 * @protected
		 * @param {File} photo Image.
		 */
		onImageChange: function(photo) {
			if (!photo || !Ext.isArray(photo)) {
				this.set("ImageConfig", null);
				return;
			}
			var img = photo[0];
			FileAPI.readAsDataURL(img, function(e) {
				this.onImageUploaded(e.result, img.name);
			}.bind(this));
		},

		/**
		 * Image upload handler.
		 * @protected
		 * @param {String} imageSrc Image source.
		 * @param {String}  name Image name.
		 */
		onImageUploaded: function(imageSrc, name) {
			this.set("ImageConfig", {
				source: BPMSoft.ImageSources.URL,
				url: imageSrc,
				name: name
			});
		},

		/**
		 * Returns config object of section view model edit.
		 * @protected
		 * @virtual
		 * @returns {Object} Section edit config.
		 */
		getEditConfig: function() {
			return {
				ItemType: this.$ItemType,
				Styles: this.$Styles,
				UseBackgroundImage: false,
				ImageConfig: this.$ImageConfig,
				Width: this.$Width,
				Height: this.$Height,
				Align: this.$Align,
				Alt: this.$Alt,
				ImageTitle: this.$ImageTitle,
				Link: this.$Link
			};
		},
		/**
		 * @inheritdoc BPMSoft.ContentElementBaseViewModel#getViewConfig
		 * @overridden
		 */
		getViewConfig: function() {
			var config = this.callParent(arguments);
			Ext.apply(config, {
				"imageConfig": "$ImageConfig",
				"placeholder": "$Resources.Strings.Placeholder",
				"width": "$Width",
				"height": "$Height",
				"align": "$Align",
				"alt": "$Alt",
				"title": "$ImageTitle"
			});
			if (!BPMSoft.Features.getIsEnabled("ContentBuilderPropertiesPanel")) {
				config.imageTools = this.getToolsViewConfig();
			}
			return config;
		},

		/**
		 * @inheritdoc BPMSoft.ContentElementBaseViewModel#getToolsViewConfig
		 * @overridden
		 */
		getToolsViewConfig: function() {
			return [{
				className: "BPMSoft.Button",
				style: BPMSoft.controls.ButtonEnums.style.ORANGE,
				markerValue: "file-upload-button",
				fileUpload: true,
				fileTypeFilter: ["image/*"],
				filesSelected: "$onImageChange",
				classes: {
					imageClass: ["tools-image"]
				},
				imageConfig: "$Resources.Images.UploadIcon"
			}, {
				className: "BPMSoft.Button",
				markerValue: "set-link-button",
				click: "$setLink",
				classes: {
					imageClass: ["tools-image"]
				},
				imageConfig: "$Resources.Images.LinkIcon"
			}];
		}

	});

});
