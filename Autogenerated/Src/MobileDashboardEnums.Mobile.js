Ext.ns("BPMSoft.configuration.consts");

BPMSoft.configuration.consts.DashboardRequestsGroupId = "dashboards";

Ext.ns("BPMSoft.configuration.enums");

/**
 * @enum
 * Dashboard item class names.
 */
BPMSoft.configuration.enums.DashboardItemClassName = {
	Indicator: "BPMSoft.IndicatorDashboardItem",
	Grid: "BPMSoft.GridDashboardItem",
	Chart: "BPMSoft.ChartDashboardItem"
};

BPMSoft.DashboardItemClassName = BPMSoft.configuration.enums.DashboardItemClassName;

/**
 * @enum
 * Dashboard item widget types.
 */
BPMSoft.configuration.enums.DashboardItemWidgetType = {
	Indicator: "Indicator",
	Chart: "Chart",
	DashboardGrid: "DashboardGrid",
	Gauge: "Gauge"
};

BPMSoft.DashboardItemWidgetType = BPMSoft.configuration.enums.DashboardItemWidgetType;

/**
 * @enum
 * Dashboard container items status.
 */
BPMSoft.configuration.enums.DashboardContainerItemsStatus = {
	NotLoaded: "notloaded",
	Loading: "loading",
	Loaded: "loaded"
};

BPMSoft.DashboardContainerItemsStatus = BPMSoft.configuration.enums.DashboardContainerItemsStatus;

/**
 * @enum
 * Dashboard style colors.
 */
BPMSoft.configuration.enums.DashboardStyleColor = {
	"widget-blue": "#03a9f4",
	"widget-green": "#20c964",
	"widget-mustard": "#ffc107",
	"widget-violet": "#9575cd",
	"widget-dark-turquoise": "#009688",
	"widget-orange": "#ff9800",
	"widget-turquoise": "#00bfa5",
	"widget-navy": "#0091ea",
	"widget-coral": "#ff7043"
};

BPMSoft.DashboardStyleColor = BPMSoft.configuration.enums.DashboardStyleColor;

/**
 * @enum
 * Dashboard gauge colors.
 */
BPMSoft.configuration.enums.DashboardGaugeScaleColor = {
	min: "#ff7143",
	middle: "#fd9704",
	max: "#0fdc63"
};

BPMSoft.DashboardGaugeScaleColor = BPMSoft.configuration.enums.DashboardGaugeScaleColor;

/**
 * @enum
 * Dashboard styles.
 */
BPMSoft.configuration.enums.DashboardStyle = {
	Blue: "widget-blue",
	Green: "widget-green",
	Mustard: "widget-mustard",
	Violet: "widget-violet",
	DarkTurquoise: "widget-dark-turquoise",
	Orange: "widget-orange",
	Turquoise: "widget-turquoise",
	Navy: "widget-navy",
	Coral: "widget-coral"
};

BPMSoft.DashboardStyle = BPMSoft.configuration.enums.DashboardStyle;

/**
 * @enum
 * Dashboard datetime format types.
 */
BPMSoft.configuration.enums.DashboardDateTimeFormatType = {
	Year: "Year",
	MonthYear: "Month;Year",
	Month: "Month",
	Week: "Week",
	DayMonthYear: "Day;Month;Year",
	DayMonth: "Day;Month",
	Day: "Day",
	Hour: "Hour"
};

BPMSoft.DashboardDateTimeFormatType = BPMSoft.configuration.enums.DashboardDateTimeFormatType;

/**
 * @enum
 * Dashboard data sort types.
 */
BPMSoft.configuration.enums.DashboardOrderBy = {
	GroupByField: "GroupByField",
	ChartEntityColumn: "ChartEntityColumn"
};

BPMSoft.DashboardOrderBy = BPMSoft.configuration.enums.DashboardOrderBy;

/**
 * @enum
 * Dashboard data order directions.
 */
BPMSoft.configuration.enums.DashboardOrderDirection = {
	Ascending: "Ascending",
	Descending: "Descending"
};

BPMSoft.DashboardOrderDirection = BPMSoft.configuration.enums.DashboardOrderDirection;

BPMSoft.configuration.consts.DefaultDashboardStyle = BPMSoft.DefaultDashboardStyle = BPMSoft.DashboardStyle.Blue;
