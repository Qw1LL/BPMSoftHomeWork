define("ConfigurationBootstrap", ["BPMSoft", "BootstrapModules", "BootstrapModulesV2"],
	function(BPMSoft, bootstrapModules) {
	require(["SectionBundleModule"]);
	var modulesNames = [];
	BPMSoft.each(bootstrapModules, function() {
		var moduleName = arguments[1];
		modulesNames.push(moduleName);
	});
	require(modulesNames, function() {
		BPMSoft.each(arguments, function(module) {
			if (module && module.init) {
				module.init();
			}
		});
	});
});
