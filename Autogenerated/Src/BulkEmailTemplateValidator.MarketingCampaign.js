/**
 * Class to validate bulk email template.
 */
define("BulkEmailTemplateValidator", ["BulkEmailTemplateValidatorResources", "AcademyUtilities",
		"DynamicContentReplicaBuilder", "BulkEmailTemplateHelper", "BulkEmailHelper", "MarketingEnums",
		"MacroUtils","EmailHelperModule", "DynamicContentValidator", "BulkEmailSenderValidator",
		"ContentExporterFactory"],
	function(resources, AcademyUtilities, ReplicaBuilder, BulkEmailTemplateHelper, BulkEmailHelper, MarketingEnums,
			 MacroUtils, EmailHelperModule) {
		/**
		 * @enum
		 * Types of  validation messages.
		 */
		BPMSoft.BulkEmailValidationType = {
			READONLY_STATE: 0,
			MAX_REPLICA_SIZE: 1,
			MAX_CONTRACT_SIZE: 2,
			INVALID_CONTENT: 3,
			DC_ATTRIBUTES_WITHOUT_FILTERS: 4,
			NO_DEFAULT_CONTENT: 5,
			INACTIVE_SENDER_DOMAINS: 6,
			MISSING_UNSUB_URL: 7,
			INVALID_HEADERS: 8,
			INVALID_CONTENT_BUILDER_STATE: 9,
			INCORRECT_EMAILS: 10
		};

		/**
		 * @enum
		 * Levels of  validation.
		 */
		BPMSoft.BulkEmailValidationLevel = {
			ERROR: 0,
			WARNING: 1
		};

		/**
		 * @class BPMSoft.configuration.BulkEmailTemplateValidator
		 */
		Ext.define("BPMSoft.configuration.BulkEmailTemplateValidator", {
			extend: "BPMSoft.BaseViewModel",
			alternateClassName: "BPMSoft.BulkEmailTemplateValidator",

			/**
			 * The mebibyte.
			 * @type {Number}
			 */
			MEBIBYTE: 1048576,

			/**
			 * Current content exporter factory.
			 * @protected
			 * @type {Object}
			 */
			contentExporterFactory: Ext.create("BPMSoft.ContentExporterFactory"),

			/**
			 * Indicating whether validation collects messages or shows messages dialogs.
			 * @type {Boolean}
			 */
			_isCollectMessageMode: false,

			/**
			 * Validation messages array
			 * @protected
			 * @type {Array}
			 */
			validationMessages: null,

			/**
			 * Dictionary of the validation configs, where key is {BPMSoft.BulkEmailValidationType}
			 * and value is object with next fields:
			 * level {BPMSoft.BulkEmailValidationLevel} validationLevel,
			 * getMessage {Function} function returning validation message,
			 * runtimeAction {Function} Function executing if validation called not in collect mode.
			 * @protected
			 * @type {Array}
			 */
			validationTypes: null,

			/**
			 * @inheritdoc BPMSoft.BaseViewModel#constructor
			 * @override
			 */
			constructor: function() {
				this.callParent(arguments);
				this._initResourcesValues(resources);
				this.initValidationTypes();
			},

			/**
			 * Initialize resource values from resource object.
			 * @private
			 * @param resourcesObj View model resources object.
			 */
			_initResourcesValues: function(resourcesObj) {
				var resourcesSuffix = "Resources";
				BPMSoft.each(resourcesObj, function(resourceGroup, resourceGroupName) {
					resourceGroupName = resourceGroupName.replace("localizable", "");
					BPMSoft.each(resourceGroup, function(resourceValue, resourceName) {
						var viewModelResourceName = [resourcesSuffix, resourceGroupName, resourceName].join(".");
						this.set(viewModelResourceName, resourceValue);
					}, this);
				}, this);
			},

			/**
			 * Recursively finds all inline images (base64 format) in replica html.
			 * @private
			 * @param {String} html Replica html.
			 * @param {Array} images List of inline image data.
			 */
			_findInlineImages: function(html, images) {
				var imgRegExp = /(data:image\/[^;]+;base64[^("|')]+)/;
				if (imgRegExp.test(html)) {
					var match = imgRegExp.exec(html);
					var image = match[0];
					if (image) {
						images.push(image);
					}
					var text = html.substr(match.index + 1, html.length);
					this._findInlineImages(text, images);
				}
			},

			/**
			 * Returns duplicated images content size.
			 * @private
			 * @param {Array} images List of all inline images.
			 * @returns {Number} Duplicated images content size.
			 */
			_getDuplicatedImagesSize: function(images) {
				var duplicatesSize = 0;
				var uniqueImages = Ext.Array.unique(images);
				BPMSoft.each(uniqueImages, function(image) {
					var duplicatesCount = this._getDuplicatedImagesCount(images, image);
					duplicatesSize += duplicatesCount * image.length;
				}, this);
				return duplicatesSize;
			},

			/**
			 * Returns count of image duplicates excluding source image.
			 * @private
			 * @param {Array} allImages List of all template images of base64 format.
			 * @param {String} imageToCheck Image to check duplicates.
			 * @returns {Number} Count of duplicates.
			 */
			_getDuplicatedImagesCount: function(allImages, imageToCheck) {
				var count = 0;
				BPMSoft.each(allImages, function(image) {
					if (image === imageToCheck) {
						count += 1;
					}
				}, this);
				return count - 1;
			},

			_showReplicaIsOversizedMessage: function(replicaInfo) {
				var maxTemplateSize = MarketingEnums.MandrillParameters.MAX_TEMPLATE_SIZE;
				var messageTemplate = resources.localizableStrings.MsgMaxReplicaSizeDescription;
				this._showTemplateIsOversizedMessage(replicaInfo.replicaSize, maxTemplateSize, messageTemplate);
			},

			_showTemplateContractIsOversizedMessage: function(contractSize) {
				var maxContractSize = MarketingEnums.MandrillParameters.MAX_TEMPLATE_CONTRACT_SIZE;
				var messageTemplate = resources.localizableStrings.MsgMaxContractSizeDescription;
				this._showTemplateIsOversizedMessage(contractSize, maxContractSize, messageTemplate);
			},

			/**
			 * Checks replica content size.
			 * @private
			 * @param {Object} replica Current template replica to validate.
			 * @param {BPMSoft.BaseContentExporter} exporter Instance of email content exporter.
			 * @returns {{isValid: Boolean, size: Number}} Validation result.
			 */
			_validateMaxReplicaSize: function(replica, exporter) {
				var replicaSize = this.getReplicaSize(replica, exporter);
				var isValid = replicaSize.optimizedSize <= MarketingEnums.MandrillParameters.MAX_TEMPLATE_SIZE;
				if (!isValid) {
					var messageData = {};
					messageData.replicaSize = replicaSize.optimizedSize;
					messageData.replicaCaption = replica.Caption;
					var validationType = BPMSoft.BulkEmailValidationType.MAX_REPLICA_SIZE;
					this._routeValidationMessage(validationType, messageData);
				}
				return {
					isValid: isValid,
					size: replicaSize.fullSize
				};
			},

			/**
			 * Creates message box config for validation fails message.
			 * @param {String} message Message text.
			 * @returns {{caption: *, buttons: *[], scope: BulkEmailTemplateValidator}} Message box config.
			 * @private
			 */
			_getFailedValidationMessageConfig: function(message) {
				var helpButtonCaption = this.get("Resources.Strings.ValidationHelpButtonCaption");
				var messageBoxConfig = {
					caption: message,
					buttons: ["save", "cancel", {
						className: "BPMSoft.Button",
						returnCode: "details",
						style: "default",
						caption: helpButtonCaption
					}],
					scope: this
				};
				return messageBoxConfig;
			},

			/**
			 * Shows message box with validation fails messages.
			 * @private
			 * @param {BPMSoft.Collection} validationResult Collection of messages.
			 * @param {Object} callback Save button handler callback to update record.
			 */
			_showContentValidationMessage: function(validationResult, callback) {
				var fullMessage = "";
				BPMSoft.each(validationResult, function(message) {
					fullMessage += (fullMessage ? "\n" : "") + message;
				});
				var messageConfig = this._getFailedValidationMessageConfig(fullMessage);
				messageConfig.handler = function(code) {
					switch (code) {
						case "save":
							callback.call(this);
							break;
						case "details":
							var academyConfig = {
								contextHelpId: "1876",
								scope: this,
								callback: function(url) {
									window.open(url);
								}
							};
							AcademyUtilities.getUrl(academyConfig);
							break;
						default:
							return;
					}
				};
				BPMSoft.utils.showMessage(messageConfig);
				this.hideBodyMask();
			},

			/**
			 * Finds elements with content recursively.
			 * @private
			 * @param {Object} item Element to find content.
			 * @param {Array} elements List of elements with content.
			 */
			_findElementsWithContent: function(item, elements) {
				if (item && item.hasOwnProperty("Content")) {
					return elements.push(item);
				}
				BPMSoft.each(item.Items, function(el) {
					this._findElementsWithContent(el, elements);
				}, this);
			},

			/**
			 * Validates template element. If validation is not success adds unique error message to result collection.
			 * @private
			 * @param {String} html Element html to validate.
			 * @param {BPMSoft.Collection} result Validation result collection.
			 */
			_validateElementContent: function(html, result) {
				var emailContentValidator = this.createContentValidator();
				emailContentValidator.validate(html, function(validationResult) {
					BPMSoft.each(validationResult, function(el) {
						if (!result.any(function(item) {
								return item === el;
							})) {
							result.add(el);
						}
					}, this);
				}, this);
			},

			/**
			 * Validates template block content and adds validation result to param collection.
			 * @private
			 * @param {BPMSoft.DynamicContentBlockViewModel} block Block item to validate.
			 * @param {BPMSoft.Collection} result Validation result collection.
			 */
			_validateBlockContent: function(block, result) {
				var elementsWithContent = [];
				this._findElementsWithContent(block, elementsWithContent);
				BPMSoft.each(elementsWithContent, function(element) {
					this._validateElementContent(element.Content, result);
				}, this);
			},

			/**
			 * Validates template group content and adds validation result to param collection.
			 * @private
			 * @param {BPMSoft.DynamicContentBlockGroupViewModel} group Group item to validate.
			 * @param {BPMSoft.Collection} result Validation result collection.
			 */
			_validateGroupContent: function(group, result) {
				BPMSoft.each(group.Items, function(block) {
					this._validateBlockContent(block, result);
				}, this);
			},

			/**
			 * Validates email template to contain old tags.
			 * @private
			 * @param {Object} config Template config.
			 * @returns {BPMSoft.Collection} Collection of invalid tag elements.
			 */
			_validateTemplateContent: function(config) {
				var result = Ext.create("BPMSoft.Collection");
				BPMSoft.each(config.Items, function(item) {
					if (item.ItemType === "blockgroup") {
						this._validateGroupContent(item, result);
					} else {
						this._validateBlockContent(item, result);
					}
				}, this);
				return result;
			},

			/**
			 * Returns expected apply unsubscribe link message text.
			 * @private
			 * @param {Boolean} hasLinksInDynamicBlock Is there any unsubscribe link in blockgroup item content.
			 * @returns {String} Message text.
			 */
			_getUnsubscribeLinkMessage: function(hasLinksInDynamicBlock) {
				if (hasLinksInDynamicBlock) {
					return this.get("Resources.Strings.ApplyUnsubscribeLinkWithDynamicBlockMessage");
				}
				return this.get("Resources.Strings.ApplyUnsubscribeLinkMessage");
			},

			/**
			 * Returns email state validation message.
			 * @private
			 * @returns {String} Message text.
			 */
			_getEditNotAllowedValidationMessage: function() {
				return this.get("Resources.Strings.EmailStateValidationMessage");
			},

			/**
			 * Shows message about the need to add a unsubscribe link.
			 * @private
			 * @param {Object} config Config of content items.
			 * @param {Boolean} hasLinksInDynamicBlock Indicates weather config contains unsub url in dynamic blocks.
			 * @param {Function} applyAction Function to execute when Ok button clicked.
			 * @param {Function} cancelAction callback function after modal box canceling
			 * @param scope Executing scope.
			 */
			_showUnsubscribeLinkMessage: function(config, hasLinksInDynamicBlock, applyAction, cancelAction, scope) {
				var message = this._getUnsubscribeLinkMessage(hasLinksInDynamicBlock);
				BPMSoft.utils.showMessage({
					caption: message,
					buttons: ["Ok", "Cancel"],
					handler: function(returnCode) {
						if (returnCode === BPMSoft.controls.MessageBoxEnums.Buttons.OK.returnCode) {
							applyAction.call(scope);
						} else if (cancelAction) {
							cancelAction.call(this);
						}
					},
					scope: this
				});
				this.hideBodyMask();
			},

			/**
			 * Shows message about the need to add a unsubscribe link.
			 * @private
			 * @param {Object} config Config of content items.
			 */
			_showEmailStateValidationMessage: function() {
				var message = this._getEditNotAllowedValidationMessage();
				BPMSoft.utils.showMessage({
					caption: message,
					buttons: ["Ok"],
					handler: function() {
						return;
					},
					scope: this
				});
				this.hideBodyMask();
			},

			/**
			 * Returns email state.
			 * @private
			 * @param {Object} config Config of content items.
			 */
			_getBulkEmailEntity: function(bulkEmailId, callback) {
				var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "BulkEmail"
				});
				esq.addColumn("Status");
				esq.addColumn("Category");
				esq.getEntity(bulkEmailId, function(result) {
					var entity = result.entity;
					callback.call(this, entity);
				}, this);
			},

			_internalValidate: function(config, callback, unsubscribeFixAction, scope) {
				BPMSoft.chain(
					function(next) {
						this.validateErrors(config, next, unsubscribeFixAction, scope);
					},
					function(next) {
						this.validateWarnings(config, next);
					},
					function() {
						callback.call(scope);
					},
					this
				);
			},

			/**
			 * Routes validation result to runtime action or resulting array
			 * @param {BPMSoft.BulkEmailValidationType} type Identifier of validation
			 * @param {Object} result Result of failed validation
			 * @param {Function} callback Callback function
			 * @private
			 */
			_routeValidationMessage: function(type, result, callback) {
				var messageConfig = this.validationTypes[type];
				if (!this._isCollectMessageMode && messageConfig.runtimeAction) {
					messageConfig.runtimeAction.call(this, result, callback);
				} else if (this._isCollectMessageMode) {
					var message = messageConfig.getMessage.call(this, messageConfig.level, result);
					this.validationMessages.push(message);
					if (callback) {
						callback.call(this);
					}
				}
			},

			_checkDCAttributes: function(dcValidator, templateConfig) {
				var incorrectRules = [];
				var isValidAttributes = dcValidator.checkDCAttributesFilters(templateConfig.Attributes, incorrectRules);
				if (!isValidAttributes) {
					var validationType = BPMSoft.BulkEmailValidationType.DC_ATTRIBUTES_WITHOUT_FILTERS;
					this._routeValidationMessage(validationType, incorrectRules);
				}
			},

			_checkDCDefaultContent: function(dcValidator, templateConfig) {
				var hasDefaultBlock = dcValidator.checkDefaultBlocksInGroups(templateConfig.Items);
				if (!hasDefaultBlock) {
					var validationType = BPMSoft.BulkEmailValidationType.NO_DEFAULT_CONTENT;
					this._routeValidationMessage(validationType);
				}
			},

			_validateDCContent: function(templateConfig, callback) {
				var dcValidator = this.createDynamicContentValidator();
				if (!this._isCollectMessageMode) {
					dcValidator.validate(templateConfig, callback, this);
				} else {
					this._checkDCAttributes(dcValidator, templateConfig);
					this._checkDCDefaultContent(dcValidator, templateConfig);
					callback.call(this);
				}
			},

			_getReadOnlyStateMessage: function(validationLevel) {
				return {
					Caption: resources.localizableStrings.MsgReadOnlyStateCaption,
					Description: resources.localizableStrings.MsgReadOnlyStateDescription,
					Level: validationLevel
				};
			},

			_getMaxContractSizeMessage: function(validationLevel, contractSize) {
				var maxContractSize = MarketingEnums.MandrillParameters.MAX_TEMPLATE_CONTRACT_SIZE;
				var overHead = contractSize - maxContractSize;
				var messageTemplate = resources.localizableStrings.MsgMaxContractSizeDescription;
				var description = Ext.String.format(messageTemplate, this.getPrintableSize(overHead),
					this.getPrintableSize(maxContractSize));
				return {
					Caption: resources.localizableStrings.MsgMaxContractSizeCaption,
					Description: description,
					Level: validationLevel
				};
			},

			_getMaxReplicaSizeMessage: function(validationLevel, messageInfo) {
				var maxTemplateSize = MarketingEnums.MandrillParameters.MAX_TEMPLATE_SIZE;
				var overHead = messageInfo.replicaSize - maxTemplateSize;
				var messageCaption = resources.localizableStrings.MsgMaxReplicaSizeCaption;
				var messageTemplate = resources.localizableStrings.MsgMaxReplicaSizeDescription;
				var description = Ext.String.format(messageTemplate, this.getPrintableSize(overHead),
					this.getPrintableSize(maxTemplateSize));
				var caption = Ext.String.format(messageCaption, messageInfo.replicaCaption);
				return {
					Caption: caption,
					Description: description,
					Level: validationLevel
				};
			},

			_getInvalidContentMessage: function(validationLevel, messages) {
				var resultMessage = messages.getItems().join("\n");
				return {
					Caption: resources.localizableStrings.MsgInvalidContentCaption,
					Description: resultMessage,
					Level: validationLevel
				};
			},

			_getNoDefaultContentMessage: function(validationLevel) {
				return {
					Caption: resources.localizableStrings.MsgNoDefaultContentCaption,
					Description: resources.localizableStrings.MsgNoDefaultContentDescription,
					Level: validationLevel
				};
			},

			_getDCAttributesWithoutFiltersMessage: function(validationLevel, invalidReplicas) {
				var names = invalidReplicas.join(", ");
				var description = Ext.String.format(resources.localizableStrings.MsgDCAttributesWithoutFiltersDescription, names);
				return {
					Caption: resources.localizableStrings.MsgDCAttributesWithoutFiltersCaption,
					Description: description,
					Level: validationLevel
				};
			},

			_getInactiveSenderDomainsMessage: function(validationLevel, inactiveDomains) {
				var domains = inactiveDomains.join(", ");
				var description = Ext.String.format(resources.localizableStrings.MsgInactiveSenderDomainsDescription, domains);
				return {
					Caption: resources.localizableStrings.MsgInactiveSenderDomainsCaption,
					Description: description,
					Level: validationLevel
				};
			},

			_getMissingUnsubUrlMessage: function(validationLevel) {
				return {
					Caption: resources.localizableStrings.MsgMissingUnsubUrlCaption,
					Description: resources.localizableStrings.MsgMissingUnsubUrlDescription,
					Level: validationLevel
				};
			},

			_getInvalidHeadersMessage: function(validationLevel, replicaCaptions) {
				return {
					Caption: resources.localizableStrings.MsgInvalidHeadersCaption,
					Description: Ext.String.format(resources.localizableStrings.MsgInvalidHeadersDescription,
						replicaCaptions),
					Level: validationLevel
				};
			},

			/**
			 * @private
			 */
			_getInvalidContentBuilderStateMessage: function(validationLevel) {
				return {
					Caption: resources.localizableStrings.MsgInvalidContentBuilderStateCaption,
					Description: resources.localizableStrings.MsgInvalidContentBuilderStateDescription,
					Level: validationLevel
				};
			},

			/**
			 * @private
			 */
			_getIncorrectEmailsMessage: function(validationLevel, emails) {
				return {
					Caption: resources.localizableStrings.MsgIncorrectEmailsCaption,
					Description: Ext.String.format(resources.localizableStrings.MsgIncorrectEmailsDescription, emails),
					Level: validationLevel
				};
			},

			/**
			 * Shows max size validation error message.
			 * @private
			 * @param {Number} size Current size.
			 * @param {Number} maxSize Max size value.
			 * @param {String} messageTemplate Localizable message template.
			 */
			_showTemplateIsOversizedMessage: function(size, maxSize, messageTemplate) {
				var overHead = size - maxSize;
				var message = Ext.String.format(messageTemplate, this.getPrintableSize(overHead),
					this.getPrintableSize(maxSize));
				BPMSoft.utils.showInformation(message, null, this, null);
				this.hideBodyMask();
			},

			_parseSenderDomains: function (senderEmails) {
				var domains = [];
				BPMSoft.each(senderEmails, function(email) {
					if(!MacroUtils.isValueMacro(email)) {
						domains.push(email.replace(/^.*@/, ""));
					}
				}, this);
				return domains;
			},

			_validateSenderDomains: function(config, callback) {
				var senderEmails = this._getSenderEmails(config.emailHeaders);
				if (Ext.isEmpty(senderEmails)) {
					callback.call(this);
					return;
				}
				var validator = this.createSenderValidator();
				var domains = this._parseSenderDomains(senderEmails);
				var validationConfig = {
					emailId: config.bulkEmailId,
					senderDomains: domains
				};
				validator.validateDomains(validationConfig, function(result) {
					var invalidDomains = result.Domains
						? invalidDomains = this._getInvalidDomains(result)
						: domains;
					if (Ext.isEmpty(invalidDomains)) {
						callback.call(this);
					} else {
						var validationType = BPMSoft.BulkEmailValidationType.INACTIVE_SENDER_DOMAINS;
						this._routeValidationMessage(validationType, invalidDomains, callback);
					}
				}, this);
			},

			_getInvalidDomains: function(validationResult) {
				return validationResult.Domains.filter(function(item) {
					return !item.IsValid;
				})
				.map(function(item) {
					return item.Domain;
				});
			},

			_addUnsubscribeLink: function(config, isAtDynamicBlock, nextCallback, nextCallbackScope, applyAction,
					applyActionScope) {
				var showMessageCancelCallback = null;
				var isCollectMode = this._isCollectMessageMode;
				if (isCollectMode) {
					showMessageCancelCallback = function () {
						var validationType = BPMSoft.BulkEmailValidationType.MISSING_UNSUB_URL;
						this._routeValidationMessage(validationType, null, nextCallback);
					};
				}
				var showMessageOkCallback = function () {
					BulkEmailTemplateHelper.applyUnsubscribeLink(config, applyAction, applyActionScope);
					if (isCollectMode) {
						nextCallback.call(nextCallbackScope);
					}
				};
				this._showUnsubscribeLinkMessage(config, isAtDynamicBlock,
					showMessageOkCallback, showMessageCancelCallback, applyActionScope);
			},

			_getSenderEmails: function(emailHeaders) {
				var senderEmails = [];
				BPMSoft.each(emailHeaders, function(item) {
					var senderEmail = item.$SenderEmail || item.SenderEmail;
					if (senderEmail) {
						senderEmails.push(senderEmail);
					}
				}, this);
				return senderEmails.filter(function(value, index, self) {
					return self.indexOf(value) === index;
				});
			},

			_validateHeaders: function(emailHeaders) {
				var result = true;
				BPMSoft.each(emailHeaders, function (item) {
					if (!item.$SenderEmail || !item.$SenderName || !item.$Subject) {
						return result = false;
					}
				}, this);
				return result && !Ext.isEmpty(emailHeaders);
			},

			/**
			 * @private
			 */
			_containsMjBlock: function(config) {
				var firstChild = config.Items && config.Items[0];
				if (!firstChild) {
					return false;
				}
				switch (firstChild.ItemType) {
					case "blockgroup":
						return this._containsMjBlock(firstChild);
					case "mjblock":
						return true;
					default:
						return false;
				}
			},

			/**
			 * @private
			 */
			_checkContentBuilderState: function(config) {
				return BPMSoft.Features.getIsEnabled("MjmlContentBuilder")
					|| !this._containsMjBlock(config.templateConfig);
			},

			/**
			 * Returns content size for current template replica.
			 * @protected
			 * @param {Object} replica Template replica object.
			 * @param {BPMSoft.BaseContentExporter} exporter Instance of email content exporter.
			 * @returns {Object} Content size object (with sizes in bytes).
			 */
			getReplicaSize: function(replica, exporter) {
				var html = exporter.exportData(replica);
				var images = [];
				this._findInlineImages(html, images);
				var duplicatedImagesSize = this._getDuplicatedImagesSize(images);
				return {
					optimizedSize: html.length - duplicatedImagesSize,
					fullSize: html.length
				};
			},

			/**
			 * Shows base body mask.
			 * @protected
			 */
			showBodyMask: function() {
				BPMSoft.MaskHelper.showBodyMask();
			},

			/**
			 * Hides base body mask.
			 * @protected
			 */
			hideBodyMask: function() {
				BPMSoft.MaskHelper.hideBodyMask();
			},

			/**
			 * Returns instance of email content validator.
			 * @protected
			 * @returns {BPMSoft.EmailContentValidator} Instance of content validator.
			 */
			createContentValidator: function() {
				return new BPMSoft.EmailContentValidator();
			},

			/**
			 * Returns instance of email content exporter.
			 * @protected
			 * @param {Object} config Content builder template config.
			 * @returns {BPMSoft.BaseContentExporter} Instance of content exporter.
			 */
			createEmailContentExporter: function(config) {
				return this.contentExporterFactory.getExporter(config);
			},

			/**
			 * Returns instance of dynamic content validator.
			 * @protected
			 * @returns {BPMSoft.DynamicContentValidator} Instance of dynamic content validator.
			 */
			createDynamicContentValidator: function() {
				return new BPMSoft.DynamicContentValidator();
			},

			/**
			 * Creates instance of sender validator.
			 * @returns {BPMSoft.BulkEmailSenderValidator}
			 */
			createSenderValidator: function() {
				return Ext.create("BPMSoft.BulkEmailSenderValidator");
			},

			/**
			 * Initialises handlers for each validation.
			 * @protected
			 */
			initValidationTypes: function() {
				var validationTypes = {};
				validationTypes[BPMSoft.BulkEmailValidationType.READONLY_STATE] = {
					level: BPMSoft.BulkEmailValidationLevel.ERROR,
					getMessage: this._getReadOnlyStateMessage,
					runtimeAction: this._showEmailStateValidationMessage
				};
				validationTypes[BPMSoft.BulkEmailValidationType.MAX_CONTRACT_SIZE] = {
					level: BPMSoft.BulkEmailValidationLevel.ERROR,
					getMessage: this._getMaxContractSizeMessage,
					runtimeAction: this._showTemplateContractIsOversizedMessage
				};
				validationTypes[BPMSoft.BulkEmailValidationType.MAX_REPLICA_SIZE] = {
					level: BPMSoft.BulkEmailValidationLevel.ERROR,
					getMessage: this._getMaxReplicaSizeMessage,
					runtimeAction: this._showReplicaIsOversizedMessage
				};
				validationTypes[BPMSoft.BulkEmailValidationType.INVALID_CONTENT] = {
					level: BPMSoft.BulkEmailValidationLevel.WARNING,
					getMessage: this._getInvalidContentMessage,
					runtimeAction: this._showContentValidationMessage
				};
				validationTypes[BPMSoft.BulkEmailValidationType.NO_DEFAULT_CONTENT] = {
					level: BPMSoft.BulkEmailValidationLevel.WARNING,
					getMessage: this._getNoDefaultContentMessage,
					runtimeAction: null
				};
				validationTypes[BPMSoft.BulkEmailValidationType.DC_ATTRIBUTES_WITHOUT_FILTERS] = {
					level: BPMSoft.BulkEmailValidationLevel.WARNING,
					getMessage: this._getDCAttributesWithoutFiltersMessage,
					runtimeAction: null
				};
				validationTypes[BPMSoft.BulkEmailValidationType.INACTIVE_SENDER_DOMAINS] = {
					level: BPMSoft.BulkEmailValidationLevel.WARNING,
					getMessage: this._getInactiveSenderDomainsMessage,
					runtimeAction: null
				};
				validationTypes[BPMSoft.BulkEmailValidationType.MISSING_UNSUB_URL] = {
					level: BPMSoft.BulkEmailValidationLevel.ERROR,
					getMessage: this._getMissingUnsubUrlMessage,
					runtimeAction: null
				};
				validationTypes[BPMSoft.BulkEmailValidationType.INVALID_HEADERS] = {
					level: BPMSoft.BulkEmailValidationLevel.ERROR,
					getMessage: this._getInvalidHeadersMessage,
					runtimeAction: null
				};
				validationTypes[BPMSoft.BulkEmailValidationType.INVALID_CONTENT_BUILDER_STATE] = {
					level: BPMSoft.BulkEmailValidationLevel.ERROR,
					getMessage: this._getInvalidContentBuilderStateMessage,
					runtimeAction: null
				};
				validationTypes[BPMSoft.BulkEmailValidationType.INCORRECT_EMAILS] = {
					level: BPMSoft.BulkEmailValidationLevel.ERROR,
					getMessage: this._getIncorrectEmailsMessage,
					runtimeAction: null
				};
				this.validationTypes = validationTypes;
			},

			/**
			 * Validates content size of template and integral dynamic content contract size.
			 * @protected
			 * @param {Object} templateConfig Template config.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Context.
			 */
			validateMaxContentSize: function(templateConfig, callback, scope) {
				var replicas = ReplicaBuilder.generateReplicas(templateConfig);
				var exporter = this.createEmailContentExporter(templateConfig);
				var allReplicasSize = 0;
				var isValid = true;
				BPMSoft.each(replicas, function(replica) {
					var result = this._validateMaxReplicaSize(replica, exporter);
					allReplicasSize += result.size;
					isValid = result.isValid;
					return isValid || this._isCollectMessageMode;
				}, this);
				var validContractSize = allReplicasSize < MarketingEnums.MandrillParameters.MAX_TEMPLATE_CONTRACT_SIZE;
				if (validContractSize) {
					callback.call(scope || this);
				} else {
					var validationType = BPMSoft.BulkEmailValidationType.MAX_CONTRACT_SIZE;
					this._routeValidationMessage(validationType, allReplicasSize, callback);
				}
			},

			/**
			 * Validates template content. If validation success calls updateCallback, otherwise shows message.
			 * @protected
			 * @param {Object} templateConfig Template config to validate.
			 * @param {Function} callback Callback function.
			 */
			validateEmailTemplateContent: function(templateConfig, callback) {
				var result = this._validateTemplateContent(templateConfig);
				if (result.isEmpty()) {
					callback.call(this);
				} else {
					var validationType = BPMSoft.BulkEmailValidationType.INVALID_CONTENT;
					this._routeValidationMessage(validationType, result, callback);
				}
			},

			/**
			 * Validates required headers fields to be filled in.
			 * @param {BPMSoft.PreviewReplicaViewModel[]} emailHeaders Array of headers view models.
			 * @param {Function} callback Callback function.
			 */
			validateHeaders: function(emailHeaders, callback) {
				if (!this._isCollectMessageMode) {
					callback.call(this);
				}
				var isValid = this._validateHeaders(emailHeaders);
				if (isValid) {
					callback.call(this);
				} else {
					var validationType = BPMSoft.BulkEmailValidationType.INVALID_HEADERS;
					this._routeValidationMessage(validationType, isValid, callback);
				}
			},

			/**
			 * Validates email addresses to be in correct format.
			 * @param {Array} emailHeaders Array of all headers.
			 * @param {Function} callback Callback function.
			 */
			validateEmails: function(emailHeaders, callback) {
				var senderEmails = this._getSenderEmails(emailHeaders);
				if (Ext.isEmpty(senderEmails)) {
					callback.call(this);
					return;
				}
				var incorrectEmails = [];
				BPMSoft.each(senderEmails, function(email){
					if (!MacroUtils.isValueMacro(email) && !EmailHelperModule.isEmailValid(email)) {
						incorrectEmails.push(email);
					}
				}, this);
				if (Ext.isEmpty(incorrectEmails)) {
					callback.call(this);
				} else {
					var validationType = BPMSoft.BulkEmailValidationType.INCORRECT_EMAILS;
					this._routeValidationMessage(validationType, incorrectEmails.join(), callback);
				}
			},

			/**
			 * Validates bulk email template with ERROR level issues.
			 * @protected
			 * @param {Object} config Template config to validate.
			 * @param {Function} callback Callback function.
			 * @param {Function} unsubscribeFixAction Function updating config to fix unsubscribe link.
			 * @param {Object} scope Context.
			 */
			validateErrors: function(config, callback, unsubscribeFixAction, scope) {
				BPMSoft.chain(
					function(next) {
						this.validateBulkEmailState(config.bulkEmailId, next);
					},
					function(next) {
						this.validateContentBuilderState(config, next, scope);
					},
					function(next) {
						this.validateUnsubscribeLink(config.templateConfig, next, this, unsubscribeFixAction, scope);
					},
					function(next) {
						this.validateMaxContentSize(config.templateConfig, next);
					},
					function(next) {
						this.validateHeaders(config.emailHeaders, next);
					},
					function(next) {
						this.validateEmails(config.emailHeaders, next);
					},
					function() {
						callback.call(this);
					},
					this
				);
			},

			/**
			 * Validates bulk email template with WARNING level issues.
			 * @protected
			 * @param {Object} config Template config to validate.
			 * @param {Function} callback Callback function.
			 */
			validateWarnings: function(config, callback) {
				BPMSoft.chain(
					function(next) {
						this._validateDCContent(config.templateConfig, next);
					},
					function(next) {
						this.validateEmailTemplateContent(config.templateConfig, next);
					},
					function(next) {
						this._validateSenderDomains(config, next);
					},
					function() {
						callback.call(this);
					},
					this
				);
			},

			/**
			 * Check bulk email state.
			 * @protected
			 * @param {String} bulkEmailId Email unique identifier.
			 * @param {Function} callback Callback function.
			 */
			validateBulkEmailState: function(bulkEmailId, callback) {
				this._getBulkEmailEntity(bulkEmailId, function(bulkEmail) {
					var isEditable = BulkEmailHelper.IsEmailTemplateEditable(bulkEmail.$Status.value,
						bulkEmail.$Category.value);
					if (isEditable) {
						callback();
					} else {
						var validationType = BPMSoft.BulkEmailValidationType.READONLY_STATE;
						this._routeValidationMessage(validationType, isEditable, callback);
					}
				});
			},

			/**
			 * Checks content builder state to be valid.
			 * @protected
			 * @param {Object} config Template config to validate.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Context.
			 */
			validateContentBuilderState: function(config, callback, scope) {
				if (this._checkContentBuilderState(config)) {
					callback.call(scope);
				} else {
					var validationType = BPMSoft.BulkEmailValidationType.INVALID_CONTENT_BUILDER_STATE;
					this._routeValidationMessage(validationType, null, callback);
				}
			},

			/**
			 * Convert size to it printable value.
			 * @param {Number} size Size in bytes.
			 * @returns {Number} Size in kilobytes.
			 */
			getPrintableSize: function(size) {
				var sizeInMegabytes = size / this.MEBIBYTE;
				return Math.round(sizeInMegabytes * 100) / 100;
			},

			/**
			 * Validates bulk email template config.
			 * @public
			 * @param {Object} config Template config to validate.
			 * @param {Function} callback Callback function.
			 * @param {Function} unsubscribeFixAction Function updating config to fix unsubscribe link.
			 * @param {Object} scope Context.
			 */
			validate: function(config, callback, unsubscribeFixAction, scope) {
				this.showBodyMask();
				this._isCollectMessageMode = false;
				this.validationMessages = [];
				this._internalValidate(config, function() {
					callback.call(scope);
					BPMSoft.MaskHelper.hideBodyMask();
				}, unsubscribeFixAction, scope);
			},

			/**
			 * Validates bulk email template config with collecting all messages.
			 * @public
			 * @param {Object} config Template config to validate.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Context.
			 */
			validateInCollectMode: function(config, callback, scope) {
				this.showBodyMask();
				this.validationMessages = [];
				this._isCollectMessageMode = true;
				var validationMessages = this.validationMessages;
				this._internalValidate(config, function() {
					callback.call(scope, validationMessages);
					BPMSoft.MaskHelper.hideBodyMask();
				}, config.applyUnsubscribeAction, scope);
			},

			/**
			 * Check unsubscribe link existing at current template with specific resolve context.
			 * @public
			 * @param {Object} config Template config to be validated.
			 * @param {Function} nextCallback Callback function.
			 * @param {Object} nextCallbackScope Resolve function context.
			 * @param {Function} applyAction Apply unsubscribe url function.
			 * @param {Object} applyActionScope Apply function context.
			 */
			validateUnsubscribeLink: function(config, nextCallback, nextCallbackScope, applyAction, applyActionScope) {
				BulkEmailTemplateHelper.checkNeedUnsubscribeLink(config, function(unsubscribeLinkCheckResult, html) {
					if (unsubscribeLinkCheckResult && !unsubscribeLinkCheckResult.hasLink) {
						var isUnsubLinkAtDynamicBlock = unsubscribeLinkCheckResult.isAtDynamicBlock;
						this._addUnsubscribeLink(config, isUnsubLinkAtDynamicBlock, nextCallback, nextCallbackScope,
							applyAction, applyActionScope);
					} else {
						nextCallback.call(nextCallbackScope, config, html);
					}
				}, this);
			}
		});
		return BPMSoft.configuration.BulkEmailTemplateValidator;
	}
);
