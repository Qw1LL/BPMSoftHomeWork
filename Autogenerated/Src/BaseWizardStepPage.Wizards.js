define("BaseWizardStepPage", [], function() {
	return {
		messages: {
			"Validate": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			"ValidationResult": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
			"Save": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			"SavingResult": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		methods: {

			//region Methods: Private

			/**
			 * Gets saving result and publishes it.
			 * @private
			 * @param {Object} wizardInfo Wizard information.
			 */
			saveStep: function(wizardInfo) {
				var savingResult = this.getSavingResult(wizardInfo);
				this.sandbox.publish("SavingResult", savingResult, [this.sandbox.id]);
			},

			/**
			 * Gets validation result and publishes it.
			 * @private
			 * @param {Object} wizardInfo Wizard information.
			 */
			validateStep: function(wizardInfo) {
				var validationResult = this.getValidationResult(wizardInfo);
				this.sandbox.publish("ValidationResult", validationResult, [this.sandbox.id]);
			},

			//endregion

			//region Methods: Protected

			/**
			 * Gets subscribers tags.
			 * @protected
			 * @virtual
			 * @return {String[]}
			 */
			getSubscribersTags: function() {
				return [this.sandbox.id];
			},

			/**
			 * Subscribes messages.
			 * @protected
			 * @virtual
			 */
			subscribeMessages: function() {
				var subscribersTags = this.getSubscribersTags();
				this.sandbox.subscribe("Save", this.saveStep, this, subscribersTags);
				this.sandbox.subscribe("Validate", this.validateStep, this, subscribersTags);
			},

			/**
			 * Returns saving result.
			 * @abstract
			 */
			getSavingResult: BPMSoft.abstractFn,

			/**
			 * Returns validation result.
			 * @abstract
			 */
			getValidationResult: BPMSoft.abstractFn,

			//endregion

			//region Methods: Public

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
			 * @overridden
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this.subscribeMessages();
					callback.call(scope);
				}, this]);
			}

			//endregion

		}
	};
});
