define("CampaignSchemaViewerFilters", ["CampaignSchemaViewerFiltersResources", "StorageUtilities",
"QuickFilterModuleV2", "QuickFilterViewModelV2", "css!CampaignSchemaViewerFiltersCSS"
],
function(resources, StorageUtilities) {
	return {
		messages: {

			/**
			 * @message GetFixedFilterConfig
			 * Returns config for create period filter.
			 */
			"GetFixedFilterConfig": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message GetModuleSchema
			 * Returns information about entity which works with filter.
			 */
			"GetModuleSchema": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message UpdateFilter
			 * Message handler filter events.
			 */
			"UpdateFilter": {
				mode: this.BPMSoft.MessageMode.BROADCAST,
				direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message GetFixedFilter
			 * Requests a filter from Quick filter module.
			 */
			"GetFixedFilter": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message SchemaViewerFiltersChanged
			 * Sends a filters to CampaignSchemaViewer.
			 * Sended object has same format as GetAnalyticsConfig message.
			 */
			"AnalyticsFiltersChange": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message ShowBadgesChange
			 * Sends config for badges to CampaignSchemaViewer.
			 * Sended object has format:
			 * badgesConfig: {
			 *		showComplete,
			 *		showNonComplete
			 * }
			 */
			"ShowBadgesChange": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message GetAnalyticsConfig
			 * Returns config for show analytics in CampaignSchemaViewer.
			 * Returned object has format:
			 * {
			 *	periodFilter: {
			 *		startDate,
			 *		dueDate
			 *	},
			 *	badgesConfig: {
			 *		showComplete,
			 *		showNonComplete
			 *	}
			 *}
			 */
			"GetAnalyticsConfig": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
			}

		},
		attributes: {

			/**
			 * Current time filter.
			 */
			"AnalyticsFilters": {
				dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: {}
			},

			/**
			 * Flag that indicates if ShowAllBadges changes other checkboxes on change.
			 */
			"CanSetAllCheckboxes": {
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				value: false
			},

			/**
			 * Flag that indicates selection state of all checkboxes.
			 */
			"ShowAllBadges": {
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				value: false
			},

			/**
			 * Flag that indicates visibility of the completed badges on schema.
			 */
			"ShowCompleteBadges": {
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				value: false
			},

			/**
			 * Flag that indicates visibility of the incompleted badges on schema.
			 */
			"ShowIncompleteBadges": {
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				value: false
			},

			/**
			 * Flag that indicates visibility of the processing badges on schema.
			 */
			"ShowProcessingBadges": {
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				value: false
			},

			/**
			 * Flag that indicates visibility of the error badges on schema.
			 */
			"ShowErrorBadges": {
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				value: false
			},

			/**
			 * Flag that indicates visibility of the suspended badges on schema.
			 */
			"ShowSuspendedBadges": {
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				value: false
			},

			/**
			 * Flag that indicates visibility of the history badges on schema.
			 */
			"ShowHistoryBadges": {
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				value: false
			}

		},
		methods: {

			// region Methods: Private

			/**
			 * Initialize AnalyticsFilters property default object.
			 * @private
			 */
			_initDefaultFilterObject: function() {
				this.$AnalyticsFilters = {
					periodFilter: {
						startDate: null,
						dueDate: null
					},
					badgesConfig: {
						showComplete: false,
						showNonComplete: false
					}
				};
			},

			/**
			 * Returns identifier of the QuickFilterModuleV2.
			 * @return {String} Unique identifier of QuickFilterModuleV2.
			 */
			_getQuickFilterModuleId: function() {
				return this.getModuleId("QuickFilterModuleV2");
			},

			/**
			 * Gets period filter from the fixed filter.
			 * @param {String} filterName Name of filter.
			 * @return {Object|null} Requested filter.
			 */
			_getFilterFromFixedFilter: function(filterName) {
				var quickFilterModuleId = this._getQuickFilterModuleId();
				var filters = this.sandbox.publish("GetFixedFilter", {
					filterName: filterName
				}, [quickFilterModuleId]);
				return this.BPMSoft.isEmptyObject(filters) ? null : filters;
			},

			/**
			 * Publishes message AnalyticsFiltersChange when defines startDate and dueDate in period filter or
			 * History checked.
			 * @private
			 */
			_publishFilterChange: function() {
				if (this.BPMSoft.isEmptyObject(this.$AnalyticsFilters)) {
					return;
				}
				this.sandbox.publish("AnalyticsFiltersChange", this.$AnalyticsFilters, [this.sandbox.id]);
			},

			/**
			 * Converts startDate in periodFilter to start of day value and
			 * converts dueDate in periodFilter to end of day value.
			 * @private
			 */
			_normalizePeriodFilters: function() {
				var periodFilter = this.$AnalyticsFilters.periodFilter;
				if (Ext.isDate(periodFilter.startDate)) {
					this.$AnalyticsFilters.periodFilter.startDate = this.BPMSoft.startOfDay(periodFilter.startDate);
				}
				if (Ext.isDate(periodFilter.dueDate)) {
					this.$AnalyticsFilters.periodFilter.dueDate = this.BPMSoft.endOfDay(periodFilter.dueDate);
				}
			},

			/**
			 * @private
			 */
			_isHistoryBadgesAllowed: function() {
				return BPMSoft.Features.getIsEnabled("CampaignAnalyticsHistory");
			},

			/**
			 * @private
			 */
			_actualizeStateOfCheckboxAll: function() {
				var isAllChecked = Ext.Array.every(Object.values(this.$AnalyticsFilters.badgesConfig), function(value) {
					return !!value;
				}, this);
				if (this.$CanSetAllCheckboxes && isAllChecked !== this.$ShowAllBadges) {
					this.set("CanSetAllCheckboxes", false);
					this.set("ShowAllBadges", isAllChecked);
					this.set("CanSetAllCheckboxes", true);	
				}
			},

			/**
			 * @private
			 */
			_publishAndSaveFilters: function() {
				if (!this.$CanSetAllCheckboxes) {
					return;
				}
				this.sandbox.publish("ShowBadgesChange", this.$AnalyticsFilters.badgesConfig, [this.sandbox.id]);
				this.saveFilters();
			},

			// endregion

			// region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#onRender
			 * @override
			 */
			onRender: function() {
				this.callParent(arguments);
				this.initUserFilters();
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
			 * @override
			 */
			init: function() {
				this.callParent(arguments);
				this._initDefaultFilterObject();
				this.subscribeSandboxEvents();
			},

			/**
			 * Subscribes on sandbox events.
			 * @protected
			 */
			subscribeSandboxEvents: function() {
				var sandbox = this.sandbox;
				var quickFilterModuleId = this._getQuickFilterModuleId();
				sandbox.subscribe("GetFixedFilterConfig", this.getFixedFiltersConfig, this, [quickFilterModuleId]);
				sandbox.subscribe("GetModuleSchema", this.getEntityForFixedFilter, this, [quickFilterModuleId]);
				sandbox.subscribe("UpdateFilter", this.onFilterUpdate, this, [quickFilterModuleId]);
				sandbox.subscribe("GetAnalyticsConfig", this.getAnalyticsConfig, this, [this.sandbox.id]);
				this.on("change:ShowAllBadges", this.showAllBadgesChanged, this);
				this.on("change:ShowCompleteBadges", this.showCompleteBadgesChanged, this);
				this.on("change:ShowIncompleteBadges", this.showNonCompleteBadgesChanged, this);
				this.on("change:ShowProcessingBadges", this.showProcessingBadgesChanged, this);
				this.on("change:ShowErrorBadges", this.showErrorBadgesChanged, this);
				this.on("change:ShowSuspendedBadges", this.showSuspendedBadgesChanged, this);
				this.on("change:ShowHistoryBadges", this.showHistoryBadgesChanged, this);
			},

			/**
			 * Inits user filters setting and rise event SchemaViewerFiltersChanged.
			 * @protected
			 */
			initUserFilters: function() {
				var profileKey = this.getProfileKey();
				var sessionFilters = StorageUtilities.getItem("AnalyticsFilters", profileKey);
				if (this.isEmpty(sessionFilters)) {
					var profileFilters = this.getProfileFilters();
					if (!this.BPMSoft.isEmptyObject(profileFilters)) {
						this.$AnalyticsFilters = this.BPMSoft.deepClone(profileFilters);
					}
				} else {
					this.$AnalyticsFilters = this.BPMSoft.deepClone(sessionFilters);
				}
				if (this.$AnalyticsFilters.hasOwnProperty("badgesConfig")) {
					this.$ShowCompleteBadges = this.$AnalyticsFilters.badgesConfig.showComplete;
					this.$ShowIncompleteBadges = this.$AnalyticsFilters.badgesConfig.showNonComplete;
					this.$ShowProcessingBadges = this.$AnalyticsFilters.badgesConfig.showProcessing;
					this.$ShowErrorBadges = this.$AnalyticsFilters.badgesConfig.showError;
					this.$ShowSuspendedBadges = this.$AnalyticsFilters.badgesConfig.showSuspended;
					this.$ShowHistoryBadges = this.$AnalyticsFilters.badgesConfig.showHistory;
					this.$CanSetAllCheckboxes = true;
					this._publishAndSaveFilters();
					this._actualizeStateOfCheckboxAll();
				}
				this._publishFilterChange();
			},

			/**
			 * Returns filters from stored profile.
			 * @protected
			 * @return {Object} Profile filters.
			 */
			getProfileFilters: function() {
				var profile = this.getProfile();
				var profileFilters = profile.analyticsFilters || {};
				if (profile && profile.analyticsFilters && profile.analyticsFilters.periodFilter) {
					var periodFilter = profile.analyticsFilters.periodFilter;
					periodFilter.startDate = periodFilter.startDate ? new Date(periodFilter.startDate) : null;
					periodFilter.dueDate = periodFilter.dueDate ? new Date(periodFilter.dueDate) : null;
					profileFilters = profile.analyticsFilters;
				}
				return profileFilters;
			},

			/**
			 * @inheritdoc BaseSchemaViewModel#getProfileKey
			 * @override
			 */
			getProfileKey: function() {
				return this.$CardSchemaName + this.$CampaignId + "AnalyticsFilters";
			},

			/**
			 * Returns entity for create fixed filter.
			 * @protected
			 * @return {BPMSoft.BaseEntitySchema} Entity.
			 */
			getEntityForFixedFilter: function() {
				return this.Ext.create("BPMSoft.BaseEntitySchema", {
					columns: {
						"StartDate": {},
						"DueDate": {}
					}
				});
			},

			/**
			 * Handles changes of period filter changes.
			 * @protected
			 */
			onFilterUpdate: function() {
				var periodFilter = this._getFilterFromFixedFilter("PeriodFilter");
				if (this.BPMSoft.isEqual(periodFilter, this.$AnalyticsFilters.periodFilter)) {
					return;
				}
				this.$AnalyticsFilters.periodFilter = periodFilter;
				this._normalizePeriodFilters();
				this._publishFilterChange();
				this.saveFilters();
			},

			/**
			 * Returns object that contains analytics filters parameters.
			 * @returns {Object} Config for analytics in CampaignSchemaViewer.
			 */
			getAnalyticsConfig: function() {
				return this.$AnalyticsFilters;
			},

			/**
			 * Handles changes of ShowAllBadges checkbox.
			 * @protected
			 * @param {Object} model View model.
			 * @param {Boolean} value Checkbox state value.
			 */
			showAllBadgesChanged: function(model, value) {
				if (this.$CanSetAllCheckboxes) {
					this.$CanSetAllCheckboxes = false;
					this.set("ShowCompleteBadges", value);
					this.set("ShowIncompleteBadges", value);
					this.set("ShowProcessingBadges", value);
					this.set("ShowErrorBadges", value);
					this.set("ShowSuspendedBadges", value);
					this.set("ShowHistoryBadges", value);
					this.$CanSetAllCheckboxes = true;
					this._publishAndSaveFilters();
				}
			},

			/**
			 * Handles changes of ShowCompleteBadges checkbox.
			 * @protected
			 * @param {Object} model View model.
			 * @param {Boolean} value Checkbox state value.
			 */
			showCompleteBadgesChanged: function(model, value) {
				if (value !== null && this.$AnalyticsFilters.badgesConfig.showComplete !== value) {
					this.$AnalyticsFilters.badgesConfig.showComplete = this.$ShowCompleteBadges;
					this._publishAndSaveFilters();
					this._actualizeStateOfCheckboxAll();
				}
			},

			/**
			 * Handles changes of ShowIncompleteBadges checkbox.
			 * @protected
			 * @param {Object} model View model.
			 * @param {Boolean} value Checkbox state value.
			 */
			showNonCompleteBadgesChanged: function(model, value) {
				if (value !== null && this.$AnalyticsFilters.badgesConfig.showNonComplete !== value) {
					this.$AnalyticsFilters.badgesConfig.showNonComplete = this.$ShowIncompleteBadges;
					this._publishAndSaveFilters();
					this._actualizeStateOfCheckboxAll();
				}
			},

			/**
			 * Handles changes of ShowProcessingBadges checkbox.
			 * @protected
			 * @param {Object} model View model.
			 * @param {Boolean} value Checkbox state value.
			 */
			showProcessingBadgesChanged: function(model, value) {
				if (value !== null && this.$AnalyticsFilters.badgesConfig.showProcessing !== value) {
					this.$AnalyticsFilters.badgesConfig.showProcessing = this.$ShowProcessingBadges;
					this._publishAndSaveFilters();
					this._actualizeStateOfCheckboxAll();
				}
			},

			/**
			 * Handles changes of ShowErrorBadges checkbox.
			 * @protected
			 * @param {Object} model View model.
			 * @param {Boolean} value Checkbox state value.
			 */
			showErrorBadgesChanged: function(model, value) {
				if (value !== null && this.$AnalyticsFilters.badgesConfig.showError !== value) {
					this.$AnalyticsFilters.badgesConfig.showError = this.$ShowErrorBadges;
					this._publishAndSaveFilters();
					this._actualizeStateOfCheckboxAll();
				}
			},

			/**
			 * Handles changes of ShowSuspendedBadges checkbox.
			 * @protected
			 * @param {Object} model View model.
			 * @param {Boolean} value Checkbox state value.
			 */
			showSuspendedBadgesChanged: function(model, value) {
				if (value !== null && this.$AnalyticsFilters.badgesConfig.showSuspended !== value) {
					this.$AnalyticsFilters.badgesConfig.showSuspended = this.$ShowSuspendedBadges;
					this._publishAndSaveFilters();
					this._actualizeStateOfCheckboxAll();
				}
			},

			/**
			 * Handles changes of ShowHistoryBadges checkbox.
			 * @protected
			 * @param {Object} model View model.
			 * @param {Boolean} value Checkbox state value.
			 */
			showHistoryBadgesChanged: function(model, value) {
				if (value !== null && this.$AnalyticsFilters.badgesConfig.showHistory !== value) {
					this.$AnalyticsFilters.badgesConfig.showHistory = this.$ShowHistoryBadges;
					this._publishAndSaveFilters();
					this._actualizeStateOfCheckboxAll();
				}
			},

			/**
			 * Saves a filter to local storage and profile.
			 * @protected
			 */
			saveFilters: function() {
				var profileKey = this.getProfileKey();
				var analyticsFilters = this.BPMSoft.deepClone(this.$AnalyticsFilters);
				this.BPMSoft.saveUserProfile(profileKey, {
					analyticsFilters: analyticsFilters
				}, false);
				StorageUtilities.setItem(analyticsFilters, "AnalyticsFilters", profileKey);
			},

			/**
			 * Returns default config of fixed filter for QuickFilterModuleV2.
			 * @protected
			 * @return {Object} Filter config.
			 */
			getFixedFiltersConfig: function() {
				var periodFilter = this.$AnalyticsFilters.periodFilter || {};
				return {
					entitySchema: this.entitySchema,
					filters: [{
						name: "PeriodFilter",
						dataValueType: this.BPMSoft.DataValueType.DATE,
						startDate: {
							columnName: "StartDate",
							defValue: periodFilter.startDate || null
						},
						dueDate: {
							columnName: "DueDate",
							defValue: periodFilter.dueDate || null
						},
						dayButtonVisible: true,
						weekButtonVisible: true
					}]
				};
			}

			// endregion

		},
		diff: /**SCHEMA_DIFF*/ [
			{
				"operation": "insert",
				"name": "SchemaViewerFiltersGridLayout",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "SchemaViewerFiltersContainer",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"classes": {
						"wrapClassName": ["schema-viewer-filters-container filters-container-wrapClass"]
					},
					"items": [],
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 24
					}

				},
				"parentName": "SchemaViewerFiltersGridLayout",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "SchemaViewerFixedFiltersModule",
				"parentName": "SchemaViewerFiltersContainer",
				"propertyName": "items",
				"values": {
					"classes": {
						"wrapClassName": ["schema-viewer-fixed-filter-module"]
					},
					"itemType": BPMSoft.ViewItemType.MODULE,
					"moduleName": "QuickFilterModuleV2",
					"instanceConfig": {
						"moduleConfig": {
							"FixedFilters": {
								"viewConfigModuleName": "FixedFilterViewV2",
								"viewModelConfigModuleName": "FixedFilterViewModelV2",
								"configPropertyName": "fixedFilterConfig"
							}
						}
					}
				}
			},
			{
				"operation": "insert",
				"name": "SchemaViewerBadgesContainer",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"classes": {
						"wrapClassName": ["schema-viewer-filters-container filters-container-wrapClass"]
					},
					"items": [],
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 24
					}

				},
				"parentName": "SchemaViewerFiltersGridLayout",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "ShowAllContainer",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"classes": {
						"wrapClassName": ["checkbox-item-container"]
					},
					"items": [],
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 24
					}

				},
				"parentName": "SchemaViewerBadgesContainer",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "ShowAllBadges",
				"values": {
					"labelConfig": {"visible": false},
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"classes": {
						"wrapClassName": ["show-all-badge"]
					}
				},
				"parentName": "ShowAllContainer",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "ShowAllBadgesLabel",
				"parentName": "ShowAllContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"classes": {
						"labelClass": ["show-badge-label"]
					},
					"caption": {
						"bindTo": "Resources.Strings.ShowAllBadgesCaption"
					}
				}
			},
			{
				"operation": "insert",
				"name": "ShowCompleteContainer",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"classes": {
						"wrapClassName": ["checkbox-item-container"]
					},
					"items": [],
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 24
					}

				},
				"parentName": "SchemaViewerBadgesContainer",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "ShowCompleteBadges",
				"values": {
					"labelConfig": {"visible": false},
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"classes": {
						"wrapClassName": ["show-complete-badge"]
					}
				},
				"parentName": "ShowCompleteContainer",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "ShowCompleteBadgeLabel",
				"parentName": "ShowCompleteContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"classes": {
						"labelClass": ["show-badge-label"]
					},
					"caption": {
						"bindTo": "Resources.Strings.ShowCompleteBadgeCaption"
					}
				}
			},
			{
				"operation": "insert",
				"name": "ShowIncompleteContainer",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"classes": {
						"wrapClassName": ["checkbox-item-container"]
					},
					"items": [],
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 24
					}

				},
				"parentName": "SchemaViewerBadgesContainer",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "ShowIncompleteBadges",
				"values": {
					"labelConfig": {"visible": false},
					"classes": {
						"wrapClassName": ["show-badge"]
					},
					"dataValueType": BPMSoft.DataValueType.BOOLEAN
				},
				"parentName": "ShowIncompleteContainer",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "ShowIncompletedLabelOnSchemaLabel",
				"parentName": "ShowIncompleteContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"classes": {
						"labelClass": ["show-badge-label"]
					},
					"caption": {
						"bindTo": "Resources.Strings.ShowIncompleteBadgeCaption"
					}
				}
			},
			{
				"operation": "insert",
				"name": "ShowProcessingContainer",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"classes": {
						"wrapClassName": ["checkbox-item-container"]
					},
					"items": [],
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 24
					}

				},
				"parentName": "SchemaViewerBadgesContainer",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "ShowProcessingBadges",
				"values": {
					"labelConfig": {"visible": false},
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"classes": {
						"wrapClassName": ["show-processing-badge"]
					}
				},
				"parentName": "ShowProcessingContainer",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "ShowProcessingBadgeLabel",
				"parentName": "ShowProcessingContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"classes": {
						"labelClass": ["show-badge-label"]
					},
					"caption": {
						"bindTo": "Resources.Strings.ShowProcessingBadgeCaption"
					}
				}
			},
			{
				"operation": "insert",
				"name": "ShowErrorContainer",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"classes": {
						"wrapClassName": ["checkbox-item-container"]
					},
					"items": [],
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 24
					}

				},
				"parentName": "SchemaViewerBadgesContainer",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "ShowErrorBadges",
				"values": {
					"labelConfig": {"visible": false},
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"classes": {
						"wrapClassName": ["show-error-badge"]
					}
				},
				"parentName": "ShowErrorContainer",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "ShowErrorBadgeLabel",
				"parentName": "ShowErrorContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"classes": {
						"labelClass": ["show-badge-label"]
					},
					"caption": {
						"bindTo": "Resources.Strings.ShowErrorBadgeCaption"
					}
				}
			},
			{
				"operation": "insert",
				"name": "ShowSuspendedContainer",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"classes": {
						"wrapClassName": ["checkbox-item-container"]
					},
					"items": [],
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 24
					}

				},
				"parentName": "SchemaViewerBadgesContainer",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "ShowSuspendedBadges",
				"values": {
					"labelConfig": {"visible": false},
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"classes": {
						"wrapClassName": ["show-suspended-badge"]
					}
				},
				"parentName": "ShowSuspendedContainer",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "ShowSuspendedBadgeLabel",
				"parentName": "ShowSuspendedContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"classes": {
						"labelClass": ["show-badge-label"]
					},
					"caption": "$Resources.Strings.ShowSuspendedBadgeCaption"
				}
			},
			{
				"operation": "insert",
				"name": "ShowHistoryContainer",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"classes": {
						"wrapClassName": ["checkbox-item-container"]
					},
					"items": [],
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 24
					}

				},
				"parentName": "SchemaViewerBadgesContainer",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "ShowHistoryBadges",
				"values": {
					"labelConfig": {"visible": false},
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"classes": {
						"wrapClassName": ["show-history-badge"]
					},
					"visible": "$_isHistoryBadgesAllowed"
				},
				"parentName": "ShowHistoryContainer",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "ShowHistoryBadgeLabel",
				"parentName": "ShowHistoryContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"classes": {
						"labelClass": ["show-badge-label"]
					},
					"caption": "$Resources.Strings.ShowHistoryBadgeCaption",
					"visible": "$_isHistoryBadgesAllowed"
				}
			}
		] /**SCHEMA_DIFF*/
	};
}
);
