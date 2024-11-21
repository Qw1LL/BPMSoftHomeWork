define("OpportunityCompetitorPageV2", ["ConfigurationConstants", "AccountLookupMiniPageMixin"],
	function(ConfigurationConstants) {
		function updateViewModel() {
			if (!this.BPMSoft.isCurrentUserSsp()) {
				return;
			}
			const lookupInfo = this.getLookupInfo();
			lookupInfo.bindAccountMiniPage(lookupInfo, this);
		}
		return {
			entitySchemaName: "OpportunityCompetitor",
			attributes: {
				"Supplier": {
					"lookupListConfig": {
						hideActions: true,
						updateViewModel: updateViewModel
					}
				},
				"Competitor": {
					"lookupListConfig": {
						hideActions: true,
						updateViewModel: updateViewModel
					}
				}
			},
			mixins: {
				AccountLookupMiniPageMixin: "BPMSoft.AccountLookupMiniPageMixin"
			},
			methods: {

				/**
				 * @inheritdoc BPMSoft.LookupQuickAddMixin#getLookupPageConfig
				 * @overriden
				 */
				getLookupPageConfig: function() {
					const config = this.callParent(arguments);
					if (BPMSoft.isCurrentUserSsp() && this.isAccountLookupColumn(config.columnName)) {
						this.applyAccountMiniPageDefValues(config);
						this.applyLookupCustomConfig(config);
						return config;
					}
					return config;
				},

				/**
				 * Applies default values to the column from lookup config.
				 * @param {Object} config Lookup config.
				 */
				applyAccountMiniPageDefValues: function (config) {
					const defValues = this.getAccountMiniPageDefValues();
					this.Ext.apply(config, {miniPageDefValues: defValues[config.columnName] || []});
				},

				/**
				 * Returns default mini page values for all account columns.
				 * @returns {Object} Default values.
				 */
				getAccountMiniPageDefValues: function () {
					return {
						"Supplier": [{
							"name": "Type",
							"value": ConfigurationConstants.AccountType.Competitor
						}]
					}
				},

				/**
				 * @inheritdoc BPMSoft.LookupQuickAddMixin#getPreventQuickAddSchemaNames
				 * @overridden
				 */
				getPreventQuickAddSchemaNames: function () {
					const schemas = this.callParent(arguments);
					schemas.push("Account");
					return schemas;
				}
			},
			diff: /**SCHEMA_DIFF*/[
			]/**SCHEMA_DIFF*/
		};
	});
