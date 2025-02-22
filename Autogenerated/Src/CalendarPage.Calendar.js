﻿define("CalendarPage", ["RightUtilities"],
	function(RightUtilities) {
		return {
			entitySchemaName: "Calendar",
			attributes: {
				/**
				 * Sign of personal calendar feature.
				 * @type {Boolean}
				 */
				"IsUserCalendarFeature": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": false
				},
				/**
				 * Sign of rights for operation.
				 * @type {Boolean}
				 */
				"CanManageOperation": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": false
				},
				/**
				 * User entity contact column.
				 * @type {Object}
				 */
				"User": {
					"dataValueType": BPMSoft.DataValueType.LOOKUP,
					"lookupListConfig": {
						"filter": function() {
							return this.BPMSoft.createColumnIsNotNullFilter("Contact");
						},
						"hideActions": true
					}
				}
			},
			details: /**SCHEMA_DETAILS*/{
				"WorkingWeek": {
					"schemaName": "WorkingWeekDetail",
					"entitySchemaName": "DayInCalendar",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "Calendar"
					}
				},
				"DayOffs": {
					"schemaName": "DayOffsDetail",
					"entitySchemaName": "DayOff",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "Calendar"
					}
				}
			},
			methods: {
				/**
				 * @inheritdoc BPMSoft.BasePageV2#init
				 * @overridden
				 */
				init: function() {
					this.set("IsUserCalendarFeature", this.BPMSoft.Features.getIsEnabled("UserCalendar"));
					this.checkRightOperation();
					this.callParent(arguments);
				},

				/**
				 * Checks of rights for administration.
				 * @private
				 */
				checkRightOperation: function() {
					RightUtilities.checkCanExecuteOperation({
						operation: this.getOperationRight()
					}, function(result) {
						this.handleRightOperation(result);
					}, this);
				},

				/**
				 * Returns operation right name.
				 * @protected
				 * @return {String} Operation name.
				 */
				getOperationRight: function() {
					return "CanManageAdministration";
				},

				/**
				 * Handler for response checks of rights.
				 * @protected
				 * @param {Boolean} result Result of the response.
				 */
				handleRightOperation: function(result) {
					this.set("CanManageOperation", result);
				}
			},
			diff: [
				{
					"operation": "insert",
					"name": "Name",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "Name"
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "TimeZone",
					"values": {
						"layout": {
							"column": 13,
							"row": 0,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "TimeZone"
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "Description",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "Description"
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "User",
					"values": {
						"layout": {
							"column": 13,
							"row": 1,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "User",
						"visible": {"bindTo": "IsUserCalendarFeature"},
						"enabled": {"bindTo": "CanManageOperation"}
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "AroundClock",
					"values": {
						"layout": {
							"column": 13,
							"row": 2,
							"colSpan": 4,
							"rowSpan": 1
						},
						"bindTo": "AroundClock",
						"visible": false
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "WithoutDayOff",
					"values": {
						"layout": {
							"column": 16,
							"row": 2,
							"colSpan": 4,
							"rowSpan": 1
						},
						"bindTo": "WithoutDayOff",
						"visible": false
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "remove",
					"name": "ESNTab"
				},
				{
					"operation": "remove",
					"name": "ESNFeedContainer"
				},
				{
					"operation": "remove",
					"name": "ESNFeed"
				},
				{
					"operation": "insert",
					"name": "WorkingWeekTab",
					"values": {
						"caption": {
							"bindTo": "Resources.Strings.WorkingWeekTabCaption"
						},
						"items": []
					},
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "WorkingWeek",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					},
					"parentName": "WorkingWeekTab",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "DaysOffTab",
					"values": {
						"caption": {
							"bindTo": "Resources.Strings.DaysOffTabCaption"
						},
						"items": []
					},
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 1
				},
				{
					"operation": "insert",
					"name": "DayOffs",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					},
					"parentName": "DaysOffTab",
					"propertyName": "items",
					"index": 0
				}
			],
			rules: {},
			userCode: {}
		};
	});
