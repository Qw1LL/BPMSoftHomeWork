define("MLModelStateProgressBarUtils", ["MLConfigurationConsts", "BaseProgressBarModule", "css!BaseProgressBarModule"],
	function(MLConfigurationConsts) {
		/**
		 * @class BPMSoft.MLModelStateProgressBarUtils
		 * Methods for working with BPMSoft.BaseProgressBar for ML model state field.
		 */
		Ext.define("BPMSoft.MLModelStateProgressBarUtils", {
			extend: "BPMSoft.BaseObject",
			singleton: true,

			/**
			 * Returns value config for BPMSoft.BaseProgressBar.
			 * @param {Object} stateConfig Current MLModelState lookup attribute value.
			 * @return {null|{value: Number, displayValue: String}} Value config for BPMSoft.BaseProgressBar.
			 */
			getStateProgressBarValue: function(stateConfig) {
				if (!stateConfig) {
					return null;
				}
				const state = BPMSoft.findWhere(MLConfigurationConsts.ModelStates, {id: stateConfig.value});
				if (!state) {
					return null;
				}
				return {
					value: state.stageNumber,
					displayValue: stateConfig.displayValue
				};
			}
		});
		return BPMSoft.MLModelStateProgressBarUtils;
	});
