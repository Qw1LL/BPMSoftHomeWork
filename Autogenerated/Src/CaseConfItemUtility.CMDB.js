define("CaseConfItemUtility", [],
	function() {
		/**
		 * @class BPMSoft.configuration.mixins.CaseConfItemUtility
		 * Mixin, that implements work with configuration item on page.
		 */
		Ext.define("BPMSoft.configuration.mixins.CaseConfItemUtility", {
			alternateClassName: "BPMSoft.CaseConfItemUtility",
			/**
			 * Forms configuration item's collection.
			 * @protected
			 * @param {String} filter configuration item's collection filter.
			 * @param {String} list configuration item's collection.
			 */
			onPrepareConfItem: function(filter, list) {
				var contact = this.get("Contact");
				if (!contact || !contact.value) {
					return;
				}
				var query = this.getConfItemQuery(contact.value);
				query.getEntityCollection(function(result) {
					this.fillConfItemCollection(result, list);
				}, this);
			},

			/**
			 * Forms query that select suitable configuration items.
			 * @protected
			 * @param {String} contactId Contact identifier.
			 * @return {BPMSoft.EntitySchemaQuery} Query that select suitable configuration items.
			 */
			getConfItemQuery: function(contactId) {
				var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "ConfItem"
				});
				esq.addColumn("Id");
				esq.addColumn("Name");
				esq.filters.add("ConfItemUser", this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL, "[ConfItemUser:ConfItem].Contact", contactId));
				return esq;
			},

			/**
			 * Fills the configuration items collection.
			 * @protected
			 * @param {Function} esq Query that select suitable configuration item.
			 * @param {BPMSoft.BaseSchemaViewModel} scope Execution context of callback function.
			 * @param {String} list Configuration items collection.
			 */
			fillConfItemCollection: function(result, list) {
				var entities = result.collection.getItems();
				var items = {};
				this.BPMSoft.each(entities, function(entity) {
					var primaryValue = entity.get("Id");
					var primaryDisplayValue = entity.get("Name");
					items[primaryValue] = {
						value: primaryValue,
						displayValue: primaryDisplayValue
					};
				});
				list.clear();
				list.loadAll(items);
			},

			/**
			 * Returns configuration item filter group.
			 * @protected
			 * @returns {BPMSoft.FilterGroup} Filter group.
			 */
			getConfItemFilters: function() {
				var filterGroup = new this.BPMSoft.createFilterGroup();
				filterGroup.logicalOperation = this.BPMSoft.LogicalOperatorType.OR;
				var contact = this.get("Contact");
				this.addConfItemFilterByContact(contact, filterGroup);
				var account = this.get("Account");
				var accounts = this.getConfItemFilterAccounts(contact, account);
				var accountGroup = this.getConfItemFilterByAccount(accounts);
				if (accountGroup) {
					var departmentGroup = this.getConfItemFilterByDepartment(contact);
					accountGroup.addItem(departmentGroup);
					filterGroup.addItem(accountGroup);
				}
				return filterGroup;
			},

			/**
			 * Adds configuration item filter by contact.
			 * @param {String} Contact identifier.
			 * @param {BPMSoft.FilterGroup} Filter group.
			 * @protected
			 */
			addConfItemFilterByContact: function(contact, filterGroup) {
				if (!contact) {
					return null;
				}
				filterGroup.add("ContactFilter", this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL, "[ConfItemUser:ConfItem].Contact", contact.value));
			},

			/**
			 * Returns configuration item filter by account.
			 * @protected
			 * @returns {BPMSoft.FilterGroup} Filter group.
			 */
			getConfItemFilterByAccount: function(accounts) {
				if (accounts.length === 0) {
					return null;
				}
				var accountFilterGroup = new this.BPMSoft.createFilterGroup();
				accountFilterGroup.add("AccountFilter", this.BPMSoft.createColumnInFilterWithParameters(
					"[ConfItemUser:ConfItem].Account", accounts));
				return accountFilterGroup;
			},

			/**
			 * Returns configuration item filter by department.
			 * @protected
			 * @returns {BPMSoft.FilterGroup} Filter group.
			 */
			getConfItemFilterByDepartment: function(contact) {
				var filters = new this.BPMSoft.createFilterGroup();
				filters.logicalOperation = this.BPMSoft.LogicalOperatorType.OR;
				filters.add("DepartmentNullFilter", this.BPMSoft.createColumnIsNullFilter(
					"[ConfItemUser:ConfItem].Department"));
				if (contact) {
					filters.add("DepartmentFilter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL,
						"[ConfItemUser:ConfItem].Department.[Contact:Department:Id].Id", contact.value));
				}
				return filters;
			},

			/**
			 * Returns configuration item filter by account.
			 * @protected
			 * @returns {BPMSoft.FilterGroup} Filter group.
			 */
			getConfItemFilterAccounts: function(contact, account) {
				var accounts = [];
				var contactAccount = null;
				if (contact) {
					contactAccount = contact.Account;
					if (contactAccount && contactAccount.value !== this.BPMSoft.GUID_EMPTY) {
						accounts.push(contactAccount.value);
					}
				}
				if (account && account.value && account.value !== this.BPMSoft.GUID_EMPTY && (!contactAccount ||
					contactAccount.value !== account.value)) {
					accounts.push(account.value);
				}
				return accounts;
			}
		});
	});
