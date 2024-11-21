define("PortalLeadSection", ["BPMSoft", "ControlGridModule", "BaseProgressBarModule",
		"css!BaseProgressBarModule", "css!LeadQualificationModuleStyles"],
	function() {
		return {
			entitySchemaName: "Lead",
			methods: {
				/**
				 * @inheritdoc BPMSoft.GridUtilitiesV2#prepareResponseCollectionItem
				 * @overridden
				 */
				prepareResponseCollectionItem: function(item) {
					item.getQualifyStatusValue = function(qualifyStatus) {
						if (!qualifyStatus) {
							return null;
						} else {
							return {
								value: this.get("QualifyStatus.StageNumber"),
								displayValue: qualifyStatus.displayValue
							};
						}
					};
					return this.callParent(arguments);
				},

				/**
				 * @inheritdoc BPMSoft.GridUtilitiesV2#getGridDataColumns
				 * @overridden
				 */
				getGridDataColumns: function() {
					var gridDataColumns = this.callParent(arguments);
					gridDataColumns["QualifyStatus.StageNumber"] = {path: "QualifyStatus.StageNumber"};
					return gridDataColumns;
				},

				/**
				 * Passes indicator config by reference.
				 * @param {Object} control Configuration object.
				 * @overridden
				 */
				applyControlConfig: function(control) {
					control.config = {
						className: "BPMSoft.BaseProgressBar",
						value: {
							"bindTo": "QualifyStatus",
							"bindConfig": {"converter": "getQualifyStatusValue"}
						},
						height: "auto",
						width: "auto"
					};
				},

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#getDefaultDataViews
				 * @override
				 */
				getDefaultDataViews: function() {
					const dataViews = this.callParent(arguments);
					delete dataViews.AnalyticsDataView;
					return dataViews;
				}
			},
			diff: /**SCHEMA_DIFF*/ [
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"className": "BPMSoft.ControlGrid",
						"controlColumnName": "QualifyStatus",
						"applyControlConfig": {"bindTo": "applyControlConfig"}
					}
				},
				{
					"operation": "remove",
					"name": "QualificationProcessButton"
				}
			],/**SCHEMA_DIFF*/
		};
	});
