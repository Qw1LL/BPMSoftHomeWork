define("SystemDesigner", ["RightUtilities"], function(RightUtilities) {
	return {
		attributes: {
			/**
			 * User has omnichannel license.
			 * @type {Boolean}
			 */
			"HasOmnichannelEditRights": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": false
			},

			/**
			 * User has omnichannel license operation.
			 * @type {Boolean}
			 */
			"HasOmnichannelLicOperation": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": false
			}
		},
		methods: {
			/**
			 * Open the chat settings window.
			 * @protected
			 */
			navigateToChatSettings: function() {
				const url = this.BPMSoft.workspaceBaseUrl + "/ClientApp/#/ChatSettings";
				window.open(url, "_blank");
			},

			/**
			 * @inheritdoc
			 * @overridden
			 */
			getOperationRightsDecoupling: function() {
				let operationRightsDecoupling = this.callParent(arguments);
				operationRightsDecoupling.navigateToChatSettings = "CanManageChats";
				return operationRightsDecoupling;
			},

			/**
			 * @return {Boolean} True if omnichannel messaging enabled.
			 */
			isOmnichannelMessagingEnabled: function () {
				return this.getIsFeatureEnabled("ShowOmniChatInCommPanel") && this.$HasOmnichannelEditRights;
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
			 * @overridden
			 */
			init: function() {
				this.callParent(arguments);
				this.checkOmnichannelEditRights();
			},

			/**
			 * Check license operation for using chats.
			 */
			checkOmnichannelLicOperation: function() {
				this.callService({
					serviceName: "CtiRightsService",
					methodName: "GetUserHasOperationLicense",
					data: {
						operations: ['Chats.Use'],
						isAnyOperation: false
					}
				}, function(result) {
					this.$HasOmnichannelLicOperation = result.GetUserHasOperationLicenseResult;
					if(this.$HasOmnichannelLicOperation) {
						this.checkOmnichannelEditRights();
					}
				}, this);
			},

			/**
			 * Check edit rights on chat object.
			 */
			checkOmnichannelEditRights: function() {
				RightUtilities.getSchemaEditRights({schemaName: "OmniChat"}, function(result) {
					this.$HasOmnichannelEditRights = this.Ext.isEmpty(result);
				},
				this);
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "IntegrationTile",
				"name": "ChatSettings",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.ChatSettingsCaption"},
					"tag": "navigateToChatSettings",
					"click": { "bindTo": "invokeOperation" },
					"visible": { "bindTo": "isOmnichannelMessagingEnabled" }
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
