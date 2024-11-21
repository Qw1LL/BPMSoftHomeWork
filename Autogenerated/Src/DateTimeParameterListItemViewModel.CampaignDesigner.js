 /**
  * View model for date time parameter item in container list.
  */
define("DateTimeParameterListItemViewModel", ["DateTimeParameterListItemViewModelResources",
		"BaseParameterListItemViewModel"],
	function(resources) {
		/**
		 * @class BPMSoft.configuration.DateTimeParameterListItemViewModel
		 */
		Ext.define("BPMSoft.configuration.DateTimeParameterListItemViewModel", {
		extend: "BPMSoft.BaseParameterListItemViewModel",
		alternateClassName: "BPMSoft.DateTimeParameterListItemViewModel",
		columns: {
			/**
			 * Selected date and time.
			 * @protected
			 */
			"DateTimeValue": {
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: BPMSoft.DataValueType.DATE_TIME
			}
		},
		attributes: {
			/**
			 * @type {Boolean}
			 */
			"HasTime": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: false
			},
			/**
			 * @type {Boolean}
			 */
			"HasDate": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: false
			}
		},

		/**
		 * Returns date control marker value.
		 * @protected
		 * @returns {String} Marker value.
		 */
		getDateControlMarkerValue: function() {
			return this.markerValuePrefix + "-date-" + this.$Name;
		},

		/**
		 * Returns time control marker value.
		 * @protected
		 * @returns {String} Marker value.
		 */
		getTimeControlMarkerValue: function() {
			return this.markerValuePrefix + "-time-" + this.$Name;
		},

		/**
		 * @inheritdoc BaseParameterListItemViewModel#initParameter
		 * @override
		 */
		initParameter: function(values, config) {
			this.callParent(arguments);
			values.HasDate = config.dataValueType === BPMSoft.DataValueType.DATE
				|| config.dataValueType === BPMSoft.DataValueType.DATE_TIME;
			values.HasTime = config.dataValueType === BPMSoft.DataValueType.TIME
				|| config.dataValueType === BPMSoft.DataValueType.DATE_TIME;
		},

		/**
		 * @inheritdoc BaseParameterListItemViewModel#initParameterValue
		 * @override
		 */
		initParameterValue: function(value) {
			if (this.$HasMacrosValue) {
				this.callParent(arguments);
			} else {
				this.$DateTimeValue = this.getTypedValue(value);
			}
		},

		/**
		 * Returns typed value of parameter.
		 * @protected
		 * @param {String} value Stringified value of parameter.
		 * @returns {Date} Parameter value.
		 */
		getTypedValue: function(value) {
			return value && new Date(value);
		},

		/**
		 * @inheritdoc BaseParameterListItemViewModel#getParameterValue
		 * @override
		 */
		getParameterValue: function() {
			return this.$HasMacrosValue
				? this.callParent()
				: this.$DateTimeValue && this.convertDateToString(this.$DateTimeValue);
		},

		/**
		 * @inheritdoc BPMSoft.BaseParameterListItemViewModel#getValueMenuItems
		 * @override
		 */
		getValueMenuItems: function() {
			var items = this.callParent();
			items.add("DateTimeMacros", new BPMSoft.BaseViewModel({
				values: {
					Id: "DateTimeMacros",
					Caption: resources.localizableStrings.DateTimeMacro,
					ImageConfig: this.getImage(resources.localizableImages.CalendarIcon),
					MarkerValue: "DateTimeMacros",
					Click: "$loadDateTimeMacrosPage"
				}
			}));
			return items;
		},

		/**
		 * @inheritdoc BPMSoft.BaseParameterListItemViewModel#getParameterInputConfig
		 * @override
		 */
		getParameterInputConfig: function() {
			return [
				{
					className: "BPMSoft.MultilineLabel",
					contentVisible: true,
					showReadMoreButton: false,
					caption: "$Caption"
				},
				{
					className: "BPMSoft.DateEdit",
					value: "$DateTimeValue",
					visible: "$HasDate",
					classes: {
						wrapClass: ["datetime-datecontrol"]
					},
					markerValue: this.getDateControlMarkerValue()
				},
				{
					className: "BPMSoft.TimeEdit",
					value: "$DateTimeValue",
					visible: "$HasTime",
					classes: {
						wrapClass: ["datetime-timecontrol"]
					},
					markerValue: this.getTimeControlMarkerValue()
				}
			];
		}
	});
	return BPMSoft.DateTimeParameterListItemViewModel;
});
