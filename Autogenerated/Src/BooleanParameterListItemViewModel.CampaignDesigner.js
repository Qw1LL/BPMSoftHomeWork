 /**
  * View model for boolean parameter item in container list.
  */
define("BooleanParameterListItemViewModel", ["BaseParameterListItemViewModel"],
	function() {
		/**
		* @class BPMSoft.configuration.BooleanParameterListItemViewModel
		*/
		Ext.define("BPMSoft.configuration.BooleanParameterListItemViewModel", {
		extend: "BPMSoft.BaseParameterListItemViewModel",
		alternateClassName: "BPMSoft.BooleanParameterListItemViewModel",

		/**
		 * @inheritdoc BPMSoft.BaseParameterListItemViewModel#getParameterInputConfig
		 * @override
		 */
		getParameterInputConfig: function() {
			return [
				{
					className: "BPMSoft.Container",
					classes: {
						wrapClassName: ["parameter-control-wrap"]
					},
					items: [
						{
							className: "BPMSoft.CheckBoxEdit",
							classes: {wrapClass: ["t-checkbox-control"]},
							markerValue: this.getControlMarkerValue(),
							checked: "$Value"
						}
					]
				},
				{
					className: "BPMSoft.Container",
					classes: {
						wrapClassName: ["parameter-label-wrap"]
					},
					items: [
						{
							className: "BPMSoft.Label",
							caption: "$Caption"
						}
					]
				}
			];
		}
	});
	return BPMSoft.BooleanParameterListItemViewModel;
});
