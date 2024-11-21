define("FeedbackModule", ["ext-base", "sandbox", "BPMSoft", "BaseSchemaModuleV2"],
	function(Ext, sandbox, BPMSoft) {

		Ext.define("BPMSoft.configuration.FeedbackModule", {
			extend: "BPMSoft.BaseSchemaModule",
			alternateClassName: "BPMSoft.FeedbackModule",

			initSchemaName: function() {
				this.schemaName = BPMSoft.feedbackConfig.schemaName;
			},
			
			renderTo: null,
			useHistoryState: false
		});

		return Ext.create("BPMSoft.FeedbackModule", {
			Ext: Ext,
			sandbox: sandbox,
			renderTo: BPMSoft.appFramework === "NETCOREAPP" ? this.Ext.getBody() : undefined,
			BPMSoft: BPMSoft
		});

	});
