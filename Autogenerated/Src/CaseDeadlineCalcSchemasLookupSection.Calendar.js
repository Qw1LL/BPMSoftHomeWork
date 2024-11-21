define("CaseDeadlineCalcSchemasLookupSection", ["CaseDeadlineCalcSchemasLookupSectionResources",
	"ConfigurationEnums", "ConfigurationGrid", "ConfigurationGridGenerator",
			"ConfigurationGridUtilities"],
	function() {
		return {
			entitySchemaName: "DeadlineCalcSchemas",
			attributes: {},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "remove",
					"name": "activeRowActionCopy"
				},
				{
					"operation": "remove",
					"name": "activeRowActionCard"
				}

			]/**SCHEMA_DIFF*/,
			messages: {},
			methods: {

				/**
				 * Remove sign of default strategy
				 * @private
				 * @param {GUID} id
				 */
				removeDefaultStatus: function(id) {
					var update = this.Ext.create("BPMSoft.UpdateQuery", {
						rootSchemaName: "DeadlineCalcSchemas"
					});
					update.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.NOT_EQUAL, "Id", id));
					update.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL, "Default", 1));
					update.setParameterValue("Default", 0, this.BPMSoft.DataValueType.BOOLEAN);
					update.execute(function(result) {
						if(result && result.success){
							this.reloadGridData();
						}
					}, this);
				},

				/**
				 * @inheritdoc ConfigurationGridUtilitiesV2#saveRowChanges
				 * overriden
				 */
				saveRowChanges: function(row, callback, scope) {
					var changedValues = row && row.changedValues;
					var needUpdate = changedValues && changedValues.hasOwnProperty("Default") && changedValues.Default;
					this.callParent([row, function() {
						this.validationOkCallback.call(this, needUpdate, row, callback);
					}, scope]);
				},

				/**
				 * Call method for deleting sing of default strategy
				 * private
				 * @param {Boolean} needUpdate sign for changing default strategy
				 * @param {Object} row active row
				 * @param {Function} callback
				 */
				validationOkCallback: function(needUpdate, row, callback) {
					if (needUpdate) {
						var id = row.get("Id");
						this.removeDefaultStatus(id);
					}
					if (Ext.isFunction(callback)) {
						callback.call(this, arguments);
					}
				},

				/**
				 * @inheritdoc GridUtilitiesV2#deleteRecords
				 * overriden
				 */
				deleteRecords: function() {
					if(this.getActiveRow().get("Default")){
						BPMSoft.utils.showInformation(this.get("Resources.Strings.RemoveDefaultStrategyMessage"));
						return;
					}
					this.callParent(arguments);
				}
			}
		};
	});
