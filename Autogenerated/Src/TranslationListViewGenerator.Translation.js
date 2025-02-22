﻿define("TranslationListViewGenerator", ["ext-base", "BPMSoft", "ViewGeneratorV2"], function(Ext, BPMSoft) {
	/**
	 * @class BPMSoft.configuration.TranslationListViewGenerator
	 *
	 */
	Ext.define("BPMSoft.configuration.TranslationListViewGenerator", {
		extend: "BPMSoft.ViewGenerator",
		alternateClassName: "BPMSoft.TranslationListViewGenerator",

		//region Methods: Protected

		/**
		 * Returns configuration for edit translation text.
		 * @param {Object} columnInfo Translation column information.
		 * @param {String} columnInfo.columnCaption Translation column caption.
		 * @param {String} columnInfo.cultureIndex Translation column culture index.
		 * @return {Object}
		 */
		getTranslationTextEditConfig: function(columnInfo) {
			return {
				"name": "Language" + columnInfo.cultureIndex,
				"caption": columnInfo.caption,
				"contentType": BPMSoft.ContentType.LONG_TEXT
			};
		},

		/**
		 * Returns configuration for edit translation text.
		 * @param {Object} columnInfo Translation column information.
		 * @param {String} columnInfo.cultureIndex Translation column culture index.
		 * @return {Object}
		 */
		getTranslationVerifyEditConfig: function(columnInfo) {
			return {
				"name": "IsVerified" + columnInfo.cultureIndex,
				"labelConfig": {"visible": false}
			};
		},

		/**
		 * Returns single culture value controls configuration.
		 * @protected
		 * @param {Object} columnInfo Translation column information.
		 * @param {String} columnInfo.columnCaption Translation column caption.
		 * @param {String} columnInfo.cultureIndex Translation column culture index.
		 * @return {Object}
		 */
		getTranslationRowConfig: function(columnInfo) {
			var cultureIndex = columnInfo.cultureIndex;
			var columnCaption = columnInfo.caption;
			return {
				name: "TranslationValuesContainer" + cultureIndex,
				itemType: BPMSoft.ViewItemType.CONTAINER,
				wrapClass: ["control-width-15", "translation-controls-container"],
				markerValue: columnCaption,
				items: [
					this.getTranslationTextEditConfig(columnInfo),
					this.getTranslationVerifyEditConfig(columnInfo)
				]
			};
		},

		/**
		 * Returns current generator initialization config, applies custom config to the default values.
		 * @param {Object} config Custom config.
		 * @return {Object}
		 */
		getInitConfig: function(config) {
			return Ext.apply({
				schema: {},
				schemaType: BPMSoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,
				schemaName: "TranslationPage"
			}, config);
		},

		//endregion

		//region Methods: Public

		/**
		 * Generates translation controls configuration for multiple cultures.
		 * @param {Object[]} columnsInfo Array contains information about columns.
		 * @param {Number} columnsInfo.cultureIndex Culture index which corresponds to the column.
		 * @param {String} columnsInfo.caption Column caption.
		 * @param {Object} initializationConfig View generator config.
		 * @param {Class} initializationConfig.viewModelClass Class of the view model.
		 * @return {Object} View configuration.
		 */
		generateTranslationsView: function(columnsInfo, initializationConfig) {
			var items = [];
			BPMSoft.each(columnsInfo, function(columnInfo) {
				var translationRowConfig = this.getTranslationRowConfig(columnInfo);
				items.push(translationRowConfig);
			}, this);
			var initConfig = this.getInitConfig(initializationConfig);
			var editConfig = this.generatePartial(
				{
					name: "TranslationsContainer",
					itemType: BPMSoft.ViewItemType.CONTAINER,
					items: items
				},
				initConfig
			);
			return editConfig[0];
		}

		//endregion

	});
});
