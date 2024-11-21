define("SectionWizard", ["ext-base", "BPMSoft", "SectionWizardResources", "SectionDesignerEnums",
	"ApplicationStructureItemWizard", "SectionManager", "SysModuleEntityManager",
	"SysModuleEditManager", "DetailManager", "WizardUtilities", "PackageUtilities", "DesignTimeEnums",
	"SectionInWorkplaceManager", "DcmWizardStep", "ProcessEntryPointUtilities", "SysModuleVisaManager",
	"SspPageDetailsManager", "PortalSchemaAccessListManager", "PortalColumnAccessListManager", "GoogleTagManagerMixin"
], function(Ext, BPMSoft, resources, SectionDesignerEnums) {

	/**
	 * Class of visual module of representation for the section wizard
	 */
	Ext.define("BPMSoft.configuration.SectionWizard", {
		extend: "BPMSoft.configuration.ApplicationStructureItemWizard",
		alternateClassName: "BPMSoft.SectionWizard",
		mixins: {
			/**
			 * @class GoogleTagManagerMixin Provides methods for SSP users minipage usage.
			 */
			GoogleTagManagerMixin: "BPMSoft.GoogleTagManagerMixin"
		},

		//region Properties: Protected

		/**
		 * @inheritdoc BPMSoft.ApplicationStructureItemWizard#applicationStructureManager
		 * @override
		 */
		applicationStructureManager: BPMSoft.SectionManager,

		/**
		 * History state hash property value that indicates ssp section creation request.
		 * @protected
		 * @type {String}
		 */
		sspCreationRequestProperty: "AddSsp",

		/**
		 * Is ssp section creation requested flag.
		 * @protected
		 * @type {Boolean}
		 */
		sspCreationRequested: false,

		/**
		 * Application structure item SSP Id.
		 * @protected
		 * @type {Guid}
		 */
		sspSectionId: null,

		/**
		 * Section types enum.
		 * @protected
		 * @type {Object}
		 */
		sectionTypes: null,

		/**
		 * Application structure manager item for ssp view.
		 * @protected
		 * @type {Object}
		 */
		sspSectionItem: null,

		//endregion

		//region Methods: Private

		/**
		 * @private
		 */
		_generateIndexationConfigs: function(callback) {
			const dataManagerItem = this.applicationStructureItem.getDataManagerItem();
			const previousGlobalSearchAvailable = dataManagerItem.getPreviousColumnValue("GlobalSearchAvailable");
			const currentGlobalSearchAvailable = this.applicationStructureItem.getGlobalSearchAvailable();
			const previousSchemaUId = dataManagerItem.getPreviousColumnValue("SectionSchemaUId");
			const currentSchemaUId = this.applicationStructureItem.getSchemaUId();
			const isExistingSectionChanged = previousSchemaUId === currentSchemaUId;
			if (isExistingSectionChanged && currentGlobalSearchAvailable === previousGlobalSearchAvailable) {
				callback();
				return;
			}
			BPMSoft.ConfigurationServiceProvider.callService({
				serviceName: "IndexingConfigService",
				methodName: "SendIndexationConfigs"
			}, callback, this);
		},

		/**
		 * @private
		 */
		_updateCommandLine: function(callback) {
			const config = {
				serviceName: "CommandLineService",
				methodName: "CreateParamCommands"
			};
			BPMSoft.ConfigurationServiceProvider.callService(config, callback, this);
		},

		/**
		 * Initialize DetailManager.
		 * @private
		 * @param {Function} callback Callback function.
		 */
		initDetailManager: function(callback) {
			BPMSoft.DetailManager.initialize(null, callback, this);
		},

		/**
		 * Initialize SspPageDetailsManager.
		 * @private
		 * @param {Function} callback Callback function.
		 */
		_initSspPageDetailManager: function(callback) {
			BPMSoft.SspPageDetailsManager.initialize(null, callback, this);
		},

		/**
		 * Initialize PortalSchemaAccessListManager.
		 * @private
		 * @param {Function} callback Callback function.
		 */
		_initPortalSchemaAccessListManager: function(callback) {
			BPMSoft.PortalSchemaAccessListManager.initialize(null, callback, this);
		},

		/**
		 * Initialize PortalColumnAccessListManager.
		 * @private
		 * @param {Function} callback Callback function.
		 */
		_initPortalColumnAccessListManager: function(callback) {
			BPMSoft.PortalColumnAccessListManager.initialize(null, callback, this);
		},

		/**
		 * Initialize SectionInWorkplaceManager.
		 * @private
		 * @param {Function} callback Callback function.
		 */
		initSectionInWorkplaceManager: function(callback) {
			BPMSoft.SectionInWorkplaceManager.initialize(null, callback, this);
		},

		/**
		 * Returns flag that indicates when to show cases step.
		 * @private
		 * @return {Boolean}
		 */
		_getCanUseDcm: function() {
			const structureItem = this.applicationStructureItem;
			return structureItem ? structureItem.code !== "Activity" : true;
		},

		/**
		 * Returns config for BusinessProcesses step.
		 * @private
		 * @return {Object} config.
		 */
		getBusinessProcessesStepConfig: function() {
			return {
				name: "BusinessProcesses",
				caption: this.getLocalizableString("BusinessProcessesCaption"),
				imageConfig: null,
				moduleName: "ConfigurationModuleV2",
				schemaName: "SectionProcessSettings"
			};
		},

		/**
		 * Processing response with section types.
		 * @private
		 * @param {String} result Section enum serialization string.
		 *
		 */
		_processSectionTypes: function(result) {
			if (result.GetSectionTypesResult) {
				this.sectionTypes = JSON.parse(result.GetSectionTypesResult);
			}
		},

		/**
		 * Get application structure item identifier by type.
		 * @private
		 * @param {Array} sections Array application structure items info.
		 * @param {Integer} type application structure item type.
		 * @param {Guid} stepItemId application structure item identitfier.
		 * @return {Guid} application structure item identifier.
		 */
		_getSectionIdByType: function(sections, type, stepItemId) {
			let section = sections.find(function(section) {
				return section.Id === stepItemId && section.Type === type;
			});
			if (!this.Ext.isEmpty(section)) {
				return section.Id;
			}
			let sectionId = null;
			sections.forEach(function(section) {
				if (section.Type === type) {
					sectionId = section.Id;
				}
			});
			return sectionId;
		},

		/**
		 * Updates sspSectionId identifier.
		 * @private
		 * @param {Guid} sectionId Section identifier.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Scope Execution context.
		 * @param {Array} callbackArgs The arguments to pass to the callback function.
		 */
		_updateSspSectionId: function(sectionId, callback, scope, callbackArgs) {
			this.sspSectionId = sectionId;
			Ext.callback(callback, scope, callbackArgs);
		},

		/**
		 * Get application structure items info.
		 * @param {Object} config An object that contains the service name, method name, data.
		 * @param {function} callback Callback.
		 * @param {Object} scope Scope.
		 * @private
		 */
		_getGeneralAndSspSections: function(config, callback, scope) {
			BPMSoft.ConfigurationServiceProvider.callService(config, function(result) {
				const items = [];
				if (result.GetGeneralAndSspSectionsResult) {
					result.GetGeneralAndSspSectionsResult.forEach(function(sectionJson) {
						items.push(JSON.parse(sectionJson));
					}, this);
				}
				Ext.callback(callback, scope, [items]);
			}, this);
		},

		/**
		 * Adds ssp section wizard step.
		 * @private
		 * @param {Array} steps Wizard steps array.
		 */
		_addSspMainSettingsStep: function(steps) {
			const sspItemId = this.sspSectionId;
			if ((sspItemId && BPMSoft.isGUID(sspItemId)) || this.sspCreationRequested) {
				steps.push({
					name: "SspMainSettings",
					caption: this.getLocalizableString("SspMainSettingsStepCaption"),
					imageConfig: null,
					moduleName: "ConfigurationModuleV2",
					schemaName: "BaseSectionMainSettings"
				});
			}
		},

		/**
		 * Gets GTM data for ssp step action.
		 * @private
		 * @return {Object} GTM data for ssp step action.
		 */
		_getGTMSspStepData: function() {
			const data = this.getDefaultGTMData();
			return Ext.apply(data, {
				action: "OpenSspStep"
			});
		},

		/**
		 * Gets GTM data for new ssp section action.
		 * @private
		 * @return {Object} GTM data for new ssp section action.
		 */
		_getGTMNewSspSectionData: function() {
			const data = this.getDefaultGTMData();
			return Ext.apply(data, {
				action: "NewSspSection"
			});
		},

		//endregion

		//region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.ApplicationStructureItemWizard#getEntitySchemasToCheck
		 * @override
		 */
		getEntitySchemasToCheck: function() {
			const errorTypes = SectionDesignerEnums.WizardValidationErrorType;
			return this.callParent(arguments)
				.then(function(schemas) {
					return new Promise(function(resolve, reject) {
						schemas.push(
							BPMSoft.DesignTimeEnums.BaseSchemaUId.BASE_LOOKUP,
							BPMSoft.DesignTimeEnums.BaseSchemaUId.BASE_VISA
						);
						if (this.applicationStructureItem.getIsNew()) {
							schemas.push(
								BPMSoft.DesignTimeEnums.BaseSchemaUId.BASE_ENTITY,
								BPMSoft.DesignTimeEnums.BaseSchemaUId.BASE_FILE,
								BPMSoft.DesignTimeEnums.BaseSchemaUId.BASE_FOLDER,
								BPMSoft.DesignTimeEnums.BaseSchemaUId.BASE_ITEM_IN_FOLDER,
								BPMSoft.DesignTimeEnums.BaseSchemaUId.BASE_TAG,
								BPMSoft.DesignTimeEnums.BaseSchemaUId.BASE_ITEM_IN_TAG
							);
							resolve(schemas);
						} else {
							this.getSysModuleEntityManagerItem(function(entityManagerItem) {
								if (!entityManagerItem) {
									const error = {type: errorTypes.SYS_MODULE_ENTITY_MISSING};
									reject(error);
								}
								const utils = BPMSoft.ApplicationStructureWizardUtils;
								const uid = entityManagerItem.getEntitySchemaUId();
								BPMSoft.EntitySchemaManager.findItemByUId(uid, function(item) {
									if (item && item.name) {
										const name = item.name;
										utils.getSectionEntitySchemaAdditionalSchemaUIds(name, function(schemaUIds) {
											schemas = schemas.concat(schemaUIds);
											resolve(schemas);
										}, this);
									} else {
										resolve(schemas);
									}
								}, this);
							}, this);
						}
					}.bind(this));
				}.bind(this));
		},

		/**
		 * @inheritdoc BPMSoft.ApplicationStructureItemWizard#onNavigateToAllowedStep
		 * @override
		 */
		onNavigateToAllowedStep: function() {
			if (this.applicationStructureItem.getIsNew()) {
				this.callParent(arguments);
				return;
			}
			if (!BPMSoft.contains(this.getErrorFreeSteps(), this.currentStep)) {
				const hash = "Cases/" + this.applicationStructureItem.getId();
				this.sandbox.publish("PushHistoryState", {hash: hash});
			}
		},

		/**
		 * @inheritdoc BPMSoft.ApplicationStructureItemWizard#getErrorFreeSteps
		 * @override
		 */
		getErrorFreeSteps: function() {
			const errorFreeSteps = this.callParent();
			errorFreeSteps.push("Cases", "BusinessProcesses");
			return errorFreeSteps;
		},

		/**
		 * @inheritdoc BPMSoft.ApplicationStructureItemWizard#getClientUnitSchemasToCheck
		 * @override
		 */
		getClientUnitSchemasToCheck: function() {
			const errorTypes = SectionDesignerEnums.WizardValidationErrorType;
			return this.callParent(arguments)
				.then(function(schemas) {
					return new Promise(function(resolve, reject) {
						if (this.applicationStructureItem.getIsNew()) {
							schemas.push(
								BPMSoft.DesignTimeEnums.BaseSchemaUId.BASE_DATA_VIEW,
								BPMSoft.DesignTimeEnums.BaseSchemaUId.BASE_SECTION,
								BPMSoft.DesignTimeEnums.BaseSchemaUId.BASE_PAGE,
								BPMSoft.DesignTimeEnums.BaseSchemaUId.BASE_MODULE_PAGE
							);
							resolve(schemas);
						} else {
							this.getSysModuleEntityManagerItem(function(entityManagerItem) {
								if (!entityManagerItem) {
									const error = {type: errorTypes.SYS_MODULE_ENTITY_MISSING};
									reject(error);
								}
								entityManagerItem.getSysModuleEditManagerItems(function(items) {
									if (!items || items.isEmpty()) {
										const error = {type: errorTypes.SYS_MODULE_EDIT_MISSING};
										reject(error);
									}
									const sectionSchemaUId = this.applicationStructureItem.getSchemaUId();
									if (sectionSchemaUId) {
										schemas.push(sectionSchemaUId);
									}
									resolve(schemas);
								}, this);
							}, this);
						}
					}.bind(this));
				}.bind(this));
		},

		/**
		 * @inheritdoc BPMSoft.ApplicationStructureItemWizard#getInitChain
		 * @override
		 */
		getInitChain: function() {
			const chain = this.callParent(arguments);
			chain.push(this.initSectionTypes);
			chain.push(this._initSspPageDetailManager);
			chain.push(this._initPortalSchemaAccessListManager);
			chain.push(this._initPortalColumnAccessListManager);
			chain.push(this.initDetailManager);
			chain.push(this.initSectionInWorkplaceManager);
			return chain;
		},

		/**
		 * Initialization section types.
		 * @protected
		 * @param {Function} callback The function will be called at the end.
		 */
		initSectionTypes: function(callback) {
			const config = {
				serviceName: "SectionService",
				methodName: "GetSectionTypes"
			};
			BPMSoft.ConfigurationServiceProvider.callService(config, function(result) {
				this._processSectionTypes(result);
				Ext.callback(callback, this);
			}, this);
		},

		/**
		 * @inheritdoc BPMSoft.ApplicationStructureItemWizard#subscribeMessages
		 * @override
		 */
		subscribeMessages: function() {
			this.callParent(arguments);
			const sandbox = this.sandbox;
			const mainPageHeaderId = this.getModuleIdByStepName("MainSettings");
			sandbox.subscribe("UpdateWizardConfig", this.onUpdateWizardConfig, this, [mainPageHeaderId]);
		},

		/**
		 * @inheritdoc BPMSoft.BaseWizardModule#getLocalizableString
		 * @override
		 */
		getLocalizableString: function(key) {
			return resources.localizableStrings[key] || this.callParent(arguments);
		},

		/**
		 * @inheritdoc BPMSoft.ApplicationStructureItemWizard#getSteps
		 * @override
		 */
		getSteps: function() {
			const parentSteps = this.callParent(arguments);
			let steps = [
				{
					name: "MainSettings",
					caption: this.getLocalizableString("MainSettingsStepCaption"),
					imageConfig: null,
					moduleName: "ConfigurationModuleV2",
					schemaName: "SectionMainSettings"
				}
			];
			this._addSspMainSettingsStep(steps);
			if (this._getCanUseDcm()) {
				steps.push({
					name: "Cases",
					caption: this.getLocalizableString("CasesStepCaption"),
					imageConfig: null,
					moduleName: "ConfigurationModuleV2",
					schemaName: "SectionWizardCasesSettings",
					config: {
						viewModelClassName: "BPMSoft.DcmWizardStep"
					}
				});
			}
			if (BPMSoft.ProcessEntryPointUtilities.getCanRunProcessFromSection()) {
				steps.push(this.getBusinessProcessesStepConfig());
			}
			steps = steps.concat(parentSteps);
			return steps.concat(this.pagesSteps);
		},

		/**
		 * @inheritdoc BPMSoft.ApplicationStructureItemWizard#getNewApplicationStructureItemWizardCaption
		 * @override
		 */
		getNewApplicationStructureItemWizardCaption: function() {
			return this.getLocalizableString("NewSectionWizardCaption");
		},

		/**
		 * @inheritdoc BPMSoft.ApplicationStructureItemWizard#generateStepCaption
		 * @override
		 */
		generateStepCaption: function() {
			let caption = "";
			const currentStep = this.operationType || this.currentStep;
			const currentStepConfig = this.getStepConfigByName(currentStep);
			if (this.Ext.isEmpty(currentStepConfig)) {
				return "";
			}
			switch (currentStep) {
				case "MainSettings":
					caption = this.getMainSettingsStepCaption();
					break;
				case "SspMainSettings":
					caption = this.getSspMainSettingsStepCaption();
					break;
				case "Cases":
					caption = this.getLocalizableString("CasesStepCaption");
					break;
				case "PageDesigner":
					caption = this.getPageDesignerStepCaption(currentStepConfig);
					break;
				case "MiniPageDesigner":
					caption = this.getLocalizableString("MiniPageDesignerStepCaption");
					break;
				case "BusinessRules":
					caption = this.getLocalizableString("BusinessRulesStepCaption");
					break;
				case "BusinessProcesses":
					caption = this.getLocalizableString("BusinessProcessesCaption");
					break;
				default:
					if (currentStepConfig.groupName === "PageDesigner") {
						caption = this.getPageDesignerStepCaption(currentStepConfig);
					}
					break;
			}
			return caption;
		},

		/**
		 * Get MainSettings step caption
		 * @protected
		 * @return {String} step caption
		 */
		getMainSettingsStepCaption: function() {
			return this.getLocalizableString("MainSettingsStepCaption");
		},

		/**
		 * Get SspMainSettings step caption
		 * @protected
		 * @return {String} step caption
		 */
		getSspMainSettingsStepCaption: function() {
			return this.getLocalizableString("SspMainSettingsStepCaption");
		},

		/**
		 * @inheritdoc BPMSoft.ApplicationStructureItemWizard#onGetModuleConfig
		 * @override
		 */
		onGetModuleConfig: function() {
			switch (this.currentStep) {
				case "MainSettings":
					this.prepareMainSettingsConfig(this.publishModuleConfig, this);
					break;
				case "SspMainSettings":
					this.prepareSspMainSettingsConfig(this.publishModuleConfig, this);
					this.sendGoogleTagManagerData(this._getGTMSspStepData());
					break;
				case "PageDesigner":
				case "MiniPageDesigner":
					this.preparePageDesignerConfig(this.publishModuleConfig, this);
					break;
				case "Cases":
					this.prepareCaseSettingsConfig(this.publishModuleConfig, this);
					break;
				case "BusinessRules":
					this.prepareBusinessRuleSectionConfig(this.publishModuleConfig, this);
					break;
				case "BusinessProcesses":
					this.prepareBusinessProcessSettingsConfig(this.publishModuleConfig, this);
					break;
				default:
					break;
			}
			const currentStep = this.getStepConfigByName(this.currentStep);
			if (currentStep.groupName === "PageDesigner") {
				this.preparePageDesignerConfig(this.publishModuleConfig, this);
			}
		},

		/**
		 * Prepare main settings configuration
		 * @protected
		 * @param {Function} callback The function will be called at the end
		 * @param {Object} scope The context in which the callback function is called
		 */
		prepareMainSettingsConfig: function(callback, scope) {
			const result = {
				"packageUId": this.packageUId,
				"applicationStructureItem": this.applicationStructureItem,
				"sectionTypes": this.sectionTypes
			};
			callback.call(scope, result);
		},

		/**
		 * Prepare ssp main settings configuration
		 * @protected
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		prepareSspMainSettingsConfig: function(callback, scope) {
			const result = {
				"packageUId": this.packageUId,
				"applicationStructureItem": this.sspSectionItem,
				"sectionTypes": this.sectionTypes
			};
			callback.call(scope, result);
		},

		/**
		 * Sets new SSP item properties.
		 * @protected
		 * @param {BPMSoft.SectionManagerItem} sspItem New SSP section manager item.
		 */
		setNewSspItemProperties: function(sspItem) {
			sspItem.setPropertyValue("type", this.sectionTypes.SSP);
			const mainItem = this.applicationStructureItem;
			if (Ext.isEmpty(sspItem.getCode())) {
				sspItem.setCode(mainItem.getCode());
			}
			if (Ext.isEmpty(sspItem.getCaption())) {
				const captionTemplate = this.getLocalizableString("NewSspSectionCaptionTemplate");
				const caption = Ext.String.format(captionTemplate, mainItem.getCaption());
				sspItem.setCaption(caption);
			}
		},

		/**
		 * Returns ssp structure item from application structure manger.
		 * Will create new item if item not found and ssp view creation requested.
		 * @protected
		 * @param {Guid} sspItemId Manager item identifier.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		getSspStructureItem: function(sspItemId, callback, scope) {
			if (!sspItemId) {
				Ext.callback(callback, scope);
				return;
			}
			this.getStructureItem(sspItemId, function(applicationStructureItem) {
				if (applicationStructureItem.getIsNew()) {
					this.setNewSspItemProperties(applicationStructureItem);
					this.sendGoogleTagManagerData(this._getGTMNewSspSectionData());
				}
				Ext.callback(callback, scope, [applicationStructureItem]);
			}, this);
		},

		/**
		 * Sets ssp section item.
		 * @override
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		setApplicationStructureItem: function(callback, scope) {
			this.callParent([function() {
				this.setSspSectionItem(callback, scope);
			}, this]);
		},

		/**
		 * Set ssp view application structure item.
		 * @protected
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		setSspSectionItem: function(callback, scope) {
			if (!this.sspSectionId) {
				Ext.callback(callback, scope);
				return;
			}
			BPMSoft.chain(
				function(next) {
					this.getSspStructureItem(this.sspSectionId, next, this);
				}, function(next, applicationStructureItem) {
					this.sspSectionItem = applicationStructureItem;
					Ext.callback(callback, scope);
				}, this
			);
		},

		/**
		 * Prepare case settings configuration.
		 * @protected
		 * @param {Function} callback The function will be called at the end.
		 * @param {Object} callback.result Case settings configuration.
		 * @param {Object} scope The context in which the callback function is called.
		 */
		prepareCaseSettingsConfig: function(callback, scope) {
			const result = {
				"packageUId": this.packageUId,
				"applicationStructureItem": this.applicationStructureItem,
				"sspSectionItem": this.sspSectionItem
			};
			callback.call(scope, result);
		},

		/**
		 * Prepare process settings configuration.
		 * @protected
		 * @param {Function} callback The function will be called at the end.
		 * @param {Object} callback.result Case settings configuration.
		 * @param {Object} scope The context in which the callback function is called.
		 */
		prepareBusinessProcessSettingsConfig: function(callback, scope) {
			const result = {
				"packageUId": this.packageUId,
				"applicationStructureItem": this.applicationStructureItem
			};
			callback.call(scope, result);
		},

		/**
		 * @inheritdoc BPMSoft.ApplicationStructureItemWizard#getDefaultStepName
		 * @override
		 */
		getDefaultStepName: function() {
			return "MainSettings";
		},

		/**
		 * @inheritdoc BPMSoft.ApplicationStructureItemWizard#getRegistrationDataSteps
		 * @override
		 */
		getRegistrationDataSteps: function() {
			const steps = this.callParent(arguments);
			steps.push({
					manager: BPMSoft.SspPageDetailsManager,
					processMessage: this.getLocalizableString("DetailRegistrationMessage"),
					updateSchemaDataAction: true
				},
				{
					manager: BPMSoft.PortalSchemaAccessListManager,
					updateSchemaDataAction: true
				},
				{
					manager: BPMSoft.PortalColumnAccessListManager,
					updateSchemaDataAction: true
				},
				{
					manager: BPMSoft.SysModuleVisaManager,
					processMessage: this.getLocalizableString("SectionRegistrationMessage"),
					updateSchemaDataAction: true
				},
				{
					manager: BPMSoft.SectionManager,
					processMessage: this.getLocalizableString("SectionRegistrationMessage"),
					updateSchemaDataAction: true
				},
				{
					manager: BPMSoft.SectionInWorkplaceManager,
					processMessage: this.getLocalizableString("SectionRegistrationMessage"),
					updateSchemaDataAction: true
				},
				{
					method: this.updateSysImageData,
					processMessage: this.getLocalizableString("SectionRegistrationMessage")
				},
				{
					manager: BPMSoft.SysDcmSettingsManager,
					processMessage: this.getLocalizableString("CasesRegistrationMessage"),
					updateSchemaDataAction: true
				},
				{
					manager: BPMSoft.EntityConnectionManager,
					processMessage: this.getLocalizableString("EntityConnectionRegistrationMessage"),
					updateSchemaDataAction: true
				},
				{
					manager: BPMSoft.DetailManager,
					processMessage: this.getLocalizableString("DetailRegistrationMessage"),
					updateSchemaDataAction: true
				});
			return steps;
		},

		/**
		 * @inheritdoc ApplicationStructureItemWizard#getApplicationStructureItemConfig
		 * @override
		 */
		getApplicationStructureItemConfig: function() {
			const config = this.callParent(arguments);
			Ext.apply(config.propertyValues, {
				moduleSchemaUId: BPMSoft.DesignTimeEnums.BaseSchemaUId.SECTION_MODULE_SCHEMA,
				globalSearchAvailable: false,
				folderMode: {
					value: BPMSoft.DesignTimeEnums.SysModuleFolderMode.MULTI_FOLDER_ENTRY
				}
			});
			return config;
		},

		/**
		 * Creates UpdatePackageSchemaDataRequest config.
		 * @protected
		 * @param {Object} entitySchema Entity schema.
		 * @return {Object} UpdatePackageSchemaDataRequest config.
		 */
		createUpdateSysImageDataRequestConfig: function(entitySchema) {
			const leftPanelLogoId = this.applicationStructureItem.getLeftPanelLogo();
			const barSymbolRegExp = new RegExp(/-/g);
			const packageSchemaDataName = Ext.String.format("SysImage_{0}", leftPanelLogoId.replace(barSymbolRegExp, ""));
			return {
				entitySchemaName: "SysImage",
				recordList: [leftPanelLogoId],
				packageUId: this.packageUId,
				packageSchemaDataName: packageSchemaDataName,
				entitySchema: {
					uId: entitySchema.uId,
					primaryColumn: {
						uId: entitySchema.primaryColumn.uId,
						caption: entitySchema.primaryColumn.caption.getCultureValue()
					}
				}
			};
		},

		/**
		 * @inheritdoc ApplicationStructureItemWizard#subscribeModuleMessages
		 * @override
		 */
		subscribeModuleMessages: function() {
			this.callParent(arguments);
			if (this.currentStep === "Cases") {
				const moduleId = this.getModuleIdByStepName(this.currentStep);
				this.sandbox.subscribe("SaveWizard", this.onSaveWizard, this, [moduleId]);
			}
		},

		/**
		 * @inheritdoc ApplicationStructureItemWizard#onAfterSaveWizard
		 * @override
		 */
		onAfterSaveWizard: function() {
			const config = this.saveWizardConfig && this.saveWizardConfig.addCaseConfig;
			if (config) {
				BPMSoft.ProcessModuleUtilities.showCaseSchemaDesigner(config);
			}
			this.callParent(arguments);
		},

		/**
		 * @inheritdoc ApplicationStructureItemWizard#buildOData
		 * @override
		 */
		buildOData: function(callback, scope) {
			BPMSoft.SchemaDesignerUtilities.buildOData(callback, scope);
		},

		/**
		 * @inheritdoc ApplicationStructureItemWizard#onManagersSave
		 * @override
		 */
		onManagersSave: function(callback, scope) {
			BPMSoft.chain(
				function(next) {
					const manager = BPMSoft.SectionProcessSettingsManager;
					if (manager) {
						manager.saveAndUpdateSchemaData(this.packageUId, next, scope);
					} else {
						next();
					}
				},
				this._generateIndexationConfigs,
				this._updateCommandLine,
				function() {
					Ext.callback(callback, scope);
				}, this
			);
		},

		/**
		 * @inheritdoc ApplicationStructureItemWizard#getApplicationStructureItemSchemaUId
		 * @override
		 */
		getApplicationStructureItemSchemaUId: function() {
			return this.applicationStructureItem.getSchemaUId();
		},

		/**
		 * @inheritdoc ApplicationStructureItemWizard#publishModuleConfig
		 * @override
		 */
		publishModuleConfig: function(config) {
			config.wizardType = "section";
			config.wizardManagerName = "SectionManager";
			this.callParent(arguments);
		},

		/**
		 * @inheritdoc ApplicationStructureItemWizard#getSysModuleEntityAbsentMessage
		 * @override
		 */
		getSysModuleEntityAbsentMessage: function() {
			const messageTemplate =
				this.getLocalizableString("WizardSysModuleEntityAbsentMessage");
			const sectionCode = this.applicationStructureItem.getCode();
			return Ext.String.format(messageTemplate, sectionCode);
		},

		/**
		 * @inheritdoc ApplicationStructureItemWizard#getSysModuleEditAbsentMessage
		 * @override
		 */
		getSysModuleEditAbsentMessage: function() {
			return this.getLocalizableString("WizardSysModuleEditAbsentMessage");
		},

		/**
		 * @inheritdoc ApplicationStructureItemWizard#setStep
		 * @override
		 */
		setStep: function(state, callback, scope) {
			if (!this.needSetStep(state)) {
				return Ext.callback(callback, scope);
			}
			this.setSspCreationRequested(state.hash);
			this.callParent(arguments);
		},

		/**
		 * @inheritdoc ApplicationStructureItemWizard#getStepApplicationStructureItemId
		 * @override
		 */
		getStepApplicationStructureItemId: function(stepItemId, callback, scope) {
			if (this.applicationStructureItemId) {
				Ext.callback(callback, scope, [stepItemId]);
				return;
			}
			BPMSoft.chain(
				function(next) {
					const config = {
						data: {
							"sectionId": stepItemId.toLowerCase()
						},
						serviceName: "SectionService",
						methodName: "GetGeneralAndSspSections"
					};
					this._getGeneralAndSspSections(config, next, this);
				},
				function(next, sections) {
					let sspItemId = this.sspSectionId;
					if (!sspItemId) {
						sspItemId = this._getSectionIdByType(sections, this.sectionTypes.SSP, stepItemId);
						if (!sspItemId && this.sspCreationRequested) {
							sspItemId = BPMSoft.generateGUID();
						}
					}
					this._updateSspSectionId(sspItemId, next, this, [sections]);
				},
				function(next, sections) {
					const generalItemId = this._getSectionIdByType(sections,
							this.sectionTypes.GENERAL, stepItemId) || stepItemId.toLowerCase();
					Ext.callback(callback, scope, [generalItemId]);
				},
				this
			);
		},

		/**
		 * @inheritdoc ApplicationStructureItemWizard#modifyUrl
		 * @override
		 */
		modifyUrl: function() {
			const state = this.sandbox.publish("GetHistoryState");
			this.setSspCreationRequested(state.hash);
			this.callParent(arguments);
		},

		/**
		 * @inheritdoc ApplicationStructureItemWizard#getStepHashParts
		 * @override
		 */
		getStepHashParts: function() {
			const hashParts = this.callParent(arguments);
			if (this.sspCreationRequested) {
				hashParts.push("AddSsp");
			}
			return hashParts;
		},

		/**
		 * Sets ssp section create requested flag value.
		 * @param {Object} hash Current history state hash property.
		 */
		setSspCreationRequested: function(hash) {
			if (Ext.isEmpty(hash)) {
				return;
			}
			const entityName = hash.entityName ? hash.entityName.toLowerCase() : "";
			const operationType = hash.operationType ? hash.operationType.toLowerCase() : "";
			if ([entityName, operationType].includes(this.sspCreationRequestProperty.toLowerCase())) {
				this.sspCreationRequested = true;
			}
		},

		/**
		 * @inheritdoc ApplicationStructureItemWizard#getStepStateObj
		 * @override
		 */
		getStepStateObj: function() {
			const state = this.callParent(arguments);
			return Ext.apply(state, {
				sspSectionId: this.sspSectionId,
				sspCreationRequested: this.sspCreationRequested
			});
		},

		/**
		 * @inheritdoc ApplicationStructureItemWizard#onHistoryStateChanged
		 * @override
		 */
		onHistoryStateChanged: function(token) {
			const state = token.state;
			if (state) {
				this.sspSectionId = this.sspSectionId || state.sspSectionId;
				this.sspCreationRequested = this.sspCreationRequested || state.sspCreationRequested;
			}
			this.callParent(arguments);
		},

		//endregion

		//region Methods: Public

		/**
		 * Update SysImage data.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function context.
		 */
		updateSysImageData: function(callback, scope) {
			if (!this.applicationStructureItem.needUpdateLeftPanelLogo()) {
				callback.call(scope);
				return;
			}
			BPMSoft.chain(
				function(next) {
					const items = BPMSoft.EntitySchemaManager.getItems();
					const sysImageSchema = items.firstOrDefault(function(item) {
						return item.name === "SysImage" && !item.extendParent;
					}, this);
					BPMSoft.EntitySchemaManager.getInstanceByUId(sysImageSchema.uId, next, this);
				},
				function(next, entitySchema) {
					const config = this.createUpdateSysImageDataRequestConfig(entitySchema);
					const request = Ext.create("BPMSoft.UpdatePackageSchemaDataRequest", config);
					request.execute(next, this);
				},
				function(next, response) {
					if (response && response.success) {
						callback.call(scope);
					} else {
						throw new BPMSoft.InvalidOperationException({message: response.errorInfo.toString()});
					}
				}, this
			);
		}

		//endregion

	});

	return BPMSoft.SectionWizard;
});
