define("SaveSchemaVersionMessageBox", ["SaveSchemaVersionMessageBoxResources", "ModalBox"
], function(resources, ModalBox) {
	return {
		attributes: {
			/**
			 * Message box title.
			 */
			"Title": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				value: resources.localizableStrings.Message
			},
			/**
			 * Displayed message to the user.
			 */
			"Message": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				value: resources.localizableStrings.Message
			},
			/**
			 * Flag that indicates when to save schema as new version.
			 */
			"SaveNewVersion": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: true
			},
			/**
			 * Flag indicates that the current schema should be saved as new version.
			 */
			"IsForceSaveNewVersion": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			}
		},
		messages: {
			"OnSaveVersionClick": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		methods: {

			// region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#onRender
			 * @override
			 */
			onRender: function() {
				this.callParent(arguments);
				ModalBox.updateSizeByContent();
			},

			/**
			 * Handles Cancel button click. Closes page.
			 * @protected
			 */
			onCancelClick: function() {
				ModalBox.close(true);
			},

			/**
			 * Handles Save button click.
			 * @protected
			 */
			onSaveClick: function() {
				this.sandbox.publish("OnSaveVersionClick", this.get("SaveNewVersion"), [this.sandbox.id]);
				ModalBox.close(true);
			}

			// endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "MainWrap",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["save-schema-version-message-box"],
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
					"caption": {"bindTo": "Title"}
				}
			},
			{
				"operation": "insert",
				"parentName": "HeaderWrap",
				"propertyName": "items",
				"name": "MessageWrap",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["message-wrap"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "MessageWrap",
				"propertyName": "items",
				"name": "Message",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": {"bindTo": "Message"}
				}
			},
			{
				"operation": "insert",
				"parentName": "MainWrap",
				"propertyName": "items",
				"name": "SaveAsWrap",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["save-as-radio-wrap"],
					"visible": {
						"bindTo": "IsForceSaveNewVersion",
						"bindConfig": {
							"converter": "invertBooleanValue"
						}
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "SaveAsWrap",
				"propertyName": "items",
				"name": "SaveAsRadioGroup",
				"values": {
					"itemType": BPMSoft.ViewItemType.RADIO_GROUP,
					"value": {"bindTo": "SaveNewVersion"},
					"wrapClass": ["save-as-radio-group"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "SaveNewVersion",
				"parentName": "SaveAsRadioGroup",
				"propertyName": "items",
				"values": {
					"caption": {"bindTo": "Resources.Strings.SaveNewVersion"},
					"markerValue": "SaveNewVersion",
					"value": true
				}
			},
			{
				"operation": "insert",
				"name": "SetAsCurrentVersion",
				"parentName": "SaveAsRadioGroup",
				"propertyName": "items",
				"values": {
					"caption": {"bindTo": "Resources.Strings.SaveCurrentVersion"},
					"markerValue": "SaveCurrentVersion",
					"value": false
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
					"visible": {
						"bindTo": "IsForceSaveNewVersion",
						"bindConfig": {
							"converter": "invertBooleanValue"
						}
					}
				}
			},
			{
				"operation": "insert",
				"name": "ForceSave",
				"parentName": "ButtonsWrap",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.SaveNewVersion"},
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
					"click": {"bindTo": "onSaveClick"},
					"classes": {"textClass": ["button-margin-right"]},
					"visible": {"bindTo": "IsForceSaveNewVersion"}
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
		]/**SCHEMA_DIFF*/
	};
});
