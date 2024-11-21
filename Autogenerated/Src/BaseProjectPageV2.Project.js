define("BaseProjectPageV2", ["BPMSoft", "BusinessRuleModule", "XRMConstants", "ProjectUtilities"],
	function(BPMSoft, BusinessRuleModule, XRMConstants) {
		return {
			entitySchemaName: "Project",
			attributes: {
				"getDurationByMask": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelSchemaItem.METHOD
				},
				"Owner": {
					"dataValueType": BPMSoft.DataValueType.LOOKUP,
					"lookupListConfig": {
						"filter": function() {
							return BPMSoft.createColumnIsNotNullFilter("[SysAdminUnit:Contact].Id");
						}
					}
				},
				"IsAutoCalcCompletion": {
					"dependencies": [
						{
							"columns": ["IsAutoCalcCompletion"],
							"methodName": "onIsAutoCalcCompletionChanged"
						}
					]
				},
				"StartDate": {
					"dependencies": [
						{
							"columns": ["EndDate"],
							"methodName": "onEndDateChange"
						}
					]
				},
				"EndDate": {
					"dependencies": [
						{
							"columns": ["StartDate"],
							"methodName": "onStartDateChanged"
						}
					]
				}
			},
			mixins: {
				/**
				 * Mixin with actions for the project calculation.
				 */
				ProjectUtilities: "BPMSoft.ProjectUtilities"
			},
			details: /**SCHEMA_DETAILS*/{
				"ProjectStructureDetailV2": {
					"schemaName": "ProjectStructureDetailV2",
					"filter": {
						"detailColumn": "ParentProject",
						"masterColumn": "Id"
					},
					"defaultValues": {
						"ParentProject": {
							"masterColumn": "Id"
						},
						"Account": {
							"masterColumn": "Account"
						},
						"Contact": {
							"masterColumn": "Contact"
						}
					}
				},
				"Files": {
					"schemaName": "FileDetailV2",
					"entitySchemaName": "ProjectFile",
					"filter": {
						"detailColumn": "Project",
						"masterColumn": "Id"
					}
				}
			}, /**SCHEMA_DETAILS*/
			methods: {

				/**
				 * @inheritDoc BPMSoft.BaseModulePageV2#init
				 * @overridden
				 */
				init: function() {
					this.mixins.ProjectUtilities.init.call(this);
					this.callParent(arguments);
				},

				/**
				 * @inheritDoc BPMSoft.BaseModulePageV2#onGridRowChanged
				 * @overridden
				 */
				onGridRowChanged: function() {
					this.set("StartDate", null);
					this.set("EndDate", null);
					return this.callParent(arguments);
				},

				/**
				 * @inheritDoc BPMSoft.BaseModulePageV2#getActions
				 * @overridden
				 */
				getActions: function() {
					var actionMenuItems = this.callParent(arguments);
					actionMenuItems.addItem(this.getButtonMenuItem({
						"Type": "BPMSoft.MenuSeparator",
						"Caption": {"bindTo": "Resources.Strings.ManpowerGroupCaption"}
					}));
					actionMenuItems.addItem(this.getButtonMenuItem({
						"Caption": {"bindTo": "Resources.Strings.CalculateProjectActualWorkActionCaption"},
						"Tag": "calculateActualWork",
						"Enabled": {"bindTo": "canEntityBeOperated"}
					}));
					actionMenuItems.addItem(this.getButtonMenuItem({
						"Caption": {"bindTo": "Resources.Strings.CalculateProjectLaborPlanActionCaption"},
						"Tag": "calculateLaborPlan",
						"Enabled": {"bindTo": "canEntityBeOperated"}
					}));
					return actionMenuItems;
				},

				/**
				 * Calculates labor for subordinate plan.
				 * @protected
				 * @virtual
				 */
				calculateLaborPlan: function() {
					this.CalculateProjectLaborPlan([this.get("Id")], this.onProjectLaborPlanCalculated, this);
				},

				/**
				 * Opens calculation result of the labor costs for subordinates.
				 * @protected
				 * @virtual
				 */
				onProjectLaborPlanCalculated: BPMSoft.emptyFn,

				/**
				 * Calculates actual labor costs.
				 * @protected
				 * @virtual
				 */
				calculateActualWork: function() {
					this.CalculateProjectActualWork([this.get("Id")], this.onProjectCollectionActualWorkCalculated, this);
				},

				/**
				 * Processes result of the conversion of actual work.
				 * @protected
				 * @virtual
				 */
				onProjectCollectionActualWorkCalculated: function() {
					this.updateActualCompletion();
				},

				/**
				 * Start date on change event handler.
				 * @protected
				 * @virtual
				 */
				onStartDateChanged: function() {
					var startDate = this.get("StartDate");
					if (!startDate) {
						return;
					}
					var endDate = this.get("EndDate");
					if (endDate && endDate < startDate) {
						this.showInformationDialog(this.get("Resources.Strings.EndDateLessStartDate"), function() {
						}, {
							style: BPMSoft.MessageBoxStyles.ORANGE
						});
						this.set("EndDate", startDate);
					}
					this.updateDuration();
				},

				/**
				 * Due date on change event handler.
				 * @protected
				 * @virtual
				 */
				onEndDateChange: function() {
					var endDate = this.get("EndDate");
					if (!endDate) {
						return;
					}
					var startDate = this.get("StartDate");
					if (startDate && endDate < startDate) {
						this.showInformationDialog(this.get("Resources.Strings.EndDateLessStartDate"), function() {
						}, {
							style: BPMSoft.MessageBoxStyles.ORANGE
						});
						this.set("StartDate", endDate);
					}
					this.updateDuration();
				},

				/**
				 * Returns the length of the project.
				 * @protected
				 * @virtual
				 * @return {String} The length of the project.
				 */
				getDurationByMask: function() {
					var duration = this.get("Duration") || 0;
					var hour = Math.round(duration / 60);
					var minute = duration % 60;
					var minuteMask = this.get("Resources.Strings.MinuteMask");
					var hourMask = this.get("Resources.Strings.HourMask");
					var result = ((hour > 0) ? this.Ext.String.format(hourMask, hour) + " " : "") +
						this.Ext.String.format(minuteMask, minute);
					return result;
				},

				/**
				 * Updates the duration of the project, depending on the date of the start and end dates.
				 * @protected
				 * @virtual
				 */
				updateDuration: function() {
					var startDate = this.get("StartDate");
					var endDate = this.get("EndDate");
					if (this.Ext.isEmpty(startDate) || this.Ext.isEmpty(endDate)) {
						this.set("Duration", 0);
						return;
					}
					this.getWorkingTimeBetweenDates(startDate, endDate, function(duration) {
						this.set("Duration", duration);
					}, this);
				},

				/**
				 * ############ ######### #### "############ #############"
				 * @protected
				 * @virtual
				 */
				onIsAutoCalcCompletionChanged: function() {
					if (!this.get("IsAutoCalcCompletion")) {
						this.set("ActualCompletion", 0);
						return;
					}
					var projectId = this.get(this.primaryColumnName);
					this.getProjectActualCompletion(projectId, function(response) {
						this.set("ActualCompletion", response || 0);
					}, this);
				},

				/**
				 * ######### #### "% ##########" ######## ##### ###### #######
				 * @protected
				 * @virtual
				 */
				updateActualCompletion: function() {
					if (!this.isEditMode()) {
						return;
					}
					var primaryColumnValue = this.get(this.primaryColumnName);
					var select = Ext.create("BPMSoft.EntitySchemaQuery", {rootSchema: this.entitySchema});
					select.addColumn("ActualCompletion");
					select.getEntity(primaryColumnValue, function(response) {
						var entity = response.entity;
						if (response.success && entity) {
							this.set("ActualCompletion", entity.get("ActualCompletion"));
						}
					}, this);
				},

				/**
				 * ######### # ######## ## ######### #### #########
				 * @protected
				 * @overridden
				 * @return {Object[]} ########## ###### ######## ## #########
				 */
				getDefaultValues: function() {
					var defaultValues = this.callParent(arguments);
					defaultValues.push({
						name: "EndDate",
						value: this.getNextWorkingDay(new Date())
					});
					return defaultValues;
				},

				/**
				 * ####### ######### ####### #### ##### ########## ####
				 * @param {Date} date #### ## ####### ####### #####
				 * @return {Date} ########## ######### ####### #### ##### ########## ####
				 */
				getNextWorkingDay: function(date) {
					var notWorkingDays = [0, 6];
					var dateDay = this.getNextDay(date);
					while (notWorkingDays.indexOf(dateDay) !== -1) {
						dateDay = this.getNextDay(date);
					}
					return date;
				},

				/**
				 * ######### # ########## #### #### ####
				 * @param {Date} date #### ### #######
				 * @return {number} ########## #### ###### ##### ####
				 */
				getNextDay: function(date) {
					date.setDate(date.getDate() + 1);
					return date.getDay();
				},

				/**
				 * ########## ######## ###### #############.
				 * #### ############ ############ ########, ####### ######### # ############# ########## #######.
				 * ##### ########## callback-#######
				 * @protected
				 * @overridden
				 * @param {Function} callback callback-#######
				 * @param {BPMSoft.BaseSchemaViewModel} scope ######## ########## callback-#######
				 */
				asyncValidate: function(callback, scope) {
					this.callParent([function(response) {
						if (!this.validateResponse(response)) {
							return;
						}
						this.validateAccountOrContactFilling(function(response) {
							if (!this.validateResponse(response)) {
								return;
							}
							callback.call(scope, response);
						}, this);
					}, this]);
				},

				/**
				 * #########, ######### ## #### ## #### ## ##### "#######" ### "##########"
				 * @param {Function} callback
				 * @param {Object} scope
				 */
				validateAccountOrContactFilling: function(callback, scope) {
					var account = this.get("Account");
					var contact = this.get("Contact");
					var result = {success: true};
					if (this.Ext.isEmpty(account) && this.Ext.isEmpty(contact)) {
						var accountColumnCaption = this.getColumnByName("Account").caption;
						var contactColumnCaption = this.getColumnByName("Contact").caption;
						result.message = this.Ext.String.format(this.get("Resources.Strings.ContactAccountRequire"),
							accountColumnCaption, contactColumnCaption);
						result.success = false;
					}
					callback.call(scope || this, result);
				},

				/**
				 * ############## ################ ########## #### ######### # ############# #######
				 * @protected
				 * @overridden
				 */
				setValidationConfig: function() {
					this.callParent(arguments);
					this.addColumnValidator("DueDate", function(value) {
						var startDate = this.get("StartDate");
						var invalidMessage = (startDate && (startDate > value))
							? this.get("Resources.Strings.StartDateGreaterDueDate")
							: "";
						return {
							fullInvalidMessage: invalidMessage,
							invalidMessage: invalidMessage
						};
					});
					this.addColumnValidator("ParentProject", function(value) {
						var primaryColumnValue = this.get(this.primaryColumnName);
						var invalidMessage = (value && (primaryColumnValue === value.value))
							? this.get("Resources.Strings.BindToSelfWarningMessage")
							: "";
						return {
							fullInvalidMessage: invalidMessage,
							invalidMessage: invalidMessage
						};
					});
				},

				/**
				 * ########## ######### ### ########### ########
				 * @param {Boolean} value ########
				 * @return {Boolean} ########## ######### ### ########### ########
				 */
				denialConverter: function(value) {
					return !value;
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Name",
					"values": {
						"layout": {"column": 0, "row": 0, "colSpan": 24}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Status",
					"values": {
						"layout": {"column": 0, "row": 1, "colSpan": 11},
						"contentType": BPMSoft.ContentType.ENUM
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Owner",
					"values": {
						"layout": {"column": 13, "row": 1, "colSpan": 11},
						"tip": {
							"content": {"bindTo": "Resources.Strings.OwnerTip"}
						}
					}
				},
				{
					"operation": "insert",
					"name": "GeneralInfoTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 0,
					"values": {
						"caption": {"bindTo": "Resources.Strings.GeneralInfoTabCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "GeneralInfoTab",
					"name": "GeneralInfoControlGroup",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
						"items": [],
						"controlConfig": {
							"collapsed": false
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "GeneralInfoControlGroup",
					"propertyName": "items",
					"name": "GeneralInfoBlock",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "GeneralInfoBlock",
					"propertyName": "items",
					"name": "Account",
					"values": {
						"layout": {"column": 0, "row": 0, "colSpan": 11}
					}
				},
				{
					"operation": "insert",
					"parentName": "GeneralInfoBlock",
					"propertyName": "items",
					"name": "Contact",
					"values": {
						"layout": {"column": 13, "row": 0, "colSpan": 11}
					}
				},
				{
					"operation": "insert",
					"parentName": "GeneralInfoBlock",
					"propertyName": "items",
					"name": "ActualCompletion",
					"values": {
						"layout": {"column": 0, "row": 1, "colSpan": 11},
						"tip": {
							"content": {"bindTo": "Resources.Strings.ActualCompletionTip"}
						},
						"enabled": {
							"bindTo": "IsAutoCalcCompletion",
							"bindConfig": {"converter": "denialConverter"}
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "GeneralInfoBlock",
					"propertyName": "items",
					"name": "IsAutoCalcCompletion",
					"values": {
						"layout": {"column": 13, "row": 1, "colSpan": 11}
					}
				},
				{
					"operation": "insert",
					"parentName": "GeneralInfoBlock",
					"propertyName": "items",
					"name": "StartDate",
					"values": {
						"layout": {"column": 0, "row": 2, "colSpan": 11}
					}
				},
				{
					"operation": "insert",
					"parentName": "GeneralInfoBlock",
					"propertyName": "items",
					"name": "getDurationByMask",
					"values": {
						"caption": {"bindTo": "Resources.Strings.DurationByMask"},
						"enabled": false,
						"layout": {"column": 13, "row": 2, "colSpan": 11}
					}
				},
				{
					"operation": "insert",
					"parentName": "GeneralInfoBlock",
					"propertyName": "items",
					"name": "EndDate",
					"values": {
						"layout": {"column": 0, "row": 3, "colSpan": 11}
					}
				},
				{
					"operation": "insert",
					"parentName": "GeneralInfoBlock",
					"propertyName": "items",
					"name": "Deadline",
					"values": {
						"layout": {"column": 13, "row": 3}
					}
				},
				{
					"operation": "insert",
					"parentName": "GeneralInfoTab",
					"name": "LinksControlGroup",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
						"caption": {"bindTo": "Resources.Strings.LinksControlGroupCaption"},
						"items": [],
						"controlConfig": {
							"collapsed": false
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "LinksControlGroup",
					"propertyName": "items",
					"name": "LinksControlBlock",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "LinksControlBlock",
					"propertyName": "items",
					"name": "Supplier",
					"values": {
						"layout": {"column": 13, "row": 0, "colSpan": 11}
					}
				},
				{
					"operation": "insert",
					"name": "StructureTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 1,
					"values": {
						"caption": {"bindTo": "Resources.Strings.StructureTabCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "HistoryTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"values": {
						"caption": {"bindTo": "Resources.Strings.HistoryTabCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "StructureTab",
					"propertyName": "items",
					"name": "ProjectStructureDetailV2",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL
					}
				},
				{
					"operation": "insert",
					"name": "NotesAndFilesTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"values": {
						"caption": {"bindTo": "Resources.Strings.NotesAndFilesTabCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "NotesAndFilesTab",
					"propertyName": "items",
					"name": "Files",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL
					}
				},
				{
					"operation": "insert",
					"name": "NotesControlGroup",
					"parentName": "NotesAndFilesTab",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
						"items": [],
						"caption": {"bindTo": "Resources.Strings.NotesGroupCaption"},
						"controlConfig": {
							"collapsed": false
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "NotesControlGroup",
					"propertyName": "items",
					"name": "Notes",
					"values": {
						"contentType": BPMSoft.ContentType.RICH_TEXT,
						"layout": {"column": 0, "row": 0, "colSpan": 24},
						"labelConfig": {
							"visible": false
						},
						"controlConfig": {
							"imageLoaded": {
								"bindTo": "insertImagesToNotes"
							},
							"images": {
								"bindTo": "NotesImagesCollection"
							}
						}
					}
				}
			]/**SCHEMA_DIFF*/,
			rules: {
				"Type": {
					"BindParameterRequiredTypeToProjectEntryType": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.REQUIRED,
						"conditions": [
							{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "ProjectEntryType"
								},
								"comparisonType": BPMSoft.ComparisonType.EQUAL,
								"rightExpression": {
									"type": BusinessRuleModule.enums.ValueType.CONSTANT,
									"value": XRMConstants.Project.EntryType.Project
								}
							}
						]
					}
				},
				"Contact": {
					"FiltrationContactByAccount": {
						"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
						"autocomplete": true,
						"autoClean": true,
						"baseAttributePatch": "Account",
						"comparisonType": BPMSoft.ComparisonType.EQUAL,
						"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
						"attribute": "Account"
					}
				}
			}
		};
	});
