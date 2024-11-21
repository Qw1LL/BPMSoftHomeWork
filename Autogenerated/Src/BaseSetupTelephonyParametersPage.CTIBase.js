define("BaseSetupTelephonyParametersPage", ["BPMSoft", "ServiceHelper", "SetupCallCenterUtilities"],
	function(BPMSoft, ServiceHelper) {
		return {
			messages: {
				"BackHistoryState": {
					"mode": BPMSoft.MessageMode.BROADCAST,
					"direction": BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			attributes: {

				/**
				 * ###### ############ ########## #########.
				 * ##### - ######## ######### #####, ######## - ######### ###########.
				 * @protected
				 * @type {Object}
				 */
				"connectionParamsConfig": {
					"dataValueType": BPMSoft.DataValueType.CUSTOM_OBJECT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": null
				},

				/**
				 * ########## ############# ####### ########## ###### ###########.
				 * @type {String}
				 */
				"sysMsgLibId": {
					"dataValueType": BPMSoft.DataValueType.GUID,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": BPMSoft.SysValue.CTI.sysMsgLibId
				},

				/**
				 * ########## ############# ####### ######## ############.
				 * @type {String}
				 */
				"sysMsgUserSettingsId": {
					"dataValueType": BPMSoft.DataValueType.GUID,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": ""
				},

				/**
				 * #######, ############ ####### ## ##### #######.
				 * @type {Boolean}
				 */
				"DebugMode": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": false
				},

				/**
				 * Sign that call transfer type is blind (instead of consult).
				 * @type {Boolean}
				 */
				"UseBlindTransfer": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": false
				},

				/**
				 * #######, ############ ######### ## #########.
				 * @type {Boolean}
				 */
				"DisableCallCentre": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": false
				},

				/**
				 * #######, ############ ########## ## ######.
				 * @type {Boolean}
				 */
				"IsPasswordEncrypted": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": true
				},

				/**
				 * ######## ####### ###### ######## ########### #########.
				 * @type {Boolean}
				 */
				"PasswordColumnName": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": ""
				}
			},
			methods: {

				/**
				 * ############## ######### ######## ######.
				 * @protected
				 * @overridden
				 */
				init: function(callback, scope) {
					this.callParent([function() {
						this.set("connectionParamsConfig", this.getConnectionParamsConfig());
						this.loadConnectionParams(function() {
							this.subscribePasswordChanged();
							callback.call(scope || this);
						}.bind(this), this);
					}.bind(this), this]);
				},

				/**
				 * ############# ## ######### ###### ######## ########### #########.
				 * @private
				 */
				subscribePasswordChanged: function() {
					var passwordColumnName = this.get("PasswordColumnName");
					if (!Ext.isEmpty(passwordColumnName)) {
						this.on("change:" + passwordColumnName, function() {
							this.set("IsPasswordEncrypted", false);
							this.un("change:" + passwordColumnName, null, this);
						}, this);
					}
				},

				/**
				 * ####### ###### ########### ######### ############.
				 * @param {String} password ###### ########### ######### ############.
				 * @param {Function} callback ####### ######### ######.
				 * @private
				 */
				encryptPassword: function(password, callback) {
					var serviceOptions = {
						password: password
					};
					ServiceHelper.callService("CryptographicService", "GetConvertedPasswordValue", function(response) {
						callback.call(this, response.GetConvertedPasswordValueResult);
					}, serviceOptions);
				},

				/**
				 * ######### ######### ######### # ############### #### #####.
				 * @param {Function} callback ####### ######### ######.
				 * @param {Object} scope (optional) ######## ###### ####### ######### ######.
				 * @private
				 */
				loadConnectionParams: function(callback, scope) {
					var sysMsgLibId = this.get("sysMsgLibId");
					if (Ext.isEmpty(sysMsgLibId)) {
						callback(scope || this);
						return;
					}
					var esq = Ext.create("BPMSoft.EntitySchemaQuery", {rootSchemaName: "SysMsgUserSettings"});
					esq.addColumn("ConnectionParams");
					esq.filters.add("filterCurrentUserParams", BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "User", BPMSoft.SysValue.CURRENT_USER.value));
					esq.filters.add("filterCurrentCallCentre", BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "SysMsgLib", sysMsgLibId));
					esq.getEntityCollection(function(result) {
						if (!result.success) {
							callback(scope || this);
							return;
						}
						var entities = result.collection;
						if (entities.isEmpty()) {
							callback(scope || this);
							return;
						}
						var entity = entities.getByIndex(0);
						this.set("sysMsgUserSettingsId", entity.get("Id"));
						var entityConnectionParams = entity.get("ConnectionParams");
						if (!Ext.isEmpty(entityConnectionParams)) {
							var connectionParams;
							try {
								connectionParams = BPMSoft.decode(entityConnectionParams);
							} catch (e) {
								this.error(e);
							}
							if (!Ext.isEmpty(connectionParams)) {
								var connectionParamsConfig = this.get("connectionParamsConfig");
								BPMSoft.each(connectionParamsConfig, function(paramName, attributeName) {
									var paramValue = connectionParams[paramName];
									if (Ext.isEmpty(paramValue)) {
										return;
									}
									this.set(attributeName, paramValue);
								}.bind(this));
							}
						}
						callback(scope || this);
					}.bind(this));
				},

				/**
				 * ########## ###### ############ ########## #########.
				 * ##### - ######## ######### #####, ######## - ######### ###########.
				 * @protected
				 * @returns {Object} ###### ############ ########## #########.
				 */
				getConnectionParamsConfig: function() {
					return {
						"DebugMode": "debugMode",
						"DisableCallCentre": "disableCallCentre",
						"UseBlindTransfer": "useBlindTransfer"
					};
				},

				/**
				 * ############ ####### ## ###### "#########"
				 * @private
				 */
				saveButtonClick: function() {
					var isPasswordEncrypted = this.get("IsPasswordEncrypted");
					var passwordColumnName = this.get("PasswordColumnName");
					if (!isPasswordEncrypted && !Ext.isEmpty(passwordColumnName)) {
						var password = this.get(passwordColumnName);
						this.encryptPassword(password, function(encryptedPassword) {
							this.set(passwordColumnName, encryptedPassword);
							this.saveSysMsgUserSettings();
						}.bind(this));
					} else {
						this.saveSysMsgUserSettings();
					}
				},

				/**
				 * ######### ######### ########### ######### ############.
				 * @private
				 */
				saveSysMsgUserSettings: function() {
					if (!this.get("DisableCallCentre") && !this.validate()) {
						this.showInformationDialog(this.getValidationMessage());
						return;
					}
					var query;
					var settingsId = this.get("sysMsgUserSettingsId");
					var sysMsgLibId = this.get("sysMsgLibId");
					if (!Ext.isEmpty(settingsId)) {
						query = Ext.create("BPMSoft.UpdateQuery", {rootSchemaName: "SysMsgUserSettings"});
						query.enablePrimaryColumnFilter(settingsId);
					} else {
						query = Ext.create("BPMSoft.InsertQuery", {rootSchemaName: "SysMsgUserSettings"});
						query.setParameterValue("User", BPMSoft.SysValue.CURRENT_USER.value,
							BPMSoft.DataValueType.GUID);
					}
					query.setParameterValue("SysMsgLib", sysMsgLibId, BPMSoft.DataValueType.GUID);
					var connectionParams = {};
					var connectionParamsConfig = this.get("connectionParamsConfig");
					BPMSoft.each(connectionParamsConfig, function(paramName, attributeName) {
						var attributeValue = this.get(attributeName);
						connectionParams[paramName] = Ext.isEmpty(attributeValue) ? "" : attributeValue;
					}.bind(this));
					query.setParameterValue("ConnectionParams", BPMSoft.encode(connectionParams),
						BPMSoft.DataValueType.TEXT);
					query.execute(this.goBack, this);
				},

				/**
				 * ############ ####### ## ###### "######".
				 * @private
				 */
				cancelButtonClick: function() {
					this.goBack();
				},

				/**
				 * ########## ############ ## ########## ######.
				 * @private
				 */
				goBack: function() {
					this.showInformationDialog('Изменения сохранены')
				}
			},
			diff: [
				{
					"operation": "insert",
					"name": "setupCallCentreParametersContainer",
					"propertyName": "items",
					"values": {
						"id": "setupCallCentreParametersContainer",
						"selectors": {
							"el": "#setupCallCentreParametersContainer",
							"wrapEl": "#setupCallCentreParametersContainer"
						},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["setup-call-centre-parameters-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "topSettings",
					"parentName": "setupCallCentreParametersContainer",
					"propertyName": "items",
					"values": {
						"id": "topSettings",
						"selectors": {"wrapEl": "#topSettings"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["top-settings-container"],
						"items": [
							{
								"id": "SaveButton",
								"markerValue": "SaveButton",
								"itemType": BPMSoft.ViewItemType.BUTTON,
								"click": {"bindTo": "saveButtonClick"},
								"caption": {"bindTo": "Resources.Strings.SaveButtonCaption"},
								"selectors": {"wrapEl": "#rightPanelCloseButton"},
								"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
								"tag": "save"
							},
							{
								"id": "CancelButton",
								"markerValue": "CancelButton",
								"itemType": BPMSoft.ViewItemType.BUTTON,
								"click": {"bindTo": "cancelButtonClick"},
								"caption": {"bindTo": "Resources.Strings.CancelButtonCaption"},
								"classes": {"textClass": ["cancel-button"]},
								"selectors": {"wrapEl": "#rightPanelCloseButton"},
								"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
								"tag": "CancelButton"
							}
						]
					}
				},
				{
					"operation": "insert",
					"name": "controlsContainerTop",
					"parentName": "setupCallCentreParametersContainer",
					"propertyName": "items",
					"values": {
						"id": "controlsContainerTop",
						"selectors": {"wrapEl": "#controlsContainerTop"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["controls-container-top"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "controlsContainer",
					"parentName": "setupCallCentreParametersContainer",
					"propertyName": "items",
					"values": {
						"id": "controlsContainer",
						"selectors": {"wrapEl": "#controlsContainer"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["controls-block-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "controlsContainerRight",
					"parentName": "setupCallCentreParametersContainer",
					"propertyName": "items",
					"values": {
						"id": "controlsContainerRight",
						"selectors": {"wrapEl": "#controlsContainerRight"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["controls-container-right"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "controlsContainerBottom",
					"parentName": "setupCallCentreParametersContainer",
					"propertyName": "items",
					"values": {
						"id": "controlsContainerBottom",
						"selectors": {"wrapEl": "#controlsContainerBottom"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["controls-container-bottom"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "controlsContainer",
					"propertyName": "items",
					"name": "DisableCallCentre",
					"values": {
						"generator": "SetupCallCenterUtilities.generateBottomCheckBoxControl"
					}
				},
				{
					"operation": "insert",
					"parentName": "controlsContainerBottom",
					"propertyName": "items",
					"name": "DebugMode",
					"values": {
						"generator": "SetupCallCenterUtilities.generateBottomCheckBoxControl"
					}
				},
				{
					"operation": "insert",
					"parentName": "controlsContainerBottom",
					"propertyName": "items",
					"name": "UseBlindTransfer",
					"values": {
						"generator": "SetupCallCenterUtilities.generateBottomCheckBoxControl"
					}
				}
			]
		};
	});
