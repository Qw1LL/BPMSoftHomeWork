define("SectionSchemaViewModule", ["BaseSchemaViewModule"], function() {
	Ext.define("BPMSoft.configuration.SectionSchemaViewModule", {
		alternateClassName: "BPMSoft.SectionSchemaViewModule",
		extend: "BPMSoft.BaseSchemaViewModule",

		// region Fields: Protected

		/**
		 * @protected
		 */
		componentSelector: "crt-section-component",

		/**
		 * @protected
		 */
		componentWrapSelector: "crt-section",

		// endregion

		// region Method: Private

		/**
		 * @private
		 */
		_initReloadAction: function() {
			this.sandbox.subscribe("UpdateSection", this.reloadPage, this, [this._getReloadActionTag()]);
		},

		/**
		 * @private
		 */
		_getReloadActionTag: function() {
			return this.schemaName + "_UpdateSection";
		},

		/**
		 * @private
		 */
		_getSchemaCaption: function(entitySchemaName) {
			return BPMSoft.configuration.ModuleStructure[entitySchemaName]?.moduleCaption;
		},

		// endregion

		// region Method: Protected

		/**
		 * @inheritDoc BPMSoft.BaseSchemaViewModule#init
		 * @overridden
		 */
		init: function(callback, scope) {
			this.callParent([
				() => {
					const historyState = this.sandbox.publish("GetHistoryState");
					const {hash} = historyState;
					this.sandbox.publish("SelectedSideBarItemChanged", hash.historyState, ["sectionMenuModule"]);
					this._initReloadAction();
					Ext.callback(callback, scope);
				}
			]);
		},

		/**
		 * @inheritDoc BPMSoft.BaseSchemaViewModule#onInitDataView
		 * @overridden
		 * @returns {Promise}
		 */
		onInitDataView: async function({$initialEvent}) {
			const {entityName} = $initialEvent;
			const {hash} = this.sandbox.publish("GetHistoryState");
			const caption = this._getSchemaCaption(entityName);
			this.headerCaption = caption;
			const headerConfig = {
				isMainMenu: false,
				isLogoVisible: true,
				isCaptionVisible: true,
				isContextHelpVisible: true,
				hidePageCaption: true,
				caption,
				moduleName: this.schemaName
			};
			this.sandbox.publish("InitDataViews", headerConfig);
			this.sandbox.subscribe("NeedHeaderCaption", function () {
				this.sandbox.publish("InitDataViews", headerConfig);
				this.sandbox.publish("SelectedSideBarItemChanged", hash.historyState, ["sectionMenuModule"]);
			}, this);
		},

		/**
		 * @inheritDoc BPMSoft.BaseSchemaViewModule#getMessages
		 * @overridden
		 */
		getMessages: function() {
			const config = this.callParent(arguments);
			const messages = {
				"NeedHeaderCaption": {
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE,
					mode: this.BPMSoft.MessageMode.BROADCAST
				},
				"UpdateSection": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				"SelectedSideBarItemChanged": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				}
			};
			return Ext.apply(config, messages);
		},

		/**
		 * @inheritDoc BPMSoft.BaseSchemaViewModule#initSchemaName
		 * @protected
		 */
		initSchemaName: function() {
			const historyState = this.sandbox.publish("GetHistoryState");
			const hash = historyState.hash;
			const state = historyState.state;
			this.schemaName = state.cardSchemaName || hash.entityName || "";
		},

		/**
		 * @inheritDoc BPMSoft.core.BaseObject#onDestroy
		 * @overridden
		 */
		destroy: function() {
			this.callParent(arguments);
			this.sandbox.unsubscribePtp("UpdateSection", [this._getReloadActionTag()]);
		}

		// endregion

	});
	return BPMSoft.SectionSchemaViewModule;
});
