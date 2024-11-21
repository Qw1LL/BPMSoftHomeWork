define("ProcessDateTimeMappingPage", ["BPMSoft"],
	function(BPMSoft) {
		return {
			attributes: {
				"ActiveRowName": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					value: "Date"
				},
				"Date": {
					dataValueType: this.BPMSoft.DataValueType.DATE
				},
				"Time": {
					dataValueType: this.BPMSoft.DataValueType.TIME
				},
				"DateTime": {
					dataValueType: this.BPMSoft.DataValueType.DATE_TIME
				}
			},
			messages: {
				/**
				 * @message ResultSelectedRows
				 * Returns selected rows.
				 */
				"ResultSelectedRows": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			methods: {
				/**
				 * Handler on label click.
				 * @private
				 * @param {String} tag Active row name.
				 */
				onLabelClick: function(tag) {
					this.set("ActiveRowName", tag);
				},
				/**
				 * Gets marker value for rows container.
				 * @private
				 * @param {String} rowName Row name.
				 * @return {String}
				 */
				getRowContainerMarkerValue: function(rowName) {
					return rowName === this.get("ActiveRowName") ? "selected-date-container" : "date-container";
				},
				/**
				 * Publish selected value.
				 * @private
				 */
				onSelectedButtonClick: function() {
					var tag = arguments[3];
					var config = this.getParameterValues(tag);
					if (!config) {
						return;
					}
					var result = new BPMSoft.Collection();
					result.add(tag, config);
					this.sandbox.publish("ResultSelectedRows", {
						selectedRows: result
					}, [this.sandbox.id]);
				},
				/**
				 * Returns parameter value.
				 * @private
				 * @param {String} dateTimeKind Date time kind.
				 * [@return] {{value: (String), displayValue: (String)}}
				 */
				getParameterValues: function(dateTimeKind) {
					var value = this.get(dateTimeKind);
					if (!value) {
						return null;
					}
					var dateValueType = this.columns[dateTimeKind].dataValueType;
					var config =  BPMSoft.FormulaParserUtils.getDateTimeValueFormatConfig(dateValueType);
					var dateValue = Ext.Date.format(value, config.valueFormat);
					var dateDisplayValue = Ext.Date.format(value, config.displayFormat);
					return {
						value: Ext.String.format("{0}{1}", config.valuePrefix, dateValue),
						displayValue: Ext.String.format("{0}{1}", config.displayPrefix, dateDisplayValue)
					};
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "ProcessDateTimeMappingContainer",
					"propertyName": "items",
					"className": "BPMSoft.GridLayoutEdit",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "DateContainer",
					"parentName": "ProcessDateTimeMappingContainer",
					"propertyName": "items",
					"values": {
						"layout": {"column": 0, "row": 0, "colSpan": 24},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"markerValue": {
							"bindTo": "getRowContainerMarkerValue"
						},
						"tag": "Date",
						"classes": {
							"wrapClassName": ["date-container"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "DateLabel",
					"parentName": "DateContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "Resources.Strings.SelectDateCaption"},
						"click": {"bindTo": "onLabelClick"},
						"tag": "Date"
					}
				},
				{
					"operation": "insert",
					"parentName": "DateContainer",
					"propertyName": "items",
					"name": "Date",
					"values": {
						"labelConfig": {
							"visible": false
						},
						"wrapClass": ["input-wrap"]
					}
				},
				{
					"operation": "insert",
					"name": "SelectDateButton",
					"parentName": "DateContainer",
					"propertyName": "items",
					"values": {
						"caption": {"bindTo": "Resources.Strings.SelectButtonCaption"},
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"click": {"bindTo": "onSelectedButtonClick"},
						"tag": "Date"
					}
				},
				{
					"operation": "insert",
					"name": "TimeContainer",
					"parentName": "ProcessDateTimeMappingContainer",
					"propertyName": "items",
					"values": {
						"layout": {"column": 0, "row": 1, "colSpan": 24},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"markerValue": {
							"bindTo": "getRowContainerMarkerValue"
						},
						"tag": "Time",
						"classes": {
							"wrapClassName": ["date-container"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "TimeLabel",
					"parentName": "TimeContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "Resources.Strings.SelectTimeCaption"},
						"click": {"bindTo": "onLabelClick"},
						"tag": "Time"
					}
				},
				{
					"operation": "insert",
					"parentName": "TimeContainer",
					"propertyName": "items",
					"name": "Time",
					"values": {
						"labelConfig": {
							"visible": false
						},
						"wrapClass": ["input-wrap"]
					}
				},
				{
					"operation": "insert",
					"name": "SelectTimeButton",
					"parentName": "TimeContainer",
					"propertyName": "items",
					"values": {
						"caption": {"bindTo": "Resources.Strings.SelectButtonCaption"},
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"click": {"bindTo": "onSelectedButtonClick"},
						"tag": "Time"
					}
				},
				{
					"operation": "insert",
					"name": "DateTimeContainer",
					"parentName": "ProcessDateTimeMappingContainer",
					"propertyName": "items",
					"values": {
						"layout": {"column": 0, "row": 2, "colSpan": 24},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"markerValue": {
							"bindTo": "getRowContainerMarkerValue"
						},
						"tag": "DateTime",
						"classes": {
							"wrapClassName": ["date-container"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "DateTimeLabel",
					"parentName": "DateTimeContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "Resources.Strings.SelectDateTimeCaption"},
						"click": {"bindTo": "onLabelClick"},
						"tag": "DateTime"
					}
				},
				{
					"operation": "insert",
					"parentName": "DateTimeContainer",
					"propertyName": "items",
					"name": "DateTime",
					"values": {
						"labelConfig": {
							"visible": false
						},
						"wrapClass": ["input-wrap"]
					}
				},
				{
					"operation": "insert",
					"name": "SelectDateTimeButton",
					"parentName": "DateTimeContainer",
					"propertyName": "items",
					"values": {
						"caption": {"bindTo": "Resources.Strings.SelectButtonCaption"},
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"click": {"bindTo": "onSelectedButtonClick"},
						"tag": "DateTime"
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
