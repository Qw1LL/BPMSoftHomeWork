define("EmailPageV2", ["BaseFiltersGenerateModule", "BusinessRuleModule", "ConfigurationConstants", "LookupUtilities",
	"EmailUtilitiesV2", "ConfigurationEnums", "EmailConstants", "EmailHelper", "ExchangeNUIConstants",
	"ActivityDatesMixin", "EmailActionsMixin", "ExtendedHtmlEditModuleUtilities", "ExtendedHtmlEditModule",
	"MacrosHelperServiceRequest", "EntityConnectionLinksUtilities", "EmailRelationsMixin", "css!EmailUtilitiesV2"
], function(BaseFiltersGenerateModule, BusinessRuleModule, ConfigurationConstants, LookupUtilities, EmailUtilities,
		ConfigurationEnums, EmailConstants, EmailHelper, ExchangeNUIConstants) {
	return {
		entitySchemaName: "Activity",
		mixins: {
			/**
			 * Mixin for actions with email.
			 */
			EmailActionsMixin: "BPMSoft.EmailActionsMixin",
			/**
			 * MiniPage Activity dates mixin.
			 */
			ActivityDatesMixin: BPMSoft.ActivityDatesMixin,
			/**
			 * Mixin for inserting e-mail templates.
			 */
			ExtendedHtmlEditModuleUtilities: BPMSoft.ExtendedHtmlEditModuleUtilities,
			/**
			 * Mixin for inserting email images.
			 */
			EmailImageMixin: "BPMSoft.EmailImageMixin",
			/**
			 * Mixin for obtain entity connection lookup columns.
			 */
			EntityConnectionLinksUtilities: BPMSoft.EntityConnectionLinksUtilities,
			/**
			 * Email relations mixin.
			 */
			EmailRelationsMixin: BPMSoft.EmailRelationsMixin
		},
		attributes: {
			/**
			 * Expandable entities list.
			 */
			"EntitiesList": {
				"dataValueType": BPMSoft.DataValueType.COLLECTION,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			/**
			 * Email owner role attribute.
			 */
			"OwnerRole": {
				"dataValueType": BPMSoft.DataValueType.LOOKUP,
				"dependencies": [
					{
						"columns": ["OwnerRole"],
						"methodName": "onOwnerRoleChange"
					}
				]
			},
			/**
			 * Owner attribute.
			 */
			"Owner": {
				"dataValueType": BPMSoft.DataValueType.LOOKUP,
				"lookupListConfig": {
					"filter": function() {
						const roleId = this.getLookupValue("OwnerRole");
						return this._getIsUseProcessPerformerAssignment()
							? BaseFiltersGenerateModule.OwnersInRoleFilter(roleId)
							: BaseFiltersGenerateModule.OwnerFilter();
					}
				}
			},
			/**
			 * Send button visibility attribute.
			 */
			"IsSendButtonVisible": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"dependencies": [
					{
						"columns": ["EmailSendStatus"],
						"methodName": "getIsVisibleSendButton"
					}
				]
			},
			/**
			 * Reply button visibility attribute.
			 */
			"IsReplyButtonVisible": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"dependencies": [
					{
						"columns": ["Type", "MessageType"],
						"methodName": "getIsVisibleReplyButton"
					}
				]
			},
			/**
			 * Forward button visibility attribute.
			 */
			"IsForwardButtonVisible": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"dependencies": [
					{
						"columns": ["Type", "MessageType"],
						"methodName": "getIsVisibleForwardButton"
					}
				]
			},
			/**
			 * Reply out button visibility attribute.
			 */
			"IsForwardOUTButtonVisible": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"dependencies": [
					{
						"columns": ["EmailSendStatus"],
						"methodName": "getIsVisibleForwardOUTButton"
					}
				]
			},
			/**
			 * Email send date.
			 */
			"SendDate": {
				"dataValueType": BPMSoft.DataValueType.DATE_TIME
			},
			/**
			 * Email sender.
			 */
			"Sender": {
				"dataValueType": BPMSoft.DataValueType.TEXT,
				"visible": false,
				"dependencies": [
					{
						"columns": ["SenderEnum"],
						"methodName": "setSenderFromSenderEnum"
					}
				],
				"isRequired": true
			},
			/**
			 * Email signature.
			 */
			"Signature": {
				"dataValueType": BPMSoft.DataValueType.TEXT,
				"value": ""
			},
			/**
			 * Flag that indicates email signature is being used.
			 */
			"UseSignature": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"value": false
			},
			/**
			 * MailboxSyncSettings collection.
			 * @private
			 */
			"MailboxSyncSettingsCollection": {
				"dataValueType": BPMSoft.DataValueType.COLLECTION
			},
			/**
			 * Email sender enum. Used in sender combobox.
			 */
			"SenderEnum": {
				"dataValueType": BPMSoft.DataValueType.ENUM,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"caption": {"bindTo": "Resources.Strings.SenderCaption"}
			},
			/**
			 * Email sender list. Used in sender combobox.
			 */
			"SenderEnumList": {
				"dataValueType": BPMSoft.DataValueType.ENUM,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"isCollection": true
			},
			/**
			 * Email recepients.
			 */
			"Recepient": {
				"dataValueType": BPMSoft.DataValueType.TEXT,
				"dependencies": [
					{
						"columns": ["Contact"],
						"methodName": "onContactChange"
					}
				],
				"isRequired": true
			},
			/**
			 * Activity category.
			 */
			"ActivityCategory": {
				"dataValueType": BPMSoft.DataValueType.LOOKUP,
				"dependencies": [
					{
						"columns": ["Type"],
						"methodName": "setDefaultValueByType"
					}
				]
			},
			/**
			 * Activity start date.
			 */
			"StartDate": {
				"dataValueType": BPMSoft.DataValueType.DATE_TIME,
				"dependencies": [
					{
						"columns": ["StartDate"],
						"methodName": "onStartDateChanged"
					}
				]
			},
			/**
			 * Activity due date.
			 */
			"DueDate": {
				"dataValueType": BPMSoft.DataValueType.DATE_TIME,
				"dependencies": [
					{
						"columns": ["DueDate"],
						"methodName": "onDueDateChanged"
					}
				]
			},
			/**
			 * Email send status.
			 */
			"EmailSendStatus": {
				"dataValueType": BPMSoft.DataValueType.LOOKUP,
				"dependencies": [
					{
						"columns": ["Type"],
						"methodName": "setDefaultValueByType"
					}
				]
			},
			/**
			 * Show in schedule attribute.
			 */
			"ShowInScheduler": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"dependencies": [
					{
						"columns": ["ActivityCategory"],
						"methodName": "setDefaultShowInScheduler"
					}
				]
			},
			/**
			 * Copy recepients input visibility.
			 */
			"isCopyRecipientVisible": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN
			},
			/**
			 * Blind copy recepients input visibility.
			 */
			"isBlindCopyRecipientVisible": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN
			},
			/**
			 * Sign that email send status is not sent.
			 */
			"isEmailSendStatusNotSent": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN
			},
			/**
			 * Activity section shcedule data view name.
			 */
			"SchedulerDataViewName": {
				"dataValueType": BPMSoft.DataValueType.TEXT,
				"value": "SchedulerDataView"
			},

			/**
			 * Flag for "forward" or "reply" action parameters initialized.
			 */
			"ForwardOrReplyValuesSet": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"value": true
			},

			/**
			 * Rich text editor for body column text mode.
			 */
			"PlainTextMode": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"value": false
			},

			/**
			 * Collection of connected to entity columns.
			 */
			"EntityConnectionColumnList": {
				"dataValueType": BPMSoft.DataValueType.COLLECTION,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Sender name.
			 */
			"SenderName": {
				"dataValueType": BPMSoft.DataValueType.TEXT
			},

			/**
			 * Sender email.
			 */
			"SenderEmail": {
				"dataValueType": BPMSoft.DataValueType.TEXT
			},

			/**
			 * Sender name and email parse regexp.
			 * @type {String}
			 */
			"SenderInfoRegExp": {
				"dataValueType": BPMSoft.DataValueType.TEXT,
				"value": "(.+) <(.+)>"
			},

			/**
			 * Unhandled macroses regexp string.
			 * @type {String}
			 */
			"UnhandledMacrosRegExp": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				value: '<span (.)*class=\"unhandled-macro\"(.)*>\\[#(.)+#\\]</span>'
			}
		},
		messages: {
			/**
			 * @message ChangeRemindingsCounts
			 * Sends new emails counter value.
			 */
			"ChangeRemindingsCounts": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
			/**
			 * @message GetIsVisibleEmailPageButtons
			 * Gets email actions buttons visibility.
			 */
			"GetIsVisibleEmailPageButtons": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
			/**
			 * @message ShowRelatedEmails
			 * Loads related emails to email panel.
			 */
			"ShowRelatedEmails": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		details: /**SCHEMA_DETAILS*/{
			Files: {
				schemaName: "EmailFileDetailV2",
				entitySchemaName: "ActivityFile",
				filter: {
					masterColumn: "Id",
					detailColumn: "Activity"
				}
			},
			EntityConnections: {
				schemaName: "EmailEntityConnectionsDetailV2",
				entitySchemaName: "EntityConnection",
				filter: {
					masterColumn: "Id",
					detailColumn: "SysModuleEntity"
				}
			},
			RelatedEmails: {
				schemaName: "RelatedEmailsDetail",
				entitySchemaName: "Activity",
				filter: {
					masterColumn: "Id",
					detailColumn: "Activity"
				}
			}
		}/**SCHEMA_DETAILS*/,
		methods: {

			//region Methods: Private

			/**
			 * Returns true if default sender should be set regardless of mode.
			 * @private
			 * @return {*|boolean}
			 */
			isDefaultSenderEmpty: function() {
				var hasProcessData = this.hasProcessData();
				var sender = this.get("Sender");
				return (hasProcessData && this.isEmpty(sender)) || this.isAddMode();
			},

			/**
			 * Loads MailboxSyncSettings collection from database.
			 * @private
			 * @param {Function} callback The scope of callback function.
			 * @param {Object} scope The scope of callback function.
			 */
			initMailboxSyncSettingsCollection: function(callback, scope) {
				const sendersEsq = this.getSenderQuery();
				sendersEsq.getEntityCollection(function(result) {
					const collection = result.collection || Ext.create("BPMSoft.Collection");
					this.processMacrosesInSignatures(collection, function() {
						this.$MailboxSyncSettingsCollection = collection;
						this.Ext.callback(callback, scope || this);
					}, this);
				}, this);
			},

			/**
			 * Returns required column names array.
			 * @private
			 * @return {Array} Required column names array.
			 */
			getEmailSelectColumns: function() {
				var columns = ["Id", "Author", "Owner", "Contact", "Account", "Sender",
					"Recepient", "CopyRecepient", "BlindCopyRecepient", "Body",
					"Title", "StartDate", "MessageType", "Type", "IsHtmlBody"];
				var connectedColumns = this.get("EntityConnectionColumnList");
				if (this.isNotEmpty(connectedColumns)) {
					BPMSoft.append(columns, connectedColumns, true);
				}
				return columns;
			},

			/**
			 * @inheritdoc BPMSoft.configuration.mixins.EmailImageMixin#validateBeforeInsert
			 * @override
			 */
			validateBeforeInsert: function(args, callback) {
				if (this.isAddMode() && Ext.isEmpty(this.get("IsSavedEntity"))) {
					this.asyncValidate(function() {
						this.saveEntity(function() {
							this.set("IsSavedEntity", true);
							Ext.callback(callback, this, [args]);
						}, this);
					}, this);
				} else {
					Ext.callback(callback, this, [args]);
				}
			},

			/**
			 * StartDate and DueDate attributes change handler. Clears seconds and miliseconds value part.
			 * @private
			 * @param {Object} argument Column dependency "argument" property.
			 * @param {String} columnName Changed column name.
			 */
			clearSeconds: function(argument, columnName) {
				var date = this.get(columnName);
				if (!Ext.isDate(date)) {
					return;
				}
				date = BPMSoft.clearSeconds(date);
				this.set(columnName, date, {
					silent: true
				});
			},

			/**
			 * Inverts field visibility property.
			 * @private
			 */
			fieldVisibleToggleClick: function() {
				if (arguments && arguments.length) {
					var tag = arguments[arguments.length - 1];
					this.set(tag, !this.get(tag));
				}
			},

			/**
			 * Returns address string without email, that set as sender.
			 * @private
			 * @param {String} addressString Address string.
			 * @return {String} Address string without sender email.
			 */
			removeSenderFromAddressString: function(addressString) {
				var sender = this.get("Sender");
				if (this.isEmpty(sender) || this.isEmpty(addressString)) {
					return addressString;
				}
				var senderEmail = EmailHelper.getEmailAddresses(sender);
				if (this.isEmpty(senderEmail)) {
					return addressString;
				}
				senderEmail = senderEmail[0];
				var addresses = addressString.split(";");
				addresses = addresses.filter(function(item) {
					return (item.indexOf(senderEmail) < 0 && item !== " ");
				});
				var combinedAddresses = addresses.join(";");
				return combinedAddresses.trim();
			},

			/**
			 * Sets recipients atribute on reply actions.
			 * @private
			 * @param {Object} actionType Reply action type.
			 * @param {String} actionType.name Action type name.
			 * @param {String} originalSender Sender address from original message.
			 * @param {String} originalRecepients Recepients address from original message.
			 */
			setReplyRecepients: function(actionType, originalSender, originalRecepients) {
				var recepients = originalSender;
				if (actionType.name === EmailConstants.emailAction.ReplyAll) {
					recepients = this.removeSenderFromAddressString(originalRecepients + "; " + originalSender);
				}
				this.set("Recepient", recepients);
			},

			/**
			 * Checks if page has process data.
			 * @private
			 * @return {Boolean} Reply actions visibility.
			 */
			hasProcessData: function() {
				return Boolean(this.get("ProcessData"));
			},

			/**
			 * Checks if reply actions visible.
			 * @private
			 * @return {Boolean} Reply actions visibility.
			 */
			isReplyActionsVisible: function() {
				var type = this.get("Type");
				var status = this.get("EmailSendStatus");
				var activityConsts = ConfigurationConstants.Activity;
				var isEmail = (!Ext.isEmpty(type) && type.value === activityConsts.Type.Email);
				var isSent = (!Ext.isEmpty(status) && status.value === activityConsts.EmailSendStatus.Sended);
				var isVisible = isEmail && isSent;
				return isVisible;
			},

			/**
			 * Copies recepients fields from original message column values.
			 * @private
			 * @param {Object} [entity] Original message.
			 * @param {Object} [actionType] Email action type.
			 */
			updateRecepientsOnReply: function(entity, actionType) {
				var hasSourceEmail = !Ext.isEmpty(entity);
				entity = entity || this;
				actionType = actionType || this.get("EmailActionType");
				var sender = entity.get("Sender");
				var recipient = entity.get("Recepient");
				var copyRecipient = entity.get("CopyRecepient");
				var blindCopyRecipient = entity.get("BlindCopyRecepient");
				var actions = EmailConstants.emailAction;
				var replyAction = actions.Reply;
				var replyAllAction = actions.ReplyAll;
				var actionName = actionType ? actionType.name : "";
				this.set("Type", entity.get("Type"));
				if (actionName !== replyAllAction && actionName !== replyAction) {
					return;
				}
				if (hasSourceEmail) {
					this.setReplyRecepients(actionType, sender, recipient);
				} else {
					this.set("Recepient", this.removeSenderFromAddressString(recipient));
				}
				if (actionName === replyAllAction) {
					if (!Ext.isEmpty(copyRecipient)) {
						this.set("CopyRecepient", this.removeSenderFromAddressString(copyRecipient));
					}
					if (!Ext.isEmpty(blindCopyRecipient)) {
						this.set("BlindCopyRecepient", this.removeSenderFromAddressString(blindCopyRecipient));
					}
				}
			},

			/**
			 * Fills combobox list with loaded senders.
			 * @private
			 * @param {BPMSoft.Collection} collection Senders collection.
			 * @param {BPMSoft.ComboBoxEdit} list Senders combobox list.
			 */
			loadSendersList: function(collection, list) {
				var columns = {};
				if (collection && !collection.isEmpty()) {
					collection.each(function(item) {
						var senderDisplayValue = item.get("SenderDisplayValue");
						var ownerName = this.isNotEmpty(senderDisplayValue) ||
						item.get("MailServer.Type.Id") === ExchangeNUIConstants.MailServer.Type.Exchange
							? senderDisplayValue
							: item.get("SysAdminUnit.Contact.Name");
						var itemId = item.get("Id");
						var columnDisplayValue = Ext.String.format(
							this.get("Resources.Strings.EmailFormatString"), ownerName,
							item.get("SenderEmailAddress")).trim();
						var lookupValue = {
							displayValue: columnDisplayValue,
							value: itemId
						};
						lookupValue = this.getItemWithSignature(lookupValue, item);
						if (!list.contains(itemId)) {
							columns[itemId] = lookupValue;
						}
					}, this);
					list.loadAll(columns);
				}
			},

			/**
			 * Sets default 'SenderEnum' from loaded collection.
			 * @private
			 * @param {BPMSoft.Collection} collection Senders collection.
			 * @param {Function} callback The callback function.
			 * @param {Object} scope The scope of callback function.
			 */
			setDefaultSenderEnumFromCollection: function(collection, callback, scope) {
				const shouldSetDefaultSender = this.isDefaultSenderEmpty();
				if (shouldSetDefaultSender) {
					if (collection && collection.collection.length > 0) {
						this.setDefaultMailbox(collection);
						const defaultMailbox = this.getDefaultMailbox(collection);
						if(defaultMailbox) {
							this.setDeafaultSender(defaultMailbox);
						}
					} else {
						var buttonsConfig = {
							buttons: [BPMSoft.MessageBoxButtons.YES.returnCode,
								BPMSoft.MessageBoxButtons.NO.returnCode],
							defaultButton: 0,
							caption: this.get("Resources.Strings.AddEmailForUserQuestion")
						};
						var buildType = ConfigurationConstants.BuildType.Public;
						BPMSoft.SysSettings.querySysSettingsItem("BuildType", function(sysSettingValue) {
							if (sysSettingValue && sysSettingValue.value === buildType) {
								this.showInformationDialog(this.get("Resources.Strings.MailboxDoesntExist"));
							} else {
								this.showInformationDialog(
									this.get("Resources.Strings.AddEmailForUserQuestion"),
									this.addEmailForUser, buttonsConfig, this);
							}
						}, this);
					}
				} else {
					var senderEmail = this.get("Sender");
					if (!Ext.isEmpty(senderEmail)) {
						var senderEnumValue = {
							displayValue: senderEmail,
							value: "oldKey"
						};
						var senderItem = this.getSenderByEmail(senderEmail);
						if (senderItem) {
							senderEnumValue = this.getItemWithSignature(senderEnumValue, senderItem);
						}
						this.set("SenderEnum", senderEnumValue);
						this.setSenderFromSenderEnum();
					}
				}
				this.Ext.callback(callback, scope || this, [shouldSetDefaultSender]);
			},

			/**
			 * Sets HTML edit mode.
			 * @private
			 */
			_setHtmlEditMode: function() {
				const plainTextMode = this.get("PlainTextMode");
				if (plainTextMode) {
					this.set("PlainTextMode", false);
				}
			},

			/**
			 * Returns sender item by sender's email.
			 * @private
			 * @param {String} senderEmail Sender's email.
			 * @return {BPMSoft.BaseViewModel} Sender view model.
			 */
			getSenderByEmail: function(senderEmail) {
				var result = null;
				var collection = this.get("MailboxSyncSettingsCollection");
				if (!collection.isEmpty()) {
					var senderItem = collection.filterByFn(function(item) {
						return senderEmail.indexOf(item.get("SenderEmailAddress")) !== -1;
					}, this);
					result = senderItem.first();
				}
				return result;
			},

			/**
			 * Sets default sender.
			 * @private
			 * @param item
			 */
			setDeafaultSender: function(item) {
				this.setSenderEnum(item, function (mssItem) {
					if (this.isDefaultSenderEmpty()) {
						this.set("UseSignature", mssItem.get("UseSignature"));
						this.setSenderFromSenderEnum();
					}
					this.updateRecepientsOnReply();
				});
			},

			/**
			 * Checks if we can insert a signature.
			 * @return {boolean} True if send status is sended or status is undefined.
			 * @overriden
			 */
			canAddSignature: function() {
				var sendStatus = this.get("EmailSendStatus");
				return !sendStatus || sendStatus.value !== ConfigurationConstants.Activity.EmailSendStatus.Sended;
			},

			/**
			 * Sets email page model initial values.
			 * @private
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			_setInitialValues: function(callback, scope) {
				this.$isCopyRecipientVisible = false;
				this.$isBlindCopyRecipientVisible = false;
				this.setSenderEnumFromSender();
				this.setEmailActionType();
				this.$ForwardOrReplyValuesSet = !this.isEmailForwardedOrReplyed();
				if (this.isAddMode() || this.isCopyMode()) {
					this.setDefEmailValues();
				}
				if (Ext.isEmpty(this.$IsHtmlBody) && this.isAddMode()) {
					this.$IsHtmlBody = true;
				}
				const emailSendStatus = ConfigurationConstants.Activity.EmailSendStatus;
				this.$isEmailSendStatusNotSent = !this.$EmailSendStatus ||
					this.$EmailSendStatus.value !== emailSendStatus.Sended;
				this.Ext.callback(callback, scope || this);
			},

			//endregion

			//region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BasePageV2#init
			 * @override
			 */
			init: function() {
				this.set("EntitiesList", Ext.create("BPMSoft.Collection"));
				this.initImageUrlTpl();
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseEntityPage#setEntityDefaultValues
			 * @override
			 */
			setEntityDefaultValues: function(callback, scope) {
				this.callParent([function() {
					this.loadEntityConnectionColumns(callback, scope);
				}, this]);
			},

			/**
			 * Fills sender combobox list.
			 * @protected
			 */
			loadSenders: function() {
				var list = arguments[1];
				if (list === null) {
					return;
				}
				list.clear();
				var mailboxSyncSettingsCollection = this.get("MailboxSyncSettingsCollection");
				this.loadSendersList(mailboxSyncSettingsCollection, list);
			},

			/**
			 * Sets email default values.
			 * @protected
			 */
			setDefEmailValues: function() {
				this.set("ActivityCategory", {value: ConfigurationConstants.Activity.ActivityCategory.Email});
				var type = this.get("Type");
				if (this.isEmpty(type)) {
					this.set("Type", {value: ConfigurationConstants.Activity.Type.Email});
				}
				var startDate = this.get("StartDate");
				var dueDate = this.get("DueDate");
				var millisecondsInMinute = BPMSoft.core.enums.DateRate.MILLISECONDS_IN_MINUTE;
				if (!dueDate || Ext.Date.getElapsed(startDate, dueDate) < 5 * millisecondsInMinute) {
					this.set("DueDate", new Date(startDate.getTime() + (30 * millisecondsInMinute)));
				}
			},

			/**
			 * Returns "Send" button visibility.
			 * @protected
			 * @return {boolan} "Send" button visibility.
			 */
			getIsVisibleSendButton: function() {
				var status = this.get("EmailSendStatus");
				var isVisible = (Ext.isEmpty(status) ||
					status.value !== ConfigurationConstants.Activity.EmailSendStatus.Sended);
				this.set("isVisibleSendButton", isVisible);
				this.sendActionVisibilityToActivitySection("IsSendButtonVisible", isVisible);
				return isVisible;
			},

			changeButtonColorIfSendButtonExists: function(){
                if(this.getIsVisibleSendButton()){
                    return BPMSoft.controls.ButtonEnums.style.DEFAULT
                } else{
                    return BPMSoft.controls.ButtonEnums.style.ORANGE
                }
            },

			changeDiscardChangesButtonColorIfSendButtonExists: function(){
                if(this.getIsVisibleSendButton()){
                    return BPMSoft.controls.ButtonEnums.style.TRANSPARENT_ORANGE
                } else{
                    return BPMSoft.controls.ButtonEnums.style.DEFAULT
                }
            },

			/**
			 * Returns "Reply" button visibility.
			 * @protected
			 * @return {boolan} "Reply" button visibility.
			 */
			getIsVisibleReplyButton: function() {
				var isVisible = this.isReplyActionsVisible();
				this.set("isVisibleReplyButton", isVisible);
				this.sendActionVisibilityToActivitySection("IsReplyButtonVisible", isVisible);
				return isVisible;
			},

			/**
			 * Returns "Forward" button visibility.
			 * @protected
			 * @return {boolan} "Forward" button visibility.
			 */
			getIsVisibleForwardButton: function() {
				var isVisible = this.isReplyActionsVisible();
				this.set("isVisibleForwardButton", isVisible);
				this.sendActionVisibilityToActivitySection("IsForwardButtonVisible", isVisible);
				return isVisible;
			},

			/**
			 * Returns "Forward out" button visibility. Button duplicates "Forward" button.
			 * @protected
			 * @obsolete
			 * @return {Boolean} "Forward out" button visibility.
			 */
			getIsVisibleForwardOUTButton: function() {
				var isVisible = false;
				this.set("isVisibleForwardOUTButton", isVisible);
				this.sendActionVisibilityToActivitySection("IsForwardOUTButtonVisible", isVisible);
				return isVisible;
			},

			/**
			 * Recepient attribute change handler.
			 * @protected
			 */
			onContactChange: function() {
				var contact = this.get("Contact");
				var recipient = this.get("Recepient");
				if (Ext.isEmpty(recipient) && !Ext.isEmpty(contact) && !Ext.isEmpty(contact.Email)) {
					var email = Ext.String.format(this.get("Resources.Strings.EmailFormatString"),
						contact.displayValue, contact.Email);
					this.set("Recepient", email);
				}
			},

			/**
			 * Opens "Copy" column lookup window.
			 * @protected
			 */
			openCopyRecepientLookupEmail: function(searchValue, columnName) {
				var lookup = this.getLookupConfig(columnName || "CopyRecepient");
				lookup.config.actionsButtonVisible = false;
				LookupUtilities.Open(this.sandbox, lookup.config, lookup.callback, this, null, false, false);
			},

			/**
			 * Opens "Blind copy" column lookup window.
			 * @protected
			 */
			openBlindCopyRecepientLookupEmail: function(searchValue, columnName) {
				var lookup = this.getLookupConfig(columnName || "BlindCopyRecepient");
				LookupUtilities.Open(this.sandbox, lookup.config, lookup.callback, this, null, false, false);
			},

			/**
			 * Returns lookup window config.
			 * @protected
			 * @param {String} columnName Lookup window column name.
			 * @return {Object} Lookup window config.
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
						filters: BPMSoft.createColumnIsNotNullFilter("ContactId"),
						multiSelect: true
					},
					callback: callback
				};
			},

			/**
			 * Creates activity participant insert query.
			 * @protected
			 * @param {String} contactId Participant contact id.
			 * @param {String} activityId Activity id.
			 * @return {BPMSoft.InsertQuery} Activity participant insert query.
			 */
			getContactInsertQuery: function(contactId, activityId) {
				var roleId = ConfigurationConstants.Activity.ParticipantRole.Participant;
				var insert = Ext.create("BPMSoft.InsertQuery", {
					rootSchemaName: "ActivityParticipant"
				});
				var id = BPMSoft.utils.generateGUID();
				insert.setParameterValue("Id", id, BPMSoft.DataValueType.GUID);
				insert.setParameterValue("Activity", activityId, BPMSoft.DataValueType.GUID);
				insert.setParameterValue("Participant", contactId, BPMSoft.DataValueType.GUID);
				insert.setParameterValue("Role", roleId, BPMSoft.DataValueType.GUID);
				return insert;
			},

			/**
			 * Returns default activity duration in milisecconds (180000 ms).
			 * @protected
			 * @return {integer} Default activity duration in milisecconds.
			 */
			getDefaultTimeInterval: function() {
				return BPMSoft.TimeScale.THIRTY_MINUTES * BPMSoft.DateRate.MILLISECONDS_IN_MINUTE;
			},

			/**
			 * StartDate changed event handler.
			 * @protected
			 */
			onStartDateChanged: function() {
				this.clearSeconds(arguments);
				var startDate = BPMSoft.deepClone(this.get("StartDate"));
				if (!Ext.isDate(startDate)) {
					return;
				}
				var differStartDueDate = this.get("DifferStartDueDate");
				if (!differStartDueDate) {
					differStartDueDate = this.getDefaultTimeInterval();
				}
				this.set("DueDate", new Date(startDate.getTime() + differStartDueDate));
			},

			/**
			 * DueDate changed event handler.
			 * @protected
			 */
			onDueDateChanged: function() {
				this.clearSeconds(arguments);
				var startDate = BPMSoft.deepClone(this.get("StartDate"));
				var dueDate = BPMSoft.deepClone(this.get("DueDate"));
				if (!this.validateDueDate() || !Ext.isDate(startDate) || !Ext.isDate(dueDate)) {
					return;
				}
				this.setDifferStartDueDate(startDate, dueDate);
			},

			/**
			 * Sets default "show in scheduler" property value.
			 * @protected
			 */
			setDefaultShowInScheduler: function() {
				var category = this.get("ActivityCategory");
				var meeting = ConfigurationConstants.Activity.ActivityCategory.Meeting;
				if (!Ext.isEmpty(category) && category.value === meeting) {
					this.set("ShowInScheduler", true);
				}
			},

			/**
			 * Creates message body for replied or forwarded email.
			 * @protected
			 * @param {BPMSoft.BaseViewModel} entity Forwarded email.
			 * @return {String} New email body.
			 */
			getEmailBodyForReply: function(entity) {
				var body = entity.get("Body") || "";
				var sender = entity.get("Sender");
				var recipient = entity.get("Recepient");
				var copyRecipient = entity.get("CopyRecepient");
				var startDate = entity.get("StartDate");
				var title = entity.get("Title");
				var isHtmlBody = entity.get("IsHtmlBody");
				sender = Ext.htmlEncode(sender);
				recipient = Ext.htmlEncode(recipient);
				copyRecipient = Ext.htmlEncode(copyRecipient);
				title = Ext.htmlEncode(title);
				if(isHtmlBody) {
					body = this.getQuotesBody(body);
				} else {
					body = "<p>" + body.replace(/\n*$/, "").replace(/\n/g, "</p><p>") + "</p>";
				}
				var htmlTemplate = this.get("Resources.Strings.ReplyBodyHtmlTemplate");
				body = Ext.String.format(htmlTemplate, sender, startDate, recipient, copyRecipient, title, body,
					this.get("Resources.Strings.SenderCaption"),
					this.get("Resources.Strings.SendDateCaption"),
					this.get("Resources.Strings.RecepientCaption"),
					this.get("Resources.Strings.CopyRecepientCaption"),
					this.get("Resources.Strings.TitleCaption"));
				body = this.getItemWithSignature(body, this);
				return body;
			},

			/**
			 * Creates message title for replied or forwarded email.
			 * @protected
			 * @param {String} actionTypeName Action type name.
			 * @param {String} title Email title.
			 * @return {String} New email title.
			 */
			getTitleForReply: function(actionTypeName, title) {
				var forwardActionName = EmailConstants.emailAction.Forward;
				var titleAdd = actionTypeName === forwardActionName
					? this.get("Resources.Strings.ForwardShablonCaption")
					: this.get("Resources.Strings.ReplyShablonCaption");
				return Ext.String.startsWith(title, titleAdd, true)
					? title
					: Ext.String.format("{0} {1}", titleAdd, title);
			},

			/**
			 * Sets email attributes values on forward or reply actions.
			 * @protected
			 * @param {Object} response Response object.
			 */
			getEntityCallBack: function(response) {
				if (response && response.success && response.entity) {
					var entity = response.entity;
					var actionType = this.get("EmailActionType");
					var title = entity.get("Title");
					this._setHtmlEditMode();
					this.set("IsHtmlBody", true);
					var forwardActionName = EmailConstants.emailAction.Forward;
					this.copyEntityColumnValues(entity, actionType);
					this.$Title = this.getTitleForReply(actionType.name, title);
					var body = this.getEmailBodyForReply(entity);
					this.set("Body", body);
					this.initHeaderCaption();
					var forwardOrReply = this.checkActionName();
					var allFiles = entity.get("FileCount");
					if (forwardOrReply && allFiles > 0 && actionType.name === forwardActionName) {
							this.showBodyMask({timeout: 0});
							this.addAttachmentsWithForwardOrReply(response, false);
						} else {
						this.set("ForwardOrReplyValuesSet", true);
						this.hideBodyMask();
					}
				}
			},

			/**
			 * Adds attachments files with "Forward" or "Reply/Reply All" letter.
			 * @protected
			 * @param {Object} response Response object.
			 * @param {Boolean} skipAttachmentCopy Flag, if true then attachments will not be copied.
			 */
			addAttachmentsWithForwardOrReply: function(response, skipAttachmentCopy) {
				var entity = response.entity;
				this.set("ForwardOrReplyValuesSet", false);
				this.saveEntity(function(response) {
					this.set("SourceEntityPrimaryColumnValue", entity.get(this.primaryColumnName));
					this.set("Operation", ConfigurationEnums.CardStateV2.EDIT);
					this.onSaved(response, {"setOperation": ConfigurationEnums.CardStateV2.ADD}, skipAttachmentCopy);
					this.updateFileDetail();
				}, this);
			},

			/**
			 * @inheritdoc BPMSoft.configuration.BaseSchemaViewModel#hideBodyMask
			 * @override
			 */
			hideBodyMask: function() {
				if (this.get("ForwardOrReplyValuesSet")) {
					this.callParent(arguments);
				}
			},

			/**
			 * Sets "EmailActionType" attribute value on email action.
			 * @protected
			 */
			setEmailActionType: function() {
				if (!this.isAddMode()) {
					return;
				}
				var state = this.sandbox.publish("GetHistoryState");
				var params = state.hash.valuePairs;
				if (!(params && params.length > 0)) {
					return;
				}
				var action = EmailConstants.emailAction;
				var actionTypes = [action.Forward, action.ReplyAll, action.Reply];
				BPMSoft.each(params, function(actionType) {
					if (actionTypes.indexOf(actionType.name) !== -1) {
						this.set("EmailActionType", actionType);
					}
				}, this);
			},

			/**
			 * Initialize values for forward or reply message based on original message.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			setValuesByForwardOrReply: function(callback, scope) {
				const state = this.sandbox.publish("GetHistoryState");
				if (!state || !state.hash) {
					return this.Ext.callback(callback, scope || this);
				}
				const stateParams = state.hash.valuePairs;
				const actions = EmailConstants.emailAction;
				const forwardOrReplyActions = [actions.Forward, actions.ReplyAll, actions.Reply];
				const action = _.find(stateParams, function(param) {
					return BPMSoft.contains(forwardOrReplyActions, param.name);
				}, this);
				if (Ext.isEmpty(action)) {
					return this.Ext.callback(callback, scope || this);
				}
				this.showBodyMask();
				this.$ForwardOrReplyValuesSet = false;
				const originalEmailId = action.value;
				const selectOriginalEmail = this.getEmailSelect(originalEmailId);
				selectOriginalEmail.getEntity(originalEmailId, callback, this);
			},

			/**
			 * Checks is email created by reply or forward action.
			 * @protected
			 * @return {Boolean} True, if email created by reply or forward action, false otherwise.
			 */
			isEmailForwardedOrReplyed: function() {
				var state = this.sandbox.publish("GetHistoryState");
				var params = (!Ext.isEmpty(state) && !Ext.isEmpty(state.hash))
					? state.hash.valuePairs
					: null;
				if (!(params && params.length > 0) || !this.isAddMode()) {
					return false;
				}
				var action = EmailConstants.emailAction;
				var actionTypes = [action.Forward, action.ReplyAll, action.Reply];
				for (var i = 0; i < params.length; i++) {
					var actionType = params[i];
					if (actionTypes.indexOf(actionType.name) !== -1) {
						return true;
					}
				}
				return false;
			},

			/**
			 * @obsolete
			 */
			setEmailAsRead: function() {
			},

			/**
			 * Adds additional columns to email select query.
			 * @protected
			 * @param {Object} esq Entity schema query.
			 */
			addAdditionalEmailSelectColumns: function(esq) {
				if (esq) {
					var fileCountColumn = Ext.create("BPMSoft.AggregationQueryColumn", {
						aggregationType: BPMSoft.AggregationType.COUNT,
						columnPath: "[ActivityFile:Activity].Id"
					});
					esq.addColumn(fileCountColumn, "FileCount");
				}
			},

			/**
			 * Creates email messate select query.
			 * @protected
			 * @param {String} emailId Email message id.
			 * @return {BPMSoft.EntitySchemaQuery} Email messate select query.
			 */
			getEmailSelect: function(emailId) {
				var esq = Ext.create("BPMSoft.EntitySchemaQuery", {rootSchemaName: "Activity"});
				var columns = this.getEmailSelectColumns();
				columns = Ext.Array.unique(columns);
				BPMSoft.each(columns, function(columnName) {
					esq.addColumn(columnName);
				}, this);
				this.addAdditionalEmailSelectColumns(esq);
				esq.enablePrimaryColumnFilter(emailId);
				return esq;
			},

			/**
			 * Sets selected sender value.
			 * @protected
			 */
			setSenderEnumFromSender: function() {
				var collection = this.getSenderCollection();
				if (!collection.isEmpty() || !this.isAddMode()) {
					this.setSenderEnumValue(this.get("Sender"));
				} else {
					this.set("Sender", "");
				}
			},

			/**
			 * Returns sender collection.
			 * @private
			 * @return {BPMSoft.Collection}
			 */
			getSenderCollection: function() {
				var mailboxSyncSettingsCollection = this.get("MailboxSyncSettingsCollection");
				if (this.hasProcessData()) {
					mailboxSyncSettingsCollection = mailboxSyncSettingsCollection.filterByFn(function(item) {
						if (item.get("SenderEmailAddress") === this.get("Sender")) {
							return true;
						}
					}, this);
				}
				return mailboxSyncSettingsCollection;
			},

			/**
			 * Sets 'SenderEnum' value.
			 * @protected
			 * @param {String} senderEmail Sender's email.
			 */
			setSenderEnumValue: function(senderEmail) {
				var senderEnum = this.get("SenderEnum");
				if (Ext.isEmpty(senderEnum) && !Ext.isEmpty(senderEmail)) {
					var senderEnumValue = {
						displayValue: senderEmail,
						value: "oldKey"
					};
					this.set("SenderEnum", senderEnumValue);
				}
			},

			/**
			 * Sets default sender value.
			 * @protected
			 */
			setDefaultSenderEnum: function(callback, scope) {
				var collection = this.get("MailboxSyncSettingsCollection");
				this.setDefaultSenderEnumFromCollection(collection, callback, scope);
			},

			/**
			 * Sets first mailbox as default one in case no mailbox is default.
			 * @protected
			 * @param {BPMSoft.data.model.BaseViewModelCollection} mailboxes Collection of mailboxes.
			 */
			setDefaultMailbox: function(mailboxes) {
				var forwardOrReply = this.checkActionName();
				if (!forwardOrReply) {
					return;
				}
				var hasDefault = false;
				mailboxes.each(function(item) {
					if (item.get("IsDefault")) {
						hasDefault = true;
						return false;
					}
				}, this);
				if (!hasDefault && mailboxes.getCount() > 0) {
					var firstMailbox = mailboxes.getByIndex(0);
					firstMailbox.set("IsDefault", true);
				}
			},

			/**
			 * Checks if action name is forward or reply.
			 * @protected
			 * @return {Boolean} Flag that is true if action name is forward or reply.
			 */
			checkActionName: function() {
				var actionType = this.get("EmailActionType");
				if (this.isEmpty(actionType)) {
					return false;
				}
				var forwardActionName = EmailConstants.emailAction.Forward;
				var replyActionName = EmailConstants.emailAction.Reply;
				var replyAllActionName = EmailConstants.emailAction.ReplyAll;
				var forwardOrReply = Ext.Array.indexOf([forwardActionName, replyActionName,
					replyAllActionName], actionType.name);
				var result = forwardOrReply >= 0;
				return result;
			},

			/**
			 * Redirects to mailbox settings page.
			 * @protected
			 * @param {String} result Confirmation dialor selected button code.
			 */
			addEmailForUser: function(result) {
				if (result === BPMSoft.MessageBoxButtons.YES.returnCode) {
					this.sandbox.publish("PushHistoryState", {hash: "MailboxSynchronizationSettingsModule"});
				}
			},

			/**
			 * Sets email default values.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			setDefaultValueByType: function(callback, scope) {
				var type = this.get("Type");
				if (!type || type.value !== ConfigurationConstants.Activity.Type.Email) {
					return Ext.callback(callback, scope || this);
				}
				if (!this.isAddMode()) {
					this.onDueDateChanged();
					return Ext.callback(callback, scope || this);
				}
				var startDate = this.get("StartDate");
				var dueDate = this.get("DueDate");
				var millisecondsInMinute = BPMSoft.core.enums.DateRate.MILLISECONDS_IN_MINUTE;
				var defaultTimeInterval = this.getDefaultTimeInterval();
				if (!dueDate || Ext.Date.getElapsed(startDate, dueDate) < 4 * millisecondsInMinute) {
					var defaultDueDate = Ext.Date.add(startDate, Ext.Date.MILLI, defaultTimeInterval);
					this.set("DueDate", defaultDueDate);
				} else {
					this.setDifferStartDueDate(startDate, dueDate);
				}
				var category = ConfigurationConstants.Activity.ActivityCategory.Email;
				var emailSendStatus = ConfigurationConstants.Activity.EmailSendStatus.NotSended;
				var emailMessageType = ConfigurationConstants.Activity.MessageType.Outgoing;
				var bq = Ext.create("BPMSoft.BatchQuery");
				bq.add(this.getLookupDisplayValueQuery({
					name: "ActivityCategory",
					value: category
				}));
				bq.add(this.getLookupDisplayValueQuery({
					name: "MessageType",
					value: emailMessageType
				}));
				bq.add(this.getLookupDisplayValueQuery({
					name: "EmailSendStatus",
					value: emailSendStatus
				}));
				bq.execute(function(response) {
					if (response && response.success) {
						this.set("ActivityCategory", response.queryResults[0].rows[0]);
						this.set("MessageType", response.queryResults[1].rows[0]);
						this.set("EmailSendStatus", response.queryResults[2].rows[0]);
					}
					Ext.callback(callback, scope || this);
				}, this);
			},

			/**
			 * Send button handler.
			 * @protected
			 */
			sendEmail: function(scope) {
				var activityId = scope.get("Id");
				scope.set("EmailSendStatus", {
					displayValue: "Sended",
					value: ConfigurationConstants.Activity.EmailSendStatus.Sended
				});
				EmailUtilities.send.call(this, activityId, function(response) {
					this.onSaved(response);
				});
			},

			/**
			 * Validates unhandled macros.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback execution context.
			 */
			validateUnhandledMacros: function(callback, scope) {
				scope = scope || this;
				var body = this.get("Body") || "";
				if (body.match(this.$UnhandledMacrosRegExp)) {
					var message = this.get("Resources.Strings.ValidateUnhandledMacrosMessage");
					this.showConfirmationDialog(message, function(result) {
						if (result === BPMSoft.MessageBoxButtons.YES.returnCode) {
							Ext.callback(callback, scope, [scope]);
						}
					}, ["yes", "no"]);
				} else {
					Ext.callback(callback, scope, [scope]);
				}
			},

			/**
			 * Creates history state object for reply actions.
			 * @protected
			 * @param {String} action Reply action name.
			 * @return {Object} New history state object.
			 */
			createNewHistoryState: function(action) {
				var link = this.getLink("link" + action);
				var moduleId = Ext.String.format("{0}_{1}", this.sandbox.id, action);
				return {
					hash: link,
					stateObj: {
						id: moduleId
					}
				};
			},

			/**
			 * Executes one of reply actions.
			 * @protected
			 * @param {String} action Reply action name.
			 */
			doReplyAction: function(action) {
				var newState = this.createNewHistoryState(action);
				this.sandbox.publish("PushHistoryState", newState);
			},

			/**
			 * Reply button handler.
			 * @protected
			 */
			replyEmail: function() {
				this.doReplyAction(EmailConstants.emailAction.Reply);
			},

			/**
			 * Reply all button handler.
			 * @protected
			 */
			replyAllEmail: function() {
				this.doReplyAction(EmailConstants.emailAction.ReplyAll);
			},

			/**
			 * Forward button handler.
			 * @protected
			 */
			forwardEmail: function() {
				this.doReplyAction(EmailConstants.emailAction.Forward);
			},

			/**
			 * Creates service request url.
			 * @protected
			 * @param {String} typeLink Email action type.
			 * @return {String} Service request url.
			 */
			getLink: function(typeLink) {
				var emailId = this.get("Id");
				var emailConfig = this.getModuleStructure("Activity");
				var typeId = this.get(emailConfig.attribute);
				var linkAddURL = [emailConfig.cardModule, "EmailPageV2", "add", emailConfig.attribute, typeId.value];
				if (typeLink === "linkReply") {
					return linkAddURL.join("/") + "/Reply/" + emailId;
				} else if (typeLink === "linkReplyAll") {
					return linkAddURL.join("/") + "/ReplyAll/" + emailId;
				} else if (typeLink === "linkForward") {
					return linkAddURL.join("/") + "/Forward/" + emailId;
				}
			},

			/**
			 * Shows select recepients lookup window.
			 * @protected
			 */
			openRecepientLookupEmail: function(searchValue, columnName) {
				var lookup = this.getLookupConfig(columnName || "Recepient");
				lookup.config.actionsButtonVisible = false;
				LookupUtilities.Open(this.sandbox, lookup.config, lookup.callback, this, null, false, false);
			},

			/**
			 * Adds view button "Go to schedule view" menu item.
			 * @protected
			 * @param {Object} viewOptions View button menu items collection.
			 */
			addSchedulerDataViewOption: function(viewOptions) {
				viewOptions.addItem(this.getButtonMenuItem({
					"Caption": {"bindTo": "Resources.Strings.SchedulerDataViewCaption"},
					"Click": {"bindTo": "changeDataView"},
					"Visible": {"bindTo": "getSchedulerDataViewOptionVisible"},
					"Tag": this.get("SchedulerDataViewName")
				}));
			},

			/**
			 * Adds view button "Go to list view" menu item.
			 * @protected
			 * @param {Object} viewOptions View button menu items collection.
			 */
			addGridDataViewOption: function(viewOptions) {
				viewOptions.addItem(this.getButtonMenuItem({
					"Caption": {"bindTo": "Resources.Strings.GridDataViewCaption"},
					"Click": {"bindTo": "changeDataView"},
					"Visible": {"bindTo": "getGridDataViewOptionVisible"},
					"Tag": this.get("GridDataViewName")
				}));
			},

			/**
			 * Sends action button visibility to activity section. Obsolete method, used for combined display mode.
			 * @protected
			 * @obsolete
			 * @param {String} actionKey [description]
			 * @param {Boolean} isVisible [description]
			 */
			sendActionVisibilityToActivitySection: function(actionKey, isVisible) {
				this.sandbox.publish("GetIsVisibleEmailPageButtons", {
					key: actionKey,
					value: isVisible
				});
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#getHeader
			 * @override
			 */
			getHeader: function() {
				return this.get("Resources.Strings.EmailPageCaption");
			},

			/**
			 * @inheritdoc BPMSoft.BasePage#setColumnValues
			 * @override
			 */
			setColumnValues: function(entity) {
				var isHtmlBody = entity.get("IsHtmlBody");
				var body = entity.get("Body");
				body = this.replaceImportantHeight(body);
				entity.set("Body", body.replace(/<base.*>/gi, ""));
				var plainTextMode = Ext.isEmpty(isHtmlBody) ? false : !isHtmlBody;
				this.set("PlainTextMode", plainTextMode);
				this.callParent(arguments);
			},

			/**
			 * Load sender contact to model.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			loadSenderContact: function(callback, scope) {
				var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "ActivityParticipant"
				});
				esq.addColumn("Participant");
				var roles = ConfigurationConstants.Activity.ParticipantRole;
				esq.filters.add("RoleFilter", esq.createColumnInFilterWithParameters(
					"Role", [roles.From, roles.DraftFrom]));
				esq.filters.add("ActivityFilter", esq.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "Activity", this.get("Id")));
				esq.getEntityCollection(callback, scope);
			},

			/**
			 * Sets sender contact to model.
			 * @protected
			 * @param {Object} response Sender request result.
			 */
			onSenderContactLoaded: function(response) {
				const collection = response && response.success && response.collection;
				if (collection && !collection.isEmpty()) {
					const row = collection.first();
					this.$SenderContact = row.get("Participant");
				}
			},

			/**
			 * Fills email sender information.
			 * @protected
			 */
			initSenderInfo: function() {
				var sender = this.get("Sender");
				if (!sender) {
					return;
				}
				var senderInfoRegExp = this.get("SenderInfoRegExp");
				var regExp = new RegExp(senderInfoRegExp);
				var senderInfo = sender.match(regExp);
				var senderName = senderInfo ? senderInfo[1] : "";
				var senderEmail = senderInfo ? senderInfo[2] : sender;
				this.set("SenderName", senderName);
				this.set("SenderEmail", senderEmail);
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#onEntityInitialized
			 * @override
			 */
			onEntityInitialized: function() {
				this.callParent(arguments);
				this.BPMSoft.chain(
					this._setInitialValues,
					this.setDefaultValueByType,
					this.setDefaultSenderEnum,
					function(next, callForwardOrReply) {
						if (!callForwardOrReply) {
							return this.Ext.callback(next, this);
						}
						this.setValuesByForwardOrReply(next, this);
					},
					function(next, response) {
						this.getEntityCallBack(response);
						this.Ext.callback(next, this);
					},
					function(next) {
						if (this.isAutoBindingContactEmailNeeded()) {
							this.loadSenderContact(next, this);
						} else {
							this.Ext.callback(next, this);
						}
					},
					function(next, response) {
						this.onSenderContactLoaded(response);
						this.Ext.callback(next, this);
					},
					this.initSenderInfo,
					this
				);
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#onPageInitialized
			 * @override
			 */
			onPageInitialized: function(callback, scope) {
				if (!this.get("SenderEnumList")) {
					this.set("SenderEnumList", Ext.create("BPMSoft.Collection"));
				}
				if (!this.get("Images")) {
					this.set("Images", Ext.create("BPMSoft.BaseViewModelCollection"));
				}
				this.initMailboxSyncSettingsCollection(callback, scope);
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#asyncValidate
			 * @override
			 */
			asyncValidate: function(callback, scope) {
				this.callParent([function(response) {
					if (!this.validateResponse(response)) {
						return;
					}
					BPMSoft.chain(
						this.validateStartDate,
						function(next, response) {
							if (this.validateResponse(response)) {
								this.Ext.callback(next, this);
							}
						},
						function(next) {
							var contact = this.changedValues.Contact;
							if (contact && contact.value && this.isAutoBindingContactEmailNeeded()) {
								this.actualizeSenderRelation(contact.value, next, this);
							} else {
								this.Ext.callback(next, this);
							}
						},
						function() {
							this.Ext.callback(callback, scope, [response]);
						}, this);
				}, this]);
			},

			/**
			 * Processes record saved.
			 * @protected
			 * @param {Object} response Server on saved response.
			 * @param {Object} config Saving config.
			 * @param {Boolean} skipAttachmentCopy Flag, if true then attachments will not be copied.
			 */
			onSaved: function(response, config, skipAttachmentCopy) {
				var forwardEmailId = this.get("SourceEntityPrimaryColumnValue");
				if (config && config.callParent === true) {
					this.callParent(arguments);
					if (config.setOperation) {
						this.set("Operation", config.setOperation);
					}
				} else if (forwardEmailId && skipAttachmentCopy === false) {
					var requestConfig = {
						serviceName: "EntityUtilsService",
						methodName: "CopyEntities",
						data: {
							sourceEntityId: forwardEmailId,
							recipientEntityId: this.get("Id"),
							columnName: "Activity",
							entitySchemaName: "Activity",
							sourceEntitySchemaNames: ["ActivityFile"]
						}
					};
					this.callService(requestConfig, function() {
						config = (config && config.length === 1) ? config[0] : (config || {});
						config.callParent = true;
						this.set("ForwardOrReplyValuesSet", true);
							this.set("SourceEntityPrimaryColumnValue", null);
							this.onSaved(response, config);
						}, this);
				} else {
					config = (config && config.length === 1) ? config[0] : (config || {});
					config.callParent = true;
					this.onSaved(response, config);
				}
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#addListSettingsOption
			 * @override
			 */
			addListSettingsOption: function(viewOptions) {
				viewOptions.addItem(this.getButtonMenuItem({
					"Caption": {"bindTo": "Resources.Strings.OpenListSettingsCaption"},
					"Click": {"bindTo": "openGridSettings"},
					"Visible": {"bindTo": "getListSettingsOptionVisible"}
				}));
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#subscribeDetailEvents
			 * @override
			 */
			subscribeDetailEvents: function(detailConfig, detailName) {
				this.callParent(arguments);
				var detailId = this.getDetailId(detailName);
				this.sandbox.subscribe("GetLookupValuePairs", this.getLookupValuePairs, this, [detailId]);
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#getCardContentContainerMarkerValue
			 * @overriden
			 */
			getCardContentContainerMarkerValue: function() {
				return (this.get("IsEntityInitialized") && this.get("ForwardOrReplyValuesSet"))
					? "EntityLoaded"
					: "loading";
			},

			/**
			 * Returns new FileReader instance.
			 * @protected
			 * @virtual
			 * @return {FileReader} FileReader instance.
			 */
			getFileReader: function() {
				return new FileReader();
			},

			//endregion

			//region Methods: Public

			/**
			 * Validates email before send.
			 */
			checkSenderBeforeSend: function() {
				var sender = this.get("Sender");
				var recipient = this.get("Recepient");
				var copyRecipient = this.get("CopyRecepient");
				var blindCopyRecipient = this.get("BlindCopyRecepient");
				if (this.isEmpty(sender)) {
					this.showInformationDialog(this.get("Resources.Strings.SendEmailForUserQuestion"));
					return;
				}
				if (this.isEmpty(recipient) && this.isEmpty(copyRecipient) && this.isEmpty(blindCopyRecipient)) {
					this.showInformationDialog(this.get("Resources.Strings.RecepientEmailForUserQuestion"));
					return;
				}
				if (this.isAddMode()) {
					if (this.isChanged()) {
						this.asyncValidate(function() {
							this.saveEntity(function() {
								this.validateUnhandledMacros(this.sendEmail, this);
							});
						}, this);
					} else {
						this.validateUnhandledMacros(this.sendEmail, this);
					}
				} else if (this.isChanged()) {
					this.saveEntity(function() {
						this.validateUnhandledMacros(this.sendEmail, this);
					});
				} else {
					this.validateUnhandledMacros(this.sendEmail, this);
				}
			},

			/**
			 * Lookup records selected event handler.
			 * @param {Object} config Selected data config.
			 */
			onLookupSelected: function(config) {
				var columnName = config.columnName;
				var isContactEmpty = Ext.isEmpty(this.get("Contact"));
				var items = config.selectedRows.collection.items;
				this.recepientCollection = this.recepientCollection || [];
				var collection = this.recepientCollection;
				var columnValue = this.get(columnName);
				columnValue = Ext.isString(columnValue)
					? columnValue.trim()
					: columnValue && columnValue.displayValue || "";
				if (Ext.isEmpty(columnValue)) {
					columnValue = "";
				} else {
					columnValue = columnValue.trim();
					var addSymbol = columnValue[columnValue.length - 1] === ";" ? " " : "; ";
					columnValue = columnValue + addSymbol;
				}
				BPMSoft.each(items, function(item) {
					var contactId = item.ContactId;
					if (isContactEmpty && Ext.isEmpty(columnValue)
						&& (columnName === "Recepient" || columnName === "Recipient")) {
						this.loadLookupDisplayValue("Contact", contactId);
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
			 * StartDate column validation method. Checks if start date less than due date.
			 * @param {Object} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			validateStartDate: function(callback, scope) {
				var result = {
					success: true
				};
				var plainTextMode = this.get("PlainTextMode");
				this.set("IsHtmlBody", !plainTextMode);
				if (this.get("StartDate") > this.get("DueDate")) {
					result.message = this.get("Resources.Strings.StartDateGreaterDueDate");
					result.success = false;
				}
				callback.call(scope || this, result);
			},

			/**
			 * DueDate column validation method. Checks if start date less than due date.
			 * @return {Boolean} Validation result.
			 */
			validateDueDate: function() {
				var startDate = this.get("StartDate");
				var dueDate = this.get("DueDate");
				if (Ext.isEmpty(startDate) || Ext.isEmpty(dueDate)) {
					return false;
				}
				if (startDate > dueDate) {
					this.showInformationDialog(this.get("Resources.Strings.StartDateGreaterDueDate"));
					return false;
				}
				return true;
			},

			/**
			 * Sets activity duration property value.
			 * @param {DateTime} startDate Start date.
			 * @param {DateTime} dueDate Due date.
			 */
			setDifferStartDueDate: function(startDate, dueDate) {
				var difference = {};
				if (startDate.getTime() < dueDate.getTime()) {
					difference = dueDate.getTime() - startDate.getTime();
				} else {
					difference = this.getDefaultTimeInterval();
				}
				this.set("DifferStartDueDate", difference);
			},

			/**
			 * Copies original message column values.
			 * @param {Object} entity Original message.
			 * @param {Object} actionType Email action type.
			 */
			copyEntityColumnValues: function(entity, actionType) {
				if (entity) {
					var connectedColumns = this.get("EntityConnectionColumnList");
					BPMSoft.each(connectedColumns, function(column) {
						var value = entity.get(column);
						if (value) {
							this.set(column, value, {silent: true});
							this.changedValues[column] = value;
						}
					}, this);
				}
				this.updateRecepientsOnReply(entity, actionType);
			},

			/**
			 * Replace inline attachments ids when message copied.
			 * @param {Object} responseIds Dictionary containing source and target attachments ids.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			replaceContentIds: function(responseIds, callback, scope) {
				var body = this.get("Body");
				var entities = responseIds.CopyEntitiesResult;
				if (!Ext.isEmpty(entities)) {
					for (var i = 0; i < entities.length; i++) {
						var sourceFileId = entities[i].Key;
						var targetFileId = entities[i].Value;
						var regex = new RegExp(sourceFileId, "g");
						body = body.replace(regex, targetFileId);
					}
					this.set("Body", body);
				}
				callback.call(scope);
			},

			/**
			 * Extract inline attachments ids from message.
			 * @return {Array} Array of inline attachments ids.
			 */
			extractContentIds: function() {
				var body = this.get("Body");
				if (this.isEmpty(body)) {
					return null;
				}
				var oldPattern = /id=[A-Z0-9]{8}-[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{12}/gim;
				var rawRegExp = "GetFile/(.+?)/[A-Z0-9]{8}-[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{12}";
				var newPattern = new RegExp(rawRegExp, "gim");
				var idsInBody = body.match(oldPattern);
				var oldIds = [];
				if (idsInBody !== null) {
					oldIds = Ext.Array.unique(idsInBody.map(function(element) {
						return element.substring(3);
					}));
				}
				idsInBody = body.match(newPattern);
				var newIds = [];
				if (idsInBody !== null) {
					newIds = Ext.Array.unique(idsInBody.map(function(element) {
						var parts = element.split("/");
						return parts[2];
					}));
				}
				return Ext.Array.merge(oldIds, newIds);
			},

			/**
			 * @inheritdoc BPMSoft.configuration.mixins.QuickAddMixin#getAddButtonMenuVisible
			 * @override
			 */
			getAddButtonMenuVisible: function() {
				return true;
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#addChangeDataViewOptions
			 * @override
			 */
			addChangeDataViewOptions: function(viewOptions) {
				this.addSchedulerDataViewOption(viewOptions);
				this.addGridDataViewOption(viewOptions);
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#getLookupValuePairs
			 * @override
			 */
			getLookupValuePairs: function(columnName) {
				var valuePairs = [];
				var column = this.getColumnByName(columnName);
				if (!Ext.isEmpty(column) && !Ext.isEmpty(column.referenceSchemaName) &&
					column.referenceSchemaName === "Contact") {
					var account = this.get("Account");
					if (!Ext.isEmpty(account)) {
						valuePairs.push({
							name: "Account",
							value: account.value
						});
					}
					if (this.isAutoBindingContactEmailNeeded()) {
						this.addSenderInfo(valuePairs);
					}
				}
				return valuePairs;
			},

			/**
			 * @inheritdoc BPMSoft.ExtendedHtmlEditModuleUtilities#onOpenEmailTemplate
			 * @override
			 */
			onOpenEmailTemplate: function(control) {
				if (Ext.isEmpty(this.get("Title"))) {
					this.set("Title", this.get("Resources.Strings.NoSubjectCaption"));
				}
				var utils = this.mixins.ExtendedHtmlEditModuleUtilities;
				var config = {
					isSilent: true,
					callback: utils.onOpenEmailTemplate.bind(this, control),
					callBaseSilentSavedActions: true,
					scope: this
				};
				this.save(config);
			},

			/**
			 * @inheritdoc BPMSoft.BasePAgeV2#getActions
			 * @override
			 */
			getActions: function() {
				var actionMenuItems = this.callParent(arguments);
				this.addDeleteDraftAction(actionMenuItems);
				this.addShowRelatedAction(actionMenuItems);
				return actionMenuItems;
			},

			/**
			 * Adds related emails action to actions menu.
			 * @protected
			 * @param {BPMSoft.BaseViewModelCollection} collection Item menu collection.
			 */
			addShowRelatedAction: function(actionMenuItems) {
				actionMenuItems.addItem(Ext.create("BPMSoft.BaseViewModel", {
						"values": {
							"Id": BPMSoft.generateGUID(),
							"Caption": {"bindTo": "Resources.Strings.ShowRelatedEmails"},
							"Click": {"bindTo": "onShowRelatedEmails"},
							"Visible": {"bindTo": "getRelatedEmailsVisible"},
							"MarkerValue": {"bindTo": "Resources.Strings.ShowRelatedEmails"}
						}
					}
				));
			},

			/**
			 * Adds delete draft action to actions menu.
			 * @protected
			 * @param {BPMSoft.BaseViewModelCollection} collection Item menu collection.
			 */
			addDeleteDraftAction: function(actionMenuItems) {
				actionMenuItems.addItem(Ext.create("BPMSoft.BaseViewModel", {
						"values": {
							"Id": BPMSoft.generateGUID(),
							"Caption": {bindTo: "Resources.Strings.DeleteDraftButtonCaption"},
							"Click": {"bindTo": "deleteDraft"},
							"Enabled": {"bindTo": "getDeleteDraftEnabled"},
							"MarkerValue": {bindTo: "Resources.Strings.DeleteDraftButtonCaption"}
						}
					}
				));
			},

			/**
			 * Loads related to current email emails to panel.
			 * @protected
			 */
			onShowRelatedEmails: function() {
				this.sandbox.publish("ShowRelatedEmails", this.$Id);
			},

			/**
			 * @inheritdoc BPMSoft.ExtendedHtmlEditModuleUtilities#addCallBack
			 * @override
			 */
			addCallBack: function(args, result) {
				const selectedItems = args.selectedRows.getItems();
				const selectedItem = selectedItems.length && selectedItems[0];
				if (!Ext.isEmpty(selectedItem)) {
					if (!Ext.isEmpty(selectedItem.Subject) && !this._isEmailTemplateMultiLanguage()) {
						this.set("Title", selectedItem.Subject);
					}
					if (!Ext.isEmpty(selectedItem.Body)) {
						this._setHtmlEditMode();
						const serviceRequest = this._isEmailTemplateMultiLanguage()
							? this.getMultilanguageMacrosHelperServiceRequest(selectedItem)
							: this.getMacrosHelperServiceRequest(selectedItem);
						this.showBodyMask();
						serviceRequest.execute(this.macrosServiceCallback.bind(this, result, selectedItem.Name));
					}
				}
			},

			/**
			 * Gets macros helper service request.
			 * @param {Object} selectedItem Lookup selected values.
			 * @returns {BPMSoft.MacrosHelperServiceRequest} Service request.
			 */
			getMacrosHelperServiceRequest: function(selectedItem) {
				return Ext.create("BPMSoft.MacrosHelperServiceRequest", {
					contractName: "GetTemplate",
					entityId: this.get("Id"),
					entityName: "Activity",
					textTemplate: selectedItem.Body
				});
			},

			/**
			 * Gets multilanguage macros helper service request.
			 * @param {Object} selectedItem Lookup selected values.
			 * @returns {BPMSoft.MacrosHelperServiceRequest} Service request.
			 */
			getMultilanguageMacrosHelperServiceRequest: function(selectedItem) {
				return Ext.create("BPMSoft.MacrosHelperServiceRequest", {
					contractName: "GetMultiLanguageTextTemplate",
					entityId: this.get("Id"),
					entityName: "Activity",
					templateId: selectedItem.Id
				});
			},

			/**
			 * Checks feature status.
			 * @private
			 * @return {Boolean} feature state.
			 */
			_isEmailTemplateMultiLanguage: function() {
				return this.getIsFeatureEnabled("EmailTemplateMultiLanguageInEmailPage");
			},

			/**
			 * Sets Body value from response.
			 * @protected
			 * @param {Object} result Object contains control instance.
			 * @param {String} templateName Name of template.
			 * @param {Object} response Server response.
			 */
			macrosServiceCallback: function(result, templateName, response) {
				this.hideBodyMask();
				if (this.validateResponse(response)) {
					this.setSubjectTemplate(response.subjectTemplate);
					let textTemplate = response.textTemplate;
					const isTextTemplateIncludesEmptySignature = textTemplate.includes(this.getEmptySignature());
					if (isTextTemplateIncludesEmptySignature) {
						textTemplate = this.addSignatureToTemplate(textTemplate);
					}
					var item = {
						body: textTemplate,
						value: templateName,
						isFromButton: true
					};
					const extendedHtmlEditModule = result.control;
					extendedHtmlEditModule.setTrackingValue(item, function(bodyValue) {
						bodyValue = bodyValue || extendedHtmlEditModule.getBodyValue() || BPMSoft.emptyString;
						this.set("Body", bodyValue.trim());
						if (isTextTemplateIncludesEmptySignature) {
							this.$Body = this.replaceSignatureAfterTemplateWithSignature();
						}
					}, this);
				}
			},

			/** Replaces signature after template with signature.
			 * @protected
			 * @return {String} Body without unnecessary signature.
			 */
			replaceSignatureAfterTemplateWithSignature: function() {
				const body = this.$Body;
				const match = body.match(this.getSignatureRegExp());
				if (!match) {
					return body;
				}
				const template = match[0];
				let index = body.indexOf(template) + template.length;
				let text = body.substring(index);
				text = text.replace(this.getSignatureRegExp(), BPMSoft.emptyString);
				return body.substring(0, index) + text;
			},

			/**
			 * Set template subject.
			 * @protected
			 * @virtual
			 * @param {String} subjectTemplate Subject template.
			 */
			setSubjectTemplate: function(subjectTemplate) {
				var subjectCaption = this.get("Resources.Strings.NoSubjectCaption");
				var title = this.get("Title");
				if (Ext.isEmpty(title) || title === subjectCaption) {
					this.set("Title", subjectTemplate);
				}
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#onRender
			 * @override
			 */
			onRender: function() {
				this.callParent(arguments);
				if (this.get("IsEntityInitialized")) {
					this.hideBodyMask();
				}
			},

			/**
			 * Returns html editor visibility.
			 * @return {Boolean} html editor visibility.
			 */
			getHtmlEditorVisible: function() {
				return !this.getBodyPreviewVisible();
			},

			/**
			 * Returns html preview frame visibility.
			 * @return {Boolean} Html preview frame visibility.
			 */
			getBodyPreviewVisible: function() {
				if (!this.getIsFeatureEnabled("EmailReadonlyAsHtml")) {
					return false;
				}
				var status = this.$EmailSendStatus;
				return (status && status.value === ConfigurationConstants.Activity.EmailSendStatus.Sended);
			},

			/**
			 * Returns html preview frame content.
			 * @return {Boolean} Html preview frame content.
			 */
			getIframeContent: function() {
				if (!this.$PlainTextMode) {
					return this.$Body;
				}
				return Ext.String.format("<pre style=\"font-family: 'Golos Regular';\">{0}</pre>",  _.escape(this.$Body));
			},

			/**
			 * Returns related emails detail visibility.
			 * @return {Boolean} Related emails detail visibility.
			 */
			getRelatedEmailsVisible: function() {
				return !this.isAddMode();
			},

			/**
			 * Returns need sanitize html in html editor.
			 * @return {Boolean} Need sanitize html in html editor.
			 */
			getNeedSanitizeHtml: function() {
				return this.getIsFeatureEnabled("SanitizeHtml");
			},

			/**
			 * Calls delete for current record.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			deleteDraft: function(callback, scope) {
				var message = this.get("Resources.Strings.DeleteConfirmationMessage");
				this.showConfirmationDialog(message, function(result) {
					if (result === BPMSoft.MessageBoxButtons.YES.returnCode) {
						this.showBodyMask();
						var primaryColumnValue = this.getPrimaryColumnValue();
						var deleteQuery = this.getDeleteQuery();
						deleteQuery.enablePrimaryColumnFilter(primaryColumnValue);
						deleteQuery.execute(function () {
							this.hideBodyMask();
							this.onBackButtonClick();
							Ext.callback(callback, scope || this);
						}, this);
					} else {
						Ext.callback(callback, scope || this);
					}
				}, ["yes", "no"]);
			},

			/**
			 * Checks is delete draft action enabled.
			 */
			getDeleteDraftEnabled: function() {
				var hasProcessData = this.hasProcessData();
				var addMode = this.isAddMode();
				var isSaved = this.isNotEmpty(this.get("IsSavedEntity"));
				var status = this.$EmailSendStatus;
				var isSent = (!this.isEmpty(status) && status.value === ConfigurationConstants.Activity.EmailSendStatus.Sended);
				return !isSent && !hasProcessData && (!addMode || (addMode && isSaved));
			},

			/**
			 * Event handler for property OwnerRole change
			 * @protected
			 */
			onOwnerRoleChange: function() {
				if (this.get("OwnerRole") != null) {
					this.set("Owner", null);
				}
			},

			/**
			 * @private
			 */
			_getIsUseProcessPerformerAssignment: function() {
				return this.getIsFeatureEnabled("UseProcessPerformerAssignment");
			}

			//endregion

		},
		modules: /**SCHEMA_MODULES*/{
			"EmailSyncErrors": {
				"config": {
					"isSchemaConfigInitialized": true,
					"schemaName": "SyncSettingsErrors",
					"useHistoryState": false
				}
			}
		}/**SCHEMA_MODULES*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "CardContentWrapper",
				"values": {
					"markerValue": {
						"bindTo": "getCardContentContainerMarkerValue"
					}
				}
			},
			{
				"operation": "insert",
				"name": "EmailSyncErrors",
				"propertyName": "items",
				"parentName": "CardContentContainer",
				"index": 1,
				"values": {
					"itemType": BPMSoft.ViewItemType.MODULE,
					"classes": {"wrapClassName": ["sync-settings-errors", "email-publisher-sync-errors"]}
				}
			},
			{
				"operation": "insert",
				"name": "EmailMessageTab",
				"parentName": "Tabs",
				"propertyName": "tabs",
				"values": {
					"caption": {"bindTo": "Resources.Strings.EmailMessageTabCaption"},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "EmailGeneralInfoTab",
				"parentName": "Tabs",
				"propertyName": "tabs",
				"values": {
					"caption": {"bindTo": "Resources.Strings.EmailGeneralInfoTabCaption"},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "EmailAttachingTab",
				"parentName": "Tabs",
				"propertyName": "tabs",
				"values": {
					"caption": {"bindTo": "Resources.Strings.EmailAttachingTabCaption"},
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "LeftContainer",
				"propertyName": "items",
				"name": "send",
				"index": 0,
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.SendEmailAction"},
					"layout": {
						"column": 6,
						"row": 0,
						"colSpan": 2
					},
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
					"classes": {"textClass": ["actions-button-margin-right"]},
					"click": {
						"bindTo": "checkSenderBeforeSend"
					},
					"visible": {
						"bindTo": "getIsVisibleSendButton"
					},
					"clickDebounceTimeout": 1000
				}
			},
			{
				"operation": "insert",
				"parentName": "LeftContainer",
				"propertyName": "items",
				"name": "reply",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.ReplyActionCaption"},
					"layout": {
						"column": 8,
						"row": 0,
						"colSpan": 2
					},
					"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
					"classes": {"textClass": ["actions-button-margin-right"]},
					"click": {
						"bindTo": "replyEmail"
					},
					"visible": {
						"bindTo": "getIsVisibleReplyButton"
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "LeftContainer",
				"propertyName": "items",
				"name": "replyAll",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.ReplyAllActionCaption"},
					"layout": {
						"column": 10,
						"row": 0,
						"colSpan": 2
					},
					"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
					"classes": {"textClass": ["actions-button-margin-right"]},
					"click": {
						"bindTo": "replyAllEmail"
					},
					"visible": {
						"bindTo": "getIsVisibleReplyButton"
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "LeftContainer",
				"propertyName": "items",
				"name": "forward",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.ForwardActionCaption"},
					"layout": {
						"column": 13,
						"row": 0,
						"colSpan": 2
					},
					"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
					"click": {
						"bindTo": "forwardEmail"
					},
					"visible": {
						"bindTo": "getIsVisibleForwardButton"
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "LeftContainer",
				"propertyName": "items",
				"name": "forwardOUT",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.ForwardActionCaption"},
					"layout": {
						"column": 14,
						"row": 0,
						"colSpan": 2
					},
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
					"click": {
						"bindTo": "forwardEmail"
					},
					"visible": {
						"bindTo": "getIsVisibleForwardOUTButton"
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "SenderEnum",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 11
					},
					"bindTo": "SenderEnum",
					"controlConfig": {
						"className": "BPMSoft.ComboBoxEdit",
						"list": {
							"bindTo": "SenderEnumList"
						},
						"prepareList": {
							"bindTo": "loadSenders"
						},
						"placeholder": {"bindTo": "Resources.Strings.SenderPlaceholder"}
					},
					"isRequired": true
				}
			},
			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "SendDate",
				"values": {
					"bindTo": "SendDate",
					"caption": {"bindTo": "Resources.Strings.SendDateCaption"},
					"enabled": false,
					"layout": {
						"column": 13,
						"row": 0,
						"colSpan": 11
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "EmailAttachingTab",
				"propertyName": "items",
				"name": "Files",
				"values": {
					"itemType": BPMSoft.ViewItemType.DETAIL
				}
			},
			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "Recepient",
				"values": {
					"bindTo": "Recepient",
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 24
					},
					"controlConfig": {
						"className": "BPMSoft.TextEdit",
						"rightIconClasses": ["custom-right-item", "lookup-edit-right-icon"],
						"rightIconClick": {
							"bindTo": "openRecepientLookupEmail"
						},
						"placeholder": {"bindTo": "Resources.Strings.RecepientPlaceholder"}
					},
					"isRequired": true,
					"enabled": {
						"bindTo": "isEmailSendStatusNotSent"
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "Header",
				"name": "ToggleHeaderContainer",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 2,
						"colSpan": 24
					},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "ToggleHeaderContainer",
				"propertyName": "items",
				"name": "ToggleCopyRecipientVisible",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.CC"},
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"click": {"bindTo": "fieldVisibleToggleClick"},
					"tag": "isCopyRecipientVisible"
				}
			},
			{
				"operation": "insert",
				"parentName": "ToggleHeaderContainer",
				"propertyName": "items",
				"name": "ToggleBlindCopyRecipientVisible",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.BCC"},
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"click": {"bindTo": "fieldVisibleToggleClick"},
					"tag": "isBlindCopyRecipientVisible"
				}
			},
			{
				"operation": "insert",
				"parentName": "Header",
				"name": "EmailPageHeaderContainer",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 3,
						"colSpan": 24
					},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "EmailPageHeaderContainer",
				"propertyName": "items",
				"name": "CopyRecepient",
				"values": {
					"bindTo": "CopyRecepient",
					"controlConfig": {
						"className": "BPMSoft.TextEdit",
						"rightIconClasses": ["custom-right-item", "lookup-edit-right-icon"],
						"rightIconClick": {"bindTo": "openCopyRecepientLookupEmail"},
						"placeholder": {"bindTo": "Resources.Strings.CopyRecepientPlaceholder"}
					},
					"visible": {"bindTo": "isCopyRecipientVisible"},
					"enabled": {
						"bindTo": "isEmailSendStatusNotSent"
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "EmailPageHeaderContainer",
				"propertyName": "items",
				"name": "BlindCopyRecepient",
				"values": {
					"bindTo": "BlindCopyRecepient",
					"controlConfig": {
						"className": "BPMSoft.TextEdit",
						"rightIconClasses": ["custom-right-item", "lookup-edit-right-icon"],
						"rightIconClick": {"bindTo": "openBlindCopyRecepientLookupEmail"},
						"placeholder": {"bindTo": "Resources.Strings.BlindCopyRecepientPlaceholder"}
					},
					"visible": {"bindTo": "isBlindCopyRecipientVisible"},
					"enabled": {
						"bindTo": "isEmailSendStatusNotSent"
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "EmailPageHeaderContainer",
				"name": "AdditionalHeaderContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"id": "AdditionalHeaderContainer",
					"selectors": {"wrapEl": "#AdditionalHeaderContainer"}
				}
			},
			{
				"operation": "insert",
				"parentName": "AdditionalHeaderContainer",
				"propertyName": "items",
				"name": "AdditionalHeaderBlock",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "AdditionalHeaderBlock",
				"name": "TitleFieldContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"id": "TitleFieldContainer",
					"selectors": {"wrapEl": "#TitleFieldContainer"},
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 24
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "AdditionalHeaderBlock",
				"name": "InformationOnStepButtonContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"id": "InformationOnStepButtonContainer",
					"selectors": {"wrapEl": "#InformationOnStepButtonContainer"},
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 1
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "TitleFieldContainer",
				"propertyName": "items",
				"name": "Title",
				"values": {
					"bindTo": "Title",
					"caption": {"bindTo": "Resources.Strings.TitleCaption"},
					"markerValue": {"bindTo": "Resources.Strings.TitleCaption"},
					"controlConfig": {
						"placeholder": {"bindTo": "Resources.Strings.TitlePlaceholder"}
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "EmailMessageTab",
				"name": "EmailPageMessageTabContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"classes": {"wrapClassName": ["email-page-tab-container"]}
				}
			},
			{
				"operation": "insert",
				"parentName": "EmailGeneralInfoTab",
				"name": "EmailPageGeneralInfoTabContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "EmailPageMessageTabContainer",
				"name": "MessageControlGroup",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "Body",
				"parentName": "MessageControlGroup",
				"propertyName": "items",
				"values": {
					"markerValue": "EmailBody",
					"generateId": false,
					"className": "BPMSoft.ExtendedHtmlEdit",
					"itemType": BPMSoft.ViewItemType.MODEL_ITEM,
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"contentType": BPMSoft.ContentType.RICH_TEXT,
					"labelConfig": {
						"visible": false
					},
					"value": {"bindTo": "Body"},
					"height": "350px",
					"fitContent": true,
					"prepareList": {"bindTo": "prepareEntitiesExpandableList"},
					"list": {"bindTo": "EntitiesList"},
					"listViewItemRender": {"bindTo": "onEntitiesListViewItemRender"},
					"openEmailTemplate": {"bindTo": "onOpenEmailTemplate"},
					"toolbarVisible": true,
					"visible": {"bindTo": "getHtmlEditorVisible"},
					"controlConfig": {
						"imageLoaded": {
							"bindTo": "onImageLoaded"
						},
						"imagePasted": {
							"bindTo": "onImagePasted"
						},
						"images": {
							"bindTo": "Images"
						},
						"plainTextMode": {
							"bindTo": "PlainTextMode"
						},
						"defaultFontFamily": "Segoe UI"
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "MessageControlGroup",
				"propertyName": "items",
				"name": "ReadonlyBody",
				"values": {
					"generator": function() {
						return {
							"markerValue": "ReadOnlyEmailBody",
							"visible": {"bindTo": "getBodyPreviewVisible"},
							"bordersWidth": 30,
							"fitHeightToContent": true,
							"className": "BPMSoft.IframeControl",
							"wrapClass": ["email-dispaly-iframe"],
							"iframeContent": {
								"bindTo": "getIframeContent"
							},
							"sanitizeHtml": {
								"bindTo": "getNeedSanitizeHtml"
							}
						};
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "EmailPageGeneralInfoTabContainer",
				"name": "GeneralInfoControlGroup",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"items": [],
					"controlConfig": {
						"collapsed": false
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "GeneralInfoControlGroup",
				"propertyName": "items",
				"name": "EmailPageGeneralInfoBlock",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "EmailPageGeneralInfoBlock",
				"propertyName": "items",
				"name": "OwnerRole",
				"values": {
					"bindTo": "OwnerRole",
					"layout": {
						"column": 0,
						"row": 3,
						"colSpan": 11
					},
					"visible": {
						"bindTo": "_getIsUseProcessPerformerAssignment"
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "EmailPageGeneralInfoBlock",
				"propertyName": "items",
				"name": "Owner",
				"values": {
					"bindTo": "Owner",
					"layout": {
						"column": 0,
						"row": 4,
						"colSpan": 11
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "EmailPageGeneralInfoBlock",
				"propertyName": "items",
				"name": "Author",
				"values": {
					"bindTo": "Author",
					"layout": {
						"column": 0,
						"row": 5,
						"colSpan": 11
					},
					"enabled": false
				}
			},
			{
				"operation": "insert",
				"parentName": "EmailPageGeneralInfoBlock",
				"propertyName": "items",
				"name": "Priority",
				"values": {
					"bindTo": "Priority",
					"layout": {
						"column": 13,
						"row": 1,
						"colSpan": 11
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "EmailPageGeneralInfoBlock",
				"propertyName": "items",
				"name": "ShowInScheduler",
				"values": {
					"bindTo": "ShowInScheduler",
					"layout": {
						"column": 0,
						"row": 2,
						"colSpan": 11
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "EmailPageGeneralInfoBlock",
				"propertyName": "items",
				"name": "Status",
				"values": {
					"caption": {"bindTo": "Resources.Strings.EmailSendStatusCaption"},
					"bindTo": "Status",
					"layout": {
						"column": 13,
						"row": 0,
						"colSpan": 11
					},
					"contentType": "BPMSoft.ContentType.ENUM"
				}
			},
			{
				"operation": "insert",
				"parentName": "EmailPageGeneralInfoBlock",
				"propertyName": "items",
				"name": "StartDate",
				"values": {
					"bindTo": "StartDate",
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 11
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "EmailPageGeneralInfoBlock",
				"propertyName": "items",
				"name": "DueDate",
				"values": {
					"bindTo": "DueDate",
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 11
					},
					"controlConfig": {
						"timeEdit": {
							"controlConfig": {
								"prepareList": {
									"bindTo": "loadDueDateList"
								}
							}
						}
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "EmailGeneralInfoTab",
				"propertyName": "items",
				"name": "EntityConnections",
				"values": {
					"itemType": BPMSoft.ViewItemType.DETAIL
				}
			},
			{
				"operation": "insert",
				"parentName": "EmailGeneralInfoTab",
				"propertyName": "items",
				"name": "RelatedEmails",
				"values": {
					"itemType": BPMSoft.ViewItemType.DETAIL,
					"visible": {"bindTo": "getRelatedEmailsVisible"}
				}
			},
			{
				"operation": "merge",
				"name": "SaveButton",
				"values": {
					"style": {"bindTo": "changeButtonColorIfSendButtonExists"}
				}
			},
			{
                "operation": "merge",
                "name": "CloseButton",
                "values": {
                    "style": {"bindTo": "changeButtonColorIfSendButtonExists"}
                }
            },
			{
				"operation": "merge",
				"name": "DiscardChangesButton",
				"values": {
					"style": {"bindTo": "changeDiscardChangesButtonColorIfSendButtonExists"}
				}
			}

		]/**SCHEMA_DIFF*/,
		rules: {
			"SenderEnum": {
				"BindParameterEnabledSenderEnumToEmailSendStatus": {
					"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
					"property": BusinessRuleModule.enums.Property.ENABLED,
					"conditions": [
						{
							"leftExpression": {
								"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
								"attribute": "EmailSendStatus"
							},
							"comparisonType": BPMSoft.ComparisonType.NOT_EQUAL,
							"rightExpression": {
								"type": BusinessRuleModule.enums.ValueType.CONSTANT,
								"value": ConfigurationConstants.Activity.EmailSendStatus.Sended
							}
						}
					]
				}
			},
			"Recepient": {
				"BindParameterEnabledRecepientToEmailSendStatus": {
					"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
					"property": BusinessRuleModule.enums.Property.ENABLED,
					"conditions": [
						{
							"leftExpression": {
								"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
								"attribute": "EmailSendStatus"
							},
							"comparisonType": BPMSoft.ComparisonType.NOT_EQUAL,
							"rightExpression": {
								"type": BusinessRuleModule.enums.ValueType.CONSTANT,
								"value": ConfigurationConstants.Activity.EmailSendStatus.Sended
							}
						}
					]
				}
			},
			"CopyRecepient": {
				"BindParameterEnabledCopyRecepientToEmailSendStatus": {
					"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
					"property": BusinessRuleModule.enums.Property.ENABLED,
					"conditions": [
						{
							"leftExpression": {
								"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
								"attribute": "EmailSendStatus"
							},
							"comparisonType": BPMSoft.ComparisonType.NOT_EQUAL,
							"rightExpression": {
								"type": BusinessRuleModule.enums.ValueType.CONSTANT,
								"value": ConfigurationConstants.Activity.EmailSendStatus.Sended
							}
						}
					]
				}
			},
			"BlindCopyRecepient": {
				"BindParameterEnabledBlindCopyRecepientToEmailSendStatus": {
					"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
					"property": BusinessRuleModule.enums.Property.ENABLED,
					"conditions": [
						{
							"leftExpression": {
								"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
								"attribute": "EmailSendStatus"
							},
							"comparisonType": BPMSoft.ComparisonType.NOT_EQUAL,
							"rightExpression": {
								"type": BusinessRuleModule.enums.ValueType.CONSTANT,
								"value": ConfigurationConstants.Activity.EmailSendStatus.Sended
							}
						}
					]
				}
			},
			"Title": {
				"BindParameterEnabledTitleToEmailSendStatus": {
					"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
					"property": BusinessRuleModule.enums.Property.ENABLED,
					"conditions": [
						{
							"leftExpression": {
								"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
								"attribute": "EmailSendStatus"
							},
							"comparisonType": BPMSoft.ComparisonType.NOT_EQUAL,
							"rightExpression": {
								"type": BusinessRuleModule.enums.ValueType.CONSTANT,
								"value": ConfigurationConstants.Activity.EmailSendStatus.Sended
							}
						}
					]
				}
			},
			"Body": {
				"BindParameterEnabledBodyToEmailSendStatus": {
					"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
					"property": BusinessRuleModule.enums.Property.ENABLED,
					"conditions": [
						{
							"leftExpression": {
								"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
								"attribute": "EmailSendStatus"
							},
							"comparisonType": BPMSoft.ComparisonType.NOT_EQUAL,
							"rightExpression": {
								"type": BusinessRuleModule.enums.ValueType.CONSTANT,
								"value": ConfigurationConstants.Activity.EmailSendStatus.Sended
							}
						}
					]
				}
			},
			"Owner": {
				"BindParameterEnabledOwnerToEmailSendStatus": {
					"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
					"property": BusinessRuleModule.enums.Property.ENABLED,
					"conditions": [
						{
							"leftExpression": {
								"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
								"attribute": "EmailSendStatus"
							},
							"comparisonType": BPMSoft.ComparisonType.NOT_EQUAL,
							"rightExpression": {
								"type": BusinessRuleModule.enums.ValueType.CONSTANT,
								"value": ConfigurationConstants.Activity.EmailSendStatus.Sended
							}
						}
					]
				}
			},
			"Status": {
				"BindParameterEnabledStatusToEmailSendStatus": {
					"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
					"property": BusinessRuleModule.enums.Property.ENABLED,
					"conditions": [
						{
							"leftExpression": {
								"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
								"attribute": "EmailSendStatus"
							},
							"comparisonType": BPMSoft.ComparisonType.NOT_EQUAL,
							"rightExpression": {
								"type": BusinessRuleModule.enums.ValueType.CONSTANT,
								"value": ConfigurationConstants.Activity.EmailSendStatus.Sended
							}
						}
					]
				}
			},
			"Contact": {
				"FiltrationContactByAccount": {
					"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
					"autocomplete": true,
					"autoClean": true,
					"baseAttributePatch": "Account",
					"comparisonType": BPMSoft.ComparisonType.EQUAL,
					"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
					"attribute": "Account"
				}
			},
			"ActivityConnection": {
				"FiltrationActivityByActivityType": {
					"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
					"baseAttributePatch": "Type",
					"comparisonType": BPMSoft.ComparisonType.NOT_EQUAL,
					"type": BusinessRuleModule.enums.ValueType.CONSTANT,
					"value": ConfigurationConstants.Activity.Type.Email
				}
			}
		}
	};
});
