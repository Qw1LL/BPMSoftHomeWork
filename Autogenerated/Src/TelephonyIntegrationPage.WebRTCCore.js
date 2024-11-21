define("TelephonyIntegrationPage", ["TelephonyIntegrationPageResources"], function(resources) {
	return {
		entitySchemaName: "TelephonyIntegration",
		attributes: {},
		mixins: {},
		modules: /**SCHEMA_MODULES*/{}/**SCHEMA_MODULES*/,
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		businessRules: /**SCHEMA_BUSINESS_RULES*/{
			"BasicAuthGroup": {
				"589e33dd-9daa-49a4-8acd-93ca2584a894": {
					"uId": "589e33dd-9daa-49a4-8acd-93ca2584a894",
					"enabled": true,
					"removed": false,
					"ruleType": 0,
					"property": 0,
					"logical": 0,
					"conditions": [
						{
							"comparisonType": 3,
							"leftExpression": {
								"type": 1,
								"attribute": "TelephonyAuthType"
							},
							"rightExpression": {
								"type": 0,
								"value": "9e40a097-3df7-49fc-a04e-bd9368760d1c",
								"dataValueType": 10
							}
						}
					]
				}
			},
			"TokenAuthGroup": {
				"5779723b-1380-45a7-be9c-0ae5405726ba": {
					"uId": "5779723b-1380-45a7-be9c-0ae5405726ba",
					"enabled": true,
					"removed": false,
					"ruleType": 0,
					"property": 0,
					"logical": 0,
					"conditions": [
						{
							"comparisonType": 3,
							"leftExpression": {
								"type": 1,
								"attribute": "TelephonyAuthType"
							},
							"rightExpression": {
								"type": 0,
								"value": "84c17db6-bef3-4a8f-8eed-b2d2ed7b5d50",
								"dataValueType": 10
							}
						}
					]
				}
			},
			"UisTabLabel": {
				"2538ac3f-fb9a-4937-9344-67ed5d7fb1a1": {
					"uId": "2538ac3f-fb9a-4937-9344-67ed5d7fb1a1",
					"enabled": true,
					"removed": false,
					"ruleType": 0,
					"property": 0,
					"logical": 0,
					"conditions": [
						{
							"comparisonType": 3,
							"leftExpression": {
								"type": 1,
								"attribute": "SysMsgLib"
							},
							"rightExpression": {
								"type": 0,
								"value": "624acd68-c073-4c30-b13a-3e32e85f5f30",
								"dataValueType": 10
							}
						}
					]
				}
			}
		}/**SCHEMA_BUSINESS_RULES*/,
		methods: {
			/**
			 * @inheritdoc BPMSoft.BaseEntityPage#asyncValidate
			 * @override
			 */
			asyncValidate: function(callback, scope) {
				this.callParent([function(response) {
					if (!this.validateResponse(response)) {
						return;
					}
					BPMSoft.chain(
						function(next) {
							this.validateName(function(response) {
								if (this.validateResponse(response)) {
									next();
								}
							}, this);
						},
						function(next) {
							this.validateSysMsgLib(function(response) {
								if (this.validateResponse(response)) {
									next();
								}
							}, this);
						},
						function(next) {
							callback.call(scope, response);
							next();
						}, this);
				}, this]);
			},
			
			/**
			 * Checks the name for duplicates in the system
			 * @callback Summary validate message
			 */
			validateName: function(callback, scope) {
				var result = {success: true};
				var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
				    rootSchemaName: "TelephonyIntegration"
				});
				
				var esqNameFilter = esq.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "Name", this.get("Name"));
				esq.filters.add("esqId", esq.createColumnFilterWithParameter(BPMSoft.ComparisonType.NOT_EQUAL, "Id", this.get("Id")));
				
				esq.filters.add("esqNameFilter", esqNameFilter);
				
				esq.getEntityCollection(function (result) {
				    if (result.success && result.collection && result.collection.getCount() > 0) {
						result.message = this.get("Resources.Strings.InvalidNameMessageCaption");
						result.success = false;
				    }
					callback.call(scope || this, result);
				}, this);
			},
			
			/**
			 * Checks the Message library for duplicates in the system
			 * @callback Summary validate message
			 */
			validateSysMsgLib: function(callback, scope) {
				var result = {success: true};
				if(!this.get("SysMsgLib")) {
					callback.call(scope || this, result);
				}
				
				var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
				    rootSchemaName: "TelephonyIntegration"
				});
						
				esq.filters.add("esqSysMsgLibFilter", esq.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "SysMsgLib", this.get("SysMsgLib").value));
				esq.filters.add("esqId", esq.createColumnFilterWithParameter(BPMSoft.ComparisonType.NOT_EQUAL, "Id", this.get("Id")));
				
				esq.getEntityCollection(function (result) {
				    if (result.success && result.collection && result.collection.getCount() > 0) {
						result.message = this.get("Resources.Strings.InvalidSysMsgLibMessageCaption");
						result.success = false;
				    }
					callback.call(scope || this, result);
				}, this);
			}
		},
		dataModels: /**SCHEMA_DATA_MODELS*/{}/**SCHEMA_DATA_MODELS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "Name",
				"values": {
					"layout": {
						"colSpan": 12,
						"rowSpan": 1,
						"column": 0,
						"row": 0,
						"layoutName": "Header"
					},
					"bindTo": "Name"
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "SysMsgLib",
				"values": {
					"layout": {
						"colSpan": 12,
						"rowSpan": 1,
						"column": 12,
						"row": 0,
						"layoutName": "Header"
					},
					"bindTo": "SysMsgLib"
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "WebServiceURL",
				"values": {
					"layout": {
						"colSpan": 12,
						"rowSpan": 1,
						"column": 0,
						"row": 1,
						"layoutName": "Header"
					},
					"bindTo": "WebServiceURL"
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "CallRecordLinkUrlTemplate",
				"values": {
					"layout": {
						"colSpan": 12,
						"rowSpan": 1,
						"column": 12,
						"row": 1,
						"layoutName": "Header"
					},
					"bindTo": "CallRecordLinkUrlTemplate"
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "TelephonyServerTimeZone",
				"values": {
					"layout": {
						"colSpan": 12,
						"rowSpan": 1,
						"column": 0,
						"row": 2,
						"layoutName": "Header"
					},
					"bindTo": "TelephonyServerTimeZone",
					"enabled": true,
					"contentType": 5
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "EnableCallRecordingFeature",
				"values": {
					"layout": {
						"colSpan": 12,
						"rowSpan": 1,
						"column": 12,
						"row": 2,
						"layoutName": "Header"
					},
					"bindTo": "EnableCallRecordingFeature"
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 5
			},
			{
				"operation": "insert",
				"name": "AuthTab",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.AuthTabTabCaption"
					},
					"items": [],
					"order": 0
				},
				"parentName": "Tabs",
				"propertyName": "tabs",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "AuthTabGroup",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.AuthTabGroupGroupCaption"
					},
					"itemType": 15,
					"markerValue": "added-group",
					"items": []
				},
				"parentName": "AuthTab",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "AuthTabGridLayoutContainer",
				"values": {
					"itemType": 0,
					"items": []
				},
				"parentName": "AuthTabGroup",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "TelephonyAuthType",
				"values": {
					"layout": {
						"colSpan": 12,
						"rowSpan": 1,
						"column": 0,
						"row": 0,
						"layoutName": "AuthTabGridLayoutContainer"
					},
					"bindTo": "TelephonyAuthType"
				},
				"parentName": "AuthTabGridLayoutContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "BasicAuthGroup",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.BasicAuthGroupGroupCaption"
					},
					"itemType": 15,
					"markerValue": "added-group",
					"items": []
				},
				"parentName": "AuthTab",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "AuthTabGridLayout",
				"values": {
					"itemType": 0,
					"items": []
				},
				"parentName": "BasicAuthGroup",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Login",
				"values": {
					"layout": {
						"colSpan": 12,
						"rowSpan": 1,
						"column": 0,
						"row": 0,
						"layoutName": "AuthTabGridLayout"
					},
					"bindTo": "Login"
				},
				"parentName": "AuthTabGridLayout",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Password",
				"values": {
					"layout": {
						"colSpan": 12,
						"rowSpan": 1,
						"column": 0,
						"row": 1,
						"layoutName": "AuthTabGridLayout"
					},
					"bindTo": "Password"
				},
				"parentName": "AuthTabGridLayout",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "TokenAuthGroup",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.TokenAuthGroupGroupCaption"
					},
					"itemType": 15,
					"markerValue": "added-group",
					"items": []
				},
				"parentName": "AuthTab",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "AuthTabGridLayout1",
				"values": {
					"itemType": 0,
					"items": []
				},
				"parentName": "TokenAuthGroup",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Token",
				"values": {
					"layout": {
						"colSpan": 12,
						"rowSpan": 1,
						"column": 0,
						"row": 0,
						"layoutName": "AuthTabGridLayout1"
					},
					"bindTo": "Token"
				},
				"parentName": "AuthTabGridLayout1",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "UisTabLabel",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.UisTabLabelTabCaption"
					},
					"items": [],
					"order": 1
				},
				"parentName": "Tabs",
				"propertyName": "tabs",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "UisTabSettingLabelGroup",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.UisTabSettingLabelGroupGroupCaption"
					},
					"itemType": 15,
					"markerValue": "added-group",
					"items": []
				},
				"parentName": "UisTabLabel",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "UisTabLabelGridLayout",
				"values": {
					"itemType": 0,
					"items": []
				},
				"parentName": "UisTabSettingLabelGroup",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "UisCallStartTimeShift",
				"values": {
					"layout": {
						"colSpan": 12,
						"rowSpan": 1,
						"column": 0,
						"row": 0,
						"layoutName": "UisTabLabelGridLayout"
					},
					"bindTo": "UisCallStartTimeShift"
				},
				"parentName": "UisTabLabelGridLayout",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "UisCallEndTimeShift",
				"values": {
					"layout": {
						"colSpan": 12,
						"rowSpan": 1,
						"column": 12,
						"row": 0,
						"layoutName": "UisTabLabelGridLayout"
					},
					"bindTo": "UisCallEndTimeShift"
				},
				"parentName": "UisTabLabelGridLayout",
				"propertyName": "items",
				"index": 1
			}
		]/**SCHEMA_DIFF*/
	};
});
