define("ExtendedFilterEditViewV2", ["ext-base", "BPMSoft", "sandbox", "ExtendedFilterEditViewV2Resources"],
	function(Ext, BPMSoft, sandbox, resources) {

		function generateView(renderTo) {
			var closePanelImageUrl =
				BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.ClosePanelImage);
			var backImageUrl =
				BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.BackImage);
			var searchFolderIconUrl =
				BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.SearchFolderIcon);
			var view = {
				id: "filteredit",
				renderTo: renderTo,
				selectors: {
					wrapEl: "#filteredit"
				},
				classes: {
					wrapClassName: "filter-edit"
				},
				items: [
					/*{
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
					},*/
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
								style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
								tag: "BackButton",
								hint: resources.localizableStrings.BackButtonHint,
								visible: {bindTo: "isFolderEditMode"},
								click: {
									bindTo: "onGoBackToFolders"
								},
								imageConfig: {
									source: BPMSoft.ImageSources.URL,
									url: backImageUrl
								}
							},
							{
								className: "BPMSoft.Container",
								id: "folder-title-container",
								selectors: {
									el: "#folder-title-container",
									wrapEl: "#folder-title-container"
								},
								classes: {
									wrapClassName: "folder-title-container-wrap"
								},
								visible: {bindTo: "isFolderEditMode"},
								items: [
									{
										className: "BPMSoft.Button",
										style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
										classes: {
											wrapperClass: ["extended-filter-folder-icon"]
										},
										imageConfig: {
											source: BPMSoft.ImageSources.URL,
											url: searchFolderIconUrl
										}
									},
									{
										className: "BPMSoft.Label",
										classes: {
											labelClass: ["extended-filter-folder-caption"]
										},
										caption: {
											bindTo: "getExtendedFolderCaption"
										}
									}
								]
							},
							{
								className: "BPMSoft.Button",
								caption: resources.localizableStrings.ActionsButtonCaption,
								markerValue: resources.localizableStrings.ActionsButtonCaption,
								style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
								classes: {
									wrapperClass: ["extended-filter-btn-actions-wrapper"]
								},
								visible: false,
								menu: {
									items: [
										{
											className: "BPMSoft.MenuItem",
											caption: resources.localizableStrings.GroupMenuItemCaption,
											markerValue: resources.localizableStrings.GroupMenuItemCaption,
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
											markerValue: resources.localizableStrings.UnGroupMenuItemCaption,
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
											markerValue: resources.localizableStrings.MoveUpMenuItemCaption,
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
											markerValue: resources.localizableStrings.MoveDownMenuItemCaption,
											click: {
												bindTo: "moveDown"
											},
											enabled: {
												bindTo: "moveDownButtonVisible"
											}
										}
									]
								}
							},
							{
								className: "BPMSoft.Button",
								tag: "CloseButton",
								markerValue: resources.localizableStrings.CloseButtonCaption,
								classes: {
									wrapperClass: ["extended-filter-button-right"]
								},
								style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
								hint: resources.localizableStrings.CloseButtonHint,
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
						className: "BPMSoft.FilterEdit",
						renderTo: Ext.get("filteredit"),
						filterManager: {
							bindTo: "FilterManager"
						},
						selectedItems: {
							bindTo: "SelectedFilters"
						},
						prepareMappingParametersList: {
							bindTo: "onPrepareMappingParametersList"
						}
					},
					{
						className: "BPMSoft.Container",
						id: "folder-buttons-container",
						classes: {
							wrapClassName: "folder-buttons-container-wrap"
						},
						items: [
							{
								className: "BPMSoft.Button",
								tag: "apply-button",
								caption: resources.localizableStrings.ApplyButtonCaption,
								markerValue: resources.localizableStrings.ApplyButtonCaption,
								style: BPMSoft.controls.ButtonEnums.style.ORANGE,
								click: {
									bindTo: "applyButton"
								}
							},
							{
								className: "BPMSoft.Button",
								tag: "save-button",
								caption: {bindTo: "getSaveButtonCaption"},
								markerValue: resources.localizableStrings.SaveButtonCaption,
								style: BPMSoft.controls.ButtonEnums.style.DEFAULT,
								visible: {bindTo: "getSaveButtonVisibility"},
								click: {
									bindTo: "saveButton"
								}
							},
						]
					}
				]
			};
			return view;
		}

		return {
			generateView: generateView
		};
	});
