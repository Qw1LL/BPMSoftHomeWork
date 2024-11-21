define("PortalMktgActivityEditPage", ["PortalMktgActivitiesConstants", "ConfigurationConstants", "BPMSoft"],
	function(PortalMktgActivitiesConstants, ConfigurationConstants) {
		return {
			entitySchemaName: "MktgActivity",
			details: /**SCHEMA_DETAILS*/{

			}/**SCHEMA_DETAILS*/,
			attributes: {
				Fund: {
					lookupListConfig: {
						filter: function() {
							return this.getParntershipActiveStatusFilter();
						}
					}
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "Fund",
					"values": {
						"layout": {
							"column": 0,
							"row": 5,
							"colSpan": 12,
							"rowSpan": 1
						},
						"enabled": {
							"bindTo": "isFieldsEditable"
						},
						"visible": false
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "Url",
					"values": {
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 24,
							"rowSpan": 1
						},
						"enabled": {
							"bindTo": "isFieldsEditable"
						}
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 0
				},

				{
					"operation": "insert",
					"name": "MarketingActivityControlGroup",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTROL_GROUP,
						"items": [],
						"caption": {
							"bindTo": "Resources.Strings.MarketingActivityGroupCaption"
						}
					},
					"parentName": "GeneralInfoTab",
					"propertyName": "items",
					"index": 1
				},
				{
					"operation": "insert",
					"name": "MarketingActivityControlGroup_GridLayout",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					},
					"parentName": "MarketingActivityControlGroup",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "Description",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24,
							"rowSpan": 1
						},
						"contentType": this.BPMSoft.ContentType.LONG_TEXT,
						"labelConfig": {
							"visible": true
						},
						"enabled": {
							"bindTo": "isFieldsEditable"
						}
					},
					"parentName": "MarketingActivityControlGroup_GridLayout",
					"propertyName": "items"
				}
			]/**SCHEMA_DIFF*/,
			rules: {},
			methods: {

				/**
				 * Create filter for active partnership status.
				 * protected
				 * @returns {Object}
				 */
				getParntershipActiveStatusFilter: function() {
					var filterGroup = new this.BPMSoft.createFilterGroup();
					filterGroup.add("ActivePartnership", this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL,
							"Partnership.IsActive", 1));
					return filterGroup;
				},

				/**
				 * Sets MktgActivity default type.
				 * @protected
				 * @virtual
				 */
				setMktgActivityDefaultType: function() {
					this.$MktgActivityType = {
						value: ConfigurationConstants.MktgActivity.Type.PartnersActivityType
					};
				},

				/**
				* @inheritdoc BPMSoft.configuration.BaseSchemaViewModel#setDefaultValues
				* @overriden
				*/
				setDefaultValues: function(callback, scope) {
					this.callParent([function() {
						this.setMktgActivityDefaultType();
						var account = this.BPMSoft.SysValue.CURRENT_USER_ACCOUNT.value;
						if (!this.BPMSoft.isEmptyGUID(account)) {
							this.$Account = this.BPMSoft.SysValue.CURRENT_USER_ACCOUNT;
							var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
								rootSchemaName: "Fund"
							});
							var typeFilter = BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
								"FundType", PortalMktgActivitiesConstants.FundType.Marketing);
							var joinFilter = "=[Partnership:Id:Partnership].Account";
							var filterGroup = new this.BPMSoft.createFilterGroup();
							filterGroup.addItem(
									BPMSoft.createColumnFilterWithParameter(
											BPMSoft.ComparisonType.EQUAL,
											joinFilter,
											account
									)
							);
							filterGroup.addItem(
									BPMSoft.createColumnFilterWithParameter(
											BPMSoft.ComparisonType.EQUAL,
											"=[Partnership:Id:Partnership].IsActive", true));
							esq.filters.addItem(filterGroup);
							esq.filters.addItem(typeFilter);
							esq.getEntityCollection(function(response) {
								if (response && response.success) {
									var collection = response.collection;
									if (collection && collection.getCount() > 0) {
										var mktgFund = collection.getByIndex(0);
										this.set("Fund", {
											value: mktgFund.values.Id
										});
									}
									callback.call(scope);
								}
							}, this);
						} else {
							callback.call(scope);
						}
					}, this]);
				}
			},
			userCode: {}
		};
	});
