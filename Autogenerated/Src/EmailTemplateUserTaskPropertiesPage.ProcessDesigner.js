/**
 * Parent: BaseActivityUserTaskPropertiesPage
 */
define("EmailTemplateUserTaskPropertiesPage", ["BPMSoft", "ProcessUserTaskConstants", "BusinessRuleModule",
		"AcademyUtilities", "ProcessSchemaUserTaskUtilities", "MailboxSyncSettings",
		"EmailTemplateMLangContentBuilderEnumsModule", "NetworkUtilities", "EmailPropertiesPageMixin",
		"ProcessEmailContentBuilder"],
function(BPMSoft, ProcessUserTaskConstants, BusinessRuleModule, AcademyUtilities, ProcessSchemaUserTaskUtilities,
		MailboxSyncSettings, EmailTemplateMLangContentBuilderEnumsModule, NetworkUtilities) {
	return {

		messages: {
			"CloseEmailTemplateBuilder": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			"SetEmailTemplateData": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			"GetEmailTemplateData": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},

		mixins: {
			EmailPropertiesPageMixin: "BPMSoft.EmailPropertiesPageMixin"
		},

		attributes: {
			/**
			 * Sender.
			 * @protected
			 * @type {BPMSoft.DataValueType.MAPPING}
			 */
			"Sender": {
				dataValueType: this.BPMSoft.DataValueType.MAPPING,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				initMethod: "initPropertySilent",
				isRequired: true,
				doAutoSave: true
			},

			/**
			 * Email template.
			 * @protected
			 * @type {BPMSoft.DataValueType.LOOKUP}
			 */
			"EmailTemplateId": {
				dataValueType: this.BPMSoft.DataValueType.LOOKUP,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				doAutoSave: true
			},

			/**
			 * Email template preview body.
			 * @protected
			 * @type {BPMSoft.DataValueType.TEXT}
			 */
			"PreviewBody": {
				dataValueType: this.BPMSoft.DataValueType.TEXT,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Email user template preview body.
			 * @protected
			 * @type {BPMSoft.DataValueType.TEXT}
			 */
			"TemplateBody": {
				dataValueType: this.BPMSoft.DataValueType.TEXT,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				onChange: "setPreviewBody"
			},

			/**
			 * Body template type.
			 * @protected
			 * @type {BPMSoft.DataValueType.LOOKUP}
			 */
			"BodyTemplateType": {
				dataValueType: this.BPMSoft.DataValueType.LOOKUP,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true,
				onChange: "onBodyTemplateTypeChange",
				initMethod: "initBodyTemplateType",
				doAutoSave: true
			},

			/**
			 * Email template entity.
			 * @protected
			 * @type {BPMSoft.DataValueType.MAPPING}
			 */
			"EmailTemplateEntityId": {
				dataValueType: this.BPMSoft.DataValueType.MAPPING,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				initMethod: "initEmailTemplateEntityId",
				doAutoSave: true
			},

			/**
			 * Subject.
			 * @protected
			 * @type {BPMSoft.DataValueType.MAPPING}
			 */
			"Subject": {
				dataValueType: this.BPMSoft.DataValueType.MAPPING,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				initMethod: "initPropertySilent",
				doAutoSave: true,
				onChange: "onSubjectChange"
			},

			/**
			 * Send email type.
			 * @protected
			 * @type {BPMSoft.DataValueType.LOOKUP}
			 */
			"SendEmailType": {
				dataValueType: this.BPMSoft.DataValueType.LOOKUP,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true,
				initMethod: "initSendEmailType",
				doAutoSave: true
			},

			/**
			 * Importance.
			 * @protected
			 * @type {BPMSoft.DataValueType.LOOKUP}
			 */
			"Importance": {
				dataValueType: this.BPMSoft.DataValueType.LOOKUP,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				initMethod: "initImportance",
				doAutoSave: true
			},

			/**
			 * Flag that indicates if is ignore errors.
			 * @protected
			 * @type {BPMSoft.DataValueType.BOOLEAN}
			 */
			"IgnoreErrors": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				initMethod: "initProperty",
				doAutoSave: true
			},

			/**
			 * Collection viewModel's controls for list of recipient.
			 */
			"Recipient": {
				"dataValueType": this.BPMSoft.DataValueType.COLLECTION,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"isCollection": true,
				"value": this.Ext.create("BPMSoft.ObjectCollection")
			},

			/**
			 * Collection viewModel's controls for list of copy recipient.
			 */
			"CopyRecipient": {
				"dataValueType": this.BPMSoft.DataValueType.COLLECTION,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"isCollection": true,
				"value": this.Ext.create("BPMSoft.ObjectCollection")
			},

			/**
			 * Collection viewModel's controls for list of blind copy recipient.
			 */
			"BlindCopyRecipient": {
				"dataValueType": this.BPMSoft.DataValueType.COLLECTION,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"isCollection": true,
				"value": this.Ext.create("BPMSoft.ObjectCollection")
			},

			/**
			 * Collection viewModel's controls for list of attachments.
			 */
			"Attachments": {
				"dataValueType": this.BPMSoft.DataValueType.COLLECTION,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"isCollection": true
			},

			/**
			 * Parameter, which indicates the copy recipient label is visible or hidden.
			 */
			"IsCopyRecipientVisible": {
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": false
			},

			/**
			 * Sign if email template academy link is visible.
			 */
			"IsEmailTemplateAcademyLinkVisible": {
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": false
			},

			/**
			 * Sign if open email template button is visible.
			 */
			"IsOpenEmailTemplateButtonVisible": {
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": false
			},

			/**
			 * Parameter, which indicates the blind copy recipient label is visible or hidden.
			 */
			"IsBlindCopyRecipientVisible": {
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": false
			},

			/**
			 * Parameter, which indicates the content builder visible or hidden.
			 */
			"IsContentBuilderVisible": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: false
			},

			/**
			 * Email template  body.
			 * @protected
			 * @type {BPMSoft.DataValueType.TEXT}
			 */
			"Body": {
				dataValueType: this.BPMSoft.DataValueType.TEXT,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				initMethod: "initPropertySilent",
				doAutoSave: true,
				onChange: "setPreviewBody",
				skipValidation: true
			},

			/**
			 * Email template body config.
			 * @protected
			 * @type {BPMSoft.DataValueType.TEXT}
			 */
			"BodyConfig": {
				dataValueType: this.BPMSoft.DataValueType.TEXT,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				initMethod: "initPropertySilent",
				doAutoSave: true,
				skipValidation: true,
				forceRemove: true
			},

			/**
			 * Parameter, which indicates is email template entity visible or hidden.
			 * @private
			 * @type {Boolean}
			 */
			"IsEmailTemplateEntityIdVisible": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Email template academy page url.
			 */
			"EmailTemplateAcademyUrl": {
				dataValueType: this.BPMSoft.DataValueType.TEXT
			}
		},

		rules: {
			"EmailTemplateId": {
				"RequiredEmailTemplateIdByBodyTemplateType": {
					"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
					"property": BusinessRuleModule.enums.Property.REQUIRED,
					"conditions": [{
						"leftExpression": {
							"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
							"attribute": "BodyTemplateType"
						},
						"comparisonType": this.BPMSoft.ComparisonType.EQUAL,
						"rightExpression": {
							"type": BusinessRuleModule.enums.ValueType.CONSTANT,
							"value": ProcessUserTaskConstants.BODY_TEMPLATE_TYPE.EmailTemplate
						}
					}]
				}
			},
			"Subject": {
				"RequiredSubjectByBodyTemplateType": {
					"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
					"property": BusinessRuleModule.enums.Property.REQUIRED,
					"conditions": [{
						"leftExpression": {
							"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
							"attribute": "BodyTemplateType"
						},
						"comparisonType": this.BPMSoft.ComparisonType.EQUAL,
						"rightExpression": {
							"type": BusinessRuleModule.enums.ValueType.CONSTANT,
							"value": ProcessUserTaskConstants.BODY_TEMPLATE_TYPE.ProcessTemplate
						}
					}]
				}
			}
		},

		modules: {
			"ContentBuilderBody": {
				"config": {
					"schemaName": "ProcessEmailContentBuilder",
					"isSchemaConfigInitialized": true,
					"useHistoryState": false,
					"showMask": true,
					"autoGeneratedContainerSuffix": "-content-builder-body",
					"parameters": {
						"viewModelConfig": {}
					}
				}
			}
		},

		methods: {

			//region Methods: Protected

			/**
			 * @inheritdoc ProcessFlowElementPropertiesPage#constructor
			 * @overridden
			 */
			constructor: function() {
				this.callParent(arguments);
				this.$Attachments = Ext.create("BPMSoft.ObjectCollection");
			},

			/**
			 * Subject change handler.
			 * @protected
			 * @param model View model.
			 * @param subject Subject attribute.
			 */
			onSubjectChange: function(model, subject) {
				const previousSubject = model.previous("Subject");
				const isTemplateSubject = previousSubject && subject
					&& previousSubject.displayValue === subject.displayValue
					&& previousSubject.value !== subject.value
					&& previousSubject.value === null;
				if (isTemplateSubject) {
					subject.value = null;
				}
			},

			/**
			 * @inheritdoc BPMSoft.MenuItemsMappingMixin#getParameterReferenceSchemaUId
			 * @override
			 */
			getParameterReferenceSchemaUId: function(elementParameter) {
				let referenceSchemaUId;
				if (elementParameter.name === "EmailTemplateEntityId") {
					const entityId = this.get("EmailTemplateEntityId");
					referenceSchemaUId = entityId ? entityId.referenceSchemaUId : null;
				} else {
					referenceSchemaUId = MailboxSyncSettings.uId;
				}
				return referenceSchemaUId;
			},

			/**
			 * @inheritdoc ProcessSchemaElementEditable#onElementDataLoad
			 * @overridden
			 */
			onElementDataLoad: function(element, callback, scope) {
				this.callParent([element, function() {
					this.initEmailTemplate(element, callback, scope);
				}, this]);
			},

			/**
			 * @inheritdoc ProcessFlowElementPropertiesPage#initParameters
			 * @protected
			 * @overridden
			 */
			initParameters: function(element) {
				this.callParent(arguments);
				const emailRecipientType = ProcessUserTaskConstants.EMAIL_RECIPIENT_TYPE;
				this.initRecipients(element, emailRecipientType.To);
				this.initRecipients(element, emailRecipientType.Cc);
				this.initRecipients(element, emailRecipientType.Bcc);
				this._initAttachments(element);
				this.addDefaultRecipient();
				this.setPreviewBody();
				this.initEmailTemplateAcademyUrl();
			},

			/**
			 * Sets academy page url for email panel.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			initEmailTemplateAcademyUrl: function() {
				const config = {
					contextHelpCode: "EmailTemplateUserTaskPropertiesPage"
				};
				config.callback = function(url) {
					this.setEmailTemplateAcademyUrl(url);
				}.bind(this);
				AcademyUtilities.getUrl(config);
			},

			/**
			 * Sets email template academy page url to EmailTemplateAcademyUrl attribute.
			 * @protected
			 * @param {String} url Academy page url.
			 */
			setEmailTemplateAcademyUrl: function(url) {
				this.set("EmailTemplateAcademyUrl", url);
			},

			/**
			 * @inheritdoc ProcessFlowElementPropertiesPage#saveParameters
			 * @overridden
			 */
			saveParameters: function(element) {
				this.setDefaultValuesUnusedAttributes();
				const emailRecipientType = ProcessUserTaskConstants.EMAIL_RECIPIENT_TYPE;
				this.saveRecipients(element, emailRecipientType.To);
				this.saveRecipients(element, emailRecipientType.Cc);
				this.saveRecipients(element, emailRecipientType.Bcc);
				this._saveAttachments(element);
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc ProcessFlowElementPropertiesPage#getParameterSourceValue
			 * @overridden
			 */
			getParameterSourceValue: function(parameter) {
				const sourceValue = this.callParent(arguments);
				if (this.getShouldActualizeSource(sourceValue, parameter.dataValueType)) {
					sourceValue.source = BPMSoft.ProcessSchemaParameterValueSource.None;
				}
				return sourceValue;
			},

			/**
			 * Returns the value indicating whether parameter value should be set to 'None'.
			 * @private
			 * @param {Object} sourceValue Source of the parameter value.
			 * @param {BPMSoft.DataValueType} dataValueType Parameter data value type.
			 * @return {Boolean}
			 */
			getShouldActualizeSource: function(sourceValue, dataValueType) {
				return BPMSoft.isLookupDataValueType(dataValueType)
					&& sourceValue.source === BPMSoft.ProcessSchemaParameterValueSource.ConstValue
					&& Ext.isEmpty(sourceValue.value);
			},

			/**
			 * @inheritdoc BaseSchemaViewModel#setValidationConfig
			 * @overridden
			 */
			setValidationConfig: function() {
				this.callParent(arguments);
				this.addColumnValidator("Sender", this.senderValidator);
				this.addColumnValidator("Recipient", this.recipientValidator);
				this.addColumnValidator("Subject", this._subjectValidator);
				this.addColumnValidator("EmailTemplateEntityId", this.emailTemplateEntityValidator);
			},

			/**
			 * @inheritdoc BPMSoft.ActivityConnectionsEditMixin#getVisibleActivityCategory
			 * @overridden
			 */
			getIsActivityTaskVisible: function() {
				return this.getIsManualTypeSendEmailSelected() || this._getIsCreateActivityEnabled();
			},

			/**
			 * Returns email template columns
			 * @protected
			 * @return {string[]}
			 */
			getEmailTemplateColumns: function() {
				return ["Name", "Body", "Object", "Subject"];
			},

			/**
			 * Sets email template attribute.
			 * @protected
			 * @param {String} emailTemplateId The unique identifier of the email template entity.
			 * @param {Function} [callback] Callback function.
			 * @param {BPMSoft.model.BaseViewModel} callback.item Item.
			 * @param {Object} [scope] Callback function context.
			 */
			setEmailTemplateAttribute: function(emailTemplateId, callback, scope) {
				this._getEmailTemplateEntity(emailTemplateId, function(emailTemplateEntity) {
					if (emailTemplateEntity) {
						this.updateEmailTemplateMapping(emailTemplateEntity);
					}
					Ext.callback(callback, scope);
				}, this);
			},

			/**
			 * Open email template page.
			 * @protected
			 */
			openEmailTemplate: function() {
				const recordId = this.get("EmailTemplateId").value;
				if(BPMSoft.Features.getIsEnabled("MultiLanguageContentBuilderEnabled")) {
					this.openMultilingualContentBuilder(recordId);
				} else {
					NetworkUtilities.openEntityWindow({
						entitySchemaName: "EmailTemplate",
						operation: "edit",
						primaryColumnValue: recordId
					});
				}
			},

			/**
			 * Updates email template mapping.
			 * @protected
			 * @param {BPMSoft.model.BaseViewModel} emailTemplate Email template entity.
			 */
			updateEmailTemplateMapping: function(emailTemplate) {
				const referenceSchemaUId = emailTemplate.getLookupValue("Object", true);
				this._initEmailTemplateEntityIdMapping(referenceSchemaUId);
				this._initEmailTemplateIdMapping(emailTemplate);
				this._initSubjectMapping(emailTemplate.get("Subject"));
				this.set("TemplateBody", emailTemplate.get("Body"));
				this.set("IsEmailTemplateEntityIdVisible", !Ext.isEmpty(referenceSchemaUId));
			},

			/**
			 * Init body email type.
			 * @param {BPMSoft.manager.ProcessSchemaParameter} parameter Process parameter.
			 * @protected
			 */
			initBodyTemplateType: function(parameter) {
				const bodyTemplateTypeConfig = this.getBodyTemplateTypeConfig();
				this.initLookupAttribute(parameter, bodyTemplateTypeConfig, null);
			},

			/**
			 * Init send email type.
			 * @param {BPMSoft.manager.ProcessSchemaParameter} parameter Process parameter.
			 * @protected
			 */
			initSendEmailType: function(parameter) {
				const sendEmailTypeConfig = this.getSendEmailTypeConfig();
				this.initLookupAttribute(parameter, sendEmailTypeConfig, null);
			},

			/**
			 * Init email template entity.
			 * @param {BPMSoft.manager.ProcessSchemaParameter} parameter Process parameter.
			 * @protected
			 */
			initEmailTemplateEntityId: function(parameter) {
				this.initProperty(parameter);
				this.setMappingEditValue("EmailTemplateEntityId", {
					isLookupEnabled: false
				});
			},

			/**
			 * Init recipients.
			 * @protected
			 * @param {BPMSoft.manager.ProcessSchemaUserTask} element User task element.
			 * @param {ProcessUserTaskConstants.EMAIL_RECIPIENT_TYPE} emailRecipientType Email recipient type.
			 */
			initRecipients: function(element, emailRecipientType) {
				const recipientList = this.get(emailRecipientType);
				recipientList.clear();
				const parameters = this.findRecipientParameters(element, emailRecipientType);
				parameters.each(function(parameter) {
					this.addRecipient(emailRecipientType, parameter);
				}, this);
			},

			/**
			 * @inheritdoc BaseUserTaskPropertiesPage#getIsActivityModuleEnabled
			 * @overridden
			 */
			getIsActivityModuleEnabled: function() {
				return false;
			},

			/**
			 * @inheritdoc BaseUserTaskPropertiesPage#getIsOptionalActivitySupported
			 * @overridden
			 */
			getIsOptionalActivitySupported: function() {
				return BPMSoft.Features.getIsEnabled("UseOptionalProcessUserTaskActivities")
					&& this.getIsAutoTypeSendEmailSelected();
			},

			/**
			 * @private
			 */
			_getIsCreateActivityEnabled: function() {
				return BPMSoft.Features.getIsEnabled("UseOptionalProcessUserTaskActivities")
					&& this.get("CreateActivity");
			},

			/**
			 * @private
			 */
			_findAttachmentParameters: function(element) {
				const pattern = BPMSoft.process.constants.EMAIL_ATTACHMENT_PARAMETER_TEMPLATE;
				const regExp = new RegExp(pattern);
				return element.parameters.filterByFn(function(parameter) {
					return parameter.getIsDynamic() && !parameter.hasParent() && regExp.test(parameter.name);
				}, this);
			},

			/**
			 * @private
			 */
			_initAttachments: function(element) {
				this.$Attachments.clear();
				const parameters = this._findAttachmentParameters(element);
				parameters.each(this._addAttachment, this);
			},

			/**
			 * Adds default recipient.
			 * @protected
			 */
			addDefaultRecipient: function() {
				const recipientType = ProcessUserTaskConstants.EMAIL_RECIPIENT_TYPE.To;
				const recipientList = this.get(recipientType);
				if (recipientList.isEmpty()) {
					this.addRecipient(recipientType);
				}
			},

			/**
			 * @private
			 */
			_saveAttachments: function(element) {
				this.$Attachments.each(function(viewModel) {
					const name = viewModel.get("Name");
					const parameter = element.findParameterByName(name);
					const mappingValue = viewModel.get("Value");
					parameter.setMappingValue(mappingValue);
					if (Ext.isEmpty(mappingValue.value)) {
						this._removeAttachment(parameter);
					}
				}, this);
			},

			/**
			 * @private
			 */
			_removeAttachment: function(parameter) {
				const attachmentViewModels = this.$Attachments;
				const viewModel = attachmentViewModels.get(parameter.name);
				if (viewModel) {
					const parentParameter = parameter.getParent();
					if (this.removeParameter(parentParameter)) {
						this.$Parameters.removeByKey(parentParameter.name);
						attachmentViewModels.remove(viewModel);
					}
				}
			},

			/**
			 * Saves recipients parameters.
			 * @protected
			 * @param {BPMSoft.manager.ProcessSchemaUserTask} element User task element.
			 * @param {ProcessUserTaskConstants.EMAIL_RECIPIENT_TYPE} emailRecipientType Email recipient type.
			 */
			saveRecipients: function(element, emailRecipientType) {
				const viewModelList = this.get(emailRecipientType);
				viewModelList.each(function(viewModel) {
					const name = viewModel.get("Name");
					const parameter = element.findParameterByName(name);
					const mappingValue = viewModel.get("Value");
					parameter.setMappingValue(mappingValue);
					if (this.Ext.isEmpty(mappingValue.value)) {
						this.removeRecipient(parameter, emailRecipientType);
					}
				}, this);
				this.setVisibleRecipientTitle(emailRecipientType);
			},

			/**
			 * Creates recipient parameter.
			 * @protected
			 * @param {ProcessUserTaskConstants.EMAIL_RECIPIENT_TYPE} emailRecipientType Email recipient type.
			 * @return {BPMSoft.ProcessSchemaParameter}
			 */
			createRecipientParameter: function(emailRecipientType) {
				const processElement = this.get("ProcessElement");
				const parameterMetaData = this.getRecipientParameterConfig(emailRecipientType);
				const elementParameter = Ext.create("BPMSoft.ProcessSchemaParameter", parameterMetaData);
				elementParameter.processFlowElementSchema = processElement;
				processElement.parameters.add(elementParameter.uId, elementParameter);
				return elementParameter;
			},

			/**
			 * Returns config for create recipient parameter.
			 * @protected
			 * @param {ProcessUserTaskConstants.EMAIL_RECIPIENT_TYPE} emailRecipientType Email recipient type.
			 * @return {Object}
			 */
			getRecipientParameterConfig: function(emailRecipientType) {
				const processElement = this.get("ProcessElement");
				const parentSchema = processElement.parentSchema;
				const processSchemaUId = parentSchema.uId;
				const parameters = processElement.parameters;
				const name = this.generateParameterName(parameters, emailRecipientType);
				const caption = this.generateRecipientCaption(parameters, emailRecipientType);
				return {
					uId: BPMSoft.generateGUID(),
					caption: Ext.create("BPMSoft.LocalizableString", {
						cultureValues: caption
					}),
					createdInSchemaUId: processSchemaUId,
					modifiedInSchemaUId: processSchemaUId,
					name: name,
					dataValueType: BPMSoft.DataValueType.MAXSIZE_TEXT,
					sourceValue: {
						source: BPMSoft.ProcessSchemaParameterValueSource.None
					}
				};
			},

			/**
			 * Sets default values for unused attributes.
			 * @protected
			 */
			setDefaultValuesUnusedAttributes: function() {
				const bodyTemplateType = this.get("BodyTemplateType") || {};
				if (bodyTemplateType.value === ProcessUserTaskConstants.BODY_TEMPLATE_TYPE.ProcessTemplate) {
					this.clearEmailTemplateAttribute();
				}
				const sendEmailType = this.get("SendEmailType") || {};
				const isCreateActivity = this._getIsCreateActivityEnabled();
				if (sendEmailType.value === ProcessUserTaskConstants.SEND_EMAIL_TYPE.Auto && !isCreateActivity) {
					this.set("InformationOnStep", null);
					this.clearActivityConnection();
				} else {
					const importanceConfig = this.getImportanceConfig();
					const importance = BPMSoft.findWhere(importanceConfig, {
						value: ProcessUserTaskConstants.EMAIL_IMPORTANCE.Normal
					});
					this.setMappingEditValue("Importance", importance);
				}
			},

			/**
			 * Returns scale of preview email template.
			 * @protected
			 * @return {Number}
			 */
			getPreviewScale: function() {
				const contentSheetWidth = 750;
				const schemaDesignerPropertiesWidth = 356;
				const schemaDesignerPropertiesPadding = 56;
				return (schemaDesignerPropertiesWidth  - schemaDesignerPropertiesPadding) / contentSheetWidth;
			},

			/**
			 * Returns EntitySchemaQuery for schema EmailTemplate.
			 * @protected
			 */
			setOpenEmailTemplateButtonVisibility: function() {
				let emailTemplateId = this.get("EmailTemplateId");
				if (emailTemplateId && !Ext.isEmpty(emailTemplateId.value)) {
					this.set("IsOpenEmailTemplateButtonVisible", true);
					return;
				}
				const processElement = this.get("ProcessElement");
				const emailTemplateParameter = processElement.getParameterByName("EmailTemplateId");
				emailTemplateId = emailTemplateParameter.sourceValue;
				this.set("IsOpenEmailTemplateButtonVisible",
					!Ext.isEmpty(emailTemplateId) && !Ext.isEmpty(emailTemplateId.value));
			},

			/**
			 * Returns EntitySchemaQuery for schema EmailTemplate.
			 * @protected
			 */
			setEmailTemplateAcademyLinkVisibility: function() {
				let emailTemplateId = this.get("EmailTemplateId");
				if (!emailTemplateId) {
					const processElement = this.get("ProcessElement");
					const emailTemplateParameter = processElement.getParameterByName("EmailTemplateId");
					emailTemplateId = emailTemplateParameter.sourceValue;
				}
				if (!emailTemplateId || !emailTemplateId.value || !BPMSoft.isGUID(emailTemplateId.value)) {
					return;
				}
				const esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "EmailTemplateLang"
				});
				esq.addAggregationSchemaColumn("Id", this.BPMSoft.AggregationType.COUNT, "Count");
				esq.filters.addItem(BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "EmailTemplate", emailTemplateId.value));
				esq.getEntityCollection(function(response) {
					if (response.success) {
						this.set("IsEmailTemplateAcademyLinkVisible",
							response.collection.getByIndex(0).get("Count") > 0);
					}
				}, this);
			},

			/**
			 * Open multilingual content builder for template.
			 * @param recordId {String} Id of template.
			 * @protected
			 */
			openMultilingualContentBuilder: function(recordId) {
				const mode = EmailTemplateMLangContentBuilderEnumsModule.ContentBuilderMode.EMAILTEMPLATE;
				const url = EmailTemplateMLangContentBuilderEnumsModule.getContentBuilderUrl(mode, recordId);
				window.open(url);
			},

			//endregion

			//region Methods: Private

			/**
			 * Email template entity validator.
			 * @private
			 * @param {Object} mappingValue Mapping.
			 * @param {String} mappingValue.value Mapping value
			 * @param {String} mappingValue.displayValue Mapping display value.
			 * @return {Object} Validation info.
			 */
			emailTemplateEntityValidator: function(mappingValue) {
				let validationInfo = {
					invalidMessage: ""
				};
				if (this.get("IsEmailTemplateEntityIdVisible")) {
					validationInfo = ProcessSchemaUserTaskUtilities.validateMappingValue(mappingValue);
				}
				return validationInfo;
			},

			/**
			 * Sender validator.
			 * @private
			 * @param {Object} mappingValue Mapping.
			 * @param {String} mappingValue.value Mapping value
			 * @param {String} mappingValue.displayValue Mapping display value.
			 * @return {Object} Validation info.
			 */
			senderValidator: function(mappingValue) {
				let validationInfo = {
					invalidMessage: ""
				};
				if (this.getIsAutoTypeSendEmailSelected()) {
					validationInfo = ProcessSchemaUserTaskUtilities.validateMappingValue(mappingValue);
				}
				return validationInfo;
			},

			/**
			 * Recipient validator
			 * @private
			 * @param {BPMSoft.ObjectCollection} collection Collection of recipients.
			 * @return {Object} Validation info.
			 */
			recipientValidator: function(collection) {
				let isValid = !collection.isEmpty();
				if (isValid) {
					collection.each(function(item) {
						isValid = item.validate();
						return !isValid;
					}, this);
				}
				const message = BPMSoft.Resources.BaseViewModel.columnRequiredValidationMessage;
				return {
					isValid: isValid,
					invalidMessage: isValid ? "" : message
				};
			},

			/**
			 * Clears activity connection.
			 * @private
			 */
			clearActivityConnection: function() {
				const viewModels = this.get("ActivityConnectionViewModels");
				viewModels.each(function(viewModel) {
					viewModel.setMappingEditValue("Value", {
						value: null,
						displayValue: null,
						source: BPMSoft.ProcessSchemaParameterValueSource.None
					});
				}, this);
			},

			/**
			 * Returns type template config.
			 * @private
			 * @return {Object}
			 */
			getBodyTemplateTypeConfig: function() {
				const bodyTemplateType = ProcessUserTaskConstants.BODY_TEMPLATE_TYPE;
				const config = {};
				config[bodyTemplateType.EmailTemplate] = {
					value: bodyTemplateType.EmailTemplate,
					displayValue: this.get("Resources.Strings.TemplateMessageCaption")
				};
				config[bodyTemplateType.ProcessTemplate] = {
					value: bodyTemplateType.ProcessTemplate,
					displayValue: this.get("Resources.Strings.UserMessageCaption")
				};
				return config;
			},

			/**
			 * Returns send type config.
			 * @private
			 * @return {Object}
			 */
			getSendEmailTypeConfig: function() {
				const sendEmailType = ProcessUserTaskConstants.SEND_EMAIL_TYPE;
				const config = {};
				config[sendEmailType.Auto] = {
					value: sendEmailType.Auto,
					displayValue: this.get("Resources.Strings.SendEmailAutoCaption")
				};
				config[sendEmailType.Manual] = {
					value: sendEmailType.Manual,
					displayValue: this.get("Resources.Strings.SendEmailManualCaption")
				};
				return config;
			},

			/**
			 * The event handler for preparing of the data drop-down period.
			 * @private
			 * @param {Object} filter Filters for data preparation.
			 * @param {BPMSoft.Collection} list The data for the drop-down list.
			 */
			onPrepareEmailTypeList: function(filter, list) {
				if (BPMSoft.isEmptyObject(list)) {
					return;
				}
				list.clear();
				list.loadAll(this.getBodyTemplateTypeConfig());
			},

			/**
			 * The event handler for preparing of the data drop-down period.
			 * @private
			 * @param {Object} filter Filters for data preparation.
			 * @param {BPMSoft.Collection} list The data for the drop-down list.
			 */
			onPrepareSendEmailTypeList: function(filter, list) {
				if (BPMSoft.isEmptyObject(list)) {
					return;
				}
				list.clear();
				list.loadAll(this.getSendEmailTypeConfig());
			},

			/**
			 * Init email template attributes.
			 * @private
			 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			initEmailTemplate: function(element, callback, scope) {
				const parameter = element.findParameterByName("EmailTemplateId");
				const value = parameter.getValue();
				if (value) {
					this.setEmailTemplateAttribute(value, function() {
						this.initEmailTemplateChangedHandler(callback, scope);
					}, this);
				} else {
					this.initEmailTemplateChangedHandler(callback, scope);
				}
				if (this.getIsFeatureEnabled("EmailTemplateUserTaskMultiLanguageV2")) {
					this.setOpenEmailTemplateButtonVisibility();
					this.setEmailTemplateAcademyLinkVisibility();
				}
			},

			/**
			 * Init email template event changed handler.
			 * @private
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			initEmailTemplateChangedHandler: function(callback, scope) {
				this.on("change:EmailTemplateId", this.onEmailTemplateChanged, this);
				callback.call(scope);
			},

			/**
			 * Returns EntitySchemaQuery for schema EmailTemplate.
			 * @private
			 * @param {Array} columns Column name list.
			 * @return {BPMSoft.EntitySchemaQuery}
			 */
			getEmailTemplateESQ: function(columns) {
				const element = this.get("ProcessElement");
				const emailTemplateId = element.getParameterByName("EmailTemplateId");
				const esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: emailTemplateId.referenceSchemaName
				});
				columns.forEach(function(columnName) {
					esq.addColumn(columnName);
				}, this);
				esq.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
					"TemplateType", "74FF0CEE-6593-482F-A62F-6DDE6E17AB5E"));
				return esq;
			},

			/**
			 * Returns email template item.
			 * @private
			 * @param {String} emailTemplateId The unique identifier of the email template entity.
			 * @param {Function} callback Callback function.
			 * @param {BPMSoft.model.BaseViewModel} callback.entity Entity.
			 * @param {Object} scope Callback function context.
			 */
			_getEmailTemplateEntity: function(emailTemplateId, callback, scope) {
				const columns = this.getEmailTemplateColumns();
				const esq = this.getEmailTemplateESQ(columns);
				esq.getEntity(emailTemplateId, function(response) {
					callback.call(scope, response.entity);
				}, this);
			},

			/**
			 * Returns list of email templates.
			 * @private
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			getEntityEmailTemplateList: function(callback, scope) {
				const columns = ["Name"];
				const esq = this.getEmailTemplateESQ(columns);
				esq.getEntityCollection(function(response) {
					const entityTemplates = this.Ext.create("BPMSoft.Collection");
					if (response.success) {
						const collection = response.collection;
						collection.each(function(item) {
							const id = item.get("Id");
							const name = item.get("Name");
							entityTemplates.add(id, {
								value: id,
								displayValue: name
							});
						}, this);
					}
					callback.call(scope, entityTemplates);
				}, this);
			},

			/**
			 * The event handler for preparing of the data drop-down of email templates.
			 * @private
			 * @param {Object} filter Filters for data preparation.
			 * @param {BPMSoft.Collection} list The data for the drop-down list.
			 */
			onPrepareEmailTemplateList: function(filter, list) {
				if (BPMSoft.isEmptyObject(list)) {
					return;
				}
				list.clear();
				this.getEntityEmailTemplateList(function(entityTemplates) {
					list.loadAll(entityTemplates);
				}, this);
			},

			/**
			 * The event handler for changed email template.
			 * @private
			 * @param {Backbone.Model} model Model.
			 * @param {Object} emailTemplate Current email template.
			 */
			onEmailTemplateChanged: function(model, emailTemplate) {
				const emailTemplateId = emailTemplate && emailTemplate.value;
				if (!emailTemplateId) {
					return;
				}
				this._clearSubject();
				this.setEmailTemplateAttribute(emailTemplateId);
				if (this.getIsFeatureEnabled("EmailTemplateUserTaskMultiLanguageV2")) {
					this.setOpenEmailTemplateButtonVisibility();
					this.setEmailTemplateAcademyLinkVisibility();
				}
			},

			/**
			 * Clears email template attribute.
			 * @private
			 */
			clearEmailTemplateAttribute: function() {
				this.setMappingEditValue("EmailTemplateEntityId", {
					referenceSchemaUId: null,
					displayValue: null,
					value: null,
					source: BPMSoft.ProcessSchemaParameterValueSource.None
				});
				this.clearEmailTemplate();
			},

			/**
			 * Returns flag that indicates if was selected email template.
			 * @private
			 * @return {Boolean}
			 */
			getIsEmailTemplateSelected: function() {
				const value = this.getLookupValue("BodyTemplateType", true);
				return value === ProcessUserTaskConstants.BODY_TEMPLATE_TYPE.EmailTemplate;
			},

			/**
			 * Opens academy email template page.
			 * @return {Boolean} False value returns to prevent click event propagation.
			 */
			openEmailTemplateAcademyLink: function() {
				const url = this.get("EmailTemplateAcademyUrl");
				const openedWindow = window.open(url, "_blank");
				openedWindow.focus();
				return false;
			},

			/**
			 * Returns flag that indicates if was selected process template.
			 * @private
			 * @return {Boolean}
			 */
			getIsProcessTemplateSelected: function() {
				const value = this.getLookupValue("BodyTemplateType", true);
				return value === ProcessUserTaskConstants.BODY_TEMPLATE_TYPE.ProcessTemplate;
			},

			/**
			 * Returns flag that indicates if Body attribute has value.
			 * @private
			 * @return {Boolean}
			 */
			getHasBody: function() {
				const body = this.get("Body");
				return !Ext.isEmpty(body);
			},

			/**
			 * Returns flag that indicates if Body attribute is Empty.
			 * @private
			 * @return {Boolean}
			 */
			getBodyIsEmpty: function() {
				return !this.getHasBody();
			},

			/**
			 * Returns flag that indicates if was selected body template type.
			 * @private
			 * @return {Boolean}
			 */
			getIsBodyTemplateTypeSelected: function() {
				const value = this.getLookupValue("BodyTemplateType", true);
				return !Ext.isEmpty(value);
			},

			/**
			 * Returns flag that indicates if was selected manual type.
			 * @private
			 * @return {Boolean}
			 */
			getIsManualTypeSendEmailSelected: function() {
				const sendEmailType = this.getLookupValue("SendEmailType", true);
				return sendEmailType === ProcessUserTaskConstants.SEND_EMAIL_TYPE.Manual;
			},

			/**
			 * Returns flag that indicates if was selected auto type.
			 * @private
			 * @return {Boolean}
			 */
			getIsAutoTypeSendEmailSelected: function() {
				const sendEmailType = this.getLookupValue("SendEmailType", true);
				return sendEmailType === ProcessUserTaskConstants.SEND_EMAIL_TYPE.Auto;
			},

			/**
			 * Loads preview module.
			 * @private
			 */
			openPreviewModule: function() {
				const subject = this.get("Subject");
				const html = this.get("PreviewBody");
				const previewWindow = window.open("", "printwin");
				const document = previewWindow.document;
				const title = Ext.String.format("<title>{0}</title>", subject.displayValue);
				/*jshint evil: true */
				document.write(title);
				document.write(html);
				document.close();
				/*jshint evil: false */
			},

			/**
			 * Returns flag that indicates if preview body is visible.
			 * @private
			 * @return {Boolean}
			 */
			getIsPreviewVisible: function() {
				const body = this.get("PreviewBody");
				return this.getIsBodyTemplateTypeSelected() && !Ext.isEmpty(body);
			},

			/**
			 * Returns flag that indicates whether message (Email body is empty) is visible.
			 * @private
			 * @return {Boolean} True if message is visible, else false.
			 */
			getIsBodyMessageVisible: function() {
				return this.getIsProcessTemplateSelected() && this.getBodyIsEmpty();
			},

			/**
			 * Sets preview body.
			 * @private
			 */
			setPreviewBody: function() {
				const isProcessTemplate = this.getIsProcessTemplateSelected();
				const body = isProcessTemplate ? this.get("Body") : this.get("TemplateBody");
				this.set("PreviewBody", body);
			},

			/**
			 * Adds view model to collection of recipient. It creates a parameter if it does not exist.
			 * @private
			 * @param {ProcessUserTaskConstants.EMAIL_RECIPIENT_TYPE} emailRecipientType Email recipient type.
			 * @param {BPMSoft.ProcessSchemaParameter} [parameter] Parameter.
			 */
			addRecipient: function(emailRecipientType, parameter) {
				const recipientList = this.get(emailRecipientType);
				if (!parameter) {
					parameter = this.createRecipientParameter(emailRecipientType);
				}
				const viewModel = this.createParameterViewModel(parameter);
				viewModel.validate();
				this.prepareRecipientViewModel(viewModel);
				this.addMappingValidator(viewModel);
				recipientList.add(parameter.name, viewModel);
				this.setVisibleRecipientTitle(emailRecipientType);
			},

			/**
			 * @private
			 */
			_addAttachment: function(parameter) {
				const parameterViewModel = this.createParameterViewModel(parameter);
				parameterViewModel.validate();
				this.addMappingValidator(parameterViewModel);
				const attachmentList = this.get("Attachments");
				const childViewModel = parameterViewModel.$ItemProperties.first();
				this._prepareParameterViewModel(childViewModel);
				this.addMappingValidator(childViewModel);
				attachmentList.add(childViewModel.$Name, childViewModel);
				if (!this.$Parameters.contains(parameter.name)) {
					this.$Parameters.add(parameter.name, parameterViewModel);
				}
			},

			/**
			 * @private
			 */
			_createAttachment: function() {
				const parameter = this._createAttachmentParameter();
				this._addAttachment(parameter);
			},

			/**
			 * @private
			 */
			_prepareParameterViewModel: function(viewModel) {
				this._prepareParameterDataItemMarker(viewModel);
				viewModel.on("change:Value", this._onParameterValueChanged, this);
				viewModel.getMainRecordMappingConfig = this.getMainRecordMappingConfig;
			},

			/**
			 * Prepares recipient parameter view model.
			 * @protected
			 * @virtual
			 * @param {BPMSoft.BaseViewModel} viewModel Parameter view model.
			 */
			prepareRecipientViewModel: function(viewModel) {
				this._prepareParameterViewModel(viewModel);
			},

			/**
			 * Prepares right data item markers for parameter item.
			 * @private
			 * @param {BPMSoft.BaseViewModel} viewModel Parameter view model.
			 */
			_prepareParameterDataItemMarker: function(viewModel) {
				const parameterName = viewModel.get("Name");
				const dataItemMarker = Ext.String.format("{0}-{1}", parameterName, BPMSoft.generateGUID());
				viewModel.set("DataItemMarker", dataItemMarker);
			},

			/**
			 * On recipient item value change handler.
			 * @protected
			 * @param {Object} model Backbone model.
			 * @param {Object} recipientValue Changed value.
			 */
			onRecipientValueChanged: function(model, recipientValue) {
				this._onParameterValueChanged(model, recipientValue);
			},

			/**
			 * @private
			 */
			_onParameterValueChanged: function(model, recipientValue) {
				const parameterName = model.get("Name");
				const element = this.get("ProcessElement");
				const parameter = element.findParameterByName(parameterName);
				parameter.dataValueType = recipientValue.dataValueType;
				parameter.source = recipientValue.source;
			},

			/**
			 * Add mapping validator.
			 * @private
			 * @param {BPMSoft.ProcessSchemaParameterViewModel} viewModel View model.
			 */
			addMappingValidator: function(viewModel) {
				let columnValidationConfig;
				const columnName = "Value";
				const viewModelColumnValidationConfig = viewModel.validationConfig[columnName];
				if (viewModelColumnValidationConfig) {
					columnValidationConfig = viewModelColumnValidationConfig;
				} else {
					columnValidationConfig = [];
					viewModel.validationConfig[columnName] = columnValidationConfig;
				}
				columnValidationConfig.push(ProcessSchemaUserTaskUtilities.validateMappingValue);
			},

			/**
			 * Shows or hides recipient title.
			 * @private
			 * @param {ProcessUserTaskConstants.EMAIL_RECIPIENT_TYPE} emailRecipientType Email recipient type.
			 */
			setVisibleRecipientTitle: function(emailRecipientType) {
				const recipientList = this.get(emailRecipientType);
				const isRecipientVisible = !recipientList.isEmpty();
				switch (emailRecipientType) {
					case  ProcessUserTaskConstants.EMAIL_RECIPIENT_TYPE.Cc:
						this.set("IsCopyRecipientVisible", isRecipientVisible);
						break;
					case  ProcessUserTaskConstants.EMAIL_RECIPIENT_TYPE.Bcc:
						this.set("IsBlindCopyRecipientVisible", isRecipientVisible);
						break;
					default:
						break;
				}
			},

			/**
			 * Finds recipient parameters.
			 * @private
			 * @param {BPMSoft.manager.ProcessSchemaUserTask} element User task element.
			 * @param {ProcessUserTaskConstants.EMAIL_RECIPIENT_TYPE} emailRecipientType Email recipient type.
			 * @return {*|BPMSoft.Collection}
			 */
			findRecipientParameters: function(element, emailRecipientType) {
				const template = BPMSoft.process.constants.EMAIL_RECIPIENT_PARAMETER_TEMPLATE;
				const pattern = Ext.String.format(template, emailRecipientType);
				const regExp = new RegExp(pattern);
				return element.parameters.filterByFn(function(parameter) {
					return parameter.getIsDynamic() && regExp.test(parameter.name);
				}, this);
			},

			/**
			 * Generates parameter caption for new adds item.
			 * @private
			 * @param {BPMSoft.Collection} collection Collection of parameters.
			 * @param {ProcessUserTaskConstants.EMAIL_RECIPIENT_TYPE} emailRecipientType Email recipient type.
			 * @return {String} Name of new parameter.
			 */
			generateRecipientCaption: function(collection, emailRecipientType) {
				let prefix;
				switch (emailRecipientType) {
					case ProcessUserTaskConstants.EMAIL_RECIPIENT_TYPE.To:
						prefix = this.get("Resources.Strings.RecipientCaption");
						break;
					case ProcessUserTaskConstants.EMAIL_RECIPIENT_TYPE.Cc:
						prefix = this.get("Resources.Strings.CopyRecipientCaption");
						break;
					case ProcessUserTaskConstants.EMAIL_RECIPIENT_TYPE.Bcc:
						prefix = this.get("Resources.Strings.BlindCopyRecipientCaption");
						break;
					default:
						prefix = null;
						break;
				}
				prefix += " ";
				return ProcessSchemaUserTaskUtilities.generateItemUniqueName(prefix, collection,
					function(item, caption) {
						const itemCaption = item.caption;
						return itemCaption && itemCaption.getValue() === caption;
					}
				);
			},

			/**
			 * Generates recipient name for new adds item.
			 * @private
			 * @param {BPMSoft.Collection} collection Collection of parameters.
			 * @param {String} prefix Prefix of new item name.
			 * @return {String} Name of new parameter.
			 */
			generateParameterName: function(collection, prefix) {
				const filterFn = function (item, name) {
					return item.name === name;
				};
				return ProcessSchemaUserTaskUtilities.generateItemUniqueName(prefix, collection, filterFn);
			},

			/**
			 * Removes parameter if it is possible.
			 * @private
			 * @param {BPMSoft.manager.ProcessSchemaParameter} parameter Process parameter.
			 * @return {Boolean}
			 */
			removeParameter: function(parameter) {
				const element = this.get("ProcessElement");
				const process = element.parentSchema;
				let canRemove = false;
				if (process.getAllLazyPropertiesAreLoaded()) {
					const result = process.canRemoveParameter(parameter);
					if (result.canRemove) {
						element.parameters.remove(parameter);
						canRemove = true;
					}
				}
				return canRemove;
			},

			/**
			 * Removes empty recipient.
			 * @private
			 * @param {BPMSoft.manager.ProcessSchemaParameter} parameter Parameter.
			 * @param {ProcessUserTaskConstants.EMAIL_RECIPIENT_TYPE} emailRecipientType Email recipient type.
			 */
			removeRecipient: function(parameter, emailRecipientType) {
				const viewModelList = this.get(emailRecipientType);
				const viewModel = viewModelList.get(parameter.name);
				const Type = ProcessUserTaskConstants.EMAIL_RECIPIENT_TYPE.To;
				if (viewModelList.getCount() > 1 || emailRecipientType !== Type) {
					this.removeParameter(parameter);
					viewModelList.remove(viewModel);
				}
			},

			/**
			 * Shows Content builder (Preview button handler).
			 * @private
			 */
			showContentBuilder: function() {
				this.set("IsContentBuilderVisible", true);
				this.subscribeOnContentBuilderMessages();
			},

			/**
			 * Subscribe on content builder message.
			 * @private
			 */
			subscribeOnContentBuilderMessages: function() {
				this.sandbox.subscribe("CloseEmailTemplateBuilder", this.closeContentBuilder, this);
				this.sandbox.subscribe("GetEmailTemplateData", this.getTemplateConfig, this);
				this.sandbox.subscribe("SetEmailTemplateData", this.onChangeTemplateData, this);
			},

			/**
			 * Returns configuration object for content builder.
			 * @private
			 * @return {Object} config.
			 */
			getTemplateConfig: function() {
				let templateConfig = {};
				if (this.getHasBody()) {
					const bodyConfig = this.get("BodyConfig");
					const body = this.get("Body");
					templateConfig = {
						bodyConfig: bodyConfig,
						body: body
					};
				}
				templateConfig.invokerUId = this.get("uId");
				return templateConfig;
			},

			/**
			 * Closes content builder.
			 * @private
			 */
			closeContentBuilder: function() {
				this.set("IsContentBuilderVisible", false);
			},

			/**
			 * Handler for change template data.
			 * @param {Object} emailTemplateData template data.
			 * @param {String} emailTemplateData.bodyConfig Content builder configuration.
			 * @param {String} emailTemplateData.body Html body.
			 * @private
			 */
			onChangeTemplateData: function(emailTemplateData) {
				this.set("BodyConfig", emailTemplateData.bodyConfig);
				this.set("Body", emailTemplateData.body);
			},

			/**
			 * Handler for change body template type.
			 * @private
			 */
			onBodyTemplateTypeChange: function() {
				this.setPreviewBody();
				this._clearSubject();
				this.clearEmailTemplate();
			},

			/**
			 * Clears Subject field.
			 * @private
			 */
			_clearSubject: function() {
				if (this.getIsProcessTemplateSelected() && this.get("Subject")) {
					this.clearEmailTemplate();
				}
				this.setMappingEditValue("Subject", {
					value: null,
					displayValue: null
				});
			},

			/**
			 * Clears Email template.
			 * @private
			 */
			clearEmailTemplate: function () {
				this.clearEmailTemplateId();
				this.setOpenEmailTemplateButtonVisibility();
			},
			
			/**
			 * Sets email template id to empty value.
			 * @private
			 */
			clearEmailTemplateId: function() {
				this.set("EmailTemplateId", {
					value: null,
					displayValue: null
				});
			},

			/**
			 * @private
			 */
			_subjectValidator: function(value) {
				const validateMappingValue = ProcessSchemaUserTaskUtilities.validateMappingValue;
				const validationInfo = {isValid: true};
				return this.getIsProcessTemplateSelected() ? validateMappingValue(value) : validationInfo;
			},

			/**
			 * @param emailTemplateEntity
			 * @private
			 */
			_initEmailTemplateIdMapping: function(emailTemplateEntity) {
				this.setMappingEditValue("EmailTemplateId", {
					value: emailTemplateEntity.get("Id"),
					displayValue: emailTemplateEntity.get("Name")
				});
			},

			/**
			 * @param referenceSchemaUId
			 * @private
			 */
			_initEmailTemplateEntityIdMapping: function(referenceSchemaUId) {
				const emailTemplateEntityId = this.get("EmailTemplateEntityId");
				if (emailTemplateEntityId.referenceSchemaUId !== referenceSchemaUId) {
					const applyConfig = {
						displayValue: null,
						value: null,
						referenceSchemaUId: referenceSchemaUId
					};
					this.applyParameterMappingEditValue("EmailTemplateEntityId", applyConfig, {skipValidation: true});
				}
			},

			/**
			 * @param emailTemplate
			 * @private
			 */
			_initSubjectMapping: function(templateSubject) {
				if (!this.getLookupValue("Subject", true)) {
					this.setMappingEditValue("Subject", {
						value: null,
						displayValue: templateSubject
					});
				}
			},

			/**
			 * @private
			 */
			_isUseProcessEmailAttachments: function() {
				return this.BPMSoft.Features.getIsEnabled("UseProcessEmailAttachments");
			},

			/**
			 * @private
			 */
			_createAttachmentParameter: function() {
				const processElement = this.get("ProcessElement");
				const parameterConfig = this._getAttachmentParameterConfig();
				const elementParameter = Ext.create("BPMSoft.ProcessSchemaParameter", parameterConfig);
				elementParameter.processFlowElementSchema = processElement;
				processElement.parameters.add(elementParameter.uId, elementParameter);
				return elementParameter;
			},

			/**
			 * @private
			 */
			_getAttachmentParameterConfig: function() {
				const processElement = this.get("ProcessElement");
				const parentSchema = processElement.parentSchema;
				const processSchemaUId = parentSchema.uId;
				const parameters = processElement.parameters;
				const name = this.generateParameterName(parameters, "Attachments");
				const caption = "Attachments collection";
				const fileLocatorParameterConfig = {
					uId: BPMSoft.generateGUID(),
					caption: Ext.create("BPMSoft.LocalizableString", {
						cultureValues: "Attachment"
					}),
					createdInSchemaUId: processSchemaUId,
					modifiedInSchemaUId: processSchemaUId,
					name: name + "FileLocator",
					dataValueType: BPMSoft.DataValueType.FILE_LOCATOR,
					direction: BPMSoft.ProcessSchemaParameterDirection.IN,
					sourceValue: {
						source: BPMSoft.ProcessSchemaParameterValueSource.None
					},
					skipValidation: true,
					forceRemove: true
				};
				return {
					uId: BPMSoft.generateGUID(),
					caption: Ext.create("BPMSoft.LocalizableString", {
						cultureValues: caption
					}),
					createdInSchemaUId: processSchemaUId,
					modifiedInSchemaUId: processSchemaUId,
					name: name,
					dataValueType: BPMSoft.DataValueType.COMPOSITE_OBJECT_LIST,
					direction: BPMSoft.ProcessSchemaParameterDirection.IN,
					sourceValue: {
						source: BPMSoft.ProcessSchemaParameterValueSource.None
					},
					itemProperties: [fileLocatorParameterConfig],
				};
			}

			//endregion

		},

		diff: [
			{
				"operation": "remove",
				"name": "Recommendation"
			},
			{
				"operation": "remove",
				"name": "BaseActivityTaskContainer"
			},
			{
				"operation": "remove",
				"name": "RecommendationLabel"
			},
			{
				"operation": "remove",
				"name": "TitleTaskContainer"
			},
			{
				"operation": "insert",
				"parentName": "UserTaskContainer",
				"propertyName": "items",
				"name": "Sender",
				"values": {
					"layout": { "column": 0, "row": 0, "colSpan": 24 },
					"wrapClass": ["top-caption-control-label"],
					"classes": {
						"labelClass": ["t-title-label-proc"]
					},
					"caption": {
						"bindTo": "Resources.Strings.SenderCaption"
					},
					"isRequired": {
						"bindTo": "getIsAutoTypeSendEmailSelected"
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "UserTaskContainer",
				"propertyName": "items",
				"name": "RecipientItemsContainer",
				"values": {
					"layout": { "column": 0, "row": 1, "colSpan": 24 },
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "RecipientItemsContainer",
				"propertyName": "items",
				"name": "AddRecipientContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["container-list-header"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "AddRecipientContainer",
				"propertyName": "items",
				"name": "RecipientItemsLabel",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.LABEL,
					"classes": {
						"labelClass": ["t-title-label-proc"]
					},
					"caption": {
						"bindTo": "Resources.Strings.RecipientCaption"
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "AddRecipientContainer",
				"propertyName": "items",
				"name": "RecipientItemsToolsButton",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.BUTTON,
					"classes": {
						"menuClass": ["detail-tools-button-menu"]
					},
					"menu": {
						"items": [{
							"tag": ProcessUserTaskConstants.EMAIL_RECIPIENT_TYPE.To,
							"caption": {
								"bindTo": "Resources.Strings.RecipientCaption"
							},
							"click": {
								"bindTo": "addRecipient"
							}
						}, {
							"tag": ProcessUserTaskConstants.EMAIL_RECIPIENT_TYPE.Cc,
							"caption": {
								"bindTo": "Resources.Strings.CopyRecipientCaption"
							},
							"click": {
								"bindTo": "addRecipient"
							}
						}, {
							"tag": ProcessUserTaskConstants.EMAIL_RECIPIENT_TYPE.Bcc,
							"caption": {
								"bindTo": "Resources.Strings.BlindCopyRecipientCaption"
							},
							"click": {
								"bindTo": "addRecipient"
							}
						}]
					},
					"imageConfig": {
						"bindTo": "Resources.Images.AddButtonImage"
					},
					"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT
				}
			},
			{
				"operation": "insert",
				"parentName": "RecipientItemsContainer",
				"propertyName": "items",
				"name": "RecipientContainer",
				"values": {
					"generator": "ConfigurationItemGenerator.generateContainerList",
					"idProperty": "DataItemMarker",
					"collection": "Recipient",
					"defaultItemConfig": {},
					"rowCssSelector": ".paramContainer",
					"classes": {
						"wrapClassName": ["top-recipient-container-list"]
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "RecipientContainer",
				"propertyName": "defaultItemConfig",
				"name": "RecipientItem",
				"values": {
					"id": "item",
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "RecipientItem",
				"propertyName": "items",
				"name": "RecipientItemView",
				"values": {
					"id": "item-view",
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "RecipientItemView",
				"propertyName": "items",
				"name": "RecipientValueContainer",
				"values": {
					"id": "ParameterValueContainer",
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["placeholderOpacity"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "RecipientValueContainer",
				"propertyName": "items",
				"name": "Value",
				"values": {
					"id": "Value",
					"itemType": BPMSoft.ViewItemType.COMPONENT,
					"className": "BPMSoft.MappingEdit",
					"allowInlineEditing": true,
					"tag": {
						"attributeName": "EmailRecipientItem",
						"typeMappingMenu": BPMSoft.process.constants.TypeMappingMenu.EmailRecipientType
					},
					"value": {
						"bindTo": "Value"
					},
					"autocomplete": "RecepientValue",
					"openEditWindow": {
						"bindTo": "openExtendedMappingEditWindow"
					},
					"prepareMenu": {
						"bindTo": "onPrepareMenu"
					},
					"change": {
						"bindTo": "onRecipientValueChanged"
					},
					"menu": {
						"items": {
							"bindTo": "MenuItems"
						}
					},
					"placeholder": {
						"bindTo": "Resources.Strings.MappingPlaceholderCaption"
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "RecipientItemsContainer",
				"propertyName": "items",
				"name": "CopyRecipientItemsLabel",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.LABEL,
					"caption": {
						"bindTo": "Resources.Strings.CopyRecipientCaption"
					},
					"visible": {
						"bindTo": "IsCopyRecipientVisible"
					},
					"classes": {
						"labelClass": ["t-label-proc t-label-proc-param"]
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "RecipientItemsContainer",
				"propertyName": "items",
				"name": "CopyRecipientContainer",
				"values": {
					"generator": "ConfigurationItemGenerator.generateContainerList",
					"idProperty": "DataItemMarker",
					"collection": "CopyRecipient",
					"defaultItemConfig": {},
					"rowCssSelector": ".paramContainer"
				}
			},
			{
				"operation": "insert",
				"parentName": "CopyRecipientContainer",
				"propertyName": "defaultItemConfig",
				"name": "CopyRecipientItem",
				"values": {
					"id": "item",
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "CopyRecipientItem",
				"propertyName": "items",
				"name": "CopyRecipientItemView",
				"values": {
					"id": "item-view",
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "CopyRecipientItemView",
				"propertyName": "items",
				"name": "CopyRecipientValueContainer",
				"values": {
					"id": "ParameterValueContainer",
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["placeholderOpacity"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "CopyRecipientValueContainer",
				"propertyName": "items",
				"name": "Value",
				"values": {
					"id": "Value",
					"itemType": BPMSoft.ViewItemType.COMPONENT,
					"className": "BPMSoft.MappingEdit",
					"tag": {
						"attributeName": "EmailRecipientItem",
						"typeMappingMenu": BPMSoft.process.constants.TypeMappingMenu.EmailRecipientType
					},
					"allowInlineEditing": true,
					"value": {
						"bindTo": "Value"
					},
					"autocomplete": "CopyRecipientValue",
					"openEditWindow": {
						"bindTo": "openExtendedMappingEditWindow"
					},
					"prepareMenu": {
						"bindTo": "onPrepareMenu"
					},
					"change": {
						"bindTo": "onRecipientValueChanged"
					},
					"menu": {
						"items": {
							"bindTo": "MenuItems"
						}
					},
					"placeholder": {
						"bindTo": "Resources.Strings.MappingPlaceholderCaption"
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "RecipientItemsContainer",
				"propertyName": "items",
				"name": "BlindCopyRecipientItemsLabel",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.LABEL,
					"caption": {
						"bindTo": "Resources.Strings.BlindCopyRecipientCaption"
					},
					"visible": {
						"bindTo": "IsBlindCopyRecipientVisible"
					},
					"classes": {
						"labelClass": ["t-label-proc t-label-proc-param"]
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "RecipientItemsContainer",
				"propertyName": "items",
				"name": "BlindCopyRecipientContainer",
				"values": {
					"generator": "ConfigurationItemGenerator.generateContainerList",
					"idProperty": "DataItemMarker",
					"collection": "BlindCopyRecipient",
					"defaultItemConfig": {},
					"rowCssSelector": ".paramContainer"
				}
			},
			{
				"operation": "insert",
				"parentName": "BlindCopyRecipientContainer",
				"propertyName": "defaultItemConfig",
				"name": "BlindCopyRecipientItem",
				"values": {
					"id": "item",
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "BlindCopyRecipientItem",
				"propertyName": "items",
				"name": "BlindCopyRecipientItemView",
				"values": {
					"id": "item-view",
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "BlindCopyRecipientItemView",
				"propertyName": "items",
				"name": "BlindCopyRecipientValueContainer",
				"values": {
					"id": "ParameterValueContainer",
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["placeholderOpacity"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "BlindCopyRecipientValueContainer",
				"propertyName": "items",
				"name": "Value",
				"values": {
					"id": "Value",
					"itemType": BPMSoft.ViewItemType.COMPONENT,
					"className": "BPMSoft.MappingEdit",
					"tag": {
						"attributeName": "EmailRecipientItem",
						"typeMappingMenu": BPMSoft.process.constants.TypeMappingMenu.EmailRecipientType
					},
					"allowInlineEditing": true,
					"value": {
						"bindTo": "Value"
					},
					autocomplete: "BlindCopyRecipientValue",
					"openEditWindow": {
						"bindTo": "openExtendedMappingEditWindow"
					},
					"prepareMenu": {
						"bindTo": "onPrepareMenu"
					},
					"change": {
						"bindTo": "onRecipientValueChanged"
					},
					"menu": {
						"items": {
							"bindTo": "MenuItems"
						}
					},
					"placeholder": {
						"bindTo": "Resources.Strings.MappingPlaceholderCaption"
					}
				}
			},
			{
				"operation": "insert",
				"name": "WhatMessageSendRegionLabel",
				"parentName": "UserTaskContainer",
				"propertyName": "items",
				"values": {
					"layout": { "column": 0, "row": 2, "colSpan": 24 },
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": {
						"bindTo": "Resources.Strings.WhatMessageSendRegionCaption"
					},
					"classes": {
						"labelClass": ["t-title-label-proc"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "BodyTemplateType",
				"parentName": "UserTaskContainer",
				"propertyName": "items",
				"values": {
					"autocomplete": "BodyTemplateType",
					"layout": { "column": 0, "row": 3, "colSpan": 24 },
					"contentType": BPMSoft.ContentType.ENUM,
					"controlConfig": {
						"prepareList": {
							"bindTo": "onPrepareEmailTypeList"
						}
					},
					"labelConfig": {
						"visible": false
					},
					"wrapClass": ["no-caption-control"]
				}
			},
			{
				"operation": "insert",
				"parentName": "UserTaskContainer",
				"propertyName": "items",
				"name": "TemplateMessageContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"layout": { "column": 0, "row": 4, "colSpan": 24 },
					"items": [],
					"visible": {
						"bindTo": "getIsEmailTemplateSelected"
					}
				}
			},
			{
			"operation": "insert",
				"parentName": "TemplateMessageContainer",
				"propertyName": "items",
				"name": "EmailTemplateMessageContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"layout": { "column": 0, "row": 4, "colSpan": 24 },
					"items": [],
					"visible": {
						"bindTo": "getIsEmailTemplateSelected"
					}
				}
			},
			{
				"operation": "insert",
				"name": "EmailTemplateId",
				"parentName": "EmailTemplateMessageContainer",
				"propertyName": "items",
				"values": {
					"layout": { "column": 0, "row": 0, "colSpan": 24 },
					"contentType": BPMSoft.ContentType.ENUM,
					"caption": {
						"bindTo": "Resources.Strings.EmailTemplateCaption"
					},
					"controlConfig": {
						"autocomplete": "MailTemplateId",
						"prepareList": {
							"bindTo": "onPrepareEmailTemplateList"
						}
					},
					"labelConfig": {},
					"visible": {
						"bindTo": "getIsEmailTemplateSelected"
					},
					"wrapClass": ["top-caption-control", "email-template-edit"]
				}
			},
			{
				"operation": "insert",
				"name": "EmailTemplateButton",
				"parentName": "EmailTemplateMessageContainer",
				"propertyName": "items",
				"values": {
					"layout": { "column": 23, "row": 0, "colSpan": 1 },
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"hint": { "bindTo": "Resources.Strings.OpenTemplateButtonHint" },
					"imageConfig": { "bindTo": "Resources.Images.OpenTemplateButtonImage" },
					"classes": {
						"wrapperClass": ["open-email-template-tool-button"]
					},
					"click": {
						"bindTo": "openEmailTemplate"
					},
					"visible": {
						"bindTo": "IsOpenEmailTemplateButtonVisible"
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "TemplateMessageContainer",
				"propertyName": "items",
				"name": "EmailTemplateAcademyLink",
				"values": {
					"itemType": BPMSoft.ViewItemType.HYPERLINK,
					"caption": { "bindTo": "Resources.Strings.EmailTemplateAcademyMessageCaption" },
					"classes": {
						"hyperlinkClass": ["email-template-academy-link"]
					},
					"click": { bindTo: "openEmailTemplateAcademyLink" },
					"markerValue": "EmailTemplateAcademyLink",
					"visible": {
						"bindTo": "IsEmailTemplateAcademyLinkVisible"
					}
				}
			},
			{
				"operation": "insert",
				"name": "EmailTemplateEntityId",
				"parentName": "TemplateMessageContainer",
				"propertyName": "items",
				"values": {
					"layout": { "column": 0, "row": 1, "colSpan": 24 },
					"caption": {
						"bindTo": "Resources.Strings.EmailTemplateEntityCaption"
					},
					"wrapClass": ["top-caption-control"],
					"visible": {
						"bindTo": "IsEmailTemplateEntityIdVisible"
					},
					"isRequired": {
						"bindTo": "IsEmailTemplateEntityIdVisible"
					}
				}
			},
			{
				"operation": "insert",
				"name": "Subject",
				"parentName": "UserTaskContainer",
				"propertyName": "items",
				"values": {
					"controlConfig": {
						"autocomplete": "SubjectMapping"
					},
					"layout": { "column": 0, "row": 5, "colSpan": 24 },
					"caption": {
						"bindTo": "Resources.Strings.SubjectCaption"
					},
					"visible": {
						"bindTo": "getIsBodyTemplateTypeSelected"
					},
					"wrapClass": ["top-caption-control"]
				}
			},
			{
				"operation": "insert",
				"name": "PreviewBodyContainer",
				"parentName": "UserTaskContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"layout": { "column": 0, "row": 6, "colSpan": 24 },
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "PreviewContainer",
				"parentName": "PreviewBodyContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {
						"wrapClassName": ["preview-container"]
					},
					"items": [],
					"visible": {
						"bindTo": "getIsPreviewVisible"
					}
				}
			},
			{
				"operation": "insert",
				"name": "PreviewBodyMaskContainer",
				"parentName": "PreviewContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {
						"wrapClassName": ["previw-body-mask-container"]
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "PreviewButton",
				"parentName": "PreviewContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"imageConfig": {
						"bindTo": "Resources.Images.PreviewButtonImage"
					},
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"click": {
						"bindTo": "openPreviewModule"
					},
					"visible": {
						"bindTo": "getIsEmailTemplateSelected"
					},
					"classes": {
						"wrapperClass": ["preview-button"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "EditButton",
				"parentName": "PreviewContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"imageConfig": {
						"bindTo": "Resources.Images.EditButtonImage"
					},
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"click": {
						"bindTo": "showContentBuilder"
					},
					"visible": {
						"bindTo": "getIsProcessTemplateSelected"
					},
					"classes": {
						"wrapperClass": ["preview-button"]
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "PreviewContainer",
				"propertyName": "items",
				"name": "Body",
				"values": {
					"generator": function() {
						return {
							"className": "BPMSoft.IframeControl",
							"id": "PreviewContentIframe",
							"iframeContent": { "bindTo": "PreviewBody" },
							"wrapClass": ["preview-content-iframe"]
						};
					}
				}
			},
			{
				"operation": "insert",
				"name": "PreviewUserMessageContainer",
				"parentName": "PreviewBodyContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {
						"wrapClassName": ["message-container"]
					},
					"items": [],
					"visible": {
						"bindTo": "getIsBodyMessageVisible"
					}
				}
			},
			{
				"operation": "insert",
				"name": "PreviewTemplateUserMessageLabel",
				"parentName": "PreviewUserMessageContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": {
						"bindTo": "Resources.Strings.EmailBodyEmptyCaption"
					},
					"classes": {
						"labelClass": ["edit-label"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "PreviewTemplateUserMessageBodyMaskContainer",
				"parentName": "PreviewUserMessageContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {
						"wrapClassName": ["previw-body-mask-container"]
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "PreviewUserMessageButton",
				"parentName": "PreviewUserMessageContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"imageConfig": {
						"bindTo": "Resources.Images.EditButtonImage"
					},
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"click": {
						"bindTo": "showContentBuilder"
					},
					"classes": {
						"wrapperClass": ["preview-button"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "HowSendEmailLabel",
				"parentName": "UserTaskContainer",
				"propertyName": "items",
				"values": {
					"layout": { "column": 0, "row": 7, "colSpan": 24 },
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": {
						"bindTo": "Resources.Strings.HowSendEmailCaption"
					},
					"classes": {
						"labelClass": ["t-title-label-proc"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "SendEmailType",
				"parentName": "UserTaskContainer",
				"propertyName": "items",
				"values": {
					"autocomplete": "SendMailType",
					"layout": { "column": 0, "row": 8, "colSpan": 24 },
					"contentType": BPMSoft.ContentType.ENUM,
					"controlConfig": {
						"prepareList": {
							"bindTo": "onPrepareSendEmailTypeList"
						}
					},
					"labelConfig": {
						"visible": false
					},
					"wrapClass": ["no-caption-control"]
				}
			},
			{
				"operation": "merge",
				"name": "caption",
				"values": {
					"autocomplete": "MailCaption"
				}
			},
			{
				"operation": "insert",
				"name": "ManualSendContainer",
				"propertyName": "items",
				"parentName": "UserTaskContainer",
				"className": "BPMSoft.GridLayoutEdit",
				"values": {
					"layout": { "column": 0, "row": 9, "colSpan": 24 },
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": [],
					"visible": {
						"bindTo": "getIsManualTypeSendEmailSelected"
					}
				}
			},
			{
				"operation": "merge",
				"name": "PerformerAssignmentContainer",
				"values": {
					"layout": { "column": 0, "row": 0, "colSpan": 24 }
				}
			},
			{
				"operation": "move",
				"name": "PerformerAssignmentContainer",
				"parentName": "ManualSendContainer",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "InformationOnStep",
				"parentName": "ManualSendContainer",
				"propertyName": "items",
				"values": {
					"controlConfig": {
						"autocomplete": "InformationOnStep",
					},
					"layout": { "column": 0, "row": 1, "colSpan": 24 },
					"caption": {
						"bindTo": "Resources.Strings.InformationOnStepCaption"
					},
					"wrapClass": ["top-caption-control"]
				}
			},
			{
				"operation": "insert",
				"name": "AutoSendContainer",
				"propertyName": "items",
				"parentName": "UserTaskContainer",
				"className": "BPMSoft.GridLayoutEdit",
				"values": {
					"layout": { "column": 0, "row": 10, "colSpan": 24 },
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": [],
					"visible": {
						"bindTo": "getIsAutoTypeSendEmailSelected"
					}
				}
			},
			{
				"operation": "insert",
				"name": "Importance",
				"parentName": "AutoSendContainer",
				"propertyName": "items",
				"values": {
					"layout": { "column": 0, "row": 0, "colSpan": 24 },
					"contentType": BPMSoft.ContentType.ENUM,
					"visible": {
						"bindTo": "getIsAutoTypeSendEmailSelected"
					},
					"controlConfig": {
						"autocomplete": "MailImportance",
						"prepareList": {
							"bindTo": "onPrepareImportanceList"
						}
					},
					"caption": {
						"bindTo": "Resources.Strings.ImportanceCaption"
					},
					"wrapClass": ["top-caption-control"]
				}
			},
			{
				"operation": "insert",
				"name": "IgnoreErrors",
				"parentName": "AutoSendContainer",
				"propertyName": "items",
				"values": {
					"layout": { "column": 0, "row": 1, "colSpan": 24 },
					"caption": { "bindTo": "Resources.Strings.IgnoreErrorsCaption" },
					"wrapClass": ["t-checkbox-control"]
				}
			},
			{
				"operation": "insert",
				"name": "ContentBuilderMaskContainer",
				"parentName": "RecepientRegionContainer",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {
						"wrapClassName": ["content-builder-mask-container"]
					},
					"visible": {"bindTo": "IsContentBuilderVisible"},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "ContentBuilderBody",
				"parentName": "RecepientRegionContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.MODULE,
					"classes": {
						"wrapClassName": "content-builder-body-container"
					},
					"visible": { "bindTo": "IsContentBuilderVisible" },
					"items": []
				}
			},
			{
				"operation": "merge",
				"name": "ActivityConnectionLabel",
				"values": {
					"caption": { "bindTo": "Resources.Strings.EmailLinksCaption" }
				}
			},
			{
				"operation": "insert",
				"parentName": "UserTaskContainer",
				"propertyName": "items",
				"name": "AttachmentsContainer",
				"values": {
					"layout": { "column": 0, "row": 11, "colSpan": 24 },
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"visible": {
						"bindTo": "_isUseProcessEmailAttachments"
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "AttachmentsContainer",
				"propertyName": "items",
				"name": "AddAttachmentContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["container-list-header"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "AddAttachmentContainer",
				"propertyName": "items",
				"name": "AddAttachmentItemsLabel",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.LABEL,
					"classes": {
						"labelClass": ["t-title-label-proc"]
					},
					"caption": {
						"bindTo": "Resources.Strings.AddAttachmentCaption"
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "AddAttachmentContainer",
				"propertyName": "items",
				"name": "AddAttachmentItemsToolsButton",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.BUTTON,
					"classes": {
						"menuClass": ["detail-tools-button-menu"]
					},
					"imageConfig": {
						"bindTo": "Resources.Images.AddButtonImage"
					},
					"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"click": {
						"bindTo": "_createAttachment"
					},
				}
			},
			{
				"operation": "insert",
				"parentName": "AttachmentsContainer",
				"propertyName": "items",
				"name": "AttachmentItemContainer",
				"values": {
					"generator": "ConfigurationItemGenerator.generateContainerList",
					"idProperty": "DataItemMarker",
					"collection": "Attachments",
					"defaultItemConfig": {},
					"rowCssSelector": ".paramContainer",
					"classes": {
						"wrapClassName": ["top-recipient-container-list"]
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "AttachmentItemContainer",
				"propertyName": "defaultItemConfig",
				"name": "AttachmentItem",
				"values": {
					"id": "item",
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "AttachmentItem",
				"propertyName": "items",
				"name": "AttachmentItemView",
				"values": {
					"id": "item-view",
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "AttachmentItemView",
				"propertyName": "items",
				"name": "AttachmentValueContainer",
				"values": {
					"id": "ParameterValueContainer",
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["placeholderOpacity"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "AttachmentValueContainer",
				"propertyName": "items",
				"name": "Value",
				"values": {
					"id": "Value",
					"itemType": BPMSoft.ViewItemType.COMPONENT,
					"className": "BPMSoft.MappingEdit",
					"value": {
						"bindTo": "Value"
					},
					"openEditWindow": {
						"bindTo": "openExtendedMappingEditWindow"
					},
					"prepareMenu": {
						"bindTo": "onPrepareMenu"
					},
					"menu": {
						"items": {
							"bindTo": "MenuItems"
						}
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "UserTaskContainer",
				"propertyName": "items",
				"name": "useBackgroundMode",
				"values": {
					"wrapClass": ["t-checkbox-control"],
					"visible": {
						"bindTo": "canUseBackgroundProcessMode"
					},
					"layout": { "column": 0,"row": 12,"colSpan": 24 }
				}
			},
			{
				"operation": "move",
				"name": "CreateActivity",
				"parentName": "UserTaskContainer",
				"propertyName": "items"
			},
			{
				"operation": "merge",
				"name": "CreateActivity",
				"values": {
					"layout": { "column": 0, "row": 13, "colSpan": 24 }
				}
			}
		]
	};
});
