define("SchemaAccessControllerMixin", ["ConfigurationConstants"], function(ConfigurationConstants) {
	/**
	 * @class BPMSoft.configuration.mixins.SchemaAccessControllerMixin
	 */
	Ext.define("BPMSoft.configuration.mixins.SchemaAccessControllerMixin", {
		alternateClassName: "BPMSoft.SchemaAccessControllerMixin",

		/**
		 * Redirect if has no access.
		 * @param {String} modulePropertyName Name of module property.
		 * @param {String} hashTemplate Template of hash.
		 * @return {Boolean} true - if successfully redirected.
		 */
		redirectIfDenied: function(modulePropertyName, hashTemplate) {
			const module = this.BPMSoft.ModuleUtils.getModuleStructureByName(this.entitySchemaName);
			const schemas = [];
			if (module) {
				if (Ext.isArray(module.pages)) {
					module.pages.map(function(page) {
						schemas.push(page.cardSchema);
					});
				}
				if (module[modulePropertyName]) {
					 schemas.push(module[modulePropertyName]);
				}
			}
			let hash = "";
			if (schemas.length === 0) {
				hash = ConfigurationConstants.DefaultPortalHomeModule;
			}
			if (!hash && schemas.indexOf(this.name) === -1) {
				hash = hashTemplate.replace(modulePropertyName, schemas[0]);
			}
			if (this.isNotEmpty(hash)) {
				this.sandbox.publish("ReplaceHistoryState", {hash: hash});
				return true;
			}
			return false;
		}
	});
});
