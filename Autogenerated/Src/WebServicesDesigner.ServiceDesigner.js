define("WebServicesDesigner", ["ext-base", "BPMSoft", "BaseViewModule", "css!WebServicesDesigner"], function(Ext, BPMSoft) {
	return Ext.define("BPMSoft.configuration.WebServicesDesigner", {
		extend: "BPMSoft.BaseViewModule",
		alternateClassName: "BPMSoft.WebServicesDesigner",
		/**
		 * @private
		 */
		_wrapClassName: "web-services",
		/**
		 * @private
		 */
		_cardModuleV2Name: 'CardModuleV2',
		/**
		 * @param {String} hash Hash
		 * @return {String}
		 * @private
		 */
		_parseHash: function(hash) {
			const params = hash.split("/");
			const operation = params[0];
			if (operation === this._cardModuleV2Name) {
				return hash;
			}
			if (operation === 'edit') {
				return this._prepareEditParameters(params[1]);
			}
			return this._prepareAddParameters(params[1], params[3]);
		},

		/**
		 * @param {String} type
		 * @param {String} packageUId
		 * @returns {String}
		 * @private
		 */
		_prepareAddParameters: function(type, packageUId) {
			return Ext.String.format("{0}/{1}WebServiceV2Page/add/packageUId/{2}", this._cardModuleV2Name, type, packageUId);
		},
		/**
		 * @param {String} schemaId
		 * @returns {String}
		 * @private
		 */
		_prepareEditParameters: function(schemaId) {
			return Ext.String.format("{0}/WebServiceV2Page/edit/{1}", this._cardModuleV2Name, schemaId);
		},
		/**
		 * @inheritdoc BPMSoft.BaseViewModule#render
		 * @overridden
		 */
		render: function(renderTo) {
			const mainContentWrapper = Ext.get("mainContentWrapper");
			mainContentWrapper.addCls(this._wrapClassName);
			this.renderTo = renderTo;
			this.callParent(arguments);
		},
		/**
		 * @inheritdoc BPMSoft.BaseViewModule#loadMainPanelsModules
		 * @overridden
		 */
		loadMainPanelsModules: function() {
			const sandbox = this.sandbox;
			const state = sandbox.publish("GetHistoryState");
			const hashFromHistoryState = state.hash.historyState;
			const newHash = this._parseHash(hashFromHistoryState) ;
			sandbox.publish("ReplaceHistoryState", {hash: newHash});
		},
		/**
		 * @inheritdoc BPMSoft.BaseViewModule#getMessages
		 * @overridden
		 * @returns {*}
		 */
		getMessages: function() {
			const parentMessages = this.callParent(arguments) || {};
			return this.Ext.apply(parentMessages, {
				"LoadModule": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				"HistoryStateChanged": {
					mode: BPMSoft.MessageMode.BROADCAST,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				"RefreshCacheHash": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				"NavigationModuleLoaded": {
					mode: BPMSoft.MessageMode.BROADCAST,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				"GetHistoryState": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				"ReplaceHistoryState": {
					mode: BPMSoft.MessageMode.BROADCAST,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			});
		},
	});
 });
