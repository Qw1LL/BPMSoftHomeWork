define("CtiProviderInitializer", ["ext-base", "CtiProviderInitializerResources", "core-base", "BPMSoft"],
	function(Ext, resources, core, BPMSoft) {
		return {
			/**
			 * ############ ########### ### cti-########## #########.
			 * @protected
			 * @param {BPMSoft.BaseCtiProvider} ctiProvider cti-#########
			 * @param {String} ctiProviderName ######## ###### cti-##########.
			 * @param {Function} callback ####### ######### ######.
			 */
			initCustomCtiProvider: function(ctiProvider, ctiProviderName, callback) {
				callback(ctiProvider);
			},

			/**
			 * ############## cti-######### # ######## ####### ######### ######.
			 * @param {String} ctiProviderName ######## ###### cti-##########.
			 * @param {Function} callback ####### ######### ######.
			 */
			initializeCtiProvider: function(ctiProviderName, callback) {
				var ctiProvider = BPMSoft[ctiProviderName];
				if (Ext.isEmpty(ctiProvider)) {
					require([ctiProviderName], function() {
						ctiProvider = BPMSoft[ctiProviderName];
						this.initCustomCtiProvider(ctiProvider, ctiProviderName, callback);
					}.bind(this));
				} else {
					this.initCustomCtiProvider(ctiProvider, ctiProviderName, callback);
				}
			}
		};
	}
);
