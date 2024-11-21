define("AccountsSearchResultDetailV2", ["AccountsSearchResultDetailV2Resources", "ConfigurationEnums",
	"LookupUtilities", "GridUtilitiesV2"],
		function() {
			return {
				entitySchemaName: "Account",
				messages: {
					"GetSearchButtonEnabled": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.PUBLISH
					}
				},
				methods: {

					/**
					 * ############## ######### ######## ######.
					 * @overridden
					 */
					init: function() {
						this.callParent(arguments);
						this.setSearchButtonEnabled();
					},

					/**
					 * ##### ######## ######## ########## ######.
					 */
					setSearchButtonEnabled: function() {
						var result = this.sandbox.publish("GetSearchButtonEnabled", null, [this.sandbox.id]);
						if (Ext.isEmpty(result.value)) {
							this.set("IsSearchButtonEnabled", false);
						}
					}

				}
			};
		}
);
