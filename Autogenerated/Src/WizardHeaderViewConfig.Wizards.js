/**
 * Class generating configuration presenting the upper panel of the wizard.
 */
Ext.define("BPMSoft.configuration.WizardHeaderViewConfig", {
	extend: "BPMSoft.BaseObject",
	alternateClassName: "BPMSoft.WizardHeaderViewConfig",

	/**
	 * ########## ############ ####### ###### #######.
	 * @returns {Object[]} ########## ############ ############# ####### ###### #######.
	 */
	generate: function() {
		var itemsConfig = [];
		var wizardContainerViewConfig = this.getWizardContainerViewConfig();
		var wizardFlexibleContainerViewConfig = wizardContainerViewConfig.items[0];
		var wizardContainerItems = wizardFlexibleContainerViewConfig.items;
		var headerCaptionContainerViewConfig = this.getHeaderCaptionContainerViewConfig();

		wizardContainerItems.push(headerCaptionContainerViewConfig);
		var utilsContainerViewConfig = this.getUtilsContainerViewConfig();
		wizardContainerItems.push(utilsContainerViewConfig);
		itemsConfig.push(wizardContainerViewConfig);

		return itemsConfig;
	},

	getWizardContainerViewConfig: function() {
		return {
			"name": "WizardContainer",
			"wrapClass": ["wizard-container"],
			"itemType": BPMSoft.ViewItemType.CONTAINER,
			"items": [{
					"name": "WizardFlexible",
					"styles": { "display": "flex" },
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			]
		};
	},

	getHeaderCaptionContainerViewConfig: function() {
		return {
			"name": "HeaderCaptionContainer",
			"itemType": BPMSoft.ViewItemType.CONTAINER,
			"wrapClass": ["header"],
			"visible": {
				bindTo: "caption",
				bindConfig: {
					converter: function(value) {
						return !!value;
					},
				}
			},
			"items": [{
				"itemType": BPMSoft.ViewItemType.LABEL,
				"name": "HeaderCaption",
				"click": {bindTo: "onHeaderCaptionClick"},
				"caption": {bindTo: "caption"},
				"labelConfig": {
					classes: ["header-label", "header-section-caption-class"]
				}
			}]
		};
	},

	getUtilsContainerViewConfig: function() {
		var utilsLeftContainerViewConfig = this.getUtilsLeftContainerViewConfig();
		var utilsRightContainerViewConfig = this.getUtilsRightContainerViewConfig();
		var utilsFooterContainerViewConfig = this.getUtilsFooterContainerViewConfig();
		var utilsCloseButtonContainerViewConfig = this.getUtilsCloseButtonContainerViewConfig();
		return {
			"name": "UtilsContainer",
			"itemType": BPMSoft.ViewItemType.CONTAINER,
			"wrapClass": ["utils"],
			"items": [utilsLeftContainerViewConfig, utilsRightContainerViewConfig, utilsFooterContainerViewConfig, utilsCloseButtonContainerViewConfig]
		};
	},

	getUtilsLeftContainerViewConfig: function() {
		return {
			"name": "utilsLeftContainer",
			"itemType": BPMSoft.ViewItemType.CONTAINER,
			"wrapClass": ["utils-left"],
			"items": [
				{
					itemType: BPMSoft.ViewItemType.BUTTON,

					name: "SaveButton",
					//Мастер раздела
					caption: {bindTo: "Resources.Strings.SaveButtonCaption"},
					// classes: {
					// 	textClass: ["utils-button"],
					// wrapperClass: ["utils-button"]
					// },
					click: {bindTo: "saveButtonClick"},
					tips: [{
						itemType: BPMSoft.ViewItemType.TIP,
						displayMode: BPMSoft.TipDisplayMode.NARROW,
						content: {bindTo: "Resources.Strings.SaveButtonHint"},
						restrictAlignType: BPMSoft.AlignType.BOTTOM
					}],
					visible: {bindTo: "isSaveButtonVisible"},
					style: BPMSoft.controls.ButtonEnums.style.ORANGE,
				},
				{
					itemType: BPMSoft.ViewItemType.BUTTON,
					name: "CancelButton",
					caption: {bindTo: "Resources.Strings.CancelButtonCaption"},
					// classes: {
					// 	textClass: ["utils-button"],
					// 	wrapperClass: ["utils-button"]
					// },
					click: {bindTo: "cancelButtonClick"},
					visible: {bindTo: "isCancelButtonVisible"}
				}
			]
		};
	},

	getUtilsRightContainerViewConfig: function() {
		return {
			"name": "utilsRightContainer",
			"itemType": BPMSoft.ViewItemType.CONTAINER,
			"wrapClass": ["utils-right"],
			"items": [{
				itemType: BPMSoft.ViewItemType.BUTTON,
				name: "PreviousButton",
				imageConfig: {bindTo: "Resources.Images.ArrowLeft"},
				classes: {
					textClass: ["utils-button"],
					wrapperClass: ["utils-button"]
				},
				click: {bindTo: "previous"},
				enabled: {bindTo: "arrowLeftEnabled"}
			}, {
				"name": "DataGrid",
				"idProperty": "Id",
				"collection": {"bindTo": "StepCollection"},
				"classes": {wrapClassName: ["wizard-steps-collection"]},
				"generator": "ContainerListGenerator.generatePartial",
				"itemType": BPMSoft.ViewItemType.GRID,
				"itemConfig": [{
					itemType: BPMSoft.ViewItemType.BUTTON,
					name: "StepButton",
					caption: {bindTo: "caption"},
					imageConfig: {bindTo: "imageConfig"},
					click: {bindTo: "click"},
					classes: {
						textClass: ["utils-button"],
						wrapperClass: ["utils-button"]
					},
					pressed: {bindTo: "isSelected"},
					visible: {bindTo: "canUseStep"},
					controlConfig: {"menu": {"items": {"bindTo": "StepCollection"}}}
				}]
			}, {
				itemType: BPMSoft.ViewItemType.BUTTON,
				name: "NextButton",
				imageConfig: {bindTo: "Resources.Images.ArrowRight"},
				classes: {
					textClass: ["utils-button"],
					wrapperClass: ["utils-button"]
				},
				click: {bindTo: "next"},
				enabled: {bindTo: "arrowRightEnabled"}
			}]
		};
	},

	getUtilsFooterContainerViewConfig: function() {
		return {
			"name": "utilsFooterContainer",
			"itemType": BPMSoft.ViewItemType.CONTAINER,
			"wrapClass": ["utils-footer"],
			"visible": {
				bindTo: "isUtilsFooterVisible"
			},
			"items": [
				{
					itemType: BPMSoft.ViewItemType.BUTTON,
					style: BPMSoft.controls.ButtonEnums.style.ORANGE,
					name: "SaveButtonFooter",
					caption: {bindTo: "Resources.Strings.SaveButtonCaption"},
					classes: {
						textClass: ["utils-button"],
						wrapperClass: ["utils-button"]
					},
					click: {bindTo: "saveButtonClick"},
					tips: [{
						itemType: BPMSoft.ViewItemType.TIP,
						displayMode: BPMSoft.TipDisplayMode.NARROW,
						content: {bindTo: "Resources.Strings.SaveButtonHint"},
						restrictAlignType: BPMSoft.AlignType.BOTTOM
					}],
					visible: {bindTo: "isSaveButtonFooterVisible"}
				},
				{
					itemType: BPMSoft.ViewItemType.BUTTON,
					style: BPMSoft.controls.ButtonEnums.style.DEFAULT,
					name: "CancelButtonFooter",
					caption: {bindTo: "Resources.Strings.CancelButtonCaption"},
					click: {bindTo: "cancelButtonClick"},
					visible: {bindTo: "isCancelButtonFooterVisible"}
				}
			]
		}
	},

	getUtilsCloseButtonContainerViewConfig: function() {
		return {
			"name": "closeButtonContainer",
			"itemType": BPMSoft.ViewItemType.CONTAINER,
			"wrapClass": ["utils-close-button-container"],
			"visible": {
				bindTo: "Resources.Strings.CloseButtonCaption",
				bindConfig: {
					converter: function(value) {
						return !!value;
					},
				}
			},
			"items": [
				{
					itemType: BPMSoft.ViewItemType.BUTTON,
					style: BPMSoft.controls.ButtonEnums.style.DEFAULT,
					name: "closeButton",
					caption: {bindTo: "Resources.Strings.CloseButtonCaption"},
					click: {bindTo: "closeButtonClick"},
				}
			]
		}
	},
});
