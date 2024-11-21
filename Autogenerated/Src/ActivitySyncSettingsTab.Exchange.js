Ext.ns("BPMSoft.enums.SyncSettings");
define("ActivitySyncSettingsTab", ["ActivitySyncSettingsTabResources", "ExchangeNUIConstants", "SyncSettingsMixin"],
	function(resources, ExchangeNuiConstants) {
	return {
		entitySchemaName: "ActivitySyncSettings",
		attributes: {
			/**
			 * Automation synchronization.
			 */
			"ExchangeAutoSyncActivity": {
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Value of radio group "Import appointments and meetings".
			 */
			"ImportAppointmentsRadioGroup": {
				"dataValueType": this.BPMSoft.DataValueType.TEXT,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Value of radio group "Import tasks".
			 */
			"ImportTasksRadioGroup": {
				"dataValueType": this.BPMSoft.DataValueType.TEXT,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Value of radio group "Export tasks and meetings".
			 */
			"ExportActivitiesRadioGroup": {
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
			},

			/**
			 * Sign that new type of meeting integration is disabled.
			 */
			"OldMeetingIntegration": {
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Sign that enabled adding calendar.
			 */
			"CanAddCalendar": {
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN
			},
		},
		mixins: {
			/**
			 * Provides methods for sync settings tabs.
			 */
			"EmailLinksMixin": "BPMSoft.SyncSettingsMixin"

		},
		methods: {

			/**
			 * @inheritDoc BPMSoft.BaseViewModel#getLookupQuery
			 * @overridden
			 */
			getLookupQuery: function(filterValue, columnName) {
				const query = this.callParent(arguments);
				if (columnName === "ActivitySyncPeriod" && BPMSoft.Features.getIsDisabled("UseAllSyncPeriod")) {
					query.filters.addItem(BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.NOT_EQUAL, "Id", ExchangeNuiConstants.MailSyncPeriod.All));
				}
				query.filters.addItem(BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.NOT_EQUAL, "Id", ExchangeNuiConstants.MailSyncPeriod.OneDay));
				query.filters.addItem(BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.NOT_EQUAL, "Id", ExchangeNuiConstants.MailSyncPeriod.ThreeDays));	
				return query;
			},

			/**
			 * @inheritDoc BPMSoft.BaseSyncSettingsTab#initDefaultValues
			 * @overridden
			 */
			initDefaultValues: function(callback, scope) {
				this.set("OldMeetingIntegration", BPMSoft.Features.getIsDisabled("NewMeetingIntegration"));
				this.initMailboxSyncSettingValues();
				this.canUserChangeCalendar(this.$MailboxName, function() {
					this.initEntity(callback, scope || this);
				}, this)

			},

			/**
			 * @inheritdoc BPMSoft.SyncSettingsMixin#canUserChangeCalendarCallback
			 * @overridden
			 */
			canUserChangeCalendarCallback: function(canAddCalendar, callback, scope) {
				this.set("CanAddCalendar", canAddCalendar);
				Ext.callback(callback, scope);
			},

			/**
			 * @inheritdoc BPMSoft.SyncSettingsMixin#getSyncSettingsSchemaName
			 * @overridden
			 */
			getSyncSettingsSchemaName: function() {
				return this.entitySchemaName;
			},

			/**
			 * @inheritDoc BPMSoft.BaseSyncSettingsTab#loadFolders
			 * @overridden
			 */
			loadFolders: function(config, callback, scope) {
				if (config.folderClass === ExchangeNuiConstants.ExchangeFolder.BPMActivity) {
					this.getDynamicGroups(config, callback, scope || this);
				} else {
					this.callParent(arguments);
				}
			},

			/**
			 * @inheritDoc BPMSoft.BaseSyncSettingsTab#selectFolders
			 * @overridden
			 */
			selectFolders: function(config, callback, scope) {
				var folders = [];
				if (callback) {
					var parameterValue = this.get(config.nameOfFolders);
					if (parameterValue) {
						folders = this.Ext.decode(parameterValue);
					}
					callback.call(scope || this, folders);
				}
			},

			/**
			 * @inheritDoc BPMSoft.BaseSyncSettingsTab#getDefValuesConfig
			 * @overridden
			 */
			getDefValuesConfig: function() {
				return {
					columns: ["ImportTasks", "ImportTasksAll", "ImportTasksFromFolders", "ImportAppointments",
						"ImportAppointmentsAll", "ImpAppointmentsFromCalendars", "ExportActivities",
						"ExportActivitiesAll", "ExportActivitiesFromGroups",
						"ImportActivitiesFrom", "ImportAppointmentsCalendars", "ExportActivitiesGroups",
						"ImportTasksFolders", "ExchangeAutoSyncActivity"]
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
			 * @inheritDoc BPMSoft.BaseSyncSettingsTab#onSaved
			 * @overridden
			 */
			onSaved: function() {
				var config = {
					tabName: this.get("TabName"),
					values: {
						isSaved: true,
						exchangeAutoSynchronizationActivity: this.get("ExchangeAutoSyncActivity"),
						importAppointments: this.get("ImportAppointments"),
						importTasks: this.get("ImportTasks"),
						exportActivities: this.get("ExportActivities")
					}
				};
				this.set("TabSavedValuesConfig", config);
				this.callParent(arguments);
			},

			/**
			 * @inheritDoc BPMSoft.BaseSyncSettingsTab#getUpdateQuery
			 * @overridden
			 */
			getUpdateQuery: function() {
				var batchQuery = this.Ext.create("BPMSoft.BatchQuery");
				var updateActivitySettings = this.getUpdateQueryActivitySettings();
				var updateMailbox = this.getUpdateQueryMailbox();
				batchQuery.add(updateActivitySettings);
				batchQuery.add(updateMailbox);
				return batchQuery;
			},

			/**
			 * @inheritDoc BPMSoft.BaseSyncSettingsTab#getUpdateQueryMailbox
			 * @return {BPMSoft.UpdateQuery}
			 */
			getUpdateQueryMailbox: function() {
				var update = this.Ext.create("BPMSoft.UpdateQuery", {
					rootSchemaName: "MailboxSyncSettings"
				});
				var filters = update.filters;
				var mailboxSettingsId = this.get("MailboxSyncSettingsId");
				var idFilter = update.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
						"Id", mailboxSettingsId);
				filters.add("IdFilter", idFilter);
				update.setParameterValue("ExchangeAutoSyncActivity",
						this.get("ExchangeAutoSyncActivity"), this.BPMSoft.DataValueType.BOOLEAN);
				return update;
			},

			/**
			 * Generates update query for settings.
			 * @return {BPMSoft.UpdateQuery} Update query for settings.
			 */
			getUpdateQueryActivitySettings: function() {
				var update = this.Ext.create("BPMSoft.UpdateQuery", {
					rootSchemaName: this.entitySchemaName
				});
				var filters = update.filters;
				var settingsId = this.get("Id");
				var idFilter = update.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
					"Id", settingsId);
				filters.add("IdFilter", idFilter);
				const oldMeetingIntegration = BPMSoft.Features.getIsDisabled("NewMeetingIntegration");
				const isSynchronizedEnabled = this.get("ExchangeAutoSyncActivity"); 
				update.setParameterValue("ImportTasks",
					oldMeetingIntegration ? this.get("ImportTasks") : isSynchronizedEnabled, this.BPMSoft.DataValueType.BOOLEAN);
				update.setParameterValue("ImportTasksAll",
					oldMeetingIntegration ? this.get("ImportTasksAll") : isSynchronizedEnabled, this.BPMSoft.DataValueType.BOOLEAN);
				update.setParameterValue("ImportTasksFromFolders",
					this.get("ImportTasksFromFolders"), this.BPMSoft.DataValueType.BOOLEAN);
				update.setParameterValue("ImportTasksFolders",
					this.getSelectedFolders("ImportTasksFolders", "ImportTasksFromFolders"),
					this.BPMSoft.DataValueType.TEXT);
				update.setParameterValue("ImportAppointments",
					oldMeetingIntegration ?  this.get("ImportAppointments") : isSynchronizedEnabled, this.BPMSoft.DataValueType.BOOLEAN);
				update.setParameterValue("ImportAppointmentsAll",
					oldMeetingIntegration ? this.get("ImportAppointmentsAll") : isSynchronizedEnabled, this.BPMSoft.DataValueType.BOOLEAN);
				update.setParameterValue("ImpAppointmentsFromCalendars",
					this.get("ImpAppointmentsFromCalendars"), this.BPMSoft.DataValueType.BOOLEAN);
				update.setParameterValue("ImportAppointmentsCalendars",
					this.getSelectedFolders("ImportAppointmentsCalendars", "ImpAppointmentsFromCalendars"),
					this.BPMSoft.DataValueType.TEXT);
				update.setParameterValue("ExportActivities",
					oldMeetingIntegration ?  this.get("ExportActivities") : isSynchronizedEnabled, this.BPMSoft.DataValueType.BOOLEAN);
				update.setParameterValue("ExportActivitiesAll",
					oldMeetingIntegration ?  this.get("ExportActivitiesAll") : isSynchronizedEnabled, this.BPMSoft.DataValueType.BOOLEAN);
				update.setParameterValue("ExportActivitiesFromGroups",
					this.get("ExportActivitiesFromGroups"), this.BPMSoft.DataValueType.BOOLEAN);
				update.setParameterValue("ImportActivitiesFrom",
					this.get("ImportActivitiesFrom"), this.BPMSoft.DataValueType.DATE);
				update.setParameterValue("ExportActivitiesGroups",
					this.getSelectedFolders("ExportActivitiesGroups", "ExportActivitiesFromGroups"),
					this.BPMSoft.DataValueType.TEXT);
				update.setParameterValue("AppointmentLastSyncDate", null, this.BPMSoft.DataValueType.DATE);
				update.setParameterValue("ActivitySyncPeriod", this.$ActivitySyncPeriod.value , this.BPMSoft.DataValueType.GUID);
				return update;
			},

			/**
			 * Changes state of appointment radio group.
			 * @param {Boolean} value Flag import appointment.
			 */
			changeStateImportAppointmentRadioButtons: function(value) {
				if (!value) {
					this.set("ImportAppointmentsAll", true);
				}
				this.set("ImportAppointments", value);
			},

			/**
			 * Changes state of tasks radio group.
			 * @param {Boolean} value Flag import task.
			 */
			changeStateImportTasksRadioButtons: function(value) {
				if (!value) {
					this.set("ImportTasksAll", true);
				}
				this.set("ImportTasks", value);
			},

			/**
			 * Changes state of export activities radio group.
			 * @param {Boolean} value Flag export activity.
			 */
			changeStateExportActivitiesRadioButtons: function(value) {
				if (!value) {
					this.set("ExportActivitiesAll", true);
				}
				this.set("ExportActivities", value);
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
				this.on("change:ImportAppointmentsAll", this.onActivitySyncParametersChanged, this);
				this.on("change:ImportTasksAll", this.onActivitySyncParametersChanged, this);
				this.on("change:ExportActivitiesAll", this.onActivitySyncParametersChanged, this);
			},

			/**
			 * Unsubscribes for the events.
			 */
			unsubscribeViewModelEvents: function() {
				this.un("change:ImportAppointmentsAll", this.onActivitySyncParametersChanged, this);
				this.un("change:ImportTasksAll", this.onActivitySyncParametersChanged, this);
				this.un("change:ExportActivitiesAll", this.onActivitySyncParametersChanged, this);
			},

			/**
			 * Set import or export parameters if activity synhronization parameters was changed.
			 * @param {Object} model Backbone model.
			 * @param {Boolean} value Value element flag.
			 */
			onActivitySyncParametersChanged: function(model, value) {
				var changedProperties = Object.getOwnPropertyNames(model.changed);
				if (!this.Ext.isEmpty(changedProperties)) {
					var changeProperty = changedProperties[0];
					switch (changeProperty) {
						case "ImportAppointmentsAll":
							this.set("ImpAppointmentsFromCalendars", !value);
							break;
						case "ImportTasksAll":
							this.set("ImportTasksFromFolders", !value);
							break;
						case "ExportActivitiesAll":
							this.set("ExportActivitiesFromGroups", !value);
							break;
						default :
							break;
					}
				}
			},

			/**
			 * @inheritDoc BPMSoft.BaseSyncSettingsTab#getFolderParameters
			 * @overridden
			 */
			getFolderParameters: function() {
				return [
					{
						foldersCollectionName: "FoldersGridData",
						folderClassName: ExchangeNuiConstants.ExchangeFolder.AppointmentClass.Name,
						nameOfFolders: "ImportAppointmentsCalendars",
						selectedRows: "SelectedRows"
					},
					{
						foldersCollectionName: "TasksFoldersGridData",
						folderClassName: ExchangeNuiConstants.ExchangeFolder.TaskClass.Name,
						nameOfFolders: "ImportTasksFolders",
						selectedRows: "TasksSelectedRows"
					},
					{
						foldersCollectionName: "ExportFoldersGridData",
						folderClass: ExchangeNuiConstants.ExchangeFolder.BPMActivity,
						nameOfFolders: "ExportActivitiesGroups",
						selectedRows: "ExportSelectedRows"
					}
				];
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
					"bindTo": "ExchangeAutoSyncActivity",
					"controlConfig": {
						"className": "BPMSoft.ToggleEdit"
					},
					"wrapClass": ["settings-page-reverse-toggle-edit"],
					"visible": {"bindTo": "CanAddCalendar"}
				}
			},
			{
				"operation": "insert",
				"name": "DisabledExchangeAutoSynchronization",
				"parentName": "SyncContainer",
				"propertyName": "items",
				"values": {
					"caption": {"bindTo": "Resources.Strings.ExchangeAutoSynchronization"},
					"bindTo": "ExchangeAutoSyncActivity",
					"controlConfig": {
						"className": "BPMSoft.ToggleEdit"
					},
					"wrapClass": ["settings-page-reverse-toggle-edit"],
					"tip": {
						"content": {"bindTo": "Resources.Strings.ActiveCalendarDialogMessage"},
						"style": BPMSoft.controls.TipEnums.style.WHITE
					},
					"visible": {
						"bindTo": "CanAddCalendar",
						"bindConfig": {"converter": "invertBooleanValue"}
					},
					"enabled": false
				}
			},
			{
				"operation": "insert",
				"name": "ActivitySyncPeriod",
				"parentName": "SyncContainer",
				"propertyName": "items",
				"values": {
					"className": "BPMSoft.ComboBoxEdit",
					"dataValueType": BPMSoft.DataValueType.ENUM,
					"bindTo": "ActivitySyncPeriod",
					"wrapClass": ["settings-page-import-from-period"]
				}
			},
			{
				"operation": "insert",
				"name": "ImportContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"visible": { "bindTo": "OldMeetingIntegration" },
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "ImportAppointments",
				"parentName": "ImportContainer",
				"propertyName": "items",
				"index": 0,
				"values": {
					"bindTo": "ImportAppointments",
					"controlConfig": {
						"checkedchanged": {"bindTo": "changeStateImportAppointmentRadioButtons"},
						"className": "BPMSoft.ToggleEdit"
					},
					"wrapClass": ["settings-page-reverse-toggle-edit"]
				}
			},
			{
				"operation": "insert",
				"name": "ImportAppointmentsRadioGroup",
				"parentName": "ImportContainer",
				"propertyName": "items",
				"index": 1,
				"values": {
					"itemType": BPMSoft.ViewItemType.RADIO_GROUP,
					"value": {"bindTo": "ImportAppointmentsAll"},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "ImportAppointmentsAll",
				"parentName": "ImportAppointmentsRadioGroup",
				"propertyName": "items",
				"values": {
					"caption": {"bindTo": "Resources.Strings.LoadAllAppointments"},
					"enabled": {"bindTo": "ImportAppointments"},
					"value": true
				}
			},
			{
				"operation": "insert",
				"name": "ImpAppointmentsFromCalendars",
				"parentName": "ImportAppointmentsRadioGroup",
				"propertyName": "items",
				"values": {
					"caption": {"bindTo": "Resources.Strings.LoadAppointmentsFromCalendars"},
					"enabled": {"bindTo": "ImportAppointments"},
					"value": false
				}
			},
			{
				"operation": "insert",
				"parentName": "ImportContainer",
				"propertyName": "items",
				"name": "ImportAppointmentsGridContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"visible": {"bindTo": "ImpAppointmentsFromCalendars"},
					"items": []
				}
			},
			{
				"operation": "move",
				"parentName": "ImportAppointmentsGridContainer",
				"propertyName": "items",
				"name": "FoldersGrid",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "ImportTasks",
				"parentName": "ImportContainer",
				"propertyName": "items",
				"values": {
					"bindTo": "ImportTasks",
					"controlConfig": {
						"checkedchanged": {"bindTo": "changeStateImportTasksRadioButtons"},
						"className": "BPMSoft.ToggleEdit"
					},
					"wrapClass": ["settings-page-reverse-toggle-edit"]
				}
			},
			{
				"operation": "insert",
				"name": "ImportTasksRadioGroup",
				"parentName": "ImportContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.RADIO_GROUP,
					"value": {"bindTo": "ImportTasksAll"},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "ImportTasksAll",
				"parentName": "ImportTasksRadioGroup",
				"propertyName": "items",
				"values": {
					"caption": {"bindTo": "Resources.Strings.LoadAllTasks"},
					"enabled": {"bindTo": "ImportTasks"},
					"value": true
				}
			},
			{
				"operation": "insert",
				"name": "ImportTasksFromFolders",
				"parentName": "ImportTasksRadioGroup",
				"propertyName": "items",
				"values": {
					"caption": {"bindTo": "Resources.Strings.LoadTasksFromFolders"},
					"enabled": {"bindTo": "ImportTasks"},
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
					"visible": {"bindTo": "ImportTasksFromFolders"},
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "ImportGridContainer",
				"propertyName": "items",
				"name": "TasksFoldersGrid",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID,
					"hierarchical": true,
					"multiSelect": {"bindTo": "IsMultiSelect"},
					"primaryColumnName": "Id",
					"collection": {"bindTo": "TasksFoldersGridData"},
					"hierarchicalColumnName": "ParentId",
					"expandHierarchyLevels": {"bindTo": "ExpandHierarchyFrom"},
					"activeRow": {bindTo: "ActiveRow"},
					"selectedRows": {bindTo: "TasksSelectedRows"},
					"selectRow": {"bindTo": "onItemFocused"},
					"type": "listed",
					"listedConfig": {
						"name": "TasksFoldersGridListedConfig",
						"items": [
							{
								name: "TasksFolderNameListedGridColumn",
								bindTo: "Name",
								position: {column: 1, colSpan: 24}
							}
						]
					},
					tiledConfig: {
						name: "TasksFoldersGridTiledConfig",
						grid: {
							columns: 24,
							rows: 1
						},
						items: [
							{
								name: "TasksFolderNameTiledGridColumn",
								bindTo: "Name",
								position: {row: 1, column: 1, colSpan: 24}
							}
						]
					}
				}
			},
			{
				"operation": "insert",
				"name": "ExportContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"visible": { "bindTo": "OldMeetingIntegration" },
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "ExportActivities",
				"parentName": "ExportContainer",
				"propertyName": "items",
				"index": 0,
				"values": {
					"bindTo": "ExportActivities",
					"controlConfig": {
						"checkedchanged": {"bindTo": "changeStateExportActivitiesRadioButtons"},
						"className": "BPMSoft.ToggleEdit"
					},
					"wrapClass": ["settings-page-reverse-toggle-edit"]
				}
			},
			{
				"operation": "insert",
				"name": "ExportActivitiesRadioGroup",
				"parentName": "ExportContainer",
				"propertyName": "items",
				"index": 1,
				"values": {
					"itemType": BPMSoft.ViewItemType.RADIO_GROUP,
					"value": {"bindTo": "ExportActivitiesAll"},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "ExportActivitiesAll",
				"parentName": "ExportActivitiesRadioGroup",
				"propertyName": "items",
				"values": {
					"caption": {"bindTo": "Resources.Strings.ExportActivitiesAllCaption"},
					"enabled": {"bindTo": "ExportActivities"},
					"value": true
				}
			},
			{
				"operation": "insert",
				"name": "ExportActivitiesFromGroups",
				"parentName": "ExportActivitiesRadioGroup",
				"propertyName": "items",
				"values": {
					"caption": {"bindTo": "Resources.Strings.ExportActivitiesFromGroupsCaption"},
					"enabled": {"bindTo": "ExportActivities"},
					"value": false
				}
			},
			{
				"operation": "insert",
				"parentName": "ExportContainer",
				"propertyName": "items",
				"name": "ExportGridContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"visible": {"bindTo": "ExportActivitiesFromGroups"},
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
