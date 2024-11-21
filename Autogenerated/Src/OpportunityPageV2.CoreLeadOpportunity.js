define("OpportunityPageV2", ["LeadConfigurationConst", "OpportunityPageV2Resources",
		"CreateLeadForEntityUtilities"],
	function(LeadConfigurationConst) {
		return {
			entitySchemaName: "Opportunity",
			details: /**SCHEMA_DETAILS*/ {
				"Lead": {
					"schemaName": "LeadDetailV2",
					"entitySchemaName": "Lead",
					"filter": {
						"detailColumn": "Opportunity",
						"masterColumn": "Id"
					},
					defaultValues: {
						QualifiedAccount: {
							masterColumn: "Account"
						},
						Budget: {
							masterColumn: "Budget"
						},
						SalesOwner: {
							masterColumn: "Owner"
						},
						OpportunityDepartment: {},
						LeadType: {
							masterColumn: "LeadType"
						}
					}
				}
			} /**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/ [
				{
					"operation": "insert",
					"name": "LeadTab",
					"values": {
						"items": [],
						"caption": {
							"bindTo": "Resources.Strings.OpportunityPageV28TabCaption"
						}
					},
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 3
				},
				{
					"operation": "insert",
					"name": "Lead",
					"values": {
						"itemType": 2
					},
					"parentName": "LeadTab",
					"propertyName": "items",
					"index": 0
				}
			] /**SCHEMA_DIFF*/,
			mixins: {
				CreateLeadForEntityUtilities: "BPMSoft.CreateLeadForEntityUtilities"
			},
			messages: {
				"GetCurrentOpportunityInfo": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},
			methods: {

				/**
				 * @inheritDoc BPMSoft.BaseSchemaModule#init
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
					var leadType = this.get("LeadType");
					if (leadType && leadType.value !== BPMSoft.GUID_EMPTY) {
						insert.setParameterValue("LeadType", leadType.value,
							BPMSoft.DataValueType.GUID);
					}
					insert.setParameterValue("QualifyStatus",
						LeadConfigurationConst.LeadConst.QualifyStatus.WaitingForSale,
						BPMSoft.DataValueType.GUID);
				},

				/**
				 * @inheritDoc BPMSoft.BasePageV2#saveEntityInChain
				 * @overridden
				 */
				saveEntityInChain: function(next) {
					var callback = this.createLeadAfterSave.bind(this, next);
					this.callParent([callback]);
				},

				/**
				 * Setting message subscription.
				 * @override
				 */
				subscribeSandboxEvents: function() {
					this.callParent(arguments);
					var sandboxId = this.getSaveRecordMessagePublishers();
					this.sandbox.subscribe("GetCurrentOpportunityInfo", function(config) {
						return this.getCurrentOpportunityInfo(config);
					}, this, sandboxId);
				},

				/**
				 * Returns opportunity data array.
				 * @param {Object} config Objects array. Example : {columnPath: ""}
				 * @return {Array} Opportunity data array. Example : {columnPath: "name_Field", value: "value_Field"}
				 */
				getCurrentOpportunityInfo: function(config) {
					config.map(function(item) {
						item.value = this.get(item.columnPath);
					}.bind(this));
					return config;
				}
			},
			rules: {},
			userCode: {}
		};
	});
