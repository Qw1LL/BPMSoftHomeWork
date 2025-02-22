﻿define('BaseProcessViewModelClass', ['ext-base', 'BPMSoft', 'BaseProcessViewModelClassResources', 'ProcessHelper',
	'MaskHelper'],
	function(Ext, BPMSoft, resources, ProcessHelper, MaskHelper) {

		/**
		 * ####### ##### ### ###### ############# ################ # ############### ####### ## ########
		 * ########### ##### # ##### ######## ### mixin, ########:
		 * mixins: {
		 * 	BaseProcessViewModel: "BPMSoft.BaseProcessViewModelClass"
		 * },
		 * 	1.	GetProcessExecData (public; ptp)
		 * 	2.  ProcessExecDataChanged (public; ptp)
		 */

		Ext.define('BPMSoft.configuration.mixins.BaseProcessViewModelClass', {
			extend: "BPMSoft.BaseObject",
			alternateClassName: 'BPMSoft.BaseProcessViewModelClass',

			/**
			 * ###### ## ######## ########
			 * ######: {
			 *  procElUId = {Guid},
			 *  name = {string},
			 *  processId = {Guid},
			 *  isProcessExecutedBySignal = {bool},
			 *  processName = {Guid},
			 *  recommendation = {string},
			 *  nextProcElUId = {string},
			 *  urlToken = {string},
			 *  recordId = {Guid},
			 *  entitySchemaName = {String},
			 *  parameters = {Object}
			 *	}
			 **/

			processParameters: [],

			acceptProcessElement: function(code) {
				this.saveProcessParameters();
				this.completeExecution(code);
			},

			cancelProcessElement: function(code) {
				this.completeExecution(code);
			},

			saveProcessParameters: function() {
				var processData = this.get("ProcessData");
				var parameters = this.processParameters = [];
				if (Ext.isEmpty(processData)) {
					return;
				}
				BPMSoft.each(processData.parameters, function(oldValue, name) {
					var value = BPMSoft.deepClone(this.get(name));
					if (Ext.isDate(value)) {
						value = BPMSoft.encodeDate(value);
					} else if (this.columns) {
						var column = this.columns[name];
						if (column) {
							value = ProcessHelper.getServerValueByDataValueType(value, column.dataValueType);
						}
					}
					parameters.push({
						key: name,
						value: (!Ext.isEmpty(value) && !Ext.isEmpty(value.value)) ? value.value : value
					});
				}, this);
			},

			completeExecution: function(code) {
				if (!Ext.isEmpty(code)) {
					this.processParameters.push({
						key: 'PressedButtonCode',
						value: code
					});
				}
				var dataSend = {
					procElUId: this.get("ProcessData").procElUId,
					parameters: this.processParameters
				};
				MaskHelper.ShowBodyMask();
				this.callServiceMethod('ProcessEngineService', 'CompleteExecution',
					this.onCompleteExecution, dataSend);
			},

			onCompleteExecution: function(response) {
				MaskHelper.HideBodyMask();
				if (response <= 0) {
					BPMSoft.Router.back();
				}
			},

			processElementChanged: function() {
				if (Ext.isEmpty(this.get("ProcessData"))) {
					return;
				}
				ProcessHelper.processElementChanged(
					this.processData.procElUId,
					this.processData.recordId,
					this.sandbox,
					this.processElementChangedCallback,
					this);
			},

			processElementChangedCallback: function(procElUId) {
				//	Todo: ####### ########## ######### ### ###### ######## ## ########
			},

			callServiceMethod: function(serviceName, methodName, callback, dataSend, timeout) {
				var timeout = timeout || (2 * 60 * 1000);
				var data = dataSend || {};
				var ajaxProvider = BPMSoft.AjaxProvider;
				var workspaceBaseUrl = BPMSoft.utils.uri.getConfigurationWebServiceBaseUrl();
				var requestUrl = workspaceBaseUrl + '/rest/' + serviceName + '/' + methodName;
				var request = ajaxProvider.request({
					url: requestUrl,
					headers: {
						'Accept': 'application/json',
						'Content-Type': 'application/json'
					},
					method: 'POST',
					jsonData: data,
					callback: function(request, success, response) {
						var responseObject = {};
						if (success) {
							responseObject = BPMSoft.decode(response.responseText);
						}
						callback.call(this, responseObject[methodName + 'Result']);
					},
					scope: this,
					timeout: timeout
				});
				return request;
			}

		});
	});
