define("PreviewReplicaViewModel",
	["MacroUtils","PreviewReplicaViewModelResources","EmailHelperModule", "BPMSoft", "BulkEmailSenderValidator",
		"InformationButtonResources", "BpmCrmCloudServiceApi"],
	function(MacroUtils, Resources, EmailHelperModule, BPMSoft, BulkEmailSenderValidator) {

	var PreviewReplicaViewModelConsts = {
		SenderEmailDomainValidationKeyPrefix: "PreviewReplicaViewModel_SenderEmail_ValidationResult_"
	};

	Ext.define("BPMSoft.configuration.PreviewReplicaViewModel", {
		alternateClassName: "BPMSoft.PreviewReplicaViewModel",
		extend: "BPMSoft.BaseViewModel",
		sandbox: null,
		resources: Resources,
		cache: null,
		validateColumns: false,
		columns: {
			"Mask": { value: null },
			"Content": { value: null },
			"Caption": { value: null },
			"Subject": { value: "" },
			"PreHeader": { value: "" },
			"SenderEmail": { value: "" },
			"SenderName": { value: "" },
			"UseSpecialHeaders": { value: null },
			"ActiveLinkedItem": { value: null },
			"DefaultItem": { value: null },
			"ReplicaRules": { value: null },
			"OnSenderEmailDomainValidation": {
				value: null
			},
			"BulkEmailId": { value: "" }
		},

		/**
		 * @inheritdoc BPMSoft.BaseViewModel#constructor
		 * @override
		 */
		constructor: function () {
			this.callParent(arguments);
			this.on("change:Subject "+
				"change:SenderEmail " +
				"change:SenderName " +
				"change:PreHeader " +
				"change:UseSpecialHeaders", this._columnChangeHandler, this);
			this.on("change:UseSpecialHeaders", this._onUseSpecialHeadersChanged, this);
			this.initValidationConfig();
		},

		_getValidationResult: function(shortMessage, fullMessage) {
			return {
				fullInvalidMessage: shortMessage,
				invalidMessage: fullMessage ? fullMessage : shortMessage
			};
		},

		/**
		 * Returns domain of the sender email.
		 * @return {String} domain.
		 */
		getSenderDomain: function() {
			var email = this.$SenderEmail || "";
			return email.replace(/^.*@/, "");
		},

		/**
		 * Function to validate email by field name.
		 * @private
		 * @return {Object} Returns validation result.
		 */
		_checkSenderEmail: function() {
			var validationMessage = "";
			var email = this.$SenderEmail;
			if (!EmailHelperModule.isEmailValid(email)) {
				validationMessage =  Resources.localizableStrings.IncorrectEmailMessage;
			} else {
				this.asyncValidateSenderDomain(function(isValid) {
					if (this.$OnSenderEmailDomainValidation) {
						this.$OnSenderEmailDomainValidation(isValid, null);
					}
				}, this);
			}
			return this._getValidationResult(validationMessage);
		},

		/**
		 * Validates sender name.
		 * @private
		 * @return {Object} Returns validation result.
		 */
		_senderNameValidator: function() {
			var validationMessage = "";
			var senderName = this.$SenderName;
			if (Ext.isEmpty(senderName)) {
				validationMessage = Resources.localizableStrings.FieldEmptyValidationMessage;
				return this._getValidationResult(validationMessage);
			}
			if (MacroUtils.isStringContainsMacro(senderName) && !MacroUtils.isValueMacro(senderName)) {
				validationMessage = Resources.localizableStrings.SenderMacroValidationMessage;
				return this._getValidationResult(validationMessage);
			}
			return this._getValidationResult(validationMessage);
		},

		/**
		 * Validates sender email.
		 * @private
		 * @return {Object} Returns validation result.
		 */
		_senderEmailValidator: function() {
			var validationMessage = "";
			var senderEmail = this.$SenderEmail;
			if (Ext.isEmpty(senderEmail)) {
				validationMessage = Resources.localizableStrings.FieldEmptyValidationMessage;
				return this._getValidationResult(validationMessage);
			}
			if (MacroUtils.isStringContainsMacro(senderEmail)) {
				if (MacroUtils.isValueMacro(senderEmail)) {
					validationMessage = this.get("Resources.Strings.SenderMacroInfoMessage");
					if (this.$OnSenderEmailDomainValidation) {
						this.$OnSenderEmailDomainValidation(true, validationMessage);
					}
					return this._getValidationResult("");
				} else {
					validationMessage = Resources.localizableStrings.SenderMacroValidationMessage;
					return this._getValidationResult(validationMessage);
				}
			}
			return this._checkSenderEmail();
		},

		/**
		 * Function to validate template subject.
		 * @private
		 * @return {Object} Returns validation result.
		 */
		_subjectValidator: function() {
			var validationMessage = "";
			var templateSubject = this.$Subject;
			if (Ext.isEmpty(templateSubject)) {
				validationMessage = Resources.localizableStrings.FieldEmptyValidationMessage;
			}
			return this._getValidationResult(validationMessage);
		},

		/**
		 * Sets selected macro to attribute.
		 * @private
		 * @param {Object} config Config with attribute name.
		 * @param {Object} macro Selected macro name.
		 */
		_setSelectedMacroToAttribute: function(attributeName, macro) {
			var macroValue = "[#" + macro.leftExpressionColumnPath + "#]";
			this.set(attributeName, null);
			this.set(attributeName, macroValue);
		},

		/**
		 * Handler on click button SenderNameSelectMacroButton.
		 * @private
		 */
		_onSenderNameSelectMacroButtonClick: function() {
			this.openMacrosColumnsPageWithCustomConfig(this, this._setSelectedMacroToAttribute, "SenderName");
		},

		/**
		 * Handler on click button SenderEmailSelectMacroButton.
		 * @private
		 */
		_onSenderEmailSelectMacroButtonClick: function() {
			this.openMacrosColumnsPageWithCustomConfig(this, this._setSelectedMacroToAttribute, "SenderEmail");
		},

		/**
		 * Handler on click button SubjectSelectMacroButton.
		 * @private
		 */
		_onSubjectSelectMacroButtonClick: function() {
			this.openMacrosColumnsPageWithCustomConfig(this, this._setSelectedMacroToAttribute, "SubjectInsertBuffer");
		},

		/**
		 * Handler on click button PreHeaderSelectMacroButton.
		 * @private
		 */
		_onPreHeaderSelectMacroButtonClick: function() {
			this.$PreHeader = this.$PreHeader || '';
			this.openMacrosColumnsPageWithCustomConfig(this, this._setSelectedMacroToAttribute, "PreHeaderInsertBuffer");
		},

		/**
		 * Event handler on UseSpecialHeaders column changing.
		 * @private
		 */
		_onUseSpecialHeadersChanged: function () {
			if (this.$DefaultItem) {
				this.$Subject = this.$DefaultItem.$Subject;
				this.$SenderEmail = this.$DefaultItem.$SenderEmail;
				this.$SenderName = this.$DefaultItem.$SenderName;
				this.$PreHeader = this.$DefaultItem.$PreHeader;
			}
		},

		/**
		 * Event handler on headers changing.
		 * @private
		 * @param {Object} model Column control model.
		 */
		_columnChangeHandler: function (model) {
			if (this.$ActiveLinkedItem) {
				BPMSoft.each(model.changed, function(value, key) {
					this.$ActiveLinkedItem.set(key, value);
				}, this);
			}
		},

		/**
		 * Sets headers values from source view model to this instance.
		 * @private
		 * @param {BPMSoft.PreviewReplicaViewModel} viewModel Source view model.
		 */
		_loadColumnValue: function(viewModel) {
			var useDefaultHeaders = !viewModel.$UseSpecialHeaders && viewModel.$DefaultItem;
			var sourceItem = useDefaultHeaders ? viewModel.$DefaultItem : viewModel;
			this.$BulkEmailId = sourceItem.$BulkEmailId;
			this.$Subject = sourceItem.$Subject;
			this.$SenderEmail = sourceItem.$SenderEmail;
			this.$SenderName = sourceItem.$SenderName;
			this.$PreHeader = sourceItem.$PreHeader;
			this.$UseSpecialHeaders = !useDefaultHeaders;
		},

		/**
		 * Links active view model with current instance.
		 * @private
		 * @param {BPMSoft.PreviewReplicaViewModel} viewModel Active view model.
		 */
		_linkActiveItem: function(viewModel) {
			if (this.$ActiveLinkedItem && this.$ActiveLinkedItem.$ActiveLinkedItem) {
				this.$ActiveLinkedItem.$ActiveLinkedItem = null;
			}
			this.$ActiveLinkedItem = viewModel;
			viewModel.$ActiveLinkedItem = this;
		},

		/**
		 * @private
		 */
		_getArrowIcon: function() {
			return BPMSoft.ImageUrlBuilder.getUrl(this.get("Resources.Images.RightArrowIcon"));
		},

		/**
		 * @private
		 */
		_getLetterIcon: function() {
			return BPMSoft.ImageUrlBuilder.getUrl(this.get("Resources.Images.LetterIcon"));
		},

		/**
		 * @private
		 */
		_getReplicaItemDomAttributes: function() {
			return {
				"replica-item-has-errors": this.hasError()
			};
		},

		/**
		 * @private
		 */
		_getReplicaLabelCaption: function() {
			return this.get("Resources.Strings.ReplicaLabel") + ": " + this.$Caption;
		},

		/**
		 * @private
		 */
		_getReplicaLabelDomAttributes: function () {
			return {
				"title": this._getReplicaLabelCaption()
			};
		},

		/**
		 * @private
		 */
		_getHeaderLabelDomAttribute: function(headerColumnName) {
			return {
				"title": this.get(headerColumnName)
			};
		},

		/**
		 * @private
		 */
		_getSenderDomAttribute: function() {
			return {
				"title": this._getSenderCaption()
			};
		},

		/**
		 * @private
		 */
		_getSenderCaption: function() {
			var senderEmailTemplate = this.get("Resources.Strings.SenderEmailTemplate");
			var email = this.$SenderEmail ? Ext.String.format(senderEmailTemplate, this.$SenderEmail) : "";
			return this.$SenderName + " " + email;
		},

		/**
		 * Validates sender domain to be confirmed and sets result to session cache.
		 * @protected
		 * @param {Object} scope scope.
		 * @param {Function} callback callback function.
		 */
		asyncValidateSenderDomain: function(callback, scope) {
			var domain = this.getSenderDomain();
			var cacheKey = PreviewReplicaViewModelConsts.SenderEmailDomainValidationKeyPrefix + domain;
			var cachedValue = this.cache.getItem(cacheKey);
			if (cachedValue !== undefined) {
				callback.call(scope, cachedValue);
				return;
			}
			var validationConfig = {
				emailId: this.$BulkEmailId,
				senderDomains: [domain]
			};
			BulkEmailSenderValidator.validateDomains(validationConfig, function(result) {
				var isValid = result.Domains && result.Domains.length > 0 
					? result.Domains[0].IsValid
					: false;
				this.cache.setItem(cacheKey, isValid);
				callback.call(scope, isValid);
			}, this);
		},

		/**
		 * Opens macros columns dialog with callback function and custom parameters.
		 * @protected
		 * @param {Object} scope scope.
		 * @param {Function} handler callback function.
		 * @param {Object} config config with custom parameters.
		 */
		openMacrosColumnsPageWithCustomConfig: function(scope, handler, attributeName) {
			var macroDialogConfig = {
				macroSelectedHandler: function(macro) {
					handler.call(scope, attributeName, macro);
				}
			};
			this.sandbox.publish("OpenMacrosDialog", macroDialogConfig);
		},

		/**
		 * Adds view model columns validators.
		 * @inheritdoc BPMSoft.BasePageV2ViewModel#setValidationConfig.
		 * @override
		 */
		initValidationConfig: function() {
			if (this.validateColumns) {
				this.addColumnValidator("SenderName", this._senderNameValidator);
				this.addColumnValidator("SenderEmail", this._senderEmailValidator);
				this.addColumnValidator("Subject", this._subjectValidator);
			}
		},

		/**
		 * Links active view model with current instance and sets headers values.
		 * @param {BPMSoft.PreviewReplicaViewModel} viewModel Active view model.
		 */
		bundle: function(viewModel) {
			this._linkActiveItem(viewModel);
			this._loadColumnValue(viewModel);
		},

		/**
		 * Validate required columns if contains special headers.
		 * @returns {boolean}
		 */
		hasError: function() {
			var hasError = false;
			if (this.$UseSpecialHeaders) {
				hasError = Ext.isEmpty(this.$Subject) || Ext.isEmpty(this.$SenderEmail) || Ext.isEmpty(this.$SenderName);
			}
			return hasError;
		},

		onItemFocused: BPMSoft.emptyFn
	});
});
