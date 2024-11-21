define("SetupCallwayParametersPage", ["BPMSoft", "SetupCallCenterUtilities"],
	function(BPMSoft, SetupCallCenterUtilities) {
		return {
			attributes: {

				/**
				 * ########## ##### #########.
				 * @type {String}
				 */
				"OperatorId": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"isRequired": true,
					"value": ""
				},

				/**
				 * #######, ############ ############ ## ########## ###### CallWay.
				 * @type {Boolean}
				 */
				"IsCallwayClient": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": false
				},

				/**
				 * ####### ########## ######.
				 * @type {String}
				 */
				"RoutingRule": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": ""
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
						"OperatorId": "operatorId",
						"IsCallwayClient": "isCallwayClient",
						"RoutingRule": "routingRule"
					});
				}
			},
			diff: [
				{
					"operation": "insert",
					"parentName": "controlsContainer",
					"propertyName": "items",
					"name": "OperatorId",
					"values": {
						"isRequired": true,
						"generator": "SetupCallCenterUtilities.generateTextEdit"
					}
				},
				{
					"operation": "insert",
					"index": 0,
					"parentName": "controlsContainerBottom",
					"propertyName": "items",
					"name": "IsCallwayClient",
					"values": {
						"generator": "SetupCallCenterUtilities.generateBottomCheckBoxControl"
					}
				},
				{
					"operation": "insert",
					"parentName": "controlsContainer",
					"propertyName": "items",
					"name": "RoutingRule",
					"values": {
						"generator": "SetupCallCenterUtilities.generateTextEdit"
					}
				}
			]
		};
	});
