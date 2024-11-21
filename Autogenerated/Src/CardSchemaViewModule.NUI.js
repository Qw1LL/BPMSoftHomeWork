define("CardSchemaViewModule", ["@bpmstudio/sdk", "BaseSchemaViewModule", "HistoryStateUtilities"], function(sdk) {
	Ext.define("BPMSoft.configuration.CardSchemaViewModule", {
		alternateClassName: "BPMSoft.CardSchemaViewModule",
		extend: "BPMSoft.BaseSchemaViewModule",

		mixins: {
			historyStateUtilities: "BPMSoft.HistoryStateUtilities"
		},

		/**
		 * @protected
		 */
		componentSelector: "crt-card-component",
		/**
		 * @protected
		 */
		componentWrapSelector: "crt-card",

		/**
		 * @inheritDoc BPMSoft.BaseSchemaViewModule#getMessages
		 * @overridden
		 */
		getMessages: function () {
			const config = this.callParent(arguments);
			const messages = {
				"CardModuleResponse": {
					direction: this.BPMSoft.MessageDirectionType.PUBLISH,
					mode: this.BPMSoft.MessageMode.PTP
				},
				"UpdateDetail": {
					"mode": this.BPMSoft.MessageMode.PTP,
					"direction": this.BPMSoft.MessageDirectionType.PUBLISH
				},
				"UpdateParentLookupDisplayValue": {
					direction: this.BPMSoft.MessageDirectionType.PUBLISH,
					mode: this.BPMSoft.MessageMode.BROADCAST
				},
			};
			return Ext.apply(config, messages);
		},

		/**
		 * @inheritDoc BPMSoft.BaseSchemaViewModule#subscribeHandlers
		 * @protected
		 */
		subscribeHandlers: function () {
			this.callParent(arguments);
			const moduleRef = this;
			this.unsubscribesHandlers.push(
				this.handlerChain.register("crt.7xRequest", new class extends sdk.BaseRequestHandler {
					handle(request) {
						switch (request.action) {
							case "CardResponse":
								const cardModuleResponse = {
									...request.$initialEvent,
									isInChain: moduleRef.isInChain
								};
								moduleRef.sandbox.publish("UpdateDetail", {
									primaryColumnValue: cardModuleResponse.primaryColumnValue
								}, [moduleRef.sandbox.id]);
								if (moduleRef.isInChain) {
									moduleRef.sandbox.publish("UpdateParentLookupDisplayValue", {
										referenceSchemaName: cardModuleResponse.referenceSchemaName,
										displayValue:  cardModuleResponse.primaryDisplayColumnValue,
										value: cardModuleResponse.primaryColumnValue,
									});
								}
								return moduleRef.sandbox.publish("CardModuleResponse", cardModuleResponse,
									[moduleRef.sandbox.id]);
							default:
								return this.next?.handle(request);
						}
					}
				}())
			);
		},

		/**
		 * @inheritDoc BPMSoft.BaseSchemaViewModule#onInitDataView
		 * @overridden
		 * @returns {Promise}
		 */
		onInitDataView: async function({$initialEvent}) {
			const {caption, hidePageCaption} = $initialEvent;
			this.headerCaption = caption;
			this.sandbox.publish("InitDataViews", {
				caption,
				hidePageCaption
			});
		},

		/**
		 * @inheritDoc BPMSoft.BaseSchemaViewModule#initSchemaName
		 * @protected
		 * @overridden
		 */
		initSchemaName: function() {
			const historyState = this.sandbox.publish("GetHistoryState");
			const state = historyState.state || {};
			this.isInChain = state.isInChain;
			if (this.Ext.isEmpty(state.schemaName) && !this.isInChain) {
				const historyStateInfo = this.getHistoryStateInfo();
				this.schemaName = historyStateInfo.schemas.pop();
				this.operation = historyStateInfo.operation;
				this.primaryColumnValue = historyStateInfo.primaryColumnValue;
			} else {
				if (state.entitySchemaName) {
					this.entitySchemaName = state.entitySchemaName;
				}
				this.schemaName = state.schemaName;
				this.operation = state.operation;
				this.primaryColumnValue = state.primaryColumnValue;
			}
		}

	});
	return BPMSoft.CardSchemaViewModule;
});
