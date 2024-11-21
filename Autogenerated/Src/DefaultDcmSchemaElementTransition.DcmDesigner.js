define("DefaultDcmSchemaElementTransition", ["DefaultDcmSchemaElementTransitionResources"],
	function(resources) {
		Ext.define("BPMSoft.configuration.DefaultDcmSchemaElementTransition", {
			extend: "BPMSoft.BaseProcessSchemaItem",
			alternateClassName: "BPMSoft.DefaultDcmSchemaElementTransition",

			statics: {
				caption: resources.localizableStrings.Caption,
				typeUId: "b55aba93-5590-4806-92f2-c2a7b9d5c379",
				typeName: "BPMSoft.Core.DcmProcess.DefaultDcmSchemaElementTransition"
			},

			//region Properties: Public

			/**
			 * DcmSchemaElement UId for which transition is created.
			 * @type {String}
			 */
			elementUId: null,

			//endregion

			//region Constructors: Public

			/**
			 * @inheritdoc BPMSoft.configuration.BaseProcessSchemaItem#constructor
			 * @overridden
			 */
			constructor: function() {
				this.callParent(arguments);
				var statics = this.getStatics();
				this.typeName = statics.typeName;
			},

			//endregion

			//region Methods: Protected

			/**
			 * Returns class statics members.
			 * @virtual
			 * @protected
			 * @return {Object}
			 */
			getStatics: function() {
				return this.statics();
			},

			//endregion

			//region Methods: Private

			/**
			 * @inheritdoc BPMSoft.manager.BaseSchema#getSerializableProperties
			 * @overridden
			 */
			getSerializableProperties: function() {
				var properties = this.callParent(arguments);
				return Ext.Array.push(properties, ["elementUId"]);
			},

			//endregion

			//region Methods: Public

			/**
			 * Returns transition typrUId.
			 * @return {String}
			 */
			getTransitionTypeUId: function() {
				var statics = this.getStatics();
				return statics.typeUId;
			},

			/**
			 * Returns DcmSchemaElement transition target element.
			 * @return {BPMSoft.BaseProcessSchemaElement}
			 */
			findElement: function() {
				return this.parentSchema.findItemByUId(this.elementUId);
			},

			/**
			 * Returns DcmSchemaElement transition source element. Returns target element stage.
			 * @virtual
			 * @return {BPMSoft.BaseProcessSchemaElement}
			 */
			findSourceElement: function() {
				var element = this.findElement();
				return this.parentSchema.findItemByUId(element.containerUId);
			},

			/**
			 * Validates DcmSchemaElement transition.
			 * @virtual
			 * @return {Boolean}
			 */
			validate: function() {
				return !Ext.isEmpty(this.elementUId) &&
					this.elementUId !== BPMSoft.GUID_EMPTY;
			}

			//endregion

		});
		return BPMSoft.DefaultDcmSchemaElementTransition;
	}
);
