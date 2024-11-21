define("SetupAsteriskParametersPage", ["BPMSoft", "SetupCallCenterUtilities"],
	function(BPMSoft) {
		return {
			attributes: {

				/**
				 * #####.
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
				 * ########## ###### ############ ########## #########.
				 * ##### - ######## ######### #####, ######## - ######### ###########.
				 * @protected
				 * @overridden
				 * @returns {Object} ###### ############ ########## #########.
				 */
				getConnectionParamsConfig: function() {
					var baseConnectionParams = this.callParent();
					return Ext.merge(baseConnectionParams, {
						"Extension": "ExtensionName"
					});
				}

			},
			diff: [
				{
					"operation": "insert",
					"parentName": "controlsContainerTop",
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
