define("CalendarLookupSection", [],
		function() {
			return {
				entitySchemaName: "Calendar",
				attributes: {
					"LastCopyRecord": {
						dataValueType: BPMSoft.DataValueType.LOOKUP
					},
					"IsCopySaving": {
						dataValueType: BPMSoft.DataValueType.BOOLEAN
					}
				},
				diff: /**SCHEMA_DIFF*/[],/**SCHEMA_DIFF*/
				messages: {},
				methods: {
					/**
					 * @inheritdoc ConfigurationGridUtilitiesV2#saveRowChanges
					 * @overridden
					 */
					saveRowChanges: function(row, callback, scope) {
						if (row && row.isCopyMode) {
							this.set("IsCopySaving", row.isCopyMode());
						}
						this.callParent([row,
								function(response) {
									if (this.Ext.isFunction(callback)) {
										callback.apply(scope, arguments);
									}
									if (response && response.id) {
										this.onNewRecordSaved(response.id);
									}
								},
								scope]);
					},
					/**
					 * @inheritdoc BPMSoft.BaseSectionV2#copyRecord
					 * @overridden
					 */
					copyRecord: function(primaryColumnValue) {
						this.callParent(arguments);
						this.set("LastCopyRecord", primaryColumnValue);
					},
					/**
					 * New record saved handler. Calls only on row first saved.
					 * @param {Guid} savedRecordId Id of saved record.
					 * @protected
					 */
					onNewRecordSaved: function(savedRecordId) {
						this.createNewCalendarDetails(savedRecordId);
					},
					/**
					 * Creates default time interval records for new calendar details.
					 * @param {Guid} calendarId Id of calendar to create intervals.
					 * @protected
					 */
					createNewCalendarDetails: function(calendarId) {
						if (this.get("IsCopySaving")) {
							this.copyDetailsFromCalendar(this.get("LastCopyRecord"), calendarId);
						} else {
							this.BPMSoft.SysSettings.querySysSettingsItem("BaseCalendar", function(baseCalendar) {
								if (baseCalendar && baseCalendar.value) {
									this.copyDetailsFromCalendar(baseCalendar.value, calendarId);
								} else {
									this.showInformationDialog(this.get("Resources.Strings.FillBaseCalendarSysSetting"));
								}
							}, this);
						}
					},
					/**
					 * Copy time intervals details records from one calendar to another.
					 * @param {Guid} sourceCalendarId Id of source calendar.
					 * @param {Guid} destinationCalendarId Id of destination calendar.
					 * @protected
					 */
					copyDetailsFromCalendar: function(sourceCalendarId, destinationCalendarId) {
						var esq = this.getCalendarInfoQuery(sourceCalendarId);
						esq.getEntityCollection(function(result) {
							this.insertCalendarWithTemplate(result, destinationCalendarId);
						}, this);
					},
					/**
					 * Returns query with calendar info.
					 * @param {Guid} calendarId Calendar identifier.
					 * @return {BPMSoft.EntitySchemaQuery} query with calendar info.
					 * @protected
					 */
					getCalendarInfoQuery: function(calendarId) {
						var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: "DayInCalendar"
						});
						esq.addColumn("Id", "DayInCalendarId");
						esq.addColumn("DayOfWeek");
						esq.addColumn("DayType");
						esq.addColumn("[WorkingTimeInterval:DayInCalendar:Id].From", "IntervalFrom");
						esq.addColumn("[WorkingTimeInterval:DayInCalendar:Id].To", "IntervalTo");
						esq.filters.add("calendarFilter", this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL, "Calendar", calendarId));
						return esq;
					},
					/**
					 * On insert calendar record handler.
					 * Creates week template and working time intervals for new calendar.
					 * @param {Object} sourceCalendarEsqResult Result of source ESQ execution.
					 * @param {Guid} destinationCalendarId Id of destination calendar.
					 * @private
					 */
					insertCalendarWithTemplate: function(sourceCalendarEsqResult, destinationCalendarId) {
						if (!sourceCalendarEsqResult.success) {
							return;
						}
						var batchQuery = this.Ext.create("BPMSoft.BatchQuery");
						this.addQueries(sourceCalendarEsqResult.collection, batchQuery, destinationCalendarId);
						batchQuery.execute();
					},
					/**
					 * Creates and add insert queries for related entities.
					 * @param {BPMSoft.Collection} baseCalendarCollection Source calendar template.
					 * @param {BPMSoft.BatchQuery} batchQuery Query.
					 * @param {Guid} destinationCalendarId Id of destination calendar.
					 * @private
					 */
					addQueries: function(baseCalendarCollection, batchQuery, destinationCalendarId) {
						this.dayInCalendarConfig = {};
						baseCalendarCollection.each(function(item) {
							var dayOfWeekId = this.Ext.isObject(item.get("DayOfWeek")) ?
									item.get("DayOfWeek").value : "";
							var dayTypeId = this.Ext.isObject(item.get("DayType")) ? item.get("DayType").value : "";
							if (this.dayInCalendarConfig.dayOfWeek !== dayOfWeekId) {
								this.dayInCalendarConfig = {
									"id": this.BPMSoft.generateGUID(),
									"dayOfWeek": dayOfWeekId,
									"dayType": dayTypeId,
									"calendarId": destinationCalendarId
								};
								batchQuery.add(this.getDayInCalendarQuery(this.dayInCalendarConfig));
							}
							if (!item.get("IntervalFrom") || !item.get("IntervalTo")) {
								return;
							}
							var timeIntervalConfig = {
								"id": this.BPMSoft.generateGUID(),
								"dayInCalendarId": this.dayInCalendarConfig.id,
								"from": item.get("IntervalFrom"),
								"to": item.get("IntervalTo")
							};
							batchQuery.add(this.getTimeIntervalQuery(timeIntervalConfig));
						}, this);
					},
					/**
					 * Returns insert query for day in calendar record.
					 * @param {Object} config DayInCalendar config.
					 * @return {BPMSoft.InsertQuery} insert.
					 * @protected
					 */
					getDayInCalendarQuery: function(config) {
						var insert = this.Ext.create("BPMSoft.InsertQuery", {
							rootSchemaName: "DayInCalendar"
						});
						insert.setParameterValue("Id", config.id,
								this.BPMSoft.DataValueType.GUID);
						insert.setParameterValue("Calendar", config.calendarId,
								this.BPMSoft.DataValueType.GUID);
						insert.setParameterValue("DayOfWeek", config.dayOfWeek,
								this.BPMSoft.DataValueType.GUID);
						insert.setParameterValue("DayType", config.dayType,
								this.BPMSoft.DataValueType.GUID);
						return insert;
					},

					/**
					 * Returns insert query for working time interval record.
					 * @param {Object} config WorkingTimeInterval config.
					 * @return {BPMSoft.InsertQuery} insert.
					 * @private
					 */
					getTimeIntervalQuery: function(config) {
						var insert = this.Ext.create("BPMSoft.InsertQuery", {
							rootSchemaName: "WorkingTimeInterval"
						});
						insert.setParameterValue("Id", config.id,
								this.BPMSoft.DataValueType.GUID);
						insert.setParameterValue("DayInCalendar", config.dayInCalendarId,
								this.BPMSoft.DataValueType.GUID);
						insert.setParameterValue("From", config.from,
								this.BPMSoft.DataValueType.DATE_TIME);
						insert.setParameterValue("To", config.to,
								this.BPMSoft.DataValueType.DATE_TIME);
						return insert;
					}
				}
			};
		});
