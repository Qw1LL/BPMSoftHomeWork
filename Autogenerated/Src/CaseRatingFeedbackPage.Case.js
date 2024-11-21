define("CaseRatingFeedbackPage", ["ImageView", "ESNHtmlEditModule",
		"CaseRatingFeedbackPageResources", "css!CaseRatingFeedbackPageCSS"],
	function() {
		return {
			profileKey: null,
			attributes: {
				"Comment": {
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				"Token": {
					"dataValueType": this.BPMSoft.DataValueType.GUID,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				"EnableQuestionToRequestor": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				"IsSuccessMessageVisible": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": false,
				}
			},
			diff:/**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "MainContainer",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"classes": {
							"wrapClassName": ["main-container"]
						},
						"items": []
					}
				},
				{
					"operation": "remove",
					"name": "LogoContainer",
					"parentName": "MainContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"classes": {
							"wrapClassName": ["logo-container container"]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ContentContainer",
					"parentName": "MainContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"classes": {
							"wrapClassName": ["content-container"]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ThanksMessageContainer",
					"parentName": "ContentContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"classes": {
							"wrapClassName": ["thanks-message-container container"]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "FeedbackContainer",
					"parentName": "ContentContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"classes": {
							"wrapClassName": ["feedback-container container"]
						},
						"visible": {
							"bindTo": "EnableQuestionToRequestor"
						},
						"items": []
					}
				},
				{
					"operation": "remove",
					"name": "LogoImageContainer",
					"parentName": "LogoContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"classes": {
							"wrapClassName": ["logo-image-container"]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "FeedBackButtonsContainer",
					"parentName": "ContentContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"classes": {
							"wrapClassName": ["feedBack-buttons-container"]
						},
						"items": []
					}
				},
				{
					"operation": "remove",
					"name": "Logo",
					"parentName": "LogoImageContainer",
					"propertyName": "items",
					"values": {
						"id": "logoImage",
						"itemType": this.BPMSoft.ViewItemType.COMPONENT,
						"className": "BPMSoft.ImageView",
						"imageSrc": {
							"bindTo": "getLogoUrl"
						},
						"classes": {
							"wrapClass": ["logo"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "MainContainer",
					"propertyName": "items",
					"name": "SuccessThanksMessage",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "Resources.Strings.ThanksMessage"
						},
						"labelConfig": {
							"classes": ["success-label"]
						},
						"visible": { "bindTo": "IsSuccessMessageVisible" }
					}
				},
				{
					"operation": "insert",
					"parentName": "ThanksMessageContainer",
					"propertyName": "items",
					"name": "ThanksLabel",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "Resources.Strings.ThanksMessage"
						},
						"labelConfig": {
							"classes": ["thanks"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "CommentTextEdit",
					"parentName": "FeedbackContainer",
					"propertyName": "items",
					"values": {
						"className": "BPMSoft.MemoEdit",
						"itemType": this.BPMSoft.ViewItemType.MODEL_ITEM,
						"dataValueType": this.BPMSoft.DataValueType.TEXT,
						"contentType": this.BPMSoft.ContentType.LONG_TEXT,
						"labelConfig": {
							"visible": false
						},
						"value": {
							"bindTo": "Comment"
						},
						"placeholder": {
							"bindTo": "Resources.Strings.AddCommentHint"
						},
						"markerValue": "comment-text-edit",
						"height": "80px"
					}
				},
				{
					"operation": "insert",
					"parentName": "FeedBackButtonsContainer",
					"propertyName": "items",
					"name": "PostButton",
					"values": {
						"click": {
							"bindTo": "postComment"
						},
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"style": this.BPMSoft.controls.ButtonEnums.style.ORANGE,
						"classes": {
							"textClass": "post-button"
						},
						"caption": {
							"bindTo": "Resources.Strings.PostButtonCaption"
						}
					}
				},
				{
					"operation": "remove",
					"name": "Background",
					"parentName": "MainGridLayout",
					"propertyName": "items",
					"values": {
						"id": "background",
						"itemType": this.BPMSoft.ViewItemType.COMPONENT,
						"className": "BPMSoft.ImageView",
						"imageSrc": {
							"bindTo": "getBackgroundUrl"
						},
						"classes": {
							"wrapClass": ["background"]
						}
					}
				}
			]/**SCHEMA_DIFF*/,
			methods: {

				/**
				 * @inheritDoc BaseSchemaViewModel#init
				 * @overridden
				 */
				init: function() {
					this.callParent(arguments);
					var feedbackConfig = this.BPMSoft.feedbackConfig;
					if (feedbackConfig) {
						this.set("Token", feedbackConfig.token);
						this.BPMSoft.feedbackConfig = null;
					}
					this.BPMSoft.chain(this.setInitialValues, this);
				},

				initializeProfile: function(callback, scope) {
					this.Ext.callback(callback, scope);
				},

				/**
				 * Sets initial values.
				 * @protected
				 * @virtual
				 */
				setInitialValues: function() {
					this.BPMSoft.SysSettings.querySysSettingsItem("EnableQuestionToRequestor",
						function(value) {
							this.set("EnableQuestionToRequestor", value);
						}, this);
				},

				/**
				 * Returns logo image URL.
				 * @private
				 * @return {String} Logo URL.
				 */
				getLogoUrl: function() {
					var config = {
						source: this.BPMSoft.ImageSources.SYS_SETTING,
						params: {
							r: "LogoImage"
						}
					};
					var url = this.BPMSoft.ImageUrlBuilder.getUrl(config);
					return url;
				},

				/**
				 * Removes feedback container from DOM.
				 * @private
				 */
				removeFeedback: function() {
					this.Ext.getCmp("CaseRatingFeedbackPageContentContainerContainer").destroy();
				},

				getSuccessPostMessageCaption: function () {
					return this.get('Resources.Strings.PostCommentSuccess');
				},

				/**
				 * Returns background image URL from resources.
				 * @protected
				 * @return {String} Background image URL.
				 */
				getBackgroundUrl: function() {
					var imageResource = this.get("Resources.Images.Background");
					var url = this.BPMSoft.ImageUrlBuilder.getUrl(imageResource);
					return url;
				},

				/**
				 * Prepares config for service call.
				 * @protected
				 * @param {String} comment Comment text.
				 * @return {Object} Service call config.
				 */
				getServiceConfig: function(comment) {
					var sendData = {
						token: this.get("Token"),
						comment: comment
					};
					var config = {
						serviceName: "CaseRatingManagementService",
						methodName: "AddComment",
						data: sendData
					};
					return config;
				},

				/**
				 * Logs out.
				 * @protected
				 */
				logout: function() {
					if (BPMSoft.feedbackConfig.doLogout === "true") {
						var config = {
							serviceName: "UserManagementService",
							methodName: "Logout"
						};
						this.callService(config, function () {
							window.logout = true;
						}, this);
					}
				},

				/**
				 * Post a comment via service.
				 * @protected
				 */
				postComment: function() {
					var comment = this.get("Comment");
					if (!comment || !comment.length) {
						var message = this.get("Resources.Strings.CommentIsEmpty");
						this.showConfirmationDialog(message, this.BPMSoft.emptyFn,
							[this.BPMSoft.MessageBoxButtons.OK]);
						return;
					}
					this.showBodyMask();
					var config = this.getServiceConfig(comment);
					this.callService(config, this.onCommentPost);
				},

				/**
				 * Post a comment callback function.
				 * Hides body mask and shows fail message upon it happens.
				 * @protected
				 * @virtual
				 * @param {Object} response Service response object.
				 */
				onCommentPost: function(response) {
					this.hideBodyMask();
					var result = response.AddCommentResult;
					if (result.success) {
						this.removeFeedback();
						this.$IsSuccessMessageVisible = true;
						this.logout();
					} else {
						this.$IsSuccessMessageVisible = false;
						var message = this.get("Resources.Strings.PostCommentFailed");
						this.showInformationDialog(message, this.BPMSoft.emptyFn);
					}
				}
			}
		};
	});
