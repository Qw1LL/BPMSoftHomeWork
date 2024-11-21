define("BaseDCTemplateViewerSchema", ["ServiceHelper", "InformationButtonResources", "BulkEmailSenderValidator", "MacroUtils", "DCTemplateReplicaRepository", "ContainerListGenerator",
	"ContainerList", "PreviewReplicaViewModel", "css!BaseDCTemplateViewerSchema"], function(ServiceHelper, informationButtonResources, BulkEmailSenderValidator, MacroUtils) {

	var BaseDCTemplateViewerSchemaConsts = {
		SenderEmailDomainValidationKeyPrefix: "BaseDCTemplateViewerSchema_SenderEmail_ValidationResult_"
	};

	return {
		messages: {

			/**
			 * @message EntityInitialized
			 * Master's entity initialized event.
			 */
			"EntityInitialized": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message GetColumnsValues
			 * Requests the values of columns from target object.
			 */
			"GetColumnsValues": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			* @message GetProviderName 
			* Gets the current provider name.
			*/
			"GetProviderName": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message GetReplicaRepository
			 * Requests the instance of replica repository from master page.
			 */
			"GetReplicaRepository": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		attributes: {

			/**
			 * Selected replica subject.
			 */
			"Subject": {
				dataValueType: this.BPMSoft.DataValueType.TEXT,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Selected replica preheader.
			 */
			"PreHeader": {
				dataValueType: this.BPMSoft.DataValueType.TEXT,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Selected replica sender email.
			 */
			"SenderEmail": {
				dataValueType: this.BPMSoft.DataValueType.TEXT,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				onChange: "_onSenderEmailChanged"
			},

			/**
			 * Selected replica sender name.
			 */
			"SenderName": {
				dataValueType: this.BPMSoft.DataValueType.TEXT,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Collection of replica headers.
			 */
			"ReplicaHeadersCollection": {
				dataValueType: this.BPMSoft.DataValueType.BaseViewModelCollection,
				isCollection: true,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Replica item with default headers.
			 */
			"DefaultHeaders": {
				"dataValueType": this.BPMSoft.DataValueType.CUSTOM_OBJECT,
				"value": this.Ext.create("BPMSoft.BaseViewModel")
			},

			/**
			 * Contains content of displayed template.
			 */
			"TemplateBody": {
				dataValueType: this.BPMSoft.DataValueType.TEXT,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Indicates ToggleListButton visibility.
			 */
			"ToggleListButtonVisible": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: false
			},

			/**
			 * Indicates replica existence for selected bulk email.
			 */
			"HasReplica": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: false
			},

			/**
			 * Left list container visibility.
			 */
			"LeftContainerVisible": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: false
			},

			/**
			 * Master column name.
			 */
			"MasterColumnName": {
				dataValueType: this.BPMSoft.DataValueType.TEXT,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: "Id"
			},

			/**
			 * Replica collection.
			 */
			"ReplicaCollection": {
				columnPath: "ReplicaCollection",
				dataValueType: this.BPMSoft.DataValueType.COLLECTION,
				isCollection: true,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Indicates that the collection of replicas is loading.
			 */
			"IsReplicaCollectionLoading": {
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
			 * Indicates that the template is empty.
			 */
			"IsTemplateEmpty": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: true
			},

			/**
			 * Active item identifier.
			 */
			"ActiveItemId": {
				dataValueType: this.BPMSoft.DataValueType.GUID,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Source master column name.
			 */
			"SourceMasterColumnName": {
				dataValueType: this.BPMSoft.DataValueType.TEXT,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: "SourceEntityPrimaryColumnValue"
			},

			/**
			 * Content of the SenderEmailInfoButton.
			 */
			"SenderEmailInfoButtonContent": {
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: BPMSoft.DataValueType.TEXT
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
			 * Style of the SenderEmailInfoButton.
			 */
			"SenderEmailInfoButtonStyle": {
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: BPMSoft.DataValueType.TEXT,
				value: BPMSoft.TipStyle.WHITE
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
			 * Indicates if wizard feature enabled.
			 */
			"IsWizardMode": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
			}
		},

		methods: {

			// region Methods: Private

			/**
			 * Returns domain of the sender email.
			* @return {String} domain.
			*/
			_getSenderDomain: function() {
				var email = this.$SenderEmail || "";
				return email.replace(/^.*@/, "");
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
			 * Change handler for the sender email text box.
			 * @private
			 */
			_onSenderEmailChanged: function() {
				if (!this.$SenderEmail) {
					return;
				}
				this._senderEmailValidator();
			},

			/**
			 * Click handler for the sender email information button.
			 * @private
			 * @returns {boolean}
			 */
			_onSenderEmailInfoButtonClick: function() {
				this._openBpmCrmCloudIntegrationPage();
				return false;
			},

			/**
			 * Opens Bpmcrm Cloud Integration settings page.
			 */
			_openBpmCrmCloudIntegrationPage: function() {
				var pageName = "BpCloudIntegrationPageV2";
				var integrationPageUrl = Ext.String.format("{0}{1}/{2}/",
					BPMSoft.workspaceBaseUrl,
					"/Nui/ViewModule.aspx#CardModuleV2",
					pageName);
				window.open(integrationPageUrl);
			},

			/**
			* Validates sender email.
			* @private
			*/
			_senderEmailValidator: function() {
				var validationMessage = "";
				senderEmail = this.$SenderEmail
				if (MacroUtils.isStringContainsMacro(senderEmail)) {
					if (MacroUtils.isValueMacro(senderEmail)) {
						validationMessage = this.get("Resources.Strings.SenderMacroInfoMessage");
					} else {
						validationMessage = this.get("Resources.Strings.SenderMacroValidationMessage");
					}
					this._updateSenderEmailInfoButton(true, validationMessage);;
				} else {
					this._validateSenderDomain();
				}
			},

			/**
			 * Sets attributes to render sender email info button.
			 * @param {boolean} isValid Indicates weather domain successfully validated
			 * @param {string} message Custom message to show.
			 * @private
			 */
			_updateSenderEmailInfoButton: function(isValid, message) {
				var buttonVisible = !!this.$SenderEmail;
				this.$SenderEmailInfoButtonVisible = buttonVisible;
				if (!buttonVisible) {
					return;
				}
				if (this.$IsSenderEmailValid !== isValid) {
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

			/**
			* Validates sender domain to be confirmed and sets result to session cache.
			* @private
			*/
			_validateSenderDomain: function() {
				var domain = this._getSenderDomain();
				var sandbox = this.sandbox;
				var providerName = sandbox.publish("GetProviderName", [], [sandbox.id]);
				var cacheKey = BaseDCTemplateViewerSchemaConsts.SenderEmailDomainValidationKeyPrefix + providerName + "_" + domain;
				var cache = BPMSoft.ClientPageSessionCache;
				var cachedValue = cache.getItem(cacheKey);
				if (cachedValue) {
					this._updateSenderEmailInfoButton(cachedValue);
					return;
				}
				var validationConfig = {
					emailId: this.getRecordIdForRepository(),
					senderDomains: [domain],
					providerName: providerName
				};
				BulkEmailSenderValidator.validateDomains(validationConfig, function(result) {
					var isValid = result.Domains && result.Domains.length > 0 
						? result.Domains[0].IsValid
						: false;
					this._updateSenderEmailInfoButton(isValid);
					cache.setItem(cacheKey, isValid);
				}, this);
			},

			// endregion

			// region Methods: Protected			

			/**
			 * Returns class name of replica's row view model.
			 * @protected
			 * @return {String}
			 */
			getRowViewModelClassName: function() {
				return "BPMSoft.BaseModel";
			},

			/**
			 * Creates item view model.
			 * @param {Object} item Item data values.
			 * @return {BPMSoft.BaseModel} Item view model.
			 */
			createItemViewModel: function(item) {
				var rowViewModelClassName = this.getRowViewModelClassName();
				return this.Ext.create(rowViewModelClassName, {
					values: {
						Id: item.Id,
						Name: item.Name,
						Mask: item.Mask
					}
				});
			},

			/**
			 * Loads replicas content data and sets into TemplateBody attribute.
			 * @protected
			 * @param {Guid} replicaId Replica identifier.
			 * @param {Function} callback The callback function.
			 * @param {Object} scope The context in which the callback function will be called.
			 */
			loadReplicaContent: function(replicaId, callback, scope) {
				var replicaModel = this.$ReplicaCollection.get(replicaId);
				if (replicaModel.$Content) {
					this.set("TemplateBody", replicaModel.$Content);
					callback.call(scope);
					return;
				}
				var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "DCReplica"
				});
				esq.addColumn("Content");
				esq.getEntity(replicaId, function(response) {
					var content = response.success && response.entity.get("Content") || "";
					var sanitizedContent = BPMSoft.utils.html.sanitizeHTML(content);
					this.set("TemplateBody", sanitizedContent);
					replicaModel.$Content = sanitizedContent;
					callback.call(scope);
				}, this);
			},

			/**
			 * Indicates master record new operation state.
			 * @protected
			 * @return {Boolean} Master record new operation state.
			 */
			isNewMasterRecord: function() {
				var operation = this.getMasterColumnValueByName("Operation");
				return operation === this.BPMSoft.ConfigurationEnums.CardOperation.ADD;
			},

			/**
			 * Indicates master record copy operation state.
			 * @protected
			 * @return {Boolean} Master record copy operation state.
			 */
			isCopyMasterRecord: function() {
				var operation = this.getMasterColumnValueByName("Operation");
				return operation === this.BPMSoft.ConfigurationEnums.CardOperation.COPY;
			},

			/**
			 * Gets replica headers collection from service and fills view model headers attributes.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Scope for callback function.
			 */
			initReplicaHeaders: function(callback, scope) {
				this.$ReplicaHeadersCollection = Ext.create("BPMSoft.BaseViewModelCollection");
				var recordId = this.getRecordIdForRepository();
				var serviceContract = { BulkEmailId: recordId };
				ServiceHelper.callService("BulkEmailTemplateService", "GetBulkEmailReplicaHeaders",
					function (response) {
						this.$DefaultHeaders = this.mapHeadersResponseToViewModel(response.DefaultHeaders);
						var headers = response.Headers;
						BPMSoft.each(headers, function(replicaHeaders) {
							var viewModelItem = this.mapHeadersResponseToViewModel(replicaHeaders);
							this.$ReplicaHeadersCollection.add(viewModelItem.$ReplicaId, viewModelItem)
						}, this);
						callback.call(scope);
					}, serviceContract, this);
			},

			/**
			 * Maps service response to headers view model.
			 * @protected
			 * @param {Object} bulkEmailHeaders Represents replica headers.
			 */
			mapHeadersResponseToViewModel: function(bulkEmailHeaders) {
				var replicaHeadersViewModel = Ext.create("BPMSoft.BaseViewModel");
				replicaHeadersViewModel.$Subject = bulkEmailHeaders.Subject;
				replicaHeadersViewModel.$SenderEmail = bulkEmailHeaders.SenderEmail;
				replicaHeadersViewModel.$SenderName = bulkEmailHeaders.SenderName;
				replicaHeadersViewModel.$PreHeader = bulkEmailHeaders.Preheader;
				replicaHeadersViewModel.$ReplicaId = bulkEmailHeaders.ReplicaId;
				return replicaHeadersViewModel;
			},

			/**
			 * Fills collection of replicas view models from array with replicas data.
			 * @protected
			 * @param {Array} replicaItems Array containing the data of each replica.
			 */
			fillReplicaCollection: function(replicaItems) {
				var viewModelCollection = this.Ext.create("BPMSoft.BaseViewModelCollection");
				if (this.Ext.isArray(replicaItems)) {
					var hasItems = replicaItems.length > 0;
					this.$HasReplica = hasItems;
					this.$IsTemplateEmpty = !hasItems;
					this.BPMSoft.each(replicaItems, function(item) {
						var viewModel = this.createItemViewModel(item);
						viewModelCollection.add(item.Id, viewModel);
					}, this);
				}
				this.$ActiveItemId = null;
				this.$ReplicaCollection.clear();
				this.$ReplicaCollection.loadAll(viewModelCollection);
			},

			/**
			 * Returns column value from page by name.
			 * @protected
			 * @param {String} columnName Column name.
			 * @return {Object} Column value.
			 */
			getMasterColumnValueByName: function(columnName) {
				var columnValuesObj = this.sandbox.publish("GetColumnsValues", [columnName], [this.sandbox.id]);
				return columnValuesObj[columnName];
			},

			/**
			 * Calls replica repository method to load replicas.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback execution context.
			 */
			loadReplicasFromRepository: function(callback, scope) {
				if (this.isNewMasterRecord()) {
					this.Ext.callback(callback, scope);
					return;
				}
				this.$ReplicaRepository.loadAll(callback, scope);
			},

			/**
			 * Loads replicas data.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback execution context.
			 */
			loadReplicas: function(callback, scope) {
				this.$IsReplicaCollectionLoading = true;
				this.loadReplicasFromRepository(function(response) {
					if (response) {
						this.fillReplicaCollection(response);
					}
					this.$IsReplicaCollectionLoading = false;
					this.Ext.callback(callback, scope);
				}, this);
			},

			/**
			 * Loads template body from bulk email when replica collection is empty.
			 * @protected
			 */
			loadTemplateContentFromBulkEmail: function() {
				this.$ActiveItemId = null;
				this.set("TemplateBody", this.getMasterColumnValueByName("TemplateBody"));
				this.$IsTemplateEmpty = false;
				this.setHeaders();
			},

			/**
			 * Initializes detail items visibility.
			 * @protected
			 */
			initDetailItemsVisibility: function() {
				var replicaItems = this.$ReplicaCollection;
				var hasMoreThanOneItem = replicaItems.getCount() > 1;
				this.$LeftContainerVisible = hasMoreThanOneItem;
				this.$ToggleListButtonVisible = hasMoreThanOneItem;
			},

			/**
			 * Select first replica item.
			 * @protected
			 */
			selectFirstReplicaItem: function() {
				var replicaItems = this.$ReplicaCollection;
				var firstItem = replicaItems.first();
				if (firstItem) {
					this.onItemClick(firstItem.$Id);
				} else if (!this.$HasReplica) {
					this.loadTemplateContentFromBulkEmail();
				}
			},

			/**
			 * Returns record unique identifier to init replica repository.
			 * @protected
			 * @returns {String} Record unique identifier.
			 */
			getRecordIdForRepository: function() {
				if (this.isCopyMasterRecord()) {
					return this.getMasterColumnValueByName(this.$SourceMasterColumnName);
				}
				return this.getMasterColumnValueByName(this.$MasterColumnName);
			},

			/**
			 * Inits properties after load replicas.
			 * @protected
			 */
			afterReplicasLoaded: function() {
				this.initDetailItemsVisibility();
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#onRender
			 * @override
			 */
			onRender: function() {
				this.callParent(arguments);
				this.loadModuleData(this.selectFirstReplicaItem, this);
			},

			/**
			 * Subscribes on sandbox events.
			 * @protected
			 */
			subscribeSandboxEvents: function() {
				var sandbox = this.sandbox;
				sandbox.subscribe("EntityInitialized", this.onEntityInitialized, this, [sandbox.id]);
			},
			
			/**
			 * Handles entity initialization.
			 * @protected
			 */
			onEntityInitialized: function() {
				this.initReplicaRepository();
				this.loadModuleData(this.selectFirstReplicaItem, this);
			},

			/**
			 * Initializes replica repository for loading list of replica.
			 * @protected
			 */
			initReplicaRepository: function() {
				var sandbox = this.sandbox;
				var repository = sandbox.publish("GetReplicaRepository", [], [sandbox.id]);
				if (!repository) {
					repository = Ext.create("BPMSoft.DCTemplateReplicaRepository");
					var recordId = this.getRecordIdForRepository();
					repository.init(recordId);
				}
				this.$ReplicaRepository = repository;
			},

			/**
			 * Sets view model header properties by replica id.
			 * @protected
			 * @param {Guid} replicaId Replica item identifier.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback scope.
			 */
			setHeaders: function(replicaId, callback, scope) {
				var activeReplicaItem = this.$ReplicaHeadersCollection.contains(replicaId)
					? this.$ReplicaHeadersCollection.get(replicaId)
					: this.$DefaultHeaders;
				this.$Subject = activeReplicaItem.$Subject;
				this.$SenderEmail = activeReplicaItem.$SenderEmail;
				this.$SenderName = activeReplicaItem.$SenderName;
				this.$PreHeader = activeReplicaItem.$PreHeader;
				if (callback) {
					callback.call(scope);
				}
			},

			// endregion

			// region Methods: Public

			/**
			 * @inheritdoc BPMSoft.BasePageV2#init
			 * @override
			 */
			init: function(callback, scope) {
				this.$ReplicaCollection = this.Ext.create("BPMSoft.BaseViewModelCollection");
				this.$IsWizardMode = BPMSoft.Features.getIsEnabled("MarketingContentBuilderWizard");
				this.callParent([function() {
					this.subscribeSandboxEvents();
					this.initReplicaRepository();
					callback.call(scope);
				}, this]);
			},

			/**
			 * Loads replicas and headers data.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback scope.
			 */
			loadModuleData: function(callback, scope) {
				BPMSoft.chain(
					function(next) {
						this.loadReplicas(next, this);
					},
					function(next) {
						this.initReplicaHeaders(next, this);
					},
					function(next) {
						this.afterReplicasLoaded();
						next();
					},
					function() {
						if(callback) {
							callback.call(scope);
						}
					},
				this);
			},

			/**
			 * Handles click event on replica item.
			 * @param {Guid} itemId Selected item identifier.
			 */
			onItemClick: function(itemId) {
				if (itemId === this.$ActiveItemId) {
					return;
				}
				this.$ActiveItemId = itemId;
				this.showBodyMask();
				this.loadReplicaContent(itemId, function() {
					this.setHeaders(itemId, this.hideBodyMask, this);
				}, this);

			},

			/**
			 * Handles toggle list button click event.
			 */
			onToggleListButtonClick: function() {
				var newLeftContainerVisible = !this.$LeftContainerVisible;
				this.$LeftContainerVisible = newLeftContainerVisible;
				// TODO: Remove after fix bugs in ContainerList.
				if (newLeftContainerVisible) {
					var itemId = this.$ActiveItemId;
					this.$ActiveItemId = null;
					this.$ActiveItemId = itemId;
				}
			},

			/**
			 * Returns tools visibility.
			 * @return {Boolean} True if control group tools should be visible, otherwise false.
			 */
			getToolsVisible: function() {
				return !this.get("IsViewerControlGroupCollapsed");
			},

			/**
			 * Generates config for icons of toggle list button.
			 * @return {Object} Toggle list button image config.
			 */
			getToggleListButtonImageConfig: function() {
				return this.getResourceImageConfig("Resources.Images.ToggleListButtonImage");
			},

			/**
			 * Handles a change of control group collapsing state.
			 * @param {Boolean} isCollapsed True if control group is collapsed, otherwise false.
			 */
			onViewerControlGroupCollapsedChanged: function(isCollapsed) {
				this.set("IsViewerControlGroupCollapsed", isCollapsed);
			}

			// endregion

		},
		diff: /**SCHEMA_DIFF*/ [{
				"operation": "insert",
				"name": "BaseDCTemplateViewerControlGroup",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTROL_GROUP,
					"caption": {
						"bindTo": "Resources.Strings.Title"
					},
					"items": [],
					"tools": [],
					"controlConfig": {
						"collapsedchanged": {
							"bindTo": "onViewerControlGroupCollapsedChanged"
						},
						"collapsed": {
							"bindTo": "IsViewerControlGroupCollapsed"
						},
						"classes": ["detail", "base-dc-template-viewer-control-group"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "OuterContainer",
				"parentName": "BaseDCTemplateViewerControlGroup",
				"values": {
					"id": "BaseDCTemplateViewerOuterContainer",
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"items": []
				},
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "InnerContainer",
				"parentName": "OuterContainer",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"classes": {
						"wrapClassName": ["base-dc-template-viewer-inner-container"]
					},
					"visible": {
						"bindTo": "IsTemplateEmpty",
						"bindConfig": {
							"converter": "invertBooleanValue"
						}
					},
					"items": []
				},
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "ToggleListButton",
				"parentName": "InnerContainer",
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
						"bindTo": "LeftContainerVisible"
					},
					"markerValue": "ToggleListButton",
					"visible": {
						"bindTo": "ToggleListButtonVisible"
					}
				}
			},
			{
				"operation": "insert",
				"name": "LeftContainer",
				"parentName": "InnerContainer",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"classes": {
						"wrapClassName": ["base-dc-template-viewer-left-container"]
					},
					"visible": {
						"bindTo": "LeftContainerVisible"
					},
					"items": []
				},
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "RightContainer",
				"parentName": "InnerContainer",
				"values": {
					"id": "BaseDCTemplateViewerRightContainer",
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"classes": {
						"wrapClassName": ["base-dc-template-viewer-right-container"]
					},
					"items": []
				},
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "EmailHeadersContainer",
				"parentName": "RightContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"visible": "$IsWizardMode"
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
					"caption":  {"bindTo": "Resources.Strings.SenderNameCaption"},
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"value": "$SenderName",
					"controlConfig": {
						"enabled": false
					},
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
				"name": "SenderEmail",
				"parentName": "EmailHeadersGridLayout",
				"propertyName": "items",
				"values": {
					"caption": {"bindTo": "Resources.Strings.SenderEmailCaption"},
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"value": "$SenderEmail",
					"controlConfig": {
						"enabled": false
					},
					"layout": {
						"column": 13,
						"row": 0,
						"colSpan": 10,
						"rowSpan": 1
					}
				}
			},
			{
				"operation": "insert",
				"name": "SenderEmailInfoButton",
				"parentName": "EmailHeadersGridLayout",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.INFORMATION_BUTTON,
					"content": "$SenderEmailInfoButtonContent",
					"visible": "$SenderEmailInfoButtonTipVisible",
					"linkClicked": "$_onSenderEmailInfoButtonClick",
					"style": "$SenderEmailInfoButtonStyle",
					"behaviour": {
						"displayEvent": this.BPMSoft.TipDisplayEvent.CLICK
					},
					"controlConfig": {
						"visible": "$SenderEmailInfoButtonVisible",
						"imageConfig": "$SenderEmailInfoButtonImageConfig"
					},
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
				"name": "Subject",
				"parentName": "EmailHeadersGridLayout",
				"propertyName": "items",
				"values": {
					"caption": {"bindTo": "Resources.Strings.SubjectCaption"},
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"value": "$Subject",
					"controlConfig": {
						"enabled": false
					},
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 24,
						"rowSpan": 1
					}
				}
			},
			{
				"operation": "insert",
				"name": "PreHeader",
				"parentName": "EmailHeadersGridLayout",
				"propertyName": "items",
				"values": {
					"caption": {"bindTo": "Resources.Strings.PreHeaderCaption"},
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"value": "$PreHeader",
					"controlConfig": {
						"enabled": false
					},
					"layout": {
						"column": 0,
						"row": 2,
						"colSpan": 24,
						"rowSpan": 1
					}
				}
			},
			{
				"operation": "insert",
				"name": "TemplateHtml",
				"parentName": "RightContainer",
				"propertyName": "items",
				"values": {
					"generator": function() {
						return {
							"className": "BPMSoft.IframeControl",
							"wrapClass": ["template-html-iframe"],
							"iframeContent": {
								"bindTo": "TemplateBody"
							},
							"fitHeightToContent": true
						};
					}
				}
			},
			{
				"operation": "insert",
				"name": "ReplicasContainerList",
				"parentName": "LeftContainer",
				"propertyName": "items",
				"values": {
					"idProperty": "Id",
					"rowCssSelector": ".replica-item",
					"itemType": this.BPMSoft.ViewItemType.GRID,
					"collection": {
						"bindTo": "ReplicaCollection"
					},
					"generator": "ContainerListGenerator.generatePartial",
					"maskVisible": {
						"bindTo": "IsReplicaCollectionLoading"
					},
					"maskTimeout": 100,
					"selectableRowCss": "replica-item",
					"classes": {
						"wrapClassName": ["replica-container-list"]
					},
					"itemPrefix": "View",
					"dataItemIdPrefix": "replica-item",
					"isAsync": false,
					"activeItem": {
						"bindTo": "ActiveItemId"
					},
					"onItemClick": {
						"bindTo": "onItemClick"
					},
					"defaultItemConfig": {
						"className": "BPMSoft.Container",
						"id": "replica-item-view",
						"selectors": {
							"wrapEl": "#replica-item-view"
						},
						"classes": {
							"wrapClassName": ["replica-item-wrapper-container"]
						},
						"items": [{
							"className": "BPMSoft.Label",
							"classes": {
								"labelClass": ["label-wrap"]
							},
							"caption": {
								"bindTo": "Name"
							},
							"markerValue": {
								"bindTo": "Name"
							}
						}]
					}
				}
			}
		] /**SCHEMA_DIFF*/
	};
});
