define("OpportunityContactDetailV2", [],
		function() {
			return {
				entitySchemaName: "OpportunityContact",
				messages: {
					"RefreshDecisionMaker": {
						"mode": BPMSoft.MessageMode.PTP,
						"direction": BPMSoft.MessageDirectionType.PUBLISH
					}
				},
				methods: {
					/**
					 * @inheritDoc BPMSoft.BaseDetailV2#updateDetail
					 * @override
					 */
					updateDetail: function() {
						this.callParent(arguments);
						this.sandbox.publish("RefreshDecisionMaker", {}, [this.sandbox.id]);
					},

					/**
					 * @inheritDoc BPMSoft.BaseDetailV2#updateDetail
					 * @override
					 */
					getAddRecordButtonVisible: function() {
						var cardPageName = this.get("CardPageName");
						return (cardPageName === "OpportunityPageV2") && this.getToolsVisible();
					},

					/**
					 * @inheritDoc BPMSoft.BaseDetailV2#updateDetail
					 * @override
					 */
					getGridDataColumns: function() {
						return {
							"Contact.Name": {path:  "Contact.Name"}
						};
					}
				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "merge",
						"name": "DataGrid",
						"values": {
							"type": "listed",
							"primaryDisplayColumnName": "Contact.Name",
							"listedConfig": {
								"name": "DataGridListedConfig",
								"items": [
									{
										"name": "TitleListedGridColumn",
										"bindTo": "Opportunity",
										"position": {
											"column": 1,
											"colSpan": 11
										},
										"type": this.BPMSoft.GridCellType.TITLE
									},
									{
										"name": "StageListedGridColumn",
										"bindTo": "Opportunity.Stage",
										"position": {
											"column": 13,
											"colSpan": 6
										}
									},
									{
										"name": "RevenueListedGridColumn",
										"bindTo": "Opportunity.Amount",
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
										"name": "TitleTiledGridColumn",
										"bindTo": "Opportunity",
										"position": {
											"row": 1,
											"column": 1,
											"colSpan": 24
										},
										"type": this.BPMSoft.GridCellType.TITLE
									},
									{
										"name": "StageTiledGridColumn",
										"bindTo": "Opportunity.Stage",
										"position": {
											"row": 2,
											"column": 1,
											"colSpan": 8
										}
									},
									{
										"name": "OwnerTiledGridColumn",
										"bindTo": "Opportunity.Owner",
										"position": {
											"row": 2,
											"column": 9,
											"colSpan": 10
										}
									},
									{
										"name": "RevenueTiledGridColumn",
										"bindTo": "Opportunity.Amount",
										"position": {
											"row": 2,
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
