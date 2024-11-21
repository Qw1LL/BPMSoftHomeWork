define("DynamicHeadersReplicaBuilder", ["DynamicContentReplicaBuilder"], function() {
	Ext.define("BPMSoft.configuration.DynamicHeadersReplicaBuilder", {
		extend: "BPMSoft.DynamicContentReplicaBuilder",
		alternateClassName: "BPMSoft.DynamicHeadersReplicaBuilder",

		getHeaderFn: Ext.emptyFn,

		/**
		 * @inheritDoc BPMSoft.DynamicContentReplicaBuilder#getReplicaConfig
		 * @override
		 */
		getReplicaConfig: function(templateJson, replicaMask, captionBuilder){
			var replicaConfig = this.callParent(arguments);
			if(replicaConfig) {
				replicaConfig.PreHeaderText = this.getHeaderFn(replicaConfig.ReplicaMask);
			}
			return replicaConfig;
		}
	});
	return BPMSoft.configuration.DynamicHeadersReplicaBuilder;
});
