 Ext.ns("BPMSoft.CampaignDesigner.enums");

BPMSoft.CampaignDesigner.enums.CampaignDiagramElements = {
	"BPMSoft.Configuration.SequenceFlowElement, BPMSoft.Configuration": {
		type: "connection"
	},
	"BPMSoft.Configuration.ConditionalSequenceFlowElement, BPMSoft.Configuration": {
		type: "connection"
	},
	"BPMSoft.Configuration.EmailConditionalTransitionElement, BPMSoft.Configuration": {
		type: "connection"
	},
	"BPMSoft.Configuration.EventConditionalTransitionElement, BPMSoft.Configuration": {
		type: "connection"
	},
	"BPMSoft.Configuration.LandingConditionalTransitionElement, BPMSoft.Configuration": {
		type: "connection"
	},
	"BPMSoft.Configuration.MarketingEmailElement, BPMSoft.Configuration": {
		type: "shape"
	},
	"BPMSoft.Configuration.AddCampaignParticipantElement, BPMSoft.Configuration": {
		type: "shape"
	},
	"BPMSoft.Configuration.CampaignLandingElement, BPMSoft.Configuration": {
		type: "shape"
	},
	"BPMSoft.Configuration.CampaignEventElement, BPMSoft.Configuration": {
		type: "shape"
	},
	"BPMSoft.Configuration.ExitFromCampaignElement, BPMSoft.Configuration": {
		type: "shape"
	},
	"BPMSoft.Configuration.CampaignStartSignalElement, BPMSoft.Configuration": {
		type: "shape"
	},
	"BPMSoft.Configuration.CampaignAddObjectElement, BPMSoft.Configuration": {
		type: "shape"
	},
	"BPMSoft.Configuration.CampaignUpdateObjectElement, BPMSoft.Configuration": {
		type: "shape"
	},
	"BPMSoft.Configuration.CampaignTimerElement, BPMSoft.Configuration": {
		type: "shape"
	}
};

BPMSoft.CampaignDiagramElements = BPMSoft.CampaignDesigner.enums.CampaignDiagramElements;
