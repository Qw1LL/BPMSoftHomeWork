define("WordPrintablePageLoader", ["ext-base", "BPMSoft", "BaseViewModule", "AngularPostMessageConnector",
	"WordPrintableConverter", "css!CommonCSSV2", "css!WordPrintablePageLoader"
], function() {

	Ext.define("BPMSoft.configuration.WordPrintablePageLoader", {
		extend: "BPMSoft.BaseViewModule",
		alternateClassName: "BPMSoft.WordPrintablePageLoader",

		// region Fields: Public

		Ext: null,
		sandbox: null,
		BPMSoft: null,
		isAsync: true,
		renderTo: "",
		messageChannel: null,
		cardState: null,
		sysModuleReport: null,

		//endregion

		// region Constructors: Public

		/**
		 * @inheritDoc BPMSoft.BaseObject#constructor.
		 * @override
		 */
		constructor: function() {
			this.callParent(arguments);
			this._registerMessages();
			this.messageChannel = Ext.create('BPMSoft.AngularPostMessageConnector', {
				channelName: "word-printable",
				target: window.parent
			});
		},

		// endregion

		// region Methods: Private

		/**
		 * @return {Object}
		 * @private
		 */
		_getMessages: function() {
			return {
				"LoadModule": {
					"direction": BPMSoft.MessageDirectionType.SUBSCRIBE,
					"mode": BPMSoft.MessageMode.PTP
				},
				"RefreshCacheHash": {
					"direction": BPMSoft.MessageDirectionType.SUBSCRIBE,
					"mode": BPMSoft.MessageMode.PTP
				},
				"NavigationModuleLoaded": {
					"direction": BPMSoft.MessageDirectionType.SUBSCRIBE,
					"mode": BPMSoft.MessageMode.BROADCAST
				},
				"HistoryStateChanged": {
					"direction": BPMSoft.MessageDirectionType.SUBSCRIBE,
					"mode": BPMSoft.MessageMode.BROADCAST
				},
				"GetHistoryState": {
					"direction": BPMSoft.MessageDirectionType.PUBLISH,
					"mode": BPMSoft.MessageMode.PTP
				},
				"PushHistoryState": {
					"direction": BPMSoft.MessageDirectionType.PUBLISH,
					"mode": BPMSoft.MessageMode.BROADCAST
				},
				"RequestSysModuleReport": {
					"direction": BPMSoft.MessageDirectionType.SUBSCRIBE,
					"mode": BPMSoft.MessageMode.PTP
				},
				"RequestSysModuleReportDiscard": {
					"direction": BPMSoft.MessageDirectionType.SUBSCRIBE,
					"mode": BPMSoft.MessageMode.PTP
				},
				"ReturnSysModuleReportDiscardResult": {
					"direction": BPMSoft.MessageDirectionType.PUBLISH,
					"mode": BPMSoft.MessageMode.PTP
				},
				"ReturnSysModuleReport": {
					"direction": BPMSoft.MessageDirectionType.PUBLISH,
					"mode": BPMSoft.MessageMode.PTP
				},
				"RequestSysModuleReportSave": {
					"direction": BPMSoft.MessageDirectionType.SUBSCRIBE,
					"mode": BPMSoft.MessageMode.PTP
				},
				"ReturnSysModuleReportSaveResult": {
					"direction": BPMSoft.MessageDirectionType.PUBLISH,
					"mode": BPMSoft.MessageMode.PTP
				},
				"RequestClosePage": {
					"mode": BPMSoft.MessageMode.PTP,
					"direction": BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				"ChangeCardState": {
					"mode": BPMSoft.MessageMode.PTP,
					"direction": BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				"RequestCopyData": {
					"direction": BPMSoft.MessageDirectionType.SUBSCRIBE,
					"mode": BPMSoft.MessageMode.PTP
				},
				"ReturnCopyData": {
					"direction": BPMSoft.MessageDirectionType.PUBLISH,
					"mode": BPMSoft.MessageMode.PTP
				},
			};
		},

		/**
		 * @private
		 */
		_registerMessages: function() {
			const messages = this._getMessages();
			this.sandbox.registerMessages(messages);
		},

		/**
		 * @private
		 */
		_unRegisterMessages: function() {
			const messages = this._getMessages();
			this.sandbox.unRegisterMessages(messages);
		},

		// endregion

		// region Methods: Protected

		/**
		 * @inheritDoc BPMSoft.BaseViewModule#initHomePage
		 * @overridden
		 */
		initHomePage: function(callback, scope) {
			Ext.callback(callback, scope);
		},

		/**
		 * @inheritDoc BPMSoft.BaseViewModule#loadMainPanelsModules
		 * @overridden
		 */
		loadMainPanelsModules: BPMSoft.emptyFn,

		/**
		 * @inheritDoc BPMSoft.BaseObject#onDestroy
		 * @overridden
		 */
		onDestroy: function() {
			this._unRegisterMessages();
			this.callParent(arguments);
		},

		// endregion

		// region Methods: Public

		/**
		 * Initializes module.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback.
		 */
		init: function(callback, scope) {
			this.callParent([function() {
				this.messageChannel.connect(function(result) {
					if (result === false) {
						throw Ext.create("BPMSoft.InvalidOperationException");
					}
					const converter = BPMSoft.WordPrintableConverter;
					this.messageChannel.on('ReturnSysModuleReport', function(payload) {
						this.cardState = payload.operation;
						this.sysModuleReport = payload.printable;
						this.sourceReportId = payload.sourceReportId;
						callback.call(scope);
					}, this);
					this.messageChannel.sendMessage("RequestSysModuleReport");
					this.sandbox.subscribe("RequestCopyData", function() {
						const payload = {
							isCopy: this.cardState === "copy",
							sourceReportId: this.sourceReportId
						};
						this.sandbox.publish("ReturnCopyData", payload);
					}, this);
					this.sandbox.subscribe("RequestSysModuleReport", function() {
						const isNew = this.cardState !== "edit";
						converter.convertFromAngularDto(isNew, this.sysModuleReport, function(entityDto) {
							this.sandbox.publish("ReturnSysModuleReport", entityDto);
						}, this);
					}, this);
					this.sandbox.subscribe("ChangeCardState", function(state) {
						 this.cardState = state;
					}, this);
					this.sandbox.subscribe("RequestSysModuleReportDiscard", function() {
						this.messageChannel.sendMessage("RequestSysModuleReportDiscard");
					}, this);
					this.messageChannel.on('ReturnSysModuleReportDiscardResult', function(printable) {
						this.sysModuleReport = printable;
						this.sandbox.publish("ReturnSysModuleReportDiscardResult");
					}, this);
					this.messageChannel.on('ReturnSysModuleReportSaveResult', function(data) {
						this.sandbox.publish("ReturnSysModuleReportSaveResult", data);
					}, this);
					this.sandbox.subscribe("RequestSysModuleReportSave", function(entity) {
						converter.convertToAngularDto(entity, function(sysModuleReport) {
							this.sysModuleReport = sysModuleReport;
							this.messageChannel.sendMessage("RequestSysModuleReportSave", {printable: sysModuleReport});
						}, this);
					}, this);
					this.sandbox.subscribe("RequestClosePage", function() {
						this.messageChannel.sendMessage("RequestClosePage");
					}, this);
				}, this);
			}, this]);
		},

		/**
		 * Renders module.
		 */
		render: function(renderTo) {
			this.callParent(arguments);
			this.sandbox.subscribe("NavigationModuleLoaded", function() {
				const hash = BPMSoft.combinePath("CardModuleV2", "WordPrintablePage", this.cardState, this.sysModuleReport.id);
				this.sandbox.publish("PushHistoryState", {hash: hash});
			}, this);
		}

		//endregion
	});

	return BPMSoft.WordPrintablePageLoader;
});
