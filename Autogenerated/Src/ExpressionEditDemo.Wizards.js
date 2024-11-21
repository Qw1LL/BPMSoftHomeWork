define("ExpressionEditDemo", ["ExpressionEditDemoResources", "BPMSoft", "ext-base", "ExpressionEdit",
	"ExpressionEditVMMixin"],
	function(resources, BPMSoft, Ext) {

	Ext.define("BPMSoft.configuration.ExpressionEditDemoViewModel", {
		alternateClassName: "BPMSoft.ExpressionEditDemoViewModel",
		extend: "BPMSoft.BaseViewModel",

		mixins: {
			"ExpressionEditVMMixin": "BPMSoft.ExpressionEditVMMixin"
		}

	});

	Ext.define("BPMSoft.configuration.ExpressionEditDemo", {
		alternateClassName: "BPMSoft.ExpressionEditDemo",
		extend: "BPMSoft.BaseSchemaModule",
		init: function(callback) {
			if (callback) {
				callback.call(this);
			}
		},
		render: function(renderTo) {
			var view = Ext.create("BPMSoft.Container", {
				"id": "container",
				"items": [{
					"className": "BPMSoft.ExpressionEdit"
				},
				{
					"className": "BPMSoft.ExpressionEdit",
					"expressionType": {"bindTo": "TextExpressionType"},
					"dataValueType": {"bindTo": "TextDataValueType"},
					"value": {"bindTo": "TextValue"}
				},
				{
					"className": "BPMSoft.ExpressionEdit",
					"expressionType": {"bindTo": "TextExpressionType"},
					"dataValueType": {"bindTo": "TextDataValueType"},
					"value": {"bindTo": "TextValue"},
					"placeholder": "Custom placeholder"
				},
				{
					"className": "BPMSoft.ExpressionEdit",
					"expressionType": {"bindTo": "TextExpressionType"},
					"dataValueType": {"bindTo": "TextDataValueType"},
					"value": {"bindTo": "TextValue"},
					"visible": false
				},
				{
					"className": "BPMSoft.ExpressionEdit",
					"expressionType": BPMSoft.ExpressionEnums.ExpressionType.CONSTANT,
					"dataValueType": BPMSoft.DataValueType.LONG_TEXT,
					"placeholder": "LONG_TEXT"
				},
				{
					"className": "BPMSoft.ExpressionEdit",
					"expressionType": BPMSoft.ExpressionEnums.ExpressionType.CONSTANT,
					"dataValueType": BPMSoft.DataValueType.MEDIUM_TEXT,
					"placeholder": "MEDIUM_TEXT"
				},
				{
					"className": "BPMSoft.ExpressionEdit",
					"expressionType": BPMSoft.ExpressionEnums.ExpressionType.CONSTANT,
					"dataValueType": BPMSoft.DataValueType.FLOAT3,
					"placeholder": "FLOAT3"
				},
				{
					"className": "BPMSoft.ExpressionEdit",
					"expressionType": BPMSoft.ExpressionEnums.ExpressionType.CONSTANT,
					"dataValueType": BPMSoft.DataValueType.MONEY,
					"placeholder": "MONEY"
				},
				{
					"className": "BPMSoft.ExpressionEdit",
					"expressionType": {"bindTo": "DateTimeExpressionType"},
					"dataValueType": {"bindTo": "DateTimeDataValueType"},
					"value": {"bindTo": "DateTimeValue"}
				},
				{
					"className": "BPMSoft.ExpressionEdit",
					"expressionType": {"bindTo": "BooleanExpressionType"},
					"dataValueType": {"bindTo": "BooleanDataValueType"},
					"value": {"bindTo": "BooleanValue"}
				},
				{
					"className": "BPMSoft.ExpressionEdit",
					"expressionType": {"bindTo": "LookupExpressionType"},
					"dataValueType": {"bindTo": "LookupDataValueType"},
					"referenceSchema": {"bindTo": "LookupReferenceSchema"},
					"value": {"bindTo": "LookupValue"},
					"prepareReferenceSchemaList": {"bindTo": "prepareReferenceSchemaList"},
					"prepareValueList": {"bindTo": "prepareLookupValueList"}
				},
				{
					"className": "BPMSoft.ExpressionEdit",
					"expressionType": {"bindTo": "LookupExpressionType"},
					"dataValueType": {"bindTo": "LookupDataValueType"},
					"referenceSchema": {"bindTo": "LookupReferenceSchema"},
					"value": {"bindTo": "LookupValue"},
					"prepareReferenceSchemaList": {"bindTo": "prepareReferenceSchemaList"},
					"prepareValueList": {"bindTo": "prepareLookupValueList"},
					"typeVisible": false
				},
				{
					"className": "BPMSoft.ExpressionEdit",
					"expressionType": {"bindTo": "LookupExpressionType"},
					"dataValueType": {"bindTo": "LookupDataValueType"},
					"referenceSchema": {"bindTo": "LookupReferenceSchema"},
					"value": {"bindTo": "LookupValue"},
					"prepareReferenceSchemaList": {"bindTo": "prepareReferenceSchemaList"},
					"prepareValueList": {"bindTo": "prepareLookupValueList"},
					"typeEnabled": false
				}]
			});
			var viewModel = Ext.create("BPMSoft.ExpressionEditDemoViewModel", {
				"values": {
					"TextExpressionType": BPMSoft.ExpressionEnums.ExpressionType.CONSTANT,
					"TextDataValueType": BPMSoft.DataValueType.TEXT,
					"TextValue": "Text",

					"DateTimeExpressionType": BPMSoft.ExpressionEnums.ExpressionType.CONSTANT,
					"DateTimeDataValueType": BPMSoft.DataValueType.DATE_TIME,
					"DateTimeValue": new Date(),


					"BooleanExpressionType": BPMSoft.ExpressionEnums.ExpressionType.CONSTANT,
					"BooleanDataValueType": BPMSoft.DataValueType.BOOLEAN,
					"BooleanValue": true,

					"LookupExpressionType": BPMSoft.ExpressionEnums.ExpressionType.CONSTANT,
					"LookupDataValueType": BPMSoft.DataValueType.LOOKUP,
					"LookupReferenceSchema": null,
					"LookupValue": null
				},
				"methods": {
					prepareLookupValueList: function(filter, list) {
						var expressionType = this.get("LookupExpressionType");
						var referenceSchema = this.get("LookupReferenceSchema");
						var referenceSchemaName = referenceSchema && referenceSchema.name;
						this.mixins.ExpressionEditVMMixin.prepareValueList(filter, list, expressionType, referenceSchemaName);
					}
				}
			});
			view.bind(viewModel);
			view.render(renderTo);
		}
	});


	return BPMSoft.ExpressionEditDemo;
});