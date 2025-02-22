﻿define("TagFilterViewGeneratorV2", ["TagFilterViewGeneratorV2Resources", "ContainerList"],
	function(resources) {
		/**
		 * @class BPMSoft.configuration.TagFilterViewGenerator
		 * ##### TagFilterViewGenerator ######### ######### ############# ######## ## ####.
		 */
		return Ext.define("BPMSoft.configuration.TagFilterViewGenerator", {
			alternateClassName: "BPMSoft.TagFilterViewGenerator",

			/**
			 * ######### ######### ############# ######## ## ####.
			 * @param {Object} config ######### ### #########.
			 * @return {Object|null} ######### ### ############# ######## ## #####.
			 */
			generate: function(config) {
				var isShortFilterVisible = config.isShortFilterVisible;
				if (isShortFilterVisible) {
					return null;
				}
				var viewConfig = {
					className: "BPMSoft.Container",
					classes: {
						wrapClassName: ["filter-inner-container", "tag-filters-container"]
					},
					items: [{
						className: "BPMSoft.Container",
						classes: {
							wrapClassName: ["tag-filters-add-button-container"]
						},
						items: [{
							className: "BPMSoft.Button",
							imageConfig: resources.localizableImages.TagFilterIcon,
							style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							click: {"bindTo": "showTagFilterEdit"},
							classes: {
								wrapperClass: ["tag-filters-add-button"],
								imageClass: ["tag-filters-icon"]
							},
							markerValue: "TagFilterAddButton"
						},
						{
							className: "BPMSoft.Label",
							caption: {"bindTo": "TagButtonCaption"},
							click: {"bindTo": "showTagFilterEdit"},
							classes: {
								labelClass: ["tag-filters-add-button-text"]
							}
						}]
					}]
				};
				var containerListConfig = this.generateContainerList(config);
				viewConfig.items.push(containerListConfig);
				return viewConfig;
			},

			/**
			 * ######### ######### ############# ######## ########## ### ########### ######## ## ####.
			 * @param {Object} config ######### ### #########.
			 * @return {Object} ######### ############# ######## ########## BPMSoft.ContainerList.
			 */
			generateContainerList: function(config) {
				var sandboxId = config.sandbox.id;
				var containerListId = sandboxId + "_tag_filters_container_list";
				var containerListConfig = {
					"className": "BPMSoft.ContainerList",
					"id": containerListId,
					idProperty: "Id",
					"selectors": {wrapEl: "#" + containerListId},
					"collection": {bindTo: "TagFilters"},
					"classes": {"wrapClassName": ["tags-container-list"]},
					"rowCssSelector": ".tag-filter-item",
					"onGetItemConfig": {bindTo: "onGetTagItemConfig"},
					"itemPrefix": sandboxId,
					"observableRowNumber": -1
				};
				return containerListConfig;
			}
		});
	});
