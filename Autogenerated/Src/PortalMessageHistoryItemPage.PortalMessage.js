define("PortalMessageHistoryItemPage", ["PortalMessageConstants", "PortalMessageMixin",
	"css!PortalMessageHistoryItemStyle"],
	function(PortalMessageConstants) {
		return {
			entitySchemaName: "BaseMessageHistory",
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			attributes: {
				/**
				 * SSP connection type flag.
				 */
				"IsSSP": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN
				},

				/**
				 * HideOnPortal value.
				 */
				"HideOnPortalValue": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"value": true
				},

				/**
				 * File attachment status.
				 */
				"IsFilesAttached": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * Portal message type.
				 */
				"Type": {
					"dataValueType": this.BPMSoft.DataValueType.CUSTOM_OBJECT
				},

				/**
				 * Flag, indicates direction of portal message.
				 */
				"IsFromPortal": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN
				}
			},
			mixins: {
				PortalMessageMixin: "BPMSoft.PortalMessageMixin"
			},
			methods: {

				/**
				 * @inheritdoc BasePageV2#init
				 * @overridden
				 */
				init: function() {
					this.callParent(arguments);
					var isSSP = BPMSoft.isCurrentUserSsp();
					this.set("IsSSP", isSSP);
					if (BPMSoft.Features.getIsEnabled("SecurePortalMessage") && isSSP) {
						this.setPortalMessageAttributes(this.initPortalMessageAttributes, this);
					} else {
						this.$HideOnPortalValue = this.get("[PortalMessage:Id:RecordId].HideOnPortal");
						this.$IsFromPortal = this.get("[PortalMessage:Id:RecordId].FromPortal");
					}
				},

				/**
				 * @protected
				 * @param {Object} response Response from portal message service.
				 */
				initPortalMessageAttributes: function(response) {
					if (response && response.GetPortalMessageAttributesResult) {
						const result = response.GetPortalMessageAttributesResult;
						var messageTypeValue = result.messageTypeCaption;
						this.$HideOnPortalValue = result.hideOnPortal;
						this.$IsFromPortal = result.fromPortal;
						if (result.messageType === PortalMessageConstants.PortalMessageType.Comment) {
							messageTypeValue = this.get("Resources.Strings.CommentMessageType");
						} else if (result.messageType === PortalMessageConstants.PortalMessageType.Complain) {
							messageTypeValue = this.get("Resources.Strings.ComplainMessageType");
						}
						this.$Type = {
							"value": result.messageType,
							"displayValue": messageTypeValue
						};
					}
				},

				/**
				 * @inheritDoc BPMSoft.BaseMessageHistoryPage#getHistoryFiles
				 * @overridden
				 */
				getHistoryFiles: function(callback, scope) {
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "PortalMessageFile"
					});
					esq.addColumn("Name");
					esq.addColumn("Id");
					esq.filters.addItem(esq.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
						"PortalMessage", this.get("RecordId")));
					esq.getEntityCollection(function(result) {
						var collection = result.collection;
						if (collection && collection.collection.length > 0) {
							this.set("IsFilesAttached", true);
							var filesConfigs = [];
							this.BPMSoft.each(collection.collection.items, function(item) {
								filesConfigs.push({
									Name: item.get("Name"),
									Id: item.get("Id"),
									SchemaUId: PortalMessageConstants.SysSchemaUId.PortalMessageFile
								});
							}, this);
							callback.call(scope || this, filesConfigs);
						}
					}, this);
				},

				/**
				 * Returns an image of the file attachment.
				 * @private
				 * @return {String} Image of the file attachment.
				 */
				getFileAttachmentsImage: function() {
					return this.BPMSoft.ImageUrlBuilder.getUrl(this.get("Resources.Images.FileAttachmentsImage"));
				},

				/**
				 * @inheritDoc BPMSoft.BaseMessageHistoryPage#historyMessageEsqApply
				 * @overridden
				 */
				historyMessageEsqApply: function(esq) {
					var isSSP = BPMSoft.isCurrentUserSsp();
					esq.addColumn("Message");
					if (!isSSP || BPMSoft.Features.getIsDisabled("SecurePortalMessage")) {
						var columns = ["[PortalMessage:Id:RecordId].FromPortal",
							"[PortalMessage:Id:RecordId].HideOnPortal"];
						this.BPMSoft.each(columns, function(column) {
							if (!esq.columns.collection.containsKey(column)) {
								esq.addColumn(column);
							}
						});
						esq.addColumn("[PortalMessage:Id:RecordId].Type", "Type");
						var filterGroup = esq.createFilterGroup();
						filterGroup.name = "PortalNotifierFilter";
						filterGroup.logicalOperation = this.BPMSoft.LogicalOperatorType.OR;
						var filterInnerGroup = esq.createFilterGroup();
						filterInnerGroup.name = "PortalNotifierInnerFilter";
						filterInnerGroup.logicalOperation = this.BPMSoft.LogicalOperatorType.AND;
						filterInnerGroup.add("PortalMessageExists",
							esq.createExistsFilter("[PortalMessage:Id:RecordId].Id"));
						if (isSSP) {
							filterInnerGroup.add("PortalMessageHideOnPortal", esq.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL,
								"[PortalMessage:Id:RecordId].HideOnPortal", false));
						}
						filterGroup.add(filterInnerGroup);
						filterGroup.add("NotPortalNotifier", esq.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.NOT_EQUAL, "MessageNotifier",
							PortalMessageConstants.MessageNotifier.Portal));
						esq.filters.addItem(filterGroup);
					}
				},

				/**
				 * @inheritdoc BPMSoft.BaseMessageHistoryPage#historyMessageEsqApply
				 * @overridden
				 */
				getCreatedByUrl: function() {
					if (this.get("IsSSP")) {
						return "";
					} else {
						return this.callParent(arguments);
					}
				},

				/**
				 * @inheritDoc BPMSoft.BaseMessageHistoryPage#openCreatedByPage
				 * @overridden
				 */
				openCreatedByPage: BPMSoft.emptyFn,

				/**
				 * Returns wrap container marker value.
				 * @private
				 * @return {String} Wrap container marker value.
				 */
				getWrapContainerMarkerValue: function() {
					var fromPortal = this.$IsFromPortal;
					var isSSP = this.get("IsSSP");
					if ((fromPortal && isSSP) || (!fromPortal && !isSSP)) {
						return "OutgoingPortalHistoryMessageWrapContainer";
					} else {
						return "IncomingPortalHistoryMessageWrapContainer";
					}
				},

				/**
				 * Checks rights for manage portal message visibility.
				 * @private
				 * @returns {Boolean} Can manage portal message visibility flag.
				 */
				canManagePortalMessageVisibility: function() {
					var fromPortal = this.$IsFromPortal;
					var isSSP = this.get("IsSSP");
					return !fromPortal && !isSSP;
				},

				/**
				 * Returns "Hide on portal" label visibility.
				 * @public
				 * @returns {Boolean} "Hide on portal" label visibility.
				 */
				isHideOnPortalLabelVisible: function() {
					return this.canManagePortalMessageVisibility() && !this.get("HideOnPortalValue");
				},

				/**
				 * Returns "Show on portal" label visibility.
				 * @public
				 * @returns {Boolean} "Show on portal" label visibility.
				 */
				isShowOnPortalLabelVisible: function() {
					return this.canManagePortalMessageVisibility() && this.get("HideOnPortalValue");
				},

				/**
				 * Hides message on portal.
				 * @public
				 */
				hideMessageOnPortal: function() {
					this._showPortalMessageButtonDialog(this.get("Resources.Strings.HideConfirmationMessage"), true);
				},

				/**
				 * Shows message on portal.
				 * @public
				 */
				showMessageOnPortal: function() {
					this._showPortalMessageButtonDialog(this.get("Resources.Strings.ShowConfirmationMessage"), false);
				},

				_showPortalMessageButtonDialog: function(message, state) {
					this.showConfirmationDialog(message,
						function(result) {
							if (result === this.BPMSoft.MessageBoxButtons.YES.returnCode) {
								this.updatePortalMessage(state);
							}
						},
					["yes", "no"]);
				},

				/**
				 * Updates portal message.
				 * @private
				 * @param {Object} value The new value for HideOnPortal.
				 */
				updatePortalMessage: function(value) {
					var update = Ext.create("BPMSoft.UpdateQuery", {
						rootSchemaName: "PortalMessage"
					});
					update.filters.add("PortalMessageIdFilter",
						update.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL, "Id", this.get("RecordId")));
					update.setParameterValue("HideOnPortal", value, this.BPMSoft.DataValueType.BOOLEAN);
					update.execute();
					this.set("HideOnPortalValue", value);
				},

				/**
				 * Returns a localizable caption for "Type" field.
				 * @returns {String}
				 */
				getMessageTypeLabelText: function() {
					if (this.get("Type")) {
						var typeCaption = this.get("Resources.Strings.TypeCaption");
						return this.Ext.String.format(typeCaption, this.get("Type").displayValue);
					}
				},

				/**
				 * Returns "Type" caption visibility.
				 * @returns {boolean}
				 */
				getMessageTypeIsVisible: function() {
					return	this.get("Type")
						? this.get("Type").value === PortalMessageConstants.PortalMessageType.Complain : false;
				},

				/**
				 * @inheritdoc BPMSoft.BaseMessageHistoryPage#getIsNeedToColor
				 * @override
				 */
				getIsNeedToColor: function() {
					const parentValue = this.callParent(arguments);
					return parentValue || (this.$HideOnPortalValue === true);
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "HistoryMessageWrapContainer",
					"values": {
						"wrapClass": ["historyMessageWrap", "historyPortalMessageWrap"],
						"markerValue": {
							"bindTo": "getWrapContainerMarkerValue"
						},
						"visible": {
							"bindTo": "HideOnPortalValue",
							"bindConfig": {
								converter: function(value) {
									return BPMSoft.isCurrentUserSsp() ? !value: true;
								}
							}
						}
					}
				},
				{
					"operation": "merge",
					"name": "MessageContentContainer",
					"values": {
						"wrapClass": ["messageContent", "speech-bubble"]
					}
				},
				{
					"operation": "merge",
					"name": "MessageFiles",
					"parentName": "MessageBodyContainer",
					"propertyName": "items",
					"values": {
						"generator": function() {
							return {
								"id": "FilesText",
								"markerValue": "FilesText",
								"className": "BPMSoft.MultilineFileLabel",
								"classes": {
									"multilineLabelClass": ["inlineEmailMessageHistoryFiles"]
								},
								"caption": {
									"bindTo": "FilesText"
								},
								"showReadMoreButton": false
							};
						}
					}
				},
				{
					"operation": "insert",
					"name": "CreatedByLink",
					"parentName": "MessageHeaderContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.HYPERLINK,
						"classes": {
							"hyperlinkClass": ["link", "createdByLink", "label-url", "label-link"]
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
					"index": 1
				},
				{
					"operation": "insert",
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
						"markerValue": "CreatedByLabel",
						"visible": {
							"bindTo": "IsSSP"
						}
					},
					"index": 2
				},
				{
					"operation": "insert",
					"name": "CreationInfo",
					"parentName": "MessageHeaderContainer",
					"propertyName": "items",
					"values": {
						"id": "CreationInfo",
						"labelClass": ["creationInfoLabel"],
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "getCreationInfo"
						}
					},
					"index": 3
				},
				{
					"operation": "insert",
					"name": "FileAttachmentsImage",
					"parentName": "MessageHeaderContainer",
					"propertyName": "items",
					"values": {
						"getSrcMethod": "getFileAttachmentsImage",
						"onPhotoChange": this.BPMSoft.emptyFn,
						"readonly": true,
						"classes": {
							"wrapClass": ["fileAttachmentsImage"]
						},
						"markerValue": "FileAttachmentsImage",
						"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
						"visible": {
							"bindTo": "IsFilesAttached"
						}
					},
					"index": 4
				},				{
					"operation": "insert",
					"name": "PortalMessageVisibilityContainer",
					"parentName": "MessageContentContainer",
					"propertyName": "items",
					"values": {
						"id": "PortalMessageVisibilityContainer",
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24,
							"rowSpan": 1
						},
						"markerValue": "PortalMessageVisibilityContainer",
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["portalMessageVisibilityContainer"],
						"items": []
					},
					"index": 3
				},
				{
					"operation": "insert",
					"name": "HideOnPortalLabel",
					"parentName": "PortalMessageVisibilityContainer",
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
					}
				},
				{
					"operation": "insert",
					"name": "ShowOnPortalLabel",
					"parentName": "PortalMessageVisibilityContainer",
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
					}
				},
				{
					"operation": "insert",
					"name": "MessageType",
					"parentName": "MessageBodyContainer",
					"propertyName": "items",
					"values": {
						"generator": function() {
							return {
								"id": "MessageType",
								"markerValue": "MessageType",
								"className": "BPMSoft.Label",
								"classes": {
									"multilineLabelClass": ["messageText"]
								},
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
					"operation": "insert",
					"name": "CommentLabelCaption",
					"parentName": "MessageBodyContainer",
					"propertyName": "items",
					"values": {
						"generator": function() {
							return {
								"id": "CommentLabelCaption",
								"className": "BPMSoft.Label",
								"classes": {
									"multilineLabelClass": ["messageText"]
								},
								"caption": {
									"bindTo": "Resources.Strings.CommentLabelCaption"
								},
								"visible": {
									"bindTo": "getMessageTypeIsVisible"
								}
							};
						}
					},
					"index": 1
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
