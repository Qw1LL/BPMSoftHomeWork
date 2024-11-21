/**
 * Parent: BaseNotificationsSchema
 */
define("VisaNotificationsSchema", ["VisaNotificationsSchemaResources", "ConfigurationConstants", "VisaHelper"],
	function(resources, ConfigurationConstants, VisaHelper) {
		return {
			attributes: {
				/**
				 * Visa actions button menu items.
				 */
				"VisaActionButtonMenu": {
					"dataValueType": this.BPMSoft.DataValueType.COLLECTION,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": this.Ext.create("BPMSoft.BaseViewModelCollection")
				},

				/**
				 * Pageable row count.
				 */
				"PageableRowCount": {
					"dataValueType": this.BPMSoft.DataValueType.NUMBER,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": 15
				},
				/**
				 * Filter approvals checkbox.
				 */
				"ShowOnlyMyApprovals": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": true
				}
			},
			/**
			 * Reload counter values.
			 */
			messages: {
				"ReloadCounterValues": {
					"mode": BPMSoft.MessageMode.BROADCAST,
					"direction": BPMSoft.MessageDirectionType.PUBLISH
				},
			},
			properties: {
				_initialized: false
			},
			methods: {

				/**
				 * @private
				 */
				_initShowOnlyMyApprovals: function(callback, scope) {
					this.initializeProfile(function() {
						const profile = this.getProfile();
						const key = "showOnlyMyApprovals";
						if (profile && !_.isUndefined(profile[key])) {
							this.$ShowOnlyMyApprovals = profile[key];
						}
						Ext.callback(callback, scope || this);
					}, this);
				},

				/**
				 * @inheritdoc BPMSoft.BaseNotificationsSchema#init
				 * @override
				 */
				init: function() {
					const parentMethod = this.getParentMethod();
					const args = arguments;
					this._initShowOnlyMyApprovals(function() {
						parentMethod.apply(this, args);
						this._initVisaActionButtonMenu();
						this._initialized = true;
					}, this);
				},

				/**
				 * Initializes and returns visa actions button menu items.
				 * @private
				 * @return {BPMSoft.BaseViewModelCollection}
				 */
				_initVisaActionButtonMenu: function() {
					var menu = this.get("VisaActionButtonMenu");
					var collection = Ext.create("BPMSoft.BaseViewModelCollection");
					collection.add(this.getButtonMenuItem({
						Caption: {"bindTo": "Resources.Strings.ApproveMenuItemCaption"},
						Click: {"bindTo": "approve"},
						ImageConfig: this.get("Resources.Images.Approve")
					}));
					collection.add(this.getButtonMenuItem({
						Caption: {"bindTo": "Resources.Strings.RejectMenuItemCaption"},
						Click: {"bindTo": "reject"},
						ImageConfig: this.get("Resources.Images.Reject")
					}));
					collection.add(this.getButtonMenuSeparator());
					collection.add(this.getButtonMenuItem({
						Caption: {"bindTo": "Resources.Strings.ChangeVizierCaption"},
						Click: {"bindTo": "changeVizier"},
						ImageConfig: this.get("Resources.Images.ChangeVizier")
					}));
					menu.clear();
					menu.loadAll(collection);
					return menu;
				},

				/**
				 * Returns type of notifications.
				 * @protected
				 * @return {Guid} Type of notifications.
				 */
				getNotificationType: function() {
					return ConfigurationConstants.Reminding.Visa;
				},

				/**
				 * @inheritdoc BPMSoft.BaseNotificationsSchema#getNotificationGroup
				 * @overridden
				 */
				getNotificationGroup: function() {
					return ConfigurationConstants.NotificationGroup.Visa;
				},

				/**
				 * @inheritdoc BPMSoft.BaseNotificationsSchema#loadNotifications
				 * @overridden
				 */
				loadNotifications: function(isLoadNew, callback, scope) {
					var config = this.getDataServiceConfig();
					this.callService(config, function(responseObject) {
						this._onLoadCollection(responseObject);
						this.Ext.callback(callback, scope || this);
					}, this);
				},

				/**
				 * Returns configuration object for the data service.
				 * @return {Object} Data service config.
				 * @private
				 */
				getDataServiceConfig: function() {
					const AsManager = 32;
					const All = 63;
					var notifications = this.get("Notifications");
					var rowCount = notifications.getCount() + this.get("PageableRowCount");
					const ownerRoleSources = this.$ShowOnlyMyApprovals ? All^AsManager : All;
					return {
						serviceName: "VisaDataService",
						methodName: "GetVisaEntities",
						data: {
							sysAdminUnitId: this.BPMSoft.SysValue.CURRENT_USER.value,
							requestOptions: {
								isPageable: true,
								rowCount: rowCount,
								ownerRoleSources
							}
						}
					};
				},

				/**
				 * @inheritdoc BPMSoft.BaseNotificationsSchema#loadNotification
				 * @overridden
				 */
				loadNotification: function() {
					var config = this.getDataServiceConfig();
					this.callService(config, function(responseObject) {
						var response = this._parseDataServiceResponse(responseObject);
						var items = this.getViewModelCollection(response);
						var notifications = this.get("Notifications");
						this.addItemsToNotificationsCollection(notifications, items);
					}, this);
				},

				/**
				 * Callback for the visa service collection query.
				 * @param {Object} responseObject Service response.
				 * @private
				 */
				_onLoadCollection: function(responseObject) {
					var response = this._parseDataServiceResponse(responseObject);
					var notifications = this.get("Notifications");
					notifications.clear();
					var items = this.getViewModelCollection(response);
					notifications.loadAll(items);
				},

				/**
				 * Removes exists notification items from server.
				 * @private
				 * @deprecated Will be removed after 7.12.2.
				 * @param {BPMSoft.Collection} responseItems Collection of notifications from server.
				 */
				_removeExistingResponseItems: function(responseItems) {
					var notifications = this.get("Notifications");
					responseItems.each(function(item) {
						var key = item.get("Id");
						if (notifications.contains(key)) {
							responseItems.remove(item);
						}
					}, this);
				},

				/**
				 * Parses server data service response object.
				 * @private
				 * @param {Object} responseObject Service response.
				 * @return {Object}
				 */
				_parseDataServiceResponse: function(responseObject) {
					var response = this.BPMSoft.decode(responseObject.GetVisaEntitiesResult);
					var result = this.responseAdapter(response);
					return result;
				},

				/**
				 * Adapts old service response for the collection.
				 * @param {Object} response Service response.
				 * @return {Object} Adapted service response.
				 * @private
				 */
				responseAdapter: function(response) {
					this.BPMSoft.each(response.rows, function(item) {
						item.SubjectCaption = item.Title;
						item.RemindTime = item.CreatedOn;
						item.SubjectId = item.VisaObjectId;
					});
					return response;
				},

				/**
				 * @inheritdoc BPMSoft.BaseNotificationsSchema#getNotificationEntity
				 * @overridden
				 */
				getNotificationEntity: function() {
					return this.get("VisaSchemaCaption");
				},

				/**
				 * @inheritdoc BPMSoft.BaseNotificationsSchema#getNotificationDate
				 * @overridden
				 */
				getNotificationDate: function() {
					const createdOn = this.get("ModifiedOn");
					if (createdOn) {
						return BPMSoft.getTypedStringValue(new Date(createdOn), BPMSoft.DataValueType.DATE_TIME);
					}
					return BPMSoft.emptyString;
				},

				/**
				 * Returns view model for the items collection.
				 * @param {Object} response View model configuration object.
				 * @return {BPMSoft.BaseViewModelCollection} Collection view model.
				 * @private
				 */
				getViewModelCollection: function(response) {
					var rowConfig = response.rowConfig;
					var viewModelCollection = Ext.create("BPMSoft.BaseViewModelCollection", {
						rowConfig: rowConfig
					});
					this.addItemsToCollection(viewModelCollection, response.rows, rowConfig);
					return viewModelCollection;
				},

				/**
				 * Add items to the view model collection.
				 * @param {BPMSoft.BaseViewModelCollection} viewModelCollection View model collection.
				 * @param {Array} items Items for the view model collection.
				 * @param {Object} rowConfig Configuration object for the item.
				 * @private
				 */
				addItemsToCollection: function(viewModelCollection, items, rowConfig) {
					this.BPMSoft.each(items, function(item) {
						var viewModel = this.getItemViewModel({
							rawData: item,
							rowConfig: rowConfig
						});
						var key = viewModel.get(viewModel.primaryColumnName);
						viewModelCollection.addIfNotExists(key, viewModel);
					}, this);
				},

				/**
				 * @inheritdoc BPMSoft.BaseNotificationsSchema#setConditionalValueParameters
				 * @overridden
				 */
				setConditionalValueParameters: function(config) {
					var lastRecord = config.lastRecord;
					config.conditionalValues.setParameterValue("ModifiedOn", lastRecord.get("ModifiedOn"),
						this.getDataValueType(lastRecord, "ModifiedOn"));
				},

				/**
				 * Handler for the approve visa.
				 * @private
				 */
				approve: function() {
					this.getVisaEntity(function(result) {
						VisaHelper.approveAction(result, function() {
							this.removeVisaFromCollection();
						}, this);
					});
				},

				/**
				 * Handler for the reject visa.
				 * @private
				 */
				reject: function() {
					this.getVisaEntity(function(result) {
						VisaHelper.rejectAction(result, function() {
							this.removeVisaFromCollection();
						}, this);
					});
				},

				/**
				 * Removes visa from items collection.
				 * @private
				 */
				removeVisaFromCollection: function() {
					this.deleteVisaItem();
					this.publishUpdateCounters();
				},

				/**
				 * Handler for the change vizier.
				 * @private
				 */
				changeVizier: function() {
					var visaEntityName = this.getVisaEntityName();
					VisaHelper.changeVizierAction(this.get("Id"), visaEntityName, this.sandbox, null, function(result) {
						if (result) {
							this.loadNotifications.call(this.parentViewModel);
							this.publishUpdateCounters();
						}
					}, this);
				},

				/**
				 * Returns in callback visa entity.
				 * @param {Function} callback Callback function.
				 * @private
				 */
				getVisaEntity: function(callback) {
					var visaEntityName = this.getVisaEntityName();
					this.getEntitySchemaByName(visaEntityName, function(schema) {
						var id = this.get("Id");
						var select = this.getEntityVisaSelect(schema);
						select.getEntity(id, function(result) {
							if (result.success) {
								callback.call(this, result.entity);
							}
						}, this);
					}.bind(this));
				},

				/**
				 * Returns visa entity name.
				 * @return {String} Visa entity name.
				 * @private
				 */
				getVisaEntityName: function() {
					var schemaName = this.get("SchemaName");
					var moduleStructure = this.BPMSoft.ModuleUtils.getModuleStructureByName(schemaName) || {};
					var visaSchemaName = moduleStructure.visaSchemaName
						? moduleStructure.visaSchemaName
						: schemaName + "Visa";
					return visaSchemaName;
				},

				/**
				 * Returns entity schema query for the visa entity.
				 * @param {String} schema Schema name.
				 * @return {BPMSoft.EntitySchemaQuery} Entity schema query for the visa entity.
				 * @private
				 */
				getEntityVisaSelect: function(schema) {
					var select = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchema: schema
					});
					select.addColumn("Id");
					select.addColumn("Status");
					select.addColumn("Comment");
					select.addColumn("SetDate");
					select.addColumn("SetBy");
					return select;
				},

				/**
				 * Removes visa from items collection.
				 * @private
				 */
				deleteVisaItem: function() {
					var id = this.get("Id");
					this.removeNotification.call(this.parentViewModel, id);
				},

				/**
				 * Selects current notification item.
				 * @protected
				 */
				selectNotificationItemOnActionButtonClick: function() {
					this.parentViewModel.set("ActiveItem", this.get("Id"));
				},

				/**
				 * @inheritdoc BPMSoft.BaseNotificationsSchema#getNotificationImage
				 * @overridden
				 */
				getNotificationImage: function() {
					var config;
					var schemaName = this.get("SchemaName");
					var module = this.BPMSoft.ModuleUtils.getModuleStructureByName(schemaName);
					if (module && module.imageId) {
						config = {
							source: this.BPMSoft.ImageSources.ENTITY_COLUMN,
							params: {
								schemaName: "SysImage",
								columnName: "Data",
								primaryColumnValue: module.imageId
							}
						};
					} else {
						config = this.get("Resources.Images.DefaultImage");
					}
					return this.BPMSoft.ImageUrlBuilder.getUrl(config);
				},

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#getProfileKey
				 * @overridden
				 */
				getProfileKey: function() {
					return "VisaNotifications";
				},

				/** Checkbox control handler.
				 * @protected
				 * @param {Boolean} checked New checkbox value.
				 */
				onShowOnlyMyApprovals: function(checked) {
					if (typeof checked === "boolean" && this._initialized === true) {
						this.$ShowOnlyMyApprovals = checked;
						const key = this.getProfileKey();
						BPMSoft.utils.saveUserProfile(key, {
							showOnlyMyApprovals: checked
						});
						this.loadNotifications(false, () => {
							this.sandbox.publish("ReloadCounterValues");
						}, this);
					}
				},

				/**
				 * Returns true, if feature disabled.
				 * @return {Boolean}
				 */
				getShowActionsButtonContainer: function() {
					return BPMSoft.Features.getIsDisabled("DisableShowOnlyMyApprovals");
				}
			},
			diff: [
				{
					"operation": "merge",
					"name": "NotificationsContainer",
					"values": {
						"observableRowNumber": 2
					}
				},
				{
					"operation": "insert",
					"name": "MainActionsButtonContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["main-actions-button-container"],
						"items": [],
						"visible": {"bindTo": "getShowActionsButtonContainer"}
					},
					"index": 0
				},
				{
					"operation": "insert",
					"name": "ShowOnlyMyApprovals",
					"parentName": "MainActionsButtonContainer",
					"propertyName": "items",
					"values": {
						"labelConfig": {
							"caption": {"bindTo": "Resources.Strings.ShowOnlyMyApprovalsCaption"}
						},
						"checkedchanged": {"bindTo": "onShowOnlyMyApprovals"},
						"wrapClass": ["t-checkbox-control show-only-my-approvals"]
					}
				},

				{
					"operation": "insert",
					"name": "NotificationItemContainer",
					"parentName": "Notification",
					"propertyName": "items",
					"values": {
						"id": "notificationItemContainer",
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"selectors": {
							"wrapEl": "#notificationItemContainer"
						},
						"wrapClass": ["visa-notification-item-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "NotificationItemTopContainer",
					"parentName": "NotificationItemContainer",
					"propertyName": "items",
					"values": {
						"id": "notificationItemTopContainer",
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"selectors": {
							"wrapEl": "#notificationItemTopContainer"
						},
						"wrapClass": ["visa-notification-item-top-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "NotificationImage",
					"parentName": "NotificationItemTopContainer",
					"propertyName": "items",
					"values": {
						"getSrcMethod": "getNotificationImage",
						"onPhotoChange": BPMSoft.emptyFn,
						"readonly": true,
						"classes": {
							"wrapClass": [
								"visa-notification-icon-class",
								"sectionPanelBackgroundColor"
							]
						},
						"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage"
					}
				},
				{
					"operation": "insert",
					"name": "NotificationDate",
					"parentName": "NotificationItemTopContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "getNotificationDate"},
						"classes": {"labelClass": ["subject-text-labelClass"]}
					}
				},
				{
					"operation": "insert",
					"name": "VisaActionButton",
					"parentName": "NotificationItemTopContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"classes": {"wrapperClass": ["visaActionButtonWrap-class"]},
						"caption": {"bindTo": "Resources.Strings.VisaActionButton"},
						"prepareMenu": {"bindTo": "selectNotificationItemOnActionButtonClick"},
						"menu": {
							"items": {"bindTo": "VisaActionButtonMenu"}
						}
					}
				},
				{
					"operation": "insert",
					"name": "NotificationItemMiddleContainer",
					"parentName": "NotificationItemTopContainer",
					"propertyName": "items",
					"values": {
						"id": "notificationItemMiddleContainer",
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"selectors": {
							"wrapEl": "#notificationItemMiddleContainer"
						},
						"wrapClass": ["visa-notification-item-middle-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "NotificationEntity",
					"parentName": "NotificationItemMiddleContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "getNotificationEntity"},
						"classes": {"labelClass": ["subject-text-labelClass", "visa-notification-item-middle"]}
					}
				},
				{
					"operation": "insert",
					"name": "NotificationItemBottomContainer",
					"parentName": "NotificationItemContainer",
					"propertyName": "items",
					"values": {
						"id": "notificationItemBottomContainer",
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"selectors": {
							"wrapEl": "#notificationItemBottomContainer"
						},
						"wrapClass": ["visa-notification-item-bottom-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "NotificationSubjectCaption",
					"parentName": "NotificationItemMiddleContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "getNotificationSubjectCaption"},
						"click": {"bindTo": "onNotificationSubjectClick"},
						"classes": {
							"labelClass": [
								"subject-text-labelClass",
								"label-link",
								"label-url",
								"visa-notification-item-middle"
							]
						},
						"canExecute": {"bindTo": "canBeDestroyed"}
					}
				},
				{
					"operation": "insert",
					"name": "NotificationObjective",
					"parentName": "NotificationItemBottomContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "Objective"}
					}
				}
			]
		};
	});
