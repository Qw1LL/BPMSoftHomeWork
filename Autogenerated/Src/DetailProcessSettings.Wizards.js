define("DetailProcessSettings", ["DetailProcessExecutingDetail"], function() {
	return {
		entitySchemaName: "ProcessInDetails",

		attributes: {
			/**
			 * SysModuleEntityId.
			 */
			"SysDetailEntityId": {
				dataValueType: BPMSoft.DataValueType.GUID,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			}
		},
		methods: {

			/**
			 * @inheritdoc BPMSoft.BaseProcessSettings#onGetModuleConfigResult
			 * @overridden
			 */
			onGetModuleConfigResult: function(config) {
				var applicationStructureItem = config.applicationStructureItem;
				this.set("SysDetailEntityId", applicationStructureItem.id);
				this.callParent(arguments);
			}
		},
		details: {
			"ProcessExecutingDetail": {
				schemaName: "DetailProcessExecutingDetail",
				entitySchemaName: "ProcessInDetails",
				filter: {
					masterColumn: "SysDetailEntityId",
					detailColumn: "SysDetail"
				}
			}
		},
		diff: [
			{
				"operation": "insert",
				"parentName": "BusinessProcessSettings",
				"propertyName": "items",
				"name": "ProcessExecutingDetail",
				"values": {
					"itemType": BPMSoft.ViewItemType.DETAIL
				}
			}
		]
	};
});
