define("BaseEnrichmentSchema", ["ConfigurationConstants", "AcademyUtilities", "CommunicationUtils",
	"BaseEnrichmentViewModel", "css!BaseEnrichmentSchemaCSS", "ContainerList"],
	function(ConfigurationConstants, AcademyUtilities, CommunicationUtils) {
	return {
		messages: {
			/**
			 * Hide enrichment data module container.
			 * @message HideEnrichmentDataModule
			 */
			"HideEnrichmentDataModule": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message GetDetailId
			 * Gets detail id by name.
			 */
			"GetDetailId": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message SyncCommunication
			 * Synchronizes communications.
			 */
			"SyncCommunication": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * Show enrichment data module container.
			 * @message ShowEnrichmentDataModule
			 */
			"ShowEnrichmentDataModule": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * Message of the column values by name.
			 * @message GetColumnsValues
			 */
			"GetColumnsValues": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message UpdateCardProperty
			 * Updates card property.
			 */
			"UpdateCardProperty": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message ReloadCard
			 * Reloads card.
			 */
			"ReloadCard": {
				"mode": BPMSoft.MessageMode.PTP,
				"direction": BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		attributes: {
			/**
			 * Detail column mapping.
			 * @type {Object[]}
			 * Example:
			 * DetailColumnMapping: [
			 *	{
			 *		CommunicationType: ConfigurationConstants.CommunicationTypes.Email,
			 *		TagName: "email"
			 *	}
			 * ]
			 */
			"DetailColumnMapping": {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
				value: [
					{
						CommunicationType: ConfigurationConstants.CommunicationTypes.Facebook,
						TagName: "facebook"
					},
					{
						CommunicationType: ConfigurationConstants.CommunicationTypes.Twitter,
						TagName: "twitter"
					},
					{
						CommunicationType: ConfigurationConstants.CommunicationTypes.Email,
						TagName: "email"
					},
					{
						CommunicationType: ConfigurationConstants.CommunicationTypes.MainPhone,
						TagName: "phone"
					}
				]
			},
			/**
			 * Is visible module flag.
			 * @type {Boolean}
			 */
			"IsVisible": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				value: true
			},
			"MainCheckboxValue": {
				name: "MainCheckboxValue",
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: true,
			},
			/**
			 * Signs if refresh button is visible.
			 * @type {Boolean}
			 */
			IsRefreshButtonVisible: {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				value: true
			},
			/**
			 * Primary column name.
			 * @type {String}
			 */
			"PrimaryColumnName": {
				dataValueType: this.BPMSoft.DataValueType.TEXT,
				value: null
			},
			/**
			 * Primary column value.
			 * @type {String}
			 */
			"PrimaryColumnValue": {
				dataValueType: this.BPMSoft.DataValueType.GUID,
				value: null
			},
			/**
			 * Collection of the enrichment data list.
			 * @type {BPMSoft.BaseViewModelCollection}
			 */
			"EnrichmentDataCollection": {
				dataValueType: this.BPMSoft.DataValueType.COLLECTION,
				value: null
			},
			/**
			 * Enrichment data count.
			 * @type {Number}
			 */
			"EnrichmentDataCount": {
				dataValueType: this.BPMSoft.DataValueType.INTEGER,
				value: 0
			},
			/**
			 * Collection of the communication types.
			 * @type {BPMSoft.BaseViewModelCollection}
			 */
			"CommunicationTypesCollection": {
				dataValueType: this.BPMSoft.DataValueType.COLLECTION,
				value: null
			},
			/**
			 * Id of the container to which align this module.
			 * @type {String}
			 */
			"AlignToElId": {
				dataValueType: this.BPMSoft.DataValueType.TEXT,
				value: null
			},
			/**
			 * Enrichment data is loaded.
			 * @type {Boolean}
			 */
			"IsDataLoaded": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				value: false
			},
			/**
			 * Communication detail name for sync.
			 * @type {String}
			 */
			"CommunicationDetailName": {
				dataValueType: this.BPMSoft.DataValueType.TEXT,
				value: null
			},
			/**
			 * Enrichment data service request timeout.
			 * @type {Number}
			 */
			"ServiceRequestTimeOut": {
				dataValueType: this.BPMSoft.DataValueType.INTEGER,
				value: 60000
			},
			/**
			 * Last enrichment action.
			 * @type {String}
			 */
			"LastAction": {
				dataValueType: this.BPMSoft.DataValueType.TEXT,
				value: null
			},
			/**
			 * Academy url.
			 * @protected
			 * @type {String}
			 */
			"AcademyHelpUrl": {
				"dataValueType": BPMSoft.DataValueType.TEXT,
				"value": ""
			},
			/**
			 * Fail reason of last enrichment call result.
			 * @protected
			 * @type {String}
			 */
			"LastEnrichmentRequestFailReason": {
				"dataValueType": BPMSoft.DataValueType.TEXT,
				"value": ""
			}
		},
		methods: {
			/**
			 * Resizes align container height due to loaded data.
			 * @private
			 */
			_adjustContainerHeight: function() {
				const alignContainer = this.Ext.getCmp("EnrichmentContainerWrapper");
				if (BPMSoft.get(alignContainer || {}, "alignConfig.alignConfig.alignType") ===
						BPMSoft.AlignType.TOP) {
					alignContainer.fireEvent("adjustPosition", {hasCenterPosition: false});
				}
			},

			/**
			 * @inheritdoc BPMSoft.configuration.BaseSchemaViewModel#init
			 * @override
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback scope.
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this.getHelpUrl(callback, scope || this);
				}, this]);
				this.subscribeSandboxEvents();
				this.subscribeChangeAttributes();
				this.initCollection();
				this.initPrimaryColumnValue();
				BPMSoft.chain(this.loadCommunicationTypes, this.loadEnrichmentData, this);
				this.on("change:LastAction", this.onLastActionChanged, this);
				this.on("change:MainCheckboxValue", this.onMainCheckboxValueChanged, this)
			},

			onEnrichmentItemChanged: function(changedItem){
				if("IsChecked" in changedItem.changedValues){
					let collection = this.get("EnrichmentDataCollection");
					let mainCheckboxValue = true;
					collection.each(function(item){
						if(!item.get("IsChecked")){
							mainCheckboxValue = false;
						}
					}, this)
					this.un("change:MainCheckboxValue", this.onMainCheckboxValueChanged, this)
					if(this.get("MainCheckboxValue") !== mainCheckboxValue){
						this.set("MainCheckboxValue", mainCheckboxValue)
					}
					this.on("change:MainCheckboxValue", this.onMainCheckboxValueChanged, this)
				};
			},

			onMainCheckboxValueChanged: function(){
				let value = this.get("MainCheckboxValue");
				let collection = this.get("EnrichmentDataCollection");
				collection.un("itemChanged", this.onEnrichmentItemChanged, this);
				collection.each(function(item){
					item.set("IsChecked", value);
				}, this)
				collection.on("itemChanged", this.onEnrichmentItemChanged, this);
			},

			/**
			 * Forms academy message content.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback scope.
			 */
			getHelpUrl: function(callback, scope) {
				var callbackFunc = function(helpUrl) {
					this.set("AcademyHelpUrl", helpUrl);
					Ext.callback(callback, scope || this);
				}.bind(this);
				var config = {
					callback: callbackFunc,
					scope: this,
					contextHelpId: 1644,
					contextHelpCode: "BaseEnrichmentSchema"
				};
				AcademyUtilities.getUrl(config);
			},

			/**
			 * Handler of the enrichment action attribute change event.
			 * @protected
			 * @virtual
			 */
			onLastActionChanged: function() {
				this.sendGoogleTagManagerData();
			},

			/**
			 * Load communication types.
			 * @protected
			 * @abstract
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			loadCommunicationTypes: function(callback, scope) {
				this.Ext.callback(callback, scope || this);
			},

			/**
			 * Subscribes on messages of the sandbox.
			 * @protected
			 */
			subscribeSandboxEvents: function() {
				this.sandbox.subscribe("ShowEnrichmentDataModule", this.showModule, this, [this.sandbox.id]);
			},

			/**
			 * Subscribes on change of the view model attributes.
			 * @protected
			 */
			subscribeChangeAttributes: function() {
				this.subscribeOnColumnChange("IsDataLoaded", this.toggleLoadingMask, this);
				this.subscribeOnColumnChange("EnrichmentDataCount", this.publishEnrichedDataCount, this);
			},

			/**
			 * Init primary column value.
			 * @protected
			 */
			initPrimaryColumnValue: function() {
				var primaryColumnName = this.get("PrimaryColumnName");
				var columnsValues = this.sandbox.publish("GetColumnsValues", [primaryColumnName], [this.sandbox.id]);
				if (this.isNotEmpty(columnsValues)) {
					this.set("PrimaryColumnValue", columnsValues[primaryColumnName]);
				}
			},

			/**
			 * Initialize enrichment data collection.
			 * @protected
			 */
			initCollection: function() {
				var collection = this.get("EnrichmentDataCollection");
				if (this.isEmpty(collection)) {
					this.set("EnrichmentDataCollection", this.Ext.create("BPMSoft.BaseViewModelCollection"));
				}
			},

			/**
			 * Toggle showing or hides load mask.
			 * @protected
			 */
			toggleLoadingMask: function() {
				var selector = ".enrichment-container-wrapper";
				this.hideBodyMask({selector: selector});
				var isDataLoaded = this.get("IsDataLoaded");
				if (isDataLoaded) {
					return;
				}
				var caption = this.get("Resources.Strings.MaskLoadingCaption");
				this.showBodyMask({
					selector: selector,
					caption: caption,
					timeout: 0
				});
			},

			/**
			 * Hides module container.
			 * @protected
			 */
			hideModule: function() {
				this.set("IsVisible", false);
				this.sandbox.publish("HideEnrichmentDataModule", null, [this.sandbox.id]);
			},

			/**
			 * Hides module container.
			 * @protected
			 */
			closeWithoutSave: function() {
				this.set("LastAction", "Cancel");
				this.hideModule();
			},

			/**
			 * Shows module container.
			 * @protected
			 */
			showModule: function() {
				this.set("IsVisible", true);
			},

			/**
			 * Loads enrichment data from server.
			 * @protected
			 */
			loadEnrichmentData: function() {
				this.set("IsDataLoaded", false);
				this.selectExistingEnrichedData(function(response) {
					var collection = response && response.collection;
					if (collection && !collection.isEmpty()) {
						this.onLoadEnrichmentData(response);
						return;
					}
					this.executeEnrichmentDataService(this.onLoadEnrichmentData, this);
				});
			},

			/**
			 * Handler of the response enrichment data collection.
			 * @protected
			 * @param {Object} response Response object.
			 * @param {BPMSoft.Collection} response.collection Enrichment data collection.
			 */
			onLoadEnrichmentData: function(response) {
				let responseCollection = response && response.collection;
				const collection = this.get("EnrichmentDataCollection");
				collection.clear();
				if (this.isNotEmpty(responseCollection)) {
					const communicationTypes = this.$CommunicationTypesCollection;
					responseCollection = responseCollection.filterByFn(function(item) {
						const communicationId = this.getCommunicationTypeId(item.$CategoryTag);
						if (communicationTypes.findByAttr("Id", communicationId)) {
							return true;
						} else {
							this.warning(this.Ext.String.format(
								"Communication type {0} is not enabled. Skipped enriched data {1}",
								communicationId, item.$Value));
							return false;
						}
					}, this);
					collection.on("itemChanged", this.onEnrichmentItemChanged, this);
					collection.loadAll(responseCollection);
				}
				this.set("EnrichmentDataCollection", null);
				this.set("EnrichmentDataCollection", collection);
				this.set("IsDataLoaded", true);
				this._adjustContainerHeight();
				this.updateEnrichemntDataCount();
			},

			/**
			 * Gets existing enriched record from table.
			 * @protected
			 * @virtual
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback scope.
			 */
			selectExistingEnrichedData: function(callback, scope) {
				var esq = this.getEntitySchemaQuery();
				esq.execute(callback, scope || this);
			},

			/**
			 * Gets instance of the ESQ for enriched data from table with default parameters.
			 * @abstract
			 * @protected
			 * @return {BPMSoft.EntitySchemaQuery} Entity schema query.
			 */
			getEntitySchemaQuery: BPMSoft.abstractFn,

			/**
			 * Gets mapping value by tag name.
			 * @protected
			 * @param {String} tagName Enriched data tag name.
			 * @return {String} Returns communication type UId.
			 */
			getCommunicationTypeId: function(tagName) {
				var defaultCommunicationType = ConfigurationConstants.CommunicationTypes.Web;
				var detailColumnMapping = this.get("DetailColumnMapping");
				var communicationMap = BPMSoft.findWhere(detailColumnMapping, {TagName: tagName});
				return communicationMap ? communicationMap.CommunicationType : defaultCommunicationType;
			},

			/**
			 * Gets is not empty collection.
			 * @protected
			 * @return {Boolean} True if collection is not empty.
			 */
			getIsNotEmptyCollection: function() {
				var collection = this.get("EnrichmentDataCollection");
				return collection && !collection.isEmpty();
			},

			/**
			 * Gets if refresh button is visible.
			 * @protected
			 */
			getIsRefreshButtonVisible: function() {
				return this.getIsNotEmptyCollection() && this.get("IsRefreshButtonVisible");
			},

			/**
			 * Returns selected items collection.
			 * @protected
			 * @return {BPMSoft.Collection} Selected items collection.
			 */
			getSelectedItemsCollection: function() {
				var collection = this.get("EnrichmentDataCollection");
				return collection.filterByFn(function(item) {
					return item.get("IsChecked");
				}, this);
			},
			/**
			 * Handler on load communication types.
			 * @protected
			 * @param {Object} response Response from server.
			 */
			onLoadCommunicationTypes: function(response) {
				if (this.isEmpty(response)) {
					return;
				}
				var collection = this.Ext.create("BPMSoft.BaseViewModelCollection");
				var responseCollection = response.collection;
				collection.loadAll(responseCollection);
				this.set("CommunicationTypesCollection", collection);
			},

			/**
			 * Close module.
			 */
			closeModule: function() {
				this.hideBodyMask();
				this.hideModule();
			},

			/**
			 * Updates Enrichment data count attribute.
			 * @protected
			 */
			updateEnrichemntDataCount: function() {
				var collection = this.get("EnrichmentDataCollection");
				this.set("EnrichmentDataCount", collection.getCount());
			},

			/**
			 * Publish message about of the count enriched data.
			 * @protected
			 */
			publishEnrichedDataCount: function() {
				var count = this.get("EnrichmentDataCount");
				this.sandbox.publish("UpdateCardProperty", {
					key: "EnrichedDataCount",
					value: count
				}, [this.sandbox.id]);
			},

			/**
			 * Returns delete enriched data query.
			 * @protected
			 * @return {BPMSoft.DeleteQuery} Delete enriched data query.
			 */
			getDeleteQuery: function() {
				return this.Ext.create("BPMSoft.DeleteQuery", {
					rootSchemaName: this.entitySchemaName
				});
			},

			/**
			 * Clear enriched data and calls enrichment data service.
			 * @protected
			 */
			refreshEnrichmentData: function() {
				this.set("IsDataLoaded", false);
				this.set("LastAction", "Refresh");
				this._adjustContainerHeight();
				this.clearEnrichedData(function() {
					this.executeEnrichmentDataService(this.onLoadEnrichmentData, this);
				}, this);
			},

			/**
			 * Executes enrichment data service.
			 * @abstract
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Execution context.
			 */
			executeEnrichmentDataService: BPMSoft.abstractFn,

			/**
			 * Handler on execute enrichment data service.
			 * @protected
			 * @virtual
			 * @param {Object} response Response from server.
			 */
			onExecuteEnrichmentDataService: function(response) {
				if (BPMSoft.isEmptyObject(response)) {
					BPMSoft.showInformation(this.get("Resources.Strings.EnricmentServiceBadRequest"));
				}
			},

			/**
			 * Gets caption of the header container.
			 * @protected
			 */
			getHeaderCaption: function() {
				var header;
				var isNotEmptyCollection = this.getIsNotEmptyCollection();
				if (isNotEmptyCollection) {
					header = this.get("Resources.Strings.HeaderCaption");
				} else {
					header = this.get("LastEnrichmentRequestFailReason");
				}
				if (!header) {
					var emptyDataReasonTemplateMessage = this.get("Resources.Strings.NotFoundItems");
					header = Ext.String.format(emptyDataReasonTemplateMessage, this.get("AcademyHelpUrl"));
				}
				return header;
			},

			/**
			 * Saves enrichment data.
			 * @protected
			 * @virtual
			 */
			saveData: function() {
				this.showBodyMask();
				this.set("LastAction", "Save");
				var detailId = this.sandbox.publish("GetDetailId",
					this.get("CommunicationDetailName"), [this.sandbox.id]);
				if (detailId) {
					this.syncDataWithDetail(detailId);
					return;
				}
				this.saveDataToDatabase();
			},

			/**
			 * Saves synced enriched data to database.
			 * @protected
			 * @virtual
			 */
			saveDataToDatabase: Ext.emptyFn,

			/**
			 * Handler of the after saved data to the database.
			 * @protected
			 */
			onSaveDataToDatabase: function() {
				this.clearEnrichedData(function() {
					this.sandbox.publish("ReloadCard", null, [this.get("PrimaryColumnValue")]);
					this.closeModule();
				}, this);
			},

			/**
			 * Synchronizes enriched data with communication detail.
			 * @protected
			 * @param {String} detailId Communication detail id for sandbox.
			 */
			syncDataWithDetail: function(detailId) {
				var syncedCollection = this.getSelectedItemsCollection();
				syncedCollection.each(function(item) {
					var communicationTypeId = this.getCommunicationTypeId(item.get("CategoryTag"));
					this.sandbox.publish("SyncCommunication", {
						communicationTypeId: communicationTypeId,
						syncColumnValue: item.get("Value"),
						syncOldColumnValue: item.getPrevious("Value"),
						isSynced: false
					}, [detailId]);
				}, this);
				this.clearEnrichedData(this.closeModule, this);
			},

			/**
			 * Clears enriched data.
			 * @protected
			 * @virtual
			 * @param {Function} [callback] Callback function.
			 * @param {Object} [scope] Execution context.
			 */
			clearEnrichedData: function(callback, scope) {
				this.onClearEnrichedData(callback, scope);
			},

			/**
			 * Handler of the cleared enriched data.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			onClearEnrichedData: function(callback, scope) {
				this.clearEnrichmentDataCollection();
				this.updateEnrichemntDataCount();
				Ext.callback(callback, scope);
			},

			/**
			 * Clears enrichment data collection.
			 * @private
			 */
			clearEnrichmentDataCollection: function() {
				var collection = this.get("EnrichmentDataCollection");
				if (collection) {
					collection.clear();
					this.updateEnrichemntDataCount();
				}
			},

			/**
			 * Handler of the configuration row of the container list.
			 * @virtual
			 * @protected
			 * @param {Object} itemConfig Config of the item.
			 * @param {BPMSoft.BaseViewModel} item ViewModel.
			 */
			onGetCollectionItemConfig: function(itemConfig, item) {
				var labelCaption = this.getItemCaption(item);
				var isPhone = this._getIsPhoneItem(item);
				itemConfig.config = {
					"className": "BPMSoft.Container",
					"classes": {
						"wrapClassName": ["enrichment-data-row"]
					},
					"items": [
						{
							"className": "BPMSoft.Container",
							"classes": {
								"wrapClassName": ["check-box-wrap"]
							},
							"items": [{
								"className": "BPMSoft.CheckBoxEdit",
								"checked": {"bindTo": "IsChecked"},
								"markerValue": {"bindTo": "getMarkerValue"}
							}]
						},
						{
							"className": "BPMSoft.Container",
							"classes": {
								"wrapClassName": ["label-wrap"]
							},
							"items": [{
								"className": "BPMSoft.Label",
								"caption": labelCaption
							}]
						},
						{
							"className": "BPMSoft.Container",
							"classes": {
								"wrapClassName": ["control-wrap"]
							},
							"items": [{
								"className": isPhone ? "BPMSoft.PhoneEdit" : "BPMSoft.TextEdit",
								"value": {"bindTo": "Value"},
								"showValueAsLink": {"bindTo": "getIsLinkData"},
								"href": {"bindTo": "getHref"},
								"linkclick": {"bindTo": "onLinkClick"},
								"markerValue": {"bindTo": "getMarkerValue"}
							}]
						}
					]
				};
			},

			/**
			 * Returns the caption for the enriched data item control.
			 * @protected
			 * @abstract
			 * @param {BPMSoft.BaseViewModel} item The enriched data item.
			 * @return {String} The item caption.
			 */
			getItemCaption: BPMSoft.abstractFn,

			/**
			 * Check if the row item is a phone.
			 * @param {BPMSoft.BaseViewModel} item The enriched data item.
			 * @private
			 * @return {Boolean} True if item row is a phone.
			 */
			_getIsPhoneItem: function(item) {
				const communicationTypeId = this.getCommunicationTypeId(item.get("CategoryTag"));
				return CommunicationUtils.isPhoneType(communicationTypeId);
			},

			/**
			 * Returns the name of the row item view model class.
			 * @protected
			 * @virtual
			 * @return {String}
			 */
			getRowViewModelClassName: function() {
				return "BPMSoft.configuration.BaseEnrichmentViewModel";
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "EnrichmentContainerWrapper",
				"values": {
					"id": "EnrichmentContainerWrapper",
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"className": "BPMSoft.AlignableContainer",
					"alignToEl": null,
					"wrapClass": ["enrichment-container-wrapper"],
					"markerValue": "enrichment-container",
					"onHideContainer": {"bindTo": "hideModule"},
					"visible": {"bindTo": "IsVisible"},
					"hideOnDocEvents": true,
					"alignOrder": [BPMSoft.AlignType.RIGHT, BPMSoft.AlignType.TOP],
					"containerOffsets": {
						"right": {"x": 28}
					},
					"items": [],
					"afterrender": {"bindTo": "toggleLoadingMask"}
				}
			},
			{
				"operation": "insert",
				"name": "EnrichmentContainer",
				"parentName": "EnrichmentContainerWrapper",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["enrichment-container"],
					"items": [],
					"visible": {"bindTo": "IsDataLoaded"}
				}
			},
			{
				"operation": "insert",
				"name": "EnrichmentHeaderCaption",
				"parentName": "EnrichmentContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.COMPONENT,
					"className": "BPMSoft.HtmlControl",
					"htmlContent": {"bindTo": "getHeaderCaption"},
					"classes": {
						"wrapClass": ["enrichment-header-caption"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "EnrichmentCloseButton",
				"parentName": "EnrichmentContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"classes": {
						"textClass": "enrichment-close-button"
					},
					"click": {"bindTo": "hideModule"}
				}
			},
			{
				"operation": "insert",
				"parentName": "EnrichmentContainer",
				"propertyName": "items",
				"name": "MainCheckboxValue",
				"values": {
					"bindTo": "MainCheckboxValue",
					"labelConfig": {"visible": false},
				}
			},
			{
				"operation": "insert",
				"name": "EnrichmentContainerList",
				"parentName": "EnrichmentContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"className": "BPMSoft.ContainerList",
					"collection": {"bindTo": "EnrichmentDataCollection"},
					"classes": {"wrapClassName": ["enrichment-container-list"]},
					"onGetItemConfig": {"bindTo": "onGetCollectionItemConfig"},
					"idProperty": "Id",
					"itemPrefix": "EnrichmentContainerList",
					"defaultItemConfig": {},
					"visible": {"bindTo": "getIsNotEmptyCollection"}
				}
			},
			{
				"operation": "insert",
				"name": "EnrichmentContainerBottom",
				"parentName": "EnrichmentContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["enrichment-container-bottom"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "EnrichmentRefreshButton",
				"parentName": "EnrichmentContainerBottom",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"imageConfig": {"bindTo": "Resources.Images.RefreshIcon"},
					"classes": {
						"wrapperClass": ["enrichment-refresh-button"]
					},
					"click": {"bindTo": "refreshEnrichmentData"},
					"visible": {"bindTo": "getIsRefreshButtonVisible"},
					"hint": {"bindTo": "Resources.Strings.RefreshButtonHint"}
				}
			},
			{
				"operation": "insert",
				"name": "EnrichmentCloseButton",
				"parentName": "EnrichmentContainerBottom",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"classes": {
						"textClass": ["enrichment-close-button"]
					},
					"click": {"bindTo": "closeWithoutSave"},
					"caption": {"bindTo": "Resources.Strings.CloseButtonCaption"}
				}
			},
			{
				"operation": "insert",
				"name": "EnrichmentSaveButton",
				"parentName": "EnrichmentContainerBottom",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
					"classes": {
						"textClass": "enrichment-save-button"
					},
					"click": {"bindTo": "saveData"},
					"caption": {"bindTo": "Resources.Strings.SaveButtonCaption"},
					"visible": {"bindTo": "getIsNotEmptyCollection"},
					"hint": {"bindTo": "Resources.Strings.SaveButtonHint"}
				}
			},
			{
				"operation": "insert",
				"name": "CloseButton",
				"parentName": "EnrichmentContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"imageConfig": {"bindTo": "Resources.Images.CloseIcon"},
					"click": {"bindTo": "closeWithoutSave"},
					"classes": {
						"wrapperClass": ["enrichment-close-button"]
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});