define("ProcessEventConditionalTransitionSchema", ["CampaignEnums", "ProcessEventConditionalTransitionSchemaResources",
			"ProcessCampaignConditionalSequenceFlowSchema"],
		function(CampaignEnums) {
			Ext.define("BPMSoft.manager.ProcessEventConditionalTransitionSchema", {
				extend: "BPMSoft.ProcessCampaignConditionalSequenceFlowSchema",
				alternateClassName: "BPMSoft.ProcessEventConditionalTransitionSchema",

				managerItemUId: "5E725C37-9C37-4072-93CC-F8E0939F6130",

				mixins: {
					parametrizedProcessSchemaElement: "BPMSoft.ParametrizedProcessSchemaElement"
				},

				/**
				 * @inheritdoc BPMSoft.ProcessBaseElementSchema#typeName
				 * @protected
				 * @overridden
				 */
				typeName: "BPMSoft.Configuration.EventConditionalTransitionElement, BPMSoft.Configuration",

				/**
				 * Sequence flow name.
				 * @type {String}
				 */
				connectionUserHandleName: "EventConditionalTransition",

				/**
				 * @inheritdoc BPMSoft.ProcessBaseElementSchema#editPageSchemaName
				 */
				editPageSchemaName: "EventConditionalTransitionPropertiesPage",

				/**
				 * Type of element
				 * @type {string}
				 */
				elementType: CampaignEnums.CampaignSchemaElementTypes.CONDITIONAL_TRANSITION,

				/**
				 * Array of recipient email responses
				 * @type {Array[]}
				 */
				eventResponseCollection: null,

				/**
				 * Transition has response condition
				 * @type {Boolean}
				 */
				hasResponseCondition: false,

				/**
				 * @inheritdoc BPMSoft.manager.BaseSchema#getSerializableProperties
				 * @overridden
				 */
				getSerializableProperties: function() {
					var baseSerializableProperties = this.callParent(arguments);
					Ext.Array.push(baseSerializableProperties, ["eventResponseCollection"]);
					Ext.Array.push(baseSerializableProperties, ["hasResponseCondition"]);
					return baseSerializableProperties;
				},

				/**
				 * @inheritdoc BPMSoft.ProcessCampaignConditionalSequenceFlowSchema#hasNotEmptyFilter
				 * @override
				 */
				hasNotEmptyFilter: function() {
					var result = this.callParent(arguments);
					var responses = BPMSoft.decode(this.eventResponseCollection);
					return result || (this.hasResponseCondition && responses && responses.length > 0);
				}
			});
			return BPMSoft.ProcessEventConditionalTransitionSchema;
		});
