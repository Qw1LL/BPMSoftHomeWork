define("PortalEmailMessageHistoryItemPageV2", ["PortalEmailMessageHistoryItemPageV2Resources", "PortalMessageConstants",
		"PortalEmailMessageMixin", "css!EmailMessageHistoryItemStyleV2"],
	function(resources, PortalMessageConstants) {
		return {
			entitySchemaName: "BaseMessageHistory",
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			messages: {
				/**
				 * @message HistoryMessageNotInitialized
				 */
				"HistoryMessageNotInitialized": {
					"mode": this.BPMSoft.MessageMode.BROADCAST,
					"direction": this.BPMSoft.MessageDirectionType.BIDIRECTIONAL
				}
			},
			attributes: {
				/**
				 * @inheritdoc BPMSoft.BaseEmailMessageHistoryPage#ConnectionColumnsPath
				 * @override
				 */
				"ConnectionColumnsPath": {
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"value": undefined
				},
				/**
				 * Recipients in portal email message.
				 */
				"EmailRecipients": {
					"dataValueType": this.BPMSoft.DataValueType.TEXT
				},
				/**
				 * Message type - incoming or outgoing.
				 */
				"MessageType": {
					"dataValueType": this.BPMSoft.DataValueType.TEXT
				},
				/**
				 * Email sender.
				 */
				"EmailSender": {
					"dataValueType": this.BPMSoft.DataValueType.TEXT
				},
				/**
				 * Indicates visibility of message history item.
				 */
				"IsMessageItemVisible": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"value": false
				}
			},
			properties: {
				/**
				 * Files preview button link template.
				 */
				hrefTplFormat: "<a href='" + BPMSoft.getConfigurationWebServiceBaseUrl() +
					"/rest/PortalFileService/GetActivityFile/{0}/{1}' vngrop='{2}'>{3}</a>"
			},
			mixins: {
				PortalEmailMessageMixin: "BPMSoft.PortalEmailMessageMixin"
			},
			methods: {
				/**
				 * @inheritDoc BPMSoft.BaseMessageHistoryPage#openCreatedByPage
				 * @override
				 */
				openCreatedByPage: this.BPMSoft.emptyFn,

				/**
				 * @inheritdoc BaseMessageHistoryItemPage#init
				 * @overridden
				 */
				init: function(callback) {
					this.callParent([function() {
						this.setPortalEmailMessageAttributes(callback);
					}, this]);
					this.replaceFileServiceWithPortalFileService();
				},

				/**
				 * Replace links to FileService with PortalFileService
				 * @protected
				 */
				replaceFileServiceWithPortalFileService: function() {
					var message = this.get("Message");
					var stringToReplace = this.Ext.String.format(
						PortalMessageConstants.SystemServicePath.systemServicePath,
						PortalMessageConstants.ActivityFileSchemaUid.activityFileSchemaUid);
					var replacementString = this.Ext.String.format(
						this._getPortalServicePath(), this.get("Id"));
					var processedMessage = message.replace(new RegExp(stringToReplace, 'gi'), replacementString);
					this.set("Message", processedMessage);
				},

				/**
				 * @private
				 */
				_getPortalServicePath: function() {
					if (this.getIsFeatureEnabled("EnableCustomPrefixRouteApi")) {
						return PortalMessageConstants.PortalServicePath.sspPrefixPortalServicePath;
					}
					return PortalMessageConstants.PortalServicePath.portalServicePath;
				},

				/**
				 * @inheritdoc BPMSoft.BaseEmailMessageHistoryPage#getNotifierGroup
				 * @override
				 */
				getNotifierGroup: function(esq) {
					return esq.createColumnIsNotNullFilter("Id");
				},

				/**
				 * @inheritdoc BaseMessageHistoryItemPage#getHistoryFiles
				 * @overridden
				 */
				getHistoryFiles: function(callback, scope) {
					var caseMessageHistoryId = this.get("Id");
					var config = {
						serviceName: "PortalFileService",
						methodName: "GetActivityFiles",
						scope: this,
						data: {
							caseMessageHistoryId: caseMessageHistoryId
						}
					};
					this.callService(config, function(result) {
						this.getActivityFilesCallback(result, callback, scope);
					}, this);
				},

				/**
				 * Filled collection received from callback getHistoryFiles
				 * @param {Object} result Result object with files collection.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function's scope.
				 * @protected
				 */
				getActivityFilesCallback: function(result, callback, scope) {
					if (result && result.GetActivityFilesResult) {
						var collection = result.GetActivityFilesResult.activityFiles;
						if (collection && collection.length > 0) {
							this.set("IsFilesAttached", true);
							var filesConfigs = [];
							this.BPMSoft.each(collection, function (item) {
								filesConfigs.push({
									Name: item.Name,
									Id: item.Id
								});
							}, this);
							callback.call(scope || this, filesConfigs);
						}
					}
				},

				/**
				 * @inheritdoc BaseMessageHistoryItemPage#getFileItemUrl
				 * @overridden
				 */
				getFileItemUrl: function (config) {
					return this.Ext.String.format(PortalMessageConstants.UrlPortalTemplate.FileUrlTemplate,
						this.get("Id"), config.Id, config.Name);
				},

				/**
				 * @inheritdoc BaseMessageHistoryItemPage#getImageFileItemUrl
				 * @overridden
				 */
				getImageFileItemUrl: function(config) {
					return this.Ext.String.format(this.hrefTplFormat,
						this.get("Id"), config.Id, this._getMessageFilesGroupId(), config.Name);
				},

				/**
				 * @inheritdoc BPMSoft.BaseEmailMessageHistoryPage#getHistoryMessageColumns
				 * @overridden
				 */
				getHistoryMessageColumns: function() {
					return ["Message"];
				},

				/**
				 * @inheritdoc BPMSoft.BaseEmailMessageHistoryPage#getChannelIcon
				 * @overridden
				 */
				getChannelIcon: function () {
					return BPMSoft.ImageUrlBuilder.getUrl(this.get("Resources.Images.EmailChannelIcon"));
				},

				/**
				 * @inheritdoc BPMSoft.BaseEmailMessageHistoryPage#getAuthorInitials
				 * @overridden
				 */
				getAuthorInitials: function() {
					const sender = this.$EmailSender || this.getCreatedByName();
					return this.generateContactInitials(sender);
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "remove",
					"name": "HistoryV1Container"
				},
				{
					"operation": "merge",
					"name": "HistoryV2Container",
					"propertyName": "items",
					"values": {
						"visible": {
							"bindTo": "IsMessageItemVisible"
						}
					}
				},
				{
					"operation": "merge",
					"name": "HistoryV2EmailRecepient",
					"values": {
						"caption": {
							"bindTo": "Resources.Strings.ToString"
						}
					}
				},
				{
					"operation": "merge",
					"name": "HistoryV2CreatedByLink",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "EmailSender"
						},
						"markerValue": "CreatedByLink"
					}
				},
				{
					"operation": "merge",
					"name": "HistoryV2MessageText",
					"values": {
						"generator": function() {
							return {
								"id": "MessageText",
								"markerValue": "MessageText",
								"className": "BPMSoft.MessageHistorySelectionHandler",
								"classes": {
									"multilineLabelClass": ["messageText"]
								},
								"caption": {
									"bindTo": "Message",
									"bindConfig": {"converter": "prepareMessage"}
								},
								"showLinks": true,
								"isHtmlBody": true,
								"showFloatButton": false,
								"frameBodyStyle": {
									"overflow": "hidden",
									"margin": 0,
									"font-family": "Calibri",
									"font-size": "15px",
									"lineHeight": "18px",
									"color": "#444444"
								}
							};
						}
					},
					"index": 2
				},
				{
					"operation": "insert",
					"name": "HistoryV2DraftLabel",
					"parentName": "HistoryV2MessageContentContainer",
					"propertyName": "items",
					"values": {
						"id": "DraftLabel",
						"labelClass": ["draft-label"],
						"markerValue": "DraftLabel",
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "Resources.Strings.DraftStringColon"
						},
						"visible": {
							"bindTo": "isDraftLabelVisible"
						}
					},
					"index": 0
				},
				{
					"operation": "insert",
					"name": "HistoryV2MessageSubject",
					"parentName": "HistoryV2MessageContentContainer",
					"propertyName": "items",
					"values": {
						"labelClass": ["email-subject"],
						"markerValue": "HistoryV2MessageSubject",
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "getSubject"
						},
						"visible": {
							"bindTo": "isDraftLabelVisible"
						}
					},
					"index": 1
				},
				{
					"operation": "merge",
					"name": "HistoryV2CreationInfo",
					"parentName": "HistoryV2MessageHeaderCenterContainer",
					"values": {
						"id": "CreationInfo",
						"labelClass": ["creationInfoLabel"],
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "getCreatedOn"
						}
					},
					"index": 1
				},
				{
					"operation": "insert",
					"name": "HistoryV2EmailActionsContainer",
					"parentName": "HistoryV2MessageHeaderRightContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["email-actions-container"],
						"items": []
					},
					"index": 0
				},
				{
					"operation": "insert",
					"name": "ReplyEmailAction",
					"parentName": "HistoryV2EmailActionsContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"imageConfig": {"bindTo": "Resources.Images.ReplyEmailActionIcon"},
						"classes": {"imageClass": ["email-action-button"]},
						"click": {"bindTo": "emailAction"},
						"tag": "Reply"
					},
					"index": 0
				},
				{
					"operation": "insert",
					"name": "ReplyToAllEmailAction",
					"parentName": "HistoryV2EmailActionsContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"imageConfig": {"bindTo": "Resources.Images.ReplyToAllEmailActionIcon"},
						"classes": {"imageClass": ["email-action-button"]},
						"click": {"bindTo": "emailAction"},
						"tag": "ReplyAll"
					},
					"index": 1
				},
				{
					"operation": "insert",
					"name": "ReplyUsingTemplateEmailAction",
					"parentName": "HistoryV2EmailActionsContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"imageConfig": {"bindTo": "Resources.Images.ReplyUsingTemplateEmailActionIcon"},
						"classes": {"imageClass": ["email-action-button"]},
						"click": {"bindTo": "replyToAllWithTemplate"}
					},
					"index": 2
				},
				{
					"operation": "insert",
					"name": "ForwardEmailAction",
					"parentName": "HistoryV2EmailActionsContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"imageConfig": {"bindTo": "Resources.Images.ForwardEmailActionIcon"},
						"classes": {"imageClass": ["email-action-button"]},
						"click": {"bindTo": "emailAction"},
						"tag": "Forward"
					},
					"index": 3
				},
				{
					"operation": "merge",
					"name": "HistoryV2MessageContentContainer",
					"parentName": "HistoryV2Container",
					"propertyName": "items",
					"values": {
						"afterrerender": {
							"bindTo": "applyVanillaLogic"
						},
						"afterrender": {
							"bindTo": "applyVanillaLogic"
						}
					}
				},
				{
					"operation": "insert",
					"name": "MessageFiles",
					"parentName": "HistoryV2MessageContentContainer",
					"propertyName": "items",
					"values": {
						"generator": function() {
							return {
								"id": "FilesText",
								"markerValue": "FilesText",
								"className": "BPMSoft.MultilineFileLabel",
								"classes": {
									"multilineLabelClass": ["inline-message-history-files"]
								},
								"caption": {
									"bindTo": "FilesText"
								},
								"filesCount": {
									"bindTo": "FilesCount"
								},
								"showLinks": true
							};
						}
					}
				},
				{
					"operation": "remove",
					"name": "HistoryV2FileDetailContainer"
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
