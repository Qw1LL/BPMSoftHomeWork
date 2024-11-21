define("CompletenessMenu", ["CompletenessMenuResources"],
	function() {

		/**
		 * @class BPMSoft.controls.CompletenessMenu
		 * ##### #### ### ####### ##########.
		 */
		var completenessMenuClass = Ext.define("BPMSoft.controls.CompletenessMenu", {
			extend: "BPMSoft.Menu",
			alternateClassName: "BPMSoft.CompletenessMenu",

			//region Fields: Private

			/**
			 * ######## ## ######### ### ##### ######## 'percentage' # ######## ViewModel.
			 * @protected
			 * @property {String} defaultPercentageName
			 */
			defaultPercentageName: "Percentage",

			/**
			 * ######## ## ######### ### ##### ######## 'percentageClass' # ######## ViewModel.
			 * @protected
			 * @property {String} defaultPercentageClassName
			 */
			defaultPercentageClassName: "PercentageClass",

			//endregion

			//region Methods: Protected

			/**
			 * @overridden
			 * @inheritdoc BPMSoft.BaseMenu#getMenuItemConfig
			 */
			getMenuItemConfig: function(itemModel) {
				var menuItemConfig = this.callParent(arguments);
				var percentageClass = itemModel.get(this.defaultPercentageClassName);
				if (percentageClass) {
					menuItemConfig.percentageClass = percentageClass;
				}
				menuItemConfig.percentage = itemModel.get(this.defaultPercentageName);
				return menuItemConfig;
			}

			//endregion
		});
		return completenessMenuClass;
	}
);
