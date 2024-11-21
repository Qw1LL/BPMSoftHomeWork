define("EmailWithSubjectMLangContentBuilderEnumsModule", ["ContentBuilderEnumsModule"], function() {
	Ext.define("BPMSoft.configuration.EmailWithSubjectMLangContentBuilderEnumsModule", {
		extend: "BPMSoft.ContentBuilderEnumsModule",
		alternateClassName: "BPMSoft.EmailWithSubjectMLangContentBuilderEnumsModule",

		//region Properties: Protected

		ContentBuilderMode: {
			EMAILTEMPLATE: "EmailTemplate"
		},

		//endregion

		//region Methods: Protected

		/**
		 * @inheritDoc BPMSoft.ContentBuilderEnumsModule#getContentBuilderConfigs
		 * @override
		 */
		getContentBuilderConfigs: function() {
			var parentConfig = this.callParent(arguments);
			var emailMLangContentBuilderConfig = {};
			emailMLangContentBuilderConfig[this.ContentBuilderMode.EMAILTEMPLATE] = {
				"ViewModelName": "EmailWithSubjectContentBuilder"
			};
			return Ext.merge(parentConfig, emailMLangContentBuilderConfig);
		},

		/**
		 * @inheritDoc BPMSoft.ContentBuilderEnumsModule#getContentBuilderUrl
		 * @override
		 */
		getContentBuilderUrl: function() {
			var tag = arguments[2];
			var parentUrl = this.callParent(arguments);
			return Ext.String.format("{0}/{1}",
				parentUrl, tag);
		}

		//endregion

	});

	return Ext.create(BPMSoft.EmailWithSubjectMLangContentBuilderEnumsModule);
});
