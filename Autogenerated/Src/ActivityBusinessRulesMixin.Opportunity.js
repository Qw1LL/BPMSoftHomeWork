define("ActivityBusinessRulesMixin", ["ext-base"], function(Ext) {
	Ext.define("BPMSoft.configuration.mixins.ActivityBusinessRulesMixin", {
		alternateClassName: "BPMSoft.ActivityBusinessRulesMixin",

		/**
		 * Sets Contact and Account values by corresponds Opportunity fields.
		 * @private
		 */
		setContactAndAccountByOpportunity: function() {
			var opportunity = this.get("Opportunity");
			if (this.Ext.isEmpty(opportunity)) {
				return;
			}
			var account = opportunity.Account;
			if (!this.Ext.isEmpty(account)) {
				this.set("Account", account);
			}
			var contact = opportunity.Contact;
			if (!this.Ext.isEmpty(contact)) {
				this.set("Contact", contact);
			}
		},

		/**
		 * Generates Opportunity attribute filters.
		 * @private
		 * @return {BPMSoft.FilterGroup}
		 */
		getOpportunityFilters: function() {
			var account = this.get("Account");
			var contact = this.get("Contact");
			var filterGroup = this.BPMSoft.createFilterGroup();
			filterGroup.logicalOperation = this.BPMSoft.LogicalOperatorType.OR;
			if (account && !this.Ext.isEmpty(account.value)) {
				filterGroup.add("AccountFilter", this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL,
					"Account",
					account.value)
				);
			}
			if (contact && !this.Ext.isEmpty(contact.value)) {
				filterGroup.add("ContactFilter", this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL,
					"Contact",
					contact.value)
				);
			}
			return filterGroup;
		}
	});
});
