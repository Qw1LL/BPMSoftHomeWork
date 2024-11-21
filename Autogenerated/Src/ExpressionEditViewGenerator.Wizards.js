define("ExpressionEditViewGenerator", ["ViewGeneratorV2", "ExpressionEnums"], function() {
	Ext.define("BPMSoft.configuration.ExpressionEditViewGenerator", {
		extend: "BPMSoft.ViewGenerator",
		alternateClassName: "BPMSoft.ExpressionEditViewGenerator",

		// region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.ViewGenerator#getConfigWithoutServiceProperties
		 * @override
		 */
		getConfigWithoutServiceProperties: function(config, serviceProperties) {
			serviceProperties.push("expressionType");
			return this.callParent(arguments);
		},

		/**
		 * @inheritdoc BPMSoft.ViewGenerator#generateLookupEdit
		 * @override
		 */
		generateLookupEdit: function() {
			var lookupEditConfig = this.callParent(arguments);
			delete lookupEditConfig.loadVocabulary;
			delete lookupEditConfig.change;
			delete lookupEditConfig.href;
			delete lookupEditConfig.linkclick;
			delete lookupEditConfig.linkmouseover;
			return lookupEditConfig;
		},

		// endregion

		// region Methods: Public

		/**
		 * Generates edit item config.
		 * @param {Object} config Input config.
		 * @return {Object} Edit control config.
		 */
		generateEditItem: function(config) {
			const expressionType = config.expressionType;
			let editItem;
			switch (expressionType) {
				case BPMSoft.ExpressionEnums.ExpressionType.ATTRIBUTE:
					config.contentType = BPMSoft.ContentType.ENUM;
					editItem = this.generateLookupEdit(config);
					break;
				case BPMSoft.ExpressionEnums.ExpressionType.SYSVALUE:
					config.contentType = BPMSoft.ContentType.ENUM;
					editItem = this.generateLookupEdit(config);
					break;
				case BPMSoft.ExpressionEnums.ExpressionType.COLUMN:
					editItem = this.generateLookupEdit(config);
					break;
				case BPMSoft.ExpressionEnums.ExpressionType.PARAMETER:
					editItem = config.contentType === BPMSoft.ContentType.LOOKUP
						? this.generateLookupEdit(config)
						: this.generateEnumEdit(config);
					break;
				case BPMSoft.ExpressionEnums.ExpressionType.CONSTANT:
					editItem = BPMSoft.isGUIDDataValueType(config.dataValueType)
						? this.generateTextEdit(config)
						: this.generateEditControl(config);
					break;
				default:
					editItem = this.generateEditControl(config);
			}
			return editItem;
		}

		// endregion

	});
});
