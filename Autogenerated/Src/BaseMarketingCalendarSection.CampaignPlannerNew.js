define("BaseMarketingCalendarSection", ["BPMSoft", "css!BaseMarketingCalendarSectionCSS"],
	function(BPMSoft) {
		return {
			messages: {

				/**
				 * Fires when year in calendar changed.
				 */
				"CalendarYearChanged": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			attributes: {

				/**
				 * Selected calendar year.
				 */
				"CalendarYear": {
					dataValueType: BPMSoft.DataValueType.ENUM,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * List of all available years in calendar.
				 */
				"CalendarYearList": {
					dataValueType: BPMSoft.DataValueType.COLLECTION,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},
			methods: {

				_getCurrentYear: function() {
					return new Date().getFullYear();
				},

				_getCalendarYearsList: function() {
					var list = this.$CalendarYearList;
					if (BPMSoft.isEmpty(list)) {
						list = this.Ext.create("BPMSoft.Collection");
						this.$CalendarYearList = list;
					}
					return list;
				},

				_getCalendarYearsCollection: function(minYearEntityCollection) {
					var resultList = this.Ext.create("BPMSoft.Collection");
					var currentYear = this._getCurrentYear();
					var minStartYear = currentYear;
					var maxStartYear = currentYear;
					if (minYearEntityCollection && minYearEntityCollection.collection.length > 0) {
						if (!BPMSoft.isEmpty(minYearEntityCollection.collection.items[0].$MinStartDate)) {
							minStartYear = minYearEntityCollection.collection.items[0].$MinStartDate.getFullYear();
						}
						if (!BPMSoft.isEmpty(minYearEntityCollection.collection.items[0].$MaxStartDate)) {
							var maxStartYearFromDB = minYearEntityCollection.collection.items[0]
								.$MaxStartDate.getFullYear();
							maxStartYear = maxStartYearFromDB < maxStartYear ? maxStartYear : maxStartYearFromDB;
						}
					}
					for (var year = minStartYear; year <= maxStartYear; year++) {
						resultList.add({
							displayValue: year,
							value: year
						});
					}
					return resultList;
				},

				/**
				 * Generates {BPMSoft.EntitySchemaQuery}
				 * @protected
				 * @virtual
				 * @param String minStartDateColumnAlias Alias for column which contains minimal StartDate.
				 */
				getStartDateRecordsRangeEsq: BPMSoft.emptyFn,

				/**
				 * Handles change of selected year in calendar.
				 * @protected
				 * @param {Object} newValue Selected year value.
				 */
				calendarYearChanged: BPMSoft.emptyFn,

				/**
				 * Loads values to calendar yeras list.
				 * @protected
				 */
				loadCalendarYearList: function() {
					var list = this._getCalendarYearsList();
					list.clear();
					var resultList = this.Ext.create("BPMSoft.Collection");
					var selectCalendarYearsRange = this.getStartDateRecordsRangeEsq("MinStartDate", "MaxStartDate");
					selectCalendarYearsRange.getEntityCollection(function(result) {
						resultList.loadAll(this._getCalendarYearsCollection(result.collection));
						list.loadAll(resultList);
					}, this);
				},

				/**
				 * @override BPMSoft.BaseSectionV2#init
				 */
				init: function () {
					this.callParent(arguments);
					this.loadCalendarYearList();
					this.$CalendarYear = {
						displayValue: this._getCurrentYear(),
						value: this._getCurrentYear()
					};
				}
			},
			diff: /**SCHEMA_DIFF*/ [
				{
					"operation": "insert",
					"parentName": "LeftGridUtilsContainer",
					"propertyName": "items",
					"name": "CalendarYear",
					"values": {
						"dataValueType": BPMSoft.DataValueType.ENUM,
						"caption": {bindTo: "Resources.Strings.YearControlLabel"},
						"wrapClass": ["select-year-container"],
						"controlConfig": {
							"className": "BPMSoft.ComboBoxEdit",
							"list": {
								"bindTo": "CalendarYearList"
							},
							"prepareList": {
								"bindTo": "loadCalendarYearList"
							},
							"value": {
								"bindTo": "CalendarYear"
							},
							"change": {
								"bindTo": "calendarYearChanged"
							}
						}
					}
				}
			] /**SCHEMA_DIFF*/
		};
	});
