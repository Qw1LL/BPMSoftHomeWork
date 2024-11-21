define("BaseSysUserInRoleDetailV2", ["RightUtilities"],
	function(RightUtilities) {
		return {
			entitySchemaName: "SysUserInRole",
			methods: {
				/**
				 * @inheritdoc BaseDetailV2#init
				 * @overridden
				 */
				init: function(callback, scope) {
					this.callParent([function() {
						this.checkUsersOperationsRights(callback, scope);
					}, this]);
				},

				/**
				* Checks if user has CanManageUsers or CanAdministratePortalUsers operations.
				* @protected.
				*/
				checkUsersOperationsRights: function(callback, scope) {
					var operations = ["CanManageUsers", "CanAdministratePortalUsers"];
					RightUtilities.checkCanExecuteOperations(operations, function(result) {
						BPMSoft.each(result, function(operationRight, operationName) {
							this.set(operationName, operationRight);
						}, this);
						if (callback) {
							callback.call(scope || this);
						}
					}, this);
				},

				/**
				 * @inheritDoc BaseSysUserInRoleDetailV2#getOnDeleteAcceptMethodName
				 * @overridden
				 * @return {String} Method name.
				 */
				getOnDeleteAcceptMethodName: function() {
					if (!this.get("CanManageUsers") && this.get("CanAdministratePortalUsers")) {
						return "RemovePortalUsersInRoles";
					} else {
						return this.callParent();
					}
				},

				/**
				 * @inheritDoc BaseSysUserInRoleDetailV2#getAddCallbackMethodName
				 * @overridden
				 * @return {String} Method name.
				 */
				getAddCallbackMethodName: function() {
					if (!this.get("CanManageUsers") && this.get("CanAdministratePortalUsers")) {
						return "AddPortalUserRoles";
					} else {
						return this.callParent();
					}
				}
			}
		};
	});
