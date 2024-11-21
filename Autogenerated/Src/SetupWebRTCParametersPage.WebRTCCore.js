    define("SetupWebRTCParametersPage", ["BPMSoft", "SetupCallCenterUtilities"],
	function(BPMSoft, SetupCallCenterUtilities) {
		return {
			attributes: {
				/**
				 * Адрес сервера.
				 * @type {String}
				 */
				"ServerAddress": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"isRequired": true,
					"value": ""
				},
				/**
				 * SIP-линия: логин пользователя.
				 * @type {String}
				 */
				"Login": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"isRequired": true,
					"value": ""
				},
				/**
				 * SIP-линия: пароль пользователя.
				 * @type {String}
				 */
				"Password": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"isRequired": true,
					"value": ""
				},
			},
			methods: {

				/**
				 * @inheritdoc BPMSoft.BaseSetupTelephonyParametersPage#init.
				 * @overridden
				 */
				init: function(callback, scope) {
					this.set("PasswordColumnName", "Password");
					this.set("isPasswordEncrypted", true);
					this.callParent(arguments);
				},

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
						"Number": "number"
					});
				},
				
				/**
				 * Убрано шифрование пароля
				 * @protected
				 * @overridden
				 */
				saveButtonClick: function() {
					this.saveSysMsgUserSettings();
				},

			},
			diff: [
				{
					"operation": "insert",
					"parentName": "controlsContainer",
					"propertyName": "items",
					"name": "ServerAddress",
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
						"isRequired": true,
						"generator": "SetupCallCenterUtilities.generateTextEdit",
						"protect": true
					},	
				},
				{
					"operation": "insert",
					"parentName": "controlsContainer",
					"propertyName": "items",
					"name": "Number",
					"values": {
						"isRequired": false,
						"generator": "SetupCallCenterUtilities.generateTextEdit"
					}
				},
			]
		};
	});
