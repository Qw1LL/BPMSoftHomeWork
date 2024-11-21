define("PortalUsersAdministrationUtilities", ["PortalUsersAdministrationUtilitiesResources", "RightUtilities"],
	function(resources, RightUtilities) {
	var PortalUsersAdministrationClass = Ext.define("BPMSoft.configuration.mixins.PortalUsersAdministrationUtilities", {
		alternateClassName: "BPMSoft.PortalUsersAdministrationUtilities",

		_checkUserMethodName: "CanChangePortalUserData",

		_canChangeUser: function(callback, scope) {
			const dataSend = {
				userId: this.$PrimaryColumnValue
			};
			const config = {
				serviceName: "AdministrationService",
				methodName: this._checkUserMethodName,
				data: dataSend
			};
			this.callService(config, function(response) {
				if (callback) {
					callback.call(scope || this, this._validatePermissionResponse(response));
				}
			}, this);
		},

		_validatePermissionResponse: function(response) {
			return Ext.isEmpty(response[this._checkUserMethodName + "Result"]);
		},

		/**
		* Checks if user has CanManageUsers or CanAdministratePortalUsers operations.
		* @protected
		* @param {Function} callback callback function.
		* @param {Object} scope scope.
		*/
		checkCanAdministratePortalUsers: function(callback, scope) {
			const operations = ["CanManageUsers", "CanAdministratePortalUsers"];
			RightUtilities.checkCanExecuteOperations(operations, function(result) {
				BPMSoft.each(result, function(operationRight, operationName) {
					this.set(operationName, operationRight);
				}, this);
				const operationsResult = this.get("CanManageUsers") || this.get("CanAdministratePortalUsers");
				if (callback) {
					if(!operationsResult || Ext.isEmpty(this.$PrimaryColumnValue)) {
						callback.call(scope || this, operationsResult);
					} else {
						this._canChangeUser(callback, scope);
					}
				}
			}, this);
		}
	});
	return Ext.create(PortalUsersAdministrationClass);
});
