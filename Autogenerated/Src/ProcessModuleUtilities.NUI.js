define("ProcessModuleUtilities", [
	"ProcessModuleUtilitiesResources",
	"ConfigurationConstants",
	"ConfigurationEnums",
	"DesktopPopupNotification",
	"LookupUtilities",
	"ServiceHelper",
	"MaskHelper",
	"ActualProcessSchemasByFilterRequest",
	"ErrorListDialogComponent"
], function(resources, ConfigurationConstants, ConfigurationEnums, DesktopPopupNotification,
			LookupUtilities, ServiceHelper) {

	/**
	 * Class ProcessModuleUtilities contains utility methods for interaction with schemas business-processes.
	 */
	Ext.define("BPMSoft.configuration.ProcessModuleUtilities", {
		extend: "BPMSoft.BaseObject",
		alternateClassName: "BPMSoft.ProcessModuleUtilities",

		singleton: true,

		PROCESS_ENGINE_SERVICE_NAME: "ServiceModel/ProcessEngineService.svc",

		PROCESS_SCHEMA_MANAGER_SERVICE_NAME: "ServiceModel/ProcessSchemaManagerService.svc",

		SCHEMA_MANAGER_SERVICE_NAME: "ServiceModel/SchemaManagerService.svc",

		WORKSPACE_EXPLORER_SERVICE_NAME: "ServiceModel/WorkspaceExplorerService.svc",
		
		APP_INSTALLER_SERVICE_NAME: "ServiceModel/AppInstallerService.svc",

		REQUEST_TIMEOUT: 900000000,

		/**
		 * Client unit schema designer url template.
		 * @type {String}
		 */
		CLIENT_UNIT_SCHEMA_DESIGNER_URL_TEMPLATE: "/ClientApp/#/ClientUnitSchemaDesigner/{0}",

		/**
		 * Timeout for wait window open and not block by browser.
		 * @type {Number}
		 */
		waitOpenWindowTimeout: 1000,

		/**
		 * A flag that indicates that the application is running in demo mode.
		 * @protected
		 * @type {Boolean}
		 */
		isDemoBuild: false,

		/**
		 * Constructor of the class.
		 * @protected
		 */
		constructor: function() {
			this.callParent(arguments);
			this.setIsDemoBuild();
		},

		// region Methods: Private

		/**
		 * Initialize the demo mode flag.
		 * @private
		 */
		setIsDemoBuild: function() {
			BPMSoft.SysSettings.querySysSettingsItem("ShowDemoLinks", function(value) {
				this.isDemoBuild = value;
			}, this);
		},

		/**
		 * @private
		 * @param responseText Text of the response.
		 * @return {Object} Decoded response.
		 */
		_getDecodedResponse: function(responseText) {
			return BPMSoft.deserialize(BPMSoft.deserialize(responseText));
		},

		/**
		 * Callback function of request to the "ProcessEngineService" methods.
		 * @private
		 * @param {Object} request Instance of the request.
		 * @param {Boolean} success Service call executed successfully.
		 * @param {Object} response Server response.
		 * @return {Boolean} Return true if response message or error message was shown.
		 */
		responseCallback: function(request, success, response) {
			this.hideBodyMask();
			const result = this._getResponseResult(response);
			if (success && !result.message) {
				return false;
			}
			if (success) {
				if (!Ext.isEmpty(result) && result.success) {
					BPMSoft.showInformation(result.message);
				} else {
					BPMSoft.showErrorMessage(result.message);
					this.warning(result.message);
				}
			} else {
				BPMSoft.showErrorMessage(BPMSoft.Resources.ProcessSchemaDesigner.Messages.ProcessNotStartedMessage);
			}
			return true;
		},

		/**
		 * @private
		 * @param response Web service response.
		 */
		_getResponseResult: function(response) {
			if (!response) {
				return {};
			}
			if (response.errorInfo) {
				return	{
					success: false,
					message: response.errorInfo.message
				};
			}
			if (!this._canGetNextProcessStepsViaResponse()) {
				return this._getResponseResultOld(response);
			}
			return {
				success: response.success,
				message: response.message
			};
		},

		/**
		 * @private
		 * @param response Web service response.
		 */
		_getResponseResultOld: function(response) {
			const data = response.responseText && this._getDecodedResponse(response.responseText);
			const message = data && data.message;
			return {
				success: data.success,
				message: message
			};
		},

		/**
		 * @private
		 */
		_canGetNextProcessStepsViaResponse: function() {
			return BPMSoft.Features.getIsEnabled("GetProcessStepsViaResponse");
		},

		/**
		 * @private
		 */
		_executeProcessCallback: function(config, request, success, response) {
			if (!this.responseCallback(request, success, response)) {
				this.loadSchemaCaptionByName(config.sysProcessName, function(caption) {
					this._showSuccessfullyRunProcessPopup(caption);
				}, this);
			}
		},

		/**
		 * @private
		 */
		 _restart: function(callback, scope, request, success, response) {
			const responseText = JSON.parse(response.responseText);
			if (responseText.errors && responseText.errors.find(error => !error.warning)) {
				callback.call(scope, request, success, response);
				return;
			};
			this.callService({
				serviceName: this.APP_INSTALLER_SERVICE_NAME,
				methodName: "RestartApp",
				timeout: this.REQUEST_TIMEOUT
			}, callback.call(scope, request, success, response), scope)
		},

		/**
		 * @private
		 */
		_showSuccessfullyRunProcessPopup: function(processCaption) {
			DesktopPopupNotification.show({
				title: BPMSoft.Resources.ProcessSchemaDesigner.Messages.SuccessfullyRunProcessInformationMessage,
				body: processCaption,
				icon: BPMSoft.ImageUrlBuilder.getUrl({
					source: BPMSoft.ImageSources.RESOURCE_MANAGER,
					params: {
						resourceManagerName: "BPMSoft.Nui",
						resourceItemName: "ProcessSchemaDesigner.runProcess_notification.svg"
					}
				}),
				ignorePageVisibility: true
			});
		},

		/**
		 * Launches business-process.
		 * @obsolete
		 * @private
		 * @param {String} processName Name of the process.
		 * @param {Object} parameters Process parameters.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		runProcess: function(processName, parameters, callback, scope) {
			const obsoleteMessage = BPMSoft.Resources.ObsoleteMessages.ObsoleteMethodMessage;
			this.warning(Ext.String.format(obsoleteMessage, "runProcess", "executeProcess"));
			this._runProcess(processName, parameters, callback, scope);
		},

		/**
		 * Launches business-process.
		 * @private
		 * @param {String} processName Name of the process.
		 * @param {Object} parameters Process parameters.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		_runProcess: function(processName, parameters, callback, scope) {
			this.showBodyMask();
			if (this._canGetNextProcessStepsViaResponse()) {
				const options = {
					schemaName: processName,
					parameterValues: this._convertRequestParameters(parameters)
				};
				BPMSoft.ProcessEngineUtilities.runProcess(options, function(response) {
					Object.defineProperty(response, "responseText", {
						get: function() {
							const obsoleteMessage = BPMSoft.Resources.ObsoleteMessages.ObsoletePropertyMessage;
							console.warn(Ext.String.format(obsoleteMessage, "'responseText'", "'response'"));
							let responseText = response.initialConfig;
							if (response.errorInfo) {
								responseText = Ext.apply({
									message: response.errorInfo.message
								}, responseText);
							}
							return Ext.encode(Ext.encode(responseText));
						}
					});
					response.success = Ext.isDefined(response.errorInfo) || response.initialConfig.success;
					Ext.callback(callback, scope, [null, response.success, response]);
				}, scope);
			} else {
				this._runProcessOld(processName, parameters, callback, scope);
			}
		},

		/**
		 * @private
		 */
		_convertRequestParameters: function(inputParameters) {
			if (!inputParameters) {
				return null;
			}
			const parameters = {};
			BPMSoft.each(inputParameters, function(value, name) {
				const isEnabled = BPMSoft.Features.getIsEnabled("PassProcessParameterValueAsArray");
				let convertedValue = value;
				if (!isEnabled && Ext.isArray(value)) {
					this.warning("Unsupported type 'Array' for the parameter '" + name + "'");
					convertedValue = value.toString();
				}
				parameters[name] = convertedValue;
			}, this);
			return parameters;
		},

		/**
		 * @private
		 */
		_runProcessOld: function(processName, parameters, callback, scope) {
			let queryString = "";
			if (parameters) {
				const queryItems = _.map(parameters, function(value, name) {
					return name + "=" + value;
				}, this);
				queryString = "?" + queryItems.join("&");
			}
			this.callService({
				serviceName: this.PROCESS_ENGINE_SERVICE_NAME,
				methodName: processName + "/RunProcess" + queryString
			}, callback, scope);
		},

		/**
		 * Returns unique name and caption of the business-process schema.
		 * @private
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		getUniqueNameAndCaption: function(callback, scope) {
			this.callService({
				serviceName: this.SCHEMA_MANAGER_SERVICE_NAME,
				methodName: "GetUniqueNameAndCaption?managerName=ProcessSchemaManager",
				timeout: this.REQUEST_TIMEOUT
			}, function(request, success, response) {
				if (success) {
					const uniqueNameAndCaption = Ext.decode(Ext.decode(response.responseText));
					Ext.callback(callback, scope, [uniqueNameAndCaption]);
				}
			}, this);
		},

		/**
		 * Execute process by name.
		 * @private
		 * @param {Object} config Configuration object.
		 * @param {String} config.sysProcessName Name of the process schema.
		 * @param {Object} config.parameters Process parameters.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		_executeProcessByName: function(config, callback, scope) {
			const sysProcessName = config.sysProcessName;
			this._runProcess(sysProcessName, config.parameters, callback, scope);
		},

		/**
		 * Returns response for not found schema.
		 * @private
		 * @param {String} sysProcessId Unique identifier of the process schema.
		 * @return {Object}
		 */
		_getItemNotFoundResponse: function(sysProcessId) {
			const message = Ext.String.format(resources.localizableStrings.ProcessSchemaNotFound, sysProcessId);
			const response = Ext.encode(Ext.encode({
				success: false,
				message: message
			}));
			return {responseText: response};
		},

		/**
		 * Execute process by ID.
		 * @private
		 * @param {Object} config Configuration object.
		 * @param {String} config.sysProcessId Unique identifier of the process schema.
		 * @param {Object} config.parameters Process parameters.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		_executeProcessById: function(config, callback, scope) {
			const id = config.sysProcessId;
			const esq = new BPMSoft.EntitySchemaQuery("VwSysProcess");
			esq.addColumn("Id", "Id");
			esq.addColumn("Name", "Name");
			esq.getEntity(id, function(result) {
				if (Ext.isEmpty(result.entity)) {
					const responseText = this._getItemNotFoundResponse(id);
					Ext.callback(callback, scope, [{}, true, responseText]);
				} else {
					config.sysProcessName = result.entity.get("Name");
					this.executeProcess(config, callback, scope);
				}
			}, this);
		},

		/**
		 * @private
		 **/
		_getQuickRunProcessESQ: function() {
			const runButtonListFilter = BPMSoft.createExistsFilter("[RunButtonProcessList:SysSchemaUId:UId].Id");
			const filters = [runButtonListFilter];
			const esq = BPMSoft.ProcessEntryPointUtilities.getCanRunProcessFromSection()
				? this.createRunProcessESQ(filters)
				: this.createRunProcessSelect(filters);
			this._addFiltersForManualStartList(esq.rootSchemaName, esq.filters);
			return esq;
		},

		/**
		 * @private
		 **/
		_addFiltersForManualStartList: function(schemaName, filters) {
			const getVwProcessLibColumnPath = function(columnPath) {
				if (schemaName === "VwProcessLib") {
					return columnPath;
				}
				return "[VwProcessLib:SysSchemaId:SysSchemaId]." + columnPath;
			};
			filters.add("hasStartEvent", BPMSoft.createColumnFilterWithParameter(
				getVwProcessLibColumnPath("HasStartEvent"), true));
		},

		/**
		 * @private
		 **/
		_addProcessSchemaRightsFilter: function(filters) {
			if (BPMSoft.Features.getIsDisabled("UseProcessSchemaExecuteRights")) {
				return;
			}
			const rightsColumnPath = "[VwSysProcessSchemaUserRight:SysSchema:SysSchemaId].Id";
			const existsFilter = BPMSoft.createExistsFilter(rightsColumnPath);
			existsFilter.subFilters.addItem(BPMSoft.createColumnFilterWithParameter(
				BPMSoft.ComparisonType.EQUAL, "SysAdminUnit", BPMSoft.SysValue.CURRENT_USER.value));
			filters.add("processesRights", existsFilter);
		},

		/**
		 * @private
		 */
		_getStartProcessPageFilters: function(schemaName) {
			const vwSysProcessFilters = BPMSoft.createFilterGroup();
			vwSysProcessFilters.name = "vwSysProcessFiler";
			const sysWorkspaceFilter = BPMSoft.createColumnFilterWithParameter(
				BPMSoft.ComparisonType.EQUAL, "SysWorkspace",
				BPMSoft.SysValue.CURRENT_WORKSPACE.value);
			vwSysProcessFilters.addItem(sysWorkspaceFilter);
			const businessProcessTagFilter = BPMSoft.createColumnFilterWithParameter(
				BPMSoft.ComparisonType.EQUAL, "TagProperty",
				ConfigurationConstants.SysProcess.BusinessProcessTag);
			vwSysProcessFilters.addItem(businessProcessTagFilter);
			const isMaxVersionFilter = BPMSoft.createColumnFilterWithParameter(
				BPMSoft.ComparisonType.EQUAL, "IsMaxVersion", true);
			vwSysProcessFilters.addItem(isMaxVersionFilter);
			this._addFiltersForManualStartList(schemaName, vwSysProcessFilters);
			this._addProcessSchemaRightsFilter(vwSysProcessFilters);
			return vwSysProcessFilters;
		},

		/**
		 * Get business process information for run process with parameter.
		 * @param {Guid} processUId UId scheme of the business process.
		 * @param {Guid} parameterUId UId of the business process parameter.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback scope.
		 * @private
		 */
		_getInfoRunProcessWithParameter: function (processUId, parameterUId, callback, scope) {
			ServiceHelper.callService("ProcessInfoService", "GetProcessWithParametersInfo", function (response) {
				const info = response.GetProcessWithParametersInfoResult;
				if (info.success) {
					callback.call(scope, info.ProcessName, info.ParameterName);
				}
			}, {processUId: processUId, parameterUId: parameterUId});
		},

		/**
		 * Adds data from Custom  package to the drop-down list.
		 * @private
		 * @param {Object} rows The data for the drop-down list.
		 * @param {String} customPackageUId Unique identifier of the Custom package.
		 */
		addCustomPackage: function(rows, customPackageUId) {
			rows[customPackageUId] = {
				"UId": customPackageUId,
				"value": customPackageUId,
				"displayValue": resources.localizableStrings.CustomPackageName
			};
		},

		/**
		 * Adds Custom package to the "SysPackage" list when it's doesn't exists.
		 * @private
		 * @param {BPMSoft.Collection} list List of the packages.
		 * @param {Object} rows The data for the drop-down list.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		tryAddCustomPackage: function(list, rows, callback, scope) {
			BPMSoft.SysSettings.querySysSettingsItem("CustomPackageUId",
				function(customPackageUId) {
					const guidEmpty = BPMSoft.GUID_EMPTY;
					customPackageUId = (customPackageUId && customPackageUId.value) || guidEmpty;
					if (!rows[customPackageUId] && !rows[guidEmpty]) {
						this.addCustomPackage(rows, guidEmpty);
					}
					Ext.callback(callback, scope || this, [list, rows]);
				}, this);
		},

		/**
		 * Returns ESQ for load schema display value.
		 * @private
		 * @param {String} schemaUId Schema unique identifier.
		 * @return {BPMSoft.EntitySchemaQuery}
		 */
		getSchemaDisplayValueESQ: function(schemaUId) {
			const esq = Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: "VwSysSchemaInWorkspace",
				clientESQCacheParameters: {
					cacheItemName: schemaUId + "-SchemaCaption"
				}
			});
			esq.addColumn("Name");
			esq.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_DISPLAY_COLUMN, "Caption");
			const currentWorkspace = BPMSoft.SysValue.CURRENT_WORKSPACE.value;
			esq.filters.addItem(esq.createColumnFilterWithParameter("UId", schemaUId));
			esq.filters.addItem(esq.createColumnFilterWithParameter("SysWorkspace", currentWorkspace));
			return esq;
		},

		/**
		 * Returns "GetInvalidElements" service method name.
		 * @private
		 * @param {Object} config Configuration object.
		 * @param {String} config.schemaUId The process schema identifier.
		 * @param {String} config.hostProcessSchemaName The host process schema name.
		 * @return {String} Service method name.
		 */
		getInvalidElementsServiceMethodName: function(config) {
			let methodName = "GetInvalidElements?schemaUId=" + config.schemaUId;
			const hostProcessSchemaName = config.hostProcessSchemaName;
			if (hostProcessSchemaName) {
				methodName += "&hostProcessSchemaName=" + hostProcessSchemaName;
			}
			return methodName;
		},
		
		/**
		 * Returns "GetIsolatedElements" service method name.
		 * @private
		 * @param {Object} config Configuration object.
		 * @param {String} config.schemaUId The process schema identifier.
		 * @param {String} config.hostProcessSchemaName The host process schema name.
		 * @return {String} Service method name.
		 */
		getIsolatedElementsServiceMethodName: function(config) {
			let methodName = "GetIsolatedElements?schemaUId=" + config.schemaUId;
			const hostProcessSchemaName = config.hostProcessSchemaName;
			if (hostProcessSchemaName) {
				methodName += "&hostProcessSchemaName=" + hostProcessSchemaName;
			}
			return methodName;
		},

		/**
		 * Returns URL which is needed for opening schema designer.
		 * @param {Object} config Configuration object.
		 * @param {String} config.designer Designer name.
		 * @param {String} config.type Designer type.
		 * @param {String} [config.schemaUId] Unique identifier of the schema.
		 * @return {String} The URL to be loaded in the newly opened window.
		 */
		getSchemaDesignerUrl: function(config) {
			const parameters = config.parameters || [];
			let schemaUId = config.schemaUId;
			const type = config.type;
			if (Ext.isEmpty(schemaUId)) {
				schemaUId = parameters.length > 0 ? "add" : "";
			}
			let suffixUrl = "";
			parameters.forEach(function(parameter) {
				suffixUrl += "/" + parameter;
			}, this);
			return Ext.String.format("ViewModule.aspx?vm={0}#{1}/{2}{3}", config.designer, type, schemaUId, suffixUrl);
		},

		/**
		 * Shows schema designer window.
		 * @private
		 * @param {Object} config Configuration object.
		 * @param {String} config.designer Designer name.
		 * @param {String} config.type Designer type.
		 * @param {String} [config.schemaUId] Unique identifier of the schema.
		 */
		showSchemaDesignerWindow: function(config) {
			const url = this.getSchemaDesignerUrl(config);
			const popup = window.open(url);
			setTimeout(function() {
				if (!popup || popup.outerHeight === 0) {
					BPMSoft.showInformation(resources.localizableStrings.PopupBlockedMessage);
				}
			}, this.waitOpenWindowTimeout);
		},

		/**
		 * Opens designer.
		 * @private
		 * @param {Object} config Configuration object.
		 * @param {String} config.designer Designer name.
		 * @param {String} config.type Designer type.
		 * @param {String} [config.schemaUId] Unique identifier of the schema.
		 */
		showSchemaDesigner: function(config) {
			this.showSchemaDesignerWindow(config);
		},



		// endregion

		// region Methods: Public

		/**
		 * Check is application run at demo mode.
		 * @param {Object} scope The scope of callback function.
		 */
		getIsDemoMode: function(scope) {
			if (this.isDemoBuild) {
				scope.showInformationDialog(resources.localizableStrings.DisableInDemoMessage);
			}
			return this.isDemoBuild;
		},

		/**
		 * Returns number of running the process elements.
		 * @param {Object} procExecDataCollection Collection of running the process elements.
		 * @return {Number}
		 */
		getProcExecDataCollectionCount: function(procExecDataCollection) {
			let itemsCount = 0;
			BPMSoft.each(procExecDataCollection, function(item, propertyName) {
				if (propertyName !== "previousProcElUId" && item && !Ext.isFunction(item) &&
						!Ext.isEmpty(item.procElUId)) {
					itemsCount++;
				}
			}, this);
			return itemsCount;
		},

		/**
		 * Opens chart of process execution.
		 * @param {String} sysProcessLogId Unique identifier of the record in process log.
		 */
		showProcessDiagram: function(sysProcessLogId) {
			const type = BPMSoft.Features.getIsEnabled("UseProcessDiagramComponent") ? "processLog" : "processLogOld";
			const config = {
				designer: "SchemaDesigner",
				type: type,
				schemaUId: sysProcessLogId
			};
			this.showSchemaDesignerWindow(config);
		},

		/**
		 * Opens chart of dcm execution.
		 * @param {String} sysProcessLogId Unique identifier of the record in process log.
		 */
		showDcmDiagram: function(sysProcessLogId) {
			this.showSchemaDesignerWindow({
				designer: "SchemaDesigner",
				type: "dcmLog",
				schemaUId: sysProcessLogId
			});
		},

		/**
		 * Opens the client unit schema designer.
		 * @param {String} uId Unique identifier of schema.
		 */
		showClientUnitSchemaDesigner: function({uId}) {
			const hash = Ext.String.format(this.CLIENT_UNIT_SCHEMA_DESIGNER_URL_TEMPLATE, uId);
			const url = BPMSoft.workspaceBaseUrl + hash;
			window.open(url, "_blank");
		},

		/**
		 * Opens existing process user task designer 5x.
		 * @param {String} schemaUId Unique identifier
		 */
		show5xExistingUserTaskSchemaDesigner: function(schemaUId) {
			this.callService({
				serviceName: this.PROCESS_SCHEMA_MANAGER_SERVICE_NAME,
				methodName: "PrepareExistingUserTaskSchemaForEdit?schemaUId=" + schemaUId,
				timeout: this.REQUEST_TIMEOUT
			}, function(request, success) {
				if (success) {
					const url = "../Designers/ProcessUserTaskSchemaDesigner.aspx?Id=" + schemaUId + "&isNewSchema=0";
					window.open(url);
				}
			}, this);
		},

		/**
		 * Opens existing process user task designer.
		 * @param {String} schemaUId Unique identifier
		 */
		showUserTaskSchemaDesigner: function(schemaUId) {
			this.callService({
				serviceName: this.PROCESS_SCHEMA_MANAGER_SERVICE_NAME,
				methodName: "PrepareExistingUserTaskSchemaForEdit?schemaUId=" + schemaUId,
				timeout: this.REQUEST_TIMEOUT
			}, function(request, success) {
				if (success) {
					const url = BPMSoft.Features.getIsEnabled("DisableUserTaskSchemaDesignerComponent")
						? "../Designers/ProcessUserTaskSchemaDesigner.aspx?Id=" + schemaUId + "&isNewSchema=0"
						: "../ClientApp/#/UserTaskSchemaDesigner/" + schemaUId;
					window.open(url);
				}
			}, this);
		},

		/**
		 * Opens the process designer.
		 * @param {String} [schemaUId] Unique identifier of the process schema,
		 * opens the designer for the new process when not set.
		 */
		showProcessSchemaDesigner: function(schemaUId) {
			const type = BPMSoft.Features.getIsEnabled("UseProcessDiagramComponent") ? "process" : "processOld";
			const config = {
				designer: "SchemaDesigner",
				type: type,
				schemaUId: schemaUId
			};
			this.showSchemaDesigner(config);
		},

		/**
		 * Opens the case designer.
		 * @param {Object} [config] Configuration object.
		 * @param {String} [config.schemaUId] Unique identifier of the case schema,
		 * opens the designer for the new process when not set.
		 * @param {String} [config.dcmSettingsId] Unique identifier of DCM settings.
		 * @param {String} [config.packageUId] Unique identifier of package.
		 */
		showCaseSchemaDesigner: function(config) {
			config = config || {};
			const urlConfig = {
				designer: "DcmDesigner",
				type: "case",
				schemaUId: config.schemaUId
			};
			const dcmSettingsId = config.dcmSettingsId;
			if (dcmSettingsId) {
				urlConfig.parameters = [dcmSettingsId];
				const packageUId = config.packageUId;
				if (packageUId) {
					urlConfig.parameters.push(packageUId);
				}
			}
			this.showSchemaDesignerWindow(urlConfig);
		},

		/**
		 * Opens the page designer.
		 * @param {String} pageUId Unique identifier of the page schema,
		 * opens the designer for the new page when not set.
		 * @param {String} templateUId Unique identifier of the template(Parent) page schema,
		 */
		showPageSchemaDesigner: function(pageUId, templateUId) {
			const config = {
				designer: "PageWizard",
				type: pageUId ? "PageDesigner" : "New",
				schemaUId: pageUId || templateUId
			};
			this.showSchemaDesigner(config);
		},

		/**
		 * Opens the page designer.
		 */
		showPageTemplateLookup: function() {
			const config = {
				designer: "PageWizard",
				type: "PageTemplateModule"
			};
			this.showSchemaDesigner(config);
		},

		/**
		 * Opens edit page of the activity by business-process.
		 * @param {Object} config Parameters.
		 * Sample call:
		 * 1. tryShowProcessCard(config);
		 * 2. tryShowProcessCard(prcElId, recordId, operation);
		 * @return {Boolean} Is edit page opened.
		 */
		tryShowProcessCard: function(config) {
			let processExecDataConfig = {
				scope: this,
				parentMethodArguments: null,
				parentMethod: null,
				operation: ConfigurationEnums.CardStateV2.EDIT
			};
			if (Ext.isObject(config)) {
				processExecDataConfig = Ext.apply(processExecDataConfig, config);
			} else {
				processExecDataConfig.procElUId = arguments[0];
				processExecDataConfig.recordId = arguments[1];
				if (arguments.length > 2) {
					processExecDataConfig.operation = arguments[2];
				}
			}
			if (processExecDataConfig.procElUId && !BPMSoft.isEmptyGUID(processExecDataConfig.procElUId)) {
				this.sandbox.publish("ProcessExecDataChanged", processExecDataConfig);
				return true;
			}
			return false;
		},

		/**
		 * Calls the Web service method with the specified parameters.
		 * @param {Object} config The call parameters.
		 * @param {Object} [config.data] Data to send.
		 * @param {Boolean} [config.encodeData] Flag that indicates when to encode data before send.
		 * @param {String} config.serviceName Service name.
		 * @param {String} config.methodName Service method name.
		 * @param {String} [config.method] (optional) HTTP method name.
		 * @param {Number} [config.timeout] Request timeout.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		callService: function(config, callback, scope) {
			const dataSend = config.data || {};
			const jsonData = (config.encodeData === false) ? dataSend : Ext.encode(dataSend);
			const requestUrl = BPMSoft.combinePath(BPMSoft.workspaceBaseUrl,
				config.serviceName, config.methodName);
			return BPMSoft.AjaxProvider.request({
				url: requestUrl,
				headers: {
					"Accept": "application/json",
					"Content-Type": "application/json"
				},
				method: config.method || "POST",
				jsonData: jsonData,
				callback: callback,
				scope: scope || this,
				timeout: config.timeout
			});
		},

		/**
		 * Save the business-process schema.
		 * @param {Object} scope The scope of callback function.
		 * @param {Object} schema Process schema object.
		 * @param {Function} callback The callback function.
		 */
		saveProcessSchema: function(scope, schema, callback) {
			this.callService({
				serviceName: this.PROCESS_SCHEMA_MANAGER_SERVICE_NAME,
				methodName: "Save",
				data: schema || {},
				timeout: this.REQUEST_TIMEOUT
			}, function(request, success, response) {
				if (!success) {
					return;
				}
				const responseObject = Ext.decode(Ext.decode(response.responseText));
				Ext.callback(callback, scope || this, [responseObject]);
				if (responseObject.success && responseObject.message) {
					BPMSoft.utils.showInformation(responseObject.message);
				}
			}, this);
		},

		/**
		 * Loads the business-process schema data.
		 * @param {Object} scope The scope of callback function.
		 * @param {String} schemaUId Unique identifier of the process schema.
		 * @param {Function} callback The callback function.
		 */
		loadProcessSchema: function(scope, schemaUId, callback) {
			this.showBodyMask();
			this.callService({
				serviceName: this.PROCESS_SCHEMA_MANAGER_SERVICE_NAME,
				methodName: schemaUId + "/Load"
			}, function(request, success, response) {
				this.hideBodyMask();
				if (success) {
					const data = Ext.decode(Ext.decode(response.responseText));
					Ext.callback(callback, scope || this, [data]);
				}
			}, this);
		},

		/**
		 * Launches business process by identifier or name.
		 * @param {Object} config Configuration object.
		 * @param {String} [config.sysProcessName] Name of the process schema.
		 * @param {String} [config.sysProcessId] Unique identifier of the process schema.
		 * @param {Object} [config.parameters] Process parameters.
		 * @param {Function} [config.callback] Callback function.
		 * @param {Object} [config.scope] Callback scope.
		 */
		executeProcess: function(config) {
			const callback = config.callback || this._executeProcessCallback.bind(this, config);
			const scope = config.scope || this;
			if (config.sysProcessName) {
				this._executeProcessByName(config, callback, scope);
			} else {
				this._executeProcessById(config, callback, scope);
			}
		},

		/**
		 * Allows publication of schemas.
		 * @param {Function} [callback] The callback function.
		 * @param {Object} [scope] Execution context.
		 */
		publish: function(callback, scope) {
			if (Ext.isDefined(callback)) {
				scope = scope || this;
			} else {
				callback = this.responseCallback;
				scope = this;
			}
			this.showBodyMask({caption: resources.localizableStrings.PublishMaskCaption});
			this.callService({
				serviceName: this.WORKSPACE_EXPLORER_SERVICE_NAME,
				methodName: "Build",
				timeout: this.REQUEST_TIMEOUT
			}, this._restart.bind(this, callback, scope), scope);
		},

		/**
		 * Ping application. Using for waiting server response after restart IIS.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		pingApplication: function(callback, scope) {
			this.callService({
				serviceName: this.PROCESS_SCHEMA_MANAGER_SERVICE_NAME,
				methodName: "PingApplication",
				timeout: this.REQUEST_TIMEOUT
			}, callback, scope);
		},

		/**
		 * @private
		 */
		_obsoleteContinueExecuting: function(processUId, callback, scope) {
			this.callService({
				serviceName: this.PROCESS_ENGINE_SERVICE_NAME,
				methodName: processUId + "/ContinueExecuting",
				timeout: this.REQUEST_TIMEOUT
			}, callback, scope);
		},

		/**
		 * Continue the process execution.
		 * @param {String} processUId Unique identifier of the process.
		 */
		continueExecuting: function(processUId) {
			this.showBodyMask();
			const callback = function() {
				this.hideBodyMask();
			};
			if (BPMSoft.Features.getIsEnabled("UseObsoleteContinueProcessMethod")) {
				this._obsoleteContinueExecuting(processUId, callback, this);
			} else {
				this.openProcessExecutionPage(processUId, callback, this);
			}
		},

		/**
		 * Opens the first available process page.
		 * @param {String} processId Identifier of the process.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Scope object.
		 */
		openProcessExecutionPage: function(processId, callback, scope) {
			const request = Ext.create("BPMSoft.OpenProcessPageRequest", {
				processId: processId
			});
			request.execute(function(response) {
				let processFound = true;
				let pageOpened = false;
				const hasExecutionData = BPMSoft.isArray(response.executionData) &&
					response.executionData.length > 0;
				if (response.success && hasExecutionData) {
					const executionData = BPMSoft.first(response.executionData);
					BPMSoft.ProcessExecutionDataCollector.add(executionData, { executeImmediate: true });
					pageOpened = true;
				} else if (response.errorInfo.errorCode === "ItemNotFoundException") {
					processFound = false;
				}
				if (!pageOpened) {
					this.error("Page not opened for processUId " + processId + " (error info: " +
						response.errorInfo?.toString() + ")");
				}
				Ext.callback(callback, scope, [processFound, pageOpened]);
			}, scope);
		},

		/**
		 * Returns execution data of the process element.
		 * @param {String} processElementUId Unique identifier of the process element.
		 * @param {String} recordId Unique identifier of activity attached to the process.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		getExecutionData: function(processElementUId, recordId, callback, scope) {
			const template = "GetExecutionData?ProcElUId={0}&RecordId={1}";
			const methodName = Ext.String.format(template, processElementUId, recordId);
			this.callService({
				serviceName: this.PROCESS_ENGINE_SERVICE_NAME,
				methodName: methodName,
				timeout: this.REQUEST_TIMEOUT
			}, callback, scope);
		},

		/**
		 * Cancels all running instances of processes to the scheme identifier.
		 * @param {Object} scope The scope of callback function.
		 * @param {String} schemaId Unique schema identifier in the user workspace.
		 * @param {Function} callback The callback function.
		 * @param {String} displayValue Process schema display value.
		 */
		cancelExecutionBySchemaId: function(scope, schemaId, callback) {
			let responseObject = null;
			BPMSoft.chain(
				function(next) {
					this.cancelExecution(schemaId, next, this);
				},
				function(next, success, response) {
					if (success) {
						responseObject = Ext.decode(Ext.decode(response.responseText));
					}
					next();
				},
				function() {
					Ext.callback(callback, scope, [responseObject]);
				}, this
			);
		},

		/**
		 * Silently cancels all running instances of processes to the scheme identifier.
		 * @param {String} schemaUId Unique schema identifier.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		cancelExecution: function(schemaUId, callback, scope) {
			this.showBodyMask();
			this.callService({
				serviceName: this.PROCESS_ENGINE_SERVICE_NAME,
				methodName: "CancelExecutionBySchemaId?schemaId=" + schemaUId,
				timeout: this.REQUEST_TIMEOUT
			}, function(request, success, response) {
				this.hideBodyMask();
				const responseObject = Ext.decode(Ext.decode(response.responseText));
				if (!responseObject.success) {
					this.log(responseObject.message);
				}
				Ext.callback(callback, scope, [success, response]);
			}, this);
		},

		/**
		 * Silently cancels all running instances for the specified processes.
		 * @param {Array} processIds Process ids array.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		cancelExecutionBatch: function(processIds, callback, scope) {
			this.showBodyMask();
			this.callService({
				serviceName: this.PROCESS_ENGINE_SERVICE_NAME,
				methodName: "CancelExecution",
				timeout: this.REQUEST_TIMEOUT,
				data: {processDataIds: processIds.join(";")}
			}, function(request, success, response) {
				this.hideBodyMask();
				Ext.callback(callback, scope, [success, response]);
			}, this);
		},

		/**
		 * Displays mask.
		 */
		showBodyMask: function() {
			BPMSoft.MaskHelper.showBodyMask();
		},

		/**
		 * Hides mask.
		 */
		hideBodyMask: function() {
			BPMSoft.MaskHelper.hideBodyMask();
		},

		/**
		 * @private
		 */
		_getCompleteExecutionData: function(response, success, tag) {
			let completeExecutionData;
			let errorMessage = response.responseText;
			const responseContent = response && response.responseXML && response.responseXML.firstChild;
			if (success && responseContent) {
				const responseText = responseContent.textContent || responseContent.text || null;
				completeExecutionData = Ext.decode(responseText, true);
				if (completeExecutionData) {
					errorMessage = null;
				}
			}
			if (errorMessage) {
				const template = resources.localizableStrings.ErrorStartBusinessProcess;
				const message = Ext.String.format(template, tag.name, errorMessage);
				window.console.error(message);
			}
			return completeExecutionData;
		},

		/**
		 * Launches business process.
		 * @param {Object} tag Parameters for launch the process.
		 * @param {String} tag.name Name of the process.
		 * @param {Object} tag.scope Execution context.
		 * @param {Object} tag.parameters Process parameters.
		 * @param {Function} tag.callback  Callback function.
		 */
		startBusinessProcess: function(tag) {
			const scope = tag.scope || this;
			let parametersQueryString = "";
			if (!Ext.isEmpty(tag.parameters)) {
				parametersQueryString += "?";
				let isNotFirstParameter = false;
				BPMSoft.each(tag.parameters, function(value, name) {
					if (isNotFirstParameter) {
						parametersQueryString += "&";
					} else {
						isNotFirstParameter = true;
					}
					parametersQueryString += name + "=" + value;
				}, this);
			}
			let callServiceCallback = BPMSoft.emptyFn;
			const tagCallback = tag.callback;
			if (Ext.isFunction(tagCallback)) {
				callServiceCallback = function(request, success, response) {
					const completeExecutionData = this._getCompleteExecutionData(response, success, tag);
					tagCallback.call(scope, success, completeExecutionData);
				};
			}
			BPMSoft.AjaxProvider.request({
				url: BPMSoft.workspaceBaseUrl + "/ServiceModel/ProcessEngineService.svc/" +
					tag.name + "/Execute" + parametersQueryString,
				method: "POST",
				jsonData: {},
				scope: this,
				callback: callServiceCallback
			});
		},

		/**
		 * @deprecated Use method createRunProcessESQ
		 * Creates query for reading available for running processes.
		 * @param {Array} filters Set of filters.
		 * @return {BPMSoft.EntitySchemaQuery} The Query to EntitySchema.
		 */
		createRunProcessSelect: function(filters) {
			const select = Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: "VwSysProcess"
			});
			const idColumnName = "Id";
			const captionColumnName = "Caption";
			select.addColumn(idColumnName);
			select.addColumn(captionColumnName);
			const vwSysProcessFilters = BPMSoft.createFilterGroup();
			vwSysProcessFilters.name = "vwSysProcessFiler";
			const currentWorkspace = BPMSoft.SysValue.CURRENT_WORKSPACE.value;
			vwSysProcessFilters.addItem(BPMSoft.createColumnFilterWithParameter("SysWorkspace", currentWorkspace));
			vwSysProcessFilters.addItem(BPMSoft.createColumnFilterWithParameter("IsMaxVersion", true));
			if (filters) {
				BPMSoft.each(filters, function(filter) {
					vwSysProcessFilters.addItem(filter);
				}, this);
			}
			this._addProcessSchemaRightsFilter(vwSysProcessFilters);
			select.filters.add("availableProcesses", vwSysProcessFilters);
			return select;
		},

		/**
		 * Returns query for reading available for running processes.
		 * @param {Array} additionalFilters Set of filters.
		 * @return {BPMSoft.EntitySchemaQuery} The Query to EntitySchema.
		 */
		createRunProcessESQ: function(additionalFilters) {
			additionalFilters = additionalFilters || [];
			const select = Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: "VwProcessLib"
			});
			select.addColumn("Id");
			select.addColumn("Caption");
			const currentWorkspace = BPMSoft.SysValue.CURRENT_WORKSPACE.value;
			const workplaceFilter = BPMSoft.createColumnFilterWithParameter("SysWorkspace", currentWorkspace);
			const activeVersionFilter = BPMSoft.createColumnFilterWithParameter("IsActiveVersion", true);
			const enabledFilter = BPMSoft.createColumnFilterWithParameter("Enabled", true);
			const vwSysProcessFilters = BPMSoft.createFilterGroup();
			vwSysProcessFilters.name = "VwProcessLibFilter";
			vwSysProcessFilters.loadAll([workplaceFilter, activeVersionFilter, enabledFilter]);
			vwSysProcessFilters.loadAll(additionalFilters);
			this._addProcessSchemaRightsFilter(vwSysProcessFilters);
			select.filters.add("availableProcesses", vwSysProcessFilters);
			return select;
		},

		/**
		 * Event handler on the data preparation for the drop-down list.
		 * @param {Object} filter Filters for data preparation.
		 * @param {BPMSoft.core.collections.Collection} list The data for the drop-down list.
		 */
		onPrepareSysPackageList: function(filter, list) {
			list.clear();
			const esq = Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: "SysPackage",
				clientESQCacheParameters: {
					cacheItemName: "SysPackageList"
				}
			});
			esq.addColumn("UId");
			esq.addColumn("Id");
			esq.addColumn("Name");
			const currentWorkspace = BPMSoft.SysValue.CURRENT_WORKSPACE.value;
			const currentMaintainer = BPMSoft.SysValue.CURRENT_MAINTAINER.value;
			esq.filters.add("SysWorkspace", BPMSoft.createColumnFilterWithParameter("SysWorkspace", currentWorkspace));
			esq.filters.add("Maintainer", BPMSoft.createColumnFilterWithParameter("Maintainer", currentMaintainer));
			esq.getEntityCollection(function(response) {
				const collection = response.collection;
				const rows = {};
				if (collection && collection.collection.length > 0) {
					BPMSoft.each(collection.collection.items, function(item) {
						const listValue = {
							UId: item.values.UId,
							value: item.values.Id,
							displayValue: item.values.Name
						};
						rows[item.values.UId] = listValue;
					}, this);
				}
				this.tryAddCustomPackage(list, rows, function(innerList, innerRows) {
					const sortedList = Ext.create("BPMSoft.Collection");
					sortedList.loadAll(innerRows);
					sortedList.sort("displayValue", BPMSoft.OrderDirection.ASC);
					innerList.loadAll(sortedList);
				}, this);
			}, this);
		},

		/**
		 * Get a list of the available results of the user action.
		 * @param {Object} scope The scope of callback function.
		 * @param {Object} processActivity The parameters of the user action.
		 * @param {Function} callback The callback function.
		 */
		getProcessActivityResultsLookupGridData: function(scope, processActivity, callback) {
			this.callService({
				serviceName: this.PROCESS_SCHEMA_MANAGER_SERVICE_NAME,
				methodName: "GetProcessActivityResultsLookupGridData",
				data: processActivity || {}
			}, function(request, success, response) {
				if (success) {
					const resultsLookupGridData = Ext.decode(Ext.decode(response.responseText));
					callback.call(scope || this, resultsLookupGridData);
				}
			}, this);
		},

		/**
		 * Activates the process.
		 * @param {String} sysSchemaId Unique identifier of the process schema.
		 * @param {Object} scope The scope of callback function.
		 * @param {Function} callback The callback function.
		 */
		enableProcess: function(sysSchemaId, scope, callback) {
			this.showBodyMask();
			this.changeProcessState(sysSchemaId, true, callback, scope);
		},

		/**
		 * Deactivates the process.
		 * @param {String} sysSchemaId Unique identifier of the process schema.
		 * @param {Object} scope The scope of callback function.
		 * @param {Function} callback The callback function.
		 */
		disableProcess: function(sysSchemaId, scope, callback) {
			this.showBodyMask();
			BPMSoft.chain(
				function(next) {
					const canUseProcessVersions = BPMSoft.ProcessSchemaManager.getCanUseProcessVersions();
					if (canUseProcessVersions) {
						this.getRunningProcessVersionsCountBySysSchemaId(sysSchemaId, next);
					} else {
						this.getRunningProcessCountBySysSchemaId(sysSchemaId, next);
					}
				},
				function(next, responseSuccess, runningProcessCount) {
					if (responseSuccess) {
						this.disableProcessWithCancelExecution(sysSchemaId, runningProcessCount, callback, scope);
					} else {
						Ext.callback(callback, scope, [false]);
					}
				}, this
			);
		},

		/**
		 * Deactivates the process with the abolition of running instances.
		 * @param {String} sysSchemaId Unique identifier of the process schema.
		 * @param {Number} runningProcessCount Number of running processes.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		disableProcessWithCancelExecution: function(sysSchemaId, runningProcessCount, callback, scope) {
			BPMSoft.chain(
				function(next) {
					if (runningProcessCount === 0) {
						this.changeProcessState(sysSchemaId, false, callback, scope);
					} else {
						this.loadSchemaCaptionById(sysSchemaId, next, this);
					}
				},
				function(next, displayValue) {
					const messageTemplate = resources.localizableStrings.HasRunningProcessMessage;
					displayValue = displayValue ? ("\"" + displayValue + "\" ") : "";
					const message = Ext.String.format(messageTemplate, displayValue, runningProcessCount);
					this.showCancelProcessConfirmMessage(message, next, this);
				},
				function(next, shouldCancel) {
					if (shouldCancel) {
						this.cancelExecutionBySchemaId(this, sysSchemaId, next);
					} else {
						this.changeProcessState(sysSchemaId, false, callback, scope);
					}
				},
				function(next, response) {
					if (response && response.success) {
						this.changeProcessState(sysSchemaId, false, callback, scope);
					} else {
						Ext.callback(callback, scope);
					}
				}, this
			);
		},

		/**
		 * Displays a message on the abolition of the running processes.
		 * @param {String} message Message.
		 * @param {Function} callback The callback function.
		 * @param {Object} [scope] The scope of callback function.
		 */
		showCancelProcessConfirmMessage: function(message, callback, scope) {
			BPMSoft.showInformation(message, function(result) {
				callback.call(scope || this, result === "yes");
			}, this, {
				buttons: ["yes", "no"],
				defaultButton: 0
			});
		},

		/**
		 * Activate \ deactivate process.
		 * @param {String} sysSchemaId Unique identifier of the process schema.
		 * @param {Boolean} isActive New value of the parameter "Active" of the process.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		changeProcessState: function(sysSchemaId, isActive, callback, scope) {
			const webServiceName = isActive ? "EnableProcess" : "DisableProcess";
			this.callService({
				serviceName: this.PROCESS_ENGINE_SERVICE_NAME,
				methodName: webServiceName + "?sysSchemaId=" + sysSchemaId,
				timeout: this.REQUEST_TIMEOUT
			}, function(request, success, response) {
				const responseResult = this._getDecodedResponse(response.responseText);
				if (success && responseResult.success) {
					scope.sandbox.publish("ResetStartProcessMenuItems");
				} else {
					this.hideBodyMask();
					BPMSoft.showErrorMessage(responseResult.errorInfo.message);
				}
				Ext.callback(callback, scope);
			}, this);
		},

		/**
		 * Gets running process counter for all schema versions.
		 * @param {String} sysSchemaId Unique identifier of the process schema.
		 * @param {Function} callback The callback function.
		 */
		getRunningProcessVersionsCountBySysSchemaId: function(sysSchemaId, callback) {
			const request = Ext.create("BPMSoft.GetRunningProcessCountByIdRequest", {
				schemaId: sysSchemaId
			});
			request.execute(function(response) {
				Ext.callback(callback, this, [response.success, response.count]);
			}, this);
		},

		/**
		 * Returns the number of running process instances with specified schema identifier.
		 * @param {String} sysSchemaId Unique identifier of the process schema.
		 * @param {Function} callback The callback function.
		 */
		getRunningProcessCountBySysSchemaId: function(sysSchemaId, callback) {
			const request = Ext.create("BPMSoft.GetRunningProcessCountByIdRequest", {
				schemaId: sysSchemaId,
				countSpecifiedVersion: true
			});
			request.execute(function(response) {
				Ext.callback(callback, this, [response.success, response.count]);
			}, this);
		},

		/**
		 * Queries schemas by specified filter.
		 * @param {Object} filter Schemas filter.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		getSchemasByFilter: function(filter, callback, scope) {
			this.callService({
				serviceName: this.PROCESS_SCHEMA_MANAGER_SERVICE_NAME,
				methodName: "GetSchemasByFilter",
				encodeData: true,
				data: Ext.encode(filter)
			}, function(request, success, response) {
				if (success) {
					const schemas = Ext.decode(Ext.decode(response.responseText));
					callback.call(scope || this, schemas);
				}
			}, this);
		},

		/**
		 * Queries actual process schemas by specified filter.
		 * @param {Object} filter Schemas filter.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 * @returns {BPMSoft.ActualProcessSchemasByFilterRequest}
		 */
		getActualProcessSchemasByFilter: function(filter, callback, scope) {
			const request = Ext.create("BPMSoft.ActualProcessSchemasByFilterRequest", {
				packageUId: filter.PackageUId,
				enabledOnly: filter.EnabledOnly,
				excludedSchemas: filter.ExcludedSchemas
			});
			request.execute(function(response) {
				if (response && response.success) {
					const schemas = Ext.decode(response.schemas);
					Ext.callback(callback, scope, [schemas]);
				} else {
					throw new BPMSoft.InvalidOperationException({
						message: response && response.errorInfo && response.errorInfo.toString()
					});
				}
			}, this);
			return request;
		},

		/**
		 * Loads SysSchema display value by UId column value.
		 * @param {String} schemaUId UId column value.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		loadSchemaDisplayValue: function(schemaUId, callback, scope) {
			const esq = this.getSchemaDisplayValueESQ(schemaUId);
			esq.getEntityCollection(function(result) {
				let displayValue, name;
				if (result.success) {
					const schema = result.collection.first();
					if (schema) {
						name = schema.get("Name");
						displayValue = schema.get("Caption");
					}
				} else if (result.errorInfo) {
					const errorMessage = result.errorInfo.message;
					this.log(errorMessage);
				} else {
					displayValue = "";
					name = "";
				}
				Ext.callback(callback, scope, [displayValue, name]);
			});
		},

		/**
		 * Loads SysSchema caption by ID.
		 * @param {String} schemaName Schema name.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		loadSchemaCaptionByName: function(schemaName, callback, scope) {
			const esq = new BPMSoft.EntitySchemaQuery({
				rootSchemaName: "VwSysSchemaInWorkspace",
				clientESQCacheParameters: {
					cacheItemName: schemaName + "-SchemaCaption"
				}
			});
			const currentWorkspace = BPMSoft.SysValue.CURRENT_WORKSPACE.value;
			esq.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_DISPLAY_COLUMN, "Caption");
			esq.filters.addItem(esq.createColumnFilterWithParameter("Name", schemaName));
			esq.filters.addItem(esq.createColumnFilterWithParameter("SysWorkspace", currentWorkspace));
			esq.getEntityCollection(function(result) {
				const schema = result.success && result.collection.first();
				const caption = schema && schema.get("Caption");
				Ext.callback(callback, scope, [caption]);
			}, this);
		},

		/**
		 * Loads SysSchema caption by name.
		 * @param {String} schemaId Schema name.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		loadSchemaCaptionById: function(schemaId, callback, scope) {
			const esq = new BPMSoft.EntitySchemaQuery({
				rootSchemaName: "VwSysSchemaInWorkspace",
				clientESQCacheParameters: {cacheItemName: schemaId + "-SchemaCaption"}
			});
			const currentWorkspace = BPMSoft.SysValue.CURRENT_WORKSPACE.value;
			esq.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_DISPLAY_COLUMN, "Caption");
			esq.filters.addItem(esq.createColumnFilterWithParameter("Id", schemaId));
			esq.filters.addItem(esq.createColumnFilterWithParameter("SysWorkspace", currentWorkspace));
			esq.getEntityCollection(function(result) {
				const schema = result.success && result.collection.first();
				const caption = schema && schema.get("Caption");
				Ext.callback(callback, scope, [caption]);
			}, this);
		},

		/**
		 * Copies process diagram.
		 * @param {Object} config Process data.
		 * @param {String} config.sourceUId Source schema identifier.
		 * @param {String} config.targetName Copied schema name.
		 * @param {String} config.targetCaption Copied schema caption.
		 * @param {String} config.targetPackageUId Copied schema package identifier.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		copyProcess: function(config, callback, scope) {
			this.showBodyMask();
			this.callService({
				serviceName: this.PROCESS_SCHEMA_MANAGER_SERVICE_NAME,
				methodName: "Copy",
				encodeData: true,
				data: Ext.encode(config),
				timeout: this.REQUEST_TIMEOUT
			}, function(request, success, response) {
				this.hideBodyMask();
				if (success) {
					const schemaUId = Ext.decode(response.responseText);
					Ext.callback(callback, scope || this, [schemaUId]);
				}
			}, this);
		},

		/**
		 * Queries copy process schema config.
		 * @param {Object} config Process schema config.
		 * @param {String} config.sourceUId Source schema identifier.
		 * @param {String} config.sourceName Source schema name.
		 * @param {String} config.sourceCaption Source schema caption.
		 * @param {String} [config.targetPackageUId] (optional) Copied schema package identifier.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		getCopyProcessConfig: function(config, callback, scope) {
			this.showBodyMask();
			BPMSoft.SysSettings.querySysSettings([
				"SchemaNamePrefix",
				"CustomPackageUId",
				"CurrentPackageId"
			], function(values) {
				const schemaNamePrefix = values.SchemaNamePrefix;
				const currentPackageId = values.CurrentPackageId && values.CurrentPackageId.value;
				const customPackageId = values.CustomPackageUId && values.CustomPackageUId.value;
				const targetPackageUId = currentPackageId || customPackageId;
				const schemaCaptionPostfix = resources.localizableStrings.CopiedSchemaPostfixCaption;
				let targetName = config.sourceName;
				if (targetName && targetName.indexOf(schemaNamePrefix) !== 0) {
					targetName = schemaNamePrefix + targetName;
				}
				const copyProcessConfig = {
					sourceUId: config.sourceUId,
					targetName: targetName,
					targetCaption: config.sourceCaption + schemaCaptionPostfix,
					targetPackageUId: config.targetPackageUId || targetPackageUId
				};
				this.hideBodyMask();
				Ext.callback(callback, scope || this, [copyProcessConfig]);
			}, this);
		},

		/**
		 * Deletes process schema.
		 * @param {String} schemaUId Schema identifier.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		deleteProcess: function(schemaUId, callback, scope) {
			this.showBodyMask();
			this.callService({
				serviceName: this.PROCESS_SCHEMA_MANAGER_SERVICE_NAME,
				methodName: "Delete?schemaUId=" + schemaUId,
				timeout: this.REQUEST_TIMEOUT
			}, function(request, success, response) {
				this.hideBodyMask();
				if (!success) {
					const errorInfo = response.errorInfo;
					this.log(errorInfo);
				}
				Ext.callback(callback, scope || this, [success, response]);
			}, this);
		},

		/**
		 * Locks process schema from editing by another user.
		 * @param {String} schemaUId Schema identifier.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		GetHasNoForeignLock: function(schemaUId, callback, scope) {
			this.showBodyMask();
			this.callService({
				serviceName: this.SCHEMA_MANAGER_SERVICE_NAME,
				methodName: "CheckHasNoForeignLock?managerName=ProcessSchemaManager&schemaUId=" + schemaUId,
				timeout: this.REQUEST_TIMEOUT
			}, function(request, success, response) {
				this.hideBodyMask();
				if (!success) {
					const errorInfo = response.errorInfo;
					this.log(errorInfo);
				}
				Ext.callback(callback, scope || this, [success, response]);
			}, this);
		},

		/**
		 * Returns invalid elements list for the specified process schema.
		 * @param {Object} config Schema configuration object.
		 * @param {String} config.schemaUId Schema identifier.
		 * @param {String} [config.hostProcessSchemaName] Optional. Host process schema name.
		 * @param {Function} callback The callback function.
		 * @param {Object} callback.response Service response object.
		 * @param {Object} scope The scope of callback function.
		 */
		getInvalidElements: function(config, callback, scope) {
			this.showBodyMask();
			const methodName = this.getIsolatedElementsServiceMethodName(config);
			this.callService({
				serviceName: this.PROCESS_SCHEMA_MANAGER_SERVICE_NAME,
				methodName: methodName,
				timeout: this.REQUEST_TIMEOUT
			}, function(request, success, response) {
				this.hideBodyMask();
				if (!success) {
					const errorInfo = response.errorInfo;
					this.log(errorInfo);
				}
				const responseText = Ext.decode(Ext.decode(response.responseText));
				Ext.callback(callback, scope, [responseText]);
			}, this);
		},
		
		/**
		 * Returns isolated elements list for the specified process schema.
		 * @param {Object} config Schema configuration object.
		 * @param {String} config.schemaUId Schema identifier.
		 * @param {String} [config.hostProcessSchemaName] Optional. Host process schema name.
		 * @param {Function} callback The callback function.
		 * @param {Object} callback.response Service response object.
		 * @param {Object} scope The scope of callback function.
		 */
		getIsolatedElements: function(config, callback, scope) {
			this.showBodyMask();
			const methodName = this.getInvalidElementsServiceMethodName(config);
			this.callService({
				serviceName: this.PROCESS_SCHEMA_MANAGER_SERVICE_NAME,
				methodName: methodName,
				timeout: this.REQUEST_TIMEOUT
			}, function(request, success, response) {
				this.hideBodyMask();
				if (!success) {
					const errorInfo = response.errorInfo;
					this.log(errorInfo);
				}
				const responseText = Ext.decode(Ext.decode(response.responseText));
				Ext.callback(callback, scope, [responseText]);
			}, this);
		},

		/**
		 * Returns process schema instance.
		 * @param {String} sysProcessUId Schema identifier.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		getProcessInstanceByUId: function(sysProcessUId, callback, scope) {
			BPMSoft.chain(
				function(next) {
					BPMSoft.ProcessFlowElementSchemaManager.initialize(next, this);
				},
				function(next) {
					BPMSoft.ProcessSchemaManager.initialize(next, this);
				},
				function() {
					BPMSoft.ProcessSchemaManager.forceGetInstanceByUId(sysProcessUId, callback, scope);
				}, this);
		},

		/**
		 * Returns process schema parent UId.
		 * @param {String} sysProcessUId Schema identifier.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		getProcessSchemaParentUIdByUId: function(sysProcessUId, callback, scope) {
			this.getProcessInstanceByUId(sysProcessUId, function(process) {
				const sourceParentUId = process.parentSchemaUId;
				const isSetParentSchemaUId = BPMSoft.ProcessSchemaManager.getIsSetParentSchemaUId(sourceParentUId);
				const parentUId = isSetParentSchemaUId ? sourceParentUId : sysProcessUId;
				Ext.callback(callback, scope, [parentUId]);
			}, this);
		},

		

		/**
		 * Run the business process with parameters.
		 * @param {Object} config Configuration object.
		 * @param {Object} config.sysProcessUId UId scheme of the business process.
		 * @param {Object} config.parameter Process parameter.
		 * @param {Function} config.callback Callback function.
		 * @param {Object} config.scope Callback scope.
		 */
		runProcessWithParameters: function (config) {
			this._getInfoRunProcessWithParameter(config.sysProcessUId, config.parameter.parameterUId,
				function (processName, parameterName) {
					const parameters = {};
					parameters[parameterName] = config.parameter.parameterValue;
					this.executeProcess({
						sysProcessName: processName,
						parameters: parameters,
						callback: config.callback,
						scope: config.scope
					});
				}
				, this);
		},

		/**
		 * Run the business processes for multiple records.
		 * @param {Object} config Configuration object.
		 * @param {String} config.processSchemaUId Business process schema UId.
		 * @param {String} config.processSchemaCaption Business process schema caption.
		 * @param {Object} config.inputParameterUId Process parameter UId.
		 * @param {Object} config.inputParameterName Process parameter name.
		 * @param {Object} config.selectedRecords Selected records config.
		 * @param {Function} config.callback Callback function.
		 * @param {Object} config.scope Callback scope.
		 */
		runProcessForMultipleRecords: function(config) {
			const selectedRecordsConfig = config.selectedRecords;
			const selectedRecordsCount = selectedRecordsConfig.selectAllMode
				? selectedRecordsConfig.selectAllModeSelectedRecordsCount
				: selectedRecordsConfig.selectedItems && selectedRecordsConfig.selectedItems.length;
			if (Number(selectedRecordsCount) < 1) {
				const message = Ext.String.format(resources.localizableStrings.NoRecordSelectedToRunProcess,
					config.processSchemaCaption);
				BPMSoft.showInformation(message);
				return;
			}
			this.showBodyMask();
			this._checkAllowedToRunProcessesForAllRecords(selectedRecordsConfig, function(allowedToRun) {
				if (allowedToRun) {
					this._runProcessForMultipleRecords(config, selectedRecordsConfig);
				} else {
					this.hideBodyMask();
					Ext.callback(config.callback, config.scope, [false]);
				}
			}, this);
		},

		/**
		 * @private
		 */
		_checkAllowedToRunProcessesForAllRecords: function(selectionConfig, callback, scope) {
			if (!selectionConfig.displayStartConfirmation) {
				Ext.callback(callback, scope, [true]);
				return;
			}
			const message = Ext.String.format(resources.localizableStrings.RunningMultipleProcessesWarning,
				selectionConfig.selectAllModeSelectedRecordsCount);
			BPMSoft.showMessage({
				caption: message,
				scope: this,
				handler: function(result) {
					Ext.callback(callback, scope, [result === "yes"]);
				},
				style: BPMSoft.MessageBoxStyles.ORANGE,
				buttons: ["no", "yes"],
				defaultButton: 0
			});
		},

		/**
		 * @private
		 */
		_runProcessForMultipleRecords: function(config, selectionConfig) {
			const request = selectionConfig.selectAllMode
				? Ext.create("BPMSoft.RunProcessForMatchingRecordsRequest", {
					entitySchemaName: selectionConfig.entitySchemaName,
					filterConfig: selectionConfig.filtersConfig,
					sortingColumns: selectionConfig.sortingColumns,
					primaryColumnValuesToExclude: selectionConfig.unselectedItems
				})
				: Ext.create("BPMSoft.RunProcessForEachValueRequest", {
					values: selectionConfig.selectedItems
				});
			request.schemaUId = config.processSchemaUId;
			request.inputParameterUId = config.inputParameterUId;
			request.inputParameterName = config.inputParameterName;
			request.execute(function() {
				this._showSuccessfullyRunProcessPopup(config.processSchemaCaption);
				this.hideBodyMask();
				Ext.callback(config.callback, config.scope, [true]);
			}, this);
		},

		/**
		 * Determines whether parameter is system or not.
		 * @param {String} parameterName Parameter name.
		 * @return {Boolean}
		 */
		isSystemParameter: function(parameterName) {
			const systemParameters = ["Buttons"];
			return BPMSoft.contains(systemParameters, parameterName);
		},

		/**
		 * Shows process designer by the Id.
		 * @param {String} id Process schema identifier(SysSchema.Id).
		 */
		showProcessSchemaDesignerById: function(id) {
			BPMSoft.ProcessSchemaManager.getSchemaUIdById(id, function(uId) {
				this.showProcessSchemaDesigner(uId);
			}, this);
		},

		/**
		 * Shows dcm designer by the Id.
		 * @param {String} id Dcm schema identifier(SysSchema.Id).
		 */
		showDcmSchemaDesignerById: function(id) {
			BPMSoft.DcmSchemaManager.getSchemaUIdById(id, function(uId) {
				this.showCaseSchemaDesigner({schemaUId: uId});
			}, this);
		},

		/**
		 * Returns the business process list for global start process button.
		 * @param {Function} callback Callback.
		 * @param {Object} scope Callback execution scope.
		 */
		getQuickStartProcessList: function(callback, scope) {
			const esq = this._getQuickRunProcessESQ();
			esq.getEntityCollection(function(result) {
				if (result.success) {
					const processes = [];
					const entities = result.collection;
					if (!entities.isEmpty()) {
						entities.each(function(entity) {
							const id = entity.get("Id");
							const caption = entity.get("Caption");
							processes.push({id: id, caption: caption});
						}, this);
					}
					Ext.callback(callback, scope, [true, processes]);
				} else {
					Ext.callback(callback, scope, [false]);
				}
			}, this);
		},

		/**
		 * Shows the start process page.
		 * @param {Object} sandbox Sandbox instance.
		 * @param {String} caption Page caption.
		 */
		showStartProcessPage: function(sandbox, caption) {
			const schemaName = "VwSysProcess";
			const vwSysProcessFilters = this._getStartProcessPageFilters(schemaName);
			const config = {
				entitySchemaName: schemaName,
				isRunProcessPage: true,
				captionLookup: caption,
				multiSelect: false,
				columnName: "Caption",
				filters: vwSysProcessFilters,
				hideActions: true
			};
			const handler = function(args) {
				const activeItems = args.selectedRows.getItems();
				if (!Ext.isEmpty(activeItems)) {
					BPMSoft.ProcessModuleUtilities.executeProcess({
						sysProcessId: activeItems[0].Id
					});
				}
			};
			LookupUtilities.Open(sandbox, config, handler, this, null, false, false);
		},

		/**
		 * Returns diff for the ExecutionDetails button.
		 * @param {Object} openPageCallback Handler for ShowTaskDetailsButton.
		 */
		getTaskExecutionDetailsButtonDiff: function(openPageCallback) {
			return {
				operation: "insert",
				name: "TaskDetailsButtonContainer",
				parentName: "ActionButtonsContainer",
				propertyName: "items",
				values: {
					itemType: BPMSoft.ViewItemType.CONTAINER,
					wrapClass: ["right-container-wrapClass"],
					items: [
						{
							name: "ShowTaskDetailsButton",
							itemType: BPMSoft.ViewItemType.BUTTON,
							style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							caption: resources.localizableStrings.TaskDetailsButtonCaption,
							classes: {
								textClass: ["show-task-details-button"]
							},
							onClick: openPageCallback
						}
					]
				}
			};
		},

		/**
		 * Executes process element by it's unique identifier.
		 * @param {String} processElementUId Process element unique identifier.
		 * @param {Function} callback Callback.
		 * @param {Object} scope Callback execution scope.
		 */
		executeProcessElementByUId: function(processElementUId, callback, scope) {
			const request = Ext.create("BPMSoft.ExecuteProcessElementRequest", {
				processElementUId: processElementUId
			});
			request.execute(function(response) {
				const pageOpened = Boolean(response.executionData);
				Ext.callback(callback, scope, [response.success, pageOpened]);
			}, this);
		}

		// endregion

	});

	return BPMSoft.ProcessModuleUtilities;

});
