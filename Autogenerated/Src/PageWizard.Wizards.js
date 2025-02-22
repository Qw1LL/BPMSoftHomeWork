﻿define("PageWizard", [
	"PageWizardResources",
	"ProcessModuleUtilities",
	"ApplicationStructureItemWizard",
	"SectionManager",
	"DetailManager",
	"WizardUtilities",
	"PackageUtilities",
	"DesignTimeEnums",
	"ProcessEntryPointUtilities",
	"PageDesignerHeaderModule",
	"SourceCodeDesigner",
	"SspPageDetailsManager"
], function(resources) {

	/**
	 * Class of visual module of representation for the page wizard
	 */
	Ext.define("BPMSoft.configuration.PageWizard", {
		extend: "BPMSoft.configuration.ApplicationStructureItemWizard",
		alternateClassName: "BPMSoft.PageWizard",

		// region Properties: Protected

		/**
		 * Operation type
		 * @protected
		 * @type {String}
		 */
		operationType: null,

		/**
		 * Page manager item.
		 * @protected
		 * @type {Object}
		 */
		pageItem: null,

		/**
		 * @inheritdoc BPMSoft.BaseViewModule#diff
		 * @override
		 */
		diff: [
			{
				"operation": "merge",
				"name": "wizardContainer",
				"values": {
					"wrapClass": ["wizard-container", "page-wizard"]
				}
			},
			{
				"operation": "merge",
				"name": "wizardHeader",
				"values": {
					"moduleName": "PageDesignerHeaderModule"
				}
			},
			{
				"operation": "insert",
				"name": "WizardMask",
				"parentName": "wizardContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {
						"wrapClassName": ["wizard-mask-container"]
					},
					"items": []
				}
			}
		],

		// endregion

		// region Methods: Private

		/**
		 * @private
		 */
		_createAndDefinePageItem: function(config, callback, scope) {
			var schemaType = BPMSoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA;
			BPMSoft.chain(
				function(next) {
					BPMSoft.ClientUnitSchemaManager.getUniqueNameAndCaption({
						captionPrefix: this.getLocalizableString("NewPageWizardCaption")
					}, next, this);
				},
				function(next, name, caption, errorMessage) {
					if (errorMessage) {
						BPMSoft.showErrorMessage(errorMessage, function() {
							window.close();
						}, this);
						return;
					}
					var schemaConfig = {
						uId: BPMSoft.generateGUID(),
						packageUId: this.packageUId,
						parentSchemaUId: this._getTemplatePageIdFromHistoryState(),
						schemaType: schemaType,
						caption: caption,
						name: name
					};
					BPMSoft.ClientUnitSchemaManager.createSchemaInstance(schemaConfig, next, this);
				},
				function(next, pageSchema, pageItem) {
					pageSchema.setDefaultSchemaBody(schemaType, {"entitySchemaName": ""});
					pageSchema.define(function() {
						Ext.callback(callback, scope, [pageItem]);
					}, this);
				}, this
			);
		},

		/**
		 * @private
		 * @param {String} step Wizard step name.
		 * @param {String} pageItemId Page item identifier.
		 */
		_redirectToStep: function(step, pageItemId) {
			this.sandbox.publish("ReplaceHistoryState", {
				hash: BPMSoft.combinePath(step, pageItemId),
				state: {
					moduleId: this.getModuleIdByStepName(step)
				}
			});
		},

		/**
		 * @private
		 */
		_initDetailManager: function(callback) {
			BPMSoft.DetailManager.initialize(callback, this);
		},

		/**
		 * @private
		 */
		_initSspPageDetailsManager: function(callback) {
			BPMSoft.SspPageDetailsManager.initialize(callback, this);
		},

		/**
		 * @private
		 */
		_setPageItem: function(id) {
			var pageItem = BPMSoft.ClientUnitSchemaManager.findItem(id);
			this.pageItem = pageItem;
		},

		/**
		 * @protected
		 * @param {Object} event Event object.
		 * @return {Boolean}
		 */
		onKeyDown: function(event) {
			this.callParent(arguments);
			if (event.ctrlKey && event.keyCode === event.M) {
				event.preventDefault();
				BPMSoft.BaseSchemaDesignerUtilities.openMetaData(this.pageItem.instance);
				return false;
			}
			if (event.ctrlKey && event.keyCode === event.K) {
				event.preventDefault();
				BPMSoft.ProcessModuleUtilities.showClientUnitSchemaDesigner(this.pageItem.instance);
				return false;
			}
		},

		/**
		 * @private
		 */
		_getTemplatePageIdFromHistoryState: function() {
			var state = this.sandbox.publish("GetHistoryState") || {};
			var stateHash = state.hash || {};
			return stateHash.entityName;
		},

		/**
		 * @private
		 */
		_getPackageUId: function() {
			const pagePackageUId = this.pageItem && this.pageItem.packageUId;
			return pagePackageUId || this.packageUId;
		},

		// endregion

		// region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.ApplicationStructureItemWizard#getInitChain
		 * @override
		 */
		getInitChain: function() {
			var chain = this.callParent(arguments);
			chain.push(this._initDetailManager);
			chain.push(this._initSspPageDetailsManager);
			return chain;
		},

		/**
		 * @inheritdoc BPMSoft.ApplicationStructureItemWizard#getEntitySchemasToCheck
		 * @override
		 */
		getEntitySchemasToCheck: function() {
			return this.callParent(arguments)
				.then(function(schemas) {
					return new Promise(function(resolve) {
						schemas.push(
							BPMSoft.DesignTimeEnums.BaseSchemaUId.BASE_LOOKUP
						);
						resolve(schemas);
					});
				});
		},

		/**
		 * @inheritdoc BPMSoft.ApplicationStructureItemWizard#getClientUnitSchemasToCheck
		 * @override
		 */
		getClientUnitSchemasToCheck: function() {
			return this.callParent(arguments)
				.then(function(schemas) {
					return new Promise(function(resolve) {
						schemas.push(
							BPMSoft.DesignTimeEnums.BaseSchemaUId.BASE_PAGE_PROCESS_TEMPLATE
						);
						resolve(schemas);
					});
				});
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
			var parentSteps = this.callParent(arguments);
			var steps = [
				{
					name: "PageDesigner",
					caption: this.getLocalizableString("PageDesignerStepCaption"),
					moduleName: this.getPageDesignerModuleName()
				},
				{
					name: "BusinessRules",
					caption: this.getLocalizableString("BusinessRulesStepCaption"),
					moduleName: "ConfigurationModuleV2",
					schemaName: "BusinessRuleSection"
				}
			];
			if (BPMSoft.Features.getIsEnabled("PageDesignerSourceCode")) {
				steps.push({
					name: "SourceCode",
					caption: this.getLocalizableString("SourceCodeStepCaption"),
					moduleName: "ConfigurationModuleV2",
					schemaName: "SourceCodeDesigner"
				});
			}
			steps = steps.concat(parentSteps);
			return steps.concat(this.pagesSteps);
		},

		/**
		 * @inheritdoc BPMSoft.ApplicationStructureItemWizard#preparePageDesignerConfig
		 * @override
		 */
		preparePageDesignerConfig: function(callback, scope) {
			const result = {};
			BPMSoft.chain(
				function(next) {
					BPMSoft.ClientUnitSchemaManager.designPageSchema({
						schemaUId: this.pageItem.uId,
						packageUId: this.packageUId
					}, next, this);
				},
				function(next, clientUnitSchema) {
					result.clientUnitSchema = clientUnitSchema;
					if (this.applicationStructureItem) {
						this.getSysModuleEntityManagerItem(next, this);
					} else {
						callback.call(scope, result);
					}
				},
				function(next, moduleEntity) {
					const config = {
						packageUId: this.packageUId,
						schemaUId: moduleEntity.getEntitySchemaUId()
					};
					BPMSoft.EntitySchemaManager.forceGetPackageSchema(config, next, this);
				},
				function(next, entitySchema) {
					this.preparePageDesignerEntitySchema(entitySchema);
					result.entitySchema = entitySchema;
					Ext.callback(callback, scope, [result]);
				}, this
			);
		},

		/**
		 * Opens new page wizard.
		 * @protected
		 */
		openNewPageWizard: function() {
			this.sandbox.publish("ReplaceHistoryState", {hash: "PageTemplateModule"});
		},

		/**
		 * @inheritdoc BPMSoft.ApplicationStructureItemWizard#setStep
		 * @override
		 */
		setStep: function(state, callback, scope) {
			if (!state) {
				Ext.callback(callback, scope);
				return;
			}
			this.checkRequirements().then(function() {
				const moduleName = state.hash.moduleName;
				const entityName = state.hash.entityName || "";
				const operationType = state.hash.operationType;
				let id;
				if (operationType) {
					const moduleId = entityName.toLowerCase();
					this.applicationStructureItemId = moduleId;
					this.applicationStructureItem = this.applicationStructureManager.findItem(moduleId);
					id = operationType.toLowerCase();
				} else {
					id = entityName.toLowerCase();
				}
				if (moduleName && this.isStepName(moduleName) && BPMSoft.isGUID(id)) {
					if (!BPMSoft.ClientUnitSchemaManager.contains(id)) {
						this.warning(Ext.String.format("{0}: {1} ({2})", "ClientUnitSchemaManager",
							BPMSoft.Resources.Exception.ItemNotFoundException, id));
						this.openNewPageWizard();
						return;
					}
					this.currentStep = moduleName;
					this.operationType = null;
					this._setPageItem(id);
					const caption = this.getCaption();
					this.updateHeader({
						currentStep: this.currentStep,
						caption: caption,
						pageUId: this.pageItem.uId
					});
				}
				Ext.callback(callback, scope);
			}.bind(this));
		},

		/**
		 * @inheritdoc BPMSoft.ApplicationStructureItemWizard#onGetModuleConfig
		 * @override
		 */
		onGetModuleConfig: function() {
			if (this.currentStep === "PageDesigner" || this.currentStep === "SourceCode") {
				this.preparePageDesignerConfig(this.publishModuleConfig, this);
			}
			if (this.currentStep === "BusinessRules") {
				const config = {
					packageUId: this.packageUId,
					clientUnitSchemaUId: this.pageItem.uId
				};
				if (this.applicationStructureItem) {
					config.applicationStructureItem = this.applicationStructureItem;
				}
				this.publishModuleConfig(config);
			}
		},

		/**
		 * @inheritdoc BPMSoft.ApplicationStructureItemWizard#getDefaultStepName
		 * @override
		 */
		getDefaultStepName: function() {
			return "PageDesigner";
		},

		/**
		 * @inheritdoc BPMSoft.ApplicationStructureItemWizard#getRegistrationDataSteps
		 * @override
		 */
		getRegistrationDataSteps: function() {
			var steps = this.callParent(arguments);
			steps.push({
				manager: BPMSoft.DetailManager,
				processMessage: this.getLocalizableString("DetailRegistrationMessage"),
				updateSchemaDataAction: true
			});
			return steps;
		},

		/**
		 * @inheritdoc BPMSoft.ApplicationStructureItemWizard#getCaption
		 * @override
		 */
		getCaption: function() {
			var pageCaption = this.pageItem && this.pageItem.getCaption();
			var wizardCaption = pageCaption || "";
			var stepCaption = this.generateStepCaption();
			return Ext.String.format("{0}: {1}", wizardCaption, stepCaption);
		},

		/**
		 * @inheritdoc BPMSoft.ApplicationStructureItemWizard#generateStepCaption
		 * @override
		 */
		generateStepCaption: function() {
			var currentStep = this.operationType || this.currentStep;
			var currentStepConfig = this.getStepConfigByName(currentStep);
			var caption = "";
			switch (currentStep) {
				case "PageDesigner":
					caption = this.getPageDesignerStepCaption(currentStepConfig);
					break;
				case "BusinessRules":
					caption = this.getLocalizableString("BusinessRulesStepCaption");
					break;
				case "SourceCode":
					caption = this.getLocalizableString("SourceCodeStepCaption");
					break;
				default:
					break;
			}
			return caption;
		},

		/**
		 * @inheritdoc BPMSoft.BaseWizardModule#onStepChanged
		 * @override
		 */
		onStepChanged: function(step) {
			this.currentStep = step;
			this.operationType = null;
			var pathList = [this.currentStep, this.pageItem.uId];
			var newHash = this.BPMSoft.combinePath.apply(this, pathList);
			this.sandbox.publish("PushHistoryState", {
				hash: newHash,
				state: {
					moduleId: this.getModuleIdByStepName(step)
				}
			});
		},

		/**
		 * @inheritdoc BPMSoft.ApplicationStructureItemWizard#modifyUrl
		 * @override
		 */
		modifyUrl: function() {
			this._createAndDefinePageItem({}, function(newPageItem) {
				var currentStep = this.getStepFromHistoryState();
				this._redirectToStep(currentStep, newPageItem.uId);
			}, this);
		},

		/**
		 * @inheritdoc BPMSoft.ApplicationStructureItemWizard#processSaveWizardResponse
		 * @override
		 */
		processSaveWizardResponse: function(response, callback, scope) {
			if (response && response.success) {
				callback.call(scope, response);
			} else {
				var failedItem = response.failedItem;
				if (failedItem instanceof BPMSoft.ClientUnitSchemaManagerItem) {
					failedItem.logInstanceBody();
				}
				var errorMessage = failedItem
					? this.getSaveSchemaManagerErrorMessage(response)
					: response.errorInfo.toString();
				BPMSoft.showErrorMessage(errorMessage);
			}
		},

		/**
		 * @inheritdoc BPMSoft.BaseWizardModule#getWizardHeaderId
		 * @override
		 */
		getWizardHeaderId: function() {
			return "ViewModule_PageDesignerHeaderModule";
		},

		/**
		 * @inheritdoc BPMSoft.ApplicationStructureItemWizard#onGetConfig
		 * @override
		 */
		onGetConfig: function() {
			var config = this.callParent();
			return Ext.apply(config, {
				pageUId: this.pageItem && this.pageItem.uId,
				pageName: this.pageItem && this.pageItem.name,
				pagePackageUId: this._getPackageUId()
			});
		},

		/**
		 * Return module name for PageDesigner step.
		 * @protected
		 * @return {String}
		 */
		getPageDesignerModuleName: function() {
			return "PageDesignerModule";
		}

		// endregion

	});

	return BPMSoft.PageWizard;
});
