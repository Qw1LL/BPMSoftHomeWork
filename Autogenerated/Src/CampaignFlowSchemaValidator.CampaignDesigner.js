define("CampaignFlowSchemaValidator", ["CampaignFlowSchemaValidatorResources"],
	function() {
		/**
		 * class BPMSoft.CampaignFlowSchemaValidator to validate campaign flow schema.
		 */
		Ext.define("BPMSoft.CampaignFlowSchemaValidator", {

			/**
			 * Information about campaign flow schema validation result.
			 * @type {BPMSoft.Collection}
			 */
			validationInfo: null,

			/**
			 * Creates CampaignFlowSchemaValidator instance.
			 */
			constructor: function() {
				this.validationInfo = Ext.create("BPMSoft.Collection");
			},

			/**
			 * Validates campaign's flow schema.
			 * @param  {BPMSoft.CampaignSchema} schema Campaign schema to validate.
			 * @private
			 */
			_validateFlowSchema: function(schema) {
				schema.validate();
				if (schema.validationResult && !schema.validationResult.isEmpty()) {
					this.validationInfo.add(schema.name, schema.validationResult);
				}
			},

			/**
			 * Validates each element of current campaign flow schema.
			 * @param  {BPMSoft.CampaignSchema} schema Campaign schema to validate.
			 * @private
			 */
			_validateElements: function(schema) {
				var elements = schema.flowElements;
				elements.each(function(el) {
					var validationResult = el.validate();
					if (validationResult && !validationResult.isEmpty()) {
						this.validationInfo.add(el.name, validationResult);
					}
				}, this);
			},

			/**
			 * Validates campaign flow schema with elements.
			 * @param  {BPMSoft.CampaignSchema} schema Campaign schema to validate.
			 * @protected
			 * @return {BPMSoft.Collection} Validation result.
			 */
			validate: function(schema) {
				this.validationInfo.clear();
				this._validateFlowSchema(schema);
				this._validateElements(schema);
				return this.validationInfo;
			}
		});
		return Ext.create("BPMSoft.CampaignFlowSchemaValidator");
	}
);
