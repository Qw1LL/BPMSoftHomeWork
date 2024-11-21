define("SpecificationInLeadPageV2", [],
	function() {
		return {
			entitySchemaName: "SpecificationInLead",
			methods: {
				/**
				 * ######### ######### ######### ##############.
				 * ######## ############ ############## ### ########.
				 * @protected
				 * @virtual
				 * @param callback ####### ######### ###### ### ########### #########
				 * @param scope ######## ##########
				 */
				validateSpecification:  function(callback, scope) {
					var result = {
						success: true
					};
					var lead = this.get("Lead");
					var specification = this.get("Specification");
					if (this.Ext.isEmpty(lead) || this.Ext.isEmpty(specification)) {
						result.message = this.get("Resources.Strings.CantCheckSpecificationError");
						result.success = false;
						callback.call(scope || this, result);
						return;
					}
					if (this.isNewMode() || this.changedValues.Specification) {
						var select = this.Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: "SpecificationInLead"
						});
						select.addAggregationSchemaColumn("Id", BPMSoft.AggregationType.COUNT, "IdCOUNT");
						select.filters.addItem(BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
							"Lead", lead.value));
						select.filters.addItem(BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
							"Specification", specification.value));
						select.getEntityCollection(function(response) {
							if (response.success) {
								if (response.collection.getCount() < 1) {
									result.message = this.get("Resources.Strings.CantCheckSpecificationError");
									result.success = false;
								} else {
									var selectResult  =  response.collection.getByIndex(0);
									var specificationsCount = selectResult.get("IdCOUNT");
									if (specificationsCount > 0) {
										result.message = this.get("Resources.Strings.SpecificationExists");
										result.success = false;
									}
								}
							} else {
								result.message = this.get("Resources.Strings.CantCheckSpecificationError");
								result.success = false;
							}
							callback.call(scope || this, result);
						}, this);
					} else {
						callback.call(scope || this, result);
					}
				},

				/**
				 * ######### ########### ######### ########
				 * @protected
				 * @override
				 * @param callback ####### ######### ######
				 * @param scope ######## ##########
				 */
				asyncValidate: function(callback, scope) {
					this.callParent([function(response) {
						if (!this.validateResponse(response)) {
							return;
						}
						BPMSoft.chain(
							function(next) {
								this.validateSpecification(function(response) {
									if (this.validateResponse(response)) {
										next();
									}
								}, this);
							},
							function(next) {
								callback.call(scope, response);
								next();
							}, this);
					}, this]);
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Lead",
					"values": {
						"bindTo": "Lead",
						"layout": { "column": 0, "row": 0, "colSpan": 11 },
						"enabled": false,
						"controlConfig": {
							"enableRightIcon": false
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
