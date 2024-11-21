// jscs:disable
/* jshint ignore:start */
function returnAccessTokens(accessToken, accessSecretToken, socialId, userId) {
	var SocialAccountAuthUtilities = require("SocialAccountAuthUtilities");
	SocialAccountAuthUtilities.createSocialAccount(accessToken, accessSecretToken, socialId, userId);
}

function returnAuthErrorMessage(message) {
	var SocialAccountAuthUtilities = require("SocialAccountAuthUtilities");
	if (message == null || message === "") {
		message = SocialAccountAuthUtilities.localizableStrings.SocialNetworkAuthError;
	}
	BPMSoft.showInformation(Ext.String.htmlDecode(message), function() {}, this);
}
// jscs:enable
/* jshint ignore:end */
define("SocialAccountAuthUtilities", ["SocialAccountAuthUtilitiesResources", "ConfigurationConstants", "AcademyUtilities"],
	function(resources, ConfigurationConstants, AcademyUtilities) {

		var socialNetworkName = "";
		var consumerKey = "";
		var afterAuthFunction;
		var localizableStrings = resources.localizableStrings;

		function getKeysSysSettingsValues(itemValues, socialNetwork) {
			consumerKey = itemValues[socialNetwork + "ConsumerKey"];
			var consumerSecret = itemValues[socialNetwork + "ConsumerSecret"];
			var notifySettingName = _getStopReturnUrlNotifySettingCode(socialNetwork);
			var stopShowReturnUriNotify = itemValues[notifySettingName];
			if (!Ext.isEmpty(consumerKey) && !Ext.isEmpty(consumerSecret)) {
				if (Ext.isEmpty(stopShowReturnUriNotify) || !stopShowReturnUriNotify) {
					_getSocialAccountCount(socialNetwork);
				} else {
					gotoOldOAuthAuthenticationUrl(socialNetwork);
				}
			} else {
				showFailedConnectionError(socialNetwork);
			}
		}

		function _getStopReturnUrlNotifySettingCode(socialNetwork) {
			return "StopReturnUrlNotify" + socialNetwork;
		}

		function _getSocialAccountCount(socialNetwork) {
			var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: "SocialAccount"
			});
			esq.addAggregationSchemaColumn("Id", BPMSoft.AggregationType.COUNT, "Count");
			esq.getEntityCollection(function(result) {
				if (!result.success) {
					return;
				}
				var item = result.collection.getByIndex(0);
				if (item.get("Count") > 0) {
					_showNewSettingsInformation(socialNetwork);
				} else {
					gotoOldOAuthAuthenticationUrl(socialNetwork);
				};
			}, this);
		}

		function _showNewSettingsInformation(socialNetwork) {
			BPMSoft.utils.showConfirmation(localizableStrings.NewReturnUrlNotify,
				function(returnCode) {
					if (returnCode === "Proceed") {
						gotoOldOAuthAuthenticationUrl(socialNetwork);
					}
					if (returnCode === "toAcademy") {
						var config = {
							contextHelpId: "1422",
							callback: function(url) {
								window.open(url, "_blank");
							}
						};
						AcademyUtilities.getUrl(config);
					}
				},
				[{
					caption: localizableStrings.ProceedBtn,
					className: "BPMSoft.Button",
					markerValue: "Proceed",
					returnCode: "Proceed",
					style: BPMSoft.controls.ButtonEnums.style.ORANGE
				}, {
					caption: localizableStrings.ToAcademyBtn,
					className: "BPMSoft.Button",
					markerValue: "toAcademy",
					returnCode: "toAcademy"
				}], this);
		}

		/**
		 * Checks application settings and opens old OAuth page.
		 * @private
		 * @param {Object} socialAccountOptions Social account options.
		 */
		function checkSettingsAndOpenWindow(socialAccountOptions) {
			var consumerKey = socialAccountOptions.consumerKey;
			var consumerSecret = socialAccountOptions.consumerSecret;
			var useSharedApplication = socialAccountOptions.useSharedApplication;
			var socialNetwork = socialAccountOptions.socialNetwork;
			var sandbox = socialAccountOptions.sandbox;
			var callAfter = socialAccountOptions.callAfter;
			if (useSharedApplication && socialNetwork === "Google") {
				checkSharedSettingsAndOpenWindow(socialNetwork, sandbox, callAfter);
				return true;
			} else if (consumerKey !== "" && consumerSecret !== "") {
				checkSysSettingsAndOpenWindow(socialNetwork, sandbox, callAfter);
				return true;
			}
			return false;
		}

		/**
		 * Checks application system settings and opens old OAuth page.
		 * @private
		 * @param {String} socialNetwork Social network name.
		 * @param {Object} sandbox Sandbox.
		 * @param {Function} callAfter Callback function.
		 */
		function checkSysSettingsAndOpenWindow(socialNetwork, sandbox, callAfter) {
			if (callAfter) {
				afterAuthFunction = callAfter;
			}
			socialNetworkName = socialNetwork;
			var settingsProvider = BPMSoft.SysSettings;
			var notifySettingName = _getStopReturnUrlNotifySettingCode(socialNetwork);
			var arrayToQuery = [socialNetwork + "ConsumerKey", socialNetwork + "ConsumerSecret",
				notifySettingName];
			var funcCallBack = function(itemValues) {
				getKeysSysSettingsValues(itemValues, socialNetwork, sandbox);
			};
			settingsProvider.querySysSettings(arrayToQuery, funcCallBack);
		}

		/**
		 * Checks shared application settings and opens old OAuth page.
		 * @private
		 * @param {String} socialNetwork Social network name.
		 * @param {Object} sandbox Sandbox.
		 * @param {Function} callAfter Callback function.
		 */
		function checkSharedSettingsAndOpenWindow(socialNetwork, sandbox, callAfter) {
			if (callAfter) {
				afterAuthFunction = callAfter;
			}
			socialNetworkName = socialNetwork;
			var schemaName = socialNetwork + "ClientConnector";
			this.BPMSoft.require([schemaName], function() {
				var connectorClassName = "BPMSoft." + schemaName;
				var socialId = ConfigurationConstants.CommunicationTypes[socialNetwork];
				var userId = this.BPMSoft.SysValue.CURRENT_USER.value;
				var connector = this.Ext.create(connectorClassName, {
					type: socialId,
					user: userId
				});
				connector.doRequest(function(response) {
					if (response.success && response.consumerInfo) {
						var responseInfo = response.consumerInfo;
						var consumerInfo = {};
						consumerInfo[socialNetwork + "ConsumerKey"] = responseInfo.Key;
						consumerInfo[socialNetwork + "ConsumerSecret"] = responseInfo.Secret;
						var notifySettingName = _getStopReturnUrlNotifySettingCode(socialNetwork);
						var arrayToQuery = [notifySettingName];
						var funcCallBack = function(itemValues) {
							consumerInfo[notifySettingName] = itemValues[notifySettingName];
							getKeysSysSettingsValues(consumerInfo, socialNetwork, sandbox);
						};
						BPMSoft.SysSettings.querySysSettings(arrayToQuery, funcCallBack);
					} else {
						showFailedConnectionError(socialNetwork);
					}
				}.bind(this));
			}, this);
		}

		/**
		 * Shows unsuccessful connection error.
		 * @private
		 * @param {String} socialNetwork Social network name.
		 */
		function showFailedConnectionError(socialNetwork) {
			BPMSoft.showInformation(resources.localizableStrings.QueryAdministrator +
			socialNetwork, function() {}, this);
		}

		function gotoOldOAuthAuthenticationUrl(socialNetworkName, callAfter) {
			if (callAfter) {
				afterAuthFunction = callAfter;
			}
			var data = {
				socialNetworkName: socialNetworkName
			};
			var requestUrl = BPMSoft.workspaceBaseUrl +
				"/rest/SocialNetworksUtilitiesService/GetOldOAuthAuthenticationUrl";
			BPMSoft.AjaxProvider.request({
				url: requestUrl,
				headers: {
					"Accept": "application/json",
					"Content-Type": "application/json"
				},
				method: "POST",
				jsonData: data,
				success: function(response, opts) {
					var url = BPMSoft.decode(response.responseText);
					url += "&socialNetwork=" + opts.jsonData.socialNetworkName;
					window.open(url);
				},
				scope: this
			});
		}

		function createSocialAccount(accessToken, accessSecretToken, socialId, userId) {
			var data = {
				socialNetworkName: socialNetworkName,
				socialId: socialId,
				accessToken: accessToken,
				accessSecretToken: accessSecretToken,
				userId: userId
			};
			var requestUrl = BPMSoft.workspaceBaseUrl + "/rest/SocialNetworksUtilitiesService/GetSocialNetworkLogin";
			BPMSoft.AjaxProvider.request({
				url: requestUrl,
				headers: {
					"Accept": "application/json",
					"Content-Type": "application/json"
				},
				method: "POST",
				jsonData: data,
				success: function(response, opts) {
					var login = BPMSoft.decode(response.responseText);
					setSocialNetworkIdAndLogin(opts.jsonData, login, socialNetworkName);
				},
				failure: BPMSoft.emptyFn,
				scope: this
			});
		}

		function insertSocialAccount(data, login, socialNetworkId, isPublic, id, callback, scope) {
			var insert = Ext.create("BPMSoft.InsertQuery", {
				rootSchemaName: "SocialAccount"
			});
			insert.setParameterValue("Id", id, BPMSoft.DataValueType.GUID);
			insert.setParameterValue("User", data.userId, BPMSoft.DataValueType.GUID);
			insert.setParameterValue("Login", login, BPMSoft.DataValueType.TEXT);
			insert.setParameterValue("AccessToken", data.accessToken, BPMSoft.DataValueType.TEXT);
			insert.setParameterValue("AccessSecretToken", data.accessSecretToken, BPMSoft.DataValueType.TEXT);
			insert.setParameterValue("SocialId", data.socialId, BPMSoft.DataValueType.TEXT);
			insert.setParameterValue("Type", socialNetworkId, BPMSoft.DataValueType.GUID);
			insert.setParameterValue("ConsumerKey", consumerKey, BPMSoft.DataValueType.TEXT);
			insert.setParameterValue("Public", isPublic, BPMSoft.DataValueType.BOOLEAN);
			insert.execute(function(response) {
				if (!response.success) {
					return;
				}
				if (callback) {
					callback.call(scope || this);
				}
			}, this);
		}

		function getSocialNetworkIdBySocialNetworkName(socialNetworkName) {
			var socialNetworkId;
			switch (socialNetworkName.toLowerCase()) {
				case "facebook":
					socialNetworkId = ConfigurationConstants.CommunicationTypes.Facebook;
					break;
				case "twitter":
					socialNetworkId = ConfigurationConstants.CommunicationTypes.Twitter;
					break;
				default:
					socialNetworkId = ConfigurationConstants.CommunicationTypes.Google;
					break;
			}
			return socialNetworkId;
		}

		function setSocialNetworkIdAndLogin(data, login, socialNetworkName) {
			var socialNetworkId = getSocialNetworkIdBySocialNetworkName(socialNetworkName);
			var socialAccountId = BPMSoft.utils.generateGUID();
			insertSocialAccount(data, login, socialNetworkId, false, socialAccountId, function() {
				if (afterAuthFunction) {
					afterAuthFunction.call(this, data, login, socialNetworkId, socialAccountId);
				}
				deletExpiredSocialAccounts();
			}, this);
		}

		function deletExpiredSocialAccounts() {
			var deleteQuery = Ext.create("BPMSoft.DeleteQuery", {
				rootSchemaName: "SocialAccount"
			});
			deleteQuery.filters.add("UserIdFilter", deleteQuery.createColumnFilterWithParameter(
				BPMSoft.ComparisonType.EQUAL, "User", BPMSoft.SysValue.CURRENT_USER.value));
			deleteQuery.filters.add("IsExpiredFilter", deleteQuery.createColumnFilterWithParameter(
				BPMSoft.ComparisonType.EQUAL, "IsExpired", true));
			deleteQuery.execute(function() {}, this);
		}

		function renewConsumerKey(consumerkey) {
			consumerKey = consumerkey;
		}

		return {
			checkSettingsAndOpenWindow: function(socialAccountOptions) {
				return checkSettingsAndOpenWindow(socialAccountOptions);
			},
			checkSysSettingsAndOpenWindow: function(socialNetwork, sandbox, afterAuthFunction) {
				return checkSysSettingsAndOpenWindow(socialNetwork, sandbox, afterAuthFunction);
			},
			gotoOldOAuthAuthenticationUrl: function(socialNetworkName, callback) {
				return gotoOldOAuthAuthenticationUrl(socialNetworkName, callback);
			},
			createSocialAccount: function(accessToken, accessSecretToken, socialId, userId) {
				return createSocialAccount(accessToken, accessSecretToken, socialId, userId);
			},
			afterAuthFunction: afterAuthFunction,
			localizableStrings: localizableStrings,
			renewConsumerKey: function(consumerKey) {
				return renewConsumerKey(consumerKey);
			}
		};
	});
