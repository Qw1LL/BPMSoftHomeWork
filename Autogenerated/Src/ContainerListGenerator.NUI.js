define("ContainerListGenerator", ["ext-base", "BPMSoft", "DesignViewGeneratorV2", "ContainerList"],
	function(Ext, BPMSoft) {
		Ext.define("BPMSoft.configuration.ContainerListGenerator", {
			extend: "BPMSoft.ViewGenerator",
			alternateClassName: "BPMSoft.ContainerListGenerator",

			/**
			 * Class name of the generate items.
			 * @type {String}
			 */
			itemClassName: "BPMSoft.ContainerList",

			/**
			 * Generates view configuration for {@link BPMSoft.ContainerList}.
			 * @protected
			 * @virtual
			 * @param {Object} config Component description.
			 * @return {Object} The generated view configuration.
			 */
			generateGrid: function(config) {
				var id = this.getControlId(config, "BPMSoft.Grid");
				var itemConfig = {
					itemType: BPMSoft.ViewItemType.CONTAINER,
					name: "row-container",
					items: config.itemConfig
				};
				var item = this.generateItem(itemConfig);
				var result = {
					className: this.itemClassName,
					defaultItemConfig: item,
					itemFadeOutDuration: config.itemFadeOutDuration || 0
				};
				if (!config.skipId) {
					result.id = id;
					result.selectors = {wrapEl: "#" + id};
				}
				Ext.apply(result, this.getConfigWithoutServiceProperties(config, ["itemConfig", "generator", "skipId"]));
				this.applyControlConfig(result, config);
				return result;
			}
		});
		return Ext.create("BPMSoft.ContainerListGenerator");
	});
