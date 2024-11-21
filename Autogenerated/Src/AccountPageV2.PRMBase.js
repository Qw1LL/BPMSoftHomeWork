define("AccountPageV2", ["ConfigurationConstants"],
	function(ConfigurationConstants) {
		return {
			entitySchemaName: "Account",
			details: /**SCHEMA_DETAILS*/ {
				Partnerships: {
					schemaName: "PartnershipDetail",
					filter: {
						masterColumn: "Id",
						detailColumn: "Account"
					}
				}
			} /**SCHEMA_DETAILS*/ ,
			methods: {

				/**
				 * Indicates visibility of Partnership detail.
				 * @returns {boolean} True if detail visible.
				 */
				isPartnershipsDetailVisible: function () {
					const type = this.$Type && this.$Type.value;
					return type === ConfigurationConstants.AccountType.Partner.toLowerCase();
				}
			},
			diff: /**SCHEMA_DIFF*/ [{
				"operation": "insert",
				"parentName": "HistoryTabContainer",
				"index": 0,
				"propertyName": "items",
				"name": "Partnerships",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.DETAIL,
					"visible": { "bindTo": "isPartnershipsDetailVisible" }
				}
			}] /**SCHEMA_DIFF*/ ,
			rules: {}
		};
	});
