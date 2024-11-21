define("ActivityMiniPage", ["ConfigurationConstants", "BusinessRuleModule", "BaseFiltersGenerateModule",
	"ProcessModuleUtilities", "EntityConnectionLinksUtilities", "ActivityDatesMixin",
	"MiniPageEntityConnectionsUtils", "MiniPageEditControlsGenerator", "MiniPageDatePeriodGenerator",
	"LookupQuickAddMixin", "css!ActivityMiniPageCSS", "ActivityTimezoneMixin", "css!ActivityTimezoneMixin"
], function(ConfigurationConstants, BusinessRuleModule, BaseFiltersGenerateModule, ProcessModuleUtilities) {
	return {
		entitySchemaName: "Activity",
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		mixins: {
			EntityConnectionLinksUtilities: BPMSoft.EntityConnectionLinksUtilities,
			MiniPageEntityConnectionsUtils: BPMSoft.MiniPageEntityConnectionsUtils,
			ActivityDatesMixin: BPMSoft.ActivityDatesMixin,
			LookupQuickAddMixin: "BPMSoft.LookupQuickAddMixin",
			ActivityTimezoneMixin: BPMSoft.ActivityTimezoneMixin
		},
		attributes: {
			/**
			 * @inheritdoc BaseMiniPage#MiniPageModes
			 * @override
			 */
			"MiniPageModes": {
				"value": [this.BPMSoft.ConfigurationEnums.CardOperation.VIEW,
					this.BPMSoft.ConfigurationEnums.CardOperation.EDIT,
					this.BPMSoft.ConfigurationEnums.CardOperation.ADD]
			},

			/**
			 * Contains activity category, StartDate and DueDate.
			 * @type {String}
			 */
			"ActivityGeneralInfo": {
				"dataValueType": this.BPMSoft.DataValueType.TEXT,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Entity connections container visibility.
			 * @type {Boolean}
			 */
			"EntityConnectionsVisibility": {
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
				"value": false
			},

			/**
			 * Entity connections list.
			 * @type {BPMSoft.Collection}
			 */
			"EntityConnectionsList": {
				"dataValueType": this.BPMSoft.DataValueType.COLLECTION
			},

			/**
			 * Entity connections menu items.
			 * @type {BPMSoft.Collection}
			 */
			"EntityConnectionMenuItems": {
				"dataValueType": this.BPMSoft.DataValueType.COLLECTION
			},

			/**
			 * Activity status display value.
			 * @type {String}
			 */
			"ActivityStatus": {
				"dataValueType": this.BPMSoft.DataValueType.TEXT,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * True if activity need to be canceled or done.
			 * @type {Boolean}
			 */
			"ShowEditableResults": {
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			/**
			 * True if page is switched to quick status submit mode
			 * Quick complete or cancel
			 * @type {Boolean}
			 */
			"IsQuickFinalStatusSubmitMode": {
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Activity owner role.
			 * @type {Object}
			 */
			"OwnerRole": {
				"type": this.BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
				"dependencies": [
					{
						"columns": ["OwnerRole"],
						"methodName": "onOwnerRoleChange"
					}
				]
			},

			/**
			 * Activity entity owner column.
			 * @type {Object}
			 */
			"Owner": {
				"type": this.BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
				"lookupListConfig": {
					"filter": function() {
						const roleId = this.getLookupValue("OwnerRole");
						return this._getIsUseProcessPerformerAssignment()
							? BaseFiltersGenerateModule.OwnersInRoleFilter(roleId)
							: BaseFiltersGenerateModule.OwnerFilter();
					}
				}
			},

			/**
			 * Activity entity status column.
			 * @type {Object}
			 */
			"Status": {
				"type": this.BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
				"lookupListConfig": {
					"columns": ["Finish"]
				},
				"dependencies": [
					{
						"columns": ["Status"],
						"methodName": "onStatusChanged"
					}
				]
			},

			/**
			 * Activity entity category column. Shows only task category.
			 * @type {Object}
			 */
			"ActivityCategory": {
				"type": this.BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
				"lookupListConfig": {
					"filters": [
						function() {
							var type = this.get("Type");
							var filterGroup = this.Ext.create("BPMSoft.FilterGroup");
							if (type) {
								filterGroup.add("ActivityTypeFilter",
									this.BPMSoft.createColumnFilterWithParameter(
										this.BPMSoft.ComparisonType.EQUAL,
										"ActivityType",
										type.value));
							}
							return filterGroup;
						}
					]
				}
			},

			/**
			 * Activity entity result column.
			 * @type {Object}
			 */
			"Result": {
				"type": this.BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
				"lookupListConfig": {
					"filters": [
						function() {
							var type = this.get("ActivityCategory");
							var filterGroup = Ext.create("BPMSoft.FilterGroup");
							filterGroup.add("ActivityCategory",
								BPMSoft.createColumnFilterWithParameter(
									BPMSoft.ComparisonType.EQUAL,
									"[ActivityCategoryResultEntry:ActivityResult].ActivityCategory",
									type.value));
							filterGroup.add("BusinessProcessOnly",
								BPMSoft.createColumnFilterWithParameter(
									BPMSoft.ComparisonType.EQUAL,
									"BusinessProcessOnly",
									0));
							return filterGroup;
						}
					]
				}
			},

			/**
			 * Contains activity result and detail results.
			 * @type {String}
			 */
			"ResultInfo": {
				"dataValueType": this.BPMSoft.DataValueType.TEXT,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Activity entity start date column.
			 * @type {Object}
			 */
			"StartDate": {
				"dataValueType": this.BPMSoft.DataValueType.DATE_TIME,
				"type": this.BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
				"dependencies": [
					{
						"columns": ["StartDate"],
						"methodName": "onStartDateChanged"
					},
					{
						"columns": ["StartDate"],
						"methodName": "setOffsetDates"
					}
				]
			},

			/**
			 * Activity entity due date column.
			 * @type {Object}
			 */
			"DueDate": {
				"dataValueType": BPMSoft.DataValueType.DATE_TIME,
				"type": this.BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
				"dependencies": [
					{
						"columns": ["DueDate"],
						"methodName": "onDueDateChanged"
					},
					{
						"columns": ["DueDate"],
						"methodName": "setOffsetDates"
					}
				]
			},

			/**
			 * Date and time start activity with offset.
			 * @type {Object}
			 */
			"OffsetStartDate": {
				"dataValueType": BPMSoft.DataValueType.DATE_TIME,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dependencies": [
					{
						"columns": ["OffsetStartDate"],
						"methodName": "onStartDateOffsetChanged"
					}
				]
			},

			/**
			 * Date and time activity completion with offset.
			 * @type {Object}
			 */
			"OffsetDueDate": {
				"dataValueType": BPMSoft.DataValueType.DATE_TIME,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dependencies": [
					{
						"columns": ["OffsetDueDate"],
						"methodName": "onDueDateOffsetChanged"
					}
				]
			},

			/**
			 * Time zone.
			 * @type {Object}
			 */
			"TimeZone": {
				"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
				"type": this.BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
				"dependencies": [
					{
						"columns": ["TimeZone"],
						"methodName": "onTimezoneChanged"
					}
				],
				"lookupListConfig": {
					"columns": ["Code"]
				}
			},

			/**
			 * Container of time zone visible state.
			 * @type {Boolean}
			 */
			"TimezoneContainerVisible": {
				"dataValueType": this.BPMSoft.DataValueType.VIRTUAL_COLUMN,
				"value": false
			},

			/**
			 * Sets focus on activity title.
			 * @type {Boolean}
			 */
			"IsTitleFocused": {
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
				"value": false
			},

			/**
			 * Sets focus on activity title.
			 * @type {Boolean}
			 */
			"CanRenderMiniPage": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"value": false
			},

			/**
			 * Results from process.
			 * @type {BPMSoft.Collection}
			 */
			"ProcessResultList": {
				"dataValueType": this.BPMSoft.DataValueType.COLLECTION
			},

			/**
			 * Process result.
			 * @type {Object}
			 */
			"ProcessResult": {
				"dataValueType": this.BPMSoft.DataValueType.LOOKUP
			},

			/**
			 * Remind to author attribute.
			 * @type {Boolean}
			 */
			"RemindToAuthor": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				dependencies: [
					{
						columns: ["RemindToAuthor"],
						methodName: "onRemindToAuthorChanged"
					}
				]
			},

			/**
			 * Remind to owner attribute.
			 * @type {Boolean}
			 */
			"RemindToOwner": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				dependencies: [
					{
						columns: ["RemindToOwner"],
						methodName: "onRemindToOwnerChanged"
					}
				]
			}
		},
		messages: {
			/**
			 * @message GetSchedulerSelectionPressedKeys
			 * Notify about pressed keys on scheduler.
			 * @type {Object}
			 */
			"GetSchedulerSelectionPressedKeys": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message ChangeDashboardTab
			 * Changes dashboard tab to default.
			 */
			"ChangeDashboardTab": {
				mode: this.BPMSoft.MessageMode.BROADCAST,
				direction: this.BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		methods: {
			/**
			 * @inheritdoc BaseMiniPage#init
			 * @override
			 */
			init: function() {
				this.callParent(arguments);
				this.initEmailExtendedMenuButtonCollections(["Contact", "Account"], this.close.bind(this));
				this.initCallExtendedMenuButtonCollections(["Contact", "Account"], this.close.bind(this));
				this.set("EntityConnectionsList", this.Ext.create("BPMSoft.BaseViewModelCollection"));
				this.set("EntityConnectionMenuItems", this.Ext.create("BPMSoft.BaseViewModelCollection"));
				this.set("ProcessResultList", this.Ext.create("BPMSoft.Collection"));
			},

			/**
			 * @inheritdoc BaseMiniPage#onEntityInitialized
			 * @override
			 */
			onEntityInitialized: function(callback, scope) {
				var parentMethods = this.getParentMethod(this, [function() {
					this.set("CanRenderMiniPage", true);
					Ext.callback(callback, scope || this);
					if (this.getIsFeatureEnabled("ShowAllContactsAsOwner")) {
						this._applyLookupListConfigToOwnerColumn();
					}
				}, this]);
				this.initializeEntityData();
				this.setTitlePressedKeys();
				var entityConnectionsList = this.get("EntityConnectionsList");
				this.loadEntityConnections(entityConnectionsList, function() {
					if (!this.isEmpty(entityConnectionsList)) {
						entityConnectionsList.each(function(item) {
							item.initSyncMailboxCount();
						}, this);
					}
					this.mixins.MiniPageEntityConnectionsUtils.initEntityConnections.call(this);
					this.mixins.ActivityTimezoneMixin.init.call(this);
					this.initializeProcessData();
					parentMethods();
				}, this);
			},

			/**
			 * @private
			 */
			_applyLookupListConfigToOwnerColumn: function() {
				const ownerColumn = this.getColumnByName("Owner");
				ownerColumn.lookupListConfig = {
					filter: function() {
						const roleId = this.getLookupValue("OwnerRole");
						return this._getIsUseProcessPerformerAssignment()
							? BaseFiltersGenerateModule.UsersInRoleFilter(roleId)
							: BaseFiltersGenerateModule.AllUsersFilter();
					},
					orders: [
						{
							columnPath: "[VwSystemUsers:Contact].ConnectionType",
							direction: BPMSoft.OrderDirection.ASC
						}
					]
				};
			},

			/**
			 * @private
			 */
			_getIsUseProcessPerformerAssignment: function() {
				return this.getIsFeatureEnabled("UseProcessPerformerAssignment");
			},

			/**
			 * @private
			 */
			isUseProcessPerformerAssignment: function() {
				return this.isNotViewMode() && this._getIsUseProcessPerformerAssignment();
			},

			/**
			 * Initializes mini page process data.
			 * @protected
			 */
			initializeProcessData: function() {
				var primaryColumnValue = this.getPrimaryColumnValue();
				var processElementUId = this.get("ProcessElementId");
				if (this.Ext.isEmpty(primaryColumnValue) || this.Ext.isEmpty(processElementUId)) {
					return;
				}
				ProcessModuleUtilities.getExecutionData(processElementUId, primaryColumnValue,
					this.processExecDataCallback, this);
			},

			/**
			 * Process execution data callback.
			 * @protected
			 * @param {Object} options Instance of the request.
			 * @param {Boolean} success Service call executed successfully.
			 * @param {Object} response Server response.
			 */
			processExecDataCallback: function(options, success, response) {
				var processExecData = this.Ext.decode(this.Ext.decode(response.responseText));
				var hasCorrectData = !this.Ext.isEmpty(processExecData) &&
					this.Ext.isEmpty(processExecData.status);
				if (!hasCorrectData) {
					return;
				}
				this.set("AllowedResults", processExecData.allowedResults);
			},

			/**
			 * Calls on prepare process result list.
			 * @protected
			 */
			onPrepareProcessResultList: function() {
				var allowedResults = this.get("AllowedResults");
				if (allowedResults) {
					var decodedAllowedResults = this.Ext.decode(allowedResults);
					var processResults = this.get("ProcessResultList");
					processResults.clear();
					var results = this.Ext.create("BPMSoft.Collection");
					this.BPMSoft.each(decodedAllowedResults, function(result) {
						var categoryPosition = this.getProcessResultCategoryPosition(result.categoryId);
						var itemId = result.resultId;
						results.add(itemId, {
							id: itemId,
							value: itemId,
							displayValue: result.caption,
							categoryPosition: categoryPosition
						});
					}, this);
					results.sortByFn(this.sortByCategoryGroupAndCaption);
					processResults.loadAll(results);
				}
			},

			/**
			 * Returns comparison result.
			 * @private
			 * @param {Object} firstItem Comparable first item.
			 * @param {Object} secondItem Comparable second item.
			 * @return {Number} Comparison result.
			 */
			sortByCategoryGroupAndCaption: function(firstItem, secondItem) {
				if (firstItem.categoryPosition < secondItem.categoryPosition) {
					return -1;
				}
				if (firstItem.categoryPosition > secondItem.categoryPosition) {
					return 1;
				}
				if (firstItem.displayValue < secondItem.displayValue) {
					return -1;
				}
				if (firstItem.displayValue > secondItem.displayValue) {
					return 1;
				}
				return 0;
			},

			/**
			 * Returns result category position for sorting.
			 * @private
			 * @param {Guid} categoryId Category identifier.
			 * @return {Number} Category position number.
			 */
			getProcessResultCategoryPosition: function(categoryId) {
				var categoryPosition = 0;
				if (!this.Ext.isEmpty(categoryId)) {
					switch (categoryId.toLowerCase()) {
						case ConfigurationConstants.Activity.ResultCategory.Neutral.toLowerCase():
							categoryPosition = 1;
							break;
						case ConfigurationConstants.Activity.ResultCategory.Fail.toLowerCase():
							categoryPosition = 2;
							break;
						default:
							categoryPosition = 0;
					}
				}
				return categoryPosition;
			},

			/**
			 * Returns true if entity has process results.
			 * @protected
			 * @return {Boolean} True if entity has process results.
			 */
			hasProcessResults: function() {
				return this.isEditableResultsVisible() && this.hasAllowedResults();
			},

			/**
			 * Returns true if entity has results.
			 * @protected
			 * @return {Boolean} True if entity has results.
			 */
			hasResults: function() {
				return this.isEditableResultsVisible() && !this.hasAllowedResults();
			},

			/**
			 * Returns true if entity has AllowedResults.
			 * @private
			 * @return {Boolean} True if entity has AllowedResults.
			 */
			hasAllowedResults: function() {
				var allowedResults = this.get("AllowedResults");
				return !this.Ext.isEmpty(allowedResults) && !this.Ext.isEmpty(this.Ext.decode(allowedResults));
			},

			/**
			 * Executes methods on entity initialized.
			 * @private
			 */
			initializeEntityData: function() {
				this.loadStatuses(function() {
					var status = this.get("ActivityMiniPageStatus");
					if (status) {
						this.changeStatus(status);
					}
				}, this);
				if (this.isAddMode()) {
					this.setDefaultActivityDateInterval();
					this.set("IsTitleFocused", true);
					this.set("ShowInScheduler", true);
				} else {
					this.onDueDateChanged();
				}
				this.setActivityGeneralInfo();
				this.onStatusChanged();
				this.onResultChanged();
			},

			/**
			 * Sets title by pressed keys.
			 * @private
			 */
			setTitlePressedKeys: function() {
				var pressedKeys = this.sandbox.publish("GetSchedulerSelectionPressedKeys", null,
					[this.sandbox.id]);
				if (pressedKeys && pressedKeys.length) {
					this.set("Title", this.Ext.String.capitalize(pressedKeys));
				}
			},

			/**
			 * Initialize statuses list.
			 * @private
			 * @param {Function} [callback] Callback-function.
			 * @param {Object} [scope] Execution context.
			 */
			loadStatuses: function(callback, scope) {
				this.loadLookupData(null, this.get("StatusList"), "Status", false, callback, scope);
			},

			/*
			 * Generate activity date period.
			 * @private
			 */
			setActivityGeneralInfo: function() {
				var startDateTime = this.get("StartDate");
				var dueDateTime = this.get("DueDate");
				var statusInfo = "";
				if (startDateTime && dueDateTime) {
					var dateOptions = {
						month: "short",
						day: "numeric"
					};
					var timeFormat = this.BPMSoft.Resources.CultureSettings.timeFormat;
					var cultureName = this.BPMSoft.Resources.CultureSettings.currentCultureName;
					var startDate = this.BPMSoft.toLocaleDate(startDateTime, cultureName, dateOptions);
					var startTime = this.Ext.Date.format(startDateTime, timeFormat);
					var dueDate = this.BPMSoft.toLocaleDate(dueDateTime, cultureName, dateOptions);
					var dueTime = this.Ext.Date.format(dueDateTime, timeFormat);
					if (startDate === dueDate) {
						statusInfo += this.Ext.String.format("{0} {1} - {2}",
							startDate, startTime, dueTime);
					} else {
						statusInfo += this.Ext.String.format("{0} {1} - {2} {3}",
							startDate, startTime, dueDate, dueTime);
					}
				}
				this.set("ActivityGeneralInfo", statusInfo);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#setValidationConfig
			 * @override
			 */
			setValidationConfig: function() {
				this.callParent(arguments);
				this.addColumnValidator("ProcessResult", this.resultRequiredValidator);
				this.addColumnValidator("DueDate", this.dueDateValueValidator);
				this.addColumnValidator("OffsetDueDate", this.validateOffsetDueDate);
			},

			/**
			 * Activity result required validator.
			 * @protected
			 * @return {Object} Validation result info.
			 */
			resultRequiredValidator: function() {
				var invalidMessage = "";
				if (this.isRequiredResult() && this.isFinalStatus() && this.Ext.isEmpty(this.get("ProcessResult"))) {
					invalidMessage = this.BPMSoft.Resources.BaseViewModel.columnRequiredValidationMessage;
				}
				return {
					invalidMessage: invalidMessage
				};
			},

			/**
			 * Activity due date value validator.
			 * @protected
			 * @return {Object} Validation result info.
			 */
			dueDateValueValidator: function() {
				var invalidMessage = "";
				var startDate = this.get("StartDate");
				var dueDate = this.get("DueDate");
				if (!this.Ext.isEmpty(startDate) && !this.Ext.isEmpty(dueDate) && startDate > dueDate) {
					invalidMessage = this.get("Resources.Strings.StartDateGreaterDueDate");
				}
				return {
					invalidMessage: invalidMessage
				};
			},

			/**
			 * Determines if status can be changed.
			 * @protected
			 * @return {Boolean} Ability to change status information.
			 */
			canChangeStatus: function() {
				return this.get("IsEntityInitialized") && !this.isFinalStatus() && this.isViewMode() &&
					!this.get("ActivityMiniPageStatus");
			},

			/**
			 * Changes status handler.
			 * @protected
			 * @param {Object} event Event object.
			 * @param {Object} dom Event dom.
			 * @param {Object} options Event options.
			 * @param {Object} buttonTag Event tag.
			 */
			onChangeStatusButtonClick: function(event, dom, options, buttonTag) {
				this.changeStatus(buttonTag);
			},

			/**
			 * Changes status of the current activity.
			 * @protected
			 * @param {Object} status Status.
			 */
			changeStatus: function(status) {
				if (status !== "Done" && status !== "Cancel") {
					return;
				}
				var statusId = ConfigurationConstants.Activity.Status[status];
				var statusList = this.get("StatusList");
				this.set("Status", statusList.get(statusId));
				this.set("ShowEditableResults", true);
				this.set("IsQuickFinalStatusSubmitMode", true);
				this.Ext.get("ActivityMiniPageContainer").addCls("quick-final-status-submit-mode")
				this.onStatusChanged();
			},

			/**
			 * Set activity status info.
			 * @protected
			 */
			onStatusChanged: function() {
				var status = this.get("Status");
				var activityCaption = this.get("Resources.Strings.ActivityCaption");
				var activityStatus = (status && status.displayValue)
					? activityCaption + " " + status.displayValue.toLowerCase()
					: "";
				this.set("ActivityStatus", activityStatus);
			},

			/**
			 * Set activity result info.
			 * @protected
			 */
			onResultChanged: function() {
				var result = this.get("Result");
				var detailedResult = this.get("DetailedResult");
				var activityResult = (result && result.displayValue)
					? result.displayValue + ". " + detailedResult
					: detailedResult;
				this.set("ResultInfo", activityResult);
			},

			/**
			 * Event handler for property OwnerRole change
			 * @protected
			 */
			onOwnerRoleChange: function() {
				if (this.get("OwnerRole") != null) {
					this.set("Owner", null);
				}
			},

			/**
			 * Returns results container visibility.
			 * @protected
			 * @return {Boolean} Result and result details container visibility.
			 */
			isEditableResultsVisible: function() {
				if (this.get("IsEntityInitialized")) {
					this.adjustMiniPagePositionTimeoutId = this.adjustMiniPagePositionTimeoutId || setTimeout(() => {
						this.adjustMiniPagePositionTimeoutId = undefined;
						this.adjustMiniPagePosition();
					});
					var showEditResult = this.get("ShowEditableResults");
					return (showEditResult || (this.isNotViewMode() && this.isFinalStatus()));
				}
				return false;
			},

			/**
			 * Determines whether to show mini-page overlay.
			 * @protected
			 * @return {Boolean} Whether to show mini-page overlay.
			 */
			isMiniPageShowOverlay: function() {
				if (this.get("IsEntityInitialized")) {
					var isQuickFinalStatusSubmitMode = this.get("IsQuickFinalStatusSubmitMode");
					return (isQuickFinalStatusSubmitMode || this.isNotViewMode());
				}
			},

			/**
			 * Returns entity connections container visibility.
			 * @protected
			 * @return {Boolean} Entity connections container visibility.
			 */
			isEntityConnectionsVisible: function() {
				var isQuickFinalStatusSubmitMode = this.get("IsQuickFinalStatusSubmitMode");
				var entityConnectionsVisibility = this.get("EntityConnectionsVisibility");
				return ((!isQuickFinalStatusSubmitMode && entityConnectionsVisibility) || this.isNotViewMode());
			},

			/**
			 * Returns results container visibility.
			 * @protected
			 * @return {Boolean} Results container visibility.
			 */
			isViewResultsVisible: function() {
				var isQuickFinalStatusSubmitMode = this.get("IsQuickFinalStatusSubmitMode");
				return (this.isFinalStatus() && this.isViewMode() && !isQuickFinalStatusSubmitMode);
			},

			
			/**
			 * Returns activityStatus container visibility.
			 * @protected
			 * @return {Boolean} ActivityStatus container visibility.
			 */
			isStatusVisible: function() {
				var isQuickFinalStatusSubmitMode = this.get("IsQuickFinalStatusSubmitMode");
				var status = this.get("Status");
				return (status && this.isViewMode() && !isQuickFinalStatusSubmitMode);
			},

			/**
			 * Returns edit buttons visibility.
			 * @protected
			 * @return {Boolean} Edit buttons visibility.
			 */
			isEditButtonsVisible: function() {
				var isQuickFinalStatusSubmitMode = this.get("IsQuickFinalStatusSubmitMode");
				return (isQuickFinalStatusSubmitMode || this.isNotViewMode());
			},

			/**
			 * Returns true if activity in Cancel or Done statuses.
			 * @protected
			 * @return {Boolean} True if activity in Cancel or Done statuses.
			 */
			isFinalStatus: function() {
				var status = this.get("Status");
				return (status && status.Finish);
			},

			/**
			 * Returns true if activity result is required field.
			 * @protected
			 * @return {Boolean} True if result is required field.
			 */
			isRequiredResult: function() {
				var processEl = this.get("ProcessElementId");
				return !this.Ext.isEmpty(processEl) && this.hasAllowedResults();
			},

			/**
			 * Cancel activity and revert result changes.
			 * @protected
			 * @param {Function} callback Callback-function.
			 * @param {Object} scope Execution context.
			 */
			cancelEditActivity: function(callback, scope) {
				if (this.get("ActivityMiniPageStatus")) {
					this.close();
				} else {
					this.reInitActivityEntity(callback, scope);
				}
			},

			/**
			 * @inheritdoc BaseMiniPage#close
			 * @override
			 */
			close: function() {
				if (this.destroyed) {
					return;
				}
				this.sandbox.publish("ChangeDashboardTab", null);
				this.callParent(arguments);
			},

			/**
			 * Reload activity entity.
			 * @protected
			 * @param {Function} callback Callback-function.
			 * @param {Object} scope Execution context.
			 */
			reInitActivityEntity: function(callback, scope) {
				this.set("IsQuickFinalStatusSubmitMode", false);
				this.Ext.get("ActivityMiniPageContainer").removeCls("quick-final-status-submit-mode")
				var showEditableResults = this.get("ShowEditableResults");
				if (showEditableResults) {
					this.set("ShowEditableResults", false);
					this.initEntity(callback, scope);
				} else if (this.Ext.isFunction(callback)) {
					callback.call(scope || this);
				} else {
					this.close();
				}
			},

			/**
			 * @inheritdoc BaseMiniPage#hasCloseButton
			 * @override
			 */
			hasCloseButton: function() {
				return true;
			},

			/**
			 * @inheritdoc BaseMiniPage#switchMiniPageMode
			 * @override
			 */
			switchMiniPageMode: function() {
				this.set("ShowEditableResults", false);
				this.set("IsQuickFinalStatusSubmitMode", false);
				this.Ext.get("ActivityMiniPageContainer").removeCls("quick-final-status-submit-mode")
				this.callParent(arguments);
				this.mixins.MiniPageEntityConnectionsUtils.updateModeForEntityConnections.call(this);
			},

			/**
			 * @inheritdoc BaseMiniPage#save
			 * @override
			 */
			canSaveMiniPage: function() {
				return this.callParent(arguments) || this.get("ActivityMiniPageStatus");
			},

			/**
			 * @inheritdoc BaseMiniPage#save
			 * @override
			 */
			save: function(callback, scope) {
				if (this.get("ProcessResult")) {
					this.set("Result", this.get("ProcessResult"));
				}
				this.mixins.MiniPageEntityConnectionsUtils.updateEntityConnections.call(this);
				if (this.isEditMode() || this.Ext.isEmpty(this.get("Participants")) ||
					this.get("callParentOnSave")) {
					this.callParent(arguments);
				} else {
					this.set("ParentOnSaveArguments", {
						callback: callback,
						scope: scope
					});
					this.askAddedParticipants();
				}
			},

			/**
			 * @inheritdoc BaseMiniPage#onSaved
			 * @override
			 */
			onSaved: function() {
				this.insertParticipants();
				this.callParent(arguments);
			},

			/**
			 * Call activity save parent.
			 * @private
			 */
			callParentOnSave: function() {
				this.set("callParentOnSave", true);
				var saveParentParameters = this.get("ParentOnSaveArguments");
				if (saveParentParameters) {
					this.save(saveParentParameters.callback, saveParentParameters.scope);
				}
			},

			/**
			 * Asks about adding activity participants.
			 * @private
			 */
			askAddedParticipants: function() {
				this.showConfirmationDialog(this.get("Resources.Strings.InsertParticipantsMessage"),
					function(returnCode) {
						if (returnCode === this.BPMSoft.MessageBoxButtons.NO.returnCode) {
							this.set("Participants", null);
						}
						this.callParentOnSave();
					},
					[this.BPMSoft.MessageBoxButtons.YES.returnCode,
						this.BPMSoft.MessageBoxButtons.NO.returnCode],
					null);
			},

			/**
			 * Returns activity participant insert query.
			 * @param {Object} item Participant identifier.
			 * @private
			 * @return {BPMSoft.EntitySchemaQuery} Activity participant insert query
			 */
			getParticipantInsertQuery: function(item) {
				var roleId = ConfigurationConstants.Activity.ParticipantRole.Participant;
				var activityId = this.get("Id");
				var insert = Ext.create("BPMSoft.InsertQuery", {
					rootSchemaName: "ActivityParticipant"
				});
				insert.setParameterValue("Activity", activityId, this.BPMSoft.DataValueType.GUID);
				insert.setParameterValue("Participant", item, this.BPMSoft.DataValueType.GUID);
				insert.setParameterValue("Role", roleId, this.BPMSoft.DataValueType.GUID);
				return insert;
			},

			/*
			 * Execute queries to add activity participants.
			 * @private
			 */
			insertParticipants: function() {
				var participants = this.get("Participants");
				if (participants) {
					var bq = Ext.create("BPMSoft.BatchQuery");
					participants.forEach(function(item) {
						bq.add(this.getParticipantInsertQuery(item.value));
					}, this);
					if (bq.queries.length) {
						bq.execute();
					}
				}
			},

			/**
			 * Returns connections image url.
			 * @private
			 * @return {Object} Connections image url.
			 */
			getConnectionsImage: function() {
				return this.BPMSoft.ImageUrlBuilder.getUrl(this.get("Resources.Images.ConnectionsImage"));
			},

			/**
			 * Handles time zone click event.
			 * @private
			 */
			onShowTimezone: function() {
				if (this.isViewMode()) {
					this.switchMiniPageMode();
				}
				this.mixins.ActivityTimezoneMixin.onShowTimezone.call(this);
			},

			getTimeZoneLabelBtn: function() {
				return this.get("Resources.Strings.TimeZoneButtonLabel")
			},

			getMiniPageContainerPosition: function() {
				const container = document.getElementById('ActivitySectionV2Container')
				const isActiveGridView = document.getElementById("view-button-GridDataView-wrapperEl")?.classList.contains("t-btn-pressed")
				const element = this.get("AlignToEl")
				return (container && isActiveGridView) ? element : null
			},
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "AlignableMiniPageContainer",
				"values": {
					"showOverlay": {"bindTo": "isMiniPageShowOverlay"},
					"alignToEl": {"bindTo": "getMiniPageContainerPosition"},
					"useDeferredPositioning": BPMSoft.Features.getIsEnabled("AlignableContainerDeferPositioning"),
					"deferPositioningAllowed": "$CanRenderMiniPage"
				}
			},
			{
				"operation": "merge",
				"name": "SaveEditButton",
				"values": {
					"visible": {"bindTo": "isEditButtonsVisible"}
				}
			},
			{
				"operation": "merge",
				"name": "CancelEditButton",
				"values": {
					"visible": {"bindTo": "isEditButtonsVisible"},
					"click": {"bindTo": "cancelEditActivity"}
				}
			},
			{
				"operation": "merge",
				"name": "MiniPage",
				"values": {
					"classes": {
						"wrapClassName": ["activity-mini-page-container"]
					}
				}
			},
			{
				"operation": "merge",
				"name": "RequiredColumnsContainer",
				"values": {
					"classes": {
						"wrapClassName": ["required-columns-container", "grid-layout",
							"activity-mini-page-container"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "TitleInViewMode",
				"parentName": "HeaderContainer",
				"propertyName": "items",
				"values": {
					"labelConfig": {
						"visible": false
					},
					"bindTo": "Title",
					"wrapClass": ["activity-mini-page-title"],
					"visible": {"bindTo": "isViewMode"},
					"isMiniPageModelItem": true
				},
				"index": 1
			},
			{
				"operation": "insert",
				"name": "TitleInEditMode",
				"parentName": "HeaderContainer",
				"propertyName": "items",
				"values": {
					"labelConfig": {
						"visible": false
					},
					"bindTo": "Title",
					"contentType": this.BPMSoft.ContentType.LONG_TEXT,
					"controlConfig": {
						"placeholder": {
							"bindTo": "Resources.Strings.TitleControlPlaceholder"
						}
					},
					"classes": {
						"wrapClassName": ["activity-mini-page-title"]
					},
					"visible": {"bindTo": "isEditMode"},
					"isMiniPageModelItem": true
				},
				"index": 2
			},
			{
				"operation": "insert",
				"name": "TitleInAddMode",
				"parentName": "MiniPage",
				"propertyName": "items",
				"values": {
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.TitleControlLabel"
						}
					},
					"bindTo": "Title",
					"contentType": this.BPMSoft.ContentType.LONG_TEXT,
					"controlConfig": {
						"placeholder": {
							"bindTo": "Resources.Strings.TitleControlPlaceholder"
						},
						"focused": {
							"bindTo": "IsTitleFocused"
						}
					},
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 24
					},
					"classes": {
						"wrapClassName": ["activity-mini-page-title"]
					},
					"visible": {"bindTo": "isAddMode"}
				}
			},
			{
				"operation": "insert",
				"parentName": "MiniPage",
				"propertyName": "items",
				"name": "ActivityGeneralInfo",
				"values": {
					"generator": "MiniPageDatePeriodGenerator.generateDatePeriodControl",
					"dueDateColumn": "DueDate",
					"startDateColumn": "StartDate",
					"timeEditConfig": {
						"timeEdit": {
							"controlConfig": {
								"prepareList": {
									"bindTo": "loadDueDateList"
								}
							}
						}
					},
					"viewModeVisible": {"bindTo": "isViewMode"},
					"editModeVisible": {"bindTo": "isNotViewMode"},
					"caption": {"bindTo": "ActivityGeneralInfo"},
					"timeZoneButtonLabel": {
						"bindTo": "getTimeZoneLabelBtn"
					},
					"layout": {
						"column": 0,
						"row": 2,
						"colSpan": 24
					},
				}
			},
			{
				"operation": "insert",
				"parentName": "MiniPage",
				"propertyName": "items",
				"name": "Divider",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["activity-mini-page--divider-container"],
					"layout": {
						"colSpan": 24,
						"column": 0,
						"row": 3
					},
					"visible": {
						"bindTo": "isStatusVisible"
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "MiniPage",
				"propertyName": "items",
				"name": "ActivityStatus",
				"values": {
					"layout": {
						"colSpan": 24,
						"column": 0,
						"row": 4
					},
					"labelConfig": {
						"caption": {
							"bindTo": "Resources.Strings.ActivityStatusCaption"
						}
					},
					"value": {"bindTo": "ActivityStatus"},
					"wrapClass": ["activity-status-wrapper"],
					"classes": {
						"labelClass": ["activity-status-label-caption"]
					},
					"isMiniPageModelItem": true,
					"visible": {
						"bindTo": "isStatusVisible"
					}
				}
			},
			{
				"operation": "insert",
				"name": "ActivityCategory",
				"parentName": "MiniPage",
				"propertyName": "items",
				"values": {
					"contentType": this.BPMSoft.ContentType.ENUM,
					"controlConfig": {
						"placeholder": {
							"bindTo": "Resources.Strings.ActivityCategoryControlPlaceholder"
						}
					},
					"layout": {
						"column": 0,
						"row": 5,
						"colSpan": 24
					},
					"visible": {
						"bindTo": "isNotViewMode"
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "MiniPage",
				"propertyName": "items",
				"name": "Status",
				"values": {
					"dataValueType": this.BPMSoft.DataValueType.ENUM,
					"controlConfig": {
						"placeholder": {
							"bindTo": "Resources.Strings.StatusControlPlaceholder"
						}
					},
					"layout": {
						"column": 0,
						"row": 6,
						"colSpan": 24
					},
					"visible": {
						"bindTo": "isNotViewMode"
					}
				}
			},
			{
				"operation": "insert",
				"name": "ResultInfoContainer",
				"parentName": "MiniPage",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"layout": {
						"column": 0,
						"row": 14,
						"colSpan": 24
					},
					"visible": {
						"bindTo": "isViewResultsVisible"
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "ResultInfoContainer",
				"propertyName": "items",
				"name": "ResultInfo",
				"values": {
					"labelConfig": {
						"caption": {
							"bindTo": "Resources.Strings.ResultsCaption"
						}
					},
					"value": {"bindTo": "ResultInfo"},
					"classes": {
						"labelClass": ["activity-result"]
					},
					"isMiniPageModelItem": true
				}
			},
			{
				"operation": "insert",
				"name": "ResultsContainer",
				"parentName": "MiniPage",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"layout": {
						"column": 0,
						"row": 7,
						"colSpan": 24
					},
					"visible": {
						"bindTo": "isEditableResultsVisible"
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "ResultsContainer",
				"propertyName": "items",
				"name": "Result",
				"values": {
					"generator": "MiniPageEditControlsGenerator.generateModelItem",
					"visible": {
						"bindTo": "hasResults"
					},
					"contentType": this.BPMSoft.ContentType.ENUM,
					"wrapClass": ["container-mini-wrap", "activity-mini-page-result-container"],
					"controlConfig": {
						"placeholder": {
							"bindTo": "Resources.Strings.ResultControlPlaceholder"
						}
					},
					"controlWrapConfig": {
						"classes": {
							"wrapClassName": ["control-mini-wrap"]
						}
					},
					"classes": {
						"labelClass": ["activity-result-label-caption"]
					},
					"labelConfig": {
						"caption": {
							"bindTo": "Resources.Strings.ResultControlPlaceholder"
						}
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "ResultsContainer",
				"propertyName": "items",
				"name": "ProcessResult",
				"values": {
					"bindTo": "ProcessResult",
					"generator": "MiniPageEditControlsGenerator.generateModelItem",
					"visible": {
						"bindTo": "hasProcessResults"
					},
					"contentType": this.BPMSoft.ContentType.ENUM,
					"wrapClass": ["container-mini-wrap"],
					"controlConfig": {
						"prepareList": {"bindTo": "onPrepareProcessResultList"},
						"list": {"bindTo": "ProcessResultList"},
						"placeholder": {
							"bindTo": "Resources.Strings.ResultControlPlaceholder"
						}
					},
					"controlWrapConfig": {
						"classes": {
							"wrapClassName": ["control-mini-wrap"]
						}
					},
					"labelConfig": {
						"visible": false,
						"markerValue": ""
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "MiniPage",
				"propertyName": "items",
				"name": "DetailedResult",
				"values": {
					"generator": "MiniPageEditControlsGenerator.generateModelItem",
					"layout": {
						"column": 0,
						"row": 8,
						"colSpan": 24,
						"rowSpan": 3
					},
					"visible": {
						"bindTo": "isEditableResultsVisible"
					},
					"contentType": this.BPMSoft.ContentType.LONG_TEXT,
					"wrapClass": ["container-mini-wrap", "activity-mini-page-detailed-result-container"],
					"controlConfig": {
						"placeholder": {
							"bindTo": "Resources.Strings.DetailedResultControlPlaceholder"
						}
					},
					"controlWrapConfig": {
						"classes": {
							"wrapClassName": ["control-mini-wrap"]
						}
					},
					"labelConfig": {
						"caption": {
							"bindTo": "Resources.Strings.DetailedResultControlPlaceholder"
						}
					}
				}
			},
			{
				"operation": "insert",
				"name": "OwnerRole",
				"parentName": "MiniPage",
				"propertyName": "items",
				"values": {
					"contentType": this.BPMSoft.ContentType.ENUM,
					"layout": {
						"column": 0,
						"row": 10,
						"colSpan": 24
					},
					"controlConfig": {
						"placeholder": {
							"bindTo": "Resources.Strings.OwnerRoleControlPlaceholder"
						}
					},
					"visible": {
						"bindTo": "isUseProcessPerformerAssignment"
					}
				}
			},
			{
				"operation": "insert",
				"name": "Owner",
				"parentName": "MiniPage",
				"propertyName": "items",
				"values": {
					"contentType": this.BPMSoft.ContentType.ENUM,
					"layout": {
						"column": 0,
						"row": 11,
						"colSpan": 24
					},
					"controlConfig": {
						"placeholder": {
							"bindTo": "Resources.Strings.OwnerControlPlaceholder"
						}
					},
					"visible": {
						"bindTo": "isNotViewMode"
					}
				}
			},
			{
				"operation": "insert",
				"name": "CommunicationsContainer",
				"parentName": "MiniPage",
				"propertyName": "items",
				"values": {
					"wrapClass": ["communications-container"],
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"layout": {
						"column": 0,
						"row": 12,
						"colSpan": 24
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "CommunicationsContainer",
				"propertyName": "items",
				"name": "AddCommunicationImage",
				"values": {
					"getSrcMethod": "getConnectionsImage",
					"readonly": true,
					"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
					"classes": {
						"wrapClass": ["communications-image"]
					},
					"visible": {"bindTo": "isEntityConnectionsVisible"}
				}
			},
			{
				"operation": "insert",
				"name": "AddCommunicationButton",
				"parentName": "CommunicationsContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"imageConfig": {
						"bindTo": "Resources.Images.AddConnectionIcon"
					},
					"classes": {
						wrapperClass: ["communications-add-button"]
					},
					"menu": {
						"classes": {"wrapClassName": ["entity-connection-menu-item"]},
						"items": {
							"bindTo": "EntityConnectionMenuItems"
						}
					},
					"visible": {"bindTo": "isNotViewMode"}
				}
			},
			{
				"operation": "insert",
				"name": "AddCommunicationLabel",
				"parentName": "CommunicationsContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"classes": {"labelClass": ["communications-label"]},
					"caption": {"bindTo": "Resources.Strings.ConnectionsCaption"},
					"visible": {"bindTo": "isEntityConnectionsVisible"}
				}
			},
			{
				"operation": "insert",
				"name": "Communications",
				"parentName": "CommunicationsContainer",
				"propertyName": "items",
				"values": {
					"classes": {"wrapClassName": ["entity-connection-container"]},
					"generator": "ConfigurationItemGenerator.generateContainerList",
					"idProperty": "Id",
					"collection": "EntityConnectionsList",
					"observableRowNumber": 10,
					"onGetItemConfig": "getEntityConnectionViewConfig",
					"visible": {"bindTo": "isEntityConnectionsVisible"}
				}
			},
			{
				"operation": "insert",
				"name": "StatusButtonContainer",
				"parentName": "MiniPage",
				"propertyName": "items",
				"values": {
					"visible": {"bindTo": "canChangeStatus"},
					"wrapClass": ["activity-minipage-status-container"],
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"layout": {
						"column": 0,
						"row": 13,
						"colSpan": 24
					}
				}
			},
			{
				"operation": "insert",
				"name": "CompleteButton",
				"parentName": "StatusButtonContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.BUTTON,
					"style": this.BPMSoft.controls.ButtonEnums.style.ORANGE,
					"caption": {"bindTo": "Resources.Strings.CompleteButtonCaption"},
					// "imageConfig": {
					// 	"bindTo": "Resources.Images.CompleteResultButtonImage"
					// },
					"classes": {
						"textClass": ["activity-minipage-btn-complete"],
						"wrapperClass": ["activity-minipage-status-btn-wrapper"],
						"imageClass": ["base-minipage-action-button-image"]
					},
					"click": {"bindTo": "onChangeStatusButtonClick"},
					"visible": {"bindTo": "canChangeStatus"},
					"tag": "Done"
				}
			},
			{
				"operation": "insert",
				"name": "CancelButton",
				"parentName": "StatusButtonContainer",
				"propertyName": "items",
				"values": {
					// "imageConfig": {
					// 	"bindTo": "Resources.Images.CancelResultButtonImage"
					// },
					"itemType": this.BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.CancelButtonCaption"},
					"classes": {
						"textClass": ["activity-minipage-btn-cancel"],
						"wrapperClass": ["activity-minipage-status-btn-wrapper"],
						"imageClass": ["base-minipage-action-button-image"]
					},
					"click": {"bindTo": "onChangeStatusButtonClick"},
					"visible": {"bindTo": "canChangeStatus"},
					"tag": "Cancel"
				}
			}
		]/**SCHEMA_DIFF*/,
		rules: {
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
