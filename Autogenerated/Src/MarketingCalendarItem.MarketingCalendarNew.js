define("MarketingCalendarItem", [], function() {
	/**
	 *  Marketing calendar diagram item
	 *  @class BPMSoft.controls.MarketingCalendarItem
	 */
	Ext.define("BPMSoft.controls.MarketingCalendarItem", {
		alternateClassName: "BPMSoft.MarketingCalendarItem",
		extend: "BPMSoft.GridLayoutTableEditItem",

		/**
		 * MOVE + RESIZE_RIGHT + RESIZE_LEFT
		 * @inheritdoc BPMSoft.BPMSoft.Draggable#dragActionsCode
		 * @overridden
		 */
		dragActionsCode: 137,

		/**
		 * Item background color
		 * Example: #000000
		 * @type {String} RGB color
		 */
		color: null,

		/**
		 * Control template parameters object
		 * @protected
		 * @type {Object}
		 */
		marketingCalendarItemTplConfig: {
			classes: {
				wrapClasses: ["marketing-calendar-item-wrap"]
			}
		},

		/**
		 * @inheritdoc BPMSoft.Component#init
		 * @overridden
		 */
		init: function() {
			this.callParent(arguments);
			this.mergeTplConfigs(this.marketingCalendarItemTplConfig);
		},

		/**
		 * @inheritdoc BPMSoft.GridLayoutEditItem#setDraggableConstraints
		 * @overridden
		 * @param currentDraggable {Ext.Element}
		 */
		setDraggableConstraints: function(currentDraggable) {
			var marketingCalendar = this.getGridLayoutEditInstance();
			var rowElId = Ext.String.format("{0}-{1}-{2}", marketingCalendar.id,
					marketingCalendar.tplConfig.selectorSuffixes.row, this.row);
			var rowEl = Ext.get(rowElId);
			currentDraggable.constrainTo(rowEl);
		},

		/**
		 * @inheritdoc BPMSoft.GridLayoutEditItem#getBindConfig
		 * @overridden
		 */
		getBindConfig: function() {
			return Ext.apply(this.callParent(arguments), {
				color: {
					changeMethod: "setColor"
				}
			});
		},

		/**
		 * Sets item background color
		 * @param {Number} Color
		 */
		setColor: function(value) {
			if (value && this.color !== value) {
				this.color = value;
				//this.wrapEl.applyStyles("background: " + value + ";");
				//this.actualizeGridSize();
			}
		},

		/**
		 * Returns text wrap styles
		 * @return {String} Styles
		 */
		getTextWrapStyles: function() {
			var color = this.getColor();
			return Ext.isEmpty(color) ? "" : {background: color};
		},

		/**
		 * @inheritdoc BPMSoft.GridLayoutEditItem#getTop
		 * @overridden
		 */
		getTop: function() {
			var gridLayoutEdit = this.getGridLayoutEditInstance();
			var itemIndex = gridLayoutEdit.gridLayoutEditItemsCollection.indexOf(this);
			var topIndent = itemIndex * gridLayoutEdit.cellHeight;
			return Ext.String.format("calc({0}px + {1}px)", topIndent, this.cellBorderLineSize);
		},
		
		/**
		 * @inheritdoc BPMSoft.GridLayoutEditItem#onAfterRowChange
		 * @overridden
		 */
		onAfterRowChange: function(value) {
			this.setRow(value, true);
		},

		/**
		 * @inheritdoc BPMSoft.GridLayoutEditItem#onAfterColumnChange
		 * @overridden
		 */
		onAfterColumnChange: function(value) {
			this.setColumn(value, true);
		},

		/**
		 * @inheritdoc BPMSoft.GridLayoutEditItem#onAfterColSpanChange
		 * @overridden
		 */
		onAfterColSpanChange: function(value) {
			this.setColSpan(value, true);
		},

		getTplData: function() {
			this.tplConfig.styles.position = "absolute";
			return this.callParent(arguments);
		},

		/**
		 * Returns element color
		 * @return {String} Color
		 */
		getColor: function() {
			var color = this.color;
			return (!Ext.isEmpty(color)) ? color : "";
		},

		/**
		 * @inheritdoc BPMSoft.GridLayoutEditItem#getItemBox
		 * @overridden
		 * @return {Object}
		 */
		getItemBox: function() {
			var itemBox = this.callParent(arguments);
			if(itemBox) {
				itemBox.height = '68px';
			}
			if (!Ext.isEmpty(this.getColor())) {
				itemBox.background = this.getColor();
			}
			return itemBox;
		},

		/**
		 * @inheritdoc BPMSoft.GridLayoutEditItem#onItemDblClick.
		 * @overridden
		 * @param {Object} event Event object
		 */
		onItemDblClick: function(event) {
			event.stopEvent();
			var marketingCalendar = this.getGridLayoutEditInstance();
			marketingCalendar.setSelection();
			marketingCalendar.fireEvent("itemDblClick", this.itemId, this);
		}
	});
});
