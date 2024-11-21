define("DcmSchemaElement", ["ext-base", "BPMSoft", "DcmElementSchemaManager", "DcmConstants"
], function(Ext, BPMSoft) {

	/**
	 * @class BPMSoft.configuration.DcmSchemaElement
	 */
	Ext.define("BPMSoft.configuration.DcmSchemaElement", {
		extend: "BPMSoft.BaseProcessSchemaElement",
		alternateClassName: "BPMSoft.DcmSchemaElement",

		mixins: {
			parametrizedProcessSchemaElement: "BPMSoft.ParametrizedProcessSchemaElement"
		},

		//region Properties: Public

		/**
		 * @inheritdoc BPMSoft.configuration.BaseProcessSchemaElement#typeName
		 * @overridden
		 */
		typeName: "BPMSoft.Core.DcmProcess.DcmSchemaElement",

		/**
		 * Process flow element.
		 * @type {BPMSoft.manager.ProcessFlowElementSchema}
		 */
		processFlowElement: null,

		/**
		 * Required step type.
		 * @type {Number}
		 */
		requiredType: null,

		/**
		 * JSON string with conditions to change stage depends on result parameter after element complete.
		 * @type {String}
		 */
		conditions: null,

		//endregion

		//region Constructors: Public

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#constructor
		 * @overridden
		 */
		constructor: function() {
			this.callParent(arguments);
			this.initProcessFlowElement();
		},

		//endregion

		//region Methods: Private

		/**
		 * @inheritdoc BPMSoft.manager.BaseProcessSchemaElement#getSerializableProperties
		 * @overridden
		 */
		getSerializableProperties: function() {
			var properties = this.callParent(arguments);
			return Ext.Array.push(properties, ["requiredType", "conditions"]);
		},

		/**
		 * Initialize process flow element.
		 * @private
		 */
		initProcessFlowElement: function() {
			var metaData = this.processFlowElement;
			if (metaData) {
				var managerItemUId = metaData.managerItemUId;
				var manager = BPMSoft.DcmElementSchemaManager;
				var processElement = manager.createInstance(managerItemUId, metaData);
				processElement.parentSchema = this.parentSchema;
				this.processFlowElement = processElement;
				this.isValid = processElement.isValid;
				this.parameters = processElement.parameters;
			}
		},

		//endregion

		//region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#getSerializableObject
		 * @overridden
		 */
		getSerializableObject: function(serializableObject) {
			this.callParent(arguments);
			var processFlowElementMetaData = {};
			var processFlowElement = this.processFlowElement;
			if (processFlowElement) {
				processFlowElement.getSerializableObject(processFlowElementMetaData);
				serializableObject.processFlowElement = processFlowElementMetaData;
			}
		},

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#loadLocalizableValues
		 * @overridden
		 */
		loadLocalizableValues: function(localizableValues) {
			this.callParent(arguments);
			var flowElement = this.processFlowElement;
			flowElement.loadLocalizableValues(localizableValues.ProcessFlowElement || {});
		},

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#loadLocalizableValuesByUIds
		 * @overridden
		 */
		loadLocalizableValuesByUIds: function(localizableValues) {
			this.callParent(arguments);
			this.processFlowElement.loadLocalizableValuesByUIds(localizableValues);
		},

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#getLocalizableValues
		 * @overridden
		 */
		getLocalizableValues: function(localizableValues) {
			this.callParent(arguments);
			this.processFlowElement.getLocalizableValues(localizableValues);
		},

		//endregion

		//region Methods: Public

		/**
		 * @inheritdoc BPMSoft.manager.BaseProcessSchemaElement#getEditPageSchemaName
		 * @protected
		 */
		getEditPageSchemaName: function(callback, scope) {
			this.processFlowElement.getEditPageSchemaName(callback, scope);
		},

		/**
		 * Returns small image configuration.
		 * @protected
		 * @return {Object} Image config.
		 */
		getSmallImage: function() {
			return this.processFlowElement.getSmallImage();
		},

		/**
		 * Returns small image configuration for dcm stage element view.
		 * @protected
		 * @return {Object} Image config.
		 */
		getDcmSmallImage: function() {
			var flowElement = this.processFlowElement;
			return flowElement.getImageConfig(flowElement.dcmSmallImageName);
		},

		/**
		 * Returns DcmSchemaElement transition. If DcmSchema doesn't contains transition for element,
		 * creates new transition.
		 * @return {BPMSoft.DefaultDcmSchemaElementTransition}
		 */
		getTransition: function() {
			var transition = this.parentSchema.findTransitionByElementUId(this.uId);
			if (!transition) {
				transition = BPMSoft.DcmSchemaElementTransitionFactory.createDefaultTransition({
					elementUId: this.uId,
					parentSchema: this.parentSchema
				});
			}
			return transition;
		},

		/**
		 * Sets DcmSchemaElement transition. If DcmSchema contains transition for element,
		 * removes old and sets new transition.
		 * @param {BPMSoft.DefaultDcmSchemaElementTransition} transition
		 */
		setTransition: function(transition) {
			var existsTransition = this.parentSchema.findTransitionByElementUId(this.uId);
			if (existsTransition) {
				this.parentSchema.removeTransitionByElementUId(this.uId);
			}
			this.parentSchema.addTransition(transition);
		},

		/**
		 * Resets DcmSchemaElement transition to default.
		 */
		setDefaultTransition: function() {
			var existsTransition = this.parentSchema.findTransitionByElementUId(this.uId);
			if (existsTransition) {
				this.parentSchema.removeTransitionByElementUId(this.uId);
			}
		},

		/**
		 * Applies parameters default values.
		 */
		applyParametersDefValues: function() {
			BPMSoft.each(this.processFlowElement.parameters, function(parameter) {
				const defValue = parameter.sourceValue;
				if (defValue?.defValueForDcm) {
					parameter.setValue({
						source: defValue.source,
						value: defValue.defValueForDcm
					});
				}
			}, this);
		}

		//endregion

	});

	Object.defineProperty(BPMSoft.DcmSchemaElement.prototype, "isUserTask", {
		get: function() {
			const flowElement = this.processFlowElement;
			return Boolean(flowElement && flowElement.isUserTask);
		},
		enumerable: true
	});

	Object.defineProperty(BPMSoft.DcmSchemaElement.prototype, "schema", {
		get: function() {
			const flowElement = this.processFlowElement;
			return flowElement && flowElement.schema;
		},
		enumerable: true
	});

	Object.defineProperty(BPMSoft.DcmSchemaElement.prototype, "schemaUId", {
		get: function() {
			const flowElement = this.processFlowElement;
			return flowElement && flowElement.schemaUId;
		},
		enumerable: true
	});

	return BPMSoft.DcmSchemaElement;
});
