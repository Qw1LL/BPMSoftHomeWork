define("CtiBaseHelper", ["BPMSoft", "CtiConstants", "CtiBaseHelperResources"], function(BPMSoft, CtiConstants,
		resources) {

	/**
	 * @class BPMSoft.CtiBaseHelper
	 * ############### ##### ### ###### #########.
	 */
	Ext.define("BPMSoft.configuration.CtiBaseHelper", {
		extend: "BPMSoft.core.BaseObject",
		alternateClassName: "BPMSoft.CtiBaseHelper",
		singleton: true,

		//region Methods: Private

		/**
		 * ####### ############### ######### # #######.
		 * @private
		 * @param {String|Object} message #########.
		 */
		logWarning: function(message) {
			this.log(message, BPMSoft.LogMessageType.WARNING);
		},

		/**
		 * ############## ######### #########.
		 * @private
		 * @param {Function} callback ####### ######### ######. # ######## ######### ########## #########
		 * #########.
		 */
		initCtiSettings: function(callback) {
			if (!BPMSoft.SysValue) {
				callback(null);
				return;
			}
			var ctiSettings = BPMSoft.SysValue.CTI;
			if (Ext.isObject(ctiSettings) && ctiSettings.isInitialized) {
				callback(ctiSettings);
				return;
			}
			ctiSettings = {
				isInitialized: false
			};
			BPMSoft.SysValue.CTI = ctiSettings;
			BPMSoft.SysSettings.querySysSettings([
					"SysMsgLib", "InternalNumberLength", "SearchNumberLength",
					"CommunicationHistoryRowCount", "DefaultContactCommunicationType",
					"DefaultAccountCommunicationType"
				],
				function(settings) {
					ctiSettings.internalNumberLength = settings.InternalNumberLength;
					ctiSettings.searchNumberLength = settings.SearchNumberLength;
					ctiSettings.communicationHistoryRowCount = settings.CommunicationHistoryRowCount;
					ctiSettings.defaultContactCommunicationType = settings.DefaultContactCommunicationType;
					ctiSettings.defaultAccountCommunicationType = settings.DefaultAccountCommunicationType;
					var sysMsgLibItem = settings.SysMsgLib;
					if (!sysMsgLibItem || (sysMsgLibItem.value === BPMSoft.GUID_EMPTY)) {
						this.logWarning(CtiConstants.LocalizableStrings.SysMsgLibSettingsEmptyMessage);
						ctiSettings.isInitialized = true;
						callback(ctiSettings);
						return;
					}
					var sysMsgLibId = settings.SysMsgLib.value;
					ctiSettings.sysMsgLibId = sysMsgLibId;
					this.initializeMsgLibSettings(sysMsgLibId, ctiSettings, function(ctiSettings) {
						this.queryCtiLicenses(ctiSettings, function(ctiSettings) {
							ctiSettings.isInitialized = true;
							callback(ctiSettings);
						});
					}.bind(this));
				}, this);
		},

		/**
		 * ############## ######### ########## #########.
		 * @private
		 * @param {String} sysMsgLibId ############# ########## ###### ###########.
		 * @param {Object} ctiSettings ######### #########.
		 * @param {Function} callback (optional) ####### ######### ######. # ######## ######### ########## #########
		 * #########.
		 */
		initializeMsgLibSettings: function(sysMsgLibId, ctiSettings, callback) {
			if (ctiSettings.isInitialized) {
				if (callback) {
					callback(ctiSettings);
				}
				return;
			}
			var batchQuery = Ext.create("BPMSoft.BatchQuery");
			batchQuery.add(this.getMsgLibSelect(sysMsgLibId));
			batchQuery.add(this.getMsgUserSettingsSelect(sysMsgLibId));
			batchQuery.execute(function(response) {
				if (!response.success || !response.queryResults || response.queryResults.length === 0) {
					if (callback) {
						callback(ctiSettings);
					}
					return;
				}
				var queryResults = response.queryResults;
				var msgLibRows = queryResults[0].rows;
				this.setMsgLibSettings(msgLibRows, ctiSettings);
				if (queryResults.length > 1) {
					var msgUserSettingsRows = queryResults[1].rows;
					this.setMsgUserSettings(msgUserSettingsRows, ctiSettings);
				}
				if (callback) {
					callback(ctiSettings);
				}
			}, this);
		},

		/**
		 * ########### ########### ######## ## #########.
		 * @private
		 * @param {Object} ctiSettings ######### #########.
		 * @param {String[]} ctiSettings.licOperations ######## ############## ########## #########.
		 * @param {Function} callback ####### ######### ######.
		 * @param {Boolean} callback.canUseCti true, #### ######## ########, ##### - false.
		 */
		queryCtiLicenses: function(ctiSettings, callback) {
			if (ctiSettings.isInitialized) {
				callback(ctiSettings);
				return;
			}
			var licOperations = ctiSettings.licOperations || [];
			this.GetUserHasOperationLicense({
				operations: licOperations,
				isAnyOperation: false
			}, function(canUseCti) {
				ctiSettings.canUseCti = canUseCti;
				if (!canUseCti) {
					this.logWarning(Ext.String.format(CtiConstants.LocalizableStrings.LicenseNotFoundMessage,
						licOperations));
				}
				callback(ctiSettings);
			}, this);
		},

		/**
		 * ########## ###### ## ####### ######### ########## #########.
		 * @private
		 * @param {String} sysMsgLibId ############# ########## ###### ###########.
		 * @return {BPMSoft.EntitySchemaQuery} ###### ## ####### ######### ########## #########.
		 */
		getMsgLibSelect: function(sysMsgLibId) {
			var select = Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: "SysMsgLib"
			});
			select.addColumn("SetupPageSchemaName");
			select.addColumn("LicOperations");
			select.addColumn("CtiProviderName");
			select.filters.add("idFilter", BPMSoft.createColumnFilterWithParameter(
				BPMSoft.ComparisonType.EQUAL, "Id", sysMsgLibId));
			return select;
		},

		/**
		 * ########## # ######### cti ######### ########## #########.
		 * @private
		 * @param {Object[]} msgLibRows ###### ####### ######## ########## #########.
		 * @param {Object} ctiSettings cti #########.
		 */
		setMsgLibSettings: function(msgLibRows, ctiSettings) {
			if (!msgLibRows || (msgLibRows.length === 0)) {
				return;
			}
			var msgLib = msgLibRows[0];
			ctiSettings.setupPageSchemaName = msgLib.SetupPageSchemaName;
			var licOperations = msgLib.LicOperations;
			if (licOperations && Ext.isString(licOperations)) {
				ctiSettings.licOperations = licOperations.split(";");
			}
			ctiSettings.ctiProviderName = msgLib.CtiProviderName;
		},

		/**
		 * ########## ###### ## ####### ########## ######### ######## ############.
		 * @private
		 * @param {String} sysMsgLibId ############# ########## ###### ###########.
		 * @return {BPMSoft.EntitySchemaQuery} ###### ## ####### ########## ######### ######## ############.
		 */
		getMsgUserSettingsSelect: function(sysMsgLibId) {
			var select = Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: "SysMsgUserSettings"
			});
			select.addColumn("ConnectionParams");
			select.filters.add("userFilter", BPMSoft.createColumnFilterWithParameter(
				BPMSoft.ComparisonType.EQUAL, "User", BPMSoft.SysValue.CURRENT_USER.value));
			select.filters.add("libFilter", BPMSoft.createColumnFilterWithParameter(
				BPMSoft.ComparisonType.EQUAL, "SysMsgLib", sysMsgLibId));
			return select;
		},

		/**
		 * ########## # ######### cti ######### ########### ############ # #########.
		 * @private
		 * @param {Object[]} msgUserSettingsRows ###### ####### ########## ########### ############ # #########.
		 * @param {Object} ctiSettings ######### #########.
		 */
		setMsgUserSettings: function(msgUserSettingsRows, ctiSettings) {
			if (!msgUserSettingsRows || (msgUserSettingsRows.length === 0)) {
				if (!ctiSettings.setupPageSchemaName) {
					ctiSettings.connectionParams = {};
					return;
				}
				this.log(CtiConstants.LocalizableStrings.ConnectionConfigEmptyMessage);
				return;
			}
			var msgUserSettings = msgUserSettingsRows[0];
			var connectionParams = msgUserSettings.ConnectionParams;
			if (connectionParams) {
				try {
					ctiSettings.connectionParams = BPMSoft.decode(connectionParams);
				} catch (e) {
					this.error(e);
				}
			}
			if (!ctiSettings.connectionParams) {
				this.error(CtiConstants.LocalizableStrings.ConnectionConfigIncorrectMessage);
			}
		},

		/**
		 * Calls CtiRightsService web-method.
		 * @private
		 * @param {String} methodName Method name.
		 * @param {Function} callback Callback function.
		 * @param {Object} data Method data.
		 */
		callServiceMethod: function(methodName, callback, data) {
			BPMSoft.AjaxProvider.request({
				url: BPMSoft.workspaceBaseUrl + "/rest/CtiRightsService/" + methodName,
				headers: {
					"Accept": "application/json",
					"Content-Type": "application/json"
				},
				method: "POST",
				jsonData: data || {},
				callback: function(request, success, response) {
					var responseObject = {};
					if (success) {
						var obj = BPMSoft.decode(response.responseText);
						responseObject = obj[methodName + "Result"];
					}
					callback.call(this, responseObject);
				},
				scope: this
			});
		},

		//endregion

		//region Methods: Public

		/**
		 * ########### ######### #########.
		 * @param {Function} callback ####### ######### ######. # ######## ######### ########## ######### #########.
		 */
		queryCtiSettings: function(callback) {
			var ctiSettings = BPMSoft.SysValue.CTI;
			if (ctiSettings && ctiSettings.isInitialized) {
				callback(ctiSettings);
				return;
			}
			this.initCtiSettings(callback);
		},

		/**
		 * ######### ############# ########### # #########.
		 * #######:
		 * #### ########### ######## ## #########.
		 * # ####### ############ ######## ########## # ##########
		 * @param {Function} callback ####### ######### ######.
		 * @param {Boolean} callback.isEnabled true, #### ########### # ######### #########. ##### - false.
		 */
		GetIsTelephonyEnabled: function(callback) {
			this.queryCtiSettings(function(ctiSettings) {
				if (Ext.isEmpty(ctiSettings.sysMsgLibId) || Ext.isEmpty(ctiSettings.ctiProviderName) ||
						Ext.isEmpty(ctiSettings.connectionParams)) {
					callback(false);
					return;
				}
				var isTelephonyEnabled = ctiSettings.canUseCti && !ctiSettings.connectionParams.disableCallCentre;
				callback(isTelephonyEnabled);
			});
		},

		/**
		 * Check user has license operation.
		 * @param {Object} data License request data.
		 * @param {String[]} data.operations Operation names.
		 * @param {Boolean} data.isAnyOperation If true, methods check any user has any operation of given. Otherwise -
		 * all of operations should exist.
		 * @param {Function} callback Callback function.
		 * @param {Boolean} callback.isExist If true, user has given operations. Otherwise - false.
		 * @param {Object} [scope] Callback function scope.
		 */
		GetUserHasOperationLicense: function(data, callback, scope) {
			var storage = BPMSoft.configuration.Storage;
			var key = data.operations.join("-");
			var licStore = storage.UserOperationLicense = storage.UserOperationLicense || [];
			if (licStore[key]) {
				callback.call(scope || this, licStore[key]);
			} else {
				var handler = function(response) {
					licStore[key] = response;
					callback.call(scope || this, licStore[key]);
				};
				this.callServiceMethod("GetUserHasOperationLicense", handler, data);
			}
		},

		/**
		 * ########## ######### # ##### ######### - ######### # ###### ### ##### ############# ######.
		 * @param {Object} config ######## ######## ### ######### ##### #############.
		 * @return {Object} ############ ##### #############.
		 */
		getIdentificationDataLabel: function(config) {
			var tag = Ext.isEmpty(config.tag) ? config.name : config.tag;
			var visibleBindTo = Ext.isEmpty(config.visible) ? {"bindTo": "getIsInfoLabelVisible"} : config.visible;
			var captionBindTo = Ext.isEmpty(config.caption)
				? {bindTo: "Resources.Strings." + tag + "LabelCaption"}
				: config.caption;
			var valueBindTo = Ext.isEmpty(config.value)
				? {"bindTo": "getSubscriberData"}
				: config.value;
			var controlConfig = {
				className: "BPMSoft.Container",
				id: config.name + "Info",
				selectors: {wrapEl: "#" + config.name + "Info"},
				markerValue: config.name + "Info",
				visible: visibleBindTo,
				tag: tag,
				items: [
					{
						id: config.name + "Label",
						className: "BPMSoft.Label",
						markerValue: captionBindTo,
						selectors: {wrapEl: "#" + config.name + "Label"},
						classes: {labelClass: "label-caption"},
						caption: captionBindTo
					},
					{
						id: config.name,
						className: "BPMSoft.Label",
						markerValue: valueBindTo,
						selectors: {wrapEl: "#" + config.name},
						classes: {labelClass: "subscriber-info"},
						caption: valueBindTo,
						tag: tag
					}
				]
			};
			return controlConfig;
		},

		/**
		 * ########## ############ ###### ######### #########.
		 * @param {String} stateCode ### c######## #########.
		 * @param {Boolean} isSmallIcon (optional) ##### ########### ######.
		 * @return {Object} ############ ###########.
		 * @deprecated
		 */
		getOperatorStatusIcon: function(stateCode, isSmallIcon) {
			if (Ext.isEmpty(stateCode)) {
				return null;
			}
			stateCode = stateCode.toUpperCase();
			var imageCode;
			switch (stateCode) {
				case "READY":
				case "ACTIVE":
				case "AVAILABLE":
				case "ONHOOK":
					imageCode = (isSmallIcon) ? "ReadyStatusIcon" : "ReadyStatusProfileMenuItemIcon";
					break;
				case "AWAY":
				case "ONBREAK":
				case "DND":
					imageCode = (isSmallIcon) ? "AwayStatusIcon" : "AwayStatusProfileMenuItemIcon";
					break;
				default:
					imageCode = (isSmallIcon) ? "BusyStatusIcon" : "BusyStatusProfileMenuItemIcon";
					break;
			}
			return resources.localizableImages[imageCode];
		},

		/**
		 * ########## ######### # ######## ### DTMF ###### # ######## # ########## #########.
		 * @param {Object} config ######## ######## ### ######### ##########.
		 * @param {String} config.name ######## ##########.
		 * @param {Object|Boolean} config.visible ###### # ############# ### ######## ######## ######### ##########
		 * ### ########## ######## ######### ##########.
		 * @param {Object} config.onButtonClick ###### # ############# ### ######## ########### ####### ## ###### DTMF
		 * ######.
		 * @param {Object|String} config.dtmfDigitsLabel ###### # ############# ### ######## ######## ####### #
		 * ########## ######### ### ###### # ########## #########.
		 * @return {Object} config ############ ########## # ######## ### DTMF ###### # ######## # ##########
		 * #########.
		 */
		getDtmfButtonsContainer: function(config) {
			var buttonCaptions = ["1", "2", "3", "4", "5", "6", "7", "8", "9", "*", "0", "#"];
			var buttonCaptionsAliases = {
				"*": "Star",
				"#": "Hashtag"
			};
			var containerConfig = {
				id: config.name,
				className: "BPMSoft.Container",
				selectors: {wrapEl: "#" + config.name},
				markerValue: config.name,
				classes: {wrapClassName: ["dtmf-buttons-container"]},
				visible: config.visible,
				items: []
			};
			buttonCaptions.forEach(function(caption) {
				var captionAlias = buttonCaptionsAliases[caption];
				var suffix = captionAlias ? captionAlias : caption;
				var buttonName = "DtmfButton" + suffix;
				var buttonConfig = {
					id: buttonName,
					className: "BPMSoft.Button",
					markerValue: buttonName,
					selectors: {wrapEl: "#" + buttonName},
					caption: caption,
					tag: caption,
					click: config.onButtonClick
				};
				containerConfig.items.push(buttonConfig);
			});
			var dtmfDigitsLabelConfig = {
				id: "DtmfDigitsLabel",
				className: "BPMSoft.Label",
				selectors: {wrapEl: "#DtmfDigitsLabel"},
				classes: {labelClass: "dtmf-digits-label"},
				caption: config.dtmfDigitsLabel,
				markerValue: config.dtmfDigitsLabel
			};
			containerConfig.items.push(dtmfDigitsLabelConfig);
			return containerConfig;
		}

		//endregion

	});
	return BPMSoft.configuration.CtiBaseHelper;
});
