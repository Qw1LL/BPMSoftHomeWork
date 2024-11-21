define("OrderPageV2", ["ProcessModuleUtilities"],
		function(ProcessModuleUtilities) {
			return {
				entitySchemaName: "Order",
				methods: {
					/**
					 * @inheritdoc BPMSoft.BasePageV2#getActions
					 * @overridden
					 */
					getActions: function() {
						var actionMenuItems = this.callParent(arguments);
						actionMenuItems.add("CreateInvoice", this.getButtonMenuItem({
							"Caption": this.get("Resources.Strings.CreateInvoiceByOrderCaption"),
							"Tag": "onCreateInvoiceClick",
							"Enabled": {"bindTo": "canEntityBeOperated"}
						}));
						return actionMenuItems;
					},

					/**
					 * Event handler "CreateInvoice" button click.
					 * @protected
					 */
					onCreateInvoiceClick: function() {
						if (this.isChanged()) {
							this.save({
								isSilent: true,
								scope: this,
								callback: this.createInvoice
							});
						} else {
							this.createInvoice();
						}
					},

					/**
					 * Returns ProcessModuleUtilities.
					 * @protected
					 * @return {BPMSoft.ProcessModuleUtilities} ProcessModuleUtilities
					 */
					getProcessModuleUtilities: function() {
						return ProcessModuleUtilities;
					},

					/**
					 * Queries create invoice from order process id.
					 * @protected
					 * @param {Function} callback Callback f-n.
					 * @param {Object} scope Callback scope.
					 */
					queryProcessId: function(callback, scope) {
						this.BPMSoft.SysSettings.querySysSettingsItem("CreateInvoiceFromOrderProcess",
								function(createInvoiceFromOrderProcessValue) {
									var sysProcessId;
									if (createInvoiceFromOrderProcessValue &&
										createInvoiceFromOrderProcessValue.value) {
										sysProcessId = createInvoiceFromOrderProcessValue.value;
									}
									this.Ext.callback(callback, scope, [sysProcessId]);
								}, this);
					},

					/**
					 * Starts create invoice from order process.
					 * @protected
					 */
					createInvoice: function() {
						this._updateHistoryState();
						this.queryProcessId(function(sysProcessId) {
							if (!sysProcessId) {
								throw BPMSoft.ItemNotFoundException(
										this.get("Resources.Strings.CreateInvoiceFromOrderProcessNotSet")
								);
							}
							this.getProcessModuleUtilities().executeProcess({
								sysProcessId: sysProcessId,
								parameters: {
									CurrentOrder: this.get("Id")
								}
							});
						}, this);
					},

					/**
					 * Updates current history state object.
					 * @private
					 */
					_updateHistoryState: function() {
						var historyState = this.sandbox.publish("GetHistoryState");
						var state = historyState.state || {};
						var cardOperation = this.get("Operation");
						var isNewModeInHistoryState = this.getIsNewMode(state.operation);
						var isNewModeInCardOperation =  this.getIsNewMode(cardOperation);
						if (isNewModeInHistoryState && !isNewModeInCardOperation) {
							state.operation = cardOperation;
							state.primaryColumnValue = this.getPrimaryColumnValue();
							this.sandbox.publish("ReplaceHistoryState", {
								stateObj: state,
								hash: historyState.hash.historyState,
								silent: true
							});
						}
					},

					/**
					 * Returns whether the page state in append or copy mode.
					 * @param {String} operation Card operation.
					 * @return {Boolean} Page state in append or copy mode.
					 */
					getIsNewMode: function(operation) {
						return operation === this.BPMSoft.ConfigurationEnums.CardOperation.ADD ||
								operation === this.BPMSoft.ConfigurationEnums.CardOperation.COPY;
					}
				},
				details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
				diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
			};
		});
