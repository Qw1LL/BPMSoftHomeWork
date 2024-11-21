define("EventTargetDetailV2", ["ConfigurationConstants", "BPMSoft", "MarketingEnums",
		"ConfigurationEnums", "SegmentsStatusUtils"],
		function(ConfigurationConstants, BPMSoft, MarketingEnums, enums, SegmentsStatusUtils) {
			return {
				entitySchemaName: "EventTarget",
				properties: {
					importSectionUrl: "AudienceSectionModule/ImportEventAudienceSection/Contact",
					manageAudienceHashPattern: "AudienceSectionModule/EventAudienceSection/Contact",
					masterRecordEntitySchemaName: "Event",
					audienceSchemaName: "Contact"
				},
				messages: {
					/**
					 * @message GetEventImportAudienceData
					 * @return {String} Current event audience data.
					 */
					"GetEventImportAudienceData": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.PUBLISH
					},
					/**
					 * @message ReloadEventQueueState
					 */
					"ReloadEventQueueState": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.PUBLISH
					}
				},
				methods: {

					/**
					 * Inits detail.
					 * @override
					 */
					init: function() {
						this.loadAllRecordsCountAsync();
						this.callParent(arguments);
						this.initAddMenuItems();
					},

					/**
					 * @inheritdoc BPMSoft.BaseDetailV2#updateDetail
					 * @override
					 */
					updateDetail: function() {
						this.callParent(arguments);
						this.loadAllRecordsCountAsync();
					},

					/**
					 * Handler on WebSocket channel message received event.
					 * @protected
					 * @param {BPMSoft.ServerChannel} channel WebSocket channel instance.
					 * @param {Object} message WebSocket message instance.
					 */
					onChannelMessageReceived: function(channel, message) {
						if (message.Header.Sender !== "EventQueueMessageNotifier") {
							return;
						}
						var messageBody = BPMSoft.decode(message.Body);
						if (messageBody.EventId === this.$MasterRecordId) {
							this.updateDetail({});
						}
					},

					/**
					 * Flag to indicate add record button visibility.
					 * @override
					 */
					getAddRecordButtonVisible: function() {
						return false;
					},

					/**
					 * ######### #### "##########".
					 * @protected
					 */
					initAddMenuItems: function() {
						var addMenuItems = Ext.create("BPMSoft.BaseViewModelCollection");
						if (!BPMSoft.Features.getIsEnabled("EventAudienceImport")) {
							addMenuItems.add("addContactItem", this.Ext.create("BPMSoft.BaseViewModel", {
								values: {
									"Caption": {"bindTo": "Resources.Strings.AddContactCaption"},
									"Click": {"bindTo": "addRecipient"},
									"Tag": "addContact"
								}
							}));
							addMenuItems.add("addContactFolderItem", this.Ext.create("BPMSoft.BaseViewModel", {
								values: {
									"Caption": {"bindTo": "Resources.Strings.AddContactFolderCaption"},
									"Click": {"bindTo": "addRecipient"},
									"Tag": "addContactFolder"
								}
							}));
						}
						this.set("addMenuItems", addMenuItems);
					},

					/**
					 * Calls specific method to add recipients.
					 * @protected
					 * @param {String} methodName Add recipient method name.
					 */
					addRecipient: function(methodName) {
						this.set("AddMethod", methodName);
						var addRecordMethod = this[methodName];
						addRecordMethod.call(this);
					},

					/**
					 * Handler on card saved event.
					 * @overridden
					 */
					onCardSaved: function() {
						var addMethod = this.get("AddMethod");
						if (addMethod === "addContactFolder") {
							this.addContactFolder(true);
						} else {
							this.callParent(arguments);
						}
					},

					/**
					 * Validates page before save.
					 * @protected
					 * @param {Function} callback ####### ######### ######
					 */
					validateCard: function(callback) {
						var cardState = this.sandbox.publish("GetCardState", null, [this.sandbox.id]);
						var isNew = (cardState.state === enums.CardStateV2.ADD ||
							cardState.state === enums.CardStateV2.COPY);
						if (isNew) {
							this.set("CardState", enums.CardStateV2.ADD);
							var args = {
								isSilent: true,
								messageTags: [this.sandbox.id]
							};
							this.sandbox.publish("SaveRecord", args, [this.sandbox.id]);
							return;
						}
						callback.call(this);
					},

					/**
					 * Adds new record to grid data.
					 * @protected
					 */
					addContact: function() {
						var recordId = this.get("MasterRecordId");
						this.set("DefaultValues", [
							{
								name: "Event",
								value: recordId
							},
							{
								name: "TargetItem",
								value: "Contact"
							}
						]);
						this.addRecord();
					},

					/**
					 * Adds new records by folder.
					 * @protected
					 * @param {Boolean} skipValidationCard Flag to specify that card validation action will be skipped.
					 */
					addContactFolder: function(skipValidationCard) {
						var addContactFolderFn = function() {
							var config = {
								entitySchemaName: "ContactFolder",
								multiSelect: true,
								columns: ["FolderType"]
							};
							var groupType = BPMSoft.createColumnInFilterWithParameters("FolderType",
								[ConfigurationConstants.Folder.Type.General,
								ConfigurationConstants.Folder.Type.Search]);
							groupType.comparisonType = BPMSoft.ComparisonType.EQUAL;
							config.filters = groupType;
							this.openLookup(config, this.addContactFolderCallback, this);
						};
						if (skipValidationCard === true) {
							addContactFolderFn.call(this);
						} else {
							this.validateCard(function() {
								addContactFolderFn.call(this);
							});
						}
					},

					/**
					 * Callback function for add contact by folder action.
					 * @private
					 * @param {Object} config Info about added data.
					 */
					addContactFolderCallback: function(config) {
						var eventId = this.get("MasterRecordId");
						var contactFolders = config.selectedRows;
						var foldersCount = contactFolders.getCount();
						var contactWillBeAddedMessage = (foldersCount === 1) ?
							this.get("Resources.Strings.ContactsOfOneWillBeAdded") :
							this.get("Resources.Strings.ContactsWillBeAdded");
						this.showInformationDialog(this.Ext.String.format(contactWillBeAddedMessage, foldersCount));
						var bq = this.Ext.create("BPMSoft.BatchQuery");
						contactFolders.each(function(item) {
							bq.add(this.getContactFolderInsert(eventId, item.Id));
						}, this);
						bq.execute(function() {
							this.timeoutBeforeUpdate = SegmentsStatusUtils.timeoutBeforeUpdate;
							SegmentsStatusUtils.updateContactList(this, "Event");
						}, this);
					},

					/**
					 * Returns query to add contacts by folder.
					 * @param {String} eventId Event unique identifier.
					 * @param {String} contactFolderId Contact folder unique identifier.
					 * @return {BPMSoft.InsertQuery} Insert query.
					 */
					getContactFolderInsert: function(eventId, contactFolderId) {
						var insertQuery = this.Ext.create("BPMSoft.InsertQuery", {
							rootSchemaName: "EventSegment"
						});
						insertQuery.setParameterValue("Event", eventId, BPMSoft.DataValueType.GUID);
						insertQuery.setParameterValue("Segment", contactFolderId, BPMSoft.DataValueType.GUID);
						insertQuery.setParameterValue("State", MarketingEnums.SegmentsStatus.REQUIERESUPDATING,
							BPMSoft.DataValueType.GUID);
						return insertQuery;
					},

					/**
					 * @inheritdoc BPMSoft.BaseGridDetailV2#getCopyRecordMenuItem
					 * @override
					 */
					getCopyRecordMenuItem: BPMSoft.emptyFn,

					/**
					 * @inheritdoc BPMSoft.BaseAudienceDetail#getDeleteAudienceConfig
					 * @override
					 */
					getDeleteAudienceConfig: function(sourceType, sourceCollection, estimatedCount) {
						return {
							serviceName: "EventAudience",
							methodName: "Remove",
							data: {
								EventId: this.$MasterRecordId,
								SourceCollection: sourceCollection || [],
								EstimatedEntitiesCount: estimatedCount || 0,
								SourceType: sourceType
							}
						};
					},

					/**
					 * @inheritdoc BPMSoft.BaseAudienceDetail#getManageAudienceConfig
					 * @override
					 */
					getManageAudienceConfig: function() {
						var config = this.callParent(arguments);
						var importAudienceData = this.sandbox.publish("GetEventImportAudienceData");
						Ext.apply(config, {
							url: this.manageAudienceHashPattern,
							recordName: importAudienceData.recordName,
							audienceSchemaName: this.audienceSchemaName
						});
						return config;
					},

					/**
					 * @inheritdoc BPMSoft.BaseAudienceDetail#canManageAudience
					 * @override
					 */
					canManageAudience: function() {
						return BPMSoft.Features.getIsEnabled("EventAudienceImport");
					},

					/**
					 * Opens event audience import section.
					 */
					openImportAudienceSection: function() {
						var importAudienceData = this.sandbox.publish("GetEventImportAudienceData");
						this.sandbox.publish("PushHistoryState", {
							hash: this.importSectionUrl,
							stateObj: {
								recordName: importAudienceData.recordName,
								entitySchema: "Contact",
								recordId: this.get("MasterRecordId"),
								canSaveFilter: false
							}
						});
					},

					/**
					 * @inheritdoc BPMSoft.BaseAudienceDetail#onDeleteCompleted
					 * @override
					 */
					onDeleteCompleted: function(result) {
						var res = this.callParent(arguments);
						if (res) {
							this.sandbox.publish("ReloadEventQueueState");
						}
						return res;
					},

					/**
					 * Handler on import audience click event.
					 */
					onImportAudienceClick: function() {
						if (!BPMSoft.Features.getIsEnabled("EventAudienceImport")) {
							return false;
						}
						var action = this.openImportAudienceSection.bind(this);
						this.trySaveBeforeAction(action);
					}
				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "merge",
						"name": "DataGrid",
						"values": {
							"rowDataItemMarkerColumnName": "Contact",
							"type": "listed",
							"listedConfig": {
								"name": "DataGridListedConfig",
								"items": [
									{
										"name": "ContactListedGridColumn",
										"bindTo": "Contact",
										"position": {
											"column": 1,
											"colSpan": 10
										},
										"type": BPMSoft.GridCellType.TITLE
									},
									{
										"name": "EventResponseListedGridColumn",
										"bindTo": "EventResponse",
										"position": {
											"column": 11,
											"colSpan": 6
										}
									},
									{
										"name": "NoteListedGridColumn",
										"bindTo": "Note",
										"position": {
											"column": 17,
											"colSpan": 8
										}
									}
								]
							},
							"tiledConfig": {
								"name": "DataGridTiledConfig",
								"grid": {
									"columns": 24,
									"rows": 3
								},
								"items": [
									{
										"name": "ContactTiledGridColumn",
										"bindTo": "Contact",
										"position": {
											"row": 1,
											"column": 1,
											"colSpan": 16
										},
										"type": BPMSoft.GridCellType.TITLE
									},
									{
										"name": "EventResponseTiledGridColumn",
										"bindTo": "EventResponse",
										"position": {
											"row": 1,
											"column": 17,
											"colSpan": 8
										}
									},
									{
										"name": "NoteTiledGridColumn",
										"bindTo": "Note",
										"position": {
											"row": 2,
											"column": 1,
											"colSpan": 24
										}
									}
								]
							}
						}
					},
					{
						"operation": "merge",
						"name": "AddTypedRecordButton",
						"parentName": "Detail",
						"propertyName": "tools",
						"values": {
							"itemType": BPMSoft.ViewItemType.BUTTON,
							"controlConfig": {
								"menu": {
									"items": {"bindTo": "addMenuItems"}
								}
							},
							"visible": "$getToolsVisible",
							"click": "$onImportAudienceClick"
						}
					}
				]/**SCHEMA_DIFF*/
			};
		}
);
