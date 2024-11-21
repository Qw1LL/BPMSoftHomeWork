define("PercentageIndicatorModule", ["SimpleIndicatorModule", "PercentageIndicatorModuleResources"],
	function() {

		/**
		 * ##### ###### ############# ### ###### ##########.
		 */
		Ext.define("BPMSoft.configuration.PercentageIndicatorViewModel", {
			extend: "BPMSoft.SimpleIndicatorViewModel",
			alternateClassName: "BPMSoft.PercentageIndicatorViewModel",

			/**
			 * ######### ####### ######.
			 * @overridden
			 * @virtual
			 * @return {BPMSoft.EntitySchemaQuery} select C####### ######### # ############### ######.
			 */
			createSelect: function() {
				var select = this.callParent(arguments);
				var dividerColumn = this.get("dividerColumnName");
				select.addAggregationSchemaColumn(dividerColumn, BPMSoft.AggregationType.SUM, "weight");
				return select;
			},

			/**
			 * ######### ########## ########## ##########.
			 * @overridden
			 * @param {Function} callback #######, ####### ##### ####### ## ##########.
			 * @param {Object} scope ########, # ####### ##### ####### ####### callback.
			 */
			prepareWidget: function(callback, scope) {
				var select = this.createSelect();
				if (select) {
					select.getEntityCollection(function(response) {
						if (!response.success || this.destroyed) {
							return;
						}
						var resultEntity = response.collection.getByIndex(0);
						var resultValue = resultEntity.get("value");
						var totalWeight = resultEntity.get("weight") || 1;
						var value = (resultValue / totalWeight);
						var valuePropertyName = this.get("valuePropertyName") || "value";
						var totalAmountPropertyName = this.get("totalAmountPropertyName") || "totalAmount";
						if (valuePropertyName !== totalAmountPropertyName) {
							this.set(valuePropertyName, value);
							this.set(totalAmountPropertyName, resultValue);
						}
						callback.call(scope);
					}, this);
				} else {
					callback.call(scope);
				}
			}

		});

		/**
		 * ###### ########## ####### Email.
		 */
		Ext.define("BPMSoft.configuration.PercentageIndicatorModule", {
			extend: "BPMSoft.SimpleIndicatorModule",
			alternateClassName: "BPMSoft.PercentageIndicatorModule",

			/**
			 * ### ###### ###### ############# ### ###### ##########.
			 * @type {String}
			 */
			viewModelClassName: "BPMSoft.PercentageIndicatorViewModel",

			/**
			 * ### ##### ########## ############ ############# ###### ##########.
			 * @type {String}
			 */
			viewConfigClassName: "BPMSoft.SimpleIndicatorViewConfig"

		});

		return BPMSoft.PercentageIndicatorModule;
	});
