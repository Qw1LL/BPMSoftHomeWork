define("SyncSettingsMixin", ["SyncSettingsMixinResources", "ModalBox", "ConfigurationConstants", "ServiceHelper"],
	function(Resources, ModalBox, ConfigurationConstants, ServiceHelper) {
	Ext.define("BPMSoft.configuration.mixins.SyncSettingsMixin", {
		alternateClassName: "BPMSoft.SyncSettingsMixin",

		/**
		 * Modal dialog height.
		 * @type {Number}
		 */
		modalHeight: 300,

		/**
		 * Modal dialog width.
		 * @type {Number}
		 */
		modalWidth: 400,

		/**
		 * Meeting service url.
		 * @type {String}
		 */
		meetingServiceName: "MeetingService",

		/**
		 * Submenu items, which provide actions to synchronize.
		 */
		"SynchronizeActivitiesSubmenu": {dataValueType: this.BPMSoft.DataValueType.COLLECTION},

		// region Methods: Private

		/**
		 * Returns batch query for getting settings.
		 * @private
		 * @return {BPMSoft.BatchQuery} Batch query.
		 */
		getSettingsBatchQuery: function() {
			var batchQuery = this.Ext.create("BPMSoft.BatchQuery");
			var googleCommunicationEsq = this.getGoogleCommunicationEsq();
			var syncSettingsEsq = this.getSyncSettingsEsq();
			batchQuery.add(googleCommunicationEsq);
			batchQuery.add(syncSettingsEsq);
			return batchQuery;
		},

		/**
		 * Returns entity schema query for getting google communication.
		 * @private
		 * @return {BPMSoft.EntitySchemaQuery} Entity schema query.
		 */
		getGoogleCommunicationEsq: function() {
			var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: "SocialAccount"
			});
			this.addColumnsToGoogleCommunicationEsq(esq);
			this.addFiltersToGoogleCommunicationEsq(esq);
			return esq;
		},

		/**
		 * Add columns to google communication entity schema query.
		 * @private
		 * @param {BPMSoft.EntitySchemaQuery} esq Entity schema query.
		 */
		addColumnsToGoogleCommunicationEsq: function(esq) {
			esq.addColumn("Login", "SenderEmailAddress");
		},

		/**
		 * Add filters to entity schema query for getting google communication for current user.
		 * @private
		 * @param {BPMSoft.EntitySchemaQuery} esq settings entity schema query.
		 */
		addFiltersToGoogleCommunicationEsq: function(esq) {
			esq.filters.add("typeFilter", this.BPMSoft.createColumnFilterWithParameter(
				this.BPMSoft.ComparisonType.EQUAL, "Type", ConfigurationConstants.CommunicationTypes.Google));
			esq.filters.add("currentUserFilter", this.BPMSoft.createColumnFilterWithParameter(
				this.BPMSoft.ComparisonType.EQUAL, "User", this.BPMSoft.SysValue.CURRENT_USER.value));
		},

		/**
		 * Returns entity schema query for getting sync settings collection.
		 * @private
		 * @return {BPMSoft.EntitySchemaQuery} Entity schema query.
		 */
		getSyncSettingsEsq: function() {
			var schemaName = this.getSyncSettingsSchemaName();
			var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: schemaName
			});
			this.addColumnsToSyncSettings(esq);
			this.addFiltersToSyncSettingsEsq(esq);
			return esq;
		},

		/**
		 * Add filters to entity schema query for getting mailbox sync settings for current user.
		 * @private
		 * @param {BPMSoft.EntitySchemaQuery} esq settings entity schema query.
		 */
		addFiltersToSyncSettingsEsq: function(esq) {
			esq.filters.add("userFilter", this.BPMSoft.createColumnFilterWithParameter(
				this.BPMSoft.ComparisonType.EQUAL, "MailboxSyncSettings.SysAdminUnit",
				this.BPMSoft.SysValue.CURRENT_USER.value));
		},

		/**
		 * Add columns to sync settings entity schema query.
		 * @private
		 * @param {BPMSoft.EntitySchemaQuery} esq Sync settings entity schema query.
		 */
		addColumnsToSyncSettings: function(esq) {
			esq.addColumn("Id");
			esq.addColumn("MailboxSyncSettings");
			esq.addColumn("MailboxSyncSettings.MailServer.Type", "MailServerType");
			esq.addColumn("MailboxSyncSettings.SenderEmailAddress", "SenderEmailAddress");
			esq.addColumn("MailboxSyncSettings.ExchangeAutoSyncActivity", "ExchangeAutoSyncActivity");
		},

		/**
		 * Returns sync settings dialog schema name.
		 * @private
		 * @return {String} Schema name.
		 */
		getDialogSchemaName: function() {
			return this.entitySchemaName + "SyncSettingsEdit";
		},

		/**
		 * Fills the action items in the synchronize submenu.
		 * @private
		 */
		initSynchronizeSubmenuActionItems: function() {
			const collection = this.Ext.create("BPMSoft.BaseViewModelCollection");
			collection.addItem(this.getButtonMenuItem({
				"Caption": {"bindTo": "Resources.Strings.SynchronizeNowCaption"},
				"Click": {"bindTo": "synchronizeNow"}
			}));
			const syncSettings = this.get("SyncSettings");
			const onClickMenuButtonHandler = syncSettings && syncSettings.length >= 1
				? "showActiveCalendarDialog"
				: "showSyncDialog";
			collection.addItem(this.getButtonMenuItem({
				"Caption": {"bindTo": "Resources.Strings.AddNewSynchronizationAccountCaption"},
				"Click": {"bindTo": onClickMenuButtonHandler},
			}));
			this.setExistsSyncSettingsActions(collection);
			this.set("SynchronizeActivitiesSubmenu", collection);
		},

		/**
		 * Add synchronization actions into section action item collection for exists sync settings.
		 * @private
		 * @param {BPMSoft.Collection} actionMenuItems Section action item collection.
		 * @param {Number} position Actions position in section actions list.
		 */
		setExistsSyncSettingsActions: function(actionMenuItems) {
			var settings = this.get("SyncSettings");
			actionMenuItems.addItem(this.getButtonMenuItem({
				"Type": "BPMSoft.MenuSeparator",
				"Caption": ""
			}));
			this.BPMSoft.each(settings, function(item) {
				var settingId = item.MailboxSyncSettings ? item.MailboxSyncSettings.value : null;
				var caption = this.getSetUpExistsSyncSettingsActionCaption(item.SenderEmailAddress);
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Click": {bindTo: "navigateToSyncSettings"},
					"Tag": settingId,
					"Caption": caption
				}));
			}, this);
		},

		/**
		 * Returns action caption for set up exists settings.
		 * @private
		 * @return {String} Action caption.
		 */
		getSetUpExistsSyncSettingsActionCaption: function(email) {
			return this.Ext.String.format(this.get("Resources.Strings.SetUpExistsSyncSettings")
				|| Resources.localizableStrings.SetUpExistsSyncSettings, email);
		},

		/**
		 * Open sync settings page for exchange synchronization.
		 * @private
		 * @param {Guid} mailboxSyncSettingsId Sync settings Id for exchange synchronization.
		 */
		openExchangeSettingsPage: function(mailboxSyncSettingsId) {
			var historyState = this.sandbox.publish("GetHistoryState");
			var prevHash = historyState.hash;
			var tabName = this.getSyncSettingsTabName();
			var newState = {
				recordId: mailboxSyncSettingsId,
				activeTabName: tabName
			};
			var hash = "BaseSchemaModuleV2/SyncSettings";
			if (prevHash && prevHash.historyState === hash) {
				this.sandbox.publish("ReloadSettings", newState);
			} else {
				this.sandbox.publish("PushHistoryState", {
					hash: hash,
					stateObj: newState
				});
			}
		},

		/**
		 * Returns sync settings tab name.
		 * @private
		 * @return {String} Tab name.
		 */
		getSyncSettingsTabName: function() {
			return this.entitySchemaName + "SettingsTab";
		},
		//endregion

		// region Methods: Protected

		/**
		 * Navigate to set up sync settings page after updating sync settings data.
		 * @protected
		 */
		navigateToSyncSettingsWithSyncSettingsUpdate: function() {
			var itemId = this.get("SyncSettingsId");
			this.navigateToSyncSettings(itemId);
			return false;
		},

		/**
		 * Start synchronization with google account.
		 * @protected
		 */
		synchronizeGoogle: this.BPMSoft.emptyFn,

		/**
		 * Start synchronization with exchange account.
		 * @protected
		 */
		synchronizeExchange: this.BPMSoft.emptyFn,

		/**
		 * Returns set sync settings section action caption.
		 * @protected
		 * @return {String} Caption.
		 */
		getSetSyncSettingsCaption: this.BPMSoft.emptyFn,

		/**
		 * Update sync settings and than show tip.
		 * @protected
		 */
		updateSyncSettingsSetAndShowTip: function(itemId) {
			this.getSectionActions();
			this.set("SyncSettingsId", itemId);
			this.set("IsSyncSettingsSetTipVisible", true);
		},

		/**
		 * Update sync settings collection.
		 * @param {Function} callback Callback function call after getting success response.
		 * @param {Object} scope Scope for callback function.
		 * @protected
		 */
		updateSyncSettings: function(callback, scope) {
			const batchQuery = this.getSettingsBatchQuery();
			batchQuery.execute(function(response) {
				if (response && response.success) {
					const googleRows = response.queryResults[0].rows || [];
					const exchangeRows = response.queryResults[1].rows || [];
					const rows = googleRows.concat(exchangeRows);
					this.settingsBatchQueryCallback(rows, callback, scope);
				} else {
					throw new BPMSoft.UnknownException({
						message: this.get("Resources.Strings.ErrorOnGettingSyncSettings")
							|| Resources.localizableStrings.ErrorOnGettingSyncSettings
					});
				}
			}, this);
		},

		/**
		 * Update sync settings callback function.
		 * @param {Array} rows Calendars synchronization accounts.
		 * @param {Function} callback Callback function call after getting success response.
		 * @param {Object} scope Scope for callback function.
		 * @protected
		 */
		settingsBatchQueryCallback: function(rows, callback, scope) {
			this.set("SyncSettings", rows);
			Ext.callback(callback, scope || this);
		},

		/**
		 * Checking if user can change calendar settings.
		 * @param {String} senderEmilAddress Sender email address.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Scope function.
		 */
		canUserChangeCalendar: function(senderEmilAddress, callback, scope) {
			const config = this.getMeetingServiceConfig(senderEmilAddress, "CanUserChangeCalendar",
				function(response) {
					this.canUserChangeCalendarCallback(response, callback, scope);
				});
			return ServiceHelper.callService(config);
		},

		/**
		 * Gets configs for calling the service with the ability to send invitations.
		 * @param {String} senderEmailAddress Meeting unique identifier.
		 * @param {String} methodName Meeting service method name.
		 * @param {Function} callback Callback function.
		 * @return {Object} Send invitations service config.
		 * @private
		 */
		getMeetingServiceConfig: function (senderEmailAddress, methodName, callback) {
			return {
				"serviceName": this.meetingServiceName,
				"methodName": methodName,
				"data":{
					"senderEmailAddress": senderEmailAddress
				},
				"callback": callback,
				"scope": this
			};
		},

		/**
		 * BPMSoft.SyncSettingsMixin#canUserChangeCalendar callback.
		 */
		canUserChangeCalendarCallback: BPMSoft.abstractFn,

		/**
		 * Returns sync settings entity schema name.
		 * @protected
		 * @return {String} Schema name.
		 */
		getSyncSettingsSchemaName: function() {
			return this.entitySchemaName + "SyncSettings";
		},

		/**
		 * Shows sync settings dialog.
		 * @protected
		 */
		showSyncDialog: function() {
			var modalBoxSize = {
				minHeight: "1",
				minWidth: "1",
				maxHeight: "100",
				maxWidth: "100",
				widthPixels: "425",
				heightPixels: "200"
			};
			var schemaName = this.getDialogSchemaName();
			var modalBoxContainer = ModalBox.show(modalBoxSize);
			this.sandbox.loadModule("CredentialsSyncSettingsEdit", {
				renderTo: modalBoxContainer,
				instanceConfig: {
					schemaName: schemaName,
					isSchemaConfigInitialized: true,
					useHistoryState: false
				}
			});
			ModalBox.setSize(this.modalWidth, this.modalHeight);
		},

		/**
		 * Add synchronization actions into section action item collection.
		 * @protected
		 * @param {BPMSoft.Collection} actionMenuItems Section action item collection.
		 * @param {Number} position Actions position in section actions list.
		 */
		setSyncSectionActions: function(actionMenuItems, position) {
			position = position || 0;
			this.set("SyncSettings", null);
			actionMenuItems.add(actionMenuItems.getUniqueKey(), this.getButtonMenuItem({
				"Caption": {"bindTo": "Resources.Strings.SynchronizeSubmenuCaption"},
				"Items": {"bindTo": "SynchronizeActivitiesSubmenu"}
			}), position);
			this.updateSyncSettings(function() {
				this.initSynchronizeSubmenuActionItems();
			}, this);
		},

		/**
		 * Show active calendar dialog.
		 * @protected
		 */
		showActiveCalendarDialog: function() {
			this.showInformationDialog(this.get("Resources.Strings.ActiveCalendarDialogMessage")
				|| Resources.localizableStrings.ActiveCalendarDialogMessage, BPMSoft.emptyFn);
		},

		/**
		 * Navigate to set up sync settings page.
		 * @protected
		 * @param {Guid} mailboxSyncSettingsId Mailbox settings id.
		 */
		navigateToSyncSettings: function(mailboxSyncSettingsId) {
			if (mailboxSyncSettingsId) {
				this.openExchangeSettingsPage(mailboxSyncSettingsId);
			} else {
				this.openGoogleSettingsPage();
			}
			return false;
		}

		//endregion

	});

	return BPMSoft.SyncSettingsMixin;
});
