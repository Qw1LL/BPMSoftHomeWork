define("NewImportTemplateModalBox", ["ModalBox"], function(ModalBox) {
	return {
		attributes: {
			/**
			 * Flag that indicates when to save template as new version.
			 */
			"Name": {
				"dataValueType": BPMSoft.DataValueType.TEXT,
				"isRequired": true
			},
		},
		messages: {
			/**
			 * @message SetNewTemplateName
			 * Publish new template name.
			 */
			"SetNewTemplateName": {
				"mode": BPMSoft.MessageMode.PTP,
				"direction": BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		methods: {

			//region Methods: Public

			/**
			 * Save button click handler.
			 * @public
			 */
			onSaveClick: function() {
				if (this.validate()) {
					this.sandbox.publish("SetNewTemplateName",  this.get("Name"), [this.sandbox.id]);
					ModalBox.close();
				}
			},

			/**
			 * Cancel button click handler.
			 * @public
			 */
			onCancelClick: function() {
				ModalBox.close();
			},

			/**
			 * Returns modal box initial config.
			 * @public
			 * @return {Object}
			 */
			getModalBoxInitialConfig: function() {
				return {
					"initialSize": {
						"width": 500,
						"height": 235
					}
				};
			}

			//endregion

		},
		diff: [
			{
				"operation": "insert",
				"name": "MainWrap",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["new-import-template-message-box"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "MainWrap",
				"propertyName": "items",
				"name": "HeaderWrap",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "HeaderWrap",
				"propertyName": "items",
				"name": "TitleWrap",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["ts-inputbox-caption"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "TitleWrap",
				"propertyName": "items",
				"name": "Title",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": {"bindTo": "Resources.Strings.Title"}
				}
			},
			{
				"operation": "insert",
				"parentName": "MainWrap",
				"propertyName": "items",
				"name": "NameWrap",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["inner-content-group"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "NameLabel",
				"parentName": "NameWrap",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": {"bindTo": "Resources.Strings.NameCaption"},
					"labelClass": ["control-caption"],
				}
			},
			{
				"operation": "insert",
				"name": "Name",
				"parentName": "NameWrap",
				"propertyName": "items",
				"values": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"markerValue": "NewTemplateNameTextEdit",
					"controlConfig": {
						"className": "BPMSoft.TextEdit",
						"value": {"bindTo": "Name"},
					},
					"labelConfig": {
						"visible": false
					}
				}
			},
			{
				"operation": "insert",
				"name": "ButtonsWrap",
				"parentName": "MainWrap",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["buttons-wrap"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "Save",
				"parentName": "ButtonsWrap",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.Save"},
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
					"click": {"bindTo": "onSaveClick"},
					"classes": {"textClass": ["button-margin-right"]},
				}
			},
			{
				"operation": "insert",
				"name": "Cancel",
				"parentName": "ButtonsWrap",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.Cancel"},
					"click": {"bindTo": "onCancelClick"},
					"classes": {"textClass": ["button-margin-right"]}
				}
			}
		]
	};
});
