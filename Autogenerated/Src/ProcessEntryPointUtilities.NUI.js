define("ProcessEntryPointUtilities", ["ModalBox", "ProcessModuleUtilities", "ProcessEntryPointUtilitiesResources",
	"ProcessEntryPointModule"],
	function(ModalBox, ProcessModuleUtilities, resources) {

		Ext.define("BPMSoft.configuration.mixins.ProcessEntryPointUtilities", {
			alternateClassName: "BPMSoft.ProcessEntryPointUtilities",

			statics: {
				/**
				 * Returns if section can processes from section.
				 * @returns {Boolean} Can run processes from section.
				 */
				getCanRunProcessFromSection: function() {
					return BPMSoft.CurrentUser.userType !== BPMSoft.UserType.SSP;
				}
			},

			/**
			 * Process entry point windows width.
			 * @private
			 * @type {Number}
			 */
			processEntryPointModuleWidth: 400,

			/**
			 * Process entry point windows height.
			 * @private
			 * @type {Number}
			 */
			processEntryPointModuleHeight: 205,

			/**
			 * Primary column name.
			 * @type {String}
			 */
			primaryColumnName: "",

			/**
			 * Returns "Visible" for process entry point button.
			 * @param entryPointsCount
			 * @return {Boolean}
			 */
			getProcessEntryPointButtonVisible: function(entryPointsCount) {
				return (entryPointsCount > 0);
			},

			/**
			 * Gets a list of available entry points for entity.
			 * If the entry point is one, it run process. Otherwise - opens a window for selecting entry points
			 */
			handle: function() {
				this.initAvailableProcessEntryPointsList(function(processList) {
					if (!processList) {
						processList = this.Ext.create("BPMSoft.Collection");
					}
					var primaryColumnValue = this.get(this.primaryColumnName);
					var processListCount = processList.getCount();
					if (processListCount > 1) {
						this.openProcessEntryPointModule(processList, primaryColumnValue);
					} else if (processListCount === 1) {
						var process = processList.getByIndex(0);
						var processElementUId = process.value;
						this.openProcess(processElementUId, primaryColumnValue);
					}
				}, this);
			},

			/**
			 * Initialize continuation of work on process by entry in section.
			 */
			onProcessEntryPointGridRowButtonClick: function() {
				this.primaryColumnName = "ActiveRow";
				this.handle();
			},

			/**
			 * Initialize continuation of work on process for the card.
			 */
			onProcessEntryPointButtonClick: function() {
				this.primaryColumnName = "Id";
				this.handle();
			},

			/**
			 * Initialize available process entry points.
			 * @private
			 * @param {Function} callback Callback function
			 * @param {Object} scope Execution context.
			 */
			initAvailableProcessEntryPointsList: function(callback, scope) {
				var primaryColumnValue = this.get(this.primaryColumnName);
				if (!this.entitySchema || !primaryColumnValue) {
					callback.call(scope);
					return;
				}
				var entitySchemaUId = this.entitySchema.uId;
				this.sandbox.publish("GetProcessEntryPointsData", {
					entitySchemaUId: entitySchemaUId,
					recordId: primaryColumnValue,
					callback: function(processes) {
						var collection = this.Ext.create("BPMSoft.Collection");
						this.BPMSoft.each(processes, function(process) {
							collection.add(process.id, {
								value: process.id,
								displayValue: process.caption
							});
						}, this);
						callback.call(scope, collection);
					},
					scope: this
				});
			},

			/**
			 * Initialize section available process list.
			 * @private
			 * @param {BPMSoft.Collection} availableProcessEntryPoints list available process.
			 */
			initSectionAvailableProcessList: function(availableProcessEntryPoints) {
				var sectionAvailableProcesses = this.Ext.create("BPMSoft.Collection");
				if (!availableProcessEntryPoints) {
					this.$ProcessButtonMenuItems = Ext.create("BPMSoft.BaseViewModelCollection");
					availableProcessEntryPoints = this.Ext.create("BPMSoft.Collection");
				}
				if (!this.hasEntitySchemaName()) {
					this.fillRunProcessButtonMenu(availableProcessEntryPoints, sectionAvailableProcesses);
					return;
				}
				var moduleStructure = this.BPMSoft.configuration.ModuleStructure[this.entitySchemaName];
				if (!moduleStructure || !moduleStructure.moduleId) {
					this.fillRunProcessButtonMenu(availableProcessEntryPoints, sectionAvailableProcesses);
					return;
				}
				var esq = this._createRunProcessESQ(moduleStructure.moduleId);
				this.getProcessEntityCollection(esq, function(availableProcesses) {
					this.fillRunProcessButtonMenu(availableProcessEntryPoints, availableProcesses);
				}, this);
			},

			/**
			 * Initialize detail available process list.
			 * @private
			 * @param {BPMSoft.Collection} buttonMenuItems Collection of viewModel menu items.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Execution context.
			 */
			_initDetailAvailableProcessList: function(buttonMenuItems, callback, scope) {
				BPMSoft.chain(
					this.getDetailId,
					function(next, detailId) {
						if (!detailId) {
							this.Ext.callback(callback, scope);
						} else {
							var esq = this._createRunProcessInDetailESQ(detailId);
							this.getProcessEntityCollection(esq, next, this);
						}
					},
					function(next, availableProcesses) {
						this.fillRunProcessButtonMenuItems({
							"buttonMenuItems": buttonMenuItems,
							"availableProcesses": availableProcesses,
							"methodName": "runProcessForSelectedRecords"
						});
						this.Ext.callback(callback, scope);
					}, this);
			},


			/**
			 * Returns available process list.
			 * @private
			 * @param {Function} esq Query to EntitySchema.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Execution context.
			 */
			getProcessEntityCollection: function(esq, callback, scope) {
				esq.getEntityCollection(function(result) {
					if (this.destroyed) {
						return;
					}
					if (result.success) {
						var processes = this.Ext.create("BPMSoft.Collection");
						var entities = result.collection;
						entities.each(function(entity) {
							var id = entity.get("Id");
							processes.add(id, {
								value: id,
								displayValue: entity.get("Caption"),
								parameterUId: entity.get("ParameterUId")
							});
						}, this);
						callback.call(scope, processes);
					} else {
						throw new this.BPMSoft.QueryExecutionException();
					}
				}, scope);
			},

			/**
			 * Returns truth when current schema has entitySchemaName.
			 * @private
			 * @return {Boolean}
			 */
			hasEntitySchemaName: function() {
				return !this.Ext.isEmpty(this.entitySchemaName);
			},

			/**
			 * Creates query for reading available for running processes available in detail.
			 * @param {String} detailId Detail id.
			 * @private
			 * @return {BPMSoft.EntitySchemaQuery} The Query to EntitySchema.
			 */
			_createRunProcessInDetailESQ: function(detailId) {
				var doesParentExists = BPMSoft.createExistsFilter(this._getDetailParentVersionColumn("Id"));
				var doesHasSysDetail = BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
					this._getDetailParentVersionColumn("SysDetail"), detailId);
				var esq = ProcessModuleUtilities.createRunProcessESQ([doesParentExists, doesHasSysDetail]);
				esq.addColumn(this._getDetailParentVersionColumn("ParameterUId"), "ParameterUId");
				return esq;
			},

			/**
			 * Creates query for reading available for running processes available in module.
			 * @private
			 * @param {String} moduleId Module id.
			 * @return {BPMSoft.EntitySchemaQuery} The Query to EntitySchema.
			 */
			_createRunProcessESQ: function(moduleId) {
				var doesParentExists = BPMSoft.createExistsFilter(this._getModuleParentVersionColumn("Id"));
				var doesHasSysDetail = BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
					this._getModuleParentVersionColumn("SysModule"), moduleId);
				var esq;
				var filters = [doesParentExists, doesHasSysDetail];
				if (BPMSoft.ProcessEntryPointUtilities.getCanRunProcessFromSection() || 
					BPMSoft.Features.getIsEnabled("AllowPortalUserRunProcess")) {
					esq = ProcessModuleUtilities.createRunProcessESQ(filters);
					esq.addColumn(this._getModuleParentVersionColumn("ParameterUId"), "ParameterUId");
					const positionColumn = esq.addColumn(this._getModuleParentVersionColumn("Position"), "Position");
					positionColumn.orderDirection = BPMSoft.OrderDirection.ASC;
					positionColumn.orderPosition = 1;
					esq.clientESQCacheParameters = {
						cacheItemName: "RunProcessInModule-" + moduleId + "-SysModuleId"
					}
				} else {
					esq = ProcessModuleUtilities.createRunProcessSelect(filters);
				}
				return esq;
			},

			/**
			 * Return ESQ join string for processInDetails.
			 * @param {String} column Column name in left schema for filter.
			 * @private
			 * @return {String}.
			 */
			_getDetailParentVersionColumn: function(column) {
				return Ext.String.format("[ProcessInDetails:SysSchemaUId:VersionParentUId].{0}", column);
			},

			/**
			 * Return ESQ join string for processInModules.
			 * @param {String} column Column name in left schema for filter.
			 * @private
			 * @return {String}.
			 */
			_getModuleParentVersionColumn: function(column) {
				return BPMSoft.ProcessEntryPointUtilities.getCanRunProcessFromSection()
						? Ext.String.format("[ProcessInModules:SysSchemaUId:VersionParentUId].{0}", column)
						: Ext.String.format("[ProcessInModules:SysSchemaUId:UId].{0}", column);
			},

			/**
			 * @private
			 */
			_getCurrentGridSortingColumns: function() {
				const hasOrderPosition = function(column) {
					return column.orderPosition > -1;
				};
				const createSortingColumnInfo = function(column) {
					return {path: column.columnPath, direction: column.orderDirection, position: column.orderPosition};
				};
				const currentGridDataEsq = this.getGridDataInitializedEsq();
				return currentGridDataEsq.columns.getItems().filter(hasOrderPosition).map(createSortingColumnInfo);
			},

			/**
			 * Opens entry points selection page.
			 * @param {BPMSoft.Collection} processList Entry points.
			 * @param {String} primaryColumnValue Primary column value.
			 */
			openProcessEntryPointModule: function(processList, primaryColumnValue) {
				var moduleId = this.sandbox.id + "_ProcessEntryPointModule";
				var container = ModalBox.show({
					widthPixels: this.processEntryPointModuleWidth,
					heightPixels: this.processEntryPointModuleHeight
				});
				this.sandbox.subscribe("GetProcessEntryPointInfo", function() {
					return {
						processList: processList,
						primaryColumnValue: primaryColumnValue
					};
				}, this, [moduleId]);
				this.sandbox.subscribe("CloseProcessEntryPointModule", function() {
					ModalBox.close();
					this.sandbox.unloadModule(moduleId);
				}, this, [moduleId]);
				this.sandbox.loadModule("ProcessEntryPointModule", {renderTo: container});
			},

			/**
			 * Opens process.
			 * @param processElementUId
			 * @param {String} primaryColumnValue Primary column value.
			 */
			openProcess: function(processElementUId, primaryColumnValue) {
				this.sandbox.publish("ProcessExecDataChanged", {
					procElUId: processElementUId,
					recordId: primaryColumnValue,
					scope: this,
					parentMethodArguments: {id: primaryColumnValue},
					parentMethod: function() {
						/*window.console.log(this.Ext.String.format("Process {0} Error", args.id));*/
					}
				});
			},

			/**
			 * Sets entry points count for entity,
			 * @param {BPMSoft.BaseViewModel} entity
			 */
			setEntryPointsCount: function(entity) {
				this.set("EntryPointsCount", entity.get("EntryPointsCount"));
			},

			/**
			 * Initializes "Run process" menu items.
			 * @protected
			 * @param {Boolean} isCardOpened Indicator that the entity edit page is open.
			 */
			initRunProcessButtonMenu: function(isCardOpened) {
				if (!this.destroyed) {
					this.set("IsCardOpened", isCardOpened);
					if (isCardOpened) {
						this.initAvailableProcessEntryPointsList(this.initSectionAvailableProcessList, this);
					} else {
						this.initSectionAvailableProcessList();
					}
				}
			},

			/**
			 * Initializes "Run process" menu items in detail.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Execution context.
			 * @protected
			 */
			initDetailRunProcessButtonMenu: function(callback, scope) {
				var processButtonMenu = this.get("RunProcessButtonMenuItems");
				if (!processButtonMenu) {
					processButtonMenu = this.Ext.create("BPMSoft.BaseViewModelCollection");
					this.set("RunProcessButtonMenuItems", processButtonMenu);
				}
				if(BPMSoft.ProcessEntryPointUtilities.getCanRunProcessFromSection() ||
					BPMSoft.Features.getIsEnabled("AllowPortalUserRunProcess")) {
					this._initDetailAvailableProcessList(processButtonMenu, callback, scope);
				} else {
					this.Ext.callback(callback, scope);
				}
			},

			/**
			 * Fills separator item to "Run process" menu.
			 * @private
			 * @param {Object} config Separator settings.
			 */
			fillProcessButtonMenuSeparator: function(config) {
				if (BPMSoft.Features.getIsDisabled("RunningProcessesOnMultipleRecordsFromSection") &&
						!config.isCardOpened) {
					return;
				}
				var buttonMenuSeparatorConfig = {
					"values": {
						"Id": config.value,
						"Caption": config.displayValue,
						"Type": "BPMSoft.MenuSeparator"
					}
				};
				var buttonMenuSeparator = this.Ext.create("BPMSoft.BaseViewModel", buttonMenuSeparatorConfig);
				config.buttonMenuItems.add(config.value, buttonMenuSeparator);
			},

			/**
			 * Returns flag that indicates visibility of global run process button.
			 * @protected
			 * @return {boolean}
			 */
			getIsRunProcessButtonVisible: function() {
				var recordProcesses = this.getFilteredBySectionProcesses();
				return !recordProcesses.isEmpty();
			},

			/**
			 * Returns processes filtered by records.
			 * @protected
			 * @return {BPMSoft.Collection}
			 */
			getFilteredBySectionProcesses: function() {
				const sectionProcesses = this.get("RunProcessButtonMenuItems") || Ext.create("BPMSoft.Collection");
				if (BPMSoft.Features.getIsEnabled("RunningProcessesOnMultipleRecordsFromSection")) {
					return sectionProcesses;
				} else {
					return sectionProcesses.filterByFn(function(process) {
						const processTag = process.get("Tag");
						return Ext.isEmpty(processTag.parameter);
					}, this);
				}
			},

			/**
			 * Add record run process menu items.
			 * @protected
			 * @param {BPMSoft.BaseGridRowViewModel} gridRowViewModelConfig Grid row view model.
			 * @param {String} recordId record Id.
			 */
			addRecordRunProcessMenuItems: function(gridRowViewModelConfig, recordId) {
				var sectionProcesses = this.get("RunProcessButtonMenuItems");
				sectionProcesses = sectionProcesses || Ext.create("BPMSoft.Collection");
				var actionMenuItems = Ext.create("BPMSoft.BaseViewModelCollection");
				sectionProcesses.each(function(process) {
						var processTag = process.get("Tag");
						if (!processTag) {
							return true;
						}
						var parameter = processTag.parameter;
						if (parameter && parameter.parameterUId) {
							var menuItem = this._createRecordProcessMenuItem(process, parameter.parameterUId, recordId);
							actionMenuItems.addItem(menuItem);
						}
				}, this);
				gridRowViewModelConfig.values.RunProcessButtonMenuItems = actionMenuItems;
				gridRowViewModelConfig.values.RunProcessButtonVisible = !actionMenuItems.isEmpty();
			},

			/**
			 * Returns record process menu item view model.
			 * @private
			 * @param {BPMSoft.BaseViewModel} process Process view model.
			 * @param {String} parameterUId Parameter UId.
			 * @param {String} recordId Record Id.
			 * @return {BPMSoft.BaseViewModel} Menu item view model.
			 */
			_createRecordProcessMenuItem: function(process, parameterUId, recordId) {
				var processUId = process.get("Id");
				var tagValue = {
					sysProcessUId: processUId,
					parameter: {
						parameterUId: parameterUId,
						parameterValue: recordId
					}
				};
				return Ext.create("BPMSoft.BaseViewModel", {
					values: {
						Id: processUId,
						Tag: tagValue,
						Caption: process.get("Caption"),
						Click: {"bindTo": "runProcessWithParameters"}
					}
				});
			},

			/**
			 * Create "Run process" menu item.
			 * @private
			 * @param {Object} config Menu item settings.
			 * @return {BPMSoft.BaseViewModel} ViewModel menu item.
			 */
			createRunProcessButtonMenuItem: function(config) {
				var tagValue;
				if (config.parameterUId) {
					var parameterValue = null;
					var isCardOpened = this.get("IsCardOpened");
					if (isCardOpened) {
						parameterValue = this.get("PrimaryColumnValue");
					}
					tagValue = {
						sysProcessUId: config.value,
						sysProcessCaption: config.displayValue,
						parameter: {
							parameterUId: config.parameterUId,
							parameterValue: parameterValue
						}
					};
				} else {
					tagValue = config.value;
				}
				var buttonMenuItemConfig = {
					"values": {
						"Id": config.value,
						"Caption": config.displayValue,
						"Click": {"bindTo": config.methodName},
						"Tag": tagValue,
						"MarkerValue": config.displayValue
					}
				};
				return this.Ext.create("BPMSoft.BaseViewModel", buttonMenuItemConfig);
			},

			/**
			 * Fills "Run process" list.
			 * @private
			 * @param {Object} config.
			 */
			fillRunProcessButtonMenuItems: function(config) {
				config.availableProcesses.each(function(availableProcess) {
					availableProcess.methodName = config.methodName;
					var buttonMenuItem = this.createRunProcessButtonMenuItem(availableProcess);
					config.buttonMenuItems.add(availableProcess.value, buttonMenuItem);
				}, this);
			},

			/**
			 * Fill menu "Run process".
			 * @private
			 * @param {BPMSoft.Collection} availableProcessEntryPoints List available process entry points.
			 * @param {BPMSoft.Collection} sectionAvailableProcesses List available process.
			 */
			fillRunProcessButtonMenu: function(availableProcessEntryPoints, sectionAvailableProcesses) {
				var buttonMenuItems = this.getPreparedButtonMenuItems();
				var isRunProcessButtonVisible = false;
				if (!availableProcessEntryPoints.isEmpty()) {
					this.fillProcessEntryPointsMenuItems(availableProcessEntryPoints, buttonMenuItems);
					isRunProcessButtonVisible = true;
				}
				if (!sectionAvailableProcesses.isEmpty()) {
					this.fillRunProcessWithoutParameterMenuItems(sectionAvailableProcesses, buttonMenuItems);
					isRunProcessButtonVisible = true;
				}
				var isCardOpened = this.get("IsCardOpened");
				if (isCardOpened) {
					this._fillCardRunProcessMenuItems(sectionAvailableProcesses, buttonMenuItems,
						isRunProcessButtonVisible);
					return;
				}
				this.fillRunProcessWhitParameterMenuItems(sectionAvailableProcesses, buttonMenuItems);
				this.set("RunProcessButtonMenuItems", buttonMenuItems);
				this.set("IsRunProcessButtonVisible", isRunProcessButtonVisible);
			},

			/**
			 * Adds record specific processes to run process button menu items.
			 * @private
			 * @param {BPMSoft.Collection} sectionProcesses Section processes.
			 * @param {BPMSoft.BaseViewModelCollection} menuItems Menu items.
			 * @param {Boolean} isButtonVisible Flag that indicates run process button visibility.
			 */
			_fillCardRunProcessMenuItems: function(sectionProcesses, menuItems, isButtonVisible) {
				this.fillRunProcessWhitParameterMenuItems(sectionProcesses, menuItems);
				this.set("ProcessButtonMenuItems", menuItems);
				this.set("IsProcessButtonVisible", isButtonVisible);
				if (!this.isAddOrCopyMode()) {
					var properties = [{
						"key": "ProcessButtonMenuItems",
						"value": menuItems
					}, {
						"key": "IsProcessButtonVisible",
						"value": isButtonVisible
					}];
					this.sandbox.publish("GetRunProcessesProperties", properties);
				}
			},

			/**
			 * Returns prepared button menu items collection.
			 * @private
			 * @return {BPMSoft.BaseViewModelCollection}
			 */
			getPreparedButtonMenuItems: function() {
				var buttonMenuItems = this.get("RunProcessButtonMenuItems");
				if (buttonMenuItems) {
					buttonMenuItems.clear();
				} else {
					buttonMenuItems = this.Ext.create("BPMSoft.BaseViewModelCollection");
				}
				return buttonMenuItems;
			},

			/**
			 * Returns truth when current page in "Add" or "Copy" mode.
			 * @private
			 * @return {Boolean}
			 */
			isAddOrCopyMode: function() {
				return this.isAddMode && this.isAddMode() || this.isCopyMode && this.isCopyMode();
			},

			/**
			 * Returns available process without parameters.
			 * @private
			 * @param {BPMSoft.Collection} sectionAvailableProcesses Collection of menu items.
			 * @return {BPMSoft.Collection} Filtered collection.
			 */
			getAvailableProcessWithoutParameterMenuItems: function(sectionAvailableProcesses) {
				return sectionAvailableProcesses.filterByFn(function(processItems) {
					return Ext.isEmpty(processItems.parameterUId);
				});
			},

			/**
			 * Returns available process with parameters.
			 * @private
			 * @param {BPMSoft.Collection} sectionAvailableProcesses Collection of menu items.
			 * @return {BPMSoft.Collection} Filtered collection.
			 */
			getAvailableProcessWhitParameterMenuItems: function(sectionAvailableProcesses) {
				return sectionAvailableProcesses.filterByFn(function(processItems) {
					return !Ext.isEmpty(processItems.parameterUId);
				});
			},

			/**
			 * Fills menu "Process Entry Points".
			 * @private
			 * @param {BPMSoft.Collection} sectionAvailableProcesses Collection of menu items.
			 * @param {BPMSoft.BaseViewModelCollection} buttonMenuItems Collection of viewModel menu items.
			 */
			fillProcessEntryPointsMenuItems: function(availableProcessEntryPoints, buttonMenuItems) {
				var isCardOpened = this.get("IsCardOpened");
				this.fillProcessButtonMenuSeparator({
					"buttonMenuItems": buttonMenuItems,
					"isCardOpened": isCardOpened,
					"value": "separator-continueprocess-menu-item",
					"displayValue": this.get("Resources.Strings.ContinueProcessButtonMenuItemCaption")
				});
				this.fillRunProcessButtonMenuItems({
					"buttonMenuItems": buttonMenuItems,
					"availableProcesses": availableProcessEntryPoints,
					"methodName": "openProcess"
				});
			},

			/**
			 * Fills menu "Run process" with elements without parameters.
			 * @private
			 * @param {BPMSoft.Collection} sectionAvailableProcesses Collection of menu items.
			 * @param {BPMSoft.BaseViewModelCollection} buttonMenuItems Collection of viewModel menu items.
			 */
			fillRunProcessWithoutParameterMenuItems: function(sectionAvailableProcesses, buttonMenuItems) {
				var isCardOpened = this.get("IsCardOpened");
				var processWithoutParameters =
					this.getAvailableProcessWithoutParameterMenuItems(sectionAvailableProcesses);
				if (!processWithoutParameters.isEmpty()) {
					this.fillProcessButtonMenuSeparator({
						"buttonMenuItems": buttonMenuItems,
						"isCardOpened": isCardOpened,
						"value": "separator-beginprocess-menu-item",
						"displayValue": resources.localizableStrings.RunProcessButtonMenuItemCaption
					});
					this.fillRunProcessButtonMenuItems({
						"buttonMenuItems": buttonMenuItems,
						"availableProcesses": processWithoutParameters,
						"methodName": "runProcess"
					});
				}
			},

			/**
			 * Fills menu "Run process" with elements with parameters.
			 * @private
			 * @param {BPMSoft.Collection} sectionAvailableProcesses Collection of menu items.
			 * @param {BPMSoft.BaseViewModelCollection} buttonMenuItems Collection of viewModel menu items.
			 */
			fillRunProcessWhitParameterMenuItems: function(sectionAvailableProcesses, buttonMenuItems) {
				const isCardOpened = this.get("IsCardOpened");
				const processWithParameters =
					this.getAvailableProcessWhitParameterMenuItems(sectionAvailableProcesses);
				if (!processWithParameters.isEmpty()) {
					this.fillProcessButtonMenuSeparator({
						"buttonMenuItems": buttonMenuItems,
						"isCardOpened": isCardOpened,
						"value": "separator-beginprocess-with-parameter-menu-item",
						"displayValue": resources.localizableStrings.RunProcessByRecordButtonMenuItemCaption
					});
					const methodName = isCardOpened ? "runProcessWithParameters" : "runProcessForSelectedRecords";
					this.fillRunProcessButtonMenuItems({
						"buttonMenuItems": buttonMenuItems,
						"availableProcesses": processWithParameters,
						"methodName": methodName
					});
				}
			},

			/**
			 * Run the business processes on multiple records from a section.
			 * @param {Object} config Configuration object.
			 * @param {Object} config.sysProcessUId UId schema of the business process.
			 * @param {Array} config.parameters Process parameters.
			 * @param {Object} config.parameter Process parameter.
			 * @param {Function} config.callback Callback function.
			 * @param {Object} config.scope Callback scope.
			 */
			runProcessForSelectedRecords: function(config) {
				const startConfig = BPMSoft.deepClone(config);
				const selectedRecordsConfig = BPMSoft.deepClone(this.getSelectedRecordsConfig());
				startConfig.selectedRecords = selectedRecordsConfig;
				startConfig.processSchemaUId = config.sysProcessUId;
				startConfig.processSchemaCaption = config.sysProcessCaption;
				startConfig.inputParameterUId = config.parameter.parameterUId;
				startConfig.callback = function(started) {
						if (started && this.$MultiSelect) {
							this.unSetMultiSelect();
						}
				};
				startConfig.scope = this;
				selectedRecordsConfig.entitySchemaName = this.getGridEntitySchemaName();
				if (selectedRecordsConfig.selectAllMode) {
					selectedRecordsConfig.sortingColumns = this._getCurrentGridSortingColumns();
					this.getFilteredRowsCount(function(filteredRowsCount) {
						const unselectedItems = this.getUnselectedItems();
						const recordsCount = filteredRowsCount - unselectedItems.length;
						selectedRecordsConfig.selectAllModeSelectedRecordsCount = recordsCount;
						const singleDataPageSize = this.getRowCount();
						selectedRecordsConfig.displayStartConfirmation = recordsCount > singleDataPageSize;
						BPMSoft.ProcessModuleUtilities.runProcessForMultipleRecords(startConfig);
					}, this);
				} else {
					BPMSoft.ProcessModuleUtilities.runProcessForMultipleRecords(startConfig);
				}
			}
		});
		return BPMSoft.ProcessEntryPointUtilities;
	});
