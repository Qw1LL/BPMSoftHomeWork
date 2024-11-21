define("ImageCustomGeneratorV2", ["ext-base", "BPMSoft", "ImageCustomGeneratorV2Resources", "ViewGeneratorV2"],
	function(Ext, BPMSoft, resources) {
		var ImageCustomGenerator = Ext.define("BPMSoft.configuration.ImageCustomgenerator", {
			extend: "BPMSoft.ViewGenerator",
			alternateClassName: "BPMSoft.ImageCustomGenerator",

			/**
			* Generates options for creating controls.
			* @param {Object} config Options for generator.
			* @return {Object} Options for creating controls.
			*/
			generateCustomImageControl: function(config) {
				var id = this.getControlId(config, "BPMSoft.ImageEdit");
				var uploadButtonHint = this.getHintConfig({
					content: resources.localizableStrings.ImageUploadButtonHint,
					alignEl: "uploadButtonIconEl"
				});
				var clearButtonHint = this.getHintConfig({
					content: resources.localizableStrings.ImageClearButtonHint,
					alignEl: "clearButtonIconEl"
				});
				var controlConfig = {
					className: "BPMSoft.ImageEdit",
					imageSrc: {bindTo: config.getSrcMethod},
					defaultImageSrc: config.defaultImage,
					tips: [uploadButtonHint, clearButtonHint]
				};
				var change = config.onPhotoChange;
				if (change) {
					controlConfig.change = {bindTo: change};
				}
				this.applyControlId(controlConfig, config, id);
				Ext.apply(controlConfig, this.getConfigWithoutServiceProperties(config,
					["generator", "getSrcMethod", "defaultImage", "onPhotoChange", "beforeFileSelected"]));
				return controlConfig;
			},

			/**
			* Gets control id.
			* @overriden
			* @param {Object} config Options for generator.
			* @param {String} className Class name.
			* @return {String} Control id.
			*/
			getControlId: function(config, className) {
				if (className === "BPMSoft.ImageEdit") {
					return config.name + BPMSoft.generateGUID() + "ImageEdit";
				}
				return this.callParent(arguments);
			},

			/**
			* Forms creation options to control the display of images.
			* @param {Object} config Options for generator.
			* @return {Object} Options to control the display of images.
			*/
			generateSimpleCustomImage: function(config) {
				var initialConfig = this.generateCustomImageControl(config);
				initialConfig.tpl = [
					/*jshint quotmark:false*/
					/* jscs:disable */
					'<div id="{id}-image-edit" class="{wrapClass}">',
					'<img id="{id}-image-edit-element" src="{imageSrc}" title="{imageTitle}">',
					'</div>'
					/*jshint quotmark:true*/
					/* jscs:enable */
				];
				return initialConfig;
			}
		});
		return Ext.create(ImageCustomGenerator);
	}
);
