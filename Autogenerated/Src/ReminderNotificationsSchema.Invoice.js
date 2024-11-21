define("ReminderNotificationsSchema", ["ReminderNotificationsSchemaResources"],
	function() {
		return {
			entitySchemaName: "Reminding",
			methods: {

				/**
				 * Returns item check for invoice notification.
				 * @return {Boolean} Is invoice notification.
				 */
				getIsInvoiceNotification: function() {
					return this.get("SchemaName") === "Invoice";
				},

				/**
				 * @inheritdoc BPMSoft.BaseNotificationsSchema#addColumns
				 * @overridden
				 */
				addColumns: function(select) {
					this.callParent(arguments);
					select.addColumn("[Invoice:Id:SubjectId].Contact", "InvoiceContact");
					select.addColumn("[Invoice:Id:SubjectId].Account", "InvoiceAccount");
					select.addColumn("[Invoice:Id:SubjectId].>[InvoicePaymentStatus:Id:PaymentStatus].FinalStatus",
						"InvoiceFinalStatus");
					select.addColumn("[Invoice:Id:SubjectId].>[InvoicePaymentStatus:Id:PaymentStatus].Name",
						"InvoiceFinalStatusName");
				},

				/**
				 * Returns true if invoice status is not final, false - otherwise.
				 * @return {Boolean}
				 */
				getInvoiceStatusIsNotFinal: function() {
					return this.get("InvoiceFinalStatus") === false;
				},

				/**
				 * @inheritDoc BPMSoft.ReminderNotificationsSchema#getNotificationStatusName
				 * @override
				 */
				getNotificationStatusName: function() {
					return this.getIsInvoiceNotification() ?
						this.$InvoiceFinalStatusName :
						this.callParent(arguments);
				}
			},
			diff: [
				{
					"operation": "insert",
					"name": "NotificationInvoiceItemContainer",
					"parentName": "Notification",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": [
							"reminder-notification-item-container",
							"reminder-notification-invoice-item-container"
						],
						"visible": {"bindTo": "getIsInvoiceNotification"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "NotificationItemInvoiceTopContainer",
					"parentName": "NotificationInvoiceItemContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["reminder-notification-item-top-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "NotificationInvoiceImage",
					"parentName": "NotificationItemInvoiceTopContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"className": "BPMSoft.ImageView",
						"imageSrc": {"bindTo": "getNotificationImage"},
						"classes": {"wrapClass": ["reminder-notification-icon-class"]}
					}
				},
				{
					"operation": "insert",
					"name": "NotificationItemInvoiceBottomContainer",
					"parentName": "NotificationInvoiceItemContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["reminder-notification-item-bottom-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "NotificationInvoiceCaption",
					"parentName": "NotificationItemInvoiceTopContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "Resources.Strings.InvoiceCaption"},
						"classes": {"labelClass": ["subject-text-labelClass"]}
					}
				},
				{
					"operation": "insert",
					"name": "NotificationInvoiceSubject",
					"parentName": "NotificationItemInvoiceTopContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "getNotificationSubjectCaption"},
						"click": {"bindTo": "onNotificationSubjectClick"},
						"classes": {"labelClass": ["subject-text-labelClass", "label-link", "label-url"]}
					}
				},
				{
					"operation": "insert",
					"name": "NotificationDate",
					"parentName": "NotificationItemInvoiceTopContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "getNotificationDate"},
						"classes": {"labelClass": ["subject-text-labelClass"]}
					}
				},
				{
					"operation": "insert",
					"name": "NotificationStatus",
					"parentName": "NotificationItemInvoiceTopContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "getNotificationStatusName"},
						"classes": {"labelClass": ["subject-text-labelClass"]}
					}
				},
				{
					"operation": "insert",
					"name": "NotificationAccountCaption",
					"parentName": "NotificationItemInvoiceBottomContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.HYPERLINK,
						"caption": {"bindTo": "getNotificationAccount"},
						"click": {"bindTo": "openCard"},
						"visible": {"bindTo": "getIsNotificationAccountShown"},
						"linkMouseOver": {"bindTo": "linkMouseOver"},
						"tag": {
							"columnName": "InvoiceAccount",
							"referenceSchemaName": "Account"
						},
						"classes": {"labelClass": ["subject-text-labelClass", "label-link", "label-url"]}
					}
				},
				{
					"operation": "insert",
					"name": "NotificationContactCaption",
					"parentName": "NotificationItemInvoiceBottomContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.HYPERLINK,
						"caption": {"bindTo": "getNotificationContact"},
						"click": {"bindTo": "openCard"},
						"linkMouseOver": {"bindTo": "linkMouseOver"},
						"tag": {
							"columnName": "InvoiceContact",
							"referenceSchemaName": "Contact"
						},
						"classes": {"labelClass": ["subject-text-labelClass", "label-link", "label-url"]}
					}
				},
				{
					"operation": "insert",
					"name": "ActionsButtonPostpone",
					"parentName": "NotificationInvoiceItemContainer",
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
						"visible": {"bindTo": "getInvoiceStatusIsNotFinal"}
					}
				}
			]
		};
	});
