define("SectionEntitySelectMixin", ["ext-base", "BPMSoft", "SectionInWorkplaceManager"], function(Ext, BPMSoft) {
	Ext.define("BPMSoft.configuration.mixins.SectionEntitySelectMixin", {
		alternateClassName: "BPMSoft.SectionEntitySelectMixin",

		//region Methods: Public

		/**
		 * Returns not virtual entity schema list for current package sorted by caption.
		 * @param {Function} callback Callback function.
		 * @param {BPMSoft.Collection} callback.items Entity schema list.
		 * @param {Object} scope Execution scope.
		 */
		getEntitySchemaList: function(callback, scope) {
			BPMSoft.chain(
				function(next) {
					BPMSoft.SectionInWorkplaceManager.initialize(null, next, this);
				},
				function() {
					var packageUId = this.get("packageUId");
					BPMSoft.EntitySchemaManager.findPackageItems(packageUId, callback, scope);
				},
				this
			);
		},

		/**
		 * Filters entities by registered section modules.
		 * @param {BPMSoft.core.collections.Collection} entityList Entity collection.
		 * @return {BPMSoft.core.collections.Collection}
		 */
		filterEntityListBySections: function(entityList) {
			var modules = BPMSoft.configuration.ModuleStructure;
			var sections = BPMSoft.SectionInWorkplaceManager.items.getItems();
			return entityList.filter(function(entity) {
				var module = modules[entity.name];
				return module && sections.some(function(item) {
						return item.section.value === module.moduleId;
					});
			});
		}

		//endregion
	});
});
