define("RecommendationModule", ["RecommendationModuleResources", "TooltipUtilities", "ViewGeneratorV2"],
	function(Resources) {
		var recomendationViewModelClass = Ext.define("BPMSoft.configuration.RecommendationModuleViewModel", {
			extend: "BPMSoft.BaseViewModel",
			alternateClassName: "BPMSoft.RecommendationModuleViewModel",
			mixins: {
				TooltipUtilitiesMixin: "BPMSoft.TooltipUtilities"
			},
			values: {
				recommendation: "",
				informationOnStep: ""
			}
		});

		/**
		 * @class BPMSoft.configuration.RecommendationModule
		 * Represents additional information that it is got from the business-process element.
		 */
		Ext.define("BPMSoft.configuration.RecommendationModule", {
			extend: "BPMSoft.BaseModule",
			alternateClassName: "BPMSoft.RecommendationModule",
			Ext: null,
			BPMSoft: null,
			sandbox: null,

			/**
			 * Creates config to generate view.
			 * @param {Object} executionData Information data.
			 * @return {BPMSoft.Container} Configuration of view
			 */
			getView: function(executionData) {
				var viewGenerator = this.Ext.create("BPMSoft.ViewGenerator");
				var containerName = "displayingInformationContainer";
				var viewConfig = {
					className: "BPMSoft.Container",
					items: [],
					id: containerName,
					selectors: {
						wrapEl: "#" + containerName
					}
				};
				if (executionData.recommendation) {
					var recommendation = {
						className: "BPMSoft.Label",
						classes: {
							labelClass: ["information", "recommendation"]
						},
						caption: {
							bindTo: "recommendation"
						},
						markerValue: {
							bindTo: "recommendation"
						}
					};
					viewConfig.items.push(recommendation);
				}
				if (executionData.informationOnStep) {
					var informationOnStepButton = viewGenerator.generatePartial({
						itemType: this.BPMSoft.ViewItemType.INFORMATION_BUTTON,
						name: "InformationOnStep",
						markerValue: "InformationOnStep",
						content: {bindTo: "informationOnStep"}
					}, {
						schemaName: "RecommendationModule",
						schema: {},
						viewModelClass: recomendationViewModelClass
					});
					viewConfig.items.push(informationOnStepButton[0]);
				}
				return this.Ext.create("BPMSoft.Container", viewConfig);
			},

			/**
			 * @inheritdoc BPMSoft.BaseModule#render
			 * @protected
			 * @overridden
			 */
			render: function(renderTo) {
				this.callParent(arguments);
				var processExecData = this.sandbox.publish("GetProcessExecData");
				if (processExecData && (processExecData.recommendation || processExecData.informationOnStep)) {
					var recommendation = processExecData.recommendation ||
						Resources.localizableStrings.DefaultInformationOnStep;
					var informationOnStep = processExecData.informationOnStep || null;
					var view = this.getView({
						"recommendation": recommendation,
						"informationOnStep": informationOnStep
					});
					var viewModel = this.Ext.create("BPMSoft.RecommendationModuleViewModel");
					viewModel.set("recommendation", recommendation);
					viewModel.set("informationOnStep", informationOnStep);
					view.bind(viewModel);
					view.render(renderTo);
				}
			}
		});

		return BPMSoft.RecommendationModule;
	}
);
