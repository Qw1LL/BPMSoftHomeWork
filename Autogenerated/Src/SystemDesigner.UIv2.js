define("SystemDesigner", ["SystemDesignerResources", "RightUtilities", "PackageHelper",
	"ConfigurationConstants", "ConfigurationEnums", "ServiceHelper", "ProcessModuleUtilities", "ChangeLogUtilities",
	"WizardUtilities", "SystemOperationsPermissionsMixin"
], function(resources, RightUtilities, PackageHelper, ConfigurationConstants, ConfigurationEnums, ServiceHelper,
		ProcessUtilities, ChangeLogUtilities) {
	return {
		mixins: {
			WizardUtilities: "BPMSoft.WizardUtilities",
			SystemOperationsPermissionsMixin: "BPMSoft.SystemOperationsPermissionsMixin"
		},
		attributes: {
			"CanManageProcessDesign": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN
			},

			"CanViewSysOperationAudit": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN
			},

			"CanImportFromExcel": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN
			},

			"WindowHeight": {
				dataValueType: BPMSoft.DataValueType.INTEGER,
				value: 300
			},

			"WindowWidth": {
				dataValueType: BPMSoft.DataValueType.INTEGER,
				value: 600
			},

			"IsSectionDesignerAvailable": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN
			},

			"CanAccessConfigurationSettings": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN
			},

			"CanManageWorkplaces": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN
			},

			"CanManageLogo": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN
			},

			"CanManageSectionPanelColorSettings": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN
			},

			/**
			 * Parameter contains information about the availability of the partition directories to the current user.
			 */
			"CanManageChangeLog": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN
			},

			/**
			 * Parameter contains information about the availability change log management for the current user.
			 */
			"CanManageAdministration": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN
			},

			"CanManageReports": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN
			},

			"CanManageMobileApplication": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN
			},

			"CanManageUsers": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN
			},

			/**
			 * A sign to access the system configuration.
			 */
			"CanManageSolution": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN
			},

			/**
			 * The parameter containing the information about the availability of the partition directories to the current user.
			 */
			"CanManageLookup": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN
			},

			/**
			 * Selected package name.
			 */
			"SelectedPackage": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: ""
			},

			/**
			 * Flag install extension visible.
			 */
			"IsInstallExtensionsVisible": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: true
			},

			/**
			 * Flag that indicates usage feature "InstalledApp"
			 */
			"UseFeatureInstalledApp": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: true
			},

			/**
			 * @override
			 */
			"IsMobilePannerVisible": {
				value: false
			},

			/**
			 * @override
			 */
			"IsSdkPanelVisible": {
				value: true
			},

			/**
			 * @override
			 */
			"IsSocialAccountsPanelVisible": {
				value: false
			}

		},
		methods: {

			//region Methods: Private

			/**
			 * Returns features page visible flag.
			 * @private
			 * @return {Boolean}
			 */
			getIsFeaturesPageVisible: function() {
				return BPMSoft.isDebug && BPMSoft.SysValue.CURRENT_MAINTAINER.value === "BPMSoft";
			},

			/**
			 * Opens features page.
			 * @private
			 */
			openFeaturesPage: function() {
				const featuresPageUrl = BPMSoft.workspaceBaseUrl + "/Nui/ViewModule.aspx#Features";
				window.open(featuresPageUrl);
				return false;
			},

			/**
			 * Opens package market page.
			 * @private
			 */
			openPackageMarket: function() {
				const packageMarketUrl = BPMSoft.workspaceBaseUrl + "/NUI/ViewModule.aspx?vm=PackageMarketModule";
				window.open(packageMarketUrl);
				return false;
			},

			/**
			 * Returns package market visible flag.
			 * @private
			 * @return {Boolean} Package market visible flag.
			 */
			getPackageMarketVisible: function() {
				return this.getIsFeatureEnabled("PackageMarket");
			},

			/**
			 * @private
			 */
			getNewReportSetupVisible: function() {
				return !this.getIsFeatureEnabled("DisableNewReportUI");
			},

			/**
			 * Returns change log visible flag.
			 * @private
			 * @return {Boolean} Change log visible flag.
			 */
			getChangeLogVisible: function() {
				return this.getIsFeatureEnabled("NewChangeLogUI");
			},

			/**
			 * Returns a flag indicating whether link to the new license manager should be visible.
			 * @private
			 * @return {Boolean}
			 */
			_getLicenseManagerVisible: function() {
				return this.getIsFeatureEnabled("NewLicenseManagerUI");
			},

			/**
			 * Initialize section designer rights.
			 * @private
			 */
			onStartSectionDesignerClick: function() {
				if (this.get("IsSectionDesignerAvailable") == null) {
					this.getIsSectionDesignerAvailable(function() {
						this.startSectionDesigner();
					}, this);
				} else {
					this.startSectionDesigner();
				}
				return false;
			},

			/**
			 * Initialize advanced settings rights.
			 * @private
			 */
			onNavigateToConfigurationSettingsClick: function() {
				if (this.get("CanAccessConfigurationSettings") == null) {
					ServiceHelper.callService("MainMenuService", "GetCanAccessConfigurationSettings", function(response) {
						if (response) {
							const result = response.GetCanAccessConfigurationSettingsResult;
							const value = result && Ext.isBoolean(result);
							this.set("CanAccessConfigurationSettings", Boolean(value));
							this.navigateToConfigurationSettings();
						}
					}, {}, this);
				} else {
					this.navigateToConfigurationSettings();
				}
				return false;
			},

			/**
			 * Checks the rights to change operation settings.
			 * @private
			 * @param {Object} options Check parameters right.
			 * @param {String} options.operationName Operation code whose rights we want to check.
			 * @param {Function} options.callback The callback function after getting the value right.
			 */
			checkRights: function(options) {
				const operation = options.operationName;
				const callback = options.callback;
				const currentRights = this.get(operation);
				if (currentRights != null) {
					callback.call(this, currentRights);
				}
				RightUtilities.checkCanExecuteOperation({operation: operation}, function(result) {
					this.set(operation, result);
					callback.call(this, result);
				}, this);
			},

			/**
			 * ######### ###### #########.
			 * @private
			 */
			navigateToSectionPanelSettingsSection: function() {
				this.sandbox.requireModuleDescriptors(["SysSectionPanelSettingsModule"], function() {
					this.sandbox.publish("PushHistoryState", {hash: "SysSectionPanelSettingsModule"});
				}, this);
			},

			/**
			 * ######### ###### "########## ########" ### ########## ######### # ######.
			 * @private
			 */
			navigateToProcessLibSection: function() {
				this.openSection("VwProcessLibSection");
			},

			/**
			 * ######### ###### "###### ########" ### ########## ######### # ######.
			 * @private
			 */
			navigateToProcessLogSection: function() {
				this.openSection("SysProcessLogSectionV2");
			},

			/**
			 * Opens process designer.
			 * @private
			 */
			navigateToProcessDesigner: function() {
				ProcessUtilities.showProcessSchemaDesigner();
			},

			/**
			 * Opens page wizard.
			 * @private
			 */
			navigateToPageWizard: function() {
				ProcessUtilities.showPageTemplateLookup();
			},

			/**
			 * ######### ###### "###### ######" ### ########## ######### # ######.
			 * @private
			 */
			navigateToSysOperationAuditSection: function() {
				this.openSection("SysOperationAuditSectionV2");
			},

			/**
			 * ######### #### ####### ###### ## Excel.
			 * @private
			 */
			navigateToImportFromExcel: function() {
				const url = BPMSoft.workspaceBaseUrl + ConfigurationConstants.ApplicationPage.ExcelImport;
				const windowFeatures = "height=" + this.get("WindowHeight") + ",width=" + this.get("WindowWidth");
				window.open(url, "_blank", windowFeatures);
			},

			/**
			 * ######### ######## ########## ##########.
			 * @private
			 */
			navigateToMobileAppDesignerSection: function() {
				BPMSoft.PackageManager.getCurrentPackageUId(function(currentPackageUId) {
					BPMSoft.DomainCache.setItem("SectionDesigner_CurrentPackageUId", currentPackageUId);
					this.showBodyMask();
					const newHash = BPMSoft.combinePath("SectionModuleV2", "SysMobileWorkplaceSection");
					this.sandbox.publish("PushHistoryState", {hash: newHash});
				}.bind(this));
			},

			/**
			 * Check available and open section designer.
			 * @private
			 */
			startSectionDesigner: function() {
				if (this.getCanDesignWizard()) {
					this.openSectionWindow("New");
				} else {
					this.showPermissionsErrorMessage("CanManageSolution");
				}
			},

			/**
			 * ######### ###### ####### ### ########## ######### # ######.
			 * @private
			 */
			startDetailWizard: function() {
				this.mixins.WizardUtilities.openDetailWindow("New");
			},

			/**
			 * ######### ####### ###### Platform # ####### #### ### ####### # ####.
			 * @private
			 * @param {Function} callback ####### ######### ######.
			 * @param {Object} scope ########.
			 */
			getIsSectionDesignerAvailable: function(callback, scope) {
				PackageHelper.getIsPackageInstalled(ConfigurationConstants.PackageUId.Platform, function(isPackageInstalled) {
					if (isPackageInstalled) {
						require(["SectionDesignerUtils"], function(module) {
							module.getCanUseSectionDesigner(function(result) {
								this.set("IsSectionDesignerAvailable", result.canUseSectionDesigner);
								callback.call(scope);
							}.bind(this));
						}.bind(this));
					} else {
						this.set("IsSectionDesignerAvailable", false);
						callback.call(scope);
					}
				}, this);
			},

			/**
			 * ######### ########## ############# ### ########## ######### # ######.
			 * @private
			 */
			navigateToConfigurationSettings: function() {
				if (this.get("CanAccessConfigurationSettings") === true) {
					var url = BPMSoft.workspaceBaseUrl + "/ClientApp/#/WorkspaceExplorer";
					window.open(url, "_blank");
				} else {
					this.showPermissionsErrorMessage("CanManageSolution");
				}
			},

			/**
			 * ######### ###### ######### ####### #### ### ########## ######### # ######.
			 * @private
			 */
			navigateToSysWorkPlaceSection: function() {
				this.showBodyMask();
				this.openSection("SysWorkplaceSectionV2");
			},

			/**
			 * ######### ###### ######### ############# ######### ### ########## ######### ## ######.
			 * @private
			 */
			navigateToSysLogoSettings: function() {
				this.sandbox.publish("PushHistoryState", {
					hash: "SysLogoSettingsModule"
				});
			},

			/**
			 * @private
			 */
			navigateToReportSetup: function() {
				const url = BPMSoft.workspaceBaseUrl + "/ClientApp/#/Printables";
				window.open(url, "_blank");
			},

			/**
			 * ######### #### ################# #### ########.
			 * @private
			 */
			navigateToObjectRightsManagement: function() {
				let url = BPMSoft.workspaceBaseUrl;
				url += this.getIsFeatureEnabled("NewRightsManagementUI")
					? "/ClientApp/"
					: ConfigurationConstants.ApplicationPage.ObjectRightsManagement;
				window.open(url, "_blank");
			},

			/**
			 * Open change log management window.
			 * @private
			 */
			navigateToChangeLogManagement: function() {
				if (this.getIsFeatureEnabled("NewChangeLogUI")) {
					ChangeLogUtilities.openChangeLogSettings();
				}
			},

			/**
			 * Open license manager window.
			 * @private
			 */
			_navigateToLicenseManager: function() {
				const url = BPMSoft.combinePath(BPMSoft.workspaceBaseUrl, "ClientApp/#/LicenseManager");
				window.open(url, "_blank");
			},

			/**
			 * ######### ############# ############### #### # ####### ################# #############.
			 * @private
			 */
			navigateToOrgRoles: function() {
				this.goToSysAdminUnitSection("SysAdminUnitPageV2");
			},

			/**
			 * ######### ############# ############## #### # ####### ################# #############.
			 * @private
			 */
			navigateToFuncRoles: function() {
				this.goToSysAdminUnitSection("SysAdminUnitFuncRolePageV2");
			},

			/**
			 * ######### ####### # ###### SysAdminUnitSection.
			 * @private
			 * @param {String} pageName ######## ######## ##############, ####### ##### ####### ### ######## # ######.
			 */
			goToSysAdminUnitSection: function(pageName) {
				const primaryId = ConfigurationConstants.SysAdminUnit.Id.AllEmployees;
				this.sandbox.publish("PushHistoryState", {
					hash: BPMSoft.combinePath("SectionModuleV2", "SysAdminUnitSectionV2",
						pageName, ConfigurationEnums.CardState.Edit, primaryId),
					stateObj: {
						module: "SectionModuleV2",
						operation: ConfigurationEnums.CardState.Edit,
						primaryColumnValue: primaryId,
						schemas: [
							this.name,
							pageName
						],
						workAreaMode: ConfigurationEnums.WorkAreaMode.COMBINED,
						moduleId: this.sandbox.id,
						skipCardHistoryStateActualization: true
					}
				});
			},

			/**
			 * ######### ############# ############ # ####### ################# #############.
			 * @private
			 */
			navigateToUsers: function() {
				this.openSection("UsersSectionV2");
			},

			/**
			 * ######### ###### ########### ####### ########.
			 * @private
			 */
			navigateToSysAdminOperationSection: function() {
				this.openSection("SysAdminOperationSectionV2");
			},

			//endregion

			//region Methods: Protected

			/**
			 * @inheritdoc BaseSchemaViewModel#init
			 * @override
			 */
			init: function(callback, scope) {
				var headerConfig = {
					isMainMenu: false,
					isCaptionVisible: true,
					isContextHelpVisible: true,
					isLogoVisible: true,
					caption: resources.localizableStrings.SystemDesignerCaption,
				};
				this.sandbox.publish("InitDataViews", headerConfig);
				
				this.callParent([function() {
					this.initUserOperationsRights(function() {
						this.setPackageZipFileStorageFeatureParameter();
						this.setDefaultParameters();
						this.set("ProductEdition", "BPMS");
						Ext.callback(callback, scope);
					}, this);
				}, this]);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#onRender
			 * @override
			 */
			onRender: function() {
				this.callParent(arguments);
				this.hideBodyMask();
			},

			/**
			 * @inheritdoc BPMSoft.configuration.mixins.WizardUtilities#getCanDesignWizard
			 * @override
			 */
			getCanDesignWizard: function() {
				return this.get("IsSectionDesignerAvailable");
			},

			/**
			 * ########## ###### ######## ######## # ######## ####.
			 * @protected
			 * @return {Object} ###### ########.
			 */
			getOperationRightsDecoupling: function() {
				let navigateToSysSettingsOperationName = "CanManageSysSettings";
				if (BPMSoft.Features.getIsEnabled("UseCanManageAdministrationForSysSettings") === true) {
					navigateToSysSettingsOperationName = "CanManageAdministration";
				}
				return {
					"navigateToProcessLibSection": "CanManageProcessDesign",
					"navigateToProcessLogSection": "CanManageProcessLogSection",
					"navigateToProcessDesigner": "CanManageProcessDesign",
					"navigateToPageWizard": "CanManageProcessDesign",
					"navigateToOrgRoles": "CanManageUsers",
					"navigateToFuncRoles": "CanManageUsers",
					"navigateToUsers": "CanManageUsers",
					"navigateToSysOperationAuditSection": "CanViewSysOperationAudit",
					"navigateToImportFromExcel": "CanImportFromExcel",
					"navigateToSysWorkPlaceSection": "CanManageWorkplaceSettings",
					"navigateToSysLogoSettings": "CanManageLogo",
					"startDetailWizard": "CanManageSolution",
					"navigateToObjectRightsManagement": "CanManageAdministration",
					"navigateToReportSetup": "CanManageReports",
					"navigateToSysAdminOperationSection": "CanManageAdministration",
					"navigateToMobileAppDesignerSection": "CanManageMobileApplication",
					"navigateToSectionPanelSettingsSection": "CanManageSectionPanelColorSettings",
					"navigateToSysSettings": navigateToSysSettingsOperationName,
					"navigateToLookupSection": "CanManageLookups",
					"navigateToInstalledApp": "CanManageSolution",
					"navigateToChangeLogManagement": "CanManageChangeLog",
					"_navigateToLicenseManager": "CanManageLicUsers",
				};
			},

			/**
			 * ############## ###### ########## ############ ## ### ############ ########.
			 * @protected
			 * @param {Function} callback ####### ######### ######.
			 * @param {Object} scope ###### ######### ####### ######### ######.
			 */
			initUserOperationsRights: function(callback, scope) {
				const getOperationRightsDecoupling = this.getOperationRightsDecoupling();
				const operationRightsNames = Ext.Object.getValues(getOperationRightsDecoupling);
				const uniqueOperationNames = [];
				BPMSoft.each(operationRightsNames, function(operationName) {
					if (uniqueOperationNames.indexOf(operationName) < 0) {
						uniqueOperationNames.push(operationName);
					}
				}, this);
				if (uniqueOperationNames.indexOf("CanViewConfiguration") < 0) {
					uniqueOperationNames.push("CanViewConfiguration");
				}
				if (uniqueOperationNames.indexOf("CanSelectEverything") < 0) {
					uniqueOperationNames.push("CanSelectEverything");
				}
				RightUtilities.checkCanExecuteOperations(uniqueOperationNames, function(result) {
					BPMSoft.each(result, function(operationRight, operationName) {
						this.set(operationName, operationRight);
					}, this);
					Ext.callback(callback, scope);
				}, this);
			},

			/**
			 * ######### ########## ######## # ######### #### ## ###. #### #### ###, ####### #########.
			 * @protected
			 * @return {boolean} ########## false ### ########### ######### ####### ####### ## ######.
			 */
			invokeOperation: function() {
				const operationName = arguments[1] || arguments[0];
				const operationRightsDecoupling = this.getOperationRightsDecoupling();
				const rightsName = operationRightsDecoupling[operationName];
				if (!Ext.isEmpty(rightsName) && !this.get(rightsName) && !this.get("CanViewConfiguration")) {
					this.showPermissionsErrorMessage(rightsName);
				} else {
					const operation = this[operationName];
					if (!Ext.isEmpty(operation) && Ext.isFunction(operation)) {
						operation.call(this);
					}
				}
				return false;
			},

			/**
			 * Opens section using section schema name.
			 * @protected
			 * @param {String} sectionSchemaName Section schema name.
			 */
			openSection: function(sectionSchemaName) {
				this.sandbox.publish("PushHistoryState", {
					hash: "SectionModuleV2/" + sectionSchemaName
				});
			},

			/**
			 * ######### ####### # ###### ############.
			 * @protected
			 */
			navigateToSysSettings: function() {
				this.openSection("SysSettingsSection");
			},

			/**
			 * ######### ####### # ###### ############.
			 * @protected
			 */
			navigateToLookupSection: function() {
				const lookupModuleStructure = BPMSoft.configuration.ModuleStructure.Lookup;
				if (lookupModuleStructure) {
					const newHash = BPMSoft.combinePath(lookupModuleStructure.sectionModule,
						lookupModuleStructure.sectionSchema);
					this.sandbox.publish("PushHistoryState", {hash: newHash});
				}
			},

			/**
			 * Sets value of the parameters.
			 * @protected
			 */
			setDefaultParameters: BPMSoft.emptyFn,

			/**
			 * Opens installed application page.
			 * @protected
			 */
			navigateToInstalledApp: function() {
				this.openSection("InstalledAppSection");
			},

			//endregion

			//region Methods: deprecated

			/**
			 * @deprecated
			 */
			defineExistentConfigurationPackage: BPMSoft.emptyFn,

			/**
			 * @deprecated
			 */
			initInstallPackages: BPMSoft.emptyFn,

			/**
			 * @deprecated
			 */
			getInstallPackages: function() {
				return [];
			},

			/**
			 * @deprecated
			 */
			getInstallPackagesConfig: function() {
				return {};
			},

			/**
			 * @deprecated
			 */
			setExistentConfigurationPackage: BPMSoft.emptyFn,

			/**
			 * @deprecated
			 */
			setPackageZipFileStorageFeatureParameter: BPMSoft.emptyFn,

			/**
			 * @deprecated
			 */
			loadExistentConfigurationPackage: function(installPackages, callback, scope) {
				callback.call(scope);
			},

			/**
			 * @deprecated
			 */
			updatePropertyExistentPackages: BPMSoft.emptyFn,

			/**
			 * @deprecated
			 */
			createExistentConfigurationPackageSelect: BPMSoft.emptyFn,

			/**
			 * @deprecated
			 */
			setExistentConfigurationPackageFilters: BPMSoft.emptyFn,

			/**
			 * @deprecated
			 */
			initParametersEvent: BPMSoft.emptyFn,

			/**
			 * @deprecated
			 */
			initLinkCaption: BPMSoft.emptyFn,

			/**
			 * @deprecated
			 */
			onInstallPackageClick: BPMSoft.emptyFn,

			/**
			 * @deprecated
			 */
			setSelectedPackage: BPMSoft.emptyFn,

			/**
			 * @deprecated
			 */
			onConfirm: BPMSoft.emptyFn,

			/**
			 * @deprecated
			 */
			installPackage: BPMSoft.emptyFn,

			/**
			 * @deprecated
			 */
			getSelectedPackage: BPMSoft.emptyFn,

			/**
			 * @deprecated
			 */
			responseInstallFromStorageHandler: BPMSoft.emptyFn,

			/**
			 * @deprecated
			 */
			responseServiceHandler: BPMSoft.emptyFn,

			/**
			 * @deprecated
			 */
			getSysSettingPackageUrlName: BPMSoft.emptyFn,

			/**
			 * @deprecated
			 */
			onFilesSelected: BPMSoft.emptyFn

			//endregion
		},
		diff: [
			{
				"operation": "merge",
				"name": "MainContainer",
				"values": {
					"markerValue": "system-designer-page"
				}
			},
			{
				"operation": "insert",
				"name": "ProcessTile",
				"propertyName": "items",
				"parentName": "LeftContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"generator": "MainMenuTileGenerator.generateMainMenuTile",
					"caption": {"bindTo": "Resources.Strings.ProcessCaption"},
					"cls": ["process", "designer-tile"],
					"icon": resources.localizableImages.ProcessIcon,
					"items": []
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "ProcessTile",
				"name": "ProcessDesigner",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.ProcessDesignerLinkCaption"},
					"tag": "navigateToProcessDesigner",
					"click": {"bindTo": "invokeOperation"},
					"visible": BPMSoft.isDebug || BPMSoft.Features.getIsEnabled("GoToProcessDesigner")
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "ProcessTile",
				"name": "PageWizard",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.PageWizardLinkCaption"},
					"tag": "navigateToPageWizard",
					"click": {"bindTo": "invokeOperation"},
					"visible": BPMSoft.isDebug || BPMSoft.Features.getIsEnabled("GoToProcessDesigner")
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "ProcessTile",
				"name": "ProcessLibrary",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.ProcessLibraryLinkCaption"},
					"tag": "navigateToProcessLibSection",
					"click": {"bindTo": "invokeOperation"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "ProcessTile",
				"name": "ProcessLog",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.ProcessLogLinkCaption"},
					"tag": "navigateToProcessLogSection",
					"click": {"bindTo": "invokeOperation"}
				}
			},
			{
				"operation": "insert",
				"name": "UsersTile",
				"propertyName": "items",
				"parentName": "LeftContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"generator": "MainMenuTileGenerator.generateMainMenuTile",
					"caption": {"bindTo": "Resources.Strings.UsersCaption"},
					"cls": ["sales-tile", "designer-tile"],
					"icon": resources.localizableImages.UsersIcon,
					"items": []
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "UsersTile",
				"name": "Users",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.UsersLinkCaption"},
					"tag": "navigateToUsers",
					"click": {"bindTo": "invokeOperation"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "UsersTile",
				"name": "OrgRoles",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.OrgRolesLinkCaption"},
					"tag": "navigateToOrgRoles",
					"click": {"bindTo": "invokeOperation"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "UsersTile",
				"name": "FuncRoles",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.FuncRolesLinkCaption"},
					"tag": "navigateToFuncRoles",
					"click": {"bindTo": "invokeOperation"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "UsersTile",
				"name": "ObjectRightsManagement",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.ObjectRightsManagementLinkCaption"},
					"tag": "navigateToObjectRightsManagement",
					"click": {"bindTo": "invokeOperation"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "UsersTile",
				"name": "OperationRightsManagement",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.OperationRightsManagementLinkCaption"},
					"tag": "navigateToSysAdminOperationSection",
					"click": {"bindTo": "invokeOperation"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "UsersTile",
				"name": "AuditLog",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.AuditLogLinkCaption"},
					"tag": "navigateToSysOperationAuditSection",
					"click": {"bindTo": "invokeOperation"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "UsersTile",
				"name": "ChangeLog",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.ChangeLogLinkCaption"},
					"tag": "navigateToChangeLogManagement",
					"click": {"bindTo": "invokeOperation"},
					"visible": {"bindTo": "getChangeLogVisible"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "UsersTile",
				"name": "LicenseManager",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.LicenseManagerLinkCaption"},
					"tag": "_navigateToLicenseManager",
					"click": {"bindTo": "invokeOperation"},
					"visible": {"bindTo": "_getLicenseManagerVisible"}
				}
			},
			{
				"operation": "insert",
				"name": "IntegrationTile",
				"propertyName": "items",
				"parentName": "LeftContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"generator": "MainMenuTileGenerator.generateMainMenuTile",
					"caption": {"bindTo": "Resources.Strings.IntegrationCaption"},
					"cls": ["settings", "designer-tile"],
					"icon": resources.localizableImages.IntegrationIcon,
					"items": []
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "IntegrationTile",
				"name": "ExcelImport",
				"index": 0,
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.ExcelImportLinkCaption"},
					"tag": "navigateToImportFromExcel",
					"click": {"bindTo": "invokeOperation"}
				}
			},
			{
				"operation": "insert",
				"name": "InstallExtensionsTile",
				"propertyName": "items",
				"parentName": "LeftContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"generator": "MainMenuTileGenerator.generateMainMenuTile",
					"caption": {"bindTo": "Resources.Strings.ApplicationsCaption"},
					"cls": ["extensions", "designer-tile"],
					"icon": resources.localizableImages.InstallExtensionsIcon,
					"visible": {"bindTo": "IsInstallExtensionsVisible"},
					"items": []
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "InstallExtensionsTile",
				"name": "InstalledAppLink",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.InstalledAppCaption"},
					"visible": {"bindTo": "UseFeatureInstalledApp"},
					"tag": "navigateToInstalledApp",
					"click": {"bindTo": "invokeOperation"}
				}
			},
			{
				"operation": "insert",
				"name": "SystemSettingsTile",
				"propertyName": "items",
				"parentName": "LeftContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"generator": "MainMenuTileGenerator.generateMainMenuTile",
					"caption": {"bindTo": "Resources.Strings.SystemSettingsCaption"},
					"cls": ["analytics", "designer-tile"],
					"icon": resources.localizableImages.SystemSettingsIcon,
					"items": []
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "SystemSettingsTile",
				"name": "Features",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.FeaturesPage"},
					"click": {"bindTo": "openFeaturesPage"},
					"visible": {"bindTo": "getIsFeaturesPageVisible"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "SystemSettingsTile",
				"name": "PackageMarket",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.PackageMarketCaption"},
					"click": {"bindTo": "openPackageMarket"},
					"visible": {"bindTo": "getPackageMarketVisible"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "SystemSettingsTile",
				"name": "LookupSection",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.LookupsLinkCaption"},
					"tag": "navigateToLookupSection",
					"click": {"bindTo": "invokeOperation"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "SystemSettingsTile",
				"name": "SysSettingsSection",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.SysSettingsLinkCaption"},
					"tag": "navigateToSysSettings",
					"click": {"bindTo": "invokeOperation"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "SystemSettingsTile",
				"name": "ReportSetup",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.ReportSetupLinkCaption"},
					"tag": "navigateToReportSetup",
					"click": {"bindTo": "invokeOperation"},
					"visible": {"bindTo": "getNewReportSetupVisible"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "SystemSettingsTile",
				"name": "SectionDesigner",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.SectionDesignerLinkCaption"},
					"click": {"bindTo": "onStartSectionDesignerClick"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "SystemSettingsTile",
				"name": "DetailWizard",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.DetailWizardLinkCaption"},
					"tag": "startDetailWizard",
					"click": {"bindTo": "invokeOperation"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "SystemSettingsTile",
				"name": "MobileAppDesignerLink",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.MobileAppDesignerLinkCaption"},
					"tag": "navigateToMobileAppDesignerSection",
					"click": {"bindTo": "invokeOperation"}
				}
			},
			{
				"operation": "insert",
				"name": "SystemViewTile",
				"propertyName": "items",
				"parentName": "LeftContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"generator": "MainMenuTileGenerator.generateMainMenuTile",
					"caption": {"bindTo": "Resources.Strings.SystemViewCaption"},
					"cls": ["basis", "designer-tile"],
					"icon": resources.localizableImages.SystemViewIcon,
					"items": []
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "SystemViewTile",
				"name": "SysWorkplace",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.SysWorkplaceLinkCaption"},
					"tag": "navigateToSysWorkPlaceSection",
					"click": {"bindTo": "invokeOperation"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "SystemViewTile",
				"name": "SysLogoManagement",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.SysLogoManagementLinkCaption"},
					"tag": "navigateToSysLogoSettings",
					"click": {"bindTo": "invokeOperation"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "SystemViewTile",
				"name": "SysColorManagement",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.SysColorManagementLinkCaption"},
					"tag": "navigateToSectionPanelSettingsSection",
					"click": {"bindTo": "invokeOperation"}
				}
			},
			{
				"operation": "insert",
				"name": "ConfigurationTile",
				"propertyName": "items",
				"parentName": "LeftContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"generator": "MainMenuTileGenerator.generateMainMenuTile",
					"caption": {"bindTo": "Resources.Strings.ConfigurationCaption"},
					"cls": ["configuration", "designer-tile"],
					"icon": resources.localizableImages.ConfigurationIcon,
					"items": []
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "ConfigurationTile",
				"name": "ConfigurationLink",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.ConfigurationLinkCaption"},
					"click": {"bindTo": "onNavigateToConfigurationSettingsClick"}
				}
			},
			{
				"operation": "merge",
				"name": "AcademyPanel",
				"propertyName": "items",
				"parentName": "RightContainer",
				"values": {
					"bannerImage": resources.localizableImages.BPMSbanner,
					"wrapClassName": "bpms-banner"
				}
			},
			{
				"operation": "merge",
				"name": "BPMSoftAccountsLinksPanel",
				"values": {
					"wrapClassName": "system-designer"
				}
			}
		]
	};
});
