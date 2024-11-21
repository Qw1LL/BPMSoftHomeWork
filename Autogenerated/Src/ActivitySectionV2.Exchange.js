define("ActivitySectionV2", ["ExchangeNUIConstants", "ConfigurationConstants", "SyncSettingsMixin"],
	function(ExchangeNUIConstants, ConfigurationConstants) {
		return {
			entitySchemaName: "Activity",
			messages: {
				/**
				 * @message ShowSyncSettingsSetTip
				 * Notify to show tip about completed set sync settings.
				 */
				"ShowSyncSettingsSetTip": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},
			mixins: {
				/**
				 * Activity synchronization mixin.
				 */
				"SyncSettinsMixin": "BPMSoft.SyncSettingsMixin"
			},
			attributes: {
				/**
				 * Flag for visibility of the completed synchronization.
				 */
				"IsSyncSettingsSetTipVisible": {dataValueType: BPMSoft.DataValueType.BOOLEAN}
			},
			methods: {
				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#init
				 * @overridden
				 */
				init: function() {
					this.callParent(arguments);
					this.sandbox.subscribe("ShowSyncSettingsSetTip", this.updateSyncSettingsSetAndShowTip, this);
				},

				/**
				 * ######### email #########.
				 * @protected
				 * @overridden
				 */
				loadEmails: function() {
					if (!this.get("isMailboxSyncExist")) {
						this.BPMSoft.showInformation(this.get("Resources.Strings.MailboxSettingsEmpty"));
						return;
					}
					var select = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "MailboxSyncSettings"
					});
					select.addColumn("[ActivityFolder:Name:MailboxName].Id", "ActivityFolderId");
					select.addColumn("SenderEmailAddress", "SenderEmailAddress");
					select.addColumn("MailServer.Id", "MailServerId");
					select.addColumn("MailServer.Type.Id", "MailServerTypeId");
					select.filters.addItem(select.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
						"SysAdminUnit", this.BPMSoft.SysValue.CURRENT_USER.value));
					select.filters.addItem(select.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
						"EnableMailSynhronization", true));
					select.filters.addItem(select.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
						"[ActivityFolder:Name:MailboxName].FolderType", ConfigurationConstants.Folder.Type.MailBox));
					select.getEntityCollection(function(response) {
						if (response.success) {
							this.downloadMessages(response.collection);
						}
					}, this);
				},

				/**
				 * ######### email #########.
				 * @private
				 * @param {BPMSoft.Collection} collection ######### ########### #########.
				 */
				downloadMessages: function(collection) {
					var requestsCount = 0;
					var messageArray = [];
					collection.each(function(item) {
						var requestUrl;
						var data = {};
						if (item.get("MailServerTypeId") === ExchangeNUIConstants.MailServer.Type.Exchange) {
							data = {
								create: true,
								interval: 0,
								serverId: item.get("MailServerId"),
								senderEmailAddress: item.get("SenderEmailAddress")
							};
							requestUrl = this.BPMSoft.workspaceBaseUrl +
								"/rest/MailboxSettingsService/CreateDeleteSyncJob";
						} else {
							requestUrl = this.BPMSoft.workspaceBaseUrl +
								"/ServiceModel/ProcessEngineService.svc/LoadImapEmailsProcess/" +
								"Execute?ResultParameterName=LoadResult" +
								"&MailBoxFolderId=" + item.get("ActivityFolderId");
						}
						this.showBodyMask();
						requestsCount++;
						this.Ext.Ajax.request({
							url: requestUrl,
							timeout: 180000,
							headers: {
								"Content-Type": "application/json",
								"Accept": "application/json"
							},
							method: "POST",
							scope: this,
							callback: function(request, success, response) {
								var responseData;
								if (success) {
									if (response.responseXML === null) {
										var result = this.Ext.decode(response.responseText);
										responseData = {
											Messages: []
										};
										if (result.CreateDeleteSyncJobResult) {
											responseData.Messages.push(result.CreateDeleteSyncJobResult);
										}
									} else {
										var responseValue = response.responseXML.firstChild.textContent;
										responseData = this.Ext.decode(this.Ext.decode(responseValue));
									}
									if (responseData && responseData.Messages.length > 0) {
										messageArray = messageArray.concat(responseData.Messages);
									}
								}
								if (--requestsCount <= 0) {
									this.refreshGridData();
									var message = this.get("Resources.Strings.LoadingMessagesComplete");
									if (messageArray.length > 0) {
										message = "";
										this.BPMSoft.each(messageArray, function(element) {
											message = message.concat(this.Ext.String.format("[{0}]: {1} ", element.key,
												element.message));
										}, this);
									}
									this.hideBodyMask();
									this.BPMSoft.utils.showInformation(message);
								}
							},
							jsonData: data || {}
						});
					}, this);
				},

				/**
				 * Synchronizes with Google and Exchange calendar and activities.
				 * @overridden
				 * @protected
				 */
				synchronizeNow: function() {
					this.callParent(arguments);
					if (this.get("IsExchangeSyncExist")) {
						this.synchronizeWithExchange();
					}
				},

				/**
				 * ######### ####### ######## ############# # ######### #######
				 * # ############# ############### ######## ######.
				 * @protected
				 * @overridden
				 */
				initMailBoxSyncSettings: function() {
					this.set("isMailboxSyncExist", false);
					this.set("IsExchangeSyncExist", false);
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "MailboxSyncSettings"
					});
					esq.clientESQCacheParameters = {cacheItemName: "ActivitySection_MailboxSyncSettings"};
					esq.addColumn("Id");
					esq.addColumn("EnableMailSynhronization");
					esq.addColumn("[ActivitySyncSettings:MailboxSyncSettings:Id].ImportTasks", "ImportTasks");
					esq.addColumn(
						"[ActivitySyncSettings:MailboxSyncSettings:Id].ImportAppointments", "ImportAppointments");
					esq.addColumn("[ActivitySyncSettings:MailboxSyncSettings:Id].ExportActivities", "ExportActivities");
					var filter = this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
						"SysAdminUnit", this.BPMSoft.SysValue.CURRENT_USER.value);
					esq.filters.addItem(filter);
					esq.getEntityCollection(function(response) {
						if (response.success) {
							if (response.collection.getCount() > 0) {
								this.set("isMailboxSyncExist",
									response.collection.getItems().some(function(entity) {
										return entity.get("EnableMailSynhronization") === true;
									}));
								this.set("IsExchangeSyncExist",
									response.collection.getItems().some(function(entity) {
										return entity.get("ImportTasks") === true ||
											entity.get("ImportAppointments") === true ||
											entity.get("ExportActivities") === true;
									}));
							}
						}
					}, this);
				},

				/**
				 * ######### ####### ############# # Exchange.
				 * @protected
				 */
				synchronizeWithExchange: function() {
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "ActivitySyncSettings"
					});
					esq.addColumn("Id");
					esq.addColumn("[MailboxSyncSettings:Id:MailboxSyncSettings].SenderEmailAddress",
						"SenderEmailAddress");
					esq.filters.addItem(esq.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
						"[MailboxSyncSettings:Id:MailboxSyncSettings].SysAdminUnit",
						this.BPMSoft.SysValue.CURRENT_USER.value));
					esq.filters.addItem(esq.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
						"[MailboxSyncSettings:Id:MailboxSyncSettings].MailServer.Type",
						ExchangeNUIConstants.MailServer.Type.Exchange));
					var filterGroup = esq.createFilterGroup();
					filterGroup.name = "SynActivitiesFilterGroup";
					filterGroup.logicalOperation = this.BPMSoft.LogicalOperatorType.OR;
					filterGroup.addItem(esq.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
						"ImportTasks", true));
					filterGroup.addItem(esq.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
						"ImportAppointments", true));
					filterGroup.addItem(esq.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
						"ExportActivities", true));
					esq.filters.addItem(filterGroup);
					esq.getEntityCollection(function(response) {
						if (response.success) {
							this.createExchangeSyncJobs.call(this, response.collection);
						}
					}, this);
				},

				/**
				 * ####### # ########## ############ ###### ## ############# ########### # Exchange.
				 * @protected
				 */
				createExchangeSyncJobs: function(exchangeSettings) {
					var requestsCount = 0;
					var messageArray = [];
					var requestUrl = BPMSoft.workspaceBaseUrl + "/rest/MailboxSettingsService/CreateActivitySyncJob";
					exchangeSettings.each(function(item) {
						requestsCount++;
						this.showBodyMask();
						var data = {
							interval: 0,
							senderEmailAddress: item.get("SenderEmailAddress")
						};
						this.BPMSoft.AjaxProvider.request({
							url: requestUrl,
							headers: {
								"Content-Type": "application/json",
								"Accept": "application/json"
							},
							method: "POST",
							jsonData: data,
							scope: this,
							callback: function(request, success, response) {
								if (success) {
									var responseData = this.Ext.decode(response.responseText);
									if (!this.Ext.isEmpty(responseData.CreateActivitySyncJob)) {
										messageArray = messageArray.concat(responseData.CreateActivitySyncJob);
									}
								}
								if (--requestsCount <= 0) {
									var message = this.get("Resources.Strings.SynchronizeWithExchangeStart");
									if (messageArray.length > 0) {
										message = "";
										this.BPMSoft.each(messageArray, function(element) {
											message = message.concat(this.Ext.String.format("[{0}]: {1} ", element.key,
												element.message));
										}, this);
									}
									this.hideBodyMask();
									this.BPMSoft.utils.showInformation(message);
								}
							}
						});
					}, this);
				},

				/**
				 * @inheritDoc BPMSoft.BaseSection#getSectionActions
				 * @overridden
				 */
				getSectionActions: function() {
					var actionMenuItems = this.callParent(arguments);
					if (this.get("canUseSyncFeaturesByBuildType")) {
						this.setSyncSectionActions(actionMenuItems);
					}
					return actionMenuItems;
				},

				/**
				 * @inheritDoc BPMSoft.BaseSection#isSeparateModeActionsButtonVisible
				 * @overridden
				 */
				isSeparateModeActionsButtonVisible: function() {
					return (!this.isSchedulerDataView() || this.get("canUseSyncFeaturesByBuildType"));
				},

				/**
				 * Returns set sync settings section action caption.
				 * @overridden
				 * @return {String} Caption.
				 */
				getSetSyncSettingsCaption: function() {
					return this.get("Resources.Strings.SetUpSynchronization");
				},

				/**
				 * Start synchronization with google account.
				 */
				synchronizeGoogle: function() {
					this.synchronizeWithGoogleCalendar();
				},

				/**
				 * Start synchronization with exchange account.
				 */
				synchronizeExchange: function() {
					this.synchronizeWithExchange();
				},

				/**
				 * @inheritDoc BPMSoft.SyncSettinsMixin#updateSyncSettingsSetAndShowTip
				 * @overridden
				 */
				updateSyncSettingsSetAndShowTip: function(itemId) {
					if (itemId) {
						this.set("IsExchangeSyncExist", true);
					} else {
						this.set("GoogleSyncExists", true);
					}
					this.mixins.SyncSettinsMixin.updateSyncSettingsSetAndShowTip.call(this, itemId);
				}
			},
			modules: /**SCHEMA_MODULES*/{
				"CalendarSyncErrors": {
					"config": {
						"isSchemaConfigInitialized": true,
						"schemaName": "CalendarSyncSettingsErrors",
						"useHistoryState": false
					}
				}
			}/**SCHEMA_MODULES*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "SeparateModeActionsButton",
					"values": {
						"tips": []
					}
				},
				{
					"operation": "insert",
					"parentName": "SeparateModeActionsButton",
					"propertyName": "tips",
					"name": "SyncSettingsSetTip",
					"values": {
						"content": {"bindTo": "Resources.Strings.SyncSettingsSetTipCaption"},
						"visible": {"bindTo": "IsSyncSettingsSetTipVisible"},
						"style": BPMSoft.TipStyle.WHITE,
						"linkClicked": {bindTo: "navigateToSyncSettingsWithSyncSettingsUpdate"},
						"behaviour": {
							"displayEvent": BPMSoft.TipDisplayEvent.NONE
						}
					}
				},
				{
					"operation": "merge",
					"parentName": "DataViewsContainer",
					"propertyName": "items",
					"name": "GridUtilsContainerWrapper",
					"values": {}
				},	
				{
					"operation": "insert",
					"name": "CalendarSyncErrors",
					"propertyName": "items",
					"parentName": "DataViewsContainer",
					"index": 2,
					"values": {
						"itemType": BPMSoft.ViewItemType.MODULE,
						"classes": {"wrapClassName": ["sync-settings-errors","calendar-sync-errors"]}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
