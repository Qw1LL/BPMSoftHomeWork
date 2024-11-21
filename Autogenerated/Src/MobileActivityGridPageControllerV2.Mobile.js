/* globals Activity: false */
/* globals ActivityStatus: false */
/* globals ActivityResult: false */
/* globals ActivityActionsModel: false */
/* globals Promise: false */
Ext.define("BPMSoft.configuration.controller.ActivityGridPage", {
	alternateClassName: "ActivityGridPage.Controller",
	extend: "BPMSoft.controller.BaseGridPage",

	statics: {

		Model: Activity

	},

	config: {

		refs: {
			view: "#ActivityGridPage"
		},

		/**
		 * @obsolete
		 */
		startDate: null,

		/**
		 * @obsolete
		 */
		dueDate: null,

		/**
		 * @obsolete
		 */
		period: null

	},

	//region Properties: Private

	/**
	 * @private
	 */
	profileData: null,

	/**
	 * @private
	 */
	gridModePicker: null,

	/**
	 * @private
	 */
	employeePicker: null,

	/**
	 * @private
	 */
	selectedRecord: null,

	/**
	 * @private
	 */
	isSchedule: null,

	/**
	 * @private
	 */
	forceRefresh: null,

	/**
	 * @private
	 */
	currentDisplayDate: null,

	/**
	 * @private
	 */
	scheduleActiveDate: null,

	/**
	 * @private
	 */
	exportData: null,

	/**
	 * @private
	 */
	autoShowNoConnectionStatusPanel: null,

	/**
	 * @private
	 */
	firstImportFinished: false,

	/**
	 * @private
	 */
	importHelper: null,

	/**
	 * @private
	 */
	hasExportConflicts: false,

	//endregion

	//region Properties: Protected

	/**
	 * @protected
	 */
	startDateColumnName: "StartDate",

	/**
	 * @protected
	 */
	endDateColumnName: "DueDate",

	//endregion

	//region Methods: Private

	/**
	 * @private
	 */
	updatePeriodFilterDateFormat: function() {
		var periodFilterComponent = this.getViewActivityPeriodFilterComponent();
		if (!periodFilterComponent) {
			return;
		}
		var dateFormat = "d M.";
		var isSchedule = this.getIsSchedule();
		if (isSchedule) {
			dateFormat = BPMSoft.LS["Sys.DateFormat.Schedule"];
			if (Ext.os.is.Phone && BPMSoft.util.getOrientation() === Ext.Viewport.PORTRAIT) {
				dateFormat = "l, " + dateFormat;
			}
		}
		periodFilterComponent.setDisplaySingleDate(isSchedule);
		periodFilterComponent.setDateFormat(dateFormat);
	},

	/**
	 * @private
	 */
	setViewOwnerButtonImage: function(ownerId) {
		var autoSetProxy = true;
		var proxyType;
		if (this.canUseCache() && ownerId === BPMSoft.CurrentUserInfo.contactId) {
			proxyType = BPMSoft.ProxyType.Offline;
			autoSetProxy = false;
		}
		var onlineProxy = BPMSoft.DataUtils.getOnlineProxy();
		var isHybridMode = BPMSoft.FeatureUtils.isHybridMode();
		BPMSoft.CFUtils.getUserImageUrl({
			contactId: ownerId,
			proxyType: proxyType,
			autoSetProxy: autoSetProxy,
			onlineProxy: onlineProxy,
			cachePriority: isHybridMode,
			cancellationId: this.getCancellationId("getUserImageUrl"),
			callback: function(imageUrl) {
				imageUrl = BPMSoft.util.formatUrlForBackgroundImage(imageUrl);
				var view = this.getView();
				view.setOwnerButtonImage(imageUrl);
			},
			scope: this
		});
	},

	/**
	 * @private
	 */
	saveActivityProfileData: function() {
		var profileData = this.profileData;
		if (!profileData.gridMode) {
			profileData.gridMode = this.getIsSchedule() ? BPMSoft.Configuration.ActivityGridModeTypes.Schedule :
				BPMSoft.Configuration.ActivityGridModeTypes.List;
		}
		var profileValue = JSON.stringify(profileData);
		BPMSoft.MobileProfileManager.saveData({
			key: "ActivityGrid",
			value: profileValue,
			failure: function(exception) {
				BPMSoft.MessageBox.showException(exception);
			},
			scope: this
		});
	},

	/**
	 * @private
	 */
	loadActivityProfileData: function(config) {
		BPMSoft.MobileProfileManager.loadData({
			key: "ActivityGrid",
			success: function(profileData) {
				this.profileData = this.initializeActivityProfileData(profileData);
				Ext.callback(config.success, config.scope, [this.profileData]);
			},
			failure: config.failure,
			scope: config.scope
		});
	},

	/**
	 * @private
	 */
	updatePeriodFilter: function() {
		var isSchedule = this.getIsSchedule();
		var periodFilterComponent = this.getViewActivityPeriodFilterComponent();
		if (!periodFilterComponent) {
			return;
		}
		periodFilterComponent.setPeriodButton(!isSchedule);
		periodFilterComponent.setPreviousButton(!isSchedule);
		periodFilterComponent.setNextButton(!isSchedule);
	},

	/**
	 * @private
	 */
	shouldShowWeekRow: function() {
		var datePeriod = this.getDatePeriod();
		var date = datePeriod.getDate();
		return !BPMSoft.Date.areDatesEqual(date.start, date.due);
	},

	/**
	 * @private
	 */
	getDatePeriod: function() {
		var periodFilterComponent = this.getViewActivityPeriodFilterComponent();
		return periodFilterComponent ? periodFilterComponent.getDatePeriod() : null;
	},

	/**
	 * @private
	 */
	updateDatePeriod: function(config) {
		if (this.isDetail()) {
			return;
		}
		var profilePeriod = this.profileData.period;
		if (!Ext.isObject(config)) {
			config = {};
			if (!Ext.isEmpty(profilePeriod)) {
				if (!Ext.isObject(profilePeriod)) {
					config.period = profilePeriod;
				} else {
					if (profilePeriod.startDate && profilePeriod.dueDate) {
						config.startDate = new Date(profilePeriod.startDate);
						config.dueDate = new Date(profilePeriod.dueDate);
						if (BPMSoft.Date.areEqual(config.startDate, config.dueDate)) {
							this.scheduleActiveDate = config.startDate;
						}
					}
				}
			}
		}
		if (!config.period && (!Ext.isDate(config.startDate) || !Ext.isDate(config.dueDate))) {
			config.period = this.getDefaultPeriod();
		}
		this.validateDatePeriod(config);
		var datePeriod = this.getDatePeriod();
		var isChanged;
		if (config.period) {
			isChanged = datePeriod.setPeriod(config.period);
		} else {
			isChanged = datePeriod.setDate({start: config.startDate, due: config.dueDate});
		}
		var grid = this.getGrid();
		if (isChanged && (grid instanceof BPMSoft.Schedule)) {
			var date = datePeriod.getDate();
			grid.setPeriod({start: date.start, due: date.due});
		}
		return isChanged;
	},

	/**
	 * @private
	 */
	updateNavigationPanel: function() {
		var isSchedule = this.getIsSchedule();
		if (isSchedule) {
			var shouldShowNavigationPanel = (!Ext.os.is.Phone || BPMSoft.util.getOrientation() !== Ext.Viewport.LANDSCAPE);
			var view = this.getView();
			view.setNavigationPanel(shouldShowNavigationPanel);
			//BPMSoft.StatusBarManager.setContentStyle(!shouldShowNavigationPanel);
		}
	},

	/**
	 * @private
	 */
	validateDatePeriod: function(config) {
		const getDaysPeriod = () => {
			var schedulePeriod = this.getSchedulePeriod();
			switch (schedulePeriod) {
				case BPMSoft.Configuration.ActivitySchedulePeriods.Day:
					return  1;
				case BPMSoft.Configuration.ActivitySchedulePeriods.ThreeDay:
					return 3;
				case BPMSoft.Configuration.ActivitySchedulePeriods.FiveDay:
					return 5;
				case BPMSoft.Configuration.ActivitySchedulePeriods.Week:
					return 7;
				default:
					break;
			}
		}

		if (!this.getIsSchedule()) {
			return;
		}
		if (this.scheduleActiveDate) {
			config.startDate = this.scheduleActiveDate;
		}
		if (config.period) {
			var date = BPMSoft.DatePeriod.getDateByPeriod(config.period);
			this.scheduleActiveDate = config.startDate = date.start;
			config.period = null;
		}

		var daysPeriod;

		if (Ext.os.is.Phone) {
			if (BPMSoft.util.getOrientation() === Ext.Viewport.LANDSCAPE) {
				daysPeriod = getDaysPeriod();
			} else {
				daysPeriod = 1;
			}
		} else {
			daysPeriod = getDaysPeriod();
		}

		if (daysPeriod > 1) {
			var period = this.getStartWeekPeriod(config.startDate, daysPeriod);
			config.startDate = period.startDate;
			config.dueDate = period.dueDate;
		} else {
			//Проверка есть ли выделенный эелемент списка
			if (this.selectedRecord) {
				config.startDate = new Date(this.selectedRecord.data.StartDate);
				config.dueDate = new Date(this.selectedRecord.data.StartDate);

				if (!!selectedRecordItem || selectedRecordItem === null) {
					selectedRecordItem = this.selectedRecord;
				}
			} else {
				config.dueDate = new Date(config.startDate);
			}

		}
	},

	/**
	 * @private
	 */
	getStartWeekPeriod: function(date, days) {
		var period = {};
		var dayOfWeek = date.getDay();
		if (dayOfWeek === 0) {
			dayOfWeek = 7;
		}
		dayOfWeek--;
		period.startDate = BPMSoft.Date.add(date, Ext.Date.DAY, -dayOfWeek);
		period.dueDate = BPMSoft.Date.add(period.startDate, Ext.Date.DAY, days - 1);
		return period;
	},

	/**
	 * @private
	 */
	getCalendarScrollingDates: function(startDate, dueDate, isForward) {
		if (BPMSoft.util.compareDate(startDate, Ext.Date.getFirstDateOfMonth(startDate)) &&
			BPMSoft.util.compareDate(dueDate, Ext.Date.getLastDateOfMonth(dueDate))) {
			startDate = Ext.Date.add(startDate, Ext.Date.MONTH, isForward ? 1 : -1);
			dueDate = Ext.Date.getLastDateOfMonth(startDate);
		} else {
			startDate.setHours(0, 0, 0, 0);
			dueDate.setHours(0, 0, 0, 0);
			var diff = BPMSoft.Date.diff(startDate, dueDate, Ext.Date.DAY) + 1;
			if (!isForward) {
				diff = -diff;
			}
			startDate = BPMSoft.Date.add(startDate, Ext.Date.DAY, diff);
			dueDate = BPMSoft.Date.add(dueDate, Ext.Date.DAY, diff);
		}
		return {
			startDate: startDate,
			dueDate: dueDate
		};
	},

	/**
	 * @private
	 */
	getDefaultPeriod: function() {
		var isSchedule = this.getIsSchedule();
		if (!isSchedule) {
			return BPMSoft.CalendarPeriod.CurrentWeek;
		} else {
			return BPMSoft.CalendarPeriod.Today;
		}
	},

	/**
	 * @private
	 */
	getSchedulePeriod: function() {
		if (!Ext.isEmpty(this.profileData.schedulePeriod)) {
			return this.profileData.schedulePeriod;
		}
		return BPMSoft.Configuration.ActivitySchedulePeriods.Week;
	},

	/**
	 * Returns view's grid.
	 * @private
	 */
	getGrid: function() {
		var view = this.getView();
		return view.getGrid();
	},

	/**
	 * @private
	 */
	finishAction: function() {
		this.deselectAll();
	},

	/**
	 * @private
	 */
	finishCopyAction: function() {
		this.finishAction();
		this.refreshDirtyData();
		BPMSoft.Mask.hide();
	},

	/**
	 * @private
	 */
	getContactRecord: function(recordId) {
		return new Promise(function(resolve) {
			var filter = Ext.create("BPMSoft.Filter", {
				property: "Id",
				value: recordId
			});
			BPMSoft.DataUtils.loadRecords({
				proxyType: BPMSoft.ProxyType.Online,
				modelName: "Contact",
				columns: ["Name", "Account", "Photo.Id"],
				filters: filter,
				success: function(loadedContactRecords) {
					if (loadedContactRecords.length === 0) {
						resolve();
						return;
					}
					resolve(loadedContactRecords[0]);
				},
				failure: function() {
					resolve();
				},
				scope: this
			});
		});
	},

	/**
	 * @private
	 */
	changeOwner: function(ownerId) {
		if (ownerId === this.profileData.ownerId) {
			return;
		}
		this.profileData.ownerId = ownerId;
		if (this.canUseCache()) {
			this.getContactRecord(ownerId).then(function(contactRecord) {
				var manager = Ext.create("BPMSoft.configuration.SysAdminUnitCacheManager", {});
				manager.putRecord(contactRecord).then(function() {
					this.setViewOwnerButtonImage(ownerId);
				}.bind(this));
			}.bind(this));
		} else {
			this.setViewOwnerButtonImage(ownerId);
		}
		this.loadData();
		this.saveRecentOwners();
		this.saveActivityProfileData();
		this.firstImportFinished = false;
		this.runImportIfNeeded();
	},

	/**
	 * @private
	 */
	saveRecentOwners: function() {
		var recentOwnersLimit = 10;
		var recentOwners = this.profileData.recentOwners;
		var ownerIndex = recentOwners.indexOf(ownerId);
		if (ownerIndex !== -1) {
			recentOwners.splice(ownerIndex, 1);
		}
		recentOwners.splice(0, 0, ownerId);
		recentOwners.splice(recentOwnersLimit, recentOwners.length);
	},

	/**
	 * @private
	 * Добавляет в массив записей запись текущего пользователя
   	 * @returns Массив записей с записью текущего пользователя на 1 месте
     */
	addCurrentUserToFirstPosition: function (records){
		const currentUserContactRecord = this.currentUserContactRecord;
		var newRecords = records;
		if (currentUserContactRecord){
			const filtredRecords = records.filter((v)=>v.getId() !== BPMSoft.CurrentUserInfo.contactId);
			newRecords = [...filtredRecords, currentUserContactRecord];
		}

		newRecords.sort((a,b)=>
			 a.get("Name").localeCompare(b.get("Name"))
		);

		return newRecords
	},

	/**
   	 * @private
   	 */
	loadEmployeeStore: function (config) {
		if (!this.profileData.recentOwners) {
		  this.profileData.recentOwners = [];
		}
		var ownerId = this.profileData.ownerId;
		var employeePicker = this.getEmployeePicker();
		employeePicker.clearSearchValue();
		var pickerList = employeePicker.getComponent();
		var employeeStore = pickerList.getStore();
		employeeStore.setProxyType(this.getProxyType());
		employeeStore.loadPage(1, {
		  isCancelable: true,
		  queryConfig: this.getEmployeeQueryConfig(),
		  callback: function (records) {
			const newRecords = this.addCurrentUserToFirstPosition(records)
			employeeStore.setData(newRecords);

			var employeeRecord = employeeStore.getById(ownerId);
			pickerList.select(employeeRecord, false, true);

			var needShowSearchMessage = records.length == 0;
			if (needShowSearchMessage) {
			  var employeeContainer = employeePicker.getWrappedContainer();
			  BPMSoft.ControlUtils.showSearchNeededMessage(
				showSearchNeededMessage,
				employeeContainer
			  );
			  pickerList.hide();
			  employeeStore.on(
				"load",
				function () {
				  pickerList.show();
				  BPMSoft.ControlUtils.showSearchNeededMessage(
					false,
					employeeContainer
				  );
				},
				this,
				{ single: true }
			  );
			}

			Ext.callback(config.callback, config.scope);
		  },
		  filters: config.filters,
		  scope: this,
		});
	  },

	  /**
	   * @private
	   */
	  getEmployeePickerStoreFilters: function () {
		var filters;
		var recentOwners = this.getProfileRecentOwners();
		if (recentOwners.length > 0) {
		  filters = Ext.create("BPMSoft.Filter", {
			property: "Id",
			funcType: BPMSoft.FilterFunctions.In,
			funcArgs: recentOwners,
			name: "RecentOwners",
		  });
		} else {
		  filters = Ext.create("BPMSoft.Filter", {
			property: "Id",
			value: null,
		  });
		}
		return filters;
	  },

	  /**
	   * @private
	   */
	  getProfileRecentOwners: function () {
		if (!this.profileData.recentOwners) {
		  this.profileData.recentOwners = [];
		}
		return this.profileData.recentOwners;
	  },

	  /**
	   * @private
	   */
	  loadValues: function () {
		var employeePicker = this.getEmployeePicker();
		var pickerList = employeePicker.getComponent();
		this.loadEmployeeStore({
		  filters: this.getEmployeePickerStoreFilters(),
		  callback: function () {
			pickerList.setMasked(false);
		  },
		  scope: this,
		});
	  },

	  /**
	   * @private
	   */
	  showEmployeePicker: function () {
		var employeePicker = this.getEmployeePicker();
		var pickerList = employeePicker.getComponent();
		pickerList.setMasked(true);
		this.doShowEmployeePicker(employeePicker);

		if (this.currentUserContactRecord) {
		  this.loadValues();
		  return;
		}

		var currentUserIdFilter = Ext.create("BPMSoft.Filter", {
		  property: "Id",
		  value: BPMSoft.CurrentUserInfo.contactId,
		});

		BPMSoft.DataUtils.loadRecords({
		  proxyType: this.getProxyType(),
		  modelName: "Contact",
		  columns: ["Name", "Photo.PreviewData"],
		  filters: currentUserIdFilter,
		  isCancelable: true,
		  success: function (loadedContactRecords) {
			const record = loadedContactRecords[0];
			this.currentUserContactRecord = record;
			if (!this.profileData && !this.profileData.ownerId) {
				this.profileData.ownerId = record.getId();
			}

			Ext.callback(this.loadValues, this);
		  },
		  failure: this.loadValues,
		  scope: this,
		});
	  },

	/**
	 * @private
	 */
	doShowEmployeePicker: function(employeePicker) {
		if (!employeePicker.getParent()) {
			Ext.Viewport.add(employeePicker);
		}
		employeePicker.show();
	},

	/**
	 * @private
	 */
	removeTmpGridRecord: function() {
		if (this.tmpGridRecord) {
			if (this.tmpGridRecord.phantom) {
				var grid = this.getGrid();
				var store = grid.getStore();
				var itemIndex = store.data.items.indexOf(this.tmpGridRecord);
				if (itemIndex !== -1) {
					store.remove(this.tmpGridRecord);
				}
			}
			this.tmpGridRecord = null;
		}
	},

	/**
	 * @private
	 */
	isScheduleColumn: function(element) {
		if (!element) {
			return false;
		}
		var className = element.className;
		var parentNode = element.parentNode;
		return ((className === "x-time-column") || (className === "x-column")) && (parentNode.className !== "x-week-row");
	},

	/**
	 * @private
	 */
	getActivityStatusButtonText: function(record) {
		var statusRecord = this.getOppositeActivityStatusRecord(record);
		var statusDisplayValue = statusRecord.getPrimaryDisplayColumnValue();
		return Ext.String.format(BPMSoft.LocalizableStrings.ActivityGridPageActionsPickerButtonText, statusDisplayValue);
	},

	/**
	 * @private
	 */
	getOppositeActivityStatusRecord: function(record) {
		var activityStatus = record.get("Status");
		var activityStatusData = ActivityStatus.Store.getData();
		if (activityStatus.getId() === BPMSoft.Configuration.ActivityStatus.Finished) {
			return activityStatusData.get(BPMSoft.Configuration.ActivityStatus.NotStarted);
		} else {
			return activityStatusData.get(BPMSoft.Configuration.ActivityStatus.Finished);
		}
	},

	/**
	 * Refreshes activity in schedule with new status.
	 * @private
	 * @param {Activity} record Instance of activity.
	 */
	completeStatusSaving: function(record) {
		record.commit();
		var operationConfig = {
			action: "update",
			record: record,
			modifiedColumns: ["Status"]
		};
		this.refreshDirtyData(operationConfig);
		var grid = this.getGrid();
		grid.setEditableItem(null);
		this.deselectAll();
	},

	/**
	 * Updates Status field for current activity.
	 * @private
	 * @param {ActivityStatus} activityStatusRecord Instance of activity status.
	 */
	saveCurrentActivityWithStatus: function(activityStatusRecord) {
		var selectedRecord = this.selectedRecord;
		if (selectedRecord) {
			selectedRecord.set("Status", activityStatusRecord);
			var processElementId = selectedRecord.get("ProcessElementId");
			if (activityStatusRecord.getId() === BPMSoft.Configuration.ActivityStatus.Finished &&
				!Ext.isEmpty(processElementId) && !BPMSoft.util.isEmptyGuid(processElementId)) {
				BPMSoft.Mask.show();
				BPMSoft.MobileActivityUtilities.getActivityResultRecords({
					activityRecord: selectedRecord,
					cancellationId: this.getCancellationId("saveCurrentActivityWithStatus"),
					success: function(records) {
						if (records.length > 0) {
							this.showActivityResultPicker({
								activityResults: records,
								selectCallback: function(record) {
									selectedRecord.set("Result", record);
									this.doSaveCurrentActivityWithStatus();
								},
								cancelCallback: function() {
									selectedRecord.reject();
								},
								scope: this
							});
						} else {
							this.doSaveCurrentActivityWithStatus();
						}
						BPMSoft.Mask.hide();
					},
					failure: function(exception) {
						BPMSoft.Mask.hide();
						selectedRecord.reject();
						BPMSoft.MessageBox.showException(exception);
					},
					scope: this
				});
			} else {
				this.doSaveCurrentActivityWithStatus();
			}
		}
	},

	/**
	 * Updates Status field for current activity.
	 * @private
	 */
	doSaveCurrentActivityWithStatus: function() {
		var queryConfig = Ext.create("BPMSoft.QueryConfig", {
			columns: ["Status", "Result"],
			modelName: "Activity"
		});
		var useOptimisticEditing = BPMSoft.ApplicationUtils.useOptimisticEditing();
		var selectedRecord = this.selectedRecord;
		var proxyType = this.getProxyType();
		selectedRecord.setProxyType(proxyType);
		selectedRecord.save({
			isCancelable: !useOptimisticEditing,
			cancellationId: this.getCancellationId("saveActivityWithStatus"),
			queryConfig: queryConfig,
			success: function() {
				if (!useOptimisticEditing) {
					this.completeStatusSaving(selectedRecord);
				}
			},
			afterRequest: function() {
				if (useOptimisticEditing) {
					this.completeStatusSaving(selectedRecord);
				}
			},
			failure: function(exception) {
				BPMSoft.MessageBox.showException(exception);
			},
			scope: this
		}, this);
	},

	/**
	 * @private
	 */
	setActionsByGridMode: function(useWithRecord) {
		var isSchedule = this.getIsSchedule();
		var actions;
		if (isSchedule && useWithRecord) {
			actions = this.getUsedWithRecordActions();
		} else {
			actions = this.getActions();
		}
		this.setViewActions(actions);
	},

	/**
	 * @private
	 */
	getUsedWithRecordActions: function() {
		var actionManager = this.getActionManager();
		var items = actionManager.getItems();
		items = items.filter(function(item) {
			return item.useWithRecord === true;
		});
		return items;
	},

	/**
	 * @private
	 */
	getGridModePickerStore: function() {
		return Ext.create("Ext.data.Store", {
			model: ActivityActionsModel,
			data: [
				{
					Type: BPMSoft.Configuration.ActivityGridModeTypes.Schedule,
					Name: BPMSoft.LocalizableStrings.ActivityGridPageV2ScheduleTitle
				},
				{
					Type: BPMSoft.Configuration.ActivityGridModeTypes.List,
					Name: BPMSoft.LocalizableStrings.ActivityGridPageActionsPickerList
				}
			],
			grouper: "Group"
		});
	},

	/**
	 * @private
	 */
	getGridModePicker: function() {
		if (this.gridModePicker) {
			var gridModePickerStore = this.getGridModePickerStore();
			var gridModePickerList = this.gridModePicker.getComponent();
			gridModePickerList.setStore(gridModePickerStore);
			return this.gridModePicker;
		}
		var pickerStore = this.getGridModePickerStore();
		this.gridModePicker = Ext.create("Ext.BPMSoft.ComboBoxPicker", {
			component: {
				store: pickerStore,
				primaryColumn: "Name",
				listeners: {
					scope: this,
					select: this.onGridModePickerSelect
				},
				pinHeaders: false
			},
			toolbar: {
				clearButton: false
			},
			title: BPMSoft.LocalizableStrings.ActivityGridPageGridModePickerTitle,
			deselectOnHide: false,
			popup: true
		});
		var gridMode = this.getActivityGridMode();
		var selectedRecord = pickerStore.getById(gridMode);
		var pickerList = this.gridModePicker.getComponent();
		pickerList.select(selectedRecord);
		return this.gridModePicker;
	},

	/**
	 * @private
	 */
	getEmployeeStoreFilters: function() {
		return Ext.create("BPMSoft.Filter", {
			modelName: "SysAdminUnit",
			assocProperty: "Contact",
			operation: "BPMSoft.FilterOperations.Any",
			property: "Active",
			value: true
		});
	},

	/**
	 * @private
	 */
	setIsScheduleByXtype: function(xtype) {
		this.isSchedule = this.getIsScheduleByXtype(xtype);
	},

	/**
	 * @private
	 */
	getIsScheduleByXtype: function(xtype) {
		return xtype === BPMSoft.Configuration.ActivityGridModeTypes.Schedule;
	},

	/**
	 * @private
	 */
	updateFilterPanel: function() {
		var view = this.getView();
		var filterPanel = view.getFilterPanel();
		filterPanel.setExtendedButton(this.getIsExtendedFiltersEnabled());
		this.applyExtendedFilters();
		view.setFolderButton(this.shouldUseFolderFilters());
		view.setSummaryButton(this.shouldUseSummaries());
	},

	/**
	 * @private
	 */
	changeGridMode: function(mode) {
		this.firstImportFinished = false;
		this.profileData.gridMode = mode;
		this.scheduleActiveDate = null;
		this.setIsScheduleByXtype(mode);
		this.updatePeriodFilterDateFormat();
		var view = this.getView();
		var gridConfig = this.getInitialGridConfig();
		view.setGrid(gridConfig);
		this.updateNavigationPanel();
		this.setExtendedFilters(null, null);
		this.loadProfileData(function() {
			var isUpdated = this.updateDatePeriod();
			if (!isUpdated) {
				this.loadData();
				this.runImportIfNeeded();
			}
			this.saveActivityProfileData();
			this.updateFilterPanel();
		}.bind(this));
	},

	/**
	 * @private
	 */
	getEmployeeQueryConfig: function() {
		return Ext.create("BPMSoft.QueryConfig", {
			modelName: "Contact",
			columns: ["Name", "Account", "Photo.PreviewData"],
			orderByColumns: [
				{
					column: "Name",
					orderType: BPMSoft.OrderTypes.ASC
				}
			],
			onlineProxy: BPMSoft.DataUtils.getOnlineProxy()
		});
	},

	/**
	 * @private
	 */
	getCurrentUserActionCaption: function() {
		return Ext.String.format(BPMSoft.LocalizableStrings.ActivityGridPageActionsPickerCurrentUserFormat,
			BPMSoft.CurrentUserInfo.contactName);
	},

	/**
	 * @private
	 */
	getActivityGridMode: function() {
		var grid = this.getGrid();
		return grid.xtype;
	},

	/**
	 * @private
	 */
	closeRecordPage: function() {
		while (BPMSoft.PageNavigator.getLastPageController() !== this) {
			BPMSoft.Router.back();
		}
	},

	/**
	 * @private
	 */
	getViewActivityPeriodFilterComponent: function() {
		var view = this.getView();
		var filterPanel = view.getFilterPanel();
		var periodFilter = filterPanel.getModuleByName("ActivityPeriodFilter");
		return periodFilter && periodFilter.getComponent();
	},

	/**
	 * @private
	 */
	validateCalendarDatePeriod: function(config) {
		this.scheduleActiveDate = config.startDate;
		this.validateDatePeriod(config);
	},

	/**
	 * Deselects all items in shedule.
	 * @private
	 */
	doScheduleDeselect: function() {
		this.selectedRecord = null;
		selectedRecordItem = null;
		this.setActionsByGridMode(false);
		var view = this.getView();
		view.removeActionButton("actionStatus");
	},

	/**
	 * Deselects all items.
	 * @private
	 */
	deselectAll: function() {
		var grid = this.getGrid();
		if (!(grid instanceof Ext.Component)) {
			return;
		}
		grid.deselectAll();
	},

	/**
	 * Запускает импорт если необходимо
	 * @param {Date | undefined} startDate Начало периода
	 * @param {Date | undefined} dueDate Конец периода
	 * @private
	 */
	runImportIfNeeded: function(startDate, dueDate) {
		const isHybridMode = BPMSoft.FeatureUtils.isHybridMode();
		if (!isHybridMode){
			return;
		}
		var importHelper = this.getImportHelper(this.profileData.ownerId);
		const period = this.getIsSchedule()
			? this.getGrid().getPeriod()
			: this.getDatePeriod()._date;
		var importConfig = {};
		if (!this.firstImportFinished) {
			if (Ext.os.is.Phone) {
				importHelper.importByPeriod({
					startDate: BPMSoft.Date.add(period.start, Ext.Date.DAY, -1),
					dueDate: BPMSoft.Date.add(period.start, Ext.Date.DAY, 1),
					importDetails: false,
					disablePeriodCache: true,
					modelColumns: this.getMainColumnNames()
				});
				importConfig.isMain = false;
			}
			var newPeriod = this.getStartWeekPeriod(period.start, 14);
			startDate = newPeriod.startDate;
			dueDate = newPeriod.dueDate;
		}  else {
			if (!startDate || !dueDate) {
				startDate = period.start;
				dueDate = period.due;
			}
		}
		importConfig.startDate = startDate;
		importConfig.dueDate = dueDate;
		importHelper.importByPeriod(importConfig);
	},

	/**
	 * @private
	 */
	reRunImport: function() {
		this.firstImportFinished = false;
		this.destroyImportHelper();
		this.runImportIfNeeded();
	},

	/**
	 * @private
	 */
	destroyImportHelper: function() {
		if (this.importHelper) {
			this.importHelper.destroy();
			this.importHelper = null;
		}
	},

	/**
	 * @private
	 */
	getCurrentPeriod: function() {
		var store = this.getStore();
		var initialFilters = store.getFilters();
		if (initialFilters) {
			var startDateFilter = initialFilters.findSubfilterByName("StartDateFilter").filter;
			var dueDateFilter = initialFilters.findSubfilterByName("DueDateFilter").filter;
			return {
				start: dueDateFilter.getValue(),
				due: startDateFilter.getValue()
			};
		} else {
			return null;
		}

	},

	/**
	 * @private
	 */
	shouldChangePeriod: function(startDate, dueDate) {
		var currentPeriod = this.getCurrentPeriod();
		if (currentPeriod) {
			return BPMSoft.Date.areDatesEqual(startDate, currentPeriod.start) ||
				BPMSoft.Date.areDatesEqual(dueDate, currentPeriod.due) || (startDate < currentPeriod.start) ||
				(dueDate > currentPeriod.due);
		} else {
			return true;
		}
	},

	/**
	 * @private
	 */
	runExportIfNeeded: function(callback) {
		if (BPMSoft.FeatureUtils.isHybridMode()) {
			BPMSoft.SyncManager.runExport({
				success: callback,
				failure: callback,
				scope: this
			}, {priority: BPMSoft.SyncPriority.Maximum});
		} else {
			Ext.callback(callback, this);
		}
	},

	/**
	 * @private
	 */
	getProxyName: function() {
		const isHybridMode = BPMSoft.FeatureUtils.isHybridMode();
		if (isHybridMode){
			return BPMSoft.Proxies.SQLite;
		} else if (this.isDataServiceSupported()) {
			return BPMSoft.Proxies.DataService;
		} else {
			return BPMSoft.DataUtils.getProxyName(undefined, this.self.Model);
		}
	},

	/**
	 * @private
	 */
	subscribeSyncManagerEvents: function() {
		BPMSoft.SyncManager.on("syncstart", this.onSynchronizationStarted, this);
		BPMSoft.SyncManager.on("syncfinish", this.onSynchronizationFinished, this);
		BPMSoft.SyncManager.on("syncfailed", this.onSynchronizationFailed, this);
	},

	/**
	 * @private
	 */
	unsubscribeSyncManagerEvents: function() {
		BPMSoft.SyncManager.un("syncstart", this.onSynchronizationStarted, this);
		BPMSoft.SyncManager.un("syncfinish", this.onSynchronizationFinished, this);
		BPMSoft.SyncManager.un("syncfailed", this.onSynchronizationFailed, this);
	},

	/**
	 * @private
	 */
	formatLastSyncDateMessage: function(lastSyncDate) {
		if (BPMSoft.util.isEmptyDate(lastSyncDate)) {
			return "";
		}
		var lastSyncDateFormatted = Ext.Date.format(lastSyncDate, BPMSoft.Date.getDateTimeFormat());
		return Ext.String.format("{0} {1}", BPMSoft.LS.ActivityGridPageLastSyncDateMessage, lastSyncDateFormatted);
	},

	/**
	 * @private
	 */
	getActivityImportLastSyncDate: function(callback) {
		BPMSoft.MobileProfileManager.loadData({
			key: "ActivityImportLastSyncDate",
			success: function(profileData) {
				if (profileData) {
					var lastSyncDateStr = Ext.JSON.decode(profileData.get("Value"), true);
					var lastSyncDate = !Ext.isEmpty(lastSyncDateStr) ? new Date(lastSyncDateStr) : null;
					Ext.callback(callback, this, [lastSyncDate]);
				} else {
					Ext.callback(callback, this);
				}
			},
			failure: function() {
				Ext.callback(callback, this);
			},
			scope: this
		});
	},

	/**
	 * @private
	 */
	hideStateInformationPanel: function() {
		var view = this.getView();
		view.hideStateInformationPanel(true);
	},

	/**
	 * @private
	 */
	getInformationPanelRefreshButtonConfig: function() {
		return {
			text: BPMSoft.LS.ActivityGridPageInformationPanelRefreshButtonText,
			cls: "cf-information-panel-refresh-button",
			iconCls: "ts-refresh-orange-icon",
			listeners: {
				tap: this.onInformationPanelRefreshButtonTap,
				scope: this
			}
		};
	},

	//endregion

	//region Methods: Protected

	/**
	 * @protected
	 */
	getEmployeePicker: function() {
		if (this.employeePicker) {
			return this.employeePicker;
		}
		var employeeStore = Ext.create("BPMSoft.store.BaseStore", {
			model: "Contact"
		});
		employeeStore.on("beforeload", this.onBeforeEmployeeStoreLoad, this);
		var defaultImageUrl = BPMSoft.Configuration.getDefaultOwnerImage();
		var employeePicker = this.employeePicker = Ext.create("Ext.BPMSoft.LookupPicker", {
			markerValue: BPMSoft.LocalizableStrings.ActivityGridPageActionsPickerOwnerGroup + "_selectPicker",
			component: {
				store: employeeStore,
				primaryColumn: "Name",
				secondaryColumn: "Account",
				imageColumn: "Photo.PreviewData",
				defaultImage: defaultImageUrl,
				listeners: {
					scope: this,
					select: this.onEmployeePickerSelect
				}
			},
			toolbar: {
				clearButton: false
			},
			title: BPMSoft.LocalizableStrings.ActivityGridPageActionsPickerOwnerGroup,
			popup: true
		});
		var filterPanel = employeePicker.getFilterPanel();
		filterPanel.on("filterchange", this.onEmployeePickerFilterChange, this);
		filterPanel.addModule({
			xtype: BPMSoft.FilterModuleTypes.Search,
			filterColumnNames: ["Name"],
			name: "LookupSearch",
			component: {
				markerValue: "lookupSearchFilter"
			}
		});
		return employeePicker;
	},

	/**
	 * Returns main column names for importing models.
	 * @return {Object} Object with model names and their arrays of columns.
	 */
	getMainColumnNames: function() {
		return {
			Activity: ["Title", "DueDate", "StartDate", "Status", "ShowInScheduler", "Owner", "Type"]
		};
	},

	/**
	 * @protected
	 */
	getIsSchedule: function() {
		return this.isSchedule;
	},

	/**
	 * @protected
	 */
	getImportHelper: function(participantId) {
		if (this.importHelper && this.importHelper.getParticipantId() !== participantId) {
			this.destroyImportHelper();
		}
		if (!this.importHelper) {
			this.importHelper = Ext.create("BPMSoft.configuration.ActivityImportHelper", {
				participantId: participantId,
				additionalDays: 0,
				activityFilters: this.getFilters()
			});
			this.importHelper.on("imported", this.onActivityImported, this);
			this.importHelper.on("finish", this.onActivityImportFinished, this);
			this.importHelper.on("start", this.onActivityImportStarted, this);
		}
		return this.importHelper;
	},

	/**
	 * @protected
	 * @virtual
	 */
	initializeView: function(view) {
		view.initializedByController = true;
		this.callParent(arguments);
	},

	/**
	 * @protected
	 * @virtual
	 */
	initializeGrid: function(gridView) {
		Ext.Viewport.on("orientationchange", this.onOrientationChange, this);
		BPMSoft.Application.on("resume", this.onResume, this);
		this.initializeNavigationPanel();
		this.initializeNavigationPanelTitle();
		if (BPMSoft.FeatureUtils.isHybridMode()) {
			this.initializePageState();
		} else if (BPMSoft.ApplicationUtils.isOnlineMode()) {
			this.initializeRefreshButton();
		}
		this.initializePeriodSegmentedButton();
		this.updatePeriodFilter();
		var isSchedule = this.getIsSchedule();
		if (isSchedule) {
			this.initializeSchedule(gridView);
		}
		this.callParent(arguments);
	},

	/**
	 * @protected
	 * @virtual
	 */
	initializeSchedule: function(schedule) {
		var datePeriod = this.getDatePeriod();
		var date = datePeriod.getDate();
		if (Ext.os.is.Phone) {
			var showWeekRow = this.shouldShowWeekRow();
			schedule.setWeekRowHidden(!showWeekRow);
		}
		schedule.setPreRenderedDaysCount(function() {
			return 7;
		});
		schedule.setPeriod({
			start: date.start,
			due: date.due
		});
		var store = schedule.getStore();
		store.on({
			scope: this,
			removerecords: this.onStoreRemoveRecords
		});
		var eventHandlers = {
			scope: this,
			gridareatap: this.onScheduleGridAreaTap,
			createrecordwithvalues: this.onScheduleCreateRecordWithValues,
			deselect: this.onScheduleDeselect,
			timescalechange: this.onScheduleTimeScaleChange,
			visibleperiodchanged: this.onScheduleVisiblePeriodChanged,
			scrollchange: this.onScheduleScrollChange,
			itemhold: this.onScheduleItemHold
		};
		if (!Ext.os.is.Phone) {
			eventHandlers.itemvaluechange = this.onScheduleItemValueChange;
			eventHandlers.itemhold = this.onScheduleItemHold;
		}
		schedule.on(eventHandlers);
	},

	/**
	 * @protected
	 * @virtual
	 */
	initializeOwnerButton: function() {
		var view = this.getView();
		view.setOwnerButton(true);
		if (BPMSoft.ApplicationUtils.isOnlineMode()) {
			var ownerButton = view.getOwnerButton();
			ownerButton.on("tap", this.onOwnerButtonTap, this);
		}
		this.setViewOwnerButtonImage(this.profileData.ownerId);
	},

	/**
	 * @protected
	 * @virtual
	 */
	initializeRefreshButton: function() {
		var isSchedule = this.getIsSchedule();
		var view = this.getView();
		view.setRefreshButton(isSchedule);
		if (isSchedule) {
			var refreshButton = view.getRefreshButton();
			refreshButton.on("tap", this.onRefreshButtonTap, this);
		}
	},

	/**
	 * @protected
	 * @virtual
	 */
	initializePageState: function() {
		var isDetail = this.isDetail();
		if (!isDetail) {
			var state = this.getIsSchedule() ? BPMSoft.PageState.Default : BPMSoft.PageState.None;
			this.subscribeSyncManagerEvents();
			var view = this.getView();
			view.setState(state);
		}
	},

	/**
	 * @protected
	 * @virtual
	 */
	initializePeriodFilter: function() {
		var periodFilterComponent = this.getViewActivityPeriodFilterComponent();
		if (!periodFilterComponent) {
			return;
		}
		periodFilterComponent.on("periodchanged", this.onPeriodFilterChange, this, null, "before");
		periodFilterComponent.setValidateFn(this.validateCalendarDatePeriod.bind(this));
		periodFilterComponent.setScrollingDatesFn(this.getCalendarScrollingDates.bind(this));
		var calendarPickerConfig = periodFilterComponent.getCalendarPickerConfig();
		Ext.merge(calendarPickerConfig, {
			listeners: {
				initialize: this.onCalendarPickerInitialize,
				scope: this
			}
		});
		var datePeriod = this.getDatePeriod();
		datePeriod.on("change", this.onDatePeriodChange, this);
	},

	/**
	 * @protected
	 * @virtual
	 */
	initializeNavigationPanelTitle: function() {
		var isSchedule = this.getIsSchedule();
		var title = isSchedule ? BPMSoft.LocalizableStrings.ActivityGridPageV2ScheduleTitle : this.getTitle();
		if (title) {
			var view = this.getView();
			var navigationPanel = view.getNavigationPanel();
			navigationPanel.setTitle(title);
			navigationPanel.updateTitle();
		}
	},

	/**
	 * @protected
	 * @virtual
	 */
	initializeNavigationPanel: function() {
		if (this.isDetail()) {
			return;
		}
		var view = this.getView();
		var navigationPanel = view.getNavigationPanel();
		var title = navigationPanel.getTitle();
		title.addCls("cf-multi-modes");
		title.element.on("tap", this.onTitleElementTap, this);
	},

	/**
	 * @protected
	 * @virtual
	 */
	initializePeriodSegmentedButton: function() {
		var showPeriodSegmentedButton = this.getIsSchedule();
		var view = this.getView();
		view.setPeriodSegmentedButton(showPeriodSegmentedButton);
		if (showPeriodSegmentedButton) {
			var periodSegmentedButton = view.getPeriodSegmentedButton();
			var schedulePeriod = this.getSchedulePeriod();
			var currentButton = periodSegmentedButton.getComponent(schedulePeriod);
			var pressedCls = periodSegmentedButton.getPressedCls();
			currentButton.addCls(pressedCls);
			var pressedButtons = periodSegmentedButton.getPressedButtons();
			pressedButtons.push(currentButton);
			periodSegmentedButton.on("toggle", this.onPeriodSegmentedButtonToggle, this);
		}
	},

	/**
	 * Initializes loaded profile data.
	 * @protected
	 * @virtual
	 * @param {Object} profileData Profile data.
	 */
	initializeActivityProfileData: function(profileData) {
		var currentDate = new Date();
		if (profileData) {
			profileData = Ext.JSON.decode(profileData.get("Value"), true);
			var lastDisplayedDate = new Date(profileData.lastDisplayedDate || currentDate);
			if (!BPMSoft.Date.areDatesEqual(lastDisplayedDate, currentDate)) {
				profileData.period = null;
			}
		} else {
			profileData = {};
		}
		profileData.lastDisplayedDate = currentDate;
		return profileData;
	},

	/**
	 * @protected
	 * @virtual
	 */
	initializeViewByProfileData: function(profileData) {
		var view = this.getView();
		if (!profileData.ownerId) {
			profileData.ownerId = BPMSoft.CurrentUserInfo.contactId;
		}
		var config = this.getGrid();
		var gridConfig = this.getInitialGridConfig(config);
		var xtype = gridConfig.xtype;
		this.setIsScheduleByXtype(xtype);
		this.updatePeriodFilterDateFormat();
		this.initializePeriodFilter();
		this.initializeOwnerButton();
		this.updateNavigationPanel();
		this.updateDatePeriod();
		view.setGrid(gridConfig);
		this.initializeQueryConfig();
		this.updateFilterPanel();
	},

	/**
	 * @protected
	 * @virtual
	 */
	getInitialGridConfig: function(config) {
		config = config || {};
		var profileData = this.profileData || {};
		if (profileData.gridMode) {
			config.xtype = profileData.gridMode;
		}
		var isSchedule = this.getIsScheduleByXtype(config.xtype);
		if (isSchedule) {
			if (profileData.scheduleTimeScale) {
				config.timeScale = profileData.scheduleTimeScale;
			}
			var changeOperations = this.getChangeModeOperations();
			if (!config.columnsBindingConfig) {
				config.columnsBindingConfig = {};
			}
			if (!changeOperations.canUpdate) {
				config.columnsBindingConfig.readOnly = function() {
					return true;
				};
			}
			config.enableHorizontalScrolling = true;
			var currentDate = new Date();
			config.startHour = currentDate.getHours();
			config.columnsBindingConfig.status = function(record) {
				var statusRecord = record.get("Status");
				if (statusRecord && !Ext.isObject(statusRecord)) {
					statusRecord = ActivityStatus.Store.getById(statusRecord);
					record.set("Status", statusRecord);
				}
				if (statusRecord && statusRecord.get("Id") === BPMSoft.Configuration.ActivityStatus.Canceled) {
					return BPMSoft.ScheduleItemStatus.Canceled;
				} else if (record.get("Status.Finish")) {
					return BPMSoft.ScheduleItemStatus.Done;
				} else if (record.get(this.endDateColumnName) < new Date()) {
					return BPMSoft.ScheduleItemStatus.Overdue;
				} else {
					return BPMSoft.ScheduleItemStatus.New;
				}
			}.bind(this);
		}
		config.store = this.getStoreConfig();
		return config;
	},

	/**
	 * Returns store config or store class name.
	 * @protected
	 * @virtual
	 * @return {Object|String} Store config or store class name.
	 */
	getStoreConfig: function() {
		if (BPMSoft.FeatureUtils.isHybridMode()) {
			return Ext.create("BPMSoft.store.BaseStore", {
				model: "Activity",
				autoSetProxy: false,
				autoDestroy: true,
				destroyRemovedRecords: false
			});
		} else {
			return "BPMSoft.configuration.store.ActivityGridPage";
		}
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	getAnalyticsEventProperties: function() {
		var eventConfig = this.callParent(arguments);
		if (eventConfig.eventName === BPMSoft.AnalyticsManagerEventNames.Open) {
			var additionalInfo = {
				isSchedule: this.getIsSchedule()
			};
			if (additionalInfo.isSchedule) {
				var schedulePeriod = this.getSchedulePeriod();
				additionalInfo.schedulePeriod = BPMSoft.Object.getKeyByValue(
					BPMSoft.Configuration.ActivitySchedulePeriods, schedulePeriod);
			}
			eventConfig.properties.additionalInfo = JSON.stringify(additionalInfo);
		}
		return eventConfig;
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	initializeQueryConfig: function() {
		this.callParent(arguments);
		var gridQueryConfig = this.getQueryConfig();
		gridQueryConfig.addColumns(this.startDateColumnName, this.endDateColumnName);
		if (BPMSoft.FeatureUtils.isHybridMode()) {
			gridQueryConfig.setIsBatch(false);
		}
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	applyExtendedFilters: function() {
		var view = this.getView();
		if (this.getIsSchedule()) {
			view.hideResultPanel();
		} else {
			this.callParent(arguments);
		}
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	getIsExtendedFiltersColumnAvailable: function(columnName) {
		if (!this.isDetail() && (columnName === this.startDateColumnName || columnName === this.endDateColumnName)) {
			return false;
		} else {
			return this.callParent(arguments);
		}
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	openPreviewPage: function(recordId, modelName, previewConfig) {
		var args = Array.prototype.slice.call(arguments);
		if (BPMSoft.FeatureUtils.isHybridMode()) {
			args[2] = Ext.merge({
				proxy: this.getProxyName()
			}, previewConfig);
		}
		this.callParent(args);
	},

	/**
	 * @protected
	 * @virtual
	 */
	onCalendarPickerInitialize: function(picker) {
		var view = this.getView();
		var toolbar = picker.getToolbar();
		var todayButton = view.createTodayButton();
		todayButton.on("tap", this.onTodayButtonTap, this);
		toolbar.insert(0, todayButton);
	},

	/**
	 * @protected
	 * @virtual
	 */
	onTodayButtonTap: function(button) {
		var toolbar = button.getParent();
		var picker = toolbar.getParent();
		var calendarComponent = picker.getComponent();
		var currentDate = new Date();
		calendarComponent.setPeriod({from: currentDate, to: currentDate});
		calendarComponent.fireEvent("dateselected");
		BPMSoft.AnalyticsManager.trackEvent({
			eventName: BPMSoft.AnalyticsManagerEventNames.Tap,
			properties: {
				control: "schedule-settoday"
			}
		});
	},

	/**
	 * @protected
	 * @virtual
	 */
	onPeriodFilterChange: function() {
		var datePeriod = this.getDatePeriod();
		var period = datePeriod.getPeriod();
		if (!Ext.isEmpty(period)) {
			this.profileData.period = period;
		} else {
			var date = datePeriod.getDate();
			this.profileData.period = {
				startDate: date.start,
				dueDate: date.due
			};
		}
		this.saveActivityProfileData();
	},

	/**
	 * @protected
	 * @virtual
	 */
	onDatePeriodChange: function(datePeriod, date) {
		var grid = this.getGrid();
		if (!(grid instanceof Ext.Component)) {
			return;
		}
		var isSchedule = this.getIsSchedule();
		if (isSchedule) {
			if (Ext.os.is.Phone){
				var showWeekRow = this.shouldShowWeekRow();
				grid.setWeekRowHidden(!showWeekRow);
			}
			grid.setPeriod({
				start: date.start,
				due: date.due
			});
		}

		if (this.shouldChangePeriod(date.start, date.due)) {
			this.loadStore();
		}
		this.runImportIfNeeded(date.start, date.due);
	},

	/**
	 * @protected
	 * @virtual
	 */
	onRefreshButtonTap: function() {
		BPMSoft.AnalyticsManager.trackEvent({
			eventName: BPMSoft.AnalyticsManagerEventNames.Tap,
			properties: {
				control: "scheduler-refresh-button"
			}
		});
		this.refreshDirtyData();
	},

	/**
	 * @protected
	 * @virtual
	 */
	isSyncFinished: function() {
		var isImportFinished = !this.importHelper || !this.importHelper.hasActiveProcesses();
		return !BPMSoft.SyncManager.hasActiveSyncOperations() && isImportFinished;
	},

	/**
	 * @protected
	 * @virtual
	 */
	isMainSyncFinished: function() {
		var isMainImportFinished = !this.importHelper || !this.importHelper.hasActiveMainProcesses();
		return !BPMSoft.SyncManager.hasActiveSyncOperations(BPMSoft.SyncRunType.Export) && isMainImportFinished;
	},

	/**
	 * @protected
	 * @virtual
	 */
	setDefaultState: function() {
		this.setState(BPMSoft.PageState.Default);
	},

	/**
	 * @protected
	 * @virtual
	 */
	onSynchronizationStarted: function(syncManager, queueItem) {
		if (queueItem.getRunType() === BPMSoft.SyncRunType.Export) {
			this.setState(BPMSoft.PageState.DataLoading);
		}
	},

	/**
	 * @protected
	 * @virtual
	 */
	onActivityImportStarted: function() {
		this.setState(BPMSoft.PageState.DataLoading);
	},

	/**
	 * @protected
	 * @virtual
	 */
	onActivityImported: function(config) {
		if (config.isMain) {
			this.firstImportFinished = true;
			if (this.isMainSyncFinished()) {
				this.setDefaultState();
			}
		}
		if (config.isDataChanged) {
			this.loadStore();
		}
	},

	/**
	 * @protected
	 * @virtual
	 */
	onActivityImportFinished: function() {
	},

	/**
	 * @protected
	 * @virtual
	 */
	onSynchronizationFinished: function(syncManager, syncQueueItem) {
		if (syncQueueItem && syncQueueItem.getRunType() === BPMSoft.SyncRunType.Export) {
			this.hasExportConflicts = false;
		}
		if (this.isMainSyncFinished()) {
			this.setDefaultState();
		}
	},

	/**
	 * @protected
	 * @virtual
	 */
	onSynchronizationFailed: function(syncManager, syncQueueItem, exception) {
		if (exception instanceof BPMSoft.NoInternetConnectionException) {
			this.setState(BPMSoft.PageState.NoConnection);
		} else if (exception instanceof BPMSoft.ServiceUnavailableException) {
			this.setState(BPMSoft.PageState.ServiceUnavailable, {
				exception: exception
			});
		} else {
			this.hasExportConflicts = exception instanceof BPMSoft.DataExportException;
			this.setState(BPMSoft.PageState.DataLoadingError, {
				exception: exception
			});
		}
	},

	/**
	 * @protected
	 * @virtual
	 */
	onResume: function() {
		this.reRunImport();
	},

	/**
	 * @protected
	 * @virtual
	 */
	onOrientationChange: function() {
		this.updatePeriodFilterDateFormat();
		this.updateNavigationPanel();
		this.updateDatePeriod();
	},

	/**
	 * @protected
	 * @virtual
	 */
	onScheduleCreateRecordWithValues: function(schedule, values) {
		this.executeAddAction(values);
	},

	/**
	 * @protected
	 * @virtual
	 */
	onScheduleItemValueChange: function(record, columns, operation) {
		var pageHistoryItem = this.getPageHistoryItem();
		var operationConfig = BPMSoft.util.getOperationConfigByOperation(operation, columns);
		BPMSoft.PageNavigator.refreshAllPages(operationConfig, pageHistoryItem);
	},

	/**
	 * @protected
	 * @virtual
	 */
	onScheduleGridAreaTap: function() {
		var self = this;
		var backPromiseFn = function() {
			return new Promise(function(resolve) {
				if (BPMSoft.PageNavigator.getLastPageController() !== self) {
					return BPMSoft.Router.back().then(resolve);
				}
			});
		};
		var result = Promise.resolve();
		for (var i = 0, ln = BPMSoft.PageHistory.getAllItems().length; i < ln; i++) {
			result = result.then(backPromiseFn);
		}
	},

	/**
	 * @protected
	 * @virtual
	 */
	onScheduleScrollChange: function(schedule, scroller) {
		var direction = scroller.getDirection();
		if (direction === "vertical") {
			return;
		}
		var period = schedule.getPeriodByScrollPosition();
		var currentScrollPositionDate = period.start;
		var currentDisplayDate = this.currentDisplayDate;
		if (!currentDisplayDate) {
			var currentDisplayPeriod = schedule.getPeriod();
			currentDisplayDate = currentDisplayPeriod.start;
		}
		if (!BPMSoft.Date.areDatesEqual(currentDisplayDate, currentScrollPositionDate)) {
			this.currentDisplayDate = currentScrollPositionDate;
			var periodFilterComponent = this.getViewActivityPeriodFilterComponent();
			periodFilterComponent.updatePeriodHtml(currentScrollPositionDate, period.due);
		}
	},

	/**
	 * @protected
	 * @virtual
	 */
	onScheduleTimeScaleChange: function(schedule, timeScale) {
		this.refreshDirtyData();
		this.profileData.scheduleTimeScale = timeScale;
		this.saveActivityProfileData();
	},

	/**
	 * @protected
	 * @virtual
	 */
	onScheduleVisiblePeriodChanged: function(schedule, startDate, dueDate) {
		this.profileData.period = {
			startDate: startDate,
			dueDate: dueDate
		};
		var datePeriod = this.getDatePeriod();
		var isChanged = datePeriod.setDate({
			start: startDate,
			due: dueDate
		}, true);
		if (isChanged) {
			var date = datePeriod.getDate();
			if (this.shouldChangePeriod(date.start, date.due)) {
				var grid = this.getGrid();
				grid.setPeriod({
					start: date.start,
					due: date.due
				});
				this.loadStore();
			}
			this.runImportIfNeeded(date.start, date.due);
		}
		this.scheduleActiveDate = startDate;
		this.saveActivityProfileData();
	},

	/**
	 * @protected
	 * @virtual
	 */
	onTitleElementTap: function(event) {
		var gridModePicker = this.getGridModePicker();
		if (!gridModePicker.getParent()) {
			Ext.Viewport.add(gridModePicker);
		}
		gridModePicker.show();
		event.stopEvent();
	},

	/**
	 * @protected
	 * @virtual
	 */
	onOwnerButtonTap: function(buttonElement, event) {
		event.stopEvent();
		BPMSoft.AnalyticsManager.trackEvent({
			eventName: BPMSoft.AnalyticsManagerEventNames.Tap,
			properties: {
				control: "scheduler-change-owner-button"
			}
		});
		this.showEmployeePicker();
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	onFilterChange: function() {
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	onStateButtonTap: function(view, state) {
		if (state === BPMSoft.PageState.NoConnection) {
			this.showNoConnectionStateInformationPanel();
		} else if (state === BPMSoft.PageState.ServiceUnavailable) {
			this.showServiceUnavailableStateInformationPanel();
		} else if (state === BPMSoft.PageState.DataLoadingError) {
			if (this.hasExportConflicts) {
				this.showExportErrorInformationPanel();
			} else {
				if (this.stateData.exception instanceof BPMSoft.AuthenticationException) {
					BPMSoft.Application.handleAuthenticationFailure({
						showMessage: true
					});
				} else {
					BPMSoft.MessageBox.showException(this.stateData.exception);
				}
			}
		} else if (state === BPMSoft.PageState.DataLoading) {
			this.showDataLoadingInformationPanel();
		} else if (state === BPMSoft.PageState.Default) {
			this.showDataLoadedInformationPanel();
		} else {
			this.callParent(arguments);
		}
	},

	/**
	 * Called when refresh data button of information panel has been tapped.
	 * @protected
	 * @virtual
	 */
	onInformationPanelRefreshButtonTap: function() {
		this.autoShowNoConnectionStatusPanel = true;
		var view = this.getView();
		view.hideStateInformationPanel();
		if (BPMSoft.SyncManager.hasSyncOperations()) {
			BPMSoft.SyncManager.reRunSync();
		} else {
			this.runImportIfNeeded();
		}
	},

	/**
	 * Called when export conflicts detail button of state panel has been tapped.
	 * @protected
	 * @virtual
	 */
	onExportErrorDetailsButtonTap: function() {
		var view = this.getView();
		view.hideStateInformationPanel(false);
		BPMSoft.util.openPage({
			controllerName: "BPMSoft.controller.MobileSyncLogPage",
			viewXClass: "BPMSoft.view.MobileSyncLogPage"
		});
	},

	/**
	 * Called when close button of "NoConnection" state panel has been tapped.
	 * @protected
	 * @virtual
	 */
	onNoConnectionPanelCloseButtonTap: function() {
		this.autoShowNoConnectionStatusPanel = false;
	},

	/**
	 * Shows information panel for state "NoConnection".
	 * @protected
	 * @virtual
	 */
	showNoConnectionStateInformationPanel: function() {
		this.getActivityImportLastSyncDate(function(lastSyncDate) {
			var view = this.getView();
			var lastSyncDateMessage = this.formatLastSyncDateMessage(lastSyncDate);
			var panel = view.createStateInformationPanel(BPMSoft.PageState.NoConnection, {
				message: BPMSoft.LS.ActivityGridPageNoConnectionStateMessage,
				additionalMessage: lastSyncDateMessage,
				buttons: [this.getInformationPanelRefreshButtonConfig()]
			});
			var closeButton = panel.getCloseButton();
			closeButton.on("tap", this.onNoConnectionPanelCloseButtonTap, this);
			view.showStateInformationPanel(panel);
		});
	},

	/**
	 * Shows information panel for state "ServiceUnavailable".
	 * @protected
	 * @virtual
	 */
	showServiceUnavailableStateInformationPanel: function() {
		this.getActivityImportLastSyncDate(function(lastSyncDate) {
			var view = this.getView();
			var lastSyncDateMessage = this.formatLastSyncDateMessage(lastSyncDate);
			var panel = view.createStateInformationPanel(BPMSoft.PageState.ServiceUnavailable, {
				message: this.stateData.exception.getMessage(),
				additionalMessage: lastSyncDateMessage,
				buttons: [this.getInformationPanelRefreshButtonConfig()]
			});
			view.showStateInformationPanel(panel);
		});
	},

	/**
	 * Shows information panel for state "DataLoadingError", if error occurs while exporting.
	 * @protected
	 * @virtual
	 */
	showExportErrorInformationPanel: function() {
		var view = this.getView();
		var panel = view.createStateInformationPanel(BPMSoft.PageState.DataLoadingError, {
			message: BPMSoft.LS.ActivityGridPageExportErrorMessage,
			buttons: [
				{
					text: BPMSoft.LS.ActivityGridPageExportErrorMoreButtonText,
					cls: "cf-export-error-details-button",
					iconCls: "ts-info-blue-icon",
					listeners: {
						tap: this.onExportErrorDetailsButtonTap,
						scope: this
					}
				}
			]
		});
		view.showStateInformationPanel(panel);
	},

	/**
	 * Shows information panel for state "DataLoading".
	 * @protected
	 * @virtual
	 */
	showDataLoadingInformationPanel: function() {
		var view = this.getView();
		var panel = view.createStateInformationPanel(BPMSoft.PageState.DataLoading, {
			message: BPMSoft.LS.ActivityGridPageDataLoadingMessage
		});
		view.showStateInformationPanel(panel);
	},

	/**
	 * Shows information panel for state "Default".
	 * @protected
	 * @virtual
	 */
	showDataLoadedInformationPanel: function() {
		this.getActivityImportLastSyncDate(function(lastSyncDate) {
			var view = this.getView();
			var lastSyncDateMessage = this.formatLastSyncDateMessage(lastSyncDate);
			var panel = view.createStateInformationPanel(BPMSoft.PageState.Default, {
				message: BPMSoft.LS.ActivityGridPageDataLoadedMessage,
				additionalMessage: lastSyncDateMessage
			});
			view.showStateInformationPanel(panel);
		});
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	setState: function(state, stateData) {
		if (!this.getIsSchedule()) {
			return;
		}
		if (this.hasExportConflicts && state === BPMSoft.PageState.Default) {
			state = BPMSoft.PageState.DataLoadingError;
		} else {
			this.stateData = stateData;
		}
		if (state !== BPMSoft.PageState.DataLoading && state !== BPMSoft.PageState.NoConnection) {
			this.autoShowNoConnectionStatusPanel = false;
		}
		this.callParent(arguments);
		if (state === BPMSoft.PageState.NoConnection && this.autoShowNoConnectionStatusPanel) {
			this.showNoConnectionStateInformationPanel();
		}
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	getIsExtendedFiltersEnabled: function() {
		return ((this.getIsSchedule() === false) || this.isDetail()) &&
			BPMSoft.Features.getIsEnabled("UseMobileQuickFilters");
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	executeAddAction: function(values) {
		var changeOperations = this.getChangeModeOperations();
		if (!changeOperations.canCreate) {
			return;
		}
		if (!values) {
			values = {};
		}
		var lastPageController = BPMSoft.PageNavigator.getLastPageController();
		if (lastPageController instanceof BPMSoft.controller.BaseEditPage || this.tmpGridRecord) {
			return;
		}
		if (this.isDetail()) {
			var detailConfig = this.getDetailConfig();
			var parentRecord = detailConfig.parentRecord;
			values[detailConfig.parentColumnName] = parentRecord;
			var account = parentRecord.get("Account");
			if (account && account instanceof BPMSoft.model.BaseModel) {
				values.Account = account;
			}
		}
		this.createRecordWithDefaultValues(values, function(newRecord) {
			if (this.getIsSchedule()) {
				var schedule = this.getGrid();
				var store = schedule.getStore();
				store.add(newRecord);
				schedule.select(newRecord);
				this.tmpGridRecord = newRecord;
			}
			BPMSoft.util.openEditPage(this.self.Model, {isCopy: true, newRecord: newRecord});
		});
	},

	/**
	 * Creates record with default values.
	 * @protected
	 * @virtual
	 */
	createRecordWithDefaultValues: function(values, callback) {
		BPMSoft.Mask.show();
		var config = {
			isCancelable: true,
			cancellationId: this.getCancellationId("activityCreateRecordWithDefaultValues")
		};
		this.self.Model.createWithDefaultValues(function(newRecord) {
			for (var column in values) {
				if (values.hasOwnProperty(column)) {
					newRecord.set(column, values[column]);
				}
			}
			Ext.callback(callback, this, [newRecord]);
			BPMSoft.Mask.hide();
		}, function(exception) {
			BPMSoft.MessageBox.showException(exception);
			BPMSoft.Mask.hide();
		}, this, config);
	},

	/**
	 * Selects record.
	 * @protected
	 * @virtual
	 * @param {Activity} record Instance of Activity.
	 * @param isItemHold
	 */
	selectRecord: function(record, isItemHold) {
		if (record !== this.tmpGridRecord) {
			this.removeTmpGridRecord();
		}
		if (record.phantom) {
			return;
		}
		var recordId = record.getId();
		var currentController = BPMSoft.PageNavigator.getLastPageController();
		if (!this.selectedRecord && currentController === this) {
			if (BPMSoft.core.getUseOldCalendar()) {
				this.doSelectRecord(record);
			} else {
				if (!Ext.os.is.Phone) {
					if (record.data.Title === $('#titleCustomText').text()) {
						this.doSelectRecord(record);
					}
				}
				if (!isItemHold) {
					this.openPreviewPage(recordId);
				} else if (Ext.os.is.Phone) {
					this.doSelectRecord(record);
				}
			}
		} else if (this.selectedRecord) {
			if (!this.isRecordPageOpened(this.selectedRecord)) {
				if (record.data.Title !== $('#titleCustomText').text() || Ext.os.is.Phone) {
					this.deselectAll();
				}
				this.openPreviewPage(recordId);
			}
		} else {
			this.openPreviewPage(recordId);
			this.selectedRecord = record;
		}
	},

	/**
	 * Checks if record page is opened.
	 * @protected
	 * @param {Activity} record Instance of Activity.
	 * @return {Boolean} True, if record page is opened.
	 */
	isRecordPageOpened: function(record) {
		var currentController = BPMSoft.PageNavigator.getLastPageController();
		if (record && currentController instanceof BPMSoft.controller.BaseRecordPage) {
			var pageConfig = currentController.getPageConfig();
			return record.getId() === pageConfig.recordId;
		}
		return false;
	},

	/**
	 * Completes selecting of record.
	 * @protected
	 * @virtual
	 * @param {Activity} record Instance of Activity.
	 */
	doSelectRecord: function(record) {
		if (this.selectedRecord && record !== this.selectedRecord) {
			this.doScheduleDeselect();
		}
		var schedule = this.getGrid();
		var item = schedule.getItemByRecord(record);
		if (item) {
			var readOnly = item.getReadOnly();
			this.setActionsByGridMode(!readOnly);
			if (this.shouldAddStatusAction(record)) {
				this.addStatusActionButton(record);
			}
			this.selectedRecord = record;
		} else {
			this.deselectAll();
		}
	},

	/**
	 * Check, if status action should be added.
	 * @protected
	 * @virtual
	 * @param {Activity} record Instance of Activity.
	 * @returns {Boolean} True, if status action should be added
	 */
	shouldAddStatusAction: function(record) {
		var schedule = this.getGrid();
		var scheduleItem = schedule.getItemByRecord(record);
		return !scheduleItem.getReadOnly();
	},

	/**
	 * Add status action button.
	 * @protected
	 * @param {Activity} record Instance of Activity.
	 */
	addStatusActionButton: function(record) {
		var view = this.getView();
		var activityStatus = record.get("Status");
		var activityStatusId = (activityStatus instanceof BPMSoft.BaseModel) ? activityStatus.getId() : activityStatus;
		var isFinished = activityStatusId === BPMSoft.Configuration.ActivityStatus.Finished;
		var iconCls = isFinished ? "x-action-activity-notstarted" : "x-action-activity-finished";
		view.addActionButton("actionStatus", {
			iconCls: iconCls,
			listeners: {
				tap: this.onActivityStatusButtonTap,
				scope: this
			}
		});
	},

	/**
	 * Handles tap on item.
	 * @protected
	 * @virtual
	 * @param {Object} el Instance of Schedule/List object.
	 * @param {Number} index Index of item.
	 * @param {Object} item Schedule/List item.
	 * @param {Activity} record Instance of Activity.
	 */
	onItemTap: function(el, index, item, record) {
		var isSchedule = this.getIsSchedule();
		if (!isSchedule) {
			this.callParent(arguments);
		} else {
			this.selectRecord(record);
		}
	},

	/**
	 * Handles tap holding on item.
	 * @protected
	 * @virtual
	 * @param {Object} schedule Instance of Schedule object.
	 * @param {Activity} record Instance of Activity.
	 */
	onScheduleItemHold: function(schedule, record) {
		this.selectRecord(record, true);
	},

	/**
	 * @protected
	 * @virtual
	 */
	onActivityStatusButtonTap: function() {
		var selectedRecord = this.selectedRecord;
		if (!selectedRecord) {
			return;
		}
		var view = this.getView();
		var actionsPicker = view.getActionsPicker(false);
		if (actionsPicker) {
			actionsPicker.hide();
		}
		var activityStatusRecord = this.getOppositeActivityStatusRecord(this.selectedRecord);
		this.saveCurrentActivityWithStatus(activityStatusRecord);
	},

	/**
	 * @protected
	 * @virtual
	 */
	onScheduleDeselect: function() {
		this.doScheduleDeselect();
	},

	/**
	 * @protected
	 * @virtual
	 */
	onStoreRemoveRecords: function() {
		this.doScheduleDeselect();
	},

	/**
	 * @protected
	 * @virtual
	 */
	onGridModePickerSelect: function(el, record) {
		var data = record.getData();
		var actionType = data.Type;
		var grid = this.getGrid();
		if (!(grid instanceof Ext.Component)) {
			return;
		}
		var gridMode = grid.xtype;
		if (gridMode !== actionType) {
			this.deselectAll();
			if (actionType === BPMSoft.Configuration.ActivityGridModeTypes.List) {
				this.destroyImportHelper();
				var view = this.getView();
				view.setState(BPMSoft.PageState.None);
			}
			this.changeGridMode(actionType);
			BPMSoft.AnalyticsManager.trackEvent({
				eventName: BPMSoft.AnalyticsManagerEventNames.Tap,
				properties: {
					control: "activity-mode",
					itemId: actionType
				}
			});
		}
	},

	/**
	 * @protected
	 * @virtual
	 */
	onEmployeePickerSelect: function(el, record) {
		var recordId = record.getId();
		this.changeOwner(recordId);
	},

	/**
	 * @protected
	 * @virtual
	 */
	onEmployeePickerFilterChange: function() {
		var employeePicker = this.employeePicker;
		var filterPanel = employeePicker.getFilterPanel();
		var filters = filterPanel.getFilters();
		var store = employeePicker.getComponent().getStore();
		store.loadPage(1, {
			isCancelable: true,
			queryConfig: this.getEmployeeQueryConfig(),
			filters: filters,
			callback: function(records, operation, success) {
				if (!success) {
					BPMSoft.MessageBox.showException(operation.getError());
				}
			},
			scope: this
		});
	},

	/**
	 * @protected
	 * @virtual
	 */
	onCurrentUserButtonTap: function() {
		BPMSoft.AnalyticsManager.trackEvent({
			eventName: BPMSoft.AnalyticsManagerEventNames.Tap,
			properties: {
				control: "show-my-activities-button"
			}
		});
		this.employeePicker.hide();
		this.changeOwner(BPMSoft.CurrentUserInfo.contactId);
	},

	/**
	 * @protected
	 * @virtual
	 */
	onBeforeEmployeeStoreLoad: function(store, operation) {
		var filters = operation.getFilters();
		var defaultEmployeeFilter = this.getEmployeeStoreFilters();
		var recentOwners = this.getProfileRecentOwners();
		var employeeFilters = recentOwners.length > 0 ? this.getEmployeePickerStoreFilters() :
			defaultEmployeeFilter;
		if (filters && filters.getSubfilters() && filters.getSubfilters().length > 0) {
			if (filters.getName() !== "RecentOwners") {
				var groupFilters = Ext.create("BPMSoft.Filter", {
					type: BPMSoft.FilterTypes.Group
				});
				groupFilters.addFilter(filters);
				groupFilters.addFilter(defaultEmployeeFilter);
				filters = groupFilters;
				store.setProxy(BPMSoft.DataUtils.getOnlineProxy());
			}
		} else {
			filters = employeeFilters;
		}
		operation.setFilters(filters);
		operation.config.cancellationId = this.getCancellationId("loadEmployee");
		operation.config.queryConfig = this.getEmployeeQueryConfig();
	},

	/**
	 * Handler on action select.
	 * @protected
	 * @overridden
	 * @param {Object} actionConfig Action config.
	 * @param {String} actionConfig.name Action name.
	 */
	onActionSelected: function(actionConfig) {
		var record = this.selectedRecord;
		if (record) {
			switch (actionConfig.name) {
				case "copyActionMenu":
					BPMSoft.MobileActivityActionsUtilities.doCopyActivityAction({
						record: record,
						callback: this.finishCopyAction,
						scope: this,
						proxyType: this.getProxyType()
					});
					return;
				case "deleteActionMenu":
					BPMSoft.MobileActivityActionsUtilities.doDeleteActivityAction({
							record: record,
							callback: this.finishAction,
							scope: this,
							proxyType: this.getProxyType()
					});
					return;
				default:
					break;
			}
		}
		this.callParent(arguments);
	},

	/**
	 * Handler on view swipe right.
	 * @protected
	 * @virtual
	 * @param {Event} event Swipe event.
	 */
	onViewSwipeRight: function(event) {
		var target = event.target;
		if (!this.getIsSchedule() || this.isScheduleColumn(target)) {
			this.callParent(arguments);
		}
	},

	/**
	 * Handler on shedule swipe.
	 * @protected
	 * @virtual
	 * @param {Event} event Swipe event.
	 */
	onScheduleSwipe: function(event) {
		var direction = event.direction;
		var offset;
		if (direction === "right") {
			offset = -1;
		} else if (direction === "left") {
			offset = 1;
		} else {
			return;
		}
		var grid = this.getGrid();
		var selection = grid.getSelection();
		if (selection.length) {
			var item = grid.getItemByRecord(selection[0]);
			var target = event.target;
			if (item && item.element.dom.contains(target)) {
				return;
			}
		}
		var datePeriod = this.getDatePeriod();
		var date = datePeriod.getDate();
		var start = BPMSoft.Date.add(date.start, Ext.Date.DAY, offset);
		var due = BPMSoft.Date.add(date.due, Ext.Date.DAY, offset);
		this.profileData.period = {
			startDate: start,
			dueDate: due
		};
		this.updateDatePeriod();
		this.saveActivityProfileData();
	},

	/**
	 * @protected
	 * @virtual
	 */
	onPeriodSegmentedButtonToggle: function(segmentedButton, button, toggle) {
		if (!toggle) {
			return;
		}
		BPMSoft.AnalyticsManager.trackEvent({
			eventName: BPMSoft.AnalyticsManagerEventNames.Tap,
			properties: {
				control: "scheduler-period-segmented-button",
				itemId: button.getMarkerValue()
			}
		});
		this.profileData.schedulePeriod = button.getItemId();
		this.updateDatePeriod();
		var datePeriod = this.getDatePeriod();
		var date = datePeriod.getDate();
		this.profileData.period = {
			startDate: date.start,
			dueDate: date.due
		};
		this.saveActivityProfileData();
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	onBeforeLoadStore: function(store, operation) {
		this.callParent(arguments);
		var queryConfig = operation.config.queryConfig;
		var isHybridMode = BPMSoft.FeatureUtils.isHybridMode();
		if (isHybridMode) {
			var proxyName = this.getProxyName();
			store.setProxy(proxyName);
		}
		var isSchedule = this.getIsSchedule();
		operation.forceRefresh = this.forceRefresh || operation.config.isPulltoRefresh ||
			!BPMSoft.ApplicationUtils.isOnlineMode();
		operation.useCache = !this.isDetail();
		operation.checkForUpdates = this.checkForUpdates;
		this.checkForUpdates = false;
		this.forceRefresh = false;
		var schedule = this.getGrid();
		if (isSchedule) {
			if (isHybridMode) {
				var initialFilters = operation.getFilters();
				var startDateFilter = initialFilters.findSubfilterByName("StartDateFilter").filter;
				var dueDateFilter = initialFilters.findSubfilterByName("DueDateFilter").filter;
				var firstDate = Ext.Date.clearTime(schedule.getFirstDate(), true);
				dueDateFilter.setValue(firstDate);
				var lastDate = Ext.Date.clone(schedule.getLastDate());
				lastDate.setHours(23, 59, 59);
				startDateFilter.setValue(lastDate);
			} else {
				operation.minCacheSizeInOneDirection = schedule.getPreRenderedDaysCount();
			}
		} else {
			var isDetail = this.isDetail();
			queryConfig.setOrderByColumns([{
				column: this.startDateColumnName,
				orderType: isDetail ? BPMSoft.OrderTypes.DESC : BPMSoft.OrderTypes.ASC
			}]);
		}
	},

	/**
	 * @protected
	 * @overridden
	 */
	getSearchColumns: function() {
		if (this.isDetail()) {
			return this.callParent(arguments);
		} else {
			return [];
		}
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	onStoreLoad: function(store) {
		this.callParent(arguments);
		if (this.getIsSchedule() && this.selectedRecord) {
			var schedule = this.getGrid();
			var scheduleItem = schedule.getItemByRecord(this.selectedRecord);
			schedule.setEditableItem(scheduleItem);
		}
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	loadData: function() {
		this.deselectAll();
		return this.callParent(arguments);
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	loadStore: function() {
		var gridView = this.getGrid();
		if (!(gridView instanceof Ext.Component)) {
			return;
		}
		var store = gridView.getStore();
		if (gridView.xtype === "tsschedule") {
			store.setPageSize(-1);
		} else {
			store.setPageSize(BPMSoft.StorePageSize);
		}
		this.callParent(arguments);
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	refreshDirtyDataByOperationConfig: function(operationConfig) {
		if (this.getIsSchedule() && operationConfig.action === "create" &&
			this.getModelName() === operationConfig.record.modelName) {
			this.removeTmpGridRecord();
			var record = operationConfig.record;
			var store = this.getStore();
			store.add(record);
			var schedule = this.getGrid();
			schedule.select(record, false, true);
			this.doSelectRecord(record);
		} else {
			this.callParent(arguments);
		}
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	refreshDirtyData: function(operationConfig) {
		if (!operationConfig) {
			this.forceRefresh = true;
		}
		this.callParent(arguments);
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	getFilters: function() {
		var groupFilter = this.callParent(arguments);
		if (!groupFilter) {
			groupFilter = Ext.create("BPMSoft.Filter", {
				type: BPMSoft.FilterTypes.Group
			});
		}
		var isSchedule = this.getIsSchedule();
		if (isSchedule) {
			var filter = Ext.create("BPMSoft.Filter", {
				property: "ShowInScheduler",
				value: true
			});
			groupFilter.addFilter(filter);
		}
		return groupFilter;
	},

	/**
	 * Creates owner filter.
	 * @protected
	 * @virtual
	 */
	createOwnerFilter: function() {
		var isDetail = this.isDetail();
		var ownerFilter;
		if (!isDetail) {
			var ownerId = this.profileData.ownerId;
			var isSchedule = this.getIsSchedule();
			if (isSchedule) {
				ownerFilter = Ext.create("BPMSoft.Filter", {
					name: "ActivityByOwnerFilter",
					property: "Participant",
					modelName: "ActivityParticipant",
					assocProperty: "Activity",
					operation: BPMSoft.FilterOperations.Any,
					value: ownerId
				});
			} else {
				ownerFilter = Ext.create("BPMSoft.Filter", {
					name: "ActivityByOwnerFilter",
					property: "Owner",
					value: ownerId
				});
			}
		}
		return ownerFilter;
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	getFilterPanelFilters: function() {
		var filters = this.callParent(arguments);
		var isDetail = this.isDetail();
		if (!isDetail && filters) {
			var dateFilters = filters.getSubfilters()[0].getSubfilters();
			if (dateFilters) {
				var dueDateFilter = dateFilters[0];
				dueDateFilter.setName("DueDateFilter");
				var startDateFilter = dateFilters[1];
				startDateFilter.setName("StartDateFilter");
			}
		}
		return filters;
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	getExtendedFilters: function() {
		var filters = this.callParent(arguments);
		var ownerFilter = this.createOwnerFilter();
		if (ownerFilter) {
			if (!filters) {
				filters = Ext.create("BPMSoft.Filter", {
					type: BPMSoft.FilterTypes.Group,
					subfilters: [ownerFilter]
				});
			} else {
				var ownerProperty = ownerFilter.getProperty();
				var filterName = BPMSoft.ExtendedFiltersPanel.getFilterName(ownerProperty);
				var foundFiltersResult = filters.findSubfilterByName(filterName);
				if (foundFiltersResult) {
					foundFiltersResult.filter.addFilter(ownerFilter);
				} else {
					filters.addFilter(ownerFilter);
				}
			}
		}
		return filters;
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	getActions: function() {
		var items = this.callParent(arguments);
		items = items.filter(function(item) {
			return item.useWithRecord !== true;
		});
		return items;
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	getCustomActions: function() {
		var actions = this.callParent(arguments);
		actions.push({
			name: "copyActionMenu",
			title: BPMSoft.LocalizableStrings.ActivityGridPageActionsCopyButtonText,
			iconCls: BPMSoft.ActionIcons.Copy,
			isQuickAction: true,
			useWithRecord: true,
			useMask: false
		}, {
			name: "deleteActionMenu",
			title: BPMSoft.LocalizableStrings.ActivityGridPageActionsDeleteButtonText,
			iconCls: BPMSoft.ActionIcons.Delete,
			isQuickAction: true,
			useWithRecord: true,
			useMask: false
		});
		return actions;
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	isActionExecutable: function(actionItem) {
		var changeModeOperations = this.getChangeModeOperations();
		if (actionItem.getName() === "copyActionMenu") {
			return changeModeOperations.canCreate;
		} else if (actionItem.getName() === "deleteActionMenu") {
			return changeModeOperations.canDelete;
		} else {
			return this.callParent(arguments);
		}
	},

	/**
	 * @protected
	 */
	showActivityResultPicker: function(config) {
		var store = Ext.create("BPMSoft.store.BaseStore", {
			model: "ActivityResult",
			data: config.activityResults
		});
		var picker = Ext.create("BPMSoft.ComboBoxPicker", {
			component: {
				store: store,
				primaryColumn: "Name"
			},
			listeners: {
				scope: this,
				itemtap: function(el, index, target, record) {
					Ext.callback(config.selectCallback, config.scope, [record]);
				}
			},
			toolbar: {
				clearButton: false,
				cancelButton: {
					listeners: {
						scope: this,
						tap: function() {
							Ext.callback(config.cancelCallback, config.scope);
						}
					}
				}
			},
			title: BPMSoft.LS.ActivityGridPageResultPickerTitle,
			popup: true
		});
		picker.on("hide", function(component) {
			component.destroy();
		}, this);
		Ext.Viewport.add(picker);
		picker.show();
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	shouldUseFolderFilters: function() {
		if (this.getIsSchedule() === false) {
			return this.callParent(arguments);
		} else {
			return false;
		}
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	shouldUseSummaries: function() {
		return false;
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	getDataCacheManager: function() {
		return this.callParent(arguments);
	},

	//endregion

	/**
	 * @inheritdoc
	 * @protected
	 * @internal
	 * @overridden
	 */
	launch: function() {
		var args = arguments;
		this.checkForUpdates = true;
		var view = this.getView();
		if (this.isDetail()) {
			this.isSchedule = false;
			var gridConfig = this.getInitialGridConfig();
			gridConfig.xtype = BPMSoft.Configuration.ActivityGridModeTypes.List;
			view.setGrid(gridConfig);
			return this.callParent(arguments);
		}
		var grid = this.getGrid();
		this.setIsScheduleByXtype(grid.xtype);
		return new Promise(function(resolve, reject) {
			this.loadActivityProfileData({
				success: function(profileData) {
					this.initializeViewByProfileData(profileData);
					var promise = BPMSoft.configuration.controller.ActivityGridPage.superclass.launch.call(this, args);
					this.runExportIfNeeded();
					this.runImportIfNeeded();
					promise.then(function() {
						resolve();
					});
				},
				failure: function(exception) {
					reject(exception);
					BPMSoft.MessageBox.showException(exception);
				},
				scope: this
			});
		}.bind(this));
	},

	/**
	 * @protected
	 * @internal
	 * @overridden
	 */
	pageLoadComplete: function() {
		var isSchedule = this.getIsSchedule();
		if (!isSchedule) {
			this.callParent(arguments);
		} else {
			if (BPMSoft.PageNavigator.getLastPageController() === this) {
				var view = this.getView();
				view.setActionsHidden(false);
			}
			this.removeTmpGridRecord();
		}
	},

	/**
	 * @inheritdoc
	 */
	destroy: function() {
		this.unsubscribeSyncManagerEvents();
		this.callParent(arguments);
		Ext.destroy(this.gridModePicker);
		Ext.destroy(this.activityStatusPicker);
		Ext.destroy(this.employeePicker);
		Ext.destroy(this.importHelper);
		this.employeePicker = null;
		this.activityStatusPicker = null;
		this.gridModePicker = null;
	},

	/**
	 * Sets date interval.
	 * @obsolete
	 */
	setDatePeriod: function(startDate, dueDate, preventEvent) {
		this.profileData.period = {
			startDate: startDate,
			dueDate: dueDate
		};
		var datePeriod = this.getDatePeriod();
		datePeriod.setDate({
			start: startDate,
			due: dueDate
		}, preventEvent);
		this.scheduleActiveDate = startDate;
		this.saveActivityProfileData();
	}

});

/**
 * @class BPMSoft.model.ActivityActions
 */
Ext.define("BPMSoft.model.ActivityActions", {
	alternateClassName: "ActivityActionsModel",
	extend: "Ext.data.Model",
	config: {
		idProperty: "Type",
		fields: [
			{name: "Type"},
			{name: "Name", type: "string"},
			{name: "Data"}
		]
	}
});

/**
 * @class BPMSoft.configuration.MobileActivityUtilities
 */
Ext.define("BPMSoft.configuration.MobileActivityUtilities", {
	alternateClassName: "BPMSoft.MobileActivityUtilities",
	singleton: true,

	/**
	 * Gets records of ActivityResult by value of AllowedResult column.
	 * @returns {BPMSoft.BaseModel[]} Records.
	 */
	getAllowedResultRecords: function(allowedResult) {
		var records = [];
		allowedResult = Ext.JSON.decode(allowedResult, true);
		if (Ext.isArray(allowedResult)) {
			for (var i = 0, ln = allowedResult.length; i < ln; i++) {
				var resultId = allowedResult[i];
				var resultRecord = ActivityResult.Store.getById(resultId);
				if (resultRecord) {
					records.push(resultRecord);
				}
			}
		}
		return records;
	},

	/**
	 * Gets records of ActivityResult.
	 * @param {Object} config Configuration object:
	 * @param {BPMSoft.BaseModel} config.activityRecord Instance of model.
	 * @param {Function} config.success Success callback.
	 * @param {Function} config.failure Failure callback.
	 * @param {Object} config.scope Value of 'this' in the above function.
	 * @param {String} config.cancellationId Cancellation id. If parameter is set, operation can be cancelled.
	 */
	getActivityResultRecords: function(config) {
		var activityRecord = config.activityRecord;
		var allowedResult = activityRecord.get("AllowedResult");
		if (Ext.isEmpty(allowedResult)) {
			var filter = Ext.create("BPMSoft.Filter", {
				property: "ActivityCategory",
				modelName: "ActivityCategoryResultEntry",
				assocProperty: "ActivityResult",
				operation: BPMSoft.FilterOperations.Any,
				value: activityRecord.get("ActivityCategory")
			});
			BPMSoft.DataUtils.loadRecords({
				isCancelable: false,
				cancellationId: config.cancellationId,
				filters: filter,
				modelName: "ActivityResult",
				columns: ["Id", "Name"],
				success: config.success,
				failure: config.failure,
				scope: config.scope
			});
		} else {
			var records = this.getAllowedResultRecords(allowedResult);
			Ext.callback(config.success, config.scope, [records]);
		}
	}

});
