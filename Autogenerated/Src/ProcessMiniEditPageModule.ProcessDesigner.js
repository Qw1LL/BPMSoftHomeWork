define("ProcessMiniEditPageModule", ["BaseSchemaModuleV2"],
	function() {

		/**
		 * @class BPMSoft.ProcessDesigner.ProcessMiniEditPageModule
		 */
		Ext.define("BPMSoft.ProcessDesigner.ProcessMiniEditPageModule", {
			alternateClassName: "BPMSoft.ProcessMiniEditPageModule",
			extend: "BPMSoft.BaseSchemaModule",

			/**
			 * @inheritdoc BPMSoft.BaseSchemaModule#isSchemaConfigInitialized
			 * @overridden
			 */
			isSchemaConfigInitialized: true,

			/**
			 * @inheritdoc BPMSoft.BaseSchemaModule#useHistoryState
			 * @overridden
			 */
			useHistoryState: false,

			/**
			 * @inheritdoc BPMSoft.BaseSchemaModule#generateViewContainerId
			 * @overridden
			 */
			generateViewContainerId: false,

			/**
			 * @inheritdoc BPMSoft.BaseModule#render
			 * @overridden
			 */
			showMask: true,

			/**
			 * @inheritdoc BPMSoft.BaseSchemaModule#init
			 * @overridden
			 */
			init: function() {
				this.showLoadingMask();
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.configuration.BaseModule#getViewModelConfig
			 * @overridden
			 */
			showLoadingMask: function() {
				if (this.maskId) {
					return;
				}
				if (this.showMask && this.renderToId) {
					this.maskId = BPMSoft.Mask.show({
						selector: Ext.String.format("#{0}", this.renderToId),
						clearMasks: true
					});
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaModule#render
			 * @overridden
			 */
			render: function(renderTo) {
				this.callParent(arguments);
				this.hideLoadingMask();
				var container = this.Ext.get(renderTo);
				var el = container.dom;
				if (!this.isElementInViewport(el)) {
					el.scrollIntoView(false);
				}
			},

			/**
			 * Indicates whether element is visible entirely or not.
			 * @param {Object} el Dom element.
			 * @return {Boolean}
			 */
			isElementInViewport: function(el) {
				var rect = el.getBoundingClientRect();
				var height = window.innerHeight || document.documentElement.clientHeight;
				var width = window.innerWidth || document.documentElement.clientWidth;
				var result = rect.top >= 0 && rect.left >= 0 && rect.bottom <= height && rect.right <= width;
				return result;
			}
		});

		return BPMSoft.ProcessMiniEditPageModule;
	});
