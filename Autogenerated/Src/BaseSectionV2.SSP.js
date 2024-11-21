define("BaseSectionV2", ["PortalFolderManagerViewModel", "SchemaAccessControllerMixin"], function () {
	return {
		mixins: {
			"SchemaAccessControllerMixin": "BPMSoft.SchemaAccessControllerMixin"
		},
		methods: {
			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#init
			 * @override
			 */
			init: function () {
				if (this.BPMSoft.isCurrentUserSsp()) {
					const hash = this.BPMSoft.combinePath("SectionModuleV2", "sectionSchema");
					const isRedirected = this.redirectIfDenied("sectionSchema", hash);
					if (isRedirected) {
						return;
					}
				}
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#getViewOptions
			 * @override
			 */
			getViewOptions: function () {
				if (!this.BPMSoft.isCurrentUserSsp()) {
					return this.callParent(arguments);
				}
				var viewOptions = this.Ext.create("BPMSoft.BaseViewModelCollection");
				if (this.getIsFeatureEnabled("PortalColumnConfig")) {
					viewOptions.addItem(this.getButtonMenuItem({
						"Caption": {"bindTo": "Resources.Strings.OpenGridSettingsCaption"},
						"Click": {"bindTo": "openGridSettings"},
						"Visible": {"bindTo": "IsGridSettingsMenuVisible"},
						"ImageConfig": this.get("Resources.Images.GridSettingsIcon")
					}));
				}
				return viewOptions;
			}

		}
	};
});
