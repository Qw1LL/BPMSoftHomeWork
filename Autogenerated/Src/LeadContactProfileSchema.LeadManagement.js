define("LeadContactProfileSchema", ["SalesReadyLeadLifecycleMixin"], function() {
		return {
			mixins: {
				SalesReadyLeadLifecycleMixin: "BPMSoft.SalesReadyLeadLifecycleMixin"	
			},
			methods: {

				//region Methods: Protected

				/**
				 * Returns mobile phone field visibility
				 * @protected
				 */
				getMobilePhoneVisibility: function() {
					return !this.get("UseTheSalesReadyLeadLifecycle") 
						&& !this.Ext.isEmpty(this.get("MobilePhone"));
				},

				/**
				 * @inheritdoc BPMSoft.LeadContactProfileSchema#init
				 * @override
				 */
				init: function(callback, scope) {
					this.callParent([function() {
						this.loadSalesReadyLeadLifecycleSysSetting(callback, scope);
					}, this]);
				},

				//endregion
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "MobilePhone",
					"values": {
						"visible": {
							"bindTo": "getMobilePhoneVisibility"
						}
					}
				},
			]/**SCHEMA_DIFF*/
		};
	}
);
