define("TaggedTabPanel", ["BPMSoft", "ext-base"], function(BPMSoft, Ext) {

	/**
	 *  Class for working with tabs.
	 */
	Ext.define("BPMSoft.configuration.TaggedTabPanel", {

		extend: "BPMSoft.TabPanel",

		alternateClassName: "BPMSoft.TaggedTabPanel",

		/**
		 * @inheritdoc BPMSoft.controls.TabPanel#onTabClick
		 * @override
		 */
		onTabClick: function() {
			var oldActiveTabName = this.activeTabName;
			this.callParent(arguments);
			if (this.activeTabName === oldActiveTabName) {
				this.toggleCollapsed();
			}
		}
	});

	return Ext.create("BPMSoft.TaggedTabPanel");
});
