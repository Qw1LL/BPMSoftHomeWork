define('ColumnPage', ['ext-base', 'BPMSoft', 'sandbox',
	'ColumnPageView', 'ColumnPageViewModel'],
	function(Ext, BPMSoft, sandbox, ColumnPageView, ColumnPageViewModel) {
		var viewConfig;
		var viewModel;
		var columnConfig;
		var view;
		function render(renderTo) {
			if (viewModel) {
				var cloneConfig = BPMSoft.deepClone(viewConfig);
				view = Ext.create('BPMSoft.Container', cloneConfig);
				view.bind(viewModel);
				view.render(renderTo);
				return;
			}

			columnConfig = sandbox.publish('GetColumnInfo', null, [sandbox.id]) || {};
			var viewModelConfig = ColumnPageViewModel.generate(sandbox, columnConfig);
			viewModel = Ext.create('BPMSoft.BaseViewModel', viewModelConfig);

			BPMSoft.SysSettings.querySysSettingsItem('SchemaNamePrefix', function(response) {
				viewModel.init(function() {
					viewConfig = ColumnPageView.generate(columnConfig, viewModel);
					var config = BPMSoft.deepClone(viewConfig);
					view = Ext.create('BPMSoft.Container', config);
					viewModel.renderTo = renderTo;
					view.bind(viewModel);
					view.render(renderTo);
				});
			}, this);

		}
		return {
			init: function() {
				var state = sandbox.publish('GetHistoryState');
				var currentHash = state.hash;
				var currentState = state.state || {};
				if (currentState.moduleId === sandbox.id) {
					return;
				}
				var newState = BPMSoft.deepClone(currentState);
				newState.moduleId = sandbox.id;
				sandbox.publish('ReplaceHistoryState', {
					stateObj: newState,
					pageTitle: null,
					hash: currentHash.historyState,
					silent: true
				});
			},
			render: render
		};
	});
