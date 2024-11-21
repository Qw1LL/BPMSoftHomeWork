define("EmailSyncSettings", ["ExchangeNUIConstants", "RightUtilities", "EmailSyncSettingsResources", "MacrosUtilities",
		"ExtendedHtmlEditModule", "EmailImageMixin", "MailboxRightsDetailRow", "css!HtmlEditModule"],
		function(ExchangeNuiConstants, RightUtilities) {
	return {
		entitySchemaName: "MailboxSyncSettings",
		attributes: {
			/**
			 * Virtual column for mail sync period comboboxedit.
			 */
			"MailSyncPeriod": {
				"onChange": "onMailSyncPeriodChange",
				"isRequired": true
			},

			/**
			 * Flag that shows signature editor text mode.
			 */
			"IsPlainTextMode": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			},

			/**
			 * Current mailbox rights collection.
			 */
			"MailboxRights": {
				"dataValueType": this.BPMSoft.DataValueType.COLLECTION
			},

			/**
			 * Mailbox rights detail row view model.
			 */
			"MailboxRightsDetailRowViewModelClass": {
				dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT
			},

			/**
			 * Mailbox rights detail row view config.
			 */
			"MailboxRightsDetailRowViewConfig": {
				dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT
			},
			/**
			 * New rights row add button enabled flag.
			 */
			"AddMailboxRightsEnabled": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: true
			}
		},
		mixins: {
			/**
			 * @class BPMSoft.EmailImageMixin
			 * Mixin for inserting images.
			 */
			EmailImageMixin: "BPMSoft.EmailImageMixin",

			/**
			 * @class BPMSoft.MacrosUtilities
			 * Mixin for processing email macroses.
			 */
			MacrosUtilities: "BPMSoft.MacrosUtilities"
		},

		messages: {
			/**
			 * @message MacroSelected
			 * Handles macros selected event from macroses modalbox page.
			 */
			"MacroSelected": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message GetSelectedAdminUnits
			 * Returns seelected admin unit list from detail.
			 */
			"GetSelectedAdminUnits": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.BIDIRECTIONAL
			}
		},

		methods: {

			//region Methods: Private

			/**
			 * Generates view model class and view config, using client unit schema.
			 * @private
			 * @param {Object} buildConfig Schema builder config.
			 * @param {String} buildConfig.schemaName Client unit schema name.
			 * @param {String} buildConfig.profileKey Client unit schema profile key.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			_internalBuildSchema: function(buildConfig, callback, scope) {
				var schemaBuilderName = this.$SchemaBuilderName || "BPMSoft.SchemaBuilder";
				var schemaBuilder = this.Ext.create(schemaBuilderName);
				var generatorConfig = this.BPMSoft.deepClone(buildConfig);
				schemaBuilder.build(generatorConfig, function(viewModelClass, viewConfig) {
					this.Ext.callback(callback, scope, [viewModelClass, viewConfig]);
				}, this);
			},

			/**
			 * Returns first item of collection, filtered by filter function.
			 * @private
			 * @param {BPMSoft.Collection} collection Collection instance.
			 * @param {Function} filterFn Filter function.
			 * @return {Object} First collection item, filtered by function.
			 */
			_firstByFn: function(collection, filterFn) {
				var filteredItems = collection.filterByFn(filterFn);
				return filteredItems.findByIndex(0);
			},

			/**
			 * Returns current entity schema rights schema name.
			 * @private
			 * @return {String} Current entity schema rights schema name.
			 */
			_getEntitySchemaRightName: function() {
				return this.Ext.String.format("Sys{0}Right", this.entitySchemaName);
			},

			/**
			 * Generates update query instance for current  mailbox settings.
			 * @private
			 * @return {BPMSoft.UpdateQuery} Update query for mailbox settings.
			 */
			_getUpdateQuery: function() {
				var update = this.Ext.create("BPMSoft.UpdateQuery", {
					rootSchemaName: "MailboxSyncSettings"
				});
				var filters = update.filters;
				var settingsId = this.$Id;
				var idFilter = update.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
					"Id", settingsId);
				filters.add("IdFilter", idFilter);
				return update;
			},

			/**
			 * Creates valid signature field value.
			 * @private
			 * @returns {String} Signature value.
			 */
			_getSignature: function() {
				let result = this.$Signature || "";
				if (result && !BPMSoft.includes(result, "<signature>")) {
					result = this.Ext.String.format("<signature>{0}</signature>", result);
				}
				return result.replace(/<div>&nbsp;<\/div>/g, "<br/>").replace(/\n/g, "").replace(/\r/g, "");
			},

			//endregion

			//region Methods: Protected

			/**
			 * @inheritDoc BPMSoft.BaseSyncSettingsTab#init.
			 * @overridden
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this.initImageUrlTpl();
					this.initCollections();
					BPMSoft.chain(
						this.initCanManageSharedMailBoxes,
						this.initMailboxSettingsFileUId,
						this.buildSchema,
						this.loadRightsDetail,
						function() {
							this.Ext.callback(callback, scope || this);
						},
						this);
				}, this]);
			},

			/**
			 * @inheritDoc BPMSoft.BaseSyncSettingsTab#subscribeSandboxEvents.
			 * @overridden
			 */
			subscribeSandboxEvents: function() {
				this.callParent(arguments);
				var macrosModuleId = this.getMacrosModuleId();
				this.sandbox.subscribe("MacroSelected", this.onGetMacros, this, [macrosModuleId]);
				this.sandbox.subscribe("GetSelectedAdminUnits", this.onGetSelectedAdminUnits, this, [this.sandbox.id]);
			},

			/**
			 * Returns selected admin units identifiers on email rights detail.
			 * @protected
			 * @returns {Array} Selected admin units identifiers.
			 */
			onGetSelectedAdminUnits: function() {
				let result = [];
				this.$MailboxRights.each(function(row) {
					const sysAdminUnit = row.$SysAdminUnit;
					if (!this.isEmpty(sysAdminUnit) && row.$RowVisible) {
						result.push(sysAdminUnit.value);
					}
				}, this);
				return result;
			},

			/**
			 * Sets file entity UId property value.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			initMailboxSettingsFileUId: function(callback, scope) {
				BPMSoft.require([this.getFileEntitySchemaName()], function(fileEntity) {
					this.set("FileEntityUId", fileEntity.uId);
					this.Ext.callback(callback, scope);
				}, this);
			},

			/**
			 * @inheritDoc BPMSoft.BaseSyncSettingsTab#getDefValuesConfig.
			 * @overridden
			 */
			getDefValuesConfig: function() {
				return {
					columns: ["Id", "AutomaticallyAddNewEmails", "EnableMailSynhronization",
						"LoadAllEmailsFromMailBox", "SendEmailsViaThisAccount", "IsDefault",
						"LoadEmailsFromDate", "MailSyncPeriod", "LastSyncDate", "ServerTypeId",
						"MailServer", "UserName", "SenderEmailAddress", "AllowEmailDownloading",
						"AllowEmailSending", "MailboxName", "SysAdminUnit", "IsShared", "SenderDisplayValue",
						"UseSignature", "Signature", "MarkEmailsAsSynchronized"]
				};
			},

			/**
			 * @inheritDoc BPMSoft.BaseSyncSettingsTab#selectFolders.
			 * @overridden
			 */
			selectFolders: function(config, callback, scope) {
				var settingsId = this.get("Id");
				var folders = [];
				if (!settingsId) {
					callback.call(this, folders);
					return;
				}
				var select = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "MailboxFoldersCorrespondence"
				});
				select.addColumn("FolderPath");
				var filters = this.Ext.create("BPMSoft.FilterGroup");
				filters.addItem(select.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "Mailbox", settingsId));
				select.filters = filters;
				select.getEntityCollection(
					function(response) {
						var responseItems = response.collection.getItems();
						for (var i = 0; i < responseItems.length; i++) {
							folders.push({
								Path: responseItems[i].get("FolderPath")
							});
						}
						callback.call(scope || this, folders);
					}, this);
			},

			/**
			 * @inheritDoc BPMSoft.BaseSyncSettingsTab#getOldFoldersSelect.
			 * @overridden
			 */
			getOldFoldersSelect: function() {
				var oldFoldersSelect = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "MailboxFoldersCorrespondence"
				});
				oldFoldersSelect.addColumn("Id");
				oldFoldersSelect.addColumn("ActivityFolder");
				oldFoldersSelect.addColumn("FolderPath");
				oldFoldersSelect.filters.addItem(
					oldFoldersSelect.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
						"Mailbox", this.get("Id")));
				return oldFoldersSelect;
			},

			/**
			 * @inheritDoc BPMSoft.BaseSyncSettingsTab#getFolderForDeleteBySchemaName.
			 * @overridden
			 */
			getFolderForDeleteBySchemaName: function(id, rootSchemaName) {
				var del = this.Ext.create("BPMSoft.DeleteQuery", {
					rootSchemaName: rootSchemaName
				});
				var filters = this.Ext.create("BPMSoft.FilterGroup");
				filters.addItem(del.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
					"Id", id));
				del.filters = filters;
				return del;
			},

			/**
			 * @inheritDoc BPMSoft.BaseSyncSettingsTab#setAdditionalFolderInsert.
			 * @overridden
			 */
			setAdditionalFolderInsert: function(insertChildFolders, mailBoxSyncSettingsId, folderId, folderPath) {
				insertChildFolders.add(this.getMailboxFolderCorrespondenceInsert(mailBoxSyncSettingsId,
					folderId, folderPath));
			},

			/**
			 * @inheritDoc BPMSoft.BaseSyncSettingsTab#onSaved
			 * @overridden
			 */
			onSaved: function() {
				var config = {
					tabName: this.get("TabName"),
					values: {
						isSaved: true,
						enableMailSynhronization: this.get("EnableMailSynhronization"),
						automaticallyAddNewEmails: this.get("AutomaticallyAddNewEmails"),
						sendEmailsViaThisAccount: this.get("SendEmailsViaThisAccount")
					}
				};
				this.set("TabSavedValuesConfig", config);
				this.callParent(arguments);
			},

			/**
			 * Sets IsDefault parameter.
			 * @protected
			 */
			SetIsDefault: function(value) {
				if (!value) {
					this.set("IsDefault", false);
				}
			},

			/**
			 * Sets AutomaticallyAddNewEmails parameter.
			 * @protected
			 */
			SetAutomaticallyAddNewEmails: function(value) {
				if (!value) {
					this.set("AutomaticallyAddNewEmails", false);
					this.set("LoadAllEmailsFromMailBox", true);
				}
			},

			/**
			 * Returns use sender display value checkbox state.
			 * @protected
			 * @return {boolean} Checkbox state.
			 */
			getSenderDisplayValueChecked: function() {
				return this.get("SendEmailsViaThisAccount") && !this.Ext.isEmpty(this.get("SenderDisplayValue"));
			},

			/**
			 * Clears sender display value.
			 * @protected
			 * @param {[type]} checkboxState Checkbox state.
			 */
			clearSenderDisplayValue: function(checkboxState) {
				if (!checkboxState) {
					this.set("SenderDisplayValue", "");
				}
			},

			/**
			 * Retruns true, if imap server settings editing.
			 * @protected
			 * @return {Boolean} Is imap server settings editing.
			 */
			isImapMailbox: function() {
				var consts = this.getExchangeNuiConstants();
				var serverType = this.get("ServerTypeId");
				return (serverType === consts.MailServer.Type.Imap);
			},

			/**
			 * Sets initial values for collection attributes.
			 * @protected
			 */
			initCollections: function() {
				this.set("MailboxRights", this.Ext.create("BPMSoft.BaseViewModelCollection"));
				this.set("Images", this.Ext.create("BPMSoft.BaseViewModelCollection"));
			},

			/**
			 * Generates rights row detail view model class and view config, using rights row detail schema.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			buildSchema: function(callback, scope) {
				var generatorConfig = {
					schemaName: "MailboxRightsDetailRow",
					profileKey: "MailboxRightsDetailRow"
				};
				this._internalBuildSchema(generatorConfig, function(viewModelClass, viewConfig) {
					this.$MailboxRightsDetailRowViewModelClass = viewModelClass;
					this.$MailboxRightsDetailRowViewConfig = viewConfig[0];
					this.Ext.callback(callback, scope || this);
				}, this);
			},

			/**
			 * Sets rights row item view config on render. Used as ContainerList "onGetItemConfig" event handler.
			 * @protected
			 * @param {Object} itemConfig Config object.
			 */
			getChangeAdminRightsItemConfig: function(viewConfig) {
				viewConfig.config = this.$MailboxRightsDetailRowViewConfig;
			},

			/**
			 * Sets empty rights detail message view config to config parameter.
			 * @protected
			 * @param {Object} config Empty message config.
			 */
			prepareEmptyRightsMessageConfig: function(config) {
				config.className = "BPMSoft.Label";
				config.caption = this.get("Resources.Strings.RightsEmpty");
				config.classes = {
					"labelClass": ["rights-empty-message"]
				};
			},

			/**
			 * Add new rights row cancel button handler.
			 * @protected
			 * @param {String} collectionName Rights detail collection name.
			 * @param {BPMSoft.BaseViewModel} item New rights row view model.
			 */
			onRightsAddCanceled: function(collectionName, item) {
				var collection = this.get(collectionName);
				collection.remove(item);
				item.un("cancel", this.onRightsAddCanceled.bind(this, collectionName));
				item.un("changed", this.onItemFocused, this);
				item.un("saved", this.setAddMailboxRightsEnabled, this);
				item.destroy();
				this.setAddMailboxRightsEnabled();
			},

			/**
			 * Adds new rights row view model to rights detail collection.
			 * @protected
			 * @param {Object|String} viewModelClass Rights row view model class.
			 * @param {String} collectionName Rights detail collection name.
			 * @param {Object} values New row initial values config.
			 */
			addViewModel: function(viewModelClass, collectionName, values) {
				var id = this.BPMSoft.generateGUID();
				var newItem = this.createViewModel(viewModelClass, id, values);
				newItem.on("cancel", this.onRightsAddCanceled.bind(this, collectionName));
				newItem.on("changed", this.onItemFocused, this);
				newItem.on("saved", this.setAddMailboxRightsEnabled, this);
				var collection = this.get(collectionName);
				collection.add(id, newItem);
				return newItem;
			},

			/**
			 * Creates new rights row view model.
			 * @protected
			 * @param {Object|String} viewModelClass Rights row view model class.
			 * @param {String} id New view model unique identifier.
			 * @param {Object} config New row initial values config.
			 * @return {BPMSoft.BaseViewModel} New rights row view model instance.
			 */
			createViewModel: function(viewModelClass, id, config) {
				var initialValues = {
					Id: id,
					MailboxOwner: this.$SysAdminUnit
				};
				this.Ext.apply(initialValues, config);
				var viewModel = this.Ext.create(viewModelClass, {
					Ext: this.Ext,
					BPMSoft: this.BPMSoft,
					sandbox: this.sandbox,
					values: initialValues
				});
				viewModel.init();
				return viewModel;
			},

			/**
			 * Checks is current user has rights to edit mailbox.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			checkCanEditRights: function(callback, scope) {
				RightUtilities.checkCanEdit({
					schemaName: this.entitySchemaName,
					primaryColumnValue: this.$Id
				}, function(result) {
					var hasEditRights = this.isEmpty(result);
					this.set("CanEditMailbox", hasEditRights);
					this.Ext.callback(callback, scope || this);
				},
				this);
			},

			/**
			 * Loads current maildox rights detail.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			loadRightsDetail: function(callback, scope) {
				if (this.$MailboxRights) {
					this.$MailboxRights.clear();
				}
				BPMSoft.chain(
					this.checkCanEditRights,
					this.loadMailboxRights,
					this.loadEmailDefRights,
					function() {
						this.Ext.callback(callback, scope || this);
					},
					this);
			},

			/**
			 * @inheritDoc BPMSoft.BaseSyncSettingsTab#afterReloadTab
			 * @overridden
			 */
			afterReloadTab: function(callback, scope) {
				this.loadRightsDetail(callback, scope);
			},

			/**
			 * Loads current maildox rights to rights detail.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			loadMailboxRights: function(callback, scope) {
				RightUtilities.getRecordRights({
					"tableName": this._getEntitySchemaRightName(),
					"recordId": this.$Id
				}, function(rightsSet) {
					this.fillMailboxRightsDetail(rightsSet);
					this.Ext.callback(callback, scope || this);
				}, this);
			},

			/**
			 * Creates mailbox rights detail rows and fills mailbox rights detail collection.
			 * @protected
			 * @param {Object[]} rightsSet Mailbox rights set.
			 */
			fillMailboxRightsDetail: function(rightsSet) {
				this.BPMSoft.each(rightsSet, this.createMailboxRightRow, this);
			},

			/**
			 * Creates mailbox rights detail row view model.
			 * @protected
			 * @param {Object} data Mailbox rights set item.
			 * @return {BPMSoft.BaseViewModel} Mailbox rights detail row view model.
			 */
			createMailboxRightRow: function(data) {
				var sysAdminUnit = data.SysAdminUnit.value ;
				if (sysAdminUnit === this.$SysAdminUnit.value) {
					return;
				}
				var rightsRow = this._firstByFn(this.$MailboxRights, function(item) {
					return item.$SysAdminUnit.value === sysAdminUnit;
				});
				if (this.isEmpty(rightsRow)) {
					rightsRow = this.addViewModel(this.$MailboxRightsDetailRowViewModelClass, "MailboxRights", {
						"ReadAllowed": false,
						"SysAdminUnit": data.SysAdminUnit,
						"IsEditMode": false,
						"IsEnabled": this.$IsShared,
						"IsSaved": true
					});
				}
				rightsRow.setMailboxOperation(data);
			},

			/**
			 * Loads current maildox email default rights detail.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			loadEmailDefRights: function(callback, scope) {
				var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {"rootSchemaName": "EmailDefRights"});
				esq.allColumns = true;
				esq.filters.add("MailboxFilter", this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL, "Record", this.$Id));
				esq.filters.add("OwnerFilter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.NOT_EQUAL, "SysAdminUnit", this.$SysAdminUnit.value));
				esq.getEntityCollection(function(response) {
					if (!response.success) {
						this.Ext.callback(callback, scope || this);
						return;
					}
					this.fillEmailDefRightsDetail(response.collection);
					this.Ext.callback(callback, scope || this);
				}, this);
			},

			/**
			 * Creates mailbox email default rights detail rows and fills mailbox emails default
			 * rights detail collection.
			 * @protected
			 * @param {BPMSoft.Collecton} rightsSet Mailbox email default rights collection.
			 */
			fillEmailDefRightsDetail: function(rightsSet) {
				this.BPMSoft.each(rightsSet, this.createEmailDefRightRow, this);
			},

			/**
			 * Creates mailbox emails default rights detail row view model.
			 * @protected
			 * @param {BPMSoft.BaseViewModel} emailDefRight Mailbox email default rigth operation permition.
			 * @return {BPMSoft.BaseViewModel} Mailbox rights detail row view model.
			 */
			createEmailDefRightRow: function(emailDefRight) {
				var rightsRow = this._firstByFn(this.$MailboxRights, function(item) {
					return item.$SysAdminUnit.value === emailDefRight.$SysAdminUnit.value;
				});
				if (this.isEmpty(rightsRow)) {
					rightsRow = this.addViewModel(this.$MailboxRightsDetailRowViewModelClass, "MailboxRights", {
						"ReadAllowed": false,
						"SysAdminUnit": emailDefRight.$SysAdminUnit,
						"IsEditMode": false,
						"IsEnabled": this.$IsShared,
						"IsSaved": true
					});
				}
				rightsRow.setEmailOperation(emailDefRight);
			},

			/**
			 * Saves mailbox rights detail data.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			saveMailboxRights: function(callback, scope) {
				var changedRights = [];
				this.$MailboxRights.each(function(row) {
					var operations = row.getMailboxOperations();
					changedRights = this.Ext.Array.merge(changedRights, operations);
				}, this);
				if (changedRights.length > 0) {
					var rightsUtils = this.getRightUtilities();
					rightsUtils.applyChanges({
						"recordRights": changedRights,
						"record": {
							entitySchemaName: this.entitySchemaName,
							primaryColumnValue: this.$Id
						}
					}, callback, scope || this);
				} else {
					this.Ext.callback(callback, scope || this);
				}
			},

			/**
			 * Saves mailbox emails default rights detail data.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			saveEmailDefRights: function(callback, scope) {
				var saveEmailDefRights = this.createBatchQuery();
				var id = this.$Id;
				this.$MailboxRights.each(function(row) {
					var operations = row.getEmailDefRightsSaveQueries(id);
					this.BPMSoft.each(operations, function(query) {
						saveEmailDefRights.add(query);
					});
				}, this);
				saveEmailDefRights.execute(function() {
					this.loadRightsDetail(callback, scope || this);
				}, this);
			},

			/**
			 * Sets rights rows controls enabled state.
			 * @protected
			 * @param {Boolean} [newState] IsShared flag new state.
			 */
			setRightRowsEnableState: function(newState) {
				this.$MailboxRights.each(function(row) {
					row.$IsEnabled = newState;
				}, this);
				this.setAddMailboxRightsEnabled(newState);
			},

			/**
			 * Sets sign that adding mailbox rights is enabled.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			initCanManageSharedMailBoxes: function(callback, scope) {
				this.setAddMailboxRightsEnabled();
				this.Ext.callback(callback, scope || this);
			},

			/**
			 * Sets add right rows button enabled state.
			 * @protected
			 * @param {Boolean} [newState] IsShared flag new state.
			 */
			setAddMailboxRightsEnabled: function(newState) {
				var isShared = this.isEmpty(newState) ? this.$IsShared : newState;
				if(!isShared) {
					this.$AddMailboxRightsEnabled = false;
					return;
				}
				var result = true;
				this.$MailboxRights.each(function(row) {
					result = result && !row.$IsEditMode;
				}, this);
				this.$AddMailboxRightsEnabled = result;
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#getProfileKey
			 * @override
			 */
			getProfileKey: function() {
				return "EmailSyncSettingsTabProfile";
			},

			/**
			 * Returns email synchronization settings controlenable state.
			 * @protected
			 * @return {Boolean} True when control enabled. Otherwise returns false.
			 */
			getSynchronizationControlEnabled: function() {
				return this.$EnableMailSynhronization && this.$AllowEmailDownloading;
			},

			//endregion

			//region Methods: Public

			/**
			 * Gets InsertQuery for MailboxFoldersCorrespondence.
			 * @param {Guid} mailboxFolderId Id of mailbox.
			 * @param {Guid} activityFolderId Id of folder.
			 * @param {string} path Path parametr of folder.
			 * @return {BPMSoft.InsertQuery} InsertQuery for MailboxFoldersCorrespondence.
			 */
			getMailboxFolderCorrespondenceInsert: function(mailboxFolderId, activityFolderId, path) {
				var insert = this.Ext.create("BPMSoft.InsertQuery", {
					rootSchemaName: "MailboxFoldersCorrespondence"
				});
				insert.setParameterValue("Mailbox", mailboxFolderId, BPMSoft.DataValueType.GUID);
				insert.setParameterValue("ActivityFolder", activityFolderId,
					BPMSoft.DataValueType.GUID);
				insert.setParameterValue("FolderPath", path, BPMSoft.DataValueType.TEXT);
				return insert;
			},

			/**
			 * Generates update query for mailbox settings.
			 * @return {BPMSoft.UpdateQuery} Update query for mailbox settings.
			 */
			getUpdateQuery: function() {
				var update = this._getUpdateQuery();
				update.setParameterValue("AutomaticallyAddNewEmails",
					this.get("AutomaticallyAddNewEmails"), BPMSoft.DataValueType.BOOLEAN);
				update.setParameterValue("EnableMailSynhronization",
					this.get("EnableMailSynhronization"), BPMSoft.DataValueType.BOOLEAN);
				update.setParameterValue("LoadAllEmailsFromMailBox",
					this.get("LoadAllEmailsFromMailBox"), BPMSoft.DataValueType.BOOLEAN);
				update.setParameterValue("SendEmailsViaThisAccount",
					this.get("SendEmailsViaThisAccount"), BPMSoft.DataValueType.BOOLEAN);
				update.setParameterValue("IsDefault",
					this.get("IsDefault"), BPMSoft.DataValueType.BOOLEAN);
				if (this.get("NeedUpdateLoadEmailsFromDate")) {
					update.setParameterValue("LoadEmailsFromDate",
						this.get("LoadEmailsFromDate"), BPMSoft.DataValueType.DATE);
				}
				update.setParameterValue("IsShared",
					this.get("IsShared"), BPMSoft.DataValueType.BOOLEAN);
				update.setParameterValue("SenderDisplayValue",
					this.get("SenderDisplayValue"), BPMSoft.DataValueType.TEXT);
				var mailSyncPeriod = this.get("MailSyncPeriod");
				var mailSyncPeriodValue = mailSyncPeriod.value;
				update.setParameterValue("MailSyncPeriod", mailSyncPeriodValue, BPMSoft.DataValueType.GUID);
				update.setParameterValue("LastSyncDate",
					this.get("LastSyncDate"), BPMSoft.DataValueType.DATE);
				update.setParameterValue("UseSignature",
					this.get("UseSignature"), BPMSoft.DataValueType.BOOLEAN);
				var sign = this._getSignature();
				update.setParameterValue("Signature", sign, BPMSoft.DataValueType.TEXT);
				update.setParameterValue("MarkEmailsAsSynchronized",
					this.get("MarkEmailsAsSynchronized"), BPMSoft.DataValueType.BOOLEAN);
				return update;
			},

			/**
			 * @inheritDoc BPMSoft.BaseSyncSettingsTab#validateSettings.
			 * @overridden
			 */
			validateSettings: function(callback, scope) {
				if (!this.$LoadAllEmailsFromMailBox && this.$SelectedRows.length === 0) {
					this.showInformationDialog(this.get("Resources.Strings.DownloadFromFoldersValidationError"));
					return;
				}
				if (!this.validate()) {
					this.hideBodyMask();
					this.showInformationDialog(this.get("Resources.Strings.FieldValidationError"));
					return;
				}
				callback.call(scope || this);
			},

			/**
			 * Changes LoadEmailsFromDate column value on mail sync period change.
			 * @param {Object} scope Scope of change event.
			 * @param {Object} changedValue Actual value.
			 */
			onMailSyncPeriodChange: function(scope, changedValue) {
				if (changedValue && changedValue.Code) {
					var newDate = this.getNewDate(changedValue.Code, changedValue.Number);
					this.set("LoadEmailsFromDate", newDate);
					this.set("NeedUpdateLoadEmailsFromDate", true);
					this.set("LastSyncDate", null);
				}
			},

			/**
			 * Generates "sync emails from date" parameter value.
			 * @param {String} code Change date code.
			 * @param {Number|null} value Value difference.
			 * @return {Date} Sync emails from date parameter value.
			 */
			getNewDate: function(code, value) {
				var newDate;
				var currentDate = this.Ext.Date.clearTime(new Date());
				switch (code) {
					case "Day":
						newDate = this.Ext.Date.add(currentDate, Ext.Date.DAY, -value);
						break;
					case "Week":
						newDate = this.Ext.Date.add(currentDate, Ext.Date.DAY, -value * 7);
						break;
					case "Month":
						newDate = this.Ext.Date.add(currentDate, Ext.Date.MONTH, -value);
						break;
					case "Year":
						newDate = this.Ext.Date.add(currentDate, Ext.Date.YEAR, -value);
						break;
					case "All":
						newDate = this.Ext.Date.clearTime(new Date(1, 1, 1));
						break;
					default:
						break;
				}
				return newDate;
			},

			/**
			 * Opens macroses page.
			 * @protected
			 */
			onOpenMacrosPage: function() {
				this.openMacrosPage();
			},

			/**
			 * It processes the macros.
			 * @protected
			 * @virtual
			 * @param {String} macros Macros.
			 */
			onGetMacros: function(macros) {
				this.set("SelectedText", macros);
			},

			/**
			 * @inheritDoc BPMSoft.BaseViewModel#getLookupQuery
			 * @overridden
			 */
			getLookupQuery: function(filterValue, columnName) {
				const consts = this.getExchangeNuiConstants();
				const query = this.callParent(arguments);
				if (columnName === "MailSyncPeriod") {
					query.addColumn("Code");
					query.addColumn("Number");
					if (BPMSoft.Features.getIsDisabled("UseAllSyncPeriod")) {
						query.filters.addItem(BPMSoft.createColumnFilterWithParameter(
							BPMSoft.ComparisonType.NOT_EQUAL, "Id", consts.MailSyncPeriod.All));
					}
				}
				return query;
			},

			/**
			 * @inheritDoc BPMSoft.BaseSyncSettingsTab#getFolderParameters
			 * @overridden
			 */
			getFolderParameters: function() {
				var consts = this.getExchangeNuiConstants();
				return [{
					foldersCollectionName: "FoldersGridData",
					folderClassName: consts.ExchangeFolder.NoteClass.Name,
					selectedRows: "SelectedRows"
				}];
			},

			/**
			 * Get flag save opportunity folders.
			 * @return {Boolean} Flag if can save folders.
			 */
			canSaveFolders: function() {
				return !this.get("LoadAllEmailsFromMailBox");
			},

			/**
			 * @inheritDoc BPMSoft.BaseSyncSettingsTab#saveSettings
			 * @overridden
			 */
			saveSettings: function(callback, scope) {
				this.callParent([function() {
					this.BPMSoft.chain(
						this.saveMailboxRights,
						this.saveEmailDefRights,
						function() {
							this.Ext.callback(callback, scope || this);
						},
						this);
				}, this]);
			},

			/**
			 * Returns ExchangeNuiConstants object.
			 * @virtual
			 * @return {Object} ExchangeNuiConstants object.
			 */
			getExchangeNuiConstants: function() {
				return ExchangeNuiConstants;
			},

			/**
			 * Returns RightUtilities instance.
			 * @virtual
			 * @return {Object} RightUtilities instance.
			 */
			getRightUtilities: function() {
				return RightUtilities;
			},

			/**
			 * Creates "Is default" checkbox caption.
			 * @virtual
			 * @return {String} "Is default" checkbox caption.
			 */
			getIsDefaultCaption: function() {
				var template = this.get("Resources.Strings.UseMailboxAsDefaultTpl");
				return this.Ext.String.format(template, this.get("SenderEmailAddress"));
			},

			/**
			 * @inheritdoc BPMSoft.configuration.mixins.EmailImageMixin#getFileEntitySchemaName
			 * @overridden
			 */
			getFileEntitySchemaName: function() {
				return "MailboxSettingsFile";
			},

			/**
			 * @inheritdoc BPMSoft.configuration.mixins.EmailImageMixin#getFileSchemaUId
			 * @overridden
			 */
			getFileSchemaUId: function() {
				return this.get("FileEntityUId");
			},

			/**
			 * @inheritdoc BPMSoft.configuration.mixins.EmailImageMixin#getFileEntityMasterColumnName
			 * @overridden
			 */
			getFileEntityMasterColumnName: function() {
				return "MailboxSyncSettings";
			},

			/**
			 * Returns signature edit enabled state.
			 * @return {Boolean} Signature edit enabled state.
			 */
			getSignatureEditEnabled: function() {
				return this.get("SendEmailsViaThisAccount") && this.get("UseSignature");
			},

			/**
			 * Add new maildox right button handler.
			 */
			onAddMailboxRightsButtonClick: function() {
				let model = this.addViewModel(this.$MailboxRightsDetailRowViewModelClass, "MailboxRights", {
					"IsNew": true,
					"IsEnabled": this.$IsShared
				});
				model.loadVocabulary.call(model, "", "SysAdminUnit");
				if (this.get("IsReady")) {
					this.sandbox.publish("ShowSaveButton");
				}
				this.setAddMailboxRightsEnabled();
			}

			//endregion
		},
		diff: [{
				"operation": "insert",
				"name": "EnableMailSynhronization",
				"index": 0,
				"values": {
					"bindTo": "EnableMailSynhronization",
					"controlConfig": {
						"checkedchanged": {"bindTo": "SetAutomaticallyAddNewEmails"},
						"className": "BPMSoft.ToggleEdit"
					},
					"enabled": {"bindTo": "AllowEmailDownloading"},
					"wrapClass": ["settings-page-reverse-toggle-edit"]
				}
			}, {
				"operation": "insert",
				"name": "SynchronizationHelpMsg",
				"index": 1,
				"values": {
					"itemType": this.BPMSoft.ViewItemType.LABEL,
					"caption": {
						"bindTo": "Resources.Strings.SynchronizationHelpMsg"
					},
					"classes": {
						"labelClass": ["help-label"]
					}
				}
			}, {
				"operation": "insert",
				"name": "MailSyncPeriod",
				"index": 2,
				"values": {
					"contentType": BPMSoft.ContentType.ENUM,
					"enabled": {"bindTo": "getSynchronizationControlEnabled"},
					"isRequired": false,
					"wrapClass": ["date-combobox"]
				}
			},
			{
				"operation": "insert",
				"name": "AutomaticallyAddNewEmails",
				"index": 3,
				"values": {
					"bindTo": "AutomaticallyAddNewEmails",
					"enabled": {"bindTo": "getSynchronizationControlEnabled"},
					"wrapClass": ["settings-page-reverse-checkbox"]
				}
			},
			{
				"operation": "insert",
				"name": "LoadEmailsFrom",
				"index": 4,
				"values": {
					"itemType": BPMSoft.ViewItemType.RADIO_GROUP,
					"value": {"bindTo": "LoadAllEmailsFromMailBox"},
					"wrapClass": ["settings-page-radio-group"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "LoadEmailsFrom",
				"name": "LoadAllEmailsFromMailBox",
				"propertyName": "items",
				"values": {
					"markerValue": "LoadAllEmailsFromMailBox",
					"caption": {"bindTo": "Resources.Strings.LoadAllMessages"},
					"enabled": {"bindTo": "getSynchronizationControlEnabled"},
					"controlConfig": {
						"checkedchanged": {"bindTo": "onItemFocused"}
					},
					value: true
				}
			},
			{
				"operation": "insert",
				"parentName": "LoadEmailsFrom",
				"name": "LoadEmailsFromFolders",
				"propertyName": "items",
				"values": {
					"markerValue": "LoadEmailsFromFolders",
					"caption": {"bindTo": "Resources.Strings.LoadFromFolders"},
					"enabled": {"bindTo": "getSynchronizationControlEnabled"},
					"controlConfig": {
						"checkedchanged": {"bindTo": "onItemFocused"}
					},
					value: false
				}
			},
			{
				"operation": "move",
				"propertyName": "items",
				"name": "FoldersGrid",
				"index": 5
			},
			{
				"operation": "merge",
				"propertyName": "items",
				"name": "FoldersGrid",
				"values": {
					"visible": {
						"bindTo": "LoadAllEmailsFromMailBox",
						"bindConfig": {"converter": "invertBooleanValue"}
					},
					"rowDataItemMarkerColumnName": "Name"
				}
			},
			{
				"operation": "insert",
				"name": "SendEmailsViaThisAccount",
				"index": 6,
				"values": {
					"controlConfig": {
						"checkedchanged": {"bindTo": "SetIsDefault"},
						"className": "BPMSoft.ToggleEdit"
					},
					"enabled": {"bindTo": "AllowEmailSending"},
					"wrapClass": ["settings-page-reverse-toggle-edit"]
				}
			}, {
				"operation": "insert",
				"name": "SendHelpMsg",
				"index": 7,
				"values": {
					"itemType": this.BPMSoft.ViewItemType.LABEL,
					"caption": {
						"bindTo": "Resources.Strings.SendHelpMsg"
					},
					"classes": {
						"labelClass": ["help-label"]
					}
				}
			}, {
				"index": 9,
				"operation": "insert",
				"name": "SenderDisplayValueContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["edit-with-checkbox-container"],
					"visible": {"bindTo": "isImapMailbox"}
				}
			},
			{
				"operation": "insert",
				"name": "SenderDisplayValueCheckbox",
				"parentName": "SenderDisplayValueContainer",
				"propertyName": "items",
				"values": {
					"bindTo": "getSenderDisplayValueChecked",
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"controlConfig": {
						"className": "BPMSoft.CheckBoxEdit",
						"checkedchanged": {"bindTo": "clearSenderDisplayValue"},
						"enabled": {"bindTo": "SendEmailsViaThisAccount"}
					},
					"labelConfig": {
						"visible": false
					}
				}
			},
			{
				"operation": "insert",
				"name": "SenderDisplayValue",
				"parentName": "SenderDisplayValueContainer",
				"propertyName": "items",
				"values": {
					"bindTo": "SenderDisplayValue",
					"enabled": {"bindTo": "SendEmailsViaThisAccount"},
					"wrapClass": ["edit-wrap"],
					"controlConfig": {
                        "className": "BPMSoft.TextEdit",
                        "placeholder": {"bindTo": "Resources.Strings.SenderDisplayPlaceholder"},
						"classes": ["placeholderOpacity"]
                    },
				}
			},
			{
				"operation": "insert",
				"name": "IsDefault",
				"index": 10,
				"values": {
					"enabled": {"bindTo": "SendEmailsViaThisAccount"},
					"wrapClass": ["settings-page-reverse-checkbox"],
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "getIsDefaultCaption"
						}
					}
				}
			}, {
				"operation": "insert",
				"name": "UseSignature",
				"index": 11,
				"values": {
					"enabled": {"bindTo": "SendEmailsViaThisAccount"},
					"wrapClass": ["settings-page-reverse-checkbox"]
				}
			},
			{
				"operation": "insert",
				"name": "SignatureEditWrap",
				"index": 12,
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["signature-edit-container"]
				}
			},
			{
				"operation": "insert",
				"name": "Signature",
				"parentName": "SignatureEditWrap",
				"propertyName": "items",
				"index": 13,
				"values": {
					"markerValue": "Signature",
					"generateId": false,
					"className": "BPMSoft.ExtendedHtmlEdit",
					"itemType": this.BPMSoft.ViewItemType.MODEL_ITEM,
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"contentType": this.BPMSoft.ContentType.RICH_TEXT,
					"labelConfig": {
						"visible": false
					},
					"value": {"bindTo": "Signature"},
					"enabled": {"bindTo": "getSignatureEditEnabled"},
					"toolbarVisible": true,
					"useTemplates": false,
					"openMacrosPage": {"bindTo": "onOpenMacrosPage"},
					"selectedText": {
						"bindTo": "SelectedText"
					},
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
							"bindTo": "IsPlainTextMode"
						},
						"defaultFontFamily": "Segoe UI",
						"resizeEnabled": true,
						"useMacroses": true
					}
				}
			},
			{
				"operation": "insert",
				"name": "IsShared",
				"index": 14,
				"values": {
					"controlConfig": {
						"className": "BPMSoft.ToggleEdit",
						"checkedchanged": {"bindTo": "setRightRowsEnableState"}
					},
					"wrapClass": ["settings-page-reverse-toggle-edit"]
				}
			}, {
				"operation": "insert",
				"name": "SharedMailboxsHelpMsg",
				"index": 15,
				"values": {
					"itemType": this.BPMSoft.ViewItemType.LABEL,
					"caption": {
						"bindTo": "Resources.Strings.SharedMailboxsHelpMsg"
					},
					"classes": {
						"labelClass": ["help-label"]
					}
				}
			}, {
				"operation": "insert",
				"name": "AddRightsControlGroup",
				"index": 16,
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"markerValue": "AddRightsControlGroup",
					"wrapClass": ["add-rights-detail"]
				}
			}, {
				"operation": "insert",
				"parentName": "AddRightsControlGroup",
				"propertyName": "items",
				"name": "AddRightsContainer",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"markerValue": "AddRightsContainer",
					"wrapClass": ["container-list-header", ""]
				}
			}, {
				"operation": "remove",
				"parentName": "AddRightsContainer",
				"propertyName": "items",
				"name": "AddRightsLabel",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.LABEL,
					"caption": {
						"bindTo": "Resources.Strings.MailboxRightsDetailCaption"
					},
					"classes": {
						"labelClass": ["t-title-label-proc"]
					}
				}
			}, {
				"operation": "insert",
				"parentName": "AddRightsContainer",
				"propertyName": "items",
				"name": "AddRightsToolsButton",
				"values": {
					"click": {
						"bindTo": "onAddMailboxRightsButtonClick"
					},
					"caption": {
						"bindTo": "Resources.Strings.MailboxRightsDetailCaption"
					},
					"visible": {"bindTo": "CanEditMailbox"},
					"itemType": this.BPMSoft.ViewItemType.BUTTON,
					"classes": {
						"imageClass": ["button-background-no-repeat", "add-button-image"],
						"wrapperClass": ["add-rule-button"],
						"menuClass": ["detail-tools-button-menu"]
					},
					"imageConfig": {
						"bindTo": "Resources.Images.AddButtonImage"
					},
					"markerValue": "AddMailboxRightsButton",
					"enabled": {"bindTo": "AddMailboxRightsEnabled"},
					"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT_ORANGE
				}
			}, {
				"operation": "insert",
				"parentName": "AddRightsControlGroup",
				"propertyName": "items",
				"name": "AddRightsItemsHeaderContainer",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"markerValue": "AddRightsItemsHeaderContainer",
					"wrapClass": ["rights-items-header-container"]
				}
			}, {
				"operation": "insert",
				"parentName": "AddRightsItemsHeaderContainer",
				"propertyName": "items",
				"name": "AddRightsHeaderLabel",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.LABEL,
					"caption": {
						"bindTo": "Resources.Strings.UserRoleCaption"
					},
					"classes": {
						"labelClass": ["rights-items-header-label"]
					}
				}
			}, {
				"operation": "insert",
				"parentName": "AddRightsItemsHeaderContainer",
				"propertyName": "items",
				"name": "AddRightsItemsHeaderImagesContainer",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"markerValue": "AddRightsItemsHeaderImagesContainer",
					"wrapClass": ["rights-items-header-images-container"]
				}
			}, {
				"operation": "insert",
				"parentName": "AddRightsItemsHeaderImagesContainer",
				"propertyName": "items",
				"name": "ContentAccessLabel",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.LABEL,
					"caption": {
						"bindTo": "Resources.Strings.ContentAccess"
					},
					"classes": {
						"labelClass": ["rights-items-header-label-end"]
					}
				}
			}, {
				"operation": "insert",
				"parentName": "AddRightsItemsHeaderImagesContainer",
				"propertyName": "items",
				"name": "SendAccessLabel",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.LABEL,
					"caption": {
						"bindTo": "Resources.Strings.SendAccess"
					},
					"classes": {
						"labelClass": ["rights-items-header-label-end"]
					}
				}
			}, {
				"operation": "insert",
				"parentName": "AddRightsItemsHeaderImagesContainer",
				"propertyName": "items",
				"name": "EditAccessLabel",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.LABEL,
					"caption": {
						"bindTo": "Resources.Strings.EditAccess"
					},
					"classes": {
						"labelClass": ["rights-items-header-label-end"]
					}
				}
			}, {
				"operation": "insert",
				"parentName": "AddRightsItemsHeaderContainer",
				"propertyName": "items",
				"name": "AddRightsItemsHeaderButtomContainer",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["rights-items-header-buttom-container"]
				}
			}, {
				"operation": "insert",
				"parentName": "AddRightsControlGroup",
				"propertyName": "items",
				"name": "AddRightsContainerList",
				"values": {
					"generator": "ConfigurationItemGenerator.generateContainerList",
					"idProperty": "Id",
					"dataItemIdPrefix": "add-rights-item",
					"collection": "MailboxRights",
					"onGetItemConfig": "getChangeAdminRightsItemConfig",
					"rowCssSelector": ".adminRightsContainer",
					"isEmpty": {
						"bindTo": "MailboxRights",
						"bindConfig": {
							"converter": function(value) {
								return value.isEmpty();
							}
						}
					},
					"getEmptyMessageConfig": {
						"bindTo": "prepareEmptyRightsMessageConfig"
					},
					"classes": {
						"wrapClassName": ["page-container-list-items"]
					}
				}
			}]
	};
});
