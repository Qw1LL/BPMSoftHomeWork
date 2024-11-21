define("CaseGeneratedWebFormPageV2", ["CaseGeneratedWebFormPageV2Resources"],
	function() {
		return {
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			methods: {

				/**
				 * @inheritdoc BaseGeneratedWebFormPageV2#getScriptTemplateFromResources
				 * @overriden
				 */
				getScriptTemplateFromResources: function() {
					var scriptTemplate;
					if (this.getIsFeatureEnabled("OutboundCampaign")) {
						scriptTemplate = this.get("Resources.Strings.CaseScriptTemplate");
					} else {
						scriptTemplate = this.get("Resources.Strings.ScriptTemplate");
					}
					return scriptTemplate;
				}
			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	});
