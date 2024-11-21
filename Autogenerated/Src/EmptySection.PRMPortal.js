define("EmptySection", [], function() {
		return {
			entitySchemaName: "BaseLookup",
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/,
			methods: {
				/**
				* Initializes the initial values of the model.
				* @protected
				* @override
				*/
				init: function() {
					this.callParent(arguments);
					var message = this.get("Resources.Strings.MessageBoxText");
					this.showMessage(message, this.back);
				},

				/**
				 * Shows message.
				 * @protected
				 * @param {String} message Message.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Execution context.
				 */
				showMessage: function(message, callback, scope) {
					this.showConfirmationDialog(message, function() {
						this.Ext.callback(callback, scope || this);
					}, [BPMSoft.MessageBoxButtons.OK]);
				},

				/**
				 * Returns user back to previous history state.
				 * @protected
				 */
				back: function() {
					this.sandbox.publish("BackHistoryState");
					this.hideBodyMask();
				}
			}
		};
	}
);
