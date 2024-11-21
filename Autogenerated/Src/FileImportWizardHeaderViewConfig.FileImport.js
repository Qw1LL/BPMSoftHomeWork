define("FileImportWizardHeaderViewConfig", ["WizardHeaderModule"], function() {
	Ext.define("BPMSoft.configuration.FileImportWizardHeaderViewConfig", {
		extend: "BPMSoft.WizardHeaderViewConfig",
		alternateClassName: "BPMSoft.FileImportWizardHeaderViewConfig",

		/**
		 * @inheritdoc
		 * @overridden
		 */
		getWizardContainerViewConfig: function() {
			var config = this.callParent(arguments);
			Ext.apply(config, {
				generateId: false,
				markerValue: {
					bindTo: "getWizardHeaderContainerMakerValue"
				}
			});
			return config;
		},

		/**
		 * @inheritdoc
		 * @overridden
		 */
		getHeaderCaptionContainerViewConfig: function() {
			var config = this.callParent(arguments);
			Ext.apply(config, {
				generateId: false
			});
			return config;
		},

		/**
		 * @inheritdoc
		 * @overridden
		 */
		getUtilsContainerViewConfig: function() {
			var config = this.callParent(arguments);
			Ext.apply(config, {
				generateId: false
			});
			return config;
		},

		/**
		 * @inheritdoc
		 * @overridden
		 */
		getUtilsLeftContainerViewConfig: function() {
			return {
				"generateId": false,
				"name": "utilsLeftContainer",
				"id": "utilsLeftContainer",
				"itemType": BPMSoft.ViewItemType.CONTAINER,
				"wrapClass": ["utils-left"],
				"items": [
					{
						generateId: false,
						itemType: BPMSoft.ViewItemType.BUTTON,
						name: "CloseButton",
						caption: {bindTo: "Resources.Strings.CloseButtonCaption"},
						// classes: {
						// 	textClass: ["utils-button"],
						// 	wrapperClass: ["utils-button"]
						// },
						click: {bindTo: "closeButtonClick"},
						markerValue: "CloseButton"
					},
					{
						generateId: false,
						itemType: BPMSoft.ViewItemType.BUTTON,
						name: "PreviousStepButton",
						caption: {bindTo: "Resources.Strings.PreviousStepButton"},
						// classes: {
						// 	textClass: ["utils-button"],
						// 	wrapperClass: ["utils-button"]
						// },
						enabled: {bindTo: "arrowLeftEnabled"},
						click: {bindTo: "previousStepButtonClick"},
						markerValue: "PreviousButton"
					},
					{
						generateId: false,
						itemType: BPMSoft.ViewItemType.BUTTON,
						name: "NextStepButton",
						caption: {bindTo: "Resources.Strings.NextStepButtonCaption"},
						// classes: {
						// 	textClass: ["utils-button"],
						// 	wrapperClass: ["utils-button"]
						// },
						enabled: {bindTo: "arrowRightEnabled"},
						visible: {bindTo: "arrowRightVisible"},
						click: {bindTo: "nextStepButtonClick"},
						markerValue: "NextButton"
					}
				]
			};
		},

		/**
		 * @inheritdoc
		 * @overridden
		 */
		getUtilsRightContainerViewConfig: function() {
			return {
				"name": "utilsRightContainer",
				"itemType": BPMSoft.ViewItemType.CONTAINER,
				"wrapClass": ["utils-right"],
				"items": []
			};
		}
	});
});
