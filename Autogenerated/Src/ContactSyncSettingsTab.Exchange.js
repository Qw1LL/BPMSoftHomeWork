Ext.ns("BPMSoft.enums.SyncSettings");
define("ContactSyncSettingsTab", ["ContactSyncSettingsTabResources", "ExchangeNUIConstants"],
	function(resources, ExchangeNuiConstants) {
		return {
			entitySchemaName: "ContactSyncSettings",
			attributes: {
				/**
				 * Automation synchronization.
				 */
				"ExchangeAutoSynchronization": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Value of radio group "Import contacts".
				 */
				"ImportContactsRadioGroup": {
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Value of radio group "Export contacts".
				 */
				"ExportContactsRadioGroup": {
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Id of reference MailboxSyncSettings.
				 */
				"MailboxSyncSettingsId": {
					"dataValueType": this.BPMSoft.DataValueType.GUID,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Name of mailbox.
				 */
				"MailboxName": {
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Type of server.
				 */
				"ServerTypeId": {
					"dataValueType": this.BPMSoft.DataValueType.GUID,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},
			methods: {
				/**
				 * @inheritDoc BPMSoft.BaseSyncSettingsTab#initDefaultValues
				 * @overridden
				 */
				initDefaultValues: function(callback, scope) {
					this.initMailboxSyncSettingValues();
					this.initEntity(function() {
						if (callback) {
							callback.call(scope || this);
						}
					}, this);
				},

				/**
				 * @inheritDoc BPMSoft.BaseSyncSettingsTab#getDefValuesConfig
				 * @overridden
				 */
				getDefValuesConfig: function() {
					return {
						columns: ["ImportContacts", "ImportContactsAll", "ImportContactsFromFolders", "ExportContacts",
							"ExportContactsAll", "ExportContactsSelected", "ImportContactsFolders",
							"ExportContactsGroups", "ExportContactsEmployers", "ExportContactsCustomers",
							"ExportContactsFromGroups"]
					};
				},

				/**
				 * @inheritDoc BPMSoft.BaseSyncSettingsTab#saveSettings
				 * @overridden
				 */
				saveSettings: function(callback, scope) {
					var folderParameters  = this.getFolderParameters();
					this.BPMSoft.each(folderParameters, function(folderParameter) {
						this.prepareChosenFoldersList(folderParameter);
					}, this);
					var update = this.getUpdateQuery();
					update.execute(function(result) {
						if (!(result && result.success)) {
							throw new BPMSoft.UnknownException({
								message: result.errorInfo.message
							});
						}
						callback.call(scope || this);
					}, this);
				},

				/**
				 * @inheritDoc BPMSoft.BaseSyncSettingsTab#getUpdateQuery
				 * @overridden
				 */
				getUpdateQuery: function() {
					var batchQuery = this.Ext.create("BPMSoft.BatchQuery");
					var updateContactSettings = this.getUpdateQueryContactSettings();
					var updateMailbox = this.getUpdateQueryMailbox();
					batchQuery.add(updateContactSettings);
					batchQuery.add(updateMailbox);
					return batchQuery;
				},

				/**
				 * Generates update query for contact settings.
				 * @return {BPMSoft.UpdateQuery} Update query for settings.
				 */
				getUpdateQueryContactSettings: function() {
					var update = this.Ext.create("BPMSoft.UpdateQuery", {
						rootSchemaName: this.entitySchemaName
					});
					var filters = update.filters;
					var settingsId = this.get("Id");
					var idFilter = update.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
						"Id", settingsId);
					filters.add("IdFilter", idFilter);
					update.setParameterValue("ImportContacts",
						this.get("ImportContacts"), this.BPMSoft.DataValueType.BOOLEAN);
					update.setParameterValue("ImportContactsAll",
						this.get("ImportContactsAll"), this.BPMSoft.DataValueType.BOOLEAN);
					update.setParameterValue("ImportContactsFromFolders",
						this.get("ImportContactsFromFolders"), this.BPMSoft.DataValueType.BOOLEAN);
					update.setParameterValue("ImportContactsFolders",
						this.getSelectedFolders("ImportContactsFolders", "ImportContactsFromFolders"),
						this.BPMSoft.DataValueType.TEXT);
					update.setParameterValue("ExportContacts",
						this.get("ExportContacts"), this.BPMSoft.DataValueType.BOOLEAN);
					update.setParameterValue("ExportContactsAll",
						this.get("ExportContactsAll"), this.BPMSoft.DataValueType.BOOLEAN);
					update.setParameterValue("ExportContactsEmployers",
						this.get("ExportContactsEmployers"), this.BPMSoft.DataValueType.BOOLEAN);
					update.setParameterValue("ExportContactsCustomers",
						this.get("ExportContactsCustomers"), this.BPMSoft.DataValueType.BOOLEAN);
					update.setParameterValue("ExportContactsSelected",
						this.get("ExportContactsSelected"), this.BPMSoft.DataValueType.BOOLEAN);
					update.setParameterValue("ExportContactsFromGroups",
							this.get("ExportContactsFromGroups"), this.BPMSoft.DataValueType.BOOLEAN);
					update.setParameterValue("ExportContactsGroups",
						this.getSelectedFolders("ExportContactsGroups", "ExportContactsSelected"),
						this.BPMSoft.DataValueType.TEXT);
					return update;
				},

				/**
				 * @inheritDoc BPMSoft.BaseSyncSettingsTab#setDefaultValues
				 * @overridden
				 */
				setDefaultValues: function() {
					this.callParent(arguments);
					this.subscribeViewModelEvents();
				},

				/**
				 * Subscribes for the events.
				 */
				subscribeViewModelEvents: function() {
					this.on("change:ImportContactsAll", this.onContactSyncParametersChanged, this);
					this.on("change:ExportContactsAll", this.onContactSyncParametersChanged, this);
				},

				/**
				 * Unsubscribes for the events.
				 */
				unsubscribeViewModelEvents: function() {
					this.un("change:ImportContactsAll", this.onContactSyncParametersChanged, this);
					this.un("change:ExportContactsAll", this.onContactSyncParametersChanged, this);
				},

				/**
				 * Set import or export parameters if contact synhronization parameters was changed.
				 * @param {Object} model Backbone model.
				 * @param {Boolean} value Value element flag.
				 */
				onContactSyncParametersChanged: function(model, value) {
					var changedProperties = Object.getOwnPropertyNames(model.changed);
					if (!this.Ext.isEmpty(changedProperties)) {
						var changeProperty = changedProperties[0];
						switch (changeProperty) {
							case "ImportContactsAll":
								this.set("ImportContactsFromFolders", !value);
								break;
							case "ExportContactsAll":
								this.set("ExportContactsSelected", !value);
								break;
							default :
								break;
						}
					}
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
							exchangeAutoSynchronizationContacts: this.get("ExchangeAutoSynchronization"),
							importContacts: this.get("ImportContacts"),
							exportContacts: this.get("ExportContacts")
						}
					};
					this.set("TabSavedValuesConfig", config);
					this.callParent(arguments);
				},

				/**
				 * Changes state of import contacts radio group.
				 * @param {Boolean} value Flag import contact.
				 */
				changeStateImportContactsRadioButtons: function(value) {
					if (!value) {
						this.set("ImportContactsAll", true);
					}
					this.set("ImportContacts", value);
				},

				/**
				 * Changes state of export contacts radio group.
				 * @param {Boolean} value Flag export contact.
				 */
				changeStateExportContactsRadioButtons: function(value) {
					if (!value) {
						this.set("ExportContactsAll", true);
					}
					this.set("ExportContacts", value);
				},

				/**
				 * @inheritDoc BPMSoft.BaseSyncSettingsTab#getFolderParameters
				 * @overridden
				 */
				getFolderParameters: function() {
					return [
						{
							foldersCollectionName: "FoldersGridData",
							folderClassName: ExchangeNuiConstants.ExchangeFolder.ContactClass.Name,
							nameOfFolders: "ImportContactsFolders",
							selectedRows: "SelectedRows"
						},
						{
							foldersCollectionName: "ExportFoldersGridData",
							folderClass: ExchangeNuiConstants.ExchangeFolder.BPMContact,
							nameOfFolders: "ExportContactsGroups",
							selectedRows: "ExportSelectedRows"
						}
					];
				},

				/**
				 * @inheritDoc BPMSoft.BaseSyncSettingsTab#selectFolders
				 * @overridden
				 */
				selectFolders: function(config, callback, scope) {
					var folders = [];
					if (callback) {
						var parameterValue = this.get(config.nameOfFolders);
						if (!this.Ext.isEmpty(parameterValue)) {
							folders = this.Ext.decode(parameterValue);
						}
						callback.call(scope || this, folders);
					}
				},

				/**
				 * @inheritDoc BPMSoft.BaseSyncSettingsTab#loadFolders
				 * @overridden
				 */
				loadFolders: function(config, callback, scope) {
					if (config.folderClass === ExchangeNuiConstants.ExchangeFolder.BPMContact) {
						this.getDynamicGroups(config, callback, scope || this);
					} else {
						this.callParent(arguments);
					}
				},

				/**
				 * @inheritDoc BPMSoft.BaseSyncSettingsTab#onReloadTab
				 * @overridden
				 */
				onReloadTab: function() {
					var newType = this.sandbox.publish("GetMailboxSyncSettingValues", {columns: ["ServerTypeId"]});
					if (newType.ServerTypeId === ExchangeNuiConstants.MailServer.Type.Exchange) {
						this.callParent(arguments);
					}
				},

				/**
				 * @inheritDoc BPMSoft.BaseSchemaModule#destroy
				 * @overridden
				 */
				destroy: function() {
					this.unsubscribeViewModelEvents();
					this.callParent(arguments);
				}
			},
			diff: [
				{
					"operation": "insert",
					"name": "SyncContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ExchangeAutoSynchronization",
					"parentName": "SyncContainer",
					"propertyName": "items",
					"values": {
						"caption": {"bindTo": "Resources.Strings.ExchangeAutoSynchronization"},
						"bindTo": "ExchangeAutoSynchronization",
						"controlConfig": {
							"className": "BPMSoft.ToggleEdit"
						},
						"wrapClass": ["settings-page-reverse-toggle-edit"]
					}
				},
				{
					"operation": "insert",
					"name": "ImportContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ImportContacts",
					"parentName": "ImportContainer",
					"propertyName": "items",
					"index": 0,
					"values": {
						"bindTo": "ImportContacts",
						"controlConfig": {
							"checkedchanged": {"bindTo": "changeStateImportContactsRadioButtons"},
							"className": "BPMSoft.ToggleEdit"
						},
						"wrapClass": ["settings-page-reverse-toggle-edit"]
					}
				},
				{
					"operation": "insert",
					"name": "ImportContactsRadioGroup",
					"parentName": "ImportContainer",
					"propertyName": "items",
					"index": 1,
					"values": {
						"itemType": BPMSoft.ViewItemType.RADIO_GROUP,
						"value": {"bindTo": "ImportContactsAll"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ImportContactsAll",
					"parentName": "ImportContactsRadioGroup",
					"propertyName": "items",
					"values": {
						"caption": {"bindTo": "Resources.Strings.ImportContactsAll"},
						"enabled": {"bindTo": "ImportContacts"},

						"value": true
					}
				},
				{
					"operation": "insert",
					"name": "ImportContactsFromFolders",
					"parentName": "ImportContactsRadioGroup",
					"propertyName": "items",
					"values": {
						"caption": {"bindTo": "Resources.Strings.ImportContactsFromFolders"},
						"enabled": {"bindTo": "ImportContacts"},

						"value": false
					}
				},
				{
					"operation": "insert",
					"parentName": "ImportContainer",
					"propertyName": "items",
					"name": "ImportGridContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"visible": {"bindTo": "ImportContactsFromFolders"},
						"items": []
					}
				},
				{
					"operation": "move",
					"parentName": "ImportGridContainer",
					"propertyName": "items",
					"name": "FoldersGrid",
					"index": 2
				},
				{
					"operation": "insert",
					"name": "ExportContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ExportContacts",
					"parentName": "ExportContainer",
					"propertyName": "items",
					"index": 0,
					"values": {
						"bindTo": "ExportContacts",
						"controlConfig": {
							"checkedchanged": {"bindTo": "changeStateExportContactsRadioButtons"},
							"className": "BPMSoft.ToggleEdit"
						},
						"wrapClass": ["settings-page-reverse-toggle-edit"]
					}
				},
				{
					"operation": "insert",
					"name": "ExportContactsRadioGroup",
					"parentName": "ExportContainer",
					"propertyName": "items",
					"index": 1,
					"values": {
						"itemType": BPMSoft.ViewItemType.RADIO_GROUP,
						"value": {"bindTo": "ExportContactsAll"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ExportContactsAll",
					"parentName": "ExportContactsRadioGroup",
					"propertyName": "items",
					"values": {
						"caption": {"bindTo": "Resources.Strings.ExportContactsAll"},
						"enabled": {"bindTo": "ExportContacts"},

						"value": true
					}
				},
				{
					"operation": "insert",
					"name": "ExportContactsGroups",
					"parentName": "ExportContactsRadioGroup",
					"propertyName": "items",
					"values": {
						"caption": {"bindTo": "Resources.Strings.ExportContactsGroups"},
						"enabled": {"bindTo": "ExportContacts"},

						"value": false
					}
				},
				{
					"operation": "insert",
					"name": "ExportContainerInner",
					"parentName": "ExportContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"visible": {"bindTo": "ExportContactsSelected"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ExportContactsEmployers",
					"parentName": "ExportContainerInner",
					"propertyName": "items",
					"values": {
						"bindTo": "ExportContactsEmployers",
						"caption": {"bindTo": "Resources.Strings.ExportContactsEmployers"},
						"wrapClass": ["settings-page-reverse-checkbox"],
						"styles": {
							"margin-left": "32px"
						}
					}
				},
				{
					"operation": "insert",
					"name": "ExportContactsCustomers",
					"parentName": "ExportContainerInner",
					"propertyName": "items",
					"values": {
						"bindTo": "ExportContactsCustomers",
						"caption": {"bindTo": "Resources.Strings.ExportContactsCustomers"},
						"wrapClass": ["settings-page-reverse-checkbox"],
						"styles": {
							"margin-left": "32px"
						}
					}
				},
				{
					"operation": "insert",
					"name": "ExportContactsFromGroups",
					"parentName": "ExportContainerInner",
					"propertyName": "items",
					"values": {
						"bindTo": "ExportContactsFromGroups",
						"caption": {"bindTo": "Resources.Strings.ExportContactsFromGroups"},
						"wrapClass": ["settings-page-reverse-checkbox"],
						"styles": {
							"margin-left": "32px"
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "ExportContainerInner",
					"propertyName": "items",
					"name": "ExportGridContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"visible": {"bindTo": "ExportContactsFromGroups"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ExportFoldersGrid",
					"parentName": "ExportGridContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID,
						"hierarchical": true,
						"multiSelect": {"bindTo": "IsMultiSelect"},
						"primaryColumnName": "Id",
						"collection": {"bindTo": "ExportFoldersGridData"},
						"hierarchicalColumnName": "ParentId",
						"expandHierarchyLevels": {"bindTo": "ExportExpandHierarchyFrom"},
						"activeRow": {bindTo: "ActiveRow"},
						"selectedRows": {bindTo: "ExportSelectedRows"},
						"selectRow": {"bindTo": "onItemFocused"},
						"type": "listed",
						"listedConfig": {
							"name": "ExportFoldersGridListedConfig",
							"items": [
								{
									name: "ExportFolderNameListedGridColumn",
									bindTo: "Name",
									position: {column: 1, colSpan: 24}
								}
							]
						},
						tiledConfig: {
							name: "ExportFoldersGridTiledConfig",
							grid: {
								columns: 24,
								rows: 1
							},
							items: [
								{
									name: "ExportFolderNameTiledGridColumn",
									bindTo: "Name",
									position: {row: 1, column: 1, colSpan: 24}
								}
							]
						}
					}
				}
			]
		};
	});
