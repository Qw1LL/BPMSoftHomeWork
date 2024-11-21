define("FolderGridRowViewModel", ["ConfigurationConstants"], function(ConfigurationConstants) {
	return Ext.define("BPMSoft.FolderGridRowViewModel", {
		extend: "BPMSoft.BaseViewModel",

		/**
		 * Check is section support static folders and folder is search
		 * @returns {boolean} return true when folder is search and section support static folders
		 */
		isConvertFolderButtonVisible: function() {
			var useStaticFolder = this.get("useStaticFolders");
			return useStaticFolder && this.isSearchFolderFolder();
		},

		/**
		 * Check is folder search type
		 * @returns {boolean} return true when is 
		 */
		isSearchFolderFolder: function() {
			var folderType = this.get("FolderType");
			return folderType && folderType.value ===
				ConfigurationConstants.Folder.Type.Search;
		}
	});
});