define("CampaignSchemaElementPropertiesEdit", ["ProcessSchemaElementPropertiesEdit",
		"css!CampaignSchemaElementPropertiesEditCSS"],
	function() {
		/**
		 * @class BPMSoft.CampaignDesigner.CampaignSchemaElementPropertiesEdit
		 * Class properties editing card module.
		 */
		Ext.define("BPMSoft.CampaignDesigner.CampaignSchemaElementPropertiesEdit", {
			alternateClassName: "BPMSoft.CampaignSchemaElementPropertiesEdit",
			extend: "BPMSoft.ProcessSchemaElementPropertiesEdit"
		});

		return BPMSoft.CampaignSchemaElementPropertiesEdit;
	});
