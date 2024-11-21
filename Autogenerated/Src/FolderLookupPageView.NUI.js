define('FolderLookupPageView', ['ext-base', 'BPMSoft', 'FolderLookupPageViewResources'], function(Ext, BPMSoft,
		resources) {

	function generate() {
		var viewConfig = {
			id: 'folderLookupContainer',
			selectors: {
				wrapEl: '#folderLookupContainer'
			},
			items: [
				{
					className: 'BPMSoft.Container',
					id: "header",
					selectors: {
						wrapEl: '#header'
					},
					classes : {
						wrapClassName: "header"
					},
					items: [
						{
							className: 'BPMSoft.Label',
							classes: {
								labelClass: ['header-name']
							},
							caption: {
								bindTo: 'groupPageCaption'
							}
						}
					]
				},
				{
					className: 'BPMSoft.Container',
					id: 'buttonsContainer',
					selectors: {
						wrapEl: '#buttonsContainer'
					},
					items: [
						{
							className: 'BPMSoft.Button',
							caption: resources.localizableStrings.SelectButtonCaption,
							style: BPMSoft.controls.ButtonEnums.style.ORANGE,
							tag: 'SelectButton',
							classes: {
								textClass: ['folder-lookup-page-main-buttons']
							},
							click: {
								bindTo: 'selectButton'
							},
							enabled: {
								bindTo: 'selectEnabled'
							}
						},
						{
							className: 'BPMSoft.Button',
							caption: resources.localizableStrings.CancelButtonCaption,
							tag: 'CancelButton',
							classes: {
								textClass: ['folder-lookup-page-main-buttons']
							},
							click: {
								bindTo: 'cancelButton'
							}
						},
						{
							className: 'BPMSoft.Button',
							caption: resources.localizableStrings.ActionButtonCaption,
							tag: 'ActionButton',
							classes: {
								wrapperClass: ['folder-lookup-page-main-buttons']
							},
							visible: {
								bindTo: 'simpleSelectMode',
								bindConfig: {
									converter: function(simpleSelectMode) {
										return !simpleSelectMode;
									}
								}
							},
							menu: {
								items: [
									{
										className: 'BPMSoft.MenuItem',
										caption: resources.localizableStrings.CreateStaticMenuItemCaption,
										click: {
											bindTo: 'addGeneralFolderButton'
										}
									},
									{
										className: 'BPMSoft.MenuItem',
										caption: resources.localizableStrings.CreateDynamicMenuItemCaption,
										click: {
											bindTo: 'addSearchFolderButton'
										}
									},
									{
										className: 'BPMSoft.MenuSeparator'
									},
									{
										className: 'BPMSoft.MenuItem',
										caption: resources.localizableStrings.MoveMenuItemCaption,
										click: {
											bindTo: 'moveFolder'
										},
										enabled: {
											bindTo: 'selectEnabled'
										}
									},
									{
										className: 'BPMSoft.MenuItem',
										caption: resources.localizableStrings.RenameMenuItemCaption,
										click: {
											bindTo: 'editButton'
										},
										visible: {
											bindTo: 'canRename'
										}
									},
									{
										className: 'BPMSoft.MenuItem',
										caption: resources.localizableStrings.DeleteMenuItemCaption,
										click: {
											bindTo: 'deleteButton'
										},
										enabled: {
											bindTo: 'selectEnabled'
										}
									},
									{
										className: 'BPMSoft.MenuItem',
										caption: resources.localizableStrings.EditRightsMenuItemCaption,
										click: {
											bindTo: 'editRights'
										},
										visible: {
											bindTo: 'administratedButtonVisible'
										},
										enabled: {
											bindTo: 'selectEnabled'
										}
									},
									{
										className: 'BPMSoft.MenuSeparator',
										visible: {
											bindTo: 'enableMultiSelect'
										}
									},
									{
										className: 'BPMSoft.MenuItem',
										caption: {
											bindTo: 'multiSelect',
											bindConfig: {
												converter: function(multiSelect) {
													return multiSelect
														? resources.localizableStrings.SelectFolderMenuItemCaption
														: resources.localizableStrings.SelectFoldersMenuItemCaption;
												}
											}
										},
										visible: {
											bindTo: 'enableMultiSelect'
										},
										click: {
											bindTo: 'changeMultiSelectMode'
										}
									}
								]
							}
						}
					]
				},
				{
					className: 'BPMSoft.Container',
					id: 'gridContainer',
					selectors: {wrapEl: '#gridContainer'},
					classes: {wrapClassName: ['folder-lookup-page-left-container']},
					items: [
						{
							className: 'BPMSoft.Grid',
							id: 'foldersGrid',
							type: 'listed',
							primaryColumnName: 'Id',
							selectRow: {bindTo: 'onActiveRowChanged'},
							multiSelect: {bindTo: 'multiSelect'},
							hierarchical: true,
							hierarchicalColumnName: 'Parent',
							columnsConfig: [{
								cols: 24,
								key: [{
									name: {bindTo: 'FolderType'},
									type: BPMSoft.GridKeyType.ICON16LISTED
								}, {
									name: {bindTo: 'Name'}
								}]
							}],
							collection: {bindTo: 'gridData'},
							watchedRowInViewport: {bindTo: 'loadNext'},
							selectedRows: {bindTo: 'selectedRows'},
							activeRow: {bindTo: 'activeRow'},
							openRecord: {bindTo: 'dblClickGrid'},
							expandHierarchyLevels: {bindTo: 'expandHierarchyLevels'},
							useListedLookupImages: true
						}
					]
				}, {
					className: 'BPMSoft.Container',
					id: 'folderEditContainer',
					selectors: {
						wrapEl: '#folderEditContainer'
					},
					classes: {
						wrapClassName: ['folder-lookup-page-right-container']
					},
					visible: {
						bindTo: 'folderInfoVisible'
					},
					items: [
					]
				}
			]
		};
		return viewConfig;
	}

	function getFolderView() {
		var config = {
			caption: resources.localizableStrings.FilterGroupCaption,
			collapsed: false,
			id: 'filteredit',
			selectors: {
				wrapEl: '#filteredit'
			},
			classes: {
				wrapClass: ['folder-lookup-page-right-control-group']
			},
			items: [
				{
					className: 'BPMSoft.Container',
					id: 'folderEditButtonsContainer',
					selectors: {
						wrapEl: '#folderEditButtonsContainer'
					},
					classes: {
						wrapClassName: ['folder-lookup-page-right-inner-container']
					},
					items: [
						{
							className: 'BPMSoft.Button',
							caption: resources.localizableStrings.SaveButtonCaption,
							style: BPMSoft.controls.ButtonEnums.style.ORANGE,
							classes: {
								textClass: ['folder-lookup-page-main-buttons']
							},
							click: {
								bindTo: 'saveButton'
							}
						},
						{
							className: 'BPMSoft.Button',
							caption: resources.localizableStrings.ClearButtonCaption,
							classes: {
								textClass: ['folder-lookup-page-main-buttons']
							},
							click: {
								bindTo: 'clearButton'
							}
						},
						{
							className: 'BPMSoft.Button',
							caption: resources.localizableStrings.ActionButtonCaption,
							style: BPMSoft.controls.ButtonEnums.style.DEFAULT,
							classes: {
								wrapperClass: ['folder-lookup-page-main-buttons']
							},
							visible: {
								bindTo: 'actionsButtonVisible'
							},
							menu: {
								items: [
									{
										className: 'BPMSoft.MenuItem',
										caption: resources.localizableStrings.GroupMenuItemCaption,
										click: {
											bindTo: 'groupItems'
										},
										enabled: {
											bindTo: 'groupButtonVisible'
										}
									},
									{
										className: 'BPMSoft.MenuItem',
										caption: resources.localizableStrings.UnGroupMenuItemCaption,
										click: {
											bindTo: 'unGroupItems'
										},
										enabled: {
											bindTo: 'unGroupButtonVisible'
										}
									},
									{
										className: 'BPMSoft.MenuItem',
										caption: resources.localizableStrings.MoveUpMenuItemCaption,
										click: {
											bindTo: 'moveUp'
										},
										enabled: {
											bindTo: 'moveUpButtonVisible'
										}
									},
									{
										className: 'BPMSoft.MenuItem',
										caption: resources.localizableStrings.MoveDownMenuItemCaption,
										click: {
											bindTo: 'moveDown'
										},
										enabled: {
											bindTo: 'moveDownButtonVisible'
										}
									}
								]
							}
						}
					]
				},
				{
					className: 'BPMSoft.FilterEdit',
					renderTo: Ext.get('filteredit'),
					filterManager: {
						bindTo: 'FilterManager'
					},
					selectedItems: {
						bindTo: 'SelectedFilters'
					},
					selectedFiltersChange: {
						bindTo: 'onSelectedFilterChange'
					}
				}
			]
		};
		return config;
	}

	return {
		generate: generate,
		getFolderView: getFolderView
	};
});
