/**
 * @deprecated
 * Will be deleted with old content builder (Grid).
 */
define("ProcessEmailContentTextElementViewModel", ["InlineParameterTextEdit", "ContentTextElementViewModel",
	"MappingEditMixin"], function() {
		Ext.define("BPMSoft.ContentBuilder.ProcessEmailContentTextElementViewModel", {
			extend: "BPMSoft.ContentTextElementViewModel",
			alternateClassName: "BPMSoft.ProcessEmailContentTextElementViewModel",

			mixins: {
				mappingEditMixin: "BPMSoft.MappingEditMixin"
			},

			/**
			 * Sandbox instance.
			 * @private
			 * @type {Object}
			 */
			sandbox: null,

			/**
			 * User task invoker uid of the mapping page.
			 * @private
			 * @type {String}
			 */
			invokerUId: null,

			/**
			 * @inheritdoc BPMSoft.MappingEditMixin#getInvokerUId
			 * @protected
			 * @overridden
			 */
			getInvokerUId: function() {
				return this.invokerUId;
			},

			/**
			 * @inheritdoc BPMSoft.BaseViewModel#constructor
			 * @overridden
			 */
			constructor: function() {
				this.callParent(arguments);
				this.initDesignerType();
			},

			/**
			 * @type {String}
			 * On parameter button click handler.
			 * @private
			 */
			onParameterButtonClick: function() {
				this.openEmailMappingWindow(this.onModalBoxSave, this);
			},

			/**
			 * On modal box close handler.
			 * @param {Object} parameter Modal box result parameter.
			 * @param {String} parameter.displayValue Display value of the result parameter.
			 * @private
			 */
			onModalBoxSave: function(parameter) {
				var htmlParameter = Ext.create("BPMSoft.InlineTextEditMacros", {
					value: parameter.value,
					displayValue: parameter.displayValue
				});
				this.set("SelectedText", htmlParameter.toHtml());
			},

			/**
			 * @inheritdoc BPMSoft.ContentElementBaseViewModel#getViewConfig
			 * @protected
			 * @overridden
			 */
			getViewConfig: function() {
				const viewConfig = this.callParent();
				const editorItem = _.find(viewConfig.items, function(item) {
					return item.className === "BPMSoft.InlineCodeTextEdit";
				}, this);
				Ext.apply(editorItem, {
					"className": "BPMSoft.InlineParameterTextEdit",
					"parameterclick": "$onParameterButtonClick"
				});
				return viewConfig;
			}
		});
	});
