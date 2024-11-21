define("AccountAnniversaryDetailV2", [], function() {
	return {
		entitySchemaName: "AccountAnniversary",
		methods: {

			/**
			 * ########## ### ####### ### ########## ## #########.
			 * @overridden
			 * @return {String} ### #######.
			 */
			getFilterDefaultColumnName: function() {
				return "AnniversaryType";
			}
		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
