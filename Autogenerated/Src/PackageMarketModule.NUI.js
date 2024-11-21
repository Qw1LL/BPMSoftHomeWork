define("PackageMarketModule", ["ext-base", "BPMSoft", "BaseViewModule"], function(Ext, BPMSoft) {
	/**
	 * @class BPMSoft.configuration.PackageMarketModule
	 * Class represents package market module. Uses to display market module.
	 * @private
	 */
	var packageMarketModule = Ext.define("BPMSoft.configuration.PackageMarketModule", {
		extend: "BPMSoft.BaseViewModule",
		alternateClassName: "BPMSoft.PackageMarketModule",

		marketModule: null,

		diff: [
			{
				"operation": "insert",
				"name": "ContentContainer",
				"values": {
					"id": "marketContentContainer",
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			}
		],

		/**
		 * Initializes market module.
		 * @protected
		 */
		initMarketModule: function() {
			this.marketModule = Ext.create("BPMSoft.PackageMarket", {
				sandbox: this.sandbox
			});
		},

		/**
		 * Loads market module.
		 * @protected
		 */
		loadMarketModule: function() {
			this.initMarketModule();
			if (!this.marketModule) {
				return;
			}
			this.marketModule.render({
				renderTo: "marketContentContainer",
				id: "package-market"
			});
		},

		/**
		 * @inheritdoc BPMSoft.BaseViewModule#render
		 * @overridden
		 */
		render: function() {
			this.callParent(arguments);
			this.loadMarketModule();
		}
	});
	return packageMarketModule;
});
