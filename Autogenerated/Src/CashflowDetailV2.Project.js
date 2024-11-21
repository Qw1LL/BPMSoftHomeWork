define("CashflowDetailV2", ["BPMSoft"],
	function() {
		return {
			entitySchemaName: "Cashflow",
			attributes: {},
			methods: {
				/**
				 * @inheritdoc BPMSoft.GridUtilitiesV2#getFilterDefaultColumnName
				 * @overridden
				 */
				getFilterDefaultColumnName: function() {
					return "Details";
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"type": "listed",
						"listedConfig": {
							"name": "DataGridListedConfig",
							"items": [
								{
									"name": "TypeListedGridColumn",
									"bindTo": "Type",
									"position": {
										"column": 1,
										"colSpan": 4
									}
								},
								{
									"name": "DateListedGridColumn",
									"bindTo": "Date",
									"position": {
										"column": 5,
										"colSpan": 6
									}
								},
								{
									"name": "DetailsListedGridColumn",
									"bindTo": "Details",
									"position": {
										"column": 11,
										"colSpan": 8
									}
								},
								{
									"name": "PrimaryAmountListedGridColumn",
									"bindTo": "PrimaryAmount",
									"position": {
										"column": 19,
										"colSpan": 6
									}
								}
							]
						},
						"tiledConfig": {
							"name": "DataGridTiledConfig",
							"grid": {
								"columns": 24,
								"rows": 3
							},
							"items": [
								{
									"name": "TypeTiledGridColumn",
									"bindTo": "Type",
									"position": {
										"row": 1,
										"column": 1,
										"colSpan": 4
									}
								},
								{
									"name": "DateTiledGridColumn",
									"bindTo": "Date",
									"position": {
										"row": 1,
										"column": 5,
										"colSpan": 6
									}
								},
								{
									"name": "DetailsTiledGridColumn",
									"bindTo": "Details",
									"position": {
										"row": 1,
										"column": 11,
										"colSpan": 8
									}
								},
								{
									"name": "PrimaryAmountTiledGridColumn",
									"bindTo": "PrimaryAmount",
									"position": {
										"row": 1,
										"column": 19,
										"colSpan": 6
									}
								}
							]
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
