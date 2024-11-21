define("TimeToPrioritizeDetailV2", ["TimeToPrioritizeDetailV2Resources", "BPMSoft",
	"TimeToPrioritize", "ConfigurationGrid", "ConfigurationGridGenerator",
	"ConfigurationGridUtilities"], function() {
	return {
		entitySchemaName: "TimeToPrioritize",
		attributes: {
			"IsEditable": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: true
			}
		},
		diff: [
			{
				"operation": "merge",
				"name": "DataGrid",
				"values": {
					"className": "BPMSoft.ConfigurationGrid",
					"generator": "ConfigurationGridGenerator.generatePartial",
					"generateControlsConfig": {"bindTo": "generateActiveRowControlsConfig"},
					"changeRow": {"bindTo": "changeRow"},
					"unSelectRow": {"bindTo": "unSelectRow"},
					"onGridClick": {"bindTo": "onGridClick"},
					"activeRowActions": [
						{
							"className": "BPMSoft.Button",
							"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							"tag": "save",
							"markerValue": "save",
							"imageConfig": {"bindTo": "Resources.Images.SaveIcon"}
						},
						{
							"className": "BPMSoft.Button",
							"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							"tag": "cancel",
							"markerValue": "cancel",
							"imageConfig": {"bindTo": "Resources.Images.CancelIcon"}
						},
						{
							"className": "BPMSoft.Button",
							"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							"tag": "remove",
							"markerValue": "remove",
							"imageConfig": {"bindTo": "Resources.Images.RemoveIcon"}
						}
					],
					"initActiveRowKeyMap": {"bindTo": "initActiveRowKeyMap"},
					"activeRowAction": {"bindTo": "onActiveRowAction"}
				}
			}
		],
		mixins: {
			ConfigurationGridUtilites: "BPMSoft.ConfigurationGridUtilities"
		},
		methods: {
			/**
			 * Run base saveRowChanges from mixin.
			 * @private
			 */
			runSaveRowChanges: function(args) {
				this.mixins.ConfigurationGridUtilites.saveRowChanges.apply(this, args);
			},

			/**
			 * Show message-box.
			 * @param {String} message - message name.
			 * @private
			 */
			showMessageBox: function(message) {
				this.BPMSoft.utils.showInformation(this.get("Resources.Strings." + message + ""));
			},

			/**
			 * Validate handler.
			 * @private
			 * @param {Array} args - arguments from saveRowChanges.
			 * @param {object} resultQuery - result from getEntityCollection.
			 */
			validateCasePriorityHandler: function(args, resultQuery) {
				if (resultQuery.success && resultQuery.collection.getItems()[0].get("Count") > 0) {
					this.showMessageBox("CasePriorityIsExist");
				} else {
					this.runSaveRowChanges(args);
				}
			},

			/**
			 * @inheritdoc BPMSoft.ConfigurationGridUtilities#saveRowChanges
			 * @overridden
			 */
			saveRowChanges: function(row) {
				var args = arguments;
				if (!Ext.isObject(row)) {
					this.runSaveRowChanges(args);
				} else {
					if (this.IsResponceOrReactionEmpty(row)) {
						if (Ext.isEmpty(row.get("CasePriority"))) {
							this.showMessageBox("CasePriorityIsNotFilling");
							return;
						}
						this.validationForUniquenessCasePriorityName(args, row,
								this.validateCasePriorityHandler);
					} else {
						this.showMessageBox("ResponceOrReactionFillingFalse");
					}
				}
			},

			/**
			 * Add service in service pact filter.
			 * @private
			 * @param {object} activeRow - active row object.
			 * @param {object} query - "BPMSoft.EntitySchemaQuery".
			 * @param {object} filterGroup - "BPMSoft.FilterGroup".
			 */
			addServiceInServicePactFilter: function(activeRow, query, filterGroup) {
				var serviceInServicePact = activeRow.get("ServiceInServicePact") &&
					activeRow.get("ServiceInServicePact").value;
				if (serviceInServicePact) {
					filterGroup.addItem(query.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
							"ServiceInServicePact", serviceInServicePact));
				}
			},

			/**
			 * Validate that casePrority column value has no duplicates.
			 * @private
			 * @param {Function} callback -  function this.validateCasePriorityHandler.
			 * @param {Array} args - arguments from saveRowChanges.
			 * @param {object} activeRow - active row object.
			 */
			validationForUniquenessCasePriorityName: function(args, activeRow, callback) {
				var id = activeRow.get("Id");
				var casePriority = activeRow.get("CasePriority").value;
				var query = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "TimeToPrioritize"
				});
				query.addAggregationSchemaColumn("Id", this.BPMSoft.AggregationType.COUNT, "Count");
				var duplicatesFilter = query.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "CasePriority", casePriority);
				var notSelfFilter = query.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.NOT_EQUAL, "Id", id);
				var filterGroup = this.Ext.create("BPMSoft.FilterGroup");
				filterGroup.logicalOperation = BPMSoft.LogicalOperatorType.AND;
				filterGroup.addItem(notSelfFilter);
				filterGroup.addItem(duplicatesFilter);
				this.addServiceInServicePactFilter(activeRow, query, filterGroup);
				query.filters.addItem(filterGroup);
				query.getEntityCollection(function(resultQuery) {
					callback.call(this, args, resultQuery);
				}, this);
			},

			/**
			 * Validate that responce or reaction filling.
			 * @private
			 * @param {object} activeRow - active row object.
			 */
			IsResponceOrReactionEmpty: function(activeRow) {
				var reactionTime = activeRow.get("ReactionTimeUnit");
				var reactionValue = activeRow.get("ReactionTimeValue");
				var solutionTime = activeRow.get("SolutionTimeUnit");
				var solutionValue = activeRow.get("SolutionTimeValue");
				return (reactionValue > 0 && reactionTime) || (solutionValue > 0 && solutionTime);
			}
		}
	};
});
