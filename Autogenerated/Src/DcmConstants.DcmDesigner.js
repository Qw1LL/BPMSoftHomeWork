define("DcmConstants", ["ext-base", "BPMSoft", "DcmConstantsResources"], function(Ext, BPMSoft, resources) {
	/**
	 * @class BPMSoft.configuration.DcmConstants
	 * Class DcmConstants contains constants for dcm processes.
	 */
	Ext.define("BPMSoft.configuration.DcmConstants", {
		alternateClassName: "BPMSoft.DcmConstants",
		singleton: true,

		/**
		 * Dcm schema element required type.
		 * @enum
		 */
		ElementRequiredType: {
			NOT_REQUIRED: {
				value: 0,
				displayValue: resources.localizableStrings.NotRequiredTypeCaption
			},
			REQUIRED: {
				value: 1,
				displayValue: resources.localizableStrings.RequiredTypeCaption
			}
		},

		/**
		 * Dcm schema stage transition type.
		 * @enum
		 */
		StageTransitionType: {
			NONE: {
				value: 0,
				displayValue: resources.localizableStrings.NoneStageTransitionTypeCaption
			},
			AFTER_REQUIRED: {
				value: 1,
				displayValue: resources.localizableStrings.AfterRequiredStageTransitionTypeCaption
			},
			AFTER_ALL: {
				value: 2,
				displayValue: resources.localizableStrings.AfterAllStageTransitionTypeCaption
			}
		}
	});

	return BPMSoft.DcmConstants;
});
