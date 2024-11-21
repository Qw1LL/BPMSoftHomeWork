define("SimpleReportFilterPage", ["css!SimpleReportFilterPageCSS"], function() {
	return {

		attributes: {
			"FilterCategory": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				value: "FormBySelected"
			}
		},

		messages: {
			"GetFiltersCollection": {
				"direction": BPMSoft.MessageDirectionType.PUBLISH,
				"mode": BPMSoft.MessageMode.PTP
			}
		},

		methods: {

			// region Methods: Private

			/**
			 * @private
			 * @return {BPMSoft.FilterGroup}
			 */
			_createFilterBySelectedRecords: function() {
				const reportConfig = this.publishGetReportConfigMessage();
				const activeRow = reportConfig.activeRow;
				const selectedRows = reportConfig.selectedRows;
				const primaryColumnName = reportConfig.sectionEntitySchemaPrimaryColumnName;
				if (activeRow) {
					return BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, primaryColumnName, activeRow);
				}
				if (selectedRows && selectedRows.length > 0) {
					return BPMSoft.createColumnInFilterWithParameters(primaryColumnName, selectedRows);
				}
				return BPMSoft.createColumnIsNullFilter(primaryColumnName);
			},

			/**
			 * @private
			 * @return {Integer}
			 */
			_getSelectedRowsCount: function() {
				const reportConfig = this.publishGetReportConfigMessage();
				const activeRow = reportConfig.activeRow;
				const selectedRows = reportConfig.selectedRows;
				if (activeRow) {
					return 1;
				}
				if (selectedRows && selectedRows.length > 0) {
					return selectedRows.length;
				}
				return 0;
			},

			_getSelectdRowFilter: function() {
				const filterGroup = Ext.create("BPMSoft.FilterGroup");
				filterGroup.addItem(this._createFilterBySelectedRecords());
				return filterGroup;
			},

			// endregion

			// region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BaseReportFilterPage#getFilters.
			 * @overridden
			 */
			getFilters: function() {
				switch (this.$FilterCategory) {
					case "FormBySelected":
						return this._getSelectdRowFilter();
					case "FormByFiltered":
						return this.sandbox.publish("GetFiltersCollection");
					case "FormByAll":
						return Ext.create("BPMSoft.FilterGroup");
					default:
						throw new Ext.create("BPMSoft.InvalidOperationException");
				}
			},

			// endregion

			// region Methods: Public

			/**
			 * Fills number of rows in label caption.
			 * @public
			 * @param {String} value
			 * @return {String}
			 */
			formatFormBySelectedLabelCaption: function(value) {
				const selectedRowsCount = this._getSelectedRowsCount();
				return Ext.String.format(value, selectedRowsCount);
			}

			// endregion

		},

		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,

		modules: /**SCHEMA_MODULES*/{}/**SCHEMA_MODULES*/,

		diff: /**SCHEMA_DIFF*/[{
			"operation": "insert",
			"name": "FormByLabel",
			"parentName": "FilterContainer",
			"propertyName": "items",
			"values": {
				"id": "FormByLabel",
				"itemType": BPMSoft.ViewItemType.LABEL,
				"caption": {"bindTo": "Resources.Strings.FormByLabel"},
				"classes": {
					"labelClass": ["report-filter-page-filter-area-caption"]
				}
			}
		}, {
			"operation": "insert",
			"name": "FilterRadioGroup",
			"parentName": "FilterContainer",
			"propertyName": "items",
			"values": {
				"itemType": BPMSoft.ViewItemType.RADIO_GROUP,
				"value": {"bindTo": "FilterCategory"},
				"items": [{
					"name": "FormBySelectedRadioButton",
					"caption": {
						"bindTo": "Resources.Strings.FormBySelectedLabel",
						"bindConfig": {"converter": "formatFormBySelectedLabelCaption"}
					},
					"value": "FormBySelected"
				}, {
					"name": "FormByFilteredRadioButton",
					"caption": {"bindTo": "Resources.Strings.FormByFilteredLabel"},
					"value": "FormByFiltered"
				}, {
					"name": "FormByAllRadioButton",
					"caption": {"bindTo": "Resources.Strings.FormByAllLabel"},
					"value": "FormByAll"
				}]
			}
		}]/**SCHEMA_DIFF*/
	};
});
