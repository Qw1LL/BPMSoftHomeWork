 define("EmailItemSchema", [], function() {
	return {
		methods: {

			/**
			 * @inheritdoc BPMSoft.EmailItemSchema#getEntityDefaultValueColumnValue
			 * @overridden
			 */
			getEntityDefaultValueColumnValue: function(schemaName, entity) {
				if (schemaName === "Lead") {
					return entity.displayValue;
				}
				return this.callParent(arguments);
			}
		}
	};
});
