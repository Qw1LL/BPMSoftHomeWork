define("ColumnSettingsViewModel", ["ColumnSettingsUtilities", "MaskHelper"], function(ColumnSettingsUtilities, MaskHelper) {
	/**
	 * @class BPMSoft.ColumnSettingsViewModel
	 * Class that column settings presentation view model.
	 */
	Ext.define("BPMSoft.ColumnSettingsViewModel", {
		extend: "BPMSoft.BaseViewModel",

		/**
		 * @type {Object} Resources.
		 */
		resources: null,

		/**
		 * Gets sandbox instance.
		 * @private
		 * @return {Object} sandbox.
		 */
		getSandbox: function() {
			return this.get("sandbox");
		},

		/**
		 * Gets a collection of column types.
		 * @private
		 */
		getColumnTypes: function() {
			var columnTypes = this.get("columnTypes");
			columnTypes.clear();
			var types = {
				"text": {
					value: BPMSoft.GridCellType.TEXT,
					displayValue: this.resources.localizableStrings.TextCaption
				},
				"title": {
					value: BPMSoft.GridCellType.TITLE,
					displayValue: this.resources.localizableStrings.CaptionCaption
				}
			};
			var referenceSchemaName = this.get("referenceSchemaName");
			var schemaConfig = BPMSoft.configuration.ModuleStructure[referenceSchemaName];
			if (this.get("useLinkType") && schemaConfig) {
				types.link = {
					value: BPMSoft.GridCellType.LINK,
					displayValue: this.resources.localizableStrings.LinkCaption
				};
			}
			columnTypes.loadAll(types);
		},

		/**
		 * Handler of the save button.
		 * @private
		 */
		saveButtonClick: function() {
			var columnConfig = this._getColumnConfig();
			var sandbox = this.getSandbox();
			sandbox.publish("ColumnSetuped", columnConfig, [sandbox.id]);
			if (this.get("isNestedColumnSettingModule")) {
				if(ColumnSettingsUtilities.isPopupWin()) {
					ColumnSettingsUtilities.Close();
				} 
				return;
			}
			sandbox.publish("BackHistoryState");
		},

		/**
		 * Gets column config.
		 * @private
		 * @return {Object} Config of the selected column.
		 */
		_getColumnConfig: function() {
			var filterManager = this.get("filterManager");
			var columnInfo = this.get("columnInfo");
			var selectedColumnType = this.get("selectedColumnType");
			var columnConfig = {
				aggregationType: this._getColumnAggregationType(),
				column: columnInfo.column,
				dataValueType: columnInfo.dataValueType,
				isBackward: columnInfo.isBackward,
				isCaptionHidden: this.get("isCaptionHidden"),
				isTiled: columnInfo.isTiled,
				metaCaptionPath: this.get("columnCaption"),
				referenceSchemaName: columnInfo.referenceSchemaName,
				row: columnInfo.row,
				columnType: selectedColumnType && selectedColumnType.value
				|| BPMSoft.GridCellType.TEXT,
				serializedFilter: filterManager && filterManager.serializeFilters(),
				title: this.get("titleValue"),
				width: columnInfo.width,
				hideFilter: columnInfo.hideFilter,
				leftExpressionColumnPath: columnInfo.leftExpressionColumnPath
			};
			return columnConfig;
		},

		/**
		 * Gets column aggregation type.
		 * @private
		 * @return {BPMSoft.AggregationType} Type of the aggregation function.
		 */
		_getColumnAggregationType: function() {
			var columnInfo = this.get("columnInfo");
			if (columnInfo.isBackward && columnInfo.dataValueType === BPMSoft.DataValueType.GUID) {
				return BPMSoft.AggregationType.NONE;
			}
			var isAggregation = columnInfo.isBackward || columnInfo.aggregationFunction;
			var aggregationType = this.get("functionButtonsGroup");
			return isAggregation ? aggregationType : BPMSoft.AggregationType.NONE;
		},

		/**
		 * Handler of the cancel button.
		 * @private
		 */
		cancelButtonClick: function() {
			var sandbox = this.getSandbox();
			if (this.get("isNestedColumnSettingModule")) {
				sandbox.publish("ColumnSetuped", {}, [sandbox.id]);
				if(ColumnSettingsUtilities.isPopupWin()) {
					ColumnSettingsUtilities.Close();
				} 
				return;
			}
			sandbox.publish("BackHistoryState");
		},

		/**
		 * Sets the visibility of the radio button.
		 * @private
		 */
		showRadioButtons: function() {
			var columnInfo = this.get("columnInfo");
			var dataValueType = columnInfo.dataValueType;
			switch (dataValueType) {
				case BPMSoft.DataValueType.DATE:
				case BPMSoft.DataValueType.DATE_TIME:
				case BPMSoft.DataValueType.TIME:
					this.set("maxContainerRadioButton", true);
					this.set("minContainerRadioButton", true);
					if (!columnInfo.aggregationType) {
						this.set("functionButtonsGroup", BPMSoft.AggregationType.MAX);
					}
					break;
				case BPMSoft.DataValueType.INTEGER:
				case BPMSoft.DataValueType.MONEY:
				case BPMSoft.DataValueType.FLOAT:
					this.set("sumContainerRadioButton", true);
					this.set("avgContainerRadioButton", true);
					this.set("maxContainerRadioButton", true);
					this.set("minContainerRadioButton", true);
					break;
				default:
					break;
			}
		}
	});
	return {};
});
