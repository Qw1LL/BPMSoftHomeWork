﻿define("SocialChannelPageV2", ["BusinessRuleModule", "SocialChannelPageV2Resources", "ImageCustomGeneratorV2", "css!SocialFeedUtilities"],
		function(BusinessRuleModule, resources) {
			return {
				entitySchemaName: "SocialChannel",
				details: /**SCHEMA_DETAILS*/{
					Subscribers: {
						schemaName: "SubscribersDetailV2",
						filter: {
							masterColumn: "Id",
							detailColumn: "EntityId"
						}
					}
				}/**SCHEMA_DETAILS*/,
				messages: {
					"CanSubscribe": {
						mode: this.BPMSoft.MessageMode.PTP,
						direction: this.BPMSoft.MessageDirectionType.PUBLISH
					},
					"GetRecordInfo": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},
					/**
					 * @message GetMasterRecordEntitySchemaUId
					 * ########## ############# ########.
					 */
					"GetMasterRecordEntitySchemaUId": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},
					/**
					 * @message UpdateIsSubscribed
					 * ######### ######## "IsSubscribed" - ######### ###### "###########" / "##########"
					 */
					"UpdateIsSubscribed": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},
					/**
					 * @message ChannelSaved
					 * ######### ######### # ########## ######.
					 */
					"ChannelSaved": {
						mode: this.BPMSoft.MessageMode.BROADCAST,
						direction: this.BPMSoft.MessageDirectionType.PUBLISH
					}
				},
				methods: {

					/**
					 * ########## ############# ###### ####### #####.
					 * @return {String} ############# ###### ####### #####.
					 */
					getESNFeedSectionSandboxId: function() {
						return "SectionModuleV2_ESNFeedSectionV2_CardModuleV2";
					},

					/**
					 * inheritDoc BPMSoft.BasePageV2#onSaved
					 * @overridden
					 */
					onSaved: function() {
						var model = this.Ext.create("BPMSoft.BaseViewModel", {
							values: {
								isNew: this.isNewMode(),
								PublisherRightKind: this.get("PublisherRightKind"),
								value: this.get(this.entitySchema.primaryColumnName),
								displayValue: this.get(this.entitySchema.primaryDisplayColumnName),
								primaryImageValue: this.get(this.entitySchema.primaryImageColumnName)
							}
						});
						this.sandbox.publish("ChannelSaved", model);
						this.callParent(arguments);
					},

					/**
					 * ########## ######### ######## ######## ### ######## "###########/##########".
					 * @protected
					 * @virtual
					 * @return {BPMSoft.BaseViewModelCollection} ########## ######### ######## ########.
					 */
					getActions: function() {
						var actionMenuItems = this.callParent(arguments);
						if (actionMenuItems.getCount() > 0) {
							var subscribeActions = actionMenuItems.filter(function(item) {
								return item.get("Tag") === "unsubscribeUser" || item.get("Tag") === "subscribeUser";
							});
							if (subscribeActions.getCount() > 0) {
								var subscribeActionsKeys = subscribeActions.getKeys();
								BPMSoft.each(subscribeActionsKeys, function(key) {
									actionMenuItems.removeByKey(key);
								}, this);
							}
						}
						return actionMenuItems;
					},

					/**
					 * ######### ###### "##########".
					 */
					updateSubscribersDetail: function() {
						this.updateDetail({detail: "Subscribers"});
					},

					/**
					 * ######### ######### ####.
					 * @param {Object} image ###### ###########.
					 */
					onImageChange: function(image) {
						var callbackSuccess = function(imageId) {
							var imageData = {
								value: imageId,
								displayValue: "Image"
							};
							this.set(this.primaryImageColumnName, imageData);
						};
						var callbackError = function(imageId, error, xhr) {
							if (xhr.response) {
								var response = BPMSoft.decode(xhr.response);
								if (response.error) {
									BPMSoft.showMessage(response.error);
								}
							}
						};
						var data = {
							onComplete: callbackSuccess,
							onError: callbackError,
							scope: this
						};
						if (image) {
							data.file = image;
							this.BPMSoft.ImageApi.upload(data);
						} else {
							this.set(this.primaryImageColumnName, null);
						}
					},

					/**
					 * ##### ######### ###### ## ###########.
					 * @return {*}
					 */
					getSrcMethod: function() {
						var primaryImageColumnValue = this.get(this.primaryImageColumnName);
						if (primaryImageColumnValue) {
							return this.getSchemaImageUrl(primaryImageColumnValue);
						}
						return this.getDefaultImageURL();
					},

					/**
					 * Returns default image url.
					 * @return {String} Default image url.
					 */
					getDefaultImageURL: function() {
						return this.BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.DefaultImage);
					},

					/**
					 *
					 * @return {boolean}
					 */
					beforeFileSelected: function() {
						return true;
					},

					/**

					 */
					setCurrentDate: function() {
						var creationDate = new Date();
						this.set("Date", creationDate);
					},

					/**
					 * #####, ############# ##### ############# #######.
					 * @overridden
					 */
					onEntityInitialized: function() {
						this.getIsSubscribed();
						this.setCurrentDate();
						this.callParent(arguments);
					},

					/**
					 * @inheritdoc BPMSoft.BaseModulePageV2#getOwnerColumnName
					 * @overridden
					 */
					getOwnerColumnName: function() {
						return this.entitySchema.columns.CreatedBy.name;
					},

					/**
					 * @inheritdoc BPMSoft.BasePageV2#subscribeDetailsEvents
					 * @overridden
					 */
					subscribeDetailsEvents: function() {
						this.callParent(arguments);
						var detailId = this.getDetailId("Subscribers");
						this.sandbox.subscribe("GetMasterRecordEntitySchemaUId", function() {
							return this.entitySchema.uId;
						}, this, [detailId]);
						this.sandbox.subscribe("UpdateIsSubscribed", function() {
							this.getIsSubscribed();
						}, this, [detailId]);
					}
				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "insert",
						"name": "PropertiesTab",
						"parentName": "Tabs",
						"propertyName": "tabs",
						"values": {
							"caption": {"bindTo": "Resources.Strings.PropertiesTabCaption"},
							"items": []
						}
					},
					{
						"operation": "merge",
						"name": "SaveButton",
						"values": {
							"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
						}
					},
					{
						"operation": "merge",
						"name": "DiscardChangesButton",
						"values": {
							"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT_ORANGE,
						}
					},
					{
						"operation": "merge",
						"name": "CloseButton",
						"values": {
							"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
						}
					},
					{
						"operation": "merge",
						"name": "actions",
						"values": {
							"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT_ORANGE,
						}
					},
					{
						"operation": "insert",
						"parentName": "Header",
						"propertyName": "items",
						"name": "ImageContainer",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"wrapClass": ["image-edit-container"],
							"layout": {"column": 0, "row": 0, "rowSpan": 4, "colSpan": 3},
							"items": []
						}
					},
					{
						"operation": "insert",
						"parentName": "ImageContainer",
						"propertyName": "items",
						"name": "Image",
						"values": {
							"getSrcMethod": "getSrcMethod",
							"onPhotoChange": "onImageChange",
							"beforeFileSelected": "beforeFileSelected",
							"readonly": false,
							"defaultImage": {"bindTo": "getDefaultImageURL"},
							"layout": {"column": 0, "row": 0, "rowSpan": 2, "colSpan": 2},
							"generator": "ImageCustomGeneratorV2.generateCustomImageControl"
						}
					},
					{
						"operation": "insert",
						"parentName": "Header",
						"propertyName": "items",
						"name": "Title",
						"values": {
							"bindTo": "Title",
							"layout": {
								"column": 2,
								"row": 0,
								"colSpan": 22
							},
							"controlConfig": {
								"placeholder": {
									"bindTo": "Resources.Strings.TitlePlaceholder"
								}
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "Header",
						"propertyName": "items",
						"name": "Description",
						"values": {
							"bindTo": "Description",
							"layout": {
								"column": 2,
								"row": 1,
								"colSpan": 22,
								"rowSpan": 0
							},
							"controlConfig": {
								"placeholder": {
									"bindTo": "Resources.Strings.DescriptionPlaceholder"
								}
							},
							"contentType": this.BPMSoft.ContentType.LONG_TEXT
						}
					},
					{
						"operation": "insert",
						"parentName": "PropertiesTab",
						"name": "SocialChannelPagePropertiesTabContainer",
						"propertyName": "items",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.CONTAINER,
							"items": []
						}
					},
					{
						"operation": "insert",
						"parentName": "PropertiesTab",
						"propertyName": "items",
						"name": "Subscribers",
						"values": {
							"itemType": BPMSoft.ViewItemType.DETAIL
						}
					},
					{
						"operation": "insert",
						"parentName": "SocialChannelPagePropertiesTabContainer",
						"propertyName": "items",
						"name": "SocialChannelPagePropertiesTabContentGroup",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.CONTROL_GROUP,
							"items": []
						}
					},
					{
						"operation": "insert",
						"parentName": "SocialChannelPagePropertiesTabContentGroup",
						"propertyName": "items",
						"name": "SocialChannelPagePropertiesBlock",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": []
						}
					},
					{
						"operation": "insert",
						"parentName": "ESNTab",
						"name": "SocialChannelPageESNTabContainer",
						"propertyName": "items",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.CONTAINER,
							"items": []
						}
					},
					{
						"operation": "insert",
						"parentName": "SocialChannelPageESNTabContainer",
						"propertyName": "items",
						"name": "SocialChannelPageESNTabContentGroup",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.CONTROL_GROUP,
							"items": []
						}
					},
					{
						"operation": "insert",
						"parentName": "SocialChannelPageESNTabContentGroup",
						"propertyName": "items",
						"name": "SocialChannelPageESNBlock",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": []
						}
					},
					{
						"operation": "insert",
						"parentName": "SocialChannelPagePropertiesBlock",
						"propertyName": "items",
						"name": "ColorAndLabelContainer",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.CONTAINER,
							"visible": true,
							"layout": {"column": 0, "row": 0, "colSpan": 5},
							"wrapClass": ["control-width-15"],
							"items": []
						}
					},
					{
						"operation": "insert",
						"name": "ColorLabelContainer",
						"parentName": "ColorAndLabelContainer",
						"propertyName": "items",
						"values": {
							"generateId": false,
							"itemType": this.BPMSoft.ViewItemType.CONTAINER,
							"visible": true,
							"items": [],
							"wrapClass": ["label-wrap"]
						}
					},
					{
						"operation": "insert",
						"parentName": "ColorLabelContainer",
						"name": "ColorLabel",
						"propertyName": "items",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.LABEL,
							"caption": {"bindTo": "Resources.Strings.ColorCaption"},
							"classes": {"labelClass": ["colorButtonLabel"]}
						}
					},
					{
						"operation": "insert",
						"name": "ColorContainer",
						"parentName": "ColorAndLabelContainer",
						"propertyName": "items",
						"values": {
							"generateId": false,
							"itemType": this.BPMSoft.ViewItemType.CONTAINER,
							"visible": true,
							"items": [],
							"wrapClass": ["control-wrap color-button"]
						}
					},
					{
						"operation": "insert",
						"parentName": "ColorContainer",
						"propertyName": "items",
						"name": "Color",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.COLOR_BUTTON,
							"value": {"bindTo": "Color"},
							"defaultValue": "#7299F8",
							"classes": {
								"wrapClasses": ["esn-color-picker-button"]
							},
							"menuItemClassName": BPMSoft.MenuItemType.COLOR_PICKER
						}
					},
					{
						"operation": "insert",
						"parentName": "SocialChannelPagePropertiesBlock",
						"propertyName": "items",
						"name": "CreatedBy",
						"values": {
							"layout": {"column": 0, "row": 1, "colSpan": 9},
							"controlConfig": {
								"enabled": false
							},
							"caption": {
								"bindTo": "Resources.Strings.CreatedByCaption"
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "SocialChannelPagePropertiesBlock",
						"propertyName": "items",
						"name": "CreatedOn",
						"values": {
							"layout": {"column": 0, "row": 2, "colSpan": 9},
							"controlConfig": {
								"enabled": false
							},
							"caption": {
								"bindTo": "Resources.Strings.CreatedOnCaption"
							}
						}
					},
					{
						"operation": "insert",
						"index": 2,
						"parentName": "LeftContainer",
						"propertyName": "items",
						"name": "SubscribeChannelButton",
						"values": {
							"caption": {"bindTo": "getChangeUserSubscriptionCaption"},
							"enabled": {"bindTo": "getChangeUserSubscriptionIsEnabled"},
							"tag": "changeUserSubscription",
							"itemType": this.BPMSoft.ViewItemType.BUTTON,
							"click": {"bindTo": "onCardAction"},
							"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
							"classes": {
								"textClass": ["actions-button-margin-right"]
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "SocialChannelPagePropertiesBlock",
						"name": "PublisherRightKindLabel",
						"propertyName": "items",
						"values": {
							"caption": {
								"bindTo": "Resources.Strings.PublisherRightKindCaption"
							},
							"itemType": this.BPMSoft.ViewItemType.LABEL,
							"layout": {"column": 0, "row": 3, "colSpan": 10}
						}
					},
					{
						"operation": "insert",
						"parentName": "SocialChannelPagePropertiesBlock",
						"name": "PublisherRightKind",
						"propertyName": "items",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.RADIO_GROUP,
							"value": {
								"bindTo": "PublisherRightKind"
							},
							"items": [],
							"layout": {"column": 0, "row": 4, "colSpan": 14}
						}
					},
					{
						"operation": "insert",
						"parentName": "PublisherRightKind",
						"propertyName": "items",
						"name": "AllUsersPublisherRights",
						"values": {
							"caption": {
								"bindTo": "Resources.Strings.AllUsersPublisherRightsCaption"
							},
							"value": true
						}
					},
					{
						"operation": "insert",
						"parentName": "PublisherRightKind",
						"propertyName": "items",
						"name": "EditorsPublisherRights",
						"values": {
							"caption": {
								"bindTo": "Resources.Strings.EditorsPublisherRightsCaption"
							},
							"value": false
						}
					}
				]/**SCHEMA_DIFF*/
			};
		});
