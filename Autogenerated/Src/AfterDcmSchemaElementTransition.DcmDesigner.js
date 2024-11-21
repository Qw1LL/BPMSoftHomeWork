define("AfterDcmSchemaElementTransition", ["AfterDcmSchemaElementTransitionResources",
		"DefaultDcmSchemaElementTransition"],
	function(resources) {
		Ext.define("BPMSoft.configuration.AfterDcmSchemaElementTransition", {
			extend: "BPMSoft.DefaultDcmSchemaElementTransition",
			alternateClassName: "BPMSoft.AfterDcmSchemaElementTransition",

			statics: {
				caption: resources.localizableStrings.Caption,
				typeUId: "f38307ae-26d6-4e66-ac91-1d07a0e1f252",
				typeName: "BPMSoft.Core.DcmProcess.AfterDcmSchemaElementTransition"
			},

			//region Properties: Public

			/**
			 * Source DcmSchemaElement uId after which {@link #elementUId} should be run.
			 */
			sourceElementUId: null,

			//endregion

			//region Methods: Protected

			/**
			 * Returns class statics members.
			 * @overridden
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
				return Ext.Array.push(properties, ["sourceElementUId"]);
			},

			//endregion

			//region Methods: Public

			/**
			 * Returns DcmSchemaElement transition source element. Returns source DcmSchemaElement.
			 * @overridden
			 * @return {BPMSoft.BaseProcessSchemaElement}
			 */
			findSourceElement: function() {
				return this.parentSchema.findItemByUId(this.sourceElementUId);
			},

			/**
			 * @inheritdoc BPMSoft.DefaultDcmSchemaElementTransition#validate
			 * @overridden
			 * @return {Boolean}
			 */
			validate: function() {
				var isValid = this.callParent(arguments);
				if (!isValid) {
					return false;
				}
				var sourceDcmElement = this.findSourceElement();
				var dcmElement = this.findElement();
				var sourceDcmElementContainerUId = sourceDcmElement ? sourceDcmElement.containerUId : null;
				var isElementsInOneContainer = sourceDcmElementContainerUId === dcmElement.containerUId;
				return isElementsInOneContainer;
			}

			//endregion

		});
		return BPMSoft.AfterDcmSchemaElementTransition;
	}
);
