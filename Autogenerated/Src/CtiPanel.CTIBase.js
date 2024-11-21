define("CtiPanel", ["BPMSoft", "CtiProviderInitializer", "CtiBaseHelper", "CtiPanelResources", "CtiConstants", "Call",
		"AcademyUtilities", "CtiPanelModelUtilities", "CtiPanelUtils", "CtiPanelIdentificationUtilities",
		"CtiContainerListGenerator", "CtiContainerList", "SearchEdit", "CtiPanelCommunicationHistoryUtilities",
		"PanelEmptyListMixin", "EntityConnectionLinksUtilities", "css!EntityConnectionLinksUtilities"],
	function(BPMSoft, CtiProviderInitializer, CtiBaseHelper, resources, ctiConstants, callSchema, AcademyUtilities) {
		return {
			messages: {
				/**
				 * @message CallCustomer`
				 * Notifies about the necessity to call the customer.
				 * @param {Object} Call parameters information.
				 */
				"CallCustomer": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message GetCallRecords
				 * Notifies about the necessity to get call records.
				 * @param {Object} Call parameters information.
				 */
				"GetCallRecords": {
					"mode": BPMSoft.MessageMode.PTP,
					"direction": BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message SelectCommunicationPanelItem
				 * ######## ##### # ################ ######.
				 * @param {Object} ########## # ######### ###### ################ ######.
				 */
				"SelectCommunicationPanelItem": {
					"mode": BPMSoft.MessageMode.PTP,
					"direction": BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message CallDurationChanged
				 * ######## ###### # ############# ################ ######.
				 * @param {String} ############ ######.
				 */
				"CallDurationChanged": {
					"mode": BPMSoft.MessageMode.PTP,
					"direction": BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message CtiPanelConnected
				 * ########## ######### # ######## cti ######.
				 */
				"CtiPanelConnected": {
					"mode": BPMSoft.MessageMode.PTP,
					"direction": BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message PushHistoryState
				 * ########## ######### ######### #########.
				 * @param {Object} ################ ###### ###### #########.
				 */
				"PushHistoryState": {
					"mode": BPMSoft.MessageMode.BROADCAST,
					"direction": BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message AgentStateChanged
				 * ######### ######### ######## ####### #########.
				 * @param {String} ############ ######.
				 */
				"AgentStateChanged": {
					"mode": BPMSoft.MessageMode.PTP,
					"direction": BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			mixins: {
				/**
				 * ###### ###### #############.
				 */
				CtiPanelModelUtilities: BPMSoft.CtiPanelModelUtilities,

				/**
				 * ###### ###### ########### ############ ####### Cti ######.
				 */
				CtiPanelUtils: BPMSoft.CtiPanelUtils,

				/**
				 * ###### ############# ########.
				 */
				CtiPanelIdentificationUtilities: BPMSoft.CtiPanelIdentificationUtilities,

				/**
				 * ###### ####### #######.
				 */
				CtiPanelCommunicationHistoryUtilities: BPMSoft.CtiPanelCommunicationHistoryUtilities,

				/**
				 * ###### ### ###### ######### ### ###### ####### #######.
				 */
				PanelEmptyListMixin: BPMSoft.PanelEmptyListMixin,

				/**
				 * Entity connection lookup columns mixin.
				 */
				EntityConnectionLinksUtilities: BPMSoft.EntityConnectionLinksUtilities
			},
			attributes: {

				/**
				 * ######### ##### ########.
				 * @private
				 * @type {String}
				 */
				"PhoneNumber": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": ""
				},

				/**
				 * ########## ######## # #### ##### ########. ##########, ##### ######## ########### ##### ############
				 * ############ ######### ######## ###### ########.
				 * @private
				 * @type {String}
				 */
				"PhoneNumberOldValue": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": ""
				},

				/**
				 * ######### ## ####### ####### # ## ############, ## ####### ######### ########
				 * ### ######## ##########.
				 * @private
				 * @type {Object[]}
				 */
				"SubscribedEvents": {
					"value": null
				},

				/**
				 * ######### ######### # ####### ############# ### ######### ##### #########.
				 * #### - ### ########, ######## - ###### ######### #############, ####### ####### ##########.
				 * @private
				 * @type {Object}
				 */
				"IdentificationDataLabels": {
					"dataValueType": BPMSoft.DataValueType.CUSTOM_OBJECT,
					"value": {
						"Contact": ["AccountName", "Job"],
						"Account": ["AccountType", "City"],
						"Employee": ["Department"]
					}
				},

				/**
				 * ########## ################## ######### ######### ######.
				 * @private
				 * @type {Number}
				 */
				"IdentifiedSubscribersCount": {
					"dataValueType": BPMSoft.DataValueType.INTEGER,
					"value": 0
				},

				/**
				 * #### ################### ######## ######### ###### # ######### # ####### ##################
				 * #########.
				 * @private
				 * @type {String}
				 */
				"IdentifiedSubscriberKey": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"value": ""
				},

				/**
				 * ########## ################## ######### ################# ######.
				 * @private
				 * @type {Number}
				 */
				"IdentifiedConsultSubscribersCount": {
					"dataValueType": BPMSoft.DataValueType.INTEGER,
					"value": 0
				},

				/**
				 * #### ################### ######## ################# ###### # ######### # ####### ##################
				 * #########.
				 * @private
				 * @type {String}
				 */
				"IdentifiedConsultSubscriberKey": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"value": ""
				},

				/**
				 * ###### ############ ############ ######### ######### ###### # ####### mm:ss.
				 * @private
				 * @type {String}
				 */
				"CallDuration": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": null
				},

				/**
				 * ##### ###### #########.
				 * @private
				 * @type {String}
				 */
				"CommutationStartedOn": {
					"dataValueType": BPMSoft.DataValueType.DATE_TIME,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": null
				},

				/**
				 * ############# #######.
				 * @private
				 * @type {String}
				 */
				"DurationTimerIntervalId": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": ""
				},

				/**
				 * ###### ############ ############ ######### ################# ###### # ####### mm:ss.
				 * @private
				 * @type {String}
				 */
				"ConsultCallDuration": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": "00:00"
				},

				/**
				 * #### ######### ########## # ###### ########.
				 * @private
				 * @type {Boolean}
				 */
				"IsTransferPrepared": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * @property {Object} AdvisedIdentifiedSubscriberInfo Information about identified subscriber.
				 * @property {String} AdvisedIdentifiedSubscriberInfo.customerId Record Id of the identified subscriber.
				 * @property {String} AdvisedIdentifiedSubscriberInfo.entitySchemaName Subscriber entity schema name.
				 * @property {String} AdvisedIdentifiedSubscriberInfo.number Subscriber phone number.
				 * @property {BPMSoft.Collection} AdvisedIdentifiedSubscriberInfo.callRelationFields Call relation
				 * fields.
				 * @private
				 */
				"AdvisedIdentifiedSubscriberInfo": {
					"dataValueType": BPMSoft.DataValueType.CUSTOM_OBJECT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * ######### ####### ################## ######### ######### ######.
				 * @private
				 * @type {BPMSoft.Collection}
				 */
				"IdentifiedSubscriberPanelCollection": {
					"dataValueType": BPMSoft.DataValueType.COLLECTION
				},

				/**
				 * ######### ####### ################## ######### ################# ######.
				 * @private
				 * @type {BPMSoft.Collection}
				 */
				"IdentifiedConsultSubscriberPanelCollection": {
					"dataValueType": BPMSoft.DataValueType.COLLECTION
				},

				/**
				 * ######### ####### # ############ ###### ########.
				 * @private
				 * @type {BPMSoft.Collection}
				 */
				"SearchResultPanelCollection": {
					"dataValueType": BPMSoft.DataValueType.COLLECTION
				},

				/**
				 * ######### ####### # ######## #######.
				 * @private
				 * @type {BPMSoft.Collection}
				 */
				"CommunicationHistoryPanelCollection": {
					"dataValueType": BPMSoft.DataValueType.COLLECTION
				},

				/**
				 * #######, ### ##### ######### ######## #
				 * ## ###### #######, ############### ############# ########.
				 * @private
				 * @type {Boolean}
				 */
				"IsSearchFinishedAndResultEmpty": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * ####### ####, ### ######## #########, ######### # ########## ######, ######.
				 * @private
				 * @type {Boolean}
				 */
				"IsSearchResultPanelCollectionEmpty": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"value": true
				},

				/**
				 * ###### ########, ####### #### ########## ##### DTMF #####.
				 * @private
				 * @type {String}
				 */
				"DtmfDigits": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": ""
				},

				/**
				 * #### ######### ########## # ###### DTMF ######.
				 * @private
				 * @type {Boolean}
				 */
				"IsDtmfPrepared": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * ######### #########.
				 * @private
				 * @type {Object}
				 */
				"CtiSettings": {
					"dataValueType": BPMSoft.DataValueType.Object,
					"value": null
				},

				/**
				 * ############ ## ######### ######### ######## #####.
				 * @private
				 * @type {Boolean}
				 */
				"IsVideoSupported": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * ##### ## ######### # #####.
				 * @private
				 * @type {Boolean}
				 */
				"IsVideoHidden": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * #######, ########### ## ############# ########### ######### # ###### #######.
				 * @private
				 * @type {Boolean}
				 */
				"DisplayEmptyHistoryMessage": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * Schema for call relations. Used for call history relation fields.
				 * @private
				 * @type {Object}
				 */
				"EntityConnectionSchema": {
					"dataValueType": BPMSoft.DataValueType.Object,
					"value": callSchema
				},

				/**
				 * Array of the call relation columns. Used for call history relation fields.
				 * @type {String[]}
				 */
				"EntityConnectionColumnList": {
					dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT
				},

				/**
				 * Sign that indicates is connection to telephony server available.
				 * @private
				 * @type {Boolean}
				 */
				"IsTelephonyAvailable": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"value": true
				},

				/**
				 * Sign that indicates is connection to telephony server not available.
				 * @private
				 * @type {Boolean}
				 */
				"IsTelephonyNotAvailable": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * Sign that indicates if academy message is visible.
				 * @private
				 * @type {Boolean}
				 */
				"IsAcademyMessageVisible": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"value": true
				},

				/**
				 * Academy message.
				 * @private
				 * @type {String}
				 */
				"AcademyHelpMessage" : {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"value": ""
				},

				/**
				 * wb id.
				 * @private
				 * @type {String}
				 */
				"wbId": {
					"dataValueType": BPMSoft.DataValueType.GUID,
					"value": "dda88d7d-19d0-4009-a3ee-192069fd7e64"
				},

				/**
				 * Search subscribers rows offset.
				 * @private
				 * @type {Number}
				 */
				"SearchSubscribersRowsOffset": {
					"dataValueType": BPMSoft.DataValueType.INTEGER,
					"value": 0
				}
			},
			methods: {

				//region Methods: Private

				/**
				 * Loads next subscribers page.
				 */
				onLoadNext: function() {
					this.$SearchSubscribersRowsOffset += ctiConstants.IdentificationMaxRowCount;
					this.updateSearchResults(true);
				},

				/**
				 * ############## cti-######, ####### #######.
				 */
				constructor: function() {
					this.callParent(arguments);
					this.addEvents(

						/**
						 * @event subscriberIdentified
						 * ###########, ##### ####### ### ###############.
						 * @param {String} callId ############# ######.
						 * @param {Object} [data] ########## ## ########. #### ########## # ###### ## ######## #######,
						 * ## null.
						 * @param {String} data.Id ############# ########.
						 * @param {String} data.Name ###.
						 * @param {String} data.Number #####.
						 * @param {CtiConstants.SubscriberTypes} data.Type ### ########.
						 * @param {String} data.AccountName ######## ###########.
						 * @param {String} data.AccountType ### ###########.
						 * @param {String} data.City ##### ###########.
						 * @param {String} data.CommunicationType ######## #### ######## #####.
						 * @param {String} data.Department #####.
						 * @param {String} data.Job #########.
						 * @param {String} data.Photo ###########.
						 */
						"subscriberIdentified",

						/**
						 * @event callIdentificationSaved
						 * ########### ##### ########## # #### ###### ############# ######## ######.
						 * @param {String} callId ############# ######.
						 * @param {BPMSoft.Collection} data ################# ###### ######.
						 * ##. {@link BPMSoft.integration.telephony.Call#identificationFieldsData}
						 * @param {String} [error] ###### ########## ######.
						 */
						"callIdentificationSaved"
					);
				},

				/**
				 * ####### ######### ## ###### # #######.
				 * @private
				 * @param {Object} message #########.
				 */
				logError: function(message) {
					var console = Ext.global.console;
					if (console && console.error) {
						console.error(message);
					}
				},

				/**
				 * ####### ############## ######### # #######.
				 * @private
				 * @param {Object} message #########.
				 */
				logInfo: function(message) {
					var console = Ext.global.console;
					if (console && console.info) {
						console.info(message);
					}
				},

				//endregion

				//region Methods: Protected

				/**
				 * Initializes schemes of collection.
				 * @protected
				 */
				initCollections: function() {
					this.set({
						SearchResultPanelCollection: this.Ext.create("BPMSoft.BaseViewModelCollection"),
						IdentifiedSubscriberPanelCollection: this.Ext.create("BPMSoft.BaseViewModelCollection"),
						IdentifiedConsultSubscriberPanelCollection: this.Ext.create("BPMSoft.BaseViewModelCollection")
					});
					this.initCallHistoryCollection();
				},

				/**
				 * ############## ######### ####### ####### # ######### ######## ## ## #########.
				 * @protected
				 */
				initCallHistoryCollection: function() {
					var collection = this.Ext.create("BPMSoft.Collection");
					collection.on("add", this.onCallHistoryChanged, this);
					collection.on("dataLoaded", this.onCallHistoryChanged, this);
					collection.on("remove", this.onCallHistoryChanged, this);
					collection.on("clear", this.onCallHistoryChanged, this);
					this.set("CommunicationHistoryPanelCollection", collection);
				},

				/**
				 * Initializes cti settings, cti provider, cti model and load communication history.
				 * @protected
				 */
				initialize: function() {
					CtiBaseHelper.queryCtiSettings(function(ctiSettings) {
						this.set("CtiSettings", ctiSettings);
						CtiProviderInitializer.initializeCtiProvider(ctiSettings.ctiProviderName,
							this.initializeCtiModel.bind(this));
						this.loadCommunicationHistory();
					}.bind(this));
				},

				/**
				 * Initializes call relation history view configuration.
				 * @protected
				 * @param {Array|*} [viewConfigItems] View configuration items.
				 * @param {Array|*} [parentContainerItems] Parent container view configuration items.
				 */
				initCallRelationHistoryViewConfig: function(viewConfigItems, parentContainerItems) {
					if (viewConfigItems) {
						this.createEntityConnectionPanelConfig(viewConfigItems);
						var linkIcons = viewConfigItems.filter(function(item) {
								return item.markerValue == "EntityLinkedIconsContainer";
						});
						if (this.isNotEmpty(linkIcons)) {
							var linkIcons = linkIcons[0];
							parentContainerItems.push(Ext.apply(linkIcons, {
								"visible": {
									"bindTo":"IsCallConnectionsVisible",
									"bindConfig": {"converter": "invertBooleanValue"}
								}
							}));
							Ext.Array.remove(viewConfigItems, linkIcons);
						}
					}
					this.initialize();
				},

				/**
				 * Processes change of calls history.
				 * @protected
				 */
				onCallHistoryChanged: function() {
					var collection = this.get("CommunicationHistoryPanelCollection");
					this.set("DisplayEmptyHistoryMessage", collection.isEmpty());
				},

				/**
				 * Creates connection to telephony.
				 * @protected
				 */
				createConnection: function() {
					this.subscribeEvents();
					this.connect(null, function(success, error) {
						if (error) {
							this.onConnectError(error);
						}
					}.bind(this));
				},

				/**
				 * Initializes Cti model.
				 * @param {BPMSoft.BaseCtiProvider} provider Telephony functions provider.
				 * @protected
				 */
				initializeCtiModel: function(provider) {
					this.ctiProvider = provider;
					this.createConnection();
				},

				/**
				 * Subscribes to Cti model events.
				 * @protected
				 */
				subscribeEvents: function() {
					var ctiPanelEvents = [
						{
							eventName: "connected",
							eventHandler: this.onConnected
						},
						{
							eventName: "disconnected",
							eventHandler: this.onDisconnected
						},
						{
							eventName: "commutationStarted",
							eventHandler: this.onCommutationStarted
						},
						{
							eventName: "change:CurrentCallNumber",
							eventHandler: this.onChangeCurrentCallNumber
						},
						{
							eventName: "change:CurrentCall",
							eventHandler: this.onChangeCurrentCall
						},
						{
							eventName: "change:CallDuration",
							eventHandler: this.onChangeCallDuration
						},
						{
							eventName: "change:ConsultCallNumber",
							eventHandler: this.onChangeConsultCallNumber
						},
						{
							eventName: "change:AgentState",
							eventHandler: this.onAgentStateCodeChanged
						},
						{
							eventName: "change:IdentifiedSubscriberKey",
							eventHandler: this.onIdentifiedSubscriberKeyChanged
						},
						{
							eventName: "change:IdentifiedConsultSubscriberKey",
							eventHandler: this.onIdentifiedConsultSubscriberKeyChanged
						},
						{
							eventName: "callSaved",
							eventHandler: this.onCallSavedEvent
						},
						{
							eventName: "dtmfEntered",
							eventHandler: this.onDtmfEntered
						},
						{
							eventName: "webRtcStarted",
							eventHandler: this.onWebRtcStarted
						},
						{
							eventName: "webRtcVideoStarted",
							eventHandler: this.onWebRtcVideoStarted
						},
						{
							eventName: "webRtcDestroyed",
							eventHandler: this.onWebRtcDestroyed
						},
						{
							eventName: "change:IsVideoHidden",
							eventHandler: this.onVideoHidden
						},
						{
							eventName: "subscriberIdentified",
							eventHandler: this.onSubscriberIdentified
						}
					];
					BPMSoft.each(ctiPanelEvents, function(item) {
						this.on(item.eventName, item.eventHandler, this);
					}, this);
					this.set("SubscribedEvents", ctiPanelEvents);
					this.sandbox.subscribe("CallCustomer", this.onCallCustomer.bind(this));
					this.sandbox.subscribe("GetCallRecords", this.onGetCallRecords.bind(this),
						[ctiConstants.CallRecordsContextMessageId]);
					var activeCalls = this.activeCalls;
					activeCalls.on("add", this.onCtiPanelActiveCallAdded, this);
					activeCalls.on("clear", this.onCtiPanelActiveCallsEmpty, this);
					activeCalls.on("remove", this.onCtiPanelActiveCallRemoved, this);
				},

				/**
				 * ############ ###### ### ########### # #########.
				 * @protected
				 * @param {Object} error ###### ######.
				 * @param {BPMSoft.MsgErrorType} error.errorType ### ######.
				 * @param {String} error.internalErrorCode ### ######.
				 * @param {String} error.data ##### ######.
				 * @param {String} error.source ######## ######.
				 */
				onConnectError: function(error) {
					if (error.errorType === BPMSoft.MsgErrorType.CONNECTION_CONFIG_ERROR) {
						this.logError(this.get("Resources.Strings.ConnectionConfigEmptyError"));
					}
				},

				/**
				 * ########## ############# ###### ######### # ###### ####### #######.
				 * @return {Boolean} #### ####### ####### ############ # ### ######, ## true.
				 * @protected
				 */
				isEmptyCallHistoryMessageVisible: function() {
					return this.getIsCommunicationHistoryVisible() && this.get("DisplayEmptyHistoryMessage");
				},

				/**
				 * Returns academy message visibility.
				 * @return {boolean}
				 * @protected
				 */
				getIsAcademyMessageVisible: function() {
					var isNotEmptyCollection = !this.get("DisplayEmptyHistoryMessage");
					var iswbCollaboration = this.get("IswbCollaboration");
					var isAcademyMessageVisible = this.get("IsAcademyMessageVisible");
					return !this.getIsCallExists() && iswbCollaboration && isNotEmptyCollection &&
						isAcademyMessageVisible && !this.getIsEmptySearchResultContainerVisible();
				},

				/**
				 * Checks if current connector is wb Collaboration.
				 * @protected
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function scope.
				 */
				initIswbCollaboration: function(callback, scope) {
					BPMSoft.SysSettings.querySysSettings(["SysMsgLib", "wbDomain"], function(sysSettings) {
						var iswbCollaboration = sysSettings.SysMsgLib.value.toLowerCase() === this.get("wbId")
							&& !sysSettings.wbDomain;
						this.set("IswbCollaboration", iswbCollaboration);
						Ext.callback(callback, scope);
					}, this);
				},

				/**
				 * Hides academy message if cti panel is scrollable.
				 * @protected
				 */
				setAcademyMessageVisibility: function() {
					var ctiPanelWrapper = Ext.get(this.renderTo);
					if (ctiPanelWrapper && (ctiPanelWrapper.dom.scrollHeight > ctiPanelWrapper.dom.clientHeight)) {
						this.set("IsAcademyMessageVisible", false);
					} else {
						this.set("IsAcademyMessageVisible", true);
					}
				},

				/**
				 * Forms academy message content.
				 * @return {string}
				 * @protected
				 */
				getHelpUrl: function() {
					var callback = function(helpUrl) {
						var startTagPart = "";
						var endTagPart = "";
						var description = this.get("Resources.Strings.EmptyHistoryMessage");
						if (!this.Ext.isEmpty(helpUrl)) {
							startTagPart = "<a target=\"_blank\" href=\"" + helpUrl + "\">";
							endTagPart = "</a>";
						}
						description = this.Ext.String.format(description, startTagPart, endTagPart);
						this.set("AcademyHelpMessage", description);
					}.bind(this);
					var config = {
						callback: callback,
						scope: this,
						contextHelpId: 1024,
						contextHelpCode: "CallPageV2"
					};
					AcademyUtilities.getUrl(config);
				},

				//endregion

				//region Methods: Public

				/**
				 * Initializes the schema.
				 */
				init: function(callback, scope) {
					this.initCollections();
					this.callParent([function() {
						this.initIswbCollaboration(callback, scope);
					}, this]);
					if (this.get("Restored") !== true) {
						this.generateIdentifiedSubscriberPanelItemConfig(function() {
							this.generateCommunicationPanelItemConfig(function() {
								this.generateSearchResultPanelItemConfig(function() {
									this.loadEntityConnectionColumns(function() {
										this.generateCommunicationHistoryItemPanelItemConfig(
											this.initCallRelationHistoryViewConfig.bind(this));
									}.bind(this));
								}.bind(this));
							}.bind(this));
						}.bind(this));
					}
					this.on("destroyed", this.onDestroyed);
					this.initHelpUrl("CallPageV2", 1024);
					this.getHelpUrl();
					this.emptyMessageConfig = {
						title: this.get("Resources.Strings.EmptyHistoryTitleLabel"),
						description: this.get("Resources.Strings.EmptyHistoryMessage"),
						image: this.get("Resources.Images.EmptySearchResultImage")
					};
				},

				/**
				 * ######### ####### ########### #####.
				 * Schema destroying event handler.
				 */
				onDestroyed: function() {
					var ctiPanelEvents = this.get("SubscribedEvents");
					BPMSoft.each(ctiPanelEvents, function(item) {
						this.un(item.eventName, item.eventHandler, this);
					}, this);
					this.set("SubscribedEvents", "");
					var activeCalls = this.activeCalls;
					activeCalls.un("add", this.onCtiPanelActiveCallAdded, this);
					activeCalls.un("clear", this.onCtiPanelActiveCallsEmpty, this);
					activeCalls.un("remove", this.onCtiPanelActiveCallRemoved, this);
					var collection = this.get("CommunicationHistoryPanelCollection");
					collection.un("add", this.onCallHistoryChanged, this);
					collection.un("dataLoaded", this.onCallHistoryChanged, this);
					collection.un("clear", this.onCallHistoryChanged, this);
					collection.un("remove", this.onCallHistoryChanged, this);
				}

				//endregion

			},
			diff: [
				{
					"operation": "insert",
					"name": "ctiPanelMainContainer",
					"values": {
						"id": "ctiPanelMainContainer",
						"selectors": {"wrapEl": "#ctiPanelMainContainer"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["ctiPanelMain"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ctiPanelVideoContainer",
					"parentName": "ctiPanelMainContainer",
					"propertyName": "items",
					"index": 0,
					"values": {
						"id": "ctiPanelVideoContainer",
						"selectors": {"wrapEl": "#ctiPanelVideoContainer"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["ctiPanelVideo"],
						"items": []
					}
				},

				//region current call identification controls

				{
					"operation": "insert",
					"name": "IdentificationPanel",
					"parentName": "ctiPanelMainContainer",
					"index": 1,
					"propertyName": "items",
					"values": {
						"id": "IdentificationPanel",
						"markerValue": {"bindTo": "CurrentCallNumber"},
						"selectors": {"wrapEl": "#IdentificationPanel"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["identification-panel"],
						"visible": {"bindTo": "getIsCallExists"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "IdentificationPanelLeft",
					"parentName": "IdentificationPanel",
					"propertyName": "items",
					"values": {
						"id": "IdentificationPanelLeft",
						"selectors": {"wrapEl": "#IdentificationPanelLeft"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["identification-panel-left"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "IdentificationPanelRight",
					"parentName": "IdentificationPanel",
					"propertyName": "items",
					"values": {
						"id": "IdentificationPanelRight",
						"selectors": {"wrapEl": "#IdentificationPanelRight"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["identification-panel-right"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "IdentificationDataPanel",
					"parentName": "IdentificationPanelRight",
					"propertyName": "items",
					"values": {
						"id": "IdentificationDataPanel",
						"selectors": {"wrapEl": "#IdentificationDataPanel"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["identification-data-panel"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "SubscriberPhoto",
					"parentName": "IdentificationPanelLeft",
					"propertyName": "items",
					"values": {
						"id": "SubscriberPhoto",
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"imageConfig": {"bindTo": "getSubscriberPhoto"},
						"classes": {"wrapperClass": ["subscriber-photo"]},
						"markerValue": "SubscriberPhoto",
						"selectors": {"wrapEl": "#SubscriberPhoto"},
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"tag": "Photo"
					}
				},
				{
					"operation": "insert",
					"name": "TransferringArrows",
					"parentName": "IdentificationPanelLeft",
					"propertyName": "items",
					"values": {
						"id": "TransferringArrows",
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"imageConfig": {"bindTo": "Resources.Images.TransferringArrows"},
						"classes": {"wrapperClass": ["transferring-arrows"]},
						"markerValue": "TransferringArrows",
						"selectors": {"wrapEl": "#TransferringArrows"},
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"visible": {"bindTo": "IsConsulting"}
					}
				},
				{
					"operation": "insert",
					"name": "PrimaryCallInfo",
					"parentName": "IdentificationPanelRight",
					"propertyName": "items",
					"values": {
						"id": "PrimaryCallInfo",
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "CurrentCallNumber"},
						"markerValue": "PrimaryCallInfo",
						"classes": {"labelClass": "primary-call-info"},
						"visible": {"bindTo": "getIsSubscriberUnknown"}
					}
				},
				{
					"operation": "insert",
					"name": "SubscriberName",
					"parentName": "IdentificationDataPanel",
					"propertyName": "items",
					"values": {
						"id": "SubscriberName",
						"markerValue": {"bindTo": "getSubscriberData"},
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {"bindTo": "getSubscriberData"},
						"hint": {"bindTo": "getSubscriberData"},
						"tag": "Name",
						"visible": {
							"bindTo": "IdentifiedSubscriberKey",
							"bindConfig": {"converter": "getIsSubscriberIdentified"}
						},
						"click": {"bindTo": "onSubscriberNameClick"},
						"classes": {"wrapperClass": ["subsciber-menu-button"]},
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"menu": {
							"items": [
								{
									"id": "SelectAnotherSubscriberMenuItem",
									"caption": {"bindTo": "Resources.Strings.SelectAnotherSubscriberCaption"},
									"markerValue": "SelectAnotherSubscriberMenuItem",
									"click": {"bindTo": "clearSubscriber"}
								}
							]
						}
					}
				},
				{
					"operation": "insert",
					"name": "SubscriberNumberInfo",
					"parentName": "IdentificationPanelRight",
					"propertyName": "items",
					"values": {
						"id": "SubscriberNumberInfo",
						"selectors": {"wrapEl": "#SubscriberNumberInfo"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"markerValue": "SubscriberNumberInfo",
						"items": [
							{
								"id": "CommunicationTypeLabel",
								"itemType": BPMSoft.ViewItemType.LABEL,
								"classes": {"labelClass": ["label-caption"]},
								"markerValue": {"bindTo": "getSubscriberData"},
								"selectors": {"wrapEl": "#CommunicationTypeLabel"},
								"caption": {"bindTo": "getSubscriberData"},
								"tag": "CommunicationType"
							},
							{
								"id": "CallNumber",
								"itemType": BPMSoft.ViewItemType.LABEL,
								"classes": {"labelClass": ["subscriber-info"]},
								"markerValue": {"bindTo": "getSubscriberData"},
								"selectors": {"wrapEl": "#CallNumber"},
								"caption": {"bindTo": "getSubscriberData"},
								"tag": "Number"
							}
						]
					}
				},
				{
					"operation": "insert",
					"name": "AccountName",
					"parentName": "IdentificationDataPanel",
					"propertyName": "items",
					"values": {
						"generator": "CtiBaseHelper.getIdentificationDataLabel"
					}
				},
				{
					"operation": "insert",
					"name": "SubscriberJob",
					"parentName": "IdentificationDataPanel",
					"propertyName": "items",
					"values": {
						"tag": "Job",
						"generator": "CtiBaseHelper.getIdentificationDataLabel"
					}
				},
				{
					"operation": "insert",
					"name": "SubscriberDepartment",
					"parentName": "IdentificationDataPanel",
					"propertyName": "items",
					"values": {
						"tag": "Department",
						"generator": "CtiBaseHelper.getIdentificationDataLabel"
					}
				},
				{
					"operation": "insert",
					"name": "AccountType",
					"parentName": "IdentificationDataPanel",
					"propertyName": "items",
					"values": {
						"generator": "CtiBaseHelper.getIdentificationDataLabel"
					}
				},
				{
					"operation": "insert",
					"name": "AccountCity",
					"parentName": "IdentificationDataPanel",
					"propertyName": "items",
					"values": {
						"tag": "City",
						"generator": "CtiBaseHelper.getIdentificationDataLabel"
					}
				},
				{
					"operation": "insert",
					"name": "CallDurationInfo",
					"parentName": "IdentificationPanelRight",
					"propertyName": "items",
					"values": {
						"id": "CallDurationInfo",
						"selectors": {"wrapEl": "#CallDurationInfo"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"visible": {"bindTo": "getIsCallDurationVisible"},
						"classes": {
							wrapClassName: ["call-duration-container"]
						},
						"items": [
							{
								"id": "CallDurationLabel",
								"itemType": BPMSoft.ViewItemType.LABEL,
								"classes": {"labelClass": ["label-caption"]},
								"markerValue": "CallDurationLabel",
								"selectors": {"wrapEl": "#CallDurationLabel"},
								"caption": {"bindTo": "Resources.Strings.CallDurationLabelCaption"}
							},
							{
								"id": "CallDuration",
								"itemType": BPMSoft.ViewItemType.LABEL,
								"classes": {"labelClass": ["call-duration"]},
								"markerValue": "CallDuration",
								"selectors": {"wrapEl": "#CallDuration"},
								"caption": {"bindTo": "CallDuration"}
							}
						]
					}
				},
				{
					"operation": "insert",
					"name": "AdditionalSubscriberInfoContainer",
					"parentName": "IdentificationPanelRight",
					"propertyName": "items",
					"values": {
						"id": "AdditionalSubscriberInfoContainer",
						"selectors": {"wrapEl": "#AdditionalSubscriberInfoContainer"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"visible": {"bindTo": "getIsAdditionalSubscriberInfoContainerVisible"},
						"classes": {
							wrapClassName: ["additional-subscriber-info-container"]
						},
						"items": []
					}
				},

				//endregion

				//region consult call identification controls

				{
					"operation": "insert",
					"name": "ConsultIdentificationPanel",
					"parentName": "ctiPanelMainContainer",
					"index": 2,
					"propertyName": "items",
					"values": {
						"id": "ConsultIdentificationPanel",
						"markerValue": {"bindTo": "ConsultCallNumber"},
						"selectors": {"wrapEl": "#ConsultIdentificationPanel"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["identification-panel", "consult-identification-panel"],
						"visible": {"bindTo": "IsConsulting"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ConsultIdentificationPanelLeft",
					"parentName": "ConsultIdentificationPanel",
					"propertyName": "items",
					"values": {
						"id": "ConsultIdentificationPanelLeft",
						"selectors": {"wrapEl": "#ConsultIdentificationPanelLeft"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["identification-panel-left"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ConsultIdentificationPanelRight",
					"parentName": "ConsultIdentificationPanel",
					"propertyName": "items",
					"values": {
						"id": "ConsultIdentificationPanelRight",
						"selectors": {"wrapEl": "#ConsultIdentificationPanelRight"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["identification-panel-right"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ConsultIdentificationDataPanel",
					"parentName": "ConsultIdentificationPanelRight",
					"propertyName": "items",
					"values": {
						"id": "ConsultIdentificationDataPanel",
						"selectors": {"wrapEl": "#ConsultIdentificationDataPanel"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["identification-data-panel"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ConsultSubscriberPhoto",
					"parentName": "ConsultIdentificationPanelLeft",
					"propertyName": "items",
					"values": {
						"id": "ConsultSubscriberPhoto",
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"imageConfig": {"bindTo": "getConsultSubscriberPhoto"},
						"classes": {"wrapperClass": ["subscriber-photo"]},
						"markerValue": "ConsultSubscriberPhoto",
						"selectors": {"wrapEl": "#ConsultSubscriberPhoto"},
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"tag": "Photo"
					}
				},
				{
					"operation": "insert",
					"name": "ConsultCallInfo",
					"parentName": "ConsultIdentificationPanelRight",
					"propertyName": "items",
					"values": {
						"id": "ConsultCallInfo",
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "ConsultCallNumber"},
						"markerValue": "ConsultCallInfo",
						"classes": {"labelClass": "primary-call-info"},
						"visible": {"bindTo": "getIsConsultSubscriberUnknown"}
					}
				},
				{
					"operation": "insert",
					"name": "ConsultSubscriberName",
					"parentName": "ConsultIdentificationDataPanel",
					"propertyName": "items",
					"values": {
						"id": "ConsultSubscriberName",
						"markerValue": {"bindTo": "getConsultSubscriberData"},
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {"bindTo": "getConsultSubscriberData"},
						"hint": {"bindTo": "getConsultSubscriberData"},
						"tag": "Name",
						"visible": {
							"bindTo": "IdentifiedConsultSubscriberKey",
							"bindConfig": {"converter": "getIsSubscriberIdentified"}
						},
						"click": {"bindTo": "onConsultSubscriberNameClick"},
						"classes": {"wrapperClass": ["subsciber-menu-button"]},
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"menu": {
							"items": [
								{
									"id": "SelectAnotherConsultSubscriberMenuItem",
									"caption": {"bindTo": "Resources.Strings.SelectAnotherSubscriberCaption"},
									"markerValue": "SelectAnotherConsultSubscriberMenuItem",
									"click": {"bindTo": "clearConsultSubscriber"}
								}
							]
						}
					}
				},
				{
					"operation": "insert",
					"name": "ConsultSubscriberNumberInfo",
					"parentName": "ConsultIdentificationPanelRight",
					"propertyName": "items",
					"values": {
						"id": "ConsultSubscriberNumberInfo",
						"selectors": {"wrapEl": "#ConsultSubscriberNumberInfo"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"markerValue": "SubscriberNumberInfo",
						"items": [
							{
								"id": "ConsultCommunicationTypeLabel",
								"itemType": BPMSoft.ViewItemType.LABEL,
								"classes": {"labelClass": ["label-caption"]},
								"markerValue": {"bindTo": "getConsultSubscriberData"},
								"selectors": {"wrapEl": "#ConsultCommunicationTypeLabel"},
								"caption": {"bindTo": "getConsultSubscriberData"},
								"tag": "CommunicationType"
							},
							{
								"id": "ConsultCallNumber",
								"itemType": BPMSoft.ViewItemType.LABEL,
								"classes": {"labelClass": ["subscriber-info"]},
								"markerValue": {"bindTo": "getConsultSubscriberData"},
								"selectors": {"wrapEl": "#ConsultCallNumber"},
								"caption": {"bindTo": "getConsultSubscriberData"},
								"tag": "Number"
							}
						]
					}
				},
				{
					"operation": "insert",
					"name": "ConsultAccountName",
					"parentName": "ConsultIdentificationDataPanel",
					"propertyName": "items",
					"values": {
						"tag": "AccountName",
						"visible": {"bindTo": "getIsConsultInfoLabelVisible"},
						"value": {"bindTo": "getConsultSubscriberData"},
						"generator": "CtiBaseHelper.getIdentificationDataLabel"
					}
				},
				{
					"operation": "insert",
					"name": "ConsultSubscriberJob",
					"parentName": "ConsultIdentificationDataPanel",
					"propertyName": "items",
					"values": {
						"tag": "Job",
						"visible": {"bindTo": "getIsConsultInfoLabelVisible"},
						"value": {"bindTo": "getConsultSubscriberData"},
						"generator": "CtiBaseHelper.getIdentificationDataLabel"
					}
				},
				{
					"operation": "insert",
					"name": "ConsultSubscriberDepartment",
					"parentName": "ConsultIdentificationDataPanel",
					"propertyName": "items",
					"values": {
						"tag": "Department",
						"visible": {"bindTo": "getIsConsultInfoLabelVisible"},
						"value": {"bindTo": "getConsultSubscriberData"},
						"generator": "CtiBaseHelper.getIdentificationDataLabel"
					}
				},
				{
					"operation": "insert",
					"name": "ConsultAccountType",
					"parentName": "ConsultIdentificationDataPanel",
					"propertyName": "items",
					"values": {
						"tag": "AccountType",
						"visible": {"bindTo": "getIsConsultInfoLabelVisible"},
						"value": {"bindTo": "getConsultSubscriberData"},
						"generator": "CtiBaseHelper.getIdentificationDataLabel"
					}
				},
				{
					"operation": "insert",
					"name": "ConsultAccountCity",
					"parentName": "ConsultIdentificationDataPanel",
					"propertyName": "items",
					"values": {
						"tag": "City",
						"visible": {"bindTo": "getIsConsultInfoLabelVisible"},
						"value": {"bindTo": "getConsultSubscriberData"},
						"generator": "CtiBaseHelper.getIdentificationDataLabel"
					}
				},

				//endregion

				//region call buttons controls

				{
					"operation": "insert",
					"name": "ButtonsPanelWrapper",
					"parentName": "ctiPanelMainContainer",
					"index": 3,
					"propertyName": "items",
					"values": {
						"markerValue": "ButtonsPanelWrapper",
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"visible": {"bindTo": "getIsCallExists"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "AdditionalCallInfoContainer",
					"parentName": "ctiPanelMainContainer",
					"index": 4,
					"propertyName": "items",
					"values": {
						"markerValue": "AdditionalCallInfoContainer",
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"visible": {"bindTo": "getIsAdditionalCallInfoContainerVisible"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "DtmfButtonsContainer",
					"parentName": "ButtonsPanelWrapper",
					"propertyName": "items",
					"values": {
						"onButtonClick": {"bindTo": "enterDtmf"},
						"dtmfDigitsLabel": {"bindTo": "DtmfDigits"},
						"visible": {"bindTo": "getCanMakeDtmf"},
						"generator": "CtiBaseHelper.getDtmfButtonsContainer"
					}
				},
				{
					"operation": "insert",
					"name": "ButtonsPanel",
					"parentName": "ButtonsPanelWrapper",
					"propertyName": "items",
					"values": {
						"markerValue": "ButtonsPanel",
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["buttons-panel"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"index": 1,
					"name": "HoldButton",
					"parentName": "ButtonsPanel",
					"propertyName": "items",
					"values": {
						"id": "HoldButton",
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"click": {"bindTo": "holdOrUnholdCall"},
						"visible": {"bindTo": "getCanHoldOrUnhold"},
						"imageConfig": {"bindTo": "getHoldButtonImageConfig"},
						"classes": {"wrapperClass": ["call-hold-button"]},
						"selectors": {"wrapEl": "#HoldButton"},
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"hint": {"bindTo": "getHoldButtonHint"},
						"markerValue": {"bindTo": "getHoldButtonHint"},
						"tag": "HoldButton"
					}
				},
				{
					"operation": "insert",
					"index": 2,
					"name": "PrepareTransferButton",
					"parentName": "ButtonsPanel",
					"propertyName": "items",
					"values": {
						"id": "PrepareTransferButton",
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"click": {"bindTo": "onPrepareTransferButtonClick"},
						"visible": {"bindTo": "getCanStartTransfer"},
						"imageConfig": {"bindTo": "getPrepareTransferButtonImageConfig"},
						"classes": {"wrapperClass": ["call-prepare-transfer-button"]},
						"selectors": {"wrapEl": "#PrepareTransferButton"},
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"hint": {"bindTo": "Resources.Strings.PrepareTransferButtonHint"},
						"markerValue": "PrepareTransferButton",
						"tag": "PrepareTransferButton"
					}
				},
				{
					"operation": "insert",
					"index": 3,
					"name": "CompleteTransferButton",
					"parentName": "ButtonsPanel",
					"propertyName": "items",
					"values": {
						"id": "CompleteTransferButton",
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"click": {"bindTo": "transferCall"},
						"visible": {"bindTo": "getCanTransfer"},
						"imageConfig": {"bindTo": "Resources.Images.CompleteTransferButtonIcon"},
						"classes": {"wrapperClass": ["call-complete-transfer-button",
							"t-btn-style-call-button-middle"]},
						"selectors": {"wrapEl": "#CompleteTransferButton"},
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"hint": {"bindTo": "Resources.Strings.CompleteTransferTip"},
						"markerValue": "CompleteTransferButton",
						"tag": "CompleteTransferButton"
					}
				},
				{
					"operation": "insert",
					"index": 4,
					"name": "DtmfButton",
					"parentName": "ButtonsPanel",
					"propertyName": "items",
					"values": {
						"id": "DtmfButton",
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"click": {"bindTo": "onDtmfButtonClick"},
						"visible": {"bindTo": "getCanDtmf"},
						"imageConfig": {"bindTo": "getDtmfButtonImageConfig"},
						"selectors": {"wrapEl": "#DtmfButton"},
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"markerValue": {"bindTo": "Resources.Strings.DtmfButtonHint"},
						"tag": "DtmfButton"
					}
				},
				{
					"operation": "insert",
					"index": 5,
					"name": "MuteButton",
					"parentName": "ButtonsPanel",
					"propertyName": "items",
					"values": {
						"id": "MuteButton",
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"click": {"bindTo": "onMuteButtonClick"},
						"visible": {"bindTo": "getIsMuteButtonVisible"},
						"enabled": {"bindTo": "getIsMuteButtonEnabled"},
						"imageConfig": {"bindTo": "getMuteButtonImageConfig"},
						"classes": {"wrapperClass": ["call-mute-button"]},
						"selectors": {"wrapEl": "#MuteButton"},
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"hint": {"bindTo": "getMuteButtonHint"},
						"markerValue": {"bindTo": "getMuteButtonHint"},
						"tag": "MuteButton"
					}
				},
				{
					"operation": "insert",
					"index": 6,
					"name": "VideoButton",
					"parentName": "ButtonsPanel",
					"propertyName": "items",
					"values": {
						"id": "VideoButton",
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"click": {"bindTo": "onVideoButtonClick"},
						"visible": {"bindTo": "getIsAdditionalButtonsVisible"},
						"enabled": {"bindTo": "IsVideoSupported"},
						"imageConfig": {"bindTo": "getVideoButtonImageConfig"},
						"classes": {"wrapperClass": ["call-video-button"]},
						"selectors": {"wrapEl": "#VideoButton"},
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"hint": {"bindTo": "getVideoButtonHint"},
						"markerValue": {"bindTo": "getVideoButtonHint"},
						"tag": "VideoOffButton"
					}
				},
				{
					"operation": "insert",
					"index": 7,
					"name": "CancelTransferButton",
					"parentName": "ButtonsPanel",
					"propertyName": "items",
					"values": {
						"id": "CancelTransferButton",
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"click": {"bindTo": "cancelTransfer"},
						"visible": {"bindTo": "getCanCancelTransfer"},
						"imageConfig": {"bindTo": "Resources.Images.CancelTransferButtonIcon"},
						"classes": {"wrapperClass": ["call-cancel-transfer-button", "t-btn-style-call-button-middle"]},
						"selectors": {"wrapEl": "#CancelTransferButton"},
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"hint": {"bindTo": "Resources.Strings.CancelTransferButtonHint"},
						"markerValue": {"bindTo": "Resources.Strings.CancelTransferButtonHint"},
						"tag": "TransferButton"
					}
				},
				{
					"operation": "insert",
					"index": 8,
					"name": "AnswerButton",
					"parentName": "ButtonsPanel",
					"propertyName": "items",
					"values": {
						"id": "AnswerButton",
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"click": {"bindTo": "answerCall"},
						"visible": {"bindTo": "getCanAnswer"},
						"imageConfig": {"bindTo": "Resources.Images.AnswerButtonLongIcon"},
						"classes": {"wrapperClass": ["call-answer-button", "t-btn-style-call-button-long"]},
						"selectors": {"wrapEl": "#AnswerButton"},
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"hint": {"bindTo": "Resources.Strings.AnswerButtonHint"},
						"markerValue": {"bindTo": "Resources.Strings.AnswerButtonHint"},
						"tag": "AnswerButton"
					}
				},
				{
					"operation": "insert",
					"index": 9,
					"name": "DropButton",
					"parentName": "ButtonsPanel",
					"propertyName": "items",
					"values": {
						"id": "DropButton",
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"click": {"bindTo": "dropCall"},
						"visible": {"bindTo": "getCanDrop"},
						"imageConfig": {"bindTo": "getDropButtonImageConfig"},
						"classes": {"wrapperClass": ["call-drop-button"]},
						"selectors": {"wrapEl": "#DropButton"},
						"style": {"bindTo": "getDropButtonStyle"},
						"hint": {"bindTo": "Resources.Strings.DropButtonHint"},
						"markerValue": {"bindTo": "Resources.Strings.DropButtonHint"},
						"tag": "DropButton"
					}
				},

				//endregion

				{
					"operation": "insert",
					"parentName": "ctiPanelMainContainer",
					"index": 5,
					"propertyName": "items",
					"name": "PhoneNumber",
					"values": {
						"id": "PhoneNumber",
						"className": "BPMSoft.SearchEdit",
						"placeholder": {"bindTo": "Resources.Strings.PhoneNumberPlaceholderCaption"},
						"contentType": BPMSoft.ContentType.SHORT_TEXT,
						"labelConfig": {"visible": false},
						"bindTo": "PhoneNumber",
						"enterkeypressed": {"bindTo": "callPhoneNumber"},
						"change": {"bindTo": "onPhoneNumberChanged"},
						"searchValueChanged": {"bindTo": "onPhoneNumberChanged"},
						"visible": {"bindTo": "getCanMakeCallOrMakeConsultCallOrGetIsOffline"},
						"controlConfig": {
							"classes": ["placeholderOpacity"]
						},
						"classes": {
							"wrapClass": ["phone-number-edit"]
						},
						"rightIconClick": {
							"bindTo": "callPhoneNumber"
						},
						"rightIconConfig": {
							"source": BPMSoft.ImageSources.URL,
							"url": BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.MakeCallButtonIcon)
						}
					}
				},
				{
					"operation": "insert",
					"name": "NoConnectionMessageContainer",
					"parentName": "ctiPanelMainContainer",
					"index": 6,
					"propertyName": "items",
					"values": {
						"id": "NoConnectionMessage",
						"selectors": {"wrapEl": "#NoConnectionMessage"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"markerValue": "NoConnectionMessage",
						"items": [
							{
								"visible": {"bindTo": "getIsInternalTelephonyNotAvailable"},
								"id": "NoConnectionMessageLabel",
								"itemType": BPMSoft.ViewItemType.LABEL,
								"classes": {"labelClass": ["no-connection-msg"]},
								"caption": {"bindTo": "Resources.Strings.NoConnectionToTelephonyErrorMessage"}
							}
						]
					}
				},
				{
					"operation": "insert",
					"name": "demoNoConnectionMessageContainer",
					"parentName": "NoConnectionMessageContainer",
					"propertyName": "items",
					"values": {
						"id": "demoNoConnectionMessageContainer",
						"selectors": {"wrapEl": "#demoNoConnectionMessageContainer"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": {wrapClassName: ["no-connection-msg"]},
						"markerValue": "demoNoConnectionMessageContainer",
						"visible": {"bindTo": "getIsDemoTelephonyNotAvailable"},
						"items": [
							{
								"id": "demoNoConnectionMessageLabel",
								"itemType": BPMSoft.ViewItemType.LABEL,
								"caption": {"bindTo": "Resources.Strings.DemoNoConnectionMessageCaption"},
								"classes": {"labelClass": ["demo-no-connection-message-label"]}
							}
						]
					}
				},

				//region search and identification panels

				{
					"operation": "insert",
					"name": "SearchResultItemsListContainer",
					"parentName": "ctiPanelMainContainer",
					"index": 7,
					"propertyName": "items",
					"values": {
						"id": "SearchResultItemsListContainer",
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"markerValue": "SearchResultItemsListContainer",
						"selectors": {"wrapEl": "#SearchResultItemsListContainer"},
						"idProperty": "Id",
						"collection": {"bindTo": "SearchResultPanelCollection"},
						"onGetItemConfig": {"bindTo": "getSearchResultPanelViewConfig"},
						"classes": {"wrapClassName": ["search-result-items-list-container"]},
						"visible": {"bindTo": "getIsSearchResultItemsListContainerVisible"},
						"generator": "ContainerListGenerator.generateGrid",
						"observableRowNumber": 1,
						"observableRowVisible": {"bindTo": "onLoadNext"},
						"items": [],
						"itemFadeOutDuration": 20,
						"keepScrollOnItemsChanged": true
					}
				},
				{
					"operation": "insert",
					"parentName": "ctiPanelMainContainer",
					"index": 8,
					"name": "IdentificationItemsControlGroup",
					"propertyName": "items",
					"values": {
						"id": "IdentificationItemsControlGroup",
						"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
						"markerValue": "IdentificationItemsControlGroup",
						"selectors": {"wrapEl": "#IdentificationItemsControlGroup"},
						"caption": {"bindTo": "Resources.Strings.IdentificationItemsControlGroupCaption"},
						"visible": {"bindTo": "getIsIdentificationGroupContainerVisible"},
						"controlConfig": {"collapsed": false},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "IdentificationItemsListContainer",
					"parentName": "IdentificationItemsControlGroup",
					"propertyName": "items",
					"values": {
						"id": "IdentificationItemsListContainer",
						"itemType": BPMSoft.ViewItemType.GRID,
						"markerValue": "IdentificationItemsListContainer",
						"selectors": {"wrapEl": "#IdentificationItemsListContainer"},
						"idProperty": "Id",
						"collection": {"bindTo": "IdentifiedSubscriberPanelCollection"},
						"onGetItemConfig": {"bindTo": "getIdentifiedSubscriberPanelViewConfig"},
						"classes": {"wrapClassName": ["identification-items-list-container"]},
						"onItemClick": {"bindTo": "setIdentifiedSubscriber"},
						"visible": {"bindTo": "getIsCurrentCallIdentificationContainerVisible"},
						"generator": "CtiContainerListGenerator.generatePartial"
					}
				},
				{
					"operation": "insert",
					"name": "IdentificationConsultItemsListContainer",
					"parentName": "IdentificationItemsControlGroup",
					"propertyName": "items",
					"values": {
						"id": "IdentificationConsultItemsListContainer",
						"itemType": BPMSoft.ViewItemType.GRID,
						"markerValue": "IdentificationConsultItemsListContainer",
						"selectors": {"wrapEl": "#IdentificationConsultItemsListContainer"},
						"idProperty": "Id",
						"collection": {"bindTo": "IdentifiedConsultSubscriberPanelCollection"},
						"onGetItemConfig": {"bindTo": "getIdentifiedSubscriberPanelViewConfig"},
						"classes": {"wrapClassName": ["identification-items-list-container"]},
						"onItemClick": {"bindTo": "setIdentifiedSubscriber"},
						"visible": {"bindTo": "getIsConsultCallIdentificationContainerVisible"},
						"generator": "CtiContainerListGenerator.generatePartial"
					}
				},

				//endregion

				//region empty panel elements

				{
					"operation": "insert",
					"name": "EmptySearchResultContainer",
					"parentName": "ctiPanelMainContainer",
					"index": 9,
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"visible": {"bindTo": "getIsEmptySearchResultContainerVisible"},
						"classes": {
							"wrapClassName": ["empty-search-result-container"]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "EmptySearchResultImage",
					"parentName": "EmptySearchResultContainer",
					"propertyName": "items",
					"values": {
						"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
						"onPhotoChange": BPMSoft.emptyFn,
						"getSrcMethod": "getEmptySearchResultImageUrl",
						"classes": {
							"wrapClass": ["image-container"]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "EmptySearchResultLabel",
					"parentName": "EmptySearchResultContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"classes": {
							"labelClass": [
								"description-label"
							]
						},
						"caption": {"bindTo": "Resources.Strings.EmptySearchResultMessage"}
					}
				},

				//endregion

				//region communication history panels

				{
					"operation": "insert",
					"name": "CommunicationHistoryContainerList",
					"parentName": "ctiPanelMainContainer",
					"index": 10,
					"propertyName": "items",
					"values": {
						"id": "CommunicationHistoryContainerList",
						"itemType": BPMSoft.ViewItemType.GRID,
						"markerValue": "CommunicationHistoryContainerList",
						"selectors": {"wrapEl": "#CommunicationHistoryContainerList"},
						"idProperty": "Id",
						"collection": {"bindTo": "CommunicationHistoryPanelCollection"},
						"onGetItemConfig": {"bindTo": "getCommunicationHistoryPanelViewConfig"},
						"classes": {"wrapClassName": ["communication-history-items-list-container"]},
						"visible": {"bindTo": "getIsCommunicationHistoryVisible"},
						"generator": "CtiContainerListGenerator.generatePartial",
						"getEmptyMessageConfig": {"bindTo": "prepareEmptyGridMessageConfig"},
						"isEmpty": {"bindTo": "isEmptyCallHistoryMessageVisible"},
						"renderFinished": {"bindTo": "setAcademyMessageVisibility"}
					}
				},

				//endregion

				//region academy message
				{
					"operation": "insert",
					"name": "AcademyMessageContainerWrap",
					"parentName": "ctiPanelMainContainer",
					"index": 11,
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": {"wrapClassName": ["academy-message-container"]},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "AcademyMessageContainer",
					"parentName": "AcademyMessageContainerWrap",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": {"wrapClassName": ["academy-grid-message"]},
						"items": [],
						"visible": {"bindTo": "getIsAcademyMessageVisible"}
					}
				},
				{
					"operation": "insert",
					"name": "AcademyMessageDescription",
					"parentName": "AcademyMessageContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": {"wrapClassName": ["description t-label"]},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "AcademyMessageElement",
					"parentName": "AcademyMessageDescription",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.COMPONENT,
						"className": "BPMSoft.HtmlControl",
						"htmlContent": {"bindTo": "AcademyHelpMessage"}
					}
				}

				//endregion

			]
		};
	}
);
