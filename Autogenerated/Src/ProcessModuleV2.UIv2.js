define("ProcessModuleV2", ["ext-base", "BPMSoft", "sandbox"],
	function(Ext, BPMSoft, sandbox) {

		var injectedExt = Ext;
		var injectedBPMSoft = BPMSoft;
		var injectedSandbox = sandbox;

		function initContext(callback, scope) {
			if (injectedSandbox && !Ext.isFunction(injectedSandbox)) {
				if (callback) {
					callback.call(scope);
				}
				return;
			}
			var core = require("core-base");
			var id = "ProcessModuleV2_injected";
			core.createContext("ProcessModuleV2", {"id": id, "moduleName": "ProcessModuleV2"});
			injectedExt = require(["ext_" + id, "BPMSoft_" + id, "sandbox_" + id], function(Ext, BPMSoft, sandbox) {
				injectedExt = Ext;
				injectedBPMSoft = BPMSoft;
				injectedSandbox = sandbox;
				if (callback) {
					callback.call(scope);
				}
			});
		}

		/**
		 * @deprecated
		 */
		function init() {
			window.console.log(Ext.String.format(BPMSoft.Resources.ObsoleteMessages.ObsoleteModule,
				"ProcessModuleV2", "ProcessListenerV2"));
			initContext(function() {
				injectedSandbox.loadModule("ProcessListenerV2");
			}, this);
		}

		/**
		 * @deprecated
		 */
		function replaceHistoryState(currentState, newState) {
			window.console.log(Ext.String.format(BPMSoft.Resources.ObsoleteMessages.ObsoleteMethodMessage,
				"replaceHistoryState", "sandbox.publish(\"ReplaceHistoryState\",...}"));
			initContext(function() {
				injectedSandbox.publish("ReplaceHistoryState", {
					stateObj: newState,
					pageTitle: null,
					hash: currentState.hash.historyState,
					silent: true
				});
			}, this);
		}

		/**
		 * @deprecated
		 */
		function changeNextProcExecDataHistoryState(nextProcessExecData) {
			window.console.log(Ext.String.format(BPMSoft.Resources.ObsoleteMessages.ObsoleteMethodMessage,
				"changeNextProcExecDataHistoryState",
				"sandbox.publish(\"ChangeNextProcExecDataHistoryState\",...}"));
			initContext(function() {
				injectedSandbox.publish("ChangeNextProcExecDataHistoryState", nextProcessExecData);
			}, this);
		}

		/**
		 * @deprecated
		 */
		function changeCurrentProcExecItemInHistoryState(processExecDataItem) {
			window.console.log(Ext.String.format(BPMSoft.Resources.ObsoleteMessages.ObsoleteMethodMessage,
				"changeCurrentProcExecItemInHistoryState",
				"sandbox.publish(\"ChangeCurrentProcExecItemInHistoryState\",...}"));
			initContext(function() {
				injectedSandbox.publish("ChangeCurrentProcExecItemInHistoryState", processExecDataItem);
			}, this);
		}

		/**
		 * @deprecated
		 */
		function onCardModuleSaved(config) {
			window.console.log(Ext.String.format(BPMSoft.Resources.ObsoleteMessages.ObsoleteMethodMessage,
				"onCardModuleSaved",
				"sandbox.publish(\"OnCardModuleSaved\",...}"));
			return injectedSandbox.publish("OnCardModuleSaved", config);
		}

		/**
		 * @deprecated
		 */
		function postponeProcessExecution() {
			window.console.log(Ext.String.format(BPMSoft.Resources.ObsoleteMessages.ObsoleteMethodMessage,
				"postponeProcessExecution",
				"sandbox.publish(\"PostponeProcessExecution\",...}"));
			initContext(function() {
				injectedSandbox.publish("PostponeProcessExecution");
			}, this);
		}

		/**
		 * @deprecated
		 */
		function completeExecution(scope, procElUId, params, callback) {
			window.console.log(Ext.String.format(BPMSoft.Resources.ObsoleteMessages.ObsoleteMethodMessage,
				"completeExecution",
				"sandbox.publish(\"CompleteProcessExecution\",...}"));
			initContext(function() {
				var tag = injectedSandbox.id + BPMSoft.generateGUID();
				if (callback) {
					injectedSandbox.subscribe("ProcessExecutionCompleted", function(result) {
						callback.call(scope, result.success, result.completeExecutionData);
					}, this, [tag]);
				}
				injectedSandbox.publish("CompleteProcessExecution", {
					params: params,
					procElUId: procElUId,
					resultMessageTags: [tag]
				});
			}, this);
		}

		/**
		 * @deprecated
		 */
		function cancelExecution(scope, data, callback) {
			window.console.log(Ext.String.format(BPMSoft.Resources.ObsoleteMessages.ObsoleteMethodMessage,
				"cancelExecution",
				"sandbox.publish(\"CancelProcessExecution\",...}"));
			initContext(function() {
				var tag = injectedSandbox.id + BPMSoft.generateGUID();
				if (callback) {
					injectedSandbox.subscribe("ProcessExecutionCanceled", function(result) {
						callback.call(scope, result.request, result.success, result.response);
					}, this, [tag]);
				}
				injectedSandbox.publish("CancelProcessExecution", {
					data: data,
					resultMessageTags: [tag]
				});
			}, this);
		}

		/**
		 * @deprecated
		 */
		function callConfigurationServiceMethod(serviceMethodName, dataSend, callback, scope) {
			window.console.log(Ext.String.format(BPMSoft.Resources.ObsoleteMessages.ObsoleteMethodMessage,
				"callConfigurationServiceMethod",
				"sandbox.publish(\"CallProcessServiceMethod\",...}"));
			initContext(function() {
				var tag = injectedSandbox.id + BPMSoft.generateGUID();
				if (callback) {
					injectedSandbox.subscribe("ProcessServiceMethodCalled", function(responseObject) {
						callback.call(scope || this, responseObject);
					}, this, [tag]);
				}
				injectedSandbox.publish("CallProcessServiceMethod", {
					serviceMethodName: serviceMethodName,
					data: dataSend,
					resultMessageTags: [tag]
				});
			}, this);
		}

		initContext();

		return {
			init: init,
			replaceHistoryState: replaceHistoryState,
			changeNextProcExecDataHistoryState: changeNextProcExecDataHistoryState,
			changeCurrentProcExecItemInHistoryState: changeCurrentProcExecItemInHistoryState,
			onCardModuleSaved: onCardModuleSaved,
			services: {
				completeExecution: completeExecution,
				cancelExecution: cancelExecution,
				callConfigurationServiceMethod: callConfigurationServiceMethod
			},
			postponeProcessExecution: postponeProcessExecution
		};
	});
