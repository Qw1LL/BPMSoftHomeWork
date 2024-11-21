define("NavigateToLDAPServerConfigurationTile", ["NavigateToLDAPServerConfigurationTileResources"],
	function(resources) {
		/**
		 * @class BPMSoft.configuration.NavigateToLDAPServerConfigurationTileViewModel
		 * ##### ###### ############# ######.
		 */
		Ext.define("BPMSoft.configuration.NavigateToLDAPServerConfigurationTileViewModel", {
			extend: "BPMSoft.SystemDesignerTileViewModel",
			alternateClassName: "BPMSoft.NavigateToLDAPServerConfigurationTileViewModel",
			Ext: null,
			sandbox: null,
			BPMSoft: null,

			constructor: function() {
				this.callParent(arguments);
				this.initResourcesValues(resources);
			},
			/**
			 * ####### ## ######## ######### LDAP #######
			 */
			onClick: function() {
				var LDAPHash = "ConfigurationModuleV2/LDAPServerSettings/";
				var currentModule = this.sandbox.publish("GetHistoryState").hash.historyState;
				if (currentModule !== LDAPHash) {
					this.sandbox.publish("PushHistoryState", {
						hash: LDAPHash
					});
				}
			}
		});
	});
