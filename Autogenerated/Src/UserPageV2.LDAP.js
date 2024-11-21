define("UserPageV2", ["UserPageV2Resources"],
	function() {
		return {
			entitySchemaName: "VwSysAdminUnit",
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"parentName": "GeneralInfoTab",
					"name": "AuthControlGroup",
					"propertyName": "items",
					"values": {},
					index: 1
				},
				{
					"operation": "merge",
					"parentName": "AuthControlGroup",
					"name": "FormAuthGridLayout",
					"propertyName": "items",
					"values": {
						"visible": {
							"bindTo": "SynchronizeWithLDAP",
							"bindConfig": {
								"converter": "invertValue"
							}
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "AuthControlGroup",
					"name": "LDAPUserBindingLayout",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": [],
						"visible": {
							"bindTo": "SynchronizeWithLDAP"
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "AuthControlGroup",
					"name": "RadioGroup",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.RADIO_GROUP,
						"value": {
							"bindTo": "SynchronizeWithLDAP"
						},
						"items": [],
						"layout": {"column": 0, "row": 0, "colSpan": 11}
					},
					index: 0
				},
				{
					"operation": "insert",
					"parentName": "RadioGroup",
					"propertyName": "items",
					"name": "AuthForm",
					"values": {
						"caption": {
							"bindTo": "Resources.Strings.AuthUseForm"
						},
						"value": false
					}
				},
				{
					"operation": "insert",
					"parentName": "RadioGroup",
					"propertyName": "items",
					"name": "AuthLDAP",
					"values": {
						"caption": {
							"bindTo": "Resources.Strings.AuthUseLdap"
						},
						"value": true
					}
				},
				{
					"operation": "insert",
					"parentName": "LDAPUserBindingLayout",
					"name": "LDAPElement",
					"propertyName": "items",
					"values": {
						"contentType": this.BPMSoft.ContentType.LOOKUP,
						"caption": {"bindTo": "Resources.Strings.UserNameCaption"},
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 11
						},
						"isRequired": {
							"bindTo": "SynchronizeWithLDAP"
						},
						"value": {
							"bindTo": "LDAPElement"
						}
					}
				}
			]/**SCHEMA_DIFF*/,
			attributes: {
				"LDAPElement": {
					dataValueType: this.BPMSoft.DataValueType.LOOKUP,
					lookupListConfig: {
						filter: function() {
							var filterGroup = new this.BPMSoft.createFilterGroup();
							filterGroup.add("UserFilter", this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL,
								"Type", 4));
							filterGroup.add(
								"NotExists", this.BPMSoft.createNotExistsFilter("[SysAdminUnit:LDAPElement].Id"));
							return filterGroup;
						}
					}
				},
				"Synchronization": {
					dependencies: [{
						columns: ["SynchronizeWithLDAP"],
						methodName: "onRadioButtonSwitch"
					}]
				},
				"Name": {
					dependencies: [
						{
							columns: ["LDAPElement"],
							methodName: "onSelectedName"
						}
					]
				}
			},
			methods: {
				/**
				 * ########### ########
				 * @protected
				 * @virtual
				 * @param {boolean} value ######## ##########
				 * @return {boolean} ############### ######## ##########
				 */
				invertValue: function(value) {
						return !value;

					},
				/**
				 * @inheritDoc BasePageV2#onEntityInitialized
				 * ############# ######## ############## # ###### ########## ###### ############.
				 * (## ######### ########## BPMCRM)
				 * @protected
				 * @overridden
				 */
				onEntityInitialized: function() {
					this.callParent(arguments);
					if (this.isAddMode()) {
						this.set("SynchronizeWithLDAP", false);
					}
				},

				/**
				 * ####### ######## ##### ### ############ ##### ###### ############## # ###### ############
				 * #### ###############
				 * @private
				 */
				onRadioButtonSwitch: function() {
					if (this.get("SynchronizeWithLDAP")) {
						this.set("Name", null);
						this.set("Email", null);
						this.set("UserPassword", "");
						this.set("PasswordConfirmation", null);
						this.set("PasswordExpireDate", null);
						this.set("ForceChangePassword", null);
					} else {
						this.set("LDAPElement", null);
						this.set("Name", null);
					}
				},
				/**
				 * #c########### ######## ######## isRequired.
				 * @protected
				 * @overridden
				 */
				isRequiredFieldsVisible: function() {
					return !this.get("SynchronizeWithLDAP");
				},
				/**
				 * ######### ############ #### Name ### ########## LDAPElement.
				 * @protected
				 * @virtual
				 */
				onSelectedName: function() {
					var value = this.get("LDAPElement");
					if (value) {
						this.set("Name", value.displayValue);
					}
				}
			}
		};
	});
