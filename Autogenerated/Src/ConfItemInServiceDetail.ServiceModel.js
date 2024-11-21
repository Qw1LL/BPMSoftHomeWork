define("ConfItemInServiceDetail", ["BPMSoft", "StorageUtilities", "ConfigurationGrid",
		"ConfigurationGridGenerator", "ConfigurationGridUtilities"],
	function(BPMSoft, StorageUtilities) {
		return {
			entitySchemaName: "VwServiceInConfItem",
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"className": "BPMSoft.ConfigurationGrid",
						"generator": "ConfigurationGridGenerator.generatePartial",
						"generateControlsConfig": {"bindTo": "generateActiveRowControlsConfig"},
						"changeRow": {"bindTo": "changeRow"},
						"unSelectRow": {"bindTo": "unSelectRow"},
						"onGridClick": {"bindTo": "onGridClick"},
						"initActiveRowKeyMap": {"bindTo": "initActiveRowKeyMap"},
						"activeRowActions": [
							{
								"className": "BPMSoft.Button",
								"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
								"tag": "save",
								"markerValue": "save",
								"imageConfig": {"bindTo": "Resources.Images.SaveIcon"}
							},
							{
								"className": "BPMSoft.Button",
								"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
								"tag": "cancel",
								"markerValue": "cancel",
								"imageConfig": {"bindTo": "Resources.Images.CancelIcon"}
							},
							{
								"className": "BPMSoft.Button",
								"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
								"tag": "remove",
								"markerValue": "remove",
								"imageConfig": {"bindTo": "Resources.Images.RemoveIcon"}
							}
						],
						"listedZebra": true,
						"activeRowAction": {"bindTo": "onActiveRowAction"}
					}
				}
			]/**SCHEMA_DIFF*/,
			mixins: {
				ConfigurationGridUtilites: "BPMSoft.ConfigurationGridUtilities"
			},
			attributes: {
				"IsEditable": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": true
				}
			},
			methods: {
				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#init
				 * @overridden
				 */
				init: function() {
					this.callParent(arguments);
					StorageUtilities.setItem("ServiceItemSection", "ServiceModelCurrentSectionName");
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetail#updateDetail
				 * @overridden
				 */
				updateDetail: function() {
					this.callParent(arguments);
					this.reloadGridData();
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getCopyRecordMenuItem
				 * @overridden
				 */
				getCopyRecordMenuItem: this.BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getEditRecordMenuItem
				 * @overridden
				 */
				getEditRecordMenuItem: this.BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.GridUtilitiesV2#prepareResponseCollection
				 * @overridden
				 */
				prepareResponseCollection: function(collection) {
					this.callParent(arguments);
					collection.each(function(item) {
						var dependencyCategory = item.get("DependencyCategory");
						var dependencyTypeCategory = item.get("DependencyTypeCategory");
						if (dependencyCategory != null && dependencyTypeCategory != null &&
							dependencyTypeCategory.value !== dependencyCategory.value) {
							var dependencyType = item.get("DependencyType");
							var reverseTypeName = item.get("LczReverseTypeName");
							dependencyType.displayValue = reverseTypeName;
						}
					}, this);
				},

				/**
				 * @inheritdoc BPMSoft.GridUtilities#initQueryColumns
				 * @overridden
				 */
				initQueryColumns: function(esq) {
					this.callParent(arguments);
					esq.addColumn("DependencyType.ReverseTypeName", "LczReverseTypeName");
				},

				/**
				 * @inheritdoc BPMSoft.ConfigurationGridUtilities#getCellControlsConfig
				 * @overridden
				 */
				getCellControlsConfig: function(entitySchemaColumn) {
					var columnName = entitySchemaColumn.name;
					var enabled = (entitySchemaColumn.usageType !== BPMSoft.EntitySchemaColumnUsageType.None) &&
						!this.Ext.Array.contains(this.systemColumns, columnName);
					var config = {
						itemType: BPMSoft.ViewItemType.MODEL_ITEM,
						name: columnName,
						labelConfig: {visible: false},
						caption: entitySchemaColumn.caption,
						enabled: enabled
					};
					if (columnName === "DependencyType") {
						config.prepareList = {"bindTo": "getDependencyTypeList"};
					}
					if (columnName === "DependencyCategory") {
						config.enabled = {"bindTo": "getDependencyCategoryEnabled"};
					}
					if (entitySchemaColumn.dataValueType === BPMSoft.DataValueType.LOOKUP) {
						config.showValueAsLink = false;
					}
					if (entitySchemaColumn.dataValueType !== BPMSoft.DataValueType.DATE_TIME &&
						entitySchemaColumn.dataValueType !== BPMSoft.DataValueType.BOOLEAN) {
						config.focused = {"bindTo": "Is" + columnName + "Focused"};
					}
					return config;
				},
				/**
				 * @inheritDoc BPMSoft.GridUtilitiesV2#getFilterDefaultColumnName
				 * @overridden
				 */
				getFilterDefaultColumnName: function() {
					return "ConfItem";
				}
			}
		};
	}
);
