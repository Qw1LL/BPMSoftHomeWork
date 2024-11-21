define("PortalMessageHistoryItemPageV2", [],
	function() {
		return {
			entitySchemaName: "BaseMessageHistory",
			messages: {

				/**
				* @message HideFileDetailContainer
				* Switch FileDetailContainer visibility into off mode.
				*/
				"HideFileDetailContainer": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},
			details: /**SCHEMA_DETAILS*/{
				"PortalFiles": {
					"schemaName": "PortalMessageFileDetail",
					"entitySchemaName": "PortalMessageFile",
					"filter": {
						"masterColumn": "RecordId",
						"detailColumn": "PortalMessage"
					}
				}
			}/**SCHEMA_DETAILS*/,
			attributes: {
				/**
				 * Flag indicates visibility of FileDetailContainer.
				 */
				"PortalMessageFileDetailVisible": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					value: true
				}
			},
			methods: {

				/**
				 * @inheritdoc BPMSoft.BasePageV2#init
				 * @override
				 */
				init: function() {
					this.callParent(arguments);
					this.subscribeDetailsEvents();
				},

				/**
				* @inheritdoc BPMSoft.BasePagev2#subscribeDetailsEvents
				* @override
				*/
				subscribeDetailsEvents: function() {
					this.callParent(arguments);
					const detailId = this.getHistoryMessageFilesDetailId();
					this.sandbox.subscribe("HideFileDetailContainer", function() {
						this.$PortalMessageFileDetailVisible = false;
					}, this, [detailId]);
				},

				/**
				 * @inheritdoc BPMSoft.BaseMessageHistoryPage#getChannelIcon
				 * @override
				 */
				getChannelIcon: function() {
					return this.BPMSoft.ImageUrlBuilder.getUrl(this.get("Resources.Images.PortalChannelIcon"));
				},

				/**
				 * @inheritdoc BPMSoft.BaseMessageHistoryPage#getHistoryMessageFilesContainer
				 * @override
				 */
				getHistoryMessageFilesContainer: function() {
					return this.Ext.String.format("PortalMessageHistoryItemPageV2PortalFilesContainer-" +
						"{0}-{1}", this.get("Id"), this.sandbox.id);
				},

				/**
				 * @inheritdoc BPMSoft.BaseMessageHistoryPage#getHistoryMessageFilesDetailId
				 * @override
				 */
				getHistoryMessageFilesDetailId: function() {
					return this.getDetailId("PortalFiles");
				},

				/**
				 * Return url of actual visibility icon link.
				 * @return {String} Url of current actual icon.
				 * @protected
				 */
				getVisibilityIcon: function() {
					return this.BPMSoft.ImageUrlBuilder.getUrl(this.get("Resources.Images." +
						(this.isHideOnPortalLabelVisible() ? "HideOnPortal" : "ShowOnPortal")
					));
				},

				/**
				 * @inheritdoc BaseMessageHistoryItemPage#getOpacityMode
				 * @override
				 */
				getOpacityMode: function() {
					if (this.get("HideOnPortalValue")) {
						return BPMSoft.controls.opacityMode.Translucent;
					} else {
						return BPMSoft.controls.opacityMode.Opaque;
					}
				},

				/**
				 * @inheritdoc BPMSoft.BaseMessageHistoryPage#isFileDetailContainerVisible
				 * @override
				 */
				isFileDetailContainerVisible: function () {
					return !this.get("IsSSP");
				},

				/**
				 * @inheritdoc BPMSoft.BaseMessageHistoryPage#setFilesVisibility
				 * @override
				 */
				setFilesVisibility: function () {
					this.callParent(arguments);
					if (BPMSoft.Features.getIsEnabled("SecurePortalMessageFileInHistory") && this.$FilesCount > 0) {
						this.$PortalMessageFileDetailVisible = !this.$PortalMessageFileDetailVisible;
					}
				},

				/**
				 * Returns value for visibility of HistoryV2FileDetailContainer
				 * @return {Boolean}
				 * @protected
				 */
				isFileDetailVisible: function() {
					return BPMSoft.Features.getIsEnabled("SecurePortalMessageFileInHistory") ?
						this.$PortalMessageFileDetailVisible : this.$FilesDetailVisible && this.$FilesCount > 0;
				},

				/**
				 * Message pre-processing.
				 * @protected
				 * @param value Bound message.
				 * @returns {String} Processed message.
				 */
				prepareMessage: function(message) {
					return this.validatePortalMessage(message);
				},

				/**
				 * Validates portal message content.
				 * @protected
				 * @param {String} message Source string.
				 * @return {String} Modified string.
				 */
				validatePortalMessage: function(message) {
					if (message && this.Ext.isString(message)) {
						const inlineEventsPattern = /(<\s*\w+[^>]*\b)(on\w+\s*=\s*\"[^"]*\")/gi;
						message = message.replace(inlineEventsPattern, "$1");
						message = this.validateMessage(message);
						message = message.replace(/<\s*script[^>]*>.*<\s*\/script\s*>/, "");
						return message;
					}
					return message;
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
					"values": {
						"markerValue": {
							"bindTo": "getWrapContainerMarkerValue"
						},
						"visible": {
							"bindTo": "HideOnPortalValue",
							"bindConfig": {
								converter: function(value) {
									return BPMSoft.isCurrentUserSsp() ? !value : true;
								}
							}
						}
					}
				},
				{
					"operation": "insert",
					"name": "HistoryV2CreatedByLink",
					"parentName": "HeaderCenterContainerTopLine",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.HYPERLINK,
						"classes": {
							"hyperlinkClass": ["createdByLink"]
						},
						"caption": {
							"bindTo": "getCreatedByName"
						},
						"href": {
							"bindTo": "getCreatedByUrl"
						},
						"markerValue": "CreatedByLink",
						"target": this.BPMSoft.controls.HyperlinkEnums.target.SELF,
						"visible": {
							"bindTo": "IsSSP",
							"bindConfig": {
								converter: function(value) {
									return !value;
								}
							}
						}
					},
					"index": 0
				},
				{
					"operation": "insert",
					"name": "HistoryV2CreatedByLabel",
					"parentName": "HeaderCenterContainerTopLine",
					"propertyName": "items",
					"values": {
						"id": "HistoryV2CreatedByLabel",
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "getCreatedByName"
						},
						"markerValue": "HistoryV2CreatedByLabel",
						"visible": {
							"bindTo": "IsSSP"
						}
					},
					"index": 4
				},
				{
					"operation": "merge",
					"name": "HistoryV2FileDetailContainer",
					"parentName": "HistoryV2MessageFooterContainer",
					"propertyName": "items",
					"values": {
						"afterrender": {"bindTo": "loadDetailModule"},
						"afterrerender": {"bindTo": "loadDetailModule"},
						"visible": {
							"bindTo": "isFileDetailVisible"
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "HistoryV2FileDetailContainer",
					"propertyName": "items",
					"name": "PortalFiles",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL,
						"markerValue": "FileDetail"
					}
				},
				{
					"operation": "insert",
					"name": "HistoryV2PortalMessageVisibilityContainer",
					"parentName": "HistoryV2MessageFooterContainer",
					"propertyName": "items",
					"values": {
						"id": "PortalMessageVisibilityContainer",
						"markerValue": "HistoryV2PortalMessageVisibilityContainer",
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["portalMessage-visibility-container"],
						"items": [],
						"visible": {
							"bindTo": "canManagePortalMessageVisibility"
						}
					},
					"index": 1
				},
				{
					"operation": "insert",
					"parentName": "HistoryV2PortalMessageVisibilityContainer",
					"propertyName": "items",
					"name": "VisibilityIcon",
					"values": {
						"getSrcMethod": "getVisibilityIcon",
						"readonly": true,
						"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
						"classes": {"wrapClass": ["visibilityIcon"]}
					},
					"index": 0
				},
				{
					"operation": "insert",
					"name": "HistoryV2OnPortalLabel",
					"parentName": "HistoryV2PortalMessageVisibilityContainer",
					"propertyName": "items",
					"values": {
						"id": "HideOnPortalLabel",
						"labelClass": ["portalMessageVisibilityLabel"],
						"markerValue": "HideOnPortalLabel",
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "Resources.Strings.HideOnPortalString"
						},
						"visible": {
							"bindTo": "isHideOnPortalLabelVisible"
						},
						"click": {
							"bindTo": "hideMessageOnPortal"
						}
					},
					"index": 1
				},
				{
					"operation": "insert",
					"name": "ShowOnPortalLabel",
					"parentName": "HistoryV2PortalMessageVisibilityContainer",
					"propertyName": "items",
					"values": {
						"id": "ShowOnPortalLabel",
						"labelClass": ["portalMessageVisibilityLabel"],
						"markerValue": "ShowOnPortalLabel",
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "Resources.Strings.ShowOnPortalString"
						},
						"visible": {
							"bindTo": "isShowOnPortalLabelVisible"
						},
						"click": {
							"bindTo": "showMessageOnPortal"
						}
					},
					"index": 2
				},
				{
					"operation": "insert",
					"name": "HistoryV2MessageType",
					"parentName": "HistoryV2MessageContentContainer",
					"propertyName": "items",
					"values": {
						"generator": function() {
							return {
								"id": "HistoryV2MessageType",
								"markerValue": "MessageType",
								"className": "BPMSoft.Label",
								"caption": {
									"bindTo": "getMessageTypeLabelText"
								},
								"visible": {
									"bindTo": "getMessageTypeIsVisible"
								}
							};
						}
					},
					"index": 0
				},
				{
					"operation": "merge",
					"name": "HistoryV2MessageText",
					"values": {
						"generator": function() {
							return {
								"id": "HistoryV2MessageText",
								"markerValue": "HistoryV2MessageText",
								"className": "BPMSoft.MessageHistorySelectionHandler",
								"classes": {
									"multilineLabelClass": ["messageText"]
								},
								"caption": {
									"bindTo": "Message",
									"bindConfig": {"converter": "prepareMessage"}
								},
								"showLinks": true,
								"selectedTextChanged": {"bindTo": "onSelectedTextChanged"},
								"selectedTextHandlerButtonClick": {"bindTo": "onSelectedTextButtonClick"},
								"showFloatButton": {"bindTo": "CreateCaseFromHistoryFeatureState"},
								"changeOpacity": {"bindTo": "getOpacityMode"}
							};
						}
					},
					"index": 1
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
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
