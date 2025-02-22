﻿/**
 * ########## ###### ##### ########## ### #########. ########### ###### ######## ######.
 */
define("MainHeaderExtensions", ["ext-base", "BPMSoft", "IconHelper", "CtiConstants"],
	function(Ext, BPMSoft, IconHelper, CtiConstants) {

		/**
		 * ########## ############ ###### ######### ######### ### ###### #######.
		 * @private
		 * @return {Object} ############ ###########.
		 */
		function getOperatorStatusProfileIcon() {
			var stateCode = this.get("AgentState");
			return this.getProfileMenuStatusIcon(stateCode);
		}

		/**
		 * ########## ############ ###### #### ######### #########.
		 * @private
		 * @param {String} stateCode ### c######## #########.
		 * @return {Object} ############ ###########.
		 */
		function getProfileMenuStatusIcon(stateCode) {
			var agentStates = this.get("AgentStates");
			var agentState = agentStates && agentStates.find(stateCode);
			return agentState && agentState.iconConfig;
		}

		/**
		 * ########## ############ ########### ###### #### ######### #########.
		 * @param {Object} image ######, # ####### ########### ########### ## #### ######.
		 * @param {String} image.value ############# ###########.
		 * @return {Object} ############ ###########.
		 */
		function getAgentStateIconConfig(image) {
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
		}

		/**
		 * ############# ############## ###### ############# ##### ##########.
		 * @param {BPMSoft.BaseViewModel} viewModel
		 * @overridden
		 */
		function customInitViewModel(viewModel) {
			var sandbox = viewModel.getSandbox();
			var ctiModel = BPMSoft.CtiModel;
			if (ctiModel && ctiModel.get("IsConnected")) {
				viewModel.onCtiPanelConnected();
			}
			sandbox.subscribe("AgentStateChanged", function(stateCode) {
				viewModel.set("AgentState", stateCode);
			}, viewModel);
			sandbox.subscribe("CtiPanelConnected", viewModel.onCtiPanelConnected, viewModel);
			viewModel.on("change:AgentState", viewModel.onAgentStateChanged, viewModel);
		}

		/**
		 * ############ ########## # cti #######.
		 * @private
		 */
		function onCtiPanelConnected() {
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
			});
		}

		/**
		 * ######### ######## ###### ############# ##### ##########.
		 * @param {Object} values ############ ######## ######.
		 * @overridden
		 */
		function extendViewModelValues(values) {
			Ext.apply(values, {

				/**
				 * ####### ### ######### #########.
				 * @private
				 * @type {String}
				 */
				AgentState: "",

				/**
				 * Current agent state display value.
				 * @private
				 * @type {String}
				 */
				AgentStateDisplayValue: "",

				/**
				 * ######### ######### #########.
				 * @private
				 * @type {BPMSoft.Collection}
				 */
				AgentStates: null
			});
		}

		/**
		 * ######### ######### ########### ########## ############.
		 * @param {BPMSoft.Container} imageContainer ######### ########### ########## ############.
		 * @overridden
		 */
		function extendImageContainer(imageContainer) {
			var operatorStatusIconConfig = IconHelper.createIconButtonConfig({
				name: "operatorStatusIcon",
				imageClass: "operator-status-icon",
				wrapperClass: "operator-status-icon-wrapper"
			});
			Ext.apply(operatorStatusIconConfig, {
				imageConfig: {bindTo: "getOperatorStatusProfileIcon"},
				markerValue: {bindTo: "AgentState"},
				hint: {bindTo: "AgentStateDisplayValue"}
			});
			imageContainer.add(operatorStatusIconConfig);
		}

		/**
		 * ######### ###### # ## ## ####### ######### #########.
		 * @param {Function} callback ####### ######### ######.
		 * @private
		 */
		function executeAgentStateQuery(callback) {
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
			esq.addColumn("Id", "Id");
			esq.addColumn("Name", "Name");
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
		}

		/**
		 * ######### ######### ######### ######### ## ########## ####### ####### # ##.
		 * @param {Object} agentStatesQueryResult ######### ####### # ## ## ####### ######### #########.
		 * @returns {BPMSoft.Collection} ######### ######### #########.
		 * @private
		 */
		function getAgentStates(agentStatesQueryResult) {
			var agentStates = new BPMSoft.Collection();
			agentStatesQueryResult.collection.each(function(item) {
				var valueCode = item.get("Code");
				var agentState = agentStates.find(valueCode);
				if (!agentState) {
					agentState = {
						value: item.get("Id"),
						displayValue: item.get("Name"),
						code: valueCode,
						iconConfig: getAgentStateIconConfig(item.get("Icon")),
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
			});
			return agentStates;
		}

		/**
		 * Returns agent state display value by code.
		 * @private
		 * @param {String} stateCode Code of the agent state.
		 * @return {String}
		 */
		function getAgentStateDisplayValue(stateCode) {
			var agentStates = this.get("AgentStates");
			if (Ext.isEmpty(agentStates)) {
				return "";
			}
			var agentState = agentStates.find(stateCode);
			var agentStateDisplayValue = Ext.isEmpty(agentState) ? "" : agentState.displayValue;
			return agentStateDisplayValue;
		}

		/**
		 * ######### ###### #### ######### ######### # #### ###### #######.
		 * @param {BPMSoft.Collection} agentStates ######### ######### #########.
		 * @param {Function} callback ####### ######### ######.
		 * @private
		 */
		function generateAgentStateMenuItems(agentStates, callback) {
			var profileMenuCollection = this.get("ProfileMenuCollection");
			profileMenuCollection.clear();
			agentStates.each(function(item) {
				if (item.isDisplayOnly) {
					return true;
				}
				var hasReasons = !Ext.isEmpty(item.reasons);
				var menuItem = Ext.create("BPMSoft.BaseViewModel", {
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
			profileMenuCollection.addItem(Ext.create("BPMSoft.BaseViewModel", {
				values: {
					Type: "BPMSoft.MenuSeparator",
					Caption: ""
				}
			}));
			callback.call(this);
		}

		/**
		 * ######### ######### ###### ######### ######### #########.
		 * @param {String} stateCode ### ######### #########.
		 * @param {BPMSoft.Collection} reasons ####### ######### #########.
		 * @return {BPMSoft.BaseViewModelCollection} ######### ###### ######### #########.
		 * @private
		 */
		function getAgentStateReasons(stateCode, reasons) {
			var reasonCollection = Ext.create("BPMSoft.BaseViewModelCollection");
			reasons.each(function(reason) {
				reasonCollection.addItem(Ext.create("BPMSoft.BaseViewModel", {
					values: {
						Caption: reason.displayValue,
						Tag: stateCode + "/" + reason.code,
						Click: {bindTo: "onOperatorStatusReasonChange"}
					}
				}));
			});
			return reasonCollection;
		}

		/**
		 * ############# ######### #########.
		 * @param {Object} tag ################# ######.
		 * @private
		 */
		function onOperatorStatusChange(tag) {
			var ctiModel = BPMSoft.CtiModel;
			ctiModel.setAgentState(tag);
		}

		/**
		 * ############# ######### ######### # ####### ######### #########.
		 * @param {Object} tag ################# ######.
		 * @private
		 */
		function onOperatorStatusReasonChange(tag) {
			var tagParams = tag.split("/");
			var agentState = tagParams[0];
			var agentStateReasonCode = tagParams[1];
			var ctiModel = BPMSoft.CtiModel;
			ctiModel.setAgentState(agentState, agentStateReasonCode);
		}

		/**
		 * Handler of the agent state attribute change event.
		 * @param {Backbone.Model} model Model.
		 * @param {String} stateCode Agent state code.
		 * @private
		 */
		function onAgentStateChanged(model, stateCode) {
			this.set("AgentStateDisplayValue", this.getAgentStateDisplayValue(stateCode));
		}

		/**
		 * ######### ###### ###### ############# ##### ##########.
		 * @param {Object} methods ############ ###### ######.
		 * @overridden
		 */
		function extendViewModelMethods(methods) {
			Ext.apply(methods, {
				getOperatorStatusProfileIcon: getOperatorStatusProfileIcon,
				onCtiPanelConnected: onCtiPanelConnected,
				executeAgentStateQuery: executeAgentStateQuery,
				getAgentStates: getAgentStates,
				getAgentStateDisplayValue: getAgentStateDisplayValue,
				getAgentStateReasons: getAgentStateReasons,
				generateAgentStateMenuItems: generateAgentStateMenuItems,
				getProfileMenuStatusIcon: getProfileMenuStatusIcon,
				onOperatorStatusChange: onOperatorStatusChange,
				onOperatorStatusReasonChange: onOperatorStatusReasonChange,
				onAgentStateChanged: onAgentStateChanged
			});
		}

		return {
			customInitViewModel: customInitViewModel,
			extendViewModelValues: extendViewModelValues,
			extendViewModelMethods: extendViewModelMethods,
			extendImageContainer: extendImageContainer
		};
	});
