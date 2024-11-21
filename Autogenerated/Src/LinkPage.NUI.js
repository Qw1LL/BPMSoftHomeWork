define("LinkPage", ["ext-base", "BPMSoft", "LinkPageStructure", "LinkPageResources",
	"ConfigurationConstants", "ConfigurationEnums"],
	function(Ext, BPMSoft, structure, resources, ConfigurationConstants, ConfigurationEnums) {
	structure.userCode = function() {

		var valuePairs = this.entityInfo.valuePairs || [];
		var baseEntitySchemaName;
		BPMSoft.each(valuePairs, function(item) {
			if (item.name === "EntitySchemaName") {
				this.entitySchema = BPMSoft[item.value];
			}
		}, this);

		this.canChangeStructure = false;
		this.name = "LinkPageViewModel";
		this.schema.rightPanel = [];
		this.schema.leftPanel = [{
			type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
			name: "Id",
			columnPath: "Id",
			visible: false,
			viewVisible: false
		}, {
			type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
			name: "Type",
			columnPath: "Type",
			dataValueType: BPMSoft.DataValueType.ENUM,
			visible: false
		}, {
			type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
			name: baseEntitySchemaName,
			columnPath: baseEntitySchemaName,
			dataValueType: BPMSoft.DataValueType.LOOKUP,
			visible: false
		}, {
			type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
			isRequired: true,
			name: "Name",
			columnPath: "Name",
			caption: resources.localizableStrings.LinkCaption,
			dataValueType: BPMSoft.DataValueType.TEXT,
			visible: true
		}, {
			type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
			name: "Notes",
			columnPath: "Notes",
			dataValueType: BPMSoft.DataValueType.TEXT,
			visible: true,
			customConfig: {
				className: "BPMSoft.controls.MemoEdit",
				height: "100px"
			}
		}];

		this.methods.getHeader = function() {
			return resources.localizableStrings.LinkCaption;
		};

		this.methods.init = function() {
			if (this.action === ConfigurationEnums.CardState.Add) {
				this.set("Type", {value: ConfigurationConstants.FileType.Link});
			}
		};
	};
	return structure;
});
