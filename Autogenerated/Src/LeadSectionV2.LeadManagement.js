 define("LeadSectionV2", ["SalesReadyLeadLifecycleMixin"], function() {
		return {
			mixins: {
				SalesReadyLeadLifecycleMixin: "BPMSoft.SalesReadyLeadLifecycleMixin"	
			},
			methods: {

				//region Methods: Protected

				/**
				 * @inheritdoc BPMSoft.LeadContactProfileSchema#init
				 * @override
				 */
				init: function(callback, scope) {
					this.callParent([function() {
						this.loadSalesReadyLeadLifecycleSysSetting(callback, scope);
					}, this]);
				},

				/**
				 * @inheritdoc BPMSoft.LeadManagementUtilities#initLeadManagementButtonVisibility
				 * @override
				 */
				initLeadManagementButtonVisibility: function(entity) {
					if(this.get("UseTheSalesReadyLeadLifecycle")) {
						this.set("LeadManagementButtonVisible", false);
					} else {
						this.callParent(arguments);
					}
				},

				//endregion
			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	}
);
