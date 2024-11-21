define("BusinessRulePopulateItemActionDesignerContainer",["BusinessRuleActionDesignerContainer",
	"css!BusinessRulePopulateItemActionDesignerContainer"
], function() {

	/**
	 * @class BPMSoft.controls.BusinessRulePopulateItemActionDesignerContainer
	 */
	Ext.define("BPMSoft.controls.BusinessRulePopulateItemActionDesignerContainer", {
		extend: "BPMSoft.BusinessRuleActionDesignerContainer",
		alternateClassName: "BPMSoft.BusinessRulePopulateItemActionDesignerContainer",

		//region Properties: Private

		businessRuleActionWebComponent: null,

		populateTitleItems: null,

		//endregion

		//region Methods: Protected

		getActionContentWrapTpl: function() {
			return "{%this.renderViewItemsProperty(out, values, 'businessRuleActionWebComponent')%}";
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
			if (blockName === "businessRuleActionWebComponent") {
				return "";
			} else if (blockName === "populateTitleItems") {
				tpl = Ext.String.format("<div id=\"{id}-{0}-header\" class=\"{{0}BlockHeaderClass}\">" +
					"{%this.renderViewItemsProperty(out, values, 'populateTitleItems')%}" +
					"</div>", blockName);
			} else {
				tpl = this.callParent(arguments);
			}
			return tpl;
		},

		/**
		 * @inheritdoc BPMSoft.BusinessRuleActionDesignerContainer#getBlockNameList
		 * @overridden
		 */
		getBlockNameList: function() {
			const blockNameList = this.callParent(arguments);
			blockNameList.push("populateTitleItems");
			blockNameList.push("businessRuleActionWebComponent");
			return blockNameList;
		},

		/**
		 * @inheritdoc BPMSoft.Component#getTplData
		 * @overridden
		 */
		getTplData: function() {
			const tplData = this.callParent(arguments);
			const actionTplData = {};
			const wrapClasses = ["business-rule-case-populate-action"];
			if (tplData.wrapClass) {
				wrapClasses.push(tplData.wrapClass);
			}
			actionTplData.wrapClass = wrapClasses;
			Ext.apply(tplData, actionTplData, {});
			return tplData;
		}

		//endregion

	});
	return BPMSoft.BusinessRulePopulateItemActionDesignerContainer;
});
