Ext.define("BPMSoft.configuration.mixins.ParameterListMixin", {
	alternateClassName: "BPMSoft.ParameterListMixin",

	/**
	 * Returns instance of the list item view model.
	 * @public
	 * @param {Object} parameter Parameter object.
	 * @returns {BPMSoft.BaseParameterListItemViewModel} List item view model.
	 */
	createParameterListItemViewModel: function(parameter) {
		var listItemViewModel;
		parameter.parentViewModel = this;
		parameter.sandbox = this.sandbox;
		switch (parameter.dataValueType) {
			case BPMSoft.DataValueType.BOOLEAN:
				listItemViewModel = new BPMSoft.BooleanParameterListItemViewModel(null, parameter);
				break;
			case BPMSoft.DataValueType.LOOKUP:
				listItemViewModel = new BPMSoft.LookupParameterListItemViewModel(null, parameter);
				break;
			case BPMSoft.DataValueType.DATE_TIME:
			case BPMSoft.DataValueType.DATE:
			case BPMSoft.DataValueType.TIME:
				listItemViewModel = new BPMSoft.DateTimeParameterListItemViewModel(null, parameter);
				break;
			case BPMSoft.DataValueType.TEXT:
			case BPMSoft.DataValueType.SHORT_TEXT:
			case BPMSoft.DataValueType.MEDIUM_TEXT:
			case BPMSoft.DataValueType.MAXSIZE_TEXT:
			case BPMSoft.DataValueType.LONG_TEXT:
				listItemViewModel = new BPMSoft.StringParameterListItemViewModel(null, parameter);
				break;
			default:
				listItemViewModel = new BPMSoft.BaseParameterListItemViewModel(null, parameter);
		}
		return listItemViewModel;
	}

});
