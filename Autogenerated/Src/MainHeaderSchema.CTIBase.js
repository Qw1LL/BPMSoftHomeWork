define("MainHeaderSchema", ["CtiConstants"],
		function(CtiConstants) {
			return {
				attributes: {
					/**
					 * ####### ### ######### #########.
					 * @private
					 * @type {String}
					 */
					"AgentState": {
						dataValueType: this.BPMSoft.DataValueType.TEXT,
						value: ""
					},

					/**
					 * Current agent state display value.
					 * @private
					 * @type {String}
					 */
					"AgentStateDisplayValue": {
						dataValueType: this.BPMSoft.DataValueType.TEXT,
						value: ""
					},

					/**
					 * ######### ######### #########.
					 * @private
					 * @type {BPMSoft.Collection}
					 */
					"AgentStates": {
						dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT,
						value: null
					}
				},
				methods: {

					//region Methods: Protected

					/**
					 * @inheritdoc BPMSoft.MainHeaderSchemaViewModel#init
					 * @overridden
					 */
					init: function() {
						this.callParent(arguments);
						var ctiModel = BPMSoft.CtiModel;
						if (ctiModel && ctiModel.get("IsConnected")) {
							this.onCtiPanelConnected();
						}
						this.sandbox.subscribe("AgentStateChanged", function(stateCode) {
							this.set("AgentState", stateCode);
						}, this);
						this.sandbox.subscribe("CtiPanelConnected", this.onCtiPanelConnected, this);
						this.on("change:AgentState", this.onAgentStateChanged, this);
					},

					/**
					 * ########## ############ ###### ######### ######### ### ###### #######.
					 * @protected
					 * @return {Object} ############ ###########.
					 */
					getOperatorStatusProfileIcon: function() {
						var stateCode = this.get("AgentState");
						return this.getProfileMenuStatusIcon(stateCode);
					},

					/**
					 * ############ ########## # cti #######.
					 * @protected
					 */
					onCtiPanelConnected: function() {
						this.executeAgentStateQuery(function(result) {
							var agentStates = this.getAgentStates(result);
							this.set("AgentStates", agentStates);
							var ctiModel = BPMSoft.CtiModel;
							if (ctiModel) {
								var stateCode = ctiModel.get("AgentState");
								this.set("AgentState", stateCode);
								this.set("AgentStateDisplayValue", this.getAgentStateDisplayValue(stateCode));
							}
							this.generateAgentStateMenuItems(agentStates, this.loadProfileButtonMenu);
							this.setSavedAgentState();
						});
					},

					/**
					 * Sets agent state from profile.
					 * @protected
					 */
					setSavedAgentState: function() {
						if (this.getIsFeatureDisabled("SetSavedAgentState")) {
							return;
						}
						var profile = this.getProfile() || {};
						var savedState = profile.agentState;
						if (!savedState) {
							return;
						}
						this.onOperatorStatusChange(savedState);
					},

					/**
					 * ######### ###### # ## ## ####### ######### #########.
					 * @protected
					 * @param {Function} callback ####### ######### ######.
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
					 * ########## ############ ########### ###### #### ######### #########.
					 * @obsolete
					 * @param {Object} image ######, # ####### ########### ########### ## #### ######.
					 * @param {String} image.value ############# ###########.
					 * @return {Object} ############ ###########.
					 */
					getAgentStateIconConfig: function(image) {
						var iconId = image && image.value;
						if (Ext.isEmpty(iconId) || this.BPMSoft.isEmptyGUID(iconId)) {
							iconId = CtiConstants.DefaultSysMsgUserStateIconId;
						}
						var iconConfig = {
							source: this.BPMSoft.ImageSources.ENTITY_COLUMN,
							params: {
								schemaName: "SysMsgUserStateIcon",
								columnName: "Image",
								primaryColumnValue: iconId
							}
						};
						return {
							source: BPMSoft.ImageSources.URL,
							url: BPMSoft.ImageUrlBuilder.getUrl(iconConfig)
						};
					},

					/**
					 * Returns the configuration of the operator state menu icon.
					 * @protected
					 * @param {String} iconId Image ID.
					 * @param {String} schemaName Entity schema name.
					 * @param {String} columnName Entity column name.
					 * @return {Object} Image config.
					 */
					getIconConfig: function (imageId, schemaName, columnName) {
						if (Ext.isEmpty(imageId) || this.BPMSoft.isEmptyGUID(imageId)) {
							imageId = CtiConstants.DefaultSysMsgUserStateIconId;
						}
						const iconConfig = {
							source: this.BPMSoft.ImageSources.ENTITY_COLUMN,
							params: {
								schemaName: schemaName,
								columnName: columnName,
								primaryColumnValue: imageId
							}
						};
						return {
							source: BPMSoft.ImageSources.URL,
							url: BPMSoft.ImageUrlBuilder.getUrl(iconConfig)
						};
					},

					/**
					 * ######### ######### ######### ######### ## ########## ####### ####### # ##.
					 * @protected
					 * @param {Object} agentStatesQueryResult ######### ####### # ## ## ####### ######### #########.
					 * @returns {BPMSoft.Collection} ######### ######### #########.
					 */
					getAgentStates: function(agentStatesQueryResult) {
						var agentStates = new BPMSoft.Collection();
						agentStatesQueryResult.collection.each(function(item) {
							var valueCode = item.get("Code");
							var image = item.get("Icon");
							var agentState = agentStates.find(valueCode);
							if (!agentState) {
								agentState = {
									value: item.get("Id"),
									displayValue: item.get("Name"),
									code: valueCode,
									iconConfig: this.getIconConfig(image && image.value,
										"SysMsgUserStateIcon", "Image"),
									isDisplayOnly: item.get("IsDisplayOnly"),
									reasons: null
								};
								agentStates.add(valueCode, agentState);
							}
							var stateReasonCode = item.get("StateReasonCode");
							if (Ext.isEmpty(stateReasonCode)) {
								return;
							}
							var stateReasonName = item.get("StateReasonName");
							agentState.reasons = agentState.reasons || new BPMSoft.Collection();
							agentState.reasons.add(stateReasonCode, {
								code: stateReasonCode,
								displayValue: stateReasonName
							});
						}, this);
						return agentStates;
					},

					/**
					 * Returns agent state display value by code.
					 * @protected
					 * @param {String} stateCode Code of the agent state.
					 * @return {String}
					 */
					getAgentStateDisplayValue: function(stateCode) {
						var agentStates = this.get("AgentStates");
						if (Ext.isEmpty(agentStates)) {
							return "";
						}
						var agentState = agentStates.find(stateCode);
						var agentStateDisplayValue = Ext.isEmpty(agentState) ? "" : agentState.displayValue;
						return agentStateDisplayValue;
					},

					/**
					 * ######### ######### ###### ######### ######### #########.
					 * @protected
					 * @param {String} stateCode ### ######### #########.
					 * @param {BPMSoft.Collection} reasons ####### ######### #########.
					 * @return {BPMSoft.BaseViewModelCollection} ######### ###### ######### #########.
					 */
					getAgentStateReasons: function(stateCode, reasons) {
						var reasonCollection = this.Ext.create("BPMSoft.BaseViewModelCollection");
						reasons.each(function(reason) {
							reasonCollection.addItem(this.Ext.create("BPMSoft.BaseViewModel", {
								values: {
									Caption: reason.displayValue,
									Tag: stateCode + "/" + reason.code,
									Click: {bindTo: "onOperatorStatusReasonChange"}
								}
							}));
						}, this);
						return reasonCollection;
					},

					/**
					 * ######### ###### #### ######### ######### # #### ###### #######.
					 * @protected
					 * @param {BPMSoft.Collection} agentStates ######### ######### #########.
					 * @param {Function} callback ####### ######### ######.
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
									Tag: item.code,
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
					 * ########## ############ ###### #### ######### #########.
					 * @protected
					 * @param {String} stateCode ### c######## #########.
					 * @return {Object} ############ ###########.
					 */
					getProfileMenuStatusIcon: function(stateCode) {
						var agentStates = this.get("AgentStates");
						var agentState = agentStates && agentStates.find(stateCode);
						return agentState && agentState.iconConfig;
					},

					/**
					 * ############# ######### #########.
					 * @protected
					 * @param {Object} tag ################# ######.
					 */
					onOperatorStatusChange: function(tag) {
						var ctiModel = BPMSoft.CtiModel;
						ctiModel.setAgentState(tag);
					},

					/**
					 * ############# ######### ######### # ####### ######### #########.
					 * @protected
					 * @param {Object} tag ################# ######.
					 */
					onOperatorStatusReasonChange: function(tag) {
						var tagParams = tag.split("/");
						var agentState = tagParams[0];
						var agentStateReasonCode = tagParams[1];
						var ctiModel = BPMSoft.CtiModel;
						ctiModel.setAgentState(agentState, agentStateReasonCode);
					},

					/**
					 * Handler of the agent state attribute change event.
					 * @protected
					 * @param {Backbone.Model} model Model.
					 * @param {String} stateCode Agent state code.
					 */
					onAgentStateChanged: function(model, stateCode) {
						this.set("AgentStateDisplayValue", this.getAgentStateDisplayValue(stateCode));
						this.saveProfileData(stateCode);
					},

					/**
					 * Save agent state to profile.
					 * @protected
					 * @param {String} stateCode Agent state code.
					 */
					saveProfileData: function(stateCode) {
						if (this.getIsFeatureDisabled("SetSavedAgentState") || !stateCode
								|| stateCode === BPMSoft.FinesseAgentState.LOGOUT) {
							return;
						}
						var profileData = Ext.Object.merge(this.getProfile() || {}, {"agentState": stateCode});
						BPMSoft.utils.saveUserProfile(this.getProfileKey(), profileData, false, function() {
							this.set("Profile", profileData);
						}, this);
					},

					/**
					 * Returns schema profile key.
					 * @protected
					 */
					getProfileKey: function() {
						return "MainHeaderSchemaProfile";
					},

					/**
					 * Returns operator state display value.
					 * @protected
					 */
					getOperatorStateDisplayValue: function() {
						return this.get("AgentStateDisplayValue") || Ext.emptyString;
					}

					//endregion

				},
				diff: [
					{
						"operation": "insert",
						"name": "operatorStatusIcon",
						"parentName": "UserProfileContainer",
						"propertyName": "items",
						"values": {
							"id": "view-button-operatorStatusIcon",
							"itemType": BPMSoft.ViewItemType.BUTTON,
							"selectors": {
								wrapEl: "#view-button-operatorStatusIcon"
							},
							"classes": {
								"wrapperClass": ["operator-status-icon-wrapper"],
								"pressedClass": ["pressed-button-view"],
								"imageClass": ["operator-status-icon", "view-images-class"]
							},
							"hint": {"bindTo": "getOperatorStateDisplayValue"},
							"tips": [],
							"click": {"bindTo": "onViewButtonClick"},
							"imageConfig": {"bindTo": "getOperatorStatusProfileIcon"},
							"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							"iconAlign": this.BPMSoft.controls.ButtonEnums.iconAlign.LEFT,
							"markerValue": {"bindTo": "AgentState"},
							"tag": "operatorStatusIcon"
						}
					}
				]
			};
		});
