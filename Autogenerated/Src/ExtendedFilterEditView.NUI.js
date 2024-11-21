define("ExtendedFilterEditView", ["ext-base", "BPMSoft", "sandbox", "ExtendedFilterEditViewResources"],
	function(Ext, BPMSoft, sandbox, resources) {

		function generateView(renderTo) {
			var closePanelImageUrl =
				BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.ClosePanelImage);
			var view = {
				id: "filteredit",
				renderTo: renderTo,
				selectors: {
					wrapEl: "#filteredit"
				},
				items: [
					{
						className: "BPMSoft.Container",
						id: "module-title",
						selectors: {
							el: "#module-title",
							wrapEl: "#module-title"
						},
						items: [
							{
								className: "BPMSoft.Label",
								classes: {
									labelClass: ["extended-filter-caption"]
								},
								caption: {
									bindTo: "getExtendedFilterCaption"
								},
								visible: true
							},
							{
								className: "BPMSoft.Button",
								tag: "CloseButton",
								classes: {
									wrapperClass: ["extended-filter-button-right"]
								},
								style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
								visible: true,
								imageConfig: {
									source: BPMSoft.ImageSources.URL,
									url: closePanelImageUrl
								},
								click: {
									bindTo: "closeExtendedFilter"
								}
							}
						]
					},
					{
						className: "BPMSoft.Container",
						id: "filter-edit-toolbar",
						selectors: {
							el: "#filter-edit-toolbar",
							wrapEl: "#filter-edit-toolbar"
						},
						classes: {
							wrapClassName: "extended-filter-button-container"
						},
						items: [
							{
								className: "BPMSoft.Button",
								caption: resources.localizableStrings.ApplyButtonCaption,
								style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
								click: {
									bindTo: "applyButton"
								}
							},
							{
								className: "BPMSoft.Button",
								caption: resources.localizableStrings.SaveButtonCaption,
								style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
								click: {
									bindTo: "saveButton"
								}
							},
							{
								className: "BPMSoft.Button",
								caption: resources.localizableStrings.ActionsButtonCaption,
								style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
								classes: {
									wrapperClass: ["extended-filter-btn-actions-wrapper"]
								},
								visible: true,
								menu: {
									items: [
										{
											className: "BPMSoft.MenuItem",
											caption: resources.localizableStrings.GroupMenuItemCaption,
											click: {
												bindTo: "groupItems"
											},
											enabled: {
												bindTo: "groupButtonVisible"
											}
										},
										{
											className: "BPMSoft.MenuItem",
											caption: resources.localizableStrings.UnGroupMenuItemCaption,
											click: {
												bindTo: "unGroupItems"
											},
											enabled: {
												bindTo: "unGroupButtonVisible"
											}
										},
										{
											className: "BPMSoft.MenuItem",
											caption: resources.localizableStrings.MoveUpMenuItemCaption,
											click: {
												bindTo: "moveUp"
											},
											enabled: {
												bindTo: "moveUpButtonVisible"
											}
										},
										{
											className: "BPMSoft.MenuItem",
											caption: resources.localizableStrings.MoveDownMenuItemCaption,
											click: {
												bindTo: "moveDown"
											},
											enabled: {
												bindTo: "moveDownButtonVisible"
											}
										}
									]
								}
							}
						]
					},
					{
						className: "BPMSoft.FilterEdit",
						renderTo: Ext.get("filteredit"),
						filterManager: {
							bindTo: "FilterManager"
						},
						selectedItems: {
							bindTo: "SelectedFilters"
						},
						selectedFiltersChange: {
							bindTo: "onSelectedFilterChange"
						}
					}
				]
			};
			return view;
		}

		return {
			generateView: generateView
		};
	});
