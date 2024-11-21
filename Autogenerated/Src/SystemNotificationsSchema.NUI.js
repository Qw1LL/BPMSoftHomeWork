define("SystemNotificationsSchema", ["SystemNotificationsSchemaResources", "ConfigurationConstants"],
	function(resources, ConfigurationConstants) {
		return {
			entitySchemaName: "Reminding",
			methods: {
				/**
				 * @inheritdoc BPMSoft.BaseNotificationsSchema#init
				 * @overridden
				 */
				init: function() {
					var isSkipUpdateCounters = true;
					this.callParent(arguments);
					this.markNewNotificationsAsRead(isSkipUpdateCounters);
				},

				/**
				 * @inheritdoc BPMSoft.BaseNotificationsSchema#getNotificationType
				 * @overridden
				 */
				getNotificationType: function() {
					return ConfigurationConstants.Reminding.Notification;
				},

				/**
				 * @inheritdoc BPMSoft.BaseNotificationsSchema#getNotificationGroup
				 * @overridden
				 */
				getNotificationGroup: function() {
					return ConfigurationConstants.NotificationGroup.Notification;
				}
			},
			diff: [
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
						"wrapClass": ["system-notification-item-container"],
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
						"wrapClass": ["system-notification-item-top-container"],
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
						"classes": {"wrapClass": ["system-notification-icon-class"]},
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
					"name": "NotificationEntity",
					"parentName": "NotificationItemTopContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "getNotificationEntity"},
						"classes": {"labelClass": ["subject-text-labelClass"]}
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
						"wrapClass": ["system-notification-item-bottom-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "NotificationSubjectCaption",
					"parentName": "NotificationItemBottomContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "getNotificationSubjectCaption"},
						"click": {"bindTo": "onNotificationSubjectClick"},
						"classes": {"labelClass": ["subject-text-labelClass", "label-link", "label-url"]},
						"domAttributes": {"bindTo": "getNotificationLinkAttributes"}
					}
				}
			]
		};
	});
