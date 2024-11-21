define("CampaignLogSectionV2", [], function() {
	return {
		entitySchemaName: "VwCampaignLog",
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "remove",
				"name": "SeparateModeAddRecordButton"
			},
			{
				"operation": "remove",
				"name": "DataGridActiveRowOpenAction"
			},
			{
				"operation": "remove",
				"name": "DataGridActiveRowCopyAction"
			},
			{
				"operation": "remove",
				"name": "DataGridActiveRowDeleteAction"
			}
		]/**SCHEMA_DIFF*/,
		methods: {
			changeSelectedSideBarMenu: function() {
				var moduleName = "Campaign";
				var moduleConfig = BPMSoft.configuration.ModuleStructure[moduleName];
				if (moduleConfig) {
					var sectionSchema = moduleConfig.sectionSchema;
					var config = moduleConfig.sectionModule + "/";
					if (sectionSchema) {
						config += moduleConfig.sectionSchema + "/";
					}
					this.sandbox.publish("SelectedSideBarItemChanged", config, ["sectionMenuModule"]);
				}
			},

			/**
			 * Hides menu item "Open wizard".
			 * @inheritdoc BaseSectionV2#addSectionDesignerViewOptions
			 * @overridden
			 */
			addSectionDesignerViewOptions: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#isVisibleDeleteAction
			 * @overridden
			 */
			isVisibleDeleteAction: function() {
				return false;
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#isVisibleDeleteAction
			 * @overridden
			 */
			getModuleCaption: function() {
				return this.get("Resources.Strings.Caption");
			}
		}
	};
});
