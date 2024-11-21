define("CasePageV2", ["BusinessRuleModule"],
	function(BusinessRuleModule) {
		return {
			entitySchemaName: "Case",
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "ServiceItem",
					"values": {
						"layout": {
							"column": 0,
							"row": 5,
							"colSpan": 24,
							"rowSpan": 1
						},
						"bindTo": "ServiceItem"
					},
					"parentName": "CaseProfile_gridLayout",
					"propertyName": "items"
				}
			]/**SCHEMA_DIFF*/,
			mixins: {},
			attributes: {
				/**
				 * ServiceItem column value.
				 */
				"ServiceItem": {
					lookupListConfig: {
						filter: function() {
							return this.getServiceItemFilter();
						}
					},
					dependencies: [
						{
							columns: ["ServiceItem"],
							methodName: "onServiceItemChanged"
						}
					]
				}
			},
			methods: {
				/**
				 * Sets CaseCategory column value for "ServiceItem".
				 * @protected
				 * @virtual
				 */
				setTypeByServiceItem: function() {
					var serviceItem = this.get("ServiceItem");
					if (!serviceItem) {
						return;
					}
					var select = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "ServiceItem"
					});
					select.addColumn("CaseCategory");
					select.filters.add("ServiceItemIdFilter",
						select.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL, "Id", serviceItem.value));
					select.getEntityCollection(function(result) {
						if (result.success && result.collection.getCount()) {
							var entity = result.collection.getByIndex(0);
							if (!this.get("Category")) {
								this.set("Category", entity.values.CaseCategory);
							}
						}
					}, this);
				},

				/**
				 * "ServiceItem" change event handler.
				 * @protected
				 * @virtual
				 */
				onServiceItemChanged: function() {
					if (this.changedValues.ServiceItem || !this.get("OriginalServiceItem")) {
						this.recalculateServiceTerms();
						this.setTypeByServiceItem();
					}
				},

				/**
				 * Updates information about initial object data.
				 * @param {Boolean} isNull Cleaning flag of initial data.
				 */
				updateOriginals: function(isNull) {
					this.set("OriginalServiceItem", isNull ? null : this.get("ServiceItem"));
					this.callParent(arguments);
				},

				/**
				 * Starts recalculating scheduled dates for "ServiceItem".
				 */
				recalculateServiceTerms: function() {
					var config = this.getCallTermCalculationServiceConfig();
					if (config) {
						this.callService(config, this.onRecalculateServiceTerms, this);
					} else if (this.get("ResponseDate")) {
						this.set("ResponseDate", null);
						this.set("SolutionDate", null);
					}
				},

				/**
				 * Returns service startup config for calculation term for "ServiceItem".
				 * @returns {Object} Service startup config.
				 */
				getCallTermCalculationServiceConfig: function() {
					var serviceItem = this.get("ServiceItem");
					var registrationTime = this.get("RegisteredOn");
					if (!serviceItem || !registrationTime) {
						return null;
					}
					var config = {
						serviceName: "TermCalculationCSService",
						methodName: "GetServiceTerm",
						data: {
							request: {
								ServiceItemId: serviceItem.value,
								PriorityId: this.BPMSoft.GUID_EMPTY,
								RegistrationTime: JSON.parse(this.BPMSoft.encodeDate(registrationTime))
							}
						}
					};
					return config;
				},

				/**
				 * @oritdoc BPMSoft.CasePageV2#handlePausedStatus
				 * @overridden
				 */
				handlePausedStatus: function(status) {
					if (status.IsPaused) {
						this.set("SolutionDateGetter", this.get("SolutionDate"));
						this.set("SolutionDate", null);
						if (this.get("IsOriginalStatusPaused") === false && this.get("SolutionDateGetter")) {
							this.calculateRemains(true);
						}
					} else {
						if (this.get("IsOriginalStatusPaused")) {
							this.calculateDateAfterPause(status.IsResolved);
						}
					}
				},

				/**
				 * Sets "ResponseDate" and "SolutionDate".
				 * @param {Object} responseObject Service response of scheduled dates for "ServiceItem".
				 */
				onRecalculateServiceTerms: function(responseObject) {
					this.hideBodyMask();
					var result = responseObject.GetServiceTermResult;
					this.set("ResponseDate", new Date(parseInt(result.ReactionTime.substr(6), 10)));
					this.set("SolutionDate", new Date(parseInt(result.SolutionTime.substr(6), 10)));
				},

				/**
				 * Starts recalculation "SolutionDate" after pause state.
				 * @protected
				 * @virtual
				 * @param {Boolean} isResolution "SolutionDate" flag.
				 */
				calculateDateAfterPause: function(isResolution) {
					var CaseId = this.get("Id");
					var remainsTicks = isResolution ? this.get("SolutionRemains") : this.get("ResponseRemains");
					var config = {
						serviceName: "TermCalculationCSService",
						methodName: "GetDateAfterPause",
						data: {
							request: {
								RemainsTicks: remainsTicks,
								IsResolution: isResolution,
								CaseId: CaseId
							}
						}
					};
					if (isResolution) {
						this.callService(config, this.onDateAfterPauseCalculated, this);
					}
				},

				/**
				 * @inheritdoc BPMSoft.CasePageV2#onStatusChanged
				 * @overridden
				 */
				onStatusChanged: function() {
					this.callParent(arguments);
					var status = this.get("Status");
					if (!status) {
						return;
					}
					var originalStatus = this.get("OriginalStatus");
					if (!originalStatus) {
						return;
					}
					var isActiveStatus = !status.IsFinal && !status.IsPaused && !status.IsResolved;
					var isActiveOriginalStatus = !originalStatus.IsFinal && !originalStatus.IsPaused &&
						!originalStatus.IsResolved;
					if (isActiveOriginalStatus && !isActiveStatus) {
						this.recalculateServiceTerms();
					}
				},

				/**
				 * Sets "SolutionDate" and reset "SolutionRemainsSetter".
				 * @param {Object} responseObject Service response  of "SolutionDate" calculation.
				 */
				onDateAfterPauseCalculated: function(responseObject) {
					this.set("SolutionDate", new Date(parseInt(responseObject.GetDateAfterPauseResult.substr(6), 10)));
					this.set("SolutionRemainsSetter", null);
				},

				/**
				 * Starts remains calculation.
				 * @protected
				 * @virtual
				 * @param {Boolean} isResolution Flag of "SolutionDate" calculation.
				 */
				calculateRemains: function(isResolution) {
					var sourceDateTime;
					var CaseId = this.get("Id");
					if (isResolution) {
						sourceDateTime = this.get("SolutionDateGetter");
					} else {
						sourceDateTime = this.get("ResponseDateGetter");
					}
					var config = {
						serviceName: "TermCalculationCSService",
						methodName: "GetRemainsTicks",
						data: {
							request: {
								SourceDateTime: JSON.parse(BPMSoft.encodeDate(sourceDateTime)),
								IsResolution: isResolution,
								CaseId: CaseId
							}
						}
					};
					if (isResolution) {
						this.callService(config, this.onRemainsCalculated, this);
					}
				},

				/**
				 * Sets "SolutionRemainsSetter" column value.
				 * @param {Object} responseObject Service response of calculation of "Remains".
				 */
				onRemainsCalculated: function(responseObject) {
					this.set("SolutionRemainsSetter", responseObject.GetRemainsTicksResult);
				},

				/**
				 * Returns filter for "ServiceItem" with "Status" = "Active".
				 * @protected
				 * @virtual
				 * @returns {BPMSoft.BaseFilter} "ServiceItem" column filter
				 */
				getServiceItemFilter: function() {
					var serviceItemFilter = this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Status.Active", true);
					return serviceItemFilter;
				}
			},
			rules: {
				"ServiceItem": {
					"EnableServiceItem": {
						ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						property: BusinessRuleModule.enums.Property.ENABLED,
						conditions: [{
							"leftExpression": {
								"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
								"attribute": "OriginalServiceItem"
							},
							"comparisonType": this.BPMSoft.ComparisonType.IS_NULL
						}]
					}
				}
			},
			userCode: {}
		};
	});
