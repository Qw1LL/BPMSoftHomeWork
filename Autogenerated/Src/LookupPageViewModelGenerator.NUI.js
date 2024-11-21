define("LookupPageViewModelGenerator", ["ext-base", "BPMSoft", "LookupPageViewModelGeneratorResources",
	"GridUtilities", "GridProfileHelper", "ConfigurationEnums", "MaskHelper", "ProcessModuleUtilities",
	"RightUtilities", "ModuleUtils", "SSPGridMixin", "ColumnUtilities", "MiniPageUtilities", "GridUtilitiesV2",
	"GridProfileColumnsMixin", "QueryCancellationMixin"
], function(Ext, BPMSoft, resources, gridUtils, GridProfileHelper, ConfigurationEnums, MaskHelper,
            ProcessModuleUtilities, RightUtilities, moduleUtils) {
	const LookupModes = {
		EDIT_MODE: "editMode",
		PROCESS_MODE: "processMode"
	};
	let flagAllSelected=false;
	const methods = {

		//region Methods: Private

		/**
		 * Sets focus to the search field.
		 * @private
		 */
		setSearchEditFocused: function() {
			const searchEdit = Ext.getCmp("searchEdit");
			searchEdit.setFocused(true);
		},

		/**
		 * Returns EntitySchemaQuery instance for Lookup entity.
		 * @private
		 * @param {String} lookupSchemaUid Current schema uId.
		 * @return {BPMSoft.EntitySchemaQuery}
		 */
		createLookupEsq: function(lookupSchemaUid) {
			const esq = Ext.create("BPMSoft.EntitySchemaQuery", {rootSchemaName: "Lookup"});
			esq.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_COLUMN, "value");
			esq.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_DISPLAY_COLUMN, "displayValue");
			esq.filters.addItem(BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
				"SysEntitySchemaUId", lookupSchemaUid));
			return esq;
		},

		_getGridInstance: function() {
			return Ext.getCmp("grid");
		},

		_restoreHierarchicalGridState: function() {
			const grid = this._getGridInstance();
			if (grid && grid.resetExpandHierarchyLevel) {
				grid.resetExpandHierarchyLevel();
			}
			this.set("expandedElements", {});
			this.set("expandHierarchyLevels", []);
		},

		//endregion

		//region Methods: Protected

		/**
		 * Loads view model.
		 * @protected
		 * @param {Object} profile Profile registry.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Scope for callback function.
		 */
		load: function(profile, callback, scope) {
			this.init();
			const lookupInfo = this.lookupInfo;
			const selectedValues = lookupInfo.selectedValues;
			if (selectedValues && selectedValues.length) {
				this.set("RestoreSelectedData", lookupInfo.selectedValues);
			}
			this.set("searchColumn", lookupInfo.searchColumn);
			const hasListedColumnsConfig = profile && profile.captionsConfig && profile.listedColumnsConfig;
			const hasTiledColumnsConfig = profile && profile.tiledColumnsConfig;
			if (hasListedColumnsConfig || hasTiledColumnsConfig) {
				this.updateSortColumnsCaptions();
				this.loadData();
				Ext.callback(callback, scope);
			} else {
				this._setDefaultProfile(callback, scope);
			}
			if (this.lookupInfo.isQuickAdd) {
				const entityStructure = BPMSoft.configuration.EntityStructure;
				const schema = entityStructure && entityStructure[this.entitySchema.name];
				if (schema && schema.pages) {
					const cardInfo = this.getCurrentCardInfo();
					this.actionButtonClick("add/" + cardInfo.cardSchemaName);
				}
			}
		},

		/**
		 * @param {Function} callback
		 * @param {Object} scope
		 * @private
		 */
		_setDefaultProfile: function(callback, scope) {
			const newProfile = this.getDefaultProfile();
			BPMSoft.utils.saveUserProfile(newProfile.key, newProfile, true, function(response) {
				if (!response.success) {
					return;
				}
				this.lookupInfo.gridProfile = newProfile;
				this.set("gridProfile", newProfile);
				this.updateSortColumnsCaptions();
				this.loadData();
				Ext.callback(callback, scope);
			}, this);
		},

		/**
		 * It refreshes the contents of the tab.
		 * @protected
		 * @param {Object} lookupInfo The configuration parameters of the object lookup.
		 * @param {String} lookupInfo.columnName lookup column name.
		 * @param {Object} lookupInfo.columnValue Configuration object of lookup column value.
		 * @param {String} lookupInfo.entitySchemaName Lookup entity schema name.
		 * @param {Object} lookupInfo.filters Lookup column filters.
		 * @param {String} lookupInfo.multiLookupColumnName MultiLookup column name.
		 * @param {Boolean} lookupInfo.multiSelect Is multiLookup tag.
		 * @param {String} lookupInfo.searchValue MultiLookup value of search.
		 */
		updateTabContent: function(lookupInfo) {
			const entitySchema = this.entitySchema;
			this.set("searchColumn", {
				value: entitySchema.primaryDisplayColumn.name,
				displayValue: entitySchema.primaryDisplayColumn.caption
			});
			const captionLookup = this.getLookupCaption(entitySchema, lookupInfo);
			this.set("captionLookup", captionLookup);
			this.set("lookupSchemaName", entitySchema.name);
			this.setSearchEditFocused();
		},

		/**
		 * Gets caption which displays at the header of the lookup modal box.
		 * @protected
		 * @param {Object} entitySchema EntitySchema object.
		 * @param {Object} lookupInfo The configuration parameters of the object lookup.
		 * @param {String} lookupInfo.captionLookup Lookup caption.
		 * @return {String} Lookup Caption.
		 */
		getLookupCaption: function(entitySchema, lookupInfo) {
			const localizableStrings = resources.localizableStrings;
			const prefix = localizableStrings.LookupPageCaptionPrefix || localizableStrings.CaptionLookupPage;
			return lookupInfo.captionLookup || prefix + entitySchema.caption;
		},

		//endregion

		//region Methods: Public

		isProcessMode: function() {
			return this.get("lookupMode") === LookupModes.PROCESS_MODE;
		},
		isEditMode: function() {
			return this.get("lookupMode") === LookupModes.EDIT_MODE;
		},

		/**
		 * Returns selected results select query.
		 * @private
		 * @return {BPMSoft.EntitySchemaQuery} Selected results select query.
		 */
		_getSelectedResultsSelectQuery: function() {
			const rootSchema = this.getCurrentSchema();
			const select = Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchema: rootSchema
			});
			select.addColumn(rootSchema.primaryColumnName);
			select.addColumn(rootSchema.primaryDisplayColumnName);
			this.addSelectColumns(select);
			return select;
		},

		/**
		 * Applies selected results select query filters.
		 * @private
		 * @param {Object} args CardModuleResponse message arguments.
		 * @param {BPMSoft.EntitySchemaQuery} select Selected results select query.
		 */
		_applySelectedResultsSelectQueryFilters: function(args, select) {
			const recordId = args.uId || args.primaryColumnValue;
			select.filters.addItem(BPMSoft.createColumnInFilterWithParameters("Id", [recordId]));
			const lookupInfo = this.getLookupInfo();
			const filters = lookupInfo.filters;
			if (filters) {
				if (filters.filterType === BPMSoft.FilterType.FILTER_GROUP) {
					filters.each(function(filter) {
						select.filters.addItem(filter);
					});
				} else {
					select.filters.addItem(filters);
				}
			}
		},

		/**
		 * Returns lookup module id.
		 * @private
		 * @return {String} Lookup module id.
		 */
		_getModuleId: function() {
			const lookupInfo = this.getLookupInfo();
			return Ext.String.format("{0}_{1}_CardModule", this.sandbox.id, lookupInfo.columnName);
		},

		/**
		 * Subscribes on messages of the sandbox.
		 * @protected
		 */
		subscribeSandboxEvents: function() {
			this.sandbox.subscribe("HistoryStateChanged", function() {
				this.hide();
			}, this);
			this.sandbox.subscribe("CardModuleResponse", function(args) {
				if (args.success) {
					const select = this._getSelectedResultsSelectQuery();
					this._applySelectedResultsSelectQueryFilters(args, select);
					select.getEntityCollection(function(response) {
						const result = new BPMSoft.Collection();
						response.collection.each(function(item) {
							result.add(item.get("Id"), this.getResultItem(item));
						}, this);
						this.selectResult(result);
					}, this);
				}
			}, this, [this._getModuleId()]);
		},

		init: function() {
			this.subscribeSandboxEvents();
			this._subscribeOnSelectedRowsChange();
		},

		/**
		 * Subscribe to changes selectedRows.
		 * @private
		 */
		_subscribeOnSelectedRowsChange: function() {
			this.on("change:selectedRows", this.onSelectedRowsChange, this);
		},

		/**
		 * Handles selected rows change event.
		 */
		onSelectedRowsChange: function() {
			if (!this.isMultiSelect()) {
				return;
			}
			let selectedRowsCount = 0;
			if (this.get("SelectAllMode") && this.get("usingMultiAddMixin")) {
				const filteredRowsCount = this.get("filteredRowsCount");
				if (filteredRowsCount) {
					const unselectedItems = this.getUnselectedItems();
					selectedRowsCount = filteredRowsCount - unselectedItems.length;
				}
			} else {
				selectedRowsCount = this.getSelectedRecords().length;
			}
			this.set("selectedRowsCount", selectedRowsCount);
		},

		loadNext: function() {
			if (!this.get("CanLoadMoreData")) {
				return;
			}
			if (!this.destroyed) {
				this.pageNumber++;
				this.loadData();
			}
		},
		getCurrentSchema: function() {
			return this.entitySchema;
		},
		getLookupInfo: function() {
			return this.get("LookupInfo");
		},
		initLoadedColumns: function() {
			this.loadedColumns = [];
			BPMSoft.each(this.getLookupInfo().columns, function(column) {
				this.loadedColumns.push({
					columnPath: column
				});
			}, this);
			const entitySchema = this.getCurrentSchema();
			this.loadedColumns.push({
				columnPath: entitySchema.primaryColumnName
			}, {
				columnPath: entitySchema.primaryDisplayColumnName
			});
			const entityStructure = moduleUtils.getEntityStructureByName(entitySchema.name);
			if (entityStructure) {
				const typeColumnName = entityStructure.pages[0].typeColumnName;
				if ((entityStructure.pages.length > 1) && typeColumnName) {
					this.loadedColumns.push({
						columnPath: typeColumnName
					});
				}
			}
		},
		isGridTiled: function() {
			const columnsSettingsProfile = this.getColumnsProfile();
			return columnsSettingsProfile.isTiled;
		},
		getColumnsProfile: function() {
			const profile = this.get("gridProfile");
			if (profile.listedConfig) {
				const viewGenerator = Ext.create("BPMSoft.ViewGenerator");
				viewGenerator.viewModelClass = this;
				const newProfile = {
					listedConfig: Ext.decode(profile.listedConfig),
					tiledConfig: Ext.decode(profile.tiledConfig),
					isTiled: profile.type === "tiled",
					type: profile.type,
					key: profile.key
				};
				viewGenerator.actualizeGridConfig(newProfile);
				this.clearLinks(newProfile);
				this.set("gridProfile", {
					isTiled: newProfile.isTiled,
					key: newProfile.key,
					listedColumnsConfig: Ext.encode(newProfile.listedConfig.columnsConfig),
					captionsConfig: Ext.encode(newProfile.listedConfig.captionsConfig),
					tiledColumnsConfig: Ext.encode(newProfile.tiledConfig.columnsConfig),
					type: newProfile.type
				});
			}
			return this.get("gridProfile");
		},

		clearLinks: function(profile) {
			BPMSoft.each(profile.listedConfig.columnsConfig, function(item) {
				if (item.hasOwnProperty("link")) {
					delete item.link;
				}
			}, this);
			BPMSoft.each(profile.tiledConfig.columnsConfig, function(rowItem) {
				BPMSoft.each(rowItem, function(item) {
					if (item.hasOwnProperty("link")) {
						delete item.link;
					}
				}, this);
			}, this);
		},

		/**
		 * @param index
		 */
		sortColumn: function(index) {
			const isNewProfileColumnsFormat = this._isNewProfileColumnsFormat();
			if (isNewProfileColumnsFormat) {
				const profile = this.get("Profile");
				this.sortColumnByIndex(profile, index);
			}
			const columnsSettingsProfile = this.getColumnsProfile();
			GridProfileHelper.changeSorting.call(this, {
				index: index,
				columnsSettingsProfile: columnsSettingsProfile
			});
			this.isClearGridData = true;
			this.loadData();
		},

		/**
		 * @private
		 * @return {Boolean}
		 */
		_isNewProfileColumnsFormat: function() {
			if (BPMSoft.Features.getIsDisabled("LookupSafeSorting")) {
				return false;
			}
			const profile = this.get("Profile");
			return Boolean(profile.listedConfig);
		},

		/**
		 * @param tag
		 */
		sortGrid: function(tag) {
			const isNewProfileColumnsFormat = this._isNewProfileColumnsFormat();
			if (isNewProfileColumnsFormat) {
				const profile = this.get("Profile");
				this.sortColumnByTag(profile, tag);
			}
			const columnsSettingsProfile = this.getColumnsProfile();
			GridProfileHelper.changeSorting.call(this, {
				tag: tag,
				columnsSettingsProfile: columnsSettingsProfile
			});
			this.isClearGridData = true;
			this.loadData();
		},

		/**
		 * @param viewColumnsSettingsProfile
		 */
		setColumnsProfile: function(viewColumnsSettingsProfile) {
			this.set("gridProfile", viewColumnsSettingsProfile);
			this._saveUserProfile();
		},

		/**
		 * @private
		 */
		_saveUserProfile: function() {
			const isNewProfileColumnsFormat = this._isNewProfileColumnsFormat();
			const profileProperty = isNewProfileColumnsFormat ? "Profile" : "gridProfile";
			const profile = this.get(profileProperty);
			const profileKey = this.getProfileKey();
			BPMSoft.utils.saveUserProfile(profileKey, profile, false);
		},

		/**
		 * Get query operation type.
		 * @protected
		 * @return {String} Query class.
		 */
		getEsqOperationType: function() {
			return BPMSoft.Features.getIsEnabled("UseSeparatedSelectMethods")
				? BPMSoft.QueryOperationType.LOOKUPSELECT : BPMSoft.QueryOperationType.SELECT;
		},

		getSelect: function() {
			const columnsSettingsProfile = this.getColumnsProfile();
			const select = Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchema: this.getCurrentSchema(),
				useRecordDeactivation: this.get("useRecordDeactivation"),
				operationType: this.getEsqOperationType()
			});
			const profileSortedColumns = {};
			const parameters = [select, columnsSettingsProfile, profileSortedColumns];
			const initSelectActions = [
				this.getLoadedColumnsWithSortedColumnsInitialization,
				function(select) {
					if (!this.loadedColumns) {
						select = null;
					}
				},
				this.addSelectColumns,
				this.initSelectSorting,
				this.pushSelectFilters,
				this.initializePageable
			];
			BPMSoft.each(initSelectActions, function(action) {
				if (action && !Ext.isEmpty(this.parameters[0])) {
					action.apply(this.scope, this.parameters);
				}
			}, {scope: this, parameters: parameters});
			return select;
		},
		getLoadedColumnsWithSortedColumnsInitialization:
		GridProfileHelper.getLoadedColumnsWithSortedColumnsInitialization,
		addSelectColumns: function(select) {
			const columns = select.columns.collection;
			BPMSoft.each(this.loadedColumns, function(column, columnKey) {
				if (!columns.containsKey(columnKey)) {
					select.addColumn(column, columnKey);
				}
			});
		},
		initSelectSorting: function(select) {
			const lookupInfo = this.getLookupInfo();
			if (lookupInfo && lookupInfo.sortedColumns) {
				BPMSoft.each(lookupInfo.sortedColumns, function(item) {
					let column = null;
					if (select.columns.contains(item.name)) {
						column = select.columns.get(item.name);
					} else {
						column = select.addColumn(item.name);
					}
					column.orderPosition = item.orderPosition;
					column.orderDirection = item.orderDirection;
				}, this);
			}
			GridProfileHelper.initSelectSorting.apply(this, arguments);
		},
		pushSelectFilters: function(select) {
			const filters = select.filters;
			const lookupInfo = this.getLookupInfo();
			if (!lookupInfo.columnValue) {
				const searchColumn = this.get("searchColumn");
				const searchData = this.get("searchData");
				if (searchColumn && searchData) {
					const columnPath = searchColumn.value;
					const stringComparisonType = this.getStringColumnComparisonType();
					const filter = select.createColumnFilterWithParameter(stringComparisonType, columnPath,
						searchData);
					filters.add("searchDataFilter", filter);
				}
			} else {
				lookupInfo.columnValue = null;
			}
		},
		initializePageable: function(select) {
			if (!this.pageRowsCount) {
				this.pageRowsCount = this.isGridTiled() ? 15 : 30;
			}
			const config = {
				collection: this.getGridData(),
				primaryColumnName: this.entitySchema.primaryColumnName,
				schemaQueryColumns: select.columns,
				isPageable: !this.loadAll && (this.pageRowsCount > 0),
				rowCount: BPMSoft.useOffsetFetchPaging ? this.pageRowsCount : this.pageRowsCount + 1,
				select: select,
				isClearGridData: this.isClearGridData,
				lookupReferenceSchema: this.getCurrentSchema()
			};
			const lastRecord = this.get("lastRecord");
			if (!Ext.isEmpty(lastRecord)) {
				config.lastRecord = lastRecord;
			}
			gridUtils.initializePageableOptions(select, config);
		},
		loadData: function() {
			if (this.get("RestoreSelectedData")) {
				this.loadSelected();
			}
			const select = this.getSelect();
			const hierarchicalColumnName = this.getHierarchicalColumnName();
			if (!Ext.isEmpty(hierarchicalColumnName)) {
				this.putNestingColumn(select, hierarchicalColumnName);
			}
			this.set("advancedVisible", false);
			this.set("advancedSpinnerVisible", true);
			this.set("IsGridLoading", true);
			const lookupInfo = this.getLookupInfo();
			if (!Ext.isEmpty(lookupInfo.filterObjectPath)) {
				this.updateFilterByFilterObjectPath(select.filters, lookupInfo.filterObjectPath);
			}
			const filters = select.filters;
			if (!Ext.isEmpty(lookupInfo.filters)) {
				filters.add("searchFilter", lookupInfo.filters);
			}
			if (!Ext.isEmpty(hierarchicalColumnName)) {
				select.filters.add("hierarchicalParentFilter",
					this.getFirstLevelFilter(hierarchicalColumnName));
			}
			this.lookupInfo = Ext.apply(this.lookupInfo, {
				lookupFilters: filters
			});
			select.getEntityCollection(this.onLoadData, this);
			this.registerSentQuery("lookupPage_loadData", select);
		},
		getHierarchicalColumnName: function() {
			const lookupInfo = this.getLookupInfo();
			if (lookupInfo.hierarchical) {
				if (!Ext.isEmpty(lookupInfo.hierarchicalColumnName)) {
					return lookupInfo.hierarchicalColumnName;
				}
				return this.getCurrentSchema().hierarchicalColumnName;
			}
			return null;
		},
		loadNesting: function(parentId) {
			const select = this.getSelect();
			const lookupInfo = this.getLookupInfo();
			let hierarchicalColumnName = this.getCurrentSchema().hierarchicalColumnName;
			if (!Ext.isEmpty(lookupInfo.hierarchicalColumnName)) {
				hierarchicalColumnName = lookupInfo.hierarchicalColumnName;
			}
			if (!Ext.isEmpty(hierarchicalColumnName)) {
				select.addColumn(hierarchicalColumnName + ".Id", "parentId");
				this.putNestingColumn(select, hierarchicalColumnName);
			}
			select.rowCount = -1;
			select.isPageable = false;
			if (!Ext.isEmpty(lookupInfo.filterObjectPath)) {
				this.updateFilterByFilterObjectPath(select.filters, lookupInfo.filterObjectPath);
			}
			const filters = select.filters;
			if (!Ext.isEmpty(lookupInfo.filters)) {
				filters.add("searchFilter", lookupInfo.filters);
			}
			if (!Ext.isEmpty(hierarchicalColumnName)) {
				const virtualRootItem = lookupInfo.virtualRootItem;
				if (!Ext.isEmpty(virtualRootItem) && (parentId === virtualRootItem.get("Id"))) {
					select.filters.add("hierarchicalParentFilter",
						this.getFirstLevelFilter(hierarchicalColumnName));
				} else {
					select.filters.add("hierarchicalParentFilter",
						this.getChildFilter(hierarchicalColumnName, parentId));
				}
			}
			select.getEntityCollection(this.onLoadNesting, this);
		},
		afterRender: function() {
			this.setSearchEditFocused();
		},
		onLoadNesting: function(response) {
			let parentId = null;
			if (!Ext.isEmpty(response.collection.getByIndex(0))) {
				parentId = response.collection.getByIndex(0).get("parentId");
			}

			let resultCollection = response.collection;
			const lookupInfo = this.getLookupInfo();
			const virtualRootItem = lookupInfo.virtualRootItem;
			if (!Ext.isEmpty(virtualRootItem) && (!parentId)) {
				const virtualRootItemValues = lookupInfo.virtualRootItemValues;
				virtualRootItem.set("HasNesting", 1);
				let hierarchicalColumnName = this.getCurrentSchema().hierarchicalColumnName;
				if (!hierarchicalColumnName) {
					hierarchicalColumnName = lookupInfo.hierarchicalColumnName;
				}
				resultCollection = Ext.create("BPMSoft.Collection");
				resultCollection.add(0, virtualRootItem);
				response.collection.each(function(item) {
					if (!item.get(hierarchicalColumnName)) {
						item.set(hierarchicalColumnName, virtualRootItemValues);
						item.set("parentId", virtualRootItem.get("Id"));
					}
					resultCollection.add(response.collection.indexOf(item) + 1, item);
				}, this);
				parentId = virtualRootItem.get("Id");
				this.getGridData().clear();
			}
			this.getGridData().loadAll(resultCollection, {
				mode: "child",
				target: parentId
			});
		},
		/**
		 * Handles load data server response.
		 * @param {Object} response Read data response.
		 * @param {Object} options Options needed to insert records into specific grid spot.
		 */
		onLoadData: function(response, options) {
			this.set("IsGridLoading", false);
			const rowConfig = response.collection && response.collection.rowConfig;
			const dataCollection = response.collection || Ext.create("BPMSoft.Collection");
			this.initCanLoadMoreData(dataCollection);
			this.notFoundColumns = this.BPMSoft.ColumnUtilities.findNotFoundColumns(rowConfig);
			const gridProfile = this.get("gridProfile");
			if (gridProfile) {
				const grid = this._getGridInstance();
				const gridColumnConfig = gridProfile.isTiled
					? gridProfile.tiledColumnsConfig
					: gridProfile.listedColumnsConfig;
				if (gridColumnConfig) {
					grid.type = gridProfile.isTiled ? "tiled" : "listed";
					const columnsConfig = Ext.decode(gridColumnConfig);
					if (columnsConfig.length > 0) {
						grid.columnsConfig = columnsConfig;
						if (!gridProfile.isTiled) {
							grid.captionsConfig = Ext.decode(gridProfile.captionsConfig);
						}
					}
					grid.initBindings(grid);
				}
			}
			const gridCollection = this.getGridData();
			if (this.isClearGridData) {
				this.isClearGridData = false;
				gridCollection.clear();
			}
			const lookupInfo = this.getLookupInfo();
			const virtualRootItem = lookupInfo.virtualRootItem;
			if (!Ext.isEmpty(virtualRootItem)) {
				virtualRootItem.set("HasNesting", 1);
				if (gridCollection.isEmpty()) {
					this.loadNesting(virtualRootItem.get("Id"));
					this.set("expandHierarchyLevels", [virtualRootItem.get("Id")]);
				}
			} else {
				this.set("IsGridEmpty", gridCollection.isEmpty() && response.collection.isEmpty());
				const fixedCollection = this.prepareResponseCollection(response.collection);
				gridCollection.loadAll(fixedCollection, options);
			}
			if (!gridCollection.isEmpty()) {
				const lastRecord = gridCollection.getByIndex(gridCollection.getCount() - 1);
				this.set("lastRecord", lastRecord);
			}
			this.set("advancedSpinnerVisible", false);
			if (this.getGridData().getCount() < this.pageRowsCount) {
				this.set("advancedVisible", false);
			} else {
				this.set("advancedVisible", (response.collection.getCount() > 0));
			}
			if (this.get("SelectAllMode") && this.get("usingMultiAddMixin")) {
				this._internalSelectAllRecords(gridCollection);
			}
		},

		/**
		 * Returns grid data.
		 * @protected
		 * @return {BPMSoft.Collection} Grid data.
		 */
		getGridData: function() {
			return this.get("gridData");
		},

		/**
		 * Returns multi selection flag.
		 * @protected
		 * @return {Boolean} Multi selection flag.
		 */
		isMultiSelect: function() {
			return this.get("multiSelect");
		},

		/**
		 * @inheritDoc BPMSoft.GridUtilities#getRowCount
		 * @override
		 */
		getRowCount: function() {
			return this.pageRowsCount;
		},
		prepareResponseCollection: function(dataCollection) {
			const gridCollection = this.getGridData();
			const fixedCollection = Ext.create("BPMSoft.Collection");

			let arrayNotAvailableInStudio;
			let isNotAvailable = false;

			if (BPMSoft.SysSettings.querySysSettings)
			{
				// Получаем версию бандла
				let productEdition = "";
				BPMSoft.SysSettings.querySysSettings(["ProductEdition"], function(values) {
			  		productEdition = values.ProductEdition;
			}, 		this);
			
			// Исключаем Translate из всех бандлов
			arrayNotAvailableInStudio = ["ac795a87-4c44-4c53-99a3-e132c18fdd81"];
	  
			// Лендинги и веб-формы и скоринговые модели исключаются только в Конструкторе
			if(productEdition === "Constructor" || productEdition === "Studio")
			{
			  arrayNotAvailableInStudio =
				["5e00c0e0-9427-451a-9e0f-38e9d6d9e3a5",
				 "b4eeec02-229d-4fb8-b9f7-a22996dd481e",
				"ac795a87-4c44-4c53-99a3-e132c18fdd81"];
			}
			  isNotAvailable = true;
			}
		  
			dataCollection.each(function(item) {
			  let excludeSample = false;
			  if(isNotAvailable)
			  {
			  // Содержит ли ли массив текущий item. Если да, то исключаем этот item из выборки
			  excludeSample = arrayNotAvailableInStudio.includes(item.values.Id);
			  }
			  const itemKey = item.get(item.primaryColumnName);
			  if (!gridCollection.contains(itemKey) && !fixedCollection.contains(itemKey) && !excludeSample) {
				fixedCollection.add(itemKey, item);
			  }
			});
			return fixedCollection;
		},

		loadSelected: function() {
			const restoredIds = this.get("RestoreSelectedData");
			this.set("RestoreSelectedData", null);
			const columnsSettingsProfile = this.getColumnsProfile();
			const select = Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchema: this.getCurrentSchema()
			});
			const profileSortedColumns = {};
			const parameters = [select, columnsSettingsProfile, profileSortedColumns];
			const initSelectActions = [
				this.getLoadedColumnsWithSortedColumnsInitialization,
				function(select) {
					if (!this.loadedColumns) {
						select = null;
					}
				},
				this.addSelectColumns,
				this.initSelectSorting
			];
			BPMSoft.each(initSelectActions, function(action) {
				if (action && !Ext.isEmpty(this.parameters[0])) {
					action.apply(this.scope, this.parameters);
				}
			}, {scope: this, parameters: parameters});
			const filters = select.filters;
			filters.add("selectedIdsFilter", BPMSoft.createColumnInFilterWithParameters("Id", restoredIds));
			this.set("advancedVisible", false);
			this.set("advancedSpinnerVisible", true);
			this.set("IsGridLoading", true);
			select.getEntityCollection(function(response) {
				this.onLoadData(response, {mode: "top"});
				this.setSelectedRecords(restoredIds);
			}, this);
		},

		updateFilterByFilterObjectPath: function(filters, objectPath) {
			if (!Ext.isEmpty(filters.leftExpression)) {
				filters.leftExpression.columnPath =
					objectPath + "." + filters.leftExpression.columnPath;
			} else {
				BPMSoft.each(filters.getItems(), function(item) {
					this.updateFilterByFilterObjectPath(item, objectPath);
				}, this);
			}
		},
		getFirstLevelFilter: function(hierarchicalColumnName) {
			return BPMSoft.createColumnIsNullFilter(hierarchicalColumnName);
		},
		getChildFilter: function(hierarchicalColumnName, parentId) {
			return BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
				hierarchicalColumnName,
				parentId);
		},
		putNestingColumn: function(select, parentColumnName) {
			const serializationInfo = select.filters.getDefSerializationInfo();
			serializationInfo.serializeFilterManagerInfo = true;
			const filters = BPMSoft.deserialize(select.filters.serialize(serializationInfo));
			const lookupInfo = this.getLookupInfo();
			if (!Ext.isEmpty(lookupInfo.filterObjectPath)) {
				this.updateFilterByFilterObjectPath(filters, lookupInfo.filterObjectPath);
			}
			if (!Ext.isEmpty(lookupInfo.filters)) {
				filters.add("searchFilter", lookupInfo.filters);
			}
			const aggregationColumnName = Ext.String.format("[{0}:{1}].Id",
				select.rootSchemaName || select.rootSchema.name, parentColumnName);
			const agrigationColumn = Ext.create("BPMSoft.AggregationQueryColumn", {
				aggregationType: BPMSoft.AggregationType.COUNT,
				columnPath: aggregationColumnName,
				subFilters: filters
			});
			select.addColumn(agrigationColumn, "HasNesting");
		},
		onSearchButtonClick: function() {
			if (this._isConditionChanged()) {
				this.set("previousSearchData", this.get("searchData"));
				this.set("previousSearchColumn", this.get("searchColumn"));
				this.set("activeRow", null);
				this.clear();
				this.loadData();
				this.emptyGridRowHistory();
			}
		},
		/**
		 * Returns true if lookup filter condition change.
		 * @private
		 * @return {Boolean} True if lookup filter condition change.
		 */
		_isConditionChanged: function() {
			const searchColumn = this.get("searchColumn");
			const previousSearchColumn = this.get("previousSearchColumn");
			const searchColumnValue = searchColumn && searchColumn.value;
			const previousSearchColumnValue = previousSearchColumn && previousSearchColumn.value;
			const isChanged = (this.get("searchData") !== this.get("previousSearchData")) ||
				(searchColumnValue !== previousSearchColumnValue);
			return isChanged;
		},
		onExpandHierarchyLevels: function(parentId, isExpanded) {
			const expandedElements = this.get("expandedElements");
			if (isExpanded && !expandedElements.hasOwnProperty(parentId)) {
				expandedElements[parentId] = {
					page: 0
				};
				this.loadNesting(parentId);
			}
		},
		getSelectedRecords: function() {
			const isMultiSelect = this.isMultiSelect();
			const activeRow = this.get("activeRow");
			const selectedRows = this.get("selectedRows");
			return isMultiSelect ? selectedRows : (activeRow && [activeRow]);
		},
		setSelectedRecords: function(rowIds) {
			const isMultiSelect = this.isMultiSelect();
			if (!isMultiSelect) {
				return;
			}
			this.set("selectedRows", rowIds);
		},
		clearSelection: function() {
			this.set("activeRow", null);
			this.set("selectedRows", []);
			this.set("SelectAllMode", false);
			this.set("selectedRowsCount", 0);
		},

		_setSelectedRowCount: function() {
			const isMultiSelect = this.isMultiSelect();
			if (isMultiSelect && this.get("usingMultiAddMixin")) {
				this.getCountItemsByFilters(function(response) {
					if (response.success) {
						const selectResult = response.collection.getByIndex(0);
						const rowsCount = selectResult.get("Count");
						this.set("filteredRowsCount", rowsCount);
						this.set("selectedRowsCount", rowsCount);
					}
				}, this);
			} else {
				const selectedRows = this.get("selectedRows");
				this.set("selectedRowsCount", selectedRows && selectedRows.length);
			}
		},

		_internalSelectAllRecords: function(gridData) {
			const data = gridData || this.getGridData();
			if (data) {
				this._selectGridDataRows(data);
				this._setSelectedRowCount();
			}
		},

		/**
		 * Selects all grid items.
		 */
		selectAllRecords: function() {
			this.set("SelectAllMode", true);
			this._internalSelectAllRecords();
		},

		changeflagAllSelected: function() {
			if (flagAllSelected===false) {
				this.selectAllRecords();
				flagAllSelected=true;
				return;
			}
			if (flagAllSelected===true) {
				this.clearSelection();
				flagAllSelected=false;
				return;
			}
		},
		
		/**
		 * Selects grid data rows.
		 * @private
		 * @param {BPMSoft.Collection} gridData Grid data.
		 */
		_selectGridDataRows: function(gridData) {
			const rowKeys = gridData && gridData.getKeys() || [];
			const selectedRows = this.get("selectedRows") || [];
			this.set("selectedRows", this.Ext.Array.merge(selectedRows, rowKeys));
		},

		/**
		 * Initializes count esq filters.
		 * @protected
		 * @override
		 */
		getFilters: function() {
			return this.get("LookupInfo").lookupFilters;
		},

		/**
		 * Generates current filters config for SelectAllMode.
		 * @param {BPMSoft.FilterGroup} Filters.
		 * @return {String} Serialized filters.
		 * @private
		 */
		getSelectAllFiltersConfig: function(filters) {
			const lookupFilters = filters || this.lookupInfo.lookupFilters;
			const filterGroup = this.Ext.create("BPMSoft.FilterGroup");
			filterGroup.addItem(lookupFilters);
			const unselectedItems = this.getUnselectedItems();
			const entitySchema = this.getCurrentSchema();
			if (unselectedItems.length) {
				const notInFilter = this.BPMSoft.createColumnInFilterWithParameters(
					entitySchema.primaryColumnName, unselectedItems);
				notInFilter.comparisonType = BPMSoft.ComparisonType.NOT_EQUAL;
				filterGroup.addItem(notInFilter);
			}
			const filtersConfig = filterGroup.serialize(filterGroup.getDefSerializationInfo());
			return filtersConfig;
		},
		/**
		 * Returns unselected grid rows identifiers.
		 * @return {Array} Unselected grid rows identifiers.
		 */
		getUnselectedItems: function() {
			let result = [];
			const rows = this.getGridData();
			const rowKeys = rows ? rows.getKeys() : [];
			const selectedRows = this.get("selectedRows") || [];
			result = this.Ext.Array.difference(rowKeys, selectedRows);
			return result;
		},
		/**
		 * Returns true is selected one item.
		 * @return {Boolean} Is selected only one item.
		 */
		isSingleSelected: function() {
			const selectedRows = this.getSelectedRecords();
			return selectedRows && (selectedRows.length === 1);
		},
		/**
		 *  Returns true is selected one or many item.
		 * @return {Boolean} Is selected one or many item.
		 */
		isAnySelected: function() {
			const selectedRows = this.getSelectedRecords();
			return selectedRows && (selectedRows.length > 0);
		},
		isUnSelectAllMenuVisible: function() {
			return (this.isMultiSelect() === true);
		},
		isSelectAllMenuVisible: function() {
			return this.isMultiSelect() === true;
		},
		getResultItem: function(item) {
			const primaryColumnName = item.primaryColumnName;
			const primaryDisplayColumnName = item.primaryDisplayColumnName;
			item.values.value = item.values[primaryColumnName];
			item.values.displayValue = item.values[primaryDisplayColumnName];
			const lookupInfo = this.getLookupInfo();
			const multiLookupColumnName = lookupInfo.multiLookupColumnName;
			if (!Ext.isEmpty(multiLookupColumnName)) {
				item.values.column = multiLookupColumnName;
			}
			return item.values;
		},
		selectButton: function() {
			const collection = this.getGridData();
			const result = new BPMSoft.Collection();
			const notLoadedItems = [];
			const records = this.getSelectedRecords();
			if (!Ext.isEmpty(records)) {
				records.forEach(function(recordId) {
					if (collection.contains(recordId)) {
						result.add(recordId, this.getResultItem(collection.get(recordId)));
					} else {
						notLoadedItems.push(recordId);
					}
				}, this);
			}
			if (Ext.isEmpty(notLoadedItems)) {
				this.selectResult(result);
			} else {
				const rootSchema = this.getCurrentSchema();
				const select = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchema: rootSchema
				});
				select.addColumn(rootSchema.primaryColumnName);
				select.addColumn(rootSchema.primaryDisplayColumnName);
				this.addSelectColumns(select);
				select.filters.add("IdFilter", BPMSoft.createColumnInFilterWithParameters("Id", notLoadedItems));
				select.getEntityCollection(function(response) {
					response.collection.each(function(item) {
						const itemId = item.get("Id");
						if(!result.contains(itemId)){
							result.add(itemId, this.getResultItem(item));
						}
					}, this);
					this.selectResult(result);
				}, this);
			}
			flagAllSelected = false;
		},
		selectResult: function(result) {
			const filters = this.get("SelectAllMode")
				? this.getSelectAllFiltersConfig(this.getFilters())
				: null;
			this.sandbox.publish("ResultSelectedRows", {
				selectedRows: result,
				columnName: this.getLookupInfo().columnName,
				filters: filters,
				searchData: this.get("searchData"),
				searchColumn: this.get("searchColumn")
			}, [this.sandbox.id]);
		},
		cancelButton: function() {
			if (this.isProcessMode()) {
				this.sandbox.publish("BackHistoryState");
				return;
			}
			this.close();
			flagAllSelected = false;
		},
		showProcessLogButton: function() {
			this.sandbox.publish("PushHistoryState", {hash: "SectionModule/SysProcessLogSection"});
		},
		updateSortColumnsCaptions: function() {
			const columnsSettingsProfile = this.getColumnsProfile();
			GridProfileHelper.setSortMenu.call(this, columnsSettingsProfile);
			GridProfileHelper.updateSortColumnsCaptions.call(this, columnsSettingsProfile);
		},
		hide: function() {
			BPMSoft.LookupUtilities.HideModalBox();
		},
		close: function() {
			BPMSoft.LookupUtilities.CloseModalBox();
		},
		getCurrentCardInfo: function() {
			const entitySchema = this.getCurrentSchema();
			const entityStructure = moduleUtils.getEntityStructureByName(entitySchema.name);
			const selectedRecords = this.getSelectedRecords();
			const gridData = this.getGridData();
			const editPagesInfo = entityStructure.pages;
			const cardSchemaName = editPagesInfo[0].cardSchema;
			const configAttribute = editPagesInfo[0].typeColumnName;
			const result = {cardSchemaName: cardSchemaName};
			if (Ext.isEmpty(selectedRecords) ||
				gridData.isEmpty() ||
				Ext.isEmpty(configAttribute)) {
				return result;
			}
			const filteredRow = gridData.get(selectedRecords[0]);
			if (Ext.isEmpty(filteredRow)) {
				return result;
			}
			const pageTypeId = filteredRow.get(configAttribute).value;
			const pageObjects = editPagesInfo.filter(function(item) {
				return (item.UId === pageTypeId);
			});
			if (Ext.isEmpty(pageObjects)) {
				return result;
			}
			const pageObject = pageObjects[0];
			const pageObjectCardSchema = pageObject.cardSchema;
			result.cardSchemaName = pageObjectCardSchema || cardSchemaName;
			result.typeUId = pageTypeId;
			result.typeColumnName = configAttribute;
			return result;
		},

		onDelete: function() {
			const items = this.getSelectedRecords();
			if (!items || !items.length) {
				return;
			}
			const checkCanDeleteCallback = function(result) {
				if (result) {
					this.showInformationDialog(resources.localizableStrings[result], BPMSoft.emptyFn, {
						style: BPMSoft.MessageBoxStyles.ORANGE
					});
				} else {
					this.showConfirmationDialog(resources.localizableStrings.OnDeleteWarning, function(returnCode) {
						if (returnCode === BPMSoft.MessageBoxButtons.YES.returnCode) {
							this.onDeleteAccept();
						}
					}, [BPMSoft.MessageBoxButtons.NO.returnCode, BPMSoft.MessageBoxButtons.YES.returnCode]);
				}
			};

			if (items.length === 1) {
				RightUtilities.checkCanDelete({
					schemaName: this.entitySchema.name,
					primaryColumnValue: items[0]
				}, checkCanDeleteCallback, this);
			} else {
				RightUtilities.checkMultiCanDelete({
					schemaName: this.entitySchema.name,
					primaryColumnValues: items
				}, checkCanDeleteCallback, this);
			}
		},

		onDeleteAccept: function() {
			gridUtils.deleteSelectedRecords(this);
		},

		getActionConfig: function(tag) {
			const tags = tag.split("/");
			const currentCardInfo = this.getCurrentCardInfo();
			const cardSchemaName = currentCardInfo.cardSchemaName && !tags[1]
				? currentCardInfo.cardSchemaName
				: tags[1];
			return {
				action: tags[0],
				cardSchemaName: cardSchemaName,
				typeUId: tags[2],
				typeColumnName: tags[3]
			};
		},

		defaultModeActionButtonClick: function(tag) {
			const actionConfig = this.getActionConfig(tag);
			const entitySchema = this.getCurrentSchema();
			const activeRows = this.getSelectedRecords();
			const activeRow = activeRows && (activeRows.length > 0) ? activeRows[0] : null;
			const lookupInfo = this.getLookupInfo();
			if ((actionConfig.action !== ConfigurationEnums.CardState.Add) && !activeRow) {
				return;
			}
			const entityStructure = moduleUtils.getEntityStructureByName(entitySchema.name);
			if (entityStructure) {
				if ((actionConfig.action === ConfigurationEnums.CardState.Edit) ||
					(actionConfig.action === ConfigurationEnums.CardState.Copy)) {
					Ext.apply(actionConfig, this.getCurrentCardInfo(actionConfig));
				}
				if (this.updateAddCardModuleEntityInfo) {
					this.updateAddCardModuleEntityInfo(actionConfig, activeRow);
				}
				if (lookupInfo.valuePairs) {
					actionConfig.valuePairs = lookupInfo.valuePairs;
				}
				const lookupPageId = this.sandbox.id + "_" + lookupInfo.columnName + "_CardModule";
				this.sandbox.subscribe("getCardInfo", function() {
					const cardInfo = {
						valuePairs: actionConfig.valuePairs || []
					};
					if (actionConfig.typeColumnName) {
						cardInfo.typeColumnName = actionConfig.typeColumnName;
						cardInfo.typeUId = actionConfig.typeUId;
					}
					return cardInfo;
				}, this, [lookupPageId]);
				const params = this.sandbox.publish("GetHistoryState");
				this.sandbox.publish("PushHistoryState", {
					hash: params.hash.historyState,
					stateObj: {
						isSeparateMode: true,
						schemaName: actionConfig.cardSchemaName,
						operation: actionConfig.action,
						primaryColumnValue: activeRow,
						valuePairs: actionConfig.valuePairs,
						isInChain: true
					}
				});
				MaskHelper.ShowBodyMask();
				BPMSoft.LookupUtilities.HideModalBox();
				if (this.needOpenMiniPage(entitySchema.name)) {
					this.openMiniPageForQuickAdd({
						entitySchemaName: entitySchema.name,
						moduleId: lookupPageId,
						valuePairs: actionConfig.valuePairs
					});
				} else {
					const moduleStructure = moduleUtils.getModuleStructureByName(entitySchema.name);
					this.sandbox.loadModule(moduleStructure?.cardModule ?? "CardModuleV2", {
						renderTo: "centerPanel",
						id: lookupPageId,
						keepAlive: true
					});
				}
			} else {
				const lookupEditPageId = this.sandbox.id + "_NUIBaseLookupEditPage";
				const captionLookup = this.get("captionLookup").replace(
					resources.localizableStrings.CaptionLookupPage, "");
				this.sandbox.subscribe("CardModuleEntityInfo", function() {
					const entityInfo = {};
					entityInfo.action = actionConfig.action;
					entityInfo.entitySchemaName = entitySchema.name;
					entityInfo.activeRow = activeRow;
					entityInfo.lookupCaption = captionLookup;
					entityInfo.lookupInfo = lookupInfo;
					return entityInfo;
				}, [lookupEditPageId]);
				const lookupEditPageParams = this.sandbox.publish("GetHistoryState");
				this.sandbox.publish("PushHistoryState", {
					hash: lookupEditPageParams.hash.historyState
				});
				MaskHelper.ShowBodyMask();
				BPMSoft.LookupUtilities.HideModalBox();
				this.sandbox.loadModule("NUIBaseLookupEditPage", {
					renderTo: "centerPanel",
					id: lookupEditPageId,
					keepAlive: true
				});
			}
		},

		/**
		 * Checks has entity mini page on quick creation.
		 * @param {String} entitySchemaName Entity schema name.
		 * @return {Boolean}
		 */
		needOpenMiniPage: function(entitySchemaName) {
			const notUseSilentCreation = !BPMSoft.Features.getIsEnabled("UseSilentCreation");
			const entityStructure = moduleUtils.getEntityStructureByName(entitySchemaName);
			const editPages = entityStructure.pages;
			const hasAddMiniPage = editPages[0].hasAddMiniPage;
			return notUseSilentCreation && this.lookupInfo.isQuickAdd && !Ext.isEmpty(hasAddMiniPage);
		},

		/**
		 * Opens mini page.
		 * @param {Object} config Mini page configuration information.
		 */
		openMiniPageForQuickAdd: function(config) {
			const miniPageUtility = Ext.create(this.BPMSoft.MiniPageUtilities);
			miniPageUtility.openAddMiniPage(config);
		},

		/**
		 * Sends "OpenCard" message.
		 * @param {Object} openCardConfig Configuration object to be passed with "OpenCard" message.
		 */
		openCard: function(openCardConfig) {
			this.sandbox.publish("OpenCard", openCardConfig, [this.sandbox.id]);
		},

		/* jshint unused : false */
		processModeActionButtonClick: function(tag) {

			const activeItems = this.getSelectedRecords();
			if ((tag === "executeProcess") && !Ext.isEmpty(activeItems)) {
				ProcessModuleUtilities.executeProcess({
					sysProcessId: activeItems[0]
				});
			}
		},
		generateCardPath: function(cardConfig, action) {
			const url = [];
			if (cardConfig.cardModule) {
				url.push(cardConfig.cardModule);
			}
			if (cardConfig.cardSchema) {
				url.push(cardConfig.cardSchema, action);
			}
			if (action !== ConfigurationEnums.CardState.Add) {
				const activeRows = this.getSelectedRecords();
				const activeRow = activeRows[0];
				url.push(activeRow);
			}
			return url.join("/");
		},
		editModeActionButtonClick: function(tag) {
			let cardModule, cardSchema;
			const entitySchema = this.getCurrentSchema();
			const module = moduleUtils.getModuleStructureByName(entitySchema.name);
			if (module) {
				cardModule = module.cardModule;
				cardSchema = module.cardSchema;
			}
			const cardConfig = {
				cardModule: cardModule,
				cardSchema: cardSchema
			};
			if (this.getLookupInfo().cardCustomConfig) {
				Ext.apply(cardConfig, this.getLookupInfo().cardCustomConfig);
			}
			if (!cardConfig.cardSchema) {
				return;
			}
			const url = this.generateCardPath(cardConfig, tag);
			if (url) {
				this.sandbox.publish("PushHistoryState", {hash: url});
				BPMSoft.LookupUtilities.HideModalBox();
			}
		},
		actionButtonClick: function(tag) {
			this.getLookupInfo().searchValue = "";
			if (!tag) {
				tag = arguments[3];
			}
			if (this.isEditMode()) {
				this.editModeActionButtonClick(tag);
				return;
			}
			if (this.isProcessMode()) {
				this.processModeActionButtonClick(tag);
				return;
			}
			this.defaultModeActionButtonClick(tag);
		},
		onDeleted: function(records) {
			if (!records) {
				records = this.getSelectedRecords();
			}
			if (records && (records.length > 0)) {
				const gridData = this.getGridData();
				records.forEach(function(record) {
					gridData.removeByKey(record);
				});
				this.set("IsGridEmpty", gridData.isEmpty());
				this.clearSelection();
				const lookupInfo = this.getLookupInfo();
				if (lookupInfo.methods && lookupInfo.methods.onDeleted) {
					lookupInfo.methods.onDeleted.call(this);
				}
			}
		},
		dblClickGrid: function(id) {
			if (this.isEditMode()) {
				this.set("activeRow", id);
				this.actionButtonClick("edit");
				return;
			} else if (this.isProcessMode()) {
				this.actionButtonClick("executeProcess");
				return;
			}
			this.set("activeRow", id);
			this.setSelectedRecords([id]);
			this.selectButton();
		},
		clear: function() {
			this.getGridData().clear();
			this._restoreHierarchicalGridState();
			this.pageNumber = 0;
		},
		openGridSettingPage: function() {
			const sandboxId = this.sandbox.id;
			const gridSettingsId = "GridSettings_" + sandboxId;
			const entitySchemaName = this.getCurrentSchema().name;
			const viewModel = this;
			const renderTo = Ext.get("centerPanel");
			this.sandbox.subscribe("GetGridSettingsInfo", this.getGridSettingsInfo, this, [gridSettingsId]);
			const params = this.sandbox.publish("GetHistoryState");
			this.sandbox.publish("PushHistoryState", {hash: params.hash.historyState});
			MaskHelper.ShowBodyMask();
			this.sandbox.loadModule("GridSettingsV2", {
				renderTo: renderTo,
				id: gridSettingsId,
				keepAlive: true
			});
			this.sandbox.subscribe("GridSettingsChanged", function(args) {
				if (args && args.newProfileData) {
					viewModel.set("gridProfile", args.newProfileData);
				}
				viewModel.isObsolete = true;
				viewModel.close();
			}, this, [gridSettingsId]);
			viewModel.hide();
		},

		/**
		 * Return gridSettings info
		 * @protected
		 * @return {Object} {{entitySchemaName: String, baseGridType: String, profileKey: String,
		 * notFoundColumns: String[]}} Grid settings info.
		 */
		getGridSettingsInfo: function() {
			return {
				entitySchemaName: this.getCurrentSchema().name,
				baseGridType: ConfigurationEnums.GridType.LISTED,
				profileKey: this.getProfileKey(),
				notFoundColumns: this.notFoundColumns
			};
		},

		/**
		 * Initialize "hasActions" value into view model.
		 */
		initHasActions: function() {
			const lookupInfo = this.getLookupInfo();
			const actionsButtonVisible = lookupInfo.actionsButtonVisible;
			if (!this.Ext.isBoolean(actionsButtonVisible) || actionsButtonVisible) {
				const schemaName = this.entitySchema.name;
				RightUtilities.getSchemaOperationRightLevel(schemaName, function(rightLevel) {
					this.initCanDelete(rightLevel);
					this.initCanAdd(rightLevel);
					this.initCanEdit(rightLevel, schemaName);
					this.set("hasActions", this.get("canEdit") || this.get("canDelete") ||
						this.get("canAdd"));
					if (lookupInfo.hideActions) {
						this.set("hasActions", false);
					}
				}, this);
			} else {
				this.set("hasActions", false);
			}
		},
		/**
		 * Initialize "canDelete" value into view model.
		 * @protected
		 * @param {Number} rightLevel Access level.
		 */
		initCanDelete: function(rightLevel) {
			if (RightUtilities.canDeleteSchemaData(rightLevel)) {
				this.set("canDelete", true);
			} else {
				this.set("canDelete", false);
			}
		},
		/**
		 * Initialize "canAdd" value into view model.
		 * @protected
		 * @param {Number} rightLevel Access level.
		 */
		initCanAdd: function(rightLevel) {
			if (RightUtilities.canAppendSchemaData(rightLevel)) {
				this.set("canAdd", true);
			} else {
				this.set("canAdd", false);
			}
		},
		/**
		 * Initialize "canEdit" value into view model.
		 * @protected
		 * @param {Number} rightLevel Access level.
		 * @param {String} schemaName Schema name.
		 */
		initCanEdit: function(rightLevel, schemaName) {
			const entityStructure = moduleUtils.getEntityStructureByName(schemaName);
			const hasEditPage = this.Ext.isEmpty(entityStructure);
			if (!RightUtilities.canEditSchemaData(rightLevel) || hasEditPage) {
				this.set("canEdit", false);
			} else {
				this.set("canEdit", true);
			}
		},
		isValidColumnDataValueType: function(column) {
			return (column.dataValueType === BPMSoft.DataValueType.TEXT ||
				column.dataValueType === BPMSoft.DataValueType.LOOKUP);
		},
		getSchemaColumns: function() {
			const entitySchema = this.getCurrentSchema();
			const schemaColumns = this.get("schemaColumns");
			schemaColumns.clear();
			const columns = Ext.create("BPMSoft.Collection");
			let allowedColumnsId = [];
			let shouldAddColumns = true;
			if (this.BPMSoft.isCurrentUserSsp()) {
				var sspGridMixin = Ext.create(this.BPMSoft.SSPGridMixin);
				allowedColumnsId = sspGridMixin.getAllowedColumns(entitySchema.name).map(i => i.uId) || [];
				if (allowedColumnsId.length === 0) {
					shouldAddColumns = false;
				}
			}
			if (!this.get("primaryColumnFilterEnabled") && shouldAddColumns) {
				BPMSoft.each(entitySchema.columns, function(entitySchemaColumn) {
					if (allowedColumnsId.length > 0 && !allowedColumnsId.includes(entitySchemaColumn.uId)) {
						return;
					}
					if (this.isValidColumnDataValueType(entitySchemaColumn) &&
						entitySchemaColumn.name !== entitySchema.primaryDisplayColumnName &&
						entitySchemaColumn.usageType !== ConfigurationEnums.EntitySchemaColumnUsageType.None) {
						let columnPath = entitySchemaColumn.name;
						if (entitySchemaColumn.isLookup) {
							columnPath += "." + entitySchemaColumn.referenceSchema.primaryDisplayColumnName;
						}
						const column = {
							value: columnPath,
							displayValue: entitySchemaColumn.caption
						};
						columns.add(column.name, column);
					}
				}, this);
				columns.sort(0, BPMSoft.OrderDirection.ASC, function(a, b) {
					if (a.displayValue < b.displayValue) {
						return -1;
					} else if (a.displayValue > b.displayValue) {
						return 1;
					} else {
						return 0;
					}
				});
			}
			columns.add(entitySchema.primaryDisplayColumn.name, {
				value: entitySchema.primaryDisplayColumn.name,
				displayValue: entitySchema.primaryDisplayColumn.caption
			}, 0);
			schemaColumns.loadAll(columns);
		},

		/**
		 * Prepares and sets caption text for modal window.
		 * @protected
		 */
		initCaptionLookup: function() {
			const lookupSchema = this.getCurrentSchema();
			this.set("lookupSchemaName", lookupSchema.name);
			const lookupInfo = this.getLookupInfo();
			if (!Ext.isEmpty(lookupInfo.captionLookup)) {
				this.set("captionLookup", lookupInfo.captionLookup);
				return;
			}
			const select = this.createLookupEsq(lookupSchema.uId);
			select.getEntityCollection(function(response) {
				let prefix = "";
				if (!lookupInfo.mode) {
					prefix = resources.localizableStrings.CaptionLookupPage;
				}
				if (response.collection.getCount() > 0) {
					const lookupName = response.collection.getByIndex(0).get("displayValue");
					this.set("captionLookup", prefix + lookupName);
				} else {
					this.set("captionLookup", prefix + lookupSchema.caption);
				}
			}, this);
		},

		emptyGridRowHistory: function() {
			const grid = this._getGridInstance();
			if (grid.watchRowHistory) {
				grid.watchRowHistory = [];
			}
		},
		getProfileKey: function() {
			const lookupInfo = this.getLookupInfo();
			const postfix = lookupInfo.lookupPostfix;
			let profileKey = "GridSettings_" + this.entitySchema.name;
			if (!this.Ext.isEmpty(postfix)) {
				profileKey += postfix;
			}
			return profileKey;
		},
		getDefaultProfile: function() {
			const primaryDisplayColumn = this.entitySchema.primaryDisplayColumn;
			const lookupInfo = this.getLookupInfo();
			let tiledColumnsConfig = null;
			let listedColumnsConfig = null;
			let captionsConfig = null;
			if (lookupInfo && !this.Ext.isEmpty(lookupInfo.sortedColumns)) {
				tiledColumnsConfig = [[{
					cols: 24,
					key: [{
						caption: primaryDisplayColumn.caption,
						name: {bindTo: primaryDisplayColumn.name},
						type: BPMSoft.GridKeyType.TITLE
					}],
					metaPath: primaryDisplayColumn.name,
					orderPosition: 0
				}]];
				listedColumnsConfig = [{
					cols: 24,
					key: [{
						name: {bindTo: primaryDisplayColumn.name}
					}],
					metaPath: primaryDisplayColumn.name,
					orderPosition: 0
				}];
				captionsConfig = [{
					cols: 24,
					columnName: primaryDisplayColumn.name,
					name: primaryDisplayColumn.caption
				}];
			} else {
				tiledColumnsConfig = [[{
					cols: 24,
					key: [{
						caption: primaryDisplayColumn.caption,
						name: {bindTo: primaryDisplayColumn.name},
						type: BPMSoft.GridKeyType.TITLE
					}],
					metaPath: primaryDisplayColumn.name,
					orderDirection: BPMSoft.OrderDirection.ASC,
					orderPosition: 0
				}]];
				listedColumnsConfig = [{
					cols: 24,
					key: [{
						name: {bindTo: primaryDisplayColumn.name}
					}],
					metaPath: primaryDisplayColumn.name,
					orderDirection: BPMSoft.OrderDirection.ASC,
					orderPosition: 0
				}];
				captionsConfig = [{
					cols: 24,
					columnName: primaryDisplayColumn.name,
					name: primaryDisplayColumn.caption,
					sortColumnDirection: BPMSoft.core.enums.OrderDirection.ASC
				}];
			}
			const key = this.getProfileKey();
			return {
				key: key,
				isTiled: false,
				listedColumnsConfig: Ext.encode(listedColumnsConfig),
				tiledColumnsConfig: Ext.encode(tiledColumnsConfig),
				captionsConfig: Ext.encode(captionsConfig)
			};
		}

		//endregion
	};

	/**
	 * Returns lookup view model values.
	 * @private
	 * @param {Object} lookupInfo The configuration parameters of the object lookup.
	 * @returns {Object} Lookup view model values.
	 */
	function _getViewModelValues(lookupInfo) {
		const activeRow = Ext.isEmpty(lookupInfo.selectedRows) ? null : lookupInfo.selectedRows[0];
		const values = {
			searchData: "",
			searchColumn: lookupInfo.searchColumn,
			previousSearchColumn: lookupInfo.searchColumn,
			schemaColumns: new BPMSoft.Collection(),
			gridProfile: lookupInfo.gridProfile,
			selectedRowsCount: 0,
			filteredRowsCount: 0,
			Caption: "",
			captionLookup: "",
			canEdit: true,
			canAdd: true,
			canDelete: true,
			hasActions: true,
			expandedElements: {},
			expandHierarchyLevels: null,
			gridData: new BPMSoft.Collection(),
			LookupInfo: lookupInfo,
			lookupMode: lookupInfo.mode,
			multiSelect: lookupInfo.multiSelect,
			usingMultiAddMixin: lookupInfo.usingMultiAddMixin,
			selectedRows: lookupInfo.selectedRows || null,
			activeRow: activeRow,
			isColumnSettingsHidden: lookupInfo.isColumnSettingsHidden,
			primaryColumnFilterEnabled: lookupInfo.primaryColumnFilterEnabled,
			useRecordDeactivation: lookupInfo.useRecordDeactivation
		};
		return values;
	}

	function generateViewModel(lookupInfo) {
		const values = _getViewModelValues(lookupInfo);
		const config = {
			name: "LookupPageModule",
			entitySchema: lookupInfo.entitySchema,
			columns: {},
			primaryColumnName: "",
			primaryDisplayColumnName: "",
			values: values,
			methods: methods,
			mixins: {
				QueryCancellationMixin: "BPMSoft.QueryCancellationMixin",
				GridUtilities: "BPMSoft.GridUtilities",
				GridProfileColumns: "BPMSoft.GridProfileColumnsMixin"
			}
		};
		return config;
	}

	return {
		generate: generateViewModel
	};
});
