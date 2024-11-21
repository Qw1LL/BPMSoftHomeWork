define("MacrosMenuItemsMappingUtilities", ["MacrosMenuItemsMappingUtilitiesResources", "SysSchemaUIdEnums"],
		function(resources) {
	Ext.define("BPMSoft.configuration.MacrosMenuItemsMappingUtilities", {
		alternateClassName: "BPMSoft.MacrosMenuItemsMappingUtilities",

		/**
		 * Returns system variable macros menu item configuration object.
		 * @param {String} referenceSchemaUId Reference schema UId.
		 * @return {Object} System variable macros menu item configuration object.
		 */
		getSysVariableMacrosMenuItemConfig: function(referenceSchemaUId) {
			var value, displayValue, caption;
			var sysVariableDisplayValues = BPMSoft.Resources.SystemValueCaptions;
			var sysVariableItemsCaptions = resources.localizableStrings;
			var sysSchemaEnums = BPMSoft.SysSchemaUIdEnums.SysVariablesSchemaUIds;
			switch (referenceSchemaUId) {
				case sysSchemaEnums.CONTACT_SCHEMA_UID:
					caption = sysVariableItemsCaptions.CurrentUserContactCaption;
					value = BPMSoft.SystemValueType.CURRENT_USER_CONTACT;
					displayValue = sysVariableDisplayValues.CurrentUserContact;
					break;
				case sysSchemaEnums.ADMIN_UNIT_SCHEMA_UID:
					caption = sysVariableItemsCaptions.CurrentUserCaption;
					value = BPMSoft.SystemValueType.CURRENT_USER;
					displayValue = sysVariableDisplayValues.CurrentUser;
					break;
				case sysSchemaEnums.ACCOUNT_SCHEMA_UID:
					caption = sysVariableItemsCaptions.CurrentUserAccountCaption;
					value = BPMSoft.SystemValueType.CURRENT_USER_ACCOUNT;
					displayValue = sysVariableDisplayValues.CurrentUserAccount;
					break;
				default:
					return null;
			}
			return {
				caption: caption,
				value: value,
				displayValue: displayValue
			};
		},

		/**
		 * Adds macros brackets to mapping edit display value.
		 * @param {String} displayValue Mapping edit display value with macros brackets.
		 */
		addMacrosBrackets: function(displayValue) {
			var consts = BPMSoft.process.constants;
			return consts.LEFT_MACROS_BRACKET + displayValue + consts.RIGHT_MACROS_BRACKET;
		},

		/**
		 * Returns configuration object for Date Time macros menu items.
		 * @param {BPMSoft.ProcessSchemaParameter} elementParameter Process element parameter.
		 * @return {Object} Configuration object.
		 */
		getDateTimeMacrosMenuItemConfig: function(systemValueType) {
			var displayValue, caption;
			var sysVariableDisplayValues = BPMSoft.Resources.SystemValueCaptions;
			var strings = resources.localizableStrings;
			switch (systemValueType) {
				case BPMSoft.SystemValueType.CURRENT_DATE_TIME:
					caption = strings.CurrentTimeAndDateSubMenuItemCaption;
					displayValue = sysVariableDisplayValues.CurrentDateTime;
					break;
				case BPMSoft.SystemValueType.CURRENT_DATE:
					caption = strings.CurrentDateSubMenuItemCaption;
					displayValue = sysVariableDisplayValues.CurrentDate;
					break;
				case BPMSoft.SystemValueType.CURRENT_TIME:
					caption = strings.CurrentTimeSubMenuItemCaption;
					displayValue = sysVariableDisplayValues.CurrentTime;
					break;
				default:
					break;
			}
			var valueMacros = BPMSoft.FormulaMacros.prepareSysVariableValue(systemValueType);
			var displayValueMacros = BPMSoft.FormulaMacros.prepareSysVariableDisplayValue(displayValue);
			return {
				caption: caption,
				value: valueMacros.getBody(),
				displayValue: displayValueMacros.toString()
			};
		}
	});
	return BPMSoft.MacrosMenuItemsMappingUtilities;
});
