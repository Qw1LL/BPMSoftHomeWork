define("ContactSyncSettingsEdit", ["ContactSyncSettingsEditResources", "SyncSettingsEditMixin", "ExchangeNUIConstants"],
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
						return "ContactSyncSettings";
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
					 * @inheritdoc BaseSyncSettingsEdit#getContactSyncSettingsInsert
					 * @overridden
					 */
					getContactSyncSettingsInsert: function() {
						return this.getEntitySyncSettingInsert();
					},

					/**
					 * @inheritdoc SyncSettingsEditMixin#setParametersToInsertEntitySyncSetting
					 * @overridden
					 */
					setParametersToInsertEntitySyncSetting: function(insert) {
						insert.setParameterValue("ImportContacts", 1,
								BPMSoft.DataValueType.BOOLEAN);
						insert.setParameterValue("ImportContactsAll", 1,
								BPMSoft.DataValueType.BOOLEAN);
						insert.setParameterValue("ImportContactsFromFolders", 0,
								BPMSoft.DataValueType.BOOLEAN);
						insert.setParameterValue("ExportContacts", 0,
								BPMSoft.DataValueType.BOOLEAN);
						insert.setParameterValue("ExportContactsAll", 1,
								BPMSoft.DataValueType.BOOLEAN);
						insert.setParameterValue("ExportContactsSelected", 0,
								BPMSoft.DataValueType.BOOLEAN);
						insert.setParameterValue("ExportContactsEmployers", 0,
								BPMSoft.DataValueType.BOOLEAN);
						insert.setParameterValue("ExportContactsCustomers", 0,
								BPMSoft.DataValueType.BOOLEAN);
						insert.setParameterValue("ExportContactsOwner", 0,
								BPMSoft.DataValueType.BOOLEAN);
						insert.setParameterValue("ExportContactsFromGroups", 0,
								BPMSoft.DataValueType.BOOLEAN);
						insert.setParameterValue("MailboxSyncSettings", this.get("MailboxSyncSettingsId"),
								BPMSoft.DataValueType.GUID);
						insert.setParameterValue("ImportContactsFolders", "",
								BPMSoft.DataValueType.TEXT);
						insert.setParameterValue("ExportContactsGroups", "",
								BPMSoft.DataValueType.TEXT);
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
