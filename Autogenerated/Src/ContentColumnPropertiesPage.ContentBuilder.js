define("ContentColumnPropertiesPage", [],
	function() {
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
								PropertyName: "WrapperStyles"
							}
						}
					}
				}
			},
			attributes: {},
			methods: {},
			diff: [
				{
					"operation": "insert",
					"name": "ContentColumnPropertiesContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"wrapClass": ["content-block-structure-wrapper"]
					}
				},
				{
					"operation": "insert",
					"name": "ColumnStylesContainer",
					"propertyName": "items",
					"parentName": "ContentColumnPropertiesContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"wrapClass": ["content-styles-container"]
					}
				},
				{
					"operation": "insert",
					"name": "VerticalAlignLabelContainer",
					"parentName": "ColumnStylesContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"wrapClass": ["group-label-wrapper"]
					},
					"index": 2
				},
				{
					"operation": "insert",
					"parentName": "VerticalAlignLabelContainer",
					"name": "VerticalAlignLabel",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"markerValue": "VerticalAlignLabel",
						"caption": "$Resources.Strings.VerticalAlign"
					}
				},
				{
					"operation": "insert",
					"name": "VerticalAlignInfoTip",
					"parentName": "VerticalAlignLabelContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
						"content": "$Resources.Strings.VerticalAlignInfo",
						"style": BPMSoft.TipStyle.WHITE,
						"behaviour": {
							"displayEvent": BPMSoft.TipDisplayEvent.HOVER
						}
					}
				},
				{
					"operation": "insert",
					"name": "VerticalAlignContainer",
					"parentName": "ColumnStylesContainer",
					"propertyName": "items",
					"values": {
						"markerValue": "VerticalAlignContainer",
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["content-builder-align-container"],
						"items": []
					},
					"index": 3
				},
				{
					"operation": "insert",
					"name": "VerticalAlignPropertyModulePage",
					"parentName": "VerticalAlignContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.MODULE
					}
				}
			]
		};
	});
