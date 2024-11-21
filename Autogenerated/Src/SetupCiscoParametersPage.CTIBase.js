define("SetupCiscoParametersPage", ["BPMSoft", "SetupCallCenterUtilities"],
	function(BPMSoft, SetupCallCenterUtilities) {
		return {
			attributes: {

				/**
				 * #####.
				 * @type {String}
				 */
				"Login": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"isRequired": true,
					"value": ""
				},

				/**
				 * ######.
				 * @type {String}
				 */
				"Password": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"isRequired": true,
					"value": ""
				},

				/**
				 * ##### ####### Cisco (#### #).
				 * @type {String}
				 */
				"ServerAddressA": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"isRequired": true,
					"value": ""
				},

				/**
				 * ####  (#### A).
				 * @type {String}
				 */
				"PortA": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"isRequired": true,
					"value": ""
				},

				/**
				 * ##### ####### Cisco (#### B).
				 * @type {String}
				 */
				"ServerAddressB": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"isRequired": true,
					"value": ""
				},

				/**
				 * ####  (#### B).
				 * @type {String}
				 */
				"PortB": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"isRequired": true,
					"value": ""
				},

				/**
				 * ##########.
				 * @type {String}
				 */
				"Instrument": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": ""
				},

				/**
				 * ### ########### #########.
				 * @type {String}
				 */
				"InstrumentType": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": ""
				}
			},
			methods: {

				/**
				 * @inheritdoc BPMSoft.BaseSetupTelephonyParametersPage#init.
				 * @overridden
				 */
				init: function(callback, scope) {
					this.set("PasswordColumnName", "Password");
					this.callParent(arguments);
				},

				/**
				 * ########## ###### ############ ########## #########.
				 * ##### - ######## ######### #####, ######## - ######### ###########.
				 * @protected
				 * @overridden
				 * @returns {Object} ###### ############ ########## #########.
				 */
				getConnectionParamsConfig: function() {
					var baseConnectionParams = this.callParent();
					return Ext.merge(baseConnectionParams, {
						"ServerAddressA": "CtiosA",
						"PortA": "PortA",
						"ServerAddressB": "CtiosB",
						"PortB": "PortB",
						"Login": "Login",
						"Password": "Password",
						"Instrument": "Instrument",
						"InstrumentType": "PeripheralID"
					});
				}

			},
			diff: [
				{
					"operation": "insert",
					"parentName": "controlsContainer",
					"propertyName": "items",
					"name": "ServerAddressA",
					"values": {
						"isRequired": true,
						"generator": "SetupCallCenterUtilities.generateTextEdit"
					}
				},
				{
					"operation": "insert",
					"parentName": "controlsContainer",
					"propertyName": "items",
					"name": "PortA",
					"values": {
						"isRequired": true,
						"generator": "SetupCallCenterUtilities.generateTextEdit"
					}
				},
				{
					"operation": "insert",
					"parentName": "controlsContainer",
					"propertyName": "items",
					"name": "Login",
					"values": {
						"isRequired": true,
						"generator": "SetupCallCenterUtilities.generateTextEdit"
					}
				},
				{
					"operation": "insert",
					"parentName": "controlsContainer",
					"propertyName": "items",
					"name": "Password",
					"values": {
						"protect": true,
						"isRequired": true,
						"generator": "SetupCallCenterUtilities.generateTextEdit"
					}
				},
				{
					"operation": "insert",
					"parentName": "controlsContainerRight",
					"propertyName": "items",
					"name": "ServerAddressB",
					"values": {
						"isRequired": true,
						"generator": "SetupCallCenterUtilities.generateTextEdit"
					}
				},
				{
					"operation": "insert",
					"parentName": "controlsContainerRight",
					"propertyName": "items",
					"name": "PortB",
					"values": {
						"isRequired": true,
						"generator": "SetupCallCenterUtilities.generateTextEdit"
					}
				},
				{
					"operation": "insert",
					"parentName": "controlsContainerRight",
					"propertyName": "items",
					"name": "Instrument",
					"values": {
						"generator": "SetupCallCenterUtilities.generateTextEdit"
					}
				},
				{
					"operation": "insert",
					"parentName": "controlsContainerRight",
					"propertyName": "items",
					"name": "InstrumentType",
					"values": {
						"generator": "SetupCallCenterUtilities.generateTextEdit"
					}
				}
			]
		};
	});
