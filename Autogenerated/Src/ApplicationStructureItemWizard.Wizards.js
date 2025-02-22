﻿define("ApplicationStructureItemWizard", ["MaskHelper", "ext-base", "BPMSoft", "ApplicationStructureItemWizardResources",
	"RightUtilities", "SectionDesignerEnums", "WizardUtilities", "BaseWizardModule", "SysModuleEntityManager",
	"SysModuleEditManager", "PackageUtilities", "LookupManager", "WidgetDashboardManager", "GoogleTagManagerMixin",
	"ApplicationStructureWizardUtils", "css!ApplicationStructureItemWizard", "BusinessRuleSchemaManager"
], function(MaskHelper, Ext, BPMSoft, resources, RightUtilities, SectionDesignerEnums) {

	/**
	 * Base class of wizard of system structure
	 */
	Ext.define("BPMSoft.configuration.ApplicationStructureItemWizard", {
		extend: "BPMSoft.configuration.BaseWizardModule",
		alternateClassName: "BPMSoft.ApplicationStructureItemWizard",

		mixins: {
			WizardUtilities: "BPMSoft.WizardUtilities",
			PackageUtilities: "BPMSoft.PackageUtilities",
			/**
			 * @class SspMiniPageUtilitiesMixin Provides methods for works with google analytics.
			 */
			GoogleTagManagerMixin: "BPMSoft.GoogleTagManagerMixin"
		},

		//region Properties: Private

		/**
		 * List of page steps.
		 * @protected
		 * @type {Array}
		 */
		pagesSteps: [],

		/**
		 * List of mini page steps.
		 * @protected
		 * @type {Array}
		 */
		miniPagesSteps: [],

		/**
		 * Identifier of mask showing while wizard are saving .
		 * @private
		 * @type {String}
		 */
		savingMaskId: null,

		/**
		 * Flag which indicates whether error message was already shown to the user.
		 * @private
		 * @type {Boolean}
		 */
		isErrorMessageShown: false,

		//endregion

		//region Properties: Protected

		/**
		 * Module messages.
		 * @type {Object}
		 */
		applicationStructureItemWizardMessages: {
			"NavigateToAllowedStep": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			"GetModuleInfo": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			"PushHistoryState": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
			"ReplaceHistoryState": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
			"GetModuleConfig": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			"GetModuleConfigResult": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
			"Validate": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
			"ValidationResult": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			"Save": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
			"SavingResult": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			"GetPackageUId": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			"UpdateWizardConfig": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			"EntitySchemaDataCollectionInitialized": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			"OnAfterSave": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
			"OpenDetailDesigner": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			"onAngularDesignerSave": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
		},

		/**
		 * Active step
		 * @protected
		 * @type {String}
		 */
		activeStep: null,

		/**
		 * Operation type
		 * @protected
		 * @type {String}
		 */
		operationType: null,

		/**
		 * Application structure item Id.
		 * @protected
		 * @type {String}
		 */
		applicationStructureItemId: null,

		/**
		 * Application structure manager.
		 * @protected
		 * @type {Object}
		 */
		applicationStructureManager: null,

		/**
		 * Application structure manager item.
		 * @protected
		 * @type {Object}
		 */
		applicationStructureItem: null,

		/**
		 * List of schemas for save data.
		 * @protected
		 * @type {String []}
		 */
		entitySchemaDataList: null,

		//endregion

		//region Methods: Private

		/**
		 * @private
		 */
		_checkPermissions: function() {
			return new Promise(function(resolve, reject) {
				RightUtilities.checkCanExecuteOperations(this.getUserOperations(), function(permissions) {
					const permissionValues = Ext.Object.getValues(permissions);
					const allow = permissionValues.some(function(value) {
						return value === true;
					});
					if (allow) {
						resolve();
					} else {
						reject(this.getLocalizableString("RightsErrorMessage"));
					}
				}, this);
			}.bind(this));
		},

		/**
		 * @private
		 */
		_initializeWizard: function() {
			const initChain = this.getInitChain();
			const chain = initChain.map(function(fn) {
				return new Promise(fn.bind(this));
			}, this);
			chain.push(this._checkPermissions());
			return Promise.all(chain);
		},

		/**
		 * @private
		 */
		_updateApplicationStructureItemId: function(stepApplicationStructureItemId, callback, scope) {
			if (this.applicationStructureItemId === stepApplicationStructureItemId) {
				Ext.callback(callback, scope);
			} else {
				this.applicationStructureItemId = stepApplicationStructureItemId;
				this.setApplicationStructureItem(function() {
					this.checkSchemasOnForeignLock(function(schemas) {
						if (schemas && schemas.length > 0) {
							BPMSoft.showInformation(this.getLockedElementsWarningMessage(schemas));
						}
					}, this);
					Ext.callback(callback, scope);
				}, this);
			}
		},

		/**
		 * @private
		 */
		_addIfNotNew: function(manager, schemas, uid) {
			const item = manager.findItem(uid);
			if (item && !item.isNew()) {
				schemas.push(item.getName());
			}
		},

		/**
		 * @private
		 */
		_checkEntitySchemas: function(schemas) {
			return this._checkSchemas(BPMSoft.EntitySchemaManager, schemas);
		},

		/**
		 * @private
		 */
		_checkClientUnitSchemas: function(schemas) {
			return this._checkSchemas(BPMSoft.ClientUnitSchemaManager, schemas);
		},

		/**
		 * @private
		 */
		_checkSchemas: function(manager, schemas) {
			const errorTypes = SectionDesignerEnums.WizardValidationErrorType;
			return new Promise(function(resolve, reject) {
				manager.getAbsentSchemaItemsInHierarchy({schemaUIds: schemas, packageUId: this.packageUId}, function(absentSchemaItems) {
					if (!Ext.isArray(absentSchemaItems)) {
						reject(absentSchemaItems);
					}
					if (absentSchemaItems.length === 0) {
						resolve();
					} else {
						this.getAbsentSchemasMessage(absentSchemaItems, function(absentSchemaMessage) {
							const error = {
								type: errorTypes.ABSENT_SCHEMAS_IN_HIERARCHY,
								message: absentSchemaMessage
							};
							reject(error);
						}, this);
					}
				}, this);
			}.bind(this));
		},

		/**
		 * @private
		 */
		_defaultSavingMaskCaption: function() {
			return this.getLocalizableString("SavingWizardMessage");
		},

		/**
		 * @private
		 */
		_showSavingMask: function(maskCaption) {
			const caption = maskCaption || this._defaultSavingMaskCaption();
			this.savingMaskId = BPMSoft.Mask.show({
				caption,
				timeout: 0,
				additionalClass: "wizard-mask"
			});
		},

		/**
		 * @private
		 */
		_updateSavingMask: function(resourceName, maskCaption) {
			const resourceString = resourceName && this.getLocalizableString(resourceName);
			const caption = resourceString || maskCaption || this._defaultSavingMaskCaption();
			if (this.savingMaskId) {
				BPMSoft.Mask.updateCaption(this.savingMaskId, caption);
			} else {
				this._showSavingMask(caption);
			}
		},

		/**
		 * @private
		 */
		_hideSavingMask: function() {
			BPMSoft.Mask.hide(this.savingMaskId);
			this.savingMaskId = null;
		},

		/**
		 * @private
		 */
		_addHotkeys: function() {
			const doc = Ext.getDoc();
			doc.on("keydown", this.onKeyDown, this);
		},

		/**
		 * @private
		 */
		_removeHotkeys: function() {
			const doc = Ext.getDoc();
			doc.un("keydown", this.onKeyDown, this);
		},

		/**
		 * @private
		 */
		_fixHasMiniPageAddModeSetting: function(callback, scope) {
			let sysSettingName;
			BPMSoft.chain(
				function(next) {
					this.getSysModuleEntityManagerItem(next, this);
				},
				function(next, sysModuleEntityItem) {
					const uId = sysModuleEntityItem.getEntitySchemaUId();
					const item = BPMSoft.EntitySchemaManager.getItems().get(uId);
					const entitySchemaName = item.getName();
					sysSettingName = BPMSoft.getFormattedString("Has{0}MiniPageAddMode", entitySchemaName);
					BPMSoft.SysSettings.querySysSettingsItem(sysSettingName, next, this);
				},
				function(next, value) {
					if (value) {
						BPMSoft.SysSettings.postSysSettingsValue(sysSettingName, false, next, this);
					} else {
						next();
					}
				},
				function() {
					Ext.callback(callback, scope);
				}, this
			);
		},

		/**
		 * @private
		 */
		_processValidationError: function(error) {
			const errorTypes = SectionDesignerEnums.WizardValidationErrorType;
			let message = "";
			switch (error.type) {
				case errorTypes.SYS_MODULE_EDIT_MISSING:
					message = this.getSysModuleEditAbsentMessage();
					this.showWizardError(message);
					break;
				case errorTypes.SYS_MODULE_ENTITY_MISSING:
					message = this.getSysModuleEntityAbsentMessage();
					this.showWizardError(message);
					break;
				case errorTypes.ABSENT_SCHEMAS_IN_HIERARCHY:
					message = error.message;
					this.showWizardErrorWithLinks(message);
					break;
				default:
					message = error;
					this.showWizardError(message);
					break;
			}
		},

		/**
		 * Gets GTM data for successfully saved wizard.
		 * @private
		 * @return {Object} GTM data for new ssp section action.
		 */
		_getGTMSavedSuccessfullyData: function() {
			var data = this.getDefaultGTMData();
			return Ext.apply(data, {
				action: "WizardSavedSuccessfully"
			});
		},

		/**
		 * Gets GTM data for failed saved wizard.
		 * @private
		 * @param {String} errorMessage Error saving wizard message.
		 * @return {Object} GTM data for new ssp section action.
		 */
		_getGTMSavedFailedData: function(errorMessage) {
			var data = this.getDefaultGTMData();
			return Ext.apply(data, {
				action: "WizardSavedFailed",
				description: errorMessage
			});
		},

		/**
		 * @private
		 */
		_openDetailDesigner: function(detailId) {
			this.mixins.WizardUtilities.openDetailWindow(detailId);
		},

		//endregion

		//region Methods: Protected

		/**
		 * Returns validation message.
		 * @protected
		 * @return {String} Message with specified missing SysModuleEntity instance.
		 */
		getSysModuleEntityAbsentMessage: BPMSoft.emptyFn,

		/**
		 * Returns validation message.
		 * @protected
		 * @return {String} Message with specified missing SysModuleEdit instance.
		 */
		getSysModuleEditAbsentMessage: BPMSoft.emptyFn,

		/**
		 * Returns an array of initialization steps.
		 * @protected
		 * @return {Array} Array of initialization steps.
		 */
		getInitChain: function() {
			return [
				this.initPackageUtilities,
				this.initEntitySchemaManager,
				this.initSysModuleEntityManager,
				this.initSysModuleEditManager,
				this.initClientUnitSchemaManager,
				this.initApplicationStructureManager,
				this.initGoogleTagManager,
				(next, scope) => BPMSoft.DetailManager.initialize(next, scope),
			];
		},

		/**
		 * @protected
		 */
		checkRequirements: function() {
			return Promise.resolve()
				.then(this.getEntitySchemasToCheck.bind(this))
				.then(this._checkEntitySchemas.bind(this))
				.then(this.getClientUnitSchemasToCheck.bind(this))
				.then(this._checkClientUnitSchemas.bind(this))
				.catch(function(error) {
					this._processValidationError(error);
				}.bind(this));
		},

		/**
		 * Returns a list of essential entity schemas.
		 * @protected
		 */
		getEntitySchemasToCheck: function() {
			return Promise.resolve([]);
		},

		/**
		 * Returns a list of essential client unit schemas.
		 * @protected
		 */
		getClientUnitSchemasToCheck: function() {
			return Promise.resolve([]);
		},

		/**
		 * Gets default GTM data.
		 * @protected
		 * @return {Object} Default GTM data.
		 */
		getDefaultGTMData: function() {
			return {
				schemaName: "SspMainSettings",
				moduleName: "SectionWizard"
			};
		},

		/**
		 * Returns list of absent schema names.
		 * @protected
		 * @param {Array} items Absent schema items.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback scope.
		 */
		getAbsentSchemasMessage: function(items, callback, scope) {
			BPMSoft.PackageManager.getPackageInfo([this.getPackageUId()], function(packageInfo) {
				const itemsToDisplay = items.slice(0, 10);
				const names = items.map(function(item) {
					return "\n".concat("- ", item.caption, " (", item.name, ")");
				});
				let message = Ext.String.format(this.getLocalizableString("RequiredSchemasAbsentInHierarchyMessage"),
					packageInfo[this.getPackageUId()],
					names);
				if (items.length > 10) {
					message = message.concat("\n",
						Ext.String.format(this.getLocalizableString("MoreAbsentSchemasMessage"),
							items.length - itemsToDisplay.length));
				}
				callback.call(scope, message);
			}, scope);
		},

		/**
		 * Returns an array operations which should be available to the user.
		 * @protected
		 * @return {String[]}
		 */
		getUserOperations: function() {
			return ["CanManageSolution", "CanManageDcm"];
		},

		/**
		 * @inheritdoc BPMSoft.BaseWizardModule#getMessages
		 * @override
		 */
		getMessages: function() {
			const parentMessages = this.callParent(arguments);
			return Ext.apply(parentMessages, this.applicationStructureItemWizardMessages);
		},

		/**
		 * @inheritdoc BPMSoft.BaseWizardModule#getLocalizableString
		 * @override
		 */
		getLocalizableString: function(key) {
			return resources.localizableStrings[key] || this.callParent(arguments);
		},

		/**
		 * Returns application structure item schema UId.
		 * @abstract
		 * @return {String} Application structure item schema UId.
		 */
		getApplicationStructureItemSchemaUId: BPMSoft.abstractFn,

		/**
		 * On managers in wizard save handler.
		 * @abstract
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback scope.
		 */
		onManagersSave: function(callback, scope) {
			callback.call(scope);
		},

		/**
		 * Returns designed schema names (without new schemas).
		 * @protected
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		getDesignedSchemaNames: function(callback, scope) {
			const schemas = [];
			BPMSoft.chain(
				function(next) {
					if (this.applicationStructureItem.getIsNew()) {
						callback.call(scope);
					} else {
						this.getSysModuleEntityManagerItem(next, this);
					}
				},
				function(next, sysModuleEntityManagerItem) {
					if (sysModuleEntityManagerItem && !sysModuleEntityManagerItem.getIsNew()) {
						const entitySchemaUId = sysModuleEntityManagerItem.getEntitySchemaUId();
						this._addIfNotNew(BPMSoft.EntitySchemaManager, schemas, entitySchemaUId);
						sysModuleEntityManagerItem.getSysModuleEditManagerItems(next, this);
					} else {
						callback.call(scope);
					}
				},
				function(next, managerItems) {
					const schemaUIds = managerItems.mapArray(function(item) {
						return item.getCardSchemaUId();
					}, this);
					schemaUIds.push(this.getApplicationStructureItemSchemaUId());
					schemaUIds.forEach(function(schemaUId) {
						this._addIfNotNew(BPMSoft.ClientUnitSchemaManager, schemas, schemaUId);
					}, this);
					callback.call(scope, schemas);
				}, this
			);
		},

		/**
		 * Returns modified schema names (without new schemas).
		 * @protected
		 * @return {Array} Schema names.
		 */
		getModifiedSchemaNames: function() {
			const schemas = Ext.Array.merge(
				BPMSoft.EntitySchemaManager.getModifiedItems(),
				BPMSoft.ClientUnitSchemaManager.getModifiedItems());
			const notNewSchemas = schemas.filter(function(schema) {
				return !schema.isNew();
			}, this);
			return notNewSchemas.map(function(schema) {
				return schema.getName();
			}, this);
		},

		/**
		 * Checks schemas on foreign lock.
		 * @protected
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		checkSchemasOnForeignLock: function(callback, scope) {
			this.getDesignedSchemaNames(function(schemas) {
				BPMSoft.SchemaDesignerUtilities.getSchemasWithForeignLock(this.packageUId, schemas, callback, scope);
			}, this);
		},

		/**
		 * Checks modified schemas on foreign lock.
		 * @protected
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		checkModifiedSchemasOnForeignLock: function(callback, scope) {
			this._updateSavingMask("SavingWizardMessage");
			const schemas = this.getModifiedSchemaNames();
			BPMSoft.SchemaDesignerUtilities.getSchemasWithForeignLock(this.packageUId, schemas, function(lockedSchemas) {
				callback.call(scope, lockedSchemas);
			}, this);
		},

		/**
		 * Returns LockedElementsWarning message.
		 * @protected
		 * @param {Array} schemas Schemas.
		 * @return {String} LockedElementsWarning message.
		 */
		getLockedElementsWarningMessage: function(schemas) {
			return this.getLocalizableString("LockedElementsWarning") + "\n" + schemas.join(",\n");
		},

		/**
		 * Initialize package utilities.
		 * @protected
		 * @param {Function} callback The function will be called at the end.
		 * @param {Function} errorCallback The function will be called when error.
		 */
		initPackageUtilities: function(callback, errorCallback) {
			BPMSoft.chain(
				this.mixins.PackageUtilities.initCurrentPackageUId.bind(this),
				function(next, result) {
					if (result.success) {
						callback();
					} else {
						errorCallback(result.message);
					}
				},
				this
			);
		},

		/**
		 * Init application structure manager.
		 * @protected
		 * @param {Function} callback The function will be called if false.
		 */
		initApplicationStructureManager: function(callback) {
			const applicationStructureManager = this.applicationStructureManager;
			if (applicationStructureManager && applicationStructureManager.initialize) {
				applicationStructureManager.initialize(null, callback, this);
			} else {
				callback();
			}
		},

		/**
		 * Init entity schema manager.
		 * @protected
		 * @param {Function} callback The function will be called if false.
		 */
		initEntitySchemaManager: function(callback) {
			BPMSoft.EntitySchemaManager.initialize(callback, this);
		},

		/**
		 * Init sysModule entity manager.
		 * @protected
		 * @param {Function} callback The function will be called if false.
		 */
		initSysModuleEntityManager: function(callback) {
			BPMSoft.SysModuleEntityManager.initialize(null, callback, this);
		},

		/**
		 * Init sysModule edit manager.
		 * @protected
		 * @param {Function} callback The function will be called if false.
		 */
		initSysModuleEditManager: function(callback) {
			BPMSoft.SysModuleEditManager.initialize(null, callback, this);
		},

		/**
		 * Init Client unit schema manager.
		 * @protected
		 * @param {Function} callback The function will be called if false.
		 */
		initClientUnitSchemaManager: function(callback) {
			BPMSoft.ClientUnitSchemaManager.initialize(callback, this);
		},

		/**
		 * Modifies the configuration steps object. Publishes a message to the top panel.
		 * @protected
		 */
		onUpdateWizardConfig: function() {
			this.initEntitySchemaPages(function() {
				const config = this.onGetConfig();
				this.sandbox.publish("UpdateConfig", config, [this.getWizardHeaderId()]);
			}, this);
		},

		/**
		 * @inheritdoc BPMSoft.BaseWizardModule#onGetConfig
		 * @override
		 */
		onGetConfig: function() {
			return {
				caption: this.getCaption() || this.getNewApplicationStructureItemWizardCaption(),
				currentStep: this.currentStep,
				steps: this.getSteps()
			};
		},

		/**
		 * Return an array of configuration steps objects.
		 * @protected
		 * @return {Array}  An array of objects configuration steps.
		 */
		getSteps: function() {
			return [];
		},

		/**
		 * Returns ApplicationStructureItem initialization configuration.
		 * @protected
		 * @param {Guid} [managerItemId] Aplication structure manager item identifier.
		 * @return {Object} ApplicationStructureItem initialization configuration.
		 */
		getApplicationStructureItemConfig: function(managerItemId) {
			return {
				propertyValues: {
					id: managerItemId || this.applicationStructureItemId
				}
			};
		},

		/**
		 * Returns structure item from application structure maanger.
		 * Will create new item if item not found.
		 * @protected
		 * @param {Guid} managerItemId Manager item identifier.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		getStructureItem: function(managerItemId, callback, scope) {
			const applicationStructureItem = this.applicationStructureManager.findItem(managerItemId);
			if (applicationStructureItem) {
				Ext.callback(callback, scope || this, [applicationStructureItem]);
			} else {
				const config = this.getApplicationStructureItemConfig(managerItemId);
				this.applicationStructureManager.createItem(config, function(item) {
					Ext.callback(callback, scope || this, [this.applicationStructureManager.addItem(item)]);
				}, this);
			}
		},

		/**
		 * Set application structure item.
		 * @protected
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		setApplicationStructureItem: function(callback, scope) {
			BPMSoft.chain(
				function(next) {
					this.getStructureItem(this.applicationStructureItemId, next, this);
				}, function(next, applicationStructureItem) {
					this.applicationStructureItem = applicationStructureItem;
					next();
				},
				function() {
					this.initEntitySchemaPages(callback, scope);
				}, this
			);
		},

		/**
		 * Get new application structure of item wizard caption.
		 * @protected
		 * @return {Object}
		 */
		getNewApplicationStructureItemWizardCaption: function() {
			return this.getLocalizableString("NewApplicationStructureItemWizardCaption");
		},

		/**
		 * Get application structure of item caption.
		 * @protected
		 * @return {String}
		 */
		getApplicationStructureItemCaption: function() {
			const caption = this.applicationStructureItem && this.applicationStructureItem.getCaption();
			return caption || "";
		},

		/**
		 * Returns caption of detail.
		 * @protected
		 * @return {String} Caption of detail.
		 */
		getCaption: function() {
			const applicationStructureItemCaption = this.getApplicationStructureItemCaption();
			return Ext.isEmpty(applicationStructureItemCaption)
				? this.getNewApplicationStructureItemWizardCaption()
				: applicationStructureItemCaption;
		},

		/**
		 * Get caption of template.
		 * @protected
		 * @return {String}
		 */
		getCaptionTemplate: function() {
			return "{0}: {1}";
		},

		/**
		 * Generates step caption.
		 * @protected
		 * @return {String} Step caption.
		 */
		generateStepCaption: function() {
			return "";
		},

		/**
		 * Changes active tab to "Business processes".
		 * @protected
		 */
		onNavigateToAllowedStep: function() {
			this.closeWindow();
		},

		/**
		 * Generates id from modal box page.
		 * @protected
		 * @return {String}
		 */
		getErrorModalBoxWindowId: function() {
			return this.sandbox.id + "_ErrorModalBox";
		},

		/**
		 * Generates array of wizard steps where error message about incorrect hierarchy should be shown once.
		 * @protected
		 * @return {Array}
		 */
		getErrorFreeSteps: function() {
			return [];
		},

		/**
		 * Shows enhanced error modal box with links to configuration and system settings.
		 * @protected
		 * @param {String} message Text to display.
		 */
		showWizardErrorWithLinks: function(message) {
			this.isErrorMessageShown = true;
			this.sandbox.loadModule("ModalBoxSchemaModule", {
				id: this.getErrorModalBoxWindowId(),
				instanceConfig: {
					moduleInfo: {
						schemaName: "WizardErrorModalBoxPage",
						errorMessageText: message
					}
				}
			});
		},

		/**
		 * Subscribe to the messages of the current module.
		 * @protected
		 */
		subscribeModuleMessages: function() {
			const sandbox = this.sandbox;
			const moduleId = this.getModuleIdByStepName(this.currentStep);
			sandbox.subscribe("SavingResult", this.onSavingResult, this, [moduleId]);
			this.sandbox.subscribe("NavigateToAllowedStep", this.onNavigateToAllowedStep, this,
				[this.getErrorModalBoxWindowId()]);
			sandbox.subscribe("ValidationResult", this.onValidationResult, this, [moduleId]);
			sandbox.subscribe("GetPackageUId", this.getPackageUId, this, [moduleId]);
			sandbox.subscribe("GetModuleConfig", this.onGetModuleConfig, this, [moduleId]);
			sandbox.subscribe("EntitySchemaDataCollectionInitialized",
				this.onEntitySchemaDataCollectionInitialized, this);
			sandbox.subscribe("SaveWizard", this.onSaveWizard, this, [moduleId]);
			sandbox.subscribe("OpenDetailDesigner", this._openDetailDesigner, this, [moduleId]);
			this.sandbox.subscribe("onAngularDesignerSave", this.getAngularDesignerData, this, ['angularDesigner']);
		},

		/**
		 * Handles a message about the initialize EntitySchemaDataCollection.
		 * @protected
		 * @param {String} entitySchemaName The name of entity schema.
		 */
		onEntitySchemaDataCollectionInitialized: function(entitySchemaName) {
			this.entitySchemaDataList = this.entitySchemaDataList || [];
			this.entitySchemaDataList.push(entitySchemaName);
		},

		getAngularDesignerData: function(data) {
			BPMSoft.angularDesignerObj = data;
		},

		/**
		 * Handler saving wizard.
		 * @protected
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		onSavingResult: function(callback, scope) {
			if (this.isSavingWizard) {
				this.saveWizard(callback, scope);
				return;
			}
			const needToSaveWizard = this.activeStep === "BusinessRules" && this.hasModifiedEntitySchemas();
			if (needToSaveWizard === false) {
				this.onStepChanged(this.activeStep);
				return;
			}
			const message = this.getLocalizableString("SaveMessage");
			const saveButtonCaption = this.getLocalizableString("SaveButtonCaption");
			const saveButton = BPMSoft.getButtonConfig("save", saveButtonCaption);
			BPMSoft.showConfirmation(message, function(returnCode) {
				if (returnCode === "save") {
					this.saveWizardConfig = {silentMode: true};
					this.saveWizard(function() {
						this.onStepChanged(this.activeStep);
					}, this);
				}
			}, [saveButton, "cancel"], this, {defaultButton: 0});
		},

		/**
		 * Handles a message about the result of the module validation.
		 * @protected
		 * @param {Boolean} result Result of module validation.
		 */
		onValidationResult: function(result) {
			if (result) {
				this.publishSave();
			} else {
				this.isSavingWizard = false;
			}
		},

		/**
		 * Publishes save message.
		 * @protected
		 */
		publishSave: function() {
			const moduleId = this.getModuleIdByStepName(this.currentStep);
			this.sandbox.publish("Save", null, [moduleId]);
		},

		/**
		 * Publishes configuration module object
		 * @protected
		 * @type {Function}
		 */
		onGetModuleConfig: Ext.emptyFn,

		/**
		 * @inheritdoc BPMSoft.BaseWizardModule#onCurrentStepChange
		 * @override
		 */
		onCurrentStepChange: function(stepName) {
			const moduleId = this.getModuleIdByStepName(this.currentStep);
			this.activeStep = stepName;
			this.sandbox.publish("Validate", null, [moduleId]);
			return true;
		},

		/**
		 * Handler a change of step.
		 * @protected
		 * @param {String} step Step name.
		 */
		onStepChanged: function(step) {
			const stepConfig = this.getStepConfigByName(step);
			if (stepConfig && stepConfig.groupName) {
				this.currentStep = stepConfig.groupName;
				this.operationType = stepConfig.name;
			} else {
				this.currentStep = step;
				this.operationType = null;
			}
			const pathList = [this.currentStep, this.applicationStructureItemId];
			if (this.operationType) {
				pathList.push(this.operationType);
			}
			const newHash = BPMSoft.combinePath.apply(this, pathList);
			this.sandbox.publish("PushHistoryState", {
				hash: newHash,
				state: {
					moduleId: this.getModuleIdByStepName(step)
				}
			});
		},

		/**
		 * Generate module identifier.
		 * @protected
		 * @param {String} moduleName Module name.
		 * @param {Object} currentState Current state.
		 * @return {String} Module identifier.
		 */
		generateModuleId: function(moduleName, currentState) {
			const stepName = currentState && currentState.hash && currentState.hash.moduleName;
			return this.getModuleIdByStepName(stepName);
		},

		/**
		 * Gets the unique identifier of the module named step.
		 * @protected
		 * @param {String} stepName Step name.
		 * @return {String}
		 */
		getModuleIdByStepName: function(stepName) {
			let moduleId = null;
			const stepConfig = this.getStepConfigByName(stepName);
			if (stepConfig) {
				const schemaName = stepConfig.schemaName;
				const moduleName = (schemaName) ? schemaName : stepConfig.moduleName;
				moduleId = moduleName + "_" + stepConfig.name;
			}
			return moduleId;
		},

		/**
		 * Publish Configuration module object.
		 * @protected
		 * @param {Object} config Configuration module object.
		 */
		publishModuleConfig: function(config) {
			const moduleId = this.getModuleIdByStepName(this.currentStep);
			if (this.applicationStructureItem) {
				config.applicationStructureItemId = this.applicationStructureItem.getId();
			}
			this.sandbox.publish("GetModuleConfigResult", config, [moduleId]);
		},

		/**
		 * Gets configuration object of step.
		 * @protected
		 * @param {String} stepName Step name.
		 * @return {Object} Configuration object of step.
		 */
		getStepConfigByName: function(stepName) {
			const steps = this.getSteps();
			let result = null;
			BPMSoft.each(steps, function(step) {
				if (step.name === stepName) {
					result = step;
					return false;
				}
			}, this);
			return result;
		},

		/**
		 * Returns currently loading wizard module name from current url.
		 * @protected
		 * @return {String}
		 */
		getLoadingWizardName: function() {
			const execResult = (/\?vm=(\w+)(#|$)/).exec(window.location.href);
			return execResult && execResult[1];
		},

		/**
		 * @inheritdoc BPMSoft.BaseViewModule#onHistoryStateChanged
		 * @override
		 */
		onHistoryStateChanged: function() {
			var moduleName = this.getLoadingWizardName();
			if (moduleName === this.getTypeInfo().typeName) {
				this.callParent(arguments);
			} else {
				this.sandbox.loadModule(moduleName, {
					id: "ViewModule",
					renderTo: "mainContentWrapper"
				});
			}
		},

		/**
		 * @inheritdoc BPMSoft.BaseViewModule#loadModuleFromHistoryState
		 * @override
		 */
		loadModuleFromHistoryState: function(token, isInitialized) {
			if (this.needUrlModification(token)) {
				this.modifyUrl();
				return;
			}
			if (isInitialized) {
				const defaultToken = this.modifyStateToDefault(token);
				this.callParent([defaultToken]);
			} else {
				this.initStepFromHistoryState(token, function() {
					this.loadModuleFromHistoryState(token, true);
				}, this);
			}
		},

		/**
		 * Init step from history state.
		 * @protected
		 * @param {Object} token History state token.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		initStepFromHistoryState: function(token, callback, scope) {
			this.setStep(token, function() {
				this.subscribeModuleMessages();
				Ext.callback(callback, scope);
			}, this);
		},

		/**
		 * Checks need to modify the hash.
		 * @protected
		 * @param {Object} currentState Object of current browser state.
		 * @return {Boolean}
		 */
		needUrlModification: function(currentState) {
			const currentStateHash = currentState.hash;
			const moduleName = currentStateHash.moduleName;
			return !moduleName || BPMSoft.isGUID(moduleName) || moduleName === "New";
		},

		/**
		 * Returns current step url hash parts array.
		 * @protected
		 * @param {String} currentStep Current step name.
		 * @return {Array} Current step url hash parts array.
		 */
		getStepHashParts: function(currentStep) {
			const applicationStructureItemId = this.getApplicationStructureItemIdFromHistoryState();
			return [currentStep, applicationStructureItemId || BPMSoft.generateGUID()];
		},

		/**
		 * Modifies the hash.
		 * @protected
		 */
		modifyUrl: function() {
			const state = this.sandbox.publish("GetHistoryState");
			if (this.needUrlModificationByMultiPageCollision(state)) {
				this.setHistoryStateToFirstStep(state);
			} else {
				const currentStep = this.getStepFromHistoryState();
				if (currentStep) {
					const hashParts = this.getStepHashParts(currentStep);
					const newHash = hashParts.join("/");
					const moduleId = this.getModuleIdByStepName(currentStep);
					this.sandbox.publish("ReplaceHistoryState", {
						hash: newHash,
						state: {moduleId: moduleId}
					});
				}
			}
		},

		/**
		 * Checks if need modify url by multi-page collisions.
		 * @protected
		 * @param {Object} state HistoryState.
		 * @return {Boolean}
		 */
		needUrlModificationByMultiPageCollision: function(state) {
			let needUrlModify = false;
			if (this.isMultiPageHistoryState(state)) {
				const hash = state.hash;
				const managerItemId = hash.operationType;
				const managerItem = BPMSoft.SysModuleEditManager.findItem(managerItemId);
				needUrlModify = managerItem ? managerItem.isDeleted : true;
			}
			return needUrlModify;
		},

		/**
		 * Checks if a multi-page historyState.
		 * @protected
		 * @param {Object} state HistoryState.
		 * @return {Boolean}
		 */
		isMultiPageHistoryState: function(state) {
			let response = false;
			if (state && state.hash) {
				const hash = state.hash;
				const moduleName = hash.moduleName;
				const operationType = hash.operationType;
				if (moduleName === "PageDesigner" &&
					BPMSoft.isGUID(operationType) &&
					!BPMSoft.isEmptyGUID(operationType)) {
					response = true;
				}
			}
			return response;
		},

		/**
		 * Gets application structureItemId from history state.
		 * @protected
		 * @return {String}
		 */
		getApplicationStructureItemIdFromHistoryState: function() {
			const state = this.sandbox.publish("GetHistoryState");
			if (!state) {
				return null;
			}
			const stateHash = state.hash || {};
			let applicationStructureItemId;
			if (BPMSoft.isGUID(stateHash.moduleName)) {
				applicationStructureItemId = stateHash.moduleName;
			} else if (BPMSoft.isGUID(stateHash.schemaName)) {
				applicationStructureItemId = stateHash.schemaName;
			} else {
				applicationStructureItemId = null;
			}
			return applicationStructureItemId;
		},

		/**
		 * Gets step from HistoryState.
		 * @protected
		 * @return {String} Step name.
		 */
		getStepFromHistoryState: function() {
			const currentState = this.sandbox.publish("GetHistoryState");
			const currentStateHash = currentState.hash;
			const moduleName = currentStateHash.moduleName;
			const entityName = currentStateHash.entityName;
			let currentStep;
			if (!moduleName || BPMSoft.isGUID(moduleName) || moduleName === "New") {
				currentStep = this.getDefaultStepName();
			} else if (BPMSoft.isGUID(entityName)) {
				currentStep = moduleName;
			} else {
				currentStep = null;
			}
			return currentStep;
		},

		/**
		 * Checks is step set is needed.
		 * @param {Object} state Current history state.
		 * @return {Boolean}
		 */
		needSetStep: function(state) {
			if (!state) {
				return false;
			}
			const moduleName = state.hash.moduleName;
			const entityName = state.hash.entityName || "";
			if (!moduleName || !BPMSoft.isGUID(entityName)) {
				return false;
			}
			return true;
		},

		/**
		 * Sets wizard step.
		 * @protected
		 * @param {Object} state Current state of the wizard.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		setStep: function(state, callback, scope) {
			if (!this.needSetStep(state)) {
				return Ext.callback(callback, scope);
			}
			const moduleName = state.hash.moduleName;
			const entityName = state.hash.entityName || "";
			this.currentStep = moduleName;
			this.operationType = state.hash.operationType;
			BPMSoft.chain(
				function(next) {
					this.getStepApplicationStructureItemId(entityName.toLowerCase(), next, this);
				},
				function(next, stepApplicationStructureItemId) {
					this._updateApplicationStructureItemId(stepApplicationStructureItemId, next, this);
				},
				function(next) {
					this.getSysModuleEntityManagerItem(next, this);
				},
				function(next, managerItem) {
					this.getActiveSysModuleEditManagerItems(managerItem, next, this);
				},
				function(next, pageCollection) {
					if (this.operationType && pageCollection.getCount() === 1) {
						this.operationType = null;
					}
					const config = this.onGetConfig();
					this.updateHeader(config);
					const errorFreeSteps = this.getErrorFreeSteps();
					if (BPMSoft.contains(errorFreeSteps, this.currentStep) && this.isErrorMessageShown) {
						next();
					} else {
						this.checkRequirements().then(next);
					}
				},
				function() {
					Ext.callback(callback, scope);
				}, this
			);
		},

		/**
		 * Get actual application structure item identifier.
		 * @param {Guid} stepItemId Actual application structure item identifier.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		getStepApplicationStructureItemId: function(stepItemId, callback, scope) {
			Ext.callback(callback, scope, [stepItemId]);
		},

		/**
		 * Returns step state object.
		 * @protected
		 * @param {Object} stepConfig Wizard step config.
		 * @return {Object} Step state object.
		 */
		getStepStateObj: function(stepConfig) {
			return {
				designerSchemaName: stepConfig.schemaName
			};
		},

		/**
		 * Modifies HistoryState to default.
		 * @protected
		 * @param {Object} currentState Object of current browser state.
		 * @return {Object} Default token.
		 */
		modifyStateToDefault: function(currentState) {
			if (!currentState) {
				return;
			}
			const currentStateHash = currentState.hash;
			const stepName = currentStateHash.moduleName;
			const stepConfig = this.getStepConfigByName(stepName);
			if (!stepConfig) {
				return currentState;
			}
			const schemaName = stepConfig.schemaName;
			const moduleName = stepConfig.moduleName;
			const stateObj = {
				schemaName: schemaName,
				moduleId: this.getModuleIdByStepName(stepName)
			};
			const historyState = schemaName
				? BPMSoft.combinePath(moduleName, schemaName)
				: BPMSoft.combinePath(moduleName);
			var replaceStateObj = this.getStepStateObj(stepConfig) ;
			const replacedToken = {
				hash: currentStateHash.historyState,
				stateObj: replaceStateObj,
				silent: true
			};
			this.sandbox.publish("ReplaceHistoryState", replacedToken);
			const modifiedToken = {
				hash: {
					entityName: schemaName,
					moduleName: moduleName,
					historyState: historyState
				},
				stateObj: stateObj,
				state: {
					designerSchemaName: stepConfig.schemaName || null
				}
			};
			return modifiedToken;
		},

		/**
		 * Gets default step name
		 * @protected
		 * @type {Function}
		 */
		getDefaultStepName: Ext.emptyFn,

		/**
		 * Publishes message of top panel, to change the current step.
		 * @protected
		 * @param {Object} config Configuration step object.
		 */
		updateHeader: function(config) {
			if (config.caption) {
				this.setTitle(config.caption);
			}
			this.sandbox.publish("UpdateConfig", config, [this.getWizardHeaderId()]);
		},

		/**
		 * Returns page schema UId for active step.
		 * @protected
		 * @param {BPMSoft.SysModuleEntityManagerItem} sysModuleEntityManagerItem Callback
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		getActiveStepPageSchemaUId: function(sysModuleEntityManagerItem, callback, scope) {
			BPMSoft.chain(
				function(next) {
					this.getActiveSysModuleEditManagerItems(sysModuleEntityManagerItem, next, this);
				},
				function(next, sysModuleEditManagerItems) {
					const currentStep = this.getStepConfigByName(this.operationType || this.currentStep);
					const editManagerItem = currentStep.id
						? sysModuleEditManagerItems.get(currentStep.id)
						: sysModuleEditManagerItems.first();
					const pageSchemaUId = currentStep.isMiniPage
						? editManagerItem.getMiniPageSchemaUId()
						: editManagerItem.getCardSchemaUId();
					callback.call(scope, pageSchemaUId);
				}, this
			);
		},

		/**
		 * Returns active edit page manager items.
		 * @protected
		 * @param {Object} sysModuleEntityManagerItem Item of SysModuleEntity.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		getActiveSysModuleEditManagerItems: function(sysModuleEntityManagerItem, callback, scope) {
			const collection = new BPMSoft.Collection();
			if (sysModuleEntityManagerItem) {
				sysModuleEntityManagerItem.getSysModuleEditManagerItems(function(pageCollection) {
					if (pageCollection) {
						pageCollection.each(function(item) {
							if (!item.isDeleted) {
								collection.add(item.id, item);
							}
						}, this);
					}
					Ext.callback(callback, scope, [collection]);
				}, this);
			} else {
				Ext.callback(callback, scope, [collection]);
			}
		},

		/**
		 * Handler for event change in EntitySchemaManagerItem.
		 * @protected
		 * @param {Object} changes Object of changes
		 * @param {BPMSoft.EntitySchemaManagerItem} entitySchema Element of manager
		 */
		onEntitySchemaChange: function(changes, entitySchema) {
			if (!BPMSoft.EntitySchemaManager.findItem(entitySchema.uId)) {
				BPMSoft.EntitySchemaManager.addSchema(entitySchema);
			}
		},

		/**
		 * Generate config of entity schema page.
		 * @protected
		 * @param {BPMSoft.manager.SysModuleEditManagerItem} sysModuleEditManagerItem Scheme name of entity.
		 * @return {Object}
		 */
		getEntitySchemaPageConfig: function(sysModuleEditManagerItem) {
			const itemId = sysModuleEditManagerItem.getId();
			return {
				id: itemId,
				name: itemId,
				caption: sysModuleEditManagerItem.getPageCaption(),
				groupName: "PageDesigner",
				moduleName: "ViewModelSchemaDesignerModule"
			};
		},

		/**
		 * Init entity schema mini pages.
		 * @protected
		 * @param {BPMSoft.core.collections.Collection} items Collection of SysModuleEditManagerItem.
		 */
		initEntitySchemaMiniPages: function(items) {
			this.miniPagesSteps = [];
			items.each(function(item) {
				const schemaUId = item.getMiniPageSchemaUId();
				if (schemaUId) {
					const config = {
						name: "MiniPageDesigner",
						caption: resources.localizableStrings.MiniPageDesignerStepCaption,
						moduleName: "MiniPageDesignerModule",
						isMiniPage: true
					};
					this.miniPagesSteps.push(config);
					return false;
				}
			}, this);
		},

		/**
		 * Gets pages of object. Sets the configuration objects for each of the page in an array of steps.
		 * @protected
		 * @param {Function} callback The function will be called at the end
		 * @param {Object} scope The context in which the callback function is called
		 */
		initEntitySchemaPages: function(callback, scope) {
			BPMSoft.chain(
				function(next) {
					this.getSysModuleEntityManagerItem(next, this);
				},
				function(next, sysModuleEntityManagerItem) {
					if (sysModuleEntityManagerItem) {
						sysModuleEntityManagerItem.getSysModuleEditManagerItems(next, this);
					} else {
						next();
					}
				},
				function(next, sysModuleEditManagerItems) {
					if (sysModuleEditManagerItems) {
						const items = sysModuleEditManagerItems.filterByFn(function(item) {
							return !item.isDeleted;
						}, this);
						const pagesSteps = items.mapArray(function(item) {
							return this.getEntitySchemaPageConfig(item);
						}, this);
						this.pagesSteps = pagesSteps.length > 1 ? pagesSteps : [];
					}
					Ext.callback(callback, scope);
				}, this
			);
		},

		/**
		 * Gets system module entity manager item.
		 * @protected
		 * @param {Function} callback The function will be called at the end
		 * @param {Object} scope The context in which the callback function is called
		 */
		getSysModuleEntityManagerItem: function(callback, scope) {
			if (this.applicationStructureItem) {
				this.applicationStructureItem.getSysModuleEntityManagerItem(callback, scope);
			} else {
				callback.call(scope);
			}
		},

		/**
		 * Get PageDesigner step caption.
		 * @protected
		 * @param {Object} currentStepConfig step config.
		 * @return {String} step caption.
		 */
		getPageDesignerStepCaption: function(currentStepConfig) {
			let caption = currentStepConfig.caption;
			const stepGroupName = currentStepConfig.groupName;
			if (stepGroupName === "PageDesigner") {
				const currentGroup = this.getStepConfigByName(stepGroupName);
				caption = Ext.String.format("{0} {1}", currentGroup.caption, caption);
			}
			return caption;
		},

		/**
		 * Prepares entity schema for page designer.
		 * @protected
		 * @param {BPMSoft.manager.EntitySchema} entitySchema Entity schema instance.
		 */
		preparePageDesignerEntitySchema: function(entitySchema) {
			if (!BPMSoft.EntitySchemaManager.contains(entitySchema.uId)) {
				if (entitySchema.extendParent) {
					entitySchema.on("changed", this.onEntitySchemaChange, this);
				} else {
					BPMSoft.EntitySchemaManager.addSchema(entitySchema);
				}
			}
		},

		/**
		 * Prepare an object containing instances of entity and customer circuits to initialize the page designer.
		 * @protected
		 * @return {Object} result The object containing instances of entity and
		 * customer circuits to initialize designer
		 * @return {BPMSoft.EntitySchema} result.entitySchema Object of entity-schemes class
		 * @return {BPMSoft.ClientUnitSchema} result.clientUnitSchema Object of client scheme class
		 * @param {Function} callback The function will be called at the end
		 * @param {Object} scope The context in which the callback function is called
		 */
		preparePageDesignerConfig: function(callback, scope) {
			const result = {
				entitySchema: null,
				clientUnitSchema: null
			};
			let entityName;
			BPMSoft.chain(
				function(next) {
					this.getSysModuleEntityManagerItem(next, this);
				},
				function(next, sysModuleEntityManagerItem) {
					this.sysModuleEntityManagerItem = sysModuleEntityManagerItem;
					BPMSoft.EntitySchemaManager.forceGetPackageSchema({
						packageUId: this.packageUId,
						schemaUId: sysModuleEntityManagerItem.getEntitySchemaUId()
					}, next, this);
				},
				function(next, entitySchema) {
					if (!BPMSoft.EntitySchemaManager.findItem(entitySchema.uId)) {
						BPMSoft.EntitySchemaManager
							.addSchema(entitySchema)
							.setStatus(BPMSoft.ModificationStatus.NOT_MODIFIED);
					}
					result.entitySchema = entitySchema;
					entityName = entitySchema.name;
					this.preparePageDesignerEntitySchema(entitySchema);
					this.getActiveStepPageSchemaUId(this.sysModuleEntityManagerItem, next, this);
				},
				function(next, pageSchemaUId) {
					BPMSoft.ClientUnitSchemaManager.designPageSchema({
						schemaUId: pageSchemaUId,
						packageUId: this.packageUId,
						entityName: entityName
					}, next, this);
				},
				function(next, clientUnitSchema) {
					result.clientUnitSchema = clientUnitSchema;
					delete this.sysModuleEntityManagerItem;
					callback.call(scope, result);
				}, this
			);
		},

		/**
		 * Prepare business rule section configuration.
		 * @protected
		 * @param {Function} callback The function will be called at the end.
		 * @param {Object} callback.result Business rule settings configuration.
		 * @param {Object} scope The context in which the callback function is called.
		 */
		prepareBusinessRuleSectionConfig: function(callback, scope) {
			const result = {
				"packageUId": this.packageUId,
				"applicationStructureItem": this.applicationStructureItem
			};
			callback.call(scope, result);
		},

		/**
		 * Function handles the response to a step of storing of the master.
		 * @protected
		 * @param {BPMSoft.BaseResponse} response Response of saving wizard's step.
		 * @param {Function} callback Function of the next step.
		 * @param {Object} scope The context in which the callback function is called.
		 */
		processSaveWizardResponse: function(response, callback, scope) {
			if (response && response.success) {
				callback.call(scope, response);
			} else {
				const errorMessage = response.failedItem
				? this.getSaveSchemaManagerErrorMessage(response)
				: response.errorInfo ? response.errorInfo.toString() : "Ошибка неопределена";
				const gtmData = this._getGTMSavedFailedData(errorMessage);
				this.sendGoogleTagManagerData(gtmData);

				if (response.angularBuildResultModels || response.changesWrappersResultModel || response.errorInfo) {
					this.handleErrors(response);
				} else {
					this.showWizardError(errorMessage);
				}
				console.log("response", response)
				console.log("errorMessage", errorMessage)
			}
		},

		/**
		 * Gets scheme manager error message during saving.
		 * @protected
		 * @param {BPMSoft.BaseResponse} managerSaveResponse Response of saving wizard's step.
		 * @return {String} Error message.
		 */
		getSaveSchemaManagerErrorMessage: function(managerSaveResponse) {
			const failedItem = managerSaveResponse.failedItem;
			const errorMessage = Ext.String.format(
				BPMSoft.Resources.Managers.Exceptions.SaveSchemaErrorTemplate, failedItem.getName(),
				failedItem.getCaption(), managerSaveResponse.errorInfo.toString());
			return errorMessage;
		},

		/**
		 * Returns new entity schemas names.
		 * @protected
		 * @return {String[]}
		 */
		getNewEntitySchemaNames: function() {
			return BPMSoft.EntitySchemaManager.getItems()
				.filterByPath("status", BPMSoft.ModificationStatus.NEW)
				.mapArray(function(item) {
					return item.name;
				}, this);
		},

		/**
		 * Saves object schema.
		 * @protected
		 * @param {Function} callback The function will be called at the end.
		 * @param {Object} scope The context in which the callback function is called.
		 */
		saveEntitySchemesProcess: function(callback, scope) {
			BPMSoft.chain(
				function(next) {
					if (!this.entitySchemaDataList) {
						this.entitySchemaDataList = this.getNewEntitySchemaNames();
					}
					this._updateSavingMask("SavingEntitySchemasMessage");
					BPMSoft.EntitySchemaManager.save(next, this);
				},
				function(next, response) {
					this.processSaveWizardResponse(response, next, this);
				},
				function(next) {
					this._updateSavingMask("UpdatingDBStructureMessage");
					BPMSoft.EntitySchemaManager.updateDBStructure({packageUId: this.packageUId}, next, this);
				},
				function(next, response) {
					if (response) {
						this.processSaveWizardResponse(response, next, this);
					} else {
						callback.call(scope);
					}
				},
				function(next) {
					this._updateSavingMask("CompilingMessage");
					BPMSoft.SchemaDesignerUtilities.buildWorkspace(next, this);
				},
				function(next, response) {
					this.processSaveWizardResponse(response, callback, scope);
				}, this
			);
		},

		/**
		 * Keeps client schemes.
		 * @protected
		 * @param {Function} callback The function will be called at the end.
		 * @param {Object} scope The context in which the callback function is called.
		 */
		saveClientUnitSchemesProcess: function(callback, scope) {
			this._updateSavingMask("SavingClientUnitSchemasMessage");
			BPMSoft.chain(
				function(next) {
					BPMSoft.ClientUnitSchemaManager.save(next, this);
				},
				function(next, response) {
					this.processSaveWizardResponse(response, next, this);
				},
				function(next, saveWizardResponse) {
					const savedSchemaUIds = saveWizardResponse.items.getKeys();
					if (savedSchemaUIds.length > 0) {
						this._updateSavingMask("UpdateClientUnitSchemaModuleFiles");
						BPMSoft.SchemaDesignerUtilities.updateClientUnitSchemasFileContent(savedSchemaUIds, next, this);
					} else {
						callback.call(scope);
					}
				},
				function(next, response) {
					this.processSaveWizardResponse(response, callback, scope);
				}, this
			);
		},

		/**
		 * Availability of modified entity schemas.
		 * @protected
		 * @return {Boolean}
		 */
		hasModifiedEntitySchemas: function() {
			return BPMSoft.EntitySchemaManager.hasModifiedItems();
		},

		/**
		 * Availability of modified client unit schemas.
		 * @protected
		 * @return {Boolean}
		 */
		hasModifiedClientUnitSchemas: function() {
			return BPMSoft.ClientUnitSchemaManager.hasModifiedItems();
		},

		/**
		 * Build changed configuration.
		 * @protected
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback context.
		 */
		buildChangedConfiguration: function(callback, scope) {
			this._updateSavingMask("BuildingConfiguration");
			BPMSoft.SchemaDesignerUtilities.buildChangedConfiguration(function(response) {
				this.processSaveWizardResponse(response, callback, scope);
			}, this);
		},

		/**
		 * Clear server cache.
		 * @protected
		 * @param {Function} callback The function will be called at the end.
		 * @param {Object} scope The context in which the callback function is called.
		 */
		clearCacheProcess: function(callback, scope) {
			this._updateSavingMask("ClearCacheMessage");
			this.mixins.WizardUtilities.clearConfigurationScript(function() {
				Ext.callback(callback, scope);
			}, this);
		},

		/**
		 * Save data.
		 * @protected
		 * @param {Function} callback The function will be called at the end.
		 * @param {Object} scope The context in which the callback function is called.
		 */
		saveDataProcess: function(callback, scope) {
			const entitySchemaDataList = this.entitySchemaDataList;
			if (Ext.isEmpty(entitySchemaDataList)) {
				Ext.callback(callback, scope);
			} else {
				this._updateSavingMask("ClearCacheMessage");
				BPMSoft.DataManager.save({entitySchemaNames: entitySchemaDataList}, function() {
					Ext.callback(callback, scope);
				}, this);
			}
		},

		/**
		 * Returns steps for save registration data.
		 * @protected
		 * @return {Array} Steps of registration data.
		 */
		getRegistrationDataSteps: function() {
			const steps = [
				{
					manager: BPMSoft.WidgetDashboardManager,
					processMessage: this.getLocalizableString("SchemaRegistrationMessage"),
					updateSchemaDataAction: true
				},
				{
					manager: BPMSoft.SysModuleEntityManager,
					processMessage: this.getLocalizableString("SchemaRegistrationMessage"),
					updateSchemaDataAction: true
				},
				{
					method: this.saveSysModuleEditManager,
					processMessage: this.getLocalizableString("PageRegistrationMessage")
				},
				{
					manager: BPMSoft.LookupManager,
					processMessage: this.getLocalizableString("SaveLookupMessage"),
					updateSchemaDataAction: true
				}
			];
			return steps;
		},

		/**
		 * Save SysModuleEntityManager items.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		saveSysModuleEditManager: function(callback, scope) {
			BPMSoft.chain(
				function(next) {
					if (!this.applicationStructureItem) {
						return next();
					}
					const itemWithoutAddMode = BPMSoft.SysModuleEditManager.findByFn(function(item) {
						const modes = (item.getMiniPageModes() || "").split(";");
						return item.getIsChanged() && !_.contains(modes, BPMSoft.ConfigurationEnums.CardOperation.ADD);
					}, this);
					if (itemWithoutAddMode) {
						this._fixHasMiniPageAddModeSetting(next, this);
					} else {
						next();
					}
				},
				function(next) {
					BPMSoft.SysModuleEditManager.saveAndUpdateSchemaData(this.packageUId, next, this);
				},
				function() {
					Ext.callback(callback, scope);
				}, this
			);
		},

		/**
		 * Save registration data.
		 * @protected
		 * @param {String} packageUId Id package for save.
		 * @param {Function} callback The function will be called at the end.
		 * @param {Object} scope The context in which the callback function is called.
		 */
		saveRegistrationDataProcess: function(packageUId, callback, scope) {
			const steps = this.getRegistrationDataSteps();
			const chain = [];
			BPMSoft.each(steps, function(step) {
				chain.push(function(next) {
					this.saveRegistrationDataStepProcess(next, step, packageUId);
				});
			}, this);
			chain.push(function() {
				callback.call(scope);
			});
			chain.push(this);
			BPMSoft.chain.apply(this, chain);
		},

		/**
		 * Method for execute registration data process step.
		 * @protected
		 * @param {Function} next The function will be called at the end.
		 * @param {Object} step Step config.
		 * @param {String} packageUId Id package for save.
		 */
		saveRegistrationDataStepProcess: function(next, step, packageUId) {
			this._updateSavingMask(null, step.processMessage);
			if (step.manager) {
				if (step.updateSchemaDataAction) {
					step.manager.saveAndUpdateSchemaData(packageUId, next, this);
				} else {
					step.manager.save(next, this);
				}
			} else if (step.method) {
				step.method.call(this, next, this);
			} else {
				next();
			}
		},

		/**
		 * Logs console ClientUnitSchemaManager modified items.
		 * @protected
		 */
		logClientUnitModifiedItems: function() {
			if (!this.applicationStructureItem) {
				return;
			}
			const modifiedItems = BPMSoft.ClientUnitSchemaManager.getModifiedItems();
			const code = this.applicationStructureItem.code;
			let modifiedItemNames = " ";
			if (modifiedItems.length > 0) {
				BPMSoft.each(modifiedItems, function(item) {
					modifiedItemNames += item.name + " ";
				}, this);
				this.log(Ext.String.format("LogBeforeSaveClientUnitSchema({0}) - ModifiedItems[{1}];",
					code, modifiedItemNames));
			} else {
				this.log(Ext.String.format("LogBeforeSaveClientUnitSchema({0}) - " +
					"modified items are not exist.", code));
			}
		},

		/**
		 * Saves business rules.
		 * @protected
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback scope.
		 */
		saveBusinessRuleProcess: function(callback, scope) {
			this._updateSavingMask("SavingBusinessRuleMessage");
			BPMSoft.BusinessRuleSchemaManager.saveToClientUnitSchemaManager(function(response) {
				this.processSaveWizardResponse(response, callback, scope);
			}, this);
		},

		/**
		 * Save wizard.
		 * @protected
		 * @param {Function} [callback] The function will be called at the end
		 * @param {Object} [scope] The context in which the callback function is called
		 */
		saveWizard: function(callback, scope) {
			let hasModifiedClientUnitSchemas, hasModifiedEntitySchemas;
			this._showSavingMask();
			BPMSoft.chain(
				this.saveBusinessRuleProcess,
				function(next) {
					this.checkModifiedSchemasOnForeignLock(function(schemas) {
						if (schemas && schemas.length > 0) {
							this.isSavingWizard = false;
							const errorMessage = this.getLockedElementsWarningMessage(schemas);
							const gmtData = this._getGTMSavedFailedData(errorMessage);
							this.sendGoogleTagManagerData(gmtData);
							BPMSoft.showInformation(errorMessage);
							Ext.callback(callback, scope);
						} else {
							next();
						}
					}, this);
				},
				function(next) {
					hasModifiedClientUnitSchemas = this.hasModifiedClientUnitSchemas();
					hasModifiedEntitySchemas = this.hasModifiedEntitySchemas();
					this.logClientUnitModifiedItems();
					this.saveClientUnitSchemesProcess(function(err) {
						if (BPMSoft.angularDesignerObj) {
							this._showSavingMask('Билд ангуляр приложения');
							this._updateSavingMask(null, "Билд ангуляр приложения");
							this.processAngularWizardData(next);

						} else {
							next();
						}
							
					}, this);
				},
				this.saveEntitySchemesProcess,
				function(next) {
					const needGenerateStaticContent = BPMSoft.useStaticFileContent && hasModifiedClientUnitSchemas;
					if (needGenerateStaticContent || hasModifiedEntitySchemas) {
						this.buildChangedConfiguration(next, this);
					} else {
						next();
					}
				},
				this.saveRegistrationDataProcess.bind(this, this.packageUId),
				this.clearCacheProcess,
				this.saveDataProcess,
				this.onManagersSave,
				this.buildOData,
				function() {
					this.sendGoogleTagManagerData(this._getGTMSavedSuccessfullyData());
					this.isSavingWizard = false;
					this._hideSavingMask();
					this.onAfterSaveWizard();
					const caption = this.getCaption();
					this.setTitle(caption);
					Ext.callback(callback, scope);
				}, this
			);
		},

		/**
		 * Builds ODataEntities.
		 * @protected
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback scope.
		 */
		buildOData: function(callback, scope) {
			callback.call(scope);
		},

		/**
		 * Handler for after wizard was saved.
		 * @protected
		 */
		onAfterSaveWizard: function() {
			const silentMode = this.saveWizardConfig && this.saveWizardConfig.silentMode;
			if (silentMode !== true) {
				const message = this.getLocalizableString("SavingSuccessMessage");
				BPMSoft.showInformation(message);
			}
			this.sandbox.publish("OnAfterSave", null, [this.getModuleIdByStepName(this.currentStep)]);
		},

		processAngularWizardData: function(next) {
			// BPMSoft.angularDesignerObj.pageSchemaUId = '8d496371-fa49-40c8-833a-a346dab80afa';
			this.callServiceMethod(BPMSoft.angularDesignerObj, function(err, response) {
				if (err) {
					return this.processSaveWizardResponse(err, next, this);
				}
				try {
					var responseObject = JSON.parse(response.responseText);
					if (responseObject.success) {
						console.log('Server response indicates success:', responseObject);
						BPMSoft.angularDesignerObj = null;
					} else {
						return this.processSaveWizardResponse(responseObject, next, this);
					}
				} catch (e) {
					console.error('Error parsing server response:', e);
					return this.processSaveWizardResponse(e, next, this);
				} finally {
					MaskHelper.hideBodyMask();
				}
				next();
			}.bind(this));
		},
		
		

		callServiceMethod: function(dataSend, callback) {
			var ajaxProvider = BPMSoft.AjaxProvider;
			var data = dataSend || {};
			var requestUrl = BPMSoft.workspaceBaseUrl + "/DataService/json/SyncReply/AngularDesignerRequest";
			MaskHelper.ShowBodyMask();
			var request = ajaxProvider.request({
				url: requestUrl,
				headers: {
					"Accept": "application/json",
					"Content-Type": "application/json"
				},
				method: "POST",
				timeout: 6000000,
				jsonData: data,
				callback: function(options, success, response) {
					if (success) {
						callback(null, response);
					} else {
						callback(response.statusText || "Request failed");
					}
				},
				scope: this
			});
			request.timeout = BPMSoft.BaseServiceProvider.getRequestTimeout(request);
			return request;
		},

		handleErrors: function(responseObject) {
			MaskHelper.hideBodyMask();
			this._hideSavingMask();
			var messages = [];
		
			// Проверяем ошибки в buildResult
			if (responseObject.angularBuildResultModels) {
				responseObject.angularBuildResultModels.forEach(function(model, index) {
					if (model.buildResult.hasErrors && model.buildResult.errors.length) {
						var errorsWithIndex = model.buildResult.errors.map(function(error, errorIndex) {
							return (index + 1) + "." + (errorIndex + 1) + ". " + error;
						}).join("\n\n");
						messages = messages.concat(errorsWithIndex);
					}
				});
			}
		
			// Проверяем ошибки в changesWrappersResultModel, если он не null
			if (responseObject.changesWrappersResultModel && responseObject.changesWrappersResultModel.hasErrors) {
				responseObject.changesWrappersResultModel.errors.forEach(function(error, index) {
					messages.push((messages.length + 1) + ". " + error.message);
				});
			}
		
			// Проверяем errorInfo
			if (responseObject.errorInfo) {
				messages.push((messages.length + 1) + ". " + (responseObject.errorInfo.message || "Произошла ошибка на сервере"));
			}
		
			if (messages.length) {
				BPMSoft.utils.showInformation(messages.join("\n\n"), null, null, {buttons: ["ok"]});
			} else if (!responseObject.success) {
				// Если нет сообщений об ошибках, но операция неуспешна
				BPMSoft.utils.showInformation("Операция не выполнена успешно, но конкретные ошибки не предоставлены.", null, null, {buttons: ["ok"]});
			}
			console.log(messages)
			console.log('messages')
		},

		/**
		 * Sets history state for first step.
		 * @protected
		 * @param {Object} state State.
		 */
		setHistoryStateToFirstStep: function(state) {
			if (state && state.hash) {
				const applicationStructureItemId = state.hash.entityName;
				const replacedToken = {
					hash: applicationStructureItemId
				};
				this.sandbox.publish("ReplaceHistoryState", replacedToken);
			}
		},

		/**
		 * Sets window title.
		 * @protected
		 * @param {String} caption Caption
		 */
		setTitle: function(caption) {
			document.title = caption;
		},

		/**
		 * @inheritdoc BPMSoft.BaseViewModule#render
		 * @override
		 */
		render: function() {
			this.callParent(arguments);
			this._addHotkeys();
		},

		/**
		 * @inheritdoc BPMSoft.BaseWizardModule#destroy
		 * @override
		 */
		destroy: function() {
			this._removeHotkeys();
			this.callParent(arguments);
		},

		/**
		 * Handler for key-down event.
		 * @protected
		 * @param {Object} event Event object.
		 * @return {Boolean}
		 */
		onKeyDown: function(event) {
			if (event.ctrlKey && event.keyCode === event.S) {
				event.preventDefault();
				if (!this.isSavingWizard) {
					if (event.target) {
						event.target.blur();
					}
					this.onSaveWizard();
				}
				return false;
			}
		},

		//endregion

		//region Methods: Public

		/**
		 * @inheritdoc BPMSoft.BaseViewModule#init
		 * @override
		 */
		init: function(callback, scope) {
			BPMSoft.Mask.show({timeout: 0});
			this.callParent([function() {
				this._initializeWizard().then(function() {
					Ext.callback(callback, scope);
				}).catch(function(message) {
					this.showWizardError(message);
				}.bind(this));
			}, this]);
		},

		//endregion

		//region Methods: Deprecated

		/**
		 * @deprecated
		 */
		getSaveMessage: function() {
			return this.getLocalizableString("SaveMessage");
		},

		/**
		 * @deprecated
		 */
		confirmSaveWizard: function() {
			const message = this.getSaveMessage();
			const handler = this.onValidationMessageResponse;
			BPMSoft.showConfirmation(message, handler, ["yes", "no"], this, {defaultButton: 0});
		},

		/**
		 * @deprecated
		 */
		onValidationMessageResponse: function(buttonCode) {
			if (buttonCode === "yes") {
				this.publishSave();
			} else {
				this.isSavingWizard = false;
			}
		},

		/**
		 * @deprecated
		 */
		isStepName: function(name) {
			const steps = this.getSteps();
			let result = false;
			BPMSoft.each(steps, function(step) {
				if (step.name === name) {
					result = true;
					return false;
				}
			}, this);
			return result;
		},

		/**
		 * @deprecated
		 */
		getActiveStepSysModuleEditItem: function(sysModuleEntityManagerItem, callback, scope) {
			BPMSoft.chain(
				function(next) {
					this.getActiveSysModuleEditManagerItems(sysModuleEntityManagerItem, next, this);
				},
				function(next, sysModuleEditManagerItems) {
					const currentStep = this.getStepConfigByName(this.operationType || this.currentStep);
					let editManagerItem = null;
					const currentPageId = currentStep.id;
					if (currentPageId) {
						editManagerItem = sysModuleEditManagerItems.get(currentPageId);
					}
					if (!editManagerItem) {
						editManagerItem = sysModuleEditManagerItems.getByIndex(0);
					}
					callback.call(scope, editManagerItem);
				},
				this
			);
		},

		/**
		 * @deprecated
		 */
		preparePageDesignerClientUnitSchema: function(schema, entitySchemaName, callback, scope) {
			BPMSoft.ClientUnitSchemaManager.prepareDesignPageSchema(schema, entitySchemaName, callback, scope);
		},

		/**
		 * @deprecated
		 */
		hasModifiedSchemas: function() {
			return this.hasModifiedEntitySchemas() || this.hasModifiedClientUnitSchemas();
		}

		//endregion

	});

	return BPMSoft.ApplicationStructureItemWizard;
});
