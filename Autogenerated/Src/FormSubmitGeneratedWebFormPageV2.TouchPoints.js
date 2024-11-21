/**
 * @inheritDoc BaseGeneratedWebFormPageV2
 */
define("FormSubmitGeneratedWebFormPageV2", ["FormSubmitGeneratedWebFormPageV2Resources"], function () {
	return {
		methods: {
			/**
			 * @inheritdoc BaseGeneratedWebFormPageV2#getScriptTemplateFromResources
			 * @override
			 */
			getScriptTemplateFromResources: function () {
				return this.get("Resources.Strings.FormSubmitScriptTemplate");
			},

			/**
			 * @inheritdoc BaseGeneratedWebFormPageV2#getCustomFormFields
			 * @override
			 */
			getCustomFormFields: function() {
				return "\"WebFormId\":\"" + this.get("Id") + "\"";
			}
		},
		diff: []
	};
});