define("ContentElementPanel", [], function() {
	return {
		methods: {

			// region Methods: Protected

			/**
			 * @inheritdoc ContentItemPanel#initPanelAttributes
			 * @overridden
			 */
			initPanelAttributes: function() {
				this.callParent(arguments);
				if (this.$ElementInfo) {
					const elementSettings = this.$ElementInfo.Settings;
					const caption = this.$ElementInfo.DesignTimeConfig && this.$ElementInfo.DesignTimeConfig.Caption;
					if (caption) {
						this.$ElementCaption = this.$ElementInfo.DesignTimeConfig.Caption;
					}
					const icon = elementSettings && elementSettings.panelIcon;
					if (icon) {
						this.$ElementIcon = icon;
					}
					const contextHelpText = elementSettings && elementSettings.contextHelpText;
					if (contextHelpText) {
						this.$ElementContextHelp = contextHelpText;
					}
					this.$IsStylesVisible = elementSettings && elementSettings.isStylesVisible;
				}
			},

			/**
			 * @inheritdoc ContentItemPanel#initActiveTab
			 * @overridden
			 */
			initActiveTab: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BasePageV2#onRender
			 * @overridden
			 */
			onRender: function() {
				this.callParent(arguments);
				const elementSettings = this.$ElementInfo && this.$ElementInfo.Settings;
				if (elementSettings) {
					const schemaName = elementSettings.schemaName;
					if (schemaName && !elementSettings.notImplemented) {
						this.sandbox.loadModule("ConfigurationModuleV2", {
							renderTo: "ContentElementAttributesContainer",
							moduleId: this.sandbox.id + schemaName,
							instanceConfig: {
								useHistoryState: false,
								schemaName: schemaName,
								isSchemaConfigInitialized: true,
								parameters: {
									viewModelConfig: {
										Config: this.$Config,
										ContentBuilderState: this.$ContentBuilderState
									}
								}
							}
						});
					}
				}
			}

			// endregion

		},
		diff: [
			{
				"operation": "insert",
				"name": "ContentElementAttributesContainer",
				"parentName": "PropertiesContent",
				"propertyName": "items",
				"values": {
					"id": "ContentElementAttributesContainer",
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": []
				},
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ContentElementStylesContainer",
				"parentName": "PropertiesContent",
				"propertyName": "items",
				"values": {
					"id": "ContentElementStylesContainer",
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"visible": "$IsStylesVisible"
				},
				"index": 1
			},
			{
				"operation": "move",
				"name": "ContentItemStylesPageModule",
				"parentName": "ContentElementStylesContainer",
				"propertyName": "items"
			},
			{
				"operation": "merge",
				"name": "PropertiesTabPanel",
				"values": {
					"visible": false
				}
			},
			{
				"operation": "remove",
				"name": "ContentBlockPropertiesPageModule"
			}
		]
	};
});
