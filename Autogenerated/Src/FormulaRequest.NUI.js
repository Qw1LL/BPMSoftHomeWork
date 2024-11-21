define("FormulaRequest", ["ConfigurationServiceRequest"], function() {
	return Ext.define("BPMSoft.configuration.FormulaRequest", {
		alternateClassName: "BPMSoft.FormulaRequest",
		extend: "BPMSoft.ConfigurationServiceRequest",

		/**
		 * @type {String}
		 */
		serviceName: "FormulaCalculationService",

		/**
		 * @type {String}
		 */
		contractName: "Calculate",

		/**
		 * @type {Boolean}
		 */
		useSspServiceUrl: true,

		/**
		 * @type {String}
		 */
		formula: null,

		/**
		 * @type {String}
		 */
		entitySchemaName: null,

		/**
		 * @type {String}
		 */
		recordId: null,

		/**
		 * @type {{name: String, value: Object}[]}
		 */
		changedColumns: null,

		/**
		 * @inheritDoc BPMSoft.ConfigurationServiceRequest.getSerializableObject
		 * @overridden
		 */
		getSerializableObject: function(serializableObject) {
			this.callParent(arguments);
			serializableObject.formula = JSON.stringify(this.formula);
			serializableObject.entitySchemaName = this.entitySchemaName;
			serializableObject.recordId = this.recordId;
			serializableObject.changedColumns = this.changedColumns.map(function(x) {
				return {Key: x.name, Value: x.value || null};
			});
		}
	});
});
