define("SyncSettingsTabModule", ["BaseSchemaModuleV2"], function() {

	/**
	 * @class BPMSoft.configuration.SyncSettingsTabModule
	 * Sync settings tab mobule.
	 */
	Ext.define("BPMSoft.configuration.SyncSettingsTabModule", {
		extend: "BPMSoft.BaseSchemaModule",
		alternateClassName: "BPMSoft.SyncSettingsTabModule",

		/**
		 * Value pairs fow view model default values.
		 */
		defaultValues: null,

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#init
		 * @overridden
		 */
		init: function(callback, scope) {
			this.callParent([function() {
				this.setDefaultValues();
				this.sandbox.publish("TabInitialized", this.viewModel.get("TabName"));
				this.viewModel.on("reRenderTab", this.render, this);
				callback.call(scope);
			}, this]);
		},

		/**
		 *  Set default values in view model.
		 */
		setDefaultValues: function() {
			this.BPMSoft.each(this.defaultValues, function(item) {
				this.viewModel.set(item.name, item.value);
			}, this);
		},

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#destroy
		 * @overridden
		 */
		destroy: function(config) {
			if (config.keepAlive !== true) {
				if (this.viewModel) {
					this.viewModel.un("reRenderTab", this.render);
				}
				this.callParent(arguments);
			}
		}
	});

	return BPMSoft.SyncSettingsTabModule;
});
