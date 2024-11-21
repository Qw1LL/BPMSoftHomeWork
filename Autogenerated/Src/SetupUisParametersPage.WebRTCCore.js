     define("SetupUisParametersPage", ["BPMSoft", "SetupCallCenterUtilities"],
	function(BPMSoft, SetupCallCenterUtilities) {
		return {
			attributes: {
				/**
				 * 
				 * @type {Boolean}
				 */
				"UseWebPhone": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": true
				},
				
				"ServerAddress": {
					"isRequired": false
				}
			},
			methods: {
				/**
				 * Добавление параметров страницы в конфиг подключения телефонии
				 * @protected
				 * @overridden
				 * @returns {Object}
				 */
				getConnectionParamsConfig: function() {
					var baseConnectionParams = this.callParent();
					return Ext.merge(baseConnectionParams, {
						"ServerAddress": "url",
						"Login": "login",
						"Password": "password",
						"Number": "number",
						"UseWebPhone": "useWebPhone"
					});
				},
			},
			diff: [
				{
					"operation": "remove",
					"name": "ServerAddress",
				},
				{
					"operation": "insert",
					"parentName": "controlsContainerBottom",
					"propertyName": "items",
					"name": "UseWebPhone",
					"values": {
						"generator": "SetupCallCenterUtilities.generateBottomCheckBoxControl",
						"enabled" : false
					}
				},
			]
		};
	});
