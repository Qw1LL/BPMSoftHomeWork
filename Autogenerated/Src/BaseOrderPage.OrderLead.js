define("BaseOrderPage", ["BaseOrderPageResources", "LeadConfigurationConst", "OrderConfigurationConstants",
		"CreateLeadForEntityUtilities"],
	function(response, LeadConfigurationConst, OrderConfigurationConstants) {
		return {
			entitySchemaName: "Order",
			details: /**SCHEMA_DETAILS*/{
				"Lead": {
					"schemaName": "LeadDetailV2",
					"entitySchemaName": "Lead",
					"filter": {
						"detailColumn": "Order",
						"masterColumn": "Id"
					},
					defaultValues: {
						QualifiedAccount: {masterColumn: "Account"},
						QualifiedContact: {masterColumn: "Contact"}
					}
				}
			}/**SCHEMA_DETAILS*/,
			mixins: {
				CreateLeadForEntityUtilities: "BPMSoft.CreateLeadForEntityUtilities"
			},
			methods: {

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
				 * @overridden
				 */
				init: function() {
					this.mixins.CreateLeadForEntityUtilities.init.call(this);
					this.callParent(arguments);
				},

				/**
				 * @inheritDoc BPMSoft.CreateLeadForEntityUtilities#addQueryColumns
				 * @overridden
				 */
				addQueryColumns: function(insert) {
					var account = this.get("Account");
					if (account) {
						var accountId = account.value;
						insert.setParameterValue("QualifiedAccount",
							accountId, BPMSoft.DataValueType.GUID);
					}
					var contact = this.get("Contact");
					if (contact) {
						var contactId = contact.value;
						insert.setParameterValue("QualifiedContact",
							contactId, BPMSoft.DataValueType.GUID);
					}
					insert.setParameterValue("QualifyStatus",
						LeadConfigurationConst.LeadConst.QualifyStatus.WaitingForSale,
						BPMSoft.DataValueType.GUID);
					insert.setParameterValue("LeadTypeStatus",
						LeadConfigurationConst.LeadConst.LeadTypeStatus.ReadyToSale,
						BPMSoft.DataValueType.GUID);
					insert.setParameterValue("RegisterMethod",
						LeadConfigurationConst.LeadConst.LeadRegisterMethod.AddedManual,
						BPMSoft.DataValueType.GUID);
				},

				/**
				 * @inheritDoc BPMSoft.BasePageV2#saveEntityInChain
				 * @overridden
				 */
				saveEntityInChain: function(next) {
					var callback =  next;
					var opportunity = this.get("Opportunity");
					if (this.Ext.isEmpty(opportunity)) {
						callback = this.createLeadAfterSave.bind(this, next);
					}
					this.callParent([callback]);
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#onSaved
				 * @overridden
				 */
				onSaved: function(response) {
					var isSuccess = this.validateResponse(response);
					this.callParent(arguments);
					if (isSuccess) {
						this.updateLeadsStatus();
					}
				},

				/**
				 * Updates status of leads.
				 */
				updateLeadsStatus: function() {
					var update = this.Ext.create("BPMSoft.UpdateQuery", {
						rootSchemaName: "Lead"
					});
					this.setParametersLeadStatus(update);
					update.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Order", this.get("Id")));
					update.execute(function(response) {
						this.validateResponse(response);
					}, this);
				},

				/**
				 * Sets parameters for update query.
				 * @param {BPMSoft.UpdateQuery} update "Lead" schema update query.
				 */
				setParametersLeadStatus: function(update) {
					var state = this.get("Status");
					switch (state.value) {
						case OrderConfigurationConstants.Order.OrderStatus.Canceled:
							update.setParameterValue("QualifyStatus",
								LeadConfigurationConst.LeadConst.QualifyStatus.Distribution,
								this.BPMSoft.DataValueType.GUID);
							break;
						case OrderConfigurationConstants.Order.OrderStatus.Closed:
							update.setParameterValue("QualifyStatus",
								LeadConfigurationConst.LeadConst.QualifyStatus.Satisfied,
								this.BPMSoft.DataValueType.GUID);
							update.setParameterValue("LeadTypeStatus",
								LeadConfigurationConst.LeadConst.LeadTypeStatus.Satisfied,
								this.BPMSoft.DataValueType.GUID);
							break;
					}
				}

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "Lead",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL
					},
					"parentName": "OrderHistoryTab",
					"propertyName": "items",
					"index": 0
				}
			]/**SCHEMA_DIFF*/,
			rules: {},
			userCode: {}
		};
	});
