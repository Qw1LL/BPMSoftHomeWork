define("DashboardsModule", ["BaseSchemaModuleV2", "DashboardBuilder"],
	function() {

		/**
		 * @class BPMSoft.configuration.DashboardModule
		 * ##### ########### ###### ######.
		 */
		return Ext.define("BPMSoft.configuration.DashboardsModule", {
			extend: "BPMSoft.BaseSchemaModule",
			alternateClassName: "BPMSoft.DashboardsModule",

			Ext: null,
			sandbox: null,
			BPMSoft: null,

			messages: {
				/**
				 * @message NeedHeaderCaption
				 * Gets header parameters request.
				 */
				"NeedHeaderCaption": {
					mode: this.BPMSoft.MessageMode.BROADCAST,
					direction: this.BPMSoft.MessageDirectionType.BIDIRECTIONAL
				},

				/**
				 * @message SelectedSideBarItemChanged
				 * Modifies the selection of the current section in the menu of sections in the left panel.
				 * @param {String} Structure of section (E.g. "SectionModuleV2/AccountPageV2/" or "DashboardsModule/").
				 */
				 "SelectedSideBarItemChanged": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message ContextHelpModuleLoaded
				 * Notify about the ContextHelpModule is loaded.
				 */
				"ContextHelpModuleLoaded": {
					mode: this.BPMSoft.MessageMode.BROADCAST,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},

			viewModelClassName: "BPMSoft.BaseDashboardsViewModel",

			builderClassName: "BPMSoft.DashboardBuilder",

			viewConfigClass: "BPMSoft.DashboardsViewConfig",

			/**
			 * ########## #### ####### ### ###### ######.
			 * @overridden
			 * @protected
			 * @return {String} ######### #### ####### ### ###### ######.
			 */
			getProfileKey: function() {
				return "DashboardId";
			},

			/**
			 * ####### ############# ##### ##### ######.
			 * @overridden
			 * @protected
			 */
			initSchemaName: BPMSoft.emptyFn,

			/**
			 * @private
			 */
			createDashboardProfileKey: function() {
				const historyState = this.sandbox.publish("GetHistoryState");
				const keyTpl = "Dashboards_{0}_{1}";
				const key = Ext.String.format(keyTpl, historyState.hash.moduleName, historyState.hash.entityName);
				return key;
			},

			/**
			 * Returns dashboard section id.
			 * @protected
			 * @virtual
			 * @return {String} Dashboard section id.
			 */
			getDashboardSectionId: function() {
				return BPMSoft.configuration.ModuleStructure.Dashboard.moduleId;
			},

			/**
			 * @private
			 */
			getDashboardSchemaBuilderConfig: function() {
				return {
					sectionId: this.getDashboardSectionId(),
					dashboardProfileKey: this.createDashboardProfileKey()
				};
			},

			/**
			 * @inheritDoc BPMSoft.configuration.BaseSchemaModule#generateSchemaStructure
			 * @overridden
			 */
			generateSchemaStructure: function(callback, scope) {
				const builder = Ext.create(this.builderClassName, {
					viewModelClass: this.viewModelClassName,
					viewConfigClass: this.viewConfigClass
				});
				const config = this.getDashboardSchemaBuilderConfig();
				builder.build(config, function(viewModelClass, view) {
					callback.call(scope, viewModelClass, view);
				}, this);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaModule#destroy
			 * @overridden
			 */
			destroy: function() {
				this.callParent(arguments);
				this.sandbox.unRegisterMessages(this.messages);
				this.renderContainer = null;
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaModule#init
			 * @overridden
			 */
			init: function() {
				this.callParent(arguments);
				this.sandbox.registerMessages(this.messages);
				this.sandbox.subscribe("NeedHeaderCaption", function() {
					if (this.viewModel && this.viewModel.initHeader) {
						this.viewModel.initHeader();
					}
				}, this);
				const historyState = this.sandbox.publish("GetHistoryState").hash.historyState;
				this.sandbox.publish("SelectedSideBarItemChanged", historyState, ["sectionMenuModule"]);
			}

		});

	});
