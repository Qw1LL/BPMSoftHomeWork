define("LookupPageViewGenerator", ["ext-base", "BPMSoft", "LookupPageViewGeneratorResources", "GridUtilities",
	"ViewUtilities", "ModuleUtils"],
	function(Ext, BPMSoft, resources, gridUtils, viewUtilities, moduleUtils) {
		function getLookupConfig(args) {
			var isTiled = args.columnsSettingsProfile.isTiled;
			var schema = args.entitySchema;
			var hierarchicalColumnName = schema.hierarchicalColumnName;
			if (!Ext.isEmpty(args.hierarchicalColumnName)) {
				hierarchicalColumnName = args.hierarchicalColumnName;
			}
			if (Ext.isEmpty(hierarchicalColumnName)) {
				args.hierarchical = false;
			}
			return {
				className: "BPMSoft.Grid",
				id: "grid",
				markerValue: "LookupGrid",
				type: isTiled ? "tiled" : "listed",
				useListedLookupImages: args.useListedLookupImages || false,
				primaryColumnName: schema.primaryColumnName,
				canChangeMultiSelectWithGridClick: false,
				multiSelect: {bindTo: "multiSelect"},
				isEmpty: {bindTo: "IsGridEmpty"},
				isLoading: {"bindTo": "IsGridLoading"},
				hierarchical: args.hierarchical,
				hierarchicalColumnName: "parentId",
				watchRowInViewport: 2,
				captionsConfig: [{
					cols: 10,
					name: args.captionConfig
				}],
				scrollElId: "grid-area-container",
				columnsConfig: [{
					key: [
						{
							name: {
								bindTo: schema.primaryDisplayColumnName
							}
						}
					]
				}],
				collection: {bindTo: "gridData"},
				watchedRowInViewport: {bindTo: "loadNext"},
				expandHierarchyLevels: {bindTo: "expandHierarchyLevels"},
				updateExpandHierarchyLevels: {bindTo: "onExpandHierarchyLevels"},
				selectedRows: {bindTo: "selectedRows"},
				activeRow: {bindTo: "activeRow"},
				openRecord: {bindTo: "dblClickGrid"},
				sortColumn: {bindTo: "sortColumn"},
				sortColumnDirection: {bindTo: "gridSortDirection"},
				sortColumnIndex: {bindTo: "sortColumnIndex"}
			};
		}
		
		function getActionButtonsContainerConfig(leftContainerActionButtonConfigItems, rightContainerActionButtonConfigItems) {
			const actionButtonsContainer = 
				viewUtilities.getContainerConfig("action-buttons-container", ["action-buttons-container"]);
			const leftActionButtonsContainer =
				viewUtilities.getContainerConfig("left-action-buttons-container", ["left-action-buttons-container"]);
			const rightActionButtonsContainer =
				viewUtilities.getContainerConfig("right-action-buttons-container", ["right-action-buttons-container"]);

			leftActionButtonsContainer.items = leftContainerActionButtonConfigItems ?? [];
			rightActionButtonsContainer.items = rightContainerActionButtonConfigItems ?? [];
			
			actionButtonsContainer.items = [leftActionButtonsContainer, rightActionButtonsContainer];

			if (leftContainerActionButtonConfigItems.length === 0 && rightContainerActionButtonConfigItems.length === 0)
				actionButtonsContainer.visible = false;
			
			return actionButtonsContainer; 
		}
		
		function buildFixedAreaContainer(args, getViewModelPropertyValue) {
			const headerContainer = getHeaderConfig(args);
			const settingsButtonControlsConfig = getSettingsButtonControlsConfig(args);
			settingsButtonControlsConfig.classes.wrapperClass = "lookup-grid-settings-button-wrapperEl";
			settingsButtonControlsConfig.menu.items = 
				settingsButtonControlsConfig.menu.items.filter(menuItem => menuItem.tag !== "sort-menu");
			
			const editionControlsConfig = getRestrictedEditionControlsConfig(args, getViewModelPropertyValue);

			const filteringControlsConfig = getFilteringControlsConfig(args);
			const selectionControlsConfig = getSelectionControlsConfig(args, getViewModelPropertyValue);
			const leftContainerActionButtonConfigItems =
				(Array.isArray(editionControlsConfig) ? editionControlsConfig : [editionControlsConfig])
					.concat((selectionControlsConfig && selectionControlsConfig.items.length > 0 ? [selectionControlsConfig] : []));

			let rightContainerActionButtonConfigItems = [];
				rightContainerActionButtonConfigItems = settingsButtonControlsConfig;
				filteringControlsConfig.items = filteringControlsConfig.items.concat(settingsButtonControlsConfig);
			
			const actionButtonsContainer = getActionButtonsContainerConfig(leftContainerActionButtonConfigItems, rightContainerActionButtonConfigItems);

			return [
				headerContainer,
				actionButtonsContainer,
				filteringControlsConfig
			];
		}
		
		function getSpecialsClassnames(args) {
			return [
				`container-lookup-${args.entitySchemaName}-entity`,
				args.lookupPageId ? `container-lookup-page-${args.lookupPageId}` : ''];
		}

		function getFixedAreaConfig(args, getViewModelPropertyValue) {
			var fixedAreaContainer = viewUtilities.getContainerConfig("fixed-area-container", [
				"containerLookupPage", "container-lookup-page-fixed"]
				.concat(getSpecialsClassnames(args)));
			fixedAreaContainer.items = buildFixedAreaContainer(args, getViewModelPropertyValue); 
			
			return fixedAreaContainer;
		}

		function getGridAreaConfig(args) {
			var wrapClasses = ["containerLookupPage", "container-lookup-page-grid"];
			if (args.gridWrapClasses) {
				wrapClasses = wrapClasses.concat(args.gridWrapClasses);
			}
			var containerClass = args.columnsSettingsProfile.isTiled ? "tiled-container" : "listed-container";
			wrapClasses.push(containerClass);
			var gridContainer = viewUtilities.getContainerConfig("grid-area-container", wrapClasses);
			var lookupConfig = getLookupConfig(args);
			var addButtonCountLabelContainer = (args?.showButtonConfig?.addButtonCount ?? true) ? [getAddButtonCountConfig(args)] : [];
			addColumnConfigToGrid(lookupConfig, args.columnsSettingsProfile);
			gridContainer.items = [lookupConfig];
			var selectAllSpan = {
				id: "SelectAllHeaderCheckbox",
				className: "BPMSoft.CheckBoxEdit",
				visible: { 
					bindTo: "IsGridEmpty",
					bindConfig: {
						converter: function(value) {
							return !value && args.multiSelect;
						}
					}
				},
				click: { bindTo: "changeflagAllSelected" }
			};

			
			return {
				className: "BPMSoft.Container",
				classes: {
					wrapClassName: getSpecialsClassnames(args)
				},
				markerValue: "LookupGridContainer",
				items: [selectAllSpan, gridContainer].concat(addButtonCountLabelContainer)
			};
		}

		function getHeaderConfig(args) {
			var commandLineEnabled = args.commandLineEnabled || false;
			var moduleHeaderCaption = ["header-name-container"];
			if (!commandLineEnabled) {
				moduleHeaderCaption.push("header-name-container-full");
			}
			var headerContainer = viewUtilities.getContainerConfig("headContainer", ["header"]);
			var headerNameContainer = viewUtilities.getContainerConfig("header-name-container", moduleHeaderCaption);
			var closeIconContainer = viewUtilities.getContainerConfig("close-icon-container", moduleHeaderCaption);
			closeIconContainer.items = [{
				className: "BPMSoft.Button",
				style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
				imageConfig: resources.localizableImages.CloseIcon,
				classes: {wrapperClass: ["close-btn-user-class"]},
				selectors: {wrapEl: "#headContainer"},
				click: {bindTo: "cancelButton"}
			}];
			headerNameContainer.items = [{
				className: "BPMSoft.Label",
				markerValue: {
					bindTo: "lookupSchemaName"
				},
				caption: {bindTo: "captionLookup"}
			}];
			var commandLineContainer = viewUtilities.getContainerConfig("module-command-line", ["module-command-line"]);
			commandLineContainer.visible = commandLineEnabled;
			headerContainer.items = [headerNameContainer];
			if (args.mode !== "processMode") {
				headerContainer.items.push(closeIconContainer);
			} else {
				headerContainer.items.push(commandLineContainer);
			}
			return headerContainer;
		}

		function getRequiredPages(args) {
			var pages = [];
			var entityStructure = moduleUtils.getEntityStructureByName(args.entitySchemaName);
			if (entityStructure && entityStructure.pages) {
				var excludedTypes = args.excludedTypes;
				if (excludedTypes) {
					excludedTypes = excludedTypes.map(function(excludedType) {
						return excludedType.toUpperCase();
					});
					BPMSoft.each(entityStructure.pages, function(page) {
						if (excludedTypes.indexOf(page.UId.toUpperCase()) === -1) {
							pages.push(page);
						}
					}, this);
				} else {
					pages = BPMSoft.deepClone(entityStructure.pages);
				}
			}
			return pages;
		}

		function getSelectionControlsConfig(args, getViewModelPropertyValue) {
			var pages = getRequiredPages(args);
			var addButtonConfig = {
				className: "BPMSoft.Button",
				caption: resources.localizableStrings.AddButtonCaption,
				classes: {
					textClass: ["main-buttons"],
					wrapperClass: ["main-buttons"]
				},
				click: {bindTo: "actionButtonClick"},
				tag: "add",
				style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT_ORANGE
			};
			if (pages.length === 0) {
				addButtonConfig.visible = false;
			} else if (pages.length > 1) {
				delete addButtonConfig.tag;
				delete addButtonConfig.click;
				var menu = addButtonConfig.menu = {};
				var items = menu.items = [];
				BPMSoft.each(pages, function(page) {
					var cardSchema = page.cardSchema;
					var caption = page.caption;
					var typeUId = page.UId;
					var typeColumnName = page.typeColumnName;
					var tag = ["add", cardSchema];
					if (typeUId) {
						tag.push(typeUId);
					}
					if (typeColumnName) {
						tag.push(typeColumnName);
					}
					items.push({
						caption: caption,
						tag: tag.join("/"),
						click: {bindTo: "actionButtonClick"}
					});
				}, this);
			}
			if (args.canAddWithoutPages) {
				addButtonConfig.visible = true;
			}
			var selectionControlsContainer = 
				viewUtilities.getContainerConfig("selectionControlsContainerLookupPage", ["controlsContainerLookupPage"]);
			
			selectionControlsContainer.visible = !args.mode;
			selectionControlsContainer.items = [];
			
			const isVisibleAddButton = args?.showButtonConfig?.addButton;
			const isVisibleActionsMenu = args?.showButtonConfig?.actionsMenu;
			const defaultIsVisibleAddButton = getViewModelPropertyValue("hasActions") && selectionControlsContainer.visible;

			if(isVisibleActionsMenu ?? defaultIsVisibleAddButton)
				selectionControlsContainer.items.push({
					className: "BPMSoft.Button",
					style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT_ORANGE,
					caption: resources.localizableStrings.ActionButtonCaption,
					tag: "ActionButton",
					classes: {wrapperClass: ["action-buttons"]},
					menu: {items: args.actionsMenuConfig},
				});
			
			if(isVisibleAddButton ?? defaultIsVisibleAddButton)
				selectionControlsContainer.items.push(addButtonConfig);
				
			return selectionControlsContainer.items.length > 0 ? selectionControlsContainer : null;
		}
		
		function getEditionControlsConfigItems(addButtonInActionsMenu) {
			var copyButtonConfig = {
				className: "BPMSoft.MenuItem",
				caption: resources.localizableStrings.CopyButtonCaption,
				tag: "copy",
				classes: {textClass: ["main-buttons"]},
				click: {bindTo: "actionButtonClick"},
				enabled: {bindTo: "isSingleSelected"}
			};
			var editButtonConfig = {
				className: "BPMSoft.MenuItem",
				caption: resources.localizableStrings.EditButtonCaption,
				tag: "edit",
				classes: {textClass: ["main-buttons"]},
				click: {bindTo: "actionButtonClick"},
				enabled: {bindTo: "isSingleSelected"}
			};
			var deleteButtonConfig = {
				className: "BPMSoft.MenuItem",
				caption: resources.localizableStrings.DeleteButtonCaption,
				classes: {textClass: ["main-buttons"]},
				click: {bindTo: "onDelete"},
				enabled: {bindTo: "isAnySelected"}
			};
			const addButtonConfig = {
				className: "BPMSoft.MenuItem",
				tag: "add",
				caption: resources.localizableStrings.AddButtonCaption,
				classes: {textClass: ["main-buttons"]},
				click: {bindTo: "actionButtonClick"}
			};
			
			return addButtonInActionsMenu 
				? [addButtonConfig, copyButtonConfig, editButtonConfig, deleteButtonConfig]
				: [copyButtonConfig, editButtonConfig, deleteButtonConfig]; 
		}

		function getProcessControlsConfig(args) {
			return {
				className: "BPMSoft.Container",
				id: "processControlsContainerLookupPage",
				selectors: {
					wrapEl: "#processControlsContainerLookupPage"
				},
				classes: {
					wrapClassName: ["controlsContainerLookupPage"]
				},
				visible: args.mode === "processMode",
				items: [
					{
						className: "BPMSoft.Button",
						style: BPMSoft.controls.ButtonEnums.style.ORANGE,
						caption: resources.localizableStrings.StartProcessButtonCaption,
						tag: "executeProcess",
						classes: {textClass: ["main-buttons"]},
						click: {bindTo: "actionButtonClick"}
					},
					{
						className: "BPMSoft.Button",
						caption: resources.localizableStrings.CancelButtonCaption,
						tag: "CancelButton",
						classes: {textClass: ["main-buttons"]},
						click: {bindTo: "cancelButton"}
					},
					{
						className: "BPMSoft.Button",
						id: "showProcessLogButton",
						caption: resources.localizableStrings.ShowProcessLogButtonCaption,
						tag: "ShowProcessLogButton",
						classes: {textClass: ["main-buttons"]},
						click: {bindTo: "showProcessLogButton"}
					}
				]
			};
		}

		function getOptionsControlsConfig(args) {
			return {
				className: "BPMSoft.Container",
				id: "optionsContainerLookupPage",
				selectors: {wrapEl: "#optionsContainerLookupPage"},
				classes: {wrapClassName: ["optionsContainerLookupPage"]},
				items: [{
					className: "BPMSoft.Label",
					classes: {labelClass: ["labelEdit"]},
					caption: resources.localizableStrings.CountSelectedRecord,
					visible: args.multiSelect
				}, {
					className: "BPMSoft.Label",
					classes: {labelClass: ["selectedRowsCountLabel"]},
					caption: {
						bindTo: "selectedRowsCount"
					},
					visible: args.multiSelect
				}]
			};
		}

		//Container with addButton, countRowsLabel, cancelButton
		function getAddButtonCountConfig(args) {
			var optionsControlsConfig = getOptionsControlsConfig(args);
			const startButton = {
				className: "BPMSoft.Button",
				style: BPMSoft.controls.ButtonEnums.style.ORANGE,
				caption: args?.showButtonConfig?.mainActionButtonCaption ?? (
					args.isRunProcessPage 
						? resources.localizableStrings.RunButtonCaption 
						: resources.localizableStrings.SelectButtonCaption),
				tag: "SelectButton",
				classes: {textClass: ["main-buttons"]},
				click: {bindTo: "selectButton"}
			}

			var cancelButtonConfig = {
				className: "BPMSoft.Button",
				caption: resources.localizableStrings.CancelButtonCaption,
				tag: "CancelButton",
				classes: {textClass: ["main-buttons"]},
				click: {bindTo: "cancelButton"}
			}

			return {
				className: "BPMSoft.Container",
				id: "addButtonCountConfig",
				selectors: {wrapEl: "#addButtonCountConfig"},
				classes: {wrapClassName: ["addButtonCountConfig"]},
				items: args.multiSelect ? [optionsControlsConfig, startButton, cancelButtonConfig] : [startButton, cancelButtonConfig]
			};
		}

		function getFilteringControlsConfig(args) {
			
			const sortedButtonConfig = gridUtils.getSettingsButtonConfig(args);
			sortedButtonConfig.visible = {
				bindTo: "IsGridEmpty",
				bindConfig: {
					converter: function(value) {
						return args?.showButtonConfig?.sortingButton ?? !value;
					}
				}
			};
			
			const sortingMenuItem = sortedButtonConfig.menu.items.find(menuItem => menuItem.tag === "sort-menu");
			sortedButtonConfig.caption = sortingMenuItem.caption;
			sortedButtonConfig.menu.items = sortingMenuItem.menu.items;
			
			const sortedButtonContainer =
				viewUtilities.getContainerConfig("sort-button-container", ["sort-button-container"]);
			sortedButtonContainer.items = [sortedButtonConfig];
			
			
			return {
				className: "BPMSoft.Container",
				id: "rootFilteringContainerLookupPage",
				selectors: {wrapEl: "#rootFilteringContainerLookupPage"},
				classes: {wrapClassName: ["rootFilteringContainerLookupPage"]},
				items: [{
					className: "BPMSoft.Container",
					id: "filteringContainerLookupPage",
					selectors: {wrapEl: "#filteringContainerLookupPage"},
					classes: {wrapClassName: ["filteringContainerLookupPage"]},
					items: [{
						className: "BPMSoft.ComboBoxEdit",
						id: "columnEdit",
						markerValue: "columnEdit",
						classes: {wrapClass: ["columnEdit"]},
						value: {bindTo: "searchColumn"},
						list: {bindTo: "schemaColumns"},
						prepareList: {bindTo: "getSchemaColumns"}
					}, {
						className: "BPMSoft.TextEdit",
						id: "searchEdit",
						markerValue: "searchEdit",
						classes: {wrapClass: ["searchEdit"]},
						enterkeypressed: {bindTo: "onSearchButtonClick"},
						value: {bindTo: "searchData"},
						afterrender: {
							bindTo: "afterRender"
						}
					}, {
						className: "BPMSoft.Button",
						tag: "SearchButton",
						markerValue: "applyButton",
						style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						classes: {textClass: ["vertical-align-top"],
							wrapperClass: ["search-template-button"]},
						imageConfig: resources.localizableImages.SearchOrangeIcon,
						click: {bindTo: "onSearchButtonClick"}
					},
						sortedButtonContainer
					]
				}]
			};
		}

		function getSettingsButtonControlsConfig(args) {
			if(this.BPMSoft.CurrentUser.userType === this.BPMSoft.UserType.SSP) {
				args.settingsButtonVisible = false;
			}
			return gridUtils.getSettingsButtonConfig(args);
		}

		function addColumnConfigToGrid(gridConfig, columnsSettingsProfile) {
			if (columnsSettingsProfile) {
				var gridsColumnsConfig = columnsSettingsProfile.isTiled ?
					columnsSettingsProfile.tiledColumnsConfig : columnsSettingsProfile.listedColumnsConfig;
				if (gridsColumnsConfig) {
					var columnsConfig = Ext.decode(gridsColumnsConfig);
					if (columnsConfig.length > 0) {
						gridConfig.columnsConfig = columnsConfig;
						if (!columnsSettingsProfile.isTiled) {
							gridConfig.captionsConfig = Ext.decode(columnsSettingsProfile.captionsConfig);
						}
					}
				}
			}
		}

		function getItemsConfig(args) {
			var fixedAreaContainer = viewUtilities.getContainerConfig("fixed-area-container", []);
			var headerContainer = getHeaderConfig(args);
			var selectionControlsConfig = getSelectionControlsConfig(args);
			var editionControlsConfig = getEditionControlsConfig(args);
			var processControlsConfig = getProcessControlsConfig(args);
			var filteringControlsConfig = getFilteringControlsConfig(args);
			var lookupConfig = getLookupConfig(args);
			addColumnConfigToGrid(lookupConfig, args.columnsSettingsProfile);

			if (args.mode !== "processMode") {
				fixedAreaContainer.items = [
					headerContainer,
					selectionControlsConfig,
					editionControlsConfig,
					processControlsConfig,
					filteringControlsConfig
				];
				return [
					fixedAreaContainer,
					lookupConfig
				];
			} else {
				return [
					headerContainer,
					selectionControlsConfig,
					editionControlsConfig,
					processControlsConfig,
					filteringControlsConfig,
					lookupConfig
				];
			}
		}

		function getLoadMoreButtonConfig() {
			var loadButton = gridUtils.getLoadButtonConfig();
			loadButton.classes = {wrapperClass: ["show-all-btn-user-class", "lookuppage-loadbutton-pos"]};
			loadButton.click = {bindTo: "loadNext"};
			loadButton.visible = {bindTo: "advancedVisible"};
			return loadButton;
		}

		function getAdvancedSpinnerConfig() {
			return {
				className: "BPMSoft.ProgressSpinner",
				classes: {extraComponentClasses: "lookuppage-loadspiner-pos"},
				visible: {bindTo: "advancedSpinnerVisible"}
			};
		}

		function getActionsMenuConfig() {
			const actionsMenuConfig = [];
			actionsMenuConfig.push({
				caption: resources.localizableStrings.UnSelectAllActionCaption,
				visible: {bindTo: "isUnSelectAllMenuVisible"},
				enabled: {bindTo: "isAnySelected"},
				click: {bindTo: "clearSelection"},
				tag: 'unselect-all'
			});
			actionsMenuConfig.push({
				caption: resources.localizableStrings.SelectAllActionButtonCaption,
				enabled: {
					bindTo: "IsGridEmpty",
					bindConfig: {
						converter: function(value) {
							return !value;
						}
					}
				},
				visible: {bindTo: "isSelectAllMenuVisible"},
				click: {bindTo: "selectAllRecords"},
				tag: 'select-all'
			});
			actionsMenuConfig.push({
				className: "BPMSoft.MenuSeparator",
				visible: {bindTo: "isUnSelectAllMenuVisible"}
			});
			actionsMenuConfig.push({
				caption: resources.localizableStrings.EditButtonCaption,
				tag: "edit",
				click: {bindTo: "actionButtonClick"},
				visible: {bindTo: "canEdit"},
				enabled: {bindTo: "isSingleSelected"},
			});
			actionsMenuConfig.push({
				caption: resources.localizableStrings.CopyButtonCaption,
				tag: "copy",
				click: {bindTo: "actionButtonClick"},
				visible: {bindTo: "canEdit"},
				enabled: {bindTo: "isSingleSelected"}
			});
			actionsMenuConfig.push({
				caption: resources.localizableStrings.DeleteButtonCaption,
				click: {bindTo: "onDelete"},
				visible: {bindTo: "canDelete"},
				enabled: {bindTo: "isAnySelected"},
				tag: "delete",
			});
			return actionsMenuConfig;
		}

		function getViewConfig(config) {
			var itemsConfig = getItemsConfig(config);
			var loadButton = getLoadMoreButtonConfig();
			var advancedSpinner = getAdvancedSpinnerConfig();
			itemsConfig.push(loadButton);
			itemsConfig.push(advancedSpinner);
			var mainContainer = viewUtilities.getContainerConfig("containerLookupPage", ["containerLookupPage"]);
			mainContainer.items = itemsConfig;
			return mainContainer;
		}

		function getEditionControlsConfig(args) {
			const actionButtonConfigItems =
				getEditionControlsConfigItems(args?.showButtonConfig?.addButtonInActionsMenu);

			const actionButtonConfig = {
				className: "BPMSoft.Button",
				caption: resources.localizableStrings.ActionButtonCaption,
				tag: "ActionButton",
				classes: {wrapperClass: ["action-buttons"]},
				menu: {items: actionButtonConfigItems},
				style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT_ORANGE,
			};

			return {
				className: "BPMSoft.Container",
				id: "editionControlsContainerLookupPage",
				selectors: {wrapEl: "#editionControlsContainerLookupPage"},
				classes: {wrapClassName: ["controlsContainerLookupPage"]},
				items: [actionButtonConfig]
			};
		}

		function getRestrictedEditionControlsConfig(args, getViewModelPropertyValue) {
			return (args?.showButtonConfig?.actionsMenu ?? (getViewModelPropertyValue('hasActions') && args.mode === 'editMode')) 
				? [getEditionControlsConfig(args)] 
				: [];
		}
		
		return {
			generate: getViewConfig,
			generateFixed: getFixedAreaConfig,
			getActionsMenuConfig: getActionsMenuConfig,
			generateGrid: getGridAreaConfig
		};
	});
