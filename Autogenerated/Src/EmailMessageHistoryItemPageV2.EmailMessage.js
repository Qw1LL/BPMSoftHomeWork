define("EmailMessageHistoryItemPageV2", ["EmailMessageHistoryItemPageV2Resources", "EmailHelper", "ConfigurationConstants",
		"css!EmailMessageHistoryItemStyleV2"],
	function(resources, EmailHelper, ConfigurationConstants) {
		return {
			entitySchemaName: "BaseMessageHistory",
			details: /**SCHEMA_DETAILS*/{
				"EmailFiles": {
					"schemaName": "HistoryMessageFilesDetail",
					"entitySchemaName": "ActivityFile",
					"filter": {
						"masterColumn": "RecordId",
						"detailColumn": "Activity"
					},
					"additionalFileFilters": [{
						"filterColumnName": "Inline",
						"comparisonType": this.BPMSoft.ComparisonType.EQUAL,
						"filterColumnValue": 0
					}]
				}
			}/**SCHEMA_DETAILS*/,
			attributes: {
				/**
				 * Total count of recepients in To and Cc fields.
				 * @type {Integer}
				 */
				"TotalRecipientsCount": {
					"dataValueType": BPMSoft.DataValueType.INTEGER,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": 0
				},

				/**
				 * Count of recepients in Cc fields.
				 * @type {Integer}
				 */
				"CopyRecipientsCount": {
					"dataValueType": BPMSoft.DataValueType.INTEGER,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": 0
				}
			},
			messages: {
			},
			methods: {
				/**
				 * @inheritdoc BPMSoft.BasePageV2#init
				 * @override
				 */
				init: function() {
					this.callParent(arguments);
					this.subscribeDetailsEvents();
					this._setupRecipientsCount();
				},

				/**
				 * @inheritdoc BPMSoft.BaseMessageHistoryPage#getHistoryMessageFilesContainer
				 * @override
				 */
				getHistoryMessageFilesContainer: function() {
					return this.Ext.String.format("EmailMessageHistoryItemPageV2EmailFilesContainer-" +
						"{0}-{1}", this.get("Id"), this.sandbox.id);
				},

				/**
				 * @inheritdoc BPMSoft.BaseMessageHistoryPage#getHistoryMessageFilesDetailId
				 * @override
				 */
				getHistoryMessageFilesDetailId: function() {
					return this.getDetailId("EmailFiles");
				},

				/**
				 * @inheritDoc BaseMessageHistoryItemPage#getChannelIcon
				 * @override
				 */
				getChannelIcon: function () {
					return this.BPMSoft.ImageUrlBuilder.getUrl(this.get("Resources.Images.EmailChannelIcon"));
				},

				/**
				 * Return email subject for page.
				 * @return {String} Subject.
				 */
				getSubject: function() {
					return this.get(this.$ConnectionColumnsPath + ".Title");
				},

				/**
				 * Creates email action parameters.
				 * @protected
				 * @return {object} Action parameters.
				 */
				getEmailActionParams: function(action) {
					const emailConfig = this.getModuleStructure("Activity");
					return {
						hash: emailConfig.cardModule + "/EmailPageV2/add/Type/" + ConfigurationConstants.Activity.Type.Email + "/" + action + "/" +
							this.get("RecordId")
					};
				},

				/**
				 * Execute actions for email.
				 */
				emailAction: function () {
					const params = this.getEmailActionParams(arguments[3]);
					this.sandbox.publish("PushHistoryState", params);
				},

				/**
				 * @inheritdoc BaseMessageHistoryItemPage#getOpacityMode
				 * @override
				 */
				getOpacityMode: function() {
					if (this.isDraftLabelVisible() || this.get(this.$ConnectionColumnsPath + ".IsAutoSubmitted") &&
							!this.get("IsMessageVisibleOnPortal")) {
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
					return true;
				},

				/**
				 * Get text for recipients hint.
				 * @return {string} Text for hint.
				 */
				getRecipientsHintContent: function() {
					var template = this.get("Resources.Strings.RecipientsHintTemplate");
					var hintText = this.Ext.String.format(template, this.get("Resources.Strings.RecepientCaption"),
						this._getEmailStringWithBreaks(this.get("[Activity:Id:RecordId].Recepient"), 100),
						this.get("Resources.Strings.CopyRecepientCaption"),
						this._getEmailStringWithBreaks(this.get("[Activity:Id:RecordId].CopyRecepient"), 100));
					return hintText;
				},

				/**
				 * ShowHideRecipientsButton click handler.
				 */
				onShowHideRecipientsButtonClick: function() {
					this.$IsExpandableContainerVisible = !this.$IsExpandableContainerVisible;
				},

				/**
				 * Gets visibility of show button.
				 * @return {Boolean} Button visibility.
				 */
				isShowRecipientsButtonVisible: function() {
					return !this.$IsExpandableContainerVisible;
				},

				/**
				 * Gets caption of details button.
				 * @return {String} Caption.
				 */
				getShowRecipientsButtonCaption: function() {
					const counter = this.$TotalRecipientsCount > 1
						? Ext.String.format("({0}) ", this.$TotalRecipientsCount) : "";
					return counter + this.get("Resources.Strings.DetailsCaption");
				},

				/**
				 * Return true if argument is greater than zero.
				 * @param {Number} value Value to check.
				 */
				isGreaterThanZeroConverter: function(value) {
					return value > 0;
				},

				_getEmailStringWithBreaks: function(source, symbolsCountPerLine) {
					var lines = source.replace(/\s*;\s*/g, "; ")
						.match(new RegExp(".{1," + symbolsCountPerLine + "}(; |$)", "g"));
					return lines && lines.join("<br/>    ") || source;
				},

				/**
				 * Get recipients count from recipients string.
				 * @param {String} emails Recipients string.
				 * @return {Number} Recipients count.
				 * @private
				 */
				_getEmailRecipientsCount: function(emails) {
					let addresses = this._getEmailAddresses(emails) || [];
					addresses = addresses.filter(function distinct(value, index, self) {
						return self.indexOf(value) === index;
					});
					return addresses.length;
				},

				/**
				 * Fill recipients count attribute from email.
				 * @private
				 */
				_setupRecipientsCount: function() {
					this.$CopyRecipientsCount = this._getEmailRecipientsCount(
						this.get("[Activity:Id:RecordId].CopyRecepient"));
					this.$TotalRecipientsCount = this.$CopyRecipientsCount + this._getEmailRecipientsCount(
						this.get("[Activity:Id:RecordId].Recepient"));
				},

				/**
				 * Apply colon character to value.
				 * @param {String} value Value to apply.
				 * @private
				 */
				_decorateColonConverter: function(value) {
					return this.Ext.String.format("{0}: ", value);
				},

				/**
				 * Parse string to fetch email addresses.
				 * @param {String} emailsString Source string.
				 * @return {Array} Result array of emails.
				 * @private
				 */
				_getEmailAddresses: function(emailsString) {
					const emailRegexp = EmailHelper.sysSettingsEmailPattern || EmailHelper.emailPattern;
					const matches = emailsString.match(new RegExp(emailRegexp, "g"));
					return matches;
				},

				/**
				 * Extract email address from string and wrap it into parentheses.
				 * @param {String} value Input value to parse.
				 * @return {String} Wrapped email address.
				 * @private
				 */
				_extractSenderAddressConverter: function(value) {
					const emailRegexp = EmailHelper.sysSettingsEmailPattern || EmailHelper.emailPattern;
					const address = new RegExp(emailRegexp).exec(value);
					return address ? this.Ext.String.format("({0})", address) : "";
				},

				/**
				 * Opens email page.
				 */
				openEmailFromHistory: function() {
					const schemaName = "EmailPageV2";
					const primaryColumnValue = this.get("RecordId");
					const hash = this.BPMSoft.combinePath("CardModuleV2", schemaName, "edit", primaryColumnValue);
					this.sandbox.publish("PushHistoryState", {hash: hash});
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "remove",
					"name": "HistoryV1Container"
				},
				{
					"operation": "merge",
					"name": "HistoryV2EmailRecepient",
					"values": {
						"caption": {
							"bindTo": "[Activity:Id:RecordId].Recepient"
						},
						"hint": {"bindTo": "getRecipientsHintContent"}
					}
				},
				{
					"operation": "insert",
					"name": "HistoryV2ToExpandable",
					"parentName": "HistoryV2MessageHeaderExpandableContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [
							{
								"name": "HistoryV2EmailToLabel",
								"itemType": BPMSoft.ViewItemType.LABEL,
								"caption": {
									"bindTo": "Resources.Strings.RecepientCaption",
									"bindConfig": {
										"converter": "_decorateColonConverter"
									}
								},
								"classes": {
									"labelClass": ["text-bold"]
								}
							},
							{
								"name": "HistoryV2EmailToValue",
								"itemType": BPMSoft.ViewItemType.LABEL,
								"caption": {
									"bindTo": "[Activity:Id:RecordId].Recepient"
								}
							}
						]
					},
					"index": 0
				},
				{
					"operation": "insert",
					"name": "HistoryV2CcExpandable",
					"parentName": "HistoryV2MessageHeaderExpandableContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"visible": {
							"bindTo": "CopyRecipientsCount",
							"bindConfig": {
								"converter": "isGreaterThanZeroConverter"
							}
						},
						"items": [
							{
								"name": "HistoryV2EmailCcLabel",
								"itemType": BPMSoft.ViewItemType.LABEL,
								"caption": {
									"bindTo": "Resources.Strings.CopyRecepientCaption",
									"bindConfig": {
										"converter": "_decorateColonConverter"
									}
								},
								"classes": {
									"labelClass": ["text-bold"]
								}
							},
							{
								"name": "HistoryV2EmailCcValue",
								"itemType": BPMSoft.ViewItemType.LABEL,
								"caption": {
									"bindTo": "[Activity:Id:RecordId].CopyRecepient"
								}
							}
						]
					},
					"index": 1
				},
				{
					"operation": "merge",
					"name": "HistoryV2CreatedByLink",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.HYPERLINK,
						"href": {
							"bindTo": "getCreatedByUrl"
						},
						"target": this.BPMSoft.controls.HyperlinkEnums.target.SELF
					}
				},
				{
					"operation": "insert",
					"name": "AddressLine",
					"parentName": "HeaderCenterContainerTopLine",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"wrapClass": ["overflow-hidden"]
					},
					"index": 0
				},
				{
					"operation": "move",
					"name": "HistoryV2CreatedByLink",
					"parentName": "AddressLine",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "move",
					"name": "HistoryV2EmailRecepientInfo",
					"parentName": "AddressLine",
					"propertyName": "items",
					"index": 2
				},
				{
					"operation": "merge",
					"name": "HistoryV2EmailRecepientInfo",
					"parentName": "HeaderCenterContainerTopLine",
					"propertyName": "items",
					"values": {
						"visible": {
							"bindTo": "isShowRecipientsButtonVisible"
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "HeaderCenterContainerTopLine",
					"propertyName": "items",
					"name": "HistoryV2MessageHeaderActions",
					"index": 3,
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["message-header-actions"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ShowRecipientsButton",
					"parentName": "HistoryV2MessageHeaderActions",
					"propertyName": "items",
					"values": {
						"id": "ShowRecipientsButton",
						"itemType": BPMSoft.ViewItemType.LABEL,
						"selectors": {"wrapEl": "#ShowHideRecipientsButton"},
						"classes": {
							"labelClass": ["clickable-label"]
						},
						"caption": {"bindTo": "getShowRecipientsButtonCaption"},
						"click": {"bindTo": "onShowHideRecipientsButtonClick"},
						"visible": {
							"bindTo": "isShowRecipientsButtonVisible"
						}
					},
					"index": 0
				},
				{
					"operation": "insert",
					"name": "HideRecipientsButton",
					"parentName": "HistoryV2MessageHeaderActions",
					"propertyName": "items",
					"values": {
						"id": "HideRecipientsButton",
						"itemType": BPMSoft.ViewItemType.LABEL,
						"selectors": {"wrapEl": "#ShowHideRecipientsButton"},
						"classes": {
							"labelClass": ["clickable-label"]
						},
						"caption": {"bindTo": "Resources.Strings.HideCaption"},
						"click": {"bindTo": "onShowHideRecipientsButtonClick"},
						"visible": {
							"bindTo": "IsExpandableContainerVisible"
						}
					},
					"index": 1
				},
				{
					"operation": "insert",
					"name": "HistoryV2EmailLinkImage",
					"parentName": "HistoryV2MessageHeaderActions",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"imageConfig": {"bindTo": "Resources.Images.GoToEmailPage"},
						"classes": {
							"wrapperClass": ["email-link-image-wrap"],
							"imageClass": ["email-link-image"]
						},
						"click": {"bindTo": "openEmailFromHistory"},
						"markerValue": {
							"bindTo": "getEmailLinkImageMarker"
						},
					},
					"index": 2
				},
				{
					"operation": "merge",
					"name": "EmailAction",
					"parentName": "HistoryV2MessageHeaderActions",
					"propertyName": "items",
					"values": {
						"id": "EmailAction",
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"imageConfig": {
							"bindTo": "isCloudVisible",
							"bindConfig": {
								"converter": "getActionsButtonImage"
							}
						},
						"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"items": [],
						"markerValue": {
							"bindTo": "getActionsButtonMarkerValue"
						},
						"visible": {
							"bindTo": "isHistoryActionVisible"
						},
						"controlConfig": {
							"menu": {
								"items": {"bindTo": "EmailActionsMenuCollection"}
							}
						},
						"classes": {
							"wrapperClass": ["email-message-actions-button-wrapper"],
							"menuClass": ["email-message-actions-button-menu"]
						}
					},
					"index": 6
				},
				{
					"operation": "move",
					"name": "EmailAction",
					"parentName": "HistoryV2MessageHeaderActions",
					"propertyName": "items",
					"index": 5
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
									"bindTo": "[Activity:Id:RecordId].Body",
									"bindConfig": {"converter": "prepareMessage"}
								},
								"showLinks": true,
								"isHtmlBody": true,
								"selectedTextChanged": {"bindTo": "onSelectedTextChanged"},
								"selectedTextHandlerButtonClick": {"bindTo": "onSelectedTextButtonClick"},
								"showFloatButton": {"bindTo": "CreateCaseFromHistoryFeatureState"},
								"changeOpacity": {"bindTo": "getOpacityMode"},
								"frameBodyStyle": {
									"overflow": "hidden",
									"margin": 0,
									"font-family": "Calibri",
									"font-size": "15px",
									"lineHeight": "18px",
									"color": "#444444"
								},
								"visible": {
									"bindTo": "[Activity:Id:RecordId].Body",
									"bindConfig": {
										"converter": "isMessageTextNotEmptyConverter"
									}
								}
							};
						}
					},
					"index": 2
				},
				{
					"operation": "insert",
					"name": "HistoryV2DraftContentContainer",
					"parentName": "HistoryV2MessageContentContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["draft-content-container"],
						"items": [],
						"visible": {
							"bindTo": "isDraftLabelVisible"
						}
					},
					"index": 0
				},
				{
					"operation": "insert",
					"name": "HistoryV2DraftLabel",
					"parentName": "HistoryV2DraftContentContainer",
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
					"parentName": "HistoryV2DraftContentContainer",
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
					"operation": "insert",
					"name": "HistoryV2SenderAddress",
					"parentName": "AddressLine",
					"propertyName": "items",
					"values": {
						"id": "HistoryV2SenderAddress",
						"labelClass": ["email-sender-address"],
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "[Activity:Id:RecordId].Sender",
							"bindConfig": {
								"converter": "_extractSenderAddressConverter"
							}
						},
						"visible": {
							"bindTo": "IsExpandableContainerVisible"
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
						"tag": "Reply",
						"tips": []
					},
					"index": 0
				},
				{
					"operation": "insert",
					"parentName": "ReplyEmailAction",
					"propertyName": "tips",
					"name": "ReplyEmailActionTip",
					"values": {
						"content": {"bindTo": "Resources.Strings.ReplyEmailCaption"},
						"style": BPMSoft.TipStyle.WHITE,
						"behaviour": {
							"displayEvent": BPMSoft.TipDisplayEvent.HOVER
						},
						"tools": []
					}
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
						"tag": "ReplyAll",
						"tips": []
					},
					"index": 1
				},
				{
					"operation": "insert",
					"parentName": "ReplyToAllEmailAction",
					"propertyName": "tips",
					"name": "ReplyToAllEmailActionTip",
					"values": {
						"content": {"bindTo": "Resources.Strings.ReplyAllEmailCaption"},
						"style": BPMSoft.TipStyle.WHITE,
						"behaviour": {
							"displayEvent": BPMSoft.TipDisplayEvent.HOVER
						},
						"tools": []
					}
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
						"click": {"bindTo": "replyToAllWithTemplate"},
						"tips": []
					},
					"index": 2
				},
				{
					"operation": "insert",
					"parentName": "ReplyUsingTemplateEmailAction",
					"propertyName": "tips",
					"name": "ReplyUsingTemplateEmailActionTip",
					"values": {
						"content": {"bindTo": "Resources.Strings.ReplyUsingTemplateEmailCaption"},
						"style": BPMSoft.TipStyle.WHITE,
						"behaviour": {
							"displayEvent": BPMSoft.TipDisplayEvent.HOVER
						},
						"tools": []
					}
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
						"tag": "Forward",
						"tips": []
					},
					"index": 3
				},
				{
					"operation": "insert",
					"parentName": "ForwardEmailAction",
					"propertyName": "tips",
					"name": "ForwardEmailActionTip",
					"values": {
						"content": {"bindTo": "Resources.Strings.ForwardEmailCaption"},
						"style": BPMSoft.TipStyle.WHITE,
						"behaviour": {
							"displayEvent": BPMSoft.TipDisplayEvent.HOVER
						},
						"tools": []
					}
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
							"bindTo": "FilesDetailVisible"
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "HistoryV2FileDetailContainer",
					"propertyName": "items",
					"name": "EmailFiles",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL,
						"markerValue": "FileDetail"
					}
				},
				{
					"operation": "merge",
					"name": "HistoryV2CreatedByLink",
					"parentName": "HeaderCenterContainerTopLine",
					"propertyName": "items",
					"values": {
						"visible": {
							"bindTo": "IsSenderContact"
						}
					}
				},
				{
					"operation": "insert",
					"name": "CreatedByLinkText",
					"parentName": "HeaderCenterContainerTopLine",
					"propertyName": "items",
					"values": {
						"id": "CreatedByLinkText",
						"labelClass": ["emailSender"],
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "getCreatedByName"
						},
						"visible": {
							"bindTo": "IsSenderContact",
							"bindConfig": {"converter": "invertBooleanValue"}
						}
					},
					"index": 0
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
