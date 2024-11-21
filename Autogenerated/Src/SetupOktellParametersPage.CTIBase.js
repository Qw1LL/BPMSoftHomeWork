define("SetupOktellParametersPage", ["BPMSoft", "SetupCallCenterUtilities"],
	function(BPMSoft, SetupCallCenterUtilities) {
		return {
			attributes: {

				/**
				 * ##### ####### Oktell.
				 * @type {String}
				 */
				"OktellServerAddress": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"isRequired": true,
					"value": ""
				},

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
				 * #######, ############ ######### ## ############# #######.
				 * @type {Boolean}
				 */
				"IsSipAutoAnswerHeaderSupported": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": false
				}
			},
			methods: {

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
						"OktellServerAddress": "url",
						"Login": "login",
						"Password": "password",
						"IsSipAutoAnswerHeaderSupported": "isSipAutoAnswerHeaderSupported"
					});
				}
			},
			diff: [
				{
					"operation": "insert",
					"index": 1,
					"parentName": "controlsContainerBottom",
					"propertyName": "items",
					"name": "IsSipAutoAnswerHeaderSupported",
					"values": {
						"hint": "Resources.Strings.IsSipAutoAnswerHeaderSupportedHint",
						"generator": "SetupCallCenterUtilities.generateBottomCheckBoxControl"
					}
				},
				{
					"operation": "insert",
					"parentName": "controlsContainer",
					"propertyName": "items",
					"name": "OktellServerAddress",
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
				}
			]
		};
	});
