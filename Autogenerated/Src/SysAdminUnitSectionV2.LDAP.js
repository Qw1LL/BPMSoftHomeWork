define("SysAdminUnitSectionV2", ["SysAdminUnitSectionV2Resources", "GridUtilitiesV2"],
	function() {
		return {
			entitySchemaName: "SysAdminUnit",
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/,
			methods: {
				/**
				 * (##########) ######### ####### ############# # LDAP
				 * @protected
				 */
				syncWithLDAP: function() {
					var obsoleteMessage = this.BPMSoft.Resources.ObsoleteMessages.ObsoleteMethodMessage;
					this.log(Ext.String.format(obsoleteMessage, "syncWithLDAP", "runLDAPSync"));
					this.runLDAPSync();
				},

				/**
				 * (##########) ######### ####### ####### ##### # ############# ## LDAP
				 * @protected
				 */
				importLDAPElements: function() {
					var obsoleteMessage = this.BPMSoft.Resources.ObsoleteMessages.ObsoleteMethodMessage;
					this.log(Ext.String.format(obsoleteMessage, "importLDAPElements", "runLDAPSync"));
					this.runLDAPSync();
				},

				/**
				 * ########## ###### ####### ####### ######## ############# ############# # LDAP.
				 * @protected
				 * @return {Object} config ######, ####### ######## ######## #######, ######## ######, ######.
				 * ########### #######
				 */
				getLDAPSyncConfig: function() {
					var jobName = "RunSyncWithLDAP";
					var syncJobGroupName = "LDAP";
					var syncProcessName = "RunLDAPSync";
					var schedulerName = "LdapQuartzScheduler";
					var data = {
						JobName: jobName + BPMSoft.SysValue.CURRENT_USER.value,
						SyncJobGroupName: syncJobGroupName,
						SyncProcessName: syncProcessName,
						periodInMinutes: 0,
						recreate: true,
						schedulerName: schedulerName
					};
					var config = {
						serviceName: "SchedulerJobService",
						methodName: "CreateSyncJobWithResponse",
						data: data
					};
					return config;
				},

				/**
				 * ######### ####### ############# # LDAP
				 * @protected
				 */
				runLDAPSync: function() {
					this.showBodyMask();
					this.callService(this.getLDAPSyncConfig(), function(response) {
								this.runLDAPSyncCallback.call(this, response.CreateSyncJobWithResponseResult);
							}, this);
				},

				/**
				* ####### ######### ###### ######## ############# # LDAP.
				* @protected
				 */
				runLDAPSyncCallback: function(response) {
					var message;
					if (response.success) {
						message = this.get("Resources.Strings.RunLDAPSuccessMessage");
					}
					else {
						var formatMessage = this.get("Resources.Strings.SyncProcessFail");
						var errorInfo = response.errorInfo;
						var error = errorInfo && errorInfo.message ? errorInfo.message : "";
						message = this.Ext.String.format(formatMessage, error);
					}
					this.hideBodyMask();
					if (message) {
						this.BPMSoft.utils.showInformation(message, null, null, {buttons: ["ok"]});
					}
				},

				/**
				 * ########## ######### ######## #######.
				 * @protected
				 * @overridden
				 * @return {BPMSoft.BaseViewModelCollection} ########## ######### ######## ####### # ######.
				 * ########### #######
				 */
				getCustomSectionActions: function() {
					var actionMenuItems = this.callParent(arguments);
					actionMenuItems.addItem(this.getSyncWithLDAPButton());
					return actionMenuItems;
				},

				/**
				 * ########## ###### "################ # LDAP".
				 * @protected
				 * @return {BPMSoft.BaseViewModel} ########## ######.
				 */
				getSyncWithLDAPButton: function() {
					return this.getButtonMenuItem({
						"Caption": {"bindTo": "Resources.Strings.SyncronizeWithLDAPButtonCaption"},
						"Click": {"bindTo": "runLDAPSync"}
					});
				}
			}
		};
	});
