define("SectionDesignerHeaderModule", [
	"ext-base", "BPMSoft", "sandbox", "SectionDesignerHeaderModuleResources",
	"SectionDesignerUtils", "SectionDesignDataModule", "SectionDesignerEnums"
],
	function(Ext, BPMSoft, sandbox, resources, SectionDesignerUtils, SectionDesignDataModule, SectionDesignerEnums) {

		var localizableStrings = resources.localizableStrings;

		var localizableImages = resources.localizableImages;

		var stepsButtons = [];

		var viewModel;

		function goToStep(step) {
			sandbox.publish("GoToStep", {
				stepCompleteResult: step
			});
		}

		function getButtonConfig(tag) {
			var config = {
				className: "BPMSoft.Button",
				caption: localizableStrings[tag + "ButtonCaption"],
				imageConfig: localizableImages[tag + "ButtonImage"],
				classes: {
					textClass: ["utils-button"],
					wrapperClass: ["utils-button"]
				},
				click: {
					bindTo: "on" + tag + "ButtonClick"
				},
				tag: tag,
				enabled: {
					bindTo: "getButtonEnabled"
				},
				markerValue: tag
			};
			return config;
		}

		function getViewModel() {
			return Ext.create("BPMSoft.BaseViewModel", {
				values: {
					visible: true
				},
				methods: {
					onStepItemClick: function(a1, a2, a3, tag) {
						var menuItems = this.get(tag + "MenuItems");
						if (menuItems && menuItems.getCount()) {
							return false;
						}
						sandbox.publish("PostDesignerStructureSelectedItem", {itemKey: tag});
					},
					onStepSubItemClick: function(tag) {
						sandbox.publish("PostDesignerStructureSelectedItem", {itemKey: tag});
					},
					onApplyButtonClick: function() {
						goToStep(SectionDesignerEnums.StepType.FINISH);
					},
					onNextButtonClick: function() {
						goToStep(SectionDesignerEnums.StepType.NEXT);
					},
					onPreviousButtonClick: function() {
						goToStep(SectionDesignerEnums.StepType.PREV);
					},
					onCancelButtonClick: function() {
						goToStep(SectionDesignerEnums.StepType.EXIT);
					},
					onSaveButtonClick: function() {
						goToStep(SectionDesignerEnums.StepType.FINISH);
					},
					getStepButtonStyle: function(tag) {
						var defaultStyle = BPMSoft.controls.ButtonEnums.style.DEFAULT;
						var currentStep = this.get("currentStep");
						var style;
						if (currentStep === tag) {
							style = BPMSoft.controls.ButtonEnums.style.ORANGE;
						}
						return style || defaultStyle;
					},
					getButtonEnabled: function(tag) {
						var customConfig = this.get("stepButtonsConfig");
						if (customConfig && customConfig[tag]) {
							return customConfig[tag].enabled;
						}
						return true;
					}
				}
			});
		}

		function onRefreshSteps(stepsConfig) {
			BPMSoft.each(stepsConfig, function(item) {
				var subItems = item.subItems;
				if (subItems) {
					var menuItemsCollectionName = item.tag + "MenuItems";
					var collection = this.get(menuItemsCollectionName);
					collection.clear();
					subItems.each(function(subItem) {
						collection.add(subItem.key, Ext.create("BPMSoft.BaseViewModel", {
							values: {
								Caption: subItem.caption,
								Tag: item.tag + "/" + subItem.key,
								MarkerValue: item.tag + "/" + subItem.caption,
								Click: {bindTo: "onStepSubItemClick"}
							}
						}));
					});
					var captionItemName = item.tag + "Caption";
					if (collection.getCount()) {
						viewModel.set(captionItemName, item.manyItemsCaption || item.caption);
					} else {
						viewModel.set(captionItemName, item.caption);
					}
				}
			}, this);
			var itemTag = sandbox.publish("GetSectionDesignerStructureItemKey");
			viewModel.set("currentStep", itemTag);
		}

		function getView() {
			var stepsConfig = sandbox.publish("GetDesignerStructureConfig");
			var stepNumber = 0;
			BPMSoft.each(stepsConfig, function(item) {
				var tag = item.tag;
				var button = getButtonConfig(tag);
				stepNumber++;
				var captionItemName = tag + "Caption";
				button.caption = {bindTo: captionItemName};
				stepsButtons.push(button);
				button.click = {bindTo: "onStepItemClick"};
				button.style = {bindTo: "getStepButtonStyle"};
				viewModel.set(captionItemName, item.caption);
				if (item.subItems) {
					var menuItemsCollectionName = tag + "MenuItems";
					button.menu = {
						items: {
							bindTo: menuItemsCollectionName
						}
					};
					viewModel.set(menuItemsCollectionName, new BPMSoft.Collection());
				}
			});
			onRefreshSteps.call(viewModel, stepsConfig);
			var saveButton = getButtonConfig("Save");
			saveButton.style = BPMSoft.controls.ButtonEnums.style.ORANGE;
			var cancelButton = getButtonConfig("Cancel");
			var utilsLeftButtons = [saveButton, cancelButton];
			var nextButton = getButtonConfig("Next");
			nextButton.hint = localizableStrings.NextButtonHint;
			nextButton.style = BPMSoft.controls.ButtonEnums.style.ORANGE;
			var previousButton = getButtonConfig("Previous");
			previousButton.hint = localizableStrings.PreviousButtonHint;
			previousButton.style = BPMSoft.controls.ButtonEnums.style.ORANGE;
			var utilsRightButtons = Ext.Array.push(previousButton, stepsButtons, nextButton);
			var config = {
				id: "moduleHeaderContainer",
				selectors: {
					wrapEl: "#moduleHeaderContainer"
				},
				visible: {
					bindTo: "visible"
				},
				items: [
					{
						className: "BPMSoft.Container",
						id: "headerCaptionContainer",
						selectors: {
							wrapEl: "#headerCaptionContainer"
						},
						classes: {
							wrapClassName: ["header"]
						},
						items: [{
							className: "BPMSoft.Label",
							classes: {
								labelClass: ["header-label", "header-section-caption-class"]
							},
							caption: {
								bindTo: "header"
							}
						}]
					},
					{
						className: "BPMSoft.Container",
						id: "utilsContainer",
						selectors: {
							wrapEl: "#utilsContainer"
						},
						classes: {
							wrapClassName: ["utils"]
						},
						items: [
							{
								className: "BPMSoft.Container",
								id: "utilsLeftContainer",
								selectors: {
									wrapEl: "#utilsLeftContainer"
								},
								classes: {
									wrapClassName: ["utils-left"]
								},
								items: utilsLeftButtons
							},
//							{
//								className: "BPMSoft.Container",
//								id: "utilsCenterContainer",
//								selectors: {
//									wrapEl: "#utilsCenterContainer"
//								},
//								classes: {
//									wrapClassName: ["utils-center"]
//								},
//								items: utilsCenterButtons
//							},
							{
								className: "BPMSoft.Container",
								id: "utilsRightContainer",
								selectors: {
									wrapEl: "#utilsRightContainer"
								},
								classes: {
									wrapClassName: ["utils-right"]
								},
								items: utilsRightButtons
							}
						]
					}
				]
			};
			return Ext.create("BPMSoft.Container", config);
		}

		/**
		 * ######### ######## ####### ######.
		 * @param {Object} config ################ ###### ####### ######.
		 * @param {String} config.header #########.
		 * @param {Object} config.buttons ################ ###### ###### ####### ######.
		 */
		function updateHeader(config) {
			this.set("visible", true);
			this.set("header", config.header);
			this.set("stepButtonsConfig", config.buttons || null);
		}

		function render(renderTo) {
			if (!viewModel) {
				viewModel = getViewModel();
				var view = getView();
				view.bind(viewModel);
				view.render(renderTo);
				viewModel.set("visible", false);
				sandbox.subscribe("RefreshSteps", onRefreshSteps, viewModel);
				var config = sandbox.publish("GetHeaderConfig");
				if (config && config.header) {
					updateHeader.call(viewModel, config);
				}
				sandbox.subscribe("SetPageHeaderInfo", function(config) {
					updateHeader.call(this, config);
				}, viewModel);
			}
		}

		return {
			render: render
		};
	}
);
