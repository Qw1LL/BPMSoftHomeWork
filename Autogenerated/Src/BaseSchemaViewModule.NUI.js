define("BaseSchemaViewModule", ["MaskHelper", "@bpmstudio/sdk", "ConfigurationEnums", "BaseModule",
		"SchemaViewComponent", "ContextHelpMixin"],
	function(MaskHelper, sdk, ConfigurationEnums) {
	Ext.define("BPMSoft.configuration.BaseSchemaViewModule", {
		alternateClassName: "BPMSoft.BaseSchemaViewModule",
		extend: "BPMSoft.BaseModule",
		mixins: {
			ContextHelpMixin: "BPMSoft.ContextHelpMixin"
		},

		/**
		 * @protected
		 */
		componentSelector: null,
		/**
		 * @protected
		 */
		isSchemaConfigInitialized: false,
		/**
		 * @protected
		 */
		useHistoryState: true,
		/**
		 * @protected
		 */
		schemaName: "",
		/**
		 * @protected
		 */
		entitySchemaName: null,

		/**
		 * @protected
		 */
		componentWrapSelector: null,

		/**
		 * @protected
		 */
		viewModel: null,

		/**
		 * @protected
		 */
		viewConfig: null,

		/**
		 * @protected
		 */
		headerCaption: null,

		/**
		 * @protected
		 */
		unsubscribesHandlers: null,

		/**
		 * @protected
		 */
		handlerChain: sdk.HandlerChainService.instance,

		/**
		 * @private
		 */
		_component: null,

		/**
		 * @private
		 */
		_onScroll: function() {
			// if (window.pageYOffset > 0) {
			// 	document.body.classList.add("scroll");
			// } else {
			// 	document.body.classList.remove("scroll");
			// }
		},

		/**
		 * @private
		 */
		_addComponent: function(renderTo) {
			this._component = document.createElement(this.componentSelector);
			renderTo.appendChild(this._component);
			this._component.addEventListener("viewModelGenerated", this._onViewModelGenerated.bind(this));
			this._component.addEventListener("viewConfigGenerated", this._onViewConfigGenerated.bind(this));
			if (this.viewModel) {
				this._component.viewModel = this.viewModel;
				this._component.viewConfig = this.viewConfig;
				this.sandbox.publish("InitDataViews", {caption: this.headerCaption, moduleName: this.schemaName});
			} else {
				this._component.setAttribute("schema", this.schemaName);
			}
		},
		/**
		 * @private
		 */
		_removeComponent: function() {
			this._component?.remove();
			this._component = null;
		},
		/**
		 * @private
		 */
		_getChainCardModuleSandboxId: function(moduleName) {
			return this.sandbox.id + moduleName + "_chain00000000-0000-0000-0000-000000000000";
		},

		/**
		 * @private
		 */
		_prepareHistoryState: function(currentState) {
			const newState = this.BPMSoft.deepClone(currentState);
			newState.moduleId = this.sandbox.id;
			return newState;
		},

		/**
		 * @private
		 */
		_onViewModelGenerated: function(event) {
			this.viewModel = event.detail;
		},

		/**
		 * @private
		 */
		_onViewConfigGenerated: function(event) {
			this.viewConfig = event.detail;
		},

		/**
		 * @protected
		 */
		onInitDataView: async function() {
		},

		/**
		 * Returns message config.
		 * @returns Object
		 */
		getMessages: function() {
			return {
				"GetHistoryState": {
					direction: this.BPMSoft.MessageDirectionType.PUBLISH,
					mode: this.BPMSoft.MessageMode.PTP
				},
				"ReplaceHistoryState": {
					direction: this.BPMSoft.MessageDirectionType.PUBLISH,
					mode: this.BPMSoft.MessageMode.BROADCAST
				},
				"PushHistoryState": {
					mode: BPMSoft.MessageMode.BROADCAST,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				"InitContextHelp": {
					direction: this.BPMSoft.MessageDirectionType.PUBLISH,
					mode: this.BPMSoft.MessageMode.PTP
				},
				"BackHistoryState": {
					"mode": BPMSoft.MessageMode.BROADCAST,
					"direction": BPMSoft.MessageDirectionType.PUBLISH
				},
				"InitDataViews": {
					direction: this.BPMSoft.MessageDirectionType.PUBLISH,
					mode: this.BPMSoft.MessageMode.PTP
				},
				"SchemaViewChanged": {
					mode: BPMSoft.MessageMode.BROADCAST,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				"GetSchemaViewInfo": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			};
		},

		/**
		 * @private
		 */
		_editRecord: function({$initialEvent}) {
			const {entityName, recordId} = $initialEvent;
			const moduleStructure = BPMSoft.configuration.ModuleStructure[entityName];
			const moduleId = [moduleStructure.cardModule, recordId, moduleStructure.cardSchema].join("_");
			const stateObj = {moduleId};
			const hash = Ext.String.format("{0}/{1}/{2}/{3}", moduleStructure.cardModule,
				moduleStructure.cardSchema, "edit", recordId);
			return this.sandbox.publish("PushHistoryState", {hash, stateObj});
		},

		/**
		 * @private
		 */
		_addRecord: function({$initialEvent}) {
			const {entityName} = $initialEvent;
			const moduleStructure = BPMSoft.configuration.ModuleStructure[entityName];
			const moduleId = this._getChainCardModuleSandboxId(moduleStructure.cardModule);
			return this.openCardInChain({
				schemaName: moduleStructure.cardSchema,
				operation: ConfigurationEnums.CardStateV2.ADD,
				moduleId,
				moduleName: moduleStructure.cardModule
			});
		},

		/**
		 * @private
		 */
		_copyRecord: function({$initialEvent}) {
			const {entityName, recordId} = $initialEvent;
			const moduleStructure = BPMSoft.configuration.ModuleStructure[entityName];
			const moduleId = this._getChainCardModuleSandboxId(moduleStructure.cardModule);
			this.openCardInChain({
				id: recordId,
				schemaName: moduleStructure.cardSchema,
				operation: ConfigurationEnums.CardStateV2.COPY,
				moduleId,
				moduleName: moduleStructure.cardModule
			});
		},

		/**
		 * Initializes the name of the scheme.
		 * @protected
		 */
		initSchemaName: BPMSoft.abstractFn,

		/**
		 * Register handler chain handlers.
		 * @protected
		 */
		subscribeHandlers: function() {
			const moduleRef = this;
			this.unsubscribesHandlers.push(
				this.handlerChain.register("crt.7xRequest", new class extends sdk.BaseRequestHandler {
					handle(request) {
						switch (request.action) {
							case "GetHistoryState":
								return moduleRef.sandbox.publish("GetHistoryState");
							case "BackHistoryState":
								return moduleRef.sandbox.publish("BackHistoryState");
							case "EditRecord":
								return moduleRef._editRecord(request);
							case "AddRecord":
								return moduleRef._addRecord(request);
							case "InitDataViews":
								return moduleRef.onInitDataView(request);
							case "CopyRecord":
								return moduleRef._copyRecord(request);
							default:
								return this.next?.handle(request);
						}
					}
				}())
			);
		},

		/**
		 * @inheritdoc BPMSoft.configuration.BaseModule#init
		 * @override
		 */
		init: function(callback, scope) {
			this.unsubscribesHandlers = [];
			this.sandbox.registerMessages(this.getMessages());
			this.initHistoryState();
			if (!this.isSchemaConfigInitialized) {
				this.initSchemaName();
			}
			this.sandbox.subscribe("GetSchemaViewInfo", this.getSchemaViewInfo.bind(this));
			this.sandbox.publish("SchemaViewChanged", this.getSchemaViewInfo());
			this.initContextHelp();
			this.subscribeHandlers();
			Ext.callback(callback, scope);
		},

		/**
		 * Returns schema view information.
		 * @returns {Object} Schema view information.
		 */
		getSchemaViewInfo: function() {
			return {schemaName: this.schemaName};
		},

		/**
		 * @override
		 */
		render: function(renderTo) {
			this._renderTo = renderTo;
			document.body.classList.add(this.componentWrapSelector);
			this._addComponent(renderTo);
			window.addEventListener("scroll", this._onScroll.bind(this));
			MaskHelper.hideBodyMask();
		},

		/**
		 * Replaces the last element in the chain of states, if the module identifier differs from the current.
		 * @protected
		 */
		initHistoryState: function() {
			const sandbox = this.sandbox;
			const state = sandbox.publish("GetHistoryState");
			const currentHash = state.hash;
			const currentState = state.state || {};
			if (currentState.moduleId === sandbox.id) {
				return;
			}
			const newState = this._prepareHistoryState(currentState);
			sandbox.publish("ReplaceHistoryState", {
				stateObj: newState,
				pageTitle: null,
				hash: currentHash.historyState,
				silent: true
			});
		},

		/**
		 * @protected
		 */
		reloadPage: function() {
			this._removeComponent();
			this.viewModel?.destroy();
			this.viewModel = null;
			this._addComponent(this._renderTo);
			this._component.setAttribute("schema", this.schemaName);
		},

		/**
		 * Opens card in chain.
		 * @protected
		 * @param {Object} config Card configuration information
		 */
		openCardInChain: function(config) {
			const historyState = this.sandbox.publish("GetHistoryState");
			const stateObj = config.stateObj || {
				isSeparateMode: true,
				schemaName: config.schemaName,
				entitySchemaName: config.entitySchemaName,
				operation: config.action || config.operation,
				primaryColumnValue: config.id,
				valuePairs: config.defaultValues,
				isInChain: true
			};
			this.sandbox.publish("PushHistoryState", {
				hash: historyState.hash.historyState,
				silent: config.silent,
				stateObj
			});
			const moduleName = config.moduleName;
			const moduleParams = {
				renderTo: this._renderTo,
				id: config.moduleId,
				keepAlive: (config.keepAlive !== false)
			};
			const instanceConfig = config.instanceConfig;
			if (instanceConfig) {
				this.Ext.apply(moduleParams, {
					instanceConfig: instanceConfig
				});
			}
			this.sandbox.loadModule(moduleName, moduleParams);
		},

		/**
		 * @inheritDoc BPMSoft.core.BaseObject#destroy
		 * @overridden
		 */
		destroy: function({keepAlive}) {
			if (keepAlive !== true) {
				this.viewConfig = null;
				this.viewModel?.destroy();
				this.viewModel = null;
			}
			window.removeEventListener("scroll", this._onScroll);
			this._component?.removeEventListener("viewModelGenerated", this._onViewModelGenerated.bind(this));
			this._component?.removeEventListener("viewConfigGenerated", this._onViewConfigGenerated.bind(this));
			this._removeComponent();
			document.body.classList.remove(this.componentWrapSelector);
			this.unsubscribesHandlers.forEach((handler) => handler());
			this.unsubscribesHandlers = [];
			this.sandbox.publish("SchemaViewChanged", {schemaName: this.schemaName, destroyed: true});
		}
	});
	return BPMSoft.BaseSchemaViewModule;
});
