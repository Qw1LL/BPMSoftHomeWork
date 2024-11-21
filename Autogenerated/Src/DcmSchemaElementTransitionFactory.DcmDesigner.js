define("DcmSchemaElementTransitionFactory", ["DcmSchemaElementTransitionFactoryResources",
		"DefaultDcmSchemaElementTransition", "AfterDcmSchemaElementTransition"],
	function() {
		Ext.define("BPMSoft.configuration.DcmSchemaElementTransitionFactory", {
			extend: "BPMSoft.BaseObject",
			alternateClassName: "BPMSoft.DcmSchemaElementTransitionFactory",
			singleton: true,

			//region Properties: Private

			/**
			 * DcmSchema transition types.
			 * @private
			 */
			transitionTypes: null,

			//endregion

			//region Properties: Public

			/**
			 * Default DcmSchemaElement transition type identifier.
			 * @type {String}
			 */
			defaultTransitionTypeUId: BPMSoft.configuration.DefaultDcmSchemaElementTransition.typeUId,

			//endregion

			//region Constructors: Public

			/**
			 * @inheritdoc BPMSoft.core.BaseObject#constructor
			 * @overridden
			 */
			constructor: function() {
				this.callParent(arguments);
				this.registerTransitionTypes();
			},

			//endregion

			//region Methods: Private

			/**
			 * Register DcmSchemaElement transition types.
			 * @private
			 */
			registerTransitionTypes: function() {
				this.transitionTypes = {};
				this.registerTransitionType("BPMSoft.configuration.DefaultDcmSchemaElementTransition");
				this.registerTransitionType("BPMSoft.configuration.AfterDcmSchemaElementTransition");
			},

			/**
			 * Register DcmSchemaElement transition type
			 * @private
			 * @param {String} className DcmSchemaElement transition class name.
			 */
			registerTransitionType: function(className) {
				var transitionClass = Ext.ClassManager.get(className);
				this.transitionTypes[transitionClass.typeUId] = transitionClass;
			},

			/**
			 * Returns DcmSchemaElement transition class by type name.
			 * @private
			 * @param {String} typeName DcmSchemaElement transition type name.
			 * @return {BPMSoft.DefaultDcmSchemaElementTransition}
			 */
			getTransitionClassByTypeName: function(typeName) {
				var result = null;
				BPMSoft.each(this.transitionTypes, function(transitionClass) {
					if (transitionClass.typeName === typeName) {
						result = transitionClass;
					}
					return result === null;
				}, this);
				return result;
			},

			/**
			 * Returns DcmSchemaElement transition class by type identifier.
			 * @private
			 * @param {String} typeUId DcmSchemaElement transition type identifier.
			 * @return {BPMSoft.DefaultDcmSchemaElementTransition}
			 */
			getTransitionClassByTypeUId: function(typeUId) {
				return this.transitionTypes[typeUId];
			},

			/**
			 * Returns config for DcmSchemaElement transition. Adds uId property if it needed.
			 * @private
			 * @param {Object} config DcmSchemaElement transition config.
			 * @return {Object}
			 */
			getTransitionConfig: function(config) {
				return Ext.apply({}, config, {
					uId: BPMSoft.generateGUID()
				});
			},

			//endregion

			//region Methods: Public

			/**
			 * Returns flag that indicates that typeUId is default DcmSchemaElement transition typeUId.
			 * @param {String} typeUId DcmSchemaElement transition typeUId.
			 * @return {Boolean}
			 */
			getIsDefaultTransitionByTypeUId: function(typeUId) {
				return typeUId === this.defaultTransitionTypeUId;
			},

			/**
			 * Returns DcmSchemaElement transition captions. Returns object where property name is transition typeUId,
			 * and property value is DcmSchemaElement transition caption.
			 * @return {Object}
			 */
			getTransitionsCaptions: function() {
				var result = {};
				BPMSoft.each(this.transitionTypes, function(transitionClass, typeUId) {
					result[typeUId] = transitionClass.caption;
				});
				return result;
			},

			/**
			 * Creates and return DcmSchemaElement transition by typeUId.
			 * @param {String} typeUId DcmSchemaElement transition typeUId.
			 * @param {Object} config DcmSchemaElement transition config.
			 * @return {BPMSoft.DefaultDcmSchemaElementTransition}
			 */
			createTransitionByTypeUId: function(typeUId, config) {
				var transitionClass = this.getTransitionClassByTypeUId(typeUId);
				var transitionConfig = this.getTransitionConfig(config);
				/*jshint newcap: false */
				return new transitionClass(transitionConfig);
				/*jshint newcap: true */
			},

			/**
			 * Creates and return DcmSchemaElement transition by typeName.
			 * @param {String} typeName DcmSchemaElement transition typeName.
			 * @param {Object} config DcmSchemaElement transition config.
			 * @return {BPMSoft.DefaultDcmSchemaElementTransition}
			 */
			createTransitionByTypeName: function(typeName, config) {
				var transitionClass = this.getTransitionClassByTypeName(typeName);
				var transitionConfig = this.getTransitionConfig(config);
				/*jshint newcap: false */
				return new transitionClass(transitionConfig);
				/*jshint newcap: true */
			},

			/**
			 * Creates and return default DcmSchemaElement transition.
			 * @param {Object} config DcmSchemaElement transition config.
			 * @return {BPMSoft.DefaultDcmSchemaElementTransition}
			 */
			createDefaultTransition: function(config) {
				return this.createTransitionByTypeUId(this.defaultTransitionTypeUId, config);
			}

			//endregion

		});
		return BPMSoft.DcmSchemaElementTransitionFactory;
	}
);
