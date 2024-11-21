define("PartnershipLeadDetail", ["ConfigurationConstants", "css!PartnershipLeadDetailCss", "css!SummaryModuleV2"],
		function(ConfigurationConstants) {
	return {
		entitySchemaName: "Lead",
		attributes: {
			IsActiveFiltrationButtonPressed: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN
			}
		},
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "ActiveFiltrationButton",
				"parentName": "Detail",
				"propertyName": "tools",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"caption": {"bindTo": "Resources.Strings.ActiveFiltrationButtonCaption"},
					"pressed": {"bindTo": "IsActiveFiltrationButtonPressed"},
					"click": {"bindTo": "onActiveFiltrationButtonClick"}
				}
			},
			{
				"operation": "insert",
				"name": "summaryItemsContainer",
				"propertyName": "tools",
				"parentName": "Detail",
				"values": {
					"id": "summaryItemContainer",
					"selectors": {"wrapEl": "#summaryItemContainer"},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["summary-item-container"],
					"visible": true,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "summaryCountCaption",
				"parentName": "summaryItemsContainer",
				"propertyName": "items",
				"values": {
					"caption": {"bindTo": "Resources.Strings.RecordsCountCaption"},
					"itemType": BPMSoft.ViewItemType.LABEL,
					"classes": {"labelClass": ["summary-item-caption"]}
				}
			},
			{
				"operation": "insert",
				"name": "summaryCountValue",
				"parentName": "summaryItemsContainer",
				"propertyName": "items",
				"values": {
					"caption": {"bindTo": "RecordsCount"},
					"markerValue": "RecordsCount",
					"itemType": BPMSoft.ViewItemType.LABEL,
					"classes": {"labelClass": ["summary-item-value"]}
				}
			}
		]/**SCHEMA_DIFF*/,
		methods: {
			/**
			* Is active filtration button click handler
			*/
			onActiveFiltrationButtonClick: function() {
				this.$IsActiveFiltrationButtonPressed = !this.$IsActiveFiltrationButtonPressed;
				this._saveFiltersToProfile();
				this.reloadGridData();
			},

			/**
			 * Save filters to profile
			 * @private
			 */
			_saveFiltersToProfile: function() {
				const profile = this.getProfile();
				const key = this.getProfileKey();
				if (this.isNotEmpty(profile) && this.isNotEmpty(key)) {
					profile.IsActiveFiltrationButtonPressed = this.$IsActiveFiltrationButtonPressed;
					this.set(this.getProfileColumnName(), profile);
					this.BPMSoft.utils.saveUserProfile(key, profile, false);
				}
			},

			/**
			 * Load filters from profile
			 * @private
			 */
			_loadFiltersFromProfile: function() {
				const profile = this.getProfile();
				if (this.isNotEmpty(profile)) {
					this.$IsActiveFiltrationButtonPressed = Boolean(profile.IsActiveFiltrationButtonPressed);
				}
			},

			/**
			 * @inheritDoc BPMSoft.GridUtilitiesV2#init
			 * @override
			 */
			init: function() {
				this.callParent(arguments);
				this._loadFiltersFromProfile();
			},

			/**
			 * @inheritDoc BPMSoft.GridUtilities#addGridDataColumns
			 * @override
			 */
			addGridDataColumns: function(esq) {
				this.addCountOverColumn(esq);
				this.callParent(arguments);
			},

			/**
			 * @inheritDoc BPMSoft.GridUtilitiesV2#getFilters
			 * @override
			 */
			getFilters: function() {
				const filterGroup = this.callParent(arguments);
				if (this.$IsActiveFiltrationButtonPressed) {
					this._addActiveFilter(filterGroup);
				}
				return filterGroup;
			},

			/**
			 * Add Active filter
			 * @private
			 */
			_addActiveFilter: function(filterGroup) {
				filterGroup.add("ActiveFilter",
				BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "QualifyStatus.IsFinal",
					false));
			},

			/**
			 * @inheritDoc BaseGridDetailV2#addRecord
			 * @override
			 */
			addRecord: function() {
				this.setupDefaultValues();
				this.callParent(arguments);
			},

			/**
			 * Set default values for card opening.
			 * @protected
			 */
			setupDefaultValues: function() {
				const masterPageColumnNames = ["Account"];
				const masterPageValues = this.sandbox.publish("GetColumnsValues", masterPageColumnNames,
					[this.sandbox.id]);
				if (masterPageValues.Account) {
					this.setDefaultValue("Partner", masterPageValues.Account.value);
				}
				this.setDefaultValue("SalesChannel", ConfigurationConstants.Opportunity.Type.PartnerSale);
			},

			/**
			 * @inheritDoc BPMSoft.BaseGridDetailV2#getEditRecordMenuItem
			 * @override
			 */
			getEditRecordMenuItem: BPMSoft.emptyFn,

			/**
			 * @inheritDoc BPMSoft.BaseGridDetailV2#getCopyRecordMenuItem
			 * @override
			 */
			getCopyRecordMenuItem: BPMSoft.emptyFn,

			/**
			 * @inheritDoc BPMSoft.BaseGridDetailV2#getDeleteRecordMenuItem
			 * @override
			 */
			getDeleteRecordMenuItem: BPMSoft.emptyFn,

			getRecordRightsSetupMenuItem: function() {
				return BPMSoft.isCurrentUserSsp() ? null : this.callParent(arguments);
			},

			getSwitchGridModeMenuItem: function() {
				return BPMSoft.isCurrentUserSsp() ? null : this.callParent(arguments);
			},

			getExportToExcelFileMenuItem: function() {
				return BPMSoft.isCurrentUserSsp() ? null : this.callParent(arguments);
			},

			getShowQuickFilterButton: function() {
				return BPMSoft.isCurrentUserSsp() ? null : this.callParent(arguments);
			}
		}
	};
});
