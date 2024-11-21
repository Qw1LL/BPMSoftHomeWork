define("ProductSalesUtils", ["ext-base", "BPMSoft", "ProductSalesUtilsResources", "MaskHelper"],
	function(Ext, BPMSoft, resources, MaskHelper) {
		var openProductSelectionModuleInChain = function(config, sandbox) {
			var newCatalogueEnabled = BPMSoft.Features.getIsEnabled("NewProductSelectionCatalogue");
			var productSelectionModuleName = newCatalogueEnabled ? "ProductSelectionModuleV2" : "ProductSelectionModule";
			MaskHelper.ShowBodyMask();
			var params = sandbox.publish("GetHistoryState");
			sandbox.publish("PushHistoryState", {
				hash: params.hash.historyState,
				silent: true
			});
			sandbox.loadModule(productSelectionModuleName, {
				renderTo: "centerPanel",
				id: config.moduleId + "_ProductSelectionModule",
				keepAlive: true
			});
			return true;
		};

		return {
			openProductSelectionModuleInChain: openProductSelectionModuleInChain
		};
	});
