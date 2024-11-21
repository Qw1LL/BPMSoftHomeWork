define("EmailPageV2", ["EmailConstants"],
	function(EmailConstants) {
	return {
		entitySchemaName: "Activity",
		methods: {

			/**
			 * @inheritDoc BPMSoft.BasePageV2#onEntityInitialized
			 * @override
			 */
			onEntityInitialized: function(callback, scope) {
				var parentMethod = this.getParentMethod();
				this.setSenderFromIncidentRegistration(function() {
					parentMethod.apply(this, [callback, scope]);
				}, this);
			},

			/**
			 * Set sender mailbox using incident registration logic.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Scope} scope Callback scope.
			 */
			setSenderFromIncidentRegistration: function(callback, scope) {
				this._obtainMailboxSender(callback, scope);
			},

			/**
			 * Obtains sender mailbox.
			 * @private
			 * @param {Function} callback Callback function.
			 * @param {Scope} scope Callback scope.
			 */
			_obtainMailboxSender: function(callback, scope) {
				const config = {
					serviceName: "SenderObtainingService",
					methodName: "ObtainSenderMailboxByActivityId"
				};
				const activityId = this.getParentActivityId();
				config.data = {
					activityId: activityId
				};
				this.callService(config, function(response) {
					this._setObtainedSenderMailbox(response, callback, scope)
				}, this);
			},

			/**
			 * Sets obtained sender mailbox as an email sender.
			 * @private
			 * @param {Object} response Sender obtaining service response.
			 * @param {Function} callback Callback function.
			 * @param {Scope} scope Callback scope.
			 */
			_setObtainedSenderMailbox: function(response, callback, scope) {
				const result = response && response.ObtainSenderMailboxByActivityIdResult;
				if (result && result.success) {
					const senderItem = this.getSenderByEmail(result.MailboxName);
					const senderName = senderItem && senderItem.$SenderDisplayValue ? senderItem.$SenderDisplayValue :
						this.BPMSoft.SysValue.CURRENT_USER_CONTACT.displayValue;
					let senderEnumValue = {
						displayValue: this.Ext.String.format(
							this.get("Resources.Strings.EmailFormatString"),
							senderName, result.MailboxName).trim(),
						value: result.MailboxId
					};
					if (senderItem) {
						senderEnumValue = this.getItemWithSignature(senderEnumValue, senderItem);
						this.set("SenderEnum", senderEnumValue);
						this.set("SenderEmail", result.MailboxName);
					}
				}
				this.Ext.callback(callback, scope || this);
			},

			/**
			 * @inheritDoc BPMSoft.EmailPageV2#initSetSenderEnum
			 * @override
			 */
			initSetSenderEnum: function() {
				if (this.isEmpty(this.get("SenderEnum"))) {
					this.callParent(arguments);
				}
			},

			/**
			 * Get parent activity from hash.
			 * @protected
			 */
			getParentActivityId: function() {
				const history = this.sandbox.publish("GetHistoryState");
				if (!history || !history.hash) {
					return;
				}
				const stateParams = history.hash.valuePairs;
				const actions = EmailConstants.emailAction;
				const forwardOrReplyActions = [actions.Forward, actions.ReplyAll, actions.Reply];
				const activityId = this.BPMSoft.find(stateParams, function(param) {
					return this.BPMSoft.contains(forwardOrReplyActions, param.name);
				}, this);
				return history.state.useServiceMailBoxLogic && activityId && activityId.value;
			}
		},
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
