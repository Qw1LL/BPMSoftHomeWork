define("SystemDesigner", [],
	function() {
		return {
			methods: {
				/**
				 * Checks whether scoring is enabled.
				 * @return {Boolean} Returns true if scoring is enabled.
				 */
				getScoringEnabled: function() {
					return BPMSoft.Features.getIsEnabled("Scoring");
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"propertyName": "items",
					"parentName": "SystemSettingsTile",
					"name": "SiteEventTypeSetup",
					"values": {
						"itemType": BPMSoft.ViewItemType.LINK,
						"caption": {"bindTo": "Resources.Strings.ScoringModelCaption"},
						"tag": "SectionModuleV2/ScoringModelSectionV2",
						"click": {"bindTo": "onNavigateTo"},
						"visible": {"bindTo": "getScoringEnabled"}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
