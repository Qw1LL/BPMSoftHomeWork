define("DataUtilities", [
	"ext-base", "BPMSoft", "MaskHelper", "ServiceHelper", "DataUtilitiesResources",
	"GoogleTagManagerUtilities", "RightUtilities", "SystemOperationsPermissionsMixin"
], function(Ext, BPMSoft, MaskHelper, ServiceHelper,
			resources, GoogleTagManagerUtilities, RightUtilities) {
	Ext.define("BPMSoft.configuration.DataUtilities", {
		extend: "BPMSoft.BaseObject",
		alternateClassName: "BPMSoft.DataUtilities",

		singleton: true,

		mixins: {
			SystemOperationsPermissionsMixin: "BPMSoft.SystemOperationsPermissionsMixin"
		},
	
		// region Properties: Private

		/**
		 * Report service name.
		 * @private
		 * @type {String}
		 */
		reportServiceName: "ReportService",

		/**
		 * Name of method that returns key for export filters.
		 * @private
		 * @type {String}
		 */
		exportFiltersKeyMethodName: "GetExportFiltersKey",

		/**
		 * Name of method that returns filtered data.
		 * @private
		 * @type {String}
		 */
		exportFilteredDataMethodName: "GetExportFilteredData",

		/**
		 * Name of method that returns key for export filters.
		 * @private
		 * @type {String}
		 */
		_exportToExcelMethodName: "GetExportToExcelKey",

		/**
		 * Name of method that download excel file by key.
		 * @private
		 * @type {String}
		 */
		_downloadExcelFileMethodName: "GetExportToExcelData",

		/**
		 * Default export to excel request timeout.
		 * @private
		 * @type {Number}
		 */
		_defExportToExcelTimeOut: 10 * 60 * 1000,

		/**
		 * System setting export to excel request timeout.
		 * @private
		 * @type {Number}
		 */
		_exportToExcelTimeout: null,

		/**
		 * Variable that sets the timeout to process the request on the server.
		 * @private
		 * @type {Number}
		 */
		_requestTimeout: null,

		/**
		 * AdminOperation name for export 
		 * @private
		 * @type {String}
		 */
		_exportAdminOperationName: "CanExportGrid",

		/**
		 * EntityOperation name for export
		 * @private
		 * @type {String}
		 */
		_exportEntityOperationName: "Export",

		//endregion

		//region Methods: Private

		constructor: function() {
			this.callParent(arguments);
			this.init();
		},

		/**
		 * Gets download link.
		 * @private
		 * @param {String} entityName Entity name.
		 * @param {String} key Filters context key.
		 * @return {String}
		 */
		getDownloadLink: function(entityName, key) {
			return Ext.String.format("../rest/{0}/{1}/{2}/{3}", this.reportServiceName,
					this.exportFilteredDataMethodName, entityName, key);
		},

		/**
		 * Downloads entity by filters context key.
		 * @private
		 * @param {String} entityName Entity name.
		 * @param {String} key Filters context key.
		 * @param {String} [fileName] File name.
		 */
		downloadEntityByFiltersKey: function(entityName, key, fileName) {
			const serviceFilePath = this.getDownloadLink(entityName, key);
			const downloadFileName = (fileName || entityName) + ".csv";
			this._startDownloadFile(serviceFilePath, downloadFileName);
		},

		/**
		 * Downloads excel file by key.
		 * @private
		 * @param {String} key Filters context key.
		 * @param {String} [fileName] File name.
		 */
		_downloadExcelFileByKey: function(key, fileName) {
			const serviceFilePath = this._getExcelDownloadLink(key, fileName);
			const downloadFileName = Ext.String.format("{0}.xlsx", fileName);
			this._startDownloadFile(serviceFilePath, downloadFileName);
		},

		/**
		 * Starts downloading file.
		 * @private
		 * @param {String} serviceFileUrl Url of the download file service.
		 * @param {String} downloadFileName Name of the downloading file.
		 */
		_startDownloadFile: function(serviceFileUrl, downloadFileName) {
			const file = document.createElement("a");
			file.href = serviceFileUrl;
			file.download = downloadFileName;
			document.body.appendChild(file);
			file.click();
			document.body.removeChild(file);
		},

		/**
		 * Gets download link by excel file.
		 * @private
		 * @param {String} key Key of the download excel file.
		 * @param {String} downloadFileName Downloading file name.
		 * @return {String} Download excel file path.
		 */
		_getExcelDownloadLink: function(key, downloadFileName) {
			return Ext.String.format("../rest/{0}/{1}/{2}/{3}",
				this.reportServiceName, this._downloadExcelFileMethodName, key, downloadFileName);
		},

		/**
		 * Gets json data from entity schema query.
		 * @private
		 * @param {BPMSoft.EntitySchemaQuery|String} esq Entity schema query.
		 * @return {String}
		 */
		getJsonStringFromEsq: function(esq) {
			if (Ext.isString(esq)) {
				return esq;
			} else if (Ext.isFunction(esq.serialize)) {
				return Ext.JSON.encodeString(esq.serialize());
			} else {
				return Ext.JSON.encodeString(BPMSoft.encode(esq));
			}
		},

		/**
		 * Gets error message.
		 * @private
		 * @param {Object} response Response object.
		 * @param {Object} response.responseStatus Response status.
		 * @param {String} [entityName] Entity name.
		 * @return {String}
		 */
		getErrorMessage: function(response, entityName) {
			const errorInfo = response.responseStatus;
			let message;
			if (errorInfo) {
				if (errorInfo.ErrorCode === "InvalidObjectStateException") {
					message = Ext.String.format(resources.localizableStrings.MaxEntityRowCountExceptionMessage,
							entityName, response.maxEntityRowCount);
				} else {
					message = errorInfo.Message;
				}
			} else {
				message = resources.localizableStrings.ExportToFileErrorMsg;
			}
			return message;
		},

		/**
		 * @private
		 */
		_getExportToExcelExceptionMessage: function(exportToExcelResponse, response) {
			if (response.timedout) {
				return resources.localizableStrings.ExportTimedoutMessage;
			}
			const errorInfo = exportToExcelResponse.responseStatus;
			if (!errorInfo) {
				return resources.localizableStrings.ExportToFileErrorMsg;
			}
			if (errorInfo.ErrorCode === "ExportToExcelException") {
				if (errorInfo.Message && errorInfo.Message.includes("InvalidObjectStateException")) {
					return resources.localizableStrings.CheckColumnSettingsMessage;
				}
				return resources.localizableStrings.DefaultExportToExcelMessage;;
			}
			return errorInfo.Message;
		},

		/**
		 * Gets sysstems or base timeout.
		 * @private
		 * @return {Number}
		 */
		_getTimeout: function() {
			return this._requestTimeout || BPMSoft.BaseServiceProvider.requestTimeout;
		},

		//endregion

		//region Methods: Public

		/**
		 * Initializes timeout property.
		 */
		init: function() {
			BPMSoft.SysSettings.querySysSettings(["DataServiceQueryTimeout", "ExportToExcelTimeout"], function(sysSettings) {
				if (!Ext.isEmpty(sysSettings.DataServiceQueryTimeout)) {
					this._requestTimeout = sysSettings.DataServiceQueryTimeout;
				}
				if (!Ext.isEmpty(sysSettings.ExportToExcelTimeout)) {
					this._exportToExcelTimeout = sysSettings.ExportToExcelTimeout;
				}
			}, this);
		},

		/**
		 * Exports entity schema query result to csv file.
		 * @param {String} fileName Result file name.
		 * @param {String} entityName Entity name.
		 * @param {BPMSoft.EntitySchemaQuery|String} esq Entity schema query.
		 */
		generateCsvFile: function(fileName, entityName, esq) {
			esq.skipRowCount = 0;
			esq.rowCount = -1;
			var data = this.getJsonStringFromEsq(esq);
			BPMSoft.AjaxProvider.request({
				url: Ext.String.format("../rest/{0}/{1}", this.reportServiceName, this.exportFiltersKeyMethodName),
				headers: {
					"Accept": "application/json",
					"Content-Type": "application/json"
				},
				method: "POST",
				jsonData: data,
				callback: function(request, success, response) {
					if (success) {
						this.downloadEntityByFiltersKey(entityName, BPMSoft.decode(response.responseText),
								fileName);
					}
				},
				timeout: this._getTimeout(),
				scope: this
			});
		},

		/**
		 * Exports object list to csv file.
		 * @param {Object} config Configuration.
		 * @param {BPMSoft.EntitySchemaQuery} config.esq Entity schema query.
		 */
		exportToCsvFile: function(config) {
			var esq = config.esq;
			var entityName = esq.rootSchema.name;
			var data = esq.serialize();
			MaskHelper.ShowBodyMask();
			var serviceParam = {
				serviceName: this.reportServiceName,
				methodName: this.exportFiltersKeyMethodName,
				callback: function(response) {
					if (response && response.success && response.key) {
						this.downloadEntityByFiltersKey(entityName, response.key);
					} else {
						BPMSoft.showInformation(this.getErrorMessage(response, entityName));
					}
					MaskHelper.HideBodyMask();
				},
				data: data,
				timeout: this._getTimeout(),
				scope: this
			};
			ServiceHelper.callService(serviceParam);
		},

		/**
		 * Export to excel file and downloading him.
		 * @param {Object} config Config object.
		 * @param {Object} config.esq Entity Schema Query of the export data.
		 * @param {String} [config.downloadFileName]
		 * @param {Function} [config.callback] Callback function. Calls after started download excel file.
		 * @param {Object} [config.scope] Scope of the callback.
		 * @param {Object} [config.analyticsConfig] Config for Google analytics.
		 */
		exportToExcelFile: function(config) {
			this.sandbox = config.scope && config.scope.sandbox;
			this._checkCanExportToExсel(config.esq, function() {
				const startExportDate = Date.now();
				const esq = config.esq;
				const downloadFileName = config.downloadFileName || BPMSoft.randomString();
				const stripedDownloadFileName = BPMSoft.FileHelper.stripFileName(downloadFileName);
				const esqSerialized = esq.serialize();
				const serviceParam = {
					serviceName: this.reportServiceName,
					methodName: this._exportToExcelMethodName,
					data: {
						esqSerialized: esqSerialized
					},
					timeout: this._exportToExcelTimeout || this._defExportToExcelTimeOut
				};
				BPMSoft.ConfigurationServiceProvider.callService(serviceParam, function(responseObject, response) {
					const exportToExcellResponce = responseObject && responseObject.GetExportToExcelKeyResult;
					if (exportToExcellResponce && exportToExcellResponce.key) {
						GoogleTagManagerUtilities.actionModule(Ext.apply(config.analyticsConfig || {}, {
							loadTime: Date.now() - startExportDate,
							exportObjectName: esq && esq.rootSchema && esq.rootSchema.name,
							schemaName: "FileExportSchema",
							moduleName: "FileExportModule",
							totalRowsCount: exportToExcellResponce.count
						}));
						this._downloadExcelFileByKey(exportToExcellResponce.key, stripedDownloadFileName);
						Ext.callback(config.callback, config.scope);
						return;
					}
					BPMSoft.showInformation(this._getExportToExcelExceptionMessage(exportToExcellResponce, response));
					MaskHelper.HideBodyMask();
				}, this);
			}, this);
		},

		/**
		 * Checks operation and call callback if operation allow.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope for the callback.
		 */
		_checkCanExecuteExportGridOperation : function(callback, scope) {
			var exportOperation = {operation: this._exportAdminOperationName};
			RightUtilities.checkCanExecuteOperation(exportOperation, callback, scope)
		},

		/**
		 * Checks entity operation and call callback if entity operation allow.
		 * @param {String} schemaName The name of shema with which th operation will work
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope for the callback.
		 */
		_checkCanExecuteEntityExportOperation : function(schemaName, callback, scope) {
			RightUtilities.checkCanExecuteEntityOperation(schemaName, this._exportEntityOperationName, callback, scope);
		},

		/**
		 * Checks operation and entity operation and call callback if operation allow.
		 * @param {ObJect} esq Entity shcema query.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope for the callback.
		 */
		_checkCanExportToExсel: function(esq, callback, scope) {
			BPMSoft.chain(
				function(next) {
					this._checkCanExecuteExportGridOperation(next, this)
				},
				function(next, isAllow) {
					if (isAllow) {
						Ext.callback(callback, scope || this);
						return;
					} else if (!BPMSoft.Features.getIsEnabled("UseEntityOperationGrantee")) {
						var exportOperation = {operation: this._exportAdminOperationName};
						scope.showPermissionsErrorMessage(exportOperation.operation);
						return;
					}
					this._checkCanExecuteEntityExportOperation(esq.rootSchema.name, next, this)
				},
				function(next, isAllow) {
					if(!isAllow) {
						this._showExportPermissionsErrorMessage();
						return;
					}
					Ext.callback(callback, scope || this);
				},
				this
			);
		},

		/**
		 * Shows a message if the user does not have permission to export.
		 */
		_showExportPermissionsErrorMessage: function() {
			var message = resources.localizableStrings.ExportToExelPermissionsErrorMessage;
			BPMSoft.showInformation(message);
			MaskHelper.HideBodyMask();
		},

		/**
		 * Checks operation and call callback if operation allow.
		 * @param {String} operation Operation name.
		 * @param {Function} callback The callback function.
		 * @param {Object} [scope] The scope for the callback.
		 * @private
		 */
		_checkCanExecuteOperation: function(operation, callback, scope) {
			RightUtilities.checkCanExecuteOperation({
				operation: operation
			}, function(allow) {
				if (!allow) {
					scope.showPermissionsErrorMessage(operation);
					return;
				}
				Ext.callback(callback, scope || this);
			});
		}

		//endregion
	});

	return BPMSoft.DataUtilities;
});
