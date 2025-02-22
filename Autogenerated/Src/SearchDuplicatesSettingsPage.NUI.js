﻿define("SearchDuplicatesSettingsPage", [
	"ext-base", "BPMSoft", "sandbox", "SearchDuplicatesSettingsPageViewModel",
	"SearchDuplicatesSettingsPageView", "DuplicatesModuleView"
], function(Ext, BPMSoft, sandbox, SearchDuplicatesSettingsPageViewModel, SearchDuplicatesSettingsPageView,
		DuplicatesModuleView) {

	function render(renderTo) {
		var historyState = sandbox.publish("GetHistoryState");
		var viewModelConfig = SearchDuplicatesSettingsPageViewModel.generate(sandbox, historyState.state.entitySchemaName);
		var viewConfig = SearchDuplicatesSettingsPageView.generate();
		var view = Ext.create("BPMSoft.Container", viewConfig);
		var viewModel = Ext.create("BPMSoft.BaseViewModel", viewModelConfig);
		viewModel.on("change:isByPeriodGroup", function(model, tag) {
			var radioGroup = ["Changed", "All"];
			if (Ext.isEmpty(tag) || radioGroup.indexOf(tag) < 0) {
				return;
			}
			BPMSoft.each(radioGroup, function(item) {
				this.set("isByPeriod" + item, (tag === item));
			}, this);
		}, viewModel);
		viewModel.load();
		view.bind(viewModel);
		view.render(renderTo);
		var mainHeaderCaption =
				SearchDuplicatesSettingsPageViewModel.getMainHeaderCaption(historyState.state.entitySchemaName);
		sandbox.publish("InitDataViews", {caption: mainHeaderCaption});
		//loadCommandLine();
	}

	function destroy() {
		var historyState = sandbox.publish("GetHistoryState");
		var mainHeaderCaption = DuplicatesModuleView.getMainHeaderCaption(historyState.hash.entityName);
		sandbox.publish("InitDataViews", {caption: mainHeaderCaption});
	}

	return {
		render: render,
		destroy: destroy
	};
});
