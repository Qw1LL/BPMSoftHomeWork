define("BaseNotificationsSchema", ["BaseNotificationsSchemaResources", "NetworkUtilities", "ProcessModuleUtilities",
		"FormatUtils", "ConfigurationConstants", "PanelEmptyListMixin", "CheckModuleDestroyMixin"],
	function(resources, NetworkUtilities, ProcessModuleUtilities, FormatUtils,
			 ConfigurationConstants) {
		return {
			entitySchemaName: "Reminding",
			mixins: {
				PanelEmptyListMixin: "BPMSoft.PanelEmptyListMixin",
				CheckModuleDestroyMixin: "BPMSoft.CheckModuleDestroyMixin"
			},
			messages: {
				/**
				 * @message MarkNewNotificationsAsRead
				 * Notify about the need to mark all new notifications as read.
				 */
				"MarkNewNotificationsAsRead": {
					"mode": BPMSoft.MessageMode.PTP,
					"direction": BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message UpdateCounters
				 * Notify about the need to update counters.
				 */
				"UpdateCounters": {
					"mode": BPMSoft.MessageMode.BROADCAST,
					"direction": BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message UpdateCounterValues
				 * Notify about changes in the some notification counter group.
				 */
				"UpdateCounterValues": {
					"mode": BPMSoft.MessageMode.BROADCAST,
					"direction": BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message ReloadCard
				 * Notify about the card is reload.
				 */
				"ReloadCard": {
					"mode": BPMSoft.MessageMode.PTP,
					"direction": BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message PushHistoryState
				 * Notify about changes in the chain.
				 */
				"PushHistoryState": {
					"mode": BPMSoft.MessageMode.BROADCAST,
					"direction": BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message GetNotificationInfo
				 * Notify about the need to get notification info to the loader.
				 */
				"GetNotificationInfo": {
					"mode": BPMSoft.MessageMode.PTP,
					"direction": BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message UpdateNotifications
				 * Notify about the need to update notifications list.
				 */
				"UpdateNotifications": {
					"mode": BPMSoft.MessageMode.PTP,
					"direction": BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message ProcessExecDataChanged
				 * Defines that process parameters must be send.
				 */
				"ProcessExecDataChanged": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message ProcessExecDataChanged
				 * Notify about the removing notification counters.
				 */
				"RemoveNotificationCounters": {
					mode: BPMSoft.MessageMode.BROADCAST,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message GetLastRemindTime
				 * Requests date for notification's query
				 */
				"GetLastRemindTime": {
					"mode": BPMSoft.MessageMode.PTP,
					"direction": BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message GetNeedReadOnOpen
				 * Returns value that represent mark as read notifications on opened tab.
				 */
				"GetNeedReadOnOpen": {
					"mode": BPMSoft.MessageMode.PTP,
					"direction": BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			attributes: {
				/**
				 * Collection of the notifications.
				 */
				"Notifications": {
					"dataValueType": this.BPMSoft.DataValueType.COLLECTION,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Signs of possible load another page of data.
				 */
				"CanLoadMoreData": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": true
				},

				/**
				 * Last selected notification item.
				 * @private
				 */
				"LastSelectedRow": {
					"dataValueType": this.BPMSoft.DataValueType.CUSTOM_OBJECT,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Flag of visibility empty message.
				 * @private
				 */
				"IsEmptyMessageVisible": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": null
				},

				/**
				 * Active and selected item identifier.
				 */
				"ActiveItem": {
					"dataValueType": this.BPMSoft.DataValueType.GUID,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},
			properties: {
				/**
				 * Use date for notifications query.
				 */
				useDateForNotificationsQuery: false,

				/**
				 * Name column for ordering notifications.
				 * @protected
				 * @virtual
				 */
				orderingColumnName: "RemindTime",

				/**
				 * Order notification desc.
				 * @protected
				 * @virtual
				 */
				isOrderDirectionDesc: true,

				/**
				 * Use update query for mark notification as read.
				 * @protected
				 * @virtual
				 */
				useUpdateQueryForMarkNotificationAsRead: false

			},
			methods: {
				/**
				 * @inheritdoc BPMSoft.BaseViewModel#init
				 * @overridden
				 */
				init: function(callback, scope) {
					var isLoadNew = false;
					this.setUseDateForNotificationsQuery();
					this.set("NotificationV2Enabled",
						this.getIsFeatureEnabled("NotificationV2"));
					this.setEmptyMessageConfig(function() {
						this.setDefaultValues(scope);
						this.loadNotifications(isLoadNew, callback, scope);
					}, this);
					this.subscribeEvents();
					if (this.get("NotificationV2Enabled")) {
						this.sandbox.publish("UpdateCounterValues", this.getUpdateCounterConfig());
					} else {
						this.publishUpdateCounters();
					}
				},

				/**
				 * @inheritdoc BPMSoft.BaseSchemaModule#destroy
				 * @overridden
				 */
				destroy: function() {
					this.unSubscribeEvents();
					this.callParent(arguments);
				},

				/**
				 * Unsubscribe events.
				 * @protected
				 */
				unSubscribeEvents: BPMSoft.emptyFn,

				/**
				 * Sets data message of an empty list.
				 * @param {Function} callback Function to be called after set empty message config.
				 * @param {Object} scope Scope for the callback function.
				 * @private
				 */
				setEmptyMessageConfig: function(callback, scope) {
					var contextHelpCode = this.get("Resources.Strings.ContextHelpCode");
					var contextHelpId = this.get("Resources.Strings.ContextHelpId");
					this.initHelpUrl(contextHelpCode, contextHelpId, callback, scope);
					this.emptyMessageConfig = {
						title: this.get("Resources.Strings.EmptyResultTitle"),
						description: this.get("Resources.Strings.EmptyResultMessage"),
						image: this.get("Resources.Images.EmptyResultImage")
					};
				},

				/**
				 * Returns the column data type.
				 * @private
				 * @param {Object} record Element collection notification.
				 * @param {String} columnName Column name.
				 * @return {Object} Data type column.
				 */
				getDataValueType: function(record, columnName) {
					var valueType = null;
					if (record && columnName) {
						var column = record.getColumnByName(columnName);
						valueType = record.getColumnDataValueType(column);
					}
					return valueType;
				},

				/**
				 * Subscribes view model on the request instance events.
				 * @param {BPMSoft.EntitySchemaQuery} esq Select query.
				 * @private
				 */
				subscribesQueryEvents: function(esq) {
					esq.on("createviewmodel", this.createViewModel, this);
				},

				/**
				 * Unsubscribes view model on the request instance events.
				 * @param {BPMSoft.EntitySchemaQuery} esq Select query.
				 * @private
				 */
				unsubscribesQueryEvents: function(esq) {
					esq.un("createviewmodel", this.createViewModel, this);
				},

				/**
				 * Initializes an instance of the view model on the results of the query.
				 * @private
				 * @param {Object} config
				 * @param {Object} config.rawData Columns values.
				 * @param {Object} config.rowConfig Type of columns.
				 * @param {Object} config.viewModel View model.
				 */
				createViewModel: function(config) {
					var viewModel = this.getItemViewModel(config);
					config.viewModel = viewModel;
				},

				/**
				 * Returns the properties of the view model class of the object returned by the query results.
				 * @private
				 * @param {Object} config
				 * @param {Object} config.rawData Columns values.
				 * @param {Object} config.rowConfig Type of columns.
				 * @return {Object} Properties of the view model class.
				 */
				getGridRowViewModelConfig: function(config) {
					var gridRowViewModelConfig = {
						entitySchema: this.entitySchema,
						rowConfig: config.rowConfig,
						values: config.rawData,
						isNew: false,
						isDeleted: false,
						Ext: this.Ext,
						BPMSoft: this.BPMSoft,
						sandbox: this.sandbox
					};
					return gridRowViewModelConfig;
				},

				/**
				 * Generates configuration of the element view.
				 * @private
				 * @param {Object} itemConfig Link to the configuration element of ContainerList.
				 */
				getItemViewConfig: function(itemConfig) {
					var viewConfig = this.get("ViewConfig");
					viewConfig.visible = true;
					itemConfig.config = viewConfig;
				},

				/**
				 * Loads the next page of data.
				 * @private
				 */
				onLoadNext: function() {
					var isLoadNew = false;
					var canLoadMoreData = this.get("CanLoadMoreData");
					if (canLoadMoreData) {
						this.loadNotifications(isLoadNew);
					}
				},

				/**
				 * @private
				 * @param {Boolean} isSkipUpdateCounters Sign of skip update counters.
				 */
				_resetNotificationCounters: function(isSkipUpdateCounters) {
					this.removeNotificationCounters();
					if (!isSkipUpdateCounters) {
						this.publishUpdateCounters();
					}
				},

				/**
				 * @private
				 * @param {Boolean} isSkipUpdateCounters Sign of skip update counters.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Scope.
				 */
				_serviceMarkNewNotificationAsRead: function(isSkipUpdateCounters, callback, scope) {
					const skipUpdateCounters = isSkipUpdateCounters;
					BPMSoft.delay(function() {
						let config = {
							"serviceName": "NotificationService",
							"methodName": "MarkNotificationAsRead",
							"encodeData": true,
							"data": {
								"notificationTypeId": this.getNotificationType(),
								"remindTime": this._getDateForNotificationsQuery()
							}
						};
						this.callService(config, function(response) {
							let serviceResponse = response.MarkNotificationAsReadResult;
							if (serviceResponse && serviceResponse.success) {
								this._resetNotificationCounters(skipUpdateCounters);
								this.Ext.callback(callback, scope || this);
							}
						}, this);
					}, this, 1000);
				},

				/**
				 * @private
				 * @param {Boolean} isSkipUpdateCounters Sign of skip update counters.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Scope.
				 */
				_queryMarkNewNotificationAsRead: function(isSkipUpdateCounters, callback, scope) {
					let update = this.getUpdateWithUnreadNotifications();
					update.execute(function(response) {
						if (!response.success) {
							this.generateException(response.errorInfo);
							return;
						}
						this._resetNotificationCounters(isSkipUpdateCounters);
						this.Ext.callback(callback, scope || this);
					}, this);
				},

				/**
				 * @returns {Boolean}
				 * @private
				 */
				_getIsUseUpdateQueryForMarkNotificationAsReadEnabled: function() {
					return this.useUpdateQueryForMarkNotificationAsRead ||
						BPMSoft.Features.getIsEnabled("UseQueryForMarkNewNotificationAsRead");
				},

				/**
				 * Subscribes on events of model.
				 * @protected
				 */
				subscribeEvents: function() {
					var notificationType = this.getNotificationType();
					this.sandbox.subscribe("MarkNewNotificationsAsRead", this.markNewNotificationsAsRead,
						this, [notificationType]);
					this.sandbox.subscribe("UpdateNotifications", function(countersData) {
						this.onChangeNotifications(this, countersData);
					}, this, [notificationType]);
				},

				/**
				 * Initializes notification container list view config.
				 * @protected
				 * @param {Object} scope View model schema.
				 */
				initNotificationViewConfig: function(scope) {
					if (scope && scope.viewConfig) {
						var config = this.BPMSoft.findItem(scope.viewConfig, {tag: "NotificationViewConfig"});
						var viewConfig = config.item || {};
						this.set("ViewConfig", viewConfig);
					}
				},

				/**
				 * Sets default value of the attributes.
				 * @protected
				 * @param {Object} scope Scope.
				 */
				setDefaultValues: function(scope) {
					this.set("Notifications", this.Ext.create("BPMSoft.Collection"));
					this.initNotificationViewConfig(scope);
				},

				/**
				 * Loads a collection of notifications.
				 * @protected
				 * @param {Boolean} isLoadNew The sign, which says that you need to
				 * loads the next page of data.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Scope.
				 */
				loadNotifications: function(isLoadNew, callback, scope) {
					var select = this.getNotificationsSelect();
					this.prepareCollectionBeforeLoad(isLoadNew);
					this.initializePageableOptions(select);
					this.executeLoadCollectionQuery(select, isLoadNew, callback, scope);
				},

				/**
				 * Loading new notifications.
				 * @protected
				 * @param notificatinIds The array unique identifiers of the notifications for loading.
				 */
				loadNewNotifications: function(userCounters) {
					this.loadNotifications(false);
				},

				/**
				 * Generates exception message.
				 * @protected
				 * @param {Object} errorInfo Message.
				 */
				generateException: function(errorInfo) {
					throw new this.BPMSoft.UnknownException({
						message: errorInfo.message
					});
				},

				/**
				 * Initializes the pageable properties of the EntitySchemaQuery.
				 * @param {BPMSoft.EntitySchemaQuery} select Request of select notification.
				 * @protected
				 */
				initializePageableOptions: function(select) {
					var config = this.getPageableOptionsConfig();
					if (select && config && config.isPageable) {
						var collection = config.collection;
						select.rowCount = config.rowCount + collection.getCount();
					}
				},

				/**
				 * Returns pageable of the condition values.
				 * @protected
				 * @param {BPMSoft.EntitySchemaQuery} select Request of select notification.
				 * @param {Object} config Configuration object.
				 * @return {BPMSoft.ColumnValues} Pageable condition of the values.
				 */
				getPageableConditionalValues: function(select, config) {
					var primaryColumnName = config.primaryColumnName;
					var collection = config.collection;
					var loadedRecordsCount = collection.getCount();
					var lastRecord = collection.getByIndex(loadedRecordsCount - 1);
					var columnDataValueType = this.getDataValueType(lastRecord, primaryColumnName);
					var conditionalValues = this.Ext.create("BPMSoft.ColumnValues");
					var parametersConfig = {
						columns: select.columns,
						lastRecord: lastRecord,
						conditionalValues: conditionalValues
					};
					conditionalValues.setParameterValue(primaryColumnName,
						lastRecord.get(primaryColumnName), columnDataValueType);
					this.setConditionalValueParameters(parametersConfig);
					return conditionalValues;
				},

				/**
				 * Sets parameters of the conditional values.
				 * @protected
				 * @param {Object} config Configuration object.
				 */
				setConditionalValueParameters: function(config) {
					var lastRecord = config.lastRecord;
					var conditionalValues = config.conditionalValues;
					config.columns.eachKey(function(columnName, column) {
						var value = config.lastRecord.get(columnName);
						var dataValueType = this.getDataValueType(lastRecord, columnName);
						if (column.orderDirection !== this.BPMSoft.OrderDirection.NONE) {
							if (dataValueType === this.BPMSoft.DataValueType.LOOKUP) {
								value = value ? value.displayValue : null;
								dataValueType = this.BPMSoft.DataValueType.TEXT;
							}
							conditionalValues.setParameterValue(columnName, value, dataValueType);
						}
					}, this);
				},

				/**
				 * Returns options config for the configure pagination.
				 * @protected
				 * @return {Object} Pagination configuration object.
				 */
				getPageableOptionsConfig: function() {
					return {
						collection: this.get("Notifications"),
						primaryColumnName: "Id",
						isPageable: true,
						rowCount: 15,
						isClearGridData: false
					};
				},

				/**
				 * Returns select query with unread notifications.
				 * Use "getUpdateWithUnreadNotifications" instead this function.
				 * @deprecated
				 * @return {BPMSoft.UpdateQuery} Update query.
				 */
				getSelectWithUnreadNotifications: function() {
					var obsoleteMessage = BPMSoft.Resources.ObsoleteMessages.ObsoleteMethodMessage;
					this.log(Ext.String.format(obsoleteMessage, "getSelectWithUnreadNotifications",
						"getUpdateWithUnreadNotifications"));
					return this.getUpdateWithUnreadNotifications();
				},

				/**
				 * Returns update query with unread notifications.
				 * @protected
				 * @return {BPMSoft.UpdateQuery} Update query.
				 */
				getUpdateWithUnreadNotifications: function() {
					var update = this.Ext.create("BPMSoft.UpdateQuery", {
						rootSchemaName: this.entitySchemaName
					});
					this.initUpdateFilters(update);
					update.setParameterValue("IsRead", true, BPMSoft.DataValueType.BOOLEAN);
					return update;
				},

				/**
				 * Initializes update query filters.
				 * @protected
				 * @virtual
				 * @param {Object} Update query.
				 */
				initUpdateFilters: function(update) {
					this.initCurrentUserContactFilter(update.filters);
					this.initNotificationTypeFilter(update.filters);
					this.initIsReadFilter(update);
				},

				/**
				 * Initializes current user contact filter.
				 * @protected
				 * @virtual
				 * @param {Object} filters Query filters.
				 */
				initCurrentUserContactFilter: function(filters) {
					var currentContactId = BPMSoft.SysValue.CURRENT_USER_CONTACT.value;
					filters.add("CurrentContact",
						BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
							this.getCurrentUserContactColumnName(), currentContactId));
				},

				/**
				 * Returns current user contact column name.
				 * @protected
				 * @virtual
				 * @return {String}
				 */
				getCurrentUserContactColumnName: function() {
					return "Contact";
				},

				/**
				 * Initializes notification type filter.
				 * @protected
				 * @virtual
				 * @param {Object} filters Query filters.
				 */
				initNotificationTypeFilter: function(filters) {
					filters.add("NotificationType", BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "NotificationType", this.getNotificationType()));
				},

				/**
				 * Initializes isRead column filter.
				 * @protected
				 * @virtual
				 * @param {Object} update Update query.
				 */
				initIsReadFilter: function(update) {
					update.filters.addItem(BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "IsRead", false));
				},

				/**
				 * Sets all new notifications as read.
				 * @protected
				 * @param {Boolean} isSkipUpdateCounters Sign of skip update counters.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Scope.
				 */
				markNewNotificationsAsRead: function(isSkipUpdateCounters, callback, scope) {
					if (this._getIsUseUpdateQueryForMarkNotificationAsReadEnabled()) {
						this._queryMarkNewNotificationAsRead(isSkipUpdateCounters, callback, scope);
						return;
					}
					this._serviceMarkNewNotificationAsRead(isSkipUpdateCounters, callback, scope);
				},

				/**
				 * Publish message of the update counters.
				 */
				publishUpdateCounters: function() {
					var config = this.getUpdateCounterConfig();
					this.sandbox.publish("UpdateCounters", config);
					if (this._getIsUseUpdateQueryForMarkNotificationAsReadEnabled()) {
						return;
					}
					this.sandbox.publish("UpdateCounterValues", config);
				},

				/**
				 * Generates path to the image of the current notice in accordance with the type of notification.
				 * @protected
				 * @return {String} Generated image path.
				 */
				getNotificationImage: function() {
					const schemaName = this.get("SchemaName");
					return this.getImageUrlBySchemaName(schemaName);
				},

				/**
				 * Gets image url by schema name.
				 * @protected
				 * @param {String} schemaName Schema name.
				 * @return {String} Image url.
				 */
				getImageUrlBySchemaName: function(schemaName) {
					const moduleStructure = this.BPMSoft.ModuleUtils.getModuleStructureByName(schemaName) || {};
					const logoId = moduleStructure.logoId;
					const config = logoId
						? {
							source: this.BPMSoft.ImageSources.ENTITY_COLUMN,
							params: {
								schemaName: "SysImage",
								columnName: "Data",
								primaryColumnValue: logoId
							}
						}
						: resources.localizableImages.DefaultRemindingIcon;
					return this.BPMSoft.ImageUrlBuilder.getUrl(config);
				},

				/**
				 * Returns view model for the collection item.
				 * @protected
				 * @param {Object} config
				 * @param {Object} config.rawData Columns values.
				 * @param {Object} config.rowConfig Type of columns.
				 * @param {Object} config.viewModel View model.
				 * @return {BPMSoft.BaseViewModel} View model of the item.
				 */
				getItemViewModel: function(config) {
					var gridRowViewModelClassName = this.alternateClassName;
					var gridRowViewModelConfig = this.getGridRowViewModelConfig(config);
					var viewModel = this.Ext.create(gridRowViewModelClassName, gridRowViewModelConfig);
					viewModel.parentViewModel = this;
					return viewModel;
				},

				/**
				 * Decorates model features.
				 * @param {Object} item Element collection notifications.
				 * @deprecated
				 * @protected
				 */
				decorateItem: function(item) {
					this.log(Ext.String.format(this.BPMSoft.Resources.ObsoleteMessages.ObsoleteMethodMessage,
						"decorateItem", this.get("Resources.Strings.ObsoleteDecorateItemMethodMessage")),
						BPMSoft.LogMessageType.WARNING);
					item.sandbox = this.sandbox;
					item.BPMSoft = this.BPMSoft;
					item.Ext = this.Ext;
					item.getNotificationImage = this.getNotificationImage;
					item.getNotificationSubjectCaption = this.getNotificationSubjectCaption;
					item.onNotificationSubjectClick = this.onNotificationSubjectClick;
					item.getNotificationDate = this.getNotificationDate;
					item.getNotificationEntity = this.getNotificationEntity;
				},

				/**
				 * Prepares items collection before load.
				 * @param {Boolean} isLoadNew The sign, which says that you need to
				 * loads the next page of data.
				 * @protected
				 */
				prepareCollectionBeforeLoad: function(isLoadNew) {
					var notifications = this.get("Notifications");
					if (isLoadNew && notifications.getCount()) {
						notifications.clear();
					}
				},

				/**
				 * Executes esq for the getting new items collection.
				 * @param {BPMSoft.EntitySchemaQuery|Object} Query object.
				 * @param {Boolean} isLoadNew The sign, which says that you need to
				 * loads the next page of data.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Scope.
				 * @protected
				 */
				executeLoadCollectionQuery: function(esq, isLoadNew, callback, scope) {
					esq.getEntityCollection(function(response) {
						this.unsubscribesQueryEvents(esq);
						if (response && response.success) {
							this.onNotificationsLoad(esq.isPageable, response.collection);
							this.Ext.callback(callback, scope || this);
						} else {
							this.generateException(response.errorInfo);
						}
					}, this);
				},

				/**
				 * Handle loaded notification collection.
				 * @protected
				 * @param {Boolean} isPageable characteristic of a page-by-page sampling of data.
				 * @param {BPMSoft.Collection} items loaded notifications.
				 */
				onNotificationsLoad: function (isPageable, items) {
					var notifications = this.get("Notifications");
					if (isPageable) {
						this.removeExistNotification(notifications, items);
					} else {
						this.removeExistNotification(items, notifications);
					}
					this.processNotificationsCollection(items);
					var localNotifications = notifications.getItems().concat(items.getItems());
					localNotifications.sort(this.getNotificationsComparator());
					items.eachKey(function(key, item) {
						notifications.addIfNotExists(key, item, localNotifications.indexOf(item));
					}, this);
					if(items.getCount() > 0 && this.sandbox.publish("GetNeedReadOnOpen", null, [this.getNotificationType()])) {
						this.markNewNotificationsAsRead();
					}
				},

				/**
				 * Processes notification collection.
				 * @protected
				 * @virtual
				 * @param {BPMSoft.Collection} notificationsCollection Notifications collection.
				 */
				processNotificationsCollection: BPMSoft.emptyFn,

				/**
				 * Processes notification item click.
				 * @protected
				 * @virtual
				 * @param {String} id Notification identifier.
				 */
				onItemClick: BPMSoft.emptyFn,

				/**
				 * Removes the existing notification.
				 * @param {BPMSoft.Collection} existNotifications Collection of existing notifications.
				 * @param {BPMSoft.Collection} updateNotifications Collection of updated notifications.
				 */
				removeExistNotification: function(existNotifications, updateNotifications) {
					if (existNotifications.getCount() > 0) {
						var keys = updateNotifications.getKeys();
						this.BPMSoft.each(keys, function(item) {
							if (existNotifications.contains(item)) {
								existNotifications.removeByKey(item);
							}
						}, this);
					}
				},

				/**
				 * Opens entity card by the schema name and entity id.
				 * @param {String} schemaName Schema name.
				 * @param {String} entityId Entity id.
				 * @param {String} [typeColumnValue] Value of column type.
				 * @protected
				 */
				openEntityCard: function(schemaName, entityId, typeColumnValue) {
					var hash = NetworkUtilities.getEntityUrl(schemaName, entityId, typeColumnValue);
					this.sandbox.publish("PushHistoryState", {hash: hash, stateObj: {forceNotInChain: true}});
				},

				/**
				 * Adds columns to select query.
				 * @protected
				 * @param {BPMSoft.EntitySchemaQuery} select Select query.
				 */
				addColumns: function(select) {
					select.addColumn("Id");
					select.addColumn("Author");
					select.addColumn("Contact", "ContactTo");
					var column = select.addColumn("RemindTime");
					column.orderDirection = this.BPMSoft.OrderDirection.DESC;
					select.addColumn("Description");
					select.addColumn("SubjectId");
					select.addColumn("Source");
					select.addColumn("SubjectCaption");
					select.addColumn("[VwSysSchemaInWorkspace:UId:Loader].Name", "LoaderName");
					select.addColumn("[VwSysSchemaInWorkspace:UId:SysEntitySchema].Name", "SchemaName");
				},

				/**
				 * Removes columns from select query.
				 * Don't use this function.
				 * @deprecated
				 * @param {BPMSoft.EntitySchemaQuery} select Select query.
				 */
				removeColumns: function() {
					this.log(Ext.String.format(this.BPMSoft.Resources.ObsoleteMessages.ObsoleteMethodMessage,
						"removeColumns", this.get("Resources.Strings.ObsoleteRemoveColumnsMethodMessage")),
						BPMSoft.LogMessageType.WARNING);
				},

				/**
				 * Adds filters to query.
				 * @protected
				 * @param {BPMSoft.EntitySchemaQuery} select Select query.
				 */
				addFilters: function(select) {
					select.filters = this.getNotificationsSelectFilters();
				},

				/**
				 * Returns type of notifications.
				 * @protected
				 * @return {Guid} Type of notifications.
				 */
				getNotificationType: function() {
					return ConfigurationConstants.Reminding.Notification;
				},

				/**
				 * Returns group of notifications.
				 * @protected
				 * @return {String} Group of notifications.
				 */
				getNotificationGroup: function() {
					return ConfigurationConstants.NotificationGroup.All;
				},

				/**
				 * Returns config of the update counter.
				 * @protected
				 * @return {Object} Config of the update counter.
				 */
				getUpdateCounterConfig: function() {
					var group = this.getNotificationGroup();
					return {
						groupName: group
					};
				},

				/**
				 * Returns notifications select query.
				 * @return {BPMSoft.EntitySchemaQuery} Request of select notification.
				 */
				getNotificationsSelect: function() {
					var select = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: this.entitySchemaName
					});
					this.subscribesQueryEvents(select);
					this.addColumns(select);
					this.addFilters(select);
					this.applySelect(select, null);
					return select;
				},

				/**
				 * Merges parameters of the select queries.
				 * @protected
				 * @deprecated
				 * @param {BPMSoft.EntitySchemaQuery} select Select query.
				 * @param {BPMSoft.EntitySchemaQuery} mergerSelect Query of the merger.
				 */
				applySelect: function(select, mergerSelect) {
					if (!mergerSelect) {
						return;
					}
					var parameterConfig = this.getApplyParameterConfig();
					this.BPMSoft.each(parameterConfig, function(item, key) {
						var selectItem = select[key];
						var mergerItem = mergerSelect[key];
						if (selectItem && mergerItem) {
							item.call(this, selectItem, mergerItem);
						}
					}, this);
				},

				/**
				 * Returns config of the parameters merger
				 * @protected
				 * @return {Object}
				 */
				getApplyParameterConfig: function() {
					return {
						"columns": this.defaultCollectionMerger,
						"filters": this.defaultCollectionMerger
					};
				},

				/**
				 * Get compare function.
				 * @protected
				 * @return {Function} return function for compare two notifications among themselves.
				 */
				getNotificationsComparator: function() {
					const orderingColumnName = this.orderingColumnName;
					const isOrderDirectionDesc = this.isOrderDirectionDesc;
					return function (item1, item2) {
						var remindTime1 = item1.get(orderingColumnName);
						var remindTime2 = item2.get(orderingColumnName);
						const result = isOrderDirectionDesc
							? (remindTime2 > remindTime1)
							: (remindTime1 > remindTime2);
						return result ? 1 : -1;
					};
				},

				/**
				 * Mergers collection of the default.
				 * @private
				 * @param {BPMSoft.Collection} collection Base collection.
				 * @param {BPMSoft.Collection} mergerCollection Collection of the merger.
				 */
				defaultCollectionMerger: function(collection, mergerCollection) {
					mergerCollection.eachKey(function(key, item) {
						if (collection.contains(key)) {
							collection.removeByKey(key);
						}
						collection.add(key, item);
					}, this);
				},

				/**
				 * Applies filters by current workspace.
				 * @private
				 * @param {BPMSoft.FilterGroup} filters Filters that need to be supplemented.
				 */
				_applyWorkspaceFilters: function(filters) {
					var workspace = this.BPMSoft.SysValue.CURRENT_WORKSPACE.value;
					var loaderFilterGroup = this.Ext.create("BPMSoft.FilterGroup");
					loaderFilterGroup.logicalOperation = this.BPMSoft.LogicalOperatorType.OR;
					loaderFilterGroup.add("LoaderSchemaWorkspaceFilter",
						this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL,
							"[VwSysSchemaInWorkspace:UId:Loader].SysWorkspace",
							workspace
						)
					);
					loaderFilterGroup.add("LoaderSchemaWorkspaceFilterNull",
						this.BPMSoft.createColumnIsNullFilter(
							"Loader"
						)
					);
					filters.add("LoaderFiltersGroup", loaderFilterGroup);
					filters.add("EntitySchemaWorkspaceFilter",
						this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL,
							"[VwSysSchemaInWorkspace:UId:SysEntitySchema].SysWorkspace",
							workspace
						)
					);
				},

				/**
				 * Applies common filters by owner and type.
				 * @private
				 * @param {BPMSoft.FilterGroup} filters Filters that need to be supplemented.
				 */
				applyTypeAndOwnerFilters: function(filters) {
					this.initCurrentUserContactFilter(filters);
					this.initNotificationTypeFilter(filters);
				},

				/**
				 * Returns is UseDateForNotificationsQuery enabled.
				 * @returns {Boolean}
				 * @private
				 */
				_getUseDateForNotificationsQuery: function() {
					return this.useDateForNotificationsQuery;
				},
				/**
				 * Returns date and time for notifications query.
				 * @returns {Date}
				 * @private
				 */
				_getDateForNotificationsQuery: function() {
					if (this._getUseDateForNotificationsQuery()) {
						var notificationType = this.getNotificationType();
						return this.sandbox.publish("GetLastRemindTime", null, [notificationType]);
					}
					return new Date(this.Ext.Date.now());
				},
				/**
				 * Returns a filters for select.
				 * @return {BPMSoft.FilterGroup} Group filters.
				 */
				getNotificationsSelectFilters: function() {
					var filters = this.BPMSoft.createFilterGroup();
					this.applyTypeAndOwnerFilters(filters);
					this._applyWorkspaceFilters(filters);
					filters.add("LessOrEqualRemindTime",
						this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.LESS_OR_EQUAL,
							"RemindTime",
							this._getDateForNotificationsQuery()
						)
					);
					return filters;
				},

				/**
				 * Updates the number of new notifications on the basis of the values of the counters.
				 * @param {Object} scope Scope.
				 * @param {Object} userCounters Contains a number of notifications counters.
				 */
				onChangeNotifications: function(scope, userCounters) {
					if (!userCounters) {
						return;
					}

					if (userCounters.Header.Sender === "UpdateReminding") {
						var config = userCounters;
						var recordId = config.recordId;
						var operation = config.operation;
						var markAsRead = config.markAsRead;
						if (operation === "update" && markAsRead !== true) {
							this.removeNotification(recordId, false);
							this.loadNotification(recordId);
						}
						if (operation === "delete") {
							this.removeNotification(recordId);
						}
						return;
					}
					this.loadNewNotifications(userCounters);
				},

				/**
				 * Returns current counter value.
				 * @return {Number} current counter value.
				 */
				getCurrentCounterValue: function() {
					var notifications = this.get("Notifications");
					var result = 0;
					if (notifications) {
						result = notifications.getCount();
					}
					return result;
				},

				/**
				 * Removes record.
				 * @param {String} notificationId The unique identifier of the notification.
				 * @param {Boolean} [useUpdateCounter=true] Use update counters after remove item.
				 */
				removeNotification: function(notificationId, useUpdateCounter) {
					var notifications = this.get("Notifications");
					if (notifications && notifications.contains(notificationId)) {
						notifications.removeByKey(notificationId);
						if (useUpdateCounter !== false && !this.get("NotificationV2Enabled")) {
							this.removeNotificationCounters();
							var config = this.getUpdateCounterConfig();
							this.sandbox.publish("UpdateCounters", config);
						}
					}
				},

				/**
				 * Removes notification counters.
				 */
				removeNotificationCounters: function() {
					var config = this.getUpdateCounterConfig();
					this.sandbox.publish("RemoveNotificationCounters", config);
				},

				/**
				 * Loads record.
				 * @param {String} notificationId The unique identifier of the notification.
				 * @param {Function} [callback] The callback function.
				 * @param {Object} [scope] The callback execution context.
				 */
				loadNotification: function(notificationId, callback, scope) {
					var notificationsCollection = this.get("Notifications");
					var select = this.getNotificationsSelect();
					select.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Id", notificationId));
					select.getEntityCollection(function(response) {
						this.unsubscribesQueryEvents(select);
						if (response && response.success) {
							var itemsCollection = response.collection;
							this.removeExistNotification(notificationsCollection, itemsCollection);
							this.addItemsToNotificationsCollection(notificationsCollection, itemsCollection);
							this.processNotificationsCollection(itemsCollection);
						} else {
							this.generateException(response.errorInfo);
						}
						Ext.callback(callback, scope, [response]);
					}, this);
				},

				/**
				 * Adds received items to notifications collection.
				 * @param {BPMSoft.Collection} notificationsCollection Collection of notifications.
				 * @param {BPMSoft.Collection} itemsCollection Collection with new items.
				 */
				addItemsToNotificationsCollection: function(notificationsCollection, itemsCollection) {
					itemsCollection.each(function(item) {
						var id = item.get("Id");
						if (!notificationsCollection.contains(id)) {
							notificationsCollection.add(id, item, 0);
						}
					}, this);
				},

				/**
				 * Gets the content of the notifications.
				 * @return {String} Content of the notifications.
				 */
				getNotificationSubjectCaption: function() {
					return this.get("SubjectCaption");
				},

				/**
				 * Returns link element dom attributes.
				 * @returns {Object} Link element dom attributes.
				 */
				getNotificationLinkAttributes: function() {
					var schemaName = this.get("SchemaName");
					var isActiveLink = !Ext.isEmpty(this.BPMSoft.ModuleUtils.getModuleStructureByName(schemaName));
					return { activelink: isActiveLink };
				},

				/**
				 * Handles a click on the hyper-link notifications. Provides a transition to the entity
				 * which initiated the notifications.
				 */
				onNotificationSubjectClick: function() {
					var schemaName = this.get("SchemaName");
					var entityId = this.get("SubjectId");
					var loaderName = this.get("LoaderName");
					this.openNotificationEntityCard(schemaName, entityId, loaderName);
				},

				/**
				 * Init attributes UseDateForNotificationsQuery.
				 * @protected
				*/
				setUseDateForNotificationsQuery: function() {
					this.useDateForNotificationsQuery = this.getIsFeatureEnabled("UseDateForNotificationsQuery");
				},
				/**
				 * Open notification entity card.
				 * @protected
				 */
				openNotificationEntityCard: function(schemaName, entityId, loaderName) {
					var moduleStructure = this.BPMSoft.ModuleUtils.getModuleStructureByName(schemaName);
					if (!moduleStructure) {
						return;
					}
					var attribute = moduleStructure.attribute;
					if (attribute && !this.Ext.isEmpty(entityId)) {
						this.openTypedCard(schemaName, attribute, entityId);
						return;
					}
					if (this.Ext.isEmpty(loaderName) && this.Ext.isEmpty(entityId)) {
						this.openEntitySection(schemaName);
						return;
					}
					if (this.Ext.isEmpty(loaderName)) {
						this.openEntityCard(schemaName, entityId);
						return;
					}
					this.openLoaderModule(loaderName);
				},

				/**
				 * Opens section of the entity.
				 * @param {String} entitySchemaName Entity name.
				 */
				openEntitySection: function(entitySchemaName) {
					NetworkUtilities.openEntitySection({
						entitySchemaName: entitySchemaName,
						sandbox: this.sandbox
					});
				},

				/**
				 * Checks that card can opened by process.
				 * @param {String} schemaName Name of schema.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Scope.
				 * @return {Boolean} true if card can opened by process.
				 */
				checkCanBeOpenedByProcess: function(schemaName, callback, scope) {
					this.getEntitySchemaByName(schemaName, function(entitySchema) {
						var isExistProcessElement = false;
						if (entitySchema) {
							isExistProcessElement = entitySchema.isColumnExist("ProcessElementId");
						}
						if (callback) {
							callback.call(scope || this, isExistProcessElement);
						}
					}, this);
				},

				/**
				 * Tries to open card by process and returns state of this operation.
				 * @param {BPMSoft.BaseViewModel} entity entity-object.
				 * @return {Boolean} Return true if opened card by process.
				 */
				openProcessCard: function(entity) {
					var entityId = entity.get("Id");
					var prcElId = entity.get("ProcessElementId");
					return ProcessModuleUtilities.tryShowProcessCard.call(this, prcElId, entityId);
				},

				/**
				 * Opens typed card.
				 * @param {String} schemaName Name of schema.
				 * @param {String} attribute Column name of type.
				 * @param {Guid} entityId Entity identifier.
				 */
				openTypedCard: function(schemaName, attribute, entityId) {
					this.checkCanBeOpenedByProcess(schemaName, function(isExistProcessElement) {
						var select = this.getTypedCardInfoSelect(schemaName, attribute, isExistProcessElement);
						select.getEntity(entityId, function(result) {
							if (result && result.success) {
								var entity = result.entity;
								var typeId = entity.get(attribute).value;
								if (isExistProcessElement) {
									var isOpenedByProcess = this.openProcessCard(entity);
									if (isOpenedByProcess) {
										return;
									}
								}
								this.openEntityCard(schemaName, entityId, typeId);
							} else {
								this.generateException(result.errorInfo);
							}
						}, this);
					}, this);
				},

				/**
				 * Returns query for getting information of the typed card.
				 * @param {String} schemaName Name of schema.
				 * @param {String} attribute Column name of type.
				 * @param {Boolean} isExistProcessElement If true, then schema use element of the process.
				 * @return {BPMSoft.EntitySchemaQuery} Query for getting information of the typed card.
				 */
				getTypedCardInfoSelect: function(schemaName, attribute, isExistProcessElement) {
					var select = this.Ext.create("BPMSoft.EntitySchemaQuery", {rootSchemaName: schemaName});
					select.addColumn(attribute);
					if (isExistProcessElement) {
						select.addColumn("ProcessElementId");
					}
					return select;
				},

				/**
				 * Opens loader module.
				 * @param {String} loaderName Name of loader module.
				 */
				openLoaderModule: function(loaderName) {
					var loaderId = this.sandbox.id + "_" + loaderName;
					this.sandbox.subscribe("GetNotificationInfo", function() {
						return this;
					}, this, [loaderId]);
					this.sandbox.loadModule(loaderName, {id: loaderId});
				},

				/**
				 * Returns notification date and time.
				 * @return {String} Date and time.
				 */
				getNotificationDate: function() {
					return FormatUtils.smartFormatDate({
						dateValue: this.get("RemindTime"),
						hasTimezoneOffset: true
					});
				},

				/**
				 * Returns entity schema name.
				 * @return {String} Name.
				 */
				getNotificationEntity: function() {
					var entityName = this.get("SchemaName");
					var moduleStructure = this.BPMSoft.ModuleUtils.getModuleStructureByName(entityName);
					return moduleStructure ? moduleStructure.moduleCaption : "";
				}
			},
			diff: [
				{
					"operation": "insert",
					"name": "NotificationsContainer",
					"values": {
						"generateId": true,
						"id": "notification-items-container-list",
						"idProperty": "Id",
						"generator": "ConfigurationItemGenerator.generateContainerList",
						"isAsync": false,
						"selectors": {"wrapEl": "#notification-items-container-list"},
						"collection": "Notifications",
						"observableRowNumber": 1,
						"observableRowVisible": {"bindTo": "onLoadNext"},
						"onGetItemConfig": "getItemViewConfig",
						"getEmptyMessageConfig": {"bindTo": "prepareEmptyGridMessageConfig"},
						"selectedItemCssClass": "selected-item-class",
						"rowCssSelector": ".notification-container.selectable",
						"isEmpty": {"bindTo": "IsEmptyMessageVisible"},
						"onItemClick": {"bindTo": "onItemClick"},
						"activeItem": {"bindTo": "ActiveItem"}
					}
				},
				{
					"operation": "insert",
					"name": "Notification",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"tag": "NotificationViewConfig",
						"wrapClass": ["notification-container"],
						"visible": false,
						"items": []
					}
				}
			]
		};
	});
