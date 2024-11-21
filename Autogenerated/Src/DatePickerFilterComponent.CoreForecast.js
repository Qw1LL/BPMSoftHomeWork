define("DatePickerFilterComponent", function() {

	Ext.define("BPMSoft.control.DatePickerFilterComponent", {
		extend: "BPMSoft.controls.Component",
		alternateClassName: "BPMSoft.DatePickerFilterComponent",

		type: 0,
		filterFunction: null,
		styles: {},
		parentComponent: Ext.emptyString,

		/**
		 * @inheritDoc BPMSoft.Component#tpl
		 * @override
		 */
		tpl: [
			/*jshint white:false */
			/*jshint quotmark:true */
			//jscs:disable
			'<div id=\"{id}-wrap\">',
			'<ts-date-picker-filter id=\"{id}\" type=\"{type}\">',
			'</ts-date-picker-filter>',
			'</div>',
			//jscs:enable
			/*jshint quotmark:false */
			/*jshint white:true */
		],

		/**
		 * @inheritDoc BPMSoft.Component#getSelectors
		 * @override
		 */
		getSelectors: function() {
			return {
				wrapEl: "#" + this.id + "-wrap",
				datePickerFilterEl: "#" + this.id
			};
		},

		/**
		 * @inheritDoc BPMSoft.Component#init
		 * @override
		 */
		init: function() {
			this.callParent(arguments);
			this.addEvents(
				"dateChanged"
			);
		},

		/**
		 * @inheritDoc BPMSoft.Component#initDomEvents
		 * @override
		 */
		initDomEvents: function() {
			this.callParent(arguments);
			const el = this.datePickerFilterEl;
			if (el) {
				el.on("dateChange", this.onDateChanged, this);
			}
		},

		/**
		 * @inheritDoc BPMSoft.Component#getTplData
		 * @override
		 */
		getTplData: function() {
			const tplData = this.callParent(arguments);
			this.selectors = this.getSelectors();
			const controlTplData = {
				type: this.type
			};
			Ext.apply(tplData, controlTplData);
			return tplData;
		},

		/**
		 * @inheritDoc BPMSoft.Component#render
		 * @override
		 */
		render: function() {
			this.callParent(arguments);
			if (this.datePickerFilterEl && this.datePickerFilterEl.dom) {
				this.datePickerFilterEl.dom.datePickerFilterFunction = this.filterFunction;
			}
		},

		/**
		 * Handles date picker component date changed event.
		 * @param {Date} event Picked date value.
		 */
		onDateChanged: function(event) {
			this.fireEvent("dateChanged", event.browserEvent.detail);
		}
	});

	return BPMSoft.DatePickerFilterComponent;
});
