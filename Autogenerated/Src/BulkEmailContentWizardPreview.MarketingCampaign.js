define("BulkEmailContentWizardPreview", ["BulkEmailContentWizardPreviewResources",
		"DynamicContentReplicaBuilder", "ContainerListGenerator", "ContainerList", "MultilineLabel", "css!MultilineLabel",
		"PreviewReplicaViewModel", "ImageView", "css!BulkEmailContentWizardPreviewCSS"],
	function (resources, ReplicaBuilder) {
	return {
		messages: {
			/**
			 * @message BulkEmailContentBuilderAction
			 * Sends specific action to content builder.
			 */
			"BulkEmailContentBuilderAction": {
				"mode": this.BPMSoft.MessageMode.PTP,
				"direction": this.BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message GetContentBuilderConfig
			 * Gets content builder config.
			 */
			"GetContentBuilderConfig": {
				"mode": this.BPMSoft.MessageMode.PTP,
				"direction": this.BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message GetPreviewHtml
			 */
			"GetPreviewHtml": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message UpdatePreview
			 * Gets content builder config.
			 */
			"UpdatePreview": {
				"mode": this.BPMSoft.MessageMode.PTP,
				"direction": this.BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message UpdatePreview
			 * Gets content builder config.
			 */
			"UpdatePreviewWithRender": {
				"mode": this.BPMSoft.MessageMode.PTP,
				"direction": this.BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message UpdatePreview
			 * Gets content builder config.
			 */
			"UpdateHeaders": {
				"mode": this.BPMSoft.MessageMode.PTP,
				"direction": this.BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message BulkEmailContentWizardAction
			 * Sends specific action to content wizard.
			 */
			"BulkEmailContentWizardAction": {
				"mode": this.BPMSoft.MessageMode.PTP,
				"direction": this.BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		attributes: {
			/**
			 * Collection of the replica models.
			 * @type {BPMSoft.BaseViewModelCollection}
			 */
			"ReplicaCollection": {
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": this.BPMSoft.DataValueType.COLLECTION,
				"isCollection": true,
				"value": Ext.create("BPMSoft.BaseViewModelCollection")
			},

			/**
			 * Collection of the default replica model.
			 * @type {BPMSoft.BaseViewModelCollection}
			 */
			"DefaultReplicaCollection": {
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": this.BPMSoft.DataValueType.COLLECTION,
				"isCollection": true,
				"value": Ext.create("BPMSoft.BaseViewModelCollection")
			},

			/**
			 * Mask of active replica.
			 * @type {Number}
			 */
			"ActiveReplicaMask": {
				"dataValueType": this.BPMSoft.DataValueType.INTEGER,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": null
			},

			/**
			 * The bulk email id.
			 * @type {String}
			 */
			"BulkEmailId": {
				"dataValueType": this.BPMSoft.DataValueType.TEXT
			},

			/**
			 * Active item in replica collection
			 * @type {BPMSoft.PreviewReplicaViewModel}
			 */
			"SelectedReplicaItem": {
				"dataValueType": this.BPMSoft.DataValueType.CUSTOM_OBJECT,
				"value": Ext.create("BPMSoft.PreviewReplicaViewModel", {
					validateColumns: false
				})
			},

			/**
			 * Replica item with default values of headers.
			 * @type {BPMSoft.PreviewDefaultReplicaViewModel}
			 */
			"DefaultReplicaItem": {
				"dataValueType": this.BPMSoft.DataValueType.CUSTOM_OBJECT,
				"value": this.Ext.create("BPMSoft.PreviewDefaultReplicaViewModel")
			},

			/**
			 * Current content to show in preview.
			 * @type {BPMSoft.CUSTOM_OBJECT}
			 */
			"PreviewHtml": {
				"dataValueType": BPMSoft.DataValueType.CUSTOM_OBJECT
			},

			/**
			 * Flag to indicate that template is static content.
			 * @type {Boolean}
			 */
			"IsStaticEmail" : {
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
				"value": true
			}
		},
		methods: {

			// region Methods: Private

			/**
			 * Gets dom attribute to turn off scrolling.
			 * @returns {{scrolling: string}}
			 * @private
			 */
			_getScrollingAttribute: function() {
				return {
					"scrolling": "no"
				};
			},

			/**
			 * Populates replica collection with custom headers from headers module.
			 * @private
			 */
			_populateReplicasWithHeaders: function () {
				var replicaHeaders = this.$IsStaticEmail ?
					this.$DefaultReplicaCollection :
					this.getInitialReplicaHeaders();
				this.setHeadersToReplicaCollection(replicaHeaders);
			},

			/**
			 * Sets html-content to replica model by replica masl,
			 * @param {number} mask Replica mask.
			 * @param {string} content Html content.
			 * @private
			 */
			_setReplicaContentByMask: function (mask, content) {
				var replicaModel = this._getReplicaByMask(mask);
				if (replicaModel && replicaModel.$Content !== content) {
					replicaModel.$Content = content;
				}
			},

			/**
			 * Gets replica model by given mask.
			 * @param {number} mask Replica mask.
			 * @returns {BPMSoft.PreviewReplicaViewModel} Replica model instance.
			 * @private
			 */
			_getReplicaByMask: function (mask) {
				return this.$ReplicaCollection.findByFn(function (replica) {
					return replica.$Mask === mask;
				});
			},

			_updatePreview: function(contentBuilderConfig) {
				this.initDefaultItem();
				this.generateContentReplicas(contentBuilderConfig);
				this._populateReplicasWithHeaders();
			},

			_renderContent: function () {
				if (this.$IsStaticEmail) {
					this.renderStaticEmailPreview();
				} else {
					this.renderDynamicEmailPreview();
				}
			},

			/**
			 * Handles UpdatePreview message. Initializes replica items for static or dynamic content.
			 * @param {object} contentBuilderConfig Template config.
			 * @private
			 */
			_onUpdatePreview: function (contentBuilderConfig) {
				this._updatePreview(contentBuilderConfig);
			},

			_onUpdatePreviewWithRender: function (contentBuilderConfig) {
				this._updatePreview(contentBuilderConfig);
				this._renderContent();
			},

			/**
			 * Handles UpdateHeaders message. Sets default and custom headers.
			 * @private
			 */
			_onUpdateHeaders: function() {
				this.initDefaultItem();
				var replicaHeaders = this.getInitialReplicaHeaders();
				this.setHeadersToReplicaCollection(replicaHeaders);
			},

			/**
			 * Handles test email button click. Sends action message to wizard module.
			 * @private
			 */
			_onSendTestEmailButtonClicked: function() {
				this.sandbox.publish("BulkEmailContentWizardAction",
					BPMSoft.BulkEmailContentWizardActions.ShowTestEmailDialog);
			},

			/**
			 * Handles click on mobile preview container to set it as active one.
			 * @private
			 */
			_subscribeOnMobileClick: function() {
				$(".mobile-content-document").on("click", function() {
					$(".mobile-content-document").removeClass("blur-background");
					$(".desktop-content-document").addClass("blur-background");
				});
			},

			/**
			 * Handles click on desktop preview container to set it as active one.
			 * @private
			 */
			_subscribeOnDesktopClick: function() {
				$(".desktop-content-document").on("click", function() {
					$(".desktop-content-document").removeClass("blur-background");
					$(".mobile-content-document").addClass("blur-background");
				});
			},

			// endregion

			// region Methods: Protected

			/**
			 * @inheritdoc Render correct preview for static email.
			 * @protected
			 */
			renderStaticEmailPreview: function() {
				this.onReplicaMaskChange(this.$ActiveReplicaMask);
			},

			/**
			 * @inheritdoc Render correct preview for dynamic email. Flushes active list item id to rerender current
			 * selection. If neither selected - selects first.
			 * @protected
			 */
			renderDynamicEmailPreview: function() {
				var currentActiveReplicaMask = this.$ActiveReplicaMask;
				this.$ActiveReplicaMask = -1;
				if (!this._getReplicaByMask(currentActiveReplicaMask)){
					currentActiveReplicaMask = this.$ReplicaCollection.first().$Mask;
				}
				this.onReplicaMaskChange(currentActiveReplicaMask);
			},

			/**
			 * @inheritdoc BPMSoft.PreviewContentBuilder#getPreviewHtml
			 * @override
			 */
			getPreviewHtml: function (previewConfig) {
				if (BPMSoft.isEmpty(this.$ActiveReplicaMask) && !this.$ReplicaCollection.isEmpty()) {
					return this.get("Resources.Strings.SelectReplicaToPreviewContent");
				}
				var replica = this._getReplicaByMask(this.$ActiveReplicaMask);
				if (replica && replica.$Content) {
					return replica.$Content;
				}
				previewConfig = previewConfig || {};
				previewConfig.activeReplicaMask = this.$IsStaticEmail ? 0 : this.$ActiveReplicaMask;
				return this.sandbox.publish("GetPreviewHtml", previewConfig);
			},

			/**
			 * Get initial collection of replicas headers from content wizard.
			 * @protected
			 * @return {BPMSoft.BaseViewModelCollection}
			 */
			getInitialReplicaHeaders: function () {
				return this.sandbox.publish("BulkEmailContentWizardAction",
					BPMSoft.BulkEmailContentWizardActions.GetReplicaHeadersFromPreview) ||
					this.sandbox.publish("BulkEmailContentWizardAction",
						BPMSoft.BulkEmailContentWizardActions.GetReplicaHeaders);
			},

			/**
			 * Sets initial headers to replicas collection.
			 * @protected
			 * @param {BPMSoft.BaseViewModelCollection} initialHeaders Collection of initial headers.
			 */
			setHeadersToReplicaCollection: function (initialHeaders) {
				BPMSoft.each(this.$ReplicaCollection, function (replica) {
					if (!initialHeaders.contains(replica.$Mask)) {
						replica.bundle(this.$DefaultReplicaItem);
						return;
					}
					replica.$UseSpecialHeaders = true;
					var headers = initialHeaders.get(replica.$Mask);
					replica.$PreHeader = headers.$PreHeader;
					replica.$SenderName = headers.$SenderName;
					replica.$SenderEmail = headers.$SenderEmail;
					replica.$Subject = headers.$Subject;
				}, this);
			},

			/**
			 * Subscribe on sandbox messages.
			 * @protected
			 */
			subscribeMessages: function () {
				this.sandbox.subscribe("UpdatePreview", this._onUpdatePreview, this, ["Preview"]);
				this.sandbox.subscribe("UpdatePreviewWithRender", this._onUpdatePreviewWithRender, this, ["Preview"]);
				this.sandbox.subscribe("UpdateHeaders", this._onUpdateHeaders, this);
			},

			/**
			 * Gets replicas collection based on content builder config.
			 * @protected
			 * @param contentBuilderConfig Content builder view model as json.
			 * @returns {Array}
			 */
			getReplicasByConfig: function (contentBuilderConfig) {
				return ReplicaBuilder.generateReplicas(contentBuilderConfig);
			},

			/**
			 * Generate collection of preview content replicas based on content builder config.
			 * @protected
			 * @param {Object} contentBuilderConfig Content builder view model as json.
			 */
			generateContentReplicas: function (contentBuilderConfig) {
				var replicas = this.getReplicasByConfig(contentBuilderConfig);
				this.$IsStaticEmail = replicas.length === 1
					&& replicas[0].ReplicaMask === 0;
				if (this.$IsStaticEmail) {
					replicas[0].ReplicaMask = 1;
				}
				var actualReplicaCollection = Ext.create("BPMSoft.BaseViewModelCollection");
				BPMSoft.each(replicas, function (replica) {
					var actualReplica = this.getActualReplicaViewModel(replica);
					actualReplicaCollection.add(actualReplica.$Mask, actualReplica);
				}, this);
				this.$ReplicaCollection.clear();
				this.$ReplicaCollection.loadAll(actualReplicaCollection);
			},

			/**
			 * Gets content builder config.
			 * @protected
			 * @return {Object}
			 */
			getContentBuilderConfig: function () {
				return this.sandbox.publish("GetContentBuilderConfig");
			},

			/**
			 * Gets actual replica view model.
			 * @protected
			 * @param {Object} replica Replica item.
			 * @return {BPMSoft.PreviewReplicaViewModel} Replica preview view model.
			 */
			getActualReplicaViewModel: function (replica) {
				var viewModel = Ext.create("BPMSoft.PreviewReplicaViewModel");
				viewModel.$DefaultItem = this.$DefaultReplicaItem;
				viewModel.$Mask = replica.ReplicaMask;
				viewModel.$Caption = replica.Caption;
				viewModel.$UseSpecialHeaders = false;
				viewModel.$Content = null;
				viewModel.$BulkEmailId = this.$BulkEmailId;
				return viewModel;
			},

			/**
			 * Sets replica selected by given mask.
			 * @param {number} mask Replica mask.
			 */
			selectReplicaByMask: function (mask) {
				var content = this.getPreviewHtml();
				this.$PreviewHtml = content;
				this._setReplicaContentByMask(mask, content);
				var selectedVm = this._getReplicaByMask(mask);
				this.$SelectedReplicaItem.bundle(selectedVm);
			},

			/**
			 * Handles current replica mask change.
			 * @protected
			 * @param {Number} mask New selected replica mask value.
			 */
			onReplicaMaskChange: function (mask) {
				this.$ActiveReplicaMask = mask;
				this.selectReplicaByMask(mask);
			},

			/**
			 * Initializes replica item for the default headers.
			 * @protected
			 */
			initDefaultItem: function () {
				var defaultHeaders = this.sandbox.publish("BulkEmailContentWizardAction",
					BPMSoft.BulkEmailContentWizardActions.GetDefaultHeadersFromPreview) ||
					this.sandbox.publish("BulkEmailContentWizardAction",
						BPMSoft.BulkEmailContentWizardActions.GetDefaultHeadersFromBulkEmail);
				this.$DefaultReplicaItem.$Subject = defaultHeaders.$Subject;
				this.$DefaultReplicaItem.$SenderEmail = defaultHeaders.$SenderEmail;
				this.$DefaultReplicaItem.$SenderName = defaultHeaders.$SenderName;
				this.$DefaultReplicaItem.$PreHeader = defaultHeaders.$PreHeader;
				this.$DefaultReplicaItem.$Caption =
					resources.localizableStrings.DefaultReplicasContainerCaption;
				this.$DefaultReplicaItem.$Mask = 1;
				this.$DefaultReplicaItem.$UseSpecialHeaders = false;
				this.$DefaultReplicaItem.$DefaultItem = this.$DefaultReplicaItem;
				this.$DefaultReplicaCollection = Ext.create("BPMSoft.BaseViewModelCollection");
				this.$DefaultReplicaCollection.add(this.$DefaultReplicaItem.$Mask, this.$DefaultReplicaItem);
			},

			// endregion

			// region Methods: Public

			/**
			 * @inheritdoc PreviewContentBuilder#init
			 * @override
			 */
			init: function () {
				this.$SelectedReplicaItem.sandbox = this.sandbox;
				this.$BulkEmailId = this.sandbox.publish("BulkEmailContentBuilderAction",
				BPMSoft.BulkEmailContentBuilderActions.GetBulkEmailId);
				this.subscribeMessages();
				this.initDefaultItem();
				var contentBuilderConfig = this.getContentBuilderConfig();
				this.generateContentReplicas(contentBuilderConfig);
				this._populateReplicasWithHeaders();
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModule#onRender
			 * @override
			 */
			onRender: function() {
				this.callParent(arguments);
				if(this.$ReplicaCollection.isEmpty()) {
					return;
				}
				if (this.$IsStaticEmail) {
					this.$ActiveReplicaMask = 1;
					this.renderStaticEmailPreview();
				} else {
					this.renderDynamicEmailPreview();
				}
			},

			/**
			 * Handles download htm button click. Downloads currently selected replica's html.
			 */
			onDownloadHtmlButtonClick: function () {
				var element = document.createElement("a");
				element.setAttribute("href", "data:text/html;charset=utf-8," + encodeURIComponent(this.$PreviewHtml));
				var currentReplica = this._getReplicaByMask(this.$ActiveReplicaMask);
				element.setAttribute("download", currentReplica.$Caption + ".html");
				element.style.display = "none";
				document.body.appendChild(element);
				element.click();
				document.body.removeChild(element);
			},

			/**
			 * @private
			 */
			_getEmailProfileImage: function() {
				return BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.EmailProfileImage);
			},

			// endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "PreviewMainContainer",
				"propertyName": "items",
				"index": 1,
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["main-preview-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "LeftSideContainer",
				"parentName": "PreviewMainContainer",
				"propertyName": "items",
				"index": 1,
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["left-side-container"],
					"visible": true,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "ReplicasContainer",
				"parentName": "LeftSideContainer",
				"propertyName": "items",
				"index": 3,
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["replica-caption-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "ReplicasContainerCaptionGridLayout",
				"parentName": "ReplicasContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"classes": {
						"wrapClassName": ["replica-caption-item-container"]
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "ReplicasContainerCaption",
				"parentName": "ReplicasContainerCaptionGridLayout",
				"propertyName": "items",
				"values": {
					"caption":  resources.localizableStrings.ReplicasContainerCaption,
					"itemType": BPMSoft.ViewItemType.LABEL,
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 21,
						"rowSpan": 1
					}
				}
			},
			{
				"operation": "insert",
				"name": "ReplicasContainerCaptionInfoButton",
				"parentName": "ReplicasContainerCaptionGridLayout",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.INFORMATION_BUTTON,
					"content": resources.localizableStrings.InboxPreviewInfoButtonCaption,
					"behaviour": {
						"displayEvent": this.BPMSoft.TipDisplayEvent.CLICK
					},
					"classes": {
						"wrapClassName": ["caption-info-button"]
					},
					"layout": {
						"column": 20,
						"row": 0,
						"colSpan": 1,
						"rowSpan": 1
					}
				}
			},
			{
				"operation": "insert",
				"name": "DefaultReplicaContainerBorder",
				"parentName": "ReplicasContainerCaptionGridLayout",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 22,
						"rowSpan": 1
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "ReplicasContainerList",
				"parentName": "ReplicasContainer",
				"propertyName": "items",
				"values": {
					"idProperty": "Mask",
					"rowCssSelector": ".replica-item",
					"itemType": this.BPMSoft.ViewItemType.GRID,
					"collection": "$ReplicaCollection",
					"generator": "ContainerListGenerator.generatePartial",
					"selectableRowCss": "replica-item",
					"classes": {
						"wrapClassName": ["replica-container-list scrollable-container"]
					},
					"itemPrefix": "View",
					"dataItemIdPrefix": "replica-item",
					"activeItem": "$ActiveReplicaMask",
					"onItemClick": "$onReplicaMaskChange",
					"defaultItemConfig": {
						"className": "BPMSoft.Container",
						"id": "replica-item-view",
						"items": [
							{
								"className": "BPMSoft.ControlGroup",
								"collapsed": false,
								"id": "replica-item-view-content",
								"caption": "$_getReplicaLabelCaption",
								"markerValue": "$Caption",
								"domAttributes": "$_getReplicaLabelDomAttributes",
								"selectors": {
									"wrapEl": "#replica-item-view-content"
								},
								"classes": {
									"wrapClassName": ["replica-item-wrapper-container", "replica-item-wrapper-caption", "grid-item-replica"]
								},
								"tools": [{
									"className": "BPMSoft.ImageView",
									"classes": {
										"wrapClass": ["letter-icon-wrapper"],
										"wrapperClass": ["page-type-add-button"]
									},
									"imageSrc": "$_getLetterIcon",
									"visible": true
								}],
								"items": [
									{
										"className": "BPMSoft.Container",
										"classes": {
											"wrapClassName": ["item-sender-name"]
										},
										"items": [
											{
												"className": "BPMSoft.Label",
												"classes": {
													"labelClass": ["label-wrap", "headers-label"]
												},
												"caption": "$SenderName",
												"markerValue": "$SenderName",
												"tag": "SenderName",
												"domAttributes": "$_getHeaderLabelDomAttribute"
											}
										]
									},
									{
										"className": "BPMSoft.Container",
										"classes": {
											"wrapClassName": ["item-subject"]
										},
										"items": [
											{
												"className": "BPMSoft.Label",
												"classes": {
													"labelClass": ["label-wrap", "headers-label"]
												},
												"caption": "$Subject",
												"markerValue": "$Subject",
												"tag": "Subject",
												"domAttributes": "$_getHeaderLabelDomAttribute"
											}
										]
									},
									{
										"className": "BPMSoft.Container",
										"classes": {
											"wrapClassName": ["item-preheader"]
										},
										"items": [
											{
												"className": "BPMSoft.Label",
												"classes": {
													"labelClass": ["label-wrap", "headers-label"]
												},
												"caption": "$PreHeader",
												"markerValue": "$PreHeader",
												"tag": "PreHeader",
												"domAttributes": "$_getHeaderLabelDomAttribute"
											}
										]
									}
								]
							}
						]
					}
				}
			},
			{
				"operation": "insert",
				"name": "PreviewCenterContainer",
				"parentName": "PreviewMainContainer",
				"propertyName": "items",
				"index": 1,
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["preview-center-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "TemplateContentContainer",
				"parentName": "PreviewCenterContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["template-content-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "MobileContentContainer",
				"parentName": "TemplateContentContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["mobile-content-document blur-background"],
					"afterrender": {"bindTo": "_subscribeOnMobileClick"},
					"afterrerender": {"bindTo": "_subscribeOnMobileClick"},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "MobileHeadersContainer",
				"parentName": "MobileContentContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["mobile-headers-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "MobileEmailGridLayout",
				"parentName": "MobileHeadersContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"classes": {
						"wrapClassName": ["mobile-email-container"]
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "MobileProfileImageContainer",
				"parentName": "MobileEmailGridLayout",
				"propertyName": "items",
				"values": {
					"classes": {
						"wrapClass": ["profile-image-email-container"]
					},
					"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
					"onPhotoChange": BPMSoft.emptyFn,
					"getSrcMethod": "_getEmailProfileImage",
					"items": [],
					"layout": {
						"column": 1,
						"row": 0,
						"rowSpan": 2,
						"colSpan": 2

					},
				}
			},
			{
				"operation": "insert",
				"name": "MobileSenderLabel",
				"parentName": "MobileEmailGridLayout",
				"propertyName": "items",
				"values": {
					"bindingContext": "SelectedReplicaItem",
					"caption": "$_getSenderCaption",
					"itemType": BPMSoft.ViewItemType.LABEL,
					"classes": {
						"labelClass": ["label-inline sender-label"]
					},
					"layout": {
						"column": 5,
						"row": 0,
						"rowSpan": 1
					},
					"domAttributes": "$_getSenderDomAttribute"
				}
			},
			{
				"operation": "insert",
				"name": "MobileSubject",
				"parentName": "MobileEmailGridLayout",
				"propertyName": "items",
				"values": {
					"bindingContext": "SelectedReplicaItem",
					"caption":  "$Subject",
					"itemType": BPMSoft.ViewItemType.LABEL,
					"classes": {
						"labelClass": ["subject-label"]
					},
					"layout": {
						"column": 5,
						"row": 1,
						"rowSpan": 1
					},
					"tag": "Subject",
					"domAttributes": "$_getHeaderLabelDomAttribute"
				}
			},
			{
				"operation": "insert",
				"name": "DesktopContentContainer",
				"parentName": "TemplateContentContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["desktop-content-document"],
					"afterrender": {"bindTo": "_subscribeOnDesktopClick"},
					"afterrerender": {"bindTo": "_subscribeOnDesktopClick"},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "DesktopHeadersContainer",
				"parentName": "DesktopContentContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["desktop-headers-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "DesktopPreviewContainer",
				"parentName": "DesktopContentContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["desktop-preview-container scrollable-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "DesktopPreviewDocument",
				"parentName": "DesktopPreviewContainer",
				"propertyName": "items",
				"values": {
					"generator": function() {
						return {
							"className": "BPMSoft.IframeControl",
							"id": "DesktopPreviewDocumentIframe",
							"iframeContent": "$PreviewHtml",
							"fitHeightToContent": "true",
							"wrapClass": ["preview-document-iframe"],
							"domAttributes": "$_getScrollingAttribute"
						};
					}
				}
			},
			{
				"operation": "insert",
				"name": "DesktopHeadersGrid",
				"parentName": "DesktopHeadersContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
					"layout": {
						"column": 0,
						"row": 0,
						"rowSpan": 1
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "ProfileImageContainer",
				"parentName": "DesktopHeadersGrid",
				"propertyName": "items",
				"values": {
					"classes": {
						"wrapClass": ["profile-image-email-container"]
					},
					"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
					"onPhotoChange": BPMSoft.emptyFn,
					"getSrcMethod": "_getEmailProfileImage",
					"items": [],
					"layout": {
						"column": 0,
						"row": 0,
						"rowSpan": 2,
						"colSpan": 2

					},
				}
			},
			{
				"operation": "insert",
				"name": "DesktopSendTestEmail",
				"parentName": "DesktopHeadersGrid",
				"propertyName": "items",
				"values": {
					"imageConfig": resources.localizableImages.SendTestEmailButtonIcon,
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"click": "$_onSendTestEmailButtonClicked",
					"classes": {"textClass": ["desktop-small-button"]},
					"layout": {
						"column": 22,
						"row": 1,
						"colSpan": 1
					}
				}
			},
			{
				"operation": "insert",
				"name": "DesktopGetHtmlButton",
				"parentName": "DesktopHeadersGrid",
				"propertyName": "items",
				"values": {
					"imageConfig": resources.localizableImages.DownloadHtmlButtonIcon,
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"classes": {"textClass": ["desktop-small-button"]},
					"click": "$onDownloadHtmlButtonClick",
					"layout": {
						"column": 23,
						"row": 1,
						"colSpan": 1
					}
				}
			},
			{
				"operation": "insert",
				"name": "DesktopSenderLabel",
				"parentName": "DesktopHeadersGrid",
				"propertyName": "items",
				"values": {
					"bindingContext": "SelectedReplicaItem",
					"caption": "$_getSenderCaption",
					"itemType": BPMSoft.ViewItemType.LABEL,
					"classes": {
						"labelClass": ["label-inline sender-label"]
					},
					"domAttributes": "$_getSenderDomAttribute",
					"layout": {
						"column": 1,
						"row": 0,
						"rowSpan": 1
					}
				}
			},
			{
				"operation": "insert",
				"name": "DesktopSubject",
				"parentName": "DesktopHeadersGrid",
				"propertyName": "items",
				"values": {
					"bindingContext": "SelectedReplicaItem",
					"caption":  "$Subject",
					"itemType": BPMSoft.ViewItemType.LABEL,
					"classes": {
						"labelClass": ["subject-label"]
					},
					"tag": "Subject",
					"domAttributes": "$_getHeaderLabelDomAttribute",
					"layout": {
						"column": 1,
						"row": 1,
						"rowSpan": 1
					}
				}
			},
			{
				"operation": "insert",
				"name": "MobilePreviewContainer",
				"parentName": "MobileContentContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["mobile-preview-container scrollable-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "MobilePreviewDocument",
				"parentName": "MobilePreviewContainer",
				"propertyName": "items",
				"values": {
					"generator": function() {
						return {
							"domAttributes": "$_getScrollingAttribute",
							"className": "BPMSoft.IframeControl",
							"id": "MobilePreviewDocumentIframe",
							"iframeContent": "$PreviewHtml",
							"wrapClass": ["preview-document-iframe"],
							"fitHeightToContent": "true"
						};
					}
				}
			}
		] /**SCHEMA_DIFF*/
	};
});
