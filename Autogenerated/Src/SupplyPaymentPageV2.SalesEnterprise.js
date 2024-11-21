define("SupplyPaymentPageV2", [],
	function() {
		return {
			entitySchemaName: "SupplyPaymentElement",
			attributes: {
				/**
				 * #### ###### # ######.
				 */
				"Order": {
					lookupListConfig: {
						columns: ["Currency", "CurrencyRate", "Currency.Division", "Contact", "Account", "Opportunity"]
					}
				}
			}
		};
	}
);
