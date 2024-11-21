define("AgeActualizationModalTimeEditModuleSchema", ["ProcessModuleUtilities"], function(ProcessModuleUtilities) {
	return {
		methods: {

			//region Methods: Public

			/**
			 * @inheritDoc BPMSoft.BaseModalTimeEditModuleSchema#initSelectedTimeValue
			 * @overridden
			 */
			initSelectedTimeValue: function() {
				BPMSoft.SysSettings.querySysSettingsItem("AutomaticAgeActualizationTime",
					this.initSelectedTimeValueCallback, this);
			},

			/**
			 * @inheritDoc BPMSoft.BaseModalTimeEditModuleSchema#saveSelectedTimeValue
			 * @overridden
			 */
			saveSelectedTimeValue: function() {
				BPMSoft.SysSettings.postSysSettingsValue("AutomaticAgeActualizationTime", this.$SelectedTimeValue,
					this.saveSelectedTimeValueCallback, this);
			},

			/**
			 * @inheritDoc BPMSoft.BaseModalTimeEditModuleSchema#saveSelectedTimeValueCallback
			 * @overridden
			 */
			saveSelectedTimeValueCallback: function() {
				this.callParent(arguments);
				ProcessModuleUtilities.executeProcess({
					"sysProcessName": "ContactAgeActualizationJobRestartProcess"
				});
			}

			//endregion

		}
	};
});