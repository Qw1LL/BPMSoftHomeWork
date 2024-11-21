define("ProcessLandingConditionalTransitionSchema", ["CampaignEnums",
		"ProcessLandingConditionalTransitionSchemaResources", "ProcessCampaignConditionalSequenceFlowSchema"],
	function(CampaignEnums) {
	Ext.define("BPMSoft.manager.ProcessLandingConditionalTransitionSchema", {
		extend: "BPMSoft.ProcessCampaignConditionalSequenceFlowSchema",
		alternateClassName: "BPMSoft.ProcessLandingConditionalTransitionSchema",

		managerItemUId: "1F41D061-F3AB-4BE3-9AF7-84BF59D05BD8",

		mixins: {
			parametrizedProcessSchemaElement: "BPMSoft.ParametrizedProcessSchemaElement"
		},

		/**
		 * @inheritdoc BPMSoft.ProcessBaseElementSchema#typeName
		 * @protected
		 * @overridden
		 */
		typeName: "BPMSoft.Configuration.LandingConditionalTransitionElement, BPMSoft.Configuration",

		/**
		 * Sequence flow name.
		 * @type {String}
		 */
		connectionUserHandleName: "LandingConditionalTransition",

		/**
		 * @inheritdoc BPMSoft.ProcessBaseElementSchema#editPageSchemaName
		 */
		editPageSchemaName: "LandingConditionalTransitionPropertiesPage",

		/**
		 * Type of element
		 * @type {String}
		 */
		elementType: CampaignEnums.CampaignSchemaElementTypes.CONDITIONAL_TRANSITION,

		/**
		 * Transition can transfer participants with any status condition
		 * @type {Integer}
		 */
		stepCompletedCondition: CampaignEnums.StepCompletedConditions.COMPLETED,

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#getSerializableProperties
		 * @overridden
		 */
		getSerializableProperties: function() {
			var baseSerializableProperties = this.callParent(arguments);
			Ext.Array.push(baseSerializableProperties, ["stepCompletedCondition"]);
			return baseSerializableProperties;
		},

		/**
		 * @inheritdoc BPMSoft.ProcessCampaignConditionalSequenceFlowSchema#hasNotEmptyFilter
		 * @override
		 */
		hasNotEmptyFilter: function() {
			var result = this.callParent(arguments);
			return result || this.stepCompletedCondition !== CampaignEnums.StepCompletedConditions.ANY;
		}
	});
	return BPMSoft.ProcessLandingConditionalTransitionSchema;
});
