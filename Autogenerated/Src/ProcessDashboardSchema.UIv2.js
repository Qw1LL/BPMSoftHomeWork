/**
 * Parent BaseNotificationSchema
 */
define("ProcessDashboardSchema",
	[
		"ProcessDashboardSchemaResources",
		"ConfigurationConstants",
		"RemindingsUtilities",
		"FormatUtils",
		"DesktopPopupNotification",
		"BaseFiltersGenerateModule",
		"DcmElementSchemaManager",
		"EmptyGridMessageConfigBuilder",
		"QuickFilterModuleV2",
		"css!ProcessDashboardModule"
	],
	function(resources, ConfigurationConstants, RemindingsUtilities, FormatUtils, DesktopNotification,
			 BaseFiltersGenerateModule) {
		const NotificationDisplayMode = {
			All: 0,
			Personal: 1,
			Group: 2
		};
		return {
			entitySchemaName: "SysProcessElementToDo",
			messages: {
				/**
				 * @message ProcessDashboardCounterChanged
				 * Updates new items count in process dashboard panel.
				 */
				"ProcessDashboardCounterChanged": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message CommunicationPanelItemSelected
				 * Notify about change selected right panel item.
				 */
				"CommunicationPanelItemSelected": {
					"mode": BPMSoft.MessageMode.BROADCAST,
					"direction": BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},
			attributes: {
				/**
				 * Flag that indicates when to show future tasks.
				 */
				"FutureTaskFilter": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"caption": resources.localizableStrings.FutureTaskFilter,
					"value": false
				},
				/**
				 * Count of today notifications.
				 */
				"Counter": {
					"dataValueType": this.BPMSoft.DataValueType.INTEGER,
					"value": 0
				},

				/**
				 * Desktop notification timeout.
				 */
				"DesktopNotificationTimeout": {
					"dataValueType": this.BPMSoft.DataValueType.INTEGER,
					"value": 5000
				},

				/**
				 * The maximum value of the counter to display.
				 * @type {Number}
				 */
				"MaxCounter": {
					"dataValueType": BPMSoft.DataValueType.INTEGER,
					"value": 99
				},

				/**
				 * Allowed display modes.
				 */
				"DisplayModes": {
					dataValueType: BPMSoft.DataValueType.COLLECTION,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Current display mode.
				 */
				"DisplayMode": {
					dataValueType: BPMSoft.DataValueType.ENUM,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true
				},

				/**
				 * Owner actions button menu items.
				 */
				"OwnerActionsButtonMenu": {
					"dataValueType": this.BPMSoft.DataValueType.COLLECTION,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": this.Ext.create("BPMSoft.BaseViewModelCollection")
				}
			},
			properties: {
				orderingColumnName: "StartDate"
			},
			methods: {

				// region Methods: Private

				/**
				 * Handles when web-socket message received.
				 * @private
				 * @param {Object} scope Current view model.
				 * @param {Object} response Response object.
				 */
				_onServerMessageReceived: function(scope, response) {
					if (response && response.Header.Sender === "ProcessDashboard") {
						var item = Ext.decode(response.Body);
						switch (item.operation) {
							case "update":
								this._onServerUpdateMessageReceived(item.recordId);
								break;
							case "delete":
								this._onServerDeleteMessageReceived(item.recordId);
								break;
							default:
								throw new BPMSoft.UnsupportedTypeException();
						}
					}
				},

				/**
				 * Shows notification and updates counter.
				 * @private
				 * @param {Object} item Notification item.
				 * @param {Boolean} isExistingItem Flag tat indicates existing item.
				 */
				_showNotification: function(item, isExistingItem) {
					const startDate = item.get("StartDate");
					const config = this._getDesktopNotificationConfig(item);
					let counter = this.get("Counter");
					let isTodayTask = startDate < BPMSoft.endOfToday();
					if (isTodayTask || this.get("FutureTaskFilter")) {
						DesktopNotification.show(config);
					}
					if (isTodayTask !== isExistingItem) {
						counter += (isExistingItem ? -1 : 1);
					}
					this._updateCounter(counter);
				},

				/**
				 * Handles when "update" web-socket message received.
				 * @private
				 * @param {String} recordId Record identifier.
				 * @param {Function} callback The callback function.
				 * @param {Object} scope The callback execution context.
				 */
				_onServerUpdateMessageReceived: function(recordId, callback, scope) {
					var notifications = this.get("Notifications");
					var isExistingItem = notifications.contains(recordId);
					this.loadNotification(recordId, function(response) {
						var notification = response.collection.first();
						if (notification) {
							this._showNotification(notification, isExistingItem);
						} else {
							this._onServerDeleteMessageReceived(recordId);
						}
						Ext.callback(callback, scope, [response]);
					}, this);
				},

				/**
				 * Handles when "delete" web-socket message received.
				 * @private
				 * @param {String} recordId Record identifier.
				 */
				_onServerDeleteMessageReceived: function(recordId) {
					this._removeNotificationAndUpdateCounter(recordId);
				},

				/**
				 * @private
				 */
				_removeNotificationAndUpdateCounter: function(recordId) {
					const notification = this._removeNotification(recordId);
					if (notification) {
						const startDate = notification.get("StartDate");
						if (startDate < BPMSoft.endOfToday()) {
							const counter = this.get("Counter") - 1;
							this._updateCounter(counter);
						}
					}
				},

				/**
				 * Returns unprocessed notifications count select.
				 * @private
				 * @return {BPMSoft.data.queries.EntitySchemaQuery}
				 */
				_getCountersSelect: function() {
					var esq = new BPMSoft.EntitySchemaQuery();
					esq.rootSchemaName = this.entitySchemaName;
					esq.addAggregationSchemaColumn("Id", BPMSoft.AggregationType.COUNT, "Counter");
					var group = this.Ext.create("BPMSoft.FilterGroup");
					group.add("Performer", this._getPerformerFilters());
					group.add("StartDate", this._createStartDateFilter());
					esq.filters.add(group);
					return esq;
				},

				/**
				 * Initializes "FutureTaskFilter" attribute from user profile.
				 * @private
				 * @param {Function} [callback] The callback function.
				 * @param {Object} [scope] The callback execution context.
				 */
				_initFutureTaskFilterFromUserProfile: function(callback, scope) {
					var profile = this.getProfile();
					var value = profile.FutureTaskFilter;
					if (Ext.isDefined(value)) {
						this.set("FutureTaskFilter", value);
					}
					this.on("change:FutureTaskFilter", this._onFutureTaskFilterChange, this);
					Ext.callback(callback, scope);
				},

				/**
				 * @private
				 */
				_initDisplayMode: function(callback, scope) {
					const profile = this.getProfile();
					const mode = profile.DisplayMode || NotificationDisplayMode.All;
					this.set("DisplayMode", this._getDisplayModeItem(mode));
					this.set("DisplayModes", Ext.create("BPMSoft.Collection"));
					Ext.callback(callback, scope);
				},

				/**
				 * @private
				 */
				_onDisplayModeChanged: function(mode) {
					if (this.$DisplayMode.value === mode.value) {
						return;
					}
					const profile = this.get("Profile");
					const key = this.getProfileKey();
					this.$DisplayMode = mode;
					profile.DisplayMode = mode.value;
					BPMSoft.utils.saveUserProfile(key, profile, false, this._reloadNotifications, this);
				},

				/**
				 * @private
				 */
				_getDisplayModeItem: function(mode) {
					let displayValue = mode;
					BPMSoft.each(NotificationDisplayMode, function(value, modeName){
						if (value === mode) {
							const resourceKey = Ext.String.format("DisplayMode_{0}_Caption", modeName);
							displayValue = resources.localizableStrings[resourceKey];
						}
					});
					return {value: mode, displayValue: displayValue};
				},

				/**
				 * @private
				 */
				_prepareDisplayModeList: function(filter, list) {
					if (!list) {
						return;
					}
					const items = Ext.create("BPMSoft.Collection");
					BPMSoft.each(NotificationDisplayMode, function(mode){
						items.add(mode, this._getDisplayModeItem(mode));
					}, this);
					list.clear();
					list.loadAll(items);
				},

				/**
				 * @private
				 */
				_getCanSelectDisplayMode: function(){
					return BPMSoft.Features.getIsEnabled("UseProcessPerformerAssignment");
				},

				/**
				 * Handles future task filter changes.
				 * @private
				 */
				_onFutureTaskFilterChange: function() {
					this._saveFutureTaskFilterInUserProfile();
					this._reloadNotifications();
				},

				/**
				 * Shows mask above the notifications container.
				 * @private
				 * @return {String} Mask identifier.
				 */
				_showMask: function() {
					var maskId = this.BPMSoft.Mask.show({
						selector: ".process-notifications-container",
						timeout: 0,
						opacity: 1
					});
					return maskId;
				},

				/**
				 * Reloads notifications and counter.
				 * @private
				 */
				_reloadNotifications: function(callback, scope) {
					var maskId = this._showMask();
					this._loadCounters(function() {
						this.loadNotifications(true, function() {
							this.BPMSoft.Mask.hide(maskId);
							Ext.callback(callback, scope);
						}, this);
					}, this);
				},

				/**
				 * Saves filter in user profile.
				 * @private
				 */
				_saveFutureTaskFilterInUserProfile: function() {
					var profile = this.get("Profile");
					var key = this.getProfileKey();
					profile.FutureTaskFilter = this.get("FutureTaskFilter");
					BPMSoft.utils.saveUserProfile(key, profile, false);
				},

				/**
				 * Returns desktop notification config.
				 * @private
				 * @param {BPMSoft.Entity} notification Notification.
				 */
				_getDesktopNotificationConfig: function(notification) {
					return {
						id: notification.get("Id"),
						title: notification.get("Title") || notification.get("SchemaName"),
						body: notification.get("Subject"),
						icon: this._getIcon(notification),
						onClick: this.onDesktopNotificationClick,
						ignorePageVisibility: true,
						timeout: this.get("DesktopNotificationTimeout"),
						scope: this
					};
				},

				/**
				 * Removes notification by record identifier.
				 * @private
				 * @param {Striong} recordId Notification identifier.
				 * @return {Object} Removed notification.
				 */
				_removeNotification: function(recordId) {
					var notifications = this.get("Notifications");
					return notifications.removeByKey(recordId);
				},

				/**
				 * Returns process user task image config.
				 * @private
				 * @param {String} schemaName User task schema name.
				 * @param {String} imageName Image name.
				 * @return {Object} Image config.
				 */
				_getImageConfig: function(schemaName, imageName) {
					return {
						source: BPMSoft.ImageSources.PROCESS_USERTASK_SCHEMA,
						params: {
							resourceItemName: imageName,
							schemaName: schemaName
						}
					};
				},

				/**
				 * Updates unprocessed notifications counter.
				 * @private
				 * @param {Number} counter Notifications count.
				 */
				_updateCounter: function(counter) {
					counter = Math.max(counter, 0);
					this.set("Counter", counter);
					var maxCounter = this.get("MaxCounter");
					counter = counter > maxCounter
						? maxCounter + "+"
						: counter;
					this.sandbox.publish("ProcessDashboardCounterChanged", counter || "");
				},

				/**
				 * Adds current entity schema columns to select
				 * @param {BPMSoft.EntitySchemaQuery} select
				 * @private
				 */
				_addColumns: function(select) {
					select.addColumn("Id");
					select.addColumn("ContactId");
					select.addColumn("GroupId");
					select.addColumn("Title");
					select.addColumn("Subject");
					select.addColumn("[SysSchema:UId:ElementSchemaUId].Name", "SchemaName");
					select.addColumn("StartDate");
				},

				/**
				 * Returns image url by specified user task schema name and image name.
				 * @private
				 * @param {String} schemaName User task schema name.
				 * @param {String} imageName Image name.
				 * @return {String}
				 */
				_getImage: function(schemaName, imageName) {
					var imageConfig = schemaName
						? this._getImageConfig(schemaName, imageName)
						: this.get("Resources.Images.Default");
					return this.BPMSoft.ImageUrlBuilder.getUrl(imageConfig);
				},

				/**
				 * Returns desktop notification *.png icon url.
				 * @private
				 * @param {Object} notification Notification.
				 * @return {String}
				 */
				_getIcon: function(notification) {
					var schemaName = notification.get("SchemaName");
					return this._getImage(schemaName, "NotificationImage.png");
				},

				/**
				 * Sets "StartDate" column order.
				 * @private
				 * @param {BPMSoft.EntitySchemaQuery} select Select query.
				 */
				_setOrderByStartDate: function(select) {
					var startDate = select.columns.get("StartDate");
					startDate.orderDirection = this.BPMSoft.OrderDirection.DESC;
				},

				/**
				 * Returns start date less or equal to current end day filter
				 * @private
				 * @return {BPMSoft.data.filters.CompareFilter}
				 */
				_createStartDateFilter: function() {
					return BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.LESS_OR_EQUAL, "StartDate", BPMSoft.endOfToday());
				},

				/**
				 * Returns current contact filter.
				 * @private
				 * @return {BPMSoft.data.filters.CompareFilter}
				 */
				_createContactFilter: function() {
					return BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "ContactId", BPMSoft.SysValue.CURRENT_USER_CONTACT.value);
				},

				/**
				 * Publishes "ProcessExecDataChanged" message.
				 * @private
				 * @param {String} processElementId Process element identifier.
				 */
				_onProcessExecDataChanged: function(processElementId) {
					this.sandbox.publish("ProcessExecDataChanged", {
						procElUId: processElementId
					});
				},

				/**
				 * Handles when web-socket channel opened. Reloads counter and notifications.
				 * @private
				 */
				_onServerChannelInitialized: function() {
					this._reloadNotifications();
				},

				/**
				 * Subscribes on server channels events.
				 * @private
				 */
				_subscribeOnServerChannelEvents: function() {
					this.BPMSoft.ServerChannel.on(BPMSoft.EventName.ON_CONNECTION_INITIALIZED,
						this._onServerChannelInitialized, this);
					this.BPMSoft.ServerChannel.on(BPMSoft.EventName.ON_MESSAGE,
						this._onServerMessageReceived, this);
				},

				/**
				 * Loads new notifications
				 * @private
				 * @param {Function} [callback] The callback function.
				 * @param {Object} [scope] The callback execution context.
				 */
				_loadNewNotifications: function(callback, scope) {
					this.loadNotifications(true, callback, scope);
				},

				/**
				 * Loads and display unprocessed today notifications.
				 * @private
				 * @param {Function} [callback] The callback function.
				 * @param {Object} [scope] The callback execution context.
				 */
				_loadCounters: function(callback, scope) {
					var select = this._getCountersSelect();
					select.getEntityCollection(function(response) {
						var collection = response.collection;
						var entity = collection.first();
						if (entity) {
							var counter = entity.get("Counter");
							this._updateCounter(counter);
						}
						Ext.callback(callback, scope);
					}, this);
				},

				/**
				 * Handles the panel menu item selection event.
				 * @private
				 * @param {Object} itemConfig Menu item config.
				 */
				_onCommunicationPanelItemSelected: function(itemConfig) {
					if (itemConfig.moduleName === "ProcessDashboardModule") {
						this._reloadNotifications();
					}
				},

				/**
				 * Subscribes on sandbox events.
				 * @private
				 */
				_subscribeOnSandboxEvents: function() {
					this.sandbox.subscribe("CommunicationPanelItemSelected",
						this._onCommunicationPanelItemSelected, this);
				},

				/**
				 * @private
				 */
				_getPerformerFilters: function() {
					const displayMode = this.$DisplayMode.value;
					const filters = BPMSoft.createFilterGroup();
					filters.logicalOperation = BPMSoft.LogicalOperatorType.OR;
					if (displayMode === NotificationDisplayMode.All ||
							displayMode === NotificationDisplayMode.Personal){
						filters.add("Contact", this._createContactFilter());
					}
					if (displayMode === NotificationDisplayMode.All ||
							displayMode === NotificationDisplayMode.Group){
						const groupFilters = BPMSoft.createFilterGroup();
						groupFilters.add("contact", BPMSoft.createColumnIsNullFilter("ContactId"));
						groupFilters.add("groupFilter", this._getPerformerFilterGroup());
						filters.add("Group", groupFilters);
					}
					return filters;
				},

				/**
				 * @private
				 */
				_getPerformerFilterGroup: function() {
					const filters = BPMSoft.createFilterGroup();
					const adminUnitRoleFilter = BPMSoft.createExistsFilter(
						"[SysAdminUnitInRole:SysAdminUnitRoleId:GroupId].Id");
					adminUnitRoleFilter.subFilters.addItem(BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "SysAdminUnit", BPMSoft.SysValue.CURRENT_USER.value));
					filters.add("adminUnitRole", adminUnitRoleFilter);
					filters.add("assignmentGroupType", BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "GroupType",
						BPMSoft.process.UserTaskAssignmentGroupType.AdminUnitRole));
					return filters;
				},

				/**
				 * @private
				 */
				_initOwnerActionsButtonMenu: function(callback, scope) {
					const menu = this.get("OwnerActionsButtonMenu");
					const collection = Ext.create("BPMSoft.BaseViewModelCollection");
					collection.addItem(this.getButtonMenuItem({
						"Caption": resources.localizableStrings.OwnerActionExecuteCaption,
						"Click": {"bindTo": "_ownerActionAssignToMe"},
						"Tag": true
					}));
					collection.addItem(this.getButtonMenuItem({
						"Caption": resources.localizableStrings.OwnerActionAssignToMeCaption,
						"Click": {"bindTo": "_ownerActionAssignToMe"},
						"Tag": false
					}));
					collection.addItem(this.getButtonMenuItem({
						"Caption": resources.localizableStrings.OwnerActionAssignCaption,
						"Click": {"bindTo": "_ownerActionAssign"}
					}));
					menu.clear();
					menu.loadAll(collection);
					Ext.callback(callback, scope);
				},

				/**
				 * @private
				 */
				_ownerActionAssignToMe: function(isNeedToExecute) {
					const newContactId = BPMSoft.SysValue.CURRENT_USER_CONTACT.value;
					if (this.$ContactId === newContactId) {
						return;
					}
					BPMSoft.ChangeProcessElementStateRequest.assignPerformer(this.$Id, newContactId,
						function(response) {
							if (response.success) {
								this.$ContactId = newContactId;
								if (isNeedToExecute) {
									this.onTitleClick();
								}
							}
						}, this);
				},

				/**
				 * @private
				 */
				_ownerActionAssign: function() {
					const lookupCallback = function(result) {
						const newContact = result && result.selectedRows.first();
						if (!newContact || this.$ContactId === newContact.Id) {
							return;
						}
						if (newContact.Id === BPMSoft.SysValue.CURRENT_USER_CONTACT.value) {
							this._ownerActionAssignToMe(false);
							return;
						}
						BPMSoft.ChangeProcessElementStateRequest.assignPerformer(this.$Id, newContact.Id,
							function(response) {
								if (response.success) {
									this._removeNotificationAndUpdateCounter.call(this.parentViewModel, this.$Id);
								}
							}, this);
					};
					const lookupConfig = {
						entitySchemaName: "Contact",
						captionLookup: resources.localizableStrings.OwnerLookupCaption,
						actionsButtonVisible: false
					};
					lookupConfig.filters = BaseFiltersGenerateModule.UsersInRoleFilter(this.$GroupId);
					this.openLookup(lookupConfig, lookupCallback, this);
				},

				/**
				 * @private
				 */
				_isActionsButtonVisible: function() {
					return this._isUseProcessPerformerAssignment() && BPMSoft.isEmpty(this.$ContactId);
				},

				/**
				 * @private
				 */
				_isUseProcessPerformerAssignment: function() {
					return this.getIsFeatureEnabled("UseProcessPerformerAssignment");
				},

				/**
				 * @private
				 */
				_getPerformerTypeImage: function() {
					const imageConfig = Ext.isEmpty(this.$ContactId)
						? this.get("Resources.Images.OwnerRoleIcon")
						: this.get("Resources.Images.OwnerIcon");
					return BPMSoft.ImageUrlBuilder.getUrl(imageConfig);
				},

				// endregion

				// region Methods: Protected

				/**
				 * @inheritdoc BPMSoft.BaseNotificationSchema#init
				 * @overridden
				 */
				init: function(callback, scope) {
					DesktopNotification.requestPermission();
					this.setDefaultValues(scope);
					BPMSoft.chain(
						this.setEmptyMessageConfig,
						this.initializeProfile,
						this._initFutureTaskFilterFromUserProfile,
						this._initDisplayMode,
						this._loadCounters,
						this._loadNewNotifications,
						this._initOwnerActionsButtonMenu,
						function() {
							this._subscribeOnSandboxEvents();
							this._subscribeOnServerChannelEvents();
							callback.call(scope);
						},
						this
					);
				},

				/**
				 * @inheritdoc BPMSoft.BaseNotificationsSchema#unSubscribeEvents
				 * @overridden
				 */
				unSubscribeEvents: function() {
					BPMSoft.ServerChannel.un(BPMSoft.EventName.ON_MESSAGE, this._onServerMessageReceived, this);
					BPMSoft.ServerChannel.un(BPMSoft.EventName.ON_CONNECTION_INITIALIZED,
						this._onServerChannelInitialized, this);
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#getProfileKey
				 * @overridden
				 */
				getProfileKey: function() {
					return "ProcessDashboardProfile";
				},

				/**
				 * Returns notification *.svg image url.
				 * @protected
				 * @return {String}
				 */
				getImage: function() {
					var schemaName = this.get("SchemaName");
					return this._getImage(schemaName, "SmallSvgImage.svg");
				},

				/**
				 * @inheritdoc BPMSoft.BaseNotificationsSchema#addColumns
				 * @overridden
				 */
				addColumns: function(select) {
					this._addColumns(select);
					this._setOrderByStartDate(select);
				},

				/**
				 * @inheritdoc BPMSoft.BaseNotificationsSchema#getNotificationsSelectFilters
				 * @overridden
				 */
				getNotificationsSelectFilters: function() {
					var filters = BPMSoft.createFilterGroup();
					var showTodayTasks = !this.get("FutureTaskFilter");
					filters.add("Performer", this._getPerformerFilters());
					if (showTodayTasks) {
						filters.add("StartDate", this._createStartDateFilter());
					}
					return filters;
				},

				/**
				 * Returns notification date and time.
				 * @protected
				 * @return {String} Date and time.
				 */
				getStartDate: function() {
					return FormatUtils.smartFormatDate({
						dateValue: this.get("StartDate"),
						hasTimezoneOffset: true
					});
				},

				/**
				 * Handle process dashboard item click. Shows process element execution page.
				 * @protected
				 */
				onTitleClick: function() {
					var value = this.get("Id");
					this._onProcessExecDataChanged(value);
				},

				/**
				 * Handle desktop notification click. Shows process element execution page.
				 * @protected
				 * @param {Object} event Click event.
				 */
				onDesktopNotificationClick: function(event) {
					window.focus();
					var notification = event.target;
					var value = notification.tag;
					this._onProcessExecDataChanged(value);
				},

				/**
				 * @protected
				 */
				getTitleOrDefault: function(title) {
					return title || this.get("SchemaName");
				},

				/**
				 * Selects current process dashboard item.
				 * @protected
				 */
				selectNotificationItemOnActionButtonClick: function() {
					this.parentViewModel.set("ActiveItem", this.get("Id"));
				}

				// endregion
			},
			diff: [
				{
					"operation": "insert",
					"name": "FiltersContainer",
					"propertyName": "items",
					"index": 0,
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["process-filters-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "FiltersContainer",
					"propertyName": "items",
					"name": "FilterButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"imageConfig": {"bindTo": "Resources.Images.Filter"},
						"visible": false,
						"classes": {
							"wrapperClass": ["process-filter-button"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "FiltersContainer",
					"propertyName": "items",
					"name": "DisplayMode",
					"values": {
						"contentType": BPMSoft.ContentType.ENUM,
						"controlConfig": {
							"prepareList": { "bindTo": "_prepareDisplayModeList" },
							"change": { "bindTo": "_onDisplayModeChanged" },
							"list": { "bindTo": "DisplayModes" }
						},
						"labelConfig": {
							"visible": false
						},
						"wrapClass": ["no-caption-control"],
						"visible": {"bindTo": "_getCanSelectDisplayMode"}
					}
				},
				{
					"operation": "insert",
					"name": "FutureTaskFilter",
					"parentName": "FiltersContainer",
					"propertyName": "items",
					"values": {
						"wrapClass": ["t-checkbox-control", "future-task-mode-checkbox"],
						"contentType": this.BPMSoft.ContentType.BOOLEAN
					}
				},
				{
					"operation": "merge",
					"name": "NotificationsContainer",
					"index": 1,
					"values": {
						"observableRowNumber": 2,
						"classes": {
							"wrapClassName": [
								"process-notifications-container",
								"ts-notifications-container",
								"ts-notificationsmodule-container"
							]
						}
					}
				},
				{
					"operation": "insert",
					"name": "ProcessDashboardContainer",
					"parentName": "Notification",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": [
							"process-notification-item-container",
							"reminder-notification-activity-item-container"
						],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ImageContainer",
					"parentName": "ProcessDashboardContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["process-notification-item-image-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "StartDateContainer",
					"parentName": "ProcessDashboardContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["process-notification-item-body-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ActionsContainer",
					"parentName": "ProcessDashboardContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["process-notification-item-actions-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "PerformerTypeImageContainer",
					"parentName": "ProcessDashboardContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["process-notification-item-image-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "TitleContainer",
					"parentName": "ProcessDashboardContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["process-notification-item-body-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "SubjectContainer",
					"parentName": "ProcessDashboardContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["process-notification-item-body-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ProcessElementImage",
					"parentName": "ImageContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.COMPONENT,
						"className": "BPMSoft.ImageView",
						"imageSrc": {"bindTo": "getImage"},
						"classes": {"wrapClass": ["reminder-notification-icon-class"]}
					}
				},
				{
					"operation": "insert",
					"name": "StartDate",
					"parentName": "StartDateContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "getStartDate"},
						"classes": {"labelClass": ["subject-text-labelClass, start-date-labelClass"]}
					}
				},
				{
					"operation": "insert",
					"parentName": "ActionsContainer",
					"propertyName": "items",
					"name": "ActionsButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT_ORANGE,
						"caption": {"bindTo": "Resources.Strings.OwnerActionsButtonCaption"},
						"classes": {
							"wrapperClass": ["owner-action-button-class"]
						},
						"prepareMenu": {"bindTo": "selectNotificationItemOnActionButtonClick"},
						"menu": {
							"items": {"bindTo": "OwnerActionsButtonMenu"}
						},
						"visible": {"bindTo": "_isActionsButtonVisible"}
					}
				},
				{
					"operation": "insert",
					"name": "PerformerTypeImage",
					"parentName": "PerformerTypeImageContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.COMPONENT,
						"className": "BPMSoft.ImageView",
						"imageSrc": {"bindTo": "_getPerformerTypeImage"},
						"classes": {"wrapClass": ["reminder-notification-icon-class"]},
						"visible": {"bindTo": "_isUseProcessPerformerAssignment"}
					}
				},
				{
					"operation": "insert",
					"name": "Title",
					"parentName": "TitleContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.HYPERLINK,
						"caption": {
							"bindTo": "Title",
							"bindConfig": {
								"converter": "getTitleOrDefault"
							}
						},
						"click": {"bindTo": "onTitleClick"},
						"classes": {
							"hyperlinkClass": ["title-text-labelClass"]
						},
						"canExecute": {"bindTo": "canBeDestroyed"}
					}
				},
				{
					"operation": "insert",
					"name": "Subject",
					"parentName": "SubjectContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "Subject"},
						"classes": {"labelClass": ["subject-text-labelClass"]}
					}
				}
			]
		};
	});
