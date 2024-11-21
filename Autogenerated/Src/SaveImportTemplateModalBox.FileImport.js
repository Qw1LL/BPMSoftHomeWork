define("SaveImportTemplateModalBox", ["ModalBox"], function(ModalBox) {
	return {
		attributes: {
			/**
			 * Flag that indicates when to save template as new version.
			 */
			"ImportTemplateSavingOption": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"value": true
			},
		},
		messages: {
			/**
			 * @message SelectSaveImportTemplateOption
			 * Publish save import template selected option.
			 */
			"SetImportTemplateSavingOption": {
				"mode": BPMSoft.MessageMode.PTP,
				"direction": BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		methods: {

			//region Methods: Public

			_getCurrentVersionCaption: function() {
				var moduleInfo = this.get("moduleInfo")
				return moduleInfo
					? moduleInfo.importTemplateName
					: '';
			},

			//endregion

			//region Methods: Public

			/**
			 * Save button click handler.
			 * @public
			 */
			onSaveClick: function() {
				this.sandbox.publish("SetImportTemplateSavingOption",  this.get("ImportTemplateSavingOption"), [this.sandbox.id]);
				ModalBox.close();
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
						"height": 220
					}
				};
			},

			/**
			 * Returns caption for current version option.
			 * @public
			 * @return {String}
			 */
			getCurrentVersionOptionCaption: function() {
				var currentVersionName = this._getCurrentVersionCaption();
				return this.Ext.String.format("{0}: \"{1}\"", this.get("Resources.Strings.SaveCurrentVersion"), currentVersionName);
			}

			//endregion

		},
		diff: [
			{
				"operation": "insert",
				"name": "MainWrap",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["save-import-template-message-box"],
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
				"name": "SaveAsWrap",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["inner-content-group"],
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
					"value": {"bindTo": "ImportTemplateSavingOption"},
					"wrapClass": ["save-as-radio-group"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "ImportTemplateSavingOption",
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
					"caption": {"bindTo": "getCurrentVersionOptionCaption"},
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