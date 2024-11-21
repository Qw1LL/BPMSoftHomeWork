define("BaseWidgetViewModelClass", ["ext-base", "BPMSoft", "BaseWidgetViewModelClassResources"],
	function(Ext, BPMSoft) {

	/**
	 * ####### ##### ###### ############# ######### ############
	 * ### ############# ###### ########## ################ # ###### ##### #########:
	 *	1.	GetHistoryState (publish; ptp)
	 *	2.	ReplaceHistoryState (publish; broadcast)
	 *	3.	HistoryStateChanged (subscribe; broadcast)
	 *	4.	GetWidgetParameters (subscribe; ptp)
	 * #### ############ ######### ########## ## ####### (useCustomParameterMethods = true)
	 *	1.	PushWidgetParameters (subscribe; ptp)
	 */
	Ext.define("BPMSoft.model.BaseWidgetViewModel", {
		extend: "BPMSoft.model.BaseViewModel",
		alternateClassName: "BPMSoft.BaseWidgetViewModel",

		sandbox: null,
		BPMSoft: null,
		Ext: null,

		/**
		 * ### ######## ############ #########
		 * @protected
		 * @type {String}
		 */
		code: null,

		/**
		 * ###### ######### ##########
		 * @protected
		 * @type {Array}
		 */
		availableParameters: [],

		/**
		 * ####, ########### ## ##, ### ###### ##### ############## #########
		 * @protected
		 * @type {Boolean}
		 */
		useCustomParameterMethods: true,

		/**
		 * ###### ########## ######## ############ #########
		 * @protected
		 * @type {Array}
		 */
		parameters: null,

		/**
		 * ######### #############
		 */
		initialize: function() {
			var sandbox = this.sandbox;
			if (!sandbox) {
				return;
			}
			var scope = this;
			var availableParameters = this.availableParameters;
			BPMSoft.each(["procElUId", "IsVisible"], function(parameterName) {
				if (availableParameters.indexOf(parameterName) < 0) {
					availableParameters.splice(0, 0, parameterName);
				}
			}, this);
			sandbox.subscribe("HistoryStateChanged", function() {
				scope.onHistoryStateChanged.call(scope);
			});
			sandbox.subscribe("GetWidgetParameters", function() {
				return BPMSoft.deepClone(scope.parameters);
			}, [this.code]);
			if (this.useCustomParameterMethods) {
				sandbox.subscribe("PushWidgetParameters", function(parametersToApply) {
					scope.applyParameters.call(scope, parametersToApply);
				}, [this.code]);
			}
			this.initParametersFromHistoryState();
		},

		/**
		 * ########## ####### ######### ######### #######
		 * @private
		 */
		onHistoryStateChanged: function() {
			var historyState = this.sandbox.publish("GetHistoryState");
			this.applyParameters(this.getParametersFromHistoryState(historyState));
		},

		/**
		 * ################ ######### ######, ########## ## ####### #########
		 * @private
		 */
		initParametersFromHistoryState: function() {
			var historyState = this.sandbox.publish("GetHistoryState");
			if (this.getIsProcessMode(historyState)) {
				this.parameters = this.getParametersFromHistoryState(historyState);
				this.updateParameters();
			}
		},

		/**
		 * ##########, # ##### ###### ############ ######
		 * @protected
		 */
		getIsProcessMode: function(historyState) {
			var hashPath = historyState.hash.historyState;
			return !Ext.isEmpty(hashPath.match("ProcessCardModuleV2/?"));
		},

		/**
		 * ########## ######, ######## ######## ######## ########### ## #########
		 * @protected
		 */
		getDefaultParameters: function() {
			return {
				IsVisible: false
			};
		},

		/**
		 * ######### #########, ######## ######## ######## ########### ## #########
		 * @protected
		 */
		applyParameters: function(parametersToApply) {
			var currentParameters = this.getDefaultParameters();
			Ext.apply(currentParameters, parametersToApply || {});
			var historyState = this.sandbox.publish("GetHistoryState");
			var isProcessMode = this.getIsProcessMode(historyState);
			if (isProcessMode && !currentParameters.procElUId) {
				return;
			}
			this.parameters = currentParameters;
			this.updateParameters();
			this.setParametersToHistoryState(historyState);
			this.updateWidget();
		},

		/**
		 * ############# ######### # ######### #######
		 * @private
		 */
		setParametersToHistoryState: function(historyState) {
			if (!historyState || !historyState.state) {
				return null;
			}
			var executionData = historyState.state.executionData;
			if (!executionData || !executionData.currentProcElUId) {
				return null;
			}
			var currentProcessData = executionData[executionData.currentProcElUId];
			if (!currentProcessData) {
				return null;
			}
			currentProcessData[this.code] = BPMSoft.deepClone(this.parameters);
			if (historyState.hash) {
				this.sandbox.publish("ReplaceHistoryState", {
					stateObj: historyState.state,
					hash: historyState.hash.historyState,
					silent: true
				});
			}
		},

		/**
		 * ######### ######### # ######
		 * @private
		 */
		updateParameters: function() {
			var parameters = this.parameters || {};
			BPMSoft.each(this.availableParameters, function(parameterName) {
				this.set(parameterName, parameters[parameterName]);
			}, this);
		},

		updateWidget: function() {
		},

		/**
		 * ######## ######### ## ######### #######
		 * @private
		 */
		getParametersFromHistoryState: function(historyState) {
			if (!historyState || !historyState.state) {
				return null;
			}
			var executionData = historyState.state.executionData;
			if (!executionData || !executionData.currentProcElUId) {
				return null;
			}
			var currentProcessData = executionData[executionData.currentProcElUId];
			if (!currentProcessData) {
				return null;
			}
			var currentParameters = currentProcessData[this.code];
			if (currentParameters) {
				currentParameters.procElUId = currentProcessData.procElUId;
			}
			return currentParameters || null;
		}

	});
});
