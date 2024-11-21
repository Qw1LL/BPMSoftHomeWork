 define("SystemNotificationsSchema", [], function() {
    return {
        methods: {
            /**
             * @inheritdoc BPMSoft.configuration.BaseNotificationSchema#onNotificationSubjectClick
             * @overridden
             */
            onNotificationSubjectClick: function() {
                var loaderName = this.get("LoaderName");
              	switch(loaderName){
                	case "LeadGenLog":
                		var url = this.BPMSoft.combinePath(this.BPMSoft.workspaceBaseUrl, "ClientApp/#/SocialLeadgen/settings?tab=logs");
               			window.open(url, "_blank");
                  	break;
                    case "LeadGenWebhooks":
                		var url = this.BPMSoft.combinePath(this.BPMSoft.workspaceBaseUrl, "ClientApp/#/SocialLeadgen/settings");
               			window.open(url, "_blank");
                  	break; 
                    case "SocialLeadGeneration_ProcessingIncomingMessages":
                		var url = this.BPMSoft.combinePath(this.BPMSoft.workspaceBaseUrl, "ClientApp/#/SocialLeadgen/settings");
               			window.open(url, "_blank");
                  	break; 
                     case "SocialLeadGeneration_LoadingLeads":
                		var url = this.BPMSoft.combinePath(this.BPMSoft.workspaceBaseUrl, "ClientApp/#/SocialLeadgen/settings?tab=logs");
               			window.open(url, "_blank");
                  	break; 
                     case "SocialLeadGeneration_ConsistencyCheck":
                		var url = this.BPMSoft.combinePath(this.BPMSoft.workspaceBaseUrl, "ClientApp/#/SocialLeadgen/settings?tab=logs");
               			window.open(url, "_blank");
                  	break; 
                    break; 
                     case "SocialLeadGeneration_LeadCreation":
                		var url = this.BPMSoft.combinePath(this.BPMSoft.workspaceBaseUrl, "ClientApp/#/SocialLeadgen/settings?tab=logs");
               			window.open(url, "_blank");
                  	break; 
                	default:
                    	this.callParent(arguments);
                    	return;
             	}
           }
        },
        diff: []
    };
});