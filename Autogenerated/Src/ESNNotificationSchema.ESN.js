define("ESNNotificationSchema", ["ESNNotificationSchemaResources", "RightUtilities", "NetworkUtilities", "FormatUtils",
		"ConfigurationConstants", "ESNConstants", "css!ESNNotificationSchemaCSS"],
	function(resources, RightUtilities, NetworkUtilities, FormatUtils, ConfigurationConstants, ESNConstants) {
		return {
			entitySchemaName: "ESNNotification",
			properties: {
				/**
				 * Name column for ordering notifications.
				 */
				orderingColumnName: "CreatedOn",

				isOrderDirectionDesc: true,

				useUpdateQueryForMarkNotificationAsRead: true
			},
			messages: {
				/**
				 * @message GetActiveTabName
				 * Returns active tab name.
				 */
				"GetActiveTabName": {
					"mode": BPMSoft.MessageMode.PTP,
					"direction": BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message IsCommunicationPanelItemSelect
				 * Returns state of the communication panel item visible.
				 */
				"IsCommunicationPanelItemSelect": {
					"mode": BPMSoft.MessageMode.PTP,
					"direction": BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			methods: {

				//region Methods: Private

				/**
				 * Generates link to image by identifier.
				 * @private
				 * @param {String} imageId Image identifier.
				 * @return {String}
				 */
				getImageSrc: function(imageId) {
					return this.BPMSoft.ImageUrlBuilder.getUrl({
						source: this.BPMSoft.ImageSources.ENTITY_COLUMN,
						params: {
							schemaName: "SysImage",
							columnName: "Data",
							primaryColumnValue: imageId
						}
					});
				},

				/**
				 * Removes html tags from string.
				 * @private
				 * @param {String} value String with html tags.
				 * @return {String}
				 */
				/*jshint ignore:start */
				removeHtmlTags: function(value) {
					value = value.replace(/\t/gi, "");
					value = value.replace(/>\s+</gi, "><");
					if (this.Ext.isWebKit) {
						value = value.replace(/<div>(<div>)+/gi, "<div>");
						value = value.replace(/<\/div>(<\/div>)+/gi, "<\/div>");
					}
					value = value.replace(/<div>\n <\/div>/gi, "\n");
					value = value.replace(/<p>\n/gi, "");
					value = value.replace(/<div>\n/gi, "");
					value = value.replace(/<div><br[\s\/]*>/gi, "");
					value = value.replace(/<br[\s\/]*>\n?|<\/p>|<\/div>/gi, "\n");
					value = value.replace(/<[^>]+>|<\/\w+>/gi, "");
					value = value.replace(/ /gi, " ");
					value = value.replace(/&/gi, "&");
					value = value.replace(/•/gi, " * ");
					value = value.replace(/–/gi, "-");
					value = value.replace(/"/gi, "\"");
					value = value.replace(/«/gi, "\"");
					value = value.replace(/»/gi, "\"");
					value = value.replace(/‹/gi, "<");
					value = value.replace(/›/gi, ">");
					value = value.replace(/™/gi, "(tm)");
					value = value.replace(/</gi, "<");
					value = value.replace(/>/gi, ">");
					value = value.replace(/©/gi, "(c)");
					value = value.replace(/®/gi, "(r)");
					value = value.replace(/\n*$/, "");
					value = value.replace(/&nbsp;/g, " ");
					value = value.replace(/(\n)( )+/, "\n");
					value = value.replace(/(\n)+$/, "");
					return value;
				},
				/*jshint ignore:end */

				/**
				 * Handles new comments and likes.
				 * @private
				 * @param {Object} scope Context of callback function.
				 * @param {Object} response Request result.
				 */
				onSocialMessageReceived: function(scope, response) {
					if (!response) {
						this.generateException(response.errorInfo);
						return;
					}
					if (response.Header.Sender === ESNConstants.WebSocketMessageHeader.ESNNotification) {
						var receivedMessage = this.Ext.decode(response.Body);
						var currentContactId = this.BPMSoft.SysValue.CURRENT_USER_CONTACT.value;
						if (currentContactId === receivedMessage.createdBy.value) {
							return;
						}
						var notifications = this.get("Notifications");
						if (!notifications.contains(receivedMessage.id)) {
							var notification = this.prepareNotification(this.alternateClassName, receivedMessage);
							notifications.add(receivedMessage.id, notification, 0);
							var activeTabName = this.sandbox.publish("GetActiveTabName", null, [this.sandbox.id]);
							var isPanelActive = this.sandbox.publish("IsCommunicationPanelItemSelect", "CenterNotification");
							if (isPanelActive && activeTabName === ESNConstants.ESN.ShortName) {
								notification.markNewNotificationsAsRead(true);
							}
						}
					}
				},

				/**
				 * Checks notification entity permission to view.
				 * @private
				 * @param {Object} config Configuration object.
				 * @param {String} config.entitySchemaUId Entity schema UId.
				 * @param {String} config.entityId Entity record Id
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Execution context.
				 */
				checkCanReadNotificationEntity: function(config, callback, scope) {
					var entitySchemaName = NetworkUtilities.getEntitySchemaName(config.entitySchemaUId);
					RightUtilities.checkCanReadRecords({
						schemaName: entitySchemaName,
						primaryColumnValues: [config.entityId]
					}, function(result) {
						var response = this.isEmpty(result) ? false : result[0];
						if (response && response.Value) {
							this.Ext.callback(callback, scope);
						} else {
							this.showInformationDialog(this.get("Resources.Strings.HasNoRightForRead"));
						}
					}, this);
				},

				/**
				 * Opens notification entity page.
				 * @private
				 * @param {Object} config Configuration object.
				 * @param {String} config.entityId Entity record Id.
				 * @param {Object[]} config.stateObj.valuePairs Data values for notification entity page.
				 */
				openNotificationEntity: function(config) {
					var reloadResult = this.sandbox.publish("ReloadCard", config.stateObj.valuePairs, [config.entityId]);
					if (!reloadResult) {
						NetworkUtilities.openEntityPage(config);
					}
				},

				//endregion

				//region Methods: Protected

				/**
				 * @inheritdoc BPMSoft.BaseNotificationsSchema#prepareCollectionBeforeLoad
				 * @overridden
				 */
				prepareCollectionBeforeLoad: BPMSoft.emptyFn,

				/**
				 * Adding notifications in collection.
				 * @deprecated
				 * @protected
				 * @param notificationsCollection {object} Notifications collection.
				 */
				addNotifications: BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseNotificationsSchema#getNotificationGroup
				 * @overridden
				 */
				getNotificationGroup: function() {
					return ConfigurationConstants.NotificationGroup.EsnNotification;
				},

				/**
				 * @inheritdoc BPMSoft.BaseNotificationsSchema#getNotificationType
				 * @overridden
				 */
				getNotificationType: function() {
					return ESNConstants.ESN.SocialChannelSchemaUId;
				},

				/**
				 * @inheritdoc BPMSoft.BaseNotificationsSchema#addColumns
				 * @overridden
				 */
				addColumns: function(select) {
					select.addColumn("Id");
					select.addColumn("CreatedBy");
					var orderingColumn = select.addColumn(this.orderingColumnName);
					orderingColumn.orderPosition = 0;
					orderingColumn.orderDirection = BPMSoft.OrderDirection.DESC;
					select.addColumn("Type");
					select.addColumn("Owner");
					select.addColumn("IsRead");
					select.addColumn("SocialMessage");
					select.addColumn("SocialMessage.Id", "SocialMessageId");
					select.addColumn("SocialMessage.EntityId", "SocialMessageEntityId");
					select.addColumn("SocialMessage.EntitySchemaUId", "SocialMessageEntitySchemaUId");
					select.addColumn("SocialMessage.Parent");
					select.addColumn("SocialMessage.Parent.Id", "SocialMessageParentId");
					select.addColumn("SocialMessage.Parent.EntityId", "SocialMessageParentEntityId");
					select.addColumn("SocialMessage.Parent.EntitySchemaUId", "SocialMessageParentEntitySchemaUId");
				},

				/**
				 * @inheritdoc BPMSoft.BaseNotificationsSchema#processNotificationsCollection
				 * @overridden
				 */
				processNotificationsCollection: function(notificationsCollection) {
					notificationsCollection.each(function(notification) {
						notification.isNew = false;
						var socialMessageParams = {
							id: notification.get("SocialMessageId"),
							entityId: notification.get("SocialMessageEntityId"),
							entitySchemaUId: notification.get("SocialMessageEntitySchemaUId"),
							parent: {
								id: notification.get("SocialMessageParentId"),
								entityId: notification.get("SocialMessageParentEntityId"),
								entitySchemaUId: notification.get("SocialMessageParentEntitySchemaUId")
							}
						};
						notification.set("SocialMessageParams", socialMessageParams);
						notification.setColumnValues(notification, {preventValidation: true});
					}, this);
				},

				/**
				 * @inheritdoc BPMSoft.BaseNotificationsSchema#subscribeEvents
				 * @overridden
				 */
				subscribeEvents: function() {
					this.BPMSoft.ServerChannel.on(BPMSoft.EventName.ON_MESSAGE, this.onSocialMessageReceived, this);
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc BPMSoft.BaseNotificationsSchema#unSubscribeEvents
				 * @overridden
				 */
				unSubscribeEvents: function() {
					this.BPMSoft.ServerChannel.un(BPMSoft.EventName.ON_MESSAGE, this.onSocialMessageReceived, this);
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc BPMSoft.BaseNotificationsSchema#getCurrentUserContactColumnName
				 * @overridden
				 */
				getCurrentUserContactColumnName: function() {
					return "Owner";
				},

				/**
				 * @inheritdoc BPMSoft.BaseNotificationsSchema#initNotificationTypeFilter
				 * @overridden
				 */
				initNotificationTypeFilter: BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseNotificationsSchema#initUpdateFilters
				 * @overridden
				 */
				initUpdateFilters: function(update) {
					this.callParent(arguments);
					this.initSocialMessageFilter(update.filters);
				},

				/**
				 * Initializes SocialMessage column not null filter.
				 * @protected
				 * @param {Object} filters Query filters.
				 */
				initSocialMessageFilter: function(filters) {
					filters.add("SocialMessageFilter", BPMSoft.createColumnIsNotNullFilter("SocialMessage"));
				},

				/**
				 * Gets notification social message.
				 * @protected
				 * @param {Object} notification Notification.
				 * @return {Object}
				 */
				getNotificationSocialMessage: function(notification) {
					var socialMessage = notification.get("SocialMessageParams");
					if (socialMessage.parent && this.isNotEmpty(socialMessage.parent.id) &&
							!this.BPMSoft.isEmptyGUID(socialMessage.parent.id)) {
						socialMessage = socialMessage.parent;
					}
					return socialMessage;
				},

				/**
				 * Gets default notifications entity value pairs.
				 * @protected
				 * @return {Object[]}
				 */
				getDefaultNotificationValuePairs: function() {
					var valuePairs = [{
						name: "DefaultTabName",
						value: "ESNTab"
					}];
					return valuePairs;
				},

				/**
				 * Reads notification and updates notification counter.
				 * @protected
				 * @param {Object} notification Notification.
				 */
				setNotificationAsRead: function(notification) {
					var notificationIsRead = notification.get("IsRead");
					if (!notificationIsRead) {
						notification.set("IsRead", true);
						notification.saveEntity(function() {
							this.sandbox.publish("UpdateCounters");
						}, this);
					}
				},

				//endregion

				//region Methods: Public

				/**
				 * @obsolete
				 */
				getDateFormat: function() {
					var cultureSettings = this.BPMSoft.Resources.CultureSettings;
					var createdOnTemplate = this.get("Resources.Strings.CreatedOnDateFormat");
					return this.Ext.String.format(createdOnTemplate, cultureSettings.dateFormat,
						cultureSettings.timeFormat);
				},

				/**
				 * Generates link to notification author avatar.
				 * @return {String}
				 */
				getAuthorImageSrc: function() {
					var author = this.get("CreatedBy");
					if (this.Ext.isEmpty(author) || this.Ext.isEmpty(author.primaryImageValue) ||
							this.BPMSoft.isEmptyGUID(author.primaryImageValue)) {
						return this.getDefaultImageURL();
					}
					return this.getImageSrc(author.primaryImageValue);
				},

				/**
				 * Generates link to notification icon type.
				 * @return {String}
				 */
				getTypeImageSrc: function() {
					var type = this.get("Type");
					if (this.Ext.isEmpty(type) || this.Ext.isEmpty(type.primaryImageValue) ||
							this.BPMSoft.isEmptyGUID(type.primaryImageValue)) {
						return "";
					}
					return this.getImageSrc(type.primaryImageValue);
				},

				/**
				 * Generates notification action text.
				 * @return {String}
				 */
				getTypeText: function() {
					var type = this.get("Type");
					if (!this.Ext.isEmpty(type)) {
						return type.displayValue;
					}
					return "";
				},

				/**
				 * Generates notification author text link.
				 * @return {String}
				 */
				getCreatedBy: function() {
					var author = this.get("CreatedBy");
					return author ? author.displayValue : "";
				},

				/**
				 * Generates notification creation date.
				 * @return {String}
				 */
				getCreatedOn: function() {
					var createdOn = this.get("CreatedOn");
					return FormatUtils.smartFormatDate(createdOn);
				},

				/**
				 * Opens notification author page.
				 */
				openAuthorPage: function() {
					var author = this.get("CreatedBy");
					if (this.Ext.isEmpty(author)) {
						return;
					}
					var hash = NetworkUtilities.getEntityUrl("Contact", author.value);
					this.sandbox.publish("PushHistoryState", {hash: hash});
					return false;
				},

				/**
				 * Generates message text, which was formed by a notification.
				 * @return {String}
				 */
				getSocialMessageText: function() {
					var wordsCount = 7;
					var resultTemplate = "\"{0}{1}\"";
					var socialMessage = this.get("SocialMessage");
					if (this.isEmpty(socialMessage)) {
						return;
					}
					var message = socialMessage.displayValue;
					var plainMessage = this.removeHtmlTags(message);
					var regexp = /\s/;
					var words = plainMessage.split(regexp);
					var textTokens = [];
					var ellipsis = "";
					this.BPMSoft.each(words, function(word) {
						if (!this.Ext.isEmpty(word)) {
							if (textTokens.length < wordsCount) {
								textTokens.push(word);
							} else {
								ellipsis = "...";
							}
						}
					}, this);
					var result = this.Ext.String.format(resultTemplate, textTokens.join(" "), ellipsis);
					return BPMSoft.utils.string.decodeHtml(result);
				},

				/**
				 * Generates notification text.
				 * @return {String}
				 */
				getNotificationMessageText: function() {
					var template = " {0}: {1}";
					var typeText = this.getTypeText();
					var socialMessageText = this.getSocialMessageText();
					return this.Ext.String.format(template, typeText, socialMessageText);
				},

				/**
				 * @inheritdoc BPMSoft.BaseNotificationsSchema#getNotificationsSelectFilters
				 * @overridden
				 */
				getNotificationsSelectFilters: function() {
					var sysValue = this.BPMSoft.SysValue,
							comparisonType = this.BPMSoft.ComparisonType,
							filters = this.BPMSoft.createFilterGroup(),
							currentContactId = sysValue.CURRENT_USER_CONTACT.value;
					this.initCurrentUserContactFilter(filters);
					filters.add("notCreatedByCurrentContactFilter", this.BPMSoft.createColumnFilterWithParameter(
							comparisonType.NOT_EQUAL, "CreatedBy", currentContactId));
					this.initSocialMessageFilter(filters);
					return filters;
				},

				/**
				 * Handles item click.
				 * @param {String} id Notification id.
				 */
				onItemClick: function(id) {
					var esnNotifications = this.get("Notifications");
					var notification = esnNotifications.get(id);
					this.setNotificationAsRead(notification);
					var socialMessage = this.getNotificationSocialMessage(notification);
					var valuePairs = this.getDefaultNotificationValuePairs();
					valuePairs.push({
						name: "ActiveSocialMessageId",
						value: socialMessage.id
					});
					var config = {
						sandbox: this.sandbox,
						entityId: socialMessage.entityId,
						entitySchemaUId: socialMessage.entitySchemaUId,
						stateObj: {
							valuePairs: valuePairs
						}
					};
					this.BPMSoft.chain(function(next) {
						this.checkCanReadNotificationEntity(config, next, this);
					}, function() {
						this.openNotificationEntity(config);
					}, this);
				},

				/**
				 * Prepares incoming message to notification.
				 * @param {Function|String} viewModelClass Notification view model class.
				 * @param {Object} message Incoming message.
				 * @return {Object} Notification.
				 */
				prepareNotification: function(viewModelClass, message) {
					var notification = this.Ext.create(viewModelClass, {
						Ext: this.Ext,
						sandbox: this.sandbox,
						BPMSoft: this.BPMSoft
					});
					notification.set("Id", message.id);
					notification.set("IsRead", false);
					notification.set("CreatedBy", message.createdBy);
					notification.set("CreatedOn", this.BPMSoft.parseDate(message.createdOn));
					notification.set("SocialMessage", message.socialMessage);
					notification.set("SocialMessageParams", message.socialMessage);
					notification.set("Type", message.type);
					notification.isNew = false;
					return notification;
				},

				/**
				 * Returns default image url.
				 * @return {String} Default image url.
				 */
				getDefaultImageURL: function() {
					return BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.DefaultPhoto);
				}

				//endregion

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "NotificationItemContainer",
					"parentName": "Notification",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["esn-notification-item-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ESNNotificationImage",
					"parentName": "NotificationItemContainer",
					"propertyName": "items",
					"values": {
						"getSrcMethod": "getAuthorImageSrc",
						"onPhotoChange": BPMSoft.emptyFn,
						"readonly": true,
						"classes": {"wrapClass": ["author-image-container"]},
						"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
						"onImageClick": {bindTo: "openAuthorPage"}
					}
				},
				{
					"operation": "insert",
					"name": "ESNNotificationMessage",
					"parentName": "NotificationItemContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": {"wrapClassName": ["message-container"]},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ESNNotificationMessageText",
					"parentName": "ESNNotificationMessage",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": {"wrapClassName": ["message-text-container"]},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "ESNNotificationMessageText",
					"propertyName": "items",
					"name": "CreatedByLabel",
					"values": {
						"itemType": BPMSoft.ViewItemType.HYPERLINK,
						"caption": {bindTo: "getCreatedBy"},
						"click": {bindTo: "openAuthorPage"},
						"linkMouseOver": {bindTo: "linkMouseOver"},
						"tag": {
							"columnName": "CreatedBy",
							"referenceSchemaName": "Contact"
						},
						"classes": {
							"hyperlinkClass": ["link", "message-created-by"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "ESNNotificationMessageText",
					"propertyName": "items",
					"name": "ActionTextLabel",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"classes": {
							"labelClass": ["message-type-text"]
						},
						"caption": {bindTo: "getNotificationMessageText"}
					}
				},
				{
					"operation": "insert",
					"name": "ESNNotificationMessageLabels",
					"parentName": "ESNNotificationMessage",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": {"wrapClassName": ["message-labels-container"]},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "ESNNotificationMessageLabels",
					"propertyName": "items",
					"name": "TypeIcon",
					"values": {
						"getSrcMethod": "getTypeImageSrc",
						"onPhotoChange": BPMSoft.emptyFn,
						"readonly": true,
						"classes": {"wrapClass": ["type-image-container"]},
						"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage"
					}
				},
				{
					"operation": "insert",
					"parentName": "ESNNotificationMessageLabels",
					"propertyName": "items",
					"name": "CreatedOnLabel",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"classes": {
							"labelClass": ["message-created-on"]
						},
						"caption": {bindTo: "getCreatedOn"}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
