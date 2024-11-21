define("SetupVirtualParametersPage", [],
	function() {
		return {
			methods: {
				getConnectionParamsConfig: function() {
					return  {
						"DisableCallCentre": "disableCallCentre"
					};
				}
			},
			diff: [
				{
					"operation": "remove",
					"name": "DebugMode"
				},
				{
					"operation": "remove",
					"name": "UseBlindTransfer"
				}
			]
		};
	});
