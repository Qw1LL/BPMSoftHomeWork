define("SetupAvayaParametersPage", ["BPMSoft", "SetupCallCenterUtilities"],
	function(BPMSoft, SetupCallCenterUtilities) {
		return {
			attributes: {

				/**
				 * Agent Id.
				 * @type {String}
				 */
				"AgentId": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": ""
				},

				/**
				 * Agent password.
				 * @type {String}
				 */
				"AgentPassword": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": ""
				},

				/**
				 * Extension.
				 * @type {String}
				 */
				"Extension": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"isRequired": true,
					"value": ""
				}
			},
			methods: {

				/**
				 * @inheritdoc BPMSoft.BaseSetupTelephonyParametersPage#init.
				 * @overridden
				 */
				init: function(callback, scope) {
					this.set("PasswordColumnName", "AgentPassword");
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
						"AgentId": "AgentId",
						"AgentPassword": "AgentPassword",
						"Extension": "Extension"
					});
				}
			},
			diff: [
				{
					"operation": "insert",
					"parentName": "controlsContainer",
					"propertyName": "items",
					"name": "AgentId",
					"values": {
						"generator": "SetupCallCenterUtilities.generateTextEdit"
					}
				},
				{
					"operation": "insert",
					"parentName": "controlsContainer",
					"propertyName": "items",
					"name": "AgentManagementCaution",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "Resources.Strings.AgentManagementCautionMessage"},
						"visible": {
							bindTo: 'AgentId',
							bindConfig: {
								converter: function(value) {
									return Ext.isEmpty(value);
								}
							}
						},
						"classes": {"labelClass": ["control-caution-label"]}
					}
				},
				{
					"operation": "insert",
					"parentName": "controlsContainer",
					"propertyName": "items",
					"name": "AgentPassword",
					"values": {
						"protect": true,
						"generator": "SetupCallCenterUtilities.generateTextEdit"
					}
				},
				{
					"operation": "insert",
					"parentName": "controlsContainer",
					"propertyName": "items",
					"name": "Extension",
					"values": {
						"isRequired": true,
						"generator": "SetupCallCenterUtilities.generateTextEdit"
					}
				}
			]
		};
	});
