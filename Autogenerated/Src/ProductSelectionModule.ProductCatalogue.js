define("ProductSelectionModule", ["ProductSelectionModuleResources", "ProductSelectionView",
	"ProductSelectionViewModel", "MaskHelper", "BaseSchemaModuleV2"],
	function(resources, moduleView, moduleViewModel, MaskHelper) {
		/**
		 * @class BPMSoft.configuration.ProductSelectionModule
		 * ##### ProductSelectionModule ############ ### ######## ###### ###### #########
		 */
		Ext.define("BPMSoft.configuration.ProductSelectionModule", {
			alternateClassName: "BPMSoft.ProductSelectionModule",
			extend: "BPMSoft.BaseSchemaModule",

			Ext: null,
			sandbox: null,
			BPMSoft: null,

			/**
			 * ######### ### ######### #####
			 * @private
			 * @type {Object}
			 */
			config: null,

			/**
			 * ######## ######### ### #########
			 * @private
			 * @type {Object}
			 */
			container: null,

			/**
			 * ######## ###### ######### ######
			 * @protected
			 * @type {Object}
			 */
			messages: null,

			/**
			 * ###### ############# ######### #####
			 * @private
			 * @type {Object}
			 */
			viewModel: null,

			/**
			 * ############# ###### ######### #####
			 * @private
			 * @type {Object}
			 */
			view: null,

			/**
			 * ############# ######.
			 * @param {Function} callback ####### ######### ######.
			 * @param {Object} scope ####### ###### ####### ######### ######.
			 */
			init: function(callback, scope) {
				MaskHelper.ShowBodyMask();
				this.registerMessages();
				this.config = this.sandbox.publish("ProductSelectionInfo", null, [this.sandbox.id]) || {};
				this.sandbox.requireModuleDescriptors(["Product"], function() {
					this.BPMSoft.require(["Product"], function(schema) {
						this.config.EntitySchema = schema;
						BPMSoft.SysSettings.querySysSettingsItem("BasePriceList",
							function(value) {
								this.config.BasePriceList = value;
								if (callback) {
									callback.call(scope || this);
								}
							}, this);
					}, this);
				}, this);
			},

			/**
			 * ######### ############ ######### ######
			 * @protected
			 */
			registerMessages: function() {
				var messages = {
					"ProductSelectionSave": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.PUBLISH
					},
					"ProductSelectionInfo": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.PUBLISH
					},
					"BackHistoryState": {
						mode: BPMSoft.MessageMode.BROADCAST,
						direction: BPMSoft.MessageDirectionType.PUBLISH
					},
					"FolderInfo": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},
					"ShowFolderManager": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},
					"ResultFolderFilter": {
						mode: BPMSoft.MessageMode.BROADCAST,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},
					"UpdateCatalogueFilter": {
						mode: BPMSoft.MessageMode.BROADCAST,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},
					"QuickSearchFilterInfo": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},
					"UpdateQuickSearchFilter": {
						mode: BPMSoft.MessageMode.BROADCAST,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},
					"UpdateQuickSearchFilterString": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.PUBLISH
					},
					"ChangeDataView": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					}
				};
				this.sandbox.registerMessages(messages);
			},

			/**
			 * ############ ############# ###### ######### #####.
			 * @param {Ext.Element} renderTo.
			 */
			render: function(renderTo) {
				this.container = renderTo;
				this.initializeModule();
			},

			/**
			 * ############## ###### ############# ###### ###### #########
			 * @protected
			 */
			initializeModule: function() {
				MaskHelper.ShowBodyMask();
				if (!this.viewModel) {
					var viewModelConfig = moduleViewModel.generate(this.sandbox, this.BPMSoft, this.Ext, this.config);
					var classConfig = {
						extend: "BPMSoft.BaseViewModel",
						alternateClassName: "BPMSoft.ProductSelectionViewModel",
						mixins: viewModelConfig.mixins,
						properties: viewModelConfig.properties
					};
					this.Ext.merge(classConfig, viewModelConfig.properties);
					delete viewModelConfig.mixins;
					this.Ext.define("BPMSoft.configuration.ProductSelectionViewModel", classConfig);
					this.viewModel = this.Ext.create("BPMSoft.configuration.ProductSelectionViewModel",
						viewModelConfig);
					this.viewModel.init(this.config);
				}
				var viewConfig = moduleView.generate();
				this.view = this.Ext.create("BPMSoft.Container", viewConfig);
				this.view.bind(this.viewModel);
				this.view.render(this.container);
				this.loadModules();
			},

			/**
			 * ######### ######
			 * @protected
			 */
			loadModules: function() {
				this.viewModel.loadFolderManager("foldersContainer");
				this.viewModel.loadQuickSearchModule("searchContainer");
			},

			/**
			 * ####### ### ######## ## ####### # ########## ######.
			 * @overridden
			 * @param {Object} config ######### ########### ######
			 */
			destroy: function(config) {
				if (config.keepAlive !== true) {
					if (this.viewModel) {
						this.viewModel.unRegisterMessages();
						this.viewModel = null;
					}
					this.callParent(arguments);
				}
			}
		});
		return BPMSoft.ProductSelectionModule;
	});
