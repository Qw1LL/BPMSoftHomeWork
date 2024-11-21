define("ProcessEmailConditionalTransitionSchema", ["CampaignEnums", "ProcessEmailConditionalTransitionSchemaResources",
	"ProcessCampaignConditionalSequenceFlowSchema"],
		function(CampaignEnums) {
	Ext.define("BPMSoft.manager.ProcessEmailConditionalTransitionSchema", {
		extend: "BPMSoft.ProcessCampaignConditionalSequenceFlowSchema",
		alternateClassName: "BPMSoft.ProcessEmailConditionalTransitionSchema",

		managerItemUId: "741B3FE3-D9C2-4032-B51E-D335F0F75F5C",

		mixins: {
			parametrizedProcessSchemaElement: "BPMSoft.ParametrizedProcessSchemaElement"
		},

		/**
		 * @inheritdoc BPMSoft.ProcessBaseElementSchema#typeName
		 * @override
		 */
		typeName: "BPMSoft.Configuration.EmailConditionalTransitionElement, BPMSoft.Configuration",

		/**
		 * Sequence flow name.
		 * @type {String}
		 */
		connectionUserHandleName: "EmailConditionalTransition",

		/**
		 * @inheritdoc BPMSoft.ProcessBaseElementSchema#editPageSchemaName
		 * @override
		 */
		editPageSchemaName: "EmailConditionalTransitionPropertiesPage",

		/**
		 * Type of element.
		 * @type {String}
		 */
		elementType: CampaignEnums.CampaignSchemaElementTypes.CONDITIONAL_TRANSITION,

		/**
		 * Array of recipient email responses.
		 * @type {String}
		 */
		emailResponseId: null,

		/**
		 * Is transition response based.
		 * @type {Boolean}
		 */
		isResponseBasedStart: false,

		/**
		 * Array of hyperlink Ids to click
		 * @type {String}
		 */
		hyperlinkId: null,

		/**
		 * Array of BPM track ids of the hyperlinks to click.
		 * @type {String}
		 */
		hyperlinkTrackId: null,

		/**
		 * @inheritdoc BPMSoft.ProcessSequenceFlowSchema#constructor
		 * @override
		 */
		constructor: function() {
			this.callParent(arguments);
		},

		/**
		 * Clears clicks response from all email responses if it had been selected.
		 * @private
		 */
		_uncheckHyperlinkClicksResponse: function() {
			var responseIds = BPMSoft.decode(this.emailResponseId);
			if (BPMSoft.contains(responseIds, CampaignEnums.BulkEmailResponses.CLICKS)) {
				Ext.Array.remove(responseIds, CampaignEnums.BulkEmailResponses.CLICKS);
				this.emailResponseId = BPMSoft.encode(responseIds);
			}
		},

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#getSerializableProperties
		 * @override
		 */
		getSerializableProperties: function() {
			var baseSerializableProperties = this.callParent(arguments);
			Ext.Array.push(baseSerializableProperties, ["emailResponseId"]);
			Ext.Array.push(baseSerializableProperties, ["isResponseBasedStart"]);
			Ext.Array.push(baseSerializableProperties, ["hyperlinkId"]);
			Ext.Array.push(baseSerializableProperties, ["hyperlinkTrackId"]);
			return baseSerializableProperties;
		},

		/**
		 * @inheritdoc BPMSoft.ProcessCampaignConditionalSequenceFlowSchema#hasNotEmptyFilter
		 * @override
		 */
		hasNotEmptyFilter: function() {
			var result = this.callParent(arguments);
			var responses = BPMSoft.decode(this.emailResponseId);
			return result || (this.isResponseBasedStart && responses && responses.length > 0);
		},

		/**
		 * Returns True if sequence flow has condition with connections on other entities.
		 * @public
		 * @returns {Boolean} Result of connections validation.
		 */
		checkDependencies: function() {
			var hyperlinkIds = BPMSoft.decode(this.hyperlinkId);
			var hyperlinkTrackIds = BPMSoft.decode(this.hyperlinkTrackId);
			return BPMSoft.isEmpty(hyperlinkIds) && BPMSoft.isEmpty(hyperlinkTrackIds);
		},

		/**
		 * Removes all connections data for current email conditional transition.
		 * @public
		 */
		clearDependentData: function() {
			if (!this.checkDependencies()) {
				this.hyperlinkId = BPMSoft.encode([]);
				this.hyperlinkTrackId = BPMSoft.encode([]);
				this._uncheckHyperlinkClicksResponse();
			}
		}
	});
	return BPMSoft.ProcessEmailConditionalTransitionSchema;
});
