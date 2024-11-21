define("EmployeeMiniPage", ["ConfigurationConstants", "EmployeePageMixin", "css!EmployeeMiniPageCSS"],
	function(ConfigurationConstants) {
		return {
			entitySchemaName: "Employee",
			mixins: {
				/**
				 * @class EmployeePageMixin
				 * Employee page mixin.
				 */
				EmployeePageMixin: "BPMSoft.EmployeePageMixin"
			},
			attributes: {
				/**
				 * @inheritdoc BaseMiniPage#MiniPageModes
				 * @overridden
				 */
				"MiniPageModes": {
					"value": [this.BPMSoft.ConfigurationEnums.CardOperation.ADD]
				},
				/**
				 * Employee name.
				 */
				"Name": {
					"dependencies": [
						{
							"columns": ["Contact"],
							"methodName": "contactChanged"
						}
					],
					"isRequired": false
				},
				/**
				 * Employee full job title.
				 */
				"FullJobTitle": {
					"dependencies": [
						{
							"columns": ["Job"],
							"methodName": "jobChanged"
						}
					]
				},
				/**
				 * Organization structure unit.
				 */
				"OrgStructureUnit": {
					"lookupConfig": {
						"hierarchical": true
					},
					"lookupListConfig": {
						"columns": ["FullName", "Head"]
					}
				},
				/**
				 * Employee contact.
				 */
				"Contact": {
					"lookupListConfig": {
						"columns": ["[Employee:Contact].Id", "Photo", "Phone", "Email", "BirthDate", "Gender.Name"],
						"filter": function() {
							return BPMSoft.createColumnIsNullFilter("[Employee:Contact].Id");
						}
					}
				},
				/**
				 * Employee account.
				 */
				"Account": {
					"lookupListConfig": {
						"filter": function() {
							return BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
									"Type", ConfigurationConstants.AccountType.OurCompany);
						}
					}
				}
			},
			methods: {
				/**
				 * @inheritdoc BPMSoft.BaseMiniPage#init
				 * @overridden
				 */
				init: function() {
					this.on("change:OrgStructureUnit", this.onChangedOrgStructureUnit, this);
					this.callParent(arguments);
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"parentName": "HeaderContainer",
					"propertyName": "items",
					"name": "HeaderColumnContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "getPrimaryDisplayColumnValue"},
						"labelClass": ["label-in-header-container"],
						"visible": {"bindTo": "isNotAddMode"}
					},
					"index": 0
				},
				{
					"operation": "merge",
					"name": "CloseMiniPageButton",
					"values": {
						"visible": true
					}
				},
				{
					"operation": "merge",
					"name": "MiniPage",
					"values": {
						"classes": {
							"wrapClassName": ["employee-mini-page-container"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "MiniPage",
					"propertyName": "items",
					"name": "Contact",
					"values": {
						"isMiniPageModelItem": true,
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "MiniPage",
					"propertyName": "items",
					"name": "Name",
					"values": {
						"isMiniPageModelItem": true,
						"visible": false,
						"layout": {
							"column": 0,
							"row": 6,
							"colSpan": 24
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "MiniPage",
					"propertyName": "items",
					"name": "Job",
					"values": {
						"isMiniPageModelItem": true,
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "MiniPage",
					"propertyName": "items",
					"name": "FullJobTitle",
					"values": {
						"isMiniPageModelItem": true,
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 24
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "MiniPage",
					"propertyName": "items",
					"name": "OrgStructureUnit",
					"values": {
						"isMiniPageModelItem": true,
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 24
						},
						"contentType": BPMSoft.ContentType.LOOKUP
					}
				},
				{
					"operation": "insert",
					"parentName": "MiniPage",
					"propertyName": "items",
					"name": "Account",
					"values": {
						"isMiniPageModelItem": true,
						"layout": {
							"column": 0,
							"row": 5,
							"colSpan": 24
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});