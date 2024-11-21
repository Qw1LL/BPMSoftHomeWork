define("PortalFolderManagerViewModel", ["BPMSoft", "BaseFolderManagerViewModel"],
	function() {
		/**
		 * @class BPMSoft.data.filters.PortalFolderManagerViewModel
		 */
		Ext.define("BPMSoft.data.filters.PortalFolderManagerViewModel", {
			extend: "BPMSoft.BaseFolderManagerViewModel",
			alternateClassName: "BPMSoft.PortalFolderManagerViewModel",

			/**
			 * @inheritdoc BPMSoft.BaseFolderManagerViewModel#getIsAdministratedByRecordsVisible
			 * @overridden
			 */
			getIsAdministratedByRecordsVisible: function() {
				if (BPMSoft.isCurrentUserSsp()) {
					return false;
				}
				return this.callParent(arguments);
			}
		});
	}
);
