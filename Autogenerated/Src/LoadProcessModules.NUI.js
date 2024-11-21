define('LoadProcessModules', ['ext-base', 'BPMSoft', 'ProcessModuleUtilities'],
	function(Ext, BPMSoft, ProcessModuleUtilities) {


		return {

			loadProcessModules: function loadProcessModules(sandbox, isProcessMode) {
				if (isProcessMode === false) {
					return;
				}
				sandbox.subscribe('GetCardModuleSandboxId', function() {
					return sandbox.id;
				});
				const processExecData = sandbox.publish('GetProcessExecData');
				const processExecDataCollection = sandbox.publish('GetProcessExecDataCollection');
				if (Ext.isEmpty(processExecData)) {
					return;
				}
				if (processExecDataCollection &&
						ProcessModuleUtilities.getProcExecDataCollectionCount(processExecDataCollection) > 1 ) {
					const remindContainer = Ext.get('process-reminder');
					sandbox.loadModule('ProcessRemindModule', {
						renderTo: remindContainer
					});
				}
				const entitySchemaName = processExecData.entitySchemaName;
				if ((entitySchemaName && entitySchemaName !== 'Activity') || processExecData.userQuestion) {
					const recommendationContainer = Ext.get('usertask-recommendation');
					sandbox.loadModule('RecommendationModule', {
						renderTo: recommendationContainer
					});
				}
				const processExecContextContainer = Ext.get('processExecutionContextContainer');
				sandbox.loadModule('ProcessExecutionContextModule', {
					renderTo: processExecContextContainer
				});
			},

			isDelayExecutionButtonVisible: function isDelayExecutionButtonVisible(sandbox, isProcessMode) {
				if (isProcessMode === true) {
					const processExecData = sandbox.publish('GetProcessExecData');
					if (processExecData && (processExecData.entitySchemaName !== 'Activity')) {
						return true;
					}
				}
				return false;
			}

		};
	});
