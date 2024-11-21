define("MobileWorkplaceSectionsModule", ["MobileWorkplaceSectionsModuleResources", "BaseDetailV2Resources", 
		"LookupUtilities", "MobileDesignerUtils", "MobileDesignerSchemaManager", "css!DetailModuleV2"],
	function(resources, baseDetailV2Resources, LookupUtilities) {

		/**
		 * @class BPMSoft.configuration.MobileWorkplaceSectionsViewConfig
		 * #####, ############ ############ ############# ######.
		 */
		Ext.define("BPMSoft.configuration.MobileWorkplaceSectionsViewConfig", {
			extend: "BPMSoft.BaseObject",
			alternateClassName: "BPMSoft.MobileWorkplaceSectionsViewConfig",

			/**
			 * @private
			 * @type {String}
			 */
			name: "MobileWorkplaceSectionsModule",

			/**
			 * ########## ############ ############# ######.
			 * @protected
			 * @virtual
			 * @returns {Object[]} ########## ############ ############# ######.
			 */
			generate: function() {
				var name = this.name;
				return [
					{
						caption: resources.localizableStrings.SectionsControlGroupCaption,
						tools: [
							{
								name: name + "Add",
								caption: resources.localizableStrings.SectionsControlGroupAddButtonCaption,
								style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
								tag: name,
								itemType: BPMSoft.ViewItemType.BUTTON,
								click: { bindTo: "onAddButtonClick" }
							},
							{
								name: name + "Tools",
								itemType: BPMSoft.ViewItemType.BUTTON,
								imageConfig: baseDetailV2Resources.localizableImages.ToolsButtonImage,
								style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
								classes: {
									wrapperClass: ["detail-tools-button-wrapper"],
									menuClass: ["detail-tools-button-menu"]
								},
								menu: {
									items: {
										bindTo: "ToolsButtonMenu"
									}
								}
							}
						],
						wrapClass: ["detail hide-grid-caption-wrapClass"],
						name: name,
						itemType: BPMSoft.ViewItemType.CONTROL_GROUP,
						items: [
							{
								itemType: BPMSoft.ViewItemType.GRID,
								name: name,
								type: "listed",
								collection: { bindTo: "GridData" },
								columnsConfig: [
									{
										cols: 24,
										key: [
											{ name: { bindTo: "Title" } }
										]
									}
								],
								listedZebra: true
							}
						]
					}
				];
			}
		});

		/**
		 * @class BPMSoft.configuration.MobileWorkplaceSectionsViewModel
		 * ##### ###### ############# ######.
		 */
		Ext.define("BPMSoft.configuration.MobileWorkplaceSectionsViewModel", {
			extend: "BPMSoft.BaseViewModel",
			alternateClassName: "BPMSoft.MobileWorkplaceSectionsViewModel",

			Ext: null,
			sandbox: null,
			BPMSoft: null,

			/**
			 * @private
			 */
			workplace: null,

			/**
			 * @private
			 */
			notConfigurableModels: ["SysDashboard"],

			/**
			 * @private
			 */
			modelsOnInit: null,

			/**
			 * @private
			 */
			mobileDesignerSchemaManager: null,

			/**
			 * @private
			 */
			designerApplicationManifest: null,

			/**
			 * @inheritDoc BPMSoft.BaseModel#columns
			 * @type {Object}
			 */
			columns: {
				GridData: {
					type: BPMSoft.ViewModelColumnType.CALCULATED_COLUMN,
					dataValueType: BPMSoft.DataValueType.COLLECTION
				}
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
			getCurrentPackageName: function() {
				var storage = BPMSoft.DomainCache;
				return storage.getItem("SectionDesigner_CurrentPackageName");
			},

			/**
			 * @private
			 */
			initializeMobileDesignerUtils: function(callback) {
				var packageUId = this.getCurrentPackageUId();
				var packageName = this.getCurrentPackageName();
				var mobileDesignerSchemaManager = this.mobileDesignerSchemaManager =
					Ext.create("BPMSoft.MobileDesignerSchemaManager");
				BPMSoft.MobileDesignerSchemaManager.initialize({
					currentPackageUId: packageUId,
					currentPackageName: packageName,
					callback: function() {
						mobileDesignerSchemaManager.readManifests({
							callback: function(manifests, localizableStrings) {
								var designerApplicationManifest = this.designerApplicationManifest =
									Ext.create("BPMSoft.MobileDesignerApplicationManifest", {
										manifests: manifests,
										localizableStrings: localizableStrings
									});
								var currentManifestModels = designerApplicationManifest.getCurrentManifestModels();
								this.modelsOnInit = Object.keys(currentManifestModels);
								BPMSoft.MobileDesignerUtils.designerApplicationManifest = designerApplicationManifest;
								BPMSoft.MobileDesignerUtils.mobileDesignerSchemaManager = this.mobileDesignerSchemaManager;
								Ext.callback(callback, this);
							},
							scope: this
						});
					},
					scope: this
				});
			},

			/**
			 * ############## ######### ######## ######.
			 * @protected
			 * @virtual
			 * @param {Function} callback ####### ######### ######.ToolsButton
			 * @param {Object} scope ######## ####### ######### ######.
			 */
			init: function(callback, scope) {
				var sectionViewModelCollection = this.createSectionViewModelCollection([]);
				this.set("GridData", sectionViewModelCollection);
				this.initToolsButtonMenu();
				Ext.callback(callback, scope);
			},

			/**
			 * ############## ########## ###### ############## ######.
			 * @protected
			 * @virtual
			 */
			initToolsButtonMenu: function() {
				var toolsButtonMenu = this.get("ToolsButtonMenu");
				if (!toolsButtonMenu) {
					toolsButtonMenu = Ext.create("BPMSoft.BaseViewModelCollection");
					this.set("ToolsButtonMenu", toolsButtonMenu);
				}
				this.addToolsButtonMenuItems(toolsButtonMenu);
			},

			/**
			 * ######### ######## # ######### ########### ###### ############## ######.
			 * @protected
			 * @virtual
			 * @param {BaseViewModelCollection} toolsButtonMenu ######### ########### ###### ############## ######.
			 */
			addToolsButtonMenuItems: function(toolsButtonMenu) {
				var deleteRecordMenuItem = this.getButtonMenuItem({
					caption: resources.localizableStrings.SectionsControlGroupMenuDeleteCaption
				});
				if (deleteRecordMenuItem) {
					toolsButtonMenu.addItem(deleteRecordMenuItem);
				}
			},

			/**
			 * ####### ######### ######## ########### #### ######.
			 * @param {Object} config ############.
			 * @return {BPMSoft.BaseViewModel} ########## ######### ######## ########### #### ######.
			 */
			getButtonMenuItem: function(config) {
				return Ext.create("BPMSoft.BaseViewModel", {
					values: Ext.apply({}, config, {
						Id: BPMSoft.generateGUID(),
						Caption: config.caption,
						Click: config.click,
						MarkerValue: config.caption
					})
				});
			},

			/**
			 * ############ ####### ## ####### ########## ########## #######.
			 * @protected
			 * @virtual
			 */
			onAddButtonClick: function() {
				var filters = BPMSoft.createFilterGroup();
				var gridData = this.get("GridData");
				var moduleEntityNames = [];
				gridData.each(function(sectionViewModel) {
					moduleEntityNames.push(sectionViewModel.get("Model"));
				}, this);
				var notInFilter = BPMSoft.createColumnInFilterWithParameters(
					"[SysModuleEntity:Id:SysModuleEntityId].[SysSchema:UId:SysEntitySchemaUId].Name",
					moduleEntityNames);
				notInFilter.comparisonType = BPMSoft.ComparisonType.NOT_EQUAL;
				filters.addItem(notInFilter);
				filters.addItem(BPMSoft.createExistsFilter("[SysModuleInWorkplace:SysModule].Id"));
				filters.addItem(BPMSoft.createIsNotNullFilter(
					Ext.create("BPMSoft.ColumnExpression", {
						columnPath: "SectionSchemaUId"
					})
				));
				var lookupConfig = {
					entitySchemaName: "SysModule",
					multiSelect: false,
					columns: ["SysModuleEntity.SysEntitySchemaUId"],
					filters: filters
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
				var selectedRows = config.selectedRows;
				var selectedRow = selectedRows.getItems()[0];
				this.addSection(selectedRow);
			},

			/**
			 * ######### ###### # ########.
			 * @protected
			 * @virtual
			 */
			addSection: function() {
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
							return (this.notConfigurableModels.indexOf(model) === -1);
						}
					}
				};
				return Ext.create("BPMSoft.BaseViewModel", viewModelConfig);
			},

			/**
			 * ######### ###### #######.
			 * @protected
			 * @virtual
			 */
			loadGridData: function() {
				var sectionList = this.designerApplicationManifest.getModuleList();
				for (var i = (sectionList.length - 1); i >= 0; i--) {
					var sectionConfig = sectionList[i];
					if (this.notConfigurableModels.indexOf(sectionConfig.Model) >= 0) {
						sectionList.splice(i, 1);
					}
				}
				var sectionViewModelCollection = this.createSectionViewModelCollection(sectionList);
				var gridData = this.get("GridData");
				gridData.clear();
				gridData.loadAll(sectionViewModelCollection);
			},

			/**
			 * ############ ############ ### ############## ###### #######.
			 * @protected
			 * @virtual
			 */
			onCollapsedChanged: function() {},

			/**
			 * ######### ########, ########### ##### ###########.
			 */
			onRender: function() {
				this.workplace = this.sandbox.publish("GetWorkplace");
				if (!this.mobileDesignerSchemaManager) {
					this.initializeMobileDesignerUtils(function() {
						this.loadGridData();
					});
				} else {
					this.loadGridData();
				}
			}
		});

		/**
		 * @class BPMSoft.configuration.MobileWorkplaceSectionsModule
		 * ##### ###### ######## ######## #####.
		 */
		Ext.define("BPMSoft.configuration.MobileWorkplaceSectionsModule", {
			alternateClassName: "BPMSoft.MobileWorkplaceSectionsModule",
			extend: "BPMSoft.BaseModule",

			Ext: null,
			sandbox: null,
			BPMSoft: null,

			/**
			 * ####### ############# ######.
			 * @type {Boolean}
			 */
			isAsync: true,

			/**
			 * ############## ######### ######## ######.
			 * @protected
			 * @virtual
			 * @param {Function} callback #######, ####### ##### ####### ## ##########.
			 * @param {Object} scope ########, # ####### ##### ####### ####### callback.
			 */
			init: function(callback, scope) {
				this.initMessages();
				this.initViewConfig(function() {
					this.initViewModel(function() {
						Ext.callback(callback, scope);
					}, this);
				}, this);
			},

			/**
			 * ############# ######## ## ######### ######.
			 * @private
			 */
			initMessages: function() {
				this.sandbox.subscribe("RerenderModule", function(config) {
					if (this.viewModel) {
						this.render(this.Ext.get(config.renderTo));
						return true;
					}
				}, this, [this.sandbox.id]);
			},

			/**
			 * ############## ###### ############ ############# ######.
			 * @protected
			 * @abstract
			 * @param {Function} callback #######, ####### ##### ####### ## ##########.
			 * @param {Object} scope ########, # ####### ##### ####### ####### callback.
			 */
			initViewConfig: function(callback, scope) {
				this.buildView(function(view) {
					this.viewConfig = view[0];
					Ext.callback(callback, scope);
				}, this);
			},

			/**
			 * ############## ###### ############# ######.
			 * @protected
			 * @abstract
			 * @param {Function} callback #######, ####### ##### ####### ## ##########.
			 * @param {Object} scope ########, # ####### ##### ####### ####### callback.
			 */
			initViewModel: function(callback, scope) {
				var viewModel = this.viewModel = Ext.create("BPMSoft.MobileWorkplaceSectionsViewModel", {
					sandbox: this.sandbox
				});
				viewModel.init(function() {
					if (!this.destroyed) {
						Ext.callback(callback, scope);
					}
				}, this);
			},

			/**
			 * ####### ############# ######.
			 * @protected
			 * @virtual
			 * @return {BPMSoft.Component} ############# ######.
			 */
			createView: function() {
				var viewConfig = BPMSoft.deepClone(this.viewConfig);
				return Ext.create(viewConfig.className, viewConfig);
			},

			/**
			 * ########## ###### ############ #############.
			 * @protected
			 * @virtual
			 * @return {Object} ###### ############ #############.
			 */
			getViewConfig: function() {
				var viewGenerator = Ext.create("BPMSoft.MobileWorkplaceSectionsViewConfig");
				return viewGenerator.generate();
			},

			/**
			 * ####### ############ ############# ######.
			 * @protected
			 * @virtual
			 * @param {Function} callback #######, ####### ##### ####### ## ##########.
			 * @param {Object} scope ########, # ####### ##### ####### ####### callback.
			 */
			buildView: function(callback, scope) {
				var viewGenerator = Ext.create("BPMSoft.ViewGenerator");
				var schema = {
					viewConfig: this.getViewConfig()
				};
				var viewConfig = {
					schema: schema,
					viewModelClass: BPMSoft.MobileWorkplaceSectionsViewModel
				};
				viewGenerator.generate(viewConfig, callback, scope);
			},

			/**
			 * ######### ######### ######.
			 * @protected
			 * @virtual
			 * @param {Object} renderTo ######### ###### ## Ext.Element # ####### ##### ########### ####### ##########.
			 */
			render: function(renderTo) {
				var viewModel = this.viewModel;
				var view = this.view;
				if (!view || view.destroyed) {
					view = this.view = this.createView();
					view.bind(viewModel);
					view.render(renderTo);
				} else {
					view.reRender(0, renderTo);
				}
				viewModel.renderTo = renderTo.id;
				viewModel.onRender();
			}
		});
		return BPMSoft.configuration.MobileWorkplaceSectionsModule;
	});
