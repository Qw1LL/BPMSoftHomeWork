define("OAuthAppUserDetail", [
	"ServiceOAuthAuthenticatorEndpointHelper", "OAuthAppUserDetailResources", "AcademyUtilities", "OAuth20Utilities"
], function() {
	return {
		entitySchemaName: "VwOAuthAppUser",
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		properties: {
			_academyUrl: null
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "remove",
				"name": "AddRecordButton"
			},
			{
				"operation": "insert",
				"name": "TooltipInfoButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": "$Resources.Strings.LoginActionCaption",
					"click": "$onLoginOAuthApp"
				},
				"parentName": "Detail",
				"propertyName": "tools",
				"index": 1
			}
		]/**SCHEMA_DIFF*/,
		messages: {
			"SaveRecord": {
				"mode": BPMSoft.MessageMode.PTP,
				"direction": BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		methods: {

			// region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.GridUtilitiesV2#addGridDataColumns
			 * @overridden
			 */
			addGridDataColumns: function(esq) {
				this.callParent(arguments);
				esq.addColumn("SysUser");
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#initToolsButtonMenu
			 * @overridden
			 */
			initToolsButtonMenu: function() {
				this.callParent(arguments);
				var toolsButtonMenu = this.get("ToolsButtonMenu");
				toolsButtonMenu.clear();
				toolsButtonMenu.addItem(this.getButtonMenuItem({
					Caption: {"bindTo": "Resources.Strings.DeleteMenuCaption"},
					Click: "$onRemoveOAuthAppUser",
					Enabled: "$isAnySelected"
				}));
			},

			// endregion

			// region Methods: Public

			/**
			 * Removes OAuth app user.
			 * @public
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			onRemoveOAuthAppUser: function(callback, scope) {
				const activeRow = this.getActiveRow();
				BPMSoft.ServiceOAuthAuthenticatorEndpointHelper.removeOAuthUser(
						activeRow.$SysUser.value,
						this.$MasterRecordId,
						function(success) {
							if (!success) {
								this.showInformationDialog(this.get("Resources.Strings.LoginCallbackFailed"));
							}
							this.reloadGridData();
							Ext.callback(callback, scope);
						}, this);
			},

			/**
			 * Makes request to OAuth login service and opens token retreive url.
			 * @public
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			onLoginOAuthApp: function(callback, scope) {
				BPMSoft.OAuth20Utilities.canLoginOAuthUser(
						BPMSoft.SysValue.CURRENT_USER.value,
						this.$MasterRecordId,
						function(canLogin) {
							if (canLogin) {
								this.sandbox.publish("SaveRecord", {
									isSilent: true,
									callback: function() {
										BPMSoft.ServiceOAuthAuthenticatorEndpointHelper.getAuthorizationGrantUrl(
												this.$MasterRecordId,
												function(success, url) {
													if (success) {
														if (url) {
															window.open(url);
														}
													} else {
														this.showInformationDialog(
															this.get("Resources.Strings.LoginCallbackFailed"));
													}
													Ext.callback(callback, scope);
												}, this);
									},
									callBaseSilentSavedActions: true,
									scope: this
								}, [this.sandbox.id]);
							} else {
								this.showInformationDialog(this.get("Resources.Strings.UserAlreadyAuthorized"));
								Ext.callback(callback, scope);
							}
						}, this);
			}

			// endregion

		}
	};
});
