define("SubscriberCommunicationItem", ["BPMSoft"],
	function(BPMSoft) {
		return {
			attributes: {

				/**
				 * ############# ######## #####.
				 * @private
				 * @type {String}
				 */
				"Id": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": ""
				},

				/**
				 * ### ######## #####.
				 * @private
				 * @type {String}
				 */
				"Type": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": ""
				},

				/**
				 * ##### ########.
				 * @private
				 * @type {String}
				 */
				"Number": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": ""
				},

				/**
				 * ############# ########.
				 * @private
				 * @type {String}
				 */
				"SubscriberId": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": ""
				},

				/**
				 * ###### CTI ######.
				 * @private
				 * @type {BPMSoft.CtiModel}
				 */
				"CtiModel": {
					"dataValueType": BPMSoft.DataValueType.CUSTOM_OBJECT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": null
				},

				/**
				 * Sign that indicates is connection to telephony server available.
				 * @private
				 * @type {Boolean}
				 */
				"IsTelephonyAvailable": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"value": true
				}

			},
			methods: {

				/**
				 * ######### ###### ## ####### ######## #####.
				 * @protected
				 */
				makeCall: function() {
					var ctiModel = this.get("CtiModel");
					var number = this.get("Number");
					var entitySchemaName = ctiModel.getEntitySchemaNameBySubscriberType(this.get("Type"));
					var subscriberInfo = {
						number: number,
						customerId: this.get("SubscriberId"),
						entitySchemaName: entitySchemaName
					};
					ctiModel.set("AdvisedIdentifiedSubscriberInfo", subscriberInfo);
					ctiModel.callByNumber(number);
				}

			},
			diff: [
				{
					"operation": "insert",
					"name": "CommunicationContainer",
					"values": {
						"id": "CommunicationContainer",
						"selectors": {"wrapEl": "#CommunicationContainer"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"markerValue": {"bindTo": "Type"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "CommunicationTypeLabel",
					"parentName": "CommunicationContainer",
					"propertyName": "items",
					"values": {
						"id": "CommunicationTypeLabel",
						"itemType": BPMSoft.ViewItemType.LABEL,
						"classes": {"labelClass": ["label-caption"]},
						"markerValue": {"bindTo": "Type"},
						"caption": {"bindTo": "Type"}
					}
				},
				{
					"operation": "insert",
					"name": "Number",
					"parentName": "CommunicationContainer",
					"propertyName": "items",
					"values": {
						"id": "Number",
						"itemType": BPMSoft.ViewItemType.LABEL,
						"classes": {"labelClass": ["communication-number"]},
						"markerValue": {"bindTo": "Number"},
						"caption": {"bindTo": "Number"}
					}
				},
				{
					"operation": "insert",
					"name": "CallButton",
					"parentName": "CommunicationContainer",
					"propertyName": "items",
					"values": {
						"enabled": {"bindTo": "IsTelephonyAvailable"},
						"id": "CallButton",
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"imageConfig": {"bindTo": "Resources.Images.MakeCallButtonIcon"},
						"classes": {"wrapperClass": "communication-call-button"},
						"markerValue": {"bindTo": "Number"},
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"click": {"bindTo": "makeCall"}
					}
				}
			]
		};
	});
