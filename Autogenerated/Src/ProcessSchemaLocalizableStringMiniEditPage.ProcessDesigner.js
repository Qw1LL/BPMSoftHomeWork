/**
 * Parent: BaseProcessMiniEditPage
 */
define("ProcessSchemaLocalizableStringMiniEditPage", [
		"BPMSoft",
		"ProcessSchemaLocalizableStringMiniEditPageResources",
		"BaseProcessMiniEditPageResources"],
	function(BPMSoft, resources, baseResources) {
		return {
			attributes: {
				/**
				 * Name of the LocalizaleString.
				 * @type {BPMSoft.dataValueType.TEXT}
				 */
				"Name": {
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"caption": resources.localizableStrings.NameCaption,
					"isRequired": true
				},
				"Caption": {
					"dataValueType": this.BPMSoft.DataValueType.LOCALIZABLE_STRING
				},
				"LocalizableCaption": {
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"type": this.BPMSoft.ViewModelColumnType.CALCULATED_COLUMN,
					"caption": { bindTo: "getCaptionLabelText" }
				},
				/**
				 * Value of the LocalizaleString.
				 * @type {BPMSoft.dataValueType.LOCALIZABLE_STRING}
				 */
				"Value": {
					"dataValueType": this.BPMSoft.DataValueType.LOCALIZABLE_STRING
				},
				/**
				 * Value of the LocalizaleString.
				 * @type {BPMSoft.dataValueType.TEXT}
				 */
				"LocalizableValue": {
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"type": this.BPMSoft.ViewModelColumnType.CALCULATED_COLUMN,
					"caption": { bindTo: "getValueLabelText" },
					"isRequired": true
				}
			},
			methods: {
				//region Methods: Protected

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
				 * @overridden
				 */
				init: function() {
					this.callParent(arguments);
					this.setFieldValue("Caption");
					this.setFieldValue("Value");
				},

				/**
				 * Returns item info.
				 * @overridden
				 * @return {Object} Item info.
				 */
				generateItemInfo: function() {
					var columns = this.columns;
					var itemInfo = {
						IsValid: true
					};
					this.updateFieldValue("Caption");
					this.updateFieldValue("Value");
					this.BPMSoft.each(columns, function(columnValue, columnName) {
						itemInfo[columnName] = this.get(columnName);
					}, this);
					return itemInfo;
				},

				/**
				 * Updates fields value from "Localizable%fieldName%" field.
				 * @private
				 * @param fieldName {string} field name to update from.
				 */
				updateFieldValue: function(fieldName) {
					var value = this.get("Localizable" + fieldName);
					var localizableValue = this.get(fieldName) || Ext.create("BPMSoft.LocalizableString");
					localizableValue.setValue(value);
					this.set(fieldName, localizableValue);
				},

				/**
				 * Sets field value from "%fieldName%" to "Localizable%fieldName%"
				 * @private
				 * @param fieldName {string} field name to set to.
				 */
				setFieldValue: function(fieldName) {
					var sourceFieldValue = this.get(fieldName) || {};
					var cultureValue = sourceFieldValue.getValue() || "";
					this.set("Localizable" + fieldName, cultureValue);
				},

				/**
				 * @inheritdoc BaseSchemaViewModel#setValidationConfig
				 * @overridden
				 */
				setValidationConfig: function() {
					this.callParent(arguments);
					this.addColumnValidator("Name", this.nameValidator);
					this.addColumnValidator("Name", this.duplicateValueValidator);
				},

				/**
				 * @inheritdoc BaseProcessMiniEditPage#getSaveButtonHint
				 * @returns {undefined}
				 */
				getSaveButtonHint: function() {
					return this.get("IsEditable")
						? this.callParent()
						: baseResources.localizableStrings.InheritedItemSaveButtonHint;
				},

				/**
				 * Returns caption for a Value label.
				 * @private
				 * @returns {string} caption.
				 */
				getValueLabelText: function() {
					var resource = resources.localizableStrings.ValueCaption;
					var currentCulture = BPMSoft.SysValue.CURRENT_USER_CULTURE.displayValue;
					var caption = BPMSoft.getFormattedString(resource, currentCulture);
					return caption;
				}

				//endregion

			},
			diff: /**SCHEMA_DIFF*/ [
				{
					"operation": "insert",
					"parentName": "Controls",
					"propertyName": "items",
					"name": "Name",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.TEXT,
						"value": {
							"bindTo": "Name"
						},
						"isRequired": true,
						"classes": {
							"labelClass": ["t-label-proc"]
						},
						"enabled": { "bindTo": "IsEditable" },
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24
						},
						"wrapClass": ["top-caption-control"]
					}
				},
				{
					"operation": "insert",
					"parentName": "Controls",
					"propertyName": "items",
					"name": "LocalizableValue",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.TEXT,
						"value": { "bindTo": "LocalizableValue" },
						"classes": {
							"labelClass": ["t-label-proc"]
						},
						"enabled": { "bindTo": "IsEditable" },
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24
						},
						"wrapClass": ["top-caption-control"]
					}
				}
			] /**SCHEMA_DIFF*/
		};
	});
