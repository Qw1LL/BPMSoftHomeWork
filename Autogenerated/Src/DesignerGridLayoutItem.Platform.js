define("DesignerGridLayoutItem", ["ext-base", "BPMSoft", "sandbox", "DesignerGridLayoutItemResources",
	"css!DesignerGridLayoutItem"],
	function(Ext, BPMSoft, sandbox, resources) {

		/**
		 * @class BPMSoft.controls.DesignerGridLayoutItem
		 * ##### ######## ######### #####.
		 */
		var designerGridLayoutItem = Ext.define("BPMSoft.controls.DesignerGridLayoutItem", {
			extend: "BPMSoft.Label",
			alternateClassName: "BPMSoft.DesignerGridLayoutItem",

			/**
			 * ####### css-##### ### ######## ##########.
			 * @protected
			 * @virtual
			 * @type {String}
			 */
			designerGridLayoutItemClasses: "",

			/**
			 * @inheritDoc BPMSoft.Label#labelClass
			 * @overridden
			 */
			labelClass: "designerGridLayoutItem-text",

			/**
			 * @inheritDoc BPMSoft.Label#tpl
			 * @overridden
			 */
			tpl: [
				"<div id='{id}-wrap' class='{designerGridLayoutItemClasses}'>",
				"<label id = {id} class = '{labelClass}'>{caption}",
				"</label>",
				"</div>"
			],

			/**
			 * @inheritDoc BPMSoft.Label#getTplData
			 * @overridden
			 */
			getTplData: function() {
				var tplData = this.callParent(arguments);
				var itemTplData = {
					designerGridLayoutItemClasses: this.designerGridLayoutItemClasses
				};
				Ext.apply(itemTplData, tplData, {});
				return itemTplData;
			},

			/**
			 * @inheritDoc BPMSoft.Label#init
			 * @overridden
			 */
			init: function() {
				this.callParent(arguments);
				this.addEvents(
						/**
						 * @event
						 * ####### ######## ####### ## ######.
						 * @param {BPMSoft.DesignerGridLayoutItem} this
						 */
						"dblclick"
				);
			},

			/**
			 * @inheritDoc BPMSoft.Label#initDomEvents
			 * @overridden
			 */
			initDomEvents: function() {
				this.callParent(arguments);
				var el = this.getWrapEl();
				el.on("dblclick", this.onDblClick, this);
			},

			/**
			 * ########## ####### ######## ##### ## ######## ##########.
			 * @private
			 */
			onDblClick: function() {
				if (this.enabled) {
					this.fireEvent("dblclick", this);
				}
			},

			/**
			 * ######## ########### ##### onDestroy ## ########### #######.
			 */
			destroy: function() {
				if (this.rendered) {
					var el = this.getWrapEl();
					el.un("dblclick", this.onDblClick, this);
				}
				this.callParent(arguments);
			},

			/**
			 * @inheritDoc BPMSoft.Label#getSelectors
			 * @overridden
			 */
			getSelectors: function() {
				return {
					wrapEl: "#" + this.id + "-wrap",
					el: "#" + this.id
				};
			}
		});

		return designerGridLayoutItem;
	});
