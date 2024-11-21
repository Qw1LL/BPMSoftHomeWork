define("WizardUtilities", ["BPMSoft", "WizardUtilitiesResources", "RightUtilities", "DesignTimeEnums",
	"SectionWizardEnums"
], function(BPMSoft, resources, RightUtilities) {
	var localizableStrings = resources.localizableStrings;
	var localizableImages = resources.localizableImages;

	Ext.define("BPMSoft.configuration.mixins.WizardUtilities", {

		alternateClassName: "BPMSoft.WizardUtilities",

		/**
		 * Name of configuration service for wizard.
		 * @protected
		 * @type {String}
		 */
		serviceName: "WizardService",

		/**
		 * Section wizard menu item ID.
		 * @protected
		 * @type {String}
		 */
		sectionWizardMenuItemId: null,

		_clearRunProcessCache: function (moduleId) {
			const key = "RunProcessInModule-" + moduleId + "-SysModuleId";
			BPMSoft.EntitySchemaQuery.clearCache(key);
		},

		/**
		 * Adds section wizard menu item.
		 * @protected
		 * @param {BPMSoft.BaseViewModelCollection} viewOptions Menu items of "View" menu.
		 * @param {BPMSoft.BaseViewModel} buttonMenuItem Button menu item.
		 */
		addSectionWizardMenuItem: function(viewOptions, buttonMenuItem) {
			var itemId = viewOptions.getUniqueKey();
			viewOptions.add(itemId, buttonMenuItem);
			this.sectionWizardMenuItemId = itemId;
		},

		/**
		 * Returns detail Id.
		 * @protected
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Execution context.
		 */
		getDetailId: function(callback, scope) {
			var schemaName = this.get("SchemaName");
			var entitySchemaName = this.entitySchemaName;
			var workspaceId = BPMSoft.SysValue.CURRENT_WORKSPACE.value;
			var cacheItemName = Ext.String.format("SysDetailId_{0}_{1}_{2}", workspaceId, schemaName, entitySchemaName);
			var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: "SysDetail",
				isDistinct: true,
				clientESQCacheParameters: {
					cacheItemName: cacheItemName
				},
				serverESQCacheParameters: {
					cacheLevel: BPMSoft.ESQServerCacheLevels.WORKSPACE,
					cacheGroup: "WizardUtilities",
					cacheItemName: cacheItemName
				}
			});
			esq.addColumn("Id");
			var filterGroup = this.BPMSoft.createFilterGroup();
			filterGroup.logicalOperation = this.BPMSoft.LogicalOperatorType.AND;
			filterGroup.addItem(this.BPMSoft.createColumnFilterWithParameter(
				this.BPMSoft.ComparisonType.EQUAL,
				"[VwSysSchemaInWorkspace:UId:EntitySchemaUId].Name",
				entitySchemaName));
			filterGroup.addItem(this.BPMSoft.createColumnFilterWithParameter(
				this.BPMSoft.ComparisonType.NOT_EQUAL,
				"[VwSysSchemaInWorkspace:UId:EntitySchemaUId].ExtendParent",
				1));
			filterGroup.addItem(this.BPMSoft.createColumnFilterWithParameter(
				this.BPMSoft.ComparisonType.EQUAL,
				"[VwSysSchemaInWorkspace:UId:DetailSchemaUId].Name",
				schemaName));
			filterGroup.addItem(this.BPMSoft.createColumnFilterWithParameter(
				this.BPMSoft.ComparisonType.NOT_EQUAL,
				"[VwSysSchemaInWorkspace:UId:DetailSchemaUId].ExtendParent",
				1));
			filterGroup.addItem(this.BPMSoft.createColumnFilterWithParameter(
				this.BPMSoft.ComparisonType.EQUAL,
				"[VwSysSchemaInWorkspace:UId:EntitySchemaUId].SysWorkspace",
				workspaceId));
			esq.filters.add("SchemasFilters", filterGroup);
			esq.getEntityCollection(function(result) {
				if (result.success) {
					var detail = result.collection.first();
					var detailId = detail && detail.get("Id");
					callback.call(scope, detailId);
				}
			}, this);
		},

		/**
		 * Open detail wizard.
		 * @protected
		 * @virtual
		 */
		openDetailWizard: function() {
			this.getDetailId(function(detailId) {
				if (detailId) {
					this.openDetailWindow(detailId);
				} else {
					BPMSoft.utils.showMessage({
						caption: localizableStrings.DetailIsNotRegisteredMessage,
						buttons: ["ok"],
						defaultButton: 0
					});
				}
			}, this);
		},

		/**
		 * Opens section wizard.
		 * @protected
		 * @virtual
		 * @param {BPMSoft.SectionWizardEnums.PageName} config.pageName Page name.
		 */
		openSectionWizard: function(config) {
			var wizardStepName = config && config.pageName;
			var enumPageDesigner = BPMSoft.SectionWizardEnums.PageName.PAGE_DESIGNER;
			const schemaName = this.name;
			let section = _.findWhere(BPMSoft.configuration.ModuleStructure, {sectionSchema: schemaName});
			if (section) {
				if (wizardStepName === enumPageDesigner) {
					var activeRow = this.getActiveRow();
					const moduleEditId = this.getModuleEditId(activeRow, section.entitySchemaName);
					this.openSectionWindow(section.moduleId, enumPageDesigner, moduleEditId);
				} else {
					this.openSectionWindow(section.moduleId, wizardStepName);
				}
			} else {
				section = _.find(BPMSoft.configuration.ModuleStructure, function(structure) {
					return _.findWhere(structure.pages, {cardSchema: schemaName});
				});
				if (section) {
					const page = _.findWhere(section.pages, {cardSchema: schemaName});
					if (wizardStepName === enumPageDesigner) {
						this.openSectionWindow(section.moduleId, wizardStepName, page.moduleEditId);
					} else {
						this.openSectionWindow(section.moduleId, wizardStepName);
					}
				} else {
					section = _.findWhere(BPMSoft.configuration.ModuleStructure, {cardSchema: schemaName});
					if (section) {
						this.openSectionWindow(section.moduleId, wizardStepName);
					}
				}
			}
			this._clearRunProcessCache(section.moduleId);
		},

		/**
		 * @protected
		 */
		getModuleEditId: function(activeRow, entitySchemaName) {
			var typeColumnValue = this.getTypeColumnValue(activeRow);
			var structure = BPMSoft.configuration.EntityStructure[entitySchemaName];
			var moduleEditId = null;
			const hasType = BPMSoft.isGUID(typeColumnValue) && !BPMSoft.isEmpty(typeColumnValue);
			const hasPages = structure && structure.pages && structure.pages.length > 1;
			if (hasType && hasPages) {
				BPMSoft.each(structure.pages, function(page) {
					if (page.UId === typeColumnValue) {
						moduleEditId = page.moduleEditId;
					}
				}, this);
			}
			return moduleEditId;
		},

		/**
		 * Opens wizard window.
		 * @private
		 * @param {String} wizardModuleUrl Wizard module URL.
		 * @param {String} wizardStepName Wizard step name.
		 * @param {String} applicationStructureItemId Application structure item ID.
		 * @param {String} moduleEditId Module edit ID.
		 * @param {String} additionalParams Additional parameters.
		 */
		openWizardWindow: function(wizardModuleUrl, wizardStepName, applicationStructureItemId, moduleEditId,
				additionalParams) {
			const wizardStepUrl = _.compact([wizardStepName, applicationStructureItemId, moduleEditId]).join("/");
			var url = BPMSoft.workspaceBaseUrl + wizardModuleUrl + wizardStepUrl;
			if (additionalParams) {
				url += additionalParams;
			}
			window.open(url);
		},

		/**
		 * Opens detail wizard window.
		 * @public
		 * @param {String} detailId Detail identifier.
		 */
		openDetailWindow: function(detailId) {
			this.openWizardWindow(BPMSoft.DesignTimeEnums.WizardUrl.DETAIL_WIZARD_URL, "", detailId);
		},

		/**
		 * Opens section wizard window.
		 * @protected
		 * @param {String} moduleId Section identifier.
		 * @param {BPMSoft.SectionWizardEnums.PageName} wizardStepName Page name.
		 * @param {String} additionalParams Additional parameters.
		 */
		openSectionWindow: function(moduleId, wizardStepName, moduleEditId, additionalParams) {
			const wizardUrlEnum = BPMSoft.DesignTimeEnums.WizardUrl;
			if (wizardStepName === BPMSoft.SectionWizardEnums.PageName.PAGE_DESIGNER) {
				this.openWizardWindow(wizardUrlEnum.SECTION_PAGE_WIZARD_URL, "", moduleId, moduleEditId);
			} else {
				this.openWizardWindow(wizardUrlEnum.SECTION_WIZARD_URL, wizardStepName, moduleId, moduleEditId,
					additionalParams);
			}
		},

		/**
		 * Check right for CanManageSolution operation.
		 * @protected
		 * @virtual
		 * @param {Function} callback Callback method.
		 * @param {Object} scope Callback method context.
		 */
		canUseWizard: function(callback, scope) {
			RightUtilities.checkCanExecuteOperation({
				operation: "CanManageSolution"
			}, function(result) {
				callback.call(scope, result);
			}, this);
		},

		/**
		 * Check right for use PageDesigner and set response into viewModel
		 * ex. callCanChangeApplicationTuningMode
		 * @protected
		 * @param {Function} [callback] Callback method.
		 * @param {Object} [scope] Callback method context.
		 */
		initCanDesignPage: function(callback, scope) {
			this.canUseWizard(function(result) {
				result = result && !Ext.isEmpty(BPMSoft.configuration.ModuleStructure[this.entitySchemaName]);
				this.set("CanDesignPage", result);
				this.Ext.callback(callback, scope || this);
			}, this);
		},

		/**
		 * Returns information about the availability of the master page.
		 * @protected
		 * @virtual
		 * @return {Boolean} true - if the page master is available, false - otherwise.
		 */
		getCanDesignPage: function() {
			var canDesignPage = this.get("CanDesignPage");
			return Ext.isEmpty(canDesignPage) ? false : canDesignPage;
		},

		/**
		 * Method cleared configuration script from server cache.
		 * @protected
		 * @virtual
		 * @param {Function} callback Callback method.
		 * @param {Object} scope Callback method context.
		 */
		clearConfigurationScript: function(callback, scope) {
			this.callServiceMethod("ClearConfigurationScript", null, callback, scope);
		},

		/**
		 * Method for call web service with defined parameters.
		 * @protected
		 * @param {String} methodName Method name.
		 * @param {Object} data Data object.
		 * @param {Function} callback Callback method.
		 * @param {Object} scope Callback method context.
		 */
		callServiceMethod: function(methodName, data, callback, scope) {
			var workspaceBaseUrl = BPMSoft.utils.uri.getConfigurationWebServiceBaseUrl();
			var requestUrl = workspaceBaseUrl + "/rest/" + this.serviceName + "/" + methodName;
			BPMSoft.AjaxProvider.request({
				"url": requestUrl,
				"headers": {
					"Accept": "application/json",
					"Content-Type": "application/json"
				},
				"method": "POST",
				"jsonData": data || {},
				"timeout": 600000,
				callback: function(request, success, response) {
					var responseObject = success ? BPMSoft.decode(response.responseText) : {};
					callback.call(scope || this, responseObject, success);
				},
				"scope": this
			});
		},

		/**
		 * Returns getCanDesignWizard.
		 * @protected
		 * @virtual
		 * @return {Boolean}
		 */
		getCanDesignWizard: BPMSoft.emptyFn,

		/**
		 * Returns open section wizard menu image config.
		 * @returns {Object} Open section wizard menu image config.
		 */
		getSectionDesignerMenuIcon: function() {
			return localizableImages.OpenSectionWizardIcon;
		},

		/**
		 * @deprecated
		 */
		getSectionWizardToggleState: function() {
			window.console.log("Method getSectionWizardToggleState is deprecated");
		},

		/**
		 * @deprecated
		 */
		getCanUseSectionWizard: function() {
			window.console.log("Method getCanUseSectionWizard is deprecated");
		},

		/**
		 * @deprecated
		 */
		getCanUseNewSectionWizard: function() {
			window.console.log("Method getCanUseNewSectionWizard is deprecated");
		}

	});

	return Ext.create(BPMSoft.WizardUtilities);
});
