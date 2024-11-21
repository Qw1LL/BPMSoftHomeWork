define('SummaryViewModel', ['ext-base', 'BPMSoft', 'SummaryViewModelResources'],
	function(Ext, BPMSoft, resources) {
		var entitySchema;

		function generateItem() {
			var viewModel = {
				values: {
					columnCaption: '',
					columnValue: ''
				},
				methods: {}
			};
			return viewModel;
		}

		function generate() {
			var viewModel = {
				values: {
				},
				methods: {
				}
			};
			return viewModel;
		}

		return {
			generate : generate,
			generateItem : generateItem
		};
	});
