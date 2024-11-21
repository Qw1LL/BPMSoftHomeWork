define("RelatedEmailsMixin", ["ConfigurationConstants"],
	function(ConfigurationConstants) {
		/**
		 * @class BPMSoft.configuration.mixins.RelatedEmailsMixin
		 * The mixin provides methods for related emails search.
		 */
		Ext.define("BPMSoft.configuration.mixins.RelatedEmailsMixin", {
			alternateClassName: "BPMSoft.RelatedEmailsMixin",

			//region Methods: Protected

			/**
			 * Returns email conversation identifier.
			 * @protected
			 * @param {String} emailId Email record unique identifier.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			getConversationId: function(emailId, callback, scope) {
				var conversationIdESQ = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "EmailMessageData"
				});
				conversationIdESQ.addColumn("ConversationId");
				var filters = this.BPMSoft.createFilterGroup();
				filters.add("masterRecordFilter", conversationIdESQ.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL, "Activity", emailId));
				conversationIdESQ.filters = filters;
				conversationIdESQ.getEntityCollection(function(result) {
					var conversationId;
					if (result.success && !result.collection.isEmpty()) {
						var emailEmd = result.collection.first();
						conversationId = emailEmd && emailEmd.$ConversationId;
					}
					this.Ext.callback(callback, scope || this, [conversationId]);
				}, this);
			},

			/**
			 * Adds emails from conversation filters to filters collection.
			 * @protected
			 * @param {BPMSoft.FilterGroup} filters Emails query filters collection. 
			 * @param {String} conversationId Emails conversation identifier.
			 */
			setEmailsByConversationFilters: function(filters, conversationId) {
				filters.add("EmailFilter", this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL, "Type", ConfigurationConstants.Activity.Type.Email
				));
				filters.add("ConversationFilter", this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL, "[EmailMessageData:Activity:Id].ConversationId", conversationId
				));
			}

			//endregion

		});
	});