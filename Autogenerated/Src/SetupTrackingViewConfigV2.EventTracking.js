define("SetupTrackingViewConfigV2", ["SetupTrackingViewConfigV2Resources", "MultilineLabel", "css!MultilineLabel",
		"css!SetupTrackingViewConfigV2"],
	function(resources) {
		Ext.define("BPMSoft.configuration.SetupTrackingViewConfig", {
			extend: "BPMSoft.BaseObject",
			alternateClassName: "BPMSoft.SetupTrackingViewConfig",
			viewModelClass: null,

			/**
			 * Returns the view configuration of the module.
			 * @returns {Object} The view configuration of the module.
			 */
			generate: function() {
				return [
					{
						"name": "ModuleContainer",
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": {wrapClassName: ["setuptracking-merge-container"]},
						"items": [
							{
								"name": "HeaderContainer",
								"itemType": BPMSoft.ViewItemType.CONTAINER,
								"wrapClass": ["header"],
								"items": [
									{
										"name": "HeaderLabel",
										"itemType": BPMSoft.ViewItemType.LABEL,
										"classes": {"labelClass": ["header-label"]},
										"caption": resources.localizableStrings.SetupTrackingModuleCaption
									},
									{
										"name": "CloseButton",
										"itemType": BPMSoft.ViewItemType.BUTTON,
										"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
										"contentVisible": true,
										"imageConfig": resources.localizableImages.CloseIcon,
										"classes": {"wrapperClass": ["close-btn"]},
										"click": {"bindTo": "onCancelButtonClick"}
									},
									{
										"name": "DescriptionLabel",
										"itemType": BPMSoft.ViewItemType.LABEL,
										"className": "BPMSoft.MultilineLabel",
										"contentVisible": true,
										"classes": {"labelClass": ["description-label"]},
										"caption": resources.localizableStrings.SetupTrackingLabelCaption
									}
								]
							},
							{
								"name": "ContentContainer",
								"itemType": BPMSoft.ViewItemType.CONTAINER,
								"wrapClass": ["content"],
								"items": [
									{
										"name": "LabelContainer",
										"itemType": BPMSoft.ViewItemType.CONTAINER,
										"wrapClass": ["label-wrap"],
										"items": [
											{
												"name": "ApiKeyLabel",
												"itemType": BPMSoft.ViewItemType.LABEL,
												"className": "BPMSoft.Label",
												"caption": resources.localizableStrings.ApiKeyCaption
											}
										]
									},
									{
										"name": "ControlContainer",
										"itemType": BPMSoft.ViewItemType.CONTAINER,
										"wrapClass": ["control-wrap"],
										"items": [
											{
												"name": "ApiKeyEdit",
												"dataValueType": BPMSoft.DataValueType.TEXT,
												"className": "BPMSoft.TextEdit",
												"labelConfig": {
													"visible": false
												},
												"value": {
													"bindTo": "ApiKey"
												}
											}
										]
									}
								]
							},
							{
								"name": "FooterContainer",
								"itemType": BPMSoft.ViewItemType.CONTAINER,
								"wrapClass": ["footer"],
								"items": [
									{
										"name": "CancelButton",
										"itemType": BPMSoft.ViewItemType.BUTTON,
										"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
										"caption": resources.localizableStrings.CancelButtonCaption,
										"click": {"bindTo": "onCancelButtonClick"}
									},
									{
										"name": "StartButton",
										"itemType": BPMSoft.ViewItemType.BUTTON,
										"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
										"caption": resources.localizableStrings.StartButtonCaption,
										"click": {"bindTo": "onStartButtonClick"}
									}
								]
							}
						]
					}
				];
			}
		});
	});
