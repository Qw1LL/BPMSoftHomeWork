/**
 * @class BPMSoft.RightsServiceHelper
 * Provides methods for work with RightsService.
 */
Ext.define("BPMSoft.configuration.RightsServiceHelper", {
	alternateClassName: "BPMSoft.RightsServiceHelper",

	/**
	 * @private
	 */
	_showInformationDialog: function(message, handler) {
		BPMSoft.utils.showMessage({
			caption: message,
			buttons: [BPMSoft.MessageBoxButtons.CLOSE],
			defaultButton: 0,
			style: BPMSoft.MessageBoxStyles.ORANGE,
			handler: handler,
			scope: this
		});
	},

	/**
	 * @private
	 */
	_callServiceMethod: function(methodName, data, onSuccess, onError, scope) {
		const config = {
			"serviceName": "RightsService",
			"methodName": methodName
		};
		if (data) {
			config.data = data;
		}
		this.callService(config, function(response) {
			if (response.success) {
				Ext.callback(onSuccess, scope);
			} else {
				this.showInformationDialog(response.errorInfo.message, function() {
					Ext.callback(onError, scope);
				});
			}
		}, this);
	},



	/**
	 * Adds or updates admin operation access rights.
	 * @param {String} adminOperationId Identifier of the admin operation.
	 * @param {Array} itemIds Array of SysAdminUnit identifiers.
	 * @param {Boolean} canExecute Determines whether an operation access is granted or not.
	 * @param {Function} callback Callback function.
	 * @param {Object} scope Scope object.
	 * @protected
	 */
	setAdminOperationGrantees: function(adminOperationId, itemIds, canExecute, callback, scope) {
		const config = {
			"serviceName": "RightsService",
			"methodName": "SetAdminOperationGrantee",
			"data": {
				"adminOperationId": adminOperationId,
				"adminUnitIds": itemIds,
				"canExecute": this.Ext.isEmpty(canExecute) ? true : canExecute
			}
		};
		BPMSoft.ConfigurationServiceProvider.callService(config, function(response) {
			if (response && response.SetAdminOperationGranteeResult) {
				const result = this.Ext.decode(response.SetAdminOperationGranteeResult);
				if (result && !this.Ext.isEmpty(result)) {
					if (result.Success) {
						Ext.callback(callback, scope);
					} else {
						this._showInformationDialog(result.ExMessage);
					}
				}
			}
		}, this);
	},

	/**
	 * Adds or updates process execution rights.
	 * @param {String} processSchemaUId Process schema unique identifier.
	 * @param {Array} adminUnitIds Array of the admin unit identifiers.
	 * @param {Boolean} canExecute Can execute or not.
	 * @param {Function} callback Callback function.
	 * @param {Object} scope Scope object.
	 */
	setProcessExecutionGrantees: function(processSchemaUId, adminUnitIds, canExecute, callback, scope) {
		const data = {
			processSchemaUId,
			adminUnitIds,
			canExecute
		};
		this._callServiceMethod("SetProcessExecutionGrantees", data, callback, null, scope);
	},

	/**
	 * Sets the access right position.
	 * @param {String} itemId Access right identifier.
	 * @param {Number} position Position value to set.
	 * @param {Function} callback Callback function.
	 * @param {Object} scope Scope object.
	 * @protected
	 */
	setAdminOperationGranteePosition: function(itemId, position, callback, scope) {
		const config = {
			"serviceName": "RightsService",
			"methodName": "SetAdminOperationGranteePosition",
			"data": {
				"granteeId": itemId,
				"position": position
			}
		};
		BPMSoft.ConfigurationServiceProvider.callService(config, function(response) {
			if (response && response.SetAdminOperationGranteePositionResult) {
				const result = this.Ext.decode(response.SetAdminOperationGranteePositionResult);
				if (result && !this.Ext.isEmpty(result)) {
					if (result.Success) {
						Ext.callback(callback, scope);
					} else {
						this._showInformationDialog(result.ExMessage);
					}
				}
			}
		}, this);
	},

	/**
	 * Adds or updates process execution right position.
	 * @param {String} processSchemaUId Process schema unique identifier.
	 * @param {String} adminUnitId Admin unit identifier.
	 * @param {Int} position Can execute or not.
	 * @param {Function} callback Callback function.
	 * @param {Object} scope Scope object.
	 */
	setProcessExecutionGranteePosition: function(processSchemaUId, adminUnitId, position, callback, scope) {
		const data = {
			processSchemaUId,
			adminUnitId,
			position
		};
		this._callServiceMethod("SetProcessExecutionGranteePosition", data, callback, null, scope);
	},

	/**
	 * Removes admin operation access rights.
	 * @param {Array} itemIds Access rights identifiers array.
	 * @param {Function} callback Callback function.
	 * @param {Object} scope Scope object.
	 * @protected
	 */
	deleteAdminOperationGrantee: function(itemIds, callback, scope) {
		const config = {
			"serviceName": "RightsService",
			"methodName": "DeleteAdminOperationGrantee",
			"data": {
				"recordIds": itemIds
			}
		};
		BPMSoft.ConfigurationServiceProvider.callService(config, function(response) {
			if (response && response.DeleteAdminOperationGranteeResult) {
				const result = this.Ext.decode(response.DeleteAdminOperationGranteeResult);
				if (result && !this.Ext.isEmpty(result)) {
					if (result.Success) {
						Ext.callback(callback, scope);
					} else {
						this._showInformationDialog(result.ExMessage);
					}
				}
			}
		}, this);
	},

	/**
	 * Removes process execution right.
	 * @param {String} processSchemaUId Process schema unique identifier.
	 * @param {Array} adminUnitIds Array of the admin unit identifiers.
	 * @param {Function} callback Callback function.
	 * @param {Object} scope Scope object.
	 * @protected
	 */
	deleteProcessExecutionGrantees: function(processSchemaUId, adminUnitIds, callback, scope) {
		const data = {
			processSchemaUId,
			adminUnitIds
		};
		this._callServiceMethod("DeleteProcessExecutionGrantees", data, callback, null, scope);
	},

	/**
	 * Assumes that the current user has an ability to change admin operation grantee.
	 * @param {Function} callbackAllow Allow callback.
	 * @param {Function} callbackDenied Deny callback.
	 * @param {Object} scope Scope object.
	 * @protected
	 */
	checkCanChangeAdminOperationGrantee: function(callbackAllow, callbackDenied, scope) {
		const config = {
			"serviceName": "RightsService",
			"methodName": "CheckCanChangeAdminOperationGrantee"
		};
		BPMSoft.ConfigurationServiceProvider.callService(config, function(response) {
			if (response && response.CheckCanChangeAdminOperationGranteeResult) {
				const result = this.Ext.decode(response.CheckCanChangeAdminOperationGranteeResult);
				if (result && !this.Ext.isEmpty(result)) {
					if (result.Success) {
						Ext.callback(callbackAllow, scope);
					} else {
						this._showInformationDialog(result.ExMessage, function() {
							Ext.callback(callbackDenied, scope);
						});
					}
				}
			}
		}, this);
	},

	/**
	 * Assumes that the current user has an ability to change admin operation grantee.
	 * @param {Function} callbackAllow Callback function for allowed result.
	 * @param {Function} callbackDenied Callback function for denied result.
	 * @param {Object} scope Scope object.
	 * @protected
	 */
	checkCanChangeProcessExecutionGrantee: function(callbackAllow, callbackDenied, scope) {
		this._callServiceMethod("CheckCanChangeProcessExecutionGrantee", null, callbackAllow, callbackDenied, scope);
	}

});
