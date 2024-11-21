 define("ContentMjHeroPropertiesPage", ["css!ContentMjHeroPropertiesPageCSS"], function() {
	return {
		modules: {
			VerticalAlignPropertyModulePage: {
				moduleId: "VerticalAlignPropertyModulePage",
				moduleName: "ConfigurationModuleV2",
				config: {
					schemaName: "VerticalAlignPropertyModule",
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
							PropertyName: "WrapperStyles"
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
							PropertyName: "WrapperStyles",
							UseImagePosition: true
						}
					}
				}
			}
		},
		attributes: {
			/**
			 * Actual hero styles.
			 */
			WrapperStyles: {
				dataValueType: BPMSoft.DataValueType.TEXT,
				onChange: "onWrapperStylesChanged"
			},

			/**
			 * Height of hero block.
			 */
			Height: {
				dataValueType: BPMSoft.core.enums.DataValueType.INTEGER,
				type: BPMSoft.core.enums.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true,
				onChange: "_onHeightChanged"
			}
		},
		methods: {
			/**
			 * @private
			 */
			_onHeightChanged: function(model, value) {
				const styles = Ext.JSON.decode(this.$WrapperStyles, true);
				if (value && this._columnHeightValidator(value).isValid) {
					styles.height = value + "px";
					this.$WrapperStyles = JSON.stringify(styles, null, "\t");
					this.save(["height"], "WrapperStyles");
				}
			},

			/**
			 * @private
			 */
			_columnHeightValidator: function(value) {
				return Ext.isEmpty(value)
					? { isValid: true }
					: BPMSoft.validateNumberRange(62, 1500, value);
			},

			/**
			 * @private
			 */
			_initHeight: function(styles) {
				if (styles && styles.hasOwnProperty("height")) {
					this.$Height = styles.height.replace("px", "");
				} else {
					styles.height = this.$Height = 360;
				}
			},

			/**
			 * @inheritdoc ContentItemPropertiesPage#onContentItemConfigChanged
			 * @override
			 */
			onContentItemConfigChanged: function(config) {
				this.callParent(arguments);
				if (config) {
					this.$Config = config;
					const wrapperStyles = config.WrapperStyles = config.WrapperStyles || {};
					this.$WrapperStyles = JSON.stringify(wrapperStyles, null, "\t");
					this._initHeight(wrapperStyles);
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#setValidationConfig
			 * @override
			 */
			setValidationConfig: function() {
				this.callParent(arguments);
				this.addColumnValidator("Height", this._columnHeightValidator);
			},

			/**
			 * Saves content item wrapper style.
			 * @protected
			 */
			onWrapperStylesChanged: function() {
				const styles = Ext.JSON.decode(this.$WrapperStyles, true);
				Ext.apply(this.$Config, { WrapperStyles: styles });
			}
		},
		diff: [
			{
				"operation": "insert",
				"name": "MjHeroPropertiesContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["mjhero-properties-container"]
				}
			},
			{
				"operation": "insert",
				"name": "SizeGroup",
				"parentName": "MjHeroPropertiesContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"items": [],
					"caption": "$Resources.Strings.SizeCaption",
					"wrapClass": ["size-control-group"]
				},
				"index": 0
			},
			{
				"operation": "insert",
				"name": "SizePropertiesLayout",
				"parentName": "SizeGroup",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["control-editor-wrapper"]
				}
			},
			{
				"operation": "insert",
				"name": "SizePropertiesGrid",
				"parentName": "SizePropertiesLayout",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "Height",
				"parentName": "SizePropertiesGrid",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.TEXT,
					"markerValue": "Height",
					"value": "$Height",
					"wrapClass": ["style-input"],
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 8,
						"rowSpan": 1
					},
					"labelConfig": {
						"caption": "$Resources.Strings.HeightCaption"
					}
				}
			},
			{
				"operation": "insert",
				"name": "VerticalAlignGroup",
				"parentName": "MjHeroPropertiesContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"items": [],
					"caption": "$Resources.Strings.VerticalAlignCaption"
				},
				"index": 1
			},
			{
				"operation": "insert",
				"name": "VerticalAlignContainer",
				"parentName": "VerticalAlignGroup",
				"propertyName": "items",
				"values": {
					"markerValue": "VerticalAlignContainer",
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["content-builder-align-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "VerticalAlignPropertyModulePage",
				"parentName": "VerticalAlignContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.MODULE
				}
			},
			{
				"operation": "insert",
				"name": "PaddingGroup",
				"parentName": "MjHeroPropertiesContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"items": [],
					"caption": "$Resources.Strings.PaddingCaption",
					"wrapClass": ["padding-control-group"]
				},
				"index": 2
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
				"parentName": "MjHeroPropertiesContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"items": [],
					"caption": "$Resources.Strings.BackgroundLabelCaption",
					"wrapClass": ["background-control-group"]
				},
				"index": 3
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
