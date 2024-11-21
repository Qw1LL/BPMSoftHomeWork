define("MobileDesignerEnums", ["MobileDesignerEnumsResources"], function() {

	Ext.ns("BPMSoft.MobileDesignerEnums");

	/**
	 * Mobile page settings types.
	 * @enum
	 */
	BPMSoft.MobileDesignerEnums.SettingsType = {
		GridPage: "GridPage",
		RecordPage: "RecordPage",
		Actions: "Actions"
	};

	/**
	 * Embedded detail types.
	 * @enum
	 */
	BPMSoft.MobileDesignerEnums.EmbeddedDetailType = {
		File: "File",
		Visa: "Visa"
	};

	/**
	 * Column view types.
	 * @enum
	 */
	BPMSoft.MobileDesignerEnums.ColumnViewType = {
		Preview: "preview",
		Map: "map",
		Url: "url",
		Phone: "phone",
		Email: "email",
		File: "file",
		Normal: "normal"
	};

	/**
	 * Business rule types.
	 */
	BPMSoft.MobileDesignerEnums.BusinessRuleTypes = {
		Requirement: "BPMSoft.RequirementRule",
		Activation: "BPMSoft.ActivationRule",
		Visibility: "BPMSoft.VisibilityRule",
		MutualFiltration: "BPMSoft.MutualFiltrationRule",
		Filtration: "BPMSoft.FiltrationRule",
		Comparison: "BPMSoft.ComparisonRule",
		RegExp: "BPMSoft.RegExpRule",
		Custom: "BPMSoft.CustomRule",
		FileAndLinksBusinessRule: "BPMSoft.FileAndLinksBusinessRule"
	};

	/**
	 * Business rule events.
	 */
	BPMSoft.MobileDesignerEnums.BusinessRuleEvents = {
		Save: "save",
		ValueChanged: "valuechanged",
		Load: "load"
	};

	/**
	 * Mobile workplace types.
	 */
	BPMSoft.MobileDesignerEnums.WorkplaceType = {
		Portal: "111c7ff1-8224-45b0-a24e-fcc983fc0c70",
		General: "000A9225-728B-4778-A951-C42439FFE024"
	};

});
