define("IntroPage", ["performancecountermanager", "MaskHelper", "BaseSchemaModuleV2", "ContextHelpMixin"],
	function(performanceManager, MaskHelper) {
		/**
		 * @class BPMSoft.configuration.IntroPage
		 * ##### ###### ####### ########.
		 */
		Ext.define("BPMSoft.configuration.IntroPage", {
			alternateClassName: "BPMSoft.IntroPage",
			extend: "BPMSoft.BaseSchemaModule",
			mixins: {
				ContextHelpMixin: "BPMSoft.ContextHelpMixin"
			},

			/**
			 * ############# ## ######### ### ######### ########## ##### ##########.
			 * @overridden
			 */
			init: function() {
				performanceManager.start(this.sandbox.id + "_Init");
				var headerConfig = {
					isMainMenu: true,
					isCaptionVisible: false,
					isContextHelpVisible: true
				};
				this.initContextHelp();
				this.sandbox.publish("InitDataViews", headerConfig);
				this.sandbox.subscribe("NeedHeaderCaption", function() {
					this.sandbox.publish("InitDataViews", headerConfig);
				}, this);
				this.callParent(arguments);
				performanceManager.stop(this.sandbox.id + "_Init");
			},

			render: function() {
				performanceManager.start(this.sandbox.id + "_Render");
				this.callParent(arguments);
				this.sandbox.publish("InitContextHelp", {
					contextHelpCode: this.schemaName
				});
				performanceManager.stop(this.sandbox.id + "_Render");
				if (BPMSoft.Features.getIsDisabled('DisableHomePageInWorkplace')) {
					MaskHelper.hideBodyMask();
				}
			}
		});
		return BPMSoft.IntroPage;
	});
