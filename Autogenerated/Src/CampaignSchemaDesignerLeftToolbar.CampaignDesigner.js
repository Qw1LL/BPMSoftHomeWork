define("CampaignSchemaDesignerLeftToolbar", ["CampaignElementSchemaManager"], function() {
	Ext.define("BPMSoft.controls.CampaignSchemaDesignerLeftToolbar", {
		extend: "BPMSoft.ProcessSchemaDesignerLeftToolbar",
		alternateClassName: "BPMSoft.CampaignSchemaDesignerLeftToolbar",

		/**
		 * @inheritdoc BPMSoft.ProcessSchemaDesignerLeftToolbar#elementSchemaManager
		 * @overridden
		 */
		elementSchemaManager: BPMSoft.CampaignElementSchemaManager,

		/**
		 * @inheritdoc BPMSoft.ProcessSchemaDesignerLeftToolbar#initToolbarGroups
		 * @overridden
		 */
		initToolbarGroups: function() {
			BPMSoft.CampaignElementGroups.Items.each(function(item) {
				var controlGroup = Ext.create("BPMSoft.ControlGroup", {
					id: this.getGroupId(item.name),
					caption: item.caption,
					collapsed: false,
					toggleCollapsed: BPMSoft.emptyFn
				});
				this.add(controlGroup);
			}, this);
		}
	});
	return BPMSoft.CampaignSchemaDesignerLeftToolbar;
});
