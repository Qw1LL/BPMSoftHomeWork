/**
 * Module for BaseWorkplaceLoader.
 */
define("BaseWorkplaceLoader", ["BaseWorkplaceLoaderResources", "sandbox", "SchemaBuilderV2", "MiniPageListener"
], function(resources, sandbox) {

	/**
	 * @private
	 */
	function hasModule(workplaceModules, sectionItem) {
		var has = false;
		if (workplaceModules && sectionItem) {
			BPMSoft.each(workplaceModules, function(item) {
				if (item.sectionName === sectionItem.sectionSchema ||
					item.sectionName === sectionItem.sectionModule) {
					has = true;
					return false;
				}
			}, this);
		}
		return has;
	}

	/**
	 * @private
	 */
	function setModulePosition(workplaceModules, sectionItem) {
		if (workplaceModules && sectionItem) {
			BPMSoft.each(workplaceModules, function(item) {
				if (item.sectionName === sectionItem.sectionSchema ||
					item.sectionName === sectionItem.sectionModule) {
					sectionItem.position = item.position;
					return false;
				}
			}, this);
		}
	}

	/**
	 * @private
	 */
	function resetMenuByWorkplaceId(workplace) {
		var structure = BPMSoft.configuration.ModuleStructure;
		if (structure) {
			BPMSoft.each(structure, function(item) {
				if (hasModule(workplace.modules, item)) {
					item.hide = "false";
					setModulePosition(workplace.modules, item);
				} else {
					item.hide = "true";
				}
			}, this);
		}
	}

	/**
	 * @private
	 */
	function hasSchemaDescriptor(schemaName) {
		const descriptors = BPMSoft.configuration.RootSchemaDescriptors;
		return descriptors ? descriptors.hasOwnProperty(schemaName) : true;
	}

	/**
	 * @private
	 */
	function canSectionBeWarmedUp(schemaName, module) {
		if (module.sectionModule === "SectionSchemaViewModule") {
			return false;
		}
		return schemaName && !JSON.parse(module.hide) && hasSchemaDescriptor(schemaName);
	}

	/**
	 * @private
	 */
	function warmUpSections() {
		var schemaNames = [];
		BPMSoft.each(BPMSoft.configuration.ModuleStructure, function(module) {
			const schemaName = module.sectionSchema;
			if (canSectionBeWarmedUp(schemaName, module)) {
				schemaNames.push(schemaName);
			}
		});
		BPMSoft.eachAsync(schemaNames, function(schemaName, next) {
			BPMSoft.defer(function() {
				var schemaBuilder = Ext.create("BPMSoft.SchemaBuilder");
				schemaBuilder.build({
					schemaName: schemaName,
					profileKey: schemaName + "GridSettingsGridDataView"
				}, next, this);
			}, this);
		}, BPMSoft.emptyFn, this);
	}

	/**
	 * @private
	 */
	function warmUpMiniPages() {
		var schemaNames = [];
		BPMSoft.each(BPMSoft.configuration.ModuleStructure, function(module) {
			const schemaName = module.miniPageSchema;
			if (schemaName && !JSON.parse(module.hide) && hasSchemaDescriptor(schemaName)) {
				schemaNames.push(module.miniPageSchema);
			}
		});
		BPMSoft.eachAsync(schemaNames, function(schemaName, next) {
			BPMSoft.defer(function() {
				var schemaBuilder = Ext.create("BPMSoft.SchemaBuilder");
				schemaBuilder.build({schemaName: schemaName}, next, this);
			}, this);
		}, BPMSoft.emptyFn, this);
	}

	/**
	 * @private
	 */
	function load(args) {
		resetMenuByWorkplaceId(args);
		var sectionMenuConfig = {
			...args
		};
		sandbox.publish("PostSectionMenuConfig", sectionMenuConfig, ["SectionMenuModuleId"]);
		sandbox.subscribe("GetSectionMenuInfo", function(moduleId) {
			sandbox.publish("PostSectionMenuConfig", sectionMenuConfig, [moduleId]);
		});
	}

	/**
	 * @private
	 */
	function init() {
		var args = sandbox.publish("GetWorkplaceInfo");
		load(args);
		if (BPMSoft.Features.getIsEnabled("DisableWarmUpSections")) {
			return;
		}
		BPMSoft.delay(function() {
			warmUpSections();
		}, this, 2000);
	}

	return {
		init: init,
		load: load
	};
});
