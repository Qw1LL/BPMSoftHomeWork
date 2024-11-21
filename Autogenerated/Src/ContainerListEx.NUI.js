define("ContainerListEx", ["ContainerList"], function() {
	/**
	 * ##### ######### ########### ######### ######### ## ####### ##########.
	 * ########### ######, # ############ ########## ######### #####
	 */
	Ext.define("BPMSoft.controls.ContainerListEx", {
		extend: "BPMSoft.ContainerList",
		alternateClassName: "BPMSoft.ContainerListEx",

		/**
		 * ####### ########## ######## ####### # ######
		 * @protected
		 * @type {Boolean}
		 */
		isAsync: false,

		/**
		 * ####### # ############## #######
		 * @protected
		 * @type {String}
		 */
		endIdPrefix: "END",

		/**
		 * ############# ######### ###########, ########## ##############
		 * @protected
		 */
		decorateView: function(items, id, prefix) {
			var decoratePrefixStr = Ext.String.format("-{0}-{1}-{2}", id, this.endIdPrefix, prefix);
			BPMSoft.each(items, function(item) {
				if (item.id) {
					item.id += decoratePrefixStr;
				}
				var selectors = item.selectors;
				if (selectors && selectors.wrapEl) {
					selectors.wrapEl += decoratePrefixStr;
				}
				var classes = item.classes;
				if (classes) {
					classes.wrapClassName = classes.wrapClassName || [];
					if (item.id) {
						classes.wrapClassName.push(item.id);
					}
				}
				if (item.items) {
					this.decorateView(item.items, id, prefix);
				}
			}, this);
		}
	});
	return BPMSoft.ContainerListEx;
});
