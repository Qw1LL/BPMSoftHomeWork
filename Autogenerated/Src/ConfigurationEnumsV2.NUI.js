define("ConfigurationEnumsV2", ["ConfigurationEnumsV2Resources"], function(resources) {
	Ext.ns("BPMSoft.ConfigurationEnums");

	BPMSoft.ConfigurationEnums.CardOperation = {
		VIEW: "view",
		ADD: "add",
		EDIT: "edit",
		COPY: "copy"
	};

	Ext.ns("BPMSoft.RightsEnums");

	BPMSoft.RightsEnums.operationTypes = {
		"read": 0,
		"edit": 1,
		"delete": 2
	};
	BPMSoft.RightsEnums.rightLevels = {
		allow: {
			Value: 1,
			Name: resources.localizableStrings.AllowRightCaption
		},
		allowAndGrant: {
			Value: 2,
			Name: resources.localizableStrings.AllowAndGrantRightCaption
		},
		deny: {
			Value: 0,
			Name: resources.localizableStrings.DenyRightCaption
		}
	};
	BPMSoft.RightsEnums.sysAdminUnitType = {
		"0": "DF93DCB9-6BD7-DF11-9B2A-001D60E938C6",
		"1": "B659F1C0-6BD7-DF11-9B2A-001D60E938C6",
		"2": "B759F1C0-6BD7-DF11-9B2A-001D60E938C6",
		"3": "462E97C7-6BD7-DF11-9B2A-001D60E938C6",
		"4": "472E97C7-6BD7-DF11-9B2A-001D60E938C6",
		"5": "F4044C41-DF2B-E111-851E-00155D04C01D"
	};

	/** @enum
	 * Schema body template.
	 */
	Ext.ns("BPMSoft.ClientUnitSchemaBodyTemplate");
	BPMSoft.ClientUnitSchemaBodyTemplate[BPMSoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA] =
		"define(\"{0}\", [], function() {\r\n" +
		"\treturn {\r\n" +
		"\t\tentitySchemaName: \"{1}\",\r\n" +
		"\t\tattributes: {},\r\n" +
		"\t\tmodules: /**SCHEMA_MODULES*/{}/**SCHEMA_MODULES*/,\r\n" +
		"\t\tdetails: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,\r\n" +
		"\t\tbusinessRules: /**SCHEMA_BUSINESS_RULES*/{}/**SCHEMA_BUSINESS_RULES*/,\r\n" +
		"\t\tmethods: {},\r\n" +
		"\t\tdiff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/\r\n" +
		"\t};\r\n" +
		"});\r\n";
	BPMSoft.ClientUnitSchemaBodyTemplate[BPMSoft.SchemaType.MODULE_VIEW_MODEL_SCHEMA] =
	BPMSoft.ClientUnitSchemaBodyTemplate[BPMSoft.SchemaType.DETAIL_VIEW_MODEL_SCHEMA] =
	BPMSoft.ClientUnitSchemaBodyTemplate[BPMSoft.SchemaType.GRID_DETAIL_VIEW_MODEL_SCHEMA] =
		"define(\"{0}\", [], function() {\r\n" +
		"\treturn {\r\n" +
		"\t\tentitySchemaName: \"{1}\",\r\n" +
		"\t\tdetails: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,\r\n" +
		"\t\tdiff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/,\r\n" +
		"\t\tmethods: {}\r\n" +
		"\t};\r\n" +
		"});\r\n";
	BPMSoft.ClientUnitSchemaBodyTemplate[BPMSoft.SchemaType.GRID_EDIT_DETAIL_VIEW_MODEL_SCHEMA] =
		"define(\"{0}\", [\"ConfigurationGrid\", \"ConfigurationGridGenerator\",\n" +
		"\t\"ConfigurationGridUtilitiesV2\"], function() {\n" +
		"\treturn {\n" +
		"\t\tentitySchemaName: \"{1}\",\n" +
		"\t\tattributes: {\n" +
		"\t\t\t\"IsEditable\": {\n" +
		"\t\t\t\tdataValueType: BPMSoft.DataValueType.BOOLEAN,\n" +
		"\t\t\t\ttype: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,\n" +
		"\t\t\t\tvalue: true\n" +
		"\t\t\t}\n" +
		"\t\t},\n" +
		"\t\tmixins: {\n" +
		"\t\t\tConfigurationGridUtilitiesV2: \"BPMSoft.ConfigurationGridUtilitiesV2\"\n" +
		"\t\t},\n" +
		"\t\tmethods: {\n" +
		"\t\t\tonActiveRowAction: function(buttonTag, primaryColumnValue) {\n" +
		"\t\t\t\tthis.mixins.ConfigurationGridUtilitiesV2.onActiveRowAction.call(this, buttonTag, primaryColumnValue);\n" +
		"\t\t\t}\n" +
		"\t\t},\n" +
		"\t\tdiff: /**SCHEMA_DIFF*/[\n" +
		"\t\t\t{\n" +
		"\t\t\t\t\"operation\": \"merge\",\n" +
		"\t\t\t\t\"name\": \"DataGrid\",\n" +
		"\t\t\t\t\"values\": {\n" +
		"\t\t\t\t\t\"className\": \"BPMSoft.ConfigurationGrid\",\n" +
		"\t\t\t\t\t\"generator\": \"ConfigurationGridGenerator.generatePartial\",\n" +
		"\t\t\t\t\t\"generateControlsConfig\": {\"bindTo\": \"generateActiveRowControlsConfig\"},\n" +
		"\t\t\t\t\t\"changeRow\": {\"bindTo\": \"changeRow\"},\n" +
		"\t\t\t\t\t\"unSelectRow\": {\"bindTo\": \"unSelectRow\"},\n" +
		"\t\t\t\t\t\"onGridClick\": {\"bindTo\": \"onGridClick\"},\n" +
		"\t\t\t\t\t\"activeRowActions\": [\n" +
		"\t\t\t\t\t\t{\n" +
		"\t\t\t\t\t\t\t\"className\": \"BPMSoft.Button\",\n" +
		"\t\t\t\t\t\t\t\"style\": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,\n" +
		"\t\t\t\t\t\t\t\"tag\": \"save\",\n" +
		"\t\t\t\t\t\t\t\"markerValue\": \"save\",\n" +
		"\t\t\t\t\t\t\t\"imageConfig\": {\"bindTo\": \"Resources.Images.SaveIcon\"}\n" +
		"\t\t\t\t\t\t},\n" +
		"\t\t\t\t\t\t{\n" +
		"\t\t\t\t\t\t\t\"className\": \"BPMSoft.Button\",\n" +
		"\t\t\t\t\t\t\t\"style\": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,\n" +
		"\t\t\t\t\t\t\t\"tag\": \"cancel\",\n" +
		"\t\t\t\t\t\t\t\"markerValue\": \"cancel\",\n" +
		"\t\t\t\t\t\t\t\"imageConfig\": {\"bindTo\": \"Resources.Images.CancelIcon\"}\n" +
		"\t\t\t\t\t\t},\n" +
		"\t\t\t\t\t\t{\n" +
		"\t\t\t\t\t\t\t\"className\": \"BPMSoft.Button\",\n" +
		"\t\t\t\t\t\t\t\"style\": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,\n" +
		"\t\t\t\t\t\t\t\"tag\": \"card\",\n" +
		"\t\t\t\t\t\t\t\"markerValue\": \"card\",\n" +
		"\t\t\t\t\t\t\t\"imageConfig\": {\"bindTo\": \"Resources.Images.CardIcon\"}\n" +
		"\t\t\t\t\t\t},\n" +
		"\t\t\t\t\t\t{\n" +
		"\t\t\t\t\t\t\t\"className\": \"BPMSoft.Button\",\n" +
		"\t\t\t\t\t\t\t\"style\": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,\n" +
		"\t\t\t\t\t\t\t\"tag\": \"copy\",\n" +
		"\t\t\t\t\t\t\t\"markerValue\": \"copy\",\n" +
		"\t\t\t\t\t\t\t\"imageConfig\": {\"bindTo\": \"Resources.Images.CopyIcon\"}\n" +
		"\t\t\t\t\t\t},\n" +
		"\t\t\t\t\t\t{\n" +
		"\t\t\t\t\t\t\t\"className\": \"BPMSoft.Button\",\n" +
		"\t\t\t\t\t\t\t\"style\": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,\n" +
		"\t\t\t\t\t\t\t\"tag\": \"remove\",\n" +
		"\t\t\t\t\t\t\t\"markerValue\": \"remove\",\n" +
		"\t\t\t\t\t\t\t\"imageConfig\": {\"bindTo\": \"Resources.Images.RemoveIcon\"}\n" +
		"\t\t\t\t\t\t}\n" +
		"\t\t\t\t\t],\n" +
		"\t\t\t\t\t\"initActiveRowKeyMap\": {\"bindTo\": \"initActiveRowKeyMap\"},\n" +
		"\t\t\t\t\t\"activeRowAction\": {\"bindTo\": \"onActiveRowAction\"},\n" +
		"\t\t\t\t\t\"multiSelect\": {\"bindTo\": \"MultiSelect\"}\n" +
		"\t\t\t\t}\n" +
		"\t\t\t}\n" +
		"\t\t]/**SCHEMA_DIFF*/\n" +
		"\t};\n" +
		"});";

	/**
	 * Optimization types.
	 * @enum
	 */
	Ext.ns("BPMSoft.Folder");
	BPMSoft.Folder.OptimizationType = {
		NotApplied: -1,
		TryOptimize: 0,
		Count: 1,
		Data: 2,
		CountAndData: 3,
		AppliedDataTryCount: 4,
		NotAppliedDataTryCount: 5,
		AppliedCountTryData: 6,
		NotAppliedCountTryData: 7,
		CountOver: 8
	};
});
