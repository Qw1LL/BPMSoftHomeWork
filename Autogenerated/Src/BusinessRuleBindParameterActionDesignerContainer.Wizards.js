define("BusinessRuleBindParameterActionDesignerContainer",["BusinessRuleActionDesignerContainer",
	"css!BusinessRuleBindParameterActionDesignerContainer", "ExpressionEdit"], function() {

		/**
		 * @class BPMSoft.controls.BusinessRuleBindParameterActionDesignerContainer
		 */
		Ext.define("BPMSoft.controls.BusinessRuleBindParameterActionDesignerContainer", {
			extend: "BPMSoft.BusinessRuleActionDesignerContainer",
			alternateClassName: "BPMSoft.BusinessRuleBindParameterActionDesignerContainer",

			//region Properties: Private

			/**
			 * Right expression items.
			 * @type {Array/Ext.util.MixedCollection}
			 */
			expressionItem: null,

			/**
			 * Expression hint.
			 * @type {String}
			 */
			expressionItemHint: null,

			businessRuleActionWebComponent: null,

			showAngularBusinessRuleActionComponent: false,

			//endregion

			//region Methods: Protected

			getActionContentWrapTpl: function() {
				let actionConentTpl = this.callParent(arguments);
				if (this.showAngularBusinessRuleActionComponent) {
					actionConentTpl = "{%this.renderViewItemsProperty(out, values, 'businessRuleActionWebComponent')%}";
				}
				return actionConentTpl;
			},

			getBlockTpl: function(blockName) {
				if (blockName === "businessRuleActionWebComponent") {
					return "";
				}
				return this.callParent(arguments);
			},

			/**
			 * Return content block tpl
			 * @param  {String} blockName Content block name.
			 * @return {String} content block tpl.
			 */
			getBlockHeaderTpl: function(blockName) {
				let tpl;
				if (blockName === "expressionItem") {
					tpl = "<div id=\"{id}-{0}-header\" class=\"{blockHeaderClass} {{0}BlockHeaderClass}\">" +
						"<label>{expressionItemHint}</label>" +
						"</div>";
				} else if (blockName === "businessRuleActionWebComponent") {
					return "";
				} else {
					tpl = this.callParent(arguments);
				}
				return Ext.String.format(tpl, blockName);
			},

			/**
			* @inheritdoc BPMSoft.controls.Component#getBindConfig
			* @overridden
			*/
			getBindConfig: function() {
				var bindConfig = this.callParent(arguments);
				var actionBindConfig = {
					"expressionItemHint": {
						changeMethod: "onChangeExpressionItemHint"
					}
				};
				Ext.apply(actionBindConfig, bindConfig);
				return actionBindConfig;
			},

			/**
			 * Handler of change expression items hint.
			 * @param {String} value Expression item hint.
			 */
			onChangeExpressionItemHint: function(value) {
				if (this.expressionItemHint === value) {
					return;
				}
				this.expressionItemHint = value;
			},

			/**
			 * @inheritdoc BPMSoft.BusinessRuleActionDesignerContainer#getBlockNameList
			 * @overridden
			 */
			getBlockNameList: function() {
				var blockNameList = this.callParent(arguments);
				blockNameList.push("expressionItem");
				blockNameList.push("businessRuleActionWebComponent");
				return blockNameList;
			},

			/**
			 * @inheritdoc BPMSoft.Component#getTplData
			 * @overridden
			 */
			getTplData: function() {
				var tplData = this.callParent(arguments);
				var actionTplData = {};
				var wrapClasses = ["bindable-action-wrap"];
				if (tplData.wrapClass) {
					wrapClasses.push(tplData.wrapClass);
				}
				actionTplData.expressionItemHint = this.expressionItemHint;
				actionTplData.wrapClass = wrapClasses;
				Ext.apply(tplData, actionTplData, {});
				return tplData;
			}

			//endregion

		});
		return BPMSoft.BusinessRuleBindParameterActionDesignerContainer;
	});
