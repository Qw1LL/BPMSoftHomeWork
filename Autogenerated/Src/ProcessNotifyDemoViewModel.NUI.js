define('ProcessNotifyDemoViewModel', ['ext-base', 'BPMSoft', 'sandbox', 'ProcessNotifyDemoViewModelResources'],
	function(Ext, BPMSoft, sandbox, resources) {

		var generateMainViewModel = function() {
			var viewModel = Ext.create('BPMSoft.BaseViewModel');
			return viewModel;
		}

		return {
			generate: generateMainViewModel
		}

	});
