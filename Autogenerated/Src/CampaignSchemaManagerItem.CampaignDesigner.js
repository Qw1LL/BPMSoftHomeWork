define("CampaignSchemaManagerItem", ["CampaignSchema",
		"CampaignSchemaUpdateRequest", "CampaignSchemaRemoveRequest", "CampaignSchemaRequest",
		"CampaignValidateRequest"],
	function() {
	/**
	 * @class BPMSoft.manager.CampaignSchemaManagerItem
	 */
	Ext.define("BPMSoft.manager.CampaignSchemaManagerItem", {
		extend: "BPMSoft.ProcessSchemaManagerItem",
		alternateClassName: "BPMSoft.CampaignSchemaManagerItem",

		/**
		 * @inheritdoc BPMSoft.BaseSchemaManagerItem#instanceClassName
		 * @overridden
		 */
		instanceClassName: "BPMSoft.CampaignSchema",

		/**
		 * @inheritdoc BPMSoft.BaseSchemaManagerItem#requestClassName
		 * @overridden
		 */
		requestClassName: "BPMSoft.CampaignSchemaRequest",

		/**
		 * @inheritdoc BPMSoft.BaseSchemaManagerItem#removeRequestClassName
		 * @overridden
		 */
		removeRequestClassName: "BPMSoft.CampaignSchemaRemoveRequest",

		/**
		 * @inheritdoc BPMSoft.BaseSchemaManagerItem#updateRequestClassName
		 * @overridden
		 */
		updateRequestClassName: "BPMSoft.CampaignSchemaUpdateRequest",
		
		/**
		 * The class name for the campaign validation.
		 * @type {String}
		 */
		validateRequestClassName: "BPMSoft.CampaignValidateRequest",

		/**
		 * Creates an object of the schema validate request.
		 * @return {BPMSoft.BaseSchemaRequest} The request object for the schema instance.
		 */
		getValidateRequest: function() {
			if (!this.instance) {
				throw new BPMSoft.exceptions.InvalidObjectState();
			}
			return Ext.create(this.validateRequestClassName, {schema: this.instance});
		},

		/**
		 * Makes validation request for campaign schema.
		 * @param {Function} callback Callback function to call when response will be received.
		 * @param {Object} scope Context.
		 */
		validate: function(callback, scope) {
			var safeCallback = this.getSafeCallback(callback, scope);
			var validateRequest = this.getValidateRequest();
			validateRequest.execute(function(response) {
				safeCallback.call(scope, response);
			}, this);
		}

	});
	return BPMSoft.CampaignSchemaManagerItem;
});
