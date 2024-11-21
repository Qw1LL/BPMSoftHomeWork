define("FolderManager", ["ext-base", "BPMSoft", "sandbox", "BaseFolderManager"],
		function(Ext, BPMSoft, sandbox) {

			var folderManager = Ext.create("BPMSoft.BaseFolderManager", {
				sandbox: sandbox
			});

			return {
				render: folderManager.render.bind(folderManager),
				init: folderManager.init.bind(folderManager)
			};
		});
