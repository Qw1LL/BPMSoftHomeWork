define("FolderManager", [
	"FolderManagerResources", "ConfigurationConstants", "MaskHelper", "BaseSchemaModuleV2",
	"ProductCatalogueFolderManagerViewModel"
], function(resources, ConfigurationConstants, MaskHelper) {
	/**
	 * ##### FolderManager ############ ### ######## ###### #####
	 */
	Ext.define("BPMSoft.configuration.FolderManager", {
		alternateClassName: "BPMSoft.FolderManager",
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
		 * ############ ############# ######### #####
		 * @private
		 * @type {Object}
		 */
		FolderManagerView: null,

		/**
		 * ############ ###### ############# ######### #####
		 * @private
		 * @type {Object}
		 */
		FolderManagerViewModel: null,

		/**
		 * ######### ######
		 */
		messages: {
			/**
			 * @message FolderInfo
			 * ########### ############ ### ############# ###### #####
			 */
			"FolderInfo": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message AddFolderActionFired
			 * ######### ########## ##### ######
			 */

			"AddFolderActionFired": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message UpdateFavoritesMenu
			 * ######### ########## #### #########
			 */
			"UpdateFavoritesMenu": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message ResultSelectedFolders
			 * ######### ###### ## ######### ######
			 */
			"ResultSelectedFolders": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message BackHistoryState
			 * ######### ######## ## ####### #########
			 */
			"BackHistoryState": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message PushHistoryState
			 * ######### ######### # ####### #########
			 */
			"PushHistoryState": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message CustomFilterExtendedMode
			 * ######### ############ #### ################ ##########
			 */
			"CustomFilterExtendedMode": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message UpdateCustomFilterMenu
			 * ######### ########## #### ################ ##########
			 */
			"UpdateCustomFilterMenu": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message GetRecordInfo
			 * ######### ########### ############ ######
			 */
			"GetRecordInfo": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message GetHistoryState
			 * ######### ########### ####### ############ ####### ######### ######
			 */
			"GetHistoryState": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message HideFolderTree
			 * ######### ######## ###### #####
			 */
			"HideFolderTree": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message ResultFolderFilter
			 * ######### ########### ############## ######### ########
			 */
			"ResultFolderFilter": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message UpdateFilter
			 * ######### ######### ####### #####
			 */
			"UpdateFilter": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message LookupInfo
			 * ### ###### LookupUtilities
			 */
			"LookupInfo": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message ResultSelectedRows
			 * ######### ########## ######### ######
			 */
			"ResultSelectedRows": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message UpdateCatalogueFilter
			 * ######### ######### ####### ########
			 */
			"UpdateCatalogueFilter": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message CloseExtendCatalogueFilter
			 * ######### ######## ###### ########### ########## #########
			 */
			"CloseExtendCatalogueFilter": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message GetExtendCatalogueFilterInfo
			 * ######### ########## ############ ### ###### ########### ########## #########
			 */
			"GetExtendCatalogueFilterInfo": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message UpdateExtendCatalogueFilter
			 * ######### ######### ####### ###### ########### ########## #########
			 */
			"UpdateExtendCatalogueFilter": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},

		/**
		 * @private
		 */
		_setGroupPageCaption: function(sectionSchema) {
			if (sectionSchema) {
				var currentModule = this.BPMSoft.configuration.ModuleStructure[sectionSchema.name];
				if (currentModule) {
					var headerName = this.Ext.String.format("{0} {1}",
							resources.localizableStrings.StaticCaptionPartHeaderGroupV2, currentModule.moduleCaption);
					this.viewModel.set("GroupPageCaption", headerName);
				}
			}
		},

		/**
		 * @private
		 */
		_initViewModel: function() {
			if (!this.viewModel) {
				var viewModelConfig = this.FolderManagerViewModel.generate(this.sandbox, this.config);
				var className = this.config.folderManagerViewModelClassName ||
						"BPMSoft.BaseViewModel";
				this.viewModel = this.Ext.create(className, viewModelConfig);
				this.viewModel.init(this.config);
			} else {
				this.viewModel.resetFolderView();
			}
		},

		/**
		 * Registers mmessages in sandbox.
		 * @protected
		 */
		registerMessages: function() {
			this.sandbox.registerMessages(this.messages);
		},

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#init
		 * @override
		 */
		init: function(callback, scope) {
			this.registerMessages();
			this.config = this.sandbox.publish("FolderInfo", null, [this.sandbox.id]);
			this.config.enableMultiSelect = true;
			if (this.config.currentFilter) {
				this.config.enableMultiSelect = true;
				this.config.selectedFolders = [this.config.currentFilter];
				this.config.currentFilter = null;
				this.config.multiSelect = true;
			}
			if (!this.config.folderFilterViewId) {
				this.config.folderFilterViewId = "FolderManagerView";
			}
			if (!this.config.folderFilterViewModelId) {
				this.config.folderFilterViewModelId = "FolderManagerViewModel";
			}
			this.config.allFoldersRecordItem = {
				value: BPMSoft.GUID_EMPTY,
				displayValue: resources.localizableStrings.AllFoldersCaptionV2
			};
			this.config.favoriteRootRecordItem = {
				value: BPMSoft.generateGUID(),
				displayValue: resources.localizableStrings.FavoriteFoldersCaptionV2
			};
			if (callback) {
				callback.call(scope || this);
			}
		},

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#render
		 * @override
		 */
		render: function(renderTo) {
			this.container = renderTo;
			if (this.config.entitySchema) {
				this.initializeModule();
			} else {
				this.sandbox.requireModuleDescriptors([this.config.entitySchemaName], function() {
					this.BPMSoft.require([this.config.entitySchemaName], function(schema) {
						this.config.entitySchema = schema;
						this.initializeModule();
					}, this);
				}, this);
			}
		},

		/**
		 * Initializes folder manager view model.
		 * @protected
		 */
		initializeModule: function() {
			this.BPMSoft.require([this.config.folderFilterViewId, this.config.folderFilterViewModelId],
					function(filterView, filterViewModel) {
						this.FolderManagerView = filterView;
						this.FolderManagerView.sandbox = this.sandbox;
						this.FolderManagerViewModel = filterViewModel;
						this.FolderManagerViewModel.sandbox = this.sandbox;
						this.FolderManagerViewModel.renderTo = this.container;
						this._initViewModel();
						var viewConfig = this.FolderManagerView.generate(this.sandbox);
						this.view = this.Ext.create("BPMSoft.Container", viewConfig);
						this.view.bind(this.viewModel);
						var sectionSchema = this.config.sectionEntitySchema;
						this._setGroupPageCaption(sectionSchema);
						this.view.render(this.container);
						MaskHelper.HideBodyMask();
						var activeRow = this.config.activeFolderId;
						this.viewModel.setActiveRow(activeRow);
						this.sandbox.subscribe("AddFolderActionFired", function(config) {
							if (config.type === "generalFolder") {
								this.viewModel.addGeneralFolderButton();
							} else if (config.type === "searchFolder") {
								this.viewModel.addSearchFolderButton();
							} else {
								this.warn("Not implemented");
							}
						}, this);
					}, this);
		},

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#destroy
		 * @override
		 */
		destroy: function(config) {
			if (config.keepAlive !== true) {
				if (this.viewModel) {
					this.viewModel.destroy();
					this.viewModel = null;
				}
				this.callParent(arguments);
			}
		}
	});
	return BPMSoft.FolderManager;
});
