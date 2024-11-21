define("GridDesignerEnums", ["GridDesignerEnumsResources"], function() {

	Ext.ns("BPMSoft.GridDesignerEnums");

	/**
	 * Enumeration of list types.
	 * @enum
	 */
	BPMSoft.GridDesignerEnums.GridType = {
		Vertical: 0,
		Listed: 1,
		Tiled: 2,
		Mobile: 3
	};

	/**
	 * Default list settings that depend on the list type.
	 * @enum
	 */
	BPMSoft.GridDesignerEnums.DefaultGridSettings = {};
	BPMSoft.GridDesignerEnums.DefaultGridSettings[BPMSoft.GridDesignerEnums.GridType.Vertical] = {
		columns: 1,
		rows: 1
	};
	BPMSoft.GridDesignerEnums.DefaultGridSettings[BPMSoft.GridDesignerEnums.GridType.Listed] = {
		columns: 24,
		rows: 1
	};
	BPMSoft.GridDesignerEnums.DefaultGridSettings[BPMSoft.GridDesignerEnums.GridType.Tiled] = {
		columns: 24,
		rows: 1
	};
	BPMSoft.GridDesignerEnums.DefaultGridSettings[BPMSoft.GridDesignerEnums.GridType.Mobile] = {
		columns: 1,
		rows: 1
	};

});
