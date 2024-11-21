define("WidgetDesignerLoader", ["ext-base", "BPMSoft", "BaseViewModule", "AngularPostMessageConnector"], function() {

	Ext.define("BPMSoft.configuration.WidgetDesignerLoader", {
		extend: "BPMSoft.BaseViewModule",
		alternateClassName: "BPMSoft.WidgetDesignerLoader",

		messageChannel: null,

		widgetConfig: null,

		/**
		 * @inheritDoc
		 * @override
		 */
		constructor: function() {
			this.callParent(arguments);
			this._registerMessages();
			this.messageChannel = Ext.create('BPMSoft.AngularPostMessageConnector', {
				channelName: "widget-designer-channel",
				target: window.parent
			});
		},
		
		/**
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
				"WidgetConfigChanged": {
					"direction": BPMSoft.MessageDirectionType.SUBSCRIBE,
					"mode": BPMSoft.MessageMode.BROADCAST
				},
				"GetModuleConfig": {
					"direction": BPMSoft.MessageDirectionType.SUBSCRIBE,
					"mode": BPMSoft.MessageMode.PTP
				},
				"DesignerLoaded": {
					"direction": BPMSoft.MessageDirectionType.SUBSCRIBE,
					"mode": BPMSoft.MessageMode.BROADCAST
				},
				"ModalOpening": {
					"direction": BPMSoft.MessageDirectionType.SUBSCRIBE,
					"mode": BPMSoft.MessageMode.BROADCAST
				},
				"ModalClosing": {
					"direction": BPMSoft.MessageDirectionType.SUBSCRIBE,
					"mode": BPMSoft.MessageMode.BROADCAST
				},
			}
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

		/**
		 * @private
		 */
		_subscribeMessages: function() {
			const widgetDesignerModuleId = this._getWidgetDesignerModuleId();
			this.sandbox.subscribe("GetModuleConfig", () => this.widgetConfig, this, [widgetDesignerModuleId]);
			this.sandbox.subscribe("WidgetConfigChanged", ({ resources, ...config }) => {
				this.widgetConfig.itemConfig.config = config;
				this.widgetConfig.resources = resources;
				this.messageChannel.sendMessage("SaveWidgetConfig", { itemConfig: this.widgetConfig.itemConfig, 
						resources });
			}, this, [widgetDesignerModuleId]);
			this.sandbox.subscribe("DesignerLoaded", () => {
				this.messageChannel.sendMessage("DesignerLoaded");
			}, this, [widgetDesignerModuleId]);
			this.sandbox.subscribe("ModalOpening", () => {
				this.messageChannel.sendMessage("ModalOpening");
			}, this, [widgetDesignerModuleId]);
			this.sandbox.subscribe("ModalClosing", () => {
				this.messageChannel.sendMessage("ModalClosing");
			}, this, [widgetDesignerModuleId]);
		},

		/**
		 * @private
		 */
		_getWidgetDesignerModuleId: function() {
			return this.sandbox.id + "_" + this._getWidgetSchemaName();
		},

		/**
		 * @private
		 */
		_getWidgetSchemaName: function() {
			const search = window.location.search;
			const parameters = new URLSearchParams(search);
			const designSchemaName = parameters.get("designSchemaName");
			if (!designSchemaName) {
				throw new BPMSoft.ArgumentNullOrEmptyException({
						argumentName: "designSchemaName"
					});
			}
			return designSchemaName;
		},

		/**
		 * @inheritDoc
		 * @overridden
		 */
		initHomePage: function(callback, scope) {
			Ext.callback(callback, scope);
		},

		/**
		 * @inheritDoc
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


		// region Methods: Public

		/**
		 * Initializes module.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback.
		 */
		init: function(callback, scope) {
			this._subscribeMessages();
			this.callParent([() => {
				this.messageChannel.connect(result => {
					if (result === false) {
						throw Ext.create("BPMSoft.InvalidOperationException");
					}
					this.messageChannel.on('ResponseWidgetConfig', function(config) {
						this.widgetConfig = config;
						Ext.callback(callback, scope);
					}, this);
					this.messageChannel.sendMessage("RequestWidgetConfig");
				});
			}]);
		},

		/**
		 * Renders module.
		 */
		render: function(renderTo) {
			this.callParent(arguments);
			this.sandbox.loadModule("BaseSchemaModuleV2", {
				id: this._getWidgetDesignerModuleId(),
				instanceConfig: {
					generateViewContainerId: false,
					useHistoryState: false,
					schemaName: this._getWidgetSchemaName(),
					isSchemaConfigInitialized: true
				},
				keepAlive: true,
				renderTo: renderTo,
			});
		}

		//endregion
	});
	
	return BPMSoft.WidgetDesignerLoader;
 });
