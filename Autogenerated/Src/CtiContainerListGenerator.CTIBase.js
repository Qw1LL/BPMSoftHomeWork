define("CtiContainerListGenerator", ["ext-base", "BPMSoft", "DesignViewGeneratorV2", "CtiContainerList"],
	function(Ext, BPMSoft) {
		var viewGenerator = Ext.define("BPMSoft.configuration.CtiContainerListGenerator", {
			extend: "BPMSoft.ViewGenerator",
			alternateClassName: "BPMSoft.CtiContainerListGenerator",

			/**
			 * ########## ############ ############# ### {BPMSoft.CtiContainerList}.
			 * @protected
			 * @virtual
			 * @param {Object} config ######## ######## #############.
			 * @return {Object} ########## ############### ############# CtiContainerList.
			 */
			generateGrid: function(config) {
				var id = this.getControlId(config, "BPMSoft.Grid");
				var itemConfig = {
					itemType: BPMSoft.ViewItemType.CONTAINER,
					name: "row-container",
					items: config.itemConfig
				};
				this.generateItem(itemConfig);
				var result = {
					className: "BPMSoft.CtiContainerList",
					id: id,
					selectors: { wrapEl: "#" + id }
				};
				Ext.apply(result, this.getConfigWithoutServiceProperties(config, ["itemConfig"]));
				this.applyControlConfig(result, config);
				return result;
			}
		});

		return Ext.create(viewGenerator);
	});
