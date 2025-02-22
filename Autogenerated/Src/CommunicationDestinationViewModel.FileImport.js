﻿define("CommunicationDestinationViewModel", ["ColumnTypedDestinationViewModel"], function() {
	Ext.define("BPMSoft.configuration.CommunicationDestinationViewModel", {
		alternateClassName: "BPMSoft.CommunicationDestinationViewModel",
		extend: "BPMSoft.ColumnTypedDestinationViewModel",

		//region Methods: Public

		/**
		 * @inheritdoc
		 * @overridden
		 */
		getPath: function() {
			this.callParent(arguments);
			var type = this.get("Type");
			return type.displayValue;
		},

		/**
		 * @inheritdoc
		 * @overridden
		 */
		validateDestinationIndex: function(destinationInfo) {
			var validationResult = this.callParent(arguments);
			if (!validationResult) {
				return validationResult;
			}
			var currentIndex = this.getIndex();
			if (currentIndex < destinationInfo.index) {
				return validationResult;
			}
			var currentType = this.get("Type");
			var destinationType = destinationInfo.type;
			return (currentType.value !== destinationType.value);
		}

		//endregion
	});
});
