define("ActivitySyncSettingsEdit", ["ActivitySyncSettingsEditResources", "SyncSettingsEditMixin",
	"ExchangeNUIConstants"],
	function(resources, SyncSettingsEditMixin, ExchangeNUIConstants) {
			return {
				mixins: {
					/**
					 * Base logic synchronization mixin.
					 */
					"SyncSettingsEditMixin": "BPMSoft.SyncSettingsEditMixin"
				},
				messages: {
					/**
					 * @message ShowSyncSettingsSetTip
					 * Notify to show tip about completed set sync settings.
					 */
					"ShowSyncSettingsSetTip": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.PUBLISH
					}
				},
				methods: {
					/**
					 * @inheritdoc BPMSoft.SyncSettingsEditMixin#getEntitySchemaName
					 * @overridden
					 */
					getEntitySchemaName: function() {
						return "ActivitySyncSettings";
					},

					/**
					 * @inheritdoc BPMSoft.BaseSyncSettingsEdit#setFiltersToServerListEsq
					 * @overridden
					 */
					setFiltersToServerListEsq: function(esq) {
						this.addFiltersToServerListEsq(esq);
					},

					/**
					 * @inheritDoc BPMSoft.BaseSyncSettingsEdit#onSaved
					 * @overridden
					 */
					onSaved: function() {
						this.publishSyncSettingsIsSet();
						this.callParent(arguments);
					},

					/**
					 * @inheritdoc BPMSoft.BaseSyncSettingsEdit#onServerListItemClick
					 * @overridden
					 */
					onServerListItemClick: function(itemId) {
						if (itemId === ExchangeNUIConstants.MailServer.Gmail) {
							this.startGoogleAuth();
							this.onCancel();
							return;
						}
						this.callParent(arguments);
					},

					/**
					 * @inheritdoc BPMSoft.BaseSyncSettingsEdit#getMailboxInsert
					 * @overridden
					 */
					getMailboxInsert: function() {
						var insert = this.callParent(arguments);
						insert.setParameterValue("ExchangeAutoSynchronization", 1,
								BPMSoft.DataValueType.BOOLEAN);
						return insert;
					},

					/**
					 * @inheritdoc BPMSoft.BaseSyncSettingsEdit#getActivitySyncSettingsInsert
					 * @overridden
					 */
					getActivitySyncSettingsInsert: function() {
						return this.getEntitySyncSettingInsert();
					},

					/**
					 * @inheritdoc BPMSoft.SyncSettingsEditMixin#setParametersToInsertEntitySyncSetting
					 * @overridden
					 */
					setParametersToInsertEntitySyncSetting: function(insert) {
						var importDate = new Date();
						importDate.setDate(importDate.getDate() - 30);
						insert.setParameterValue("ImportTasks", 1,
								this.BPMSoft.DataValueType.BOOLEAN);
						insert.setParameterValue("ImportTasksAll", 1,
								this.BPMSoft.DataValueType.BOOLEAN);
						insert.setParameterValue("ImportTasksFromFolders", 0,
								this.BPMSoft.DataValueType.BOOLEAN);
						insert.setParameterValue("ImportTasksFolders", "",
								this.BPMSoft.DataValueType.TEXT);
						insert.setParameterValue("ImportAppointments", 1,
								this.BPMSoft.DataValueType.BOOLEAN);
						insert.setParameterValue("ImportAppointmentsAll", 1,
								this.BPMSoft.DataValueType.BOOLEAN);
						insert.setParameterValue("ImpAppointmentsFromCalendars", 0,
								this.BPMSoft.DataValueType.BOOLEAN);
						insert.setParameterValue("ImportAppointmentsCalendars", "",
								this.BPMSoft.DataValueType.TEXT);
						insert.setParameterValue("ExportActivities", 1,
								this.BPMSoft.DataValueType.BOOLEAN);
						insert.setParameterValue("ExportActivitiesAll", 1,
								this.BPMSoft.DataValueType.BOOLEAN);
						insert.setParameterValue("ExportTasks", 1,
								this.BPMSoft.DataValueType.BOOLEAN);
						insert.setParameterValue("ExportActivitiesFromGroups", 0,
								this.BPMSoft.DataValueType.BOOLEAN);
						insert.setParameterValue("ImportActivitiesFrom", importDate,
								this.BPMSoft.DataValueType.DATE);
						insert.setParameterValue("ExportActivitiesGroups", "",
								this.BPMSoft.DataValueType.TEXT);
						insert.setParameterValue("MailboxSyncSettings", this.get("MailboxSyncSettingsId"),
								BPMSoft.DataValueType.GUID);
					},

					/**
					 * @inheritdoc BPMSoft.BaseSyncSettingsEdit#addNewMailServerToList
					 * @overridden
					 */
					addNewMailServerToList: function(response) {
						var newEntity = response.entity;
						var addedServerTypeId = newEntity.get("Type").value;
						if (addedServerTypeId === ExchangeNUIConstants.MailServer.Type.Exchange) {
							var collection = this.get("ServerListCollection");
							var newEntityId = newEntity.get("Id");
							collection.add(newEntityId, newEntity);
						}
					}
				}
			};
		});