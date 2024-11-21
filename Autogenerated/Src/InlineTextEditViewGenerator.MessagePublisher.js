define("InlineTextEditViewGenerator", ["ext-base", "BPMSoft", "ViewGeneratorV2", "InlineCodeTextEdit",
	"css!InlineTextEditViewGenerator"],
	function(Ext) {
		Ext.define("BPMSoft.configuration.InlineTextEditViewGenerator", {
			extend: "BPMSoft.ViewGenerator",
			alternateClassName: "BPMSoft.InlineTextEditViewGenerator",
			Ext: null,

			// region Methods: Private

			_removeMacrosButtonFromConfig: function(config){
				if (config.ckeditorDefaultConfig && config.ckeditorDefaultConfig.removeButtons) {
					var configRemoveButtons = config.ckeditorDefaultConfig.removeButtons.split(',');
					configRemoveButtons = _.without(configRemoveButtons, "bpmcrmmacros");
					config.ckeditorDefaultConfig.removeButtons = configRemoveButtons.join();
					return config;
				}
				return config;
			},

			//endregion

			// region Methods: Public

			/**
			 * Get list of attributes for applying to config.
			 * @returns {string[]} List of attribute names.
			 * @protected
			 * @virtual
			 */
			getConfigAttributesList: function() {
				return ["macrobuttonclicked", "images", "imageLoaded", "imagePasted", "hasFullScreen", "hasTableEdit", "sanitizeHtml"];
			},

			/**
			 * Returns configuration for {BPMSoft.InlineTextEdit}.
			 * @protected
			 * @virtual
			 * @param {Object} config Description view control.
			 * @return {Object} Returns view of InlineTextEdit.
			 */
			getInlineTextEditConfig: function(config) {
				var inlineTextEditConfig = {
					"className": "BPMSoft.InlineCodeTextEdit",
					"value": {"bindTo": config.bindTo || config.name},
					"id": "InlineCodeTextEdit_" + BPMSoft.generateGUID(),
					"placeholder": config.placeholder,
					"selectedText": config.selectedText
				};
				if (config.controlConfig) {
					BPMSoft.each(this.getConfigAttributesList(), function(attribute) {
						if (!Ext.isEmpty(config.controlConfig[attribute])) {
							inlineTextEditConfig[attribute] = config.controlConfig[attribute];
						}});
					var inlineTextConfig = config.controlConfig.inlineTextControlConfig;
					if (config.controlConfig.hasOwnProperty("showEmailTemplateLinkButton")) {
						inlineTextEditConfig.showEmailTemplateLinkButton =
							config.controlConfig.showEmailTemplateLinkButton;
					}
					if (config.controlConfig.hasOwnProperty("sanitizationLevel")) {
						inlineTextEditConfig.sanitizationLevel = config.controlConfig.sanitizationLevel;
					}
					if (!Ext.isEmpty(inlineTextConfig) && BPMSoft.Features.getIsEnabled("IsMacrosButtonHidden")) {
						Ext.apply(inlineTextEditConfig, inlineTextConfig);
					} else if (!Ext.isEmpty(inlineTextConfig)) {
						inlineTextConfig = this._removeMacrosButtonFromConfig(inlineTextConfig);
						Ext.apply(inlineTextEditConfig, inlineTextConfig);
					}
				}
				return inlineTextEditConfig;
			},

			/**
			 * Generates configuration view for {BPMSoft.InlineTextEdit}.
			 * @protected
			 * @virtual
			 * @param {Object} viewConfig Description view control.
			 * @param {Object} config Description control.
			 * @return {Object} Generated view of InlineTextEdit.
			 */
			generate: function(viewConfig, config) {
				this.init(config);
				var inlineTextEditConfig = this.getInlineTextEditConfig(viewConfig);
				var componentId=inlineTextEditConfig.id.replace('InlineCodeTextEdit_', '');
				var controlConfig = {
					"className": "BPMSoft.Container",
					"id": "inlineText-edit-"+componentId+"control-wrapper",
					"classes": {
						"wrapClassName": ["inlinetextedit-expandable"]
					},
					"items": [
						{
							"className": "BPMSoft.Container",
							"id": "inlineText-edit-"+componentId+"inlineText-edit-control-container-edit",
							"classes": {
								"wrapClassName": ["item-control"]
							},
							"items": [inlineTextEditConfig]
						}
					]
				};
				Ext.apply(controlConfig, this.getConfigWithoutServiceProperties(viewConfig,
					["generator", "placeholder", "labelConfig", "selectedText"]));
				return controlConfig;
			}

			//endregion

		});
		return Ext.create("BPMSoft.configuration.InlineTextEditViewGenerator");
	});
