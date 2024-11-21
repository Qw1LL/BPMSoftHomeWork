define("SetupTelephonyParametersPageModule", ["BaseSchemaModuleV2", "CtiConstants", "CtiBaseHelper"],
		function(BaseSchemaModuleV2, CtiConstants, CtiBaseHelper) {
	/**
	 * @class BPMSoft.configuration.SetupTelephonyParametersPageModule
	 * ##### ######## ######## ########## #########.
	 */
	Ext.define("BPMSoft.configuration.SetupTelephonyParametersPageModule", {
		alternateClassName: "BPMSoft.SetupTelephonyParametersPageModule",
		extend: "BPMSoft.BaseSchemaModule",

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#init
		 * @overridden
		 */
		init: function(callback, scope) {
			callback = callback || function() {};
			if (this.viewModel) {
				this.viewModel.set("Restored", true);
				callback.call(scope);
				return;
			}
			this.schemaBuilder = this.Ext.create("BPMSoft.SchemaBuilder");
			this.initHistoryState();
			BPMSoft.SysSettings.querySysSettingsItem("SysMsgLib", function(sysSettingsValue) {
				var currentSysMsgLibId = sysSettingsValue.value.toLowerCase();
				if (BPMSoft.SysValue.CTI && BPMSoft.SysValue.CTI.sysMsgLibId !== currentSysMsgLibId) {
					BPMSoft.SysValue.CTI.isInitialized = false;
				}
				CtiBaseHelper.queryCtiSettings(function(ctiSettings) {
					this.schemaName = ctiSettings.setupPageSchemaName;
					this.generateSchemaStructure(function(viewModelClass, viewConfig) {
						if (this.destroyed) {
							return;
						}
						this.viewModelClass = viewModelClass;
						this.viewConfig = viewConfig;
						var viewModel = this.viewModel = this.createViewModel(viewModelClass);
						viewModel.set("sysMsgLibId", ctiSettings.sysMsgLibId);
						viewModel.init(function() {
							if (!this.destroyed) {
								callback.call(scope);
							}
						}, this);
						var headerCaption = this.viewModel.get("Resources.Strings.HeaderCaption");
						BPMSoft.SysValue.CTI.setupPageName = headerCaption;
					}, this);
				}.bind(this));
			}, this);
		},

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#render
		 * @overridden
		 */
		render: function() {
			this.callParent(arguments);
		},

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#initHistoryState
		 * @overridden
		 */
		initHistoryState: function() {
			var sandbox = this.sandbox;
			var state = sandbox.publish("GetHistoryState");
			var currentHash = state.hash;
			var currentState = state.state || {};
			if (currentState.moduleId === sandbox.id) {
				return;
			}
			var newState = BPMSoft.deepClone(currentState);
			newState.moduleId = sandbox.id;
			sandbox.publish("ReplaceHistoryState", {
				stateObj: newState,
				hash: currentHash.historyState,
				silent: true
			});
		}

	});
	return BPMSoft.SetupTelephonyParametersPageModule;
});
