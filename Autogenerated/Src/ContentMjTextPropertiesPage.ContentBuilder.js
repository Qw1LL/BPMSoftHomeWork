  define("ContentMjTextPropertiesPage", ["css!ContentItemStylesPageCSS"], function() {
	return {
		modules: {
			FontFamilyPropertyModulePage: {
				moduleId: "FontFamilyPropertyModulePage",
				moduleName: "ConfigurationModuleV2",
				config: {
					schemaName: "FontFamilyPropertyModule",
					isSchemaConfigInitialized: true,
					useHistoryState: false,
					parameters: {
						viewModelConfig: {
							Config: {
								attributeValue: "Config"
							},
							PropertyName: "Styles",
							UseLetterSpacing: true
						}
					}
				}
			},
			FontPropertyModulePage: {
				moduleId: "FontPropertyModulePage",
				moduleName: "ConfigurationModuleV2",
				config: {
					schemaName: "FontPropertyModule",
					isSchemaConfigInitialized: true,
					useHistoryState: false,
					parameters: {
						viewModelConfig: {
							Config: {
								attributeValue: "Config"
							},
							PropertyName: "Styles",
							UseLetterSpacing: true
						}
					}
				}
			},
			TextAlignPropertyModulePage: {
				moduleId: "TextAlignPropertyModulePage",
				moduleName: "ConfigurationModuleV2",
				config: {
					schemaName: "TextAlignPropertyModule",
					isSchemaConfigInitialized: true,
					useHistoryState: false,
					parameters: {
						viewModelConfig: {
							Config: {
								attributeValue: "Config"
							},
							PropertyName: "Styles"
						}
					}
				}
			},
			PaddingPropertyModulePage: {
				moduleId: "PaddingPropertyModulePage",
				moduleName: "ConfigurationModuleV2",
				config: {
					schemaName: "PaddingPropertyModule",
					isSchemaConfigInitialized: true,
					useHistoryState: false,
					parameters: {
						viewModelConfig: {
							Config: {
								attributeValue: "Config"
							},
							PropertyName: "Styles"
						}
					}
				}
			},
			BackgroundPropertyModulePage: {
				moduleId: "BackgroundPropertyModulePage",
				moduleName: "ConfigurationModuleV2",
				config: {
					schemaName: "BackgroundPropertyModule",
					isSchemaConfigInitialized: true,
					useHistoryState: false,
					parameters: {
						viewModelConfig: {
							Config: {
								attributeValue: "Config"
							},
							PropertyName: "Styles",
							UseImage: false
						}
					}
				}
			}
		},
		attributes: {
			/**
			 * Text element height.
			 */
			Height: {
				dataValueType: BPMSoft.DataValueType.INTEGER,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				onChange: "_onTextHeightChanged"
			}
		},
		properties: {
			workStyles: ["height"]
		},
		methods: {

			/**
			 * @private
			 */
			_onTextHeightChanged: function(model, height) {
				if (this.isChanged(this.$Config.Styles.height + "px", this.$Height)) {
					if (!Ext.isEmpty(height)) {
						Ext.apply(this.$Config.Styles, {
							"height": height + "px"
						});
					} else {
						delete this.$Config.Styles.height;
					}
					this.save();
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#setValidationConfig
			 * @override
			 */
			setValidationConfig: function() {
				this.callParent(arguments);
				this.addColumnValidator("Height", this.positiveNumberValidator);
			},

			/**
			 * @inheritdoc ContentItemPropertiesPage#onContentItemConfigChanged
			 * @overridden
			 */
			onContentItemConfigChanged: function(config) {
				if (config) {
					config.Styles = config.Styles || {};
					this.$Height = config.Styles.height ? parseFloat(config.Styles.height) : BPMSoft.emptyString;
				}
			}
		},
		diff: [
			{
				"operation": "insert",
				"name": "ContentTextPropertiesContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["content-styles-editor-wrapper"]
				}
			},
			// {
			// 	"operation": "insert",
			// 	"name": "FontGroup",
			// 	"parentName": "ContentTextPropertiesContainer",
			// 	"propertyName": "items",
			// 	"values": {
			// 		"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
			// 		"items": [],
			// 		"caption": "$Resources.Strings.FontCaption",
			// 		"wrapClass": ["font-control-group"]
			// 	},
			// 	"index": 0
			// },
			{
				"operation": "insert",
				"name": "FontFamilyLabelContainer",
				"parentName": "ContentTextPropertiesContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["group-label-wrapper"]
				},
				"index": 0
			},
			{
				"operation": "insert",
				"parentName": "FontFamilyLabelContainer",
				"name": "FontFamilyLabel",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"markerValue": "FontCaptionLabel",
					"caption": "$Resources.Strings.FontCaption"
				}
			},
			{
				"operation": "insert",
				"name": "FontFamilyInfoTip",
				"parentName": "FontFamilyLabelContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
					"content": "$Resources.Strings.FontInfoText",
					"style": BPMSoft.TipStyle.WHITE,
					"behaviour": {
						"displayEvent": BPMSoft.TipDisplayEvent.HOVER
					}
				}
			},
			{
				"operation": "insert",
				"name": "FontGroup",
				"parentName": "ContentTextPropertiesContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["font-control-group"]
				},
				"index": 1
			},
			{
				"operation": "insert",
				"name": "FontFamilyPropertyModulePage",
				"parentName": "FontGroup",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.MODULE
				}
			},
			{
				"operation": "insert",
				"name": "FontPropertyModulePage",
				"parentName": "FontGroup",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.MODULE
				}
			},
			{
				"operation": "insert",
				"name": "TextAlignGroup",
				"parentName": "ContentTextPropertiesContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"items": [],
					"caption": "$Resources.Strings.TextAlignCaption"
				},
				"index": 2
			},
			{
				"operation": "insert",
				"name": "TextAlignContainer",
				"parentName": "TextAlignGroup",
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
				"name": "TextAlignPropertyModulePage",
				"parentName": "TextAlignContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.MODULE
				}
			},
			{
				"operation": "insert",
				"name": "TextSizeGroup",
				"parentName": "ContentTextPropertiesContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"items": [],
					"caption": "$Resources.Strings.TextElementHeight"
				},
				"index": 3
			},
			{
				"operation": "insert",
				"parentName": "TextSizeGroup",
				"name": "TextSizeGroupContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["control-editor-wrapper"]
				}
			},
			{
				"operation": "insert",
				"parentName": "TextSizeGroupContainer",
				"propertyName": "items",
				"name": "Height",
				"values": {
					"itemType": BPMSoft.ViewItemType.TEXT,
					"wrapClass": ["style-input"],
					"controlConfig": {"placeholder": "$Resources.Strings.PlaceholderAutoText"},
					"classes": {"wrapClassName": ["show-placeholder width-50"]},
					"markerValue": "TextHeight",
					"labelConfig": {
						"visible": false
					}
				}
			},
			{
				"operation": "insert",
				"name": "PaddingGroup",
				"parentName": "ContentTextPropertiesContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"items": [],
					"caption": "$Resources.Strings.PaddingCaption",
					"wrapClass": ["padding-control-group"]
				},
				"index": 4
			},
			{
				"operation": "insert",
				"name": "PaddingPropertyModulePage",
				"parentName": "PaddingGroup",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.MODULE
				}
			},
			{
				"operation": "insert",
				"name": "BackgroundGroup",
				"parentName": "ContentTextPropertiesContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"items": [],
					"caption": "$Resources.Strings.BackgroundLabelCaption",
					"wrapClass": ["background-control-group"]
				},
				"index": 5
			},
			{
				"operation": "insert",
				"name": "BackgroundPropertyModulePage",
				"parentName": "BackgroundGroup",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.MODULE
				}
			}
		]
	};
});
