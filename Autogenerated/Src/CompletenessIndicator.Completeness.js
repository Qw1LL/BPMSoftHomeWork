define("CompletenessIndicator", ["RoundProgressBar", "CompletenessMenu", "CompletenessMenuItem",
		"css!CompletenessIndicator"],
	function() {

		/**
		 * @class BPMSoft.controls.CompletenessIndicator
		 * Round completeness indicator component class.
		 * @deprecated Use {@link #BPMSoft.RoundProgressBar}.
		 */
		var completenessIndicatorClass = Ext.define("BPMSoft.controls.CompletenessIndicator", {
			alternateClassName: "BPMSoft.CompletenessIndicator",
			extend: "BPMSoft.RoundProgressBar",

			mixins: {
				menuMixin: "BPMSoft.MenuMixin"
			},

			//region Fields: Protected

			/**
			 * @inheritdoc BPMSoft.Component#tpl
			 * @overridden
			 */
			tpl: [
				/* jshint ignore:start */
				/* jscs:disable */
				'<div id="{id}-wrap" class="{wrapClass} ts-round-progress-bar-wrap completeness-indicator-wrap" style="{wrapStyle}" progress-data="{value}">',
					'<div id="{id}-circle" class="circle" style="{circleElStyle}">',
						'<div id="{id}-firstHalf" class="half" style="{firstHalfElStyle}"></div>',
						'<div id="{id}-secondHalf" class="half" style="{secondHalfElStyle}"></div>',
					'</div>',
					'<div id="{id}-overlay" class="overlay" style="{overlayElStyle}" data-item-marker="{id}">{value}%</div>',
					'<tpl if="menu">',
						'<span id="{id}-menuWrapEl" class="{menuWrapClass}"></span>',
					'</tpl>',
				'</div>'
				/* jscs:enable */
				/* jshint ignore:end */
			],

			/**
			 * ###### ######## ############ ###### ##########.
			 * @overridden
			 */
			sectorsColors: ["#FF9584", "#FDCC65", "#B7E975"],

			/**
			 * ###### ######## ###### ###### ##########.
			 * @overridden
			 */
			sectorsBounds: [0, 25, 75, 100],

			/**
			 * @inheritdoc BPMSoft.MenuMixin#menuClass
			 * @overridden
			 */
			menuClass: "BPMSoft.CompletenessMenu",

			//endregion

			//region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.Component#init
			 * @overridden
			 */
			init: function() {
				this.callParent(arguments);
				this.mixins.menuMixin.init.call(this);
			},

			/**
			 * ############## ####### DOM.
			 * @protected
			 * @overridden
			 */
			initDomEvents: function() {
				this.callParent(arguments);
				var wrapEl = this.getWrapEl();
				if (wrapEl) {
					wrapEl.on({
						click: {
							fn: this.onClick,
							scope: this
						}
					});
				}
			},

			/**
			 * ############ ##### ######.
			 * @param {Ext.EventObjectImpl} e ###### #######.
			 * @protected
			 */
			onClick: function(e) {
				e.stopEvent();
				if (!this.enabled) {
					return;
				}
				var showMenu = this.menu && this.menu.items && this.menu.items.getCount() > 0;
				if (this.handler || this.hasListener("click")) {
					if (this.handler) {
						var obsoleteMessage = BPMSoft.Resources.ObsoleteMessages.ObsoleteMethodMessage;
						this.log(Ext.String.format(obsoleteMessage, "handler", "click event"));
						this.handler();
					}
					showMenu = (this.fireEvent("click", this, null, null, null) === false) && showMenu;
				}
				if (showMenu) {
					this.showMenu();
				}
			},

			/**
			 * ######### ######## #### # ######### ######.
			 * @overridden
			 */
			bind: function() {
				this.callParent(arguments);
				this.mixins.menuMixin.bindMenu.call(this, this.model);
			},

			/**
			 * @inheritdoc BPMSoft.Component#clearDomListeners
			 * @overridden
			 */
			clearDomListeners: function() {
				this.callParent(arguments);
				this.unsubscribeWindowScroll();
			}

			//endregion
		});

		return completenessIndicatorClass;
	}
);
