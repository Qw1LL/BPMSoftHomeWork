define("EmployeeProfileSchema", ["ProfileSchemaMixin"], function() {
			return {
				entitySchemaName: "Employee",
				attributes: {
					/**
					 * Contact photo.
					 */
					"ContactPhoto": {
						"dataValueType": this.BPMSoft.DataValueType.CUSTOM_OBJECT,
						"type": this.BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
						"columnPath": "Contact.Photo"
					},
					/**
					 * Mobile phone.
					 */
					"MobilePhone": {
						"dataValueType": this.BPMSoft.DataValueType.TEXT,
						"type": this.BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
						"columnPath": "Contact.MobilePhone",
						"caption": {bindTo: "Resources.Strings.MobilePhoneCaption"}
					},
					/**
					 * Work phone.
					 */
					"Phone": {
						"dataValueType": this.BPMSoft.DataValueType.TEXT,
						"type": this.BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
						"columnPath": "Contact.Phone",
						"caption": {bindTo: "Resources.Strings.PhoneCaption"}
					}
				},
				mixins: {
					ProfileSchemaMixin: "BPMSoft.ProfileSchemaMixin"
				},
				methods: {
					/**
					 * @inheritdoc BPMSoft.BaseProfileSchema#init
					 * @overridden
					 */
					init: function(callback, scope) {
						this.callParent([
							function() {
								this.primaryImageColumnName = "ContactPhoto";
								this.Ext.callback(callback, scope || this);
							}, this
						]);
					}
				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "merge",
						"name": "ProfileModuleContainer",
						"values": {
							"wrapClass": ["profile-module-container", "contact-profile"]
						}
					},
					{
						"operation": "insert",
						"name": "FullJobTitle",
						"parentName": "ProfileContentContainer",
						"propertyName": "items",
						"values": {
							"layout": {
								"column": 0,
								"row": 2,
								"colSpan": 24
							}
						}
					},
					{
						"operation": "insert",
						"name": "MobilePhone",
						"parentName": "ProfileContentContainer",
						"propertyName": "items",
						"values": {
							"layout": {
								"column": 0,
								"row": 3,
								"colSpan": 24
							}
						}
					},
					{
						"operation": "insert",
						"name": "Phone",
						"parentName": "ProfileContentContainer",
						"propertyName": "items",
						"values": {
							"layout": {
								"column": 0,
								"row": 4,
								"colSpan": 24
							}
						}
					}
				]/**SCHEMA_DIFF*/
			};
		}
);
