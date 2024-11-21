define("CredentialsSyncSettingsEdit", ["BaseSchemaModuleV2"], function() {

	/**
	 * @class BPMSoft.configuration.CredentialsSyncSettingsEdit
	 * Sync settings tab module.
	 */
	Ext.define("BPMSoft.configuration.CredentialsSyncSettingsEdit", {
		extend: "BPMSoft.BaseSchemaModule",
		alternateClassName: "BPMSoft.CredentialsSyncSettingsEdit",

		/**
		 * Value pairs fow view model default values.
		 */
		defaultValues: null,

		/**
		 * @inheritdoc BPMSoft.BaseSyncSettingsEdit#init
		 * @overridden
		 */
		init: function(callback, scope) {
			this.callParent([function() {
				this.setDefaultValues();
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
		 * @inheritdoc BPMSoft.BaseSyncSettingsEdit#getViewConfig
		 * @overriddem
		 */
		getViewConfig: function() {
			var viewConfig = this.callParent(arguments);
			viewConfig.classes.wrapClassName = ["credantials-modal-box"];
			return viewConfig;
		}
	});

	return BPMSoft.CredentialsSyncSettingsEdit;
});
