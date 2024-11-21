define("RightSideBarModule", ["RightSideBarModuleResources", "ViewUtilities", "BaseModule"],
	function(resources, ViewUtilities) {

		/**
		 * @class BPMSoft.configuration.RightSideBarModule
		 * ##### RightSideBarModule ############ ### ######## ########## ###### ####### ######
		 */
		var rightSideBarModule = Ext.define("BPMSoft.configuration.RightSideBarModule", {
			extend: "BPMSoft.BaseModule",
			alternateClassName: "BPMSoft.RightSideBarModule",
			Ext: null,
			sandbox: null,
			BPMSoft: null,

			/**
			 * Forms configuration of view.
			 * @protected
			 * @virtual
			 * @return {Object} Returns configuration of view.
			 */
			getViewConfig: function() {
				var rightPanelModulesContainer = ViewUtilities.getContainerConfig("rightPanelModulesContainer",
					["right-panel-modules-container"]);
				return {
					id: "rightSideBarContainer",
					selectors: {wrapEl: "#rightSideBarContainer"},
					classes: {wrapClassName: ["right-side-bar-container"]},
					items: [rightPanelModulesContainer]
				};
			},

			/**
			 * Creates view object.
			 * @protected
			 * @virtual
			 * @return {BPMSoft.Container} Returns instance of view container.
			 */
			getView: function() {
				return this.Ext.create("BPMSoft.Container", this.getViewConfig());
			},

			/**
			 * Creates view nodel object.
			 * @protected
			 * @return {BPMSoft.BaseViewModel} View model.
			 */
			getViewModel: function() {
				var viewModel = this.Ext.create("BPMSoft.BaseViewModel", {
					values: {
						/**
						 * ###### ########## ########### ########### #######.
						 * @private
						 * @type {String}
						 */
						wrapContainerNamePattern: "{0}_WrapContainer"
					},
					methods: {

						/**
						 * ############## ######### ######.
						 * @private
						 */
						init: function() {
							this.sandbox.subscribe("CommunicationPanelItemSelected",
								this.onCommunicationPanelItemSelected, this);
						},

						/**
						 * ############ ####### ###### ######## #### ######.
						 * @virtual
						 * @param {Object} itemConfig ############ ######## #### ######.
						 * @example
						 * ### ####### ###### #########/############ ########### #########.
						 * ###### ## ####### ##### #### keepAlive.
						 * # ###### ###### #### #### ######### ## ##, ### ##### ## ######## ###### ### ##### #########
						 * ##########.
						 *
						 * ##### ######## SampleAliveModule (keepAlive == true), ##### ########## ###### ######
						 * AnotherModule (keepAlive == false). # ########## # ### ##### ##### ######### ####### ######,
						 * ## ### ###### ##### ######## # ########### ## #######, # ###### - ########## # #########.
						 * #####, ########## ##### ###### ######. # ########## ######### ####### ###### ##### #########,
						 * # ######### ####### - #####, ## ### ### ###### ###### keepAlive = false, ## ## #####
						 * ########. ### ########### ######### ####### ###### ##### ############ ######### ### ########
						 * # ############ ### #### #########.
						 */
						onCommunicationPanelItemSelected: function(itemConfig) {
							var moduleName = itemConfig.moduleName;
							var keepAlive = itemConfig.keepAlive;
							var previousItemConfig = itemConfig.previousItemConfig || {};
							var previousModuleName = previousItemConfig.moduleName;
							var wrapContainerNamePattern = this.get("wrapContainerNamePattern");
							var moduleContainer =
								Ext.getCmp(Ext.String.format(wrapContainerNamePattern, moduleName));
							var previousModuleContainer =
								Ext.getCmp(Ext.String.format(wrapContainerNamePattern, previousModuleName));
							if (!Ext.isEmpty(previousModuleName) && !Ext.isEmpty(previousModuleContainer)) {
								if (!previousItemConfig.keepAlive) {
									this.sandbox.unloadModule(this.sandbox.id + "_" + previousModuleName);
								}
								previousModuleContainer.wrapEl.addCls("hidden");
							}
							var reloadModule = !keepAlive;
							if (!Ext.isEmpty(moduleContainer)) {
								moduleContainer.wrapEl.removeCls("hidden");
							} else {
								moduleContainer = Ext.create("BPMSoft.Container", {
									id: Ext.String.format(wrapContainerNamePattern, moduleName)
								});
								var rightPanelModulesContainer = Ext.getCmp("rightPanelModulesContainer");
								rightPanelModulesContainer.add(moduleContainer);
								moduleContainer.wrapEl.addCls("communication-panel-item-container");
								if (itemConfig.loadHidden === true) {
									moduleContainer.wrapEl.addCls("hidden");
								}
								reloadModule = true;
							}
							if (reloadModule) {
								this.sandbox.loadModule(moduleName, {
									renderTo: Ext.String.format(wrapContainerNamePattern, moduleName)
								});
							}
						}
					}
				});
				viewModel.Ext = this.Ext;
				viewModel.sandbox = this.sandbox;
				viewModel.BPMSoft = this.BPMSoft;
				return viewModel;
			},

			/**
			 * ######### ########## ###### # #########.
			 * @private
			 * @param {Ext.Element} renderTo ######### ###### ## {@link Ext.Element} # ####### ##### ###########
			 * ####### ##########.
			 */
			render: function(renderTo) {
				var view = this.getView();
				var viewModel = this.getViewModel(this);
				view.bind(viewModel);
				view.render(renderTo);
				viewModel.init();
			}
		});
		return rightSideBarModule;
	});
