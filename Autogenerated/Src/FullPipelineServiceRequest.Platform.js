define("FullPipelineServiceRequest", ["ConfigurationServiceRequest"], function() {
	Ext.define("BPMSoft.configuration.FullPipelineServiceRequest", {
		extend: "BPMSoft.ConfigurationServiceRequest",
		alternateClassName: "BPMSoft.FullPipelineServiceRequest",

		serviceName: "FullPipelineService",

		contractName: "GetAllSlicesFullPipelineData",

		pipelineConfig: {},

		getSerializableObject: function(serializableObject) {
			this.callParent(arguments);
			serializableObject.pipelineConfig = this.pipelineConfig;
		}
	});
});
