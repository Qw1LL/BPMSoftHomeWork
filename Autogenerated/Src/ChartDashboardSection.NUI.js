define('ChartDashboardSection', ['ext-base', 'BPMSoft', 'sandbox', 'ChartDashboardSectionResources'],
	function(Ext, BPMSoft, sandbox, resources, ConfigurationConstants) {
		var getViewModel = function() {
			return Ext.create('BPMSoft.BaseViewModel', {
				//todo SysModuleAnalyticsChart deleted
				entitySchema: null,
				methods: {
					getChart: function(key) {
						sandbox.publish('GenerateChart', key);
					},
					load: function() {

					}
				}
			});
		};

		function generateMainView() {
			var resultConfig = Ext.create('BPMSoft.Container', {
				id: 'topChartDashboardSectionContainer',
				selectors: {
					wrapEl: '#topChartDashboardSectionContainer'
				},
				items: [
					{
						className: 'BPMSoft.Label',
						classes: {
							labelClass: ['graph-header-name']
						},
						caption: 'TestLabel'
					}
				]
			});
			return resultConfig;
		}

		var render = function(renderTo) {
			var viewConfig = generateMainView();
			var viewModel = getViewModel();
			viewConfig.bind(viewModel);
			viewConfig.render(renderTo);
		};
		return {
			userCode: function() {
			},
			schema: function() {
			},
			methods: function() {
			},
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
	}
)
;
