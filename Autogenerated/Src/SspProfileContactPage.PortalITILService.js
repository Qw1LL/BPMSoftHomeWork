define("SspProfileContactPage", ["ServiceFilterMixin"],
function() {
	return {
		mixins: {
			/**
			 * @class BPMSoft.configuration.mixins.ServiceFilterMixin.
			 */
			ServiceFilterMixin: "BPMSoft.ServiceFilterMixin"
		},
		entitySchemaName: "Contact",
		messages: {},
		details: /**SCHEMA_DETAILS*/{
			"Services": {
				"schemaName": "ServiceRecepientsDetail",
				"entitySchemaName": "VwServiceRecepients",
				"filterMethod": "getServicesFilter",
				"filter": {
					"masterColumn": "Id",
					"detailColumn": "Contact"
				}
			},
			"ServicePacts": {
				"schemaName": "ServicePactRecipientsDetail",
				"entitySchemaName": "ServiceObject",
				"filterMethod": "getServicesPactFilter",
				"filter": {
					"masterColumn": "Id",
					"detailColumn": "Contact"
				}
			}
		}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "ContactPageServiceTab",
				"parentName": "Tabs",
				"propertyName": "tabs",
				"index": 2,
				"values": {
					"caption": {"bindTo": "Resources.Strings.MaintenanceTab"},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "Services",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.DETAIL
				},
				"parentName": "ContactPageServiceTab",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ServicePacts",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.DETAIL
				},
				"parentName": "ContactPageServiceTab",
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
				this.initServiceFilterMixin();
			},

			/**
			 * Returns service item filter.
			 * @protected
			 * @returns {BPMSoft.FilterGroup} Filter group.
			 */
			getServicesFilter: function() {
				return this.mixins.ServiceFilterMixin.getServicesFilter("Service.Id",
					"[VwServiceRecepients:Service:Id]");
			},

			/**
			 * Returns service pact filter.
			 * @protected
			 * @returns {BPMSoft.FilterGroup} Filter group.
			 */
			getServicesPactFilter: function() {
				return this.mixins.ServiceFilterMixin.getServicesFilter("ServicePact.Id",
					"[ServiceObject:ServicePact:Id]");
			},

			/**
			 * Initialize ServiceFilter mixin.
			 * @protected
			 */
			initServiceFilterMixin: function() {
				this.mixins.ServiceFilterMixin.init({
					contact: this.$Id,
					account: this.$Account,
					department:  this.$Department
				});
			}
		},
		rules: {},
		userCode: {}
	};
});
