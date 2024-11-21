define("BusinessRuleActionDesignerCollectionContainer", ["BusinessRuleActionDesignerContainer",
		"BusinessRuleFilterActionDesignerContainer"], function() {

		/**
		 * @class BPMSoft.controls.BusinessRuleActionDesignerCollectionContainer
		 */
		Ext.define("BPMSoft.controls.BusinessRuleActionDesignerCollectionContainer", {
			extend: "BPMSoft.ReorderableContainer",
			alternateClassName: "BPMSoft.BusinessRuleActionDesignerCollectionContainer",

			/**
			 * Title block items.
			 * @type {Array}
			 */
			titleItems: [],

			/**
			 * @inheritdoc BPMSoft.core.mixins.ReorderableContainer#itemClassName
			 * @overridden
			 */
			itemClassName: "BPMSoft.BusinessRuleActionDesignerContainer",

			/**
			 * @inheritdoc BPMSoft.core.mixins.Reorderable#getItemConfig
			 * @overridden
			 */
			getItemConfig: function(itemViewModel) {
				var config = this.callParent(arguments);
				Ext.apply(config, {
					"id": itemViewModel.get("Id")
				});
				itemViewModel.enrichViewConfig(config);
				return config;
			}
		});
		return BPMSoft.BusinessRuleActionDesignerCollectionContainer;
	});
