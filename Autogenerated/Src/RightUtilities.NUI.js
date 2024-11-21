define("RightUtilities", ["ext-base", "BPMSoft", "StorageUtilities"],
	function(Ext, BPMSoft, StorageUtilities) {

	/**
	 * ####### ######### ###### ######## ##### ######## ############ ## ########.
	 * @callback BPMSoft.RightUtilities~onCheckCanExecuteOperations
	 * @param {Object} requestResult ######### ######## ####### ## ########. #### ####### - ######## ########,
	 * ######## - ######## ## ######## ######## ############.
	 */

	/** @enum
	 *  Schema right levels */
	var SchemaOperationRightLevels = {
		/** No access */
		None: 0,
		/** Can read  */
		CanRead: 1,
		/** Can append */
		CanAppend: 2,
		/** Can edit */
		CanEdit: 4,
		/** Can delete */
		CanDelete: 8
	};

	/** @enum
	 *  ###### ####### ## ###### */
	var RecordOperationRightLevels = {
		/** ### ####### */
		None: 0,
		/** ######## ### ###### */
		CanRead: 1,
		/** ######## ### ###### # ###### ############# */
		CanChangeReadRight: 1 + 2,
		/** ######## ### ######### */
		CanEdit: 4,
		/** ######## ### ######### # ###### ############# */
		CanChangeEditRight: 4 + 8,
		/** ######## ### ######## */
		CanDelete: 16,
		/** ######## ### ######## # ###### ############# */
		CanChangeDeleteRight: 16 + 32
	};

	/** @enum
	 *  SysAdminUnitInRole source type */
	var AdminUnitRoleSource = {
		/** Empty value */
		None: 0,
		/** Self */
		Self: 1,
		/** Explicit entry into role */
		ExplicitEntry: 2,
		/** Delegated role */
		Delegated: 4,
		/** Gets functional role from organisational role */
		FuncRoleFromOrgRole: 8,
		/** Gets role up hierarchy from role */
		UpHierarchy: 16,
		/** Gets role as a manager */
		AsManager: 32,
		/** Gets all roles */
		All: 63
	};

	var definedClass = Ext.ClassManager.get("BPMSoft.RightUtilities");
	if (definedClass) {
		return Ext.create(definedClass);
	}

	Ext.define("BPMSoft.configuration.mixins.RightUtilitiesMixin", {
		alternateClassName: "BPMSoft.RightUtilitiesMixin",

		/**
		 * Checks whether there is a read access to the table, transferred to the access level.
		 * Use "canSchemaReadData" instead this function.
		 * @obsolete
		 * @param {Number} value Access level.
		 * @return {boolean} Return true if you have access to read operation,
		 * false - otherwise.
		 */
		isSchemaCanReadRightConverter: function(value) {
			var obsoleteMessage = BPMSoft.Resources.ObsoleteMessages.ObsoleteMethodMessage;
			this.log(Ext.String.format(obsoleteMessage, "isSchemaCanReadRightConverter", "canSchemaReadData"));
			return this.canSchemaReadData(value);
		},

		/**
		 * Checks whether there is a read access to the table, transferred to the access level.
		 * @param {Number} value Access level.
		 * @return {boolean} Return true if you have access to read operation,
		 * false - otherwise.
		 */
		canSchemaReadData: function(value) {
			/*jshint bitwise:false */
			return ((SchemaOperationRightLevels.CanRead & value) === SchemaOperationRightLevels.CanRead);
			/*jshint bitwise:true */
		},

		/**
		 * Checks whether there is an append access to the table, transferred to the access level.
		 * Use "canAppendSchemaData" instead this function.
		 * @obsolete
		 * @param {Number} value Access level.
		 * @return {boolean} Return true if you have access to append operation,
		 * false - otherwise.
		 */
		isSchemaCanAppendRightConverter: function(value) {
			var obsoleteMessage = BPMSoft.Resources.ObsoleteMessages.ObsoleteMethodMessage;
			this.log(Ext.String.format(obsoleteMessage, "isSchemaCanAppendRightConverter", "canAppendSchemaData"));
			return this.canAppendSchemaData(value);
		},

		/**
		 * Checks whether there is an append access to the table, transferred to the access level.
		 * @param {Number} value Access level.
		 * @return {boolean} Return true if you have access to append operation,
		 * false - otherwise.
		 */
		canAppendSchemaData: function(value) {
			/*jshint bitwise:false */
			return ((SchemaOperationRightLevels.CanAppend & value) === SchemaOperationRightLevels.CanAppend);
			/*jshint bitwise:true */
		},

		/**
		 * Checks whether there is an edit access to the table, transferred to the access level.
		 * Use "canEditSchemaData" instead this function.
		 * @obsolete
		 * @param {Number} value Access level.
		 * @return {boolean} Return true if you have access to edit operation,
		 * false - otherwise.
		 */
		isSchemaCanEditRightConverter: function(value) {
			var obsoleteMessage = BPMSoft.Resources.ObsoleteMessages.ObsoleteMethodMessage;
			this.log(Ext.String.format(obsoleteMessage, "isSchemaCanEditRightConverter", "canEditSchemaData"));
			return this.canEditSchemaData(value);
		},

		/**
		 * Checks whether there is an edit access to the table, transferred to the access level.
		 * @param {Number} value Access level.
		 * @return {boolean} Return true if you have access to edit operation,
		 * false - otherwise.
		 */
		canEditSchemaData: function(value) {
			/*jshint bitwise:false */
			return ((SchemaOperationRightLevels.CanEdit & value) === SchemaOperationRightLevels.CanEdit);
			/*jshint bitwise:true */
		},

		/**
		 * Checks whether there is a delete access to the table, transferred to the access level.
		 * Use "canDeleteSchemaData" instead this function.
		 * @obsolete
		 * @param {Number} value Access level.
		 * @return {boolean} Return true if you have access to delete operation,
		 * false - otherwise.
		 */
		isSchemaCanDeleteRightConverter: function(value) {
			var obsoleteMessage = BPMSoft.Resources.ObsoleteMessages.ObsoleteMethodMessage;
			this.log(Ext.String.format(obsoleteMessage, "isSchemaCanDeleteRightConverter", "canDeleteSchemaData"));
			return this.canDeleteSchemaData(value);
		},

		/**
		 * Checks whether there is a delete access to the table, transferred to the access level.
		 * @param {Number} value Access level.
		 * @return {boolean} Return true if you have access to delete operation,
		 * false - otherwise.
		 */
		canDeleteSchemaData: function(value) {
			/*jshint bitwise:false */
			return ((SchemaOperationRightLevels.CanDelete & value) === SchemaOperationRightLevels.CanDelete);
			/*jshint bitwise:true */
		},

		/**
		 * ######### #### ## ###### ## ###### ######, ### ########### ###### #######.
		 * @param {Number} value ####### #######.
		 * @return {boolean} ########## true #### #### ###### ## ########,
		 * false - # ######### ######.
		 */
		isSchemaRecordCanReadRightConverter: function(value) {
			/*jshint bitwise:false */
			return ((RecordOperationRightLevels.CanRead & value) === RecordOperationRightLevels.CanRead);
			/*jshint bitwise:true */
		},

		/**
		 * ######### #### ## ###### ## ######### #### ## ###### ######, ### ########### ###### #######.
		 * @param {Number} value ####### #######.
		 * @return {boolean} ########## true #### #### ###### ## ########,
		 * false - # ######### ######.
		 */
		isSchemaRecordCanChangeReadRightConverter: function(value) {
			/*jshint bitwise:false */
			return ((RecordOperationRightLevels.CanChangeReadRight & value) ===
				RecordOperationRightLevels.CanChangeReadRight);
			/*jshint bitwise:true */
		},

		/**
		 * ######### #### ## ###### ## ######### ######, ### ########### ###### #######.
		 * @param {Number} value ####### #######.
		 * @return {boolean} ########## true #### #### ###### ## ########,
		 * false - # ######### ######.
		 */
		isSchemaRecordCanEditRightConverter: function(value) {
			/*jshint bitwise:false */
			return ((RecordOperationRightLevels.CanEdit & value) === RecordOperationRightLevels.CanEdit);
			/*jshint bitwise:true */
		},

		/**
		 * ######### #### ## ###### ## ######### #### ## ######### ######, ### ########### ###### #######.
		 * @param {Number} value ####### #######.
		 * @return {boolean} ########## true #### #### ###### ## ########,
		 * false - # ######### ######.
		 */
		isSchemaRecordCanChangeEditRightConverter: function(value) {
			/*jshint bitwise:false */
			return ((RecordOperationRightLevels.CanChangeEditRight & value) ===
				RecordOperationRightLevels.CanChangeEditRight);
			/*jshint bitwise:true */
		},

		/**
		 * ######### #### ## ###### ## ######## ######, ### ########### ###### #######.
		 * @param {Number} value ####### #######.
		 * @return {boolean} ########## true #### #### ###### ## ########,
		 * false - # ######### ######.
		 */
		isSchemaRecordCanDeleteRightConverter: function(value) {
			/*jshint bitwise:false */
			return ((RecordOperationRightLevels.CanDelete & value) === RecordOperationRightLevels.CanDelete);
			/*jshint bitwise:true */
		},

		/**
		 * ######### #### ## ###### ## ######### #### ## ######## ######, ### ########### ###### #######.
		 * @param {Number} value ####### #######.
		 * @return {boolean} ########## true #### #### ###### ## ########,
		 * false - # ######### ######.
		 */
		isSchemaRecordCanChangeDeleteRightConverter: function(value) {
			/*jshint bitwise:false */
			return ((RecordOperationRightLevels.CanChangeDeleteRight & value) ===
				RecordOperationRightLevels.CanChangeDeleteRight);
			/*jshint bitwise:true */
		}
	});

	/**
	 * ################ ####### ##### ###### #############
	 */
	Ext.define("BPMSoft.configuration.RightUtilities", {
		extend: "BPMSoft.BaseObject",
		alternateClassName: "BPMSoft.RightUtilities",

		mixins: {
			rightsUtilities: "BPMSoft.RightUtilitiesMixin"
		},

		/**
		 * Client request timeout in ms.
		 * @private
		 * @type {Integer}
		 */
		dataServiceQueryTimeout: 0,

		/**
		 * Array of objects representing right service methods that are currently called.
		 * @private
		 * @type {Array}
		 */
		_executingMethods: [],

		/**
		 * ### ####### ###### # #######.
		 * @protected
		 * @type {String}
		 */
		serviceName: "RightsService",

		/**
		 * ######## ########.
		 * @type {Object}
		 */
		SysAdminOperationCode: {
			CAN_DESIGN_PAGE: "CanChangeApplicationTuningMode"
		},

		/**
		 * Creates right utilities module.
		 * @overridden
		 */
		constructor: function() {
			this.callParent(arguments);
			this.init();
		},

		/**
		 * Initializes right utilities module.
		 */
		init: function() {
			BPMSoft.SysSettings.querySysSettings(["DataServiceQueryTimeout"], function(sysSettings) {
				if (!Ext.isEmpty(sysSettings.DataServiceQueryTimeout)) {
					this.dataServiceQueryTimeout = sysSettings.DataServiceQueryTimeout;
				}
			}, this);
		},

		/**
		 * Returns client request timeout in ms.
		 * @private
		 * @return {Number} Request timeout.
		 */
		getRequestTimeout: function() {
			var defaultTimeout = BPMSoft.BaseServiceProvider.requestTimeout;
			return this.dataServiceQueryTimeout || defaultTimeout;
		},

		/**
		 * Finds object representing method that is currently called.
		 * @private
		 * @param {String} methodName Web service method name.
		 * @param {Object} data Web service data.
		 * @param {Boolean} needRemove When true then found object will be removed.
		 * @return {Object|null} Object representing method that is currently called if found, otherwise null value.
		 */
		_findInExecutingMethods: function(methodName, data, needRemove) {
			var executingMethods = this._executingMethods;
			for (var i = 0; i < executingMethods.length; i++) {
				var executingMethod = executingMethods[i];
				if (executingMethod.methodName === methodName && Ext.Object.equals(executingMethod.data, data)) {
					if (needRemove) {
						executingMethods.splice(i, 1);
					}
					return executingMethod;
				}
			}
			return null;
		},

		/**
		 * Calls web service method with params.
		 * @param {String} methodName Web service method name.
		 * @param {Object} data Web service data.
		 * @param {Function} callback Callback.
		 * @param {Object} scope Callback execution scope.
		 */
		callServiceMethod: function(methodName, data, callback, scope) {
			var workspaceBaseUrl = BPMSoft.utils.uri.getConfigurationWebServiceBaseUrl();
			var requestUrl = workspaceBaseUrl + "/rest/" + this.serviceName + "/" + methodName;
			BPMSoft.AjaxProvider.request({
				url: requestUrl,
				headers: {
					"Accept": "application/json",
					"Content-Type": "application/json"
				},
				method: "POST",
				jsonData: data || {},
				timeout: this.getRequestTimeout(),
				callback: function(request, success, response) {
					var responseObject = success ? BPMSoft.decode(response.responseText) : {};
					callback.call(scope || this, responseObject, success);
				},
				scope: this
			});
		},

		/**
		 * Calls right service method with specified parameters and processes received value to use.
		 * Prevents simultaneous execution of identical requests.
		 * @param {String} methodName Web-service method name.
		 * @param {Object} data Object with data for passing to service.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function execution context.
		 */
		callRightServiceMethod: function(methodName, data, callback, scope) {
			var executingMethod = this._findInExecutingMethods(methodName, data, false);
			if (executingMethod) {
				executingMethod.callbacks.push({
					fn: callback,
					scope: scope
				});
			} else {
				this._executingMethods.push({
					methodName: methodName,
					data: data,
					callbacks: [{
						fn: callback,
						scope: scope
					}]
				});
				this.callServiceMethod(methodName, data, function(responseObject, success) {
					if (!this.isDestroyed) {
						executingMethod = this._findInExecutingMethods(methodName, data, true);
						BPMSoft.each(executingMethod.callbacks, function(callbackObj) {
							callbackObj.fn.call(callbackObj.scope || this, responseObject[methodName + "Result"],
								success);
						}, this);
					}
				}, this);
			}
		},

		/**
		 * Calls right service method with specified parameters and processes received value to use.
		 * Prevents simultaneous execution of identical requests. Uses caching.
		 * @param {String} config.methodName Web-service method name.
		 * @param {Object} config.data Object with data for passing to service.
		 * @param {Function} config.callback Callback function.
		 * @param {Object} config.scope Callback function execution context.
		 * @param {String} config.storageKey Storage key.
		 */
		callRightServiceMethodWithStorage: function (config) {
			const { methodName, data, callback, scope, storageKey } = config;
			var requestFunction = function (innerCallback) {
				this.callRightServiceMethod(methodName, data, innerCallback, this);
			};
			StorageUtilities.workRequestWithStorage(storageKey, requestFunction, function () {
				callback.apply(scope, arguments);
			}, this);
		},

		/**
		 * Checks if the user has the right to execute the operation on the entity.
		 * @param {String} entitySchemaName Entity schema name.
		 * @param {String} entityOperationCode Operation Code.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function execution context.
		 */
		checkCanExecuteEntityOperation(entitySchemaName, entityOperationCode, callback, scope) {
			var data = {entitySchemaName: entitySchemaName, entityOperationCode: entityOperationCode};
			var storageKey = "GetCanExecuteEntityOperation!" + data.entitySchemaName + ":" + data.entityOperationCode;
			var requestFunction = function(innerCallback) {
				this.callRightServiceMethod("GetCanExecuteEntityOperation", data, innerCallback, this);
			};
			StorageUtilities.workRequestWithStorage(storageKey, requestFunction, function() {
				callback.apply(scope, arguments);
			}, this);
		},

		/**
		 * ######### ##### ######## ############ ## ########## ########.
		 * @param {Object} data ###### ###### ### ###### ### #######.
		 * @param {Function} callback ####### ######### ######.
		 * @param {Object} scope ###### ######### ####### ######### ######.
		 */
		checkCanExecuteOperation: function(data, callback, scope) {
			var storageKey = "GetCanExecuteOperation!" + data.operation;
			var requestFunction = function(innerCallback) {
				this.callRightServiceMethod("GetCanExecuteOperation", data, innerCallback, this);
			};
			StorageUtilities.workRequestWithStorage(storageKey, requestFunction, function() {
				callback.apply(scope, arguments);
			}, this);
		},

		/**
		 * ######### ##### ######## ############ ## ########. ########## ###### ####### ## ###### ########.
		 * @param {String[]} operations ###### ########.
		 * @param {RightUtilities~onCheckCanExecuteOperations} callback ####### ######### ######.
		 * @param {Object} scope ###### ######### ####### ######### ######.
		 */
		checkCanExecuteOperations: function(operations, callback, scope) {
			var operationsToRequest = [];
			var requestResult = {};
			BPMSoft.each(operations, function(operation) {
				var storageKey = "GetCanExecuteOperation!" + operation;
				var storageItem = StorageUtilities.getItem(storageKey);
				if (Ext.isEmpty(storageItem)) {
					operationsToRequest.push(operation);
				} else {
					requestResult[operation] = storageItem[0];
				}
			}, this);
			var data = Ext.encode({operations: operationsToRequest});
			this.callRightServiceMethod("GetCanExecuteOperations", data, function(result) {
				BPMSoft.each(result, function(operationPermission) {
					var operationPermissionKey = operationPermission.Key;
					var operationPermissionValue = operationPermission.Value;
					var storageKey = "GetCanExecuteOperation!" + operationPermissionKey;
					StorageUtilities.setItem([operationPermissionValue], storageKey);
					requestResult[operationPermissionKey] = operationPermissionValue;
				}, this);
				if (callback) {
					callback.call(scope, requestResult);
				}
			}, this);
		},

		/**
		 * Checks whether the user has access to any of the requested operations.
		 * @param {String[]} operations List of operations to check.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Execution scope.
		 */
		checkCanExecuteAnyOperation: function(operations, callback, scope) {
			this.checkCanExecuteOperations(operations, function(operationPermissions) {
				const canExecuteOperations = Object.values(operationPermissions);
				const canExecuteAnyOperation = canExecuteOperations.some(function(canExecute) {
					return canExecute === true;
				});
				callback.call(scope, canExecuteAnyOperation);
			}, scope);
		},

		/**
		 * ########### ########## ### ##### ## ######## ### ######.
		 * @param {String} schemaName ### #######.
		 * @param {Function} callback ####### ######### ######.
		 * @param {Object} scope ###### ######### ####### ######### ######.
		 */
		getSchemaOperationRightLevel: function(schemaName, callback, scope) {
			var storageKey = "SchemaOperationRightLevel!" + schemaName;
			var requestFunction = function(innerCallback) {
				this.callRightServiceMethod("GetSchemaOperationRightLevel", {
					"schemaName": schemaName
				}, innerCallback, this);
			};
			StorageUtilities.workRequestWithStorage(storageKey, requestFunction, function() {
				callback.apply(scope, arguments);
			}, this);
		},

		/**
		 * ########### ########## ### ##### ## ######## ### ######.
		 * @param {String} schemaName ### #######.
		 * @param {String} primaryColumnValue ########## ############# ######.
		 * @param {Function} callback ####### ######### ######.
		 * @param {Object} scope ###### ######### ####### ######### ######.
		 */
		getSchemaRecordRightLevel: function(schemaName, primaryColumnValue, callback, scope) {
			this.callRightServiceMethod("GetSchemaRecordRightLevel", {
				"schemaName": schemaName,
				"primaryColumnValue": primaryColumnValue
			}, callback, scope);
		},

		/**
		 * ########### ########## ### ##### ## ######## ######## # #######.
		 * @param {Object} data ###### ###### ### ###### ### #######.
		 * @param {Function} callback ####### ######### ######.
		 * @param {Object} scope ###### ######### ####### ######### ######.
		 */
		checkCanDelete: function(data, callback, scope) {
			this.callRightServiceMethod("GetCanDelete", data, callback, scope);
		},

		/**
		 * ########### ########## ### ##### ## ######## ######### ### ######.
		 * @param {Object} data ###### ###### ### ###### ### #######.
		 * @param {Function} callback ####### ######### ######.
		 * @param {Object} scope ###### ######### ####### ######### ######.
		 */
		checkCanEditRecords: function(data, callback, scope) {
			this.callRightServiceMethod("GetCanEditRecords", data, callback, scope);
		},

		/**
		 * ########### ########## ### ##### ## ######## ###### ### ######.
		 * @param {Object} data ###### ###### ### ###### ### #######.
		 * @param {Function} callback ####### ######### ######.
		 * @param {Object} scope ###### ######### ####### ######### ######.
		 */
		checkCanReadRecords: function(data, callback, scope) {
			this.callRightServiceMethod("GetCanReadRecords", data, callback, scope);
		},

		/**
		 * ########### ########## ### ##### ## ######## ######## ### #######.
		 * @param {Object} data ###### ###### ### ###### ### #######.
		 * @param {Function} callback ####### ######### ######.
		 * @param {Object} scope ###### ######### ####### ######### ######.
		 */
		checkMultiCanDelete: function(data, callback, scope) {
			this.callRightServiceMethod("GetCanDeleteRecords", data, callback, scope);
		},

		/**
		 * ########### ########## ### ##### ## ######## ######### # #######.
		 * @param {Object} data ###### ###### ### ###### ### #######.
		 * @param {Function} callback ####### ######### ######.
		 * @param {Object} scope ###### ######### ####### ######### ######.
		 */
		checkCanEdit: function(data, callback, scope) {
			const methodName = "GetCanEdit";
			const canCashResponse = BPMSoft.Features.getIsEnabled("CachedUserRights");
			if (!canCashResponse) {
				this.callRightServiceMethod(methodName, data, callback, scope);
				return;
			}
			var storageKey = Ext.String.format("{0}!{1}_{2}", methodName, data.schemaName, data.primaryColumnValue);
			this.callRightServiceMethodWithStorage({
				methodName,
				data,
				callback,
				scope,
				storageKey
			});
		},

		/**
		 * ########### ########## ### ### ##### ## ######.
		 * @param {Object} data ###### ###### ### ###### ### #######.
		 * @param {Function} callback ####### ######### ######.
		 * @param {Object} scope ###### ######### ####### ######### ######.
		 */
		getRecordRights: function(data, callback, scope) {
			this.callRightServiceMethod("GetRecordRights", data, callback, scope);
		},

		/**
		 * ########### ########## ### ### ##### ## ###### ### ############ ############.
		 * @param {Object} data ###### ###### ### ###### ### #######.
		 * @param {Function} callback ####### ######### ######.
		 * @param {Object} scope ###### ######### ####### ######### ######.
		 */
		getUserRecordRights: function(data, callback, scope) {
			this.callRightServiceMethod("GetUserRecordRights", data, callback, scope);
		},

		/**
		 * ########### ########## ### ########### ##### ## ###### ### ############ ############.
		 * @param {Object} data ###### ###### ### ###### ### #######.
		 * @param {Function} callback ####### ######### ######.
		 * @param {Object} scope ###### ######### ####### ######### ######.
		 */
		getUseDenyRecordRights: function(data, callback, scope) {
			this.callRightServiceMethod("GetUseDenyRecordRights", data, callback, scope);
		},

		/**
		 * ########### ########## ### ##### ## ######## ######## # #######.
		 * @param {Object} data ###### ###### ### ###### ### #######.
		 * @param {Function} callback ####### ######### ######.
		 * @param {Object} scope ###### ######### ####### ######### ######.
		 */
		getSchemaDeleteRights: function(data, callback, scope) {
			this.callRightServiceMethod("GetSchemaDeleteRights", data, callback, scope);
		},

		/**
		 * ########### ########## ### ##### ## ######## ######### # #######.
		 * @param {Object} data ###### ###### ### ###### ### #######.
		 * @param {Function} callback ####### ######### ######.
		 * @param {Object} scope ###### ######### ####### ######### ######.
		 */
		getSchemaEditRights: function(data, callback, scope) {
			this.callRightServiceMethod("GetSchemaEditRights", data, callback, scope);
		},

		/**
		 * ########### ########## ### ##### ## ######## ###### # #######.
		 * @param {Object} data ###### ###### ### ###### ### #######.
		 * @param {Function} callback ####### ######### ######.
		 * @param {Object} scope ###### ######### ####### ######### ######.
		 */
		getSchemaReadRights: function(data, callback, scope) {
			this.callRightServiceMethod("GetSchemaReadRights", data, callback, scope);
		},

		/**
		 * ######### ###### ######### #### ### ########### ######.
		 * @param {Object} data ###### ###### ### ###### ### #######.
		 * @param {Function} callback ####### ######### ######.
		 * @param {Object} scope ###### ######### ####### ######### ######.
		 */
		applyChanges: function(data, callback, scope) {
			this.callRightServiceMethod("ApplyChanges", data, callback, scope);
		},

		/**
		 * Requests information about the right to edit the column in the object.
		 * @param {Object} data The data object for a service method.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope Scope callback function.
		 */
		getCanEditColumns: function(data, callback, scope) {
			this.callRightServiceMethod("GetCanEditColumns", data, callback, scope);
		},

		/**
		 * Copies rights for target record from source record of the schema.
		 * @param {Object} data The data object for a service method.
		 * @param {String} data.schemaName Name of the schema where the source and the destination records should be.
		 * @param {String} data.sourceRecordId Identifier of the record which access rights will be copied from.
		 * @param {String} data.targetRecordId Identifier of the record where access rights will be copied to.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope Scope callback function.
		 */
		copyRights: function(data, callback, scope) {
			this.callRightServiceMethod("CopyRights", data, callback, scope);
		}
	});
	return Ext.create("BPMSoft.RightUtilities");
});
