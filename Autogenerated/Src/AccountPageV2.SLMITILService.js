define("AccountPageV2", [],
function() {
	return {
		entitySchemaName: "Account",
		messages: {
			/*
			 * @message
			 * Updates service recipients detail.
			 * */
			"UpdateServiceRecepientsDetail": {
				"mode": this.BPMSoft.MessageMode.PTP,
				"direction": this.BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
		details: /**SCHEMA_DETAILS*/{
			"Services": {
				"schemaName": "ServiceRecepientsDetail",
				"entitySchemaName": "VwServiceRecepients",
				"filter": {
					"masterColumn": "Id",
					"detailColumn": "Account"
				}
			},
			"ServicePacts": {
				"schemaName": "ServicePactRecipientsDetail",
				"entitySchemaName": "ServiceObject",
				"filter": {
					"masterColumn": "Id",
					"detailColumn": "Account"
				}
			}
		}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "AccountPageServiceTab",
				"parentName": "Tabs",
				"propertyName": "tabs",
				"index": 2,
				"values": {
					"caption": {"bindTo": "Resources.Strings.AccountPageServiceTab"},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "Services",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.DETAIL
				},
				"parentName": "AccountPageServiceTab",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ServicePacts",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.DETAIL
				},
				"parentName": "AccountPageServiceTab",
				"propertyName": "items",
				"index": 1
			}
		]/**SCHEMA_DIFF*/,
		attributes: {},
		methods: {
			/**
			 * @inheritDoc BPMSoft.BasePageV2#onEntityInitialized
			 * @overridden
			 */
			onEntityInitialized: function() {
				this.callParent(arguments);
				this.sandbox.subscribe("UpdateServiceRecepientsDetail", this.updateDetails, this);
			}
		},
		rules: {},
		userCode: {}
	};
});
