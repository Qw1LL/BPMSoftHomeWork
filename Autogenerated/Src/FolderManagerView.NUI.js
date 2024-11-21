define("FolderManagerView", ["FolderManagerViewConfigGenerator"], function() {
	return {
		generate: function() {
			var folderManagerViewConfigGenerator = Ext.create("BPMSoft.FolderManagerViewConfigGenerator");
			return folderManagerViewConfigGenerator.generate();
		}
	};
});
