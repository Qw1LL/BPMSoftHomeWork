define("ForecastItemViewModel", [
		"ConfigurationEnums",
		"RightUtilities",
		"ForecastItemViewModelResources",
		"ForecastConstants",
		"MiniPageUtilities"],
	function(ConfigurationEnums, RightUtilities, Resources, ForecastConstants) {
	Ext.define("BPMSoft.configuration.ForecastItemViewModel", {
		extend: "BPMSoft.BaseViewModel",
		alternateClassName: "BPMSoft.ForecastItemViewModel",

		Ext: null,
		BPMSoft: null,
		sandbox: null,

		columns: {
			ForecastId: { dataValueType: BPMSoft.DataValueType.TEXT },
			SnapshotId: { dataValueType: BPMSoft.DataValueType.TEXT },
			PeriodsId: { dataValueType: BPMSoft.DataValueType.TEXT },
			Command: { dataValueType: BPMSoft.DataValueType.TEXT },
			BaseUrl: { dataValueType: BPMSoft.DataValueType.TEXT },
			Images: { dataValueType: BPMSoft.DataValueType.COLLECTION },
			MaxDisplayedRecords: { dataValueType: BPMSoft.DataValueType.NUMBER }
		},

		mixins: {
			"MiniPageUtilities": "BPMSoft.MiniPageUtilities"
		},

		messages: {
			/**
			 * Sign forecast column saved.
			 */
			"ForecastColumnSaved": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},

		/**
		 * @inheritDoc BPMSoft.BaseViewModel#constructor
		 * @protected
		 * @override
		 */
		constructor: function() {
			this.callParent(arguments);
			this.sandbox.registerMessages(this.messages);
			this.sandbox.subscribe("ForecastColumnSaved", function(columnTypeId) {
				if (columnTypeId === ForecastConstants.ColumnType.Formula) {
					this.$Command = "forcerefreshcolumns";
				} else {
					this.$Command = "refreshcolumns";
				}
			}, this, [this._getModuleId()]);
			this.$Images = this._getImagesList();
		},

		/**
		 * @private
		 */
		_getImagesList: function() {
			return [{
				name: "empty-blank-slate",
				url: this.BPMSoft.ImageUrlBuilder.getUrl(Resources.localizableImages.EmptyBlankSlate)
			}];
		},

		/**
		 * Returns module identifier.
		 * @return {String} The module identifier.
		 * @private
		 */
		_getModuleId: function() {
			return this.sandbox.id + "_ForecastColumnDesignerMiniPage";
		},

		/**
		 * Handles command finished.
		 */
		onCommandFinished: function() {
			this.$Command = "";
		},

		/**
		 * Shows mini-page.
		 */
		showMiniPage: function(operation, recordId, valuePairs) {
			const miniPageConfig = {
				recordId: recordId,
				miniPageSchemaName: "ForecastColumnDesignerMiniPage",
				entitySchemaName: "ForecastColumn",
				valuePairs: valuePairs,
				operation: operation,
				showDelay: 0,
				moduleId: this._getModuleId(),
				viewGeneratorClassName: "BPMSoft.ViewGenerator"
			};
			this._showMiniPageWithCheckingRights(miniPageConfig);
		},

		/**
		 * @private
		 */
		_showMiniPageWithCheckingRights: function(miniPageConfig) {
			RightUtilities.checkCanEdit({
				schemaName: "ForecastSheet",
				primaryColumnValue: this.$ForecastId
			}, function(result) {
				if (this.Ext.isEmpty(result)) {
					this.openMiniPage(miniPageConfig);
				} else {
					this.showInformationDialog(result);
				}
			}, this);
		},

		/**
		 * Shows mini-page in adding mode.
		 */
		showAddColumnMiniPage: function() {
			const valuePairs = this._getDefaultValues();
			this.showMiniPage(ConfigurationEnums.CardStateV2.ADD, BPMSoft.generateGUID(), valuePairs);
		},

		/**
		 * Shows mini-page in editing mode.
		 * @param {Event} event Event data.
		 * @param {Object} columnData Column data.
		 */
		showEditColumnMiniPage: function(event, columnData) {
			const valuePairs = this._getDefaultValues();
			valuePairs.push({
				"name": "IsSummaryColumn",
				"value": this._getIsSummaryColumn(columnData),
			});
			this.showMiniPage(ConfigurationEnums.CardStateV2.EDIT, columnData.code, valuePairs);
		},

		/**
		 * @private
		 */
		_getDefaultValues: function() {
			return [{
				"name": "Sheet",
				"value": this.$ForecastId
			}, {
				"name": "forecastSourceItemName",
				"value": this.$ForecastSourceItemName
			}];
		},

		/**
		 * @private
		 */
		_getIsSummaryColumn: function(columnData) {
			return columnData.id.indexOf('_summary') !== -1;
		},

		/**
		 * Handles forecast row action click.
		 * @param {Object} event Row action data.
		 */
		onRowActionClick: function(event) {
			this.sandbox.publish("RowActionClick", event, [this.sandbox.id]);
		},

		onSetupColumns: function(data) {
			this.sandbox.publish("ShowDrilldownSetupColumns", data, [this.sandbox.id]);
		},

		/**
		 * Forms filter for object value records.
		 * @protected 
		 * @param {Object} data Object value data.
		 * @return {String} Serialized filter for object value records.
		 */
		getObjectValueFilterString: function(data) {
			const forecastObjValRecordSchemaPath = '[ForecastObjValueRecord:EntityId:Id].';
			const filtersGroup = this.Ext.create("BPMSoft.FilterGroup");
			filtersGroup.addItem(this.BPMSoft.createColumnFilterWithParameter(
				this.BPMSoft.ComparisonType.EQUAL, forecastObjValRecordSchemaPath + "RefEntityId", 
				{value: data.refEntityId, displayValue: data.refEntityTitle}, this.BPMSoft.DataValueType.LOOKUP));
			filtersGroup.addItem(this.BPMSoft.createColumnFilterWithParameter(
				this.BPMSoft.ComparisonType.EQUAL, forecastObjValRecordSchemaPath + "Column", 
				{value: data.columnId, displayValue: data.columnTitle}, this.BPMSoft.DataValueType.LOOKUP));
			filtersGroup.addItem(this.BPMSoft.createColumnFilterWithParameter(
				this.BPMSoft.ComparisonType.EQUAL, forecastObjValRecordSchemaPath + "Period", 
				{value: data.periodId, displayValue: data.periodTitle}, this.BPMSoft.DataValueType.LOOKUP));
			const serializationInfo = filtersGroup.getDefSerializationInfo();
			serializationInfo.serializeFilterManagerInfo = true;
			return filtersGroup.serialize(serializationInfo);
		},
		
		/**
		 * Handles go to section action click.
		 * @param data
		 */
		goToSectionClicked: function(data) {
			const moduleInfo = this.BPMSoft.configuration.ModuleStructure[data.entitySchemaName] || {};
			const sectionSchema =  moduleInfo.sectionSchema;
			const navigationHelper = this.Ext.create("BPMSoft.NavigationHelper", {
				Ext: this.Ext,
				sandbox: this.sandbox
			});
			const navigationConfig = {
				target: "Section",
				options: {
					sectionSchema: moduleInfo.sectionSchema,
					filters: {
							"ForecastColumn":  {
								"displayValue": data.title,
								"value": data.title,
								"filter": this.getObjectValueFilterString(data)
							}
					},
					hideFilterBlock: true
				}
			};
			navigationHelper.navigateTo(navigationConfig);
		},

		/**
		 * Handles inner exception.
		 * @param info Exception information.
		 */
		handleInnerException: function(info) {
			this.showInformationDialog(info.message);
		},

		/**
		 * Handles cell selection.
		 * @param {Object} data Cell selected data.
		 */
		onCellSelected: function(data) {
			this.sandbox.publish("CellSelected", data, [this.sandbox.id]);
		}

	});

	return BPMSoft.ForecastItemViewModel;

});
