define("UserProfilePage", [],
	function() {
		return {
			methods: {
				//region Methods: Public

				/**
				 * Opens setup call centre parameters page.
				 */
				setupCallCentreParameters: function() {
					var callCentreParametersModule = "SetupTelephonyParametersPageModule";
					this.sandbox.publish("PushHistoryState", {hash: callCentreParametersModule});
				},

				/**
				 * Determines if call centre settings button is visible.
				 * @return {Boolean}
				 */
				isCallCentreSettingsVisible: function() {
					return !this.get("IsSSP");
				}

				//endregion
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "remove",
					"name": "callCentreSetup",
					"parentName": "leftTopGroupContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {"bindTo": "Resources.Strings.SetupCallCentreParameters"},
						"click": {"bindTo": "setupCallCentreParameters"},
						"classes": {"textClass": "profile-button"},
						"tag": "callCentreSetup",
						"visible": {"bindTo": "isCallCentreSettingsVisible"},
						"markerValue": "callCentreSetup"
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
