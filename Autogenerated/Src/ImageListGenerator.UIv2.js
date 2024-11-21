define("ImageListGenerator", ["ext-base", "BPMSoft", "ViewGeneratorV2", "ImageList"],
	function(Ext, BPMSoft) {
		Ext.define("BPMSoft.configuration.ImageListGenerator", {
			singleton: true,
			extend: "BPMSoft.ViewGenerator",
			alternateClassName: "BPMSoft.ImageListGenerator",

			/**
			 * ########## ############ ############# ### {BPMSoft.ContainerList}.
			 * @protected
			 * @virtual
			 * @param {Object} config ######## ######## #############.
			 * @return {Object} ########## ############### ############# ContainerList.
			 */
			generateImageList: function(config) {
				var result = {
					className: "BPMSoft.ImageList",
					value: {
						bindTo: this.getItemBindTo(config)
					},
					list: {
						bindTo: this.getExpandableListName(config)
					}
				};
				Ext.apply(result, this.getConfigWithoutServiceProperties(config, ["generator"]));
				this.applyControlConfig(result, config);
				return result;
			}
		});

		return BPMSoft.configuration.ImageListGenerator;
	});
