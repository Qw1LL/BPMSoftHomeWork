define("TrackingCodeViewConfigV2", ["TrackingCodeViewConfigV2Resources", "MultilineLabel", "css!MultilineLabel",
		"css!TrackingCodeViewConfigV2"],
	function(resources) {
		Ext.define("BPMSoft.configuration.TrackingCodeViewConfig", {
			extend: "BPMSoft.BaseObject",
			alternateClassName: "BPMSoft.TrackingCodeViewConfig",
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
						"classes": {wrapClassName: ["tracking-merge-container"]},
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
										"caption": resources.localizableStrings.TrackingCodeModuleCaption
									},
									{
										"name": "CloseButton",
										"itemType": BPMSoft.ViewItemType.BUTTON,
										"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
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
										"caption": resources.localizableStrings.TrackingCodeLabelCaption
									}
								]
							},
							{
								"name": "ContentContainer",
								"itemType": BPMSoft.ViewItemType.CONTAINER,
								"wrapClass": ["content"],
								"items": [
									{
										"name": "TrackingCodeLabel",
										"contentType": BPMSoft.ContentType.LONG_TEXT,
										"dataValueType": BPMSoft.DataValueType.TEXT,
										"className": "BPMSoft.MemoEdit",
										"labelConfig": {
											"visible": false
										},
										"value": {
											"bindTo": "TrackingCode"
										},
										"readonly": true,
										"height": "200px"
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
										"caption": resources.localizableStrings.CloseButtonCaption,
										"click": {"bindTo": "onCancelButtonClick"}
									}
								]
							}
						]
					}
				];
			}
		});
	});
