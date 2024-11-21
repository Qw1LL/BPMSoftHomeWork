define("CaseServiceContractUtility", [],
	function() {
		/**
		 * @class BPMSoft.configuration.mixins.CaseServiceContractUtility
		 * Mixin, that implements work with service contracts on page.
		 */
		Ext.define("BPMSoft.configuration.mixins.CaseServiceContractUtility", {
			alternateClassName: "BPMSoft.CaseServiceContractUtility",
			/**
			 * @inheritdoc BPMSoft.BasePageV2#onEntityInitialized
			 * @overridden
			 */
			onEntityInitialized: function() {
				this.callParent(arguments);
				this.setInitialValues();
			},

			/**
			 * Sets initial values on page init.
			 * @protected
			 */
			setInitialValues: function() {
				this.set("SuitableServicePacts", []);
				this.setServicePact();
			},

			/**
			 * Returns service pact filter.
			 * @protected
			 * @returns {BPMSoft.FilterGroup} Filter group
			 */
			getServicePactFilter: function() {
				var suitableServicePacts = this.get("SuitableServicePacts");
				var availableServicePactIds = [];
				this.Ext.Array.each(suitableServicePacts, function(item) {
					availableServicePactIds.push(item.Id);
				});
				availableServicePactIds = availableServicePactIds.length ? availableServicePactIds
					: [this.BPMSoft.GUID_EMPTY];
				return this.BPMSoft.createColumnInFilterWithParameters("Id", availableServicePactIds);
			},

			/**
			 * Sets resolution planned date and reset estimated by resolution.
			 * @protected
			 * @param {Object} responseObject
			 */
			onDateAfterPauseCalculated: function(responseObject) {
				this.set("SolutionDate", new Date(parseInt(responseObject.GetDateAfterPauseResult.substr(6), 10)));
				this.set("SolutionRemainsSetter", null);
			},

			/**
			 * Returns calculation service name.
			 * @protected
			 * @return {BPMSoft.BaseFilter} Service name.
			 */
			getCalculationServiceName: function() {
				return "TermCalculationService";
			},

			/**
			 * Returns service item filter group by service pact.
			 * @protected
			 * @returns {BPMSoft.FilterGroup} Filter group
			 */
			getServiceItemFilters: function() {
				var filtersCollection = this.BPMSoft.createFilterGroup();
				var servicePact = this.get("ServicePact");
				if (!servicePact) {
					return filtersCollection;
				}
				filtersCollection.add("ServiceItemByServicePactFilter",
					this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
						"[ServiceInServicePact:ServiceItem].ServicePact", servicePact.value));
				filtersCollection.add("ServiceItemByActiveServiceStatusFilter",
					this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
						"[ServiceInServicePact:ServiceItem].Status.Active", true));
				var caseCategoryFilter = this.getCaseCategoryFilter();
				if (caseCategoryFilter) {
					filtersCollection.add("ServiceItemByCaseCategory", caseCategoryFilter);
				}
				var serviceCategory = this.get("ServiceCategory");
				if (serviceCategory) {
					filtersCollection.add("ServiceItemByCategory",
						this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
							"Category", serviceCategory.value));
				}
				return filtersCollection;
			},

			/**
			 * Returns service item filter by case category.
			 * @protected
			 * @returns {BPMSoft.Filter} Filter group
			 */
			getCaseCategoryFilter: function() {
				var caseCategory = this.get("Category");
				if (caseCategory) {
					return this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
					"CaseCategory", caseCategory.value);
				}
				return null;
			},

			/**
			 * On service pact field change handler.
			 * @protected
			 */
			onServicePactChanged: function() {
				var servicePact = this.get("ServicePact");
				var serviceItem = this.get("ServiceItem");
				if (!servicePact) {
					this.set("ServiceItem", null);
					this.set("ServiceCategory", null);
					return;
				}
				if (this.changedValues.ServicePact && serviceItem) {
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "ServiceItem"
					});
					esq.addColumn("Id");
					esq.filters.add("servicePactAndStatusFilter", this.getServiceItemFilters());
					esq.filters.add("serviceItemId", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Id", serviceItem.value));
					esq.getEntityCollection(function(result) {
						if (result.success && !result.collection.getCount()) {
							this.set("ServiceItem", null);
						}
					}, this);
				}
			},

			/**
			 * Returns calculating dates service config.
			 * @protected
			 * @returns {Object} Service input config
			 */
			getCallTermCalculationServiceConfig: function() {
				var servicePact = this.get("ServicePact");
				var serviceItem = this.get("ServiceItem");
				var registrationTime = this.get("RegisteredOn");
				if (!servicePact || !serviceItem || !registrationTime) {
					return null;
				}
				var config = {
					serviceName: "TermCalculationService",
					methodName: "GetServiceTerm",
					data: {
						request: {
							ServicePactId: servicePact.value,
							ServiceItemId: serviceItem.value,
							PriorityId: this.BPMSoft.GUID_EMPTY,
							RegistrationTime: JSON.parse(this.BPMSoft.encodeDate(registrationTime))
						}
					}
				};
				return config;
			},

			/**
			 * Sets service pact value.
			 * @protected
			 */
			setServicePact: function() {
				if (this.get("OriginalServiceItem")) {
					return;
				}
				var config = this.getCallDetermineServiceConfig();
				if (config) {
					this.showBodyMask();
					this.callService(config, this.onGetSuitableServicePacts, this);
				} else if (this.get("ServicePact")) {
					this.set("ServicePact", null);
					this.set("SuitableServicePacts", []);
				}
			},

			/**
			 * Returns determine service pact service config.
			 * @protected
			 * @returns {Object}
			 */
			getCallDetermineServiceConfig: function() {
				var contact = this.get("Contact");
				var account = this.get("Account");
				if (!contact && !account) {
					return null;
				}
				var config = {
					serviceName: "ServicePactService",
					methodName: "GetSuitableServicePacts",
					data: {
						request: {
							ContactId: contact ? contact.value : this.BPMSoft.GUID_EMPTY,
							AccountId: account ? account.value : this.BPMSoft.GUID_EMPTY
						}
					}
				};
				return config;
			},

			/**
			 * On get service pacts handler.
			 * @protected
			 * @param {Object} responseObject
			 */
			onGetSuitableServicePacts: function(responseObject) {
				this.hideBodyMask();
				this.set("SuitableServicePacts", responseObject.GetSuitableServicePactsResult || []);
				if (!this.get("ServicePact")) {
					var mostSuitableServicePact = this.getMostSuitableServicePact();
					if (mostSuitableServicePact) {
						this.set("ServicePact", mostSuitableServicePact);
					}
				}
			},

			/**
			 * Determine service pact with high priority.
			 * @private
			 * @returns {Object}
			 */
			getMostSuitableServicePact: function() {
				var suitableServicePacts = this.get("SuitableServicePacts");
				var mostSuitableServicePact = this.Ext.Array.min(suitableServicePacts, function(min, item) {
					return item.SuitableLevel < min.SuitableLevel;
				});
				if (!mostSuitableServicePact) {
					return null;
				}
				return {
					value: mostSuitableServicePact.Id,
					displayValue: mostSuitableServicePact.Name
				};
			},

			/**
			 * @inheritdoc BPMSoft.CasePageV2#getOwnerDependenceFilters
			 * @overridden
			 */
			getOwnerDependenceFilters: function(scope) {
				var filterGroup = new scope.BPMSoft.createFilterGroup();
				var serviceItem = scope.get("ServiceItem");
				var supportLevel = scope.get("SupportLevel");
				if (serviceItem) {
					filterGroup.add("ServiceItemFilter", scope.BPMSoft.createColumnFilterWithParameter(
						scope.BPMSoft.ComparisonType.EQUAL, "[ServiceEngineer:Engineer].ServiceItem", serviceItem.value));
				}
				if (supportLevel) {
					filterGroup.add("SupportLevelFilter", scope.BPMSoft.createColumnFilterWithParameter(
						scope.BPMSoft.ComparisonType.EQUAL, "[ServiceEngineer:Engineer].SupportLevel", supportLevel.value));
				}
				return filterGroup;
			},

			/**
			 * @inheritdoc BPMSoft.CasePageV2#handleResolvedStatus
			 * @overridden
			 */
			handleResolvedStatus: function(status) {
				if (status.IsResolved && !this.get("SolutionProvidedOn")) {
					var originalSolutionProvidedOn = this.get("OriginalSolutionProvidedOn");
					var solutionProvidedOn = originalSolutionProvidedOn ? originalSolutionProvidedOn : new Date();
					this.set("SolutionProvidedOn", solutionProvidedOn);
					var originalSupportLevel = this.get("OriginalSolvedOnSupportLevel");
					var supportLevel = originalSupportLevel ? originalSupportLevel : this.get("SupportLevel");
					this.set("SolvedOnSupportLevel", supportLevel);
				} else if (!status.IsFinal && !status.IsResolved) {
					this.set("SolvedOnSupportLevel", null);
					this.set("SolutionProvidedOn", null);
				}
			},

			/**
			 * @inheritdoc BPMSoft.CasePageV2#handleFinalStatus
			 * @overridden
			 */
			handleFinalStatus: function(status) {
				if (status.IsFinal && !this.get("ClosureDate")) {
					if (this.get("OriginalSolvedOnSupportLevel")) {
						this.set("SolvedOnSupportLevel", this.get("OriginalSolvedOnSupportLevel"));
					}
				}
				this.callParent(arguments);
			}
		});
	});
