define("MainHeaderSchema", ["RightUtilities", "css!MainHeaderSchemaCSS"], function (RightUtilities) {
	return {
		properties: {
			omnichannelOperatorServiceName: "OmnichannelOperatorService",
			operatorStateSchemaName: "OperatorState",
			phoneOperatorStateServiceName : "PhoneOperatorStatusService"
		},
		attributes: {
			/**
			 * The current operator state code.
			 * @private
			 * @type {String}
			 */
			"OperatorState": {
				dataValueType: this.BPMSoft.DataValueType.TEXT,
				value: BPMSoft.emptyString
			},

			/**
			 * A collection of operator states.
			 * @private
			 * @type {BPMSoft.Collection}
			 */
			"OperatorStates": {
				dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT,
				value: null
			},

			/**
			 * User has omnichannel license operation.
			 * @type {Boolean}
			 */
			"HasOmnichannelLicOperation": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": false
			},

			/**
			 * Current user has omnichannel rights.
			 * @private
			 * @type {Boolean}
			 */
			"HasOmnichannelRights": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				value: null
			},
			/**
			* Статус оператора телефонии.
			* @protected
			*/
			"PhoneOperatorState": {
				dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT,
				value: {
					code: "NotActive",
				    availableStatus: false
				}
			}
			
		},
		messages: {},
		mixins: {},
		methods: {

			//region Methods: Private

			/**
			* Запрос на получение всех статусов
			* @protected
			*/
			executeAgentStateQuery: function(callback) {
				var cacheKey = "SysMsgUserState_ProfileMenuStatuses";
				var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "SysMsgUserState",
					clientESQCacheParameters: {
						cacheItemName: cacheKey
					},
					serverESQCacheParameters: {
						cacheLevel: BPMSoft.ESQServerCacheLevels.SESSION,
						cacheGroup: "SysMsgUserState",
						cacheItemName: cacheKey
					}
				});
				esq.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_COLUMN, "Id");
				esq.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_DISPLAY_COLUMN, "Name");
				esq.addColumn("Code", "Code");
				esq.addColumn("Icon", "Icon");
				// От родителького отличие только в этой колонки.
				esq.addColumn("IsAvailableStatus", "IsAvailableStatus");
				esq.addColumn("IsDisplayOnly", "IsDisplayOnly");
				esq.addColumn("[SysMsgUserStateReason:SysMsgUserState].Code", "StateReasonCode");
				esq.addColumn("[SysMsgUserStateReason:SysMsgUserState].Name", "StateReasonName");
				esq.filters.add("filterSysMsgUserState", BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL,
						"[SysMsgUserStateInLib:SysMsgUserState].SysMsgLib",
						BPMSoft.SysValue.CTI.sysMsgLibId));
				esq.getEntityCollection(callback, this);
			},
			
			/**
			* Генерация статусов
			* @protected
			*/
			generateAgentStateMenuItems: function(agentStates, callback) {
				var profileMenuCollection = this.get("ProfileMenuCollection");
				profileMenuCollection.clear();
				profileMenuCollection.addItem(this.Ext.create("BPMSoft.BaseViewModel", {
					values: {
						Type: "BPMSoft.MenuSeparator",
						Caption: {
							bindTo: "Resources.Strings.TelephonyMenuSeparator"
						},
					}
				}));
				agentStates.each(function(item) {
					if (item.isDisplayOnly) {
						return true;
					}
					var hasReasons = !this.Ext.isEmpty(item.reasons);
					var menuItem = this.Ext.create("BPMSoft.BaseViewModel", {
						values: {
							Caption: item.displayValue,
							MarkerValue: item.displayValue,
							// Доработка тега
							Tag: {
									code: item.code,
									availableStatus: item.availableStatus
								 },
							ImageConfig: this.getProfileMenuStatusIcon(item.code),
							Click: hasReasons ? null : {bindTo: "onOperatorStatusChange"},
							Items: hasReasons ? this.getAgentStateReasons(item.code, item.reasons) : null
						}
					});
					profileMenuCollection.addItem(menuItem);
				}, this);
				profileMenuCollection.addItem(this.Ext.create("BPMSoft.BaseViewModel", {
					values: {
						Type: "BPMSoft.MenuSeparator",
						Caption: ""
					}
				}));
				callback.call(this);
			},
			
			/**
			* Получение всех статусов провайдера телефонии
			* @protected
			*/
			getAgentStates: function(agentStatesQueryResult) {
				let agentStates = new BPMSoft.Collection();
				agentStatesQueryResult.collection.each(function(item) {
					let valueCode = item.get("Code");
					let image = item.get("Icon");
					let agentState = agentStates.find(valueCode);
					if (!agentState) {
						agentState = {
							value: item.get("Id"),
							displayValue: item.get("Name"),
							code: valueCode,
							availableStatus: item.get("IsAvailableStatus"),
							iconConfig: this.getIconConfig(image && image.value,
								"SysMsgUserStateIcon", "Image"),
							isDisplayOnly: item.get("IsDisplayOnly"),
							reasons: null
						};
						agentStates.add(valueCode, agentState);
					}
					let stateReasonCode = item.get("StateReasonCode");
					if (Ext.isEmpty(stateReasonCode)) {
						return;
					}
					let stateReasonName = item.get("StateReasonName");
					agentState.reasons = agentState.reasons || new BPMSoft.Collection();
					agentState.reasons.add(stateReasonCode, {
						code: stateReasonCode,
						displayValue: stateReasonName
					});
				}, this);
				return agentStates;
			},
			
			/**
			* Действие на смену статуса оператора телефонии.
			* @protected
			*/
			onOperatorStatusChange: function(tag) {
				let scope = this;
				let ctiModel = BPMSoft.CtiModel;
				ctiModel.setAgentState(tag.code);
				let currentStatus = scope.get("PhoneOperatorState");
				if (scope.isEmpty(tag.code) || currentStatus.State !== tag.availableStatus ) {
					scope.changeTelephonyOperatorState(tag, function(response) {
						if (response.success) {
								scope.set("PhoneOperatorState", tag);
						}
						else if (response.errorInfo) {
							this.error(response.errorInfo.message);
						}
					});
					}
			},
			
			/**
			 * Returns operator state info.
			 * @private
			 * @param {String} stateCode Operator status code.
			 * @return {Object} Operator info result.
			 */
			_getOperatorStateInfo: function (stateCode) {
				const operatorStates = this.get("OperatorStates");
				return operatorStates && operatorStates.find(stateCode);
			},

			/**
			 * Updates operator status on server message.
			 * @private
			 * @param {Object} scope message scope.
			 * @param {Object} message Server channel message.
			 */
			_onOperatorStatusChanged: function(scope, message) {
				if (message.Header.Sender === "OperatorStateChanged") {
					const body = this.Ext.decode(message.Body);
					this.set("OperatorState", body.StateCode);
				}
			},
			

			/**
			 * Check license operation for using chats.
			 */
			_checkOmnichannelLicOperation: function(callback, scope) {
				scope.callService({
					serviceName: "CtiRightsService",
					methodName: "GetUserHasOperationLicense",
					data: {
						operations: ['Chats.Use'],
						isAnyOperation: false
					}
				}, function(result) {
					this.$HasOmnichannelLicOperation = result.GetUserHasOperationLicenseResult;
					this.Ext.callback(callback, scope);
				}, this);
			},

			_hasOmnichannelRights: function(callback, scope) {
				RightUtilities.getSchemaEditRights({schemaName: "OmniChat"}, function(result) {
					this.$HasOmnichannelRights = this.Ext.isEmpty(result);
					Ext.callback(callback, scope);
				}, this);
			},

			//endregion

			//region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.MainHeaderSchema#loadProfileButtonMenu
			 * @override
			 */
			loadProfileButtonMenu: function () {
				const parentMethod = this.getParentMethod();
				if (this.getIsFeatureEnabled("ShowOmniChatInCommPanel")) {
					BPMSoft.chain(
						function (next) {
							this.getCurrentUserOperatorInfo(next, this);
						},
						function (next) {
							this._hasOmnichannelRights(next, this);
						},
						function (next) {
							if (this.$HasOmnichannelRights &&
								this.isNotEmpty(this.get("OperatorState"))) {
								this.addOperatorStatesToProfileButtonMenu(next, this);
							} else {
								next();
							}
						},
						function () {
							parentMethod.call(this);
						}, this);
				} else {
					parentMethod.call(this);
				}
			},

			/**
			 * Forms a collection of operator states from the result of a selection request to the database.
			 * @protected
			 * @param {Object} operatorStatesQueryResult Result of a database query for a selection of operator states.
			 * @returns {BPMSoft.Collection} A collection of operator states.
			 */
			getOperatorStates: function (operatorStatesQueryResult) {
				const operatorStates = new BPMSoft.Collection();
				operatorStatesQueryResult.collection.each(function (item) {
					const valueCode = item.get("Code");
					let operatorState = operatorStates.find(valueCode);
					if (!operatorState) {
						operatorState = {
							value: item.get("Id"),
							displayValue: item.get("Name"),
							code: valueCode,
							operatorAvailable: item.get("OperatorAvailable"),
							iconConfig: this.getIconConfig(item.get("Id"),
								this.operatorStateSchemaName, "Image"),
						};
						operatorStates.add(valueCode, operatorState);
					}
				}, this);
				return operatorStates;
			},

			/**
			 * Sets the state of the operator.
			 * @protected
			 * @param {String} tag Element tag.
			 */
			onChatOperatorStateChange: function (tag) {
				if (this.isEmpty(tag) || tag === this.get("OperatorState")) {
					return;
				}
				this.changeOperatorState(tag, this.handleOperatorStateChange);
			},

			/**
			 * Getting the current state of the operator.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Execution context.
			 * @protected
			 */
			getCurrentUserOperatorInfo: function (callback, scope) {
				const config = {
					serviceName: this.omnichannelOperatorServiceName,
					methodName: "GetCurrentState"
				};
				this.callService(config, function (response) {
					if (response) {
						if (response.success) {
							this.set("OperatorState", response.CurrentStateCode);
						} else if (response.errorInfo) {
							this.error(response.errorInfo.message);
						}
					}
					Ext.callback(callback, scope);
				}, this);
			},

			/**
			 * #all the service of changing the operator state.
			 * @param {String} newState New state for operator.
			 * @param {Function} callback Callback function.
			 * @protected
			 */
			changeOperatorState: function (newState, callback) {
				const config = {
					serviceName: this.omnichannelOperatorServiceName,
					methodName: "ChangeState",
					data: {
						newState: newState
					}
				};
				this.callService(config, callback, this);
			},

			/**
			 * Handles after change operator state.
			 * @param {Object} response Response from server.
			 * @protected
			 */
			handleOperatorStateChange: function (response) {
				if (response) {
					if (response.success) {
						this.set("OperatorState", response.CurrentStateCode);
					} else if (response.errorInfo) {
						this.error(response.errorInfo.message);
					}
				}
			},

			/**
			 * Add omnichannel operator statuses.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Execution context.
			 */
			addOperatorStatesToProfileButtonMenu: function (callback, scope) {
				this.executeOperatorStateQuery(function (result) {
					const operatorStates = this.getOperatorStates(result);
					this.set("OperatorStates", operatorStates);
					this.generateOperatorStateMenuItems(operatorStates);
					Ext.callback(callback, scope);
				});
			},

			/**
			 * Request to read operator statuses
			 * @param {Function} Callback function.
			 * @protected
			 */
			executeOperatorStateQuery: function (callback) {
				const operatorStateEsq = this.getOperatorStateEsq();
				operatorStateEsq.getEntityCollection(callback, this);
			},

			/**
			 * Creates a query to select an operator state.
			 * @protected
			 * @returns {BPMSoft.EntitySchemaQuery} Operator state select query.
			 */
			getOperatorStateEsq: function () {
				const cacheKey = "OperatorState_ProfileMenuStatuses";
				const esq = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: this.operatorStateSchemaName,
					clientESQCacheParameters: {
						cacheItemName: cacheKey
					},
					serverESQCacheParameters: {
						cacheLevel: BPMSoft.ESQServerCacheLevels.SESSION,
						cacheGroup: this.operatorStateSchemaName,
						cacheItemName: cacheKey
					}
				});
				esq.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_COLUMN, "Id");
				esq.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_DISPLAY_COLUMN, "Name");
				esq.addColumn("Code");
				esq.addColumn("Image");
				esq.addColumn("OperatorAvailable");
				return esq;
			},

			/**
			 * @inheritdoc BPMSoft.MainHeaderSchema#getOperatorStatusProfileIcon
			 * @override
			 */
			getOperatorStatusProfileIcon: function () {
				//const currentOperatorStateInfo = this._getOperatorStateInfo(this.get("OperatorState"));
				//const baseProfileIcon = this.callParent(arguments);
				//if (this.isEmpty(currentOperatorStateInfo)) {
				//	return baseProfileIcon;
				//}
				//const resultProfileIcon = currentOperatorStateInfo.operatorAvailable && this.isNotEmpty(baseProfileIcon)
				//	? baseProfileIcon
				//	: currentOperatorStateInfo.iconConfig;
				//return resultProfileIcon;

				let isPortalUser = this.BPMSoft.CurrentUser.userType === this.BPMSoft.UserType.SSP;
				if (isPortalUser) {
					return;
				}

				let ctiModel = BPMSoft.CtiModel;
				let ctiStatus = ctiModel.get("IsConnected");
				let chatState = this.get("OperatorState");
				if (chatState === "Active") {
					return this.get("Resources.Images.OperatorStatusOn");
				}
				else {
					return this.get("Resources.Images.OperatorStatusOff");
				}
			},

			/**
			 * Forms menu items of operator states in the profile button menu.
			 * @protected
			 * @param {BPMSoft.Collection} operatorStates Operator state collection.
			 */
			generateOperatorStateMenuItems: function (operatorStates) {
				const profileMenuCollection = this.get("ProfileMenuCollection");
				profileMenuCollection.addItem(this.Ext.create("BPMSoft.BaseViewModel", {
					values: {
						Id: "separator-profil-menu-item-menu-separator",
						Type: "BPMSoft.MenuSeparator",
						Caption: {
							bindTo: "Resources.Strings.ChatMenuSeparator"
						},
					}
				}));
				operatorStates.each(function (item) {
					const menuItem = this.Ext.create("BPMSoft.BaseViewModel", {
						values: {
							Id: item.value,
							Caption: item.displayValue,
							MarkerValue: item.displayValue,
							Tag: item.code,
							ImageConfig: item.iconConfig,
							Click: { bindTo: "onChatOperatorStateChange" }
						}
					});
					profileMenuCollection.addItem(menuItem);
				}, this);
				profileMenuCollection.addItem(this.Ext.create("BPMSoft.BaseViewModel", {
					values: {
						Id: "t-comp49-menu-separator-menu-separator",
						Type: "BPMSoft.MenuSeparator",
						Caption: BPMSoft.emptyString
					}
				}));
			},

			/**
			 * Returns operator state display value.
			 * @override
			 */
			getOperatorStateDisplayValue: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.MainHeaderSchema#init
			 * @override
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this.BPMSoft.ServerChannel.on(BPMSoft.EventName.ON_MESSAGE, this._onOperatorStatusChanged, this);
					this.Ext.callback(callback, scope || this);
				}, this]);
				this.BPMSoft.ServerChannel.un(BPMSoft.EventName.ON_MESSAGE, this._onOperatorStatusChanged, this);
				this.BPMSoft.ServerChannel.on(BPMSoft.EventName.ON_MESSAGE, this.onOperatorPhoneAndChatStatusChanged, this);
				this.on("change:PhoneOperatorState", function () {
					this.getOperatorStatusProfileIcon();
					this.getPhoneStatusProfileIcon();
				}, this);
			},
			
			/**
			* Обработка сообщений о смени статуса по веб-сокету.
			* @protected
			*/
			onOperatorPhoneAndChatStatusChanged: function(scope, message) {
				if (message.Header.Sender === "OperatorStateChanged") {
					const body = this.Ext.decode(message.Body);
					this.set("OperatorState", body.StateCode);
				}
				if (message.Header.Sender === "PhoneOperatorStateChanged") {
					const body = this.Ext.decode(message.Body);
					let state = {
								code : body.State,
								availableStatus : body.IsAvailable
							};
					this.set("PhoneOperatorState", state);
					let ctiModel = BPMSoft.CtiModel;
					ctiModel.setAgentState(body.State);
				}
			},
			
			/**
			* Действие при подключении телефонии.
			* @protected
			*/
			onCtiPanelConnected: function() {
				let scope = this;
				scope.callParent(arguments);
				scope.getTelephonyOperatorState(function(response){
					if (response && Ext.isEmpty(response.State)) {
						// to do...
						scope.set("PhoneOperatorState", {code: "Active", availableStatus: true});
					}
					else {
						let state = {
							code : response.State,
							availableStatus : response.IsAvailable
						};
						scope.onOperatorStatusChange(state);
					}
				});
			},
			
			/**
			* Смена статуса оператора телефонии на сервере.
			* @protected
			*/
			changeTelephonyOperatorState: function (statusData, callback) {
				const config = {
					serviceName: this.phoneOperatorStateServiceName,
					methodName: "ChangeState",
					data: {
						state: statusData.code,
						available: statusData.availableStatus
					}
				};
				this.callService(config, callback, this);
			},
			
			/**
			* Получение статуса оператора телефонии с сервера.
			* @protected
			*/
			getTelephonyOperatorState: function(callback) {
				const config = {
					serviceName: this.phoneOperatorStateServiceName,
					methodName: "GetState",
				};
				this.callService(config, callback, this);
			},
			
			/**
			* Установка иконок статус телефонии на профиле пользователя.
			* @protected
			*/
			getPhoneStatusProfileIcon: function () {
				let isPortalUser = this.BPMSoft.CurrentUser.userType === this.BPMSoft.UserType.SSP;
				if (isPortalUser) {
					return;
				}

				let phoneState = this.get("PhoneOperatorState");
				if (phoneState.availableStatus) {
					return this.get("Resources.Images.PhoneStatusOn");
				}
				else {
					return this.get("Resources.Images.PhoneStatusOff");
				}
			}
			
			//endregion

		},
		diff: [
			{
						"operation": "insert",
						"name": "phoneStatusIcon",
						"parentName": "UserProfileContainer",
						"propertyName": "items",
						"values": {
							"id": "view-button-phoneStatusIcon",
							"itemType": BPMSoft.ViewItemType.BUTTON,
							"selectors": {
								wrapEl: "#view-button-operatorStatusIcon"
							},
							"classes": {
								"wrapperClass": ["operator-status-icon-wrapper", "phone-status-icon-wrapper"],
								"pressedClass": ["pressed-button-view"],
								"imageClass": ["operator-status-icon", "view-images-class"]
							},
							"visible": true,
							"hint": {"bindTo": "getOperatorStateDisplayValue"},
							"tips": [],
							"click": {"bindTo": "onViewButtonClick"},
							"imageConfig": {"bindTo": "getPhoneStatusProfileIcon"},
							"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							"iconAlign": this.BPMSoft.controls.ButtonEnums.iconAlign.LEFT,
							"markerValue": {"bindTo": "AgentState"},
							"tag": "operatorStatusIcon"
						}
					}
		]
	};
});
