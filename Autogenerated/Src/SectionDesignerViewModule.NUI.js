define("SectionDesignerViewModule", ["ext-base", "sandbox", "BPMSoft", "BaseViewModule", "ConfigurationViewModule"],
	function(Ext, sandbox, BPMSoft) {

		/**
		 * @class BPMSoft.configuration.ViewModule
		 * Visual view module class for section designer
		 */
		Ext.define("BPMSoft.configuration.SectionDesignerViewModule", {
			extend: "BPMSoft.ConfigurationViewModule",
			alternateClassName: "BPMSoft.SectionDesignerViewModule",

			diff: [{
				"operation": "remove",
				"name": "leftPanel"
			}, {
				"operation": "remove",
				"name": "communicationPanel"
			}, {
				"operation": "remove",
				"name": "rightPanel"
			}, {
				"operation": "remove",
				"name": "mainHeader"
			}],

			/**
			 * @inheritDoc BPMSoft.configuration.BaseViewModule#init
			 * @overridden
			 */
			render: function(renderTo) {
				renderTo.addCls("section-designer-shown");
				this.callParent(arguments);
			},

			/**
			 * @inheritDoc BPMSoft.ConfigurationViewModule#prepareDemoLinkButtons
			 * @overridden
			 */
			prepareDemoLinkButtons: BPMSoft.emptyFn,

			/**
			 * @inheritDoc BPMSoft.configuration.ConfigurationViewModule#onSideBarModuleDefInfo
			 * @overridden
			 */
			onSideBarModuleDefInfo: BPMSoft.emptyFn,

			/**
			 * @inheritDoc BPMSoft.configuration.BaseViewModule#loadModuleFromHistoryState
			 * @overridden
			 */
			loadModuleFromHistoryState: function(token) {
				var moduleName = this.getModuleName(token);
				if (!moduleName) {
					return;
				}
				this.onStateChanged();
				this.sandbox.loadModule(moduleName, { renderTo: "centerPanel" });
			}

		});

		return BPMSoft.SectionDesignerViewModule;
	});
