define("OpportunityCompetitorDetailV2", [],
	function() {
		return {
			entitySchemaName: "OpportunityCompetitor",
			methods: {
			getGridDataColumns: function() {
				return {
					"Id": {path: "Id"},
					"Strengths": {path:  "Strengths"},
					"Weakness": {path:  "Weakness"},
					"CompetitorProduct.Name": {path:  "CompetitorProduct.Name"},
					"Competitor.Name": {path:  "Competitor.Name"}
				};
			},
				/**
				 * @inheritdoc BPMSoft.GridUtilitiesV2#getFilterDefaultColumnName
				 * @overridden
				 */
				getFilterDefaultColumnName: function() {
					return "Competitor";
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"type": "listed",
						"primaryDisplayColumnName": "Competitor.Name",
						"listedConfig": {
							"name": "DataGridListedConfig",
							"items": [
								{
									"name": "CompetitorListedGridColumn",
									"bindTo": "Competitor",
									"position": {"column": 1, "colSpan": 6}
								},
								{
									"name": "CompetitorListedGridColumn",
									"bindTo": "CompetitorProduct",
									"position": {"column": 7, "colSpan": 6}
								},
								{
									"name": "CompetitorListedGridColumn",
									"bindTo": "Strengths",
									"position": {"column": 13, "colSpan": 6}
								},
								{
									"name": "CompetitorListedGridColumn",
									"bindTo": "Weakness",
									"position": {"column": 19, "colSpan": 6}
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
									"name": "CompetitorTiledGridColumn",
									"bindTo": "Competitor",
									"position": {"row": 1, "column": 1, "colSpan": 6}
								},
								{
									"name": "CompetitorTiledGridColumn",
									"bindTo": "CompetitorProduct",
									"position": {"row": 1, "column": 7, "colSpan": 6}
								},
								{
									"name": "CompetitorTiledGridColumn",
									"bindTo": "Strengths",
									"position": {"row": 1, "column": 13, "colSpan": 6}
								},
								{
									"name": "CompetitorTiledGridColumn",
									"bindTo": "Weakness",
									"position": {"row": 1, "column": 19, "colSpan": 6}
								}
							]
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
