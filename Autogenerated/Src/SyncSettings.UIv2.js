define("SyncSettings", ["ModalBox", "ExchangeNUIConstants", "RightUtilities", "ConfigurationConstants",
		"SyncSettingsResources", "css!SyncSettingsTabModule", "CredentialsSyncSettingsMixin"],
		function(ModalBox, ExchangeNUIConstants, RightUtilities, ConfigurationConstants) {
	return {
		entitySchemaName: "MailboxSyncSettings",
		mixins: {
			/**
			 * @class CasePageUtilitiesV2 implements quick save cards in one click.
			 */
			CredentialsSyncSettingsMixin: "BPMSoft.CredentialsSyncSettingsMixin"
		},
		attributes: {
			/**
			 * Settings page tabs collection.
			 */
			"TabsCollection": {
				dataValueType: this.BPMSoft.DataValueType.COLLECTION
			},
			/**
			 * Saved tabs collection.
			 */
			"SavedTabsCollection": {
				dataValueType: this.BPMSoft.DataValueType.COLLECTION
			},
			/**
			 * Active tab name.
			 */
			"ActiveTabName": {
				dataValueType: this.BPMSoft.DataValueType.TEXT
			},
			/**
			 * Page ready state flag.
			 */
			"IsReady": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				value: false,
				dependencies: [
					{
						columns: ["RecordId"],
						methodName: "onRecordIdChanged"
					}
				]
			},
			/**
			 * Flag is page saved.
			 */
			"IsSaved": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				value: true
			},
			/**
			 * Auto synchronization contacts is enabled.
			 */
			"ExchangeAutoSynchronizationContacts": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				value: false
			},
			/**
			 * Auto synchronization activities is enabled.
			 */
			"ExchangeAutoSynchronizationActivity": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				value: false
			},
			/**
			 * MailboxSyncSettings record id.
			 */
			"RecordId": {
				dataValueType: this.BPMSoft.DataValueType.GUID
			}
		},
		messages: {
			/**
			 * @message GetMailboxSyncSettingValues
			 * Returns column values of setting.
			 */
			"GetMailboxSyncSettingValues": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			/**
			 * @message TabSaved
			 * Message fires when tab saved.
			 */
			"TabSaved": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			/**
			 * @message TabInitialized
			 * Message fires when tab initialized.
			 */
			"TabInitialized": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			/**
			 * @message GetHistoryState
			 * Returns current history state.
			 */
			"GetHistoryState": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message PushHistoryState
			 * Modifies history state.
			 */
			"PushHistoryState": {
				mode: this.BPMSoft.MessageMode.BROADCAST,
				direction: this.BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message BackHistoryState
			 * Changes current history state to the previous state.
			 */
			"BackHistoryState": {
				"mode": BPMSoft.MessageMode.BROADCAST,
				"direction": BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message SaveSettings
			 * Invoke save in tabs.
			 */
			"SaveSettings": {
				"mode": BPMSoft.MessageMode.BROADCAST,
				"direction": BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message ReloadSettings
			 * Reloads settings parameters.
			 */
			"ReloadSettings": {
				"mode": BPMSoft.MessageMode.PTP,
				"direction": BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message ReloadTabs
			 * Invoke tabs reload.
			 */
			"ReloadTabs": {
				"mode": BPMSoft.MessageMode.BROADCAST,
				"direction": BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message ChangeHeaderCaption
			 * Sets header parameters.
			 */
			"ChangeHeaderCaption": {
				"mode": BPMSoft.MessageMode.PTP,
				"direction": BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message NeedHeaderCaption
			 * Gets header parameters request.
			 */
			"NeedHeaderCaption": {
				"mode": BPMSoft.MessageMode.BROADCAST,
				"direction": BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message InitDataViews
			 * Sends header parameters on request.
			 */
			"InitDataViews": {
				"mode": BPMSoft.MessageMode.PTP,
				"direction": BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message InitDataViews
			 * Sends the message that the tab is rerendered.
			 */
			"RerenderTab": {
				"mode": BPMSoft.MessageMode.BROADCAST,
				"direction": BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message ShowSaveButton
			 * Shows save button.
			 */
			"ShowSaveButton": {
				"mode": BPMSoft.MessageMode.PTP,
				"direction": BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			/**
			 * @message UpdateSection
			 * Page header click message.
			 */
			"UpdateSection": {
				"mode": BPMSoft.MessageMode.PTP,
				"direction": BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
		methods: {

			//region methods: private

			/**
			 * Sets current sender email address to clipboard.
			 * @private
			 */
			_copyEmailToClipboard: function() {
				let input = document.getElementById("copyInput");
				if (input === null) {
					input = document.createElement("input");
					input.id = "copyInput";
					input.style.position = "absolute";
					input.style.top = "-100px";
					document.body.append(input);
					input = document.getElementById("copyInput");
				}
				input.value = this.get("SenderEmailAddress");
				input.select();
				document.execCommand("copy");
			},

			//endregion

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
			 * @overridden
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this.BPMSoft.chain(
						this.initParameters,
						this.initEntity,
						this.onEntityInitialized,
						this.executeAsyncInitFunctions,
						function() {
							callback.call(scope || this);
						}, this);
				}, this]);
			},

			/**
			 * Executes async init functions.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			executeAsyncInitFunctions: function(callback, scope) {
				this.subscribeSandboxEvents();
				this.initTabs();
				this.initHeader();
				if (callback) {
					callback.call(scope || this);
				}
			},

			/**
			 * Sets initial parameters of mailbox settings.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			initParameters: function(callback, scope) {
				var historyState = this.sandbox.publish("GetHistoryState");
				var state = historyState.state || {};
				this.setParameters(state);
				this.initSaveTabsCollection();
				callback.call(scope || this);
			},

			/**
			 * Sets settings parameters from config.
			 * @param {Object} config Parameters.
			 * @param {Guid} config.recordId Settings record id.
			 * @param {String} [config.activeTabName] Tab to open.
			 */
			setParameters: function(config) {
				var recordId = config.recordId;
				var activeTabName = config.activeTabName;
				this.set("ActiveTabName", activeTabName);
				this.set("RecordId", recordId);
			},

			/**
			 * Init SaveTabsCollection for tabs.
			 * @protected
			 */
			initSaveTabsCollection: function() {
				var saveTabsCollection = this.Ext.create("BPMSoft.Collection");
				this.set("SavedTabsCollection", saveTabsCollection);
			},

			/**
			 * Sets default values for tab when it initialized.
			 * @protected
			 * @param {String} tabName Loaded tab name.
			 */
			setSaveTabCollectionItemDefaults: function(tabName) {
				var saveTabsCollection = this.get("SavedTabsCollection");
				if (!saveTabsCollection.contains(tabName)) {
					var newTab = this.Ext.create("BPMSoft.BaseViewModel", {
						values: {
							"isSaved": false
						}
					});
					saveTabsCollection.add(tabName, newTab);
				}
			},

			/**
			 * Set default values for SaveTabsCollection.
			 * @protected
			 * @param {Object} saveTabsCollection Tabs saved flags.
			 */
			setSaveTabsCollectionDefaults: function(saveTabsCollection) {
				saveTabsCollection.each(function(item) {
					item.set("isSaved", false);
				});
			},

			/**
			 * Sets ready flag false on record id change.
			 * @protected
			 */
			onRecordIdChanged: function() {
				this.set("IsReady", false);
			},

			/**
			 * Initializes schema entity.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			initEntity: function(callback, scope) {
				var recordId = this.get("RecordId");
				var esq = this.getSettingsEsq();
				this.setEsqFilters(esq);
				esq.getEntity(recordId, function(result) {
					this.onEntityResponse(result);
					callback.call(scope || this);
				}, this);
			},

			/**
			 * Generates entity schema query for mailbox sync settings.
			 * @return {BPMSoft.EntitySchemaQuery} Entity schema query.
			 */
			getSettingsEsq: function() {
				var settingsEsq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "MailboxSyncSettings"
				});
				this.BPMSoft.each(this.columns, function(column, columnName) {
					if (column.type === this.BPMSoft.ViewModelColumnType.ENTITY_COLUMN &&
							columnName !== "OAuthTokenStorage" && !settingsEsq.columns.contains(columnName)) {
						settingsEsq.addColumn(columnName);
					}
				}, this);
				settingsEsq.addColumn("MailServer.Type.Id", "ServerTypeId");
				settingsEsq.addColumn("MailServer.AllowEmailDownloading", "AllowEmailDownloading");
				settingsEsq.addColumn("MailServer.AllowEmailSending", "AllowEmailSending");
				settingsEsq.addColumn("MailServer.SMTPServerAddress", "SMTPServerAddress");
				settingsEsq.addColumn("MailServer.UseLogin", "UseLogin");
				settingsEsq.addColumn("MailServer.UseUserNameAsLogin", "UseUserNameAsLogin");
				settingsEsq.addColumn("MailServer.UseEmailAddressAsLogin", "UseEmailAddressAsLogin");
				settingsEsq.addColumn("MailServer.OAuthApplication", "OAuthApplication");
				return settingsEsq;
			},

			/**
			 * Sets entity schema filters.
			 * @param {BPMSoft.EntitySchemaQuery} esq Entity schema query.
			 */
			setEsqFilters: function(esq) {
				var filterSysAdminUnit = esq.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL, "SysAdminUnit", this.BPMSoft.SysValue.CURRENT_USER.value);
				esq.filters.add("filterSysAdminUnit", filterSysAdminUnit);
			},

			/**
			 * Sets result data in view model columns.
			 * @param {Object} response Server data response.
			 */
			onEntityResponse: function(response) {
				if (response.success) {
					var entity = response.entity;
					this.BPMSoft.each(entity.columns, function(column, columnName) {
						this.set(columnName, entity.get(columnName));
					}, this);
				}
			},

			/**
			 * Sets ready flag after entity initialized.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			onEntityInitialized: function(callback, scope) {
				this.set("IsReady", true);
				if (callback) {
					callback.call(scope || this);
				}
			},

			/**
			 * Reloads settings state.
			 * @param {Object} config Parameters.
			 * @param {Guid} config.recordId Settings record id.
			 * @param {String} [config.activeTabName] Tab to open.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			reloadSettings: function(config, callback, scope) {
				this.setParameters(config);
				this.BPMSoft.chain(
					this.initEntity,
					this.onEntityInitialized,
					this.executeAsyncInitFunctions,
					function() {
						this.sandbox.publish("ReloadTabs");
						this.set("IsSaved", true);
						if (callback) {
							callback.call(scope || this);
						}
					}, this);
			},

			/**
			 * Subscribes for sandbox messages.
			 */
			subscribeSandboxEvents: function() {
				this.sandbox.subscribe("GetMailboxSyncSettingValues", this.onGetMailboxSyncSettingValues, this);
				this.sandbox.subscribe("ReloadSettings", this.reloadSettings, this);
				this.sandbox.subscribe("NeedHeaderCaption", this.sendHeaderConfig, this);
				this.sandbox.subscribe("TabSaved", this.setTabSaved, this);
				this.sandbox.subscribe("TabInitialized", this.setSaveTabCollectionItemDefaults, this);
				this.sandbox.subscribe("ShowSaveButton", this.showSaveButton, this);
				this.sandbox.subscribe("UpdateSection", this._copyEmailToClipboard, this,
					[this.sandbox.id + "_UpdateSection"]);
			},

			/**
			 * Set values in SavedTabsCollection.
			 * @protected
			 * @param {String} tabconfig Saved tab value config.
			 */
			setTabSaved: function(tabconfig) {
				var tabSavedCollection = this.get("SavedTabsCollection");
				var tab = tabSavedCollection.get(tabconfig.tabName);
				this.BPMSoft.each(tabconfig.values, function(value, itemName) {
					tab.set(itemName, value);
				}, this);
				if (this.IsAllTabsSaved(tabSavedCollection)) {
					this.updateSyncSettingsParameters(tabSavedCollection);
					this.createOrDeleteSyncJob();
					this.setSaveTabsCollectionDefaults(tabSavedCollection);
					this.set("IsSaved", true);
					this.set("IsReady", true);
				}
			},

			/**
			 * Updates sync settings parameters.
			 * @protected
			 */
			updateSyncSettingsParameters: function(collection) {
				var emailSettingsTab = collection.find("EmailSettingsTab");
				var setTabAtributes = function(settingsTabMap, settingsTab) {
					this.BPMSoft.each(settingsTabMap, function(valueName, attributeName) {
						this.set(attributeName, settingsTab.get(valueName));
					}, this);
				};
				if (!this.Ext.isEmpty(emailSettingsTab)) {
					var emailSettingsTabMap = {
						"EnableMailSynhronization": "enableMailSynhronization",
						"AutomaticallyAddNewEmails": "automaticallyAddNewEmails",
						"SendEmailsViaThisAccount": "sendEmailsViaThisAccount"
					};
					setTabAtributes.call(this, emailSettingsTabMap, emailSettingsTab);
				}
				var activitySyncSettingsTab = collection.find("ActivitySyncSettingsTab");
				if (!this.Ext.isEmpty(activitySyncSettingsTab)) {
					var activitySyncSettingsTabMap = {
						"ExchangeAutoSynchronizationActivity": "exchangeAutoSynchronizationActivity",
						"ImportAppointments": "importAppointments",
						"ImportTasks": "importTasks",
						"ExportActivities": "exportActivities"
					};
					setTabAtributes.call(this, activitySyncSettingsTabMap, activitySyncSettingsTab);
				}
				var contactSettingsTab = collection.find("ContactSettingsTab");
				if (!this.Ext.isEmpty(contactSettingsTab)) {
					var contactSettingsTabMap = {
						"ExchangeAutoSynchronizationContacts": "exchangeAutoSynchronizationContacts",
						"ImportContacts": "importContacts",
						"ExportContacts": "exportContacts"
					};
					setTabAtributes.call(this, contactSettingsTabMap, contactSettingsTab);
				}
			},

			/**
			 * Creates auto synchronization jobs.
			 * @protected
			 */
			createOrDeleteSyncJob: function() {
				var interval = parseInt(this.get("EmailsCyclicallyAddingInterval"), 10);
				var data = {
					create: this.get("EnableMailSynhronization") && this.get("AutomaticallyAddNewEmails"),
					mailboxName: this.get("MailboxName"),
					interval: interval,
					serverId: this.get("MailServer").value,
					senderEmailAddress: this.get("SenderEmailAddress"),
					createContactJob: this.get("ExchangeAutoSynchronizationContacts") && (this.get("ImportContacts") ||
						this.get("ExportContacts")),
					createActivityJob: this.get("ExchangeAutoSynchronizationActivity") &&
						(this.get("ImportAppointments") || this.get("ImportTasks") || this.get("ExportActivities")
						|| this.getIsFeatureEnabled("NewMeetingIntegration")),
					contactActivityInterval: this.get("ContactSyncInterval"),
					activityInterval: this.getIsFeatureEnabled("NewMeetingIntegration") ? 1 : this.get("ExchangeSyncInterval")
				};
				this.callService({
					serviceName: "MailboxSettingsService",
					methodName: "CreateDeleteSyncJob",
					data: data
				}, function(response) {
					if (!this.Ext.isEmpty(response.CreateDeleteSyncJobResult)) {
						this.showInformationDialog(response.CreateDeleteSyncJobResult);
					} else {
						this.checkContactEmail(this.checkIsProviderSMTPAddressSet, this);
					}
				});
			},

			/**
			 * Checks contact email.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback scope.
			 * @protected
			 */
			checkContactEmail: function(callback, scope) {
				var userEmailAddress = this.get("SenderEmailAddress");
				if (userEmailAddress.indexOf("@") === -1) {
					callback.call(scope || this);
				} else {
					this.checkEditContactRights(function(result) {
						if (!this.Ext.isEmpty(result)) {
							callback.call(scope || this);
							return;
						}
						var select = this.Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: "ContactCommunication"
						});
						select.addColumn("Id");
						this.contactEmailFilters(select, userEmailAddress);
						select.getEntityCollection(function(response) {
							var collection = response.success ? response.collection : null;
							if (collection && collection.getCount() === 0) {
								this.addEmailToContactCommunications(callback, scope);
							} else {
								callback.call(scope || this);
							}
						}, this);
					}, this);
				}
			},

			/**
			 * Adds filters for contact communication select.
			 * @param {BPMSoft.EntitySchemaQuery} select Select contact communication query.
			 * @param {String} userEmailAddress Entered email address.
			 */
			contactEmailFilters: function(select, userEmailAddress) {
				select.filters.add("CommunicationType", BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "CommunicationType",
					ConfigurationConstants.CommunicationType.Email));
				select.filters.add("Number", BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "Number", userEmailAddress));
				select.filters.add("Contact", BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "Contact",
					BPMSoft.SysValue.CURRENT_USER_CONTACT.value));
			},

			/**
			 * Checks if provider SMTP adress set. Show message if provider SMTP adress is not exist.
			 * @protected
			 */
			checkIsProviderSMTPAddressSet: function() {
				var exchangeType = ExchangeNUIConstants.MailServer.Type.Exchange;
				var serverType = this.get("ServerTypeId");
				if (this.get("SendEmailsViaThisAccount") && (serverType !== exchangeType)) {
					this.getIsProviderSMTPAddressSet();
				}
			},

			/**
			 * Gets flag if provider SMTP adress set, show message if this flag is not true.
			 * @protected
			 */
			getIsProviderSMTPAddressSet: function() {
				var mailServer = this.get("MailServer");
				var mailServerId = mailServer ? mailServer.value : null;
				if (this.Ext.isEmpty(mailServerId) || this.Ext.isEmpty(this.get("SMTPServerAddress"))) {
					this.showInformationDialog("Resources.Strings.SMTPSettingsNotSetMessage");
				}
			},

			/**
			 * Checks if current user can edit contact.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback scope.
			 * @protected
			 */
			checkEditContactRights: function(callback, scope) {
				RightUtilities.checkCanEdit({
					schemaName: "Contact",
					primaryColumnValue: BPMSoft.SysValue.CURRENT_USER_CONTACT.value,
					isNew: false
				}, function(result) {
					callback.call(scope, result);
				}, this);
			},

			/**
			 * Adds email to contact communication.
			 * @param {Function} callback Callback function.
			 * @protected
			 */
			addEmailToContactCommunications: function(callback, scope) {
				BPMSoft.utils.showConfirmation(this.get("Resources.Strings.AddToCommunicationDetail"),
					function(returnCode) {
						if (returnCode === BPMSoft.MessageBoxButtons.YES.returnCode) {
							var insert = this.Ext.create("BPMSoft.InsertQuery", {
								rootSchemaName: "ContactCommunication"
							});
							var id = this.BPMSoft.utils.generateGUID();
							this.contactCommunicationInsertParameters(insert, id);
							insert.execute(callback, scope || this);
						} else {
							callback.call(scope || this);
						}
					}, ["yes", "no"], this);
			},

			/**
			 * Sets new contact communication parameters.
			 * @param {BPMSoft.InsertQuery} insert Contact communication insert query.
			 * @param {Guid} id New contact communication id.
			 */
			contactCommunicationInsertParameters: function(insert, id) {
				insert.setParameterValue("Id", id, BPMSoft.DataValueType.GUID);
				insert.setParameterValue("CommunicationType",
					ConfigurationConstants.CommunicationType.Email,
					BPMSoft.DataValueType.GUID);
				insert.setParameterValue("Contact",
					BPMSoft.SysValue.CURRENT_USER_CONTACT.value,
					BPMSoft.DataValueType.GUID);
				insert.setParameterValue("Number", this.get("SenderEmailAddress"),
					BPMSoft.DataValueType.TEXT);
			},

			/**
			 * Check if all tabs was saved.
			 * @protected
			 * @return {Object} Flag if all tabs was saved.
			 */
			IsAllTabsSaved: function(saveTabsCollection) {
				var filteredSaveTabsCollection = saveTabsCollection.filterByFn(function(item) {
					return !item.get("isSaved");
				}, this);
				return filteredSaveTabsCollection.isEmpty();
			},

			/**
			 * Checks is password change allowed for current mailbox.
			 * @protected
			 * @return {Boolean} True if password change allowed, false otherwise.
			 */
			getChangePasswordAllowed: function() {
				return this.isEmpty(this.$OAuthApplication);
			},

			/**
			 * Sends header init message.
			 */
			sendHeaderConfig: function() {
				var headerConfig = this.getHeaderConfig();
				this.sandbox.publish("InitDataViews", headerConfig, this);
			},

			/**
			 * Returns header config.
			 * @return {Object} Header config.
			 */
			getHeaderConfig: function() {
				var headerCaptionTpl = this.get("Resources.Strings.HeaderCaptionTpl");
				var email = this.get("SenderEmailAddress");
				return {
					"isMainMenu": false,
					"caption": this.Ext.String.format(headerCaptionTpl, email),
					"dataViews": this.Ext.create("BPMSoft.Collection"),
					"moduleName": this.sandbox.id
				};
			},

			/**
			 * Initializes page header.
			 */
			initHeader: function() {
				var headerConfig = this.getHeaderConfig();
				this.sandbox.publish("ChangeHeaderCaption", headerConfig);
			},

			/**
			 * Returns column values.
			 * @param {Object} config Values request config.
			 * @param {Array} [config.columns] Requested columns.
			 * @param {Boolean} [config.all] Request all columns flag.
			 */
			onGetMailboxSyncSettingValues: function(config) {
				var columns = config.all ? this.entitySchema.columns : config.columns;
				var result = {};
				this.BPMSoft.each(columns, function(column, columnName) {
					columnName = this.Ext.isObject(column) ? columnName : column;
					var value = this.get(columnName);
					result[columnName] = this.BPMSoft.deepClone(value);
				}, this);
				return result;
			},

			/**
			 * Initializes start tabs parameters.
			 */
			initTabs: function() {
				var activeTabName = this.get("ActiveTabName") || "EmailSettingsTab";
				this.setActiveTab(activeTabName);
				var tabsCollection = this.get("TabsCollection");
				tabsCollection.fireEvent("dataLoaded", tabsCollection, tabsCollection.getItems());
			},

			/**
			 * Hides calendar and contact tabs for imap settings.
			 * @protected
			 * @param {Object} tabConfig Tab config.
			 */
			onTabRender: function(tabConfig) {
				var html = tabConfig.html;
				var tabName = tabConfig.tab.get("Name");
				var exchangeType = ExchangeNUIConstants.MailServer.Type.Exchange;
				var serverType = this.get("ServerTypeId");
				if ((serverType !== exchangeType) && (tabName !== "EmailSettingsTab")) {
					tabConfig.html = html.replace("style=\"\"", "style=\"display: none;\"");
				}
			},

			/**
			 * Active tab change handler.
			 * @param {BPMSoft.BaseViewModel} activeTab Current active tab view model.
			 */
			onActiveTabChange: function(activeTab) {
				var activeTabName = activeTab.get("Name");
				this.setActiveTab(activeTabName);
			},

			/**
			 * Sets tabs containers visibility to false.
			 */
			closeTabs: function() {
				var tabsCollection = this.get("TabsCollection");
				tabsCollection.eachKey(function(tabName, tab) {
					var tabContainerVisibleBinding = tab.get("Name");
					this.set(tabContainerVisibleBinding, false);
				}, this);
			},

			/**
			 * Sets active tab.
			 * @param {String} activeTabName Tab name to set active.
			 */
			setActiveTab: function(activeTabName) {
				this.closeTabs();
				this.set("ActiveTabName", activeTabName);
				this.set(activeTabName, true);
			},

			/**
			 * Save button handler.
			 * @protected
			 */
			onSave: function() {
				this.set("IsReady", false);
				this.sandbox.publish("SaveSettings");
			},

			/**
			 * Cancel button handler.
			 */
			onCancel: function() {
				this.sandbox.publish("BackHistoryState");
			},

			/**
			 * Generates data item marker for page container.
			 * @return {String} Data item marker for page container.
			 */
			getReadyMarkerValue: function() {
				var email = this.get("SenderEmailAddress");
				return this.get("IsReady") ? ("SyncSettingsReady " + email) : "Loading";
			},

			/**
			 * Sends rerender message for tab modules.
			 * @protected
			 * @param {Object} config Rerender parameters.
			 */
			afterrerender: function(config) {
				this.sandbox.publish("RerenderTab", config);
			},

			/**
			 * Opens change password popup.
			 * @protected
			 */
			onChangePassword: function() {
				var mailserver = this.$MailServer;
				var mailbox = {
					id: this.$Id,
					senderEmailAddress: this.$SenderEmailAddress,
					mailServerId: mailserver.value,
					mailServerName: mailserver.displayValue,
					userName: this.$UserName,
					useLogin: this.$UseLogin,
					useEmailAddressAsLogin: this.$UseEmailAddressAsLogin,
					useUserNameAsLogin: this.$UseUserNameAsLogin,
					sendEmailsViaThisAccount: this.$SendEmailsViaThisAccount,
					enableMailSynhronization: this.$EnableMailSynhronization
				};
				this.openCredentialsSyncSettingsEdit(mailbox);
			},

			/**
			 * Get inverse value.
			 * @protected
			 * @deprecated Use {@link #BPMSoft.BaseModel.invertBooleanValue}.
			 * @param {Boolean} value Value.
			 * @return {Boolean} Inverse value.
			 */
			inverseValue: function(value) {
				return !value;
			},

			/**
			 * Shows save button.
			 */
			showSaveButton: function() {
				this.set("IsSaved", false);
			}
		},
		diff: [
			{
				"operation": "insert",
				"name": "SyncSettingsContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"markerValue": {"bindTo": "getReadyMarkerValue"},
					"classes": {"wrapClassName": ["sync-settings-page"]}
				}
			},
			{
				"operation": "insert",
				"name": "buttonsMenu",
				"parentName": "SyncSettingsContainer",
				"propertyName": "items",
				"values": {
					"id": "buttonsMenu",
					"selectors": {
						wrapEl: "#buttonsMenu"
					},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["buttons-menu-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "buttonsMenu",
				"propertyName": "items",
				"name": "SaveButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.SaveButtonCaption"},
					"classes": {"textClass": "actions-button-margin-right"},
					"click": {"bindTo": "onSave"},
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
					"markerValue": "SaveButton",
					"visible": {
						"bindTo": "IsSaved",
						"bindConfig": {"converter": "invertBooleanValue"}
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "buttonsMenu",
				"propertyName": "items",
				"name": "CloseButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.CloseButtonCaption"},
					"classes": {"textClass": "actions-button-margin-right"},
					"click": {"bindTo": "onCancel"},
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
					"markerValue": "CloseButton",
					"visible": {bindTo: "IsSaved"}
				}
			},
			{
				"operation": "insert",
				"parentName": "buttonsMenu",
				"propertyName": "items",
				"name": "CancelButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.CancelButtonCaption"},
					"classes": {"textClass": "actions-button-margin-right"},
					"click": {"bindTo": "onCancel"},
					"markerValue": "CancelButton",
					"visible": {
						"bindTo": "IsSaved",
						"bindConfig": {"converter": "invertBooleanValue"}
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "buttonsMenu",
				"propertyName": "items",
				"name": "ChangeEmailSettings",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.ChangeEmailSettings"},
					"classes": {"textClass": "actions-button-margin-right"},
					"click": {"bindTo": "onChangePassword"},
					"markerValue": "ChangePassword",
					"visible": {"bindTo": "getChangePasswordAllowed"}
				}
			},
			{
				"operation": "insert",
				"parentName": "SyncSettingsContainer",
				"name": "TabsPanel",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.TAB_PANEL,
					"activeTabChange": {"bindTo": "onActiveTabChange"},
					"activeTabName": {"bindTo": "ActiveTabName"},
					"tabRender": {"bindTo": "onTabRender"},
					"collection": {"bindTo": "TabsCollection"},
					"isScrollVisible": false,
					"tabs": []
				}
			},
			{
				"operation": "insert",
				"parentName": "TabsPanel",
				"name": "EmailSettingsTab",
				"propertyName": "tabs",
				"values": {
					caption: {"bindTo": "Resources.Strings.EmailSettingsTabCaption"},
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "EmailSettingsTab",
				"name": "EmailSettingsModule",
				"propertyName": "items",
				"values": {
					"moduleId": "SyncSettings_EmailSyncSettingsSchemaModule",
					"itemType": BPMSoft.ViewItemType.MODULE,
					"moduleName": "SyncSettingsTabModule",
					"instanceConfig": {
						"isSchemaConfigInitialized": true,
						"schemaName": "EmailSyncSettings",
						"defaultValues": [{
							name: "TabName",
							value: "EmailSettingsTab"
						}],
						"useHistoryState": false
					},
					"afterrerender": {"bindTo": "afterrerender"}
				}
			}
		]
	};
});
