define("ContactMiniPage", ["ContactDuplicateSearchMixin"], function() {
	return {
		entitySchemaName: "Contact",
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		attributes: {},
		mixins: {
			ContactDuplicateSearchMixin: "BPMSoft.ContactDuplicateSearchMixin"
		},
		methods: {

			/**
			 * @inheritdoc BPMSoft.DuplicatesSearchUtilitiesV2#getFilterValue
			 * @override
			 */
			getFilterValue: function(filter) {
				if (this.isDuplicateRuleByName(filter)) {
					return this.getContactNameForSearchDuplicates();
				}
				return this.callParent(arguments);
			}
		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
