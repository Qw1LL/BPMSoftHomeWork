define("CampaignElementShapeForm", [], function() {
	Ext.define("BPMSoft.configuration.CampaignElementShapeForm", {
		alternateClassName: "BPMSoft.CampaignElementShapeForm",

		/**
		 * @public
		 */
		convertNodeTypeInShapeForm: function(nodeType) {
			switch (true) {
				case nodeType === BPMSoft.diagram.UserHandlesConstraint.Event:
					return "circle";
				case nodeType === BPMSoft.diagram.UserHandlesConstraint.Gateway:
					return "rhomb";
				default:
					return "default";
			}
		},
	});
	return Ext.create(BPMSoft.CampaignElementShapeForm);
});
