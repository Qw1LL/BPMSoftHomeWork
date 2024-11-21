define("ForecastConstants", [], function() {
	/**
	 * @class BPMSoft.configuration.ForecastConstants
	 * This class provides constants for forecast section.
	 */
	Ext.define("BPMSoft.configuration.ForecastConstants", {
		extend: "BPMSoft.BaseObject",
		alternateClassName: "BPMSoft.ForecastConstants",

		Indicator: {
			PlanIndicatorId: "cbd311c7-6e1b-4324-bf21-192681349ddf"
		},

		PeriodType: {
			YearPeriodTypeId: "41c1b636-bca0-4618-8527-fbf727cef3c7",
			QuarterPeriodTypeId: "d4346752-cb02-4edf-b071-6946738e1d40",
			MonthPeriodTypeId: "83140788-d3f8-4dcc-9497-1d6ece36f2db"
		},

		ColumnType: {
			Editable: "85a0eddc-0638-4cd5-b1d4-7f2f82fe514f",
			ObjectValue: "42df643e-ac48-4e67-8f78-52d18beecf10",
			Formula: "1b401172-d1ce-4c75-8530-c5272b9b328d"
		},

		FormulaSettingType: {
			Default: 0,
			Summary: 1,
			Footer: 2
		},

		GTMEventActions: {
			ForecastSnapshotEnabled: "ForecastSnapshotEnabled",
			ForecastSnapshotDisabled: "ForecastSnapshotDisabled",
			ForecastAutoCalculateEnabled: "ForecastAutoCalculateEnabled",
			ForecastDatepickerClick: "ForecastDatepickerClick"
		}
	});
	return Ext.create("BPMSoft.ForecastConstants");
});
