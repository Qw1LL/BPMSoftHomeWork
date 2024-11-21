define("ConfigurationVerticalGridGenerator", ["ext-base", "ViewGeneratorV2"],
	function(Ext) {

		/**
		 * @class BPMSoft.configuration.ConfigurationVerticalGridGenerator
		 * ##### ########## ############# #######.
		 */
		Ext.define("BPMSoft.configuration.ConfigurationVerticalGridGenerator", {
			extend: "BPMSoft.ViewGenerator",
			alternateClassName: "BPMSoft.ConfigurationVerticalGridGenerator",

			/**
			 * @inheritdoc BPMSoft.ViewGeneratorV2#generateGrid
			 * @overridden
			 */
			generateGrid: function() {
				var baseConfig = this.callParent(arguments);
				baseConfig = this.getConfigWithoutServiceProperties(baseConfig, ["isVertical"]);
				return baseConfig;
			},

			/**
			 * @inheritdoc BPMSoft.ViewGeneratorV2#actualizeTiledGridConfig
			 * @overridden
			 */
			actualizeTiledGridConfig: function(gridConfig) {
				this.callParent(arguments);
				this.addLinks(gridConfig.tiledConfig, true);
			}

		});

		return Ext.create("BPMSoft.ConfigurationVerticalGridGenerator");
	});
