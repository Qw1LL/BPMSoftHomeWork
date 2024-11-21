define("BaseModule", ["ext-base"], function(Ext) {

	/**
	 * The base class of the module.
	 */
	Ext.define("BPMSoft.configuration.BaseModule", {
		extend: "BPMSoft.core.BaseObject",
		alternateClassName: "BPMSoft.BaseModule",

		/**
		 * Ext framework.
		 * @type {Object}.
		 */
		Ext: null,

		/**
		 * Sandbox.
		 * @type {Object}.
		 */
		sandbox: null,

		/**
		 * BPMSoft framework.
		 * @type {Object}
		 */
		BPMSoft: null,

		/**
		 * ############# ########## ######.
		 * type {String}
		 */
		renderToId: null,

		/**
		 * ####### ############# ##### ######## ### ######## ######.
		 * type {Boolean}
		 */
		showMask: false,

		/**
		 * ############# ##### ######## ######.
		 * @private
		 * type {String}
		 */
		maskId: null,

		/**
		 * ######### ######## ######.
		 * @type {Object}
		 * @protected
		 */
		parameters: null,

		/**
		 * ########## ##### ######## ######.
		 * @protected
		 */
		showLoadingMask: function() {
			if (this.showMask && this.renderToId) {
				this.maskId = BPMSoft.Mask.show({
					selector: Ext.String.format("#{0}", this.renderToId)
				});
			}
		},

		/**
		 * ######## ##### ######## ######.
		 * @protected
		 */
		hideLoadingMask: function() {
			if (this.maskId && this.showMask) {
				BPMSoft.Mask.hide(this.maskId);
				this.maskId = null;
			}
		},

		/**
		 * @inheritDoc BPMSoft.core.BaseObject#init
		 * @overridden
		 */
		init: function() {
			this.showLoadingMask();
		},

		/**
		 * ######### ####### ########## ######.
		 */
		render: function() {
			this.hideLoadingMask();
		},

		/**
		 * @inheritDoc BPMSoft.core.BaseObject#onDestroy
		 * @overridden
		 */
		onDestroy: function() {
			this.hideLoadingMask();
			this.callParent(arguments);
		}

	});

	return BPMSoft.BaseModule;
});
