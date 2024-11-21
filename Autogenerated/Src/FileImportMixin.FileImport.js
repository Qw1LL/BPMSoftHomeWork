define("FileImportMixin", [
	"FileImportMixinResources", "RightUtilities", "GoogleTagManagerUtilities", "SystemOperationsPermissionsMixin"
], function(res, RightUtilities) {
	/**
	 * FileImport mixin class.
	 * Provides methods for opening file import wizard from everywhere.
	 * @class BPMSoft.FileImportMixin
	 */
	Ext.define("BPMSoft.FileImportMixin", {
		alternateClassName: "BPMSoft.configuration.mixins.FileImportMixin",
		mixins: {
			SystemOperationsPermissionsMixin: "BPMSoft.SystemOperationsPermissionsMixin"
		},

		// region Fields: Private

		/**
		 * @private
		 */
		_resources: res,

		/**
		 * @private
		 */
		_waitOpenWindowTimeout: 1000,

		/**
		 * @private
		 */
		_excludedSysEntities: [
			"SysAdminUnit", "SysAdminUnitInRole", "SysUserInRole", "SysTranslation"
		],

		// endregion

		// region Methods: Private

		/**
		 * @private
		 */
		_initMixinResources: function() {
			BPMSoft.each(this._resources.localizableStrings, function(item, key) {
				this.set("Resources.Strings." + key, item);
			}, this);
		},

		/**
		 * @private
		 */
		_initCanImportFromExcel: function() {
			RightUtilities.checkCanExecuteOperation({
				operation: "CanImportFromExcel"
			}, this._onCanImportFromExcelComplete, this);
		},

		/**
		 * @private
		 */
		_onCanImportFromExcelComplete: function(result) {
			this.set("CanImportFromExcel", result);
		},

		/**
		 * @private
		 */
		_getImportWizardUrl: function(schemaName) {
			const importSessionId = this.getUniqueImportSessionId();
			return BPMSoft.combinePath(BPMSoft.workspaceBaseUrl, "Nui",
					"ViewModule.aspx?vm=FileImportWizard#FileImportModule/FileImportStartPage",
					importSessionId, schemaName);
		},

		/**
		 * @private
		 */
		_getResources: function() {
			return this._resources;
		},

		/**
		 * @private
		 */
		_getSysEntityFilters: function() {
			const comparisonTypeNotStartWith = BPMSoft.ComparisonType.NOT_START_WITH;
			const sysFilters = BPMSoft.createFilterGroup();
			sysFilters.name = "sysFilters";
			sysFilters.logicalOperation = BPMSoft.LogicalOperatorType.OR;
			sysFilters.add("NotSysFilter", BPMSoft.createColumnFilterWithParameter(
					comparisonTypeNotStartWith, "Name", "Sys", BPMSoft.DataValueType.TEXT
			));
			const notInFilter = BPMSoft.createColumnInFilterWithParameters("Name", this._excludedSysEntities);
			notInFilter.comparisonType = BPMSoft.ComparisonType.EQUAL;
			sysFilters.add("SysFilter", notInFilter);
			return sysFilters;
		},

		// endregion

		// region Methods: Protected

		/**
		 * Forms import session identifier.
		 * @protected
		 * @return {String} Unique identifier of the import session.
		 */
		getUniqueImportSessionId: function() {
			return BPMSoft.generateGUID();
		},

		/**
		 * Applies entity Name column filters for entities select.
		 * @protected
		 * @param {BPMSoft.FilterGroup} filters Filters for apply naming conditions.
		 */
		applyEntityNameFilters: function(filters) {
			const comparisonTypeNotStartWith = BPMSoft.ComparisonType.NOT_START_WITH;
			const comparisonTypeNotEndWith = BPMSoft.ComparisonType.NOT_END_WITH;
			const textValueType = BPMSoft.DataValueType.TEXT;
			filters.add("NameVwFilter", BPMSoft.createColumnFilterWithParameter(
					comparisonTypeNotStartWith, "Name", "Vw", textValueType
			));
			filters.add("NameBaseFilter", BPMSoft.createColumnFilterWithParameter(
					comparisonTypeNotStartWith, "Name", "Base", textValueType
			));
			filters.add("NameLczFilter", BPMSoft.createColumnFilterWithParameter(
					comparisonTypeNotEndWith, "Name", "Lcz", textValueType
			));
			filters.add("NameSettingsFilter", BPMSoft.createColumnFilterWithParameter(
					comparisonTypeNotEndWith, "Name", "Settings", textValueType
			));
			filters.add("NameLookupFilter", BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.NOT_EQUAL, "Name", "Lookup", textValueType
			));
		},

		/**
		 * Returns mixins localizable images.
		 * @protected
		 * @virtual
		 * @return {Object} Localizable images object.
		 */
		getLocalizableImages: function() {
			const resources = this._getResources();
			return resources && resources.localizableImages;
		},

		/**
		 * Opens url in a new window. If it is blocked, shows message about it.
		 * @protected
		 * @param {String} url Url to open.
		 */
		navigateToUrl: function(url) {
			const popup = window.open(url, "_blank");
			setTimeout(function() {
				if (!popup || popup.outerHeight === 0) {
					BPMSoft.showInformation(this.get("Resources.Strings.DataImportPopupBlockedMessage"));
				}
			}, this._waitOpenWindowTimeout);
		},

		/**
		 * Initializes data import availability for current schema entity.
		 * @protected
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback execution context.
		 */
		initDataImportAvailability: function(callback, scope) {
			if (Ext.isEmpty(this.entitySchemaName)) {
				this.$IsImportAvailable = false;
				Ext.callback(callback, scope || this);
				return;
			}
			const esq = this.getEntitySchemaEsq();
			const filters = BPMSoft.createFilterGroup();
			filters.name = "vwFilters";
			filters.logicalOperation = BPMSoft.LogicalOperatorType.AND;
			filters.add("CurrentSchemaFilter",
					esq.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "Name", this.entitySchemaName));
			esq.filters.add("SchemaFilter", filters);
			esq.getEntityCollection(function(response) {
				if (response && response.success) {
					this.$IsImportAvailable = response.collection.getCount() === 1;
				} else {
					this.$IsImportAvailable = false;
				}
				Ext.callback(callback, scope || this);
			}, this);
		},

		/**
		 * Forms query for getting entities which are allowed for data import.
		 * @protected
		 * @return {BPMSoft.EntitySchemaQuery} Select query for entities.
		 */
		getEntitySchemaEsq: function() {
			const esq = Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: "VwSysSchemaInWorkspace",
				rowCount: 1,
				clientESQCacheParameters: {
					cacheItemName: this.getFileImportCacheItemName()
				},
				serverESQCacheParameters: {
					cacheLevel: BPMSoft.ESQServerCacheLevels.SESSION,
					cacheGroup: "FileImportAvailability",
					cacheItemName: this.getFileImportCacheItemName()
				}
			});
			esq.addColumn("UId");
			esq.filters.add("excludedFilters", this.getEntitySchemaFilters());
			return esq;
		},

		// endregion

		// region Methods: Public

		/**
		 * Sends Google tag manager data.
		 */
		sendGoogleTagManagerImportData: function() {
			const isGoogleTagManagerEnabled = this.get("IsGoogleTagManagerEnabled");
			if (!isGoogleTagManagerEnabled) {
				return;
			}
			const data = Ext.isFunction(this.getGoogleTagManagerData) ? this.getGoogleTagManagerData() : {};
			Ext.apply(data, {
				schemaName: this.entitySchemaName,
				moduleName: this.getFileImportCacheItemName()
			});
			BPMSoft.GoogleTagManagerUtilities.actionModule(data);
		},

		/**
		 * Get file import cache name for current entity schema.
		 * @return {String} Cache name for current entity schema.
		 */
		getFileImportCacheItemName: function() {
			return Ext.String.format("FileImport_{0}", this.entitySchemaName);
		},

		/**
		 * Initializes mixin state.
		 * Initializes resources and Import rights.
		 */
		init: function() {
			this.set("IsImportAvailable", false);
			this._initMixinResources();
			this.initDataImportAvailability(function() {
				this._initCanImportFromExcel();
			}, this);
		},

		/**
		 * Opens file import wizard for current entity schema.
		 */
		openFileImportWizard: function() {
			if (this.$CanImportFromExcel) {
				const url = this._getImportWizardUrl(this.entitySchemaName);
				this.sendGoogleTagManagerImportData();
				this.navigateToUrl(url);
			} else {
				this.showPermissionsErrorMessage("CanImportFromExcel");
			}
		},

		/**
		 * Checks menu item visibility.
		 * @return {Boolean} Import menu item visibility sign.
		 */
		getDataImportMenuItemVisible: function() {
			if (!this.$IsImportDisabled) {
				return this.$IsImportAvailable && !this.$MultiSelect && !this.$SelectAllMode;
			} else {
				return false;
			}
		},

		/**
		 * Returns config of the data import menu item for sections and details.
		 * @return {Object} Config of the menu item.
		 */
		getFileImportMenuItemCfg: function() {
			if (this.$IsImportDisabled) {
				return null;
			}
			const localizableImages = this.getLocalizableImages();
			return {
				"Caption": {"bindTo": "Resources.Strings.ImportFromFileButtonCaption"},
				"Click": {"bindTo": "openFileImportWizard"},
				"ImageConfig": localizableImages.ImportFromFileButtonImage,
				"Visible": {"bindTo": "getDataImportMenuItemVisible"}
			};
		},

		/**
		 * Creates data import menu item for section actions.
		 * @virtual
		 * @return {Object} Data import menu item.
		 */
		getDataImportMenuItem: function() {
			const config = this.getFileImportMenuItemCfg();
			return Ext.isEmpty(config) ? null : this.getButtonMenuItem(config);
		},

		/**
		 * Gets import object query filters.
		 * @return {BPMSoft.data.filters.FilterGroup} Filters for entities select.
		 */
		getEntitySchemaFilters: function() {
			const filters = BPMSoft.createFilterGroup();
			filters.name = "vwFilters";
			filters.logicalOperation = BPMSoft.LogicalOperatorType.AND;
			const sysFilters = this._getSysEntityFilters();
			filters.add("NameSysFilter", sysFilters);
			filters.add("SysWorkspaceNameFilter", BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "SysWorkspace.Id", BPMSoft.SysValue.CURRENT_WORKSPACE.value,
					BPMSoft.DataValueType.TEXT
			));
			filters.add("ManagerNameFilter", BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "ManagerName", "EntitySchemaManager", BPMSoft.DataValueType.TEXT
			));
			filters.add("ExtendParentFilter", BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "ExtendParent", false, BPMSoft.DataValueType.BOOLEAN
			));
			this.applyEntityNameFilters(filters);
			return filters;
		}

		// endregion

	});
});
