define("ConfigurationGridLookupUtilities", [], function() {
	Ext.define("BPMSoft.configuration.mixins.ConfigurationGridLookupUtilities", {

		alternateClassName: "BPMSoft.ConfigurationGridLookupUtilities",

		/**
		 * Returns the filter by a unique column (default is UId).
		 * @protected
		 * @param {Object} columnValue Value of column.
		 * @return {BPMSoft.BaseFilter} Filter by column UId.
		 */
		getQueryUniqueColumnFilter: function(columnValue) {
			return this.BPMSoft.createColumnFilterWithParameter(
				this.BPMSoft.ComparisonType.EQUAL, "UId", columnValue);
		},

		/**
		 * Loads the value of virtual schema column.
		 * @protected
		 * @virtual
		 * @param {String} lookupName Name of the virtual model column on which you want to get the value.
		 * @param {String} columnName Name of a column, value of which will be used in the filter
		 * when building a query.
		 * @param {Function} callback The function to be called after setting the value to the model.
		 * @param {Object} scope The context in which callback function is called.
		 */
		loadVirtualColumnValues: function(lookupName, columnName, callback, scope) {
			var columnValue = this.get(columnName);
			if (!this.Ext.isEmpty(columnValue) && this.BPMSoft.isGUID(columnValue)) {
				var column = this.columns[lookupName];
				var lookupQuery = this.getLookupQuery(null, column.name, column.isLookup);
				lookupQuery.filters.addItem(this.getQueryUniqueColumnFilter(columnValue));
				lookupQuery.getEntityCollection(function(result) {
					var value = null;
					if (result.success && !result.collection.isEmpty()) {
						var resultValue = result.collection.getByIndex(0);
						value = resultValue.values;
					}
					this.set(lookupName, value);
					if (this.Ext.isFunction(callback)) {
						callback.call(scope || this, this);
					}
				}, this);
			} else {
				this.set(lookupName, null);
				if (this.Ext.isFunction(callback)) {
					callback.call(scope || this, this);
				}
			}
		}
	});
});
