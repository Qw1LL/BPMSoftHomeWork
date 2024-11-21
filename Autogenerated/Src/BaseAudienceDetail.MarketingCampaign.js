define("BaseAudienceDetail", ["BaseAudienceDetailResources"],
	function(resources) {
		return {
			properties: {
				removeMode: {
					SELECTED: 0,
					FOLDER: 1,
					FILTERED: 2,
					AUDIENCE: 3
				},
				/**
				 * Last all records count request unique identifier.
				 * @type {String}
				 */
				lastAllCountRequestId: null,
				/**
				 * @abstract
				 */
				masterRecordEntitySchemaName: null,
				/**
				 * @protected
				 */
				manageAudienceHashPattern: "AudienceSectionModule/BaseManageAudienceSection"
			},
			messages: {
				/**
				 * @message SaveBeforeAction
				 * Provide trigger for save action before audience import.
				 */
				"SaveBeforeAction": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			attributes: {
				/**
				 * Count of all bulk email audience records for current email.
				 * @type {Number}
				 */
				"AllRecordsCount": {
					dataValueType: this.BPMSoft.DataValueType.INTEGER,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: 0
				}
			},
			methods: {
				/**
				 * @private
				 */
				_getDeleteAllMenuItem: function() {
					return this.getButtonMenuItem({
						Caption: "$Resources.Strings.DeleteAllMenuCaption",
						Click: "$onDeleteAllRecordsClick",
						Visible: "$isAudienceNotEmpty"
					});
				},

				/**
				 * @private
				 */
				_getManageAudienceMenuItem: function() {
					return this.getButtonMenuItem({
						Caption: "$Resources.Strings.ManageAudienceMenuCaption",
						Click: "$onManageAudienceClick",
						Visible: "$isAudienceNotEmpty"
					});
				},

				/**
				 * @private
				 */
				_getSelectedRecords: function() {
					if (this.$MultiSelect) {
						return this.getSelectedItems();
					}
					var activeRow = this.getActiveRow();
					if (activeRow && activeRow.$Id) {
						return [activeRow.$Id];
					}
					return null;
				},

				/**
				 * Cancels previous load all records count request.
				 * @private
				 */
				_abortPreviousAllCountRequest: function() {
					if (this.lastAllCountRequestId) {
						this.BPMSoft.AjaxProvider.abortRequestByInstanceId(this.lastAllCountRequestId);
					}
				},

				getDeleteRecordButtonEnabled: function() {
					return this.isAnySelected();
				},

				/**
				 * @protected
				 */
				isDeleteSelectedRecordsVisible: function() {
					var selectedRecords = this._getSelectedRecords();
					return selectedRecords &&
						selectedRecords.length > 0 &&
						this.getDeleteRecordButtonEnabled();
				},

				/**
				 * @protected
				 */
				isAudienceNotEmpty: function() {
					return Boolean(this.get("AllRecordsCount"));
				},

				/**
				 * Returns ESQ to select audience count for current bulk email.
				 * @protected
				 * @returns {BPMSoft.EntitySchemaQuery}
				 */
				getEsqForAllRecordsCount: function() {
					var esq = this.getEntitySchemaQuery();
					esq.columns.clear();
					esq.addAggregationSchemaColumn(this.primaryColumnName,
						this.BPMSoft.AggregationType.COUNT, "Count");
					var filter = BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
						this.masterRecordEntitySchemaName, this.$MasterRecordId);
					esq.filters.addItem(filter);
					return esq;
				},

				/**
				 * Loads all records count.
				 * @protected
				 */
				loadAllRecordsCountAsync: function() {
					this._abortPreviousAllCountRequest();
					var esq = this.getEsqForAllRecordsCount();
					esq.getEntityCollection(function(response) {
						if (response.success) {
							var result = response.collection.first();
							var count = result && result.$Count || 0;
							this.$AllRecordsCount = count;
						}
					}, this);
					this.lastAllCountRequestId = esq.instanceId;
				},

				/**
				 * Returns specific config for bulk email audience service to provide import action.
				 * @protected
				 * @abstract
				 * @param {Number} sourceType Source type for import action.
				 * @param {Array} sourceCollection Source data collection to import.
				 * @param {Number} estimatedCount Estimated records count to remove.
				 * @returns {Object}
				 */
				getDeleteAudienceConfig: BPMSoft.abstractFn,

				/**
				 * @protected
				 */
				getManageAudienceConfig: function() {
					return {
						url: this.manageAudienceUrlPattern,
						recordName: this.get("RecordName"),
						recordId: this.get("MasterRecordId"),
						audienceSchemaName: this.entitySchemaName
					};
				},

				/**
				 * @protected
				 */
				canManageAudience: function() {
					return false;
				},

				/**
				 * @inheritdoc BPMSoft.BaseDetailV2#updateDetail
				 * @override
				 */
				updateDetail: function(config) {
					config.reloadAll = true;
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetail#onGridDataLoaded
				 * @override
				 */
				onGridDataLoaded: function() {
					BPMSoft.ServerChannel.on(BPMSoft.EventName.ON_MESSAGE,
						this.onChannelMessageReceived, this);
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc BPMSoft.BaseObject#destroy
				 * @override
				 */
				destroy: function() {
					this.BPMSoft.ServerChannel.un(BPMSoft.EventName.ON_MESSAGE,
						this.onChannelMessageReceived, this);
					this.callParent(arguments);
				},

				/**
				 * @abstract
				 */
				onChannelMessageReceived: BPMSoft.abstractFn,

				/**
				 * Handler on delete records completed event.
				 * @protected
				 * @param {Object} result Service response result.
				 */
				onDeleteCompleted: function(result) {
					if (result.Success) {
						this.updateDetail({});
					} else {
						this.showInformationDialog(result.Message);
					}
					return result.Success;
				},

				/**
				 * Calls audience service to remove selected records.
				 * @protected
				 */
				deleteSelectedRecords: function() {
					var selectedRecords = this._getSelectedRecords();
					var config = this.getDeleteAudienceConfig(this.removeMode.SELECTED, selectedRecords,
						selectedRecords.length);
					this.callService(config, this.onDeleteCompleted, this);
				},

				/**
				 * Calls audience service to remove all records from current bulk email audience.
				 * @protected
				 */
				deleteAllRecords: function() {
					var config = this.getDeleteAudienceConfig(this.removeMode.AUDIENCE, [],
						this.$AllRecordsCount);
					this.callService(config, this.onDeleteCompleted, this);
				},

				/**
				 * Handler on delete all records button click event.
				 * @protected
				 */
				onDeleteAllRecordsClick: function() {
					var confirmationMessage = this.get("Resources.Strings.DeleteAllConfirmationMessage");
					this.showConfirmationDialog(confirmationMessage,
						function(returnCode) {
							if (returnCode === BPMSoft.MessageBoxButtons.OK.returnCode) {
								this.deleteAllRecords();
							}
						},
						[this.BPMSoft.MessageBoxButtons.OK.returnCode,
							this.BPMSoft.MessageBoxButtons.CANCEL.returnCode]);
				},

				/**
				 * Handler on manage audience menu item click event.
				 * @protected
				 */
				onManageAudienceClick: function() {
					var action = this.openManageAudienceSection.bind(this);
					this.trySaveBeforeAction(action);
				},

				/**
				 * @protected
				 */
				trySaveBeforeAction: function(action) {
					this.sandbox.publish("SaveBeforeAction", {
						action: action
					});
				},

				/**
				 * Opens manage audience section.
				 * @protected
				 */
				openManageAudienceSection: function() {
					var manageAudienceConfig = this.getManageAudienceConfig();
					this.sandbox.publish("PushHistoryState", {
						hash: manageAudienceConfig.url || this.manageAudienceUrlPattern,
						stateObj: {
							recordName: manageAudienceConfig.recordName || this.get("RecordName"),
							recordId: manageAudienceConfig.recordId || this.get("MasterRecordId"),
							audienceSchemaName: manageAudienceConfig.audienceSchemaName || this.entitySchemaName,
							canSaveFilter: false
						}
					});
				},

				/**
				 * @inheritdoc BPMSoft.GridUtilitiesV2#checkCanDeleteCallback
				 * @override
				 */
				checkCanDeleteCallback: function(result) {
					if (result) {
						this.showInformationDialog(resources.localizableStrings[result]);
						return;
					}
					var confirmationMessage = this.get("Resources.Strings.DeleteSelectedConfirmationMessage");
					this.showConfirmationDialog(confirmationMessage,
						function(returnCode) {
							if (returnCode === BPMSoft.MessageBoxButtons.OK.returnCode) {
								this.deleteSelectedRecords();
							}
						},
						[this.BPMSoft.MessageBoxButtons.OK.returnCode,
							this.BPMSoft.MessageBoxButtons.CANCEL.returnCode]);
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getDeleteRecordMenuItem
				 * @override
				 */
				getDeleteRecordMenuItem: function() {
					return this.getButtonMenuItem({
						Caption: "$Resources.Strings.DeleteSelectedMenuCaption",
						Click: "$deleteRecords",
						Visible: "$isDeleteSelectedRecordsVisible"
					});
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#addRecordOperationsMenuItems
				 * @override
				 */
				addRecordOperationsMenuItems: function(toolsButtonMenu) {
					this.callParent(arguments);
					if (!this.canManageAudience()) {
						return;
					}
					if (this.$IsEnabled !== false) {
						var deleteAllMenuItem = this._getDeleteAllMenuItem();
						toolsButtonMenu.addItem(deleteAllMenuItem);
					}
					var manageAudienceMenuItem = this._getManageAudienceMenuItem();
					toolsButtonMenu.addItem(manageAudienceMenuItem);
				}
			},
			diff: []
		};
	}
);
