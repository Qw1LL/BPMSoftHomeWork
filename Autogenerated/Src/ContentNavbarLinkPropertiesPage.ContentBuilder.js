 /**
 * @extends ContentItemPropertiesPage
 */
define("ContentNavbarLinkPropertiesPage", ["css!ContentNavbarLinkPropertiesPageCSS"],
		function() {
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
			}
		},
		attributes: {
			/**
			 * Navbar link url.
			 */
			Link: {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				onChange: "_onLinkChanged"
			}
		},
		methods: {
			
			/**
			 * @private
			 */
			_onLinkChanged: function(model, link) {
				var purifiedLink = BPMSoft.utils.html.sanitizeHTML(link);
				this.$Config.Url = purifiedLink;
				this.save();
			},

			/**
			 * @inheritdoc ContentItemPropertiesPage#onContentItemConfigChanged
			 * @overridden
			 */
			onContentItemConfigChanged: function(config) {
				this.callParent(arguments);
				if (config) {
					this.$Link = Ext.isEmpty(config.Url) ? null : config.Url;
				}
			}
		},
		diff: [
			{
				"operation": "insert",
				"name": "ContentNavbarLinkProperties",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["content-styles-editor-wrapper", "content-navbar-link-properties"]
				}
			},
			{
				"operation": "insert",
				"parentName": "ContentNavbarLinkProperties",
				"name": "LinkGroup",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"items": [],
					"caption": "$Resources.Strings.LinkToOpen"
				}
			},
			{
				"operation": "insert",
				"parentName": "LinkGroup",
				"propertyName": "items",
				"name": "Link",
				"values": {
					"itemType": BPMSoft.ViewItemType.TEXT,
					"value": "$Link",
					"markerValue": "Link",
					"wrapClass": ["style-input link"],
					"labelConfig": {"visible": false},
					"controlConfig": {"placeholder": ""}
				}
			},
			{
				"operation": "insert",
				"name": "FontFamilyLabelContainer",
				"parentName": "ContentNavbarLinkProperties",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["group-label-wrapper"]
				}
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
				"parentName": "ContentNavbarLinkProperties",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["font-control-group"]
				}
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
				"name": "PaddingGroup",
				"parentName": "ContentNavbarLinkProperties",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"items": [],
					"caption": "$Resources.Strings.PaddingCaption",
					"wrapClass": ["padding-control-group"]
				}
			},
			{
				"operation": "insert",
				"name": "PaddingPropertyModulePage",
				"parentName": "PaddingGroup",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.MODULE
				}
			}
		]
	};
});
