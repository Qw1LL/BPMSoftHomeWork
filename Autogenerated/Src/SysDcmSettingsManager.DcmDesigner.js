define("SysDcmSettingsManager", [
		"SysDcmSettingsManagerResources",
		"SysDcmSettingsManagerItem"
	],
	function() {
		/**
		 * @class BPMSoft.SysDcmSettingsManager
		 * Class of DCM settings.
		 */
		Ext.define("BPMSoft.manager.SysDcmSettingsManager", {
			extend: "BPMSoft.ObjectManager",
			alternateClassName: "BPMSoft.SysDcmSettingsManager",
			singleton: true,

			/**
			 * @inheritdoc BPMSoft.BaseManager#useNotification
			 * @overridden
			 */
			useNotification: true,

			/**
			 * @inheritdoc BPMSoft.BaseManager#outdatedEventName
			 * @overridden
			 */
			outdatedEventName: "SysDcmSettingsManagerOutdated",

			//region Properties: Private

			/**
			 * @inheritdoc BPMSoft.manager.ObjectManager#itemClassName
			 * @overridden
			 */
			itemClassName: "BPMSoft.SysDcmSettingsManagerItem",

			/**
			 * @inheritdoc BPMSoft.manager.ObjectManager#entitySchemaName
			 * @overridden
			 */
			entitySchemaName: "SysDcmSettings",

			/**
			 * @inheritdoc BPMSoft.manager.ObjectManager#propertyColumnNames
			 * @overridden
			 */
			propertyColumnNames: {
				sysModuleEntity: "SysModuleEntity",
				stageColumnUId: "StageColumnUId",
				filters: "Filters",
				defaultSchemaUId: "DefaultSchemaUId"
			},

			// endregion

			//region Methods: Public

			/**
			 * Returns sysDcmSettings manager item by sysModuleEntity id.
			 * @param {String} sysModuleEntityId SysModuleEntity id.
			 * @return {BPMSoft.manager.SysDcmSettingsManagerItem} Requested manager item.
			 */
			findBySysModuleEntityId: function(sysModuleEntityId) {
				this.checkIsInitialized();
				var filteredItems = this.items.filterByFn(function(item) {
					return item.getSysModuleEntity() === sysModuleEntityId;
				});
				return filteredItems.first();
			},

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
		return BPMSoft.SysDcmSettingsManager;
	}
);
