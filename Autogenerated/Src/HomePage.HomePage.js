define("HomePage", ["MaskHelper", "BaseSchemaViewModule", "SchemaViewComponent", "css!HomePage","ContextHelpMixin"], function (MaskHelper) {
	Ext.define("BPMSoft.configuration.HomePage", {
		alternateClassName: "BPMSoft.HomePage",
		extend: "BPMSoft.BaseSchemaViewModule",
		mixins: {
			ContextHelpMixin: "BPMSoft.ContextHelpMixin"
		},

		/**
		 * @private
		 */
		_renderTo: null,

		/**
		 * @protected
		 */
		componentSelector: "crt-home-page-component",

		/**
		 * @protected
		 */
		componentWrapSelector: "home-page",

		/**
		 * @private
		 */
		_getHomePageSchemaName() {
			const historyState = this.sandbox.publish("GetHistoryState");
			return historyState?.hash.entityName;
		},

		/**
		 * @private
		 */
		_getReloadActionTag: function() {
			return "_UpdateSection";
		},

		/**
		 * @private
		 */
		_initReloadAction: function() {
			this.sandbox.subscribe("UpdateSection", this.reloadPage, this, [this._getReloadActionTag()]);
		},

		/**
		 * @private
		 */
		_getSchemaCaption: function(callback, scope) {
			const homePageSchemaName = this._getHomePageSchemaName();
			const request = this._getHomePageEsq(homePageSchemaName);
			request.execute((response) => {
				const item = response.collection.first();
				callback.call(scope || this, item.get("Caption"));
			});
		},

		/**
		 * @private
		 */
		_getHomePageEsq: function(name) {
			const esqAngularHomePages = new BPMSoft.EntitySchemaQuery({
				rootSchemaName: "SysSchema",
				isDistinct: true
			});
			esqAngularHomePages.addColumn(
				"=[VwSysSchemaExtending:BaseSchemaId:Id].[SysSchema:Id:TopExtendingSchemaId].Caption", "Caption");
			esqAngularHomePages.addParameterColumn(true, BPMSoft.DataValueType.BOOLEAN,
				"isHomePage");
			const filterName = BPMSoft.createColumnFilterWithParameter("Name", name);
			esqAngularHomePages.filters.add("SchemaPropertyNameFilter", filterName);
			return esqAngularHomePages;
		},

		/**
		 * @inheritDoc BPMSoft.BaseSchemaViewModule#init
		 * @protected
		 */
		init: function() {
			this.callParent(arguments);
			const historyState = this.sandbox.publish("GetHistoryState");
			const {hash} = historyState;
			this.sandbox.publish("SelectedSideBarItemChanged", hash.historyState, ["sectionMenuModule"]);
			this._getSchemaCaption((caption) => {
				const headerConfig = {
					isMainMenu: false,
					isLogoVisible: true,
					isCaptionVisible: true,
					isContextHelpVisible: true,
					caption
				};
				this.sandbox.publish("InitDataViews", headerConfig);
				this._initReloadAction();
				this.sandbox.subscribe("NeedHeaderCaption", function () {
					this.sandbox.publish("InitDataViews", headerConfig);
					this.sandbox.publish("SelectedSideBarItemChanged", hash.historyState, ["sectionMenuModule"]);
				}, this);
			});
		},

		/**
		 * @inheritDoc BPMSoft.BaseSchemaViewModule#getMessages
		 * @protected
		 */
		getMessages: function() {
			const message = this.callParent(arguments);
			return Ext.apply(message, {
				"SelectedSideBarItemChanged": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},
				"NeedHeaderCaption": {
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE,
					mode: this.BPMSoft.MessageMode.BROADCAST
				},
				"InitContextHelp": {
					direction: this.BPMSoft.MessageDirectionType.PUBLISH,
					mode: this.BPMSoft.MessageMode.PTP
				},
				"UpdateSection": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			});
		},

		/**
		 * @inheritDoc BPMSoft.BaseSchemaViewModule#initSchemaName
		 * @protected
		 */
		initSchemaName: function() {
			this.schemaName = this._getHomePageSchemaName();
		},

		/**
		 * @inheritDoc BPMSoft.core.BaseObject#onDestroy
		 * @overridden
		 */
		destroy: function(config) {
			this.callParent(arguments);
			this.sandbox.unsubscribePtp("UpdateSection", [this._getReloadActionTag()]);
		}
	});
	return BPMSoft.HomePage;
});
