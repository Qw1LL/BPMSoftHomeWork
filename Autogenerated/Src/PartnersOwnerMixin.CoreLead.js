define("PartnersOwnerMixin", ["ConfigurationConstants"], function(ConfigurationConstants) {
	/**
	 * @class BPMSoft.configuration.mixins.PartnersOwnerMixin
	 * Mixin represents methods for partners owners.
	 */
	Ext.define("BPMSoft.configuration.mixins.PartnersOwnerMixin", {
		alternateClassName: "BPMSoft.PartnersOwnerMixin",

		/**
		 * Value to compare with check column
		 * @protected
		 */
		typeColumnCheckValue: ConfigurationConstants.Opportunity.Type.PartnerSale,

		/**
		 * Column in which the link to the partner is stored
		 * @protected
		 */
		partnerColumnName: "Partner",

		/**
		 * Returns filter for Owner field.
		 * @param {String} typeColumnName Name of column that contains type of sales value.
		 * @return {BPMSoft.FilterGroup} Owner filter.
		 */
		getOwnerFilter: function(typeColumnName) {
			const userFilter = this.BPMSoft.createColumnIsNotNullFilter("[VwSystemUsers:Contact].Id");
			const filters = this.BPMSoft.createFilterGroup();
			filters.add("isUserFilter", userFilter);
			if (!this._isPartnerSalesChannel(typeColumnName)) {
				const connectionTypeFilter =
					this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
					"[VwSystemUsers:Contact].ConnectionType",
					ConfigurationConstants.SysAdminUnit.ConnectionType.AllEmployees);
				filters.add("connectionTypeFilter", connectionTypeFilter);
			}
			const partner = this.get(this.partnerColumnName) && this.get(this.partnerColumnName).value;
			if (this._isPartnerSalesChannel(typeColumnName) && partner) {
				const partnerFilters = this.getPartnerFilters(partner);
				filters.add("PartnersFilters", partnerFilters);
			}
			return filters;
		},

		/**
		 * Get filters dependent on current partner.
		 * @param {String} partner Identifier of partner account.
		 * @returns {BPMSoft.FilterGroup} Group of filters dependent on current partner.
		 */
		getPartnerFilters: function(partner) {
			const filterGroup = this.BPMSoft.createFilterGroup();
			filterGroup.logicalOperation = this.BPMSoft.LogicalOperatorType.OR;
			const partnerContactsFilter = this.BPMSoft.createColumnFilterWithParameter(
				BPMSoft.ComparisonType.EQUAL, "Account", partner);
			filterGroup.add("PartnersContactsFilter", partnerContactsFilter);
			const ourCompanyFilter = BPMSoft.createColumnFilterWithParameter(
				BPMSoft.ComparisonType.EQUAL, "Account.Type",
				ConfigurationConstants.AccountType.OurCompany);
			filterGroup.add("OurCompanyFilter", ourCompanyFilter);
			return filterGroup;
		},

		/**
		 * Clear partner if column value is not a partner sale.
		 * @param {String} typeColumnName Name of column that contains type of sales value.
		 */
		clearPartnerIfColumnChange: function(typeColumnName) {
			const column = this.get(typeColumnName);
			if (column && column.value !== this.typeColumnCheckValue) {
				this.set(this.partnerColumnName, null);
			}
		},

		/**
		 * Fills owner by partner contact.
		 */
		autoCompleteOwner: function() {
			const partner = this.get(this.partnerColumnName);
			const partnerId = partner && partner.value;
			if (this.Ext.isEmpty(partnerId) || !this.$IsEntityInitialized) {
				return;
			}
			const ownerAccountId = this.$Owner && this.$Owner.Account && this.$Owner.Account.value;
			if (ownerAccountId === partnerId) {
				return;
			}
			const partnerPrimaryContact = partner &&
				partner["[VwSystemUsers:Contact:PrimaryContact].Contact"];
			this.$Owner = this.Ext.isEmpty(partnerPrimaryContact) ? null : partnerPrimaryContact;
		},

		/**
		 * Fill partner by owner account if it is a partner account type.
		 */
		fillPartnerByOwner: function() {
			const ownerAccountId = this.$Owner && this.$Owner.Account;
			const ownerAccountType = this.$Owner["Account.Type"] && this.$Owner["Account.Type"].value;
			if (!this.Ext.isEmpty(ownerAccountType) && !this.Ext.isEmpty(ownerAccountId) &&
				(ownerAccountType.toUpperCase() === ConfigurationConstants.AccountType.Partner.toUpperCase())) {
				this.set(this.partnerColumnName, ownerAccountId);
			}
		},

		/**
		 * Initialize mixin default values
		 * @param {String} partnerColumnName Column in which the link to the partner is stored.
		 * @param {String} typeColumnCheckValue Value to compare with check column.
		 */
		initializeDefaultValues: function(partnerColumnName, typeColumnCheckValue) {
			this.partnerColumnName = partnerColumnName;
			this.typeColumnCheckValue = typeColumnCheckValue;
		},

		/**
		 * @private
		 */
		_isPartnerSalesChannel: function(typeColumnName) {
			const salesChannel = this.get(typeColumnName) && this.get(typeColumnName).value;
			return salesChannel === this.typeColumnCheckValue;
		}

	});
});
