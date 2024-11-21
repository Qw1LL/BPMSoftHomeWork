define("ServiceFilterMixin", [], function() {
	/**
	 * @class BPMSoft.configuration.mixins.ServiceFilterMixin
	 * Service Filter mixin.
	 */
	Ext.define("BPMSoft.configuration.mixins.ServiceFilterMixin", {
		alternateClassName: "BPMSoft.ServiceFilterMixin",

		/**
		 * Contact Id.
		 */
		contact: null,

		/**
		 * Account Id.
		 */
		account: null,

		/**
		 * Department Id.
		 */
		department: null,

		// region Methods: Protected

		/**
		 * Returns service item filter by account.
		 * @protected
		 * @returns {BPMSoft.FilterGroup} Filter group
		 */
		getServicesFilterByAccount: function() {
			const accountFilterGroup = new BPMSoft.createFilterGroup();
			if (this.account) {
				accountFilterGroup.add("AccountFilter", BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "Account", this.account.value));
			}
			return accountFilterGroup;
		},

		/**
		 * Returns service item filter by department.
		 * @protected
		 * @returns {BPMSoft.FilterGroup} Filter group
		 */
		getServicesFilterByDepartment: function() {
			const filters = new BPMSoft.createFilterGroup();
			filters.logicalOperation = BPMSoft.LogicalOperatorType.OR;
			filters.add("DepartmentNullFilter", BPMSoft.createColumnIsNullFilter("Department"));
			if (this.department) {
				filters.add("DepartmentFilter", BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "Department", this.department.value));
			}
			return filters;
		},

		//endregion

		// region Methods: Public

		/**
		 * Returns service item filter.
		 * @param {String} notExistsFilterColumnName Column name of existing filter.
		 * @param {String} reverseSchemaPath Reverse path to main schema.
		 * @public
		 * @returns {BPMSoft.FilterGroup} Filter group
		 */
		getServicesFilter: function(notExistsFilterColumnName, reverseSchemaPath) {
			const filterGroup = new BPMSoft.createFilterGroup();
			const contactGroup = new BPMSoft.createFilterGroup();
			filterGroup.logicalOperation = BPMSoft.LogicalOperatorType.OR;
			contactGroup.add("ContactFilter", BPMSoft.createColumnFilterWithParameter(
				BPMSoft.ComparisonType.EQUAL, "Contact", this.contact)
			);
			if (this.account) {
				const accountFilterGroup = this.getServicesFilterByAccount();
				const departmentFilters = this.getServicesFilterByDepartment();
				accountFilterGroup.add("Department", departmentFilters);
				if (!Ext.isEmpty(notExistsFilterColumnName) && !Ext.isEmpty(reverseSchemaPath)) {
					const subFilters = BPMSoft.createFilterGroup();
					subFilters.addItem(BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, reverseSchemaPath + ".Contact.Id", this.contact));
					const notExistFilter = BPMSoft.createNotExistsFilter(notExistsFilterColumnName, subFilters);
					accountFilterGroup.add("NotExisting", notExistFilter);
				}
				filterGroup.add("AccountGroupFilter", accountFilterGroup);
			}
			filterGroup.add("ContactGroupFilter", contactGroup);
			return filterGroup;
		},

		/**
		 * Initializes the initial values of the mixin.
		 * @public
		 */
		init: function(config) {
			this.contact = config.contact;
			this.account = config.account;
			this.department = config.department;
		}

		//endregion

	});

	return BPMSoft.ServiceFilterMixin;
});
