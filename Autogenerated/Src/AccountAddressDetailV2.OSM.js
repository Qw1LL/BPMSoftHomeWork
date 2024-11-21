define("AccountAddressDetailV2", [], function() {
	return {
		entitySchemaName: "AccountAddress",
		diff: /**SCHEMA_DIFF*/ [] /**SCHEMA_DIFF*/,
		methods: {

			/**
			 * @inheritdoc BPMSoft.GridUtilitiesV2#addGridDataColumns
			 * @overridden
			 */
			addGridDataColumns: function(esq) {
				this.callParent(arguments);
				esq.addColumn("GPSN");
				esq.addColumn("GPSE");
			}
		}
	};
});
