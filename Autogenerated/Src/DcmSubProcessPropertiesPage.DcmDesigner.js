/**
 * Parent: SubProcessPropertiesPage => ProcessFlowElementPropertiesPage => BaseProcessSchemaElementPropertiesPage
 */
define("DcmSubProcessPropertiesPage", [],
	function() {
		return {

			/**
			 * Use base DCM schema.
			 * @type {Boolean}
			 */
			useBaseDcmSchema: true,

			attributes: {
				/**
				 * @inheritdoc BPMSoft.BaseDcmSchemaElementPropertiesPage#UseConditions
				 * @override
				 */
				"UseConditions": {
					"value": true
				},

				/**
				 * @inheritdoc BPMSoft.BaseDcmSchemaElementPropertiesPage#UseFormulaConditions
				 * @override
				 */
				"UseFormulaConditions": {
					"value": true
				}
			},

			methods: {

				// region Methods: Protected

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
				 * @override
				 */
				init: function() {
					var parentInit = this.getParentMethod();
					var parentArguments = arguments;
					BPMSoft.ProcessFlowElementSchemaManager.initialize(function() {
						parentInit.apply(this, parentArguments);
					}, this);
				},

				/**
				 * @inheritdoc BPMSoft.SubProcessPropertiesPage#setElementCaptionBySchema
				 * @override
				 */
				setElementCaptionBySchema: BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.SubProcessPropertiesPage#synchronizeParameters
				 * @override
				 */
				synchronizeParameters: function(element, schema) {
					this.callParent(arguments);
					if (schema !== null) {
						var parentSchema = element.parentSchema;
						parentSchema.setEntityConnectionParameterDefaultValue(element);
					}
				},

				/**
				 * @inheritdoc BPMSoft.SubProcessPropertiesPage#getCanRemoveElement
				 * @override
				 */
				getCanRemoveElement: function(callback, scope) {
					var element = this.get("DcmElement");
					BPMSoft.ProcessSchemaDesignerUtilities.validateElementRemoval(
						element.parentSchema, [element.name], callback, scope);
				},

				/**
				 * @inheritdoc BPMSoft.SubProcessPropertiesPage#findLinksToElements
				 * @override
				 */
				findLinksToElements: function(element) {
					return element.parentSchema.findLinksToElements([this.$DcmElement.name]);
				}

				// endregion

			},

			diff: /**SCHEMA_DIFF*/[
			]/**SCHEMA_DIFF*/
		};
	}
);
