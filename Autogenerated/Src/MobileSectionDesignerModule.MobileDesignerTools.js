/**
 * @class MobileSectionDesignerModule
 * @public
 * Mobile section designer module.
 */
define("MobileSectionDesignerModule", ["BPMSoft", "MobileSectionDesignerModuleResources",
		"ProcessModuleUtilities", "SectionDesignerUtils", "LookupUtilities", "MobileDesignerUtils", "LocalizableHelper",
		"MobileSectionDesignerEnums", "SecurityUtilities", "EntityStructureHelperMixin", "MobileRecordDesignerSettings",
		"MobileGridDesignerSettings", "MobileActionsDesignerSettings", "css!MobileDesignerUtils", "ImageView"],
	function(BPMSoft, resources, ProcessModuleUtilities, SectionDesignerUtils, LookupUtilities, MobileDesignerUtils,
			LocalizableHelper) {

		/**
		 * @private
		 */
		var maxSaveAttemptsCount = 10;

		/**
		 * @private
		 * List of models that must be configurable only by code.
		 */
		var excludedModels = [];

		/**
		 * @private
		 */
		var newSections = {};

		/**
		 * @private
		 */
		var initialSections = {};

		return {
			attributes: {

				GridData: {
					type: BPMSoft.ViewModelColumnType.CALCULATED_COLUMN,
					dataValueType: BPMSoft.DataValueType.COLLECTION
				},

				ActiveRow: {
					type: BPMSoft.ViewModelColumnType.CALCULATED_COLUMN,
					dataValueType: BPMSoft.DataValueType.INTEGER
				},

				Workplace: {
					type: BPMSoft.ViewModelColumnType.CALCULATED_COLUMN,
					dataValueType: BPMSoft.DataValueType.TEXT
				},

				WorkplaceTypeId: {
					type: BPMSoft.ViewModelColumnType.CALCULATED_COLUMN,
					dataValueType: BPMSoft.DataValueType.TEXT
				},

				/**
				 * Name of sysOperation which will be used to check the access rights to section.
				 */
				SecurityOperationName: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					value: "CanManageMobileApplication"
				}

			},
			messages: {

				"PushHistoryState": {
					mode: BPMSoft.MessageMode.BROADCAST,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				"OnDesignerSaved": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				"LookupInfo": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				"BackHistoryState": {
					"mode": BPMSoft.MessageMode.BROADCAST,
					"direction": BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				"ResultSelectedRows": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				"GetDesignerManifest": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				"ChangeHeaderCaption": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}

			},
			mixins: {

				EntityStructureHelper: "BPMSoft.EntityStructureHelperMixin",

				SecurityUtilitiesMixin: "BPMSoft.SecurityUtilitiesMixin"

			},
			methods: {

				/**
				 * @private
				 */
				saveAttemptsNumber: null,

				/**
				 * @private
				 */
				saveSchemasFromManifest: function(maskId) {
					var manifest = MobileDesignerUtils.manifest;
					manifest.resolveManifest({
						callback: function() {
							var currentManifest = manifest.getCurrentManifest();
							var currentManifestLocalizableStrings = manifest.getCurrentManifestLocalizableStrings();
							MobileDesignerUtils.schemaManager.updateCurrentPackageManifest(
								JSON.stringify(currentManifest, null, "\t"), currentManifestLocalizableStrings);
							this.saveSchemas(maskId);
						},
						scope: this
					});
				},

				/**
				 * @private
				 */
				saveSchemas: function(maskId) {
					this.saveAttemptsNumber++;
					MobileDesignerUtils.schemaManager.saveSchemas({
						callback: function(managerSaveResponse) {
							this.mobileDesignerSaveSchemasCallback(maskId, managerSaveResponse);
						},
						scope: this
					});
				},

				/**
				 * @private
				 */
				getCurrentPackageUId: function() {
					var storage = BPMSoft.DomainCache;
					return storage.getItem("SectionDesigner_CurrentPackageUId");
				},

				/**
				 * @private
				 */
				mobileDesignerSaveSchemasCallback: function(maskId, managerSaveResponse) {
					var infoMessage = resources.localizableStrings.SaveCompletionInformationMessage;
					var callbackFn = function(callbackMaskId, callbackInfoMessage) {
						BPMSoft.Mask.hide(callbackMaskId);
						BPMSoft.showInformation(callbackInfoMessage);
						newSections = {};
					}.bind(this);
					if (managerSaveResponse && !managerSaveResponse.success) {
						infoMessage = resources.localizableStrings.SaveErrorInformationMessage;
						if (managerSaveResponse.errorInfo) {
							this.log(managerSaveResponse.errorInfo, BPMSoft.LogMessageType.ERROR);
							if (this.saveAttemptsNumber < maxSaveAttemptsCount &&
								managerSaveResponse.errorInfo.errorCode === "SqlException") {
								this.saveSchemas(maskId);
								return;
							}
							infoMessage = Ext.String.format("{0}:\n'{1}'", infoMessage,
								managerSaveResponse.errorInfo.message);
							callbackFn(maskId, infoMessage);
						}
					} else {
						BPMSoft.SchemaDesignerUtilities.forceBuildWorkspace(function() {
							callbackFn(maskId, infoMessage);
						}, this);
					}
				},

				/**
				 * @private
				 */
				executeProcess: function(sysProcessName, callback) {
					if (Ext.isFunction(callback)) {
						ProcessModuleUtilities.responseCallback = callback;
					}
					ProcessModuleUtilities.executeProcess({
						sysProcessName: sysProcessName
					});
				},

				/**
				 * @private
				 */
				updateManifestModulesPosition: function(sectionViewModelCollection) {
					var manifest = MobileDesignerUtils.manifest;
					sectionViewModelCollection.each(function(item) {
						manifest.changeModulePosition(item.get("Model"), item.get("Position"));
					});
				},

				/**
				 * @private
				 */
				onDefaultSectionsBatchQueryExecuted: function(response, callback) {
					if (!response || !response.success) {
						Ext.callback(callback, this);
						return;
					}
					var queryResults = response.queryResults;
					var sections = [];
					for (var i = 0, ln = queryResults.length; i < ln; i++) {
						var queryResult = queryResults[i];
						var sectionResult = queryResult.rows[0];
						sections.push({
							entitySchemaName: BPMSoft.MobileSectionDesignerEnums.DefaultManifestModules[i],
							title: sectionResult.Caption,
							position: i
						});
					}
					this.addSections({
						sections: sections,
						callback: callback
					});
				},

				/**
				 * @private
				 */
				getDefaultSectionsSelectQuery: function(entityName) {
					var select = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "SysModule"
					});
					select.addColumn("Caption");
					select.filters.addItem(BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
						"[SysModuleEntity:Id:SysModuleEntity].[SysSchema:UId:SysEntitySchemaUId].Name",
						entityName));
					return select;
				},

				/**
				 * @private
				 */
				addSection: function(config) {
					this.addSections({
						sections: [
							{
								entitySchemaName: config.schemaName,
								title: config.title,
								position: config.position
							}
						],
						callback: function() {
							this.loadGridData();
							Ext.callback(config.callback, config.scope);
						}
					});
				},

				/**
				 * ####### ######## ######## ## ######### # #########.
				 * @param {String} modelName ### ###### #######.
				 * @param {String} pageName ### ######## ########.
				 * @private
				 */
				removeSettingsPage: function(modelName, pageName) {
					MobileDesignerUtils.schemaManager.removeSchema({
						schemaName: pageName,
						callback: function() {
							MobileDesignerUtils.manifest.removeSettingsPage(modelName, pageName);
						}
					});
				},

				/**
				 * ########## ####### ####, ####### ## ####### ##### ####### ## ########### ######### # #########.
				 * @private
				 * @param {String} modelName ### ###### #######.
				 * @returns {Boolean} ####### ####, ####### ## ####### ##### ####### ## ########### ######### # #########.
				 */
				shouldRemoveSectionSchemas: function(modelName) {
					return (newSections[modelName] === true &&
						(!initialSections[modelName] || MobileDesignerUtils.schemaManager.manifestSchemaIsNew));
				},

				/**
				 * ############# ######### #######.
				 * @protected
				 * @virtual
				 * @param {Function} callback ####### ######### ######.
				 * @param {Object} scope ######## ####### ######### ######.
				 */
				init: function(callback, scope) {
					this.subscribeSandboxEvents();
					this.updateHeaderCaption();
					this.showBodyMask();
					this.callParent([
						function() {
							this.checkAvailability(function() {
								var nextcallback = function() {
									var sectionViewModelCollection = this.createSectionViewModelCollection([]);
									this.set("GridData", sectionViewModelCollection);
									this.initializeMobileDesignerUtils(function() {
										newSections = {};
										initialSections = {};
										var initialModuleList = BPMSoft.MobileDesignerUtils.manifest.getModuleList();
										for (var i = 0, ln = initialModuleList.length; i < ln; i++) {
											var moduleConfig = initialModuleList[i];
											initialSections[moduleConfig.Model] = true;
										}
										this.createDefaultSectionsIfNotExist(function() {
											this.loadGridData();
											this.hideBodyMask();
											callback.call(scope);
										});
									});
								}.bind(this);
								if (this.getCurrentPackageUId()) {
									nextcallback();
								} else {
									SectionDesignerUtils.getCurrentPackageUId(nextcallback, this);
								}
							}, this);
						},
						this
					]);
				},

				/**
				 * ######### ######## ## #########, ####### ########### ########.
				 * @protected
				 * @virtual
				 */
				subscribeSandboxEvents: function() {
					this.sandbox.subscribe("OnDesignerSaved", this.onDesignerSaved, this);
					this.sandbox.subscribe("BackHistoryState", this.onBackHistoryState, this);
					this.sandbox.subscribe("GetDesignerManifest", function() {
						return MobileDesignerUtils.manifest;
					}, this);
				},

				/**
				 * ############# #########.
				 * @protected
				 * @virtual
				 */
				updateHeaderCaption: function() {
					var caption = this.get("Resources.Strings.DesignerCaption");
					this.sandbox.publish("ChangeHeaderCaption", {
						caption: caption,
						moduleName: this.name
					});
				},

				/**
				 * ######### ###### #######.
				 * @protected
				 * @virtual
				 */
				loadGridData: function() {
					var sectionList = MobileDesignerUtils.manifest.getModuleList();
					for (var i = (sectionList.length - 1); i >= 0; i--) {
						var sectionConfig = sectionList[i];
						if (excludedModels.indexOf(sectionConfig.Model) >= 0) {
							sectionList.splice(i, 1);
						}
					}
					var sectionViewModelCollection = this.createSectionViewModelCollection(sectionList);
					var gridData = this.get("GridData");
					gridData.clear();
					gridData.loadAll(sectionViewModelCollection);
				},

				/**
				 * ############## ##### ###### ########## #########.
				 * @protected
				 * @virtual
				 * @param {Function} callback ####### ######### ######.
				 */
				initializeMobileDesignerUtils: function(callback) {
					var packageUId = this.getCurrentPackageUId();
					MobileDesignerUtils.initialize({
						packageUId: packageUId,
						workplaceCode: this.get("Workplace"),
						workplaceTypeId: this.get("WorkplaceTypeId"),
						callback: callback,
						scope: this
					});
				},

				/**
				 * ####### ######### ########.
				 * @protected
				 * @virtual
				 * @param {Object} sectionList ###### ########.
				 * @returns {BPMSoft.BaseViewModelCollection} ######### ########.
				 */
				createSectionViewModelCollection: function(sectionList) {
					var viewModelCollection = Ext.create("BPMSoft.BaseViewModelCollection");
					for (var i = 0, ln = sectionList.length; i < ln; i++) {
						var sectionConfig = sectionList[i];
						var viewModel = this.createSectionViewModel(sectionConfig);
						var key = viewModel.get(viewModel.primaryColumnName);
						viewModelCollection.add(key, viewModel);
					}
					return viewModelCollection;
				},

				/**
				 * ####### ###### ############# #######.
				 * @protected
				 * @virtual
				 * @param {Object} sectionConfig ######## ####### #######.
				 * @returns {BPMSoft.BaseViewModel} ###### ############# #######.
				 */
				createSectionViewModel: function(sectionConfig) {
					var viewModelConfig = {
						rowConfig: {
							Title: {
								columnPath: "Title",
								dataValueType: BPMSoft.DataValueType.TEXT
							},
							Model: {
								columnPath: "Model",
								dataValueType: BPMSoft.DataValueType.TEXT
							},
							Position: {
								columnPath: "Position",
								dataValueType: BPMSoft.DataValueType.NUMBER
							}
						},
						primaryColumnName: "Model",
						primaryDisplayColumnName: "Title",
						values: sectionConfig,
						methods: {
							isModuleEditable: function() {
								var model = this.get("Model");
								var index = BPMSoft.MobileSectionDesignerEnums.NotConfigurableModules.indexOf(model);
								return index === -1;
							}
						}
					};
					return Ext.create("BPMSoft.BaseViewModel", viewModelConfig);
				},

				/**
				 * ############ ####### ## ####### ########## ###### #######.
				 * @protected
				 * @virtual
				 */
				onAddSectionButtonClick: function() {
					var filterGroup = this.BPMSoft.createFilterGroup();
					filterGroup.logicalOperation = this.BPMSoft.LogicalOperatorType.OR;
					var filters = this.BPMSoft.createFilterGroup();
					var gridData = this.get("GridData");
					var nonStandardModuleCodes = [];
					Ext.Object.each(BPMSoft.MobileSectionDesignerEnums.ModuleWithoutSysModuleEntity,
						function(name, value) {
							nonStandardModuleCodes.push(value);
						}
					);
					var excludedStandardModules = [];
					var excludedNonStandardModules = [];
					gridData.each(function(sectionViewModel) {
						var modelName = sectionViewModel.get("Model");
						var moduleCode = BPMSoft.MobileSectionDesignerEnums.ModuleWithoutSysModuleEntity[modelName];
						 if (moduleCode) {
						 	excludedNonStandardModules.push(moduleCode);
						 } else {
							excludedStandardModules.push(modelName);
						 }
					}, this);
					var exludeBySchemaNameFilter;
					if (excludedStandardModules.length > 0) {
						exludeBySchemaNameFilter = BPMSoft.createColumnInFilterWithParameters(
							"[SysModuleEntity:Id:SysModuleEntity].[SysSchema:UId:SysEntitySchemaUId].Name",
							excludedStandardModules);
						exludeBySchemaNameFilter.comparisonType = BPMSoft.ComparisonType.NOT_EQUAL;
					} else {
						exludeBySchemaNameFilter = BPMSoft.createExistsFilter("[SysModuleEntity:Id:SysModuleEntity].Id");
					}
					var exceptNonStandardModulesFilter = BPMSoft.createColumnInFilterWithParameters(
						"Code",
						nonStandardModuleCodes);
					exceptNonStandardModulesFilter.comparisonType = BPMSoft.ComparisonType.EQUAL;
					var exludeBySchemaNameGroupFilter = BPMSoft.createFilterGroup();
					exludeBySchemaNameGroupFilter.logicalOperation = BPMSoft.LogicalOperatorType.OR;
					exludeBySchemaNameGroupFilter.addItem(exludeBySchemaNameFilter);
					exludeBySchemaNameGroupFilter.addItem(exceptNonStandardModulesFilter);
					var exludeByCodeFilter = BPMSoft.createColumnInFilterWithParameters(
						"Code",
						excludedNonStandardModules);
					exludeByCodeFilter.comparisonType = BPMSoft.ComparisonType.NOT_EQUAL;
					var excludeSectionsFilter = BPMSoft.createFilterGroup();
					excludeSectionsFilter.logicalOperation = BPMSoft.LogicalOperatorType.AND;
					excludeSectionsFilter.addItem(exludeBySchemaNameGroupFilter);
					excludeSectionsFilter.addItem(exludeByCodeFilter);
					filters.addItem(excludeSectionsFilter);
					filters.addItem(BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "IsSystem", 0));
					filters.addItem(BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "Type", 0));
					filterGroup.addItem(filters);
					var lookupConfig = {
						entitySchemaName: "SysModule",
						multiSelect: false,
						columns: ["SysModuleEntity.SysEntitySchemaUId", "Code"],
						filters: filterGroup
					};
					LookupUtilities.Open(this.sandbox, lookupConfig, this.addSectionLookupUtilitiesOpenCallback, this);
				},

				/**
				 * ############ ######### ## #### ###### ## ###########.
				 * @protected
				 * @virtual
				 * @param {Object} config ############ ###### ## ###########.
				 */
				addSectionLookupUtilitiesOpenCallback: function(config) {
					var maskId = BPMSoft.Mask.show();
					var selectedRows = config.selectedRows;
					var selectedRow = selectedRows.getItems()[0];
					var sectionViewModelCollection = this.get("GridData");
					var maxPosition = sectionViewModelCollection.getCount();
					var nonStandardModuleName;
					Ext.Object.each(BPMSoft.MobileSectionDesignerEnums.ModuleWithoutSysModuleEntity,
						function(name, value) {
							if (value === selectedRow.Code) {
								nonStandardModuleName = name;
								return false;
							}
						}
					);
					if (nonStandardModuleName) {
						this.addSection({
							schemaName: nonStandardModuleName,
							title: selectedRow.Caption,
							position: maxPosition,
							callback: function() {
								BPMSoft.Mask.hide(maskId);
							},
							scope: this
						});
					} else {
						var entitySchemaUId = selectedRow["SysModuleEntity.SysEntitySchemaUId"];
						SectionDesignerUtils.getSchemaInfo({
							schemaId: entitySchemaUId,
							callback: function(schemaInfo) {
								if (schemaInfo) {
									this.addSection({
										schemaName: schemaInfo.name,
										title: selectedRow.Caption,
										position: maxPosition,
										callback: function() {
											BPMSoft.Mask.hide(maskId);
										},
										scope: this
									});
								} else {
									this.loadGridData();
									BPMSoft.Mask.hide(maskId);
								}
							},
							scope: this
						});
					}
				},

				/**
				 * ####### ####### ## #########.
				 * @protected
				 * @virtual
				 * @param {Function} callback ####### ######### ######.
				 */
				createDefaultSectionsIfNotExist: function(callback) {
					var schemaManager = MobileDesignerUtils.schemaManager;
					if (!schemaManager.manifestSchemaIsNew || (this.get("WorkplaceTypeId") == this.BPMSoft.MobileDesignerEnums.WorkplaceType.Portal)) {
						Ext.callback(callback, this);
						return;
					}
					var batchQuery = Ext.create("BPMSoft.BatchQuery");
					var defaultManifestModules = BPMSoft.MobileSectionDesignerEnums.DefaultManifestModules;
					for (var i = 0, ln = defaultManifestModules.length; i < ln; i++) {
						var moduleName = defaultManifestModules[i];
						var select = this.getDefaultSectionsSelectQuery(moduleName);
						batchQuery.add(select);
					}
					var batchQueryCallback = Ext.bind(this.onDefaultSectionsBatchQueryExecuted, this, [callback], true);
					batchQuery.execute(batchQueryCallback);
				},

				/**
				 * Adds modules.
				 * @protected
				 * @virtual
				 * @param {Object} config Configuration object.
				 * @param {String[]} config.sections Array of modules.
				 * @param {Function} config.callback Callback function.
				 */
				addSections: function(config) {
					var sections = config.sections;
					var entities = [];
					var manifest = MobileDesignerUtils.manifest;
					for (var i = 0, ln = sections.length; i < ln; i++) {
						var section = sections[i];
						var entitySchemaName = section.entitySchemaName;
						var nonStandardModules = BPMSoft.MobileSectionDesignerEnums.ModuleWithoutSysModuleEntity;
						manifest.addModule(entitySchemaName, {
							title: section.title,
							position: section.position,
							addModel: nonStandardModules[entitySchemaName] ? false : true
						});
						entities.push(entitySchemaName);
						newSections[entitySchemaName] = true;
					}
					this.saveEntitiesDefaultSettingsIfNotExist({
						entities: entities,
						callback: config.callback
					});
				},

				/**
				 * ######### ### #########.
				 * @protected
				 * @virtual
				 */
				onSaveSectionButtonClick: function() {
					var maskId = BPMSoft.Mask.show();
					this.saveAttemptsNumber = 0;
					this.saveSchemasFromManifest(maskId);
				},

				/**
				 * ######## ###### # #########.
				 * @param {String} id ############# ######## ######### ########.
				 */
				removeSection: function(id) {
					var confirmationMessage = resources.localizableStrings.RemoveSectionConfirmationDialogMessage;
					BPMSoft.showConfirmation(confirmationMessage, function(returnCode) {
						if (returnCode === BPMSoft.MessageBoxButtons.YES.returnCode) {
							var sectionViewModelCollection = this.get("GridData");
							var sectionViewModel = sectionViewModelCollection.get(id);
							var modelName = sectionViewModel.get("Model");
							this.set("ActiveRow", null);
							if (this.shouldRemoveSectionSchemas(modelName)) {
								var moduleConfig = MobileDesignerUtils.manifest.getModuleConfig(modelName);
								var pagesExtensions = moduleConfig.PagesExtensions;
								for (var i = 0, ln = pagesExtensions.length; i < ln; i++) {
									this.removeSettingsPage(modelName, pagesExtensions[i]);
								}
							}
							MobileDesignerUtils.manifest.hideModule(modelName);
							this.loadGridData();
						}
					}, ["yes", "no"], this);
				},

				/**
				 * ######## ####### ######## # #########.
				 * @param {String} id ############# ######## ######### ########.
				 * @param {Number} position ######## ########## ####### (-1 - #####, 1 - ####).
				 */
				changeSectionPosition: function(id, position) {
					var sectionViewModelCollection = this.get("GridData");
					var activeSectionViewModel = sectionViewModelCollection.get(id);
					var activeSectionPosition = sectionViewModelCollection.indexOf(activeSectionViewModel);
					var newActiveSectionPosition = activeSectionPosition + position;
					var maxPosition = sectionViewModelCollection.getCount() - 1;
					var minPosition = 0;
					if (newActiveSectionPosition < minPosition || newActiveSectionPosition > maxPosition) {
						return;
					}
					var modifiedMaxPosition = (newActiveSectionPosition > activeSectionPosition) ?
						newActiveSectionPosition : activeSectionPosition;
					for (var i = modifiedMaxPosition; i >= 0; i--) {
						var sectionItem = sectionViewModelCollection.getByIndex(i);
						if (i === newActiveSectionPosition) {
							sectionItem.set("Position", activeSectionPosition);
						} else if (i === activeSectionPosition) {
							sectionItem.set("Position", newActiveSectionPosition);
						} else {
							sectionItem.set("Position", i);
						}
					}
					this.updateManifestModulesPosition(sectionViewModelCollection);
					this.loadGridData();
				},

				/**
				 * ######### ######## ######### #######.
				 * @param {String} id ############# ######## ######### ########.
				 */
				openGridDesigner: function(id) {
					var designerCaption = resources.localizableStrings.GridDesignerCaption;
					this.openDesigner(id, BPMSoft.MobileDesignerEnums.SettingsType.GridPage,
						"MobileGridDesignerModule", designerCaption);
				},

				/**
				 * ######### ######## ######### ########.
				 * @param {String} id ############# ######## ######### ########.
				 */
				openPageDesigner: function(id) {
					var designerCaption = resources.localizableStrings.PageDesignerCaption;
					this.openDesigner(id, BPMSoft.MobileDesignerEnums.SettingsType.RecordPage,
						"MobilePageDesignerModule", designerCaption);
				},

				/**
				 * ######### ######## ######### ######.
				 * @param {String} id ############# ######## ######### ########.
				 */
				openDetailDesigner: function(id) {
					var designerCaption = resources.localizableStrings.DetailsDesignerCaption;
					this.openDesigner(id, BPMSoft.MobileDesignerEnums.SettingsType.RecordPage,
						"MobileDetailDesignerModule", designerCaption);
				},

				/**
				 * ########## ####### ########## ########.
				 * @protected
				 * @virtual
				 * @param {Object} settingsConfig ############ ######### #########.
				 */
				onDesignerSaved: function(settingsConfig) {
					if (settingsConfig.settingsType === BPMSoft.MobileDesignerEnums.SettingsType.RecordPage) {
						this.saveRecordSettings(settingsConfig);
					} else {
						this.saveGridSettings(settingsConfig);
					}
				},

				/**
				 * ########## ######## ## ########### ######
				 * @protected
				 * @virtual
				 */
				onBackHistoryState: function() {
					this.updateHeaderCaption();
				},

				/**
				 * ##### ######### ######## ### ########## ####### # ############ ## tag
				 * @protected
				 * @virtual
				 */
				onActiveRowAction: function(tag, id) {
					switch (tag) {
						case "delete":
							this.removeSection(id);
							break;
						case "up":
						case "down":
							var position = (tag === "up") ? -1 : 1;
							this.changeSectionPosition(id, position);
							break;
						case "editGrid":
							this.openGridDesigner(id);
							break;
						case "editPage":
							this.openPageDesigner(id);
							break;
						case "editDetail":
							this.openDetailDesigner(id);
							break;
						default:
							break;
					}
				},

				/**
				 * ######### ######### # ######### ###### #########.
				 * @protected
				 * @virtual
				 * @param {String} id ############# ######## ######### ########.
				 * @param {String} settingsType ### ######## ######### ########.
				 * @param {String} designerModuleSchemaName ### ##### ###### #########.
				 * @param {String} designerCaption ######### #########.
				 */
				openDesigner: function(id, settingsType, designerModuleSchemaName, designerCaption) {
					var maskId = BPMSoft.Mask.show();
					var sectionViewModelCollection = this.get("GridData");
					var sectionViewModel = sectionViewModelCollection.get(id);
					var entitySchemaName = sectionViewModel.get("Model");
					MobileDesignerUtils.loadSettings({
						entitySchemaName: entitySchemaName,
						settingsType: settingsType,
						callback: function(designerSettings) {
							if (!designerSettings) {
								designerSettings = {
									entitySchemaName: entitySchemaName,
									settingsType: settingsType
								};
							}
							var sectionTitle = sectionViewModel.get("Title");
							var title = Ext.String.format("{0} \"{1}\"", designerCaption, sectionTitle);
							var moduleConfig = {
								designerSettings: designerSettings,
								designerModuleSchemaName: designerModuleSchemaName,
								title: title
							};
							this.openDesignerModulePage(moduleConfig);
							BPMSoft.Mask.hide(maskId);
						},
						scope: this
					});
				},

				/**
				 * ######### ###### #########.
				 * @protected
				 * @virtual
				 * @param {Object} moduleConfig ######### ######### #########.
				 */
				openDesignerModulePage: function(moduleConfig) {
					var designerPageSchemaName = "MobileDesignerModulePage";
					var designerId = this.sandbox.id + designerPageSchemaName;
					var params = this.sandbox.publish("GetHistoryState");
					var stateObj = {
						designerSchemaName: designerPageSchemaName,
						moduleConfig: moduleConfig
					};
					this.sandbox.publish("PushHistoryState", {
						hash: params.hash.historyState,
						stateObj: stateObj,
						silent: true
					});
					this.sandbox.loadModule("ConfigurationModuleV2", {
						renderTo: "centerPanel",
						id: designerId,
						keepAlive: true
					});
				},

				/**
				 * ######### ######### ########.
				 * @protected
				 * @virtual
				 * @param {Object} settingsConfig ############ ######### #########.
				 */
				saveRecordSettings: function(settingsConfig) {
					var maskId = BPMSoft.Mask.show();
					this.processStandartDetails({
						details: settingsConfig.details,
						callback: function() {
							this.saveSettings({
								settingsConfig: settingsConfig,
								callback: function() {
									BPMSoft.Mask.hide(maskId);
								}
							});
						}
					});
				},

				/**
				 * ######### ######### #######.
				 * @protected
				 * @virtual
				 * @param {Object} settingsConfig ############ ######### #########.
				 */
				saveGridSettings: function(settingsConfig) {
					var maskId = BPMSoft.Mask.show();
					this.saveSettings({
						settingsConfig: settingsConfig,
						callback: function() {
							BPMSoft.Mask.hide(maskId);
						}
					});
				},

				/**
				 * ######### #########.
				 * @protected
				 * @virtual
				 * @param {Object} config ################ ######.
				 * @param {Object} config.settingsConfig ############ ######### #########.
				 * @param {Function} config.callback ####### ######### ######.
				 */
				saveSettings: function(config) {
					var settingsConfig = config.settingsConfig;
					MobileDesignerUtils.saveSettings({
						entitySchemaName: settingsConfig.entitySchemaName,
						settings: settingsConfig,
						settingsType: settingsConfig.settingsType,
						callback: config.callback,
						scope: this
					});
				},

				/**
				 * ######### ######### ## ######### # #####, ####### ## #### ####### ## # ##### ## #######.
				 * @protected
				 * @virtual
				 * @param {Object} config ################ ######.
				 * @param {Object} config.entitySchemaName ### #####.
				 * @param {BPMSoft.MobileDesignerEnums.SettingsType} config.settingsType ### ########.
				 * @param {Function} config.callback ####### ######### ######.
				 */
				saveDefaultSettingsIfNotExist: function(config) {
					var schemaManager = MobileDesignerUtils.schemaManager;
					var entitySchemaName = config.entitySchemaName;
					var settingsType = config.settingsType;
					schemaManager.readSettingsSchema({
						settingsType: settingsType,
						entitySchemaName: entitySchemaName,
						searchInAllPackages: true,
						callback: function(schemaInstance) {
							var isNewSchemaInstance = schemaManager.self.isNewSchemaInstance(schemaInstance);
							if (!isNewSchemaInstance) {
								Ext.callback(config.callback, this);
								return;
							}
							this.getDefaultSettingsConfig({
								entitySchemaName: entitySchemaName,
								settingsType: settingsType,
								callback: function(settingsConfig) {
									settingsConfig.settingsType = settingsType;
									this.saveSettings({
										settingsConfig: settingsConfig,
										callback: config.callback
									});
								}
							});
						},
						scope: this
					});
				},

				/**
				 * ######### ######### ## ####### ####.
				 * @param {Object} config ################ ######.
				 * @param {String[]} config.entities ###### #### ####.
				 * @param {Function} config.callback ####### ######### ######.
				 */
				saveEntitiesDefaultSettingsIfNotExist: function(config) {
					var recordSettingsType = BPMSoft.MobileDesignerEnums.SettingsType.RecordPage;
					var gridSettingsType = BPMSoft.MobileDesignerEnums.SettingsType.GridPage;
					var actionsSettingsType = BPMSoft.MobileDesignerEnums.SettingsType.Actions;
					var chainArguments = [];
					var generateSaveSettingsChainFn = function(schemaName, settingsType) {
						return function(next) {
							this.saveDefaultSettingsIfNotExist({
								settingsType: settingsType,
								entitySchemaName: schemaName,
								callback: function() {
									next();
								}
							});
						};
					};
					var entities = config.entities;
					for (var i = 0, ln = entities.length; i < ln; i++) {
						var entitySchemaName = entities[i];
						if (!BPMSoft.MobileSectionDesignerEnums.ModuleWithoutSysModuleEntity[entitySchemaName] &&
							!BPMSoft.contains(BPMSoft.MobileSectionDesignerEnums.NotConfigurableModules,
								entitySchemaName)) {
							chainArguments.push(generateSaveSettingsChainFn(entitySchemaName, recordSettingsType));
							chainArguments.push(generateSaveSettingsChainFn(entitySchemaName, gridSettingsType));
							chainArguments.push(generateSaveSettingsChainFn(entitySchemaName, actionsSettingsType));
						}
					}
					chainArguments.push(function(next) {
						Ext.callback(config.callback, this);
						next();
					});
					chainArguments.push(this);
					Ext.callback(BPMSoft.chain, this, chainArguments);
				},

				/**
				 * ############ ########## ########### #######.
				 * @protected
				 * @virtual
				 * @param {Object} config ################ ######.
				 * @param {Object[]} config.details ###### ######## #######.
				 * @param {Function} config.callback ####### ######### ######.
				 */
				processStandartDetails: function(config) {
					var details = config.details;
					var entities = [];
					for (var i = 0, ln = details.length; i < ln; i++) {
						var detail = details[i];
						entities.push(detail.entitySchemaName);
					}
					this.saveEntitiesDefaultSettingsIfNotExist({
						entities: entities,
						callback: config.callback
					});
				},

				/**
				 * ######## ############ ######### ## ####.
				 * @protected
				 * @virtual
				 * @param {Object} config ################ ######.
				 * @param {Object} config.entitySchemaName ### #####.
				 * @param {BPMSoft.MobileDesignerEnums.SettingsType} config.settingsType ### ########.
				 * @param {Function} config.callback ####### ######### ######.
				 */
				getDefaultSettingsConfig: function(config) {
					var designerSettingsClassName;
					var settingsType = config.settingsType;
					if (settingsType === BPMSoft.MobileDesignerEnums.SettingsType.RecordPage) {
						designerSettingsClassName = "BPMSoft.MobileRecordDesignerSettings";
					} else if (settingsType === BPMSoft.MobileDesignerEnums.SettingsType.GridPage) {
						designerSettingsClassName = "BPMSoft.MobileGridDesignerSettings";
					} else if (settingsType === BPMSoft.MobileDesignerEnums.SettingsType.Actions) {
						designerSettingsClassName = "BPMSoft.MobileActionsDesignerSettings";
					}
					var recordDesignerSettings = Ext.create(designerSettingsClassName, {
						sandbox: this.sandbox,
						settingsConfig: {
							entitySchemaName: config.entitySchemaName
						}
					});
					recordDesignerSettings.initialize(function() {
						var settingsConfig = recordDesignerSettings.getSettingsConfig();
						Ext.callback(config.callback, this, [settingsConfig]);
					}, this);
				},

				onCancelClick: function() {
					window.close();
				},

				getCancelButtonCaption: function() {
					return BPMSoft.Resources.SchemaDesigner.DiscardStorageButtonCaption;
				}
			},
			diff: [
				{
					"operation": "insert",
					"parentName": "FooterContainer",
					"name": "SectionDesignerSaveButton",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
						"caption": {
							"bindTo": "Resources.Strings.SaveButtonCaption"
						},
						"classes": {
							"textClass": "actions-button-margin-right"
						},
						"click": {
							"bindTo": "onSaveSectionButtonClick"
						}
					}
				},
				{
					"operation": "insert",
					"name": "SectionDesignerAddButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
						"caption": {
							"bindTo": "Resources.Strings.AddSectionButtonCaption"
						},
						"click": {
							"bindTo": "onAddSectionButtonClick"
						}
					}
				},
				{
					"operation": "insert",
					"name": "SectionDesignerModuleGrid",
					"values": {
						"id": "SectionDesignerModuleGrid",
						"selectors": {
							"wrapEl": "#SectionDesignerModuleGrid"
						},
						type: "listed",
						columnsConfig: [
							{
								cols: 24,
								key: [
									{name: {bindTo: "Title"}}
								]
							}
						],
						captionsConfig: [
							{
								cols: 24,
								name: resources.localizableStrings.GridTitleColumnCaption
							}
						],
						"activeRow": {"bindTo": "ActiveRow"},
						"activeRowAction": {"bindTo": "onActiveRowAction"},
						"activeRowActions": [],
						"listedZebra": true,
						"collection": {"bindTo": "GridData"},
						"itemType": BPMSoft.ViewItemType.GRID,
						"items": [],
						"primaryColumnName": "Model"
					}
				},
				{
					"operation": "insert",
					"name": "DataGridActiveRowEditGridAction",
					"parentName": "SectionDesignerModuleGrid",
					"propertyName": "activeRowActions",
					"values": {
						"className": "BPMSoft.Button",
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
						"caption": resources.localizableStrings.OpenGridDesignerGridRowButtonCaption,
						"classes": {
							"textClass": ["mobile-section-designer-button"]
						},
						"tag": "editGrid",
						"visible": {
							"bindTo": "isModuleEditable"
						}
					}
				},
				{
					"operation": "insert",
					"name": "DataGridActiveRowEditPageAction",
					"parentName": "SectionDesignerModuleGrid",
					"propertyName": "activeRowActions",
					"values": {
						"className": "BPMSoft.Button",
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
						"caption": resources.localizableStrings.OpenPageDesignerGridRowButtonCaption,
						"classes": {
							"textClass": ["mobile-section-designer-button"]
						},
						"tag": "editPage",
						"visible": {
							"bindTo": "isModuleEditable"
						}
					}
				},
				{
					"operation": "insert",
					"name": "DataGridActiveRowEditDeatilAction",
					"parentName": "SectionDesignerModuleGrid",
					"propertyName": "activeRowActions",
					"values": {
						"className": "BPMSoft.Button",
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
						"caption": resources.localizableStrings.OpenDetailDesignerGridRowButtonCaption,
						"classes": {
							"textClass": ["mobile-section-designer-button"]
						},
						"tag": "editDetail",
						"visible": {
							"bindTo": "isModuleEditable"
						}
					}
				},
				{
					"operation": "insert",
					"name": "DataGridActiveRowMoveUpAction",
					"parentName": "SectionDesignerModuleGrid",
					"propertyName": "activeRowActions",
					"values": {
						"className": "BPMSoft.Button",
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
						"caption": LocalizableHelper.localizableStrings.UpButtonHint,
						"classes": {
							"textClass": ["mobile-section-designer-button"]
						},
						"tag": "up"
					}
				},
				{
					"operation": "insert",
					"name": "DataGridActiveRowMoveDownAction",
					"parentName": "SectionDesignerModuleGrid",
					"propertyName": "activeRowActions",
					"values": {
						"className": "BPMSoft.Button",
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
						"caption": LocalizableHelper.localizableStrings.DownButtonHint,
						"classes": {
							"textClass": ["mobile-section-designer-button"]
						},
						"tag": "down"
					}
				},
				{
					"operation": "insert",
					"name": "DataGridActiveRowDeleteAction",
					"parentName": "SectionDesignerModuleGrid",
					"propertyName": "activeRowActions",
					"values": {
						"className": "BPMSoft.Button",
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
						"caption": resources.localizableStrings.DeleteRecordGridRowButtonCaption,
						"classes": {
							"textClass": ["mobile-section-designer-button"]
						},
						"tag": "delete"
					}
				},
				{
					"operation": "insert",
					"name": "FooterContainer",
					"parentName": "MainContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"generateId": false,
						"classes": {"wrapClassName": ["footer-container", "mobile-section-designer-footer"]},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "CancelButton",
					"parentName": "FooterContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
						"generateId": false,
						"click": {"bindTo": "onCancelClick"},
						"caption": {"bindTo": "getCancelButtonCaption"},
						"classes": {
							"textClass": ["cancel-footer-button"],
							"wrapperClass": ["cancel-footer-button"]
						},
						"markerValue": {"bindTo": "CancelButton"}
					}
				},
			]
		};
	}
);
