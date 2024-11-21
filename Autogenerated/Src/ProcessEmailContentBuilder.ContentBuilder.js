/**
 * Parent: EmailTemplateContentBuilder
 */
define("ProcessEmailContentBuilder", ["EmailTemplateContentBuilder", "ProcessEmailContentBuilderHelper",
		"ProcessEmailContentMjTextElementViewModel", "ProcessEmailContentMjButtonElementViewModel"], function() {
	return {
		attributes: {
			/**
			 * User task invoker uid of the mapping page.
			 */
			"InvokerUId": {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			}
		},
		messages: {
			/**
			 * @message GetProcessSchema
			 * Returns process schema.
			 */
			"GetProcessSchema": {
				direction: BPMSoft.MessageDirectionType.PUBLISH,
				mode: BPMSoft.MessageMode.PTP
			}
		},
		methods: {

			/**
			 * @inheritdoc BPMSoft.EmailTemplateContentBuilder#save
			 * @override
			 */
			save: function() {
				if (this.validateEmptyItems()) {
					this.forceSave();
				}
			},

			/**
			 * @inheritdoc BPMSoft.configuration.BaseSchemaViewModel#init
			 * @override
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this.$Caption = this.get("Resources.Strings.DefaultCaption");
					callback.call(scope);
				}, this]);
			},

			/**
			 * Splits content into array of strings and macros objects.
			 * @private
			 * @param {String} content Content string.
			 * @return {Array} Array of strings and macros objects.
			 */
			splitContent: function(content) {
				var stringArray = content.split(BPMSoft.process.constants.HTML_PARAMETER_REGEX);
				BPMSoft.each(stringArray, function(item, index) {
					if (this.getIsMacrosString(item)) {
						stringArray[index] = new BPMSoft.InlineTextEditMacros({html: item});
					}
				}, this);
				return stringArray;
			},

			/**
			 * Joins array of strings and macros objects into content string.
			 * @private
			 * @param {Array} contentArray Array of strings and macros objects.
			 * @return {String} Content string.
			 */
			joinContent: function(contentArray) {
				var result = "";
				BPMSoft.each(contentArray, function(item) {
					result += this.getIsMacrosObject(item) ? item.toHtml() : item;
				}, this);
				return result;
			},

			/**
			 * Returns true if string is a macros.
			 * @private
			 * @param {String} string Html string.
			 * @return {Boolean} True if string is macros.
			 */
			getIsMacrosString: function(string) {
				return BPMSoft.process.constants.HTML_PARAMETER_REGEX.test(string);
			},

			/**
			 * Returns true if object is a macros.
			 * @private
			 * @param {Object} object Testing object.
			 * @return {Boolean} True if object is macros.
			 */
			getIsMacrosObject: function(object) {
				return object instanceof BPMSoft.InlineTextEditMacros;
			},

			/**
			 * @inheritdoc BPMSoft.EmailTemplateContentBuilder#setContentSheetConfig
			 * @override
			 */
			setContentSheetConfig: function(emailTemplateData, callback, scope) {
				this.set("InvokerUId", emailTemplateData.invokerUId);
				var config = this.prepareConfig(emailTemplateData);
				this.filterContentSheetConfig(config, callback, scope);
			},

			/**
			 * @inheritdoc BPMSoft.EmailTemplateContentBuilder#filterContentSheetConfig
			 * @override
			 */
			filterContentSheetConfig: function(config, callback, scope) {
				var schema = this.sandbox.publish("GetProcessSchema");
				var textItems = this.filterTextItems(config.Items);
				BPMSoft.eachAsync(textItems,
					function(textItem, next) {
						this.updateMacrosDisplayValues(textItem, schema, next, this);
					},
					function() {
						Ext.callback(callback, scope || this, [config]);
					}, this
				);
			},

			/**
			 * Filters content sheet items by text type.
			 * @param {Array} items Content sheet items.
			 * @return {Array} Only content sheet items.
			 */
			filterTextItems: function(items) {
				var textItems = [];
				BPMSoft.each(items, function(block) {
					BPMSoft.each(block.Items, function(item) {
						if (item.ItemType === "text") {
							textItems.push(item);
						}
					}, this);
				}, this);
				return textItems;
			},

			/**
			 * Process html content of text items.
			 * @private
			 * @param {Object} textItem Content text item.
			 * @param {BPMSoft.ProcessSchema} schema Process schema.
			 * @param {Function} callback Callback.
			 * @param {Object} scope Scope of the callback.
			 */
			updateMacrosDisplayValues: function(textItem, schema, callback, scope) {
				var contentArray = this.splitContent(textItem.Content);
				BPMSoft.eachAsync(contentArray,
					function(item, next) {
						if (this.getIsMacrosObject(item)) {
							BPMSoft.FormulaParserUtils.getFormulaDisplayValue(item.value, schema,
								function(actualDisplayValue) {
									item.displayValue = actualDisplayValue;
									next();
								}, this);
						} else {
							next();
						}
					},
					function() {
						textItem.Content = this.joinContent(contentArray);
						Ext.callback(callback, scope);
					}, this
				);
			},

			/**
			 * @inheritdoc BPMSoft.EmailTemplateContentBuilder#getViewConfig
			 * @override
			 */
			createContentBuilderHelper: function() {
				return new BPMSoft.ProcessEmailContentBuilderHelper({
					sandbox: this.sandbox,
					invokerUId: this.get("InvokerUId")
				});
			}
		}
	};
});
