define("SendTestEmailContentSchema", ["EmailHelperModule", "ServiceHelper", "EmailHelper", "SendTestEmailContentMixin",
	"css!SendTestEmailContentSchemaCSS", "MultipleEmailInput"],
	function(EmailHelperModule, ServiceHelper, EmailHelper) {

		var SendTestEmailConsts = {
			REPLICAUNDERTESTCACHEKEY: "ReplicaUnderTestLastValue"
		};

		return {
			properties: {

				/**
				 * @property {Boolean} Flag, indicates that invalid email has entered.
				 */
				isInvalidEmailEntered: false
			},
			mixins: {
				SendTestEmailContentMixin: "BPMSoft.SendTestEmailContentMixin"
			},
			messages: {
				/**
				 * @message CloseTestEmail
				 * Message will be fired when test email container is closing.
				 */
				"CloseTestEmail": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			attributes: {

				/**
				 * Bulk email.
				 */
				"BulkEmail": {
					dataValueType: this.BPMSoft.DataValueType.LOOKUP,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true
				},

				/**
				 * Selected emails.
				 */
				"EmailAddress": {
					dataValueType: this.BPMSoft.DataValueType.TEXT,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true,
					caption: {
						bindTo: "Resources.Strings.EmailAddressCaption"
					},
					value: ""
				},

				/**
				 * Selected contact.
				 */
				"Contact": {
					dataValueType: this.BPMSoft.DataValueType.LOOKUP,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					referenceSchemaName: "Contact",
					isRequired: true,
					isEnum: true
				},

				/**
				 * Path to contact column in source entity.
				 */
				"ContactColumnPath": {
					dataValueType: this.BPMSoft.DataValueType.TEXT,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Selected source entity.
				 */
				"SourceEntity": {
					dataValueType: this.BPMSoft.DataValueType.LOOKUP,
					referenceSchemaName: "Contact"
				},

				/**
				 * Object name of the recipient source entity.
				 */
				"AudienceSchemaName": {
					dataValueType: this.BPMSoft.DataValueType.TEXT,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Caption of the recipient source entity.
				 */
				"AudienceSchemaCaption": {
					dataValueType: this.BPMSoft.DataValueType.TEXT,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Send test email mode.
				 */
				"SendTestEmailMode": {
					dataValueType: this.BPMSoft.DataValueType.TEXT,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: "AllReplicas"
				},

				/**
				 * Modal box height.
				 */
				"ModalBoxHeight": {
					dataValueType: this.BPMSoft.DataValueType.TEXT,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: "270px"
				},

				/**
				 * Modal box with settings height.
				 */
				"ModalBoxWithSettingsHeight": {
					dataValueType: this.BPMSoft.DataValueType.TEXT,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: "420px"
				},

				/**
				 * Modal box width.
				 */
				"ModalBoxWidth": {
					dataValueType: this.BPMSoft.DataValueType.TEXT,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: "470px"
				},

				/**
				 * Mailing service name.
				 */
				"MailingServiceName": {
					dataValueType: this.BPMSoft.DataValueType.TEXT,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: "MailingService"
				},

				/**
				 * Send test message method name.
				 */
				"SendTestMessageMethodName": {
					dataValueType: this.BPMSoft.DataValueType.TEXT,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: "SendDCTestMessage"
				},

				/**
				 * DCReplica lookup enabled.
				 */
				"IsReplicaUnderTestEnabled": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false
				},

				/**
				 * Selected DCReplica.
				 */
				"ReplicaUnderTest": {
					dataValueType: this.BPMSoft.DataValueType.LOOKUP,
					referenceSchemaName: "DCReplica",
					lookupListConfig: {
						columns: ["Mask"],
						filters:
							function() {
								return this._getDCReplicaFilters();
							}
					}
				},

				/**
				 * Is linked entity can be used as recipient.
				 */
				"UseEntityAsRecipient": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * Flag to indicate that lookup view will be limited.
				 */
				"LimitedView": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"value": false
				}
			},
			methods: {

				//region Methods: Private

				_getSourceEntityConfig: function(bulkEmailId, callback, scope) {
					var e = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "BulkEmail"
					});
					e.addColumn("AudienceSchema.EntityObject", "AudienceSchema");
					e.addColumn("AudienceSchema.ContactColumn", "ContactColumn");
					e.getEntity(bulkEmailId, function(result) {
						callback.call(scope, result.entity);
					}, this);
				},

				_getTestEmailEntity: function(entity, callback, scope) {
					var e = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: this.$AudienceSchemaName
					});
					e.addColumn(this.$ContactColumnPath + ".Id", "ContactId");
					e.addColumn(this.$ContactColumnPath + ".Name", "ContactName");
					this.columns.SourceEntity.referenceSchemaName = this.$AudienceSchemaName;
					if (this.$UseEntityAsRecipient && this.$SourceEntity && !this.$SourceEntity.displayValue) {
						this.$SourceEntity.displayValue = entity.displayValue || entity.Contact.displayValue;
					}
					e.getEntity(entity.value, function(result) {
						callback.call(scope, result.entity);
					}, this);
				},

				_onSourceEntityChange: function(value) {
					if (value) {
						this._getTestEmailEntity(value, function(entity) {
							if (!entity) {
								this.set("Contact", null);
								this.set("SourceEntity", null);
								return;
							}
							this.set("Contact", {
								value: entity.$ContactId,
								displayValue: entity.$ContactName
							});
						}, this);
					}
				},

				_getSourceEntityCaption: function() {
					var captionTemplate = this.get("Resources.Strings.SelectedSourceEntityCaption");
					return Ext.String.format(captionTemplate, this.$AudienceSchemaCaption);
				},

				/**
				 * @inheritDoc BPMSoft.Configuration.BasePageV2#getLookupPageConfig
				 * @override
				 */
				getLookupPageConfig: function(args, columnName) {
					var config = {
						entitySchemaName: this.$AudienceSchemaName || "Contact",
						hideActions: true,
						isColumnSettingsHidden: this.$LimitedView,
						multiSelect: false,
						columnName: columnName,
						columnValue: this.get(columnName),
						searchValue: args.searchValue
					};
					Ext.apply(config, this.getLookupListConfig(columnName));
					return config;
				},

				/**
				 * Gets filter for DCReplica.
				 * @private
				 * @return {BPMSoft.FilterGroup} FilterGroup instance for load predictable lookup column data.
				 */
				_getDCReplicaFilters: function() {
					var filterGroup = new BPMSoft.FilterGroup();
					var bulkEmailId = this.get("BulkEmail");
					var filter = BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
						"DCTemplate.RecordId", bulkEmailId);
					filterGroup.add("RecordId", filter);
					return filterGroup;
				},

				/**
				 * Fetch the first default replica from db.
				 * @private
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Scope for callback function.
				 */
				_fetchSingleReplicaFromDb: function(callback, scope) {
					var esq = this.getLookupQuery(null, "ReplicaUnderTest");
					esq.rowCount = 1;
					esq.getEntityCollection(function(response) {
						var collection = response.collection;
						if (response.success && collection && !collection.isEmpty()) {
							var item = collection.getByIndex(0);
							callback.call(scope, item);
						}
					}, this);
				},

				/**
				 * Initialize the selected replica value.
				 * @private
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Scope for callback function.
				 */
				_initialiseReplicaUnderTestValue: function(callback, scope) {
					var cachedValue = this.BPMSoft.ClientPageSessionCache.getItem(SendTestEmailConsts.REPLICAUNDERTESTCACHEKEY);
					if (cachedValue) {
						callback.call(scope, cachedValue);
						return;
					}
					this._fetchSingleReplicaFromDb(function(entity) {
						var lookupValue = {
							value: entity.$value,
							displayValue: entity.$displayValue,
							Mask: entity.$Mask
						};
						callback.call(scope, lookupValue);
					});
				},

				_onSendCurrentReplicasModeChecked: function() {
					this.$IsReplicaUnderTestEnabled = true;
					this._initialiseReplicaUnderTestValue(function(lookupValue) {
						this.$ReplicaUnderTest = lookupValue;
					}, this);
				},

				_onSendAllReplicasModeChecked: function() {
					this.$IsReplicaUnderTestEnabled = false;
					this.$ReplicaUnderTest = null;
				},

				/**
				 * Handle the change sending mode.
				 * @private
				 * @param {Boolean} value The value of radio button.
				 * @param {String} radioButtonName The name of radio button.
				 */
				_onSendTestEmailModeBlockChanged: function(value, radioButtonName) {
					if (!value) {
						return;
					}
					switch (radioButtonName) {
						case "SelectedReplica":
							this._onSendCurrentReplicasModeChecked();
							break;
						case "AllReplicas":
							this._onSendAllReplicasModeChecked();
							break;
					}
				},

				/**
				 * Cash the last selected value from ReplicaUnderTest lookup.
				 * @private
				 * @param {Object} value Selected value.
				 */
				_onReplicaUnderTestChange: function(value) {
					if (value) {
						this.BPMSoft.ClientPageSessionCache.setItem(SendTestEmailConsts.REPLICAUNDERTESTCACHEKEY, value);
					}
				},

				/**
				 * Returns profile key.
				 * @private
				 * @return {String} key Profile key.
				 */
				_getProfileKey: function(postfix) {
					return "SendTestEmailContentSchema_Fields_" + postfix;
				},

				/**
				 * Saves selected source entity or contact into user profile.
				 * @private
				 */
				_saveSourceEntityToProfile: function(callback, scope) {
					var schemaName = this.$UseEntityAsRecipient ? this.$AudienceSchemaName : "Contact";
					var sourceEntityKey = this._getProfileKey(schemaName);
					var data = this.$UseEntityAsRecipient
						? { sourceEntity: this.$SourceEntity }
						: { contact: this.$Contact };
					BPMSoft.utils.saveUserProfile(sourceEntityKey, data, false, callback, scope);
				},

				/**
				 * Saves email address value into user profile.
				 * @private
				 */
				_saveEmailAddressToProfile: function(callback, scope) {
					var emailKey = this._getProfileKey("EmailAddress");
					var data = {
						emailAddress: this.$EmailAddress
					};
					BPMSoft.utils.saveUserProfile(emailKey, data, false, callback, scope);
				},

				/**
				 * Read source entity or contact data from profile and set them into appropriate properties.
				 * @private
				 */
				_initSourceEntityFromProfile: function() {
					var schemaName = this.$UseEntityAsRecipient ? this.$AudienceSchemaName : "Contact";
					var sourceEntityKey = this._getProfileKey(schemaName);
					BPMSoft.ProfileUtilities.getProfile({
							profileKey: sourceEntityKey
						},
						function(profile) {
							this.$SourceEntity = profile.sourceEntity;
							if (profile.contact) {
								this.$Contact = profile.contact;
							}
						},
						this
					);
				},

				/**
				 * Read and set email address value from user profile.
				 * @private
				 */
				_initEmailAddressFromProfile: function() {
					var sourceEntityKey = this._getProfileKey("EmailAddress");
					BPMSoft.ProfileUtilities.getProfile({
							profileKey: sourceEntityKey
						},
						function(profile) {
							this.$EmailAddress = profile.emailAddress;
						},
						this
					);
				},

				/**
				 * @private
				 */
				_initHotkeys: function() {
					var topEl = Ext.getBody().parent("html");
					topEl.on("keydown", this._onKeyDown, this);
				},

				/**
				 * @private
				 */
				_removeHotkeys: function() {
					var topEl = Ext.getBody().parent("html");
					topEl.un("keydown", this._onKeyDown, this);
				},

				/**
				 * @private
				 */
				_onKeyDown: function(e) {
					var key = e.getKey();
					if (key === e.ESC) {
						e.preventDefault();
						e.stopPropagation();
						this._removeHotkeys();
						this.close();
					}
				},

				//endregion

				//region Methods: Protected

				/**
				 * Gets result of lookup query filter.
				 * @protected
				 * @param {Object} lookupListConfig Lookup config.
				 * @return {BPMSoft.FilterGroup} FilterGroup instance for load predictable lookup column data.
				 */
				getLookupQueryFilters: function(lookupListConfig) {
					if (Ext.isFunction(lookupListConfig.filters)) {
						return lookupListConfig.filters.call(this);
					}
				},

				/**
				 * Returns EntitySchemaQuery instance for load predictable lookup column data.
				 * @protected
				 * @param {String} filterValue Filter for primaryDisplayColumn.
				 * @param {String} columnName ViewModel column name.
				 * @return {BPMSoft.EntitySchemaQuery} EntitySchemaQuery instance for load predictable lookup column data.
				 */
				getLookupQuery: function(filterValue, columnName) {
					var esq = this.callParent(arguments);
					var lookupColumn = this.columns[columnName];
					if (columnName === "SourceEntity") {
						esq.rootSchemaName = this.$AudienceSchemaName;
					}
					var lookupListConfig = lookupColumn.lookupListConfig;
					if (!lookupListConfig) {
						return esq;
					}
					esq.filters = this.getLookupQueryFilters(lookupListConfig);
					return esq;
				},

				/**
				 * Validates email address and returns validation message.
				 * @protected
				 * @param {String} email Current email address value.
				 * @return {Object} Email validation result.
				 */
				checkEmailValidator: function(email) {
					var emailSplitRegexPattern = /[;,\s]\s*/;
					var emails = (email || "").split(emailSplitRegexPattern);
					var result = true;
					var invalidEmail = "";
					var invalidMessage = "";
					var fullInvalidMessage = "";
					this.BPMSoft.each(emails, function(item) {
						result = result && EmailHelperModule.isEmailValid(item);
						if (!result) {
							invalidEmail = item;
						}
						return result;
					}, this);
					if (!result) {
						invalidMessage = this.get("Resources.Strings.IncorrectEmailMessage");
						fullInvalidMessage = this.Ext.String.format(
							this.get("Resources.Strings.FullInvalidEmailAddressMessage"),
							invalidEmail
						);
					}
					return {
						fullInvalidMessage: fullInvalidMessage,
						invalidMessage: invalidMessage
					};
				},

				/**
				 * @inheritdoc BPMSoft.BaseViewModel#getValidationMessage.
				 * @override
				 */
				getValidationMessage: function() {
					var emailValidationInfo = this.checkEmailValidator(this.get("EmailAddress"));
					var fullInvalidMessage = emailValidationInfo && emailValidationInfo.fullInvalidMessage;
					if (!this.Ext.isEmpty(fullInvalidMessage)) {
						return fullInvalidMessage;
					}
					return this.callParent(arguments);
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2ViewModel#setValidationConfig.
				 * @override
				 */
				setValidationConfig: function() {
					this.callParent(arguments);
					this.addColumnValidator("EmailAddress", this.checkEmailValidator);
				},

				/**
				 * Initializes schema name of the source entity.
				 * @protected
				 * @return {String} Identifier of the bulk email.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Scope for callback function.
				 */
				initAudienceSchema: function(bulkEmailId, callback, scope) {
					if (!BPMSoft.Features.getIsEnabled("BulkEmailExtendedMacro")) {
						Ext.callback(callback, scope);
						return;
					}
					BPMSoft.chain(
						function(next) {
							this._getSourceEntityConfig(bulkEmailId, function(config) {
								var entitySchemaUId = config.$AudienceSchema && config.$AudienceSchema.value;
								this.$ContactColumnPath = config.$ContactColumn;
								if (Ext.isEmpty(entitySchemaUId)) {
									Ext.callback(callback, scope);
								} else {
									next(entitySchemaUId);
								}
							}, scope);
						},
						function(next, entitySchemaUId) {
							BPMSoft.EntitySchemaManager.getItemByUId(entitySchemaUId, function(schema) {
								if (schema.name !== "Contact") {
									this.$AudienceSchemaName = schema.name;
									this.$AudienceSchemaCaption = schema.caption;
									this.$UseEntityAsRecipient = true;
								}
								Ext.callback(callback, scope);
							}.bind(this));
						}, scope);
				},

				/**
				 * Initializes default values.
				 * @protected
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Scope for callback function.
				 */
				initDefaultValues: function(callback, scope) {
					if (!Ext.isEmpty(this.$ReplicaMask)) {
						this.set("SendTestEmailMode", "AllReplicas");
					}
					this.initAudienceSchema(this.$BulkEmail, function() {
						if (this.$UseEntityAsRecipient) {
							Ext.callback(callback, scope);
						} else {
							this.BPMSoft.SysSettings.querySysSettingsItem("TestSendingBulkEmailContact",
								function(testSendingBulkEmailContact) {
									this.set("Contact", testSendingBulkEmailContact);
									Ext.callback(callback, scope);
								}, this);
						}
					}, this);
				},

				/**
				 * @inheritdoc BPMSoft.ModalBoxSchemaModule#init.
				 * @override
				 */
				init: function(callback, scope) {
					BPMSoft.ClientPageSessionCache.removeItem(SendTestEmailConsts.REPLICAUNDERTESTCACHEKEY);
					this.callParent([function() {
						this.initDefaultValues(function() {
							if (BPMSoft.Features.getIsEnabled("BulkEmailExtendedMacro")) {
								this._initEmailAddressFromProfile();
								this._initSourceEntityFromProfile();
							}
							callback.call(scope);
						}.bind(this), scope);
					}, this]);
					this._initHotkeys();
				},

				/**
				 * @inheritdoc BPMSoft.BaseModalBoxPage#getHeader.
				 * @override
				 */
				getHeader: function() {
					return this.get("Resources.Strings.SendTestEmailContentModalBoxHeader");
				},

				close: function() {
					this.sandbox.publish("CloseTestEmail", null, [this.sandbox.id]);
				},

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#getGoogleTagManagerData.
				 * @override
				 */
				getGoogleTagManagerData: function() {
					var data = this.callParent(arguments);
					var actionTag = this.$LastActionTag;
					if (!this.Ext.isEmpty(actionTag)) {
						this.Ext.apply(data, {
							action: actionTag
						});
					}
					return data;
				},

				/**
				 * Shows the success of SendTestMessage request.
				 * @protected
				 * @param {Object} response Response object.
				 */
				sendDCTestMessageCallBack: function(response) {
					this.hideModalBoxMask();
					if (!this.Ext.isEmpty(response.message)) {
						this.showInformationDialog(response.message);
					} else if (response.sentReplicasCount !== response.replicasCount) {
						var message = this.Ext.String.format(
							this.get("Resources.Strings.SendDCTestMessageSuccessMessage"),
							response.sentReplicasCount, response.replicasCount);
						this.showInformationDialog(message);
					} else if (!response.success) {
						this.showInformationDialog(this.get("Resources.Strings.SendTestBulkMessageFailMessage"));
					} else {
						this.showInformationDialog(this.get("Resources.Strings.SendTestBulkMessageSuccessMessage"),
							this.close);
					}
				},

				/**
				 * Returns data for SendDCTestMessage request.
				 * @protected
				 * @return {Object} Data for SendDCTestMessage request.
				 */
				getSendDCTestMessageDataConfig: function() {
					var replicaMasksParam = null;
					if (this.$SendTestEmailMode === "SelectedReplica") {
						replicaMasksParam = [];
						replicaMasksParam.push(this.$ReplicaUnderTest.Mask);
					}
					return {
						data: {
							bulkEmailId: this.$BulkEmail,
							contactId: this.$Contact.value,
							linkedEntityId: this.$SourceEntity && this.$SourceEntity.value,
							emailRecipients: this.$EmailAddress,
							replicaMasks: replicaMasksParam
						}
					};
				},

				/**
				 * Returns data for SendDCTestMessage request.
				 * @protected
				 * @return {Object} Data for SendDCTestMessage request.
				 */
				getSendDCTestMessageConfig: function() {
					var dataConfig = this.getSendDCTestMessageDataConfig();
					return {
							serviceName: this.$MailingServiceName,
							methodName: this.$SendTestMessageMethodName,
							callback: this.sendDCTestMessageCallBack,
							data: dataConfig,
							scope: this,
							timeout: 300000
					};
				},

				/**
				 * Sends dynamic content test message.
				 * @protected
				 */
				sendDCTestMessage: function() {
					var config = this.getSendDCTestMessageConfig();
					ServiceHelper.callService(config);
				},

				//endregion

				//region Methods: Public

				/**
				 * Send button click handler.
				 * @public
				 */
				onSendClick: function() {
					this.$LastActionTag = "Send";
					this.sendGoogleTagManagerData();
					this.send();
				},

				/**
				 * Returns SendAllTemplates radio button caption.
				 * @public
				 * @return {String} Radio button caption.
				 */
				getSendAllTemplatesCaption: function() {
					return this.Ext.String.format(this.get("Resources.Strings.SendAllTemplatesCaption"),
						this.get("ReplicaCount"));
				},

				/**
				 * Returns SendTestEmailModeBlock container visibility.
				 * @public
				 * @return {Boolean} SendTestEmailModeBlock container visibility.
				 */
				isSendTestEmailModeBlockVisible: function() {
					return this.$ReplicaCount > 1 && !this.Ext.isEmpty(this.$ReplicaMask);
				},

				/**
				 * Sends test email if validated successfully.
				 * @public
				 */
				send: function() {
					if (!this.validate()) {
						var message = this.getValidationMessage();
						this.showInformationDialog(message, null, null);
						return;
					}
					BPMSoft.chain(
						this._saveEmailAddressToProfile,
						this._saveSourceEntityToProfile,
						this.validateBulkEmail,
						this.sendDCTestMessage,
						this
					);
				},

				/**
				 * Split string by separators.
				 * @protected
				 * @param rawString
				 */
				splitString: function(rawString) {
					const itemsArray = rawString.toLowerCase().split(/[ ,;]+/g);
					return Ext.Array.filter(itemsArray, function(item) {
						if (!Ext.isEmpty(item)) {
							return item;
						}
					}).sort();
				},

				/**
				 * Adds isValid marker for emails using EmailHelper.
				 * @protected
				 * @param {Array} inputArray Array of emails.
				 */
				mapArrayByValidationMarker: function(inputArray) {
					return inputArray.map(function(item) {
						return {
							itemId: BPMSoft.generateGUID(),
							isValid: EmailHelper.isEmailAddress(item),
							value: item
						};
					}, this);
				},

				/**
				 * Handler for "handleValue" event in EmailInput control.
				 * @protected
				 * @param {Object} config Config object from control
				 * @param {String} config.rawString String, that was entered in control.
				 */
				onHandleValue: function(config) {
					if (config && config.rawString) {
						const itemsArray = this.splitString(config.rawString);
						config.itemsArray = itemsArray;
						config.proccededString = itemsArray.join(",");
					}
				},

				/**
				 * Handler for "validateItems" event in EmailInput control.
				 * @protected
				 * @param {Object} config Config object from control
				 * @param {String} config.rawString String, that was entered in control.
				 */
				onValidateItems: function(config) {
					const itemsArray = this.splitString(config.rawString);
					const itemsWithValidationMarker = this.mapArrayByValidationMarker(itemsArray);
					config.items = itemsWithValidationMarker;
				},

				/**
				 * Handler for "renderedItemsCollectionChanged" event in EmailInput control.
				 * @protected
				 * @param renderedItemsCollection {BPMSoft.Collection} Collection of rendered items.
				 */
				onRenderedItemsCollectionChanged: function(renderedItemsCollection) {
					const invalidEmailEntered = renderedItemsCollection.any(function(item) {
						return !item.isValid;
					}, this);
					this.isInvalidEmailEntered = invalidEmailEntered;
				}

				//endregion
			},
			diff: /**SCHEMA_DIFF*/ [{
					"operation": "insert",
					"name": "TestBulkEmailContainer",
					"parentName": "TestEmail",
					"propertyName": "items",
					"values": {
						"id": "testBulkEmailContainer",
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "MultipleEmailAddressContainer",
					"parentName": "TestBulkEmailContainer",
					"propertyName": "items",
					"values": {
						"id": "multipleEmailAddressContainer",
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"wrapClass": ["control-width-15", "vertical-field-label"]
					}
				},
				{
					"operation": "insert",
					"name": "MultipleEmailAddressCaptionWrap",
					"parentName": "MultipleEmailAddressContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"wrapClass": ["label-wrap"]
					}
				},
				{
					"operation": "insert",
					"name": "MultipleEmailAddressCaption",
					"parentName": "MultipleEmailAddressCaptionWrap",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.TIP_LABEL,
						"caption": {
							"bindTo": "Resources.Strings.EmailsFieldCaption"
						},
						"classes": {
							"wrapClass": ["tip-label-wrap"],
							"labelClass": ["t-label-is-required"]
						},
						"tip": {
							"content": {
								"bindTo": "Resources.Strings.EmailAddressHint"
							},
							"displayMode": BPMSoft.controls.TipEnums.displayMode.WIDE
						}
					}
				},
				{
					"operation": "insert",
					"name": "MultipleEmailAddress",
					"parentName": "MultipleEmailAddressContainer",
					"propertyName": "items",
					"values": {
						"generator": function() {
							return {
								"id": "emailInput",
								"className": "BPMSoft.MultipleEmailInput",
								"classes": {
									"wrapClass": ["vertical-field-label"],
									"inputWrapClass": ["portal-user-invitation-emails-input"]
								},
								"handleValue": {"bindTo": "onHandleValue"},
								"validateItems": {"bindTo": "onValidateItems"},
								"renderedItemsCollectionChanged": {"bindTo": "onRenderedItemsCollectionChanged"},
								"value": {"bindTo": "EmailAddress"},
								"markerValue": "EmailAddress"
							};
						}
					}
				},
				{
					"operation": "insert",
					"name": "SendTestEmailModeContainer",
					"parentName": "TestBulkEmailContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"visible": {
							"bindTo": "isSendTestEmailModeBlockVisible"
						}
					}
				},
				{
					"operation": "insert",
					"name": "SendTestEmailModeBlockLabel",
					"parentName": "SendTestEmailModeContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"className": "BPMSoft.Label",
						"caption": {
							"bindTo": "Resources.Strings.SendTestEmailModeBlockCaption"
						},
						"classes": {
							"labelClass": ["template-settings-block-label"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "SendTestEmailModeContainer",
					"name": "SendTestEmailModeBlock",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.RADIO_GROUP,
						"value": {
							"bindTo": "SendTestEmailMode"
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "SendTestEmailModeBlock",
					"propertyName": "items",
					"name": "SendAllTemplates",
					"values": {
						"caption": {
							"bindTo": "getSendAllTemplatesCaption"
						},
						"value": "AllReplicas",
						"controlConfig": {
							"checkedchanged": {"bindTo": "_onSendTestEmailModeBlockChanged"}
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "SendTestEmailModeBlock",
					"propertyName": "items",
					"name": "SelectedReplica",
					"values": {
						"caption": {
							"bindTo": "Resources.Strings.SendCurrentTemplateCaption"
						},
						"value": "SelectedReplica",
						"controlConfig": {
							"checkedchanged": {"bindTo": "_onSendTestEmailModeBlockChanged"}
						}
					}
				},
				{
					"operation": "insert",
					"name": "ReplicaUnderTest",
					"parentName": "TestBulkEmailContainer",
					"propertyName": "items",
					"values": {
						"contentType": this.BPMSoft.ContentType.ENUM,
						"enabled": "$IsReplicaUnderTestEnabled",
						"classes": {
							"wrapClassName": "vertical-field-without-label"
						},
						"controlConfig": {
							"change": "$_onReplicaUnderTestChange"
						},
						"labelConfig": {
							"visible": false
						},
						"visible": {
							"bindTo": "isSendTestEmailModeBlockVisible"
						}
					}
				},
				{
					"operation": "insert",
					"name": "SourceEntity",
					"parentName": "TestBulkEmailContainer",
					"propertyName": "items",
					"values": {
						"contentType": this.BPMSoft.ContentType.LOOKUP,
						"caption": {"bindTo": "_getSourceEntityCaption"},
						"visible": "$UseEntityAsRecipient",
						"controlConfig": {
							"change": "$_onSourceEntityChange"
						},
						"showValueAsLink": {
							"bindTo": "LimitedView",
							"bindConfig": {
								"converter": "invertBooleanValue"
							}
						},
						"classes": {
							"wrapClassName": "vertical-field-label"
						}
					}
				},
				{
					"operation": "insert",
					"name": "Contact",
					"parentName": "TestBulkEmailContainer",
					"propertyName": "items",
					"values": {
						"contentType": this.BPMSoft.ContentType.LOOKUP,
						"caption": {
							"bindTo": "Resources.Strings.SelectedContactFieldCaption"
						},
						"showValueAsLink": {
							"bindTo": "LimitedView",
							"bindConfig": {
								"converter": "invertBooleanValue"
							}
						},
						"classes": {
							"wrapClassName": "vertical-field-label"
						},
						"visible": {
							"bindTo": "UseEntityAsRecipient",
							"bindConfig": {
								"converter": "invertBooleanValue"
							}
						},
						"tip": {
							"content": {
								"bindTo": "Resources.Strings.ContactHint"
							},
							"displayMode": this.BPMSoft.controls.TipEnums.displayMode.WIDE
						}
					}
				},
				{
					"operation": "insert",
					"name": "ButtonsContainer",
					"parentName": "TestBulkEmailContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": {
							wrapClassName: ["buttons-container"]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "SendTestEmail",
					"parentName": "ButtonsContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
						"click": {
							"bindTo": "onSendClick"
						},
						"caption": {
							"bindTo": "Resources.Strings.SendTestEmailButtonCaption"
						},
						"classes": {
							"textClass": ["tap-panel-box"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "CancelButton",
					"parentName": "ButtonsContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
						"click": {
							"bindTo": "close"
						},
						"caption": {
							"bindTo": "Resources.Strings.CancelButtonCaption"
						},
						"classes": {
							"textClass": ["tap-panel-box"]
						}
					}
				}

			] /**SCHEMA_DIFF*/
		};
	});


