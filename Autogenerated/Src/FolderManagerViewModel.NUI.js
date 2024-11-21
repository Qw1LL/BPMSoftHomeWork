define("FolderManagerViewModel", ["FolderManagerViewModelConfigGenerator"],
	function() {
		return {
			generate: function(parentSandbox, config) {
				var generator = Ext.create("BPMSoft.FolderManagerViewModelConfigGenerator");
				return generator.generate(parentSandbox, config);
			},
			getFolderViewModelConfig: function() {
				return {};
			}
		};
	});
