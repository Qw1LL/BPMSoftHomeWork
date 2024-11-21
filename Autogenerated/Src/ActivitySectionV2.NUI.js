define("ActivitySectionV2", ["BaseFiltersGenerateModule", "ConfigurationConstants", "ConfigurationEnums",
			"ProcessModuleUtilities", "GoogleIntegrationUtilitiesV2",
			"ActivitySectionGridRowViewModel", "css!ActivitySectionCSS"],
	function(BaseFiltersGenerateModule, ConfigurationConstants, ConfigurationEnums,
			ProcessModuleUtilities) {
		return {
			/**
			 *
			 */
			entitySchemaName: "Activity",
			mixins: {
				GoogleIntegrationUtils: "BPMSoft.GoogleIntegrationUtilities"
			},
			attributes: {
				/**
				 * ######### ####### #### ########## ####### ##########.
				 */
				IntervalMenuItems: {dataValueType: this.BPMSoft.DataValueType.COLLECTION},

				/**
				 * ######### ######### ##########.
				 */
				ScheduleGridData: {dataValueType: this.BPMSoft.DataValueType.COLLECTION},

				/**
				 * ######## ############# "##########".
				 */
				"SchedulerDataViewName": {
					dataValueType: this.BPMSoft.DataValueType.TEXT,
					value: "SchedulerDataView"
				},

				/**
				 * ######, ########## ######## ######### # ######## #### ######### #######.
				 */
				SchedulerSelection: {
					dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT,
					value: null
				},

				/**
				 * ######### ####### ########### #### ##########.
				 */
				SchedulerFloatItemsCollection: {dataValueType: this.BPMSoft.DataValueType.COLLECTION},

				/**
				 * ######## ############# #######.
				 */
				GetSchedulerSelectionPressedKeys: {
					dataValue: this.BPMSoft.DataValueType.TEXT,
					value: ""
				},

				/**
				 * ########## ########### ####### # ##########.
				 */
				"SchedulePageCount": {
					dataValueType: this.BPMSoft.DataValueType.INTEGER,
					value: 0
				},

				/**
				 * ########## ####### ## ######## # ##########. ############ ######### ##########.
				 */
				"SchedulerItemsAmountPerPage": {
					dataValueType: this.BPMSoft.DataValueType.INTEGER
				},
				"canUseSyncFeaturesByBuildType": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					value: false
				}
			},
			messages: {
				/**
				 * @message GetIsVisibleEmailPageButtons
				 * ########## ######### ###### ######## ######## Email.
				 * @param {Object} ######## ########, ####### ######## ## ######### ######.
				 */
				"GetIsVisibleEmailPageButtons": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				"OpenItem": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message ProcessExecDataChanged
				 * ########## ### ##### ######## ###### ########## ########.
				 * @param {Object}
				 * procElUId: ############# ######## ########,
				 * recordId: ############# ######,
				 * scope: ########,
				 * parentMethodArguments: ######## ### ############# ######,
				 * parentMethod: ############ #####.
				 */
				"ProcessExecDataChanged": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message GetFixedFilter
				 * ######## ######## FixedFilter.
				 * @param {String} ######## #######.
				 * @return {Object} ######.
				 */
				"GetFixedFilter": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message GetSimpleTaskAddViewModel
				 * ########### ############ ###### #### ######## ########## ######.
				 */
				"GetSimpleTaskAddViewModel": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message SimpleTaskViewModelCreated
				 * ######## ############## ###### #### ######## ########## ######.
				 */
				"SimpleTaskViewModelCreated": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message RenderSimpleTaskAddView
				 * ########## ######### #### ######## ########## ######.
				 * @param {Object}
				 * renderTo: ############# ########## ### #########,
				 * viewModel: ###### #### ######## ########## ######.
				 */
				"RenderSimpleTaskAddView": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message RemoveViewModel
				 * ####### ######### ## ######## ###### #### ######## ########## ###### ## ######### ##########.
				 */
				"RemoveViewModel": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message GetEnteredKeys
				 * ########## ######### ############# ####### ### ####### ########## ###### ##### #########.
				 * @return {String} ###### ######### ########.
				 */
				"GetSchedulerSelectionPressedKeys": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				/**
				 * @message ReloadGridAfterAdd
				 * ######### ###### ### ########### ######.
				 */
				"ReloadGridAfterAdd": {
					mode: this.BPMSoft.MessageMode.BROADCAST,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},
			methods: {
				/**
				 * Initialize defaults values of the section.
				 * @overridden
				 */
				init: function(callback, scope) {
					this.set("SelectedRows", []);
					this.initFiltersUpdateDelay();
					this.registerGetIsVisibleEmailPageButtonsHandler();
					this.initScheduleGridData();
					this.initSchedulerFloatItemsCollection();
					this.initSchedulerTimeScaleLookupValue();
					this.initMailBoxSyncSettings();
					this.initFixedFiltersConfig();
					this.initIntervalMenuItems();
					this.initRowCount();
					var parentInitFn = this.getParentMethod(this, [function() {
						this._updateSchedulerDates();
						Ext.callback(callback, scope);
					}, this]);
					this.initSchedulerItemsAmountPerPage(parentInitFn);
					var sysSettings = ["BuildType"];
					BPMSoft.SysSettings.querySysSettings(sysSettings, function() {
						var cachedSettings = BPMSoft.SysSettings.cachedSettings;
						var buildType = cachedSettings.BuildType && cachedSettings.BuildType.value;
						var isNotPublic = buildType !== ConfigurationConstants.BuildType.Public;
						this.set("canUseSyncFeaturesByBuildType", isNotPublic);
					}, this);
					this.mixins.GoogleIntegrationUtils.init.call(this);
					this.initGoogleCalendarLog();
					this.subscribeServerChannelEvents();
				},

				/**
				 * Initializes the value of the number of records on the page in the schedule.
				 */
				initSchedulerItemsAmountPerPage: function(callback) {
					this.BPMSoft.SysSettings.querySysSettingsItem("SchedulerItemsAmountPerPage", function(value) {
						var rowCount = this.get("RowCount");
						var schedulerItemsAmountPerPage = value || rowCount || 0;
						this.set("SchedulerItemsAmountPerPage", schedulerItemsAmountPerPage);
						Ext.callback(callback);
					}, this);
				},

				/**
				 * ############## ######### ###### ############# ########.
				 * @protected
				 */
				initScheduleGridData: function() {
					this.set("ScheduleGridData", this.Ext.create("BPMSoft.BaseViewModelCollection"));
				},

				/**
				 * ############## ######### ###### ############# ########.
				 * @protected
				 */
				initSchedulerFloatItemsCollection: function() {
					this.set("SchedulerFloatItemsCollection", this.Ext.create("BPMSoft.BaseViewModelCollection"));
				},

				/**
				 * ############## ######## ########## ######### # ##########.
				 * @protected
				 */
				initSchedulerTimeScaleLookupValue: function() {
					var profile = this.get("Profile");
					this.set("SchedulerTimeScaleLookupValue", {
						value: (profile && profile.schedulerTimeScaleLookupValue) ||
						this.BPMSoft.TimeScale.THIRTY_MINUTES
					});
				},

				/**
				 * ######## ######### #######.
				 * @override
				 * @protected
				 * @return {Collection}
				 */
				getGridData: function() {
					if (this.isNotSchedulerDataView()) {
						return this.get("GridData");
					} else {
						return this.get("ScheduleGridData");
					}
				},

				/**
				 * ############# ############# ########### #######.
				 * @protected
				 */
				initContextHelp: function() {
					this.set("ContextHelpId", 1010);
					this.callParent(arguments);
				},

				/**
				 * ########## #######, ####### ###### ########## ########.
				 * @protected
				 * @overridden
				 * @return {Object} ########## ###### ########-############ #######.
				 */
				getGridDataColumns: function() {
					var baseGridDataColumns = this.callParent(arguments);
					var gridDataColumns = {
						"Account": {path: "Account"},
						"StartDate": {path: "StartDate"},
						"DueDate": {path: "DueDate"},
						"ShowInScheduler": {path: "ShowInScheduler"},
						"Status": {path: "Status"},
						"Status.Finish": {path: "Status.Finish"},
						"ProcessElementId": {
							path: "ProcessElementId",
							dataValueType: 0
						}
					};
					return Ext.apply(baseGridDataColumns, gridDataColumns);
				},

				/**
				 * ########## ######## ######### ### ######## ############# #####.
				 * @overridden
				 * @return {boolean} ######### ###### ####.
				 */
				isMultiSelectVisible: function() {
					return (!this.get("MultiSelect") && this.isNotSchedulerDataView());
				},

				/**
				 * ########## ######## ######### ### ######## ######## ############# #####.
				 * @return {boolean} ######### ###### ####.
				 */
				isSingleSelectVisible: function() {
					return this.get("MultiSelect") && this.isNotSchedulerDataView();
				},

				/**
				 * ########## ######## ######### ### ######## ##### ### #########.
				 * @return {boolean} ######### ###### ####.
				 */
				isUnSelectVisible: function() {
					return this.isAnySelected() && this.isNotSchedulerDataView();
				},

				/**
				 * ############# ######## ######### ### ######## ######### # ######.
				 */
				setAddFolderActionVisible: function() {
					this.set("IsIncludeInFolderButtonVisible", this.isNotSchedulerDataView());
				},

				/**
				 * #########, ###### ## ###### ######### ## ###### # #### ###### ########.
				 * @protected
				 * @return {Boolean} ######### ########.
				 */
				isExcludeFromFolderButtonVisible: function() {
					var currentFolder = this.get("CurrentFolder");
					var visible = currentFolder ?
						(currentFolder.folderType.value === ConfigurationConstants.Folder.Type.General) :
						false;
					return visible && this.isNotSchedulerDataView();
				},

				/**
				 * Synchronizes with Google calendar and activities.
				 * @protected
				 */
				synchronizeNow: function() {
					if (this.get("canUseSyncFeaturesByBuildType")) {
						this.synchronizeWithGoogleCalendar();
					} else {
						if (!this.get("IsExchangeSyncExist")) {
							this.showConfirmationDialog(this.get("Resources.Strings.SettingsNotSet"), function(result) {
								if (result === BPMSoft.MessageBoxButtons.YES.returnCode) {
									this.showSyncDialog();
								}
							}, ["yes", "no"]);
						}
					}
				},

				/**
				 * ######### ####### ######## ############# # ######### #######
				 * # ############# ############### ######## ######.
				 * @protected
				 */
				initMailBoxSyncSettings: function() {
					this.set("isMailboxSyncExist", false);
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "MailboxSyncSettings"
					});
					esq.addColumn("Id");
					var filter = this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
						"SysAdminUnit", this.BPMSoft.SysValue.CURRENT_USER.value);
					esq.filters.addItem(filter);
					esq.getEntityCollection(function(response) {
						if (response.success) {
							this.set("isMailboxSyncExist", (response.collection.getCount() > 0));
						}
					}, this);
				},

				/**
				 * ###### ######## ######### #############. ########## ### ########.
				 * ### ######### ############# ##########.
				 * @protected
				 * @overridden
				 */
				setActiveView: function() {
					this.set("IsGridEmpty", false);
					this.callParent(arguments);
					this.setAddFolderActionVisible();
					if (this.isSchedulerDataView()) {
						this.showBodyMask();
					}
				},

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#loadGridDataView
				 * @overridden
				 */
				loadGridDataView: function(loadData) {
					var refreshData = loadData;
					loadData = false;
					this.callParent(arguments);
					if (refreshData === true) {
						this.refreshGridData();
					}
				},

				/**
				 * ############## ############# #######.
				 * @protected
				 */
				initFixedFiltersConfig: function() {
					var fixedFilterConfig = {
						entitySchema: this.entitySchema,
						filters: [
							{
								name: "PeriodFilter",
								caption: this.get("Resources.Strings.PeriodFilterCaption"),
								dataValueType: this.BPMSoft.DataValueType.DATE,
								startDate: {
									columnName: "StartDate",
									defValue: this.BPMSoft.startOfWeek(new Date())
								},
								dueDate: {
									columnName: "DueDate",
									defValue: this.BPMSoft.endOfWeek(new Date())
								}
							},
							{
								name: "Owner",
								caption: this.get("Resources.Strings.OwnerFilterCaption"),
								addOwnerCaption: this.get("Resources.Strings.AddEmployeeFilterCaption"),
								hint: this.get("Resources.Strings.SelectEmployeeFilterHint"),
								columnName: "Owner",
								defValue: this.BPMSoft.SysValue.CURRENT_USER_CONTACT,
								dataValueType: this.BPMSoft.DataValueType.LOOKUP,
								filter: BaseFiltersGenerateModule.OwnerFilter,
								appendFilter: function(filterInfo) {
									var confirmedFilter;
									if (filterInfo.value && filterInfo.value.length > 0) {
										var inviteResponse = ConfigurationConstants.Activity.ParticipantInviteResponse;
										confirmedFilter = new BPMSoft.createFilterGroup();
										confirmedFilter.add("InviteResponseFilter", BPMSoft.createColumnFilterWithParameter(
												BPMSoft.ComparisonType.NOT_EQUAL,
												"[ActivityParticipant:Activity].InviteResponse",
												inviteResponse.Declined,
												BPMSoft.DataValueType.GUID));
										confirmedFilter.add("ActivityParticipantFilter", BPMSoft.createColumnInFilterWithParameters(
												"[ActivityParticipant:Activity].Participant",
												filterInfo.value));
									}
									return confirmedFilter;
								}
							}
						]
					};
					this.set("FixedFilterConfig", fixedFilterConfig);
				},

				/**
				 * ############ ###########.
				 * @protected
				 */
				registerGetIsVisibleEmailPageButtonsHandler: function() {
					this.sandbox.subscribe("GetIsVisibleEmailPageButtons", function(config) {
						this.set(config.key, config.value);
					}, this);
				},

				/**
				 * ######## ############# ## #########.
				 * @protected
				 * @return {Object}
				 */
				getDefaultDataViews: function() {
					var baseDataViews = this.callParent();
					baseDataViews.SchedulerDataView = {
						index: 0,
						name: "SchedulerDataView",
						caption: this.get("Resources.Strings.SchedulerHeader"),
						hint: this.get("Resources.Strings.CalendarDataViewHint"),
						icon: this.get("Resources.Images.SchedulerDataViewIcon")
					};
					baseDataViews.GridDataView.index = 1;
					baseDataViews.AnalyticsDataView.index = 2;
					return baseDataViews;
				},

				/**
				 * Handler of the update filters in section.
				 * @overridden
				 */
				onFilterUpdate: function() {
					this.callParent(arguments);
					this._updateSchedulerDates();
				},

				/**
				 * Updates scheduler start and due dates.
				 * @private
				 */
				_updateSchedulerDates: function() {
					if (this.isSchedulerDataView()) {
						this.set("SchedulePageCount", 0);
					}
					var periodFilter = this._getPeriodFilterFromFixedFilter() || this._getProfilePeriodFilter();
					this.set("SchedulerStartDate", periodFilter.startDate);
					this.set("SchedulerDueDate", periodFilter.dueDate);
				},

				/**
				 * Gets period filter of the profile.
				 * @private
				 * @return {Object} {startDate: Date, dueDate: Date} Period filter of the profile or new date.
				 */
				_getProfilePeriodFilter: function() {
					var profileFilters = BPMSoft.deepClone(this.getProfileFilters());
					var fixedFilters = profileFilters && profileFilters.FixedFilters;
					var fixedFilter = fixedFilters && fixedFilters.Fixed;
					var periodFilter = fixedFilter && fixedFilter.PeriodFilter || {};
					if (!periodFilter.startDate || !periodFilter.dueDate) {
						periodFilter.startDate = new Date();
						periodFilter.dueDate = new Date();
					}
					var startDate = new Date(periodFilter.startDate);
					var dueDate = new Date(periodFilter.dueDate);
					return {
						startDate: startDate,
						dueDate: dueDate
					};
				},

				/**
				 * Gets period filter from the fixed filter.
				 * @private
				 * @return {Object|null} {startDate: Date, dueDate: Date} Period filter of the profile or new date.
				 */
				_getPeriodFilterFromFixedFilter: function() {
					var quickFilterModuleId = this.getQuickFilterModuleId();
					var filters = this.sandbox.publish("GetFixedFilter", {filterName: "PeriodFilter"},
						[quickFilterModuleId]);
					return BPMSoft.isEmptyObject(filters) ? null : filters;
				},

				/**
				 * Load scheduler data view.
				 * @protected
				 * @param {Boolean} loadData Data loading flag.
				 */
				loadSchedulerDataView: function(loadData) {
					this.initSchedulerTimeScaleLookupValue();
					this.set("IsActionButtonsContainerVisible", true);
					this.set("IsAnalyticsActionButtonsContainerVisible", false);
					this.set("IsClearGridData", true);
					this.set("ActiveRow", null);
					this.set("SelectedRows", []);
					this.set("SchedulePageCount", 0);
					if (loadData === false) {
						return;
					}
					this.loadGridData();
				},

				/**
				 * Returns section filters list.
				 * @protected
				 * @overridden
				 */
				getFilters: function() {
					var filters = this.callParent(arguments);
					var fixedFilters = filters.contains("FixedFilters")	? filters.get("FixedFilters") : null;
					if (!this.Ext.isEmpty(fixedFilters) && fixedFilters.contains("Owner")) {
						var ownerFilters = fixedFilters.get("Owner");
						if (ownerFilters.contains("OwnerDefaultFilter")) {
							ownerFilters.removeByKey("OwnerDefaultFilter");
						}
					}
					if (this.isSchedulerDataView()) {
						if (!filters.contains("ShowInSchedulerFilter")) {
							filters.add("ShowInSchedulerFilter", this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL, "ShowInScheduler", true));
						}
						if (!fixedFilters) {
							fixedFilters = this.BPMSoft.createFilterGroup();
							fixedFilters.logicalOperation = BPMSoft.LogicalOperatorType.AND;
							filters.add("FixedFilters", fixedFilters);
						}
						var hasPeriodFilters = fixedFilters.contains("PeriodFilter");
						var periodFilter = hasPeriodFilters ? fixedFilters.get("PeriodFilter") : null;
						if (!hasPeriodFilters || (periodFilter && !(periodFilter instanceof BPMSoft.Collection))) {
							this.setDateFiltersCurrentDate(fixedFilters);
						}
					}
					if (this.isNotSchedulerDataView() &&
						filters.contains("ShowInSchedulerFilter")) {
						filters.removeByKey("ShowInSchedulerFilter");
					}

					filters.add("NotEmailFilter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.NOT_EQUAL, "Type", ConfigurationConstants.Activity.Type.Email
					));

					return filters;
				},

				/**
				 * ############# ############ ####### ## ####### ### ########## ## ####### ####.
				 * @private
				 * @param {Object} fixedFilters ###### ############ ########.
				 */
				setDateFiltersCurrentDate: function(fixedFilters) {
					var now = new Date();
					var periodFilter = this.BPMSoft.createFilterGroup();
					periodFilter.logicalOperation = BPMSoft.LogicalOperatorType.AND;
					periodFilter.add("DueDate", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.GREATER_OR_EQUAL, "DueDate",
						this.BPMSoft.startOfDay(now)));
					periodFilter.add("StartDate", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.LESS_OR_EQUAL, "StartDate",
						this.BPMSoft.endOfDay(now)));
					if (fixedFilters.contains("PeriodFilter")) {
						fixedFilters.removeByKey("PeriodFilter");
					}
					fixedFilters.add("PeriodFilter", periodFilter);
				},

				/**
				 * ############## ######### ######### ### ###### # ########### ######### ##########.
				 * @protected
				 */
				initIntervalMenuItems: function() {
					this.set("IntervalMenuItems", this.Ext.create("BPMSoft.BaseViewModelCollection"));
					var intervalMenuItems = this.get("IntervalMenuItems");
					var timeScaleFormat = this.get("Resources.Strings.IntervalFormat");
					var intervals = this.getSchedulerIntervals();
					this.BPMSoft.each(intervals, function(interval) {
						intervalMenuItems.addItem(this.getButtonMenuItem({
							"Caption": this.Ext.String.format(timeScaleFormat, interval),
							"Click": {bindTo: "changeInterval"},
							"Tag": interval
						}));
					}, this);
				},

				/**
				 * Returns intervals for scheduler.
				 * @protected
				 * @virtual
				 */
				getSchedulerIntervals: function() {
					var intervals = [];
					this.BPMSoft.each(this.BPMSoft.TimeScale, function(value) {
						intervals.push(value);
					});
					var excludedIntervals = this.getExcludedIntervals();
					intervals = this.BPMSoft.difference(intervals, excludedIntervals);
					return intervals;
				},

				/**
				 * Returns excluded intervals.
				 * @protected
				 * @virtual
				 * @return {Array} Excluded intervals.
				 */
				getExcludedIntervals: function() {
					return [this.BPMSoft.TimeScale.ONE_MINUTE];
				},

				/**
				 * ######## ######## ##### ####### ######## ########## ##########.
				 * @protected
				 * @param {BPMSoft.TimeScale} value ######## ##### #######.
				 */
				changeInterval: function(value) {
					var profile = this.get("Profile");
					if (profile) {
						profile.schedulerTimeScaleLookupValue = value;
						this.BPMSoft.utils.saveUserProfile(this.getProfileKey(), profile, false);
					}
					this.set("SchedulerTimeScaleLookupValue", {value: value});
				},

				/**
				 * ######## ######## ##### ####### ######## ########## ##########.
				 * @protected
				 * @return {Object} ####### ######## ##### #######.
				 */
				getTimeScale: function() {
					var schedulerTimeScaleLookupValue = this.get("SchedulerTimeScaleLookupValue");
					return (schedulerTimeScaleLookupValue && schedulerTimeScaleLookupValue.value);
				},

				/**
				 * ######## ###### ######## ########## ##########.
				 * @protected
				 * @return {Object} ######## ########## ##########.
				 */
				getSchedulerPeriod: function() {
					var startDate = this.get("SchedulerStartDate") || new Date();
					var dueDate = this.get("SchedulerDueDate") || new Date();
					var clearDueDate = this.Ext.Date.clearTime(dueDate);
					var clearStartDate = this.Ext.Date.clearTime(startDate);
					var selectedPeriod = clearDueDate - clearStartDate;
					if (selectedPeriod < 0) {
						startDate = dueDate;
					}
					return {
						startDate: startDate,
						dueDate: dueDate
					};
				},

				/**
				 * ############ ####### ######### ######## ##########.
				 * @protected
				 */
				changeScheduleItem: BPMSoft.emptyFn,

				/**
				 * ######## #######, ######## ## ###### ##########.
				 * @protected
				 * @return {Boolean} ########## ###### ##########.
				 */
				getSchedulerButtonsEnabled: function() {
					var selectedValues = this.get("SelectedRows");
					return selectedValues && (selectedValues.length > 0);
				},

				/**
				 * ######### ######.
				 * @protected
				 */
				refreshGridData: function() {
					var gridData = this.getGridData();
					if (gridData) {
						gridData.clear();
						this.loadGridData();
					}
				},

				/**
				 * Execute synchronization with Google Calendars.
				 * @protected
				 */
				synchronizeWithGoogleCalendar: function() {
					this.showBodyMask();
					if (!this.get("GoogleSyncExists") && !this.get("IsExchangeSyncExist")) {
						this.showConfirmationDialog(this.get("Resources.Strings.SettingsNotSet"),
							function(result) {
								if (result === BPMSoft.MessageBoxButtons.YES.returnCode) {
									this.showSyncDialog();
								}
							}, ["yes", "no"]);
						this.hideBodyMask();
						return;
					}
					if (!this.get("GoogleSyncExists") && this.get("IsExchangeSyncExist")) {
						this.hideBodyMask();
						return;
					}
					this.startGoogleSynchronization();
				},

				/**
				 * ######### email #########.
				 * @obsolete
				 * @protected
				 */
				loadImapEmails: function() {
					window.console.warn(this.Ext.String.format(
						this.BPMSoft.Resources.ObsoleteMessages.ObsoleteMethodMessage,
						"loadImapEmails", "loadEmails"));
					this.loadEmails();
				},

				/**
				 * ######### email #########.
				 * @protected
				 */
				loadEmails: function() {
					if (!this.get("isMailboxSyncExist")) {
						var buttonsConfig = {
							buttons: [this.BPMSoft.MessageBoxButtons.OK.returnCode],
							defaultButton: 0
						};
						this.BPMSoft.showInformation(this.get("Resources.Strings.MailboxSettingsEmpty"),
							this.BPMSoft.emptyFn, this, buttonsConfig);
						return;
					}
					var select = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "ActivityFolder"
					});
					select.addColumn("Id");
					select.filters.addItem(select.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
						"[MailboxSyncSettings:MailboxName:Name].SysAdminUnit", this.BPMSoft.SysValue.CURRENT_USER.value));
					select.getEntityCollection(function(response) {
						if (response.success) {
							this.BPMSoft.each(response.collection.getItems(), function(item) {
								var requestUrl = this.BPMSoft.workspaceBaseUrl +
									"/ServiceModel/ProcessEngineService.svc/LoadImapEmailsProcess/" +
									"Execute?ResultParameterName=LoadResult" +
									"&MailBoxFolderId=" + item.get("Id");
								this.showBodyMask();
								this.Ext.Ajax.request({
									url: requestUrl,
									headers: {
										"Content-Type": "application/json",
										"Accept": "application/json"
									},
									method: "POST",
									scope: this,
									callback: function(request, success, response) {
										this.hideBodyMask();
										var responseData;
										if (success) {
											var responseValue = response.responseXML.firstChild.textContent;
											responseData = this.Ext.decode(this.Ext.decode(responseValue));
											this.refreshGridData();
											this.BPMSoft.utils.showInformation(
												this.get("Resources.Strings.LoadImapEmailsResult"), null, null,
												{buttons: ["ok"]});
										}
										if (responseData && responseData.Messages.length > 0) {
											this.BPMSoft.each(responseData.Messages, function(element) {
												this.BPMSoft.utils.showInformation(element.message, null, null,
													{buttons: ["ok"]});
											}, this);
										}
									}
								});
							}, this);
						}
					}, this);
				},

				/**
				 * Opens page for editing entity of the activity.
				 * @protected
				 */
				openItem: function() {
					var gridData = this.getGridData();
					var selectedRows = this.get("SelectedRows");
					var activeRow = gridData.get(selectedRows);
					var typeColumnValue = this.getTypeColumnValue(activeRow);
					var schemaName = this.getEditPageSchemaName(typeColumnValue);
					this.openCard(schemaName, "edit", selectedRows);
				},

				/**
				 * ############# ######### ######## # ############ ############# # ########### ## ######.
				 */
				setFiltersVisibleInCombinedMode: function(planning = false) {
					var schema = this.Ext.get(this.name + "Container");
					if (schema) {
						if (this.isSchedulerDataView() && planning) {
							this.setGridOffsetClass();
							if (!schema.hasCls("filters-hidden")) {
								schema.addCls("filters-hidden");
							}
						} else {
							schema.removeCls("filters-hidden");
							this.setGridOffsetClass(this.get("GridOffsetLinesCount"));
						}
					}
				},

				/*
				 * ######### ########### ####### ######## ####### NotEmailFilter.
				 * @inheritdoc BPMSoft.BaseSectionV2#getVerticalGridOffset
				 * @overridden
				 */
				getVerticalGridOffset: function(filters) {
					var linesCount = this.callParent(arguments);
					var notEmailFilter = filters.collection.findBy(
						function(item, key) {
							return (key === "NotEmailFilter");
						});
					if (notEmailFilter) {
						linesCount--;
					}
					return linesCount;
				},

				/**
				 * ######### ############# ######### ###### ########## #######.
				 * @overridden
				 * @param {Integer|*} linesCount ########## #####.
				 * @return {boolean} ############# ######### ####### ########## #######.
				 */
				needToSetOffset: function(linesCount) {
					return (linesCount != null && !this.isSchedulerDataView());
				},

				/**
				 * ######## ########## ######.
				 * @protected
				 */
				copyItem: function() {
					var selectedItem = this.get("SelectedRows");
					var gridData = this.getGridData();
					var activeRow = gridData.get(selectedItem);
					var primaryColumnValue = activeRow.get(activeRow.primaryColumnName);
					this.copyRecord(primaryColumnValue);
				},

				/**
				 * ####### ##########.
				 * @protected
				 */
				deleteItem: function() {
					this.deleteRecords();
				},

				/**
				 * ########## ######### ###### # ##########.
				 * @protected
				 * @overridden
				 * @return {Array|null} ###### #######.
				 */
				getSelectedItems: function() {
					if (this.isSchedulerDataView()) {
						return this.get("SelectedRows");
					} else {
						return this.callParent(arguments);
					}
				},

				/**
				 * ######## #### ######## ########## ###### ##### ######## ######.
				 * @overridden
				 * @param {object} response ##### ## #######.
				 */
				onDeleted: function(response) {
					this.callParent(arguments);
					if (response.Success) {
						var schedulerFloatItemsCollection = this.get("SchedulerFloatItemsCollection");
						if (schedulerFloatItemsCollection) {
							schedulerFloatItemsCollection.clear();
						}
					}
				},

				/**
				 * Opens page for editing entity of the activity.
				 * @overridden
				 */
				openCard: function() {
					this.setFiltersVisibleInCombinedMode();
					var gridData = this.getGridData();
					var activeRow = this.get("ActiveRow");
					var prcElId = BPMSoft.GUID_EMPTY;
					var recordId = BPMSoft.GUID_EMPTY;
					if (activeRow && gridData && gridData.contains(activeRow)) {
						var activeRecord = gridData.get(activeRow);
						if (activeRecord) {
							prcElId = activeRecord.get("ProcessElementId");
							recordId = activeRecord.get(this.primaryColumnName);
						}
					}
					var config = {
						procElUId: prcElId,
						recordId: recordId,
						scope: this,
						parentMethodArguments: arguments,
						parentMethod: this.getParentMethod()
					};
					if (ProcessModuleUtilities.tryShowProcessCard.call(this, config)) {
						return;
					}
					this.callParent(arguments);
				},

				/**
				 * Opens activity card in chain.
				 * @overridden
				 */
				openCardInChain: function(config) {
					if (this.isSchedulerDataView() && (config.operation === ConfigurationEnums.CardStateV2.ADD)) {
						var historyStateInfo = this.getHistoryStateInfo();
						if (historyStateInfo.workAreaMode === ConfigurationEnums.WorkAreaMode.COMBINED) {
							this.closeCard();
						}
					}
					return this.callParent(arguments);
				},

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#showCard
				 * @overridden
				 */
				showCard: function() {
					if (this.isSchedulerDataView()) {
						var selectedRows = this.get("SelectedRows");
						if (selectedRows.length) {
							var scheduleGridData = this.get("ScheduleGridData");
							var selectedRow = scheduleGridData.get(selectedRows[0]);
							var startDate = selectedRow.get("StartDate");
							this.saveSeparateModeSchedulerProperties();
							this.setVerticalSchedulerPeriodToOneDay(startDate);
						}
					}
					this.callParent(arguments);
				},

				/**
				 * ############# ###### ### ############# ####### ###### ###### ###.
				 * @param {Object} date #### ###### ####### ######.
				 */
				setVerticalSchedulerPeriodToOneDay: function(date) {
					if(Ext.isEmpty(this.get("SchedulerStartDate")) || Ext.isEmpty(!this.get("SchedulerDueDate"))){
						return;
					}
					var startDate = this.get("SchedulerStartDate").toDateString("dd.MM.yyyy");
					var endDate = this.get("SchedulerDueDate").toDateString("dd.MM.yyyy");
					if (startDate !== endDate || startDate !== date.toDateString("dd.MM.yyyy")) {
						this.set("SchedulerStartDate", this.BPMSoft.deepClone(date));
						this.set("SchedulerDueDate", this.BPMSoft.deepClone(date));
					}
				},

				/**
				 * ########## ######## ## ######### ### ############# ##########.
				 * @overridden
				 */
				isNewRowSelected: function() {
					if (this.isSchedulerDataView()) {
						return true;
					} else {
						return this.callParent(arguments);
					}
				},

				/**
				 * ######## #######, ### ######## ############# ### ############# ##########.
				 * @protected
				 * @return {boolean}
				 */
				isSchedulerDataView: function() {
					return (this.get("ActiveViewName") === "SchedulerDataView");
				},

				/**
				 * ######## #######, ### ######## ############# ## ############# ##########.
				 * @protected
				 * @return {boolean}
				 */
				isNotSchedulerDataView: function() {
					return !this.isSchedulerDataView();
				},

				/**
				 * ########## ######### ###### "######### ######" # #### ###### "###".
				 * @protected
				 * @return {Boolean} ######### ###### "######### ######".
				 */
				getListSettingsOptionVisible: function() {
					return (this.get("IsSectionVisible") && this.isNotSchedulerDataView());
				},

				/**
				 * ########## ######### ###### "####### # ##########" # #### ###### "###".
				 * @protected
				 * @return {Boolean} ######### ###### "####### # ##########".
				 */
				getSchedulerDataViewOptionVisible: function() {
					return (this.get("IsSectionVisible") && this.isNotSchedulerDataView());
				},

				/**
				 * ########## ######### ###### "####### # ###### #######" # #### ###### "###".
				 * @protected
				 * @return {Boolean} ######### ###### "####### # ###### #######".
				 */
				getGridDataViewOptionVisible: function() {
					return (this.get("IsSectionVisible") && this.isSchedulerDataView());
				},

				/**
				 * ######## ####### ##### ## ### Email ######## ######.
				 * @protected
				 * @return {boolean}
				 */
				isActiveRowEmail: function() {
					var activeRowId = this.get("ActiveRow");
					if (activeRowId) {
						var gridData = this.getGridData();
						if (gridData.contains(activeRowId)) {
							var activeRow = gridData.get(activeRowId);
							var type = activeRow.get("Type").value;
							return type === ConfigurationConstants.Activity.Type.Email;
						}
						return false;
					}
					return false;
				},

				/**
				 * ######## #######, ###### ## ###### #########.
				 * @protected
				 * @return {Boolean}
				 */
				getIsSendButtonVisible: function() {
					var visible = this.get("IsSendButtonVisible") || false;
					return visible && this.isActiveRowEmail();
				},

				/**
				 * ######## #######, ###### ## ###### ########.
				 * @protected
				 * @return {Boolean}
				 */
				getIsReplyButtonVisible: function() {
					var visible = this.get("IsReplyButtonVisible") || false;
					return visible && this.isActiveRowEmail();
				},

				/**
				 * ######## #######, ###### ## ###### #########.
				 * @protected
				 * @return {Boolean}
				 */
				getIsForwardButtonVisible: function() {
					var visible = this.get("IsForwardButtonVisible") || false;
					return visible && this.isActiveRowEmail();
				},

				/**
				 * ######## #######, ###### ## ###### #########.
				 * @protected
				 * @return {Boolean}
				 */
				getIsForwardOUTButtonVisible: function() {
					var visible = this.get("IsForwardOUTButtonVisible") || false;
					return visible && this.isActiveRowEmail();
				},

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#linkClicked
				 * @overridden
				 */
				linkClicked: function(href, columnName) {
					if (columnName === this.primaryDisplayColumnName) {
						var linkParams = href.split("/");
						var recordId = linkParams[linkParams.length - 1];
						var gridData = this.getGridData();
						var row = gridData.get(recordId);
						var prcElId = row.get("ProcessElementId");
						var config = {
							procElUId: prcElId,
							recordId: recordId,
							scope: this,
							parentMethodArguments: arguments,
							parentMethod: this.getParentMethod()
						};
						if (ProcessModuleUtilities.tryShowProcessCard.call(this, config)) {
							return false;
						}
					}
					return this.callParent(arguments) || false;
				},

				/**
				 * Restores separate mode scheduler properties.
				 * @private
				 */
				restoreSeparateModeSchedulerProperties: function() {
					var sectionSchedulerStartDate = this.get("SectionSchedulerStartDate");
					if (sectionSchedulerStartDate) {
						this.set("SchedulerStartDate", sectionSchedulerStartDate);
						this.set("SectionSchedulerStartDate", null);
					}
					var sectionSchedulerDueDate = this.get("SectionSchedulerDueDate");
					if (sectionSchedulerDueDate) {
						this.set("SchedulerDueDate", sectionSchedulerDueDate);
						this.set("SectionSchedulerDueDate", null);
					}
				},

				/**
				 * Saves separate mode scheduler properties.
				 * @private
				 */
				saveSeparateModeSchedulerProperties: function() {
					if (!this.get("SectionSchedulerStartDate") && !this.get("SectionSchedulerDueDate")) {
						this.set("SectionSchedulerStartDate", this.get("SchedulerStartDate"));
						this.set("SectionSchedulerDueDate", this.get("SchedulerDueDate"));
					}
				},

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#closeCard
				 * @protected
				 * @overridden
				 */
				closeCard: function() {
					this.callParent(arguments);
					var isSchedulerDataView = this.isSchedulerDataView();
					var isSectionVisible = this.get("IsSectionVisible");
					if (isSchedulerDataView && isSectionVisible) {
						this.restoreSeparateModeSchedulerProperties();
					}
				},

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#showSection
				 * @protected
				 * @overridden
				 */
				showSection: function() {
					this.callParent(arguments);
					var schedulerDataView = this.isSchedulerDataView();
					var isCardVisible = this.get("IsCardVisible");
					if (schedulerDataView && !isCardVisible) {
						this.restoreSeparateModeSchedulerProperties();
					}
				},

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#addChangeDataViewOptions
				 * @overridden
				 */
				addChangeDataViewOptions: function(viewOptions) {
					viewOptions.addItem(this.getButtonMenuItem({
						"Caption": {"bindTo": "Resources.Strings.SchedulerDataViewCaption"},
						"Click": {"bindTo": "changeDataView"},
						"Tag": this.get("SchedulerDataViewName"),
						"ImageConfig": this.get("Resources.Images.SchedulerDataViewItemIcon")
					}));
					this.callParent(arguments);
				},

				/**
				 * ########## ############# ## ############# #######, ##### ######## ############.
				 * @private
				 */
				getParticipants: function() {
					var quickFilterModuleId = this.getQuickFilterModuleId();
					var owners = this.sandbox.publish("GetFixedFilter", {filterName: "Owner"},
						[quickFilterModuleId]);
					var participants = [];
					owners.forEach(function(item) {
						if (item.value !== this.BPMSoft.SysValue.CURRENT_USER_CONTACT.value) {
							participants.push(item);
						}
					});
					return participants;
				},

				/**
				 * Returns configuration information about card default values and parameters.
				 * @overridden
				 */
				getCardInfoConfig: function(typeColumnName, typeColumnValue) {
					var cardInfo = {
						typeColumnName: typeColumnName,
						typeUId: typeColumnValue
					};
					cardInfo.valuePairs = this.getCardInfoDefaultValues();
					this.set("SchedulerSelection", null);
					return cardInfo;
				},

				/**
				 * Returns activity section default values.
				 * Sends StartDate and DueDate if scheduler has selected interval.
				 * @protected
				 */
				getCardInfoDefaultValues: function() {
					var defaultValues = [];
					var selection = this.get("SchedulerSelection");
					if (selection) {
						defaultValues.push({
							name: "DueDate",
							value: selection.dueDate
						});
						defaultValues.push({
							name: "StartDate",
							value: selection.startDate
						});
					}
					defaultValues.push({
						name: "Participants",
						value: this.getParticipants()
					});
					return defaultValues;
				},

				/**
				 * Loads SimpleTaskAddModule.
				 * @overridden
				 */
				onRender: function() {
					this.callParent(arguments);
					this.sandbox.loadModule("SimpleTaskAddModule", {
						id: this.getSimpleAddTaskModuleId(),
						keepAlive: true
					});
					this.setFiltersVisibleInCombinedMode();
				},

				/**
				 * ########## ######## ###### #### ######## ########## ######.
				 * @private
				 * @param {Object} config ###### ######## ######
				 */
				getSimpleAddTaskViewModel: function(config) {
					this.sandbox.publish("GetSimpleTaskAddViewModel", config);
				},

				/**
				 * ######### ###### #### ######## ########## ###### # ######### ##########.
				 * @private
				 * @param {Object} viewModel ###### #### ######## ########## ######.
				 */
				onSimpleTaskViewModelCreated: function(viewModel) {
					var collection = this.get("SchedulerFloatItemsCollection");
					collection.add(viewModel);
				},

				/**
				 * ####### ###### #### ######## ########## ###### # ######### ##########.
				 * @private
				 * @param {Object} config ######### ### ########## ######,
				 * # ###### #### #### ########### ## ###### #########.
				 */
				onRemoveViewModel: function(config) {
					var viewModel = config.viewModel;
					var collection = this.get("SchedulerFloatItemsCollection");
					collection.remove(viewModel);
					var recordId = config.recordId;
					if (recordId) {
						this.set("SchedulerSelection", null);
						this.loadGridDataRecord(recordId);
					}
				},

				/**
				 * ########## ######, ####### ######## ######### ############# #######.
				 * @return {String} ###### # ########## #########.
				 */
				getSchedulerSelectionPressedKeys: function() {
					var symbols = this.get("SchedulerSelectionPressedKeys") || "";
					this.set("SchedulerSelectionPressedKeys", "");
					return symbols;
				},

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#subscribeSandboxEvents
				 * Subscribes on simple task module model creating/removing, on simple task module opening,
				 * on scheduler selection key pressed.
				 * @overridden
				 */
				subscribeSandboxEvents: function() {
					this.callParent(arguments);
					this.sandbox.subscribe("SimpleTaskViewModelCreated", this.onSimpleTaskViewModelCreated, this);
					this.sandbox.subscribe("RemoveViewModel", this.onRemoveViewModel, this);
					this.sandbox.subscribe("GetSchedulerSelectionPressedKeys", this.getSchedulerSelectionPressedKeys,
						this, this.getSelectionPressedKeysSubscribers());
					this.sandbox.subscribe("OpenItem", this.openItem, this, [this.getSimpleAddTaskModuleId()]);
					this.sandbox.subscribe("ReloadGridAfterAdd", this.onReloadGridAfterAdd, this);
				},

				/**
				 * ########## ######### # ###### ######### #### ######## ########## ######.
				 * @private
				 * @param {Object} config ################ ######.
				 */
				onFloatingItemReady: function(config) {
					var collection = this.get("SchedulerFloatItemsCollection");
					var viewModel = collection.getByIndex(0);
					this.sandbox.publish("RenderSimpleTaskAddView", {
						renderTo: config.renderTo,
						input: config.input,
						viewModel: viewModel
					});
				},

				/**
				 * Returns selection pressed keys subscribers.
				 * @private
				 * @return {Array} Subscribers.
				 */
				getSelectionPressedKeysSubscribers: function() {
					var subscribers = [];
					subscribers.push(this.getMiniPageSandboxId(this.entitySchemaName), this.getSimpleAddTaskModuleId());
					return subscribers;
				},

				/**
				 * Returns simple task module id.
				 * @private
				 * @return {String} Simple task module identifier.
				 */
				getSimpleAddTaskModuleId: function() {
					return this.sandbox.id + "_SimpleAddTaskModule";
				},

				/**
				 * ############# ######## ## ######### ######### ########## ######## #
				 * ######## ## ######### ### ###### ######## ########## ######.
				 * @overridden
				 */
				initGetCardInfoSubscription: function(typeColumnValue) {
					var typeColumnName = this.get("TypeColumnName");
					if (typeColumnName && typeColumnValue) {
						this.sandbox.subscribe("getCardInfo", function() {
							return this.getCardInfoConfig(typeColumnName, typeColumnValue);
						}, this, [
							this.getChainCardModuleSandboxId(typeColumnValue),
							this.getSimpleAddTaskModuleId()
						]);
					}
				},

				/**
				 * @inheritdoc BPMSoft.BaseSection#getCardModuleResponseTags
				 * @overridden
				 */
				getCardModuleResponseTags: function() {
					var editCardsSandboxIds = this.callParent(arguments);
					editCardsSandboxIds.push(this.getSimpleAddTaskModuleId() + "_CardModule");
					return editCardsSandboxIds;
				},

				/**
				 * ########## ########## ####### ## ######## # ##########.
				 * @overridden
				 * @return {Integer|*} ########## #######.
				 */
				getRowCount: function() {
					var rowCount = this.callParent(arguments);
					if (this.isSchedulerDataView()) {
						rowCount = this.get("SchedulerItemsAmountPerPage") || rowCount;
					}
					return rowCount;
				},

				/**
				 * Returns current active row in scheduler or grid.
				 * @overridden
				 * @return {Object|null} Current active record.
				 */
				getActiveRow: function() {
					var activeRow = null;
					var primaryColumnValue = this.isSchedulerDataView()
						? this.get("SelectedRows")[0]
						: this.get("ActiveRow");
				    if(primaryColumnValue === null) {
					   primaryColumnValue = this.cachedActiveRow;
				    }
					if (primaryColumnValue) {
						var gridData = this.getGridData();
						activeRow = gridData.contains(primaryColumnValue) ? gridData.get(primaryColumnValue) : null;
					}
					return activeRow;
				},

				/**
				 * Returns grid data view or scheduler data view.
				 * @overridden
				 * @return {*|Component}
				 */
				getCurrentGrid: function() {
					return this.isSchedulerDataView()
						? this.Ext.getCmp("ActivitySectionV2Scheduler")
						: this.Ext.getCmp(this.name + "DataGridGrid");
				},

				/**
				 * Opens activity page by double click.
				 * @private
				 */
				onScheduleItemDoubleClick: function() {
					var isCardVisible = this.get("IsCardVisible");
					if (isCardVisible === true) {
						return;
					}
					var collection = this.get("SchedulerFloatItemsCollection");
					if (!collection.isEmpty()) {
						return;
					}
					BPMSoft.MiniPageListener.close();
					this.openItem();
				},

				/**
				 * Reloaded grid data record if needed.
				 * @private
				 */
				onReloadGridAfterAdd: function(config) {
					if (config && config.entitySchemaName === this.entitySchemaName) {
						this.set("IsCardInChain", config.isInChain || false);
						this.loadGridDataRecord(config.primaryColumnValue, function() {
							this.set("IsCardInChain", false);
						}, this);
					}
				},

				/**
				 * Clears scheduler pop-up windows.
				 * @private
				 */
				onChangeSelectedItems: function() {
					var collection = this.get("SchedulerFloatItemsCollection");
					if (collection && !collection.isEmpty()) {
						collection.clear();
					}
				},

				/**
				 * Opens activity mini page in add mode or simple task window.
				 * @private
				 */
				onSelectionKeyPress: function() {
					var addPageTypeUId = ConfigurationConstants.Activity.Type.Task;
					if (this.hasAddMiniPage(addPageTypeUId)) {
						this.openAddMiniPage({
							entitySchemaName: this.entitySchemaName,
							valuePairs: this.getAddMiniPageDefaultValues(addPageTypeUId)
						});
					} else {
						this.getSimpleAddTaskViewModel({
							mode: (!this.get("IsCardVisible")) ? "normal" : "small"
						});
					}
				},

				/**
				 * ######## ############# ####### # ############ # ##### ############# ####### # #######.
				 * # ###### # ###########, ########### ## #####.
				 * @inheritdoc BPMSoft.BaseSectionV2#reloadGridColumnsConfig
				 * @overridden
				 */
				reloadGridColumnsConfig: function(doReRender) {
					var isNotSchedulerDataView = this.isNotSchedulerDataView();
					this.callParent([(doReRender && isNotSchedulerDataView)]);
				},

				/**
				 * ### ######## ###### ## ########## ######### ####### ####### # ######## ######.
				 * @inheritdoc BPMSoft.BaseSectionV2#reloadGridColumnsConfig
				 * @overridden
				 */
				ensureActiveRowVisible: function() {
					if (this.isSchedulerDataView()) {
						return;
					}
					this.callParent(arguments);
				},

				/**
				 * ############ ######### ######, # ####### ######### # ########### #########
				 * ### #### ######## ###### # ##########.
				 * @overridden
				 * @param {Object} response ##### #######.
				 */
				onGridDataLoaded: function(response) {
					this.callParent(arguments);
					if (!response.success || this.isNotSchedulerDataView()) {
						return;
					}
					var scheduleCollection = this.getGridData();
					var pageCount = this.get("SchedulePageCount") || 1;
					var canLoadMoreData = this.get("CanLoadMoreData");
					var rowCount = this.get("SchedulerItemsAmountPerPage");
					if (scheduleCollection.getCount() < pageCount * rowCount && canLoadMoreData) {
						this.needLoadData();
					} else {
						if (canLoadMoreData) {
							this.set("CanLoadMoreData", false);
							var message = this.get("Resources.Strings.LoadMoreDataTemplate");
							this.showConfirmationDialog(this.Ext.String.format(message, rowCount), function(result) {
								if (result === BPMSoft.MessageBoxButtons.YES.returnCode) {
									this.set("SchedulePageCount", pageCount + 1);
									this.set("CanLoadMoreData", true);
									this.needLoadData();
								}
							}, ["yes", "no"]);
						}
					}
				},

				/**
				 * Displays mask on scheduler while loading grid data records.
				 * @inheritdoc BPMSoft.GridUtilities#beforeLoadGridData
				 * @overridden
				 */
				beforeLoadGridData: function() {
					if (this.isSchedulerDataView()) {
						this.showBodyMask({timeout: 0});
					}
					this.callParent(arguments);
				},

				/**
				 * ########## # ########## ##### ######## ###### ### ########## ######.
				 * @inheritdoc BPMSoft.GridUtilities#beforeLoadGridDataRecord
				 * @overridden
				 */
				beforeLoadGridDataRecord: function() {
					if (this.isSchedulerDataView()) {
						this.showBodyMask({timeout: 0});
					}
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc BPMSoft.GridUtilities#addItemsToGridData
				 * @overridden
				 */
				addItemsToGridData: function() {
					this.callParent(arguments);
					if (this.isSchedulerDataView()) {
						this.hideBodyMask();
					}
				},

				/**
				 * ############# ########## ## #### ###### ### ############# ##########.
				 * @overridden
				 * @param {Object} esq ###### ## ####### ######.
				 */
				initQuerySorting: function(esq) {
					if (this.isSchedulerDataView()) {
						var sortedColumn = esq.columns.collection.get("StartDate");
						if (sortedColumn) {
							sortedColumn.orderPosition = 1;
							sortedColumn.orderDirection = this.BPMSoft.OrderDirection.ASC;
						}
					} else {
						this.callParent(arguments);
					}
				},

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#afterLoadGridDataUserFunction
				 * @overridden
				 */
				afterLoadGridDataUserFunction: function(primaryColumnValue) {
					this.callParent(arguments);
					if (this.isSchedulerDataView()) {
						this.set("SelectedRows", [primaryColumnValue]);
					}
				},

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#needSetActiveRow
				 * @overridden
				 */
				needSetActiveRow: function() {
					return this.isNotSchedulerDataView() && this.getCurrentGrid() && !this.get("IsCardVisible");
				},

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#rowSelected
				 * @overridden
				 * @protected
				 */
				rowSelected: function(primaryColumnValue) {
					if (this.isSchedulerDataView()) {
						this.set("ActiveRow", primaryColumnValue);
					}
					this.callParent(arguments);
				},

				/**
				 * Loads data in schedule.
				 * @overridden
				 */
				loadActiveViewData: function() {
					var activeViewName = this.getActiveViewName();
					if (activeViewName === this.get("GridDataViewName") || this.isSchedulerDataView()) {
						this.loadGridData();
					}
				},

				/**
				 * @inheritdoc BPMSoft.BaseSection#getGridRowViewModelClassName
				 */
				getGridRowViewModelClassName: function() {
					return this.isSchedulerDataView()
						? "BPMSoft.ActivitySectionGridRowViewModel"
						: this.callParent(arguments);
				},

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#destroy
				 * @overridden
				 */
				 destroy: function() {
					this.unsubscribeServerChannelEvents();
					this.callParent(arguments);
				},

				/**
				 * Removes viewmodel subscription to server messages.
				 * @protected
				 */
				 unsubscribeServerChannelEvents: function() {
					this.BPMSoft.ServerChannel.un(this.BPMSoft.EventName.ON_MESSAGE,
						this.onServerChannelMessage, this);
				},

				/**
				 * Subscribes viewmodel to server messages.
				 * @protected
				 */
				subscribeServerChannelEvents: function() {
					this.BPMSoft.ServerChannel.on(this.BPMSoft.EventName.ON_MESSAGE,
						this.onServerChannelMessage, this);
				},

				/**
				 * Server message handler.
				 * @protected
				 * @param {Object} scope Message scope.
				 * @param {Object} message Server messsage.
				 */
				 onServerChannelMessage: function(scope, message) {
					if ((this.isEmpty(message) || this.isEmpty(message.Header)) && 
						message.Header.Sender !== "RecordOperationsNotificator") {
						return;
					}
					const body = this.Ext.decode(message.Body);
					const activityRecordChangeMessage = Ext.String.format("{0}RecordChange", this.entitySchemaName);
					switch (message.Header.BodyTypeName) {
						case activityRecordChangeMessage:
							this.onActivityRecordChangeMessage(body.RecordId, body.State);
							break;
						default:
							break;
					}
				},

				/**
				 * Updates activity grid record on server message.
				 * @private
				 * @param {GUID} recordId Record identifier.
				 * @param {BPMSoft.EntityChangeType} state New record state.
				 */
				 onActivityRecordChangeMessage: function(recordId, state) {
					if (this.isNotSchedulerDataView() || this.get("IsCardVisible")) {
						return;
					}
					switch (state) {
						case BPMSoft.EntityChangeType.Inserted:
						case BPMSoft.EntityChangeType.Updated:
							this.loadGridDataRecord(recordId)
							break;
						case BPMSoft.EntityChangeType.Deleted:
							this.removeGridRecords([recordId]);
							break;
						default:
							break;
					}
				},

				/**
				 * ########### ## ####### ######, ### ######### ######### ######## ############# # Google-##########.
				 * @private
				 */
				initGoogleCalendarLog: function() {
					this.BPMSoft.ServerChannel.on(BPMSoft.EventName.ON_MESSAGE, this.onGoogleCalendarMessage, this);
				},

				/**
				 * ######### ######### ######## ############# # Google-##########.
				 * @param {Object} scope ########.
				 * @param {Object} message ######### ######## ############# # Google-##########.
				 */
				onGoogleCalendarMessage: function(scope, message) {
					switch (message.Header.Sender) {
						case "GoogleCalendar":
							this.log(message.Body, this.BPMSoft.LogMessageType.INFORMATION);
							break;
						default:
							break;
					}
				},

				/**
				 * Sets delay before filtration.
				 * @private
				 */
				initFiltersUpdateDelay: function() {
					this.filtersUpdateDelay = 300;
				},

				/**
				 * ############## ######### ####### ############## ########.
				 * ####### ## ######### ######## ### #### Email # ######
				 * @inheritdoc BPMSoft.BaseSection#initEditPages
				 * @override
				 */
				initEditPages: function() {
					var enabledEditPages = new this.BPMSoft.Collection();
					this.callParent(arguments);
					var editPages = this.get("EditPages");
					this.BPMSoft.each(editPages.getItems(), function(item) {
						if (item.get("Id") !== ConfigurationConstants.Activity.Type.Email &&
							item.get("Id") !== ConfigurationConstants.Activity.Type.Call) {
							enabledEditPages.add(item);
						}
					});
					this.set("EnabledEditPages", enabledEditPages);
				},

				/**
				 * @inheritdoc BPMSoft.BaseSection#checkEditPagesCount
				 * @override
				 */
				checkEditPagesCount: function() {
					return this.get("EnabledEditPages").getCount() > 1;
				},

				/**
				 * @inheritdoc BPMSoft.BaseSection#getAddMiniPageDefaultValues
				 * @override
				 */
				getAddMiniPageDefaultValues: function() {
					var defaultValues = this.callParent(arguments);
					defaultValues = this.Ext.Array.merge(defaultValues, this.getCardInfoDefaultValues());
					return defaultValues;
				},

				/**
				 * @inheritdoc BPMSoft.BaseSection#initAddRecordButtonParameters
				 * @overriden
				 */
				initAddRecordButtonParameters: function() {
					var caption = this.get("Resources.Strings.AddRecordButtonCaption");
					var tag = this.BPMSoft.GUID_EMPTY;
					var editPages = this.get("EnabledEditPages");
					var editPagesCount = editPages.getCount();
					if (editPagesCount === 1) {
						var editPage = editPages.getByIndex(0);
						caption = editPage.get("Caption");
						tag = editPage.get("Tag");
					}
					this.set("AddRecordButtonCaption", caption);
					this.set("AddRecordButtonTag", tag);
				},

				/**
				 * @inheritdoc BPMSoft.BaseSection#getExportToFileActionVisibility
				 * @overriden
				 */
				getExportToFileActionVisibility: function() {
					var visibility = this.callParent(arguments);
					return (visibility && this.isNotSchedulerDataView());
				},

				/**
				 * Schedule item title mouse click event handler.
				 * @private
				 * @param {Object} options Event handler options.
				 */
				scheduleItemTitleClick: function(options) {
					var historyStateInfo = this.getHistoryStateInfo();
					if (historyStateInfo.workAreaMode === ConfigurationEnums.WorkAreaMode.COMBINED) {
						return;
					}
					var activeRow = this.get("ActiveRow");
					if (activeRow) {
						var pageOptions = this.BPMSoft.deepClone(options);
						this.Ext.apply(pageOptions, {
							rowId: activeRow,
							columnName: this.primaryDisplayColumnName,
							isFixed: true,
							showDelay: 0
						});
						this.prepareMiniPageOpenParameters(pageOptions, {
							referenceSchemaName: this.entitySchemaName
						});
					}
				},

				/**
				 * Mouse over event handler.
				 * @private
				 * @param {Object} options Event handler options.
				 * @param {Object} entityInfo Entity column name or entity attribute with entitySchemaName.
				 */
				scheduleItemTitleMouseOver: function(options, entityInfo) {
					if (this.BPMSoft.Features.getIsEnabled("ShowMiniPageOnScheduleItemTitleMouseOver")) {
						entityInfo.referenceSchemaName = this.entitySchemaName;
						this.prepareMiniPageOpenParameters(options, entityInfo);
					}
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "OpenButton",
					"parentName": "SeparateModeActionButtonsLeftContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {"bindTo": "Resources.Strings.OpenButtonCaption"},
						"classes": {
							"textClass": ["actions-button-margin-right"]
						},
						"visible": {
							"bindTo": "isSchedulerDataView"
						},
						"enabled": {"bindTo": "getSchedulerButtonsEnabled"},
						"click": {"bindTo": "openItem"}
					}
				},
				{
					"operation": "insert",
					"name": "CopyButton",
					"parentName": "SeparateModeActionButtonsLeftContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {"bindTo": "Resources.Strings.CopyButtonCaption"},
						"classes": {
							"textClass": ["actions-button-margin-right"]
						},
						"visible": {
							"bindTo": "isSchedulerDataView"
						},
						"click": {
							"bindTo": "copyItem"
						},
						"enabled": {
							"bindTo": "getSchedulerButtonsEnabled"
						}
					}
				},
				{
					"operation": "insert",
					"name": "DeleteButton",
					"parentName": "SeparateModeActionButtonsLeftContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {"bindTo": "Resources.Strings.DeleteButtonCaption"},
						"classes": {
							"textClass": ["actions-button-margin-right"]
						},
						"visible": {
							"bindTo": "isSchedulerDataView"
						},
						"click": {
							"bindTo": "deleteItem"
						},
						"enabled": {
							"bindTo": "getSchedulerButtonsEnabled"
						}
					}
				},
				{
					"operation": "merge",
					"name": "SeparateModePrintButton",
					"values": {
						"visible": {
							"bindTo": "ActiveViewName",
							"bindConfig": {
								"converter": function(value) {
									var sectionPrintMenuItems = this.get("SectionPrintMenuItems");
									return ((value !== "SchedulerDataView") &&
									(sectionPrintMenuItems && sectionPrintMenuItems.getCount() > 0));
								}
							}
						}
					}
				},
				{
					"operation": "merge",
					"name": "SeparateModeViewOptionsButton",
					"values": {
						"visible": {"bindTo": "isNotSchedulerDataView"}
					}
				},
				{
					"operation": "merge",
					"name": "SelectMultipleRecordsMenuItem",
					"values": {
						"visible": {
							"bindTo": "isNotSchedulerDataView"
						}
					}
				},
				{
					"operation": "merge",
					"name": "SelectOneRecordMenuItem",
					"values": {
						"visible": {
							"bindTo": "isNotSchedulerDataView"
						}
					}
				},
				{
					"operation": "merge",
					"name": "UnselectAllRecordsMenuItem",
					"values": {
						"visible": {
							"bindTo": "isNotSchedulerDataView"
						}
					}
				},
				{
					"operation": "merge",
					"name": "ExportListToFileMenuItem",
					"values": {
						"visible": {
							"bindTo": "isNotSchedulerDataView"
						}
					}
				},
				{
					"operation": "merge",
					"name": "IncludeInFolderMenuItem",
					"values": {
						"visible": {
							"bindTo": "isNotSchedulerDataView"
						}
					}
				},
				{
					"operation": "merge",
					"name": "ExcludeFromFolderMenuItem",
					"values": {
						"visible": {
							"bindTo": "isNotSchedulerDataView"
						}
					}
				},
				{
					"operation": "merge",
					"name": "DeleteRecordMenuItem",
					"values": {
						"visible": {
							"bindTo": "isNotSchedulerDataView"
						}
					}
				},
				{
					"operation": "insert",
					"name": "SeparateModeIntervalButton",
					"parentName": "SeparateModeActionButtonsRightContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"controlConfig": {"menu": {"items": {"bindTo": "IntervalMenuItems"}}},
						"visible": {
							"bindTo": "isSchedulerDataView"
						},
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
						"caption": {"bindTo": "Resources.Strings.ViewOptionsButtonCaption"}
					}
				},
				{
					"operation": "insert",
					"parentName": "CombinedModeActionButtonsCardLeftContainer",
					"propertyName": "items",
					"name": "send",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"classes": {
							"textClass": ["actions-button-margin-right"],
							"wrapperClass": ["actions-button-margin-right"]
						},
						"caption": {"bindTo": "Resources.Strings.SendEmailAction"},
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
						"click": {"bindTo": "onCardAction"},
						"tag": "checkSenderBeforeSend",
						"visible": {
							"bindTo": "getIsSendButtonVisible"
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "CombinedModeActionButtonsCardLeftContainer",
					"propertyName": "items",
					"name": "reply",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {"bindTo": "Resources.Strings.ReplyActionCaption"},
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
						"classes": {
							"textClass": ["actions-button-margin-right"],
							"wrapperClass": ["actions-button-margin-right"]
						},
						"click": {"bindTo": "onCardAction"},
						"tag": "replyEmail",
						"visible": {
							"bindTo": "getIsReplyButtonVisible"
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "CombinedModeActionButtonsCardLeftContainer",
					"propertyName": "items",
					"name": "replyAll",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {"bindTo": "Resources.Strings.ReplyAllActionCaption"},
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
						"classes": {
							"textClass": ["actions-button-margin-right"],
							"wrapperClass": ["actions-button-margin-right"]
						},
						"click": {"bindTo": "onCardAction"},
						"tag": "replyAllEmail",
						"visible": {
							"bindTo": "getIsReplyButtonVisible"
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "CombinedModeActionButtonsCardLeftContainer",
					"propertyName": "items",
					"name": "forward",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {"bindTo": "Resources.Strings.ForwardActionCaption"},
						"layout": {"column": 13, "row": 0, "colSpan": 2},
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
						"click": {"bindTo": "onCardAction"},
						"tag": "forwardEmail",
						"visible": {
							"bindTo": "getIsForwardButtonVisible"
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "CombinedModeActionButtonsCardLeftContainer",
					"propertyName": "items",
					"name": "forwardOUT",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {"bindTo": "Resources.Strings.ForwardActionCaption"},
						"layout": {"column": 14, "row": 0, "colSpan": 2},
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
						"click": {"bindTo": "onCardAction"},
						"tag": "forwardEmail",
						"visible": {
							"bindTo": "getIsForwardOUTButtonVisible"
						}
					}
				},
				{
					"operation": "insert",
					"name": "Schedule",
					"parentName": "DataViewsContainer",
					"propertyName": "items",
					"values": {
						"id": "ActivitySectionV2Scheduler",
						"selectors": {"wrapEl": "#ActivitySectionV2Scheduler"},
						"itemType": BPMSoft.ViewItemType.SCHEDULE_EDIT,
						"visible": {"bindTo": "isSchedulerDataView"},
						"startHour": BPMSoft.SysSettings.cachedSettings.SchedulerTimingStart,
						"displayStartHour": BPMSoft.SysSettings.cachedSettings.SchedulerDisplayTimingStart + "-00",
						"dueHour": BPMSoft.SysSettings.cachedSettings.SchedulerTimingEnd,
						"timeScale": {"bindTo": "getTimeScale"},
						"period": {"bindTo": "getSchedulerPeriod"},
						"timezone": [{}],
						"startDate": null,
						"dueDate": null,
						"activityCollection": {"bindTo": "ScheduleGridData"},
						"selectedItems": {"bindTo": "SelectedRows"},
						"changeSelectedItems": {"bindTo": "onChangeSelectedItems"},
						"scheduleItemDoubleClick": {"bindTo": "onScheduleItemDoubleClick"},
						"scheduleItemTitleMouseOver": {"bindTo": "scheduleItemTitleMouseOver"},
						"scheduleItemTitleClick": {"bindTo": "scheduleItemTitleClick"},
						"change": {"bindTo": "changeScheduleItem"},
						"selection": {"bindTo": "SchedulerSelection"},
						"floatingItemsCollection": {"bindTo": "SchedulerFloatItemsCollection"},
						"selectionKeyPress": {bindTo: "onSelectionKeyPress"},
						"floatingItemReady": {"bindTo": "onFloatingItemReady"},
						"selectionKeyPressSymbols": {"bindTo": "SchedulerSelectionPressedKeys"},
						"itemBindingConfig": {
							"itemId": {"bindTo": "Id"},
							"title": {"bindTo": "getScheduleItemTitle"},
							"changeTitle": {"bindTo": "onTitleChanged"},
							"startDate": {"bindTo": "StartDate"},
							"changeStartDate": {"bindTo": "onStartDateChanged"},
							"dueDate": {"bindTo": "DueDate"},
							"changeDueDate": {"bindTo": "onDueDateChanged"},
							"status": {"bindTo": "getScheduleItemStatus"},
							"changeStatus": {"bindTo": "onStatusChanged"},
							"background": {"bindTo": "Background"},
							"fontColor": {"bindTo": "FontColor"},
							"isBold": {"bindTo": "IsBold"},
							"isItalic": {"bindTo": "IsItalic"},
							"isUnderline": {"bindTo": "IsUnderline"},
							"markerValue": {"bindTo": "getScheduleItemHint"}
						},
						"floatingItemBindingConfig": {
							"caption": {"bindTo": "getSimpleModuleCaption"},
							"width": {"bindTo": "getSimpleModuleWidth"}
						},
						"canExecute": {"bindTo": "canBeDestroyed"}
					}
				},
				{
					"operation": "insert",
					"index": 0,
					"name": "OpenSchedulerDataViewOptionsMenuItem",
					"parentName": "AnalyticsModeViewOptionsButton",
					"propertyName": "menu",
					"values": {
						"itemType": BPMSoft.ViewItemType.MENU_ITEM,
						"caption": {"bindTo": "Resources.Strings.SchedulerDataViewCaption"},
						"markerValue": {"bindTo": "Resources.Strings.SchedulerDataViewCaption"},
						"click": {"bindTo": "changeDataView"},
						"tag": "SchedulerDataView"
					}
				},
				{
					"operation": "merge",
					"name": "SeparateModeAddRecordButton",
					"parentName": "SeparateModeActionButtonsLeftContainer",
					"propertyName": "items",
					"values": {
						"controlConfig": {
							"menu": {
								"items": {
									"bindTo": "EnabledEditPages",
									"bindConfig": {
										"converter": function(editPages) {
											if (editPages.getCount() > 1) {
												return editPages;
											} else {
												return null;
											}
										}
									}
								}
							}
						}

					}
				},
				{
					"operation": "merge",
					"name": "CombinedModeAddRecordButton",
					"parentName": "CombinedModeActionButtonsSectionContainer",
					"propertyName": "items",
					"values": {
						"controlConfig": {
							"menu": {
								"items": {
									"bindTo": "EnabledEditPages",
									"bindConfig": {
										"converter": function(editPages) {
											if (editPages.getCount() > 1) {
												return editPages;
											} else {
												return null;
											}
										}
									}
								}
							}
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
