define("BulkEmailContentWizardHeaders", ["BulkEmailContentWizardHeadersResources",
	"DynamicContentReplicaBuilder", "InformationButtonResources", "ContainerListGenerator",
	"ContainerList", "MultilineLabel", "css!MultilineLabel", "PreviewReplicaViewModel",
	"PreviewDefaultReplicaViewModel", "ImageView", "css!BulkEmailContentWizardHeadersCSS"],
	function (resources, ReplicaBuilder, informationButtonResources) {
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
			 * @message UpdatePreview
			 * Gets content builder config.
			 */
			"UpdatePreview": {
				"mode": this.BPMSoft.MessageMode.PTP,
				"direction": this.BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message UpdateTemplateSubject
			 * Gets new default template subject.
			 */
			"UpdateTemplateSubject": {
				"mode": this.BPMSoft.MessageMode.PTP,
				"direction": this.BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message GetReplicaHeaders
			 * Returns actual replica headers from preview module.
			 */
			"GetReplicaHeaders": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message GetBulkEmailDefaultHeaders
			 * Returns actual default headers.
			 */
			"GetBulkEmailDefaultHeaders": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message BulkEmailContentWizardAction
			 * Sends specific action to content wizard.
			 */
			"BulkEmailContentWizardAction": {
				"mode": this.BPMSoft.MessageMode.PTP,
				"direction": this.BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message OpenMacrosDialog
			 * Opens macro selection dialog.
			 */
			"OpenMacrosDialog": {
				"mode": this.BPMSoft.MessageMode.PTP,
				"direction": this.BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		attributes: {

			/**
			 * The bulk email id.
			 * @type {String}
			 */
			"BulkEmailId": {
				"dataValueType": this.BPMSoft.DataValueType.TEXT
			},
			
			/**
			 * Buffer for insert value to subject.
			 * @type {String}
			 */
			"SubjectInsertBuffer": {
				"dataValueType": this.BPMSoft.DataValueType.TEXT
			},

			/**
			 * Buffer for insert value to pre-header.
			 * @type {String}
			 */
			"PreHeaderInsertBuffer": {
				"dataValueType": this.BPMSoft.DataValueType.TEXT
			},

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
			 * Collection of the replica headers.
			 * @type {BPMSoft.Collection}
			 */
			"ReplicaHeadersCollection": {
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": this.BPMSoft.DataValueType.COLLECTION,
				"isCollection": true
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
			 * Mask of default active replica.
			 * @type {Number}
			 */
			"DefaultActiveReplicaMask": {
				"dataValueType": this.BPMSoft.DataValueType.INTEGER,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": null
			},

			/**
			 * Side bar visible value.
			 * @type {Boolean}
			 */
			"IsSideBarVisible": {
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
				"value": false
			},

			/**
			 * Flag to indicate replica mask 0.
			 * @type {Boolean}
			 */
			"IsDynamicDefaultBlockSelected": {
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
				"value": false
			},

			/**
			 * Flag to indicate that there is no default content at the template.
			 * @type {Boolean}
			 */
			"NoDefaultContent": {
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
				"value": false
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
			 * Active item in replica collection
			 * @type {BPMSoft.PreviewDefaultReplicaViewModel}
			 */
			"SelectedReplicaItem": {
				"dataValueType": this.BPMSoft.DataValueType.CUSTOM_OBJECT,
				"value": Ext.create("BPMSoft.PreviewReplicaViewModel", {
					validateColumns: true,
					cache: this.BPMSoft.ClientPageSessionCache,
					sandbox: this.sandbox
				})
			},

			/**
			 * Indicates ToggleListButton visibility.
			 * @type {Boolean}
			 */
			"IsToggleListButtonVisible": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: false
			},

			/**
			 * Determines that value of the SenderEmail field is valid.
			 */
			"IsSenderEmailValid": {
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: true
			},
			/**
			 * Determines that SenderEmailInfoButton message is visible.
			 */
			"SenderEmailInfoButtonTipVisible": {
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			},
			/**
			 * Determines that SenderEmailInfoButton is visible.
			 */
			"SenderEmailInfoButtonVisible": {
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			},
			/**
			 * Image config for the SenderEmailInfoButton.
			 */
			"SenderEmailInfoButtonImageConfig": {
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
				value: null
			},
			/**
			 * Content of the SenderEmailInfoButton.
			 */
			"SenderEmailInfoButtonContent": {
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: BPMSoft.DataValueType.TEXT
			},
			/**
			 * Style of the SenderEmailInfoButton.
			 */
			"SenderEmailInfoButtonStyle": {
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: BPMSoft.DataValueType.TEXT,
				value: BPMSoft.TipStyle.WHITE
			}
		},
		methods: {

			// region Methods: Private

			/**
			 * @private
			 */
			_populateReplicasWithHeaders: function () {
				var replicaHeaders = this.getInitialReplicaHeaders();
				this.setHeadersToReplicaCollection(replicaHeaders);
			},

			/**
			 * @private
			 */
			_setReplicaContentByMask: function (mask, content) {
				var replicaModel = this._getReplicaByMask(mask);
				if (replicaModel && replicaModel.$Content !== content) {
					replicaModel.$Content = content;
				}
			},

			/**
			 * @private
			 */
			_getReplicaByMask: function (mask) {
				return this.$ReplicaCollection.findByFn(function (replica) {
					return replica.$Mask === mask;
				});
			},

			/**
			 * Checks when there is no default content in all dynamic blocks.
			 * @private
			 * @param {Object} config Template config.
			 */
			_checkNoDefaultContent: function (config) {
				var hasDefault = false;
				BPMSoft.each(config.Items, function (item) {
					if (item.ItemType === "blockgroup") {
						var defaultBlock = Ext.Array.findBy(item.Items, function (block) {
							return block.IsDefault;
						});
						hasDefault = hasDefault || Boolean(defaultBlock);
						return !hasDefault;
					}
				}, this);
				return !hasDefault;
			},

			/**
			 * @private
			 */
			_initSideBarVisibility: function () {
				var isStaticTemplate = this.$ReplicaCollection.getCount() === 1
					&& this.$ReplicaCollection.first().$Mask === 0;
				this.$IsSideBarVisible = !isStaticTemplate;
				this.$IsToggleListButtonVisible = !isStaticTemplate;
			},

			/**
			 * @private
			 */
			_isPreviewVisible: function () {
				return Boolean(this.$PreviewHtml && !this.$IsDynamicDefaultBlockSelected);
			},

			/**
			 * @private
			 */
			_isEmptyReplicaContainerVisible: function () {
				return this.$IsDynamicDefaultBlockSelected && this.$NoDefaultContent;
			},

			/**
			 * @private
			 */
			_getIsStaticEmail: function() {
				return this.$ReplicaCollection.getCount() === 1
					&& this.$ReplicaCollection.first().$Mask === 0;
			},

			/**
			 * Handler for UpdatePreview message.
			 * Generates replicas by template config and render new html content for preview.
			 * @param {Object} contentBuilderConfig Template config.
			 * @private
			 */
			_onUpdatePreview: function (contentBuilderConfig) {
				this.generateContentReplicas(contentBuilderConfig);
				var isStaticTemplate = this._getIsStaticEmail();
				if (isStaticTemplate) {
					this.renderStaticEmailPreview();
				} else {
					this.renderDynamicEmailPreview();
				}
			},

			/**
			 * @private
			 */
			_onUpdateTemplateSubject: function(templateSubject) {
				this.$DefaultReplicaItem.$Subject = templateSubject;
			},

			/**
			 * @private
			 */
			_actualizeHeaderReplicaBinding: function() {
				var contentBuilderConfig = this.getContentBuilderConfig();
				var replicas = this.getReplicasByConfig(contentBuilderConfig);
				this._bindHeadersToReplica(replicas);
			},

			/**
			 * @private
			 */
			_bindHeadersToReplica: function(replicaObjects) {
				BPMSoft.each(replicaObjects, function (replicaObject) {
					var replicaRules = this._getReplicaRules(replicaObject);
					var viewModel = this._getReplicaByRules(replicaRules);
					if (viewModel) {
						viewModel.$Mask = replicaObject.ReplicaMask;
					}
				}, this);
			},

			/**
			 * @private
			 */
			_onGetReplicaHeaders: function() {
				var actualTemplateConfig = this.getContentBuilderConfig();
				this.generateContentReplicas(actualTemplateConfig);
				this._actualizeHeaderReplicaBinding();
				return this.getSpecialReplicaHeaders();
			},

			/**
			 * @private
			 */
			_onGetDefaultHeaders: function() {
				return this.$DefaultReplicaItem;
			},

			/**
			 * Gets replica's unique combination of dynamic rules.
			 * @param {BPMSoft.PreviewReplicaViewModel} replicaObject Replica view model.
			 * @returns {string} dynamic rules identifiers joined as a string.
			 * @private
			 */
			_getReplicaRules: function(replicaObject) {
				var ruleIndexes = replicaObject.Items
					.map(function(i) { return i.Attributes && i.Attributes[0]; })
					.filter(function(i) { return i; });
				var ids = replicaObject.Attributes
					.filter(function(a) { return ruleIndexes.indexOf(a.Index) >= 0; })
					.map(function(a) { return a.Id; });
				return ids.join();
			},

			/**
			 * Gets replica view model from replica collection by unique combination of dynamic rules.
			 * @param {string} replicaRules
			 * @returns {BPMSoft.PreviewReplicaViewModel} found view model.
			 * @private
			 */
			_getReplicaByRules: function (replicaRules) {
				return this.$ReplicaCollection.getItems().find(function(r) { return r.$ReplicaRules === replicaRules; });
			},

			/**
			 * Sets handler for sender email validation event.
			 * @private
			 */
			_initSenderEmailDomainValidationHandler: function () {
				var scope = this;
				this.$SelectedReplicaItem.$OnSenderEmailDomainValidation = function (isValid, message, forceShowToolTip) {
					scope._updateSenderEmailInfoButton(isValid, message, forceShowToolTip);
				};
			},

			/**
			 * Returns image config for the SenderEmailInfoButton depending on the enabled state.
			 * @private
			 * @param {Boolean} isValid Determines state of the button and what image has to be returned.
			 * @return {Object} Image config.
			 */
			_getSenderEmailInfoButtonImageConfig: function(isValid) {
				var imageName = isValid ? "DefaultIcon" : "WarningIcon";
				return informationButtonResources.localizableImages[imageName];
			},

			/**
			 * Sets attributes to render sender email info button.
			 * @param {boolean} isValid Indicates weather domain successfully validated
			 * @param {string} message Custom message to show.
			 * @param {boolean} forceShowToolTip Indicates weather to show tip forcibly.
			 * @private
			 */
			_updateSenderEmailInfoButton: function(isValid, message, forceShowToolTip) {
				var buttonVisible = !!this.$SelectedReplicaItem.$SenderEmail;
				this.$SenderEmailInfoButtonVisible = buttonVisible;
				if (!buttonVisible) {
					return;
				}
				if (this.$IsSenderEmailValid !== isValid || forceShowToolTip) {
					this.$SenderEmailInfoButtonTipVisible = true;
				}
				this.$IsSenderEmailValid = isValid;
				this.$SenderEmailInfoButtonImageConfig = this._getSenderEmailInfoButtonImageConfig(isValid);
				var content;
				var style;
				if (isValid) {
					content = message ? message : this.get("Resources.Strings.ValidSenderDomainMessage");
					style = BPMSoft.TipStyle.WHITE;
				} else {
					content = message ? message : this.get("Resources.Strings.InvalidSenderDomainMessage");
					style = BPMSoft.TipStyle.RED;
				}
				this.$SenderEmailInfoButtonContent = content;
				this.$SenderEmailInfoButtonStyle = style;
			},

			// endregion

			// region Methods: Protected

			/**
			 * @inheritdoc Render correct preview for static email.
			 * @protected
			 */
			renderStaticEmailPreview: function() {
				this.$PreviewHtml = this.getPreviewHtml();
				this.$IsDynamicDefaultBlockSelected = false;
			},

			/**
			 * @inheritdoc Render correct preview for dynamic email.
			 * @protected
			 */
			renderDynamicEmailPreview: function() {
				if (!this.$ActiveReplicaMask || this.$ActiveReplicaMask === -1) {
					return;
				}
				var currentActiveReplicaMask = this.$ActiveReplicaMask;
				this.$ActiveReplicaMask = -1;
				if (this.$ReplicaCollection.getCount() < currentActiveReplicaMask){
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
				if (this.$IsSideBarVisible) {
					var replica = this._getReplicaByMask(this.$ActiveReplicaMask);
					if (replica && replica.$Content) {
						return replica.$Content;
					}
					this.$IsDynamicDefaultBlockSelected = this.$ActiveReplicaMask === 0;
					previewConfig = previewConfig || {};
					previewConfig.activeReplicaMask = this.$ActiveReplicaMask;
				}
				return this.callParent([previewConfig]);
			},

			/**
			 * Get initial collection of replicas headers from content wizard.
			 * @protected
			 * @return {BPMSoft.BaseViewModelCollection}
			 */
			getInitialReplicaHeaders: function () {
				return this.sandbox.publish("BulkEmailContentWizardAction",
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
				this.sandbox.subscribe("UpdatePreview", this._onUpdatePreview, this, ["Headers"]);
				this.sandbox.subscribe("UpdateTemplateSubject", this._onUpdateTemplateSubject, this);
				this.sandbox.subscribe("GetReplicaHeaders", this._onGetReplicaHeaders, this);
				this.sandbox.subscribe("GetBulkEmailDefaultHeaders", this._onGetDefaultHeaders, this);
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
				var actualReplicaCollection = Ext.create("BPMSoft.BaseViewModelCollection");
				BPMSoft.each(replicas, function (replica) {
					var actualReplica = this.getActualReplicaViewModel(replica);
					actualReplicaCollection.add(actualReplica.$Mask, actualReplica);
				}, this);
				this.$ReplicaCollection.clear();
				this.$ReplicaCollection.loadAll(actualReplicaCollection);
				this._initSideBarVisibility();
				this.$NoDefaultContent = this._checkNoDefaultContent(contentBuilderConfig);
			},

			/**
			 * Gets collection of replicas with special headers.
			 * @protected
			 * @returns {BPMSoft.BaseViewModelCollection}
			 */
			getSpecialReplicaHeaders: function () {
				return this.$ReplicaCollection.filter(function (replica) {
					return replica.$UseSpecialHeaders;
				});
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
				var viewModel;
				var replicaRules = this._getReplicaRules(replica);
				viewModel = this._getReplicaByRules(replicaRules);
				if (viewModel) {
					viewModel.$Content = null;
					viewModel.$Caption = replica.Caption;
					viewModel.$Mask = replica.ReplicaMask;
					viewModel.$BulkEmailId = this.$BulkEmailId;
				} else {
					viewModel = Ext.create("BPMSoft.PreviewReplicaViewModel");
					viewModel.$DefaultItem = this.$DefaultReplicaItem;
					viewModel.$ReplicaRules = replicaRules;
					viewModel.$Mask = replica.ReplicaMask;
					viewModel.$Caption = replica.Caption;
					viewModel.$UseSpecialHeaders = false;
					viewModel.$BulkEmailId = this.$BulkEmailId;
				}
				return viewModel;
			},

			/**
			 * Returns blank slate image url.
			 * @protected
			 * @returns {string} Blank slate image URL.
			 */
			getEmptyReplicaImageUrl: function () {
				var config = resources.localizableImages.EmptyReplicaIcon;
				return BPMSoft.ImageUrlBuilder.getUrl(config);
			},

			/**
			 * Generates config for icons of toggle list button.
			 * @protected
			 * @return {Object} Toggle list button image config.
			 */
			getToggleListButtonImageConfig: function () {
				return this.getResourceImageConfig("Resources.Images.ToggleListButtonImage");
			},

			/**
			 * Handles default item select event.
			 */
			onSelectDefaultHeaderClick: function () {
				this.$DefaultActiveReplicaMask = -1;
				this.$ActiveReplicaMask = -1;
				this.$SelectedReplicaItem.bundle(this.$DefaultReplicaItem);
				this.$IsDynamicDefaultBlockSelected = true;
				this.$DefaultActiveReplicaMask = 1;
			},

			/**
			 * Handles toggle list button click event.
			 */
			onToggleListButtonClick: function () {
				this.$IsSideBarVisible = !this.$IsSideBarVisible;
			},

			/**
			 * Handles current replica mask change.
			 * @protected
			 * @param {Number} mask New selected replica mask value.
			 */
			onReplicaMaskChange: function (mask) {
				this.$DefaultActiveReplicaMask = -1;
				this.$IsDynamicDefaultBlockSelected = false;
				this.$ActiveReplicaMask = mask;
				var content = this.getPreviewHtml();
				this.$PreviewHtml = content;
				this._setReplicaContentByMask(mask, content);
				var selectedVm = this._getReplicaByMask(mask);
				this.$SelectedReplicaItem.bundle(selectedVm);
			},

			/**
			 * Initializes replica item for the default headers.
			 * @protected
			 */
			initDefaultItem: function () {
				var defaultHeaders = this.sandbox.publish("BulkEmailContentWizardAction",
					BPMSoft.BulkEmailContentWizardActions.GetDefaultHeadersFromBulkEmail);
				this.$DefaultReplicaItem.$Subject = defaultHeaders.$Subject;
				this.$DefaultReplicaItem.$SenderEmail = defaultHeaders.$SenderEmail;
				this.$DefaultReplicaItem.$SenderName = defaultHeaders.$SenderName;
				this.$DefaultReplicaItem.$PreHeader = defaultHeaders.$PreHeader;
				this.$DefaultReplicaItem.$Caption =
					resources.localizableStrings.DefaultReplicasContainerCaption;
				this.$DefaultReplicaItem.$Mask = 1;
				this.$DefaultReplicaItem.$UseSpecialHeaders = true;
				this.$DefaultReplicaItem.$BulkEmailId = this.$BulkEmailId;
				this.$DefaultReplicaCollection = Ext.create("BPMSoft.BaseViewModelCollection");
				this.$DefaultReplicaCollection.add(this.$DefaultReplicaItem.$Mask, this.$DefaultReplicaItem);
			},

			/**
			 * Click handler for the sender email information button.
			 * @protected
			 * @returns {boolean}
			 */
			onSenderEmailInfoButtonClick: function() {
				this.openBpmCrmCloudIntegrationPage();
				return false;
			},

			/**
			 * Opens Bpmcrm Cloud Integration settings page.
			 */
			openBpmCrmCloudIntegrationPage: function() {
				var pageName = "BpCloudIntegrationPageV2";
				var integrationPageUrl = Ext.String.format("{0}{1}/{2}/",
					BPMSoft.workspaceBaseUrl,
					"/Nui/ViewModule.aspx#CardModuleV2",
					pageName);
				window.open(integrationPageUrl);
			},

			// endregion

			// region Methods: Public

			/**
			 * @inheritdoc PreviewContentBuilder#init
			 * @override
			 */
			init: function () {
				this.$SelectedReplicaItem.sandbox = this.sandbox;
				this._updateSenderEmailInfoButton(false);
				this._initSenderEmailDomainValidationHandler();
				this.subscribeMessages();
				this.$BulkEmailId = this.sandbox.publish("BulkEmailContentBuilderAction", 
				BPMSoft.BulkEmailContentBuilderActions.GetBulkEmailId);
				this.initDefaultItem();
				var contentBuilderConfig = this.getContentBuilderConfig();
				this.generateContentReplicas(contentBuilderConfig);
				this._populateReplicasWithHeaders();
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc PreviewContentBuilder#onRender
			 * @override
			 */
			onRender: function () {
				this.onSelectDefaultHeaderClick();
				var isStaticTemplate = this._getIsStaticEmail();
				if (isStaticTemplate) {
					this.renderStaticEmailPreview();
				}
			}

			// endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "HeadersMainContainer",
				"propertyName": "items",
				"index": 1,
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["main-headers-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "LeftSideContainer",
				"parentName": "HeadersMainContainer",
				"propertyName": "items",
				"index": 1,
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["left-side-container"],
					"visible": {
						"bindTo": "IsSideBarVisible"
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "DefaultReplicaContainer",
				"parentName": "LeftSideContainer",
				"propertyName": "items",
				"index": 1,
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"classes": {
						"wrapClassName": ["replica-caption-container"]
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "DefaultReplicaContainerCaptionGridLayout",
				"parentName": "DefaultReplicaContainer",
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
				"name": "DefaultReplicaContainerCaption",
				"parentName": "DefaultReplicaContainerCaptionGridLayout",
				"propertyName": "items",
				"values": {
					"caption":  resources.localizableStrings.DefaultReplicasContainerCaption,
					"itemType": BPMSoft.ViewItemType.LABEL,
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 22,
						"rowSpan": 1
					}
				}
			},
			{
				"operation": "insert",
				"name": "DefaultReplicaContainerInformationButton",
				"parentName": "DefaultReplicaContainerCaptionGridLayout",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.INFORMATION_BUTTON,
					"content":  {bindTo: "Resources.Strings.DefaultReplicaInformationButtonTooltip"},
					"style": BPMSoft.TipStyle.WHITE,
					"behaviour": {
						"displayEvent": this.BPMSoft.TipDisplayEvent.CLICK
					},
					"layout": {
						"column": 22,
						"row": 0,
						"colSpan": 2,
						"rowSpan": 1
					},
					"controlConfig": {
						"visible":  true,
						"imageConfig": informationButtonResources.localizableImages.DefaultIcon
					}
				}
			},
			{
				"operation": "insert",
				"name": "DefaultReplicasContainerList",
				"parentName": "DefaultReplicaContainer",
				"propertyName": "items",
				"values": {
					"idProperty": "Mask",
					"rowCssSelector": ".replica-item",
					"itemType": this.BPMSoft.ViewItemType.GRID,
					"collection": "$DefaultReplicaCollection",
					"generator": "ContainerListGenerator.generatePartial",
					"selectableRowCss": "replica-item",
					"classes": {
						"wrapClassName": ["replica-container-list scrolling-container"]
					},
					"itemPrefix": "View",
					"dataItemIdPrefix": "default-replica-item",
					"activeItem": "$DefaultActiveReplicaMask",
					"onItemClick": "$onSelectDefaultHeaderClick",
					"defaultItemConfig": {
						"className": "BPMSoft.Container",
						"id": "replica-item-view-default",
						"selectors": {
							"wrapEl": "#replica-item-view-default"
						},
						"classes": {
							"wrapClassName": ["replica-item-wrapper-container"]
						},
						"items": [
							{
								"className": "BPMSoft.Container",
								"classes": {
									"wrapClassName": ["replica-item-wrapper-toggle"]
								},
								"items": [
									{
										"className": "BPMSoft.CheckBoxEdit",
										"classes": {
											"labelClass": ["toggle-wrap"]
										},
										"checked": true,
										"enabled": false
									}
								]
							},
							{
								"className": "BPMSoft.Container",
								"classes": {
									"wrapClassName": ["replica-item-wrapper-caption"]
								},
								"items": [
									{
										"className": "BPMSoft.Label",
										"classes": {
											"labelClass": ["label-wrap"]
										},
										"caption": "$Caption",
										"markerValue": "$Caption",
										"domAttributes": "$_getReplicaItemDomAttributes"
									}
								]
							}
						]
					}
				}
			},
			{
				"operation": "insert",
				"name": "DefaultReplicaContainerBorder",
				"parentName": "LeftSideContainer",
				"propertyName": "items",
				"index": 2,
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"classes": {
						"wrapClassName": ["replica-caption-container-border"]
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "ToggleListButton",
				"parentName": "HeadersMainContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.BUTTON,
					"classes": {
						"wrapperClass": ["toggle-list-button"]
					},
					"click": {
						"bindTo": "onToggleListButtonClick"
					},
					"imageConfig": {
						"bindTo": "getToggleListButtonImageConfig"
					},
					"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"pressedClass": "toggle-list-button-pressed",
					"pressed": {
						"bindTo": "IsSideBarVisible"
					},
					"markerValue": "ToggleListButton",
					"visible": "$IsToggleListButtonVisible"
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
						"colSpan": 22,
						"rowSpan": 1
					}
				}
			},
			{
				"operation": "insert",
				"name": "ReplicasContainerInformationButton",
				"parentName": "ReplicasContainerCaptionGridLayout",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.INFORMATION_BUTTON,
					"content":  {bindTo: "Resources.Strings.ReplicaInformationButtonTooltip"},
					"style": BPMSoft.TipStyle.WHITE,
					"behaviour": {
						"displayEvent": this.BPMSoft.TipDisplayEvent.CLICK
					},
					"layout": {
						"column": 22,
						"row": 0,
						"colSpan": 2,
						"rowSpan": 1
					},

					"controlConfig": {
						"visible":  true,
						"imageConfig": informationButtonResources.localizableImages.DefaultIcon
					}
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
						"wrapClassName": ["replica-container-list"]
					},
					"itemPrefix": "View",
					"dataItemIdPrefix": "replica-item",
					"activeItem": "$ActiveReplicaMask",
					"onItemClick": "$onReplicaMaskChange",
					"defaultItemConfig": {
						"className": "BPMSoft.Container",
						"id": "replica-item-view",
						"selectors": {
							"wrapEl": "#replica-item-view"
						},
						"classes": {
							"wrapClassName": ["replica-item-wrapper-container"]
						},
						"items": [
							{
								"className": "BPMSoft.Container",
								"classes": {
									"wrapClassName": ["replica-item-wrapper-toggle"]
								},
								"items": [
									{
										"className": "BPMSoft.CheckBoxEdit",
										"classes": {
											"labelClass": ["toggle-wrap"]
										},
										"checked": "$UseSpecialHeaders"
									}
								]
							},
							{
								"className": "BPMSoft.Container",
								"classes": {
									"wrapClassName": ["replica-item-wrapper-caption"]
								},
								"items": [
									{
										"className": "BPMSoft.Label",
										"classes": {
											"labelClass": ["label-wrap"]
										},
										"caption": "$Caption",
										"markerValue": "$Caption",
										"domAttributes": "$_getReplicaItemDomAttributes"
									}
								]
							},
							{
								"className": "BPMSoft.Container",
								"items": [
									{
										"className": "BPMSoft.ImageView",
										"classes": {
											"wrapClass": ["right-arrow-icon-wrapper"]
										},
										"imageSrc":  "$_getArrowIcon",
										"visible": "$UseSpecialHeaders"
									}
								]
							}
						]
					}
				}
			},
			{
				"operation": "insert",
				"name": "HeadersCenterContainer",
				"parentName": "HeadersMainContainer",
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
				"name": "EmailHeadersContainer",
				"parentName": "HeadersCenterContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["email-headers-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "EmailHeadersGridLayout",
				"parentName": "EmailHeadersContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "SenderName",
				"parentName": "EmailHeadersGridLayout",
				"propertyName": "items",
				"values": {
					"caption":  resources.localizableStrings.SenderNameColumnCaption,
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"bindingContext": "SelectedReplicaItem",
					"controlConfig": {
						"enabled": "$UseSpecialHeaders"
					},
					"labelConfig": {"isRequired": true},
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 11,
						"rowSpan": 1
					}
				}
			},
			{
				"operation": "insert",
				"name": "SenderNameSelectMacroButton",
				"parentName": "EmailHeadersGridLayout",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"click": "$_onSenderNameSelectMacroButtonClick",
					"layout": {
						"column": 11,
						"row": 0,
						"colSpan": 1,
						"rowSpan": 1
					},
					"bindingContext": "SelectedReplicaItem",
					"visible": "$UseSpecialHeaders",
					"imageConfig": resources.localizableImages.BpmCrmMacrosIcon
				}
			},
			{
				"operation": "insert",
				"name": "SenderEmail",
				"parentName": "EmailHeadersGridLayout",
				"propertyName": "items",
				"values": {
					"caption": resources.localizableStrings.SenderEmailColumnCaption,
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"bindingContext": "SelectedReplicaItem",
					"controlConfig": {
						"enabled": "$UseSpecialHeaders"
					},
					"labelConfig": {"isRequired": true},
					"layout": {
						"column": 13,
						"row": 0,
						"colSpan": 11,
						"rowSpan": 1
					}
				}
			},
			{
				"operation": "insert",
				"name": "SenderEmailButtons",
				"parentName": "EmailHeadersGridLayout",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["email-sender-buttons-container"],
					"items": [],
					"layout": {
						"column": 23,
						"row": 0,
						"colSpan": 1,
						"rowSpan": 1
					}
				}
			},
			{
				"operation": "insert",
				"name": "SenderEmailSelectMacroButton",
				"parentName": "SenderEmailButtons",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"click": "$_onSenderEmailSelectMacroButtonClick",
					"bindingContext": "SelectedReplicaItem",
					"visible": "$UseSpecialHeaders",
					"imageConfig": resources.localizableImages.BpmCrmMacrosIcon
				}
			},
			{
				"operation": "insert",
				"name": "SenderEmailInfoButton",
				"parentName": "SenderEmailButtons",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.INFORMATION_BUTTON,
					"content": "$SenderEmailInfoButtonContent",
					"visible": "$SenderEmailInfoButtonTipVisible",
					"linkClicked": "$onSenderEmailInfoButtonClick",
					"style": "$SenderEmailInfoButtonStyle",
					"behaviour": {
						"displayEvent": this.BPMSoft.TipDisplayEvent.CLICK
					},
					"controlConfig": {
						"visible": "$SenderEmailInfoButtonVisible",
						"imageConfig": "$SenderEmailInfoButtonImageConfig"
					}
				}
			},
			{
				"operation": "insert",
				"name": "Subject",
				"parentName": "EmailHeadersGridLayout",
				"propertyName": "items",
				"values": {
					"caption": resources.localizableStrings.SubjectColumnCaption,
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"bindingContext": "SelectedReplicaItem",
					"controlConfig": {
						"enabled": "$UseSpecialHeaders",
						"injectionValue":  "$SubjectInsertBuffer"
					},
					"labelConfig": {"isRequired": true},
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 11,
						"rowSpan": 1
					}
				}
			},
			{
				"operation": "insert",
				"name": "SubjectSelectMacroButton",
				"parentName": "EmailHeadersGridLayout",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"click": "$_onSubjectSelectMacroButtonClick",
					"layout": {
						"column": 11,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					},
					"bindingContext": "SelectedReplicaItem",
					"visible": "$UseSpecialHeaders",
					"imageConfig": resources.localizableImages.BpmCrmMacrosIcon
				}
			},
			{
				"operation": "insert",
				"name": "PreHeader",
				"parentName": "EmailHeadersGridLayout",
				"propertyName": "items",
				"values": {
					"caption": resources.localizableStrings.PreHeaderColumnCaption,
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"bindingContext": "SelectedReplicaItem",
					"controlConfig": {
						"enabled": "$UseSpecialHeaders",
						"injectionValue":  "$PreHeaderInsertBuffer"
					},
					"layout": {
						"column": 13,
						"row": 1,
						"colSpan": 10,
						"rowSpan": 1
					}
				}
			},
			{
				"operation": "insert",
				"name": "PreHeaderSelectMacroButton",
				"parentName": "EmailHeadersGridLayout",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"click": "$_onPreHeaderSelectMacroButtonClick",
					"layout": {
						"column": 23,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					},
					"bindingContext": "SelectedReplicaItem",
					"visible": "$UseSpecialHeaders",
					"imageConfig": resources.localizableImages.BpmCrmMacrosIcon
				}
			},
			{
				"operation": "insert",
				"name": "PreviewNavigationButtonsContainer",
				"parentName": "HeadersCenterContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["preview-navigation-buttons-container"],
					"items": []
				}
			},
			{
				"operation": "remove",
				"name": "Header",
				"parentName": "PreviewNavigationButtonsContainer",
				"propertyName": "items"
			},
			{
				"operation": "remove",
				"name": "ContentDesigner"
			},
			{
				"operation": "insert",
				"name": "TemplateContentContainer",
				"parentName": "HeadersCenterContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["template-content-container"],
					"items": []
				}
			},
			{
				"operation": "move",
				"name": "Center",
				"parentName": "TemplateContentContainer",
				"propertyName": "items"
			},
			{
				"operation": "merge",
				"name": "Outside",
				"values": {
					"visible": "$_isPreviewVisible",
					"wrapClass": ["outsider-container scrolling-container"],
					"styles": {
						"overflow": "auto"
					}
				}
			},
			{
				"operation": "merge",
				"name": "PreviewDocument",
				"values": {
					"generator": function() {
						return {
							"className": "BPMSoft.IframeControl",
							"id": "PreviewDocumentIframe",
							"iframeContent": {
								"bindTo": "PreviewHtml"
							},
							"wrapClass": ["preview-document-iframe"],
							"fitHeightToContent": "true"
						};
					}
				}
			},
			{
				"operation": "insert",
				"name": "EmptyReplicaContainer",
				"parentName": "Center",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["empty-replica-container"],
					"items": [],
					"visible": "$_isEmptyReplicaContainerVisible"
				}
			},
			{
				"operation": "insert",
				"name": "EmptyReplicaImage",
				"parentName": "EmptyReplicaContainer",
				"propertyName": "items",
				"values": {
					"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
					"onPhotoChange": BPMSoft.emptyFn,
					"getSrcMethod": "getEmptyReplicaImageUrl",
					"classes": {
						"wrapClass": ["empty-replica-image"]
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "EmptyReplicaWarningLabel",
				"parentName": "EmptyReplicaContainer",
				"propertyName": "items",
				"values": {
					"className": "BPMSoft.MultilineLabel",
					"itemType": BPMSoft.ViewItemType.LABEL,
					"classes": {
						"labelClass": ["empty-replica-warning-label"]
					},
					"contentVisible": true,
					"caption": "$Resources.Strings.EmptyReplicaWarning"
				}
			},
			{
				"operation": "merge",
				"name": "NewTabButton",
				"values": {
					"enabled": "$_isPreviewVisible"
				}
			}
		] /**SCHEMA_DIFF*/
	};
});
