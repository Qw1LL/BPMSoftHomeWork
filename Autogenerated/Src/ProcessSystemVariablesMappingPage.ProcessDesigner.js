/**
 * Parent: ProcessFunctionsMappingPage
 */
define("ProcessSystemVariablesMappingPage", ["BPMSoft", "GridUtilitiesV2"],
	function(BPMSoft) {
		return {
			methods: {
				/**
				 * Determines whether the functionality of the process remindings is enabled.
				 * @private
				 * @return {Boolean} True, if functionality is enabled; otherwise - False.
				 */
				getCanUseProcessRemindings: function() {
					return BPMSoft.Features.getIsEnabled("UseProcessRemindings");
				},

				/**
				 * @inheritdoc BPMSoft.ProcessFunctionsMappingPage#getGridCollection
				 * @overridden
				 */
				getGridCollection: function(callback) {
					var isEnabled = this.getCanUseProcessRemindings();
					var constants = BPMSoft.process.constants;
					var propertyName = {
						value: constants.CAPTION_PROPERTY_VALUE_MACROS,
						displayValue: BPMSoft.Resources.ProcessSchemaDesigner.PropertyNames.Caption
					};
					var dataCollection = !isEnabled
						? constants.SYS_VARIABLES
						: Ext.Array.merge([], constants.SYS_VARIABLES, propertyName);
					callback.call(this, dataCollection);
				},

				/**
				 * @inheritdoc BPMSoft.ProcessFunctionsMappingPage#getSelectedData
				 * @overridden
				 */
				getSelectedData: function() {
					var selectedData = this.callParent(arguments);
					if (!selectedData) {
						return;
					}
					var result;
					var formulaMacros = BPMSoft.FormulaMacros;
					var isEnabled = this.getCanUseProcessRemindings();
					var constants = BPMSoft.process.constants;
					if (isEnabled && selectedData.value === constants.CAPTION_PROPERTY_VALUE_MACROS) {
						result = {
							valueMacros: formulaMacros.preparePropertyValue(selectedData.value),
							displayValueMacros: formulaMacros.preparePropertyDisplayValue(selectedData.displayValue)
						};
					} else {
						result = {
							valueMacros: formulaMacros.prepareSysVariableValue(selectedData.value),
							displayValueMacros: formulaMacros.prepareSysVariableDisplayValue(selectedData.displayValue)
						};
					}
					return {
						value: result.valueMacros.getBody(),
						displayValue: result.displayValueMacros.getBody()
					};
				}
			},
			diff: /**SCHEMA_DIFF*/[
			]/**SCHEMA_DIFF*/
		};
	});
