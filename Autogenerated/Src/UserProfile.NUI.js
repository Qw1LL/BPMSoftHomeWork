define("UserProfile", ["BaseSchemaModuleV2"],
	function() {
		/**
		 * @class BPMSoft.configuration.UserProfile
		 */
		Ext.define("BPMSoft.configuration.UserProfile", {
			extend: "BPMSoft.BaseSchemaModule",
			alternateClassName: "BPMSoft.UserProfile",

			//region Methods: Protected

			/**
			 * @inheritdoc
			 * @overridden
			 */
			initSchemaName: function() {
				this.callParent(arguments);
				if (this.Ext.isEmpty(this.schemaName)) {
					this.schemaName = "UserProfilePage";
				}
			}

			//endregion

		});
		return BPMSoft.UserProfile;
	}
);
