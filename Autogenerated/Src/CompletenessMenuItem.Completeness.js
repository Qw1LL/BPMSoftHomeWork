define("CompletenessMenuItem", ["CompletenessMenuItemResources", "css!CompletenessMenuItem"],
	function() {

		/**
		 * @class BPMSoft.controls.CompletenessMenuItem
		 * ##### ######## #### # ####### ##########
		 */
		var completenessMenuItemClass = Ext.define("BPMSoft.controls.CompletenessMenuItem", {
			extend: "BPMSoft.BaseMenuItem",
			alternateClassName: "BPMSoft.CompletenessMenuItem",

			//region Fields: Private

			/**
			 * ###### ######## ######## ##########
			 * @type {Array}
			 */
			tpl: [
				/* jshint ignore:start */
				/* jscs:disable */
				'<li id="{id}" class="{itemClass}" style="{itemStyle}">',
				'<div class="{percentageClass}">+{percentage}%</div> {caption}',
				'</li>'
				/* jscs:enable */
				/* jshint ignore:end */
			],

			/**
			 * ####### ##########.
			 * @type {Number}
			 */
			percentage: 0,

			/**
			 * CSS ##### ### ##### # ######### ##########.
			 * @type {String}
			 */
			percentageClass: "completeness-menu-item-percentage",

			//endregion

			//region Methods: Protected

			/**
			 * @overridden
			 * @inheritdoc BPMSoft.BaseMenuItem#getTplData
			 */
			getTplData: function() {
				var tplData = this.callParent(arguments);
				tplData.caption = this.caption;
				tplData.percentage = this.percentage;
				tplData.percentageClass = this.percentageClass;
				return tplData;
			}

			//endregion
		});

		return completenessMenuItemClass;
	}
);

