/**
 * Parent: BaseProcessParametersEditModule
 */
define("ProcessParameterSelectionModule", ["BaseProcessParametersEditModule", "css!ProcessMappingModalBoxStyles"],
	function() {

		Ext.define("BPMSoft.configuration.ProcessParameterSelectionModule", {
			alternateClassName: "BPMSoft.ProcessParameterSelectionModule",
			extend: "BPMSoft.BaseProcessParametersEditModule",

			/**
			 * @inheritdoc BPMSoft.BaseSchemaModule#initSchemaName
			 * @overridden
			 */
			initSchemaName: function() {
				this.schemaName = "ProcessParameterSelectionPage";
			}
		});

		return BPMSoft.ProcessParameterSelectionModule;
	});
