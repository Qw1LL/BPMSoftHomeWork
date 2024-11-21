define("EmailMessagePublisherPage", [],
	function() {
		return {
			entitySchemaName: "Activity",
			messages: {
				/**
				 * @message GetColumnsValues
				 * Returns requested column values.
				 */
				"GetColumnsValues": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},
				/**
				 * @message UpdateEmailSender
				 * Tells that email sender has to be updated.
				 */
				"UpdateEmailSender": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},
			methods: {

				/**
				 * @inheritdoc BPMSoft.EmailMessagePublisherPage#init
				 * @overridden
				 */
				init: function(callback, scope) {
					this.callParent([function() {
						if (this._isCaseSchema()) {
							this.loadRecipients(this.setSenderMailbox, this);
						}
						this.Ext.callback(callback, scope || this);
					}, this]);
				},

				/**
				 * Loads case parent activity recipients.
				 * @private
				 * @param {Function} callback Callback.
				 * @param {Object} scope Scope.
				 */
				loadRecipients: function(callback, scope) {
					let recipients = "";
					const esq = this.createRecipientsEsq();
					esq.getEntityCollection(function(response) {
						if (response.success && response.collection.getCount()) {
							const caseItem = response.collection.getItems()[0];
							const array = [];
							this._addIfHasValue(array, caseItem.get("Recipient"));
							this._addIfHasValue(array, caseItem.get("CC"));
							this._addIfHasValue(array, caseItem.get("BCC"));
							if (array.length > 0) {
								recipients = array.join(";");
							}
						}
						this.set("Recipients", this.isEmpty(recipients) ? this.$Recepient : recipients);
						if (this.Ext.isFunction(callback)) {
							callback.call(scope || this);
						}
					}, this);
				},

				/**
				 * @private
				 */
				_addIfHasValue: function(array, value) {
					if (value) {
						array.push(value);
					}
				},

				/**
				 * @inheritdoc BPMSoft.EmailMessagePublisherPage#setRecipientFromHistoryPage
				 * @overridden
				 */
				setRecipientFromHistoryPage: this.BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.EmailMessagePublisherPage#onGetMacrosData
				 * @overridden
				 */
				onGetMacrosData: function() {
					this.callParent(arguments);
					var recipient = arguments[0].recepient;
					if(!this.Ext.isEmpty(recipient)) {
						this.executeSupportEmailsFilterServiceRequest(recipient,
							this.supportEmailsResponse, this);
					}
				},

				/**
				 * Processes response without support emails.
				 * @protected
				 * @virtual
				 * @param {Object} response Response with filtered emails.
				 */
				supportEmailsResponse: function(response) {
					this.hideBodyMask();
					var emailsWithoutSupportResult = response.GetEmailsWithoutSupportResult;
					if (this.validateResponse(emailsWithoutSupportResult)) {
						var resultEmails = emailsWithoutSupportResult.resultEmails;
						if (this.isFeatureEmailsSearchDisabled()) {
							this.set("Recepient", resultEmails);
						} else {
							this.clearLookup("Recipient");
							this.setRecipient(resultEmails, "Recipient");
						}
					}
				},

				/**
				 * Creates a query to receive case parent activity recipients.
				 * @protected
				 * @virtual
				 * @return {BPMSoft.EntitySchemaQuery} Entity schema query.
				 */
				createRecipientsEsq: function() {
					var caseId = this.getListenerRecordData().relationSchemaRecordId;
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "Case"
					});
					esq.addColumn("ParentActivity.Recepient", "Recipient");
					esq.addColumn("ParentActivity.CopyRecepient", "CC");
					esq.addColumn("ParentActivity.BlindCopyRecepient", "BCC");
					esq.filters.add(esq.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "Id", caseId));
					return esq;
				},

				/**
				 * @inheritdoc BPMSoft.EmailMessagePublisherPage#subscribeMessages
				 * @overridden
				 */
				subscribeMessages: function() {
					this.callParent(arguments);
					this.sandbox.subscribe("UpdateEmailSender", this.onUpdateEmailSender, this, [this.sandbox.id]);
				},

				/**
				 * @inheritdoc BPMSoft.EmailMessagePublisherPage#createInsertQueryWithParameters
				 * @overridden
				 */
				createInsertQueryWithParameters: function() {
					var insert = this.callParent(arguments);
					insert.setParameterValue("IsNotPublished", true, BPMSoft.DataValueType.BOOLEAN);
					return insert;
				},

				/**
				 * @inheritdoc BPMSoft.EmailMessagePublisherPage#setDefaultSenderMailbox
				 * @overridden
				 * @remarks This logic doesn't correspond business requirements anymore.
				 */
				setDefaultSenderMailbox: function(result) {
					if (!this._isCaseSchema()) {
						this.callParent([result]);
					}
				},

				/**
				 * Email sender updating message handler.
				 * @private
				 * @param {Object} config
				 * @param {Guid} config.contactId Case contact identifier.
				 * @param {Guid} config.categoryId Case category identifier.
				 */
				onUpdateEmailSender: function(config) {
					this.obtainMailboxSender(this.get("Recipients"), config.contactId, config.categoryId);
				},

				/**
				 * Sets sender mailbox.
				 * @private
				 */
				setSenderMailbox: function() {
					var recipients = this.get("Recipients");
					var contact = this.getMasterEntityParameterValue("Contact");
					var contactId = contact && contact.value;
					var category = this.getMasterEntityParameterValue("Category");
					var categoryId = category && category.value;
					this.obtainMailboxSender(recipients, contactId, categoryId);
				},

				/**
				 * Returns value of the ViewModel parameter.
				 * @private
				 * @param {String} parameterName Name of the ViewModel parameter.
				 * @return {Object} Value.
				 */
				getMasterEntityParameterValue: function(parameterName) {
					var moduleId = this.getDcmActionsDashboardModuleId();
					var result = this.sandbox.publish("GetColumnsValues", [parameterName], [moduleId]);
					return result[parameterName];
				},

				/**
				 * Gets DCM actions dashboard module identifier.
				 * @private
				 * @return {String} Module identifier.
				 */
				getDcmActionsDashboardModuleId: function() {
					return this.sandbox.id.replace("_" + this.sandbox.moduleName, "");
				},

				/**
				 * Obtains sender mailbox.
				 * @private
				 * @param {String} recipients Email recipients, separated by semicolon.
				 * @param {Guid} contactId Case contact entity identifier.
				 * @param {Guid} categoryId Case category entity identifier.
				 */
				obtainMailboxSender: function(recipients, contactId, categoryId) {
					const config = {
						serviceName: "SenderObtainingService",
						methodName: "ObtainSenderMailbox"
					};
					const data = {
						recipients: recipients || ""
					};
					if (contactId) {
						data.contactId = contactId;
					}
					if (categoryId) {
						data.categoryId = categoryId;
					}
					config.data = data;
					this.callService(config, this.setObtainedSenderMailbox, this);
				},

				/**
				 * Sets obtained sender mailbox as an email sender.
				 * @private
				 * @param {Object} response Sender obtaining service response.
				 */
				setObtainedSenderMailbox: function(response) {
					var result = response.ObtainSenderMailboxResult;
					if (result.success) {
						this._getMailboxByName(result.MailboxName);
					}
				},

				/**
				 * Gets mailbox by name.
				 * @private
				 * @param {String} mailboxName Mailbox name.
				 */
				_getMailboxByName: function(mailboxName) {
					var esq = this.getSenderQuery();
					esq.addColumn("MailboxName");
					var nameFilter = esq.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "MailboxName", mailboxName);
					esq.filters.add(nameFilter);
					esq.getEntityCollection(this._handleMailboxByName, this);
				},

				/**
				 * Checks if relation schema name is Case.
				 * @returns {Boolean} True, if relation schema is Case.
				 * @private
				 */
				_isCaseSchema: function() {
					var recordData = this.getListenerRecordData();
					return recordData && recordData.relationSchemaName === "Case";
				},

				/**
				 * Handles entity schema query response with mailboxes filtered by name.
				 * @private
				 * @param {Object} response Entity schema query response.
				 */
				_handleMailboxByName: function(response) {
					if (response && response.success && response.collection.getCount() === 1) {
						var mailbox = response.collection.first();
						if (mailbox.$UseSignature && !this.isEmpty(mailbox.$Signature)) {
							this.executeSignatureMacrosServiceRequest(mailbox.$Signature, function(processedSignature) {
								mailbox.$Signature = processedSignature.textTemplate || mailbox.$Signature;
								this._setSenderEnum(mailbox);
								this.hideBodyMask();
							}, this);
						} else {
							this._setSenderEnum(mailbox);
						}
					}
				},

				/**
				 * Sets sender mailbox to sender enum.
				 * @private
				 * @param {BPMSoft.Entity} mailbox Mailbox entity.
				 */
				_setSenderEnum: function(mailbox) {
					var lookupValue = this.getLookupValue(mailbox);
					lookupValue = this.getItemWithSignature(lookupValue, mailbox);
					this.set("SenderEnum", lookupValue);
				},

				/**
				 * @inheritdoc BPMSoft.EmailMessagePublisherPage#executeMacrosHelperServiceRequest
				 * @overridden
				 */
				executeMacrosHelperServiceRequest: function(textTemplate, callback, scope) {
					this.showBodyMask();
					var recordData = this.getListenerRecordData();
					var config = {
						serviceName: "InvokableMacrosHelperService",
						methodName: "GetTextTemplate",
						data: {
							entitySchemaName: recordData.relationSchemaName,
							recordId: recordData.relationSchemaRecordId,
							textTemplate: textTemplate
						}
					};
					this.callService(config, callback, scope || this);
				},

				/**
				 * @inheritdoc BPMSoft.EmailMessagePublisherPage#executeMultiLanguageMacrosHelperServiceRequest
				 * @overridden
				 */
				executeMultiLanguageMacrosHelperServiceRequest: function(args, callback, scope) {
					this.showBodyMask();
					var data = this.getListenerRecordData();
					var serviceRequest = this.Ext.create("BPMSoft.MacrosHelperServiceRequest", {
						contractName: "GetMultiLanguageTextTemplate",
						entityId: data.relationSchemaRecordId,
						entityName: data.relationSchemaName,
						templateId: args.id
					});
					serviceRequest.serviceName = "InvokableMacrosHelperService";
					serviceRequest.execute(function(response) {
						callback.call(scope || this, response, args.isReplyTo);
					});
				},

				/**
				 * Calls service for getting emails from recipients without support emails.
				 * @protected
				 * @param {String} emails for service.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function's scope.
				 */
				executeSupportEmailsFilterServiceRequest: function(emails, callback, scope) {
					this.showBodyMask();
					var config = {
						serviceName: "SupportEmailsFilterService",
						methodName: "GetEmailsWithoutSupport",
						data: {
							emails: emails
						}
					};
					this.callService(config, callback, scope || this);
				},

				/**
				 * @inheritdoc BPMSoft.EmailMessagePublisherPage#processResponse
				 * @overridden
				 */
				processResponse: function(response, isReplyTo) {
					if(this.getIsFeatureEnabled("EmailTemplateMultiLanguageInActionDashBoard")) {
						if(response.GetTextTemplateResult) {
							this.callParent([response.GetTextTemplateResult]);
						} else {
							this.callParent(arguments, isReplyTo);
						}
					} else {
						this.callParent([response.GetTextTemplateResult]);
					}
				}
			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	}
);
