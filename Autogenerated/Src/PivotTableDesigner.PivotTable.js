define("PivotTableDesigner", ["PivotTableDesignerResources", "FormulaDesignerResourcesResources", "PivotTable"], 
		function(resources, formulaDesignerResources) {
	/**
	 * Component for rendering pivot-table web components
	 */
	Ext.define("BPMSoft.controls.PivotTableDesigner", {
		extend: "BPMSoft.controls.PivotTable",
		alternateClassName: "BPMSoft.PivotTableDesigner",

		/**
		 * @inheritDoc
		 * @override
		 */
		controlResources: resources,

		/**
		 * @inheritDoc
		 * @override
		 */
		tpl: [
			/*jshint white:false */
			/*jshint quotmark:true */
			//jscs:disable
			'<div id=\"{id}-wrap\" style=\"{styles}\" class=\"ts-pivot-table-designer-wrapper\">',
			'<ts-pivot-table-designer id=\"{id}\" data-qa=\"pivot-table-designer\">',
			'</ts-pivot-table-designer>',
			'</div>',
			//jscs:enable
			/*jshint quotmark:false */
			/*jshint white:true */
		],

		/**
		 * @inheritDoc
		 * @override
		 */
		init: function() {
			Ext.apply(this.controlResources.localizableStrings, formulaDesignerResources.localizableStrings);
			this.callParent(arguments);
			this.addEvents(
				"optionsChanged"
			);
		},

		/**
		 * @inheritDoc
		 * @override
		 */
		initDomEvents: function() {
			this.callParent(arguments);
			const el = this.pivotTableDesignerEl;
			if (el) {
				el.on("optionsChanged", this.handleOptionsChanged, this);
			}
		},

		/**
		 * @inheritDoc
		 * @override
		 */
		clearDomListeners: function() {
			this.callParent(arguments);
			const el = this.pivotTableDesignerEl;
			if (el) {
				el.un("optionsChanged", this.handleOptionsChanged, this);
			}
		},

		/**
		 * Pivot designer options changed event handler
		 * @protected
		 * @param {Event} event Browser event object.
		 */
		handleOptionsChanged: function(event) {
			const options = event.browserEvent.detail;
			this.fireEvent("optionsChanged", options);
		},

		/**
		 * @inheritDoc
		 * @override
		 */
		getSelectors: function() {
			return {
				wrapEl: "#" + this.id + "-wrap",
				pivotTableDesignerEl: "#" + this.id
			};
		},

		/**
		 * @inheritDoc
		 * @override
		 */
		setElementOptions: function() {
			this.pivotTableDesignerEl.dom.options = this.options;
		}

	});

	return BPMSoft.PivotTable;

});
