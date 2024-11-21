define("DuplicatesRulePageV2", function() {
	return {
		entitySchemaName: "DuplicatesRule",
		methods: {
			/**
			 * @inheritdoc DuplicatesRulePageV2#getObjectFilterByNameParameters
			 * @overridden
			 */
			getObjectFilterByNameParameters: function() {
				var result = this.callParent(arguments);
				result.push("Lead");
				return result;
			}
		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
