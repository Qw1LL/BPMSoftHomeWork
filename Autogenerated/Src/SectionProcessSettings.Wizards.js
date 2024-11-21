/**
 * Parent: BaseProcessSettings
 */
define("SectionProcessSettings", ["SectionProcessExecutingDetail"], function() {
	return {
		entitySchemaName: "ProcessInModules",
		attributes: {
			"SysModuleEntityId": {
				dataValueType: BPMSoft.DataValueType.GUID,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			}
		},
		methods: {

			/**
			 * @inheritdoc BPMSoft.BaseProcessSettings#onGetModuleConfigResult
			 * @override
			 */
			onGetModuleConfigResult: function(config) {
				var applicationStructureItem = config.applicationStructureItem;
				this.set("SysModuleEntityId", applicationStructureItem.id);
				this.callParent(arguments);
			}
		},
		details: {
			"ProcessExecutingDetail": {
				schemaName: "SectionProcessExecutingDetail",
				entitySchemaName: "ProcessInModules",
				filter: {
					masterColumn: "SysModuleEntityId",
					detailColumn: "SysModule"
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
