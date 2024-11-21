define("WSEntitySchemaFilterProvider", ["BPMSoft", "sandbox", "WSEntitySchemaFilterProviderResources", "StructureExplorerUtilities", "LookupUtilities"], 
function(BPMSoft, sandbox, resources, StructureExplorerUtilities, LookupUtilities) {
	Ext.define("BPMSoft.data.filters.WSEntitySchemaFilterProvider", {
		alternateClassName: "BPMSoft.WSEntitySchemaFilterProvider",
		override: "BPMSoft.EntitySchemaFilterProvider",
		
		getLeftExpressionConfig: function() {
			if (this.sandbox){
				if ( (this.sandbox.id == "WSPattern1Page_FilterEditModule") || (this.sandbox.id == "WSColourOfField1Page_FilterEditModule") ){
					/*return {
						excludeDataValueTypes: [BPMSoft.DataValueType.IMAGELOOKUP],
						useBackwards: true,
						ExpandVisible: false,
						displayId: true,
						firstColumnsOnly: true,
					};*/
				}
			}
			return this.callParent(arguments);
		},
		
		initDateMacrosTypes: function() {
			if (this.sandbox){
				if ( (this.sandbox.id == "WSPattern1Page_FilterEditModule") || (this.sandbox.id == "WSColourOfField1Page_FilterEditModule") ){
					return;
				}
			}
			this.callParent(arguments);
		},
	});
});