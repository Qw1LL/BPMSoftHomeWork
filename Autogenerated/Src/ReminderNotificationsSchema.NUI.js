define("ReminderNotificationsSchema", ["ReminderNotificationsSchemaResources", "ConfigurationConstants",
		"RemindingsUtilities"],
	function(resources, ConfigurationConstants, RemindingsUtilities) {
		return {
			entitySchemaName: "Reminding",
			methods: {
				/**
				 * @inheritdoc BPMSoft.BaseNotificationsSchema#getNotificationType
				 * @overridden
				 */
				getNotificationType: function() {
					return ConfigurationConstants.Reminding.Reminding;
				},

				/**
				 * @inheritdoc BPMSoft.BaseNotificationsSchema#getNotificationGroup
				 * @overridden
				 */
				getNotificationGroup: function() {
					return ConfigurationConstants.NotificationGroup.Reminding;
				},

				/**
				 * Returns a menu button configuration.
				 * @param {String} bindToFunction The function name which is assigned to a menu item.
				 * @private
				 * @return {BPMSoft.BaseViewModelCollection} Menu button configuration.
				 */
				getNotificationActionButtonMenuItems: function(bindToFunction) {
					var menuItems = this.Ext.create("BPMSoft.BaseViewModelCollection");
					var menuItemsConfig = {
						"5": this.get("Resources.Strings.MenuItem5MinCaption"),
						"10": this.get("Resources.Strings.MenuItem10MinCaption"),
						"30": this.get("Resources.Strings.MenuItem30MinCaption"),
						"60": this.get("Resources.Strings.MenuItem1HourCaption"),
						"120": this.get("Resources.Strings.MenuItem2HourCaption"),
						"1440": this.get("Resources.Strings.MenuItem1DayCaption")
					};
					this.BPMSoft.each(menuItemsConfig, function(caption, time) {
						var buttonMenuItem = this.getButtonMenuItem({
							"Caption": caption,
							"Click": {"bindTo": bindToFunction},
							"Tag": time,
							"MarkerValue": caption
						});
						menuItems.addItem(buttonMenuItem);
					}, this);
					return menuItems;
				},

				/**
				 * Returns item check for activity notification.
				 * @return {Boolean} Is activity notification.
				 */
				getIsActivityNotification: function() {
					return this.get("SchemaName") === "Activity";
				},

				/**
				 * @inheritdoc BPMSoft.BaseNotificationsSchema#getNotificationImage
				 * @overridden
				 */
				getNotificationImage: function() {
					var url = this.callParent(arguments);
					var category = this.get("Category");
					var activityCategories = ConfigurationConstants.Activity.ActivityCategory;
					if (category) {
						var imageResource;
						switch (category.value) {
							case activityCategories.Call:
								imageResource = this.get("Resources.Images.CallActivityImage");
								break;
							case activityCategories.CallAsTask:
								imageResource = this.get("Resources.Images.CallActivityImage");
								break;
							case activityCategories.PaperWork:
								imageResource = this.get("Resources.Images.PaperWorkActivityImage");
								break;
							case activityCategories.Meeting:
								imageResource = this.get("Resources.Images.MeetingActivityImage");
								break;
							default:
								imageResource = this.get("Resources.Images.DefaultActivityImage");
								break;
						}
						url = imageResource ? this.BPMSoft.ImageUrlBuilder.getUrl(imageResource) : url;
					}
					return url;
				},

				/**
				 * Returns activity account if it is.
				 * @private
				 * @return {String} Account name.
				 */
				getNotificationAccount: function() {
					var schemaName = this.get("SchemaName");
					var account = this.get(schemaName + "Account");
					return account ? account.displayValue : "";
				},

				/**
				 * Returns activity contact if it is.
				 * @private
				 * @return {String} Contact name.
				 */
				getNotificationContact: function() {
					var schemaName = this.get("SchemaName");
					var contact = this.get(schemaName + "Contact");
					return contact ? contact.displayValue : "";
				},

				/**
				 * Opens reference entity card.
				 * @private
				 */
				openCard: function() {
					var tag = arguments[arguments.length - 1];
					if (!this.Ext.isEmpty(tag)) {
						var referenceSchemaValue = this.get(tag.columnName);
						if (referenceSchemaValue) {
							this.openNotificationEntityCard(tag.referenceSchemaName, referenceSchemaValue.value);
						}
					}
				},

				/**
				 * @inheritdoc BPMSoft.BaseNotificationsSchema#addColumns
				 * @overridden
				 */
				addColumns: function(select) {
					this.callParent(arguments);
					select.addColumn("[Activity:Id:SubjectId].Contact", "ActivityContact");
					select.addColumn("[Activity:Id:SubjectId].Account", "ActivityAccount");
					select.addColumn("[Activity:Id:SubjectId].ActivityCategory", "Category");
					select.addColumn("[Activity:Id:SubjectId].>[ActivityStatus:Id:Status].Finish", "Finish");
					select.addColumn("[Activity:Id:SubjectId].>[ActivityStatus:Id:Status].Name", "StatusName");
				},

				/**
				 * @inheritdoc BPMSoft.BaseNotificationsSchema#getNotificationSubjectCaption
				 * @overridden
				 */
				getNotificationSubjectCaption: function() {
					var caption = this.get("SubjectCaption");
					if (this.getIsFeatureEnabled("NotificationV2")) {
						caption = this.get("Description") || caption;
					}
					if (!this.Ext.isEmpty(caption)) {
						caption = (caption.length > 90) ? caption.substr(0, 90) + "..." : caption;
					}
					return caption;
				},

				/**
				 * Returns entity notification status name.
				 * @return {String} Entity notification status name.
				 */
				getNotificationStatusName: function() {
					return this.$StatusName;
				},

				/**
				 * Returns comma.
				 * @protected
				 * @return {String} Comma.
				 */
				getComma: function() {
					return this.get("Resources.Strings.Comma");
				},

				/**
				 * Returns entity notification status name caption.
				 * @return {String} Entity notification status name caption.
				 */
				getNotificationStatusCaption: function() {
					return this.getNotificationStatusName();
				},

				/**
				 * @inheritDoc BPMSoft.BaseNotificationsSchema#getNotificationDate
				 * @override
				 */
				getNotificationDate: function() {
					return this.callParent(arguments);
				},

				/**
				 * Returns entity notification date and status name caption
				 * @return {String} Entity notification date and status name caption
				 */
				getNotificationDateAndStatusCaption: function() {
					return this.getNotificationDate() + this.getComma() + ' ' + this.getNotificationStatusCaption();
				},

				/**
				 * Returns check for notification caption visibility.
				 * @return {Boolean} Is notification caption visible.
				 */
				getIsNotificationAccountShown: function() {
					return this._isExistsDisplayColumnValue("Account");
				},

				/**
				 * Signs of exists display column value.
				 * @private
				 */
				_isExistsDisplayColumnValue: function(columnName) {
					var schemaName = this.get("SchemaName");
					var schemaColumnName = this.get(schemaName + columnName);
					return Boolean(schemaColumnName && schemaColumnName.displayValue);
				},

				/**
				 * Signs of exists whether in notification contact or account.
				 * @return {Boolean} True if contact or account is exists, false otherwise.
				 */
				getIsNotificationAccountOrContactShown: function() {
					return this.getIsNotificationAccountShown() || this._isExistsDisplayColumnValue("Contact");
				},

				/**
				 * Signs of exists in notification contact and account.
				 * @return {Boolean} True if contact and account is exists, false otherwise.
				 */
				getIsNotificationAccountAndContactShown: function() {
					return this.getIsNotificationAccountShown() && this._isExistsDisplayColumnValue("Contact");
				},

				/**
				 * Sets new time for reminder.
				 * @param {BPMSoft.UpdateQuery} updateQuery Update query.
				 * @param {Number} minutesOffset Offset in minutes.
				 */
				setNewTimeForReminder: function(updateQuery, minutesOffset) {
					var newTime = this.Ext.Date.add(
							new Date(Date.now()),
							this.Ext.Date.MINUTE,
							parseInt(minutesOffset, 0)
					);
					updateQuery.setParameterValue("RemindTime", newTime, this.BPMSoft.DataValueType.DATE_TIME);
				},

				/**
				 * Handles the event menu "Postpone".
				 * @param {Object} minutesOffset Element menu button which was caused by.
				 * @private
				 */
				postpone: function(minutesOffset) {
					var updateQuery = this.getUpdateQuery();
					this.addIdFilter(updateQuery);
					this.setNewTimeForReminder(updateQuery, minutesOffset);
					this._setIsNeedToSendForReminder(updateQuery, true);
					this.executeOperation(updateQuery, this.removeReminder);
				},

				/**
				 * Handles the event menu "PostponeAll".
				 * @param {Object} minutesOffset Element menu button which was caused by.
				 * @private
				 */
				postponeAll: function(minutesOffset) {
					var notifications = this.get("Notifications");
					if (notifications.isEmpty()) {
						return;
					}
					var question = this.get("Resources.Strings.PostponeAllNotificationsQuestion");
					this.showConfirmationForOperation(question, function() {
						var updateQuery = this.getUpdateQuery();
						this.addByAllFilter(updateQuery);
						this.setNewTimeForReminder(updateQuery, minutesOffset);
						this._setIsNeedToSendForReminder(updateQuery, true);
						this.executeOperation(updateQuery, this.clearNotifications);
					});
				},

				/**
				 * Sets flag of reminder needs to be sent.
				 * @param {Object} updateQuery - update query.
				 * @param {Boolean} isNeedToSend - reminder needs to be sent flag.
				 * @private
				 */
				_setIsNeedToSendForReminder: function(updateQuery, isNeedToSend) {
					updateQuery.setParameterValue("IsNeedToSend", isNeedToSend, this.BPMSoft.DataValueType.BOOLEAN);
				},

				/**
				 * Cancels notification. In this operation a notification record deleted from the database.
				 * @private
				 */
				cancel: function() {
					var deleteQuery = this.getDeleteQuery();
					this.addIdFilter(deleteQuery);
					this.executeOperation(deleteQuery, this.removeReminder);
				},

				/**
				 * Cancels all notifications. This operation deletes all record of the current user from the database.
				 * @private
				 */
				cancelAll: function() {
					var notifications = this.get("Notifications");
					if (notifications.isEmpty()) {
						return;
					}
					var question = this.get("Resources.Strings.CancelAllNotificationsQuestion");
					this.showConfirmationForOperation(question, function() {
						var deleteQuery = this.getDeleteQuery();
						this.addByAllFilter(deleteQuery);
						this.executeOperation(deleteQuery, this.clearNotifications);
					});
				},

				/**
				 * Shows window with confirmation.
				 * @param {String} message Confirmation message.
				 * @param {Function} callback Callback function.
				 * @protected
				 */
				showConfirmationForOperation: function(message, callback) {
					this.showConfirmationDialog(message, function(returnCode) {
						if (returnCode === this.BPMSoft.MessageBoxButtons.YES.returnCode) {
							this.Ext.callback(callback, this);
						}
					}, [this.BPMSoft.MessageBoxButtons.YES.returnCode,
						this.BPMSoft.MessageBoxButtons.NO.returnCode], this.parentViewModel, null);
				},

				/**
				 * Executes a query operation.
				 * @param {BPMSoft.EntitySchemaQuery} query Query of operation.
				 * @param {Function} callback Callback function.
				 * @protected
				 */
				executeOperation: function(query, callback) {
					query.execute(function(response) {
						if (response.success) {
							this.Ext.callback(callback, this);
						} else {
							this.generateException(response.errorInfo);
						}
					}, this);
				},

				/**
				 * Returns delete query.
				 * @return {BPMSoft.DeleteQuery} Delete query.
				 */
				getDeleteQuery: function() {
					var deleteQuery = Ext.create("BPMSoft.DeleteQuery", {
						rootSchemaName: "Reminding"
					});
					return deleteQuery;
				},

				/**
				 * Returns update query.
				 * @return {BPMSoft.UpdateQuery} Update query.
				 */
				getUpdateQuery: function() {
					var updateQuery = Ext.create("BPMSoft.UpdateQuery", {
						rootSchemaName: "Reminding"
					});
					return updateQuery;
				},

				/**
				 * Adds filter by identifier.
				 * @param {BPMSoft.EntitySchemaQuery} query Query for filter.
				 * @protected
				 */
				addIdFilter: function(query) {
					var idFilter = this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
							"Id", this.get("Id"));
					query.filters.add("IdFilter", idFilter);
				},

				/**
				 * Adds filter by identifier.
				 * @param {BPMSoft.EntitySchemaQuery} query Query for filter.
				 * @protected
				 */
				addByAllFilter: function(query) {
					var allFilter = RemindingsUtilities.remindingFilters();
					allFilter.addItem(this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "NotificationType", this.getNotificationType()));
					query.filters.add("AllFilter", allFilter);
				},

				/**
				 * Clears notifications. Informs subscribers about the need recount the number of notifications.
				 * @protected
				 */
				clearNotifications: function() {
					var scope = this.parentViewModel || this;
					var notificationsCollection = scope.get("Notifications");
					notificationsCollection.clear();
					this.removeNotificationCounters();
					if (this.get("NotificationV2Enabled")) {
						this.sandbox.publish("UpdateCounterValues", this.getUpdateCounterConfig());
					} else {
						this.sandbox.publish("UpdateCounters");
					}
				},

				/**
				 * Deletes the record from the registry of notifications. Informs subscribers about the need
				 * recount the number of notifications.
				 * @protected
				 */
				removeReminder: function() {
					var scope = this.parentViewModel || this;
					var notificationId = this.get("Id");
					this.removeNotification.call(scope, notificationId);
				},

				/**
				 * Returns true if activity is not finish, false - otherwise.
				 * @return {Boolean}
				 */
				getActivityIsNotFinish: function() {
					return this.get("Finish") === false;
				}
			},
			diff: [
				{
					"operation": "insert",
					"name": "MainActionsButtonContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["main-actions-button-container"],
						"items": []
					},
					"index": 0
				},
				{
					"operation": "insert",
					"name": "MainActionsButtonPostponeAll",
					"parentName": "MainActionsButtonContainer",
					"propertyName": "items",
					"values": {
						"caption": {"bindTo": "Resources.Strings.PostponeAllMenuItemCaption"},
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"menu": {
							"items": {"bindTo": "getNotificationActionButtonMenuItems"},
							"tag": "postponeAll"
						},
						"classes": {
							"wrapperClass": ["postpone-all-class"],
							"menuClass": ["postpone-all-menuClass"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "MainActionsButtonCancelAll",
					"parentName": "MainActionsButtonContainer",
					"propertyName": "items",
					"values": {
						"caption": {"bindTo": "Resources.Strings.CancelAllMenuItemCaption"},
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"click": {"bindTo": "cancelAll"},
						"classes": {"textClass": ["cancel-all-class"]}
					}
				},
				{
					"operation": "insert",
					"name": "NotificationActivityItemContainer",
					"parentName": "Notification",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": [
							"reminder-notification-item-container",
							"reminder-notification-activity-item-container"
						],
						"visible": {"bindTo": "getIsActivityNotification"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "NotificationItemActivityTopContainer",
					"parentName": "NotificationActivityItemContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["reminder-notification-item-top-container"],
						"items": [
							{
								"name": "NotificationImageAndInfoWrapper",
								"itemType": BPMSoft.ViewItemType.CONTAINER,
								"wrapClass": ["reminder-notification-item-image-info-container"],
								"items": [
									{
										"name": "NotificationActivityImage",
										"itemType": BPMSoft.ViewItemType.COMPONENT,
										"className": "BPMSoft.ImageView",
										"imageSrc": {"bindTo": "getNotificationImage"},
										"classes": {"wrapClass": ["reminder-notification-icon-class"]}
									},
									{
										"name": "NotificationInfoWrapper",
										"itemType": BPMSoft.ViewItemType.CONTAINER,
										"wrapClass": ["reminder-notification-item-info-container"],
										"items": [
											{
												"name": "NotificationContactCaption",
												"itemType": BPMSoft.ViewItemType.HYPERLINK,
												"caption": {"bindTo": "getNotificationContact"},
												"click": {"bindTo": "openCard"},
												"linkMouseOver": {"bindTo": "linkMouseOver"},
												"tag": {
													"columnName": "ActivityContact",
													"referenceSchemaName": "Contact"
												},
												"classes": {"hyperlinkClass": ["notification-header", "subject-text-labelClass", "label-link", "label-url"]}
											},
											{
												"name": "NotificationSubjectCaption",
												"itemType": BPMSoft.ViewItemType.HYPERLINK,
												"caption": {"bindTo": "getNotificationAccount"},
												"click": {"bindTo": "openCard"},
												"visible": {"bindTo": "getIsNotificationAccountShown"},
												"linkMouseOver": {"bindTo": "linkMouseOver"},
												"tag": {
													"columnName": "ActivityAccount",
													"referenceSchemaName": "Account"
												},
												"classes": {"hyperlinkClass": ["notification-header", "subject-text-labelClass", "label-link", "label-url"]}
											},
											{
												"name": "NotificationDateAndStatus",
												"itemType": BPMSoft.ViewItemType.LABEL,
												"caption": {"bindTo": "getNotificationDateAndStatusCaption"},
												"classes": {"labelClass": ["subject-text-labelClass"]}
											}
										]
									}
								]
							},
						]
					}
				},
				{
					"operation": "insert",
					"name": "NotificationItemActivityBottomContainer",
					"parentName": "NotificationActivityItemContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["reminder-notification-item-bottom-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "NotificationActivitySubject",
					"parentName": "NotificationItemActivityBottomContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.HYPERLINK,
						"caption": {"bindTo": "getNotificationSubjectCaption"},
						"click": {"bindTo": "onNotificationSubjectClick"},
						"linkMouseOver": {"bindTo": "linkMouseOver"},
						"tag": {
							"columnName": "SubjectId",
							"referenceSchemaName": "Activity"
						},
						"classes": {"labelClass": ["subject-text-labelClass", "label-link", "label-url"]}
					}
				},
				{
					"operation": "insert",
					"name": "ActionsButtonPostpone",
					"parentName": "NotificationActivityItemContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"classes": {
							"wrapperClass": ["notificationActionButtonWrap-class"]
						},
						"markerValue": "RemindingActionsMenu",
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"menu": {
							"items": [{
								"caption": {"bindTo": "Resources.Strings.PostponeMenuItemCaption"},
								"markerValue": {"bindTo": "Resources.Strings.PostponeMenuItemCaption"},
								"menu": {
									"items": {"bindTo": "getNotificationActionButtonMenuItems"},
									"tag": "postpone"
								}
							}, {
								"caption": {"bindTo": "Resources.Strings.CancelMenuItemCaption"},
								"markerValue": {"bindTo": "Resources.Strings.CancelMenuItemCaption"},
								"click": {"bindTo": "cancel"}
							}]
						},
						"visible": {"bindTo": "getActivityIsNotFinish"}
					}
				}
			]
		};
	});
