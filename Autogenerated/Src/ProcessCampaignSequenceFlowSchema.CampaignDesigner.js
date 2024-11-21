define("ProcessCampaignSequenceFlowSchema", ["ProcessCampaignSequenceFlowSchemaResources",
	"CampaignEnums", "CampaignElementMixin"], function(resources, CampaignEnums) {
	Ext.define("BPMSoft.manager.ProcessCampaignSequenceFlowSchema", {
		extend: "BPMSoft.ProcessSequenceFlowSchema",
		alternateClassName: "BPMSoft.ProcessCampaignSequenceFlowSchema",

		mixins: {
			parametrizedProcessSchemaElement: "BPMSoft.ParametrizedProcessSchemaElement",
			campaignElementMixin: "BPMSoft.CampaignElementMixin"
		},

		/**
		 * @inheritdoc BPMSoft.ProcessBaseElementSchema#typeName
		 * @protected
		 * @overridden
		 */
		typeName: "BPMSoft.Configuration.SequenceFlowElement, BPMSoft.Configuration",

		/**
		 * Sequence flow name.
		 * @type {String}
		 */
		connectionUserHandleName: "CampaignSequenceFlow",

		/**
		 * @inheritdoc BPMSoft.ProcessBaseElementSchema#editPageSchemaName
		 */
		editPageSchemaName: "CampaignSequenceFlowPropertiesPage",

		/**
		 * Type of element
		 * @type {string}
		 */
		elementType: CampaignEnums.CampaignSchemaElementTypes.TRANSITION,

		/**
		 * Hint of element.
		 * @protected
		 * @type {String}
		 */
		hint: null,

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#caption
		 */
		caption: resources.localizableStrings.Caption,

		/**
		 * Is synchronous.
		 * @protected
		 * @type {Boolean}
		 */
		isSynchronous: false,

		/**
		 * Priority of transition.
		 * @protected
		 * @type {number}
		 */
		priority: -1,

		/**
		 * Description text.
		 * @type {String}
		 */
		description: null,

		constructor: function() {
			this.callParent(arguments);
			this.mixins.parametrizedProcessSchemaElement.constructor.call(this);
		},

		/**
		 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#getTitleImage
		 * @override
		 */
		getTitleImage: function() {
			return this.mixins.campaignElementMixin
				.getImage(resources.localizableImages.TitleImage);
		},

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#getSerializableProperties
		 * @overridden
		 */
		getSerializableProperties: function() {
			var baseSerializableProperties = this.callParent(arguments);
			Ext.Array.push(baseSerializableProperties, ["isSynchronous", "priority"]);
			return baseSerializableProperties;
		},

		/**
		 * @inheritdoc BPMSoft.ProcessSequenceFlowSchema#insertFlowElement
		 * @overridden
		 */
		insertFlowElement: function(flowElement) {
			var parentSchema = this.parentSchema;
			var targetFlowElement = this.findItemByUId(this.targetRefUId);
			var flowElementPoint = parentSchema.getItemPosition(flowElement);
			var targetFlowElementPoint = parentSchema.getItemPosition(targetFlowElement);
			var sourcePort = this.getDefSequenceFlowPortName(flowElementPoint, targetFlowElementPoint);
			var newSequenceFlow = Ext.create(this.$className, {
				uId: BPMSoft.generateGUID(),
				name: this.connectionUserHandleName,
				managerItemUId: this.managerItemUId,
				sourceRefUId: flowElement.uId,
				targetRefUId: targetFlowElement.uId,
				showPropertiesWindowOnAdding: false
			});
			newSequenceFlow.sourceSequenceFlowPointLocalPosition = sourcePort;
			newSequenceFlow.targetSequenceFlowPointLocalPosition = this.targetSequenceFlowPointLocalPosition;
			var sourceFlowElement = this.findItemByUId(this.sourceRefUId);
			var sourceFlowElementPoint = parentSchema.getItemPosition(sourceFlowElement);
			var targetPort = this.getDefSequenceFlowPortName(flowElementPoint, sourceFlowElementPoint);
			this.targetRefUId = flowElement.uId;
			this.targetSequenceFlowPointLocalPosition = targetPort;
			return newSequenceFlow;
		},

		/**
		 * Applies specific logic when server saving process is successfully finished.
		 * @protected
		 */
		onAfterSave: function() {
			return;
		},

		/**
		 * Validates campaign schema sequence flow element as a part of campaign flow schema.
		 * @protected
		 */
		validate: BPMSoft.emptyFn,

		/**
		 * @inheritdoc BPMSoft.CampaignBaseElementSchema#applyElementData
		 * @override
		 */
		applyElementData: BPMSoft.emptyFn
	});
	return BPMSoft.ProcessCampaignSequenceFlowSchema;
});
