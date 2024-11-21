define("DatePickerFilterModule", ["DatePickerFilterComponent"], function() {
	Ext.define("BPMSoft.configuration.DatePickerFilterModule", {
		extend: "BPMSoft.configuration.BaseModule",
		alternateClassName: "BPMSoft.DatePickerFilterModule",

		Ext: null,
		sandbox: null,
		BPMSoft: null,

		view: null,
		type: 0,
		messages: {

			/**
			 * @message SnapshotDateChanged
			 * On date changed on datepicker.
			 */
			"SnapshotDateChanged": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message ValidateDate
			 * Validate date from datepicker.
			 */
			"ValidateDate": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			}
		},

		/**
		 * Checks if date from datepicker is valid for displaying.
		 * @public
		 * @param {Date}  date Datepicker date.
		 * @returns {Boolean} Is date valid.
		 */
		validateDate: function(date) {
			return this.sandbox.publish("ValidateDate", date, [this.sandbox.id]);
		},

		/**
		 * @inheritdoc BPMSoft.BaseGridDetailV2#init
		 * @overridden
		 */
		init: function() {
			this.callParent(arguments);
			this.sandbox.registerMessages(this.messages);
		},

		/**
		 * Renders datetime picker to application.
		 * @param {Object} renderTo Element to rendering.
		 * @private
		 */
		_renderDatePickerFilter: function(renderTo) {
			this.view = Ext.create("BPMSoft.DatePickerFilterComponent", {
				type: this.type,
				filterFunction: this.validateDate.bind(this),
				dateChanged: { "bindTo": "onDateChanged" },
			});
			this.view.bind(this);
			this.view.render(renderTo);
		},

		onDateChanged: function(date) {
			this.sandbox.publish("SnapshotDateChanged", date, [this.sandbox.id]);
		},

		/**
		 * @inheritDoc BPMSoft.BaseModule#render
		 * @override
		 */
		render: function(renderTo) {
			this.callParent(arguments);
			if (!renderTo.dom) {
				renderTo = Ext.get(renderTo.id);
			}
			this._renderDatePickerFilter(renderTo);
		},

		/**
		 * @inheritDoc BPMSoft.BaseModule#destroy
		 * @override
		 */
		destroy: function() {
			if (this.view) {
				this.view.destroy();
			}
			this.callParent(arguments);
		}

	});

	return BPMSoft.DatePickerFilterModule;

});
