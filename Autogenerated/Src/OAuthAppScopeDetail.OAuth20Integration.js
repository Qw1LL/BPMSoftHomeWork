define("OAuthAppScopeDetail", [
	"InformationButtonResources", "ConfigurationGrid", "ConfigurationGridGenerator",
	"ConfigurationGridUtilities", "css!OAuth20AppStyles"
], function(InformationButtonResources) {
	return {
		entitySchemaName: "OAuthAppScope",
		attributes: {
			"IsEditable": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: true
			}
		},
		mixins: {
			ConfigurationGridUtilities: "BPMSoft.ConfigurationGridUtilities"
		},
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
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
					"initActiveRowKeyMap": {"bindTo": "initActiveRowKeyMap"},
					"activeRowAction": {"bindTo": "onActiveRowAction"},
					"multiSelect": false
				}
			},
			{
				"operation": "insert",
				"name": "ScopeInfo",
				"parentName": "Detail",
				"propertyName": "tools",
				"values": {
					"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
					"behaviour": {"displayEvent": BPMSoft.TipDisplayEvent.HOVER},
					"content": {"bindTo": "Resources.Strings.ScopeInfoTip"},
					"style": BPMSoft.TipStyle.WHITE,
					"controlConfig": {
						"imageConfig": InformationButtonResources.localizableImages.DefaultIcon,
						"classes": {"wrapperClass": ["scope-info-btn"]}
					}
				}
			}
		]/**SCHEMA_DIFF*/,
		methods: {

			// region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getEditRecordMenuItem
			 * @overridden
			 */
			getEditRecordMenuItem: BPMSoft.emptyFn,

			// endregion

			// region Methods: Public

			/**
			 * @inheritdoc BPMSoft.ConfigurationGridUtilities#saveRowChanges
			 * @overridden
			 */
			saveRowChanges: function(row) {
				if (Ext.isObject(row)) {
					row.$Scope = row.$Scope.trim();
				}
				this.mixins.ConfigurationGridUtilities.saveRowChanges.apply(this, arguments);
			}

			// endregion

		}
	};
});
