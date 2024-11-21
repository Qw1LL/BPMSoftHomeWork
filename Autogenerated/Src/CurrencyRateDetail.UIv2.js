define("CurrencyRateDetail", ["ConfigurationGrid", "ConfigurationGridGenerator", "ConfigurationGridUtilities",
	"MoneyUtilsMixin", "CurrencyRatePage"],
	function() {
		return {
			entitySchemaName: "CurrencyRate",
			attributes: {
				/**
				 * IsEditable flag.
				 */
				"IsEditable": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": true
				},

				/**
				 * MultiSelect flag.
				 */
				"MultiSelect": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": false
				},

				"Division": {
					"dataValueType": BPMSoft.DataValueType.INTEGER,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": 1
				}
			},

			mixins: {
				ConfigurationGridUtilites: "BPMSoft.ConfigurationGridUtilities",
				MoneyUtilsMixin: "BPMSoft.MoneyUtilsMixin"
			},

			messages: {
				"GetCurrencyDivision": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},

			methods: {

				/**
				 * @inheritDoc BPMSoft.mixins.BaseGridDetailV2#init
				 * @override
				 */
				init: function() {
					this.callParent(arguments);
					this.set("Precision", this.getColumnPrecision("Rate"));
				},

				/**
				 * Sets sorting order for columns.
				 * @overriden
				 */
				getGridDataColumns: function() {
					var gridDataColumns = this.callParent(arguments);
					gridDataColumns.StartDate = {
						path: "StartDate",
						orderPosition: 0,
						orderDirection: this.BPMSoft.OrderDirection.DESC
					};
					gridDataColumns.CreatedOn = {
						path: "CreatedOn",
						orderPosition: 1,
						orderDirection: this.BPMSoft.OrderDirection.DESC
					};
					return gridDataColumns;
				},

				/**
				 * @inheritDoc BPMSoft.mixins.ConfigurationGridUtilites#saveRowChanges
				 * @overridden
				 */
				saveRowChanges: function(row, callback, scope) {
					this.mixins.ConfigurationGridUtilites.saveRowChanges.call(this, row, function() {
						if (row && this.getIsRowChanged(row)) {
							this.fireDetailChanged(null);
						}
						Ext.callback(callback, scope);
					}, this);
				},

				/**
				 * @inheritdoc BPMSoft.GridUtilitiesV2#prepareResponseCollection
				 * @overriden
				 */
				prepareResponseCollection: function() {
					var division = this.sandbox.publish("GetCurrencyDivision", null);
					this.set("Division", division);
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc BPMSoft.GridUtilitiesV2#prepareResponseCollectionItem
				 * @overriden
				 */
				prepareResponseCollectionItem: function(item) {
					this.callParent(arguments);
					var rate = item.get("Rate") || 0;
					if (rate) {
						const division = this.get("Division");
						const rateMantissa = item.get("RateMantissa") || 0;
						const precision = this.get("Precision");
						item.set("Rate", this.calculateRate(division, rate, rateMantissa, precision));
					}
					item.setValidationConfig();
				},

				/**
				 * @inheritdoc BPMSoft.GridUtilitiesV2#setGridRowValueFromEntity
				 * @overriden
				 */
				setGridRowValueFromEntity: function (row, entity, columnName) {
					if (columnName === "Rate") {
						const division = this.get("Division");
						const rateMantissa = entity.get("RateMantissa") || 0;
						const precision = this.get("Precision");
						row.set("Rate", this.calculateRate(division, entity.get("Rate"), rateMantissa, precision));
					} else {
						this.callParent(arguments);
					}
				},

				/**
				 * @inheritdoc BPMSoft.GridUtilitiesV2#sortColumn
				 * @overriden
				 */
				sortColumn: this.BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getGridSortMenuItem
				 * @overriden
				 */
				getGridSortMenuItem: this.BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getAddRecordButtonVisible
				 * @overridden
				 */
				getAddRecordButtonVisible: function() {
					return true;
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getCopyRecordMenuItem
				 * @overridden
				 */
				getCopyRecordMenuItem: BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getDeleteRecordMenuItem
				 * @overridden
				 */
				getDeleteRecordMenuItem: BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getEditRecordMenuItem
				 * @overridden
				 */
				getEditRecordMenuItem: BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getSwitchGridModeMenuItem
				 * @overridden
				 */
				getSwitchGridModeMenuItem: BPMSoft.emptyFn
			},
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
						"multiSelect": false,
						"type": "listed"
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
