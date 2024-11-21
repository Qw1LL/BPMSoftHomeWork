define("ActualizationUtilities", ["BPMSoft", "ActualizationUtilitiesResources"],
	function(BPMSoft, resources) {
		var actualizationUtilitiesClass = Ext.define("BPMSoft.configuration.mixins.ActualizationUtilities", {

				alternateClassName: "BPMSoft.ActualizationUtilities",

				/**
				 * ######## ######, ########### ############ ############### #####.
				 * @private
				 */
				onActualizeAdminUnitInRole: function() {
					this.showBodyMask();
					var config = {
						serviceName: "AdministrationService",
						methodName: "ActualizeAdminUnitInRole",
						timeout: 600000
					};
					this.callService(config, function(response) {
						this.hideBodyMask();
						if (response && response.ActualizeAdminUnitInRoleResult) {
							this.showInformationDialog(resources.localizableStrings.ActualizeSuccessMessage);
						} else {
							this.showInformationDialog(resources.localizableStrings.ActualizeFailedMessage);
						}
					}, this);
				},

				/**
				 * ########## ###### "############### ####".
				 * @protected
				 * @return {BPMSoft.BaseViewModel} ########## ######.
				 */
				getActualizeAdminUnitInRoleButton: function() {
					return this.getButtonMenuItem({
						"Caption": {"bindTo": "Resources.Strings.ActualizeOrgStructureButtonCaption"},
						"Click": {"bindTo": "onActualizeAdminUnitInRole"},
						"Visible": {"bindTo": "CanManageUsers"}
					});
				},

				/**
				 * ######## ###### ## #######.
				 * @protected
				 * @param {Object} callback ####### ######### ######.
				 * @param {Object} scope ######## ##########.
				 */
				initCustomUserProfileData: function(callback, scope) {
					var profileKey = this.getCustomProfileKey();
					this.BPMSoft.require(["profile!" + profileKey], function(profile) {
						this.set("UserCustomProfile", profile);
						if (this.Ext.isFunction(callback)) {
							callback.call(scope, arguments);
						}
					}, this);
				},

				/**
				 * ######## #### #######.
				 * @protected
				 * @return {String} ########## #### #######.
				 */
				getCustomProfileKey: function() {
					return "SysAdminUnitSectionCustomData";
				}
			});
		return Ext.create(actualizationUtilitiesClass);
	});
