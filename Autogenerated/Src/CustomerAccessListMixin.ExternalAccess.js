define("CustomerAccessListMixin", ["CustomerAccessListMixinResources", "ModalBox", "RightUtilities",
			"SystemOperationsPermissionsMixin"], function(mixinResources, ModalBox, RightUtilities) {
		/**
		 * @class BPMSoft.configuration.mixins.CustomerAccessListMixin
		 * Mixin for receiving external access to customer's site.
		 *
		 * Messages should be registered at the host schema:
			"GetCustomerAccessLookupPageConfig": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			"HideCustomerAccessLookupPageModule": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		 */
		Ext.define("BPMSoft.configuration.mixins.CustomerAccessListMixin", {
			alternateClassName: "BPMSoft.CustomerAccessListMixin",

			mixins: {
				SystemOperationsPermissionsMixin: "BPMSoft.SystemOperationsPermissionsMixin"
			},
			/**
			 * @private
			 * @param {String} moduleId Lookup page module id.
			 * @param {Object} customerConfig Customer identification config.
			 * @param {string[]} customerConfig.customerIds Customer ids (CID).
			 * @param {string} customerConfig.clientId Customer's ClientId.
			 * @param {Function} callback Callback function will be called when lookup page box has been closed.
			 */
			_subscribeOnLookupPageMessages: function(moduleId, customerConfig, callback) {
				this.sandbox.subscribe("GetCustomerAccessLookupPageConfig", function() {
					return {
						operation: "refresh",
						customerConfig: customerConfig
					};
				}.bind(this), this, [moduleId]);
				this.sandbox.subscribe("HideCustomerAccessLookupPageModule", function(selectedAccessConfig) {
					callback(selectedAccessConfig);
					ModalBox.close();
				}, this, [moduleId]);
			},
			/**
			 * @private
			 * @param {String} accessId External access id.
			 * @param {Function} callback Callback function.
			 */
			_requestAccessToken: function(accessId, callback) {
				this.callService({
						serviceName: "TempAccessService",
						methodName: "GetAccessToken",
						data: {
							accessId: accessId
						}
					}, callback, this);
			},
			/**
			 * Logs data to ExternalAccessRequestLog.
			 * @private
			 * @param {Object} accessConfig External access config.
			 * @param {Function} callback Callback function.
			 */
			_logExternalAccessRequest: function(accessConfig, callback) {
				const insert = this.Ext.create("BPMSoft.InsertQuery", {
					rootSchemaName: "ExternalAccessRequestLog"
				});
				insert.setParameterValue("ExternalAccessId", accessConfig.Id, this.BPMSoft.DataValueType.GUID);
				insert.setParameterValue("ExternalAccessDescription", accessConfig.Description,
					this.BPMSoft.DataValueType.TEXT);
				insert.setParameterValue("CustomerId", accessConfig.CustomerId, this.BPMSoft.DataValueType.TEXT);
				insert.setParameterValue("Url", accessConfig.Url, this.BPMSoft.DataValueType.TEXT);
				insert.execute(callback);
			},
			/**
			 * Adds UI action to show access list.
			 * @protected
			 * @param {BPMSoft.Collection} actionMenuItems Collection of menu items.
			 */
			addCustomersAccessListMenuItem: function(actionMenuItems) {
				if (this.getIsFeatureEnabled("DisableExternalAccess") ||
						this.BPMSoft.CurrentUser.userType !== this.BPMSoft.UserType.GENERAL) {
					return;
				}
				actionMenuItems.add("GetRelatedCustomersAccessList", this.getButtonMenuItem({
					"Caption": mixinResources.localizableStrings.GetRelatedCustomersAccessList,
					"Tag": "getRelatedCustomersAccessList",
					"MarkerValue": "GetRelatedCustomersAccessList"}
				));
			},
			/**
			 * Returns customers to request access list.
			 * @protected
			 * @param {Object} customerConfig Customer identification config.
			 * @param {string[]} customerConfig.customerIds Customer ids (CID).
			 * @param {string} customerConfig.clientId Customer's ClientId.
			 */
			requestRelatedCustomersAccessListCallback: function(customerConfig) {
				if (!customerConfig ||
						(BPMSoft.isEmpty(customerConfig.customerIds) && BPMSoft.isEmpty(customerConfig.clientId))) {
					BPMSoft.showMessage(mixinResources.localizableStrings.NoCustomerIdsFound);
					return;
				}
				this.showLookupPage(customerConfig, function(accessConfig) {
					if (!accessConfig) {
						return;
					}
					this.redirectToExternalAccessLogin(accessConfig);
				}.bind(this));
			},
			/**
			 * Shows lookup page to select external access by customer.
			 * @protected
			 * @param {Object} customerConfig Customer identification config.
			 * @param {string[]} customerConfig.customerIds Customer ids (CID).
			 * @param {string} customerConfig.clientId Customer's ClientId.
			 * @param {Function} callback Callback function.
			 * @param {Object} [callback.accessConfig] Selected external access record.
			 */
			showLookupPage: function(customerConfig, callback) {
				const moduleId = this.sandbox.id + "CustomerAccessLookupPage";
				const modalBoxSelectorClass = "customer-access-page-modal-box";
				const modalBoxConfig = {
					heightPixels: 400,
					widthPixels: 800,
					boxClasses: [modalBoxSelectorClass]
				};
				const renderTo = ModalBox.show(modalBoxConfig, function() {
					this.sandbox.unloadModule(moduleId, renderTo);
				}, this);
				const maskId = BPMSoft.Mask.show({
					timeout: 10,
					selector: "." + modalBoxSelectorClass,
					clearMasks: true,
					showSpinner: true
				});
				this.sandbox.loadModule("BaseSchemaModuleV2", {
					id: moduleId,
					renderTo: renderTo.id,
					instanceConfig: {
						parameters: {
							viewModelConfig: {
								"MaskId": maskId
							}
						},
						schemaName: "CustomerAccessLookupPage",
						isSchemaConfigInitialized: true,
						useHistoryState: false
					}
				});
				this._subscribeOnLookupPageMessages(moduleId, customerConfig, callback);
			},
			/**
			 * Returns customer ids (CID) to request access list.
			 * @protected
			 * @virtual
			 * @param {Function} callback Function will be called to return results.
			 */
			getCustomerIds: function(callback) {
				callback.call(this, []);
			},
			/**
			 * Returns customer's ClientId to request access list.
			 * @protected
			 * @virtual
			 * @param {Function} callback Function will be called to return results.
			 */
			getClientId: function(callback) {
				callback.call(this, null);
			},
			/**
			 * Retrieves information about current customer and shows external accesses provided by one.
			 */
			getRelatedCustomersAccessList: function() {
				const operationCode = "CanUseExternalAccess";
				RightUtilities.checkCanExecuteOperations([operationCode], function(result) {
					if (result && result[operationCode]) {
						this.getCustomerIds(function(customerIds) {
							this.getClientId(function(clientId) {
								this.requestRelatedCustomersAccessListCallback({
									customerIds: customerIds,
									clientId: clientId
								});
							}.bind(this));
						}.bind(this));
					} else {
						this.showPermissionsErrorMessage(operationCode);
					}
				}, this);
			},
			/**
			 * Requests access token by the given external access config and redirects to grantor's OAuth login page.
			 * @param {Object} accessConfig External access config.
			 * @param {String} accessConfig.Id External access id.
			 * @param {String} accessConfig.Url External access url.
			 * @param {String} accessConfig.Description External access description.
			 * @param {String} accessConfig.CustomerId Customer identifier (CID).
			 */
			redirectToExternalAccessLogin: function(accessConfig) {
				const maskId = BPMSoft.Mask.show({
					timeout: 10
				});
				this._requestAccessToken(accessConfig.Id, function(response) {
					BPMSoft.Mask.hide(maskId);
					const accessToken = response.result;
					if (!accessToken) {
						const message = mixinResources.localizableStrings.AccessTokenRequestError;
						BPMSoft.showErrorMessage(message);
						return;
					}
					this._logExternalAccessRequest(accessConfig, function() {
						const redirectUrl = Ext.String.format("{0}/Login/ExternalAccessLogin.aspx#access_token={1}",
							accessConfig.Url, accessToken);
						const newTab = window.open(redirectUrl);
						newTab.focus();
					});
				});
			}
		});
	});
