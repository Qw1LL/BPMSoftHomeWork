define("BusinessRuleFilterActionDesignerContainer", ["BusinessRuleActionDesignerContainer",
	"css!BusinessRuleFilterActionDesignerContainer"], function() {

		/**
		 * @class BPMSoft.controls.BusinessRuleFilterActionDesignerContainer
		 */
		Ext.define("BPMSoft.controls.BusinessRuleFilterActionDesignerContainer", {
			extend: "BPMSoft.BusinessRuleActionDesignerContainer",
			alternateClassName: "BPMSoft.BusinessRuleFilterActionDesignerContainer",

			//region Properties: Private

			/**
			 * Condition items.
			 * @type {Array/Ext.util.MixedCollection}
			 */
			conditionItems: null,

			/**
			 * Condition title items.
			 * @type {Array/Ext.util.MixedCollection}
			 */
			conditionTitleItems: null,

			//endregion

			//region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BusinessRuleActionDesignerContainer#getBlockNameList
			 * @overridden
			 */
			getBlockNameList: function() {
				var blockNameList = this.callParent(arguments);
				blockNameList.push("conditionItems");
				return blockNameList;
			},

			/**
			 * @inheritdoc BPMSoft.AbstractContainer#getViewItemsPropertyNames
			 * @overridden
			 */
			getViewItemsPropertyNames: function() {
				var viewItemsPropertyNames = this.callParent(arguments);
				viewItemsPropertyNames.push("conditionTitleItems");
				return viewItemsPropertyNames;
			},

			/**
			 * @inheritdoc BPMSoft.BusinessRuleActionDesignerContainer#getBlockHeaderTpl
			 * @overridden
			 */
			getBlockHeaderTpl: function(blockName) {
				var tpl;
				if (blockName === "conditionItems") {
					tpl = Ext.String.format("<div id=\"{id}-{0}-header\" class=\"{{0}BlockHeaderClass}\">" +
					"{%this.renderViewItemsProperty(out, values, 'conditionTitleItems')%}" +
					"</div>", blockName);
				} else {
					tpl = this.callParent(arguments);
				}
				return tpl;
			},

			/**
			 * @inheritdoc BPMSoft.Component#getTplData
			 * @overridden
			 */
			getTplData: function() {
				var testData = this.callParent(arguments);
				testData.wrapClass.push("business-rule-case-filter-action");
				return testData;
			}

			//endregion

		});
		return BPMSoft.BusinessRuleFilterActionDesignerContainer;
	});
