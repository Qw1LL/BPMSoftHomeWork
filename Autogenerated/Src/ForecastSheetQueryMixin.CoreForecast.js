define("ForecastSheetQueryMixin", [], function() {
	Ext.define("BPMSoft.configuration.mixins.ForecastSheetQueryMixin", {
		alternateClassName: "BPMSoft.ForecastSheetQueryMixin",

		getForecastSchemaName: function() {
			return "ForecastSheet";
		},

		/**
		 * Generates esq for forecasts.
		 * @protected
		 * @virtual
		 */
		getForecastsEsq: function() {
			const esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: this.getForecastSchemaName()
			});
			esq.addColumn("Id");
			const nameColumn = esq.addColumn("Name");
			nameColumn.orderPosition = 1;
			nameColumn.orderDirection = this.BPMSoft.OrderDirection.ASC;
			esq.addColumn("ForecastEntity.Id", "ForecastEntityId");
			esq.addColumn("ForecastEntity.Name", "ForecastEntityName");
			esq.addColumn("Setting");
			esq.addColumn("ForecastEntityInCellUId");
			return esq;
		}
	});
});
