define("ProcessSplitGatewayTransitionSchema", ["CampaignEnums", "ProcessSplitGatewayTransitionSchemaResources",
		"ProcessCampaignSequenceFlowSchema"],
	function(CampaignEnums) {
		Ext.define("BPMSoft.manager.ProcessSplitGatewayTransitionSchema", {
			extend: "BPMSoft.ProcessCampaignSequenceFlowSchema",
			alternateClassName: "BPMSoft.ProcessSplitGatewayTransitionSchema",

			managerItemUId: "4E725C37-9C37-4072-93CC-F8E0939F6130",

			mixins: {
				parametrizedProcessSchemaElement: "BPMSoft.ParametrizedProcessSchemaElement"
			},

			/**
			 * @inheritdoc BPMSoft.ProcessBaseElementSchema#typeName
			 * @protected
			 * @overridden
			 */
			typeName: "BPMSoft.Configuration.CampaignSplitGatewayTransitionElement, BPMSoft.Configuration",

			/**
			 * Sequence flow name.
			 * @type {String}
			 */
			connectionUserHandleName: "SplitGatewayTransition",

			/**
			 * @inheritdoc BPMSoft.ProcessBaseElementSchema#editPageSchemaName
			 */
			editPageSchemaName: "CampaignSequenceFlowPropertiesPage",

			/**
			 * Type of element
			 * @type {String}
			 */
			elementType: CampaignEnums.CampaignSchemaElementTypes.CONDITIONAL_TRANSITION,

			/**
			 * Unique key for current transition in current campaign.
			 * @type {Guid}
			 */
			transitionId: null,

			/**
			 * Description text.
			 * @type {String}
			 */
			description: null,

			/**
			 * @inheritdoc BPMSoft.BaseObject#constructor
			 * @override
			 */
			constructor: function() {
				this.transitionId = BPMSoft.generateGUID();
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.configuration.mixins.CampaignElementMixin#getElementSpecificPropertiesNames
			 * @overridden
			 */
			getElementSpecificPropertiesNames: function() {
				return  ["transitionId"];
			},

			/**
			 * @inheritdoc BPMSoft.manager.BaseSchema#getSerializableProperties
			 * @override
			 */
			getSerializableProperties: function() {
				var baseSerializableProperties = this.callParent(arguments);
				return Ext.Array.push(baseSerializableProperties, ["transitionId"]);
			}
		});
		return BPMSoft.ProcessSplitGatewayTransitionSchema;
	});
