define("IdentifiedSubscriberItem", ["BPMSoft", "CtiConstants"],
	function(BPMSoft, CtiConstants) {
		return {
			attributes: {

				/**
				 * ############# ########.
				 */
				"Id": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": ""
				},

				/**
				 * ### ########.
				 */
				"Type": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": ""
				},

				/**
				 * ### ########.
				 */
				"Name": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": ""
				},

				/**
				 * ############# #### ########.
				 */
				"Photo": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": ""
				},

				/**
				 * ########### ########.
				 */
				"Department": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": ""
				},

				/**
				 * ########## ########.
				 */
				"AccountName": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": ""
				},

				/**
				 * ######### ########.
				 */
				"Job": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": ""
				},

				/**
				 * ### ###########, ##### ####### ############### ### ##########.
				 */
				"AccountType": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": ""
				},

				/**
				 * ##### ########.
				 */
				"City": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": ""
				},

				/**
				 * ### ######## #####.
				 */
				"CommunicationType": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": ""
				},

				/**
				 * #####, ## ######## ####### ##### ########.
				 */
				"Number": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": ""
				},

				/**
				 * ############ ###### ## ################### ########, # ########### ## ### ####.
				 * #### - ### ########, ######## - ###### #### ##### ###### #############, ####### ####### ##########.
				 * @private
				 * @type {Object}
				 */
				"SubscriberColumnsByType": {
					"dataValueType": BPMSoft.DataValueType.CUSTOM_OBJECT,
					"value": {
						"Contact": ["AccountName", "Job"],
						"Account": ["AccountType", "City"],
						"Employee": ["Department"]
					}
				}
			},
			methods: {

				/**
				 * ########## ############ ########### # #### ######## ### ####### ###########.
				 * @private
				 * @returns {Object} ############ ###########.
				 */
				getPhoto: function() {
					var subscriberType = this.get("Type");
					var photoId = this.get("Photo");
					if (subscriberType === CtiConstants.SubscriberTypes.Account) {
						return this.get("Resources.Images.AccountIdentifiedPhoto");
					}
					if (Ext.isEmpty(photoId) || this.BPMSoft.isEmptyGUID(photoId)) {
						return this.get("Resources.Images.ContactEmptyPhotoWhite");
					}
					var photoConfig =  {
						source: this.BPMSoft.ImageSources.ENTITY_COLUMN,
						params: {
							schemaName: "SysImage",
							columnName: "Data",
							primaryColumnValue: photoId
						}
					};
					return  {
						source: BPMSoft.ImageSources.URL,
						url: BPMSoft.ImageUrlBuilder.getUrl(photoConfig)
					};
				},

				/**
				 * ##########, ######## ## ###### ############# ####### ## #### ######## ##########.
				 * @param {String} tag ### ############# ########.
				 * @returns {Boolean} ######### ######.
				 */
				getIsInfoLabelVisible: function(tag) {
					var type = this.get("Type");
					var subscriberColumnsByType = this.get("SubscriberColumnsByType");
					var subscriberColumns = subscriberColumnsByType[type];
					if (Ext.isEmpty(subscriberColumns) || (subscriberColumns.indexOf(tag) === -1)) {
						return false;
					}
					var infoLabelValue = this.get(tag);
					return !Ext.isEmpty(infoLabelValue);
				}
			},
			diff: [
				{
					"operation": "insert",
					"name": "IdentifiedSubscriberItemContainer",
					"values": {
						"id": "IdentifiedSubscriberItemContainer",
						"selectors": {
							"wrapEl": "#IdentifiedSubscriberItemContainer"
						},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["identified-subscriber-item-container"],
						"markerValue": {"bindTo": "Name"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "Photo",
					"parentName": "IdentifiedSubscriberItemContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"imageConfig": {"bindTo": "getPhoto"},
						"classes": {"wrapperClass": ["subscriber-photo"]},
						"markerValue": "Photo",
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT
					}
				},
				{
					"operation": "insert",
					"name": "SubscriberDataContainer",
					"parentName": "IdentifiedSubscriberItemContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["subscriber-data-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "Name",
					"parentName": "SubscriberDataContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"classes": {"labelClass": ["subscriber-name"]},
						"markerValue": {"bindTo": "Name"},
						"caption": {"bindTo": "Name"},
						"hint": {"bindTo": "Name"}
					}
				},
				{
					"operation": "insert",
					"name": "AccountName",
					"parentName": "SubscriberDataContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"classes": {"labelClass": ["subscriber-data"]},
						"markerValue": {"bindTo": "AccountName"},
						"caption": {"bindTo": "AccountName"},
						"visible": {"bindTo": "getIsInfoLabelVisible"},
						"hint": {"bindTo": "AccountName"},
						"tag": "AccountName"
					}
				},
				{
					"operation": "insert",
					"name": "Department",
					"parentName": "SubscriberDataContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"classes": {"labelClass": ["subscriber-data"]},
						"markerValue": {"bindTo": "Department"},
						"caption": {"bindTo": "Department"},
						"visible": {"bindTo": "getIsInfoLabelVisible"},
						"hint": {"bindTo": "Department"},
						"tag": "Department"
					}
				},
				{
					"operation": "insert",
					"name": "Job",
					"parentName": "SubscriberDataContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"classes": {"labelClass": ["subscriber-data"]},
						"markerValue": {"bindTo": "Job"},
						"caption": {"bindTo": "Job"},
						"visible": {"bindTo": "getIsInfoLabelVisible"},
						"hint": {"bindTo": "Job"},
						"tag": "Job"
					}
				},
				{
					"operation": "insert",
					"name": "AccountType",
					"parentName": "SubscriberDataContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"classes": {"labelClass": ["subscriber-data"]},
						"markerValue": {"bindTo": "AccountType"},
						"caption": {"bindTo": "AccountType"},
						"visible": {"bindTo": "getIsInfoLabelVisible"},
						"hint": {"bindTo": "AccountType"},
						"tag": "AccountType"
					}
				},
				{
					"operation": "insert",
					"name": "City",
					"parentName": "SubscriberDataContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"classes": {"labelClass": ["subscriber-data"]},
						"markerValue": {"bindTo": "City"},
						"caption": {"bindTo": "City"},
						"visible": {"bindTo": "getIsInfoLabelVisible"},
						"hint": {"bindTo": "City"},
						"tag": "City"
					}
				},
				{
					"operation": "insert",
					"name": "NumberContainer",
					"parentName": "IdentifiedSubscriberItemContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["subscriber-number-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "CommunicationType",
					"parentName": "NumberContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"classes": {"labelClass": ["subscriber-communication-type-name"]},
						"markerValue": {"bindTo": "CommunicationType"},
						"caption": {"bindTo": "CommunicationType"},
						"hint": {"bindTo": "CommunicationType"}
					}
				},
				{
					"operation": "insert",
					"name": "Number",
					"parentName": "NumberContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"classes": {"labelClass": ["subscriber-number"]},
						"markerValue": {"bindTo": "Number"},
						"caption": {"bindTo": "Number"},
						"hint": {"bindTo": "Number"}
					}
				}
			]
		};
	});
