define("SystemDesigner", ["RightUtilities"], function(RightUtilities) {
	return {
		methods: {
			onNavigateToLDAPServerSettingsClick: function() {
				var canManageAdministration = this.get("CanManageAdministration");
				if (!this.Ext.isEmpty(canManageAdministration)) {
					this.navigateToLDAPServerSettings();
				} else {
					RightUtilities.checkCanExecuteOperation({
						operation: "CanManageAdministration"
					}, function(result) {
						this.set("CanManageAdministration", result);
						this.navigateToLDAPServerSettings();
					}, this);
				}
				return false;
			},

			/**
			 * ######### ######## ######### LDAP.
			 * @private
			 */
			navigateToLDAPServerSettings: function() {
				if (this.get("CanManageAdministration") === true) {
					this.sandbox.publish("PushHistoryState", {
						hash: "ConfigurationModuleV2/LDAPServerSettings/"
					});
				} else {
					this.showPermissionsErrorMessage("CanManageAdministration");
				}
			}
		},
		diff: [
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "IntegrationTile",
				"name": "Ldap",
				"index": 1,
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.LdapLinkCaption"},
					"click": {"bindTo": "onNavigateToLDAPServerSettingsClick"}
				}
			}
		]
	};
});
