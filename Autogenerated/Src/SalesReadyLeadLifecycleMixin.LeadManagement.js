define("SalesReadyLeadLifecycleMixin", [],
	function() {
		Ext.define("BPMSoft.configuration.mixins.SalesReadyLeadLifecycleMixin", {
			alternateClassName: "BPMSoft.SalesReadyLeadLifecycleMixin",

			//region Methods: Protected

			/**
			 * Loads value of system setting.
			 * @protected
			 */
			loadSalesReadyLeadLifecycleSysSetting: function(callback, scope) {
				this.BPMSoft.SysSettings.querySysSettingsItem(["UseTheSalesReadyLeadLifecycle"], function(value) {
					this.set("UseTheSalesReadyLeadLifecycle", value)
					this.Ext.callback(callback, scope);
				}, this);
			},

			//endregion
		});
	});
