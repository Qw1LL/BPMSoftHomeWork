define("PartnershipPage", ["ConfigurationConstants", "PRMEnums", "css!PartnershipCommonCSS"],
	function(ConfigurationConstants) {
		return {
			entitySchemaName: "Partnership",
			methods: {

				/**
				 * Adds filters for invoice detail
				 * @private
				 */
				invoiceDetailFilter: function() {
					var generalFilterGroup = new this.BPMSoft.createFilterGroup();
					generalFilterGroup.name = "generalFilterGroup";
					generalFilterGroup.logicalOperation = this.BPMSoft.LogicalOperatorType.AND;
					var invoiceFilterGroup = new this.BPMSoft.createFilterGroup();
					invoiceFilterGroup.name = "invoiceFilterGroup";
					var accountFilterGroup = new this.BPMSoft.createFilterGroup();
					accountFilterGroup.name = "accountFilterGroup";
					var partnerAccountFilterGroup = new this.BPMSoft.createFilterGroup();
					partnerAccountFilterGroup.name = "partnerAccountFilterGroup";
					partnerAccountFilterGroup.logicalOperation = this.BPMSoft.LogicalOperatorType.OR;
					var account = this.get("Account");
					var startDate = this.get("StartDate");
					var dueDate = this.get("DueDate");
					if (!this.Ext.isEmpty(account) && !this.Ext.isEmpty(startDate) && !this.Ext.isEmpty(dueDate)) {
						accountFilterGroup.add("AccountFilter", this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL, "Account", account.value));
						invoiceFilterGroup.add("OpportunityFilter", this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL, "[Opportunity:Id:Opportunity].Partner", account.value));
						invoiceFilterGroup.add("OpportunityTypeFilter", this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL,
							"[Opportunity:Id:Opportunity].Type", ConfigurationConstants.Opportunity.Type.PartnerSale));
						partnerAccountFilterGroup.add("accountFilterGroup", accountFilterGroup);
						partnerAccountFilterGroup.add("invoiceFilterGroup", invoiceFilterGroup);
						generalFilterGroup.add("partnerAccountFilterGroup", partnerAccountFilterGroup);
						generalFilterGroup.add("StartDateFilter", this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.GREATER_OR_EQUAL, "StartDate", startDate));
						generalFilterGroup.add("DueDateFilter", this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.LESS_OR_EQUAL, "DueDate", dueDate));
					}
					else {
						generalFilterGroup.add("InvoiceIdIsNullFilter", this.BPMSoft.createColumnIsNullFilter("Id"));
					}
					return generalFilterGroup;
				}
			},
			diff: /**SCHEMA_DIFF*/[
			]/**SCHEMA_DIFF*/
		};
	});
