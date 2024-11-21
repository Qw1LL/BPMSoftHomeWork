/**
 * Base process library section.
 * Parent: BaseSectionV2
 */
define("BaseProcessLibSection", ["css!BaseProcessLibSectionCSS"], function() {
	return {
		attributes: {
			/**
			 * Section active process filter state.
			 */
			HasActiveProcessFilter: {
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				value: true
			},

			/**
			 * Section active process column name.
			 */
			ActiveProcessFilterColumnName: {
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: this.BPMSoft.DataValueType.TEXT,
				value: "Enabled"
			}
		},
		methods: {

			/**
			 * @inheritdoc BaseSectionV2#getActiveViewGridSettingsProfile
			 * @overridden
			 */
			getActiveViewGridSettingsProfile: function(callback, scope) {
				this.callParent([function() {
					this.initHasActiveProcessFilter();
					Ext.callback(callback, scope);
				}, this]);
			},

			/**
			 * Adds a filter by the IsActiveVersion column.
			 * @protected
			 */
			addIsActiveVersionFilter: function(filters) {
				filters.addIfNotExists("ActiveVersionFilter", BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "IsActiveVersion", true));
			},

			/**
			 * Initializes active process filter from user profile.
			 * @private
			 */
			initHasActiveProcessFilter: function() {
				var profile = this.getProfile();
				var profileValue = profile.HasActiveProcessFilter;
				if (Ext.isDefined(profileValue)) {
					this.set("HasActiveProcessFilter", profileValue);
				}
			},

			/**
			 * Adds active process filter.
			 * @private
			 * @param {BPMSoft.core.collections.Collection} filters Filters.
			 */
			addActiveProcessFilter: function(filters) {
				var hasActiveProcessFilter = this.get("HasActiveProcessFilter");
				if (hasActiveProcessFilter) {
					var columnName = this.get("ActiveProcessFilterColumnName");
					filters.addIfNotExists("ActiveProcess", this.BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, columnName, 1));
				} else {
					filters.removeByKey("ActiveProcess");
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#getFilters.
			 * @overridden
			 */
			getFilters: function() {
				var filters = this.callParent(arguments);
				this.addActiveProcessFilter(filters);
				return filters;
			},

			/**
			 * Saves active process filter state in user profile.
			 * @private
			 * @param {Boolean} value Indicates if active process filter enabled.
			 */
			saveActiveProcessFilterInUserProfile: function(value) {
				var profile = this.get("Profile");
				profile.HasActiveProcessFilter = value;
				this.BPMSoft.utils.saveUserProfile(this.getProfileKey(), profile, false);
			},

			/**
			 * Handles active process filter checked changes.
			 * @param {Boolean} value Checked value.
			 */
			onActiveProcessFilterChecked: function(value) {
				this.saveActiveProcessFilterInUserProfile(value);
				if (this.get("IsSectionVisible")) {
					this.set("HasActiveProcessFilter", value);
					this.sandbox.publish("FiltersChanged", null, [this.sandbox.id]);
					this.reloadGridData();
				}
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "HasActiveProcessFilterContainer",
				"parentName": "FiltersContainer",
				"propertyName": "items",
				"index": 0,
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["active-process-filter-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "HasActiveProcessFilterContainer",
				"propertyName": "items",
				"name": "HasActiveProcessFilter",
				"values": {
					"caption": {"bindTo": "Resources.Strings.ActiveProcessFilterCaption"},
					"controlConfig": {
						"className": "BPMSoft.CheckBoxEdit",
						"checkedchanged": {
							"bindTo": "onActiveProcessFilterChecked"
						}
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
