define("SysModuleVisaManager", ["SysModuleVisaManagerResources", "SysModuleVisaManagerItem"],
	function() {
		/**
		 * @class BPMSoft.SysModuleVisaManager
		 * Class of DCM settings.
		 */
		Ext.define("BPMSoft.manager.SysModuleVisaManager", {
			extend: "BPMSoft.ObjectManager",
			alternateClassName: "BPMSoft.SysModuleVisaManager",
			singleton: true,

			//region Properties: Private

			/**
			 * @inheritdoc BPMSoft.manager.ObjectManager#itemClassName
			 * @overridden
			 */
			itemClassName: "BPMSoft.SysModuleVisaManagerItem",

			/**
			 * @inheritdoc BPMSoft.manager.ObjectManager#entitySchemaName
			 * @overridden
			 */
			entitySchemaName: "SysModuleVisa",

			/**
			 * @inheritdoc BPMSoft.manager.ObjectManager#propertyColumnNames
			 * @overridden
			 */
			propertyColumnNames: {
				visaSchemaUId: "VisaSchemaUId",
				masterColumnUId: "MasterColumnUId",
				useCustomNotificationProvider: "UseCustomNotificationProvider"
			},

			// endregion

			//region Methods: Public

			/**
			 * @inheritdoc BPMSoft.manager.ObjectManager#getPackageSchemaDataName
			 * @overridden
			 */
			getPackageSchemaDataName: function(item) {
				var itemId = item.getPropertyValue("id");
				return Ext.String.format("{0}_{1}", this.entitySchemaName, itemId.replace(/-/g, ""));
			}

			//endregion

		});
		return BPMSoft.SysModuleVisaManager;
	}
);
