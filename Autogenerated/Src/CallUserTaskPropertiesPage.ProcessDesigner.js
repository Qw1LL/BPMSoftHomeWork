/**
 * Edit page schema of process element Call user task.
 * Parent: BaseActivityUserTaskPropertiesPage
 */
define("CallUserTaskPropertiesPage", [], function() {
	return {
		attributes: {
			/**
			 * Start in.
			 * @type {DateTime}
			 */
			"StartIn": {
				dataValueType: this.BPMSoft.DataValueType.MAPPING,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				doAutoSave: true,
				initMethod: "initProperty"
			},
			/**
			 * Start in period.
			 * @type {Integer}
			 */
			"StartInPeriod": {
				dataValueType: this.BPMSoft.DataValueType.LOOKUP,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true,
				doAutoSave: true,
				initMethod: "_initPeriod"
			},
			/**
			 * Duration.
			 * @type {DateTime}
			 */
			"Duration": {
				dataValueType: this.BPMSoft.DataValueType.MAPPING,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				doAutoSave: true,
				initMethod: "initProperty"
			},
			/**
			 * Duration period.
			 * @type {Integer}
			 */
			"DurationPeriod": {
				dataValueType: this.BPMSoft.DataValueType.LOOKUP,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true,
				doAutoSave: true,
				initMethod: "_initPeriod"
			},
			/**
			 * Remind before.
			 * @type {DateTime}
			 */
			"RemindBefore": {
				dataValueType: this.BPMSoft.DataValueType.MAPPING,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				doAutoSave: true,
				initMethod: "initProperty"
			},
			/**
			 * Remind before period.
			 * @type {Integer}
			 */
			"RemindBeforePeriod": {
				dataValueType: this.BPMSoft.DataValueType.LOOKUP,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true,
				doAutoSave: true,
				initMethod: "_initPeriod"
			},
			/**
			 * Show in scheduler.
			 * @type {Boolean}
			 */
			"ShowInScheduler": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				doAutoSave: true,
				initMethod: "initProperty"
			}
		},
		methods: {

			/**
			 * Sets display period value.
			 * @private
			 * @param {BPMSoft.ProcessSchemaParameter} parameter Process parameter.
			 */
			_initPeriod: function(parameter) {
				const parameterName = parameter.name;
				const value = parameter.getValue();
				const periodConfig = this.getPeriodConfig();
				const item = BPMSoft.findWhere(periodConfig, {value: value});
				this.set(parameterName, item);
			},

			/**
			 * Returns period.
			 * @private
			 * @return {Object}.
			 */
			getPeriodConfig: function() {
				return {
					"minutes": {
						value: "0",
						displayValue: this.get("Resources.Strings.MinutesCaption")
					},
					"hours": {
						value: "1",
						displayValue: this.get("Resources.Strings.HoursCaption")
					},
					"days": {
						value: "2",
						displayValue: this.get("Resources.Strings.DaysCaption")
					},
					"weeks": {
						value: "3",
						displayValue: this.get("Resources.Strings.WeeksCaption")
					},
					"months": {
						value: "4",
						displayValue: this.get("Resources.Strings.MonthsCaption")
					}
				};
			},

			/**
			 * The event handler for preparing of the data drop-down period.
			 * @private
			 * @param {Object} filter Filters for data preparation.
			 * @param {BPMSoft.Collection} list The data for the drop-down list.
			 */
			onPreparePeriodList: function(filter, list) {
				if (BPMSoft.isEmptyObject(list)) {
					return;
				}
				list.clear();
				list.loadAll(this.getPeriodConfig());
			},

			/**
			 * @inheritDoc ProcessFlowElementPropertiesPage#getResultParameterAllValues
			 * @overridden
			 */
			getResultParameterAllValues: function(callback, scope) {
				var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "ActivityCategoryResultEntry"
				});
				esq.addColumn("ActivityResult.Id", "ActivityResultId");
				esq.addColumn("ActivityResult.Name", "ActivityResultName");
				var filter = esq.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
					"ActivityCategory.ActivityType.Code", "Call", this.BPMSoft.DataValueType.TEXT);
				esq.filters.add("CodeFilter", filter);
				esq.execute(function(result) {
					var resultParameterValues = {};
					if (result.success === true) {
						result.collection.each(function(item) {
							var id = item.get("ActivityResultId");
							var name = item.get("ActivityResultName");
							resultParameterValues[id] = name;
						});
					}
					callback.call(scope, resultParameterValues);
				});
			},

			/**
			 * @inheritDoc RootUserTaskPropertiesPage#getResultParameterAllValues
			 * @overridden
			 */
			getIsPerformerAssignmentEnabled: function() {
				return false;
			},

			/**
			 * @inheritDoc BaseUserTaskPropertiesPage#getIsActivityModuleEnabled
			 * @overridden
			 */
			getIsActivityModuleEnabled: function() {
				return false;
			}
		},
		diff: [
			{
				"operation": "remove",
				"name": "ActivityControlsContainer",
				"parentName": "TaskPropertiesContainer",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "StartInLabel",
				"parentName": "TitleTaskContainer",
				"propertyName": "items",
				"values": {
					"layout": { "column": 0, "row": 2, "colSpan": 24 },
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": { "bindTo": "Resources.Strings.StartInCaption" },
					"classes": {
						"labelClass": ["t-label-proc"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "StartIn",
				"parentName": "TitleTaskContainer",
				"propertyName": "items",
				"values": {
					"layout": { "column": 0, "row": 3, "colSpan": 14 },
					"labelConfig": {
						"visible": false
					}
				}
			},
			{
				"operation": "insert",
				"name": "StartInPeriod",
				"parentName": "TitleTaskContainer",
				"propertyName": "items",
				"values": {
					"layout": { "column": 16, "row": 3, "colSpan": 8 },
					"contentType": BPMSoft.ContentType.ENUM,
					"controlConfig": {
						"prepareList": {
							"bindTo": "onPreparePeriodList"
						}
					},
					"labelConfig": {
						"visible": false
					}
				}
			},
			{
				"operation": "insert",
				"name": "DurationLabel",
				"parentName": "TitleTaskContainer",
				"propertyName": "items",
				"values": {
					"layout": { "column": 0, "row": 4, "colSpan": 24 },
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": { "bindTo": "Resources.Strings.DurationCaption" },
					"classes": {
						"labelClass": ["t-label-proc"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "Duration",
				"parentName": "TitleTaskContainer",
				"propertyName": "items",
				"values": {
					"layout": { "column": 0, "row": 5, "colSpan": 14 },
					"labelConfig": {
						"visible": false
					},
					"classes": {
						"labelClass": ["t-label-proc"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "DurationPeriod",
				"parentName": "TitleTaskContainer",
				"propertyName": "items",
				"values": {
					"layout": { "column": 16, "row": 5, "colSpan": 8 },
					"contentType": BPMSoft.ContentType.ENUM,
					"controlConfig": {
						"prepareList": {
							"bindTo": "onPreparePeriodList"
						}
					},
					"labelConfig": {
						"visible": false
					}
				}
			},
			{
				"operation": "insert",
				"name": "ShowInScheduler",
				"parentName": "TitleTaskContainer",
				"propertyName": "items",
				"values": {
					"layout": { "column": 0, "row": 6, "colSpan": 24 },
					"caption": { "bindTo": "Resources.Strings.ShowInSchedulerCaption" },
					"wrapClass": ["t-checkbox-control"]
				}
			},
			{
				"operation": "merge",
				"name": "BaseActivityTaskContainer",
				"values": {
					"collapseEmptyRow": true
				}
			},
			{
				"operation": "insert",
				"name": "RemindBeforeLabel",
				"parentName": "BaseActivityTaskContainer",
				"propertyName": "items",
				"values": {
					"layout": { "column": 0, "row": 5, "colSpan": 24 },
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": { "bindTo": "Resources.Strings.RemindBeforeCaption" },
					"classes": {
						"labelClass": ["t-label-proc"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "RemindBefore",
				"parentName": "BaseActivityTaskContainer",
				"propertyName": "items",
				"values": {
					"layout": { "column": 0, "row": 6, "colSpan": 14 },
					"labelConfig": {
						"visible": false
					},
					"classes": {
						"labelClass": ["t-label-proc"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "RemindBeforePeriod",
				"parentName": "BaseActivityTaskContainer",
				"propertyName": "items",
				"values": {
					"layout": { "column": 16, "row": 6, "colSpan": 8 },
					"contentType": BPMSoft.ContentType.ENUM,
					"controlConfig": {
						"prepareList": {
							"bindTo": "onPreparePeriodList"
						}
					},
					"labelConfig": {
						"visible": false
					}
				}
			},
		]
	};
});
