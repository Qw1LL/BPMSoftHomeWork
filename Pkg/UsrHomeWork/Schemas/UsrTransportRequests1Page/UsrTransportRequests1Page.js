define("UsrTransportRequests1Page", [], function() {
	return {
		entitySchemaName: "UsrTransportRequests",
		attributes: {},
		modules: /**SCHEMA_MODULES*/{}/**SCHEMA_MODULES*/,
		details: /**SCHEMA_DETAILS*/{
			"Files": {
				"schemaName": "FileDetailV2",
				"entitySchemaName": "UsrTransportRequestsFile",
				"filter": {
					"masterColumn": "Id",
					"detailColumn": "UsrTransportRequests"
				}
			}
		}/**SCHEMA_DETAILS*/,
		businessRules: /**SCHEMA_BUSINESS_RULES*/{}/**SCHEMA_BUSINESS_RULES*/,
		methods: {
				setValidationConfig: function() {
				this.callParent(arguments);
				this.addColumnValidator("UsrRequestNumber", this.requestNumberColumnValidator);
		},
			
			requestNumberColumnValidator: function(value) {
				console.log(value);
				const regexStr = /^\d{4}-\d{2}-\d{2}-\d{2}$/;
				if (!regexStr.test(value)) {
					return {
					invalidMessage: "Некорректный формат номера заявки"
				};
				}
				return {
					invalidMessage: ""
				};
			}
		},
		dataModels: /**SCHEMA_DATA_MODELS*/{}/**SCHEMA_DATA_MODELS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "UsrNamee24b5889-4392-43d6-92c6-4da4eb14b0fb",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 0,
						"layoutName": "ProfileContainer"
					},
					"bindTo": "UsrName"
				},
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "UsrRequestNumber16f962cf-fc60-4a10-bc02-b5c8c4ceea93",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 1,
						"layoutName": "ProfileContainer"
					},
					"bindTo": "UsrRequestNumber"
				},
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "UsrStatusf6b68ce8-08ee-43b5-b4b8-badb38226c9f",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 2,
						"layoutName": "ProfileContainer"
					},
					"bindTo": "UsrStatus"
				},
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "UsrDescriptiona8eb73f0-5eeb-4cc6-a3e6-39c7696a8730",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 0,
						"layoutName": "Header"
					},
					"bindTo": "UsrDescription"
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "UsrDeliveryAddress985fa067-6904-4b52-8ea4-09a2a2106c6e",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 11,
						"row": 0,
						"layoutName": "Header"
					},
					"bindTo": "UsrDeliveryAddress"
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "UsrCar2649684a-59e8-44e4-bbad-2da72eb3d31b",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 1,
						"layoutName": "Header"
					},
					"bindTo": "UsrCar",
					"enabled": true,
					"contentType": 5
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "UsrDrivercd45b981-061d-4ec2-883d-ceb2c3573cec",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 11,
						"row": 1,
						"layoutName": "Header"
					},
					"bindTo": "UsrDriver"
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "UsrOwner3f0d893f-ba4e-4862-8848-ccf26c1441c7",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 2,
						"layoutName": "Header"
					},
					"bindTo": "UsrOwner"
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "UsrCompany05efea84-8978-4180-aa21-da5e9dd6cb28",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 11,
						"row": 2,
						"layoutName": "Header"
					},
					"bindTo": "UsrCompany"
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 5
			},
			{
				"operation": "merge",
				"name": "ESNTab",
				"values": {
					"order": 0
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
