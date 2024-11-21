define("BaseWizardStepSchemaMixin", ["ext-base", "BPMSoft"], function(Ext, BPMSoft) {
	Ext.define("BPMSoft.configuration.mixins.BaseWizardStepSchemaMixin", {
		alternateClassName: "BPMSoft.BaseWizardStepSchemaMixin",

		//region Methods: Private

		/**
		 * Returns wizard step messages.
		 * @private
		 * @return {Object} Messages.
		 */
		getWizardStepMessages: function() {
			return {
				/**
				 * @message GetModuleConfig
				 * Publishing message for section parameters request.
				 */
				"GetModuleConfig": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message GetModuleConfigResult
				 * Subscribing on message for section parameters request.
				 */
				"GetModuleConfigResult": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message Validate
				 * Subscribing on message for section parameters validation request.
				 */
				"Validate": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message ValidationResult
				 * Publishing message for section parameters validation sending.
				 */
				"ValidationResult": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message Save
				 * Subscribing on message for section saving request.
				 */
				"Save": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message SavingResult
				 * Publishing message for sending section saved results.
				 */
				"SavingResult": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			};
		},

		/**
		 * Subscribes sandbox messages.
		 * @private
		 */
		subscribeWizardStepMessages: function() {
			var sandboxId = this.sandbox.id;
			this.sandbox.subscribe("Save", this.onSave, this, [sandboxId]);
			this.sandbox.subscribe("Validate", this.onValidate, this, [sandboxId]);
		},

		//endregion

		//region Methods: Protected

		/**
		 * Processes saving on save/left wizard action.
		 * @abstract
		 * @protected
		 * @virtual
		 */
		onSave: function() {
			this.publishSavingResult();
		},

		/**
		 * Processes validation on save/left wizard action.
		 * @abstract
		 * @protected
		 * @virtual
		 */
		onValidate: function() {
			this.publishValidationResult();
		},

		/**
		 * Processes getting section configuration.
		 * @abstract
		 * @protected
		 * @virtual
		 * @param {Object} config Section configuration.
		 * @param {String} config.packageUId Package uId.
		 * @param {Object} config.applicationStructureItem Designed section structure item.
		 * @param {Function} next The callback function.
		 * @param {object} scope The context of callback function.
		 */
		onGetModuleConfigResult: BPMSoft.abstractFn,

		//endregion

		//region Methods: Public

		/**
		 * Initialize subscribe/publish base wizard step messages.
		 */
		init: function(next, scope) {
			this.sandbox.registerMessages(this.getWizardStepMessages());
			this.subscribeWizardStepMessages();
			this.sandbox.subscribe("GetModuleConfigResult", function(config) {
				this.onGetModuleConfigResult(config, next, scope);
			}, this, [this.sandbox.id]);
			this.sandbox.publish("GetModuleConfig", null, [this.sandbox.id]);
		},

		/**
		 * Publishes validation result.
		 * @param {Boolean} isValid Is valid view model.
		 */
		publishValidationResult: function(isValid) {
			isValid = Ext.isDefined(isValid) ? isValid : false;
			this.sandbox.publish("ValidationResult", isValid, [this.sandbox.id]);
		},

		/**
		 * Publishes saveing result.
		 * @param {Boolean} saveResult Saving result value.
		 */
		publishSavingResult: function(saveResult) {
			saveResult = Ext.isDefined(saveResult) ? saveResult : null;
			this.sandbox.publish("SavingResult", saveResult, [this.sandbox.id]);
		}

		//endregion

	});
	return Ext.create("BPMSoft.BaseWizardStepSchemaMixin");
});
