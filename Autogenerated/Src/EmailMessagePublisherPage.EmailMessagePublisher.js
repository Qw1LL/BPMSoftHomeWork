define("EmailMessagePublisherPage", ["EmailMessagePublisherPageResources", "LookupUtilities", "EmailImageMixin",
			"ConfigurationConstants", "MaskHelper", "EmailActionsMixin", "MacrosUtilities",
			"ExtendedHtmlEditModuleUtilities", "ExtendedHtmlEditModule", "MessagePublisherAttachmentUtilities",
			"MacrosHelperServiceRequest", "EntityResponseValidationMixin", "css!HtmlEditModule",
			"css!EmailMessagePublisherModule"],
		function(resources, LookupUtilities, EmailImageMixin, ConfigurationConstants, MaskHelper) {
			return {
				entitySchemaName: "Activity",
				mixins: {
					MacrosUtilities: "BPMSoft.MacrosUtilities",
					ExtendedHtmlEditModuleUtilities: "BPMSoft.ExtendedHtmlEditModuleUtilities",
					MessagePublisherAttachmentUtilities: "BPMSoft.MessagePublisherAttachmentUtilities",
					EntityResponseValidationMixin: "BPMSoft.EntityResponseValidationMixin",

					/**
					 * @class BPMSoft.EmailImageMixin
					 * Mixin for inserting email images.
					 */
					EmailImageMixin: "BPMSoft.EmailImageMixin",
					/**
					 * @class BPMSoft.EmailActionsMixin
					 * Mixin for actions with email.
					 */
					EmailActionsMixin: "BPMSoft.EmailActionsMixin"
				},
				messages: {
					/**
					 * Email signature.
					 */
					"Signature": {
						dataValueType: this.BPMSoft.DataValueType.TEXT,
						value: ""
					},
					/**
					 * Flag that indicates email signature is being used.
					 */
					"UseSignature": {
						dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
						value: false
					},
					/**
					 * @message LaunchLoadEmailData
					 *  Message that launches loading email data.
					 */
					"LaunchLoadEmailData": {
						mode: this.BPMSoft.MessageMode.PTP,
						direction: this.BPMSoft.MessageDirectionType.PUBLISH
					},
					/**
					 * @message SendListenerEmailData
					 * Returns email data.
					 */
					"SendListenerEmailData": {
						mode: this.BPMSoft.MessageMode.PTP,
						direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
					},
					/**
					 * @message PushHistoryState
					 * Returns history state.
					 */
					"PushHistoryState": {
						"mode": BPMSoft.MessageMode.BROADCAST,
						"direction": BPMSoft.MessageDirectionType.PUBLISH
					},
					/**
					 * @message GetPropertiesByName
					 * Returns values of target columns.
					 */
					"GetPropertiesByName": {
						"mode": BPMSoft.MessageMode.PTP,
						"direction": BPMSoft.MessageDirectionType.PUBLISH
					},

					/**
					 * @message SendMacrosData
					 * Informs publisher that loaded EmailTemplate from history page
					 */
					"SendMacrosData": {
						mode: this.BPMSoft.MessageMode.PTP,
						direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
					},

					/**
					 * @message EmailMessagePageLoaded
					 * Informs section that tab was loaded
					 */
					"EmailMessagePageLoaded": {
						mode: this.BPMSoft.MessageMode.PTP,
						direction: this.BPMSoft.MessageDirectionType.PUBLISH
					},

					/**
					 * @message MacroSelected
					 */
					"MacroSelected": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					}

				},
				attributes: {
					/**
					 * Shows whether Title field is enabled.
					 */
					IsTitleEnabled: {
						dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
						value: true
					},

					/**
					 * Email body from reply message.
					 */
					InReplyToEmailBody: {
						dataValueType: this.BPMSoft.DataValueType.TEXT,
						value: ""
					},

					/**
					 * Expandable entities list.
					 */
					entitiesList: {
						"dataValueType": this.BPMSoft.DataValueType.COLLECTION,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},

					/**
					 * Senders list.
					 */
					"SenderEnum": {
						dataValueType: this.BPMSoft.DataValueType.ENUM,
						type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						caption: {
							"bindTo": "Resources.Strings.SenderCaption"
						},
						"isRequired": true
					},

					/**
					 * Senders list which is displayed when lookup is opened.
					 */
					"SenderEnumList": {
						dataValueType: this.BPMSoft.DataValueType.ENUM,
						type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						isCollection: true
					},

					/**
					 * Recepient.
					 */
					"Recepient": {
						dataValueType: this.BPMSoft.DataValueType.TEXT,
						dependencies: [
							{
								columns: ["Contact"],
								methodName: "onContactChange"
							}
						]
					},

					/**
					 * Visibility of Copy button.
					 */
					"isCopyRecipientVisible": {
						dataValueType: this.BPMSoft.DataValueType.BOOLEAN
					},

					/**
					 * Visibility of Blind copy button.
					 */
					"isBlindCopyRecipientVisible": {
						dataValueType: this.BPMSoft.DataValueType.BOOLEAN
					},

					/**
					 * MailboxSyncSettings items, avaliable for send.
					 */
					"SendersCollection": {
						dataValueType: this.BPMSoft.DataValueType.COLLECTION
					}
				},
				methods: {

					//region methods: private

					/**
					 * Reverses the visibility of the field.
					 * @private
					 */
					fieldVisibleToggleClick: function() {
						if (arguments && arguments.length) {
							var tag = arguments[arguments.length - 1];
							this.set(tag, !this.get(tag));
						}
					},

					/**
					 * Initializes collection.
					 * @private
					 */
					initCollection: function() {
						var collectionName = "FilesList";
						var collection = this.get(collectionName);
						if (!collection) {
							collection = this.Ext.create("BPMSoft.Collection");
							this.set(collectionName, collection);
						} else {
							collection.clear();
						}
					},

					/**
					 * Initializes attachments view data (viewModelClass and viewConfig).
					 * @private
					 * @param {Function} callback Callback function.
					 * @param {Object} scope Callback function scope.
					 */
					initAttachmentsViewData: function(callback, scope) {
						var schemaName = "EmailPublisherAttachmentPage";
						var builderConfig = {
							schemaName: schemaName,
							entitySchemaName: null,
							profileKey: schemaName
						};
						var schemaBuilder = this.Ext.create("BPMSoft.SchemaBuilder");
						schemaBuilder.build(builderConfig, function(viewModelClass, viewConfig) {
							this.set("AttachmentViewModelClass", viewModelClass);
							this.set("AttachmentViewConfig", viewConfig);
							this.Ext.callback(callback, scope || this);
						}, this);
					},

					/**
					 * Returns MailboxSyncSettings items, avaliable for send.
					 * @private
					 * @param {Function} callback Callback function.
					 * @param {Object} scope Callback function scope.
					 */
					_getSendersCollection: function(callback, scope) {
						if (!this.isEmpty(this.$SendersCollection)) {
							return this.Ext.callback(callback, scope || this, [this.$SendersCollection]);
						}
						var selectMailboxSyncSettings = this.getSenderQuery();
						selectMailboxSyncSettings.getEntityCollection(function(result) {
							const collection = result.collection || this.Ext.create("BPMSoft.Collection");
							this.processMacrosesInSignatures(collection, function() {
								this.$SendersCollection = collection;
								this.Ext.callback(callback, scope || this, [collection]);
							}, this);
						}, this);
					},

					//endregion

					/**
					 * @inheritdoc BPMSoft.BaseMessagePublisherPage#getPublishData
					 * @overridden
					 */
					getPublishData: function() {
						var publishData = [];
						var config = this.getListenerRecordData();
						var relationSchemaRecordId = config.relationSchemaRecordId;
						publishData.push({"Key": config.relationColumnName + "Id", "Value": relationSchemaRecordId});
						var body = this.get("Body");
						var title = this.get("Title");
						if (config && config.additionalInfo.title) {
							title = config.additionalInfo.title;
						}
						var sender = this.get("Sender");
						var recepient = this.get("Recepient");
						var copyRecepient = this.get("CopyRecepient");
						var blindCopyRecepient = this.get("BlindCopyRecepient");
						publishData.push(
								{"Key": "Body", "Value": body},
								{"Key": "Title", "Value": title},
								{"Key": "Sender", "Value": sender},
								{"Key": "Recepient", "Value": recepient},
								{"Key": "CopyRecepient", "Value": copyRecepient},
								{"Key": "BlindCopyRecepient", "Value": blindCopyRecepient},
								{"Key": "Id", "Value": this.get("PrimaryColumnValue")}
						);
						return publishData;
					},

					/**
					 * Returns email data for Recipient.
					 * @private
					 * @return {Object} Current email.
					 */
					loadEmailData: function() {
						return this.sandbox.publish("LaunchLoadEmailData", null, [this.sandbox.id]);
					},

					/**
					 * @inheritdoc BasePageV2#onRender
					 * @overridden
					 */
					onRender: function() {
						this.callParent(arguments);
						this.loadEmailData();
					},

					/**
					 * @inheritdoc BPMSoft.BaseMessagePublisherPage#onPublishButtonClick
					 * @overridden
					 */
					onPublishButtonClick: function() {
						if (this.checkSenderBeforeSend()) {
							MaskHelper.ShowBodyMask();
							this.callParent(arguments);
						}
					},

					/**
					 * @inheritdoc BPMSoft.MessagePublisherAttachmentUtilities#onComplete
					 * @overridden
					 */
					onComplete: function() {
						this.mixins.MessagePublisherAttachmentUtilities.onComplete.call(this);
						this.onDropzoneHover(false);
					},

					/**
					 * @inheritdoc BPMSoft.BaseMessagePublisherPage#onPublished
					 * @overridden
					 */
					onPublished: function() {
						this.callParent(arguments);
						var body = "";
						body = this.getItemWithSignature(body, this);
						this.set("Body", body);
						this.set("Title", "");
						this.set("Recepient", "");
						this.set("CopyRecepient", "");
						this.set("BlindCopyRecepient", "");
						var listItems = this.get("FilesList");
						listItems.clear();
						MaskHelper.HideBodyMask();
					},

					/**
					 * @inheritdoc BPMSoft.BaseMessagePublisherPage#getPublishMaskCaption
					 * @overridden
					 */
					getPublishMaskCaption: function() {
						return this.get("Resources.Strings.EmailMaskCaption");
					},

					/**
					 * Validates fields before E-mail is sent.
					 * @protected
					 * @return {Boolean} Validate result.
					 */
					checkSenderBeforeSend: function() {
						var ext = this.Ext;
						var sender = this.get("Sender");
						var recipient = this.get("Recepient");
						var copyRecipient = this.get("CopyRecepient");
						var blindCopyRecipient = this.get("BlindCopyRecepient");
						var subject = this.get("Title");
						if (ext.isEmpty(sender)) {
							this.showConfirmationDialog(this.get("Resources.Strings.SendEmailForUserQuestion"));
							return false;
						}
						if (ext.isEmpty(recipient) && ext.isEmpty(copyRecipient) && ext.isEmpty(blindCopyRecipient)) {
							this.showConfirmationDialog(this.get("Resources.Strings.RecepientEmailForUserQuestion"));
							return false;
						}
						if (ext.isEmpty(subject)) {
							this.showInformationDialog(this.get("Resources.Strings.SubjectIsEmptyMessageToUser"));
							return false;
						}
						return true;
					},

					/**
					 * @inheritdoc BPMSoft.BaseMessagePublisherPage#init
					 * @overridden
					 */
					init: function(callback, scope) {
						this.mixins.MessagePublisherAttachmentUtilities.init.call(this);
						this.callParent([function() {
							this.BPMSoft.chain(
								function(next) {
									this.set("entitiesList", this.Ext.create("BPMSoft.Collection"));
									this.initImageUrlTpl();
									this.on("change:SenderEnum", this.setSenderFromSenderEnum, this);
									this.initDefaultControlsValues();
									this.initCollection();
									this.sandbox.subscribe("SendListenerEmailData", this.setListenerEmailData, this, [this.sandbox.id]);
									this.setSectionProperties();
									this.subscribeMessages();
									this.sandbox.publish("EmailMessagePageLoaded", null, [this.sandbox.id]);
									this.Ext.callback(next, scope || this);
								},
								this.setDefaultSenderEnum,
								this.initAttachmentsViewData,
								function() {
									this.Ext.callback(callback, scope || this);
								},
								this
							);
						}, this]);
						
					},

					/**
					 * Sets properties from current section.
					 * @protected
					 */
					setSectionProperties: function() {
						var columns = ["entitySchemaName"];
						var columnValues = this.sandbox.publish("GetPropertiesByName", columns, [this.sandbox.id]);
						this.set("SectionEntitySchemaName", columnValues.entitySchemaName);
					},

					/**
					 * Initialize default recipient values.
					 * @protected
					 */
					setDefaultRecepient: function() {
						var config = this.getListenerRecordData();
						if (!config) {
							return;
						}
						if (config.additionalInfo && config.additionalInfo.recepient) {
							this.set("Recepient", config.additionalInfo.recepient);
						} else {
							this.set("Recepient", null);
						}
					},

					/**
					 * Initialize default controls values.
					 * @protected
					 */
					initDefaultControlsValues: function() {
						this.set("SenderEnumList", this.Ext.create("BPMSoft.Collection"));
						this.set("CopyRecepient", "");
						this.set("BlindCopyRecepient", "");
						this.setDefaultRecepient();
						if (!this.get("Images")) {
							this.set("Images", this.Ext.create("BPMSoft.BaseViewModelCollection"));
						}
					},

					/**
					 * @inheritdoc BPMSoft.BaseMessagePublisherPage#onDashboardRealoaded
					 * @override
					 */
					onDashboardRealoaded: function() {
						this.setDefaultRecepient();
						this.setDefaultSubject();
					},

					/**
					 * Initialize default email subject.
					 * @protected
					 */
					setDefaultSubject: function() {
						let config = this.getListenerRecordData();
						if (!config) {
							return;
						}
						if (config.additionalInfo && config.additionalInfo.title) {
							this.set("Title", config.additionalInfo.title);
						} else {
							this.set("Title", null);
						}
					},

					/**
					 * Fill e-mail senders list.
					 * @protected
					 */
					loadSenders: function() {
						var list = arguments[1];
						if (list === null) {
							return;
						}
						list.clear();
						this._getSendersCollection(function(collection) {
							var columns = {};
							collection.each(function(item) {
								var lookupValue = this.getLookupValue(item);
								lookupValue = this.getItemWithSignature(lookupValue, item);
								var itemId = item.get("Id");
								if (!list.contains(itemId)) {
									columns[itemId] = lookupValue;
								}
							}, this);
							list.loadAll(columns);
						}, this);
					},

					/**
					 * Gets column display value of given mailbox sync settings item.
					 * @protected
					 * @param {BPMSoft.Entity} item Mailbox sync settings item.
					 * @return {String} Column display value.
					 */
					getColumnDisplayValue: function(item) {
						return this.mixins.EmailActionsMixin.getColumnDisplayValue.call(this, item);
					},

					/**
					 * @inheritdoc BPMSoft.BaseMessagePublisherPage#getServiceConfig
					 * @overridden
					 */
					getServiceConfig: function() {
						return {
							className: "BPMSoft.Configuration.ActivityEmailMessagePublisher"
						};
					},

					/**
					 * Opens e-mail's recepients lookup page.
					 * @protected
					 */
					openRecepientLookupEmail: function() {
						var lookup = this.getLookupConfig("Recepient");
						lookup.config.actionsButtonVisible = false;
						var searchValue = this.get("RecepientLookupSearchValue");
						if (searchValue) {
							lookup.config.searchValue = searchValue;
						}
						LookupUtilities.Open(this.sandbox, lookup.config, lookup.callback, this, null, false, false);
					},

					/**
					 * Opens e-mail's copy recepients lookup page.
					 * @protected
					 */
					openCopyRecepientLookupEmail: function() {
						var lookup = this.getLookupConfig("CopyRecepient");
						lookup.config.actionsButtonVisible = false;
						LookupUtilities.Open(this.sandbox, lookup.config, lookup.callback, this, null, false, false);
					},

					/**
					 * Opens e-mail's blind copy recepients lookup page.
					 * @protected
					 */
					openBlindCopyRecepientLookupEmail: function() {
						var lookup = this.getLookupConfig("BlindCopyRecepient");
						LookupUtilities.Open(this.sandbox, lookup.config, lookup.callback, this, null, false, false);
					},

					/**
					 * Sets email data by default.
					 * @protected
					 * @param {Object} data Email data from Listener.
					 */
					setListenerEmailData: function(data) {
						var recipient = this.get("Recepient");
						if (data && data.emailTitle) {
							if (this.Ext.isEmpty(this.get("Title"))) {
								this.set("Title", data.emailTitle);
							}
							this.set("IsTitleEnabled", false);
						}
						if (recipient) {
							return;
						}
						this.setRecipientValue(data);
					},

					/**
					 * Sets Recepient data by default.
					 * @param {Object} data Email data from Listener.
					 */
					setRecipientValue: function(data) {
						if (data && data.email) {
							this.set("Recepient", data.email);
						} else if (data && data.searchValue) {
							this.set("Recepient", "");
							this.set("RecepientLookupSearchValue", data.searchValue);
						} else {
							this.set("Recepient", "");
						}
					},

					/**
					 * Set default sender.
					 * @protected
					 * @param {Collectoion} Mailbox query result.
					 */
					setDefaultSenderMailbox: function(collection) {
						const defaultMailbox = this.getDefaultMailbox(collection);
						if(defaultMailbox) {
							this.setSenderEnum(defaultMailbox);
						}
					},

					/**
					 * Gets lookup value.
					 * @protected
					 * @param {BPMSoft.Entity} item Mailbox sync settings item.
					 * @returns {Object} Lookup value.
					 */
					getLookupValue: function (item) {
						return this.mixins.EmailActionsMixin.getMailboxLookupValue.call(this, item);
					},

					/**
					 * Sets sender list with default values.
					 * @protected
					 * @param {Function} callback Callback function.
					 * @param {Object} scope Callback function scope.
					 */
					setDefaultSenderEnum: function(callback, scope) {
						this._getSendersCollection(function(collection) {
							if (!collection.isEmpty()) {
								this.setDefaultSenderMailbox(collection);
							} else {
								var buttonsConfig = {
									buttons: [this.BPMSoft.MessageBoxButtons.YES.returnCode,
										this.BPMSoft.MessageBoxButtons.NO.returnCode],
									defaultButton: 0,
									caption: this.get("Resources.Strings.AddEmailForUserQuestion")
								};
								var buildType = ConfigurationConstants.BuildType.Public;
								this.BPMSoft.SysSettings.querySysSettingsItem("BuildType", function(sysSettingValue) {
									if (sysSettingValue && sysSettingValue.value === buildType) {
										this.showInformationDialog(this.get("Resources.Strings.MailboxDoesntExist"));
									} else {
										this.showInformationDialog(
												this.get("Resources.Strings.AddEmailForUserQuestion"),
												this.addEmailForUser, buttonsConfig, this);
									}
								}, this);
							}
							this.Ext.callback(callback, scope || this);
						}, this);
					},

					/**
					 *Allows user specify email box.
					 * @protected
					 * @param {String} result Dialog window bitton code.
					 */
					addEmailForUser: function(result) {
						if (result === this.BPMSoft.MessageBoxButtons.YES.returnCode) {
							this.sandbox.publish("PushHistoryState", {hash: "MailboxSynchronizationSettingsModule"});
						}
					},

					/**
					 * Generates settings required to display lookup page.
					 * @protected
					 * @param {String} columnName Column name for which lookup value needed to be selected.
					 * @return {Object} Settings configuration.
					 */
					getLookupConfig: function(columnName) {
						var scope = this;
						var callback = function(args) {
							scope.onLookupSelected(args);
						};
						return {
							config: {
								entitySchemaName: "VwRecepientEmail",
								columnName: columnName,
								columns: ["ContactId"],
								filters: this.BPMSoft.createColumnIsNotNullFilter("ContactId"),
								multiSelect: true
							},
							callback: callback
						};
					},

					/**
					 * Triggered when lookup values is selected.
					 * @param {Object} args Selected lookup value.
					 */
					onLookupSelected: function(args) {
						var ext = this.Ext;
						var columnName = args.columnName;
						var isContactEmpty = ext.isEmpty(this.get("Contact"));
						var items = args.selectedRows.collection.items;
						this.recepientCollection = this.recepientCollection || [];
						var collection = this.recepientCollection;
						var columnValue = this.get(columnName);
						if (ext.isEmpty(columnValue)) {
							columnValue = "";
						} else {
							columnValue = columnValue.trim();
							var addSymbol = "";
							var symbol = columnValue[columnValue.length - 1];
							if (symbol === ";") {
								addSymbol = " ";
							} else {
								addSymbol = "; ";
							}
							columnValue = columnValue + addSymbol;
						}
						this.BPMSoft.each(items, function(item) {
							var contactId = item.ContactId;
							if (isContactEmpty && ext.isEmpty(columnValue) && columnName === "Recepient") {
								isContactEmpty = false;
							}
							var displayValue = item.displayValue;
							if (collection.indexOf(contactId) < 0) {
								collection.push(contactId);
							}
							var idx = columnValue.indexOf(displayValue + ";");
							if (idx !== 0 && idx < 0) {
								columnValue += displayValue + "; ";
							}
						}, this);
						this.set(columnName, columnValue);
					},

					/**
					 * Create inserts parameters for entity.
					 * @private
					 */
					createInsertQueryWithParameters: function() {
						var insert = this.Ext.create("BPMSoft.InsertQuery", {
							rootSchemaName: this.entitySchemaName
						});
						insert.setParameterValue("Id", this.get("PrimaryColumnValue"),
								this.BPMSoft.DataValueType.GUID);
						insert.setParameterValue("Title", this.get("Resources.Strings.DraftBodyMessage"),
								this.BPMSoft.DataValueType.TEXT);
						insert.setParameterValue("Type", ConfigurationConstants.Activity.Type.Email,
								this.BPMSoft.DataValueType.GUID);
						insert.setParameterValue("EmailSendStatus", ConfigurationConstants.Activity.EmailSendStatus.NotSended,
								this.BPMSoft.DataValueType.GUID);
						return insert;
					},

					/**
					 * Inserts entity.
					 * @private
					 */
					insertEntity: function() {
						var insert = this.createInsertQueryWithParameters();
						insert.execute(function(response) {
							if (response && response.success) {
								this.set("IsInserted", response.success);
								this.uploadFile();
							}
						}, this);
					},

					/**
					 * Returns attachment view config.
					 * @protected
					 * @virtual
					 * @param {Object} itemConfig Attachment config.
					 */
					getItemViewConfig: function(itemConfig) {
						var fullViewConfig = this.get("AttachmentViewConfig");
						if (fullViewConfig.length > 0) {
							var attachmentWrapContainerIndex = 0;
							for (var i = 0; i < fullViewConfig.length; i++) {
								if (fullViewConfig[i].id === "AttachmentWrapContainer") {
									attachmentWrapContainerIndex = i;
									break;
								}
							}
							itemConfig.config = fullViewConfig[attachmentWrapContainerIndex];
						}
						var activityFile = arguments[1];
						if (activityFile) {
							var fileName = activityFile.get("Name");
							var fileTypes = this.get("FileTypes");
							if (!fileTypes) {
								return;
							}
							var imageType = /^image/;
							var fileType = fileTypes[fileName];
							if (fileType && fileType.match(imageType)) {
								var fileId = activityFile.get("Id");
								var activityFileSchemaUId = ConfigurationConstants.SysSchema.ActivityFile;
								var image = this.Ext.create("BPMSoft.BaseViewModel", {
									values: {
										fileName: fileName,
										url: "../rest/FileService/GetFile/" + activityFileSchemaUId + "/" + fileId
									}
								});
								var imagesCollection = this.get("Images");
								if (imagesCollection) {
									imagesCollection.add(imagesCollection.getUniqueKey(), image);
								}
							}
						}
					},

					/**
					 * Template button click event handler.
					 * @protected
					 */
					onTemplateButtonClick: function() {
						this.saveMasterEntity(this.onOpenEmailTemplate, this);
					},

					/**
					 * Processes response with text template.
					 * @protected
					 * @virtual
					 * @param {Object} response Response with text template.
					 */
					processResponse: function(response, isReplyTo) {
						this.hideBodyMask();
						if (this.validateResponse(response)) {
							let textTemplate = response.textTemplate;
							textTemplate = Ext.String.format("<div>{0}</div>", textTemplate)
								.replace(new RegExp(/<(\/)?(html|head|body)([^><]*?)>/img), "");
							if (textTemplate.includes(this.getEmptySignature())) {
								textTemplate = this.addSignatureToTemplate(textTemplate);
							}
							if (this._isEmailTemplateMultiLanguage()) {
								let emailBody = isReplyTo
									? this.getQuotesBody(this.get("InReplyToEmailBody"))
									: this.get("InReplyToEmailBody");
								emailBody = textTemplate + emailBody;
								this.applyTemplate(emailBody);
								this.applySubjectTemplate(response.subjectTemplate);
								this.set("InReplyToEmailBody", this.Ext.emptyString);
							} else {
								this.applyTemplate(textTemplate);
							}
						}
					},

					/**
					 * Applies text template.
					 * @protected
					 * @virtual
					 * @param {String} textTemplate Text template.
					 */
					applyTemplate: function(textTemplate) {
						var signature = this.get("Signature");
						var useSignature = this.get("UseSignature");
						var body = textTemplate;
						if (this.isSignatureExist(useSignature, signature)
								&& !textTemplate.match(this.getSignatureRegExp())) {
							body = body.concat(signature);
						}
						this.set("Body", body);
					},

					/**
					 * Applies template subject.
					 * @protected
					 * @virtual
					 * @param {String} subjectTemplate Subject template.
					 */
					applySubjectTemplate: function(subjectTemplate) {
						if (this.Ext.isEmpty(this.get("Title"))) {
							this.set("Title", subjectTemplate);
						}
					},

					/**
					 * @inheritDoc BPMSoft.ExtendedHtmlEditModuleUtilities#addCallBack
					 * @overridden
					 */
					addCallBack: function(args) {
						var selectedItems = args.selectedRows.getItems();
						var selectedItem = selectedItems.length && selectedItems[0];
						if (!this.Ext.isEmpty(selectedItem)) {
							if (!this.Ext.isEmpty(selectedItem.Subject) && this.get("IsTitleEnabled") &&
									!this._isEmailTemplateMultiLanguage()) {
								this.set("Title", selectedItem.Subject);
							}
							if (!this.Ext.isEmpty(selectedItem.Body)) {
								var requestParams = {
									id: selectedItem.Id,
									body: selectedItem.Body
								};
								this.callMacrosHelperServiceRequest(requestParams);
							}
						}
					},

					/**
					 * Calls service for getting template text with replaced macroses.
					 * @protected
					 * @param {String} textTemplate Config for service.
					 * @param {Function} callback Callback function.
					 * @param {Object} scope Callback function's scope.
					 */
					executeMacrosHelperServiceRequest: function(textTemplate, callback, scope) {
						this.showBodyMask();
						var data = this.getListenerRecordData();
						var serviceRequest = this.Ext.create("BPMSoft.MacrosHelperServiceRequest", {
							contractName: "GetTemplate",
							entityId: data.relationSchemaRecordId,
							entityName: data.relationSchemaName,
							textTemplate: textTemplate
						});
						serviceRequest.execute(function(response) {
							callback.call(scope || this, response);
						});
					},

					/**
					 * @inheritdoc BPMSoft.EmailMessagePublisherPage#subscribeMessages
					 * @override
					 */
					subscribeMessages: function() {
						this.callParent(arguments);
						var macrosModuleId = this.getMacrosModuleId();
						this.sandbox.subscribe("MacroSelected", this.onGetMacros, this, [macrosModuleId]);
						this.sandbox.subscribe("SendMacrosData", this.onGetMacrosData, this,
								[this.actionDashboarModuleId()]);
						this.sandbox.subscribe("GetPublisherPageState", this.onGetPublisherPageState, this);
					},

					/**
					 * Get action dashboard module id.
					 * @return {String} module id.
					 */
					actionDashboarModuleId: function() {
						var moduleId = this.sandbox.id;
						return moduleId.replace("_EmailMessagePublisherModule", "");
					},

					/**
					 * Set`s recipient data from history page.
					 * @protected
					 * @virtual
					 * @param {string} recipient data.
					 */
					setRecipientFromHistoryPage: function(historyRecipient) {
						var recipient = !this.Ext.isEmpty(historyRecipient) ? historyRecipient : null;
						this.set("Recepient", recipient);

					},

					/**
					 * Porcesses macros data from history page.
					 * @protected
					 * @virtual
					 * @param {object} macros data.
					 */
					onGetMacrosData: function(args) {
						if (!this.Ext.isEmpty(args)) {
							if (!this.Ext.isEmpty(args.title)) {
								this.set("Title", args.title);
							}
							if (!this.Ext.isEmpty(args.body) || !this.Ext.isEmpty(args.Id)) {
								args.isReplyTo = true;
								this.set("InReplyToEmailBody", args.body);
								this.callMacrosHelperServiceRequest(args);
							}
							this.setRecipientFromHistoryPage(args.recepient);
							if (!this.Ext.isEmpty(args.copyRecepient)) {
								this.set("isCopyRecipientVisible", true);
								this.set("CopyRecepient", args.copyRecepient);
							}
						}
					},

					/**
					 * Calls service for getting template text with replaced macroses.
					 * @protected
					 * @virtual
					 * @param {Object} args Macros data.
					 */
					callMacrosHelperServiceRequest: function(args) {
						if (this._isEmailTemplateMultiLanguage()) {
							this.executeMultiLanguageMacrosHelperServiceRequest(args, this.processResponse, this);
						} else {
							this.executeMacrosHelperServiceRequest(args.body, this.processResponse, this);
						}
					},

					/**
					 * Calls service for getting multilanguage template with replaced macroses.
					 * @protected
					 * @param {Object} args object with params for service.
					 * @param {Function} callback Callback function.
					 * @param {Object} scope Callback function's scope.
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
						serviceRequest.execute(function(response) {
							callback.call(scope || this, response);
						});
					},

					/**
					 * Check feature status.
					 * @private
					 * @return {Boolean} feature state.
					 */
					_isEmailTemplateMultiLanguage: function() {
						return this.getIsFeatureEnabled("EmailTemplateMultiLanguageInActionDashBoard");
					},

					/**
					 * Image pasted event handler. Pasts to email body image pasted from buffer.
					 * @private
					 * @param {Object} item Pasted from buffer file config object.
					 */
					onImagePasted: function(item) {
						var file = null;
						if (item && typeof item.getAsFile === "function") {
							file = item.getAsFile();
						}
						var callback = this.onComplete.bind(this);
						var args = [file, this.get("PrimaryColumnValue"), callback, this];
						if (this.get("IsInserted")) {
							this.insertImageFromBuffer(args);
							return;
						}
						var insert = this.createInsertQueryWithParameters();
						insert.execute(function(response) {
							if (response && response.success) {
								this.set("IsInserted", true);
								this.insertImageFromBuffer(args);
							}
						}, this);
					},

					/**
					 * Processes adding macros event.
					 * @protect
					 * @virtual
					 * @param {String} macrosType Macros type.
					 */
					onMacroButtonClicked: function(macrosType) {
						switch (macrosType) {
							case "macros":
								this.saveMasterEntity(this.openMacrosPage, this);
								break;
							case "column":
								this.saveMasterEntity(this.openMacrosColumnsPage, this);
								break;
							default:
								throw this.Ext.create("BPMSoft.UnsupportedTypeException " + macrosType);
						}
					},

					/**
					 * Opens entity structure explorer module for select column macros.
					 * @protected
					 * @virtual
					 */
					openMacrosColumnsPage: function() {
						var data = this.getListenerRecordData();
						this.BPMSoft.StructureExplorerUtilities.open({
							scope: this,
							handlerMethod: this.onMacrosColumnSelected,
							moduleConfig: {
								useBackwards: false,
								schemaName: data.relationSchemaName
							}
						});
					},

					/**
					 * It processes the macros.
					 * @protected
					 * @virtual
					 * @param {String} macros Macros.
					 */
					onGetMacros: function(macros) {
						this.set("SelectedText", macros);
						this.executeMacrosHelperServiceRequest(this.get("Body"), this.processResponse, this);
					},

					/**
					 * @inheritdoc BPMSoft.BaseMessagePublisherPage#isNeedToBePublished
					 * @overridden
					 */
					isNeedToBePublished: function() {
						return Boolean(this.get("Body"));
					},

					/**
					 * Returns need sanitize html in html editor.
					 * @return {Boolean} Need sanitize html in html editor.
					 */
					getNeedSanitizeHtml: function() {
						return this.getIsFeatureEnabled("SanitizeHtml");
					}
				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "merge",
						"name": "PublishButton",
						"values": {
							"caption": {
								"bindTo": "Resources.Strings.SendButtonCaption"
							}
						}
					},
					{
						"operation": "insert",
						"name": "EmailSyncErrors",
						"propertyName": "items",
						"parentName": "ModulePageContainer",
						"index": 1,
						"values": {
							"itemType": BPMSoft.ViewItemType.MODULE,
							"classes": {"wrapClassName": ["sync-settings-errors","email-publisher-sync-errors"]},
							"moduleName": "BaseSchemaModuleV2",
							"instanceConfig": {
								"isSchemaConfigInitialized": true,
								"schemaName": "SyncSettingsErrors",
								"useHistoryState": false
							}
						}
					},
					{
						"operation": "insert",
						"propertyName": "items",
						"parentName": "LayoutContainer",
						"name": "MainGridLayout",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": []
						},
						"index": 0
					},
					{
						"operation": "insert",
						"parentName": "MainGridLayout",
						"propertyName": "items",
						"name": "SenderEnum",
						"values": {
							"layout": {
								"column": 15,
								"row": 0,
								"colSpan": 9
							},
							"bindTo": "SenderEnum",
							"controlConfig": {
								"className": "BPMSoft.ComboBoxEdit",
								"list": {
									"bindTo": "SenderEnumList"
								},
								"prepareList": {
									"bindTo": "loadSenders"
								}
							},
							"markerValue": "From"
						}
					},
					{
						"operation": "insert",
						"parentName": "MainGridLayout",
						"propertyName": "items",
						"name": "Recepient",
						"values": {
							"bindTo": "Recepient",
							"layout": {
								"column": 0,
								"row": 0,
								"colSpan": 11
							},
							"controlConfig": {
								"className": "BPMSoft.TextEdit",
								"rightIconClasses": ["custom-right-item", "lookup-edit-right-icon"],
								"rightIconClick": {
									"bindTo": "openRecepientLookupEmail"
								}
							},
							"markerValue": "To"
						}
					},
					{
						"operation": "insert",
						"parentName": "MainGridLayout",
						"propertyName": "items",
						"name": "ToggleCopyRecipientVisible",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.BUTTON,
							"caption": {
								"bindTo": "Resources.Strings.CC"
							},
							"layout": {
								"column": 11,
								"row": 0,
								"colSpan": 1
							},
							"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							"click": {
								"bindTo": "fieldVisibleToggleClick"
							},
							"tag": "isCopyRecipientVisible",
							"markerValue": "CC"
						}
					},
					{
						"operation": "insert",
						"parentName": "MainGridLayout",
						"propertyName": "items",
						"name": "ToggleBlindCopyRecipientVisible",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.BUTTON,
							"classes": {
								"textClass": ["bcc-button-text"]
							},
							"caption": {
								"bindTo": "Resources.Strings.BCC"
							},
							"layout": {
								"column": 13,
								"row": 0,
								"colSpan": 2
							},
							"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							"click": {
								"bindTo": "fieldVisibleToggleClick"
							},
							"tag": "isBlindCopyRecipientVisible",
							"markerValue": "BCC"
						}
					},
					{
						"operation": "insert",
						"parentName": "LayoutContainer",
						"propertyName": "items",
						"name": "CopyRecepient",
						"values": {
							"bindTo": "CopyRecepient",
							"controlConfig": {
								"className": "BPMSoft.TextEdit",
								"rightIconClasses": ["custom-right-item", "lookup-edit-right-icon"],
								"rightIconClick": {
									"bindTo": "openCopyRecepientLookupEmail"
								}
							},
							"visible": {
								"bindTo": "isCopyRecipientVisible"
							}
						},
						"index": 1
					},
					{
						"operation": "insert",
						"parentName": "LayoutContainer",
						"propertyName": "items",
						"name": "BlindCopyRecepient",
						"values": {
							"bindTo": "BlindCopyRecepient",
							"controlConfig": {
								"className": "BPMSoft.TextEdit",
								"rightIconClasses": ["custom-right-item", "lookup-edit-right-icon"],
								"rightIconClick": {
									"bindTo": "openBlindCopyRecepientLookupEmail"
								}
							},
							"visible": {
								"bindTo": "isBlindCopyRecipientVisible"
							}
						},
						"index": 2
					},
					{
						"operation": "insert",
						"parentName": "LayoutContainer",
						"propertyName": "items",
						"name": "Title",
						"values": {
							"bindTo": "Title",
							"caption": {
								"bindTo": "Resources.Strings.EmailTitleCaption"
							},
							"controlConfig": {
								"className": "BPMSoft.TextEdit"
							},
							"markerValue": "Title",
							"enabled": {
								"bindTo": "IsTitleEnabled"
							}
						},
						"index": 3
					},
					{
						"operation": "insert",
						"name": "Body",
						"values": {
							"contentType": this.BPMSoft.ContentType.RICH_TEXT,
							"generator": "InlineTextEditViewGenerator.generate",
							"labelConfig": {
								"visible": true
							},
							"markerValue": "Body",
							"placeholder": {
								"bindTo": "Resources.Strings.WriteEmailPostHint"
							},
							"selectedText": {
								"bindTo": "SelectedText"
							},
							"controlConfig": {
								"macrobuttonclicked": {
									"bindTo": "onMacroButtonClicked"
								},
								"inlineTextControlConfig": {
									"ckeditorDefaultConfig": {
										"allowedContent": true,
										"removeButtons": "bpmcrmmacros,bpmcrmemailtemplatelink",
										"keystrokes": [
											[CKEDITOR.CTRL + 75, "link"] // CTRL + K
										]
									}
								},
								"showEmailTemplateLinkButton": false,
								"hasFullScreen": true,
								"hasTableEdit": BPMSoft.Features.getIsEnabled("CKeditorTableEdit"),
								"images": {
									"bindTo": "Images"
								},
								"imagePasted": {
									"bindTo": "onImagePasted"
								},
								"sanitizeHtml": {
									"bindTo": "getNeedSanitizeHtml"
								}
							}
						},
						"parentName": "BodyContainer",
						"propertyName": "items"
					},
					{
						"operation": "insert",
						"name": "AttachFileButton",
						"propertyName": "items",
						"parentName": "PublisherBottomContainer",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.BUTTON,
							"style": this.BPMSoft.controls.ButtonEnums.style.DEFAULT,
							"iconAlign": this.BPMSoft.controls.ButtonEnums.iconAlign.LEFT,
							"imageConfig": {
								"bindTo": "getAttachFileButtonImageConfig"
							},
							"tag": "attachFileButton",
							"fileUpload": true,
							"filesSelected": {"bindTo": "onAttachFileSelected"},
							"enabled": {
								"bindTo": "IsPublishButtonEnabled"
							},
							"click": {
								"bindTo": "onAttachFileButtonClick"
							},
							"classes": {
								"imageClass": ["attachFileButtonImage"]
							},
							"markerValue": "AttachFileButton"
						}
					},
					{
						"operation": "insert",
						"name": "TemplateButton",
						"propertyName": "items",
						"parentName": "PublisherBottomContainer",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.BUTTON,
							"imageConfig": {
								"bindTo": "Resources.Images.TemplateButtonImage"
							},
							"hint": {
								"bindTo": "Resources.Strings.TemplateButtonCaption"
							},
							"enabled": {
								"bindTo": "IsPublishButtonEnabled"
							},
							"click": {
								"bindTo": "onTemplateButtonClick"
							}
						}
					},
					{
						"operation": "insert",
						"name": "FilesList",
						"parentName": "ModulePageContainer",
						"propertyName": "items",
						"values": {
							"generateId": false,
							"generator": "ConfigurationItemGenerator.generateContainerList",
							"idProperty": "Id",
							"collection": "FilesList",
							"onGetItemConfig": "getItemViewConfig",
							"isAsync": true
						}
					}
				]/**SCHEMA_DIFF*/
			};
		});
