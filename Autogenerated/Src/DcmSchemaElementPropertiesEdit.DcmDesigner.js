define("DcmSchemaElementPropertiesEdit", ["ProcessSchemaElementPropertiesEdit",
		"DcmSchemaElementPropertiesPageBuilder"],
	function() {

		/**
		 * @class BPMSoft.ProcessDesigner.DcmSchemaElementPropertiesEdit
		 * Class properties editing card module.
		 */
		Ext.define("BPMSoft.ProcessDesigner.DcmSchemaElementPropertiesEdit", {
			alternateClassName: "BPMSoft.DcmSchemaElementPropertiesEdit",
			extend: "BPMSoft.ProcessSchemaElementPropertiesEdit",

			/**
			 * @inheritdoc BPMSoft.BaseSchemaModule#generateSchemaStructure
			 * @protected
			 * @overridden
			 */
			generateSchemaStructure: function() {
				this.schemaBuilder = Ext.create("BPMSoft.DcmSchemaElementPropertiesPageBuilder");
				this.callParent(arguments);
			}
		});

		return BPMSoft.DcmSchemaElementPropertiesEdit;
	});
