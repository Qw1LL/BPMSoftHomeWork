define("MappingEnums", [], function() {

	Ext.ns("BPMSoft.MappingEnums");

	/**
	 * Mapping type.
	 * @enum
	 */
	BPMSoft.MappingEnums.MappingType = {
		ALL: 0,
		PROCESS_ELEMENT_PARAMETERS: 1,
		PROCESS_PARAMETERS: 2,
		LOOKUP: 4,
		SYSTEM_SETTINGS: 8,
		SYSTEM_VARIABLES: 16,
		FUNCTIONS: 32,
		DATE_TIME: 64
	};

	/**
	 * Mapping type unions.
	 * @enum
	 */
	BPMSoft.MappingEnums.MappingUnion = {
		PROCESS_AND_ELEMENT_PARAMETERS: BPMSoft.MappingEnums.MappingType.PROCESS_PARAMETERS |
			BPMSoft.MappingEnums.MappingType.PROCESS_ELEMENT_PARAMETERS
	};

	/**
	 * Designer type.
	 * @enum
	 */
	BPMSoft.MappingEnums.DesignerType = {
		PROCESS_DESIGNER: "Process",
		DCM_DESIGNER: "Dcm"
	};

});
