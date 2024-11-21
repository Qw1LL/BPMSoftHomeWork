define("CommunicationInCaseDetail", [], function() {
	return {
		entitySchemaName: "ContactCommunication",
		methods: {
			/**
			 * @inheritDoc ContactCommunicationDetail#getEntityRestrictions
			 * @protected
			 * @overridden
			 */
			getEntityRestrictions: function(callback, scope) {
				var isContactEmpty = !this.isContactNotEmpty();
				if(isContactEmpty || this.get("IsDetailCollapsed")) {
					if(isContactEmpty) {
						this.set("IsDataLoaded", true);
					}
					callback.call(scope);
					return;
				}
				this.callParent(arguments);
			},

			/**
			 * @inheritDoc ContactCommunicationDetail#getSaveRestrictionsQuery
			 * @protected
			 * @overridden
			 */
			getSaveRestrictionsQuery: function() {
				if (!this.isContactNotEmpty()) {
					return null;
				}
				this.callParent(arguments);
			},

			/**
			 * Checks whether contact exists.
			 * @return {Boolean} ####### ####### ########.
			 */
			isContactNotEmpty: function() {
				return this.get("MasterRecordId") ? true : false;
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "remove",
				"name": "SocialNetworksContainer"
			},
			{
				"operation": "merge",
				"name": "AddButton",
				"values": {
					"enabled": {
						"bindTo": "isContactNotEmpty"
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
