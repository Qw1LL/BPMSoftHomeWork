define("PortalEmailMessageHistoryItemPage", ["ConfigurationConstants", "PortalMessageConstants",
		"PortalEmailMessageMixin", "PortalEmailMessageHistoryItemPageResources", "css!EmailMessageHistoryItemStyle"],
	function(ConfigurationConstants, PortalMessageConstants) {
		return {
			entitySchemaName: "BaseMessageHistory",
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
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
			messages: {},
			methods: {

				init: function(callback) {
					this.callParent([function() {
						this.setPortalEmailMessageAttributes(callback);
					}, this]);
				},

				/**
				 * @inheritDoc BPMSoft.BaseMessageHistoryPage#openCreatedByPage
				 * @override
				 */
				openCreatedByPage: this.BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseEmailMessageHistoryPage#getWrapContainerMarkerValue
				 * @override
				 */
				getWrapContainerMarkerValue: function() {
					var messageType = this.$MessageType;
					if (messageType === ConfigurationConstants.Activity.MessageType.Incoming) {
						return "OutgoingEmailHistoryMessageWrapContainer";
					} else {
						return "IncomingEmailHistoryMessageWrapContainer";
					}
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
				 * @override
				 */
				getHistoryMessageColumns: function() {
					return ["Message"];
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "HistoryV1Container",
					"propertyName": "items",
					"values": {
						"visible": {
							"bindTo": "IsMessageItemVisible"
						}
					}
				},
				{
					"operation": "merge",
					"name": "MessageText",
					"values": {
						"generator": function() {
							return {
								"id": "MessageText",
								"markerValue": "MessageText",
								"className": "BPMSoft.SelectionHandlerMultilineLabel",
								"classes": {
									"multilineLabelClass": ["messageText"]
								},
								"caption": {
									"bindTo": "Message",
									"bindConfig": {"converter": "prepareMessage"}
								},
								"showLinks": true,
								"isHtmlBody": true,
								"showFloatButton": false
							};
						}
					}
				},
				{
					"operation": "merge",
					"name": "CreatedByLink",
					"parentName": "MessageHeaderContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"classes": {
							"hyperlinkClass": ["link", "createdByLink", "label-url", "label-link"]
						},
						"caption": {
							"bindTo": "getCreatedByName"
						},
						"markerValue": "CreatedByLink"
					}
				},
				{
					"operation": "merge",
					"name": "CreatedByLabel",
					"parentName": "MessageHeaderContainer",
					"propertyName": "items",
					"values": {
						"id": "CreatedByLabel",
						"labelClass": ["createdByLink"],
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "getCreatedByName"
						},
						"markerValue": "CreatedByLabel"
					}
				},
				{
					"operation": "merge",
					"name": "EmailSenderLabel",
					"parentName": "EmailSenderWrapContainer",
					"propertyName": "items",
					"values": {
						"caption": {
							"bindTo": "Resources.Strings.FromString"
						}
					}
				},
				{
					"operation": "merge",
					"name": "EmailSender",
					"parentName": "EmailSenderWrapContainer",
					"propertyName": "items",
					"values": {
						"caption": {
							"bindTo": "EmailSender"
						}
					}
				},
				{
					"operation": "merge",
					"name": "EmailRecepientLabel",
					"parentName": "EmailRecepientWrapContainer",
					"propertyName": "items",
					"values": {
						"caption": {
							"bindTo": "Resources.Strings.ToString"
						}
					}
				},
				{
					"operation": "merge",
					"name": "EmailRecepient",
					"parentName": "EmailRecepientWrapContainer",
					"propertyName": "items",
					"values": {
						"caption": {
							"bindTo": "EmailRecipients"
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
