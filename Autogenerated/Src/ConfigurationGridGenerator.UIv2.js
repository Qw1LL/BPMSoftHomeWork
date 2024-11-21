define("ConfigurationGridGenerator", ["ext-base", "ViewGeneratorV2"],
	function(Ext) {

		Ext.define("BPMSoft.configuration.ConfigurationGridGenerator", {
			extend: "BPMSoft.ViewGenerator",
			alternateClassName: "BPMSoft.ConfigurationGridGenerator",

			/**
			 * @inheritdoc BPMSoft.ViewGeneratorV2#addLinks
			 * @overridden
			 */
			addLinks: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.ViewGeneratorV2#generateGridCellValue
			 * @overridden
			 */
			generateGridCellValue: function(config) {
				var cellValue = {};
				var type = config.type;
				cellValue.name = config.value || {bindTo: config.bindTo};
				switch (type) {
					case BPMSoft.GridCellType.TITLE:
						cellValue.type = BPMSoft.GridKeyType.TITLE;
						break;
					default:
						cellValue.type = BPMSoft.GridKeyType.TEXT;
						break;
				}
				return cellValue;
			}
		});
		return Ext.create("BPMSoft.ConfigurationGridGenerator");

	});
