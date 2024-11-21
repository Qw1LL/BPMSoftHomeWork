define("QuickFilterViewV2", ["BPMSoft", "FixedFilterViewV2", "FolderFilterViewV2", "CustomFilterViewV2",
	"QuickFilterViewV2Resources", "ConfigurationConstants", "ext-base"],
	function(BPMSoft, FixedFilterView, FolderFilterView, CustomFilterView, resources, ConfigurationConstants) {

		function generate(config) {
			var viewConfig = {
				quickFilterViewConfig: {
					id: config.quickFilterViewContainerName,
					selectors: {
						el: "#" + config.quickFilterViewContainerName,
						wrapEl: "#" + config.quickFilterViewContainerName
					},
					items: [
					],
					classes: {
						wrapperClassName: "filter-main-container"
					}
				}
			};
			if (config.fixedFilterConfig) {
				viewConfig.fixedFilterViewConfig = FixedFilterView.generate(config.fixedFilterConfig);
			}
			if (config.folderFilterConfig) {
				viewConfig.folderFilterViewConfig = FolderFilterView.generate(config.folderFilterConfig);
			}
			if (config.customFilterConfig) {
				viewConfig.customFilterViewConfig = CustomFilterView.generate(config.customFilterConfig);
			}
			return viewConfig;
		}

		function generateFilterViewConfig(filterName, folderType) {
			var viewConfig = {
				id: filterName + "View",
				selectors: {
					el: "#" + filterName + "View",
					wrapEl: "#" + filterName + "View"
				},
				classes: {
					wrapClassName: "filter-inner-container filter-element-container-wrap"
				},
				markerValue: {
					bindTo: "columnCaption"},
				visible: {
					bindTo: "viewVisible",
					bindConfig: {
						converter: function(x) {
							if (x === false) {
								return false;
							}
							return true;
						}
					}
				},
				items: [
					{
						className: "BPMSoft.Container",
						id: filterName + "ViewContainer",
						selectors: {
							el: "#" + filterName + "ViewContainer",
							wrapEl: "#" + filterName + "ViewContainer"
						},
						classes: {
							wrapClassName: "filter-caption-value-container"
						},
						items: [
							{
								className: "BPMSoft.Label",
								classes: {
									labelClass: ["filter-caption-label", "filter-element-with-right-space"]
								},
								caption: {
									bindTo: "columnCaption",
									bindConfig: {
										converter: function(x) {
											if (x) {
												return x + ":";
											}
											return x;
										}
									}
								},
								visible: {
									bindTo: "columnCaption",
									bindConfig: {
										converter: function(x) {
											if (x !== "" && !x) {
												return false;
											}
											return true;
										}
									}
								}
							},
							{
								className: "BPMSoft.Label",
								classes: {
									labelClass: ["filter-value-label", "filter-element-with-right-space"]
								},
								caption: {
									bindTo: "displayValue"
								},
								click: {
									bindTo: "editFilter"
								},
								tag: filterName
							}
						]
					},

					{
						className: "BPMSoft.Button",
						classes: {
							wrapperClass: "filter-remove-button"
						},
						style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						hint: resources.localizableStrings.RemoveButtonHint,
						imageConfig: resources.localizableImages.RemoveButtonImage,
						click: {
							bindTo: "removeFilter"
						},
						tag: filterName
					}
				]
			};
			if (folderType) {
				var menu = [
					{
						className: "BPMSoft.MenuItem",
						caption: resources.localizableStrings.SelectAnotherFolder,
						click: { bindTo: "openFoldersTree"}
					}
				];
				if (folderType.value === ConfigurationConstants.Folder.Type.Search) {
					menu.push(
						{
							className: "BPMSoft.MenuItem",
							caption: resources.localizableStrings.EditFilterGroup,
							click: { bindTo: "openEditFolderItem"},
							tag: filterName
						}
					);
				}
				var folderIcon = {
					className: "BPMSoft.Button",
					classes: {
						wrapperClass: "folder-icon-button"
					},
					caption: {
						bindTo: "displayValue"
					},
					menu:  {
						items: menu
					},
					style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					imageConfig: folderType.value === ConfigurationConstants.Folder.Type.General ?
						resources.localizableImages.GeneralFolderImage : resources.localizableImages.SearchFolderImage,
					tag: filterName
				};
				viewConfig.classes = {
					wrapClassName: "folder-filter-inner-container filter-element-container-wrap"
				};
				var itemsContainer = viewConfig.items[0];
				itemsContainer.items = [folderIcon];
			}

			return viewConfig;
		}

		return {
			generate: generate,
			generateAddSimpleFilterConfig: CustomFilterView.generateAddSimpleFilterConfig,
			getSimpleFilterValueEditConfig: CustomFilterView.getSimpleFilterValueEditConfig,
			generateFilterViewConfig: generateFilterViewConfig,
			//TODO ####### ##### ############
			generateAddSimpleFolderFilterConfig: FolderFilterView.generateAddSimpleFolderFilterConfig,
			generateSimpleEditFilterConfig: FixedFilterView.generateSimpleEditFilterConfig
		};

	});
