define("EntityProductCountMixin", [], function() {
	/**
	 * @class BPMSoft.configuration.mixins.EntityProductCountMixin
	 * Mixin for products count by entity.
	 */
	Ext.define("BPMSoft.configuration.mixins.EntityProductCountMixin", {
		alternateClassName: "BPMSoft.EntityProductCountMixin",

		/**
		 * Aggregation column name.
		 * @private
		 */
		aggregationColumnName: "ProductsCount",

		/**
		 * Returns column name of products count in entity schema.
		 * @protected
		 * @return {String} Column name.
		 */
		getProductCountInEntityColumnName: function() {
			return this.aggregationColumnName;
		},

		/**
		 * Returns dependent entity schema name.
		 * @protected
		 * @return {String} Dependent entity schema name.
		 */
		getDependentEntitySchemaName: function() {
			return this.entitySchemaName;
		},

		/**
		 * Returns products in entity schema column name.
		 * @protected
		 * @return {String} Products in entity schema column name.
		 */
		getEntityProductSchemaColumnName: function() {
			return this.getDependentEntitySchemaName();
		},

		/**
		 * Returns products in entity schema name.
		 * @protected
		 * @return {String} Products in entity schema name.
		 */
		getEntityProductSchemaName: function() {
			var schemaName = this.getDependentEntitySchemaName();
			return schemaName + "Product";
		},

		/**
		 * Returns entity schema query for getting product count.
		 * @protected
		 * @param {Guid} primaryColumnValue Unique record identifier.
		 * @return {BPMSoft.EntitySchemaQuery} Entity schema query.
		 */
		getProductCountQuery: function(primaryColumnValue) {
			var entityProductSchemaName = this.getEntityProductSchemaName();
			var entityProductSchemaColumnName = this.getEntityProductSchemaColumnName();
			var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: entityProductSchemaName
			});
			this.setAggregationSchemaColumn(esq);
			esq.filters.add(entityProductSchemaColumnName, this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL, entityProductSchemaColumnName, primaryColumnValue));
			return esq;
		},

		/**
		 * Sets aggregation column in query.
		 * @param {BPMSoft.EntitySchemaQuery} esq Entity schema query.
		 */
		setAggregationSchemaColumn: function(esq) {
			esq.addAggregationSchemaColumn("Id", this.BPMSoft.AggregationType.COUNT, this.aggregationColumnName);
		},

		/**
		 * Sets products count.
		 * @protected
		 * @param {Guid} primaryColumnValue Unique record identifier.
		 * @param {Function} [callback] The callback function.
		 * @param {Object} [scope] Environment object callback function.
		 */
		setProductCount: function(primaryColumnValue, callback, scope) {
			var esq = this.getProductCountQuery(primaryColumnValue);
			esq.getEntityCollection(function(response) {
				if (response.success) {
					var collection = response.collection;
					if (collection && collection.getCount() > 0) {
						var firstItem = collection.getByIndex(0);
						var entityColumnName = this.getProductCountInEntityColumnName();
						if (entityColumnName) {
							var productsCount = firstItem.get(this.aggregationColumnName);
							this.set(entityColumnName, productsCount, {silent: true});
						}
					}
				}
				this.Ext.callback(callback, scope || this);
			}, this);
		}

	});
});
