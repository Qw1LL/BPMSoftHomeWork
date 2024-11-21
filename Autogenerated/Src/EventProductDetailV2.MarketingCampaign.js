define("EventProductDetailV2", ["BPMSoft"],
		function(BPMSoft) {
			return {
				entitySchemaName: "EventProduct",
				attributes: {},
				methods: {},
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
										"name": "ProductListedGridColumn",
										"bindTo": "Product",
										"position": {
											"column": 1,
											"colSpan": 11
										},
										"type": BPMSoft.GridCellType.TITLE
									},
									{
										"name": "NoteListedGridColumn",
										"bindTo": "Note",
										"position": {
											"column": 13,
											"colSpan": 11
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
										"name": "ProductTiledGridColumn",
										"bindTo": "Product",
										"position": {
											"row": 1,
											"column": 1,
											"colSpan": 24
										},
										"type": BPMSoft.GridCellType.TITLE
									},
									{
										"name": "NoteTiledGridColumn",
										"bindTo": "Note",
										"position": {
											"row": 2,
											"column": 1,
											"colSpan": 24
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
